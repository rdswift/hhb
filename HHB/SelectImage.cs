/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-11-17
 * Time: 15:42
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HHBuilder
{
	/// <summary>
	/// Form to select an image to insert into an HTML help item.
	/// </summary>
	public partial class SelectImage : Form
	{
		#region Private Member Variables
		private TreeNode _node;
		#endregion

		#region Private Properties
		// ==============================================================================
		#endregion
		
		#region Private Methods
		// ==============================================================================
		void BCancelClick(object sender, EventArgs e)
		{
			Close();
		}
		
		// ==============================================================================
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
		
		// ==============================================================================
		void BInsertClick(object sender, EventArgs e)
		{
			MainForm.parameterString = String.Format("{0}Image:{1}{2}", "{", dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString().Trim(), "}");
			//MainForm.parameterString = String.Format("![{0}]({1})", dataGridView1.SelectedRows[0].Cells["Title"].Value.ToString().Trim(), dataGridView1.SelectedRows[0].Cells["FileName"].Value.ToString().Trim());
			Close();
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		/// <summary>
		/// Select an image to insert into an HTML help item.
		/// </summary>
		/// <param name="node">Node in the help project.</param>
		public SelectImage(TreeNode node)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			_node = node;
		}
		#endregion
		
		#region Public Properties
		// ==============================================================================
		#endregion
		
		#region Public Methods
		// ==============================================================================
		#endregion
	}
}
