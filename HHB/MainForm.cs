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
//		DataSet dsLinks = new DataSet();
		DataSet dsIndexEntries = new DataSet();
		HelpItem savedHelpItem = null;
		TreeNode savedNode = null;
		string helpProjectFilePathAndName = "";
//		public static ResourceManager rmText = new ResourceManager("HHBuilder.LanguageText", Assembly.GetExecutingAssembly());
		public const int _MaxLevels = 7;
		private static string _returnedString;
		
		public static string parameterString
		{
			get{ return _returnedString.Trim(); }
			set{ _returnedString = value.Trim(); }
		}
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			AssemblyName tempAssembly = Assembly.GetExecutingAssembly().GetName();
			this.Text = String.Format("HTML Help Builder ({0} v{1}.{2:00})", tempAssembly.Name, tempAssembly.Version.Major, tempAssembly.Version.Minor);
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
			
			Log.logDir = HBSettings.logDir;
			Log.level = HBSettings.logLevel;
			Log.filesToKeep = HBSettings.logsToKeep;
			Log.Debug("Session started.");
			if ( !String.IsNullOrWhiteSpace(HBSettings.uiCulture) )
			{
				Language.culture = HBSettings.uiCulture;
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
			treeView1.Nodes.Clear();
			treeView1.Nodes.Add(HelpNode.Initialize());
			SetTreeContextMenuStrips();
			treeView1.ExpandAll();
			
			InitDataSet();
			string defaultLanguage = HBSettings.language;
			cbLanguage.SelectedIndex = -1;
			if ( !String.IsNullOrEmpty(defaultLanguage) )
			{
				cbLanguage.SelectedIndex = cbLanguage.FindString(defaultLanguage.Substring(7).Trim());
			}
			UpdateTemplateTab();
			Log.Debug("Project form reset.");
//			ShowDataSet();
		}
		
		
		// ---------------------------------------------------------------------------------------------
		/// <summary>
		/// Initialize the dataset
		/// </summary>
		public void InitDataSet()
		{
			DataTable dt = new DataTable();
			DataColumn dc;
			
//			// Initialize Links DataSet
//			dsLinks = new DataSet();
//			dsLinks.DataSetName = "HelpLinks";
//			dt = new DataTable();
//			dt.TableName = "Links";
//			dc = new DataColumn("ID", Type.GetType("System.String"));
//			dt.Columns.Add(dc);
//			dc = new DataColumn("Title", Type.GetType("System.String"));
//			dt.Columns.Add(dc);
//			dc = new DataColumn("Checked", Type.GetType("System.Boolean"));
//			dt.Columns.Add(dc);
//			dc = new DataColumn("Index", Type.GetType("System.String"));
//			dt.Columns.Add(dc);
//			dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
//			dsLinks.Tables.Add(dt);
			
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
		/// <param name="nIdx">The branch index number of the current treenode.</param>
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
		
//		// ---------------------------------------------------------------------------------------------
//		
//		public int GetBranchIndex(TreeNode NodeToCheck)
//		{
//			if ((NodeToCheck == null) || (NodeToCheck.Level < 1))
//			{
//				return -1;
//			}
//			TreeNode tempNode = NodeToCheck;
//			while (tempNode.Level > 1)
//			{
//				tempNode = tempNode.Parent;
//			}
//			return tempNode.Index;
//		}
		
		// ---------------------------------------------------------------------------------------------
		void UpdateTemplateTab()
		{
			if (treeView1.SelectedNode != null)
			{
				TreeNode tNode = HelpNode.GetRootNode(treeView1.SelectedNode);
				HHBProject tProject = (HHBProject) tNode.Tag;
				if ( tbTemplateID.Text != tProject.template)
				{
					HHBTemplate tTemplate = HHBTemplate.GetTemplate(tProject.template);
					tbTemplateID.Text = tTemplate.id;
					tbTemplateTitle.Text = tTemplate.title;
					tbTemplateAuthor.Text = tTemplate.author;
					tbTemplateCompany.Text = tTemplate.company;
					tbTemplateContact.Text = tTemplate.contactName;
					tbTemplateEmail.Text = tTemplate.contactEmail;
					tbTemplateWebsite.Text = tTemplate.contactWebsite;
					tbTemplateDescription.Text = tTemplate.description;
					tbTemplateVersion.Text = tTemplate.version;
					tbTemplateDate.Text = tTemplate.revisionDate;
					tbTemplateLicense.Text = tTemplate.licenseTitle;
					tbTemplateNotes.Text = tTemplate.Notes();
				}
			}
			
		}
		
		// ---------------------------------------------------------------------------------------------
		/// <summary>
		/// Display the information on the appropriate tab page for the currently selected node.
		/// </summary>
		void DisplayNodeInfo()
		{
			UpdateTemplateTab();
			
			bool bTest = false;
			if (treeView1.SelectedNode != null)
			{
				toolStripStatusLabel1.Text = HelpNode.NodeIndexPath(treeView1.SelectedNode, true);
				if (treeView1.SelectedNode.Level > 1)
				{
					bTest = true;
				}
			}
			if (tabControl1.TabPages.Contains(tabPageScreen) == true)
			{
				tabControl1.TabPages.Remove(tabPageScreen);
			}
			if (tabControl1.TabPages.Contains(tabPagePopupText) == true)
			{
				tabControl1.TabPages.Remove(tabPagePopupText);
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
			
			if (treeView1.SelectedNode.Level < 1)
			{
				HHBProject tProject = (HHBProject) treeView1.Nodes[0].Tag;
				treeView1.Nodes[0].Text = tProject.title;
				
				tbProjectName.Text = tProject.title;
				tbRootFileName.Text = tProject.filename;
				tbAuthor.Text = tProject.author;
				tbCompany.Text = tProject.company;
				tbCopyright.Text = tProject.copyright;
				tbTemplateUsed.Text = tProject.template;
				tbLanguage.Text = tProject.language;
				tbDefaultTopic.Text = tProject.defaultTopic;
				cbFullTextSearch.Checked = tProject.useFullTextSearch;
			}
			
			if (bTest)
			{
				int nIdx = HelpNode.GetBranchIndex(treeView1.SelectedNode);
				switch (nIdx)
				{
					case (int) HelpNode.branches.tocEntry:
					case (int) HelpNode.branches.htmlPopup:
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
						
						lvLinks.Items.Clear();
//						if (nIdx < 1)		// Uncomment this to disallow links on HTML Popup screens
						{
							DataSet ds = HelpNode.ScreenLinks(treeView1.Nodes[0]);
							foreach (DataRow dsRow in ds.Tables[0].Rows)
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
						tabControl1.SelectedTab = tabPageScreen;
						break;
					case (int) HelpNode.branches.textPopup:
						PopupTextItem tempPopupText = (PopupTextItem) treeView1.SelectedNode.Tag;
						treeView1.SelectedNode.Text = tempPopupText.title;
						tbPopupTextTitle.Text = tempPopupText.title;
						tbPopupTextID.Text = tempPopupText.id;
						tbPopupTextLinkID.Text = tempPopupText.linkID.ToString().Trim();
						tbPopupTextText.Text = tempPopupText.helpText;
						if (tabControl1.TabPages.Contains(tabPagePopupText) == false)
						{
							tabControl1.TabPages.Add(tabPagePopupText);
						}
						tabControl1.SelectedTab = tabPagePopupText;
						break;
					case (int) HelpNode.branches.cssFile:
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
					case (int) HelpNode.branches.scriptFile:
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
					case (int) HelpNode.branches.imageFile:
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
			SetTreeContextMenuStrips();
			treeView1.SelectedNode.ExpandAll();
			treeView1.Focus();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void TreeView1AfterSelect(object sender, TreeViewEventArgs e)
		{
			int nIdx = HelpNode.GetBranchIndex(treeView1.SelectedNode);
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
		
		private void InsertToolStripMenuItemClick(object sender, EventArgs e)
		{
			InsertNode();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void AddChildToolStripMenuItemClick(object sender, EventArgs e)
		{
			AddChildNode();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void BUpdateScreenSettingsClick(object sender, EventArgs e)
		{
			HelpItem tempItem = (HelpItem) treeView1.SelectedNode.Tag;
			tempItem.title = hiTitle.Text.Trim();
			//tempItem.fileName = hiFileName.Text.Trim();
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
		
		private void TreeView1NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			treeView1.SelectedNode = e.Node;
			int nIdx = HelpNode.GetBranchIndex(treeView1.SelectedNode);
			FilterContextMenuStrip1(nIdx);
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void MoveUpToolStripMenuItemClick(object sender, EventArgs e)
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
		
		private void MoveDownToolStripMenuItemClick(object sender, EventArgs e)
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
		
		private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
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
		
		private void CutNodeToolStripMenuItemClick(object sender, EventArgs e)
		{
			savedNode = CopyBranch(treeView1.SelectedNode, true);
			savedHelpItem = null;
			treeView1.SelectedNode.Remove();
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void CopyNodeToolStripMenuItemClick(object sender, EventArgs e)
		{
			savedNode = CopyBranch(treeView1.SelectedNode, false);
			savedHelpItem = null;
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void PasteNodeAboveToolStripMenuItemClick(object sender, EventArgs e)
		{
			treeView1.SelectedNode.Parent.Nodes.Insert(treeView1.SelectedNode.Index, savedNode);
			treeView1.SelectedNode = savedNode;
			treeView1.SelectedNode.ContextMenuStrip = contextMenuStrip1;
			savedHelpItem = null;
			savedNode = null;
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void PasteNodeBelowToolStripMenuItemClick(object sender, EventArgs e)
		{
			treeView1.SelectedNode.Parent.Nodes.Insert(treeView1.SelectedNode.Index + 1, savedNode);
			treeView1.SelectedNode = savedNode;
			treeView1.SelectedNode.ContextMenuStrip = contextMenuStrip1;
			savedHelpItem = null;
			savedNode = null;
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void PasteAsChildNodeToolStripMenuItemClick(object sender, EventArgs e)
		{
			treeView1.SelectedNode.Nodes.Add(savedNode);
			savedNode.ContextMenuStrip = contextMenuStrip1;
			treeView1.SelectedNode = savedNode;
			savedHelpItem = null;
			savedNode = null;
			DisplayNodeInfo();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void BUpdateProjectSettingsClick(object sender, EventArgs e)
		{
			HHBProject tProject = (HHBProject) treeView1.Nodes[0].Tag;
			
			tProject.title = tbProjectName.Text;
			tProject.filename = tbRootFileName.Text;
			tProject.author = tbAuthor.Text;
			tProject.company = tbCompany.Text;
			tProject.copyright = tbCopyright.Text;
			tProject.template = tbTemplateUsed.Text;
			tProject.language = tbLanguage.Text;
			tProject.defaultTopic = tbDefaultTopic.Text;
			tProject.useFullTextSearch = cbFullTextSearch.Checked;
			
			treeView1.Nodes[0].Text = tProject.title;
			treeView1.Nodes[0].Tag = tProject;
			
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
		
		private void TreeView1ItemDrag(object sender, ItemDragEventArgs e)
		{
			TreeNode draggedNode = (TreeNode) e.Item;
			if (draggedNode.Level > 1)
			{
				DoDragDrop(e.Item, DragDropEffects.Copy | DragDropEffects.Move | DragDropEffects.None);
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void TreeView1DragEnter(object sender, DragEventArgs e)
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
		
		private void TreeView1DragDrop(object sender, DragEventArgs e)
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
		
		private void TreeView1DragOver(object sender, DragEventArgs e)
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
		
		private void SaveProjectFile()
		{
			//TreeToDataset();
			//ds.WriteXml(helpProjectFilePathAndName);
			HelpNode.Save(treeView1.Nodes[0], helpProjectFilePathAndName);
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private bool GetProjectSaveAsName()
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
		
		private void SaveProject(object sender, EventArgs e)
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
		
		private void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (GetProjectSaveAsName() == true)
			{
				SaveProjectFile();
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void OpenProject(object sender, EventArgs e)
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
				TreeNode tNode;
				try
				{
					tNode = HelpNode.Load(helpProjectFilePathAndName);
					treeView1.Nodes.Clear();
					treeView1.Nodes.Add(tNode);
					treeView1.ExpandAll();
					treeView1.SelectedNode = treeView1.Nodes[0];
					DisplayNodeInfo();
				}
				catch (Exception)
				{
					Log.ErrorBox("Problem reading the selected project file.");
					//throw;
				}
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void NewProject(object sender, EventArgs e)
		{
			InitDataSet();
			
			TreeNode tNode;
			try
			{
				tNode = HelpNode.Initialize();
				treeView1.Nodes.Clear();
				treeView1.Nodes.Add(tNode);
				treeView1.ExpandAll();
			}
			catch (Exception)
			{
				Log.ErrorBox("Problem initializing the project file.");
				//throw;
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void AddFileToolStripMenuItemClick(object sender, EventArgs e)
		{
			int nIdx = HelpNode.GetBranchIndex(treeView1.SelectedNode);
			if (nIdx > 1)
			{
				TreeNode tNode = treeView1.Nodes[0].Nodes[nIdx].Nodes.Add("new file");
				switch (nIdx) {
					case (int) HelpNode.branches.textPopup:
						tNode.Tag = new PopupTextItem();
						break;
					case (int) HelpNode.branches.cssFile:
						tNode.Tag = new CSSItem();
						break;
					case (int) HelpNode.branches.scriptFile:
						tNode.Tag = new ScriptItem();
						break;
					case (int) HelpNode.branches.imageFile:
						tNode.Tag = new ImageItem();
						break;
					default:
						ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("Branch Type", "Unknown or unspecified project branch type.");
						ex.Source = this.Name;
						Log.ErrorExit(ex);
						break;
				}
				treeView1.SelectedNode = tNode;
				treeView1.SelectedNode.ContextMenuStrip = contextMenuStrip2;
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void BCssSaveClick(object sender, EventArgs e)
		{
			CSSItem tItem = (CSSItem) treeView1.SelectedNode.Tag;
			tItem.fileName = tbCssFilename.Text.Trim();
			tItem.title = tbCssTitle.Text.Trim();
			tItem.content = tbCssContents.Text.Trim();
			treeView1.SelectedNode.Tag = tItem;
			treeView1.SelectedNode.Text = tbCssTitle.Text.Trim();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void BScriptSaveClick(object sender, EventArgs e)
		{
			ScriptItem tItem = (ScriptItem) treeView1.SelectedNode.Tag;
			tItem.fileName = tbScriptFilename.Text.Trim();
			tItem.title = tbScriptTitle.Text.Trim();
			tItem.content = tbScriptContent.Text.Trim();
			treeView1.SelectedNode.Tag = tItem;
			treeView1.SelectedNode.Text = tbScriptTitle.Text.Trim();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void BImageSaveClick(object sender, EventArgs e)
		{
			ImageItem tItem = (ImageItem) treeView1.SelectedNode.Tag;
			//tItem.fileName = tbImageFilename.Text.Trim();
			tItem.extension = System.IO.Path.GetExtension(tbImageFilename.Text.Trim());
			tItem.title = tbImageTitle.Text.Trim();
			tItem.content = tbImageContent.Text;
			treeView1.SelectedNode.Tag = tItem;
			treeView1.SelectedNode.Text = tbImageTitle.Text.Trim();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void BUpdatePopupTextClick(object sender, EventArgs e)
		{
			PopupTextItem tItem = (PopupTextItem) treeView1.SelectedNode.Tag;
			tItem.title = tbPopupTextTitle.Text.Trim();
			tItem.linkID = Convert.ToUInt32(tbPopupTextLinkID.Text.Trim());
			tItem.helpText = tbPopupTextText.Text;
			treeView1.SelectedNode.Tag = tItem;
			treeView1.SelectedNode.Text = tItem.title;
		}

		// ---------------------------------------------------------------------------------------------
		
		private void RemoveFileToolStripMenuItemClick(object sender, EventArgs e)
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
		
		private void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			CleanTempFiles();
			Application.Exit();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void CleanTempFiles()
		{
			// Add code to remove all temporary files and directories.
			// This should also be called when exiting via the close button in the header.
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void ShowLinks()
		{
			
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void MakeTempDirs()
		{
			string TempRoot = System.IO.Path.GetTempPath() + "HHB";
			MessageBox.Show(TempRoot);
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void CleanTempDirs()
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
		
		private void OptionsToolStripMenuItemClick(object sender, EventArgs e)
		{
			Form frm = new frmSettings();
			frm.ShowDialog();
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void CbLanguageSelectedIndexChanged(object sender, EventArgs e)
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
		
		private void CutButton(object sender, EventArgs e)
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
				if ((HelpNode.GetBranchIndex(tNode) < 2) && (tNode.Level > 1))
				{
					savedNode = CopyBranch(tNode, true);
					savedHelpItem = null;
					tNode.Remove();
					DisplayNodeInfo();
				}
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void CopyButton(object sender, EventArgs e)
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
				if ((HelpNode.GetBranchIndex(tNode) < 2) && (tNode.Level > 1))
				{
					savedNode = CopyBranch(tNode, false);
					savedHelpItem = null;
					DisplayNodeInfo();
				}
			}
		}

		// ---------------------------------------------------------------------------------------------
		
		private void PasteButton(object sender, EventArgs e)
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
				int iIdx = HelpNode.GetBranchIndex(tNode);
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
		
		private void PastePopupNodes(TreeView tvTree, TreeNode tvNode)
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
		
		private bool ProcessProject()
		{
			// TODO Prepare Image Collection
			// TODO Prepare CSS Collection
			// TODO Prepare Scripts Collection
			// TODO Prepare Popup Collection
			
			return true;
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void LPictureBoxDragDrop(object sender, DragEventArgs e)
		{
			string[] theFiles = (string[]) e.Data.GetData("FileDrop", true);
			if (theFiles.Length > 0)
			{
				LoadImageFile(theFiles[0]);
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void LoadImageFile(string ImageFileName)
		{
			if (System.IO.File.Exists(ImageFileName.Trim())) {
				tbImageFilename.Text = tbImageID.Text.Trim() + System.IO.Path.GetExtension(ImageFileName);
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
		
		private void LPictureBoxDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}
		
		// ---------------------------------------------------------------------------------------------
		
		private void DisplayImage()
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
		
		private void SetTreeContextMenuStrips()
		{
			RecurseContextMenuStrip1(treeView1.Nodes[0].Nodes[(int) HelpNode.branches.tocEntry]);
			RecurseContextMenuStrip1(treeView1.Nodes[0].Nodes[(int) HelpNode.branches.htmlPopup]);
			RecurseContextMenuStrip2(treeView1.Nodes[0].Nodes[(int) HelpNode.branches.textPopup]);
			RecurseContextMenuStrip2(treeView1.Nodes[0].Nodes[(int) HelpNode.branches.cssFile]);
			RecurseContextMenuStrip2(treeView1.Nodes[0].Nodes[(int) HelpNode.branches.scriptFile]);
			RecurseContextMenuStrip2(treeView1.Nodes[0].Nodes[(int) HelpNode.branches.imageFile]);
		}
		
		private void RecurseContextMenuStrip1(TreeNode tNode)
		{
			tNode.ContextMenuStrip = contextMenuStrip1;
			foreach (TreeNode tempNode in tNode.Nodes) {
				RecurseContextMenuStrip1(tempNode);
			}
		}
		
		private void RecurseContextMenuStrip2(TreeNode tNode)
		{
			tNode.ContextMenuStrip = contextMenuStrip2;
			foreach (TreeNode tempNode in tNode.Nodes) {
				RecurseContextMenuStrip2(tempNode);
			}
		}
		
		private void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (HBSettings.cleanOnExit )
			{
				HHBTemplate.Cleanup();
				HHCompile.Cleanup();
			}
			Log.CleanLogFiles();
			Log.Debug("Session ended.  Exiting the program.");
		}
		
		private void BViewTemplateLicenseClick(object sender, EventArgs e)
		{
			HHBTemplate tTemplate = HHBTemplate.GetTemplate(tbTemplateID.Text.Trim());
			string tLicense = tTemplate.License();
			Form frm = new ViewLicense(tLicense);
			frm.ShowDialog();
		}
		
		private void BPreviewScreenClick(object sender, EventArgs e)
		{
			TreeNode node = treeView1.Nodes[0];
			HHCompile.MakeFiles(node);
			TreeNode tNode = treeView1.SelectedNode;
			HelpItem tHelp = (HelpItem) tNode.Tag;
			string fileName = System.IO.Path.Combine(HBSettings.projectBuildDir, tHelp.fileName);
			if ( System.IO.File.Exists(fileName) )
			{
				Form frm = new PreviewHTML(fileName);
				frm.ShowDialog();
			}
			else
			{
				Log.ErrorBox("Unable to load the HTML file " + fileName);
			}
		}
		
		void BTemplateSelectClick(object sender, EventArgs e)
		{
			parameterString = String.Empty;
			Form frm = new TemplateSelector();
			frm.ShowDialog();
			if ( !String.IsNullOrWhiteSpace(parameterString) )
			{
				TreeNode tNode = HelpNode.GetRootNode(treeView1.SelectedNode);
				HHBProject tProject = (HHBProject) tNode.Tag;
				tProject.template = parameterString;
				tNode.Tag = tProject;
				parameterString = String.Empty;
				UpdateTemplateTab();
			}
		}
		
		private void ToolStripButton1Click(object sender, EventArgs e)
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
			
//			// Test node count and list string methods
//			Log.ErrorBox("Treeview has " + HelpNode.NodeCount(treeView1.Nodes[0]).ToString() + " Nodes.\n\n" + HelpNode.NodeList(treeView1.Nodes[0], 2));
			
//			// Test treenode initialize
//			TreeNode tempNode = HelpNode.Initialize();
//			Log.ErrorBox("Treeview has " + HelpNode.NodeCount(tempNode).ToString() + " Nodes.\n\n" + HelpNode.NodeList(tempNode, 2));
//			treeView1.Nodes.Clear();
//			treeView1.Nodes.Add(tempNode);
//			treeView1.ExpandAll();
//			Log.ErrorBox("TreeView updated.");
			
//			// Test project load
//			try
//			{
//				TreeNode tempNode = HelpNode.Load("ProjectFileName.hhb");
//				Log.ErrorBox("Success loading the file.");
//			}
//			catch (Exception ex)
//			{
//				Log.ErrorBox("Error: " + ex.Message);
//				//throw;
//			}
			
			// Test saving project items
			TreeNode node = treeView1.Nodes[0];
			HHCompile.MakeFiles(node);
			
		}
		
		
		
	}
}
