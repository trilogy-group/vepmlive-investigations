<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register src="Tools/DGrid.ascx" tagname="DGridUserControl" tagprefix="dg1" %>
<%@ Register src="Tools/TGrid.ascx" tagname="TGridUserControl" tagprefix="tg1" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lookups_NAX.aspx.cs" Inherits="WorkEnginePPM.Lookups_NAX" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Reference Control="/_layouts/ppm/tools/DGrid.ascx" %>
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
<div class="modalContent" id="idLookupDlg" style="display:none;">
    <input id="idLookupDlgMode" type="hidden" value="" />
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
                <label for="txtName">Lookup Name</label>
            </td>
            <td class="controlcell">
                <input type="text" id="txtName" style="width:350px;" />
            </td>
        </tr>
        <tr>
            <td class="descriptioncell">
                Lookup Description
            </td>
            <td class="controlcell">
                    <input type="text" id="txtDesc" style="Width:350px;"/>
            </td>
        </tr>
    </table>
    <div style="width:516px; display:block; padding-top: 0px; padding-bottom: 10px;">
        <table cellpadding="5">
            <tr>
                <td class="descriptioncell">
                    Enter the lookup values:</td>
            </tr>
            <tr>
                <td class="descriptioncell">
                    <div id="idToolbarLVDiv"></div></td>
            </tr>
            <tr>
                <td class="descriptioncell">
                    <div style="display:block;"><tg1:TGridUserControl id="tgridLV" runat="server" /></div>
                </td>
            </tr>
        </table>
    </div>
    <div id="idDeleteWarning" style="width:300px; color:red; display:none;"><a>Are you sure, all data will be cleared?</a></div>
	<div class="button-container" >
		<input id="idOKButton" type="button" class="epmliveButton" value="OK" onclick="LookupDlg_event('ok');"/>
		<input type="button" class="epmliveButton" value="Cancel" onclick="LookupDlg_event('cancel');"/>
	</div>
