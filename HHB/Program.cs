/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-06-23
 * Time: 10:21
 */
using System;
using System.Windows.Forms;

namespace HHBuilder
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
