<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register src="Tools/DGrid.ascx" tagname="DGridUserControl" tagprefix="dg1" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customfields_NAX.aspx.cs" Inherits="WorkEnginePPM.Customfields_NAX" DynamicMasterPageFile="~masterurl/default.master" %>
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
<div class="modalContent" id="idCustomfieldDlg" style="display:none;">
    <input id="idCustomfieldDlgMode" type="hidden" value="" />
	<div>
        <table style="width:100%;" cellspacing="0" cellpadding="0">
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
                    Entity</td>
                <td class="controlcell">
                    <select id="idEntity" style="width:206px;" onchange="idEntity_OnChange();">
                        <option value='2'>Portfolio</option><option value='1'>Resource</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td class="descriptioncell">
                    <label for="txtName">Field Name</label>
                </td>
                <td class="controlcell">
                    <input type="text" id="txtName" style="width:200px;" />
                </td>
            </tr>
            <tr>
                <td class="descriptioncell">
                    Field Description
                </td>
                <td class="controlcell">
                        <input type="text" id="txtDesc" style="Width:200px;"/>
                </td>
            </tr>
            <tr>
                <td class="descriptioncell">
                    Field Type</td>
                <td class="controlcell">
                    <select id="idFieldType" style="width:206px;" onchange="idFieldType_OnChange();">
                        <option value='9'>Text</option>
                        <option value='3'>Number (optional calculation)</option>
                        <option value='8'>Cost (optional calculation)</option>
                        <option value='13'>Flag</option>
                        <option value='1'>Date</option>
                    </select>
                </td>
            </tr>
        </table>
	</div>
    <div id="idFormulaBox" style="display:none; padding-top: 10px; padding-bottom: 10px;">
		<table style="width:100%;" border="0" cellspacing="0">
			<tr>
				<td class="ms-propertysheet"> <label for="idFormula">Formula (optional):</label><!-- --> </td>
                <td class="ms-propertysheet"> <label for="idFrmFields">Insert Column:</label><!-- --> </td>
			</tr>
			<tr>
				<td class="ms-propertysheet" nowrap="nowrap">
					<textarea  class="ms-formula" name="Formula" style="height: 95px !important; width: 200px !important; padding: 3px;" rows="5" cols="24" id="idFormula" dir="ltr"></textarea>
				</td>
				<td>
					<select name="FrmFields" size="7" id="idFrmFields" style="width: 200px !important; padding: 3px;" ondblclick="javascript:AddColumnToFormula()" >
					</select>
				</td>
			</tr>
			<tr>
				<td class="ms-propertysheet" nowrap="nowrap">
			        <input id="idValidate" type="button" class="epmliveButton" value="Validate" onclick="customfieldDlg_event('validate');" style="height: 25px !important"/>
				</td>
				<td>
			        <input id="idInsertField" type="button" class="epmliveButton" value="Insert Field" onclick="customfieldDlg_event('insertField');" style="height: 25px !important""/>
				</td>
			</tr>
        </table>
    </div>
    <div id="idDeleteWarning" style="color:red; display:none;"><a>Are you sure, all data will be cleared?</a></div>
	<div class="button-container" >
		<input id="idOKButton" type="button" class="epmliveButton" value="OK" onclick="customfieldDlg_event('ok');"/>
		<input type="button" class="epmliveButton" value="Cancel" onclick="customfieldDlg_event('cancel');"/>
	</div>
