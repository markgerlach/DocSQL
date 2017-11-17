namespace DocSQL_2017
{
	partial class frmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.prgMain = new System.Windows.Forms.ProgressBar();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lst = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// prgMain
			// 
			this.prgMain.Location = new System.Drawing.Point(12, 137);
			this.prgMain.Name = "prgMain";
			this.prgMain.Size = new System.Drawing.Size(269, 23);
			this.prgMain.TabIndex = 1;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(11, 10);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(270, 121);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// lst
			// 
			this.lst.FormattingEnabled = true;
			this.lst.Location = new System.Drawing.Point(288, 13);
			this.lst.Name = "lst";
			this.lst.Size = new System.Drawing.Size(353, 147);
			this.lst.TabIndex = 2;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(653, 172);
			this.ControlBox = false;
			this.Controls.Add(this.lst);
			this.Controls.Add(this.prgMain);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.frmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ProgressBar prgMain;
		private System.Windows.Forms.ListBox lst;
	}
}

