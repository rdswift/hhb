/*
 * Created by SharpDevelop.
 * User: bob
 * Date: 2016-11-19
 * Time: 10:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HHBuilder
{
	/// <summary>
	/// Form for creating or editing HHBuilder templates.
	/// </summary>
	public partial class TemplateEditor : Form
	{
		#region Private Member Variables
		// ==============================================================================
		HHBTemplate _template;
		HHBTemplate _templateOld;
		#endregion

		#region Private Properties
		// ==============================================================================
		#endregion
		
		#region Private Methods
		// ==============================================================================
		private void OpenFile()
		{
			openFileDialog1.Filter = "HHBuilder template files (*.hhbt)|*.hhbt|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			
			try
			{
				if ( !String.IsNullOrWhiteSpace(_template.fileName) )
				{
					openFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(_template.fileName);
				}
				else
				{
					openFileDialog1.InitialDirectory = System.IO.Path.GetFullPath(HBSettings.templateDir);
				}
			}
			catch (Exception ex)
			{
				Log.Error(String.Format("Invalid template directory {0}", HBSettings.templateDir));
				Log.Exception(ex);
				openFileDialog1.InitialDirectory = Environment.SpecialFolder.CommonDocuments.ToString();
				//throw;
			}
			
			openFileDialog1.FileName = "";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				string templateFilePathAndName = openFileDialog1.FileName;
				_template = new HHBTemplate(templateFilePathAndName);
				if ( String.IsNullOrWhiteSpace(_template.fileName) )
				{
					tbHtmlDirectory.Text = String.Empty;
					tbREADME.Text = String.Empty;
				}
				else
				{
					tbREADME.Text = _template.Notes();
					tbHtmlDirectory.Text = System.IO.Path.GetFullPath(HBSettings.templateHtmlDir);
					_template.UnpackTemplatePackage(HBSettings.templateHtmlDir);
				}
				DisplayTemplate();
			}
		}
		
		// ==============================================================================
		private void TemplateEditorLoad(object sender, EventArgs e)
		{
			ResetForm();
		}
		
		// ==============================================================================
		private void ResetForm()
		{
			_template = new HHBTemplate();
			_templateOld = _template;
			tbHtmlDirectory.Text = String.Empty;
			tbREADME.Text = String.Empty;
			DisplayTemplate();
		}
		
		// ==============================================================================
		private void DisplayTemplate()
		{
			tbTemplateAuthor.Text = _template.author;
			tbTemplateCompany.Text = _template.company;
			tbTemplateContact.Text = _template.contactName;
			tbTemplateDate.Text = _template.revisionDate;
			tbTemplateDescription.Text = _template.description;
			tbTemplateEmail.Text = _template.contactEmail;
			tbTemplateLicense.Text = _template.licenseTitle;
			tbTemplateTitle.Text = _template.title;
			tbTemplateVersion.Text = _template.version;
			tbTemplateWebsite.Text = _template.contactWebsite;
		}
		
		// ==============================================================================
		private void NewToolStripMenuItemClick(object sender, EventArgs e)
		{
			ResetForm();
		}

		// ==============================================================================
		private void NewToolStripButtonClick(object sender, EventArgs e)
		{
			ResetForm();
		}
		
		// ==============================================================================
		private void OpenToolStripButtonClick(object sender, EventArgs e)
		{
			OpenFile();
		}
		
		// ==============================================================================
		private void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
			OpenFile();
		}
		
		// ==============================================================================
		private void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			HHBTemplate.Cleanup();
			Close();
		}
		
		// ==============================================================================
		private void BExitClick(object sender, EventArgs e)
		{
			HHBTemplate.Cleanup();
			Close();
		}
		
		// ==============================================================================
		private void BResetClick(object sender, EventArgs e)
		{
			ResetForm();
		}
		
		// ==============================================================================
		/// <summary>
		/// Finds the control that has the focus in a container control
		/// </summary>
		/// <param name="control">The container control to check.</param>
		/// <returns>The control that has the focus.</returns>
		private static Control FindFocusedControl(Control control)
		{
			var container = control as IContainerControl;
			while (container != null)
			{
				control = container.ActiveControl;
				container = control as IContainerControl;
			}
			return control;
		}
		
		// ==============================================================================
		private void CutButton(object sender, EventArgs e)
		{
			Control tControl = FindFocusedControl(this);
			if (tControl.GetType() == typeof(TextBox))
			{
				((TextBox) tControl).Cut();
			}
		}
		
		// ==============================================================================
		private void CopyButton(object sender, EventArgs e)
		{
			Control tControl = FindFocusedControl(this);
			if (tControl.GetType() == typeof(TextBox))
			{
				((TextBox) tControl).Copy();
			}
		}

		// ==============================================================================
		private void PasteButton(object sender, EventArgs e)
		{
			Control tControl = FindFocusedControl(this);
			if (tControl.GetType() == typeof(TextBox))
			{
				((TextBox) tControl).Paste();
			}
		}
		
		// ==============================================================================
		private void SelectAllButton(object sender, EventArgs e)
		{
			Control tControl = FindFocusedControl(this);
			if (tControl.GetType() == typeof(TextBox))
			{
				((TextBox) tControl).SelectAll();
			}
		}
		
		// ==============================================================================
		private void SaveTemplate(string fileNameToSave)
		{
			_templateOld = _template;
			string fileName = fileNameToSave;
			if ( String.IsNullOrWhiteSpace(fileName) )
			{
				saveFileDialog1.Filter = "HHBuilder template files (*.hhbt)|*.hhbt|All files (*.*)|*.*";
				saveFileDialog1.FilterIndex = 1;
				if ( String.IsNullOrWhiteSpace(_template.fileName) )
				{
					saveFileDialog1.FileName = "HHB_Template.hhbt";
				}
				else
				{
					saveFileDialog1.FileName = System.IO.Path.GetFileName(_template.fileName);
				}
				
				try
				{
					if ( !String.IsNullOrWhiteSpace(_template.fileName) )
					{
						saveFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(_template.fileName);
					}
					else
					{
						saveFileDialog1.InitialDirectory = System.IO.Path.GetFullPath(HBSettings.templateDir);
					}
				}
				catch (Exception ex)
				{
					Log.Error(String.Format("Invalid template directory {0}", HBSettings.templateDir));
					Log.Exception(ex);
					saveFileDialog1.InitialDirectory = Environment.SpecialFolder.CommonDocuments.ToString();
					//throw;
				}

				
				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					fileName = saveFileDialog1.FileName;
					_template = _template.Clone();
				}
			}
			
			_template.author = tbTemplateAuthor.Text;
			_template.company = tbTemplateCompany.Text;
			_template.contactEmail = tbTemplateEmail.Text;
			_template.contactName = tbTemplateContact.Text;
			_template.contactWebsite = tbTemplateWebsite.Text;
			_template.description = tbTemplateDescription.Text;
			_template.licenseTitle = tbTemplateLicense.Text;
			_template.revisionDate = tbTemplateDate.Text;
			_template.title = tbTemplateTitle.Text;
			_template.version = tbTemplateVersion.Text;
			
			if ( !String.IsNullOrWhiteSpace(fileName) )
			{
				System.IO.File.WriteAllText(System.IO.Path.Combine(HBSettings.templateExtractDir, "README"), tbREADME.Text.Trim());
				bool result = _template.PackTemplatePackage(HBSettings.templateHtmlDir, fileName);
				if ( result )
				{
					string message = String.Format("Template saved as {0}", fileName);
					Log.Info(message);
					MessageBox.Show(message, "Success");
				}
				else
				{
					_template = _templateOld;
					string message = String.Format("Problem saving template {0}", fileName);
					Log.Error(message);
					Log.ErrorBox(message);
				}
			}
		}
		
		// ==============================================================================
		private void SaveToolStripButtonClick(object sender, EventArgs e)
		{
			SaveTemplate(_template.fileName);
		}
		
		// ==============================================================================
		private void BSaveClick(object sender, EventArgs e)
		{
			SaveTemplate(_template.fileName);
		}
		
		// ==============================================================================
		private void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			SaveTemplate(_template.fileName);
		}
		
		// ==============================================================================
		private void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
		{
			SaveTemplate(String.Empty);
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		/// <summary>
		/// Form for creating or editing HHBuilder templates.
		/// </summary>
		public TemplateEditor()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
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
