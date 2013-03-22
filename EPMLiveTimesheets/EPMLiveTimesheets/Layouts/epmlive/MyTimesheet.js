var curRow;
var curCol;
var TSColType;
var TSNotes;
var TSTypeObject;
var TSCols;
var curGrid;
var curPop = false;
var StopWatchRow = null;
var StopWatchGrid = null;
var siteUrl;
var sApplyDates = "";
var curStoppingRow;
var curStoppingGrid;
var StopWatchResponse;
var bStopWatchStartWaiting = false;
var cView;
var TSStatusMessage = null;
var TSApprovalMessage = null;
var bTSSaving = false;
var bTSApproving = false;
var iApproveInterval;
var curServerDate;
var spnMsg = null;


Grids.OnRenderStart = function (grid) {
    if (grid.id.substr(0, 2) == "TS") {
        var newgridid = grid.id.substr(2);
        var newobj = eval("TSObject" + newgridid);
        if (newobj) {
            grid.TSObject = newobj;

            document.getElementById("TSLoader" + newgridid).style.display = "none";
        }

        for (var R in grid.Rows) {
            var oRow = grid.Rows[R];
            if (oRow.Kind == "Data") {
                if (grid.GetValue(oRow, "StopWatch") != "") {
                    StopWatchRow = oRow;
                    StopWatchGrid = grid;
                }
            }
        }

        EPMLiveCore.WorkEngineAPI.set_path(siteUrl + '/_vti_bin/WorkEngine.asmx');
    }
}

Grids.OnRenderFinish = function (grid) {
    curGrid = grid;
    if (grid.id.substr(0, 2) == "TS") {
        RefreshStopWatch();
        CheckSaveStatus(grid.id);
        StartCheckApproveStatus(grid.id);


    }
}

Grids.OnScroll = function (grid) {
    if (curRow && curRow.Kind == "Data" && curRow.id != "-1" && curCol && TSCols[curCol]) {
        grid.SetAttribute(curRow, curCol, "HtmlPrefix", "", true, false);
        curPop = false;
    }
}


Grids.OnKeyDown = function (grid, key, event, name, prefix) {

    if (curPop) {
        grid.EndEdit(false);
        grid.StartEdit();
    }
}

Grids.OnEnterEdit = function (grid, row, col) {
    if (curPop) {
        setTimeout("curGrid.StartEdit()", 100);
    }
}

Grids.OnKeyPress = function (grid, key, event, name, prefix) {

}

Grids.OnDblClick = function (grid, row, col, x, y, event) {
    if (curPop)
        return true;
}

Grids.OnAfterSave = function (grid, result, autoupdate) {
    if (grid.id.substr(0, 2) == "TS") {

        if (grid.IO.Result == "0" || grid.IO.Result == "2") {
            bTSSaving = true;
            RefreshCommandUI();
            CheckSaveStatus(grid.id);
        }

        HideMessage(grid.id);


    }
}

function CheckSaveStatus(gridid) {

    var grid = Grids[gridid];

    EPMLiveCore.WorkEngineAPI.ExecuteJSON("timesheet_CheckSaveStatus", "<Timesheet ID=\"" + grid.TimesheetUID + "\" />", function (response) {
        var oResponse = eval("(" + response + ")");

        if (oResponse.SaveStatus.Result == "0") {

            var status = "";

            if (oResponse.SaveStatus.Status == "-1")
                return;

            if (oResponse.SaveStatus.Status == "0")
                status = "Queued";
            else if (oResponse.SaveStatus.Status == "1")
                status = "Processing (" + oResponse.SaveStatus.PercentComplete + "%)";
            else if (oResponse.SaveStatus.Status == "2")
                status = "Completed";

            if (oResponse.SaveStatus.Status == "2") {

                if (oResponse.SaveStatus.ErrorResult == "No Errors") {
                    if (TSStatusMessage != null) {
                        SP.UI.Status.removeStatus(TSStatusMessage);
                        TSStatusMessage = null;
                    }
                }
                else {
                    SP.UI.Status.setStatusPriColor(TSStatusMessage, 'red');
                    SP.UI.Status.updateStatus(TSStatusMessage, "Error: " + oResponse.SaveStatus.ResultText);
                }

                if (bTSSaving) {
                    bTSSaving = false;
                    RefreshCommandUI();
                }
            }
            else {
                if (!bTSSaving) {
                    bTSSaving = true;
                    RefreshCommandUI();
                }
                if (TSStatusMessage == null) {
                    TSStatusMessage = SP.UI.Status.addStatus('Save Status:', status, true);
                    SP.UI.Status.setStatusPriColor(TSStatusMessage, 'blue');
                }
                else {
                    SP.UI.Status.updateStatus(TSStatusMessage, status);
                    SP.UI.Status.setStatusPriColor(TSStatusMessage, 'blue');
                }
                setTimeout("CheckSaveStatus('" + gridid + "')", 2000);
            }
        }

    });
}

