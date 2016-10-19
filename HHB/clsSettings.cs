/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-10-04
 * Time: 17:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using Ini;

namespace HHBuilder
{
	/// <summary>
	/// Description of clsSettings.
	/// </summary>
	public static class HBSettings
	{
		public enum LogLevel
		{
			Normal,
			Debug
		};
		
		#region Private Member Variables
		private static string _workingDir;				// Root working directory
		private static string _templateDir;			// Directory to look for templates
		private static string _author;
		private static string _company;
		private static string _copyrightTemplate;		// Copyright template
		private static string _language;
		private static string _cfgFileName;
		private static string _logFileName;
		private static LogLevel _logLevel;

		private static string NS = typeof(MainForm).Namespace;
		private static string FNAME = NS + ".cfg";		
		#endregion

		#region Private Properties
		#endregion
		
		#region Private Methods
		// ==============================================================================
		/// <summary>
		/// Checks standard directories for the location of the current configuration<br />
		/// file. If no file is found, one is created.
		/// </summary>
		/// <returns>The full path and file name of the program configuration file.</returns>
		private static string GetFileName()
		{
			string testFilePath = "";
			string testStartupPath = Application.StartupPath;
			if (!testStartupPath.EndsWith(@"\"))
			{
				testStartupPath += @"\";
			}
			testStartupPath += FNAME;
			if (System.IO.File.Exists(testStartupPath))
			{
				testFilePath = testStartupPath;
			}
			
			string testAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			if (String.IsNullOrEmpty(testFilePath))
			{
				if (!testAppDataPath.EndsWith(@"\"))
				{
					testAppDataPath += @"\";
				}
				testAppDataPath += FNAME;
				if (System.IO.File.Exists(testAppDataPath))
				{
					testFilePath = testAppDataPath;
				}
			}
			
			string fileContents = MakeFileContents();
			
			if (String.IsNullOrEmpty(testFilePath))
			{
				try
				{
					System.IO.File.WriteAllText(testStartupPath, fileContents);
					testFilePath = testStartupPath;
				}
				catch
				{
					testFilePath = "";
				}
			}
			
			if (String.IsNullOrEmpty(testFilePath))
			{
				try
				{
					System.IO.File.WriteAllText(testAppDataPath, fileContents);
					testFilePath = testAppDataPath;
				}
				catch
				{
					testFilePath = "";
				}
			}
			
			return testFilePath;
		}
		
		// ==============================================================================
		/// <summary>
		/// Prepares a string of the current configuration settings suitable for<br />
		/// writing to the configuration file.
		/// </summary>
		/// <returns>A string of the current configuration settings.</returns>
		private static string MakeFileContents()
		{
			System.Text.StringBuilder filecontents = new System.Text.StringBuilder("");
			filecontents.Append(";");
			filecontents.Append('=', 69);
			filecontents.AppendLine();
			filecontents.AppendLine(";");
			filecontents.AppendLine("; Local Configuration Information for osHHB Application");
			filecontents.AppendLine(";");
			filecontents.Append('=', 69);
			filecontents.AppendLine();
			filecontents.AppendLine();
			filecontents.AppendLine();
			filecontents.AppendLine("[Identification]");
			filecontents.Append(";");
			filecontents.Append('-', 69);
			filecontents.AppendLine();
			filecontents.AppendLine("; Author:  Name to use in the {AUTHOR} tags");
			filecontents.AppendLine("; Company:  Name to use in the {COMPANY} tags");
			filecontents.Append(";");
			filecontents.Append('-', 69);
			filecontents.AppendLine();
			filecontents.Append("Author=");
			filecontents.AppendLine(author);
			filecontents.Append("Company=");
			filecontents.AppendLine(company);
			filecontents.AppendLine();
			filecontents.AppendLine();
			filecontents.AppendLine("[Copyright]");
			filecontents.Append(";");
			filecontents.Append('-', 69);
			filecontents.AppendLine();
			filecontents.AppendLine("; CopyrightTemplate:  Template used to produce Copyright string");
			filecontents.AppendLine(";           Can include the replaceable tags: {YEAR}, {AUTHOR}");
			filecontents.AppendLine(";           and {COMPANY}");
			filecontents.Append(";");
			filecontents.Append('-', 69);
			filecontents.AppendLine();
			filecontents.Append("CopyrightTemplate=");
			filecontents.AppendLine(copyrightTemplate);
			filecontents.AppendLine();
			filecontents.AppendLine();
			filecontents.AppendLine("[Settings]");
			filecontents.Append(";");
			filecontents.Append('-', 69);
			filecontents.AppendLine();
			filecontents.AppendLine("; Language:  The default language code");
			filecontents.Append(";");
			filecontents.Append('-', 69);
			filecontents.AppendLine();
			filecontents.Append("Language=");
			filecontents.AppendLine(language);
			filecontents.AppendLine();
			filecontents.AppendLine();
			filecontents.AppendLine("[Logging]");
			filecontents.Append(";");
			filecontents.Append('-', 69);
			filecontents.AppendLine();
			filecontents.AppendLine("; FileName:  File to write log entries");
			filecontents.AppendLine("; LogLevel:  Amount of detail to log (Normal|Debug)");
			filecontents.Append(";");
			filecontents.Append('-', 69);
			filecontents.AppendLine();
			filecontents.Append("FileName=");
			filecontents.AppendLine(logFileName);
			filecontents.Append("LogLevel=");
			filecontents.AppendLine(logLevel.ToString());
			filecontents.AppendLine();
			filecontents.AppendLine();
			filecontents.AppendLine("[Directories]");
			filecontents.Append(";");
			filecontents.Append('-', 69);
			filecontents.AppendLine();
			filecontents.AppendLine("; Working:  The default working directory");
			filecontents.AppendLine("; Template:  Directory to search for help template files");
			filecontents.Append(";");
			filecontents.Append('-', 69);
			filecontents.AppendLine();
			filecontents.Append("Working=");
			filecontents.AppendLine(workingDir);
			filecontents.Append("Template=");
			filecontents.AppendLine(templateDir);
			
			return filecontents.ToString();
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		
//		public HBSettings()
//		{
//			workingDir = "";
//			templateDir = "";
//			author = "";
//			company = "";
//			copyrightTemplate = "";
//			language = "";
//			cfgFileName = GetFileName();
//		}
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// Working directory
		/// </summary>
		public static string workingDir
		{
			get{ return _workingDir.Trim(); }
			set{ _workingDir = value.Trim(); }
		}
		
		/// <summary>
		/// Directory where the template files are stored
		/// </summary>
		public static string templateDir
		{
			get{ return _templateDir.Trim(); }
			set{ _templateDir = value.Trim(); }
		}
		
		/// <summary>
		/// Default help project author name
		/// </summary>
		public static string author
		{
			get{ return _author.Trim(); }
			set{ _author = value.Trim(); }
		}
		
		/// <summary>
		/// Default help project company name
		/// </summary>
		public static string company
		{
			get{ return _company.Trim(); }
			set{ _company = value.Trim(); }
		}
		
		/// <summary>
		/// Template to use for generating the help project copyright notice
		/// </summary>
		public static string copyrightTemplate
		{
			get{ return _copyrightTemplate.Trim(); }
			set{ _copyrightTemplate = value.Trim(); }
		}
		
		/// <summary>
		/// Default help project language
		/// </summary>
		public static string language
		{
			get{ return _language.Trim(); }
			set{ _language = value.Trim(); }
		}
		
		/// <summary>
		/// Path and name of the configuration file
		/// </summary>
		public static string cfgFileName
		{
			get{ return _cfgFileName.Trim(); }
			set{ _cfgFileName = value.Trim(); }
		}
		
		/// <summary>
		/// Path and name of the log file
		/// </summary>
		public static string logFileName
		{
			get{ return _logFileName.Trim(); }
			set{ _logFileName = value.Trim(); }
		}
		
		/// <summary>
		/// Amount of detail to write to log file
		/// </summary>
		public static LogLevel logLevel
		{
			get{ return _logLevel; }
			set{ _logLevel = value; }
		}
		#endregion
		
		#region Public Methods
		// ==============================================================================
		/// <summary>
		/// Initializes the settings and locates the configuration file.<br />
		/// If the configuration file does not exist, one will be created.
		/// </summary>
		/// <returns>True on success, otherwise false.</returns>
		public static bool Initialize()
		{
			workingDir = "";
			templateDir = "";
			author = "";
			company = "";
			copyrightTemplate = "";
			language = "";
			logFileName = "";
			logLevel = LogLevel.Normal;
			cfgFileName = GetFileName();
			return !String.IsNullOrEmpty(cfgFileName);
		}
		
		// ==============================================================================
		/// <summary>
		/// Builds a copyright string by replacing the {YEAR}, {AUTHOR} and {COMPANY}<br />
		/// tags in the CopyrightTemplate with their current values from the configuration settings.
		/// </summary>
		/// <returns>
		/// A copyright string based on the object's Copyright template.<br />
		/// If the template is empty, a standard copyright string is returned.
		/// </returns>
		public static string Copyright()
		{
			string copyrightNotice = copyrightTemplate;
			if (!String.IsNullOrEmpty(copyrightNotice))
			{
				copyrightNotice = copyrightNotice.Replace("{YEAR}", DateTime.Now.ToString("yyyy"));
				copyrightNotice = copyrightNotice.Replace("{AUTHOR}", author);
				copyrightNotice = copyrightNotice.Replace("{COMPANY}", company);
			}
			else
			{
				System.Text.StringBuilder tempString = new System.Text.StringBuilder("Copyright ");
				tempString.Append(DateTime.Now.ToString("yyyy"));
				if ((String.IsNullOrEmpty(author)) && (String.IsNullOrEmpty(company)))
				{
					tempString.Append(" ");
					tempString.Append(Environment.UserName);
				}
				else
				{
					if (!String.IsNullOrEmpty(author))
					{
						tempString.Append(" ");
						tempString.Append(author);
						if (!String.IsNullOrEmpty(company))
						{
							tempString.Append(" (");
							tempString.Append(company);
							tempString.Append(")");
						}
					}
					else
					{
						if (!String.IsNullOrEmpty(company))
						{
							tempString.Append(")");
						}
					}
				}
				tempString.Append(". All rights reserved.");
				copyrightNotice = tempString.ToString();
			}
			return copyrightNotice;
		}

		// ==============================================================================
		/// <summary>
		/// Reads the settings from the current configuration file.
		/// </summary>
		/// <returns>True if the configuration file was read successfully,<br />
		/// otherwise False.</returns>
		public static bool Read()
		{
			string fileToRead = cfgFileName;
			if (!System.IO.File.Exists(fileToRead)) { return false; }
			
			try
			{
				// Open .ini file
				IniFile ini = new IniFile(fileToRead);
				
				// Read the configuration settings
				author = ini.IniReadValue("Identification", "Author");
				company = ini.IniReadValue("Identification", "Company");
				copyrightTemplate = ini.IniReadValue("Copyright", "CopyrightTemplate");
				language = ini.IniReadValue("Settings", "Language");
				logFileName = ini.IniReadValue("Logging", "FileName");
				workingDir = ini.IniReadValue("Directories", "Working");
				templateDir = ini.IniReadValue("Directories", "Template");
				string tempLogLevel = ini.IniReadValue("Logging", "LogLevel");
				if ( tempLogLevel.ToLower().Equals("debug") )
				{
					logLevel = LogLevel.Debug;
				}
				else
				{
					logLevel = LogLevel.Normal;
				}
				return true;
			}
			catch (Exception ex)
			{
				Log.Exception(ex);
				return false;
			}
			
		}

		// ==============================================================================
		/// <summary>
		/// Writes the settings to the current configuration file.
		/// </summary>
		/// <returns>True if the configuration file was written successfully,<br />
		/// otherwise False.</returns>
		public static bool Write()
		{
			try
			{
				System.IO.File.WriteAllText(cfgFileName, MakeFileContents());
				return true;
			}
			catch (Exception ex)
			{
				Log.Exception(ex);
				return false;
			}
		}

		// --------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Displays the current configuration settings
		/// </summary>
		public static void ShowAll()
		{
			System.Text.StringBuilder tempString = new System.Text.StringBuilder("");
			tempString.Append("Config File: ");
			tempString.AppendLine(cfgFileName);
			tempString.Append("Author: ");
			tempString.AppendLine(author);
			tempString.Append("Company: ");
			tempString.AppendLine(company);
			tempString.Append("Copyright Template: ");
			tempString.AppendLine(copyrightTemplate);
			tempString.Append("Copyright: ");
			tempString.AppendLine(Copyright());
			tempString.Append("Working Dir: ");
			tempString.AppendLine(workingDir);
			tempString.Append("Template Dir: ");
			tempString.AppendLine(templateDir);
			MessageBox.Show( tempString.ToString(), "Current Settings");
		}
		#endregion
		
	}
}
