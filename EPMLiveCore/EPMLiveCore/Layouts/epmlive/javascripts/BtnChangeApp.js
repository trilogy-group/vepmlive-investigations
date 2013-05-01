/// <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js" />
function AsyncChangeAppMenu() {
    var postData = { requesturl: window.location.href, appid: btnChangeAppCurrentAppId };
    $.post(changeAppAsyncUrl, postData, function (data) {
        var result = data.split('#;');
        if (result[0] == 'success') {
            var menuDiv = document.getElementById("divChangeAppMenuAsync");
            menuDiv.innerHTML = result[1];
        }
        else {
            document.getElementById('divChangeAppMenu').style.display = "none";
        }
    });
}

function ToggleChangeAppMenu() {
    AsyncChangeAppMenu();
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

        //if (clickedOutsideElement('spnCreateNew', event) && clickedOutsideElement('lnkChangeApp', event) && clickedOutsideElement('spnCreateNewText', event)) {
        if (clickedOutsideElement('lnkChangeApp', event)) {
            document.getElementById('divChangeAppMenu').style.display = "none";
        }
        else {
            document.getElementById('divChangeAppMenu').style.display = "inline";
        }
    }
    document.getElementById('divChangeAppMenu').style.display = "inline";
    if ((GetFullLeft(document.getElementById('lnkChangeApp')) + document.getElementById('divChangeAppMenu').offsetWidth) > pageWidth()) {
        var differenceInWidth = document.getElementById('divChangeAppMenu').offsetWidth - document.getElementById('lnkChangeApp').offsetWidth;
        document.getElementById('divChangeAppMenu').style.left = (GetFullLeft(document.getElementById('lnkChangeApp')) - differenceInWidth) + "px";
    }
    else {
        document.getElementById('divChangeAppMenu').style.left = GetFullLeft(document.getElementById('lnkChangeApp')) + "px";
    }
    //document.getElementById('divChangeAppMenu').style.top = (GetFullTop(document.getElementById('spnCreateNew')) + document.getElementById('spnCreateNew').offsetHeight) + "px";
    document.getElementById('divChangeAppMenu').style.top = (GetFullTop(document.getElementById('lnkChangeApp')) - document.getElementById('lnkChangeApp').offsetHeight) + 6 + "px";
    //var tempTop = document.getElementById('divChangeAppMenu').style.top.replace('px', '');

    var tempTop = tempTop = document.getElementById('lnkChangeApp').offsetTop + document.getElementById('lnkChangeApp').offsetHeight;

    if ((parseInt(tempTop) + document.getElementById('divChangeAppMenu').offsetHeight) > pageHeight()) {
        var newHeight = pageHeight() - (GetFullTop(document.getElementById('lnkChangeApp')) + document.getElementById('lnkChangeApp').offsetHeight);
        document.getElementById('divChangeAppMenu').style.height = newHeight + "px";
    }
    else {
        document.getElementById('divChangeAppMenu').style.height = "auto";
    }
    document.getElementById('divChangeAppMenu').style.top = tempTop + "px";
}

function AsyncChangeApp(homePageUrl, itemId) {
    window.location.href =  webUrl + '/_layouts/epmlive/ChangeApp.aspx?appid=' + itemId; 
}

function OpenUrlWithModal(url, title) {
    var options = { url: url,
        title: title,
        allowMaximize: false,
        showClose: false,
        dialogReturnValueCallback: ChangeToNewCommunity
    };

    SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);
    return false;
}

function ChangeToNewCommunity(result, value) {
//    switch (result) {
//        case '1':
//            var postData = { appid: itemId };
//            $.post(webUrl + '/_layouts/epmlive/ChangeApp.aspx', postData, function (data) {
//            });
//            break;
//    }
    window.location.href = webUrl + '/_layouts/epmlive/ChangeApp.aspx?appid=' + value; 
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