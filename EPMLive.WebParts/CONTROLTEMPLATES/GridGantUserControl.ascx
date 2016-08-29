<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages"
    Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GridGantUserControl.ascx.cs"
    Inherits="EPMLiveWebParts.GridGantUserControl" %>
<span id="lnk_checkAll" onclick="fnCheckAllPPItems('PPMItem');" visible="false" runat="server"
    onmouseout="this.style.textDecoration = 'none';" onmouseover="this.style.cursor='hand';this.style.textDecoration = 'underline';">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Check All</span>
<SharePoint:JSGrid ID="_grid" runat="server" Height="500" />
<script type="text/javascript">
    var spGridControl;
    var gridData = null;
    var colNames = null;
    var colValues = null;
    var gridRowIndex = null;
    var _focusedGridRow = null;
    var _dataSource;
    var _jsGridParams;
    var _focusedRowId = null;
    var _linkTitle = "<%=_linkTitle %>";
    var _workspaceUrl = "<%=_workspaceurl %>";
    var _assignedTo = "<%=_assignedTo %>";
    var _usePopup = "<%=_usePopup %>";
    var _action = "<%=_action %>";
    var _linkTitleNoMenu = "<%=_linkTitleNoMenu %>";
    var _gridID = "<%=gridID %>";
    var _imgs = "<%=_images %>";
    var _fullWebUrl = "<%=_fullWebUrl %>";

    document.getElementsByAttribute = function (attrN, attrV, multi) {
        attrV = attrV.replace(/\|/g, '\\|').replace(/\[/g, '\\[').replace(/\(/g, '\\(').replace(/\+/g, '\\+').replace(/\./g, '\\.').replace(/\*/g, '\\*').replace(/\?/g, '\\?').replace(/\//g, '\\/');
        var 
        multi = typeof multi != 'undefined' ?
        multi :
        false,
        cIterate = document.getElementsByTagName('*'),
        aResponse = [],
        attr,
        re = new RegExp(multi ? '\\b' + attrV + '\\b' : '^' + attrV + '$'),
        i = 0,
        elm;
        while ((elm = cIterate.item(i++))) {
            attr = elm.getAttributeNode(attrN);
            if (attr && attr.specified && re.test(attr.value))
                aResponse.push(elm);
        }
        return aResponse;
    }

    document.getElementsByClass = function getElementsByClass(searchClass, node, tag) {
        var classElements = new Array();
        if (node == null)
            node = document;
        if (tag == null)
            tag = '*';
        var els = node.getElementsByTagName(tag);
        var elsLen = els.length;
        var pattern = new RegExp('(^|\\\\s)' + searchClass + '(\\\\s|$)');
        for (i = 0, j = 0; i < elsLen; i++) {
            if (pattern.test(els[i].className)) {
                classElements[j] = els[i];
                j++;
            }
        }
        return classElements;
    }




    try {
        Type.registerNamespace("GridManager");
        GridManager = function () {
            this.Init = function (jsGridControl, initialData, props) {
                _dataSource = new SP.JsGrid.StaticDataSource(initialData);
                _jsGridParams = _dataSource.InitJsGridParams();
                gridData = initialData.LocalizedTable;
                jsGridControl.AttachEvent(SP.JsGrid.EventType.OnRowFocusChanged, SelectedRowIndexChanged);
                jsGridControl.AttachEvent(SP.JsGrid.EventType.OnSingleCellClick, OnSingleClick);
                jsGridControl.Init(_jsGridParams);
                spGridControl = jsGridControl;
                spGridControl.SetSplitterPosition(800);
                //spGridControl.RefreshAllRows();
            }
        };

    }
    catch (e) {

    }

    var _cbStatus = 'off';
    function OnDoubleClick(obj) {
        if (obj.fieldKey == "PPMItem") {
            if (_cbStatus == 'off') {
                fnCheckAllPPItems(obj.fieldKey);
                _cbStatus = 'on';
            }
            else {
                fnUnCheckAllPPItems(obj.fieldKey);
                _cbStatus = 'off';
            }
        }
    }

    function OnSingleClick(obj) {
        if (obj.fieldKey == _assignedTo) {
            loadUserSetting();
            return;
        }

        if (obj.fieldKey == _workspaceUrl) {
            NavigateToWorkspace();
            return;
        }

        if (obj.fieldKey == _linkTitle || obj.fieldKey == _linkTitleNoMenu || obj.fieldKey == "Edit" || obj.fieldKey == "LinkTitle" || obj.fieldKey == "LinkTitleNoMenu") {
            loadModal(obj.fieldKey);
        }

        //var html = document.getElementsByClass('ms-WPBody', null, null)[0].children[1].innerText;
        //html = html.replace('PPMItemTask', '<input type=\"checkbox\"/>Task');
        //document.getElementsByClass('ms-WPBody', null, null)[0].children[1].innerText = html;

        //LEFT OFF HERE....
        //var src = document.body.outerHTML;
        //var origText = '<DIV style=\"TEXT-ALIGN: left; LINE-HEIGHT: 19px; PADDING-LEFT: 2px; WIDTH: 53px; HEIGHT: 19px; COLOR: #363636; FONT-SIZE: 1em; CURSOR: move; FONT-WEIGHT: normal\" class=jsgrid-header-core-content colid=\"coreContent\">PPMItem</DIV>';
        //var newText = '<DIV style=\"TEXT-ALIGN: left; LINE-HEIGHT: 19px; PADDING-LEFT: 2px; WIDTH: 53px; HEIGHT: 19px; COLOR: #363636; FONT-SIZE: 1em; CURSOR: move; FONT-WEIGHT: normal\"><input type=\"checkbox\"/></DIV>';
        //src = src.replace(origText, newText);
        //document.body.outerHTML = src;
    }

    function loadUserSetting() {
        var assignedTo = fnGetUserData('assignedtodata');
        var regex = new RegExp(/ID=[0-9]*/i);

        if (assignedTo && assignedTo.match(regex)) {
            var userId = assignedTo.match(regex)[0].split('=')[1];
            if (userId) {
                var webUrl = _fullWebUrl + "/_layouts/userdisp.aspx?id=" + userId;
                var options = { url: webUrl, width: 650 };
                SP.UI.ModalDialog.showModalDialog(options);
            }
        }
    }

    function NavigateToWorkspace() {
        var workspaceurldata = fnGetUserData('workspaceurldata');
        var url = workspaceurldata.split(',')[0].trim();

        if (workspaceurldata && url) {
            window.location.href = url;
        }
    }

    function loadModal(fieldName) {

        var groupLevel = fnGetUserData('GroupingOutlineLevel');
        if (groupLevel == undefined || groupLevel == null || groupLevel == '') {
            var weburl = fnGetUserData("siteUrl");
            var webid = fnGetUserData("WebId");
            var listid = fnGetUserData("listid");
            var itemid = fnGetUserData("itemid");
            var action = "";

            if (itemid != null && itemid != "") {
                if (weburl == "/")
                    weburl = "";

                switch (_action) {
                    case 'view':
                        action = "view";
                        weburl = weburl + "/_layouts/epmlive/gridaction.aspx?action=" + action + "&webid=" + webid + "&ListId=" + listid + "&ID=" + itemid + "&Source=" + document.location.href;
                        if (_usePopup == 'false') {
                            window.location.href = weburl;
                        }
                        else {
                            var options = { url: weburl, width: 650, dialogReturnValueCallback: ajaxpost };
                            SP.UI.ModalDialog.showModalDialog(options);
                        }
                        break;

                    case 'edit':
                        action = "edit";
                        weburl = weburl + "/_layouts/epmlive/gridaction.aspx?action=" + action + "&webid=" + webid + "&ListId=" + listid + "&ID=" + itemid + "&Source=" + document.location.href;
                        if (_usePopup == 'false') {
                            window.location.href = weburl;
                        }
                        else {
                            var options = { url: weburl, width: 650, dialogReturnValueCallback: ajaxpost };
                            SP.UI.ModalDialog.showModalDialog(options);
                        }
                        break;

                    case 'workspace':
                        action = 'workspace';
                        weburl = weburl + "/_layouts/epmlive/gridaction.aspx?action=" + action + "&webid=" + webid;
                        window.location.href = weburl;
                        break;

                    case 'workplan':
                        action = 'workplan';
                        weburl = weburl + "/_layouts/epmlive/gridaction.aspx?action=" + action + "&webid=" + webid + "&ListId=" + listid + "&ID=" + itemid;
                        if (_usePopup == 'false') {
                            window.location.href = weburl;
                        }
                        else {
                            var options = { url: weburl, width: 650, dialogReturnValueCallback: ajaxpost };
                            SP.UI.ModalDialog.showModalDialog(options);
                        }
                        break;

                    case 'tasks':
                        action = "view";
                        weburl = weburl + "/_layouts/epmlive/gridaction.aspx?action=" + action + "&webid=" + webid + "&ListId=" + listid + "&ID=" + itemid + "&Source=" + document.location.href;
                        if (_usePopup == 'false') {
                            window.location.href = weburl;
                        }
                        else {
                            var options = { url: weburl, width: 650, dialogReturnValueCallback: ajaxpost };
                            SP.UI.ModalDialog.showModalDialog(options);
                        }

                    case '':
                        if (fieldName == 'Edit') {
                            action = "edit";
                            weburl = weburl + "/_layouts/epmlive/gridaction.aspx?action=" + action + "&webid=" + webid + "&ListId=" + listid + "&ID=" + itemid + "&Source=" + document.location.href;
                            if (_usePopup == 'false') {
                                window.location.href = weburl;
                            }
                            else {
                                var options = { url: weburl, width: 650, dialogReturnValueCallback: ajaxpost };
                                SP.UI.ModalDialog.showModalDialog(options);
                            }
                        }
                        else {
                            action = "view";
                            weburl = weburl + "/_layouts/epmlive/gridaction.aspx?action=" + action + "&webid=" + webid + "&ListId=" + listid + "&ID=" + itemid + "&Source=" + document.location.href;
                            if (_usePopup == 'false') {
                                window.location.href = weburl;
                            }
                            else {
                                var options = { url: weburl, width: 650, dialogReturnValueCallback: ajaxpost };
                                SP.UI.ModalDialog.showModalDialog(options);
                            }
                        }
                        break;
                }
            }
        }
    }

    function SelectedRowIndexChanged(obj) {
        try {
            _focusedGridRow = GetFocusedRecord();
            //fnCheckAllPPItems('PPMItem');
            RefreshCommandUI();
        }
        catch (e) {

        }
    }

    function fnJSGridEvents(name) {
        switch (name) {
            case 'zoomIn':
                GanttZoomIn();
            case 'zoomOut':
                GanttZoomOut();
            case 'scrollToTask':
                scrollTo();
        }
        return true;
    }

    function GanttZoomIn() {
        spGridControl.SetGanttZoomLevel(spGridControl.GetGanttZoomLevel() - 1);
    }

    function GanttZoomOut() {
        spGridControl.SetGanttZoomLevel(spGridControl.GetGanttZoomLevel() + 1);
    }

    function scrollTo() {
        var record = GetFocusedRecord();
        if (record != null) {
            var date = record.GetDataValue('ganttStart');
            if (date == null) {
                date = record.GetDataValue('ganttFinish');
            }
            if (date != null) {
                spGridControl.ScrollGanttToDate(date);
            }
        }
    }


    function scrollToInit() {
        var record = _dataSource.tableCache.GetCachedRecord(_dataSource.tableCache.RecordIdxToKey(0));
        if (record != null) {
            var date = record.GetDataValue('ganttStart');
            if (date == null) {
                date = record.GetDataValue('ganttFinish');
            }
            if (date != null) {
                spGridControl.ScrollGanttToDate(date);
            }
        }
    }

    function GetFocusedRecord() {

        var focusedItem = null;
        var focusedRecord = null;
        try {
            focusedItem = spGridControl.GetFocusedItem();
            focusedRecord;
        }
        catch (e) {

        }

        if (focusedItem != null) {
            focusedRecord = _dataSource.tableCache.GetCachedRecord(focusedItem.recordKey);
            _focusedRowId = focusedItem.recordKey;
        }
        return focusedRecord;
    }

    function fnGetGlobalCommands(arr) {
        return arr;
    }

    function fnCanHandleCommand(gridControl, commandId) {
        return commandId;
    }

    function fnFocusedCommands(arr) {
        return arr;
    }

    function fnCheckAllPPItems(colName) {
        if (document.getElementById('lnk_checkAll').innerHTML == 'Check All') {
            var allRecordKeys = _dataSource.tableCache.GetView();
            var i = 0;
            var record = null;
            var cachedTable = _dataSource.tableCache;
            while (i < allRecordKeys.length) {
                record = cachedTable.GetCachedRecord(allRecordKeys[i]);
                record.properties[colName].Update(true, 'Checked');
                spGridControl.RefreshRow(allRecordKeys[i]);
                i++;
            }
            document.getElementById('lnk_checkAll').innerHTML = 'Uncheck All';
        }
        else {
            fnUnCheckAllPPItems('PPMItem');
        }
    }

    function fnUnCheckAllPPItems(colName) {
        var allRecordKeys = _dataSource.tableCache.GetView();
        var cachedTable = _dataSource.tableCache;
        var i = 0;
        var record = null;
        while (i < allRecordKeys.length) {
            record = cachedTable.GetCachedRecord(allRecordKeys[i]);
            record.properties[colName].Update(false, 'Unchecked');
            spGridControl.RefreshRow(allRecordKeys[i]);
            i++;
        }
        document.getElementById('lnk_checkAll').innerHTML = 'Check All';
    }

    function fnGetUserData(key) {
        var value = null;
        try {
            switch (key.toString().toLowerCase()) {
                case 'siteid':
                    value = _focusedGridRow.GetLocalizedValue('siteid');
                    break;

                case 'itemid':
                    value = _focusedGridRow.GetLocalizedValue('ID');
                    break;

                case 'webid':
                    value = _focusedGridRow.GetLocalizedValue('WebId');
                    break;

                case 'siteurl':
                    value = _focusedGridRow.GetLocalizedValue('siteUrl');
                    break;

                case 'viewmenus':
                    value = _focusedGridRow.GetLocalizedValue('viewMenus');
                    if (value == undefined) {
                        value = '0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0';
                    }
                    break;

                case 'listid':
                    value = _focusedGridRow.GetLocalizedValue('listid');
                    break;

                case 'viewurl':
                    value = _focusedGridRow.GetLocalizedValue('viewUrl');
                    break;

                case 'groupingoutlinelevel':
                    value = _focusedGridRow.GetLocalizedValue('GroupingOutlineLevel');
                    break;

                case 'assignedtodata':
                    value = _focusedGridRow.GetLocalizedValue('AssignedToData');
                    break;

                case 'workspaceurldata':
                    value = _focusedGridRow.GetLocalizedValue('WorkspaceUrlData');
            }
        }
        catch (e) {
            if (key == 'viewMenus') {
                value = '0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0';
            }
        }

        if (value == undefined) {
            value = null;
        }
        return value;
    }

    function GetColumnIndexByColumnName(colName) {
        var i = 0;
        while (i < gridData.gridPaneColumns.length) {
            if (gridData.gridPaneColumns[i].toString().toLower() == colName.toString().toLower()) {
                return i;
            }
            i++;
        }
    }   
</script>
<script type="text/javascript">
    var xmlhttp = false;
    if (navigator.appName == "Microsoft Internet Explorer") {
        xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    else {
        xmlhttp = new XMLHttpRequest();
    }

    function ajaxpost() {

        var val = SP.UI.Notify.addNotification("Updating Saved Row...", false, "", null);
        var siteid = fnGetUserData('siteid');
        var webid = fnGetUserData('WebId');
        var itemid = fnGetUserData('itemid');
        var listid = fnGetUserData('listid');
        var viewUrl = fnGetUserData('viewUrl');
        var params = "<%=ganttParams %>";
        var curWebUrl = "<%=webUrl %>";
        xmlhttp.open("POST", curWebUrl, true);
        xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4) {
                focusedRecord = null;
                focusedRecord = _dataSource.tableCache.GetCachedRecord(_focusedRowId);
                var obj = Sys.Serialization.JavaScriptSerializer.deserialize(xmlhttp.responseText);
                var i = 0;
                while (i < obj.FieldValues.length) {
                    var fieldkey = obj.FieldValues[i].fieldKey;
                    var dataValue = obj.FieldValues[i].dataValue;
                    var localizedValue = obj.FieldValues[i].localizedValue;
                    var prop = focusedRecord.GetProp(fieldkey);
                    if (prop != null && prop != undefined) {
                        focusedRecord.properties[fieldkey].Update(dataValue, localizedValue);
                    }
                    i++;
                }
                spGridControl.RefreshRow(_focusedRowId);
                //spGridControl.RefreshAllRows();
            }
        }
        xmlhttp.send("siteid=" + siteid + "&webid=" + webid + "&itemid=" + itemid + "&listid=" + listid + "&viewUrl=" + viewUrl + "&params=" + params + "&imgs=" + _imgs);
    }

    function ajaxpostXML() {
        var postUrl = "<%=postUrl %>";
        var data = "<%=datavals %>";
        var width = "";
        var source = "<%=source %>";
        var insertrow = "<%=insertrow %>";
        var edit = "<%=edit %>";

        xmlhttp.open("POST", postUrl, true);
        xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4) {
                var obj = xmlhttp.responseText;
            }
        }
        xmlhttp.send("data=" + data + "&width=" + width + "&insertrow=" + insertrow + "&source=" + source + "&edit=" + edit);
    }

     
</script>
<script language="javascript" type="text/javascript">

    var scrollInit = false;
    var int = self.setInterval("InitScrollToTask()", 1000);


    function InitScrollToTask() {
        if (scrollInit == false) {
            try {
                if (_dataSource != undefined) {
                    scrollToInit();
                    self.clearInterval(int);
                    scrollInit = true;
                }
            }
            catch (e) {

            }
        }
    }
</script>
