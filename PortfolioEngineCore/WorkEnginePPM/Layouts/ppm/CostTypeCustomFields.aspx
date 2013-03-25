<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register src="Tools/DGrid.ascx" tagname="DGridUserControl" tagprefix="dg1" %>
<%@ Register src="Tools/TGrid.ascx" tagname="TGridUserControl" tagprefix="tg1" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostTypeCustomFields.aspx.cs" Inherits="WorkEnginePPM.CostTypeCustomFields" DynamicMasterPageFile="~masterurl/default.master" %>
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
</style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
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
                        <label for="txtName">Name</label>
                    </td>
                    <td class="controlcell">
                        <input type="text" id="txtName" style="width:200px;" />
                    </td>
                </tr>
                <tr>
                    <td width="250" class="descriptioncell">
                        Lookup Table</td>
                    <td class="controlcell">
                        <select id="idLookups" style="width:206px;"  onchange="customfieldDlg_event('lookupChanged');"></select>
                   </td>
                </tr>
                <tr>
                    <td width="250" class="descriptioncell">
                        <label for="cbLeafOnly">Restrict selection to leaf entries</label>
                    </td>
                    <td class="controlcell">
                        <input type="checkbox" id="cbLeafOnly" />
                    </td>
                </tr>
                <tr>
                    <td width="250" class="descriptioncell">
                        <label for="cbUseFullName">Use Full Name</label>
                    </td>
                    <td class="controlcell">
                        <input type="checkbox" id="cbUseFullName" />
                    </td>
                </tr>
            </table>
		</div>
        <div style="display:block;"><tg1:TGridUserControl id="tgrid2" runat="server" /></div>
        <div id="idDeleteWarning" style="color:red; padding:10px; display:none;"><a>Are you sure, all data will be cleared?</a></div>
		<div style="float:right;">
			<div class="button-container" >
			    <input id="idOKButton" type="button" class="epmliveButton" value="OK" onclick="customfieldDlg_event('ok');"/>
			    <input type="button" class="epmliveButton" value="Cancel" onclick="customfieldDlg_event('cancel');"/>
			</div>
		</div>
	</div>
