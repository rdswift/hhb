/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-10-22
 * Time: 12:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
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
		//private static string _workingDir;
		private static string _templateFile = String.Empty;
		private static string _homeID = String.Empty;
		private static string _headerCSS = String.Empty;
		private static string _headerScripts = String.Empty;
		private static DataSet _nodeDS = InitializeNodeDataset();
		#endregion

		#region Private Properties
		#endregion
		
		#region Private Methods
		// ==============================================================================
		private static bool MakeHTMLFiles()
		{
			bool ret = true;	// Return code
			
			// Load template file
			string htmlTemplate = String.Empty;
			try
			{
				htmlTemplate = File.ReadAllText(Path.Combine(HBSettings.projectBuildDir, "template.html"));
			}
			catch (Exception ex)
			{
				string err = "Invalid template.  Unable to read the template.html file.";
				Log.Error(err);
				Log.Exception(ex);
				Log.ErrorBox(err);
				return false;
				//throw;
			}
			
			string homeLink = String.Empty;
			string homeText = String.Empty;
			string homeNumber = String.Empty;
			DataRow tHomeDR = _nodeDS.Tables[0].Rows.Find(_homeID);
			if ( tHomeDR != null )
			{
				homeLink = tHomeDR["FileName"].ToString();
				homeText = tHomeDR["Title"].ToString();
				homeNumber = tHomeDR["IndexPath"].ToString().TrimStart('0');
			}
			
			// Process each row in the HTML items dataset
			foreach (DataRow dr in _nodeDS.Tables[0].Rows) {
				if ( (bool) dr["ShowScreen"] )
				{
					// Set home link information
					if ( String.IsNullOrWhiteSpace(homeLink) )
					{
						homeLink = dr["FileName"].ToString();
						homeText = dr["Title"].ToString();
						homeNumber = dr["IndexPath"].ToString().TrimStart('0');
					}
					
					// Create style entry to hide unwanted sections
					bool bTest = false;
					System.Text.StringBuilder sb = new System.Text.StringBuilder();
					sb.AppendLine("<style>");
					if ( !( (bool) dr["ShowTitle"] ) )
					{
						sb.AppendLine(".TITLE { display: none; }");
						bTest = true;
					}
					if ( !( (bool) dr["ShowHeader"] ) )
					{
						sb.AppendLine(".HEADER { display: none; }");
						bTest = true;
					}
					if ( !( (bool) dr["ShowFooter"] ) )
					{
						sb.AppendLine(".FOOTER { display: none; }");
						bTest = true;
					}
					
					string references = "";
					if ( String.IsNullOrWhiteSpace(dr["ReferenceLinks"].ToString()) )
					{
						sb.AppendLine(".REFERENCES { display: none; }");
						bTest = true;
					}
					else
					{
						System.Text.StringBuilder sbRef = new System.Text.StringBuilder();
						string[] refArray = dr["ReferenceLinks"].ToString().Split('|');
						foreach (string tRef in refArray)
						{
							string tRefLink = String.Empty;
							string tRefText = "Error! Missing reference.";
							DataRow tRefDR = _nodeDS.Tables[0].Rows.Find(tRef);
							if ( tRefDR != null )
							{
								tRefLink = tRefDR["FileName"].ToString();
								tRefText = System.Net.WebUtility.HtmlEncode(tRefDR["LinkDesc"].ToString());
							}
							sbRef.AppendFormat("<li class=\"reference\"><a href=\"{0}\">{1}</a></li>\n", tRefLink, tRefText);
						}
						references = sbRef.ToString();
					}
					sb.AppendLine("</style>");
					
					string hideItems = "";
					if ( bTest )
					{
						hideItems = sb.ToString();
					}
					
					string repBody = dr["Body"].ToString();
					
					
					
					
					
					
					
					// TODO: Insert body text preprocessing here.
					
					
					
					
					
					
					string tHTML = htmlTemplate;
					tHTML = tHTML.Replace("</head>", _headerScripts + _headerCSS + hideItems + "</head>");
					tHTML = tHTML.Replace("{BODY}", repBody);
					tHTML = tHTML.Replace("{TITLE}", System.Net.WebUtility.HtmlEncode(dr["Title"].ToString()));
					tHTML = tHTML.Replace("{PREVLINK}", System.Net.WebUtility.HtmlEncode(dr["PrevLink"].ToString()));
					tHTML = tHTML.Replace("{NEXTLINK}", System.Net.WebUtility.HtmlEncode(dr["NextLink"].ToString()));
					tHTML = tHTML.Replace("{PREVTEXT}", System.Net.WebUtility.HtmlEncode(dr["PrevText"].ToString()));
					tHTML = tHTML.Replace("{NEXTTEXT}", System.Net.WebUtility.HtmlEncode(dr["NextText"].ToString()));
					tHTML = tHTML.Replace("{PREVNUMBER}", System.Net.WebUtility.HtmlEncode(dr["PrevNumber"].ToString()));
					tHTML = tHTML.Replace("{NEXTNUMBER}", System.Net.WebUtility.HtmlEncode(dr["NextNumber"].ToString()));
					tHTML = tHTML.Replace("{NUMBER}", System.Net.WebUtility.HtmlEncode(dr["IndexPath"].ToString().TrimStart('0')));
					//tHTML = tHTML.Replace("{}", dr[""]);					// TODO: Accommodate processing picture links.
					//tHTML = tHTML.Replace("{}", dr[""]);
					//tHTML = tHTML.Replace("{}", dr[""]);
					//tHTML = tHTML.Replace("{}", dr[""]);
					//tHTML = tHTML.Replace("{}", dr[""]);
					//tHTML = tHTML.Replace("{}", dr[""]);
					tHTML = tHTML.Replace("{HOMELINK}", System.Net.WebUtility.HtmlEncode(homeLink));
					tHTML = tHTML.Replace("{HOMETEXT}", System.Net.WebUtility.HtmlEncode(homeText));
					tHTML = tHTML.Replace("{HOMENUMBER}", System.Net.WebUtility.HtmlEncode(homeNumber));
					tHTML = tHTML.Replace("{YEAR}", DateTime.Now.ToString("yyyy"));
					tHTML = tHTML.Replace("{DATE}", DateTime.Now.ToString("yyyy-MM-dd"));
					tHTML = tHTML.Replace("{REFERENCES}", references);
					
					Log.Debug(String.Format("Saving HTML file {0} - {1}", dr["FileName"].ToString(), dr["Title"].ToString()));
					try
					{
						File.WriteAllText(Path.Combine(HBSettings.projectBuildDir, dr["FileName"].ToString()), tHTML);
					}
					catch (Exception ex)
					{
						Log.Error(String.Format("Error saving HTML file {0}", dr["FileName"].ToString()));
						Log.Exception(ex);
						ret = false;
						//throw;
					}
				}
			}
			
			return ret;
		}
		
		// ==============================================================================
		private static DataSet InitializeNodeDataset()
		{
			DataSet ds = new DataSet();
			DataTable dt = new DataTable();
			DataColumn dc;
			
			ds.DataSetName = "ScreenInfo";
			dt = new DataTable();
			dt.TableName = "HTML";
			dc = new DataColumn("ID", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("IndexPath", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("PrevLink", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("PrevText", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("PrevNumber", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("NextLink", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("NextText", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("NextNumber", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Title", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("IndexEntries", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("ReferenceLinks", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("ShowScreen", Type.GetType("System.Boolean"));
			dt.Columns.Add(dc);
			dc = new DataColumn("ShowTitle", Type.GetType("System.Boolean"));
			dt.Columns.Add(dc);
			dc = new DataColumn("ShowHeader", Type.GetType("System.Boolean"));
			dt.Columns.Add(dc);
			dc = new DataColumn("ShowFooter", Type.GetType("System.Boolean"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Body", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("FileName", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("LinkID", Type.GetType("System.Int32"));
			dt.Columns.Add(dc);
			dc = new DataColumn("LinkDesc", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			
			dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
			
			ds.Tables.Add(dt);
			
			return ds;
		}
		
		// ==============================================================================
		private static void DatasetAddTOC(TreeNode node)
		{
			TreeNode topNode = HelpNode.GetRootNode(node);
			foreach (TreeNode tNode in topNode.Nodes[(int) HelpNode.branches.tocEntry].Nodes)
			{
				RecurseDatasetAddTOC(tNode);
			}
			
			// Populate next screen links (ignoring ToC items without a screen to display)
			string nextLink = String.Empty;
			string nextText = String.Empty;
			string nextNumber = String.Empty;
			
			// Sort help screen heierarchy
			DataView dv = _nodeDS.Tables[0].DefaultView;
			dv.Sort = "IndexPath DESC";
			DataTable sortedDT = dv.ToTable();
			
			// Help Screens (Table of Contents and HTML Popups)
			foreach (DataRow tDR in sortedDT.Rows)
			{
				if ( (bool) tDR["ShowScreen"] )
				{
					tDR["NextLink"] = nextLink;
					tDR["NextText"] = nextText;
					tDR["NextNumber"] = nextNumber;
					nextLink = tDR["FileName"].ToString();
					nextText = tDR["Title"].ToString();
					nextNumber = tDR["IndexPath"].ToString().TrimStart('0');
				}
			}
			_nodeDS.Tables.Clear();
			sortedDT.PrimaryKey = new DataColumn[] { sortedDT.Columns["ID"] };
			_nodeDS.Tables.Add(sortedDT);
			dv = sortedDT.DefaultView;
			
			// Populate previous screen links (ignoring ToC items without a screen to display)
			string prevLink = String.Empty;
			string prevText = String.Empty;
			string prevNumber = String.Empty;
			
			// Sort help screen heierarchy
			dv.Sort = "IndexPath";
			sortedDT = dv.ToTable();
			
			// Help Screens (Table of Contents and HTML Popups)
			foreach (DataRow tDR in sortedDT.Rows)
			{
				if ( (bool) tDR["ShowScreen"] )
				{
					tDR["PrevLink"] = prevLink;
					tDR["PrevText"] = prevText;
					tDR["PrevNumber"] = prevNumber;
					prevLink = tDR["FileName"].ToString();
					prevText = tDR["Title"].ToString();
					prevNumber = tDR["IndexPath"].ToString().TrimStart('0');
				}
			}
			_nodeDS.Tables.Clear();
			sortedDT.PrimaryKey = new DataColumn[] { sortedDT.Columns["ID"] };
			_nodeDS.Tables.Add(sortedDT);
		}
		
		// ==============================================================================
		private static void RecurseDatasetAddTOC(TreeNode node)
		{
			DataRow dr = _nodeDS.Tables[0].NewRow();
			HelpItem tItem = (HelpItem) node.Tag;
			dr["ID"] = tItem.id;
			dr["IndexPath"] = HelpNode.NodeTocIndex(node);
			dr["PrevLink"] = String.Empty;
			dr["PrevText"] = String.Empty;
			dr["PrevNumber"] = String.Empty;
			dr["NextLink"] = String.Empty;
			dr["NextText"] = String.Empty;
			dr["NextNumber"] = String.Empty;
			dr["Title"] = tItem.title;
			dr["IndexEntries"] = tItem.indexEntries;
			dr["ReferenceLinks"] = tItem.linkList;
			dr["ShowScreen"] = tItem.hasScreen;
			dr["ShowTitle"] = tItem.usesTitle;
			dr["ShowHeader"] = tItem.usesHeader;
			dr["ShowFooter"] = tItem.usesFooter;
			dr["Body"] = tItem.body;
			dr["FileName"] = tItem.fileName;
			dr["LinkID"] = tItem.linkID;
			dr["LinkDesc"] = tItem.linkDescription;
			_nodeDS.Tables[0].Rows.Add(dr);
			foreach (TreeNode tNode in node.Nodes)
			{
				RecurseDatasetAddTOC(tNode);
			}
		}
		
		// ==============================================================================
		private static void DatasetAddPopup(TreeNode node)
		{
			TreeNode topNode = HelpNode.GetRootNode(node);
			foreach (TreeNode tNode in topNode.Nodes[(int) HelpNode.branches.htmlPopup].Nodes)
			{
				DataRow dr = _nodeDS.Tables[0].NewRow();
				HelpItem tItem = (HelpItem) tNode.Tag;
				dr["ID"] = tItem.id;
				dr["IndexPath"] = String.Empty;
				dr["PrevLink"] = String.Empty;
				dr["PrevText"] = String.Empty;
				dr["PrevNumber"] = String.Empty;
				dr["NextLink"] = String.Empty;
				dr["NextText"] = String.Empty;
				dr["NextNumber"] = String.Empty;
				dr["Title"] = tItem.title;
				dr["IndexEntries"] = tItem.indexEntries;
				dr["ReferenceLinks"] = tItem.linkList;
				dr["ShowScreen"] = true;
				dr["ShowTitle"] = tItem.usesTitle;
				dr["ShowHeader"] = tItem.usesHeader;
				dr["ShowFooter"] = tItem.usesFooter;
				dr["Body"] = tItem.body;
				dr["FileName"] = tItem.fileName;
				dr["LinkID"] = tItem.linkID;
				dr["LinkDesc"] = tItem.linkDescription;
				_nodeDS.Tables[0].Rows.Add(dr);
			}
		}
		
		// ==============================================================================
		private static bool SaveCSS(TreeNode node)
		{
			bool ret = true;
			_headerCSS = "\n";
			TreeNode topNode =  HelpNode.GetRootNode(node);
			foreach (TreeNode tNode in topNode.Nodes[(int) HelpNode.branches.cssFile].Nodes) {
				CSSItem tItem = (CSSItem) tNode.Tag;
				string fileToWrite = Path.Combine(cssDir, tItem.fileName);
				Log.Debug(String.Format("Writing CSS file {0}", fileToWrite));
				try
				{
					File.WriteAllText(fileToWrite, tItem.content);
					_headerCSS = String.Format("{0}<link rel=\"stylesheet\" type=\"text/css\" href=\"css/{1}\" />\n", _headerCSS, tItem.fileName);
				}
				catch (Exception ex)
				{
					Log.Error(String.Format("Error writing CSS file {0}", fileToWrite));
					Log.Exception(ex);
					ret = false;
					//throw;
				}
			}
			
			return ret;
		}
		
		// ==============================================================================
		private static bool SaveScripts(TreeNode node)
		{
			bool ret = true;
			_headerScripts = "\n";
			TreeNode topNode =  HelpNode.GetRootNode(node);
			foreach (TreeNode tNode in topNode.Nodes[(int) HelpNode.branches.scriptFile].Nodes) {
				ScriptItem tItem = (ScriptItem) tNode.Tag;
				string fileToWrite = Path.Combine(scriptDir, tItem.fileName);
				Log.Debug(String.Format("Writing script file {0}", fileToWrite));
				try
				{
					File.WriteAllText(fileToWrite, tItem.content);
					_headerScripts = String.Format("{0}<script type=\"text/javascript\" src=\"scripts/{1}\"></script>\n", _headerScripts, tItem.fileName);
				}
				catch (Exception ex)
				{
					Log.Error(String.Format("Error writing script file {0}", fileToWrite));
					Log.Exception(ex);
					ret = false;
					//throw;
				}
			}
			
			return ret;
		}
		
		// ==============================================================================
		private static bool SaveImages(TreeNode node)
		{
			bool ret = true;
			TreeNode topNode =  HelpNode.GetRootNode(node);
			foreach (TreeNode tNode in topNode.Nodes[(int) HelpNode.branches.imageFile].Nodes) {
				ImageItem tItem = (ImageItem) tNode.Tag;
				string fileToWrite = Path.Combine(imageDir, tItem.fileName);
				Log.Debug(String.Format("Writing image file {0}", fileToWrite));
				try
				{
					byte[] imageBytes = Convert.FromBase64String(tItem.content);
					File.WriteAllBytes(fileToWrite, imageBytes);
				}
				catch (Exception ex)
				{
					Log.Error(String.Format("Error writing image file {0}", fileToWrite));
					Log.Exception(ex);
					ret = false;
					//throw;
				}
			}
			
			return ret;
		}
		
		// ==============================================================================
		/// <summary>
		/// Create the standard subdirectories for the HTML files.
		/// </summary>
		/// <returns>True on success, otherwise false.</returns>
		private static bool MakeSubdirectories()
		{
			return MakeSubdirectories(HBSettings.projectBuildDir);
		}
		
		// ==============================================================================
		/// <summary>
		/// Create the standard subdirectories for the HTML files.
		/// </summary>
		/// <param name="workingDir">Directory in which the subdirectories should be created.</param>
		/// <returns>True on success, otherwise false.</returns>
		private static bool MakeSubdirectories(string workingDir)
		{
			Log.Debug("Creating standard HTML subdirectories.");
			bool ret = true;
			foreach (string dirToMake in new string[] { cssDir, scriptDir, imageDir })
			{
				if ( !Directory.Exists(dirToMake) )
				{
					Log.Debug(String.Format("Creating directory {0}", dirToMake));
					try
					{
						Directory.CreateDirectory(dirToMake);
					}
					catch (Exception ex)
					{
						Log.Error(String.Format("Error creating directory {0}", dirToMake));
						Log.Exception(ex);
						ret = false;
						//throw;
					}
				}
			}
			
			if ( !ret )
			{
				Log.ErrorBox("Problem creating standard subdirectories.");
			}
			
			return ret;
		}
		
		// ==============================================================================
		private static bool RecreateDirectory(string dirToRecreate)
		{
			if ( !RemoveDir(dirToRecreate) )
			{
				return false;
			}
			
			return CreateDir(dirToRecreate);
		}
		
		// ==============================================================================
		private static bool CreateDir(string dirToCreate)
		{
			Log.Debug("Creating directory: " + dirToCreate);
			try
			{
				Directory.CreateDirectory(dirToCreate);
			}
			catch (Exception ex)
			{
				string error = "Error creating working directory: " + dirToCreate;
				Log.Error(error);
				Log.Exception(ex);
				return false;
			}
			Log.Debug(dirToCreate + " created successfully.");
			return true;
		}
		
		// ==============================================================================
		private static bool RemoveDir(string dirToRemove)
		{
			templateFile = String.Empty;		// Clear current unpacked template indicator
			Log.Debug("Removing directory: " + dirToRemove);
			if ( !Directory.Exists(dirToRemove) )
			{
				Log.Debug(dirToRemove + " does not exist.");
				return true;
			}
			else
			{
				try
				{
					Directory.Delete(dirToRemove, true);
				}
				catch (Exception ex)
				{
					string error = "Error removing working directory: " + dirToRemove;
					Log.Error(error);
					Log.Exception(ex);
					return false;
				}
			}
			Log.Debug(dirToRemove + " removed successfully.");
			return true;
		}
		
		
		// ==============================================================================
		/// <summary>
		/// Checks the working directory for the template.html file, and unpacks the
		/// template if it is not present.
		/// </summary>
		/// <returns>True on success, otherwise false.</returns>
		private static bool CheckWorkingDirs()
		{
			string errorMessage = "Error removing / creating the working directory: ";
			
//			// Clean out template directory by removing and recreating it
//			if ( !RecreateDirectory(HBSettings.templateBuildDir) )
//			{
//				Log.ErrorBox(errorMessage + HBSettings.templateBuildDir);
//				return false;
//			}
			
			// Clean out project build directory by removing and recreating it
			if ( !RecreateDirectory(HBSettings.projectBuildDir) )
			{
				Log.ErrorBox(errorMessage + HBSettings.projectBuildDir);
				return false;
			}
			
			return true;
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		#endregion
		
		#region Public Properties

//		/// <summary>
//		/// Working directory (will be deleted and recreated on compile operations)
//		/// </summary>
//		public static string workingDir
//		{
//			get
//			{
//				if ( String.IsNullOrWhiteSpace(_workingDir) ) {
//					return Path.Combine( System.IO.Path.GetTempPath(), typeof(MainForm).Namespace + "_working" );
//				}
//				else
//				{
//					return _workingDir.Trim();
//				}
//			}
//			set
//			{
//				_workingDir = value.Trim();
//			}
//		}
		
		/// <summary>
		/// Template file currently unpacked in the working directory.
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
		
		public static string cssDir
		{
			get{ return Path.Combine(HBSettings.projectBuildDir, "css"); }
		}
		
		public static string scriptDir
		{
			get{ return Path.Combine(HBSettings.projectBuildDir, "scripts"); }
		}
		
		public static string imageDir
		{
			get{ return Path.Combine(HBSettings.projectBuildDir, "images"); }
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
			Log.Debug("Cleaning up temporary project build files and directories.");
			bool ret = true;
			templateFile = String.Empty;
			_headerCSS = String.Empty;
			_headerScripts = String.Empty;
			foreach ( string tDir in new string[] { HBSettings.projectBuildDir } ) 
			{
				ret = ret & RemoveDir(tDir);
			}
			
			return ret;
		}
		
		// ==============================================================================
		public static bool MakeFiles( System.Windows.Forms.TreeNode node )
		{
			string errorMessage = String.Empty;
			bool ret = true;
			HHBProject project = (HHBProject) HelpNode.GetRootNode(node).Tag;
			HHBTemplate template = HHBTemplate.GetTemplate(project.template);
			
			// Check for missing template filename
			if ( String.IsNullOrWhiteSpace(template.fileName) )
			{
				errorMessage = "Invalid project template.  The template was not found.";
				Log.Error(errorMessage);
				Log.ErrorBox(errorMessage);
				return false;
			}
			
			// Initialize working directory
			Cleanup();
			
			// Unpack the template to the working directory
			templateFile = template.fileName;
			if ( !template.UnpackTemplatePackage() )
			{
				templateFile = String.Empty;
				return false;
			}
			
			// Create the other standard subdirectories
			if ( !MakeSubdirectories() )
			{
				Cleanup();
				return false;
			}
			
			// Save CSS files
			ret = ret & ( SaveCSS(node) );
//			if ( !SaveCSS(node) )
//			{
//				Cleanup();
//				return false;
//			}
			
			// Save Script files
			ret = ret & ( SaveScripts(node) );
//			if ( !SaveScripts(node) )
//			{
//				Cleanup();
//				return false;
//			}
			
			// Save Image files
			ret = ret & ( SaveImages(node) );
//			if ( !SaveImages(node) )
//			{
//				Cleanup();
//				return false;
//			}
			
			if ( !ret )
			{
				Log.ErrorBox("Problem saving one or more files.  Please see the log file for details.");
			}
			
			// Create node information list (ID, Prev Link, Next Link, etc)
			_nodeDS = InitializeNodeDataset();
			DatasetAddTOC(node);
			DatasetAddPopup(node);
			
			// Create HTML files
			if ( !MakeHTMLFiles() )
			{
				Log.ErrorBox("Problem creating one or more HTML files.  Please see the log file for details.");
				ret = false;
			}
			
			// TODO: Create ToC file
			
			
			// TODO: Create Text Popup file
			
			
			// TODO: Create Index File
			
			
			// TODO: Create Compiler Project file


			return ret;
		}
		
		// ==============================================================================
		public static bool Compile( System.Windows.Forms.TreeNode node, string outputFile )
		{
			bool ret = true;
			
			// make files
			if ( !MakeFiles(node) )
			{
				// TODO: Display error message 
				ret = false;
			}
			
			// check files
			
			
			// run compile
			
			return ret;
		}
		#endregion
		
	}
}
