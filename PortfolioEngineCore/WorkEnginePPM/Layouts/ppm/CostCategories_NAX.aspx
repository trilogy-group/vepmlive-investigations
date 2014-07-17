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
	<div style="margin-top:10px;padding-right:10px;">
		<div style="padding-bottom:3px;">
            <table width="100%" cellspacing="0">
                <tr>
                    <td style="height:1px;" width="250" class="topcell"></td>
                    <td style="height:1px;" class="topcell"></td>
                </tr>
                <tr>
                    <td width="250" class="descriptioncell">
                        Base Rate
                    </td>
                    <td class="controlcell">
                        <input type="text" id="txtBaseRate" />
                    </td>
                </tr>
                <tr>
                    <td class="descriptioncell" colspan="2">
                        Optionally enter rates which will become effective on the specified dates:
                    </td>
                </tr>
            </table>
		</div>
    </div>
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
        <table cellspacing="0">
            <tr id="trCalendar">
                <td>Calendar&nbsp:&nbsp&nbsp</td>
                <td>
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
                        <asp:DropDownList ID="ddlMajorCategoryItems" OnChange="ddlChanged('ddlMajorCategoryItems');" runat="server"></asp:DropDownList>
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
            { type: "button", id: "btnFTEs", name: "FTEs", img: "formatmap16x16_2.png", style: "top: -217px; left: -289px;", tooltip: "FTEs", width: "80px", onclick: "return toolbar_event('btnFTEs');", disabled: false },
            { type: "button", id: "btnRates", name: "RATES", img: "rates.png", tooltip: "Rates", width: "80px", onclick: "return toolbar_event('btnRates');", disabled: true }
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
    var tgridFTEs_Width = 770;
    var tgridFTEs_Height = 275;
    var tgrid1 = window['<%=tgrid1.UID%>'];
    var tgridRates = window['<%=tgridRates.UID%>'];
    var tgridFTEs = window['<%=tgridFTEs.UID%>'];
    var new_CA_UIDs = 0;
    var bChanged = false;
 
    var OnLoad = function (event) {
        Grids.OnFocus = GridsOnFocus;
        Grids.OnAfterValueChanged = GridsOnAfterValueChanged;
        Grids.OnCanDrop = GridsOnCanDrop;
        tgrid1_selectedRow = 0;
        OnResize();
    };
    var OnBeforeUnload = function (event) {
        if (HasChanges() || bChanged == true)
            event.returnValue = "You have unsaved changes.\n";
    };
    function HasChanges() {
        var grid = tgrid1.grid;
        if (grid == null)
            return false;
        var hasChanges = grid.HasChanges();
        if ((hasChanges & (1 << 0)) != 0)
            return true;
        else
            return false;
    };
    function GridsOnFocus(grid, row, col, orow, ocol, pagepos) {
        switch (grid.id) {
            case tgrid1.id:
                tgrid1_selectedRow = row;
                toolbar.enableItem("btnModify");
                toolbar.enableItem("btnDelete");
                toolbar.enableItem("btnRates");
                break;
            case tgridRates.id:
                tgridRates_selectedRow = row;
                toolbarRates.enableItem("btnInsert2");
                toolbarRates.enableItem("btnDelete2");
                break;
            case tgridFTEs.id:
                tgridFTEs_selectedRow = row;
                toolbarFTEs.enableItem("btnInsert2");
                toolbarFTEs.enableItem("btnDelete2");
                break;
        }
    };
    function GridsOnAfterValueChanged(grid, row, col, val) {
        switch (grid.id) {
            case tgridFTEs.id:
                var hasChanges = grid.HasChanges();
                if ((hasChanges & (1 << 0)) != 0)
                    toolbarFTEs.enableItem("btnSaveFTEs");
                else
                    toolbarFTEs.disableItem("btnSaveFTEs");
                break;
        }
    };
    function GridsOnCanDrop(grid, row, togrid, torow, type, copy) {
        // types : 0 - cannot drop; 1 - above; 2 append as child of torow; 3 - add below torow
        if (grid == null || togrid == null || row == null || torow == null || grid.id != tgrid1.id || grid.id != togrid.id)
            return 0;
        var toroleid = grid.GetAttribute(torow, "CA_ROLE", null);
        if (toroleid != 0) {
            return 0;
        }
        return type;
    };
    var OnResize = function (event) {
        var lefttop = tgrid1.GetLeftTopPositions();
        var newHeight = document.documentElement.clientHeight - lefttop[1] - 18;
        var newWidth = document.documentElement.clientWidth - lefttop[0] - 23;
        tgrid1.SetSizes(newWidth,newHeight);
    };
    function ddlChanged(ddlName) {
        bChanged = true;
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
                        var ddlMajorCategoryItems = document.getElementById('<%=ddlMajorCategoryItems.ClientID%>');
                        ddlMajorCategoryItems.options.length = 0;
                        ddlMajorCategoryItems.selectedIndex = -1;
                        var item = json.reply.MajorCategoryItems.Item;
                        for (var i=0; i<item.length; i++) {
                            ddlMajorCategoryItems.options[ddlMajorCategoryItems.options.length] = new Option(item[i].name, item[i].id);
                        }
                    }
                }
                else {
                    var ddlMajorCategoryItems = document.getElementById('<%=ddlMajorCategoryItems.ClientID%>');
                    ddlMajorCategoryItems.options.length = 0;
                    ddlMajorCategoryItems.selectedIndex = -1;
                }
                break;
        }
    };
    function  DisplayDialog (width, height, title, idWindow, idAttachObj, bModal, bResize) {
        var dlg = jsf_displayDialog(thiswins, 0, 0, width, height, title, idWindow, idAttachObj, bModal, bResize);
        dlg.attachEvent("onClose", function (win) { return CloseDialog(idWindow); });
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
        var ddlMajorCategoryItems = document.getElementById('<%=ddlMajorCategoryItems.ClientID%>');
        var sMCItemValue = "";
        if (ddlMajorCategoryItems.selectedIndex > -1)
            sMCItemValue = ddlMajorCategoryItems.options[ddlMajorCategoryItems.selectedIndex].value;
        var sb = new StringBuilder("");
        sb.append('<data');
        sb.append(' majorcategoryid="' + sMCValue + '"');
        sb.append(' majorcategorydefault="' + sMCItemValue + '"');
        sb.append('>');
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
        var sRowId = "";
        if (toolbar.isItemDisabled(event) == true)
            return;
        switch (event) {
            case "btnAdd":
                var row = tgrid1.AddRow();
                new_CA_UIDs--;
                tgrid1.SetCellValue(row, "CA_UID", new_CA_UIDs.toString());
                tgrid1.SetCellValue(row, "CA_NAME", "New Row");
                tgrid1_OnFocus(tgrid1.grid, row, "CA_NAME");
                break;
            case "btnAddRole":
                var grid = tgrid1.grid;
                var parentrow = tgrid1_selectedRow;
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
                            row = row.nextSibling;
                        }
                        if (bAdd)
                            availableRolesSelect.options[availableRolesSelect.options.length] = new Option(masterRoles.options[i].text, masterRoles.options[i].value);
                    }
                    if (availableRolesSelect.options.length > 0) {
                        DisplayDialog(400, 280, "Add roles to " + grid.GetAttribute(parentrow, "CA_NAME", null), "winRolesDlg", "idRolesDlg", true, false);
                    }
                    else
                        alert("All available roles have already been added to this summary row.");
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
                    tgrid1.grid.AcceptChanges();
                    bChanged = false;
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
                    sb.appendLine("All child rows of the selected cost category will also be deleted.");
                    sb.appendLine("");
                }
                sb.appendLine("Press 'OK' to continue. The rows will be deleted on Save.");
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
                    var txtBaseRate = document.getElementById('txtBaseRate');
                    txtBaseRate.value = NumberToString(parseFloat(json.reply.costcategory.baserate), "0.00");
                    tgridRates.Initialize(json.reply.costcategory.tgridRates);
                    tgridRates.SetWidth(390);
                    tgridRates.SetHeight(150);
                    toolbarRates.Render();
                    var s = "Add rates for " + grid.GetAttribute(tgrid1_selectedRow, "CA_NAME", null);
                    tgridRates_selectedRow = 0;
                    DisplayDialog(420, 380, s, "winRatesDlg", "idRatesDlg", true, false);
                }
                break;
            case "btnFTEs":
                var hasChanges = tgrid1.grid.HasChanges();
                if ((hasChanges & (1 << 0)) != 0) {
                     window.alert("You have unsaved changes to cost categories.\n\nYou must save or abandon these changes before editing FTEs.");
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
                tgridFTEs.Initialize(json.reply.FTEs.tgridFTEs);
                tgridFTEs.SetWidth(tgridFTEs_Width);
                tgridFTEs.SetHeight(tgridFTEs_Height);
                toolbarFTEs.Render();
                var s = "Cost Category FTE Values";
                tgridFTEs_selectedRow = 0;
                DisplayDialog(800, 455, s, "winFTEsDlg", "idFTEsDlg", true, false);
                break;
        }
        return false;
    };
    function ratesDlg_event(event) {
        switch (event) {
            case "ok":
                var sb = new StringBuilder();
                tgridRates.grid.EndEdit(true);
                var sRowId = tgrid1.grid.GetAttribute(tgrid1_selectedRow, "CA_UID", null).toString();
                sb.append('<request function="CostCategoriesRequest" context="SaveCostCategoryRatesInfo">');
                sb.append('<data');
                sb.append(' CA_UID="' + sRowId + '"');
                var txtBaseRate = document.getElementById('txtBaseRate');
                sb.append(' baserate="' + txtBaseRate.value + '"');
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
                var row;
                if (event == "btnInsert2") {
                    row = tgridRates.grid.AddRow(null, tgridRates_selectedRow, true);
                }
                else {
                    row = tgridRates.grid.AddRow(null, null, true);
                }
                tgridRates_selectedRow = row;
                var dt = new Date(); //StringToDate(dateAndRateArr[0], "yyyy.MM.dd");
                tgridRates.grid.SetAttribute(row, null, "BC_EFFECTIVE_DATE", dt, 1, 0);
                tgridRates.grid.SetAttribute(row, null, "BC_RATE", 1.0 , 1, 0);
                tgridRates.Focus(row, 'BC_RATE');
                break;
          case "btnDelete2":
               tgridRates.grid.DeleteRow(tgridRates_selectedRow, 2); // 1=okmsg+del; 2=del; 3=undel
               break;
        }
        return false;
    };
    function FTEsDlg_event(event) {
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
                tgridFTEs.SetWidth(tgridFTEs_Width);
                tgridFTEs.SetHeight(tgridFTEs_Height);
                break;
        }
        return false;
    };
    var roleDlg_event = function (event) {
        switch (event) {
            case "ok":
                var grid = tgrid1.grid;
                var parentrow = tgrid1_selectedRow;
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
    thiswins.setImagePath("../epmlive/dhtml/windows/imgs/");
    thiswins.setSkin("dhx_web");
    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("load", OnLoad, true);
        window.addEventListener("beforeunload", OnBeforeUnload, true);
        window.addEventListener("resize", OnResize, true);
    }
    else { // e.g. IE
        window.attachEvent("onload", OnLoad);
        window.attachEvent("onbeforeunload", OnBeforeUnload);
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
