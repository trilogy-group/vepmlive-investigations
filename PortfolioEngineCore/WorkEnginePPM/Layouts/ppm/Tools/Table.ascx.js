function Table(thisID, clientID) {
    // NB Constructor code at end of function
    var MakeDelegate = function (target, method) {
        if (method == null) {
            throw ("Method not found");
        }

        return function() {
            return method.apply(target, arguments);
        };
    };

    Table.prototype.OnLoad = function(event) {
        $addHandler(document, 'keydown', keyDownDelegate);
    };

    Table.prototype.OnKeyDown = function(e) {
        //alert(e.keyCode.toString());

        //        var lRow = this.GetSelectedRowIndex();
        //        var sRow = "";

        //        switch (e.keyCode) {
        //            case 27: // esc
        //                //ClearSelectedRow();
        //                break;
        //            case 38:    // uparrow
        //                if (lRow > 1)
        //                    sRow = (lRow - 1).toString();
        //                this.RowEvent("", "onclick", sRow);
        //                break;
        //            case 40:    // downarrow
        //                sRow = (lRow + 1).toString();
        //                this.RowEvent("", "onclick", sRow);
        //                break;
        //        }
    };


    Table.prototype.GetSelectedRowIndex = function() {
        var index = -1;
        if (this.nodeSelectedRow != null) {
            for (var i = 0; i < this.nodeSelectedRow.parentNode.childNodes.length; i++) {
                if (this.nodeSelectedRow.parentNode.childNodes[i] == this.nodeSelectedRow) {
                    index = i;
                    break;
                }
            }
        }
        return index;
    };

    Table.prototype.GetSelectedRowId = function() {
        if (this.nodeSelectedRow != null)
            return this.nodeSelectedRow.id.replace("r_", "");
        return "";
    };

    Table.prototype.RowEvent = function(sControlId, sEvent, sRowUId) {
        if (!document.getElementById)
            return;
        var sRowId = "r_" + sRowUId;
        var thisRow = document.getElementById(sRowId);
        if (thisRow != null) {
            switch (sEvent) {
            case "onclick":
                this.SetRowTDClass(this.nodeSelectedRow, "cellDefault", "");
                this.nodeSelectedRow = null;
                this.SetRowTDClass(thisRow, "cellDefault", "_selected");
                this.nodeSelectedRow = thisRow;
                break;
            case "onmouseover":
                if (this.nodeSelectedRow == thisRow)
                    break;
                this.SetRowTDClass(thisRow, "cellDefault", "_over");
                break;
            case "onmouseout":
                if (this.nodeSelectedRow == thisRow)
                    break;
                this.SetRowTDClass(thisRow, "cellDefault", "");
                break;
            default:
                alert("Unhandled TableRow Event : " + sEvent);
                break;
            }
        }
    };

    Table.prototype.SetRowTDClass = function(row, classroot, classext) {
        if (row != null && row.hasChildNodes()) {
            var nodes = row.getElementsByTagName("td");
            for (var i = 0; i < nodes.length; i++) {
                var sClass = nodes[i].getAttribute("class");
                if (sClass != null && sClass != "") {
                    var s = sClass.split("_");
                    //nodes[i].setAttribute("class", s[0] + classext);
                    nodes[i].className = s[0] + classext;
                } else {
                    //nodes[i].setAttribute("class", classroot + classext);
                    nodes[i].className = classroot + classext;
                }
            }
        }
    };

    Table.prototype.OnMouseOut = function(sID, sClassName) {
        //document.all(sID).className = sClassName;
        if (document.getElementById)
            document.getElementById(sID).firstChild.className = sClassName;
    };

    // Initialised fields
    this.thisID = thisID;
    this.clientID = clientID; // Text ID of the parent control
    this.nodeSelectedRow = null;

    var keyDownDelegate = MakeDelegate(this, this.OnKeyDown);
    //var mouseOutDelegate = MakeDelegate(this, this.OnMouseOut);
    var loadDelegate = MakeDelegate(this, this.OnLoad);

    if (document.addEventListener != null) { // e.g. Firefox
        window.addEventListener("load", loadDelegate, true);
    }
    else { // e.g. IE
        window.attachEvent("onload", loadDelegate);
    }
}