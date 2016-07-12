<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register src="Tools/DGrid.ascx" tagname="DGridUserControl" tagprefix="dg1" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Models_NAX.aspx.cs" Inherits="WorkEnginePPM.Models_NAX" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Reference Control="/_layouts/ppm/tools/DGrid.ascx" %>
<%@ Register src="Tools/TGrid.ascx" tagname="TGridUserControl" tagprefix="tg1" %>
<%@ Reference Control="/_layouts/ppm/tools/TGrid.ascx" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script src="tools/jsfunctions.js" type="text/javascript"></script>
<script src="general.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="styles/dialognew.css" />
<link rel="stylesheet" type="text/css" href="styles/form.css" />
<link rel="stylesheet" type="text/css" href="tools/toolbar.css" />
<script src="tools/toolbar.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.css" />
<link rel="stylesheet" type="text/css" href="/_layouts/epmlive/dhtml/windows/skins/dhtmlxwindows_dhx_admin.css" />
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcommon.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxcontainer.js" type="text/javascript"></script>
<script src="/_layouts/epmlive/dhtml/windows/dhtmlxwindows.js" type="text/javascript"></script>
<style type="text/css">
.ms-cui-tabBody {
    border-bottom: 0 !important;
}
BODY #s4-workspace {
    height: 100% !important;
}
html, body {
    width: 100%;
    height: 100%;
    margin: 0px;
    overflow: hidden;
}
</style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <div id="veil" style="display:none;"></div>
<div class="modalContent" id="idModelDlg" style="display:none;">
    <input id="idModelDlgMode" type="hidden" value="" />
    <table cellspacing="0" cellpadding="0">
        <tr>
            <td style="height:1px;" class="topcell"></td>
            <td style="height:1px;" class="topcell"></td>
        </tr>
        <tr style="display:none;">
            <td class="descriptioncell">
                Field Id
            </td>
            <td class="controlcell">
                <input type="text" id="txtId" />
            </td>
        </tr>
        <tr>
            <td class="descriptioncell">
                <label for="txtName">Model Name</label>
            </td>
            <td class="controlcell">
                <input type="text" id="txtName" style="width:350px;" />
            </td>
        </tr>
        <tr>
            <td class="descriptioncell">
                Model Description
            </td>
            <td class="controlcell">
                    <input type="text" id="txtDesc" style="Width:350px;"/>
            </td>
        </tr>
        <tr id="trCalendar">
            <td class="descriptioncell">
                Fiscal Calendar</td>
            <td class="controlcell">
                <select id="idCalendar" onchange="javascript:modelDlg_event('calendarchanged');" >
                </select>
            </td>
        </tr>
        <tr>
            <td class="descriptioncell">
                Custom field for Selected flag</td>
            <td class="controlcell">
                <select id="idSelectedFlag" onchange="javascript:modelDlg_event('flagchanged');" >
                </select>
            </td>
        </tr>
    </table>
    <div style="width:516px; display:block; padding-top: 10px; padding-bottom: 10px;">
        <table cellpadding="5">
            <tr>
                <td colspan="4" class="descriptioncell">Select the Cost Types to be used:</td>
            </tr>
            <tr>
                <td class="descriptioncell">
                    Available:<br />
					<select name="FrmFieldsOut" size="7" id="idCostTypesOut" style="width: 210px; margin-top: 3px; padding: 3px;" ondblclick="javascript:modelDlg_event('include');" >
					</select>
                </td>
                <td>
                    <input type="button" class="epmliveSmallButton" value="&gt; " onclick="javascript:modelDlg_event('include');" /><br /><br />
                    <input type="button" class="epmliveSmallButton" value="&lt; " onclick="javascript:modelDlg_event('exclude');"/>
                </td>
                <td class="descriptioncell">
                    Selected:<br />
					<select name="FrmFieldsIn" size="7" id="idCostTypesIn" style="width: 210px; margin-top: 3px; padding: 3px;" ondblclick="javascript:modelDlg_event('exclude');" >
					</select>
                </td>
                <td>
                    <input type="button" class="epmliveSmallButton" value="up" onclick="javascript:modelDlg_event('moveup');" /><br /><br />
                    <input type="button" class="epmliveSmallButton" value="dn" onclick="javascript:modelDlg_event('movedown');"/>
                </td>
            </tr>
             <tr>
                <td colspan="4" class="descriptioncell">Create Model Versions and assign Permissions:</td>
            </tr>
             <tr>
                <td colspan="4" class="descriptioncell">
                    <div id="idModelVersions">
                        <div id="idToolbarVersionsDiv"></div>
                        <div style="display:block;"><dg1:DGridUserControl id="dgridVersions" runat="server" /></div>
                    </div></td>
            </tr>
       </table>
    </div>
    <div id="idDeleteWarning" style="width:300px; color:red; display:none;"><a>Are you sure, all data will be cleared?</a></div>
	<div style="float:right;">
	    <div class="button-container" >
		    <input id="idOKButton" type="button" class="epmliveButton" value="OK" onclick="modelDlg_event('ok');"/>
		    <input type="button" class="epmliveButton" value="Cancel" onclick="modelDlg_event('cancel');"/>
	    </div>
    </div>
