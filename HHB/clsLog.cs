/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-10-16
 * Time: 13:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace HHBuilder
{
	/// <summary>
	/// Manage the output log for the program, including:<br />
	///  * Store the log file path and create the file if necessary<br />
	///  * Store the preferred logging level<br />
	///  * Log entries based on specified logging level<br />
	///  * Display specified error messages in a standard error messagebox
	/// </summary>
	public static class Log
	{
		#region Private Member Variables
		private static string _logFile = "";
		#endregion

		#region Private Properties
		#endregion
		
		#region Private Methods
		// ==============================================================================
		
		private static void writeToLog( string lineToWrite )
		{
			if ( !String.IsNullOrEmpty(logFile) )
			{
				try
				{
					string output = String.Format("{0} {1}\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), lineToWrite);
					System.IO.File.AppendAllText(logFile, output);
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
		
		/// <summary>
		/// The full path and file name of the log file.
		/// </summary>
		public static string logFile
		{
			get{ return _logFile.Trim(); }
			set{ _logFile = value.Trim(); }
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
			writeToLog("  " + lineToWriteToLogFile);
		}

		// ==============================================================================
		/// <summary>
		/// Write a line of error information to the log file.
		/// </summary>
		/// <param name="lineToWriteToLogFile">Text line to write</param>
		public static void Error( string lineToWriteToLogFile )
		{
			writeToLog("! " + lineToWriteToLogFile);
		}

		// ==============================================================================
		/// <summary>
		/// Write a line of debug information to the log file.
		/// </summary>
		/// <param name="lineToWriteToLogFile">Text line to write</param>
		public static void Debug( string lineToWriteToLogFile )
		{
			writeToLog("+ " + lineToWriteToLogFile);
		}

		// ==============================================================================
		/// <summary>
		/// Write exception information to the log file.
		/// </summary>
		/// <param name="exceptionToWriteToLogFile">Exception object to write</param>
		public static void Exception( Exception exceptionToWriteToLogFile )
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
		#endregion
	}
}
