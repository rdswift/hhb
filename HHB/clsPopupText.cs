/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-11-03
 * Time: 17:13
 */
using System;

namespace HHBuilder
{
	/// <summary>
	/// The PopupTextItem class is used to manage the information associated with popup<br />
	/// text entries used in a help project.
	/// </summary>
	public class PopupTextItem
	{
		#region Private Member Variables
		// ==============================================================================
		private string _id;
		private string _title;
		private uint _linkID;
		private string _helpText;
		#endregion

		#region Private Properties
		// ==============================================================================
		#endregion
		
		#region Private Methods
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
			return "p" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
		}

		// ==============================================================================
		#endregion
		
		#region Constructors
		// ==============================================================================
		/// <summary>
		/// Information associated with a popup text entry used in a help project. 
		/// </summary>
		public PopupTextItem()
		{
			id = GetID();
			title = String.Format("New Item ID: {0}", id);
			linkID = 0;
			helpText = title;
		}
		#endregion
		
		#region Public Properties
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
		/// Title of the item
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
		public uint linkID
		{
			get{ return _linkID; }
			set{ _linkID = System.Math.Max( 0, value );	}
		}
		
		// ==============================================================================
		/// <summary>
		/// The line of text to display in the popup.
		/// </summary>
		public string helpText
		{
			get{ return _helpText.Trim(); }
			set{ _helpText = value.Trim(); }
		}
		#endregion
		
		#region Public Methods
		// ==============================================================================
		#endregion
	}
}