</div>
<div style="display: block;" >
<asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
<div id="idToolbarDiv"></div>
<dg1:DGridUserControl id="dgrid1" runat="server" />
</div>
<script type="text/javascript">
    var toolbarData = {
        parent: "idToolbarDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", name: "ADD", img: "formatmap16x16_2.png", style: "top: -90px; left: -216px;", tooltip: "Add", onclick: "toolbar_event('btnAdd');" },
            { type: "button", id: "btnModify", name: "MODIFY", img: "formatmap16x16_2.png", style: "top: -243px; left: -55px;", tooltip: "Modify", onclick: "return toolbar_event('btnModify');", disabled: true },
            { type: "button", id: "btnDelete", name: "DELETE", img: "formatmap16x16_2.png", style: "top: -270px; left: -270px;", tooltip: "Delete",  onclick: "return toolbar_event('btnDelete');", disabled: true }
        ]
    };
    var toolbarLVData = {
        parent: "idToolbarLVDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", name: "Add", img: "addresource.gif", tooltip: "Add", width: "80px", onclick: "toolbarLV_event('btnAddLV');" },
            { type: "button", id: "btnInsertLV", name: "Insert", img: "editview.gif", tooltip: "Modify", width: "80px", onclick: "return toolbarLV_event('btnInsertLV');", disabled: true },
            { type: "button", id: "btnDeleteLV", name: "Delete", img: "delete.png", tooltip: "Delete", width: "80px", onclick: "return toolbarLV_event('btnDeleteLV');", disabled: true }
        ]
    };
    var toolbar = new Toolbar(toolbarData);
    var toolbarLV = new Toolbar(toolbarLVData);
    var tgridLV = window['<%=tgridLV.UID%>'];
    var dgrid1 = window['<%=dgrid1.UID%>'];
    var dgrid1_selectedRow = 0;
    var OnLoad = function (event) {
        Grids.OnClick = GridsOnClick;
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
    function GridsOnClick(grid, row, col) {
        switch (grid.id) {
            case tgridLV.id:
                tgridLV_selectedRow = row;
                if (row != null && row != "") {
                    toolbarLV.enableItem("btnInsertLV");
                    toolbarLV.enableItem("btnDeleteLV");
                }
                else {
                    toolbarLV.disableItem("btnInsertLV");
                    toolbarLV.disableItem("btnDeleteLV");
                }
                if (col == "LV_INACTIVE") {
                    if (row.firstChild != null)
                        window.setTimeout("SetChildrenCheckboxStates('" + row.id + "');", 10);
                    if (row.Level > 0) {
                        window.setTimeout("SetParentCheckboxStates('" + row.id + "');", 10);
                    }
                }
                break;
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
        ResizeDialog(idWindow, idAttachObj);
        window.setTimeout('ResizeDialog("' + idWindow + '", "' + idAttachObj + '");', 10);
        return dlg;
    };
    function ResizeDialog(idWindow, idAttachObj) {
        var obj = document.getElementById(idAttachObj);
        var width = GetMaxWidth(obj) + 20;
        var height = obj.offsetHeight;
        var win = thiswins.window(idWindow);
        win.setDimension(width + 13, height + 110);
    };
    function GetMaxWidth(obj) {
        var width = 0;
        var childDivs = obj.childNodes;
        for( i=0; i< childDivs.length; i++ )
        {
            var childDiv = childDivs[i];
            if (childDiv.offsetWidth > width)
                width = childDiv.offsetWidth;
        }
        return width;
    };
    function CloseDialog (idWindow) {
        switch (idWindow) {
            case 'winLookupDlg':
                dgrid1.grid.selectRowById(dgrid1_selectedRow);
                break;
        }
        return jsf_closeDialog(thiswins, idWindow);
    };
    function SendRequest(sXML) {
         sURL = "./Lookups.ashx";
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
        document.getElementById('idLookupDlgMode').value = event;
        var bModify = false;
        var dlgTitle = "Add Lookup";
        switch (event) {
            case "btnModify":
                if (toolbar.isItemDisabled("btnModify") == true) {
                    alert("Select a row to enable the Modify button");
                    return false;
                }
                dlgTitle = "Modify Lookup";
                bModify = true;
            case "btnAdd":
                sRowId = "0";
                if (event == "btnModify")
                    sRowId = dgrid1_selectedRow;
                var sRequest = '<request function="LookupsRequest" context="ReadLookupInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                toolbarLV.Render();
                var fieldId = json.reply.Lookup.LOOKUP_UID;
                document.getElementById('txtId').value = fieldId;
                document.getElementById('txtName').value = GetStringFromValue(json.reply.Lookup.LOOKUP_NAME);
                document.getElementById('txtDesc').value = GetStringFromValue(json.reply.Lookup.LOOKUP_DESC);
                document.getElementById('txtName').disabled = false;
                document.getElementById('txtDesc').disabled = false;
                tgridLV.Initialize(json.reply.Lookup.tgridLVData);
                tgridLV.SetWidth(440);
                tgridLV.SetHeight(120);
                document.getElementById('idDeleteWarning').style.display = "none";
                document.getElementById('idOKButton').value = "OK";
                dgrid1.grid.clearSelection();
                DisplayDialog(645, 550, dlgTitle, "winLookupDlg", "idLookupDlg", true, false);
                break;
            case "btnDelete":
                if (toolbar.isItemDisabled("btnDelete") == true) {
                    alert("Select a row to enable the Delete button");
                    return false;
                }
                sRowId = dgrid1_selectedRow;
                var sRequest = '<request function="LookupsRequest" context="ReadLookupInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                toolbarLV.Render();
                var fieldId = json.reply.Lookup.LOOKUP_UID;
                document.getElementById('txtId').value = fieldId;
                document.getElementById('txtName').value = GetStringFromValue(json.reply.Lookup.LOOKUP_NAME);
                document.getElementById('txtDesc').value = GetStringFromValue(json.reply.Lookup.LOOKUP_DESC);
                document.getElementById('txtName').disabled = true;
                document.getElementById('txtDesc').disabled = true;
                tgridLV.Initialize(json.reply.Lookup.tgridLVData);
                tgridLV.SetWidth(440);
                tgridLV.SetHeight(120);

                
                document.getElementById('idDeleteWarning').style.display = "block";
                document.getElementById('idOKButton').value = "Delete";
                dgrid1.grid.clearSelection();
                DisplayDialog(445, 360, "Delete Lookup - " /*+ json.reply.Lookup.LOOKUP_NAME*/, "winLookupDlg", "idLookupDlg", true, false);
                break;
        }
        return false;
    };
    function toolbarLV_event(event) {
    var dlgTitle = "";
    switch (event) {
        case "btnInsertLV":
            if (toolbarLV.isItemDisabled("btnInsertLV") == true) {
                alert("Select a row to enable the Insert button");
                return false;
            }
        case "btnAddLV":
            var newrow;
            if (event == "btnInsertLV") {
                newrow = tgridLV.grid.AddRow(null, tgridLV_selectedRow, true);
            }
            else {
                newrow = tgridLV.grid.AddRow(null, null, true);
            }
            tgridLV.SetCellValue(newrow, "LV_UID", 0);
            tgridLV.SetCellValue(newrow, "LV_NAME", "New Value");
            tgridLV_selectedRow = newrow;
            tgridLV.Focus(newrow, 'LV_NAME');
            break;
        case "btnDeleteLV":
            if (toolbarLV.isItemDisabled("btnDeleteLV") == true) {
                alert("Select a row to enable the Delete button");
                return false;
            }
            var sItems = BuildDeleteList(tgridLV.grid, tgridLV_selectedRow);

            var sRequest = '<request function="LookupsRequest" context="CanDeleteLookupRows"><data><![CDATA[' + sItems + ']]></data></request>';
            var jsonString = SendRequest(sRequest);
            var json = JSON_ConvertString(jsonString);
            if (json.reply != null) {
                if (jsf_alertError(json.reply.error) == true)
                    return false;
            }
            tgridLV.grid.DeleteRow(tgridLV_selectedRow, 2); // 1=okmsg+del; 2=del; 3=undel
            GridsOnClick(tgridLV.grid, null, null)
            break;
    }
    return false;
};
function BuildDeleteList(grid, row) {
    var lvuid = grid.GetAttribute(row, "LV_UID", null);
    var sItems = lvuid.toString();
    var childrow = row.firstChild;
    if (childrow != null)
        sItems += "," + AddChildrenToList(grid, childrow);
    return sItems;
};
function AddChildrenToList(grid, row) { 
    var sItems = "";
    while (row != null) {
        var lvuid = grid.GetAttribute(row, "LV_UID", null);
        if (sItems != "")
            sItems += ",";
        sItems += lvuid.toString();
        var childrow = row.firstChild;
        if (childrow != null) {
            var sChildItems = AddChildrenToList(grid, childrow);
            if (sItems != "")
                sItems += ",";
            sItems += sChildItems;
        }
        row = row.nextSibling;
    }
    return sItems;
};
function SetChildrenCheckboxStates(rowid) {
        var grid = tgridLV.grid;
        var row = grid.GetRowById(rowid);
        if (row != null) {
            var childrow = row.firstChild;
            var cb = grid.GetAttribute(row, "LV_INACTIVE", null);
            while (childrow != null) {
                grid.SetAttribute(childrow, null, "LV_INACTIVE", cb, 1, 0);
                if (childrow.firstChild != null)
                    window.setTimeout("SetChildrenCheckboxStates('" + childrow.id + "');", 10);
                childrow = childrow.nextSibling;
            }
        }
    };
    function SetParentCheckboxStates(rowid) {
        var grid = tgridLV.grid;
        var row = grid.GetRowById(rowid);
        if (row != null && row.Level > 0) {
            var cb = grid.GetAttribute(row, "LV_INACTIVE", null);
            if (cb == "0") {
                var parentRow = row.parentNode;
                grid.SetAttribute(parentRow, null, "LV_INACTIVE", cb, 1, 0);
                if (parentRow.Level > 0)
                    window.setTimeout("SetParentCheckboxStates('" + parentRow.id + "');", 10);
            }
        }
    };
var LookupDlg_event = function (event) {
        switch (event) {
            case "ok":
                var action = document.getElementById('idLookupDlgMode').value;
                switch (action) {
                    case "btnAdd":
                    case "btnModify":
                        var sRowId = dgrid1_selectedRow;
                        var sb = new StringBuilder();
                        sb.append('<request function="LookupsRequest" context="UpdateLookupInfo">');
                        sb.append('<data');
                        sb.append(' LOOKUP_UID="' + document.getElementById('txtId').value + '"');
                        sb.append(' LOOKUP_NAME="' + jsf_xml(document.getElementById('txtName').value) + '"');
                        sb.append(' LOOKUP_DESC="' + jsf_xml(document.getElementById('txtDesc').value) + '"');
                        sb.append('>');
                        sb.append('<![CDATA[' + tgridLV.GetXmlData() + ']]>');
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
                            sRowId = json.reply.Lookup.LOOKUP_UID;
                            dgrid1.addRow(sRowId);
                        }
                        dgrid1.SetCellValue(sRowId, "LOOKUP_UID", json.reply.Lookup.LOOKUP_UID);
                        dgrid1.SetCellValue(sRowId, "LOOKUP_NAME", json.reply.Lookup.LOOKUP_NAME);
                        dgrid1.SetCellValue(sRowId, "LOOKUP_DESC", json.reply.Lookup.LOOKUP_DESC);
                        dgrid1.reapplySort();
                        dgrid1.selectRow(sRowId);
                        break;
                    case "btnDelete":
                        var sRowId = dgrid1_selectedRow;
                        var sb = new StringBuilder();
                        sb.append('<request function="LookupsRequest" context="DeleteLookupInfo">');
                        sb.append('<data');
                        sb.append(' LOOKUP_UID="' + document.getElementById('txtId').value + '"');
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
                CloseDialog('winLookupDlg');
                break;
            case "cancel":
                CloseDialog('winLookupDlg');
                break;
        }
    };

    var thiswins = new dhtmlXWindows();
    thiswins.setImagePath("/_layouts/ppm/images/");
    thiswins.setSkin("dhx_web");

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
Lookups
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Lookups
</asp:Content>
