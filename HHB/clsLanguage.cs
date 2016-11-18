/*
 * Created by SharpDevelop.
 * User: Bob Swift
 * Date: 2016-10-10
 * Time: 11:27
 */
using System;
using System.Collections.Generic;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace HHBuilder
{
	/// <summary>
	/// Class for handling standard language settings including localization resource information.
	/// </summary>
	public class Language
	{
		#region Private Member Variables
		// ==============================================================================
		/// <summary>
		/// Resource manager for localization information
		/// </summary>
		private static ResourceManager _rmText = new ResourceManager("HHBuilder.LanguageText", Assembly.GetExecutingAssembly());
		private static CultureInfo _cultureInfo = CultureInfo.CurrentCulture;
		private static CultureInfo _cultureUiInfo = CultureInfo.CurrentUICulture;
		
		// ==============================================================================
		private string _title;
		private string _code;
		#endregion

		#region Private Properties
		#endregion
		
		#region Private Methods
		// ==============================================================================
		#endregion
		
		#region Constructors
		// ==============================================================================
		#endregion
		
		#region Public Properties
		// ==============================================================================
		/// <summary>
		/// Title and location (if applicable) of the language
		/// </summary>
		public string title
		{ 
			get { return _title.Trim(); }
			set { _title = value.Trim(); }
		}
		
		// ==============================================================================
		/// <summary>
		/// Hexidecimal code for the language in the form 0x0000
		/// </summary>
		public string code 
		{ 
			get { return _code.Trim(); }
			set { _code = value.Trim(); }
		}
		
		// ==============================================================================
		/// <summary>
		/// The current culture setting
		/// </summary>
		public static string culture
		{
			get { return _cultureInfo.Name; }
			set
			{
				CultureInfo tempCulture = _cultureInfo;
				CultureInfo tempUiCulture = _cultureUiInfo;
				try 
				{
					_cultureInfo = new CultureInfo(value.Trim(), false);
					_cultureUiInfo = new CultureInfo(value.Trim(), false);
				} catch (Exception ex) {
					Log.Exception(ex);
					_cultureInfo = tempCulture;
					_cultureUiInfo = tempUiCulture;
					//throw;
				}
				System.Threading.Thread.CurrentThread.CurrentCulture = _cultureInfo;
				System.Threading.Thread.CurrentThread.CurrentUICulture = _cultureUiInfo;
				_rmText = new ResourceManager("HHBuilder.LanguageText", Assembly.GetExecutingAssembly());
			}
		}
		#endregion
		
		#region Public Methods
		// ==============================================================================
		/// <summary>
		/// Available cultures for program localization
		/// </summary>
		/// <returns>Code and title of supported languages for program localization."</returns>
		public static List<Language> SupportedCultureList()
		{ 
			return new List<Language>
			{
				new Language() { title = "English", code = "en-US" }
//				, new Language() { title = "Russian", code = "ru-RU" }
//				, new Language() { title = "Ukrainian", code = "uk-UA" }
			};
		}
		
		// ==============================================================================
		/// <summary>
		/// Language code and title
		/// </summary>
		/// <returns>Code and title in the form "0x0000 Language (optional location)"</returns>
		public string CodeText() 
		{ 
			return string.Format("{0} {1}", code, title); 
		}
		
		// ==============================================================================
		/// <summary>
		/// Returns language specific string from resources.
		/// </summary>
		/// <param name="key">Key to look up in the language resources</param>
		/// <returns>Language string associated with the specified key.</returns>
		public static string GetString(string key)
		{
			return _rmText.GetString(key);
		}
		
		// ==============================================================================
		/// <summary>
		/// Language titles and codes
		/// </summary>
		/// <returns>Complete list of Language class elements</returns>
		public static List<Language> GetList()
		{
			return new List<Language>
			{
				new Language() { title = "Afrikaans (South Africa)", code = "0x0436" },
				new Language() { title = "Albanian (Albania)", code = "0x041C" },
				new Language() { title = "Alsatian", code = "0x0484" },
				new Language() { title = "Amharic (Ethiopia)", code = "0x045E" },
				new Language() { title = "Arabic (Saudi Arabia)", code = "0x0401" },
				new Language() { title = "Arabic (Algeria)", code = "0x1401" },
				new Language() { title = "Arabic (Bahrain)", code = "0x3C01" },
				new Language() { title = "Arabic (Egypt)", code = "0x0C01" },
				new Language() { title = "Arabic (Iraq)", code = "0x0801" },
				new Language() { title = "Arabic (Jordan)", code = "0x2C01" },
				new Language() { title = "Arabic (Kuwait)", code = "0x3401" },
				new Language() { title = "Arabic (Lebanon)", code = "0x3001" },
				new Language() { title = "Arabic (Libya)", code = "0x1001" },
				new Language() { title = "Arabic (Morocco)", code = "0x1801" },
				new Language() { title = "Arabic (Oman)", code = "0x2001" },
				new Language() { title = "Arabic (Qatar)", code = "0x4001" },
				new Language() { title = "Arabic (Syria)", code = "0x2801" },
				new Language() { title = "Arabic (Tunisia)", code = "0x1C01" },
				new Language() { title = "Arabic (U.A.E.)", code = "0x3801" },
				new Language() { title = "Arabic (Yemen)", code = "0x2401" },
				new Language() { title = "Armenian (Armenia)", code = "0x042B" },
				new Language() { title = "Assamese", code = "0x044D" },
				new Language() { title = "Azeri (Cyrillic)", code = "0x082C" },
				new Language() { title = "Azeri (Latin)", code = "0x042C" },
				new Language() { title = "Bashkir", code = "0x046D" },
				new Language() { title = "Basque", code = "0x042D" },
				new Language() { title = "Belarusian", code = "0x0423" },
				new Language() { title = "Bengali (India)", code = "0x0445" },
				new Language() { title = "Bengali (Bangladesh)", code = "0x0845" },
				new Language() { title = "Bosnian (Bosnia/Herzegovina)", code = "0x141A" },
				new Language() { title = "Breton", code = "0x047E" },
				new Language() { title = "Bulgarian", code = "0x0402" },
				new Language() { title = "Burmese", code = "0x0455" },
				new Language() { title = "Catalan", code = "0x0403" },
				new Language() { title = "Cherokee (United States)", code = "0x045C" },
				new Language() { title = "Chinese (People's Republic of China)", code = "0x0804" },
				new Language() { title = "Chinese (Singapore)", code = "0x1004" },
				new Language() { title = "Chinese (Taiwan)", code = "0x0404" },
				new Language() { title = "Chinese (Hong Kong SAR)", code = "0x0C04" },
				new Language() { title = "Chinese (Macao SAR)", code = "0x1404" },
				new Language() { title = "Corsican", code = "0x0483" },
				new Language() { title = "Croatian", code = "0x041A" },
				new Language() { title = "Croatian (Bosnia/Herzegovina)", code = "0x101A" },
				new Language() { title = "Czech", code = "0x0405" },
				new Language() { title = "Danish", code = "0x0406" },
				new Language() { title = "Dari", code = "0x048C" },
				new Language() { title = "Divehi", code = "0x0465" },
				new Language() { title = "Dutch (Netherlands)", code = "0x0413" },
				new Language() { title = "Dutch (Belgium)", code = "0x0813" },
				new Language() { title = "Edo", code = "0x0466" },
				new Language() { title = "English (United States)", code = "0x0409" },
				new Language() { title = "English (United Kingdom)", code = "0x0809" },
				new Language() { title = "English (Australia)", code = "0x0C09" },
				new Language() { title = "English (Belize)", code = "0x2809" },
				new Language() { title = "English (Canada)", code = "0x1009" },
				new Language() { title = "English (Caribbean)", code = "0x2409" },
				new Language() { title = "English (Hong Kong SAR)", code = "0x3C09" },
				new Language() { title = "English (India)", code = "0x4009" },
				new Language() { title = "English (Indonesia)", code = "0x3809" },
				new Language() { title = "English (Ireland)", code = "0x1809" },
				new Language() { title = "English (Jamaica)", code = "0x2009" },
				new Language() { title = "English (Malaysia)", code = "0x4409" },
				new Language() { title = "English (New Zealand)", code = "0x1409" },
				new Language() { title = "English (Philippines)", code = "0x3409" },
				new Language() { title = "English (Singapore)", code = "0x4809" },
				new Language() { title = "English (South Africa)", code = "0x1C09" },
				new Language() { title = "English (Trinidad)", code = "0x2C09" },
				new Language() { title = "English (Zimbabwe)", code = "0x3009" },
				new Language() { title = "Estonian", code = "0x0425" },
				new Language() { title = "Faroese", code = "0x0438" },
				new Language() { title = "Farsi", code = "0x0429" },
				new Language() { title = "Filipino", code = "0x0464" },
				new Language() { title = "Finnish", code = "0x040B" },
				new Language() { title = "French (France)", code = "0x040C" },
				new Language() { title = "French (Belgium)", code = "0x080C" },
				new Language() { title = "French (Cameroon)", code = "0x2C0C" },
				new Language() { title = "French (Canada)", code = "0x0C0C" },
				new Language() { title = "French (Democratic Rep. of Congo)", code = "0x240C" },
				new Language() { title = "French (Cote d'Ivoire)", code = "0x300C" },
				new Language() { title = "French (Haiti)", code = "0x3C0C" },
				new Language() { title = "French (Luxembourg)", code = "0x140C" },
				new Language() { title = "French (Mali)", code = "0x340C" },
				new Language() { title = "French (Monaco)", code = "0x180C" },
				new Language() { title = "French (Morocco)", code = "0x380C" },
				new Language() { title = "French (North Africa)", code = "0xE40C" },
				new Language() { title = "French (Reunion)", code = "0x200C" },
				new Language() { title = "French (Senegal)", code = "0x280C" },
				new Language() { title = "French (Switzerland)", code = "0x100C" },
				new Language() { title = "French (West Indies)", code = "0x1C0C" },
				new Language() { title = "Frisian (Netherlands)", code = "0x0462" },
				new Language() { title = "Fulfulde (Nigeria)", code = "0x0467" },
				new Language() { title = "FYRO Macedonian", code = "0x042F" },
				new Language() { title = "Galician", code = "0x0456" },
				new Language() { title = "Georgian", code = "0x0437" },
				new Language() { title = "German (Germany)", code = "0x0407" },
				new Language() { title = "German (Austria)", code = "0x0C07" },
				new Language() { title = "German (Liechtenstein)", code = "0x1407" },
				new Language() { title = "German (Luxembourg)", code = "0x1007" },
				new Language() { title = "German (Switzerland)", code = "0x0807" },
				new Language() { title = "Greek", code = "0x0408" },
				new Language() { title = "Greenlandic", code = "0x046F" },
				new Language() { title = "Guarani (Paraguay)", code = "0x0474" },
				new Language() { title = "Gujarati", code = "0x0447" },
				new Language() { title = "Hausa (Nigeria)", code = "0x0468" },
				new Language() { title = "Hawaiian (United States)", code = "0x0475" },
				new Language() { title = "Hebrew", code = "0x040D" },
				new Language() { title = "Hindi", code = "0x0439" },
				new Language() { title = "Hungarian", code = "0x040E" },
				new Language() { title = "Ibibio (Nigeria)", code = "0x0469" },
				new Language() { title = "Icelandic", code = "0x040F" },
				new Language() { title = "Igbo (Nigeria)", code = "0x0470" },
				new Language() { title = "Indonesian", code = "0x0421" },
				new Language() { title = "Inuktitut", code = "0x045D" },
				new Language() { title = "Irish", code = "0x083C" },
				new Language() { title = "Italian (Italy)", code = "0x0410" },
				new Language() { title = "Italian (Switzerland)", code = "0x0810" },
				new Language() { title = "Japanese", code = "0x0411" },
				new Language() { title = "K'iche", code = "0x0486" },
				new Language() { title = "Kannada", code = "0x044B" },
				new Language() { title = "Kanuri (Nigeria)", code = "0x0471" },
				new Language() { title = "Kashmiri", code = "0x0860" },
				new Language() { title = "Kashmiri (Arabic)", code = "0x0460" },
				new Language() { title = "Kazakh", code = "0x043F" },
				new Language() { title = "Khmer", code = "0x0453" },
				new Language() { title = "Kinyarwanda", code = "0x0487" },
				new Language() { title = "Konkani", code = "0x0457" },
				new Language() { title = "Korean", code = "0x0412" },
				new Language() { title = "Kyrgyz (Cyrillic)", code = "0x0440" },
				new Language() { title = "Lao", code = "0x0454" },
				new Language() { title = "Latin", code = "0x0476" },
				new Language() { title = "Latvian", code = "0x0426" },
				new Language() { title = "Lithuanian", code = "0x0427" },
				new Language() { title = "Luxembourgish", code = "0x046E" },
				new Language() { title = "Malay (Malaysia)", code = "0x043E" },
				new Language() { title = "Malay (Brunei Darussalam)", code = "0x083E" },
				new Language() { title = "Malayalam", code = "0x044C" },
				new Language() { title = "Maltese", code = "0x043A" },
				new Language() { title = "Manipuri", code = "0x0458" },
				new Language() { title = "Maori (New Zealand)", code = "0x0481" },
				new Language() { title = "Mapudungun", code = "0x047A" },
				new Language() { title = "Marathi", code = "0x044E" },
				new Language() { title = "Mohawk", code = "0x047C" },
				new Language() { title = "Mongolian (Cyrillic)", code = "0x0450" },
				new Language() { title = "Mongolian (Mongolian)", code = "0x0850" },
				new Language() { title = "Nepali", code = "0x0461" },
				new Language() { title = "Nepali (India)", code = "0x0861" },
				new Language() { title = "Norwegian (BokmÃ¥l)", code = "0x0414" },
				new Language() { title = "Norwegian (Nynorsk)", code = "0x0814" },
				new Language() { title = "Occitan", code = "0x0482" },
				new Language() { title = "Oriya", code = "0x0448" },
				new Language() { title = "Oromo", code = "0x0472" },
				new Language() { title = "Papiamentu", code = "0x0479" },
				new Language() { title = "Pashto", code = "0x0463" },
				new Language() { title = "Polish", code = "0x0415" },
				new Language() { title = "Portuguese (Brazil)", code = "0x0416" },
				new Language() { title = "Portuguese (Portugal)", code = "0x0816" },
				new Language() { title = "Punjabi", code = "0x0446" },
				new Language() { title = "Punjabi (Pakistan)", code = "0x0846" },
				new Language() { title = "Quecha (Bolivia)", code = "0x046B" },
				new Language() { title = "Quecha (Ecuador)", code = "0x086B" },
				new Language() { title = "Quecha (Peru)", code = "0x0C6B" },
				new Language() { title = "Rhaeto-Romanic", code = "0x0417" },
				new Language() { title = "Romanian", code = "0x0418" },
				new Language() { title = "Romanian (Moldava)", code = "0x0818" },
				new Language() { title = "Russian", code = "0x0419" },
				new Language() { title = "Russian (Moldava)", code = "0x0819" },
				new Language() { title = "Sami (Lappish)", code = "0x043B" },
				new Language() { title = "Sanskrit", code = "0x044F" },
				new Language() { title = "Scottish Gaelic", code = "0x043C" },
				new Language() { title = "Sepedi", code = "0x046C" },
				new Language() { title = "Serbian (Cyrillic)", code = "0x0C1A" },
				new Language() { title = "Serbian (Latin)", code = "0x081A" },
				new Language() { title = "Sindhi (India)", code = "0x0459" },
				new Language() { title = "Sindhi (Pakistan)", code = "0x0859" },
				new Language() { title = "Sinhalese (Sri Lanka)", code = "0x045B" },
				new Language() { title = "Slovak", code = "0x041B" },
				new Language() { title = "Slovenian", code = "0x0424" },
				new Language() { title = "Somali", code = "0x0477" },
				new Language() { title = "Sorbian", code = "0x042E" },
				new Language() { title = "Spanish (Spain (Modern Sort)", code = "0x0C0A" },
				new Language() { title = "Spanish (Spain (Traditional Sort)", code = "0x040A" },
				new Language() { title = "Spanish (Argentina)", code = "0x2C0A" },
				new Language() { title = "Spanish (Bolivia)", code = "0x400A" },
				new Language() { title = "Spanish (Chile)", code = "0x340A" },
				new Language() { title = "Spanish (Colombia)", code = "0x240A" },
				new Language() { title = "Spanish (Costa Rica)", code = "0x140A" },
				new Language() { title = "Spanish (Dominican Republic)", code = "0x1C0A" },
				new Language() { title = "Spanish (Ecuador)", code = "0x300A" },
				new Language() { title = "Spanish (El Salvador)", code = "0x440A" },
				new Language() { title = "Spanish (Guatemala)", code = "0x100A" },
				new Language() { title = "Spanish (Honduras)", code = "0x480A" },
				new Language() { title = "Spanish (Latin America)", code = "0x580A" },
				new Language() { title = "Spanish (Mexico)", code = "0x080A" },
				new Language() { title = "Spanish (Nicaragua)", code = "0x4C0A" },
				new Language() { title = "Spanish (Panama)", code = "0x180A" },
				new Language() { title = "Spanish (Paraguay)", code = "0x3C0A" },
				new Language() { title = "Spanish (Peru)", code = "0x280A" },
				new Language() { title = "Spanish (Puerto Rico)", code = "0x500A" },
				new Language() { title = "Spanish (United States)", code = "0x540A" },
				new Language() { title = "Spanish (Uruguay)", code = "0x380A" },
				new Language() { title = "Spanish (Venezuela)", code = "0x200A" },
				new Language() { title = "Sutu", code = "0x0430" },
				new Language() { title = "Swahili", code = "0x0441" },
				new Language() { title = "Swedish", code = "0x041D" },
				new Language() { title = "Swedish (Finland)", code = "0x081D" },
				new Language() { title = "Syriac", code = "0x045A" },
				new Language() { title = "Tajik", code = "0x0428" },
				new Language() { title = "Tamazight (Arabic)", code = "0x045F" },
				new Language() { title = "Tamazight (Latin)", code = "0x085F" },
				new Language() { title = "Tamil", code = "0x0449" },
				new Language() { title = "Tatar", code = "0x0444" },
				new Language() { title = "Telugu", code = "0x044A" },
				new Language() { title = "Thai", code = "0x041E" },
				new Language() { title = "Tibetan (Bhutan)", code = "0x0851" },
				new Language() { title = "Tibetan (People's Republic of China)", code = "0x0451" },
				new Language() { title = "Tigrigna (Eritrea)", code = "0x0873" },
				new Language() { title = "Tigrigna (Ethiopia)", code = "0x0473" },
				new Language() { title = "Tsonga", code = "0x0431" },
				new Language() { title = "Tswana", code = "0x0432" },
				new Language() { title = "Turkish", code = "0x041F" },
				new Language() { title = "Turkmen", code = "0x0442" },
				new Language() { title = "Uighur (China)", code = "0x0480" },
				new Language() { title = "Ukrainian", code = "0x0422" },
				new Language() { title = "Urdu", code = "0x0420" },
				new Language() { title = "Urdu (India)", code = "0x0820" },
				new Language() { title = "Uzbek (Cyrillic)", code = "0x0843" },
				new Language() { title = "Uzbek (Latin)", code = "0x0443" },
				new Language() { title = "Venda", code = "0x0433" },
				new Language() { title = "Vietnamese", code = "0x042A" },
				new Language() { title = "Welsh", code = "0x0452" },
				new Language() { title = "Wolof", code = "0x0488" },
				new Language() { title = "Xhosa", code = "0x0434" },
				new Language() { title = "Yakut", code = "0x0485" },
				new Language() { title = "Yi", code = "0x0478" },
				new Language() { title = "Yiddish", code = "0x043D" },
				new Language() { title = "Yoruba", code = "0x046A" },
				new Language() { title = "Zulu", code = "0x0435" }
			};
		}
		#endregion
	}
}
