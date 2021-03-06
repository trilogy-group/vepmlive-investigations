﻿var ArrGantts = new Array();
var GridProperties = {};
var OnlyGrid = false;
var CurrentGrid;
var CurrentRow;

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

function GetGridId(grid) {
    return grid.id.substr(9);
}


function setupPage(records, UseReporting, PageSize, grid, startpage) {
    var gridid = GetGridId(grid);

    var pages = Math.ceil(records / PageSize);

    var prev = document.getElementById("PagePrevious" + gridid);
    var next = document.getElementById("PageNext" + gridid);
    var pagediv = document.getElementById("pagediv" + gridid);
    var viewalldiv = document.getElementById("viewalldiv" + gridid);
    var pagetable = document.getElementById("pagetable" + gridid);


    if (UseReporting) {
        if (pages > 1) {
            if (!grid.bPageSetup) {
                grid.bPageSetup = true;

                viewalldiv.style.display = "block";
                pagetable.style.display = "block";

                var p = $("#pagediv" + gridid).parent();
                $("#pagediv" + gridid).remove();
                p.append("<div id=\"pagediv" + gridid + "\"/>");

                if (startpage == "0")
                    startpage = "1";

                $("#pagediv" + gridid).paginate({
                    count: pages,
                    start: startpage,
                    display: 12,
                    border: true,
                    rotate: false,
                    images: false,
                    mouse: 'press',
                    onChange: ChangePage,
                    gridid: GetGridId(grid)
                });

            }
        }
        else {
            viewalldiv.style.display = "none";
            pagetable.style.display = "none";
        }
    }
    else {
        pagediv.style.display = "inline-block";
        var rec = records.split('|');

        var mygrid = eval("mygrid" + gridid);

        mygrid.PAGEfirstItem = parseInt(rec[2]) * -1;
        mygrid.PAGElastItem = rec[1];

        if (rec[0] == "0" || mygrid.PAGEfItemHide == mygrid.PAGEfirstItem) {

            prev.style.background = "#EFEFEF";
            prev.style.opacity = "0.5";
            mygrid.PAGEfItemHide = mygrid.PAGEfirstItem;
        }
        else {
            prev.style.background = "#DDDDDD";
            prev.style.opacity = "1";
        }

        if (rec[3] == "true") {
            next.style.background = "#DDDDDD";
            next.style.opacity = "1";
        }
        else {
            next.style.background = "#EFEFEF";
            next.style.opacity = "0.5";
            mygrid.PAGElastItem = 0;
        }

        if (rec[3] != "true" && rec[0] == "0") {
            pagetable.style.display = "none";
        }
    }
}

