namespace WingetRepoBrowser
{
	partial class NewDownloadsForm
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
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
			this.simpleButtonDownload = new DevExpress.XtraEditors.SimpleButton();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.ColName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colVersion = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItemDownload = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
			this.layoutControlItemCancel = new DevExpress.XtraLayout.LayoutControlItem();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDownload)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItemCancel)).BeginInit();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.simpleButtonCancel);
			this.layoutControl1.Controls.Add(this.memoEdit1);
			this.layoutControl1.Controls.Add(this.simpleButtonDownload);
			this.layoutControl1.Controls.Add(this.gridControl1);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(4676, 600, 650, 400);
			this.layoutControl1.Root = this.Root;
			this.layoutControl1.Size = new System.Drawing.Size(588, 413);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.Location = new System.Drawing.Point(296, 201);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.Size = new System.Drawing.Size(280, 22);
			this.simpleButtonCancel.StyleController = this.layoutControl1;
			this.simpleButtonCancel.TabIndex = 7;
			this.simpleButtonCancel.Text = "Cancel";
			this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
			// 
			// memoEdit1
			// 
			this.memoEdit1.Location = new System.Drawing.Point(12, 243);
			this.memoEdit1.Name = "memoEdit1";
			this.memoEdit1.Size = new System.Drawing.Size(564, 158);
			this.memoEdit1.StyleController = this.layoutControl1;
			this.memoEdit1.TabIndex = 6;
			// 
			// simpleButtonDownload
			// 
			this.simpleButtonDownload.Location = new System.Drawing.Point(12, 201);
			this.simpleButtonDownload.Name = "simpleButtonDownload";
			this.simpleButtonDownload.Size = new System.Drawing.Size(280, 22);
			this.simpleButtonDownload.StyleController = this.layoutControl1;
			this.simpleButtonDownload.TabIndex = 5;
			this.simpleButtonDownload.Text = "Download";
			this.simpleButtonDownload.Click += new System.EventHandler(this.simpleButtonDownload_Click);
			// 
			// gridControl1
			// 
			this.gridControl1.Location = new System.Drawing.Point(12, 12);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(564, 180);
			this.gridControl1.TabIndex = 4;
			this.gridControl1.UseEmbeddedNavigator = true;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColName,
            this.colVersion,
            this.colId});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsSelection.MultiSelect = true;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			// 
			// ColName
			// 
			this.ColName.FieldName = "PackageName";
			this.ColName.Name = "ColName";
			this.ColName.Visible = true;
			this.ColName.VisibleIndex = 0;
			this.ColName.Width = 198;
			// 
			// colVersion
			// 
			this.colVersion.FieldName = "PackageVersion";
			this.colVersion.Name = "colVersion";
			this.colVersion.Visible = true;
			this.colVersion.VisibleIndex = 1;
			this.colVersion.Width = 129;
			// 
			// colId
			// 
			this.colId.FieldName = "PackageIdentifier";
			this.colId.Name = "colId";
			this.colId.Visible = true;
			this.colId.VisibleIndex = 2;
			this.colId.Width = 131;
			// 
			// Root
			// 
			this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.Root.GroupBordersVisible = false;
			this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItemDownload,
            this.layoutControlItem3,
            this.splitterItem1,
            this.layoutControlItemCancel});
			this.Root.Name = "Root";
			this.Root.Size = new System.Drawing.Size(588, 413);
			this.Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.gridControl1;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(568, 184);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// layoutControlItemDownload
			// 
			this.layoutControlItemDownload.Control = this.simpleButtonDownload;
			this.layoutControlItemDownload.Location = new System.Drawing.Point(0, 189);
			this.layoutControlItemDownload.Name = "layoutControlItemDownload";
			this.layoutControlItemDownload.Size = new System.Drawing.Size(284, 26);
			this.layoutControlItemDownload.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItemDownload.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.memoEdit1;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 215);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(568, 178);
			this.layoutControlItem3.Text = "Log";
			this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
			this.layoutControlItem3.TextSize = new System.Drawing.Size(17, 13);
			// 
			// splitterItem1
			// 
			this.splitterItem1.AllowHotTrack = true;
			this.splitterItem1.Location = new System.Drawing.Point(0, 184);
			this.splitterItem1.Name = "splitterItem1";
			this.splitterItem1.Size = new System.Drawing.Size(568, 5);
			// 
			// layoutControlItemCancel
			// 
			this.layoutControlItemCancel.Control = this.simpleButtonCancel;
			this.layoutControlItemCancel.Location = new System.Drawing.Point(284, 189);
			this.layoutControlItemCancel.Name = "layoutControlItemCancel";
			this.layoutControlItemCancel.Size = new System.Drawing.Size(284, 26);
			this.layoutControlItemCancel.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItemCancel.TextVisible = false;
			this.layoutControlItemCancel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// NewDownloadsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(588, 413);
			this.Controls.Add(this.layoutControl1);
			this.Name = "NewDownloadsForm";
			this.Text = "WingetRepoBrowser New Downloads";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewDownloadsForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDownload)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItemCancel)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private DevExpress.XtraEditors.MemoEdit memoEdit1;
		private DevExpress.XtraEditors.SimpleButton simpleButtonDownload;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItemDownload;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.SplitterItem splitterItem1;
		private DevExpress.XtraGrid.Columns.GridColumn ColName;
		private DevExpress.XtraGrid.Columns.GridColumn colVersion;
		private DevExpress.XtraGrid.Columns.GridColumn colId;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItemCancel;
	}
}