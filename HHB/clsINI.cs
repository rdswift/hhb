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

namespace Ini
{
	/// <summary>
	/// Class to manage loading from and saving to an INI file.
	/// </summary>
	public static class IniFile
	{
		#region Private Member Variables
		/// <summary>
		/// Full path and filename of the INI file
		/// </summary>
		private static string _path;
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
		#endregion
		
		#region Public Properties
		
		/// <summary>
		/// The full path and file name of the INI file to read / write.
		/// </summary>
		public static string filePath
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
		/// <param name="section">Section name within the INI file.</param>
		/// <param name="key">Key name within the section.</param>
		/// <param name="value">Value to write to the INI file.</param>
		public static void IniWriteValue( string section, string key, string value )
		{
			WritePrivateProfileString( section, key, value, filePath );
		}
		
		// ==============================================================================
		/// <summary>
		/// Write Data to the INI File
		/// </summary>
		/// <param name="section">Section name within the INI file.</param>
		/// <param name="key">Key name within the section.</param>
		/// <param name="value">Value to write to the INI file.</param>
		/// <param name="fileName">File to write the specified value</param>
		public static void IniWriteValue( string section, string key, string value, string fileName )
		{
			WritePrivateProfileString( section, key, value, fileName );
		}
		
		// ==============================================================================
		/// <summary>
		/// Read Data Value From the INI File
		/// </summary>
		/// <param name="section">Section name within the INI file.</param>
		/// <param name="key">Key name within the section.</param>
		/// <returns>Value read from the INI file.</returns>
		public static string IniReadValue( string section, string key )
		{
			StringBuilder temp = new StringBuilder( 255 );
			GetPrivateProfileString( section, key, "", temp, 255, filePath );
			return temp.ToString();
		}
		
		// ==============================================================================
		/// <summary>
		/// Read Data Value From the INI File
		/// </summary>
		/// <param name="section">Section name within the INI file.</param>
		/// <param name="key">Key name within the section.</param>
		/// <returns>Value read from the INI file.</returns>
		/// <param name="fileName">File to read the specified value</param>
		public static string IniReadValue( string section, string key, string fileName )
		{
			StringBuilder temp = new StringBuilder( 255 );
			GetPrivateProfileString( section, key, "", temp, 255, fileName );
			return temp.ToString();
		}
		#endregion
	}
}