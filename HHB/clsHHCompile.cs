/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-10-22
 * Time: 12:31
 */

using System;
using System.Data;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HHBuilder
{
	/// <summary>
	/// Methods for compiling a help project.
	/// </summary>
	public static class HHCompile
	{
		#region Private Member Variables
		// ==============================================================================
		private static string _templateFile = String.Empty;
		private static string _homeID = String.Empty;
		private static string _homeFileName = String.Empty;
		private static string _homeText = String.Empty;
		private static string _homeNumber = String.Empty;
		private static string _htmlTemplate = String.Empty;
		private static DataSet _nodeDS = InitializeNodeDataset();
		private static DataSet _imageDS = InitializeImageDataset();
		#endregion

		#region Private Properties
		// ==============================================================================
		#endregion
		
		#region Private Methods
		// ==============================================================================
		private static bool MakeProjectTOC(TreeNode node)
		{
			System.Text.StringBuilder toc = new System.Text.StringBuilder();
			toc.AppendLine("<!DOCTYPE HTML PUBLIC \"-//IETF//DTD HTML//EN\">");
			toc.AppendLine("<HTML>");
			toc.AppendLine("<HEAD>");
			System.Reflection.AssemblyName tempAssembly = System.Reflection.Assembly.GetExecutingAssembly().GetName();
			toc.AppendFormat("<meta name=\"GENERATOR\" content=\"HTML Help Builder ({0} v{1}.{2:00})\">\n", tempAssembly.Name, tempAssembly.Version.Major, tempAssembly.Version.Minor);
			toc.AppendLine("<!-- Sitemap 1.0 -->");
			toc.AppendLine("</HEAD><BODY>");
			toc.AppendLine("<OBJECT type=\"text/site properties\">");
			toc.AppendLine("	<param name=\"Window Styles\" value=\"0x800025\">");
			toc.AppendLine("	<param name=\"ImageType\" value=\"Folder\">");
			toc.AppendLine("</OBJECT>");
			
			TreeNode tNode = HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.tocEntry];
			recurseTOC(ref toc, tNode, 0);
			
			toc.AppendLine("</BODY></HTML>");
			
			string outputFile = Path.Combine(HBSettings.projectBuildDir, "toc.hhc");
			try
			{
				Log.Debug(String.Format("Creating Table of Contents file {0}", outputFile));
				File.WriteAllText(outputFile, toc.ToString());
			}
			catch (Exception ex)
			{
				Log.Error(String.Format("Problem writing Table of Contents file {0}", outputFile));
				Log.Exception(ex);
				return false;
				//throw;
			}
			
			return true;
		}
		
		// ==============================================================================
		private static void recurseTOC(ref System.Text.StringBuilder sb, TreeNode node, int offset)
		{
			if ( node.Nodes.Count > 0 )
			{
				string tSpace = new String(' ', offset);
				sb.AppendFormat("{0}<UL>\n", tSpace);
				offset += 4;
				tSpace = new String(' ', offset);
				foreach (TreeNode tNode in node.Nodes)
				{
					HelpItem tItem = (HelpItem) tNode.Tag;
					sb.AppendFormat("{0}<LI> <OBJECT type=\"text/sitemap\">\n", tSpace);
					tSpace = new String(' ', offset + 4);
					sb.AppendFormat("{0}<param name=\"Name\" value=\"{1}\">\n", tSpace, System.Net.WebUtility.HtmlEncode(tItem.title));
					string tFileName = String.Empty;
					if ( tItem.hasScreen )
					{
						tFileName = tItem.fileName;
					}
					sb.AppendFormat("{0}<param name=\"Local\" value=\"{1}\">\n", tSpace, tFileName);
					sb.AppendFormat("{0}</OBJECT>\n", tSpace);
					tSpace = new String(' ', offset);
					recurseTOC(ref sb, tNode, offset);
				}
				offset -= 4;
				tSpace = new String(' ', offset);
				sb.AppendFormat("{0}</UL>\n", tSpace);
			}
		}
		
		// ==============================================================================
		private static bool MakeProjectIndex(TreeNode node)
		{
			
			
			
			return true;
		}
		
		// ==============================================================================
		private static int MakeProjectPopupText(TreeNode node)
		{
			int topicCount = 0;
			
			System.Text.StringBuilder popupText = new System.Text.StringBuilder();
			System.Text.StringBuilder popupMap = new System.Text.StringBuilder();
			
			foreach (TreeNode tNode in HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.textPopup].Nodes)
			{
				PopupTextItem tItem = (PopupTextItem) tNode.Tag;
				popupText.AppendFormat(".topic IDH_{0}\n{1}\n\n", tItem.id, tItem.helpText.Trim());
				popupMap.AppendFormat("#define IDH_{0}  {1}\n", tItem.id, tItem.linkID.ToString().Trim());
				topicCount++;
			}
			
			if ( topicCount > 0 )
			{
				string outputFile = String.Empty;
				try
				{
					string msgText = "Creating popup text file {0}";
					outputFile = Path.Combine(HBSettings.projectBuildDir, "textpopups.txt");
					Log.Debug(String.Format(msgText, outputFile));
					File.WriteAllText(outputFile, popupText.ToString());
					
					outputFile = Path.Combine(HBSettings.projectBuildDir, "textpopups.h");
					Log.Debug(String.Format(msgText, outputFile));
					File.WriteAllText(outputFile, popupMap.ToString());
				}
				catch (Exception ex)
				{
					Log.Error(String.Format("Problem writing popup text file {0}", outputFile));
					Log.Exception(ex);
					topicCount = 0;
					//throw;
				}
			}
			
			return topicCount;
		}
		
		// ==============================================================================
		private static bool MakeProjectCompilerFile(TreeNode node)
		{
			
			
			
			return true;
		}
		
		// ==============================================================================
		
		
		
		
		
		
		
		
		
		
		

		// ==============================================================================
		private static string ParseHtmlBody(TreeNode node, HelpItem hItem)
		{
			string repBody = hItem.body;
			
			
			
			
			
			
			
			
			
			// TODO: Insert body text preprocessing here.
			
			
			
			
			
			
			
			
			// Create style entry to hide unwanted sections
			bool bTest = false;
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.AppendLine("<style>");
			if ( !hItem.usesTitle )
			{
				sb.AppendLine(".TITLE { display: none; }");
				bTest = true;
			}
			if ( !hItem.usesHeader )
			{
				sb.AppendLine(".HEADER { display: none; }");
				bTest = true;
			}
			if ( !hItem.usesFooter )
			{
				sb.AppendLine(".FOOTER { display: none; }");
				bTest = true;
			}
			
			string references = "";
			if ( String.IsNullOrWhiteSpace(hItem.linkList) )
			{
				sb.AppendLine(".REFERENCES { display: none; }");
				bTest = true;
			}
			else
			{
				System.Text.StringBuilder sbRef = new System.Text.StringBuilder();
				string[] refArray = hItem.linkArray;
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
					sbRef.AppendFormat("<li class=\"REFERENCE\"><a href=\"{0}\">{1}</a></li>\n", tRefLink, tRefText);
				}
				references = sbRef.ToString();
			}
			sb.AppendLine("</style>");
			
			string hideItems = "";
			if ( bTest )
			{
				hideItems = sb.ToString();
			}
			
			string headerCSS = String.Empty;
			if ( !String.IsNullOrWhiteSpace(hItem.cssList) )
			{
				System.Text.StringBuilder sbCSS = new System.Text.StringBuilder();
				string[] CssArray = hItem.cssArray;
				foreach (string tCSS in CssArray)
				{
					if ( !File.Exists(Path.Combine(cssDir, tCSS + ".css")) )
					{
						MakeCssFile(node, tCSS);
					}
					if ( File.Exists(Path.Combine(cssDir, tCSS + ".css")) )
					{
						sbCSS.AppendFormat("<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}/{1}\" />\n", cssDirName, tCSS + ".css");
					}
					else
					{
						Log.Error("Missing CSS file " + tCSS + ".css");
					}
				}
				headerCSS = sbCSS.ToString();
			}
			
			
			string headerScripts = String.Empty;
			if ( !String.IsNullOrWhiteSpace(hItem.scriptList) )
			{
				System.Text.StringBuilder sbScript = new System.Text.StringBuilder();
				string[] scriptArray = hItem.scriptArray;
				foreach (string tScript in scriptArray)
				{
					if ( !File.Exists(Path.Combine(scriptDir, tScript + ".js")) )
					{
						MakeScriptFile(node, tScript);
					}
					if ( File.Exists(Path.Combine(scriptDir, tScript + ".js")) )
					{
						sbScript.AppendFormat("<script type=\"text/javascript\" src=\"{0}/{1}\"></script>\n", scriptDirName, tScript + ".js");
					}
					else
					{
						Log.Error("Missing script file " + tScript + ".js");
					}
				}
				headerScripts = sbScript.ToString();
			}
			
