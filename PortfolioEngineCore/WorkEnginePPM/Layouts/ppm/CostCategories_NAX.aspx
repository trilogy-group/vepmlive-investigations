<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register src="Tools/TGrid.ascx" tagname="TGridUserControl" tagprefix="tg1" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostCategories_NAX.aspx.cs" Inherits="WorkEnginePPM.CostCategories_NAX" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Reference Control="/_layouts/ppm/tools/TGrid.ascx" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
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

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<div class="modalContent" id="idRatesDlg" style="display:none;">
    <div id="idToolbarRatesDiv"></div>
    <div style="display:block;"><tg1:TGridUserControl id="tgridRates" runat="server" /></div>
	<div style="float:right;">
		<div class="button-container" >
			<input id="Button1" type="button" class="epmliveButton" value="OK" onclick="ratesDlg_event('ok');"/>
			<input type="button" class="epmliveButton" value="Cancel" onclick="ratesDlg_event('cancel');"/>
		</div>
	</div>
</div>
<div class="modalContent" id="idFTEsDlg" style="display:none;">
	<div style="padding-bottom:3px;">
        <table width="100%" cellspacing="0">
            <tr id="trCalendar">
                <td>Calendar : </td>
                <td class="controlcell">
                    <select id="idCalendar"  onchange="FTEsDlg_event('calendarOnChange');"></select>
                </td>
            </tr>
        </table>
	</div>
    <div id="idToolbarFTEsDiv"></div>
    <div style="display:block;"><tg1:TGridUserControl id="tgridFTEs" runat="server" /></div>
	<div style="float:right;">
		<div class="button-container" >
			<input type="button" class="epmliveButton" value="Close" onclick="FTEsDlg_event('cancel');"/>
		</div>
	</div>
</div>
<div class="modalContent" id="idRolesDlg" style="display:none;">
    <input id="idRolesDlgMode" type="hidden" value="" />
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
                        Available Roles</td>
                    <td class="controlcell">
                        <select id="idAvailableRoles" size="10" style="width:206px;" multiple="multiple"></select>
                    </td>
                </tr>
            </table>
		</div>
		<div style="float:right;">
			<div class="button-container" >
			    <input id="idOKButton" type="button" class="epmliveButton" value="OK" onclick="roleDlg_event('ok');"/>
			    <input type="button" class="epmliveButton" value="Cancel" onclick="roleDlg_event('cancel');"/>
			</div>
		</div>
	</div>
</div>
<div style="display:none;">
    <asp:ListBox ID="ddlResourceRoles" runat="server"></asp:ListBox>
</div>
<div style="display: block;" >
    <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
    <div id="idToolbarDiv"></div>
	<div style="margin-top:5px;margin-bottom:5px;padding-left:3px;padding-right:3px;">
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
                        <input type="text" id="Text1" />
                    </td>
                </tr>
                <tr>
                    <td width="250" class="descriptioncell">Major Category</td>
                    <td class="controlcell">
                        <asp:DropDownList ID="ddlMajorCategoryLookups" OnChange="ddlChanged('ddlMajorCategoryLookups');" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="250" class="descriptioncell">Default Major Category Item</td>
                    <td class="controlcell">
                        <select id="idMajorCategoryItem" style="width:206px;" onchange="ddlChanged('idMajorCategoryItem');">
                        </select>
                   </td>
                </tr>
            </table>
		</div>
    </div>
    <div style="display:block;"><tg1:TGridUserControl id="tgrid1" runat="server" /></div>
