# HHB Specifications (Draft v1.0)
## Interactive HTML Help Builder Development Specifications

The following are the specifications for the development of the application. These specifications are developed and managed by the project team members and are subject to change.


## 1.0 License

* The program will be open source and released under the ***[GNU GPL v3.0 license](http://www.gnu.org/licenses/gpl.html "http://www.gnu.org/licenses/gpl.html")***.


## 2.0 Development Platform

* The program will be written in C#.
* The program will be developed and compiled using ***[SharpDevelop](https://sourceforge.net/projects/sharpdevelop/ "https://sourceforge.net/projects/sharpdevelop/")***.


## 3.0 Overview

The program will be a Windows application 

It will provide the following features:

* graphical user interface (GUI)
* portable (install and use in any directory)
* all configuration and project data files stored in plain text
* support templates for help system
* builds CHM file by calling hhc.exe
* **INCLUDE ANY ADDITIONAL SUGGESTED FEATURES HERE**


## 4.0 Distribution / Installation

* source code available via git (Sourceforge or GitHub?)
* source code available for download as ZIP file (?)
* executable distributed via ZIP file
* executable distributed via MSI installer (?)
* executable distributed via EXE installer (InnoScript)
* installers include uninstaller


## 5.0 Data Files

Expect there may be three (or more) types of data files:

* program configuration / defaults
* help system project files (.hhb ?)
* template files


### 5.1 Program Configuration Files

* does not need to be plain text
* where should this reside?

Information to include in this file:

* location of template files
* last 5 help projects (?)
* default company name (?)
* default contact info (?)
* default template file (?)
* other items?


### 5.2 Help System Project Files

* one file per help system project
* must be saved as plain text (xml format?)
* contains complete information for help project (except template contents)

Information to include in this file:

* project information:
    * project name
    * root for html file names (?)
    * author
    * company
    * copyright
    * template used
* non-template images information (one record per image)
    * image id
    * name
    * file name
    * path to image file (or image stored in mime format?)
* help screen information (one record per screen)
    * screen id (unique id assigned by the program)
    * parent id
    * type (regular screen listed in ToC, popup, etc.)
    * level
    * index on level
    * add header flag
    * title
    * bookmark name used to create links in other pages (or use screen id)
    * index entries / link title in index (one per entry or separated list?)
    * link id (to call from program context)
    * has body flag (actual screen or just ToC entry)
    * body (content of page to plug into html body)
    

### 5.3 Template Files

* does not need to be plain text (possibly save as ZIP file with with standard directory structure for contents that would provide the initial files and structure to add project-specific information used to build the CHM file)

Information to include in this file:

* title
* author
* date / revision
* html page template with help screen page header
* html page template without help screen page header
* css file(s) used
* javascript file(s) used
* image file(s) used


## 6.0 User Interface

The user interface should contain screens for the various functions of the program including:

* opening splash screen (?)
* program configuration settings screen
* template management / creation / editing screen (or should this be handled as a sepatae application?)
* main help project screen showing:
    * project screen tree
    * help project settings
    * selected help node details including help screen body content editor
    * help screen html preview (?)
* help project compiler status screen (showing log entries?) and launcher for compiled help project file
* about screen (include list of contributors / team members?)

The user interface should also include context sensitive help provided by a CHM file.  Ideally, this help system file could be developed using this application.


## 7.0 Other Considerations

* multi language support (?)
* spell checking support (?)
* wysiwyg / graphical screen editor (?)

