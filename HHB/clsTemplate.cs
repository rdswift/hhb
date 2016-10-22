/*
 * Created by SharpDevelop.
 * User: bob
 * Date: 2016-10-14
 * Time: 11:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO.Compression;
using Ini;

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
		private string _company;
		private string _contact;
		private string _email;
		private string _website;
		private string _version;
		private string _date;
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
        	company = "";
        	contactName = "";
        	contactEmail = "";
        	contactWebsite = "";
        	version = "";
        	revisionDate = "";
        }
		
		// ==============================================================================
		/// <summary>
		/// Unpack the template information from the archive and populate the class variables
		/// </summary>
		/// <returns>True on success, otherwise false</returns>
		private bool UnpackTemplateInfo()
		{
			string tempFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), @"template.txt");
			
			using (ZipArchive zip = ZipFile.OpenRead(this.fileName))
			{
				 foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    if (entry.FullName.Equals("template.txt", StringComparison.OrdinalIgnoreCase))
                    {
                    	entry.ExtractToFile(tempFile, true);
                    }
                }
			}
			
			if (System.IO.File.Exists(tempFile))
			{
				IniFile ini = new IniFile(tempFile);
				id = ini.IniReadValue("Identification", "ID");
				title = ini.IniReadValue("Identification", "Title");
				description = ini.IniReadValue("Identification", "Description");
				author = ini.IniReadValue("Developer", "Author");
				company = ini.IniReadValue("Developer", "Company");
				contactName = ini.IniReadValue("Developer", "Contact");
				contactEmail = ini.IniReadValue("Developer", "Email");
				contactWebsite = ini.IniReadValue("Developer", "Website");
				version = ini.IniReadValue("Miscellaneous", "Version");
				revisionDate = ini.IniReadValue("Miscellaneous", "Date");
				license = ini.IniReadValue("Miscellaneous", "License");
				System.IO.File.Delete(tempFile);
			}
			else
			{
				return false;
			}
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
			fileName = templateFile;
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
		/// Company providing the HHBuilder template
		/// </summary>
		public string company
		{
			get{ return _company.Trim(); }
			set{ _company = value.Trim(); }
		}
		
		/// <summary>
		/// Contact name regarding the HHBuilder template
		/// </summary>
		public string contactName
		{
			get{ return _contact.Trim(); }
			set{ _contact = value.Trim(); }
		}

		/// <summary>
		/// Contact email regarding the HHBuilder template
		/// </summary>
		public string contactEmail
		{
			get{ return _email.Trim(); }
			set{ _email = value.Trim(); }
		}

		/// <summary>
		/// Contact website regarding the HHBuilder template
		/// </summary>
		public string contactWebsite
		{
			get{ return _website.Trim(); }
			set{ _website = value.Trim(); }
		}

		/// <summary>
		/// Version of the HHBuilder template
		/// </summary>
		public string version
		{
			get{ return _version.Trim(); }
			set{ _version = value.Trim(); }
		}

		/// <summary>
		/// Revision date of the HHBuilder template
		/// </summary>
		public string revisionDate
		{
			get{ return _date.Trim(); }
			set{ _date = value.Trim(); }
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
		
		// ==============================================================================
		/// <summary>
		/// Displays all template information in a messagebox 
		/// </summary>
		public void showAll()
		{
			System.Text.StringBuilder info = new System.Text.StringBuilder();
			info.AppendFormat("ID: {0}\n", id);
			info.AppendFormat("Title: {0}\n", title);
			info.AppendFormat("Version: {0}\n", version);
			info.AppendFormat("Revision Date: {0}\n", revisionDate);
			info.AppendFormat("License: {0}\n\n", license);
			info.AppendFormat("Description: {0}\n\n", description);
			info.AppendFormat("Author: {0}\n", author);
			info.AppendFormat("Company: {0}\n", company);
			info.AppendFormat("Contact: {0}\n", contactName);
			info.AppendFormat("Email: {0}\n", contactEmail);
			info.AppendFormat("Website: {0}\n", contactWebsite);
			System.Windows.Forms.MessageBox.Show(info.ToString(), "Template Information");
		}
		
		// ==============================================================================
		/// <summary>
		/// Get list of all available templates from the specified directory<br />Note that templates located in the program directory are included automatically.
		/// </summary>
		/// <param name="templateDirectory">Template storage directory</param>
		/// <returns>Array of available templates as HHBTemplate objects</returns>
		public static System.Collections.Generic.IList<HHBTemplate> AvailableTemplates(string templateDirectory)
		{
			System.Collections.Generic.IList<HHBTemplate> ret = new System.Collections.Generic.List<HHBTemplate>();
			string searchDir = System.Windows.Forms.Application.StartupPath;
			System.IO.DirectoryInfo directorySelected = new System.IO.DirectoryInfo(searchDir);
            foreach (System.IO.FileInfo templateFile in directorySelected.GetFiles("*.hhbt"))
            {
            	HHBTemplate tempTemplate = new HHBTemplate(templateFile.FullName);
            	if ( !String.IsNullOrEmpty(tempTemplate.title) )
            	{
            		ret.Add(tempTemplate);
            	}
            }
            if ( (!String.IsNullOrEmpty(templateDirectory)) && (System.IO.Directory.Exists(templateDirectory)) )
            {
            	directorySelected = new System.IO.DirectoryInfo(templateDirectory);
            	foreach (System.IO.FileInfo templateFile in directorySelected.GetFiles("*.hhbt"))
            	{
            		HHBTemplate tempTemplate = new HHBTemplate(templateFile.FullName);
            		if ( !String.IsNullOrEmpty(tempTemplate.title) )
            		{
            			ret.Add(tempTemplate);
            		}
            	}
            }
            return ret;
		}
		#endregion
		
	}
}
