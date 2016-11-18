/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-11-13
 * Time: 18:28
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HHBuilder
{
	/// <summary>
	/// Form for previewing an HTML help item.
	/// </summary>
	public partial class PreviewHTML : Form
	{
		#region Private Member Variables
		private string _fileName;
		#endregion

		#region Private Properties
		// ==============================================================================
		#endregion
		
		#region Private Methods
		// ==============================================================================
		void PreviewHTMLLoad(object sender, EventArgs e)
		{
			webBrowser1.Navigate(_fileName);
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		/// <summary>
		/// Form for previewing an HTML help item.
		/// </summary>
		/// <param name="fileName">Full path and name of the HTML file to display.</param>
		public PreviewHTML(string fileName)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			_fileName = fileName;
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
