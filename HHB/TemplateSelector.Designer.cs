/*
 * Created by SharpDevelop.
 * User: bob
 * Date: 2016-11-14
 * Time: 16:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace HHBuilder
{
	partial class TemplateSelector
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.bSelect = new System.Windows.Forms.Button();
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
			this.bViewTemplateLicense = new System.Windows.Forms.Button();
			this.tbTemplateLicense = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.tbTemplateDate = new System.Windows.Forms.TextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.tbTemplateDescription = new System.Windows.Forms.TextBox();
			this.label39 = new System.Windows.Forms.Label();
			this.tbTemplateVersion = new System.Windows.Forms.TextBox();
			this.tbTemplateTitle = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.bSelect);
			this.splitContainer1.Panel2.Controls.Add(this.bExit);
			this.splitContainer1.Panel2.Controls.Add(this.tbTemplateWebsite);
			this.splitContainer1.Panel2.Controls.Add(this.label43);
			this.splitContainer1.Panel2.Controls.Add(this.tbTemplateEmail);
			this.splitContainer1.Panel2.Controls.Add(this.label42);
			this.splitContainer1.Panel2.Controls.Add(this.tbTemplateContact);
			this.splitContainer1.Panel2.Controls.Add(this.label41);
			this.splitContainer1.Panel2.Controls.Add(this.tbTemplateCompany);
			this.splitContainer1.Panel2.Controls.Add(this.label40);
			this.splitContainer1.Panel2.Controls.Add(this.tbTemplateAuthor);
			this.splitContainer1.Panel2.Controls.Add(this.label37);
			this.splitContainer1.Panel2.Controls.Add(this.label46);
			this.splitContainer1.Panel2.Controls.Add(this.bViewTemplateLicense);
			this.splitContainer1.Panel2.Controls.Add(this.tbTemplateLicense);
			this.splitContainer1.Panel2.Controls.Add(this.label38);
			this.splitContainer1.Panel2.Controls.Add(this.tbTemplateDate);
			this.splitContainer1.Panel2.Controls.Add(this.label44);
			this.splitContainer1.Panel2.Controls.Add(this.tbTemplateDescription);
			this.splitContainer1.Panel2.Controls.Add(this.label39);
			this.splitContainer1.Panel2.Controls.Add(this.tbTemplateVersion);
			this.splitContainer1.Panel2.Controls.Add(this.tbTemplateTitle);
			this.splitContainer1.Panel2.Controls.Add(this.label36);
			this.splitContainer1.Size = new System.Drawing.Size(621, 321);
			this.splitContainer1.SplitterDistance = 286;
			this.splitContainer1.TabIndex = 0;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.ID,
									this.Title});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(286, 321);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1SelectionChanged);
			// 
			// bSelect
			// 
			this.bSelect.Location = new System.Drawing.Point(168, 288);
			this.bSelect.Name = "bSelect";
			this.bSelect.Size = new System.Drawing.Size(75, 23);
			this.bSelect.TabIndex = 60;
			this.bSelect.Text = "Select";
			this.bSelect.UseVisualStyleBackColor = true;
			this.bSelect.Click += new System.EventHandler(this.BSelectClick);
			// 
			// bExit
			// 
			this.bExit.Location = new System.Drawing.Point(248, 288);
			this.bExit.Name = "bExit";
			this.bExit.Size = new System.Drawing.Size(75, 23);
			this.bExit.TabIndex = 59;
			this.bExit.Text = "Exit";
			this.bExit.UseVisualStyleBackColor = true;
			this.bExit.Click += new System.EventHandler(this.BExitClick);
			// 
			// tbTemplateWebsite
			// 
			this.tbTemplateWebsite.Location = new System.Drawing.Point(88, 256);
			this.tbTemplateWebsite.Name = "tbTemplateWebsite";
			this.tbTemplateWebsite.ReadOnly = true;
			this.tbTemplateWebsite.Size = new System.Drawing.Size(232, 20);
			this.tbTemplateWebsite.TabIndex = 58;
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(8, 256);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(72, 16);
			this.label43.TabIndex = 57;
			this.label43.Text = "Website:";
			this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbTemplateEmail
			// 
			this.tbTemplateEmail.Location = new System.Drawing.Point(88, 232);
			this.tbTemplateEmail.Name = "tbTemplateEmail";
			this.tbTemplateEmail.ReadOnly = true;
			this.tbTemplateEmail.Size = new System.Drawing.Size(232, 20);
			this.tbTemplateEmail.TabIndex = 56;
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(8, 232);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(72, 16);
			this.label42.TabIndex = 55;
			this.label42.Text = "Email:";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbTemplateContact
			// 
			this.tbTemplateContact.Location = new System.Drawing.Point(88, 208);
			this.tbTemplateContact.Name = "tbTemplateContact";
			this.tbTemplateContact.ReadOnly = true;
			this.tbTemplateContact.Size = new System.Drawing.Size(232, 20);
			this.tbTemplateContact.TabIndex = 54;
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(8, 208);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(72, 16);
			this.label41.TabIndex = 53;
			this.label41.Text = "Contact:";
			this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbTemplateCompany
			// 
			this.tbTemplateCompany.Location = new System.Drawing.Point(88, 184);
			this.tbTemplateCompany.Name = "tbTemplateCompany";
			this.tbTemplateCompany.ReadOnly = true;
			this.tbTemplateCompany.Size = new System.Drawing.Size(232, 20);
			this.tbTemplateCompany.TabIndex = 52;
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(8, 184);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(72, 16);
			this.label40.TabIndex = 51;
			this.label40.Text = "Company:";
			this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbTemplateAuthor
			// 
			this.tbTemplateAuthor.Location = new System.Drawing.Point(88, 160);
			this.tbTemplateAuthor.Name = "tbTemplateAuthor";
			this.tbTemplateAuthor.ReadOnly = true;
			this.tbTemplateAuthor.Size = new System.Drawing.Size(232, 20);
			this.tbTemplateAuthor.TabIndex = 50;
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(8, 160);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(72, 16);
			this.label37.TabIndex = 49;
			this.label37.Text = "Author:";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label46
			// 
			this.label46.Location = new System.Drawing.Point(152, 32);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(40, 16);
			this.label46.TabIndex = 48;
			this.label46.Text = "Date:";
			this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// bViewTemplateLicense
			// 
			this.bViewTemplateLicense.Location = new System.Drawing.Point(272, 56);
			this.bViewTemplateLicense.Name = "bViewTemplateLicense";
			this.bViewTemplateLicense.Size = new System.Drawing.Size(48, 23);
			this.bViewTemplateLicense.TabIndex = 47;
			this.bViewTemplateLicense.Text = "View";
			this.bViewTemplateLicense.UseVisualStyleBackColor = true;
			this.bViewTemplateLicense.Click += new System.EventHandler(this.BViewTemplateLicenseClick);
			// 
			// tbTemplateLicense
			// 
			this.tbTemplateLicense.Location = new System.Drawing.Point(80, 56);
			this.tbTemplateLicense.Name = "tbTemplateLicense";
			this.tbTemplateLicense.ReadOnly = true;
			this.tbTemplateLicense.Size = new System.Drawing.Size(184, 20);
			this.tbTemplateLicense.TabIndex = 46;
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(8, 56);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(64, 16);
			this.label38.TabIndex = 45;
			this.label38.Text = "License:";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbTemplateDate
			// 
			this.tbTemplateDate.Location = new System.Drawing.Point(200, 32);
			this.tbTemplateDate.Name = "tbTemplateDate";
			this.tbTemplateDate.ReadOnly = true;
			this.tbTemplateDate.Size = new System.Drawing.Size(120, 20);
			this.tbTemplateDate.TabIndex = 44;
			this.tbTemplateDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(8, 32);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(64, 16);
			this.label44.TabIndex = 43;
			this.label44.Text = "Version:";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbTemplateDescription
			// 
			this.tbTemplateDescription.Location = new System.Drawing.Point(80, 88);
			this.tbTemplateDescription.Multiline = true;
			this.tbTemplateDescription.Name = "tbTemplateDescription";
			this.tbTemplateDescription.ReadOnly = true;
			this.tbTemplateDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbTemplateDescription.Size = new System.Drawing.Size(240, 64);
			this.tbTemplateDescription.TabIndex = 42;
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(8, 88);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(64, 16);
			this.label39.TabIndex = 41;
			this.label39.Text = "Description:";
			this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbTemplateVersion
			// 
			this.tbTemplateVersion.Location = new System.Drawing.Point(80, 32);
			this.tbTemplateVersion.Name = "tbTemplateVersion";
			this.tbTemplateVersion.ReadOnly = true;
			this.tbTemplateVersion.Size = new System.Drawing.Size(64, 20);
			this.tbTemplateVersion.TabIndex = 40;
			this.tbTemplateVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbTemplateTitle
			// 
			this.tbTemplateTitle.Location = new System.Drawing.Point(80, 8);
			this.tbTemplateTitle.Name = "tbTemplateTitle";
			this.tbTemplateTitle.ReadOnly = true;
			this.tbTemplateTitle.Size = new System.Drawing.Size(240, 20);
			this.tbTemplateTitle.TabIndex = 39;
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(8, 8);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(64, 16);
			this.label36.TabIndex = 38;
			this.label36.Text = "Title:";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ID
			// 
			this.ID.DataPropertyName = "ID";
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Visible = false;
			// 
			// Title
			// 
			this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Title.DataPropertyName = "Title";
			this.Title.HeaderText = "Title";
			this.Title.Name = "Title";
			this.Title.ReadOnly = true;
			// 
			// TemplateSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(621, 321);
			this.Controls.Add(this.splitContainer1);
			this.Name = "TemplateSelector";
			this.Text = "Template Selector";
			this.Load += new System.EventHandler(this.TemplateSelectorLoad);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
		}
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
		private System.Windows.Forms.Button bSelect;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.TextBox tbTemplateTitle;
		private System.Windows.Forms.TextBox tbTemplateVersion;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.TextBox tbTemplateDescription;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TextBox tbTemplateDate;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.TextBox tbTemplateLicense;
		private System.Windows.Forms.Button bViewTemplateLicense;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.DataGridViewTextBoxColumn Title;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}
