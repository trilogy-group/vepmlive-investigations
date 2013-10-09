<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register src="Tools/DGrid.ascx" tagname="DGridUserControl" tagprefix="dg1" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grouppermissions_NAX.aspx.cs" Inherits="WorkEnginePPM.Layouts.ppm.grouppermissions_NAX" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Reference Control="/_layouts/ppm/tools/DGrid.ascx" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script src="tools/jsfunctions.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="styles/form.css"/>
<script type="text/javascript" src="/_layouts/epmlive/TreeGrid/GridE.js"></script>
<script src="general.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="styles/dialognew.css" />
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

.GMFocusRowBorder {
    border: 0px !important;
}

</style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<div class="modalContent" id="idGroupPermissionsDlg" style="display:none;">
    <input id="idGroupPermissionsDlgMode" type="hidden" value="" />
    <div>
        <table width="100%" cellspacing="0">
            <tr>
                <td style="height:1px;" width="250" class="topcell"></td>
                <td style="height:1px;" class="topcell"></td>
            </tr>
            <tr style="display:none;">
                <td width="250" class="descriptioncell">
                    Field Id
                </td>
                <td class="controlcell">
                    <input type="text" id="txtId" />
                </td>
            </tr>
            <tr>
                <td width="250" class="descriptioncell">
                    Group Name
                </td>
                <td class="controlcell">
                     <input type="text" id="txtName" style="width:400px;" />
               </td>
            </tr>
            <tr>
                <td width="250" class="descriptioncell">
                    Group Description
                </td>
                <td class="controlcell">
                      <input type="text" id="txtDesc" style="width:400px;" />
               </td>
            </tr>
            <tr>
                 <td width="250" class="descriptioncell">
                    Permissions
                </td>
                <td  class="controlcell" style="vertical-align:top; ">
                     <div id='idtg1' style="width:400px; height:350px;"></div>
                </td>
            </tr>
        </table>
    </div>
	<div style="float:right;">
		<div class="button-container" >
			<input type="button" class="epmliveButton" value="OK" onclick="groupPermissionsDlg_event('ok');"/>
			<input type="button" class="epmliveButton" value="Cancel" onclick="groupPermissionsDlg_event('cancel');"/>
		</div>
	</div>
</div>
<div class="modalContent" id="idGroupMembersDlg" style="display:none;">
    <div style="width:260px; height:250px;">
        <dg1:DGridUserControl id="dgrid2" runat="server"/>
    </div>
	<div style="float:right;">
		<div class="button-container" >
			<input type="button" class="epmliveButton" value="Close" onclick="groupMembersDlg_event('cancel');"/>
		</div>
	</div>
</div>
<asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
<div id="idToolbarDiv"></div>
<dg1:DGridUserControl id="dgrid1" runat="server" />

