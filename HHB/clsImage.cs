/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-08-11
 * Time: 14:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HHBuilder
{
	/// <summary>
	/// Description of ImageItem class.
	/// The ImageItem class is used to manage the information associated with additional<br />
	/// images used in a help project.
	/// </summary>
	public class ImageItem
	{
		#region Private Member Variables
		private string _id;
		private string _extension;
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
			return "i" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
		}
		#endregion
		
		#region Constructors
		// ==============================================================================
		/// <summary>
		/// Creates a new imageItem object 
		/// </summary>
		public ImageItem()
		{
			_id = GetID();
			title = string.Format("Image ID: {0}", id);
			_extension = "";
			_content = "";
		}
		
		// ==============================================================================
		/// <summary>
		/// Creates a new imageItem object 
		/// </summary>
		/// <param name="imageFileName">Path and file name of the image</param>
		public ImageItem(string imageFileName)
		{
			_id = GetID();
			title = string.Format("Image ID: {0}", id);
			//_fileName = "Img_" + id + System.IO.Path.GetExtension(imageFileName);
			_extension = System.IO.Path.GetExtension(imageFileName);
			_content = GetFileContents(imageFileName);
		}
		#endregion
		
		#region Public Properties
		/// <summary>
		/// Unique identifier.
		/// </summary>
		public string id
		{
			get{ return _id.Trim(); }
			set{ _id = value.Trim(); }
		}
		
		/// <summary>
		/// Name used for the image file produced.
		/// </summary>
		public string fileName
		{
			get{ return id + extension; }
		}
		
		/// <summary>
		/// The extension of the image file (including the period).
		/// </summary>
		public string extension
		{
			get{ return _extension.Trim(); }
			set{ _extension = value.Trim(); }
		}
		
		/// <summary>
		/// The title of the image file.
		/// </summary>
		public string title
		{
			get{ return _title.Trim(); }
			set{ _title = value.Trim(); }
		}
		
		/// <summary>
		/// The content of the image file in Base 64 format.
		/// </summary>
		public string content
		{
			get{ return _content.Trim(); }
			set{ _content = value.Trim(); }
		}
		
		/// <summary>
		/// The content of the image file as an image object.
		/// </summary>
		public Image image
		{
			get{ return GetImage(content); }
		}
		#endregion
		
		#region Public Methods
		// ==============================================================================
		/// <summary>
		/// Reads the specified image file and updates the imageItem contents
		/// </summary>
		/// <param name="imageFileName">Path and file name of the image file</param>
		/// <returns>True on success, otherwise false.</returns>
		public bool LoadFile(string imageFileName)
		{
			if ( System.IO.File.Exists(imageFileName) )
			{
				string tempContent = GetFileContents(imageFileName);
				if ( !String.IsNullOrEmpty(tempContent) )
				{
					_content = tempContent;
					//_fileName = "Img_" + id + System.IO.Path.GetExtension(imageFileName);
					_extension = System.IO.Path.GetExtension(imageFileName);
					return true;
				}
			}
			return false;
		}
		
		// ==============================================================================
		/// <summary>
		/// Converts the specified image file to a Base 64 string
		/// </summary>
		/// <param name="imageFileName">Path and file name of the image file</param>
		/// <returns>Base 64 string of the image file</returns>
		public static string GetFileContents(string imageFileName)
		{
			string RetVal = "";
			if (System.IO.File.Exists(imageFileName)) {
				Byte[] bytes = System.IO.File.ReadAllBytes(imageFileName);
				string s1 = Convert.ToBase64String(bytes);
				RetVal = System.Text.RegularExpressions.Regex.Replace(s1, ".{128}", "$0\n");
			}
			return RetVal;
		}
		
		// ==============================================================================
		/// <summary>
		/// Converts a string to an image
		/// </summary>
		/// <param name="Base64String">Base 64 string of the image file content</param>
		/// <returns>The resulting image</returns>
		public static Image GetImage(string Base64String)
		{
			byte[] bArray = Convert.FromBase64String(Base64String);
			return GetImage(bArray);
		}
		
		// ==============================================================================
		/// <summary>
		/// Converts a string to an image
		/// </summary>
		/// <param name="byteArrayIn">Byte array of the image file content</param>
		/// <returns>The resulting image</returns>
		public static Image GetImage(byte[] byteArrayIn)
		{
			using (var ms = new MemoryStream(byteArrayIn))
			{
				return Image.FromStream(ms);
			}
		}
		
		// ==============================================================================
		public static DataTable GetAvailableImages(TreeNode node)
		{
			DataTable dt = new DataTable();
			dt.TableName = "Images";
			DataColumn dc = new DataColumn("ID", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("Title", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dc = new DataColumn("FileName", Type.GetType("System.String"));
			dt.Columns.Add(dc);
			dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };
			
			foreach (TreeNode tNode in HelpNode.GetRootNode(node).Nodes[(int) HelpNode.branches.imageFile].Nodes)
			{
				ImageItem tItem = (ImageItem) tNode.Tag;
				DataRow dr = dt.NewRow();
				dr["ID"] = tItem.id;
				dr["Title"] = tItem.title;
				dr["FileName"] = tItem.fileName;
				dt.Rows.Add(dr);
			}
			
			return dt;
		}
		#endregion
	}
}