function GetPageHeight() {
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

function GetItemTop(obj) {
    var posY = obj.offsetTop;

    while (obj.offsetParent) {
        posY = posY + obj.offsetParent.offsetTop;
        if (obj == document.getElementsByTagName('body')[0]) { break }
        else { obj = obj.offsetParent; }
    }

    return posY;
}

$(window).resize(function () {
    for (var g in Grids) {
        if (g.substr(0, 9) == "GanttGrid") {
            SetGridSize(Grids[g]);
        }
    }
});


function SetGridSize(grid) {

    var gridid = GetGridId(grid);

    if (OnlyGrid) {


        var outer = document.getElementById("gridouter" + gridid);

        var height = GetPageHeight();
        var top = GetItemTop(outer);

        //document.getElementById("griddiv" + gridid).style.height = (height - top) + "px";
        var currentDialog = SP.UI.ModalDialog.get_childDialog();        if (currentDialog)
            outer.style.height = (height - top - 105) + "px";
        else
            outer.style.height = (height - top - 35) + "px";
        //document.getElementById("MSOZoneCell_WebPart").style.height = "400px";
    }
    else {
        var bodyheight = grid.GetBodyScrollHeight() + 60;
        if (bodyheight < 100)
            bodyheight = 100;
        var gridid = GetGridId(grid);
        var divOuter = document.getElementById("gridouter" + gridid);

        if (bodyheight > parseInt(eval("mygrid" + gridid + ".GridHeight"))) {
            divOuter.style.height = eval("mygrid" + gridid + ".GridHeight") + "px";
        }
        else
            divOuter.style.height = bodyheight + "px";



    }
}

function GetWebUrl() {
    if (_spPageContextInfo.webServerRelativeUrl == "/")
        return "";
    else return _spPageContextInfo.webServerRelativeUrl;
}


function GridListSettings(listid) {
    var $v_E = new SP.Guid(listid);
    var $v_F = GetWebUrl() + '/_layouts/15/listedit.aspx' + '?List=' + SP.Utilities.HttpUtility.urlKeyValueEncode($v_E.toString('B').toUpperCase());
    SP.Utilities.HttpUtility.navigateTo($v_F);
}

function GridListEditView(listid, viewid) {
    var $v_E = new SP.Guid(listid);
    var $v_C = new SP.Guid(viewid);
    var $v_F = GetWebUrl() + '/_layouts/15/epmlive/gridaction.aspx' + '?action=editview&List=' + SP.Utilities.HttpUtility.urlKeyValueEncode($v_E.toString('B').toUpperCase()) + '&View=' + SP.Utilities.HttpUtility.urlKeyValueEncode($v_C.toString('B').toUpperCase()) + '&Source=' + escape(document.location.href);
    SP.Utilities.HttpUtility.navigateTo($v_F);
}


function GridListCreateView(listid) {
    var $v_E = new SP.Guid(listid);
    var $v_F = GetWebUrl() + '/_layouts/15/ViewNew.aspx' + '?List=' + SP.Utilities.HttpUtility.urlKeyValueEncode($v_E.toString('B').toUpperCase()) + '&Source=' + escape(document.location.href);
    SP.Utilities.HttpUtility.navigateTo($v_F);
}

function GridUnSearch(gridid) {

    var grid = Grids["GanttGrid" + gridid];
    eval("mygrid" + gridid + ".CurPage='0'");
    eval("mygrid" + gridid + ".Searcher=''");
    ReloadGridWithNewParams(gridid);

}

function GridSearch(gridid, searchfield, searchvalue, searchtype) {

    var grid = Grids["GanttGrid" + gridid];
    if (!grid) {
        EPM.UI.Loader.current().startLoading({ id: 'WebPart' + eval("mygrid" + gridid + ".Qualifier") });
        eval("mygrid" + gridid + ".Searcher='&searchfield=" + searchfield + "&searchvalue=" + escape(searchvalue) + "&searchtype=" + searchtype + "'");
        TreeGrid({ Data: { Url: GetWebUrl() + "/_layouts/epmlive/getganttitems.aspx?data=" + eval("mygrid" + gridid + ".Params") + eval("mygrid" + gridid + ".Searcher") }, Export: { Url: GetWebUrl() + '/_layouts/15/epmlive/getgriditemsexport.aspx' }, SuppressMessage: 2, Debug: "" }, "griddiv" + gridid);
    }
    else {
        var grid = Grids["GanttGrid" + gridid];
        eval("mygrid" + gridid + ".CurPage='0'");
        eval("mygrid" + gridid + ".Searcher='&searchfield=" + searchfield + "&searchvalue=" + escape(searchvalue) + "&searchtype=" + searchtype + "'");
        ReloadGridWithNewParams(gridid);
    }

}

function GridOnLoaded(grid) {
    var gridid = GetGridId(grid);

    grid.Lang.Format.DecimalSeparator = eval("mygrid" + gridid + ".DecimalSeparator");
    grid.Lang.Format.GroupSeparator = eval("mygrid" + gridid + ".GroupSeparator");
}

var GridColumnWidthNamespace = 'GridColumnWidth';
function GridColumnWidthSet(col) {
    var contains = columnStatus.filter(function(x) { return x.Name == col });
    if (contains.length == 0) {
        columnStatus.push({ Name: col, Width: Grids[0].Cols[col].Width });
    } else {
        for (var i = 0; i < columnStatus.length; i++) {
            if (columnStatus[i].Name == col)
                columnStatus[i].Width = Grids[0].Cols[col].Width;
        }
    }

    var columnKeys = columnStatus.map(function(x) { return x.Name + '=' + x.Width });
    var columnKeysPlain = columnKeys.join(',');

    $.ajax({
        type: 'POST',
        url: window.epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
        data: "{ Function: 'personalization_Set', Dataxml: '<Data  Key=\"" + GridColumnWidthNamespace + "\"><Value>" + columnKeysPlain + "</Value><Filters>"
        + "<Filter Key=\"siteId\">" + window.epmLive.currentSiteId + "</Filter>"
        + "<Filter Key=\"listid\">" + window.epmLive.currentListId + "</Filter>"
        + "<Filter Key=\"webid\">" + window.epmLive.currentWebId + "</Filter>"
        + "</Filters></Data>' }",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function () { }, error: function (xhr, status, error) { alert(xhr.responseText); }
    });
}

var columnStatus = [];

function GridColumnWidthGet() {
    var columns = Object.keys(Grids[0].Cols).map(function (key, index) {
        return Grids[0].Cols[key];
    }).filter(function(x) { return x.Name != "Panel" && x.Visible === 1 });
    var columnKeys = columns.map(function(x) { return GridColumnWidthNamespace + '.' + x.Name });
    var columnKeysPlain = columnKeys.reduce(function (acc, name) { return acc + ',' + name; });

    $.ajax({
        type: 'POST',
        url: window.epmLive.currentWebFullUrl + '/_vti_bin/WorkEngine.asmx/Execute',
        data: "{ Function: 'personalization_Get', Dataxml: '<Data  Key=\"" + GridColumnWidthNamespace + "\"><Value>" + columnKeysPlain + "</Value><Filters>"
        + "<Filter Key=\"siteId\">" + window.epmLive.currentSiteId + "</Filter>"
        + "<Filter Key=\"listid\">" + window.epmLive.currentListId + "</Filter>"
        + "<Filter Key=\"webid\">" + window.epmLive.currentWebId + "</Filter>"
        + "</Filters></Data>' }",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (response) {
            var cdata = response.d.split('[CDATA[');

            if (cdata.length != 1) {
                var widthsPart = cdata[1].split(']]>')[0].split(',');
                var widths = widthsPart.map(function(x) { return { Name: x.split('=')[0], Width: x.split('=')[1] }; });
                for (var i = 0; i < widths.length; i++) {
                    var index = widths[i].Name;
                    var col = Grids[0].Cols[index];
                    if (typeof col == 'undefined') {
                        continue;
                    }
                    var width = +(widths[i].Width);
                    if (typeof col != 'undefined') {
                        delete Grids[0].Cols[index].RelWidth;
                    }
                    Grids[0].SetWidth(index, width - col.Width);
                }

                columnStatus = widths;
            }

            Grids.OnColResize = function (tgrid, col) {
                GridColumnWidthSet(col);
            };
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}


function GridOnReady(grid) {
    TGSetEvent("OnRenderFinish", grid.id, GridOnRenderFinish);
    TGSetEvent("OnGetHtmlValue", grid.id, GridOnGetHtmlValue);
    TGSetEvent("OnClick", grid.id, GridClick);
    TGSetEvent("OnClickOutside", grid.id, GridClickOutside);
    TGSetEvent("OnMouseOutRow", grid.id, GridOnMouseOutRow);
    TGSetEvent("OnMouseOverOutside", grid.id, GridOnMouseOverOutside);
    TGSetEvent("OnMouseOverRow", grid.id, GridOnMouseOverRow);
    TGSetEvent("OnSelect", grid.id, GridOnSelect);
    TGSetEvent("OnFocus", grid.id, GridOnFocus);
    TGSetEvent("OnDblClick", grid.id, GridOnDblClick);

    GridColumnWidthGet();

    var gridid = GetGridId(grid);

    var LinkType = eval("mygrid" + gridid + ".LinkType");

    if (LinkType == "") {
        if (grid.LinkTitleField == "LinkTitle")
            eval("mygrid" + gridid + ".LinkType='edit'");
        else if (grid.LinkTitleField == "LinkTitleNoMenu")
            eval("mygrid" + gridid + ".LinkType='view'");
    }
}



function GridOnRenderFinish(grid) {

    if (grid.id.substr(0, 9) == "GanttGrid") {

        TGSetEvent("OnAfterValueChanged", grid.id, GridOnAfterValueChanged);


        grid.EditRow = 0;
        var gridid = GetGridId(grid);

        if (!eval("mygrid" + gridid + ".loadedmenu")) {
            eval("mygrid" + gridid + ".loadedmenu = true;");
            grid.bPageSetup = false;

            try {
                eval("loadMenu" + gridid + "();");
            } catch (e) { }
            eval("mygrid" + gridid + ".Groups=''");
            eval("mygrid" + gridid + ".Cols=''");
            eval("mygrid" + gridid + ".NoPage=''");

            var ribbon = eval("mygrid" + gridid + ".RibbonBehavior");

            if (OnlyGrid) {
                if (ribbon == "1") {

                    var wp = document.getElementById('MSOZoneCell_WebPart' + eval("mygrid" + gridid + ".Qualifier"));

                    fireEvent(wp, 'mouseup');
                }
                else if (ribbon == "2") {

                }
                else {
                    var wp = document.getElementById('MSOZoneCell_WebPart' + eval("mygrid" + gridid + ".Qualifier"));

                    fireEvent(wp, 'mouseup');



                }
            }
        }

        if (ArrGantts.indexOf(grid.id) > -1)
            setupPage(grid.PagInfo, eval("mygrid" + gridid + ".UseReporting"), grid.PagSize, grid, eval("mygrid" + gridid + ".CurPage"));

        SetGridSize(grid);

        eval("EPM.UI.Loader.current().stopLoading('WebPart" + eval("mygrid" + gridid + ".Qualifier") + "')");

        document.getElementById("searchload" + grid.id.substr(9)).style.display = "";

        RefreshCommandUI();
    }
}

function GridOnGetHtmlValue(grid, row, col, val) {
    if (row.Def.Name == 'R') {
        if (col == "Title") {
            var gridid = GetGridId(grid);

            // get the grid action url
            var url = GetGridItemUrl(grid, row);
            if (!url) {
                url = 'javascript:;';
            }

            if (eval("mygrid" + gridid + ".LinkType")) {
                val = "<a onclick=\"GridGoToItem('" + grid.id + "','" + row.id + "'); return false;\" href=\"" + url + "\">" + val + "</a>";
            }

            if (grid.GetValue(row, "HasComments") == "1") {
                val = val + "&nbsp;<a href=\"javascript:GridComments('" + grid.id + "','" + row.id + "');\"><img src=\"/_layouts/15/epmlive/images/mywork/comment-small.png\" border=\"0\"></a>";
            }
            else if (grid.GetValue(row, "HasComments") == "2") {
                val = val + "&nbsp;<a href=\"javascript:GridComments('" + grid.id + "','" + row.id + "');\"><img src=\"/_layouts/15/epmlive/images/mywork/commentsnew-small.png\" border=\"0\"></a>";
            }

            if (grid.GetValue(row, "wsurl") != "") {
                val = val + "&nbsp;<a href=\"javascript:GridWorkspace('" + grid.id + "','" + row.id + "');\"><img src=\"/_layouts/15/epmlive/images/itemworkspace.png\" border=\"0\"></a>";
            }

            if (grid.GetValue(row, "HasPlan") == "1") {
                val = val + "&nbsp;<a href=\"#\"><span class=\"epm-nav-cm-icon fui-ext-project\">&nbsp;</span></a>";
            }

            return val;
        }
    }
    else if (row.id == "Header") {
        if (col == "State")
            return "State";
    }
}

function GridWorkspace(gridid, rowid) {
    var grid = Grids[gridid];
    var row = grid.GetRowById(rowid);
    CurrentGrid = grid;
    CurrentRow = row;

    gridid = GetGridId(grid);

    var url = window.epmLiveNavigation.currentWebUrl + "/_layouts/epmlive/gridaction.aspx?action=workspace&webid=" + row.webid + "&listid=" + row.listid + "&ID=" + row.itemid + "&Source=" + escape(location.href);

    location.href = url;
}

function GridComments(gridid, rowid) {
    var grid = Grids[gridid];
    var row = grid.GetRowById(rowid);
    CurrentGrid = grid;
    CurrentRow = row;

    gridid = GetGridId(grid);

    var url = window.epmLiveNavigation.currentWebUrl + "/_layouts/epmlive/gridaction.aspx?action=comments&webid=" + row.webid + "&listid=" + row.listid + "&ID=" + row.itemid + "&Source=" + escape(location.href);

    var options = window.SP.UI.$create_DialogOptions();

    options.url = url;
    options.width = 600;
    options.allowMaximize = false;
    options.showClose = true;
    window.SP.UI.ModalDialog.showModalDialog(options);

}

function GridCommentsCallBack() {
    GetRowData(CurrentGrid, CurrentRow);
}

function GetGridItemUrl(grid, row) {
    var gridid = GetGridId(grid);
    var linkType = eval("mygrid" + gridid + ".LinkType");

    if (new RegExp(/%\d[\dA-F]/g).test(location.href)) {
        var url = GetWebUrl() + "/_layouts/epmlive/gridaction.aspx?action=" + linkType + "&webid=" + row.webid + "&listid=" + row.listid + "&ID=" + row.itemid + "&Source=" + location.href;
    }
    else {
        var url = GetWebUrl() + "/_layouts/epmlive/gridaction.aspx?action=" + linkType + "&webid=" + row.webid + "&listid=" + row.listid + "&ID=" + row.itemid + "&Source=" + escape(location.href);
    }

    return url;
}

function GridGoToItem(gridid, rowid) {
    var grid = Grids[gridid];
    var row = grid.GetRowById(rowid);

    CurrentGrid = grid;
    CurrentRow = row;
    gridid = GetGridId(grid);

    // get the url for grid action
    var url = GetGridItemUrl(grid, row);

    if (eval("mygrid" + gridid + "._usepopup")) {

        var options = window.SP.UI.$create_DialogOptions();

        options.url = url;
        options.width = 700;
        options.allowMaximize = false;
        options.showClose = true;
        options.dialogReturnValueCallback = GridCommentsCallBack;
        window.SP.UI.ModalDialog.showModalDialog(options);
    }
    else
        location.href = url;
}


function GridOnMouseOverOutside(grid, row, col, event) {
    if (grid.CurHoverRow)
        grid.SetAttribute(grid.GetRowById(grid.CurHoverRow), "Title", "ButtonText", ' ', 1);
    grid.CurHoverRow = "";

}

function GridOnMouseOverRow(grid, row, col, event) {
    if (grid.CurHoverRow != row.id) {
        grid.CurHoverRow = row.id;
        CurrentGrid = grid;
        if (grid.GetValue(row, "itemid") != "") {
            grid.SetAttribute(row, "Title", "ButtonText", '<div style="position:absolute;overflow:visible;margin-right:5px" id=\"' + row.id + '\"><a data-itemid="' + grid.GetValue(row, "itemid") + '" data-listid="' + grid.GetValue(row, "listid") + '" data-webid="' + grid.GetValue(row, "webid") + '" data-siteid="' + grid.GetValue(row, "siteid") + '" ></a></div>', 1);
            CurrentGrid = grid;
            CurrentRow = row;
            window.epmLiveNavigation.addContextualMenu($('#' + row.id), [], null, null, { "delete": "GridGanttDeleteRow", "comments": "GridCommentsCallBack", "edit": "GridCommentsCallBack" });
        }
    }
}

function GridOnSelect(grid, row, deselect) {
    if (grid.id.substr(0, 9) == "GanttGrid") {
        if (row.Kind == "Data") {
            if (!row.itemid) {
                grid.SelectRange(row.firstChild, null, row.lastChild, null, !deselect, 0);
            }

        }
        setTimeout("RefreshCommandUI()", 200);
    }
}

function GridOnFocus(grid, row, col, orow, ocol, pagepos) {
    //grid.ClearSelection();
    //grid.SelectRow(row, true);

    curGrid = eval("mygrid" + grid.id.substr(9));
    //curRowId = row.id;

    //RefreshCommandUI();
    if (grid.id.substr(0, 9) == "GanttGrid") {
        if (row.Kind == "Data") {
            if (col == "Panel")
                grid.SelectRow(row);

            else if (row.itemid) {
                grid.ActionClearSelection();
                grid.SelectRow(row);
            }

            var gridid = GetGridId(grid);

            var ribbon = eval("mygrid" + gridid + ".RibbonBehavior");

            if (ribbon != "1" && ribbon != "2")
                SelectRibbonTab("Ribbon.ListItem", true);
        }
    }
    //RefreshCommandUI();
}


function GridOnDblClick(grid, row, col, x, y, event) {
    if (grid.id.substr(0, 9) == "GanttGrid") {
        EditGridRow(grid, row, col);
    }
}

function GridOnAfterValueChanged(grid, row, col, val) {
    if (grid.id.substr(0, 9) == "GanttGrid") {
        grid.EditRowChanged = true;
    }
}


function ChangePage(pg, gridid) {
    var grid = Grids["GanttGrid" + gridid];
    eval("mygrid" + gridid + ".CurPage='" + pg + "'");
    ReloadGridWithNewParams(gridid);
}


function GridSort(grid) {
    grid.ChangeSort("Title");
}

function GridHideShowSearch(grid) {
    var sdiv = document.getElementById("searchdiv" + grid.id.substr(9));
    if (sdiv.style.display == 'none')
        sdiv.style.display = '';
    else
        sdiv.style.display = 'none';

    SetGridSize(grid);
}


function GridHideShowFilter(grid) {
    var row = grid.GetRowById("Filter");
    try {
        if (row.Visible)
            grid.HideRow(row);
        else
            grid.ShowRow(row);
    } catch (e) { }
}

function GridGanttDeleteRow(liid) {
    CurrentGrid.RemoveRow(CurrentGrid.GetRowById(liid), 1);
}

function GridClickOutside(grid, row, col, x, y, event) {
    if (grid.EditRow)
        StopEditGridRow(grid, grid.GetRowById("Header"));
}

function GridClick(grid, row, col, x, y, event) {
    if (grid.EditRow)
        StopEditGridRow(grid, row);
    if (col == "Edit")
        EditGridRow(grid, row, "");

}

function NewItemCallback(dialogResult, returnValue) {
    if (dialogResult) { GridNewItem(curGrid._gridid, returnValue); }
}

function GridNewItem(gridid, newid) {
    var grid = Grids["GanttGrid" + gridid];

    var row = grid.AddRow(null, null, true, null, null);

    var listid = eval("mygrid" + gridid + "._listid");
    var webid = eval("mygrid" + gridid + "._webid");

    grid.SetValue(row, "siteid", window.epmLive.currentSiteId);
    grid.SetValue(row, "webid", webid);
    grid.SetValue(row, "listid", listid);
    grid.SetValue(row, "itemid", newid);
    grid.SetAttribute(row, "Title", "HtmlPrefix", "<img src='/_layouts/15/epmlive/images/mywork/loading16.gif'>", 1);
    grid.SetAttribute(row, "Title", "ButtonText", " ", 1);
    GetRowData(grid, row);
    grid.Reload();
}

function StopEditGridRow(grid, row) {

    if (row.id != grid.EditRow) {
        var row = grid.GetRowById(grid.EditRow);
        grid.EditRow = null;
        grid.EndEdit(true);
        if (grid.EditRowChanged) {
            grid.SetAttribute(row, "Title", "HtmlPrefix", "<img src='/_layouts/15/epmlive/images/mywork/loading16.gif'>", 1);

            var Values = "";
            var cols = "";

            for (var col in grid.Cols) {
                if (grid.GetAttribute(row, col, "CanEdit") == "1" && col != "G") {
                    Values += "<Field Name=\"" + col + "\">" + escape(grid.GetValue(row, col)) + "</Field>";
                }

                cols += "," + col;
            }

            var data = "<Row id=\"" + row.id + "\" siteid=\"" + row.siteid + "\" webid=\"" + row.webid + "\" listid=\"" + row.listid + "\" itemid=\"" + row.itemid + "\" Cols=\"" + cols + "\">" + Values + "</Row>";

            var webUrl = window.epmLiveNavigation.currentWebUrl;

            $.ajax({
                type: 'POST',
                url: (webUrl + '/_vti_bin/WorkEngine.asmx/ExecuteJSON').replace(/\/\//g, '/'),
                data: "{ Function: 'webparts_SetGridRowEdit', Dataxml: '" + data + "' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    var oResp = eval("(" + response.d + ")");
                    if (oResp.Result.Status == "0") {
                        grid.AddDataFromServer(oResp.Result.InnerText);
                    }
                    else
                        alert(oResp.Result.Error.Text);
                    grid.SetAttribute(row, "Title", "HtmlPrefix", "", 1);
                    for (var col in grid.Cols) {
                        grid.SetAttribute(row, col, "CanEdit", "0", 1);
                    }
                    grid.AcceptChanges(row);
                },
                error: function (response) {
                    alert("Error: " + response);
                    grid.SetAttribute(row, "Title", "HtmlPrefix", "", 1);
                }
            });
        }
        else {
            grid.EditRow = "";
            for (var col in grid.Cols) {
                grid.SetAttribute(row, col, "CanEdit", "0", 1);
                grid.SetAttribute(row, "Title", "HtmlPrefix", "", 1);
            }
        }
        grid.EditRowChanged = false;

    }
}

function GetRowData(grid, row) {

    if (!row.itemid) return;

    var cols = "";

    for (var col in grid.Cols) {
        cols += "," + col;
    }

    grid.SetAttribute(row, "Title", "HtmlPrefix", "<img src='/_layouts/15/epmlive/images/mywork/loading16.gif'>", 1);

    var data = "<Row id=\"" + row.id + "\" siteid=\"" + row.siteid + "\" webid=\"" + row.webid + "\" listid=\"" + row.listid + "\" itemid=\"" + row.itemid + "\" Cols=\"" + cols + "\"></Row>";

    var webUrl = window.epmLiveNavigation.currentWebUrl;

    $.ajax({
        type: 'POST',
        url: (webUrl + '/_vti_bin/WorkEngine.asmx/ExecuteJSON').replace(/\/\//g, '/'),
        data: "{ Function: 'webparts_GetGridRow', Dataxml: '" + data + "' }",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (response) {
            var oResp = eval("(" + response.d + ")");
            if (oResp.Result.Status == "0") {
                grid.AddDataFromServer(oResp.Result.InnerText);
            }
            else
                alert(oResp.Result.Error.Text);
            grid.SetAttribute(row, "Title", "HtmlPrefix", "", 1);
            for (var col in grid.Cols) {
                grid.SetAttribute(row, col, "CanEdit", "0", 1);
            }
            grid.AcceptChanges(row);
        },
        error: function (response) {
            alert("Error: " + response);
            grid.SetAttribute(row, "Title", "HtmlPrefix", "", 1);
        }
    });
}

function LoadGrid(gridid) {

    var gUrl = GetWebUrl() + "/_layouts/15/epmlive/getganttitems.aspx?data=" + eval("mygrid" + gridid + ".Params") + eval("mygrid" + gridid + ".Searcher");

    if (epmdebug)
        gUrl += "&epmdebug=true";

    EPM.UI.Loader.current().startLoading({ id: 'WebPart' + eval("mygrid" + gridid + ".Qualifier") });

    TreeGrid({ Data: { Url: gUrl }, Export: { Url: GetWebUrl() + '/_layouts/15/epmlive/getgriditemsexport.aspx' }, SuppressMessage: 3, Debug: "" }, "griddiv" + gridid);

}

function EditGridRow(grid, row, col) {



    if (row.itemid && grid.EditRow != row.id && row.id != "Header") {
        var webUrl = window.epmLiveNavigation.currentWebUrl;

        var cols = "";

        for (var c in grid.Cols)
            cols += "," + c;

        cols = cols.substr(1);

        var data = "<Row id=\"" + row.id + "\" siteid=\"" + row.siteid + "\" webid=\"" + row.webid + "\" listid=\"" + row.listid + "\" itemid=\"" + row.itemid + "\" Cols=\"" + cols + "\"/>";

        grid.SetAttribute(row, "Title", "HtmlPrefix", "<img src='/_layouts/15/epmlive/images/mywork/loading16.gif'>", 1);

        $.ajax({
            type: 'POST',
            url: (webUrl + '/_vti_bin/WorkEngine.asmx/ExecuteJSON').replace(/\/\//g, '/'),
            data: "{ Function: 'webparts_GetGridRowEdit', Dataxml: '" + data + "' }",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                var oResp = eval("(" + response.d + ")");
                if (oResp.Result.Status == "0") {
                    grid.EditRow = row.id;
                    grid.AddDataFromServer(oResp.Result.InnerText);
                    grid.SetAttribute(row, "Title", "HtmlPrefix", "<span class=\"icon-pencil\" style=\"color: #CCC;padding-right:5px\"></span>", 1);
                    grid.StartEdit();
                }
                else
                    alert(oResp.Result.Error.Text);

            },
            error: function (response) {
                alert("Error: " + response);
            }
        });


    }
}


function ChangeGroups(gridid, data) {

    var sGroups = "";

    for (var v in data) {
        sGroups += "," + data[v].value;
    }

    if (sGroups != "")
        sGroups = sGroups.substr(1);

    eval("mygrid" + gridid + ".Groups='" + sGroups + "'");
    ReloadGridWithNewParams(gridid, "FromGroupBy");
    return true;
}

function ViewAllPages(gridid) {
    if (confirm('Are you sure you want to view all items? If there are a lot of items, this process can take some time.')) {
        eval("mygrid" + gridid + ".NoPage='true'");

        var pagediv = document.getElementById("pagediv" + gridid);
        var viewalldiv = document.getElementById("viewalldiv" + gridid);

        pagediv.style.display = "none";
        viewalldiv.style.display = "none";

        ReloadGridWithNewParams(gridid);
        return true;
    }
}


function ChangeColumns(gridid, data) {
    eval("mygrid" + gridid + ".Cols='" + data['selectedKeys'] + "'");
    ReloadGridWithNewParams(gridid);
    return true;
}

function ReloadGridWithNewParams(gridid, Source) {
    EPM.UI.Loader.current().startLoading({ id: 'WebPart' + eval("mygrid" + gridid + ".Qualifier") });

    var dataurl = eval("DataUrl" + gridid);
    if (Source == "FromGroupBy") {
        Grids["GanttGrid" + gridid].Data.Data.Url = dataurl + '&FromGroupBy=1&Page=' + eval("mygrid" + gridid + ".CurPage") + "&Cols=" + eval("mygrid" + gridid + ".Cols") + "&GB=" + eval("mygrid" + gridid + ".Groups") + "&NP=" + eval("mygrid" + gridid + ".NoPage") + eval("mygrid" + gridid + ".Searcher");
    } else {
        Grids["GanttGrid" + gridid].Data.Data.Url = dataurl + '&Page=' + eval("mygrid" + gridid + ".CurPage") + "&Cols=" + eval("mygrid" + gridid + ".Cols") + "&GB=" + eval("mygrid" + gridid + ".Groups") + "&NP=" + eval("mygrid" + gridid + ".NoPage") + eval("mygrid" + gridid + ".Searcher");
    }


    Grids["GanttGrid" + gridid].Data.Export.Url = GetWebUrl() + '/_layouts/15/epmlive/getgriditemsexport.aspx';

    Grids["GanttGrid" + gridid].Reload();

}

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

        var GanttStartField = eval("mygrid" + gridid + ".GanttStart");

        var sDate = grid.GetValue(row, GanttStartField)
        if (sDate != "") {
            var date = new Date(sDate);
            grid.ScrollToDate(date, "left");
        }
    }
}

function GridOnMouseOutRow(grid, row, col, event) {
    grid.SetAttribute(row, "Title", "ButtonText", ' ', 1);
}

Grids.OnGetExportValue = function (grid, row, col, str) {
    var val = getHTML(grid, row, col, grid.GetValue(row, col));
    if (val)
        return str + val;
}

function getHTML(grid, row, col, val) {
    if (row.Kind == "Data") {
        if (col != "Title") {
            try {
                if (grid.GetValue(row, col).indexOf('<img') == 0) {
                    var colimg = grid.GetValue(row, col);
                    var splcolimg = colimg.split("/")[colimg.split("/").length - 1];
                    val = splcolimg.split('"')[0];
                }
                return val;
            } catch (e) { }
        }
    }
}