<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Register src="Tools/DGrid.ascx" tagname="DGridUserControl" tagprefix="dg1" %>
<%@ Register src="Tools/TGrid.ascx" tagname="TGridUserControl" tagprefix="tg1" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendars_NAX.aspx.cs" Inherits="WorkEnginePPM.Layouts.ppm.Calendars_NAX" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Reference Control="/_layouts/ppm/tools/DGrid.ascx" %>
<%@ Reference Control="/_layouts/ppm/tools/TGrid.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
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
<script src="/_layouts/ppm/Tools/DateHelper.js?ver=<%=FileVersion%>" type="text/javascript"></script>
<script src="/_layouts/ppm/PeriodAutomation.js?ver=<%=FileVersion%>" type="text/javascript"></script>
<script src="/_layouts/epmlive/javascripts/libraries/jquery-ui.min.js" type="text/javascript"></script>

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

.formtable {
    width: 100%;
    border-spacing: 0;
    border-collapse: collapse;
    padding: 0;
}

.normaldescription {
    width: 210px !important;
}

.tinyinput {
    width: 70px;
}

.normalinput {
    width: 300px;
}

.l2 {
    padding-left: 20px;
}

.l3 {
    padding-left: 40px;
}

input[type="radio"] {
    cursor: pointer;
}

.hiddenelement {
    display: none;
}

.message {
    padding: 8px 35px 8px 14px;
    margin-bottom: 20px;
    text-shadow: 0 1px 0 rgba(255, 255, 255, 0.5);
    background-color: #fcf8e3;
    border: 1px solid #fbeed5;
    -webkit-border-radius: 4px;
    -moz-border-radius: 4px;
    border-radius: 4px;
}

.message-info {
    color: #3a87ad;
    background-color: #d9edf7;
    border-color: #bce8f1;
}

.message-success {
    color: #468847;
    background-color: #dff0d8;
    border-color: #d6e9c6;
}

.message-danger,
.message-error {
    color: #b94a48;
    background-color: #f2dede;
    border-color: #eed3d7;
}

#periodsLabelCell {
    width: 20% !important;
    vertical-align: top;
}

#periodsControlCell {
    width: 80% !important;
}

#createPeriodsButton {
    width: 100px !important;
    margin-left: 4px;
}

