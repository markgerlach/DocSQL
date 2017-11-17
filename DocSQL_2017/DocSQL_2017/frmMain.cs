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
using Microsoft.Win32;

namespace DocSQL_2017
{
	public partial class frmMain : Form
	{
		private int _totalSteps = 10;
		private string _sourceDirectory = string.Empty, _targetDirectory = string.Empty;

		private string _configFileName = "_main.config";

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
			prgMain.Minimum = 0;
			prgMain.Maximum = (int)TotalFileSize;
			prgMain.Value = (int)TotalBytesTransferred;
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

		public frmMain()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Check to make sure the configuration file exists
		/// </summary>
		/// <returns>Boolean to denote if the file exists or not</returns>
		private bool ConfigFileExists()
		{
			bool rtv = File.Exists(Path.Combine(Application.StartupPath, _configFileName));
			return rtv;
		}

		/// <summary>
		/// Create the configuration file
		/// </summary>
		/// <returns>True if it was created successfully, otherwise false</returns>
		private bool CreateConfigFile()
		{
			bool rtv = false;

			try
			{

			}
			catch (Exception ex)
			{

			}

			return rtv;
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			// Present the form
			this.Show();
			lst.Items.Clear();
			prgMain.Value = 0;
			Application.DoEvents();

			// Run some checks
			// Check for the config file in the same running directory
			// If it doesn't exist, 
			bool configExists = ConfigFileExists();
			if (!configExists)
			{

			}

			// Check to make sure we can read from the remote path


			// Check to make sure we can write to the local target directory


			// Get the source directory
			_sourceDirectory = @"\\sherry\PMC2000\IAR_Release\";
			_targetDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);

			AddStatus("Source Directory: " + _sourceDirectory);
			AddStatus("Target Directory: " + _targetDirectory);

			// Turn off the code for VBA Warnings so we can start the program without incident
			if (System.Environment.MachineName.ToLower() != "programmer-ntbk" &&
				System.Environment.MachineName.ToLower() != "isspprog-12")
			{
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
													AddStatus("Adding VBAWarnings registry value.");
												}
												else
												{
													// Check to make sure the value of the key is "1"
													if (securityKey.GetValue("VBAWarnings").ToString() != "1")
													{
														securityKey.SetValue("VBAWarnings", 1, RegistryValueKind.DWord);
														AddStatus("Modifying VBAWarnings registry value.");
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
				}
				catch (Exception ex)
				{
					AddStatus("Could not set registry value.");
					//MessageBox.Show("Couldn't set registry values.",
					//	"Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}

			// Delete any files that might exist in the local directory
			List<string> list = Directory.GetFiles(_targetDirectory, "IAR_*.mdb").ToList<string>();
			list.Sort();
			int errorCount = 0;
			foreach (string s in list)
			{
				FileInfo info = new FileInfo(s);
				AddStatus("Attempt Delete Local File: " + info.Name);
				try
				{
					File.Delete(s);		// Delete the local file
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					errorCount++;
				}
				if (errorCount > 0) { break; }
			}
			if (errorCount > 0)
			{
				MessageBox.Show("Attempt to delete a file failed.  The program cannot start.", 
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			// Find the most recent file name
			int maxNum = 0;
			string lastFileName = string.Empty;
			foreach (string s in Directory.GetFiles(_sourceDirectory, "IAR_*.mdb"))
			{
				try
				{
					FileInfo info = new FileInfo(s);
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
			}
			string fileName = lastFileName; //"IAR_" + maxNum.ToString().PadLeft(6, '0') + ".mdb";
			AddStatus("Copying File: " + fileName);
			string remoteFileName = Path.Combine(_sourceDirectory, fileName);
			string localFileName = Path.Combine(_targetDirectory, fileName);

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

			// Start the file and terminate this application
			System.Diagnostics.Process.Start(localFileName);

			Application.Exit();
		}

		/// <summary>
		/// Add to the status window
		/// </summary>
		/// <param name="text">The text to add</param>
		private void AddStatus(string text)
		{
			lst.Items.Add(text);
			lst.SelectedIndex = lst.Items.Count - 1;
		}
	}
}
