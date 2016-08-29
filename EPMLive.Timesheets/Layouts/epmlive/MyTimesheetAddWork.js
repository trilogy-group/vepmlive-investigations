var spnMessage

function ShowSearch() {
    document.getElementById("divSearch").style.display = "";


}


function SearchWork() {

    ShowMessage("Searching...", 130, 40);

    var o = document.getElementById("ctl00_PlaceHolderMain_ddlField");
    var sText = document.getElementById("txtSearch").value;
    var sField = o.options[o.selectedIndex].value;

    var grid = Grids["TSWork"];

    var dataxml = sLayout;
    dataxml += " SearchField=\"" + sField + "\"";
    dataxml += " SearchText=\"" + escape(sText) + "\"";
    dataxml += "/&gt;";

    grid.Data.Data.Param.Dataxml = dataxml;

    grid.Reload();
}

function ShowMessage(message, w, h) {

    HideMessage();

    if (!spnMessage)
        spnMessage = document.getElementById("spnMessage");

    spnMessage.innerHTML = message;

    sm("divMessage", w, h);
}

function HideMessage() {
    hm("divMessage");
}

function AddItems(grid, items) {

    EPMLiveCore.WorkEngineAPI.ExecuteJSON("timesheet_AddWork", "<Work TSUID=\"" + TSUID + "\">" + items + "</Work>", function (response) {
        var oResponse = eval("(" + response + ")");

        if (oResponse.AddWork.Status == "0") {
            window.frameElement.commitPopup('Y');
        }
        else {
            alert(oResponse.AddWork.Text);
        }
        HideMessage();
    });

}

function SetChecked(grid, row, col, checked) {

    var child = row.firstChild;

    if (row.id == "Header")
        child = grid.GetFirst();

    if (child) {

        while (child) {
            SetChecked(grid, child, col, checked);

            grid.SetValue(child, col, checked, 1, 0);

            child = child.nextSibling;        
        }
    }

}

Grids.OnRenderStart = function (grid) {
    maximizeWindow();
}

Grids.OnRenderFinish = function (grid) {
    EPMLiveCore.WorkEngineAPI.set_path(siteUrl + '/_vti_bin/WorkEngine.asmx');

    try {
        HideMessage();
    } catch (e) { }
}

Grids.OnClick = function (grid, row, col, x, y, event) {

    if (grid && row && col) {

        if (col == "Check") {

            if (row.id == "Header") {
                if (grid.GetAttribute(row, col, "Class") == "GMBool0RO") {
                    curVal = "1";
                    grid.SetAttribute(row, col, "Class", "GMBool1RO", 1);
                }
                else {
                    curVal = "0";
                    grid.SetAttribute(row, col, "Class", "GMBool0RO", 1);
                }
            }
            else {
                var curVal = grid.GetValue(row, col);

                if (curVal == "0")
                    curVal = "1";
                else
                    curVal = "0";

                grid.SetValue(row, col, curVal, 1, 0);
            }

            if (row.Def.Name == "Group" || row.id == "Header") {

                SetChecked(grid, row, col, curVal);

            }
        }

    }

}

function ChangeView(grid, view) {
    

    var oView = Views[view];

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

    Show += ",Check";

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

    CurrentViewId = view;
    CurrentView = oView.Name;

    RefreshCommandUI();

    grid.Render();
}


function SaveView(grid, retval) {

    ShowMessage("Saving View...", 140, 35);

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

    EPMLiveCore.WorkEngineAPI.ExecuteJSON("timesheet_SaveWorkView", "<View Name=\"" + retval[0] + "\" Default=\"" + retval[1] + "\" Filters=\"" + filters + "\" Group=\"" + grid.Group + "\" Sort=\"" + grid.Sort + "\" Cols=\"" + sCols + "\" Expand=\"\" NonWork=\"" + NonWork + "\"/>", function (response) {
        var oResponse = eval("(" + response + ")");
        grid.StaticCursor = 1;

        HideMessage();

        if (oResponse.Views.Status == "0") {

            Views = eval("(" + oResponse.Views.Text.replace(/&quot;/g, "\"") + ")");

            for (var view in Views) {
                var oView = Views[view];

                if (oView.Name == retval[0]) {
                    CurrentView = retval[0];
                    CurrentViewId = view;
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