#cutPeriodsStartDateRow+td {
    padding-top: 0;
    padding-bottom: 0
}
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<div style="display: block;" >
<div class="modalContent" id="idCalendarDlg" style="display:none;">
    <input id="idCalendarDlgMode" type="hidden" value="" />
    <div id="idToolbar2Div"></div>
	<div style="margin-top:10px;padding-right:10px;">
		<div style="padding-bottom:3px;">
            <table class="formtable">
                <tr>
                    <td style="height:1px;" class="topcell normaldescription"></td>
                    <td style="height:1px;" class="topcell"></td>
                </tr>
                <tr class="hiddenelement">
                    <td class="descriptioncell normaldescription">
                        Field Id
                    </td>
                    <td class="controlcell">
                        <input type="text" id="txtId" />
                    </td>
                </tr>
                <tr>
                    <td class="descriptioncell normaldescription">
                        Name
                    </td>
                    <td class="controlcell normalinput">
                        <input type="text" id="txtName" />
                    </td>
                </tr>
                <tr title="Enable automation to create new periods without the need to manually create them." >
                    <td class="descriptioncell normaldescription">
                        <label for="automateNewPeriodCreationRadioYes">Automate new period creation</label>
                    </td>
                    <td class="controlcell">
                        <input id="automateNewPeriodCreationRadioYes" type="radio" name="automateNewPeriodCreationRadioGroup" onclick="javascript: calendarDlg_event('AutomateNewPeriodCreationRadioOnClick');" /> <label for="automateNewPeriodCreationRadioYes">Yes</label>
                        <input id="automateNewPeriodCreationRadioNo" type="radio" name="automateNewPeriodCreationRadioGroup" onclick="javascript: calendarDlg_event('AutomateNewPeriodCreationRadioOnClick');" /> <label for="automateNewPeriodCreationRadioNo">No</label>
                    </td>
                </tr>
                <tr id="cutPeriodsSummaryRow" class="hiddenelement">
                    <td colspan="2">
                        <div class="message message-info">
                            <span id="cutPeriodsSummaryText"></span>
                        </div>
                    </td>
                </tr>
                <tr id="cutPeriodsWeeklyRow">
                    <td class="descriptioncell normaldescription l2">
                        <span>Cut Periods Weekly:</span>
                    </td>
                    <td class="controlcell">
                        <input id="cutPeriodsWeeklyRadioYes" type="radio" name="cutPeriodsWeeklyRadioGroup" onclick="javascript: calendarDlg_event('CutPeriodsWeeklyRadioOnClick');" /> <label for="cutPeriodsWeeklyRadioYes">Yes</label>
                        <input id="cutPeriodsWeeklyRadioNo" type="radio" name="cutPeriodsWeeklyRadioGroup" onclick="javascript: calendarDlg_event('CutPeriodsWeeklyRadioOnClick');" /> <label for="cutPeriodsWeeklyRadioNo">No</label>
                    </td>
                </tr>
                <tr id="cutPeriodsWeeklyPeriodicityRow">
                    <td class="descriptioncell normaldescription l3">
                        <span>Cut every how many weeks</span>
                    </td>
                    <td class="controlcell tinyinput">
                        <input type="number" min="1" id="cutPeriodsWeeklyPeriodicityInput"/>
                    </td>
                </tr>
                <tr id="cutPeriodsWeeklyDayRow">
                    <td class="descriptioncell normaldescription l3">
                        <span>Cut on what day of the week</span>
                    </td>
                    <td class="controlcell normalinput">
                        <select id="cutPeriodsWeeklyDayInput" >
                            <option value="1">Monday</option>
                            <option value="2">Tuesday</option>
                            <option value="3">Wednesday</option>
                            <option value="4">Thursday</option>
                            <option value="5">Friday</option>
                            <option value="6">Saturday</option>
                            <option value="0" selected>Sunday</option>
                        </select>
                    </td>
                </tr>
                <tr id="cutPeriodsMonthlyRow">
                    <td class="descriptioncell normaldescription l2">
                        <span>Cut Periods Monthly:</span>
                    </td>
                    <td class="controlcell">
                        <input id="cutPeriodsMonthlyRadioYes" type="radio" name="cutPeriodsMonthlyRadioGroup" onclick="javascript: calendarDlg_event('CutPeriodsMonthlyRadioOnClick');" /> <label for="cutPeriodsMonthlyRadioYes">Yes</label>
                        <input id="cutPeriodsMonthlyRadioNo" type="radio" name="cutPeriodsMonthlyRadioGroup" onclick="javascript: calendarDlg_event('CutPeriodsMonthlyRadioOnClick');" /> <label for="cutPeriodsMonthlyRadioNo">No</label>
                    </td>
                </tr>
                <tr id="cutPeriodsMonthlyPeriodicityRow">
                    <td class="descriptioncell normaldescription l3">
                        <span>Cut every how many months</span>
                    </td>
                    <td class="controlcell tinyinput">
                        <input type="number" min="1" id="cutPeriodsMonthlyPeriodicityInput"/>
                    </td>
                </tr>
                <tr id="cutPeriodsMonthlyDayRow">
                    <td class="descriptioncell normaldescription l3">
                        <span>Cut on what day of the month</span>
                    </td>
                    <td class="controlcell tinyinput">
                        <input type="number" min="1" max="31" id="cutPeriodsMonthlyDayInput"/>
                        <input id="cutPeriodsMonthlyEndOfDayCheckBox" type="checkbox" onclick="javascript: calendarDlg_event('CutPeriodsMonthlyEndOfDayCheckBoxOnClick');" /> <label for="cutPeriodsMonthlyRadioNo">Last Day</label>
                    </td>
                </tr>
                <tr id="cutPeriodsStartDateRow">
                    <td class="descriptioncell normaldescription l2">
                        <span>Start On</span>
                    </td>
                    <td class="controlcell normalinput">
                        <input type="text" id="cutPeriodsStartDateInput">
                    </td>
                </tr>
                <tr id="cutPeriodsEndDateRow">
                    <td class="descriptioncell normaldescription l2">
                        <span>End By</span>
                    </td>
                    <td class="controlcell normalinput">
                        <input type="text" id="cutPeriodsEndDateInput">
                    </td>
                </tr>
                <tr id="createPeriodsActionRow">
                    <td class="descriptioncell">
                        &nbsp;
                    </td>
                    <td>
                        <input id="createPeriodsButton" type="button" class="epmliveButton" value="Create Periods" onclick="calendarDlg_event('CreatePeriodsButtonOnClick');"/>
                    </td>
                </tr>
            </table>
            <table id="periodsTable" class="formtable">
                <tr>
                    <td id="periodsLabelCell" class="descriptioncell" >
                        Periods
                    </td>
                    <td id="periodsControlCell" class="controlcell" colspan="2">
                        <tg1:TGridUserControl id="tgrid1" runat="server" />
                    </td>
                </tr>
            </table>
		</div>
		<div style="float:right;">
			<div class="button-container" >
			    <input id="idOKButton" type="button" class="epmliveButton" value="OK" onclick="calendarDlg_event('ok');"/>
			    <input type="button" class="epmliveButton" value="Cancel" onclick="calendarDlg_event('cancel');"/>
			</div>
		</div>
	</div>
