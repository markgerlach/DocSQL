using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;

using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;

using DocSQL_2017.Model;

namespace DocSQL_2017
{
	public class UserInterface
	{
		public static System.Windows.Forms.Form MainMDIForm = null;
		//public static ScreenSecurityElementCollection ScreenSecurityElements = new ScreenSecurityElementCollection();
		public static bool UseSystemAsAdminSystem = false;		// Pay attention to the AdminSystems code in each form - set at login
		public static string GemBoxLicenseString = "EIKT-XYMG-Y70R-IBYV";		// This is the 3.1 Key
		//public static string GemBoxLicenseString = "ESWL-1QO1-26HG-JYUB";		// This is the 3.3 Key

		public static bool AppEntry_AllowNavBack = false;
		public static System.Windows.Forms.Form AppEntry_MainForm = null;
		
		//private static Dictionary<string, QuickViewCollection> QuickViewCollection = new Dictionary<string, QuickViewCollection>();

		public static string LastAttachmentPath = string.Empty;		// The last attachment path that was pulled up in the app

		public static int ClientAreaWidth = 0;
		public static int ClientAreaHeight = 0;

		public static string TempDirectoryName = "temp";

		public static System.Diagnostics.Process HelpProcess = null;

		//public static forms.dialogs.frmProgress _frm = null;

		private static Dictionary<ScreenObjectFormType, string> _screenKeys = new Dictionary<ScreenObjectFormType,string>();

		//public static DocSQL_2017.classes.DigitalSignage.AdminClient DigitalSignageClient = null;
		//public static string DigitalSignageServerIP = SystemSetting.GetSingleStringValue("DigitalSignageServer");


		//public static List<string> AppEntryProgramArgs = new List<string>();

