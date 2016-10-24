/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-10-22
 * Time: 12:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows.Forms;

namespace HHBuilder
{
	/// <summary>
	/// Methods for compiling a help project.
	/// </summary>
	public static class HHCompile
	{
		#region Private Member Variables
		private static string _workingDir;
		private static string _templateFile;
		#endregion

		#region Private Properties
		#endregion
		
		#region Private Methods
		// ==============================================================================
		/// <summary>
		/// Creates the working directory.  Removes and recreates if it already exists.
		/// </summary>
		/// <returns>True on success, otherwise false.</returns>
		private static bool MakeWorkingDir()
		{
			if ( !Cleanup() )
			{
				string errorMessage = "Error removing old working directory.";
				Log.Error(errorMessage);
				return false;
			}
			
			try
			{
				Directory.CreateDirectory(workingDir);
			}
			catch (Exception ex)
			{
				string errorMessage = "Error creating the working directory.";
				Log.Error(errorMessage);
				Log.Exception(ex);
				return false;
			}
			return true;
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		#endregion
		
		#region Public Properties

		/// <summary>
		/// Working directory (will be deleted and recreated on compile operations)
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
				_workingDir = value.Trim();
			}
		}
		
		/// <summary>
		/// Template file
		/// </summary>
		public static string templateFile
		{
			get {
				if ( String.IsNullOrWhiteSpace(_templateFile) )
				{
					return String.Empty;
				}
				else
				{
					return _templateFile.Trim();
				}
			}
			set
			{
				_templateFile = value.Trim();
			}
		}
		
		#endregion
		
		#region Public Methods
		// ==============================================================================
		/// <summary>
		/// Removes working directory and all contents (files and subdirectories)
		/// </summary>
		/// <returns>True on success, otherwise false.</returns>
		public static bool Cleanup()
		{
			if ( Directory.Exists(workingDir) )
			{
				try
				{
					Directory.Delete(workingDir, true);
				}
				catch (Exception ex)
				{
					Log.Exception(ex);
					return false;
				}
			}
			return true;
		}
		
		// ==============================================================================
		public static bool MakeFiles( System.Windows.Forms.TreeNode rootNode )
		{
			if ( !MakeWorkingDir() )
			{
				string errorMessage = String.Format("Unable to access the working directory:\n\n{0}", workingDir);
				System.Windows.Forms.MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			
			// TODO Include code to check node information, unpack template, make link lists, check links, make files  
			
			return true;
		}
		#endregion
		
	}
}