function UnSubmitTimesheet(gridid) {

    ShowMessage(gridid, "Unsubmitting...", 150, 30);

    var grid = Grids[gridid];

    EPMLiveCore.WorkEngineAPI.ExecuteJSON("timesheet_UnSubmitTimesheet", "<Timesheet ID=\"" + grid.TimesheetUID + "\" />", function (response) {
        var oResponse = eval("(" + response + ")");

        HideMessage(grid.id);

        if (oResponse.UnSubmitTimesheet.Status == "0") {

            var newgridid = grid.id.substr(2);
            var newobj = eval("TSObject" + newgridid);

            newobj.Status = "Unsubmitted";

            EnableAllRows(grid);

            HideMessage(gridid);

            AfterUnSubmit(grid);

            RefreshCommandUI();

        }
        else {
            alert(oResponse.UnSubmitTimesheet.Text);
        }
    });
}

function SubmitTimesheet(gridid) {

    if (!StopWatchRow) {
        ShowMessage(gridid, "Submitting...", 140, 30);

        var grid = Grids[gridid];

        EPMLiveCore.WorkEngineAPI.ExecuteJSON("timesheet_SubmitTimesheet", "<Timesheet ID=\"" + grid.TimesheetUID + "\" />", function (response) {
            var oResponse = eval("(" + response + ")");

            HideMessage(grid.id);

            if (oResponse.SubmitTimesheet.Status == "0") {

                var newgridid = grid.id.substr(2);
                var newobj = eval("TSObject" + newgridid);

                newobj.Status = "Submitted";

                DisableAllRows(grid);

                AfterSubmit(grid);

                RefreshCommandUI();

            }
            else {
                alert(oResponse.SubmitTimesheet.Text);
            }

            StartCheckApproveStatus(gridid);
        });
    }
    else {
        alert('You have a stopwatch currently running, please stop the stopwatch before you submit');
    }
}

function DisableAllRows(grid) {

    for (var row in grid.Rows) {

        var oRow = grid.Rows[row];

        if (oRow.Kind == "Data" && oRow.id != "-1") {
            grid.SetAttribute(oRow, null, "CanEdit", 0, true, false);
        }
    }

}

function EnableAllRows(grid) {

    for (var row in grid.Rows) {

        var oRow = grid.Rows[row];

        if (oRow.Kind == "Data" && oRow.id != "-1") {
            if (grid.GetValue(oRow, "TSEnabled") == "1")
                grid.SetAttribute(oRow, null, "CanEdit", "1", true, false);
        }
    }



}

function ShowMessage(id, message, w, h) {

    id = id.substr(2);

    HideMessage(id);

    if (!spnMsg)
        spnMsg = document.getElementById("spnMessage" + id);

    spnMsg.innerHTML = message;

    sm("divMessage" + id, w, h);
}

function HideMessage(id) {
    hm("divMessage" + id);
}

function StartCheckApproveStatus(gridid) {
    if (iApproveInterval)
        clearInterval(iApproveInterval);

    CheckApproveStatus(gridid);

    iApproveInterval = setInterval("CheckApproveStatus('" + gridid + "')", 10000);
}

function ChangeView(grid, view) {
    var newgridid = grid.id.substr(2);
    var newobj = eval("TSObject" + newgridid);

    var oView = newobj.Views[view];



    //Group
    if (oView.Group == "") {
        grid.DoGrouping(null);
    }
    else {
        grid.DoGrouping(oView.Group);
    }


    var oViewCols = oView.Cols.split(',');
    var sViewCols = "";

    var oVisible = new Object();

    for (var oViewCol in oViewCols) {
        var oViewColInfo = oViewCols[oViewCol].split('|');

        oVisible[oViewColInfo[0]] = new Object();

        if (oViewColInfo.length > 1)
            oVisible[oViewColInfo[0]].Width = oViewColInfo[1];
        else
            oVisible[oViewColInfo[0]].Width = "";

    }

    //Cols
    var Cols = grid.GetCols("");

    var Show = "";
    var Hide = "";

    for (var i = 0; i < Cols.length; i++) {
        var vCol = grid.Cols[Cols[i]];
        if (vCol) {
            if (vCol.Sec == 0) {
                if (oVisible[vCol.Name])
                    Show += "," + vCol.Name;
                else
                    Hide += "," + vCol.Name;
            }
        }
    }

    grid.ChangeColsVisibility(Show.substr(1).split(','), Hide.substr(1).split(','), 0);

    for (var oV in oVisible) {

        var ooV = oVisible[oV];

        if (ooV.Width != "") {
            var tWidth = grid.GetAttribute(null, oV, "Width");

            var dx = parseInt(ooV.Width) - tWidth;
            try {
                grid.SetWidth(oV, dx);
            } catch (e) {

            }
        }

    }

    //Filters
    if (oView.Filters == "" || oView.Filters == "||") {
        grid.ChangeFilter("", "", "", 0, 0, null);
    }
    else {
        var filters = oView.Filters.split("|");
        grid.ChangeFilter(filters[0], filters[1], filters[2], 0, 0, null);
    }

    //Sort
    grid.Sort = oView.Sort;
    grid.SortRows();
    //===========================================

    newobj.CurrentViewId = view;
    newobj.CurrentView = oView.Name;

    RefreshCommandUI();

    grid.Render();
}

