/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-11-17
 * Time: 15:42
 */
namespace HHBuilder
{
	partial class SelectImage
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ImageSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Thumbnail = new System.Windows.Forms.DataGridViewImageColumn();
			this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// bInsert
			// 
			this.bInsert.Location = new System.Drawing.Point(472, 200);
			this.bInsert.Name = "bInsert";
			this.bInsert.Size = new System.Drawing.Size(75, 23);
			this.bInsert.TabIndex = 0;
			this.bInsert.Text = "Insert";
			this.bInsert.UseVisualStyleBackColor = true;
			this.bInsert.Click += new System.EventHandler(this.BInsertClick);
			// 
			// bCancel
			// 
			this.bCancel.Location = new System.Drawing.Point(552, 200);
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
									this.ID,
									this.Title,
									this.ImageSize,
									this.Thumbnail,
									this.FileName});
			this.dataGridView1.Location = new System.Drawing.Point(8, 8);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowTemplate.Height = 50;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(616, 184);
			this.dataGridView1.TabIndex = 2;
			// 
			// ID
			// 
			this.ID.DataPropertyName = "ID";
			this.ID.HeaderText = "ID";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Width = 130;
			// 
			// Title
			// 
			this.Title.DataPropertyName = "Title";
			this.Title.HeaderText = "Title";
			this.Title.Name = "Title";
			this.Title.ReadOnly = true;
			this.Title.Width = 300;
			// 
			// ImageSize
			// 
			this.ImageSize.DataPropertyName = "ImageSize";
			this.ImageSize.HeaderText = "Size";
			this.ImageSize.Name = "ImageSize";
			this.ImageSize.ReadOnly = true;
			// 
			// Thumbnail
			// 
			this.Thumbnail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Thumbnail.DataPropertyName = "Thumbnail";
			this.Thumbnail.HeaderText = "Thumbnail";
			this.Thumbnail.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.Thumbnail.Name = "Thumbnail";
			this.Thumbnail.ReadOnly = true;
			// 
			// FileName
			// 
			this.FileName.DataPropertyName = "FileName";
			this.FileName.HeaderText = "File Name";
			this.FileName.Name = "FileName";
			this.FileName.ReadOnly = true;
			this.FileName.Visible = false;
			// 
			// SelectImage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 232);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bInsert);
			this.Name = "SelectImage";
			this.Text = "Insert Image";
			this.Load += new System.EventHandler(this.SelectImageLoad);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.DataGridViewTextBoxColumn ImageSize;
		private System.Windows.Forms.DataGridViewImageColumn Thumbnail;
		private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Title;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.Button bInsert;
	}
}
