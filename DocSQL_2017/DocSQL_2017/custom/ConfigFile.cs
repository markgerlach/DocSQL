using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DocSQL_2017.custom
{
	public static class ConfigFile
	{
		private static string _configFileName = "_main.config";
		
		/// <summary>
		/// Check to make sure the configuration file exists
		/// </summary>
		/// <returns>Boolean to denote if the file exists or not</returns>
		public static bool ConfigFileExists()
		{
			return File.Exists(Path.Combine(Application.StartupPath, _configFileName));
		}

		/// <summary>
		/// Get the conig file contents
		/// </summary>
		/// <returns>The contents of the file
		/// Should be a pipe-delimited string in the format Source:path|Target:path</returns>
		public static string GetConfigFileContents(ref string err)
		{
			string rtv = string.Empty;

			//// Crack open the file, decrypt the contents and bring them back
			//using (StreamReader sr = new StreamReader(Path.Combine(Application.StartupPath, _configFileName)))
			//{
			//	rtv = sr.ReadToEnd();
			//}

			//// Decrypt it
			//err = string.Empty;
			//rtv = rtv.Replace("\r\n", "");
			//rtv = Crypto.DecryptString(rtv, ref err);

			//// Check the contents
			//if (!rtv.ToLower().StartsWith("source:"))
			//{
			//	err = "Invalid configuration: " + rtv;
			//	rtv = string.Empty;
			//}

			return rtv;
		}

		/// <summary>
		/// Write the file contents in
		/// </summary>
		/// <param name="fileContents"></param>
		/// <returns></returns>
		public static bool WriteConfigFileContents(string sourcePath, string targetPath, string type, ref string err)
		{
			string fileTarget = Path.Combine(Application.StartupPath, _configFileName);
			bool rtv = true;

			//// Build the string first, then write it
			//string encString = String.Format("Source:{0}|Target:{1}|Type:{2}", sourcePath, targetPath, type);
			//err = string.Empty;
			//encString = Crypto.EncryptString(encString, ref err);
			//if (!String.IsNullOrEmpty(err))
			//{
			//	return false;
			//}

			//// Destroy the file if it exists
			//if (File.Exists(targetPath))
			//{
			//	try
			//	{
			//		File.Delete(targetPath);
			//	}
			//	catch (Exception ex)
			//	{
			//		err = ex.Message;
			//		rtv = false;
			//	}
			//}

			//// Write it
			//try
			//{
			//	TextWriter wt = File.AppendText(fileTarget);
			//	TextWriter.Synchronized(wt);
			//	wt.WriteLine(encString);
			//	wt.Close();
			//}
			//catch (Exception ex)
			//{
			//	Error.DisplayCustomError("Error saving configuration file: " + ex.Message);
			//	rtv = false;
			//}

			return rtv;
		}
		
		/// <summary>
		/// Get the source path from the file
		/// </summary>
		/// <returns>The source path</returns>
		public static string GetSourcePath()
		{
			string rtv = string.Empty, err = string.Empty;

			if (ConfigFileExists())
			{
				// Crack it open and get the contents
				rtv = GetConfigFileContents(ref err);
				if (String.IsNullOrEmpty(err) &&
					!String.IsNullOrEmpty(rtv))
				{
					rtv = Utils.SplitString(rtv, "|")[0].Substring(7);
				}
				else
				{
					rtv = "ERROR: " + err;		// Return the error
				}
			}

			return rtv;
		}

		/// <summary>
		/// Get the target path from the file
		/// </summary>
		/// <returns>The target path</returns>
		public static string GetTargetPath()
		{
			string rtv = string.Empty, err = string.Empty;

			if (ConfigFileExists())
			{
				// Crack it open and get the contents
				rtv = GetConfigFileContents(ref err);
				if (String.IsNullOrEmpty(err) &&
					!String.IsNullOrEmpty(rtv))
				{
					rtv = Utils.SplitString(rtv, "|")[1].Substring(7);
				}
				else
				{
					rtv = "ERROR: " + err;      // Return the error
				}
			}

			return rtv;
		}

		/// <summary>
		/// Get the type of file
		/// </summary>
		/// <returns>The file type</returns>
		public static string GetType()
		{
			string rtv = string.Empty, err = string.Empty;

			if (ConfigFileExists())
			{
				// Crack it open and get the contents
				rtv = GetConfigFileContents(ref err);
				if (String.IsNullOrEmpty(err) &&
					!String.IsNullOrEmpty(rtv))
				{
					rtv = Utils.SplitString(rtv, "|")[2].Substring(5);
				}
				else
				{
					rtv = "ERROR: " + err;      // Return the error
				}
			}

			return rtv;
		}
	}
}
