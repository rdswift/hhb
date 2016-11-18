/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-06-23
 * Time: 14:46
 */

using System;
using System.Text;

namespace HHBuilder
{
	/// <summary>
	/// Help screen item class.
	/// </summary>
	public class HelpItem
	{
		#region Private Member Variables
		private string _id;
		private ScreenType _screenType;
		//private int _level;
		private bool _hasScreen;
		private bool _usesTitle;
		private bool _usesHeader;
		private bool _usesFooter;
		private string _title;
		private int _linkID;
		private string _linkDescription;
		private string _linkList;
		private string _indexEntries;
		private string _body;
		private string _cssList;
		private string _scriptList;
		#endregion

		#region Private Properties
		#endregion
		
		#region Private Methods
		// ==============================================================================
		/// <summary>
		/// Cleans joined string of empty elements and trims each element
		/// </summary>
		/// <param name="listStringToClean">Joined string to clean</param>
		/// <returns>Cleaned string</returns>
		private string CleanList( string listStringToClean )
		{
			string workingString = listStringToClean.Trim();
			int stringLength = 0;
			while (stringLength != workingString.Length) {
				workingString = workingString.Trim( '|' );
				workingString = workingString.Replace( " |", "|" );
				workingString = workingString.Replace( "| ", "|" );
				workingString = workingString.Replace( "||", "|" );
				workingString = workingString.Trim();
				stringLength = workingString.Length;
			}
			return workingString;
		}
		
