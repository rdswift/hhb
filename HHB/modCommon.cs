/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-10-11
 * Time: 15:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Windows.Forms;

namespace HHBuilder
{
	/// <summary>
	/// Collection of miscellaneous utilities.
	/// </summary>
	public partial class RSDSUtils
	{

		// ==============================================================================
		/// <summary>
		/// Displays a standard error messagebox with an Okay button.
		/// </summary>
		/// <param name="Message">A string containing the message to be displayed.</param>
		/// 
		public static void ErrorBox(string Message)
		{
			MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}


		
	}
}
