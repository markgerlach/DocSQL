using DocSQL_2017.custom;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DocSQL_2017
{
	public partial class frmMain_v2 : frmDocSQLBase
	{
		private int _totalSteps = 10;
		private string _sourceDirectory = string.Empty, _targetDirectory = string.Empty;
		private bool _ACCDB = true;

		private System.Drawing.Color _topColor = System.Drawing.Color.LightGreen;
		private System.Drawing.Color _bottomColor = System.Drawing.Color.LightGreen;
		private System.Drawing.Color _textColor = System.Drawing.Color.Black;

		private BuildItemCollection _buildItemCollection = new BuildItemCollection();

		#region Copy File DLL's
		[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		static extern bool CopyFileEx(string lpExistingFileName, string lpNewFileName,
		   Callback lpProgressRoutine, IntPtr lpData, ref bool pbCancel,
		   CopyFileFlags dwCopyFlags);

		[Flags]
		enum CopyFileFlags : uint
		{
			COPY_FILE_FAIL_IF_EXISTS = 0x00000001,
			COPY_FILE_RESTARTABLE = 0x00000002,
			COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,
			COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008
		}

		private long Report(long TotalFileSize,
			long TotalBytesTransferred,
			long StreamSize,
			long StreamBytesTransferred,
			uint dwStreamNumber,
			uint dwCallbackReason,
			uint hSourceFile,
			uint hDestionationFile,
			uint lpData)
		{
			// Update the progress bar
			//prgMain.Minimum = 0;
			//prgMain.Maximum = (int)TotalFileSize;
			//prgMain.Value = (int)TotalBytesTransferred;
			int percentComplete = (int)(((decimal)TotalBytesTransferred / (decimal)TotalFileSize) * 100);
			//if (percentComplete > 50) { int test = 1;  }
			_buildItemCollection["CopyFromRemote"].UpdateMessage("Copying File...", percentComplete);
			//RefreshGrid();
			//gridStatus.Invalidate();
			//gridStatus.Refresh();
			//gridViewStatus.RefreshData();
			Application.DoEvents();
			return (false ? 2 : 0);
		}

		public delegate long Callback(
			long TotalFileSize,
			long TotalBytesTransferred,
			long StreamSize,
			long StreamBytesTransferred,
			uint dwStreamNumber,
			uint dwCallbackReason,
			uint hSourceFile,
			uint hDestionationFile,
			uint lpData
			);
		#endregion Copy File DLL's

		public frmMain_v2()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Post an error message to the screen
		/// </summary>
		/// <param name="msg">The message</param>
		private void PostError(string msg)
		{
			//txtErrorMsg.Text = msg;
			//layoutClose.Visibility =
			//	layoutErrMsg.Visibility =
			//	DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
		}

		/// <summary>
		/// Refresh the grid with the list of elements from the database
		/// </summary>
		private void RefreshGrid()
		{
			//if (gridStatus.DataSource == null)
			//{
			//	gridStatus.BeginUpdate();
			//	gridStatus.DataSource = null;
			//	gridStatus.DataSource = _buildItemCollection;
			//	Application.DoEvents();
			//	SetColumns();		// Set up the columns in the grid

			//	// Highlight the last row in the grid
			//	gridStatus.EndUpdate();
			//}
		}

		/// <summary>
		/// Set the columns on the grid
		/// </summary>
		private void SetColumns()
		{
			//foreach (DevExpress.XtraGrid.Columns.GridColumn col in gridViewStatus.Columns)
			//{
			//	switch (col.FieldName)
			//	{
			//		case "ItemIcon":
			//			col.VisibleIndex = 0;
			//			col.Caption = "";
			//			col.Width = 30;
			//			col.ImageAlignment = StringAlignment.Center;

			//			col.OptionsColumn.ShowCaption = false;
			//			break;
			//		case "FileName":
			//			col.VisibleIndex = 1;
			//			col.Width = 50;
			//			col.Caption = "Name";
			//			break;
			//		//case "Description":
			//		//	col.VisibleIndex = 2;
			//		//	col.Caption = "Status Message";
			//		//	//col.OptionsColumn.AllowEdit = false;
			//		//	break;
			//		case "PercentageComplete":
			//			col.VisibleIndex = 3;
			//			col.Caption = "% Complete";
			//			break;
			//		default:
			//			col.VisibleIndex = -1;
			//			break;
			//	}
			//}
			//Application.DoEvents();
		}

		/// <summary>
		/// Build the grid and it's associated collection
		/// </summary>
		private void BuildGrid()
		{
			_buildItemCollection = new BuildItemCollection();

			// Add the events
			_buildItemCollection.Add(new BuildItem("CheckConfig", "Checking Configuration...", new List<string>()));
			_buildItemCollection.Add(new BuildItem("ReadRemote", "Read from Remote Path...", new List<string>()));
			_buildItemCollection.Add(new BuildItem("WriteLocal", "Write to Local Path...", new List<string>()));

			_buildItemCollection.Add(new BuildItem("SourceDir", "Source Directory: ", new List<string>()));
			_buildItemCollection.Add(new BuildItem("TargetDir", "Target Directory: ", new List<string>()));
			_buildItemCollection.Add(new BuildItem("CheckVBA", "Check VBA Warnings... ", new List<string>()));

			_buildItemCollection.Add(new BuildItem("FindFileName", "Find remote file...", new List<string>()));
			_buildItemCollection.Add(new BuildItem("DeleteLocal", "Deleting Local Files...", new List<string>()));
			_buildItemCollection.Add(new BuildItem("CopyFromRemote", "Copy from Server...", new List<string>()));
			_buildItemCollection.Add(new BuildItem("StartApp", "Start Application...", new List<string>()));

			// Refresh the grid
			RefreshGrid();
		}

		private void gridViewStatus_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
		{
			//if (e.Column.FieldName == "ItemIcon")
			//{
			//	Image img = ilMain.Images[0];       // The success image
			//	int progress = int.Parse(gridViewStatus.GetRowCellValue(e.RowHandle, "PercentageComplete").ToString());
			//	if (e.CellValue.ToString().ToLower() == "error")
			//	{
			//		img = ilMain.Images[2];
			//	}
			//	else if (progress < 100)
			//	{
			//		img = ilMain.Images[3];
			//	}
			//	Rectangle r = e.Bounds;
			//	//e.Graphics.DrawImageUnscaled(img, (e.Bounds.Width - 16) / 2, 3, 16, 16);
			//	r = new Rectangle(((e.Bounds.Width - 16) / 2) + 18, e.Bounds.Y, 16, 16);
			//	e.Graphics.DrawImageUnscaled(img, r);
			//	e.Handled = true;
			//}
			//else if (e.Column.FieldName == "PercentageComplete")
			//{
			//	// Draw a custom progress bar
			//	int cellValue = int.Parse(e.CellValue.ToString());
			//	//if (cellValue > 0 && cellValue < 100) { int test = 1;  }
			//	Rectangle r = e.Bounds;
			//	Rectangle textRect = r;
			//	e.Cache.FillRectangle(new SolidBrush(Color.White), r);
			//	r.Inflate(-1, -1);
			//	decimal width = ((decimal)cellValue / (decimal)100) * r.Width;
			//	r.Width = (int)width;

			//	if (r.Width > 0)
			//	{
			//		Color topColor = _topColor;
			//		Color bottomColor = _bottomColor;
			//		System.Drawing.Drawing2D.LinearGradientBrush linearBrush =
			//			new System.Drawing.Drawing2D.LinearGradientBrush(r, topColor, bottomColor, System.Drawing.Drawing2D.LinearGradientMode.Vertical);

			//		e.Cache.FillRectangle(linearBrush, r);
			//	}

			//	Font f = new Font("Tahoma", 8F);
			//	Brush br = new SolidBrush(_textColor);
			//	StringFormat format = new StringFormat();
			//	format.Alignment = StringAlignment.Center;
			//	format.LineAlignment = StringAlignment.Center;
			//	format.FormatFlags = StringFormatFlags.NoWrap;
			//	format.Trimming = StringTrimming.None;

			//	//string text = gridViewStatus.GetRowCellValue(e.RowHandle, "Description").ToString();
			//	//if (text.ToLower().StartsWith("error"))
			//	//{
			//	//	f = new Font(f.Name, f.Size, FontStyle.Bold);
			//	//	br = new SolidBrush(Color.Red);
			//	//}
			//	//e.Cache.DrawString(text, f, br, textRect, format);

			//	e.Handled = true;
			//}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			// Shut down the application
			Application.Exit();
		}

		private void frmMain_v2_Load(object sender, EventArgs e)
		{
			// Dump out
			return;

			// Go through and copy the files
			//List<string> listF = Directory.GetFiles(@"D:\tmpTransfer\2017-03-19-iMaintTest\", "*.mdb").ToList();
			//string lPath = @"D:\tmpTransfer\2017-03-19-iMaintTest\";
			//int counter = listF.Count - 1;
			//string name1 = new FileInfo(listF[counter]).Name.Replace("IAR_", "").Replace(".mdb", "");
			//int index = int.Parse(name1);
			//name1 = "IAR_" + int.Parse(name1).ToString().PadLeft(7, '0') + ".mdb";
			//string origFileName = string.Empty;
			//while (index > 0)
			//{
			//	if (File.Exists(Path.Combine(lPath, name1)))
			//	{
			//		// The file exists - don't do anything
			//	}
			//	else
			//	{
			//		// Copy the file
			//		origFileName = listF[counter];
			//		File.Copy(origFileName, Path.Combine(lPath, name1));
			//	}
			//	index--;
			//	counter--;
			//	if (counter < 0) { counter = listF.Count - 1; }
			//	name1 = "IAR_" + index.ToString().PadLeft(7, '0') + ".mdb";
			//}
			//Application.Exit();


			// When the form loads, start the process
			// Present the form
			this.Show();
			//lst.Items.Clear();
			//prgMain.Value = 0;
			Application.DoEvents();

			// Build out the grid with the events/status
			BuildGrid();

			// Check to see if the shift key is down
			bool showConfigForm = false;
			//if ((ModifierKeys & Keys.Shift) != 0)
			//{
			//	// Show the configuration form
			//	showConfigForm = true;
			//}

			// Run some checks
			// Check for the config file in the same running directory
			// If it doesn't exist, 
			if (!ConfigFile.ConfigFileExists())
			{
				showConfigForm = true;
			}

			//if (showConfigForm)
			//{
			//	layoutMain.Enabled = false;
			//	frmDialogConfig frm = new frmDialogConfig();
			//	frm.ParentForm = this;
			//	if (frm.ShowDialog() == DialogResult.OK)
			//	{
			//		_sourceDirectory = ConfigFile.GetSourcePath();
			//		_targetDirectory = ConfigFile.GetTargetPath();
			//		_ACCDB = ConfigFile.GetType().ToLower().StartsWith("a");
			//	}
			//	else
			//	{
			//		// Shut down the application
			//		PostError("Configuration not valid.");
			//		_buildItemCollection["CheckConfig"].ItemIcon = BuildItemIcon.Error;
			//		gridViewStatus.RefreshData();
			//		layoutMain.Enabled = true;
			//		return;
			//	}
			//	layoutMain.Enabled = true;
			//}
			//else
			//{
			//	// Just get the values
			//	_sourceDirectory = ConfigFile.GetSourcePath();
			//	_targetDirectory = ConfigFile.GetTargetPath();
			//	_ACCDB = ConfigFile.GetType().ToLower().StartsWith("a");
			//}

			// Update the messages for config
			_buildItemCollection["CheckConfig"].UpdateMessage("Configuration Good.", 100);
			RefreshGrid();

			// Check to make sure we can read from the remote path
			string fileNamePrefix = string.Empty;
			try
			{
				List<string> listFiles = Directory.GetFiles(_sourceDirectory, "*.accdb").ToList<string>();
				if (!_ACCDB) { listFiles = Directory.GetFiles(_sourceDirectory, "*.mdb").ToList<string>(); }

				// Go through and get the file name prefix from the file (everything up until the first number)
				if (listFiles.Count > 0)
				{
					string tmpFileName = listFiles[0];
					for (int i = 0; i < tmpFileName.Length - 1; i++)
					{
						if (tmpFileName.Substring(i, 1).IndexOfAny("0123456789".ToCharArray()) > -1)
						{
							break;
						}
						else
						{
							fileNamePrefix += tmpFileName.Substring(i, 1);
						}
					}
				}
				_buildItemCollection["ReadRemote"].UpdateMessage("Remote Files Read.", 100);
				RefreshGrid();

				// Check to see how many files we have in the remote directory
				if (showConfigForm &&
					listFiles.Count > 250)
				{
					if (MessageBox.Show("There are more than 250 files on the remote server.  Large amounts " + 
						"of files can cause the program to run longer.\r\n\r\nDid you want this program to attempt " + 
						"deleting these files down to the most recent 50?\r\n\r\n(Please make sure you have a " + 
						"recent backup before continuing.)", "Large File Count",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
						MessageBoxDefaultButton.Button2) == DialogResult.Yes)
					{
						try
						{
							List<string> localList = Directory.GetFiles(_sourceDirectory, "*.accdb").ToList<string>();
							if (!_ACCDB) { localList = Directory.GetFiles(_sourceDirectory, "*.mdb").ToList<string>(); }
							localList.Sort();
							int loopCount = 0;
							for (int itemCount = localList.Count - 1; itemCount >= 0; itemCount--)
							{
								if (itemCount < 0) { break; } 
								localList.RemoveAt(itemCount);
								loopCount++;
								if (loopCount > 50) { break; }

								// Show a message to say that the delete worked
								MessageBox.Show("The system deleted the files.", "Successful Delete", 
									MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
						}
						catch (Exception ex)
						{
							// We weren't unable to delete the files - let the user know
							MessageBox.Show("The system was unable to delete these files.\r\n\r\n" + 
								"Please use another method to delete these files from the server.\r\n\r\n" + 
								"(Error: " + ex.Message + ")", "Unable to Delete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
				}
			}
			catch (Exception ex)
			{
				// Shut down the application
				PostError("Could not read from remote directory: \r\n" + _sourceDirectory);
				_buildItemCollection["ReadRemote"].ItemIcon = BuildItemIcon.Error;
				//gridViewStatus.RefreshData();
				return;
			}

			// Check to make sure we can write to the local target directory
			try
			{
				// Create a local file on the target directory and delete it
				string tempFile = Path.Combine(_targetDirectory, "tst.txt");
				TextWriter wt = File.AppendText(tempFile);
				TextWriter.Synchronized(wt);
				wt.WriteLine("Testing Write.");
				wt.Close();

				// Delete the file
				if (File.Exists(tempFile)) { File.Delete(tempFile); }

				_buildItemCollection["WriteLocal"].UpdateMessage("Local Write Complete.", 100);
				RefreshGrid();
			}
			catch (Exception ex)
			{
				// Shut down the application
				PostError("Could not write to local directory: " + _targetDirectory + "\r\n" + ex.Message);
				_buildItemCollection["WriteLocal"].ItemIcon = BuildItemIcon.Error;
				//gridViewStatus.RefreshData();
				return;
			}

			// Write the source and target directories
			_buildItemCollection["SourceDir"].UpdateMessage(_sourceDirectory, 100);
			_buildItemCollection["TargetDir"].UpdateMessage(_targetDirectory, 100);
			RefreshGrid();

			// Turn off the code for VBA Warnings so we can start the program without incident
			//if (System.Environment.MachineName.ToLower() != "programmer-ntbk" &&
			//	System.Environment.MachineName.ToLower() != "isspprog-12")
			//{
			try
			{
				bool vbaWarningsKeyExists = false;
				using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Office"))
				{
					foreach (string v in key.GetSubKeyNames())
					{
						if (v == "11.0" ||
							v == "12.0" ||
							v == "14.0")
						{
							// Try to open the access key
							using (RegistryKey verKey = key.OpenSubKey(v))
							{
								foreach (string accessKey in verKey.GetSubKeyNames())
								{
									if (accessKey.ToLower() == "access")
									{
										using (RegistryKey securityKey = verKey.OpenSubKey("Access\\Security", true))
										{
											vbaWarningsKeyExists = false;
											foreach (string val in securityKey.GetValueNames())
											{
												if (val == "VBAWarnings")
												{
													vbaWarningsKeyExists = true;
													break;
												}
											}
											if (!vbaWarningsKeyExists)
											{
												// Create the key
												securityKey.SetValue("VBAWarnings", 1, RegistryValueKind.DWord);
												//AddStatus("Adding VBAWarnings registry value.");
											}
											else
											{
												// Check to make sure the value of the key is "1"
												if (securityKey.GetValue("VBAWarnings").ToString() != "1")
												{
													securityKey.SetValue("VBAWarnings", 1, RegistryValueKind.DWord);
													//AddStatus("Modifying VBAWarnings registry value.");
												}
											}
										}
										break;
									}
								}
							}
						}
					}
				}
				_buildItemCollection["CheckVBA"].UpdateMessage("VBA Warning Set.", 100);
				RefreshGrid();
			}
			catch (Exception ex)
			{
				//AddStatus("Could not set registry value.");
			}
			//}

			// Find the target file name
			string remoteFileName = string.Empty, localFileName = string.Empty;
			try
			{
				_buildItemCollection["FindFileName"].UpdateMessage("Copying File...", 50);
				RefreshGrid();
				int maxNum = 0;
				string lastFileName = string.Empty;
				List<string> list = Directory.GetFiles(_sourceDirectory, "*.accdb").ToList<string>();
				if (!_ACCDB) { list = Directory.GetFiles(_sourceDirectory, "*.mdb").ToList<string>(); }
				StringBuilder sb = new StringBuilder();
				foreach (string s in list)
				{
					try
					{
						FileInfo info = new FileInfo(s);
						//string name = info.Name;
						string name = info.Name.Substring(info.Name.IndexOf("_") + 1);
						name = name.Substring(0, name.IndexOf("."));

						int num = int.Parse(name);
						if (num > maxNum)
						{
							maxNum = num;
							lastFileName = info.Name;
						}
					}
					catch
					{
						// Do nothing
					}
				}
				if (maxNum == 0)
				{
					MessageBox.Show("No file could be found to copy...",
						"Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Application.Exit();
					return;
				}
				string fileName = lastFileName; //"IAR_" + maxNum.ToString().PadLeft(6, '0') + ".mdb";
				remoteFileName = Path.Combine(_sourceDirectory, fileName);
				localFileName = Path.Combine(_targetDirectory, fileName);
			}
			catch (Exception ex)
			{
				PostError("Could not copy file: " + remoteFileName + "\r\n" + ex.Message);
				_buildItemCollection["FindFileName"].ItemIcon = BuildItemIcon.Error;
				//gridViewStatus.RefreshData();
				return;
			}
			_buildItemCollection["FindFileName"].UpdateMessage("Copy File Complete.", 100);

			// If the local file is the same as the remote file, and it already exists, just load it
			if (!String.IsNullOrEmpty(localFileName) &&
				File.Exists(localFileName))
			{
				System.Diagnostics.Process.Start(localFileName);
				Application.Exit();
				return;
			}

			// Delete any files that might exist in the local directory
			try
			{
				List<string> list = Directory.GetFiles(_targetDirectory, "*.accdb").ToList<string>();
				if (!_ACCDB) { list = Directory.GetFiles(_targetDirectory, "*.mdb").ToList<string>(); }
				list.Sort();
				foreach (string s in list)
				{
					FileInfo info = new FileInfo(s);
					File.Delete(s);     // Delete the local file
				}
				_buildItemCollection["DeleteLocal"].UpdateMessage("Local Files Deleted.", 100);
				RefreshGrid();
			}
			catch (Exception ex)
			{
				PostError("Could not delete local files: " + _targetDirectory + "\r\n" + ex.Message);
				_buildItemCollection["DeleteLocal"].ItemIcon = BuildItemIcon.Error;
				//gridViewStatus.RefreshData();
				return;
			}

			// Find the most recent file name
			remoteFileName = localFileName = string.Empty;
			try
			{
				_buildItemCollection["CopyFromRemote"].UpdateMessage("Copying File...", 1);
				RefreshGrid();
				int maxNum = 0;
				string lastFileName = string.Empty;
				List<string> list = Directory.GetFiles(_sourceDirectory, "*.accdb").ToList<string>();
				if (!_ACCDB) { list = Directory.GetFiles(_sourceDirectory, "*.mdb").ToList<string>(); }
				StringBuilder sb = new StringBuilder();
				foreach (string s in list)
				{
					try
					{
						FileInfo info = new FileInfo(s);
						//string name = info.Name;
						string name = info.Name.Substring(info.Name.IndexOf("_") + 1);
						name = name.Substring(0, name.IndexOf("."));

						int num = int.Parse(name);
						if (num > maxNum)
						{
							maxNum = num;
							lastFileName = info.Name;
						}
					}
					catch
					{
						// Do nothing
					}
				}
				if (maxNum == 0)
				{
					MessageBox.Show("No file could be found to copy...",
						"Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Application.Exit();
					return;
				}
				string fileName = lastFileName; //"IAR_" + maxNum.ToString().PadLeft(6, '0') + ".mdb";
				remoteFileName = Path.Combine(_sourceDirectory, fileName);
				localFileName = Path.Combine(_targetDirectory, fileName);

				// Copy the files over from the server
				Callback myCallback = new Callback(Report);

				bool cancel = false;
				bool ret = CopyFileEx(
					remoteFileName,
					localFileName,
					myCallback,
					System.IntPtr.Zero,
					ref cancel,
					CopyFileFlags.COPY_FILE_FAIL_IF_EXISTS);
			}
			catch (Exception ex)
			{
				PostError("Could not copy file: " + remoteFileName + "\r\n" + ex.Message);
				_buildItemCollection["CopyFromRemote"].ItemIcon = BuildItemIcon.Error;
				//gridViewStatus.RefreshData();
				return;
			}
			_buildItemCollection["CopyFromRemote"].UpdateMessage("Copy File Complete.", 100);

			_buildItemCollection["StartApp"].UpdateMessage("Starting Application.", 50);
			RefreshGrid();
			this.BringToFront();
			Application.DoEvents();
			//System.Threading.Thread.Sleep(5000);

			// Start the file and terminate this application
			System.Diagnostics.Process.Start(localFileName);

			Application.Exit();
		}
	}

	public class BuildItem
	{
		private string _itemKey = string.Empty;
		private string _description = string.Empty;
		private BuildItemIcon _itemIcon = BuildItemIcon.Success;
		private int _percentageComplete = 0;
		private string _completedFileContents = string.Empty;
		private string _fileName = string.Empty;
		private string _csharpFileName = string.Empty;
		private List<string> _selectedFiles = new List<string>();
		private BackgroundWorker _bw = null;

		public BuildItem(string itemKey,
			string desc,
			string fileName,
			List<string> selectedFiles)
		{
			_itemKey = itemKey;
			_description = desc;
			_fileName = fileName;
			_selectedFiles = selectedFiles;
		}

		public BuildItem(string itemKey,
			string fileName,
			List<string> selectedFiles)
		{
			_itemKey = itemKey;
			_fileName = fileName;
			_selectedFiles = selectedFiles;
		}

		public BuildItem()
		{
		}

		public string ItemKey
		{
			get { return _itemKey; }
			set { _itemKey = value; }
		}

		public BackgroundWorker Worker
		{
			get { return _bw; }
			set { _bw = value; }
		}

		public string FileName
		{
			get { return _fileName; }
			set { _fileName = value; }
		}

		public string CSharpFileName
		{
			get { return _csharpFileName; }
			set { _csharpFileName = value; }
		}

		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		public string CompletedFileContents
		{
			get { return _completedFileContents; }
			set { _completedFileContents = value; }
		}

		public List<string> SelectedFiles
		{
			get { return _selectedFiles; }
			set { _selectedFiles = value; }
		}

		public BuildItemIcon ItemIcon
		{
			get { return _itemIcon; }
			set { _itemIcon = value; }
		}

		public int PercentageComplete
		{
			get { return _percentageComplete; }
			set
			{
				bool throwEvent = (_percentageComplete != value);
				_percentageComplete = value;
				this.OnBuildItemPercentageCompleteChanged(this);
			}
		}

		/// <summary>
		/// Update the message in the system
		/// </summary>
		/// <param name="desc">The description to write in there</param>
		/// <param name="percentageComplete">The percentage complete</param>
		public void UpdateMessage(string desc, int percentageComplete)
		{
			this.Description = desc;
			this.PercentageComplete = percentageComplete;
		}

		public delegate void BuildItemPercentageCompleteChangedEventHandler(object sender, ProjectItemBuiltEventArgs e);
		public event BuildItemPercentageCompleteChangedEventHandler BuildItemPercentageComplete;
		protected void OnBuildItemPercentageCompleteChanged(BuildItem buildItem)
		{
			if (BuildItemPercentageComplete != null)
			{
				ProjectItemBuiltEventArgs e = new ProjectItemBuiltEventArgs(buildItem);
				BuildItemPercentageComplete(this, e);
			}
		}
	}

	public class BuildItemCollection : BindingList<BuildItem>
	{
		public BuildItemCollection()
		{
		}

		/// <summary>
		/// Return a value from the collection based on the one in here
		/// </summary>
		/// <param name="itemKey">The item key to find</param>
		/// <returns>The Build Item</returns>
		public BuildItem this[string itemKey]
		{
			get
			{
				BuildItem item = null;
				foreach (BuildItem i in this)
				{
					if (i.ItemKey.ToLower().Equals(itemKey.ToLower()))
					{
						item = i;
						break;
					}
				}
				return item;
			}
		}
	}

	public enum BuildItemIcon : int
	{
		Success = 0,
		Error,
		Warning,
		Building,
	}
}
