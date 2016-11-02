/*
 * Created by SharpDevelop.
 * User: bob
 * Date: 2016-10-14
 * Time: 11:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.IO.Compression;
using Ini;
using System.Data;
using System.Security;

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
		private static string _workingDir = "";		// Should be the same value for all template objects.  Only needs to be set once.
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
        	//workingDir = String.Empty;
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
		/// Unpack the specified file from the HTML Help template archive.
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
		/// Deletes the specified file
		/// </summary>
		/// <param name="fileNameToDelete">Full path and name of the file to delete</param>
		/// <returns>True on success, otherwise false.</returns>
		private bool DeleteTempFile(string fileNameToDelete)
		{
			bool ret = true;
			if ( !String.IsNullOrWhiteSpace(fileNameToDelete) )
			{
				try
				{
					System.IO.File.Delete(fileNameToDelete);
				}
				catch (Exception ex)
				{
					Log.Error("Error deleting file: " + fileNameToDelete);
					Log.Exception(ex);
					ret = false;
				}
			}
			return ret;
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
				DeleteTempFile(tempFile);
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
		/// Creates a working subdirectory and confirms that it can be properly accessed.
		/// </summary>
		/// <param name="workingDirectory">Base directory in which the specified subdirectory will be created.</param>
		/// <param name="subdirectoryName">Working subdirectory to create.</param>
		/// <returns>The full path to the working subdirectory created, or an empty string on error.</returns>
		private string MakeWorkingSub(string workingDirectory, string subdirectoryName)
		{
			if ( String.IsNullOrWhiteSpace(subdirectoryName) )
			{
				return String.Empty;
			}
			
			// Ensure proper working directory and update the current object's property
			if ( String.IsNullOrWhiteSpace(workingDirectory) )
			{
				if ( String.IsNullOrWhiteSpace(workingDir) )
				{
					workingDir = Path.GetTempPath();
				}
			}
			else
			{
				workingDir = workingDirectory;
			}
			
			// Build program specific directory under the specified working directory
			string workingSub = Path.Combine(workingDir, subdirectoryName);
			
			try
			{
				if ( Directory.Exists(workingSub) )
				{
					// Remove the existing directory to clear out any files and subdirectories
					Directory.Delete(workingSub, true);
				}
				
				// Create the working directory.
				Directory.CreateDirectory(workingSub);
			}
			catch (Exception ex)
			{
				string errorMessage = "Unable to access working directory: " + workingDir;
				Log.Error(errorMessage);
				Log.Exception(ex);
				Log.ErrorBox(errorMessage);
				return String.Empty;
			}
			
			return workingSub;
		}
		
		// ==============================================================================
		/// <summary>
		/// Write the template.xml file to the specified directory.
		/// </summary>
		/// <param name="workingSub">Directory to save the output file.</param>
		/// <returns>True on success, otherwise false.</returns>
		private bool WriteInformationXML(string workingSub)
		{
			if ( String.IsNullOrWhiteSpace(workingSub) )
			{
				return false;
			}
			
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Clear();
			sb.AppendLine("<?xml version=\"1.0\" standalone=\"yes\"?>");
			sb.AppendLine("<HelpTemplate>");
			sb.AppendLine("  <TemplateInfo>");
			sb.AppendFormat("    <ID>{0}</ID>\n", SecurityElement.Escape(this.id));
			sb.AppendFormat("    <Title>{0}</Title>\n", SecurityElement.Escape(this.title));
			sb.AppendFormat("    <Description>{0}</Description>\n", SecurityElement.Escape(this.description));
			sb.AppendFormat("    <Author>{0}</Author>\n", SecurityElement.Escape(this.author));
			sb.AppendFormat("    <Company>{0}</Company>\n", SecurityElement.Escape(this.company));
			sb.AppendFormat("    <ContactName>{0}</ContactName>\n", SecurityElement.Escape(this.contactName));
			sb.AppendFormat("    <ContactEmail>{0}</ContactEmail>\n", SecurityElement.Escape(this.contactEmail));
			sb.AppendFormat("    <ContactWebsite>{0}</ContactWebsite\n", SecurityElement.Escape(this.contactWebsite));
			sb.AppendFormat("    <Version>{0}</Version>\n", SecurityElement.Escape(this.version));
			sb.AppendFormat("    <RevisionDate>{0}</RevisionDate>\n", SecurityElement.Escape(this.revisionDate));
			sb.AppendFormat("    <LicenseTitle>{0}</LicenseTitle>\n", SecurityElement.Escape(this.licenseTitle));
			sb.AppendLine("  </TemplateInfo>");
			sb.AppendLine("</HelpTemplate>");
			
			string outFile = Path.Combine(workingSub, "template.xml");
			try
			{
				File.WriteAllText(outFile, sb.ToString());
			}
			catch (Exception ex)
			{
				Log.Error("Error writing " + outFile);
				Log.Exception(ex);
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
		/// Sets the working directory for all HHTemplate objects
		/// </summary>
		/// <param name="workingDirectory">Working directory to use.</param>
		public static void SetWorkingDir(string workingDirectory)
		{
			_workingDir = workingDirectory.Trim();
		}
		
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
		/// Builds the HTML Help Builder template file (.hhbt)
		/// <para>If the working directory is not provided, the workingDir property of the current HHBTemplate object will be used. If the 
		/// workingDir property is empty, a default working directory will be used.</para>
		/// <para>If the output path and filename is not provided, the fileName property of the current HHBTemplate object will be used.</para>
		/// <para>If the output file exists, it will be overwritten.</para>
		/// </summary>
		/// <param name="htmlDirectory">The directory containing the template.htm and LICENSE files and HTML support files subdirectories.</param>
		/// <returns>True on success, otherwise false.</returns>
		public bool PackTemplatePackage(string htmlDirectory)
		{
			return PackTemplatePackage(htmlDirectory, workingDir, this.fileName);
		}

		// ==============================================================================
		/// <summary>
		/// Builds the HTML Help Builder template file (.hhbt)
		/// <para>If the working directory is not provided, the workingDir property of the current HHBTemplate object will be used. If the 
		/// workingDir property is empty, a default working directory will be used.</para>
		/// <para>If the output path and filename is not provided, the fileName property of the current HHBTemplate object will be used.</para>
		/// </summary>
		/// <param name="htmlDirectory">The directory containing the template.htm and LICENSE files and HTML support files subdirectories.</param>
		/// <param name="workingDirectory">The directory used for assembling the help template package.</param>
		/// <para>If the output file exists, it will be overwritten.</para>
		/// <returns>True on success, otherwise false.</returns>
		public bool PackTemplatePackage(string htmlDirectory, string workingDirectory)
		{
			return PackTemplatePackage(htmlDirectory, workingDirectory, this.fileName);
		}

		// ==============================================================================
		/// <summary>
		/// Builds the HTML Help Builder template file (.hhbt)
		/// <para>If the working directory is not provided, the workingDir property of the current HHBTemplate object will be used. If the 
		/// workingDir property is empty, a default working directory will be used.</para>
		/// <para>If the output path and filename is not provided, the fileName property of the current HHBTemplate object will be used.</para>
		/// <para>If the output file exists, it will be overwritten.</para>
		/// </summary>
		/// <param name="htmlDirectory">The directory containing the template.htm and LICENSE files and HTML support files subdirectories.</param>
		/// <param name="workingDirectory">The directory used for assembling the help template package.</param>
		/// <param name="outputPathAndFileName">The full path and filename of the resulting template file.</param>
		/// <returns>True on success, otherwise false.</returns>
		public bool PackTemplatePackage(string htmlDirectory, string workingDirectory, string outputPathAndFileName)
		{
			// Confirm valid output file name
			if ( String.IsNullOrWhiteSpace(outputPathAndFileName) )
			{
				string error = "Missing template output file name.";
				Log.Error(error);
				Log.ErrorBox(error);
				return false;
			}
			
			// Confirm valid HTML directory
			if ( (String.IsNullOrWhiteSpace(htmlDirectory)) || (!Directory.Exists(htmlDirectory)) )
			{
				string error = "Missing or invalid HTML directory.";
				Log.Error(error);
				Log.ErrorBox(error);
				return false;
			}
			
			// Confirm template.htm file exists
			if ( !File.Exists(Path.Combine(htmlDirectory, "template.htm")) )
			{
				string error = "Missing template.htm file.";
				Log.Error(error);
				Log.ErrorBox(error);
				return false;
			}
			
			// Confirm LICENSE file exists
			if ( !File.Exists(Path.Combine(htmlDirectory, "LICENSE")) )
			{
				string error = "Missing LICENSE file.";
				Log.Error(error);
				Log.ErrorBox(error);
				return false;
			}
			
			// Validate current template object information
			if ( String.IsNullOrWhiteSpace(this.id) )
			{
				this.id = GetID();
			}
			
			if ( String.IsNullOrWhiteSpace(this.title) )
			{
				this.title = "Title not specified";
			}
			
			if ( String.IsNullOrWhiteSpace(this.description) )
			{
				this.description = "No description provided.";
			}
			
			if ( String.IsNullOrWhiteSpace(this.licenseTitle) )
			{
				this.licenseTitle = "License type not specified";
			}
			
			if ( String.IsNullOrWhiteSpace(this.version) )
			{
				this.version = "1.0";
			}
			
			if ( String.IsNullOrWhiteSpace(this.revisionDate) )
			{
				this.revisionDate = DateTime.Now.ToString("yyyy-MM-dd");
			}
			
			// Create the working directory for the assembly
			string workingSub = MakeWorkingSub(workingDirectory, "HHBTemplateBuilder");
			if ( String.IsNullOrWhiteSpace(workingSub) )
			{
				return false;
			}
			
			// Create template.xml file
			if ( !WriteInformationXML(workingSub) )
			{
				string error = "Problem writing the template information file.";
				Log.Error(error);
				Log.ErrorBox(error);
				return false;
			}
			
			// Pack the LICENSE and HTML files
			try
			{
				// Remove output file if it already exists
				if ( File.Exists(outputPathAndFileName) )
				{
					if ( !DeleteTempFile(outputPathAndFileName) )
					{
						Log.ErrorBox("Unable to delete existing file: " + outputPathAndFileName);
						return false;
					}
				}
				
				ZipFile.CreateFromDirectory(htmlDirectory, outputPathAndFileName);
			}
			catch (Exception ex)
			{
				string error = "Problem creating the HTML Help template file.";
				Log.Error(error);
				Log.Exception(ex);
				Log.ErrorBox(error);
				return false;
			}
			
			// Add the template.xml file to the template package
			try
			{
				using ( ZipArchive templatePackage = ZipFile.Open(outputPathAndFileName, ZipArchiveMode.Update) )
				{
					templatePackage.CreateEntryFromFile(Path.Combine(workingSub, "template.xml"), "template.xml");
				}
			}
			catch (Exception ex)
			{
				string error = "Problem adding the template information to the HTML Help template file.";
				Log.Error(error);
				Log.Exception(ex);
				Log.ErrorBox(error);
				return false;
			}
			
			// Clean up temporary working files and directory
			try
			{
				Directory.Delete(workingSub, true);
			}
			catch (Exception ex)
			{
				string error = "Problem removing the temporary files and working directory: " + workingSub;
				Log.Error(error);
				Log.Exception(ex);
			}
			
			Log.Info("HTML Help template file created successfully: " + outputPathAndFileName);
			
			return true;
		}
		
		// ==============================================================================
		/// <summary>
		/// Unpacks the template file to the working directory 
		/// </summary>
		/// <returns>True on success, otherwise false.</returns>
		public bool UnpackTemplatePackage()
		{
			return UnpackTemplatePackage(workingDir);
		}
		
		// ==============================================================================
		/// <summary>
		/// Unpacks the template file to the working directory 
		/// </summary>
		/// <param name="workingDirectory">The directory used for assembling the help project.</param>
		/// <returns>True on success, otherwise false.</returns>
		public bool UnpackTemplatePackage(string workingDirectory)
		{
			// Confirm template file exists
			if ( !File.Exists(this.fileName) )
			{
				string errorMessage = "Unable to locate template file: " + this.fileName; 
				Log.Error(errorMessage);
				Log.ErrorBox(errorMessage);
				return false;
			}
			
			// Build program specific directory under the specified working directory
			string workingSub = MakeWorkingSub(workingDirectory, "HHBuilderTemp");
			
			if ( String.IsNullOrWhiteSpace(workingSub) )
			{
				return false;
			}
			
			// Remove working directory to ensure it is empty (required by ExtractToDirectory() method)
			if ( Directory.Exists(workingSub) )
			{
				try 
				{
					Directory.Delete(workingSub, true);
				} 
				catch (Exception ex)
				{
					string errorMessage = "Unable to access working directory: " + workingDir;
					Log.Error(errorMessage);
					Log.Exception(ex);
					Log.ErrorBox(errorMessage);
					return false;
				}
			}
			
			// Unpack the files and directories from the template file
			try
			{
				ZipFile.ExtractToDirectory(this.fileName, workingSub);
			}
			catch (Exception ex)
			{
				string errorMessage = "Unable to extract template files to the working directory: " + workingSub;
				Log.Error(errorMessage);
				Log.Exception(ex);
				Log.ErrorBox(errorMessage);
				return false;
			}
			
			string templateFile = Path.Combine(workingSub, "template.html");
			if ( !System.IO.File.Exists(templateFile) )
			{
				string errorMessage = "Missing template.html file in the working directory: " + workingSub;
				Log.Error(errorMessage);
				Log.ErrorBox(errorMessage);
				return false;
			}
			
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

				DeleteTempFile(tempFile);
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
