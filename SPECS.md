# HHB Specifications (v0.04) - DRAFT
## Interactive HTML Help Builder Development Specifications

The following are the specifications for the development of the application. These specifications are developed and managed by the project team members and are subject to change.

&nbsp;
## 1.0 License
* The program will be open source and released under the ***[GNU GPL v3.0 license](http://www.gnu.org/licenses/gpl.html "http://www.gnu.org/licenses/gpl.html")***.

&nbsp;
## 2.0 Development Platform
* The program will be written in C# with the target framework of .NET Framework 4.5, 32-bit Intel-compatible processor.
* The program will be developed and compiled using ***[SharpDevelop](https://sourceforge.net/projects/sharpdevelop/ "https://sourceforge.net/projects/sharpdevelop/")*** or a compatible tool such as ***[Microsoft Visual Studio](https://www.visualstudio.com/ "https://www.visualstudio.com/")***.

&nbsp;
## 3.0 Overview
The program will be a Windows application 

It will provide the following features:

* graphical user interface (GUI)
* portable (install and use in any directory)
* may use registry, but does not rely on it
* all configuration and project data files stored in plain text
* support templates for help system
* builds CHM file by calling hhc.exe
* manual check for updates and option setting for automatic update checks at program startup
* **INCLUDE ANY ADDITIONAL SUGGESTED FEATURES HERE**

&nbsp;
## 4.0 Distribution / Installation
* source code available via git on Sourceforge (and GitHub)
* source code available for download as ZIP file (from GitHub)
* executable distributed via ZIP file
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
* read from the first configuration file found in the following locations (checked in order of preference): (1) program directory; (2) the current roaming user app data directory.
* created if not found
* written to the first directory with write access at the following locations (checked in order of preference): (1) program directory; (2) the current roaming user app data directory.

&nbsp;
Information to include in this file:

* default help project author
* default help project company name
* default help project copyright template
* default help project language
* full path and name of log file (if used)
* logging information level (if used)
* location of template files (May be relative to program directory by starting with ".\" to accommodate portable application.)
* location of hhc.exe compiler executable (May be relative to program directory by starting with ".\" to accommodate portable application.)
* location of working directory (May be relative to program directory by starting with ".\" to accommodate portable application. Blank entry will use the directory for all users' application-specific data.)
* check for updates at startup indicator
* last 5 help projects (Perhaps this would be better stored in the registry because it may not apply if application is run from a USB stick on a different computer.)
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
    * screen type (listed in ToC or popup)
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
	* file name
	* file contents
* additional (non-template) script files
	* id (unique id assigned by the program)
	* title
	* file name
	* file contents
* additional (non-template) image files
	* id (unique id assigned by the program)
	* title
	* file name
	* file contents (stored in Base 64 format)
    
&nbsp;
### 5.3 Template Files
* stored in a zip format file with the extension changed to ".hhbt" containing the internal directory structure:
	* \ (contains: template.txt, template.html, license.txt)
	* \tpl_css\ (contains: all CSS files used with the template)
	* \tpl_images\ (contains: all image files used with the template)
	* \tpl_scripts\ (contains: all script files used with the template)
	* \tpl_other\ (contains: any other files to be included with the template)

* template.txt is an INI style file with the following format:

~~~
;=====================================================================
;              HTML Builder Template Information
;=====================================================================

[Identification]
;---------------------------------------------------------------------
; ID: Unique template id code (assigned by HHB when template created)
; Title: Title of the temple to show in the selection list
; Description: Brief description of the template
;---------------------------------------------------------------------
ID=t00000000000000000
Title=Default Template
Description=Basic template with index number, title and home link in the header, and previous and next links in the footer.

[Developer]
;---------------------------------------------------------------------
; Author: Name of the person that developed the template
; Company: Name of the company (if applicable)
; Contact: Name of person to contact about the template
; Email: Email address of the contact person
; Website: Website address (if applicable)
;---------------------------------------------------------------------
Author=Bob Swift
Company=R.S. Digital Solutions
Contact=Bob Swift
Email=bswift@rsds.ca
Website=https://sourceforge.net/projects/oshhb/

[Miscellaneous]
;---------------------------------------------------------------------
; Version: The version or revision number
; Date: The date of the latest revision
; License: The type of license for the template
;---------------------------------------------------------------------
Version=1.00
Date=2016-10-19
License=GPLv3
~~~
 
* license.txt is the full text of the license for the use of the template

* template.html is the html file used as a basis for developing the help screens displayed.
	* Contains sections for optional title, header, footer and references.  These can be in any order, but should appear in the order that they will be displayed. The header, footer and title sections are bounded by comment elements (e.g. "&lt;!-HEADER" above and "HEADER--&gt;" below).
	* The references section contains "{REFERENCES}" which will be replaced by the reference titles and links, each bounded by &lt;li class="reference"&gt; ... &lt;/li&gt; tags.  Note that the CSS file should include style settings for the "reference" class.
	* Contains "{BODY}" which will be replaced by the information provided by the help system developer for the screen.  This should appear somewhere between the normal &lt;body&gt; ... &lt;/body&gt; tags.
	* May contain "{TITLE}" tag which will be replaced by the help screen title.  This can appear multiple times if required anywhere within the html document.
	* May contain "{PREVLINK}", "{NEXTLINK}", "{HOMELINK}", "{PREVTEXT}", "{NEXTTEXT}" and "{HOMETEXT}" tags which will be replaced with the corresponding link and title.  If an item is unavailable, the link will be "" and the title will be "None".
	* May contain "{NUMBER}" which will be replaced with the number of the entry in the Table of Contents (e.g. the third subtopic of the second topic would be number 2.3).  For popup screens this will be "".
	
* For linking purposes, note that all html files generated will be placed in the root directory (same directory as the template.html file).

&nbsp;
## 6.0 User Interface
The user interface should contain screens for the various functions of the program including:

* opening splash screen (?)
* program configuration settings screen
* template management / creation / editing screen (or should this be handled as a sepatae application?)
* main help project screen showing:
    * project tree (Table of Contents, popup screens, and additional CSS, script and image files)
    * help project settings
    * selected help node details including help screen body content editor
    * help screen html preview (?)
* help project compiler status screen (showing log entries?) and launcher for compiled help project file
* about screen (include list of contributors / team members)

&nbsp;
The user interface should also include context sensitive help provided by a CHM file.  Ideally, this help system file could be developed using this application.

&nbsp;
## 7.0 Other Considerations
* multi language support
* spell checking support (?)
* wysiwyg / graphical screen editor (?)

