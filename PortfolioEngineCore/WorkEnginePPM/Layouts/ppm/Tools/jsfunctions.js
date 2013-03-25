

function jsf_getStringFromValue(val) {
    if (val == null)
        return "";
    return val.toString();
}

function jsf_alertError(error) {
    if (error == null)
        return false;
    var severity = error.severity;
    switch (severity) {
        case "error":
            alert("Error returned from server:\n\n" + error.message + "\n");
            break;
        default:
            alert("Error returned from server:\nseverity: " + severity + "\nlocation: " + error.location + "\nmessage: " + error.message + "\n");
            break;
    }
    return true;
};
function jsf_isEmpty(value) {
    return (typeof value === "undefined" || value === null || value === '');
};
function jsf_displayDialog(wins, left, top, width, height, title, idWindow, idAttachObj, bModal, bResize, bAttachURL) {
    if (wins != null) {
        var dlg = wins.createWindow(idWindow, left, top, width, height);
        if (dlg != null) {
            dlg.clearIcon();
            if (bResize == false) {
                dlg.denyResize();
                dlg.button("minmax1").hide();
            } else {
                dlg.allowResize();
                dlg.button("minmax1").show();
            }
            dlg.button("park").hide();
            dlg.button("close").show();
            dlg.setModal(bModal);
            dlg.center();
            dlg.setText(title);
            if (idAttachObj != null) {
                if (bAttachURL == true)
                    dlg.attachURL(idAttachObj);
                else
                    dlg.attachObject(idAttachObj);
            }
            dlg.allowMove();

        }
        return dlg;
    }
    return null;
};

function jsf_closeDialog(wins, idWindow) {
    if (wins != null) {
        var dlg = wins.window(idWindow);
        jsf_closeDialog2(dlg);
    }
};
function jsf_closeDialog2(dlg) {
    if (dlg != null) {
        dlg.setModal(false);
        dlg.hide();
        dlg.detachObject();
    }
};

function jsf_xml(sValue) {
    return sValue.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
}
function jsf_sendRequest(sURL, sXML) {
    var sReplyXML = "";
    try {
        var oXMLHttp = new XMLHttpRequest();
        oXMLHttp.open("POST", sURL, false);
        oXMLHttp.setRequestHeader("Content-Type", "text/xml; charset=utf-8");
        oXMLHttp.send(sXML);
        sReplyXML = oXMLHttp.responseText;
        if (oXMLHttp.status != 200) {
            alert("jsf_sendRequest : Invalid status reply.\n\nstatus=" + oXMLHttp.status.toString() + " : " + oXMLHttp.statusText + ";\n\nPlease report this to your System Administrator");
            alert("jsf_sendRequest : Extra Info.\n\nURL=" + sURL + ";\n\nresponseText=" + sReplyXML + ";\n\nPlease report this to your System Administrator");
        } else if (sReplyXML.length == 0) {
            alert("jsf_sendRequest : Invalid (zero length) reply from server.\n\nURL=" + sURL + ";\n\nstatus=" + oXMLHttp.status.toString() + " : " + oXMLHttp.statusText + ";\n\nPlease report this to your System Administrator");
        } else if (sReplyXML.substr(0, 16) == "Server Request Error" || sReplyXML.substr(4, 9) == "<!DOCTYPE") {
            alert("jsf_sendRequest : Server request error.\n\nURL=" + sURL);
        }
    } catch (e) {
        alert("jsf_sendRequest : Exception. \nType=" + e.name + "; \nMessage=" + e.Message + ";\nURL=" + sURL + ";\n\nPlease report this to your System Administrator");
        alert("jsf_sendRequest : status=" + oXMLHttp.status.toString() + " : " + oXMLHttp.statusText + ";\n\nPlease report this to your System Administrator");
    }
    return sReplyXML;
};
