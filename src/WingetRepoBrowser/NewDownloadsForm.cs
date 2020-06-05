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
		// newer, but very specific: "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:77.0) Gecko/20100101 Firefox/77.0";
		// or "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)"
		const string cUserAgent = "Mozilla/4.0 (Windows NT 10.0; Win64; x64)";


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

		public static string GetFileNameFromUrl(string url)
		{

			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			req.Method = "HEAD";
			//without this: "https://fossies.org/windows/misc/audacity-win-2.4.1.exe" -> WebException 403 forbidden
			//req.Headers.Add("user-agent" -> System.ArgumentException: 'The 'user-agent' header must be modified using the appropriate property or method. Parameter name: name'

			// https://github.com/HandBrake/HandBrake/releases/download/1.3.2/HandBrake-1.3.2-x86_64-Win_GUI.exe
			// this and other github release URIs throws 403 even with useragent, but webclient.downloadfileworks

			if (req.Host.ToLower() != "sourceforge.net")//HACK!! sourceforge does not remove 'download' at the end of ResponseUri when we provide UserAgent
			{
				req.UserAgent = cUserAgent;
			}

			WebResponse resp =null;
			try
			{
				resp = req.GetResponse();
			}
			catch (WebException /*ex*/)
			{
				string fileNameFromUrl = Path.GetFileName(url);
				if (fileNameFromUrl.Contains('?') || fileNameFromUrl.Contains('=') )
				{
					return "unknown.bin";//TODO
				}
				return fileNameFromUrl;
			}
			using (resp)
			{
				// Try to extract the filename from the Content-Disposition header
				string contDisp = resp.Headers["Content-Disposition"];
				if (!string.IsNullOrEmpty(contDisp))
				{
					ContentDisposition parsedContDisp = new ContentDisposition(contDisp);
					return parsedContDisp.FileName;
				}

				string location = resp.Headers["Location"];
				if (location != null)
				{
					return Path.GetFileName(location);
				}

				//string fileNameFromUrl = Path.GetFileName(url);
				//if (fileNameFromUrl.Contains('?') || fileNameFromUrl.Contains('=') )
				//{
				//	return Path.GetFileName(resp.ResponseUri.ToString());
				//}

				return Path.GetFileName(resp.ResponseUri.ToString());
			}

		}

		WebClient _webClient;
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
			_webClient = new WebClient();
			//without this: "https://fossies.org/windows/misc/audacity-win-2.4.1.exe" -> WebException 403 forbidden
			_webClient.Headers.Add("user-agent", cUserAgent);
			_errorCount = 0;
			foreach (NewDownload newDownload in NewDownloads)
			{
				string versionFolder = newDownload.VersionFolder;

				//TODO select specific installer when winget supports multiple installers
				ManifestPackage manifestPackage = newDownload.ManifestPackage;
				foreach (ManifestInstaller manifestInstaller in manifestPackage.Installers)
				{
					string downloadUrl = manifestInstaller.Url;
					string downloadFileName = GetFileNameFromUrl(downloadUrl);
					try
					{
						AddLogLineBackground("Creating directory: " + versionFolder);
						Directory.CreateDirectory(versionFolder);
						string downloadFilePath = Path.Combine(versionFolder, downloadFileName);
						AddLogLineBackground("Downloading: " + downloadUrl + " -> " + downloadFilePath);
						_webClient.DownloadFile(downloadUrl, downloadFilePath);// todo create a yaml file with the chosen local filename as url in the installer?
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
				if(Directory.Exists(versionFolder))
				{
					Helpers.WriteYamlFile(yamlTargetFilePath, manifestPackage);
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
			_webClient.Dispose();
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