function DeleteView(grid, view) {

    ShowMessage(grid.id, "Deleting View...", 150, 50);

    EPMLiveCore.WorkEngineAPI.ExecuteJSON("timesheet_DeleteView", "<View Name=\"" + view + "\"/>", function (response) {
        var oResponse = eval("(" + response + ")");
        grid.StaticCursor = 1;

        HideMessage(grid.id);

        if (oResponse.Views.Status == "0") {

            var newgridid = grid.id.substr(2);
            var newobj = eval("TSObject" + newgridid);

            newobj.Views = eval("(" + oResponse.Views.Text.replace(/&quot;/g, "\"") + ")");

            for (var view in newobj.Views) {
                var oView = newobj.Views[view];

                //if (oView.Name == retval[0]) {
                //    newobj.CurrentView = retval[0];
                //    newobj.CurrentViewId = view;
                //    break;
                //}
            }

            newobj.CurrentView = "";
            newobj.CurrentViewId = "";

            RefreshCommandUI();
        }
        else {
            alert(oResponse.Views.Text);
        }
    });
}

function RenameView(grid, view, newview) {

    ShowMessage(grid.id, "Renaming View...", 150, 50);

    EPMLiveCore.WorkEngineAPI.ExecuteJSON("timesheet_RenameView", "<View Name=\"" + view + "\" NewName=\"" + newview + "\"/>", function (response) {
        var oResponse = eval("(" + response + ")");
        grid.StaticCursor = 1;

        HideMessage(grid.id);

        if (oResponse.Views.Status == "0") {

            var newgridid = grid.id.substr(2);
            var newobj = eval("TSObject" + newgridid);

            newobj.Views = eval("(" + oResponse.Views.Text.replace(/&quot;/g, "\"") + ")");

            for (var view in newobj.Views) {
                var oView = newobj.Views[view];

                if (oView.Name == newview) {
                    newobj.CurrentView = newview;
                    newobj.CurrentViewId = view;
                    break;
                }
            }

            RefreshCommandUI();
        }
        else {
            alert(oResponse.Views.Text);
        }
    });
}

function SaveView(grid, retval) {

    ShowMessage(grid.id, "Saving View...", 150, 50);

    grid.StaticCursor = 0;
    //=============Filters===================
    var row = grid.GetRowById("Filter");

    var filterfields = "";
    var filtervals = "";
    var filtertypes = "";

    for (var col in grid.Cols) {
        var cell = row[col + "Filter"];
        if (cell != null) {
            if (cell != 0) {
                filtertypes += "," + cell;
                filtervals += "," + row[col];
                filterfields += "," + col;
            }
        }
    }
    if (filtertypes.length > 0)
        filtertypes = filtertypes.substr(1);
    if (filtervals.length > 0)
        filtervals = filtervals.substr(1);
    if (filterfields.length > 0)
        filterfields = filterfields.substr(1);

    var filters = filterfields + "|" + filtervals + "|" + filtertypes;
    //=============Grouping===================

    //=============Sorting==================

    //=============Columns==================

    var Cols = grid.GetCols("Visible");

    var sCols = "";

    for (var i = 0; i < Cols.length; i++) {

        var vCol = grid.Cols[Cols[i]];
        if (vCol) {
            if (vCol.Sec == 0) {
                if (vCol.Name != "Title")
                    sCols += "," + Cols[i] + "|" + vCol.Width;
                else
                    sCols += "," + Cols[i] + "|";
            }
        }
    }

    sCols = sCols.substr(1);

    EPMLiveCore.WorkEngineAPI.ExecuteJSON("timesheet_SaveView", "<View Name=\"" + retval[0] + "\" Default=\"" + retval[1] + "\" Filters=\"" + filters + "\" Group=\"" + grid.Group + "\" Sort=\"" + grid.Sort + "\" Cols=\"" + sCols + "\" Expand=\"\" />", function (response) {
        var oResponse = eval("(" + response + ")");
        grid.StaticCursor = 1;

        HideMessage(grid.id);

        if (oResponse.Views.Status == "0") {

            var newgridid = grid.id.substr(2);
            var newobj = eval("TSObject" + newgridid);

            newobj.Views = eval("(" + oResponse.Views.Text.replace(/&quot;/g, "\"") + ")");

            for (var view in newobj.Views) {
                var oView = newobj.Views[view];

                if (oView.Name == retval[0]) {
                    newobj.CurrentView = retval[0];
                    newobj.CurrentViewId = view;
                    break;
                }
            }

            RefreshCommandUI();
        }
        else {
            alert(oResponse.Views.Text);
        }
    });
}

