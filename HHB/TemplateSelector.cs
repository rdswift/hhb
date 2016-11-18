/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-11-14
 * Time: 16:17
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HHBuilder
{
	/// <summary>
	/// Form to select a template to use with a help project.
	/// </summary>
	public partial class TemplateSelector : Form
	{
		#region Private Member Variables
		private DataSet _templateDS;
		#endregion

		#region Private Properties
		// ==============================================================================
		#endregion
		
		#region Private Methods
		// ==============================================================================
		private void InitializeData()
		{
			_templateDS = new DataSet();
			_templateDS.DataSetName = "Templates";
			DataTable dt = new DataTable();
			dt.TableName = "TemplateList";
			DataColumn dc  = new DataColumn("ID", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc  = new DataColumn("Title", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
			_templateDS.Tables.Add(dt);
			
			foreach (HHBTemplate tTemplate in HHBTemplate.AvailableTemplates())
			{
				if ( _templateDS.Tables[0].Rows.Find(tTemplate.id) == null )
				{
					DataRow dr = _templateDS.Tables[0].NewRow();
					dr["ID"] = tTemplate.id;
					dr["Title"] = tTemplate.title;
					_templateDS.Tables[0].Rows.Add(dr);
				}
			}
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		/// <summary>
		/// Select a template to use with a help project.
		/// </summary>
		public TemplateSelector()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		#endregion
		
		#region Public Properties
		// ==============================================================================
		#endregion
		
		#region Public Methods
		// ==============================================================================
		void TemplateSelectorLoad(object sender, EventArgs e)
		{
			MainForm.parameterString = String.Empty;
			
			InitializeData();
			if ( _templateDS.Tables[0].Rows.Count < 1 )
			{
				Log.ErrorBox("There were no templates found.  Please check your template folder setting.");
				Close();
			}
			
			dataGridView1.DataSource = _templateDS.Tables[0];
			dataGridView1.SelectedRows.Clear();
			dataGridView1.Rows[0].Selected = true;
		}
		
		// ==============================================================================
		void DisplayTemplate()
		{
			if ( dataGridView1.SelectedRows.Count < 1 )
			{
				tbTemplateAuthor.Text = String.Empty;
				tbTemplateCompany.Text = String.Empty;
				tbTemplateContact.Text = String.Empty;
				tbTemplateDate.Text = String.Empty;
				tbTemplateDescription.Text = String.Empty;
				tbTemplateEmail.Text = String.Empty;
				tbTemplateLicense.Text = String.Empty;
				tbTemplateTitle.Text = String.Empty;
				tbTemplateVersion.Text = String.Empty;
				tbTemplateWebsite.Text = String.Empty;
			}
			else
			{
				HHBTemplate tTemplate = HHBTemplate.GetTemplate(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString().Trim());
				tbTemplateAuthor.Text = tTemplate.author;
				tbTemplateCompany.Text = tTemplate.company;
				tbTemplateContact.Text = tTemplate.contactName;
				tbTemplateDate.Text = tTemplate.revisionDate;
				tbTemplateDescription.Text = tTemplate.description;
				tbTemplateEmail.Text = tTemplate.contactEmail;
				tbTemplateLicense.Text = tTemplate.licenseTitle;
				tbTemplateTitle.Text = tTemplate.title;
				tbTemplateVersion.Text = tTemplate.version;
				tbTemplateWebsite.Text = tTemplate.contactWebsite;
			}
		}
		
		// ==============================================================================
		void BExitClick(object sender, EventArgs e)
		{
			MainForm.parameterString = String.Empty;
			Close();
		}
		
		// ==============================================================================
		void DataGridView1SelectionChanged(object sender, EventArgs e)
		{
			DisplayTemplate();
		}
		
		// ==============================================================================
		void BSelectClick(object sender, EventArgs e)
		{
			MainForm.parameterString = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString().Trim();
			Close();
		}
		
		// ==============================================================================
		void BViewTemplateLicenseClick(object sender, EventArgs e)
		{
			HHBTemplate tTemplate = HHBTemplate.GetTemplate(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString().Trim());
			string tLicense = tTemplate.License();
			Form frm = new ViewLicense(tLicense);
			frm.ShowDialog();
		}
		#endregion
	}
}
