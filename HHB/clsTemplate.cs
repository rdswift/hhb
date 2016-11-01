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
using System.Data;

namespace HHBuilder
{
	/// <summary>
	/// Manages the templates used by the HHBuilder application.
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
		private string _licenseTitle;
		private string _company;
		private string _contact;
		private string _email;
		private string _website;
		private string _version;
		private string _date;
		private static System.Collections.Generic.IList<HHBTemplate> _templateList = new System.Collections.Generic.List<HHBTemplate>(); 
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
        	fileName = String.Empty;
        	workingDir = String.Empty;
        	title = String.Empty;
        	description = String.Empty;
        	author = String.Empty;
        	licenseTitle = String.Empty;
        	company = String.Empty;
        	contactName = String.Empty;
        	contactEmail = String.Empty;
        	contactWebsite = String.Empty;
        	version = String.Empty;
        	revisionDate = String.Empty;
        }
		
		// ==============================================================================
		/// <summary>
		/// Unpack the template license from the archive and populate the class variables
		/// </summary>
		/// <param name="fileNameToExtract">Name of the file to extract from the template file</param>
		/// <returns>The path of the extracted file on success, otherwise an empty string.</returns>
		private string UnpackTemplateFile(string fileNameToExtract)
		{
			string tempFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), fileNameToExtract);
			if ( System.IO.File.Exists(tempFile) )
			{
				try
				{
					System.IO.File.Delete(tempFile);
				}
				catch (Exception ex)
				{
					Log.Error("Error deleting " + tempFile);
					Log.Exception(ex);
				}
			}
			
			using (ZipArchive zip = ZipFile.OpenRead(this.fileName))
			{
				 foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    if (entry.FullName.Equals(fileNameToExtract, StringComparison.OrdinalIgnoreCase))
                    {
                    	entry.ExtractToFile(tempFile, true);
                    }
                }
			}
			
			if (System.IO.File.Exists(tempFile))
			{
				return tempFile;
			}
			else
			{
				Log.Error("Error extracting " + fileNameToExtract + " from " + this.fileName);
				return String.Empty;
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// Unpack the template information from the archive and populate the class variables
		/// </summary>
		/// <returns>True on success, otherwise false</returns>
		private bool UnpackTemplateInfo()
		{
			string tempFile = UnpackTemplateFile(@"template.xml");
			
			if ( (!String.IsNullOrWhiteSpace(tempFile)) && (System.IO.File.Exists(tempFile)) )
			{
				ReadInformationXML(tempFile);
				
				try
				{
					System.IO.File.Delete(tempFile);
				}
				catch (Exception ex)
				{
					Log.Error("Error deleting information file: " + tempFile);
					Log.Exception(ex);
				}
			}
			else
			{
				Log.Error("Error reading information file: \"" + tempFile + "\"");
				return false;
			}
			
			return true;
		}
		
		// ==============================================================================
		/// <summary>
		/// Reads information from specified template information file
		/// </summary>
		/// <param name="xmlFileToRead">Full path of XML rile to read</param>
		/// <returns>True on success, otherwise false.</returns>
		private bool ReadInformationXML(string xmlFileToRead)
		{
			DataSet ds = new DataSet();
			ds.DataSetName = "HelpTemplate";
			
			// Prepare Template Information DataTable
			DataTable dt = new DataTable();
			dt.TableName = "TemplateInfo";
			
			DataColumn dc;
			
			dc = new DataColumn("ID", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Title", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Description", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Author", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Company", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("ContactName", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("ContactEmail", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("ContactWebsite", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Version", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("RevisionDate", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("LicenseTitle", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			
			ds.Tables.Add(dt);
			
			ds.Clear();
			try
			{
				ds.ReadXml(xmlFileToRead);
			}
			catch (Exception ex)
			{
				Log.Error("Error reading template information file");
				Log.Exception(ex);
				return false;
			}
			
			dt = ds.Tables[0];
			if ( dt.Rows.Count > 0 )
			{
				DataRow dr = dt.Rows[0];
				foreach (DataColumn tDC in dt.Columns) {
					object value = dr[tDC.ColumnName];
					if (value == DBNull.Value)
					{
						dr[tDC.ColumnName] = String.Empty;
					}
				}
				id = (string) dr["ID"];
				title = (string) dr["Title"];
				description = (string) dr["Description"];
				author = (string) dr["Author"];
				company = (string) dr["Company"];
				contactName = (string) dr["ContactName"];
				contactEmail = (string) dr["ContactEmail"];
				contactWebsite = (string) dr["ContactWebsite"];
				version = (string) dr["Version"];
				revisionDate = (string) dr["RevisionDate"];
				licenseTitle = (string) dr["LicenseTitle"];
			}
			else
			{
				Log.Error("No template information found in file: " + xmlFileToRead);
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
		/// Title / description of the license terms for use of the HHBuilder template
		/// </summary>
		public string licenseTitle
		{
			get{ return _licenseTitle.Trim(); }
			set{ _licenseTitle = value.Trim(); }
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
			
			if ( !UnpackTemplateInfo() )
			{
				Log.Error("Error loading template information and license from " + fileToLoad);
				return false;
			}
			return true;
		}
		
		// ==============================================================================
		/// <summary>
		/// Packs the template file from the specified directory 
		/// </summary>
		/// <param name="workingDirectory">The directory containing the template files and subdirectories.</param>
		/// <param name="outputPathAndFileName">Full path and filename of output template file.</param>
		/// <returns>True on success, otherwise false.</returns>
		public bool PackTemplatePackage(string workingDirectory, string outputPathAndFileName)
		{
			// TODO Write the code to pack the template archive from the working directory
			//			- Confirm valid output file name
			//			- Validate current template object information
			//			- Create template.xml file
			//			- Confirm template.xml file exists
			//			- Confirm HTML template file exists
			//			- Confirm LICENSE file exists
			//			- Copy template files and subdirectories to specified output file 
			
			return false;
		}
		
		// ==============================================================================
		/// <summary>
		/// Unpacks the template file to the working directory 
		/// </summary>
		/// <param name="workingDirectory">The directory used for assembling the help project.</param>
		/// <returns>True on success, otherwise false.</returns>
		public bool UnpackTemplatePackage(string workingDirectory)
		{
			// TODO Write the code to unpack the template archive to the working directory
			//			- Confirm template file exists
			//			- Confirm working directory exists
			//			- Unpack the files and directories from the template file
			//			- Confirm HTML template file exists
			
			return false;
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
			info.AppendFormat("License: {0}\n\n", licenseTitle);
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
		/// Get list of all available templates<br />
		/// Note that templates located in the program directory are included automatically.
		/// </summary>
		/// <returns>Array of available templates as HHBTemplate objects</returns>
		public static System.Collections.Generic.IList<HHBTemplate> AvailableTemplates()
		{
			if ( _templateList.Count < 1 )
			{
				ReadAvailableTemplates(String.Empty);
			}
			return _templateList;
		}
		
		// ==============================================================================
		/// <summary>
		/// Get list of all available templates from the specified directory<br />
		/// Note that templates located in the program directory are included automatically.
		/// </summary>
		/// <param name="templateDirectory">Template storage directory</param>
		/// <returns>Array of available templates as HHBTemplate objects</returns>
		public static System.Collections.Generic.IList<HHBTemplate> AvailableTemplates(string templateDirectory)
		{
			ReadAvailableTemplates(templateDirectory);
			return _templateList;
		}
		
		// ==============================================================================
		/// <summary>
		/// Get list of all available templates from the specified directory<br />
		/// and stores them in a static variable for delivery via the AvailableTemplates() method.<br />
		/// Note that templates located in the program directory are included automatically.
		/// </summary>
		/// <param name="templateDirectory">Template storage directory</param>
		public static void ReadAvailableTemplates(string templateDirectory)
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
            _templateList = ret;
		}
		
		// ==============================================================================
		/// <summary>
		/// Unpack the license information from the template archive
		/// </summary>
		/// <returns>The contents of the LICENSE file included with the template</returns>
		public string License()
		{
			string tempFile = UnpackTemplateFile(@"LICENSE");
			string licenseText = String.Empty;
			if ( (!String.IsNullOrWhiteSpace(tempFile)) && (System.IO.File.Exists(tempFile)) )
			{
				try 
				{
					licenseText = System.IO.File.ReadAllText(tempFile);
				}
				catch (Exception ex)
				{
					Log.Exception(ex);
					licenseText = String.Empty;
				}
				
				try
				{
					System.IO.File.Delete(tempFile);
				}
				catch (Exception ex)
				{
					Log.Error("Error deleting information file: " + tempFile);
					Log.Exception(ex);
				}
			}
			
			if ( String.IsNullOrWhiteSpace(licenseText) )
			{
				Log.Error("Error reading information file: \"" + tempFile + "\"");
			}
			
			return licenseText;
		}
		#endregion
	}
}
