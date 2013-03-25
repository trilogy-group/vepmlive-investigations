<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register src="Tools/DGrid.ascx" tagname="DGridUserControl" tagprefix="dg1" %>
<%@ Register src="Tools/TGrid.ascx" tagname="TGridUserControl" tagprefix="tg1" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostTypes_NAX.aspx.cs" Inherits="WorkEnginePPM.CostTypes_NAX" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Reference Control="/_layouts/ppm/tools/DGrid.ascx" %>
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

.descriptioncell
{
    width: 125px;
}

.controlcell
{
    width: 425px;
}

</style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<div class="modalContent" id="idCostTypeDlg" style="display:none;">
    <input id="idCostTypeDlgMode" type="hidden" value="" />
	<div style="margin-top:10px;padding-right:10px;">
		<div style="padding-bottom:3px;">
            <table cellspacing="0">
                <tr>
                    <td style="height:1px;" class="topcell"></td>
                    <td style="height:1px;" class="topcell"></td>
                </tr>
                <tr style="display:none;">
                    <td class="descriptioncell">Field Id</td>
                    <td class="controlcell"><input type="text" id="txtId" /></td>
                </tr>
                <tr id="trName">
                    <td class="descriptioncell">Cost Type Name</td>
                    <td class="controlcell"><input type="text" id="txtName" /></td>
                </tr>
                <tr id="trCTOptions">
                    <td class="descriptioncell">How will this Cost Type be created and maintained</td>
                    <td class="controlcell">
                        <select id="idCTOptions" onchange="costtypeDlg_event('CTOptionsChanged');">
                            <option value='1'>Editable</option>
                            <option value='41'>Timesheet Actuals</option>
                            <option value='9'>Resource Plans</option>
                            <option value='3'>Calculated from other Cost Types</option>
                            <option value='30'>Calculated - Cumulative</option>
                            <option value='0'>Display Only - populated directly to database</option>
                            <option value='101'>Display Only with Details</option>
                        </select>
                   </td>
                </tr>
                <tr id="trOpenLevel">
                    <td class="descriptioncell">
                        Open to level in Edit Cost</td>
                    <td class="controlcell">
                        <select id="idOpenLevel" >
                            <option value='1'>1</option>
                            <option value='2'>2</option>
                            <option value='3'>3</option>
                            <option value='4'>4</option>
                            <option value='5'>5</option>
                        </select>
                   </td>
                </tr>
                <tr id="trCalendar">
                    <td class="descriptioncell">
                        Fiscal Calendar for input</td>
                    <td class="controlcell">
                        <select id="idCalendar" >
                        </select>
                   </td>
                </tr>
                <tr id="trNamedRate">
                    <td class="descriptioncell">
                        Named Rate Visible</td>
                    <td class="controlcell">
                        <input type="checkbox" id="cbNamedRate" />
                   </td>
                </tr>
                <tr id="trtgrid1">
                    <td class="descriptioncell">
                        Choose the custom fields you want to use</td>
                    <td class="controlcell">
                        <tg1:TGridUserControl id="tgrid1" runat="server" />
                   </td>
                </tr>
                <tr id="trtgrid2">
                    <td class="descriptioncell">
                        Identify the cost categories which can be used for this cost type</td>
                    <td class="controlcell">
                        <tg1:TGridUserControl id="tgrid2" runat="server" />
                   </td>
                </tr>
            </table>
		</div>
        <div id="idFormulaBox" style="display:none;">
			<table style="width: 100%;" border="0" cellspacing="1">
				<tr>
					<td class="ms-propertysheet"> <label for="idFormula">Formula:</label><!-- --> </td>
                    <td class="ms-propertysheet"> <label for="idFrmFields">Insert Component:</label><!-- --> </td>
				</tr>
				<tr>
					<td class="ms-propertysheet" nowrap="nowrap">
					    <textarea  class="ms-formula" name="Formula" style="height: 95px !important; width: 200px !important;" rows="5" cols="24" id="idFormula" dir="ltr"></textarea>
					</td>
					<td>
						<select name="FrmFields" size="7" id="idFrmFields" ondblclick="javascript:AddColumnToFormula()" >
						</select>
					</td>
				</tr>
				<tr>
					<td class="ms-propertysheet" nowrap="nowrap">
			            <input id="idValidate" type="button" class="epmliveButton" value="Validate" onclick="costtypeDlg_event('validate');" style="height: 25px !important"/>
					</td>
					<td>
			            <input id="idInsertField" type="button" class="epmliveButton" value="Insert" onclick="costtypeDlg_event('insertField');" style="height: 25px !important""/>
					</td>
				</tr>
            </table>
        </div>
        <div id="idDeleteWarning" style="color:red; display:none;"><a>Are you sure, all data will be cleared?</a></div>
		<div style="float:right;">
			<div class="button-container" >
			    <input id="idOKButton" type="button" class="epmliveButton" value="OK" onclick="costtypeDlg_event('ok');"/>
			    <input type="button" class="epmliveButton" value="Cancel" onclick="costtypeDlg_event('cancel');"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idCostTotalsDlg" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
        <div style="display:block;"><dg1:DGridUserControl id="dgridCostTotals" runat="server" /></div>
		<div style="float:right;">
			<div class="button-container" >
			    <input type="button" class="epmliveButton" value="OK" onclick="costtotalsDlg_event('ok');"/>
			    <input type="button" class="epmliveButton" value="Cancel" onclick="costtotalsDlg_event('cancel');"/>
			</div>
		</div>
	</div>
