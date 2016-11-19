/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-10-04
 * Time: 17:25
 */
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Ini;

namespace HHBuilder
{
	/// <summary>
	/// The HBSettings class holds and serves all program and user settings.
	/// </summary>
	public static class HBSettings
	{
		#region Private Member Variables
		private static string _workingDir = String.Empty;				// Root working directory
		private static string _templateDir = String.Empty;				// Directory to look for templates
		private static string _author = String.Empty;
		private static string _company = String.Empty;
		private static string _copyrightTemplate = String.Empty;		// Copyright template
		private static string _language = String.Empty;
		private static string _cfgFileName = String.Empty;
		private static string _logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), Assembly.GetExecutingAssembly().GetName().Name);
		private static Log.LogLevel _logLevel = Log.LogLevel.Normal;
		private static int _logsToKeep = 5;
		private static string _uiCulture = String.Empty;
		private static bool _cleanup = true;
		private static string _hhcDirectory = String.Empty;
		private static bool _checkUpdates = true;

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
			string testFilePath = String.Empty;
			string testStartupPath = Path.Combine(Application.StartupPath, FNAME);
			if (System.IO.File.Exists(testStartupPath))
			{
				testFilePath = testStartupPath;
			}
			
			string testAppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), FNAME);
			if (String.IsNullOrEmpty(testFilePath))
			{
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
					testFilePath = String.Empty;
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
					testFilePath = String.Empty;
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
			filecontents.AppendLine("; UserInterface:  The user interface language code (blank for current Windows setting)");
			filecontents.AppendLine("; CheckForUpdates:  Check for program updates at during startup (Yes|No)");
			filecontents.AppendLine("; CleanOnExit:  Remove temporary files and directories at program shutdown (Yes|No)");
			filecontents.Append(";");
			filecontents.Append('-', 69);
			filecontents.AppendLine();
			filecontents.Append("Language=");
			filecontents.AppendLine(language);
			filecontents.Append("UserInterface=");
			filecontents.AppendLine(uiCulture);
			filecontents.Append("CheckForUpdates=");
			if ( checkForUpdates )
			{
				filecontents.AppendLine("Yes");
			}
			else
			{
				filecontents.AppendLine("No");
			}
			filecontents.Append("CleanOnExit=");
			if ( cleanOnExit )
			{
				filecontents.AppendLine("Yes");
			}
			else
			{
				filecontents.AppendLine("No");
			}
			filecontents.AppendLine();
			filecontents.AppendLine();
			filecontents.AppendLine("[Logging]");
			filecontents.Append(";");
			filecontents.Append('-', 69);
			filecontents.AppendLine();
			filecontents.AppendLine("; LogDir:  Directory to write the log file");
			filecontents.AppendLine("; LogLevel:  Amount of detail to log:");
			foreach (Log.LogLevel tLevel in Enum.GetValues(typeof(Log.LogLevel))) {
				filecontents.AppendFormat(";                {0} = {1}\n", (int) tLevel, tLevel.ToString());
			}
			filecontents.AppendLine("; LogFileCount:  Number of session log files to keep");
			filecontents.Append(";");
			filecontents.Append('-', 69);
			filecontents.AppendLine();
			filecontents.Append("LogDir=");
			filecontents.AppendLine(logDir);
			filecontents.Append("LogLevel=");
			filecontents.AppendLine(((int) logLevel).ToString());
			filecontents.Append("LogFileCount=");
			filecontents.AppendLine(logsToKeep.ToString());
			filecontents.AppendLine();
			filecontents.AppendLine();
			filecontents.AppendLine("[Directories]");
			filecontents.Append(";");
			filecontents.Append('-', 69);
			filecontents.AppendLine();
			filecontents.AppendLine("; Working:  The default working directory");
			filecontents.AppendLine("; Compiler:  Location of the hhc.exe program file");
			filecontents.AppendLine("; Template:  Directory to search for help template files");
			filecontents.Append(";");
			filecontents.Append('-', 69);
			filecontents.AppendLine();
			filecontents.Append("Working=");
			filecontents.AppendLine(workingDir);
			filecontents.Append("Compiler=");
			filecontents.AppendLine(compilerDir);
			filecontents.Append("Template=");
			filecontents.AppendLine(templateDir);
			
			return filecontents.ToString();
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		#endregion
		
		#region Public Properties
		// ==============================================================================
		/// <summary>
		/// Working directory
		/// </summary>
		public static string workingDir
		{
			get
			{
				if ( String.IsNullOrWhiteSpace(_workingDir) ) {
					return Path.Combine( System.IO.Path.GetTempPath(), typeof(MainForm).Namespace + "_working" );
				}
				else
				{
					return _workingDir.Trim();
				}
			}
			set
			{
				if ( workingDir != value.Trim() )
				{
					HHBTemplate.Cleanup();
					HHCompile.Cleanup();
				}
				_workingDir = value.Trim();
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// Working directory used for building templates
		/// </summary>
		public static string templateBuildDir
		{
			get{ return Path.Combine(workingDir, "BuildTemplate"); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Working directory used for extracting template HTML files
		/// </summary>
		public static string templateHtmlDir
		{
			get{ return Path.Combine(workingDir, "TemplateHTML"); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Working directory used for extracting templates
		/// </summary>
		public static string templateExtractDir
		{
			get{ return Path.Combine(workingDir, "ExtractTemplate"); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Working directory used for building projects
		/// </summary>
		public static string projectBuildDir
		{
			get{ return Path.Combine(workingDir, "BuildProject"); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Directory where the template files are stored
		/// </summary>
		public static string templateDir
		{
			get{ return _templateDir.Trim(); }
			set
			{
				_templateDir = value.Trim();
				HHBTemplate.ReadAvailableTemplates();
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// Directory where the hhc.exe file is located
		/// </summary>
		public static string compilerDir
		{
			get{ return _hhcDirectory.Trim(); }
			set{ _hhcDirectory = value.Trim(); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Default help project author name
		/// </summary>
		public static string author
		{
			get{ return _author.Trim(); }
			set{ _author = value.Trim(); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Default help project company name
		/// </summary>
		public static string company
		{
			get{ return _company.Trim(); }
			set{ _company = value.Trim(); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Template to use for generating the help project copyright notice
		/// </summary>
		public static string copyrightTemplate
		{
			get{ return _copyrightTemplate.Trim(); }
			set{ _copyrightTemplate = value.Trim(); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Default help project language
		/// </summary>
		public static string language
		{
			get{ return _language.Trim(); }
			set{ _language = value.Trim(); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Default program user interface culture
		/// </summary>
		public static string uiCulture
		{
			get{ return _uiCulture.Trim(); }
			set{ _uiCulture = value.Trim(); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Path and name of the configuration file
		/// </summary>
		public static string cfgFileName
		{
			get{ return _cfgFileName.Trim(); }
			set{ _cfgFileName = value.Trim(); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Directory to store the log files
		/// </summary>
		public static string logDir
		{
			get{ return _logPath.Trim(); }
			set{ _logPath = value.Trim(); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Amount of detail to write to log file
		/// </summary>
		public static Log.LogLevel logLevel
		{
			get{ return _logLevel; }
			set{ _logLevel = value; }
		}
		
		// ==============================================================================
		/// <summary>
		/// Number of log files to keep
		/// </summary>
		public static int logsToKeep
		{
			get{ return _logsToKeep; }
			set
			{
				if ( value < 0 )
				{
					_logsToKeep = 0;
				}
				else
				{
					_logsToKeep = value;
				}
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// Whether to remove working files and directories during program shutdown.
		/// </summary>
		public static bool cleanOnExit
		{
			get{ return _cleanup; }
			set{ _cleanup = value; }
		}
		
		// ==============================================================================
		/// <summary>
		/// Whether to check for program updates during program startup.
		/// </summary>
		public static bool checkForUpdates
		{
			get{ return _checkUpdates; }
			set{ _checkUpdates = value; }
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
			workingDir = String.Empty;
			templateDir = String.Empty;
			compilerDir = String.Empty;
			author = String.Empty;
			company = String.Empty;
			copyrightTemplate = String.Empty;
			language = String.Empty;
			logDir = String.Empty;
			logLevel = Log.LogLevel.Normal;
			logsToKeep = 5;
			uiCulture = String.Empty;
			cfgFileName = GetFileName();
			cleanOnExit = true;
			checkForUpdates = true;
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
				// Set name of configuration file to read
				IniFile.filePath = fileToRead;
				
				// Read the configuration settings
				author = IniFile.IniReadValue("Identification", "Author");
				company = IniFile.IniReadValue("Identification", "Company");
				copyrightTemplate = IniFile.IniReadValue("Copyright", "CopyrightTemplate");
				language = IniFile.IniReadValue("Settings", "Language");
				uiCulture = IniFile.IniReadValue("Settings", "UserInterface");
				logDir = IniFile.IniReadValue("Logging", "LogDir");
				workingDir = IniFile.IniReadValue("Directories", "Working");
				compilerDir = IniFile.IniReadValue("Directories", "Compiler");
				templateDir = IniFile.IniReadValue("Directories", "Template");
				logsToKeep = Convert.ToInt32("0" + IniFile.IniReadValue("Logging", "LogFileCount"));
				int tempLogLevel = Convert.ToInt32("0" + IniFile.IniReadValue("Logging", "LogLevel"));
				switch (tempLogLevel) {
					case (int) Log.LogLevel.None:
						logLevel = Log.LogLevel.None;
						break;
					case (int) Log.LogLevel.Errors:
						logLevel = Log.LogLevel.Errors;
						break;
					case (int) Log.LogLevel.Normal:
						logLevel = Log.LogLevel.Normal;
						break;
					case (int) Log.LogLevel.Debug:
						logLevel = Log.LogLevel.Debug;
						break;
					default:
						logLevel = Log.LogLevel.Normal;
						break;
				}
				string tCleanup = IniFile.IniReadValue("Settings", "CleanOnExit");
				cleanOnExit = (tCleanup.Trim() + "Y").ToUpper().StartsWith("Y");
				string tCheckUpdates = IniFile.IniReadValue("Settings", "CheckForUpdates");
				checkForUpdates = (tCheckUpdates.Trim() + "Y").ToUpper().StartsWith("Y");
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

		// ==============================================================================
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
			tempString.Append("Compiler Dir: ");
			tempString.AppendLine(compilerDir);
			tempString.Append("Template Dir: ");
			tempString.AppendLine(templateDir);
			tempString.Append("Default Project Language: ");
			tempString.AppendLine(language);
			tempString.Append("User Interface Language: ");
			tempString.AppendLine(uiCulture);
			tempString.Append("Check for Program Updates on Startup: ");
			if ( checkForUpdates )
			{
				tempString.AppendLine("Yes");
			}
			else
			{
				tempString.AppendLine("No");
			}
			tempString.Append("Remove working files on exit: ");
			if ( cleanOnExit )
			{
				tempString.AppendLine("Yes");
			}
			else
			{
				tempString.AppendLine("No");
			}
			MessageBox.Show( tempString.ToString(), "Current Settings");
		}
		#endregion
	}
}
