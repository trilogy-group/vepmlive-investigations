<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register src="Tools/TGrid.ascx" tagname="TGridUserControl" tagprefix="tg1" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rates_NAX.aspx.cs" Inherits="WorkEnginePPM.Rates_NAX" DynamicMasterPageFile="~masterurl/default.master" %>
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
    <tg1:TGridUserControl id="tgridRates" runat="server" />
	<div style="float:right;">
		<div class="button-container" >
			<input id="Button1" type="button" class="epmliveButton" value="OK" onclick="ratesDlg_event('ok');"/>
			<input type="button" class="epmliveButton" value="Cancel" onclick="ratesDlg_event('cancel');"/>
		</div>
	</div>
</div>
<div class="modalContent" id="idResourcesDlg" style="display:none;">
    <div style="width:380px; display:block; padding-top: 0px; padding-bottom: 10px;">
        <table cellpadding="5">
            <tr>
                <td colspan="3" class="descriptioncell">
                    Select the resources to be associated with this rate:</td>
            </tr>
            <tr>
                <td class="descriptioncell">
                    Available Resources:<br />
					<select name="FrmFieldsOut" size="7" id="idResourcesOut" style="width: 150px; padding: 3px;" ondblclick="javascript:resourcesDlg_event('include');" >
					</select>
                </td>
                <td>
                    <input type="button" class="epmliveSmallButton"  value="&gt; " onclick="javascript:resourcesDlg_event('include');" /><br /><br />
                    <input type="button" class="epmliveSmallButton" value="&lt; " onclick="javascript:resourcesDlg_event('exclude');"/>
                </td>
                <td class="descriptioncell">
                    Resources with this rate:<br />
					<select name="FrmFieldsIn" size="7" id="idResourcesIn" style="width: 150px; padding: 3px;" ondblclick="javascript:resourcesDlg_event('exclude');" >
					</select>
                </td>
            </tr>
        </table>
    </div>
	<div style="float:right;">
		<div class="button-container" >
			<input id="Button2" type="button" class="epmliveButton" value="OK" onclick="resourcesDlg_event('ok');"/>
			<input type="button" class="epmliveButton" value="Cancel" onclick="resourcesDlg_event('cancel');"/>
		</div>
	</div>
</div>
<div style="display:none;">
    <asp:ListBox ID="ddlResources" runat="server"></asp:ListBox>
</div>
<div style="display: block;" >
    <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
    <div id="idToolbarDiv"></div>
    <div style="display:block;"><tg1:TGridUserControl id="tgrid1" runat="server" /></div>
