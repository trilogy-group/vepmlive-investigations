<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register src="Tools/DGrid.ascx" tagname="DGridUserControl" tagprefix="dg1" %>
<%@ Register src="Tools/TGrid.ascx" tagname="TGridUserControl" tagprefix="tg1" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendars_NAX.aspx.cs" Inherits="WorkEnginePPM.Layouts.ppm.Calendars_NAX" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Reference Control="/_layouts/ppm/tools/DGrid.ascx" %>
<%@ Reference Control="/_layouts/ppm/tools/TGrid.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script src="tools/jsfunctions.js" type="text/javascript"></script>
<script src="general.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="styles/form.css" />
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
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<div style="display: block;" >
<div class="modalContent" id="idCalendarDlg" style="display:none;">
    <input id="idCalendarDlgMode" type="hidden" value="" />
    <div id="idToolbar2Div"></div>
	<div style="margin-top:10px;padding-right:10px;">
		<div style="padding-bottom:3px;">
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
                        Field Name
                    </td>
                    <td class="controlcell">
                        <input type="text" id="txtName" style="Width:400px;"/>
                    </td>
                </tr>
                <tr>
                    <td width="250" class="descriptioncell" style="vertical-align:top;" >
                        Periods
                    </td>
                    <td class="controlcell" style="Width:400px;">
                       <tg1:TGridUserControl id="tgrid1" runat="server" />
                    </td>
               </tr>
            </table>
		</div>
		<div style="float:right;">
			<div class="button-container" >
			    <input id="idOKButton" type="button" class="epmliveButton" value="OK" onclick="calendarDlg_event('ok');"/>
			    <input type="button" class="epmliveButton" value="Cancel" onclick="calendarDlg_event('cancel');"/>
			</div>
		</div>
	</div>