//			string repBody = ParseHtmlBody(dr["Body"].ToString());
			
			// Process links
			repBody = ProcessLinks(repBody);
			
			// Process image links
			repBody = ProcessImageLinks(node, repBody);
			
			string tHTML = _htmlTemplate;
			tHTML = tHTML.Replace("</head>", headerScripts + headerCSS + hideItems + "</head>");
			tHTML = tHTML.Replace("{BODY}", repBody);

			DataRow dr = _nodeDS.Tables[0].Rows.Find(hItem.id);
			if ( dr != null )
			{
				tHTML = tHTML.Replace("{TITLE}", System.Net.WebUtility.HtmlEncode(dr["Title"].ToString()));
				tHTML = tHTML.Replace("{PREVLINK}", System.Net.WebUtility.HtmlEncode(dr["PrevLink"].ToString()));
				tHTML = tHTML.Replace("{NEXTLINK}", System.Net.WebUtility.HtmlEncode(dr["NextLink"].ToString()));
				tHTML = tHTML.Replace("{PREVTEXT}", System.Net.WebUtility.HtmlEncode(dr["PrevText"].ToString()));
				tHTML = tHTML.Replace("{NEXTTEXT}", System.Net.WebUtility.HtmlEncode(dr["NextText"].ToString()));
				tHTML = tHTML.Replace("{PREVNUMBER}", System.Net.WebUtility.HtmlEncode(dr["PrevNumber"].ToString()));
				tHTML = tHTML.Replace("{NEXTNUMBER}", System.Net.WebUtility.HtmlEncode(dr["NextNumber"].ToString()));
				tHTML = tHTML.Replace("{NUMBER}", System.Net.WebUtility.HtmlEncode(dr["IndexPath"].ToString().TrimStart('0')));
				//tHTML = tHTML.Replace("{}", dr[""]);
				//tHTML = tHTML.Replace("{}", dr[""]);
				//tHTML = tHTML.Replace("{}", dr[""]);
				//tHTML = tHTML.Replace("{}", dr[""]);
				//tHTML = tHTML.Replace("{}", dr[""]);
				//tHTML = tHTML.Replace("{}", dr[""]);
			}
			tHTML = tHTML.Replace("{HOMELINK}", System.Net.WebUtility.HtmlEncode(_homeFileName));
			tHTML = tHTML.Replace("{HOMETEXT}", System.Net.WebUtility.HtmlEncode(_homeText));
			tHTML = tHTML.Replace("{HOMENUMBER}", System.Net.WebUtility.HtmlEncode(_homeNumber));
			
			HHBProject project = (HHBProject) HelpNode.GetRootNode(node).Tag;
			tHTML = tHTML.Replace("{AUTHOR}", System.Net.WebUtility.HtmlEncode(project.author));
			tHTML = tHTML.Replace("{COMPANY}", System.Net.WebUtility.HtmlEncode(project.company));
			tHTML = tHTML.Replace("{COPYRIGHT}", System.Net.WebUtility.HtmlEncode(project.copyright));
			
			tHTML = tHTML.Replace("{YEAR}", DateTime.Now.ToString("yyyy"));
			tHTML = tHTML.Replace("{DATE}", DateTime.Now.ToString("yyyy-MM-dd"));
			tHTML = tHTML.Replace("{REFERENCES}", references);
			
			return tHTML;
		}
		
		// ==============================================================================
		private static string ProcessLinks(string bodyText)
		{
			string repBody = bodyText;
			Regex regExImages = new System.Text.RegularExpressions.Regex(@"\{Link:([^\}]*)\}", RegexOptions.IgnoreCase);
			MatchCollection matches = regExImages.Matches(repBody);
			foreach (Match match in matches)
			{
				string[] screenInfo = match.Groups[1].Value.Split('|');
				string linkURL = screenInfo[0];
				string linkText = String.Empty;
				if ( screenInfo.Length > 1 )
				{
					linkText = String.Join("|", screenInfo, 1, (screenInfo.Length - 1));
				}
				string screenID = match.Groups[1].Value;
				string sOld = String.Format("{0}Link:{1}{2}", "{", match.Groups[1].Value, "}");
				string sNew = String.Format("<a href=\"{0}\">{1}</a>", linkURL, System.Net.WebUtility.HtmlEncode(linkText));
				repBody = repBody.Replace(sOld, sNew);
			}
			return repBody;
		}
		
		// ==============================================================================
		private static string ProcessImageLinks(TreeNode node, string bodyText)
		{
			string repBody = bodyText;
			Regex regExImages = new System.Text.RegularExpressions.Regex(@"\{Image:([^\}]*)\}", RegexOptions.IgnoreCase);
			MatchCollection matches = regExImages.Matches(repBody);
			foreach (Match match in matches)
			{
				string imageID = match.Groups[1].Value;
				string sOld = String.Format("{0}Image:{1}{2}", "{", imageID, "}");
				string sNew;
				DataRow dr = _imageDS.Tables[0].Rows.Find(imageID);
				if ( dr == null )
				{
					sNew = String.Format("<img src=\"{0}/{1}\" alt=\"{2}\">", imageDirName, imageID, "Image not found");
				}
				else
				{
					string fileName = dr["FileName"].ToString().Trim();
					sNew = String.Format("<img src=\"{0}/{1}\" alt=\"{2}\">", imageDirName, fileName, System.Net.WebUtility.HtmlEncode(dr["Title"].ToString()));
					MakeImageFile(node, imageID);
				}
				repBody = repBody.Replace(sOld, sNew);
			}
			return repBody;
		}
		
		// ==============================================================================
		private static DataSet InitializeImageDataset()
		{
			DataSet ds = new DataSet();
			DataTable dt = new DataTable();
			DataColumn dc;
			
			ds.DataSetName = "ImageInfo";
			dt = new DataTable();
			dt.TableName = "Images";
			dc = new DataColumn("ID", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Title", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("FileName", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			
			dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
			
			ds.Tables.Add(dt);
			
			return ds;
		}
		
		// ==============================================================================
		private static void SetHomeScreen(TreeNode node)
		{
			_homeID = ((HHBProject) HelpNode.GetRootNode(node).Tag).defaultTopic.Trim().Split(' ')[0];
			_homeFileName = String.Empty;
			_homeNumber = String.Empty;
			_homeText = String.Empty;
			
			DataRow tHomeDR = _nodeDS.Tables[0].Rows.Find(_homeID);
			if ( tHomeDR != null )
			{
				_homeFileName = tHomeDR["FileName"].ToString();
				_homeText = tHomeDR["Title"].ToString();
				_homeNumber = tHomeDR["IndexPath"].ToString().TrimStart('0');
			}
			else
			{
				// Process each row in the HTML items dataset
				foreach (DataRow dr in _nodeDS.Tables[0].Rows)
				{
					if ( (bool) dr["ShowScreen"] )
					{
						// Set home link information
						if ( String.IsNullOrWhiteSpace(_homeFileName) )
						{
							_homeFileName = dr["FileName"].ToString();
							_homeText = dr["Title"].ToString();
							_homeNumber = dr["IndexPath"].ToString().TrimStart('0');
						}
					}
				}
			}
		}
		
		// ==============================================================================
		private static DataSet ImageParsingDataset(TreeNode node)
		{
			DataSet ds = InitializeImageDataset();
			TreeNode topNode = HelpNode.GetRootNode(node);
			foreach (TreeNode tNode in topNode.Nodes[(int) HelpNode.branches.imageFile].Nodes)
			{
				DataRow dr = ds.Tables[0].NewRow();
				ImageItem tItem = (ImageItem) tNode.Tag;
				dr["ID"] = tItem.id;
				dr["Title"] = tItem.title;
				dr["FileName"] = tItem.fileName;
				ds.Tables[0].Rows.Add(dr);
			}
			
			return ds;
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
			dc = new DataColumn("CssLinks", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("ScriptLinks", Type.GetType("System.String"));
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
			dr["CssLinks"] = tItem.cssList;
			dr["ScriptLinks"] = tItem.scriptList;
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
				dr["ScriptLinks"] = tItem.scriptList;
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
			TreeNode topNode =  HelpNode.GetRootNode(node);
			foreach (TreeNode tNode in topNode.Nodes[(int) HelpNode.branches.cssFile].Nodes)
			{
				CSSItem tItem = (CSSItem) tNode.Tag;
				string fileToWrite = Path.Combine(cssDir, tItem.fileName);
				Log.Debug(String.Format("Saving CSS file {0} - {1}", tItem.fileName, tItem.title));
				try
				{
					File.WriteAllText(fileToWrite, tItem.content);
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
			TreeNode topNode =  HelpNode.GetRootNode(node);
			foreach (TreeNode tNode in topNode.Nodes[(int) HelpNode.branches.scriptFile].Nodes)
			{
				ScriptItem tItem = (ScriptItem) tNode.Tag;
				string fileToWrite = Path.Combine(scriptDir, tItem.fileName);
				Log.Debug(String.Format("Saving script file {0} - {1}", tItem.fileName, tItem.title));
				try
				{
					File.WriteAllText(fileToWrite, tItem.content);
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
			_imageDS = InitializeImageDataset();
			bool ret = true;
			TreeNode topNode =  HelpNode.GetRootNode(node);
			foreach (TreeNode tNode in topNode.Nodes[(int) HelpNode.branches.imageFile].Nodes)
			{
				ImageItem tItem = (ImageItem) tNode.Tag;
				DataRow dr = _imageDS.Tables[0].NewRow();
				dr["ID"] = tItem.id;
				dr["Title"] = tItem.title;
				dr["FileName"] = tItem.fileName;
				_imageDS.Tables[0].Rows.Add(dr);
				string fileToWrite = Path.Combine(imageDir, tItem.fileName);
				Log.Debug(String.Format("Saving image file {0} - {1}", tItem.fileName, tItem.title));
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
				int retryCount = 3;
				while ( (retryCount > 0) && (Directory.Exists(dirToRemove)) )
				{
					retryCount--;
					try
					{
						Directory.Delete(dirToRemove, true);
					}
					catch (Exception ex)
					{
						if (retryCount < 1)
						{
							string error = "Error removing working directory: " + dirToRemove;
							Log.Error(error);
							Log.Exception(ex);
							return false;
						}
						System.Threading.Thread.Sleep(250);
					}
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
		// ==============================================================================
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
		
		// ==============================================================================
		/// <summary>
		/// The standard subdirectory name containing the project's additional CSS files.
		/// </summary>
		public static string cssDirName
		{
			get{ return "css"; }
		}
		
		// ==============================================================================
		/// <summary>
		/// The standard subdirectory name containing the project's additional Javascript files. 
		/// </summary>
		public static string scriptDirName
		{
			get{ return "scripts"; }
		}
		
		// ==============================================================================
		/// <summary>
		/// The standard subdirectory name containing the project's additional image files. 
		/// </summary>
		public static string imageDirName
		{
			get{ return "images"; }
		}
		
		// ==============================================================================
		/// <summary>
		/// The full path name of the subdirectory containing the project's additional CSS files. 
		/// </summary>
		public static string cssDir
		{
			get{ return Path.Combine(HBSettings.projectBuildDir, cssDirName); }
		}
		
		// ==============================================================================
		/// <summary>
		/// The full path name of the subdirectory containing the project's additional Javascript files. 
		/// </summary>
		public static string scriptDir
		{
			get{ return Path.Combine(HBSettings.projectBuildDir, scriptDirName); }
		}
		
		// ==============================================================================
		/// <summary>
		/// The full path name of the subdirectory containing the project's additional image files. 
		/// </summary>
		public static string imageDir
		{
			get{ return Path.Combine(HBSettings.projectBuildDir, imageDirName); }
		}
		#endregion
		
		#region Public Methods
		// ==============================================================================
		/// <summary>
		/// Initialize the build directory including unpacking the template.
		/// </summary>
		/// <param name="node">Node in the project tree.</param>
		/// <returns>True on success, otherwise false.</returns>
		public static bool InitializeBuildDirectory(TreeNode node)
		{
			HHBProject project = (HHBProject) HelpNode.GetRootNode(node).Tag;
			HHBTemplate template = HHBTemplate.GetTemplate(project.template);
			
			// Check for missing template filename
			if ( String.IsNullOrWhiteSpace(template.fileName) )
			{
				string errorMessage = "Invalid project template.  The template was not found.";
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
				_htmlTemplate = String.Empty;
				return false;
			}
			else
			{
				try
				{
					_htmlTemplate = File.ReadAllText(Path.Combine(HBSettings.projectBuildDir, "template.html"));
				}
				catch (Exception ex)
				{
					string errMessage = "Problem reading the template.html file.";
					Log.Error(errMessage);
					Log.Exception(ex);
					Log.ErrorBox(errMessage + "  Please see the log file for details.");
					return false;
					//throw;
				}
			}
			
			// Create the other standard subdirectories
			if ( !MakeSubdirectories() )
			{
				Cleanup();
				return false;
			}
			
			return true;
		}
		
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
			foreach ( string tDir in new string[] { HBSettings.projectBuildDir } ) 
			{
				ret = ret & RemoveDir(tDir);
			}
			System.Threading.Thread.Sleep(1000);
			
			return ret;
		}
		
		// ==============================================================================
		/// <summary>
		/// Delete the specified file.
		/// </summary>
		/// <param name="FilePathAndName">File to delete.</param>
		/// <returns>True on success, otherwise false.</returns>
		public static bool DeleteFile(string FilePathAndName)
		{
			if ( File.Exists(FilePathAndName) )
			{
				try
				{
					Log.Debug(String.Format("Deleting {0}", FilePathAndName));
					File.Delete(FilePathAndName);
				}
				catch (Exception ex)
				{
					Log.Error(String.Format("Error deleting {0}", FilePathAndName));
					Log.Exception(ex);
					return false;
					//throw;
				}
			}
			
			return true;
		}
		
		// ==============================================================================
		/// <summary>
		/// Write the specified script file.
		/// </summary>
		/// <param name="node">Node in the project tree.</param>
		/// <param name="id">ID of the script.</param>
		/// <returns>True on success, otherwise false.</returns>
		public static bool MakeScriptFile(TreeNode node, string id)
		{
			TreeNode tNode = null;
			foreach (TreeNode cNode in HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.scriptFile].Nodes)
			{
				if ( ( (ScriptItem) cNode.Tag).id == id )
				{
					tNode = cNode;
				}
			}
			if ( tNode == null )
			{
				Log.Error(String.Format("Unable to make script {0}.  Node information not found.", id));
				return false;
			}
			else
			{
				return MakeScriptFile(tNode);
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// Write the specified script file.
		/// </summary>
		/// <param name="node">Node containing the script information.</param>
		/// <returns>True on success, otherwise false.</returns>
		public static bool MakeScriptFile(TreeNode node)
		{
			ScriptItem tItem = (ScriptItem) node.Tag;
			string outFile = Path.Combine(HHCompile.scriptDir, tItem.fileName);
			Log.Debug(String.Format("Writing script file {0} : {1}", tItem.fileName, tItem.title));
			if ( File.Exists(outFile) )
			{
				return true;
			}
			
			if ( !File.Exists(Path.Combine(HBSettings.projectBuildDir, "template.html")) )
			{
				if ( !InitializeBuildDirectory(node) )
				{
					return false;
				}
			}
			
			try
			{
				File.WriteAllText(outFile, tItem.content);
			}
			catch (Exception ex)
			{
				Log.Error(String.Format("Unable to create the script file {0}.", outFile));
				Log.Exception(ex);
				return false;
				//throw;
			}
			return true;
		}
		
		// ==============================================================================
		/// <summary>
		/// Write the specified CSS file.
		/// </summary>
		/// <param name="node">Node in the project tree.</param>
		/// <param name="id">ID of the CSS file.</param>
		/// <returns>True on success, otherwise false.</returns>
		public static bool MakeCssFile(TreeNode node, string id)
		{
			TreeNode tNode = null;
			foreach (TreeNode cNode in HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.cssFile].Nodes)
			{
				if ( ( (CSSItem) cNode.Tag).id == id )
				{
					tNode = cNode;
				}
			}
			if ( tNode == null )
			{
				Log.Error(String.Format("Unable to make CSS file {0}.  Node information not found.", id));
				return false;
			}
			else
			{
				return MakeCssFile(tNode);
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// Write the specified CSS file.
		/// </summary>
		/// <param name="node">Node containing the CSS information.</param>
		/// <returns>True on success, otherwise false.</returns>
		public static bool MakeCssFile(TreeNode node)
		{
			CSSItem tItem = (CSSItem) node.Tag;
			Log.Debug(String.Format("Writing CSS file {0} : {1}", tItem.fileName, tItem.title));
			string outFile = Path.Combine(HHCompile.cssDir, tItem.fileName);
			if ( File.Exists(outFile) )
			{
				return true;
			}
			
			if ( !File.Exists(Path.Combine(HBSettings.projectBuildDir, "template.html")) )
			{
				if ( !InitializeBuildDirectory(node) )
				{
					return false;
				}
			}
			
			try
			{
				File.WriteAllText(outFile, tItem.content);
			}
			catch (Exception ex)
			{
				Log.Error(String.Format("Unable to create the CSS file {0}.", outFile));
				Log.Exception(ex);
				return false;
				//throw;
			}
			return true;
		}
		
		// ==============================================================================
		/// <summary>
		/// Write the specified image file.
		/// </summary>
		/// <param name="node">Node in the project tree.</param>
		/// <param name="id">ID of the image.</param>
		/// <returns>True on success, otherwise false.</returns>
		public static bool MakeImageFile(TreeNode node, string id)
		{
			TreeNode tNode = null;
			foreach (TreeNode cNode in HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.imageFile].Nodes)
			{
				if ( ( (ImageItem) cNode.Tag).id == id )
				{
					tNode = cNode;
				}
			}
			if ( tNode == null )
			{
				Log.Error(String.Format("Unable to make image {0}.  Node information not found.", id));
				return false;
			}
			else
			{
				return MakeImageFile(tNode);
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// Write the specified image file.
		/// </summary>
		/// <param name="node">Node containing the image information.</param>
		/// <returns>True on success, otherwise false.</returns>
		public static bool MakeImageFile(TreeNode node)
		{
			ImageItem tItem = (ImageItem) node.Tag;
			Log.Debug(String.Format("Writing image file {0} : {1}", tItem.fileName, tItem.title));
			string outFile = Path.Combine(HHCompile.imageDir, tItem.fileName);
			if ( File.Exists(outFile) )
			{
				return true;
			}
			
			if ( !File.Exists(Path.Combine(HBSettings.projectBuildDir, "template.html")) )
			{
				if ( !InitializeBuildDirectory(node) )
				{
					return false;
				}
			}
			
			try
			{
				byte[] imageBytes = Convert.FromBase64String(tItem.content);
				File.WriteAllBytes(outFile, imageBytes);
			}
			catch (Exception ex)
			{
				Log.Error(String.Format("Unable to create the image file {0}.", outFile));
				Log.Exception(ex);
				return false;
				//throw;
			}
			return true;
		}
		
		// ==============================================================================
		/// <summary>
		/// Write the specified HTML file.
		/// </summary>
		/// <param name="node">Node containing the HTML item information.</param>
		/// <returns>True on success, otherwise false.</returns>
		public static bool MakeHtmlFile(TreeNode node)
		{
			return MakeHtmlFile(node, true);
		}
		
		// ==============================================================================
		/// <summary>
		/// Write the specified HTML file.
		/// </summary>
		/// <param name="node">Node in the project tree.</param>
		/// <param name="id">ID of the HTML item.</param>
		/// <param name="rebuildIndices">Rebuild all index data tables.</param>
		/// <returns>True on success, otherwise false.</returns>
		public static bool MakeHtmlFile(TreeNode node, string id, bool rebuildIndices)
		{
			TreeNode tNode = null;
			int[] branches = { (int) HelpNode.branches.tocEntry, (int) HelpNode.branches.htmlPopup };
			foreach (int branch in branches)
			{
				foreach (TreeNode cNode in HelpNode.GetRootNode(node).Nodes[branch].Nodes)
				{
					if ( ( (ImageItem) cNode.Tag).id == id )
					{
						tNode = cNode;
					}
				}
			}
			if ( tNode == null )
			{
				Log.Error(String.Format("Unable to make HTML file {0}.  Node information not found.", id));
				return false;
			}
			else
			{
				return MakeHtmlFile(tNode, rebuildIndices);
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// Write the specified HTML file.
		/// </summary>
		/// <param name="node">Node in the project tree.</param>
		/// <param name="id">ID of the HTML item.</param>
		/// <returns>True on success, otherwise false.</returns>
		public static bool MakeHtmlFile(TreeNode node, string id)
		{
			return MakeHtmlFile(node, id, true);
		}
		
		// ==============================================================================
		/// <summary>
		/// Write the specified HTML file.
		/// </summary>
		/// <param name="node">Node containing the HTML item information.</param>
		/// <param name="rebuildIndices">Rebuild all index data tables.</param>
		/// <returns>True on success, otherwise false.</returns>
		public static bool MakeHtmlFile(TreeNode node, bool rebuildIndices)
		{
			if ( rebuildIndices )
			{
				MakeIndices(node);
			}
			
			HelpItem tItem = (HelpItem) node.Tag;
			if ( !tItem.hasScreen )
			{
				Log.ErrorBox("Selected node setting is that it has no screen to display.");
				return false;
			}
			Log.Debug(String.Format("Writing HTML file {0} : {1}", tItem.fileName, tItem.title));
			string fileToWrite = Path.Combine(HBSettings.projectBuildDir, tItem.fileName);
			DeleteFile(fileToWrite);
			
			// Check that the template has been unpacked.
			if ( !File.Exists(Path.Combine(HBSettings.projectBuildDir, "template.html")) )
			{
				if ( !InitializeBuildDirectory(node) )
				{
					Log.ErrorBox(String.Format("Template not unpacked.  Unable to create HTML file: {0}", fileToWrite));
					return false;
				}
			}
			
			// Parse the HTML screen body content
			string tHTML = ParseHtmlBody(node, tItem);
			
			Log.Debug(String.Format("Saving HTML file {0} - {1}", tItem.fileName, tItem.title));
			try
			{
				File.WriteAllText(Path.Combine(HBSettings.projectBuildDir, tItem.fileName), tHTML);
			}
			catch (Exception ex)
			{
				Log.Error(String.Format("Error saving HTML file {0}", tItem.fileName));
				Log.Exception(ex);
				return false;
				//throw;
			}
			
			return true;
		}
		
		// ==============================================================================
		/// <summary>
		/// Builds the project index tables.
		/// </summary>
		/// <param name="node">Node in the project tree.</param>
		public static void MakeIndices(TreeNode node)
		{
			// Make HTML nodes index 
			_nodeDS = InitializeNodeDataset();
			DatasetAddTOC(node);
			DatasetAddPopup(node);
			
			// Make images index
			_imageDS = ImageParsingDataset(node);
			
			// Set home screen
			SetHomeScreen(node);
		}
		
		// ==============================================================================
		/// <summary>
		/// Creates all HTML files for the specified project.
		/// </summary>
		/// <param name="node">Node in the project tree.</param>
		/// <returns>True on success, otherwise false.</returns>
		public static bool MakeAllHTML(TreeNode node)
		{
			MakeIndices(node);
			bool retValue = InitializeBuildDirectory(node);
			foreach (DataRow dr in _nodeDS.Tables[0].Rows)
			{
				if ( (bool) dr["ShowScreen"] )
				{
					retValue = retValue & MakeHtmlFile(node, dr["ID"].ToString().Trim());
				}
			}
			
			return retValue;
		}
		
		// ==============================================================================
		/// <summary>
		/// Create the files required for the creation of the compiled help file (.chm) 
		/// </summary>
		/// <param name="node">Node in the project tree.</param>
		/// <returns>True on success, otherwise false.</returns>
		public static bool MakeFiles( System.Windows.Forms.TreeNode node )
		{
			string errorMessage = String.Empty;
			bool ret = true;
			
			if ( !InitializeBuildDirectory(node) )
			{
				return false;
			}
			
			// Save Script files
			ret = ret & ( SaveScripts(node) );
			
			// Save Image files
			ret = ret & ( SaveImages(node) );
			
			// Save CSS files
			ret = ret & ( SaveCSS(node) );
			
			if ( !ret )
			{
				Log.ErrorBox("Problem saving one or more files.  Please see the log file for details.");
			}
			
			// Create node information list (ID, Prev Link, Next Link, etc)
			// and the images information list
			MakeIndices(node);
			
			// Create HTML files
			if ( !MakeAllHTML(node) )
			{
				Log.ErrorBox("Problem creating one or more HTML files.  Please see the log file for details.");
				ret = false;
			}
			
			// Create ToC file
			if ( !MakeProjectTOC(node) )
			{
				Log.ErrorBox("Problem creating the project Table of Contents file.  Please see the log file for details.");
				ret = false;
			}
			
			// Create Text Popup file
			int popupTextCount = MakeProjectPopupText(node);
			
			// Create Index File
			if ( !MakeProjectIndex(node) )
			{
				Log.ErrorBox("Problem creating the project Index file.  Please see the log file for details.");
				ret = false;
			}
			
			// Create Compiler Project file
			if ( !MakeProjectCompilerFile(node) )
			{
				Log.ErrorBox("Problem creating the Project file for the compiler.  Please see the log file for details.");
				ret = false;
			}

			return ret;
		}
		
		// ==============================================================================
		/// <summary>
		/// Creates and compiles the project files to a compiled HTML Help file (.chm) 
		/// </summary>
		/// <param name="node">Node in the project tree.</param>
		/// <param name="outputFile">Path and name of the compiled output file.</param>
		/// <returns>True on success, otherwise false.</returns>
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
