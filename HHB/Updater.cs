/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-12-04
 * Time: 10:20
 */
 
using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace HHBuilder
{
	/// <summary>
	/// Checks for program updates via the project's AssemblyInfo.cs file on the Internet.
	/// </summary>
	public static class Updater
	{
		#region Private Member Variables
		// ==============================================================================
		private static string _urlProject = @"https://sourceforge.net/projects/oshhb/";
		private static string _urlDownload = @"https://sourceforge.net/projects/oshhb/files/latest/download";
		private static string _urlRoot = @"https://sourceforge.net/p/oshhb/source/ci/master/tree/";
		private static string _urlToCheck = _urlRoot + @"HHB/Properties/AssemblyInfo.cs?format=raw";
		private static string _urlRevisionNotes = _urlRoot + @"REVISION?format=raw";
		private static AssemblyName _assemblyName = Assembly.GetExecutingAssembly().GetName();
		private static string _programName = _assemblyName.Name;
		private static int _major = _assemblyName.Version.Major;
		private static int _minor = _assemblyName.Version.Minor;
		private static int _build = _assemblyName.Version.Build;
		private static int _revision = _assemblyName.Version.Revision;
		private static int _currentMajor = 0;
		private static int _currentMinor = 0;
		private static int _currentBuild = 0;
		private static bool _checked = false;
		private static bool _updateRequired = false;
		private static string _revisionNotes = String.Empty;
		#endregion

		#region Private Properties
		// ==============================================================================
		#endregion
		
		#region Private Methods
		// ==============================================================================
		/// <summary>
		/// Get the latest version information from the SourceForge website.
		/// <para>Only contacts the website if a successful check has not been completed during the current session.</para>
		/// </summary>
		private static void GetLatestVersionInfo()
		{
			if ( !_checked )
			{
				string content = String.Empty;
				Log.Debug("Checking for update information.");
				using ( WebClient client = new WebClient() )
				{
					try
					{
						Stream stream = client.OpenRead(_urlToCheck);
						StreamReader reader = new StreamReader(stream);
						content = reader.ReadToEnd();
					}
					catch (Exception ex)
					{
						string error = String.Format("Error getting update information from {0}", _urlToCheck);
						Log.Error(error);
						Log.Exception(ex);
						//Log.ErrorBox(error);
						//throw;
					}
				}
				
				//Log.ErrorBox(content);
				
				string testString = "[assembly: AssemblyVersion(\"";
				if ( !String.IsNullOrWhiteSpace(content) )
				{
					Log.Debug("Current version information obtained.");
					string[] sArray = content.Split('\n');
					foreach ( string tLine in sArray )
					{
						if ( tLine.Contains(testString) )
						{
							_checked = true;
							string tString = tLine.Split('"')[1];
							string[] tArray = tString.Split('.');
							if ( (tArray.Length > 0) && (!tArray[0].Contains("*")) )
							{
								_currentMajor = Convert.ToInt32("0" + tArray[0].Trim());
							}
							if ( (tArray.Length > 1) && (!tArray[1].Contains("*")) )
							{
								_currentMinor = Convert.ToInt32("0" + tArray[1].Trim());
							}
							if ( (tArray.Length > 2) && (!tArray[2].Contains("*")) )
							{
								_currentBuild = Convert.ToInt32("0" + tArray[2].Trim());
							}
						}
					}
				}
				
				// Determine if an update is required.
				_updateRequired = (_currentMajor > _major);
				if ( _currentMinor > _minor )
				{
					_updateRequired = true;
				}
				if ( _currentBuild > _build )
				{
					_updateRequired = true;
				}
				
				// Get the latest revision notes if update required.
				if ( _updateRequired )
				{
					Log.Debug("Getting the latest revision notes.");
					using ( WebClient client = new WebClient() )
					{
						try
						{
							Stream stream = client.OpenRead(_urlRevisionNotes);
							StreamReader reader = new StreamReader(stream);
							_revisionNotes = reader.ReadToEnd();
						}
						catch (Exception ex)
						{
							string error = String.Format("Error getting revision notes from {0}", _urlRevisionNotes);
							Log.Error(error);
							Log.Exception(ex);
							_revisionNotes = "Revision notes not currently available.";
							//Log.ErrorBox(error);
							//throw;
						}
					}
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
		/// Indicates whether an update check has been successfully completed this session.
		/// </summary>
		public static bool checkedThisSession
		{
			get{ return _checked; }
		}
		
		// ==============================================================================
		/// <summary>
		/// Indicates whether a newer version of the program is available.
		/// <para>Automatically tries to check the website if that hasn't been done this session.</para>
		/// </summary>
		public static bool updateAvailable
		{
			get
			{
				GetLatestVersionInfo();
				return _updateRequired;
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// Revision notes for the program package from the SourceForge website.
		/// <para>Automatically tries to check the website if that hasn't been done this session.</para>
		/// </summary>
		public static string revisionNotes
		{
			get
			{
				GetLatestVersionInfo();
				return _revisionNotes;
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// The major portion of the revision number of the currently running program.
		/// </summary>
		public static int currentMajor
		{
			get{ return _major; }
		}
		
		// ==============================================================================
		/// <summary>
		/// The minor portion of the revision number of the currently running program.
		/// </summary>
		public static int currentMinor
		{
			get{ return _minor; }
		}
		
		// ==============================================================================
		/// <summary>
		/// The build portion of the revision number of the currently running program.
		/// </summary>
		public static int currentBuild
		{
			get{ return _build; }
		}
		
		// ==============================================================================
		/// <summary>
		/// The major portion of the revision number of the latest version of the program.
		/// <para>Automatically tries to check the website if that hasn't been done this session.</para>
		/// </summary>
		public static int latestMajor
		{
			get
			{
				GetLatestVersionInfo();
				return _currentMajor;
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// The minor portion of the revision number of the latest version of the program.
		/// <para>Automatically tries to check the website if that hasn't been done this session.</para>
		/// </summary>
		public static int latestMinor
		{
			get
			{
				GetLatestVersionInfo();
				return _currentMinor;
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// The build portion of the revision number of the latest version of the program.
		/// <para>Automatically tries to check the website if that hasn't been done this session.</para>
		/// </summary>
		public static int latestBuild
		{
			get
			{
				GetLatestVersionInfo();
				return _currentBuild;
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// The URL of the project site on SourceForge.
		/// </summary>
		public static string projectURL
		{
			get{ return _urlProject; }
		}
		
		// ==============================================================================
		/// <summary>
		/// The URL to dowload the latest version of the program from SourceForge.
		/// </summary>
		public static string downloadURL
		{
			get{ return _urlDownload; }
		}
		
		// ==============================================================================
		/// <summary>
		/// The name of the currently running program.
		/// </summary>
		public static string name
		{
			get{ return _programName; }
		}
		#endregion
		
		#region Public Methods
		// ==============================================================================
		/// <summary>
		/// Gets the version of the currently running program.
		/// </summary>
		/// <returns>A formatted string of the Major.Minor.Build.</returns>
		public static string getCurrentVersion()
		{
			return String.Format("{0}.{1:00}.{2:00}", _major, _minor, _build);
		}
		
		// ==============================================================================
		/// <summary>
		/// Gets the version of the currently running program, including the revision field.
		/// </summary>
		/// <returns>A formatted string of the Major.Minor.Build.Revision.</returns>
		public static string getCurrentVersionWithRevision()
		{
			return String.Format("{0}.{1:00}.{2:00}.{3}", _major, _minor, _build, _revision);
		}
		
		// ==============================================================================
		/// <summary>
		/// Gets the version of the latest version of the program.
		/// </summary>
		/// <returns>A formatted string of the Major.Minor.Build.</returns>
		public static string getLatestVersion()
		{
			GetLatestVersionInfo();
			return String.Format("{0}.{1:00}.{2:00}", _currentMajor, _currentMinor, _currentBuild);
		}
		#endregion
	}
}