		/// <summary>
		/// Gets the default application icon for the project
		/// </summary>
		/// <returns>The default Icon that the application will use</returns>
		public static Icon GetDefaultApplicationIcon()
		{
			try
			{
				//return null;
				//return global::DocSQL_2017.resIcon.DocSQLLogo_Base_120x120_Blue;
				return global::DocSQL_2017.resIcon.folder_copy;
				//return global::DocSQL_2017.resIcon.iMaint_1;
				//FileInfo info = new FileInfo(Assembly.GetExecutingAssembly().Location);
				//string filePath = info.DirectoryName;
				//Assembly assy = Assembly.LoadFile(filePath + @"\mwsCommon.dll");

				//Bitmap bmp = new Bitmap(Image.FromStream(assy.GetManifestResourceStream("mwsCommon.images.icons.App.ico")));
				//Icon ico = Icon.FromHandle(bmp.GetHicon());
				//bmp.Dispose();
				//return ico;
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// Get the machine name
		/// </summary>
		public static string MachineName
		{
			get { return System.Environment.MachineName; }
		}

		/// <summary>
		/// Get the company image 
		/// </summary>
		/// <returns>The company image</returns>
		public static System.Drawing.Image GetCompanyImage()
		{
			//return ResLibrary.resFull.RippleLogo_25;
			return null;
		}

		/// <summary>
		/// Get the company name
		/// </summary>
		/// <returns>The company's name</returns>
		public static string GetCompanyName()
		{
			return "AA Jewel Box";
		}

		public static string CurrentTimeFormat = string.Empty;
		public static string CurrentDateFormat = string.Empty;

		/// <summary>
		/// Get the current time format from a system preference
		/// </summary>
		/// <returns>The time format as a string</returns>
		public static string GetTimeFormatAsString()
		{
			if (String.IsNullOrEmpty(UserInterface.CurrentTimeFormat))
			{
				UserInterface.CurrentTimeFormat = "hh:mm tt";
			}

			return UserInterface.CurrentTimeFormat;
		}

		/// <summary>
		/// Get the current date format from a system preference
		/// </summary>
		/// <returns>The date format as a string</returns>
		public static string GetDateFormatAsString()
		{
			if (String.IsNullOrEmpty(UserInterface.CurrentDateFormat))
			{
				UserInterface.CurrentDateFormat = "MM/dd/yyyy";
			}

			return UserInterface.CurrentDateFormat;
		}

		/// <summary>
		/// Get the current date and time format from a system preference
		/// </summary>
		/// <returns>The date and time format as a string</returns>
		public static string GetDateAndTimeFormatAsString()
		{
			return GetDateFormatAsString() + " " + GetTimeFormatAsString();
		}

		/// <summary>
		/// Sorts a datatable and returns the sorted datatable
		/// </summary>
		/// <param name="dt">The datatable to sort</param>
		/// <param name="sortString">The string to use as a sort - use SQL syntax</param>
		/// <returns>The sorted datatable</returns>
		public static DataTable SortDataTable(DataTable dt, string sortString)
		{
			dt.TableName = dt.TableName.Replace("_Copy", "");
			DataTable dtOutput = new DataTable(dt.TableName + "_Copy");
			foreach (DataColumn col in dt.Columns)
			{
				dtOutput.Columns.Add(col.ColumnName, col.DataType, col.Expression);
			}

			// Now that you have the structure
			DataRow[] rows = dt.Select(string.Empty, sortString);
			for (int i = 0; i < rows.Length; i++)
			{
				dtOutput.ImportRow(rows[i]);
			}

			// Return the datatable
			return dtOutput;
		}

		/// <summary>
		/// Copy the passed data table to a new datatable
		/// </summary>
		public static DataTable CopyDataTable(DataTable dt)
		{
			return SortDataTable(dt, string.Empty);		// Return from the sort method
		}

		/// <summary>
		/// Reset the ribbon control security based on the user that's loading the screen
		/// </summary>
		/// <param name="ribbon">The instance of the ribbon control to update</param>
		/// <param name="keyedCollection">The Keyed Collection of button names in the ribbon 
		///		control, and their corresponding screen entries in the SecObjects table</param>
		public static void ResetRibbonControlSecurity(mgDevX_RibbonControl ribbon,
			Dictionary<string, string> keyedCollection)
		{
			try
			{
				// Get a collection of screen objects in the database
				DataTable dtScreen = null; // Security.AggregateScreens();

				// Get the collection of buttons in the listing
				mgDevX_RibbonControl.mgDevX_RibbonControlBarItemCollection buttonArray =
					ribbon.GetBarButtonItems();
				foreach (KeyValuePair<string, string> kvp in keyedCollection)
				{
					// Go through the collection of sec objects
					foreach (DataRow row in dtScreen.Rows)
					{
						if (kvp.Key.ToLower() == row["sObjectKey"].ToString().ToLower() &&
							((int)row["iAccessLevel"] == 0 ||
							(int)row["iAccessLevel"] == 5))
						{
							// Go through the ribbon and kill off the control
							foreach (mgDevX_RibbonControl.mgDevX_RibbonControlBarItem item in buttonArray)
							{
								if (item.BarItemLink.Item.Name.ToLower() == kvp.Value.ToLower())
								{
									//item.BarItemLink.Visible = false;
									if (item.BarItemLink.Item is BarButtonItem)
									{
										((BarButtonItem)item.BarItemLink.Item).Visibility = BarItemVisibility.Never;
									}
									else
									{
										item.BarItemLink.Visible = false;
									}
									//item.PageGroup.ItemLinks.Remove(item.BarItemLink);
									//break;
								}
							}
						}
					}
				}

				// Go through the controls in the ribbon and reset groups/categories
				int visibleCount = 0, pageVisibleCount = 0;
				bool groupIsPrintGroup = false;
				foreach (RibbonPage page in ribbon.Pages)
				{
					pageVisibleCount = 0;
					foreach (RibbonPageGroup group in page.Groups)
					{
						visibleCount = 0; groupIsPrintGroup = false;
						for (int i = 0; i < group.ItemLinks.Count; i++)
						{
							if (group.ItemLinks[i].Item.Name.StartsWith("btnPrint") ||
								group.ItemLinks[i].Item.Name.StartsWith("btnPreview"))
							{ groupIsPrintGroup = true; }

							if (//group.ItemLinks[i].Visible &&
								group.ItemLinks[i].Item is BarButtonItem &&
								((BarButtonItem)group.ItemLinks[i].Item).Visibility == BarItemVisibility.Always &&
								!group.ItemLinks[i].Item.Name.StartsWith("btnPrint") &&
								!group.ItemLinks[i].Item.Name.StartsWith("btnPreview") &&
								!group.ItemLinks[i].Item.Name.StartsWith("btnRun") &&
								!group.ItemLinks[i].Item.Name.Equals("btnCopyChart") &&
								!group.ItemLinks[i].Item.Name.Equals("btnSaveChart"))
							{
								visibleCount++;
								pageVisibleCount++;
							}
						}
						if (visibleCount == 0 && !groupIsPrintGroup)
						{
							// Hide the group
							group.Visible = false;
						}
					}
					if (pageVisibleCount == 0)
					{
						foreach (RibbonPageGroup group in page.Groups)
						{
							group.Visible = false;
						}
						page.Visible = false;
					}
				}
			}
			catch (Exception ex)
			{

			}
		}

		/// <summary>
		/// Size the image and keep its aspect ratio in tact
		/// Either a height or width is passed in to use as a max level
		/// </summary>
		public static Image SizeImageKeepAspectRatio(Image img,
			int? width, int? height)
		{
			int newWidth = 0, newHeight = 0;
			if (img == null) { return img; }

			// Check to make sure they didn't pass in both
			if (width != null &&
				height != null)
			{
				throw new Exception("You can't pass in both Height and Width to this method...");
				return null;
			}

			Bitmap bmp = new Bitmap(img);

			// Check the width
			if (width != null)
			{
				newWidth = width.Value;
				newHeight = (int)(((decimal)newWidth * (decimal)bmp.Height) / (decimal)bmp.Width);
			}

			// Check the height
			if (height != null)
			{
				newHeight = height.Value;
				newWidth = (int)(((decimal)newHeight * (decimal)bmp.Width) / (decimal)bmp.Height);
			}

			Image returnImage = new Bitmap(img, newWidth, newHeight);
			return returnImage;		// Return the image
		}

		/// <summary>
		/// Add to the status box
		/// </summary>
		/// <param name="lst">The list box to add the status to</param>
		/// <param name="status">The string to add</param>
		public static void AddStatus(DevExpress.XtraEditors.ListBoxControl lst, string status)
		{
			AddStatus(lst, status, false);
		}

		/// <summary>
		/// Add to the status box
		/// </summary>
		/// <param name="lst">The status box to add to</param>
		/// <param name="status">The status string to add</param>
		/// <param name="replaceLastLine">Replace the last line with this one?</param>
		public static void AddStatus(DevExpress.XtraEditors.ListBoxControl lst, string status, bool replaceLastLine)
		{
			// Filter out if there are too many
			lst.BeginUpdate();
			while (lst.Items.Count > 1000)
			{
				lst.Items.RemoveAt(0);		// Remove the base item
			}

			// Add the string
			if (replaceLastLine)
			{
				lst.Items[lst.Items.Count - 1] = status;
			}
			else
			{
				// Just add the line
				lst.Items.Add(status);
			}

			// Scroll to the bottom
			lst.SelectedIndex = lst.Items.Count - 1;

			// End the update
			lst.EndUpdate();
			Application.DoEvents();
		}

		#region Grid Interaction
		public static void GridUIAction(DevExpress.XtraGrid.Views.Grid.GridView gridView, GridUIActionType action)
		{
			gridView.BeginUpdate();
			switch (action)
			{
				case GridUIActionType.ExpandAllGroups:
					gridView.ExpandAllGroups();
					//for (int i = 0; i < gridView.RowCount; i++)
					//{
					//    gridView.ExpandGroupRow(i, true);
					//}
					break;
				case GridUIActionType.CollapseAllGroups:
					gridView.CollapseAllGroups();
					//for (int i = 0; i < gridView.RowCount; i++)
					//{
					//    gridView.CollapseGroupRow(i, true);
					//}
					break;
				case GridUIActionType.ExpandAllDetails:
					for (int i = 0; i < gridView.RowCount; i++)
					{
						gridView.ExpandMasterRow(i);
					}
					break;
				case GridUIActionType.CollapseAllDetails:
					for (int i = 0; i < gridView.RowCount; i++)
					{
						gridView.CollapseMasterRow(i);
					}
					break;
			}
			gridView.EndUpdate();
		}
		#endregion Grid Interaction

		/// <summary>
		/// Tells if the file is a photo or not
		/// </summary>
		/// <returns>True if it's a photo, otherwise, false</returns>
		public static bool FileIsPhoto(string path)
		{
			bool rtv = false;
			PictureBox pic = new PictureBox();
			pic.Size = new Size(100, 100);

			try
			{
				Bitmap bmp = new Bitmap(Image.FromFile(path));
				int width = 0, height = 0;
				decimal imgRatio = (decimal)bmp.Size.Width / (decimal)bmp.Size.Height;
				decimal picDisplayRatio = (decimal)pic.Width / (decimal)pic.Height;
				if (imgRatio > picDisplayRatio)		// This means that width will take precedence
				{
					width = pic.Width;
					height = (width * bmp.Height) / bmp.Width;
				}
				else		// Height is the winner here
				{
					height = pic.Height;
					width = (height * bmp.Width) / bmp.Height;
				}
				pic.Image = new Bitmap(Image.FromFile(path), width, height);

				rtv = true;
			}
			catch
			{
			}
			pic.Dispose();		// Kill off the picture box

			return rtv;
		}

		/// <summary>
		/// Get what the text color should be based on the background color
		/// </summary>
		/// <param name="background">The color of the background</param>
		/// <returns>The color of the text</returns>
		public static Color GetTextColorBasedOnBackgroundColor(Color background,
			Color darkBackgroundTextColor,
			Color lightBackgroundTextColor)
		{
			decimal avg = (decimal)background.R + (decimal)background.G + (decimal)background.B;
			if (avg <= (decimal)(420))
			{
				return darkBackgroundTextColor;			// This is the darker color
			}
			else
			{
				return lightBackgroundTextColor;		// This is the lighter color
			}
		}

		/// <summary>
		/// Return the text color based on the background color sent
		/// </summary>
		/// <param name="background">The background Color</param>
		/// <returns>The finished color</returns>
		public static Color GetTextColorBasedOnBackgroundColor(Color background)
		{
			return GetTextColorBasedOnBackgroundColor(background, Color.White, Color.Black);
		}

		/// <summary>
		/// Alter the field caption from the field name
		/// </summary>
		/// <param name="fieldName">The field name to alter</param>
		/// <returns>A string with the field name</returns>
		public static string AlterCaptionFromFieldName(string fieldName)
		{
			string tmpOut = string.Empty;
			string workingVar = fieldName.Trim();

			// Shear off all the lower case from the front
			for (int i = 0; i < workingVar.Length; i++)
			{
				if ("abcdefghijklmnopqrstuvwxyz".ToUpper().IndexOf(workingVar.Substring(i, 1)) > -1)
				{
					workingVar = workingVar.Substring(i);
					break;
				}
			}

			// Get the actual value, putting space in
			bool prevLetterCapped = false, nextLetterCapped = false;
			for (int i = 0; i < workingVar.Length; i++)
			{
				if ("abcdefghijklmnopqrstuvwxyz".IndexOf(workingVar.Substring(i, 1)) > -1)
				{
					tmpOut += workingVar.Substring(i, 1);
				}
				else
				{
					// Check for a cap or not
					if (i > 0 &&
						"abcdefghijklmnopqrstuvwxyz_".IndexOf(workingVar.Substring(i - 1, 1)) > -1)
					{
						// This is going to be a cap
						if (workingVar.Substring(i, 1) != "_")
						{
							//tmpOut += " " + workingVar.Substring(i, 1);
							tmpOut = tmpOut.Trim() + " " + workingVar.Substring(i, 1);
						}
						else
						{
							tmpOut += " - ";
						}
					}
					else
					{
						tmpOut += workingVar.Substring(i, 1);
					}
				}
			}

			// Go through the string and figure out if you have any 
			// mashed caps (caps that are right next to one another
			// Will take "ContactSSNNumber" and turn it into "Contact SSN Number"
			for (int i = tmpOut.Length - 1; i >= 0; i--)
			{
				if (i > 1 &&
					//i < tmpOut.Length - 1 &&
					"ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(tmpOut.Substring(i - 1, 1)) > -1 &&
					"ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(tmpOut.Substring(i - 2, 1)) > -1 &&
					"abcdefghijklmnopqrstuvwxyz_".IndexOf(tmpOut.Substring(i, 1)) > -1)
				{
					// Dump a space in there
					tmpOut = tmpOut.Substring(0, i - 1) + "-" + tmpOut.Substring(i - 1);
				}
			}

			//if (tmpOut.ToLower().Contains(" - ")) { int test = 1; }
			return tmpOut;
		}

		/// <summary>
		/// Set the form's width and height to fill the current client area without being maximized
		/// </summary>
		/// <param name="targetForm">The form to work with</param>
		private static void FormFillsClientArea(Form targetForm)
		{
			//targetForm.Location = new Point(0, 0);

			//Size sz = new Size();
			//if (targetForm.MdiParent != null &&
			//	typeof(IMDIExternalMethods).IsAssignableFrom(targetForm.MdiParent.GetType()))
			//{
			//	sz = ((IMDIExternalMethods)targetForm.MdiParent).GetOpenClientArea();
			//}

			//// Commented out by MG on 6/13/2008
			//// Size sz = mwsLEAD.common.UserInterface._mainMDIForm.GetOpenClientArea();
			//// End Commented out by MG on 6/13/2008

			//targetForm.Size = sz;

			//// Call the resize controls method
			//if (targetForm is DocSQL_2017.forms.frmDocSQLBase)
			//{
			//	ResizeLayoutControls(targetForm.Controls);		// Resize the layout control
			//}
		}

		/// <summary>
		/// Size the screen accordingly to the wishes of the programmer
		/// </summary>
		/// <param name="targetForm">The form to size</param>
		/// <param name="size">The size of the form</param>
		public static void SizeScreen(System.Windows.Forms.Form targetForm, DocSQLScreenSize size)
		{
			SizeScreen(targetForm, size, null);
		}

		/// <summary>
		/// Size the screen accordingly to the wishes of the programmer
		/// </summary>
		/// <param name="targetForm">The form to size</param>
		/// <param name="size">The size of the form</param>
		/// <param name="percentOfScreen">The percentage of the screen to fill</param>
		public static void SizeScreen(System.Windows.Forms.Form targetForm, DocSQLScreenSize size, int? percentOfScreen)
		{
			//switch (size)
			//{
			//	case DocSQLScreenSize.FormFillsClientArea:
			//		FormFillsClientArea(targetForm);		// Fill the form to the client area
			//		break;
			//	case DocSQLScreenSize.CenterAndSize:
			//	case DocSQLScreenSize.CascadeFromLastForm:
			//		// Figure out if the available window space is smaller than 1024x768
			//		// If it is, then make this form fill the client area
			//		// Otherwise, make it a percentage of the total size of the screen
			//		Size sz = new Size();
			//		if (targetForm.MdiParent != null &&
			//			typeof(IMDIExternalMethods).IsAssignableFrom(targetForm.MdiParent.GetType()))
			//		{
			//			sz = ((IMDIExternalMethods)targetForm.MdiParent).GetOpenClientArea();
			//		}
			//		if (targetForm.MdiParent == null)
			//		{
			//			// Create a size based on the open client area of the main form
			//			sz = ((IMDIExternalMethods)UserInterface.MainMDIForm).GetOpenClientArea();
			//			Size newSize = new Size(
			//				Math.Max((int)((decimal)sz.Width * (decimal).7), targetForm.Width),
			//				Math.Max((int)((decimal)sz.Height * (decimal).85), targetForm.Height)
			//				);
			//			if (percentOfScreen != null)
			//			{
			//				newSize = new Size(
			//					Math.Max((int)((decimal)sz.Width *
			//						(decimal)((decimal)percentOfScreen / 100)), targetForm.Width),
			//					Math.Max((int)((decimal)sz.Height *
			//						(decimal)(((decimal)percentOfScreen / 100))), targetForm.Height)
			//					);
			//			}
			//			targetForm.Size = newSize;
			//			targetForm.Location = new Point(((UserInterface.MainMDIForm.Width - newSize.Width) / 2) +
			//				UserInterface.MainMDIForm.Left,
			//				((UserInterface.MainMDIForm.Height - newSize.Height) / 2) + UserInterface.MainMDIForm.Top);
			//			return;
			//		}
			//		if (targetForm.Size.Width > sz.Width ||
			//			targetForm.Size.Height > sz.Height)
			//		{
			//			FormFillsClientArea(targetForm);		// Fill the form to the client area
			//		}
			//		else
			//		{
			//			Size newSize = new Size(
			//				Math.Max((int)((decimal)sz.Width * (decimal).7), targetForm.Width),
			//				Math.Max((int)((decimal)sz.Height * (decimal).85), targetForm.Height)
			//				);
			//			if (percentOfScreen != null)
			//			{
			//				newSize = new Size(
			//					Math.Max((int)((decimal)sz.Width *
			//						(decimal)((decimal)percentOfScreen / 100)), targetForm.Width),
			//					Math.Max((int)((decimal)sz.Height *
			//						(decimal)(((decimal)percentOfScreen / 100))), targetForm.Height)
			//					);
			//			}
			//			targetForm.Size = newSize;

			//			// Position the form
			//			if (size == DocSQLScreenSize.CenterAndSize)
			//			{
			//				targetForm.Location = new Point((sz.Width - newSize.Width) / 2,
			//					(sz.Height - newSize.Height) / 2);
			//			}
			//			else
			//			{
			//				if (targetForm.MdiParent != null &&
			//					typeof(IMDIExternalMethods).IsAssignableFrom(targetForm.MdiParent.GetType()))
			//				{
			//					// Set the form location
			//					SetFormLocation(targetForm, targetForm.MdiParent);
			//				}
			//			}



			//			// Call the resize controls method
			//			if (targetForm is DocSQL_2017.forms.frmDocSQLBase)
			//			{
			//				ResizeLayoutControls(targetForm.Controls);		// Resize the layout control
			//			}
			//		}
			//		break;
			//}

			//// Take care of this thing only being opened for print
			//if (targetForm is DocSQL_2017.forms.frmDocSQLBase)
			//{
			//	if (((DocSQL_2017.forms.frmDocSQLBase)targetForm).ForPrintOnly)
			//	{ targetForm.Location = new Point(-10000, -10000); }
			//}
		}

		/// <summary>
		/// Resize the MWS Layout Controls
		/// </summary>
		private static void ResizeLayoutControls(System.Windows.Forms.Control.ControlCollection controls)
		{
			// Run through the controls and resize them if need be
			foreach (Control cntrl in controls)
			{
				if (cntrl is mgLayoutControl)
				{
					// Undock the control if need be
					cntrl.Dock = DockStyle.None;

					// Size the control
					cntrl.Location = new Point(8, 8);
					cntrl.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
					cntrl.Size = new Size(cntrl.Parent.ClientSize.Width - 16, cntrl.Parent.ClientSize.Height - 16);

					// Reset any of the other internal controls
					if (cntrl.HasChildren)
					{
						ResizeLayoutControls(cntrl.Controls);
					}
				}
			}
		}

		/// <summary>
		/// Set the form location according to predefined settings
		/// </summary>
		public static void SetFormLocation(Form targetForm, System.Windows.Forms.Form parentForm)
		{
			// Go through each of the forms that are children and position the next one accordingly
			if (parentForm != null &&
				parentForm.MdiChildren.Length == 1)
			{
				targetForm.Location = new Point(0, 0);
				return;
			}

			int startPos = 0;
		retry:
			bool found = false;
			if (parentForm != null)
			{
				foreach (Form frm in parentForm.MdiChildren)
				{
					if (frm != targetForm &&
						frm.Location == new Point(startPos, startPos))
					{
						found = true;
						break;
					}
				}
			}
			if (found) { startPos += 20; goto retry; }
			else { targetForm.Location = new Point(startPos, startPos); }
		}

		/// <summary>
		/// Set the form location according to predefined settings
		/// </summary>
		public static void SetFormLocation(Form targetForm,
			System.Windows.Forms.Form parentForm,
			ClientFormPosition position)
		{
			// Depending on the form position, position the form in the client area accordingly
			Point point = new Point(0, 0);

			// Get the center X and the center Y
			//			int centerX = parentForm.ClientRectangle.Width / 2;
			//			int centerY = parentForm.ClientRectangle.Height / 2;
			int centerX = Utils.ClientAreaWidth / 2;
			int centerY = Utils.ClientAreaHeight / 2;
			int formWidth = targetForm.Width;
			int formHeight = targetForm.Height;
			int formWidthCenter = formWidth / 2;
			int formHeightCenter = formHeight / 2;

			switch (position)
			{
				case ClientFormPosition.TopLeft:
					point = new Point(0, 0);
					break;
				case ClientFormPosition.TopCenter:
					point = new Point(centerX - formWidthCenter, 0);
					break;
				case ClientFormPosition.TopRight:
					point = new Point(parentForm.ClientRectangle.Width - formWidth, 0);
					break;

				case ClientFormPosition.MiddleLeft:
					point = new Point(0, centerY - formHeightCenter);
					break;
				case ClientFormPosition.MiddleCenter:
					point = new Point(centerX - formWidthCenter, centerY - formHeightCenter);
					break;
				case ClientFormPosition.MiddleRight:
					point = new Point(parentForm.ClientRectangle.Width - formWidthCenter,
						centerY - formHeightCenter);
					break;

				case ClientFormPosition.BottomLeft:
					point = new Point(0, parentForm.ClientRectangle.Height - formHeight);
					break;
				case ClientFormPosition.BottomCenter:
					point = new Point(centerX - formWidthCenter, parentForm.ClientRectangle.Height - formHeight);
					break;
				case ClientFormPosition.BottomRight:
					point = new Point(parentForm.ClientRectangle.Width - formWidthCenter,
						parentForm.ClientRectangle.Height - formHeight);
					break;
			}

			targetForm.Location = point;
		}

		/// <summary>
		/// Get an image from the resource path
		/// </summary>
		/// <param name="assemblyName">The assembly name to get the image from 
		///		- should be passed in as the complete file name - like "mwsImgNav.dll"</param>
		/// <param name="resourceName">The name to retrieve the image from - such as DocSQLSplashScreen</param>
		/// <returns>The image...duh!</returns>
		public static Image GetImageFromAssemblyDLLAndResourcePath(string assemblyName, string resourceName)
		{
			return GetImageFromAssemblyDLLAndResourcePath(assemblyName, resourceName, ResImageSize.Empty);
		}

		/// <summary>
		/// Get an image from the resource path
		/// </summary>
		/// <param name="strm">The stream to pull the image from</param>
		/// <param name="resourceName">The name to retrieve the image from - such as DocSQLSplashScreen</param>
		/// <param name="imgSize">The file/image size resource file to pull it out of
		///		If Empty - pulls the first one it runs into that matches the name</param>
		/// <returns>The image...duh!</returns>
		public static Dictionary<string, Image> GetImageFromAssemblyDLLAndResourcePath(Stream strm, ResImageSize imgSize)
		{
			Dictionary<string, Image> images = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);
			#region Resource File/Reader
			// Treat the resource as a resource file.
			try
			{
				// The embedded resource in the stream is not an image, so
				// read it into a ResourceReader and extract the values
				// from there.
				using (System.Resources.IResourceReader reader = new System.Resources.ResourceReader(strm))
				{
					foreach (DictionaryEntry entry in reader)
					{
						if (entry.Value is Image &&
							!images.ContainsKey((string)entry.Key))
						{
							images.Add((string)entry.Key, (Image)entry.Value);
						}
					}
				}
			}
			catch (Exception)
			{
			}
			#endregion Resource File/Reader
			
			return images;
		}

		/// <summary>
		/// Get an image from the resource path
		/// </summary>
		/// <param name="assemblyName">The assembly name to get the image from 
		///		- should be passed in as the complete file name - like "mwsImgNav.dll"</param>
		/// <param name="resourceName">The name to retrieve the image from - such as DocSQLSplashScreen</param>
		/// <param name="imgSize">The file/image size resource file to pull it out of
		///		If Empty - pulls the first one it runs into that matches the name</param>
		/// <returns>The image...duh!</returns>
		public static Image GetImageFromAssemblyDLLAndResourcePath(string assemblyName, string resourceName, ResImageSize imgSize)
		{
			if (!File.Exists(assemblyName))
			{
				MessageBox.Show(assemblyName + " does not exist in the executing directory.\r\n\r\nPlease " +
					"copy " + assemblyName + " to the executing directory and re-run the application.", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return new Bitmap(48, 48);
			}

			Assembly assy = Assembly.LoadFrom(assemblyName);		// Load the assembly
			try
			{
				// Enumerate through all the paths in the file and see if we have a match
				//Dictionary<string, Icon> icons = new Dictionary<string, Icon>();
				//Dictionary<string, Cursor> cursors = new Dictionary<string, Cursor>();
				Dictionary<string, Image> images = new Dictionary<string, Image>();
				foreach (string resName in assy.GetManifestResourceNames())
				{
					if (imgSize == ResImageSize.Empty ||
						(imgSize == ResImageSize.Full && resName.ToLower().Contains("resfull")) ||
						(imgSize == ResImageSize.Size16x16 && resName.ToLower().Contains("16x16")) ||
						(imgSize == ResImageSize.Size24x24 && resName.ToLower().Contains("24x24")) ||
						(imgSize == ResImageSize.Size32x32 && resName.ToLower().Contains("32x32")) ||
						(imgSize == ResImageSize.Size48x48 && resName.ToLower().Contains("48x48")))
					{
						using (Stream stream = assy.GetManifestResourceStream(resName))
						{
							#region Icon
							//// Treat the resource as an icon.
							//try
							//{
							//    Icon icon = new Icon(stream);
							//    icons.Add(resName, icon);
							//    continue;
							//}
							//catch (ArgumentException)
							//{
							//    stream.Position = 0;
							//}
							#endregion Icon

							#region Cursor
							//// Treat the resource as a cursor.
							//try
							//{
							//    Cursor cursor = new Cursor(stream);
							//    cursors.Add(resName, cursor);
							//    continue;
							//}
							//catch (ArgumentException)
							//{
							//    stream.Position = 0;
							//}
							#endregion Cursor

							#region Image
							// Treat the resource as an image.
							try
							{
								Image image = Image.FromStream(stream);
								images.Add(resName, image);

								continue;
							}
							catch (ArgumentException)
							{
								stream.Position = 0;
							}
							#endregion Image

							#region Resource File/Reader
							// Treat the resource as a resource file.
							try
							{
								// The embedded resource in the stream is not an image, so
								// read it into a ResourceReader and extract the values
								// from there.
								using (System.Resources.IResourceReader reader = new System.Resources.ResourceReader(stream))
								{
									foreach (DictionaryEntry entry in reader)
									{
										#region Old Code
										//if (entry.Value is Icon)
										//{
										//    icons.Add(resName, (Icon)entry.Value);
										//}
										//else 
										#endregion Old Code
										if (entry.Value is Image &&
											!images.ContainsKey((string)entry.Key))
										{
											images.Add((string)entry.Key, (Image)entry.Value);
										}
									}
								}
							}
							catch (Exception)
							{
							}
							#endregion Resource File/Reader
						}
					}
				}

				// We have all the images
				Image img = null;
				if (images.Count > 0)
				{
					foreach (KeyValuePair<string, Image> i in images)
					{
						if (i.Key.Equals(resourceName, StringComparison.OrdinalIgnoreCase))
						{
							img = i.Value;
							break;
						}
					}
				}
				return img;
			}
			catch (Exception ex)
			{
				Error.WriteErrorLog(ex, false);
				return new Bitmap(48, 48);
			}
			
		}

		/// <summary>
		/// Resizes the specidied bitmap to a new size. Overloaded.
		/// </summary>
		/// <param name="b"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <returns>Bitmap</returns>
		public static Image ResizeImage(Image img, int width, int height)
		{
			Bitmap result = new Bitmap(width, height);

			try
			{
				using (
					Graphics g = Graphics.FromImage((Image)result))
					g.DrawImage(img, 0, 0, width, height);
			}
			catch (Exception err) { Error.WriteErrorLog(err); }

			return result;
		}

		/// <summary>
		/// Get the resources
		/// </summary>
		/// <param name="assemblyName">The assembly name to get the image from 
		///		- should be passed in as the complete file name - like "mwsImgNav.dll"</param>
		/// <returns>The list of image names</returns>
		public static List<string> GetImageNamesFromDLL(string assemblyName)
		{
			List<string> list = new List<string>();
			if (!File.Exists(assemblyName))
			{
				MessageBox.Show(assemblyName + " does not exist in the executing directory.\r\n\r\nPlease " +
					"copy " + assemblyName + " to the executing directory and re-run the application.", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return list;
			}

			Assembly assy = Assembly.LoadFrom(assemblyName);		// Load the assembly
			try
			{
				string[] names = assy.GetManifestResourceNames();
				for (int i = 0; i < names.Length; i++)
				{
					list.Add(names[i]);
				}
			}
			catch (Exception ex)
			{
				Error.WriteErrorLog(ex, false);
			}

			return list;		// Return the list
		}

		/// <summary>
		/// Get a grayscale version of the image
		/// </summary>
		/// <param name="img">The image to convert</param>
		/// <returns>The new image (in grayscale)</returns>
		public static Image GetGrayscaleImage(Image img)
		{
			if (img == null) { return img; }

			Bitmap bm = new Bitmap(img, img.Width, img.Height);

			for (int y = 0; y < bm.Height; y++)
			{
				for (int x = 0; x < bm.Width; x++)
				{
					Color c = bm.GetPixel(x, y);
					int luma = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
					bm.SetPixel(x, y, Color.FromArgb(luma, luma, luma));
				}
			}
			bm.MakeTransparent();

			return bm;
		}

		/// <summary>
		/// Change the cursor to a wait cursor
		/// </summary>
		public static void WaitCursor()
		{
			Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
		}

		/// <summary>
		/// Change the cursor to the default cursor
		/// </summary>
		public static void DefaultCursor()
		{
			Cursor.Current = System.Windows.Forms.Cursors.Default;
		}

		///// <summary>
		///// Returns the current database and database server version in 3 lines.
		///// </summary>
		///// <returns>string</returns>
		//public static string GetDbVersionString()
		//{
		//    StringBuilder sb = new StringBuilder();
		//    SqlCommand cmd = null;
		//    DataTable dt = null;

		//    try
		//    {
		//        cmd = new SqlCommand("[dbo].[spr_AppListDBCurrentVersion]");
		//        dt = DAL.SQLExecDT(cmd);
		//        if (dt.Rows.Count > 0)
		//        {
		//            DataRow row = dt.Rows[0];
		//            sb.Append("Database v.");
		//            sb.Append(row[0].ToString());
		//            sb.Append(" ");
		//            sb.Append(DateTime.Parse(row[2].ToString()).ToString("dd-MMM-yyyy"));
		//            sb.Append(Environment.NewLine);
		//            sb.Append("SQL ");
		//            sb.Append(row[5].ToString());
		//            sb.Append(" ");
		//            sb.Append(row[6].ToString());
		//            sb.Append(" On ");
		//            sb.Append(row[4].ToString());
		//        }
		//        dt.Dispose();
		//    }
		//    catch (SqlException sqle) { Error.WriteErrorLog(sqle); }
		//    catch (Exception err) { Error.WriteErrorLog(err); }

		//    return sb.ToString();
		//}

		/// <summary>
		/// Get the app version string for the current assembly
		/// </summary>
		/// <returns>A string in the format Major + Minor + Build + Revision</returns>
		public static string GetAppVersionString()
		{
			return GetFileVersionString(Application.ExecutablePath);
		}

		/// <summary>
		/// Get the file version string for the specified file
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public static string GetFileVersionString(string fileName)
		{
			string rtv = string.Empty;
			try
			{
				System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(fileName);
				rtv = fvi.FileVersion;
			}
			catch (Exception ex) { }

			return rtv;
		}

		/// <summary>
		/// Get version information for the app entry program
		/// </summary>
		/// <returns>A string containing the formatted version information</returns>
		public static string GetAppEntryVersionInfo()
		{
			StringBuilder sb = new StringBuilder();

			// Get the entry from the executing assembly
			Assembly assy = Assembly.GetExecutingAssembly();
			sb.Append("" +
				assy.GetName().Version.Major + "." +
				assy.GetName().Version.Minor + "." +
				assy.GetName().Version.Build);

			return sb.ToString();
		}

		/// <summary>
		/// Take a standard string and use the split characters to make a name value collection
		/// </summary>
		public static NameValueCollection GetNameValueCollectionFromString(string target, string firstSplitChar, string secondSplitChar)
		{
			NameValueCollection nvc = new NameValueCollection();

			string[] itemsToParse = DocSQL_2017.Utils.SplitString(target, firstSplitChar);
			foreach (string s in itemsToParse)
			{
				if (!String.IsNullOrEmpty(s))
				{
					// Take the value and split it again
					string[] nameValue = DocSQL_2017.Utils.SplitString(s, secondSplitChar);
					if (nameValue.Length == 2 &&
						!String.IsNullOrEmpty(nameValue[0]) &&
						!String.IsNullOrEmpty(nameValue[1]))
					{
						nvc.Add(nameValue[0], nameValue[1]);
					}
				}
			}

			return nvc;
		}

		#region Progress Form Captioning
		/// <summary>
		/// Show the progress bar window
		/// </summary>
		/// <param name="showMain"></param>
		/// <param name="startVal"></param>
		public static void ShowProgress(decimal startVal)
		{
			ShowProgress(false, startVal);
		}

		/// <summary>
		/// Show the progress bar window
		/// </summary>
		/// <param name="showMain"></param>
		/// <param name="startVal"></param>
		public static void ShowProgress(bool showMain, decimal startVal)
		{
			//if (_frm != null) { KillProgress(); }

			//_frm = new forms.dialogs.frmProgress();

			//if (_frm != null)
			//{
			//	try
			//	{
			//		_frm.Show();
			//	}
			//	catch (Exception ex) { }
			//}
		}

		/// <summary>
		/// Set the progress bar to a hidden state or unhide it
		/// </summary>
		/// <param name="hidden">Tells if the element should be hidden</param>
		public static void ProgressHidden(bool hidden)
		{
			//if (_frm != null)
			//{
			//	if (hidden)
			//	{
			//		_frm.Hide();
			//	}
			//	else
			//	{
			//		_frm.Show();
			//	}
			//}
		}

		/// <summary>
		/// Set the progress sub caption
		/// </summary>
		/// <param name="caption">The caption to set</param>
		public static void SetProgressSubCaption(string caption)
		{
			//if (_frm != null)
			//{
			//	_frm.MainCaption = caption;
			//}
		}

		/// <summary>
		/// Set the progress sub value
		/// </summary>
		/// <param name="val">The value to set</param>
		public static void SetProgressSubValue(decimal val)
		{
			//if (_frm != null)
			//{
			//	_frm.SetSubValue(val);
			//}
		}

		/// <summary>
		/// Set the progress sub value
		/// </summary>
		/// <param name="val">The value to set</param>
		/// <param name="caption">The value to set</param>
		public static void SetProgressSubValue(decimal val, string caption)
		{
			//if (_frm != null)
			//{
			//	_frm.SetSubValue(val, caption);
			//}
		}

		///// <summary>
		///// Set the progress main caption
		///// </summary>
		///// <param name="caption">The caption to set</param>
		//public static void SetProgressMainCaption(string caption)
		//{
		//    if (_frm != null)
		//    {
		//        _frm.MainCaption = caption;
		//    }
		//}

		///// <summary>
		///// Set the progress Main value
		///// </summary>
		///// <param name="caption">The value to set</param>
		//public static void SetProgressMainValue(decimal val)
		//{
		//    if (_frm != null)
		//    {
		//        _frm.SetMainValue(val);
		//    }
		//}

		/// <summary>
		/// Kill the progress window if it's open
		/// </summary>
		public static void KillProgress()
		{
			// Reset the status text 
			//mwsLEAD.common.UserInterface._mainMDIForm.SetStatusText("");
			//mwsLEAD.common.UserInterface._mainMDIForm.ProgressBarHide();

			//if (_frm != null)
			//{
			//	_frm.Close();
			//	_frm = null;
			//}
		}
		#endregion Progress Form Captioning

		public static void PopRichText(RichTextBox rtb, string DisplayText)
		{
			int selStart = rtb.Text.Length;
			rtb.AppendText(DisplayText);
			rtb.Select(selStart, rtb.Text.Length);
			rtb.HideSelection = true;
		}

		/// <summary>
		/// used to format the confirmation box
		/// </summary>
		/// <param name="rtb"></param>
		/// <param name="DisplayText"></param>
		/// <param name="font"></param>
		public static void PopRichText(RichTextBox rtb, string DisplayText, Font font)
		{
			int selStart = rtb.Text.Length;
			rtb.AppendText(DisplayText);
			rtb.Select(selStart, rtb.Text.Length);
			rtb.SelectionFont = font;
			rtb.HideSelection = true;
		}

		public static void PopRichText(RichTextBox rtb, string DisplayText, Color color)
		{
			int selStart = rtb.Text.Length;
			rtb.AppendText(DisplayText);
			rtb.Select(selStart, rtb.Text.Length);
			rtb.SelectionColor = color;
			rtb.HideSelection = true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rtb"></param>
		/// <param name="DisplayText"></param>
		/// <param name="font"></param>
		/// <param name="color"></param>
		public static void PopRichText(RichTextBox rtb, string DisplayText, Font font, Color color)
		{
			int selStart = rtb.Text.Length;
			rtb.AppendText(DisplayText);
			rtb.Select(selStart, rtb.Text.Length);
			rtb.SelectionColor = color;
			rtb.SelectionFont = font;
			rtb.HideSelection = true;
		}

		/// <summary>
		/// Get the connection type based on the connection string for the database
		/// </summary>
		/// <returns>A string containing the proper information</returns>
		public static string GetConnectionType()
		{
			//string DBName = string.Empty, connectionMethod = string.Empty;
			string retval = string.Empty;

			//switch (System.Environment.MachineName.ToLower())
			//{
			//	default:
			//		retval = "Online";

			//		// Get the name from the connection string and put that in the box
			//		if (String.IsNullOrEmpty(DBName))
			//		{
			//			NameValueCollection nvc = GetNameValueCollectionFromString(DAL.ConnString, ";", "=");
			//			string dataSource = string.Empty, initCatalog = string.Empty;
			//			for (int i = 0; i < nvc.Count; i++)
			//			{
			//				switch (nvc.GetKey(i).ToLower().Trim())
			//				{
			//					case "data source":
			//						dataSource = nvc[i];
			//						break;
			//					case "initial catalog":
			//						initCatalog = nvc[i];
			//						break;
			//					default:
			//						break;
			//				}
			//			}

			//			if (!String.IsNullOrEmpty(dataSource) &&
			//				!String.IsNullOrEmpty(initCatalog))
			//			{
			//				retval = "Online - " + dataSource + @"\" + initCatalog;
			//			}

			//			//int startPos = DAL._connstring.ToLower().IndexOf("data source=");
			//			//if (startPos > -1)
			//			//{
			//			//    startPos += "data source=".Length;
			//			//    int endPos = DAL._connstring.ToLower().IndexOf(";", startPos);
			//			//    if (startPos > -1 && endPos > -1)
			//			//        { DBName = DAL._connstring.Substring(startPos, endPos - startPos); }
			//			//    retval = "Online - " + DBName; // + " - " + connectionMethod;
			//			//}
			//		}
			//		break;
			//}

			return retval;		// Return the string
		}


		/// <summary>
		/// Installed versions may include the following:
		/// 1.0.2204.21   Version 1.0 Public Beta 1 Nov 2000 *  
		/// 1.0.2914.16   Version 1.0 Public Beta 2 Jun 2001 *  
		/// 1.0.3512.0   Version 1.0 Pre-release RC3 (Visual Studio.NET 2002 RC3) 
		/// 1.0.3705.0   Version 1.0 RTM (Visual Studio.NET 2002) Feb 2002 *  
		/// 1.0.3705.209   Version 1.0 SP1 Mar 2002 * 
		/// 1.0.3705.288   Version 1.0 SP2 Aug 2002 * 
		/// 1.1.4322.510   Version 1.1 Final Beta Oct 2002 * 
		/// 1.1.4322.573   Version 1.1 RTM (Visual Studio.NET 2003 / Windows Server 2003) Feb 2003 * 
		/// 1.2.21213.-1   Version 1.2 (Whidbey pre-Alpha build) * 
		/// 1.2.30703.27   Version 1.2 (Whidbey Alpha, PDC 2004) Nov 2003 * 
		/// 2.0.40301.9   Version 2.0 (Whidbey CTP, WinHEC 2004) March 2004 * 
		/// 2.0.40426.16   Version 2.0 (Whidbey CTP, TechEd US 2004) May 2004 * 
		/// 2.0.40607.16   Version 2.0 (Visual Studio.NET 2005 Beta 1, TechEd Europe 2004) June 2004 
		/// 2.0.40607.42   Version 2.0 (SQL Server Yukon Beta 2) July 2004  
		/// 1.0.3705.6018   Version 1.0 SP3 Aug 2004 
		/// 1.1.4322.2032   Version 1.1 SP1 Aug 2004  
		/// 1.1.4322.2300   Version 1.1 Post-SP1 (Windows Server 2003 SP1) March 2005  
		/// 2.0.40607.85   Version 2.0 (Visual Studio.NET 2005 Beta 1, Team System Refresh) Aug 2004 * 
		/// 2.0.40903.0   Version 2.0 (Whidbey CTP, Visual Studio Express) Oct 2004 
		/// 2.0.41115.19   Version 2.0 (Visual Studio.NET 2005 Beta 1, Team System Refresh) Dec 2004 
		/// 2.0.50110.28   Version 2.0 (Visual Studio.NET 2005 CTP, Professional Edition) Feb 2005 
		/// 2.0.50215.44   Version 2.0 (Visual Studio.NET 2005 Beta 2, Visual Studio Express Beta 2) Apr 2005 
		/// 2.0.50601.0   Version 2.0 (Visual Studio.NET 2005 CTP) June 2005 
		/// 2.0.50215.322   Version 2.0 (Beta 2, WinFX) Sept 2005 
		/// 2.0.50727.07   Version 2.0 (Visual Studio.NET 2005 CTP) Aug 2005 
		/// 2.0.50727.26   Version 2.0 (Visual Studio.NET 2005 RC / SQL Server 2005 CTP) Sept 2005 
		/// 2.0.50727.42   Version 2.0 RTM (Visual Studio.NET 2005 RTM / SQL Server 2005 RTM) Nov 2005 
		/// 3.0.4131.06   Version 3.0 (CTP 4131.06) Jun 2006 
		/// 3.0.4306.-1   Version 3.0 (CTP 4306 with Vista OS) July 2006 
		/// 3.0.4307.-1   Version 3.0 (CTP 4307 for XP/2003) July 2006 
		/// 3.0.4324.17   Version 3.0 (RC1 4324.17) Aug 2006 
		/// 3.0.4506.03   Version 3.0 (CTP 4506.03) Sept 2006 
		/// 3.0.4506.30   Version 3.0 RTM (RTM 4506.30) Nov 2006 
		/// 2.0 RTM (Vista) 2.0.50727.312 2007-01-30 
		/// 2.0 (KB928365) 2.0.50727.832 2007-07-10 
		/// 2.0 SP1 2.0.50727.1433 2007-11-19
		/// 2.0 SP1 (Windows Server 2008 and Windows Vista SP1) 2.0.50727.1434 ?
		/// 3.0 RTM 3.0.4506.30 2006-11-06
		/// 3.0 RTM (Vista) 3.0.4506.26 2007-01-30
		/// 3.0 SP1 3.0.4506.648 2007-11-19
		/// 3.5 RTM 3.5.21022.8 2007-11-19
		/// 2.0.50727.1434 	Version 2.0 SP1 (Vista SP1, Server 2008) 	February 2008
		/// 3.5.?.? 	Version 3.5 SP1 beta 	May 2008
		/// 2.0.50727.3053 	Version 2.0 SP2 (.NET 3.5 SP1) 	August 2008
		/// 3.0.4506.2123 	Version 3.0 SP2 (.NET 3.5 SP1) 	August 2008
		/// 3.5.30729.01 	Version 3.5 SP1 	August 2008
		/// </summary>
		/// <returns>The latest version found on the current system</returns>
		public static DotNetVersion GetLatestInstalledDotNetVersion()
		{
			string vNum = System.Environment.Version.Major.ToString() + "." +
				System.Environment.Version.Minor.ToString() + "." +
				System.Environment.Version.Build.ToString() + "." +
				System.Environment.Version.Revision.ToString();
			DotNetVersion dotNetVersion = DotNetVersion.Unknown;
			if (vNum.StartsWith("1.0")) { dotNetVersion = DotNetVersion.V_1_0; }
			else if (vNum.StartsWith("1.1")) { dotNetVersion = DotNetVersion.V_1_1; }
			else if (vNum.StartsWith("1.2")) { dotNetVersion = DotNetVersion.V_1_2; }
			else if (vNum.StartsWith("2.0"))
			{
				dotNetVersion = DotNetVersion.V_2_0;
				if (System.Environment.Version.Build == 50727 &&
					System.Environment.Version.Revision >= 1433)
				{
					dotNetVersion = DotNetVersion.V_2_0_SP1;
				}
			}
			else if (vNum.StartsWith("3.0")) { dotNetVersion = DotNetVersion.V_3_0; }
			else if (vNum.StartsWith("3.5")) { dotNetVersion = DotNetVersion.V_3_5; }
			else if (vNum.StartsWith("4.0")) { dotNetVersion = DotNetVersion.V_4_0; }

			return dotNetVersion;
		}

		/// <summary>
		/// Tells if the machine is running at least 2.0 SP1
		/// </summary>
		public static bool InstalledDotNetVersionAtLeast20SP1()
		{
			bool rtv = false;
			DotNetVersion version = GetLatestInstalledDotNetVersion();
			if (version == DotNetVersion.V_2_0_SP1 ||
				version == DotNetVersion.V_3_0 ||
				version == DotNetVersion.V_3_5 ||
				version == DotNetVersion.V_4_0)
			{
				rtv = true;
			}
			return rtv;
		}

		/// <summary>
		/// Tells if the machine is running at least 4.0
		/// </summary>
		public static bool InstalledDotNetVersionAtLeast40()
		{
			bool rtv = false;
			DotNetVersion version = GetLatestInstalledDotNetVersion();
			if (version == DotNetVersion.V_4_0)
			{
				rtv = true;
			}
			return rtv;
		}

		///// <summary>
		///// Build the backdrop picture
		///// </summary>
		///// <param name="enabled">If true, then return the enabled version of the image</param>
		///// <returns>A picture stream containing the image</returns>
		//public static Image GetBackdropPicture(Rectangle screenSize)
		//{
		//    return GetDesktopImage();
		//}

		/// <summary>
		/// Get the agency image from the database
		/// </summary>
		/// <returns>An Image of the Agency's badge</returns>
		public static System.Drawing.Image GetDesktopImage()
		{
			Image img = null;
			//////img = (GlobalCollections.CompleteSettingsCollection != null &&
			//////    GlobalCollections.CompleteSettingsCollection.GetByCategoryKey("Desktop", "DesktopImage") != null ?
			//////    GlobalCollections.CompleteSettingsCollection.GetByCategoryKey("Desktop", "DesktopImage").Image : null);
			//////if (img == null)
			//////{
			//////    img = global::DocSQL_2017.ResLibrary.resFull.DocSQLBlankBackground;
			//////}
			////img = global::DocSQL_2017.ResLibrary.resFull.ShultzLogo_80;
			////return global::DocSQL_2017.ResLibrary.resFull.ShultzLogo_80;		// Return the image

			//// Get the current size of the desktop and show the appropriate image
			//if (UserInterface.MainMDIForm is IMDIExternalMethods)
			//{
			//	decimal percentageSize = 0.6M;
			//	Size openClientArea = ((IMDIExternalMethods)UserInterface.MainMDIForm).GetOpenClientArea();
			//	if (openClientArea.Width <= 0)
			//	{
			//		img = global::DocSQL_2017.ResLibrary.resFull.DocSQLLogo_25;
			//	}
			//	else if (global::DocSQL_2017.ResLibrary.resFull.DocSQLLogo_50.Width / (decimal)openClientArea.Width < percentageSize)
			//	{
			//		img = global::DocSQL_2017.ResLibrary.resFull.DocSQLLogo_50;
			//	}
			//	else if (global::DocSQL_2017.ResLibrary.resFull.DocSQLLogo_45.Width / (decimal)openClientArea.Width < percentageSize)
			//	{
			//		img = global::DocSQL_2017.ResLibrary.resFull.DocSQLLogo_45;
			//	}
			//	else if (global::DocSQL_2017.ResLibrary.resFull.DocSQLLogo_40.Width / (decimal)openClientArea.Width < percentageSize)
			//	{
			//		img = global::DocSQL_2017.ResLibrary.resFull.DocSQLLogo_40;
			//	}
			//	else if (global::DocSQL_2017.ResLibrary.resFull.DocSQLLogo_35.Width / (decimal)openClientArea.Width < percentageSize)
			//	{
			//		img = global::DocSQL_2017.ResLibrary.resFull.DocSQLLogo_35;
			//	}
			//	else if (global::DocSQL_2017.ResLibrary.resFull.DocSQLLogo_30.Width / (decimal)openClientArea.Width < percentageSize)
			//	{
			//		img = global::DocSQL_2017.ResLibrary.resFull.DocSQLLogo_30;
			//	}
			//	else
			//	{
			//		img = global::DocSQL_2017.ResLibrary.resFull.DocSQLLogo_25;
			//	}
			//}

			return img;
		}

		/// <summary>
		/// Get a listing of systems that are admin systems by machine name
		/// If you're using this to determine an Admin system for special purposes, please use the 
		/// "Utils.IsAdminSystem" property
		/// </summary>
		public static List<string> AdminSystems
		{
			get
			{
				List<string> l = new List<string>();
				//l.Add("isspprog".ToLower());			// Mark's Machine
				//l.Add("isspprog-11".ToLower());			// Mark's Machine
				l.Add("isspprog-12".ToLower());			// Mark's Machine
				//l.Add("loney".ToLower());			// Test machine
				//l.Add("mws-lap5".ToLower());			// Mark's Laptop
				l.Add("programmer-ntbk".ToLower());			// Mark's Laptop
				l.Add("programmer-2010".ToLower());		// Alphonso's machine
				l.Add("programmer-2011".ToLower());		// Joseph M's machine
				return l;
			}
		}

		/// <summary>
		/// Tells if the system is an admin system for the purposes of admin code
		/// </summary>
		public static bool IsAdminSystem
		{
			get
			{
				return (UserInterface.AdminSystems.Contains(System.Environment.MachineName.ToLower()) &&
					UserInterface.UseSystemAsAdminSystem);
			}
		}

		/// <summary>
		/// Get a listing of users that are admin users 
		/// If you're using this to determine an Admin user for special purposes, please use the 
		/// "Utils.IsAdminUser" property
		/// </summary>
		public static List<string> AdminUsers
		{
			get
			{
				List<string> l = new List<string>();

				l.Add("mark gerlach".ToLower());
				l.Add("alphonso turner".ToLower());
				//l.Add("arthur park".ToLower());
				l.Add("joseph koenka".ToLower());
				l.Add("joseph minas".ToLower());

				l.Add("steve thorne".ToLower());
				l.Add("kurtis bates".ToLower());
				l.Add("angel ramirez".ToLower());
				l.Add("jerome liscano".ToLower());

				l.Add("mgerlach".ToLower());

				return l;
			}
		}

		/// <summary>
		/// Tells if the user is an admin user for the purposes of admin code
		/// </summary>
		public static bool IsAdminUser
		{
			get
			{
				return true;
				//string currentUserName = Security.CurrentUser.UserName;
				//if (String.IsNullOrEmpty(currentUserName)) { currentUserName = System.Environment.UserName; }
				////return (UserInterface.AdminUsers.Contains(System.Environment.UserName.ToLower()));
				//return (UserInterface.AdminUsers.Contains(currentUserName.ToLower()));
			}
		}

		/// <summary>
		/// Apply the caption changes from the Collection
		/// </summary>
		/// <param name="cntrls">The controls collection to process</param>
		/// <param name="dt">The datatable that contains the replacement values</param>
		public static void ApplyCaptionChangesFromUtilsCollection(System.Windows.Forms.Control.ControlCollection cntrls, 
			string screenName)
		{
			foreach (Control cntrl in cntrls)
			{
				//Console.WriteLine("{0}: {1}", cntrl.Name, cntrl.Text);

				// INFRAGISTICS TAB CONTROL
				//if (cntrl is Infragistics.Win.UltraWinTabControl.UltraTabPageControl)
				//{
				//    // Enumerate through the pages on the tab control
				//    ApplyCaptionChangesFromUtilsCollection(((Infragistics.Win.UltraWinTabControl.UltraTabPageControl)cntrl).Controls,
				//        screenName);

				//    // Change the text on the tab
				//    if (((Infragistics.Win.UltraWinTabControl.UltraTabPageControl)cntrl).Tab != null)
				//    {
				//        ((Infragistics.Win.UltraWinTabControl.UltraTabPageControl)cntrl).Tab.Text =
				//            Utils.ScreenCaptions.AlterText(((Infragistics.Win.UltraWinTabControl.UltraTabPageControl)cntrl).Tab.Text,
				//            screenName);
				//    }
				//}

				// LAYOUTCONTROL
				if (cntrl is DocSQL_2017.mgLayoutControl)
				{
					DevExpress.XtraLayout.Utils.ReadOnlyItemCollection items =
						((DocSQL_2017.mgLayoutControl)cntrl).Items;
					foreach (DevExpress.XtraLayout.BaseLayoutItem item in items)
					{
						if (item.Text != item.Name)
						{
							//// Change the text
							////if (item.Text.StartsWith("User Defined 1:")) { int test = 1; }
							//string newVal = Utils.ScreenCaptions.AlterText(item.Text, screenName);
							//if (!String.IsNullOrEmpty(newVal))
							//{
							//    item.Text = newVal;
							//}
							//else
							//{
							//    //item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
							//    item.Text = "<Not Assigned>";
							//}
							////item.Text = (String.IsNullOrEmpty(newVal) ? " " : newVal);
							////item.Text = Utils.ScreenCaptions.AlterText(item.Text, screenName);
						}
					}
				}

				// NOT AN INFRAGISTICS TAB CONTROL BUT ANY CONTROL WITH CHILDREN
				// UCCOMMONBASE
				//if (!(cntrl is Infragistics.Win.UltraWinTabControl.UltraTabPageControl) &&
				//    //!(cntrl is mgLayoutControl) &&
				//    cntrl.HasChildren)
				//{
				//    // Enumerate through the pages on the tab control
				//    ApplyCaptionChangesFromUtilsCollection(cntrl.Controls, screenName);
				//}

				// DEVXPRESS GRID
				//if (cntrl is DevExpress.XtraGrid.GridControl)
				//{
				//    // Go through each of the views and columns
				//    foreach (DevExpress.XtraGrid.Views.Base.BaseView view in ((DevExpress.XtraGrid.GridControl)cntrl).Views)
				//    {
				//        if (view is DevExpress.XtraGrid.Views.Grid.GridView)
				//        {
				//            DevExpress.XtraGrid.Columns.GridColumnCollection columns = ((DevExpress.XtraGrid.Views.Grid.GridView)view).Columns;
				//            foreach (DevExpress.XtraGrid.Columns.GridColumn col in columns)
				//            {
				//                col.Caption = Utils.ScreenCaptions.AlterText(col.Caption, screenName);
				//            }
				//        }
				//    }
				//}

				// LABEL
				//if (cntrl is Label)
				//{
				//    cntrl.Text = Utils.ScreenCaptions.AlterText(cntrl.Text, screenName);
				//}

				// UCCOMMONBASE
				//if (cntrl is ucCommonBase)
				//{
				//    // Enumerate through the pages on the tab control
				//    ApplyCaptionChangesFromUtilsCollection(((ucCommonBase)cntrl).Controls, screenName);
				//}

				// INFRAGISTICS GRID
				//if (cntrl is Infragistics.Win.UltraWinGrid.UltraGrid)
				//{
				//    // Go through each of the columns
				//    Infragistics.Win.UltraWinGrid.UltraGrid grid = (Infragistics.Win.UltraWinGrid.UltraGrid)cntrl;
				//    for (int band = 0; band < grid.DisplayLayout.Bands.Count; band++)
				//    {
				//        for (int columnIndex = 0; columnIndex < grid.DisplayLayout.Bands[band].Columns.Count; columnIndex++)
				//        {
				//            Infragistics.Win.UltraWinGrid.UltraGridColumn col = grid.DisplayLayout.Bands[band].Columns[columnIndex];
				//            if (!col.Hidden)
				//            {
				//                col.Header.Caption = Utils.ScreenCaptions.AlterText(col.Header.Caption, screenName);
				//            }
				//        }
				//    }
				//}


				// UCMWSGRID
				//if (cntrl is mwsCommon.ucMWSGrid)
				//{
				//    // Go through each of the columns in the column collection
				//    mwsCommon.ucMWSGrid gr = (mwsCommon.ucMWSGrid)cntrl;
				//    for (int band = 0; band < gr.BandCount; band++)
				//    {
				//        for (int columnIndex = 0; columnIndex < gr.GetGridColumnByIndex(band).Count; columnIndex++)
				//        {
				//            MWSGridColumn col = gr.GetGridColumnByIndex(band)[columnIndex];
				//            col.HeaderCaption = Utils.ScreenCaptions.AlterText(col.HeaderCaption, screenName);
				//        }
				//    }
				//}
			}
		}

		/// <summary>
		/// Export the grids to Excel
		/// </summary>
		/// <param name="list">The list of grids</param>
		/// <param name="savePath">The path to save the file to</param>
		public static ClassGenExceptionCollection ExportGridsToExcel(Dictionary<string, mgDevX_GridControl> dict, string savePath)
		{
			// Go through each of the dictionary items and check the name
			ClassGenExceptionCollection errors = new ClassGenExceptionCollection();

			//// Set the license
			//SpreadsheetInfo.SetLicense(Utils.GemBoxLicenseString);

			//foreach (KeyValuePair<string, mgDevX_GridControl> kvp in dict)
			//{
			//    if (kvp.Key.Length > 31) { errors.Add(new 
			//        ClassGenException("The sheet name you're trying to add can only contain 31 characters: \"" + 
			//        kvp.Key + "\"", ClassGenExceptionIconType.Critical)); }

			//    if (kvp.Value.GridView.DataRowCount < 1)
			//    {
			//        errors.Add(new 
			//            ClassGenException("You have no rows to export on this grid: \"" + 
			//            kvp.Key + "\"", ClassGenExceptionIconType.Critical));
			//    }
			//}
			//if (errors.ViewableExceptionCount > 0)
			//{
			//    return errors;
			//}

			//// Create the Excel sheet
			//ExcelFile excelFile = new ExcelFile();

			//// Enumerate through the list of grids to create a sheet in the Excel file
			//List<string> columns = new List<string>();
			//foreach (KeyValuePair<string, mgDevX_GridControl> kvp in dict)
			//{
			//    ExcelWorksheet wksht = excelFile.Worksheets.Add(kvp.Key);
			//    mgDevX_GridControl grid = kvp.Value;

			//    // Go through and generate a list of columns
			//    columns = new List<string>();
			//    for (int i = 0; i < grid.GridView.GroupedColumns.Count; i++)
			//    {
			//        columns.Add(grid.GridView.GroupedColumns[i].FieldName);
			//    }
			//    for (int i = 0; i < grid.GridView.VisibleColumns.Count; i++)
			//    {
			//        columns.Add(grid.GridView.VisibleColumns[i].FieldName);
			//    }

			//    // Build the column headers first
			//    //foreach (GemBox.Spreadsheet.ExcelCell cell in wksht.Cells.GetSubrange("A1", "DB1"))
			//    //{
			//    //    cell.Style.Font.Weight = GemBox.Spreadsheet.ExcelFont.BoldWeight;
			//    //    cell.Style.Font.Name = "Calibri";
			//    //    cell.Style.Font.Size = 11 * 20;

			//    //    cell.Style.Font.Color = Color.White;
			//    //    //cell.Style.FillPattern.PatternForegroundColor = Color.White;
			//    //    cell.Style.FillPattern.SetSolid(Color.FromArgb(82, 128, 188));
			//    //}

			//    GemBox.Spreadsheet.CellRange rangeVisible = wksht.Cells.GetSubrange("A1", "DB1");
			//    string caption = string.Empty;
			//    for (int i = 0; i < columns.Count; i++)
			//    {
			//        caption = grid.GridView.Columns[columns[i]].Caption;
			//        if (String.IsNullOrEmpty(caption))
			//        {
			//            caption = UserInterface.AlterCaptionFromFieldName(grid.GridView.Columns[columns[i]].FieldName);
			//        }
			//        rangeVisible[0, i].Value = "" + caption + "";

			//        // Set the style
			//        rangeVisible[0, i].Style.Font.Weight = GemBox.Spreadsheet.ExcelFont.BoldWeight;
			//        rangeVisible[0, i].Style.Font.Name = "Calibri";
			//        rangeVisible[0, i].Style.Font.Size = 11 * 20;

			//        rangeVisible[0, i].Style.Font.Color = Color.White;
			//        rangeVisible[0, i].Style.FillPattern.SetSolid(Color.FromArgb(82, 128, 188));
			//    }

			//    // Then generate the data
			//    rangeVisible = wksht.Cells.GetSubrange("A2", "GZ" + (grid.GridView.DataRowCount + 1).ToString());
			//    for (int rowIndex = 0; rowIndex < grid.GridView.DataRowCount; rowIndex++)
			//    {
			//        for (int colIndex = 0; colIndex < columns.Count; colIndex++)
			//        {
			//            rangeVisible[rowIndex, colIndex].Value = "" +
			//                (grid.GridView.GetRowCellValue(rowIndex, grid.GridView.Columns[columns[colIndex]].FieldName) != null ?
			//                grid.GridView.GetRowCellValue(rowIndex, grid.GridView.Columns[columns[colIndex]].FieldName).ToString() : string.Empty) + "";

			//            if (rowIndex % 2 == 0)
			//            {
			//                rangeVisible[rowIndex, colIndex].Style.FillPattern.SetSolid(Color.FromArgb(219, 229, 241));
			//            }
			//        }
			//    }

			//    // Go through the columns in the sheet and auto fit the suckers
			//    for (int i = 0; i < columns.Count; i++)
			//    {
			//        wksht.Columns[i].AutoFit();  // Autofit the column
			//    }
			//}

			//// Make the final save
			//excelFile.SaveXls(savePath);

			return errors;		// Return the errors collection
		}

		/// <summary>
		/// Tells whether to show the message box for the current user
		/// If the user has already checked that they don't want to see this box anymore, we don't show it
		/// </summary>
		/// <param name="key">The key for the box to show</param>
		/// <returns>True if the box is to be shown - otherwise, false</returns>
		public static bool ShowMessageBox(MessageBoxKey key)
		{
			bool rtv = true;

			//UserExtendedPropertyCollection coll = new UserExtendedPropertyCollection("sUserGUID = '" + Security.CurrentUser.UserGUID + "' AND " + 
			//	"sPropName = 'MessageBox" + key.ToString() + "'");
			//if (coll.Count > 0) { rtv = false; }

			return rtv;
		}

		/// <summary>
		/// Delete the unused files based on the listing in the XML file
		/// </summary>
		public static void DeleteUnusedFiles()
		{
			// Delete the old versions of the devexpress files
			if (UserInterface.IsAdminSystem) { return; }

			List<string> filePatterns = new List<string>();
			filePatterns.Add("DevExpress*.v7.1*.dll");
			filePatterns.Add("DevExpress*.v7.2*.dll");
			filePatterns.Add("DevExpress*.v7.3*.dll");
			filePatterns.Add("DevExpress*.v8.1*.dll");
			filePatterns.Add("DevExpress*.v9.1*.dll");
			filePatterns.Add("DevExpress*.v9.2*.dll");

			// Go through and delete the files
			foreach (string fileMask in filePatterns)
			{
				string[] files = Directory.GetFiles(Application.StartupPath + @"\", fileMask, SearchOption.TopDirectoryOnly);
				for (int i = 0; i < files.Length; i++)
				{
					try
					{
						File.Delete(files[i]);
					}
					catch (Exception ex)
					{
						// Just dump out
					}
				}
			}
		}

		/// <summary>
		/// Resizes the specidied bitmap to a new size. Overloaded.
		/// </summary>
		/// <param name="b"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <returns>Bitmap</returns>
		public static Bitmap ResizeBitmap(Bitmap b, int width, int height)
		{
			Bitmap result = new Bitmap(width, height);

			try
			{
				using (
					Graphics g = Graphics.FromImage((Image)result))
					g.DrawImage(b, 0, 0, width, height);
			}
			catch (Exception err) { Error.WriteErrorLog(err); }

			return result;
		}

		/// <summary>
		/// Resizes the specidied bitmap to a new size. Overloaded.
		/// </summary>
		/// <param name="b"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="padX">The amount to pad on each side of the image in the x-dimension.</param>
		/// <param name="padY">The amound to pad on each side of the image in the y-dimension</param>
		/// <returns>Bitmap</returns>
		public static Bitmap ResizeBitmap(Bitmap b, int width, int height, int padX, int padY)
		{
			Bitmap result = new Bitmap(width + (2 * padX), height + (2 * padY));
			Bitmap baseImage = new Bitmap(width, height);

			try
			{

				using (Graphics g = Graphics.FromImage((Image)baseImage))
					g.DrawImage(b, 0, 0, width, height);

				using (Graphics g = Graphics.FromImage((Image)result))
					g.DrawImage(b, padX, padY, width, height);

				baseImage.Dispose();
			}
			catch (Exception err) { Error.WriteErrorLog(err); }

			return result;
		}

		/// <summary>
		/// Get an image for the attachment screen
		/// </summary>
		/// <param name="backColor">The back color of the button</param>
		/// <param name="foreColor">The fore color of the button</param>
		/// <param name="text">The text to place on the button</param>
		/// <param name="width">The width of the image</param>
		/// <param name="height">The height of the image</param>
		/// <returns>The completed image</returns>
		public static Image GetImageForAttachment(Color backColor, Color foreColor, string text, int width, int height)
		{
			Rectangle imageSize = new Rectangle(0, 0, width, height);

			Image img = new Bitmap(width, height);
			Graphics g = Graphics.FromImage(img);

			Font font = new Font("Copperplate Gothic Light", 9, FontStyle.Bold);
			SizeF size = g.MeasureString(text, font, 60);

			float newX = (width - size.Width) / 2;
			float newY = (height - size.Height) / 2;

			g.FillRectangle(new SolidBrush(backColor), imageSize);
			StringFormat format = new StringFormat();
			format.Alignment = StringAlignment.Center;
			RectangleF drawRect = new RectangleF(0, newY, width, size.Height);
			g.DrawString(text, font, new SolidBrush(foreColor), drawRect, format);
			g.Dispose();

			return img;		// Return the icon		
		}

		/// <summary>
		/// Get a byte array from a file
		/// </summary>
		/// <param name="fileNameAndPath">The file name and path to pull</param>
		/// <returns>The byte array from the file</returns>
		public static byte[] GetByteArrayFromFile(string fileNameAndPath)
		{
			byte[] fileBin = null;
			try
			{
				FileStream fs = new FileStream(fileNameAndPath, FileMode.Open, FileAccess.Read);
				fileBin = new byte[fs.Length];
				fs.Read(fileBin, 0, System.Convert.ToInt32(fs.Length));
				fs.Close();
			}
			catch (Exception err) { Error.WriteErrorLog(err); }

			return fileBin;
		}

		/// <summary>
		/// Get the type from the key that's passed in
		/// </summary>
		/// <param name="key">The key to grab</param>
		/// <returns>The screen object type</returns>
		public static ScreenObjectFormType GetScreenObjectFormTypeFromKey(string key)
		{
			ScreenObjectFormType rtv = ScreenObjectFormType.Empty;
			if (_screenKeys.Count == 0) { LoadScreenKeys(); }
			foreach (KeyValuePair<ScreenObjectFormType, string> kvp in _screenKeys)
			{
				if (kvp.Value.ToLower() == key.ToLower()) { rtv = kvp.Key; break; }
			}
			return rtv;
		}

		/// <summary>
		/// Get the screen key
		/// </summary>
		/// <param name="type">The type of key to get</param>
		/// <returns>The GUID based on the screen</returns>
		public static string GetScreenKey(ScreenObjectFormType type)
		{
			string rtv = string.Empty;
			if (_screenKeys.Count == 0) { LoadScreenKeys(); }
			if (_screenKeys.ContainsKey(type)) { rtv = _screenKeys[type]; }
			return rtv.ToLower();
		}

		/// <summary>
		/// Load up the screen Keys object
		/// </summary>
		private static void LoadScreenKeys()
		{
			// Run the following code against the database to generate this:
			// SELECT TOP 1000 [sCaseDesc] FROM [DocSQL].[dbo].[vwNavBarObjects] ORDER BY [sCaseDesc]
			
			_screenKeys = new Dictionary<ScreenObjectFormType, string>();

			#region Database Add

			_screenKeys.Add(ScreenObjectFormType.AppraisalList, "6309A25D-E5D3-44EE-B9ED-EA9C03F8D1EA");
			_screenKeys.Add(ScreenObjectFormType.AppraisalNew, "7D892177-D154-4829-B144-92A183882986");
			_screenKeys.Add(ScreenObjectFormType.Appraisals, "CB585DAF-4F13-447D-8C6A-42216AE23F72");
			_screenKeys.Add(ScreenObjectFormType.BreakApartList, "D736F5AC-F57F-4A75-9B8E-435CD721485E");
			_screenKeys.Add(ScreenObjectFormType.BreakApartNew, "B26073E1-E9B5-49F0-B47E-161F22FA02ED");
			_screenKeys.Add(ScreenObjectFormType.BreakAparts, "63E99515-0830-4759-B7DF-731E50834079");
			_screenKeys.Add(ScreenObjectFormType.CustomerList, "BAA19C8F-1176-4CFA-8730-84ECDAE11330");
			_screenKeys.Add(ScreenObjectFormType.CustomerNew, "37F8CA8F-0A87-4C87-BD79-514B186DE25F");
			_screenKeys.Add(ScreenObjectFormType.Customers, "2DCE3F59-F2E8-4046-BBEE-6F4E6DC8CEE9");
			_screenKeys.Add(ScreenObjectFormType.CustomersMain, "DA8E0489-55B1-4CA9-903E-A7C7069EC120");
			_screenKeys.Add(ScreenObjectFormType.GiftCertificates, "D81C02C2-FD00-4C87-B313-DEEED8FFD4F7");
			_screenKeys.Add(ScreenObjectFormType.GiftCertList, "12FDD866-C051-4E5A-AB65-29BD7C0A29DC");
			_screenKeys.Add(ScreenObjectFormType.GiftCertNew, "4A910368-EE8A-4644-B1CC-4852B4BE02D5");
			_screenKeys.Add(ScreenObjectFormType.GiftRegistry, "CEBCB0CD-51EC-4B54-8D01-661A26CC7C32");
			_screenKeys.Add(ScreenObjectFormType.GiftRegistryList, "D71B0B87-A90C-490E-B803-BBB1D2602171");
			_screenKeys.Add(ScreenObjectFormType.GiftRegistryNew, "70FB2F1D-01F2-4CA8-91B8-8E196D8A555F");
			_screenKeys.Add(ScreenObjectFormType.Gifts, "18865AC5-F0A3-47EB-A903-DDF289E29A17");
			_screenKeys.Add(ScreenObjectFormType.InsuranceQuoteList, "C009A192-F1D1-4273-AA80-979863AE1D4A");
			_screenKeys.Add(ScreenObjectFormType.InsuranceQuoteNew, "027922DF-F4E3-483D-AE7D-D493EE5E772A");
			_screenKeys.Add(ScreenObjectFormType.InsuranceQuotes, "5285BDB2-7372-4A02-A9FA-53C021010F78");
			_screenKeys.Add(ScreenObjectFormType.InsuranceSales, "74584781-766E-46DD-BF19-26D6D17B9110");
			_screenKeys.Add(ScreenObjectFormType.InsuranceSalesList, "E8AA3F37-90EF-4125-9701-C5DA7D307C3E");
			_screenKeys.Add(ScreenObjectFormType.InsuranceSalesNew, "03C0038C-B140-4CC2-A51B-FF6A78816966");
			_screenKeys.Add(ScreenObjectFormType.Inventory, "E1DF7BEC-4179-40EE-B87B-C63DE9C6F1F8");
			_screenKeys.Add(ScreenObjectFormType.InventoryList, "5C457C90-C426-46A6-8A54-6FCD24CB9427");
			_screenKeys.Add(ScreenObjectFormType.InventoryMain, "48051AF7-CFF4-4245-AC58-168BB12F07DD");
			_screenKeys.Add(ScreenObjectFormType.InventoryNew, "EF9BE65B-52D3-48F8-8B3C-EAECB1B2C358");
			_screenKeys.Add(ScreenObjectFormType.JobBagList, "0276A1C1-CCE4-4504-93F0-68809D5E3627");
			_screenKeys.Add(ScreenObjectFormType.JobBagNew, "B6F2906C-AAD1-49F0-9913-E378B7F63768");
			_screenKeys.Add(ScreenObjectFormType.JobBags, "A1E28731-71B1-4549-B700-AFF0DF846BD9");
			_screenKeys.Add(ScreenObjectFormType.LayawayList, "8C14E420-5AE8-406B-B50D-A2E020FFB437");
			_screenKeys.Add(ScreenObjectFormType.LayawayNew, "14D654A8-3529-4B70-A2F4-51A4C7F8691E");
			_screenKeys.Add(ScreenObjectFormType.Layaways, "B982224E-A4C5-41B3-A31E-AC798660295F");
			_screenKeys.Add(ScreenObjectFormType.MemoList, "30140E67-BBE6-4A04-8D61-C5926EDA0586");
			_screenKeys.Add(ScreenObjectFormType.MemoNew, "313BB335-ACD8-43F6-B2E6-9E96A18A119C");
			_screenKeys.Add(ScreenObjectFormType.Memorandums, "A738F6D1-5828-46F9-B458-7E0DD7BAD9EC");
			_screenKeys.Add(ScreenObjectFormType.Miscellaneous, "8CE63031-1980-4E49-BD99-49D7388FDD1D");
			_screenKeys.Add(ScreenObjectFormType.PaymentList, "C2EED2AD-6AFD-4D0E-9180-1DE98BE91285");
			_screenKeys.Add(ScreenObjectFormType.PaymentNew, "B4AED578-8113-453E-AD64-E405EAB8BE06");
			_screenKeys.Add(ScreenObjectFormType.Payments, "1AAFC5CE-D686-4B74-8476-4E98D1C3C5E0");
			_screenKeys.Add(ScreenObjectFormType.POList, "3E4237EF-26CA-42BD-B95B-ABEDF9A760E7");
			_screenKeys.Add(ScreenObjectFormType.PONew, "C81E005E-B71A-4D4F-B6B5-5AB9C922D9C6");
			_screenKeys.Add(ScreenObjectFormType.PurchaseOrders, "DA09690F-BE60-4CBC-91F8-918B851303F5");
			_screenKeys.Add(ScreenObjectFormType.ReturnItems, "F6D161C0-92DD-4B1D-B478-05E41E04A1AE");
			_screenKeys.Add(ScreenObjectFormType.ReturnsList, "21D1FE8E-14DF-4A87-8A35-0DFE652EE0E0");
			_screenKeys.Add(ScreenObjectFormType.ReturnsNew, "4454CAE0-753A-4C4E-9E6F-92CE6C72C783");
			_screenKeys.Add(ScreenObjectFormType.Sales, "8E066705-9DB7-4529-8FB3-11085A24047F");
			_screenKeys.Add(ScreenObjectFormType.SalesList, "01349255-D0CA-499B-8C3C-DCFD6FFA7E70");
			_screenKeys.Add(ScreenObjectFormType.SalesMain, "5E22FB13-ECAE-4832-84EC-1329FB19F488");
			_screenKeys.Add(ScreenObjectFormType.SalesNew, "753F9782-40ED-4DCF-B32B-EBC2ED681FFF");
			_screenKeys.Add(ScreenObjectFormType.SpecialOrderList, "7EED1332-5A6E-440A-9BEC-34489BDBF7DB");
			_screenKeys.Add(ScreenObjectFormType.SpecialOrderNew, "F978034F-2AD4-42A0-965D-31BDFE6072BF");
			_screenKeys.Add(ScreenObjectFormType.SpecialOrders, "7A590B5E-B487-4875-BA03-8C1B07F8D933");
			_screenKeys.Add(ScreenObjectFormType.SupplierList, "273E10DA-F715-415F-B05A-C2D733C93085");
			_screenKeys.Add(ScreenObjectFormType.SupplierNew, "AD580DC8-90A4-4F43-A8F5-2EAB82682F69");
			_screenKeys.Add(ScreenObjectFormType.Suppliers, "77CBF88C-9CD4-4B27-823D-35FEB647C73B");
			_screenKeys.Add(ScreenObjectFormType.TimeClock, "A5EB2678-669D-49D1-9530-48500DD6B38C");
			_screenKeys.Add(ScreenObjectFormType.TimeClockList, "EC339ADC-2FE8-4602-9458-DBE469ACF55B");
			_screenKeys.Add(ScreenObjectFormType.TimeClockNew, "EDDDBADF-CF37-438A-A0D2-DDBEA4A0FD37");

			#endregion Database Add

			#region Added By Developer
			foreach (string type in Enum.GetNames(typeof(ScreenObjectFormType)))
			{
				ScreenObjectFormType enumType = (ScreenObjectFormType)Enum.Parse(typeof(ScreenObjectFormType), type, true);
				if (!_screenKeys.ContainsKey(enumType)) { _screenKeys.Add(enumType, System.Guid.NewGuid().ToString()); }
			}
			#endregion Added By Developer
		}

		#region Halt Redrawing
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

		private const int WM_SETREDRAW = 11;

		public static void SuspendDrawing(Control parent)
		{
			SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
		}

		public static void ResumeDrawing(Control parent)
		{
			SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
			parent.Refresh();
		}
		#endregion Halt Redrawing
	}
}
