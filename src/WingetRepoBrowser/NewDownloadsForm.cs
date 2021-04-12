using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WingetRepoBrowserCore;

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

			List<ManifestPackage_1_0_0> ds = NewDownloads.Select(item => item.ManifestPackage).ToList();
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
				ProcessOneNewDownload(newDownload);
			}
		}

		private void ProcessOneNewDownload(NewDownload newDownload)
		{
			string versionFolder = newDownload.VersionFolder;
			// create a fresh instance, otherwise the changes we will make would be visible in the GUI-grid
			ManifestPackage_1_0_0 targetManifestPackage = Helpers.ReadYamlFile(newDownload.FilePath);
			ManifestInstaller_1_0_0[] installers = targetManifestPackage.Installers;

			ManifestPackage_1_0_0 installerPackage = null;
			if (newDownload.InstallerPackageFilePath != null)
			{
				installerPackage = Helpers.ReadYamlFile(newDownload.InstallerPackageFilePath);
				installers = installerPackage.Installers;
			}

			foreach (ManifestInstaller_1_0_0 manifestInstaller in installers)
			{
				string downloadUrl = manifestInstaller.InstallerUrl;
				string downloadFileName = _installerDownloader.GetFileNameFromUrl(downloadUrl, out Uri responseUri);
				if (responseUri != null)
				{
					// this download url returns html instead of the .exe
					// https://sourceforge.net/projects/keepass/files/KeePass%202.x/2.46/KeePass-2.46-Setup.exe/download 
					// but the returned responseUri works:
					// https://downloads.sourceforge.net/project/keepass/KeePass%202.x/2.46/KeePass-2.46-Setup.exe
					downloadUrl = responseUri.ToString();
				}
				if (downloadFileName == null)
				{
					AddLogLineBackground("Error: Unable to determine filename from download-url!");
					continue;
				}
				try
				{
					AddLogLineBackground("Creating directory: " + versionFolder);
					Directory.CreateDirectory(versionFolder);
					string downloadFolder = versionFolder;
					if (newDownload.InstallerPackageFilePath != null)
					{
						string archAndLocale = $"{manifestInstaller.Architecture ?? "null"}_{manifestInstaller.InstallerLocale ?? "null"}";
						downloadFolder = Path.Combine(versionFolder, archAndLocale);
						Directory.CreateDirectory(downloadFolder);
					}

					string downloadFilePath = Path.Combine(downloadFolder, downloadFileName);
					AddLogLineBackground("Downloading: " + downloadUrl + " -> " + downloadFilePath);
					_installerDownloader.DownloadFile(downloadUrl, downloadFilePath);
					if (backgroundWorker1.CancellationPending)
					{
						return;
					}

					AddLogLineBackground("Calculating Sha256-Hash from file");
					string calculatedHash = Helpers.CalculateSha256HashFromFile(downloadFilePath);
					string expectedHash = manifestInstaller.InstallerSha256.ToLower();
					if (calculatedHash != expectedHash)
					{
						AddLogLineBackground($"Error: Sha256-Hash mismatch (expected {expectedHash} - calculated {calculatedHash})");
						++_errorCount;
					}

					manifestInstaller.InstallerUrl = downloadFileName + " |# " + manifestInstaller.InstallerUrl; //HACK!!!

					if (backgroundWorker1.CancellationPending)
					{
						return;
					}
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

			if (Directory.Exists(versionFolder))
			{
				//save modified manifest to download-folder
				string yamlTargetFilename = Path.GetFileName(newDownload.FilePath);
				string yamlTargetFilePath = Path.Combine(versionFolder, yamlTargetFilename);

				Helpers.WriteYamlFile(yamlTargetFilePath, targetManifestPackage);
				if (newDownload.InstallerPackageFilePath == null)
				{
					Trace.WriteLine("modified: " + newDownload.FilePath + " " + yamlTargetFilePath);
				}
				else
				{
					string yamlInstallerTargetFilePath = Helpers.GetInstallerPackageFilePath(yamlTargetFilePath);
					Helpers.WriteYamlFile(yamlInstallerTargetFilePath, installerPackage);
					Trace.WriteLine("modified: " + newDownload.InstallerPackageFilePath + " " + yamlInstallerTargetFilePath);

					string defaultLocale = targetManifestPackage.DefaultLocale;
					string yamlLocaleTargetFilePath = GetYamlLocaleFilePath(yamlTargetFilePath, defaultLocale);
					string yamlLocaleSourceFilePath = GetYamlLocaleFilePath(newDownload.FilePath, defaultLocale);
					File.Copy(yamlLocaleSourceFilePath, yamlLocaleTargetFilePath);
				}
			}
		}

		private static string GetYamlLocaleFilePath(string yamlFilePath, string locale)
		{
			return Path.ChangeExtension(yamlFilePath, ".locale." + locale + ".yaml");
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
