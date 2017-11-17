namespace DocSQL_2017
{
	partial class frmMain_v2
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain_v2));
			this.layoutMain = new DocSQL_2017.mgLayoutControl();
			this.treeNav = new DocSQL_2017.mgDevX_TreeList();
			this.ribbonMain = new DocSQL_2017.mgDevX_RibbonControl();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.ilMain = new System.Windows.Forms.ImageList(this.components);
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutLeft = new DocSQL_2017.mgLayoutControl();
			this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutRight = new DocSQL_2017.mgLayoutControl();
			this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.ribbonStatus = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutMain)).BeginInit();
			this.layoutMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.treeNav)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutLeft)).BeginInit();
			this.layoutLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutRight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// ucGrLbl
			// 
			this.ucGrLbl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucGrLbl.BackgroundImage")));
			this.ucGrLbl.Size = new System.Drawing.Size(914, 24);
			// 
			// layoutMain
			// 
			this.layoutMain.AllowCustomization = false;
			this.layoutMain.BackColor = System.Drawing.Color.White;
			this.layoutMain.Controls.Add(this.ribbonStatus);
			this.layoutMain.Controls.Add(this.splitContainerControl1);
			this.layoutMain.Controls.Add(this.ribbonMain);
			this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutMain.Location = new System.Drawing.Point(0, 0);
			this.layoutMain.Name = "layoutMain";
			this.layoutMain.Root = this.layoutControlGroup1;
			this.layoutMain.Size = new System.Drawing.Size(1061, 428);
			this.layoutMain.TabIndex = 1;
			this.layoutMain.Text = "mgLayoutControl1";
			// 
			// treeNav
			// 
			this.treeNav.Location = new System.Drawing.Point(5, 5);
			this.treeNav.Name = "treeNav";
			this.treeNav.Size = new System.Drawing.Size(226, 230);
			this.treeNav.TabIndex = 11;
			// 
			// ribbonMain
			// 
			this.ribbonMain.Dock = System.Windows.Forms.DockStyle.None;
			this.ribbonMain.ExpandCollapseItem.Id = 0;
			this.ribbonMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMain.ExpandCollapseItem});
			this.ribbonMain.Location = new System.Drawing.Point(5, 5);
			this.ribbonMain.MaxItemId = 1;
			this.ribbonMain.Name = "ribbonMain";
			this.ribbonMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
			this.ribbonMain.Size = new System.Drawing.Size(1051, 116);
			this.ribbonMain.StatusBar = this.ribbonStatus;
			this.ribbonMain.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "ribbonPage1";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.Text = "ribbonPageGroup1";
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.simpleLabelItem1});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			this.layoutControlGroup1.Size = new System.Drawing.Size(1061, 428);
			this.layoutControlGroup1.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.ribbonMain;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 125);
			this.layoutControlItem1.MinSize = new System.Drawing.Size(110, 125);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(1061, 125);
			this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// ilMain
			// 
			this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
			this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
			this.ilMain.Images.SetKeyName(0, "check2.png");
			this.ilMain.Images.SetKeyName(1, "warning.png");
			this.ilMain.Images.SetKeyName(2, "delete2.png");
			this.ilMain.Images.SetKeyName(3, "Speedometer_Progress_01_16.png");
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Location = new System.Drawing.Point(5, 130);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.layoutLeft);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.layoutRight);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(1051, 240);
			this.splitContainerControl1.SplitterPosition = 236;
			this.splitContainerControl1.TabIndex = 13;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.splitContainerControl1;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 125);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(1061, 250);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// layoutLeft
			// 
			this.layoutLeft.AllowCustomization = false;
			this.layoutLeft.BackColor = System.Drawing.Color.White;
			this.layoutLeft.Controls.Add(this.treeNav);
			this.layoutLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutLeft.Location = new System.Drawing.Point(0, 0);
			this.layoutLeft.Name = "layoutLeft";
			this.layoutLeft.Root = this.layoutControlGroup2;
			this.layoutLeft.Size = new System.Drawing.Size(236, 240);
			this.layoutLeft.TabIndex = 0;
			this.layoutLeft.Text = "mgLayoutControl1";
			// 
			// layoutControlGroup2
			// 
			this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup2.GroupBordersVisible = false;
			this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
			this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup2.Name = "layoutControlGroup2";
			this.layoutControlGroup2.Size = new System.Drawing.Size(236, 240);
			this.layoutControlGroup2.TextVisible = false;
			// 
			// layoutRight
			// 
			this.layoutRight.AllowCustomization = false;
			this.layoutRight.BackColor = System.Drawing.Color.White;
			this.layoutRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutRight.Location = new System.Drawing.Point(0, 0);
			this.layoutRight.Name = "layoutRight";
			this.layoutRight.Root = this.layoutControlGroup3;
			this.layoutRight.Size = new System.Drawing.Size(810, 240);
			this.layoutRight.TabIndex = 0;
			this.layoutRight.Text = "mgLayoutControl2";
			// 
			// layoutControlGroup3
			// 
			this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup3.GroupBordersVisible = false;
			this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup3.Name = "layoutControlGroup3";
			this.layoutControlGroup3.Size = new System.Drawing.Size(810, 240);
			this.layoutControlGroup3.TextVisible = false;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.treeNav;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(236, 240);
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// ribbonStatus
			// 
			this.ribbonStatus.Dock = System.Windows.Forms.DockStyle.None;
			this.ribbonStatus.Location = new System.Drawing.Point(5, 373);
			this.ribbonStatus.Name = "ribbonStatus";
			this.ribbonStatus.Ribbon = this.ribbonMain;
			this.ribbonStatus.Size = new System.Drawing.Size(1051, 27);
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.ribbonStatus;
			this.layoutControlItem4.Location = new System.Drawing.Point(0, 375);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(1061, 30);
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// simpleLabelItem1
			// 
			this.simpleLabelItem1.AllowHotTrack = false;
			this.simpleLabelItem1.Location = new System.Drawing.Point(0, 405);
			this.simpleLabelItem1.Name = "simpleLabelItem1";
			this.simpleLabelItem1.Size = new System.Drawing.Size(1061, 23);
			this.simpleLabelItem1.TextSize = new System.Drawing.Size(107, 13);
			// 
			// frmMain_v2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1061, 428);
			this.ControlBox = false;
			this.Controls.Add(this.layoutMain);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMain_v2";
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = ":: Custom Reports Starter ::";
			this.Load += new System.EventHandler(this.frmMain_v2_Load);
			this.Controls.SetChildIndex(this.ucGrLbl, 0);
			this.Controls.SetChildIndex(this.layoutMain, 0);
			((System.ComponentModel.ISupportInitialize)(this.layoutMain)).EndInit();
			this.layoutMain.ResumeLayout(false);
			this.layoutMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.treeNav)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ribbonMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutLeft)).EndInit();
			this.layoutLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutRight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private mgLayoutControl layoutMain;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private System.Windows.Forms.ImageList ilMain;
		private mgDevX_TreeList treeNav;
		private mgDevX_RibbonControl ribbonMain;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private mgLayoutControl layoutLeft;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private mgLayoutControl layoutRight;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatus;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
	}
}