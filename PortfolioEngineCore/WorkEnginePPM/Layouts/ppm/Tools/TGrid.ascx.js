function TGrid(params) {
    // NB Constructor code at end of function
    TGrid.prototype.MakeDelegate = function (target, method) {
        if (method == null) {
            throw ("Method not found");
        }
        return function() {
            return method.apply(target, arguments);
        };
    };

    TGrid.prototype.OnLoad = function (event) {
//        this.grid.setImagePath(this.params.ImagePath); //path to images required by grid
//        this.grid.setSkin(this.params.Skin);
        if (jsf_isEmpty(this.params.Data) == false)
            this.Initialize(this.params.Data);
    };

    TGrid.prototype.Initialize = function (data) {
        //        if (jsf_isEmpty(columns) == false)
        //            this.params.Columns = columns;
        //        if (jsf_isEmpty(data) == false)
        //            this.params.Data = data;
        //        this.columns = JSON_ConvertString(params.Columns);
        //        this.grid.parse(this.params.Data);
        //        this.grid = TreeGrid("<treegrid debug='0' sync='1' Data_Script='treegridData' ></treegrid>", "idtg2");
        //var treegridData = data;
        if (this.grid != null)
            this.grid.Dispose();
        this.grid = null;
        this.grid = TreeGrid("<treegrid debug='0' sync='1' Data_Data='" + data + "' ></treegrid>", this.params.treegrid_div, this.params.tg_id);
    };

    TGrid.prototype.addEventListener = function (eventName, eventFunction) {
        if (this.grid != null)
            SetEvent(eventName,this.params.tg_id,eventFunction);
    };
    TGrid.prototype.grid = function () {
        return this.grid;
    };
    TGrid.prototype.GetXmlData = function () {
        if (this.grid != null)
            return this.grid.GetXmlData("Data");
        return "";
    };

    TGrid.prototype.GetTop = function () {
        var div = document.getElementById(this.params.treegrid_div);
        var xy = this.findAbsolutePosition(div);
        return xy[1];
    };

    TGrid.prototype.SetWidth = function (w) {
        var div = document.getElementById(this.params.treegrid_div);
        div.style.width = w + "px";
    };

    TGrid.prototype.SetHeight = function (h) {
        var div = document.getElementById(this.params.treegrid_div);
        div.style.height = h + "px";
    };

    TGrid.prototype.findAbsolutePosition = function (obj) {
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

    TGrid.prototype.GetCellValue = function (row, col) {
        //return this.grid.GetValue(row, col);
        if (this.grid != null)
            return this.grid.GetAttribute(row, col, null);
        return null;
    };

    TGrid.prototype.SetCellValue = function (row, col, value) {
        if (this.grid != null)
            this.grid.SetValue(row, col, value, 1);
    };

    TGrid.prototype.AddRow = function () {
        if (this.grid != null)
            return this.grid.AddRow(this.grid.FRow, null, true);
        return null;
    };
    TGrid.prototype.Focus = function (row, col) {
        this.focusrow = row;
        this.focuscol = col;
        window.setTimeout(params.tg_uid + ".HandleAction('focus')", 10);
    };
    TGrid.prototype.HandleAction = function (event) {
        switch (event) {
            case 'focus':
                this.grid.Focus(this.focusrow, this.focuscol, null, true);
                break;
            default:
                break;
        }
    };
    this.grid = null;
    this.params = params;
    this.focusrow = null;
    this.focuscol = null;
    var loadDelegate = this.MakeDelegate(this, this.OnLoad);
    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("load", loadDelegate, true);
    }
    else { // e.g. IE
        window.attachEvent("onload", loadDelegate);
    }
}