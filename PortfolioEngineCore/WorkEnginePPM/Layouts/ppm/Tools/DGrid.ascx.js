function DGrid(params) {
    // NB Constructor code at end of function
    var MakeDelegate = function (target, method) {
        if (method == null) {
            throw ("Method not found");
        }
        return function() {
            return method.apply(target, arguments);
        };
    };
    DGrid.prototype.GetXmlData = function () {
        if (this.grid != null) {
            this.grid.setSerializationLevel(true, false, true, true, false, false);
            return this.grid.serialize();
        }
        return "";
    };
    DGrid.prototype.OnLoad = function (event) {
        this.grid.setImagePath(this.params.ImagePath); //path to images required by grid
        this.grid.setSkin(this.params.Skin);
        if (jsf_isEmpty(this.params.Columns) == false || jsf_isEmpty(this.params.Data) == false)
            this.Initialize();
    };
    DGrid.prototype.Initialize = function (columns, data) {
        if (jsf_isEmpty(columns) == false)
            this.params.Columns = columns;
        if (jsf_isEmpty(data) == false)
            this.params.Data = data;
        this.columns = JSON_ConvertString(params.Columns);
        this.grid.parse(this.params.Data);
    };
    DGrid.prototype.grid = function () {
        return this.grid;
    };
    DGrid.prototype.addEventListener = function (eventName, eventFumction) {
        if (this.grid != null)
            return this.grid.attachEvent(eventName, eventFumction);
        return null;
    };
    DGrid.prototype.autoSizeColumns = function () {
        var gridcols = this.columns;
        var cols = gridcols.head.column;
        for (var c = 0; c < cols.length; c++) {
            this.grid.adjustColumnSize(c);
        }
    };
    DGrid.prototype.OnRowSelect = function (id, ind) {
        //this.RowEvent("", "onclick", id);
    };

    DGrid.prototype.GetTop = function () {
        var div = document.getElementById(params.dgrid_div);
        var xy = this.findAbsolutePosition(div);
        return xy[1];
    };

    DGrid.prototype.SetHeight = function (h) {
        var div = document.getElementById(params.grid_div);
        if (h > 0)
            div.style.height = h + "px";
        this.grid.setSizes();
    };

    DGrid.prototype.SetWidth = function (w) {
        var div = document.getElementById(params.grid_div);
        if (w > 0)
            div.style.width = w + "px";
        this.grid.setSizes();
    };
    DGrid.prototype.SetSizes = function (w, h) {
        var div = document.getElementById(params.grid_div);
        if (w > 11)
            div.style.width = (w-11) + "px";
        if (h > 5)
            div.style.height = (h-5) + "px";
        this.grid.setSizes();
    };
    DGrid.prototype.findAbsolutePosition = function (obj) {
        var curleftx = 0;
        var curtopy = 0;
        if (obj.offsetParent) {
            do {
                curleftx += obj.offsetLeft;
                curtopy += obj.offsetTop;
            } while (obj = obj.offsetParent);
        }
        return [curleftx, curtopy];
    };

    DGrid.prototype.GetCellValue = function (row, col) {
        var colid = this.GetColId(col);
        if (colid != null) {
            return this.grid.cells(row, colid).getValue();
        }
    };

    DGrid.prototype.SetCellValue = function (row, col, value) {
        var colid = this.GetColId(col);
        if (colid != null) {
            this.grid.cells(row, colid).setValue(value);
        }
    };

    DGrid.prototype.GetColId = function (col) {
        var gridcols = this.columns;
        var cols = gridcols.head.column;
        for (var c = 0; c < cols.length; c++) {
            if (cols[c].name == col)
                return c;
        }
        return null
    };

    DGrid.prototype.deleteRow = function (rowid) {
        this.grid.deleteRow(rowid);
    };

    DGrid.prototype.addRow = function (rowid) {
        this.grid.addRow(rowid, "");
    };

    DGrid.prototype.selectRow = function (rowid) {
        this.grid.selectRowById(rowid, false, true, true);
    };

    DGrid.prototype.reapplySort = function () {
        var state = this.grid.getSortingState();
        if (state.length > 0) {
            this.grid.sortRows(state[0], null , state[1]);
        }
    };

    // Initialised fields
    this.params = params;
    //this.grid = null;
    this.grid = new dhtmlXGridObject(this.params.grid_div);
    this.columns = null;
    var loadDelegate = MakeDelegate(this, this.OnLoad);
    var OnRowSelectDelegate = MakeDelegate(this, this.OnRowSelect);
    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("load", loadDelegate, true);
    }
    else { // e.g. IE
        window.attachEvent("onload", loadDelegate);
    }
}