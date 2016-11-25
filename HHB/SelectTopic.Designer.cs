/*
 * Created by SharpDevelop.
 * User: bob
 * Date: 2016-11-25
 * Time: 11:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace HHBuilder
{
	partial class SelectTopic
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
			this.bSelect = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.bClear = new System.Windows.Forms.Button();
			this.nodeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nodeIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nodeTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nodeChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.nodeFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nodeLinkText = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// bSelect
			// 
			this.bSelect.Location = new System.Drawing.Point(512, 224);
			this.bSelect.Name = "bSelect";
			this.bSelect.Size = new System.Drawing.Size(75, 23);
			this.bSelect.TabIndex = 0;
			this.bSelect.Text = "Select";
			this.bSelect.UseVisualStyleBackColor = true;
			this.bSelect.Click += new System.EventHandler(this.BSelectClick);
			// 
			// bCancel
			// 
			this.bCancel.Location = new System.Drawing.Point(672, 224);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(75, 23);
			this.bCancel.TabIndex = 1;
			this.bCancel.Text = "Cancel";
			this.bCancel.UseVisualStyleBackColor = true;
			this.bCancel.Click += new System.EventHandler(this.BCancelClick);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.nodeID,
									this.nodeIndex,
									this.nodeTitle,
									this.nodeChecked,
									this.nodeFileName,
									this.nodeLinkText});
			this.dataGridView1.Location = new System.Drawing.Point(8, 8);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(736, 208);
			this.dataGridView1.TabIndex = 2;
			// 
			// bClear
			// 
			this.bClear.Location = new System.Drawing.Point(592, 224);
			this.bClear.Name = "bClear";
			this.bClear.Size = new System.Drawing.Size(75, 23);
			this.bClear.TabIndex = 3;
			this.bClear.Text = "Clear";
			this.bClear.UseVisualStyleBackColor = true;
			this.bClear.Click += new System.EventHandler(this.BClearClick);
			// 
			// nodeID
			// 
			this.nodeID.DataPropertyName = "ID";
			this.nodeID.HeaderText = "ID";
			this.nodeID.Name = "nodeID";
			this.nodeID.ReadOnly = true;
			this.nodeID.Width = 130;
			// 
			// nodeIndex
			// 
			this.nodeIndex.DataPropertyName = "Index";
			this.nodeIndex.HeaderText = "ToC Index";
			this.nodeIndex.Name = "nodeIndex";
			this.nodeIndex.ReadOnly = true;
			// 
			// nodeTitle
			// 
			this.nodeTitle.DataPropertyName = "Title";
			this.nodeTitle.HeaderText = "Title";
			this.nodeTitle.Name = "nodeTitle";
			this.nodeTitle.ReadOnly = true;
			this.nodeTitle.Width = 200;
			// 
			// nodeChecked
			// 
			this.nodeChecked.DataPropertyName = "Checked";
			this.nodeChecked.HeaderText = "Checked";
			this.nodeChecked.Name = "nodeChecked";
			this.nodeChecked.ReadOnly = true;
			this.nodeChecked.Visible = false;
			// 
			// nodeFileName
			// 
			this.nodeFileName.DataPropertyName = "FileName";
			this.nodeFileName.HeaderText = "File Name";
			this.nodeFileName.Name = "nodeFileName";
			this.nodeFileName.ReadOnly = true;
			this.nodeFileName.Visible = false;
			// 
			// nodeLinkText
			// 
			this.nodeLinkText.DataPropertyName = "LinkText";
			this.nodeLinkText.HeaderText = "Link Text";
			this.nodeLinkText.Name = "nodeLinkText";
			this.nodeLinkText.ReadOnly = true;
			this.nodeLinkText.Width = 300;
			// 
			// SelectTopic
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(753, 254);
			this.Controls.Add(this.bClear);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bSelect);
			this.Name = "SelectTopic";
			this.Text = "Select Default Topic Screen";
			this.Load += new System.EventHandler(this.SelectTopicLoad);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.DataGridViewTextBoxColumn nodeLinkText;
		private System.Windows.Forms.DataGridViewTextBoxColumn nodeFileName;
		private System.Windows.Forms.DataGridViewCheckBoxColumn nodeChecked;
		private System.Windows.Forms.Button bClear;
		private System.Windows.Forms.DataGridViewTextBoxColumn nodeTitle;
		private System.Windows.Forms.DataGridViewTextBoxColumn nodeIndex;
		private System.Windows.Forms.DataGridViewTextBoxColumn nodeID;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.Button bSelect;
	}
}
