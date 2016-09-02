function Toolbar(toolbarData) {
    Toolbar.prototype.gettoolbarDiv = function () {
        return this.toolbarData.parent + "_toolbar";
    };
    Toolbar.prototype.isItemDisabled = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            return item.disabled;
        }
        return true;
    };
    Toolbar.prototype.disableItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = true;
            if (document.getElementById) {
                document.getElementById(id).className = item.className + " toolbar-button-disabled";
            }
        }
    };
    Toolbar.prototype.enable = function () {
        var items = this.toolbarData.items;
        if (items.length > 0) {
            for (var k = 0; k < items.length; k++) {
                document.getElementById(items[k].id).disabled = false;
            }
        }
    };
    Toolbar.prototype.disable = function () {
        var items = this.toolbarData.items;
        if (items.length > 0) {
            for (var k = 0; k < items.length; k++) {
                document.getElementById(items[k].id).disabled = true;
            }
        }
    };
    Toolbar.prototype.enableItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = false;
            if (document.getElementById) {
                document.getElementById(id).className = item.className;
            }
        }
    };
    Toolbar.prototype.hideItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = true;
            if (document.getElementById)
                document.getElementById(id).style.display = "none";
        }
    };
    Toolbar.prototype.showItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = false;
            if (document.getElementById)
                document.getElementById(id).style.display = "block";

        }
    };
    Toolbar.prototype.FindItemById = function (id) {
        var items = this.toolbarData.items;
        if (items.length > 0) {
            for (var k = 0; k < items.length; k++) {
                if (items[k].id == id)
                    return items[k];
            }
        }
        return null;
    };
    Toolbar.prototype.Render = function () {
        try {
            var sb = new StringBuilder();
            var onclick = "";
            this.toolbarData.collapsed = "false";
            sb.append("<div id='" + this.toolbarData.parent + "_toolbar'  class='toolbar-table-div'>");
            sb.append("<table id='" + this.toolbarData.parent + "_toolbar_table'  class='toolbar-table' cellpadding='0' cellspacing='0'><tbody><tr>");
            // NB tabindex required for firefox focus
            var tabindex;
            if (document.all) tabindex = ""; else tabindex = " tabindex='1' ";
            var items = this.toolbarData.items;
            if (items.length > 0) {
                for (var i = 0; i < items.length; i++) {
                    sb.append(this.BuildItemHtml(items[i], i));
                }
            }
            sb.append("<td class='toolbar-item-td' nowrap='true' style='width:100%;'>&nbsp;</td>");
            sb.append("</tr></tbody></table>");
            sb.append("</div>");

            var s = sb.toString();
            var div = document.getElementById(this.toolbarData.parent);
            div.innerHTML = s;
        }
        catch (e) {
            Ribbon_HandleException("Render", e);
        }
    };
    Toolbar.prototype.BuildItemHtml = function (item, index) {
        var s = "";
        try {
            var sb = new StringBuilder();
            if (item.id == null || item.id == "")
                item.id = this.toolbarData.parent + "_" + index.toString();
            var id = " id=\"" + item.id + "\"";
            var onclick = "";
            if (item.onclick != null)
                onclick = " onclick=\"" + item.onclick + "\"";
            var itemname = "";
            if (item.name != null)
                itemname = item.name.replace(/ /g, "&nbsp;");
            var itemtooltip = "";
            if (item.tooltip != null)
                itemtooltip = item.tooltip.replace(/ /g, "&nbsp;");
            else
                itemtooltip = itemname;
            var classdisabled = "";
            if (item.disabled == true)
                classdisabled = " toolbar-button-disabled";
            var classname;

            var width = "";
            if (item.width != null)
                width = "min-width:" + item.width + "; ";
            var style = "";
            if (item.style != null)
                style = item.style;
            var itemstyle = "";
//            if (style != "" || width != "")
//                itemstyle = " style='" + width + style + "' ";
            if (style != "")
                itemstyle = " style='" + style + "' ";

            switch (item.type) {
                case "button":
                    item.className = "toolbar-button";
                    classname = item.className + classdisabled;
                    sb.append("<td class='toolbar-item-td' >");
                    sb.append("<a class='toolbar-button-link' >");
                    sb.append("<div" + id + " type='button' title='" + itemtooltip + "' class='" + classname + "' " + onclick + ">");
                    //sb.append("<span>");
                    sb.append("<span class='toolbar-button-image-span'>");
                    sb.append("<img alt='' src='" + this.toolbarData.imagePath + item.img + "' " + itemstyle + "/>");
                    sb.append("</span>");
                    //sb.append("</span>");
                    //sb.append("<span class='ms-cui-ctl-mediumlabel'>" + itemname + "</span>");

//                    sb.append("<img style='vertical-align: middle;' class='toolbar-button-image' alt='" + itemname + "' src='" + this.toolbarData.imagePath + item.img + "'/>");
                    sb.append("<span class='toolbar-button-image-span-2' >" + itemname + "</span>");

                    sb.append("</div>");
                    sb.append("</a>");
                    sb.append("</td>");
                    break;

                default:
                    break;
            }
            s = sb.toString();
        }
        catch (e) {
            this.HandleException("BuildItemHtml", e);
        }
        return s;
    };
    Toolbar.prototype.HandleException = function (name, e) {
        alert("Exception thrown in function " + name + "\n\n" + e.toString());
    };
    try {
        this.toolbarData = toolbarData;
    }
    catch (e) {
        this.HandleException("toolbar Initialization", e);
    }
}


    
