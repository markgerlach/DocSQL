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
			this.btnClose = new DocSQL_2017.mgDevX_SimpleButton();
			this.txtErrorMsg = new DocSQL_2017.mgDevX_MemoEdit();
			this.gridStatus = new DocSQL_2017.mgDevX_GridControl();
			this.gridViewStatus = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutGrid = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutErrMsg = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutClose = new DevExpress.XtraLayout.LayoutControlItem();
			this.ilMain = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.layoutMain)).BeginInit();
			this.layoutMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtErrorMsg.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridStatus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewStatus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutErrMsg)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutClose)).BeginInit();
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
			this.layoutMain.Controls.Add(this.btnClose);
			this.layoutMain.Controls.Add(this.txtErrorMsg);
			this.layoutMain.Controls.Add(this.gridStatus);
			this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutMain.Location = new System.Drawing.Point(0, 0);
			this.layoutMain.Name = "layoutMain";
			this.layoutMain.Root = this.layoutControlGroup1;
			this.layoutMain.Size = new System.Drawing.Size(1061, 428);
			this.layoutMain.TabIndex = 1;
			this.layoutMain.Text = "mgLayoutControl1";
			// 
			// btnClose
			// 
			this.btnClose.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.btnClose.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(60)))));
			this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
			this.btnClose.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.btnClose.Appearance.Options.UseBackColor = true;
			this.btnClose.Appearance.Options.UseFont = true;
			this.btnClose.Appearance.Options.UseForeColor = true;
			this.btnClose.ButtonColor = DocSQL_2017.mgButtonGUIButtonColor.Blue;
			this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.btnClose.Location = new System.Drawing.Point(152, 403);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(758, 20);
			this.btnClose.TabIndex = 10;
			this.btnClose.Text = "CLOSE";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// txtErrorMsg
			// 
			this.txtErrorMsg.Location = new System.Drawing.Point(5, 327);
			this.txtErrorMsg.Name = "txtErrorMsg";
			this.txtErrorMsg.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.txtErrorMsg.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
			this.txtErrorMsg.Properties.Appearance.Options.UseFont = true;
			this.txtErrorMsg.Properties.Appearance.Options.UseForeColor = true;
			this.txtErrorMsg.Size = new System.Drawing.Size(1051, 66);
			this.txtErrorMsg.StyleController = this.layoutMain;
			this.txtErrorMsg.TabIndex = 9;
			// 
			// gridStatus
			// 
			this.gridStatus.CheckUncheckByClickingColumnHeader = true;
			this.gridStatus.Location = new System.Drawing.Point(5, 5);
			this.gridStatus.MainView = this.gridViewStatus;
			this.gridStatus.Name = "gridStatus";
			this.gridStatus.ShowDetailButtons = false;
			this.gridStatus.ShowOnlyPredefinedDetails = true;
			this.gridStatus.Size = new System.Drawing.Size(1051, 312);
			this.gridStatus.TabIndex = 7;
			this.gridStatus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewStatus});
			// 
			// gridViewStatus
			// 
			this.gridViewStatus.GridControl = this.gridStatus;
			this.gridViewStatus.Name = "gridViewStatus";
			this.gridViewStatus.OptionsCustomization.AllowGroup = false;
			this.gridViewStatus.OptionsDetail.ShowDetailTabs = false;
			this.gridViewStatus.OptionsView.ShowDetailButtons = false;
			this.gridViewStatus.OptionsView.ShowGroupPanel = false;
			this.gridViewStatus.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridViewStatus_CustomDrawCell);
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutGrid,
            this.layoutErrMsg,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.layoutClose});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			this.layoutControlGroup1.Size = new System.Drawing.Size(1061, 428);
			this.layoutControlGroup1.TextVisible = false;
			// 
			// layoutGrid
			// 
			this.layoutGrid.Control = this.gridStatus;
			this.layoutGrid.Location = new System.Drawing.Point(0, 0);
			this.layoutGrid.Name = "layoutGrid";
			this.layoutGrid.Size = new System.Drawing.Size(1061, 322);
			this.layoutGrid.TextSize = new System.Drawing.Size(0, 0);
			this.layoutGrid.TextVisible = false;
			// 
			// layoutErrMsg
			// 
			this.layoutErrMsg.Control = this.txtErrorMsg;
			this.layoutErrMsg.Location = new System.Drawing.Point(0, 322);
			this.layoutErrMsg.MaxSize = new System.Drawing.Size(0, 76);
			this.layoutErrMsg.MinSize = new System.Drawing.Size(20, 76);
			this.layoutErrMsg.Name = "layoutErrMsg";
			this.layoutErrMsg.Size = new System.Drawing.Size(1061, 76);
			this.layoutErrMsg.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutErrMsg.TextSize = new System.Drawing.Size(0, 0);
			this.layoutErrMsg.TextVisible = false;
			this.layoutErrMsg.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(0, 398);
			this.emptySpaceItem2.MaxSize = new System.Drawing.Size(147, 30);
			this.emptySpaceItem2.MinSize = new System.Drawing.Size(147, 30);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(147, 30);
			this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(915, 398);
			this.emptySpaceItem1.MaxSize = new System.Drawing.Size(146, 30);
			this.emptySpaceItem1.MinSize = new System.Drawing.Size(146, 30);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(146, 30);
			this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// layoutClose
			// 
			this.layoutClose.Control = this.btnClose;
			this.layoutClose.Location = new System.Drawing.Point(147, 398);
			this.layoutClose.MaxSize = new System.Drawing.Size(0, 30);
			this.layoutClose.MinSize = new System.Drawing.Size(53, 30);
			this.layoutClose.Name = "layoutClose";
			this.layoutClose.Size = new System.Drawing.Size(768, 30);
			this.layoutClose.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutClose.TextSize = new System.Drawing.Size(0, 0);
			this.layoutClose.TextVisible = false;
			this.layoutClose.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
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
			((System.ComponentModel.ISupportInitialize)(this.txtErrorMsg.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridStatus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridViewStatus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutErrMsg)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutClose)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private mgLayoutControl layoutMain;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private mgDevX_GridControl gridStatus;
		private DevExpress.XtraGrid.Views.Grid.GridView gridViewStatus;
		private DevExpress.XtraLayout.LayoutControlItem layoutGrid;
		private mgDevX_MemoEdit txtErrorMsg;
		private DevExpress.XtraLayout.LayoutControlItem layoutErrMsg;
		private System.Windows.Forms.ImageList ilMain;
		private mgDevX_SimpleButton btnClose;
		private DevExpress.XtraLayout.LayoutControlItem layoutClose;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
	}
}