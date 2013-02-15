function CostAnalyzer(thisID, params) {
    // NB Constructor code at end of function
    var MakeDelegate = function (target, method) {
        if (method === null) {
            throw ("Method not found");
        }

        return function () {
            return method.apply(target, arguments);
        }
    }

    //  General page settings


    CostAnalyzer.prototype.OnLoad = function (event) {
        try {

            Grids.OnValueChanged = GridsOnValueChangedDelegate;
            Grids.OnAfterValueChanged = GridsOnAfterValueChangedDelegate;

            Grids.OnFilterFinish = GridsOnFilterFinishDelegate;
            Grids.OnClickCell = GridsOnClickCellDelegate;
            Grids.OnGetDefaultColor = GridsOnGetDefaultColorDelegate;
            Grids.OnReady = GridsOnReadyDelegate;
            Grids.OnAfterColResize = GridsOnAfterColResizeDelegate;
            Grids.OnStartDragCell = GridsOnStartDragCellDelegate;
            Grids.OnEndDragCell = GridsOnEndDragCellDelegate;
            Grids.OnMoveDragCell = GridsOnMoveDragCellDelegate;
 
            Grids.OnRenderStart = GridsOnRenderStartDelegate;
            Grids.OnRenderFinish = GridsOnRenderFinishDelegate;



            Grids.OnUpdated = GridsOnUpdatedDelegate;


            WorkEnginePPM.CostAnalyzer.set_path(this.params.Webservice);

            var s = this.BuildLoadInf(this.params.TicketVal, this.params.ViewID);


            WorkEnginePPM.CostAnalyzer.ExecuteJSON("CALoadData", s, LoadCostDataCompleteDelegate);


         }
        catch (e) {
            alert("Resource Analyzer OnLoad Exception");
        }
    }

    CostAnalyzer.prototype.OnUnload = function (event) {
        if (this.Dirty && this.ExitConfirmed == false)
            event.returnValue = "You have unsaved changes.\n\nAre you sure you want to exit without saving?";
        this.ExitConfirmed = false;
    }


    CostAnalyzer.prototype.OnResize = function (event) {
        if (this.initialized == true) {
            //var toolbarDataObjectDiv = document.getElementById("toolbarDataObjectDiv");
            var lHeight = this.Height;
            var divLayout = document.getElementById(this.params.ClientID + "layoutDiv");
            if (lHeight > 400) {
                divLayout.style.height = (lHeight /*- toolbarDataObjectDiv.offsetHeight*/ - 12) + "px";

                var lsplit = Math.floor((lHeight - 200) / 2);

                if (this.TotMaxed == false) {

                    this.layout.cells(this.mainArea).setHeight(lsplit - 12);

                    this.layout_totals.cells(this.totalsGridArea).setHeight(lsplit - 12);
                }

            }
            var lWidth = this.Width;
            if (lWidth > 300) {
                divLayout.style.width = lWidth + "px";
            }

            this.layout.cont.obj._offsetTop = 0;
            this.layout.cont.obj._offsetHeight = 0;
            this.layout.cont.obj._offsetLeft = 0;
            this.layout.cont.obj._offsetWidth = 0;


            this.layout.setSizes();

            if (this.dlgEditTarget != null)
                this.dlgEditTarget.window("winEditTargetDlg").setDimension(this.Width, this.Height);
        }
    }



    CostAnalyzer.prototype.HandlePingSession = function () {
        try {
            WorkEnginePPM.CostAnalyzer.Execute("CASessionPing", "");
            this.PingSessionData();
        }
        catch (e) {

        }

    }

    CostAnalyzer.prototype.PingSessionData = function () {

        try {


            window.setTimeout(HandlePingSessionData, 1000 * 60);
        }

        catch (e) {
        }
    }


    CostAnalyzer.prototype.SetSize = function (nWidth, nHeight) {

        if (this.Width == nWidth && this.Height == nHeight)
            return;

        this.Width = nWidth;
        this.Height = nHeight;
        this.OnResize();
    }

    CostAnalyzer.prototype.xmlStringToJson = function (xmlstring) {

        var xml;

        if (window.DOMParser) {
            parser = new DOMParser();
            xml = parser.parseFromString(xmlstring, "text/xml");
        }
        else // Internet Explorer
        {
            xml = new ActiveXObject("Microsoft.XMLDOM");
            xml.async = false;
            xml.loadXML(xmlstring);
        }

        return this.xmlToJson(xml);


    }

    CostAnalyzer.prototype.xmlToJson = function (xml) {

        // Create the return object
        var obj = {};

        if (xml.nodeType == 1) { // element
            // do attributes
            if (xml.attributes.length > 0) {
                for (var j = 0; j < xml.attributes.length; j++) {
                    var attribute = xml.attributes.item(j);
                    obj[attribute.nodeName] = attribute.nodeValue;
                }
            }
        } else if (xml.nodeType == 3) { // text
            obj = xml.nodeValue;
        }

        // do children
        if (xml.hasChildNodes()) {
            for (var i = 0; i < xml.childNodes.length; i++) {
                var item = xml.childNodes.item(i);
                var nodeName = item.nodeName;
                if (typeof (obj[nodeName]) == "undefined") {
                    obj[nodeName] = this.xmlToJson(item);
                } else {
                    if (typeof (obj[nodeName].length) == "undefined") {
                        var old = obj[nodeName];
                        obj[nodeName] = [];
                        obj[nodeName].push(old);
                    }
                    obj[nodeName].push(this.xmlToJson(item));
                }
            }
        }
        return obj;
    };

    CostAnalyzer.prototype.BuildViewInf = function (viewGUID, viewName, isViewDefault, isViewPersonal, bConvToJSON) {
        if (isViewDefault == true) isViewDefault = 1; else if (isViewDefault == false) isViewDefault = 0;
        if (isViewPersonal == true) isViewPersonal = 1; else if (isViewPersonal == false) isViewPersonal = 0;

        var sTopGrid = this.BuildGridInf("g_1", this.AnalyzerFilterschecked, this.AnalyzeGroupingchecked, this.AnalyzerTabisCollapsed);

        var sBottomGrid = this.BuildGridInf("bottomg_1", this.TotalFilterschecked, this.TotalGroupingchecked, this.TotalTabisCollapsed);

        var dataXml = '<View ViewGUID="' + XMLValue(viewGUID) + '" Name="' + XMLValue(viewName) + '" Default="'
                + isViewDefault + '" Personal="' + isViewPersonal + '">'
                + sTopGrid
                + sBottomGrid
                + '<OtherData>'
                + '</OtherData>'
				+ '</View>';

        if (bConvToJSON != true)
            return dataXml;


        return this.xmlStringToJson(dataXml);

    }

    CostAnalyzer.prototype.BuildGridInf = function (gridId, showFilter, showGrouping, ribbonExpanded) {
        if (showFilter == true) showFilter = 1; else if (showFilter == false) showFilter = 0;
        if (showGrouping == true) showGrouping = 1; else if (showGrouping == false) showGrouping = 0;
        var grid = Grids[gridId];
        var leftCols = '';
        var cols = '';
        var rightCols = '';

        var rexpanded = 1;

        if (ribbonExpanded == false)
            rexpanded = 0;

        var visibleCols = grid.GetCols("Visible");
        for (var i = 0; i < visibleCols.length; i++) {
            var colName = visibleCols[i];
            var c = grid.Cols[colName];

            if (c.Sec === 0) {
                leftCols += ',' + colName + ':' + c.Width;
            } else if (c.Sec === 1) {
                cols += ',' + colName + ':' + c.Width;
            } else if (c.Sec === 2) {
                rightCols += ',' + colName + ':' + c.Width;
            }
        }

        try {
            leftCols = leftCols.substr(1);
        } catch (e) {
        }

        try {
            cols = cols.substr(1);
        } catch (e) {
        }

        try {
            rightCols = rightCols.substr(1);
        } catch (e) {
        }


        var filterRow = grid.GetRowById('Filter');
        var filters = '';
        if (filterRow !== null) {
            for (var col in grid.Cols) {
                var cell = filterRow[col + 'Filter'];

                if (cell !== undefined) {
                    if (cell !== 0) {
                        filters += ',' + col + ':' + filterRow[col] + ':' + cell;
                    }
                }
            }
        }

        if (filters.length > 0) {
            filters = filters.substr(1);
        }



        filters = showFilter + '|' + filters;

        var grouping = showGrouping + '|' + grid.Group;

        var sorting = grid.Sort;

        var dataXml = '<' + XMLValue(gridId) + ' LeftCols="' + XMLValue(leftCols) + '" Cols="' + XMLValue(cols) + '" RightCols="'
                    + XMLValue(rightCols) + '" Filters="' + XMLValue(filters) + '" Grouping="' + grouping + '" Sorting="' + sorting + '" RibbonExpanded="' + rexpanded + '"/>';
        return dataXml;
    }

    CostAnalyzer.prototype.DoesColExist = function (allcols, thiscol) {
        try {
            for (var c in allcols) {
                var cn = allcols[c];

                if (cn == thiscol)
                    return true;
            }
        } catch (e) {

        }

        return false;
    }

    CostAnalyzer.prototype.ApplyGridView = function (gridId, view, bRender) {
        try {

            var grid = Grids[gridId];
            var gridView = view[gridId];
            var allCols = new Array();

            var gcols = grid.GetCols();

            var p1c1ind = 0;


            var FromList = document.getElementById("idAnalyzerTab_FromPeriod");
            var ToList = document.getElementById("idAnalyzerTab_ToPeriod");

            var StartID = parseInt(FromList.options[FromList.selectedIndex].value);
            var FinishID = parseInt(ToList.options[ToList.selectedIndex].value);

            for (var i = 0; i < gcols.length; i++) {
                if (gcols[i] == "P1C1") {
                    p1c1ind = i;
                    break;
                }
            }


            if (gridView.LeftCols !== null) {
                var leftCols = gridView.LeftCols.split(',');

                for (var c in leftCols) {
                    var cv = leftCols[c].split(':');
                    var col = cv[0];

                    if (this.DoesColExist(gcols, col) == true) {

                        Array.add(allCols, col);

                        try {
                            var width = cv[1] - grid.Cols[col].Width;

                            //                        if (col === 'Edit') {
                            //                            if ($.browser.msie && parseInt($.browser.version) <= 8) {
                            //                                width = 23;
                            //                            }
                            //                        }

                            if (width !== 0) {
                                grid.SetWidth(col, width);
                            }
                        } catch (e) {
                        }

                        grid.MoveCol(col, 0, 1, 1);
                    }
                }
            }


            if (gridView.Cols !== null) {
                var cols = gridView.Cols.split(',');

                for (var c in cols) {
                    var cv = cols[c].split(':');
                    var col = cv[0];

                    if (this.DoesColExist(gcols, col) == true) {

                        Array.add(allCols, col);

                        try {
                            var width = cv[1] - grid.Cols[col].Width;
                            if (width !== 0) {
                                grid.SetWidth(col, width);
                            }
                        } catch (e) {
                        }

                        grid.MoveCol(col, 1, 1, 1);
                    }
                }
                for (var i = 0; i < gcols.length; i++) {
                    if (grid.Cols[gcols[i]].Sec == 2)
                        break;

                    if (grid.Cols[gcols[i]].Sec == 1) {
                        var xfound = false;
                        for (var j = 0; j < allCols.length; j++) {
                            if (allCols[j] === gcols[i])
                                xfound = true;
                        }

                        if (!xfound)
                            grid.MoveCol(gcols[i], 1, 1, 1);
                    }
                }


            }



            var groupCols = grid.Group.split(',');

            try { grid.DoGrouping(null); } catch (e) { };
            try {
                for (var i = 0; i < groupCols.length; i++) {
                    grid.HideCol(groupCols[i]);
                }
            } catch (e) { };


            try {
                if (gridView.Cols !== null) {
                    var vCols = grid.GetCols('Visible');
                    vCols = vCols.concat(groupCols);

                    var mainCols = [];

                    var bhadFirstPer = false;

                    for (var i = 0; i < vCols.length; i++) {

                        if (vCols[i] === "P1C1")
                            bhadFirstPer = true;

                        if (bhadFirstPer) {

                            var per, sCol;

                            sCol = vCols[i].substr(1, vCols[i].length - 2);
                            per = parseInt(sCol);

                            if (per >= StartID && per <= FinishID)
                                allCols.push(vCols[i]);
                            else {
                                mainCols.push(vCols[i]);
                            }

                        } else {

                            var found = false;
                            for (var j = 0; j < allCols.length; j++) {
                                if (allCols[j] === vCols[i]) {
                                    found = true;
                                }
                            }

                            if (!found) {
                                mainCols.push(vCols[i]);
                            }
                        }
                    }


                    if (allCols.length > 0)
                        grid.ChangeColsVisibility(allCols, mainCols, 0);
                } else {
                    this.flashGridView(gridId, false);
                }
            }
            catch (e) { }


            try {
                if (gridView['Filters'] === '') {
                    grid.ChangeFilter('', '', '', 0, 0, null);
                } else {
                    var filters = gridView['Filters'].split('|');

                    if (filters[0] === '1') {
                        this.showFilters(grid);
                    } else {
                        this.hideFilters(grid);
                    }

                    filters[1] = filters[1].replace(",", ":");

                    var filter = filters[1].split(':');

                    var colvals = new Array();
                    var valvals = new Array();
                    var opvals = new Array();

                    if (filter.length > 2) {
                        var xi = 0;

                        for (var xj = 0; xj < filter.length; xj++) {
                            ++xi;
                            if (xi == 1)
                                colvals[colvals.length] = filter[xj];

                            else if (xi == 2)
                                valvals[valvals.length] = filter[xj];

                            else {
                                opvals[opvals.length] = filter[xj];
                                xi = 0;
                            }
                        }

                        try { grid.ChangeFilter(colvals, valvals, opvals, 0, 0, null); } catch (e) { };

                    }



                }
            }
            catch (e) { }


            try {
                grid.ChangeSort(gridView['Sorting']);
            } catch (e) { }




            if (gridView['Grouping'] === '') {
                try { grid.DoGrouping(null); } catch (e) { };
            } else {
                var grouping = gridView['Grouping'].split('|');

                if (grouping[0] === '1') {
                    this.showGrouping(grid);
                } else {
                    this.hideGrouping(grid);
                }

                try { grid.DoGrouping(grouping[1]); } catch (e) { };
            }

            try {
                if (bRender)
                    grid.Render();
            }
            catch (e) { };


        } catch (e) {
            this.HandleException("ApplyGridView", e);
        }
    }

    CostAnalyzer.prototype.flashGridView = function (gridId, bDoRender) {
        try {

            var grid = Grids[gridId];
            var allCols = new Array();

            var gcols = grid.GetCols();
            var vCols = grid.GetCols('Visible');

            var p1c1ind = 0;


            var FromList = document.getElementById("idAnalyzerTab_FromPeriod");
            var ToList = document.getElementById("idAnalyzerTab_ToPeriod");

            var StartID = parseInt(FromList.options[FromList.selectedIndex].value);
            var FinishID = parseInt(ToList.options[ToList.selectedIndex].value);

            for (var i = 0; i < gcols.length; i++) {
                if (gcols[i] == "P1C1") {
                    p1c1ind = i;
                    break;
                }
            }

            for (var i = 0; i < vCols.length; i++) {
                if (grid.Cols[vCols[i]].Sec < 2)
                    Array.add(allCols, vCols[i]);
                else
                    break;
            }


            var mainCols = [];
            var bhadFirstPer = false;

            for (var i = 0; i < gcols.length; i++) {

                if (gcols[i] === "P1C1")
                    bhadFirstPer = true;

                if (bhadFirstPer) {

                    var per, sCol;


                    sCol = gcols[i].substr(1, gcols[i].length - 2);

                    if (gcols[i].charAt(0) != "P")
                        mainCols.push(gcols[i]);
                    else if (sCol.indexOf("C") == -1)
                        mainCols.push(gcols[i]);
                    else {
                        per = parseInt(sCol);

                        if (per >= StartID && per <= FinishID)
                            allCols.push(gcols[i]);
                        else
                            mainCols.push(gcols[i]);
                    }
                }
                else {

                    var found = false;
                    for (var j = 0; j < allCols.length; j++) {
                        if (allCols[j] === gcols[i]) {
                            found = true;
                        }
                    }

                    if (!found)
                        mainCols.push(gcols[i]);
                }
            }


            if (allCols.length > 0)
                grid.ChangeColsVisibility(allCols, mainCols, 0);

            try {
                if (bDoRender == true)
                    grid.Render();
            }
            catch (e) { };


        }
        catch (e) {
            this.HandleException("ApplyGridView", e);
        }
    }

    CostAnalyzer.prototype.SaveCostAnalyzerViewComplete = function (jsonString) {
        try {
            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {
                var view = jsonObject.Result.View;

                var bFound = false;
                var select = document.getElementById("idAnalyzerTab_SelView");
                for (var i = 0; i < select.options.length; i++) {
                    if (select.options[i].value == view.ViewGUID) {
                        select.options[i].text = view.Name;
                        bFound = true;
                        this.Views[i] = view;
                        break;
                    }
                }
                if (bFound == false) {
                    select.options[select.options.length] = new Option(view.Name, view.ViewGUID, true, true);

                    this.Views.push(view);
                }

                if (select.options.length == 0)
                    select.disabled = true;
                else
                    select.disabled = false;

                this.SetViewChanged(null);

                this.externalEvent('SaveView_Cancel');

            }
        }
        catch (e) {
            this.HandleException("SaveCostAnalyzerViewComplete", e);
        }
    }

    CostAnalyzer.prototype.RenameResourceAnalyzerViewComplete = function (jsonString) {
        try {
            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {
                var view = jsonObject.Result.View;

                var bFound = false;
                var select = document.getElementById("idAnalyzerTab_SelView");
                for (var i = 0; i < select.options.length; i++) {
                    if (select.options[i].value == view.ViewGUID) {
                        select.options[i].text = view.Name;
                        bFound = true;
                        break;
                    }
                }

                this.SetViewChanged(null);

                this.externalEvent('SaveView_Cancel');

            }
        }
        catch (e) {
            this.HandleException("RenameResourceAnalyzerViewComplete", e);
        }
    }

    // >>>>Calendar and periods selection

    CostAnalyzer.prototype.BuildLoadInf = function (sTicket, ViewID) {

        var dataXml = '<Load Ticket="' + sTicket + '" ViewID="' + ViewID + '">' + '</Load>';
        return dataXml;
    }


    // >>>>>> Totals area


    CostAnalyzer.prototype.GetTotals = function () {
        WorkEnginePPM.CostAnalyzer.ExecuteJSON("GetTotalsConfiguration", "", this.GetTotalsDataCompleteDelegate);
    }

    CostAnalyzer.prototype.GetTotalsDataComplete = function (jsonString) {

        try {
            if (this.SetTotals == null) {



                this.SetTotals = new dhtmlXWindows();
                this.SetTotals.setSkin("dhx_web");

                this.SetTotals.enableAutoViewport(false);
                this.SetTotals.attachViewportTo(this.params.ClientID + "mainDiv");
                this.SetTotals.setImagePath(this.imagePath);
                this.SetTotals.createWindow("winTotDlg", 20, 30, 500, 300);
                this.SetTotals.window("winTotDlg").setIcon("logo.ico", "logo.ico");
                this.SetTotals.window("winTotDlg").allowMove();
                this.SetTotals.window("winTotDlg").denyResize();
                this.SetTotals.window("winTotDlg").setModal(true);
                this.SetTotals.window("winTotDlg").center();
                this.SetTotals.window("winTotDlg").setText("Totals Column Configuration");
                this.SetTotals.window("winTotDlg").attachObject("idTotalsDlgObj");
                this.SetTotals.window("winTotDlg").button("close").disable();
                this.SetTotals.window("winTotDlg").button("park").hide();

                //       document.getElementById("dhxMainCont").style.border = "none";

                this.TotalsLoading = true;

            }
            else
                this.SetTotals.window("winTotDlg").show();



            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {
                this.TotalsData = jsonObject.Result.TotalsConfiguration;


                var selSelected = document.getElementById('idSelSelectedCols');
               
                selSelected.options.length = 0;


                for (var n = 0; n < this.TotalsData.FIELD.length; n++) {
                    var fld = this.TotalsData.FIELD[n];
                    var Id = fld.ID;
                    var Name = fld.Name;
                    var Selb = fld.Selected;
                    selSelected.options[n] = new Option(Name, Id, Selb == 1, Selb == 1);
                }
            }
        }
        catch (e) {
            alert("Cost Analyzer  GetTotalsDataComplete error " + e.toString());

            if (this.SetTotals != null) {
                this.SetTotals.window("winTotDlg").detachObject()
                this.SetTotals.window("winTotDlg").close();
                this.SetTotals = null;
            }
        }
        this.TotalsLoading = false;

    }

    CostAnalyzer.prototype.SelectTotals_OKOnClick = function (iApply) {
        if (iApply == 1) {
            var selSelected = document.getElementById('idSelSelectedCols');

            var sb = new StringBuilder();
            sb.append("<TotalsConfiguration>");

            var sbDataxml = new StringBuilder();

            for (i = 0; i <= selSelected.options.length - 1; i++) {

                if (selSelected.options[i].selected == true) {
                    var fID = selSelected.options[i].value;
                    sbDataxml.append("<Item ");
                    sbDataxml.append("ID='");
                    sbDataxml.append(fID);
                    sbDataxml.append("'/>");
                    sb.append(sbDataxml.toString())
                }
            }


            sb.append("</TotalsConfiguration>");

            this.TotalsColumnSettings = sb.toString();
            this.stashgridsettings = this.BuildViewInf("guid", "name", false, false, true);

            var gview = this.stashgridsettings.View.bottomg_1;
            gview.Cols = null;
            gview.LeftCols = null;
            gview.RightCols = null;

            //            if (this.bottomgridbyrole != rbtotByRole.checked) {
            //                gview.Grouping = "";
            //                gview.Filters = "";
            //                gview.Sorting = "";

            //            }
            //            else {

            this.bottomgriddragstash = this.BuildViewInf("guid", "name", false, false, true);
            this.stashgridsettings = null;
            //            }

            WorkEnginePPM.CostAnalyzer.Execute("SetTotalsConfiguration", sb.toString(), this.SetTotalsDataCompleteDelegate);



        }

        this.SetTotals.window("winTotDlg").detachObject();
        this.SetTotals.window("winTotDlg").close();
        this.SetTotals = null;
    }



    CostAnalyzer.prototype.SetCompareCostTypeListComplete = function (jsonString) {

        try {

            this.heatmapText = "";
            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {
                this.heatmapText = jsonObject.Result.HeatMapText.Value;
            }
            document.getElementById("idTotCompVal").innerHTML = this.heatmapText;
            RefreshBottomGrid();
        }

        catch (e) {
            alert("Cost Analyzer  SetCompareCostTypeListComplete error " + e.toString());

        }
    }

    CostAnalyzer.prototype.SetTotalsDataComplete = function () {

        try {
                RefreshBottomGrid();
            }
        
        catch (e) {
            alert("Cost Analyzer  SetTotalsDataComplete error " + e.toString());

        }
    }

    CostAnalyzer.prototype.SelectCTCmp = function (iApply) {
        if (iApply == 1) {
            var selSelected = document.getElementById('idSelectCTCmp');
            this.bdoingCmp = false;

            var sb = new StringBuilder();
            sb.append("<CTCMP>");

            var sbDataxml = new StringBuilder();

            for (i = 0; i <= selSelected.options.length - 1; i++) {

                if (selSelected.options[i].selected == true) {
                    var fID = selSelected.options[i].value;
                    this.bdoingCmp = true;
                    sbDataxml.append("<Item ");
                    sbDataxml.append("ID='");
                    sbDataxml.append(fID);
                    sbDataxml.append("'/>");
                    sb.append(sbDataxml.toString())
                }
            }


            sb.append("</CTCMP>");

            this.stashgridsettings = this.BuildViewInf("guid", "name", false, false, true);

            var gview = this.stashgridsettings.View.bottomg_1;
            gview.Cols = null;
            gview.LeftCols = null;
            gview.RightCols = null;

            this.bottomgriddragstash = this.BuildViewInf("guid", "name", false, false, true);
            this.stashgridsettings = null;
            //            }

            WorkEnginePPM.CostAnalyzer.ExecuteJSON("SetCompareCostTypeList", sb.toString(), this.SetCompareCostTypeListCompleteDelegate);

            this.FlashTargetMenuStuff();

        }


        this.CostTypeDlg.window("winCostTypeDlg").detachObject();
        this.CostTypeDlg.window("winCostTypeDlg").close();
        this.CostTypeDlg = null;
    }



    CostAnalyzer.prototype.SetChangeViewComplete = function (jsonString) {

        try {
            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {
                this.TotalsGridSettingsData = jsonObject.Result.ViewData.TotalsGridSetting;

                this.TotalsGridSupressHeatmap = this.TotalsGridSettingsData.HeatMap.HeapMapSubCol;
                this.TotalsGridTotalsCol = this.TotalsGridSettingsData.HeatMap.HeapMapTotalsCol;

                var wmode = jsonObject.Result.ViewData.WorkDisplayMode.Mode;

//                var wsel = document.getElementById("idAnalyzerTab_SelMode");
//                wsel.selectedIndex = wmode - 1;


                this.DetailsData = jsonObject.Result.ViewData.WorkDetails;

                var wselectedItem = wsel.options[wsel.selectedIndex];

//                this.flashRibbonSelect("idAnalyzerTab_SelMode");
                this.flashTotalsButtons();

                this.stashgridsettings = null;

                RefreshBothGrids();
            }
        }
        catch (e) {
            alert("Resource Analyzer  SetChangeViewComplete error " + e.toString());

        }
    }


    CostAnalyzer.prototype.SelectDetails_OKOnClick = function () {

        var sb = new StringBuilder();
        sb.append("<CTDetails>");

        var sbDataxml;

        for (var n1 = 0; n1 < this.CTsPresent.CostType.length; n1++) {
            var ct = this.CTsPresent.CostType[n1];
            var cId = ct.ID;
            var cName = ct.Name;
            var cEvent = ct.Event;
            var cbuttonID = ct.ButtonID

            sbDataxml = new StringBuilder();
            sbDataxml.append("<CT ID='" + cId + "' Value='");
            sbDataxml.append(ct.Sel);
            sbDataxml.append("'/>");
            sb.append(sbDataxml.toString());
        }

 







        sb.append("</CTDetails>");

        this.DetailsSettings = sb.toString();
        try {
            this.stashgridsettings = this.BuildViewInf("guid", "name", false, false, true);
        }
        catch(e) {
        }
        WorkEnginePPM.CostAnalyzer.Execute("SetCTDetails", sb.toString());

        RefreshBothGrids();
    }


    CostAnalyzer.prototype.SetSelectedMode = function () {
        try {

            var sb = new StringBuilder();
            sb.append("<ShowDetails>");

            var sbDataxml = new StringBuilder();
            sbDataxml.append("<QTY Value='");
            sbDataxml.append((this.viewTab.getButtonState("chksQuantity") ? "1" : "0"));
            sbDataxml.append("'/>");
            sb.append(sbDataxml.toString());
            
            sbDataxml = new StringBuilder();
            sbDataxml.append("<FTE Value='");
            sbDataxml.append((this.viewTab.getButtonState("chksFTE") ? "1" : "0"));
            sbDataxml.append("'/>");
            sb.append(sbDataxml.toString());
           
            sbDataxml = new StringBuilder();
            sbDataxml.append("<COST Value='");
            sbDataxml.append((this.viewTab.getButtonState("chksCost") ? "1" : "0"));
            sbDataxml.append("'/>");
            sb.append(sbDataxml.toString());
           
            sbDataxml = new StringBuilder();
            sbDataxml.append("<DECOST Value='");
            sbDataxml.append((this.viewTab.getButtonState("chksDecCosts") ? "1" : "0"));
            sbDataxml.append("'/>");
            sb.append(sbDataxml.toString());
   

            sb.append("</ShowDetails>");

            this.ModeSettings = sb.toString();
            try {
                this.stashgridsettings = this.BuildViewInf("guid", "name", false, false, true);
            }
            catch (e) {
            }
            WorkEnginePPM.CostAnalyzer.Execute("SetDisplayMode", sb.toString());

            RefreshBothGrids();
 
            return true;

        }
        catch (e) {
            this.HandleException("SetSelectedMode", e);
        }
        return null;
    }

    // >>>> Showing initalizing the grids and menus

    var RefreshBothGrids = function () {

        try {


            window.setTimeout(HandleRefreshBothDelegate, 400);
        }

        catch (e) {
        }
    }

    CostAnalyzer.prototype.HandleBothRefresh = function () {

        try {
            if (this.DetGrid != null)
                this.DetGrid.Reload(null);

            if (this.FilterDifferent == false)
                RefreshBottomGrid();

            this.FilterDifferent = false;
        }
        catch (e) {

        }

    }


    CostAnalyzer.prototype.InitializeLayout = function () {
        try {


            var analyzerTabData = {
                parent: "idAnalyzerTabDiv",
                style: "display:none;",
                showstate: "true",
                initialstate: "expanded",
                onstatechange: "dialogEvent('TopRibbon_Toggle');",
                imagePath: this.imagePath,
                sections: [
                    {
                        name: "Actions",
                        tooltip: "Plan Actions",
                        columns: [
                            {
                                 items: [
                                    { type: "bigbutton", name: "Close", img: "formatmap32x32.png", style: "top: -448px; left: -288px;position:relative;", tooltip: "Close", onclick: "dialogEvent('AnalyzerTab_Close');" }
                                ]
                             }
                        ]
                    },
                    {
                        name: "Total Details",
                        tooltip: "Total Details",
                        columns: [
                        ]
                    },
                    {
                        name: "Share",
                        tooltip: "Share",
                        columns: [
                           {
                               items: [
                                    { type: "bigbutton", id: "idExportExcelTop", name: "Export to<br/> Excel", img: "formatmap32x32.png", style: "top: -352px; left: 0px;position:relative;", tooltip: "Export to Excel", onclick: "dialogEvent('AnalyzerTab_ExporttoExcel');" }
                                ]
                           },
                           {
                               items: [
                                    { type: "bigbutton", id: "idPrintTop", name: "Print", img: "ps32x32.png", style: "top: -287px; left: -128px;position:relative;", tooltip: "Print", onclick: "dialogEvent('AnalyzerTab_Print');" }
                                ]
                           }
                        ]
                    }
                ]
            };



            var sections = analyzerTabData.sections;
            var columns = null;

            for (var xi = 0; xi < sections.length - 1; xi++) {
                if (sections[xi].name == "Total Details") {
                    columns = sections[xi].columns;
                    break;
                }
            }

            if (columns != null) {
                var xacc = 0;
                var cacc = -1;



                for (var n1 = 0; n1 < this.CTsPresent.CostType.length; n1++) {
                    var ct = this.CTsPresent.CostType[n1];
                    var cId = ct.ID;
                    var cName = ct.Name;
                    var cEvent = ct.Event;
                    var cbuttonID = ct.ButtonID;

                    if (xacc == 0) {
                        ++cacc;
                        columns[cacc] = new Object;
                        columns[cacc].items = new Array;
                    }

                    var addme = new Object;
                    addme.type = "mediumtext";
                    addme.id = cbuttonID;
                    addme.name = "Show " + cName;
                    addme.tooltip = "Show " + cName;
                    addme.onclick = "dialogEvent('" + cEvent + "');";


                    columns[cacc].items[xacc++] = addme;

                    if (xacc >= 3)
                        xacc = 0;
                }


            }





            var viewTabData = {
                parent: "idViewTabDiv",
                style: "display:none;",
                showstate: "true",
                initialstate: "expanded",
                onstatechange: "dialogEvent('TopRibbon_Toggle');",
                imagePath: this.imagePath,
                sections: [
                     {
                        name: "View Management",
                        columns: [
                            {
                                items: [
                                    { type: "smallbutton", id: "SaveViewBtn", name: "Save View", img: "createview.gif", tooltip: "Save View", onclick: "dialogEvent('AnalyzerTab_SaveView');" },
                                    { type: "smallbutton", id: "RenameViewBtn", name: "Rename View", img: "editview.gif", tooltip: "Rename View", onclick: "dialogEvent('AnalyzerTab_RenameView');" },
                                    { type: "smallbutton", id: "DeleteViewBtn", name: "Delete View", img: "deleteview.gif", tooltip: "Delete View", onclick: "dialogEvent('AnalyzerTab_DeleteView');" }
                                ]
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "idAnalyzerShowFilters", name: "Show Filters", img: "showhidefilters-16.png", tooltip: "Show Filters", onclick: "dialogEvent('AnalyzerTab_ShowFilters_Click');" },
                                    { type: "smallbutton", id: "idAnalyzerShowGrouping", name: "Show Grouping", img: "grouping.gif", tooltip: "Show Grouping", onclick: "dialogEvent('AnalyzerTab_ShowGrouping_Click');" },
                                    { type: "smallbutton", id: "idViewTab_RemoveSorting", name: "Clear Sorting", img: "clearsort.gif", tooltip: "Remove Sorting", onclick: "dialogEvent('AnalyzerTab_RemoveSorting_Click');" }
                                ]
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "idAnalyzerShowBars", name: "Show Bars", img: "formatmap16x16.png", style: "top: -128px; left: -128px;position:relative;", tooltip: "Show Bars", onclick: "dialogEvent('AnalyzerTab_ShowBars_Click');" },
                                    { type: "smallbutton", id: "idAnalyzerHideDetails", name: "Hide Details", img: "ps16x16.png", style: "top: -112px; left: -64px;position:relative;", tooltip: "Hide Details", onclick: "dialogEvent('AnalyzerTab_HideDetails_Click');" }
                                 ]
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "SelectColumnsBtn", name: "Select Columns", img: "selectcolumn.gif", tooltip: "Select Columns", onclick: "dialogEvent('AnalyzerTab_SelectColumns');" },
                                    { type: "smallbutton", id: "idAnalyzerExpandAll", name: "Expand All", img: "ExpandAll.gif", tooltip: "Expand All", onclick: "dialogEvent('AnalyzerTab_ExpandAll');" },
                                    { type: "smallbutton", id: "idAnalyzerCollapsAll", name: "Collapse All", img: "CollapseAll.gif", tooltip: "Collapse All", onclick: "dialogEvent('AnalyzerTab_CollapseAll');" }

                               ]
                            },
                            {
                                items: [
                                    { type: "text", name: "Current View:" },
                                    { type: "select", id: "idAnalyzerTab_SelView", onchange: "dialogEvent('AnalyzerTab_SelView_Changed');", width: "100px" }
                                ]
                            },
                            {
                                items: [
                                    { type: "text", name: " ", width: "10px" }
                                ]
                            },
                            {
                                items: [
                                    { type: "mediumtext", id: "chksQuantity", name: "Show Quantity", tooltip: "Show Quantity", onclick: "dialogEvent('AnalyzerTab_SelMode_Changed1');" },
                                    { type: "mediumtext", id: "chksFTE", name: "Show FTEs", tooltip: "Show FTEs", onclick: "dialogEvent('AnalyzerTab_SelMode_Changed2');" },
                                    { type: "mediumtext", id: "chksCost", name: "Show Costs", tooltip: "Show Costs", onclick: "dialogEvent('AnalyzerTab_SelMode_Changed3');" }
                                ]
                           },
                           {
                               items: [
                                    { type: "mediumtext", id: "chksDecCosts", name: "Show Decimal Places in Costs", tooltip: "Show Decimal Places in Costs", onclick: "dialogEvent('AnalyzerTab_SelMode_Changed4');" }
                                 ]
                            }
                         ]
                    },
                       {
                           name: "Periods",
                           columns: [
                           {
                               items: [
                                    { type: "text", name: "From Period:" },
                                    { type: "select", id: "idAnalyzerTab_FromPeriod", onchange: "dialogEvent('AnalyzerTab_FromPeriod_Changed');", width: "100px" }
                                ]
                           },
                             {
                                 items: [
                                    { type: "text", name: " ", width: "10px" }
                                ]
                             },
                             {
                                 items: [
                                    { type: "text", name: "To Period:" },
                                    { type: "select", id: "idAnalyzerTab_ToPeriod", onchange: "dialogEvent('AnalyzerTab_ToPeriod_Changed');", width: "100px" }
                                ]
                             }
                        ]
                       }
                ]
            };


            var BottomTabData = {
                parent: "idBottomTabDiv",
                style: "display:none;",
                showstate: "true",
                initialstate: "expanded",
                onstatechange: "dialogEvent('TotalRibbon_Toggle');",
                imagePath: this.imagePath,
                sections: [
                    {
                        name: "Actions",
                        columns: [
                            {
                                items: [
                                    { type: "mediumbutton", id: "idTotCol", name: "Total<br/> Column", img: "TotalColumnsl20x20.png", tooltip: "Total Columns", onclick: "dialogEvent('TotalsTab_SelectTotalColumns');" }
                                ]
                            },
                            {
                                items: [
                                    { type: "mediumbutton", id: "CTCmpBtn", name: "Compare<br/> Totals", img: "capscenariosl20x20.png", tooltip: "Compare Totals against Cost Type", onclick: "dialogEvent('CTCmpBtn');" }
                               ]
                            }
                         ]
                    },
                    {
                        name: "Options",
                        columns: [
                            {
                                items: [
                                    { type: "smallbutton", id: "idTotTab_ShowFilters", name: "Show Filters", img: "showhidefilters-16.png", tooltip: "Show Filters", onclick: "dialogEvent('TotalsTab_ShowFilters_Click');" },
                                    { type: "smallbutton", id: "idTotTab_ShowGrouping", name: "Show Grouping", img: "grouping.gif", tooltip: "Show Grouping", onclick: "dialogEvent('TotalsTab_ShowGrouping_Click');" }
                                ]
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "idTotTab_RemSort", name: "Remove Sorting", img: "sort-16.png", tooltip: "Remove Sorting", onclick: "dialogEvent('TotalsTab_RemoveSorting_Click');" },
                                    { type: "smallbutton", id: "idTotTab_SelCol", name: "Select Columns", img: "formatmap16x16.png", style: "top: -224px; left: -128px;position:relative;", tooltip: "Select Columns", onclick: "dialogEvent('TotalsTab_SelectColumns');" }
                                ]
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "idTotExpandAll", name: "Expand All", img: "ExpandAll.gif", tooltip: "Expand All", onclick: "dialogEvent('TotalsTab_ExpandAll');" },
                                    { type: "smallbutton", id: "idTotCollapsAll", name: "Collapse All", img: "CollapseAll.gif", tooltip: "Collapse All", onclick: "dialogEvent('TotalsTab_CollapseAll');" }
                                ]
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "ShowTotChk", name: "Show Remaining", img: "ps16x16.png", style: "top: -112px; left: -64px;position:relative;", tooltip: "Show Totals or Remaining", onclick: "dialogEvent('ShowTotBtn');" },
                                     { type: "smallbutton", id: "TargetLegend", name: "Legend", img: "ps16x16.png", style: "top: -128px; left: -176px;position:relative;", tooltip: "Legend", onclick: "dialogEvent('TotalsTab_TarLegBtn');" }
                                ]

                            }
                        ]
                    },
                    {
                        name: "Share",
                        tooltip: "       ",
                        columns: [
                           {
                               items: [
                                    { type: "mediumbutton", id: "idExportExcelBot", name: "Export<br/> to Excel", img: "exportexcel20x20.png", tooltip: "Export to Excel", onclick: "dialogEvent('TotalsTab_ExporttoExcel');" }
                                ]
                           },
                           {
                               items: [
                                    { type: "mediumbutton", id: "idPrintBot", name: "Print", img: "printl20x20.png", tooltip: "Print", onclick: "dialogEvent('TotalTab_Print');" }
                                ]
                           }
                        ]
                    },
                    {
                        name: "Comparison",
                        columns: [
                            {
                                items: [
                                  { type: "text", name: "Comparison Data", disabled: true },
                                  { type: "text", id: "idTotCompVal", name: "       ", disabled: true, width: "200px" }
                               ]
                            }
                        ]
                    }

                ]
            };

            //,{ type: "smallbutton", id: "GridExplain", name: "Grid Explaination", img: "help.gif", tooltip: "Grid Explaination", onclick: "dialogEvent('TotalsTab_GridHelpBtn');" }


            this.layout = new dhtmlXLayoutObject(this.params.ClientID + "layoutDiv", "3E", "dhx_skyblue");
            this.layout.cells(this.mainRibbonArea).setText("Analyzer");
            this.layout.cells(this.mainArea).setText("Main Area");
            this.layout.cells(this.totalsArea).setText("Total Area");

            this.layout.cells(this.mainRibbonArea).hideHeader();
            this.layout.cells(this.mainArea).hideHeader();
            this.layout.cells(this.totalsArea).hideHeader();
            this.layout_totals = this.layout.cells(this.totalsArea).attachLayout("2E", "dhx_skyblue");
            this.layout_totals.cells(this.totalsRibbonArea).setText("Totals");
            this.layout_totals.cells(this.totalsGridArea).setText("Total Grid Area");
            this.layout_totals.cells(this.totalsRibbonArea).hideHeader();
            this.layout_totals.cells(this.totalsGridArea).hideHeader();
            this.layout_totals.cells(this.totalsRibbonArea).setHeight(68);
            this.layout_totals.cells(this.totalsRibbonArea).fixSize(false, true);


            //	        this.tabbar = this.layout.cells(this.mainRibbonArea).attachTabbar();



            this.layout.cells(this.mainArea).attachObject("gridDiv_1");


            this.Tabbar = this.layout.cells(this.mainRibbonArea).attachTabbar();
            this.Tabbar.attachEvent("onSelect", function (id) { tabbarOnSelectDelegate(id, arguments); return true; });

            this.analyzerTab = new Ribbon(analyzerTabData);
            this.analyzerTab.Render();
            this.viewTab = new Ribbon(viewTabData);
            this.viewTab.Render();

            this.totTab = new Ribbon(BottomTabData);
            this.totTab.Render();

            //this.planTabbar.setSkin("dark_blue");
            this.Tabbar.setImagePath("/_layouts/epmlive/dhtml/xtab/imgs/");
            this.Tabbar.enableAutoReSize();
            this.Tabbar.addTab("tab_Display", "Analyzer", 70);
            this.Tabbar.setContent("tab_Display", this.analyzerTab.getRibbonDiv());
            this.Tabbar.addTab("tab_View", "View", 70);
            this.Tabbar.setContent("tab_View", this.viewTab.getRibbonDiv());

            this.layout_totals.cells(this.totalsRibbonArea).attachObject(document.getElementById(this.totTab.getRibbonDiv()));

            this.layout_totals.cells(this.totalsGridArea).attachObject("gridDiv_Totals");

            this.layout.cells(this.mainArea).setHeight(200);



            this.layout.cells(this.mainRibbonArea).setHeight(120);


            this.layout.cells(this.mainRibbonArea).setHeight(120);
            this.layout.cells(this.mainRibbonArea).fixSize(false, true);
            this.layout_totals.cells(this.totalsRibbonArea).setHeight(68);

            this.layout_totals._minHeight = 18;
            this.layout._minHeight = 18;

            var FromList = document.getElementById("idAnalyzerTab_FromPeriod");
            var ToList = document.getElementById("idAnalyzerTab_ToPeriod");

            document.getElementById("idTotCompVal").innerHTML = this.heatmapText;


            if (this.initDataStart == 0)
                this.initDataStart = 1;

            if (this.initDataFinish == 0)
                this.initDataFinish = this.UsingPeriods.Period.length;

            this.initDataStart = this.initDataStart - 1;
            this.initDataFinish = this.initDataFinish - 1;


            for (var n1 = 0; n1 < this.UsingPeriods.Period.length; n1++) {
                var per = this.UsingPeriods.Period[n1];
                var perId = per.perID;
                var perName = per.perName;

                FromList.options[n1] = new Option(perName, perId, n1 == this.initDataStart, n1 == this.initDataStart);
                ToList.options[n1] = new Option(perName, perId, n1 == this.initDataFinish, n1 == this.initDataFinish);

                if (n1 == 0)
                    this.PerStart = perId;

                this.PerEnd = perId;

            }

            this.flashRibbonSelect('idAnalyzerTab_FromPeriod');
            this.flashRibbonSelect('idAnalyzerTab_ToPeriod');

            this.flashTotalsButtons();
            this.FlashTargetMenuStuff();

            this.Tabbar.setTabActive("tab_Display");
        }
        catch (e) {
            alert("CostAnalyzer InitializeLayout Exception");
        }
    }

    CostAnalyzer.prototype.flashTotalsButtons = function () {

        try {
            for (var n1 = 0; n1 < this.CTsPresent.CostType.length; n1++) {
                var ct = this.CTsPresent.CostType[n1];
                var cSel = ct.Sel;
                var cbuttonID = ct.ButtonID
                
                if (cSel == 1)
                    this.analyzerTab.setButtonStateOn(cbuttonID);
                else
                    this.analyzerTab.setButtonStateOff(cbuttonID);
   
            }

        }
        catch (e) { }
    }


    CostAnalyzer.prototype.LoadCostDataComplete = function (result) {
        try {
            var jsonObject = JSON_ConvertString(result);
            if (JSON_ValidateServerResult(jsonObject)) {

                var errors = jsonObject.Result.Error;

                if (errors != undefined) {
                    if (errors != null) {

                        if (errors.Value != "") {

                            alert("Error: " + errors.Value);
                            if (SP.UI.DialogResult)
                                SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');
                            else
                                SP.UI.ModalDialog.commonModalDialogClose(0, '');

                            return;
                        }
                    }
                }


                this.UsingPeriods = jsonObject.Result.Periods;
                this.CTsPresent = jsonObject.Result.CostTypes;
                this.ModeSettings = jsonObject.Result.DisplayMode;

                //                this.TargetData = jsonObject.Result.Targets;
                var views = jsonObject.Result.Views;
                this.Views = JSON_GetArray(views, "View");

                //                this.TotalsData = jsonObject.Result.TotalsConfiguration.TotalsConfiguration;

                //                this.TotalsColumnSettings = jsonObject.Result.TotalsConfiguration.Value;

                //                this.DetailsSettings = jsonObject.Result.DetailsConfiguration.Value;
                //                this.DetailsData = jsonObject.Result.DetailsConfiguration.WorkDetails;

                this.DisplayMode = jsonObject.Result.DisplayModeXML.Value;
                //                this.PMOAdmin = jsonObject.Result.gpPMOAdmin.Value;

                //                var LoadingDataReply = jsonObject.Result.LoadingDataReply;

                //                this.ticketvalue = jsonObject.Result.TicketValue.Value;
                //                this.ticketreturns = jsonObject.Result.TicketReturns.Value;

                //                this.loadedDataCount = jsonObject.Result.DetailsLoaded.Value;

                try {
                    this.initDataStart = parseInt(jsonObject.Result.PeriodRange.Start);
                    this.initDataFinish = parseInt(jsonObject.Result.PeriodRange.Finish);
                }
                catch (e) {

                }

                //                this.heatmapText = "";

                //                try {
                //                    this.heatmapText = jsonObject.Result.HeatMapText.Value;
                //                }
                //                catch (e) { }

                //                if (LoadingDataReply.Value !== "")
                //                    alert(LoadingDataReply.Value);

                this.InitializeLayout();

                window.setTimeout(HandlePopulateUI, 200);



                this.PingSessionData();
            }
        }
        catch (e) {
            this.HandleException("LoadCostDataComplete", e);
            if (SP.UI.DialogResult)
                SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');
            else
                SP.UI.ModalDialog.commonModalDialogClose(0, '');

        }
    }



    CostAnalyzer.prototype.GridsOnRenderStart = function (grid) {
        if (grid.id == "bottomg_1")
            this.refreshIconsInTotGrid = null;

        return false;
    }
    CostAnalyzer.prototype.GridsOnRenderFinish = function (grid) {
        if (grid.id == "bottomg_1") {
            this.TotGrid = grid;
            if (this.refreshIconsInTotGrid != null)
                window.setTimeout(HandleRerenderDelegate, 400);
        }
    }


    CostAnalyzer.prototype.HandleRerender = function () {

        if (this.refreshIconsInTotGrid != null) {
            for (var i = 0; i < this.refreshIconsInTotGrid.length; i++) {
                this.TotGrid.RefreshCell(this.refreshIconsInTotGrid[i], "IconFlag");
            }
            this.refreshIconsInTotGrid = null;
        }

    }


    CostAnalyzer.prototype.PopulateUI = function () {

        try {
            this.selectedView = null;
 

            this.TotalGroupingchecked = false;
            this.TotalFilterschecked = false;


            this.AnalyzerFilterschecked = false;
            this.AnalyzeGroupingchecked = false;

            try {
                
                   if (this.ModeSettings.QTY.Value != "0")
                        this.viewTab.setButtonStateOn("chksQuantity");
                    else
                        this.viewTab.setButtonStateOff("chksQuantity");
                      
                 
                   if (this.ModeSettings.FTE.Value != "0")
                        this.viewTab.setButtonStateOn("chksFTE");
                    else
                        this.viewTab.setButtonStateOff("chksFTE");
                                      
                   if (this.ModeSettings.COST.Value != "0")
                        this.viewTab.setButtonStateOn("chksCost");
                    else
                        this.viewTab.setButtonStateOff("chksCost");
                                      
                   if (this.ModeSettings.DECOST.Value != "0")
                        this.viewTab.setButtonStateOn("chksDecCosts");
                    else
                        this.viewTab.setButtonStateOff("chksDecCosts");
                                            
            }
            catch(e) {}



            this.selectedView != null
            var selectviews = document.getElementById("idAnalyzerTab_SelView");
            selectviews.options.length = 0;


            if (this.Views != null) {
                for (var i = 0; i < this.Views.length; i++) {
                    var view = this.Views[i];


                    if (this.bapplyDefView == true || view.Default == 0)
                        selectviews.options[selectviews.options.length] = new Option(view.Name, view.ViewGUID, false, false);
                    else {

                        this.bapplyDefView = (view.Default == 1)
                        selectviews.options[selectviews.options.length] = new Option(view.Name, view.ViewGUID, this.bapplyDefView, this.bapplyDefView);
                    }
                }


                if (selectviews.options.length == 0)
                    selectviews.disabled = true;
                else
                    selectviews.disabled = false;

                this.selectedView = this.GetSelectedView();
                this.bapplyDefView = true; // this stops the autoselection next time through this code if there was no default view previously defined

                this.SetViewChanged(null);
            }


            if (this.selectedView != null)
                WorkEnginePPM.CostAnalyzer.ExecuteJSON("ApplyCostAnalyzerViewServerSideSettings", this.selectedView.ViewGUID, this.CreateTopGridDelegate);
            else
                this.CreateTopGridDelegate("");

        }
        catch (e) {
            this.HandleException("PopulateUI", e);
            if (SP.UI.DialogResult)
                SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');
            else
                SP.UI.ModalDialog.commonModalDialogClose(0, '');

        }
    }

    CostAnalyzer.prototype.CreateTopGrid = function (jsonString) {

        try {

            if (jsonString == undefined || jsonString == "") {
                this.TotalsGridSettingsData = null;

                this.TotalsGridSupressHeatmap = 0;
            }
            else {

                var jsonObject = JSON_ConvertString(jsonString);
                if (JSON_ValidateServerResult(jsonObject)) {
//                    this.TotalsGridSettingsData = jsonObject.Result.ViewData.TotalsGridSetting;

//                    this.TotalsGridSupressHeatmap = this.TotalsGridSettingsData.HeatMap.HeapMapSubCol;
//                    this.TotalsGridTotalsCol = this.TotalsGridSettingsData.HeatMap.HeapMapTotalsCol;
                      this.heatmapText = "";

//                    try {
//                        this.heatmapText = this.TotalsGridSettingsData.HeatMap.HeatMapText;
//                    }
//                    catch (e) { }

//                    this.DetailsData = jsonObject.Result.ViewData.WorkDetails;   // the next two lines are needed to flash the proper state of the totals buttons on the top grid 
//                    this.flashTotalsButtons()

                    document.getElementById("idTotCompVal").innerHTML = this.heatmapText;

//                    var wmode = jsonObject.Result.ViewData.WorkDisplayMode.Mode;

                }
            }

            this.stashgridsettings = null;
            var sbDataxml = new StringBuilder();
            sbDataxml.append('<![CDATA[');
            sbDataxml.append('<Execute Function="GetCostAnalyzerData">');
            sbDataxml.append('</Execute>');
            sbDataxml.append(']]>');

            var sb = new StringBuilder();
            sb.append("<treegrid debug='0' sync='0' ");
            sb.append(" Export_Url='rpaExportExcel.aspx'");
            sb.append(" data_url='" + this.Webservice + "'");
            sb.append(" data_method='Soap'");
            sb.append(" data_function='Execute'")
            sb.append(" data_namespace='WorkEnginePPM'");
            sb.append(" data_param_Function='GetCostAnalyzerData'");
            sb.append(" data_param_Dataxml='" + sbDataxml.toString() + "'");
            sb.append(" >");
            sb.append("</treegrid>");

            this.DetGrid = TreeGrid(sb.toString(), "gridDiv_1", "g_1");
            this.OnResize();
        }
        catch (e) {
            this.HandleException("CreateTopGrid", e);
            if (SP.UI.DialogResult)
                SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');
            else
                SP.UI.ModalDialog.commonModalDialogClose(0, '');

        }
    }


    // >>>>>>>>>>>  Grid event handlers

    CostAnalyzer.prototype.GridsOnValueChanged = function (grid, row, col, val) {
        if (grid.id != "et_1")
            return val;


        if (col.charAt(0) !== "P")
            return val;

        var s = col.substr(1);
        var i = s.indexOf("V");

        if (i === -1)
            return val;

        var per = s.substr(0, i);

        i = row.id - 1;
        trow = this.CapScenData[i];
        frow = this.CostCatFTEData[i];

        fval = frow.FTEs[per - 1].Value

        if (this.CSHourMode == true) {
            if (fval != 0)
                trow.FTEs[per - 1].Value = val / fval;
            else
                trow.FTEs[per - 1].Value = 0;

            trow.Hours[per - 1].Value = val;
        }
        else {
            trow.Hours[per - 1].Value = fval * val;
            trow.FTEs[per - 1].Value = val;
        }


        return val;


    }

    CostAnalyzer.prototype.GridsOnAfterValueChanged = function (Grid, Row, Col, value) {

        if (Grid.id == "g_1" && Col == "Select") {
            var sb = new StringBuilder();
            sb.append("<Rows ");
            sb.append(" value='" + value + "'>");

            HandleClick(Grid, Row, Col, value, sb);

            sb.append("</Rows>");

            //       alert(sb.toString());

            WorkEnginePPM.CostAnalyzer.Execute("SetDetailsSelectedFlag", sb.toString());
            this.bottomgriddragstash = this.BuildViewInf("guid", "name", false, false, true);
            RefreshBottomGrid();
            return;
        }
    }

    CostAnalyzer.prototype.GridsOnClickCell = function (grid, row, col) {

        if (grid.id == "g_1") {

            var bg = Grids["bottomg_1"];

            bg.SelectAllRows(0);
            return;

        }

        if (grid.id == "bottomg_1") {

            var tg = Grids["g_1"];

            tg.SelectAllRows(0);
            return;

        }


        if (grid.id == "et_1")
            this.csrow = row;
    }

    CostAnalyzer.prototype.GetGridRow = function (Grid, row) {
        try {
            return Grid.Rows[row];

        }
        catch (e) {
            return null;
        }

    }

    CostAnalyzer.prototype.GridsOnFilterFinish = function (Grid) {

        if (Grid.id == "g_1") {

            if (this.GetGridRow(Grid, 1) == null)
                return;

            var children;

            var sb = new StringBuilder();
            sb.append("<FilteredRows>");

            var i = 1;

            while (i != 0) {
                var arow = this.GetGridRow(Grid, i);
                ++i;

                if (arow == null) {
                    i = 0;
                    break;
                }
                else {

                    children = arow.firstChild;

                    if (children == null) {
                        var rowid = Grid.GetString(arow, "rowid");

                        if (rowid != "" && arow.Visible == false)
                            sb.append("<Row rowid='" + rowid + "'/>");
                    }
                }
            }

            sb.append("</FilteredRows>");

            if (this.LastFilterString != sb.toString())
                WorkEnginePPM.CostAnalyzer.Execute("SetDetailsFilteredFlag", sb.toString(), HandleRefreshDelegate);

            this.LastFilterString = sb.toString();

            return;
        }
    }


    CostAnalyzer.prototype.GetSelectedView = function () {
        try {
            var selectView = document.getElementById("idAnalyzerTab_SelView");
            if (selectView.selectedIndex >= 0) {
                var selectedItem = selectView.options[selectView.selectedIndex];
                if (selectedItem.value != null) {
                    if (this.Views != null) {
                        for (var i = 0; i < this.Views.length; i++) {
                            var view = this.Views[i];
                            if (view != null) {
                                if (view.ViewGUID == selectedItem.value) {
                                    this.doTopApply = true;
                                    this.doBottomApply = true;
                                    this.flashRibbonSelect("idAnalyzerTab_SelView");
                                    return view;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (e) {
            this.HandleException("GetSelectedView", e);
        }
        return null;
    }



    CostAnalyzer.prototype.AnalyzerViewDlg_OnClose = function () {
        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").detachObject()
        this.AnalyzerViewDlg = null;
    }


    CostAnalyzer.prototype.AnalyzerDeleteViewDlg_OnClose = function () {
        this.AnalyzerDeleteViewDlg.window("winAnalyzerDeleteViewDlg").detachObject()
        this.AnalyzerDeleteViewDlg = null;
    }

    CostAnalyzer.prototype.DeleteResourceAnalyzerViewComplete = function (jsonString) {
        try {
            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {
                var viewGUID = jsonObject.Result.View.ViewGUID;

                var bFound = false;
                var select = document.getElementById("idAnalyzerTab_SelView");
                for (var i = 0; i < select.options.length; i++) {
                    if (select.options[i].value == viewGUID) {
                        bFound = true;
                        select.options[i] = null;

                        // for (var f in this.views)
                        for (var i = 0; i < this.Views.length; i++) {

                            var view = this.Views[i];

                            if (view != undefined) {

                                if (view.ViewGUID != undefined) {

                                    if (view.ViewGUID == viewGUID) {
                                        delete this.Views[i];
                                        break;
                                    }
                                }
                            }
                        }
                        break;
                    }
                }

                if (select.options.length == 0)
                    select.disabled = true;
                else
                    select.disabled = false;

                this.externalEvent('DeleteView_Cancel');
                this.SetViewChanged(null);


            }
        }
        catch (e) {
            this.HandleException("DeleteResourcePlanViewComplete", e);
        }
    }



    CostAnalyzer.prototype.GridsOnReady = function (grid, start) {
        try {

            if (grid.id == "g_1")
                this.topgridready = true;

            if (grid.id == "bottomg_1")
                this.bottomgridready = true;


            if (this.doTopApply == false && this.doBottomApply == false && this.stashgridsettings != null && (grid.id == "g_1" || grid.id == "bottomg_1")) {

                this.ApplyGridView(grid.id, this.stashgridsettings.View, false);
            }
            else if (this.bottomgriddragstash != null && grid.id == "bottomg_1") {
                this.ApplyGridView(grid.id, this.bottomgriddragstash.View, false);
                this.bottomgriddragstash = null;
                return;
            }
            else if (this.topgridstash != null && grid.id == "g_1") {
                this.ApplyGridView(grid.id, this.topgridstash.View, false);
                this.topgridstash = null;
                return;
            }


        }
        catch (e) { };



        try {

            if (grid.id == "bottomg_1" && this.initialized == false) {
                this.initialized = true;
                this.OnResize();
            }

            if (grid.id == "g_1") {
                if (this.TotGrid == null) {

                    if (this.AnalyzerFilterschecked == true) {
                        this.showFilters(grid);
                    } else {
                        this.hideFilters(grid);
                    }

                    if (this.AnalyzeGroupingchecked == true) {
                        this.showGrouping(grid);
                    } else {
                        this.hideGrouping(grid);
                    }

                    var sbDataxml = new StringBuilder();

                    sbDataxml = new StringBuilder();
                    sbDataxml.append('<![CDATA[');
                    sbDataxml.append('<Execute Function="GetCostAnalyzerTotals">');
                    sbDataxml.append('</Execute>');
                    sbDataxml.append(']]>');

                    sb = new StringBuilder();
                    sb.append("<treegrid debug='0' sync='0' ");
                    sb.append(" Export_Url='rpaExportExcel.aspx'");
                    sb.append(" data_url='" + this.Webservice + "'");
                    sb.append(" data_method='Soap'");
                    sb.append(" data_function='Execute'")
                    sb.append(" data_namespace='WorkEnginePPM'");
                    sb.append(" data_param_Function='GetCostAnalyzerTotals'");
                    sb.append(" data_param_Dataxml='" + sbDataxml.toString() + "'");
                    sb.append(" >");
                    sb.append("</treegrid>");


                    this.TotGrid = TreeGrid(sb.toString(), "gridDiv_Totals", "bottomg_1");




                }

                if (this.selectedView != null && this.doTopApply == true)
                    this.ApplyGridView(grid.id, this.selectedView, true);
                else if(this.doTopApply == true) {
                    this.flashGridView(grid.id, true)
                }



                if (this.deferredhidedetails == true) {
                    this.deferredhidedetails = false;
                    this.AnalyzerHideDetailschecked = !this.AnalyzerHideDetailschecked;    // this gets flipped back or even set to false whilst in the next proc
                    this.FlashTopGridHideDetails();

                    if (this.AnalyzerHideDetailschecked == true) {
                        this.viewTab.setButtonStateOn("idAnalyzerHideDetails");
                    } else {
                        this.viewTab.setButtonStateOff("idAnalyzerHideDetails");
                    }


                }
                this.doTopApply = false;

            }

            if (grid.id == "bottomg_1") {

                if (this.selectedView != null && this.doBottomApply == true)
                    this.ApplyGridView(grid.id, this.selectedView, false);
                else if (this.doBottomApply == true) {
                    this.flashGridView(grid.id, true)
                }


                this.doBottomApply = false;

                if (this.TotalFilterschecked == true) {
                    this.showFilters(grid);
                } else {
                    this.hideFilters(grid);
                }

                if (this.TotalGroupingchecked == true) {
                    this.showGrouping(grid);
                } else {
                    this.hideGrouping(grid);
                }


                if (this.loadedDataCount == "0") {
                    alert("The Items or Resources you selected to Analyze do not have any associated plans with them - hence the grids are displaying no data");


                }

            }

        }
        catch (e) {
            this.HandleException("GridsOnReady", e);
        }
    }

    var AllLeavesChecked = function (Grid, Row) {
        var children;
        children = Row.firstChild;

        if (children == null) {
            var rowck = Grid.GetString(Row, "Select");
            if (rowck == "0")
                return false;

        }

        while (children != null) {
            if (AllLeavesChecked(Grid, children) == false)
                return false;

            children = children.nextSibling;
        }

        return true;
    }

    CostAnalyzer.prototype.HandleRerenderChecks = function () {

        if (this.refreshChecksInDetGrid != null) {
            for (var i = 0; i < this.refreshChecksInDetGrid.length; i++) {
                this.DetGrid.RefreshCell(this.refreshChecksInDetGrid[i], "Select");
            }
            this.refreshChecksInDetGrid = null;
        }



    }


    CostAnalyzer.prototype.HandleRerenderRollups = function () {
        this.tg_rollup_render = true;

        if (this.tg_rollup != null) {
            for (var i = 0; i < this.tg_rollup.length; i++) {

                var o = this.tg_rollup[i];
                this.DetGrid.RefreshCell(o.Row, o.Col);
            }

        }

        this.tg_rollup = null;
        this.tg_rollup_render = false;

    }

    CostAnalyzer.prototype.CheckLeafValuesareSame = function (grid, row, col) {

        var children;
        children = row.firstChild;

        if (children == null) {
            var rowv = grid.GetString(row, col);

            if (this.GrpColValSet == false) {
                this.GrpColValSet = true;
                this.GrpColVal = rowv;
            }
            else if (this.GrpColVal != rowv)
                return false;

        }

        while (children != null) {
            if (this.CheckLeafValuesareSame(grid, children, col) == false)
                return false;

            children = children.nextSibling;
        }

        return true;
    }

    CostAnalyzer.prototype.GridsOnGetDefaultColor = function (grid, row, col, r, g, b) {
        if (grid.id == "et_1") {

            if (this.EditGrid.GetAttribute(row, col, "CanEdit") == "0")
                return 0xDADCDD;

            return null;

        }

        if (grid.id == "g_1") {

            if (row.id == "Filter")
                return null;



            if (row.Kind == "Data") {

  
                if (grid.Cols[col].Sec == 2 && col.substr(0, 1) == "P" && this.AnalyzerShowBarschecked == true) {
                    var fp = grid.GetValue(row, "xinterenalPeriodMin");
                    var lp = grid.GetValue(row, "xinterenalPeriodMax");

                    var stg = col.substr(1);
                    var itg = stg.indexOf("C");

                    var peridtg = parseInt(stg.substr(0, itg));

                    if (peridtg >= fp && peridtg <= lp) {

                        //var cls = grid.GetAttribute(row, col, "ClassInner");
                        //        grid.SetAttribute(row, col, "ClassInner", "GMngBodyRight", 1);



                        return 0x00F800;
                    }

                    if (row.firstChild == null)
                        return null;

                    return this.groupColour;
                }
            }



            if (row.firstChild == null || row.id == "Filter")
                return null;

            if (col == "Select") {

                var bAll = AllLeavesChecked(grid, row);

                var rowck = grid.GetString(row, "Select");
                var newck = (bAll == true ? "1" : "0");

                if (rowck != newck) {
                    grid.SetAttribute(row, col, null, newck, 1);


                    if (this.refreshChecksInDetGrid == null) {
                        this.refreshChecksInDetGrid = new Array();
                        window.setTimeout(HandleRerenderChecksDelegate, 400);
                    }

                    this.refreshChecksInDetGrid[this.refreshChecksInDetGrid.length] = row;
                    //grid.RefreshCell(row, "Select");
                }
            }

            if (col == "RowSel")
                return null;



            // this is where we need to check the children to see if they all have the same value and if so set this rows col to that value....

            if (grid.Cols[col].Sec == 1 && this.tg_rollup_render == false) {
                var rowv = grid.GetString(row, col);

                if (rowv == "") {
                    this.GrpColVal = "";
                    this.GrpColValSet = false;


                    if (this.CheckLeafValuesareSame(grid, row, col) == true) {
                        if (this.tg_rollup == null) {
                            this.tg_rollup = new Array();
                            window.setTimeout(HandleRerenderRollupsDelegate, 400);
                        }

                        var o = new Object();

                        o.Row = row;
                        o.Col = col;

                        grid.SetAttribute(row, col, null, this.GrpColVal, 1);
                        //  o.val = this.GrpColVal;

                        //          if (this.tg_rollup_render == false)
                        this.tg_rollup.push(o);
                    }

                }


            }


            return this.groupColour;
        }

        if (row.firstChild == null)
            return null;

        if (grid.id != "bottomg_1")
            return null;

        if (row.firstChild == null || row.id == "Filter")
            return null;

        if (col == "RowSel")
            return null;


        if (col.charAt(0) === "P") {

            var s = col.substr(1);
            var i = s.indexOf("C");

            if (i === -1)
                return 0xDADCDD;

            // because we can now swap the target bounds around we need to look at thchildrenminvalinstead if the comparison is swapped

            var perid = s.substr(0, i);
            var subper = s.substr(i + 1);
            var childrenMaxhmVal = grid.GetValue(row, "X" + s);
            var childrenMinhmVal = grid.GetValue(row, "Y" + s);
            var myhmVal;

            var hmcol = "P" + perid + "H";

            var hmv = grid.GetValue(row, hmcol);
            var cv = grid.GetValue(row, col);

            if (subper == this.TotalsGridTotalsCol) {
                var retval = this.TargetBackground(cv, hmv);
                var bdoit = false;

                if (this.selectedHeatMapColour == 1)
                    bdoit = (this.tarlev < childrenMaxhmVal && childrenMaxhmVal != "")
                else
                    bdoit = (this.tarlev > childrenMinhmVal && childrenMinhmVal != "")


                if (bdoit == true) {
                    var rowicon = grid.GetString(row, "IconFlag");

                    if (rowicon != '/_layouts/ppm/images/Yellow.gif') {

                        grid.SetAttribute(row, "IconFlag", null, '/_layouts/ppm/images/Yellow.gif', 1);

                        if (this.refreshIconsInTotGrid == null) {
                            this.refreshIconsInTotGrid = new Array();
                            window.setTimeout(HandleRerenderDelegate, 600);

                        }


                        this.refreshIconsInTotGrid[this.refreshIconsInTotGrid.length] = row;


                    }
                }


                //	            if (this.tarlev < childrenMaxhmVal) 
                //	                grid.SetString(row, col + "Icon", '/_layouts/ppm/images/Yellow.gif', 1);
                //	            else
                //	                grid.SetString(row, col + "Icon", '/_layouts/ppm/images/Green.gif', 1);

                return retval;
            }
            else
                return 0xFFFFFF;

        }

        return this.groupColour;

    }

    CostAnalyzer.prototype.TargetBackground = function (Tdbl, Pdbl) {

        var sRet = 0xFFFFFF;
        var i;
        this.tarlev = -4;

        try {

            var crgb = -1;

            if (this.TargetData == null)
                return sRet;

            if (this.TargetData.Target.length == 0)
                return sRet;

            var targets = this.TargetData.Target

            if (Tdbl == 0 && Pdbl == 0) {
                this.tarlev = -3;
                for (i = 0; i < targets.length; is++) {
                    if (targets[i].ID == -3) {
                        crgb = targets[i].RGB;
                        break;
                    }
                }
            }
            else if (Tdbl == 0) {
                this.tarlev = -2;
                for (i = 0; i < targets.length; i++) {
                    if (targets[i].ID == -2) {
                        crgb = targets[i].RGB;
                        break;
                    }
                }
            }
            else if (Pdbl == 0) {
                this.tarlev = -1;

                for (i = 0; i < targets.length; i++) {
                    if (targets[i].ID == -1) {
                        crgb = targets[i].RGB;
                        break;
                    }
                }
            }
            else {

                var percnt;



                if (this.selectedHeatMapColour == 1)
                    percnt = (Tdbl / Pdbl) * 100;
                else {
                    percnt = (Pdbl / Tdbl) * 100;

                }




                for (i = 0; i < targets.length; i++) {
                    if (targets[i].ID > 0) {

                        if ((percnt >= targets[i].Lowval && percnt <= targets[i].Hival) || (targets[i].Hival == 0)) {
                            crgb = targets[i].RGB;
                            this.tarlev = targets[i].ID;
                            break;
                        }
                    }
                }
            }

            if (crgb == -1)
                return sRet;

            return "rgb(" + (crgb & 0xFF) + "," + ((crgb & 0xFF00) >> 8) + "," + ((crgb & 0xFF0000) >> 16) + ")";
        }
        catch (e) {
            return sRet;
        }

    }


    CostAnalyzer.prototype.GridsOnStartDragCell = function (grid, row, col, shtml) {

        this.DoingCellDrag = false;
        this.currDrag = null;
        this.singleRowUndraggable = false;

        if (this.PMOAdmin != "1")
            return;


        if (grid.id != "g_1")
            return false;


        this.includesNotDraggable = false;
        this.includesDraggable = false;
        this.draggingGroupRow = false;

        if (this.SelectedMode == 4)
            return false;


        var children = row.firstChild;


        if (children == null) {
            var rowdraggable = grid.GetString(row, "RowDraggable");
            if (rowdraggable == "0") {
                this.singleRowUndraggable = true;
                return false;
            }

        } else {
            this.draggingGroupRow = true;
        }


        if (grid.Cols[col].Sec == 2) {
            this.DoingCellDrag = true;
            this.LastMovedCol = null;
            this.HadMove = false;
            this.currDrag = new Array();
            this.startCol = col;

            this.CaptureDragRow(grid, row);
            return false;
        }



        return true;

    }

    CostAnalyzer.prototype.GridsOnMoveDragCell = function (grid, row, pcol, togrid, torow, tocol, x, y) {

        if (grid.id != "g_1" || this.DoingCellDrag == false)
            return;

        if (this.PMOAdmin != "1")
            return;

        if (grid.id != togrid.id || row == null || pcol == null || torow == null || tocol == null)
            return;


        if (row != torow) {
            //alert("You may only drag within the same row");
            return;
        }

        if (grid.Cols[tocol].Sec != 2) {

            //   alert("You may only drag withing the rows right hand pane");
            return;
        }

        if (pcol == tocol)
            return;

        var start_period = 0;
        var to_period = 0;
        var s;
        var i;

        if (this.LastMovedCol == null)
            col = pcol;
        else
            col = this.LastMovedCol;


        this.LastMovedCol = tocol;

        if (col.charAt(0) === "P") {

            s = col.substr(1);
            i = s.indexOf("C");

            start_period = parseInt(s.substr(0, i));

        }
        if (tocol.charAt(0) === "P") {

            s = tocol.substr(1);
            i = s.indexOf("C");

            to_period = parseInt(s.substr(0, i));

        }

        var sb = new StringBuilder();

        if (start_period != to_period)
            this.HandleDragRow(grid, row, start_period, to_period, sb);


    }
    CostAnalyzer.prototype.GridsOnEndDragCell = function (grid, row, col, togrid, torow, tocol, x, y) {

        var sb = new StringBuilder();


        if (this.PMOAdmin != "1") {
            alert("You do not have the application permission to be able to change the data by dragging rows");
            return;
        }

        if (grid == null || togrid == null)
            return;


        if (grid.id != togrid.id || row == null || col == null || torow == null || tocol == null)
            return;



        if (this.DoingCellDrag == false) {
            if (this.singleRowUndraggable == true)
                alert("The selected row cannot be dragged - so no values have been changed");
            return;

        }

        if (row != torow) {
            alert("You may only drag within the same row");
            this.ResetDragRow(grid, this.currDrag);
            return;
        }

        if (grid.Cols[tocol].Sec != 2) {

            alert("You may only drag withing the rows right hand pane");
            this.ResetDragRow(grid, this.currDrag);
            return;
        }

        if (col == tocol) {
            if (this.HadMove == false)
                return;

            this.HandleDragRow(grid, row, 1, 1, null);
            return;
        }

        var start_period = 0;
        var to_period = 0;
        var s;
        var i;

        if (this.startCol.charAt(0) === "P") {

            s = this.startCol.substr(1);
            i = s.indexOf("C");

            start_period = parseInt(s.substr(0, i));

        }
        if (tocol.charAt(0) === "P") {

            s = tocol.substr(1);
            i = s.indexOf("C");

            to_period = parseInt(s.substr(0, i));

        }

        sb = new StringBuilder();
        sb.append("<Rows ");
        sb.append(" fromCol='" + start_period + "'");
        sb.append(" toCol='" + to_period + "'>");



        this.HandleDragRow(grid, row, null, null, sb);

        sb.append("</Rows>");


        if (this.draggingGroupRow == true) {
            if (this.includesNotDraggable == true) {
                if (this.includesDraggable == true)
                    alert("One of more of the children rows of the selected Group row are not draggable!  Values on those rows will not have changed");
                else {
                    alert("None of the children rows of the selected Group row are draggable!  No values have changed");
                    return;
                }


            }
        }


        this.HaveDragChanges = true;


        this.analyzerTab.enableItem("UndoBtn");
        this.viewTab.enableItem("UndoBtn2");


        this.dragStack.push(this.currDrag);

        this.bottomgriddragstash = this.BuildViewInf("guid", "name", false, false, true);
        WorkEnginePPM.CostAnalyzer.Execute("SetRADragRows", sb.toString(), HandleRefreshDelegate);

    }


    var HandleClick = function (Grid, Row, Col, value, sb) {
        var children;

        Row.Changed = 1;
        Grid.SetString(Row, Col, value, 1);
        children = Row.firstChild;

        if (children == null) {
            var rowid = Grid.GetString(Row, "rowid");
            sb.append("<Row rowid='" + rowid + "'/>");

        }

        while (children != null) {
            HandleClick(Grid, children, Col, value, sb);
            children = children.nextSibling;
        }
    }

    CostAnalyzer.prototype.CaptureDragRow = function (Grid, Row) {
        var children;
        children = Row.firstChild;

        if (children == null) {
            var rowdraggable = Grid.GetString(Row, "RowDraggable");
            if (rowdraggable == "0")
                return;

            var rowid = Grid.GetString(Row, "rowid");
            var rCols = Grid.ColNames[2];
            var trow = new Object;
            trow.rowID = rowid;
            trow.rowobj = Row.id;
            trow.rowData = new Array();
            trow.bcStart = Grid.GetValue(Row, "xinterenalPeriodMin");
            trow.bcFinish = Grid.GetValue(Row, "xinterenalPeriodMax");
            var tCol;
            var cval;


            for (var i = 0; i < rCols.length; i++) {
                tCol = rCols[i];
                cval = Grid.GetString(Row, tCol);
                if (cval != "")
                    cval = parseFloat(cval.replace(/,/g, ''));
                else
                    cval = 0;

                trow.rowData[i] = cval;

            }

            this.currDrag.push(trow);


        }

        while (children != null) {
            this.CaptureDragRow(Grid, children);
            children = children.nextSibling;
        }
    }

    CostAnalyzer.prototype.ResetDragRow = function (Grid, rows) {

        if (rows == undefined)
            return;

        if (rows == null)
            return;

        var rCols = Grid.ColNames[2];

        var arows = Grid.Rows;

        for (var j = 0; j < rows.length; j++) {
            var trow = null;

            trow = arows[rows[j].rowobj]

            var dcnt = Grid.GetString(trow, "RowChanged");
            --dcnt;
            Grid.SetString(trow, "RowChanged", dcnt, 1);

            if (dcnt == 0)
                Grid.SetString(trow, "ChangedIcon", '/_layouts/ppm/images/Nogif.gif', 1);
            else
                Grid.SetString(trow, "ChangedIcon", '/_layouts/ppm/images/Approve.gif', 1)




            Grid.SetString(trow, "xinterenalPeriodMin", trow.bcStart, 1);
            Grid.SetString(trow, "xinterenalPeriodMax", trow.bcFinish, 1);

            for (var i = 0; i < rCols.length; i++) {
                var cval = rows[j].rowData[i];
                var tCol = rCols[i];

                Grid.SetString(trow, tCol, cval, 1);
                tCol = "X" + tCol.substr(1);
                cval = rows[j].bcData[i];
                Grid.SetString(trow, tCol, cval, 1);
            }
        }
    }


    CostAnalyzer.prototype.HandleDragRow = function (Grid, Row, fromCol, toCol, sb) {
        var children;




        Row.Changed = 1;
        children = Row.firstChild;




        if (children == null) {
            var rowdraggable = Grid.GetString(Row, "RowDraggable");
            if (rowdraggable == "0") {
                this.includesNotDraggable = true;
                return;
            }

            var rowid = Grid.GetString(Row, "rowid");
            if (sb != undefined)
                sb.append("<Row rowid='" + rowid + "'/>");

            this.includesDraggable = true;

            if (fromCol != null) {

                var sCol;
                var tCol;
                var cval;
                var i;

                var rCols = Grid.ColNames[2];

                if (fromCol == toCol) {

                    if (this.HadMove == false)
                        return;

                    this.HadMove = false;

                    for (var j = 0; j <= this.currDrag.length; j++) {
                        var trow = this.currDrag[j];

                        if (trow.rowID == rowid) {

                            Grid.SetString(Row, "xinterenalPeriodMin", trow.bcStart, 1);
                            Grid.SetString(Row, "xinterenalPeriodMax", trow.bcFinish, 1);

                            for (i = 0; i < rCols.length; i++) {
                                cval = trow.rowData[i];
                                tCol = rCols[i];

                                Grid.SetString(Row, tCol, cval, 1);
                            }
                            return;
                        }
                    }
                    return;
                }
                else if (fromCol < toCol) {
                    var diffr = toCol - fromCol;

                    for (var xi = 1; xi <= diffr; xi++) {
                        sCol = rCols[rCols.length - 1];

                        cval = Grid.GetString(Row, sCol);
                        cval = parseFloat(cval.replace(/,/g, ''));

                        if (cval != 0)     // dont drag data of the end of the grid
                            return;

                        var iRfp = Grid.GetString(Row, "xinterenalPeriodMin");
                        var iRlp = Grid.GetString(Row, "xinterenalPeriodMax");



                        Grid.SetString(Row, "xinterenalPeriodMin", ++iRfp, 1);
                        Grid.SetString(Row, "xinterenalPeriodMax", ++iRlp, 1);

                        this.HadMove = true;
                        for (i = rCols.length; i >= 2; i--) {
                            tCol = rCols[i - 1];
                            sCol = rCols[i - 2];

                            cval = Grid.GetString(Row, sCol);
                            cval = parseFloat(cval.replace(/,/g, ''));
                            Grid.SetString(Row, tCol, cval, 1);

                        }

                        Grid.SetString(Row, rCols[0], 0, 1);
                    }

                }
                else {

                    var diffr = fromCol - toCol;

                    for (var xi = 1; xi <= diffr; xi++) {
                        sCol = rCols[0];

                        cval = Grid.GetString(Row, sCol);
                        cval = parseFloat(cval.replace(/,/g, ''));

                        if (cval != 0)     // dont drag data of the start of the grid
                            return;

                        var iLfp = Grid.GetString(Row, "xinterenalPeriodMin");
                        var iLlp = Grid.GetString(Row, "xinterenalPeriodMax");



                        Grid.SetString(Row, "xinterenalPeriodMin", --iLfp, 1);
                        Grid.SetString(Row, "xinterenalPeriodMax", --iLlp, 1);


                        this.HadMove = true;
                        for (i = 1; i <= rCols.length - 1; i++) {
                            tCol = rCols[i - 1];
                            sCol = rCols[i];

                            cval = Grid.GetString(Row, sCol);
                            cval = parseFloat(cval.replace(/,/g, ''));
                            Grid.SetString(Row, tCol, cval, 1);
                        }

                        Grid.SetString(Row, rCols[rCols.length - 1], 0, 1);
                    }
                }
            }
            else {

                var dcnt = Grid.GetString(Row, "RowChanged");
                ++dcnt;
                Grid.SetString(Row, "RowChanged", dcnt, 1);
                Grid.SetString(Row, "ChangedIcon", '/_layouts/ppm/images/Approve.gif', 1);

            }


        }

        while (children != null) {
            this.HandleDragRow(Grid, children, fromCol, toCol, sb);
            children = children.nextSibling;
        }
    }

    var RefreshBottomGrid = function () {

        try {


            window.setTimeout(HandleRefreshDelegate, 700);
        }

        catch (e) {
        }
    }

    CostAnalyzer.prototype.HandleRefresh = function () {

        try {
            if (this.TotGrid != null) {

                this.TotGrid.Reload(null);
            }

        }
        catch (e) {

        }

    }

    CostAnalyzer.prototype.FlashTargetMenuStuff = function () {

        if (this.bdoingCmp == false) {

            this.totTab.disableItem("ShowTotChk");
            this.totTab.disableItem("TargetLegend");

            this.totTab.hideItem("ShowTotChk");
            this.totTab.hideItem("TargetLegend");
            return;
        }


        this.totTab.showItem("ShowTotChk");
        this.totTab.showItem("TargetLegend");
        this.totTab.enableItem("ShowTotChk");
        this.totTab.enableItem("TargetLegend");

    }



    var RefreshTopGrid = function () {

        try {


            window.setTimeout(HandleRefreshTopDelegate, 700);
        }

        catch (e) {
        }
    }

    CostAnalyzer.prototype.HandleTopRefresh = function () {

        try {
            if (this.DetGrid != null) {

                this.DetGrid.Reload(null);
            }

        }
        catch (e) {

        }

    }
    CostAnalyzer.prototype.GetCTListComplete = function (jsonString) {

        try {

 

            if (this.CostTypeDlg == null) {
                this.CostTypeDlg = new dhtmlXWindows();
                this.CostTypeDlg.setSkin("dhx_web");
                this.CostTypeDlg.enableAutoViewport(false);
                this.CostTypeDlg.attachViewportTo(this.params.ClientID + "mainDiv");
                this.CostTypeDlg.setImagePath("/_layouts/ppm/images/");
                this.CostTypeDlg.createWindow("winCostTypeDlg", 20, 30, 500, 300);
                this.CostTypeDlg.window("winCostTypeDlg").setIcon("logo.ico", "logo.ico");
                this.CostTypeDlg.window("winCostTypeDlg").denyResize();
                this.CostTypeDlg.window("winCostTypeDlg").button("park").hide();
                this.CostTypeDlg.window("winCostTypeDlg").setModal(true);
                this.CostTypeDlg.window("winCostTypeDlg").center();
                this.CostTypeDlg.window("winCostTypeDlg").setText("Totals v Cost Types Comparison");
                this.CostTypeDlg.window("winCostTypeDlg").attachEvent("onClose", function (win) { CostTypeDlg_OnCloseDelegate(); return true; });
                this.CostTypeDlg.window("winCostTypeDlg").attachObject("idCTCmpDlgObj");

                var jsonObject = JSON_ConvertString(jsonString);
                if (JSON_ValidateServerResult(jsonObject)) {
                    this.CTCmpData = jsonObject.Result.CTCmpConfiguration;


                    var selSelected = document.getElementById('idSelectCTCmp');

                    selSelected.options.length = 0;


                    for (var n = 0; n < this.CTCmpData.CostType.length; n++) {
                        var fld = this.CTCmpData.CostType[n];
                        var Id = fld.ID;
                        var Name = fld.Name;
                        var Selb = fld.Selected;
                        selSelected.options[n] = new Option(Name, Id, Selb == 1, Selb == 1);
                    }
                }



            }
            else {
                this.CostTypeDlg.window("winCostTypeDlg").show();
            }

        }
        catch (e) {
            this.HandleException("GetCTListComplete", e);
        }
    }

    CostAnalyzer.prototype.CostTypeDlg_OnClose = function () {
        this.CostTypeDlg.window("winCostTypeDlg").detachObject();
        this.CostTypeDlg = null;
    }


    CostAnalyzer.prototype.SetViewChanged = function (selindex) {

        var selectView = document.getElementById("idAnalyzerTab_SelView");

        if (selindex != null) {

            selectView.selectedIndex = selindex - 1;
        }


        var selectedItem = null;

        if (selectView.selectedIndex != -1)
            selectView.options[selectView.selectedIndex];

        var oldguid = "";
        var newguid = "";

        if (this.selectedView != null) {
            oldguid = this.selectedView.ViewGUID;
        }


        this.selectedView = this.GetSelectedView();

        if (this.selectedView != null) {
            newguid = this.selectedView.ViewGUID;
        }

        this.flashRibbonSelect("idAnalyzerTab_SelView");

        if (this.selectedView != null) {


            this.AnalyzerShowBarschecked = false;
            this.AnalyzerHideDetailschecked = false;

            try {
                this.AnalyzerShowBarschecked = (this.selectedView.ViewSettings.ShowBars == "1");
            } catch (e) {
            }

            try {
                this.AnalyzerHideDetailschecked = (this.selectedView.ViewSettings.HideDetails == "1");
            } catch (e) {
            }

            if (this.AnalyzerShowBarschecked == true) {
                this.viewTab.setButtonStateOn("idAnalyzerShowBars");
            } else {
                this.viewTab.setButtonStateOff("idAnalyzerShowBars");
            }


            if (this.AnalyzerHideDetailschecked == true) {
                this.viewTab.setButtonStateOn("idAnalyzerHideDetails");
            } else {
                this.viewTab.setButtonStateOff("idAnalyzerHideDetails");
            }

            this.deferredhidedetails = true;

        }

        if (oldguid == newguid && selindex == null)
            return;

        if (this.selectedView != null) {
            this.FilterDifferent = false;


            this.stashgridsettings = this.BuildViewInf("guid", "name", false, false, true);
            var gridView = this.stashgridsettings.View.g_1;
            var curfilter = gridView['Filters'];
            gridView = this.selectedView["g_1"];
            var newfilter = gridView['Filters'];

            if (newfilter != curfilter) {
                this.FilterDifferent = true;
            }

            WorkEnginePPM.CostAnalyzer.ExecuteJSON("ApplyResourceAnalyzerViewServerSideSettings", this.selectedView.ViewGUID, SetChangeViewCompleteDelegate);
        }
    }



    CostAnalyzer.prototype.deferExternalEvent = function (event) {
        this.deferevent = event;

        window.setTimeout(this.deferedExternalEventDelegate, 200);
    }

    CostAnalyzer.prototype.deferedExternalEvent = function () {
        this.externalEvent(this.deferevent);
        this.deferevent = "";
    }

    CostAnalyzer.prototype.findAbsolutePosition = function (obj) {
        var curleft = curtop = 0;
        if (obj.offsetParent) {
            do {
                curleft += obj.offsetLeft;
                curtop += obj.offsetTop;
            } while (obj = obj.offsetParent);
        }
        return [curleft, curtop];
        //returns an array
    }

    CostAnalyzer.prototype.deferedsetFocus = function () {

        if (this.doSetFocus == "")
            return;
        try {
            document.getElementById(this.doSetFocus).focus();
        }
        catch (e) { }


        this.doSetFocus = "";

    }

    CostAnalyzer.prototype.setNewButtonDisable = function (idButton, bstate) {

        var btn = document.getElementById(idButton);

        if (btn == null)
            return;

        if (bstate == true)
            btn.className = "button-new disabledSilver";
        else
            btn.className = "button-new silver";

    }

    CostAnalyzer.prototype.externalEvent = function (event) {

        try {

            var grid = null;
            var i;
            var viewid = 1;


            if (event == "")
                return;


            if (event.length > 11) {
                var firstchars = event.substr(0, 11);

                if (firstchars == "ViewChanged") {
                    viewid = event.substr(11);
                    event = "ViewChanged";

                }
            }


            for (var n1 = 0; n1 < this.CTsPresent.CostType.length; n1++) {
                var ct = this.CTsPresent.CostType[n1];
                var cId = ct.ID;
                var cName = ct.Name;
                var cEvent = ct.Event;
                var cbuttonID = ct.ButtonID

                if (cEvent == event) {
                    ct.Sel = (ct.Sel == 1 ? 0 : 1);

                    if (ct.Sel == 1)
                        this.analyzerTab.setButtonStateOn(cbuttonID);
                    else
                        this.analyzerTab.setButtonStateOff(cbuttonID);

                    this.SelectDetails_OKOnClick();
                    return;
                }

            }


            switch (event) {
                case "ShowTotBtn":



                    var stateOn = this.totTab.getButtonState("ShowTotChk");


                    if (stateOn == true) {
                        this.bShowingTotals = true;
                        this.totTab.setButtonStateOff("ShowTotChk");
                        WorkEnginePPM.CostAnalyzer.Execute("SetShowRemaining", "0", RefreshBottomGrid);
                    } else {
                        this.bShowingTotals = false;
                        this.totTab.setButtonStateOn("ShowTotChk");
                        WorkEnginePPM.CostAnalyzer.Execute("SetShowRemaining", "1", RefreshBottomGrid);
                    }

                    break;


                case "AnalyzerTab_FromPeriod_Changed":
                    var fp = this.ribbonGetSelectValue("idAnalyzerTab_FromPeriod");
                    var tp = this.ribbonGetSelectValue("idAnalyzerTab_ToPeriod");

                    if (tp < fp) {
                        alert("The From period cannot be after the To Period");
                        this.ribbonSetSelectValue("idAnalyzerTab_FromPeriod", this.PerStart);
                        return;
                    }

                    this.PerStart = fp;

                    this.flashGridView("g_1", true);
                    this.flashGridView("bottomg_1", true);
                    break;


                case "AnalyzerTab_ToPeriod_Changed":


                    var fp = this.ribbonGetSelectValue("idAnalyzerTab_FromPeriod");
                    var tp = this.ribbonGetSelectValue("idAnalyzerTab_ToPeriod");

                    if (tp < fp) {
                        alert("The To period cannot be before the From Period");
                        this.ribbonSetSelectValue("idAnalyzerTab_ToPeriod", this.PerEnd);
                        return;
                    }

                    this.PerEnd = tp;

                    this.flashGridView("g_1", true);
                    this.flashGridView("bottomg_1", true);
                    break;



                case "ViewChanged":
                    this.SetViewChanged(viewid);

                    break;

                case "TotalsTab_Maximize":
                    this.TotMaxed = !this.TotMaxed;

                    if (this.TotMaxed == true) {
                        this.preMaxHeight = this.layout.cells(this.mainArea).getHeight();

                        this.layout.cells(this.mainArea).detachObject();
                        this.layout._minHeight = 1;
                        this.layout.cells(this.mainArea).setHeight(2);
                        this.layout.cells(this.mainArea).fixSize(false, true);

                        //   this.MediumButtonState("TotGridMax", true);


                    } else {

                        this.layout.cells(this.mainArea).fixSize(false, false);
                        this.layout.cells(this.mainArea).setHeight(this.preMaxHeight);

                        this.layout._minHeight = 18;

                        document.getElementById("gridDiv_1").style.display = "block";
                        this.layout.cells(this.mainArea).attachObject("gridDiv_1");
                        //           this.MediumButtonState("TotGridMax", false);
                    }

                    break;

                case "TopRibbon_Toggle":

                    if (this.analyzerTab.isCollapsed() == true) {
                        this.layout.cells(this.mainRibbonArea).fixSize(false, false);
                        this.layout.cells(this.mainRibbonArea).setHeight(120);
                        this.layout.cells(this.mainRibbonArea).fixSize(false, true);
                        this.analyzerTab.expand();
                        this.viewTab.expand();

                    } else {
                        this.layout.cells(this.mainRibbonArea).fixSize(false, false);
                        this.layout.cells(this.mainRibbonArea).setHeight(50);
                        this.layout.cells(this.mainRibbonArea).fixSize(false, true);
                        this.analyzerTab.collapse();
                        this.viewTab.collapse();
                    }
                    break;


                case "TotalRibbon_Toggle":

                    if (this.totTab.isCollapsed() == true) {
                        this.layout_totals.cells(this.totalsRibbonArea).fixSize(false, false);
                        this.layout_totals.cells(this.totalsRibbonArea).setHeight(68);
                        this.layout_totals.cells(this.totalsRibbonArea).fixSize(false, true);

                        this.totTab.expand();

                    } else {
                        this.layout_totals.cells(this.totalsRibbonArea).fixSize(false, false);
                        this.layout_totals.cells(this.totalsRibbonArea).setHeight(22);
                        this.layout_totals.cells(this.totalsRibbonArea).fixSize(false, true);

                        this.totTab.collapse();
                    }
                    break;



                case "AnalyzerTab_ShowFilters_Click":
                    this.AnalyzerFilterschecked = !this.AnalyzerFilterschecked;
                    grid = Grids["g_1"];
                    if (this.AnalyzerFilterschecked == true) {
                        this.showFilters(grid);
                    } else {
                        this.hideFilters(grid);
                    }
                    break;



                case "AnalyzerTab_ShowGrouping_Click":
                    this.AnalyzeGroupingchecked = !this.AnalyzeGroupingchecked;
                    grid = Grids["g_1"];
                    if (this.AnalyzeGroupingchecked == true) {
                        this.showGrouping(grid);
                    } else {
                        this.hideGrouping(grid);
                    }
                    grid.Render();
                    break;


                case "AnalyzerTab_SelView_Changed":
                    this.SetViewChanged(null);

                    break;


                case "AnalyzerTab_RenameView":
                    var selectView = document.getElementById("idAnalyzerTab_SelView");
                    if (selectView != null && selectView.selectedIndex >= 0) {
                        var view = this.GetSelectedView();
                        this.selectedView = view;
                        var selectedItem = selectView.options[selectView.selectedIndex];
                        document.getElementById("id_RenameView_Name").value = selectedItem.text;
                    }
                    else {
                        alert("No views have been saved to be renamed!");
                        break;
                    }

                    if (this.AnalyzerViewDlg == null) {
                        this.AnalyzerViewDlg = new dhtmlXWindows();
                        this.AnalyzerViewDlg.setSkin("dhx_web");
                        this.AnalyzerViewDlg.enableAutoViewport(false);
                        this.AnalyzerViewDlg.attachViewportTo(this.params.ClientID + "mainDiv");
                        this.AnalyzerViewDlg.setImagePath("/_layouts/ppm/images/");
                        this.AnalyzerViewDlg.createWindow("winAnalyzerViewDlg", 20, 30, 280, 142);
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").setIcon("logo.ico", "logo.ico");
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").denyResize();
                        //this.AnalyzerViewDlg.window("winAnalyzerViewDlg").button("close").disable();
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").button("park").hide();
                        //this.AnalyzerViewDlg.setSkin(this.params.DHTMLXSkin);
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").setModal(true);
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").center();
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").setText("Rename View");
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").attachEvent("onClose", function (win) { AnalyzerViewDlg_OnCloseDelegate(); return true; });
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").attachObject("idRenameAnalyzerDlg");
                    }
                    else {
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").show();
                    }
                    break;

                case "AnalyzerTab_SaveView":
                    document.getElementById("id_SaveView_Name").value = "New View";
                    document.getElementById("id_SaveView_Default").checked = false;
                    document.getElementById("id_SaveView_Personal").checked = true;
                    var selectView = document.getElementById("idAnalyzerTab_SelView");
                    if (selectView != null && selectView.selectedIndex >= 0) {
                        var view = this.GetSelectedView();
                        this.selectedView = view;
                        var selectedItem = selectView.options[selectView.selectedIndex];
                        document.getElementById("id_SaveView_Name").value = selectedItem.text;
                        var bDefault = false;
                        //    Joe wants the default for default to be off EVEN for the defaiult view 
                        //                       if (view.Default != 0)
                        //                           bDefault = true;
                        document.getElementById("id_SaveView_Default").checked = bDefault;
                        var bPersonal = false;
                        if (view.Personal != 0)
                            bPersonal = true;
                        document.getElementById("id_SaveView_Personal").checked = bPersonal;
                    }

                    if (this.AnalyzerViewDlg == null) {
                        this.AnalyzerViewDlg = new dhtmlXWindows();
                        this.AnalyzerViewDlg.setSkin("dhx_web");
                        this.AnalyzerViewDlg.enableAutoViewport(false);
                        this.AnalyzerViewDlg.attachViewportTo(this.params.ClientID + "mainDiv");
                        this.AnalyzerViewDlg.setImagePath("/_layouts/ppm/images/");
                        this.AnalyzerViewDlg.createWindow("winAnalyzerViewDlg", 20, 30, 280, 192);
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").setIcon("logo.ico", "logo.ico");
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").denyResize();
                        //this.AnalyzerViewDlg.window("winAnalyzerViewDlg").button("close").disable();
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").button("park").hide();
                        //this.AnalyzerViewDlg.setSkin(this.params.DHTMLXSkin);
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").setModal(true);
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").center();
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").setText("Save View");
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").attachEvent("onClose", function (win) { AnalyzerViewDlg_OnCloseDelegate(); return true; });
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").attachObject("idSaveAnalyzerDlg");
                    }
                    else {
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").show();
                    }
                    break;

                case "AnalyzerTab_DeleteView":
                    document.getElementById("id_DeleteView_Name").value = "";
                    var selectView = document.getElementById("idAnalyzerTab_SelView");
                    if (selectView != null && selectView.selectedIndex >= 0) {
                        var view = this.GetSelectedView();
                        this.selectedView = view;
                        var selectedItem = selectView.options[selectView.selectedIndex];
                        document.getElementById("id_DeleteView_Name").value = selectedItem.text;
                    }

                    if (this.AnalyzerDeleteViewDlg == null) {
                        this.AnalyzerDeleteViewDlg = new dhtmlXWindows();
                        this.AnalyzerDeleteViewDlg.setSkin("dhx_web");
                        this.AnalyzerDeleteViewDlg.enableAutoViewport(false);
                        this.AnalyzerDeleteViewDlg.attachViewportTo(this.params.ClientID + "mainDiv");
                        this.AnalyzerDeleteViewDlg.setImagePath("/_layouts/ppm/images/");
                        this.AnalyzerDeleteViewDlg.createWindow("winAnalyzerDeleteViewDlg", 20, 30, 280, 157);
                        this.AnalyzerDeleteViewDlg.window("winAnalyzerDeleteViewDlg").setIcon("logo.ico", "logo.ico");
                        this.AnalyzerDeleteViewDlg.window("winAnalyzerDeleteViewDlg").denyResize();
                        //this.ViewDlg.window("winViewDlg").button("close").disable();
                        this.AnalyzerDeleteViewDlg.window("winAnalyzerDeleteViewDlg").button("park").hide();
                        //this.ViewDlg.setSkin(this.params.DHTMLXSkin);
                        this.AnalyzerDeleteViewDlg.window("winAnalyzerDeleteViewDlg").setModal(true);
                        this.AnalyzerDeleteViewDlg.window("winAnalyzerDeleteViewDlg").center();
                        this.AnalyzerDeleteViewDlg.window("winAnalyzerDeleteViewDlg").setText("Delete View");
                        this.AnalyzerDeleteViewDlg.window("winAnalyzerDeleteViewDlg").attachEvent("onClose", function (win) { AnalyzerDeleteViewDlg_OnCloseDelegate(); return true; });
                        this.AnalyzerDeleteViewDlg.window("winAnalyzerDeleteViewDlg").attachObject("idDeleteAnalyzerDlg");
                    }
                    else {
                        this.ViewDlg.window("winViewDlg").show();
                    }
                    break;

                case "SaveView_OK":
                    var saveViewName = document.getElementById("id_SaveView_Name").value;
                    var selectView = document.getElementById("idAnalyzerTab_SelView");
                    //var saveViewGuid = "";
                    var guid = new Guid();
                    if (selectView.selectedIndex >= 0) {
                        var selectedItem = selectView.options[selectView.selectedIndex];
                        guid.value = selectedItem.value;
                        if (selectedItem.text != saveViewName || guid.isGuid() != true) {
                            guid.newGuid();
                        }
                    }
                    else
                        guid.newGuid();

                    var bDefault = document.getElementById("id_SaveView_Default").checked;
                    var bPersonal = document.getElementById("id_SaveView_Personal").checked;

                    var s = this.BuildViewInf(guid.value, saveViewName, bDefault, bPersonal, false);
                    var sbd = new StringBuilder();
                    sbd.append('<Execute Function="SaveCostPlanAnalyzerView">');
                    sbd.append(s);
                    sbd.append('</Execute>');

                    WorkEnginePPM.CostAnalyzer.ExecuteJSON("SaveCostPlanAnalyzerView", sbd.toString(), SaveCostAnalyzerViewCompleteDelegate);
                    break;

                case "RenameView_OK":
                    var renameViewName = document.getElementById("id_RenameView_Name").value;
                    var selectView = document.getElementById("idAnalyzerTab_SelView");
                    var viewGUID;
                    if (selectView.selectedIndex >= 0) {
                        var selectedItem = selectView.options[selectView.selectedIndex];
                        viewGUID = selectedItem.value;
                    }

                    var dataXml = '<View ViewGUID="' + XMLValue(viewGUID) + '" Name="' + XMLValue(renameViewName) + '" />';
                    var sbd = new StringBuilder();
                    sbd.append('<Execute Function="RenameResourcePlanAnalyzerView">');
                    sbd.append(dataXml);
                    sbd.append('</Execute>');

                    WorkEnginePPM.CostAnalyzer.ExecuteJSON("RenameResourceAnalyzerView", sbd.toString(), RenameResourceAnalyzerViewCompleteDelegate);
                    break;

                case "SaveView_Cancel":
                case "RenameView_Cancel":
                    this.AnalyzerViewDlg.window("winAnalyzerViewDlg").setModal(false);
                    this.AnalyzerViewDlg.window("winAnalyzerViewDlg").hide();
                    this.AnalyzerViewDlg.window("winAnalyzerViewDlg").detachObject()
                    this.AnalyzerViewDlg = null;
                    break;

                case "DeleteView_Cancel":
                    this.AnalyzerDeleteViewDlg.window("winAnalyzerDeleteViewDlg").setModal(false);
                    this.AnalyzerDeleteViewDlg.window("winAnalyzerDeleteViewDlg").hide();
                    this.AnalyzerDeleteViewDlg.window("winAnalyzerDeleteViewDlg").detachObject()
                    this.AnalyzerDeleteViewDlg = null;
                    break;


                case "AnalyzerTab_Close":
                    if (SP.UI.DialogResult)
                        SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');
                    else
                        SP.UI.ModalDialog.commonModalDialogClose(0, '');
                    return;


                case "AnalyzerTab_SelectColumns":
                    grid = Grids["g_1"];
                    grid.ActionShowColumns('Selectable');
                    break;

                case "AnalyzerTab_ExpandAll":
                    grid = Grids["g_1"];
                    var bExall = grid.ExpandAll(null, 0, 3);
                    break;

                case "AnalyzerTab_CollapseAll":
                    grid = Grids["g_1"];
                    grid.CollapseAll();
                    break;

                case "AnalyzerTab_SelMode_Changed1":
                    if (this.viewTab.getButtonState("chksFTE") == false && this.viewTab.getButtonState("chksCost") == false)
                        return;

                    if (this.viewTab.getButtonState("chksQuantity") != true)
                        this.viewTab.setButtonStateOn("chksQuantity");
                    else
                        this.viewTab.setButtonStateOff("chksQuantity");

                    this.SetSelectedMode();
                     break;

                case "AnalyzerTab_SelMode_Changed2":
                    if (this.viewTab.getButtonState("chksQuantity") == false && this.viewTab.getButtonState("chksCost") == false)
                        return;

                    if (this.viewTab.getButtonState("chksFTE") != true)
                        this.viewTab.setButtonStateOn("chksFTE");
                    else
                        this.viewTab.setButtonStateOff("chksFTE");

                    this.SetSelectedMode();
                    break;
                case "AnalyzerTab_SelMode_Changed3":
                    if (this.viewTab.getButtonState("chksQuantity") == false && this.viewTab.getButtonState("chksFTE") == false)
                        return;

                    if (this.viewTab.getButtonState("chksCost") != true)
                        this.viewTab.setButtonStateOn("chksCost");
                    else
                        this.viewTab.setButtonStateOff("chksCost");

                    this.SetSelectedMode();
                    break;

                case "AnalyzerTab_SelMode_Changed4":

                    if (this.viewTab.getButtonState("chksCost") != true)
                        return;
                    
                    if (this.viewTab.getButtonState("chksDecCosts") != true)
                        this.viewTab.setButtonStateOn("chksDecCosts");
                    else
                        this.viewTab.setButtonStateOff("chksDecCosts");

                    this.SetSelectedMode();
                    break;

                case "AnalyzerTab_ExporttoExcel":
                    grid = Grids["g_1"];
                    grid.Source.Export.Type = "xls";
                    grid.ActionExport();
                    break;

                case "AnalyzerTab_Print":
                    grid = Grids["g_1"];
                    grid.ActionPrint();
                    break;

                case "TotalTab_Print":
                    grid = Grids["bottomg_1"];
                    grid.ActionPrint();
                    break;



                case "AnalyzerTab_RemoveSorting_Click":
                    grid = Grids["g_1"];
                    grid.ChangeSort("");

                    break;

                case "AnalyzerTab_ShowBars_Click":
                    this.AnalyzerShowBarschecked = !this.AnalyzerShowBarschecked;
                    grid = Grids["g_1"];
                    if (this.AnalyzerShowBarschecked == true) {
                        this.viewTab.setButtonStateOn("idAnalyzerShowBars");
                    } else {
                        this.viewTab.setButtonStateOff("idAnalyzerShowBars");
                    }

                    grid.Render();
                    //this.topgridstash = this.BuildViewInf("guid", "name", false, false, true);
                    //RefreshTopGrid();
                    break;


                case "AnalyzerTab_HideDetails_Click":


                    this.FlashTopGridHideDetails();

                    if (this.AnalyzerHideDetailschecked == true) {
                        this.viewTab.setButtonStateOn("idAnalyzerHideDetails");
                    } else {
                        this.viewTab.setButtonStateOff("idAnalyzerHideDetails");
                    }

                    break;


                case "CTCmpBtn":

                    WorkEnginePPM.CostAnalyzer.ExecuteJSON("GetCompareCostTypeList", "", GetCTListCompleteDelegate);

                    break;

                case "TotalsTab_GridHelpBtn":
                    this.DisplayGridExplaination();
                    break;

                case "TotalsTab_ExporttoExcel":
                    grid = Grids["bottomg_1"];
                    grid.Source.Export.Type = "xls";
                    grid.ActionExport();
                    break;

                case "TotalsTab_TarLegBtn":
                    this.ShowLegend();
                    break;

                case "TargetLegend_OKOnClick":
                    this.dlgShowLegend.window("winShowLegDlg").detachObject()
                    this.dlgShowLegend.window("winShowLegDlg").close();
                    this.dlgShowLegend = null;

                    this.LegendGrid.Dispose();
                    this.LegendGrid = null;
                    break;


                case "TotalsTab_SelectTotalColumns":
                    this.TotGrid.SelectAllRows(0);

                    this.GetTotals();
                    break;

                case "SelectTotals_OK":
                    this.SelectTotals_OKOnClick(1);
                    break;


                case "SelectTotals_Cancel":
                    this.SelectTotals_OKOnClick(0);
                    break;

                case "SelectCTCmp_OK":
                    this.SelectCTCmp(1);
                    break;

                case "SelectCTCmp_Cancel":
                    this.SelectCTCmp(0);
                    break;

                case "TotalsTab_SelectColumns":
                    grid = Grids["bottomg_1"];
                    grid.ActionShowColumns('Selectable');
                    break;
                    break;

                case "TotalsTab_ShowFilters_Click":
                    this.TotalFilterschecked = !this.TotalFilterschecked;
                    grid = Grids["bottomg_1"];
                    if (this.TotalFilterschecked == true) {
                        this.showFilters(grid);
                    } else {
                        this.hideFilters(grid);
                    }
                    break;

                case "TotalsTab_ShowGrouping_Click":
                    this.TotalGroupingchecked = !this.TotalGroupingchecked;
                    grid = Grids["bottomg_1"];
                    if (this.TotalGroupingchecked == true) {
                        this.showGrouping(grid);
                    } else {
                        this.hideGrouping(grid);
                    }
                    grid.Render();
                    break;


                case "TotalsTab_ExpandAll":
                    grid = Grids["bottomg_1"];
                    var bExall = grid.ExpandAll(null, 0, 3);
                    break;

                case "TotalsTab_CollapseAll":
                    grid = Grids["bottomg_1"];
                    grid.CollapseAll();
                    break;

                case "TotalsTab_RemoveSorting_Click":
                    grid = Grids["bottomg_1"];
                    grid.ChangeSort("");

                    break;

                case "DeleteView_OK":


                    var selectView = document.getElementById("idAnalyzerTab_SelView");
                    if (selectView.selectedIndex >= 0) {
                        var selectedItem = selectView.options[selectView.selectedIndex];
                        var deleteViewGuid = selectedItem.value;
                        var sbd = new StringBuilder();
                        sbd.append('<Execute Function="DeleteResourceAnalyzerView">');
                        sbd.append('<View ViewGUID="' + XMLValue(deleteViewGuid) + '" />');
                        sbd.append('</Execute>');

                        WorkEnginePPM.CostAnalyzer.ExecuteJSON("DeleteResourceAnalyzerView", sbd.toString(), DeleteResourceAnalyzerViewCompleteDelegate);
                    }
                    break;

   
                default:
                    alert("unhandled external event - " + event);
                    break;


            }
        }

        catch (e) {
            this.HandleException("externalEvent", e);
        }

    }

    //  <<<< Filters>>>>

    CostAnalyzer.prototype.showFilters = function (grid) {
        grid.ShowRow(grid.GetRowById("Filter"));
        switch (grid.id) {
            case "g_1":
                this.AnalyzerFilterschecked = true;
                this.viewTab.setButtonStateOn("idAnalyzerShowFilters");

                break;
            case "bottomg_1":
                this.TotalFilterschecked = true;
                this.totTab.setButtonStateOn("idTotTab_ShowFilters");
                break;
        }


        var htt;
        var htb;

        htt = this.layout.cells(this.mainArea).getHeight();
        htb = this.layout_totals.cells(this.totalsGridArea).getHeight();

        this.layout_totals.cells(this.totalsGridArea).setHeight(100);
        this.layout.cells(this.mainArea).setHeight(htt / 2);


        this.layout_totals.cells(this.totalsGridArea).setHeight(htb);
        this.layout.cells(this.mainArea).setHeight(htt);
    }


    CostAnalyzer.prototype.FlashTopGridHideDetails = function () {
        var grid = Grids["g_1"];


        var arows = grid.Rows;
        var row = null;

        for (var r in arows) {
            var xrow = arows[r];

            if (xrow.Kind == "Data") {
                if (xrow.firstChild != null) {
                    row = xrow;
                    break;
                }

            }
        }

        if (row == null) {
            this.AnalyzerHideDetailschecked = false;
            for (var r in arows) {
                var yrow = arows[r];

                if (yrow.Kind == "Data")
                    grid.ShowRow(yrow);
            }
            return;
        }

        if (row.firstChild == null) {
            this.AnalyzerHideDetailschecked = false;
            for (var r in arows) {
                var zrow = arows[r];

                if (zrow.Kind == "Data")
                    grid.ShowRow(zrow);
            }
            return;
        }

        this.AnalyzerHideDetailschecked = !this.AnalyzerHideDetailschecked;


        var fc = null;

        if (this.AnalyzerHideDetailschecked == true) {
            for (var r in arows) {
                row = arows[r];

                if (row.Kind == "Data") {
                    fc = row.childNodes.length;

                    if (fc == 0)
                        grid.HideRow(row);
                }
            }
        } else {
            for (var r in arows) {
                row = arows[r];

                if (row.Kind == "Data") {
                    fc = row.childNodes.length;

                    if (fc == 0)
                        grid.ShowRow(row);
                }
            }

        }


        grid.Render();
    }

    CostAnalyzer.prototype.hideFilters = function (grid) {
        grid.HideRow(grid.GetRowById("Filter"));
        switch (grid.id) {
            case "g_1":
                this.AnalyzerFilterschecked = false;
                this.viewTab.setButtonStateOff("idAnalyzerShowFilters");
                break;
            case "bottomg_1":
                this.TotalFilterschecked = false;
                this.totTab.setButtonStateOff("idTotTab_ShowFilters");
                break;

        }

        var htt;
        var htb;

        htt = this.layout.cells(this.mainArea).getHeight();
        htb = this.layout_totals.cells(this.totalsGridArea).getHeight();

        this.layout_totals.cells(this.totalsGridArea).setHeight(100);
        this.layout.cells(this.mainArea).setHeight(htt / 2);


        this.layout_totals.cells(this.totalsGridArea).setHeight(htb);
        this.layout.cells(this.mainArea).setHeight(htt);
    }

    CostAnalyzer.prototype.showGrouping = function (grid) {
        var groupRow = this.getGroupRow(grid);
        if (groupRow != null) {
            groupRow.Visible = 1;
        }
        switch (grid.id) {
            case "g_1":
                this.AnalyzeGroupingchecked = true;
                this.viewTab.setButtonStateOn("idAnalyzerShowGrouping");

                break;
            case "bottomg_1":
                this.TotalGroupingchecked = true;
                this.totTab.setButtonStateOn("idTotTab_ShowGrouping");
                break;
        }
    }

    CostAnalyzer.prototype.getGroupRow = function (grid) {
        var solid = grid.Solid;
        var childrow = solid.firstChild;
        while (childrow != null) {
            if (childrow.Kind === 'Group') {
                return childrow;
            }
            childrow = childrow.nextSibling;
        }
        return null;
    }

    CostAnalyzer.prototype.hideGrouping = function (grid) {
        var groupRow = this.getGroupRow(grid);
        if (groupRow != null) {
            groupRow.Visible = 0;
        }
        switch (grid.id) {
            case "g_1":
                this.AnalyzeGroupingchecked = false;
                this.viewTab.setButtonStateOff("idAnalyzerShowGrouping");
                break;
            case "bottomg_1":
                this.TotalGroupingchecked = false;
                this.totTab.setButtonStateOff("idTotTab_ShowGrouping");
                break;
        }
    }

    CostAnalyzer.prototype.GridsOnUpdated = function (grid) {

        //        var arow = grid.Rows["Filter"];

        //        if (arow == undefined)
        //            return;

        //        if (arow == null)
        //            return;

        //        if (grid.id == "g_1")
        //           grid.ChangeDef(arow, "FilterRow", 1, 0);


    }


    CostAnalyzer.prototype.GridsOnAfterColResize = function (grid, col) {
        if (this.bInColResize == false) {
            this.bInColResize = true;

            if (grid.Cols[col].Sec == 2) {
                var lWidth = grid.GetAttribute(null, col, "Width");
                if (lWidth > 0) {

                    for (var c = 0; c < grid.ColNames[2].length; c++) {
                        var cCol = grid.ColNames[2][c];
                        var cWidth = grid.GetAttribute(null, cCol, "Width");
                        var cVis = grid.GetAttribute(null, cCol, "Visible");
                        if (cWidth > 0 && cVis > 0) {
                            var dx = lWidth - cWidth;
                            if (dx != 0)
                                grid.SetWidth(cCol, dx);
                        }
                    }
                }
            }


            this.bInColResize = false;
        }
    }


    CostAnalyzer.prototype.HandleException = function (sWhere, e) {
        alert("Error " + sWhere + " : " + e.toString());
    }


    CostAnalyzer.prototype.ShowLegend = function () {
        if (this.dlgShowLegend == null) {

            this.dlgShowLegend = new dhtmlXWindows();
            this.dlgShowLegend.setSkin("dhx_web");
            this.dlgShowLegend.enableAutoViewport(false);
            this.dlgShowLegend.attachViewportTo(this.clientID + "mainDiv");
            this.dlgShowLegend.setImagePath(this.imagePath);
            this.dlgShowLegend.createWindow("winShowLegDlg", 20, 30, 405, 315);
            this.dlgShowLegend.window("winShowLegDlg").setIcon("logo.ico", "logo.ico");
            this.dlgShowLegend.window("winShowLegDlg").allowMove();
            this.dlgShowLegend.window("winShowLegDlg").denyResize();
            this.dlgShowLegend.window("winShowLegDlg").setModal(true);
            this.dlgShowLegend.window("winShowLegDlg").center();


            this.dlgShowLegend.window("winShowLegDlg").setText("Legend Key");

            this.dlgShowLegend.window("winShowLegDlg").attachObject("idTargetLegendDlgObj");
            this.dlgShowLegend.window("winShowLegDlg").button("close").disable();
            this.dlgShowLegend.window("winShowLegDlg").button("park").hide();

            var sbDataxml = new StringBuilder();

            sbDataxml = new StringBuilder();
            sbDataxml.append('<![CDATA[');
            sbDataxml.append('<Execute Function="GetLegendKey">');
            sbDataxml.append('</Execute>');
            sbDataxml.append(']]>');

            sb = new StringBuilder();
            sb.append("<treegrid debug='0' sync='0' ");
            sb.append(" data_url='" + this.Webservice + "'");
            sb.append(" data_method='Soap'");
            sb.append(" data_function='Execute'")
            sb.append(" data_namespace='WorkEnginePPM'");
            sb.append(" data_param_Function='GetLegendKey'");
            sb.append(" data_param_Dataxml='" + sbDataxml.toString() + "'");
            sb.append(" >");
            sb.append("</treegrid>");

            this.LegendGrid = TreeGrid(sb.toString(), "idTarLegDiv", "leg_1");


        }
        else
            this.dlgShowLegend.window("winShowLegDlg").show();

    }

    CostAnalyzer.prototype.tabbarOnSelect = function (id, data) {
        if (this.analyzerTab.isCollapsed() == true) {
            this.layout.cells(this.mainRibbonArea).fixSize(false, false);
            this.layout.cells(this.mainRibbonArea).setHeight(120);
            this.layout.cells(this.mainRibbonArea).fixSize(false, true);
            this.analyzerTab.expand();
            this.viewTab.expand();
        }
    }

    CostAnalyzer.prototype.flashRibbonSelect = function (idsel) {
        var select = document.getElementById(idsel);
        var sttx = "";

        if (select != null) {

            if (select.selectedIndex != -1) {

                var selectedopt = select.options[select.selectedIndex];
                if (selectedopt.value != null) {

                    sttx = selectedopt.text;
                }
            }
        }

        var selectText = document.getElementById(idsel + "_textbox");

        if (selectText != null) {
            if (document.all) selectText.innerText = sttx;
            else selectText.textContent = sttx;
        }

    }


    CostAnalyzer.prototype.ribbonGetSelectValue = function (idsel) {
        var select = document.getElementById(idsel);


        if (select != null) {

            if (select.selectedIndex == -1)
                return 0;

            var selectedopt = select.options[select.selectedIndex];
            if (selectedopt.value != null) {

                return parseInt(selectedopt.value);
            }
        }

        return 0;
    }

    CostAnalyzer.prototype.ribbonSetSelectValue = function (idsel, indval) {
        var select = document.getElementById(idsel);


        if (select != null) {


            for (var i = 0; i < select.options.length; i++) {
                if (select.options[i].value == indval) {
                    select.selectedIndex = i;
                    break;
                }
            }

            this.flashRibbonSelect(idsel);
        }
    }



    try {
        // Initialised fields
        this.dlgShowGridEx = null;

        this.TotMaxed = false;
        this.groupColour = 0xF8F8F8;

        this.bapplyDefView = false;

        this.analyzerCalID = 0;
        this.csCalID = 0;

        this.tg_rollup = null;
        this.tg_rollup_render = false;

        this.topgridready = false;
        this.bottomgridready = false;


        this.CTsPresent = null;

        this.bdoingCmp = false;

        this.AnalyzeGroupingchecked = false;
        this.AnalyzerFilterschecked = false;

        this.AnalyzerShowBarschecked = false;
        this.AnalyzerHideDetailschecked = false;

        this.TotalGroupingchecked = false;
        this.TotalFilterschecked = false;

        this.AnalyzerTabisCollapsed = false;
        this.TotalTabisCollapsed = false;

        this.bInColResize = false;
        this.EditCapScen = -1;
        this.SelectedMode = 0;
        this.HaveDragChanges = false;


        this.CostTypeDlg = null;

        this.params = params;
        this.TotSelectedOrder = null;

        this.clientID = this.params.ClientID;
        this.Webservice = params.Webservice;

        this.mainRibbonArea = "a";
        this.mainArea = "b";
        this.totalsArea = "c";
        this.totalsRibbonArea = "a";
        this.totalsGridArea = "b";

        this.analyzerTab = null;
        this.viewTab = null;

        this.TotAddSel = null;
        this.TotRemSel = null;
        this.CSHourMode = null;

        this.dlgShowLegend = null;
        this.LegendGrid = null;

        this.Dirty = false;
        this.initialized = false;
        this.ExitConfirmed = false;
        this.Height = 0;
        this.Width = 0;

        this.layout = null;
        this.layout_totals = null;

        this.TotGrid = null;
        this.DetGrid = null;
        this.TotalsGridSettingsData = null;

        this.FilterDifferent = false;
        this.CSChanged = false;


        this.selectCalendarAndPeriods = null;
        this.imagePath = "/_layouts/ppm/images/";

        // dialog handles

        this.Views = null;
        this.selectedView = null;

        this.SetTotals = null
        this.TotalsLoading = false
        this.TotalsData = null;
        this.tarlev = 0;

        this.SetDetails = null;
        this.DetailsLoading = false
        this.DetailsData = null;
        this.DetailsSettings = "";
        this.DisplayMode = "";

        this.TargetData = null;
        this.TotalsColumnSettings = "";
        this.TotalsGridSupressHeatmap = 0;
        this.TotalsGridTotalsCol = 0;

        this.stashgridsettings = null;

        this.AnalyzerViewDlg = null;
        this.AnalyzerDeleteViewDlg = null;

        this.doTopApply = true;
        this.doBottomApply = true;
        this.CapScens = null;
        this.SelectedCapScen = 0;

        this.dlgEditTarget = null; 
        this.EditGrid = null;
        this.dlgSpreadDlg = null;
        this.csrow = null;
        this.doSetFocus = "";

        this.bottomgriddragstash = null;
        this.topgridstash = null;
        this.CSRoleData = null;

        this.initDataStart = 0;
        this.initDataFinish = 0;

        this.heatmapText = "";
        this.bottomgridbyrole = false;
        this.totTab = null;

        this.selectedHeatMapColour = "1";

        this.deferredhidedetails = false;
        this.CTCmpData = null;


        var loadDelegate = MakeDelegate(this, this.OnLoad);
        //        var unloadDelegate = MakeDelegate(this, this.OnUnload);
        var HandlePingSessionData = MakeDelegate(this, this.HandlePingSession);
        var HandlePopulateUI = MakeDelegate(this, this.PopulateUI);

        this.deferevent = "";
        this.deferedExternalEventDelegate = MakeDelegate(this, this.deferedExternalEvent);
        this.deferedsetFocusDelegate = MakeDelegate(this, this.deferedsetFocus);


        var LoadCostDataCompleteDelegate = MakeDelegate(this, this.LoadCostDataComplete);

        this.GetTotalsDataCompleteDelegate = MakeDelegate(this, this.GetTotalsDataComplete);
        this.SetTotalsDataCompleteDelegate = MakeDelegate(this, this.SetTotalsDataComplete);
        this.CreateTopGridDelegate = MakeDelegate(this, this.CreateTopGrid);

        var GetCTListCompleteDelegate = MakeDelegate(this, this.GetCTListComplete);

        var SaveCostAnalyzerViewCompleteDelegate = MakeDelegate(this, this.SaveCostAnalyzerViewComplete);
        var RenameResourceAnalyzerViewCompleteDelegate = MakeDelegate(this, this.RenameResourceAnalyzerViewComplete);

        this.LastFilterString = "";

        this.FinishTotalsDelegate = MakeDelegate(this, this.FinishTotals);

        var GridsOnGetDefaultColorDelegate = MakeDelegate(this, this.GridsOnGetDefaultColor);
        var GridsOnStartDragCellDelegate = MakeDelegate(this, this.GridsOnStartDragCell);
        var GridsOnMoveDragCellDelegate = MakeDelegate(this, this.GridsOnMoveDragCell);
        var GridsOnEndDragCellDelegate = MakeDelegate(this, this.GridsOnEndDragCell);
        var HandleRefreshBothDelegate = MakeDelegate(this, this.HandleBothRefresh);
        var HandleRefreshTopDelegate = MakeDelegate(this, this.HandleTopRefresh);
        var HandleRefreshDelegate = MakeDelegate(this, this.HandleRefresh);
        var GridsOnAfterValueChangedDelegate = MakeDelegate(this, this.GridsOnAfterValueChanged);
        var GridsOnUpdatedDelegate = MakeDelegate(this, this.GridsOnUpdated);
        var SetChangeViewCompleteDelegate = MakeDelegate(this, this.SetChangeViewComplete);
        var DeleteResourceAnalyzerViewCompleteDelegate = MakeDelegate(this, this.DeleteResourceAnalyzerViewComplete);
        var GridsOnAfterColResizeDelegate = MakeDelegate(this, this.GridsOnAfterColResize);
        var GridsOnClickCellDelegate = MakeDelegate(this, this.GridsOnClickCell);


        GridsOnFilterFinishDelegate = MakeDelegate(this, this.GridsOnFilterFinish);
        var GridsOnReadyDelegate = MakeDelegate(this, this.GridsOnReady);

        this.SetCompareCostTypeListCompleteDelegate = MakeDelegate(this, this.SetCompareCostTypeListComplete);

        var GridsOnValueChangedDelegate = MakeDelegate(this, this.GridsOnValueChanged);
        var AnalyzerViewDlg_OnCloseDelegate = MakeDelegate(this, this.AnalyzerViewDlg_OnClose);
        var AnalyzerDeleteViewDlg_OnCloseDelegate = MakeDelegate(this, this.AnalyzerDeleteViewDlg_OnClose);

        var CostTypeDlg_OnCloseDelegate = MakeDelegate(this, this.CostTypeDlg_OnClose);

        this.CapacityScenarios = null;

        var GridsOnRenderStartDelegate = MakeDelegate(this, this.GridsOnRenderStart);
        var GridsOnRenderFinishDelegate = MakeDelegate(this, this.GridsOnRenderFinish);
        this.refreshIconsInTotGrid = null;
        this.refreshChecksInDetGrid = null;
        var HandleRerenderDelegate = MakeDelegate(this, this.HandleRerender);
        var HandleRerenderChecksDelegate = MakeDelegate(this, this.HandleRerenderChecks);
        var HandleRerenderRollupsDelegate = MakeDelegate(this, this.HandleRerenderRollups);

        this.dragStack = new Array();
        this.dragLevel = 0;

        var tabbarOnSelectDelegate = MakeDelegate(this, this.tabbarOnSelect);

        if (document.addEventListener != null) { // e.g. Firefox
            window.addEventListener("load", loadDelegate, true);
            //            window.addEventListener("beforeunload", unloadDelegate, true);
        }
        else { // e.g. IE
            window.attachEvent("onload", loadDelegate);
            //            window.attachEvent("onbeforeunload", unloadDelegate);
        }
    }
    catch (e) {
        alert("Resource Plan Analyzer Initialization error");
    }


}