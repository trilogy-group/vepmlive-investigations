function AsyncGetCreateNewMenu() {
    var xmlhttp = false;
    if (navigator.appName == 'Microsoft Internet Explorer') {
        xmlhttp = new ActiveXObject('Microsoft.XMLHTTP');
    }
    else {
        xmlhttp = new XMLHttpRequest();
    }
    xmlhttp.open("POST", createNewAsyncUrl, true);
    xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4) {
            if (xmlhttp.status == 200) {
                var menuData = xmlhttp.responseText;
                if (menuData) {
                    var menuDiv = document.getElementById("divCreateNewMenuAsync");
                    menuDiv.innerHTML = menuData;
                }
            }
        }
    };
    xmlhttp.send("requesturl=" + window.location.href);
}

function ToggleCreateNewMenu() {
    AsyncGetCreateNewMenu();
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

        //if (clickedOutsideElement('spnCreateNew', event) && clickedOutsideElement('lnkCreateNew', event) && clickedOutsideElement('spnCreateNewText', event)) {
        if (clickedOutsideElement('lnkCreateNew', event)) {
            document.getElementById('divCreateNewMenu').style.display = "none";
        }
        else {
            document.getElementById('divCreateNewMenu').style.display = "inline";
        }
    }
    document.getElementById('divCreateNewMenu').style.display = "inline";
    if ((GetFullLeft(document.getElementById('lnkCreateNew')) + document.getElementById('divCreateNewMenu').offsetWidth) > pageWidth()) {
        var differenceInWidth = document.getElementById('divCreateNewMenu').offsetWidth - document.getElementById('lnkCreateNew').offsetWidth;
        document.getElementById('divCreateNewMenu').style.left = (GetFullLeft(document.getElementById('lnkCreateNew')) - differenceInWidth) + "px";
    }
    else {
        document.getElementById('divCreateNewMenu').style.left = GetFullLeft(document.getElementById('lnkCreateNew')) + "px";
    }
    //document.getElementById('divCreateNewMenu').style.top = (GetFullTop(document.getElementById('spnCreateNew')) + document.getElementById('spnCreateNew').offsetHeight) + "px";
    document.getElementById('divCreateNewMenu').style.top = (GetFullTop(document.getElementById('lnkCreateNew')) - document.getElementById('lnkCreateNew').offsetHeight) + 6 + "px";
    
    //var tempTop = document.getElementById('divCreateNewMenu').style.top.replace('px', '');
    var tempTop = tempTop = document.getElementById('lnkCreateNew').offsetTop + document.getElementById('lnkCreateNew').offsetHeight;

    if ((parseInt(tempTop) + document.getElementById('divCreateNewMenu').offsetHeight) > pageHeight()) {
        var newHeight = pageHeight() - (GetFullTop(document.getElementById('lnkCreateNew')) + document.getElementById('lnkCreateNew').offsetHeight);
        document.getElementById('divCreateNewMenu').style.height = newHeight + "px";
    }
    else {
        document.getElementById('divCreateNewMenu').style.height = "auto";
    }
    document.getElementById('divCreateNewMenu').style.top = tempTop + "px";
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

function HandleCreateNewWorkspaceCreate(result, value) {
    var tag = document.getElementsByTagName('object');
    for (var i = tag.length - 1; i >= 0; i--) {
        tag[i].style.display = '';
    }

    if (result == '1') {
        window.location.href = value;
    }
}

function HideLayers() {
    var tag = document.getElementsByTagName('object');
    for (var i = tag.length - 1; i >= 0; i--) {
        tag[i].style.display = 'none';
    }
}