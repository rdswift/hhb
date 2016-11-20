/*
 * Created by SharpDevelop.
 * User: bob
 * Date: 2016-11-20
 * Time: 09:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace HHBuilder
{
	partial class SelectLink
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
			this.bInsert = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.tbLinkURL = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbLinkText = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.lvColumnIndex = new System.Windows.Forms.ColumnHeader();
			this.lvColumnTitle = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// bInsert
			// 
			this.bInsert.Location = new System.Drawing.Point(296, 288);
			this.bInsert.Name = "bInsert";
			this.bInsert.Size = new System.Drawing.Size(75, 23);
			this.bInsert.TabIndex = 0;
			this.bInsert.Text = "Insert";
			this.bInsert.UseVisualStyleBackColor = true;
			this.bInsert.Click += new System.EventHandler(this.BInsertClick);
			// 
			// bCancel
			// 
			this.bCancel.Location = new System.Drawing.Point(376, 288);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(75, 23);
			this.bCancel.TabIndex = 1;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = true;
			this.bCancel.Click += new System.EventHandler(this.BCancelClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 232);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Link:";
			// 
			// tbLinkURL
			// 
			this.tbLinkURL.Location = new System.Drawing.Point(120, 232);
			this.tbLinkURL.Name = "tbLinkURL";
			this.tbLinkURL.Size = new System.Drawing.Size(328, 20);
			this.tbLinkURL.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 256);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Text to Display:";
			// 
			// tbLinkText
			// 
			this.tbLinkText.Location = new System.Drawing.Point(120, 256);
			this.tbLinkText.Name = "tbLinkText";
			this.tbLinkText.Size = new System.Drawing.Size(328, 20);
			this.tbLinkText.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 176);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(440, 48);
			this.label3.TabIndex = 7;
			this.label3.Text = "Select an item from the list above, or enter the link and display text informatio" +
			"n below and click the Insert button.";
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.lvColumnIndex,
									this.lvColumnTitle});
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(8, 8);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(440, 160);
			this.listView1.TabIndex = 8;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1SelectedIndexChanged);
			// 
			// lvColumnIndex
			// 
			this.lvColumnIndex.Text = "Index";
			// 
			// lvColumnTitle
			// 
			this.lvColumnTitle.Text = "Title";
			this.lvColumnTitle.Width = 300;
			// 
			// SelectLink
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(456, 319);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbLinkText);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbLinkURL);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bInsert);
			this.Name = "SelectLink";
			this.Text = "Insert Link";
			this.Load += new System.EventHandler(this.SelectLinkLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ColumnHeader lvColumnTitle;
		private System.Windows.Forms.ColumnHeader lvColumnIndex;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbLinkURL;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbLinkText;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.Button bInsert;
	}
}
