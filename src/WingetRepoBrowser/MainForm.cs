using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

using WingetRepoBrowserCore;


//todo:
// support multiple repo paths (; separated)


namespace WingetRepoBrowser
{
	public partial class MainForm : XtraForm
	{
		const string cGitRepoBaseUrl = "https://github.com/microsoft/winget-pkgs";

		AppSettings _appSettings;
		GridRowPopupMenuBehavior _gridViewManifestsRowPopup;
		List<ManifestPackageVM> _manifestVMs;
		YamlFileHelper _yamlFileHelper;

		public MainForm()
		{
			InitializeComponent();

			_gridViewManifestsRowPopup = new GridRowPopupMenuBehavior(gridView1);
			_gridViewManifestsRowPopup.SetMenuItems(CreateMenuItemsManifestsPopup());
			_yamlFileHelper = new YamlFileHelper();
		}

		private DXMenuItem[] CreateMenuItemsManifestsPopup()
		{
			//menu tooltip: https://www.devexpress.com/Support/Center/Question/Details/Q304975

			DXMenuItem[] result = new DXMenuItem[] {
				new DXMenuItem("OpenYamlFile", ItemOpenYamlFile_Click),
				new DXMenuItem("OpenYamlFolder", ItemOpenYamlFolder_Click),
				new DXMenuItem("OpenGitRepo", ItemOpenGitRepo_Click)
			};
			return result;
		}

		private void ItemOpenYamlFile_Click(object sender, EventArgs e)
		{
			ManifestPackageVM row = GetFocusedRow();
			if (row == null)
			{
				return;
			}

			OpenFileOrUrl(row.FilePath);
		}
		private void ItemOpenYamlFolder_Click(object sender, EventArgs e)
		{
			ManifestPackageVM row = GetFocusedRow();
			if (row == null)
			{
				return;
			}

			OpenFileOrUrl(Path.GetDirectoryName(row.FilePath));
		}
		private void ItemOpenGitRepo_Click(object sender, EventArgs e)
		{
			ManifestPackageVM row = GetFocusedRow();
			if (row == null)
			{
				return;
			}
			string[] parts = row.Id.Split('.');
			string vendor = parts[0];
			string name = parts[1];
			string url = cGitRepoBaseUrl + $"/tree/master/manifests/{vendor.ToLower()[0]}/{vendor}/{name}/{row.Version}";
			OpenFileOrUrl(url);
		}

		private void ShowMessageBox(string message)
		{
			MessageBox.Show(this, message, "WingetRepo Browser");
		}

		private ManifestPackageVM GetFocusedRow()
		{
			return gridView1.GetFocusedRow() as ManifestPackageVM;
		}
		private IEnumerable<ManifestPackageVM> GetSelectedRows()
		{
			return gridView1.GetSelectedRows().Select(item => gridView1.GetRow(item)).Cast<ManifestPackageVM>();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			//var args = Environment.GetCommandLineArgs();
			//if (args.Length >= 2)
			//{
			//	textEditRepoFolder.Text = args[1];
			//}
			//if (args.Length >= 3)
			//{
			//	textEditInstallersFolder.Text = args[2];
			//}

			string settingsFilePath = Path.Combine(Application.StartupPath, "AppSettings.json");
			if (File.Exists(settingsFilePath))
			{
				try
				{
					string json = File.ReadAllText(settingsFilePath);
					_appSettings = JsonSerializer.Deserialize<AppSettings>(json);
					textEditRepoFolder.Text = _appSettings.RepoFolder;
					textEditInstallersFolder.Text = _appSettings.InstallersFolder;
				}
				catch (Exception ex)
				{
					ShowMessageBox("Error while deserializing AppSettings: " + ex.Message);
				}
			}

		}


		private void gridView1_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
		{
			if (e.RowHandle == GridControl.InvalidRowHandle)
			{
				return;
			}

			e.RelationName = "Installers";
		}

		private void gridView1_MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
		{
			e.RelationCount = 1;
		}

		private void gridView1_MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
		{
			ManifestPackageVM row = gridView1.GetRow(e.RowHandle) as ManifestPackageVM;
			e.ChildList = row.Installers;
		}

		private static IEnumerable<string> FindAllYamlFiles(string folder)
		{
			return Directory.GetFiles(folder, "*.yaml", SearchOption.AllDirectories);
		}
		/*
		private static async Task<IEnumerable<string>> FindAllYamlFilesAsync(string folder)
		{
			using (var e = await Task.Run(() => Directory.EnumerateFiles(folder, "*.yaml", SearchOption.AllDirectories).GetEnumerator()))
			{
				while (await Task.Run(() => e.MoveNext()))
				{
					Use(e.Current);
				}
			}
		}
		*/
		private static async Task<IEnumerable<string>> FindAllYamlFilesAsync(string folder)
		{
			IEnumerable<string> e = await Task.Run(() => Directory.EnumerateFiles(folder, "*.yaml", SearchOption.AllDirectories));
			return e;
		}

