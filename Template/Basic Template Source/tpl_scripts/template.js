/////////////////////////////////////////////////////////////////////////////
//                                                                         //
//  Standard HTML Template Functions                           2016-10-20  //
//  Copyright 2016, Bob Swift.  Released under GPLv3.0.                    //
//                                                                         //
/////////////////////////////////////////////////////////////////////////////

function PrintHome(myLink, myText, myNumber) {
	var linkLength = myLink.length;
	var textLength = myText.length;
	if ((linkLength > 0) && (textLength > 0)) {
		//document.write('<a href="' + myLink + '">Home: <span class="HEADERNUMBER">' + myNumber + '</span> ' + myText + '</a>');
		document.write('<a href="' + myLink + '"><span class="HEADERNUMBER">' + myNumber + '</span> ' + myText + ' <img alt="Home:" src="tpl_images/UpArrow.png" /></a>');
	}
	return true;
}

function PrintPrevious(myLink, myText, myNumber) {
	var linkLength = myLink.length;
	var textLength = myText.length;
	if ((linkLength > 0) && (textLength > 0)) {
		//document.write('<a href="' + myLink + '">Previous: <span class="FOOTERNUMBER">' + myNumber + '</span> ' + myText + '</a>');
		document.write('<a href="' + myLink + '"><img alt="Previous:" src="tpl_images/LeftArrow.png" /> <span class="FOOTERNUMBER">' + myNumber + '</span> ' + myText + '</a>');
	}
	return true;
}

function PrintNext(myLink, myText, myNumber) {
	var linkLength = myLink.length;
	var textLength = myText.length;
	if ((linkLength > 0) && (textLength > 0)) {
		//document.write('<a href="' + myLink + '">Next: <span class="FOOTERNUMBER">' + myNumber + '</span> ' + myText + '</a>');
		document.write('<a href="' + myLink + '"><span class="FOOTERNUMBER">' + myNumber + '</span> ' + myText + ' <img alt="Next:" src="tpl_images/RightArrow.png" /></a>');
	}
	return true;
}


///////////////////////////////////////////////////////////////////////////
//                                                                       //
//   End of File                                                         //
//                                                                       //
///////////////////////////////////////////////////////////////////////////

