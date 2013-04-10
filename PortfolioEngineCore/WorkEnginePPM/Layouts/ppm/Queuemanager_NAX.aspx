<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register src="Tools/DGrid.ascx" tagname="DGridUserControl" tagprefix="dg1" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Queuemanager_NAX.aspx.cs" Inherits="WorkEnginePPM.Queuemanager_NAX" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Reference Control="/_layouts/ppm/tools/DGrid.ascx" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script src="tools/jsfunctions.js" type="text/javascript"></script>
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
</style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<div style="display: block;" >
<div class="modalContent" id="idCustomfieldDlg" style="display:none;">
    <input id="idCustomfieldDlgMode" type="hidden" value="" />
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
                        Entity</td>
                    <td class="controlcell">
                        <select id="idEntity" style="width:206px;" onchange="idEntity_OnChange();">
                            <option value='2'>Portfolio</option><option value='1'>Resource</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td width="250" class="descriptioncell">
                        <label for="txtName">Field Name</label>
                    </td>
                    <td class="controlcell">
                        <input type="text" id="txtName" style="width:200px;" />
                    </td>
                </tr>
                <tr>
                    <td width="250" class="descriptioncell">
                        Field Description
                    </td>
                    <td class="controlcell">
                         <input type="text" id="txtDesc" style="Width:200px;"/>
                    </td>
                </tr>
                <tr>
                    <td width="250" class="descriptioncell">
                        Field Type</td>
                    <td class="controlcell">
                        <select id="idFieldType" style="width:206px;" onchange="idFieldType_OnChange();">
                            <option value='9'>Text</option>
                            <option value='3'>Number</option>
                            <option value='8'>Cost</option>
                            <option value='13'>Flag</option>
                            <option value='1'>Date</option>
                        </select>
                   </td>
                </tr>
            </table>
		</div>
        <div id="idFormulaBox" style="display:block;">
			<table border="0" cellspacing="1">
				<tr>
					<td class="ms-propertysheet"> <label for="idFormula">Formula:</label><!-- --> </td>
                    <td class="ms-propertysheet"> <label for="idFrmFields">Insert Column:</label><!-- --> </td>
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
			            <input id="idValidate" type="button" class="epmliveButton" value="Validate" onclick="customfieldDlg_event('validate');" style="height: 25px !important"/>
					</td>
					<td>
			            <input id="idInsertField" type="button" class="epmliveButton" value="Insert Field" onclick="customfieldDlg_event('insertField');" style="height: 25px !important""/>
					</td>
				</tr>
            </table>
        </div>
        <div id="idDeleteWarning" style="color:red; display:none;"><a>Are you sure, all data will be cleared?</a></div>
		<div style="float:right;">
			<div class="button-container" >
			    <input id="idOKButton" type="button" class="epmliveButton" value="OK" onclick="customfieldDlg_event('ok');"/>
			    <input type="button" class="epmliveButton" value="Cancel" onclick="customfieldDlg_event('cancel');"/>
			</div>
		</div>
	</div>
</div>

<asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
<div id="idToolbarDiv"></div>
<dg1:DGridUserControl id="dgrid1" runat="server" />
</div>
<script type="text/javascript">
    var shortDlgHeight = 200;
    var tallDlgHeight = 350;
    var toobarData = {
        parent: "idToolbarDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", id: "btnTest", name: "TEST", img: "formatmap16x16_2.png", style: "top: -254px; left: -270px;", tooltip: "Test", onclick: "return toolbar_event('btnTest');" },
            { type: "button", id: "btnRefresh", name: "REFRESH", img: "refresh.png", tooltip: "Refresh", onclick: "return toolbar_event('btnRefresh');" },
            { type: "button", id: "btnCheck", name: "CHECK", img: "heart.gif", tooltip: "Check QueueManager Status", onclick: "return toolbar_event('btnCheck');" }
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
        toolbar.enableItem("btnModify");
        toolbar.enableItem("btnDelete");
    };

    var OnResize = function (event) {
        var top = dgrid1.GetTop();
        var newHeight = document.documentElement.clientHeight - top - 5;
        dgrid1.SetHeight(newHeight);
        var newWidth = document.documentElement.clientWidth - 5;
        dgrid1.SetWidth(newWidth);
    };
    
    function  DisplayDialog (left, top, width, height, title, idWindow, idAttachObj, bModal, bResize) {
        return jsf_displayDialog(thiswins, left, top, width, height, title, idWindow, idAttachObj, bModal, bResize);
    };
    
    function  SetDialogHeight(idWindow, newHeight) {
        var dimension = thiswins.window(idWindow).getDimension();
        thiswins.window(idWindow).setDimension(dimension[0], newHeight);
    };

    function CloseDialog (idWindow) {
        jsf_closeDialog(thiswins, idWindow)
    };

    function SendRequest(sXML) {
         sURL = "./QueueManager.ashx";
         return jsf_sendRequest(sURL, sXML);
    };

    function toolbar_event(event) {
        var sRowId = "";
        switch (event) {
            case "btnCheck":
                var sRequest = '<request function="QueueManagerRequest" context="CheckQMStatus"><data></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                    alert(json.reply.QMStatus.HeartbeatInfo);
                }
                break;
            case "btnTest":
                var sRequest = '<request function="QueueManagerRequest" context="QueueTestJob"><data></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                    __doPostBack('', '');
                }
                break;
            case "btnRefresh":
                __doPostBack('', '');
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
                sb.append(' FA_NAME="' + document.getElementById('txtName').value + '"');
                sb.append(' FA_DESC="' + document.getElementById('txtDesc').value + '"');
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
                        sb.append(' FA_NAME="' + document.getElementById('txtName').value + '"');
                        sb.append(' FA_DESC="' + document.getElementById('txtDesc').value + '"');
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
Queue Manager
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Queue Manager
</asp:Content>