</div>

<asp:Label ID="lblGeneralError" runat="server" Text="" Visible="false" ForeColor="Red"></asp:Label>
<div id="successMessage" class="message message-success hiddenelement">
    Period creation is successful.
</div>
<div id="idToolbarDiv"></div>
<dg1:DGridUserControl id="dgrid1" runat="server" />
</div>
<script type="text/javascript">
    var toolbarData = {
        parent: "idToolbarDiv",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", name: "Add", img: "addresource.gif", tooltip: "Add", width: "80px", onclick: "toolbar_event('btnAdd');" },
            { type: "button", id: "btnModify", name: "Modify", img: "editview.gif", tooltip: "Modify", width: "80px", onclick: "return toolbar_event('btnModify');", disabled: true },
            { type: "button", id: "btnDelete", name: "Delete", img: "delete.png", tooltip: "Delete", width: "80px", onclick: "return toolbar_event('btnDelete');", disabled: true }
        ]
    };
    var toolbar2Data = {
        parent: "idToolbar2Div",
        style: "display:none;",
        imagePath: "images/",
        items: [
            { type: "button", id: "btnAdd2", name: "Add", img: "addresource.gif", tooltip: "Add", width: "80px", onclick: "toolbar2_event('btnAdd2');" },
            { type: "button", id: "btnInsert2", name: "Insert", img: "editview.gif", tooltip: "Modify", width: "80px", onclick: "return toolbar2_event('btnInsert2');", disabled: true },
            { type: "button", id: "btnDelete2", name: "Delete", img: "delete.png", tooltip: "Delete", width: "80px", onclick: "return toolbar2_event('btnDelete2');", disabled: true }
        ]
    };

    var toolbar = new Toolbar(toolbarData);
    var toolbar2 = new Toolbar(toolbar2Data);
    
    var dgrid1 = window['<%=dgrid1.UID%>'];
    var dgrid1_selectedRow = 0;
    var tgrid1 = window['<%=tgrid1.UID%>'];
    var tgrid1_selectedRow = 0;

    function OnLoad(event) {
        toolbar.Render();
        Grids.OnClickCell = GridsOnClickCell;
        dgrid1.addEventListener("onRowSelect", dgrid1_OnRowSelect);
        PeriodAutomation.initializeForm(UpdatePeriodAutomationControlStates);
        OnResize();
    };
    function dgrid1_OnRowSelect(rowid, cellindex) {
        dgrid1_selectedRow = rowid;
        if (rowid != null && rowid >= 0) {
            toolbar.enableItem("btnModify");
            toolbar.enableItem("btnDelete");
        }
        else {
            toolbar.disableItem("btnModify");
            toolbar.disableItem("btnDelete");
        }
    };
    function GridsOnClickCell(grid, row, col) {
        switch (grid.id) {
            case tgrid1.id:
                tgrid1_selectedRow = row;
                if (row != null && row != "") {
                    toolbar2.enableItem("btnInsert2");
                    if (row.id != null && row.id.substring(2) == grid.RowCount) {
                        toolbar2.enableItem("btnDelete2");
                    }
                    else
                    {
                        toolbar2.disableItem("btnDelete2");
                    }
                }
                else {
                    toolbar2.disableItem("btnInsert2");
                    toolbar2.disableItem("btnDelete2");
                }
                break;
        }
    };
    var OnResize = function (event) {
        var lefttop = dgrid1.GetLeftTopPositions();
        var newHeight = document.documentElement.clientHeight - lefttop[1] - 5;
        dgrid1.SetHeight(newHeight);
        var newWidth = document.documentElement.clientWidth - lefttop[0] - 3;
        dgrid1.SetWidth(newWidth);
    };
    function DisplayDialog(width, height, title, idWindow, idAttachObj, bModal, bResize) {
        var dlg = jsf_displayDialog(thiswins, 0, 0, width, height, title, idWindow, idAttachObj, bModal, bResize);
        dlg.attachEvent("onClose", function (win) { return CloseDialog(idWindow); });
        return dlg;
    };
    function CloseDialog (idWindow) {
        if (idWindow == 'winCalendarDlg')
            dgrid1.grid.selectRowById(dgrid1_selectedRow);
        return jsf_closeDialog(thiswins, idWindow);
    };
    function SendRequest(sXML) {
         sURL = "./Calendars.ashx";
         return jsf_sendRequest(sURL, sXML);
    };
    function toolbar2_event(event) {
        var dlgTitle = "";
        switch (event) {
           case "btnInsert2":
                if (toolbar2.isItemDisabled("btnInsert2") == true) {
                    alert("Select a row to enable the Insert button");
                    return false;
                }
           case "btnAdd2":
               var newrow;
                if (event == "btnInsert2") {
                    newrow = tgrid1.grid.AddRow(null, tgrid1_selectedRow, true);
                }
                else {
                    newrow = tgrid1.grid.AddRow(null, null, true);
                }
                var prevrow = newrow.previousSibling;
                var start = null;
                var finish = null;
                var id = 0;
                var const_day = 86400000;
                if (prevrow != null && tgrid1.grid.GetAttribute(prevrow, null, "Deleted") != 1) {
                    start = tgrid1.GetCellValue(prevrow, "PRD_START_DATE");
                    finish = tgrid1.GetCellValue(prevrow, "PRD_FINISH_DATE");
                    id = parseInt(tgrid1.GetCellValue(prevrow, "PRD_ID"));
                    if (start != null && finish != null) {
                        tgrid1.SetCellValue(newrow, "PRD_START_DATE", finish + const_day);
                        tgrid1.SetCellValue(newrow, "PRD_FINISH_DATE", finish + (finish - start) + const_day);
                    }
                    tgrid1.SetCellValue(newrow, "PRD_ID", (id+1));
                    tgrid1.SetCellValue(newrow, "PRD_NAME", "Period" + (id+1).toString());
                }
                else {
                    var nextrow = newrow.nextSibling;
                    if (nextrow != null && tgrid1.grid.GetAttribute(nextrow, null, "Deleted") != 1) {
                        start = tgrid1.GetCellValue(nextrow, "PRD_START_DATE");
                        finish = tgrid1.GetCellValue(nextrow, "PRD_FINISH_DATE");
                        id = parseInt(tgrid1.GetCellValue(nextrow, "PRD_ID"));
                        if (start != null && finish != null) {
                            tgrid1.SetCellValue(newrow, "PRD_FINISH_DATE", start - const_day);
                            tgrid1.SetCellValue(newrow, "PRD_START_DATE", start - (finish - start) - const_day);
                        }
                        tgrid1.SetCellValue(newrow, "PRD_ID", (id-1));
                        tgrid1.SetCellValue(newrow, "PRD_NAME", "Period" + (id-1).toString());
                    }
                    else {
                        tgrid1.SetCellValue(newrow, "PRD_ID", 1);
                        tgrid1.SetCellValue(newrow, "PRD_NAME", "Period1");
                        var today = new Date().getTime();
                        today = parseInt(today / const_day) * const_day;
                        tgrid1.SetCellValue(newrow, "PRD_START_DATE", today);
                        tgrid1.SetCellValue(newrow, "PRD_FINISH_DATE", today + const_day);
                    }
                }
                tgrid1_selectedRow = newrow;
                tgrid1.Focus(newrow, 'PRD_NAME');
                break;
          case "btnDelete2":
                if (toolbar2.isItemDisabled("btnDelete2") == true) {
                    alert("Select a row to enable the Delete button");
                    return false;
                }
                tgrid1.grid.DeleteRow(tgrid1_selectedRow, 2); // 1=okmsg+del; 2=del; 3=undel
                GridsOnClickCell(tgrid1.grid, null, null)
                break;
        }
        return false;
    };
    function toolbar_event(event) {
        var sRowId = "";
        document.getElementById('idCalendarDlgMode').value = event;
        document.getElementById("successMessage").style.display = "none";
        var dlgTitle = "";
       switch (event) {
           case "btnModify":
                if (toolbar.isItemDisabled("btnModify") == true) {
                    alert("Select a row to enable the Modify button");
                    return false;
                }
                dlgTitle = "Modify Calendar";
                sRowId = dgrid1_selectedRow;
                GetCalendarInfo(event, dlgTitle, sRowId);
                break;
          case "btnAdd":
                sRowId = "-1";
                dlgTitle = "Add Calendar";
                GetCalendarInfo(event, dlgTitle, sRowId);
                break;
          case "btnDelete":
                if (toolbar.isItemDisabled("btnDelete") == true) {
                    alert("Select a row to enable the Delete button");
                    return false;
                }
                sRowId = dgrid1_selectedRow;
                GetCalendarInfo(event, "Delete Calendar, are you sure?", sRowId);
                break;
        }
        return false;
    };
    function GetCalendarInfo(sMode, sDlgTitle, sRowId) {
        var sRequest = '<request function="CalendarRequest" context="ReadCalendarInfo"><data><![CDATA[' + sRowId + ']]></data></request>';
        var jsonString = SendRequest(sRequest);
        var json = JSON_ConvertString(jsonString);
        if (json.reply != null) {
            if (jsf_alertError(json.reply.error) == true)
                return false;
        }
        document.getElementById('txtId').value = json.reply.calendar.calendarid;
        document.getElementById('txtName').value = json.reply.calendar.name;
        toolbar2.Render();
        tgrid1.Initialize(json.reply.calendar.tgridData);
        tgrid1.SetWidth(380);
        tgrid1.SetHeight(380);
        dgrid1.grid.clearSelection();
        var minDate = null;
        var lastRow = tgrid1.grid.GetLast();
        if (lastRow !== null) {
            minDate = DateHelper.addDays(DateHelper.convertToUtcDate(tgrid1.GetCellValue(lastRow, "PRD_FINISH_DATE")), 1);
        }
        PeriodAutomation.setMinDate(minDate);
        PeriodAutomation.updateFormValues(false, false, false, false, true);
        if (sMode == "btnDelete") {
            document.getElementById("automateNewPeriodCreationRadioYes").disabled = true;
            document.getElementById("automateNewPeriodCreationRadioNo").disabled = true;
            document.getElementById('idOKButton').value = "Delete";
         }
        else {
            document.getElementById("automateNewPeriodCreationRadioYes").disabled = false;
            document.getElementById("automateNewPeriodCreationRadioNo").disabled = false;
            document.getElementById('idOKButton').value = "Save";
        }
        DisplayDialog(600, 720, sDlgTitle, "winCalendarDlg", "idCalendarDlg", true, false);
    };

    function AddAutomatedPeriods(data) {
        PeriodAutomation.displaySummary(data.summary);
        var periods = data.periods;
        for (var i = 0; i < periods.length; i++) {
            var period = periods[i];
            var newRow = tgrid1.grid.AddRow(null, null, true);
            tgrid1.SetCellValue(newRow, "PRD_START_DATE", period.start.getTime());
            tgrid1.SetCellValue(newRow, "PRD_FINISH_DATE", period.finish.getTime());
            tgrid1.SetCellValue(newRow, "PRD_ID", period.id);
            tgrid1.SetCellValue(newRow, "PRD_NAME", period.name);
        }
        
        return;
    }

    function UpdatePeriodAutomationControlStates(options) {
        if (options.enabled !== undefined) {
            document.getElementById("periodsTable").style.display = options.enabled ? "none" : "table";
            document.getElementById("idOKButton").disabled = options.enabled;

            if (options.enabled) {
                toolbar2.disableItem("btnAdd2");
            } else {
                toolbar2.enableItem("btnAdd2");
            }
        }
    }

    function calendarDlg_event(event) {
        switch (event) {
            case "ok":
                var action = document.getElementById('idCalendarDlgMode').value;
                switch (action) {
                    case "btnAdd":
                    case "btnModify":
                        var sb = new StringBuilder();
                        tgrid1.grid.EndEdit(true);
                        sb.append('<request function="CalendarRequest" context="UpdateCalendarInfo">');
                        sb.append('<data');
                        sb.append(' calendarid="' + document.getElementById('txtId').value + '"');
                        sb.append(' name="' + jsf_xml(document.getElementById('txtName').value) + '"');
                        sb.append('>');
                        sb.append('<![CDATA[' + tgrid1.GetXmlData() + ']]>');
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
                            sRowId = json.reply.calendar.calendarid;
                            dgrid1.addRow(sRowId);
                        }
                        dgrid1.SetCellValue(sRowId, "CB_ID", json.reply.calendar.calendarid);
                        dgrid1.SetCellValue(sRowId, "CB_NAME", json.reply.calendar.name);

                        var lastRow = tgrid1.grid.GetLast();
                        if (lastRow !== null && lastRow.Added === 1) {
                            document.getElementById("successMessage").innerHTML = "Period creation is successful.";
                            document.getElementById("successMessage").style.display = "block";
                        }
                        break;
                    case "btnDelete":
                        var sb = new StringBuilder();
                        sb.append('<request function="CalendarRequest" context="DeleteCalendarInfo">');
                        sb.append('<data');
                        sb.append(' calendarid="' + document.getElementById('txtId').value + '"');
                        sb.append(' name="' + jsf_xml(document.getElementById('txtName').value) + '"');
                        sb.append('>');
                        sb.append('<![CDATA[' + tgrid1.GetXmlData() + ']]>');
                        sb.append('</data>');
                        sb.append('</request>'); 
                        var sRequest = sb.toString();
                        var jsonString = SendRequest(sRequest);
                        var json = JSON_ConvertString(jsonString);
                        if (json.reply != null) {
                            if (jsf_alertError(json.reply.error) == true)
                                return false;
                        }
                        // if deleted  then remove row from grid
                        var sRowId = dgrid1_selectedRow;
                        dgrid1.deleteRow(sRowId);
                        dgrid1_OnRowSelect(null);
                      break;
                }
                GridsOnClickCell(tgrid1.grid, null, null)
                CloseDialog('winCalendarDlg');
                break;
            case "AutomateNewPeriodCreationRadioOnClick":
                PeriodAutomation.automateNewPeriodCreationRadioOnClick();
                break;
            case "CutPeriodsWeeklyRadioOnClick":
                PeriodAutomation.cutPeriodsWeeklyRadioOnClick();
                break;
            case "CutPeriodsMonthlyRadioOnClick":
                PeriodAutomation.cutPeriodsMonthlyRadioOnClick();
                break;
            case "CutPeriodsMonthlyEndOfDayCheckBoxOnClick":
                PeriodAutomation.cutPeriodsMonthlyEndOfDayCheckBoxOnClick();
                break;
            case "CreatePeriodsButtonOnClick":
                if (PeriodAutomation.validateForm()) {
                    var periods = PeriodAutomation.getPeriods();
                    AddAutomatedPeriods(periods);
                }
                break;
            case "cancel":
                GridsOnClickCell(tgrid1.grid, null, null);
                CloseDialog('winCalendarDlg');
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

<asp:Content ID="Content3" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Calendars
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
Calendars
</asp:Content>
