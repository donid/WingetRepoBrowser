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
			components = new System.ComponentModel.Container();
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			colInstArch = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstUrl = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstSha256 = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstSignatureSha256 = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstInstallerType = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstallModes = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstScope = new DevExpress.XtraGrid.Columns.GridColumn();
			gridReleaseDate = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstLanguage = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstUpgradeBehavior = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstSwitchesSilent = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstSwitchesSilentWithProgress = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstSwitchesCustom = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstSwitchesInstallLocation = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstSwitchesLanguage = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstSwitchesLog = new DevExpress.XtraGrid.Columns.GridColumn();
			colSwitchesInteractive = new DevExpress.XtraGrid.Columns.GridColumn();
			gridControl1 = new DevExpress.XtraGrid.GridControl();
			gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			colFilePath = new DevExpress.XtraGrid.Columns.GridColumn();
			colManifestType = new DevExpress.XtraGrid.Columns.GridColumn();
			colId = new DevExpress.XtraGrid.Columns.GridColumn();
			colName = new DevExpress.XtraGrid.Columns.GridColumn();
			colVersion = new DevExpress.XtraGrid.Columns.GridColumn();
			colParsedVersion = new DevExpress.XtraGrid.Columns.GridColumn();
			colReleaseDate = new DevExpress.XtraGrid.Columns.GridColumn();
			colDefaultLocale = new DevExpress.XtraGrid.Columns.GridColumn();
			colPackageLocale = new DevExpress.XtraGrid.Columns.GridColumn();
			colPublisher = new DevExpress.XtraGrid.Columns.GridColumn();
			colMoniker = new DevExpress.XtraGrid.Columns.GridColumn();
			colAuthor = new DevExpress.XtraGrid.Columns.GridColumn();
			colLicense = new DevExpress.XtraGrid.Columns.GridColumn();
			colLicenseUrl = new DevExpress.XtraGrid.Columns.GridColumn();
			repositoryItemButtonEditUrl = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			colPublisherSupportUrl = new DevExpress.XtraGrid.Columns.GridColumn();
			colPublisherUrl = new DevExpress.XtraGrid.Columns.GridColumn();
			colPrivacyUrl = new DevExpress.XtraGrid.Columns.GridColumn();
			colMinOSVersion = new DevExpress.XtraGrid.Columns.GridColumn();
			colPackageUrl = new DevExpress.XtraGrid.Columns.GridColumn();
			colShortDescription = new DevExpress.XtraGrid.Columns.GridColumn();
			colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
			colTags = new DevExpress.XtraGrid.Columns.GridColumn();
			colFileExtensions = new DevExpress.XtraGrid.Columns.GridColumn();
			colProtocols = new DevExpress.XtraGrid.Columns.GridColumn();
			colCommands = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstallerType = new DevExpress.XtraGrid.Columns.GridColumn();
			colMainInstallModes = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstallersCount = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstallersArch = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstallersLocale = new DevExpress.XtraGrid.Columns.GridColumn();
			colInstallersInstallerType = new DevExpress.XtraGrid.Columns.GridColumn();
			colManifestSwitchInteractive = new DevExpress.XtraGrid.Columns.GridColumn();
			colManifestSwitchSilent = new DevExpress.XtraGrid.Columns.GridColumn();
			colManifestSwitchSilentWithProgress = new DevExpress.XtraGrid.Columns.GridColumn();
			colPlatforms = new DevExpress.XtraGrid.Columns.GridColumn();
			colExpectedReturnCodes = new DevExpress.XtraGrid.Columns.GridColumn();
			textEditRepoFolder = new DevExpress.XtraEditors.TextEdit();
			layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			numericUpDownAgeLimitCommitDays = new System.Windows.Forms.NumericUpDown();
			memoEditMessages = new DevExpress.XtraEditors.MemoEdit();
			simpleButtonCreateSubFoldersForSelected = new DevExpress.XtraEditors.SimpleButton();
			simpleButtonCheckForNewDownloads = new DevExpress.XtraEditors.SimpleButton();
			textEditInstallersFolder = new DevExpress.XtraEditors.TextEdit();
			simpleButtonOpenGitRepo = new DevExpress.XtraEditors.SimpleButton();
			simpleButtonSearch = new DevExpress.XtraEditors.SimpleButton();
			Root = new DevExpress.XtraLayout.LayoutControlGroup();
			layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItemRepoFolder = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItemMessages = new DevExpress.XtraLayout.LayoutControlItem();
			splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
			layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
			barManager1 = new DevExpress.XtraBars.BarManager(components);
			bar1 = new DevExpress.XtraBars.Bar();
			bar2 = new DevExpress.XtraBars.Bar();
			bar3 = new DevExpress.XtraBars.Bar();
			barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
			barEditItemMarquee = new DevExpress.XtraBars.BarEditItem();
			repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
			barEditItemProgress = new DevExpress.XtraBars.BarEditItem();
			repositoryItemProgressBar2 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
			barStaticItemResult = new DevExpress.XtraBars.BarStaticItem();
			barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
			repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			((System.ComponentModel.ISupportInitialize)gridView2).BeginInit();
			((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
			((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemButtonEditUrl).BeginInit();
			((System.ComponentModel.ISupportInitialize)textEditRepoFolder.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
			layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDownAgeLimitCommitDays).BeginInit();
			((System.ComponentModel.ISupportInitialize)memoEditMessages.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)textEditInstallersFolder.Properties).BeginInit();
			((System.ComponentModel.ISupportInitialize)Root).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItemRepoFolder).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItemMessages).BeginInit();
			((System.ComponentModel.ISupportInitialize)splitterItem1).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
			((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemMarqueeProgressBar1).BeginInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemProgressBar2).BeginInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemProgressBar1).BeginInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).BeginInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit1).BeginInit();
			SuspendLayout();
			// 
			// gridView2
			// 
			gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colInstArch, colInstUrl, colInstSha256, colInstSignatureSha256, colInstInstallerType, colInstallModes, colInstScope, gridReleaseDate, colInstLanguage, colInstProductCode, colInstUpgradeBehavior, colInstSwitchesSilent, colInstSwitchesSilentWithProgress, colInstSwitchesCustom, colInstSwitchesInstallLocation, colInstSwitchesLanguage, colInstSwitchesLog, colSwitchesInteractive });
			gridView2.GridControl = gridControl1;
			gridView2.Name = "gridView2";
			gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// colInstArch
			// 
			colInstArch.FieldName = "Arch";
			colInstArch.Name = "colInstArch";
			colInstArch.Visible = true;
			colInstArch.VisibleIndex = 0;
			// 
			// colInstUrl
			// 
			colInstUrl.FieldName = "Url";
			colInstUrl.Name = "colInstUrl";
			colInstUrl.Visible = true;
			colInstUrl.VisibleIndex = 3;
			// 
			// colInstSha256
			// 
			colInstSha256.FieldName = "Sha256";
			colInstSha256.Name = "colInstSha256";
			colInstSha256.Visible = true;
			colInstSha256.VisibleIndex = 1;
			// 
			// colInstSignatureSha256
			// 
			colInstSignatureSha256.FieldName = "SignatureSha256";
			colInstSignatureSha256.Name = "colInstSignatureSha256";
			colInstSignatureSha256.Visible = true;
			colInstSignatureSha256.VisibleIndex = 2;
			// 
			// colInstInstallerType
			// 
			colInstInstallerType.FieldName = "InstallerType";
			colInstInstallerType.Name = "colInstInstallerType";
			colInstInstallerType.Visible = true;
			colInstInstallerType.VisibleIndex = 5;
			// 
			// colInstallModes
			// 
			colInstallModes.FieldName = "InstallModes";
			colInstallModes.Name = "colInstallModes";
			colInstallModes.Visible = true;
			colInstallModes.VisibleIndex = 4;
			// 
			// colInstScope
			// 
			colInstScope.FieldName = "Scope";
			colInstScope.Name = "colInstScope";
			colInstScope.Visible = true;
			colInstScope.VisibleIndex = 7;
			// 
			// gridReleaseDate
			// 
			gridReleaseDate.FieldName = "ReleaseDate";
			gridReleaseDate.Name = "gridReleaseDate";
			gridReleaseDate.Visible = true;
			gridReleaseDate.VisibleIndex = 6;
			// 
			// colInstLanguage
			// 
			colInstLanguage.Caption = "InstallerLocale";
			colInstLanguage.FieldName = "InstallerLocale";
			colInstLanguage.Name = "colInstLanguage";
			colInstLanguage.Visible = true;
			colInstLanguage.VisibleIndex = 8;
			// 
			// colInstProductCode
			// 
			colInstProductCode.Caption = "ProductCode";
			colInstProductCode.FieldName = "ProductCode";
			colInstProductCode.Name = "colInstProductCode";
			colInstProductCode.Visible = true;
			colInstProductCode.VisibleIndex = 9;
			// 
			// colInstUpgradeBehavior
			// 
			colInstUpgradeBehavior.Caption = "UpgradeBehavior";
			colInstUpgradeBehavior.FieldName = "UpgradeBehavior";
			colInstUpgradeBehavior.Name = "colInstUpgradeBehavior";
			colInstUpgradeBehavior.Visible = true;
			colInstUpgradeBehavior.VisibleIndex = 10;
			// 
			// colInstSwitchesSilent
			// 
			colInstSwitchesSilent.FieldName = "SwitchesSilent";
			colInstSwitchesSilent.Name = "colInstSwitchesSilent";
			colInstSwitchesSilent.Visible = true;
			colInstSwitchesSilent.VisibleIndex = 11;
			// 
			// colInstSwitchesSilentWithProgress
			// 
			colInstSwitchesSilentWithProgress.FieldName = "SwitchesSilentWithProgress";
			colInstSwitchesSilentWithProgress.Name = "colInstSwitchesSilentWithProgress";
			colInstSwitchesSilentWithProgress.Visible = true;
			colInstSwitchesSilentWithProgress.VisibleIndex = 12;
			// 
			// colInstSwitchesCustom
			// 
			colInstSwitchesCustom.FieldName = "SwitchesCustom";
			colInstSwitchesCustom.Name = "colInstSwitchesCustom";
			colInstSwitchesCustom.Visible = true;
			colInstSwitchesCustom.VisibleIndex = 13;
			// 
			// colInstSwitchesInstallLocation
			// 
			colInstSwitchesInstallLocation.FieldName = "SwitchesInstallLocation";
			colInstSwitchesInstallLocation.Name = "colInstSwitchesInstallLocation";
			colInstSwitchesInstallLocation.Visible = true;
			colInstSwitchesInstallLocation.VisibleIndex = 14;
			// 
			// colInstSwitchesLanguage
			// 
			colInstSwitchesLanguage.FieldName = "SwitchesLanguage";
			colInstSwitchesLanguage.Name = "colInstSwitchesLanguage";
			colInstSwitchesLanguage.Visible = true;
			colInstSwitchesLanguage.VisibleIndex = 15;
			// 
			// colInstSwitchesLog
			// 
			colInstSwitchesLog.FieldName = "SwitchesLog";
			colInstSwitchesLog.Name = "colInstSwitchesLog";
			colInstSwitchesLog.Visible = true;
			colInstSwitchesLog.VisibleIndex = 16;
			// 
			// colSwitchesInteractive
			// 
			colSwitchesInteractive.FieldName = "SwitchesInteractive";
			colSwitchesInteractive.Name = "colSwitchesInteractive";
			colSwitchesInteractive.Visible = true;
			colSwitchesInteractive.VisibleIndex = 17;
			// 
			// gridControl1
			// 
			gridLevelNode1.LevelTemplate = gridView2;
			gridLevelNode1.RelationName = "Installers";
			gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] { gridLevelNode1 });
			gridControl1.Location = new System.Drawing.Point(5, 140);
			gridControl1.MainView = gridView1;
			gridControl1.Name = "gridControl1";
			gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemButtonEditUrl });
			gridControl1.Size = new System.Drawing.Size(1002, 422);
			gridControl1.TabIndex = 4;
			gridControl1.UseEmbeddedNavigator = true;
			gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1, gridView2 });
			// 
			// gridView1
			// 
			gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { colFilePath, colManifestType, colId, colName, colVersion, colParsedVersion, colReleaseDate, colDefaultLocale, colPackageLocale, colPublisher, colMoniker, colAuthor, colLicense, colLicenseUrl, colPublisherSupportUrl, colPublisherUrl, colPrivacyUrl, colMinOSVersion, colPackageUrl, colShortDescription, colDescription, colTags, colFileExtensions, colProtocols, colCommands, colInstallerType, colMainInstallModes, colInstallersCount, colInstallersArch, colInstallersLocale, colInstallersInstallerType, colManifestSwitchInteractive, colManifestSwitchSilent, colManifestSwitchSilentWithProgress, colPlatforms, colExpectedReturnCodes });
			gridView1.GridControl = gridControl1;
			gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] { new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Version", null, "(Version: Count={0})") });
			gridView1.Name = "gridView1";
			gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Classic;
			gridView1.OptionsDetail.ShowDetailTabs = false;
			gridView1.OptionsSelection.MultiSelect = true;
			gridView1.OptionsView.ColumnAutoWidth = false;
			gridView1.OptionsView.ShowAutoFilterRow = true;
			gridView1.OptionsView.ShowFooter = true;
			gridView1.CustomDrawFooter += gridView1_CustomDrawFooter;
			gridView1.MasterRowGetChildList += gridView1_MasterRowGetChildList;
			gridView1.MasterRowGetRelationName += gridView1_MasterRowGetRelationName;
			gridView1.MasterRowGetRelationCount += gridView1_MasterRowGetRelationCount;
			// 
			// colFilePath
			// 
			colFilePath.FieldName = "FilePath";
			colFilePath.Name = "colFilePath";
			colFilePath.OptionsColumn.ReadOnly = true;
			colFilePath.Visible = true;
			colFilePath.VisibleIndex = 0;
			// 
			// colManifestType
			// 
			colManifestType.Caption = "ManifestType";
			colManifestType.FieldName = "ManifestType";
			colManifestType.Name = "colManifestType";
			colManifestType.Visible = true;
			colManifestType.VisibleIndex = 1;
			// 
			// colId
			// 
			colId.FieldName = "Id";
			colId.Name = "colId";
			colId.OptionsColumn.ReadOnly = true;
			colId.Visible = true;
			colId.VisibleIndex = 2;
			// 
			// colName
			// 
			colName.FieldName = "Name";
			colName.Name = "colName";
			colName.OptionsColumn.ReadOnly = true;
			colName.Visible = true;
			colName.VisibleIndex = 3;
			// 
			// colVersion
			// 
			colVersion.FieldName = "Version";
			colVersion.Name = "colVersion";
			colVersion.OptionsColumn.ReadOnly = true;
			colVersion.Visible = true;
			colVersion.VisibleIndex = 4;
			// 
			// colParsedVersion
			// 
			colParsedVersion.Caption = "ParsedVersion";
			colParsedVersion.FieldName = "ParsedPackageVersion";
			colParsedVersion.Name = "colParsedVersion";
			colParsedVersion.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			colParsedVersion.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
			colParsedVersion.Visible = true;
			colParsedVersion.VisibleIndex = 5;
			// 
			// colReleaseDate
			// 
			colReleaseDate.FieldName = "ReleaseDate";
			colReleaseDate.Name = "colReleaseDate";
			colReleaseDate.ToolTip = "If the release date is specified per installer, the maximum date is shown";
			colReleaseDate.Visible = true;
			colReleaseDate.VisibleIndex = 6;
			// 
			// colDefaultLocale
			// 
			colDefaultLocale.Caption = "DefaultLocale";
			colDefaultLocale.FieldName = "DefaultLocale";
			colDefaultLocale.Name = "colDefaultLocale";
			colDefaultLocale.Visible = true;
			colDefaultLocale.VisibleIndex = 8;
			// 
			// colPackageLocale
			// 
			colPackageLocale.Caption = "PackageLocale";
			colPackageLocale.FieldName = "PackageLocale";
			colPackageLocale.Name = "colPackageLocale";
			colPackageLocale.Visible = true;
			colPackageLocale.VisibleIndex = 7;
			// 
			// colPublisher
			// 
			colPublisher.FieldName = "Publisher";
			colPublisher.Name = "colPublisher";
			colPublisher.OptionsColumn.ReadOnly = true;
			colPublisher.Visible = true;
			colPublisher.VisibleIndex = 15;
			// 
			// colMoniker
			// 
			colMoniker.FieldName = "Moniker";
			colMoniker.Name = "colMoniker";
			colMoniker.OptionsColumn.ReadOnly = true;
			colMoniker.Visible = true;
			colMoniker.VisibleIndex = 9;
			// 
			// colAuthor
			// 
			colAuthor.FieldName = "Author";
			colAuthor.Name = "colAuthor";
			colAuthor.OptionsColumn.ReadOnly = true;
			colAuthor.Visible = true;
			colAuthor.VisibleIndex = 14;
			// 
			// colLicense
			// 
			colLicense.FieldName = "License";
			colLicense.Name = "colLicense";
			colLicense.OptionsColumn.ReadOnly = true;
			colLicense.Visible = true;
			colLicense.VisibleIndex = 31;
			// 
			// colLicenseUrl
			// 
			colLicenseUrl.ColumnEdit = repositoryItemButtonEditUrl;
			colLicenseUrl.FieldName = "LicenseUrl";
			colLicenseUrl.Name = "colLicenseUrl";
			colLicenseUrl.OptionsColumn.ReadOnly = true;
			colLicenseUrl.Visible = true;
			colLicenseUrl.VisibleIndex = 32;
			// 
			// repositoryItemButtonEditUrl
			// 
			repositoryItemButtonEditUrl.AutoHeight = false;
			repositoryItemButtonEditUrl.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search) });
			repositoryItemButtonEditUrl.Name = "repositoryItemButtonEditUrl";
			repositoryItemButtonEditUrl.ButtonClick += repositoryItemButtonEditUrl_ButtonClick;
			// 
			// colPublisherSupportUrl
			// 
			colPublisherSupportUrl.Caption = "PublisherSupportUrl";
			colPublisherSupportUrl.FieldName = "PublisherSupportUrl";
			colPublisherSupportUrl.Name = "colPublisherSupportUrl";
			colPublisherSupportUrl.Visible = true;
			colPublisherSupportUrl.VisibleIndex = 17;
			// 
			// colPublisherUrl
			// 
			colPublisherUrl.Caption = "PublisherUrl";
			colPublisherUrl.FieldName = "PublisherUrl";
			colPublisherUrl.Name = "colPublisherUrl";
			colPublisherUrl.Visible = true;
			colPublisherUrl.VisibleIndex = 16;
			// 
			// colPrivacyUrl
			// 
			colPrivacyUrl.Caption = "PrivacyUrl";
			colPrivacyUrl.FieldName = "PrivacyUrl";
			colPrivacyUrl.Name = "colPrivacyUrl";
			colPrivacyUrl.Visible = true;
			colPrivacyUrl.VisibleIndex = 33;
			// 
			// colMinOSVersion
			// 
			colMinOSVersion.FieldName = "MinOSVersion";
			colMinOSVersion.Name = "colMinOSVersion";
			colMinOSVersion.OptionsColumn.ReadOnly = true;
			colMinOSVersion.Visible = true;
			colMinOSVersion.VisibleIndex = 18;
			// 
			// colPackageUrl
			// 
			colPackageUrl.ColumnEdit = repositoryItemButtonEditUrl;
			colPackageUrl.FieldName = "PackageUrl";
			colPackageUrl.Name = "colPackageUrl";
			colPackageUrl.OptionsColumn.ReadOnly = true;
			colPackageUrl.Visible = true;
			colPackageUrl.VisibleIndex = 10;
			// 
			// colShortDescription
			// 
			colShortDescription.Caption = "ShortDescription";
			colShortDescription.FieldName = "ShortDescription";
			colShortDescription.Name = "colShortDescription";
			colShortDescription.Visible = true;
			colShortDescription.VisibleIndex = 11;
			// 
			// colDescription
			// 
			colDescription.FieldName = "Description";
			colDescription.Name = "colDescription";
			colDescription.OptionsColumn.ReadOnly = true;
			colDescription.Visible = true;
			colDescription.VisibleIndex = 12;
			// 
			// colTags
			// 
			colTags.FieldName = "Tags";
			colTags.Name = "colTags";
			colTags.OptionsColumn.ReadOnly = true;
			colTags.Visible = true;
			colTags.VisibleIndex = 13;
			// 
			// colFileExtensions
			// 
			colFileExtensions.FieldName = "FileExtensions";
			colFileExtensions.Name = "colFileExtensions";
			colFileExtensions.OptionsColumn.ReadOnly = true;
			colFileExtensions.Visible = true;
			colFileExtensions.VisibleIndex = 19;
			// 
			// colProtocols
			// 
			colProtocols.FieldName = "Protocols";
			colProtocols.Name = "colProtocols";
			colProtocols.OptionsColumn.ReadOnly = true;
			colProtocols.Visible = true;
			colProtocols.VisibleIndex = 20;
			// 
			// colCommands
			// 
			colCommands.FieldName = "Commands";
			colCommands.Name = "colCommands";
			colCommands.OptionsColumn.ReadOnly = true;
			colCommands.Visible = true;
			colCommands.VisibleIndex = 21;
			// 
			// colInstallerType
			// 
			colInstallerType.FieldName = "InstallerType";
			colInstallerType.Name = "colInstallerType";
			colInstallerType.OptionsColumn.ReadOnly = true;
			colInstallerType.Visible = true;
			colInstallerType.VisibleIndex = 22;
			// 
			// colMainInstallModes
			// 
			colMainInstallModes.FieldName = "InstallModes";
			colMainInstallModes.Name = "colMainInstallModes";
			colMainInstallModes.OptionsColumn.ReadOnly = true;
			colMainInstallModes.Visible = true;
			colMainInstallModes.VisibleIndex = 26;
			// 
			// colInstallersCount
			// 
			colInstallersCount.FieldName = "InstallersCount";
			colInstallersCount.Name = "colInstallersCount";
			colInstallersCount.OptionsColumn.ReadOnly = true;
			colInstallersCount.Visible = true;
			colInstallersCount.VisibleIndex = 23;
			// 
			// colInstallersArch
			// 
			colInstallersArch.FieldName = "InstallersArch";
			colInstallersArch.Name = "colInstallersArch";
			colInstallersArch.Visible = true;
			colInstallersArch.VisibleIndex = 25;
			// 
			// colInstallersLocale
			// 
			colInstallersLocale.Caption = "InstallersLocale";
			colInstallersLocale.FieldName = "InstallersLocale";
			colInstallersLocale.Name = "colInstallersLocale";
			colInstallersLocale.Visible = true;
			colInstallersLocale.VisibleIndex = 27;
			// 
			// colInstallersInstallerType
			// 
			colInstallersInstallerType.FieldName = "InstallersInstallerType";
			colInstallersInstallerType.Name = "colInstallersInstallerType";
			colInstallersInstallerType.Visible = true;
			colInstallersInstallerType.VisibleIndex = 24;
			// 
			// colManifestSwitchInteractive
			// 
			colManifestSwitchInteractive.FieldName = "ManifestSwitchInteractive";
			colManifestSwitchInteractive.Name = "colManifestSwitchInteractive";
			colManifestSwitchInteractive.Visible = true;
			colManifestSwitchInteractive.VisibleIndex = 28;
			// 
			// colManifestSwitchSilent
			// 
			colManifestSwitchSilent.FieldName = "ManifestSwitchSilentWithProgress";
			colManifestSwitchSilent.Name = "colManifestSwitchSilent";
			colManifestSwitchSilent.Visible = true;
			colManifestSwitchSilent.VisibleIndex = 29;
			// 
			// colManifestSwitchSilentWithProgress
			// 
			colManifestSwitchSilentWithProgress.FieldName = "ManifestSwitchSilentWithProgress";
			colManifestSwitchSilentWithProgress.Name = "colManifestSwitchSilentWithProgress";
			colManifestSwitchSilentWithProgress.Visible = true;
			colManifestSwitchSilentWithProgress.VisibleIndex = 30;
			// 
			// colPlatforms
			// 
			colPlatforms.Caption = "Platforms";
			colPlatforms.FieldName = "Platforms";
			colPlatforms.Name = "colPlatforms";
			colPlatforms.Visible = true;
			colPlatforms.VisibleIndex = 34;
			// 
			// colExpectedReturnCodes
			// 
			colExpectedReturnCodes.Caption = "ExpectedReturnCodes";
			colExpectedReturnCodes.FieldName = "ExpectedReturnCodes";
			colExpectedReturnCodes.Name = "colExpectedReturnCodes";
			colExpectedReturnCodes.Visible = true;
			colExpectedReturnCodes.VisibleIndex = 35;
			// 
			// textEditRepoFolder
			// 
			textEditRepoFolder.Location = new System.Drawing.Point(91, 5);
			textEditRepoFolder.Name = "textEditRepoFolder";
			textEditRepoFolder.Size = new System.Drawing.Size(480, 20);
			textEditRepoFolder.StyleController = layoutControl1;
			textEditRepoFolder.TabIndex = 5;
			// 
			// layoutControl1
			// 
			layoutControl1.Controls.Add(numericUpDownAgeLimitCommitDays);
			layoutControl1.Controls.Add(memoEditMessages);
			layoutControl1.Controls.Add(simpleButtonCreateSubFoldersForSelected);
			layoutControl1.Controls.Add(simpleButtonCheckForNewDownloads);
			layoutControl1.Controls.Add(textEditInstallersFolder);
			layoutControl1.Controls.Add(simpleButtonOpenGitRepo);
			layoutControl1.Controls.Add(simpleButtonSearch);
			layoutControl1.Controls.Add(textEditRepoFolder);
			layoutControl1.Controls.Add(gridControl1);
			layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			layoutControl1.Location = new System.Drawing.Point(0, 49);
			layoutControl1.Name = "layoutControl1";
			layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(4790, 879, 650, 400);
			layoutControl1.Root = Root;
			layoutControl1.Size = new System.Drawing.Size(1012, 567);
			layoutControl1.TabIndex = 6;
			layoutControl1.Text = "layoutControl1";
			// 
			// numericUpDownAgeLimitCommitDays
			// 
			numericUpDownAgeLimitCommitDays.Location = new System.Drawing.Point(661, 5);
			numericUpDownAgeLimitCommitDays.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
			numericUpDownAgeLimitCommitDays.Name = "numericUpDownAgeLimitCommitDays";
			numericUpDownAgeLimitCommitDays.Size = new System.Drawing.Size(40, 21);
			numericUpDownAgeLimitCommitDays.TabIndex = 13;
			numericUpDownAgeLimitCommitDays.Value = new decimal(new int[] { 30, 0, 0, 0 });
			// 
			// memoEditMessages
			// 
			memoEditMessages.Location = new System.Drawing.Point(5, 73);
			memoEditMessages.Name = "memoEditMessages";
			memoEditMessages.Size = new System.Drawing.Size(1002, 58);
			memoEditMessages.StyleController = layoutControl1;
			memoEditMessages.TabIndex = 11;
			// 
			// simpleButtonCreateSubFoldersForSelected
			// 
			simpleButtonCreateSubFoldersForSelected.Enabled = false;
			simpleButtonCreateSubFoldersForSelected.Location = new System.Drawing.Point(846, 31);
			simpleButtonCreateSubFoldersForSelected.Name = "simpleButtonCreateSubFoldersForSelected";
			simpleButtonCreateSubFoldersForSelected.Size = new System.Drawing.Size(161, 22);
			simpleButtonCreateSubFoldersForSelected.StyleController = layoutControl1;
			simpleButtonCreateSubFoldersForSelected.TabIndex = 10;
			simpleButtonCreateSubFoldersForSelected.Text = "CreateSubFolders For Selected";
			simpleButtonCreateSubFoldersForSelected.Click += simpleButtonCreateSubFoldersForSelected_Click;
			// 
			// simpleButtonCheckForNewDownloads
			// 
			simpleButtonCheckForNewDownloads.Enabled = false;
			simpleButtonCheckForNewDownloads.Location = new System.Drawing.Point(705, 31);
			simpleButtonCheckForNewDownloads.Name = "simpleButtonCheckForNewDownloads";
			simpleButtonCheckForNewDownloads.Size = new System.Drawing.Size(137, 22);
			simpleButtonCheckForNewDownloads.StyleController = layoutControl1;
			simpleButtonCheckForNewDownloads.TabIndex = 9;
			simpleButtonCheckForNewDownloads.Text = "Check For New Downloads";
			simpleButtonCheckForNewDownloads.Click += simpleButtonCheckForNewDownloads_Click;
			// 
			// textEditInstallersFolder
			// 
			textEditInstallersFolder.Location = new System.Drawing.Point(91, 31);
			textEditInstallersFolder.Name = "textEditInstallersFolder";
			textEditInstallersFolder.Size = new System.Drawing.Size(610, 20);
			textEditInstallersFolder.StyleController = layoutControl1;
			textEditInstallersFolder.TabIndex = 8;
			// 
			// simpleButtonOpenGitRepo
			// 
			simpleButtonOpenGitRepo.Location = new System.Drawing.Point(846, 5);
			simpleButtonOpenGitRepo.Name = "simpleButtonOpenGitRepo";
			simpleButtonOpenGitRepo.Size = new System.Drawing.Size(161, 22);
			simpleButtonOpenGitRepo.StyleController = layoutControl1;
			simpleButtonOpenGitRepo.TabIndex = 7;
			simpleButtonOpenGitRepo.Text = "Open GitRepo";
			simpleButtonOpenGitRepo.Click += simpleButtonOpenGitRepo_Click;
			// 
			// simpleButtonSearch
			// 
			simpleButtonSearch.Location = new System.Drawing.Point(705, 5);
			simpleButtonSearch.Name = "simpleButtonSearch";
			simpleButtonSearch.Size = new System.Drawing.Size(137, 22);
			simpleButtonSearch.StyleController = layoutControl1;
			simpleButtonSearch.TabIndex = 6;
			simpleButtonSearch.Text = "Search";
			simpleButtonSearch.Click += simpleButtonSearch_Click;
			// 
			// Root
			// 
			Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			Root.GroupBordersVisible = false;
			Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItemRepoFolder, layoutControlItem2, layoutControlItem3, layoutControlItem4, layoutControlItem5, layoutControlItem6, layoutControlItemMessages, splitterItem1, layoutControlItem8 });
			Root.Name = "Root";
			Root.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
			Root.Size = new System.Drawing.Size(1012, 567);
			Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			layoutControlItem1.Control = gridControl1;
			layoutControlItem1.Location = new System.Drawing.Point(0, 135);
			layoutControlItem1.Name = "layoutControlItem1";
			layoutControlItem1.Size = new System.Drawing.Size(1006, 426);
			layoutControlItem1.TextVisible = false;
			// 
			// layoutControlItemRepoFolder
			// 
			layoutControlItemRepoFolder.Control = textEditRepoFolder;
			layoutControlItemRepoFolder.Location = new System.Drawing.Point(0, 0);
			layoutControlItemRepoFolder.Name = "layoutControlItemRepoFolder";
			layoutControlItemRepoFolder.Size = new System.Drawing.Size(570, 26);
			layoutControlItemRepoFolder.Text = "Repo-Folder:";
			layoutControlItemRepoFolder.TextSize = new System.Drawing.Size(82, 13);
			// 
			// layoutControlItem2
			// 
			layoutControlItem2.Control = simpleButtonSearch;
			layoutControlItem2.Location = new System.Drawing.Point(700, 0);
			layoutControlItem2.Name = "layoutControlItem2";
			layoutControlItem2.Size = new System.Drawing.Size(141, 26);
			layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			layoutControlItem3.Control = simpleButtonOpenGitRepo;
			layoutControlItem3.Location = new System.Drawing.Point(841, 0);
			layoutControlItem3.Name = "layoutControlItem3";
			layoutControlItem3.Size = new System.Drawing.Size(165, 26);
			layoutControlItem3.TextVisible = false;
			// 
			// layoutControlItem4
			// 
			layoutControlItem4.Control = textEditInstallersFolder;
			layoutControlItem4.Location = new System.Drawing.Point(0, 26);
			layoutControlItem4.Name = "layoutControlItem4";
			layoutControlItem4.Size = new System.Drawing.Size(700, 26);
			layoutControlItem4.Text = "Installers-Folder:";
			layoutControlItem4.TextSize = new System.Drawing.Size(82, 13);
			// 
			// layoutControlItem5
			// 
			layoutControlItem5.Control = simpleButtonCheckForNewDownloads;
			layoutControlItem5.Location = new System.Drawing.Point(700, 26);
			layoutControlItem5.Name = "layoutControlItem5";
			layoutControlItem5.Size = new System.Drawing.Size(141, 26);
			layoutControlItem5.TextVisible = false;
			// 
			// layoutControlItem6
			// 
			layoutControlItem6.Control = simpleButtonCreateSubFoldersForSelected;
			layoutControlItem6.Location = new System.Drawing.Point(841, 26);
			layoutControlItem6.Name = "layoutControlItem6";
			layoutControlItem6.Size = new System.Drawing.Size(165, 26);
			layoutControlItem6.TextVisible = false;
			// 
			// layoutControlItemMessages
			// 
			layoutControlItemMessages.Control = memoEditMessages;
			layoutControlItemMessages.Location = new System.Drawing.Point(0, 52);
			layoutControlItemMessages.Name = "layoutControlItemMessages";
			layoutControlItemMessages.Size = new System.Drawing.Size(1006, 78);
			layoutControlItemMessages.Text = "Messages:";
			layoutControlItemMessages.TextLocation = DevExpress.Utils.Locations.Top;
			layoutControlItemMessages.TextSize = new System.Drawing.Size(82, 13);
			layoutControlItemMessages.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
			// 
			// splitterItem1
			// 
			splitterItem1.Location = new System.Drawing.Point(0, 130);
			splitterItem1.Name = "splitterItem1";
			splitterItem1.Size = new System.Drawing.Size(1006, 5);
			// 
			// layoutControlItem8
			// 
			layoutControlItem8.Control = numericUpDownAgeLimitCommitDays;
			layoutControlItem8.Location = new System.Drawing.Point(570, 0);
			layoutControlItem8.Name = "layoutControlItem8";
			layoutControlItem8.OptionsToolTip.ToolTip = "Commit Age Limit for Files / -1 means 'No Filter'";
			layoutControlItem8.Size = new System.Drawing.Size(130, 26);
			layoutControlItem8.Text = "Age Limit Days:";
			layoutControlItem8.TextSize = new System.Drawing.Size(82, 13);
			// 
			// barManager1
			// 
			barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1, bar2, bar3 });
			barManager1.DockControls.Add(barDockControlTop);
			barManager1.DockControls.Add(barDockControlBottom);
			barManager1.DockControls.Add(barDockControlLeft);
			barManager1.DockControls.Add(barDockControlRight);
			barManager1.Form = this;
			barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barEditItemMarquee, barEditItemProgress, barStaticItem1, barStaticItemResult });
			barManager1.MainMenu = bar2;
			barManager1.MaxItemId = 5;
			barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemProgressBar1, repositoryItemMarqueeProgressBar1, repositoryItemProgressBar2 });
			barManager1.StatusBar = bar3;
			// 
			// bar1
			// 
			bar1.BarName = "Tools";
			bar1.DockCol = 0;
			bar1.DockRow = 1;
			bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			bar1.Text = "Tools";
			bar1.Visible = false;
			// 
			// bar2
			// 
			bar2.BarName = "Main menu";
			bar2.DockCol = 0;
			bar2.DockRow = 0;
			bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			bar2.OptionsBar.MultiLine = true;
			bar2.OptionsBar.UseWholeRow = true;
			bar2.Text = "Main menu";
			bar2.Visible = false;
			// 
			// bar3
			// 
			bar3.BarName = "Status bar";
			bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
			bar3.DockCol = 0;
			bar3.DockRow = 0;
			bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
			bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barStaticItem1), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, barEditItemMarquee, "", false, true, true, 188), new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, barEditItemProgress, "", false, true, true, 147), new DevExpress.XtraBars.LinkPersistInfo(barStaticItemResult) });
			bar3.OptionsBar.AllowQuickCustomization = false;
			bar3.OptionsBar.DrawDragBorder = false;
			bar3.OptionsBar.UseWholeRow = true;
			bar3.Text = "Status bar";
			// 
			// barStaticItem1
			// 
			barStaticItem1.Caption = "v0.3.1";
			barStaticItem1.Id = 3;
			barStaticItem1.Name = "barStaticItem1";
			// 
			// barEditItemMarquee
			// 
			barEditItemMarquee.Caption = "Found YAMLs:";
			barEditItemMarquee.Edit = repositoryItemMarqueeProgressBar1;
			barEditItemMarquee.Id = 1;
			barEditItemMarquee.Name = "barEditItemMarquee";
			barEditItemMarquee.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
			barEditItemMarquee.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
			// 
			// repositoryItemMarqueeProgressBar1
			// 
			repositoryItemMarqueeProgressBar1.MarqueeAnimationSpeed = 200;
			repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
			repositoryItemMarqueeProgressBar1.Paused = true;
			repositoryItemMarqueeProgressBar1.ProgressAnimationMode = DevExpress.Utils.Drawing.ProgressAnimationMode.PingPong;
			repositoryItemMarqueeProgressBar1.ShowTitle = true;
			// 
			// barEditItemProgress
			// 
			barEditItemProgress.Caption = "Read YAMLs:";
			barEditItemProgress.Edit = repositoryItemProgressBar2;
			barEditItemProgress.Id = 2;
			barEditItemProgress.Name = "barEditItemProgress";
			barEditItemProgress.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
			barEditItemProgress.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
			// 
			// repositoryItemProgressBar2
			// 
			repositoryItemProgressBar2.DisplayFormat.FormatString = "0.0 \\%";
			repositoryItemProgressBar2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			repositoryItemProgressBar2.Name = "repositoryItemProgressBar2";
			repositoryItemProgressBar2.PercentView = false;
			repositoryItemProgressBar2.ShowTitle = true;
			// 
			// barStaticItemResult
			// 
			barStaticItemResult.Id = 4;
			barStaticItemResult.Name = "barStaticItemResult";
			// 
			// barDockControlTop
			// 
			barDockControlTop.CausesValidation = false;
			barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			barDockControlTop.Location = new System.Drawing.Point(0, 0);
			barDockControlTop.Manager = barManager1;
			barDockControlTop.Size = new System.Drawing.Size(1012, 49);
			// 
			// barDockControlBottom
			// 
			barDockControlBottom.CausesValidation = false;
			barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			barDockControlBottom.Location = new System.Drawing.Point(0, 616);
			barDockControlBottom.Manager = barManager1;
			barDockControlBottom.Size = new System.Drawing.Size(1012, 23);
			// 
			// barDockControlLeft
			// 
			barDockControlLeft.CausesValidation = false;
			barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			barDockControlLeft.Location = new System.Drawing.Point(0, 49);
			barDockControlLeft.Manager = barManager1;
			barDockControlLeft.Size = new System.Drawing.Size(0, 567);
			// 
			// barDockControlRight
			// 
			barDockControlRight.CausesValidation = false;
			barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			barDockControlRight.Location = new System.Drawing.Point(1012, 49);
			barDockControlRight.Manager = barManager1;
			barDockControlRight.Size = new System.Drawing.Size(0, 567);
			// 
			// repositoryItemProgressBar1
			// 
			repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
			// 
			// repositoryItemTextEdit1
			// 
			repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
			// 
			// repositoryItemMemoEdit1
			// 
			repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
			// 
			// MainForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1012, 639);
			Controls.Add(layoutControl1);
			Controls.Add(barDockControlLeft);
			Controls.Add(barDockControlRight);
			Controls.Add(barDockControlBottom);
			Controls.Add(barDockControlTop);
			IconOptions.Icon = (System.Drawing.Icon)resources.GetObject("MainForm.IconOptions.Icon");
			Name = "MainForm";
			Text = "WingetRepo Browser";
			((System.ComponentModel.ISupportInitialize)gridView2).EndInit();
			((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
			((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemButtonEditUrl).EndInit();
			((System.ComponentModel.ISupportInitialize)textEditRepoFolder.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
			layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)numericUpDownAgeLimitCommitDays).EndInit();
			((System.ComponentModel.ISupportInitialize)memoEditMessages.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)textEditInstallersFolder.Properties).EndInit();
			((System.ComponentModel.ISupportInitialize)Root).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItemRepoFolder).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItemMessages).EndInit();
			((System.ComponentModel.ISupportInitialize)splitterItem1).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
			((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemMarqueeProgressBar1).EndInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemProgressBar2).EndInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemProgressBar1).EndInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemTextEdit1).EndInit();
			((System.ComponentModel.ISupportInitialize)repositoryItemMemoEdit1).EndInit();
			ResumeLayout(false);
			PerformLayout();

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
        private DevExpress.XtraBars.BarStaticItem barStaticItemResult;
		private System.Windows.Forms.NumericUpDown numericUpDownAgeLimitCommitDays;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
	}
}
