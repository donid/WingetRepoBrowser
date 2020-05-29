using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WingetRepoBrowserCore;
using DevExpress.Utils.Menu;
using System.Diagnostics;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Net.Http;
using System.Net;
using System.Security.Cryptography;
using System.Collections;


//todo:
// support multiple repo paths (; separated)
// implement/find custom sort algorithm for version-column

namespace WingetRepoBrowser
{
	public partial class MainForm : XtraForm
	{

		GridRowPopupMenuBehavior _gridViewHostsRowPopup;
		List<ManifestPackageVM> _manifestVMs;

		public MainForm()
		{
			InitializeComponent();

			_gridViewHostsRowPopup = new GridRowPopupMenuBehavior(gridView1);
			_gridViewHostsRowPopup.SetMenuItems(CreateMenuItemsHostsPopup());
		}

		private DXMenuItem[] CreateMenuItemsHostsPopup()
		{
			//menu tooltip: https://www.devexpress.com/Support/Center/Question/Details/Q304975

			DXMenuItem[] result = new DXMenuItem[] {
				new DXMenuItem("OpenYamlFile", ItemOpenYamlFile_Click)
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

			var args = Environment.GetCommandLineArgs();
			if (args.Length >= 2)
			{
				textEditRepoFolder.Text = args[1];
			}
			if (args.Length >= 3)
			{
				textEditInstallersFolder.Text = args[2];
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

		private void simpleButtonSearch_Click(object sender, EventArgs e)
		{
			string folder = textEditRepoFolder.Text;
			if (!Directory.Exists(folder))
			{
				ShowMessageBox("The specified folder does not exist!");
				return;
			}

			_manifestVMs = new List<ManifestPackageVM>();
			IEnumerable<string> yamlFiles;
			try
			{
				yamlFiles = Directory.GetFiles(folder, "*.yaml", SearchOption.AllDirectories);
			}
			catch (Exception ex)
			{
				gridControl1.DataSource = null; //remove old list;
				simpleButtonCheckForNewDownloads.Enabled = false;
				simpleButtonCreateSubFoldersForSelected.Enabled = false;

				// e.g. when using folder 'c:\' System.UnauthorizedAccessException: 'Access to the path 'C:\$Recycle.Bin\S-1-5-18' is denied.'
				ShowMessageBox(ex.Message);
				return;
			}

			foreach (string yamlFile in yamlFiles)
			{
				ManifestPackage package = Helpers.ReadYamlFile(yamlFile);
				_manifestVMs.Add(new ManifestPackageVM(package, yamlFile));
			}

			gridControl1.DataSource = _manifestVMs;
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
			OpenFileOrUrl("https://github.com/microsoft/winget-pkgs");
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
				Dictionary<string, string> packageIds = idFiles.ToDictionary(item => Path.GetFileNameWithoutExtension(item));// todo catch ArgumentException for duplicate keys
				List<NewDownload> newDownloads = FindNewDownloads(packageIds, _manifestVMs.Select(item => item.Package));
				NewDownloadsForm form = new NewDownloadsForm();
				form.NewDownloads = newDownloads;
				form.ShowDialog();
			}
			finally
			{
				Cursor.Current = saveCursor;
			}
		}

		private static List<NewDownload> FindNewDownloads(Dictionary<string, string> packageIds, IEnumerable<ManifestPackage> manifestPackages)
		{
			List<NewDownload> result = new List<NewDownload>();
			foreach (ManifestPackage manifestPackage in manifestPackages)
			{
				if (packageIds.TryGetValue(manifestPackage.Id, out string idFilePath))
				{
					string idFileFolder = Path.GetDirectoryName(idFilePath);
					string versionFolder = Path.Combine(idFileFolder, ConvertVersionToDirectoryName(manifestPackage.Version)); // illegal chars in version shouldn't be a problem, because yaml files are stored in folders with version as name
					bool exists = Directory.Exists(versionFolder);
					if (!exists)
					{
						result.Add(new NewDownload() { ManifestPackage = manifestPackage, VersionFolder = versionFolder });
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



	}


	class NewDownload
	{
		public ManifestPackage ManifestPackage { get; set; }
		public string VersionFolder { get; set; }

	}

	

}
