


//=======================================================================

// Copyright ? 2000 by Apple Computer, Inc., All Rights Reserved.
//
// You may incorporate this Apple sample code into your own code
// without restriction. This Apple sample code has been provided "AS IS"
// and the responsibility for its operation is yours. You may redistribute
// this code, but you are not permitted to redistribute it as
// "Apple sample code" after having made changes.
//
// ************************
// layer utility routines *
// ************************
function getStyleObject(objectId) {
    // cross-browser function to get an object's style object given its id
    if(document.getElementById && document.getElementById(objectId)) {
	// W3C DOM
	return document.getElementById(objectId).style;
    } else if (document.all && document.all(objectId)) {
	// MSIE 4 DOM
	return document.all(objectId).style;
    } else if (document.layers && document.layers[objectId]) {
	// NN 4 DOM.. note: this won't find nested layers
	return document.layers[objectId];
    } else {
	return false;
    }
} // getStyleObject

function getObject(objectId) {
	// cross-browser function to get an object's style object given its id
    if(document.getElementById && document.getElementById(objectId)) {
	// W3C DOM
	return document.getElementById(objectId);
    } else if (document.all && document.all(objectId)) {
	// MSIE 4 DOM
	return document.all(objectId);
    } else if (document.layers && document.layers[objectId]) {
	// NN 4 DOM.. note: this won't find nested layers
	return document.layers[objectId];
    } else {
	return false;
    }
}

function changeObjectVisibility(objectId, newVisibility) {
    // get a reference to the cross-browser style object and make sure the object exists
    var styleObject = getStyleObject(objectId);
    if(styleObject) {
		styleObject.visibility = newVisibility;
		return true;
    } else {
		// we couldn't find the object, so we can't change its visibility
		return false;
    }
} // changeObjectVisibility


function setObjectDisplay(objectId, display) {
	var styleObject = getStyleObject(objectId);
	var d = display;
	if(!display) d = 'none';
    if(styleObject) {
		styleObject.display = d;
		return true;
    } else {
		// we couldn't find the object, so we can't change its visibility
		return false;
    }
}

function showHideObject(elt, vis) {
	if(! elt) {
		return;
	}

	if(vis) {
		elt.style.display = "inline";
	}
	else {
		elt.style.display = "none";
	}
}


function moveObject(objectId, newXCoordinate, newYCoordinate) {
    // get a reference to the cross-browser style object and make sure the object exists
    var styleObject = getStyleObject(objectId);
    if(styleObject && newXCoordinate && newYCoordinate) {
	styleObject.left = newXCoordinate;
	styleObject.top = newYCoordinate;
	return true;
    } else {
	// we couldn't find the object, so we can't very well move it
	return false;
    }
} // moveObject



// store variables to control where the popup will appear relative to the cursor position
// positive numbers are below and to the right of the cursor, negative numbers are above and to the left
var xOffset = 30;
var yOffset = -5;

function showPopup (targetObjectId, eventObj, elementName) {
	if (elementName) {
		// hide any currently-visible popups
		hideCurrentPopup();
		
		var field = getFieldObject(elementName);
		if (field) {
			var arr = findPosition(field);
			var newXCoordinate = arr[0] + field.offsetWidth;
			var newYCoordinate = arr[1];
						
			moveObject(targetObjectId, newXCoordinate, newYCoordinate);
			// and make it visible
			if( changeObjectVisibility(targetObjectId, 'visible') ) {
				// if we successfully showed the popup
				// store its Id on a globally-accessible object
				window.currentlyVisiblePopup = targetObjectId;
				return true;
			} else {
				// we couldn't show the popup, boo hoo!
				return false;
			}
		}
		// if no field, move on to eventObj section
	}
	
	if(eventObj) {
		// hide any currently-visible popups
		hideCurrentPopup();
		
		// stop event from bubbling up any farther
		eventObj.cancelBubble = true;
	
		// move popup div to current cursor position 
		// (add scrollTop to account for scrolling for IE)
		var newXCoordinate = (eventObj.pageX)? eventObj.pageX + xOffset : eventObj.x + xOffset + ((document.body.scrollLeft)?document.body.scrollLeft:0);
		var newYCoordinate = (eventObj.pageY)?eventObj.pageY + yOffset:eventObj.y + yOffset + ((document.body.scrollTop)?document.body.scrollTop:0);
		
		if(isNaN(newXCoordinate) || isNaN(newYCoordinate)){
			//	Calculate the place to show the validation div.
			var newXCoordinate = (window.innerWidth / 4)  + window.pageXOffset;
			var newYCoordinate = (window.innerHeight / 4) + window.pageYOffset;
		}
	
		//alert("Div is at: "+newXCoordinate+", "+newYCoordinate);
	
		moveObject(targetObjectId, newXCoordinate, newYCoordinate);
		// and make it visible
		if( changeObjectVisibility(targetObjectId, 'visible') ) {
			// if we successfully showed the popup
			// store its Id on a globally-accessible object
			window.currentlyVisiblePopup = targetObjectId;
			return true;
		} else {
			// we couldn't show the popup, boo hoo!
			return false;
		}
	} else {
		// there was no event object, so we won't be able to position anything, so give up
		return false;
    }
} // showPopup







function changeClass(id, cName) {
	var ob = getObject(id);
	if(typeof ob == "object") {
	//	alert("Old Class: "+ob.className);
		ob.className = cName;
	}
	else {
	//	alert("Cannot Find: "+id);
	}
}

function toggleClass(id, cName1, cName2) {
	var ob = getObject(id);
	if (typeof ob == "object") {
		var currentClass = ob.className;
		if (currentClass == cName1) {
			ob.className = cName2;
		} else {
			ob.className = cName1;
		}
	} else {
		// do nothing
	}
}


function swapImage(id,src,title) {
	var ob = document[id];
	if (!ob) {
		// try using getObject - IE doesn't find images that are dynamically added to the page
		ob = getObject(id);
	}
	if(typeof ob == "object") {
		ob.src=src;
		if(title) {
			ob.alt=title;
			ob.title=title;
		}
	} else {
		//alert("Cannot Find: "+id);
	}
}


