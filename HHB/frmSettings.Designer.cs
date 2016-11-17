/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-10-04
 * Time: 17:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace HHBuilder
{
	partial class frmSettings
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Identification");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Settings");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Defaults");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Directories");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Logging");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
			this.tbAuthor = new System.Windows.Forms.TextBox();
			this.lAuthor = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbCompany = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbCopyright = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbWorkingDir = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbTemplatesDir = new System.Windows.Forms.TextBox();
			this.bSave = new System.Windows.Forms.Button();
			this.cbLanguage = new System.Windows.Forms.ComboBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tbLogFileDir = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.rbLogErrors = new System.Windows.Forms.RadioButton();
			this.rbLogNone = new System.Windows.Forms.RadioButton();
			this.rbLogDebug = new System.Windows.Forms.RadioButton();
			this.rbLogNormal = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tbFilesToKeep = new System.Windows.Forms.TextBox();
			this.cbCleanOnExit = new System.Windows.Forms.CheckBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageIdentification = new System.Windows.Forms.TabPage();
			this.tabPageSettings = new System.Windows.Forms.TabPage();
			this.cbCheckUpdates = new System.Windows.Forms.CheckBox();
			this.label10 = new System.Windows.Forms.Label();
			this.cbUILanguage = new System.Windows.Forms.ComboBox();
			this.tabPageDefaults = new System.Windows.Forms.TabPage();
			this.tabPageDirectories = new System.Windows.Forms.TabPage();
			this.bBrowseForCompilerDirectory = new System.Windows.Forms.Button();
			this.bBrowseForTemplatesDirectory = new System.Windows.Forms.Button();
			this.bBrowseForWorkingDirectory = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.tbHhcDirectory = new System.Windows.Forms.TextBox();
			this.tabPageLogging = new System.Windows.Forms.TabPage();
			this.bBrowseForLogDirectory = new System.Windows.Forms.Button();
			this.bExit = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPageIdentification.SuspendLayout();
			this.tabPageSettings.SuspendLayout();
			this.tabPageDefaults.SuspendLayout();
			this.tabPageDirectories.SuspendLayout();
			this.tabPageLogging.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbAuthor
			// 
			this.tbAuthor.Location = new System.Drawing.Point(120, 16);
			this.tbAuthor.Name = "tbAuthor";
			this.tbAuthor.Size = new System.Drawing.Size(376, 20);
			this.tbAuthor.TabIndex = 0;
			// 
			// lAuthor
			// 
			this.lAuthor.Location = new System.Drawing.Point(8, 16);
			this.lAuthor.Name = "lAuthor";
			this.lAuthor.Size = new System.Drawing.Size(112, 16);
			this.lAuthor.TabIndex = 1;
			this.lAuthor.Text = "Author:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Company:";
			// 
			// tbCompany
			// 
			this.tbCompany.Location = new System.Drawing.Point(120, 40);
			this.tbCompany.Name = "tbCompany";
			this.tbCompany.Size = new System.Drawing.Size(376, 20);
			this.tbCompany.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Copyright Template:";
			// 
			// tbCopyright
			// 
			this.tbCopyright.Location = new System.Drawing.Point(120, 64);
			this.tbCopyright.Name = "tbCopyright";
			this.tbCopyright.Size = new System.Drawing.Size(376, 20);
			this.tbCopyright.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(120, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(392, 24);
			this.label4.TabIndex = 6;
			this.label4.Text = "Can include the replaceable parameters {YEAR}, {AUTHOR} and {COMPANY}.";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Working Directory:";
			// 
			// tbWorkingDir
			// 
			this.tbWorkingDir.Location = new System.Drawing.Point(120, 16);
			this.tbWorkingDir.Name = "tbWorkingDir";
			this.tbWorkingDir.Size = new System.Drawing.Size(376, 20);
			this.tbWorkingDir.TabIndex = 7;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Templates Directory:";
			// 
			// tbTemplatesDir
			// 
			this.tbTemplatesDir.Location = new System.Drawing.Point(120, 64);
			this.tbTemplatesDir.Name = "tbTemplatesDir";
			this.tbTemplatesDir.Size = new System.Drawing.Size(376, 20);
			this.tbTemplatesDir.TabIndex = 9;
			// 
			// bSave
			// 
			this.bSave.Location = new System.Drawing.Point(568, 312);
			this.bSave.Name = "bSave";
			this.bSave.Size = new System.Drawing.Size(75, 23);
			this.bSave.TabIndex = 11;
			this.bSave.Text = "Save";
			this.bSave.UseVisualStyleBackColor = true;
			this.bSave.Click += new System.EventHandler(this.BSaveClick);
			// 
			// cbLanguage
			// 
			this.cbLanguage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbLanguage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLanguage.FormattingEnabled = true;
			this.cbLanguage.Location = new System.Drawing.Point(120, 16);
			this.cbLanguage.Name = "cbLanguage";
			this.cbLanguage.Size = new System.Drawing.Size(376, 21);
			this.cbLanguage.TabIndex = 21;
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(4, 18);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(112, 16);
			this.label27.TabIndex = 20;
			this.label27.Text = "Default Language:";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(12, 10);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(112, 16);
			this.label7.TabIndex = 23;
			this.label7.Text = "Log Directory:";
			// 
			// tbLogFileDir
			// 
			this.tbLogFileDir.Location = new System.Drawing.Point(124, 10);
			this.tbLogFileDir.Name = "tbLogFileDir";
			this.tbLogFileDir.Size = new System.Drawing.Size(376, 20);
			this.tbLogFileDir.TabIndex = 22;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.rbLogErrors);
			this.groupBox1.Controls.Add(this.rbLogNone);
			this.groupBox1.Controls.Add(this.rbLogDebug);
			this.groupBox1.Controls.Add(this.rbLogNormal);
			this.groupBox1.Location = new System.Drawing.Point(124, 34);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(380, 120);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(64, 88);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(312, 24);
			this.label13.TabIndex = 30;
			this.label13.Text = "- All activity, errors, system exceptions and notices will be logged";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(64, 40);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(312, 24);
			this.label12.TabIndex = 29;
			this.label12.Text = "- Only errors and system exceptions will be logged";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(64, 64);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(312, 24);
			this.label14.TabIndex = 31;
			this.label14.Text = "- Errors, system exceptions and notices will be logged";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(64, 16);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(312, 24);
			this.label11.TabIndex = 28;
			this.label11.Text = " - No logging will be performed.";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rbLogErrors
			// 
			this.rbLogErrors.Location = new System.Drawing.Point(8, 40);
			this.rbLogErrors.Name = "rbLogErrors";
			this.rbLogErrors.Size = new System.Drawing.Size(64, 24);
			this.rbLogErrors.TabIndex = 3;
			this.rbLogErrors.TabStop = true;
			this.rbLogErrors.Text = "Errors";
			this.rbLogErrors.UseVisualStyleBackColor = true;
			// 
			// rbLogNone
			// 
			this.rbLogNone.Location = new System.Drawing.Point(8, 16);
			this.rbLogNone.Name = "rbLogNone";
			this.rbLogNone.Size = new System.Drawing.Size(64, 24);
			this.rbLogNone.TabIndex = 2;
			this.rbLogNone.TabStop = true;
			this.rbLogNone.Text = "None";
			this.rbLogNone.UseVisualStyleBackColor = true;
			// 
			// rbLogDebug
			// 
			this.rbLogDebug.Location = new System.Drawing.Point(8, 88);
			this.rbLogDebug.Name = "rbLogDebug";
			this.rbLogDebug.Size = new System.Drawing.Size(64, 24);
			this.rbLogDebug.TabIndex = 1;
			this.rbLogDebug.TabStop = true;
			this.rbLogDebug.Text = "Debug";
			this.rbLogDebug.UseVisualStyleBackColor = true;
			// 
			// rbLogNormal
			// 
			this.rbLogNormal.Location = new System.Drawing.Point(8, 64);
			this.rbLogNormal.Name = "rbLogNormal";
			this.rbLogNormal.Size = new System.Drawing.Size(64, 24);
			this.rbLogNormal.TabIndex = 0;
			this.rbLogNormal.TabStop = true;
			this.rbLogNormal.Text = "Normal";
			this.rbLogNormal.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 24);
			this.label1.TabIndex = 25;
			this.label1.Text = "Log Level:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 160);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(108, 24);
			this.label8.TabIndex = 26;
			this.label8.Text = "Log Files to Keep:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbFilesToKeep
			// 
			this.tbFilesToKeep.Location = new System.Drawing.Point(124, 160);
			this.tbFilesToKeep.Name = "tbFilesToKeep";
			this.tbFilesToKeep.Size = new System.Drawing.Size(40, 20);
			this.tbFilesToKeep.TabIndex = 27;
			// 
			// cbCleanOnExit
			// 
			this.cbCleanOnExit.Location = new System.Drawing.Point(120, 64);
			this.cbCleanOnExit.Name = "cbCleanOnExit";
			this.cbCleanOnExit.Size = new System.Drawing.Size(376, 24);
			this.cbCleanOnExit.TabIndex = 28;
			this.cbCleanOnExit.Text = "Remove working files at program shutdown";
			this.cbCleanOnExit.UseVisualStyleBackColor = true;
			// 
			// treeView1
			// 
			this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.treeView1.FullRowSelect = true;
			this.treeView1.HideSelection = false;
			this.treeView1.Location = new System.Drawing.Point(16, 8);
			this.treeView1.Name = "treeView1";
			treeNode1.Name = "Node0";
			treeNode1.Text = "Identification";
			treeNode2.Name = "Node1";
			treeNode2.Text = "Settings";
			treeNode3.Name = "Node2";
			treeNode3.Text = "Defaults";
			treeNode4.Name = "Node3";
			treeNode4.Text = "Directories";
			treeNode5.Name = "Node4";
			treeNode5.Text = "Logging";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
									treeNode1,
									treeNode2,
									treeNode3,
									treeNode4,
									treeNode5});
			this.treeView1.Size = new System.Drawing.Size(121, 296);
			this.treeView1.TabIndex = 29;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1AfterSelect);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageIdentification);
			this.tabControl1.Controls.Add(this.tabPageSettings);
			this.tabControl1.Controls.Add(this.tabPageDefaults);
			this.tabControl1.Controls.Add(this.tabPageDirectories);
			this.tabControl1.Controls.Add(this.tabPageLogging);
			this.tabControl1.Location = new System.Drawing.Point(144, 8);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(584, 296);
			this.tabControl1.TabIndex = 32;
			// 
			// tabPageIdentification
			// 
			this.tabPageIdentification.Controls.Add(this.tbAuthor);
			this.tabPageIdentification.Controls.Add(this.lAuthor);
			this.tabPageIdentification.Controls.Add(this.label4);
			this.tabPageIdentification.Controls.Add(this.tbCompany);
			this.tabPageIdentification.Controls.Add(this.label3);
			this.tabPageIdentification.Controls.Add(this.label2);
			this.tabPageIdentification.Controls.Add(this.tbCopyright);
			this.tabPageIdentification.Location = new System.Drawing.Point(4, 22);
			this.tabPageIdentification.Name = "tabPageIdentification";
			this.tabPageIdentification.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageIdentification.Size = new System.Drawing.Size(576, 270);
			this.tabPageIdentification.TabIndex = 0;
			this.tabPageIdentification.Text = "Identification";
			this.tabPageIdentification.UseVisualStyleBackColor = true;
			// 
			// tabPageSettings
			// 
			this.tabPageSettings.Controls.Add(this.cbCheckUpdates);
			this.tabPageSettings.Controls.Add(this.label10);
			this.tabPageSettings.Controls.Add(this.cbUILanguage);
			this.tabPageSettings.Controls.Add(this.cbCleanOnExit);
			this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
			this.tabPageSettings.Name = "tabPageSettings";
			this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSettings.Size = new System.Drawing.Size(576, 270);
			this.tabPageSettings.TabIndex = 1;
			this.tabPageSettings.Text = "Settings";
			this.tabPageSettings.UseVisualStyleBackColor = true;
			// 
			// cbCheckUpdates
			// 
			this.cbCheckUpdates.Location = new System.Drawing.Point(120, 40);
			this.cbCheckUpdates.Name = "cbCheckUpdates";
			this.cbCheckUpdates.Size = new System.Drawing.Size(376, 24);
			this.cbCheckUpdates.TabIndex = 35;
			this.cbCheckUpdates.Text = "Check for updates at program startup";
			this.cbCheckUpdates.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(4, 18);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(112, 16);
			this.label10.TabIndex = 33;
			this.label10.Text = "Interface Language:";
			// 
			// cbUILanguage
			// 
			this.cbUILanguage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbUILanguage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbUILanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUILanguage.FormattingEnabled = true;
			this.cbUILanguage.Location = new System.Drawing.Point(120, 16);
			this.cbUILanguage.Name = "cbUILanguage";
			this.cbUILanguage.Size = new System.Drawing.Size(376, 21);
			this.cbUILanguage.TabIndex = 34;
			// 
			// tabPageDefaults
			// 
			this.tabPageDefaults.Controls.Add(this.cbLanguage);
			this.tabPageDefaults.Controls.Add(this.label27);
			this.tabPageDefaults.Location = new System.Drawing.Point(4, 22);
			this.tabPageDefaults.Name = "tabPageDefaults";
			this.tabPageDefaults.Size = new System.Drawing.Size(576, 270);
			this.tabPageDefaults.TabIndex = 2;
			this.tabPageDefaults.Text = "Defaults";
			this.tabPageDefaults.UseVisualStyleBackColor = true;
			// 
			// tabPageDirectories
			// 
			this.tabPageDirectories.Controls.Add(this.bBrowseForCompilerDirectory);
			this.tabPageDirectories.Controls.Add(this.bBrowseForTemplatesDirectory);
			this.tabPageDirectories.Controls.Add(this.bBrowseForWorkingDirectory);
			this.tabPageDirectories.Controls.Add(this.label9);
			this.tabPageDirectories.Controls.Add(this.tbHhcDirectory);
			this.tabPageDirectories.Controls.Add(this.tbWorkingDir);
			this.tabPageDirectories.Controls.Add(this.label5);
			this.tabPageDirectories.Controls.Add(this.tbTemplatesDir);
			this.tabPageDirectories.Controls.Add(this.label6);
			this.tabPageDirectories.Location = new System.Drawing.Point(4, 22);
			this.tabPageDirectories.Name = "tabPageDirectories";
			this.tabPageDirectories.Size = new System.Drawing.Size(576, 270);
			this.tabPageDirectories.TabIndex = 3;
			this.tabPageDirectories.Text = "Directories";
			this.tabPageDirectories.UseVisualStyleBackColor = true;
			// 
			// bBrowseForCompilerDirectory
			// 
			this.bBrowseForCompilerDirectory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bBrowseForCompilerDirectory.BackgroundImage")));
			this.bBrowseForCompilerDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.bBrowseForCompilerDirectory.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
			this.bBrowseForCompilerDirectory.FlatAppearance.BorderSize = 0;
			this.bBrowseForCompilerDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bBrowseForCompilerDirectory.Location = new System.Drawing.Point(504, 40);
			this.bBrowseForCompilerDirectory.Name = "bBrowseForCompilerDirectory";
			this.bBrowseForCompilerDirectory.Size = new System.Drawing.Size(24, 22);
			this.bBrowseForCompilerDirectory.TabIndex = 13;
			this.bBrowseForCompilerDirectory.UseVisualStyleBackColor = true;
			this.bBrowseForCompilerDirectory.Click += new System.EventHandler(this.BBrowseForCompilerDirectoryClick);
			// 
			// bBrowseForTemplatesDirectory
			// 
			this.bBrowseForTemplatesDirectory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bBrowseForTemplatesDirectory.BackgroundImage")));
			this.bBrowseForTemplatesDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.bBrowseForTemplatesDirectory.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
			this.bBrowseForTemplatesDirectory.FlatAppearance.BorderSize = 0;
			this.bBrowseForTemplatesDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bBrowseForTemplatesDirectory.Location = new System.Drawing.Point(504, 64);
			this.bBrowseForTemplatesDirectory.Name = "bBrowseForTemplatesDirectory";
			this.bBrowseForTemplatesDirectory.Size = new System.Drawing.Size(24, 22);
			this.bBrowseForTemplatesDirectory.TabIndex = 12;
			this.bBrowseForTemplatesDirectory.UseVisualStyleBackColor = true;
			this.bBrowseForTemplatesDirectory.Click += new System.EventHandler(this.BBrowseForTemplatesDirectoryClick);
			// 
			// bBrowseForWorkingDirectory
			// 
			this.bBrowseForWorkingDirectory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bBrowseForWorkingDirectory.BackgroundImage")));
			this.bBrowseForWorkingDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.bBrowseForWorkingDirectory.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
			this.bBrowseForWorkingDirectory.FlatAppearance.BorderSize = 0;
			this.bBrowseForWorkingDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bBrowseForWorkingDirectory.Location = new System.Drawing.Point(504, 16);
			this.bBrowseForWorkingDirectory.Name = "bBrowseForWorkingDirectory";
			this.bBrowseForWorkingDirectory.Size = new System.Drawing.Size(24, 22);
			this.bBrowseForWorkingDirectory.TabIndex = 11;
			this.bBrowseForWorkingDirectory.UseVisualStyleBackColor = true;
			this.bBrowseForWorkingDirectory.Click += new System.EventHandler(this.BBrowseForWorkingDirectoryClick);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 40);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(112, 16);
			this.label9.TabIndex = 10;
			this.label9.Text = "hhc.exe Directory:";
			// 
			// tbHhcDirectory
			// 
			this.tbHhcDirectory.Location = new System.Drawing.Point(120, 40);
			this.tbHhcDirectory.Name = "tbHhcDirectory";
			this.tbHhcDirectory.Size = new System.Drawing.Size(376, 20);
			this.tbHhcDirectory.TabIndex = 9;
			// 
			// tabPageLogging
			// 
			this.tabPageLogging.Controls.Add(this.bBrowseForLogDirectory);
			this.tabPageLogging.Controls.Add(this.label8);
			this.tabPageLogging.Controls.Add(this.tbLogFileDir);
			this.tabPageLogging.Controls.Add(this.label7);
			this.tabPageLogging.Controls.Add(this.groupBox1);
			this.tabPageLogging.Controls.Add(this.tbFilesToKeep);
			this.tabPageLogging.Controls.Add(this.label1);
			this.tabPageLogging.Location = new System.Drawing.Point(4, 22);
			this.tabPageLogging.Name = "tabPageLogging";
			this.tabPageLogging.Size = new System.Drawing.Size(576, 270);
			this.tabPageLogging.TabIndex = 4;
			this.tabPageLogging.Text = "Logging";
			this.tabPageLogging.UseVisualStyleBackColor = true;
			// 
			// bBrowseForLogDirectory
			// 
			this.bBrowseForLogDirectory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bBrowseForLogDirectory.BackgroundImage")));
			this.bBrowseForLogDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.bBrowseForLogDirectory.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
			this.bBrowseForLogDirectory.FlatAppearance.BorderSize = 0;
			this.bBrowseForLogDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bBrowseForLogDirectory.Location = new System.Drawing.Point(508, 10);
			this.bBrowseForLogDirectory.Name = "bBrowseForLogDirectory";
			this.bBrowseForLogDirectory.Size = new System.Drawing.Size(24, 22);
			this.bBrowseForLogDirectory.TabIndex = 28;
			this.bBrowseForLogDirectory.UseVisualStyleBackColor = true;
			this.bBrowseForLogDirectory.Click += new System.EventHandler(this.BBrowseForLogDirectoryClick);
			// 
			// bExit
			// 
			this.bExit.Location = new System.Drawing.Point(648, 312);
			this.bExit.Name = "bExit";
			this.bExit.Size = new System.Drawing.Size(75, 23);
			this.bExit.TabIndex = 33;
			this.bExit.Text = "Exit";
			this.bExit.UseVisualStyleBackColor = true;
			this.bExit.Click += new System.EventHandler(this.BExitClick);
			// 
			// frmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(739, 350);
			this.Controls.Add(this.bExit);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.bSave);
			this.Name = "frmSettings";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.FrmSettingsLoad);
			this.groupBox1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPageIdentification.ResumeLayout(false);
			this.tabPageIdentification.PerformLayout();
			this.tabPageSettings.ResumeLayout(false);
			this.tabPageDefaults.ResumeLayout(false);
			this.tabPageDirectories.ResumeLayout(false);
			this.tabPageDirectories.PerformLayout();
			this.tabPageLogging.ResumeLayout(false);
			this.tabPageLogging.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button bBrowseForLogDirectory;
		private System.Windows.Forms.Button bBrowseForTemplatesDirectory;
		private System.Windows.Forms.Button bBrowseForCompilerDirectory;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button bBrowseForWorkingDirectory;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button bExit;
		private System.Windows.Forms.TabPage tabPageLogging;
		private System.Windows.Forms.TextBox tbHhcDirectory;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TabPage tabPageDirectories;
		private System.Windows.Forms.TabPage tabPageDefaults;
		private System.Windows.Forms.ComboBox cbUILanguage;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.CheckBox cbCheckUpdates;
		private System.Windows.Forms.TabPage tabPageSettings;
		private System.Windows.Forms.TabPage tabPageIdentification;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.CheckBox cbCleanOnExit;
		private System.Windows.Forms.TextBox tbFilesToKeep;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.RadioButton rbLogNone;
		private System.Windows.Forms.RadioButton rbLogErrors;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rbLogNormal;
		private System.Windows.Forms.RadioButton rbLogDebug;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbLogFileDir;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.ComboBox cbLanguage;
		private System.Windows.Forms.Button bSave;
		private System.Windows.Forms.TextBox tbTemplatesDir;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbWorkingDir;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbCopyright;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbCompany;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lAuthor;
		private System.Windows.Forms.TextBox tbAuthor;
	}
}
