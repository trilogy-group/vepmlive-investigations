function AgileNewIteration() {

    var grid = Grids.WorkPlannerGrid;

    var newId = grid.GenerateId();

    //var iRow = FindLastIterationRow(grid, grid.GetRowById("0").firstChild);

    newrow = grid.AddRow(grid.GetRowById("0"), grid.GetRowById("BacklogRow"), true, newId, "Iteration");

    grid.SetValue(newrow, 'Title', 'New Iteration', true);

    setDefaultDates(grid, newrow);

    grid.Focus(newrow, 'Title');
}

function AgileDeleteItem() {
    var agrid = Grids.AgileGrid;
    var grid = Grids.AgileGrid;

    if (!agrid.EditMode) {
        selRows = agrid.GetSelRows();
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

function EnterButtonA(grid) {
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
            var newtask = grid.GetRowById(NewTask(false,false,false,true));

            grid.Focus(newtask, grid.FCol, null, 1);
        }

        Grids.WorkPlannerGrid.HideRow(Grids.WorkPlannerGrid.GetRowById(newtask.id));
    }
}

function DoNewRowA() {

    var grid = Grids.WorkPlannerGrid;
    var agrid = Grids.AgileGrid;

    agrid.EndEdit(true);

    /*if (agrid.GetLast(null, 0).id == "0")
        var newRow = grid.AddRow(grid.GetRowById("BacklogRow", null, true, grid.GenerateId(), "Task");
    else {

        var lRow = agrid.GetLast(null, 0);

        if (lRow.Def.Name == "Assignment")
            lRow = lRow.parentNode;

        var newRow = grid.AddRow(lRow.parentNode, null, true, grid.GenerateId(), "Task");

    }*/
    
    var newRow = grid.AddRow(grid.GetRowById("BacklogRow"), null, true, grid.GenerateId(), "Task");
    var ntRow = agrid.GetRowById("NewTask");
    for (var c in grid.Cols) {
        if (c != "id") {
            grid.SetValue(newRow, c, agrid.GetValue(ntRow, c), 1, 0);
            agrid.SetValue(ntRow, c, "", 1, 0);
        }
    }
    
    agrid.SetValue(ntRow, "Title", "New Item", 1, 0);

    ApplyDefaults(agrid, ntRow);

    setWBSAndTaskID(grid.GetRowById('0'));

    bNewRowHasChanged = false;

    grid.HideRow(grid.GetRowById(newRow.id));

    return newRow;
}

function FindLastIterationRow(grid) {
    var child = grid.GetRowById("0").firstChild;
    var iteration = null;

    while (child) {
        if (child.Def.Name == "Iteration")
            iteration = child;
        child = child.nextSibling;
    }

    return iteration;
}

function AgileSelectColumns() {
    Grids.AgileGrid.ActionShowColumns();
}

//function AgileGridMove(grid, row, togrid, torow, copy) {
function AgileGridMove(grid, row) {
    


    if (grid.id == "WorkPlannerGrid") {
        RollDownFromParent(grid, row);
        for (var c in oRollDown) {
            RollDown(row, c);
        }
    }

    if (row.Def.Name != "Iteration") {
        var iRow = FindParentIteration(grid, row);

        if (iRow) {
            grid.ShowRow(row);
            grid.RefreshRow(row);
            ShowBacklogRows(grid, row);

        }
        else {
            HideBacklogRows(row);
            grid.HideRow(row);
        }
    }
    //if (grid.id == "WorkPlannerGrid" && togrid.id == "AgileGrid") {
    //    togrid.SetValue(torow, "WBS", "");
    //    torow.id = row.id;
    //}

}


function ChangeAgileView(view) {
    
    var VIEWcols = viewObject[view]["agilecols"];
    var VIEWleftcols = viewObject[view]["agileleft"];
    var VIEWgantt = viewObject[view]["agilegantt"];
    var VIEWfilters = viewObject[view]["agilefilters"];
    var VIEWgrouping = viewObject[view]["agilegrouping"];
    var VIEWsorting = viewObject[view]["agilesorting"];
    //var VIEWbacklog = viewObject[view]["backlog"];

    if (!VIEWcols)
        VIEWcols = viewObject[view]["cols"];
    if (!VIEWleftcols)
        VIEWleftcols = viewObject[view]["leftCols"];
    if (!VIEWgantt)
        VIEWgantt = viewObject[view]["gantt"];
    if (!VIEWfilters)
        VIEWfilters = viewObject[view]["filters"];
    if (!VIEWgrouping)
        VIEWgrouping = viewObject[view]["grouping"];
    if (!VIEWsorting)
        VIEWsorting = viewObject[view]["sorting"];

    curView = viewObject[view]["title"];

    var grid = Grids.AgileGrid;

    var cols = VIEWcols.split(",");
    var leftCols = VIEWleftcols.split(",");
    var allCols = (VIEWleftcols + "," + VIEWcols).split(",");

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

    //grid.ChangeColsPositions(leftCols, cols, ["G"]);
    grid.ChangeColsVisibility(allCols, mainCols, 0);
    grid.ShowCol("Notifications");
    grid.ShowCol("Panel");
    //grid.ChangeColsVisibility(allCols, "", 0);
    
    if (VIEWgantt == "1")
        grid.ShowCol("G");
    else
        grid.HideCol("G");

    //================Filters================
    if (VIEWfilters == "") {
        grid.ChangeFilter("", "", "", 0, 0, null);
    }
    else {
        var filters = VIEWfilters.split("^");
        try {
            if (filters[0] == "1" || filters[0] == "true")
                grid.ShowRow(grid.GetRowById("Filter"));
            else
                grid.HideRow(grid.GetRowById("Filter"));
        } catch (e) { }
        grid.ChangeFilter(filters[1], filters[2], filters[3], 0, 0, null);
    }

    //==============sorting======================
    grid.sort = VIEWsorting;
    grid.SortRows();
    //=============grouping=====================
    if (VIEWgrouping == "") {
        grid.DoGrouping(null);
        grid.HideRow(grid.GetRowById("GroupRow"));
    }
    else {
        var grouping = VIEWgrouping.split("^");

        if (grouping[0] == "true" || grouping[0] == "1")
            grid.ShowRow(grid.GetRowById("GroupRow"));
        else
            grid.HideRow(grid.GetRowById("GroupRow"));

        grid.DoGrouping(grouping[1]);
    } grid.HideRow(grid.GetRowById("GroupRow"));
    
    grid.Render();

    try {
        if (viewObject[view]["backlog"] == "true")
            dhxLayout.cells(agileCell).expand();
        else
            dhxLayout.cells(agileCell).collapse();
    } catch (e) { }
}