</div>
<div class="modalContent" id="idVersionDlg" style="display:none;">
    <input id="idVersionDlgMode" type="hidden" value="" />
    <table cellspacing="0" cellpadding="0">
        <tr>
            <td style="height:1px;" class="topcell"></td>
            <td style="height:1px;" class="topcell"></td>
        </tr>
        <tr style="display:none;">
            <td class="descriptioncell">
                Field Id
            </td>
            <td class="controlcell">
                <input type="text" id="txtIdVer" />
            </td>
        </tr>
        <tr>
            <td class="descriptioncell">
                <label for="txtName">Name</label>
            </td>
            <td class="controlcell">
                <input type="text" id="txtNameVer" style="width:250px;" />
            </td>
        </tr>
        <tr>
            <td class="descriptioncell">
                Description
            </td>
            <td class="controlcell">
                    <input type="text" id="txtDescVer" style="Width:250px;"/>
            </td>
        </tr>
    </table>
	<div style="margin-top:10px;padding-right:10px;width:360px;">
        <tg1:TGridUserControl id="tgridSecurity" runat="server" />
	</div>
    <div id="idDeleteWarningVer" style="width:250px; color:red; display:none;"><a>Are you sure, all data will be cleared?</a></div>
	<div style="float:right;">
	    <div class="button-container" >
		    <input id="idOKButtonVer" type="button" class="epmliveButton" value="OK" onclick="versionDlg_event('ok');"/>
		    <input type="button" class="epmliveButton" value="Cancel" onclick="versionDlg_event('cancel');"/>
	    </div>
    </div>