function CheckApproveStatus(gridid) {

    var grid = Grids[gridid];

    EPMLiveCore.WorkEngineAPI.ExecuteJSON("timesheet_CheckApproveStatus", "<Timesheet ID=\"" + grid.TimesheetUID + "\" />", function (response) {
        var oResponse = eval("(" + response + ")");

        if (oResponse.ApproveStatus.Result == "0") {

            var status = "";
            var newgridid = grid.id.substr(2);
            var newobj = eval("TSObject" + newgridid);

            if (oResponse.ApproveStatus.Status == "2" || oResponse.ApproveStatus.Status == "-1") {

                if (TSApprovalMessage != null) {
                    SP.UI.Status.removeStatus(TSApprovalMessage);
                    TSApprovalMessage = null;
                }

                if (oResponse.ApproveStatus.ApprovalStatus == "1") {
                    newobj.Status = 'Approved';
                }
                else if (oResponse.ApproveStatus.ApprovalStatus == "2") {
                    newobj.Status = 'Rejected';
                }

                if (bTSApproving) {
                    bTSApproving = false;
                    RefreshCommandUI();
                }
            }
            else {
                if (!bTSApproving) {
                    bTSApproving = true;

                    newobj.Status = 'Approving';
                    RefreshCommandUI();
                }

                if (TSApprovalMessage == null) {
                    TSApprovalMessage = SP.UI.Status.addStatus('Approval:', 'Your timesheet is currently being approved.', true);
                    SP.UI.Status.setStatusPriColor(TSApprovalMessage, 'blue');
                }
                else {
                    SP.UI.Status.updateStatus(TSApprovalMessage, 'Your timesheet is currently being approved.');
                    SP.UI.Status.setStatusPriColor(TSApprovalMessage, 'blue');
                }

            }
        }
        else {
            alert(oResponse.ApproveStatus.Text);
        }

    });
}



Grids.OnFocus = function (grid, row, col, x, y, event) {

    curRow = row;

    DoPopUp(grid, row, col);

    RefreshCommandUI();
}

Grids.OnClick = function (grid, row, col, x, y, event) {

    if(!curPop)
        DoPopUp(grid, row, col);

}

function AutoAddWork(grid) {

    ShowMessage(grid.id, "Adding Work...", 130, 30);

    var rows = "";

    for (var R in grid.Rows) {
        var oRow = grid.Rows[R];
        if (oRow.Kind == "Data" && oRow.Def.Name == "R") {
            rows += "," + oRow.ListID + "." + oRow.ItemID;
        }
    }

    if (rows.length > 0)
        rows = rows.substr(1);

    EPMLiveCore.WorkEngineAPI.ExecuteJSON("timesheet_AutoAddWork", "<Timesheet ID=\"" + grid.TimesheetUID + "\" Rows=\"" + rows + "\" />", function (response) {

        var oResponse = eval("(" + response + ")");

        if (oResponse.AutoAddWork.Status == "0") {

            HideMessage(grid.id);

            CheckForUpdate(grid);

        }
        else {
            HideMessage(grid.id);

            alert(oResponse.AutoAddWork.Text);
        }

    });

}