</div>
<script type="text/javascript">
    var toobarData = {
        parent: "idToolbarDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", id: "btnSave", name: "SAVE", img: "formatmap16x16_2.png", style: "top: -127px; left: -91px;", tooltip: "Save",  onclick: "toolbar_event('btnSave');" },
            { type: "button", id: "btnAdd", name: "ADD", img: "formatmap16x16_2.png", style: "top: -90px; left: -216px;", tooltip: "Add a new rate type", onclick: "toolbar_event('btnAdd');" },
            { type: "button", id: "btnEdit", name: "MODIFY", img: "formatmap16x16_2.png", style: "top: -90px; left: -216px;", tooltip: "Edit the selected rate type", onclick: "toolbar_event('btnEdit');", disabled: true },
            { type: "button", id: "btnDelete", name: "DELETE", img: "formatmap16x16_2.png", style: "top: -270px; left: -270px;", tooltip: "Delete the selected rate type",  onclick: "return toolbar_event('btnDelete');", disabled: true },
            { type: "button", id: "btnResources", name: "RESOURCES", img: "formatmap16x16_2.png", style: "top: -250px; left: -36px;", tooltip: "Edit resources associated with selected rate type",  onclick: "return toolbar_event('btnResources');", disabled: true }
        ]
    };
    var toolbarRatesData = {
        parent: "idToolbarRatesDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", name: "ADD", img: "addresource.gif", tooltip: "Add rate", width: "80px", onclick: "ratesDlg_event('btnAdd2');" },
            { type: "button", id: "btnInsert2", name: "INSERT", img: "editview.gif", tooltip: "Insert rate", width: "80px", onclick: "return ratesDlg_event('btnInsert2');", disabled: true },
            { type: "button", id: "btnDelete2", name: "DELETE", img: "delete.png", tooltip: "Delete rate", width: "80px", onclick: "return ratesDlg_event('btnDelete2');", disabled: true }
        ]
    };

    var toolbar = new Toolbar(toobarData);
    toolbar.Render();
    var toolbarRates = new Toolbar(toolbarRatesData);
    var tgrid1_selectedRow = 0;
    var tgridRates_selectedRow = 0;
    var tgridFTEs_selectedRow = 0;
    var tgrid1 = window.<%=tgrid1.UID%>;
    var tgridRates = window['<%=tgridRates.UID%>'];
    var bSaving = false;
 
    var OnLoad = function (event) {
        Grids.OnFocus = GridsOnFocus;
        tgrid1_selectedRow = 0;
        OnResize();
    };
    var OnBeforeUnload = function (event) {
        if (HasChanges() && bSaving == false)
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
                if (row != null) {
                    toolbar.enableItem("btnEdit");
                    toolbar.enableItem("btnDelete");
                    toolbar.enableItem("btnResources");
                }
                else {
                    toolbar.disableItem("btnEdit");
                    toolbar.disableItem("btnDelete");
                    toolbar.disableItem("btnResources");
                }
                break;
            case tgridRates.id:
                tgridRates_selectedRow = row;
                toolbarRates.enableItem("btnInsert2");
                toolbarRates.enableItem("btnDelete2");
                break;
        }
    };
    var OnResize = function (event) {
        var lefttop = tgrid1.GetLeftTopPositions();
        var newHeight = document.documentElement.clientHeight - lefttop[1] - 18;
        var newWidth = document.documentElement.clientWidth - lefttop[0] - 23;
        tgrid1.SetSizes(newWidth,newHeight);
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
         sURL = "./Rates.ashx";
         return jsf_sendRequest(sURL, sXML);
    };
    function BuildSaveRatesInfo() {
        var sb = new StringBuilder("");
        sb.append('<data');
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
        if (toolbar.isItemDisabled(event) == true)
            return;
        tgrid1.EndEdit();
        switch (event) {
            case "btnAdd":
                var newrow = tgrid1.grid.AddRow(null, null, true);
                tgrid1.SetCellValue(newrow, "RT_NAME", "New Rate");
                tgrid1.grid.SetAttribute(newrow, null, "wres_ids", "", 1, 0);
                tgrid1.grid.SetAttribute(newrow, null, "rates", "", 1, 0);
                break;
            case "btnSave":
                var sData = BuildSaveRatesInfo();
                var sb = new StringBuilder();
                sb.append('<request function="RatesRequest" context="SaveRatesInfo">');
                sb.append(sData);
                sb.append('</request>'); 
                var sRequest = sb.toString();
                var jsonString = SendRequest(sRequest);
                var json = JSON_ConvertString(jsonString);
                if (json.reply != null) {
                    if (jsf_alertError(json.reply.error) == true)
                        return false;
                    bSaving = true;
                    __doPostBack('', '');
                }
                break;
            case "btnDelete":
                var firstrow = tgrid1_selectedRow;
                var lastrow = tgrid1_selectedRow;
                var childrow = tgrid1_selectedRow.firstChild;

                var sb = new StringBuilder("");
                if (childrow != null) {
                    sb.appendLine("WARNING!");
                    sb.appendLine("");
                    sb.appendLine("All child rows of the selected named rate will also be deleted");
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
            case "btnEdit":
                if (tgrid1_selectedRow != null) {
                    var grid = tgrid1.grid;
                    //var wresids = "," + grid.GetAttribute(tgrid1_selectedRow, "wres_ids", null).toString() + ",";
                    var ratePairsArr = grid.GetAttribute(tgrid1_selectedRow, "rates", null).split(",");
                    tgridRates.Initialize(null); // reset grid data
                    var txtBaseRate = document.getElementById('txtBaseRate');
                    txtBaseRate.value = "";
                    for (var i = 0; i < ratePairsArr.length; i++) {
                        var dateAndRateArr = ratePairsArr[i].split("::");
                        if (dateAndRateArr.length == 2) {
                            if (dateAndRateArr[0] == "1899.12.30") {
                                tgridRates.grid.SetAttribute(row, null, "BC_EFFECTIVE_DATE", "", 1, 0);
                                txtBaseRate.value = NumberToString(parseFloat(dateAndRateArr[1]), "0.00");
                            } else {
                                var row = tgridRates.AddRow();
                                var dt = StringToDate(dateAndRateArr[0], "yyyy.MM.dd");
                                tgridRates.grid.SetAttribute(row, null, "BC_EFFECTIVE_DATE", dt, 1, 0);
                                tgridRates.grid.SetAttribute(row, null, "BC_RATE", NumberToString(parseFloat(dateAndRateArr[1]), "0.00") , 1, 0);
                            }
                       }
                    }

                    tgridRates.SetWidth(390);
                    tgridRates.SetHeight(150);
                    toolbarRates.Render();
                    var s = "Modify rates for " + grid.GetAttribute(tgrid1_selectedRow, "RT_NAME", null);
                    tgridRates_selectedRow = 0;
                    DisplayDialog(420, 380, s, "winRatesDlg", "idRatesDlg", true, false);
                }
                break;
            case "btnResources":
                if (tgrid1_selectedRow != null) {
                    var grid = tgrid1.grid;
                    var wresids = "," + grid.GetAttribute(tgrid1_selectedRow, "wres_ids", null).toString() + ",";

                    var s = "Add resources to rate " + grid.GetAttribute(tgrid1_selectedRow, "RT_NAME", null);
                    tgridRates_selectedRow = 0;
                    var idResourcesOut = document.getElementById('idResourcesOut');
                    idResourcesOut.options.length = 0;
                    var idResourcesIn = document.getElementById('idResourcesIn');
                    idResourcesIn.options.length = 0;
                    var ddlResources = document.getElementById('<%=ddlResources.ClientID%>');
                    for (var i = 0; i < ddlResources.options.length; i++) {
                        var wresid = ddlResources.options[i].value;
                        var resname = ddlResources.options[i].text;
                        var name = BuildResourceName(wresid,resname,tgrid1_selectedRow);
                        var option = new Option(name, wresid);
                        if (wresids.indexOf("," + wresid + ",") > -1)
                            idResourcesIn.options[idResourcesIn.options.length] = option;
                        else
                            idResourcesOut.options[idResourcesOut.options.length] = option;
                    }
                    DisplayDialog(420, 300, s, "winResourcesDlg", "idResourcesDlg", true, false);
                }
                break;
        }
        return false;
    };
    function BuildResourceName(wresid, resname, ignorethisrow) {
        var grid = tgrid1.grid;
        var row = grid.GetFirst(null);
        while (row != null) {
            if (row.id != ignorethisrow.id) {
                var wresids = "," + grid.GetAttribute(row, "wres_ids", null).toString() + ",";
                if (wresids.indexOf("," + wresid + ",") > -1) {
                    return resname + "(*)";
                }
            }
            row = grid.GetNext(row);
        }
        return resname;
    };
    function GetResourceRateName(wresid) {
        var grid = tgrid1.grid;
        var row = grid.GetFirst(null);
        while (row != null) {
            var wresids = "," + grid.GetAttribute(row, "wres_ids", null).toString() + ",";
            if (wresids.indexOf("," + wresid + ",") > -1) {
                return grid.GetAttribute(row, "RT_NAME", null).toString();
            }
            row = grid.GetNext(row);
        }
        return "";
    };
    function ratesDlg_event(event) {
        switch (event) {
            case "ok":
                tgridRates.EndEdit();
                var rates = "1899.12.30::" + txtBaseRate.value;
                var row = tgridRates.grid.GetFirst();
                while (row != null) {
                    var deleted = tgridRates.grid.GetAttribute(row, null, "Deleted");
                    if (deleted != 1) {
                        var date = DateToString(tgridRates.grid.GetAttribute(row, "BC_EFFECTIVE_DATE", null), "yyyy.MM.dd");
                        var rate = date + "::" + tgridRates.grid.GetAttribute(row, "BC_RATE", null).toString();
                        if (rates != "")
                            rates += ",";
                        rates += rate;
                    }
                    row = tgridRates.grid.GetNext(row);
                }
                tgrid1.grid.SetAttribute(tgrid1_selectedRow, null, "rates", rates, 1, 0);
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
    function resourcesDlg_event(event) {
        switch (event) {
            case "include":
                var selected = $("#idResourcesOut option:selected").get(0);
                if (selected != null) {
                    var nindex = selected.text.indexOf("(*)");
                    if (nindex > -1) {
                        var resname = selected.text.substr(0,nindex);
                        var srate = GetResourceRateName(selected.value);
                        var b = window.confirm(resname + " is currently assigned rate " + srate + ".\n\nAre you sure you want to change rate to " + tgrid1.grid.GetAttribute(tgrid1_selectedRow, "RT_NAME", null) + "?");
                        if (b == false)
                            return;
                    }
                }
                $("#idResourcesOut option:selected").appendTo("#idResourcesIn");
                break;
            case "exclude":
                $("#idResourcesIn option:selected").appendTo("#idResourcesOut");
                break;
            case "ok":
                var idResourcesIn = document.getElementById('idResourcesIn');
                for (var i = 0; i < idResourcesIn.options.length; i++) {
                    var resname = idResourcesIn.options[i].text;
                    var nindex = resname.indexOf("(*)");
                    if (nindex > -1) {
                        resname = "," + resname.substr(0,nindex) + ",";
                        var wresid = "," + idResourcesIn.options[i].value + ",";
                        var row = tgrid1.grid.GetFirst();
                        while (row != null) {
                            var wresids = "," + tgrid1.grid.GetAttribute(row, null, "wres_ids") + ",";
                            var resnames = "," + tgrid1.grid.GetAttribute(row, null, "res_names") + ",";
                            wresids = wresids.replace(wresid, ",");
                            resnames = resnames.replace(resname, ",");
                            tgrid1.grid.SetAttribute(row, "wres_ids", null, wresids.replace(/(^,)|(,$)/g, ""), 1, 0);
                            tgrid1.grid.SetAttribute(row, "res_names", null, resnames.replace(/(^,)|(,$)/g, ""), 1, 0);
                            row = tgrid1.grid.GetNext(row);
                        }
                    }
                }
                var wresids = "";
                var resnames = "";
                for (var i = 0; i < idResourcesIn.options.length; i++) {
                    if (wresids != "")
                        wresids += ",";  
                    wresids += idResourcesIn.options[i].value;
                    if (resnames != "")
                        resnames += ",";
                    var resname = idResourcesIn.options[i].text;
                    var nindex = resname.indexOf("(*)");
                    if (nindex > -1) {
                        resname = resname.substr(0,nindex);
                    }
                    resnames += resname;
                }
                tgrid1.grid.SetAttribute(tgrid1_selectedRow, "wres_ids", null, wresids, 1, 0);
                tgrid1.grid.SetAttribute(tgrid1_selectedRow, "res_names", null, resnames, 1, 0);
                CloseDialog('winResourcesDlg');
                break;
            case "cancel":
                CloseDialog('winResourcesDlg');
                break;
        }
        return false;
    };
    var thiswins = new dhtmlXWindows();
    thiswins.setImagePath("/_layouts/ppm/images/");
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
Rates
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Rates
</asp:Content>