</div>
<div style="display:none;">
    <asp:ListBox ID="ddlLookups" runat="server"></asp:ListBox>
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
            { type: "button", id: "btnModify", name: "Modify", img: "addresource.gif", tooltip: "Modify", width: "80px", onclick: "toolbar_event('btnModify');", disabled: true },
            { type: "button", id: "btnDelete", name: "Delete", img: "delete.png", tooltip: "Delete", width: "80px", onclick: "return toolbar_event('btnDelete');", disabled: true }
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
        var name = dgrid1.GetCellValue(dgrid1_selectedRow, "FA_NAME");
        if (name != "")
            toolbar.enableItem("btnDelete");
        else
            toolbar.disableItem("btnDelete");
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

    function CloseDialog (idWindow) {
        jsf_closeDialog(thiswins, idWindow)
    };
    
    function SendRequest(sXML) {
        sURL = "./CostTypeCustomFields.ashx";
        return jsf_sendRequest(sURL, sXML);
    };

    function toolbar_event(event) {
        var sRowId = "";
        var $ = function (id) {return document.getElementById(id);}
        document.getElementById('idCustomfieldDlgMode').value = event;
        switch (event) {
            case "btnModify":
                 if (toolbar.isItemDisabled("btnModify") == true) {
                    alert("Select a row to enable the Modify button");
                    return false;
                }
                sRowId = dgrid1_selectedRow;
                var sRequest = '<request function="CostTypeCustomFieldsRequest" context="ReadCustomfieldInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                var customfield = json.reply.customfield;
                document.getElementById('txtId').value = customfield.FA_FIELD_ID;
                document.getElementById('txtName').value = jsf_getStringFromValue(customfield.FA_NAME);
                document.getElementById('txtName').disabled = false;
                var lookups = document.getElementById('idLookups');
                var ddlLookups = document.getElementById('<%=ddlLookups.ClientID%>');
                lookups.options.length = 0;
                lookups.options[lookups.options.length] = new Option("[None]", "0");
                for (var i = 0; i < ddlLookups.options.length; i++) {
                    var option = new Option(ddlLookups.options[i].text, ddlLookups.options[i].value);
                    lookups.options[lookups.options.length] = option
                    if (option.value == customfield.FA_LOOKUP_UID)
                        lookups.selectedIndex = lookups.options.length - 1;
                }
                document.getElementById('idLookups').disabled = false;
                document.getElementById('cbLeafOnly').checked = (customfield.FA_LEAFONLY == 1);
                document.getElementById('cbUseFullName').checked = (customfield.FA_USEFULLNAME == 1);
                var sId = lookups.options[lookups.selectedIndex].value;
                if (sId == null || sId == "0") {
                    document.getElementById('cbLeafOnly').disabled = true;
                    document.getElementById('cbUseFullName').disabled = true;
                }
                else {
                    document.getElementById('cbLeafOnly').disabled = false;
                    document.getElementById('cbUseFullName').disabled = false;
                }
                var tgrid2 = window['<%=tgrid2.UID%>'];
                tgrid2.Initialize(json.reply.customfield.tgridData);
                tgrid2.SetWidth(380);
                tgrid2.SetHeight(150);
                document.getElementById('idDeleteWarning').style.display = "none";
                document.getElementById('idOKButton').value = "Save";
                DisplayDialog(400, 420, "Modify Custom Field - " + dgrid1.GetCellValue(dgrid1_selectedRow, "FieldName"), "winCustomfieldDlg", "idCustomfieldDlg", true, false);
                break;
            case "btnDelete":
                if (toolbar.isItemDisabled("btnDelete") == true) {
                    alert("Select a valid row to enable the Delete button");
                    return false;
                }
                sRowId = dgrid1_selectedRow;
                var sRequest = '<request function="CostTypeCustomFieldsRequest" context="ReadCustomfieldInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                }
                var customfield = json.reply.customfield;
                document.getElementById('txtId').value = customfield.FA_FIELD_ID;
                document.getElementById('txtName').value = jsf_getStringFromValue(customfield.FA_NAME);
                document.getElementById('txtName').disabled = true;
                var lookups = document.getElementById('idLookups');
                var ddlLookups = document.getElementById('<%=ddlLookups.ClientID%>');
                lookups.options.length = 0;
                lookups.options[lookups.options.length] = new Option("[None]", "0");
                for (var i = 0; i < ddlLookups.options.length; i++) {
                    var option = new Option(ddlLookups.options[i].text, ddlLookups.options[i].value);
                    lookups.options[lookups.options.length] = option
                    if (option.value == customfield.FA_LOOKUP_UID)
                        lookups.selectedIndex = lookups.options.length - 1;
                }
                document.getElementById('idLookups').disabled = true;
                document.getElementById('cbLeafOnly').checked = (customfield.FA_LEAFONLY == 1);
                document.getElementById('cbLeafOnly').disabled = true;
                document.getElementById('cbUseFullName').disabled = true;
                document.getElementById('cbUseFullName').checked = (customfield.FA_USEFULLNAME == 1);
                var tgrid2 = window['<%=tgrid2.UID%>'];
                tgrid2.Initialize(json.reply.customfield.tgridData);
                tgrid2.SetWidth(380);
                tgrid2.SetHeight(150);
                document.getElementById('idDeleteWarning').style.display = "block";
                document.getElementById('idOKButton').value = "Delete";
                DisplayDialog(400, 440, "Delete Custom Field - " + dgrid1.GetCellValue(dgrid1_selectedRow, "FieldName"), "winCustomfieldDlg", "idCustomfieldDlg", true, false);
                break;
        }
        return false;
    };
    var customfieldDlg_event = function (event) {
       switch (event) {
            case "ok":
                var action = document.getElementById('idCustomfieldDlgMode').value;
                switch (action) {
                    case "btnModify":
                        var sRowId = dgrid1_selectedRow;
                        var sb = new StringBuilder();
                        sb.append('<request function="CostTypeCustomFieldsRequest" context="UpdateCustomfieldInfo">');
                        sb.append('<data');
                        sb.append(' FA_FIELD_ID="' + document.getElementById('txtId').value + '"');
                        sb.append(' FA_NAME="' + jsf_xml(document.getElementById('txtName').value) + '"');
                        sb.append(' FA_LOOKUP_UID="' + document.getElementById('idLookups').value + '"');
                        if (document.getElementById('cbLeafOnly').checked==true) {sb.append(' FA_LEAFONLY="1"');}  else {sb.append(' FA_LEAFONLY="0"');}
                        if (document.getElementById('cbUseFullName').checked==true) {sb.append(' FA_USEFULLNAME="1"');} else {sb.append(' FA_USEFULLNAME="0"');}
                        sb.append('/>');
                        sb.append('</request>');
                        var sRequest = sb.toString();
                        var jsonString = SendRequest(sRequest);
                        var json = JSON_ConvertString(jsonString);
                        if (json.reply != null) {
                            if (jsf_alertError(json.reply.error) == true)
                                return false;
                        }
                        dgrid1.SetCellValue(sRowId, "FA_NAME", json.reply.customfield.FA_NAME);
                        dgrid1.reapplySort();
                        dgrid1.selectRow(sRowId);
                        break;
                    case "btnDelete":
                        var sRowId = dgrid1_selectedRow;
                        var sb = new StringBuilder();
                        sb.append('<request function="CostTypeCustomFieldsRequest" context="DeleteCustomfieldInfo">');
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
                        dgrid1.SetCellValue(sRowId, "FA_NAME", "");
                        dgrid1_OnRowSelect(dgrid1_selectedRow);
                        break;
                }
                CloseDialog('winCustomfieldDlg');
                break;
            case "cancel":
                CloseDialog('winCustomfieldDlg');
                break;
            case "lookupChanged":
                var lookups = document.getElementById('idLookups');
                var sId = lookups.options[lookups.selectedIndex].value;
                if (sId == null) 
                    sId = "0";

                var sRequest = '<request function="CostTypeCustomFieldsRequest" context="ReadLookup"><data><![CDATA[' + sId + ']]></data></request>';
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                    if (sId == "0") {
                        document.getElementById('cbLeafOnly').checked = false;
                        document.getElementById('cbUseFullName').checked = false;
                        document.getElementById('cbLeafOnly').disabled = true;
                        document.getElementById('cbUseFullName').disabled = true;
                    }
                    else {
                        document.getElementById('cbLeafOnly').disabled = false;
                        document.getElementById('cbUseFullName').disabled = false;
                    }
                    var tgrid2 = window['<%=tgrid2.UID%>'];
                    tgrid2.Initialize(json.reply.customfield.tgridData);
                    tgrid2.SetWidth(380);
                    tgrid2.SetHeight(150);
                }
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
Cost Type Custom Fields
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Cost Type Custom Fields
</asp:Content>
