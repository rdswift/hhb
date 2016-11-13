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
			tbLogFile.Text = HBSettings.logDir;
			tbFilesToKeep.Text = HBSettings.logsToKeep.ToString();
			cbLanguage.DataSource = Language.GetList();
			cbLanguage.DisplayMember = "Title";
			switch (HBSettings.logLevel) {
				case Log.LogLevel.None:
					rbLogNone.Checked = true;
					break;
				case Log.LogLevel.Errors:
					rbLogErrors.Checked = true;
					break;
				case Log.LogLevel.Normal:
					rbLogNormal.Checked = true;
					break;
				case Log.LogLevel.Debug:
					rbLogDebug.Checked = true;
					break;
				default:
					string exString = String.Format("Unknown log level: {0}", HBSettings.logLevel.ToString());
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("logLevel", exString);
					ex.Source = this.Name;
					Log.ErrorExit(ex);
					//throw new Exception("Invalid value for LogLevel");
					break;
			}
			string defaultLanguage = HBSettings.language;
			cbLanguage.SelectedIndex = -1;
			if ( !String.IsNullOrEmpty(defaultLanguage) )
			{
				cbLanguage.SelectedIndex = cbLanguage.FindString(defaultLanguage.Substring(7).Trim());
			}
			cbCleanOnExit.Checked = HBSettings.cleanOnExit;
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
			Log.Debug("Saving user settings.");
			
			HBSettings.author = tbAuthor.Text.Trim();
			HBSettings.company = tbCompany.Text.Trim();
			HBSettings.copyrightTemplate = tbCopyright.Text.Trim();
			HBSettings.workingDir = tbWorkingDir.Text.Trim();
			HBSettings.templateDir = tbTemplatesDir.Text.Trim();
			HBSettings.logDir = tbLogFile.Text.Trim();
			HBSettings.logsToKeep = Convert.ToInt32("0" + tbFilesToKeep.Text.Trim());
			
			Log.logDir = HBSettings.logDir;
			Log.filesToKeep = HBSettings.logsToKeep;

			if ( rbLogNone.Checked )
			{
				HBSettings.logLevel = Log.LogLevel.None;
			}
			else if ( rbLogErrors.Checked )
			{
				HBSettings.logLevel = Log.LogLevel.Errors;
			}
			else if ( rbLogNormal.Checked )
			{
				HBSettings.logLevel = Log.LogLevel.Normal;
			}
			else if ( rbLogDebug.Checked )
			{
				HBSettings.logLevel = Log.LogLevel.Debug;
			}
			else
			{
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("logLevel", "Unknown or unspecified log level.");
				ex.Source = this.Name;
				Log.ErrorExit(ex);
			}
			
			Log.level = HBSettings.logLevel;

			if (cbLanguage.SelectedIndex < 0)
			{
				HBSettings.language = "";
			}
			else
			{
				HBSettings.language = ((Language) cbLanguage.SelectedItem).CodeText();
			}
			HBSettings.cleanOnExit = cbCleanOnExit.Checked;
			
			Log.Debug("- Author: " + HBSettings.author);
			Log.Debug("- Company: " + HBSettings.company);
			Log.Debug("- Copyright Template: " + HBSettings.copyrightTemplate);
			Log.Debug("- Working Directory: " + HBSettings.workingDir);
			Log.Debug("- Cleanup on Program Exit: " + cbCleanOnExit.Checked.ToString());
			Log.Debug("- Template Directory: " + HBSettings.templateDir);
			Log.Debug("- Log Directory: " + HBSettings.logDir);
			Log.Debug("- Log Level: " + HBSettings.logLevel.ToString());
			Log.Debug("- Log Files to Keep: " + HBSettings.logsToKeep.ToString());
			if ( HBSettings.Write() )
			{
				Log.Debug("Program settings saved successfully.");
				Close();
			}
			else
			{
				MessageBox.Show(String.Format(rmText.GetString("errorMessage003"), HBSettings.cfgFileName), 
				                rmText.GetString("errorMessage000"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		
		
	}
}