		private async void simpleButtonSearch_Click(object sender, EventArgs e)
		{
			string folder = textEditRepoFolder.Text;
			if (!Directory.Exists(folder))
			{
				ShowMessageBox("The specified folder does not exist!");
				return;
			}

			memoEditMessages.Text = string.Empty;
			gridControl1.DataSource = null; //remove old list;
			simpleButtonCheckForNewDownloads.Enabled = false;
			simpleButtonCreateSubFoldersForSelected.Enabled = false;

			simpleButtonSearch.Enabled = false;
			gridView1.ShowLoadingPanel();

			try
			{

				IEnumerable<string> yamlFiles;
				try
				{
					//yamlFiles = await FindAllYamlFilesAsync(folder);
					yamlFiles = FindAllYamlFiles(folder);
				}
				catch (Exception ex)
				{

					// e.g. when using folder 'c:\' System.UnauthorizedAccessException: 'Access to the path 'C:\$Recycle.Bin\S-1-5-18' is denied.'
					ShowMessageBox(ex.Message);
					return;
				}


				LoadManifestsResult loadManifestsResult = await Task.Run(() => _yamlFileHelper.LoadAllManifests(yamlFiles));
				// LoadManifestsResult loadManifestsResult = _yamlFileHelper.LoadAllManifests(yamlFiles);

				IEnumerable<MultiFileYaml> multiFileYamls = loadManifestsResult.Manifests;
				List<ManifestPackageVM> tmpManifestVMs = new List<ManifestPackageVM>();
				foreach (MultiFileYaml multiFileYaml in multiFileYamls)
				{
					tmpManifestVMs.Add(new ManifestPackageVM(multiFileYaml));
				}

				if (loadManifestsResult.Messages.Any())
				{
					layoutControlItemMessages.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
					memoEditMessages.Text = string.Join(Environment.NewLine, loadManifestsResult.Messages);
				}
				_manifestVMs = tmpManifestVMs;
				gridControl1.DataSource = _manifestVMs;
			}
			finally
			{
				gridView1.HideLoadingPanel();
				simpleButtonSearch.Enabled = true;
			}
			simpleButtonCheckForNewDownloads.Enabled = true;
			simpleButtonCreateSubFoldersForSelected.Enabled = true;
		}



		private void repositoryItemButtonEditUrl_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			ButtonEdit buttonEdit = (ButtonEdit)sender;
			string fileOrUrl = (string)buttonEdit.EditValue;
			OpenFileOrUrl(fileOrUrl);
		}

		private void OpenFileOrUrl(string FileOrUrl)
		{
			try
			{
				Process.Start(FileOrUrl);
			}
			catch (Exception ex)
			{
				ShowMessageBox(ex.Message);
			}
		}

		private void simpleButtonOpenGitRepo_Click(object sender, EventArgs e)
		{
			OpenFileOrUrl(cGitRepoBaseUrl);
		}

