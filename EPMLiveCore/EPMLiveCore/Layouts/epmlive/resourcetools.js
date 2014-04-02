/// <reference name="MicrosoftAjax.js" />
/// <reference path="file://C:/Program Files/Common Files/Microsoft Shared/Web Server Extensions/14/TEMPLATE/LAYOUTS/SP.core.debug.js" />
/// <reference path="file://C:/Program Files/Common Files/Microsoft Shared/Web Server Extensions/14/TEMPLATE/LAYOUTS/SP.debug.js" />
/// <reference path="file://C:/Program Files/Common Files/Microsoft Shared/Web Server Extensions/14/TEMPLATE/LAYOUTS/epmlive/dhtml/xgrid/dhtmlxcommon.js" />

var ResToolsSet = false;
var ResToolsEnabled = false;

function getResToolsEnabled() {


    if (!ResToolsSet) {
        var url = SP.PageContextInfo.get_webServerRelativeUrl()
        if (url == "/")
            url = "";

        var $v_0 = new Sys.StringBuilder();
        $v_0.append(url);
        $v_0.append("/_layouts/15/epmlive/getGeneralSetting.aspx?listid=");
        $v_0.append(SP.PageContextInfo.get_pageListId());
        $v_0.append("&setting=EnableResourcePlan");

        var data = dhtmlxAjax.getSync($v_0);
        var dataText = data.xmlDoc.responseText.trim();

        if (dataText == "True")
            ResToolsEnabled = true;
        else
            ResToolsEnabled = false;

        ResToolsSet = true;
    }
    
    return ResToolsEnabled;
}

function findResource() {
    var url = SP.PageContextInfo.get_webServerRelativeUrl();
    if (url == "/")
        url = "";

    var $v_0 = new Sys.StringBuilder();
    $v_0.append(url);
    $v_0.append("/_layouts/epmlive/resourcecapacity.aspx");
    //$v_0.append("/_layouts/epmlive/getGeneralSetting.aspx?listid=");
    //$v_0.append(SP.PageContextInfo.get_pageListId());
    //$v_0.append("&websetting=ReportingServicesURL");

    //var data = dhtmlxAjax.getSync($v_0);
    //var dataText = data.xmlDoc.responseText.trim();

    //if (dataText != "") {
        javascript: window.open($v_0, '', config = 'height=600,width=800, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes');
        //javascript: window.open(dataText + "&URL=" + url, '', config = 'height=600,width=800, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes');
    //}
    //else {
        //alert("Cannot get SSRS URL");
    //}
}

function checkResource() {

    var url = SP.PageContextInfo.get_webServerRelativeUrl();
    if (url == "/")
        url = "";

    var $v_0 = new Sys.StringBuilder();
    $v_0.append(url);
    $v_0.append("/_layouts/epmlive/getGeneralSetting.aspx?listid=");
    $v_0.append(SP.PageContextInfo.get_pageListId());
    $v_0.append("&websetting=EPMLiveResourceURL");

    var data = dhtmlxAjax.getSync($v_0);
    var dataText = data.xmlDoc.responseText.trim();

    if (dataText != "") {
        if (dataText == "/")
            dataText = "";
        showgantt(dataText + "/_layouts/epmlive/checkresgantt.aspx", SP.PageContextInfo.get_pageListId(), getRequestParam("ID"));
    }
    else {
        alert("Could not get resource pool URL");
    }
}


function getRequestParam(name)
{
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null) 
        return "";
    else 
        return results[1]; 
}

function findacontrol(FieldName) {
    var arr = document.getElementsByTagName("!");
    for (var i = 0; i < arr.length; i++)
        if (arr[i].innerHTML.indexOf(FieldName) > 0)
            return arr[i];
}

function getFormInput(tablefield) {
    return tablefield.nextSibling.firstChild;
}

function getUsers(fieldname) {
    var users = "";
    try {
        var resTable = findacontrol(fieldname);
        var userField = "";

        if (resTable != null) {
            //userField = resTable.nextSibling.firstChild.id.replace("HiddenUserFieldValue", "UserField_downlevelTextBox");
            userField = resTable.nextSibling.firstChild.id.replace("HiddenUserFieldValue","UserField_upLevelDiv");
        }

        var userList = document.getElementById(userField);

        for (var i = 0; i < userList.childNodes.length; i++) {
            var node = userList.childNodes[i];
            if (node.nodeName == "SPAN") {
                users = users + ";" + encodeURIComponent(node.attributes["title"].value);
            }
        }
        if (users != "") {
            users = users.substr(1);
        }
        /*
        var child = document.getElementById(userField).firstChild;
		
        while(child != null)
        {
        if(child.nodeName == "SPAN")
        {
        alert(child.firstChild.firstChild.attributes["data"].value);
        }
        child = child.nextSibling;
        }

        var elem = document.forms[0].elements;
        for (var i = 0; i < elem.length; i++) {
            if (elem[i].id.indexOf(userField) != -1) {
                users = elem[i].value;
            }
        }*/
    }
    catch (e) {
        alert("Error: " + e);
    }
    return users;
}



function showgantt(url, listid, itemid) {


    

    var start = "";
    var end = "";
    var work = ""
    var title = "";
    var resources = "";
    try {
        resources = getUsers("AssignedTo");
    } catch (e) { }

    try {
        if (g_strDateTimeControlIDs["SPStartDate"] != "undefined")
            start = document.getElementById(g_strDateTimeControlIDs["SPStartDate"]).value;
    } catch (e) { }

    try {
        if (g_strDateTimeControlIDs["SPDueDate"] != "undefined")
            end = document.getElementById(g_strDateTimeControlIDs["SPDueDate"]).value;
    } catch (e) { }

    try {
        var workTable = findacontrol("\"Work\"");

        if (workTable != null)
            workTable = getFormInput(workTable);
        if (workTable != null)
            work = workTable.value;
    } catch (e) { }

    try {
        var titleTable = findacontrol("=\"Title");

        if (titleTable != null)
            titleTable = getFormInput(titleTable);
        if (titleTable != null)
            title = titleTable.value;
    } catch (e) { }

    if (start == "") {
        alert('You must specify a Start Date');
        return;
    }
    if (end == "") {
        alert('You must specify a Due Date');
        return;
    }
    if (work == "") {
        alert('You must specify Work');
        return;
    }
    if (resources == "") {
        alert('You must specify 1 or more resources');
        return;
    }
    window.open(url + "?showgantt=1&startdate=" + start + "&enddate=" + end + "&work=" + work + "&resources=" + resources + "&title=" + title + "&startfield=" + g_strDateTimeControlIDs["SPStartDate"] + "&endfield=" + g_strDateTimeControlIDs["SPDueDate"] + "&listid=" + listid + "&itemid=" + itemid, '', config = 'height=400,width=800, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes');
}