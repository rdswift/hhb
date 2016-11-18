/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-11-14
 * Time: 15:20
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HHBuilder
{
	/// <summary>
	/// Form to view the license for a template.
	/// </summary>
	public partial class ViewLicense : Form
	{
		#region Private Member Variables
		private string _licenseText;
		#endregion

		#region Private Properties
		// ==============================================================================
		#endregion
		
		#region Private Methods
		// ==============================================================================
		void ViewLicenseLoad(object sender, EventArgs e)
		{
			if ( String.IsNullOrWhiteSpace(_licenseText) )
			{
				textBox1.Text = "No license text found.";
			}
			else
			{
				textBox1.Text = _licenseText;
			}
			textBox1.DeselectAll();
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		/// <summary>
		/// View the license for a template.
		/// </summary>
		/// <param name="licenseText">License text to display.</param>
		public ViewLicense(string licenseText)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			_licenseText = licenseText;
			
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