</div>
<div class="modalContent" id="idSecurityDlg" style="display:none;">
	<div style="margin-top:10px;padding-right:10px;">
		<div style="padding-bottom:3px;">
            <table width="100%" cellspacing="0">
                <tr style="display:none;">
                    <td width="250" class="descriptioncell">
                        Field Id
                    </td>
                    <td class="controlcell">
                        <input type="text" id="Text1" />
                    </td>
                </tr>
            </table>
		</div>

        <div style="display:block;"><tg1:TGridUserControl id="tgridSecurity" runat="server" /></div>
		<div style="float:right;">
			<div class="button-container" >
			    <input type="button" class="epmliveButton" value="OK" onclick="securityDlg_event('ok');"/>
			    <input type="button" class="epmliveButton" value="Cancel" onclick="securityDlg_event('cancel');"/>
			</div>
		</div>
	</div>
</div>
<div style="display: block;" >
    <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
    <div id="idToolbarDiv"></div>
    <dg1:DGridUserControl id="dgrid1" runat="server" />
</div>
<script type="text/javascript">
    var shortDlgHeight = 380;
    var tallDlgHeight = 640;
    var toobarData = {
        parent: "idToolbarDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", id: "btnAdd", name: "Add", img: "addresource.gif", tooltip: "Add", width: "80px", onclick: "toolbar_event('btnAdd');" },
            { type: "button", id: "btnModify", name: "Modify", img: "addresource.gif", tooltip: "Modify", width: "80px", onclick: "toolbar_event('btnModify');", disabled: true },
            { type: "button", id: "btnDelete", name: "Delete", img: "delete.png", tooltip: "Delete", width: "80px", onclick: "return toolbar_event('btnDelete');", disabled: true },
            { type: "button", id: "btnCostTotals", name: "Cost Totals", img: "addresource.gif", tooltip: "Cost Totals", width: "80px", onclick: "toolbar_event('btnCostTotals');", disabled: true },
            { type: "button", id: "btnSecurity", name: "Security", img: "addresource.gif", tooltip: "Security", width: "80px", onclick: "toolbar_event('btnSecurity');", disabled: true }
        ]
    };

    var toolbar = new Toolbar(toobarData);
    toolbar.Render();
   
    var dgrid1 = window.<%=dgrid1.UID%>;
    var dgrid1_selectedRow = 0;
    var OnLoad = function (event) {
        dgrid1.addEventListener("onRowSelect", dgrid1_OnRowSelect);

        OnResize();
    };

    function dgrid1_OnRowSelect(rowid, cellindex) {
        dgrid1_selectedRow = rowid;
        toolbar.enableItem("btnModify");
        toolbar.enableItem("btnDelete");
        toolbar.enableItem("btnCostTotals");
        toolbar.enableItem("btnSecurity");
    };

    function OnResize(event) {
        var top = dgrid1.GetTop();
        var newHeight = document.documentElement.clientHeight - top - 5;
        dgrid1.SetHeight(newHeight);
    };

    function DisplayDialog (width, height, title, idWindow, idAttachObj, bModal, bResize) {
        var dlg = jsf_displayDialog(thiswins, 0, 0, width, height, title, idWindow, idAttachObj, bModal, bResize);
        dlg.attachEvent("onClose", function (win) { jsf_closeDialog2(win); return true; });
        return dlg;
    };

    function SetDialogHeight(idWindow, newHeight) {
        var dimension = thiswins.window(idWindow).getDimension();
        thiswins.window(idWindow).setDimension(dimension[0], newHeight);
    };

    function CloseDialog (idWindow) {
        jsf_closeDialog(thiswins, idWindow)
    };
    
    function SendRequest(sXML) {
        sURL = "./CostTypes.ashx";
        return jsf_sendRequest(sURL, sXML);
    };

    function toolbar_event(event) {
        var sRowId = "0";
        var dlgTitle = "Add Cost Type";
        document.getElementById('idCostTypeDlgMode').value = event;
        switch (event) {
            case "btnCostTotals":
                if (toolbar.isItemDisabled("btnCostTotals") == true) {
                    alert("Select a row to enable the Cost Totals button");
                    return false;
                }
                sRowId = dgrid1_selectedRow;
                var sRequest = '<request function="CostTypesRequest" context="GetCostTotalsInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                var dgridCostTotals = window.<%=dgridCostTotals.UID%>;
                var columnData = json.reply.costTotals.columnData;
                var tableData = json.reply.costTotals.tableData;
                dgridCostTotals.Initialize(columnData, tableData);
                dgridCostTotals.SetHeight(250);
                dgridCostTotals.grid.enableLightMouseNavigation(true);
                dgridCostTotals.grid.enableKeyboardSupport(true);
                DisplayDialog(470, 380, "Cost Totals for " + dgrid1.GetCellValue(dgrid1_selectedRow, "CT_NAME"), "winCostTotalsDlg", "idCostTotalsDlg", true, false);
                break;
            case "btnSecurity":
                if (toolbar.isItemDisabled("btnSecurity") == true) {
                    alert("Select a row to enable the Security button");
                    return false;
                }
                sRowId = dgrid1_selectedRow;
                var sRequest = '<request function="CostTypesRequest" context="GetSecurityInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                var costtype = json.reply.costtype;
                document.getElementById('txtId').value = costtype.CT_ID;
                var tgridSecurity = window['<%=tgridSecurity.UID%>'];
                tgridSecurity.Initialize(costtype.tgridSecurity);
                tgridSecurity.SetWidth(250);
                tgridSecurity.SetHeight(180);
                DisplayDialog(300, 300, "Security for " + dgrid1.GetCellValue(dgrid1_selectedRow, "CT_NAME"), "winSecurityDlg", "idSecurityDlg", true, false);
                break;
            case "btnModify":
                if (toolbar.isItemDisabled("btnModify") == true) {
                    alert("Select a row to enable the Modify button");
                    return false;
                }
                dlgTitle = "Modify Cost Type - " + dgrid1.GetCellValue(dgrid1_selectedRow, "CT_NAME");
                sRowId = dgrid1_selectedRow;
            case "btnAdd":
                var sRequest = '<request function="CostTypesRequest" context="GetCostTypesInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                var costtype = json.reply.costtype;
                document.getElementById('txtId').value = costtype.CT_ID;
                document.getElementById('txtName').value = costtype.CT_NAME;
                document.getElementById('txtName').disabled = false;
                document.getElementById('idCTOptions').value = costtype.CT_EDIT_MODE;
                document.getElementById('idOpenLevel').value = costtype.CT_INITIAL_LEVEL;
                document.getElementById('cbNamedRate').checked = (costtype.CT_NAMEDRATES == 1);

                var nCalendar = costtype.CT_CB_ID;
                var idCalendar = document.getElementById('idCalendar');
                idCalendar.options.length = 0;
                var item = json.reply.costtype.calendars.item;
                for (var i = 0; i < item.length; i++) {
                    idCalendar.options[idCalendar.options.length] = new Option(item[i].name, item[i].id);
                    if (item[i].id == nCalendar)
                        idCalendar.selectedIndex = idCalendar.options.length - 1;
                }

                document.getElementById('idDeleteWarning').style.display = "none";
                document.getElementById('idOKButton').value = "Save";
                var tgrid1 = window['<%=tgrid1.UID%>'];
                tgrid1.Initialize(costtype.tgridCFData);
                tgrid1.SetWidth(440);
                tgrid1.SetHeight(120);
                var tgrid2 = window['<%=tgrid2.UID%>'];
                tgrid2.Initialize(costtype.tgridData);
                tgrid2.SetWidth(440);
                tgrid2.SetHeight(150);

                var select = document.getElementById("idFrmFields");
                select.options.length = 0;

                var fields = json.reply.costtype.fields;
                if (fields != null) {
                    var field = fields.field;

                    for (var i = 0; i < field.length; i++) {
                            select.options[select.options.length] = new Option(field[i].CT_NAME, field.CT_ID);
                    }
                }
                var sFormula = jsf_getStringFromValue(json.reply.costtype.formula);
                document.getElementById('idFormula').value = sFormula;

                var ht = SetCTDlgState();
                DisplayDialog(625, ht, dlgTitle, "winCosttypeDlg", "idCostTypeDlg", true, false);
                break;
            case "btnDelete":
                if (toolbar.isItemDisabled("btnDelete") == true) {
                    alert("Select a row to enable the Delete button");
                    return false;
                }
                sRowId = dgrid1_selectedRow;
                var sRequest = '<request function="CostTypesRequest" context="GetCostTypesInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                var costtype = json.reply.costtype;
                document.getElementById('txtId').value = costtype.CT_ID;
                document.getElementById('txtName').value = costtype.CT_NAME;
                document.getElementById('txtName').disabled = true;
                document.getElementById('idCTOptions').value = costtype.CT_EDIT_MODE;
                document.getElementById('idOpenLevel').value = costtype.CT_INITIAL_LEVEL;
                document.getElementById('cbNamedRate').checked = (costtype.CT_NAMEDRATES == 1);
                var nCalendar = costtype.CT_CB_ID;
                var idCalendar = document.getElementById('idCalendar');
                idCalendar.options.length = 0;
                var item = json.reply.costtype.calendars.item;
                for (var i = 0; i < item.length; i++) {
                    idCalendar.options[idCalendar.options.length] = new Option(item[i].name, item[i].id);
                    if (item[i].id == nCalendar)
                        idCalendar.selectedIndex = idCalendar.options.length - 1;
                }
                document.getElementById('idDeleteWarning').style.display = "block";
                document.getElementById('idOKButton').value = "Delete";
                var tgrid1 = window['<%=tgrid1.UID%>'];
                tgrid1.Initialize(costtype.tgridCFData);
                tgrid1.SetWidth(440);
                tgrid1.SetHeight(120);
                var tgrid2 = window['<%=tgrid2.UID%>'];
                tgrid2.Initialize(costtype.tgridData);
                tgrid2.SetWidth(440);
                tgrid2.SetHeight(150);
                var sFormula = jsf_getStringFromValue(json.reply.costtype.formula);
                document.getElementById('idFormula').value = sFormula;
                var ht = SetCTDlgState();
                DisplayDialog(625, ht + 15, "Delete Cost Type - " + dgrid1.GetCellValue(dgrid1_selectedRow, "CT_NAME") + "  Are you sure?", "winCosttypeDlg", "idCostTypeDlg", true, false);
                break;
        }
        return false;
    };
    function AddColumnToFormula() {
        var select = document.getElementById("idFrmFields");
        if (select.selectedIndex >= 0){
            var formula = document.getElementById("idFormula");
            insertAtCursor(formula, select.options[select.selectedIndex].innerText);
        }
   };
   function insertAtCursor(myField, myValue) {
        //IE support
        if (document.selection) {
            myField.focus();
            sel = document.selection.createRange();
            sel.text = myValue;
        }
        //MOZILLA/NETSCAPE support
        else if (myField.selectionStart || myField.selectionStart == '0') {
            var startPos = myField.selectionStart;
            var endPos = myField.selectionEnd;
            myField.value = myField.value.substring(0, startPos) + myValue + myField.value.substring(endPos, myField.value.length);
        } else {
            myField.value += myValue;
        }
    };
    var costtypeDlg_event = function (event) {
        switch (event) {
            case "insertField":
                AddColumnToFormula();
                break;
            case "validate":
                var sb = new StringBuilder();
                sb.append('<request function="CostTypesRequest" context="ValidateFormula">');
                sb.append('<data');
                sb.append(' CT_ID="' + document.getElementById('txtId').value + '"');
                sb.append(' CT_NAME="' + jsf_xml(document.getElementById('txtName').value) + '"');
                sb.append(' CT_INITIAL_LEVEL="' + document.getElementById('idOpenLevel').value + '"');
                sb.append(' CT_CB_ID="' + document.getElementById('idCalendar').value + '"');
                sb.append(' CT_EDIT_MODE="' + document.getElementById('idCTOptions').value + '"');
                if (document.getElementById('cbNamedRate').checked==true) {sb.append(' CT_NAMEDRATES="1"');}  else {sb.append(' CT_NAMEDRATES="0"');}
                sb.append(' formula="' + jsf_xml(document.getElementById('idFormula').value) + '"');
                sb.append('/>');
                sb.append('</request>'); 
                var sRequest = sb.toString();
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                alert("Formula is valid");
                break;
            case "ok":
                var action = document.getElementById('idCostTypeDlgMode').value;
                switch (action) {
                  case "btnAdd":
                  case "btnModify":
                        var sb = new StringBuilder();
                        sb.append('<request function="CostTypesRequest" context="UpdateCosttypeInfo">');
                        sb.append('<data');
                        sb.append(' CT_ID="' + document.getElementById('txtId').value + '"');
                        sb.append(' CT_NAME="' + jsf_xml(document.getElementById('txtName').value) + '"');
                        sb.append(' CT_INITIAL_LEVEL="' + document.getElementById('idOpenLevel').value + '"');
                        sb.append(' CT_CB_ID="' + document.getElementById('idCalendar').value + '"');
                        sb.append(' CT_EDIT_MODE="' + document.getElementById('idCTOptions').value + '"');
                        if (document.getElementById('cbNamedRate').checked==true) {sb.append(' CT_NAMEDRATES="1"');}  else {sb.append(' CT_NAMEDRATES="0"');}
                        sb.append(' formula="' + document.getElementById('idFormula').value + '"');
                        sb.append('>');
                        var tgrid1 = window['<%=tgrid1.UID%>'];
                        sb.append('<tgridCFData>');
                        sb.append('<![CDATA[' + tgrid1.GetXmlData() + ']]>');
                        sb.append('</tgridCFData>');
                        sb.append('<tgridData>');
                        var tgrid2 = window['<%=tgrid2.UID%>'];
                        sb.append('<![CDATA[' + tgrid2.GetXmlData() + ']]>');
                        sb.append('</tgridData>');
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
                            sRowId = json.reply.costtype.CT_ID;
                            dgrid1.addRow(sRowId);
                        }
                        dgrid1.SetCellValue(sRowId, "CT_ID", json.reply.costtype.CT_ID);
                        dgrid1.SetCellValue(sRowId, "CT_NAME", json.reply.costtype.CT_NAME);

                        dgrid1.reapplySort();
                        dgrid1.selectRow(sRowId);
                        break;
                    case "btnDelete":
                        var sb = new StringBuilder();
                        sb.append('<request function="CostTypesRequest" context="DeleteCostType">');
                        sb.append('<data');
                        sb.append(' CT_ID="' + document.getElementById('txtId').value + '"');
                        sb.append('/>');
                        sb.append('</request>');
                        var sRequest = sb.toString();
                        var jsonString = SendRequest(sRequest);
                        var json = JSON_ConvertString(jsonString);
                        if (json.reply != null) {
                            if (jsf_alertError(json.reply.error) == true)
                                return false;
                        }
                        // if deleted clear data from row
                        var sRowId = dgrid1_selectedRow;
                        dgrid1.deleteRow(sRowId);
                        break;
                }
                CloseDialog('winCosttypeDlg');
                break;
            case "cancel":
                CloseDialog('winCosttypeDlg');
                break;
            case "lookupChanged":
                var lookups = document.getElementById('idLookups');
                var sId = lookups.options[lookups.selectedIndex].value;
                if (sId == null) 
                    sId = "0";

                var sRequest = '<request function="CostTypesRequest" context="ReadLookup"><data><![CDATA[' + sId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                    var tgrid2 = window['<%=tgrid2.UID%>'];
                    tgrid2.Initialize(json.reply.customfield.tgridData);
                    tgrid2.SetWidth(380);
                    tgrid2.SetHeight(150);
                }
                break;
            case "CTOptionsChanged":
                SetDialogHeight("winCosttypeDlg", SetCTDlgState());
                break;
        }
    };
    function SetCTDlgState() {
        var idCTOptions = document.getElementById('idCTOptions');
        var ctoption = idCTOptions.value;
        document.getElementById('trName').style.display = 'block';
        document.getElementById('trCTOptions').style.display = 'block';
        if (ctoption == "3" || ctoption == "30") {
            document.getElementById('trOpenLevel').style.display = 'none';
            document.getElementById('trCalendar').style.display = 'none';
            document.getElementById('trNamedRate').style.display = 'none';
            document.getElementById('trtgrid1').style.display = 'none';
            document.getElementById('trtgrid2').style.display = 'none';
            document.getElementById('idFormulaBox').style.display = 'block';
            return shortDlgHeight;
        } else {
            document.getElementById('trOpenLevel').style.display = 'block';
            document.getElementById('trCalendar').style.display = 'block';
            document.getElementById('trNamedRate').style.display = 'block';
            document.getElementById('trtgrid1').style.display = 'block';
            document.getElementById('trtgrid2').style.display = 'block';
            document.getElementById('idFormulaBox').style.display = 'none';
            return tallDlgHeight;
        }
    };
    var costtotalsDlg_event = function (event) {
        var dgridCostTotals = window.<%=dgridCostTotals.UID%>;
        dgridCostTotals.grid.editStop();
        var sRowId = dgrid1_selectedRow;
        switch (event) {
            case "ok":
                var sb = new StringBuilder();
                sb.append('<request function="CostTypesRequest" context="UpdateCostTotalsInfo">');
                sb.append('<data');
                sb.append(' CT_ID="' + sRowId + '"');
                sb.append('>');
                sb.append('<dgridCostTotals>');
                sb.append('<![CDATA[' + dgridCostTotals.GetXmlData() + ']]>');
                sb.append('</dgridCostTotals>');
                sb.append('</data>');
                sb.append('</request>');
                var sRequest = sb.toString();
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }

                CloseDialog('winCostTotalsDlg');
                break;
            case "cancel":
                CloseDialog('winCostTotalsDlg');
                break;
        }
    };
    var securityDlg_event = function (event) {
        switch (event) {
            case "ok":
                var sb = new StringBuilder();
                sb.append('<request function="CostTypesRequest" context="UpdateSecurityInfo">');
                sb.append('<data');
                sb.append(' CT_ID="' + document.getElementById('txtId').value + '"');
                sb.append('>');
                var tgridSecurity = window['<%=tgridSecurity.UID%>'];
                sb.append('<tgridSecurity>');
                sb.append('<![CDATA[' + tgridSecurity.GetXmlData() + ']]>');
                sb.append('</tgridSecurity>');
                sb.append('</data>');
                sb.append('</request>');
                var sRequest = sb.toString();
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                CloseDialog('winSecurityDlg');
                break;
            case "cancel":
                CloseDialog('winSecurityDlg');
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
Cost Types
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Cost Types
</asp:Content>
