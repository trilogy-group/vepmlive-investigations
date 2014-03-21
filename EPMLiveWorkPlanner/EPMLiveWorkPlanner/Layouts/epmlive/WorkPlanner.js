var curView = "";
var defaultView = "";
var AddLinkDirection;

var sResourceList = "";
var sChoiceList = "";
var sLookupList = "";

var publishStatusBox;
var canPublish = false;
var updateStatusBox;
var processUpdatesBox;
var taskorder;

var hasUpdates = false;
var curTempDate;

var bAgile = false;
var folderCell = "a";
var plannerCell = "b";
var agileCell = "";
var detailsCell = "d";
var allocCell = "c";
var oResourceList;

var bUseTeam = false;

var bCalcCost = false;
var bCalcWork = false;
var iWorkHours = 8;

var canShowDetails = false;

var divsaveTemplateDiv;

var oLinkedTasks;

var newtasktext = "Add New Task";

function SetSplashText(text) {

    document.getElementById("divSplashInfo").innerHTML = text;

}

function SaveTemplate() {

    if (!divsaveTemplateDiv)
        divsaveTemplateDiv = saveTemplateDiv;

    divsaveTemplateDiv.style.display = "";

    var options = { html: divsaveTemplateDiv, width: 350, height: 180, title: "Save As Template", dialogReturnValueCallback: SaveTemplateClose };

    SP.UI.ModalDialog.showModalDialog(options);

}

function SaveTemplateClose(dialogResult, returnValue) {
    if (dialogResult == SP.UI.DialogResult.OK) {
        if (returnValue != "") {
            ShowTDialog("Saving Template...");
            var x = Grids.WorkPlannerGrid.GetXmlData("Body,AllCols,NoIO", "");
            x = x.replace(/&/gi, "%26");

            var tVals = returnValue.split('`');

            dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=SaveTemplate&TemplateName=" + tVals[0] + "&Description=" + tVals[1] + "&PlannerID=" + sPlannerID + "&pjData=" + x, SaveTemplateCloseClose);

        }
    }
}

function SaveTemplateCloseClose(loader) {

    if (loader.xmlDoc.responseText != null) {
        HideTDialog();
        if (loader.xmlDoc.responseText != null) {
            if (loader.xmlDoc.responseText.trim() != "Success")
                alert(loader.xmlDoc.responseText);
            else
                alert("Template Saved");
        }
        else
            alert("Response contains no XML");
    }
}


function hideDetails(text) {
    canShowDetails = false;
    Grids.WorkPlannerDetail.MainTag.style.display = "none";
    document.getElementById("detailMulti").style.display = "";
    document.getElementById("detailMulti").innerText = text;

    document.getElementById("assignmentsDivInnerMulti").style.display = "";
    document.getElementById("assignmentsDivInnerMulti").innerText = text;
    document.getElementById("assignmentsDivInner").style.display = "none";

    document.getElementById("linksDivInnerMulti").style.display = "";
    document.getElementById("linksDivInnerMulti").innerText = text;
    document.getElementById("linksDivInner").style.display = "none";

    document.getElementById("notesDivInnerMulti").style.display = "";
    document.getElementById("notesDivInnerMulti").innerText = text;
    document.getElementById("notesDivInner2").style.display = "none";
}
function showDetails() {
    canShowDetails = true;
    Grids.WorkPlannerDetail.MainTag.style.display = "";
    document.getElementById("detailMulti").style.display = "none";

    document.getElementById("assignmentsDivInnerMulti").style.display = "none";
    document.getElementById("assignmentsDivInner").style.display = "";

    document.getElementById("linksDivInnerMulti").style.display = "none";
    document.getElementById("linksDivInner").style.display = "";

    document.getElementById("notesDivInnerMulti").style.display = "none";
    document.getElementById("notesDivInner2").style.display = "";
}

function getTop(obj) {
    var posY = obj.offsetTop;

    while (obj.offsetParent) {
        posY = posY + obj.offsetParent.offsetTop;
        if (obj == document.getElementsByTagName('body')[0]) { break }
        else { obj = obj.offsetParent; }
    }

    return posY;
}

function getLeft(obj) {
    var posY = obj.offsetLeft;

    while (obj.offsetParent) {
        posY = posY + obj.offsetParent.offsetLeft;
        if (obj == document.getElementsByTagName('body')[0]) { break }
        else { obj = obj.offsetParent; }
    }

    return posY;
}

function ShowResGrid() {
    if (isQueryShowResGrid()) {
        try {
            dhxLayout.cells(allocCell).collapse();
        } catch (e) { }
    }
    else {
        try {
            dhxLayout.cells(allocCell).expand();
        } catch (e) { }
    }
    RefreshCommandUI();
}

function ShowBacklog() {
    if (isQueryShowBacklog()) {
        try {
            dhxLayout.cells(agileCell).collapse();
        } catch (e) { }
    }
    else {
        try {
            dhxLayout.cells(agileCell).expand();
        } catch (e) { }
    }
    RefreshCommandUI();
}

function isQueryShowBacklog() {
    return !dhxLayout.cells(agileCell).isCollapsed();
}

function RollupSummaryForce(Col) {
    switch (Col) {
        case "PercentComplete":
        case "Duration":
            return true;
    };
    return false;
}

function isQueryShowResGrid() {
    return !dhxLayout.cells(allocCell).isCollapsed();
}

function OpenLocation(sLocation, sTitle) {
    var grid = Grids.WorkPlannerGrid;
    var row = grid.FRow;

    if (row) {

        var options = { url: "WorkPlannerLocation.aspx?locationurl=" + sLocation + "&listid=" + sTaskListId + "&taskuid=" + row.id + "&ProjectId=" + sItemID, width: 600, title: sTitle, dialogReturnValueCallback: CommentsClose };

        SP.UI.ModalDialog.showModalDialog(options);

    }
}

function CommentsClose(dialogResult, returnValue) {

    var grid = Grids.WorkPlannerGrid;
    var row = grid.FRow;

    ShowTDialog("Refreshing...");

    dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=GetRowInfo&listid=" + sTaskListId + "&taskuid=" + row.id + "&ProjectId=" + sItemID, CommentsCloseClose);
}

function CommentsCloseClose(loader) {
    HideTDialog();
    if (loader.xmlDoc.responseText != null) {

        try {

            if (loader.xmlDoc.responseText.trim().substr(0, 7) == "Success") {

                var Items = loader.xmlDoc.responseText.trim().substr(8).split(',');

                for (var Item in Items) {
                    var sItem = Items[Item];

                    var sItemData = sItem.split('|');
                    //var count = parseInt(sItemData[);
                    try {

                        var grid = Grids.WorkPlannerGrid;
                        var row = grid.FRow;
                        grid.SetValue(row, sItemData[0], sItemData[1]);
                        grid.RefreshCell(row, "Notifications");
                    } catch (e) { alert(e); }
                }

            } else {
                alert(loader.xmlDoc.responseText.trim());
            }
        } catch (e) { }
    }
}

function RollupSummaryField(Col) {

    if (bSummaryRollup) {
        if (Col == "Duration") {
            try {
                Grids.ProjectInfo.SetValue(Grids.ProjectInfo.GetRowById(Col), "V", Grids.WorkPlannerGrid.GetValue(Grids.WorkPlannerGrid.GetRowById("0"), Col), 1);
            } catch (e) { }
        }
        else {
            var o = oRollUp[Col];
            if (o != null || RollupSummaryForce(Col)) {
                if (Col == "ActualFinish") {
                    if (Grids.WorkPlannerGrid.GetValue(Grids.WorkPlannerGrid.GetRowById("0"), "PercentComplete") != 100) {
                        return;
                    }
                }
                try {
                    var newCol = Col;
                    if (newCol == "StartDate")
                        newCol = "Start";
                    if (newCol == "DueDate")
                        newCol = "Finish";

                    Grids.ProjectInfo.SetValue(Grids.ProjectInfo.GetRowById(newCol), "V", Grids.WorkPlannerGrid.GetValue(Grids.WorkPlannerGrid.GetRowById("0"), Col), 1);
                } catch (e) { }
            }
        }
    }
}

function AddResource() {

    var grid = Grids.WorkPlannerGrid;
    var row = grid.FRow;

    if (row != null) {
        addResourceDiv.style.display = "";

        //addResourceDiv.firstChild.nextSibling.nextSibling.value = curView;
        var select = addResourceDiv.firstChild.nextSibling.nextSibling;
        select.options.length = 0;

        var curRes = grid.GetValue(row, "AssignedTo").toString().split(';');

        var reses = new Object();

        for (var i = 0; i < curRes.length; i++) {
            reses[curRes[i]] = new Object();
        }

        var enums = grid.Cols["AssignedTo"].Enum.split('|');
        var enumkeys = grid.Cols["AssignedTo"].EnumKeys.split('|');
        var counter = 0;

        for (var oR in enums) {
            if (enumkeys[oR] != "" && reses[enumkeys[oR]] == null)
                select.options[select.options.length] = new Option(enums[oR], enumkeys[oR]);
        }

        var options = { html: addResourceDiv, width: 300, height: 280, title: "Select Resources", dialogReturnValueCallback: AddResourceClose };

        SP.UI.ModalDialog.showModalDialog(options);
    }
}

