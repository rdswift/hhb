/*
 * Created by SharpDevelop.
 * User: bob
 * Date: 2016-10-14
 * Time: 11:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace HHBuilder
{
	/// <summary>
	/// Templates used by the HHBuilder application
	/// </summary>
	public class HHBTemplate
	{
		#region Private Member Variables
		private string _id;
		private string _fileName;
		private string _workingDir;
		private string _title;
		private string _description;
		private string _author;
		private string _license;
		#endregion

		#region Private Properties
		#endregion
		
		#region Private Methods
        // ==============================================================================
		/// <summary>
		/// Prepare a unique ID based on the current timestamp
		/// </summary>
		/// <returns>
		/// Unique ID string
		/// </returns>
		/// 
		private static string GetID()
		{
			// Time Based Key - should be sufficient for this application
			System.Threading.Thread.Sleep(2);
			return "t" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
		}
		
        // ==============================================================================
		/// <summary>
		/// Initialize private class variables
		/// </summary>
        private void Initialize()
        {
        	id = GetID();
        	fileName = "";
        	workingDir = "";
        	title = "";
        	description = "";
        	author = "";
        	license = "";
        }
		
		// ==============================================================================
		/// <summary>
		/// Unpack the template information from the archive and populate the class variables
		/// </summary>
		/// <returns>True on success, otherwise false</returns>
		private bool UnpackTemplateInfo()
		{
			// TODO Write the code to unpack the template archive info file
			
			//if (!System.IO.File.Exists(FileToLoad)) { return false; }
			//if (!System.IO.Directory.Exists(WorkingDir)) { return false; }
			return true;
		}
		#endregion
		
		#region Constructors
        // ==============================================================================
		/// <summary>
		/// Create a new HHBTemplate object
		/// </summary>
		public HHBTemplate()
		{
			Initialize();
		}
		
        // ==============================================================================
		/// <summary>
		/// Create a new HHBTemplate object
		/// </summary>
		/// <param name="templateFile">Path and filename of the template file to load</param>
		public HHBTemplate(string templateFile)
		{
			Initialize();
			Load();
		}
		#endregion
		
		#region Public Properties
		/// <summary>
		/// Unique identifier for the template
		/// </summary>
		public string id
		{
			get{ return _id.Trim(); }
			set{ _id = value.Trim(); }
		}
		
		/// <summary>
		/// Full path and file name of the template file (.hhbt)
		/// </summary>
		public string fileName
		{
			get{ return _fileName.Trim(); }
			set{ _fileName = value.Trim(); }
		}
			
		/// <summary>
		/// Full path to the working directory
		/// </summary>
		public string workingDir
		{
			get{ return _workingDir.Trim(); }
			set{ _workingDir = value.Trim(); }
		}
		
		/// <summary>
		/// Title of the HHBuilder template
		/// </summary>
		public string title
		{
			get{ return _title.Trim(); }
			set{ _title = value.Trim(); }
		}
		
		/// <summary>
		/// Description of the HHBuilder template
		/// </summary>
		public string description
		{
			get{ return _description.Trim(); }
			set{ _description = value.Trim(); }
		}
		
		/// <summary>
		/// Author of the HHBuilder template
		/// </summary>
		public string author
		{
			get{ return _author.Trim(); }
			set{ _author = value.Trim(); }
		}
		
		/// <summary>
		/// License terms for use of the HHBuilder template
		/// </summary>
		public string license
		{
			get{ return _license.Trim(); }
			set{ _license = value.Trim(); }
		}
		#endregion
		
		#region Public Methods
		// ==============================================================================
		/// <summary>
		/// Loads information from the template file
		/// </summary>
		/// <returns>True on success, otherwise false.</returns>
		public bool Load()
		{
			return Load(this.fileName);
		}
		
		// ==============================================================================
		/// <summary>
		/// Loads information from the template file
		/// </summary>
		/// <param name="fileToLoad">Path and filename of the template file</param>
		/// <returns>True on success, otherwise false.</returns>
		public bool Load(string fileToLoad)
		{
			if (!System.IO.File.Exists(fileToLoad)) { return false; }
			
			if (UnpackTemplateInfo())
			{

				// TODO Write the code to parse the template info file
				
				try
				{
					// Unpack INFO.txt file
					// Parse INFO.txt file for title, description, author
				}
				catch
				{
					return false;
				}
			}
			else
			{
				return false;
			}
			return true;
		}
		
		// ==============================================================================
		/// <summary>
		/// Unpacks the template file to the working directory 
		/// </summary>
		/// <returns>True on success, otherwise false.</returns>
		public bool UnpackTemplatePackage()
		{
			// TODO Write the code to unpack the template archive to the working directory
			
			//if (!System.IO.File.Exists(FileToLoad)) { return false; }
			//if (!System.IO.Directory.Exists(WorkingDir)) { return false; }
			return true;
		}
		#endregion
		
	}
}
