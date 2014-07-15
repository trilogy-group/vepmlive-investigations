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
            Grids.OnClick = GridsOnClickDelegate;

            Grids.OnCreateGroup = GridsOnCreateGroupDelegate;

            Grids.OnRenderStart = GridsOnRenderStartDelegate;
            Grids.OnRenderFinish = GridsOnRenderFinishDelegate;



            Grids.OnUpdated = GridsOnUpdatedDelegate;


            WorkEnginePPM.CostAnalyzer.set_path(this.params.Webservice);

            if (this.params.TicketVal == undefined || this.params.TicketVal == "")
                WorkEnginePPM.CostAnalyzer.ExecuteJSON("GetPortfolioItemList", "", GetPortfolioItemListCompleteDelegate);
            else {

                var s = this.BuildLoadInf(this.params.TicketVal, this.params.ViewID);


                WorkEnginePPM.CostAnalyzer.ExecuteJSON("CALoadData", s, LoadCostDataCompleteDelegate);
            }


        }
        catch (e) {
            alert("Cost Analyzer OnLoad Exception");
        }
    }



    CostAnalyzer.prototype.GetPortfolioItemListComplete = function (jsonString) {

        try {

            if (jsonString != null) {

                var jsonObject = JSON_ConvertString(jsonString);
                if (JSON_ValidateServerResult(jsonObject)) {
                    this.PIInfo = jsonObject.Result.IDLists;

                    if (this.PIInfo.IDLIST == "") {

                        alert("You do not have the Permissions to access any Portfolio Items!");

                        if (parent.SP.UI.DialogResult)
                            parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
                        else
                            parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');


                        return;
                    }

                    this.PIList = JSON_GetArray(this.PIInfo.PIS, "PI");
                }


                if (this.selectPIList == null) {
                    this.selectPIList = new dhtmlXWindows();
                    this.selectPIList.setSkin("dhx_web");
                    this.selectPIList.enableAutoViewport(false);
                    this.selectPIList.attachViewportTo(this.params.ClientID + "mainDiv");   // ("layoutDiv");
                    this.selectPIList.setImagePath("/_layouts/ppm/images/");
                    //                   this.selectCalendarAndPeriods.createWindow("winFCandPerDlg", 20, 30, 410, 175);
                    this.selectPIList.createWindow("winSELPIDlg", 20, 30, 410, 270);
                    this.selectPIList.window("winSELPIDlg").setIcon("logo.ico", "logo.ico");
                    this.selectPIList.window("winSELPIDlg").allowMove();
                    this.selectPIList.window("winSELPIDlg").denyResize();
                    this.selectPIList.window("winSELPIDlg").setModal(true);
                    this.selectPIList.window("winSELPIDlg").center();
                    this.selectPIList.window("winSELPIDlg").setText("Select Portfolio Items");
                    this.selectPIList.window("winSELPIDlg").attachObject("idSelectPIDiv");
                    this.selectPIList.window("winSELPIDlg").button("close").disable();
                    this.selectPIList.window("winSELPIDlg").button("park").hide();
                    this.selectPIList.window("winSELPIDlg").button("minmax1").hide();
                    //      this.selectCalendarAndPeriods.window("winFCandPerDlg").hideHeader();




                    var idpilist = document.getElementById('idSelPIDiv');
                    //idpilist.options.length = 0;

                    var shtml = "";

                    for (var i = 0; i < this.PIList.length; i++) {
                        var pid = this.PIList[i].ID;
                        var pname = this.PIList[i].NAME;

                        shtml += '<input id="idSelPIChk' + i + '" type="checkbox" CHECKED />' + pname + '<br />';

                    }

                    idpilist.innerHTML = shtml;

                }
                else
                    this.selectPIList.window("winSELPIDlg").show();




            }

        }

        catch (e) {
            alert("Cost Analyzer GetPortfolioItemListComplete Exception");

            if (parent.SP.UI.DialogResult)
                parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
            else
                parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');

        }



    }


    CostAnalyzer.prototype.GrabSelectedPIs = function () {

        var retval = false;
        var sExtPIs = "";



        for (var i = 0; i < this.PIList.length; i++) {
            var idpilist = document.getElementById('idSelPIChk' + i);
            var pextid = this.PIList[i].EXTID;

            if (idpilist.checked == true) {
                retval = true;

                if (sExtPIs == "")
                    sExtPIs = pextid;
                else
                    sExtPIs = sExtPIs + "," + pextid;
            }

        }

        if (retval == true)
            WorkEnginePPM.CostAnalyzer.ExecuteJSON("GetGeneratedPortfolioItemTicket", sExtPIs, GetGeneratedPortfolioItemTicketCompleteDelegate);
        else
            alert("No Portfolio Items were selected");



        return retval;

    }

    CostAnalyzer.prototype.GetGeneratedPortfolioItemTicketComplete = function (jsonString) {
        try {

            if (jsonString != null) {

                var jsonObject = JSON_ConvertString(jsonString);
                if (JSON_ValidateServerResult(jsonObject)) {
                    var xticket = jsonObject.Result.Ticket.Value;

                    if (xticket == "" || xticket == undefined) {

                        if (parent.SP.UI.DialogResult)
                            parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
                        else
                            parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');


                        return;
                    }

                    this.params.TicketVal = xticket;
                    if (this.params.ViewID == undefined || this.params.ViewID == "")
                        this.params.ViewID = -1;

                    var s = this.BuildLoadInf(this.params.TicketVal, this.params.ViewID);


                    WorkEnginePPM.CostAnalyzer.ExecuteJSON("CALoadData", s, LoadCostDataCompleteDelegate);



                }




            }

        }

        catch (e) {
            alert("Cost Analyzer GetGeneratedPortfolioItemTicketComplete Exception");

            if (parent.SP.UI.DialogResult)
                parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
            else
                parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');

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
        var ssbf = (this.AnalyzerShowBarschecked ? "1" : "0");
        var shdf = (this.AnalyzerHideDetailschecked ? "1" : "0");

        this.SelectDetails_OKOnClick(false);
        this.SetSelectedMode(false);

        var FromList = document.getElementById("idAnalyzerTab_FromPeriod");
        var ToList = document.getElementById("idAnalyzerTab_ToPeriod");

        var StartID = parseInt(FromList.options[FromList.selectedIndex].value);
        var FinishID = parseInt(ToList.options[ToList.selectedIndex].value);
        

        var dataXml = '<View ViewGUID="' + XMLValue(viewGUID) + '" Name="' + XMLValue(viewName) + '" Default="'
                + isViewDefault + '" Personal="' + isViewPersonal + '">'
                + sTopGrid
                + sBottomGrid
                + '<OtherData>'
                + this.DetailsSettings
                + this.ModeSettings
                + this.TotalsColumnSettings
                + '</OtherData>'
                + '<ViewSettings ShowBars="' + ssbf + '" HideDetails="' + shdf + '"';


                if (StartID == -1)
                    dataXml += ' PerInc = "1" FinishPeriod="' + FinishID + '" ';
                else
                    dataXml += ' PerInc = "0" '


                dataXml += '/>' + '</View>';

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



            if (StartID == -1) {
                StartID = this.CurrentPeriod;
            }

            var FinishID = parseInt(ToList.options[ToList.selectedIndex].value);



            for (var i = 0; i < gcols.length; i++) {
                if (gcols[i] == "P1C1") {
                    p1c1ind = i;
                    break;
                }
            }


            if (gridView.LeftCols !== null) {
                var leftCols = gridView.LeftCols.split(',');

                if (gridView.LeftCols != "") {


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
            }


            if (gridView.Cols !== null) {
                var cols = gridView.Cols.split(',');
                if (gridView.Cols != "") {

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



            if (StartID == -1) {
                StartID = this.CurrentPeriod;
            }

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

    CostAnalyzer.prototype.RenameCostAnalyzerViewComplete = function (jsonString) {
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
            this.HandleException("RenameCostAnalyzerViewComplete", e);
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
                this.SetTotals.createWindow("winTotDlg", 20, 30, 600, 500);
                this.SetTotals.window("winTotDlg").setIcon("logo.ico", "logo.ico");
                this.SetTotals.window("winTotDlg").allowMove();
                this.SetTotals.window("winTotDlg").denyResize();
                this.SetTotals.window("winTotDlg").setModal(true);
                this.SetTotals.window("winTotDlg").center();
                this.SetTotals.window("winTotDlg").setText("Totals Column Configuration");
                this.SetTotals.window("winTotDlg").attachObject("idTotalsDlgObj");
                this.SetTotals.window("winTotDlg").button("close").disable();
                this.SetTotals.window("winTotDlg").button("park").hide();
                this.SetTotals.window("winTotDlg").button("minmax1").hide();

                //       document.getElementById("dhxMainCont").style.border = "none";

                this.TotalsLoading = true;

            }
            else
                this.SetTotals.window("winTotDlg").show();



            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {
                this.TotalsData = jsonObject.Result.TotalsConfiguration;


                var selAvail = document.getElementById('idSelTotAvailCols');
                var selSelected = document.getElementById('idSelSelectedCols');
                var chkEnableHeatMap = document.getElementById('idEnableHeatMap');
                var selHeatMap = document.getElementById('idSelHeatmap');
                var selHeatMapColour = document.getElementById('idSelHeatmapColour');

                this.TotSelectedOrder = new Array();

                var titem;

                if (this.TotalsData.SelectedOrderItems.Item.length == undefined)
                    this.TotSelectedOrder[0] = 0;
                else {

                    for (i = 0; i < this.TotalsData.SelectedOrderItems.Item.length; i++) {
                        titem = this.TotalsData.SelectedOrderItems.Item[i];
                        this.TotSelectedOrder[i] = titem.ItemID;
                    }
                }

                this.TotAddSel = null;
                this.TotRemSel = null;

                chkEnableHeatMap.checked = (this.TotalsData.EnableHeatMap.Value == 1);

                window.setTimeout(this.FinishTotalsDelegate, 10);


                //                var selSelected = document.getElementById('idSelSelectedCols');
                //               
                //                selSelected.options.length = 0;

                var topt1 = document.getElementById('toption1');
                var topt2 = document.getElementById('toption2');
                var topt3 = document.getElementById('toption3');
                var topt4 = document.getElementById('toption4');
                var topt5 = document.getElementById('toption5');



                for (var n = 0; n < this.TotalsData.FIELD.length; n++) {
                    var fld = this.TotalsData.FIELD[n];
                    var Id = fld.ID;
                    var Selb = fld.Selected;

                    switch (Id) {
                        case "1":
                            topt1.checked = (Selb == 1);
                            break;
                        case "2":
                            topt2.checked = (Selb == 1);
                            break;
                        case "4":
                            topt3.checked = (Selb == 1);
                            break;
                        case "11":
                            topt4.checked = (Selb == 1);
                            break;
                        case "8":
                            topt5.checked = (Selb == 1);
                            break;

                        default:
                            break;


                    }

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

    CostAnalyzer.prototype.FinishTotals = function () {
        if (this.TotalsLoading == true)
            return;

        var selAvail = document.getElementById('idSelTotAvailCols');
        var selSelected = document.getElementById('idSelSelectedCols');

        var moveupbtn = document.getElementById('idSelectedColsMoveUp');
        var movedownbtn = document.getElementById('idSelectedColsMoveDown');

        var chkEnableHeatMap = document.getElementById('idEnableHeatMap');
        var selHeatMap = document.getElementById('idSelHeatmap');
        var selHeatMapColour = document.getElementById('idSelHeatmapColour');

        this.selectedHeatMapColour = selHeatMapColour;

        selAvail.options.length = 0;
        selSelected.options.length = 0;
        selHeatMap.options.length = 0;


        this.addbtndisabled = (this.TotAddSel == null);
        this.setNewButtonDisable('idTotButtonAdd', this.addbtndisabled);

        this.rembtndisabled = (this.TotRemSel == null);
        this.setNewButtonDisable('idTotButtonRemove', this.rembtndisabled);

        selHeatMap.disabled = !chkEnableHeatMap.checked;
        selHeatMapColour.disabled = !chkEnableHeatMap.checked;

        var i;
        var item;
        var j = 0;

        var temparr = new Array();

        for (i = 0; i < this.TotSelectedOrder.length; i++) {
            temparr[j++] = this.TotSelectedOrder[i];
        }
        this.TotSelectedOrder = temparr;



        n1 = 0;
        var bSel = false;

        var bfound = false;
        var selval;



        for (i = 0; i < this.TotSelectedOrder.length; i++) {
            for (j = 0; j < this.TotalsData.ColumnOptions.ColumnOption.length; j++) {
                item = this.TotalsData.ColumnOptions.ColumnOption[j];
                if (item.ColumnID == this.TotSelectedOrder[i]) {
                    bSel = false;

                    if (this.TotRemSel != null)
                        bSel = (item.ColumnID == this.TotRemSel);

                    bfound |= bSel;

                    if (bSel)
                        selval = n1;

                    selSelected.options[n1] = new Option(item.Name, item.ColumnID, bSel, bSel);

                    if (item.ColumnID == 0) {
                        var opt = selSelected.options[n1];

                        opt.style.color = "#CCCCCC";    // "LightGrey";
                    }

                    ++n1;
                    item.Selected = 1;
                    break;
                }
            }
        }



        if (bfound == false) {
            this.TotRemSel = null;
            moveupbtn.disabled = true;
            movedownbtn.disabled = true;
        }
        else if (selSelected.options.length <= 1) {
            moveupbtn.disabled = true;
            movedownbtn.disabled = true;
        }
        else {

            if (selval == 0) {
                moveupbtn.disabled = true;
                movedownbtn.disabled = false;
            }
            else if (selval == (selSelected.options - 1)) {
                moveupbtn.disabled = false;
                movedownbtn.disabled = true;
            }
            else {
                moveupbtn.disabled = false;
                movedownbtn.disabled = false;
            }
        }
        bfound = false;


        n1 = 0;
        for (j = 0; j < this.TotalsData.ColumnOptions.ColumnOption.length; j++) {
            item = this.TotalsData.ColumnOptions.ColumnOption[j];
            if (item.Selected == 0) {
                bSel = false;



                if (this.TotAddSel != null)
                    bSel = (item.ColumnID == this.TotAddSel);

                bfound |= bSel;

                selAvail.options[n1++] = new Option(item.Name, item.ColumnID, bSel, bSel);
            }
        }

        n1 = 0;

        var usesel = this.TotalsData.EnableHeatField.Value;

        for (i = 0; i < this.TotalsData.ColumnOptions.ColumnOption.length; i++) {
            item = this.TotalsData.ColumnOptions.ColumnOption[i];
            item.Selected = 0;

            if (item.ColumnID != 0) {
                selHeatMap.options[n1++] = new Option(item.Name, item.ColumnID, item.ColumnID == usesel, item.ColumnID == usesel);
            }

        }



        if (bfound == false)
            this.TotAddSel = null;




    }



    CostAnalyzer.prototype.TotalsCols_ButtonClick = function (iDir) {
        var selAvail = document.getElementById('idSelTotAvailCols');
        var selSelected = document.getElementById('idSelSelectedCols');
        var i;
        var j;
        var item;

        if (iDir == 1) {
            var iRemColID;

            for (i = 0; i <= selSelected.options.length - 1; i++) {
                if (selSelected.options[i].selected == true) {
                    if (selSelected.options[i].value == 0) {    // the remove button should be disabled for the totals column - but this is here for belt and braces
                        alert("You cannot remove the Total column from the Selected colulmns");
                        return;
                    }

                    iRemColID = selSelected.options[i].value;

                    if (selSelected.options.length == 2) {
                        this.TotRemSel = null;
                    }
                    else if (i == selSelected.options.length - 1)
                        selSelected.options[i - 1].selected = true;
                    else
                        selSelected.options[i + 1].selected = true;

                    selSelected.remove(i);
                    break;
                }
            }

            for (j = 0; j < this.TotalsData.ColumnOptions.ColumnOption.length; j++) {
                item = this.TotalsData.ColumnOptions.ColumnOption[j];
                if (item.ColumnID == iRemColID) {

                    item.Selected = 0;
                    this.TotAddSel = item.ColumnID;
                    break;
                }
            }

            var temparr = new Array();

            for (i = 0; i <= this.TotSelectedOrder.length - 1; i++) {

                if (this.TotSelectedOrder[i] != iRemColID) {
                    temparr[temparr.length] = this.TotSelectedOrder[i];
                }
            }

            this.TotSelectedOrder = temparr;

            for (i = 0; i <= selSelected.options.length - 1; i++) {

                if (selSelected.options[i].selected == true) {
                    this.TotRemSel = selSelected.options[i].value;
                    break
                }
            }


            window.setTimeout(this.FinishTotalsDelegate, 10);
            return;

        }

        // iDir = 0 - so Add a column to the selected list...

        for (i = 0; i <= selAvail.options.length - 1; i++) {

            if (selAvail.options[i].selected == true) {
                var iAddColID = selAvail.options[i].value;

                if (selAvail.options.length == 1) {
                    this.TotAddSel = null;
                }
                else if (i == selAvail.options.length - 1)
                    selAvail.options[i - 1].selected = true;
                else
                    selAvail.options[i + 1].selected = true;

                selAvail.remove(i);

                for (j = 0; j < this.TotalsData.ColumnOptions.ColumnOption.length; j++) {
                    item = this.TotalsData.ColumnOptions.ColumnOption[j];
                    if (item.ColumnID == iAddColID) {

                        item.Selected == 1;

                        this.TotSelectedOrder[this.TotSelectedOrder.length] = item.ColumnID;

                        this.TotRemSel = item.ColumnID;
                        break;
                    }
                }


                break;
            }
        }

        for (i = 0; i <= selAvail.options.length - 1; i++) {

            if (selAvail.options[i].selected == true) {
                this.TotAddSel = selAvail.options[i].value;
                break
            }
        }


        window.setTimeout(this.FinishTotalsDelegate, 10);
        return;



    }

    CostAnalyzer.prototype.TotalsSelColsMove_ButtonClick = function (iallezup) {
        var selSelected = document.getElementById('idSelSelectedCols');
        var moveupbtn = document.getElementById('idSelectedColsMoveUp');
        var movedownbtn = document.getElementById('idSelectedColsMoveDown');

        var i;
        var selival;
        var swapval;


        for (i = 0; i <= selSelected.options.length; i++) {

            if (selSelected.options[i].selected == true) {
                selival = i;
                break;
            }
        }

        if (iallezup == 1) {
            if (selival == 0)
                return;

            swapval = this.TotSelectedOrder[selival];
            this.TotSelectedOrder[selival] = this.TotSelectedOrder[selival - 1];
            this.TotSelectedOrder[selival - 1] = swapval;
        }
        else {
            if (selival == selSelected.options.length - 1)
                return;

            swapval = this.TotSelectedOrder[selival];
            this.TotSelectedOrder[selival] = this.TotSelectedOrder[selival + 1];
            this.TotSelectedOrder[selival + 1] = swapval;
        }

        window.setTimeout(this.FinishTotalsDelegate, 10);

    }

    CostAnalyzer.prototype.SelectTotals_OKOnClick = function (iApply) {
        if (iApply == 1) {

            var selAvail = document.getElementById('idSelTotAvailCols');
            var selSelected = document.getElementById('idSelSelectedCols');
            var chkEnableHeatMap = document.getElementById('idEnableHeatMap');
            var selHeatMap = document.getElementById('idSelHeatmap');
            var selHeatMapColour = document.getElementById('idSelHeatmapColour');
            var topt1 = document.getElementById('toption1');
            var topt2 = document.getElementById('toption2');
            var topt3 = document.getElementById('toption3');
            var topt4 = document.getElementById('toption4');
            var topt5 = document.getElementById('toption5');


            var sb = new StringBuilder();
            sb.append("<TotalsConfiguration>");



            var sbDataxml = new StringBuilder();
            sbDataxml.append("<EnableHeatMap Value='");
            sbDataxml.append((chkEnableHeatMap.checked ? "1" : "0"));
            sbDataxml.append("'/>");
            sb.append(sbDataxml.toString());

            var sbDataxml = new StringBuilder();
            sbDataxml.append("<EnableHeatField Value='");
            sbDataxml.append(selHeatMap.value);
            sbDataxml.append("'/>");
            sb.append(sbDataxml.toString());

            this.selectedHeatMapColour = selHeatMapColour.value;

            sbDataxml = new StringBuilder();
            sbDataxml.append("<HeatFieldColour Value='");
            sbDataxml.append(selHeatMapColour.value);
            sbDataxml.append("'/>");
            sb.append(sbDataxml.toString());


            var bgotfield = false;


            sbDataxml = new StringBuilder();
            sbDataxml.append("<FIELD ID='1' Selected='" + (topt1.checked ? "1" : "0") + "'/>");
            sb.append(sbDataxml.toString());
            bgotfield |= topt1.checked;


            sbDataxml = new StringBuilder();
            sbDataxml.append("<FIELD ID='2' Selected='" + (topt2.checked ? "1" : "0") + "'/>");
            sb.append(sbDataxml.toString());
            bgotfield |= topt2.checked;

            sbDataxml = new StringBuilder();
            sbDataxml.append("<FIELD ID='4' Selected='" + (topt3.checked ? "1" : "0") + "'/>");
            sb.append(sbDataxml.toString());
            bgotfield |= topt3.checked;

            sbDataxml = new StringBuilder();
            sbDataxml.append("<FIELD ID='11' Selected='" + (topt4.checked ? "1" : "0") + "'/>");
            sb.append(sbDataxml.toString());
            bgotfield |= topt4.checked;

            sbDataxml = new StringBuilder();
            sbDataxml.append("<FIELD ID='8' Selected='" + (topt5.checked ? "1" : "0") + "'/>");
            sb.append(sbDataxml.toString());
            bgotfield |= topt5.checked;


            if (bgotfield == false) {
                alert("You must select at least one file to group on");
                return;
            }


            sbDataxml = new StringBuilder();
            sbDataxml.append("<SelectedOrderItems>");

            this.bdoingCmp == false;

            if (chkEnableHeatMap.checked) {
                var w = selHeatMap.selectedIndex;
                var selected_text = selHeatMap.options[w].text;
                this.heatmapText = selected_text;
                this.bdoingCmp == true

            }
            else
                this.heatmapText = "";

            document.getElementById("idTotCompVal").innerHTML = this.heatmapText;

            var i;
            var j;
            for (i = 0; i < this.TotSelectedOrder.length; i++) {
                sbDataxml.append("<Item ");
                sbDataxml.append("ItemID='");

                j = this.TotSelectedOrder[i];

                if (j == 0) {
                    sbDataxml.append("0");
                    this.TotalsGridTotalsCol = i + 1;


                }
                else
                    sbDataxml.append(j);

                sbDataxml.append("'/>");
            }

            sbDataxml.append("</SelectedOrderItems>");
            sb.append(sbDataxml.toString());

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

            this.FlashTargetMenuStuff();

        }

        this.SetTotals.window("winTotDlg").detachObject();
        this.SetTotals.window("winTotDlg").close();
        this.SetTotals = null;
    }



    CostAnalyzer.prototype.SetTotalsDataComplete = function () {

        try {
            RefreshBottomGrid();
        }

        catch (e) {
            alert("Cost Analyzer  SetTotalsDataComplete error " + e.toString());

        }
    }


    CostAnalyzer.prototype.SetChangeViewComplete = function (jsonString) {

        try {
            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {
                this.CTsPresent = jsonObject.Result.ViewData.CostTypes;
                this.CTsPresent.CostType = JSON_GetArray(this.CTsPresent, "CostType");

                this.ModeSettings = jsonObject.Result.ViewData.DisplayMode;
                //                    this.TotalsGridSettingsData = jsonObject.Result.ViewData.TotalsGridSetting;

                //                    this.TotalsGridSupressHeatmap = this.TotalsGridSettingsData.HeatMap.HeapMapSubCol;
                //                    this.TotalsGridTotalsCol = this.TotalsGridSettingsData.HeatMap.HeapMapTotalsCol;
                this.heatmapText = "";

                try {
                    this.heatmapText = this.heatmapText = jsonObject.Result.ViewData.HeatMapText.Value;
                }
                catch (e) { }

                //                    this.DetailsData = jsonObject.Result.ViewData.WorkDetails;   // the next two lines are needed to flash the proper state of the totals buttons on the top grid 
                this.flashTotalsButtons();
                this.FlashDisplayMode();

                document.getElementById("idTotCompVal").innerHTML = this.heatmapText;
                this.TotalsColumnSettings = jsonObject.Result.ViewData.TotalsConfiguration.Value;

                this.stashgridsettings = null;

                RefreshBothGrids();
            }
        }
        catch (e) {
            alert("Resource Analyzer  SetChangeViewComplete error " + e.toString());

        }
    }


    CostAnalyzer.prototype.SelectDetails_OKOnClick = function (issueServerRequest) {

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

        if (issueServerRequest == false)
            return;

        try {
            this.stashgridsettings = this.BuildViewInf("guid", "name", false, false, true);
        }
        catch (e) {
        }
        WorkEnginePPM.CostAnalyzer.Execute("SetCTDetails", sb.toString());

        RefreshBothGrids();
    }


    CostAnalyzer.prototype.SetSelectedMode = function (issueServerRequest) {
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

            if (issueServerRequest == false)
                return;

            try {
                this.stashgridsettings = this.BuildViewInf("guid", "name", false, false, true);
            }
            catch (e) {
            }
            WorkEnginePPM.CostAnalyzer.Execute("SetDisplayMode", sb.toString());
            this.ShowWorkingPopup("divLoading");
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

            this.stashgridsettings = this.BuildViewInf("guid", "name", false, false, true);
            this.doTopApply = false;
            this.doBottomApply = false;

            if (this.DetGrid != null) {
                //	            this.DetGrid.Reload(null);
                this.DetGrid = Grids["g_1"];
                this.DetGrid.Dispose();
                this.DetGrid = null;



                var sbDataxml = new StringBuilder();
                sbDataxml.append('<![CDATA[');
                sbDataxml.append('<Execute Function="GetCostAnalyzerData">');
                sbDataxml.append('</Execute>');
                sbDataxml.append(']]>');

                var sb = new StringBuilder();
                sb.append("<treegrid  SuppressMessage='3' debug='0' sync='0' ");
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

            }

            this.TotGrid = Grids["bottomg_1"];
            this.TotGrid.Dispose();
            this.TotGrid = null;

            sbDataxml = new StringBuilder();
            sbDataxml.append('<![CDATA[');
            sbDataxml.append('<Execute Function="GetCostAnalyzerTotals">');
            sbDataxml.append('</Execute>');
            sbDataxml.append(']]>');

            sb = new StringBuilder();
            sb.append("<treegrid  SuppressMessage='3' debug='0' sync='0' ");
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
                        tooltip: "Actions",
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
                    addme.disabled = (ct.Sel == false);

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
                        name: "Actions",
                        tooltip: "Actions",
                        columns: [
                            {
                                items: [
                                    { type: "bigbutton", name: "Close", img: "formatmap32x32.png", style: "top: -448px; left: -288px;position:relative;", tooltip: "Close", onclick: "dialogEvent('AnalyzerTab_Close');" }
                                ]
                            }
                        ]
                    },
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
                                    { type: "mediumtext", id: "chksQuantity", name: "Show Quantity", tooltip: "Show Quantity", disabled: true, onclick: "dialogEvent('AnalyzerTab_SelMode_Changed1');" },
                                    { type: "mediumtext", id: "chksFTE", name: "Show FTEs", tooltip: "Show FTEs", disabled: true,  onclick: "dialogEvent('AnalyzerTab_SelMode_Changed2');" },
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
                                    { type: "smallbutton", id: "CreateTargetBtn", name: "Create Target", img: "createview.gif", tooltip: "Create Target", onclick: "dialogEvent('CreateTargetBtn');" },
                                    { type: "smallbutton", id: "EditTargetBtn", name: "Edit Target", img: "editview.gif", tooltip: "Edit Target", onclick: "dialogEvent('EditTargetBtn');" }
                                ]
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "DeleteTargetBtn", name: "Delete Target", img: "delete.gif", tooltip: "Delete Target", onclick: "dialogEvent('DeleteTargetBtn');" },
                                    { type: "smallbutton", id: "CopyTargetBtn", name: "Copy Target", img: "formatmap16x16.png", style: "top: -48px; left: -192px;position:relative;", tooltip: "Copy Target", onclick: "dialogEvent('CopyTargetBtn');" }
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
            //                        { type: "smallbutton", id: "ShowTotChk", name: "Show Remaining", img: "ps16x16.png", style: "top: -112px; left: -64px;position:relative;", tooltip: "Show Totals or Remaining", onclick: "dialogEvent('ShowTotBtn');" },

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

            FromList.options[0] = new Option("Current", -1, this.initDataStart == -1, this.initDataStart == -1);


            for (var n1 = 0; n1 < this.UsingPeriods.Period.length; n1++) {
                var per = this.UsingPeriods.Period[n1];
                var perId = per.perID;
                var perName = per.perName;

                FromList.options[n1 + 1] = new Option(perName, perId, n1 == this.initDataStart, n1 == this.initDataStart);
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

    CostAnalyzer.prototype.ShowWorkingPopup = function (divid) {
        //        var veil = document.getElementById("veil");
        //        veil.style.display = "block";
        var div = $('#' + divid);
        var win = $(window);
        div.css('top', (win.height() - div.height()) / 2);
        div.css('left', (win.width() - div.width()) / 2);
        div.show();
        var veil = $('#veil');
        this.burkka == true;
        veil.show();
    };
    CostAnalyzer.prototype.HideWorkingPopup = function (divid) {
        var div = $('#' + divid);
        div.hide();
        var veil = $('#veil');
        this.burkka = false;
        veil.hide();
    };

    CostAnalyzer.prototype.LoadCostDataComplete = function (result) {
        try {
            var jsonObject = JSON_ConvertString(result);
            if (JSON_ValidateServerResult(jsonObject)) {

                var errors = jsonObject.Result.Error;

                if (errors != undefined) {
                    if (errors != null) {

                        if (errors.Value != "") {

                            alert("Error: " + errors.Value);
                            if (parent.SP.UI.DialogResult)
                                parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
                            else
                                parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');

                            return;
                        }
                    }
                }


                if (jsonObject.Result.Perms.Value == 0) {

                    alert("You do not have the Global Permission set to access this functionality!");

                    if (parent.SP.UI.DialogResult)
                        parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
                    else
                        parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');
                    return;
                }

                this.UsingPeriods = jsonObject.Result.Periods;
                this.CurrentPeriod = this.UsingPeriods.CurrentPeriod.Value;
                this.CTsPresent = jsonObject.Result.CostTypes;
                this.CTsPresent.CostType = JSON_GetArray(this.CTsPresent, "CostType");

                this.TotalsData = jsonObject.Result.TotalsConfiguration;


                this.ModeSettings = jsonObject.Result.DisplayMode;

                this.TargetData = jsonObject.Result.Targets;
                var views = jsonObject.Result.Views;
                this.Views = JSON_GetArray(views, "View");

                //                this.TotalsData = jsonObject.Result.TotalsConfiguration.TotalsConfiguration;

                this.TotalsColumnSettings = jsonObject.Result.TotalsConfiguration.Value;

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
            if (parent.SP.UI.DialogResult)
                parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
            else
                parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');

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

        if (grid.id == "et_1")
            this.EditGrid = grid;
    }


    CostAnalyzer.prototype.HandleRerender = function () {

        if (this.refreshIconsInTotGrid != null) {
            for (var i = 0; i < this.refreshIconsInTotGrid.length; i++) {
                this.TotGrid.RefreshCell(this.refreshIconsInTotGrid[i], "IconFlag");
            }
            this.refreshIconsInTotGrid = null;
        }

    }


    CostAnalyzer.prototype.FlashDisplayMode = function () {
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
        catch (e) { }
    }
    CostAnalyzer.prototype.PopulateUI = function () {

        try {
            this.selectedView = null;


            this.TotalGroupingchecked = false;
            this.TotalFilterschecked = false;


            this.AnalyzerFilterschecked = false;
            this.AnalyzeGroupingchecked = false;

            this.FlashDisplayMode();


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


            if (selectviews.options.length == 0) {
                selectviews.options[selectviews.options.length] = new Option("--No Views--", "-1", false, false);
                this.flashRibbonSelect("idAnalyzerTab_SelView");
            }



            if (this.selectedView != null)
                WorkEnginePPM.CostAnalyzer.ExecuteJSON("ApplyCostAnalyzerViewServerSideSettings", this.selectedView.ViewGUID, this.CreateTopGridDelegate);
            else
                this.CreateTopGridDelegate("");

        }
        catch (e) {
            this.HandleException("PopulateUI", e);
            if (parent.SP.UI.DialogResult)
                parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
            else
                parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');

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


                    this.CTsPresent = jsonObject.Result.ViewData.CostTypes;
                    this.CTsPresent.CostType = JSON_GetArray(this.CTsPresent, "CostType");

                    this.ModeSettings = jsonObject.Result.ViewData.DisplayMode;
                    //this.TotalsGridSettingsData = jsonObject.Result.TotalsGridSetting;

                    //                    this.TotalsGridSupressHeatmap = this.TotalsGridSettingsData.HeatMap.HeapMapSubCol;
                    //                    this.TotalsGridTotalsCol = this.TotalsGridSettingsData.HeatMap.HeapMapTotalsCol;
                    this.heatmapText = "";

                    try {
                        this.heatmapText = jsonObject.Result.ViewData.HeatMapText.Value;

                        this.TotalsGridTotalsCol = jsonObject.Result.ViewData.HeatMapCol.Value;




                    }
                    catch (e) { }

                    //                    this.DetailsData = jsonObject.Result.ViewData.WorkDetails;   // the next two lines are needed to flash the proper state of the totals buttons on the top grid 
                    this.flashTotalsButtons();

                    this.bdoingCmp == (this.heatmapText != "");

                    this.FlashDisplayMode();
                    this.FlashTargetMenuStuff();

                    document.getElementById("idTotCompVal").innerHTML = this.heatmapText;

                    this.TotalsColumnSettings = jsonObject.Result.ViewData.TotalsConfiguration.Value;


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
            sb.append("<treegrid  SuppressMessage='3' debug='0' sync='0' ");
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

            this.initialized = true;
            this.OnResize();
            this.ShowWorkingPopup("divLoading");
        }
        catch (e) {
            this.HandleException("CreateTopGrid", e);
            if (parent.SP.UI.DialogResult)
                parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
            else
                parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');

        }
    }

    CostAnalyzer.prototype.GrabRateTable = function (trow) {
        if (trow.m_rt != 0) {
            for (var i = 0; i < this.CSDataCache.NamedRates.length; i++) {
                if (this.CSDataCache.NamedRates[i].UID == trow.BC_UID)
                    return this.CSDataCache.NamedRates[i].Rate;

            }

        }
        else {
            for (i = 0; i < this.CSDataCache.Categories.length; i++) {
                if (this.CSDataCache.Categories[i].UID == trow.BC_UID)
                    return this.CSDataCache.Categories[i].Rate;
            }

        }


        return null;
    }

    CostAnalyzer.prototype.GetTargetRow = function (Row) {

        var trow = null;

        for (var xi = 0; xi < this.CSTargetCache.targetRows.length; xi++) {
            if (this.CSTargetCache.targetRows[xi].RID == Row.id) {
                trow = this.CSTargetCache.targetRows[xi];
                break;
            }

        }


        return trow;
    }



    CostAnalyzer.prototype.ChangeTargetCostType = function (Row, cat) {

        this.EditGrid = Grids["et_1"];
        var trow;
        trow = this.GetTargetRow(Row);

        if (trow == null)
            return;

        trow.BC_UID = cat.UID
        trow.Cat_Name = cat.Name;
        trow.FullCatName = cat.FullName;
        trow.BC_ROLE_UID = cat.Role_UID;
        trow.Role_Name = cat.Role_Name;
        trow.MC_Val = cat.MC_UID;
        trow.MC_Name = cat.MC_Val;
        trow.sUoM = cat.UoM;


        var rt = this.GrabRateTable(trow);

        var arows = this.EditGrid.Rows;
        var grow = arows[Row];  

        if (rt != null) {
            for (var per = 1; per < trow.zCost.length; per++) {
                if (trow.sUoM == "") {
                    trow.zValue[per].Value = 0;
                }
                else 
                    trow.zCost[per].Value = trow.zValue[per].Value * rt[per].Value;

                if (cat.FTE[per].Value == 0)
                    trow.zFTE[per].Value = 0;
                else
                    trow.zFTE[per].Value = (trow.zValue[per].Value * 100) / cat.FTE[per].Value;


            }

        }

    }

    CostAnalyzer.prototype.HandleTargetEdit = function (Row, Col, value) {

        this.EditGrid = Grids["et_1"];

        if (Col == "Select")
            return;

        if (Col.charAt(0) == "P") {
            var per, sCol, trow;

            sCol = Col.substr(1, Col.length - 2);
            per = parseInt(sCol);

            var trow = null;

            for (var xi = 0; xi < this.CSTargetCache.targetRows.length; xi++) {
                if (this.CSTargetCache.targetRows[xi].RID == Row.id) {
                    trow = this.CSTargetCache.targetRows[xi];
                    break;
                }

            }

            if (trow == null)
                return;


            if (Col.charAt(Col.length - 1) == "C") {
                trow.zCost[per].Value = parseFloat(value);
                return;
            }


            var cat = null;
            for (var j = 0; j < this.CSDataCache.Categories.length; j++) {

                if (this.CSDataCache.Categories[j].UID == trow.BC_UID) {
                    cat = this.CSDataCache.Categories[j];
                    break;
                }
            }

            if (this.etShowingFTEs == true) {
                trow.zFTE[per].Value = parseFloat(value);
                if (cat != null)
                    trow.zValue[per].Value = (parseFloat(value) * cat.FTEConv[per].Value) / 100;
            }
            else
                trow.zValue[per].Value = parseFloat(value);

            var rt = this.GrabRateTable(trow);

            if (rt == null)
                trow.zCost[per].Value = 0;
            else
                trow.zCost[per].Value = trow.zValue[per].Value * rt[per].Value;


            if (cat != null && this.etShowingFTEs == false) {

                if (cat.FTE[per].Value == 0)
                    trow.zFTE[per].Value = 0;
                else
                    trow.zFTE[per].Value = (trow.zValue[per].Value * 100) / cat.FTE[per].Value;

            }


            sCol = Col.substr(0, Col.length - 1) + "C";


            this.EditGrid.SetString(Row, sCol, trow.zCost[per].Value, 1);


            return;
        }

        RefreshTargetGrid();

    }

    CostAnalyzer.prototype.PopulateTargetTexts = function (row, oDet) {

        this.EditGrid = Grids["et_1"];
        this.EditGrid.SetString(row, "CostType", oDet.CT_Name, 1);
        this.EditGrid.SetString(row, "CostCategory", oDet.FullCatName, 1);
        this.EditGrid.SetString(row, "MajorCategory", oDet.MC_Name, 1);
        this.EditGrid.SetString(row, "Role", oDet.Role_Name, 1);
        this.EditGrid.SetString(row, "NamedRate", oDet.m_rt_name, 1);



        for (var i = 0; i < this.CSDataCache.CustomFields.length; i++) {
            var stxt, oc;

            oc = this.CSDataCache.CustomFields[i];

            if (oc.FieldID < 11810)
                stxt = oDet.Text_OCVal[oc.FieldID - 11800].Value;
            else
                stxt = oDet.TXVal[oc.FieldID - 11810].Value;

            this.EditGrid.SetString(row, oc.Name, stxt, 1);

        }


    }

    CostAnalyzer.prototype.FlashTargetData = function () {

        this.EditGrid = Grids["et_1"];

        var trow, grow, cat, xrow;
        var arows = this.EditGrid.Rows;
        var oc;
        var xi;
        var grouping = this.EditGrid.Group;


        for (var i = 0; i < this.CSTargetCache.targetRows.length; i++) {
            trow = this.CSTargetCache.targetRows[i];

            grow = arows[trow.RID]



            this.EditGrid.SetAttribute(grow, "Select", "Type", "Bool", 1);
            this.EditGrid.SetAttribute(grow, "Select", "CanEdit", 1, 1);
            this.EditGrid.SetAttribute(grow, "CostType", "Button", "Defaults", 1, 0);
            this.EditGrid.SetAttribute(grow, "CostCategory", "Button", "Defaults", 1, 0);
            this.EditGrid.SetString(grow, "Select", "0", 1);

            for (xi = 0; xi < this.CSDataCache.CustomFields.length; xi++) {
                oc = this.CSDataCache.CustomFields[xi];

                if (oc.jsonMenu == "") {
                    this.EditGrid.SetAttribute(grow, oc.Name, "Button", "", 1);
                    this.EditGrid.SetAttribute(grow, oc.Name, "CanEdit", 1, 1);
                }
                else {

                    this.EditGrid.SetAttribute(grow, oc.Name, "CanEdit", 0, 1);
                    this.EditGrid.SetAttribute(grow, oc.Name, "Button", "Defaults", 1, 0);
                }

            }





            this.PopulateTargetTexts(grow, trow);

            cat = null;
            for (var j = 0; j < this.CSDataCache.Categories.length; j++) {

                if (this.CSDataCache.Categories[j].UID == trow.BC_UID) {
                    cat = this.CSDataCache.Categories[j];
                    break;
                }
            }

            var qe = 1;
            var ce = 1;


            if (cat != null) {
                if (cat.UoM == "")
                    qe = 0;
                else
                    ce = 0;
            }
            else
                qe = 0;

            for (var per = 1; per <= this.CSDataCache.numberPeriods; per++) {
                var x = "P" + per.toString() + "V";

                this.EditGrid.SetAttribute(grow, x, "CanEdit", qe, 1);

                if (cat != null) {
                    if (this.etShowingFTEs == true) {
                        if (cat.FTE[per].Value != 0)
                            trow.zFTE[per].Value = (trow.zValue[per].Value * 100) / cat.FTE[per].Value;
                        else
                            trow.zFTE[per].Value = 0;
                        this.EditGrid.SetString(grow, x, trow.zFTE[per].Value, 1);
                    }
                    else
                        this.EditGrid.SetString(grow, x, trow.zValue[per].Value, 1);
                }
                else if (trow.bGroupRow == true) {
                    if (this.etShowingFTEs == true)
                        this.EditGrid.SetString(grow, x, trow.zFTE[per].Value, 1);
                    else
                        this.EditGrid.SetString(grow, x, trow.zValue[per].Value, 1);
                }
                else
                    this.EditGrid.SetString(grow, x, 0, 1);

                x = "P" + per.toString() + "C";
                this.EditGrid.SetString(grow, x, trow.zCost[per].Value, 1);
                this.EditGrid.SetAttribute(grow, x, "CanEdit", ce, 1);

            }
        }
        this.EditGrid.DoGrouping(grouping)
        this.EditGrid.Render();
    }



    var RefreshTargetGrid = function () {

        try {


            window.setTimeout(HandleTargetRefreshDelegate, 100);
        }

        catch (e) {
        }
    }

    CostAnalyzer.prototype.HandleTargetRefresh = function () {

        try {
             this.FlashTargetData();
        }
        catch (e) {

        }

    }
    // >>>>>>>>>>>  Grid event handlers

    CostAnalyzer.prototype.GridsOnValueChanged = function (grid, row, col, val) {
        if (grid.id == "et_1") {

            this.EditGrid = Grids["et_1"];
            if (col == "CostCategory") {

                for (i = 0; i < this.CSDataCache.Categories.length; i++) {
                    if (this.CSDataCache.Categories[i].UID == val) {

                        var cat = this.CSDataCache.Categories[i];

                        this.ChangeTargetCostType(row, cat);

                        return cat.FullName;
                    }
                }

                return val;
            }

            if (col == "CostType") {

                trow = this.GetTargetRow(row);

                if (trow == null)
                    return;


                for (i = 0; i < this.CSDataCache.CostTypes.length; i++) {
                    if (this.CSDataCache.CostTypes[i].Id == val) {

                        var ct = this.CSDataCache.CostTypes[i];

                        trow.CT_ID = val;
                        trow.CT_Name = ct.Name;

                        return ct.Name;
                    }
                }

                trow.CT_ID = 0;
                trow.CT_Name = "";

                return "";



            }



            for (i = 0; i < this.CSDataCache.CustomFields.length; i++) {
                var lk, oc;

                oc = this.CSDataCache.CustomFields[i];

                if (oc.Name == col) {
                    trow = this.GetTargetRow(row);

                    if (trow == null)
                        return;



                    if (oc.jsonMenu == "") {
                        trow.TXVal[oc.FieldID - 11810] = val;
                        return val;

                    }

                    for (var xi = 0; xi < oc.LookUps.length; xi++) {
                        lk = oc.LookUps[xi];

                        if (lk.UID == val) {




                            if (oc.FieldID < 11810) {
                                trow.Text_OCVal[oc.FieldID - 11800].Value = lk.Name;
                                trow.OCVal[oc.FieldID - 11800].Value = val;
                            }

                            else {
                                if (oc.UseFullName == 1) {
                                    trow.TXVal[oc.FieldID - 11810].Value = lk.FullName;
                                    return lk.FullName;
                                }
                                else
                                    trow.TXVal[oc.FieldID - 11810].Value = lk.Name;
                            }

                            return lk.Name;
                        }
                    }
                }

            }


        }


        return val;


    }

    CostAnalyzer.prototype.GridsOnAfterValueChanged = function (Grid, Row, Col, value) {
        if (Grid.id == "et_1") {
            this.HandleTargetEdit(Row, Col, value)
            return value;
        }

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


    CostAnalyzer.prototype.GridsOnClick = function (grid, row, col, x, y, event) {

        if (grid.id == "et_1") {
            this.csrow = null;

            if (row.childNodes.length == 0)
                this.csrow = row;

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


        if (grid.id == "et_1") {
            this.csrow = null;
            
            if (row.childNodes.length == 0)
                this.csrow = row;

        }
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
                    if (selectedItem.value == -1)
                        return null;

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

    CostAnalyzer.prototype.DeleteCostAnalyzerViewComplete = function (jsonString) {
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
            if (grid.id == "et_1") {

                this.EditGrid = Grids["et_1"];
                if (this.EditGridInit)
                    this.hideGrouping(grid);

                this.EditGridInit = false;
            }


            if (grid.id == "g_1")
                this.topgridready = true;


            if (grid.id == "bottomg_1") {
                if (this.bottomgridfirstready == false) {
                    this.HideWorkingPopup("divLoading");
                    bottomgridfirstready = true;
                }


                this.bottomgridready = true;
            }

            if (this.bottomgridready == true && this.burkka == true)
                this.HideWorkingPopup("divLoading");

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
                    sb.append("<treegrid  SuppressMessage='3' debug='0' sync='0' ");
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
                else if (this.doTopApply == true) {
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

            if (row.Kind != "Data" || grid.Cols[col] == null)
                return null;

            if (row.childNodes.length > 0)
                return null;  // "rgb(128,128,128)";

            if (col == "MajorCategory" || col == "Role")
                return null;  // "rgb(128,128,128)";

            var bEditable = false;
            var sCanEdit = grid.GetAttribute(row, col, "CanEdit");

            if (sCanEdit == "1")
                bEditable = true;
            else {
                if (typeof (grid.GetAttribute(row, col, "Defaults")) != "undefined")
                    bEditable = true;
            }

            if (bEditable == true) {

                return "rgb(255,255,255)";
            }
            else
                return null;  // "rgb(128,128,128)";

        }

        if (grid.id == "g_1") {

            if (row.id == "Filter")
                return null;

            if (row.Kind == "Data") {

                if (col == "Select") {
                    var xfp = grid.GetValue(row, "xinterenalPeriodMin");
                    var xlp = grid.GetValue(row, "xinterenalPeriodMax");
                    var xtp = this.UsingPeriods.Period.length;   //  grid.GetValue(row, "xinterenalPeriodTotal");

                    var lcn = grid.GetLastCol(2);
                    var nsc = parseInt(lcn.charAt(lcn.length - 1));
                    var xas = "";
                    var cv = grid.GetValue(row, "P1C1HtmlPrefix");

                    if (this.AnalyzerShowBarschecked == false) {


                        if (cv != "") {

                            for (var xo = 1; xo <= nsc; ++xo) {
                                for (var xi = 1; xi <= xtp; ++xi) {

                                    xas = "P" + xi.toString() + "C" + xo.toString();

                                    grid.SetString(row, xas + "HtmlPrefix", "", 1);
                                    grid.SetString(row, xas + "HtmlPostfix", "", 1);
                                }
                            }
                        }

                    }
                    else {
                        if (cv == "") {
                            if (xfp != 0) {
                                for (var xo = 1; xo <= nsc; ++xo) {
                                    for (var xi = 1; xi < xfp; ++xi) {
                                        xas = "P" + xi.toString() + "C" + xo.toString();
                                        grid.SetString(row, xas + "HtmlPrefix", "<font color='black'>", 1);
                                        grid.SetString(row, xas + "HtmlPostfix", "</font>", 1);
                                        //	                            grid.SetString(row, xas + "ClassInner", "", 1);
                                    }
                                }


                                for (var xo = 1; xo <= nsc; ++xo) {
                                    for (var xi = xfp; xi <= xlp; ++xi) {

                                        xas = "P" + xi.toString() + "C" + xo.toString();


                                        //	                                                        if (xfp == xlp)
                                        //	                                                            grid.SetString(row, xas + "ClassInner", "GMngSingleCell", 1);
                                        //	                                                        else if (xi == xfp)
                                        //	                                                            grid.SetString(row, xas + "ClassInner", "GMngLeftCell", 1);
                                        //	                                                        else if (xi == xlp)
                                        //	                                                            grid.SetString(row, xas + "ClassInner", "GMngRightCell", 1);
                                        //	                                                        else
                                        //	                                                            grid.SetString(row, xas + "ClassInner", "GMngMiddleCell", 1);


                                        grid.SetString(row, xas + "HtmlPrefix", "<font color='white'>", 1);
                                        grid.SetString(row, xas + "HtmlPostfix", "</font>", 1);


                                    }
                                }

                                for (var xo = 1; xo <= nsc; ++xo) {
                                    for (var xi = xlp + 1; xi <= xtp; ++xi) {
                                        xas = "P" + xi.toString() + "C" + xo.toString();
                                        grid.SetString(row, xas + "HtmlPrefix", "<font color='black'>", 1);
                                        grid.SetString(row, xas + "HtmlPostfix", "</font>", 1);
                                        //	                            grid.SetString(row, xas + "ClassInner", "", 1);
                                    }
                                }

                            }
                        }
                    }

                }


                if (grid.Cols[col].Sec == 2 && col.substr(0, 1) == "P" && this.AnalyzerShowBarschecked == true) {
                    var fp = grid.GetValue(row, "xinterenalPeriodMin");
                    var lp = grid.GetValue(row, "xinterenalPeriodMax");

                    var stg = col.substr(1);
                    var itg = stg.indexOf("C");

                    var peridtg = parseInt(stg.substr(0, itg));

                    if (peridtg >= fp && peridtg <= lp) {




                        return 0x0072C6;
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


            if (subper == this.TotalsGridTotalsCol) {

                var childrenMaxhmVal = grid.GetValue(row, "X" + s);
                var childrenMinhmVal = grid.GetValue(row, "Y" + s);
                var myhmVal;

                var hmcol = "P" + perid + "H";

                var hmv = grid.GetValue(row, hmcol);
                var cv = grid.GetValue(row, col);


                var retval = this.TargetBackground(cv, hmv);
                var bdoit = false;

                //                if (this.selectedHeatMapColour == 1)
                //                    bdoit = (this.tarlev < childrenMaxhmVal && childrenMaxhmVal != "")
                //                else
                //                    bdoit = (this.tarlev > childrenMinhmVal && childrenMinhmVal != "")


                //                if (bdoit == true) {
                //                    var rowicon = grid.GetString(row, "IconFlag");

                //                    if (rowicon != '/_layouts/ppm/images/Yellow.gif') {

                //                        grid.SetAttribute(row, "IconFlag", null, '/_layouts/ppm/images/Yellow.gif', 1);

                //                        if (this.refreshIconsInTotGrid == null) {
                //                            this.refreshIconsInTotGrid = new Array();
                //                            window.setTimeout(HandleRerenderDelegate, 600);

                //                        }


                //                        this.refreshIconsInTotGrid[this.refreshIconsInTotGrid.length] = row;


                //                    }
                //                }


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

    CostAnalyzer.prototype.GridsOnCreateGroup = function (grid, row, group, col) {
        if (grid.id == "et_1") {
            grid.ExpandAll(null, 0, 3);

            window.setTimeout(HandleExpandAllDelegate, 100);
        }

    }

    CostAnalyzer.prototype.HandleExpandAll = function () {
            this.EditGrid.ExpandAll(null, 0, 3);

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

//        if (this.bdoingCmp == false) {

//            this.totTab.disableItem("ShowTotChk");
//            this.totTab.disableItem("TargetLegend");

//            this.totTab.hideItem("ShowTotChk");
//            this.totTab.hideItem("TargetLegend");
//            return;
//        }


//        this.totTab.showItem("ShowTotChk");
//        this.totTab.showItem("TargetLegend");
//        this.totTab.enableItem("ShowTotChk");
//        this.totTab.enableItem("TargetLegend");

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


            try {
                if (this.selectedView.ViewSettings.PerInc == "1") {
                    var perf = this.selectedView.ViewSettings.FinishPeriod;
                    var pers = this.CurrentPeriod;

                    if (perf < pers)
                        perf = pers;
                    else if (perf > this.UsingPeriods.Period.length)
                        perf = this.UsingPeriods.Period.length

                    this.PerStart = pers;
                    this.PerEnd = perf;

                    document.getElementById("idAnalyzerTab_FromPeriod").selectedIndex = 0;
                    document.getElementById("idAnalyzerTab_ToPeriod").selectedIndex = perf - 1;
                    this.flashRibbonSelect('idAnalyzerTab_FromPeriod');
                    this.flashRibbonSelect('idAnalyzerTab_ToPeriod');
                }
            } catch (e) {
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

            WorkEnginePPM.CostAnalyzer.ExecuteJSON("ApplyCostAnalyzerViewServerSideSettings", this.selectedView.ViewGUID, SetChangeViewCompleteDelegate);
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
        btn.disabled = bstate;

        return;

        //if (bstate == true)
        //    btn.className = "button-new disabledSilver";
        //else
        //    btn.className = "button-new silver";

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

            if (this.CTsPresent != null) {
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

                        this.SelectDetails_OKOnClick(true);

                        this.ShowWorkingPopup("divLoading");
                        return;
                    }

                }

            }

            switch (event) {

                case "Dont_Select_PI":

                    this.selectPIList.window("winSELPIDlg").setModal(false);
                    this.selectPIList.window("winSELPIDlg").hide();
                    this.selectPIList.window("winSELPIDlg").detachObject()
                    this.selectPIList = null;

                    if (parent.SP.UI.DialogResult)
                        parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
                    else
                        parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');

                    return;

                    break;

                case "Select_PI":

                    this.selectPIList.window("winSELPIDlg").setModal(false);
                    this.selectPIList.window("winSELPIDlg").hide();
                    this.selectPIList.window("winSELPIDlg").detachObject()
                    this.selectPIList = null;

                    if (this.GrabSelectedPIs() == false) {
                        if (parent.SP.UI.DialogResult)
                            parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
                        else
                            parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');
                    }

                    //                   WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("GetRAUserCalendarInfo", "", GetCalendarInfoCompleteDelegate);

                    return;

                    break;




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


                    if (fp == -1) {
                        fp = this.CurrentPeriod;

                        if (tp < fp) {
                            tp = fp;

                            this.PerEnd = tp;

                            document.getElementById("idAnalyzerTab_ToPeriod").selectedIndex = tp - 1;
                            this.flashRibbonSelect('idAnalyzerTab_ToPeriod');
                        }
                    }


                    this.PerStart = fp;

                    this.flashGridView("g_1", true);
                    this.flashGridView("bottomg_1", true);
                    break;


                case "AnalyzerTab_ToPeriod_Changed":


                    var fp = this.ribbonGetSelectValue("idAnalyzerTab_FromPeriod");
                    var tp = this.ribbonGetSelectValue("idAnalyzerTab_ToPeriod");

                    if (fp == -1) {
                        fp = this.CurrentPeriod;
                    }

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

                    var view = this.GetSelectedView();
                    if (view != null) {

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
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").button("minmax1").hide();
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
                        if (view != null)
                            document.getElementById("id_SaveView_Name").value = selectedItem.text;

                        var bDefault = false;
                        //    Joe wants the default for default to be off EVEN for the defaiult view 
                        //                       if (view.Default != 0)
                        //                           bDefault = true;
                        document.getElementById("id_SaveView_Default").checked = bDefault;
                        var bPersonal = false;
                        if (view != null) {
                            if (view.Personal != 0)
                                bPersonal = true;
                        }
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
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").button("minmax1").hide();
                    }
                    else {
                        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").show();
                    }
                    break;

                case "AnalyzerTab_DeleteView":
                    document.getElementById("id_DeleteView_Name").value = "";
                    var selectView = document.getElementById("idAnalyzerTab_SelView");

                    var view = this.GetSelectedView();
                    if (view != null) {

                        this.selectedView = view;
                        var selectedItem = selectView.options[selectView.selectedIndex];
                        document.getElementById("id_DeleteView_Name").value = selectedItem.text;
                    }
                    else {
                        alert("No views have been saved to be deleted!");
                        break;
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
                        this.AnalyzerDeleteViewDlg.window("winAnalyzerDeleteViewDlg").button("minmax1").hide();
                    }
                    else {
                        this.ViewDlg.window("winViewDlg").show();
                    }
                    break;

                case "SaveView_OK":
                    var saveViewName = document.getElementById("id_SaveView_Name").value;

                    //TO check entered value is blank or with only space.
                    var val = saveViewName.replace(/^\s+|\s+$/, '');
                    if (val.length == 0) {
                        alert("Please enter a valid view name");
                        break;
                    }
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

                    //TO check entered value is blank or with only space.
                    var val = renameViewName.replace(/^\s+|\s+$/, '');
                    if (val.length == 0) {
                        alert("Please enter a valid view name");
                        break;
                    }
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

                    WorkEnginePPM.CostAnalyzer.ExecuteJSON("RenameCostAnalyzerView", sbd.toString(), RenameCostAnalyzerViewCompleteDelegate);
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
                    if (parent.SP.UI.DialogResult)
                        parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
                    else
                        parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');
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

                    this.SetSelectedMode(true);
                    break;

                case "AnalyzerTab_SelMode_Changed2":
                    if (this.viewTab.getButtonState("chksQuantity") == false && this.viewTab.getButtonState("chksCost") == false)
                        return;

                    if (this.viewTab.getButtonState("chksFTE") != true)
                        this.viewTab.setButtonStateOn("chksFTE");
                    else
                        this.viewTab.setButtonStateOff("chksFTE");

                    this.SetSelectedMode(true);
                    break;
                case "AnalyzerTab_SelMode_Changed3":
                    if (this.viewTab.getButtonState("chksQuantity") == false && this.viewTab.getButtonState("chksFTE") == false)
                        return;

                    if (this.viewTab.getButtonState("chksCost") != true)
                        this.viewTab.setButtonStateOn("chksCost");
                    else
                        this.viewTab.setButtonStateOff("chksCost");

                    this.SetSelectedMode(true);
                    break;

                case "AnalyzerTab_SelMode_Changed4":

                    if (this.viewTab.getButtonState("chksCost") != true)
                        return;

                    if (this.viewTab.getButtonState("chksDecCosts") != true)
                        this.viewTab.setButtonStateOn("chksDecCosts");
                    else
                        this.viewTab.setButtonStateOff("chksDecCosts");

                    this.SetSelectedMode(true);
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

                case "TotalAddCol_Click":
                    if (this.addbtndisabled != true)
                        this.TotalsCols_ButtonClick(0);

                    break;

                case "TotalRemoveCol_Click":

                    if (this.rembtndisabled != true)
                        this.TotalsCols_ButtonClick(1);

                    break;

                case "TotalEnableAdd":
                    var selAvail = document.getElementById('idSelTotAvailCols');


                    this.addbtndisabled = false;
                    this.setNewButtonDisable('idTotButtonAdd', false);


                    for (i = 0; i <= selAvail.options.length - 1; i++) {

                        if (selAvail.options[i].selected == true) {
                            this.TotAddSel = selAvail.options[i].value;
                            break;
                        }
                    }

                    break;

                case "TotalEnableRemove":
                    var selSelected = document.getElementById('idSelSelectedCols');
                    var selival = 0;

                    for (i = 0; i <= selSelected.options.length; i++) {

                        if (selSelected.options[i].selected == true) {
                            selival = i;
                            this.TotRemSel = selSelected.options[i].value;

                            this.rembtndisabled = (selSelected.options[i].value == 0);
                            this.setNewButtonDisable('idTotButtonRemove', this.rembtndisabled);
                            break;
                        }
                    }

                    var moveupbtn = document.getElementById('idSelectedColsMoveUp');
                    var movedownbtn = document.getElementById('idSelectedColsMoveDown');

                    if (selSelected.options.length <= 1) {
                        moveupbtn.disabled = true;
                        movedownbtn.disabled = true;
                    }
                    else {
                        moveupbtn.disabled = false;
                        movedownbtn.disabled = false;
                    }

                    if (selival == 0)
                        moveupbtn.disabled = true;
                    else if (selival = (selSelected.options.length - 1))
                        movedownbtn.disabled = true;

                    break;

                case "TotalSelectMoveUp":

                    this.TotalsSelColsMove_ButtonClick(1);
                    break;

                case "TotalSelectMoveDown":

                    this.TotalsSelColsMove_ButtonClick(0);
                    break;

                case "TotalHeatMap_Click":
                    if (this.TotalsLoading == true)
                        return;


                    var chkEnableHeatMap = document.getElementById('idEnableHeatMap');
                    var selHeatMap = document.getElementById('idSelHeatmap');
                    var selHeatMapColour = document.getElementById('idSelHeatmapColour');
                    selHeatMap.disabled = !chkEnableHeatMap.checked;
                    selHeatMapColour.disabled = !chkEnableHeatMap.checked;

                    break;


                case "DeleteView_OK":


                    var selectView = document.getElementById("idAnalyzerTab_SelView");
                    if (selectView.selectedIndex >= 0) {
                        var selectedItem = selectView.options[selectView.selectedIndex];
                        var deleteViewGuid = selectedItem.value;
                        var sbd = new StringBuilder();
                        sbd.append('<Execute Function="DeleteCostAnalyzerView">');
                        sbd.append('<View ViewGUID="' + XMLValue(deleteViewGuid) + '" />');
                        sbd.append('</Execute>');

                        WorkEnginePPM.CostAnalyzer.ExecuteJSON("DeleteCostAnalyzerView", sbd.toString(), DeleteCostAnalyzerViewCompleteDelegate);
                    }
                    break;

                case "CreateTargetBtn":
                    this.DoingEdit = false;
                    this.DoingDelete = false;
                    this.DoingCopy = false;
                    this.DoingCreate = true;
                    this.SaveAsSet = true;


                    this.GoDoEdit(0, "Create Target");


                    break;

                case "EditTargetBtn":
                    this.DoingEdit = true;
                    this.DoingDelete = false;
                    this.DoingCopy = false;
                    this.DoingCreate = false;
                    this.SaveAsSet = false;
                    WorkEnginePPM.CostAnalyzer.ExecuteJSON("GetTargetList", "", GetTargetsListCompleteDelegate);
                    break;

                case "DeleteTargetBtn":
                    this.DoingEdit = false;
                    this.DoingDelete = true;
                    this.DoingCopy = false;
                    this.DoingCreate = false;
                    this.SaveAsSet = false;
                    WorkEnginePPM.CostAnalyzer.ExecuteJSON("GetTargetList", "", GetTargetsListCompleteDelegate);
                    break;
                case "CopyTargetBtn":
                    this.DoingEdit = false;
                    this.DoingDelete = false;
                    this.DoingCopy = true;
                    this.DoingCreate = false;
                    this.SaveAsSet = true;
                    WorkEnginePPM.CostAnalyzer.ExecuteJSON("GetTargetList", "", GetTargetsListCompleteDelegate);
                    break;

                case "SelectEditTarget_OK":
                    this.EditTargetDone(1);
                    break;

                case "SelectEditTarget_Cancel":
                    this.EditTargetDone(0);
                    break;

                case "SelectDeleteTarget_OK":
                    this.DeleteTargetDone(1);
                    break;

                case "SelectDeleteTarget_Cancel":
                    this.DeleteTargetDone(0);
                    break;

                case "SelectCopyTarget_OK":
                    this.CopyTargetDone(1);
                    break;

                case "SelectCopyTarget_Cancel":
                    this.CopyTargetDone(0);
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


        grid.Render();


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
            case "et_1":
                this.TargetGroupingchecked = true;
                this.EditTab.setButtonStateOn("Grp");
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
            case "et_1":
                this.TargetGroupingchecked = false;
                this.EditTab.setButtonStateOff("Grp");
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
            this.dlgShowLegend.window("winShowLegDlg").button("minmax1").hide();

            var sbDataxml = new StringBuilder();

            sbDataxml = new StringBuilder();
            sbDataxml.append('<![CDATA[');
            sbDataxml.append('<Execute Function="GetLegendKey">');
            sbDataxml.append('</Execute>');
            sbDataxml.append(']]>');

            sb = new StringBuilder();
            sb.append("<treegrid  SuppressMessage='3' debug='0' sync='0' ");
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

    // targets

    CostAnalyzer.prototype.GetTargetsListComplete = function (jsonString) {

        try {


            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {

                this.TargetList = JSON_GetArray(jsonObject.Result.Targets, "Target");
                if (this.TargetList.length != 0) {

                    if (this.DoingEdit == true)
                        this.DoEdit();
                    else if (this.DoingDelete == true)
                        this.DoDelete();
                    else if (this.DoingCopy == true)
                        this.DoCopy();
                    //                    this.DoingCreate = false;
                    return;
                }

            }
        }
        catch (e) {

        }


        if (this.DoingDelete == true)
            alert("No Targets have been defined  or are available to delete");
        else if (this.DoingEdit == false)
            alert("No Targets have been defined or are available to edit");
        else
            alert("No Targets have been defined or are available to copy");
    }


    CostAnalyzer.prototype.DoEdit = function () {
        try {
            if (this.SelectEditDlg == null) {

                this.SelectEditDlg = new dhtmlXWindows();
                this.SelectEditDlg.setSkin("dhx_web");
                this.SelectEditDlg.enableAutoViewport(false);
                this.SelectEditDlg.attachViewportTo(this.clientID + "mainDiv");
                this.SelectEditDlg.setImagePath(this.imagePath);

                this.SelectEditDlg.createWindow("winEditTarDlg", 20, 30, 300, 125);

                this.SelectEditDlg.window("winEditTarDlg").setIcon("logo.ico", "logo.ico");
                this.SelectEditDlg.window("winEditTarDlg").allowMove();
                this.SelectEditDlg.window("winEditTarDlg").denyResize();
                this.SelectEditDlg.window("winEditTarDlg").setModal(true);
                this.SelectEditDlg.window("winEditTarDlg").center();


                this.SelectEditDlg.window("winEditTarDlg").setText("Select which Target to Edit");

                this.SelectEditDlg.window("winEditTarDlg").attachObject("idEditTargetDlgObj");
                this.SelectEditDlg.window("winEditTarDlg").button("close").disable();
                this.SelectEditDlg.window("winEditTarDlg").button("park").hide();
                this.SelectEditDlg.window("winEditTarDlg").button("minmax1").hide();

                var select = document.getElementById('idSelEditTarget');



                for (var n = 0; n < this.TargetList.length; n++) {
                    var Id = this.TargetList[n].ID;
                    var Name = this.TargetList[n].Name;
                    select.options[n] = new Option(Name, Id, n == 0, n == 0);
                }



            }
            else
                this.SelectEditDlg.window("winEditTarDlg").show();
        }

        catch (e) {
            alert("error 1");
        }
    }

    CostAnalyzer.prototype.EditTargetDone = function (iDoEdit) {

        this.SelectEditDlg.window("winEditTarDlg").setModal(false);
        this.SelectEditDlg.window("winEditTarDlg").hide();
        this.SelectEditDlg.window("winEditTarDlg").detachObject()
        this.SelectEditDlg.window("winEditTarDlg").close();
        this.SelectEditDlg = null;

        if (iDoEdit == 1) {
            var editsel = document.getElementById('idSelEditTarget');
            var ID = editsel.options[editsel.selectedIndex].value;
            var sName = editsel.options[editsel.selectedIndex].text;
            this.EditTargetid = ID;
            this.EditTargetsplash = "Edit Target : " + sName;
           // this.GoDoEdit(ID, "Edit Target : " + sName);

            window.setTimeout(this.GoDoEditDeferDelegate, 200);
        }

    }

    CostAnalyzer.prototype.GoDoEditDefer = function () {
        this.GoDoEdit(this.EditTargetid, this.EditTargetsplash);
    }
 
    CostAnalyzer.prototype.DoDelete = function () {
        try {
            if (this.SelectDelDlg == null) {

                this.SelectDelDlg = new dhtmlXWindows();
                this.SelectDelDlg.setSkin("dhx_web");
                this.SelectDelDlg.enableAutoViewport(false);
                this.SelectDelDlg.attachViewportTo(this.clientID + "mainDiv");
                this.SelectDelDlg.setImagePath(this.imagePath);

                this.SelectDelDlg.createWindow("winDelTarDlg", 20, 30, 300, 125);

                this.SelectDelDlg.window("winDelTarDlg").setIcon("logo.ico", "logo.ico");
                this.SelectDelDlg.window("winDelTarDlg").allowMove();
                this.SelectDelDlg.window("winDelTarDlg").denyResize();
                this.SelectDelDlg.window("winDelTarDlg").setModal(true);
                this.SelectDelDlg.window("winDelTarDlg").center();


                this.SelectDelDlg.window("winDelTarDlg").setText("Select which Target to Delete");

                this.SelectDelDlg.window("winDelTarDlg").attachObject("idDeleteTargetDlgObj");
                this.SelectDelDlg.window("winDelTarDlg").button("close").disable();
                this.SelectDelDlg.window("winDelTarDlg").button("park").hide();
                this.SelectDelDlg.window("winDelTarDlg").button("minmax1").hide();

                var select = document.getElementById('idSelDelTarget');



                for (var n = 0; n < this.TargetList.length; n++) {
                    var Id = this.TargetList[n].ID;
                    var Name = this.TargetList[n].Name;
                    select.options[n] = new Option(Name, Id, n == 0, n == 0);
                }



            }
            else
                this.SelectDelDlg.window("winDelTarDlg").show();
        }

        catch (e) {
            alert("error 1");
        }
    }

    CostAnalyzer.prototype.DeleteTargetDone = function (iDoDelete) {
        if (iDoDelete == 1) {
            var delsel = document.getElementById('idSelDelTarget');
            var ID = delsel.options[delsel.selectedIndex].value;
            var sName = delsel.options[delsel.selectedIndex].text;



            this.bottomgriddragstash = this.BuildViewInf("guid", "name", false, false, true);
            this.stashgridsettings = null;
            //            }

            WorkEnginePPM.CostAnalyzer.ExecuteJSON("DeleteTarget", ID.toString(), GetTargetDeleteCompleteDelegate);
        }



        this.SelectDelDlg.window("winDelTarDlg").detachObject()
        this.SelectDelDlg.window("winDelTarDlg").close();
        this.SelectDelDlg = null;

    }

    CostAnalyzer.prototype.GetTargetDeleteComplete = function (jsonString) {

        try {


            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {

                this.heatmapText = jsonObject.Result.HeatMapText.Value;
                document.getElementById("idTotCompVal").innerHTML = this.heatmapText;

            }
        } catch (e) {

        }

        RefreshBottomGrid();


    }

    CostAnalyzer.prototype.DoCopy = function () {
        try {
            if (this.SelectCopyDlg == null) {

                this.SelectCopyDlg = new dhtmlXWindows();
                this.SelectCopyDlg.setSkin("dhx_web");
                this.SelectCopyDlg.enableAutoViewport(false);
                this.SelectCopyDlg.attachViewportTo(this.clientID + "mainDiv");
                this.SelectCopyDlg.setImagePath(this.imagePath);

                this.SelectCopyDlg.createWindow("winCopyTarDlg", 20, 30, 300, 125);

                this.SelectCopyDlg.window("winCopyTarDlg").setIcon("logo.ico", "logo.ico");
                this.SelectCopyDlg.window("winCopyTarDlg").allowMove();
                this.SelectCopyDlg.window("winCopyTarDlg").denyResize();
                this.SelectCopyDlg.window("winCopyTarDlg").setModal(true);
                this.SelectCopyDlg.window("winCopyTarDlg").center();


                this.SelectCopyDlg.window("winCopyTarDlg").setText("Select which Target to Copy");

                this.SelectCopyDlg.window("winCopyTarDlg").attachObject("idCopyTargetDlgObj");
                this.SelectCopyDlg.window("winCopyTarDlg").button("close").disable();
                this.SelectCopyDlg.window("winCopyTarDlg").button("park").hide();
                this.SelectCopyDlg.window("winCopyTarDlg").button("minmax1").hide();

                var select = document.getElementById('idSelCopyTarget');



                for (var n = 0; n < this.TargetList.length; n++) {
                    var Id = this.TargetList[n].ID;
                    var Name = this.TargetList[n].Name;
                    select.options[n] = new Option(Name, Id, n == 0, n == 0);
                }



            }
            else
                this.SelectCopyDlg.window("winCopyTarDlg").show();
        }

        catch (e) {
            alert("error 1");
        }
    }

    CostAnalyzer.prototype.CopyTargetDone = function (iDoEdit) {

        this.SelectCopyDlg.window("winCopyTarDlg").detachObject()
        this.SelectCopyDlg.window("winCopyTarDlg").close();
        this.SelectCopyDlg = null;


        if (iDoEdit) {
            var copysel = document.getElementById('idSelCopyTarget');
            var ID = copysel.options[copysel.selectedIndex].value;
            var sName = copysel.options[copysel.selectedIndex].text;

            this.EditTargetid = ID;
            this.EditTargetsplash = "Copy Target : " + sName;

            window.setTimeout(this.GoDoEditDeferDelegate, 200);

     //       this.GoDoEdit(ID, "Copy Target : " + sName);
        }

    }

    CostAnalyzer.prototype.GoDoEdit = function (id, name) {

        try {



            if (this.dlgEditTarget == null) {
                this.dlgEditTarget = new dhtmlXWindows();
                this.dlgEditTarget.setSkin("dhx_web");
                this.dlgEditTarget.enableAutoViewport(false);
                this.dlgEditTarget.attachViewportTo(this.clientID + "mainDiv");
                this.dlgEditTarget.setImagePath(this.imagePath);



                this.dlgEditTarget.createWindow("winEditTargetDlg", 0, 0, this.Width - 30, this.Height - 50);

                this.dlgEditTarget.window("winEditTargetDlg").setIcon("logo.ico", "logo.ico");
                this.dlgEditTarget.window("winEditTargetDlg").allowMove();
                //		this.dlgEditTarget.window("winEditTargetDlg").allowResize();
                this.dlgEditTarget.window("winEditTargetDlg").setModal(true);
                this.dlgEditTarget.window("winEditTargetDlg").keepInViewport(true);
                this.dlgEditTarget.window("winEditTargetDlg").showHeader();
                this.dlgEditTarget.window("winEditTargetDlg").progressOn();
                this.dlgEditTarget.window("winEditTargetDlg").center();


                this.dlgEditTarget.window("winEditTargetDlg").setText(name);
                this.dlgEditTarget.window("winEditTargetDlg").attachObject("idEditTargetDlg");
                this.dlgEditTarget.window("winEditTargetDlg").button("close").disable();
                this.dlgEditTarget.window("winEditTargetDlg").button("park").hide();
                this.dlgEditTarget.window("winEditTargetDlg").button("minmax1").hide();
                //               this.dlgEditTarget.window("winEditTargetDlg").attachEvent("onFocus", layoutOnResizeFinishDelegate);

                this.EditTargetid = id;

                var TarRibonData = {
                    parent: "ribbonbarEdiTarDiv",
                    style: "display:none;",
                    imagePath: this.imagePath,
                    showstate: "false",
                    sections: [
                     { name: "General",
                         columns: [
                            {
                                items: [
                                    { type: "bigbutton", name: "Close", img: "close32.gif", tooltip: "Close", onclick: "editTargetEvent('etCloseBtn');" }
                                ]
                            },
                            {
                                items: [
                                    { type: "bigbutton", id: "idTargetSave", name: "Save", img: "save32x32.png", tooltip: "Save", onclick: "editTargetEvent('etSaveBtn');" }
                                ]
                            }
                        ]
                     },
                      { name: "Tools",
                          columns: [
                            {
                                items: [
                                     { type: "mediumtext", id: "idTargetFTE", name: "Show FTE", tooltip: "Swap between FTEs and Hours", onclick: "editTargetEvent('Edit_SelMode_Changed');" },
									 { type: "smallbutton", id: "SpreadBtn", name: "Allocate Values", img: "spread.gif", tooltip: "Allocate Values", onclick: "editTargetEvent('etSpread');" },
                                     { type: "smallbutton", id: "LoadUpBtn", name: "Populate Totals", img: "spread.gif", tooltip: "Populate Totals", onclick: "editTargetEvent('etPopBtn');" }
                                ]
                            },
                            {
                                items: [
                                     { type: "smallbutton", id: "TarAppendRow", name: "Append Row", img: "ps16x16.png", style: "top: -128px;left: -64px;position:relative;", tooltip: "Append Row", onclick: "editTargetEvent('etInsBtn');" },
                                     { type: "smallbutton", id: "TarDelRowsBtn", name: "Delete Selected Rows", img: "delete.gif", tooltip: "Delete Selected Rows", onclick: "editTargetEvent('etDelBtn');" },
                                       { type: "smallbutton", id: "Grp", name: "Group Rows", img: "grouping.gif", tooltip: "Group Rows", onclick: "editTargetEvent('etGrpBtn');" }
                              ]
                            }
                        ]
                      }

                 ]
                };



                this.EditTab = new Ribbon(TarRibonData);

                if (this.SaveAsSet)
                    this.EditTab.SetItemName("idTargetSave", "Save As");
                this.EditTab.Render();


                if (this.CSDataCache == null) {

                    WorkEnginePPM.CostAnalyzer.ExecuteJSON("GetClientSideCalcData","",GetClientSideCalcDataCompleteDelegate);
                }
                else {

                    WorkEnginePPM.CostAnalyzer.ExecuteJSON("PrepareTargetData", this.EditTargetid, GetTargetDataCompleteDelegate);
                }

            }
            else
                this.dlgEditTarget.window("winEditTargetDlg").show();
        }

        catch (e) {
            alert("error 1");
        }

    }

    CostAnalyzer.prototype.FlipFTEQtyTargetCostType = function (bFTE) {

        this.EditGrid = Grids["et_1"];
        var trow, grow, cat;
        var arows = this.EditGrid.Rows;
        var hRow = arows["Header"];

        if (this.CSTargetCache.targetRows.length == 0) {

            try {

                var rt = this.CSDataCache.Categories[0].Rate;
                for (var per = 1; per < rt.length; per++) {
                    var x = "P" + per.toString() + "V";

                    if (bFTE == true)
                        this.EditGrid.SetString(hRow, x, " FTE", 1);
                    else
                        this.EditGrid.SetString(hRow, x, " QTY", 1);
                }

                return;

            }
            catch (e) { }
        }


        for (var i = 0; i < this.CSTargetCache.targetRows.length; i++) {
            trow = this.CSTargetCache.targetRows[i];
            grow = arows[trow.RID];

            cat = null;
            for (var j = 0; j < this.CSDataCache.Categories.length; j++) {

                if (this.CSDataCache.Categories[j].UID == trow.BC_UID) {
                    cat = this.CSDataCache.Categories[j];
                    break;
                }
            }

            var rt = this.GrabRateTable(trow);

            if (rt != null) {
                for (var per = 1; per < rt.length; per++) {
                    var x = "P" + per.toString() + "V";

                    if (i == 0) {
                        if (bFTE == true)
                            this.EditGrid.SetString(hRow, x, " FTE", 1);
                        else
                            this.EditGrid.SetString(hRow, x, " QTY", 1);
                    }

                    if (bFTE == true) {
                        if (cat.FTE[per].Value != 0)
                            trow.zFTE[per].Value = (trow.zValue[per].Value * 100) / cat.FTE[per].Value;
                        else
                            trow.zFTE[per] = 0;
                        this.EditGrid.SetString(grow, x, trow.zFTE[per].Value, 1);
                    }
                    else
                        this.EditGrid.SetString(grow, x, trow.zValue[per].Value, 1);

                }
            }
        }
    }



    CostAnalyzer.prototype.GetClientSideCalcDataComplete = function (jsonString) {

        var jsonObject = JSON_ConvertString(jsonString);
        if (JSON_ValidateServerResult(jsonObject)) {

            this.CSDataCache = jsonObject.Result.RatesAndCategories;

            this.CSDataCache.Periods = JSON_GetArray(this.CSDataCache.Periods, "Period");
            this.CSDataCache.Categories = JSON_GetArray(this.CSDataCache.Categories, "Category");
            this.CSDataCache.CostTypes = JSON_GetArray(this.CSDataCache.CostTypes, "CostType");
            this.CSDataCache.CustomFields = JSON_GetArray(this.CSDataCache.CustomFields, "CustomField");
            this.CSDataCache.NamedRates = JSON_GetArray(this.CSDataCache.NamedRates, "NamedRate");


            for (var i = 0; i < this.CSDataCache.Categories.length; i++) {
               var x = this.CSDataCache.Categories[i];

               x.Rate = JSON_GetArray(x, "Rate");
               x.FTE = JSON_GetArray(x, "FTE");
            }

            for (var i = 0; i < this.CSDataCache.CustomFields.length; i++) {
               var x = this.CSDataCache.CustomFields[i];

               x.LookUps = JSON_GetArray(x.LookUps, "LookUp");
            }

       }


        WorkEnginePPM.CostAnalyzer.ExecuteJSON("PrepareTargetData", this.EditTargetid, GetTargetDataCompleteDelegate);
    }
    CostAnalyzer.prototype.GetTargetDataComplete = function (jsonString) {

        try {
            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {

                this.CSTargetCache = jsonObject.Result;
                this.CSTargetCache.targetRows = JSON_GetArray(jsonObject.Result.TargetData, "targetRows");
                for (var i = 0; i < this.CSTargetCache.targetRows.length; i++) {
                    var x = this.CSTargetCache.targetRows[i];
                    
                    x.RID = parseInt(x.RID);
                    this.maxTargetRID = x.RID;
                    
                    x.OCVal = JSON_GetArray(x, "OCVal");
                    x.Text_OCVal = JSON_GetArray(x, "Text_OCVal");
                    x.TXVal = JSON_GetArray(x, "TXVal");

                    x.zCost = JSON_GetArray(x, "zCost");
                    x.zValue = JSON_GetArray(x, "zValue");
                    x.zFTE = JSON_GetArray(x, "zFTE");



                }

                this.etShowingFTEs = false;
            }

        }
        catch (e) { }



        //	    this.ettoolbar = new dhtmlXToolbarObject(this.toolbarEditTargetData);
        //	    this.ettoolbar.attachEvent("onClick", ettoolbarOnClickDelegate);

        //	    this.ettoolbar.hideItem("etQTYBtn");


        //	    document.getElementById('idEditGridDiv').style.height = (this.Height - 120) + "px";
        //	
        



        var sbDataxml = new StringBuilder();
        sbDataxml.append('<![CDATA[');
        sbDataxml.append('<Execute Function="GetTargetGrid">');
        sbDataxml.append('</Execute>');
        sbDataxml.append(']]>');

        var sb = new StringBuilder();
        sb.append("<treegrid  SuppressMessage='3' debug='0' sync='0' ");
        sb.append(" data_url='" + this.Webservice + "'");
        sb.append(" data_method='Soap'");
        sb.append(" data_function='Execute'")
        sb.append(" data_namespace='WorkEnginePPM'");
        sb.append(" data_param_Function='GetTargetGrid'");
        sb.append(" data_param_Dataxml='" + sbDataxml.toString() + "'");
        sb.append(" >");
        sb.append("</treegrid>");

        this.EditGridInit = true;

        this.EditGrid = TreeGrid(sb.toString(), "idEditTargetGridDiv", "et_1");

        this.csrow = null;

        //        var sHTML1 = "<treegrid debug='0' sync='0' layout_url='" + this.Webservice + "' layout_method='Soap' layout_function='GetTargetGridLayout' layout_namespace='WorkEnginePPM' layout_param_Ticket='" + this.TicketVal + "' data_url='" + this.Webservice + "' data_method='Soap' data_function='GetTargetGridData' data_namespace='WorkEnginePPM' data_param_Ticket='" + this.TicketVal + "' ></treegrid>";
        //        this.EditGrid = TreeGrid(sHTML1, "idEditGridDiv", "et_1");


    }

    CostAnalyzer.prototype.CloseEditTarget = function () {

        this.dlgEditTarget.window("winEditTargetDlg").detachObject();
        this.dlgEditTarget.window("winEditTargetDlg").close();
        this.dlgEditTarget = null;



        this.EditGrid.Dispose();
        this.EditGrid = null;


    }


    CostAnalyzer.prototype.TargetDeleteRows = function () {
        this.EditGrid = Grids["et_1"];
        var trow, grow, cat;
        var arows = this.EditGrid.Rows;

        var grouping = this.EditGrid.Group;

        var cnt = 0;
        var dcnt = 0;
        var i;

        for (var i = 0; i < this.CSTargetCache.targetRows.length; i++) {
            trow = this.CSTargetCache.targetRows[i];
            grow = arows[trow.RID];

            if (this.EditGrid.GetString(grow, "Select") != "1")
                cnt++;
            else {
                dcnt++;
            }

        }

        if (dcnt == 0)
            return;

        var narr = new Array(cnt);
        var darr = new Array(dcnt);



        cnt = 0;
        dcnt = 0;


        for (var i = 0; i < this.CSTargetCache.targetRows.length; i++) {
            trow = this.CSTargetCache.targetRows[i];
            grow = arows[trow.RID];


            if (this.EditGrid.GetString(grow, "Select") != "1") {
                narr[cnt++] = trow;
            }
            else {
                darr[dcnt++] = trow;
            }

        }

        this.CSTargetCache.targetRows = narr;

        for (i = 0; i < darr.length; i++) {
            trow = darr[i];
            grow = arows[trow.RID];

            this.EditGrid.RemoveRow(grow);
        }

        // this.FlashTargetData();
        this.EditGrid.DoGrouping(grouping)
        this.EditGrid.Render();


    }

    CostAnalyzer.prototype.CreateNewTargetRow = function () {


        var newobj = new Object();
        var i;

        this.maxTargetRID = this.maxTargetRID + 1;

        newobj.CT_ID = 0;
        newobj.BC_UID = 0;
        newobj.BC_ROLE_UID = 0;
        newobj.BC_SEQ = 0;

        newobj.CAT_UID = 0;
        newobj.m_rt = 0;


        newobj.MC_Val = "";
        newobj.m_rt_name = "";

        newobj.CT_Name = "";
        newobj.Cat_Name = "";
        newobj.Role_Name = "";
        newobj.MC_Name = "";
        newobj.FullCatName = "";
        newobj.CC_Name = "";
        newobj.FullCCName = "";
        newobj.FullCCName = "";
        newobj.sUoM = "";
        newobj.bGroupRow = false;
        newobj.Grouping = "";
        newobj.RID = this.maxTargetRID;


        newobj.OCVal = new Array(6);
        newobj.Text_OCVal = new Array(6);
        newobj.TXVal = new Array(6);

        for (i = 0; i < 6; i++) {
            newobj.OCVal[i] = new Object();
            newobj.Text_OCVal[i] = new Object();
            newobj.TXVal[i] = new Object();

            newobj.OCVal[i].Value = 0;
            newobj.Text_OCVal[i].Value = "";
            newobj.TXVal[i].Value = "";
        }

        var nump = this.CSDataCache.numberPeriods;

        newobj.zCost = new Array(nump);
        newobj.zValue = new Array(nump);
        newobj.zFTE = new Array(nump);

        for (i = 0; i <= nump; i++) {
            newobj.zCost[i] = new Object();
            newobj.zValue[i] = new Object();
            newobj.zFTE[i] = new Object();
            
            newobj.zCost[i].Value = 0.0;
            newobj.zValue[i].Value = 0.0;
            newobj.zFTE[i].Value = 0.0;
        }

        return newobj;
    }

    CostAnalyzer.prototype.SaveTarget = function (sNewName) {


        var sb = new StringBuilder();
        sb.append("<SaveTarget ");

        if (sNewName == "")
            sb.append("ID='" + this.EditTargetid + "' >");
        else
            sb.append("Name='" + sNewName + "' >");

        for (var i = 0; i < this.CSTargetCache.targetRows.length; i++) {
            trow = this.CSTargetCache.targetRows[i];
            var sbDataxml = new StringBuilder();
            sbDataxml.append('<TROW ');
            sbDataxml.append(" CT_ID='" + trow.CT_ID + "'");
            sbDataxml.append(" BC_UID='" + trow.BC_UID + "'");
            sbDataxml.append(" OC1='" + trow.OCVal[1].Value + "'");
            sbDataxml.append(" OC2='" + trow.OCVal[2].Value + "'");
            sbDataxml.append(" OC3='" + trow.OCVal[3].Value + "'");
            sbDataxml.append(" OC4='" + trow.OCVal[4].Value + "'");
            sbDataxml.append(" OC5='" + trow.OCVal[5].Value + "'");
            sbDataxml.append(" TX1='" + trow.TXVal[1].Value + "'");
            sbDataxml.append(" TX2='" + trow.TXVal[2].Value + "'");
            sbDataxml.append(" TX3='" + trow.TXVal[3].Value + "'");
            sbDataxml.append(" TX4='" + trow.TXVal[4].Value + "'");
            sbDataxml.append(" TX5='" + trow.TXVal[5].Value + "'");


            sbDataxml.append('>');

            var nump = this.CSDataCache.numberPeriods;

            for (xi = 0; xi <= nump; xi++) {

                var vc = trow.zCost[xi].Value;
                var vv = trow.zValue[xi].Value;
                
                if (vc != 0 || vv != 0) {
                    sbDataxml.append("<Per ID='" + xi + "'");
                    sbDataxml.append(" Cost='" + vc + "'");
                    sbDataxml.append(" Val='" + vv + "' />");
                }
                

            }

            
            sbDataxml.append('</TROW>');
            sb.append(sbDataxml.toString());


        }

        sb.append("</SaveTarget>");


        WorkEnginePPM.CostAnalyzer.ExecuteJSON("SaveTargetData", sb.toString(), SaveTargetDataCompleteDelegate);


    }




    CostAnalyzer.prototype.SaveTargetDataComplete = function (jsonString) {

        var xTar = 0;
        var jsonObject = JSON_ConvertString(jsonString);
        if (JSON_ValidateServerResult(jsonObject))
            xTar = jsonObject.Result.SaveTarget.Target.Value


        if (xTar == 0) {
            alert("The save failed");
            return;
        }

        if (xTar == -1) {
            alert("A target of that name already exists");
            return;
        }

        alert("Target has been saved");
        this.EditTargetid = xTar;


        this.SaveAsSet = false;
        this.EditTab.SetItemName("idTargetSave", "Save");
        this.EditTab.Render();

        RefreshBottomGrid();
                  
    }

	
    CostAnalyzer.prototype.PopulateTarget = function () {
        WorkEnginePPM.CostAnalyzer.ExecuteJSON("GetTargetTotalsData", "", GetTargetTotalsDataCompleteDelegate);


    }

    CostAnalyzer.prototype.GetTargetTotalsDataComplete = function (jsonString) {

        try {
            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {

                var totals = jsonObject.Result;
                totals.totalRows = JSON_GetArray(jsonObject.Result.TargetTotalData, "totalRows");
                for (var i = 0; i < totals.totalRows.length; i++) {
                    var x = totals.totalRows[i];

                    x.OCVal = JSON_GetArray(x, "OCVal");
                    x.Text_OCVal = JSON_GetArray(x, "Text_OCVal");
                    x.TXVal = JSON_GetArray(x, "TXVal");

                    x.zCost = JSON_GetArray(x, "zCost");
                    x.zValue = JSON_GetArray(x, "zValue");
                    x.zFTE = JSON_GetArray(x, "zFTE");



                }


                this.EditGrid = Grids["et_1"];
                var trow, grow;
                var arows = this.EditGrid.Rows;

                var nump = this.CSDataCache.numberPeriods;
                var i;

                var cnt = 0;


                var narr = new Array(this.CSTargetCache.targetRows.length + 1);

                cnt = 0;


                for (i = 0; i < this.CSTargetCache.targetRows.length; i++) {
                    narr[cnt++] = this.CSTargetCache.targetRows[i];
                }

                for (var xi = 0; xi < totals.totalRows.length; xi++) {
                    var xt = totals.totalRows[xi];

                    trow = this.CreateNewTargetRow();

                    trow.CT_ID = xt.CT_ID;
                    trow.BC_UID = xt.BC_UID;
                    trow.BC_ROLE_UID = xt.BC_ROLE_UID;

                    trow.CAT_UID = xt.CAT_UID;


                    trow.MC_Val = xt.MC_Val;

                    trow.CT_Name = xt.CT_Name;
                    trow.Cat_Name = xt.Cat_Name;
                    trow.Role_Name = xt.Role_Name;
                    trow.MC_Name = xt.MC_Name;
                    trow.FullCatName = xt.FullCatName;
                    trow.CC_Name = xt.CC_Name;
                    trow.FullCCName = xt.FullCCName;
                    trow.sUoM = xt.sUoM;

                    for (i = 0; i < 6; i++) {

                        trow.OCVal[i].Value = xt.OCVal[i].Value;
                        trow.Text_OCVal[i].Value = xt.Text_OCVal[i].Value;
                        trow.TXVal[i].Value = xt.TXVal[i].Value;
                    }

                    var nump = this.CSDataCache.numberPeriods;


                    for (i = 0; i <= nump; i++) {

                        trow.zCost[i].Value = xt.zCost[i].Value;
                        trow.zValue[i].Value = xt.zValue[i].Value;
                        trow.zFTE[i].Value = xt.zFTE[i].Value;
                    }



                    narr[cnt++] = trow;


                    grow = this.EditGrid.AddRow(null, null, true, trow.RID, "Leaf");

                    trow.RID = grow.id;


                    for (i = 1; i <= nump; i++) {
                        var x = "P" + i.toString() + "V";
                        this.EditGrid.SetString(grow, x, 0, 1);
                        this.EditGrid.SetAttribute(grow, x, "CanEdit", 0, 1);


                        x = "P" + i.toString() + "C";
                        this.EditGrid.SetString(grow, x, 0, 1);
                        this.EditGrid.SetAttribute(grow, x, "CanEdit", 1, 1);

                    }
                    grow.NoColorState = 1;



                }
                this.CSTargetCache.targetRows = narr;
                this.FlashTargetData();



            }

        }
        catch (e) { }

    }

    CostAnalyzer.prototype.TargetAddRow = function () {
        this.EditGrid = Grids["et_1"];
        var trow, grow;
        var arows = this.EditGrid.Rows;

        var nump = this.CSDataCache.numberPeriods;
        var i;

        var cnt = 0;


        var narr = new Array(this.CSTargetCache.targetRows.length + 1);

        cnt = 0;


        for (i = 0; i < this.CSTargetCache.targetRows.length; i++) {
            narr[cnt++] = this.CSTargetCache.targetRows[i];
        }

        trow = this.CreateNewTargetRow();
        narr[cnt++] = trow;
        this.CSTargetCache.targetRows = narr;


        grow = this.EditGrid.AddRow(null, null, true, trow.RID, "Leaf");

        grow.NoColorState = 1;


        trow.RID = grow.id;



        for (i = 1; i <= nump; i++) {
            var x = "P" + i.toString() + "V";
            this.EditGrid.SetString(grow, x, 0, 1);
            this.EditGrid.SetAttribute(grow, x, "CanEdit", 0, 1);


            x = "P" + i.toString() + "C";
            this.EditGrid.SetString(grow, x, 0, 1);
            this.EditGrid.SetAttribute(grow, x, "CanEdit", 1, 1);

        }


        this.FlashTargetData();

        this.EditGrid.ScrollIntoView(grow, "Select");
        var btmp;
        btmp = this.EditGrid.Update();
        this.EditGrid.ScrollIntoView(grow, "Select");
     }

    CostAnalyzer.prototype.GetSaveTargetName = function () {
             if (this.dlgSaveTargetAs == null) {
                this.dlgSaveTargetAs = new dhtmlXWindows();
                this.dlgSaveTargetAs.setSkin("dhx_web");
                this.dlgSaveTargetAs.enableAutoViewport(false);
                this.dlgSaveTargetAs.attachViewportTo(this.clientID + "mainDiv");
                this.dlgSaveTargetAs.setImagePath(this.imagePath);



                this.dlgSaveTargetAs.createWindow("winSaveAsTargetDlg", 20, 30, 245, 130);

                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").setIcon("logo.ico", "logo.ico");
                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").allowMove();
                //		this.dlgSaveTargetAs.window("winSaveAsTargetDlg").allowResize();
                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").setModal(true);
                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").keepInViewport(true);
                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").showHeader();
                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").progressOn();
                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").center();


                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").setText(name);
                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").attachObject("idSaveTargetDlg");
                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").button("close").disable();
                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").button("park").hide();
                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").button("minmax1").hide();
                 //               this.dlgSaveTargetAs.window("winSaveAsTargetDlg").attachEvent("onFocus", layoutOnResizeFinishDelegate);


                if (this.DoingCreate)
                    this.dlgSaveTargetAs.window("winSaveAsTargetDlg").setText("Create Target");
                else {
                    this.dlgSaveTargetAs.window("winSaveAsTargetDlg").setText("Create Copy of Target");
                   
                }

                this.DoingEdit = false;
                this.DoingDelete = false;
                this.DoingCopy = false;
                this.DoingCreate = true;

                document.getElementById("txtCostTargetName").value = "";
            }
            else
                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").show();
        }

        CostAnalyzer.prototype.GoDoSpread = function () {

            if (this.csrow == null) {
                alert("No Cost Target detail row has been selected");
                return;
            }

            if (this.dlgSpreadDlg == null) {
                this.dlgSpreadDlg = new dhtmlXWindows();
                this.dlgSpreadDlg.setSkin("dhx_web");
                this.dlgSpreadDlg.enableAutoViewport(false);
                this.dlgSpreadDlg.attachViewportTo(this.clientID + "mainDiv");
                this.dlgSpreadDlg.setImagePath(this.imagePath);

                this.dlgSpreadDlg.createWindow("winSpreadDlg", 20, 30, 275, 245);

                this.dlgSpreadDlg.window("winSpreadDlg").setIcon("logo.ico", "logo.ico");
                this.dlgSpreadDlg.window("winSpreadDlg").allowMove();
                this.dlgSpreadDlg.window("winSpreadDlg").allowResize();
                this.dlgSpreadDlg.window("winSpreadDlg").setModal(true);

                this.dlgSpreadDlg.window("winSpreadDlg").showHeader();
                this.dlgSpreadDlg.window("winSpreadDlg").progressOn();
                this.dlgSpreadDlg.window("winSpreadDlg").center();


                this.dlgSpreadDlg.window("winSpreadDlg").setText("Allocate Hours");
                this.dlgSpreadDlg.window("winSpreadDlg").attachObject("idSpreadDlgObj");
                this.dlgSpreadDlg.window("winSpreadDlg").button("close").disable();
                this.dlgSpreadDlg.window("winSpreadDlg").button("park").hide();
                this.dlgSpreadDlg.window("winSpreadDlg").button("minmax1").hide();

            }
            else
                this.dlgSpreadDlg.window("winSpreadDlg").show();

            var itemName = this.EditGrid.GetString(this.csrow, "CostCategory");


            this.dlgSpreadDlg.window("winSpreadDlg").setText("Allocate " + (this.etShowingFTEs == false ? "Hours" : "FTEs") + " to " + itemName);
            //                dlg.setText("Allocate " + sUnits + " to " + itemName);
            //  



            var sUnits = "";
            var sValue = "";


            if (this.etShowingFTEs == false) {
                sUnits = "Hours";
                sValue = "100";
            }
            else {
                sUnits = "FTE";
                sValue = "1";
            }

            var units = document.getElementById('idSpreadUnits');
            units.innerHTML = sUnits;

            document.getElementById("idSpreadAmount").value = sValue;

            var from = document.getElementById('idSpreadStartPeriod');
            var to = document.getElementById('idSpreadFinishPeriod');

            if (from.options.length == 0) {
                from.options.length = 0;
                to.options.length = 0;

                for (var c = 0; c < this.CSDataCache.Periods.length; c++) {
                    var per = this.CSDataCache.Periods[c];
                    from.options[c] = new Option(per.Name, per.ID);
                    to.options[c] = new Option(per.Name, per.ID);
                }
                from.options.selectedIndex = 0;
                to.options.selectedIndex = to.options.length - 1;
            }
        }

        CostAnalyzer.prototype.spreadDlg_Apply = function () {
            var amount = document.getElementById("idSpreadAmount").value;
            if (isNaN(amount)) {
                alert("Amount : '" + amount + "' is not a number");
                return;
            }
            var copy = document.getElementById("idSpreadCopy").checked;
            //var spread = document.getElementById("idSpreadPeriods").checked;
            var select = document.getElementById("idSpreadStartPeriod");
            startPeriod = parseInt(select.options[select.selectedIndex].value);
            select = document.getElementById("idSpreadFinishPeriod");
            finishPeriod = parseInt(select.options[select.selectedIndex].value);
            var clearPeriods = document.getElementById("idSpreadClearPeriods").checked;


            var grid = this.EditGrid;
            var row = this.csrow;

            var jval = ValidateStringAsNumber(amount, 10, 2, false, "");
            var val = jval.value;
            if (copy == 0)
                val = val / (finishPeriod - startPeriod + 1);


            if (row != null) {

                trow = this.CSTargetCache.targetRows[row.id - 1];
                var rt = this.GrabRateTable(trow);


                var cat = null;
                for (var j = 0; j < this.CSDataCache.Categories.length; j++) {

                    if (this.CSDataCache.Categories[j].UID == trow.BC_UID) {
                        cat = this.CSDataCache.Categories[j];
                        break;
                    }
                }


                var gval;


                for (var per = 1; per <= this.CSDataCache.Periods.length; per++) {
                    fval = cat.FTE[per].Value;


                    var x = "P" + per.toString() + "V";
                    var xc = "P" + per.toString() + "C";

                    if (per < startPeriod && clearPeriods != 0) {
                        trow.zFTE[per - 1].Value = 0;
                        trow.zValue[per - 1].Value = 0;
                        trow.zCost[per - 1].Value = 0;
                        this.EditGrid.SetString(row, x, 0, 1)
                        this.EditGrid.SetString(row, xc, 0, 1)
                    }

                    if (per > finishPeriod && clearPeriods != 0) {
                        trow.zFTE[per - 1].Value = 0;
                        trow.zValue[per - 1].Value = 0;
                        trow.zCost[per - 1].Value = 0;
                        this.EditGrid.SetString(row, x, 0, 1)
                        this.EditGrid.SetString(row, xc, 0, 1)
                    }



                    if (per >= startPeriod && per <= finishPeriod) {
                        gval = val;

                        if (this.etShowingFTEs == false) {
                            if (fval != 0)
                                trow.zFTE[per - 1].Value = val / fval;
                            else
                                trow.zFTE[per - 1].Value = 0;

                            trow.zValue[per - 1].Value = val;
                        }
                        else {
                            trow.zValue[per - 1].Value = val * fval;
                            if (fval != 0)
                                trow.zFTE[per - 1].Value = val;
                            else {
                                gval = 0;
                                trow.zFTE[per - 1].Value = 0;
                            }
                        }
                        this.EditGrid.SetString(row, x, gval, 1)

                        gval = trow.zValue[per - 1].Value * rt[per].Value;

                        trow.zCost[per - 1].Value = gval;
                        this.EditGrid.SetString(row, xc, gval, 1)

                    }

                }
            }
        }



        CostAnalyzer.prototype.edittTargetEvent = function (id, data) {
            this.EditGrid = Grids["et_1"];


            if (id == "Edit_SelMode_Changed") {

                if (this.EditTab.getButtonState("idTargetFTE") != true) {
                    this.EditTab.setButtonStateOn("idTargetFTE");
                    this.FlipFTEQtyTargetCostType(true);
                    this.etShowingFTEs = true;
                } else {
                    this.EditTab.setButtonStateOff("idTargetFTE");
                    this.FlipFTEQtyTargetCostType(false);
                    this.etShowingFTEs = false;
                }


            }

            if (id == "etCloseBtn") {
                this.CloseEditTarget();
            } else if (id == "etSaveBtn" && this.SaveAsSet == true) {
                this.GetSaveTargetName();
            } else if (id == "etSaveBtn") {
                this.SaveTarget("");
            } else if (id == "etPopBtn") {
                this.PopulateTarget();
            } else if (id == "etTestBtn") {
                this.ChangeTargetCostType(13, 3);
            } else if (id == "etInsBtn") {

                this.TargetAddRow();
            } else if (id == "etDelBtn") {
                this.TargetDeleteRows();
            } else if (id == "etGrpBtn") {
                if (this.TargetGroupingchecked == false)
                    this.showGrouping(this.EditGrid);
                else {
                    this.hideGrouping(this.EditGrid);

                }

                this.EditGrid.Render();
            } else if (id == "etSpread") {
                this.GoDoSpread();
            } else if (id == "etSaveAs_Cancel") {
                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").detachObject();
                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").close();
                this.dlgSaveTargetAs = null;

            } else if (id == "etSaveAs_OK") {


                var sname = document.getElementById("txtCostTargetName").value;

                if (sname == "") {
                    alert("You must enter a Cost Target Name value");
                    return;
                }


                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").detachObject();
                this.dlgSaveTargetAs.window("winSaveAsTargetDlg").close();
                this.dlgSaveTargetAs = null;
                this.dlgEditTarget.window("winEditTargetDlg").setText("Edit Target : " + sname);

  
                this.SaveTarget(sname);

                
            } else if (id == "spreadDlg_Close") {


                this.dlgSpreadDlg.window("winSpreadDlg").setModal(false);
                this.dlgSpreadDlg.window("winSpreadDlg").hide();
                this.dlgSpreadDlg.window("winSpreadDlg").detachObject();
                this.dlgSpreadDlg = null;

            }
            else if (id == "spreadDlg_Apply")
            {

                this.spreadDlg_Apply();

            }
        }

    try {
        // Initialised fields
        this.dlgShowGridEx = null;
        this.SelectEditDlg = null;
        this.SelectCopyDlg = null;
        this.dlgEditTarget = null;
        this.dlgSaveTargetAs = null;
        this.selectPIList = null;

        this.SaveAsSet = false;

        this.maxTargetRID = 0;

        this.EditGridInit = false;
        this.TargetGroupingchecked = false;

        this.CSDataCache = null;

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
        this.bottomgridfirstready = false;

        this.burkka = false;



        var GetPortfolioItemListCompleteDelegate = MakeDelegate(this, this.GetPortfolioItemListComplete);
        var GetGeneratedPortfolioItemTicketCompleteDelegate = MakeDelegate(this, this.GetGeneratedPortfolioItemTicketComplete);
        
        var loadDelegate = MakeDelegate(this, this.OnLoad);
        //        var unloadDelegate = MakeDelegate(this, this.OnUnload);
        var HandlePingSessionData = MakeDelegate(this, this.HandlePingSession);
        var HandlePopulateUI = MakeDelegate(this, this.PopulateUI);

        this.deferevent = "";
        this.deferedExternalEventDelegate = MakeDelegate(this, this.deferedExternalEvent);
        this.deferedsetFocusDelegate = MakeDelegate(this, this.deferedsetFocus);

        this.TotalsDataXML = "";
        var LoadCostDataCompleteDelegate = MakeDelegate(this, this.LoadCostDataComplete);

        this.GetTotalsDataCompleteDelegate = MakeDelegate(this, this.GetTotalsDataComplete);
        this.SetTotalsDataCompleteDelegate = MakeDelegate(this, this.SetTotalsDataComplete);
        this.CreateTopGridDelegate = MakeDelegate(this, this.CreateTopGrid);
        this.GoDoEditDeferDelegate = MakeDelegate(this, this.GoDoEditDefer);

        var SaveCostAnalyzerViewCompleteDelegate = MakeDelegate(this, this.SaveCostAnalyzerViewComplete);
        var RenameCostAnalyzerViewCompleteDelegate = MakeDelegate(this, this.RenameCostAnalyzerViewComplete);

        this.LastFilterString = "";

        this.FinishTotalsDelegate = MakeDelegate(this, this.FinishTotals);

        var GetClientSideCalcDataCompleteDelegate = MakeDelegate(this, this.GetClientSideCalcDataComplete);
        var GetTargetDataCompleteDelegate = MakeDelegate(this, this.GetTargetDataComplete);

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
        var DeleteCostAnalyzerViewCompleteDelegate = MakeDelegate(this, this.DeleteCostAnalyzerViewComplete);
        var GridsOnAfterColResizeDelegate = MakeDelegate(this, this.GridsOnAfterColResize);
        var GridsOnClickCellDelegate = MakeDelegate(this, this.GridsOnClickCell);
        var GridsOnCreateGroupDelegate = MakeDelegate(this, this.GridsOnCreateGroup);
        var HandleExpandAllDelegate = MakeDelegate(this, this.HandleExpandAll);
        var GetTargetTotalsDataCompleteDelegate = MakeDelegate(this, this.GetTargetTotalsDataComplete);
        var GridsOnClickDelegate = MakeDelegate(this, this.GridsOnClick);
        SaveTargetDataCompleteDelegate = MakeDelegate(this, this.SaveTargetDataComplete);
        

        this.DoingEdit = false;
        this.DoingDelete = false;
        this.DoingCopy = false;
        this.DoingCreate = false;
        this.SelectDelDlg = null;

        var GetTargetsListCompleteDelegate = MakeDelegate(this, this.GetTargetsListComplete);

        var GridsOnFilterFinishDelegate = MakeDelegate(this, this.GridsOnFilterFinish);
        var GridsOnReadyDelegate = MakeDelegate(this, this.GridsOnReady);

        var GetTargetDeleteCompleteDelegate = MakeDelegate(this, this.GetTargetDeleteComplete);


        var GridsOnValueChangedDelegate = MakeDelegate(this, this.GridsOnValueChanged);
        var AnalyzerViewDlg_OnCloseDelegate = MakeDelegate(this, this.AnalyzerViewDlg_OnClose);
        var AnalyzerDeleteViewDlg_OnCloseDelegate = MakeDelegate(this, this.AnalyzerDeleteViewDlg_OnClose);

        this.CapacityScenarios = null;

        var GridsOnRenderStartDelegate = MakeDelegate(this, this.GridsOnRenderStart);
        var GridsOnRenderFinishDelegate = MakeDelegate(this, this.GridsOnRenderFinish);
        this.refreshIconsInTotGrid = null;
        this.refreshChecksInDetGrid = null;
        var HandleRerenderDelegate = MakeDelegate(this, this.HandleRerender);
        var HandleRerenderChecksDelegate = MakeDelegate(this, this.HandleRerenderChecks);
        var HandleRerenderRollupsDelegate = MakeDelegate(this, this.HandleRerenderRollups);
        var HandleTargetRefreshDelegate = MakeDelegate(this, this.HandleTargetRefresh);

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