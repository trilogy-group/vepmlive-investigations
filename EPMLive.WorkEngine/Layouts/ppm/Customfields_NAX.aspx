<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register src="Tools/DGrid.ascx" tagname="DGridUserControl" tagprefix="dg1" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
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
                </select>
            </td>
        </tr>
    </table>
    <div id="idFormulaBox" style="width:416px; display:none; padding-top: 10px; padding-bottom: 10px;">
		<table border="0" cellspacing="0">
			<tr>
				<td class="ms-propertysheet"> <label for="idFormula">Formula (optional):</label><!-- --> </td>
                <td class="ms-propertysheet"> <label for="idFrmFields">Insert Column:</label><!-- --> </td>
			</tr>
			<tr>
				<td class="ms-propertysheet" nowrap="nowrap">
					<textarea  class="epmliveFormula" name="Formula" style="height: 102px !important; width: 200px; padding: 3px;" rows="5" cols="24" id="idFormula" dir="ltr"></textarea>
				</td>
				<td>
					<select name="FrmFields" size="7" id="idFrmFields" style="width: 200px; padding: 3px;" ondblclick="javascript:AddColumnToFormula();" >
					</select>
				</td>
			</tr>
			<tr>
				<td class="ms-propertysheet" nowrap="nowrap">
			        <input id="idValidate" type="button" class="epmliveButton" value="Validate" onclick="customfieldDlg_event('validate');" />
				</td>
				<td>
			        <input id="idInsertField" type="button" class="epmliveButton" value="Insert Field" onclick="customfieldDlg_event('insertField');" />
				</td>
			</tr>
        </table>
    </div>
    <div id="idDeleteWarning" style="width:300px; color:red; display:none;"><a>Are you sure, all data will be cleared?</a></div>
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
    var dgrid1 = window['<%=dgrid1.UID%>'];
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
        }
        else {
            formulaBox.style.display = 'none';
        }
        ResizeDialog("winCustomfieldDlg", "idCustomfieldDlg");
    };
    function PopulateFieldTypes(entity) {
        var select = document.getElementById("idFieldType");
        select.options.length = 0;
        if (entity == 2) {
            select.options[select.options.length] = new Option("Text", "9");
            select.options[select.options.length] = new Option("Number (optional calculation)", "3");
            select.options[select.options.length] = new Option("Cost (optional calculation)", "8");
            select.options[select.options.length] = new Option("Flag", "13");
            select.options[select.options.length] = new Option("Date", "1");
        }
        else {
            select.options[select.options.length] = new Option("Text", "9");
            select.options[select.options.length] = new Option("Number", "3");
            select.options[select.options.length] = new Option("Cost", "8");
            select.options[select.options.length] = new Option("Flag", "13");
            select.options[select.options.length] = new Option("Date", "1");
        }
    };

    function idEntity_OnChange() {
        var entity=document.getElementById('idEntity').value;
        PopulateFieldTypes(entity);
        idFieldType_OnChange();
    };
    function SelectAll(id) {
        document.getElementById(id).focus();
        document.getElementById(id).select();
    };
    function dgrid1_OnRowSelect(rowid, cellindex) {
        dgrid1_selectedRow = rowid;
        if (rowid != null && rowid > 0) {
            var isDeprecated = dgrid1.GetCellValue(rowid, "IsDeprecated");
            if (isDeprecated != "1")
                toolbar.enableItem("btnModify");
            else
                toolbar.disableItem("btnModify");

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
        //var toolbardiv=document.getElementById('idToolbarDiv');
        //var newWidth = toolbardiv.offsetWidth;
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
            case 'winCustomfieldDlg':
                dgrid1.grid.selectRowById(dgrid1_selectedRow);
                break;
        }
        return jsf_closeDialog(thiswins, idWindow);
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
    };
    function toolbar_event(event) {
        var sRowId = "";
        document.getElementById('idCustomfieldDlgMode').value = event;
        var bModify = false;
        var dlgTitle = "Add Custom Field";
        switch (event) {
            case "btnModify":
                if (toolbar.isItemDisabled("btnModify") == true) {
                    var isDeprecated = dgrid1.GetCellValue(dgrid1_selectedRow, "IsDeprecated");
                    if (isDeprecated != "1")
                        alert("Select a row to enable the Modify button");
                    else
                        alert("This Custom Field Type is deprecated and cannot be modified");

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
                PopulateFieldTypes(entity);
                document.getElementById('idEntity').value = entity;
                var fieldFormat = json.reply.customfield.FA_FORMAT;
                document.getElementById('idFieldType').value = fieldFormat;
                document.getElementById('txtName').disabled = false;
                document.getElementById('txtDesc').disabled = false;
                document.getElementById('idEntity').disabled = bModify;
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
                document.getElementById('idFormula').value = "";
                //formulaBox.value="";
                if (entity == 2 && (fieldFormat == 3 || fieldFormat == 8)) {
                    formulaBox.style.display = 'block';
                    var sFormula = GetStringFromValue(json.reply.customfield.formula);
                    document.getElementById('idFormula').value = sFormula;
                }
                else {
                    formulaBox.style.display = 'none';
                }
                DisplayDialog(445, 350, dlgTitle, "winCustomfieldDlg", "idCustomfieldDlg", true, false);
                break;
            case "btnDelete":
                if (toolbar.isItemDisabled("btnDelete") == true) {
                    alert("Select a row to enable the Delete button");
                    return false;
                }
                sRowId = dgrid1_selectedRow;
                var isDeprecated = dgrid1.GetCellValue(dgrid1_selectedRow, "IsDeprecated");
                if (isDeprecated == "1") {
                    var b = window.confirm("This Custom Field Type is deprecated and should be deleted.\n\nDelete Now?");
                    if (b) {
                        var sb = new StringBuilder();
                        sb.append('<request function="CustomfieldRequest" context="DeleteCustomfieldInfo">');
                        sb.append('<data');
                        sb.append(' FA_FIELD_ID="' + sRowId + '"');
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
                    }
                    return;
                }
                var sRequest = '<request function="CustomfieldRequest" context="ReadCustomfieldInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                var entity = json.reply.customfield.ENTITY_ID;
                PopulateFieldTypes(entity);
                document.getElementById('txtId').value = json.reply.customfield.FA_FIELD_ID;
                document.getElementById('txtName').value = GetStringFromValue(json.reply.customfield.FA_NAME);
                document.getElementById('txtDesc').value = GetStringFromValue(json.reply.customfield.FA_DESC);
                document.getElementById('idEntity').value = entity;
                document.getElementById('idFieldType').value = json.reply.customfield.FA_FORMAT;
                document.getElementById('txtName').disabled = true;
                document.getElementById('txtDesc').disabled = true;
                document.getElementById('idEntity').disabled = true;
                document.getElementById('idFieldType').disabled = true;
                
                document.getElementById('idDeleteWarning').style.display = "block";
                document.getElementById('idOKButton').value = "Delete";

                var formulaBox = document.getElementById('idFormulaBox');
                formulaBox.style.display = 'none';
                DisplayDialog(445, 360, "Delete Custom Field - " + json.reply.customfield.FA_NAME, "winCustomfieldDlg", "idCustomfieldDlg", true, false);
                break;
        }
        return false;
    };
    function AddColumnToFormula() {
        var select = document.getElementById("idFrmFields");
        if (select != null && select.selectedIndex >= 0){
            var formula = document.getElementById("idFormula");
            insertAtCursor(formula, select.options[select.selectedIndex].innerHTML);
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
        else if (myField.selectionStart != myField.selectionEnd && typeof myField.selectionEnd != "undefined") {
            //alert (myField.selectionStart + "::" + myField.selectionEnd);
            var startPos = myField.selectionStart;
            var endPos = myField.selectionEnd;
            myField.value = myField.value.substring(0, startPos) + myValue + myField.value.substring(endPos, myField.value.length);
        } else {
            //alert (myField.value + ":" + myValue);
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
    thiswins.setImagePath("../epmlive/dhtml/windows/imgs/");
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
