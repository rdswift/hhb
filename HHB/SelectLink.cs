/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-11-20
 * Time: 09:37
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HHBuilder
{
	/// <summary>
	/// Select a link to insert into the HTML screen body.
	/// </summary>
	public partial class SelectLink : Form
	{
		#region Private Member Variables
		// ==============================================================================
		private TreeNode _node;
		private System.Data.DataSet _ds;
		#endregion

		#region Private Properties
		// ==============================================================================
		#endregion
		
		#region Private Methods
		// ==============================================================================
		private void SelectLinkLoad(object sender, EventArgs e)
		{
			MainForm.parameterString = String.Empty;
			_ds = HelpNode.ScreenLinks(_node);
			listView1.Items.Clear();
			foreach (System.Data.DataRow dr in _ds.Tables[0].Rows)
			{
				ListViewItem lvi = new ListViewItem();
//				lvi.Text = dr.ItemArray[0].ToString();
//				lvi.SubItems[0].Text = dr.ItemArray[3].ToString();
//				lvi.SubItems[1].Text = dr.ItemArray[1].ToString();
				lvi.Text = dr.ItemArray[3].ToString().TrimStart('0');
				lvi.SubItems.Add(dr.ItemArray[1].ToString().Trim());
				string[] tagInfo = { (string) dr.ItemArray[4].ToString(), (string) dr.ItemArray[5].ToString() };
				lvi.Tag = tagInfo;
				listView1.Items.Add(lvi);
			}
			if ( listView1.Items.Count > 0 )
			{
				listView1.Items[0].Selected = true;
			}
			listView1.Refresh();
			UpdateLinkInfo();
		}
		
		// ==============================================================================
		private void UpdateLinkInfo()
		{
			if ( listView1.SelectedItems.Count > 0 )
			{
				string[] tagINfo = (string[]) listView1.SelectedItems[0].Tag;
				tbLinkURL.Text = tagINfo[0];
				tbLinkText.Text = tagINfo[1];
			}
			else
			{
				tbLinkURL.Text = String.Empty;
				tbLinkText.Text = String.Empty;
			}
		}
		
		// ==============================================================================
		private void BInsertClick(object sender, EventArgs e)
		{
			if ( String.IsNullOrWhiteSpace(tbLinkURL.Text) )
			{
				Log.ErrorBox("Missing link URL.  Please enter the link information and try again.");
			}
			else
			{
				if ( String.IsNullOrWhiteSpace(tbLinkText.Text) )
				{
					Log.ErrorBox("Missing link display text.  Please enter the link information and try again.");
				}
				else
				{
					MainForm.parameterString = String.Format("{0}Link:{1}|{2}{3}", "{", tbLinkURL.Text.Trim(), tbLinkText.Text.Trim(), "}");
					Close();
				}
			}
		}
		
		// ==============================================================================
		private void BCancelClick(object sender, EventArgs e)
		{
			Close();
		}
		
		// ==============================================================================
		void ListView1SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateLinkInfo();
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		/// <summary>
		/// Select a link to insert into the HTML screen body.
		/// </summary>
		/// <param name="node">Node in the help project.</param>
		public SelectLink(TreeNode node)
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
