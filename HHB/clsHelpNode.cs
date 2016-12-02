/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-10-27
 * Time: 15:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace HHBuilder
{
	/// <summary>
	/// Class module for managing the treenodes comprising the help project.
	/// </summary>
	public static class HelpNode
	{
		#region Private Member Variables
		#endregion

		#region Private Properties
		#endregion
		
		#region Private Methods
		// ==============================================================================
		/// <summary>
		/// Initialize the treenode collection for a project tree
		/// </summary>
		/// <returns>The root node of the project treenode collection</returns>
		private static TreeNode InitializeTreeNode()
		{
			HHBProject proj = new HHBProject();
			TreeNode topNode = new TreeNode();
			
			topNode.Tag = proj;
			topNode.Text = proj.title;
			topNode.ForeColor = System.Drawing.Color.Blue;
			TreeNode tempNode = topNode.Nodes.Add("Table of Contents");
			tempNode.ForeColor = System.Drawing.Color.DarkRed;
			tempNode = topNode.Nodes.Add("Popup HTML Screens");
			tempNode.ForeColor = System.Drawing.Color.DarkRed;
			tempNode = topNode.Nodes.Add("Popup Text");
			tempNode.ForeColor = System.Drawing.Color.Black;
			tempNode = topNode.Nodes.Add("CSS Files");
			tempNode.ForeColor = System.Drawing.Color.Green;
			tempNode = topNode.Nodes.Add("Script Files");
			tempNode.ForeColor = System.Drawing.Color.Purple;
			tempNode = topNode.Nodes.Add("Image Files");
			tempNode.ForeColor = System.Drawing.Color.Blue;
			
			Log.Debug("Treenode collection initialized.");
			
			return topNode;
		}
		
		// ==============================================================================
		/// <summary>
		/// Recurse through all children of the specified node to build node list
		/// </summary>
		/// <param name="title">List of nodes processed so far.</param>
		/// <param name="tNode">Node to process.</param>
		/// <param name="offset">Number of spaces to offset each level.</param>
		/// <returns>Updated list of nodes processed.</returns>
		private static string RecurseNodeList(string title, TreeNode tNode, int offset)
		{
			string ts = title + ("").PadLeft(tNode.Level * offset) + tNode.Text + "\n";
			foreach (TreeNode rNode in tNode.Nodes) {
				ts = RecurseNodeList(ts, rNode, offset);
			}
			return ts;
		}

		// ==============================================================================
		/// <summary>
		/// Recurse through all children of the specified node to increase count
		/// </summary>
		/// <param name="count">Current number of nodes processed.</param>
		/// <param name="tNode">Node to process.</param>
		/// <returns></returns>
		private static int RecurseCount(int count, TreeNode tNode)
		{
			count++;
			foreach (TreeNode rNode in tNode.Nodes) {
				count = RecurseCount(count, rNode);
			}
			return count;
		}
		
		// ==============================================================================
		/// <summary>
		/// Converts an HTML Help project tree to a dataset.
		/// </summary>
		/// <param name="node">Node in the HTML Help project tree.</param>
		/// <returns>The dataset representing the project tree.</returns>
		private static DataSet TreeToDataset(TreeNode node)
		{
			DataSet ds = InitializeDataset();
			TreeNode topNode = GetRootNode(node);
			
			// Settings Table
			HHBProject proj = (HHBProject) topNode.Tag;
			ds.Tables[0].Rows.Clear();
			DataRow dr = ds.Tables[0].NewRow();
			dr["ProjectName"] = proj.title;
			dr["Author"] = proj.author;
			dr["Company"] = proj.company;
			dr["Copyright"] = proj.copyright;
			dr["Language"] = proj.language;
			dr["DefaultTopic"] = proj.defaultTopic;
			dr["FullTextSearch"] = proj.useFullTextSearch.ToString();
			dr["Template"] = proj.template;
			ds.Tables[0].Rows.Add(dr);
			
			// Help Screens Table
			ds.Tables[1].Rows.Clear();
			foreach (TreeNode tNode in topNode.Nodes)
			{
				RecurseTreeToDataset(ref ds, tNode);
			}
			
			// Popup Text Table
			ds.Tables[2].Rows.Clear();
			foreach (TreeNode tNode in topNode.Nodes[(int) branches.textPopup].Nodes)
			{
				PopupTextItem tItem = (PopupTextItem) tNode.Tag;
				dr = ds.Tables[2].NewRow();
				dr["ID"] = tItem.id;
				dr["Title"] = tItem.title;
				dr["LinkID"] = tItem.linkID.ToString();
				dr["HelpText"] = tItem.helpText;
				ds.Tables[2].Rows.Add(dr);
			}
			
			// CSS Files Table
			ds.Tables[3].Rows.Clear();
			foreach (TreeNode tNode in topNode.Nodes[(int) branches.cssFile].Nodes)
			{
				CSSItem tItem = (CSSItem) tNode.Tag;
				dr = ds.Tables[3].NewRow();
				dr["ID"] = tItem.id;
				dr["Title"] = tItem.title;
				dr["FileName"] = tItem.fileName;
				dr["FileContents"] = tItem.content;
				ds.Tables[3].Rows.Add(dr);
			}
			
			// Script Files Table
			ds.Tables[4].Rows.Clear();
			foreach (TreeNode tNode in topNode.Nodes[(int) branches.scriptFile].Nodes)
			{
				ScriptItem tItem = (ScriptItem) tNode.Tag;
				dr = ds.Tables[4].NewRow();
				dr["ID"] = tItem.id;
				dr["Title"] = tItem.title;
				dr["FileName"] = tItem.fileName;
				dr["FileContents"] = tItem.content;
				ds.Tables[4].Rows.Add(dr);
			}
			
			// Image Files Table
			ds.Tables[5].Rows.Clear();
			foreach (TreeNode tNode in topNode.Nodes[(int) branches.imageFile].Nodes)
			{
				ImageItem tItem = (ImageItem) tNode.Tag;
				dr = ds.Tables[5].NewRow();
				dr["ID"] = tItem.id;
				dr["Title"] = tItem.title;
				dr["FileName"] = tItem.fileName;
				dr["FileContents"] = tItem.content;
				ds.Tables[5].Rows.Add(dr);
			}
			
			Log.Debug("Project tree converted to dataset.");
			
			return ds;
		}
		
		// ==============================================================================
		/// <summary>
		/// Recurse the specified treenode to add the information to the dataset.
		/// </summary>
		/// <param name="ds">The dataset to update.</param>
		/// <param name="tNode">Node to process.</param>
		private static void RecurseTreeToDataset(ref DataSet ds, TreeNode tNode)
		{
			int nIdx = GetBranchIndex(tNode);
			if ((tNode.Level > 1) && ((nIdx == (int) branches.tocEntry) || (nIdx == (int) branches.htmlPopup)))
			{
				HelpItem tnItem = (HelpItem) tNode.Tag;
				DataRow dr = ds.Tables[1].NewRow();
				dr["ID"] = tnItem.id;
				dr["IndexPath"] = NodeIndexPath(tNode).Split(' ')[0];
				switch (nIdx) {
					case (int) branches.tocEntry :
						dr["ScreenType"] = "TOC";
						break;
					case (int) branches.htmlPopup :
						dr["ScreenType"] = "Popup";
						break;
					default:
						dr["ScreenType"] = "Unknown";
						Log.Error("Unknown HTML screen type.");
						break;
				}
				dr["FileName"] = tnItem.fileName;
				dr["HasScreen"] = tnItem.hasScreen.ToString();
				dr["UseTitle"] = tnItem.usesTitle.ToString();
				dr["UseHeader"] = tnItem.usesHeader.ToString();
				dr["UseFooter"] = tnItem.usesFooter.ToString();
				dr["Title"] = tnItem.title;
				dr["IndexEntries"] = tnItem.indexEntries;
				dr["LinkID"] = tnItem.linkID.ToString();
				dr["LinkDesc"] = tnItem.linkDescription;
				dr["LinkList"] = tnItem.linkList;
				dr["CssList"] = tnItem.cssList;
				dr["ScriptList"] = tnItem.scriptList;
				dr["Body"] = tnItem.body;
				ds.Tables[1].Rows.Add(dr);
			}
			foreach (TreeNode cNode in tNode.Nodes)
			{
				RecurseTreeToDataset(ref ds, cNode);
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// Initialize the dataset and set up the data tables
		/// </summary>
		/// <returns>The initialized dataset.</returns>
		private static DataSet InitializeDataset()
		{
			DataSet ds = new DataSet();
			ds.DataSetName = "HelpData";
			
			// Prepare Settings DataTable
			DataTable dt = new DataTable();
			dt.TableName = "Settings";
			
			DataColumn dc;
			
			dc = new DataColumn("ProjectName", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Author", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Company", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Copyright", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Language", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("DefaultTopic", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("FullTextSearch", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Template", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			
			// Add Placeholder Row
			HHBProject proj = new HHBProject();
			DataRow dr = dt.NewRow();
			dr["ProjectName"] = proj.title;
			dr["Author"] = proj.author;
			dr["Company"] = proj.company;
			dr["Copyright"] = proj.copyright;
			dr["Language"] = proj.language;
			dr["DefaultTopic"] = proj.defaultTopic;
			dr["FullTextSearch"] = proj.useFullTextSearch.ToString();
			dr["Template"] = proj.template;
			dt.Rows.Add(dr);
			
			// Add Settings Table to DataSet
			ds.Tables.Add(dt);
			
			// Prepare Screens DataTable
			dt = new DataTable();
			dt.TableName = "Screens";
			dc = new DataColumn("ID", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("IndexPath", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("ScreenType", Type.GetType("System.String"));		// TOC or Popup
			dt.Columns.Add(dc);
			dc = new DataColumn("FileName", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("HasScreen", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("UseTitle", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("UseHeader", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("UseFooter", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Title", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("IndexEntries", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("LinkID", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("LinkDesc", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("LinkList", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("CssList", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("ScriptList", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Body", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			
			
			// Add Screens Table to DataSet
			ds.Tables.Add(dt);
			
			// Prepare PopupText DataTable
			dt = new DataTable();
			dt.TableName = "PopupText";
			dc = new DataColumn("ID", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Title", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("LinkID", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("HelpText", Type.GetType("System.String"));
			dt.Columns.Add(dc);

			// Add CSS Table to DataSet
			ds.Tables.Add(dt);
			
			// Prepare CSS DataTable
			dt = new DataTable();
			dt.TableName = "CSS";
			dc = new DataColumn("ID", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Title", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("FileName", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("FileContents", Type.GetType("System.String"));
			dt.Columns.Add(dc);

			// Add CSS Table to DataSet
			ds.Tables.Add(dt);
			
			// Prepare Scripts DataTable
			dt = new DataTable();
			dt.TableName = "Scripts";
			dc = new DataColumn("ID", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Title", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("FileName", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("FileContents", Type.GetType("System.String"));
			dt.Columns.Add(dc);

			// Add Scripts Table to DataSet
			ds.Tables.Add(dt);
			
			// Prepare Images DataTable
			dt = new DataTable();
			dt.TableName = "Images";
			dc = new DataColumn("ID", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Title", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("FileName", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("FileContents", Type.GetType("System.String"));
			dt.Columns.Add(dc);

			// Add CSS Table to DataSet
			ds.Tables.Add(dt);
			
			Log.Debug("Project dataset initialized.");
			
			return ds;
		}
		
		// ==============================================================================
		/// <summary>
		/// Convert a project dataset to a project tree.
		/// </summary>
		/// <param name="ds">The project dataset to process.</param>
		/// <returns>The root node of the project tree.</returns>
		private static TreeNode DatasetToTreenode(DataSet ds)
		{
			string s1;		// Temporary string variable
			TreeNode topNode = InitializeTreeNode();
			
			// General Project Information
			HHBProject tHP = new HHBProject();
			DataRow dr = ds.Tables[0].Rows[0];
			s1 = dr["ProjectName"].ToString().Trim();
			if ( !String.IsNullOrWhiteSpace(s1) )
			{
				tHP.title = s1;
			}
			tHP.author = dr["Author"].ToString().Trim();
			tHP.company = dr["Company"].ToString().Trim();
			tHP.copyright = dr["Copyright"].ToString().Trim();
			tHP.template = dr["Template"].ToString().Trim();
			tHP.language = dr["Language"].ToString().Trim();
			tHP.defaultTopic = dr["DefaultTopic"].ToString().Trim();
			tHP.useFullTextSearch = String.Equals(dr["FullTextSearch"].ToString().Trim().ToLower(), "true");
			topNode.Tag = tHP;
			topNode.Text = tHP.title;
			
			// Clear all project data nodes
			topNode.Nodes[(int) branches.tocEntry].Nodes.Clear();	// Table of Contents Items
			topNode.Nodes[(int) branches.htmlPopup].Nodes.Clear();	// HTML Popup Help Screen Items
			topNode.Nodes[(int) branches.textPopup].Nodes.Clear();	// Text Popup Help Screen Items
			topNode.Nodes[(int) branches.cssFile].Nodes.Clear();	// CSS Files (not included in the template)
			topNode.Nodes[(int) branches.scriptFile].Nodes.Clear();	// Script Files (not included in the template)
			topNode.Nodes[(int) branches.imageFile].Nodes.Clear();	// IMage Files (not included in the template)
			
			// Sort help screen heierarchy
			DataView dv = ds.Tables[1].DefaultView;
			dv.Sort = "IndexPath";
			DataTable sortedDT = dv.ToTable();
			
			// Help Screens (Table of Contents and HTML Popups)
			foreach (DataRow tDR in sortedDT.Rows)
			{
				// Replace all missing values with empty string
				foreach (DataColumn tDC in sortedDT.Columns)
				{
					object value = tDR[tDC.ColumnName];
					if (value == DBNull.Value)
					{
						tDR[tDC.ColumnName] = "";
					}
				}
				HelpItem tHI = new HelpItem();
				tHI.id = (string) tDR["ID"];
				if ( ((string) tDR["ScreenType"]).ToLower().Equals("toc") )
				{
					tHI.screenType = HelpItem.ScreenType.TOC;
				}
				else
				{
					tHI.screenType = HelpItem.ScreenType.Popup;
				}
				tHI.hasScreen = String.Equals(tDR["HasScreen"].ToString().Trim().ToLower(), "true");
				tHI.usesTitle = String.Equals(tDR["UseTitle"].ToString().Trim().ToLower(), "true");
				tHI.usesHeader = String.Equals(tDR["UseHeader"].ToString().Trim().ToLower(), "true");
				tHI.usesFooter = String.Equals(tDR["UseFooter"].ToString().Trim().ToLower(), "true");
				tHI.title = (string) tDR["Title"];
				tHI.indexEntries = (string) tDR["IndexEntries"];
				tHI.linkID = System.Convert.ToInt32("0" + tDR["LinkID"].ToString().Trim());
				tHI.linkDescription = (string) tDR["LinkDesc"];
				tHI.linkList = (string) tDR["LinkList"];
				tHI.cssList = (string) tDR["CssList"];
				tHI.scriptList = (string) tDR["ScriptList"];
				tHI.body = (string) tDR["Body"];
				TreeNode tTN = new TreeNode();
				tTN = topNode;
				string[] tArray = tDR["IndexPath"].ToString().Split('.');
				for (int i = 1; i < tArray.Length - 1; i++)
				{
					int j = Convert.ToInt32(tArray[i]);
					tTN = tTN.Nodes[j];
				}
				tTN = tTN.Nodes.Add(tHI.title);
				tTN.Tag = tHI;
				tTN.Text = tHI.title;
				tTN.Name = tHI.id;
			}
			
			// Popup Text Screens
			foreach (DataRow tdr in ds.Tables[2].Rows)
			{
				PopupTextItem tItem = new PopupTextItem();
				tItem.id = tdr["ID"].ToString().Trim();
				tItem.title = tdr["Title"].ToString().Trim();
				tItem.linkID = System.Convert.ToUInt32("0" + tdr["LinkID"].ToString().Trim());
				tItem.helpText = tdr["HelpText"].ToString().Trim();
				TreeNode tTN = topNode.Nodes[(int) HelpNode.branches.textPopup].Nodes.Add(tItem.title);
				tTN.Tag = tItem;
			}
			
			// CSS Files
			foreach (DataRow tdr in ds.Tables[3].Rows)
			{
				CSSItem tItem = new CSSItem();
				tItem.id = tdr["ID"].ToString().Trim();
				tItem.title = tdr["Title"].ToString().Trim();
				tItem.content = tdr["FileContents"].ToString().Trim();
				TreeNode tTN = topNode.Nodes[(int) HelpNode.branches.cssFile].Nodes.Add(tItem.title);
				tTN.Tag = tItem;
			}
			
			// Script Files
			foreach (DataRow tdr in ds.Tables[4].Rows)
			{
				ScriptItem tItem = new ScriptItem();
				tItem.id = tdr["ID"].ToString().Trim();
				tItem.title = tdr["Title"].ToString().Trim();
				tItem.fileName = tdr["FileName"].ToString().Trim();
				tItem.content = tdr["FileContents"].ToString().Trim();
				TreeNode tTN = topNode.Nodes[(int) HelpNode.branches.scriptFile].Nodes.Add(tItem.title);
				tTN.Tag = tItem;
			}
			
			// Image Files
			foreach (DataRow tdr in ds.Tables[5].Rows)
			{
				ImageItem tItem = new ImageItem();
				tItem.id = tdr["ID"].ToString().Trim();
				tItem.title = tdr["Title"].ToString().Trim();
				tItem.extension = Path.GetExtension(tdr["FileName"].ToString().Trim());
				tItem.content = tdr["FileContents"].ToString().Trim();
				TreeNode tTN = topNode.Nodes[(int) HelpNode.branches.imageFile].Nodes.Add(tItem.title);
				tTN.Tag = tItem;
			}
			
			Log.Debug("Dataset converted to project tree.");

			return topNode;
			
		}
		
		// ==============================================================================
		/// <summary>
		/// Recurses the project tree to a dataset of links.  Used by the ScreenLinks method.
		/// </summary>
		/// <param name="dsLinks">Dataset to update.  Passed by reference.</param>
		/// <param name="tNode">Node to process.</param>
		private static void RecurseTreeToLinkList(ref DataSet dsLinks, TreeNode tNode)
		{
			int nIdx = HelpNode.GetBranchIndex(tNode);
			if ((tNode.Level > 1) && ((nIdx == (int) branches.tocEntry) || (nIdx == (int) branches.htmlPopup)))
			{
				HelpItem tnItem = (HelpItem) tNode.Tag;
				DataRow dr = dsLinks.Tables[0].NewRow();
				dr["ID"] = tnItem.id;
				dr["Title"] = tnItem.title;
				dr["Checked"] = false;
				if (nIdx == (int) branches.tocEntry)
				{
					dr["Index"] = HelpNode.NodeTocIndex(tNode);
				}
				else
				{
					dr["Index"] = "Popup";
				}
				dr["FileName"] = tnItem.fileName;
				dr["LinkText"] = tnItem.linkDescription;
				dsLinks.Tables[0].Rows.Add(dr);
			}
			
			foreach (TreeNode cNode in tNode.Nodes)
			{
				RecurseTreeToLinkList(ref dsLinks, cNode);
			}
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		#endregion
		
		#region Public Properties
		/// <summary>
		/// Types of branches in the HTML Help project tree
		/// </summary>
		public enum branches
		{
			/// <summary>
			/// Table of Contents entry
			/// </summary>
			tocEntry = 0,
			
			/// <summary>
			/// HTML Popup Screen entry
			/// </summary>
			htmlPopup = 1,
			
			/// <summary>
			/// Text Popup Screen entry
			/// </summary>
			textPopup = 2,
			
			/// <summary>
			/// Cascading Style Sheet File entry
			/// </summary>
			cssFile = 3,
			
			/// <summary>
			/// Script File entry
			/// </summary>
			scriptFile = 4,
			
			/// <summary>
			/// Image File entry
			/// </summary>
			imageFile = 5
		}
		#endregion
		
		#region Public Methods
		// ==============================================================================
		/// <summary>
		/// Gets the index of the specified level ancestor of a node.
		/// </summary>
		/// <param name="NodeToCheck">Node to process.</param>
		/// <param name="AncestorLevel">Level of the ancestor to check.</param>
		/// <returns>The index of the specified ancestor on success, otherwise -1.</returns>
		public static int GetAncestorIndex(TreeNode NodeToCheck, int AncestorLevel)
		{
			if ((NodeToCheck == null) || (NodeToCheck.Level <= AncestorLevel) || (AncestorLevel < 0))
			{
				return -1;
			}
			TreeNode tempNode = NodeToCheck;
			while (tempNode.Level > AncestorLevel)
			{
				tempNode = tempNode.Parent;
			}
			return tempNode.Index;
		}
		
		// ==============================================================================
		/// <summary>
		/// Gets the root (level 0) ancestor of the specified node.
		/// </summary>
		/// <param name="node">Node to process.</param>
		/// <returns>The level 0 ancestor node.</returns>
		public static System.Windows.Forms.TreeNode GetRootNode(System.Windows.Forms.TreeNode node)
		{
			System.Windows.Forms.TreeNode tNode = node;
			while (tNode.Level > 0) {
				tNode = tNode.Parent;
			}
			return tNode;
		}
		
		// ==============================================================================
		/// <summary>
		/// Provides a list of the nodes starting at the specified node. 
		/// </summary>
		/// <param name="RootNode">The root node to begin processing.</param>
		/// <param name="offset">The number of spaces to indent each level.</param>
		/// <returns>A string of the list of nodes starting with the specified root node.</returns>
		public static string NodeList(System.Windows.Forms.TreeNode RootNode, int offset)
		{
			return RecurseNodeList(String.Empty, RootNode, offset);
		}
		
		// ==============================================================================
		/// <summary>
		/// Provides a count of the nodes starting at the specified node. 
		/// </summary>
		/// <param name="RootNode">The root node to begin processing.</param>
		/// <returns>A count of the number of nodes starting with the specified root node.</returns>
		public static int NodeCount(System.Windows.Forms.TreeNode RootNode)
		{
			return RecurseCount(0, RootNode);
		}
		
		// ==============================================================================
		/// <summary>
		/// Initializes the dataset and treeview nodes
		/// </summary>
		/// <returns>The root node for the project treeview.</returns>
		public static TreeNode Initialize()
		{
			InitializeDataset();
			return InitializeTreeNode();
		}
		
		// ==============================================================================
		/// <summary>
		/// Get's the branch index of the specified node.
		/// </summary>
		/// <param name="NodeToCheck">The node to process.</param>
		/// <returns>The project tree branch of the specified node on success, otherwise -1.</returns>
		public static int GetBranchIndex(TreeNode NodeToCheck)
		{
			if ((NodeToCheck == null) || (NodeToCheck.Level < 1))
			{
				return -1;
			}
			TreeNode tempNode = NodeToCheck;
			while (tempNode.Level > 1)
			{
				tempNode = tempNode.Parent;
			}
			return tempNode.Index;
		}
		
		// ==============================================================================
		/// <summary>
		/// Determine whether one node is a parent or ancestor of a second node.
		/// </summary>
		/// <param name="node1">Node to check.</param>
		/// <param name="node2">Ancestor branch node to check.</param>
		/// <returns>True if the first node is a decendent of the second node's root node, otherwise false.</returns>
		public static bool ContainsNode(TreeNode node1, TreeNode node2)
		{
			// Check the parent node of the second node.
			if (node2.Parent == null)
			{
				return false;
			}
			if (node2.Parent.Equals(node1))
			{
				return true;
			}

			// If the parent node is not null or equal to the first node,
			// call the ContainsNode method recursively using the parent of
			// the second node.
			return ContainsNode(node1, node2.Parent);
		}

		// ==============================================================================
		/// <summary>
		/// The location of the specified item in the Table of Contents.
		/// </summary>
		/// <param name="NodeToCheck">The node to process.</param>
		/// <returns>A string with the Table of Contents index number, or an empty string if the node is not in the Table of Contents branch.</returns>
		public static string NodeTocIndex(TreeNode NodeToCheck)
		{
			if ((NodeToCheck == null) || (NodeToCheck.Level < 1) || (GetBranchIndex(NodeToCheck) != (int) branches.tocEntry))
			{
				return String.Empty;
			}
			string s1 = String.Empty;
			string s2 = String.Empty;
			TreeNode tempNode = NodeToCheck;
			while (tempNode.Level > 1) {
				s1 = String.Concat(String.Format("{0:00}", tempNode.Index + 1), s2, s1);
				s2 = ".";
				tempNode = tempNode.Parent;
			}
			return s1;
		}
		
		// ==============================================================================
		/// <summary>
		/// The index number and path of the specified node.
		/// </summary>
		/// <param name="NodeToCheck">The node to process.</param>
		/// <returns>A string with the zero-based index number and path of the specified node.</returns>
		public static string NodeIndexPath(TreeNode NodeToCheck)
		{
			return NodeIndexPath(NodeToCheck, false);
		}
		
		// ==============================================================================
		/// <summary>
		/// The index number and path of the specified node.
		/// </summary>
		/// <param name="NodeToCheck">The node to process.</param>
		/// <param name="startIndexNumberAtOne">True to start the index numbering at 1, or false to start numbering at 0.</param>
		/// <returns>A string with the index number and path of the specified node.</returns>
		public static string NodeIndexPath(TreeNode NodeToCheck, bool startIndexNumberAtOne)
		{
			if (NodeToCheck == null) 
			{
				return "";
			}
			int indexBase = 0;
			if ( startIndexNumberAtOne )
			{
				indexBase = 1;
			}
			string s1 = "";
			string s2 = "";
			string t1 = "";
			string t2 = "";
			TreeNode tempNode = NodeToCheck;
			while (tempNode.Level > 0) {
				s1 = String.Concat(String.Format("{0:00}", tempNode.Index + indexBase), s2, s1);
				s2 = ".";
				t1 = String.Concat(tempNode.Text, t2, t1);
				t2 = @"\";
				tempNode = tempNode.Parent;
			}
			s1 = String.Concat((tempNode.Index + indexBase).ToString().Trim(), s2, s1, "  ", tempNode.Text, t2 , t1);
			return s1;
		}
		
		// ==============================================================================
		/// <summary>
		/// Loads a help project file.
		/// </summary>
		/// <param name="projectFileName">Full path and name of the HTML Help Builder project file.</param>
		/// <returns>The root node of the help project tree.</returns>
		/// <exception cref="Exception">Project file name not specified.</exception>
		/// <exception cref="Exception">Project file not found.</exception>
		/// <exception cref="Exception">Error processing project file.</exception>
		public static TreeNode Load(string projectFileName)
		{
			if ( String.IsNullOrWhiteSpace(projectFileName) )
			{
				throw new Exception("Project file name not specified.");
			}

			if ( !File.Exists(projectFileName) )
			{
				throw new Exception("Project file not found: " + projectFileName);
			}
			
			DataSet ds = InitializeDataset();
			ds.Clear();
			try
			{
				ds.ReadXml(projectFileName);
			}
			catch (Exception ex)
			{
				string error = "Error reading project file: " + projectFileName;
				Log.Error(error);
				Log.Exception(ex);
				throw new Exception(error);
			}

			TreeNode tNode = InitializeTreeNode();
			try
			{
				tNode = DatasetToTreenode(ds);
				HHBProject proj = (HHBProject) tNode.Tag;
				proj.filename = projectFileName;
				tNode.Tag = proj;
			}
			catch (Exception ex)
			{
				string error = "Error processing project file: " + projectFileName;
				Log.Error(error);
				Log.Exception(ex);
				throw new Exception(error);
			}
			
			return tNode;
		}
		
		// ==============================================================================
		/// <summary>
		/// Save the HTML Help Builder project to a file.
		/// <para>If the file name is not specified, it will be extracted from the project settings in the root node's tag property.</para>
		/// </summary>
		/// <param name="node">Node in the help project tree.</param>
		/// <exception cref="Exception">Project file name not specified.</exception>
		/// <exception cref="Exception">Unable to save the project file.</exception>
		public static void Save(TreeNode node)
		{
			TreeNode topNode = GetRootNode(node);
			string fileName = ((HHBProject) topNode.Tag).filename;
			Save(topNode, fileName);
		}

		// ==============================================================================
		/// <summary>
		/// Save the HTML Help Builder project to a file.
		/// </summary>
		/// <param name="node">Node in the help project tree.</param>
		/// <param name="projectFileName">Full path and name of file to save.</param>
		/// <exception cref="Exception">Project file name not specified.</exception>
		/// <exception cref="Exception">Unable to save the project file.</exception>
		public static void Save(TreeNode node, string projectFileName)
		{
			TreeNode topNode = GetRootNode(node);
			if ( String.IsNullOrWhiteSpace(projectFileName) )
			{
				throw new Exception("Project file name not specified.");
			}
			
			DataSet ds = TreeToDataset(topNode);
			
			try
			{
				ds.WriteXml(projectFileName);
			}
			catch (Exception ex)
			{
				string error = "Unable to save the project file: " + projectFileName;
				Log.Error(error);
				Log.Exception(ex);
				throw new Exception(error);
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// List of the HTML screens for the selected project.
		/// </summary>
		/// <param name="node">A node in the project to use for locating the topics.</param>
		/// <returns>A dataset of all topics with an associated HTML screen.</returns>
		public static DataSet ScreenLinks(TreeNode node)
		{
			DataSet ds = new DataSet();
			ds.DataSetName = "HelpLinks";
			DataTable dt = new DataTable();
			dt.TableName = "Links";
			DataColumn dc = new DataColumn("ID", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Title", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Checked", Type.GetType("System.Boolean"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Index", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("FileName", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("LinkText", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
			ds.Tables.Add(dt);
			
			TreeNode tNode = new TreeNode();
			tNode = GetRootNode(node);
			RecurseTreeToLinkList(ref ds, tNode);
			
			return ds;
		}
		// ==============================================================================
		#endregion
	}
}
