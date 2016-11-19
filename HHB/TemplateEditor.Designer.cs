/*
 * Created by SharpDevelop.
 * User: bob
 * Date: 2016-11-19
 * Time: 10:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace HHBuilder
{
	partial class TemplateEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateEditor));
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
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.bSave = new System.Windows.Forms.Button();
			this.bExit = new System.Windows.Forms.Button();
			this.tbTemplateWebsite = new System.Windows.Forms.TextBox();
			this.label43 = new System.Windows.Forms.Label();
			this.tbTemplateEmail = new System.Windows.Forms.TextBox();
			this.label42 = new System.Windows.Forms.Label();
			this.tbTemplateContact = new System.Windows.Forms.TextBox();
			this.label41 = new System.Windows.Forms.Label();
			this.tbTemplateCompany = new System.Windows.Forms.TextBox();
			this.label40 = new System.Windows.Forms.Label();
			this.tbTemplateAuthor = new System.Windows.Forms.TextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.label46 = new System.Windows.Forms.Label();
			this.tbTemplateLicense = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.tbTemplateDate = new System.Windows.Forms.TextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.tbTemplateDescription = new System.Windows.Forms.TextBox();
			this.label39 = new System.Windows.Forms.Label();
			this.tbTemplateVersion = new System.Windows.Forms.TextBox();
			this.tbTemplateTitle = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.bReset = new System.Windows.Forms.Button();
			this.tbHtmlDirectory = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbREADME = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.bBrowseForWorkingDirectory = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
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
			this.menuStrip1.Size = new System.Drawing.Size(781, 24);
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
			this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItemClick);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
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
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
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
			// 
			// printToolStripMenuItem
			// 
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
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.undoToolStripMenuItem.Text = "&Undo";
			this.undoToolStripMenuItem.Visible = false;
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.redoToolStripMenuItem.Text = "&Redo";
			this.redoToolStripMenuItem.Visible = false;
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
			this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.cutToolStripMenuItem.Text = "Cu&t";
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutButton);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
			this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyButton);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
			this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.pasteToolStripMenuItem.Text = "&Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteButton);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.selectAllToolStripMenuItem.Text = "Select &All";
			this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllButton);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.customizeToolStripMenuItem,
									this.optionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			this.toolsToolStripMenuItem.Visible = false;
			// 
			// customizeToolStripMenuItem
			// 
			this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
			this.customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
			this.customizeToolStripMenuItem.Text = "&Customize";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
			this.optionsToolStripMenuItem.Text = "&Options";
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
									this.helpToolStripButton});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(781, 25);
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
			this.newToolStripButton.Click += new System.EventHandler(this.NewToolStripButtonClick);
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.openToolStripButton.Text = "&Open";
			this.openToolStripButton.Click += new System.EventHandler(this.OpenToolStripButtonClick);
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.saveToolStripButton.Text = "&Save";
			this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButtonClick);
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
			this.toolStripSeparator6.Visible = false;
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
			this.toolStripSeparator7.Visible = false;
			// 
			// helpToolStripButton
			// 
			this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
			this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.helpToolStripButton.Name = "helpToolStripButton";
			this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.helpToolStripButton.Text = "He&lp";
			this.helpToolStripButton.Visible = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// bSave
			// 
			this.bSave.Location = new System.Drawing.Point(616, 320);
			this.bSave.Name = "bSave";
			this.bSave.Size = new System.Drawing.Size(75, 23);
			this.bSave.TabIndex = 83;
			this.bSave.Text = "Save";
			this.bSave.UseVisualStyleBackColor = true;
			this.bSave.Click += new System.EventHandler(this.BSaveClick);
			// 
			// bExit
			// 
			this.bExit.Location = new System.Drawing.Point(696, 320);
			this.bExit.Name = "bExit";
			this.bExit.Size = new System.Drawing.Size(75, 23);
			this.bExit.TabIndex = 82;
			this.bExit.Text = "Exit";
			this.bExit.UseVisualStyleBackColor = true;
			this.bExit.Click += new System.EventHandler(this.BExitClick);
			// 
			// tbTemplateWebsite
			// 
			this.tbTemplateWebsite.Location = new System.Drawing.Point(128, 296);
			this.tbTemplateWebsite.Name = "tbTemplateWebsite";
			this.tbTemplateWebsite.Size = new System.Drawing.Size(232, 20);
			this.tbTemplateWebsite.TabIndex = 81;
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(8, 296);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(112, 16);
			this.label43.TabIndex = 80;
			this.label43.Text = "Website:";
			this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbTemplateEmail
			// 
			this.tbTemplateEmail.Location = new System.Drawing.Point(128, 272);
			this.tbTemplateEmail.Name = "tbTemplateEmail";
			this.tbTemplateEmail.Size = new System.Drawing.Size(232, 20);
			this.tbTemplateEmail.TabIndex = 79;
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(8, 272);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(112, 16);
			this.label42.TabIndex = 78;
			this.label42.Text = "Email:";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbTemplateContact
			// 
			this.tbTemplateContact.Location = new System.Drawing.Point(128, 248);
			this.tbTemplateContact.Name = "tbTemplateContact";
			this.tbTemplateContact.Size = new System.Drawing.Size(232, 20);
			this.tbTemplateContact.TabIndex = 77;
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(8, 248);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(112, 16);
			this.label41.TabIndex = 76;
			this.label41.Text = "Contact:";
			this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbTemplateCompany
			// 
			this.tbTemplateCompany.Location = new System.Drawing.Point(128, 224);
			this.tbTemplateCompany.Name = "tbTemplateCompany";
			this.tbTemplateCompany.Size = new System.Drawing.Size(232, 20);
			this.tbTemplateCompany.TabIndex = 75;
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(8, 224);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(112, 16);
			this.label40.TabIndex = 74;
			this.label40.Text = "Company:";
			this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbTemplateAuthor
			// 
			this.tbTemplateAuthor.Location = new System.Drawing.Point(128, 200);
			this.tbTemplateAuthor.Name = "tbTemplateAuthor";
			this.tbTemplateAuthor.Size = new System.Drawing.Size(232, 20);
			this.tbTemplateAuthor.TabIndex = 73;
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(8, 200);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(112, 16);
			this.label37.TabIndex = 72;
			this.label37.Text = "Author:";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label46
			// 
			this.label46.Location = new System.Drawing.Point(192, 80);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(40, 16);
			this.label46.TabIndex = 71;
			this.label46.Text = "Date:";
			this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbTemplateLicense
			// 
			this.tbTemplateLicense.Location = new System.Drawing.Point(128, 176);
			this.tbTemplateLicense.Name = "tbTemplateLicense";
			this.tbTemplateLicense.Size = new System.Drawing.Size(232, 20);
			this.tbTemplateLicense.TabIndex = 69;
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(8, 176);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(112, 16);
			this.label38.TabIndex = 68;
			this.label38.Text = "License Type:";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbTemplateDate
			// 
			this.tbTemplateDate.Location = new System.Drawing.Point(240, 80);
			this.tbTemplateDate.Name = "tbTemplateDate";
			this.tbTemplateDate.Size = new System.Drawing.Size(120, 20);
			this.tbTemplateDate.TabIndex = 67;
			this.tbTemplateDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(8, 80);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(112, 16);
			this.label44.TabIndex = 66;
			this.label44.Text = "Version:";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbTemplateDescription
			// 
			this.tbTemplateDescription.Location = new System.Drawing.Point(128, 104);
			this.tbTemplateDescription.Multiline = true;
			this.tbTemplateDescription.Name = "tbTemplateDescription";
			this.tbTemplateDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbTemplateDescription.Size = new System.Drawing.Size(232, 64);
			this.tbTemplateDescription.TabIndex = 65;
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(8, 104);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(112, 16);
			this.label39.TabIndex = 64;
			this.label39.Text = "Description:";
			this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbTemplateVersion
			// 
			this.tbTemplateVersion.Location = new System.Drawing.Point(128, 80);
			this.tbTemplateVersion.Name = "tbTemplateVersion";
			this.tbTemplateVersion.Size = new System.Drawing.Size(56, 20);
			this.tbTemplateVersion.TabIndex = 63;
			this.tbTemplateVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbTemplateTitle
			// 
			this.tbTemplateTitle.Location = new System.Drawing.Point(128, 56);
			this.tbTemplateTitle.Name = "tbTemplateTitle";
			this.tbTemplateTitle.Size = new System.Drawing.Size(232, 20);
			this.tbTemplateTitle.TabIndex = 62;
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(8, 56);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(112, 16);
			this.label36.TabIndex = 61;
			this.label36.Text = "Title:";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bReset
			// 
			this.bReset.Location = new System.Drawing.Point(536, 320);
			this.bReset.Name = "bReset";
			this.bReset.Size = new System.Drawing.Size(75, 23);
			this.bReset.TabIndex = 84;
			this.bReset.Text = "Reset";
			this.bReset.UseVisualStyleBackColor = true;
			this.bReset.Click += new System.EventHandler(this.BResetClick);
			// 
			// tbHtmlDirectory
			// 
			this.tbHtmlDirectory.Location = new System.Drawing.Point(496, 56);
			this.tbHtmlDirectory.Name = "tbHtmlDirectory";
			this.tbHtmlDirectory.Size = new System.Drawing.Size(248, 20);
			this.tbHtmlDirectory.TabIndex = 86;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(376, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 16);
			this.label1.TabIndex = 85;
			this.label1.Text = "HTML Directory:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbREADME
			// 
			this.tbREADME.Location = new System.Drawing.Point(376, 96);
			this.tbREADME.Multiline = true;
			this.tbREADME.Name = "tbREADME";
			this.tbREADME.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbREADME.Size = new System.Drawing.Size(392, 216);
			this.tbREADME.TabIndex = 88;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(376, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 16);
			this.label2.TabIndex = 87;
			this.label2.Text = "Notes:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bBrowseForWorkingDirectory
			// 
			this.bBrowseForWorkingDirectory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bBrowseForWorkingDirectory.BackgroundImage")));
			this.bBrowseForWorkingDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.bBrowseForWorkingDirectory.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
			this.bBrowseForWorkingDirectory.FlatAppearance.BorderSize = 0;
			this.bBrowseForWorkingDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bBrowseForWorkingDirectory.Location = new System.Drawing.Point(752, 56);
			this.bBrowseForWorkingDirectory.Name = "bBrowseForWorkingDirectory";
			this.bBrowseForWorkingDirectory.Size = new System.Drawing.Size(24, 22);
			this.bBrowseForWorkingDirectory.TabIndex = 89;
			this.bBrowseForWorkingDirectory.UseVisualStyleBackColor = true;
			// 
			// TemplateEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(781, 353);
			this.Controls.Add(this.bBrowseForWorkingDirectory);
			this.Controls.Add(this.tbREADME);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbHtmlDirectory);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bReset);
			this.Controls.Add(this.bSave);
			this.Controls.Add(this.bExit);
			this.Controls.Add(this.tbTemplateWebsite);
			this.Controls.Add(this.label43);
			this.Controls.Add(this.tbTemplateEmail);
			this.Controls.Add(this.label42);
			this.Controls.Add(this.tbTemplateContact);
			this.Controls.Add(this.label41);
			this.Controls.Add(this.tbTemplateCompany);
			this.Controls.Add(this.label40);
			this.Controls.Add(this.tbTemplateAuthor);
			this.Controls.Add(this.label37);
			this.Controls.Add(this.label46);
			this.Controls.Add(this.tbTemplateLicense);
			this.Controls.Add(this.label38);
			this.Controls.Add(this.tbTemplateDate);
			this.Controls.Add(this.label44);
			this.Controls.Add(this.tbTemplateDescription);
			this.Controls.Add(this.label39);
			this.Controls.Add(this.tbTemplateVersion);
			this.Controls.Add(this.tbTemplateTitle);
			this.Controls.Add(this.label36);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "TemplateEditor";
			this.Text = "Template Builder / Editor";
			this.Load += new System.EventHandler(this.TemplateEditorLoad);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripButton pasteToolStripButton;
		private System.Windows.Forms.ToolStripButton copyToolStripButton;
		private System.Windows.Forms.ToolStripButton cutToolStripButton;
		private System.Windows.Forms.ToolStripButton printToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.Button bBrowseForWorkingDirectory;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbREADME;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbHtmlDirectory;
		private System.Windows.Forms.Button bReset;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.TextBox tbTemplateTitle;
		private System.Windows.Forms.TextBox tbTemplateVersion;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.TextBox tbTemplateDescription;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TextBox tbTemplateDate;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.TextBox tbTemplateLicense;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.TextBox tbTemplateAuthor;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.TextBox tbTemplateCompany;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.TextBox tbTemplateContact;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.TextBox tbTemplateEmail;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.TextBox tbTemplateWebsite;
		private System.Windows.Forms.Button bExit;
		private System.Windows.Forms.Button bSave;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripButton helpToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
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
