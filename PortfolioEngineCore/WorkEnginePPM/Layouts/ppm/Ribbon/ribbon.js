function Ribbon(ribbonData) {
    // NB Constructor code at end of function

    Ribbon.prototype.isCollapsed = function () {
        if (this.ribbonData.collapsed == "true") {
            return true;
        }
        return false;
    }

    Ribbon.prototype.collapse = function () {
        this.ribbonData.collapsed = "true";
        var id = this.ribbonData.parent + "_ribbon";
        document.getElementById(id).style.display = "none";
        id = this.ribbonData.parent + "_ribbonimg";
        document.getElementById(id).src = "ribbon/images/expand.gif";
    }

    Ribbon.prototype.expand = function () {
        this.ribbonData.collapsed = "false";
        var id = this.ribbonData.parent + "_ribbon";
        document.getElementById(id).style.display = "block";
        id = this.ribbonData.parent + "_ribbonimg";
        document.getElementById(id).src = "ribbon/images/collapse.gif";
    }

    Ribbon.prototype.isItemDisabled = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            return item.disabled;
        }
        return true;
    }

    Ribbon.prototype.disableItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = true;
            if (document.getElementById) {
                // jwg 6/6/12  - if its a check box or select need the endable or disable the html element directly as well - though the string for the checkbox still needs work
                if (item.type == "checkbox" || item.type == "select")
                    document.getElementById(id).disabled = true;
                
                document.getElementById(id).className = item.className + "_d";
            }
        }
    }

    Ribbon.prototype.enableItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = false;
            if (document.getElementById) {
                // jwg 6/6/12  - if its a check box or select need the endable or disable the html element directly as well  - though the string for the checkbox still needs work
                if (item.type == "checkbox" || item.type == "select")
                    document.getElementById(id).disabled = false;
                
                document.getElementById(id).className = item.className;
            }
        }
    }
    
    Ribbon.prototype.hideItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = true;
            if (document.getElementById)
                document.getElementById(id).style.display = "none";

            // jwg 6/6/12  - if its a check boxnide/show the td html element directly as well 
            if (item.type == "checkbox")
                document.getElementById(id + "_chk").style.display = "none";
  
  
  
        }
    }

    Ribbon.prototype.showItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = false;
            if (document.getElementById)
                document.getElementById(id).style.display = "block";
            // jwg 6/6/12  - if its a check boxnide/show the td html element directly as well 
            if (item.type == "checkbox")
                document.getElementById(id + "_chk").style.display = "block";

        }
    }

    Ribbon.prototype.FindItemById = function (id) {
        var sections = this.ribbonData.sections;
        if (sections.length > 0) {
            for (var i = 0; i < sections.length; i++) {
                var columns = sections[i].columns;
                if (columns.length > 0) {
                    for (var j = 0; j < columns.length; j++) {
                        var items = columns[j].items;
                        if (items.length > 0) {
                            for (var k = 0; k < items.length; k++) {
                                if (items[k].id == id)
                                    return items[k];
                            }
                        }
                    }
                }
            }
        }
        return null;
    }


    Ribbon.prototype.Render = function () {
        try {

            var sb = new StringBuilder();
            var style = "";

            // JWG 3/16/12 Rob - I don't know what is the aim of this clause - but because item is not defined it causes firefox to fail to bring up the ribbon bar - so I have commented it out
            //if (item.style != null)
            //    style = "style=\"" + item.style + "\"";

            // JWG 3/16/12 Rob - Firefox does not support outerHTML - so need to use inner instead - so comment out the div defn

            //        sb.append("<div id='" + this.ribbonData.parent + "' class='" + this.ribbonclass + "_row' " + style + ">");
            // add sections
            var onclick = "";
            if (this.ribbonData.showstate == "true") {
                if (this.ribbonData.onstatechange != null)
                    onclick = " onclick=\"" + this.ribbonData.onstatechange + "\"";

                sb.append("<div id='" + this.ribbonData.parent + "_ribbondiv' style='float:right;display:block;' >");
                if (this.ribbonData.initialstate == "collapsed") {
                    this.ribbonData.collapsed = "true";
                    sb.append("<img id='" + this.ribbonData.parent + "_ribbonimg'" + onclick + " src=\"ribbon/images/expand.gif\" alt=''/>");
                } else {
                    this.ribbonData.collapsed = "false";
                    sb.append("<img id='" + this.ribbonData.parent + "_ribbonimg'" + onclick + " src=\"ribbon/images/collapse.gif\" alt=''/>");
                }
                sb.append("</div>");
            }

            var sections = this.ribbonData.sections;
            if (sections.length > 0) {
                sb.append("<table id='" + this.ribbonData.parent + "_ribbon' class='" + this.ribbonclass + "_row' ><tr>");
                for (var i = 0; i < sections.length; i++) {
                    sb.append(this.BuildSectionHtml(sections[i]));
                }
                sb.append("</tr></table>");
            }
            // JWG 3/16/12 Rob - Firefox does not support outerHTML - so need to use inner instead - so comment out the div close
            //         sb.append("</div>");


            var s = sb.toString();


            var div = document.getElementById(this.ribbonData.parent);
            div.className = this.ribbonclass + "_row";

            //        div.outerHTML = s;
            // JWG 3/16/12 Rob - Firefox does not support outerHTML - so need to use inner instead - 
            div.innerHTML = s;

        }
        catch (e) {
            alert("rb Render: " + e.toString());
        }
    }

 
    Ribbon.prototype.BuildSectionHtml = function (section) {
        var s = "";
        try {
            var onclick = "";
            if (section.onclick != null)
                onclick = " onclick=\"" + section.onclick + "\"";
            var sb = new StringBuilder();
            var columns = section.columns;
            if (columns.length > 0) {
                sb.append("<td><table class='" + this.ribbonclass + "_section'>");
                if (section.name !== undefined) {
                    sb.append("<tr style='display:none;' class='foot'><td class='foot' " + onclick + " colspan='" + columns.length.toString() + "'>" + section.name + "</td></tr>");
                }
                sb.append("<tr class='body'>");
                for (var i = 0; i < columns.length; i++) {
                    sb.append(this.BuildColumnHtml(columns[i]));
                }
                sb.append("</tr>");
                if (section.name !== undefined) {
                    sb.append("<tr class='foot'><td class='foot' " + onclick + " colspan='" + columns.length.toString() + "'>" + section.name + "</td></tr>");
                }
                sb.append("</table></td>");
            }
            s = sb.toString();
        }
        catch (e) {
            //this.HandleException("Render", e);
        }
        return s;
    }

    Ribbon.prototype.BuildColumnHtml = function (column) {
        var s = "";
        try {
            var sb = new StringBuilder();
            var items = column.items;
            if (items.length > 0) {
                sb.append("<td><table class='" + this.ribbonclass + "_column'>");
                for (var i = 0; i < items.length; i++) {
                    sb.append(this.BuildItemHtml(items[i]));
                }
                sb.append("</table></td>");
            }
            s = sb.toString();
        }
        catch (e) {
            //this.HandleException("Render", e);
        }
        return s;
    }

    Ribbon.prototype.BuildItemHtml = function (item) {
        var s = "";
        try {
            var sb = new StringBuilder();
            var id = "";
            if (item.id != null) 
                id = " id=\"" + item.id + "\"";
            var idFrame = "";
            if (item.id != null)
                idFrame = " id=\"" + item.id + "_frame\"";
            var onchange = "";
            if (item.onchange != null)
                onchange = " onchange=\"" + item.onchange + "\"";
            var onclick = "";
            if (item.onclick != null)
                onclick = " onclick=\"" + item.onclick + "\"";
            var tooltip = "";
            if (item.tooltip != null)
                tooltip = " tooltip=\"" + item.tooltip + "\"";
            var disabled = "";
            if (item.disabled != null && item.disabled == true)
                disabled = "_d";
            var itemname = "";
            if (item.name != null)
                itemname = item.name.replace(/ /g, "&nbsp;");
            var sOptions = "";
            if (item.options != null)
                sOptions = item.options;

            var accessKey = "";
            var alt = "";
            switch (item.type) {
                case "bigbutton":
                    item.className = "bigbutton";
                    sb.append("<tr><td class='bigbutton" + disabled + "'" + id + onclick + ">");
                    sb.append("<div><img src=\"" + this.ribbonData.imagePath + item.img + "\" alt=''/></div>");
                    sb.append("<div><a tabindex='0' title='" + item.tooltip + "'>" + item.name + "</a></div>");
                    sb.append("</td></tr>");
                    break;
                case "smallbutton":
                    item.className = "smallbutton";
                    sb.append("<tr class='short'><td nowrap='nowrap' class='smallbutton" + disabled + "'" + id + " " + onclick + ">");
                    sb.append("<img src=\"" + this.ribbonData.imagePath + item.img + "\" alt=''/>");
                    sb.append("<a tabindex='0' title='" + item.tooltip + "'>&nbsp;" + itemname + "</a>");
                    sb.append("</td></tr>");
                    break;
                case "text":
                    sb.append("<tr class='short'><td nowrap='nowrap' style='margin-left:5px;'>" + itemname + "</td></tr>");
                    break;
                case "select":
                    item.className = "smallbutton";
                    sb.append("<tr class='short'><td nowrap='nowrap' class='smallbutton" + disabled + "'><select class='select' " + id + " " + onchange + ">" + sOptions + "</select>");
                    sb.append("</td></tr>");
                    break;
                case "checkbox":
                    item.className = "smallbutton";
                    sb.append("<tr class='short'><td id='" + item.id + "_chk' nowrap='nowrap' class='smallbutton" + disabled + "'>");
                    sb.append("<input class='cb' type='checkbox' " + id + " " + sOptions + " " + onclick + "/>" + itemname);
                    sb.append("</td></tr>");
                    break;
                default:
                    break;
            }
            s = sb.toString();
        }
        catch (e) {
            alert("ribbon.js : " + e.Message);
        }
        return s;
    }

    try
    {
        this.ribbonData = ribbonData;
        this.ribbonclass = "epm_ribbon";
        if (this.ribbonData.ribbonclass != null && this.ribbonData.ribbonclass != "")
            this.ribbonclass = this.ribbonData.ribbonclass;
    }
    catch (e) {
        alert("Ribbon Initialization error");
    }
}


    