		private void simpleButtonCheckForNewDownloads_Click(object sender, EventArgs e)
		{
			string installersFolder = textEditInstallersFolder.Text;
			if (!Directory.Exists(installersFolder))
			{
				ShowMessageBox("The specified installers-folder does not exist!");
				return;
			}

			Cursor saveCursor = Cursor.Current;
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				string[] idFiles = Directory.GetFiles(installersFolder, "*.wingetid", SearchOption.AllDirectories);
				string[] duplicateIdFiles = idFiles.GroupBy(item => GetKeyFromIdFilePath(item)).Where(g => g.Count() > 1).Select(g => g.Key).ToArray();
				if (duplicateIdFiles.Length > 0)
				{
					ShowMessageBox("Error: Multiple '.wingetid' files found for the following ID(s):" + Environment.NewLine + string.Join(Environment.NewLine, duplicateIdFiles));
					return;
				}
				Dictionary<string, string> packageIds = idFiles.ToDictionary(item => GetKeyFromIdFilePath(item));
				List<NewDownload> newDownloads = FindNewDownloads(_yamlFileHelper, packageIds, _manifestVMs);
				NewDownloadsForm form = new NewDownloadsForm(_yamlFileHelper);
				form.NewDownloads = newDownloads;
				if (_appSettings != null)
				{
					form.LocalesToDownload = _appSettings.LocalesToDownload;
				}
				form.ShowDialog(this);
			}
			finally
			{
				Cursor.Current = saveCursor;
			}
		}
		static string GetKeyFromIdFilePath(string wingetidFilePath)
		{
			return Path.GetFileNameWithoutExtension(wingetidFilePath).ToLower();
		}


		private static List<NewDownload> FindNewDownloads(YamlFileHelper yamlFileHelper, Dictionary<string, string> packageIds, IEnumerable<ManifestPackageVM> manifestPackages)
		{
			List<Tuple<ManifestPackageVM, string>> idFileTuples = manifestPackages.Join(packageIds, manifestPackage => manifestPackage.Id.ToLower(), i => i.Key, (mpvm, kvp) => Tuple.Create(mpvm, kvp.Value)).ToList();

			List<NewDownload> result = new List<NewDownload>();

			foreach (Tuple<ManifestPackageVM, string> idFileTuple in idFileTuples)
			{
				ManifestPackageVM manifestPackage = idFileTuple.Item1;
				string idFilePath = idFileTuple.Item2;

				string[] versionsToIgnoreDownload = Helpers.GetVersionsToIgnoreDownload(idFilePath);

				string idFileFolder = Path.GetDirectoryName(idFilePath);
				string versionFolder = Path.Combine(idFileFolder, ConvertVersionToDirectoryName(manifestPackage.Version)); // illegal chars in version shouldn't be a problem, because yaml files are stored in folders with version as name
				bool exists = versionsToIgnoreDownload.Any(v => v == manifestPackage.Version) || Directory.Exists(versionFolder);
				//if (manifestPackage.Version == "latest" && exists)
				if (false)//TODO: the following code crashes when downloaded yaml-files are not version 1.0.0
				{
					string downloadedYamlFilePath = Path.Combine(versionFolder, "latest.yaml");
					ManifestPackage_1_0_0 downloadedManifestPackage = yamlFileHelper.ReadYamlFile(downloadedYamlFilePath).Manifest;
					//TODO test all installers when winget supports multiple installers
					if (manifestPackage.Installers[0].Sha256 != downloadedManifestPackage.Installers[0].InstallerSha256)
					{
						FileInfo fi = new FileInfo(downloadedYamlFilePath);
						string versionSuffix = fi.LastWriteTime.ToString("_yyyy-MM-dd");
						downloadedManifestPackage.PackageVersion += versionSuffix;
						yamlFileHelper.WriteYamlFile(downloadedYamlFilePath, downloadedManifestPackage);
						Directory.Move(versionFolder, versionFolder + versionSuffix);
						exists = Directory.Exists(versionFolder);
					}
				}
				if (manifestPackage.Version != "latest")//TODO!!!!
				{
					if (!exists)
					{
						NewDownload dl = new NewDownload()
						{
							MultiFileYaml = manifestPackage.MultiFileYaml,
							VersionFolder = versionFolder,
							IdFilePath = idFilePath
						};
						result.Add(dl);
					}
				}
			}
			return result;
		}



		static string ReplaceInvalidChars(string filename)
		{
			return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
		}

		static string ConvertVersionToDirectoryName(string version)
		{
			return ReplaceInvalidChars(version);
		}

		private void simpleButtonCreateSubFoldersForSelected_Click(object sender, EventArgs e)
		{
			string installersFolder = textEditInstallersFolder.Text;
			if (!Directory.Exists(installersFolder))
			{
				ShowMessageBox("The specified installers-folder does not exist!");
				return;
			}

			DialogResult result = MessageBox.Show(this, "Do you really want to create subfolders for the selected packages?", "WingetRepo Browser", MessageBoxButtons.OKCancel);
			if (result != DialogResult.OK)
			{
				return;
			}

			IEnumerable<ManifestPackageVM> rows = GetSelectedRows().DistinctBy(item => item.Id);
			foreach (ManifestPackageVM manifestPackageVM in rows)
			{
				string packagePath = Path.Combine(installersFolder, manifestPackageVM.Id);
				Directory.CreateDirectory(packagePath);
				string idFilePath = Path.Combine(packagePath, manifestPackageVM.Id + ".wingetid");
				File.WriteAllText(idFilePath, "");
			}
		}

		private void gridView1_CustomDrawFooter(object sender, RowObjectCustomDrawEventArgs e)
		{
			if (this.gridView1.GroupCount > 0)
			{
				e.DefaultDraw();
				string groupRows = this.gridView1.DataController.GroupRowCount.ToString();
				e.Graphics.DrawString("GroupRowCount:" + Environment.NewLine + groupRows, e.Appearance.Font, Brushes.Black, e.Bounds);
				e.Handled = true;
			}
		}

		/*
		private void gridView1_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
		{
			GridView view = gridView1;
			if (e.Column.FieldName == nameof(ManifestPackageVM.ParsedPackageVersion))
			{
				object val1 = view.GetListSourceRowCellValue(e.ListSourceRowIndex1, e.Column);
				object val2 = view.GetListSourceRowCellValue(e.ListSourceRowIndex2, e.Column);
				e.Handled = true;
				e.Result = System.Collections.Comparer.Default.Compare(val1.ToString(), val2.ToString());
			}
		}
		*/


	}


	class NewDownload
	{
		public MultiFileYaml MultiFileYaml { get; set; }
		public string VersionFolder { get; set; }
		//public string FilePath { get; set; }
		//public ManifestPackage_1_0_0 InstallerPackage { get; set; }
		//public string InstallerPackageFilePath { get; set; }
		public string IdFilePath { get; set; }

	}



}
