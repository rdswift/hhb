# HHB Specifications (v0.07) - DRAFT
## Interactive HTML Help Builder Development Specifications

The following are the specifications for the development of the application. These specifications are developed and managed by the project team members and are subject to change.

&nbsp;
## 1.0 License
* The program will be open source and released under the ***[GNU GPL v3.0 license](http://www.gnu.org/licenses/gpl.html "http://www.gnu.org/licenses/gpl.html")***.

&nbsp;
## 2.0 Development Platform
* The program will be written in C# with the target framework of .NET Framework 4.5, 32-bit Intel-compatible processor.
* The program will be developed and compiled using ***[Microsoft Visual Studio](https://www.visualstudio.com/ "https://www.visualstudio.com/")*** or a compatable product.

&nbsp;
## 3.0 Overview
The program will be a Windows application 

It will provide the following features:

* graphical user interface (GUI)
* portable (install and use in any directory) (?)
* may use registry, but does not rely on it
* all configuration and project data files stored in plain text
* support templates for help system
* builds CHM file by calling hhc.exe
* manual check for updates and option setting for automatic update checks at program startup
* **INCLUDE ANY ADDITIONAL SUGGESTED FEATURES HERE**

&nbsp;
## 4.0 Distribution / Installation
* source code available via git on GitHub
* source code available for download as ZIP file from GitHub
* executable distributed via ZIP file (?)
* executable distributed via MSI installer (?)
* executable distributed via EXE installer (InnoScript)
* installers include uninstaller

&nbsp;
## 5.0 Data Files
Expect there may be three (or more) types of data files:

* program configuration / defaults
* help system project files (.hhb)
* template files (.hhbt)

&nbsp;
### 5.1 Program Configuration Files
* INI style plain text file
* read from the current user's roaming app data directory
* created if not found
* written to the current user's roaming app data directory

&nbsp;
Information to include in this file:

* default help project author
* default help project company name
* default help project copyright template
* default help project language
* default user interface language
* indicator to remove all working files and directories on exit
* directory to write log files (if used)
* maximum number of log files to keep (if used)
* logging information level
* location of template files (May be relative to program directory by starting with ".\" to accommodate portable application.) (?)
* location of hhc.exe compiler executable (May be relative to program directory by starting with ".\" to accommodate portable application.) (?)
* location of working directory (May be relative to program directory by starting with ".\" to accommodate portable application. Blank entry will use the directory for all users' application-specific data.) (?)
* check for updates at startup indicator
* last 5 help projects (?) (Perhaps this would be better stored in the registry because it may not apply if application is run from a USB stick on a different computer.)
* default template file (?)
* other items?

&nbsp;
### 5.2 Help System Project Files
* one file per help system project
* saved as plain text (xml format)
* contains complete information for help project (except template contents)

&nbsp;
Information to include in this file:

* project information:
    * project name
    * author
    * company
    * copyright
	* language
	* default topic
	* full-text search indicator
    * template used
    * root for html file names (?)
* help screen information (one record per screen)
    * id (unique id assigned by the program)
	* index path (location in project tree assigned by the program)
    * screen type (?) (listed in ToC or popup)
    * title (used in the ToC and the template "Title" section)
	* file name (?)
	* display screen indicator (actual screen or just ToC folder entry)
	* uses template "Title" section indicator
	* uses template "Header" section indicator
	* uses template "Footer" section indicator
    * link id (to call from program context)
	* link description (to display when referenced from another screen)
	* links to other screens (id codes of linked screens, separated by "|")
    * index entries (text entries to use in the index, separated by "|")
    * body (content to insert into the template "Body" section)
	* additional css files used (id codes of CSS files, separated by "|")
	* additional script files used (id codes of script files, separated by "|")
* additional (non-template) CSS files
	* id (unique id assigned by the program)
	* title
	* file name (?) (Generate automatically from id)
	* file contents
* additional (non-template) script files
	* id (unique id assigned by the program)
	* title
	* file name (?) (Generate automatically from id)
	* file contents
* additional (non-template) image files
	* id (unique id assigned by the program)
	* title
	* file extension, including the leading period
	* file name (?) (Generate automatically from id and file extension)
	* file contents (stored in Base 64 format)
    
&nbsp;
### 5.3 Template Files
* stored in a zip format file with the extension changed to ".hhbt", containing the internal directory structure:
	* \ (contains: template.xml, template.htm, LICENSE, README)
	* \tpl_css\ (contains: all CSS files used with the template)
	* \tpl_images\ (contains: all image files used with the template)
	* \tpl_scripts\ (contains: all script files used with the template)
	* \tpl_other\ (contains: any other files to be included with the template)

* template.xml is an XML file with the following format:

~~~
<?xml version="1.0" standalone="yes"?>
<HelpTemplate>
  <TemplateInfo>
    <ID>t00000000000000000</ID>
	<Title>Basic HH Builder Template</Title>
	<Description>Basic template with the index number, title and home link in the header, and the previous and next links in the footer.
	</Description>
	<Author>Bob Swift</Author>
	<Company></Company>
	<ContactName>Bob Swift</ContactName>
	<ContactEmail>bswift@users.sourceforge.net</ContactEmail>
	<ContactWebsite>https://sourceforge.net/projects/oshhb/</ContactWebsite>
	<Version>1.00</Version>
	<RevisionDate>2016-11-02</RevisionDate>
	<LicenseTitle>GPLv3</LicenseTitle>
  </TemplateInfo>
</HelpTemplate>
~~~
 
* template.htm is the HTML file used as a basis for developing the help screens displayed.
    * Contains sections for optional title, header, footer and references.  These can be in any order, but should appear in the order that they will be displayed. The header, footer, title and references sections are bounded by division tags (e.g. &lt;div class="HEADER"&gt;&lt;/div&gt;).  Note that the class entries are all upper case (i.e. "HEADER", "TITLE", "REFERENCES" and "FOOTER").  These classes will be displayed or hidden as specified by the settings for each help screen.
	* The references section contains ***{REFERENCES}*** which will be replaced by the reference titles and links, each bounded by &lt;li class="reference"&gt; ... &lt;/li&gt; tags.  Note that the CSS file should include style settings for the "reference" class.
	* Contains ***{BODY}*** which will be replaced by the information provided by the help system developer for the screen.  This should appear somewhere between the normal &lt;body&gt; ... &lt;/body&gt; tags.
	* May contain any of the following replaceable parameters.  These can appear multiple times if required anywhere within the HTML document.
	    * ***{TITLE}*** will be replaced by the help screen title.
		* ***{PREVLINK}*** will be replaced by a link to the previous screen in the Table of Contents, or "" if no previous page exists.
		* ***{NEXTLINK}*** will be replaced by a link to the next screen in the Table of Contents, or "" if no following page exists.
		* ***{HOMELINK}*** will be replaced by a link to the user-specified default screen, or the first screen in the Table of Contents if not specified.
		* ***{PREVTEXT}*** will be replaced by the title of the previous screen in the Table of Contents, or "" if no previous page exists.
		* ***{NEXTTEXT}*** will be replaced by the title of the next screen in the Table of Contents, or "" if no following page exists.
		* ***{HOMETEXT}*** will be replaced by the title of the user-specified default screen, or the first screen in the Table of Contents if not specified.
		* ***{NUMBER}*** will be replaced with the number of the entry in the Table of Contents (e.g. the third subtopic of the second topic would be number 2.3).  For popup screens this will be "".
		* ***{YEAR}*** will be replaced with the four digit year when the help project was compiled.
		* ***{DATE}*** will be replaced with the date in the format "yyyy-mm-dd" when the help project was compiled.
		* ***{AUTHOR}*** will be replaced with the help project's "Author" setting.
		* ***{COMPANY}*** will be replaced with the help project's "Company" setting.
		* ***{COPYRIGHT}*** will be replaced with the help project's "Copyright" setting.
	
* LICENSE is a text file containing the text of the license terms for the use of the template.  This is displayed to the user when requested.

* README is a text file containing notes regarding the template (e.g.: instructions for use, where to look for updates, anything else).  This file is displayed to the user when selecting a template and in the help project's "Template" section.
	
* For linking purposes, note that all HTML files generated will be placed in the root directory (same directory as the template.htm file).

&nbsp;
## 6.0 User Interface
The graphical user interface should contain screens for the various functions of the program including:

* opening splash screen (?)
* program configuration settings screen
* template management / creation / editing screen (or should this be handled as a separate application?)
* main help project screen showing:
    * project tree (Table of Contents, pop-up screens, and additional CSS, script and image files)
    * help project settings
    * selected help node details including help screen body content editor
    * help screen HTML preview (?)
* help project compiler status screen (showing log entries?) and launcher for compiled help project file
* about screen (include list of contributors / team members)

&nbsp;
The graphical user interface should also include context sensitive help provided by a CHM file.  Ideally, this help system file could be developed using this application.

A command line interface (CLI) will be provided to support batch operations or help file compilation from within an IDE.

&nbsp;
## 7.0 Other Considerations
* multi language support (?)
* spell checking support (?)
* wysiwyg / graphical screen editor (?)