function AgileShowGantt() {
    var grid = Grids.AgileGrid;
    if (grid.Cols.G.Visible)
        grid.HideCol("G");
    else
        grid.ShowCol("G");
}

function AgileScrollTo() {
    var grid = Grids.AgileGrid;
    var row = grid.FRow;
    if (row != null) {
        var sDate = grid.GetValue(row, "StartDate")
        if (sDate != "") {
            var date = new Date(sDate);
            grid.ScrollToDate(date, "left");
        }
    }
}


function AgileZoomIn() {
    if (AgileCanZoomIn()) {
        Grids.AgileGrid.ActionZoomIn();
        AgileScrollTo();
        RefreshCommandUI();
    }
}

function AgileZoomOut() {
    if (AgileCanZoomOut()) {
        Grids.AgileGrid.ActionZoomOut();
        AgileScrollTo();
        RefreshCommandUI();
    }
}

function AgileCanZoomOut() {
    try {
        return Grids.AgileGrid.CanZoomOut();
    } catch (e) { }
    return false;
}

function AgileCanZoomIn() {
    try {
        return Grids.AgileGrid.CanZoomIn();
    } catch (e) { }
    return false;
}

function AgileShowFilters() {
    var grid = Grids.AgileGrid;
    var row = grid.GetRowById("Filter");
    try {
        if (row.Visible)
            grid.HideRow(row);
        else
            grid.ShowRow(row);
    } catch (e) { }
}

function AgileAddItem() {
    var newid = NewTask(false, false, false, true);
    var newrow = Grids.WorkPlannerGrid.GetRowById(newid);
    Grids.WorkPlannerGrid.HideRow(newrow);

    newrow = Grids.AgileGrid.GetRowById(newrow.id);
    Grids.AgileGrid.Focus(newrow, 'Title');
}


function AgileOutdent() {
    var grid = Grids.AgileGrid;
    grid.EndEdit(true);
    var orows = grid.GetSelRows();

    for (var i = orows.length - 1; i >= 0; i--) {
        var row = orows[i];

        if (row.Def.Name != "Folder" && row.parentNode != null && row.parentNode.Def.Name != "Folder" && row.parentNode.id != "BacklogRow") {

            var parent = row.parentNode;

            var sibling = row.nextSibling;
            var oSiblings = new Array();

            while (sibling != null) {
                oSiblings.push(sibling.id);
                sibling = sibling.nextSibling;
            }

            row = grid.GetRowById(row.id);

            grid.MoveRow(row, row.parentNode.parentNode, row.parentNode.nextSibling, 1);

            for (var s in oSiblings) {
                grid.MoveRow(grid.GetRowById(oSiblings[s]), row, null, 1);
            }

            //grid.MoveRow(row, row.parentNode.parentNode, null, 1);


        }
    }


}

function AgileIndent() {

    var grid = Grids.WorkPlannerGrid;

    grid.EndEdit(true);

    Grids.AgileGrid.EndEdit(true);

    var orows = Grids.AgileGrid.GetSelRows();

    for (var i = 0; i < orows.length; i++) {
        var row = grid.GetRowById(orows[i].id);
        if (row.Def.Name != "Folder" && row.previousSibling != null && row.previousSibling.Def.Name != "Folder") {

            grid.MoveRow(row, row.previousSibling, null, 1);

            grid.Expand(row.parentNode);
            grid.RefreshRow(row.parentNode);

            grid.Recalculate(row, "DueDate", 1);
            
            grid.Recalculate(row, "Duration", 1);
        }
    }
}


function FindLastIteration(grid) {

    var id = grid.GetRowById("Iteration", "Def.Name", true);

    alert(id);

}