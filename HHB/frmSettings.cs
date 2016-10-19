/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-10-04
 * Time: 17:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace HHBuilder
{
	/// <summary>
	/// Description of frmSettings.
	/// </summary>
	public partial class frmSettings : Form
	{
		ResourceManager rmText = new ResourceManager("HHBuilder.LanguageText", Assembly.GetExecutingAssembly());
		//ResourceManager rmText = MainForm.rmText;
		
		public frmSettings()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		// ==============================================================================
		/// <summary>
		/// Handles the Load event for the form
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="e">Event arguments</param>
		void FrmSettingsLoad(object sender, EventArgs e)
		{
			// Set form title
			this.Text = rmText.GetString("frnSettingsTitle");
			
			// Set label text
			lAuthor.Text = rmText.GetString("labels001");
			
			// Display current settings 
			tbAuthor.Text = HBSettings.author;
			tbCompany.Text = HBSettings.company;
			tbCopyright.Text = HBSettings.copyrightTemplate;
			tbWorkingDir.Text = HBSettings.workingDir;
			tbTemplatesDir.Text = HBSettings.templateDir;
			tbLogFile.Text = HBSettings.logFileName;
			cbLanguage.DataSource = Language.GetList();
			cbLanguage.DisplayMember = "Title";
			if ( HBSettings.logLevel == HBSettings.LogLevel.Normal )
			{
				rbLogNormal.Checked = true;
			}
			else if ( HBSettings.logLevel == HBSettings.LogLevel.Debug )
			{
				rbLogDebug.Checked = true;
			}
			else
			{
				string exString = String.Format("Unknown log level: {0}", HBSettings.logLevel.ToString());
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("logLevel", exString);
				ErrorExit(ex);
			}
			string defaultLanguage = HBSettings.language;
			cbLanguage.SelectedIndex = -1;
			if ( !String.IsNullOrEmpty(defaultLanguage) )
			{
				cbLanguage.SelectedIndex = cbLanguage.FindString(defaultLanguage.Substring(7).Trim());
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// Handles click event for the Save button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void BSaveClick(object sender, EventArgs e)
		{
			SaveSettings();
		}
		
		
		// ==============================================================================
		/// <summary>
		/// Save the settings to the configuration file
		/// </summary>
		private void SaveSettings()
		{
			HBSettings.author = tbAuthor.Text.Trim();
			HBSettings.company = tbCompany.Text.Trim();
			HBSettings.copyrightTemplate = tbCopyright.Text.Trim();
			HBSettings.workingDir = tbWorkingDir.Text.Trim();
			HBSettings.templateDir = tbTemplatesDir.Text.Trim();
			HBSettings.logFileName = tbLogFile.Text.Trim();

			if ( rbLogNormal.Checked )
			{
				HBSettings.logLevel = HBSettings.LogLevel.Normal;
			}
			else if ( rbLogDebug.Checked )
			{
				HBSettings.logLevel = HBSettings.LogLevel.Debug;
			}
			else
			{
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("logLevel", "Unknown or unspecified log level.");
				ErrorExit(ex);
			}

			if (cbLanguage.SelectedIndex < 0)
			{
				HBSettings.language = "";
			}
			else
			{
				HBSettings.language = ((Language) cbLanguage.SelectedItem).CodeText();
			}
			if ( HBSettings.Write() )
			{
				Close();
			}
			else
			{
				MessageBox.Show(String.Format(rmText.GetString("errorMessage003"), HBSettings.cfgFileName), 
				                rmText.GetString("errorMessage000"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		
		
		// ==============================================================================
		/// <summary>
		/// Log fatal error and exit with message to the user
		/// </summary>
		/// <param name="ex">Exception to log and display</param>
		private void ErrorExit(Exception ex)
		{
			if ( String.IsNullOrEmpty(ex.Source) )
			{
				ex.Source = this.Name;
			}
			Log.Exception(ex);
			System.Text.StringBuilder errorMessage = new System.Text.StringBuilder();
			errorMessage.Append("The program has encountered an error, and will now shut down.\n\nException: ");
			errorMessage.AppendLine(ex.Message);
			errorMessage.Append("Source: ");
			errorMessage.AppendLine(ex.Source);
			if ( !String.IsNullOrEmpty(ex.StackTrace) )
			{
				errorMessage.AppendLine(ex.StackTrace);
			}
			MessageBox.Show(errorMessage.ToString(), rmText.GetString("errorMessage000"), MessageBoxButtons.OK, MessageBoxIcon.Error);
			Application.Exit();
		}
	}
}