function DoPopUp(grid, row, col) {
    if (curRow != row || curCol != col || (!curPop && TSColType == 2)) {

        curPop = false;

        if (curRow && curRow.Kind == "Data" && curRow.id != "-1" && curCol && TSCols[curCol]) {
            grid.SetAttribute(curRow, curCol, "HtmlPrefix", "", true, false);
        }

        curRow = row;
        curCol = col;
        curGrid = grid;

        var newgridid = grid.id.substr(2);
        var newobj = eval("TSObject" + newgridid);
        var bLocked = false;

        if (newobj.Locked)
            bLocked = true;
        if (newobj.Status != 'Unsubmitted')
            bLocked = true;
        if (grid.GetValue(row, "TSEnabled") != "1")
            bLocked = true;
        if (grid.GetAttribute(row, "CanEdit") == "0")
            bLocked = true;

        if (row && row.Kind == "Data" && row.id != "-1" && col && TSCols[col] && row.Def.Name == "R") {
            if (TSColType == 1) {
                if (TSNotes) {

                    var pVal = grid.GetValue(row, "TS" + col);

                    var image = "tsnonotes";

                    if (pVal != "") {
                        image = "tsnotes";
                    }

                    grid.EndEdit(true);

                    var strDivTag = "<div style='position: absolute; margin-left: 65px; cursor:pointer' onMouseDown=\"stopProp(event);\" onClick=\"showNotes(event);\"><img id=\"notesimg\" class=\"transparentnotes\" src=\"/_layouts/epmlive/images/" + image + ".png\"></div><div id='NotesDiv' style='position: absolute; margin-left: 65px; display:none; width:150px;height:100px;border: 1px solid black;background-color:#FFFFFF;cursor:pointer' onClick=\"stopProp(event);\"><textarea id='txtNotes' style='width:150px;height:75px;border:0px' onkeyup=\"stopProp(event);\" onclick=\"stopProp(event);\" onkeypress=\"stopProp(event);\"";

                    if (bLocked)
                        strDivTag += " disabled=\"disabled\"";

                    strDivTag += ">" + pVal + "</textarea><br><input type=\"button\" value=\"OK\" onCLick=\"SaveNotes(event);stopProp(event);\"></div>";



                    grid.SetAttribute(row, col, "HtmlPrefix", strDivTag, true, false);

                }
            }
            else if (TSColType == 2) {

                curPop = true;

                var strTypeDiv = "<div id='TypeDivOuter' style='position: absolute; margin-top: 20px; margin-left: 2px; cursor:default; width:156px; background-color: #EAEAEA; text-align:left;border: 1px solid gray; padding:3px;' onClick=\"stopProp(event);\"><table border=\"0\" cellspacing=\"3\" cellpadding=\"0\">";

                var pVal = grid.GetValue(row, "TS" + col);
                if (pVal == "")
                    pVal = "{}";

                var oVal = eval("(" + pVal + ")");

                for (var iType in TSTypeObject) {
                    var oType = TSTypeObject[iType];

                    strTypeDiv += "<tr><td>" + oType + ":</td><td align=\"right\"><input type=\"text\" class=\"epmliveinput\" onkeydown=\"stopProp(event);\" onkeyup=\"stopProp(event);\" onkeypress=\"stopProp(event);\" onmousedown=\"this.focus();this.select();stopProp(event);\" onmouseup=\"this.focus();this.select();stopProp(event);\" onClick=\"this.focus();this.select();stopProp(event);\" style=\"width:25px\" id=\"" + iType + "TypeValue\" Value=\"";

                    try {
                        if (oVal[iType]) {
                            strTypeDiv += oVal[iType];
                        }
                        else {
                            strTypeDiv += "0";
                        }
                    } catch (e) { }

                    strTypeDiv += "\"";

                    if (bLocked)
                        strTypeDiv += " disabled=\"disabled\"";

                    strTypeDiv += "></td></tr>";
                }

                if (TSNotes) {
                    var notes = "";
                    if (oVal["Notes"]) {
                        notes = oVal["Notes"];
                        notes = unescape(notes).replace(/<br>/g, "\r\n");
                    }

                    strTypeDiv += "<tr><td colspan=\"2\"><textarea class=\"epmliveinput\" id='txtNotes' style='width:140px;height:75px;' ondblclick=\"stopProp(event);\" onkeydown=\"stopProp(event);\" onkeyup=\"stopProp(event);\" onclick=\"stopProp(event);\" onkeypress=\"stopProp(event);\"";

                    if (bLocked)
                        strTypeDiv += " disabled=\"disabled\"";

                    strTypeDiv += ">" + notes + "</textarea></td></tr>";
                }

                strTypeDiv += "<tr><td colspan=\"2\" align=\"right\">";
                if(!bLocked)
                    strTypeDiv += "<input type=\"button\" value=\"OK\" class=\"tsOK\" onClick=\"SaveTypes(event);\">&nbsp;";
                    
                strTypeDiv += "<input type=\"button\" value=\"Cancel\" class=\"tsOK\" onClick=\"CloseTypes(event);\"></td></tr></table></div><div style='position: absolute; margin-top: -10px; margin-left: -9px '><img src='/_layouts/epmlive/images/tsoutline.png'></div>";

                grid.SetAttribute(row, col, "HtmlPrefix", strTypeDiv, true, false);

                setTimeout("curGrid.StartEdit()", 100);
            }

        }

    }
}

function CheckForUpdate(grid) {
    
    curGrid = grid;

    ShowMessage(grid.id, "Refreshing Timesheet", 180, 50);

    var rows = "";

    for (var R in grid.Rows) {
        var oRow = grid.Rows[R];
        if (oRow.Kind == "Data" && oRow.Def.Name == "R") {
            rows += "," + oRow.UID;
        }
    }

    if(rows.length > 0)
        rows = rows.substr(1);

    var dataxml = "&lt;Param";
    dataxml += " ID=\"" + grid.TimesheetUID + "\"";
    dataxml += " Rows=\"" + rows + "\"";
    dataxml += "/&gt;";

    grid.Data.Check.Param.Dataxml = dataxml;

    grid.CheckForUpdates(CheckedUpdates);
}

function CheckedUpdates() {

    var newgridid = curGrid.id.substr(2);
    var newobj = eval("TSObject" + newgridid);

    ChangeView(curGrid, newobj.CurrentViewId);

    HideMessage(curGrid.id);
}

Grids.OnIconClick = function (grid, row, col, x, y) {
    if (grid.id.substr(0, 2) == "TS") {
        if (x < 16) {
            if (col == "StopWatch") {
                if (StopWatchRow) {
                    if (StopWatchRow.UID == row.UID) {
                        if (confirm('Would you like to stop that stop watch now?')) {
                            StopStopWatch(grid, row);
                        }
                    }
                    else {
                        if (confirm('There is already a stop watch running. Would you like to stop that stopwatch and start this one?')) {
                            curGrid = grid;
                            curRow = row;
                            StopStopWatch(StopWatchGrid, StopWatchRow);
                            bStopWatchStartWaiting = true;
                        }
                        else {
                            bStopWatchStartWaiting
                        }
                    }
                } else {
                    StartStopWatch(grid, row);
                }
            }
        }
    }
}

