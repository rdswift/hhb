/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-11-04
 * Time: 13:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace HHBuilder
{
	/// <summary>
	/// General settings for an HTML Help Builder project.
	/// </summary>
	public class HHBProject
	{
		#region Private Member Variables
		private string _title;
		private string _fileName;
		private string _author;
		private string _company;
		private string _copyright;
		private string _language;
		private string _defaultTopic;
		private bool _useFullTextSearch;
		private string _template;
		#endregion

		#region Private Properties
		#endregion
		
		#region Private Methods
		// ==============================================================================
		#endregion
		
		#region Constructors
		// ==============================================================================
		/// <summary>
		/// Initialize a new HTML Help Builder Project object. 
		/// </summary>
		public HHBProject()
		{
			title = "New Project";
			filename = String.Empty;
			author = HBSettings.author;
			company = HBSettings.company;
			copyright = HBSettings.Copyright();
			language = HBSettings.language;
			defaultTopic = String.Empty;
			useFullTextSearch = true;
			template = "t00000000000000000";
		}
		#endregion
		
		#region Public Properties
		/// <summary>
		/// The title of the project
		/// </summary>
		public string title
		{
			get { return _title.Trim(); }
			set { _title = value.Trim(); }
		}
		
		/// <summary>
		/// The full path and name of the project file (.hhb)
		/// </summary>
		public string filename
		{
			get { return _fileName.Trim(); }
			set { _fileName = value.Trim(); }
		}
		
		/// <summary>
		/// The author of the help project
		/// </summary>
		public string author
		{
			get { return _author.Trim(); }
			set { _author = value.Trim(); }
		}
		
		/// <summary>
		/// The company developing the help project
		/// </summary>
		public string company
		{
			get { return _company.Trim(); }
			set { _company = value.Trim(); }
		}
		
		/// <summary>
		/// The copyright notice for the project
		/// </summary>
		public string copyright
		{
			get { return _copyright.Trim(); }
			set { _copyright = value.Trim(); }
		}
		
		/// <summary>
		/// The language used for the project
		/// </summary>
		public string language
		{
			get { return _language.Trim(); }
			set { _language = value.Trim(); }
		}
		
		/// <summary>
		/// The default topic to display for the project
		/// </summary>
		public string defaultTopic
		{
			get { return _defaultTopic.Trim(); }
			set { _defaultTopic = value.Trim(); }
		}
		
		/// <summary>
		/// Determines whether the project is compiled with full text search capability 
		/// </summary>
		public bool useFullTextSearch
		{
			get { return _useFullTextSearch; }
			set { _useFullTextSearch = value; }
		}
		
		/// <summary>
		/// The template used when compiling the project
		/// </summary>
		public string template
		{
			get { return _template.Trim(); }
			set { _template = value.Trim(); }
		}
		#endregion
		
		#region Public Methods
		// ==============================================================================
		#endregion
		
		
		
	}
}
