using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using WingetRepoBrowserCore;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Web;

namespace WingetRepoBrowser
{
	public partial class NewDownloadsForm : XtraForm
	{

		public NewDownloadsForm()
		{
			InitializeComponent();
		}

		internal List<NewDownload> NewDownloads { get; set; }

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			List<ManifestPackage> ds = NewDownloads.Select(item => item.ManifestPackage).ToList();
			gridControl1.DataSource = ds;
		}

		InstallerDownloader _installerDownloader;
		int _errorCount;

		private void simpleButtonDownload_Click(object sender, EventArgs e)
		{
			memoEdit1.Text = string.Empty;
			layoutControlItemCancel.Visibility = LayoutVisibility.Always;
			layoutControlItemDownload.Visibility = LayoutVisibility.Never;
			backgroundWorker1.RunWorkerAsync();
		}

		void AddLogLine(string text)
		{
			memoEdit1.Text += text + Environment.NewLine;
		}
		void AddLogLineBackground(string text)
		{
			backgroundWorker1.ReportProgress(0, text);
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			_installerDownloader = new InstallerDownloader();
			_errorCount = 0;
			foreach (NewDownload newDownload in NewDownloads)
			{
				string versionFolder = newDownload.VersionFolder;
				// create a fresh instance, otherwise the changes we will make would be visible in the GUI-grid
				ManifestPackage targetManifestPackage = Helpers.ReadYamlFile(newDownload.FilePath);

				//TODO select specific installer when winget supports multiple installers
				foreach (ManifestInstaller manifestInstaller in targetManifestPackage.Installers)
				{
					string downloadUrl = manifestInstaller.Url;
					string downloadFileName = _installerDownloader.GetFileNameFromUrl(downloadUrl);
					try
					{
						AddLogLineBackground("Creating directory: " + versionFolder);
						Directory.CreateDirectory(versionFolder);
						string downloadFilePath = Path.Combine(versionFolder, downloadFileName);
						AddLogLineBackground("Downloading: " + downloadUrl + " -> " + downloadFilePath);
						_installerDownloader.DownloadFile(downloadUrl, downloadFilePath);
						if (backgroundWorker1.CancellationPending) return;
						AddLogLineBackground("Calculating Sha256-Hash from file");
						string calculatedHash = Helpers.CalculateSha256HashFromFile(downloadFilePath);
						string expectedHash = manifestInstaller.Sha256.ToLower();
						if (calculatedHash != expectedHash)
						{
							AddLogLineBackground($"Error: Sha256-Hash mismatch (expected {expectedHash} - calculated {calculatedHash})");
							++_errorCount;
						}


						manifestInstaller.Url = downloadFileName;

						if (backgroundWorker1.CancellationPending) return;
					}
					catch (Exception ex)
					{
						++_errorCount;
						AddLogLineBackground(ex.ToString());
						if (Directory.GetFiles(versionFolder).Length == 0)
						{
							Directory.Delete(versionFolder);
						}
					}
				}
				//save modified manifest to download-folder
				string yamlTargetFilename = Path.GetFileName(newDownload.FilePath);
				string yamlTargetFilePath = Path.Combine(versionFolder, yamlTargetFilename);
				if (Directory.Exists(versionFolder))
				{
					Helpers.WriteYamlFile(yamlTargetFilePath, targetManifestPackage);
				}
			}
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			AddLogLine((string)e.UserState);
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			layoutControlItemDownload.Visibility = LayoutVisibility.Always;
			layoutControlItemCancel.Visibility = LayoutVisibility.Never;

			AddLogLine("");
			if (_errorCount == 0)
			{
				AddLogLine("All downloads completed successfully.");
			}
			else
			{
				AddLogLine($"{_errorCount} error(s) occurred!");
			}
			_installerDownloader.Dispose();
		}

		private void simpleButtonCancel_Click(object sender, EventArgs e)
		{
			AddLogLine("");
			AddLogLine("Cancellation pending...");

			layoutControlItemCancel.Visibility = LayoutVisibility.Never;
			backgroundWorker1.CancelAsync();
		}

		private void NewDownloadsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (backgroundWorker1.IsBusy)
			{
				e.Cancel = true;
				MessageBox.Show(this, "Please cancel download(s) first!", "WingetRepoBrowser");
			}
		}
	}


}