Grids.OnValueChanged = function (grid, row, col, val) {

    if (grid.id.substr(0, 2) == "TS" && row && row.Kind == "Data" && row.id != "-1" && col && TSCols[col]) {
        if (val.toString() == "")
            val = "0";

        var tVal = GetDecimalFromTime(val);

        var oldVal = grid.GetValue(row, col);

        if (tVal.toString() == "NaN") {
            alert('That is not a valid entry.');
            val = oldVal;
        }
        else
            val = tVal;

        if (TSDCols[col]) {
            var minmax = TSDCols[col].split('|');
            var min = parseFloat(minmax[0]);
            var max = parseFloat(minmax[1]);
            if (val > max) {
                alert("You may only enter a maximum time of " + max + " hours");
                val = oldVal;
            }
            if (val < min) {
                alert("You must enter atleast time of " + min + " hours");
                val = oldVal;
            }
        }
    }
    return val;
}


function StopStopWatchClose(oDialogResult) {
    if (oDialogResult == SP.UI.DialogResult.OK) {

        if (TSColType == 1) {
            for (var SW in StopWatchResponse) {
                if (SW != "Status") {
                    var oSW = StopWatchResponse[SW];
                    var fVal = parseFloat(curStoppingGrid.GetValue(curStoppingRow, "P" + oSW.DateTicks));

                    if (isNaN(fVal))
                        fVal = 0;

                    fVal += parseFloat(oSW.Minutes) / 60;

                    curStoppingGrid.SetValue(curStoppingRow, "P" + oSW.DateTicks, parseFloat(fVal.toFixed(2)), 1, 0);
                }
            }
        }
        else if (TSColType == 2) {

            for (var SW in StopWatchResponse) {
                if (SW != "Status") {
                    var oSW = StopWatchResponse[SW];

                    var pVal = curStoppingGrid.GetValue(curStoppingRow, "TSP" + oSW.DateTicks);

                    var oVal = null;

                    if (pVal != "")
                        oVal = eval("(" + pVal + ")");

                    var fTotal = 0;
                    var bSet = false;
                    var newTypeVal = "";

                    for (var iType in TSTypeObject) {

                        var fVal = 0;

                        if (oVal && oVal[iType])
                            fVal = oVal[iType];

                        if (!bSet) {
                            fVal += parseFloat(oSW.Minutes) / 60;
                            bSet = true;
                        }

                        if (fVal != "NaN" && fVal != 0) {
                            newTypeVal += "," + iType + ": " + fVal.toFixed(2);

                            fTotal += fVal;
                        }
                    }

                    if (TSNotes && oVal && oVal.Notes) {
                        newTypeVal += ",Notes: \"" + oVal.Notes + "\"";
                    }

                    if (newTypeVal.length > 0)
                        newTypeVal = newTypeVal.substr(1);

                    newTypeVal = "{" + newTypeVal + "}";

                    curStoppingGrid.SetValue(curStoppingRow, "P" + oSW.DateTicks, parseFloat(fTotal.toFixed(2)), 1, 0);
                    curStoppingGrid.SetValue(curStoppingRow, "TSP" + oSW.DateTicks, newTypeVal, 0, 0);
                }
            }
        }

    }

    if (bStopWatchStartWaiting) {
        bStopWatchStartWaiting = false;
        StartStopWatch(curGrid, curRow);
    }
}

function StopStopWatch(grid, row) {
    var newgridid = grid.id.substr(2);
    var newobj = eval("TSObject" + newgridid);

    EPMLiveCore.WorkEngineAPI.ExecuteJSON("timesheet_StopStopWatch", "<StopWatch ID=\"" + row.UID + "\" UserId=\"" + newobj.UserId + "\"/>", function (response) {
        var oResp = eval("(" + response + ")");

        if (oResp.StopWatch.Status == "0") {

            var bApply = false;
            var htmlP = document.createElement('p');
            htmlP.setAttribute("style", "padding:10px");

            var htmlMsg = document.createTextNode("Would you like to apply the following to your timesheet: ");
            htmlP.appendChild(htmlMsg);
            htmlP.appendChild(document.createElement('br'));
            htmlP.appendChild(document.createElement('br'));


            StopWatchResponse = oResp.StopWatch;

            for (var oSW in oResp.StopWatch) {
                if (oSW != "Status") {
                    var oSWV = oResp.StopWatch[oSW];

                    var oDate = new Date(oSWV.Date);
                    var oMinutes = oSWV.Minutes;

                    var oCol = grid.Cols["P" + oSWV.DateTicks];

                    if (oCol) {
                        bApply = true;

                        var htmlMsg = document.createTextNode(oDate.format("MMM dd") + ": " + GetTimeDisplay(parseFloat(oMinutes) * 60 * 1000));
                        htmlP.appendChild(htmlMsg);
                        htmlP.appendChild(document.createElement('br'));
                    }
                }
            }

            if (bApply) {

                curStoppingGrid = grid;
                curStoppingRow = row;

                var inp = document.createElement('input')
                inp.setAttribute("type", "button");
                inp.setAttribute("value", "Yes");
                inp.setAttribute("onclick", "SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, 0);");

                htmlP.appendChild(document.createElement('br'));
                htmlP.appendChild(document.createElement('br'));
                htmlP.appendChild(inp);

                var inp2 = document.createElement('input')
                inp2.setAttribute("type", "button");
                inp2.setAttribute("value", "No");
                inp2.setAttribute("onclick", "SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.Cancel, 0);");
                htmlP.appendChild(inp2);

                var options = {
                    title: "Confirm Hours",
                    width: 300,
                    html: htmlP,
                    dialogReturnValueCallback: StopStopWatchClose
                };

                SP.UI.ModalDialog.showModalDialog(options);

            }
            else {
                alert("There were no dates to apply to this period");
            }

            grid.SetAttribute(row, "StopWatch", "Icon", "/_layouts/epmlive/images/tstimeroff.png", true, false);

            StopWatchRow = null;

            grid.SetValue(row, "StopWatch", "", 1, 0);

        }
        else {
            alert(oResp.StopWatch.Text);
        }
    });
}