<script type="text/javascript">
    var toobarData = {
        parent: "idToolbarDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", name: "ADD", img: "formatmap16x16_2.png", style: "top: -90px; left: -216px;", tooltip: "Add", onclick: "toolbar_event('btnAdd');" },
            { type: "button", id: "btnModify", name: "MODIFY", img: "formatmap16x16_2.png", style: "top: -243px; left: -55px;", tooltip: "Modify", onclick: "return toolbar_event('btnModify');", disabled: true },
            { type: "button", id: "btnDelete", name: "DELETE", img: "formatmap16x16_2.png", style: "top: -270px; left: -270px;", tooltip: "Delete",  onclick: "return toolbar_event('btnDelete');", disabled: true },
            { type: "button", id: "btnMembers", name: "MEMBERS", img: "formatmap16x16_2.png", style: "top: -90px; left: -252px;", tooltip: "Group Members", onclick: "return toolbar_event('btnMembers');", disabled: true }
        ]
    };

    var treegridData;
    var toolbar = new Toolbar(toobarData);
    
    var dgrid1 = window["<%=dgrid1.UID%>"];
    var dgrid1_selectedRow = 0;
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
            toolbar.enableItem("btnMembers");
        }
        else {
            toolbar.disableItem("btnModify");
            toolbar.disableItem("btnDelete");
            toolbar.disableItem("btnMembers");
        }
    };
    var OnResize = function (event) {
        var lefttop = dgrid1.GetLeftTopPositions();
        var newHeight = document.documentElement.clientHeight - lefttop[1] - 8;
        dgrid1.SetHeight(newHeight);
        var newWidth = document.documentElement.clientWidth - lefttop[0] - 24;
        dgrid1.SetWidth(newWidth);
    };
    function SendRequest(sXML) {
         sURL = "./GroupPermissions.ashx";
         return jsf_sendRequest(sURL, sXML);
    };

    function toolbar_event(event) {
        var sRowId = "";
        var sMode = "";
        var sDlgTitle = "";
        document.getElementById('idGroupPermissionsDlgMode').value = event;
        switch (event) {
            case "btnAdd":
                GetGroupPermissions("Add", "Add Permission Group", 0);
                break;
            case "btnModify":
                 if (toolbar.isItemDisabled("btnModify") == true) {
                    alert("Select a row to enable the Modify button");
                    return false;
                }
                GetGroupPermissions("Modify", "Modify Group Permissions", dgrid1_selectedRow);
                break;
            case "btnDelete":
                if (toolbar.isItemDisabled("btnDelete") == true) {
                    alert("Select a row to enable the Delete button");
                    return false;
                }
                GetGroupPermissions("Delete", "Delete Permission Group, are you sure?", dgrid1_selectedRow);
                break;
            case "btnMembers":
                if (toolbar.isItemDisabled("btnMembers") == true) {
                    alert("Select a row to enable the Members button");
                    return false;
                }
                GetGroupMembers(dgrid1_selectedRow);
                break;
        }
    };
    function GetGroupPermissions(sMode, sDlgTitle, sRowId) {
        var sRequest = '<request function="GroupPermissionsRequest" context="GetGroupPermissionsInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
        var jsonString = SendRequest(sRequest);
        var json = JSON_ConvertString(jsonString);
        if (json.reply != null) {
            if (jsf_alertError(json.reply.error) == true)
                return false;
        }

        document.getElementById('txtId').value = json.reply.groupPermissions.groupid;
        document.getElementById('txtName').value = json.reply.groupPermissions.name;
        document.getElementById('txtDesc').value = json.reply.groupPermissions.notes;
        treegridData = json.reply.groupPermissions.treegridData;
        DisposeGrids();
        var grid = TreeGrid("<treegrid debug='0' sync='1' Data_Script='treegridData' ></treegrid>", "idtg1");

       dgrid1.grid.clearSelection();
       DisplayDialog(570, 540, sDlgTitle, "winGroupPermissionsDlg", "idGroupPermissionsDlg", true, false);
   };
   function GetGroupMembers(sRowId) {
        var sRequest = '<request function="GroupPermissionsRequest" context="GetGroupMembersInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
        var jsonString = SendRequest(sRequest);
        var json = JSON_ConvertString(jsonString);
        if (json.reply != null) {
            if (jsf_alertError(json.reply.error) == true)
                return false;
        }

        var dgrid2 = window["<%=dgrid2.UID%>"];

        var columnData = json.reply.groupMembers.columnData;
        var tableData = json.reply.groupMembers.tableData;
        dgrid2.Initialize(columnData, tableData);
        dgrid2.SetHeight(250);
        //dgrid2.SetWidth(260);
        var groupName = dgrid1.GetCellValue(sRowId, "GROUP_NAME");

        DisplayDialog(300, 360, "Members for Group " + groupName, "winGroupMembersDlg", "idGroupMembersDlg", true, false);
   };
   function NewItemCallback(dialogResult, returnValue) {
        if (dialogResult) {
            window.location.href = window.location.href;
        }
   };
    
    function  DisplayDialog (width, height, title, idWindow, idAttachObj, bModal, bResize) {
        var dlg = jsf_displayDialog(thiswins, 0, 0, width, height, title, idWindow, idAttachObj, bModal, bResize);
        dlg.attachEvent("onClose", function (win) { return CloseDialog(idWindow); });
        return dlg;
    };

    function CloseDialog (idWindow) {
        switch (idWindow) {
            case 'winGroupPermissionsDlg':
                dgrid1.grid.selectRowById(dgrid1_selectedRow);
                break;
        }
        return jsf_closeDialog(thiswins, idWindow);
    };

    var groupPermissionsDlg_event = function (event) {
       var action = document.getElementById('idGroupPermissionsDlgMode').value;
       switch (event) {
            case "ok":
                switch (action) {
                    case "btnAdd":
                    case "btnModify":
                        //alert(action + ".OK");
                        var s = Grids[0].GetXmlData("Data,AllCols");
                        var sb = new StringBuilder();
                        sb.append('<request function="GroupPermissionsRequest" context="UpdateGroupPermissionsInfo">');
                        sb.append('<data');
                        sb.append(' groupid="' + document.getElementById('txtId').value + '"');
                        sb.append(' name="' + jsf_xml(document.getElementById('txtName').value) + '"');
                        sb.append(' notes="' + jsf_xml(document.getElementById('txtDesc').value) + '"');
                        sb.append('>');
                        sb.append('<treegridData><![CDATA[' + s + ']]></treegridData>');
                        sb.append('</data>');
                        sb.append('</request>'); 
                        var sRequest = sb.toString();
                        var jsonString = SendRequest(sRequest);
                        var json = JSON_ConvertString(jsonString);
                        if (json.reply != null) {
                            if (jsf_alertError(json.reply.error) == true)
                                return false;
                        }
                        if (action == "btnModify") {
                        var sRowId = dgrid1_selectedRow;
                        }
                        if (action == "btnAdd") {
                            sRowId = json.reply.groupPermissions.groupid;
                            dgrid1.addRow(sRowId);
                        }
                        var val = document.getElementById('txtName').value;
                        dgrid1.SetCellValue(sRowId, "GROUP_NAME", val);
                        dgrid1.SetCellValue(sRowId, "GROUP_NOTES", document.getElementById('txtDesc').value);
                        dgrid1.reapplySort();
                        dgrid1.selectRow(sRowId);
                        break;
                    case "btnDelete":
                        //alert("btnDelete.OK");
                        var s = Grids[0].GetXmlData("Data,AllCols");
                        var sb = new StringBuilder();
                        sb.append('<request function="GroupPermissionsRequest" context="DeleteGroupPermission">');
                        sb.append('<data');
                        sb.append(' groupid="' + document.getElementById('txtId').value + '"');
                        sb.append(' name="' + jsf_xml(document.getElementById('txtName').value) + '"');
                        sb.append(' notes="' + jsf_xml(document.getElementById('txtDesc').value) + '"');
                        sb.append('>');
                        sb.append('<treegridData><![CDATA[' + s + ']]></treegridData>');
                        sb.append('</data>');
                        sb.append('</request>'); 
                        var sRequest = sb.toString();
                        var jsonString = SendRequest(sRequest);
                        var json = JSON_ConvertString(jsonString);
                        if (json.reply != null) {
                            if (jsf_alertError(json.reply.error) == true)
                                return false;
                        }
                        // if deleted  then remove row from grid
                        var sRowId = dgrid1_selectedRow;
                        dgrid1.deleteRow(sRowId);
                        dgrid1_OnRowSelect(0);
                   break;
                }
                CloseDialog('winGroupPermissionsDlg');
                break;
            case "cancel":
                CloseDialog('winGroupPermissionsDlg');
                break;
        }
    };
    var groupMembersDlg_event = function (event) {
        CloseDialog('winGroupMembersDlg');
    };
    var thiswins = new dhtmlXWindows();
    thiswins.setImagePath("/_layouts/ppm/images/");
    thiswins.setSkin("dhx_web");

    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("load", OnLoad, true);
        window.addEventListener("resize", OnResize, true);
        //window.addEventListener("beforeunload", beforeUnloadDelegate, true);
        //window.addEventListener("unload", unloadDelegate, true);
    }
    else { // e.g. IE
        window.attachEvent("onload", OnLoad);
        window.attachEvent("onresize", OnResize);
        //window.attachEvent("onbeforeunload", beforeUnloadDelegate);
        //window.attachEvent("onunload", unloadDelegate);
    }
</script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Group Permissions
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Group Permissions
</asp:Content>
