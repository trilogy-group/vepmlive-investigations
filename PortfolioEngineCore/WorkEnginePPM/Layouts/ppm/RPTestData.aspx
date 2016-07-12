<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPTestData.aspx.cs" Inherits="WorkEnginePPM.RPTestData" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Reference Control="/_layouts/ppm/RPEditor.ascx" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">

<style type="text/css">
    .ms-dialog .ms-bodyareacell {
    padding: 0 !important;
}
</style>
<script src="tools/jsfunctions.js" type="text/javascript"></script>
<script src="general.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="/_layouts/ppm/ribbon/ribbon2.css" />
<script src="/_layouts/ppm/ribbon/ribbon2.js" type="text/javascript"></script>

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
<div class="modalContent" id="idAllocatePeriodValuesDlgObj" style="display:none;">
	<div class="modalText" style="margin-top:5px;padding-right:10px;">
	    <div>
            <div>
                <table>
                    <tr>
                    <td>Amount&nbsp;:</td>
                    <td class="datacol">
                    <table>
                    <tr>
                    <td><input id="idAPVAmount" type="text" value="100" style="width:2.5em; text-align:right;" />&nbsp;<label for="idAPVAmount" id="idAPVUnits">Hours</label></td>
                    </tr>
                    </table>
                    </td>
                    </tr>
                    <tr>
                    <td valign="top">Action&nbsp;:&nbsp;</td>
                    <td class="datacol">
                    <table>
                    <tr><td><input id="idAPVCopy" type="radio" name="APVaction" checked="checked" class="actionRadio" style="margin:0px;padding:0px;" /><label  for="idAPVCopy">Copy</label></td></tr>
                    <tr><td><input id="idAPVSpread" type="radio" name="APVaction" class="actionRadio" style="margin:0px;padding:0px;" /><label for="idAPVSpread">Spread</label></td></tr>
                    </table>
                    </td>
                    </tr>
                </table>
            </div>
            <div>
                <table width="100%" style="margin-top:10px;">
                <tr>
                <td>Start Period:<br /><select id="idAPVStartPeriod" name="D1" style="margin:3px 0px 0px 0px;padding:0px;"></select></td>
                <td>Finish Period:<br /><select id="idAPVFinishPeriod" name="D1" style="margin:3px 0px 0px 0px;padding:0px;"></select></td>
                </tr>
                <tr style="margin-top:10px;">
                    <td colspan="2"><input type="checkbox" style="margin:10px 8px 0px 0px;padding:0px;" id="idAPVClearPeriods"><span style="vertical-align:bottom;">Clear other Periods</span></td>
                </tr>
                </table>
            </div>
        </div>
	    <div style="width:200px;float:right;">
		    <div class="button-container" style="margin-top:18px;">
        	    <a onclick="javascript:toolbar_event('idAllocatePeriodValuesDlgObj_Apply');" class="button-new green" style="width:75px;">Apply</a>
        	    <a onclick="javascript:toolbar_event('idAllocatePeriodValuesDlgObj_Close');" class="button-new silver" style="width:75px;">Close</a>
		    </div>
	    </div>
    </div>
</div>
<div class="modalContent" id="idSavePlanAsDlgObj" style="display:none;">
	<div class="modalText" style="margin-top:5px;padding-right:10px;">
	    <div>
            <div>
                <table>
                    <tr>
                    <td valign="top">PIs&nbsp;:</td>
                    <td class="datacol">
                    <asp:ListBox ID="lstSaveAsPIs" runat="server" SelectionMode="Multiple" Height="140" Width="210" ></asp:ListBox>
                    </td>
                    </tr>
                </table>
            </div>
        </div>
	    <div style="width:200px;float:right;">
		    <div class="button-container" style="margin-top:18px;">
        	    <a onclick="javascript:toolbar_event('btnSavePlanAs_Save');" class="button-new green" style="width:75px;">Save</a>
        	    <a onclick="javascript:toolbar_event('btnSavePlanAs_Close');" class="button-new silver" style="width:75px;">Close</a>
		    </div>
	    </div>
    </div>