</div>

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
            { type: "button", name: "Add", img: "addresource.gif", tooltip: "Add", width: "80px", onclick: "toolbar_event('btnAdd');" },
            { type: "button", id: "btnModify", name: "Modify", img: "editview.gif", tooltip: "Modify", width: "80px", onclick: "return toolbar_event('btnModify');", disabled: true },
            { type: "button", id: "btnDelete", name: "Delete", img: "delete.png", tooltip: "Delete", width: "80px", onclick: "return toolbar_event('btnDelete');", disabled: true }
        ]
    };
    var toolbar2Data = {
        parent: "idToolbar2Div",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", name: "Add", img: "addresource.gif", tooltip: "Add", width: "80px", onclick: "toolbar2_event('btnAdd2');" },
            { type: "button", id: "btnInsert2", name: "Insert", img: "editview.gif", tooltip: "Modify", width: "80px", onclick: "return toolbar2_event('btnInsert2');", disabled: true },
            { type: "button", id: "btnDelete2", name: "Delete", img: "delete.png", tooltip: "Delete", width: "80px", onclick: "return toolbar2_event('btnDelete2');", disabled: true }
        ]
    };

    var toolbar = new Toolbar(toolbarData);
    var toolbar2 = new Toolbar(toolbar2Data);
    
    var dgrid1 = window.<%=dgrid1.UID%>;
    var dgrid1_selectedRow = 0;
    var tgrid1 = window['<%=tgrid1.UID%>'];
    var tgrid1_selectedRow = 0;

    function OnLoad(event) {
        toolbar.Render();
        Grids.OnClickCell = GridsOnClickCell;
        dgrid1.addEventListener("onRowSelect", dgrid1_OnRowSelect);
        OnResize();
    };
    function dgrid1_OnRowSelect(rowid, cellindex) {
        dgrid1_selectedRow = rowid;
        if (rowid != null && rowid >= 0) {
            toolbar.enableItem("btnModify");
            toolbar.enableItem("btnDelete");
        }
        else {
            toolbar.disableItem("btnModify");
            toolbar.disableItem("btnDelete");
        }
    };
    function GridsOnClickCell(grid, row, col) {
        switch (grid.id) {
            case tgrid1.id:
                tgrid1_selectedRow = row;
                if (row != null && row != "") {
                    toolbar2.enableItem("btnInsert2");
                    toolbar2.enableItem("btnDelete2");
                }
                else {
                    toolbar2.disableItem("btnInsert2");
                    toolbar2.disableItem("btnDelete2");
                }
                break;
        }
    };
    function OnResize(event) {
        var top = dgrid1.GetTop();
        var newHeight = document.documentElement.clientHeight - top - 5;
        dgrid1.SetHeight(newHeight);
    };
    function  DisplayDialog (width, height, title, idWindow, idAttachObj, bModal, bResize) {
        var dlg = jsf_displayDialog(thiswins, 0, 0, width, height, title, idWindow, idAttachObj, bModal, bResize);
        dlg.attachEvent("onClose", function (win) { return CloseDialog(idWindow); });
        return dlg;
    };
    function CloseDialog (idWindow) {
        if (idWindow == 'winCalendarDlg')
           dgrid1.grid.selectRowById(dgrid1_selectedRow);
        return jsf_closeDialog(thiswins, idWindow);
    };
    function SendRequest(sXML) {
         sURL = "./Calendars.ashx";
         return jsf_sendRequest(sURL, sXML);
    };
    function toolbar2_event(event) {
        var dlgTitle = "";
        switch (event) {
           case "btnInsert2":
                if (toolbar2.isItemDisabled("btnInsert2") == true) {
                    alert("Select a row to enable the Insert button");
                    return false;
                }
           case "btnAdd2":
               var newrow;
                if (event == "btnInsert2") {
                    newrow = tgrid1.grid.AddRow(null, tgrid1_selectedRow, true);
                }
                else {
                    newrow = tgrid1.grid.AddRow(null, null, true);
                }
                var prevrow = newrow.previousSibling;
                var start = null;
                var finish = null;
                var id = 0;
                var const_day = 86400000;
                if (prevrow != null && tgrid1.grid.GetAttribute(prevrow, null, "Deleted") != 1) {
                    start = tgrid1.GetCellValue(prevrow, "PRD_START_DATE");
                    finish = tgrid1.GetCellValue(prevrow, "PRD_FINISH_DATE");
                    id = parseInt(tgrid1.GetCellValue(prevrow, "PRD_ID"));
                    if (start != null && finish != null) {
                        tgrid1.SetCellValue(newrow, "PRD_START_DATE", finish + const_day);
                        tgrid1.SetCellValue(newrow, "PRD_FINISH_DATE", finish + (finish - start) + const_day);
                    }
                    tgrid1.SetCellValue(newrow, "PRD_ID", (id+1));
                    tgrid1.SetCellValue(newrow, "PRD_NAME", "Period" + (id+1).toString());
                }
                else {
                    var nextrow = newrow.nextSibling;
                    if (nextrow != null && tgrid1.grid.GetAttribute(nextrow, null, "Deleted") != 1) {
                        start = tgrid1.GetCellValue(nextrow, "PRD_START_DATE");
                        finish = tgrid1.GetCellValue(nextrow, "PRD_FINISH_DATE");
                        id = parseInt(tgrid1.GetCellValue(nextrow, "PRD_ID"));
                        if (start != null && finish != null) {
                            tgrid1.SetCellValue(newrow, "PRD_FINISH_DATE", start - const_day);
                            tgrid1.SetCellValue(newrow, "PRD_START_DATE", start - (finish - start) - const_day);
                        }
                        tgrid1.SetCellValue(newrow, "PRD_ID", (id-1));
                        tgrid1.SetCellValue(newrow, "PRD_NAME", "Period" + (id-1).toString());
                    }
                    else {
                        tgrid1.SetCellValue(newrow, "PRD_ID", 1);
                        tgrid1.SetCellValue(newrow, "PRD_NAME", "Period1");
                        var today = new Date().getTime();
                        today = parseInt(today / const_day) * const_day;
                        tgrid1.SetCellValue(newrow, "PRD_START_DATE", today);
                        tgrid1.SetCellValue(newrow, "PRD_FINISH_DATE", today + const_day);
                    }
                }
                tgrid1_selectedRow = newrow;
                tgrid1.Focus(newrow, 'PRD_NAME');
                break;
          case "btnDelete2":
                if (toolbar2.isItemDisabled("btnDelete2") == true) {
                    alert("Select a row to enable the Delete button");
                    return false;
                }
                tgrid1.grid.DeleteRow(tgrid1_selectedRow, 2); // 1=okmsg+del; 2=del; 3=undel
                GridsOnClickCell(tgrid1.grid, null, null)
                break;
        }
        return false;
    };
    function toolbar_event(event) {
        var sRowId = "";
        document.getElementById('idCalendarDlgMode').value = event;
        var dlgTitle = "";
       switch (event) {
           case "btnModify":
                if (toolbar.isItemDisabled("btnModify") == true) {
                    alert("Select a row to enable the Modify button");
                    return false;
                }
                dlgTitle = "Modify Calendar";
                sRowId = dgrid1_selectedRow;
                GetCalendarInfo(event, dlgTitle, sRowId);
                break;
          case "btnAdd":
                sRowId = "-1";
                dlgTitle = "Add Calendar";
                GetCalendarInfo(event, dlgTitle, sRowId);
                break;
          case "btnDelete":
                if (toolbar.isItemDisabled("btnDelete") == true) {
                    alert("Select a row to enable the Delete button");
                    return false;
                }
                sRowId = dgrid1_selectedRow;
                GetCalendarInfo(event, "Delete Calendar, are you sure?", sRowId);
                break;
        }
        return false;
    };
    function GetCalendarInfo(sMode, sDlgTitle, sRowId) {
        var sRequest = '<request function="CalendarRequest" context="ReadCalendarInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
        var jsonString = SendRequest(sRequest);
        var json = JSON_ConvertString(jsonString);
        if (json.reply != null) {
            if (jsf_alertError(json.reply.error) == true)
                return false;
        }
        document.getElementById('txtId').value = json.reply.calendar.calendarid;
        document.getElementById('txtName').value = json.reply.calendar.name;
        toolbar2.Render();
        tgrid1.Initialize(json.reply.calendar.tgridData);
        tgrid1.SetWidth(400);
        tgrid1.SetHeight(350);
        if (sMode == "btnDelete") {
             document.getElementById('idOKButton').value = "Delete";
         }
        else {
            document.getElementById('idOKButton').value = "Save";
        }
        dgrid1.grid.clearSelection();
        DisplayDialog(570, 550, sDlgTitle, "winCalendarDlg", "idCalendarDlg", true, false);
    };
    function calendarDlg_event(event) {
        switch (event) {
            case "ok":
                var action = document.getElementById('idCalendarDlgMode').value;
                switch (action) {
                    case "btnAdd":
                    case "btnModify":
                        var sb = new StringBuilder();
                        tgrid1.grid.EndEdit(true);
                        sb.append('<request function="CalendarRequest" context="UpdateCalendarInfo">');
                        sb.append('<data');
                        sb.append(' calendarid="' + document.getElementById('txtId').value + '"');
                        sb.append(' name="' + jsf_xml(document.getElementById('txtName').value) + '"');
                        sb.append('>');
                        sb.append('<![CDATA[' + tgrid1.GetXmlData() + ']]>');
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
                            sRowId = json.reply.calendar.calendarid;
                            dgrid1.addRow(sRowId);
                        }
                        dgrid1.SetCellValue(sRowId, "CB_ID", json.reply.calendar.calendarid);
                        dgrid1.SetCellValue(sRowId, "CB_NAME", json.reply.calendar.name);
                        break;
                    case "btnDelete":
                        var sb = new StringBuilder();
                        sb.append('<request function="CalendarRequest" context="DeleteCalendarInfo">');
                        sb.append('<data');
                        sb.append(' calendarid="' + document.getElementById('txtId').value + '"');
                        sb.append(' name="' + jsf_xml(document.getElementById('txtName').value) + '"');
                        sb.append('>');
                        sb.append('<![CDATA[' + tgrid1.GetXmlData() + ']]>');
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
                        dgrid1_OnRowSelect(null);
                      break;
                }
                GridsOnClickCell(tgrid1.grid, null, null)
                CloseDialog('winCalendarDlg');
                break;
            case "cancel":
                GridsOnClickCell(tgrid1.grid, null, null)
                CloseDialog('winCalendarDlg');
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

<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Calendars
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Calendars
</asp:Content>
