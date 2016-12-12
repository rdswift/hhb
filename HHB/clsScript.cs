/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-08-11
 * Time: 14:25
 */
using System;

namespace HHBuilder
{
	/// <summary>
	/// The ScriptItem class is used to manage the information associated with additional<br />
	/// scripts used in a help project.
	/// </summary>
	public class ScriptItem
	{
		#region Private Member Variables
		private string _id;
		private string _fileName;
		private string _title;
		private string _content;
		#endregion

		#region Private Properties
		#endregion
		
		#region Private Methods
		// ==============================================================================
		/// <summary>
		/// Prepare a unique ID based on the current timestamp
		/// </summary>
		/// <returns>
		/// Unique ID string
		/// </returns>
		private static string GetID()
		{
			// Time Based Key - should be sufficient for this application
			System.Threading.Thread.Sleep(2);
			return "s" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		/// <summary>
		/// Create a new ScriptItem object
		/// </summary>
		public ScriptItem()
		{
			id = GetID();
			//fileName = "Scr_" + id + ".js";
			_fileName = id + ".js";
			title = string.Format("Script ID: {0}", id);
			content = "// User-Defined Additional Script File\n\n";
		}
		
		// ==============================================================================
		/// <summary>
		/// Create a new ScriptItem object
		/// </summary>
		/// <param name="itemTitle">Title of script object</param>
		/// <param name="itemContent">Contents of the script file</param>
		public ScriptItem(string itemTitle, string itemContent)
		{
			id = GetID();
			_fileName = id + ".js";
			title = itemTitle;
			content = itemContent;
		}
		
		// ==============================================================================
		/// <summary>
		/// Create a new ScriptItem object
		/// </summary>
		/// <param name="itemFileName">Name of output script file</param>
		/// <param name="itemTitle">Title of script object</param>
		/// <param name="itemContent">Contents of the script file</param>
		public ScriptItem(string itemFileName, string itemTitle, string itemContent)
		{
			id = GetID();
			_fileName = itemFileName;	// TODO: Remove this line
			_fileName = id + ".js";
			title = itemTitle;
			content = itemContent;
		}
		
		// ==============================================================================
		/// <summary>
		/// Create a new ScriptItem object
		/// </summary>
		/// <param name="itemID">Unique ID</param>
		/// <param name="itemFileName">Name of output script file</param>
		/// <param name="itemTitle">Title of script object</param>
		/// <param name="itemContent">Contents of the script file</param>
		public ScriptItem(string itemID, string itemFileName, string itemTitle, string itemContent)
		{
			id = itemID;
			_fileName = itemFileName;	// TODO: Remove this line
			_fileName = id + ".js";
			title = itemTitle;
			content = itemContent;
		}
		#endregion
		
		#region Public Properties
		// ==============================================================================
		/// <summary>
		/// Unique ID
		/// </summary>
		public string id
		{
			get{ return _id.Trim(); }
			set{ _id = value.Trim(); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Name of output script file
		/// </summary>
		public string fileName
		{
			// TODO: Update to disallow assigning a file name (including in Main Form).  Use ID + ".js" for file name.

			//get{ return _fileName.Trim(); }
			get{ return _id + ".js"; }
			set
			{
				if ( String.IsNullOrWhiteSpace(_fileName) )
				{
					_fileName = value.Trim();
				}
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// Title of script object
		/// </summary>
		public string title
		{
			get{ return _title.Trim(); }
			set{ _title = value.Trim(); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Content of the script file
		/// </summary>
		public string content
		{
			get{ return _content.Trim(); }
			set{ _content = value.Trim(); }
		}
		#endregion
		
		#region Public Methods
		// ==============================================================================
		/// <summary>
		/// Write the script file in the specified directory
		/// </summary>
		/// <param name="outputDirectory">Directory to write the file.  Uses current directory if blank.</param>
		/// <returns>True on success, otherwise false.</returns>
		public bool WriteFile(string outputDirectory)
		{
			string outputPath = outputDirectory.Trim();
			if (( !String.IsNullOrEmpty(outputPath) ) && ( !System.IO.Directory.Exists(outputPath) ))
			{
				try
				{
					System.IO.Directory.CreateDirectory(outputPath);
				}
				catch
				{
					return false;
				}
			}
			outputPath = System.IO.Path.Combine(outputPath, fileName);
			try
			{
				System.IO.File.WriteAllText(outputPath, content);
			}
			catch
			{
				return false;
			}
			return true;
		}
		#endregion
	}
}
