using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;

using WingetRepoBrowserCore;

namespace WingetRepoBrowser
{
	public partial class NewDownloadsForm : XtraForm
	{
		GridRowPopupMenuBehavior _gridViewDownloadRowPopup;
		YamlFileHelper _yamlFileHelper;

		public NewDownloadsForm(YamlFileHelper yamlFileHelper)
		{
			InitializeComponent();

			_gridViewDownloadRowPopup = new GridRowPopupMenuBehavior(gridView1);
			_gridViewDownloadRowPopup.SetMenuItems(CreateMenuItemsDownloadPopup());
			_yamlFileHelper = yamlFileHelper;
		}

		private DXMenuItem[] CreateMenuItemsDownloadPopup()
		{
			DXMenuItem[] result = new DXMenuItem[] {
				new DXMenuItem("Ignore selected version(s)", ItemIgnoreVersion_Click)
			};
			return result;
		}

		private void ItemIgnoreVersion_Click(object sender, EventArgs e)
		{
			NewDownloadVM[] rows = GetSelectedRows().ToArray();
			if (rows.Length == 0)
			{
				return;
			}
			IEnumerable<IGrouping<string, NewDownload>> groupedByWingetId = rows.GroupBy(r => r.NewDownload.IdFilePath, r => r.NewDownload);
			foreach (IGrouping<string, NewDownload> group in groupedByWingetId)
			{
				string wingetidFilePath = group.Key;
				string[] versionsToIgnore = group.Select(nd => nd.MultiFileYaml.MainPackage.PackageVersion).ToArray();
				WingetIdSettings wingetidSettings = Helpers.LoadWingetIdSettings(wingetidFilePath);
				if (wingetidSettings == null)
				{
					wingetidSettings = new WingetIdSettings();
				}
				IEnumerable<string> oldVersions = wingetidSettings.VersionsToIgnoreDownload ?? new string[] { };
				wingetidSettings.VersionsToIgnoreDownload = oldVersions.Concat(versionsToIgnore).ToArray();
				Helpers.SaveWingetIdSettings(wingetidFilePath, wingetidSettings);
			}
		}

		private IEnumerable<NewDownloadVM> GetSelectedRows()
		{
			return gridView1.GetSelectedRows().Select(item => gridView1.GetRow(item)).Cast<NewDownloadVM>();
		}

		internal List<NewDownload> NewDownloads { get; set; }

		public string[] LocalesToDownload { get; set; }


		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			List<NewDownloadVM> ds = NewDownloads.Select(item => new NewDownloadVM(item)).ToList();
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

		private static bool HasMatchingLocale(ManifestInstaller_1_0_0 manifestInstaller, string[] localesToDownload)
		{
			if (string.IsNullOrEmpty(manifestInstaller.InstallerLocale))
			{
				return true;
			}
			return localesToDownload.Any(locale => string.Compare(locale, manifestInstaller.InstallerLocale, true) == 0);
		}

		private void ProcessOneNewDownload(NewDownload newDownload)
		{
			string versionFolder = newDownload.VersionFolder;
			// create a fresh instance, otherwise the changes we will make would be visible in the GUI-grid
			ManifestPackage_1_0_0 targetManifestPackage = _yamlFileHelper.ReadYamlFile(newDownload.MultiFileYaml.MainYamlFilePath).Manifest;
			ManifestInstaller_1_0_0[] installers = targetManifestPackage.Installers;

			ManifestPackage_1_0_0 installerPackage = null;
			if (newDownload.MultiFileYaml.InstallerPackageFilePath != null)
			{
				installerPackage = _yamlFileHelper.ReadYamlFile(newDownload.MultiFileYaml.InstallerPackageFilePath).Manifest;
				installers = installerPackage.Installers;
			}

			var installersWithMatchingLocale = installers.Where(i => HasMatchingLocale(i, LocalesToDownload));

			foreach (ManifestInstaller_1_0_0 manifestInstaller in installersWithMatchingLocale)
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
					if (newDownload.MultiFileYaml.InstallerPackageFilePath != null)
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
					Helpers.CalculateFileHashResult calculateFileHashResult = Helpers.CalculateSha256HashFromFile(downloadFilePath);
					if (calculateFileHashResult.ErrorMessage == null)
					{
						string calculatedHash = calculateFileHashResult.Hash;
						string expectedHash = manifestInstaller.InstallerSha256.ToLower();
						if (calculatedHash != expectedHash)
						{
							AddLogLineBackground($"Error: Sha256-Hash mismatch (expected {expectedHash} - calculated {calculatedHash})");
							++_errorCount;
						}
					}
					else
					{
						AddLogLineBackground($"Error: Calculating Sha256-Hash: {calculateFileHashResult.ErrorMessage}");
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
				string yamlTargetFilename = Path.GetFileName(newDownload.MultiFileYaml.MainYamlFilePath);
				string yamlTargetFilePath = Path.Combine(versionFolder, yamlTargetFilename);

				_yamlFileHelper.WriteYamlFile(yamlTargetFilePath, targetManifestPackage);
				if (newDownload.MultiFileYaml.InstallerPackageFilePath == null)
				{
					Trace.WriteLine("modified: " + newDownload.MultiFileYaml.MainYamlFilePath + " " + yamlTargetFilePath);
				}
				else
				{
					string yamlInstallerTargetFilePath = Helpers.GetInstallerPackageFilePath(yamlTargetFilePath);
					_yamlFileHelper.WriteYamlFile(yamlInstallerTargetFilePath, installerPackage);
					Trace.WriteLine("modified: " + newDownload.MultiFileYaml.InstallerPackageFilePath + " " + yamlInstallerTargetFilePath);

					string defaultLocale = targetManifestPackage.DefaultLocale;
					string yamlLocaleTargetFilePath = GetYamlLocaleFilePath(yamlTargetFilePath, defaultLocale);
					string yamlLocaleSourceFilePath = GetYamlLocaleFilePath(newDownload.MultiFileYaml.MainYamlFilePath, defaultLocale);
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

	class NewDownloadVM
	{
		NewDownload _newDownload;

		public NewDownloadVM(NewDownload newDownload)
		{
			_newDownload = newDownload;
		}
		internal NewDownload NewDownload { get { return _newDownload; } }


		public string PackageName { get { return _newDownload.MultiFileYaml.DefaultLocalePackage.PackageName; } }
		public string PackageVersion { get { return _newDownload.MultiFileYaml.MainPackage.PackageVersion; } }
		public string PackageIdentifier { get { return _newDownload.MultiFileYaml.MainPackage.PackageIdentifier; } }

	}
}