function AddResourceClose(dialogResult, returnValue) {

    if (dialogResult == SP.UI.DialogResult.OK && returnValue != "") {

        var grid = Grids.WorkPlannerGrid;
        var row = grid.FRow;

        var assns = row.AssignedTo.toString();



        var selectBox = returnValue;

        for (var i = 0; i < selectBox.options.length; ++i) {
            if (selectBox.options[i].selected) {
                if (assns == "") {
                    assns = selectBox.options[i].value;
                }
                else {
                    var found = false;
                    for (var assn in assns.split(';')) {
                        if (assns[assn] == returnValue) {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                        assns = assns + ";" + selectBox.options[i].value;
                }
            }
        }

        grid.SetValue(row, "AssignedTo", assns, 1);
        Grids.WorkPlannerDetail.SetValue(Grids.WorkPlannerDetail.GetRowById("AssignedTo"), "V", assns, 1);

        SetTaskAssignments(row);
        PopulateResourceTable(row, false);
    }
}

function RollDown(Row, Col) {

    var o = oRollDown[Col];

    if (o != null) {

        var Grid = Grids.WorkPlannerGrid;
        Row = Grid.GetRowById(Row.id);
        var child = Row.firstChild;
        while (child != null) {

            if (child.Def.Name == "Folder" || child.Def.Name == "Iteration") {
                if (Grid.GetValue(child, Col) == oldVal) {
                    Grid.SetValue(child, Col, Grid.GetValue(Row, Col), 1);
                    if (Col == "StartDate")
                        RollDownColFromParent(Grid, child, "DueDate");
                    RollDown(child, Col);
                }
            }
            else {
                Grid.SetValue(child, Col, Grid.GetValue(Row, Col), 1);
                if (Col == "StartDate")
                    RollDownColFromParent(Grid, child, "DueDate");
                RollDown(child, Col);
            }

            if (child.Def && child.Def.Name == "Assignment")
                CalcUsage(Grid, child);

            child = child.nextSibling;
        }
    }

}

function RollDownFromParent(grid, row) {

    var iRow = FindParentIteration(grid, row);

    if (iRow) {
        for (var rd in oRollDown) {
            grid.SetValue(row, rd, grid.GetValue(iRow, rd), true);
        }
    }
}

function RollDownColFromParent(grid, row, col) {

    var iRow = FindParentIteration(grid, row);

    if (iRow) {
        var o = oRollDown[col];

        if (o != null) {
            grid.SetValue(row, col, grid.GetValue(iRow, col), true);
        }
    }
}

function FindParentIteration(grid, row) {
    var parentRow = row.parentNode;
    if (parentRow && parentRow.Def) {
        if (parentRow.Def.Name == "Iteration")
            return parentRow;
        else
            return FindParentIteration(grid, parentRow);
    }

    return null;
}

function SetProjectInfoFieldsEdit() {
    for (var c in oRollUp) {
        var col = c;

        if (col != "StartDate") {

            if (col == "DueDate")
                col = "Finish";

            CopySummaryField(col, c);
            /*
            try {
                CopySummaryField(col, c);
                if (bSummaryRollup) {
                    Grids.ProjectInfo.GetRowById(col).CanEdit = 0;
                    Grids.ProjectInfo.SetValue(Grids.ProjectInfo.GetRowById(col), "V", Grids.WorkPlannerGrid.GetValue(Grids.WorkPlannerGrid.GetRowById("0"), c), 1);
                }
                else
                    Grids.ProjectInfo.GetRowById(col).CanEdit = 1;
            } catch (e) { }
            Grids.ProjectInfo.RefreshRow(Grids.ProjectInfo.GetRowById(col));*/
        }
    }
    CopySummaryField("PercentComplete", "PercentComplete");
    CopySummaryField("Duration", "Duration");
}

function CopySummaryField(col, c) {
    try {
        if (bSummaryRollup) {
            Grids.ProjectInfo.GetRowById(col).CanEdit = 0;
            Grids.ProjectInfo.SetValue(Grids.ProjectInfo.GetRowById(col), "V", Grids.WorkPlannerGrid.GetValue(Grids.WorkPlannerGrid.GetRowById("0"), c), 1);
        }
        else
            Grids.ProjectInfo.GetRowById(col).CanEdit = 1;
    } catch (e) { }
    Grids.ProjectInfo.RefreshRow(Grids.ProjectInfo.GetRowById(col));
}

function GridHasChanges() {

    try {
        var sBin = Grids.WorkPlannerGrid.HasChanges().toString(2);
        if (sBin[sBin.length - 1] == "1" || !canPublish)
            return false;
        else
            return true;

    } catch (e) { }

    return false;
}

/*
function SetResourceList() {

    sResourceList = "";

    var chks = document.all["chkResList"];

    for(var i = 0;i<chks.length;i++)
    {
        if (chks[i].checked || chks[i].selected)
            sResourceList += "," + chks[i].value;
    }

    try
    {
        sResourceList = sResourceList.substr(1);
    } catch (e) { }

}

function SetLookupList() {

    sLookupList = "";

    var chks = document.all["chkLookupList"];

    for (var i = 0; i < chks.length; i++) {
        if (chks[i].checked || chks[i].selected)
            sLookupList += "," + chks[i].value;
    }

    try {
        sLookupList = sLookupList.substr(1);
    } catch (e) { }

}

function SetChoiceList() {

    sChoiceList = "";

    var chks = document.all["chkChoiceList"];

    for (var i = 0; i < chks.length; i++) {
        if (chks[i].checked)
            sChoiceList += "," + chks[i].value;
    }

    try {
        sChoiceList = sChoiceList.substr(1);
    } catch (e) { }

}*/

function setWBSAndTaskID(Row, force) {
    if (!force)
        return;

    var Grid = Grids.WorkPlannerGrid;

    var turnoncalc = false;

    if (Grid.Calculated) {
        Grid.ActionCalcOff();
        turnoncalc = true;
    }

    try {

        var WBS = Grid.GetValue(Row, "WBS");

        if (Row.id == "0")
            taskorder = 0;

        var child = Row.firstChild;
        var cWBS = 0;

        var newWBS = "";

        while (child != null) {

            if (child.Def.Name != "Assignment") {
                taskorder++;
                cWBS++;

                if (WBS == "")
                    newWBS = cWBS.toString();
                else
                    newWBS = WBS + "." + cWBS.toString();

                Grid.SetValue(child, "taskorder", taskorder, 0, 0);
                try {
                    Grid.SetValue(child, "WBS", newWBS, 0, 0);
                } catch (e) { }
                try {
                    Grid.SetValue(child, "OutlineNumber", newWBS, 0, 0);
                } catch (e) { }
                //Grid.SetValue(child, "taskorder", taskorder, 0);
                //Grid.SetValue(child, "WBS", newWBS, 0);

                setWBSAndTaskID(child, force);
            }
            else {
                Grid.SetValue(child, "taskorder", taskorder, 0, 0);
                try {
                    Grid.SetValue(child, "WBS", WBS, 0, 0);
                } catch (e) { }
                try {
                    Grid.SetValue(child, "OutlineNumber", WBS, 0, 0);
                } catch (e) { }
                //Grid.SetValue(child, "taskorder", taskorder, 0);
                //Grid.SetValue(child, "WBS", WBS, 0);
            }

            child = child.nextSibling;
        }
    } catch (e) { }

    if (turnoncalc)
        grid.ActionCalcOn();
}



function ChangeTaskType(slt) {
    if (slt[0].selected)
        Grids.WorkPlannerGrid.SetValue(Grids.WorkPlannerGrid.FRow, "TaskType", "Shared", 1);
    else if (slt[1].selected)
        Grids.WorkPlannerGrid.SetValue(Grids.WorkPlannerGrid.FRow, "TaskType", "Individual", 1);

    DoAssignmentRollDown(Grids.WorkPlannerGrid, Grids.WorkPlannerGrid.FRow, 1, "Work");
    PopulateResourceTable(Grids.WorkPlannerGrid.FRow, false);
}

function PopulateResourceTable(Row, Force) {

    if (!isActiveRow(Row))
        return;

    var grid = Grids.WorkPlannerGrid;

    var wp = Grids.WorkPlannerAssignments;

    var slt = document.getElementById("slcttasktype");

    if (grid.GetValue(Row, "TaskType") == "" || grid.GetValue(Row, "TaskType") == "Shared") {
        slt.selectedIndex = 0;
        wp.Cols["Work"].CanEdit = 0;
    }
    else {
        slt.selectedIndex = 1;
        wp.Cols["Work"].CanEdit = 1;
    }

    for (var R in wp.Rows) {
        if (R != "Header" && R != "Toolbar")
            wp.RemoveRow(wp.GetRowById(R));
    }

    var oChild = Row.firstChild;

    while (oChild != null) {
        var def = oChild.Def.Name;

        if (def == "Assignment") {
            var newRow = wp.AddRow(null, null, true, oChild.id, null);
            newRow.NoColor = 1;
            newRow.NoUpload = 1;
            newRow.NoColorState = 1;

            wp.SetValue(newRow, "R", oChild.Title, 1);
            wp.SetValue(newRow, "Work", oChild.Work, 1);
        }

        oChild = oChild.nextSibling;
    }

}

function RollupAssignmentFields(row) {

}


function RollupAssignments(Row, Col, Type) {

    var grid = Grids.WorkPlannerGrid;

    switch (Type.toUpperCase()) {
        case "SUM":
            var oChild = Row.firstChild;
            var sum = 0;
            while (oChild != null) {

                var id = oChild.id;

                var def = oChild.Def.Name;

                if (def == "Assignment") {

                    try {
                        sum += grid.GetValue(oChild, Col);
                    } catch (e) { }
                }

                oChild = oChild.nextSibling;
            }

            grid.SetValue(Row, Col, sum, 1);
            break;
        case "MIN":
            var oChild = Row.firstChild;

            if (oChild != null) {

                val = grid.GetValue(oChild, Col);

                while (oChild != null) {

                    var id = oChild.id;

                    var def = oChild.Def.Name;

                    if (def == "Assignment") {

                        try {
                            if (grid.GetValue(oChild, Col) < val)
                                val = grid.GetValue(oChild, Col);
                        } catch (e) { }
                    }

                    oChild = oChild.nextSibling;
                }

                grid.SetValue(Row, Col, val, 1);
            }
            break;
        case "MAX":
            var oChild = Row.firstChild;

            if (oChild != null) {

                val = grid.GetValue(oChild, Col);

                while (oChild != null) {

                    var id = oChild.id;

                    var def = oChild.Def.Name;

                    if (def == "Assignment") {

                        try {
                            if (grid.GetValue(oChild, Col) > val)
                                val = grid.GetValue(oChild, Col);
                        } catch (e) { }
                    }

                    oChild = oChild.nextSibling;
                }

                grid.SetValue(Row, Col, val, 1);
            }
            break;
        case "PCT":
            var oChild = Row.firstChild;
            var sum = 0;
            var work = grid.GetValue(Row, "Work");
            if (work != 0) {
                while (oChild != null) {

                    var id = oChild.id;

                    var def = oChild.Def.Name;

                    if (def == "Assignment") {

                        try {
                            var aWork = grid.GetValue(oChild, "Work");
                            sum += ((aWork / work) * (grid.GetValue(oChild, Col) / 100)) * 100;
                        } catch (e) { }
                    }

                    oChild = oChild.nextSibling;
                }

                grid.SetValue(Row, Col, sum, 1);
            }
            break;
    };

}


function SaveProject() {
    var x = Grids.ProjectInfo.GetXmlData("Body", "V");
    x = x.replace(/&/gi, "%26");
    dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=SaveProject&ID=" + sItemID + "&PlannerID=" + sPlannerID + "&pjData=" + x, SaveProjectClose);
}

function SaveWorkPlan() {

    if (sUpdates != "") {
        ShowTDialog("Processing Updates...");
        dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=ProcessUpdates&ID=" + sItemID + "&PlannerID=" + sPlannerID + "&Updates=" + sUpdates, SaveUpdatesClose);
    }
    else {
        Grids.WorkPlannerGrid.ActionCalcOff();
        setWBSAndTaskID(Grids.WorkPlannerGrid.GetRowById('0'), true);
        Grids.WorkPlannerGrid.ActionCalcOn();
        ShowTDialog("Saving Project...");
        SaveProject();
    }

}

function SaveProjectClose(loader) {

    if (loader.xmlDoc.responseText != null) {
        HideTDialog();
        if (loader.xmlDoc.responseText != null) {
            if (loader.xmlDoc.responseText.trim() != "Success")
                alert(loader.xmlDoc.responseText);
            else {
                SaveMainGrid();
            }
        }
        else
            alert("Response contains no XML");
    }
}


function SaveMainGrid() {

    ShowTDialog("Saving Plan...");

    if (bAgile)
        SaveAgileGrid();

    Grids.WorkPlannerGrid.Save();

}

function SaveAgileGrid() {

    //ShowTDialog("Saving Plan...");

    //Grids.AgileGrid.Save();
}

function SaveUpdatesClose(loader) {

    if (loader.xmlDoc.responseText != null) {
        HideTDialog();
        if (loader.xmlDoc.responseText != null) {
            if (loader.xmlDoc.responseText.trim() != "Success")
                alert(loader.xmlDoc.responseText);
            else {
                sUpdates = "";
                CheckUpdatesBox();
                SaveWorkPlan();
            }
        }
        else
            alert("Response contains no XML");
    }
}

function SelectColumns() {
    Grids.WorkPlannerGrid.ActionShowColumns();
}

function SelectResColumns() {
    Grids.AllocationGrid.ActionShowColumns();
}

function DeleteView() {

    var newViews = new Object();

    if (confirm("Are you sure you want to delete that view?")) {
        for (var v in viewObject) {
            if (viewObject[v].title != curView)
                newViews[v] = viewObject[v];
        }

        viewObject = newViews;

        sm("dlgDeletingView", 130, 50);

        dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=DeleteView&title=" + curView + "&PlannerID=" + sPlannerID, onDeleteViewCloseResponse);
    }
}

function SetDepsGrid(grid, row) {
    var deps = grid.GetValue(row, "Descendants");

    var sDeps = deps.toString().split(";");

    var lGrid = Grids.WorkPlannerLinks;

    for (var R in lGrid.Rows) {
        if (R != "Header" && R != "Toolbar")
            lGrid.RemoveRow(lGrid.GetRowById(R));
    }

    if (sDeps != "") {
        for (var i = 0; i < sDeps.length; i++) {
            var sType = "";
            var sId = "";
            var sLag = 0;
            try {

                sId = sDeps[i];

                var sLagPos = sId.indexOf("-", 0);
                if (sLagPos == -1)
                    sLagPos = sId.indexOf("+", 0);

                if (sLagPos > 0) {
                    sLag = sId.substr(sLagPos);
                    sId = sId.substr(0, sLagPos);
                }

                if (sLag[0] == '+')
                    sLag = sLag.substr(1);

                sType = sId.substr(sId.length - 2, 2).toLowerCase();
                if (sType == "ss" || sType == "sf" || sType == "ff" || sType == "fs") {
                    sId = sId.substr(0, sId.length - 2).toUpperCase();
                    sType = sType.toUpperCase();
                }
                else
                    sType = "FS";
            } catch (e) { sType = "FS"; }



            var newRow = lGrid.AddRow(null, null, true, null, null);
            newRow.NoColor = 1;
            newRow.NoUpload = 1;
            newRow.NoColorState = 1;

            var gRow = grid.GetRowById(sId);
            if (gRow) {
                lGrid.SetValue(newRow, "N", gRow.Title, 1);
                lGrid.SetValue(newRow, "ID", sId, 1);
                lGrid.SetValue(newRow, "T", sType, 1);
                lGrid.SetValue(newRow, "L", sLag, 1);
            }
        }
    }
}


function onDeleteViewCloseResponse(loader) {
    hm("dlgDeletingView");
    if (loader.xmlDoc.responseText != null) {
        if (loader.xmlDoc.responseText.trim() != "Success")
            alert(loader.xmlDoc.responseText);
    }
    else
        alert("Response contains no XML");
}

function DoNewRow(bAgileGrid) {

    var grid = Grids.WorkPlannerGrid;
    var agrid = Grids.AgileGrid;

    grid.EndEdit(true);
    try {
        if (agrid)
            agrid.EndEdit(true);
    } catch (e) { }

    if (bAgile && !bAgileGrid) {
        var blRow = FindLastIterationRow(grid);

        if (!blRow) {
            alert("You must have at least 1 iteration created first");
            return;
        } else {
            var newRow = grid.AddRow(blRow, null, true, grid.GenerateId(), "Task");
        }
    }
    else {
        if (grid.GetLast(null, 0).id == "0")
            var newRow = grid.AddRow(grid.GetLast(null, 0), null, true, grid.GenerateId(), "Task");
        else {

            var lRow = grid.GetLast(null, 0);

            if (lRow.Def.Name == "Assignment")
                lRow = lRow.parentNode;

            var newRow = grid.AddRow(lRow.parentNode, null, true, grid.GenerateId(), "Task");

        }
    }

    if (bAgileGrid) {
        newRow = agrid.GetRowById(newRow.id);

        var ntRow = agrid.GetRowById("NewTask");

        for (var c in grid.Cols) {
            if (c != "id") {
                agrid.SetValue(newRow, c, agrid.GetValue(ntRow, c), 1, 0);
                agrid.SetValue(ntRow, c, "", 1, 0);
            }
        }

        agrid.SetValue(ntRow, "Title", "New Item", 1, 0);

        grid.HideRow(grid.GetRowById(newRow.id));

        ApplyDefaults(agrid, ntRow);

        grid.Focus(ntRow, "Title");
    }
    else {
        var ntRow = grid.GetRowById("NewTask");

        for (var c in grid.Cols) {
            if (c != "id") {
                grid.SetValue(newRow, c, grid.GetValue(ntRow, c), 1, 0);
                grid.SetValue(ntRow, c, "", 1, 0);
            }
        }

        grid.SetValue(ntRow, "Title", "New Item", 1, 0);

        ApplyDefaults(grid, ntRow);

        grid.Focus(ntRow, "Title");
    }
    return;
    if (bAgile)
        RollDownFromParent(grid, newRow);

    //setWBSAndTaskID(grid.GetRowById('0'));

    bNewRowHasChanged = false;

    return newRow;
}

function SetTaskAssignments(Row) {

    if (Row == null)
        return;

    var grid = Grids.WorkPlannerGrid;

    var turnoncalc = false;

    if (grid.Calculated) {
        grid.ActionCalcOff();
        turnoncalc = true;
    }

    Row = grid.GetRowById(Row.id);

    var assignments = Row.AssignedTo.toString();
    var assignmentsstring = grid.GetString(Row, "AssignedTo");

    grid.SetValue(Row, "ResourceNames", assignmentsstring, 1, 0);

    var oAssns = new Object();

    if (assignments != null) {

        var oArray = assignments.split(';');
        var oArrayString = assignmentsstring.split(';');
        var counter = 0;
        for (var assignment in oArray) {
            if (assignment != "") {
                assignment = oArray[assignment];
                oAssns[assignment] = oArrayString[counter++];
            }
        }

        var oChild = Row.firstChild;

        while (oChild != null) {

            var id = oChild.id;

            var def = oChild.Def.Name;

            oChild = oChild.nextSibling;

            if (def == "Assignment") {
                var resource = id.toString().split('.')[1];

                var assnObj = oAssns[resource];

                if (assnObj == null) {
                    grid.RemoveRow(grid.GetRowById(id));
                } else {
                    oAssns[resource] = null;
                }
            }
        }

        var assignmentcount = 0;

        for (var oAssn in oAssns)
            assignmentcount++;

        for (var oAssn in oAssns) {
            if (oAssns[oAssn] != null && oAssns[oAssn] != "") {
                newrow = grid.AddRow(Row, null, oShowAssignments, Row.id + "." + oAssn, "Assignment");
                //newrow = grid.CopyRow(Row, Row, null, false, false);
                grid.ChangeDef(newrow, "Assignment", oShowAssignments, 0);
                if (!oShowAssignments)
                    grid.HideRow(newrow);

                grid.SetValue(newrow, "Title", oAssns[oAssn], 1);
                grid.SetValue(newrow, "AssignedTo", oAssn, 1);
                grid.SetValue(newrow, "ResourceNames", oAssns[oAssn], 1);

                if (bCalcWork) {
                    if (Row.TaskType == "Individual") {
                        var st = Row.StartDate;
                        var en = Row.DueDate;
                        var diff = grid.DiffGanttDate(st, en, "h");
                        grid.SetValue(newrow, "Work", diff, 1);
                        RollupAssignments(Row, "Work", "SUM");
                        //SetPlannerFieldValue(newrow, "Work", diff, true);
                    }
                    else {

                        var fWork = 0;
                        try {
                            fWork = parseFloat(Row.Work);
                        } catch (e) { }

                        if (fWork == 0) {
                            var st = grid.GetValue(Row, "StartDate")
                            var en = grid.GetValue(Row, "DueDate")
                            var diff = grid.DiffGanttDate(st, en, "h");
                            // SetPlannerFieldValue(Row, "Work", diff, true);
                            grid.SetValue(Row, "Work", diff * assignmentcount, 1);
                        }
                    }
                }
                else {
                    grid.SetValue(newrow, "Work", 0, oShowAssignments);
                }
                //if(!oShowAssignments)
                //    grid.HideRow(newrow);

                RefreshResourceUsage(newrow.id);
                //hideNonFolders(newrow);
            }
        }

        //DoAssignmentRollDown(Grids.WorkPlannerGrid, Row, 1, "Work");

        //setTimeout("RollDownAllAssignmentFields('" + Row.id + "')", 1000);

        RollDownAllAssignmentFields(Row.id);

        CalculateAssignmentCosts(grid, Row);
    }

    if (turnoncalc)
        grid.ActionCalcOn();
}


function RollDownAllAssignmentFields(iRow) {
    var Row = Grids.WorkPlannerGrid.GetRowById(iRow);

    for (var c in Grids.WorkPlannerGrid.Cols) {
        if (IsAssignmentField(c)) {
            if (Row.TaskType == "" || Row.TaskType == "Shared")
                DoAssignmentRollDown(Grids.WorkPlannerGrid, Row, 0, c);
        }
        else if (c == "Work") {
            if (Row.TaskType == "" || Row.TaskType == "Shared")
                DoAssignmentRollDown(Grids.WorkPlannerGrid, Row, 1, "Work");
        }
        else if (c != "G" && c != "Panel" && c != "Title" && c != "AssignedTo") {
            DoAssignmentRollDown(Grids.WorkPlannerGrid, Row, 0, c);
        }
    }

    CalculateAssignmentCosts(Grids.WorkPlannerGrid, Row);
}

function IsAssignmentField(col) {
    switch (col) {
        case "ActualWork":
        case "PercentComplete":
        case "RemainingWork":
            return true;
    };
    return false;
}

function DoAssignmentRollDown(Grid, Row, Type, Col) {
    if (Col == "AssignedTo" || Col == "Title" || Col == "ResourceNames" || Col == "Descendants" || Col == "Predecessors")
        return;

    var val = Grid.GetValue(Row, Col);

    if (Type == 0) {

    }
    else if (Type == 1) {

        var count = 0;

        var oChild = Row.firstChild;

        while (oChild != null) {
            var def = oChild.Def.Name;

            if (def == "Assignment")
                count++;

            oChild = oChild.nextSibling;
        }

        try {
            if (count != 0)
                val = val / count;
        } catch (e) { }
    }


    var oChild = Row.firstChild;

    while (oChild != null) {
        var def = oChild.Def.Name;

        if (def == "Assignment") {
            Grid.SetValue(oChild, Col, val, 1); //TODO: change to 0

            if (Col == "Duration" || Col == "DueDate")
                Grids.WorkPlannerGrid.CheckGantt(oChild);
        }

        oChild = oChild.nextSibling;
    }
}

function GetProperDateVal(val, oFromRow, c) {

    var dtTo = new Date(val);

    if (parent.Grids.WorkPlannerGrid.GetValue(oFromRow, c) != "") {
        var dtFrom = new Date(parent.Grids.WorkPlannerGrid.GetValue(oFromRow, c));

    }
    else {
        if (parent.oRollUp[c] && parent.oRollUp[c].toLowerCase() == "max") {
            var dtFrom = new Date(parent.Grids.WorkPlannerGrid.RoundGanttDate(new Date(val).valueOf(), 2, null, null, null));
        }
        else {
            var dtFrom = new Date(parent.Grids.WorkPlannerGrid.RoundGanttDate(new Date(val).valueOf(), 8, null, null, null));
        }
    }

    dtTo.setHours(dtFrom.getHours());
    val = dtTo.valueOf();
    return val;
}

function SetCheckDates(start, finish) {

    var frow = Grids.WorkPlannerGrid.FRow;

    SetPlannerFieldValue(frow, "StartDate", GetProperDateVal(start, frow, "StartDate"), true);
    SetPlannerFieldValue(frow, "DueDate", GetProperDateVal(finish, frow, "DueDate"), true);

}

function CheckResources() {

    var grid = Grids.WorkPlannerGrid;
    var row = grid.FRow;

    var start = new Date(grid.GetValue(row, "StartDate")).format("yyyy-MM-dd");
    var finish = new Date(grid.GetValue(row, "DueDate")).format("yyyy-MM-dd");
    var work = grid.GetValue(row, "Work");
    var title = grid.GetValue(row, "Title");
    var res = grid.GetValue(row, "AssignedTo");


    var wurl = sWebUrl + "/_layouts/epmlive/workplanneraction.aspx?action=CheckResources&startdate=" + start + "&enddate=" + finish + "&work=" + work + "&resources=" + res + "&title=" + title + "&listid=" + sTaskListId + "&itemid=" + row.id + "&pitemid=" + sItemID;

    window.open(wurl, "CheckResources", config = 'height=500, width=700, toolbar=no, menubar=no, scrollbars=no, resizable=yes, location=no, directories=no, status=yes');
}

function MoreThan1Selected() {
    try {
        if (Grids.WorkPlannerGrid.GetSelRows().length > 1)
            return true;
    } catch (e) { }
    return false;
}


function Just1Selected() {
    try {
        if (Grids.WorkPlannerGrid.GetSelRows().length == 1)
            return true;
    } catch (e) { }
    return false;
}

function MoreThan0Selected() {
    try {
        if (Grids.WorkPlannerGrid.GetSelRows().length > 0)
            return true;
    } catch (e) { }
    return false;
}

function DeleteTasks() {
    var grid = Grids.WorkPlannerGrid;
    if (!grid.EditMode) {
        selRows = grid.GetSelRows();
        if (selRows.length > 0) {
            if (confirm("Are you sure you want to delete those task(s)?")) {
                var delRows = [];
                for (var i = 0; i < selRows.length; i++) {
                    delRows.push(selRows[i].id);
                }

                for (var i = 0; i < delRows.length; i++) {
                    try {
                        var row = grid.GetRowById(delRows[i]);
                        grid.DeleteRow(row, 2);
                        grid.RemoveRow(row);
                    } catch (e) { }
                }
            }

        }
    }
}
function EditView() {
    Grids.WorkPlannerGrid.ActionBlur();

    viewNameDiv.style.display = "";

    viewNameDiv.firstChild.nextSibling.nextSibling.value = curView;

    var def = false;

    for (var v in viewObject) {
        if (viewObject[v].title == curView)
            def = true;
        break;
    }

    viewNameDiv.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.style.display = "none";

    var options = { html: viewNameDiv, width: 300, height: 150, title: "Rename View", dialogReturnValueCallback: onEditViewClose };

    SP.UI.ModalDialog.showModalDialog(options);
}

function onEditViewClose(dialogResult, returnValue) {
    if (dialogResult == SP.UI.DialogResult.OK) {

        ShowTDialog("Saving View...");

        dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=RenameView&oldtitle=" + curView + "&newtitle=" + assignments + "&PlannerID=" + sPlannerID, onEditViewCloseResponse);

    }
}


function onEditViewCloseResponse(loader) {
    if (loader.xmlDoc.responseText != null) {
        HideTDialog();
        if (loader.xmlDoc.responseText.trim() != "Success")
            alert(loader.xmlDoc.responseText);
    }
    else
        alert("Response contains no XML");
}

/*function CopyAllSummaryFields() {
    for (var c in Grids.WorkPlannerGrid.Cols) {
        if (c == 'Title')
            CopySummaryField(c, sProjectName);
        else
            CopySummaryField(c);
    }
}

function CopySummaryField(Col, Val) {

    var wgrid = Grids.WorkPlannerGrid;
    
    if (Col == "Title")
        Val = sProjectName;

    if (Val != null) {
        wgrid.SetValue(wgrid.GetRowById("Summary"), Col, Val, 1, 0);
    }
    else {
        wgrid.SetValue(wgrid.GetRowById("Summary"), Col, wgrid.GetValue(grid.GetRowById("0"), Col), 1, 0);
    }
}*/

function ShowBaseline() {
    var grid = Grids.WorkPlannerGrid;
    var col = grid.Cols["G"];
    if (col.GanttFlow == "")
        col.GanttFlow = "BaselineDateRange";
    else
        col.GanttFlow = "";

    grid.RefreshGantt(1, null);

    RefreshCommandUI();
}

function isShowBaseline() {
    var col = Grids.WorkPlannerGrid.Cols["G"];
    if (col.GanttFlow == "")
        return false;
    else
        return true;
}

function ResizeGantt(fromgrid, togrid) {


    var col = "G";
    var fWidth = fromgrid.GetBodyWidth(0) + fromgrid.GetBodyWidth(1);
    var tWidth = togrid.GetAttribute(null, "NAME", "Width");

    var dx = fWidth - tWidth;


    //alert(new Date(fromgrid.GetAttribute(null, "G", "GanttChartMinStart")));

    togrid.SetWidth("NAME", dx);
    togrid.Rerender();

    Grids.AllocationGrid.ChangeZoom(Grids.WorkPlannerGrid.Cols["G"].GanttZoom);
}

function iChangeView(view, bHide) {
    curView = viewObject[view]["title"];

    var grid = Grids.WorkPlannerGrid;

    var cols = viewObject[view]["cols"].split(",");
    var leftCols = viewObject[view]["leftCols"].split(",");
    var allCols = (viewObject[view]["leftCols"] + "," + viewObject[view]["cols"] + ",G").split(",");

    var vCols = grid.GetCols("Visible");

    var oViews = {};
    var lViews = {};

    for (var i = 0; i < leftCols.length; i++) {
        lViews[leftCols[i]] = new Object();
        lViews[leftCols[i]] = 0;
        if (leftCols[i] != "Panel") {
            grid.MoveCol(leftCols[i], 0, 1, 1);
            try {
                grid.Cols[leftCols[i]].Visible = 1;
            } catch (e) { }
        }
    }

    for (var i = 0; i < cols.length; i++) {
        oViews[cols[i]] = new Object();
        oViews[cols[i]] = 1;

        grid.MoveCol(cols[i], 1, 1, 1);
        try {
            grid.Cols[cols[i]].Visible = 1;
        } catch (e) { }
    }



    for (var c in grid.Cols) {
        if (oViews[c] == null && lViews[c] == null && c != "G") {
            oViews[c] = new Object();
            oViews[c] = 0;
        }
    }

    var mainCols = [];
    var counter = 0;

    //for (var c in oViews)
    //    mainCols[counter++] = c;

    for (var i = 0; i < vCols.length; i++) {
        var found = false;
        for (var j = 0; j < allCols.length; j++) {
            if (allCols[j] == vCols[i])
                found = true;
        }
        if (!found)
            mainCols.push(vCols[i]);
    }

    grid.ChangeColsVisibility(allCols, mainCols, 0);
    grid.ShowCol("Notifications");
    grid.ShowCol("Panel");
    //grid.ChangeColsVisibility(allCols, "", 0);

    try {
        if (viewObject[view]["gantt"] == "1")
            grid.ShowCol("G");
        else if (grid.Cols["G"].Visible)
            grid.HideCol("G");
    } catch (e) { }
    //if (viewObject[view]["folders"] == "true" && bUseFolders)
    //    dhxLayout.cells(folderCell).expand();
    //else
    //    dhxLayout.cells(folderCell).collapse();

    if (viewObject[view]["details"] == "true")
        dhxLayout.cells(detailsCell).expand();
    else
        dhxLayout.cells(detailsCell).collapse();

    try {
        if (viewObject[view]["allocation"] == "true")
            dhxLayout.cells(allocCell).expand();
        else
            dhxLayout.cells(allocCell).collapse();
    } catch (e) { }

    //================Filters================
    if (viewObject[view]["filters"] == "") {
        grid.ChangeFilter("", "", "", 0, 0, null);
        grid.ActionFilterOff();
    }
    else {
        var filters = viewObject[view]["filters"].split("^");
        try {
            if (filters[0] == "1" || filters[0] == "true")
                grid.ShowRow(grid.GetRowById("Filter"));
            else
                grid.HideRow(grid.GetRowById("Filter"));
        } catch (e) { }
        if (filters[0] == "1")
            grid.ChangeFilter(filters[1], filters[2], filters[3], 0, 0, null);
        else
            grid.ActionFilterOff();
    }
    //==============sorting======================
    grid.sort = viewObject[view]["sorting"];
    grid.SortRows();
    //=============grouping=====================
    if (viewObject[view]["grouping"] == "") {
        grid.DoGrouping(null);
    }
    else {
        var grouping = viewObject[view]["grouping"].split("^");

        if (grouping[0] == "true" || grouping[0] == "1")
            grid.ShowRow(grid.GetRowById("GroupRow"));
        else
            grid.HideRow(grid.GetRowById("GroupRow"));

        grid.DoGrouping(grouping[1]);
    }


    /*
    try
    {
    var row = grid.GetRowById("0");

    if (viewObject[view]["0"] == "true" || viewObject[view]["summary"] == "1")
    grid.ShowRow(row);
    else
    grid.HideRow(row);
    }catch(e){}*/
    //=========================================

    RefreshCommandUI();

    grid.Render();

    if (bAgile) {
        ChangeAgileView(view);
        Grids.AgileGrid.ShowCol("id");
        HideBacklogRows(grid, grid.GetRowById("BacklogRow"));
        grid.HideRow(grid.GetRowById("BacklogRow"));
    }

    try {
        if (viewObject[view]["assignments"] == "true" || viewObject[view]["assignments"] == "1")
            oShowAssignments = true;
        else
            oShowAssignments = false;

        HideShowAssignments();
    } catch (e) { }

    if (bHide)
        HideTDialog();
}

function ChangeView(view) {

    ShowTDialog("Changing View...");

    setTimeout("iChangeView('" + view + "', true)", 100);
}

function SaveView() {

    Grids.WorkPlannerGrid.ActionBlur();

    viewNameDiv.style.display = "";

    viewNameDiv.firstChild.nextSibling.nextSibling.value = curView;

    var def = false;

    for (var v in viewObject) {
        if (viewObject[v].title == curView)
            def = true;
        break;
    }

    viewNameDiv.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.style.display = "";

    if (def)
        viewNameDiv.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.checked = true;
    else
        viewNameDiv.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.checked = false;

    var options = { html: viewNameDiv, width: 300, height: 150, title: "Save View", dialogReturnValueCallback: onSaveViewClose };

    SP.UI.ModalDialog.showModalDialog(options);

}

function onSaveViewClose(dialogResult, returnValue) {

    if (dialogResult == SP.UI.DialogResult.OK) {

        var vals = returnValue.split("|");

        if (checkViewName(vals[0])) {
            var grid = Grids.WorkPlannerGrid;

            var leftCols = "";
            var cols = "";

            var vCols = grid.GetCols("Visible");

            for (var i = 0; i < vCols.length; i++) {

                var vCol = grid.Cols[vCols[i]];

                if (vCol.Sec == 0)
                    leftCols += "," + vCols[i];
                else if (vCol.Sec == 1)
                    cols += "," + vCols[i];
            }

            try {
                cols = cols.substr(1);
            } catch (e) { }
            try {
                leftCols = leftCols.substr(1);
            } catch (e) { }

            var key = vals[0].replace(/ /gi, "");

            if (viewObject[key] == null)
                viewObject[key] = new Object();

            //TODO: grouping
            //======Filters=======
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

            var filters = grid.GetRowById("Filter").Visible.toString() + "^" + filterfields + "^" + filtervals + "^" + filtertypes;

            //===========Grouping=========
            var grouping = grid.GetRowById("GroupRow").Visible.toString() + "^" + grid.Group;

            //===========Gantt============
            var gantt = grid.Cols["G"].Visible;

            //===========Sorting==========
            var sorting = grid.Sort;

            //===========Folders==========
            var folders = !dhxLayout.cells(folderCell).isCollapsed();

            //===========Detail===========
            var details = !dhxLayout.cells(detailsCell).isCollapsed();
            //==========Allocation=========
            var allocation = !dhxLayout.cells(allocCell).isCollapsed();
            //============Summary=========
            var summary = grid.GetRowById("0").Visible.toString();
            //============Assignedments=====
            var assignments = oShowAssignments.toString();

            viewObject[key]["title"] = vals[0];
            viewObject[key]["leftCols"] = leftCols;
            viewObject[key]["cols"] = cols;
            viewObject[key]["gantt"] = gantt.toString();
            viewObject[key]["folders"] = folders.toString();
            viewObject[key]["details"] = details.toString();
            viewObject[key]["filters"] = filters;
            viewObject[key]["sorting"] = sorting;
            viewObject[key]["grouping"] = grouping;
            viewObject[key]["summary"] = summary;
            viewObject[key]["assignments"] = assignments;
            viewObject[key]["allocation"] = allocation;

            curView = vals[0];

            RefreshCommandUI();

            sm("dlgSavingView", 130, 50);

            dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=SaveView&title=" + vals[0] + "&assignments=" + assignments + "&summary=" + summary + "&leftcols=" + leftCols + "&cols=" + cols + "&default=" + vals[1] + "&gantt=" + gantt + "&details=" + details + "&folders=" + folders + "&filters=" + filters + "&sorting=" + sorting + "&grouping=" + grouping + "&allocation=" + allocation + "&PlannerID=" + sPlannerID + GetAgileViewParam(key), onSaveViewCloseResponse);

        }
    }
}

function GetAgileViewParam(key) {
    if (bAgile) {

        var grid = Grids.AgileGrid;
        //===========Grouping=========
        var grouping = grid.GetRowById("GroupRow").Visible.toString() + "^" + grid.Group;
        //===========Gantt============
        var gantt = grid.Cols["G"].Visible;
        //===========Sorting==========
        var sorting = grid.Sort;

        var leftCols = "";
        var cols = "";

        var vCols = grid.GetCols("Visible");

        for (var i = 0; i < vCols.length; i++) {

            var vCol = grid.Cols[vCols[i]];

            if (vCol.Sec == 0)
                leftCols += "," + vCols[i];
            else if (vCol.Sec == 1)
                cols += "," + vCols[i];
        }

        try {
            cols = cols.substr(1);
        } catch (e) { }
        try {
            leftCols = leftCols.substr(1);
        } catch (e) { }

        //======Filters=======
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

        var filters = grid.GetRowById("Filter").Visible.toString() + "^" + filterfields + "^" + filtervals + "^" + filtertypes;

        viewObject[key]["agileleft"] = leftCols;
        viewObject[key]["agilecols"] = cols;
        viewObject[key]["agilegantt"] = gantt.toString();
        viewObject[key]["agilefilters"] = filters;
        viewObject[key]["agilesorting"] = sorting;
        viewObject[key]["agilegrouping"] = grouping;
        viewObject[key]["backlog"] = backlog;

        //===========Detail===========
        var backlog = !dhxLayout.cells(agileCell).isCollapsed();

        return "&agileleft=" + leftCols + "&agilecols=" + cols + "&agilegantt=" + gantt.toString() + "&agilefilters=" + filters + "&agilesorting=" + sorting + "&agilegrouping=" + grouping + "&backlog=" + backlog;
    }
    else
        return "";
}

function ClearSort() {
    Grids.WorkPlannerGrid.ChangeSort("taskorder");
    //Grids.WorkPlannerGrid.Sort = "";
    //Grids.WorkPlannerGrid.SortRows();
}

function isShowFilters() {
    try {
        var grid = Grids.WorkPlannerGrid;
        var row = grid.GetRowById("Filter");
        return row.Visible;
    } catch (e)
    { }
    return false;
}

function ShowFilters() {
    var grid = Grids.WorkPlannerGrid;
    var row = grid.GetRowById("Filter");
    try {
        if (row.Visible)
            grid.HideRow(row);
        else
            grid.ShowRow(row);
    } catch (e) { }
}

function checkViewName(viewName) {

    if (viewName == "Default View") {
        alert("You can't overwrite the Default View");
        return false;
    }
    if (viewObject[viewName] != null) {
        return confirm("Would you like to overwrite that view?");
    }
    //TODO:
    return true;

}

function onSaveViewCloseResponse(loader) {
    if (loader.xmlDoc.responseText != null) {
        hm("dlgSavingView");
        if (loader.xmlDoc.responseText.trim() != "Success")
            alert(loader.xmlDoc.responseText);
    }
    else
        alert("Response contains no XML");
}

function DoCreateNew(fieldinfo, hasproject) {

    ShowTDialog("Posting Data...");

    var sFieldInfo = fieldinfo.split('.');

    var params = "listid=" + sProjectListId + "&lookups=" + escape(sProjectName) + "&field=" + sFieldInfo[0] + "&LookupFieldList=" + sFieldInfo[1];

    dhtmlxAjax.post("gridaction.aspx?action=linkeditemspost", params, DoCreateNewPost);


    //var options = { url: "WorkPlannerAction.aspx?Action=GoToList&ID=" + sItemID + "&PlannerID=" + sPlannerID + "&list=" + list + "&hasproject=" + hasproject, showMaximized: true };

    //SP.UI.ModalDialog.showModalDialog(options);
}

function DoCreateNewPost(ret) {
    HideTDialog();


    var ticket = ret.xmlDoc.responseText;

    if (ticket.indexOf("General Error") != 0) {
        var listInfo = ticket.split('|');

        var weburl = listInfo[0] + "/_layouts/epmlive/gridaction.aspx?action=linkeditems&list=" + listInfo[3] + "&field=" + listInfo[1] + "&LookupFieldList=" + listInfo[2];

        var options = { url: weburl, showMaximized: true };

        SP.UI.ModalDialog.showModalDialog(options);
    }
    else {
        alert(ticket);
    }
}

function DeleteResource() {
    if (confirm("Are you sure you want to delete that resource assignment?")) {
        var grid = Grids.WorkPlannerAssignments;
        if (grid.FRow != null) {
            grid.RemoveRow(grid.FRow);

            UpdateAssignments(grid);
        }
    }
}

function UpdateAssignments(grid) {
    var deps = "";
    for (var R in grid.Rows) {
        if (R != "Header" && R != "Toolbar") {
            var row = grid.GetRowById(R);

            deps += ";" + row.id.toString().split('.')[1];
        }
    }
    if (deps != "")
        deps = deps.substr(1);

    var mainRow = Grids.WorkPlannerGrid.GetRowById(Grids.WorkPlannerGrid.FRow.id);

    Grids.WorkPlannerGrid.SetValue(mainRow, "AssignedTo", deps, 1);
    Grids.WorkPlannerDetail.SetValue(Grids.WorkPlannerDetail.GetRowById("AssignedTo"), "V", deps, 1);

    SetTaskAssignments(mainRow);
    PopulateResourceTable(mainRow, false);

    try {
        if (mainRow.TaskType == "Individual")
            RollupAssignments(mainRow, "Work", "SUM");
    } catch (e) { }
}

function PopulateCreateNew() {
    var sb = new Sys.StringBuilder();
    sb.append('<Menu Id=\'Ribbon.WorkPlanner.CreateNew.Dropdown.Menu\'>');
    sb.append('<MenuSection DisplayMode=\'Menu\' Id=\'Ribbon.WorkPlanner.CreateNew.Dropdown.Menu.Default\' Title=\'Lists\'>');
    sb.append('<Controls Id=\'Ribbon.WorkPlanner.CreateNew.Dropdown.Menu.Default.Controls\'>');

    for (var i = 0; i < oAttachedLists.length; i++) {

        var sAList = oAttachedLists[i].split(',');

        sb.append('<Button');
        sb.append(' Id=\'Ribbon.WorkPlanner.DisplayView.CreateNewItem');
        sb.append('\'');
        sb.append(' Command=\'');
        if (sAList[1] == "True")
            sb.append('Ribbon.WorkPlanner.DoCreateNew');
        else
            sb.append('Ribbon.WorkPlanner.DoCreateNewNoProject');
        sb.append('\'');
        sb.append(' LabelText=\'' + sAList[0] + '');
        sb.append('\'');
        sb.append(' CommandValueId=\'' + sAList[1] + '\'');
        sb.append('/>');

    }

    sb.append('</Controls>');
    sb.append('</MenuSection>');

    sb.append('<MenuSection DisplayMode=\'Menu\' Id=\'Ribbon.WorkPlanner.CreateNew.Dropdown.Menu.Default2\' Title=\'Document Libraries\'>');
    sb.append('<Controls Id=\'Ribbon.WorkPlanner.CreateNew.Dropdown.Menu.Default.Controls\'>');

    for (var i = 0; i < oAttachedDocLibs.length; i++) {
        var sAList = oAttachedDocLibs[i].split(',');
        sb.append('<Button');
        sb.append(' Id=\'Ribbon.WorkPlanner.DisplayView.CreateNewItem');
        sb.append('\'');
        sb.append(' Command=\'');
        if (sAList[1] == "True")
            sb.append('Ribbon.WorkPlanner.DoCreateNew');
        else
            sb.append('Ribbon.WorkPlanner.DoCreateNewNoProject');
        sb.append('\'');
        sb.append(' LabelText=\'' + sAList[0] + '');
        sb.append('\'');
        sb.append(' CommandValueId=\'' + sAList[1] + '\'');
        sb.append('/>');

    }

    sb.append('</Controls>');
    sb.append('</MenuSection>');

    sb.append('</Menu>');
    return sb.toString();
}

function PopulateDisplayView() {

    var sb = new Sys.StringBuilder();
    sb.append('<Menu Id=\'Ribbon.WorkPlanner.DisplayView.Dropdown.Menu\'>');
    sb.append('<MenuSection DisplayMode=\'Menu\' Id=\'Ribbon.WorkPlanner.DisplayView.Dropdown.Menu.Default\'>');
    sb.append('<Controls Id=\'Ribbon.WorkPlanner.DisplayView.Dropdown.Menu.Default.Controls\'>');

    //sb.append('<Button');
    //sb.append(' Id=\'Ribbon.WorkPlanner.DisplayView.DefaultView\'');
    //sb.append(' Command=\'Ribbon.WorkPlanner.DisplayView.DoDisplayView\'');
    //sb.append(' LabelText=\'Default View\'');
    //sb.append(' CommandValueId=\'DefaultView\'');
    //sb.append('/>');

    var hasOne = false;

    for (var v in viewObject) {

        sb.append('<Button');
        sb.append(' Id=\'Ribbon.WorkPlanner.DisplayView.' + v);
        sb.append('\'');
        sb.append(' Command=\'');
        sb.append('Ribbon.WorkPlanner.DisplayView.DoDisplayView');
        sb.append('\'');
        sb.append(' LabelText=\'' + viewObject[v].title + '');
        sb.append('\'');
        sb.append(' CommandValueId=\'' + v + '\'');
        sb.append('/>');

        if (!hasOne) {
            if (curView == "")
                curView = viewObject[v].title;

            sb.append('</Controls>');
            sb.append('</MenuSection>');

            sb.append('<MenuSection DisplayMode=\'Menu\' Id=\'Ribbon.WorkPlanner.DisplayView.Dropdown.Menu.Default\' Title=\'Custom Views\'>');
            sb.append('<Controls Id=\'Ribbon.WorkPlanner.DisplayView.Dropdown.Menu.Default.Controls\'>');

            hasOne = true;
        }
    }

    sb.append('</Controls>');
    sb.append('</MenuSection>');

    sb.append('</Menu>');
    return sb.toString();

}


function IsShowGantt() {
    var grid = Grids.WorkPlannerGrid;
    return grid.Cols.G.Visible;
}

function ZoomIn() {
    if (CanZoomIn()) {
        //curZoom++;

        Grids.WorkPlannerGrid.ActionZoomIn();
        //Grids.AllocationGrid.ChangeZoom(Grids.WorkPlannerGrid.Cols["G"].GanttZoom);

        //ScrollTo();
        RefreshCommandUI();
    }
}

function ZoomOut() {
    if (CanZoomOut()) {
        //curZoom--;

        Grids.WorkPlannerGrid.ActionZoomOut();
        //Grids.AllocationGrid.ChangeZoom(Grids.WorkPlannerGrid.Cols["G"].GanttZoom);
        //ScrollTo();
        RefreshCommandUI();
    }
}

function ShowHideGantt() {
    var grid = Grids.WorkPlannerGrid;
    if (grid.Cols.G.Visible)
        grid.HideCol("G");
    else {
        grid.ShowCol("G");
        ResizeGantt(grid, Grids.AllocationGrid);
    }
}

function ZoomFit() {

    Grids.WorkPlannerGrid.ActionZoomFit();
    Grids.AllocationGrid.ActionZoomFit();

    RefreshCommandUI();

}

function CanZoomOut() {
    try {
        return Grids.WorkPlannerGrid.CanZoomOut();
    } catch (e) { }
    return false;
}

function CanZoomIn() {
    try {
        return Grids.WorkPlannerGrid.CanZoomIn();
    } catch (e) { }
    return false;
}

function AddLinkMenu(direction) {

    AddLinkDirection = direction;

    addlinkdiv.style.display = "";

    addlinkdiv.firstChild.nextSibling.value = "FS";

    addlinkdiv.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.value = "0";

    var options = { html: addlinkdiv, width: 300, height: 150, title: "Add Link", dialogReturnValueCallback: onAddLinkMenu };

    SP.UI.ModalDialog.showModalDialog(options);
}

function AddNewLink() {

    if (Grids.WorkPlannerGrid.FRow != null) {

        addLinkTableDiv.style.display = "";

        addLinkTableDiv.firstChild.nextSibling.firstChild.nextSibling.nextSibling.nextSibling.value = "FS";

        addLinkTableDiv.firstChild.nextSibling.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.value = "0";

        for (var row in Grids.WorkPlannerAddLinks.Rows)
            if (row != "Header" && row != "Toolbar")
                Grids.WorkPlannerAddLinks.RemoveRow(Grids.WorkPlannerAddLinks.GetRowById(row));

        for (var row in Grids.WorkPlannerGrid.Rows) {
            var oldRow = Grids.WorkPlannerGrid.GetRowById(row);
            if (oldRow.Kind == "Data" && oldRow.id != "NewTask" && oldRow.Def.Name != "Assignment") {

                var newRow = Grids.WorkPlannerAddLinks.AddRow(Grids.WorkPlannerAddLinks.GetRowById(oldRow.parentNode.id), null, true, row, null);
                newRow.NoColor = 1;
                newRow.NoUpload = 1;
                newRow.NoColorState = 1;

                Grids.WorkPlannerAddLinks.SetValue(newRow, "Title", oldRow.Title, 1);
            }
        }

        var options = { html: addLinkTableDiv, width: 550, height: 400, title: "Add Link", dialogReturnValueCallback: onAddNewLink };

        SP.UI.ModalDialog.showModalDialog(options);
    }
}

function onAddNewLink(dialogResult, returnValue) {
    if (dialogResult == SP.UI.DialogResult.OK) {
        var vals = returnValue.split('|');

        var wgrid = Grids.WorkPlannerGrid;

        var lgrid = Grids.WorkPlannerAddLinks;


        if (wgrid.GetRowById(lgrid.FRow.id).Def.Name == "Task") {
            linkItems(lgrid.FRow.id, wgrid.FRow, vals[0], vals[1]);
            SetDepsGrid(wgrid, wgrid.FRow);
            Grids.WorkPlannerGrid.CorrectDependencies(Grids.WorkPlannerGrid.FRow, "G");
        }
        else {
            alert("You can't link summary rows");
        }

    }
}

function onAddLinkMenu(dialogResult, returnValue) {
    if (dialogResult == SP.UI.DialogResult.OK) {
        var vals = returnValue.split('|');

        if (AddLinkDirection == "up")
            LinkUp(vals[0], vals[1]);
        else
            LinkDown(vals[0], vals[1]);
    }

}

function CheckMilestone(rowid) {
    var grid = Grids.WorkPlannerGrid;
    var row = grid.GetRowById(rowid);

    try {
        var duration = grid.GetValue(row, "Duration");

        if (duration == "0")
            grid.SetValue(row, "Milestone", 1, 1, 0);
        else
            grid.SetValue(row, "Milestone", 0, 1, 0);
    } catch (e) { }

    if (grid.FRow && grid.FRow.id == row.id) {
        try {
            Grids.WorkPlannerDetail.SetValue(Grids.WorkPlannerDetail.GetRowById("Milestone"), "V", grid.GetValue(row, "Milestone"), 1, 0);
        } catch (e) { }
    }
}

function RemovePred(grid, row, parentid) {
    var pId = row.Predecessors.toString();
    var pIds = pId.split(";");
    pId = "";

    for (var pI in pIds) {
        if (pIds[pI] != "") {
            var dep = getDependencyArray(pIds[pI])[0];
            if (dep != parentid.toString()) {
                pId += ";" + pIds[pI];
            }
        }
    }

    if (pId != "")
        return pId.substr(1);
    else
        return "";
}


function AddPred(grid, row, parentid, type, lag) {
    var pId = row.Predecessors.toString();
    var pIds = pId.split(";");
    pId = "";

    for (var pI in pIds) {
        if (pIds[pI] != "") {
            var dep = getDependencyArray(pIds[pI])[0];
            if (dep != parentid.toString()) {
                pId += pIds[pI] + ";";
            }
        }
    }

    pId += parentid;
    if (type != "FS")
        pId += type;

    if (lag != "") {
        var iLag = parseInt(lag);
        if (iLag < 0)
            pId += iLag;
        else if (iLag > 0)
            pId += "+" + iLag;
    }

    return pId;
}

function linkItems(parentid, row, type, lag) {

    var grid = Grids.WorkPlannerGrid;

    var pId = row.Descendants.toString();
    var pIds = pId.split(";");
    pId = "";

    for (var pI in pIds) {
        if (pIds[pI] != "") {
            var dep = getDependencyArray(pIds[pI])[0];
            if (dep != parentid.toString()) {
                pId += pIds[pI] + ";";
            }
            else {
                return;
            }
        }
    }

    pId += parentid;
    if (type != "FS")
        pId += type;

    if (lag != "") {
        var iLag = parseInt(lag);
        if (iLag < 0)
            pId += iLag;
        else if (iLag > 0)
            pId += "+" + iLag;
    }

    var pRow = grid.GetRowById(parentid);

    if (grid.GetValue(row, "StartDate") == "") {
        setDefaultDates(grid, row);
    }

    if (grid.GetValue(pRow, "StartDate") == "") {
        setDefaultDates(grid, pRow);
    }

    grid.SetValue(row, "Descendants", pId, 1);

    grid.SetValue(pRow, "Predecessors", AddPred(grid, pRow, row.id, type, lag), 1, 0);

}

function setDefaultDates(grid, row, samedates) {

    if (oRollDown["StartDate"])
        return;

    if (grid.GetValue(row, "StartDate") == "" && !oRollDown["StartDate"])
        grid.SetValue(row, "StartDate", new Date(grid.Cols["G"].GanttBase).valueOf(), 1, 0);

    if (samedates && !oRollDown["Duration"]) {
        //grid.SetValue(row, "DueDate", new Date(grid.Cols["G"].GanttBase).valueOf(), 1, 0);
        grid.SetValue(row, "Duration", 0, 1, 0);
    }
    else {
        //grid.SetValue(row, "DueDate", new Date(grid.IncGanttDate(new Date(Grids.WorkPlannerGrid.Cols["G"].GanttBase).valueOf(), 1, null, false, null)), 1, 0);
        //grid.SetValue(row, "Duration", 1, 1, 0);

        var start = grid.GetValue(row, "StartDate");

        var newstart = grid.IncGanttDate(start, iWorkHours, "h");

        if (grid.GetValue(row, "Duration") == "" && !oRollDown["Duration"]) {
            grid.SetValue(row, "Duration", 1, 1, 0);
            grid.SetValue(row, "DueDate", newstart, 1, 0);
            //grid.SetValue(row, "Duration", 1, 1, 0);
            //grid.CheckGantt(row, "DueDate");
            //grid.CheckGantt(row, "Duration", 1);
            //grid.SetValue(row, "Duration", 1, 1, 0);
        }
    }
}

function LinkDown(type, lag) {

    var grid = Grids.WorkPlannerGrid;
    grid.ActionCalcOff();
    var rows = grid.GetSelRows();

    var parent = null;
    var row = null;

    for (var i = rows.length - 1; i >= 0; i--) {
        if (rows[i].Def.Name != "Assignment" && rows[i].Def.Name != "Summary") {
            if (parent == null) {
                parent = rows[i];
            }
            else {

                linkItems(parent.id, rows[i], type, lag);

                parent = rows[i];

            }
        }
    }
    grid.ActionCalcOn();
    setTimeout("Grids.WorkPlannerGrid.ActionCorrectAllDependencies()", 100);
}

function UpdateDependencies(grid) {
    var deps = "";
    var wpGrid = Grids.WorkPlannerGrid

    for (var R in grid.Rows) {
        if (R != "Header" && R != "Toolbar") {
            var row = grid.GetRowById(R);

            deps += ";" + row.ID;

            var type = "";
            var lag = "";

            if (row.T != "FS") {
                deps += row.T;
                type = row.T;
            }
            if (row.L != 0) {
                if (row.L < 0)
                    deps += row.L;
                else
                    deps += "+" + row.L;

                lag = row.L;
            }
            var cRow = wpGrid.GetRowById(row.ID);
            wpGrid.SetValue(cRow, "Predecessors", AddPred(wpGrid, cRow, wpGrid.FRow.id, type, lag), 1, 0);
        }
    }
    if (deps != "")
        deps = deps.substr(1);



    Grids.WorkPlannerGrid.SetValue(Grids.WorkPlannerGrid.FRow, "Descendants", deps, 1);



    Grids.WorkPlannerGrid.CorrectDependencies(Grids.WorkPlannerGrid.FRow, "G");
}

function ShowAssignments() {
    if (oShowAssignments) {
        oShowAssignments = false;
        Grids.WorkPlannerGrid.Def["Assignment"].Visible = "0";
    }
    else {
        oShowAssignments = true;
        Grids.WorkPlannerGrid.Def["Assignment"].Visible = "1";
    }



    HideShowAssignments();
}

function CanShowSummary() {
    try {
        var grid = Grids.WorkPlannerGrid;
        var row = grid.GetRowById("Summary");
        return row.Visible;
    } catch (e) { }
}

function ShowSummary() {
    var grid = Grids.WorkPlannerGrid;
    var row = grid.GetRowById("Summary");

    if (row.Visible)
        grid.HideRow(row);
    else
        grid.ShowRow(row);
}

function HideShowAssignment(grid, row) {
    if (row.Def.Name == "Assignment") {
        if (oShowAssignments) {
            grid.ShowRow(row);
            return true;
        }
        else {
            grid.HideRow(row);
            return false;
        }
    }
}

function PublishLog() {

    var options = { url: "PublishLog.aspx?ID=" + sItemID + "&ListID=" + sProjectListId, width: 600, height: 500, title: "Publish Status" };

    SP.UI.ModalDialog.showModalDialog(options);

}

function HideShowAssignments() {
    var grid = Grids.WorkPlannerGrid;

    var row = grid.GetFirst();

    while (row && row.id != "BacklogRow") {
        HideShowAssignment(grid, row);

        row = grid.GetNext(row);
    }

    if (bAgile) {
        grid = Grids.AgileGrid;

        var row = grid.GetFirst();

        while (row) {
            HideShowAssignment(grid, row);

            row = grid.GetNext(row);
        }

    }
}

function DeleteNewLink() {
    try {
        var grid = Grids.WorkPlannerLinks;
        if (grid.FRow != null && confirm("Are you sure you want to remove that link?")) {

            Grids.WorkPlannerGrid.SetValue(Grids.WorkPlannerGrid.GetRowById(grid.FRow.ID), "Predecessors", RemovePred(Grids.WorkPlannerGrid, Grids.WorkPlannerGrid.GetRowById(grid.FRow.ID), Grids.WorkPlannerGrid.FRow.id), 1);

            grid.RemoveRow(grid.FRow);

            UpdateDependencies(grid);
        }
    } catch (e) { }
}

function getDependencyArray(sId) {

    var out = ["", "", ""];
    var sType = "";
    var sLag = 0;
    try {

        var sLagPos = sId.indexOf("-", 0);
        if (sLagPos == -1)
            sLagPos = sId.indexOf("+", 0);

        if (sLagPos > 0) {
            sLag = sId.substr(sLagPos);
            sId = sId.substr(0, sLagPos);
        }

        sType = sId.substr(sId.length - 2, 2).toLowerCase();
        if (sType == "ss" || sType == "sf" || sType == "ff" || sType == "fs") {
            sId = sId.substr(0, sId.length - 2).toUpperCase();
            sType = sType.toUpperCase();
        }
        else
            sType = "FS";
    } catch (e) { sType = "FS"; }

    out[0] = sId;
    out[1] = sLag;
    out[2] = sType;

    return out;
}

function LinkUp(type, lag) {

    var grid = Grids.WorkPlannerGrid;
    grid.ActionCalcOff();
    var rows = grid.GetSelRows();

    var parent = null;
    var row = null;

    for (var i = 0; i < rows.length; i++) {
        if (rows[i].Def.Name != "Assignment" || rows[i].Def.Name != "Summary") {
            if (parent == null) {
                parent = rows[i];
            }
            else {
                linkItems(parent.id, rows[i], type, lag);
                parent = rows[i];
            }
        }
    }
    grid.ActionCalcOn();
    setTimeout("Grids.WorkPlannerGrid.ActionCorrectAllDependencies()", 100);
}

function Unlink() {

    if (confirm("Are you sure you want to unlink all successors?")) {
        var grid = Grids.WorkPlannerGrid;
        grid.ActionCalcOff();
        var rows = grid.GetSelRows();

        for (var i = 0; i < rows.length; i++) {
            var sDs = grid.GetValue(rows[i], "Descendants").toString().split(';');

            for (var sD in sDs) {
                var rId = sDs[sD];
                var iRow = grid.GetRowById(parseFloat(rId));
                if (iRow)
                    grid.SetValue(iRow, "Predecessors", RemovePred(grid, iRow, rows[i].id), 1);
            }

            grid.SetValue(rows[i], "Descendants", "", 1);
        }
        grid.ActionCalcOn();
        grid.ActionCorrectAllDependencies();
    }
}

function PublishWorkPlan() {

    sm("divPublish", 130, 50);

    dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=Publish&ID=" + sItemID + "&PlannerID=" + sPlannerID, onPublishClose);

}

function CheckUpdates() {

    //if (canPublish)
    dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=GetUpdateCount&ID=" + sItemID + "&PlannerID=" + sPlannerID, CheckUpdatesClose);
    //else {
    //    closeupdateStatusBox();
    //setTimeout("CheckUpdates()", 60000);
    //}
}

function closeupdateStatusBox() {
    if (updateStatusBox != null) {
        SP.UI.Status.removeStatus(updateStatusBox);
        updateStatusBox = null;
        setHeight();
    }
}

function closepublishStatusBox() {
    if (publishStatusBox != null) {
        SP.UI.Status.removeStatus(publishStatusBox);
        publishStatusBox = null;
        setHeight();
    }
}

function CheckUpdatesClose(loader) {

    if (loader.xmlDoc.responseText != null) {

        var uStatus = loader.xmlDoc.responseText.trim();

        if (uStatus.indexOf("Errors") == 0) {
            alert(uStatus);
        }

        else if (uStatus == "0") {
            hasUpdates = false;
            closeupdateStatusBox();
        }
        else {
            if (updateStatusBox == null) {
                hasUpdates = true;
                updateStatusBox = SP.UI.Status.addStatus('Updates:', 'You have ' + uStatus + ' update(s) waiting to be processed <a href=\'#\' onclick=\'Javascript:DoUpdates();\'>[Process Updates]</a>', true);
                //SP.UI.Status.setStatusPriColor(updateStatusBox, 'yellow');
            }
            else {
                hasUpdates = true;
                SP.UI.Status.updateStatus(updateStatusBox, 'You have ' + uStatus + ' update(s) waiting to be processed <a href=\'#\' onclick=\'Javascript:DoUpdates();\'>[Process Updates]</a>');
            }
        }
    }

    setTimeout("CheckUpdates()", 60000);
}


function CopyRemainingWork(grid, row) {
    var w = grid.GetValue(row, "Work");
    if (grid.GetValue(row, "RemainingWork") == oldWork || grid.GetValue(row, "RemainingWork") == "0") {
        try {
            grid.SetValue(row, "RemainingWork", w, 1, 0);
        } catch (e) { }
        try {
            Grids.WorkPlannerDetail.SetValue(Grids.WorkPlannerDetail.GetRowById("RemainingWork"), "V", w, 1, 0);
        } catch (e) { }
    }
}

function onDoUpdates(dialogResult, returnValue) {
    if (dialogResult == SP.UI.DialogResult.OK) {
        sUpdates = returnValue;

        var grid = Grids.WorkPlannerGrid;

        if (grid.Cols["G"].GanttCorrectDependencies == 1) {
            grid.ActionCorrectAllDependencies();
        }

        CheckUpdatesBox();
    }
}

function CheckUpdatesBox() {
    if (processUpdatesBox == null && sUpdates != "") {
        processUpdatesBox = SP.UI.Status.addStatus('Updates:', 'You have applied updates. To commit your updates you must save your plan.', true);
        //SP.UI.Status.setStatusPriColor(processUpdatesBox, 'yellow');
    }
    else if (sUpdates != "" && processUpdatesBox != null) {
        try {
            SP.UI.Status.UpdateStatus(processUpdatesBox, 'You have applied updates. To commit your updates you must save your plan.');
        } catch (e) {
            processUpdatesBox = SP.UI.Status.addStatus('Updates:', 'You have applied updates. To commit your updates you must save your plan.', true);
        }
        //SP.UI.Status.setStatusPriColor(processUpdatesBox, 'yellow');
    }
    else if (processUpdatesBox != null && sUpdates == "") {
        SP.UI.Status.removeStatus(processUpdatesBox);
    }
    setHeight();
}

function DoUpdates() {

    var options = { url: "PlannerUpdates.aspx?ID=" + sItemID + "&PlannerID=" + sPlannerID, width: 700, height: 600, title: "Process Updates", dialogReturnValueCallback: onDoUpdates };

    SP.UI.ModalDialog.showModalDialog(options);
}

function CheckPublishStatus() {

    dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=PublishStatus&ID=" + sItemID + "&PlannerID=" + sPlannerID, CheckPublishStatusClose);

}

function CheckPublishStatusClose(loader) {

    if (loader.xmlDoc.responseText != null) {

        if (publishStatusBox == null) {
            publishStatusBox = SP.UI.Status.addStatus('Publish Status:', '', true);
            SP.UI.Status.setStatusPriColor(publishStatusBox, 'blue');
            setHeight();
        }

        publishStatus = loader.xmlDoc.responseText.trim();

        var sPublishStatus = publishStatus.split('|');

        if (sPublishStatus[0] == "true")
            canPublish = true;
        else
            canPublish = false;

        if (loader.xmlDoc.responseText.trim() != "No Status") {
            SP.UI.Status.updateStatus(publishStatusBox, sPublishStatus[2]);
            if (sPublishStatus[1] == "true") {
                SP.UI.Status.setStatusPriColor(publishStatusBox, 'yellow');
            } else {
                SP.UI.Status.setStatusPriColor(publishStatusBox, 'blue');
            }

            setTimeout("CheckPublishStatus()", 10000);
            setHeight();
        }
        //else 
        //{
        //    
        //    RefreshCommandUI();
        //    closepublishStatusBox();
        //}
        RefreshCommandUI();
    }
}

function onPublishClose(loader) {
    hm("divPublish");

    if (loader.xmlDoc.responseText != null) {

        if (loader.xmlDoc.responseText.trim() != "Success") {
            alert(loader.xmlDoc.responseText);
        }
        else {
            //closeupdateStatusBox();
            canPublish = false;
            RefreshCommandUI();
            CheckPublishStatus();
        }
    }
    else
        alert("Response contains no XML");
}

function Outdent() {
    var grid = Grids.WorkPlannerGrid;
    grid.EndEdit(true);
    var orows = grid.GetSelRows();
    grid.ActionCalcOff();
    for (var i = orows.length - 1; i >= 0; i--) {
        var row = orows[i];

        if (row.Def.Name != "Folder" && row.parentNode != null && row.parentNode.Def.Name != "Folder" && row.parentNode.Def.Name != "Iteration") {

            var parent = row.parentNode;

            var sibling = row.nextSibling;
            var oSiblings = new Array();

            while (sibling != null) {
                oSiblings.push(sibling.id);
                sibling = sibling.nextSibling;
            }

            row = Grids.WorkPlannerGrid.GetRowById(row.id);

            Grids.WorkPlannerGrid.MoveRow(row, row.parentNode.parentNode, row.parentNode.nextSibling, 1);

            for (var s in oSiblings) {
                Grids.WorkPlannerGrid.MoveRow(Grids.WorkPlannerGrid.GetRowById(oSiblings[s]), row, null, 1);
            }

            //grid.MoveRow(row, row.parentNode.parentNode, null, 1);


        }
    }
    grid.ActionCalcOn();

}

function Indent() {

    var grid = Grids.WorkPlannerGrid;
    grid.EndEdit(true);
    var orows = grid.GetSelRows();
    grid.ActionCalcOff();
    for (var i = 0; i < orows.length; i++) {
        var row = grid.GetRowById(orows[i].id);

        if (row.Def.Name != "Folder" && row.previousSibling != null && row.previousSibling.Def.Name != "Folder" && row.previousSibling.Def.Name != "Assignment") {

            grid.MoveRow(row, row.previousSibling, null, 1);

            grid.Collapse(row.parentNode);

            grid.Expand(row.parentNode);

            grid.RefreshRow(row.parentNode);
            grid.ShowRow(row);

            grid.Recalculate(row, "DueDate", 1);
            grid.Recalculate(row, "Duration", 1);
        }
    }
    grid.ActionCalcOn();
}

function NewTask(isSummary, isMilestone, isAbove, bAgileGrid, bIsExternal, bForceNew) {

    if (bAgileGrid) {
        var aRow = Grids.AgileGrid.FRow;
    }

    var grid = Grids.WorkPlannerGrid;

    var row = grid.FRow;

    if (bAgileGrid) {
        row = aRow;
    }

    if (row != null) {
        if (row.Def.Name == "Assignment")
            row = row.parentNode;
        if (row.Kind != "Data" || row.id == "NewTask")
            row = null;
    }
    var newrow = null;

    var taskDef = "Task";
    if (isSummary)
        taskDef = "Summary";
    else if (isMilestone)
        taskDef = "Milestone";
    else if (bIsExternal)
        taskDef = "External";

    var newId = grid.GenerateId();

    //AddRow   (TRow parent, TRow next, bool show = false, string id = null, string Def = null)

    if (bAgile && row && row.id == "0")
        row = null;

    if (row == null || bForceNew) //No Row Selected
    {
        if (bAgile) {
            if (bAgileGrid) {
                newrow = grid.AddRow(grid.GetRowById("BacklogRow"), null, true, newId, taskDef);
            }
            else {

                var lRow = grid.GetRowById("BacklogRow");
                var iRow = lRow.previousSibling;
                if (iRow && iRow.Def.Name == "Iteration") {
                    newrow = grid.AddRow(iRow, null, true, newId, taskDef);
                }
                else {
                    alert('You must have an iteration to add your new task.');
                    return;
                }
            }
        }
        else
            newrow = grid.AddRow(grid.GetRowById("0"), null, true, newId, taskDef);
    }
    else {
        row = grid.GetRowById(row.id);
        if (row.Def.Name == "Folder" || row.Def.Name == "Iteration") {
            newrow = grid.AddRow(row, row.firstChild, true, newId, taskDef);
        }
        else {
            if (isAbove)
                newrow = grid.AddRow(row.parentNode, row, true, newId, taskDef);
            else
                newrow = grid.AddRow(row.parentNode, row.nextSibling, true, newId, taskDef);
        }
    }

    if (isMilestone) {
        grid.SetValue(newrow, "StartDate", new Date(grid.Cols["G"].GanttBase).valueOf(), 1, 0);
    }
    //ApplyDefaults(grid, newrow, isMilestone, isSummary);

    setParentDef(grid, newrow);

    grid.SetValue(newrow, "Summary", 0, 1, 0);

    if (isSummary) {

        grid.SetValue(newrow, "Title", "Summary Task 1", 1);
        grid.SetValue(newrow, "Summary", 1, 1, 0);
        newId = grid.GenerateId();
        newrow = grid.AddRow(newrow, null, true, newId, "Task");
        setDefaultDates(grid, newrow);

    }



    var hRow = newrow;

    SetRowRollDowns(grid, newrow);
    if (bAgile) {
        RollDownFromParent(grid, newrow);
    }
    ////hideNonFolders(hRow);

    //setWBSAndTaskID(Grids.WorkPlannerGrid.GetRowById('0'));

    if (bAgileGrid)
        grid.HideRow(newrow);

    if (!bAgileGrid)
        grid.Focus(newrow, 'Title');

    return newrow.id;
}

function GetColor(grid, row, col, r, g, b, edit) {
    if (grid.id == "WorkPlannerGrid") {
        if (col == "Available" || col == "AvailableWork") {
            try {
                if (row.id != "NewTask" && row.id != "0" && row.Def.Name == "Iteration") {

                    var val = parseFloat(grid.GetValue(row, col));
                    if (val < 0)
                        return "#C86363";
                    else
                        return "#70B76F";

                }
            } catch (e) { }
        }
    }
}

function getHTML(grid, row, col, val) {
    if (grid.id == "WorkPlannerGrid") {
        if (row.Kind == "Data") {
            if (col == "Notifications") {
                val = "";
                if (grid.GetValue(row, "Notes") != "" && grid.GetValue(row, "Notes") != "<div></div>")
                    val += " <img src='/_layouts/epmlive/images/notes16.png' alt='Task Has Notes'>";

                try {
                    if (parseInt(grid.GetValue(row, "CommentCount")) > 0)
                        val += " <img src='/_layouts/epmlive/images/comments16.gif' alt='Task Has Comments'>";
                } catch (e) { }

                try {
                    if (grid.GetValue(row, "Attachments").toString().toLowerCase() == "true")
                        val += " <img src='/_layouts/epmlive/images/attach16.gif' alt='Task Has Attachments'>";
                } catch (e) { }

                if (row.Def.Name == "External")
                    val += " <img src='/_layouts/epmlive/images/externallink.png' alt='Task Is External'>";

                return val;
            }
            else if (col == "ScheduleStatus") {
                try {
                    var today = new Date();
                    var todayplus = new Date(new Date() - (1000 * 60 * 60 * 24 * 30));

                    var duedate = new Date(grid.GetValue(row, "DueDate"));

                    today.setHours(0, 0, 0, 0);
                    todayplus.setHours(0, 0, 0, 0);
                    duedate.setHours(0, 0, 0, 0);

                    var val = "";

                    if (row.id == "NewTask" || row.id == "0")
                        return "";

                    if (grid.GetValue(row, "Status") == "Completed") {
                        val = "<img src='/_layouts/images/checkmark.gif' alt='Completed'>";
                    }
                    else if (grid.GetValue(row, "Status") == "Deferred") {
                        val = "<img src='/_layouts/images/green.gif' alt='On Schedule'>";
                    }
                    else {
                        if (duedate < todayplus)
                            val = "<img src='/_layouts/images/red.gif' alt='On Schedule'>";
                        else if (duedate < today)
                            val = "<img src='/_layouts/images/yellow.gif' alt='On Schedule'>";
                        else
                            val = "<img src='/_layouts/images/green.gif' alt='On Schedule'>";
                    }
                } catch (e) { alert(e); }

                return val;

            }
            else if (col == "Predecessors" || col == "Descendants") {
                var ValidChars = "0123456789";

                var newval = "";
                var sVals = val.toString().split(';');

                for (var sVal in sVals) {
                    var pred = sVals[sVal];
                    var realpred = "";
                    for (i = 0; i < pred.length; i++) {
                        Char = pred.charAt(i);
                        if (ValidChars.indexOf(Char) == -1) {
                            break;
                        }
                        else {
                            realpred += Char;
                        }
                    }

                    var predExtra = "";

                    try {
                        predExtra = pred.substr(realpred.length);
                    } catch (e) { }

                    try {
                        var newpred = grid.GetValue(grid.GetRowById(realpred), "taskorder");
                        if (newpred != "")
                            newval += ";" + newpred + predExtra;
                        //else
                        //    newval += ";#" + pred;
                    } catch (e) { }
                }

                if (newval.length > 0)
                    val = newval.substr(1);
                else
                    val = "";
                return val;
            }
        }
    }
}

function EnterButton(grid) {
    var row = grid.FRow;
    if (row != null) {
        grid.EndEdit(true);
        var cRow = grid.GetNext(row);
        while (cRow && !cRow.Visible) {
            cRow = grid.GetNext(cRow);
        }
        if (cRow && cRow.Def.Name == "Folder")
            cRow = null;

        if (cRow) {
            grid.Focus(cRow, grid.FCol, null, 1);
        }
        else {
            var newtask = grid.GetRowById(NewTask());

            grid.Focus(newtask, grid.FCol, null, 1);
        }
    }
}

function SetRowRollDowns(grid, row) {

    var parent = row.parentNode;

    while (parent != null) {

        if (parent.Def.Name == "Folder" || parent.Def.Name == 'Iteration')
            break;

        parent = parent.parentNode;
    }


    for (var c in oRollDown) {
        grid.SetValue(row, c, grid.GetValue(parent, c), 1, true);
    }
}

function isShowGrouping() {
    try {
        var grid = Grids.WorkPlannerGrid;
        var row = grid.GetRowById("GroupRow");
        return row.Visible;
    } catch (e) { }
    return false;
}

function ShowGrouping() {
    var grid = Grids.WorkPlannerGrid;
    var row = grid.GetRowById("GroupRow");
    if (row.Visible)
        grid.HideRow(row);
    else
        grid.ShowRow(row);
}

function ShowTab(tab) {
    try {
        dhxLayout.cells(detailsCell).expand();
        dhxTabbar.setTabActive(tab);
    } catch (e) { }
}

function setParentDef(Grid, Row) {
    if (Row.parentNode.Def.Name == "Task") {
        Grids.WorkPlannerGrid.ChangeDef(Grids.WorkPlannerGrid.GetRowById(Row.id).parentNode, "Summary", 1, 0);
        Grid.ChangeDef(Row.parentNode, "Summary", 1, 0);
    }
}

function focusCell(grid, row) {
    grid.Focus(row, "Title", null, true);
}

function NewFolder() {

    var folder = prompt('Enter New Folder Name:', '');

    var grid = Grids.WorkPlannerGrid;

    var Row = grid.AddRow(grid.FRow, null, true, grid.GenerateId(), "Folder");

    Row.Detail = "WorkPlannerGrid";

    grid.SetValue(Row, "Title", folder, 1);
    //Grids.WorkPlannerGrid.RefreshRow(Grids.WorkPlannerGrid.GetRowById(Row.id));
}

function EditFolder() {

    var grid = Grids.WorkPlannerGrid;

    if (grid.FRow.id != "0") {

        var folder = prompt('Enter New Folder Name:', grid.FRow.Title);
        if (folder != null)
            grid.SetValue(grid.FRow, "Title", folder, 1);
    }
}

function DeleteFolder() {
    var grid = Grids.WorkPlannerGrid;

    if (grid.FRow.id != "0") {
        if (confirm("Are you sure you want to delete that folder and all it's tasks?")) {

            grid.DeleteRow(grid.FRow, 1);

        }
    }
}

function FolderEnabled() {
    var grid = Grids.WorkPlannerGrid;
    try {
        if (grid.FRow != null && grid.FRow.id != "0") {
            return true;
        }
    } catch (e) { }
    return false;
}

function PrintPlan() {
    Grids.WorkPlannerGrid.ActionPrint();
}

function CanUndo() {
    try {
        return Grids.WorkPlannerGrid.CanUndo();
    } catch (e) { }
    return false;
}

function CanRedo() {
    try {
        return Grids.WorkPlannerGrid.CanRedo();
    } catch (e) { }
    return false;
}

function Undo() {
    try {
        Grids.WorkPlannerGrid.ActionUndo();
    } catch (e) { }
    RefreshCommandUI();
}

function Redo() {
    try {
        Grids.WorkPlannerGrid.ActionRedo();
    } catch (e) { }
    RefreshCommandUI();
}

function Copy() {

    try {
        Grids.WorkPlannerGrid.ActionCopy();
    } catch (e) { }
    RefreshCommandUI();
}

function Paste() {

    try {
        Grids.WorkPlannerGrid.ActionPaste();
    } catch (e) { alert(e); }
    RefreshCommandUI();
}

function SetPercent(percent) {
    var grid = Grids.WorkPlannerGrid;

    var orows = grid.GetSelRows();

    for (var orow in orows) {
        var row = orows[orow];
        row = grid.GetRowById(row.id);
        try {
            grid.SetValue(row, "PercentComplete", percent, 1);
        } catch (e) { }
    }
}

function CanResourceInfo() {
    try {
        return Grids.WorkPlannerAssignments.FRow != null;
    } catch (e) { }
    return false;
}

function ResourceInformation() {
    if (Grids.WorkPlannerAssignments.FRow != null) {
        var options = { url: "ResourceInformation.aspx?ID=" + Grids.WorkPlannerAssignments.FRow.id, width: 700, height: 600, title: "Resource Information", dialogReturnValueCallback: null };

        SP.UI.ModalDialog.showModalDialog(options);
    }
}

function BuildTeam() {
    var options = { url: "buildteam.aspx?listid=" + sProjectListId + "&id=" + sItemID, title: "Build Team", showMaximized: true, dialogReturnValueCallback: RefreshTeam };

    //var options = { url: "buildteam.aspx?useteam=" + bUseTeam + "&listid=" + sProjectListId + "&id=" + sItemID + "&nosave=true&currentteam=1", title: "Build Team", showMaximized: true, dialogReturnValueCallback: RefreshTeam };

    SP.UI.ModalDialog.showModalDialog(options);
}

function AddFragment() {
    var options = { url: "addfragment.aspx?PlannerID=" + sPlannerID + '&listid=' + sProjectListId + "&id=" + sItemID, width: 450, height: 450, title: "Insert Fragment", showMaximized: false, dialogReturnValueCallback: RefreshTeam };
    SP.UI.ModalDialog.showModalDialog(options);
}

function SaveFragment() {
    var options = { url: "savefragment.aspx?PlannerID=" + sPlannerID, width: 325, height: 195, title: "Save Fragment", showMaximized: false };
    SP.UI.ModalDialog.showModalDialog(options);
}

function ManageFragment() {
    var options = { url: "managefragment.aspx?PlannerID=" + sPlannerID, width: 450, height: 450, title: "Manage Fragments", showMaximized: false};
    SP.UI.ModalDialog.showModalDialog(options);
}

function RefreshTeam(dialogResult, returnValue) {
    sm("dlgResource", 130, 50);
    dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=GetTeam&PlannerID=" + sPlannerID + "&itemid=" + sItemID + "&listid=" + sProjectListId, RefreshTeamClose);
}

function ApplyDefaults(grid, row, isMilestone, isSummary) {

    if (grid && row) {
        /*for (var oD in oDefaults) {
            if (grid.GetValue(row, oD) == "" && oD != "StartDate" && oD != "DueDate" && oD != "Duration" && !oRollDown[oD]) {
                try {
                    grid.SetValue(row, oD, oDefaults[oD], 0, 0);
                } catch (e) { }
            }
        }*/

        grid.SetValue(row, "Summary", 0, 1, 0);

        if (isMilestone) {
            setDefaultDates(grid, row, true);
            CheckMilestone(row.id);
        }
        else if (!isSummary)
            setDefaultDates(grid, row);


        if (iDefaultTaskType == 0)
            grid.SetValue(row, "TaskType", "Shared", 1);
        else if (iDefaultTaskType == 1)
            grid.SetValue(row, "TaskType", "Individual", 1);

        grid.RefreshRow(row);
    }
}

function RefreshTeamClose(loader) {
    hm("dlgResource");
    if (loader.xmlDoc.responseText != null) {
        if (loader.xmlDoc.responseText.trim().indexOf("Error") == 0) {
            alert(loader.xmlDoc.responseText.trim());
        }
        else {
            oResourceList = eval("({" + loader.xmlDoc.responseText.trim() + "})");

            RefreshResourceObject();
        }
    }
}

function RefreshResourceObject() {
    var enums = "";
    var enumkeys = "";
    //var bRowAdded = false;
    //var bAddedRows = new Array();
    var grid = Grids.WorkPlannerGrid;
    for (var oR in oResourceList) {
        enumkeys += "|" + oR.toString().substr(1);
        enums += "|" + oResourceList[oR].Title;

        /*
        if (!grid.Resources[oResourceList[oR].Title]) {
            grid.Resources[oResourceList[oR].Title] = new Object();
            grid.Resources[oResourceList[oR].Title].Name = oResourceList[oR].Title;
            grid.Resources[oResourceList[oR].Title].Availability = iWorkHours;
            grid.Resources[oResourceList[oR].Title].Type = 1;

            Grids.AllocationGrid.AddRow(grid.Foot, null, true, oResourceList[oR].Title, "RES");
            Grids.AllocationGrid.SetValue(Grids.AllocationGrid.GetRowById(oResourceList[oR].Title), "Title", oResourceList[oR].Title, 1);
            //bAddedRows.push(oR);

            //bRowAdded = true;
        }*/
    }

    for (var i = 0; i < oTaskUserFields.length; i++) {
        var f = oTaskUserFields[i];

        if (Grids.WorkPlannerGrid.Cols[f] != null) {
            Grids.WorkPlannerGrid.Cols[f].Enum = enums;
            Grids.WorkPlannerGrid.Cols[f].EnumKeys = enumkeys;

            Grids.WorkPlannerDetail.SetAttribute(Grids.WorkPlannerDetail.GetRowById(f), "V", "Enum", enums, true, false);
            Grids.WorkPlannerDetail.SetAttribute(Grids.WorkPlannerDetail.GetRowById(f), "V", "EnumKeys", enumkeys, true, false);
        }
    }

    for (var i = 0; i < oProjectUserFields.length; i++) {
        var f = oProjectUserFields[i];

        if (Grids.ProjectInfo.GetRowById(f) != null) {
            Grids.ProjectInfo.SetAttribute(Grids.ProjectInfo.GetRowById(f), "V", "Enum", enums, true, false);
            Grids.ProjectInfo.SetAttribute(Grids.ProjectInfo.GetRowById(f), "V", "EnumKeys", enumkeys, true, false);
        }
    }
}

function ScrollTo() {
    var grid = Grids.WorkPlannerGrid;
    var row = grid.FRow;
    if (row != null) {
        var sDate = grid.GetValue(row, "StartDate")
        if (sDate != "") {
            var date = new Date(sDate);
            grid.ScrollToDate(date, "left");
            //Grids.AllocationGrid.ScrollToDate(date, "left");
        }
    }
}

function Close() {
    try {
        location.href = sSource;
    } catch (e) { }
}

function UpdateProject() {

    curTempDate = new Date();

    var options = { url: "SelectDate.aspx", width: 250, height: 280, title: "Update Project", dialogReturnValueCallback: onUpdateProject };

    SP.UI.ModalDialog.showModalDialog(options);
}

function IsCalcEnabled() {
    try {
        if (Grids.WorkPlannerGrid.Calculated == 1)
            return true;
        else
            return false;
    } catch (e) { }
    return false;
}

function IsRespectLinks() {
    try {
        if (Grids.WorkPlannerGrid.Cols["G"].GanttCorrectDependencies == 1)
            return true;
        else
            return false;
    } catch (e) { }
    return false;
}

function RespectLinks() {
    if (Grids.WorkPlannerGrid.Cols["G"].GanttCorrectDependencies == 1) {
        ShowTDialog("Disabling Links...");
        dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=SetProperty&ID=" + sItemID + "&PlannerID=" + sPlannerID + "&Property=FRL&Value=0", RespectLinksClose);
    }
    else {
        ShowTDialog("Enabling Links...");
        dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=SetProperty&ID=" + sItemID + "&PlannerID=" + sPlannerID + "&Property=FRL&Value=1", RespectLinksClose);
    }
}

function isActiveRow(Row) {
    if (Grids.WorkPlannerGrid.FRow && Grids.WorkPlannerGrid.FRow.id == Row.id)
        return true;
    return false;
}

function CalculateAssignmentCosts(grid, row) {

    var child = row.firstChild;

    var fTotalWork = 0;
    var fTotalActualWork = 0;

    while (child) {

        if (child.Def.Name == "Assignment") {
            var id = child.id.toString();
            var assn = id.split('.')[1];

            if (bCalcCost) {
                var res = oResourceList["T" + assn];
                if (res) {
                    var rate = res.StandardRate;

                    if (rate && rate != "") {
                        var fRate = 0.0;
                        try {
                            fRate = parseFloat(rate);
                        } catch (e) { }

                        if (fRate > 0) {
                            try {
                                var fWork = fRate * child.Work;
                                fTotalWork = fTotalWork + fWork;
                                grid.SetValue(child, "Cost", fWork, oShowAssignments);
                            } catch (e) { }
                            try {
                                var fActualWork = fRate * child.ActualWork;
                                fTotalActualWork = fTotalActualWork + fActualWork;
                                grid.SetValue(child, "ActualCost", fActualWork, oShowAssignments);
                            } catch (e) { }
                        }
                    }
                }
            }

            CalcUsage(grid, child);
        }
        child = child.nextSibling;
    }

    if (bCalcCost) {
        grid.SetValue(row, "Cost", fTotalWork, 1);
        grid.SetValue(row, "ActualCost", fTotalActualWork, 1);
    }
}

function CalcUsage(grid, row) {
    try {
        var st = row.StartDate;
        var en = row.DueDate;
        var diff = grid.DiffGanttDate(st, en, "h");
        if (diff) {
            var usage = row.Work / diff * iWorkHours;

            if (usage != "NaN")
                grid.SetValue(row, "USAGE", row.Title + "*" + usage, 1);
        }
        else
            grid.SetValue(row, "USAGE", "", 1);
    } catch (e) { }
}

function SetPlannerFieldValue(row, col, val, setVal) {

    var grid = Grids.WorkPlannerGrid;

    var row = grid.GetRowById(row.id);

    if (!row)
        return;

    if (setVal)
        grid.SetValue(row, col, val, 1);

    if (row.id == "NewTask")
        bNewRowHasChanged = true;

    try {
        Grids.WorkPlannerDetail.SetValue(Grids.WorkPlannerDetail.GetRowById(col), "V", val, 1);
    } catch (e) { }

    if (col == "AssignedTo" && row.Def.Name != "Assignment") {

        if (row.id == "NewTask") {
            row = DoNewRow();
        }
        SetTaskAssignments(row);

        PopulateResourceTable(row, false);

    }

    var rolldowntype = 0;

    if (col == "Work") {
        rolldowntype = 1;
        DoAssignmentRollDown(grid, row, rolldowntype, col);
    }
    else {
        DoAssignmentRollDown(grid, row, 0, col);
    }

    if (col == "TaskType") {
        DoAssignmentRollDown(grid, row, 1, "Work");

        if (Grids.WorkPlannerGrid.FRow != null && row.id == Grids.WorkPlannerGrid.FRow.id)
            PopulateResourceTable(row, false);
    }

    RollupSummaryField(col);

    if (col == "Duration") {
        RollupSummaryField("DueDate");
        DoAssignmentRollDown(grid, row, 0, "DueDate");

        //if (val == "0")
        //    grid.SetValue(row, "DueDate", grid.GetValue(row, "StartDate"), 1, 0);

        CheckMilestone(row.id);
        CalculateAssignmentCosts(grid, row);

        //if (bAgile) {
        //    RollDown(row, "DueDate");
        //}
    }

    if (col == "DueDate") {
        if (setVal) {
            grid.SetValue(row, "Duration", grid.DiffGanttDate(row.StartDate, row.DueDate, "d", null, null), 1, 0);
        }
        RollupSummaryField("Duration");
        DoAssignmentRollDown(grid, row, 0, "Duration");
        Grids.WorkPlannerGrid.CorrectDependencies(row, "G");
        CalculateAssignmentCosts(grid, row);
        grid.RefreshCell(row, "ScheduleStatus");
        //if (bAgile) {
        //    RollDown(row, "DueDate");
        //}
    }

    if (col == "StartDate") {

        RollupSummaryField("DueDate");
        DoAssignmentRollDown(grid, row, 0, "DueDate");
        CalculateAssignmentCosts(grid, row);
        grid.RefreshCell(row, "ScheduleStatus");
        //if (bAgile) {
        //    RollDown(row, "StartDate");
        //    RollDown(row, "DueDate");
        //}
    }

    if (col == "Work") {
        CopyRemainingWork(grid, row);
        CalculateAssignmentCosts(grid, row);
    }

    if (col == "ActualWork") {
        CalculateAssignmentCosts(grid, row);
    }

    if (row.Def.Name == "Folder" || row.Def.Name == "Iteration")
        RollDown(row, col);

    if (col == "Status") {
        WEStatusCalculateStatus(grid, row, val);
        DoAssignmentRollDown(grid, row, 0, "PercentComplete");
        DoAssignmentRollDown(grid, row, 0, "Complete");
        grid.RefreshCell(row, "ScheduleStatus");
    }

    if (col == "PercentComplete") {
        WEStatusCalculatePercentComplete(grid, row, val);
        DoAssignmentRollDown(grid, row, 0, "Status");
        DoAssignmentRollDown(grid, row, 0, "Complete");
        grid.RefreshCell(row, "ScheduleStatus");
    }

    if (col == "Complete") {
        WEStatusCalculateComplete(grid, row, val);
        DoAssignmentRollDown(grid, row, 0, "PercentComplete");
        DoAssignmentRollDown(grid, row, 0, "Status");
        grid.RefreshCell(row, "ScheduleStatus");
    }

    if (col == "Complete" || col == "PercentComplete" || col == "Status") {
        try {

            if (parseFloat(grid.GetValue(row, "PercentComplete")) > 0 && grid.GetValue(row, "ActualStart") == "") {
                grid.SetValue(row, "ActualStart", grid.GetValue(row, "StartDate"), 1, 1);
            }

            if (parseFloat(grid.GetValue(row, "PercentComplete")) == 100 && grid.GetValue(row, "ActualFinish") == "") {
                grid.SetValue(row, "ActualFinish", grid.GetValue(row, "DueDate"), 1, 1);
            }

        } catch (e) { }
    }

    if (row.Def.Name == "Assignment") {
        if (col == "PercentComplete") {
            RollupAssignments(row.parentNode, col, "PCT");
        }
        else {
            var r = oRollUp[col];
            if (r != null) {
                RollupAssignments(row.parentNode, col, oRollUp[col]);
                if (col == "StartDate" && oRollUp["DueDate"] != null)
                    RollupAssignments(row.parentNode, "DueDate", oRollUp["DueDate"]);
            }
        }
    }
}

function WEStatusCalculateStatus(grid, row, val) {
    _WEStatus_Status = val;
    _WEStatus_PercentComplete = grid.GetValue(row, "PercentComplete");
    ProcessStatus();
    try {
        grid.SetValue(row, "PercentComplete", _WEStatus_PercentComplete, 1, 0);
    } catch (e) { }
    try {
        grid.SetValue(row, "Complete", _WEStatus_Complete, 1, 0);
    } catch (e) { }

    if (isActiveRow(row)) {
        try {
            Grids.WorkPlannerDetail.SetValue(Grids.WorkPlannerDetail.GetRowById("PercentComplete", "V", _WEStatus_PercentComplete, 1, 0));
        } catch (e) { }
        try {
            Grids.WorkPlannerDetail.SetValue(Grids.WorkPlannerDetail.GetRowById("Complete", "V", _WEStatus_Complete, 1, 0));
        } catch (e) { }
    }
}

function WEStatusCalculateComplete(grid, row, val) {
    _WEStatus_Complete = val;
    _WEStatus_PercentComplete = grid.GetValue(row, "PercentComplete");
    ProcessComplete();
    try {
        grid.SetValue(row, "PercentComplete", _WEStatus_PercentComplete, 1, 0);
    } catch (e) { }
    try {
        grid.SetValue(row, "Status", _WEStatus_Status, 1, 0);
    } catch (e) { }
    if (isActiveRow(row)) {
        try {
            Grids.WorkPlannerDetail.SetValue(Grids.WorkPlannerDetail.GetRowById("PercentComplete", "V", _WEStatus_PercentComplete, 1, 0));
        } catch (e) { }
        try {
            Grids.WorkPlannerDetail.SetValue(Grids.WorkPlannerDetail.GetRowById("Status", "V", _WEStatus_Status, 1, 0));
        } catch (e) { }
    }
}

function WEStatusCalculatePercentComplete(grid, row, val) {
    _WEStatus_PercentComplete = val;
    _WEStatus_Status = grid.GetValue(row, "Status");
    ProcessPercentComplete();
    try {
        grid.SetValue(row, "Complete", _WEStatus_Complete, 1, 0);
    } catch (e) { }
    try {
        grid.SetValue(row, "Status", _WEStatus_Status, 1, 0);
    } catch (e) { }
    if (isActiveRow(row)) {
        try {
            Grids.WorkPlannerDetail.SetValue(Grids.WorkPlannerDetail.GetRowById("Complete", "V", _WEStatus_Complete, 1, 0));
        } catch (e) { }
        try {
            Grids.WorkPlannerDetail.SetValue(Grids.WorkPlannerDetail.GetRowById("Status", "V", _WEStatus_Status, 1, 0));
        } catch (e) { }
    }
}

function RespectLinksClose(loader) {
    HideTDialog();
    if (loader.xmlDoc.responseText != null) {
        if (loader.xmlDoc.responseText.trim() != "Success") {
            alert(loader.xmlDoc.responseText.trim());
        }
        else {
            if (Grids.WorkPlannerGrid.Cols["G"].GanttCorrectDependencies == 1) {
                Grids.WorkPlannerGrid.Cols["G"].GanttCorrectDependencies = 0;
            }
            else {
                Grids.WorkPlannerGrid.Cols["G"].GanttCorrectDependencies = 1;
                Grids.WorkPlannerGrid.ActionCorrectAllDependencies();
            }

            RefreshCommandUI();
        }
    }
}

function CreateColumn() {

    var options = { url: "../fldNew.aspx?List=" + sTaskListId, width: 600, height: 600, title: "Create Column", dialogReturnValueCallback: onCreateColumn };

    SP.UI.ModalDialog.showModalDialog(options);
}

function onCreateColumn(dialogResult, returnValue) {
    if (dialogResult == SP.UI.DialogResult.OK) {

        //alert(returnValue);
    }
}

function SetRichTextHtml(val) {

    var link = document.createElement('Div');
    link.innerHTML = val;

    //var strHtml = RTE_GetEditorDocument(sEditorID).body.innerHTML;
    try {
        if (link.firstChild.innerText.trim() == "")
            val = "";
    } catch (e) { }

    Grids.WorkPlannerGrid.SetValue(Grids.WorkPlannerGrid.FRow, "Notes", val, 1);

    document.getElementById("noteDivInner").innerHTML = val;

    RefreshNotifications(Grids.WorkPlannerGrid.FRow);

    //SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');
}

function RefreshNotifications(row) {
    Grids.WorkPlannerGrid.RefreshCell(row, "Notifications");
}

function ShowTDialog(text) {

    sm("dlgNormal", 150, 50);
    document.getElementById("dlgNormalText").innerText = text;
}

function ShowNotes() {

    if (Grids.WorkPlannerGrid.FRow != null) {

        var options = { url: "NoteEditor.aspx", width: 650, height: 450, title: "Notes", dialogReturnValueCallback: ShowNotesClose };

        SP.UI.ModalDialog.showModalDialog(options);

        //RTE_GetEditorDocument(sEditorID).body.innerHTML = Grids.WorkPlannerGrid.GetValue(Grids.WorkPlannerGrid.FRow, "Notes");
    }
}

function ShowNotesClose() {

}

function HideTDialog() {
    hm("dlgNormal");
}


function SummaryRollup() {
    if (bSummaryRollup) {
        ShowTDialog("Disabling Summary...");
        dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=SetProperty&ID=" + sItemID + "&PlannerID=" + sPlannerID + "&Property=FSC&Value=0", SummaryRollupClose);
    }
    else {
        ShowTDialog("Enabling Summary...");
        dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=SetProperty&ID=" + sItemID + "&PlannerID=" + sPlannerID + "&Property=FSC&Value=1", SummaryRollupClose);
    }
}

function SummaryRollupClose(loader) {
    HideTDialog();
    if (loader.xmlDoc.responseText != null) {
        if (loader.xmlDoc.responseText.trim() != "Success") {
            alert(loader.xmlDoc.responseText.trim());
        }
        else {
            if (bSummaryRollup) {
                bSummaryRollup = false;
            }
            else {
                bSummaryRollup = true;
            }
            SetProjectInfoFieldsEdit();
            RefreshCommandUI();
        }
    }
}

function DisableCalc() {
    if (Grids.WorkPlannerGrid.Calculated == 1) {
        ShowTDialog("Disabling Calculation...");
        dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=SetProperty&ID=" + sItemID + "&PlannerID=" + sPlannerID + "&Property=FAC&Value=0", DisableCalcClose);
    }
    else {
        ShowTDialog("Enabling Calculation...");
        dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=SetProperty&ID=" + sItemID + "&PlannerID=" + sPlannerID + "&Property=FAC&Value=1", DisableCalcClose);
    }
}

function DisableCalcClose(loader) {
    HideTDialog();
    if (loader.xmlDoc.responseText != null) {
        if (loader.xmlDoc.responseText.trim() != "Success") {
            alert(loader.xmlDoc.responseText.trim());
        }
        else {
            if (Grids.WorkPlannerGrid.Calculated == 1) {
                Grids.WorkPlannerGrid.ActionCalcOff();
            }
            else {
                Grids.WorkPlannerGrid.ActionCalcOn();
            }
            RefreshCommandUI();
        }
    }
}

function Expand(level) {

    if (level == "-1")
    { return; }

    if (level == "99") {
        Grids.WorkPlannerGrid.ActionExpandAll();
    }
    else {
        var grid = Grids.WorkPlannerGrid;

        var iLevel = parseInt(level) + 1;

        for (var R in grid.Rows) {
            if (R != "Header" && R != "Toolbar" && R != "Footer") {
                var row = grid.GetRowById(R);

                if (row.Def != null && row.Def.Name != "Folder") {
                    if (grid.HasChildren(row)) {

                        if (row.Level < iLevel) {
                            grid.Expand(row);
                        }
                        else {
                            grid.Collapse(row);
                        }
                    }
                }
            }
        }

    }
}

function ClearBaseline() {
    var grid = Grids.ProjectInfo;
    var row = grid.GetRowById(sPlannerID + "BD");
    var lastb = "";

    if (row != null)
        lastb = grid.GetValue(row, "V");

    if (lastb != "") {
        if (confirm("Would you like to overwrite the baseline saved on: " + new Date(lastb).toString())) {
            ShowTDialog("Clearing Baseline...");
            setTimeout("DoClearBaseline()", 100);
        }
    }
}

function ExcelExport() {
    Grids.WorkPlannerGrid.ActionExport();
}

function PDFExport() {
    Grids.WorkPlannerGrid.ActionExportPDF();
}

function DoClearBaseline() {

    var grid = Grids.WorkPlannerGrid;
    grid.ActionCalcOff();
    for (var R in grid.Rows) {
        if (R != "Header" && R != "Toolbar") {
            var row = grid.GetRowById(R);

            for (var col in oBaselineFields) {

                grid.SetValue(row, oBaselineFields[col], "", 1);

            }

            grid.SetValue(row, "BaselineDateRange", "", 1);
        }
    }
    Grids.ProjectInfo.SetValue(Grids.ProjectInfo.GetRowById(sPlannerID + "BD"), "V", "", 1, 0);
    grid.ActionCalcOn();
    HideTDialog();
}


function SetBaseline() {
    if (sBaselineDate == "") {
        ShowTDialog("Setting Baseline...");
        setTimeout("DoSetBaseline()", 100);
    }
    else {
        if (confirm("Would you like to overwrite the baseline saved on: " + new Date(sBaselineDate).toString())) {
            ShowTDialog("Setting Baseline...");
            setTimeout("DoSetBaseline()", 100);
        }
    }
}

function CancelBubbling(obj, evt) {
    evt.Handled = true;
    var e = (evt) ? evt : window.event;
    if (window.event) {
        e.cancelBubble = true;
    }
    else {
        e.stopPropagation();
    }
}

function newtaskfocus(textfield) {
    if (textfield.value == newtasktext) {
        textfield.value = "";
        textfield.style.color = "#444444";
    }
}

function newtaskblur(textfield) {
    if (textfield.value == "") {
        textfield.value = newtasktext;
        textfield.style.color = "#9C9C9C";
    }
}

function newtaskkeypress(textfield, event, agilegrid) {
    if (event.which == 13 || event.keyCode == 13) {
        if (textfield.value != newtasktext && textfield.value != "") {
            var rid = NewTask(false, false, false, agilegrid, false, true);
            var grid = Grids.WorkPlannerGrid;
            var row = grid.GetRowById(rid);
            if (row) {
                grid.SetValue(row, "Title", textfield.value, 1, 0);
                textfield.value = "";
            }
        }
        event.preventDefault();
        return false;
    }

}

function LeavePage(e) {
    try {
        var sBin = Grids.WorkPlannerGrid.HasChanges().toString(2);
        if (sBin[sBin.length - 1] == "1") {
            if (!e) e = window.event;
            //e.cancelBubble is supported by IE - this will kill the bubbling process.
            //e.cancelBubble = true;
            e.returnValue = 'Your plan has unsaved changes.'; //This is displayed on the dialog

            //e.stopPropagation works in Firefox.
            if (e.stopPropagation) {
                e.stopPropagation();
                e.preventDefault();
            }
        }
    } catch (e) { }
}

function DoSetBaseline() {

    var grid = Grids.WorkPlannerGrid;
    grid.ActionCalcOff();
    for (var R in grid.Rows) {
        if (R != "Header" && R != "Toolbar") {
            var row = grid.GetRowById(R);

            for (var col in oBaselineFields) {

                grid.SetValue(row, oBaselineFields[col], grid.GetValue(row, col), 1);

            }

            try {
                var s = grid.GetValue(row, "StartDate");
                var f = grid.GetValue(row, "DueDate");
                if (s != "" && f != "") {
                    grid.SetValue(row, "BaselineDateRange", s + "~" + f, 1);
                }
            } catch (e) { }
        }
    }
    grid.ActionCalcOn();
    var dt = new Date();

    dhtmlxAjax.post("WorkPlannerAction.aspx", "Action=SetProperty&ID=" + sItemID + "&PlannerID=" + sPlannerID + "&Property=BD&Value=" + dt.toLocaleString(), DoSetBaselineClose);

    try {
        Grids.ProjectInfo.SetValue(Grids.ProjectInfo.GetRowById(sPlannerID + "BD"), "V", dt.valueOf(), 1, 0);
    } catch (e) { }

    setTimeout("DoSetBaselinePJ()", 100);

}

function DoSetBaselinePJ() {
    for (var col in oBaselineFields) {
        RollupSummaryField(oBaselineFields[col]);
    }
    HideTDialog();
}


function DoSetBaselineClose(loader) {
    HideTDialog();
    if (loader.xmlDoc.responseText != null) {
        if (loader.xmlDoc.responseText.trim() != "Success") {
            alert(loader.xmlDoc.responseText.trim());
        }
        else {
            RefreshCommandUI();
        }
    }
}

function onUpdateProject(dialogResult, returnValue) {
    if (dialogResult == SP.UI.DialogResult.OK) {
        var grid = Grids.WorkPlannerGrid;

        var sDate = new Date(returnValue);
        var sDate = new Date(sDate.toDateString());

        for (var R in grid.Rows) {
            if (R != "Header" && R != "Toolbar" && R != "NewTask") {
                var row = grid.GetRowById(R);
                if (row.Kind == "Data") {
                    try {
                        var f = new Date(row.DueDate);
                        var finish = new Date(f.toDateString());
                        var s = new Date(row.StartDate);
                        var start = new Date(s.toDateString());

                        if (finish < sDate) {
                            SetPlannerFieldValue(row, "PercentComplete", 100, true);
                            //grid.SetValue(row, "PercentComplete", 100, 1);
                        }
                        else if (start < sDate) {

                            var mDiff = finish - start;
                            var pDiff = sDate - start;
                            SetPlannerFieldValue(row, "PercentComplete", pDiff / mDiff * 100, true);
                            //grid.SetValue(row, "PercentComplete", pDiff / mDiff * 100, 1);
                        }
                    } catch (e) { }
                }
            }
        }
    }
}

function MoveProject() {

    curTempDate = Grids.WorkPlannerGrid.Cols["G"].GanttBase;

    var options = { url: "SelectDate.aspx", width: 250, height: 280, title: "Move Project", dialogReturnValueCallback: onMoveProject };

    SP.UI.ModalDialog.showModalDialog(options);
}

function onMoveProject(dialogResult, returnValue) {
    if (dialogResult == SP.UI.DialogResult.OK) {

        setTimeout("SetProjectStartDate('" + returnValue + "')", 100);
    }
}



function SetProjectStartDate(idate) {

    var date = new Date(idate).setHours(0, 0, 0, 0);

    date = Grids.WorkPlannerGrid.RoundGanttDate(date.valueOf(), 8);
    //date = new Date(new Date(Date.UTC(date.getYear(), date.getMonth(), date.getDate())).toUTCString());

    Grids.WorkPlannerGrid.SetGanttBase(date, 2, null);

    Grids.ProjectInfo.SetValue(Grids.ProjectInfo.GetRowById("Start"), "V", date, 1, 0);

    Grids.WorkPlannerGrid.Cols["G"].GanttBase = date;
}

function CheckProjectStart() {

    var grid = Grids.ProjectInfo;

    if (grid.GetValue(grid.GetRowById("Start"), "V") == "") {
        SetProjectStartDate(new Date().toDateString());
    }

}

function setHeight() {
    //dhxLayout.cells("b").setHeight((getHeight() - getTop(document.getElementById("parentId"))));
    document.getElementById("parentId").style.height = (getHeight() - getTop(document.getElementById("parentId"))) + "px";
    document.getElementById("parentId").style.width = (getWidth() - 20) + "px";
    dhxLayout.setSizes();
}

function getHeight() {
    var scnHei;
    if (self.innerHeight) // all except Explorer
    {
        //scnWid = self.innerWidth;
        scnHei = self.innerHeight;
    }
    else if (document.documentElement && document.documentElement.clientHeight) {
        //scnWid = document.documentElement.clientWidth;
        scnHei = document.documentElement.clientHeight;
    }
    else if (document.body) // other Explorers
    {
        //scnWid = document.body.clientWidth;
        scnHei = document.body.clientHeight;
    }
    return scnHei;
}

function getWidth() {
    var scnWid;
    if (self.innerHeight) // all except Explorer
    {
        scnWid = self.innerWidth;
        //scnHei = self.innerHeight;
    }
    else if (document.documentElement && document.documentElement.clientHeight) {
        scnWid = document.documentElement.clientWidth;
        //scnHei = document.documentElement.clientHeight;
    }
    else if (document.body) // other Explorers
    {
        scnWid = document.body.clientWidth;
        //scnHei = document.body.clientHeight;
    }
    return scnWid;
}
//Import Functions
function ImportExcel() {

    var options = { url: "ImportExcel.aspx?ID=" + sItemID + "&PlannerID=" + sPlannerID + "", title: "Excel Import", dialogReturnValueCallback: ImportClose };

    SP.UI.ModalDialog.showModalDialog(options);

}

function ImportCsv() {

    var options = { url: "ImportCsv.aspx?ID=" + sItemID + "&PlannerID=" + sPlannerID + "", title: "Csv Import", dialogReturnValueCallback: ImportClose };

    SP.UI.ModalDialog.showModalDialog(options);

}

function ImportList() {

    var options = { url: "ImportList.aspx?ID=" + sItemID + "&PlannerID=" + sPlannerID + "", title: "List Import", dialogReturnValueCallback: ImportClose };

    SP.UI.ModalDialog.showModalDialog(options);

}

function ImportClose(dialogResult, returnValue) {
    if (dialogResult == SP.UI.DialogResult.OK) {

        location.href = location.href;

    }
}

function RefreshResourceUsage(rowid) {
    var grid = Grids.WorkPlannerGrid;
    var row = grid.GetRowById(rowid);

    if (row.Def && row.Def.Name == "Assignment") {
        if (!grid.Resources[row.ResourceNames]) {
            grid.Resources[row.ResourceNames] = new Object();
            grid.Resources[row.ResourceNames].Name = row.Title;
            grid.Resources[row.ResourceNames].Availability = iWorkHours;
            grid.Resources[row.ResourceNames].Type = 1;

            var newrow = Grids.AllocationGrid.AddRow(null, null, true, row.Title, null);
            Grids.AllocationGrid.SetValue(newrow, "NAME", row.Title, 1);
            Grids.AllocationGrid.SetValue(newrow, "MAX", iWorkHours, 1);
            Grids.AllocationGrid.SetValue(newrow, "TYPE", 1, 1);
        }
    }
}

//=======================EPK===============

function EPKEnabled(control) {
    if (control == "costs" && EPKCost != 0)
        return true;
    if (control == "resplan" && EPKResPlan != 0)
        return true;
}

function EditCosts() {
    var FullId = sWebId + "." + sProjectListId + "." + sItemID;

    weburl = sWebUrl + "/_layouts/ppm/costs.aspx?itemid=" + FullId + "&listid=" + sProjectListId + "&view=";

    var options = { url: weburl, showMaximized: true, showClose: false };

    SP.UI.ModalDialog.showModalDialog(options);
}

function EditResourcePlan() {
    if (EPKResPlan == 1) {

        ShowTDialog("Loading...");

        dhtmlxAjax.post(sWebUrl + "/_layouts/ppm/gridaction.aspx?action=postepkmultipage", "IDs=" + sWebId + "." + sProjectListId + "." + sItemID, EditResourcePlanResponse);

    }
    else if (EPKResPlan == 2) {
        var FullId = sWebId + "." + sProjectListId + "." + sItemID;

        var weburl = sWebUrl + "/_layouts/ppm/rpeditor.aspx?itemid=" + FullId;

        var options = { url: weburl, showMaximized: true, showClose: false };

        SP.UI.ModalDialog.showModalDialog(options);
    }
}

function EditResourcePlanResponse(ret) {
    var ticket = ret.xmlDoc.responseText;

    HideTDialog();

    var weburl = sWebUrl + "/_layouts/ppm/gridaction.aspx?action=epkmultipage&ticket=" + ticket + "&epkcontrol=rpeditor&view=&listid=" + sProjectListId;

    var options = { url: weburl, showMaximized: true, showClose: false };

    SP.UI.ModalDialog.showModalDialog(options);
}


function LinkExternalTask() {

    var weburl = sWebUrl + "/_layouts/epmlive/workplanlinktask.aspx?PlannerID=" + sPlannerID;

    var options = { url: weburl, width: 800, height: 600, showClose: true, dialogReturnValueCallback: AddExternalTask };

    SP.UI.ModalDialog.showModalDialog(options);

}

function AddExternalTask(dialogResult, returnValue) {
    if (dialogResult == SP.UI.DialogResult.OK) {

        grid = Grids.WorkPlannerGrid;

        var rowid = NewTask(false, false, false, false, true);

        var newRow = grid.GetRowById(rowid);

        var ntRow = returnValue.Row;



        grid.ActionCalcOff();

        //grid.SetValue(newRow, "StartDate", ntRow["StartDate"], 1, 0);
        //grid.SetValue(newRow, "DueDate", ntRow["DueDate"], 1, 0);
        //grid.SetValue(newRow, "Title", ntRow["Title"], 1, 0);
        //grid.SetValue(newRow, "Duration", ntRow["Duration"], 1, 0);

        for (var c in grid.Cols) {
            if (c != "id") {
                if (validExternalField(c))
                    SetPlannerFieldValue(newRow, c, ntRow[c], true);
                //grid.SetValue(newRow, c, ntRow[c], 1, 0);
            }
        }

        grid.SetValue(newRow, "ExternalLink", sPlannerID + "." + returnValue.ProjectID + "." + ntRow.id, 1, 0);
        grid.SetValue(newRow, "LinkedTask", 1, 1, 0);
        grid.SetValue(newRow, "IsExternal", 1, 1, 0);
        grid.SetValue(newRow, "Predecessors", "", 1, 0);
        grid.SetValue(newRow, "Descendants", "", 1, 0);
        grid.SetValue(newRow, "PercentComplete", ntRow["PercentComplete"], 1, 0);

        grid.ActionCalcOn();
    }
}

function AcceptExternal() {

    var grid = Grids.WorkPlannerExternalLinks;
    var wgrid = Grids.WorkPlannerGrid;

    for (var row in grid.Rows) {
        var orow = grid.Rows[row];


        if (orow.Reject == "1") {

            if (orow.Action == "Add") {

                orow = wgrid.GetRowById(orow.puid);

                wgrid.DeleteRow(orow, 2);
            }
            else {
                orow = wgrid.GetRowById(orow.puid);

                wgrid.SetValue(orow, "StartDate", wgrid.GetValue(orow, "OldStartDate"), 1, 1);
                wgrid.SetValue(orow, "DueDate", wgrid.GetValue(orow, "OldDueDate"), 1, 1);
            }

        }
    }



}

function validExternalField(field) {

    if (field == "ExternalLink" || field == "IsExternal" || field == "Predecessors" || field == "Descendants")
        return false;

    return true;
}

//=======================Init Functions===============================
function InitGantt() {


    var WGrid = Grids.WorkPlannerGrid;
    var AGrid = Grids.AgileGrid;
    var RGrid = Grids.AllocationGrid;

    WGrid.SetValue(WGrid.GetRowById("0"), "Title", sProjectName, 1, 0);

    //WGrid.ActionZoomFit();
    WGrid.ChangeZoom("z6");


    try {
        var date = new Date(Grids.WorkPlannerGrid.Cols["G"].GanttBase);
        RGrid.ScrollToDate(date, "left");
    } catch (e) { }


    try {
        RGrid.ActionZoomFit();
        //RGrid.ChangeZoom("z6");
    } catch (e) { }
    //WGrid.HideCol("G");



    if (bAgile) {
        AGrid.SetValue(WGrid.GetRowById("0"), "Title", sProjectName, 1, 0);
        AGrid.ActionZoomFit();
        //AGrid.ChangeZoom("z6");
    }
    //dhxLayout.cells("c").collapse();

    dhxTabbar.setTabActive("t1");

    SetSplashText("Checking Structure...");
    setTimeout("InitStructure()", 100);
}

function InitStructure() {
    var WGrid = Grids.WorkPlannerGrid;
    SetProjectInfoFieldsEdit();
    setWBSAndTaskID(WGrid.GetRowById("0"));

    if (bAgile) {
        WGrid.ShowDetail(WGrid.GetRowById("BacklogRow"), "AgileGrid");
    }

    SetSplashText("Loading Resources...");
    setTimeout("InitResources()", 100);
}


function InitView() {
    for (var view in viewObject) {
        curView = viewObject[view]["title"];

        if (viewObject[view]["details"] == "true")
            dhxLayout.cells(detailsCell).expand();
        else
            dhxLayout.cells(detailsCell).collapse();

        try {
            if (viewObject[view]["allocation"] == "true")
                dhxLayout.cells(allocCell).expand();
            else
                dhxLayout.cells(allocCell).collapse();
        } catch (e) { }

        try {
            if (viewObject[view]["backlog"] == "true")
                dhxLayout.cells(agileCell).expand();
            else
                dhxLayout.cells(agileCell).collapse();
        } catch (e) { }

        var grid = Grids.WorkPlannerGrid;

        if (viewObject[view]["filters"] == "") {
            grid.ActionFilterOff();
        }
        else {
            var filters = viewObject[view]["filters"].split("^");
            if (filters[0] != "1")
                grid.ActionFilterOff();
        }
        //iChangeView(v);
        break;
    }

    //HideTDialog();
    SetSplashText("Finalizing...");
    setTimeout("InitFinal()", 1000);
}

function InitLinked() {

    if (CanLinkExternal) {

        var grid = Grids.WorkPlannerGrid;
        var row = grid.GetRowById("ExternalTasks");
        if (row) {
            if (row.Title != "") {

                var tgrid = Grids.WorkPlannerExternalLinks;

                var links = row.Title.split(',');

                for (var ilink in links) {
                    var link = links[ilink];
                    var linkinfo = link.split(':');


                    var r = grid.GetRowById(linkinfo[1]);

                    var trow = grid.MoveRowsToGrid(r, tgrid, null, 2, 2);

                    tgrid.ChangeDef(trow, "Task", 1, 0);

                    tgrid.SetAttribute(trow, "Reject", "CanEdit", "1");
                    tgrid.RefreshCell(trow, "Reject");

                    if (linkinfo[0] == "A")
                        tgrid.SetValue(trow, "Action", "Add", 1, 1);
                    else if (linkinfo[0] == "U")
                        tgrid.SetValue(trow, "Action", "Update", 1, 1);

                    tgrid.SetValue(trow, "puid", r.id);
                }

                tgrid.ChangeSort("taskorder");
                tgrid.SortRows();

                var divexternal = document.getElementById("divExternalLinkAccept");

                var options = {
                    html: divexternal, width: 600, height: 400, showClose: false, allowMaximize: false, title: "External Links"
                };

                SP.UI.ModalDialog.showModalDialog(options);


            }
        }
    }
}

function InitResources() {

    //RefreshResourceObject();

    try {
        var grid = Grids.WorkPlannerGrid;
        Grids.AllocationGrid.ActionCalcOff();
        for (var r in grid.Rows) {
            var row = grid.Rows[r];
            if (row.Def && row.Def.Name == "Assignment") {
                if (!grid.Resources[row.Title]) {
                    grid.Resources[row.Title] = new Object();
                    grid.Resources[row.Title].Name = row.Title;
                    grid.Resources[row.Title].Availability = iWorkHours;
                    grid.Resources[row.Title].Type = 1;

                    var newrow = Grids.AllocationGrid.AddRow(null, null, true, row.Title, null);
                    Grids.AllocationGrid.SetValue(newrow, "NAME", row.Title, 1);
                    Grids.AllocationGrid.SetValue(newrow, "MAX", iWorkHours, 1);
                    Grids.AllocationGrid.SetValue(newrow, "TYPE", 1, 1);
                }
            }
        }
        Grids.AllocationGrid.ActionCalcOn();
        ResizeGantt(grid, Grids.AllocationGrid);
    } catch (e) { }

    SetSplashText("Loading View...");
    setTimeout("InitView()", 100);
}


function InitFinal() {

    CheckProjectStart();

    document.getElementById("txtNewTask").value = newtasktext;
    try {
        document.getElementById("txtNewTask2").value = newtasktext;
    } catch (e) { }
    setTimeout("InitFinal2()", 100);

}

function InitFinal2() {
    var WGrid = Grids.WorkPlannerGrid;
    var AGrid = Grids.AgileGrid;

    //ApplyDefaults(WGrid, WGrid.GetRowById("NewTask"));

    if (bAgile) {
        var backlog = WGrid.GetRowById("BacklogRow");

        HideBacklogRows(WGrid, backlog);
        WGrid.HideRow(backlog);
    }

    setTimeout("CloseInit()", 100);

    bRendering = false;
}

function CloseInit() {
    document.getElementById("divCover").style.display = "none";
    hm("dlgSplash");
    setTimeout("InitLinked()", 100);

}

function HideBacklogRows(grid, row) {
    try {
        var child = row.firstChild;

        while (child) {
            HideBacklogRows(grid, child);
            grid.HideRow(child);
            child = child.nextSibling;
        }
    } catch (e) { }
}

function ShowBacklogRows(grid, row) {
    var child = row.firstChild;



    while (child) {
        ShowBacklogRows(grid, child);
        if (child.Def.Name == "Assignment") {
            if (oShowAssignments)
                grid.ShowRow(child);
        }
        else {
            grid.ShowRow(child);
        }
        grid.RefreshRow(child);
        child = child.nextSibling;
    }
}

