/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-10-09
 * Time: 13:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */


using System;
using System.Runtime.InteropServices;
using System.Text;

// TODO: Revise this to a static class.

namespace Ini
{
	/// <summary>
	/// Class to manage loading from and saving to an INI file
	/// </summary>
	public class IniFile
	{
		#region Private Member Variables
		/// <summary>
		/// Full path and filename of the INI file
		/// </summary>
		private string _path;
		#endregion

		#region Private Properties
		#endregion
		
		#region Private Methods
		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString( string section, string key, string val, string filePath );
		
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString( string section, string key, string def, StringBuilder retVal, int size, string filePath );
		#endregion
		
		#region Constructors
		// ==============================================================================
		/// <summary>
		/// Create a new object to store or load data from an INI file
		/// </summary>
		/// <PARAM name="filePath">Full path and filename of the INI file</PARAM>
		public IniFile( string filePath )
		{
			_path = filePath.Trim();
		}
		#endregion
		
		#region Public Properties
		public string filePath
		{
			get{ return _path.Trim(); }
			set{ _path = value.Trim(); }
		}
		#endregion
		
		#region Public Methods
		// ==============================================================================
		/// <summary>
		/// Write Data to the INI File
		/// </summary>
		/// <PARAM name="section">Section name</PARAM>
		/// <PARAM name="key">Key name</PARAM>
		/// <PARAM name="value">Value to write</PARAM>
		/// 
		public void IniWriteValue( string section, string key, string value )
		{
			WritePrivateProfileString( section, key, value, this.filePath );
		}
		
		// ==============================================================================
		/// <summary>
		/// Read Data Value From the INI File
		/// </summary>
		/// <PARAM name="section">Section name</PARAM>
		/// <PARAM name="key">Key name</PARAM>
		/// <returns>Value read</returns>
		/// 
		public string IniReadValue( string section, string key )
		{
			StringBuilder temp = new StringBuilder( 255 );
			GetPrivateProfileString( section, key, "", temp, 255, this.filePath );
			return temp.ToString();
		}
		#endregion
		
	}
}