		// ==============================================================================
		/// <summary>
		/// Prepare a unique ID based on the current timestamp
		/// </summary>
		/// <returns>
		/// Unique ID string
		/// </returns>
		private string GetID()
		{
			// Time Based Key - should be sufficient for this application
			System.Threading.Thread.Sleep(2);
			return "h" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		/// <summary>
		/// Create a new HelpItem object
		/// </summary>
		public HelpItem()
		{
			id = GetID();
			screenType = ScreenType.TOC;
			title = String.Format("New Item ID: {0}", id);
			linkID = 0;
			linkDescription = title;
			linkList = String.Empty;
			cssList = String.Empty;
			scriptList = String.Empty;
			indexEntries = String.Empty;
			body = String.Empty;
			hasScreen = true;
			usesTitle = true;
			usesHeader = true;
			usesFooter = true;
		}
		#endregion
		
		#region Public Properties
		// ==============================================================================
		/// <summary>
		/// Type of screen for an HTML Help item
		/// </summary>
		public enum ScreenType
		{
			/// <summary>
			/// Topic appears in the Table of Contents
			/// </summary>
			TOC,
			
			/// <summary>
			/// Topic appears as a popup screen
			/// </summary>
			Popup
		};
		
		// ==============================================================================
		/// <summary>
		/// Unique identifier for the item
		/// </summary>
		public string id
		{ 
			get{ return _id.Trim(); }
			set{ _id = value.Trim(); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Type of screen for the topic (Toc or Popup)
		/// </summary>
		public ScreenType screenType
		{
			get{ return _screenType; }
			set{ _screenType = value; }
		}
		
		// ==============================================================================
		/// <summary>
		/// Name of the topic output file
		/// </summary>
		public string fileName
		{
			get{ return String.Format("{0}.html", id); }
		}
		
		// ==============================================================================
		/// <summary>
		/// The topic has a screen to display.
		/// </summary>
		public bool hasScreen
		{
			get{ return _hasScreen; }
			set{ _hasScreen = value; }
		}
		
		// ==============================================================================
		/// <summary>
		/// Displays the Title section of the template
		/// </summary>
		public bool usesTitle
		{
			get{ return _usesTitle; }
			set{ _usesTitle = value; }
		}
		
		// ==============================================================================
		/// <summary>
		/// Displays the Header section of the template 
		/// </summary>
		public bool usesHeader
		{
			get{ return _usesHeader; }
			set{ _usesHeader = value; }
		}
		
		// ==============================================================================
		/// <summary>
		/// Displays the Footer section of the template
		/// </summary>
		public bool usesFooter
		{
			get{ return _usesFooter; }
			set{ _usesFooter = value; }
		}
		
		// ==============================================================================
		/// <summary>
		/// The title for the topic
		/// </summary>
		public string title
		{
			get{ return _title.Trim(); }
			set{ _title = value.Trim(); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Number assigned to the topic when called from an external application 
		/// </summary>
		public int linkID
		{
			get{ return _linkID; }
			set{ _linkID = System.Math.Max( 0, value );	}
		}
		
		// ==============================================================================
		/// <summary>
		/// Default text to display when this topic is linked from another topic. 
		/// </summary>
		public string linkDescription
		{
			get{ return _linkDescription.Trim(); }
			set{ _linkDescription = value.Trim(); }
		}
		
		// ==============================================================================
		/// <summary>
		/// List of other topic IDs linked from this topic, separated by a vertical bar (|).
		/// </summary>
		public string linkList
		{
			get{ return CleanList(_linkList); }
			set{ _linkList = CleanList(value); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Array of other topic IDs linked from this topic.
		/// </summary>
		public string[] linkArray
		{
			get
			{
				if ( String.IsNullOrWhiteSpace(_linkList) )
				{
					return new string[0];
				}
				else
				{
					return CleanList(_linkList).Split('|');
				}
			}
			
			set
			{
				_linkList = CleanList(String.Join("|", value));
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// List of additional cascading style sheet IDs loaded for this topic, separated by a vertical bar (|).
		/// </summary>
		public string cssList
		{
			get{ return CleanList(_cssList); }
			set{ _cssList = CleanList(value); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Array of additional cascading style sheet IDs loaded for this topic.
		/// </summary>
		public string[] cssArray
		{
			get
			{
				if ( String.IsNullOrWhiteSpace(_cssList) )
				{
					return new string[0];
				}
				else
				{
					return CleanList(_cssList).Split('|');
				}
			}
			
			set
			{
				_cssList = CleanList(String.Join("|", value));
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// List of additional Javascript file IDs loaded for this topic, separated by a vertical bar (|).
		/// </summary>
		public string scriptList
		{
			get{ return CleanList(_scriptList); }
			set{ _scriptList = CleanList(value); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Array of additional Javascript file IDs loaded for this topic.
		/// </summary>
		public string[] scriptArray
		{
			get
			{
				if ( String.IsNullOrWhiteSpace(_scriptList) )
				{
					return new string[0];
				}
				else
				{
					return CleanList(_scriptList).Split('|');
				}
			}
			
			set
			{
				_scriptList = CleanList(String.Join("|", value));
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// List of entries to be included in the Index for the topic, separated by a vertical bar (|).
		/// <para>Each entry is of the form "optional group`text of the entry" or "text of the entry".</para>
		/// <para>If the entry includes a group, it is separated from the entry text by a back tic (`).</para>
		/// </summary>
		public string indexEntries
		{
			get{ return CleanList(_indexEntries); }
			set{ _indexEntries = CleanList(value); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Array of entries to be included in the Index for the topic.
		/// <para>Each entry is of the form "optional group`text of the entry" or "text of the entry".</para>
		/// <para>If the entry includes a group, it is separated from the entry text by a back tic (`).</para>
		/// </summary>
		public string[] indexArray
		{
			get
			{
				if ( String.IsNullOrWhiteSpace(_indexEntries) )
				{
					return new string[0];
				}
				else
				{
					return CleanList(_indexEntries).Split('|');
				}
			}
			
			set
			{
				_indexEntries = CleanList(String.Join("|", value));
			}
		}
		
		// ==============================================================================
		/// <summary>
		/// The body contents for the help topic.  May include replaceable parameters as required.
		/// </summary>
		public string body
		{
			get{ return _body.Trim(); }
			set{ _body = value.Trim(); }
		}
		#endregion
		
		#region Public Methods
		// ==============================================================================
		/// <summary>
		/// Create a copy of the HelpItem
		/// </summary>
		/// <returns></returns>
		public HelpItem Copy()
		{
			HelpItem newItem = new HelpItem();
			//newItem.linkID = this.linkID;					// Don't copy to new HelpItem
			newItem.screenType = this.screenType;
			newItem.title = this.title;
			newItem.linkDescription = this.linkDescription;
			newItem.indexEntries = this.indexEntries;
			newItem.body = this.body;
			newItem.hasScreen = this.hasScreen;
			newItem.usesTitle = this.usesTitle;
			newItem.usesHeader = this.usesHeader;
			newItem.usesFooter = this.usesFooter;
			
			return newItem;
		}
		#endregion
	}
}
