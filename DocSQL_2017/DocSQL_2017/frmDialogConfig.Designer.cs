namespace DocSQL_2017
{
	partial class frmDialogConfig
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogConfig));
			this.layoutMain = new DocSQL_2017.mgLayoutControl();
			this.rdoMDB = new System.Windows.Forms.RadioButton();
			this.rdoACCDB = new System.Windows.Forms.RadioButton();
			this.txtTarget = new DocSQL_2017.mgDevX_ButtonEdit();
			this.txtSource = new DocSQL_2017.mgDevX_ButtonEdit();
			this.btnCancel = new DocSQL_2017.mgDevX_SimpleButton();
			this.btnSave = new DocSQL_2017.mgDevX_SimpleButton();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutSource = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutSourcePathSpacer = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutSourcePath = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutTargetPathSpacer = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutTargetPath = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.fbdMain = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.layoutMain)).BeginInit();
			this.layoutMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtTarget.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSource.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutSourcePathSpacer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutSourcePath)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutTargetPathSpacer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutTargetPath)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
			this.SuspendLayout();
			// 
			// ucGrLbl
			// 
			this.ucGrLbl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ucGrLbl.BackgroundImage")));
			this.ucGrLbl.Size = new System.Drawing.Size(461, 24);
			// 
			// layoutMain
			// 
			this.layoutMain.AllowCustomization = false;
			this.layoutMain.BackColor = System.Drawing.Color.White;
			this.layoutMain.Controls.Add(this.rdoMDB);
			this.layoutMain.Controls.Add(this.rdoACCDB);
			this.layoutMain.Controls.Add(this.txtTarget);
			this.layoutMain.Controls.Add(this.txtSource);
			this.layoutMain.Controls.Add(this.btnCancel);
			this.layoutMain.Controls.Add(this.btnSave);
			this.layoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutMain.Location = new System.Drawing.Point(0, 0);
			this.layoutMain.Name = "layoutMain";
			this.layoutMain.Root = this.layoutControlGroup1;
			this.layoutMain.Size = new System.Drawing.Size(483, 261);
			this.layoutMain.TabIndex = 1;
			this.layoutMain.Text = "mgLayoutControl1";
			// 
			// rdoMDB
			// 
			this.rdoMDB.Location = new System.Drawing.Point(216, 153);
			this.rdoMDB.Name = "rdoMDB";
			this.rdoMDB.Size = new System.Drawing.Size(262, 25);
			this.rdoMDB.TabIndex = 7;
			this.rdoMDB.Text = "MDB";
			this.rdoMDB.UseVisualStyleBackColor = true;
			// 
			// rdoACCDB
			// 
			this.rdoACCDB.Checked = true;
			this.rdoACCDB.Location = new System.Drawing.Point(73, 153);
			this.rdoACCDB.Name = "rdoACCDB";
			this.rdoACCDB.Size = new System.Drawing.Size(133, 25);
			this.rdoACCDB.TabIndex = 6;
			this.rdoACCDB.TabStop = true;
			this.rdoACCDB.Text = "ACCDB";
			this.rdoACCDB.UseVisualStyleBackColor = true;
			// 
			// txtTarget
			// 
			this.txtTarget.Location = new System.Drawing.Point(70, 88);
			this.txtTarget.Name = "txtTarget";
			this.txtTarget.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.txtTarget.Size = new System.Drawing.Size(408, 20);
			this.txtTarget.StyleController = this.layoutMain;
			this.txtTarget.TabIndex = 5;
			this.txtTarget.ButtonEllipsisClicked += new DocSQL_2017.mgDevX_ButtonEdit.ButtonEllipsisClickedEventHandler(this.txtTarget_ButtonEllipsisClicked);
			this.txtTarget.EditValueChanged += new System.EventHandler(this.txtTarget_EditValueChanged);
			// 
			// txtSource
			// 
			this.txtSource.Location = new System.Drawing.Point(70, 33);
			this.txtSource.Name = "txtSource";
			this.txtSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.txtSource.Size = new System.Drawing.Size(408, 20);
			this.txtSource.StyleController = this.layoutMain;
			this.txtSource.TabIndex = 5;
			this.txtSource.ButtonEllipsisClicked += new DocSQL_2017.mgDevX_ButtonEdit.ButtonEllipsisClickedEventHandler(this.txtSource_ButtonEllipsisClicked);
			this.txtSource.EditValueChanged += new System.EventHandler(this.txtSource_EditValueChanged);
			// 
			// btnCancel
			// 
			this.btnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.btnCancel.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(60)))));
			this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnCancel.Appearance.ForeColor = System.Drawing.Color.White;
			this.btnCancel.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.btnCancel.Appearance.Options.UseBackColor = true;
			this.btnCancel.Appearance.Options.UseFont = true;
			this.btnCancel.Appearance.Options.UseForeColor = true;
			this.btnCancel.ButtonColor = DocSQL_2017.mgButtonGUIButtonColor.Blue;
			this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.btnCancel.Location = new System.Drawing.Point(261, 236);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(171, 20);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "CANCEL";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.btnSave.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(60)))));
			this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnSave.Appearance.ForeColor = System.Drawing.Color.White;
			this.btnSave.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			this.btnSave.Appearance.Options.UseBackColor = true;
			this.btnSave.Appearance.Options.UseFont = true;
			this.btnSave.Appearance.Options.UseForeColor = true;
			this.btnSave.ButtonColor = DocSQL_2017.mgButtonGUIButtonColor.Blue;
			this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
			this.btnSave.Location = new System.Drawing.Point(52, 236);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(171, 20);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "SAVE";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutSource,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.layoutControlItem3,
            this.layoutSourcePathSpacer,
            this.layoutSourcePath,
            this.layoutTargetPathSpacer,
            this.layoutTargetPath,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem6,
            this.emptySpaceItem7});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			this.layoutControlGroup1.Size = new System.Drawing.Size(483, 261);
			this.layoutControlGroup1.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 183);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(483, 48);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// layoutSource
			// 
			this.layoutSource.Control = this.txtSource;
			this.layoutSource.Location = new System.Drawing.Point(0, 28);
			this.layoutSource.Name = "layoutSource";
			this.layoutSource.Size = new System.Drawing.Size(483, 30);
			this.layoutSource.Text = "Source Path:";
			this.layoutSource.TextSize = new System.Drawing.Size(62, 13);
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.txtTarget;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 83);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(483, 30);
			this.layoutControlItem2.Text = "Target Path:";
			this.layoutControlItem2.TextSize = new System.Drawing.Size(62, 13);
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.emptySpaceItem2.AppearanceItemCaption.Options.UseFont = true;
			this.emptySpaceItem2.AppearanceItemCaption.Options.UseTextOptions = true;
			this.emptySpaceItem2.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.emptySpaceItem2.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
			this.emptySpaceItem2.MaxSize = new System.Drawing.Size(467, 28);
			this.emptySpaceItem2.MinSize = new System.Drawing.Size(467, 28);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(483, 28);
			this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.emptySpaceItem2.Text = "Use the form below to enter the source and target paths for the copy.";
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(62, 0);
			this.emptySpaceItem2.TextVisible = true;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.btnSave;
			this.layoutControlItem1.Location = new System.Drawing.Point(47, 231);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(181, 30);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(0, 231);
			this.emptySpaceItem3.MaxSize = new System.Drawing.Size(47, 30);
			this.emptySpaceItem3.MinSize = new System.Drawing.Size(47, 30);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(47, 30);
			this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem4
			// 
			this.emptySpaceItem4.AllowHotTrack = false;
			this.emptySpaceItem4.Location = new System.Drawing.Point(228, 231);
			this.emptySpaceItem4.MaxSize = new System.Drawing.Size(28, 30);
			this.emptySpaceItem4.MinSize = new System.Drawing.Size(28, 30);
			this.emptySpaceItem4.Name = "emptySpaceItem4";
			this.emptySpaceItem4.Size = new System.Drawing.Size(28, 30);
			this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem5
			// 
			this.emptySpaceItem5.AllowHotTrack = false;
			this.emptySpaceItem5.Location = new System.Drawing.Point(437, 231);
			this.emptySpaceItem5.MaxSize = new System.Drawing.Size(46, 30);
			this.emptySpaceItem5.MinSize = new System.Drawing.Size(46, 30);
			this.emptySpaceItem5.Name = "emptySpaceItem5";
			this.emptySpaceItem5.Size = new System.Drawing.Size(46, 30);
			this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.btnCancel;
			this.layoutControlItem3.Location = new System.Drawing.Point(256, 231);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(181, 30);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// layoutSourcePathSpacer
			// 
			this.layoutSourcePathSpacer.AllowHotTrack = false;
			this.layoutSourcePathSpacer.Location = new System.Drawing.Point(0, 58);
			this.layoutSourcePathSpacer.Name = "layoutSourcePathSpacer";
			this.layoutSourcePathSpacer.Size = new System.Drawing.Size(68, 25);
			this.layoutSourcePathSpacer.TextSize = new System.Drawing.Size(0, 0);
			this.layoutSourcePathSpacer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
			// 
			// layoutSourcePath
			// 
			this.layoutSourcePath.AllowHotTrack = false;
			this.layoutSourcePath.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
			this.layoutSourcePath.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
			this.layoutSourcePath.AppearanceItemCaption.Options.UseFont = true;
			this.layoutSourcePath.AppearanceItemCaption.Options.UseForeColor = true;
			this.layoutSourcePath.Location = new System.Drawing.Point(68, 58);
			this.layoutSourcePath.MaxSize = new System.Drawing.Size(0, 25);
			this.layoutSourcePath.MinSize = new System.Drawing.Size(10, 25);
			this.layoutSourcePath.Name = "layoutSourcePath";
			this.layoutSourcePath.Size = new System.Drawing.Size(415, 25);
			this.layoutSourcePath.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutSourcePath.Text = "Path not valid.";
			this.layoutSourcePath.TextSize = new System.Drawing.Size(62, 0);
			this.layoutSourcePath.TextVisible = true;
			this.layoutSourcePath.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
			// 
			// layoutTargetPathSpacer
			// 
			this.layoutTargetPathSpacer.AllowHotTrack = false;
			this.layoutTargetPathSpacer.Location = new System.Drawing.Point(0, 113);
			this.layoutTargetPathSpacer.Name = "layoutTargetPathSpacer";
			this.layoutTargetPathSpacer.Size = new System.Drawing.Size(68, 25);
			this.layoutTargetPathSpacer.TextSize = new System.Drawing.Size(0, 0);
			this.layoutTargetPathSpacer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
			// 
			// layoutTargetPath
			// 
			this.layoutTargetPath.AllowHotTrack = false;
			this.layoutTargetPath.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
			this.layoutTargetPath.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
			this.layoutTargetPath.AppearanceItemCaption.Options.UseFont = true;
			this.layoutTargetPath.AppearanceItemCaption.Options.UseForeColor = true;
			this.layoutTargetPath.Location = new System.Drawing.Point(68, 113);
			this.layoutTargetPath.MaxSize = new System.Drawing.Size(0, 25);
			this.layoutTargetPath.MinSize = new System.Drawing.Size(10, 25);
			this.layoutTargetPath.Name = "layoutTargetPath";
			this.layoutTargetPath.Size = new System.Drawing.Size(415, 25);
			this.layoutTargetPath.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutTargetPath.Text = "Path not valid.";
			this.layoutTargetPath.TextSize = new System.Drawing.Size(62, 0);
			this.layoutTargetPath.TextVisible = true;
			this.layoutTargetPath.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.rdoACCDB;
			this.layoutControlItem4.Location = new System.Drawing.Point(68, 148);
			this.layoutControlItem4.MaxSize = new System.Drawing.Size(143, 35);
			this.layoutControlItem4.MinSize = new System.Drawing.Size(143, 35);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(143, 35);
			this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.rdoMDB;
			this.layoutControlItem5.Location = new System.Drawing.Point(211, 148);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(272, 35);
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// emptySpaceItem6
			// 
			this.emptySpaceItem6.AllowHotTrack = false;
			this.emptySpaceItem6.Location = new System.Drawing.Point(0, 138);
			this.emptySpaceItem6.MaxSize = new System.Drawing.Size(0, 10);
			this.emptySpaceItem6.MinSize = new System.Drawing.Size(10, 10);
			this.emptySpaceItem6.Name = "emptySpaceItem6";
			this.emptySpaceItem6.Size = new System.Drawing.Size(483, 10);
			this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem7
			// 
			this.emptySpaceItem7.AllowHotTrack = false;
			this.emptySpaceItem7.Location = new System.Drawing.Point(0, 148);
			this.emptySpaceItem7.MaxSize = new System.Drawing.Size(68, 35);
			this.emptySpaceItem7.MinSize = new System.Drawing.Size(68, 35);
			this.emptySpaceItem7.Name = "emptySpaceItem7";
			this.emptySpaceItem7.Size = new System.Drawing.Size(68, 35);
			this.emptySpaceItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
			// 
			// frmDialogConfig
			// 
			this.ClientSize = new System.Drawing.Size(483, 261);
			this.Controls.Add(this.layoutMain);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDialogConfig";
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = ":: Configuration ::";
			this.Load += new System.EventHandler(this.frmDialogConfig_Load);
			this.Controls.SetChildIndex(this.ucGrLbl, 0);
			this.Controls.SetChildIndex(this.layoutMain, 0);
			((System.ComponentModel.ISupportInitialize)(this.layoutMain)).EndInit();
			this.layoutMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtTarget.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSource.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutSourcePathSpacer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutSourcePath)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutTargetPathSpacer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutTargetPath)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private mgLayoutControl layoutMain;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private mgDevX_SimpleButton btnSave;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private mgDevX_ButtonEdit txtSource;
		private DevExpress.XtraLayout.LayoutControlItem layoutSource;
		private mgDevX_ButtonEdit txtTarget;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private mgDevX_SimpleButton btnCancel;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private System.Windows.Forms.FolderBrowserDialog fbdMain;
		private DevExpress.XtraLayout.EmptySpaceItem layoutSourcePathSpacer;
		private DevExpress.XtraLayout.EmptySpaceItem layoutSourcePath;
		private DevExpress.XtraLayout.EmptySpaceItem layoutTargetPathSpacer;
		private DevExpress.XtraLayout.EmptySpaceItem layoutTargetPath;
		private System.Windows.Forms.RadioButton rdoMDB;
		private System.Windows.Forms.RadioButton rdoACCDB;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
	}
}