</div>
<script type="text/javascript">
    var toobarData = {
        parent: "idToolbarDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", id: "btnSave", name: "SAVE", img: "formatmap16x16_2.png", style: "top: -127px; left: -91px;", tooltip: "Save",  onclick: "toolbar_event('btnSave');" },
            { type: "button", id: "btnAdd", name: "ADD", img: "formatmap16x16_2.png", style: "top: -90px; left: -216px;", tooltip: "Add", onclick: "toolbar_event('btnAdd');" },
            { type: "button", id: "btnAddRole", name: "ADD ROLE", img: "addresource.gif", tooltip: "Add role", width: "80px", onclick: "toolbar_event('btnAddRole');" },
            { type: "button", id: "btnDelete", name: "DELETE", img: "formatmap16x16_2.png", style: "top: -270px; left: -270px;", tooltip: "Delete",  onclick: "return toolbar_event('btnDelete');", disabled: true },
            { type: "button", id: "btnFTEs", name: "FTEs", img: "delete.png", tooltip: "FTEs", width: "80px", onclick: "return toolbar_event('btnFTEs');", disabled: false },
            { type: "button", id: "btnRates", name: "RATES", img: "delete.png", tooltip: "Rates", width: "80px", onclick: "return toolbar_event('btnRates');", disabled: true }
        ]
    };
    var toolbarRatesData = {
        parent: "idToolbarRatesDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", name: "Add", img: "addresource.gif", tooltip: "Add", width: "80px", onclick: "ratesDlg_event('btnAdd2');" },
            { type: "button", id: "btnInsert2", name: "Insert", img: "editview.gif", tooltip: "Modify", width: "80px", onclick: "return ratesDlg_event('btnInsert2');", disabled: true },
            { type: "button", id: "btnDelete2", name: "Delete", img: "delete.png", tooltip: "Delete", width: "80px", onclick: "return ratesDlg_event('btnDelete2');", disabled: true }
        ]
    };
    var toolbarFTEsData = {
        parent: "idToolbarFTEsDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
             { type: "button", id: "btnSaveFTEs", name: "SAVE", img: "formatmap16x16_2.png", style: "top: -127px; left: -91px;", tooltip: "Save",  onclick: "FTEsDlg_event('btnSaveFTEs');", disabled: true  }
       ]
    };

    var toolbar = new Toolbar(toobarData);
    toolbar.Render();
    var toolbarRates = new Toolbar(toolbarRatesData);
    var toolbarFTEs = new Toolbar(toolbarFTEsData);
    var tgrid1_selectedRow = 0;
    var tgridRates_selectedRow = 0;
    var tgridFTEs_selectedRow = 0;
    var tgrid1 = window.<%=tgrid1.UID%>;
 
    var OnLoad = function (event) {
        var tgrid1 = window.<%=tgrid1.UID%>;
        tgrid1_selectedRow = 0;
        tgrid1.addEventListener("OnFocus", tgrid1_OnFocus);
        OnResize();
    };
    function tgrid1_OnFocus(grid, row, col, orow, ocol, pagepos) {
        tgrid1_selectedRow = row;
        toolbar.enableItem("btnModify");
        toolbar.enableItem("btnDelete");
        toolbar.enableItem("btnRates");
    };
    function tgridRates_OnFocus(grid, row, col, orow, ocol, pagepos) {
        tgridRates_selectedRow = row;
        toolbarRates.enableItem("btnInsert2");
        toolbarRates.enableItem("btnDelete2");
    };
    function tgridFTEs_OnFocus(grid, row, col, orow, ocol, pagepos) {
        tgridFTEs_selectedRow = row;
        toolbarFTEs.enableItem("btnInsert2");
        toolbarFTEs.enableItem("btnDelete2");
    };
    function tgridFTEs_OnAfterValueChanged(grid, row, col, va) {
        var hasChanges = grid.HasChanges();
        if ((hasChanges & (1 << 0)) != 0)
            toolbarFTEs.enableItem("btnSaveFTEs");
        else
            toolbarFTEs.disableItem("btnSaveFTEs");
    };

    var OnResize = function (event) {
        var tgrid1 = window.<%=tgrid1.UID%>;
        var top = tgrid1.GetTop();
        var newHeight = document.documentElement.clientHeight - top - 5;
        tgrid1.SetHeight(newHeight);
    };
    function ddlChanged(ddlName) {
        switch (ddlName) {
            case "ddlMajorCategoryLookups":
                var idMC = document.getElementById('<%=ddlMajorCategoryLookups.ClientID%>');
                var sId = idMC.options[idMC.selectedIndex].value;
                if (sId != null && sId != "0") {

                    var sRequest = '<request function="CostCategoriesRequest" context="ReadMajorCategoryItems"><data><![CDATA[' + sId + ']]></data></request>';
                    var jsonString = SendRequest(sRequest);
                    var json = JSON_ConvertString(jsonString);
                    if (json.reply != null) {
                        if (jsf_alertError(json.reply.error) == true)
                            return false;
                        var idMajorCategoryItem = document.getElementById('idMajorCategoryItem');
                        idMajorCategoryItem.options.length = 0;
                        var item = json.reply.MajorCategoryItems.Item;
                        for (var i=0; i<item.length; i++) {
                            idMajorCategoryItem.options[idMajorCategoryItem.options.length] = new Option(item[i].name, item[i].id);
                        }
                    }
                }
                break;
        }
    };
    function  DisplayDialog (width, height, title, idWindow, idAttachObj, bModal, bResize) {
        var dlg = jsf_displayDialog(thiswins, 0, 0, width, height, title, idWindow, idAttachObj, bModal, bResize);
        dlg.attachEvent("onClose", function (win) { jsf_closeDialog2(win); return true; });
        return dlg;
    };
    function CloseDialog (idWindow) {
        jsf_closeDialog(thiswins, idWindow)
    };
    function SendRequest(sXML) {
         sURL = "./CostCategories.ashx";
         return jsf_sendRequest(sURL, sXML);
    };
    function BuildSaveCostCategoryInfo() {
        var idMC = document.getElementById('<%=ddlMajorCategoryLookups.ClientID%>');
        var sMCValue = "";
        if (idMC.selectedIndex > -1)
            sMCValue = idMC.options[idMC.selectedIndex].value;
        var idMCItem = document.getElementById('idMajorCategoryItem');
        var sMCItemValue = "";
        if (idMCItem.selectedIndex > -1)
            sMCItemValue = idMCItem.options[idMCItem.selectedIndex].value;
        var sb = new StringBuilder("");
        sb.append('<data');
        sb.append(' majorcategoryid="' + sMCValue + '"');
        sb.append(' majorcategorydefault="' + sMCItemValue + '"');
        sb.append('>');
        var tgrid1 = window.<%=tgrid1.UID%>;
        //if ((tgrid1.grid.HasChanges() & (1 << 0)) != 0) {
            sb.append('<![CDATA[' + tgrid1.GetXmlData() + ']]>');
        //}
        sb.append('</data>');
        return sb.toString();
    };
    function getParentRow(grid, row) {
        var roleid = grid.GetAttribute(row, "CA_ROLE", null);
        var parentrow = null;
        if (roleid == 0) {
            parentrow = row
        }
        else {
            while (row != null) {
                if (grid.GetAttribute(row, "CA_ROLE", null) == 0)  {
                    parentrow = row;
                    break;
                }
                row = grid.GetPrev(row);
            }
        }
        return parentrow;
    }
    function toolbar_event(event) {
        var tgrid1 = window.<%=tgrid1.UID%>;
        var sRowId = "";
        if (toolbar.isItemDisabled(event) == true)
            return;
        switch (event) {
            case "btnAdd":
                var row = tgrid1.AddRow();
                tgrid1.SetCellValue(row, "CA_NAME", "New Row");
                break;
            case "btnAddRole":
                var grid = tgrid1.grid;
                var parentrow = getParentRow(grid, tgrid1_selectedRow);
                if (parentrow != null) {
                    var masterRoles = document.getElementById('<%=ddlResourceRoles.ClientID%>');
                    var availableRolesSelect = document.getElementById('idAvailableRoles');
                    availableRolesSelect.options.length = 0;

                    for (var i=0; i<masterRoles.options.length; i++) {
                        var bAdd = true;
                        var row = parentrow.firstChild;
                        var vValue = masterRoles.options[i].value;
                        while (row != null) {
                            if (vValue == grid.GetAttribute(row, "CA_ROLE", null)) {
                                bAdd = false; 
                                break; 
                            }
                            row = grid.GetNextSibling(row);
                        }
                        if (bAdd)
                            availableRolesSelect.options[availableRolesSelect.options.length] = new Option(masterRoles.options[i].text, masterRoles.options[i].value);
                    }
                    if (availableRolesSelect.options.length > 0) {
                        DisplayDialog(400, 280, "Add roles to " + grid.GetAttribute(parentrow, "CA_NAME", null), "winRolesDlg", "idRolesDlg", true, false);
                    }
                    else
                        alert("all available roles have already been added to this cost type");
                }
                break;
            case "btnSave":
                var sData = BuildSaveCostCategoryInfo();
                var sb = new StringBuilder();
                sb.append('<request function="CostCategoriesRequest" context="SaveCostCategoryInfo">');
                sb.append(sData);
                sb.append('</request>'); 
                var sRequest = sb.toString();
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                    __doPostBack('', '');
                }
                break;
            case "btnDelete":
                var ccids = tgrid1.grid.GetAttribute(tgrid1_selectedRow, "CA_UID", null).toString();
                var ccrole = tgrid1.grid.GetAttribute(tgrid1_selectedRow, "CA_ROLE", null);
                var firstrow = tgrid1_selectedRow;
                var lastrow = tgrid1_selectedRow;
                var childrow = tgrid1_selectedRow.firstChild;
                if (childrow != null) {
                    var row = tgrid1.grid.GetNext(tgrid1_selectedRow);
                    while (row != null && tgrid1.grid.GetAttribute(row, "CA_ROLE", null) != 0) {
                        ccids += "," + tgrid1.grid.GetAttribute(row, "CA_UID", null).toString();
                        lastrow = row;
                        row = tgrid1.grid.GetNext(row);
                    }
                }
                var sb = new StringBuilder();
                sb.append('<request function="CostCategoriesRequest" context="DeleteCostCategoryInfo">');
                sb.append('<data');
                sb.append(' CA_UIDs="' + ccids + '"');
                sb.append('/>');
                sb.append('</request>'); 
                var sRequest = sb.toString();
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }

                var sb = new StringBuilder("");
                if (childrow != null) {
                    sb.appendLine("WARNING!");
                    sb.appendLine("");
                    sb.appendLine("All child rows of the selected cost category will also be deleted");
                    sb.appendLine("");
                }
                sb.appendLine("Press 'OK' to continue. The rows will be deleted on Save");
                var s = sb.toString();
                var r = confirm (s);
                if (r == true) {
                    var row = lastrow;
                    while (row != null) {
                        tgrid1.grid.DeleteRow(row, 2); // 1=okmsg+del; 2=del; 3=undel
                        if (firstrow.id == row.id)
                            break;
                        row = tgrid1.grid.GetPrev(row);
                    }
                }
                break;
            case "btnRates":
                if (tgrid1_selectedRow != null) {
                    var grid = tgrid1.grid;
                    var sRowId = grid.GetAttribute(tgrid1_selectedRow, "CA_UID", null).toString();
                    var sRequest = '<request function="CostCategoriesRequest" context="ReadCostCategoryRatesInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                    var jsonString = SendRequest(sRequest);
                    var json = JSON_ConvertString(jsonString);
                    if (json.reply != null) {
                        if (jsf_alertError(json.reply.error) == true)
                            return false;
                    }
                    var tgridRates = window['<%=tgridRates.UID%>'];
                    tgridRates.Initialize(json.reply.costcategory.tgridRates);
                    tgridRates.SetWidth(380);
                    tgridRates.SetHeight(150);
                    //var newrow = tgridRates.grid.AddRow(null, null, true);
                    toolbarRates.Render();
                    tgridRates.addEventListener("OnFocus", tgridRates_OnFocus);
                    var s = "Add rates for " + grid.GetAttribute(tgrid1_selectedRow, "CA_NAME", null);
                    tgridRates_selectedRow = 0;
                    DisplayDialog(400, 300, s, "winRatesDlg", "idRatesDlg", true, false);
                }
                break;
            case "btnFTEs":
                var hasChanges = tgrid1.grid.HasChanges();
                if ((hasChanges & (1 << 0)) != 0) {
                     window.alert("You have unsaved changes to cost categories.\n\nYou must save or abandon these changes before editing FTEs");
                     return;
                }
                var sRequest = '<request function="CostCategoriesRequest" context="ReadCalendarFTEsInfo"><data><![CDATA[' + -1 + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                var nCalendar = json.reply.FTEs.CB_ID;
                var idCalendar = document.getElementById('idCalendar');
                idCalendar.options.length = 0;
                var item = json.reply.FTEs.calendars.item;
                for (var i = 0; i < item.length; i++) {
                    idCalendar.options[idCalendar.options.length] = new Option(item[i].name, item[i].id);
                    if (item[i].id == nCalendar)
                        idCalendar.selectedIndex = idCalendar.options.length - 1;
                }
                var tgridFTEs = window['<%=tgridFTEs.UID%>'];
                tgridFTEs.Initialize(json.reply.FTEs.tgridFTEs);
                tgridFTEs.SetWidth(570);
                tgridFTEs.SetHeight(250);
                toolbarFTEs.Render();
                tgridFTEs.addEventListener("OnFocus", tgridFTEs_OnFocus);
                tgridFTEs.addEventListener("OnAfterValueChanged", tgridFTEs_OnAfterValueChanged);

                var s = "Cost Category FTE Values";
                tgridFTEs_selectedRow = 0;
                DisplayDialog(600, 430, s, "winFTEsDlg", "idFTEsDlg", true, false);

                break;
        }
        return false;
    };
    function ratesDlg_event(event) {
        var tgridRates = window['<%=tgridRates.UID%>'];
        switch (event) {
            case "ok":
                //alert("btnModify.OK");
                var sb = new StringBuilder();
                var tgridRates = window['<%=tgridRates.UID%>'];
                tgridRates.grid.EndEdit(true);
                var sRowId = tgrid1.grid.GetAttribute(tgrid1_selectedRow, "CA_UID", null).toString();
                sb.append('<request function="CostCategoriesRequest" context="SaveCostCategoryRatesInfo">');
                sb.append('<data');
                sb.append(' CA_UID="' + sRowId + '"');
                sb.append('>');
                sb.append('<![CDATA[' + tgridRates.GetXmlData() + ']]>');
                sb.append('</data>');
                sb.append('</request>'); 
                var sRequest = sb.toString();
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                CloseDialog('winRatesDlg');
                break;
            case "cancel":
                CloseDialog('winRatesDlg');
                break;
           case "btnInsert2":
           case "btnAdd2":
                var newrow;
                if (event == "btnInsert2") {
                    newrow = tgridRates.grid.AddRow(null, tgridRates_selectedRow, true);
                }
                else {
                    newrow = tgridRates.grid.AddRow(null, null, true);
                }
                tgridRates_selectedRow = newrow;
                tgridRates.Focus(newrow, 'BC_RATE');
                break;
          case "btnDelete2":
               tgridRates.grid.DeleteRow(tgridRates_selectedRow, 2); // 1=okmsg+del; 2=del; 3=undel
               break;
        }
        return false;
    };
    function FTEsDlg_event(event) {
        var tgridFTEs = window['<%=tgridFTEs.UID%>'];
        tgridFTEs.grid.EndEdit(true);
        var hasChanges = tgridFTEs.grid.HasChanges();
        switch (event) {
            case "btnSaveFTEs":
                if ((hasChanges & (1 << 0)) == 0) {
                    alert("There are no changes to save");
                    return;
                }
                var sb = new StringBuilder();
                var calendarId=document.getElementById('idCalendar').value;
                sb.append('<request function="CostCategoriesRequest" context="SaveCalendarFTEsInfo">');
                sb.append('<data');
                sb.append(' CB_ID="' + calendarId + '"');
                sb.append('>');
                sb.append('<![CDATA[' + tgridFTEs.GetXmlData() + ']]>');
                sb.append('</data>');
                sb.append('</request>'); 
                var sRequest = sb.toString();
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                break;
            case "ok":
                CloseDialog('winFTEsDlg');
                break;
            case "cancel":
                CloseDialog('winFTEsDlg');
                break;
            case "calendarOnChange":
                if ((hasChanges & (1 << 0)) != 0) {
                    var b = true;
                    b = window.confirm("You have unsaved changes.\n\nAre you sure you want to continue without saving?");

                }
                var calendarId=document.getElementById('idCalendar').value;
                var sRequest = '<request function="CostCategoriesRequest" context="ReadCalendarFTEsInfo"><data><![CDATA[' + calendarId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                tgridFTEs.Initialize(json.reply.FTEs.tgridFTEs);
                tgridFTEs.SetWidth(570);
                tgridFTEs.SetHeight(250);
                tgridFTEs.addEventListener("OnFocus", tgridFTEs_OnFocus);
                tgridFTEs.addEventListener("OnAfterValueChanged", tgridFTEs_OnAfterValueChanged);
                break;
        }
        return false;
    };
    var roleDlg_event = function (event) {
        var tgrid1 = window.<%=tgrid1.UID%>;
        switch (event) {
            case "ok":
                var grid = tgrid1.grid;
                var parentrow = getParentRow(grid, tgrid1_selectedRow);
                if (parentrow != null) {
                    var uid = grid.GetAttribute(parentrow, "CA_UID", null);
                    var options = document.getElementById('idAvailableRoles').options;
                    for (var i=0, iLen=options.length; i<iLen; i++) {
                        var opt = options[i];
                        if (opt.selected) {
                            var newrow = grid.AddRow(parentrow, null, true);
                            if (newrow != null) {
                                grid.SetAttribute(newrow, "CA_NAME", null, opt.text, true);
                                grid.SetAttribute(newrow, null, "CA_ROLE", opt.value, true);
                                //grid.SetAttribute(newrow, null, "CA_UID", uid, true);
                            }
                        }
                    }
                    CloseDialog('winRolesDlg');
                }
                break;
            case "cancel":
                CloseDialog('winRolesDlg');
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
Cost Categories
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Cost Categories
</asp:Content>