function StartStopWatch(grid, row) {

    var newgridid = grid.id.substr(2);
    var newobj = eval("TSObject" + newgridid);

    if (IsLocked(grid)) {
        alert("You cannot start a stop watch on a submitted timesheet");
    }
    else
    {
        if (newobj.IsCurPeriod) {

            EPMLiveCore.WorkEngineAPI.ExecuteJSON("timesheet_StartStopWatch", "<StopWatch ID=\"" + row.UID + "\" UserId=\"" + newobj.UserId + "\"/>", function (response) {

                var oResp = eval("(" + response + ")");

                if (oResp.StopWatch.Status == "0") {

                    grid.SetValue(row, "StopWatch", oResp.StopWatch.Text, 1, 0);
                    grid.SetAttribute(row, "StopWatch", "Icon", "/_layouts/epmlive/images/tstimeron.png", true, false);

                    StopWatchRow = row;
                    StopWatchGrid = grid;
                    RefreshStopWatch();
                }
                else {
                    alert(oResp.StopWatch.Text);
                }
            });

        }
        else {
            if (newobj.CurPeriodId == 0) {
                alert("You can only start stopwatches within the period that the current date resides and there seems to be no period setup for today's date.");
            }
            else {
                if (confirm("You can only start stopwatches within the period that the current date resides. Would you like to switch to period: " + newobj.CurPeriodName + "?")) {
                    var url = newobj.TSURL;

                    if (url.indexOf("?") > 0)
                        url += "&";
                    else
                        url += "?";

                    location.href = url + "NewPeriod=" + newobj.CurPeriodId;
                }
            }
        }
    }
}

Grids.OnGetHtmlValue = function (grid, row, col, val) {
    if (grid.id.substr(0, 2) == "TS") {

        if (col == "StopWatch") {
            if (StopWatchRow && row.UID == StopWatchRow.UID) {

                var dt = new Date(val);

                var dtNow = new Date(new Date().getTime() - curServerDate);

                var diff = dtNow.getTime() - dt.getTime();

                return GetTimeDisplay(diff);

            }
        }
        else if (TSCols[col] || col == "TSTotals") {
            if (val == "0" || val == "")
                return "";
            return getFormattedNumber(val.toLocaleString());
        }
    }

}

function getFormattedNumber(Amount) {
    var DecimalSeparator = Number("1.2").toLocaleString().substr(1, 1);

    var AmountWithCommas = Amount.toLocaleString();
    var arParts = String(AmountWithCommas).split(DecimalSeparator);
    var intPart = arParts[0];
    var decPart = (arParts.length > 1 ? arParts[1] : '');
    decPart = (decPart + '00').substr(0, 2);
    if (parseInt(decPart) == 0) {
        decPart = "";
        DecimalSeparator = "";
    }
    return intPart + DecimalSeparator + decPart;
}


function GetTimeDisplay(val) {
    var msecPerMinute = 1000 * 60;
    var msecPerHour = msecPerMinute * 60;
    var msecPerDay = msecPerHour * 24;

    var days = Math.floor(val / msecPerDay);
    val = val - (days * msecPerDay);

    var hours = Math.floor(val / msecPerHour);
    val = val - (hours * msecPerHour);

    var minutes = Math.floor(val / msecPerMinute);
    val = val - (minutes * msecPerMinute);

    var seconds = Math.floor(val / 1000);

    if (days > 0) {
        return days + "d " + hours + "h " + minutes + "m";
    }
    else if (hours > 0) {
        return hours + "h " + minutes + "m";
    }
    else {
        return minutes + "m";
    }
}

function RefreshStopWatch() {
    if (StopWatchRow && StopWatchGrid) {

        StopWatchGrid.RefreshCell(StopWatchRow, "StopWatch");

        setTimeout("RefreshStopWatch()", 30000);

    }
}


function GetDecimalFromTime(time) {
    var sTime = time.split(':');
    var lTime = StringToNumber(sTime[0]);
    if (sTime.length > 1) {
        var rTime = StringToNumber(sTime[1]);

        rTime = rTime / 60;

        lTime += rTime;
    }

    return parseFloat(lTime.toFixed(2));
}

function CloseTypes(event) {
    
    curGrid.EndEdit(false);

    curGrid.SetAttribute(curRow, curCol, "HtmlPrefix", "", true, false);

    curPop = false;

    stopProp(event);
}