</div>
<div style="display: block;" >
<asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
<div id="idToolbarDiv"></div>
<dg1:DGridUserControl id="dgrid1" runat="server" />
</div>
<script type="text/javascript">
    var shortDlgHeight = 250;
    var tallDlgHeight = 420;
    var toobarData = {
        parent: "idToolbarDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", name: "Add", img: "addresource.gif", tooltip: "Add", width: "80px", onclick: "toolbar_event('btnAdd');" },
            { type: "button", id: "btnModify", name: "Modify", img: "editview.gif", tooltip: "Modify", width: "80px", onclick: "return toolbar_event('btnModify');", disabled: true },
            { type: "button", id: "btnDelete", name: "Delete", img: "delete.png", tooltip: "Delete", width: "80px", onclick: "return toolbar_event('btnDelete');", disabled: true }
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
    
    function idFieldType_OnChange() {
        var entity=document.getElementById('idEntity').value;
        var fieldtype=document.getElementById('idFieldType').value;
        var idcalc = document.getElementById('idcalculation');
        var formulaBox = document.getElementById('idFormulaBox');
        if (entity == 2 && (fieldtype==3 || fieldtype==8)) {
            formulaBox.style.display = 'block';
            SetDialogHeight("winCustomfieldDlg", tallDlgHeight);
        }
        else {
            formulaBox.style.display = 'none';
            SetDialogHeight("winCustomfieldDlg", shortDlgHeight);
        }
    };
    function idEntity_OnChange() {
        idFieldType_OnChange();
    };
    function SelectAll(id) {
        document.getElementById(id).focus();
        document.getElementById(id).select();
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
        var top = dgrid1.GetTop();
        var newHeight = document.documentElement.clientHeight - top - 5;
        dgrid1.SetHeight(newHeight);
    };
    
    function  DisplayDialog (width, height, title, idWindow, idAttachObj, bModal, bResize) {
        var dlg = jsf_displayDialog(thiswins, 0, 0, width, height, title, idWindow, idAttachObj, bModal, bResize);
        dlg.attachEvent("onClose", function (win) { jsf_closeDialog2(win); return true; });
        return dlg;
    };
    
    function  SetDialogHeight(idWindow, newHeight) {
        var dimension = thiswins.window(idWindow).getDimension();
        thiswins.window(idWindow).setDimension(dimension[0], newHeight);
    };

    function CloseDialog (idWindow) {
        jsf_closeDialog(thiswins, idWindow)
    };

    function SendRequest(sXML) {
         sURL = "./Customfields.ashx";
         return jsf_sendRequest(sURL, sXML);
    };
    function GetStringFromValue(val)
    {
        if (val == null)
            return "";
        return val.toString();
    }

    function toolbar_event(event) {
        var sRowId = "";
        document.getElementById('idCustomfieldDlgMode').value = event;
        var bModify = false;
        var dlgTitle = "Add Custom Field";
        switch (event) {
            case "btnModify":
                if (toolbar.isItemDisabled("btnModify") == true) {
                    alert("Select a row to enable the Modify button");
                    return false;
                }
                dlgTitle = "Modify Custom Field";
                bModify = true;
            case "btnAdd":
                sRowId = "0";
                if (event == "btnModify")
                    sRowId = dgrid1_selectedRow;
                var sRequest = '<request function="CustomfieldRequest" context="ReadCustomfieldInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                var fieldId = json.reply.customfield.FA_FIELD_ID
                document.getElementById('txtId').value = fieldId;
                document.getElementById('txtName').value = GetStringFromValue(json.reply.customfield.FA_NAME);
                document.getElementById('txtDesc').value = GetStringFromValue(json.reply.customfield.FA_DESC);
                var entity = json.reply.customfield.ENTITY_ID;
                document.getElementById('idEntity').value = entity;
                document.getElementById('idEntity').disabled = bModify;
                var fieldFormat = json.reply.customfield.FA_FORMAT;
                document.getElementById('idFieldType').value = fieldFormat;
                document.getElementById('idFieldType').disabled = bModify;

                document.getElementById('idDeleteWarning').style.display = "none";
                document.getElementById('idOKButton').value = "Save";

                var select = document.getElementById("idFrmFields");
                select.options.length = 0;

                var fields = json.reply.customfield.fields;
                if (fields != null) {
                    var field = fields.field;

                    for (var i = 0; i < field.length; i++) {
                        if (field[i].FA_FIELD_ID != fieldId)
                            select.options[select.options.length] = new Option(field[i].FA_NAME, field.FA_FIELD_ID);
                    }
                }
                var formulaBox = document.getElementById('idFormulaBox');
                formulaBox.value="";
                if (entity == 2 && (fieldFormat == 3 || fieldFormat == 8)) {
                    formulaBox.style.display = 'block';
                    var sFormula = GetStringFromValue(json.reply.customfield.formula);
                    document.getElementById('idFormula').value = sFormula;
                    DisplayDialog(445, tallDlgHeight, dlgTitle, "winCustomfieldDlg", "idCustomfieldDlg", true, false);
                }
                else {
                    formulaBox.style.display = 'none';
                    DisplayDialog(445, shortDlgHeight, dlgTitle, "winCustomfieldDlg", "idCustomfieldDlg", true, false);
                }
                break;
            case "btnDelete":
                if (toolbar.isItemDisabled("btnDelete") == true) {
                    alert("Select a row to enable the Delete button");
                    return false;
                }
                sRowId = dgrid1_selectedRow;
                var sRequest = '<request function="CustomfieldRequest" context="ReadCustomfieldInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                document.getElementById('txtId').value = json.reply.customfield.FA_FIELD_ID;
                document.getElementById('txtName').value = GetStringFromValue(json.reply.customfield.FA_NAME);
                document.getElementById('txtName').disabled = true;
                document.getElementById('txtDesc').value = GetStringFromValue(json.reply.customfield.FA_DESC);
                document.getElementById('txtDesc').disabled = true;
                document.getElementById('idEntity').value = json.reply.customfield.ENTITY_ID;
                document.getElementById('idEntity').disabled = true;
                document.getElementById('idFieldType').value = json.reply.customfield.FA_FORMAT;
                document.getElementById('idFieldType').disabled = true;
                
                document.getElementById('idDeleteWarning').style.display = "block";
                document.getElementById('idOKButton').value = "Delete";

                var formulaBox = document.getElementById('idFormulaBox');
                formulaBox.style.display = 'none';
                DisplayDialog(445, shortDlgHeight+10, "Delete Custom Field - " + json.reply.customfield.FA_NAME, "winCustomfieldDlg", "idCustomfieldDlg", true, false);
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
 var customfieldDlg_event = function (event) {
        switch (event) {
            case "insertField":
                AddColumnToFormula();
                break;
            case "validate":
                var sb = new StringBuilder();
                sb.append('<request function="CustomfieldRequest" context="ValidateFormula">');
                sb.append('<data');
                sb.append(' FA_FIELD_ID="' + document.getElementById('txtId').value + '"');
                sb.append(' FA_NAME="' + jsf_xml(document.getElementById('txtName').value) + '"');
                sb.append(' FA_DESC="' + jsf_xml(document.getElementById('txtDesc').value) + '"');
                sb.append(' ENTITY_ID="' + document.getElementById('idEntity').value + '"');
                sb.append(' FA_FORMAT="' + document.getElementById('idFieldType').value + '"');
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
                var action = document.getElementById('idCustomfieldDlgMode').value;
                switch (action) {
                    case "btnAdd":
                    case "btnModify":
                        //alert("btnModify.OK");
                        var sRowId = dgrid1_selectedRow;
                        var sb = new StringBuilder();
                        sb.append('<request function="CustomfieldRequest" context="UpdateCustomfieldInfo">');
                        sb.append('<data');
                        sb.append(' FA_FIELD_ID="' + document.getElementById('txtId').value + '"');
                        sb.append(' FA_NAME="' + jsf_xml(document.getElementById('txtName').value) + '"');
                        sb.append(' FA_DESC="' + jsf_xml(document.getElementById('txtDesc').value) + '"');
                        sb.append(' ENTITY_ID="' + document.getElementById('idEntity').value + '"');
                        sb.append(' FA_FORMAT="' + document.getElementById('idFieldType').value + '"');
                        sb.append(' formula="' + document.getElementById('idFormula').value + '"');
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
                            sRowId = json.reply.customfield.FA_FIELD_ID;
                            dgrid1.addRow(sRowId);
                        }
                        dgrid1.SetCellValue(sRowId, "FA_FIELD_ID", json.reply.customfield.FA_FIELD_ID);
                        dgrid1.SetCellValue(sRowId, "FA_NAME", json.reply.customfield.FA_NAME);
                        dgrid1.SetCellValue(sRowId, "FA_DESC", json.reply.customfield.FA_DESC);
                        dgrid1.SetCellValue(sRowId, "ENTITY_NAME", json.reply.customfield.ENTITY_NAME);
                        dgrid1.SetCellValue(sRowId, "FA_FORMAT_NAME", json.reply.customfield.FA_FORMAT_NAME);
                        dgrid1.SetCellValue(sRowId, "TABLE_NAME", json.reply.customfield.TABLE_NAME);
                        dgrid1.SetCellValue(sRowId, "FIELD_NAME", json.reply.customfield.FIELD_NAME);
                        dgrid1.reapplySort();
                        dgrid1.selectRow(sRowId);
                        break;
                    case "btnDelete":
                        var sRowId = dgrid1_selectedRow;
                        var sb = new StringBuilder();
                        sb.append('<request function="CustomfieldRequest" context="DeleteCustomfieldInfo">');
                        sb.append('<data');
                        sb.append(' FA_FIELD_ID="' + document.getElementById('txtId').value + '"');
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
                CloseDialog('winCustomfieldDlg');
                break;
            case "cancel":
                CloseDialog('winCustomfieldDlg');
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
Custom Fields
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Custom Fields
</asp:Content>
