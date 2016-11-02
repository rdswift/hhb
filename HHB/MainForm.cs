/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-06-23
 * Time: 10:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace HHBuilder
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	
	public partial class MainForm : Form
	{
		DataSet ds = new DataSet();
		DataSet dsLinks = new DataSet();
		DataSet dsIndexEntries = new DataSet();
		HelpItem savedHelpItem = null;
		TreeNode savedNode = null;
		string helpProjectFilePathAndName = "";
//		public static ResourceManager rmText = new ResourceManager("HHBuilder.LanguageText", Assembly.GetExecutingAssembly());
		
//		public HBSettings cfgSettings = new HBSettings();
		public const int _MaxLevels = 7;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			AssemblyName tempAssembly = Assembly.GetExecutingAssembly().GetName();
			this.Text = String.Format("{0} v{1}.{2:00}", tempAssembly.Name, tempAssembly.Version.Major, tempAssembly.Version.Minor);
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void MainFormLoad(object sender, EventArgs e)
		{
			string errorMessage = "";
			if ( !HBSettings.Initialize() )
			{
//				errorMessage = "Unable to locate or create a configuration file.  Please check that you have write access and that the drive is not full.\n";
//				errorMessage = rmText.GetString("errorMessage001");
				errorMessage = Language.GetString("errorMessage001");
			}
			if (( String.IsNullOrEmpty(errorMessage) ) && ( !HBSettings.Read() ))
			{
//				errorMessage = "Unable to read the configuration file.  Please check that you have read access to:\n\n" + HBSettings.cfgFileName;
//				errorMessage = string.Format(rmText.GetString("errorMessage002"), HBSettings.cfgFileName);
				errorMessage = string.Format(Language.GetString("errorMessage002"), HBSettings.cfgFileName);
			}
			if ( !String.IsNullOrEmpty(errorMessage) )
			{
				// TODO Add logging
				Log.ErrorBox(errorMessage);
				Close();
				Application.Exit();
			}
			
			//HBSettings.ShowAll();			// Testing only
			
			Log.logFile = HBSettings.logFileName;
			if (HBSettings.logLevel == HBSettings.LogLevel.Debug)
			{
				Log.Debug("Program started.");
			}
			cbLanguage.DataSource = Language.GetList();
			cbLanguage.DisplayMember = "Title";

			ResetForm();
			
			
//			System.Collections.Generic.IList<HHBTemplate> templateList = HHBTemplate.AvailableTemplates(@"Templates");
//			System.Text.StringBuilder tempText = new System.Text.StringBuilder();
//			tempText.AppendFormat("Found {0} templates.\n\n", templateList.Count);
//			foreach (HHBTemplate tpl in templateList) {
//				tempText.AppendFormat("ID: {0}\nTitle: {1}\nPath: {2}\nDesc: {3}\n\n", tpl.id, tpl.title, tpl.fileName, tpl.description);
//			}
//			MessageBox.Show(tempText.ToString(), "Templates");
			
			
		}

		// ---------------------------------------------------------------------------------------------
		/// <summary>
		/// Reset the form
		/// </summary>
		public void ResetForm()
		{
			InitDataSet();
			string defaultLanguage = HBSettings.language;
			cbLanguage.SelectedIndex = -1;
			if ( !String.IsNullOrEmpty(defaultLanguage) )
			{
				cbLanguage.SelectedIndex = cbLanguage.FindString(defaultLanguage.Substring(7).Trim());
			}
			if (HBSettings.logLevel == HBSettings.LogLevel.Debug)
			{
				Log.Debug("Project form reset.");
			}
			ShowDataSet();
		}
		
		
		// ---------------------------------------------------------------------------------------------
		/// <summary>
		/// Initialize the dataset
		/// </summary>
		public void InitDataSet()
		{
			ds = new DataSet();
			ds.DataSetName = "HelpData";
			
			// Prepare Settings DataTable
			DataTable dt = new DataTable();
			dt.TableName = "Settings";
			
			DataColumn dc;
			
			dc = new DataColumn("ProjectName", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("FileName", Type.GetType("System.String"));
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
			DataRow dr = dt.NewRow();
			dr["ProjectName"] = "Undefined Project";
			dr["FileName"] = "Undefined";
			dr["Author"] = HBSettings.author;
			dr["Company"] = HBSettings.company;
			dr["Copyright"] = HBSettings.Copyright();
			dr["Language"] = HBSettings.language;
			dr["DefaultTopic"] = "";
			dr["FullTextSearch"] = "Yes";
			dr["Template"] = "Default";
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
			dc = new DataColumn("Body", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			
			
			// Add Screens Table to DataSet
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
			
			
			// Initialize Links DataSet
			dsLinks = new DataSet();
			dsLinks.DataSetName = "HelpLinks";
			dt = new DataTable();
			dt.TableName = "Links";
			dc = new DataColumn("ID", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Title", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Checked", Type.GetType("System.Boolean"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Index", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
			dsLinks.Tables.Add(dt);
			
			// Create table for index entries on help screens
			dsIndexEntries = new DataSet();
			dsIndexEntries.DataSetName = "IndexEntries";
			dt = new DataTable();
			dt.TableName = "IndexLines";
			dc = new DataColumn("IndexLine", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dsIndexEntries.Tables.Add(dt);
			
		}
		
		// ---------------------------------------------------------------------------------------------
		/// <summary>
		/// Set up the available right-click options for the current treenode
		/// </summary>
		private void FilterContextMenuStrip1(int nIdx)
		{
			insertToolStripMenuItem.Enabled = false;
			moveLeftToolStripMenuItem.Enabled = false;
			moveRightToolStripMenuItem.Enabled = false;
			moveUpToolStripMenuItem.Enabled = false;
			moveDownToolStripMenuItem.Enabled = false;
			deleteToolStripMenuItem.Enabled = false;
			addChildToolStripMenuItem.Enabled = false;
			copyNodeToolStripMenuItem.Enabled = false;
			cutNodeToolStripMenuItem.Enabled = false;
			pasteNodeAboveToolStripMenuItem.Enabled = false;
			pasteNodeBelowToolStripMenuItem.Enabled = false;
			pasteAsChildNodeToolStripMenuItem.Enabled = false;
			
			TreeNode tempNode = treeView1.SelectedNode;
			if (tempNode.Level > 0)
			{
				addChildToolStripMenuItem.Enabled = true;
				if ((savedHelpItem != null) || (savedNode != null))
				{
					pasteAsChildNodeToolStripMenuItem.Enabled = true;
				}
			}
			
			if ((tempNode.Level > _MaxLevels) || ((tempNode.Level > 1) && (nIdx > 0)))
			{
				addChildToolStripMenuItem.Enabled = false;
				pasteAsChildNodeToolStripMenuItem.Enabled = false;
			}
			
			if (tempNode.Level > 1)
			{
				deleteToolStripMenuItem.Enabled = true;
				insertToolStripMenuItem.Enabled = true;
//			if (tempNode.GetNodeCount(true) < 1) { cutNodeToolStripMenuItem.Enabled = true; }
				cutNodeToolStripMenuItem.Enabled = true;
				copyNodeToolStripMenuItem.Enabled = true;
				if ((savedHelpItem != null) || (savedNode != null))
				{
					pasteNodeAboveToolStripMenuItem.Enabled = true;
					pasteNodeBelowToolStripMenuItem.Enabled = true;
				}
				if (tempNode.PrevNode != null)
				{
					moveUpToolStripMenuItem.Enabled = true;
				}
				if (tempNode.NextNode != null)
				{
					moveDownToolStripMenuItem.Enabled = true;
				}
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void TreeToDataset()
		{
			// Help Screens Table
			ds.Tables[1].Rows.Clear();
			foreach (TreeNode tNode in treeView1.Nodes)
			{
				RecurseTreeToDataset(tNode);
			}
			
			// CSS Files Table
			ds.Tables[2].Rows.Clear();
			foreach (TreeNode tNode in treeView1.Nodes[0].Nodes[2].Nodes)
			{
				CSSItem tItem = (CSSItem) tNode.Tag;
				DataRow dr = ds.Tables[2].NewRow();
				dr["ID"] = tItem.id;
				dr["Title"] = tItem.title;
				dr["FileName"] = tItem.fileName;
				dr["FileContents"] = tItem.content;
				ds.Tables[2].Rows.Add(dr);
			}
			
			// Script Files Table
			ds.Tables[3].Rows.Clear();
			foreach (TreeNode tNode in treeView1.Nodes[0].Nodes[3].Nodes)
			{
				ScriptItem tItem = (ScriptItem) tNode.Tag;
				DataRow dr = ds.Tables[3].NewRow();
				dr["ID"] = tItem.id;
				dr["Title"] = tItem.title;
				dr["FileName"] = tItem.fileName;
				dr["FileContents"] = tItem.content;
				ds.Tables[3].Rows.Add(dr);
			}
			
			// Image Files Table
			ds.Tables[4].Rows.Clear();
			foreach (TreeNode tNode in treeView1.Nodes[0].Nodes[4].Nodes)
			{
				ImageItem tItem = (ImageItem) tNode.Tag;
				DataRow dr = ds.Tables[4].NewRow();
				dr["ID"] = tItem.id;
				dr["Title"] = tItem.title;
				dr["FileName"] = tItem.fileName;
				dr["FileContents"] = tItem.content;
				ds.Tables[4].Rows.Add(dr);
			}
			
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void RecurseTreeToDataset(TreeNode tNode)
		{
			int nIdx = GetBranchIndex(tNode);
			if ((tNode.Level > 1) && (nIdx < 2))
			{
				HelpItem tnItem = (HelpItem) tNode.Tag;
				DataRow dr = ds.Tables[1].NewRow();
				dr["ID"] = tnItem.id;
				dr["IndexPath"] = NodeIndexPath(tNode).Split(' ')[0];
				//dr["ScreenType"] = tnItem.screenType.ToString();
				dr["ScreenType"] = ( (nIdx < 1) ? "TOC" : "Popup" );
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
				dr["Body"] = tnItem.body;
				ds.Tables[1].Rows.Add(dr);
			}
			foreach (TreeNode cNode in tNode.Nodes)
			{
				RecurseTreeToDataset(cNode);
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		public void ShowDataSet()
		{
			string s1;		// Temporary string variable
			
			// General Project Information
			DataRow dr = ds.Tables[0].Rows[0];
			s1 = dr["ProjectName"].ToString().Trim();
			if (s1.Length < 1)
			{
				s1 = "Undefined Project";
				dr["ProjectName"] = s1;
			}
			treeView1.SelectedNode = treeView1.Nodes[0];
			treeView1.Nodes[0].Text = s1;
			
			tbProjectName.Text = s1;
			tbRootFileName.Text = dr["FileName"].ToString().Trim();
			tbAuthor.Text = dr["Author"].ToString().Trim();
			tbCompany.Text = dr["Company"].ToString().Trim();
			tbCopyright.Text = dr["Copyright"].ToString().Trim();
			tbTemplateUsed.Text = dr["Template"].ToString().Trim();
			tbLanguage.Text = dr["Language"].ToString().Trim();
			tbDefaultTopic.Text = dr["DefaultTopic"].ToString().Trim();
			cbFullTextSearch.Checked = dr["FullTextSearch"].ToString().Trim().ToUpper().StartsWith("Y");
			
			// Clear all project data nodes
			treeView1.Nodes[0].Nodes[0].Nodes.Clear();	// Table of Contents Items
			treeView1.Nodes[0].Nodes[1].Nodes.Clear();	// Popup Help Screen Items
			treeView1.Nodes[0].Nodes[2].Nodes.Clear();	// CSS Files (not included in the template)
			treeView1.Nodes[0].Nodes[3].Nodes.Clear();	// Script Files (not included in the template)
			treeView1.Nodes[0].Nodes[4].Nodes.Clear();	// IMage Files (not included in the template)
			
			// Sort help screen heierarchy
			DataView dv = ds.Tables[1].DefaultView;
			dv.Sort = "IndexPath";
			DataTable sortedDT = dv.ToTable();
			
			// Help Screens (Table of Contents and Popups)
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
				if ( ((string) tDR["FileName"]).ToLower().Equals("toc") )
				{
					tHI.screenType = HelpItem.ScreenType.TOC;
				}
				else
				{
					tHI.screenType = HelpItem.ScreenType.Popup;
				}
				tHI.fileName = (string) tDR["FileName"];
				tHI.hasScreen = String.Equals(tDR["HasScreen"].ToString().Trim().ToLower(), "true");
				tHI.usesTitle = String.Equals(tDR["UseTitle"].ToString().Trim().ToLower(), "true");
				tHI.usesHeader = String.Equals(tDR["UseHeader"].ToString().Trim().ToLower(), "true");
				tHI.usesFooter = String.Equals(tDR["UseFooter"].ToString().Trim().ToLower(), "true");
				tHI.title = (string) tDR["Title"];
				tHI.indexEntries = (string) tDR["IndexEntries"];
				tHI.linkID = System.Convert.ToUInt32("0" + tDR["LinkID"].ToString().Trim());
				tHI.linkDescription = (string) tDR["LinkDesc"];
				tHI.linkList = (string) tDR["LinkList"];
				tHI.body = (string) tDR["Body"];
				TreeNode tTN = new TreeNode();
				tTN = treeView1.Nodes[0];
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
				tTN.ContextMenuStrip = contextMenuStrip1;
			}
			
			// CSS Files
			foreach (DataRow tdr in ds.Tables[2].Rows)
			{
				CSSItem tItem = new CSSItem();
				tItem.id = tdr["ID"].ToString().Trim();
				tItem.title = tdr["Title"].ToString().Trim();
				tItem.fileName = tdr["FileName"].ToString().Trim();
				tItem.content = tdr["FileContents"].ToString().Trim();
				TreeNode tTN = treeView1.Nodes[0].Nodes[2].Nodes.Add(tItem.title);
				tTN.Tag = tItem;
				tTN.ContextMenuStrip = contextMenuStrip2;
			}
			
			// Script Files
			foreach (DataRow tdr in ds.Tables[3].Rows)
			{
				ScriptItem tItem = new ScriptItem();
				tItem.id = tdr["ID"].ToString().Trim();
				tItem.title = tdr["Title"].ToString().Trim();
				tItem.fileName = tdr["FileName"].ToString().Trim();
				tItem.content = tdr["FileContents"].ToString().Trim();
				TreeNode tTN = treeView1.Nodes[0].Nodes[3].Nodes.Add(tItem.title);
				tTN.Tag = tItem;
				tTN.ContextMenuStrip = contextMenuStrip2;
			}
			
			// Image Files
			foreach (DataRow tdr in ds.Tables[4].Rows)
			{
				ImageItem tItem = new ImageItem();
				tItem.id = tdr["ID"].ToString().Trim();
				tItem.title = tdr["Title"].ToString().Trim();
				tItem.fileName = tdr["FileName"].ToString().Trim();
				tItem.content = tdr["FileContents"].ToString().Trim();
				TreeNode tTN = treeView1.Nodes[0].Nodes[4].Nodes.Add(tItem.title);
				tTN.Tag = tItem;
				tTN.ContextMenuStrip = contextMenuStrip2;
			}

			treeView1.SelectedNode = treeView1.Nodes[0];
			treeView1.Refresh();
			treeView1.ExpandAll();
			tabPageProject.Focus();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		public int GetAncestorIndex(TreeNode NodeToCheck, int AncestorLevel)
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
		
		// ---------------------------------------------------------------------------------------------
		
		public int GetBranchIndex(TreeNode NodeToCheck)
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
		
		// ---------------------------------------------------------------------------------------------
		
		public string NodeIndexPath(TreeNode NodeToCheck)
		{
			if (NodeToCheck == null) 
			{
				return "";
			}
			string s1 = "";
			string s2 = "";
			string t1 = "";
			string t2 = "";
			TreeNode tempNode = NodeToCheck;
			while (tempNode.Level > 0) {
				s1 = String.Concat(String.Format("{0:00}", tempNode.Index), s2, s1);
				s2 = ".";
				t1 = String.Concat(tempNode.Text, t2, t1);
				t2 = @"\";
				tempNode = tempNode.Parent;
			}
			s1 = String.Concat(tempNode.Index.ToString().Trim(), s2, s1, "  ", tempNode.Text, t2 , t1);
			return s1;
		}
		
		// ---------------------------------------------------------------------------------------------

		void MakeLinkList()
		{
			dsLinks.Tables[0].Rows.Clear();
			TreeNode tNode = new TreeNode();
			tNode = treeView1.Nodes[0].Nodes[0];
			RecurseTreeToLinkList(tNode);
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void RecurseTreeToLinkList(TreeNode tNode)
		{
			//int nIdx = GetBranchIndex(tNode);
			if (tNode.Level > 1)
			{
				HelpItem tnItem = (HelpItem) tNode.Tag;
				DataRow dr = dsLinks.Tables[0].NewRow();
				dr["ID"] = tnItem.id;
				dr["Title"] = tnItem.title;
				dr["Checked"] = false;
				dr["Index"] = NodeIndexPath(tNode).Split(' ')[0];
				dsLinks.Tables[0].Rows.Add(dr);
			}
			
			foreach (TreeNode cNode in tNode.Nodes)
			{
				RecurseTreeToLinkList(cNode);
			}
		}
		
		
		// ---------------------------------------------------------------------------------------------
		
		void DisplayNodeInfo()
		{
			bool bTest = false;
			if (treeView1.SelectedNode != null)
			{
				toolStripStatusLabel1.Text = NodeIndexPath(treeView1.SelectedNode);
				if (treeView1.SelectedNode.Level > 1)
				{
					bTest = true;
				}
			}
			if (tabControl1.TabPages.Contains(tabPageScreen) == true)
			{
				tabControl1.TabPages.Remove(tabPageScreen);
			}
			if (tabControl1.TabPages.Contains(tabPagePreview) == true)
			{
				tabControl1.TabPages.Remove(tabPagePreview);
			}
			if (tabControl1.TabPages.Contains(tabPageCSS) == true)
			{
				tabControl1.TabPages.Remove(tabPageCSS);
			}
			if (tabControl1.TabPages.Contains(tabPageScripts) == true)
			{
				tabControl1.TabPages.Remove(tabPageScripts);
			}
			if (tabControl1.TabPages.Contains(tabPageImages) == true)
			{
				tabControl1.TabPages.Remove(tabPageImages);
			}
			if (bTest)
			{
				int nIdx = GetBranchIndex(treeView1.SelectedNode);
				switch (nIdx)
				{
					case 0:
					case 1:
						HelpItem tempItem = (HelpItem) treeView1.SelectedNode.Tag;
						treeView1.SelectedNode.Text = tempItem.title;
						hiTitle.Text = tempItem.title;
						hiFileName.Text = tempItem.fileName;
						hiID.Text = tempItem.id;
						hiLinkID.Text = tempItem.linkID.ToString();
						hiLinkDesc.Text = tempItem.linkDescription;
						hiBody.Text = tempItem.body;
						hiHasScreen.Checked = tempItem.hasScreen;
						hiIncludeTitle.Checked = tempItem.usesTitle;
						hiIncludeHeader.Checked = tempItem.usesHeader;
						hiIncludeFooter.Checked = tempItem.usesFooter;

						string[] sArray = tempItem.indexArray;
						dsIndexEntries.Tables[0].Rows.Clear();
						if (sArray.Length > 0)
						{
							foreach (string s2 in sArray) 
							{
								string s3 = s2.Trim();
								if (s3.Length > 0)
								{
									DataRow tRow = dsIndexEntries.Tables[0].NewRow();
									tRow[0] = s3;
									dsIndexEntries.Tables[0].Rows.Add(tRow);
								}
							}
						}
						dgvIndexEntries.DataSource = dsIndexEntries.Tables[0];
						
						MakeLinkList();
						
						lvLinks.Items.Clear();
						if (nIdx < 1)
						{
							foreach (DataRow dsRow in dsLinks.Tables[0].Rows)
							{
								if (dsRow["ID"].ToString() != tempItem.id)
								{
									ListViewItem lvI = new ListViewItem(dsRow["ID"].ToString());
									lvI.SubItems.Add(dsRow["Index"].ToString());
									lvI.SubItems.Add(dsRow["Title"].ToString());
									lvI.Checked = (bool) tempItem.linkList.Contains(lvI.Text);
									lvLinks.Items.Add(lvI);
								}
							}
						}
						lvLinks.Refresh();
						
						if (tabControl1.TabPages.Contains(tabPageScreen) == false)
						{
							tabControl1.TabPages.Add(tabPageScreen);
						}
						if (tabControl1.TabPages.Contains(tabPagePreview) == false)
						{
							tabControl1.TabPages.Add(tabPagePreview);
						}
						tabControl1.SelectedTab = tabPageScreen;
						break;
					case 2:
						CSSItem tempCSS = (CSSItem) treeView1.SelectedNode.Tag;
						treeView1.SelectedNode.Text = tempCSS.title;
						tbCssTitle.Text = tempCSS.title;
						tbCssFilename.Text = tempCSS.fileName;
						tbCssContents.Text = tempCSS.content;
						if (tabControl1.TabPages.Contains(tabPageCSS) == false)
						{
							tabControl1.TabPages.Add(tabPageCSS);
						}
						tabControl1.SelectedTab = tabPageCSS;
						break;
					case 3:
						ScriptItem tempScript = (ScriptItem) treeView1.SelectedNode.Tag;
						treeView1.SelectedNode.Text = tempScript.title;
						tbScriptTitle.Text = tempScript.title;
						tbScriptFilename.Text = tempScript.fileName;
						tbScriptContent.Text = tempScript.content;
						if (tabControl1.TabPages.Contains(tabPageScripts) == false)
						{
							tabControl1.TabPages.Add(tabPageScripts);
						}
						tabControl1.SelectedTab = tabPageScripts;
						break;
					case 4:
						ImageItem tempImage = (ImageItem) treeView1.SelectedNode.Tag;
						treeView1.SelectedNode.Text = tempImage.title;
						tbImageTitle.Text = tempImage.title;
						tbImageFilename.Text = tempImage.fileName;
						tbImageContent.Text = tempImage.content;
						tbImageID.Text = tempImage.id;
						DisplayImage();
						if (tabControl1.TabPages.Contains(tabPageImages) == false)
						{
							tabControl1.TabPages.Add(tabPageImages);
						}
						tabControl1.SelectedTab = tabPageImages;
						break;
					default:
						tabControl1.SelectedTab = tabPageProject;
						break;
				}
			}
			tabControl1.Refresh();
			treeView1.SelectedNode.ExpandAll();
			treeView1.Focus();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void TreeView1AfterSelect(object sender, TreeViewEventArgs e)
		{
			int nIdx = GetBranchIndex(treeView1.SelectedNode);
			if (nIdx < 2)
			{
				FilterContextMenuStrip1(nIdx);
			}
			DisplayNodeInfo();
		}

		// ---------------------------------------------------------------------------------------------

		private void InsertNode()
		{
			bool bTest = false;
			if (treeView1.SelectedNode != null)
			{
				if (treeView1.SelectedNode.Level > 1)
				{
					bTest = true;
				}
			}
			if (bTest)
			{
				TreeNode tempNode;
				tempNode = treeView1.SelectedNode.Parent.Nodes.Insert(treeView1.SelectedNode.Index + 1, "New Item");
				HelpItem tempItem = new HelpItem();
				tempNode.Tag = tempItem;
				tempNode.Text = tempItem.title;
				tempNode.Name = tempItem.id;
				tempNode.ContextMenuStrip = contextMenuStrip1;
				treeView1.SelectedNode = tempNode;
			}
			DisplayNodeInfo();
		}

		// ---------------------------------------------------------------------------------------------

		private void AddChildNode()
		{
			bool bTest = false;
			if (treeView1.SelectedNode != null) {
				if (treeView1.SelectedNode.Level > 0) { bTest = true; }
			}
			if (bTest) {
				TreeNode tempNode;
				tempNode = treeView1.SelectedNode.Nodes.Add("New Item");
				HelpItem tempItem = new HelpItem();
				tempNode.Tag = tempItem;
				tempNode.Text = tempItem.title;
				tempNode.Name = tempItem.id;
				tempNode.ContextMenuStrip = contextMenuStrip1;
				treeView1.SelectedNode = tempNode;
			}
			DisplayNodeInfo();
		}
		
		
//		private void DeleteNode()
//		{
//			if (treeView1.SelectedNode.Level > 1) { treeView1.SelectedNode.Remove(); }
//			DisplayNodeInfo();
//		}

//
//	Private Sub DeleteNode()
//		If Not Me.treeView1.SelectedNode Is Nothing AndAlso Me.treeView1.SelectedNode.Level > 0 Then
//			Me.treeView1.SelectedNode.Remove()
//		End If
//		'Me.treeView1.Focus
//		DisplayNodeInfo()
//	End Sub
//
//	' --------------------------------------------------------------------------------------
//
//	Private Sub MoveNodeUp()
//		If Not Me.treeView1.SelectedNode Is Nothing AndAlso Me.treeView1.SelectedNode.Level > 0 _
//			AndAlso Me.treeView1.SelectedNode.Index > 0 Then
//			Dim CurrentIndex As Integer = Me.treeView1.SelectedNode.Index
//			Dim CurrentNode As TreeNode = Me.treeView1.SelectedNode
//			Dim ParentNode As TreeNode = Me.treeView1.SelectedNode.Parent
//			Me.treeView1.SelectedNode.Remove()
//			ParentNode.Nodes.Insert(CurrentIndex - 1, CurrentNode)
//			Me.treeView1.SelectedNode = CurrentNode
//		End If
//		'Me.treeView1.Focus
//		DisplayNodeInfo()
//	End Sub
//
//	' --------------------------------------------------------------------------------------
//
//	Private Sub MoveNodeRight()
//
//	End Sub
//
//	' --------------------------------------------------------------------------------------
//
//	Private Sub MoveNodeLeft()
//
//	End Sub




		// ---------------------------------------------------------------------------------------------
		
		void InsertToolStripMenuItemClick(object sender, EventArgs e)
		{
			InsertNode();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void AddChildToolStripMenuItemClick(object sender, EventArgs e)
		{
			AddChildNode();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void BUpdateScreenSettingsClick(object sender, EventArgs e)
		{
			HelpItem tempItem = (HelpItem) treeView1.SelectedNode.Tag;
			tempItem.title = hiTitle.Text.Trim();
			tempItem.fileName = hiFileName.Text.Trim();
			tempItem.hasScreen = hiHasScreen.Checked;
			tempItem.usesTitle = hiIncludeTitle.Checked;
			tempItem.usesHeader = hiIncludeHeader.Checked;
			tempItem.usesFooter = hiIncludeFooter.Checked;
			tempItem.linkID = Convert.ToUInt32("0" + hiLinkID.Text.Trim());
			tempItem.linkDescription = hiLinkDesc.Text.Trim();
			tempItem.body = hiBody.Text.Trim();
			
			string s1 = "";
			foreach (DataRow dr in dsIndexEntries.Tables[0].Rows)
			{
				if (dr[0].ToString().Trim().Length > 0)
				{
					if (s1.Length > 0)
					{
						s1 += "|";
					}
					s1 += dr[0].ToString().Trim();
				}
			}
			tempItem.indexEntries = s1;
			
			s1 = "";
			foreach (ListViewItem lvI in lvLinks.Items)
			{
				if ((Boolean) lvI.Checked)
				{
					if (s1.Length > 0)
					{
						s1 += "|";
					}
					s1 += lvI.Text.Trim();
				}
			}
			tempItem.linkList = s1.Trim();
			hiLinkID.Text = tempItem.linkID.ToString().Trim();
			treeView1.SelectedNode.Tag = tempItem;
			treeView1.SelectedNode.Text = hiTitle.Text.Trim();
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void TreeView1NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			treeView1.SelectedNode = e.Node;
			int nIdx = GetBranchIndex(treeView1.SelectedNode);
			FilterContextMenuStrip1(nIdx);
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void MoveUpToolStripMenuItemClick(object sender, EventArgs e)
		{
			int tempIndex = treeView1.SelectedNode.Index;
			TreeNode tempNode = treeView1.SelectedNode;
			TreeNode tempParent = treeView1.SelectedNode.Parent;
			treeView1.SelectedNode.Remove();
			tempParent.Nodes.Insert(tempIndex - 1, tempNode);
			treeView1.SelectedNode = tempNode;
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void MoveDownToolStripMenuItemClick(object sender, EventArgs e)
		{
			int tempIndex = treeView1.SelectedNode.Index;
			TreeNode tempNode = treeView1.SelectedNode;
			TreeNode tempParent = treeView1.SelectedNode.Parent;
			treeView1.SelectedNode.Remove();
			tempParent.Nodes.Insert(tempIndex + 1, tempNode);
			treeView1.SelectedNode = tempNode;
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void DeleteToolStripMenuItemClick(object sender, EventArgs e)
		{
			string s1 = "";
			if (treeView1.SelectedNode.Level > 1)
			{
				if (treeView1.SelectedNode.GetNodeCount(true) > 0)
				{
					s1 = " and all decendents";
				}
				DialogResult result1 = MessageBox.Show("Delete the selected node" + s1 + "?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
				if (result1 == DialogResult.OK)
				{
					treeView1.SelectedNode.Remove();
				}
			}
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void CutNodeToolStripMenuItemClick(object sender, EventArgs e)
		{
			savedNode = CopyBranch(treeView1.SelectedNode, true);
			savedHelpItem = null;
			treeView1.SelectedNode.Remove();
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void CopyNodeToolStripMenuItemClick(object sender, EventArgs e)
		{
			savedNode = CopyBranch(treeView1.SelectedNode, false);
			savedHelpItem = null;
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void PasteNodeAboveToolStripMenuItemClick(object sender, EventArgs e)
		{
			treeView1.SelectedNode.Parent.Nodes.Insert(treeView1.SelectedNode.Index, savedNode);
			treeView1.SelectedNode = savedNode;
			treeView1.SelectedNode.ContextMenuStrip = contextMenuStrip1;
			savedHelpItem = null;
			savedNode = null;
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void PasteNodeBelowToolStripMenuItemClick(object sender, EventArgs e)
		{
			treeView1.SelectedNode.Parent.Nodes.Insert(treeView1.SelectedNode.Index + 1, savedNode);
			treeView1.SelectedNode = savedNode;
			treeView1.SelectedNode.ContextMenuStrip = contextMenuStrip1;
			savedHelpItem = null;
			savedNode = null;
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void PasteAsChildNodeToolStripMenuItemClick(object sender, EventArgs e)
		{
			treeView1.SelectedNode.Nodes.Add(savedNode);
			savedNode.ContextMenuStrip = contextMenuStrip1;
			treeView1.SelectedNode = savedNode;
			savedHelpItem = null;
			savedNode = null;
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void BUpdateProjectSettingsClick(object sender, EventArgs e)
		{
			DataRow dr = ds.Tables[0].Rows[0];
			dr["ProjectName"] = tbProjectName.Text.Trim();
			dr["FileName"] = tbRootFileName.Text.Trim();
			dr["Author"] = tbAuthor.Text.Trim();
			dr["Company"] = tbCompany.Text.Trim();
			dr["Copyright"] = tbCopyright.Text.Trim();
			dr["Template"] = tbTemplateUsed.Text.Trim();
			dr["Language"] = tbLanguage.Text.Trim();
			dr["DefaultTopic"] = tbDefaultTopic.Text.Trim();
			dr["FullTextSearch"] = ( cbFullTextSearch.Checked ? "Yes" : "No" );
			treeView1.Nodes[0].Text = tbProjectName.Text.Trim();
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private TreeNode CopyBranch(TreeNode selectNode, bool cut)
		{
			TreeNode node1 = new TreeNode(selectNode.Text);
			if (cut == true)
			{
				node1.Tag = selectNode.Tag;
			}
			else
			{
				HelpItem tHelpItem = (HelpItem) selectNode.Tag;
				node1.Tag = tHelpItem.Copy();
			}

			//copy all the child nodes
			CopyChildNodes(selectNode, node1, cut);
			return node1;
		}

		// ---------------------------------------------------------------------------------------------

		private void CopyChildNodes(TreeNode searchNode, TreeNode newParentNode, bool cut)
		{
			foreach (TreeNode tn1 in searchNode.Nodes)
			{
				TreeNode tmpNode = new TreeNode(tn1.Text);
				tmpNode.Tag = tn1.Tag;
				tmpNode.ContextMenuStrip = contextMenuStrip1;
				if (cut == false)
				{
					HelpItem tHelpItem = (HelpItem) tmpNode.Tag;
					tmpNode.Tag = tHelpItem.Copy();
				}
				newParentNode.Nodes.Add(tmpNode);
				CopyChildNodes(tn1, tmpNode, cut);
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void TreeView1ItemDrag(object sender, ItemDragEventArgs e)
		{
			TreeNode draggedNode = (TreeNode) e.Item;
			if (draggedNode.Level > 1)
			{
				DoDragDrop(e.Item, DragDropEffects.Copy | DragDropEffects.Move | DragDropEffects.None);
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void TreeView1DragEnter(object sender, DragEventArgs e)
		{
			if ((ModifierKeys & Keys.Control) == Keys.Control)
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.Move;
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void TreeView1DragDrop(object sender, DragEventArgs e)
		{
			// Retrieve the client coordinates of the drop location.
			Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));

			// Retrieve the node at the drop location.
			TreeNode targetNode = treeView1.GetNodeAt(targetPoint);

			// Retrieve the node that was dragged.
			TreeNode draggedNode = (TreeNode) e.Data.GetData(typeof(TreeNode));

			// Confirm that the node at the drop location is not
			// the dragged node and that target node isn't null
			// (for example if you drag outside the control)
			if ( (!draggedNode.Equals(targetNode))
			     && (targetNode != null)
			     && (draggedNode.Level > 1)
			     && (targetNode.Level > 0)
			     && (!ContainsNode(draggedNode, targetNode)) )
			{
				if (e.Effect == DragDropEffects.Move)
				{
					// Remove the node from its current
					// location and add it to the node at the drop location.
					draggedNode.Remove();
					targetNode.Nodes.Add(draggedNode);
				}
				else if (e.Effect == DragDropEffects.Copy)
				{
					savedNode = CopyBranch(draggedNode, false);
					targetNode.Nodes.Add(savedNode);
				}

				// Expand the node at the location
				// to show the dropped node.
				treeView1.SelectedNode = targetNode;
				targetNode.ExpandAll();
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void TreeView1DragOver(object sender, DragEventArgs e)
		{
			// Retrieve the client coordinates of the drop location.
			Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));

			// Retrieve the node at the drop location.
			TreeNode targetNode = treeView1.GetNodeAt(targetPoint);
			if (targetNode.Level > 0)
			{
				treeView1.SelectedNode = targetNode;
			}
			
			if ( ((e.KeyState & 8) == 8)
			    && ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) )
			{
				// CTL KeyState for copy.
				e.Effect = DragDropEffects.Copy;

			}
			else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move) 
			{
				// By default, the drop action should be move, if allowed.
				e.Effect = DragDropEffects.Move;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
//			if ((ModifierKeys & Keys.Control) == Keys.Control) {
//				e.Effect = DragDropEffects.Copy;
//			}
//			else {
//				e.Effect = DragDropEffects.Move;
//			}
		}
		
		// ---------------------------------------------------------------------------------------------
		// Determine whether one node is a parent
		// or ancestor of a second node.
		private bool ContainsNode(TreeNode node1, TreeNode node2)
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
		
		// ---------------------------------------------------------------------------------------------
		
		void SaveProjectFile()
		{
			TreeToDataset();
			ds.WriteXml(helpProjectFilePathAndName);
		}
		
		// ---------------------------------------------------------------------------------------------
		
		bool GetProjectSaveAsName()
		{
			saveFileDialog1.Filter = "Help Project files (*.hhb)|*.hhb|All files (*.*)|*.*";
			saveFileDialog1.FilterIndex = 1;
			if (helpProjectFilePathAndName.Trim().Length > 0)
			{
				saveFileDialog1.FileName = System.IO.Path.GetFileName(helpProjectFilePathAndName);
				saveFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(helpProjectFilePathAndName);
			}
			else
			{
				saveFileDialog1.FileName = "HHB_Project.hhb";
			}
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				helpProjectFilePathAndName = saveFileDialog1.FileName;
				return true;
			}
			return false;
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void SaveProject(object sender, EventArgs e)
		{
			if (helpProjectFilePathAndName.Trim().Length < 1)
			{
				if (GetProjectSaveAsName() == false)
				{
					return;
				}
			}
			SaveProjectFile();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (GetProjectSaveAsName() == true)
			{
				SaveProjectFile();
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void OpenProject(object sender, EventArgs e)
		{
			openFileDialog1.Filter = "Help Project files (*.hhb)|*.hhb|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			if (helpProjectFilePathAndName.Trim().Length > 0)
			{
				openFileDialog1.InitialDirectory = System.IO.Path.GetFileName(helpProjectFilePathAndName);
			}
			openFileDialog1.FileName = "";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				helpProjectFilePathAndName = openFileDialog1.FileName;
				ds.Clear();
				ds.ReadXml(helpProjectFilePathAndName);
				ShowDataSet();
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void NewProject(object sender, EventArgs e)
		{
			InitDataSet();
			ShowDataSet();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void AddFileToolStripMenuItemClick(object sender, EventArgs e)
		{
			int nIdx = GetBranchIndex(treeView1.SelectedNode);
			if (nIdx > 1)
			{
				TreeNode tNode = treeView1.Nodes[0].Nodes[nIdx].Nodes.Add("new file");
				if (nIdx == 2)
				{
					tNode.Tag = new CSSItem();
				}
				if (nIdx == 3)
				{
					tNode.Tag = new ScriptItem();
				}
				if (nIdx == 4)
				{
					tNode.Tag = new ImageItem();
				}
				treeView1.SelectedNode = tNode;
				treeView1.SelectedNode.ContextMenuStrip = contextMenuStrip2;
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void BCssSaveClick(object sender, EventArgs e)
		{
			CSSItem tItem = (CSSItem) treeView1.SelectedNode.Tag;
			tItem.fileName = tbCssFilename.Text.Trim();
			tItem.title = tbCssTitle.Text.Trim();
			tItem.content = tbCssContents.Text.Trim();
			treeView1.SelectedNode.Tag = tItem;
			treeView1.SelectedNode.Text = tbCssTitle.Text.Trim();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void BScriptSaveClick(object sender, EventArgs e)
		{
			ScriptItem tItem = (ScriptItem) treeView1.SelectedNode.Tag;
			tItem.fileName = tbScriptFilename.Text.Trim();
			tItem.title = tbScriptTitle.Text.Trim();
			tItem.content = tbScriptContent.Text.Trim();
			treeView1.SelectedNode.Tag = tItem;
			treeView1.SelectedNode.Text = tbScriptTitle.Text.Trim();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void BImageSaveClick(object sender, EventArgs e)
		{
			ImageItem tItem = (ImageItem) treeView1.SelectedNode.Tag;
			tItem.fileName = tbImageFilename.Text.Trim();
			tItem.title = tbImageTitle.Text.Trim();
			tItem.content = tbImageContent.Text;
			treeView1.SelectedNode.Tag = tItem;
			treeView1.SelectedNode.Text = tbImageTitle.Text.Trim();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void RemoveFileToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (treeView1.SelectedNode.Level > 1)
			{
				DialogResult result1 = MessageBox.Show("Delete the selected node?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
				if (result1 == DialogResult.OK)
				{
					treeView1.SelectedNode.Remove();
				}
			}
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			CleanTempFiles();
			Application.Exit();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void CleanTempFiles()
		{
			// Add code to remove all temporary files and directories.
			// This should also be called when exiting via the close button in the header.
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void ShowLinks()
		{
			
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void MakeTempDirs()
		{
			string TempRoot = System.IO.Path.GetTempPath() + "HHB";
			MessageBox.Show(TempRoot);
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void CleanTempDirs()
		{
			
		}
		
		// ---------------------------------------------------------------------------------------------
		/// <summary>
		/// Add line numbers to DataGridView rows.  Call from the RowPostPaint event. 
		/// </summary>
		/// <param name="sender">The DataGridView control firing the event.</param>
		/// <param name="e">The control's event arguments.</param>
		/// 
		public void DgvAddLineNumbers(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
			{
				e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), 
				                      ((DataGridView)sender).DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void OptionsToolStripMenuItemClick(object sender, EventArgs e)
		{
			Form frm = new frmSettings();
			frm.ShowDialog();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void CbLanguageSelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbLanguage.SelectedIndex < 0)
			{
				tbLanguage.Text = "";
			}
			else
			{
				tbLanguage.Text = ((Language) cbLanguage.SelectedItem).CodeText();
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		public static Control FindFocusedControl(Control control)
		{
			var container = control as IContainerControl;
			while (container != null)
			{
				control = container.ActiveControl;
				container = control as IContainerControl;
			}
//			string s1 = control.Name;
//			string s2 = control.GetType().ToString();
//			MessageBox.Show(string.Format("Name: {0}\nType: {1}\n", s1, s2));
			return control;
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void CutButton(object sender, EventArgs e)
		{
			Control tControl = FindFocusedControl(this);
			if (tControl.GetType() == typeof(TextBox))
			{
				((TextBox) tControl).Cut();
			}
			
			if (tControl.GetType() == typeof(TreeView))
			{
				TreeView tTV = (TreeView) tControl;
				TreeNode tNode = tTV.SelectedNode;
				if ((GetBranchIndex(tNode) < 2) && (tNode.Level > 1))
				{
					savedNode = CopyBranch(tNode, true);
					savedHelpItem = null;
					tNode.Remove();
					DisplayNodeInfo();
				}
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void CopyButton(object sender, EventArgs e)
		{
			Control tControl = FindFocusedControl(this);
			if (tControl.GetType() == typeof(TextBox))
			{
				((TextBox) tControl).Copy();
			}
			if (tControl.GetType() == typeof(TreeView))
			{
				TreeView tTV = (TreeView) tControl;
				TreeNode tNode = tTV.SelectedNode;
				if ((GetBranchIndex(tNode) < 2) && (tNode.Level > 1))
				{
					savedNode = CopyBranch(tNode, false);
					savedHelpItem = null;
					DisplayNodeInfo();
				}
			}
		}

		// ---------------------------------------------------------------------------------------------
		
		void PasteButton(object sender, EventArgs e)
		{
			Control tControl = FindFocusedControl(this);
			if (tControl.GetType() == typeof(TextBox))
			{
				((TextBox) tControl).Paste();
			}
			if (tControl.GetType() == typeof(TreeView))
			{
				TreeView tTV = (TreeView) tControl;
				TreeNode tNode = tTV.SelectedNode;
				int iIdx = GetBranchIndex(tNode);
				if ((iIdx < 2) && (tNode.Level > 0) && (savedNode != null))
				{
					if ((iIdx == 0) && (tNode.Level > 0))
					{
						tTV.SelectedNode = tNode.Nodes[tNode.Nodes.Add(savedNode)];
						tTV.SelectedNode.ContextMenuStrip = contextMenuStrip1;
					}
					if (iIdx == 1)
					{
						PastePopupNodes(tTV, savedNode);
					}
					savedHelpItem = null;
					savedNode = null;
					DisplayNodeInfo();
				}
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void PastePopupNodes(TreeView tvTree, TreeNode tvNode)
		{
			TreeNode cNode = (TreeNode) tvNode.Clone();
			cNode.Nodes.Clear();
			tvTree.Nodes[0].Nodes[1].Nodes.Add(cNode);
			TreeNode tNode = tvNode;
			foreach (TreeNode tTN in tvNode.Nodes)
			{
				PastePopupNodes(tvTree, tTN);
			}
			tvTree.SelectedNode = tNode;
		}
		
		// ---------------------------------------------------------------------------------------------
		
		bool ProcessProject()
		{
			// TODO Prepare Image Collection
			// TODO Prepare CSS Collection
			// TODO Prepare Scripts Collection
			// TODO Prepare Popup Collection
			
			return true;
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void LPictureBoxDragDrop(object sender, DragEventArgs e)
		{
			string[] theFiles = (string[]) e.Data.GetData("FileDrop", true);
			if (theFiles.Length > 0)
			{
				LoadImageFile(theFiles[0]);
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void LoadImageFile(string ImageFileName)
		{
			if (System.IO.File.Exists(ImageFileName.Trim())) {
				tbImageFilename.Text = "Img_" + tbImageID.Text.Trim() + System.IO.Path.GetExtension(ImageFileName);
				tbImageContent.Text = ImageItem.GetFileContents(ImageFileName.Trim());
				DisplayImage();
			}
			else
			{
				tbImageContent.Text = "";
				Log.ErrorBox("Unable to open the specified image file.");
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void LPictureBoxDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		void DisplayImage()
		{
			if (tbImageContent.Text.Trim().Length > 0)
			{
				pictureBox1.Image = ImageItem.GetImage(tbImageContent.Text);
				if ((pictureBox1.Image.PhysicalDimension.Width > pictureBox1.Width)
				    || (pictureBox1.Image.PhysicalDimension.Height > pictureBox1.Height))
				{
					pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
				}
				else
				{
					pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
				}
				tbImageSize.Text = String.Format("{0} x {1}", pictureBox1.Image.PhysicalDimension.Width, 
				                                 pictureBox1.Image.PhysicalDimension.Height);
			}
			else
			{
				tbImageSize.Text = "";
				pictureBox1.Image = null;
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
//			// Test Culture code
//			MessageBox.Show(String.Format("Current Language: {0}\nMessage: {1}\n", Language.culture, Language.GetString("errorMessage001")));
//			Language.culture = "uk-UA";
//			MessageBox.Show(String.Format("Current Language: {0}\nMessage: {1}\n", Language.culture, Language.GetString("errorMessage001")));
//			Language.culture = "en-US";
//			MessageBox.Show(String.Format("Current Language: {0}\nMessage: {1}\n", Language.culture, Language.GetString("errorMessage001")));
			
//			// Test unpacking a template package
//			HHBTemplate tempTemplate = new HHBTemplate(@"C:\Development\SharpDevelop\Projects\osHHB\hhb\HHB\bin\Debug\DefaultTemplate.hhbt");
//			tempTemplate.workingDir = @"C:\--HHB--\Working";
//			tempTemplate.UnpackTemplatePackage();
			
//			// Test creating a template package
//			HHBTemplate tempTemplate = new HHBTemplate();
//			tempTemplate.id = @"t00000000000000000";
//			tempTemplate.title = @"Basic HH Builder Template";
//			tempTemplate.description = @"Basic template with the index number, title and home link in the header, and the previous and next links in the footer.";
//			tempTemplate.author = @"Bob Swift";
//			tempTemplate.company = @"";
//			tempTemplate.contactName = @"Bob Swift";
//			tempTemplate.contactEmail = @"bswift@users.sourceforge.net";
//			tempTemplate.contactWebsite = @"https://sourceforge.net/projects/oshhb/";
//			tempTemplate.version = @"1.00";
//			tempTemplate.revisionDate = @"2016-11-02";
//			tempTemplate.licenseTitle = @"GPLv3";
//			HHBTemplate.SetWorkingDir(@"C:\--HHB--\Working");
//			string sourceDir = @"C:\--HHB--\Source";
//			string packageFile = @"C:\--HHB--\TestTemplate.hhbt";
//			tempTemplate.fileName = packageFile;
//			if ( tempTemplate.PackTemplatePackage(sourceDir) )
//			{
//				MessageBox.Show("Successfully created template file:\n\n" + packageFile + "\n\nfrom the files found in:\n\n" + sourceDir, "Success");
//			}
//			else
//			{
//				Log.ErrorBox("Error creating template file:\n\n" + packageFile + "\n\nfrom the files found in:\n\n" + sourceDir);
//			}
			
		}
	}
}
