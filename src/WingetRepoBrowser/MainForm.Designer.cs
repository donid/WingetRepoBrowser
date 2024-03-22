namespace WingetRepoBrowser
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
			this.components = new System.ComponentModel.Container();
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colInstArch = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstUrl = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstSha256 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstSignatureSha256 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstInstallerType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstallModes = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstScope = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridReleaseDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstLanguage = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstUpgradeBehavior = new DevExpress.XtraGrid.Columns.GridColumn();
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
			this.colManifestType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colVersion = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colParsedVersion = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colReleaseDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDefaultLocale = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPackageLocale = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPublisher = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMoniker = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAuthor = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLicense = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLicenseUrl = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemButtonEditUrl = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.colPublisherSupportUrl = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPublisherUrl = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPrivacyUrl = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMinOSVersion = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPackageUrl = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colShortDescription = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTags = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFileExtensions = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colProtocols = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCommands = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstallerType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMainInstallModes = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstallersCount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstallersArch = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstallersLocale = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colInstallersInstallerType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colManifestSwitchInteractive = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colManifestSwitchSilent = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colManifestSwitchSilentWithProgress = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPlatforms = new DevExpress.XtraGrid.Columns.GridColumn();
			this.textEditRepoFolder = new DevExpress.XtraEditors.TextEdit();
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.memoEditMessages = new DevExpress.XtraEditors.MemoEdit();
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
			this.layoutControlItemMessages = new DevExpress.XtraLayout.LayoutControlItem();
			this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
			this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.bar2 = new DevExpress.XtraBars.Bar();
			this.bar3 = new DevExpress.XtraBars.Bar();
			this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
			this.barEditItemMarquee = new DevExpress.XtraBars.BarEditItem();
			this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
			this.barEditItemProgress = new DevExpress.XtraBars.BarEditItem();
			this.repositoryItemProgressBar2 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
			this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.colExpectedReturnCodes = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditUrl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditRepoFolder.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.memoEditMessages.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditInstallersFolder.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItemRepoFolder)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItemMessages)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
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
            this.colInstallModes,
            this.colInstScope,
            this.gridReleaseDate,
            this.colInstLanguage,
            this.colInstProductCode,
            this.colInstUpgradeBehavior,
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
			this.colInstInstallerType.VisibleIndex = 5;
			// 
			// colInstallModes
			// 
			this.colInstallModes.FieldName = "InstallModes";
			this.colInstallModes.Name = "colInstallModes";
			this.colInstallModes.Visible = true;
			this.colInstallModes.VisibleIndex = 4;
			// 
			// colInstScope
			// 
			this.colInstScope.FieldName = "Scope";
			this.colInstScope.Name = "colInstScope";
			this.colInstScope.Visible = true;
			this.colInstScope.VisibleIndex = 7;
			// 
			// gridReleaseDate
			// 
			this.gridReleaseDate.FieldName = "ReleaseDate";
			this.gridReleaseDate.Name = "gridReleaseDate";
			this.gridReleaseDate.Visible = true;
			this.gridReleaseDate.VisibleIndex = 6;
			// 
			// colInstLanguage
			// 
			this.colInstLanguage.Caption = "InstallerLocale";
			this.colInstLanguage.FieldName = "InstallerLocale";
			this.colInstLanguage.Name = "colInstLanguage";
			this.colInstLanguage.Visible = true;
			this.colInstLanguage.VisibleIndex = 8;
			// 
			// colInstProductCode
			// 
			this.colInstProductCode.Caption = "ProductCode";
			this.colInstProductCode.FieldName = "ProductCode";
			this.colInstProductCode.Name = "colInstProductCode";
			this.colInstProductCode.Visible = true;
			this.colInstProductCode.VisibleIndex = 9;
			// 
			// colInstUpgradeBehavior
			// 
			this.colInstUpgradeBehavior.Caption = "UpgradeBehavior";
			this.colInstUpgradeBehavior.FieldName = "UpgradeBehavior";
			this.colInstUpgradeBehavior.Name = "colInstUpgradeBehavior";
			this.colInstUpgradeBehavior.Visible = true;
			this.colInstUpgradeBehavior.VisibleIndex = 10;
			// 
			// colInstSwitchesSilent
			// 
			this.colInstSwitchesSilent.FieldName = "SwitchesSilent";
			this.colInstSwitchesSilent.Name = "colInstSwitchesSilent";
			this.colInstSwitchesSilent.Visible = true;
			this.colInstSwitchesSilent.VisibleIndex = 11;
			// 
			// colInstSwitchesSilentWithProgress
			// 
			this.colInstSwitchesSilentWithProgress.FieldName = "SwitchesSilentWithProgress";
			this.colInstSwitchesSilentWithProgress.Name = "colInstSwitchesSilentWithProgress";
			this.colInstSwitchesSilentWithProgress.Visible = true;
			this.colInstSwitchesSilentWithProgress.VisibleIndex = 12;
			// 
			// colInstSwitchesCustom
			// 
			this.colInstSwitchesCustom.FieldName = "SwitchesCustom";
			this.colInstSwitchesCustom.Name = "colInstSwitchesCustom";
			this.colInstSwitchesCustom.Visible = true;
			this.colInstSwitchesCustom.VisibleIndex = 13;
			// 
			// colInstSwitchesInstallLocation
			// 
			this.colInstSwitchesInstallLocation.FieldName = "SwitchesInstallLocation";
			this.colInstSwitchesInstallLocation.Name = "colInstSwitchesInstallLocation";
			this.colInstSwitchesInstallLocation.Visible = true;
			this.colInstSwitchesInstallLocation.VisibleIndex = 14;
			// 
			// colInstSwitchesLanguage
			// 
			this.colInstSwitchesLanguage.FieldName = "SwitchesLanguage";
			this.colInstSwitchesLanguage.Name = "colInstSwitchesLanguage";
			this.colInstSwitchesLanguage.Visible = true;
			this.colInstSwitchesLanguage.VisibleIndex = 15;
			// 
			// colInstSwitchesLog
			// 
			this.colInstSwitchesLog.FieldName = "SwitchesLog";
			this.colInstSwitchesLog.Name = "colInstSwitchesLog";
			this.colInstSwitchesLog.Visible = true;
			this.colInstSwitchesLog.VisibleIndex = 16;
			// 
			// colSwitchesInteractive
			// 
			this.colSwitchesInteractive.FieldName = "SwitchesInteractive";
			this.colSwitchesInteractive.Name = "colSwitchesInteractive";
			this.colSwitchesInteractive.Visible = true;
			this.colSwitchesInteractive.VisibleIndex = 17;
			// 
			// gridControl1
			// 
			gridLevelNode1.LevelTemplate = this.gridView2;
			gridLevelNode1.RelationName = "Installers";
			this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
			this.gridControl1.Location = new System.Drawing.Point(5, 139);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEditUrl});
			this.gridControl1.Size = new System.Drawing.Size(1002, 419);
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
            this.colManifestType,
            this.colId,
            this.colName,
            this.colVersion,
            this.colParsedVersion,
            this.colReleaseDate,
            this.colDefaultLocale,
            this.colPackageLocale,
            this.colPublisher,
            this.colMoniker,
            this.colAuthor,
            this.colLicense,
            this.colLicenseUrl,
            this.colPublisherSupportUrl,
            this.colPublisherUrl,
            this.colPrivacyUrl,
            this.colMinOSVersion,
            this.colPackageUrl,
            this.colShortDescription,
            this.colDescription,
            this.colTags,
            this.colFileExtensions,
            this.colProtocols,
            this.colCommands,
            this.colInstallerType,
            this.colMainInstallModes,
            this.colInstallersCount,
            this.colInstallersArch,
            this.colInstallersLocale,
            this.colInstallersInstallerType,
            this.colManifestSwitchInteractive,
            this.colManifestSwitchSilent,
            this.colManifestSwitchSilentWithProgress,
            this.colPlatforms,
            this.colExpectedReturnCodes});
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
			// colManifestType
			// 
			this.colManifestType.Caption = "ManifestType";
			this.colManifestType.FieldName = "ManifestType";
			this.colManifestType.Name = "colManifestType";
			this.colManifestType.Visible = true;
			this.colManifestType.VisibleIndex = 1;
			// 
			// colId
			// 
			this.colId.FieldName = "Id";
			this.colId.Name = "colId";
			this.colId.OptionsColumn.ReadOnly = true;
			this.colId.Visible = true;
			this.colId.VisibleIndex = 2;
			// 
			// colName
			// 
			this.colName.FieldName = "Name";
			this.colName.Name = "colName";
			this.colName.OptionsColumn.ReadOnly = true;
			this.colName.Visible = true;
			this.colName.VisibleIndex = 3;
			// 
			// colVersion
			// 
			this.colVersion.FieldName = "Version";
			this.colVersion.Name = "colVersion";
			this.colVersion.OptionsColumn.ReadOnly = true;
			this.colVersion.Visible = true;
			this.colVersion.VisibleIndex = 4;
			// 
			// colParsedVersion
			// 
			this.colParsedVersion.Caption = "ParsedVersion";
			this.colParsedVersion.FieldName = "ParsedPackageVersion";
			this.colParsedVersion.Name = "colParsedVersion";
			this.colParsedVersion.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colParsedVersion.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
			this.colParsedVersion.Visible = true;
			this.colParsedVersion.VisibleIndex = 5;
			// 
			// colReleaseDate
			// 
			this.colReleaseDate.FieldName = "ReleaseDate";
			this.colReleaseDate.Name = "colReleaseDate";
			this.colReleaseDate.ToolTip = "If the release date is specified per installer, the maximum date is shown";
			this.colReleaseDate.Visible = true;
			this.colReleaseDate.VisibleIndex = 6;
			// 
			// colDefaultLocale
			// 
			this.colDefaultLocale.Caption = "DefaultLocale";
			this.colDefaultLocale.FieldName = "DefaultLocale";
			this.colDefaultLocale.Name = "colDefaultLocale";
			this.colDefaultLocale.Visible = true;
			this.colDefaultLocale.VisibleIndex = 8;
			// 
			// colPackageLocale
			// 
			this.colPackageLocale.Caption = "PackageLocale";
			this.colPackageLocale.FieldName = "PackageLocale";
			this.colPackageLocale.Name = "colPackageLocale";
			this.colPackageLocale.Visible = true;
			this.colPackageLocale.VisibleIndex = 7;
			// 
			// colPublisher
			// 
			this.colPublisher.FieldName = "Publisher";
			this.colPublisher.Name = "colPublisher";
			this.colPublisher.OptionsColumn.ReadOnly = true;
			this.colPublisher.Visible = true;
			this.colPublisher.VisibleIndex = 15;
			// 
			// colMoniker
			// 
			this.colMoniker.FieldName = "Moniker";
			this.colMoniker.Name = "colMoniker";
			this.colMoniker.OptionsColumn.ReadOnly = true;
			this.colMoniker.Visible = true;
			this.colMoniker.VisibleIndex = 9;
			// 
			// colAuthor
			// 
			this.colAuthor.FieldName = "Author";
			this.colAuthor.Name = "colAuthor";
			this.colAuthor.OptionsColumn.ReadOnly = true;
			this.colAuthor.Visible = true;
			this.colAuthor.VisibleIndex = 14;
			// 
			// colLicense
			// 
			this.colLicense.FieldName = "License";
			this.colLicense.Name = "colLicense";
			this.colLicense.OptionsColumn.ReadOnly = true;
			this.colLicense.Visible = true;
			this.colLicense.VisibleIndex = 31;
			// 
			// colLicenseUrl
			// 
			this.colLicenseUrl.ColumnEdit = this.repositoryItemButtonEditUrl;
			this.colLicenseUrl.FieldName = "LicenseUrl";
			this.colLicenseUrl.Name = "colLicenseUrl";
			this.colLicenseUrl.OptionsColumn.ReadOnly = true;
			this.colLicenseUrl.Visible = true;
			this.colLicenseUrl.VisibleIndex = 32;
			// 
			// repositoryItemButtonEditUrl
			// 
			this.repositoryItemButtonEditUrl.AutoHeight = false;
			this.repositoryItemButtonEditUrl.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
			this.repositoryItemButtonEditUrl.Name = "repositoryItemButtonEditUrl";
			this.repositoryItemButtonEditUrl.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEditUrl_ButtonClick);
			// 
			// colPublisherSupportUrl
			// 
			this.colPublisherSupportUrl.Caption = "PublisherSupportUrl";
			this.colPublisherSupportUrl.FieldName = "PublisherSupportUrl";
			this.colPublisherSupportUrl.Name = "colPublisherSupportUrl";
			this.colPublisherSupportUrl.Visible = true;
			this.colPublisherSupportUrl.VisibleIndex = 17;
			// 
			// colPublisherUrl
			// 
			this.colPublisherUrl.Caption = "PublisherUrl";
			this.colPublisherUrl.FieldName = "PublisherUrl";
			this.colPublisherUrl.Name = "colPublisherUrl";
			this.colPublisherUrl.Visible = true;
			this.colPublisherUrl.VisibleIndex = 16;
			// 
			// colPrivacyUrl
			// 
			this.colPrivacyUrl.Caption = "PrivacyUrl";
			this.colPrivacyUrl.FieldName = "PrivacyUrl";
			this.colPrivacyUrl.Name = "colPrivacyUrl";
			this.colPrivacyUrl.Visible = true;
			this.colPrivacyUrl.VisibleIndex = 33;
			// 
			// colMinOSVersion
			// 
			this.colMinOSVersion.FieldName = "MinOSVersion";
			this.colMinOSVersion.Name = "colMinOSVersion";
			this.colMinOSVersion.OptionsColumn.ReadOnly = true;
			this.colMinOSVersion.Visible = true;
			this.colMinOSVersion.VisibleIndex = 18;
			// 
			// colPackageUrl
			// 
			this.colPackageUrl.ColumnEdit = this.repositoryItemButtonEditUrl;
			this.colPackageUrl.FieldName = "PackageUrl";
			this.colPackageUrl.Name = "colPackageUrl";
			this.colPackageUrl.OptionsColumn.ReadOnly = true;
			this.colPackageUrl.Visible = true;
			this.colPackageUrl.VisibleIndex = 10;
			// 
			// colShortDescription
			// 
			this.colShortDescription.Caption = "ShortDescription";
			this.colShortDescription.FieldName = "ShortDescription";
			this.colShortDescription.Name = "colShortDescription";
			this.colShortDescription.Visible = true;
			this.colShortDescription.VisibleIndex = 11;
			// 
			// colDescription
			// 
			this.colDescription.FieldName = "Description";
			this.colDescription.Name = "colDescription";
			this.colDescription.OptionsColumn.ReadOnly = true;
			this.colDescription.Visible = true;
			this.colDescription.VisibleIndex = 12;
			// 
			// colTags
			// 
			this.colTags.FieldName = "Tags";
			this.colTags.Name = "colTags";
			this.colTags.OptionsColumn.ReadOnly = true;
			this.colTags.Visible = true;
			this.colTags.VisibleIndex = 13;
			// 
			// colFileExtensions
			// 
			this.colFileExtensions.FieldName = "FileExtensions";
			this.colFileExtensions.Name = "colFileExtensions";
			this.colFileExtensions.OptionsColumn.ReadOnly = true;
			this.colFileExtensions.Visible = true;
			this.colFileExtensions.VisibleIndex = 19;
			// 
			// colProtocols
			// 
			this.colProtocols.FieldName = "Protocols";
			this.colProtocols.Name = "colProtocols";
			this.colProtocols.OptionsColumn.ReadOnly = true;
			this.colProtocols.Visible = true;
			this.colProtocols.VisibleIndex = 20;
			// 
			// colCommands
			// 
			this.colCommands.FieldName = "Commands";
			this.colCommands.Name = "colCommands";
			this.colCommands.OptionsColumn.ReadOnly = true;
			this.colCommands.Visible = true;
			this.colCommands.VisibleIndex = 21;
			// 
			// colInstallerType
			// 
			this.colInstallerType.FieldName = "InstallerType";
			this.colInstallerType.Name = "colInstallerType";
			this.colInstallerType.OptionsColumn.ReadOnly = true;
			this.colInstallerType.Visible = true;
			this.colInstallerType.VisibleIndex = 22;
			// 
			// colMainInstallModes
			// 
			this.colMainInstallModes.FieldName = "InstallModes";
			this.colMainInstallModes.Name = "colMainInstallModes";
			this.colMainInstallModes.OptionsColumn.ReadOnly = true;
			this.colMainInstallModes.Visible = true;
			this.colMainInstallModes.VisibleIndex = 26;
			// 
			// colInstallersCount
			// 
			this.colInstallersCount.FieldName = "InstallersCount";
			this.colInstallersCount.Name = "colInstallersCount";
			this.colInstallersCount.OptionsColumn.ReadOnly = true;
			this.colInstallersCount.Visible = true;
			this.colInstallersCount.VisibleIndex = 23;
			// 
			// colInstallersArch
			// 
			this.colInstallersArch.FieldName = "InstallersArch";
			this.colInstallersArch.Name = "colInstallersArch";
			this.colInstallersArch.Visible = true;
			this.colInstallersArch.VisibleIndex = 25;
			// 
			// colInstallersLocale
			// 
			this.colInstallersLocale.Caption = "InstallersLocale";
			this.colInstallersLocale.FieldName = "InstallersLocale";
			this.colInstallersLocale.Name = "colInstallersLocale";
			this.colInstallersLocale.Visible = true;
			this.colInstallersLocale.VisibleIndex = 27;
			// 
			// colInstallersInstallerType
			// 
			this.colInstallersInstallerType.FieldName = "InstallersInstallerType";
			this.colInstallersInstallerType.Name = "colInstallersInstallerType";
			this.colInstallersInstallerType.Visible = true;
			this.colInstallersInstallerType.VisibleIndex = 24;
			// 
			// colManifestSwitchInteractive
			// 
			this.colManifestSwitchInteractive.FieldName = "ManifestSwitchInteractive";
			this.colManifestSwitchInteractive.Name = "colManifestSwitchInteractive";
			this.colManifestSwitchInteractive.Visible = true;
			this.colManifestSwitchInteractive.VisibleIndex = 28;
			// 
			// colManifestSwitchSilent
			// 
			this.colManifestSwitchSilent.FieldName = "ManifestSwitchSilentWithProgress";
			this.colManifestSwitchSilent.Name = "colManifestSwitchSilent";
			this.colManifestSwitchSilent.Visible = true;
			this.colManifestSwitchSilent.VisibleIndex = 29;
			// 
			// colManifestSwitchSilentWithProgress
			// 
			this.colManifestSwitchSilentWithProgress.FieldName = "ManifestSwitchSilentWithProgress";
			this.colManifestSwitchSilentWithProgress.Name = "colManifestSwitchSilentWithProgress";
			this.colManifestSwitchSilentWithProgress.Visible = true;
			this.colManifestSwitchSilentWithProgress.VisibleIndex = 30;
			// 
			// colPlatforms
			// 
			this.colPlatforms.Caption = "Platforms";
			this.colPlatforms.FieldName = "Platforms";
			this.colPlatforms.Name = "colPlatforms";
			this.colPlatforms.Visible = true;
			this.colPlatforms.VisibleIndex = 34;
			// 
			// textEditRepoFolder
			// 
			this.textEditRepoFolder.Location = new System.Drawing.Point(91, 5);
			this.textEditRepoFolder.Name = "textEditRepoFolder";
			this.textEditRepoFolder.Size = new System.Drawing.Size(611, 20);
			this.textEditRepoFolder.StyleController = this.layoutControl1;
			this.textEditRepoFolder.TabIndex = 5;
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.memoEditMessages);
			this.layoutControl1.Controls.Add(this.simpleButtonCreateSubFoldersForSelected);
			this.layoutControl1.Controls.Add(this.simpleButtonCheckForNewDownloads);
			this.layoutControl1.Controls.Add(this.textEditInstallersFolder);
			this.layoutControl1.Controls.Add(this.simpleButtonOpenGitRepo);
			this.layoutControl1.Controls.Add(this.simpleButtonSearch);
			this.layoutControl1.Controls.Add(this.textEditRepoFolder);
			this.layoutControl1.Controls.Add(this.gridControl1);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 49);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(4790, 879, 650, 400);
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(1012, 563);
			this.layoutControl1.TabIndex = 6;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// memoEditMessages
			// 
			this.memoEditMessages.Location = new System.Drawing.Point(5, 73);
			this.memoEditMessages.Name = "memoEditMessages";
			this.memoEditMessages.Size = new System.Drawing.Size(1002, 57);
			this.memoEditMessages.StyleController = this.layoutControl1;
			this.memoEditMessages.TabIndex = 11;
			// 
			// simpleButtonCreateSubFoldersForSelected
			// 
			this.simpleButtonCreateSubFoldersForSelected.Enabled = false;
			this.simpleButtonCreateSubFoldersForSelected.Location = new System.Drawing.Point(847, 31);
			this.simpleButtonCreateSubFoldersForSelected.Name = "simpleButtonCreateSubFoldersForSelected";
			this.simpleButtonCreateSubFoldersForSelected.Size = new System.Drawing.Size(160, 22);
			this.simpleButtonCreateSubFoldersForSelected.StyleController = this.layoutControl1;
			this.simpleButtonCreateSubFoldersForSelected.TabIndex = 10;
			this.simpleButtonCreateSubFoldersForSelected.Text = "CreateSubFolders For Selected";
			this.simpleButtonCreateSubFoldersForSelected.Click += new System.EventHandler(this.simpleButtonCreateSubFoldersForSelected_Click);
			// 
			// simpleButtonCheckForNewDownloads
			// 
			this.simpleButtonCheckForNewDownloads.Enabled = false;
			this.simpleButtonCheckForNewDownloads.Location = new System.Drawing.Point(706, 31);
			this.simpleButtonCheckForNewDownloads.Name = "simpleButtonCheckForNewDownloads";
			this.simpleButtonCheckForNewDownloads.Size = new System.Drawing.Size(137, 22);
			this.simpleButtonCheckForNewDownloads.StyleController = this.layoutControl1;
			this.simpleButtonCheckForNewDownloads.TabIndex = 9;
			this.simpleButtonCheckForNewDownloads.Text = "Check For New Downloads";
			this.simpleButtonCheckForNewDownloads.Click += new System.EventHandler(this.simpleButtonCheckForNewDownloads_Click);
			// 
			// textEditInstallersFolder
			// 
			this.textEditInstallersFolder.Location = new System.Drawing.Point(91, 31);
			this.textEditInstallersFolder.Name = "textEditInstallersFolder";
			this.textEditInstallersFolder.Size = new System.Drawing.Size(611, 20);
			this.textEditInstallersFolder.StyleController = this.layoutControl1;
			this.textEditInstallersFolder.TabIndex = 8;
			// 
			// simpleButtonOpenGitRepo
			// 
			this.simpleButtonOpenGitRepo.Location = new System.Drawing.Point(847, 5);
			this.simpleButtonOpenGitRepo.Name = "simpleButtonOpenGitRepo";
			this.simpleButtonOpenGitRepo.Size = new System.Drawing.Size(160, 22);
			this.simpleButtonOpenGitRepo.StyleController = this.layoutControl1;
			this.simpleButtonOpenGitRepo.TabIndex = 7;
			this.simpleButtonOpenGitRepo.Text = "Open GitRepo";
			this.simpleButtonOpenGitRepo.Click += new System.EventHandler(this.simpleButtonOpenGitRepo_Click);
			// 
			// simpleButtonSearch
			// 
			this.simpleButtonSearch.Location = new System.Drawing.Point(706, 5);
			this.simpleButtonSearch.Name = "simpleButtonSearch";
			this.simpleButtonSearch.Size = new System.Drawing.Size(137, 22);
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
            this.layoutControlItem6,
            this.layoutControlItemMessages,
            this.splitterItem1});
			this.Root.Name = "Root";
			this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
			this.Root.Size = new System.Drawing.Size(1012, 563);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.gridControl1;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 134);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(1006, 423);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// layoutControlItemRepoFolder
			// 
			this.layoutControlItemRepoFolder.Control = this.textEditRepoFolder;
			this.layoutControlItemRepoFolder.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItemRepoFolder.Name = "layoutControlItemRepoFolder";
			this.layoutControlItemRepoFolder.Size = new System.Drawing.Size(701, 26);
			this.layoutControlItemRepoFolder.Text = "Repo-Folder:";
			this.layoutControlItemRepoFolder.TextSize = new System.Drawing.Size(82, 13);
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.simpleButtonSearch;
			this.layoutControlItem2.Location = new System.Drawing.Point(701, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(141, 26);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.simpleButtonOpenGitRepo;
			this.layoutControlItem3.Location = new System.Drawing.Point(842, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(164, 26);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.textEditInstallersFolder;
			this.layoutControlItem4.Location = new System.Drawing.Point(0, 26);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(701, 26);
			this.layoutControlItem4.Text = "Installers-Folder:";
			this.layoutControlItem4.TextSize = new System.Drawing.Size(82, 13);
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.simpleButtonCheckForNewDownloads;
			this.layoutControlItem5.Location = new System.Drawing.Point(701, 26);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(141, 26);
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.simpleButtonCreateSubFoldersForSelected;
			this.layoutControlItem6.Location = new System.Drawing.Point(842, 26);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(164, 26);
			this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem6.TextVisible = false;
			// 
			// layoutControlItemMessages
			// 
			this.layoutControlItemMessages.Control = this.memoEditMessages;
			this.layoutControlItemMessages.Location = new System.Drawing.Point(0, 52);
			this.layoutControlItemMessages.Name = "layoutControlItemMessages";
			this.layoutControlItemMessages.Size = new System.Drawing.Size(1006, 77);
			this.layoutControlItemMessages.Text = "Messages:";
			this.layoutControlItemMessages.TextLocation = DevExpress.Utils.Locations.Top;
			this.layoutControlItemMessages.TextSize = new System.Drawing.Size(82, 13);
			this.layoutControlItemMessages.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
			// 
			// splitterItem1
			// 
			this.splitterItem1.AllowHotTrack = true;
			this.splitterItem1.Location = new System.Drawing.Point(0, 129);
			this.splitterItem1.Name = "splitterItem1";
			this.splitterItem1.Size = new System.Drawing.Size(1006, 5);
			// 
			// barManager1
			// 
			this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this;
			this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barEditItemMarquee,
            this.barEditItemProgress,
            this.barStaticItem1});
			this.barManager1.MainMenu = this.bar2;
			this.barManager1.MaxItemId = 4;
			this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1,
            this.repositoryItemMarqueeProgressBar1,
            this.repositoryItemProgressBar2});
			this.barManager1.StatusBar = this.bar3;
			// 
			// bar1
			// 
			this.bar1.BarName = "Tools";
			this.bar1.DockCol = 0;
			this.bar1.DockRow = 1;
			this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar1.Text = "Tools";
			this.bar1.Visible = false;
			// 
			// bar2
			// 
			this.bar2.BarName = "Main menu";
			this.bar2.DockCol = 0;
			this.bar2.DockRow = 0;
			this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar2.OptionsBar.MultiLine = true;
			this.bar2.OptionsBar.UseWholeRow = true;
			this.bar2.Text = "Main menu";
			this.bar2.Visible = false;
			// 
			// bar3
			// 
			this.bar3.BarName = "Status bar";
			this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
			this.bar3.DockCol = 0;
			this.bar3.DockRow = 0;
			this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
			this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barEditItemMarquee, "", false, true, true, 188),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barEditItemProgress, "", false, true, true, 147)});
			this.bar3.OptionsBar.AllowQuickCustomization = false;
			this.bar3.OptionsBar.DrawDragBorder = false;
			this.bar3.OptionsBar.UseWholeRow = true;
			this.bar3.Text = "Status bar";
			// 
			// barStaticItem1
			// 
			this.barStaticItem1.Caption = "v0.2.7";
			this.barStaticItem1.Id = 3;
			this.barStaticItem1.Name = "barStaticItem1";
			// 
			// barEditItemMarquee
			// 
			this.barEditItemMarquee.Caption = "Found YAMLs:";
			this.barEditItemMarquee.Edit = this.repositoryItemMarqueeProgressBar1;
			this.barEditItemMarquee.Id = 1;
			this.barEditItemMarquee.Name = "barEditItemMarquee";
			this.barEditItemMarquee.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
			this.barEditItemMarquee.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
			// 
			// repositoryItemMarqueeProgressBar1
			// 
			this.repositoryItemMarqueeProgressBar1.MarqueeAnimationSpeed = 200;
			this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
			this.repositoryItemMarqueeProgressBar1.Paused = true;
			this.repositoryItemMarqueeProgressBar1.ProgressAnimationMode = DevExpress.Utils.Drawing.ProgressAnimationMode.PingPong;
			this.repositoryItemMarqueeProgressBar1.ShowTitle = true;
			// 
			// barEditItemProgress
			// 
			this.barEditItemProgress.Caption = "Read YAMLs:";
			this.barEditItemProgress.Edit = this.repositoryItemProgressBar2;
			this.barEditItemProgress.Id = 2;
			this.barEditItemProgress.Name = "barEditItemProgress";
			this.barEditItemProgress.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
			this.barEditItemProgress.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
			// 
			// repositoryItemProgressBar2
			// 
			this.repositoryItemProgressBar2.DisplayFormat.FormatString = "0.0";
			this.repositoryItemProgressBar2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.repositoryItemProgressBar2.Name = "repositoryItemProgressBar2";
			this.repositoryItemProgressBar2.PercentView = false;
			this.repositoryItemProgressBar2.ShowTitle = true;
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Manager = this.barManager1;
			this.barDockControlTop.Size = new System.Drawing.Size(1012, 49);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 612);
			this.barDockControlBottom.Manager = this.barManager1;
			this.barDockControlBottom.Size = new System.Drawing.Size(1012, 27);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 49);
			this.barDockControlLeft.Manager = this.barManager1;
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 563);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(1012, 49);
			this.barDockControlRight.Manager = this.barManager1;
			this.barDockControlRight.Size = new System.Drawing.Size(0, 563);
			// 
			// repositoryItemProgressBar1
			// 
			this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
			// 
			// repositoryItemTextEdit1
			// 
			this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
			// 
			// repositoryItemMemoEdit1
			// 
			this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
			// 
			// colExpectedReturnCodes
			// 
			this.colExpectedReturnCodes.Caption = "ExpectedReturnCodes";
			this.colExpectedReturnCodes.FieldName = "ExpectedReturnCodes";
			this.colExpectedReturnCodes.Name = "colExpectedReturnCodes";
			this.colExpectedReturnCodes.Visible = true;
			this.colExpectedReturnCodes.VisibleIndex = 35;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 639);
			this.Controls.Add(this.layoutControl1);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("MainForm.IconOptions.Icon")));
			this.Name = "MainForm";
			this.Text = "WingetRepo Browser";
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditUrl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditRepoFolder.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.memoEditMessages.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditInstallersFolder.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItemRepoFolder)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItemMessages)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

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
		private DevExpress.XtraGrid.Columns.GridColumn colMoniker;
		private DevExpress.XtraGrid.Columns.GridColumn colAuthor;
		private DevExpress.XtraGrid.Columns.GridColumn colLicense;
		private DevExpress.XtraGrid.Columns.GridColumn colLicenseUrl;
		private DevExpress.XtraGrid.Columns.GridColumn colMinOSVersion;
		private DevExpress.XtraGrid.Columns.GridColumn colPackageUrl;
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
		private DevExpress.XtraGrid.Columns.GridColumn colInstUpgradeBehavior;
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
		private DevExpress.XtraGrid.Columns.GridColumn colInstallersLocale;
		private DevExpress.XtraGrid.Columns.GridColumn colInstallersInstallerType;
		private DevExpress.XtraGrid.Columns.GridColumn colSwitchesInteractive;
		private DevExpress.XtraGrid.Columns.GridColumn colManifestSwitchInteractive;
		private DevExpress.XtraGrid.Columns.GridColumn colManifestSwitchSilent;
		private DevExpress.XtraGrid.Columns.GridColumn colManifestSwitchSilentWithProgress;
		private DevExpress.XtraGrid.Columns.GridColumn colManifestType;
		private DevExpress.XtraGrid.Columns.GridColumn colDefaultLocale;
		private DevExpress.XtraGrid.Columns.GridColumn colPackageLocale;
		private DevExpress.XtraGrid.Columns.GridColumn colShortDescription;
		private DevExpress.XtraGrid.Columns.GridColumn colPublisherUrl;
		private DevExpress.XtraGrid.Columns.GridColumn colPrivacyUrl;
		private DevExpress.XtraGrid.Columns.GridColumn colInstProductCode;
		private DevExpress.XtraEditors.MemoEdit memoEditMessages;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItemMessages;
		private DevExpress.XtraLayout.SplitterItem splitterItem1;
		private DevExpress.XtraGrid.Columns.GridColumn colParsedVersion;
        private DevExpress.XtraGrid.Columns.GridColumn gridReleaseDate;
        private DevExpress.XtraGrid.Columns.GridColumn colReleaseDate;
		private DevExpress.XtraGrid.Columns.GridColumn colInstallModes;
		private DevExpress.XtraGrid.Columns.GridColumn colMainInstallModes;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.Bar bar2;
		private DevExpress.XtraBars.Bar bar3;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
		private DevExpress.XtraBars.BarEditItem barEditItemMarquee;
		private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
		private DevExpress.XtraBars.BarEditItem barEditItemProgress;
		private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar2;
		private DevExpress.XtraBars.BarStaticItem barStaticItem1;
		private DevExpress.XtraGrid.Columns.GridColumn colPublisherSupportUrl;
		private DevExpress.XtraGrid.Columns.GridColumn colPlatforms;
		private DevExpress.XtraGrid.Columns.GridColumn colExpectedReturnCodes;
	}
}
