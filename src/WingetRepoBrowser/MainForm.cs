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


//todo:
// support multiple repo paths (; separated)
// implement/find custom sort algorithm for version-column
// download installers context menu with sha check

namespace WingetRepoBrowser
{
	public partial class MainForm : XtraForm
	{

		GridRowPopupMenuBehavior _gridViewHostsRowPopup;

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

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			var args = Environment.GetCommandLineArgs();
			if (args.Length >= 2)
			{
				textEditRepoFolder.Text = args[1];
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

			List<ManifestPackageVM> ds = new List<ManifestPackageVM>();
			IEnumerable<string> yamlFiles = Directory.EnumerateFiles(folder, "*.yaml", SearchOption.AllDirectories);
			foreach (string yamlFile in yamlFiles)
			{
				ManifestPackage package = Helpers.ReadYamlFile(yamlFile);
				ds.Add(new ManifestPackageVM(package, yamlFile));
			}

			gridControl1.DataSource = ds;
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
	}

}
