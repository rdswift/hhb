/*
 * Created by SharpDevelop.
 * User: bob
 * Date: 2016-11-17
 * Time: 15:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HHBuilder
{
	/// <summary>
	/// Description of SelectImage.
	/// </summary>
	public partial class SelectImage : Form
	{
		private TreeNode _node;
		public SelectImage(TreeNode node)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			_node = node;
		}
		
		void BCancelClick(object sender, EventArgs e)
		{
			Close();
		}
		
		void SelectImageLoad(object sender, EventArgs e)
		{
			dataGridView1.DataSource = ImageItem.GetAvailableImages(_node);
			if ( dataGridView1.Rows.Count < 1 )
			{
				Log.ErrorBox("No images available for selection.");
				Close();
			}
			dataGridView1.SelectedRows.Clear();
			dataGridView1.Rows[0].Selected = true;
		}
		
		void BInsertClick(object sender, EventArgs e)
		{
			MainForm.parameterString = String.Format("{0}Image:{1}{2}", "{", dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString().Trim(), "}");
			Close();
		}
	}
}
