/*
 * Created by SharpDevelop.
 * User: bob
 * Date: 2016-11-25
 * Time: 11:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HHBuilder
{
	/// <summary>
	/// Select the default topic for the help project.
	/// </summary>
	public partial class SelectTopic : Form
	{
		#region Private Member Variables
		// ==============================================================================
		private string _currentTopicID;
		private TreeNode _node;
		#endregion

		#region Private Properties
		// ==============================================================================
		#endregion
		
		#region Private Methods
		// ==============================================================================
		private void SelectTopicLoad(object sender, EventArgs e)
		{
			MainForm.parameterString = String.Empty;
			dataGridView1.DataSource = HelpNode.ScreenLinks(_node).Tables[0];
			if ( dataGridView1.Rows.Count < 1 )
			{
				Log.ErrorBox("No help topic screens available for selection.");
				Close();
			}
			
			dataGridView1.Rows[0].Selected = true;
			if ( !String.IsNullOrWhiteSpace(_currentTopicID) )
			{
				string tID = _currentTopicID.Trim().Split(' ')[0].Trim();
				foreach (DataGridViewRow tRow in dataGridView1.Rows)
				{
					if ( tRow.Cells["nodeID"].Value.ToString().Trim() == tID )
					{
						tRow.Selected = true;
						dataGridView1.CurrentCell = tRow.Cells[0];
					}
				}
			}
		}
		
		// ==============================================================================
		private void BCancelClick(object sender, EventArgs e)
		{
			Close();
		}
		
		// ==============================================================================
		private void BClearClick(object sender, EventArgs e)
		{
			MainForm.parameterString = "CLEAR";
			Close();
		}
		
		// ==============================================================================
		private void BSelectClick(object sender, EventArgs e)
		{
			MainForm.parameterString = String.Format("{0} : {1}", dataGridView1.SelectedRows[0].Cells["nodeID"].Value.ToString().Trim(),
			                                         dataGridView1.SelectedRows[0].Cells["nodeTitle"].Value.ToString().Trim());
			Close();
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		/// <summary>
		/// Displays a list of topics for selection of a default topic screen for the help project.
		/// </summary>
		/// <param name="node">Node in the help project tree.</param>
		public SelectTopic(TreeNode node)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			_node = node;
			_currentTopicID = String.Empty;
		}
		
		// ==============================================================================
		/// <summary>
		/// Displays a list of topics for selection of a default topic screen for the help project.
		/// </summary>
		/// <param name="node">Node in the help project tree.</param>
		/// <param name="currentTopicID">ID of the current default topic.</param>
		public SelectTopic(TreeNode node, string currentTopicID)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			_node = node;
			_currentTopicID = currentTopicID;
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
