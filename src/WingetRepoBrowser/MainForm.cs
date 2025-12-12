using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WingetRepoBrowserCore;


//todo:
// support multiple repo paths (; separated)


namespace WingetRepoBrowser
{
    public partial class MainForm : XtraForm
    {
        private const string cGitRepoBaseUrl = "https://github.com/microsoft/winget-pkgs";
        private AppSettings _appSettings;
        private GridRowPopupMenuBehavior _gridViewManifestsRowPopup;
        private List<ManifestPackageVM> _manifestVMs;
        private YamlFileHelper _yamlFileHelper;

        public MainForm()
        {
            InitializeComponent();

            _gridViewManifestsRowPopup = new GridRowPopupMenuBehavior(gridView1);
            _gridViewManifestsRowPopup.SetMenuItems(CreateMenuItemsManifestsPopup());
            _yamlFileHelper = new YamlFileHelper();

            // Hook up repository-folder Leave event to check last commit when user finishes editing the path
            this.textEditRepoFolder.Leave += TextEditRepoFolder_Leave;
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
            //    textEditRepoFolder.Text = args[1];
            //}
            //if (args.Length >= 3)
            //{
            //    textEditInstallersFolder.Text = args[2];
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

            // Start an initial check for the last commit (non-blocking)
            _ = UpdateLastCommitDisplayAsync();

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

        private static List<string> FindAllYamlFiles(string folder, IProgress<int> progress)
        {
            IEnumerable<string> enumerable = Directory.EnumerateFiles(folder, "*.yaml", SearchOption.AllDirectories);
            List<string> result = new List<string>();
            int count = 0;

            foreach (string item in enumerable)
            {
                result.Add(item);
                progress.Report(++count);
            }
            return result;
        }

        private static async Task<IEnumerable<string>> FindAllYamlFilesAsync(string folder, IProgress<int> progress)
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
            barEditItemMarquee.EditValue = 0;
            barEditItemProgress.EditValue = 0;
            repositoryItemMarqueeProgressBar1.Paused = false;
            barEditItemMarquee.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            try
            {

                List<string> yamlFiles;
                try
                {
                    //yamlFiles = await FindAllYamlFilesAsync(folder);
                    IProgress<int> progressDiscover = new Progress<int>(count => barEditItemMarquee.EditValue = count);
                    yamlFiles = await Task.Run(() => FindAllYamlFiles(folder, progressDiscover));
                }
                catch (Exception ex)
                {

                    repositoryItemMarqueeProgressBar1.Paused = true;
                    // e.g. when using folder 'c:\' System.UnauthorizedAccessException: 'Access to the path 'C:\$Recycle.Bin\S-1-5-18' is denied.'
                    ShowMessageBox(ex.Message);
                    return;
                }

                repositoryItemMarqueeProgressBar1.Paused = true;
                barEditItemProgress.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                IProgress<int> progressRead = new Progress<int>(count => { if (count % 200 == 0) barEditItemProgress.EditValue = count * 100.0 / yamlFiles.Count; });
                LoadManifestsResult loadManifestsResult = await Task.Run(() => _yamlFileHelper.LoadAllManifests(yamlFiles, progressRead));

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
                barEditItemMarquee.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barEditItemProgress.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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

        private static string GetKeyFromIdFilePath(string wingetidFilePath)
        {
            return Path.GetFileNameWithoutExtension(wingetidFilePath).ToLower();
        }


        private static List<NewDownload> FindNewDownloads(YamlFileHelper yamlFileHelper, Dictionary<string, string> packageIds, IEnumerable<ManifestPackageVM> manifestPackages)
        {
            List<Tuple<ManifestPackageVM, string>> idFileTuples = manifestPackages.Join(packageIds, manifestPackage => manifestPackage.Id.ToLower(), i => i.Key, (mpvm, kvp) => Tuple.Create(mpvm, kvp.Value));

            List<NewDownload> result = new List<NewDownload>();

            foreach (Tuple<ManifestPackageVM, string> idFileTuple in idFileTuples)
            {
                ManifestPackageVM manifestPackage = idFileTuple.Item1;
                string idFilePath = idFileTuple.Item2;

                string[] versionsToIgnoreDownload = Helpers.GetVersionsToIgnoreDownload(idFilePath);

                string idFileFolder = Path.GetDirectoryName(idFilePath);
                string versionFolder = Path.Combine(idFileFolder, ConvertVersionToDirectoryName(manifestPackage.Version)); // illegal chars in version shouldn't be a problem, because yaml files are stored in[...]
                bool exists = versionsToIgnoreDownload.Any(v => v == manifestPackage.Version) || Directory.Exists(versionFolder);
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
            return result;
        }

        private static string ReplaceInvalidChars(string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }

        private static string ConvertVersionToDirectoryName(string version)
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

        private async void TextEditRepoFolder_Leave(object sender, EventArgs e)
        {
            await UpdateLastCommitDisplayAsync();
        }

        private async Task UpdateLastCommitDisplayAsync()
        {
            string path = textEditRepoFolder.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(path)) return;

            var savedText = memoEditMessages.Text;
            memoEditMessages.Text = "Checking git info...";

            var repoInfo = await GitHelpers.GetRepoCommitInfoAsync(path);

            if (repoInfo == null)
            {
                memoEditMessages.Text = $"Not a git repo or an error occurred for path: {path}" + Environment.NewLine + savedText;
                return;
            }

            string localLine = repoInfo.Local != null
                ? $"Local HEAD: {ShortSha(repoInfo.Local.Sha)} — {repoInfo.Local.Date:u} — {repoInfo.Local.Message}"
                : "Local HEAD: (no commits)";

            string remoteLine = repoInfo.Remote != null
                ? $"Remote tip: {ShortSha(repoInfo.Remote.Sha)} — {repoInfo.Remote.Date:u} — {repoInfo.Remote.Message}"
                : "Remote tip: (no origin/main or origin/master detected or fetch failed)";

            string display = $"Repo: {path}{Environment.NewLine}{localLine}{Environment.NewLine}{remoteLine}{Environment.NewLine}{Environment.NewLine}{savedText}";

            memoEditMessages.Text = display;
        }

        private static string ShortSha(string sha)
        {
            if (string.IsNullOrEmpty(sha)) return sha;
            return sha.Length >= 7 ? sha.Substring(0, 7) : sha;
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

    internal class NewDownload
    {
        public MultiFileYaml MultiFileYaml { get; set; }
        public string VersionFolder { get; set; }
        //public string FilePath { get; set; }
        //public ManifestPackage_1_0_0 InstallerPackage { get; set; }
        //public string InstallerPackageFilePath { get; set; }
        public string IdFilePath { get; set; }

    }



}
