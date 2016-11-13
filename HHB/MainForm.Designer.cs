/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-06-23
 * Time: 10:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace HHBuilder
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Table of Contents");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Popup HTML Screens");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Popup Text");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("CSS Files");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Script Files");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Image Files");
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("New Project", new System.Windows.Forms.TreeNode[] {
									treeNode1,
									treeNode2,
									treeNode3,
									treeNode4,
									treeNode5,
									treeNode6});
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cutNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteNodeAboveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteNodeBelowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteAsChildNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.label15 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageProject = new System.Windows.Forms.TabPage();
			this.cbFullTextSearch = new System.Windows.Forms.CheckBox();
			this.cbLanguage = new System.Windows.Forms.ComboBox();
			this.tbDefaultTopic = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.tbLanguage = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.bUpdateProjectSettings = new System.Windows.Forms.Button();
			this.tbTemplateUsed = new System.Windows.Forms.TextBox();
			this.tbCopyright = new System.Windows.Forms.TextBox();
			this.tbCompany = new System.Windows.Forms.TextBox();
			this.tbAuthor = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbRootFileName = new System.Windows.Forms.TextBox();
			this.tbProjectName = new System.Windows.Forms.TextBox();
			this.tabPageCSS = new System.Windows.Forms.TabPage();
			this.label18 = new System.Windows.Forms.Label();
			this.tbCssTitle = new System.Windows.Forms.TextBox();
			this.bCssSave = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.tbCssFilename = new System.Windows.Forms.TextBox();
			this.tbCssContents = new System.Windows.Forms.TextBox();
			this.tabPageScripts = new System.Windows.Forms.TabPage();
			this.label19 = new System.Windows.Forms.Label();
			this.tbScriptTitle = new System.Windows.Forms.TextBox();
			this.bScriptSave = new System.Windows.Forms.Button();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.tbScriptFilename = new System.Windows.Forms.TextBox();
			this.tbScriptContent = new System.Windows.Forms.TextBox();
			this.tabPageImages = new System.Windows.Forms.TabPage();
			this.label30 = new System.Windows.Forms.Label();
			this.tbImageSize = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.tbImageFilename = new System.Windows.Forms.TextBox();
			this.lPictureBox = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tbImageID = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.tbImageTitle = new System.Windows.Forms.TextBox();
			this.bImageSave = new System.Windows.Forms.Button();
			this.label23 = new System.Windows.Forms.Label();
			this.tbImageContent = new System.Windows.Forms.TextBox();
			this.tabPageScreen = new System.Windows.Forms.TabPage();
			this.hiIncludeTitle = new System.Windows.Forms.CheckBox();
			this.hiIncludeHeader = new System.Windows.Forms.CheckBox();
			this.hiIncludeFooter = new System.Windows.Forms.CheckBox();
			this.hiHasScreen = new System.Windows.Forms.CheckBox();
			this.dgvIndexEntries = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lvLinks = new System.Windows.Forms.ListView();
			this.lvLinksID = new System.Windows.Forms.ColumnHeader();
			this.lvLinksIndex = new System.Windows.Forms.ColumnHeader();
			this.lvLinksTitle = new System.Windows.Forms.ColumnHeader();
			this.label26 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.hiFileName = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.hiLinkDesc = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.hiID = new System.Windows.Forms.TextBox();
			this.hiLinkID = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.bUpdateScreenSettings = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.hiBody = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.hiTitle = new System.Windows.Forms.TextBox();
			this.tabPagePreview = new System.Windows.Forms.TabPage();
			this.tabPagePopupText = new System.Windows.Forms.TabPage();
			this.bUpdatePopupText = new System.Windows.Forms.Button();
			this.label34 = new System.Windows.Forms.Label();
			this.tbPopupTextText = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.tbPopupTextLinkID = new System.Windows.Forms.TextBox();
			this.tbPopupTextID = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.tbPopupTextTitle = new System.Windows.Forms.TextBox();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.helpProvider1 = new System.Windows.Forms.HelpProvider();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.contextMenuStrip1.SuspendLayout();
			this.contextMenuStrip2.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPageProject.SuspendLayout();
			this.tabPageCSS.SuspendLayout();
			this.tabPageScripts.SuspendLayout();
			this.tabPageImages.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tabPageScreen.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvIndexEntries)).BeginInit();
			this.tabPagePopupText.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.insertToolStripMenuItem,
									this.addChildToolStripMenuItem,
									this.moveUpToolStripMenuItem,
									this.moveDownToolStripMenuItem,
									this.moveRightToolStripMenuItem,
									this.moveLeftToolStripMenuItem,
									this.deleteToolStripMenuItem,
									this.cutNodeToolStripMenuItem,
									this.copyNodeToolStripMenuItem,
									this.pasteNodeAboveToolStripMenuItem,
									this.pasteNodeBelowToolStripMenuItem,
									this.pasteAsChildNodeToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(180, 268);
			// 
			// insertToolStripMenuItem
			// 
			this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
			this.insertToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.insertToolStripMenuItem.Text = "Add Sibling Node";
			this.insertToolStripMenuItem.Click += new System.EventHandler(this.InsertToolStripMenuItemClick);
			// 
			// addChildToolStripMenuItem
			// 
			this.addChildToolStripMenuItem.Name = "addChildToolStripMenuItem";
			this.addChildToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.addChildToolStripMenuItem.Text = "Add Child Node";
			this.addChildToolStripMenuItem.Click += new System.EventHandler(this.AddChildToolStripMenuItemClick);
			// 
			// moveUpToolStripMenuItem
			// 
			this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
			this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.moveUpToolStripMenuItem.Text = "Move Node Up";
			this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.MoveUpToolStripMenuItemClick);
			// 
			// moveDownToolStripMenuItem
			// 
			this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
			this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.moveDownToolStripMenuItem.Text = "Move Node Down";
			this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.MoveDownToolStripMenuItemClick);
			// 
			// moveRightToolStripMenuItem
			// 
			this.moveRightToolStripMenuItem.Name = "moveRightToolStripMenuItem";
			this.moveRightToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.moveRightToolStripMenuItem.Text = "Move Right";
			this.moveRightToolStripMenuItem.Visible = false;
			// 
			// moveLeftToolStripMenuItem
			// 
			this.moveLeftToolStripMenuItem.Name = "moveLeftToolStripMenuItem";
			this.moveLeftToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.moveLeftToolStripMenuItem.Text = "Move Left";
			this.moveLeftToolStripMenuItem.Visible = false;
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.deleteToolStripMenuItem.Text = "Delete Node";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
			// 
			// cutNodeToolStripMenuItem
			// 
			this.cutNodeToolStripMenuItem.Name = "cutNodeToolStripMenuItem";
			this.cutNodeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.cutNodeToolStripMenuItem.Text = "Cut Node";
			this.cutNodeToolStripMenuItem.Click += new System.EventHandler(this.CutNodeToolStripMenuItemClick);
			// 
			// copyNodeToolStripMenuItem
			// 
			this.copyNodeToolStripMenuItem.Name = "copyNodeToolStripMenuItem";
			this.copyNodeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.copyNodeToolStripMenuItem.Text = "Copy Node";
			this.copyNodeToolStripMenuItem.Click += new System.EventHandler(this.CopyNodeToolStripMenuItemClick);
			// 
			// pasteNodeAboveToolStripMenuItem
			// 
			this.pasteNodeAboveToolStripMenuItem.Name = "pasteNodeAboveToolStripMenuItem";
			this.pasteNodeAboveToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.pasteNodeAboveToolStripMenuItem.Text = "Paste Node Above";
			this.pasteNodeAboveToolStripMenuItem.Click += new System.EventHandler(this.PasteNodeAboveToolStripMenuItemClick);
			// 
			// pasteNodeBelowToolStripMenuItem
			// 
			this.pasteNodeBelowToolStripMenuItem.Name = "pasteNodeBelowToolStripMenuItem";
			this.pasteNodeBelowToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.pasteNodeBelowToolStripMenuItem.Text = "Paste Node Below";
			this.pasteNodeBelowToolStripMenuItem.Click += new System.EventHandler(this.PasteNodeBelowToolStripMenuItemClick);
			// 
			// pasteAsChildNodeToolStripMenuItem
			// 
			this.pasteAsChildNodeToolStripMenuItem.Name = "pasteAsChildNodeToolStripMenuItem";
			this.pasteAsChildNodeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.pasteAsChildNodeToolStripMenuItem.Text = "Paste as Child Node";
			this.pasteAsChildNodeToolStripMenuItem.Click += new System.EventHandler(this.PasteAsChildNodeToolStripMenuItemClick);
			// 
			// contextMenuStrip2
			// 
			this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.addFileToolStripMenuItem,
									this.removeFileToolStripMenuItem});
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new System.Drawing.Size(139, 48);
			// 
			// addFileToolStripMenuItem
			// 
			this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
			this.addFileToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.addFileToolStripMenuItem.Text = "Add File";
			this.addFileToolStripMenuItem.Click += new System.EventHandler(this.AddFileToolStripMenuItemClick);
			// 
			// removeFileToolStripMenuItem
			// 
			this.removeFileToolStripMenuItem.Name = "removeFileToolStripMenuItem";
			this.removeFileToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.removeFileToolStripMenuItem.Text = "Remove File";
			this.removeFileToolStripMenuItem.Click += new System.EventHandler(this.RemoveFileToolStripMenuItemClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.editToolStripMenuItem,
									this.toolsToolStripMenuItem,
									this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(979, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.newToolStripMenuItem,
									this.openToolStripMenuItem,
									this.toolStripSeparator,
									this.saveToolStripMenuItem,
									this.saveAsToolStripMenuItem,
									this.toolStripSeparator1,
									this.printToolStripMenuItem,
									this.printPreviewToolStripMenuItem,
									this.toolStripSeparator2,
									this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.NewProject);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenProject);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveProject);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
			this.toolStripSeparator1.Visible = false;
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Enabled = false;
			this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
			this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.printToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.printToolStripMenuItem.Text = "&Print";
			this.printToolStripMenuItem.Visible = false;
			// 
			// printPreviewToolStripMenuItem
			// 
			this.printPreviewToolStripMenuItem.Enabled = false;
			this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
			this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
			this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
			this.printPreviewToolStripMenuItem.Visible = false;
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.undoToolStripMenuItem,
									this.redoToolStripMenuItem,
									this.toolStripSeparator3,
									this.cutToolStripMenuItem,
									this.copyToolStripMenuItem,
									this.pasteToolStripMenuItem,
									this.toolStripSeparator4,
									this.selectAllToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.undoToolStripMenuItem.Text = "&Undo";
			this.undoToolStripMenuItem.Visible = false;
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.redoToolStripMenuItem.Text = "&Redo";
			this.redoToolStripMenuItem.Visible = false;
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
			this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.cutToolStripMenuItem.Text = "Cu&t";
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutButton);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
			this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyButton);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
			this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.pasteToolStripMenuItem.Text = "&Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteButton);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.selectAllToolStripMenuItem.Text = "Select &All";
			this.selectAllToolStripMenuItem.Visible = false;
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.customizeToolStripMenuItem,
									this.optionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// customizeToolStripMenuItem
			// 
			this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
			this.customizeToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.customizeToolStripMenuItem.Text = "&Customize";
			this.customizeToolStripMenuItem.Visible = false;
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.optionsToolStripMenuItem.Text = "&Options / Settings";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItemClick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.contentsToolStripMenuItem,
									this.indexToolStripMenuItem,
									this.searchToolStripMenuItem,
									this.toolStripSeparator5,
									this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// contentsToolStripMenuItem
			// 
			this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
			this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.contentsToolStripMenuItem.Text = "&Contents";
			// 
			// indexToolStripMenuItem
			// 
			this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
			this.indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.indexToolStripMenuItem.Text = "&Index";
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.searchToolStripMenuItem.Text = "&Search";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.newToolStripButton,
									this.openToolStripButton,
									this.saveToolStripButton,
									this.printToolStripButton,
									this.toolStripSeparator6,
									this.cutToolStripButton,
									this.copyToolStripButton,
									this.pasteToolStripButton,
									this.toolStripSeparator7,
									this.helpToolStripButton,
									this.toolStripSeparator8,
									this.toolStripButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(979, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.newToolStripButton.Text = "&New";
			this.newToolStripButton.Click += new System.EventHandler(this.NewProject);
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.openToolStripButton.Text = "&Open";
			this.openToolStripButton.Click += new System.EventHandler(this.OpenProject);
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.saveToolStripButton.Text = "&Save";
			this.saveToolStripButton.Click += new System.EventHandler(this.SaveProject);
			// 
			// printToolStripButton
			// 
			this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
			this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printToolStripButton.Name = "printToolStripButton";
			this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.printToolStripButton.Text = "&Print";
			this.printToolStripButton.Visible = false;
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// cutToolStripButton
			// 
			this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
			this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripButton.Name = "cutToolStripButton";
			this.cutToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.cutToolStripButton.Text = "C&ut";
			this.cutToolStripButton.Click += new System.EventHandler(this.CutButton);
			// 
			// copyToolStripButton
			// 
			this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
			this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripButton.Name = "copyToolStripButton";
			this.copyToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.copyToolStripButton.Text = "&Copy";
			this.copyToolStripButton.Click += new System.EventHandler(this.CopyButton);
			// 
			// pasteToolStripButton
			// 
			this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
			this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripButton.Name = "pasteToolStripButton";
			this.pasteToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.pasteToolStripButton.Text = "&Paste";
			this.pasteToolStripButton.Click += new System.EventHandler(this.PasteButton);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
			// 
			// helpToolStripButton
			// 
			this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
			this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.helpToolStripButton.Name = "helpToolStripButton";
			this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.helpToolStripButton.Text = "He&lp";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(87, 22);
			this.toolStripButton1.Text = "Debug Test";
			this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 592);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(979, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
			this.toolStripStatusLabel1.Text = ".";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 49);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
			this.splitContainer1.Size = new System.Drawing.Size(979, 543);
			this.splitContainer1.SplitterDistance = 326;
			this.splitContainer1.TabIndex = 3;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.treeView1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.AutoScroll = true;
			this.splitContainer2.Panel2.Controls.Add(this.label15);
			this.splitContainer2.Size = new System.Drawing.Size(326, 543);
			this.splitContainer2.SplitterDistance = 512;
			this.splitContainer2.TabIndex = 0;
			// 
			// treeView1
			// 
			this.treeView1.AllowDrop = true;
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			treeNode1.ContextMenuStrip = this.contextMenuStrip1;
			treeNode1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			treeNode1.Name = "Node0";
			treeNode1.Text = "Table of Contents";
			treeNode2.ContextMenuStrip = this.contextMenuStrip1;
			treeNode2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			treeNode2.Name = "Node1";
			treeNode2.Text = "Popup HTML Screens";
			treeNode3.ContextMenuStrip = this.contextMenuStrip2;
			treeNode3.Name = "Node0";
			treeNode3.Text = "Popup Text";
			treeNode4.ContextMenuStrip = this.contextMenuStrip2;
			treeNode4.ForeColor = System.Drawing.Color.Green;
			treeNode4.Name = "Node2";
			treeNode4.Text = "CSS Files";
			treeNode5.ContextMenuStrip = this.contextMenuStrip2;
			treeNode5.ForeColor = System.Drawing.Color.Purple;
			treeNode5.Name = "Node3";
			treeNode5.Text = "Script Files";
			treeNode6.ContextMenuStrip = this.contextMenuStrip2;
			treeNode6.ForeColor = System.Drawing.Color.Blue;
			treeNode6.Name = "Node5";
			treeNode6.Text = "Image Files";
			treeNode7.BackColor = System.Drawing.Color.White;
			treeNode7.ForeColor = System.Drawing.Color.Blue;
			treeNode7.Name = "Node0";
			treeNode7.Text = "New Project";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
									treeNode7});
			this.treeView1.Size = new System.Drawing.Size(326, 512);
			this.treeView1.TabIndex = 0;
			this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TreeView1ItemDrag);
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1AfterSelect);
			this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1NodeMouseClick);
			this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.TreeView1DragDrop);
			this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.TreeView1DragEnter);
			this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.TreeView1DragOver);
			// 
			// label15
			// 
			this.label15.AutoEllipsis = true;
			this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(0, 0);
			this.label15.MinimumSize = new System.Drawing.Size(0, 25);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(326, 27);
			this.label15.TabIndex = 1;
			this.label15.Text = "Right click a node to add, edit or delete";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageProject);
			this.tabControl1.Controls.Add(this.tabPageCSS);
			this.tabControl1.Controls.Add(this.tabPageScripts);
			this.tabControl1.Controls.Add(this.tabPageImages);
			this.tabControl1.Controls.Add(this.tabPageScreen);
			this.tabControl1.Controls.Add(this.tabPagePreview);
			this.tabControl1.Controls.Add(this.tabPagePopupText);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(649, 543);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPageProject
			// 
			this.tabPageProject.Controls.Add(this.cbFullTextSearch);
			this.tabPageProject.Controls.Add(this.cbLanguage);
			this.tabPageProject.Controls.Add(this.tbDefaultTopic);
			this.tabPageProject.Controls.Add(this.label28);
			this.tabPageProject.Controls.Add(this.tbLanguage);
			this.tabPageProject.Controls.Add(this.label27);
			this.tabPageProject.Controls.Add(this.bUpdateProjectSettings);
			this.tabPageProject.Controls.Add(this.tbTemplateUsed);
			this.tabPageProject.Controls.Add(this.tbCopyright);
			this.tabPageProject.Controls.Add(this.tbCompany);
			this.tabPageProject.Controls.Add(this.tbAuthor);
			this.tabPageProject.Controls.Add(this.label6);
			this.tabPageProject.Controls.Add(this.label5);
			this.tabPageProject.Controls.Add(this.label4);
			this.tabPageProject.Controls.Add(this.label3);
			this.tabPageProject.Controls.Add(this.label2);
			this.tabPageProject.Controls.Add(this.label1);
			this.tabPageProject.Controls.Add(this.tbRootFileName);
			this.tabPageProject.Controls.Add(this.tbProjectName);
			this.tabPageProject.Location = new System.Drawing.Point(4, 22);
			this.tabPageProject.Name = "tabPageProject";
			this.tabPageProject.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageProject.Size = new System.Drawing.Size(641, 517);
			this.tabPageProject.TabIndex = 0;
			this.tabPageProject.Text = "Project Settings";
			this.tabPageProject.UseVisualStyleBackColor = true;
			// 
			// cbFullTextSearch
			// 
			this.cbFullTextSearch.Location = new System.Drawing.Point(120, 256);
			this.cbFullTextSearch.Name = "cbFullTextSearch";
			this.cbFullTextSearch.Size = new System.Drawing.Size(192, 24);
			this.cbFullTextSearch.TabIndex = 20;
			this.cbFullTextSearch.Text = "Full Text Search";
			this.cbFullTextSearch.UseVisualStyleBackColor = true;
			// 
			// cbLanguage
			// 
			this.cbLanguage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbLanguage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLanguage.FormattingEnabled = true;
			this.cbLanguage.Location = new System.Drawing.Point(120, 160);
			this.cbLanguage.Name = "cbLanguage";
			this.cbLanguage.Size = new System.Drawing.Size(328, 21);
			this.cbLanguage.TabIndex = 19;
			this.cbLanguage.SelectedIndexChanged += new System.EventHandler(this.CbLanguageSelectedIndexChanged);
			// 
			// tbDefaultTopic
			// 
			this.tbDefaultTopic.Location = new System.Drawing.Point(120, 192);
			this.tbDefaultTopic.Name = "tbDefaultTopic";
			this.tbDefaultTopic.Size = new System.Drawing.Size(328, 20);
			this.tbDefaultTopic.TabIndex = 16;
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(8, 192);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(112, 16);
			this.label28.TabIndex = 15;
			this.label28.Text = "Default Topic:";
			// 
			// tbLanguage
			// 
			this.tbLanguage.Location = new System.Drawing.Point(120, 8);
			this.tbLanguage.Name = "tbLanguage";
			this.tbLanguage.ReadOnly = true;
			this.tbLanguage.Size = new System.Drawing.Size(328, 20);
			this.tbLanguage.TabIndex = 14;
			this.tbLanguage.Visible = false;
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(8, 160);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(112, 16);
			this.label27.TabIndex = 13;
			this.label27.Text = "Language:";
			// 
			// bUpdateProjectSettings
			// 
			this.bUpdateProjectSettings.Location = new System.Drawing.Point(552, 480);
			this.bUpdateProjectSettings.Name = "bUpdateProjectSettings";
			this.bUpdateProjectSettings.Size = new System.Drawing.Size(75, 23);
			this.bUpdateProjectSettings.TabIndex = 12;
			this.bUpdateProjectSettings.Text = "Update";
			this.bUpdateProjectSettings.UseVisualStyleBackColor = true;
			this.bUpdateProjectSettings.Click += new System.EventHandler(this.BUpdateProjectSettingsClick);
			// 
			// tbTemplateUsed
			// 
			this.tbTemplateUsed.Location = new System.Drawing.Point(120, 224);
			this.tbTemplateUsed.Name = "tbTemplateUsed";
			this.tbTemplateUsed.Size = new System.Drawing.Size(328, 20);
			this.tbTemplateUsed.TabIndex = 11;
			// 
			// tbCopyright
			// 
			this.tbCopyright.Location = new System.Drawing.Point(120, 128);
			this.tbCopyright.Name = "tbCopyright";
			this.tbCopyright.Size = new System.Drawing.Size(328, 20);
			this.tbCopyright.TabIndex = 10;
			// 
			// tbCompany
			// 
			this.tbCompany.Location = new System.Drawing.Point(120, 96);
			this.tbCompany.Name = "tbCompany";
			this.tbCompany.Size = new System.Drawing.Size(328, 20);
			this.tbCompany.TabIndex = 9;
			// 
			// tbAuthor
			// 
			this.tbAuthor.Location = new System.Drawing.Point(120, 64);
			this.tbAuthor.Name = "tbAuthor";
			this.tbAuthor.Size = new System.Drawing.Size(328, 20);
			this.tbAuthor.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 224);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 16);
			this.label6.TabIndex = 7;
			this.label6.Text = "Template Used:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 128);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "Copyright:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "Company:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Author:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 288);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Root File Name:";
			this.label2.Visible = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Project Name:";
			// 
			// tbRootFileName
			// 
			this.tbRootFileName.Location = new System.Drawing.Point(120, 288);
			this.tbRootFileName.Name = "tbRootFileName";
			this.tbRootFileName.Size = new System.Drawing.Size(328, 20);
			this.tbRootFileName.TabIndex = 1;
			this.tbRootFileName.Visible = false;
			// 
			// tbProjectName
			// 
			this.tbProjectName.Location = new System.Drawing.Point(120, 32);
			this.tbProjectName.Name = "tbProjectName";
			this.tbProjectName.Size = new System.Drawing.Size(328, 20);
			this.tbProjectName.TabIndex = 0;
			// 
			// tabPageCSS
			// 
			this.tabPageCSS.Controls.Add(this.label18);
			this.tabPageCSS.Controls.Add(this.tbCssTitle);
			this.tabPageCSS.Controls.Add(this.bCssSave);
			this.tabPageCSS.Controls.Add(this.label17);
			this.tabPageCSS.Controls.Add(this.label16);
			this.tabPageCSS.Controls.Add(this.tbCssFilename);
			this.tabPageCSS.Controls.Add(this.tbCssContents);
			this.tabPageCSS.Location = new System.Drawing.Point(4, 22);
			this.tabPageCSS.Name = "tabPageCSS";
			this.tabPageCSS.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageCSS.Size = new System.Drawing.Size(641, 517);
			this.tabPageCSS.TabIndex = 3;
			this.tabPageCSS.Text = "Additional CSS";
			this.tabPageCSS.UseVisualStyleBackColor = true;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(8, 8);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(64, 24);
			this.label18.TabIndex = 9;
			this.label18.Text = "Title:";
			// 
			// tbCssTitle
			// 
			this.tbCssTitle.Location = new System.Drawing.Point(72, 8);
			this.tbCssTitle.Name = "tbCssTitle";
			this.tbCssTitle.Size = new System.Drawing.Size(312, 20);
			this.tbCssTitle.TabIndex = 8;
			// 
			// bCssSave
			// 
			this.bCssSave.Location = new System.Drawing.Point(528, 40);
			this.bCssSave.Name = "bCssSave";
			this.bCssSave.Size = new System.Drawing.Size(104, 23);
			this.bCssSave.TabIndex = 7;
			this.bCssSave.Text = "Update";
			this.bCssSave.UseVisualStyleBackColor = true;
			this.bCssSave.Click += new System.EventHandler(this.BCssSaveClick);
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(8, 56);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(64, 16);
			this.label17.TabIndex = 5;
			this.label17.Text = "Contents:";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(8, 32);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(64, 24);
			this.label16.TabIndex = 4;
			this.label16.Text = "File Name:";
			// 
			// tbCssFilename
			// 
			this.tbCssFilename.Location = new System.Drawing.Point(72, 32);
			this.tbCssFilename.Name = "tbCssFilename";
			this.tbCssFilename.Size = new System.Drawing.Size(312, 20);
			this.tbCssFilename.TabIndex = 2;
			// 
			// tbCssContents
			// 
			this.tbCssContents.AcceptsReturn = true;
			this.tbCssContents.AcceptsTab = true;
			this.tbCssContents.Location = new System.Drawing.Point(8, 72);
			this.tbCssContents.Multiline = true;
			this.tbCssContents.Name = "tbCssContents";
			this.tbCssContents.Size = new System.Drawing.Size(624, 432);
			this.tbCssContents.TabIndex = 1;
			// 
			// tabPageScripts
			// 
			this.tabPageScripts.Controls.Add(this.label19);
			this.tabPageScripts.Controls.Add(this.tbScriptTitle);
			this.tabPageScripts.Controls.Add(this.bScriptSave);
			this.tabPageScripts.Controls.Add(this.label20);
			this.tabPageScripts.Controls.Add(this.label21);
			this.tabPageScripts.Controls.Add(this.tbScriptFilename);
			this.tabPageScripts.Controls.Add(this.tbScriptContent);
			this.tabPageScripts.Location = new System.Drawing.Point(4, 22);
			this.tabPageScripts.Name = "tabPageScripts";
			this.tabPageScripts.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageScripts.Size = new System.Drawing.Size(641, 517);
			this.tabPageScripts.TabIndex = 4;
			this.tabPageScripts.Text = "Scripts";
			this.tabPageScripts.UseVisualStyleBackColor = true;
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(8, 8);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(64, 24);
			this.label19.TabIndex = 16;
			this.label19.Text = "Title:";
			// 
			// tbScriptTitle
			// 
			this.tbScriptTitle.Location = new System.Drawing.Point(72, 8);
			this.tbScriptTitle.Name = "tbScriptTitle";
			this.tbScriptTitle.Size = new System.Drawing.Size(312, 20);
			this.tbScriptTitle.TabIndex = 15;
			// 
			// bScriptSave
			// 
			this.bScriptSave.Location = new System.Drawing.Point(528, 40);
			this.bScriptSave.Name = "bScriptSave";
			this.bScriptSave.Size = new System.Drawing.Size(104, 23);
			this.bScriptSave.TabIndex = 14;
			this.bScriptSave.Text = "Update";
			this.bScriptSave.UseVisualStyleBackColor = true;
			this.bScriptSave.Click += new System.EventHandler(this.BScriptSaveClick);
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(8, 56);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(64, 16);
			this.label20.TabIndex = 13;
			this.label20.Text = "Contents:";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(8, 32);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(64, 24);
			this.label21.TabIndex = 12;
			this.label21.Text = "File Name:";
			// 
			// tbScriptFilename
			// 
			this.tbScriptFilename.Location = new System.Drawing.Point(72, 32);
			this.tbScriptFilename.Name = "tbScriptFilename";
			this.tbScriptFilename.Size = new System.Drawing.Size(312, 20);
			this.tbScriptFilename.TabIndex = 11;
			// 
			// tbScriptContent
			// 
			this.tbScriptContent.AcceptsReturn = true;
			this.tbScriptContent.AcceptsTab = true;
			this.tbScriptContent.Location = new System.Drawing.Point(8, 72);
			this.tbScriptContent.Multiline = true;
			this.tbScriptContent.Name = "tbScriptContent";
			this.tbScriptContent.Size = new System.Drawing.Size(624, 432);
			this.tbScriptContent.TabIndex = 10;
			// 
			// tabPageImages
			// 
			this.tabPageImages.Controls.Add(this.label30);
			this.tabPageImages.Controls.Add(this.tbImageSize);
			this.tabPageImages.Controls.Add(this.label24);
			this.tabPageImages.Controls.Add(this.tbImageFilename);
			this.tabPageImages.Controls.Add(this.lPictureBox);
			this.tabPageImages.Controls.Add(this.pictureBox1);
			this.tabPageImages.Controls.Add(this.tbImageID);
			this.tabPageImages.Controls.Add(this.label29);
			this.tabPageImages.Controls.Add(this.label22);
			this.tabPageImages.Controls.Add(this.tbImageTitle);
			this.tabPageImages.Controls.Add(this.bImageSave);
			this.tabPageImages.Controls.Add(this.label23);
			this.tabPageImages.Controls.Add(this.tbImageContent);
			this.tabPageImages.Location = new System.Drawing.Point(4, 22);
			this.tabPageImages.Name = "tabPageImages";
			this.tabPageImages.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageImages.Size = new System.Drawing.Size(641, 517);
			this.tabPageImages.TabIndex = 5;
			this.tabPageImages.Text = "Images";
			this.tabPageImages.UseVisualStyleBackColor = true;
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(8, 32);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(64, 24);
			this.label30.TabIndex = 26;
			this.label30.Text = "Image Size:";
			// 
			// tbImageSize
			// 
			this.tbImageSize.AllowDrop = true;
			this.tbImageSize.Location = new System.Drawing.Point(72, 32);
			this.tbImageSize.Name = "tbImageSize";
			this.tbImageSize.ReadOnly = true;
			this.tbImageSize.Size = new System.Drawing.Size(128, 20);
			this.tbImageSize.TabIndex = 25;
			this.tbImageSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(112, 128);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(64, 24);
			this.label24.TabIndex = 12;
			this.label24.Text = "File Name:";
			this.label24.Visible = false;
			// 
			// tbImageFilename
			// 
			this.tbImageFilename.AllowDrop = true;
			this.tbImageFilename.Location = new System.Drawing.Point(176, 128);
			this.tbImageFilename.Name = "tbImageFilename";
			this.tbImageFilename.Size = new System.Drawing.Size(368, 20);
			this.tbImageFilename.TabIndex = 11;
			this.tbImageFilename.Visible = false;
			// 
			// lPictureBox
			// 
			this.lPictureBox.AllowDrop = true;
			this.lPictureBox.BackColor = System.Drawing.SystemColors.Window;
			this.lPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lPictureBox.Location = new System.Drawing.Point(336, 40);
			this.lPictureBox.Name = "lPictureBox";
			this.lPictureBox.Size = new System.Drawing.Size(104, 24);
			this.lPictureBox.TabIndex = 24;
			this.lPictureBox.Text = "Drop File Here";
			this.lPictureBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lPictureBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.LPictureBoxDragDrop);
			this.lPictureBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.LPictureBoxDragEnter);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(8, 72);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(624, 432);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 23;
			this.pictureBox1.TabStop = false;
			// 
			// tbImageID
			// 
			this.tbImageID.Enabled = false;
			this.tbImageID.Location = new System.Drawing.Point(512, 8);
			this.tbImageID.Name = "tbImageID";
			this.tbImageID.Size = new System.Drawing.Size(120, 20);
			this.tbImageID.TabIndex = 22;
			this.tbImageID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(480, 8);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(28, 16);
			this.label29.TabIndex = 21;
			this.label29.Text = "ID:";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(8, 8);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(64, 24);
			this.label22.TabIndex = 16;
			this.label22.Text = "Title:";
			// 
			// tbImageTitle
			// 
			this.tbImageTitle.Location = new System.Drawing.Point(72, 8);
			this.tbImageTitle.Name = "tbImageTitle";
			this.tbImageTitle.Size = new System.Drawing.Size(368, 20);
			this.tbImageTitle.TabIndex = 15;
			// 
			// bImageSave
			// 
			this.bImageSave.Location = new System.Drawing.Point(528, 40);
			this.bImageSave.Name = "bImageSave";
			this.bImageSave.Size = new System.Drawing.Size(104, 23);
			this.bImageSave.TabIndex = 14;
			this.bImageSave.Text = "Update";
			this.bImageSave.UseVisualStyleBackColor = true;
			this.bImageSave.Click += new System.EventHandler(this.BImageSaveClick);
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(8, 56);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(64, 16);
			this.label23.TabIndex = 13;
			this.label23.Text = "Contents:";
			// 
			// tbImageContent
			// 
			this.tbImageContent.AcceptsReturn = true;
			this.tbImageContent.AcceptsTab = true;
			this.tbImageContent.Location = new System.Drawing.Point(8, 72);
			this.tbImageContent.Multiline = true;
			this.tbImageContent.Name = "tbImageContent";
			this.tbImageContent.ReadOnly = true;
			this.tbImageContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbImageContent.Size = new System.Drawing.Size(624, 136);
			this.tbImageContent.TabIndex = 10;
			this.tbImageContent.Visible = false;
			// 
			// tabPageScreen
			// 
			this.tabPageScreen.Controls.Add(this.hiIncludeTitle);
			this.tabPageScreen.Controls.Add(this.hiIncludeHeader);
			this.tabPageScreen.Controls.Add(this.hiIncludeFooter);
			this.tabPageScreen.Controls.Add(this.hiHasScreen);
			this.tabPageScreen.Controls.Add(this.dgvIndexEntries);
			this.tabPageScreen.Controls.Add(this.lvLinks);
			this.tabPageScreen.Controls.Add(this.label26);
			this.tabPageScreen.Controls.Add(this.label8);
			this.tabPageScreen.Controls.Add(this.hiFileName);
			this.tabPageScreen.Controls.Add(this.label12);
			this.tabPageScreen.Controls.Add(this.hiLinkDesc);
			this.tabPageScreen.Controls.Add(this.label11);
			this.tabPageScreen.Controls.Add(this.textBox4);
			this.tabPageScreen.Controls.Add(this.label10);
			this.tabPageScreen.Controls.Add(this.textBox3);
			this.tabPageScreen.Controls.Add(this.label25);
			this.tabPageScreen.Controls.Add(this.hiID);
			this.tabPageScreen.Controls.Add(this.hiLinkID);
			this.tabPageScreen.Controls.Add(this.label14);
			this.tabPageScreen.Controls.Add(this.bUpdateScreenSettings);
			this.tabPageScreen.Controls.Add(this.label13);
			this.tabPageScreen.Controls.Add(this.hiBody);
			this.tabPageScreen.Controls.Add(this.label9);
			this.tabPageScreen.Controls.Add(this.label7);
			this.tabPageScreen.Controls.Add(this.hiTitle);
			this.tabPageScreen.Location = new System.Drawing.Point(4, 22);
			this.tabPageScreen.Name = "tabPageScreen";
			this.tabPageScreen.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageScreen.Size = new System.Drawing.Size(641, 517);
			this.tabPageScreen.TabIndex = 1;
			this.tabPageScreen.Text = "Page Settings";
			this.tabPageScreen.UseVisualStyleBackColor = true;
			// 
			// hiIncludeTitle
			// 
			this.hiIncludeTitle.Location = new System.Drawing.Point(296, 176);
			this.hiIncludeTitle.Name = "hiIncludeTitle";
			this.hiIncludeTitle.Size = new System.Drawing.Size(88, 24);
			this.hiIncludeTitle.TabIndex = 29;
			this.hiIncludeTitle.Text = "Include Title";
			this.hiIncludeTitle.UseVisualStyleBackColor = true;
			// 
			// hiIncludeHeader
			// 
			this.hiIncludeHeader.Location = new System.Drawing.Point(408, 176);
			this.hiIncludeHeader.Name = "hiIncludeHeader";
			this.hiIncludeHeader.Size = new System.Drawing.Size(104, 24);
			this.hiIncludeHeader.TabIndex = 28;
			this.hiIncludeHeader.Text = "Include Header";
			this.hiIncludeHeader.UseVisualStyleBackColor = true;
			// 
			// hiIncludeFooter
			// 
			this.hiIncludeFooter.Location = new System.Drawing.Point(528, 176);
			this.hiIncludeFooter.Name = "hiIncludeFooter";
			this.hiIncludeFooter.Size = new System.Drawing.Size(104, 24);
			this.hiIncludeFooter.TabIndex = 27;
			this.hiIncludeFooter.Text = "Include Footer";
			this.hiIncludeFooter.UseVisualStyleBackColor = true;
			// 
			// hiHasScreen
			// 
			this.hiHasScreen.Location = new System.Drawing.Point(112, 176);
			this.hiHasScreen.Name = "hiHasScreen";
			this.hiHasScreen.Size = new System.Drawing.Size(96, 24);
			this.hiHasScreen.TabIndex = 26;
			this.hiHasScreen.Text = "Has Screen";
			this.hiHasScreen.UseVisualStyleBackColor = true;
			// 
			// dgvIndexEntries
			// 
			this.dgvIndexEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvIndexEntries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Column1});
			this.dgvIndexEntries.Location = new System.Drawing.Point(8, 80);
			this.dgvIndexEntries.Name = "dgvIndexEntries";
			this.dgvIndexEntries.Size = new System.Drawing.Size(280, 96);
			this.dgvIndexEntries.TabIndex = 25;
			this.dgvIndexEntries.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DgvAddLineNumbers);
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "IndexLine";
			this.Column1.HeaderText = "Index Entry";
			this.Column1.Name = "Column1";
			this.Column1.Width = 200;
			// 
			// lvLinks
			// 
			this.lvLinks.CheckBoxes = true;
			this.lvLinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.lvLinksID,
									this.lvLinksIndex,
									this.lvLinksTitle});
			this.lvLinks.GridLines = true;
			this.lvLinks.Location = new System.Drawing.Point(296, 80);
			this.lvLinks.Name = "lvLinks";
			this.lvLinks.Size = new System.Drawing.Size(336, 96);
			this.lvLinks.TabIndex = 24;
			this.lvLinks.UseCompatibleStateImageBehavior = false;
			this.lvLinks.View = System.Windows.Forms.View.Details;
			// 
			// lvLinksID
			// 
			this.lvLinksID.Text = "";
			this.lvLinksID.Width = 20;
			// 
			// lvLinksIndex
			// 
			this.lvLinksIndex.Text = "ToC Index";
			this.lvLinksIndex.Width = 100;
			// 
			// lvLinksTitle
			// 
			this.lvLinksTitle.Text = "Title";
			this.lvLinksTitle.Width = 200;
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(288, 64);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(50, 16);
			this.label26.TabIndex = 22;
			this.label26.Text = "Link To:";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(168, 256);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(112, 16);
			this.label8.TabIndex = 6;
			this.label8.Text = "HTML File Name:";
			this.label8.Visible = false;
			// 
			// hiFileName
			// 
			this.hiFileName.Location = new System.Drawing.Point(280, 256);
			this.hiFileName.Name = "hiFileName";
			this.hiFileName.Size = new System.Drawing.Size(328, 20);
			this.hiFileName.TabIndex = 5;
			this.hiFileName.Visible = false;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 40);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(112, 16);
			this.label12.TabIndex = 14;
			this.label12.Text = "Link Description:";
			// 
			// hiLinkDesc
			// 
			this.hiLinkDesc.Location = new System.Drawing.Point(120, 40);
			this.hiLinkDesc.Name = "hiLinkDesc";
			this.hiLinkDesc.Size = new System.Drawing.Size(328, 20);
			this.hiLinkDesc.TabIndex = 13;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(168, 304);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(112, 16);
			this.label11.TabIndex = 12;
			this.label11.Text = "Project Name:";
			this.label11.Visible = false;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(280, 304);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(328, 20);
			this.textBox4.TabIndex = 11;
			this.textBox4.Visible = false;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(168, 280);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(112, 16);
			this.label10.TabIndex = 10;
			this.label10.Text = "Project Name:";
			this.label10.Visible = false;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(280, 280);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(328, 20);
			this.textBox3.TabIndex = 9;
			this.textBox3.Visible = false;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(456, 40);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(50, 16);
			this.label25.TabIndex = 21;
			this.label25.Text = "Link ID:";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// hiID
			// 
			this.hiID.Enabled = false;
			this.hiID.Location = new System.Drawing.Point(512, 16);
			this.hiID.Name = "hiID";
			this.hiID.Size = new System.Drawing.Size(120, 20);
			this.hiID.TabIndex = 20;
			this.hiID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// hiLinkID
			// 
			this.hiLinkID.Location = new System.Drawing.Point(512, 40);
			this.hiLinkID.Name = "hiLinkID";
			this.hiLinkID.Size = new System.Drawing.Size(120, 20);
			this.hiLinkID.TabIndex = 19;
			this.hiLinkID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(480, 16);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(28, 16);
			this.label14.TabIndex = 18;
			this.label14.Text = "ID:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// bUpdateScreenSettings
			// 
			this.bUpdateScreenSettings.Location = new System.Drawing.Point(560, 480);
			this.bUpdateScreenSettings.Name = "bUpdateScreenSettings";
			this.bUpdateScreenSettings.Size = new System.Drawing.Size(75, 23);
			this.bUpdateScreenSettings.TabIndex = 17;
			this.bUpdateScreenSettings.Text = "Update";
			this.bUpdateScreenSettings.UseVisualStyleBackColor = true;
			this.bUpdateScreenSettings.Click += new System.EventHandler(this.BUpdateScreenSettingsClick);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 184);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(112, 16);
			this.label13.TabIndex = 16;
			this.label13.Text = "Body Contents:";
			// 
			// hiBody
			// 
			this.hiBody.AcceptsReturn = true;
			this.hiBody.AcceptsTab = true;
			this.hiBody.Location = new System.Drawing.Point(8, 200);
			this.hiBody.Multiline = true;
			this.hiBody.Name = "hiBody";
			this.hiBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.hiBody.Size = new System.Drawing.Size(624, 272);
			this.hiBody.TabIndex = 15;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 64);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(112, 16);
			this.label9.TabIndex = 8;
			this.label9.Text = "Index Entries:";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(112, 16);
			this.label7.TabIndex = 4;
			this.label7.Text = "Help Item Title:";
			// 
			// hiTitle
			// 
			this.hiTitle.Location = new System.Drawing.Point(120, 16);
			this.hiTitle.Name = "hiTitle";
			this.hiTitle.Size = new System.Drawing.Size(328, 20);
			this.hiTitle.TabIndex = 3;
			// 
			// tabPagePreview
			// 
			this.tabPagePreview.Location = new System.Drawing.Point(4, 22);
			this.tabPagePreview.Name = "tabPagePreview";
			this.tabPagePreview.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePreview.Size = new System.Drawing.Size(641, 517);
			this.tabPagePreview.TabIndex = 2;
			this.tabPagePreview.Text = "Preview";
			this.tabPagePreview.UseVisualStyleBackColor = true;
			// 
			// tabPagePopupText
			// 
			this.tabPagePopupText.Controls.Add(this.bUpdatePopupText);
			this.tabPagePopupText.Controls.Add(this.label34);
			this.tabPagePopupText.Controls.Add(this.tbPopupTextText);
			this.tabPagePopupText.Controls.Add(this.label33);
			this.tabPagePopupText.Controls.Add(this.tbPopupTextLinkID);
			this.tabPagePopupText.Controls.Add(this.tbPopupTextID);
			this.tabPagePopupText.Controls.Add(this.label31);
			this.tabPagePopupText.Controls.Add(this.label32);
			this.tabPagePopupText.Controls.Add(this.tbPopupTextTitle);
			this.tabPagePopupText.Location = new System.Drawing.Point(4, 22);
			this.tabPagePopupText.Name = "tabPagePopupText";
			this.tabPagePopupText.Size = new System.Drawing.Size(641, 517);
			this.tabPagePopupText.TabIndex = 6;
			this.tabPagePopupText.Text = "Popup Text";
			this.tabPagePopupText.UseVisualStyleBackColor = true;
			// 
			// bUpdatePopupText
			// 
			this.bUpdatePopupText.Location = new System.Drawing.Point(560, 200);
			this.bUpdatePopupText.Name = "bUpdatePopupText";
			this.bUpdatePopupText.Size = new System.Drawing.Size(75, 23);
			this.bUpdatePopupText.TabIndex = 29;
			this.bUpdatePopupText.Text = "Update";
			this.bUpdatePopupText.UseVisualStyleBackColor = true;
			this.bUpdatePopupText.Click += new System.EventHandler(this.BUpdatePopupTextClick);
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(8, 32);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(112, 16);
			this.label34.TabIndex = 28;
			this.label34.Text = "Help Item Text:";
			// 
			// tbPopupTextText
			// 
			this.tbPopupTextText.AcceptsReturn = true;
			this.tbPopupTextText.Location = new System.Drawing.Point(120, 32);
			this.tbPopupTextText.Multiline = true;
			this.tbPopupTextText.Name = "tbPopupTextText";
			this.tbPopupTextText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbPopupTextText.Size = new System.Drawing.Size(328, 184);
			this.tbPopupTextText.TabIndex = 27;
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(456, 32);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(50, 16);
			this.label33.TabIndex = 26;
			this.label33.Text = "Link ID:";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbPopupTextLinkID
			// 
			this.tbPopupTextLinkID.Location = new System.Drawing.Point(512, 32);
			this.tbPopupTextLinkID.Name = "tbPopupTextLinkID";
			this.tbPopupTextLinkID.Size = new System.Drawing.Size(120, 20);
			this.tbPopupTextLinkID.TabIndex = 25;
			this.tbPopupTextLinkID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbPopupTextID
			// 
			this.tbPopupTextID.Enabled = false;
			this.tbPopupTextID.Location = new System.Drawing.Point(512, 8);
			this.tbPopupTextID.Name = "tbPopupTextID";
			this.tbPopupTextID.Size = new System.Drawing.Size(120, 20);
			this.tbPopupTextID.TabIndex = 24;
			this.tbPopupTextID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(480, 8);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(28, 16);
			this.label31.TabIndex = 23;
			this.label31.Text = "ID:";
			this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(8, 8);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(112, 16);
			this.label32.TabIndex = 22;
			this.label32.Text = "Help Item Title:";
			// 
			// tbPopupTextTitle
			// 
			this.tbPopupTextTitle.Location = new System.Drawing.Point(120, 8);
			this.tbPopupTextTitle.Name = "tbPopupTextTitle";
			this.tbPopupTextTitle.Size = new System.Drawing.Size(328, 20);
			this.tbPopupTextTitle.TabIndex = 21;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(979, 614);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "HHBuilder";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.contextMenuStrip1.ResumeLayout(false);
			this.contextMenuStrip2.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPageProject.ResumeLayout(false);
			this.tabPageProject.PerformLayout();
			this.tabPageCSS.ResumeLayout(false);
			this.tabPageCSS.PerformLayout();
			this.tabPageScripts.ResumeLayout(false);
			this.tabPageScripts.PerformLayout();
			this.tabPageImages.ResumeLayout(false);
			this.tabPageImages.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tabPageScreen.ResumeLayout(false);
			this.tabPageScreen.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvIndexEntries)).EndInit();
			this.tabPagePopupText.ResumeLayout(false);
			this.tabPagePopupText.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.TextBox tbPopupTextTitle;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.TextBox tbPopupTextID;
		private System.Windows.Forms.TextBox tbPopupTextLinkID;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.TextBox tbPopupTextText;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Button bUpdatePopupText;
		private System.Windows.Forms.TabPage tabPagePopupText;
		private System.Windows.Forms.CheckBox hiIncludeFooter;
		private System.Windows.Forms.CheckBox hiIncludeHeader;
		private System.Windows.Forms.CheckBox hiIncludeTitle;
		private System.Windows.Forms.TextBox tbImageSize;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label lPictureBox;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TextBox tbImageID;
		private System.Windows.Forms.CheckBox cbFullTextSearch;
		private System.Windows.Forms.CheckBox hiHasScreen;
		private System.Windows.Forms.ToolStripButton helpToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripButton pasteToolStripButton;
		private System.Windows.Forms.ToolStripButton copyToolStripButton;
		private System.Windows.Forms.ToolStripButton cutToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton printToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ComboBox cbLanguage;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox tbLanguage;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox tbDefaultTopic;
		private System.Windows.Forms.HelpProvider helpProvider1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridView dgvIndexEntries;
		private System.Windows.Forms.ColumnHeader lvLinksIndex;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.ColumnHeader lvLinksTitle;
		private System.Windows.Forms.ColumnHeader lvLinksID;
		private System.Windows.Forms.ListView lvLinks;
		private System.Windows.Forms.TextBox hiID;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox tbImageContent;
		private System.Windows.Forms.TextBox tbImageFilename;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Button bImageSave;
		private System.Windows.Forms.TextBox tbImageTitle;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox tbScriptContent;
		private System.Windows.Forms.TextBox tbScriptFilename;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Button bScriptSave;
		private System.Windows.Forms.TextBox tbScriptTitle;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox tbCssTitle;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ToolStripMenuItem removeFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button bCssSave;
		private System.Windows.Forms.TextBox tbCssFilename;
		private System.Windows.Forms.TextBox tbCssContents;
		private System.Windows.Forms.TabPage tabPageImages;
		private System.Windows.Forms.TabPage tabPageScripts;
		private System.Windows.Forms.TabPage tabPageCSS;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ToolStripMenuItem pasteAsChildNodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteNodeBelowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteNodeAboveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyNodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cutNodeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox hiLinkID;
		private System.Windows.Forms.Button bUpdateScreenSettings;
		private System.Windows.Forms.Button bUpdateProjectSettings;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moveLeftToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moveRightToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addChildToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
		private System.Windows.Forms.TextBox hiTitle;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox hiFileName;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox hiLinkDesc;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox hiBody;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TabPage tabPagePreview;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.TextBox tbProjectName;
		private System.Windows.Forms.TextBox tbRootFileName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbAuthor;
		private System.Windows.Forms.TextBox tbCompany;
		private System.Windows.Forms.TextBox tbCopyright;
		private System.Windows.Forms.TextBox tbTemplateUsed;
		private System.Windows.Forms.TabPage tabPageScreen;
		private System.Windows.Forms.TabPage tabPageProject;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
	}
}