</div>
	<div style="margin-top:5px;margin-bottom:5px;padding-left:3px;padding-right:3px;">
		<div style="padding-bottom:3px;">
            <table cellspacing="0">
                <tr>
                    <td>Select a PI&nbsp;:&nbsp;</td>
                    <td style="min-width:300px;">
                        <asp:DropDownList ID="ddlPIs" style="min-width:300px;" runat="server"></asp:DropDownList>
                    </td>
                    <td><asp:Button ID="btnGo" OnClick="btnGo_Click" runat="server" Text="Go" /></td>
                    <td><div id="idtestdiv" style="width:100%;"><a id="lblMessage"></a></div></td>
                </tr>
            </table>
		</div>
    </div>
    <div id="idTestTabDiv"></div>
    <asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
    <asp:PlaceHolder runat="server" ID="PlaceHolder1" />
<script type="text/javascript">
    var testTab;
    var resrows;
    var resrowsindex;
    var planrows;
    var planrowsindex;
    var OnLoad = function (event) {
        window.setTimeout("waitforcontrolloaded();", 1000);
    };
    function waitforcontrolloaded() {
        try {
            if (rpeditor == null || rpeditor.initialized == false) {
                window.setTimeout("waitforcontrolloaded();", 1000);
                return;
            }
            var testTabData = {
                parent: "idTestTabDiv",
                style: "display:none;",
                showstate: "true",
                initialstate: "expanded",
                onstatechange: "dialogEvent('PlanRibbon_Toggle');",
                imagePath: rpeditor.imagePath,
                sections: [
                    {
                        name: "Plan Rows",
                        tooltip: "Plan Rows",
                        columns: [
                            {
                                items: [
                                    { type: "bigbutton", id: "btnSavePlanAs", name: "Save As", img: "save32x32.png", tooltip: "Save As", onclick: "toolbar_event('btnSavePlanAs');", disabled: false }
                                ]
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "btnDeleteAllPlanRows", name: "Delete All", img: "formatmap16x16_2.png", style: "top: -270px; left: -270px;", tooltip: "Delete All", onclick: "return toolbar_event('btnDeleteAllPlanRows');" },
                                    { type: "smallbutton", id: "btnAddSelectedResourcesToPlan", name: "Add Resources", img: "formatmap16x16_2.png", style: "top: -90px; left: -216px;", tooltip: "Add", onclick: "toolbar_event('btnAddSelectedResourcesToPlan');" },
                                    { type: "smallbutton", id: "btnAllocateHours", name: "Allocate Hours", img: "formatmap16x16_2.png", style: "top: -90px; left: -216px;", tooltip: "Allocate Hours", onclick: "toolbar_event('btnAllocateHours');" }
                                ]
                            }
                        ]
                    },
                    {
                        name: "Resource Rows",
                        tooltip: "Resource Rows",
                        columns: [
                            {
                                items: [
                                    { type: "smallbutton", id: "btnSelectAllResourceRows", name: "Select All", img: "formatmap16x16_2.png", style: "top: -90px; left: -216px;", tooltip: "Add", onclick: "toolbar_event('btnSelectAllResourceRows');" }
                                ]
                            }
                        ]
                    }
                ]
            };
            testTab = new Ribbon(testTabData);
            testTab.Render();
            rpeditor.planTabbar.addTab("tab_Test", "Test", 70);
            rpeditor.planTabbar.setContent("tab_Test", testTab.getRibbonDiv());
            rpeditor.planTabbar.setTabActive("tab_Test");
            rpeditor.UpdateButtonsAsync();
            rpeditor.OnResizeInternal();
        }
        catch (e) {
            //this.HandleException("GridsOnReady", e);
        }
    };
    function toolbar_event(event) {
        switch (event) {
            case "btnDeleteAllPlanRows":
                var plangrid = rpeditor.plangrid;
                var planrow = GetFirstProjectRow();
                if (plangrid != null && planrow != null) {
                    var b = window.confirm("This action will delete all the rows in the plan.\n\nAre you sure?\n\nAny row values will be deleted on save.");
                    if (b) {
                        var row = planrow.firstChild;
                        while (row != null) {
                            plangrid.DeleteRow(row, 2); // 1=okmsg+del; 2=del; 3=undel
                            row = row.nextSibling;
                        }
                        rpeditor.UpdateButtonsAsync();
                    }
                }
                break;
            case "btnSelectAllResourceRows":
                var resgrid = rpeditor.resgrid;
                resgrid.SelectAllRows(1);
                break;
            case "btnAddSelectedResourcesToPlan":
                var resgrid = rpeditor.resgrid;
                resrows = resgrid.GetSelRows();
                resrowsindex = 0;
                var plangrid = rpeditor.plangrid;
                plangrid.ActionFilterOff();
                plangrid.ActionGroupOff();
                plangrid.Rendering = true;
                window.setTimeout("ProcessRows();", 1);
                break;
            case "btnSavePlanAs":
                var dlg = rpeditor.wins.window("winSavePlanAsDlg");
                if (dlg == null) {
                    rpeditor.DisplayDialog(20, 30, 275, 245, "Save Plan As", "winSavePlanAsDlg", "idSavePlanAsDlgObj", false, false);
                }
                else {
                    dlg.show();
                }
                break;
            case "btnSavePlanAs_Save":
                ProcessSaveAs();
//                var lstSaveAsPIs = document.getElementById('<%=lstSaveAsPIs.ClientID%>');
//                var lblMessage = document.getElementById("lblMessage");
//                for (var i = 0; i < lstSaveAsPIs.options.length; i++) {
//                    if (lstSaveAsPIs.options[i].selected) {
//                        //alert(lstSaveAsPIs.options[i].text + "(" + lstSaveAsPIs.options[i].value +")");
//                        lblMessage.innerHTML = "Assigning new plan guids for PI " + lstSaveAsPIs.options[i].text;
//                        SavePlanAs(lstSaveAsPIs.options[i].value, lstSaveAsPIs.options[i].text);
//                        if (rpeditor.CheckPlanOKToSave() == true) {
//                            lblMessage.innerHTML = "Saving Plan to PI " + lstSaveAsPIs.options[i].text;
//                            rpeditor.SavePlan(false);
//                            lblMessage.innerHTML = "Plan saved to PI " + lstSaveAsPIs.options[i].text;
//                        }
//                    }
//                }
//                lblMessage.innerHTML = "Save As Completed";
//                alert("Please refresh page before making further changes");
                break;
            case "btnSavePlanAs_Close":
                rpeditor.wins.window("winSavePlanAsDlg").hide();
                break;
            case "btnAllocateHours":
                var dlg = rpeditor.wins.window("winAPVDlg");
                if (dlg == null) {
                    rpeditor.DisplayDialog(20, 30, 275, 245, "Allocate Values", "winAPVDlg", "idAllocatePeriodValuesDlgObj", false, false);
                    idAllocatePeriodValuesDlgObj_LoadData(true);
                    document.getElementById("idSpreadAmount").select();
                }
                else {
                    idAllocatePeriodValuesDlgObj_LoadData(false);
                    dlg.show();
                    document.getElementById("idSpreadAmount").select();
                }
                break;
            case "idAllocatePeriodValuesDlgObj_Apply":
                var plangrid = rpeditor.plangrid; 
                planrows = GetAllCommitmentRows(); 
                planrowsindex = 0; 
                var amount = document.getElementById("idAPVAmount").value; 
                if (isNaN(amount)) { 
                    alert("Amount : '" + amount + "' is not a number"); 
                    return; 
                }
                var select = document.getElementById("idAPVStartPeriod"); 
                var startPeriod = select.options[select.selectedIndex].value;
                select = document.getElementById("idAPVFinishPeriod"); 
                var finishPeriod = select.options[select.selectedIndex].value;
                var lStartPeriod = parseInt(startPeriod.substring(1));
                var lFinishPeriod = parseInt(finishPeriod.substring(1));
                var copy = document.getElementById("idAPVCopy").checked; 
                var clearPeriods = document.getElementById("idAPVClearPeriods").checked; 
                plangrid.ActionFilterOff(); 
                plangrid.ActionGroupOff(); 
                plangrid.Rendering = true;
                ProcessAllocateHoursRows(amount, lStartPeriod, lFinishPeriod, copy, clearPeriods); 
                break;
            case "idAllocatePeriodValuesDlgObj_Close":
                rpeditor.wins.window("winAPVDlg").hide();
                break;
        }
    };

    idAllocatePeriodValuesDlgObj_LoadData = function (init) {
        var sUnits = "";
        var sValue = "";
        switch (rpeditor.displayMode) {
            case 0: /* Hours */
                sUnits = "Hours";
                sValue = "100";
                break;
            case 1: /* FTE */
                sUnits = "FTE";
                sValue = "1";
                break;
            case 2: /* FTE %*/
                sUnits = "FTE%";
                sValue = "100";
                break;
        }

        var dlg = rpeditor.wins.window("winAPVDlg");
        if (dlg != null) {
            dlg.setText("Allocate " + sUnits);
        }

        var units = document.getElementById('idAPVUnits');
        units.innerHTML = sUnits;
        if (init == true) {
            var from = document.getElementById('idAPVStartPeriod');
            from.options.length = 0;
            from.options.selectedIndex = -1;
            var to = document.getElementById('idAPVFinishPeriod');
            to.options.length = 0;
            to.options.selectedIndex = -1;
            var n = 0;
            var grid = rpeditor.plangrid;
            for (var c = 0; c < grid.ColNames[2].length; c++) {
                var col = grid.ColNames[2][c];
                var sType = col.substring(0, 1);
                if (sType == "Q") {
                    var sPeriod = grid.GetCaption(col);
                    var id = parseInt(col.substring(1));
                    from.options[n] = new Option(sPeriod, col);
                    if (id == rpeditor.startPeriod) from.options.selectedIndex = n;
                    to.options[n] = new Option(sPeriod, col);
                    if (id == rpeditor.finishPeriod) to.options.selectedIndex = n;
                }
                n++;
            }
            dlg.show();
            document.getElementById("idAPVAmount").value = sValue;
        }
    };
    function ProcessSaveAs() {
        if (rpeditor.savingPlan == true) {
            window.setTimeout("ProcessSaveAs();", 100);
            return;
        }

        var lstSaveAsPIs = document.getElementById('<%=lstSaveAsPIs.ClientID%>');
        var lblMessage = document.getElementById("lblMessage");
        for (var i = 0; i < lstSaveAsPIs.options.length; i++) {
            if (lstSaveAsPIs.options[i].selected) {
                lstSaveAsPIs.options[i].selected = false;
                lblMessage.innerHTML = "Saving Resource Plan to PI " + lstSaveAsPIs.options[i].text + "...";
                SavePlanAs(lstSaveAsPIs.options[i].value, lstSaveAsPIs.options[i].text);
                if (rpeditor.CheckPlanOKToSave() == true) {
                    rpeditor.SavePlan(false);
                }
                window.setTimeout("ProcessSaveAs();", 100);
                return;
            }
        }
        lblMessage.innerHTML = "Save Complete - please refresh page.";
        alert("Please refresh page before making further changes");
    };
    function SavePlanAs(projectid, piname) {
        var grid = Grids["g_RPE"];
        // build up a list of replacement guids
        var guids = [];
        var row = grid.GetFirst(null, 0);
        while (row != null) {
            var sguid = grid.GetAttribute(row, null, "GUID");
            if (sguid != null && sguid.length == 36) {
                var guid = guids[sguid];
                if (guid == null) {
                    guid = new Guid();
                    guids[sguid] = guid.newGuid();
                }
            }
            sguid = grid.GetAttribute(row, null, "Group");
            if (sguid != null && sguid.length > 0) {
                var guid = guids[sguid];
                if (guid == null) {
                    guid = new Guid();
                    guids[sguid] = guid.newGuid();
                }
            }
            row = grid.GetNext(row);
        }
        // now have a list of guid replacements
        row = grid.GetFirst(null, 0);
        while (row != null) {
            var sguid = grid.GetAttribute(row, null, "GUID");
            if (sguid != null && sguid.length == 36) {
                var guid = guids[sguid];
                if (guid == null) {
                    alert("guid not found");
                } else {
                    grid.SetAttribute(row, null, "GUID", guid, 0, 0);
                }
            }
            sguid = grid.GetAttribute(row, null, "Group");
            if (sguid != null && sguid.length > 0) {
                var guid = guids[sguid];
                if (guid == null) {
                    alert("group id not found " + sguid);
                } else {
                    grid.SetAttribute(row, null, "Group", guid, 0, 0);
                }
            }
            sguid = grid.GetAttribute(row, null, "sfRPEGroup");
            if (sguid != null && sguid.length > 0) {
                var guid = guids[sguid];
                if (guid == null) {
                    alert("sfRPEGroup id not found " + sguid);
                } else {
                    grid.SetAttribute(row, null, "sfRPEGroup", guid, 0, 0);
                }
            }
            grid.SetAttribute(row, null, "Project_UID", projectid, 0, 0);
            var name = grid.GetAttribute(row, null, "PROJECT_NAME");
            if (name != null)
                grid.SetAttribute(row, null, "PROJECT_NAME", piname, 0, 0);
            var uid = grid.GetAttribute(row, null, "UID");
            if (uid != null)
                grid.SetAttribute(row, null, "UID", 0, 0, 0);
            grid.SetAttribute(row, null, "Changed", 1, 0, 0);
            var status = grid.GetAttribute(row, null, "Status");
            var const_Project = 0;
            if (status == const_Project)
                grid.SetAttribute(row, null, "DeleteExistingPlan", 1, 0, 0);
            else
                grid.SetAttribute(row, null, "Added", 1, 0, 0);
            row = grid.GetNext(row);
        }
        //rpeditor.UpdateButtonsAsync();
    };
    function ProcessRows() {
        var rows = [];
        var planrow = GetFirstProjectRow();
        var lblMessage = document.getElementById("lblMessage");
        if (resrowsindex < resrows.length) {
            for (var i = resrowsindex; i < resrows.length; i++) {
                if (rows.length >= 10) {
                    lblMessage.innerHTML = i + " rows of " + resrows.length + " added";
                    rpeditor.AddRowsToProject(rows, planrow, false);
                    resrowsindex = i;
                    window.setTimeout("ProcessRows();", 1);
                    return;
                }
                var resrow = resrows[i];
                if (resrow.Kind === 'Data')
                    rows[rows.length++] = resrow;
            }
            if (rows.length > 0) {
                rpeditor.AddRowsToProject(rows, planrow, false);
                lblMessage.innerHTML = "Rendering grid ...";
                resrowsindex = i;
                window.setTimeout("ProcessRows();", 1);
            }
        } else {
            var plangrid = rpeditor.plangrid;
            plangrid.Rendering = false;
            plangrid.ActionFilterOn();
            plangrid.ActionGroupOn();
            plangrid.RenderBody();
            rpeditor.UpdateButtonsAsync();
            lblMessage.innerHTML = "Process complete " + resrows.length + " added";
        }
    };
    function ProcessAllocateHoursRows(amount, startPeriod, finishPeriod, copy, clearPeriods) {
        //var planrow = GetFirstProjectRow();
        var lblMessage = document.getElementById("lblMessage");
        var count = 0;
        var plangrid = rpeditor.plangrid;
        if (planrowsindex < planrows.length) {
            for (var i = planrowsindex; i < planrows.length; i++) {
                var planrow = planrows[i];
                var deleted = plangrid.GetAttribute(planrow, null, "Deleted");
                if (deleted != 1) {
                    ApplyPlanrowPeriodValues(planrows[i], amount, startPeriod, finishPeriod, copy, clearPeriods);
                    count++;
                    if (count >= 10) {
                        lblMessage.innerHTML = i + " rows of " + planrows.length + " updated";
                        planrowsindex = i;
                        window.setTimeout("ProcessAllocateHoursRows(" + amount + "," + startPeriod + "," + finishPeriod + "," + copy + "," + clearPeriods + ");", 1);
                        return;
                    }
                }
            }
            if (count > 0) {
                lblMessage.innerHTML = "Rendering grid ...";
                planrowsindex = i;
                window.setTimeout("ProcessAllocateHoursRows(" + amount + "," + startPeriod + "," + finishPeriod + "," + copy + "," + clearPeriods + ");", 1);
            }
        } else {
            plangrid.Rendering = false;
            plangrid.ActionFilterOn();
            plangrid.ActionGroupOn();
            plangrid.RenderBody();
            rpeditor.RefreshResourcePeriods();
            rpeditor.UpdateButtonsAsync();
            rpeditor.RefreshGrid(rpeditor.resgrid);
            lblMessage.innerHTML = "Process complete - planrows updated";
        }
    };
    function ApplyPlanrowPeriodValues(row, amount, startPeriod, finishPeriod, copy, clearPeriods) {
        var grid = rpeditor.plangrid;
        var const_Project = 0;
        var val = amount;
        if (row != null) {
            var status = grid.GetAttribute(row, null, "Status");
            if (status == const_Project) {
                alert("Values cannot be allocated to a project row");
                return;
            }

            var jValue = null;
            var mpy = 100;
            switch (rpeditor.displayMode) {
                case 0: /* Hours */
                    jValue = ValidateStringAsNumber(val, 10, 2, false, "");
                    break;
                case 1: /* FTE */
                    jValue = ValidateStringAsNumber(val, 5, 2, false, "");
                    mpy = 10000;
                    break;
                case 2: /* FTE %*/
                    jValue = ValidateStringAsNumber(val, 7, 0, true, "");
                    break;
            }
            if (jValue == null || jValue.error != null)
                return;

            var lStartPeriod = startPeriod;
            var lFinishPeriod = finishPeriod;
            if (copy == 0) {
                if (jValue.value != "") {
                    jValue.value = jValue.value / (lFinishPeriod - lStartPeriod + 1);
                }
            }
            var resuid = grid.GetAttribute(row, null, "PendingRes_UID");
            if (resuid == null) resuid = grid.GetAttribute(row, null, "Res_UID");
            var resrow = rpeditor.FindResourceRow(resuid);
            for (var c = 0; c < grid.ColNames[2].length; c++) {
                var col = grid.ColNames[2][c];
                var sType = col.substring(0, 1);
                if (sType == "Q") {
                    var nId = parseInt(col.substring(1));
                    if (nId < lStartPeriod || nId > lFinishPeriod) {
                        if (clearPeriods != 0) {
                            rpeditor.SetPeriodValue(grid, row, col, 0);
                            grid.SetAttribute(row, col, null, "", 0, 0);
                            rpeditor.CalculateResourceRowPeriodCommitted(resuid, resrow, nId, false);
                        }
                    }
                    else if (jValue != null && jValue.error == null && jValue.value != "") {
                        var dblValue = parseFloat(jValue.value) * mpy;
                        rpeditor.SetPeriodValue(grid, row, col, dblValue);
                        var sValue = rpeditor.GetFormattedPeriodCell(grid, row, col, false, false);
                        grid.SetAttribute(row, col, null, sValue, 0, 0);
                        rpeditor.CalculateResourceRowPeriodCommitted(resuid, resrow, nId, false);
                    }
                }
            }

            grid.RefreshRow(row);
            var reqrow = rpeditor.GetParentRequirement(row);
            if (reqrow != null) {
                rpeditor.UpdatePlanRowCalculatedValues(reqrow, 0);
                rpeditor.RefreshPlanRowPeriods(grid, reqrow, true);
            }
            //rpeditor.UpdateButtonsAsync();
        }
    };
    function GetFirstProjectRow() {
        var plangrid = rpeditor.plangrid;
        var planrow = plangrid.GetFirst(null, 0);
        var const_Project = 0;
        while (planrow != null) {
            var status = plangrid.GetAttribute(planrow, null, "Status");
            if (status == const_Project)
                return planrow;
            planrow = plangrid.GetNext(planrow);
        }
        return null
    };
    function GetAllCommitmentRows() {
        var rows = [];
        var plangrid = rpeditor.plangrid;
        var planrow = plangrid.GetFirst(null, 0);
        while (planrow != null) {
            var status = plangrid.GetAttribute(planrow, null, "Status");
            if (planrow.Kind === 'Data' && status == 256)
                rows[rows.length++] = planrow;
            planrow = plangrid.GetNext(planrow);
        }
        return rows
    };
    //    var thiswins = new dhtmlXWindows();
//    thiswins.setImagePath("/_layouts/ppm/images/");
//    thiswins.setSkin("dhx_web");

    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("load", OnLoad, true);
        //window.addEventListener("beforeunload", OnBeforeUnload, true);
        //window.addEventListener("resize", OnResize, true);
    }
    else { // e.g. IE
        window.attachEvent("onload", OnLoad);
        //window.attachEvent("onbeforeunload", OnBeforeUnload);
        //window.attachEvent("onresize", OnResize);
    }
</script>
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Resource Planning Test Data
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Resource Planning Test Data
</asp:Content>
