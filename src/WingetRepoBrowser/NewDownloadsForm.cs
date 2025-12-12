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
		private GridRowPopupMenuBehavior _gridViewDownloadRowPopup;
		private YamlFileHelper _yamlFileHelper;

		public NewDownloadsForm(YamlFileHelper yamlFileHelper)
		{
			InitializeComponent();

			_gridViewDownloadRowPopup = new GridRowPopupMenuBehavior(gridView1);
			_gridViewDownloadRowPopup.SetMenuItems(CreateMenuItemsDownloadPopup());
			_yamlFileHelper = yamlFileHelper;
		}

		private DXMenuItem[] CreateMenuItemsDownloadPopup()
		{
			DXMenuItem[] result = [
				new DXMenuItem("Ignore selected version(s)", ItemIgnoreVersion_Click)
			];
			return result;
		}

		private void ItemIgnoreVersion_Click(object? sender, EventArgs e)
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

			//remove all selected rows from grid
			List<int> descendingRowHandles = gridView1.GetSelectedRows().OrderByDescending(i => i).ToList();
			gridView1.BeginDataUpdate();
			foreach (int rowHandle in descendingRowHandles)
			{
				gridView1.DeleteRow(rowHandle);
			}
			gridView1.EndDataUpdate();
		}

		private IEnumerable<NewDownloadVM> GetSelectedRows()
		{
			return gridView1.GetSelectedRows().Select(item => gridView1.GetRow(item)).Cast<NewDownloadVM>();
		}

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal List<NewDownload> NewDownloads { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string[] LocalesToDownload { get; set; }


		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			List<NewDownloadVM> ds = NewDownloads.Select(item => new NewDownloadVM(item)).ToList();
			gridControl1.DataSource = ds;
			progressBarControl1.Properties.Maximum = 100;
		}

		private InstallerDownloader _installerDownloader;
		private int _errorCount;

		private void simpleButtonDownload_Click(object sender, EventArgs e)
		{
			memoEdit1.Text = string.Empty;
			layoutControlItemCancel.Visibility = LayoutVisibility.Always;
			layoutControlItemDownload.Visibility = LayoutVisibility.Never;
			backgroundWorker1.RunWorkerAsync();
		}

		private void AddLogLine(int percentage, string? text)
		{
			if (percentage >= 0)
			{
				progressBarControl1.EditValue = percentage;
            }
			if(!string.IsNullOrEmpty(text))
            {
                memoEdit1.Text += text + Environment.NewLine;
            }
        }

        private void AddLogLineBackground(int percentage, string text)
		{
			backgroundWorker1.ReportProgress(percentage, text);
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			_installerDownloader = new InstallerDownloader();
			_errorCount = 0;

			List<NewDownloadVM> ds = (List<NewDownloadVM>)gridControl1.DataSource;
			int downloadIndex = 0;
			foreach (NewDownloadVM newDownloadVM in ds)
			{
				ProcessOneNewDownload(downloadIndex * 100 / ds.Count, newDownloadVM.NewDownload);
				++downloadIndex;
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

		private void ProcessOneNewDownload(int progressPercent, NewDownload newDownload)
		{
			string versionFolder = newDownload.VersionFolder;
			// create a fresh instance, otherwise the changes we will make would be visible in the GUI-grid
			MultiFileYaml mfy = new YamlFileHelper().LoadMultiFileYaml(newDownload.MultiFileYaml.MainYamlFilePath);

			var installersWithMatchingLocale = mfy.Installers.Where(i => HasMatchingLocale(i, LocalesToDownload));

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
					AddLogLineBackground(progressPercent, "Error: Unable to determine filename from download-url!");
					continue;
				}
				try
				{
					AddLogLineBackground(progressPercent, "Creating directory: " + versionFolder);
					Directory.CreateDirectory(versionFolder);
					string downloadFolder = versionFolder;
					if (newDownload.MultiFileYaml.Installers.Count > 1)
					{
						string archAndLocale = $"{manifestInstaller.Architecture ?? "null"}_{manifestInstaller.InstallerLocale ?? "null"}";
						downloadFolder = Path.Combine(versionFolder, archAndLocale);
						Directory.CreateDirectory(downloadFolder);
					}

					string downloadFilePath = Path.Combine(downloadFolder, downloadFileName);
					AddLogLineBackground(progressPercent, "Downloading: " + downloadUrl + " -> " + downloadFilePath);
					_installerDownloader.DownloadFile(downloadUrl, downloadFilePath);
					if (backgroundWorker1.CancellationPending)
					{
						return;
					}

					AddLogLineBackground(progressPercent, "Calculating Sha256-Hash from file");
					Helpers.CalculateFileHashResult calculateFileHashResult = Helpers.CalculateSha256HashFromFile(downloadFilePath);
					if (calculateFileHashResult.ErrorMessage == null)
					{
						string calculatedHash = calculateFileHashResult.Hash;
						string expectedHash = manifestInstaller.InstallerSha256.ToLower();
						if (calculatedHash != expectedHash)
						{
							AddLogLineBackground(progressPercent, $"Error: Sha256-Hash mismatch (expected {expectedHash} - calculated {calculatedHash})");
							++_errorCount;
						}
					}
					else
					{
						AddLogLineBackground(progressPercent, $"Error: Calculating Sha256-Hash: {calculateFileHashResult.ErrorMessage}");
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
					AddLogLineBackground(progressPercent, ex.ToString());
					if (Directory.GetFileSystemEntries(versionFolder).Length == 0)
					{
						try
						{
							Directory.Delete(versionFolder);
						}
						catch (Exception ex2)
						{
							AddLogLineBackground(progressPercent, ex2.ToString());
						}
					}
				}
			}

			if (Directory.Exists(versionFolder))
			{
				//save modified manifest to download-folder
				_yamlFileHelper.SaveMultiFileYaml(mfy, versionFolder);
			}
		}



		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			AddLogLine(e.ProgressPercentage, (string?)e.UserState);
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			layoutControlItemDownload.Visibility = LayoutVisibility.Always;
			layoutControlItemCancel.Visibility = LayoutVisibility.Never;

			AddLogLine(100, "");
			if (_errorCount == 0)
			{
				AddLogLine(100, "All downloads completed successfully.");
			}
			else
			{
				AddLogLine(100, $"{_errorCount} error(s) occurred!");
			}
			_installerDownloader.Dispose();
		}

		private void simpleButtonCancel_Click(object sender, EventArgs e)
		{
			AddLogLine(-1, "");
			AddLogLine(-1, "Cancellation pending...");

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

	internal class NewDownloadVM
	{
		private NewDownload _newDownload;

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
