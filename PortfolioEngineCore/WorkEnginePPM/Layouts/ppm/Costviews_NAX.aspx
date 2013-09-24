<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register src="Tools/DGrid.ascx" tagname="DGridUserControl" tagprefix="dg1" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Costviews_NAX.aspx.cs" Inherits="WorkEnginePPM.Costviews_NAX" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Reference Control="/_layouts/ppm/tools/DGrid.ascx" %>

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
<div class="modalContent" id="idCostviewDlg" style="display:none;">
    <input id="idCostviewDlgMode" type="hidden" value="" />
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
                <label for="txtName">Field Name</label>
            </td>
            <td class="controlcell">
                <input type="text" id="txtName" style="width:350px;" />
            </td>
        </tr>
        <tr>
            <td class="descriptioncell">
                Field Description
            </td>
            <td class="controlcell">
                    <input type="text" id="txtDesc" style="Width:350px;"/>
            </td>
        </tr>
        <tr id="trCalendar">
            <td class="descriptioncell">
                Choose a Fiscal Calendar</td>
            <td class="controlcell">
                <select id="idCalendar" onchange="javascript:CostviewDlg_event('calendarchanged');" >
                </select>
            </td>
        </tr>
        <tr id="trFromPeriod">
            <td class="descriptioncell">
                From Period (optional)</td>
            <td class="controlcell">
                <select id="idFromPeriod" >
                </select>
            </td>
        </tr>
        <tr id="trToPeriod">
            <td class="descriptioncell">
                To Period (optional)</td>
            <td class="controlcell">
                <select id="idToPeriod" >
                </select>
            </td>
        </tr>
    </table>
    <div style="width:516px; display:block; padding-top: 0px; padding-bottom: 10px;">
        <table cellpadding="5">
            <tr>
                <td colspan="3" class="descriptioncell">
                    Select the cost types to be displayed in this view:</td>
            </tr>
            <tr>
                <td class="descriptioncell">
                    Available Cost Types:<br />
					<select name="FrmFieldsOut" size="7" id="idCostTypesOut" style="width: 200px; padding: 3px;" ondblclick="javascript:CostviewDlg_event('include');" >
					</select>
                </td>
                <td>
                    <input type="button" value=" &gt; " onclick="javascript:CostviewDlg_event('include');" /><br /><br />
                    <input type="button" value=" &lt; " onclick="javascript:CostviewDlg_event('exclude');"/>
                </td>
                <td class="descriptioncell">
                    Selected Cost Types:<br />
					<select name="FrmFieldsIn" size="7" id="idCostTypesIn" style="width: 200px; padding: 3px;" ondblclick="javascript:CostviewDlg_event('exclude');" >
					</select>
                </td>
                <td>
                    <input type="button" value="up" onclick="javascript:CostviewDlg_event('moveup');" /><br /><br />
                    <input type="button" value="dn" onclick="javascript:CostviewDlg_event('movedown');"/>
                </td>
            </tr>
        </table>
    </div>
    <div id="idDeleteWarning" style="width:300px; color:red; display:none;"><a>Are you sure, all data will be cleared?</a></div>
	<div class="button-container" >
		<input id="idOKButton" type="button" class="epmliveButton" value="OK" onclick="CostviewDlg_event('ok');"/>
		<input type="button" class="epmliveButton" value="Cancel" onclick="CostviewDlg_event('cancel');"/>
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
    var toolbar = new Toolbar(toobarData);
    var dgrid1 = window.<%=dgrid1.UID%>;
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
        }
        else {
            toolbar.disableItem("btnModify");
            toolbar.disableItem("btnDelete");
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
        return jsf_closeDialog(thiswins, idWindow);
    };
    function SendRequest(sXML) {
         sURL = "./Costviews.ashx";
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
        document.getElementById('idCostviewDlgMode').value = event;
        var bModify = false;
        var dlgTitle = "Add Cost View";
        switch (event) {
            case "btnModify":
                if (toolbar.isItemDisabled("btnModify") == true) {
                    alert("Select a row to enable the Modify button");
                    return false;
                }
                dlgTitle = "Modify Cost View";
                bModify = true;
            case "btnAdd":
                sRowId = "0";
                if (event == "btnModify")
                    sRowId = dgrid1_selectedRow;
                var sRequest = '<request function="CostviewsRequest" context="ReadCostviewInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                var fieldId = json.reply.Costview.VIEW_UID;
                document.getElementById('txtId').value = fieldId;
                document.getElementById('txtName').value = GetStringFromValue(json.reply.Costview.VIEW_NAME);
                document.getElementById('txtDesc').value = GetStringFromValue(json.reply.Costview.VIEW_DESC);

                var nCalendar = json.reply.Costview.VIEW_COST_BREAKDOWN;
                var idCalendar = document.getElementById('idCalendar');
                idCalendar.options.length = 0;
                var item = json.reply.Costview.calendars.item;
                for (var i = 0; i < item.length; i++) {
                    idCalendar.options[idCalendar.options.length] = new Option(item[i].name, item[i].id);
                    if (item[i].id == nCalendar)
                        idCalendar.selectedIndex = idCalendar.options.length - 1;
                }
                var nFromPeriod = json.reply.Costview.VIEW_FIRST_PERIOD;
                var idFromPeriod = document.getElementById('idFromPeriod');
                idFromPeriod.options.length = 0;
                var item = json.reply.Costview.periods.item;
                for (var i = 0; i < item.length; i++) {
                    idFromPeriod.options[idFromPeriod.options.length] = new Option(item[i].name, item[i].id);
                    if (item[i].id == nFromPeriod)
                        idFromPeriod.selectedIndex = idFromPeriod.options.length - 1;
                }
                var nToPeriod = json.reply.Costview.VIEW_LAST_PERIOD;
                var idToPeriod = document.getElementById('idToPeriod');
                idToPeriod.options.length = 0;
                var item = json.reply.Costview.periods.item;
                for (var i = 0; i < item.length; i++) {
                    idToPeriod.options[idToPeriod.options.length] = new Option(item[i].name, item[i].id);
                    if (item[i].id == nToPeriod)
                        idToPeriod.selectedIndex = idToPeriod.options.length - 1;
                }
                var idCostTypesOut = document.getElementById('idCostTypesOut');
                idCostTypesOut.options.length = 0;
                var idCostTypesIn = document.getElementById('idCostTypesIn');
                idCostTypesIn.options.length = 0;
                var item = json.reply.Costview.costtypes.item;
                for (var i = 0; i < item.length; i++) {
                    if (item[i].used == 0)
                        idCostTypesOut.options[idCostTypesOut.options.length] = new Option(item[i].name, item[i].id);
                    else
                        idCostTypesIn.options[idCostTypesIn.options.length] = new Option(item[i].name, item[i].id);
                }

                DisplayDialog(645, 550, dlgTitle, "winCostviewDlg", "idCostviewDlg", true, false);
                break;
            case "btnDelete":
                if (toolbar.isItemDisabled("btnDelete") == true) {
                    alert("Select a row to enable the Delete button");
                    return false;
                }
                sRowId = dgrid1_selectedRow;
                var sRequest = '<request function="CostviewsRequest" context="ReadCostviewInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                var fieldId = json.reply.Costview.VIEW_UID;
                document.getElementById('txtId').value = fieldId;
                document.getElementById('txtName').value = GetStringFromValue(json.reply.Costview.VIEW_NAME);
                document.getElementById('txtDesc').value = GetStringFromValue(json.reply.Costview.VIEW_DESC);
                document.getElementById('txtName').disabled = true;
                document.getElementById('txtDesc').disabled = true;

                var nCalendar = json.reply.Costview.VIEW_COST_BREAKDOWN;
                var idCalendar = document.getElementById('idCalendar');
                idCalendar.options.length = 0;
                var item = json.reply.Costview.calendars.item;
                for (var i = 0; i < item.length; i++) {
                    idCalendar.options[idCalendar.options.length] = new Option(item[i].name, item[i].id);
                    if (item[i].id == nCalendar)
                        idCalendar.selectedIndex = idCalendar.options.length - 1;
                }
                document.getElementById('idCalendar').disabled = true;
                var nFromPeriod = json.reply.Costview.VIEW_FIRST_PERIOD;
                var idFromPeriod = document.getElementById('idFromPeriod');
                idFromPeriod.options.length = 0;
                var item = json.reply.Costview.periods.item;
                for (var i = 0; i < item.length; i++) {
                    idFromPeriod.options[idFromPeriod.options.length] = new Option(item[i].name, item[i].id);
                    if (item[i].id == nFromPeriod)
                        idFromPeriod.selectedIndex = idFromPeriod.options.length - 1;
                }
                document.getElementById('idFromPeriod').disabled = true;
                var nToPeriod = json.reply.Costview.VIEW_LAST_PERIOD;
                var idToPeriod = document.getElementById('idToPeriod');
                idToPeriod.options.length = 0;
                var item = json.reply.Costview.periods.item;
                for (var i = 0; i < item.length; i++) {
                    idToPeriod.options[idToPeriod.options.length] = new Option(item[i].name, item[i].id);
                    if (item[i].id == nToPeriod)
                        idToPeriod.selectedIndex = idToPeriod.options.length - 1;
                }
                document.getElementById('idToPeriod').disabled = true;
                var idCostTypesOut = document.getElementById('idCostTypesOut');
                idCostTypesOut.options.length = 0;
                document.getElementById('idCostTypesOut').disabled = true;
                var idCostTypesIn = document.getElementById('idCostTypesIn');
                idCostTypesIn.options.length = 0;
                document.getElementById('idCostTypesIn').disabled = true;
                var item = json.reply.Costview.costtypes.item;
                for (var i = 0; i < item.length; i++) {
                    if (item[i].used == 0)
                        idCostTypesOut.options[idCostTypesOut.options.length] = new Option(item[i].name, item[i].id);
                    else
                        idCostTypesIn.options[idCostTypesIn.options.length] = new Option(item[i].name, item[i].id);
                }
                
                
                document.getElementById('idDeleteWarning').style.display = "block";
                document.getElementById('idOKButton').value = "Delete";

                DisplayDialog(445, 360, "Delete Cost View - " + json.reply.Costview.VIEW_NAME, "winCostviewDlg", "idCostviewDlg", true, false);
                break;
        }
        return false;
    };
 var CostviewDlg_event = function (event) {
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
                var sRequest = '<request function="CostviewsRequest" context="ReadCalendarInfo"><data><![CDATA[' + calendarId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                var idFromPeriod = document.getElementById('idFromPeriod');
                idFromPeriod.options.length = 0;
                var item = json.reply.Costview.periods.item;
                for (var i = 0; i < item.length; i++) {
                    idFromPeriod.options[idFromPeriod.options.length] = new Option(item[i].name, item[i].id);
                }
                var idToPeriod = document.getElementById('idToPeriod');
                idToPeriod.options.length = 0;
                var item = json.reply.Costview.periods.item;
                for (var i = 0; i < item.length; i++) {
                    idToPeriod.options[idToPeriod.options.length] = new Option(item[i].name, item[i].id);
                }
                break;
            case "ok":
                var action = document.getElementById('idCostviewDlgMode').value;
                switch (action) {
                    case "btnAdd":
                    case "btnModify":
                        //alert("btnModify.OK");
                        var sRowId = dgrid1_selectedRow;
                        var sb = new StringBuilder();
                        sb.append('<request function="CostviewsRequest" context="UpdateCostviewInfo">');
                        sb.append('<data');
                        sb.append(' VIEW_UID="' + document.getElementById('txtId').value + '"');
                        sb.append(' VIEW_NAME="' + jsf_xml(document.getElementById('txtName').value) + '"');
                        sb.append(' VIEW_DESC="' + jsf_xml(document.getElementById('txtDesc').value) + '"');
                        var calendarId=document.getElementById('idCalendar').value;
                        sb.append(' VIEW_COST_BREAKDOWN="' + calendarId + '"');
                        var fromPeriod = document.getElementById('idFromPeriod').value;
                        sb.append(' VIEW_FIRST_PERIOD="' + fromPeriod + '"');
                        var toPeriod = document.getElementById('idToPeriod').value;
                        sb.append(' VIEW_LAST_PERIOD="' + toPeriod + '"');
                        var sCTs = "";
                        var idCostTypesIn = document.getElementById('idCostTypesIn');
                        for (var i = 0; i < idCostTypesIn.options.length; i++) {

                            if (i > 0)
                                sCTs += ",";
                            
                            sCTs += idCostTypesIn.options[i].value;
                        }
                        sb.append(' VIEW_CTS="' + jsf_xml(sCTs) + '"');
                        sb.append('/>');
                        sb.append('</request>'); 
                        var sRequest = sb.toString();
                        var jsonString = SendRequest(sRequest);
                        var json = JSON_ConvertString(jsonString);
                        if (json.reply != null) {
                            if (jsf_alertError(json.reply.error) == true)
                                return false;
                        }
                        if (action == "btnAdd") {
                            sRowId = json.reply.Costview.VIEW_UID;
                            dgrid1.addRow(sRowId);
                        }
                        dgrid1.SetCellValue(sRowId, "VIEW_UID", json.reply.Costview.VIEW_UID);
                        dgrid1.SetCellValue(sRowId, "VIEW_NAME", json.reply.Costview.VIEW_NAME);
                        dgrid1.SetCellValue(sRowId, "VIEW_DESC", json.reply.Costview.VIEW_DESC);
                        dgrid1.reapplySort();
                        dgrid1.selectRow(sRowId);
                        break;
                    case "btnDelete":
                        var sRowId = dgrid1_selectedRow;
                        var sb = new StringBuilder();
                        sb.append('<request function="CostviewsRequest" context="DeleteCostviewInfo">');
                        sb.append('<data');
                        sb.append(' VIEW_UID="' + document.getElementById('txtId').value + '"');
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
                CloseDialog('winCostviewDlg');
                break;
            case "cancel":
                CloseDialog('winCostviewDlg');
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
Cost Views
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Cost Views
</asp:Content>
