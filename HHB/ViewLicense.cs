/*
 * Created by SharpDevelop.
 * User: bob
 * Date: 2016-11-14
 * Time: 15:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HHBuilder
{
	/// <summary>
	/// Description of ViewLicense.
	/// </summary>
	public partial class ViewLicense : Form
	{
		
		public ViewLicense(string licenseText)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			if ( String.IsNullOrWhiteSpace(licenseText) )
			{
				textBox1.Text = "No license text found.";
			}
			else
			{
				textBox1.Text = licenseText;
			}
			textBox1.DeselectAll();
		}
	}
}