function SaveTypes(event) {
    curGrid.EndEdit(false);
    var newTypeVal = "";

    var fTotal = 0;

    for (var iType in TSTypeObject) {

        var sVal = document.getElementById(iType + "TypeValue").value;

        if (sVal != "") {

            var fVal = GetDecimalFromTime(sVal);

            if (fVal != "NaN" && fVal != 0) {
                newTypeVal += "," + iType + ": " + fVal;

                fTotal += fVal;
            }
        }
    }

    if (TSNotes) {
        newTypeVal += ",Notes: \"" + escape(document.getElementById("txtNotes").value.replace(/\r\n/g, "<br>")) + "\"";
    }

    if (newTypeVal.length > 0)
        newTypeVal = newTypeVal.substr(1);

    newTypeVal = "{" + newTypeVal + "}";

    curGrid.SetAttribute(curRow, curCol, "HtmlPrefix", "", true, false);
    curGrid.SetValue(curRow, curCol, fTotal, 1, 0);
    curGrid.SetValue(curRow, "TS" + curCol, newTypeVal, 0, 0);
    curPop = false;

    stopProp(event);
}

function SaveNotes(event) {

    var notes = document.getElementById("txtNotes").value;

    if (TSColType == 1) {
        curGrid.SetValue(curRow, "TS" + curCol, notes);
    }

    document.getElementById("NotesDiv").style.display = "none";
    var notesimg = document.getElementById("notesimg");

    if (notes == "") {
        notesimg.src = "/_layouts/epmlive/images/tsnonotes.png";
    }
    else {
        notesimg.src = "/_layouts/epmlive/images/tsnotes.png";
    }

    stopProp(event);
}

function stopProp(event) {
    if (event.stopPropagation) {
        event.stopPropagation();
    }
    else if (window.event) {
        window.event.cancelBubble = true;
    }
}

function showNotes(event) {


    var notesDiv = document.getElementById("NotesDiv");
    notesDiv.style.display = "";

    var notes = document.getElementById("txtNotes");
    notes.focus();

    stopProp(event);


}



//===========API Helpers===========

function BeforeSave(grid) {
    if (typeof TimesheetBeforeSave == 'function') {
        try {
            var retVal = TimesheetBeforeSave(grid);
            if (retVal.CanSave) {
                return true;
            }
            else {
                alert(retVal.Message);
                return false;
            }
        }
        catch (e) {
            alert("Error Checking Save: " + e);
        }
        return false;
    }
    else
        return true;
}

function AfterSave(grid) {
    if (typeof TimesheetAfterSave == 'function') {
        try {
            TimesheetAfterSave(grid);
        }
        catch (e) {
            alert("Error After Save: " + e);
        }
    }
}

function BeforeSubmit(grid) {
    if (typeof TimesheetBeforeSubmit == 'function') {
        try {
            var retVal = TimesheetBeforeSubmit(grid);
            if (retVal.CanSubmit) {
                return true;
            }
            else {
                alert(retVal.Message);
                return false;
            }
        }
        catch (e) {
            alert("Error Checking Submit: " + e);
        }
        return false;
    }
    else
        return true;
}

function IsLocked(grid)
{
    var newgridid = grid.id.substr(2);
    var newobj = eval("TSObject" + newgridid);

    if (newobj.Locked || bTSApproving)
        return true;
    if (newobj.Status != 'Unsubmitted')
        return true;
        
    return false;
}

function AfterSubmit(grid) {
    if (typeof TimesheetAfterSubmit == 'function') {
        try {
            TimesheetAfterSubmit(grid);
        }
        catch (e) {
            alert("Error After Submit: " + e);
        }
    }
}


function BeforeUnSubmit(grid) {
    if (typeof TimesheetBeforeUnSubmit == 'function') {
        try {
            var retVal = TimesheetBeforeUnSubmit(grid);
            if (retVal.CanUnSubmit) {
                return true;
            }
            else {
                alert(retVal.Message);
                return false;
            }
        }
        catch (e) {
            alert("Error Checking UnSubmit: " + e);
        }
        return false;
    }
    else
        return true;
}

function AfterUnSubmit(grid) {
    if (typeof TimesheetAfterUnSubmit == 'function') {
        try {
            TimesheetAfterUnSubmit(grid);
        }
        catch (e) {
            alert("Error After UnSubmit: " + e);
        }
    }
}

function fireEvent(element, event) {
    if (document.createEventObject) {
        // dispatch for IE
        var evt = document.createEventObject();
        return element.fireEvent('on' + event, evt)
    }
    else {
        // dispatch for firefox + others
        var evt = document.createEvent("HTMLEvents");
        evt.initEvent(event, true, true); // event type,bubbling,cancelable
        return !element.dispatchEvent(evt);
    }
}

function leavePage()
{
    if (curGrid.HasChanges())
    {
        if (!e) e = window.event;

	    e.returnValue = 'You have unsaved changes.';

	    if (e.stopPropagation) {
		    e.stopPropagation();
		    e.preventDefault();
	    }
    }
}

window.onbeforeunload = leavePage;

