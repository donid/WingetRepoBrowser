﻿namespace WingetRepoBrowser
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colInstArch = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstUrl = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstSha256 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstSignatureSha256 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstInstallerType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstScope = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstLanguage = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstSystemAppId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstSwitchesSilent = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstSwitchesSilentWithProgress = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstSwitchesCustom = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstSwitchesInstallLocation = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstSwitchesLanguage = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstSwitchesLog = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSwitchesInteractive = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colFilePath = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colVersion = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPublisher = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAppMoniker = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAuthor = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLicense = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLicenseUrl = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemButtonEditUrl = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.colMinOSVersion = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHomepage = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTags = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFileExtensions = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colProtocols = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCommands = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstallerType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstallersCount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstallersArch = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstallersLanguage = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstallersInstallerType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colManifestSwitchInteractive = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colManifestSwitchSilent = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colManifestSwitchSilentWithProgress = new DevExpress.XtraGrid.Columns.GridColumn();
			this.textEditRepoFolder = new DevExpress.XtraEditors.TextEdit();
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.simpleButtonCreateSubFoldersForSelected = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonCheckForNewDownloads = new DevExpress.XtraEditors.SimpleButton();
			this.textEditInstallersFolder = new DevExpress.XtraEditors.TextEdit();
			this.simpleButtonOpenGitRepo = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonSearch = new DevExpress.XtraEditors.SimpleButton();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItemRepoFolder = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditUrl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditRepoFolder.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEditInstallersFolder.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItemRepoFolder)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
			this.SuspendLayout();
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInstArch,
            this.colInstUrl,
            this.colInstSha256,
            this.colInstSignatureSha256,
            this.colInstInstallerType,
            this.colInstScope,
            this.colInstLanguage,
            this.colInstSystemAppId,
            this.colInstSwitchesSilent,
            this.colInstSwitchesSilentWithProgress,
            this.colInstSwitchesCustom,
            this.colInstSwitchesInstallLocation,
            this.colInstSwitchesLanguage,
            this.colInstSwitchesLog,
            this.colSwitchesInteractive});
			this.gridView2.GridControl = this.gridControl1;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// colInstArch
			// 
			this.colInstArch.FieldName = "Arch";
			this.colInstArch.Name = "colInstArch";
			this.colInstArch.Visible = true;
			this.colInstArch.VisibleIndex = 0;
			// 
			// colInstUrl
			// 
			this.colInstUrl.FieldName = "Url";
			this.colInstUrl.Name = "colInstUrl";
			this.colInstUrl.Visible = true;
			this.colInstUrl.VisibleIndex = 3;
			// 
			// colInstSha256
			// 
			this.colInstSha256.FieldName = "Sha256";
			this.colInstSha256.Name = "colInstSha256";
			this.colInstSha256.Visible = true;
			this.colInstSha256.VisibleIndex = 1;
			// 
			// colInstSignatureSha256
			// 
			this.colInstSignatureSha256.FieldName = "SignatureSha256";
			this.colInstSignatureSha256.Name = "colInstSignatureSha256";
			this.colInstSignatureSha256.Visible = true;
			this.colInstSignatureSha256.VisibleIndex = 2;
			// 
			// colInstInstallerType
			// 
			this.colInstInstallerType.FieldName = "InstallerType";
			this.colInstInstallerType.Name = "colInstInstallerType";
			this.colInstInstallerType.Visible = true;
			this.colInstInstallerType.VisibleIndex = 4;
			// 
			// colInstScope
			// 
			this.colInstScope.FieldName = "Scope";
			this.colInstScope.Name = "colInstScope";
			this.colInstScope.Visible = true;
			this.colInstScope.VisibleIndex = 5;
			// 
			// colInstLanguage
			// 
			this.colInstLanguage.FieldName = "Language";
			this.colInstLanguage.Name = "colInstLanguage";
			this.colInstLanguage.Visible = true;
			this.colInstLanguage.VisibleIndex = 6;
			// 
			// colInstSystemAppId
			// 
			this.colInstSystemAppId.FieldName = "SystemAppId";
			this.colInstSystemAppId.Name = "colInstSystemAppId";
			this.colInstSystemAppId.Visible = true;
			this.colInstSystemAppId.VisibleIndex = 7;
			// 
			// colInstSwitchesSilent
			// 
			this.colInstSwitchesSilent.FieldName = "SwitchesSilent";
			this.colInstSwitchesSilent.Name = "colInstSwitchesSilent";
			this.colInstSwitchesSilent.Visible = true;
			this.colInstSwitchesSilent.VisibleIndex = 8;
			// 
			// colInstSwitchesSilentWithProgress
			// 
			this.colInstSwitchesSilentWithProgress.FieldName = "SwitchesSilentWithProgress";
			this.colInstSwitchesSilentWithProgress.Name = "colInstSwitchesSilentWithProgress";
			this.colInstSwitchesSilentWithProgress.Visible = true;
			this.colInstSwitchesSilentWithProgress.VisibleIndex = 9;
			// 
			// colInstSwitchesCustom
			// 
			this.colInstSwitchesCustom.FieldName = "SwitchesCustom";
			this.colInstSwitchesCustom.Name = "colInstSwitchesCustom";
			this.colInstSwitchesCustom.Visible = true;
			this.colInstSwitchesCustom.VisibleIndex = 10;
			// 
			// colInstSwitchesInstallLocation
			// 
			this.colInstSwitchesInstallLocation.FieldName = "SwitchesInstallLocation";
			this.colInstSwitchesInstallLocation.Name = "colInstSwitchesInstallLocation";
			this.colInstSwitchesInstallLocation.Visible = true;
			this.colInstSwitchesInstallLocation.VisibleIndex = 11;
			// 
			// colInstSwitchesLanguage
			// 
			this.colInstSwitchesLanguage.FieldName = "SwitchesLanguage";
			this.colInstSwitchesLanguage.Name = "colInstSwitchesLanguage";
			this.colInstSwitchesLanguage.Visible = true;
			this.colInstSwitchesLanguage.VisibleIndex = 12;
			// 
			// colInstSwitchesLog
			// 
			this.colInstSwitchesLog.FieldName = "SwitchesLog";
			this.colInstSwitchesLog.Name = "colInstSwitchesLog";
			this.colInstSwitchesLog.Visible = true;
			this.colInstSwitchesLog.VisibleIndex = 13;
			// 
			// colSwitchesInteractive
			// 
			this.colSwitchesInteractive.FieldName = "SwitchesInteractive";
			this.colSwitchesInteractive.Name = "colSwitchesInteractive";
			this.colSwitchesInteractive.Visible = true;
			this.colSwitchesInteractive.VisibleIndex = 14;
			// 
			// gridControl1
			// 
			gridLevelNode1.LevelTemplate = this.gridView2;
			gridLevelNode1.RelationName = "Installers";
			this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
			this.gridControl1.Location = new System.Drawing.Point(5, 57);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEditUrl});
			this.gridControl1.Size = new System.Drawing.Size(1002, 577);
			this.gridControl1.TabIndex = 4;
			this.gridControl1.UseEmbeddedNavigator = true;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFilePath,
            this.colId,
            this.colName,
            this.colVersion,
            this.colPublisher,
            this.colAppMoniker,
            this.colAuthor,
            this.colLicense,
            this.colLicenseUrl,
            this.colMinOSVersion,
            this.colHomepage,
            this.colDescription,
            this.colTags,
            this.colFileExtensions,
            this.colProtocols,
            this.colCommands,
            this.colInstallerType,
            this.colInstallersCount,
            this.colInstallersArch,
            this.colInstallersLanguage,
            this.colInstallersInstallerType,
            this.colManifestSwitchInteractive,
            this.colManifestSwitchSilent,
            this.colManifestSwitchSilentWithProgress});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Version", null, "(Version: Count={0})")});
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Classic;
			this.gridView1.OptionsDetail.ShowDetailTabs = false;
			this.gridView1.OptionsSelection.MultiSelect = true;
			this.gridView1.OptionsView.ColumnAutoWidth = false;
			this.gridView1.OptionsView.ShowAutoFilterRow = true;
			this.gridView1.OptionsView.ShowFooter = true;
			this.gridView1.CustomDrawFooter += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView1_CustomDrawFooter);
			this.gridView1.MasterRowGetChildList += new DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventHandler(this.gridView1_MasterRowGetChildList);
			this.gridView1.MasterRowGetRelationName += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventHandler(this.gridView1_MasterRowGetRelationName);
			this.gridView1.MasterRowGetRelationCount += new DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventHandler(this.gridView1_MasterRowGetRelationCount);
			// 
			// colFilePath
			// 
			this.colFilePath.FieldName = "FilePath";
			this.colFilePath.Name = "colFilePath";
			this.colFilePath.OptionsColumn.ReadOnly = true;
			this.colFilePath.Visible = true;
			this.colFilePath.VisibleIndex = 0;
			// 
			// colId
			// 
			this.colId.FieldName = "Id";
			this.colId.Name = "colId";
			this.colId.OptionsColumn.ReadOnly = true;
			this.colId.Visible = true;
			this.colId.VisibleIndex = 1;
			// 
			// colName
			// 
			this.colName.FieldName = "Name";
			this.colName.Name = "colName";
			this.colName.OptionsColumn.ReadOnly = true;
			this.colName.Visible = true;
			this.colName.VisibleIndex = 2;
			// 
			// colVersion
			// 
			this.colVersion.FieldName = "Version";
			this.colVersion.Name = "colVersion";
			this.colVersion.OptionsColumn.ReadOnly = true;
			this.colVersion.Visible = true;
			this.colVersion.VisibleIndex = 3;
			// 
			// colPublisher
			// 
			this.colPublisher.FieldName = "Publisher";
			this.colPublisher.Name = "colPublisher";
			this.colPublisher.OptionsColumn.ReadOnly = true;
			this.colPublisher.Visible = true;
			this.colPublisher.VisibleIndex = 4;
			// 
			// colAppMoniker
			// 
			this.colAppMoniker.FieldName = "AppMoniker";
			this.colAppMoniker.Name = "colAppMoniker";
			this.colAppMoniker.OptionsColumn.ReadOnly = true;
			this.colAppMoniker.Visible = true;
			this.colAppMoniker.VisibleIndex = 5;
			// 
			// colAuthor
			// 
			this.colAuthor.FieldName = "Author";
			this.colAuthor.Name = "colAuthor";
			this.colAuthor.OptionsColumn.ReadOnly = true;
			this.colAuthor.Visible = true;
			this.colAuthor.VisibleIndex = 6;
			// 
			// colLicense
			// 
			this.colLicense.FieldName = "License";
			this.colLicense.Name = "colLicense";
			this.colLicense.OptionsColumn.ReadOnly = true;
			this.colLicense.Visible = true;
			this.colLicense.VisibleIndex = 7;
			// 
			// colLicenseUrl
			// 
			this.colLicenseUrl.ColumnEdit = this.repositoryItemButtonEditUrl;
			this.colLicenseUrl.FieldName = "LicenseUrl";
			this.colLicenseUrl.Name = "colLicenseUrl";
			this.colLicenseUrl.OptionsColumn.ReadOnly = true;
			this.colLicenseUrl.Visible = true;
			this.colLicenseUrl.VisibleIndex = 8;
			// 
			// repositoryItemButtonEditUrl
			// 
			this.repositoryItemButtonEditUrl.AutoHeight = false;
			this.repositoryItemButtonEditUrl.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
			this.repositoryItemButtonEditUrl.Name = "repositoryItemButtonEditUrl";
			this.repositoryItemButtonEditUrl.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEditUrl_ButtonClick);
			// 
			// colMinOSVersion
			// 
			this.colMinOSVersion.FieldName = "MinOSVersion";
			this.colMinOSVersion.Name = "colMinOSVersion";
			this.colMinOSVersion.OptionsColumn.ReadOnly = true;
			this.colMinOSVersion.Visible = true;
			this.colMinOSVersion.VisibleIndex = 9;
			// 
			// colHomepage
			// 
			this.colHomepage.ColumnEdit = this.repositoryItemButtonEditUrl;
			this.colHomepage.FieldName = "Homepage";
			this.colHomepage.Name = "colHomepage";
			this.colHomepage.OptionsColumn.ReadOnly = true;
			this.colHomepage.Visible = true;
			this.colHomepage.VisibleIndex = 10;
			// 
			// colDescription
			// 
			this.colDescription.FieldName = "Description";
			this.colDescription.Name = "colDescription";
			this.colDescription.OptionsColumn.ReadOnly = true;
			this.colDescription.Visible = true;
			this.colDescription.VisibleIndex = 11;
			// 
			// colTags
			// 
			this.colTags.FieldName = "Tags";
			this.colTags.Name = "colTags";
			this.colTags.OptionsColumn.ReadOnly = true;
			this.colTags.Visible = true;
			this.colTags.VisibleIndex = 12;
			// 
			// colFileExtensions
			// 
			this.colFileExtensions.FieldName = "FileExtensions";
			this.colFileExtensions.Name = "colFileExtensions";
			this.colFileExtensions.OptionsColumn.ReadOnly = true;
			this.colFileExtensions.Visible = true;
			this.colFileExtensions.VisibleIndex = 13;
			// 
			// colProtocols
			// 
			this.colProtocols.FieldName = "Protocols";
			this.colProtocols.Name = "colProtocols";
			this.colProtocols.OptionsColumn.ReadOnly = true;
			this.colProtocols.Visible = true;
			this.colProtocols.VisibleIndex = 14;
			// 
			// colCommands
			// 
			this.colCommands.FieldName = "Commands";
			this.colCommands.Name = "colCommands";
			this.colCommands.OptionsColumn.ReadOnly = true;
			this.colCommands.Visible = true;
			this.colCommands.VisibleIndex = 15;
			// 
			// colInstallerType
			// 
			this.colInstallerType.FieldName = "InstallerType";
			this.colInstallerType.Name = "colInstallerType";
			this.colInstallerType.OptionsColumn.ReadOnly = true;
			this.colInstallerType.Visible = true;
			this.colInstallerType.VisibleIndex = 16;
			// 
			// colInstallersCount
			// 
			this.colInstallersCount.FieldName = "InstallersCount";
			this.colInstallersCount.Name = "colInstallersCount";
			this.colInstallersCount.OptionsColumn.ReadOnly = true;
			this.colInstallersCount.Visible = true;
			this.colInstallersCount.VisibleIndex = 17;
			// 
			// colInstallersArch
			// 
			this.colInstallersArch.FieldName = "InstallersArch";
			this.colInstallersArch.Name = "colInstallersArch";
			this.colInstallersArch.Visible = true;
			this.colInstallersArch.VisibleIndex = 19;
			// 
			// colInstallersLanguage
			// 
			this.colInstallersLanguage.FieldName = "InstallersLanguage";
			this.colInstallersLanguage.Name = "colInstallersLanguage";
			this.colInstallersLanguage.Visible = true;
			this.colInstallersLanguage.VisibleIndex = 20;
			// 
			// colInstallersInstallerType
			// 
			this.colInstallersInstallerType.FieldName = "InstallersInstallerType";
			this.colInstallersInstallerType.Name = "colInstallersInstallerType";
			this.colInstallersInstallerType.Visible = true;
			this.colInstallersInstallerType.VisibleIndex = 18;
			// 
			// colManifestSwitchInteractive
			// 
			this.colManifestSwitchInteractive.FieldName = "ManifestSwitchInteractive";
			this.colManifestSwitchInteractive.Name = "colManifestSwitchInteractive";
			this.colManifestSwitchInteractive.Visible = true;
			this.colManifestSwitchInteractive.VisibleIndex = 21;
			// 
			// colManifestSwitchSilent
			// 
			this.colManifestSwitchSilent.FieldName = "ManifestSwitchSilentWithProgress";
			this.colManifestSwitchSilent.Name = "colManifestSwitchSilent";
			this.colManifestSwitchSilent.Visible = true;
			this.colManifestSwitchSilent.VisibleIndex = 22;
			// 
			// colManifestSwitchSilentWithProgress
			// 
			this.colManifestSwitchSilentWithProgress.FieldName = "ManifestSwitchSilentWithProgress";
			this.colManifestSwitchSilentWithProgress.Name = "colManifestSwitchSilentWithProgress";
			this.colManifestSwitchSilentWithProgress.Visible = true;
			this.colManifestSwitchSilentWithProgress.VisibleIndex = 23;
			// 
			// textEditRepoFolder
			// 
			this.textEditRepoFolder.Location = new System.Drawing.Point(91, 5);
			this.textEditRepoFolder.Name = "textEditRepoFolder";
			this.textEditRepoFolder.Size = new System.Drawing.Size(614, 20);
			this.textEditRepoFolder.StyleController = this.layoutControl1;
			this.textEditRepoFolder.TabIndex = 5;
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.simpleButtonCreateSubFoldersForSelected);
			this.layoutControl1.Controls.Add(this.simpleButtonCheckForNewDownloads);
			this.layoutControl1.Controls.Add(this.textEditInstallersFolder);
			this.layoutControl1.Controls.Add(this.simpleButtonOpenGitRepo);
			this.layoutControl1.Controls.Add(this.simpleButtonSearch);
			this.layoutControl1.Controls.Add(this.textEditRepoFolder);
			this.layoutControl1.Controls.Add(this.gridControl1);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(1012, 639);
			this.layoutControl1.TabIndex = 6;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// simpleButtonCreateSubFoldersForSelected
			// 
			this.simpleButtonCreateSubFoldersForSelected.Enabled = false;
			this.simpleButtonCreateSubFoldersForSelected.Location = new System.Drawing.Point(849, 31);
			this.simpleButtonCreateSubFoldersForSelected.Name = "simpleButtonCreateSubFoldersForSelected";
			this.simpleButtonCreateSubFoldersForSelected.Size = new System.Drawing.Size(158, 22);
			this.simpleButtonCreateSubFoldersForSelected.StyleController = this.layoutControl1;
			this.simpleButtonCreateSubFoldersForSelected.TabIndex = 10;
			this.simpleButtonCreateSubFoldersForSelected.Text = "CreateSubFolders For Selected";
			this.simpleButtonCreateSubFoldersForSelected.Click += new System.EventHandler(this.simpleButtonCreateSubFoldersForSelected_Click);
			// 
			// simpleButtonCheckForNewDownloads
			// 
			this.simpleButtonCheckForNewDownloads.Enabled = false;
			this.simpleButtonCheckForNewDownloads.Location = new System.Drawing.Point(709, 31);
			this.simpleButtonCheckForNewDownloads.Name = "simpleButtonCheckForNewDownloads";
			this.simpleButtonCheckForNewDownloads.Size = new System.Drawing.Size(136, 22);
			this.simpleButtonCheckForNewDownloads.StyleController = this.layoutControl1;
			this.simpleButtonCheckForNewDownloads.TabIndex = 9;
			this.simpleButtonCheckForNewDownloads.Text = "Check For New Downloads";
			this.simpleButtonCheckForNewDownloads.Click += new System.EventHandler(this.simpleButtonCheckForNewDownloads_Click);
			// 
			// textEditInstallersFolder
			// 
			this.textEditInstallersFolder.Location = new System.Drawing.Point(91, 31);
			this.textEditInstallersFolder.Name = "textEditInstallersFolder";
			this.textEditInstallersFolder.Size = new System.Drawing.Size(614, 20);
			this.textEditInstallersFolder.StyleController = this.layoutControl1;
			this.textEditInstallersFolder.TabIndex = 8;
			// 
			// simpleButtonOpenGitRepo
			// 
			this.simpleButtonOpenGitRepo.Location = new System.Drawing.Point(849, 5);
			this.simpleButtonOpenGitRepo.Name = "simpleButtonOpenGitRepo";
			this.simpleButtonOpenGitRepo.Size = new System.Drawing.Size(158, 22);
			this.simpleButtonOpenGitRepo.StyleController = this.layoutControl1;
			this.simpleButtonOpenGitRepo.TabIndex = 7;
			this.simpleButtonOpenGitRepo.Text = "Open GitRepo";
			this.simpleButtonOpenGitRepo.Click += new System.EventHandler(this.simpleButtonOpenGitRepo_Click);
			// 
			// simpleButtonSearch
			// 
			this.simpleButtonSearch.Location = new System.Drawing.Point(709, 5);
			this.simpleButtonSearch.Name = "simpleButtonSearch";
			this.simpleButtonSearch.Size = new System.Drawing.Size(136, 22);
			this.simpleButtonSearch.StyleController = this.layoutControl1;
			this.simpleButtonSearch.TabIndex = 6;
			this.simpleButtonSearch.Text = "Search";
			this.simpleButtonSearch.Click += new System.EventHandler(this.simpleButtonSearch_Click);
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItemRepoFolder,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
			this.Root.Name = "Root";
			this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
			this.Root.Size = new System.Drawing.Size(1012, 639);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.gridControl1;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 52);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(1006, 581);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// layoutControlItemRepoFolder
			// 
			this.layoutControlItemRepoFolder.Control = this.textEditRepoFolder;
			this.layoutControlItemRepoFolder.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItemRepoFolder.Name = "layoutControlItemRepoFolder";
			this.layoutControlItemRepoFolder.Size = new System.Drawing.Size(704, 26);
			this.layoutControlItemRepoFolder.Text = "Repo-Folder:";
			this.layoutControlItemRepoFolder.TextSize = new System.Drawing.Size(82, 13);
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.simpleButtonSearch;
			this.layoutControlItem2.Location = new System.Drawing.Point(704, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(140, 26);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.simpleButtonOpenGitRepo;
			this.layoutControlItem3.Location = new System.Drawing.Point(844, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(162, 26);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.textEditInstallersFolder;
			this.layoutControlItem4.Location = new System.Drawing.Point(0, 26);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(704, 26);
			this.layoutControlItem4.Text = "Installers-Folder:";
			this.layoutControlItem4.TextSize = new System.Drawing.Size(82, 13);
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.simpleButtonCheckForNewDownloads;
			this.layoutControlItem5.Location = new System.Drawing.Point(704, 26);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(140, 26);
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.simpleButtonCreateSubFoldersForSelected;
			this.layoutControlItem6.Location = new System.Drawing.Point(844, 26);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(162, 26);
			this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem6.TextVisible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 639);
			this.Controls.Add(this.layoutControl1);
			this.Name = "MainForm";
			this.Text = "WingetRepo Browser 0.0.5";
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditUrl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditRepoFolder.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.textEditInstallersFolder.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItemRepoFolder)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn colFilePath;
		private DevExpress.XtraGrid.Columns.GridColumn colInstallersCount;
		private DevExpress.XtraGrid.Columns.GridColumn colId;
		private DevExpress.XtraGrid.Columns.GridColumn colName;
		private DevExpress.XtraGrid.Columns.GridColumn colVersion;
		private DevExpress.XtraGrid.Columns.GridColumn colPublisher;
		private DevExpress.XtraGrid.Columns.GridColumn colAppMoniker;
		private DevExpress.XtraGrid.Columns.GridColumn colAuthor;
		private DevExpress.XtraGrid.Columns.GridColumn colLicense;
		private DevExpress.XtraGrid.Columns.GridColumn colLicenseUrl;
		private DevExpress.XtraGrid.Columns.GridColumn colMinOSVersion;
		private DevExpress.XtraGrid.Columns.GridColumn colHomepage;
		private DevExpress.XtraGrid.Columns.GridColumn colDescription;
		private DevExpress.XtraGrid.Columns.GridColumn colTags;
		private DevExpress.XtraGrid.Columns.GridColumn colInstallerType;
		private DevExpress.XtraGrid.Columns.GridColumn colFileExtensions;
		private DevExpress.XtraGrid.Columns.GridColumn colProtocols;
		private DevExpress.XtraGrid.Columns.GridColumn colCommands;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
		private DevExpress.XtraGrid.Columns.GridColumn colInstArch;
		private DevExpress.XtraGrid.Columns.GridColumn colInstUrl;
		private DevExpress.XtraGrid.Columns.GridColumn colInstSha256;
		private DevExpress.XtraGrid.Columns.GridColumn colInstSignatureSha256;
		private DevExpress.XtraGrid.Columns.GridColumn colInstInstallerType;
		private DevExpress.XtraGrid.Columns.GridColumn colInstScope;
		private DevExpress.XtraGrid.Columns.GridColumn colInstLanguage;
		private DevExpress.XtraGrid.Columns.GridColumn colInstSystemAppId;
		private DevExpress.XtraGrid.Columns.GridColumn colInstSwitchesSilent;
		private DevExpress.XtraGrid.Columns.GridColumn colInstSwitchesSilentWithProgress;
		private DevExpress.XtraGrid.Columns.GridColumn colInstSwitchesCustom;
		private DevExpress.XtraGrid.Columns.GridColumn colInstSwitchesInstallLocation;
		private DevExpress.XtraGrid.Columns.GridColumn colInstSwitchesLanguage;
		private DevExpress.XtraGrid.Columns.GridColumn colInstSwitchesLog;
		private DevExpress.XtraEditors.TextEdit textEditRepoFolder;
		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraEditors.SimpleButton simpleButtonSearch;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItemRepoFolder;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditUrl;
		private DevExpress.XtraEditors.SimpleButton simpleButtonOpenGitRepo;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraEditors.TextEdit textEditInstallersFolder;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCheckForNewDownloads;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCreateSubFoldersForSelected;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
		private DevExpress.XtraGrid.Columns.GridColumn colInstallersArch;
		private DevExpress.XtraGrid.Columns.GridColumn colInstallersLanguage;
		private DevExpress.XtraGrid.Columns.GridColumn colInstallersInstallerType;
		private DevExpress.XtraGrid.Columns.GridColumn colSwitchesInteractive;
		private DevExpress.XtraGrid.Columns.GridColumn colManifestSwitchInteractive;
		private DevExpress.XtraGrid.Columns.GridColumn colManifestSwitchSilent;
		private DevExpress.XtraGrid.Columns.GridColumn colManifestSwitchSilentWithProgress;
	}
}