</div>
<div style="display: block;" >
<asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
<div id="idToolbarDiv"></div>
<dg1:DGridUserControl id="dgrid1" runat="server" />
</div>
<script type="text/javascript">
    var toobarData = {
        parent: "idToolbarDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", name: "ADD", img: "formatmap16x16_2.png", style: "top: -90px; left: -216px;", tooltip: "Add", onclick: "toolbar_event('btnAdd');" },
            { type: "button", id: "btnModify", name: "MODIFY", img: "formatmap16x16_2.png", style: "top: -243px; left: -55px;", tooltip: "Modify", onclick: "return toolbar_event('btnModify');", disabled: true },
            { type: "button", id: "btnDelete", name: "DELETE", img: "formatmap16x16_2.png", style: "top: -270px; left: -270px;", tooltip: "Delete",  onclick: "return toolbar_event('btnDelete');", disabled: true }
        ]
    };
    var toolbarVersionsData = {
        parent: "idToolbarVersionsDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", name: "ADD", img: "formatmap16x16_2.png", style: "top: -90px; left: -216px;", tooltip: "Add", onclick: "modelDlg_event('btnAdd2');" },
            { type: "button", id: "btnModify2", name: "MODIFY", img: "formatmap16x16_2.png", style: "top: -243px; left: -55px;", tooltip: "Modify", onclick: "return modelDlg_event('btnModify2');", disabled: true },
            { type: "button", id: "btnDelete2", name: "DELETE", img: "formatmap16x16_2.png", style: "top: -270px; left: -270px;", tooltip: "Delete",  onclick: "return modelDlg_event('btnDelete2');", disabled: true }
        ]
    };
    var toolbar = new Toolbar(toobarData);
    var toolbarVersions = new Toolbar(toolbarVersionsData);
    var dgrid1 = window["<%=dgrid1.UID%>"];
    var dgrid1_selectedRow = 0;
    var dgridVersions_selectedRow = 0;
    var versionid = 0;
    var tgridSecurityTemplate;
    var OnLoad = function (event) {
        toolbar.Render();
        dgrid1.addEventListener("onRowSelect", dgrid1_OnRowSelect);
        OnResize();
    };
    function dgrid1_OnRowSelect(rowid, cellindex) {
        dgrid1_selectedRow = rowid;
        if (rowid != null && rowid > 0) {
            toolbar.enableItem("btnModify");
            toolbar.enableItem("btnDelete");
        }
        else {
            toolbar.disableItem("btnModify");
            toolbar.disableItem("btnDelete");
        }
    };
    function dgridVersions_OnRowSelect(rowid, cellindex) {
        dgridVersions_selectedRow = rowid;
        if (rowid != null && rowid != 0) {
            toolbarVersions.enableItem("btnModify2");
            toolbarVersions.enableItem("btnDelete2");
        }
        else {
            toolbarVersions.disableItem("btnModify2");
            toolbarVersions.disableItem("btnDelete2");
        }
    };
    var OnResize = function (event) {
        var lefttop = dgrid1.GetLeftTopPositions();
        var newHeight = document.documentElement.clientHeight - lefttop[1] - 8;
        dgrid1.SetHeight(newHeight);
        var newWidth = document.documentElement.clientWidth - lefttop[0] - 24;
        dgrid1.SetWidth(newWidth);
    };
    function  DisplayDialog (width, height, title, idWindow, idAttachObj, bModal, bResize) {
        var dlg = jsf_displayDialog(thiswins, 0, 0, width, height, title, idWindow, idAttachObj, bModal, bResize);
        dlg.attachEvent("onClose", function (win) { return CloseDialog(idWindow); });
        var obj = document.getElementById(idAttachObj);
        var useWidth = width;
        if (obj.offsetWidth + 10 > width)
            useWidth = obj.offsetWidth + 10;
        var useHeight = height;
        if (obj.offsetHeight + 105 > height)
            useHeight = obj.offsetHeight + 105;
        if (useHeight != height || useWidth != width) {
            var win = thiswins.window(idWindow);
            win.setDimension(useWidth, useHeight);
        }
        return dlg;
    };
    function CloseDialog (idWindow) {
        switch (idWindow) {
            case 'winModelDlg':
                dgrid1.grid.selectRowById(dgrid1_selectedRow);
                break;
        }
        return jsf_closeDialog(thiswins, idWindow);
    };
    function SendRequest(sXML) {
         sURL = "./Models.ashx";
         return jsf_sendRequest(sURL, sXML);
    };
    function GetStringFromValue(val)
    {
        if (val == null)
            return "";
        return val.toString();
    };
    function toolbar_event(event) {
        var sRowId = "";
        document.getElementById('idModelDlgMode').value = event;
        var bModify = false;
        var dlgTitle = "Add Model";
        switch (event) {
            case "btnModify":
                if (toolbar.isItemDisabled("btnModify") == true) {
                    alert("Select a row to enable the Modify button");
                    return false;
                }
                dlgTitle = "Modify Model";
                bModify = true;
            case "btnAdd":
                sRowId = "0";
                if (event == "btnModify")
                    sRowId = dgrid1_selectedRow;
                var sRequest = '<request function="ModelsRequest" context="ReadModelInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                var fieldId = json.reply.Model.MODEL_UID;
                document.getElementById('txtId').value = fieldId;
                document.getElementById('txtName').value = GetStringFromValue(json.reply.Model.MODEL_NAME);
                document.getElementById('txtDesc').value = GetStringFromValue(json.reply.Model.MODEL_DESC);

                tgridSecurityTemplate = json.reply.Model.tgridSecurity;

                var nCalendar = json.reply.Model.MODEL_CB_ID;
                var idCalendar = document.getElementById('idCalendar');
                idCalendar.options.length = 0;
                var item = json.reply.Model.calendars.item;
                for (var i = 0; i < item.length; i++) {
                    idCalendar.options[idCalendar.options.length] = new Option(item[i].name, item[i].id);
                    if (item[i].id == nCalendar)
                        idCalendar.selectedIndex = idCalendar.options.length - 1;
                }
                var idCostTypesOut = document.getElementById('idCostTypesOut');
                idCostTypesOut.options.length = 0;
                var idCostTypesIn = document.getElementById('idCostTypesIn');
                idCostTypesIn.options.length = 0;
                var item = json.reply.Model.costtypes.item;
                for (var i = 0; i < item.length; i++) {
                    if (item[i].used == 0)
                        idCostTypesOut.options[idCostTypesOut.options.length] = new Option(item[i].name, item[i].id);
                    else
                        idCostTypesIn.options[idCostTypesIn.options.length] = new Option(item[i].name, item[i].id);
                }
                var idSelectedFlag = document.getElementById('idSelectedFlag');
                idSelectedFlag.options.length = 0;
                var item = json.reply.Model.flagcustomfields.item;
                if (typeof item.length == 'undefined')
                    idSelectedFlag.options[idSelectedFlag.options.length] = new Option(item.name, item.id);
                else {
                    for (var i = 0; i < item.length; i++) {
                        idSelectedFlag.options[idSelectedFlag.options.length] = new Option(item[i].name, item[i].id);
                        if (item[i].selected == 1)
                            idSelectedFlag.selectedIndex = idSelectedFlag.options.length - 1;
                    }
                }
                var dgridVersions = window['<%=dgridVersions.UID%>'];
                dgridVersions.Initialize(json.reply.Model.dgridVersionsColumnData,json.reply.Model.dgridVersionsTableData);
                dgridVersions.SetWidth(540);
                dgridVersions.SetHeight(150);
                dgridVersions.grid.setEditable(true);
                toolbarVersions.Render();
                //dgridVersions.addEventListener("OnFocus", dgridVersions_OnFocus);
                dgridVersions.addEventListener("onRowSelect", dgridVersions_OnRowSelect);
                document.getElementById('txtName').disabled = false;
                document.getElementById('txtDesc').disabled = false;
                document.getElementById('idCostTypesOut').disabled = false;
                document.getElementById('idCostTypesIn').disabled = false;
                document.getElementById('idModelVersions').disabled = false;
                toolbarVersions.enable();
                document.getElementById('idDeleteWarning').style.display = "none";
                document.getElementById('idOKButton').value = "OK";
                dgrid1.grid.clearSelection();
                DisplayDialog(592, 664, dlgTitle, "winModelDlg", "idModelDlg", true, false);
                break;
            case "btnDelete":
                if (toolbar.isItemDisabled("btnDelete") == true) {
                    alert("Select a row to enable the Delete button");
                    return false;
                }
                sRowId = dgrid1_selectedRow;
                var sRequest = '<request function="ModelsRequest" context="ReadModelInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                var fieldId = json.reply.Model.MODEL_UID;
                document.getElementById('txtId').value = fieldId;
                document.getElementById('txtName').value = GetStringFromValue(json.reply.Model.MODEL_NAME);
                document.getElementById('txtDesc').value = GetStringFromValue(json.reply.Model.MODEL_DESC);

                tgridSecurityTemplate = json.reply.Model.tgridSecurity;

                var nCalendar = json.reply.Model.MODEL_CB_ID;
                var idCalendar = document.getElementById('idCalendar');
                idCalendar.options.length = 0;
                var item = json.reply.Model.calendars.item;
                for (var i = 0; i < item.length; i++) {
                    idCalendar.options[idCalendar.options.length] = new Option(item[i].name, item[i].id);
                    if (item[i].id == nCalendar)
                        idCalendar.selectedIndex = idCalendar.options.length - 1;
                }
                var idCostTypesOut = document.getElementById('idCostTypesOut');
                idCostTypesOut.options.length = 0;
                var idCostTypesIn = document.getElementById('idCostTypesIn');
                idCostTypesIn.options.length = 0;
                var item = json.reply.Model.costtypes.item;
                for (var i = 0; i < item.length; i++) {
                    if (item[i].used == 0)
                        idCostTypesOut.options[idCostTypesOut.options.length] = new Option(item[i].name, item[i].id);
                    else
                        idCostTypesIn.options[idCostTypesIn.options.length] = new Option(item[i].name, item[i].id);
                }
                var idSelectedFlag = document.getElementById('idSelectedFlag');
                idSelectedFlag.options.length = 0;
                var item = json.reply.Model.flagcustomfields.item;
                for (var i = 0; i < item.length; i++) {
                    idSelectedFlag.options[idSelectedFlag.options.length] = new Option(item[i].name, item[i].id);
                    if (item[i].selected == 1)
                        idSelectedFlag.selectedIndex = idSelectedFlag.options.length - 1;
                }

                var dgridVersions = window['<%=dgridVersions.UID%>'];
                dgridVersions.Initialize(json.reply.Model.dgridVersionsColumnData,json.reply.Model.dgridVersionsTableData);
                dgridVersions.SetWidth(540);
                dgridVersions.SetHeight(150);
                dgridVersions.grid.setEditable(false);
                toolbarVersions.Render();
                //dgridVersions.addEventListener("OnFocus", dgridVersions_OnFocus);
                dgridVersions.addEventListener("onRowSelect", dgridVersions_OnRowSelect);
                dgrid1.grid.clearSelection();

                document.getElementById('txtName').disabled = true;
                document.getElementById('txtDesc').disabled = true;
                document.getElementById('idCostTypesOut').disabled = true;
                document.getElementById('idCostTypesIn').disabled = true;
                document.getElementById('idModelVersions').disabled = true;
                toolbarVersions.disable();
                document.getElementById('idDeleteWarning').style.display = "block";
                document.getElementById('idOKButton').value = "Delete";
                DisplayDialog(592, 684, "Delete Model ", "winModelDlg", "idModelDlg", true, false);
                break;
        }
        return false;
    };
    var modelDlg_event = function (event) {
        document.getElementById('idVersionDlgMode').value = event;
        var sTitle = "";
        switch (event) {
            case "include":
                $("#idCostTypesOut option:selected").appendTo("#idCostTypesIn");
                break;
            case "exclude":
                $("#idCostTypesIn option:selected").appendTo("#idCostTypesOut");
                break;
            case "moveup":
                $("#idCostTypesIn option:selected").each(function (i, selected) {
                   if (!$(this).prev().length) return false;
                   $(this).insertBefore($(this).prev());
                });
                $('#idCostTypesIn option').focus().blur();
                break;
            case "movedown":
                $($('#idCostTypesIn option:selected').get().reverse()).each(function(i, selected) {
                    if (!$(this).next().length) return false;
                    $(this).insertAfter($(this).next());
                });
                $('#idCostTypesIn option').focus().blur();
                break;
            case "calendarchanged":
                var calendarId=document.getElementById('idCalendar').value;
                var sRequest = '<request function="ModelsRequest" context="ReadCalendarInfo"><data><![CDATA[' + calendarId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                break;
            case "btnModify2":
                if (toolbarVersions.isItemDisabled("btnModify2") == true) {
                    alert("Select a row to enable the Modify button");
                    return false;
                }
                sTitle = "Modify Model Version"
                var dgridVersions = window['<%=dgridVersions.UID%>'];
                document.getElementById('txtIdVer').value = dgridVersions.GetCellValue(dgridVersions_selectedRow, "MODEL_VERSION_UID");
                document.getElementById('txtNameVer').value = dgridVersions.GetCellValue(dgridVersions_selectedRow, "MODEL_VERSION_NAME");
                document.getElementById('txtDescVer').value = dgridVersions.GetCellValue(dgridVersions_selectedRow, "MODEL_VERSION_DESC");
            case "btnAdd2":
                if (sTitle == "") {
                    sTitle = "Create Model Version"
                    versionid--;
                    document.getElementById('txtIdVer').value = versionid.toString();
                    document.getElementById('txtNameVer').value = "New Model Version";
                    document.getElementById('txtDescVer').value = "";
                }
                var tgridSecurity = window['<%=tgridSecurity.UID%>'];
                tgridSecurity.Initialize(tgridSecurityTemplate);
                //tgridSecurity.SetWidth(310);
                tgridSecurity.SetHeight(180);
                var sPerms = "";
                if (event == "btnModify2") {
                    sPerms = dgridVersions.GetCellValue(dgridVersions_selectedRow, "MODEL_VERSION_PERMISSIONS_HIDDEN");
                }
                var arrPerms = sPerms.split(",");
                var grid = tgridSecurity.grid;
                var bFirst = true;
                for (i=0;i<arrPerms.length;i++) {
                    var arrPerm = arrPerms[i].split("::");
                    var groupid = arrPerm[0];
                    var groupname = arrPerm[1];
                    var read = arrPerm[2];
                    var readwrite = arrPerm[3];
                    var row = grid.GetFirst(null, 0);
                    while (row != null) {
                        var sID = grid.GetAttribute(row, null, "GROUP_ID");
                        if (bFirst) {
                            grid.SetAttribute(row, null, "DS_READ", 0, 1, 0);
                            grid.SetAttribute(row, null, "DS_EDIT", 0, 1, 0);
                        }
                        if (groupid == sID) {
                            grid.SetAttribute(row, null, "DS_READ", read, 1, 0);
                            grid.SetAttribute(row, null, "DS_EDIT", readwrite, 1, 0);
                        }
                        row = grid.GetNext(row);
                    }
                    bFirst = false;
                }
                thiswins.window('winModelDlg').setModal(false);
                DisplayDialog(393, 368, sTitle, "winVersionDlg", "idVersionDlg", true, false);
                break;
            case "btnDelete2":
                if (toolbarVersions.isItemDisabled("btnDelete2") == true) {
                    alert("Select a row to enable the Delete button");
                    return false;
                }
                var dgridVersions = window['<%=dgridVersions.UID%>'];
                dgridVersions.SetCellValue(dgridVersions_selectedRow, "Deleted", 1);
                dgridVersions.grid.setRowHidden(dgridVersions_selectedRow, true);
                break;
            case "ok":
                var action = document.getElementById('idModelDlgMode').value;
                switch (action) {
                    case "btnAdd":
                    case "btnModify":
                        //alert("btnModify.OK");
                        var sRowId = dgrid1_selectedRow;
                        var sb = new StringBuilder();
                        sb.append('<request function="ModelsRequest" context="UpdateModelInfo">');
                        sb.append('<data');
                        sb.append(' MODEL_UID="' + document.getElementById('txtId').value + '"');
                        sb.append(' MODEL_NAME="' + jsf_xml(document.getElementById('txtName').value) + '"');
                        sb.append(' MODEL_DESC="' + jsf_xml(document.getElementById('txtDesc').value) + '"');
                        var calendarId=document.getElementById('idCalendar').value;
                        sb.append(' MODEL_COST_BREAKDOWN="' + calendarId + '"');
                        var sCTs = "";
                        var idCostTypesIn = document.getElementById('idCostTypesIn');
                        for (var i = 0; i < idCostTypesIn.options.length; i++) {
                            if (i > 0)
                                sCTs += ",";
                            sCTs += idCostTypesIn.options[i].value;
                        }
                        sb.append(' MODEL_CTS="' + jsf_xml(sCTs) + '"');
                        var idSelectedFlag = document.getElementById('idSelectedFlag');

                        var cf = -1;
                        if (idSelectedFlag.options.selectedIndex > -1) {
                            var item = idSelectedFlag.options[idSelectedFlag.options.selectedIndex];
                            cf = item.value;
                        }

                        sb.append(' MODEL_CUSTOM_FIELD="' + cf + '"');
                        sb.append('>');
                        var dgridVersions = window['<%=dgridVersions.UID%>'];
                        sb.append('<![CDATA[' + dgridVersions.GetXmlData() + ']]>');
                        sb.append('</data>');
                        sb.append('</request>'); 
                        var sRequest = sb.toString();
                        var jsonString = SendRequest(sRequest);
                        var json = JSON_ConvertString(jsonString);
                        if (json.reply != null) {
                            if (jsf_alertError(json.reply.error) == true)
                                return false;
                        }
                        if (action == "btnAdd") {
                            sRowId = json.reply.Model.MODEL_UID;
                            dgrid1.addRow(sRowId);
                        }
                        dgrid1.SetCellValue(sRowId, "MODEL_UID", json.reply.Model.MODEL_UID);
                        dgrid1.SetCellValue(sRowId, "MODEL_NAME", json.reply.Model.MODEL_NAME);
                        dgrid1.SetCellValue(sRowId, "MODEL_DESC", json.reply.Model.MODEL_DESC);
                        dgrid1.reapplySort();
                        dgrid1.selectRow(sRowId);
                        break;
                    case "btnDelete":
                        var sRowId = dgrid1_selectedRow;
                        var sb = new StringBuilder();
                        sb.append('<request function="ModelsRequest" context="DeleteModelInfo">');
                        sb.append('<data');
                        sb.append(' MODEL_UID="' + document.getElementById('txtId').value + '"');
                        sb.append('/>');
                        sb.append('</request>'); 
                        var sRequest = sb.toString();
                        var jsonString = SendRequest(sRequest);
                        var json = JSON_ConvertString(jsonString);
                        if (json.reply != null) {
                            if (jsf_alertError(json.reply.error) == true)
                                return false;
                        }
                        // if deleted  then remove row from grid
                        dgrid1.deleteRow(sRowId);
                        dgrid1_OnRowSelect(0);
                        break;
                }
                CloseDialog('winModelDlg');
            break;
            case "cancel":
                CloseDialog('winModelDlg');
                break;
        }
    };
    var versionDlg_event = function (event) {
        switch (event) {
            case "ok":
                var action = document.getElementById('idVersionDlgMode').value;
                switch (action) {
                    case "btnAdd2":
                    case "btnModify2":
                        var tgridSecurity = window['<%=tgridSecurity.UID%>'];
                        var grid = tgridSecurity.grid;
                        var row = grid.GetFirst(null, 0);
                        var sPerms = "";
                        var sPermsHidden = "";
                        while (row != null) {
                            var read = grid.GetAttribute(row, null, "DS_READ");
                            var readwrite = grid.GetAttribute(row, null, "DS_EDIT");
                            if (read == 1 || readwrite == 1) {
                                var sID = grid.GetAttribute(row, null, "GROUP_ID");
                                var sName = grid.GetAttribute(row, null, "GROUP_NAME");
                                var sMode = "Read Only";
                                if (readwrite == 1)
                                    sMode = "Read/Write";
                                var sPerm = sName + "(" + sMode + ")";
                                if (sPerms != "")
                                    sPerms+= ",";
                                sPerms += sPerm;
                                var sPermHidden = sID + "::" + sName + "::" + read + "::" + readwrite;
                                if (sPermsHidden != "")
                                    sPermsHidden+= ",";
                                sPermsHidden += sPermHidden;
                            }
                            row = grid.GetNext(row);
                        }
                        var dgridVersions = window['<%=dgridVersions.UID%>'];

                        
                        dgridVersions_selectedRow = document.getElementById('txtIdVer').value;
                        if (action == "btnAdd2") {
                            dgridVersions.addRow(dgridVersions_selectedRow);
                            dgridVersions_OnRowSelect(dgridVersions_selectedRow);
                        }
                        dgridVersions.SetCellValue(dgridVersions_selectedRow, "MODEL_VERSION_UID", document.getElementById('txtIdVer').value);
                        dgridVersions.SetCellValue(dgridVersions_selectedRow, "MODEL_VERSION_NAME", document.getElementById('txtNameVer').value);
                        dgridVersions.SetCellValue(dgridVersions_selectedRow, "MODEL_VERSION_DESC", document.getElementById('txtDescVer').value);
                        dgridVersions.SetCellValue(dgridVersions_selectedRow, "MODEL_VERSION_PERMISSIONS", sPerms);
                        dgridVersions.SetCellValue(dgridVersions_selectedRow, "MODEL_VERSION_PERMISSIONS_HIDDEN", sPermsHidden);
                        break;
                    case "btnDelete2":
                        break;
                }
                CloseDialog('winVersionDlg');
                thiswins.window('winModelDlg').setModal(true);
                break;
            case "cancel":
                CloseDialog('winVersionDlg');
                thiswins.window('winModelDlg').setModal(true);
                break;
        }
    };

    var thiswins = new dhtmlXWindows();
    thiswins.setImagePath("../epmlive/dhtml/windows/imgs/");
    thiswins.setSkin("dhx_web");
    var thiswins2 = null;

    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("load", OnLoad, true);
        window.addEventListener("resize", OnResize, true);
    }
    else { // e.g. IE
        window.attachEvent("onload", OnLoad);
        window.attachEvent("onresize", OnResize);
    }
</script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Models
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Models
</asp:Content>
