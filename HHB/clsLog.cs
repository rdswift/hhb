/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-10-16
 * Time: 13:46
 */
using System;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace HHBuilder
{
	/// <summary>
	/// Manage the output log for the program, including:<br />
	///  * Store the log file path and create the file if necessary<br />
	///  * Store the preferred logging level<br />
	///  * Log entries based on specified logging level<br />
	///  * Remove log files as required to retain the specified number of session logs<br />
	///  * Display specified error messages in a standard error messagebox
	/// </summary>
	public static class Log
	{
		
		#region Private Member Variables
		private static string _logDir = String.Empty;
		private static string _logFile = String.Format("{0}_{1}.log", Assembly.GetExecutingAssembly().GetName().Name, DateTime.Now.ToString("yyyyMMddHHmmss"));
		private static int _logsToKeep = 5;
		private static LogLevel _level = LogLevel.Normal;
		#endregion

		#region Private Properties
		#endregion
		
		#region Private Methods
		// ==============================================================================
		private static bool MoveLogFiles(string fromDir, string toDir)
		{
			if ( String.IsNullOrWhiteSpace(fromDir) || String.IsNullOrWhiteSpace(toDir) )
			{
				return false;
			}
			
			System.IO.DirectoryInfo directorySelected = new System.IO.DirectoryInfo(fromDir);
			System.IO.FileInfo[] logFiles = directorySelected.GetFiles(String.Format("{0}_*.log", Assembly.GetExecutingAssembly().GetName().Name));
			bool success = true;
			Exception tEx = new Exception("No exception");
			foreach (FileInfo logFile in logFiles) {
				try
				{
					string fromFile = logFile.FullName;
					string toFile = Path.Combine(toDir, logFile.Name);
					File.Copy(fromFile, toFile, true);
					if ( File.Exists(toFile) )
					{
						File.Delete(fromFile);
					}
					else
					{
						tEx = new FileNotFoundException("Unable to move file", logFile.Name);
						tEx.Source = String.Format("{0}.Log", Assembly.GetExecutingAssembly().GetName().Name);
						success = false;
					}
				}
				catch (Exception ex)
				{
					tEx = ex;
					success = false;
					//throw;
				}
			}
			if ( !success )
			{
				string errorMessage = "Problem moving existing log files to new location.";
				Log.Error(errorMessage);
				Log.Exception(tEx);
				Log.ErrorBox(errorMessage);
			}
			return success;
		}
		
		// ==============================================================================
		private static void writeToLog( string lineToWrite )
		{
			if ( !String.IsNullOrEmpty(fileName) )
			{
				try
				{
					string output = String.Format("{0} {1}\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), lineToWrite);
					System.IO.File.AppendAllText(fileName, output);
				}
				catch
				{
					ErrorBox("Unable to write to the specified log file.\n");
				}
			}
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		#endregion
		
		#region Public Properties
		// ==============================================================================
		/// <summary>
		/// Available levels of program logging
		/// </summary>
		public enum LogLevel
		{
			/// <summary>
			/// No logging.
			/// </summary>
			None = 0,
			
			/// <summary>
			/// Logs errors and exceptions.
			/// </summary>
			Errors = 1,
			
			/// <summary>
			/// Logs normal information and all errors and exceptions.
			/// </summary>
			Normal = 2,
			
			/// <summary>
			/// Logs all messages.
			/// </summary>
			Debug = 3
		};
		
		// ==============================================================================
		/// <summary>
		/// The directory to store the log files.
		/// </summary>
		public static string logDir
		{
			get{
				if ( String.IsNullOrWhiteSpace(_logDir) )
				{
					_logDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), Assembly.GetExecutingAssembly().GetName().Name);
				}
				return _logDir.Trim();
			}
			set
			{
				string tValue = value.Trim();
				if ( !Directory.Exists(tValue) )
				{
					try
					{
						Directory.CreateDirectory(tValue);
					}
					catch (Exception ex)
					{
						string errorMessage = String.Format("Unable to access log directory {0}", tValue);
						Log.Error(errorMessage);
						Log.Exception(ex);
						Log.ErrorBox(errorMessage);
						tValue = String.Empty;
						//throw;
					}
				}
				if ( String.IsNullOrWhiteSpace(tValue) )
				{
					tValue = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), Assembly.GetExecutingAssembly().GetName().Name);
				}
				if ( !String.IsNullOrWhiteSpace(_logDir) )		// Don't try to move files during startup
				{
					if ( Path.GetFullPath(_logDir.Trim()).ToUpper() != Path.GetFullPath(tValue).ToUpper() )
					{
						MoveLogFiles(_logDir.Trim(), Path.GetFullPath(tValue));
					}
				}
				_logDir = tValue;
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// The level of information to log.
		/// </summary>
		public static LogLevel level
		{
			get{ return _level; }
			set{ _level = value; }
		}
		
		// ==============================================================================
		/// <summary>
		/// The maximum number of log files to keep.
		/// </summary>
		public static int filesToKeep
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
		/// The full path and file name of the current log file.
		/// </summary>
		public static string fileName
		{
			get
			{
				if ( String.IsNullOrWhiteSpace(_logDir) )
				{
					_logDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), Assembly.GetExecutingAssembly().GetName().Name);
				}
				return Path.Combine(_logDir, _logFile);
			}
		}
		#endregion
		
		#region Public Methods
		// ==============================================================================
		/// <summary>
		/// Write a line of information to the log file.
		/// </summary>
		/// <param name="lineToWriteToLogFile">Text line to write</param>
		public static void Info( string lineToWriteToLogFile )
		{
			if ( (level == LogLevel.Normal) || (level == LogLevel.Debug) )
			{
				writeToLog("  " + lineToWriteToLogFile);
			}
		}

		// ==============================================================================
		/// <summary>
		/// Write a line of error information to the log file.
		/// </summary>
		/// <param name="lineToWriteToLogFile">Text line to write</param>
		public static void Error( string lineToWriteToLogFile )
		{
			if ( level != LogLevel.None )
			{
				writeToLog("! " + lineToWriteToLogFile);
			}
		}

		// ==============================================================================
		/// <summary>
		/// Write a line of debug information to the log file.
		/// </summary>
		/// <param name="lineToWriteToLogFile">Text line to write</param>
		public static void Debug( string lineToWriteToLogFile )
		{
			if ( level == LogLevel.Debug )
			{
				writeToLog("* " + lineToWriteToLogFile);
			}
		}

		// ==============================================================================
		/// <summary>
		/// Write exception information to the log file.
		/// </summary>
		/// <param name="exceptionToWriteToLogFile">Exception object to write</param>
		public static void Exception( Exception exceptionToWriteToLogFile )
		{
			if ( level != LogLevel.None )
			{
				string offset = "\n" + ("").PadLeft(26);
				System.Text.StringBuilder output = new System.Text.StringBuilder("! ");
				output.Append('-', 53);
				output.AppendFormat("{0}Exception: {1}", offset, exceptionToWriteToLogFile.Message);
				string tempString = "Not defined";
				if ( !String.IsNullOrEmpty(exceptionToWriteToLogFile.Source) )
				{
					tempString = exceptionToWriteToLogFile.Source;
				}
				output.AppendFormat("{0}Source: {1}", offset, tempString);
				if ( !String.IsNullOrEmpty(exceptionToWriteToLogFile.StackTrace) )
				{
					output.Append(offset);
					output.AppendLine(exceptionToWriteToLogFile.StackTrace.Replace("\n", offset));
				}
				output.Append(offset);
				output.Append('-', 53);
				writeToLog(output.ToString());
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// Displays a standard error messagebox with an Okay button.
		/// </summary>
		/// <param name="message">A string containing the message to be displayed.</param>
		/// 
		public static void ErrorBox(string message)
		{
			MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		
		// ==============================================================================
		/// <summary>
		/// Displays a standard error messagebox with an Okay button.
		/// </summary>
		/// <param name="message">A string containing the message to be displayed.</param>
		/// <param name="title">A string containing the messagebox title to be displayed.</param>
		/// 
		public static void ErrorBox(string message, string title)
		{
			MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		
		// ==============================================================================
		/// <summary>
		/// Removes older log files leaving only the specified number of remaining files.
		/// </summary>
		public static void CleanLogFiles()
		{
			System.IO.DirectoryInfo directorySelected = new System.IO.DirectoryInfo(logDir);
			System.IO.FileInfo[] logFiles = directorySelected.GetFiles(String.Format("{0}_*.log", Assembly.GetExecutingAssembly().GetName().Name));
			Array.Sort(logFiles, (f1, f2) => f1.Name.CompareTo(f2.Name));
			for (int i = 0; i < logFiles.Length - filesToKeep; i++)
			{
				Log.Debug("Deleting old log file: " + logFiles[i].FullName);
				try
				{
					File.Delete(logFiles[i].FullName);
				}
				catch (Exception ex)
				{
					string error = "Problem deleting log file: " + logFiles[i].FullName;
					Log.Error(error);
					Log.Exception(ex);
					Log.ErrorBox(error);
					//throw;
				}
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// Log fatal error and exit with message to the user
		/// </summary>
		/// <param name="ex">Exception to log and display</param>
		public static void ErrorExit(Exception ex)
		{
			if ( String.IsNullOrEmpty(ex.Source) )
			{
				ex.Source = "Undefined Source";
			}
			Log.Exception(ex);
			System.Text.StringBuilder errorMessage = new System.Text.StringBuilder();
			errorMessage.Append("The program has encountered an error, and will now shut down.\n\nException: ");
			errorMessage.AppendLine(ex.Message);
			errorMessage.Append("Source: ");
			errorMessage.AppendLine(ex.Source);
			if ( !String.IsNullOrEmpty(ex.StackTrace) )
			{
				errorMessage.AppendLine(ex.StackTrace);
			}
			Log.ErrorBox(errorMessage.ToString());
			Application.Exit();
		}
		#endregion
	}
}
