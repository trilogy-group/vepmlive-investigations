function AsyncGetCommonActionsMenu() {
    var xmlhttp = false;
    if (navigator.appName == 'Microsoft Internet Explorer') {
        xmlhttp = new ActiveXObject('Microsoft.XMLHTTP');
    }
    else {
        xmlhttp = new XMLHttpRequest();
    }
    xmlhttp.open("POST", commonActionsAsyncUrl, true);
    xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4) {
            if (xmlhttp.status == 200) {
                var menuData = xmlhttp.responseText;
                if (menuData) {
                    var menuDiv = document.getElementById("divCommonActionsMenuAsync");
                    menuDiv.innerHTML = menuData;
                }
            }
        }
    };
    xmlhttp.send("requesturl=" + window.location.href);
}

function ToggleCommonActionsMenu() {
    AsyncGetCommonActionsMenu();
    document.onclick = function (event) {
        var element;
        var allElements = document.getElementsByTagName("*");

        for (var i = 0; (element = allElements[i]) != null; i++) {
            if (typeof element.className !== 'string') {
                continue;
            }
            var elementClass = element.className;
            if (elementClass && (elementClass.indexOf("ms-MenuUIPopupBody") != -1)) {
                if (element.style.display != "none" || element.style.display != "None") {
                    element.style.display = "none";
                }
            }
        }

        if (clickedOutsideElement('spnCommonActions', event) && clickedOutsideElement('lnkCommonActions', event) && clickedOutsideElement('spnCommonActionsText', event)) {
            document.getElementById('divCommonActionsMenu').style.display = "none";
        }
        else {
            document.getElementById('divCommonActionsMenu').style.display = "";
        }
    }

    document.getElementById('divCommonActionsMenu').style.display = "";

    //if ((GetFullLeft(document.getElementById('lnkCommonActions')) + document.getElementById('divCommonActionsMenu').offsetWidth) > pageWidth()) {
    //    var differenceInWidth = document.getElementById('divCommonActionsMenu').offsetWidth - document.getElementById('lnkCommonActions').offsetWidth;
    //    document.getElementById('divCommonActionsMenu').style.left = (GetFullLeft(document.getElementById('lnkCommonActions')) - differenceInWidth) + "px";
    //}
    //else {
    //    document.getElementById('divCommonActionsMenu').style.left = GetFullLeft(document.getElementById('lnkCommonActions')) + "px";
    //}

    ////document.getElementById('divCommonActionsMenu').style.top = (GetFullTop(document.getElementById('lnkCommonActions')) + document.getElementById('lnkCommonActions').offsetHeight) + "px";
    //document.getElementById('divCommonActionsMenu').style.top = (GetFullTop(document.getElementById('lnkCommonActions')) - document.getElementById('lnkCommonActions').offsetHeight) + 11 + "px";
    ////var tempTop = document.getElementById('divCommonActionsMenu').style.top.replace('px', '');
    //var tempTop = tempTop = document.getElementById('lnkCommonActions').offsetTop + document.getElementById('lnkCommonActions').offsetHeight;

    //if ((parseInt(tempTop) + document.getElementById('divCommonActionsMenu').offsetHeight) > pageHeight()) {
    //    var newHeight = pageHeight() - (GetFullTop(document.getElementById('lnkCommonActions')) + document.getElementById('lnkCommonActions').offsetHeight);
    //    document.getElementById('divCommonActionsMenu').style.height = newHeight + "px";
    //}
    //else {
    //    document.getElementById('divCommonActionsMenu').style.height = "auto";
    //}

    //document.getElementById('divCommonActionsMenu').style.top = tempTop + "px";
}

function clickedOutsideElement(elemId, event) {
    var theElem = (window.event) ? getEventTarget(window.event) : event.target;
    while (theElem != null) {
        if (theElem.id == elemId) {
            return false;
        }
        else {
            theElem = theElem.parentNode;
        }
    }
    return true;
}

function getEventTarget(evt) {
    var targ = (evt.target) ? evt.target : evt.srcElement;
    if (targ != null) {
        if (targ.nodeType == 3)
            targ = targ.parentNode;
    }
    return targ;
}

function GetFullTop(obj) {

    var posY = obj.offsetTop;
    

    while (obj.offsetParent) {

        posY = posY + obj.offsetParent.offsetTop;

        if (obj == document.getElementsByTagName('body')[0]) { break }
        else { obj = obj.offsetParent; }
    }

    return posY;
}

function GetFullLeft(obj) {

    var posX = obj.offsetLeft;

    while (obj.offsetParent) {

        posX = posX + obj.offsetParent.offsetLeft;

        if (obj == document.getElementsByTagName('body')[0]) { break }
        else { obj = obj.offsetParent; }
    }

    return posX;
}

function pageWidth() {
    return window.innerWidth != null ? window.innerWidth :
document.documentElement && document.documentElement.clientWidth ?
document.documentElement.clientWidth : document.body != null ?
document.body.clientWidth : null;
}

function pageHeight() {
    return window.innerHeight != null ? window.innerHeight :
document.documentElement && document.documentElement.clientHeight ?
document.documentElement.clientHeight : document.body != null ?
document.body.clientHeight : null;
}