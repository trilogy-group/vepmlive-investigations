var ArrGantts = new Array();

if (!Array.prototype.indexOf) {
    Array.prototype.indexOf = function (needle) {
        for (var i = 0; i < this.length; i++) {
            if (this[i] === needle) {
                return i;
            }
        }
        return -1;
    };
}

Grids.OnSelect = function (grid, row, deselect) {

    //curGrid = eval("mygrid" + grid.id.substr(9));
    //curRowId = row.id;

    RefreshCommandUI();
    //setTimeout("RefreshCommandUI()", 100);
}

Grids.OnFocus = function (grid, row, col, orow, ocol, pagepos) {
    //grid.ClearSelection();
    //grid.SelectRow(row, true);
    
    curGrid = eval("mygrid" + grid.id.substr(9));
    //curRowId = row.id;

    //RefreshCommandUI();
}

/*
Grids.OnSelect = function (grid, row, deselect) {

    //curGrid = eval("mygrid" + grid.id.substr(9));
    //curRowId = row.id;

    RefreshCommandUI();
    //setTimeout("RefreshCommandUI()", 100);
}


Grids.OnRenderFinish = function (grid) {
grid.ActionZoomFit();
grid.ChangeZoom("z6");
}*/

function GanttZoomIn(gridid) {
    var grid = Grids["GanttGrid" + gridid];
    grid.ActionZoomIn();
}

function GanttZoomOut(gridid) {
    var grid = Grids["GanttGrid" + gridid];
    grid.ActionZoomOut();
}

function GanttScrollTo(gridid) {
    var grid = Grids["GanttGrid" + gridid];
    var row = grid.FRow;
    if (row != null) {
        var sDate = grid.GetValue(row, "StartDate")
        if (sDate != "") {
            var date = new Date(sDate);
            grid.ScrollToDate(date, "left");
        }
    }
}