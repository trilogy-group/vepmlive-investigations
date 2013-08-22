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
        //Grids.OnValueChanged = GridsOnValueChangedDelegate;
        var s = document.getElementById(this.params.DataTag).value;
        if (jsf_isEmpty(s) == false)
            this.Initialize(null);
    };
    TGrid.prototype.GridsOnValueChanged = function (grid, row, col, val) {
        var snewVal = val;
        var def = grid.GetAttribute(null, col, "Defaults");
        var valueField = grid.GetAttribute(null, col, "ValueField");
        if (def != null && def != "" && valueField != null && val != null && val != "") {
            var list = JSON_ConvertString(def);
            if (list != null && list.Items != null) {
                var items = list.Items;
                var s = "";
                var vals = val.toString().split(';');
                for (var j = 0; j < vals.length; j++) {
                    var jval = vals[j];
                    for (var i = 0; i < items.length; i++) {
                        if (items[i].Value == jval) {
                            if (s != "")
                                s += ";";
                            s += items[i].Text;
                            break;
                        }
                    }
                }
                snewVal = s;
                grid.SetAttribute(row, null, valueField, val, 0, 0);
            }
        }
        return snewVal;
    };
    TGrid.prototype.GetNamePrefix = function (name) {
        // ids in form of g_1
        var s = name.split("_");
        return s[0];
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
        if (data != null)
            document.getElementById(this.params.DataTag).value = data;
        if (this.grid != null)
            this.grid.Dispose();
        this.grid = null;
        this.grid = TreeGrid("<treegrid debug='0' sync='1' Data_Tag='" + this.params.DataTag + "' ></treegrid>", this.params.treegrid_div, this.params.tg_id);
        SetEvent("OnValueChanged", this.params.tg_id, this.GridsOnValueChanged);
    };

    TGrid.prototype.addEventListener = function (eventName, eventFunction) {
        if (this.grid != null)
            SetEvent(eventName,this.params.tg_id,eventFunction);
    };
    TGrid.prototype.grid = function () {
        return this.grid;
    };
    TGrid.prototype.EndEdit = function () {
        if (this.grid != null) {
            this.grid.EndEdit(true);
            this.grid.CloseDialog();
        }
    }
    TGrid.prototype.GetXmlData = function () {
        this.EndEdit();
        if (this.grid != null) {
            return this.grid.GetXmlData("Data");
        }
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
    TGrid.prototype.SetSizes = function (w, h) {
        var div = document.getElementById(this.params.treegrid_div);
        if (w > 11)
            div.style.width = (w - 11) + "px";
        if (h > 5)
            div.style.height = (h - 5) + "px";
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
    var GridsOnValueChangedDelegate = MakeDelegate(this, this.GridsOnValueChanged);
    var loadDelegate = this.MakeDelegate(this, this.OnLoad);
    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("load", loadDelegate, true);
    }
    else { // e.g. IE
        window.attachEvent("onload", loadDelegate);
    }
}