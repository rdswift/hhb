/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-10-22
 * Time: 12:31
 */

using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
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
			StringBuilder toc = new StringBuilder();
			toc.AppendLine("<!DOCTYPE HTML PUBLIC \"-//IETF//DTD HTML//EN\">");
			toc.AppendLine("<HTML>");
			toc.AppendLine("<HEAD>");
			toc.AppendLine("<meta name=\"GENERATOR\" content=\"Microsoft&reg; HTML Help Workshop 4.1\">\n");
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
		private static void recurseTOC(ref StringBuilder sb, TreeNode node, int offset)
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
			DataTable dt = MakeIndexTable(node);
			
			// Sort index entry heierarchy
			DataView dv = dt.DefaultView;
			dv.Sort = "AlphaSort";
			DataTable sDT = dv.ToTable();
			
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("<!DOCTYPE HTML PUBLIC \"-//IETF//DTD HTML//EN\">");
			sb.AppendLine("<HTML>");
			sb.AppendLine("<HEAD>");
			sb.AppendLine("<meta name=\"GENERATOR\" content=\"Microsoft&reg; HTML Help Workshop 4.1\">");
			sb.AppendLine();
			sb.AppendLine("<!-- Sitemap 1.0 -->");
			sb.AppendLine("</HEAD><BODY>");
			sb.AppendLine("<OBJECT type=\"text/site properties\">");
			sb.AppendLine("	<param name=\"FrameName\" value=\"current\">");
			sb.AppendLine("</OBJECT>");
			sb.AppendLine("<UL>");
			
			string oGroup = String.Empty;
			int indent = 4;
			foreach (DataRow dr in sDT.Rows)
			{
				string itemGroup = dr["Group"].ToString(); 
				if ( itemGroup.ToUpper() != oGroup )
				{
					if ( !String.IsNullOrWhiteSpace(oGroup) )
					{
						indent -= 4;
						sb.AppendFormat("{0}</UL>", String.Empty.PadLeft(indent));
						sb.AppendLine();
					}
					
					if ( !String.IsNullOrWhiteSpace(itemGroup) )
					{
						sb.AppendFormat("{0}<LI> <OBJECT type=\"text/sitemap\">", String.Empty.PadLeft(indent));
						sb.AppendLine();
						sb.AppendFormat("{0}<param name=\"Name\" value=\"{1}\">", String.Empty.PadLeft(indent + 4), WebUtility.HtmlEncode(itemGroup));
						sb.AppendLine();
						sb.AppendFormat("{0}<param name=\"See Also\" value=\"{1}\">", String.Empty.PadLeft(indent + 4), WebUtility.HtmlEncode(itemGroup));
						sb.AppendLine();
						sb.AppendFormat("{0}</OBJECT>", String.Empty.PadLeft(indent + 4));
						sb.AppendLine();
						sb.AppendFormat("{0}<UL>", String.Empty.PadLeft(indent));
						sb.AppendLine();
						indent += 4;
					}
					
					oGroup = itemGroup.ToUpper();
				}

				sb.AppendFormat("{0}<LI> <OBJECT type=\"text/sitemap\">", String.Empty.PadLeft(indent));
				sb.AppendLine();
				sb.AppendFormat("{0}<param name=\"Name\" value=\"{1}\">", String.Empty.PadLeft(indent + 4), WebUtility.HtmlEncode(dr["Topic"].ToString()));
				sb.AppendLine();
				sb.AppendFormat("{0}<param name=\"Local\" value=\"{1}\">", String.Empty.PadLeft(indent + 4), dr["FileName"]);
				sb.AppendLine();
				sb.AppendFormat("{0}</OBJECT>", String.Empty.PadLeft(indent + 4));
				sb.AppendLine();
			}
			
			while ( indent > 4 )
			{
				indent -= 4;
				sb.AppendFormat("{0}</UL>", String.Empty.PadLeft(indent));
				sb.AppendLine();
			}
			
			sb.AppendLine("</UL>");
			sb.AppendLine("</BODY></HTML>");
			
			string outputFile = Path.Combine(HBSettings.projectBuildDir, "index.hhk");
			try
			{
				Log.Debug(String.Format("Creating Index file {0}", outputFile));
				File.WriteAllText(outputFile, sb.ToString());
			}
			catch (Exception ex)
			{
				Log.Error(String.Format("Problem writing Index file {0}", outputFile));
				Log.Exception(ex);
				return false;
				//throw;
			}
			
			return true;
		}
		
		// ==============================================================================
		private static DataTable MakeIndexTable(TreeNode node)
		{
			DataTable dt;
			DataColumn dc;
			
			dt = new DataTable();
			dt.TableName = "IndexTable";
			dc = new DataColumn("ID", Type.GetType("System.Int32"));
			dt.Columns.Add(dc);
			dc = new DataColumn("AlphaSort", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Group", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Topic", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Title", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("FileName", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			
			dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
			dt.Rows.Clear();
			
			int indexCount = 0;
			RecurseIndexTable(ref dt, HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.tocEntry], ref indexCount);
			RecurseIndexTable(ref dt, HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.htmlPopup], ref indexCount);
			
			return dt;
		}
		
		// ==============================================================================
		private static void RecurseIndexTable(ref DataTable dt, TreeNode node, ref int indexCount)
		{
			foreach (TreeNode tNode in node.Nodes)
			{
				HelpItem tItem = (HelpItem) tNode.Tag;
				if ( tItem.hasScreen )
				{
					string[] tArray = tItem.indexArray;
					foreach (string indexLine in tArray)
					{
						indexCount++;
						DataRow dr = dt.NewRow();
						dr["ID"] = indexCount;
						dr["AlphaSort"] = indexLine.Trim().ToUpper();
						dr["Title"] = tItem.title;
						dr["FileName"] = tItem.fileName;
						int splitPointer = indexLine.IndexOf('`');
						if ( splitPointer < 0 )
						{
							dr["Group"] = String.Empty;
							dr["Topic"] = indexLine;
						}
						else
						{
							dr["Group"] = indexLine.Substring(0, splitPointer);
							dr["Topic"] = indexLine.Substring(splitPointer + 1);
						}
						dt.Rows.Add(dr);
					}
				}
				RecurseIndexTable(ref dt, tNode, ref indexCount);
			}
		}
		
		// ==============================================================================
		private static int MakeProjectPopupText(TreeNode node)
		{
			int topicCount = 0;
			
			StringBuilder popupText = new StringBuilder();
			StringBuilder popupMap = new StringBuilder();
			
			foreach (TreeNode tNode in HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.textPopup].Nodes)
			{
				PopupTextItem tItem = (PopupTextItem) tNode.Tag;
				popupText.AppendFormat(".topic IDH_{0}\n{1}", tItem.id, tItem.helpText.Trim());
				popupText.AppendLine(String.Empty);
				popupText.AppendLine(String.Empty);
				popupMap.AppendFormat("#define IDH_{0}  {1}", tItem.id, tItem.linkID.ToString().Trim());
				popupMap.AppendLine(String.Empty);
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
		private static bool MakeProjectCompilerFile(TreeNode node, bool includePopupText)
		{
			HHBProject project = (HHBProject) HelpNode.GetRootNode(node).Tag;
			
			StringBuilder sbFiles = new StringBuilder();
			StringBuilder sbAlias = new StringBuilder();
			StringBuilder sbMap = new StringBuilder();
			
			sbFiles.AppendLine("[FILES]");
			sbAlias.AppendLine("[ALIAS]");
			sbMap.AppendLine("[MAP]");
			
			RecurseFileAndMapList(HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.tocEntry], ref sbFiles, ref sbAlias, ref sbMap);
			RecurseFileAndMapList(HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.htmlPopup], ref sbFiles, ref sbAlias, ref sbMap);
			
			FilesListAddImages(HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.imageFile], ref sbFiles);
			FilesListAddCSS(HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.cssFile], ref sbFiles);
			FilesListAddScripts(HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.scriptFile], ref sbFiles);
			
			FilesListAddTemplateFiles(ref sbFiles);

			StringBuilder sb = new StringBuilder();
			sb.AppendLine("[OPTIONS]");
			sb.AppendLine("Auto Index=Yes");
			sb.AppendLine("Compatibility=1.1 or later");
			sb.AppendLine("Compiled file=HHBuilder.chm");
			sb.AppendLine("Contents file=toc.hhc");
			sb.AppendLine("Default Font=Arial,8,0");
			sb.AppendLine("Default Window=Main");
			//sb.AppendFormat("Default topic={0}\n", _homeFileName);		// Need include in window definition and not in options
			sb.AppendLine("Display compile notes=Yes");
			sb.AppendLine("Display compile progress=Yes");
			sb.AppendLine("Error Log file=HHBuilder.log");
			if ( project.useFullTextSearch )
			{
				sb.AppendLine("Full text search stop list file=HHBuilder.stp");
				sb.AppendLine("Full-text search=Yes");
				string stopList = "a an and are as at be by for he her his in is it its me of on or she some such than that the their then there these they this through to under until use was we were when where which who with you ";
				stopList = stopList.Replace(" ", Environment.NewLine);
				string stopFile = Path.Combine(HBSettings.projectBuildDir, "HHBuilder.stp");
				try
				{
					Log.Debug(String.Format("Creating compiler project text search stop file {0}", stopFile));
					File.WriteAllText(stopFile, stopList);
				}
				catch (Exception ex)
				{
					Log.Error(String.Format("Problem writing compiler project text search stop file {0}", stopFile));
					Log.Exception(ex);
					return false;
					//throw;
				}
				
			}
			sb.AppendLine("Index file=index.hhk");
			sb.AppendFormat("Language={0}", project.language);
			//sb.AppendFormat("Title={0}\n", project.title);
			sb.AppendLine("");
			sb.AppendLine("");
			sb.AppendLine("");
			sb.AppendLine("[WINDOWS]");
			sb.AppendFormat("Main=\"{0}\",\"toc.hhc\",\"index.hhk\",\"{1}\",,,,,,0x22520,,0x3006,[568,222,1338,738],,,,,,,0", project.title, _homeFileName);
			//sb.AppendFormat("Main=\"{0}\",\"toc.hhc\",\"index.hhk\",,,,,,,0x22520,,0x3006,[568,222,1338,738],,,,,,,0", project.title);
			sb.AppendLine("");
			sb.AppendLine("");
			sb.AppendLine("");
			sb.AppendLine(sbFiles.ToString());
			sb.AppendLine(sbAlias.ToString());
			sb.AppendLine(sbMap.ToString());
			
			if ( includePopupText )
			{
				sb.AppendLine("[TEXT POPUPS]");
				sb.AppendLine("textpopups.txt");
				sb.AppendLine("textpopups.h");
				sb.AppendLine("");
			}
			
			sb.AppendLine("[INFOTYPES]");
			sb.AppendLine("");
			
			string outputFile = Path.Combine(HBSettings.projectBuildDir, "HHBuilder.hhp");
			try
			{
				Log.Debug(String.Format("Creating compiler project file {0}", outputFile));
				File.WriteAllText(outputFile, sb.ToString());
			}
			catch (Exception ex)
			{
				Log.Error(String.Format("Problem writing compiler project file {0}", outputFile));
				Log.Exception(ex);
				return false;
				//throw;
			}
			
			return true;
		}
		
		// ==============================================================================
		private static void FilesListAddImages(TreeNode node, ref StringBuilder sbFiles)
		{
			foreach (TreeNode tNode in node.Nodes)
			{
				ImageItem tItem = (ImageItem) tNode.Tag;
				sbFiles.AppendLine(String.Format("{0}/{1}", imageDirName, tItem.fileName));
			}
		}
		
		// ==============================================================================
		private static void FilesListAddCSS(TreeNode node, ref StringBuilder sbFiles)
		{
			foreach (TreeNode tNode in node.Nodes)
			{
				CSSItem tItem = (CSSItem) tNode.Tag;
				sbFiles.AppendLine(String.Format("{0}/{1}", cssDirName, tItem.fileName));
			}
		}
		
		// ==============================================================================
		private static void FilesListAddScripts(TreeNode node, ref StringBuilder sbFiles)
		{
			foreach (TreeNode tNode in node.Nodes)
			{
				ScriptItem tItem = (ScriptItem) tNode.Tag;
				sbFiles.AppendLine(String.Format("{0}/{1}", scriptDirName, tItem.fileName));
			}
		}
		
		// ==============================================================================
		private static void FilesListAddTemplateFiles(ref StringBuilder sbFiles)
		{
			string[] dirsToCheck = { "tpl_css", "tpl_images", "tpl_scripts", "tpl_other" };
			foreach (string dir in dirsToCheck)
			{
				string searchDir = Path.Combine(HBSettings.projectBuildDir, dir);
				if ( Directory.Exists(searchDir) )
				{
					string[] fileList = Directory.GetFiles(searchDir);
					foreach (string fileToList in fileList)
					{
						sbFiles.AppendLine(String.Format("{0}/{1}", dir, Path.GetFileName(fileToList)));
					}
				}
			}
		}
		
		// ==============================================================================
		private static void RecurseFileAndMapList(TreeNode node, ref StringBuilder sbFiles, ref StringBuilder sbAlias, ref StringBuilder sbMap)
		{
			foreach (TreeNode tNode in node.Nodes)
			{
				HelpItem tItem = (HelpItem) tNode.Tag;
				if ( tItem.hasScreen )
				{
					sbFiles.AppendLine(tItem.fileName);
					sbAlias.AppendFormat("H_{0}={1}", tItem.id, tItem.fileName);
					sbAlias.AppendLine(String.Empty);
					if ( tItem.linkID > 0 )
					{
						sbMap.AppendFormat("#define H_{0} {1}", tItem.id, tItem.linkID);
						sbMap.AppendLine(String.Empty);
					}
				}
				RecurseFileAndMapList(tNode, ref sbFiles, ref sbAlias, ref sbMap);
			}
		}
		
		// ==============================================================================
		private static string ParseHtmlBody(TreeNode node, HelpItem hItem)
		{
			string repBody = ReplaceParameters(node, hItem, hItem.body);
			repBody = CommonMark.CommonMarkConverter.Convert(repBody);
			
			
			
			
			// TODO: Insert body text preprocessing here.
			
			
			
			
			// Create style entry to hide unwanted sections
			bool bTest = false;
			StringBuilder sb = new StringBuilder();
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
				StringBuilder sbRef = new StringBuilder();
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
				StringBuilder sbCSS = new StringBuilder();
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
				StringBuilder sbScript = new StringBuilder();
				string[] scriptArray = hItem.scriptArray;
				foreach (string tScript in scriptArray)
				{
					string outFile = Path.Combine(scriptDir, tScript + ".js");
					if ( !File.Exists(outFile) )
					{
						MakeScriptFile(node, tScript);
					}
					if ( File.Exists(outFile) )
					{
						sbScript.AppendFormat("<script type=\"text/javascript\" src=\"{0}/{1}\"></script>\n", scriptDirName, tScript + ".js");
					}
					else
					{
						Log.Error("Missing script file " + outFile);
					}
				}
				headerScripts = sbScript.ToString();
			}
			
			// Process links
			repBody = ProcessLinks(repBody);
			
			// Process image links
			repBody = ProcessImageLinks(node, repBody);
			
			string tHTML = ReplaceParameters(node, hItem, _htmlTemplate);
			tHTML = tHTML.Replace("</head>", headerScripts + headerCSS + hideItems + "</head>");
			tHTML = tHTML.Replace("{BODY}", repBody);
			tHTML = tHTML.Replace("{REFERENCES}", references);
			
			return tHTML;
		}
		
		// ==============================================================================
		private static string ReplaceParameters(TreeNode node, HelpItem hItem, string htmlText)
		{
			string tHTML = htmlText;
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
				dr["IndexPath"] = "Popup HTML";
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
		private static void DatasetAddText(TreeNode node)
		{
			TreeNode topNode = HelpNode.GetRootNode(node);
			foreach (TreeNode tNode in topNode.Nodes[(int) HelpNode.branches.textPopup].Nodes)
			{
				DataRow dr = _nodeDS.Tables[0].NewRow();
				PopupTextItem tItem = (PopupTextItem) tNode.Tag;
				dr["ID"] = tItem.id;
				dr["IndexPath"] = "Popup Text";
				dr["PrevLink"] = String.Empty;
				dr["PrevText"] = String.Empty;
				dr["PrevNumber"] = String.Empty;
				dr["NextLink"] = String.Empty;
				dr["NextText"] = String.Empty;
				dr["NextNumber"] = String.Empty;
				dr["Title"] = tItem.title;
				dr["IndexEntries"] = String.Empty;
				dr["ReferenceLinks"] = String.Empty;
				dr["ScriptLinks"] = String.Empty;
				dr["ReferenceLinks"] = String.Empty;
				dr["ShowScreen"] = true;
				dr["ShowTitle"] = false;
				dr["ShowHeader"] = false;
				dr["ShowFooter"] = false;
				dr["Body"] = String.Empty;
				dr["FileName"] = String.Empty;
				dr["LinkID"] = tItem.linkID;
				dr["LinkDesc"] = String.Empty;
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
				string info = String.Format("Saving CSS file {0} - {1}", tItem.fileName, tItem.title); 
				Log.Debug(info);
				((MainForm) Form.ActiveForm).ProgressAddLine(info);
				try
				{
					File.WriteAllText(fileToWrite, tItem.content);
				}
				catch (Exception ex)
				{
					string errorMessage = String.Format("Error writing CSS file {0}", fileToWrite);
					Log.Error(errorMessage);
					Log.Exception(ex);
					((MainForm) Form.ActiveForm).ProgressAddLine(errorMessage);
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
				string info = String.Format("Saving script file {0} - {1}", tItem.fileName, tItem.title); 
				Log.Debug(info);
				((MainForm) Form.ActiveForm).ProgressAddLine(info);
				try
				{
					File.WriteAllText(fileToWrite, tItem.content);
					((MainForm) Form.ActiveForm).ProgressAddStep();
				}
				catch (Exception ex)
				{
					string errorMessage = String.Format("Error writing script file {0}", fileToWrite);
					Log.Error(errorMessage);
					Log.Exception(ex);
					((MainForm) Form.ActiveForm).ProgressAddLine(errorMessage);
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
				string info = String.Format("Saving image file {0} - {1}", tItem.fileName, tItem.title);
				Log.Debug(info);
				((MainForm) Form.ActiveForm).ProgressAddLine(info);
				try
				{
					byte[] imageBytes = Convert.FromBase64String(tItem.content);
					File.WriteAllBytes(fileToWrite, imageBytes);
					((MainForm) Form.ActiveForm).ProgressAddStep();
				}
				catch (Exception ex)
				{
					string errorMessage = String.Format("Error writing image file {0}", fileToWrite);
					Log.Error(errorMessage);
					Log.Exception(ex);
					((MainForm) Form.ActiveForm).ProgressAddLine(errorMessage);
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
		
		// ==============================================================================
		private static void procOutputReceived(object sendingProcess, DataReceivedEventArgs e)
		{
			if ( !String.IsNullOrEmpty(e.Data) )
			{
				if ( Application.OpenForms["MainForm"].InvokeRequired )
				{
					string[] textLine = { e.Data };
					Application.OpenForms["MainForm"].BeginInvoke(new myDelegate(procDataReceived), textLine);
				}
				else
				{
					((MainForm) Application.OpenForms["MainForm"]).ProgressAddLine(e.Data);
				}
			}
		}
		
		// ==============================================================================
		private delegate void myDelegate(string textLine);
		
		// ==============================================================================
		private static void procDataReceived(string textLine)
		{
			((MainForm) Form.ActiveForm).ProgressAddLine(textLine);
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
			TreeNode tNode = FindScreenNode(HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.tocEntry], id);
			if ( tNode == null )
			{
				tNode = FindScreenNode(HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.htmlPopup], id);
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
		private static TreeNode FindScreenNode(TreeNode node, string id)
		{
			foreach (TreeNode cNode in node.Nodes)
			{
				if ( ( (HelpItem) cNode.Tag).id == id )
				{
					return cNode;
				}
				TreeNode tNode = FindScreenNode(cNode, id);
				if ( tNode != null )
				{
					return tNode;
				}
			}
			return null;
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
				string errorMessage = String.Format("Error saving HTML file {0}", tItem.fileName);
				Log.Error(errorMessage);
				Log.Exception(ex);
				((MainForm) Form.ActiveForm).ProgressAddLine(errorMessage);
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
			bool retValue = true;
			foreach (DataRow dr in _nodeDS.Tables[0].Rows)
			{
				if ( (bool) dr["ShowScreen"] )
				{
					((MainForm) Form.ActiveForm).ProgressAddLine(String.Format("Writing {0}.html - {1}", dr["ID"].ToString().Trim(), dr["Title"].ToString().Trim()));
					retValue = retValue & MakeHtmlFile(node, dr["ID"].ToString().Trim(), false);
					((MainForm) Form.ActiveForm).ProgressAddStep();
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
		public static bool MakeFiles(TreeNode node)
		{
			string errorMessage = String.Empty;
			bool ret = true;
			
			((MainForm) Form.ActiveForm).ProgressInitialize(HelpNode.NodeCount(HelpNode.GetRootNode(node)));
			//((MainForm) Form.ActiveForm).ProgressAddLine(String.Format("Making files started at {0}", DateTime.Now.ToString("HH:mm:ss.fff")));
			((MainForm) Form.ActiveForm).ProgressAddLine("Starting Make of all help project files.");
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Format("Initializing build directory {0}", HBSettings.projectBuildDir));
			
			if ( !InitializeBuildDirectory(node) )
			{
				return false;
			}
			((MainForm) Form.ActiveForm).ProgressAddLine("Build directory initialized.");
			((MainForm) Form.ActiveForm).ProgressAddStep();
			
			// Save Script files
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Format("Saving {0} script files", HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.scriptFile].Nodes.Count));
			ret = ret & ( SaveScripts(node) );
			
			// Save Image files
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Format("Saving {0} image files", HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.imageFile].Nodes.Count));
			ret = ret & ( SaveImages(node) );
			
			// Save CSS files
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Format("Saving {0} Style Sheet (CSS) files", HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.cssFile].Nodes.Count));
			ret = ret & ( SaveCSS(node) );
			
			if ( !ret )
			{
				Log.ErrorBox("Problem saving one or more files.  Please see the log for details.");
			}
			
			// Create node information list (ID, Prev Link, Next Link, etc)
			// and the images information list
			((MainForm) Form.ActiveForm).ProgressAddLine("Preparing topic and image indices.");
			MakeIndices(node);
			((MainForm) Form.ActiveForm).ProgressAddLine("Topic and image indices complete.");
			((MainForm) Form.ActiveForm).ProgressAddStep();
			
			// Create HTML files
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Format("Saving {0} HTML files", _nodeDS.Tables[0].Rows.Count));
			if ( !MakeAllHTML(node) )
			{
				Log.ErrorBox("Problem creating one or more HTML files.  Please see the log file for details.");
				ret = false;
			}
			
			// Create ToC file
			((MainForm) Form.ActiveForm).ProgressAddLine("Preparing Table of Contents file.");
			if ( !MakeProjectTOC(node) )
			{
				Log.ErrorBox("Problem creating the project Table of Contents file.  Please see the log file for details.");
				ret = false;
			}
			((MainForm) Form.ActiveForm).ProgressAddLine("Table of Contents file complete.");
			((MainForm) Form.ActiveForm).ProgressAddStep();
			
			// Create Text Popup file
			((MainForm) Form.ActiveForm).ProgressAddLine("Preparing popup text file.");
			int popupTextCount = MakeProjectPopupText(node);
			if ( popupTextCount < 1 )
			{
				((MainForm) Form.ActiveForm).ProgressAddLine("Popup text file not required.  There were no entries found.");
			}
			else
			{
				((MainForm) Form.ActiveForm).ProgressAddLine("Popup text file complete.");
			}
			((MainForm) Form.ActiveForm).ProgressAddStep();
			
			// Create Index File
			((MainForm) Form.ActiveForm).ProgressAddLine("Preparing project Index file.");
			if ( !MakeProjectIndex(node) )
			{
				errorMessage = "Problem creating the project Index file.  Please see the log for details.";
				((MainForm) Form.ActiveForm).ProgressAddLine(errorMessage);
				Log.ErrorBox(errorMessage);
				ret = false;
			}
			else
			{
				((MainForm) Form.ActiveForm).ProgressAddLine("Project Index file complete.");
			}
			((MainForm) Form.ActiveForm).ProgressAddStep();
			
			// Create Compiler Project file
			((MainForm) Form.ActiveForm).ProgressAddLine("Preparing compiler project file.");
			if ( !MakeProjectCompilerFile(node, (popupTextCount > 0)) )
			{
				errorMessage = "Problem creating the Project file for the compiler.  Please see the log for details.";
				((MainForm) Form.ActiveForm).ProgressAddLine(errorMessage);
				Log.ErrorBox(errorMessage);
				ret = false;
			}
			else
			{
				((MainForm) Form.ActiveForm).ProgressAddLine("Compiler project file complete.");
			}
			((MainForm) Form.ActiveForm).ProgressAddStep();

			return ret;
		}
		
		// ==============================================================================
		/// <summary>
		/// Creates and compiles the project files to a compiled HTML Help file (.chm)
		/// </summary>
		/// <param name="node">Node in the project tree.</param>
		/// <param name="outputFile">Path and name of the compiled output file.</param>
		/// <returns>True on success, otherwise false.</returns>
		public static bool Compile(TreeNode node, string outputFile)
		{
			// make files
			if ( !MakeFiles(node) )
			{
				string errMsg = "Problem making all of the project files.";
				Log.Error(errMsg);
				Log.ErrorBox(errMsg + "  Please see the log for more information.");
				return false;
			}
			
			
			
			
			
			
			// check files
			// TODO: Check the validity of the generated files
			
			
			
			
			
			
			
			
			// run compile
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Empty.PadLeft(80, '='));
			((MainForm) Form.ActiveForm).ProgressAddLine("Compiling the help project.");
			string hhCompiler = Path.Combine(HBSettings.compilerDir, "hhc.exe");
			if ( !File.Exists(hhCompiler) )
			{
				string errMsg = String.Format("Unable to find HTML Help Compiler {0}", hhCompiler);
				Log.Error(errMsg);
				((MainForm) Form.ActiveForm).ProgressAddLine(errMsg);
				Log.ErrorBox(errMsg);
				return false;
			}
			
			ProcessStartInfo psi = new ProcessStartInfo(hhCompiler);
			psi.Arguments = Path.Combine(HBSettings.projectBuildDir, "HHBuilder.hhp");
			psi.WorkingDirectory = HBSettings.projectBuildDir;
			psi.RedirectStandardOutput = true;
			psi.RedirectStandardError = true;
			psi.UseShellExecute = false;
			psi.CreateNoWindow = true;
			
			Process compiler = new System.Diagnostics.Process();
			compiler.StartInfo = psi;
			compiler.OutputDataReceived += new DataReceivedEventHandler(procOutputReceived);
			compiler.ErrorDataReceived += new DataReceivedEventHandler(procOutputReceived);
			compiler.Start();
			compiler.BeginErrorReadLine();
			compiler.BeginOutputReadLine();
			while ( !compiler.HasExited )
			{
				Application.DoEvents();
			}
			
			compiler.WaitForExit();
			int eCode = compiler.ExitCode;	// For the hhc.exe program 1=success and 0=error
			compiler.WaitForExit();
			compiler.Close();
			((MainForm) Form.ActiveForm).ProgressAddStep();
			((MainForm) Form.ActiveForm).ProgressAddLine("Compile complete.");
			
//			Log.ErrorBox(String.Format("Compiler exit code: {0}", eCode));
			
			if ( eCode == 0 )
			{
				string eMessage = "The Help Compiler reported an error.";
				Log.Error(eMessage);
				((MainForm) Form.ActiveForm).ProgressAddLine(eMessage);
				Log.ErrorBox(String.Format("{0}  Please check the compiler log file for more information.\n\n{1}", eMessage, Path.Combine(HBSettings.projectBuildDir, "HHBuilder.log")));
				return false;
			}
			
			// copy compiled output to specified file
			((MainForm) Form.ActiveForm).ProgressAddLine("Copying compiled output to specified output file.");
			try
			{
				File.Copy(Path.Combine(HBSettings.projectBuildDir, "HHBuilder.chm"), outputFile, true);
			}
			catch (Exception ex)
			{
				string eMessage = String.Format("Problem copying the compiled file to the specified output file {0}", outputFile);
				Log.Error(eMessage);
				Log.Exception(ex);
				((MainForm) Form.ActiveForm).ProgressAddLine(eMessage);
				Log.ErrorBox(eMessage);
				return false;
				//throw;
			}
			((MainForm) Form.ActiveForm).ProgressAddStep();
			
			return true;
		}
		
		// ==============================================================================
		/// <summary>
		/// Creates a screen topic map report which is displayed in the progress window.
		/// </summary>
		/// <param name="node">Node in the project tree.</param>
		/// <returns>True on success, or false if there are no topic entries in the project.</returns>
		public static bool ShowScreenMap(TreeNode node)
		{
			// Make HTML nodes index
			_nodeDS = InitializeNodeDataset();
			DatasetAddTOC(node);
			DatasetAddPopup(node);
			DatasetAddText(node);
			
			if ( _nodeDS.Tables[0].Rows.Count < 1 )
			{
				Log.ErrorBox("No screens in the project to map.");
				return false;
			}
			
			((MainForm) Form.ActiveForm).ProgressInitialize(_nodeDS.Tables[0].Rows.Count * 2);
			((MainForm) Form.ActiveForm).ProgressAddLine("Preparing help project topic map report.");
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Empty);
			
			DataView dv;
			DataTable sortedDT;
			
			// Sort by map number
			dv = _nodeDS.Tables[0].DefaultView;
			dv.Sort = "LinkID ASC";
			sortedDT = dv.ToTable();
			
			StringBuilder sbDuplicates = new StringBuilder();
			StringBuilder sbUnmappedPopups = new StringBuilder();
			StringBuilder sbMappedByLink = new StringBuilder();
			int previousLinkID = 0;
			bool errorLogged = false;
			foreach (DataRow dr in sortedDT.Rows)
			{
				int tLink = Convert.ToInt32(dr["LinkID"].ToString());
				if ( tLink > 0 )
				{
					sbMappedByLink.AppendLine(String.Format("{0,10}\t{1,-25}\t{2}", tLink, dr["IndexPath"].ToString().TrimStart('0'), dr["Title"]));
					if ( tLink == previousLinkID )
					{
						if ( !errorLogged )
						{
							sbDuplicates.AppendLine(String.Format("Error:\tLink {0} is mapped to more than one screen.", dr["LinkID"]));
							errorLogged = true;
						}
					}
					else
					{
						errorLogged = false;
					}
				}
				else
				{
					if ( dr["IndexPath"].ToString().StartsWith("P") )
					{
						sbUnmappedPopups.AppendLine(String.Format("Warning:\tUnmapped {0}: {1}", dr["IndexPath"], dr["Title"]));
					}
				}
				previousLinkID = tLink;
				((MainForm) Form.ActiveForm).ProgressAddStep();
			}
			
			// Sort help screen heierarchy
			dv = _nodeDS.Tables[0].DefaultView;
			dv.Sort = "IndexPath ASC";
			sortedDT = dv.ToTable();
			
			StringBuilder sbMappedByIndex = new StringBuilder();
			StringBuilder sbNotMapped = new StringBuilder();
			foreach (DataRow dr in sortedDT.Rows)
			{
				int tLink = Convert.ToInt32(dr["LinkID"].ToString());
				if ( tLink > 0 )
				{
					sbMappedByIndex.AppendLine(String.Format("{0,10}\t{1,-25}\t{2}", tLink, dr["IndexPath"].ToString().TrimStart('0'), dr["Title"]));
				}
				else
				{
					sbNotMapped.AppendLine(String.Format("{0,-25}\t{1}", dr["IndexPath"].ToString().TrimStart('0'), dr["Title"]));
				}
				((MainForm) Form.ActiveForm).ProgressAddStep();
			}
			
			((MainForm) Form.ActiveForm).ProgressAddLine("Mapped Screens (sorted by link number)");
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Empty);
			
			if ( sbMappedByLink.Length > 0 )
			{
				foreach (string tString in sbMappedByLink.ToString().TrimEnd().Split('\n'))
				{
					((MainForm) Form.ActiveForm).ProgressAddLine(tString);
				}
			}
			else
			{
				((MainForm) Form.ActiveForm).ProgressAddLine("None.");
			}
			
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Empty);
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Empty);
			
			((MainForm) Form.ActiveForm).ProgressAddLine("Mapped Screens (sorted by ToC index)");
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Empty);
			
			if ( sbMappedByIndex.Length > 0 )
			{
				foreach (string tString in sbMappedByIndex.ToString().TrimEnd().Split('\n'))
				{
					((MainForm) Form.ActiveForm).ProgressAddLine(tString);
				}
			}
			else
			{
				((MainForm) Form.ActiveForm).ProgressAddLine("None.");
			}
			
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Empty);
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Empty);
			
			((MainForm) Form.ActiveForm).ProgressAddLine("Unmapped Screens");
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Empty);
			
			if ( sbNotMapped.Length > 0 )
			{
				foreach (string tString in sbNotMapped.ToString().TrimEnd().Split('\n'))
				{
					((MainForm) Form.ActiveForm).ProgressAddLine(tString);
				}
			}
			else
			{
				((MainForm) Form.ActiveForm).ProgressAddLine("None.");
			}
			
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Empty);
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Empty);
			
			((MainForm) Form.ActiveForm).ProgressAddLine("Errors and Warnings");
			((MainForm) Form.ActiveForm).ProgressAddLine(String.Empty);
			
			if ( sbDuplicates.Length > 0 )
			{
				foreach (string tString in sbDuplicates.ToString().TrimEnd().Split('\n'))
				{
					((MainForm) Form.ActiveForm).ProgressAddLine(tString);
				}
			}
			
			if ( sbUnmappedPopups.Length > 0 )
			{
				foreach (string tString in sbUnmappedPopups.ToString().TrimEnd().Split('\n'))
				{
					((MainForm) Form.ActiveForm).ProgressAddLine(tString);
				}
			}
			
			if ( (sbDuplicates.Length + sbUnmappedPopups.Length) > 0 )
			{
				((MainForm) Form.ActiveForm).ProgressAddLine(String.Empty);
				((MainForm) Form.ActiveForm).ProgressAddLine(String.Empty);
			}
			((MainForm) Form.ActiveForm).ProgressAddLine("Help project topic map report complete");
			((MainForm) Form.ActiveForm).ProgressAddStep();
			
			return true;
		}
		#endregion
	}
}
