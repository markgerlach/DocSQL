using DocSQL_2017.custom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DocSQL_2017
{
	public partial class frmDialogConfig : DocSQL_2017.frmDocSQLBase
	{
		public frmDocSQLBase ParentForm = null;

		public frmDialogConfig()
		{
			InitializeComponent();
		}

		private void frmDialogConfig_Load(object sender, EventArgs e)
		{
			// Don't close the form on escape
			this.CloseOnEscape = false;

			// Place the form
			this.Show();
			this.BringToFront();
			this.Location = new Point(this.ParentForm.Left + 50, this.ParentForm.Top + 100);
			Application.DoEvents();

			// When the form loads, get the paths from the configuration file if it exists
			txtSource.EditValue = null;
			txtTarget.EditValue = null;

			string source = ConfigFile.GetSourcePath();
			if (!source.ToLower().StartsWith("error:"))
			{
				txtSource.EditValue = source;
			}
			else
			{
				Error.DisplayCustomError(source);
			}
			string target = ConfigFile.GetTargetPath();
			if (!target.ToLower().StartsWith("error:"))
			{
				txtTarget.EditValue = target;
			}
			else
			{
				Error.DisplayCustomError(target);
			}

			if (txtTarget.EditValue == null)
			{
				txtTarget.EditValue = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
			}

			// Set up the dialog result
			this.DialogResult = DialogResult.None;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			// Check the validation on the form
			if (!LocationsValid())
			{
				// Show the user a message letting them know something's wrong
				Error.DisplayCustomError("At least one of the paths on the form isn't valid.");
				return;
			}
			else if (txtSource.EditValue.ToString().ToLower() == txtTarget.EditValue.ToString().ToLower())
			{
				Error.DisplayCustomError("The source and target paths cannot be the same.");
				return;
			}

			// Save the elements to the configuration file and close the form
			string err = string.Empty;
			string type = "ACCDB";
			if (rdoMDB.Checked) { type = "MDB"; }
			ConfigFile.WriteConfigFileContents(txtSource.EditValue.ToString(), txtTarget.EditValue.ToString(), type, ref err);
			if (!String.IsNullOrEmpty(err))
			{
				// Show the error
				Error.DisplayCustomError(err);
			}
			else
			{
				// Close the form
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			// Validate the files and send back a valid response
			if (LocationsValid())
			{
				this.DialogResult = DialogResult.OK;
			}
			else
			{
				this.DialogResult = DialogResult.Cancel;
			}
			this.Close();
		}

		/// <summary>
		/// Checks to see if the source path is valid
		/// </summary>
		/// <returns>True if valid, otherwise false</returns>
		private bool SourcePathValid()
		{
			bool rtv = true;

			if (txtSource.EditValue == null ||
				String.IsNullOrEmpty(txtSource.EditValue.ToString()))
			{
				return false;
			}

			string sourceDir = txtSource.EditValue.ToString();

			// Check the source
			if (!Directory.Exists(sourceDir)) { rtv = false; }

			return rtv;
		}

		/// <summary>
		/// Checks to see if the target path is valid
		/// </summary>
		/// <returns>True if valid, otherwise false</returns>
		private bool TargetPathValid()
		{
			bool rtv = true;

			if (txtTarget.EditValue == null ||
				String.IsNullOrEmpty(txtTarget.EditValue.ToString()))
			{
				return false;
			}

			string targetDir = txtTarget.EditValue.ToString();

			// Check the source
			if (!Directory.Exists(targetDir)) { rtv = false; }

			return rtv;
		}

		/// <summary>
		/// Check to see if the locations are valid
		/// </summary>
		/// <returns>True if valid, otherwise false</returns>
		private bool LocationsValid()
		{
			bool rtv = TargetPathValid() && SourcePathValid();
			return rtv;
		}

		private void txtSource_ButtonEllipsisClicked(object sender, ButtonEllipsisClicked_EventArgs e)
		{
			// Bring up the browse window to get a folder
			fbdMain.SelectedPath = (txtSource.EditValue != null && !String.IsNullOrEmpty(txtSource.EditValue.ToString()) ?
				txtSource.EditValue.ToString() : string.Empty);
			fbdMain.ShowNewFolderButton = false;
			fbdMain.Description = "Select Source Path";
			if (fbdMain.ShowDialog() == DialogResult.OK)
			{
				if (!Directory.Exists(fbdMain.SelectedPath))
				{
					MessageBox.Show("The path entered is not a valid path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				txtSource.EditValue = fbdMain.SelectedPath;
			}
		}

		private void txtTarget_ButtonEllipsisClicked(object sender, ButtonEllipsisClicked_EventArgs e)
		{
			// Bring up the browse window to get a folder
			fbdMain.SelectedPath = (txtTarget.EditValue != null && !String.IsNullOrEmpty(txtTarget.EditValue.ToString()) ?
				txtTarget.EditValue.ToString() : string.Empty);
			fbdMain.ShowNewFolderButton = false;
			fbdMain.Description = "Select Target Path";
			if (fbdMain.ShowDialog() == DialogResult.OK)
			{
				if (!Directory.Exists(fbdMain.SelectedPath))
				{
					MessageBox.Show("The path entered is not a valid path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				txtTarget.EditValue = fbdMain.SelectedPath;
			}
		}

		private void txtSource_EditValueChanged(object sender, EventArgs e)
		{
			// When the value changes, validate the path
			//btnSave.Enabled = false;
			if (SourcePathValid())
			{
				layoutSourcePathSpacer.Visibility = 
					layoutSourcePath.Visibility =
					DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
				//btnSave.Enabled = true;
			}
			else
			{
				layoutSourcePathSpacer.Visibility =
					layoutSourcePath.Visibility =
					DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
			}
		}

		private void txtTarget_EditValueChanged(object sender, EventArgs e)
		{
			// When the value changes, validate the path
			//btnSave.Enabled = false;
			if (TargetPathValid())
			{
				layoutTargetPathSpacer.Visibility =
					layoutTargetPath.Visibility =
					DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
				//btnSave.Enabled = true;
			}
			else
			{
				layoutTargetPathSpacer.Visibility =
					layoutTargetPath.Visibility =
					DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
			}
		}
	}
}
