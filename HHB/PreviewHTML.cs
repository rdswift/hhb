/*
 * Created by SharpDevelop.
 * User: bob
 * Date: 2016-11-13
 * Time: 18:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HHBuilder
{
	/// <summary>
	/// Description of PreviewHTML.
	/// </summary>
	public partial class PreviewHTML : Form
	{
		private string _fileName;
		
		public PreviewHTML(string fileName)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			_fileName = fileName;
		}
		
		void PreviewHTMLLoad(object sender, EventArgs e)
		{
			webBrowser1.Navigate(_fileName);
		}
	}
}
