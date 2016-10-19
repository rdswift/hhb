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
			this.tbLogFile = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbLogNormal = new System.Windows.Forms.RadioButton();
			this.rbLogDebug = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbAuthor
			// 
			this.tbAuthor.Location = new System.Drawing.Point(128, 8);
			this.tbAuthor.Name = "tbAuthor";
			this.tbAuthor.Size = new System.Drawing.Size(376, 20);
			this.tbAuthor.TabIndex = 0;
			// 
			// lAuthor
			// 
			this.lAuthor.Location = new System.Drawing.Point(16, 8);
			this.lAuthor.Name = "lAuthor";
			this.lAuthor.Size = new System.Drawing.Size(112, 16);
			this.lAuthor.TabIndex = 1;
			this.lAuthor.Text = "Author (blah):";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Company:";
			// 
			// tbCompany
			// 
			this.tbCompany.Location = new System.Drawing.Point(128, 32);
			this.tbCompany.Name = "tbCompany";
			this.tbCompany.Size = new System.Drawing.Size(376, 20);
			this.tbCompany.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Copyright Template:";
			// 
			// tbCopyright
			// 
			this.tbCopyright.Location = new System.Drawing.Point(128, 72);
			this.tbCopyright.Name = "tbCopyright";
			this.tbCopyright.Size = new System.Drawing.Size(376, 20);
			this.tbCopyright.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(128, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(392, 24);
			this.label4.TabIndex = 6;
			this.label4.Text = "Can include the replaceable parameters {YEAR}, {AUTHOR} and {COMPANY}.";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 248);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Working Directory:";
			// 
			// tbWorkingDir
			// 
			this.tbWorkingDir.Location = new System.Drawing.Point(128, 248);
			this.tbWorkingDir.Name = "tbWorkingDir";
			this.tbWorkingDir.Size = new System.Drawing.Size(376, 20);
			this.tbWorkingDir.TabIndex = 7;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 272);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Templates Directory:";
			// 
			// tbTemplatesDir
			// 
			this.tbTemplatesDir.Location = new System.Drawing.Point(128, 272);
			this.tbTemplatesDir.Name = "tbTemplatesDir";
			this.tbTemplatesDir.Size = new System.Drawing.Size(376, 20);
			this.tbTemplatesDir.TabIndex = 9;
			// 
			// bSave
			// 
			this.bSave.Location = new System.Drawing.Point(432, 352);
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
			this.cbLanguage.Location = new System.Drawing.Point(128, 312);
			this.cbLanguage.Name = "cbLanguage";
			this.cbLanguage.Size = new System.Drawing.Size(376, 21);
			this.cbLanguage.TabIndex = 21;
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(16, 312);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(112, 16);
			this.label27.TabIndex = 20;
			this.label27.Text = "Default Language:";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 144);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(112, 16);
			this.label7.TabIndex = 23;
			this.label7.Text = "Log File:";
			// 
			// tbLogFile
			// 
			this.tbLogFile.Location = new System.Drawing.Point(128, 144);
			this.tbLogFile.Name = "tbLogFile";
			this.tbLogFile.Size = new System.Drawing.Size(376, 20);
			this.tbLogFile.TabIndex = 22;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbLogDebug);
			this.groupBox1.Controls.Add(this.rbLogNormal);
			this.groupBox1.Location = new System.Drawing.Point(128, 168);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(376, 48);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			// 
			// rbLogNormal
			// 
			this.rbLogNormal.Location = new System.Drawing.Point(8, 16);
			this.rbLogNormal.Name = "rbLogNormal";
			this.rbLogNormal.Size = new System.Drawing.Size(104, 24);
			this.rbLogNormal.TabIndex = 0;
			this.rbLogNormal.TabStop = true;
			this.rbLogNormal.Text = "Normal";
			this.rbLogNormal.UseVisualStyleBackColor = true;
			// 
			// rbLogDebug
			// 
			this.rbLogDebug.Location = new System.Drawing.Point(112, 16);
			this.rbLogDebug.Name = "rbLogDebug";
			this.rbLogDebug.Size = new System.Drawing.Size(104, 24);
			this.rbLogDebug.TabIndex = 1;
			this.rbLogDebug.TabStop = true;
			this.rbLogDebug.Text = "Debug";
			this.rbLogDebug.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 184);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 24);
			this.label1.TabIndex = 25;
			this.label1.Text = "Log Level:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(520, 397);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.tbLogFile);
			this.Controls.Add(this.cbLanguage);
			this.Controls.Add(this.label27);
			this.Controls.Add(this.bSave);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbTemplatesDir);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbWorkingDir);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbCopyright);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbCompany);
			this.Controls.Add(this.lAuthor);
			this.Controls.Add(this.tbAuthor);
			this.Name = "frmSettings";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.FrmSettingsLoad);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rbLogNormal;
		private System.Windows.Forms.RadioButton rbLogDebug;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbLogFile;
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
