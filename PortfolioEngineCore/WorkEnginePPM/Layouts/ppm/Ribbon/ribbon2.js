function Ribbon(ribbonData) {
    // NB Constructor code at end of function


    Ribbon.prototype.getRibbonDiv = function () {
        return this.ribbonData.parent + "_ribbon";
    };
    Ribbon.prototype.isCollapsed = function () {
        if (this.ribbonData.collapsed == "true") {
            return true;
        }
        return false;
    };
    Ribbon.prototype.refreshSelect = function (id) {
        //window.setTimeout('Ribbon_set_select("' + id + '")', 100);
        Ribbon_set_select(id);
    };
    Ribbon.prototype.selectByValue = function (id, itemValue) {
        var select = document.getElementById(id);
        if (select != null) {
            for (var i = 0; i < select.options.length; i++) {
                if (select.options[i].value == itemValue) {
                    select.selectedIndex = i;
                    break;
                }
            }
            Ribbon_set_select(id);
        }
    };
    Ribbon.prototype.collapse = function () {
        this.ribbonData.collapsed = "true";
        var id = this.ribbonData.parent + "_ul";
        document.getElementById(id).style.display = "none";
        id = this.ribbonData.parent + "_ulCollapsed";
        document.getElementById(id).style.display = "block";
    };
    Ribbon.prototype.expand = function () {
        this.ribbonData.collapsed = "false";
        var id = this.ribbonData.parent + "_ulCollapsed";
        document.getElementById(id).style.display = "none";
        id = this.ribbonData.parent + "_ul";
        document.getElementById(id).style.display = "block";
    };
    Ribbon.prototype.isItemDisabled = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            return item.disabled;
        }
        return true;
    };
    Ribbon.prototype.disableItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = true;
            if (document.getElementById) {
                if (item.type == "checkbox" || item.type == "select")
                    document.getElementById(id).disabled = true;

                document.getElementById(id).className = item.className + " ms-cui-disabled";
            }
        }
    };
    Ribbon.prototype.enableItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = false;
            if (document.getElementById) {
                if (item.type == "checkbox" || item.type == "select")
                    document.getElementById(id).disabled = false;

                document.getElementById(id).className = item.className;
            }
        }
    };
    Ribbon.prototype.getButtonState = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            if (item.stateOn == null) item.stateOn = false;
            return item.stateOn;
        }
        return false;
    };
    Ribbon.prototype.setButtonStateOn = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.stateOn = true;
            if (document.getElementById) {
                document.getElementById(id).className = item.className + " ms-cui-ctl-on";
            }
        }
    };
    Ribbon.prototype.setButtonStateOff = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.stateOn = false;
            if (document.getElementById) {
                document.getElementById(id).className = item.className;
            }
        }
    };
    Ribbon.prototype.hideItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = true;
            if (document.getElementById)
                document.getElementById(id).style.display = "none";
        }
    };
    Ribbon.prototype.showItem = function (id) {
        var item = this.FindItemById(id);
        if (item != null) {
            item.disabled = false;
            if (document.getElementById)
                document.getElementById(id).style.display = "block";

        }
    };
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
    };
    Ribbon.prototype.Render = function () {
        try {
            var sb = new StringBuilder();
            var onclick = "";
            //            if (this.ribbonData.showstate == "true") {
            //                if (this.ribbonData.onstatechange != null)
            //                    onclick = " onclick=\"" + this.ribbonData.onstatechange + "\"";

            //                sb.append("<div id='" + this.ribbonData.parent + "_ribbondiv' style='float:right;display:block;' >");
            //                if (this.ribbonData.initialstate == "collapsed") {
            //                    this.ribbonData.collapsed = "true";
            //                    sb.append("<img id='" + this.ribbonData.parent + "_ribbonimg'" + onclick + " src=\"ribbon/images/expand.gif\" alt=''/>");
            //                } else {
            //                    this.ribbonData.collapsed = "false";
            //                    sb.append("<img id='" + this.ribbonData.parent + "_ribbonimg'" + onclick + " src=\"ribbon/images/collapse.gif\" alt=''/>");
            //                }
            //                sb.append("</div>");
            //            }
            this.ribbonData.collapsed = "false";
            sb.append("<div id='" + this.ribbonData.parent + "_ribbon'  class='ms-cui-tabContainer ms-cui-tabContainer-lb'>");
            var sections = this.ribbonData.sections;
            if (sections.length > 0) {
                if (this.ribbonData.miniribbon == "true")
                    sb.append("<ul id='" + this.ribbonData.parent + "_ul'  class='ms-cui-tabBodyLower ms-cui-tabBody-lb'>");
                else
                    sb.append("<ul id='" + this.ribbonData.parent + "_ul'  class='ms-cui-tabBody ms-cui-tabBody-lb'>");
                for (var i = 0; i < sections.length; i++) {
                    sb.append(this.BuildSectionHtml(sections[i]));
                }
                if (this.ribbonData.showstate != "false") {
                    sb.append("<span style='float:right;height:20px;'>");
                    if (this.ribbonData.onstatechange != null)
                        onclick = " onclick=\"" + this.ribbonData.onstatechange + "\"";
                    sb.append("<img alt='' src='ribbon/images/collapse.png' " + onclick + "/>");
                    sb.append("</span>");
                    sb.append("</ul>");
                    if (this.ribbonData.miniribbon == "true")
                        sb.append("<ul id='" + this.ribbonData.parent + "_ulCollapsed'  class='ms-cui-tabBodyLower ms-cui-tabBody-lb' style='display:none'>");
                    else
                        sb.append("<ul id='" + this.ribbonData.parent + "_ulCollapsed'  class='ms-cui-tabBody ms-cui-tabBody-lb' style='display:none'>");
                    sb.append("<span style='float:right;height:20px;'>");
                    sb.append("<img alt='' src='ribbon/images/expand.png' " + onclick + "/>");
                    sb.append("</span>");
                }
            }

            sb.append("</div>");

            sb.append("<div id='" + this.ribbonData.parent + "_popups'>");

            // NB tabindex required for firefox focus
            var tabindex;
            if (document.all) tabindex = ""; else tabindex = " tabindex='1' ";
            sections = this.ribbonData.sections;
            if (sections.length > 0) {
                for (var i = 0; i < sections.length; i++) {
                    var columns = sections[i].columns;
                    if (columns.length > 0) {
                        for (var j = 0; j < columns.length; j++) {
                            var items = columns[j].items;
                            if (items.length > 0) {
                                for (var k = 0; k < items.length; k++) {
                                    if (items[k].type == "select") {
                                        sb.append("<div id='" + items[k].id + "_popup'" + tabindex + "style='display:none;'></div>");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            sb.append("</div>");

            var s = sb.toString();
            var div = document.getElementById(this.ribbonData.parent);
            div.innerHTML = s;
        }
        catch (e) {
            Ribbon_HandleException("Render", e);
        }
    };
    Ribbon.prototype.BuildSectionHtml = function (section) {
        var s = "";
        try {
            var sb = new StringBuilder();
            if (this.ribbonData.miniribbon == "true") {
                sb.append("<li class='ms-cui-groupLower'>");
                sb.append("<span class='ms-cui-groupContainerLower'>");
                sb.append("<span class='ms-cui-groupBodyLower'>");
            } else {
                sb.append("<li class='ms-cui-group'>");
                sb.append("<span class='ms-cui-groupContainer'>");
                sb.append("<span class='ms-cui-groupBody'>");
            }
            sb.append("<span class='ms-cui-layout'>");
            var columns = section.columns;
            if (columns.length > 0) {

                for (var i = 0; i < columns.length; i++) {
                    sb.append(this.BuildColumnHtml(columns[i]));
                }
            }

            var tooltip = "";
            if (section.tooltip != null) tooltip = section.tooltip;


            sb.append("</span>");
            sb.append("</span>");
            sb.append("<span class='ms-cui-groupTitle' title='" + tooltip + "'>" + section.name + "</span>");
            sb.append("</span>");

            if (this.ribbonData.miniribbon == "true") {
                sb.append("<span class='ms-cui-groupSeparatorLower'></span>");
            } else {
                sb.append("<span class='ms-cui-groupSeparator'></span>");
            }
            sb.append("</li>");
            s = sb.toString();
        }
        catch (e) {
            Ribbon_HandleException("BuildSectionHtml", e);
        }
        return s;
    };
    Ribbon.prototype.BuildColumnHtml = function (column) {
        var s = "";
        try {
            var sb = new StringBuilder();
            sb.append("<span class='ms-cui-section'>");
            var items = column.items;
            if (items.length > 0) {
                for (var i = 0; i < items.length; i++) {
                    sb.append(this.BuildItemHtml(items[i]));
                }
            }
            sb.append("</span>");
            s = sb.toString();
        }
        catch (e) {
            Ribbon_HandleException("BuildColumnHtml", e);
        }
        return s;
    };
    Ribbon.prototype.BuildItemHtml = function (item) {
        var s = "";
        try {
            var sb = new StringBuilder();
            var id = "";
            if (item.id != null)
                id = " id=\"" + item.id + "\"";
            var onclick = "";
            if (item.onclick != null)
                onclick = " onclick=\"" + item.onclick + "\"";
//            var tooltip = "";
//            if (item.tooltip != null)
//                tooltip = " tooltip=\"" + item.tooltip + "\"";
            var itemname = "";
            if (item.name != null)
                itemname = item.name.replace(/ /g, "&nbsp;");
            var classdisabled = "";
            if (item.disabled == true)
                classdisabled = " ms-cui-disabled";
            var classname;

            var itemstyle = "";
            if (item.style != null)
                itemstyle = " style='" + item.style + "' ";
           

            switch (item.type) {
                case "bigbutton":
                    item.className = "ms-cui-ctl-large";
                    classname = item.className + classdisabled;
                    sb.append("<span class='ms-cui-row-onerow'>");
                    sb.append("<a" + id + " class='" + classname + "' " + onclick + ">");
                    sb.append("<span class='ms-cui-ctl-largeIconContainer' >");
                    sb.append("<span class='ms-cui-img-32by32 ms-cui-img-cont-float'>");
                    sb.append("<img alt='' src='" + this.ribbonData.imagePath + item.img + "' " + itemstyle + "/>");
                    sb.append("</span>");
                    sb.append("</span>");
                    sb.append("<span class='ms-cui-ctl-largelabel'>" + itemname + "</span>");
                    sb.append("</a>");
                    sb.append("</span>");
                    break;
                case "mediumbutton":
                    item.className = "ms-cui-ctl-lowerlarge";
                    classname = item.className + classdisabled;
                    sb.append("<span class='ms-cui-row-onerow'>");
                    sb.append("<a" + id + " class='" + classname + "' " + onclick + ">");
                    sb.append("<span class='ms-cui-ctl-MediumIconContainer' >");
                    sb.append("<span class='ms-cui-img-20by20 ms-cui-img-cont-float'>");
                    sb.append("<img alt='' src='" + this.ribbonData.imagePath + item.img + "' " + itemstyle + "/>");
                    sb.append("</span>");
                    sb.append("</span>");
                    sb.append("<span class='ms-cui-ctl-lowerlargelabel'>" + itemname + "</span>");
                    sb.append("</a>");
                    sb.append("</span>");
                    break;
                case "smallbutton":
                    item.className = "ms-cui-ctl-medium";
                    classname = item.className + classdisabled;
                    sb.append("<span class='ms-cui-row'>");
                    sb.append("<a" + id + " class='" + classname + "' " + onclick + ">");
                    sb.append("<span class='ms-cui-ctl-iconContainer' >");
                    sb.append("<span class='ms-cui-img-16by16 ms-cui-img-cont-float'>");
                    sb.append("<img alt='' src='" + this.ribbonData.imagePath + item.img + "' " + itemstyle + "/>");
                    sb.append("</span>");
                    sb.append("</span>");
                    sb.append("<span class='ms-cui-ctl-mediumlabel'>" + itemname + "</span>");
                    sb.append("</a>");
                    sb.append("</span>");
                    break;
                case "mediumtext":
                    item.className = "ms-cui-ctl-medium";
                    classname = item.className + classdisabled;
                    sb.append("<span class='ms-cui-row'>");
                    sb.append("<a" + id + " class='" + classname + "' " + onclick + ">");
                    sb.append("<span class='ms-cui-ctl-mediumlabel'>" + itemname + "</span>");
                    sb.append("</a>");
                    sb.append("</span>");
                    break;
                case "text":
                    item.className = "ms-cui-ctl-small";
                    sb.append("<span class='ms-cui-row'>");
                    sb.append("<span " + id + " class='ms-cui-ctl-small ms-cui-fslb ms-cui-disabled' " + onclick + ">");
                    sb.append("<span class='ms-cui-ctl-mediumlabel'>" + itemname + "</span>");
                    sb.append("</span>");
                    sb.append("</span>");
                    break;
                case "select":
                    var sWidth = "";
                    if (item.width != null)
                        sWidth = "width: " + item.width + ";";
                    var sStyle = "";
                    if (sWidth != "")
                        sStyle = " style='" + sWidth + "'";
                    var sOptions = "";
                    if (item.options != null)
                        sOptions = item.options;
                    var onchange = "";
                    if (item.onchange != null)
                        onchange = " onchange=\"" + item.onchange + "\"";
                    var aid = "";
                    if (item.id != null)
                        aid = " id=\"" + item.id + "_textbox\"";
                    var bid = "";
                    if (item.id != null)
                        bid = " id=\"" + item.id + "_button\"";
                    item.className = "ms-cui-dd-text";
                    sb.append("<div style='display:none;'>");
                    sb.append("<select " + id + " " + onchange + ">" + sOptions + "</select>");
                    sb.append("</div>");
                    sb.append("<span class='ms-cui-row'>");
                    sb.append("<span" + bid + " class='ms-cui-dd-text'" + sStyle + " onclick='Ribbon_showPopup(\"" + item.id + "_popup\",\"" + item.id + "\",\"" + this.ribbonData.parent + "\");'>");
                    sb.append("<a" + aid + "></a>");
                    sb.append("</span>");
                    sb.append("<a class='ms-cui-dd-arrow-button' onclick='Ribbon_showPopup(\"" + item.id + "_popup\",\"" + item.id + "\",\"" + this.ribbonData.parent + "\");'>");
                    sb.append("<span class='ms-cui-img-5by3 ms-cui-img-cont-float'>");
                    sb.append("<img alt='' src='./images/formatmap16x16.png' style='top: -24px; left: -48px;position:relative;z-index:5;' />");
                    sb.append("</span>");
                    sb.append("</a>");
                    sb.append("</span>");
                    window.setTimeout('Ribbon_set_select("' + item.id + '")', 100);
                    break;
                case "checkbox":
                    item.className = "ms-cui-ctl-medium";
                    sb.append("<span class='ms-cui-row'>");
                    //sb.append("<input type='checkbox' " + id + " " + sOptions + " " + onclick + "/>" + itemname);
                    sb.append("<input type='checkbox' " + id + " " + onclick + "/>" + itemname);
                    sb.append("</span>");
                    break;

                default:
                    break;
            }
            s = sb.toString();
        }
        catch (e) {
            Ribbon_HandleException("BuildItemHtml", e);
        }
        return s;
    };
    Ribbon_showPopup = function (idPopup, idSelect, idParent) {
        var popup = document.getElementById(idPopup);
        var tbselect = document.getElementById(idSelect + "_textbox");
        var parent = document.getElementById(idParent);
        var offsetParent = parent.offsetParent;
        var xy = Ribbon_findAbsolutePosition(tbselect, parent);
        if (popup.style.display == "block") {
            if (popup.style.top == (xy[1] + 17).toString() + "px" && popup.style.left == (xy[0] - 8).toString() + "px") {
                popup.style.display = "none";
                return;
            }
        }
        var maxheight = 75;
        if (offsetParent != null) {
            var l = offsetParent.offsetHeight - xy[1] - 50;
            if (l > maxheight)
                maxheight = l;
        }
        var vid = "";
        if (idSelect != null)
            vid = " id=\"" + idSelect + "_view\"";
        var vinternalid = "";
        if (idSelect != null)
            vinternalid = " id=\"" + idSelect + "_viewinternal\"";
        var sb = new StringBuilder();
        sb.append("<div class='ms-cui-smenu-inner'>");
        sb.append("<div class=''>");
        sb.append("<div class='ms-cui-menusection'>");
        //sb.append("<div class='ms-cui-menusection-title'>Current View</div>");
        sb.append("<ul class='ms-cui-menusection-items'>");
        sb.append("<li " + vinternalid + " class='ms-cui-menusection-items'>");
        var select = document.getElementById(idSelect);
        for (var i = 0; i < select.options.length; i++) {
            var oItem = select.options[i];
            sb.append("<a onclick='Ribbon_selectItem_click(\"" + idPopup + "\",\"" + idSelect + "\",\"" + i.toString() + "\");' class=\"ms-cui-ctl-menu\" title='" + oItem.text + "'\">");
            sb.append("<span class='ms-cui-ctl-iconContainer'>");
            sb.append("<span class='ms-cui-img-16by16 ms-cui-img-cont-float'></span>");
            sb.append("</span>");
            sb.append("<span class='ms-cui-ctl-mediumlabel'>" + oItem.text + "</span>");
            sb.append("<span class='ms-cui-glass-ff'></span>");
            sb.append("</a>");
        }
        sb.append("</li>");
        sb.append("</ul>");
        sb.append("</div>");
        sb.append("</div>");
        var s = sb.toString();
        popup.className = "ms-cui-menu";
        popup.style.cssText = "direction: ltr; visibility: visible; position: absolute; top: " + (xy[1] + 17).toString() + "px; left: " + (xy[0] - 8).toString() + "px; z-index: 1001; min-width: " + (tbselect.parentNode.offsetWidth - 1).toString() + "px; max-height:" + maxheight + "px;overflow:auto; display:none;";
        popup.innerHTML = s;
        popup.style.display = "block";
        popup.focus();
        //popup.onblur = function () { Ribbon_hide_popup(idPopup); };
        popup.onblur = function () { window.setTimeout('document.getElementById("' + idPopup + '").style.display = "none";', 200); };

    };
    Ribbon_selectItem_click = function (idPopup, item, index) {
        //alert(item.toString() + index);
        var select = document.getElementById(item);
        select.selectedIndex = index;
        Ribbon_set_select(item);
        window.setTimeout('document.getElementById("' + item + '").onchange();', 200);
        document.activeElement.blur();
        //document.getElementById(idPopup).style.display = "none";
        //Ribbon_hide_popup(idPopup);
    }; //Ribbon_hide_popup = function (idPopup) {
        //window.setTimeout('document.getElementById("' + idPopup + '").style.display = "none";', 200);
    //}

    Ribbon_set_select = function (idSelect) {
        var select = document.getElementById(idSelect);
        var s = "";
        if (select != null && select.selectedIndex >= 0)
            s = select.options[select.selectedIndex].text;
        var selectText = document.getElementById(idSelect + "_textbox");

        if (selectText != null) {
            if (document.all) selectText.innerText = s; else selectText.textContent = s;
        }
    };
    Ribbon_findAbsolutePosition = function (obj, objParent) {
        var pcurleftx = 0;
        var pcurtopy = 0;
        if (objParent.offsetParent) {
            do {
                pcurleftx += objParent.offsetLeft;
                pcurtopy += objParent.offsetTop;
            } while (objParent = objParent.offsetParent);
        }
        var curleftx = 0;
        var curtopy = 0;
        if (obj.offsetParent) {
            do {
                curleftx += obj.offsetLeft;
                curtopy += obj.offsetTop;
            } while (obj = obj.offsetParent);
        }
        return [curleftx - pcurleftx, curtopy - pcurtopy];
    };
    Ribbon_HandleException = function (name, e) {
        alert("Exception thrown in function " + name + "\n\n" + e.toString());
    };
    try {
        this.ribbonData = ribbonData;
        this.ribbonclass = "epm_ribbon";
        if (this.ribbonData.ribbonclass != null && this.ribbonData.ribbonclass != "")
            this.ribbonclass = this.ribbonData.ribbonclass;
    }
    catch (e) {
        Ribbon_HandleException("Ribbon Initialization", e);
    }
}


    
