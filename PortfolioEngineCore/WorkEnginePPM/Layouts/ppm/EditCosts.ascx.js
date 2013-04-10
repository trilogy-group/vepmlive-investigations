function EditCosts(thisID, params) {
    var MakeDelegate = function (target, method) {
        if (method == null) {
            throw ("Method not found");
        }

        return function () {
            return method.apply(target, arguments);
        };
    };
    EditCosts.prototype.UpdateButtonsAsync = function () {
        window.setTimeout(thisID + ".HandleButtons()", 100);
    };
    EditCosts.prototype.IsReferenceGrid = function (idname) {
        // ids in form of g_1
        var s = idname.split("_");
        if (s[0] == "bottomg") return true; else return false;
    };
    EditCosts.prototype.GetRootIdFromIdName = function (idname) {
        // ids in form of g_1
        var s = idname.split("_");
        return s[1];
    };
    EditCosts.prototype.GetCostTypeFromId = function (id) {
        for (var n = 0; n < this.CostTypes.length; n++) {
            var costtypeId = this.CostTypes[n].Id;
            if (costtypeId == id)
                return this.CostTypes[n];
        }
        return null;
    };
    EditCosts.prototype.OnLoad = function (event) {
        try {
            Grids.OnValueChanged = GridsOnValueChangedDelegate;
            Grids.OnAfterValueChanged = GridsOnAfterValueChangedDelegate;
            Grids.OnAfterSave = GridsOnAfterSaveDelegate;
            Grids.OnSelect = GridsOnSelectDelegate;
            Grids.OnReady = GridsOnReadyDelegate;
            Grids.OnRenderFinish = GridsOnRenderFinishDelegate;
            Grids.OnClickCell = GridsOnClickCellDelegate;
            Grids.OnFocus = GridsOnFocusDelegate;
            Grids.OnAfterColResize = GridsOnAfterColResizeDelegate;
            Grids.OnGetDefaultColor = GridsOnGetDefaultColorDelegate;

            WorkEnginePPM.EditCosts.set_path(this.params.Webservice);
            WorkEnginePPM.EditCosts.CheckStatus("", CheckStatusCompleteDelegate);
        }
        catch (e) {
            alert("catch");
        }
    };
    EditCosts.prototype.ShowWorkingPopup = function (divid) {
        var div = $('#' + divid);
        var win = $(window);
        div.css('top', (win.height() - div.height()) / 2);
        div.css('left', (win.width() - div.width()) / 2);
        div.show();
        var veil = $('#veil');
        veil.show();
    };
    EditCosts.prototype.HideWorkingPopup = function (divid) {
        var div = $('#' + divid);
        div.hide();
        var veil = $('#veil');
        veil.hide();
    };
    EditCosts.prototype.OnCheckStatusComplete = function (result) {
        var s = result.toString();
        if (s != "") {
            alert(s);
            window.setTimeout("parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');", 100);
            return;
        }
        if ((this.params.ProjectID <= 0 && this.params.WEPID == "") || this.params.ViewUID <= 0)
            this.GetPIAndView();
        else {
            WorkEnginePPM.EditCosts.GetCostTypes(this.params.ViewUID, getCostTypesCompleteDelegate);
        }
    };
    EditCosts.prototype.OnBeforeUnload = function (event) {
        if (this.Dirty && this.ExitConfirmed == false)
            event.returnValue = "You have unsaved changes.\n\nAre you sure you want to exit without saving?";
        this.ExitConfirmed = false;
    };
    EditCosts.prototype.OnUnload = function (event) {
        if (this.DoneCheckIn == false && this.CostTypes != null) {
            for (var n = 0; n < this.CostTypes.length; n++) {
                var g = Grids["g_" + this.CostTypes[n].Id];
                if (g != null) {
                    if (g.CostsAreEditable == 1) {
                        WorkEnginePPM.EditCosts.CheckInPI(this.params.ProjectID, this.params.WEPID);
                    }
                }
            }
            this.DoneCheckIn = true;
        }
    };
    EditCosts.prototype.GetPIAndView = function () {
        if (this.selectPIAndViewDlg == null) {
            this.selectPIAndViewDlg = new dhtmlXWindows();
            this.selectPIAndViewDlg.enableAutoViewport(false);
            this.selectPIAndViewDlg.attachViewportTo(this.params.ClientID + "layoutDiv");
            this.selectPIAndViewDlg.setImagePath("/_layouts/ppm/images/");
            this.selectPIAndViewDlg.createWindow("winPIAndViewDlg", 20, 30, 400, 150);
            this.selectPIAndViewDlg.window("winPIAndViewDlg").setIcon("logo.ico", "logo.ico");
            this.selectPIAndViewDlg.window("winPIAndViewDlg").denyMove();
            this.selectPIAndViewDlg.window("winPIAndViewDlg").denyResize();
            this.selectPIAndViewDlg.window("winPIAndViewDlg").setModal(true);
            this.selectPIAndViewDlg.window("winPIAndViewDlg").center();
            this.selectPIAndViewDlg.window("winPIAndViewDlg").setText("Select Portfolio Item and View");
            this.selectPIAndViewDlg.window("winPIAndViewDlg").attachObject("idPIAndViewDlgObj");
            this.selectPIAndViewDlg.window("winPIAndViewDlg").button("close").disable();
            this.selectPIAndViewDlg.window("winPIAndViewDlg").button("park").hide();
            WorkEnginePPM.EditCosts.GetPIList(GetPIListCompleteDelegate);
            WorkEnginePPM.EditCosts.GetViewList(GetViewListCompleteDelegate);
        }
        else
            this.selectPIAndViewDlg.window("winPIAndViewDlg").show();
    };
    EditCosts.prototype.GetPIListComplete = function (result) {
        var PIList = document.getElementById('idPIList');
        PIList.options.length = 0;
        for (var n = 0; n < result.length; n++) {
            var Id = result[n].Id;
            var Name = result[n].Name;
            PIList.options[n] = new Option(Name, Id);
        }
    };
    EditCosts.prototype.GetViewListComplete = function (result) {
        var ViewList = document.getElementById('idViewList');
        ViewList.options.length = 0;
        for (var n = 0; n < result.length; n++) {
            var Uid = result[n].Uid;
            var Name = result[n].Name;
            ViewList.options[n] = new Option(Name, Uid);
        }
    };
    EditCosts.prototype.SelectPIDlg_OKOnClick = function () {
        var PIList = document.getElementById("idPIList");
        var projectId = PIList.options[PIList.selectedIndex].value;
        var ViewList = document.getElementById("idViewList");
        var viewUid = ViewList.options[ViewList.selectedIndex].value;
        if (projectId > 0 && viewUid > 0) {
            this.params.ProjectID = projectId;
            this.params.ViewUID = viewUid;
            this.selectPIAndViewDlg.window("winPIAndViewDlg").detachObject();
            this.selectPIAndViewDlg.window("winPIAndViewDlg").close();
            this.selectPIAndViewDlg = null;
            WorkEnginePPM.EditCosts.GetCostTypes(this.params.ViewUID, getCostTypesCompleteDelegate);
        }
    };
    EditCosts.prototype.OnResize = function (event) {
        if (this.initialized == true) {
            var lHeight = this.Height;
            var divLayout = document.getElementById(this.params.ClientID + "layoutDiv");
            if (lHeight > 300) {
                divLayout.style.height = (lHeight - 12) + "px";
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
        }
    };
    EditCosts.prototype.SetSize = function (nWidth, nHeight) {
        this.Width = nWidth;
        this.Height = nHeight;
        this.OnResize();
    };
    EditCosts.prototype.ChildEvent = function (json) {
        switch (json.event) {
            case "GetPeriods":
                var jsonPeriods = { 'periods': [] };
                for (var n = 0; n < this.Periods.length; n++) {
                    jsonPeriods.periods.push({
                        'Id': this.Periods[n].Id,
                        'Name': this.Periods[n].Name,
                        'StartDate': this.Periods[n].StartDate,
                        'FinishDate': this.Periods[n].IdFinishDate
                    });
                }
                return jsonPeriods;
            case "Close":
                this.dhxWins_CloseDialog("winToolsDlg");
                break;
            case "Apply":
                this.ApplyChanges(json);
                break;
        }
        return null;
    };
    EditCosts.prototype.ApplyChanges = function (json) {
        var selectedgrid = this.GetSelectedTopGrid();
        if (selectedgrid == null) {
            alert("No Cost Type selected");
            return;
        }
        var amount = parseInt(json.amount);
        if (isNaN(amount)) {
            alert("Amount : '" + json.amount + "' is not a number");
            return;
        }
        if (amount < 1) {
            alert("Amount cannot be less than 1%");
            return;
        }
        if (amount > 100 && json.action != "Grow") {
            alert("Amount cannot be greater than 100% (Except for 'Grow')");
            return;
        }
        if (parseInt(json.fromperiodid) > parseInt(json.toperiodid)) {
            alert("Start period cannot be later than Finish period");
            return;
        }
        var bReply;
        switch (json.action) {
            case "MoveLater":
                bReply = this.ApplyMoveLater(json);
                break;
            case "MoveEarlier":
                bReply = this.ApplyMoveEarlier(json);
                break;
            case "Grow":
                bReply = this.ApplyAdjustment(json);
                break;
            case "Shrink":
                bReply = this.ApplyAdjustment(json);
                break;
            default:
                alert("Unknown action : " + json.action);
                return;
        }

        if (bReply) {
            this.UpdateAllCalculatedCells(selectedgrid);
            this.CalculateGridTotals(selectedgrid, true);
            this.SetCellsEditStatus(selectedgrid);

            this.RefreshGrid(selectedgrid);
        }
        this.UpdateButtonsAsync();
    };
    EditCosts.prototype.ApplyMoveLater = function (json) {
        var grid = this.GetSelectedTopGrid();
        var row = grid.GetFirst(null, 0);
        var amount = parseFloat(json.amount);
        var bUseAll = false;
        if (json.scope == "AllRows")
            bUseAll = true;
        var fromPeriod = parseInt(json.fromperiodid);
        var toPeriod = parseInt(json.toperiodid);
        while (row != null) {
            var bUse = (bUseAll || row.Selected);
            if (bUse) {
                for (var c = grid.ColNames[1].length - 1; c >= 0; c--) {
                    var col = grid.ColNames[1][c];
                    if (grid.GetAttribute(row, col, "CanEdit") == "1") {
                        var nId = parseInt(col.substring(1));
                        if (nId >= fromPeriod && nId <= toPeriod) {
                            var sType = col.substring(0, 1);
                            var vValue = parseFloat(row[col]);
                            if (isNaN(vValue) == false) {
                                var vAmount = ((vValue * amount) / 100);
                                grid.SetValue(row, col, vValue - vAmount, 0);
                                var nPrevId = (nId + 1);
                                if (nPrevId >= fromPeriod && nPrevId <= toPeriod) {
                                    var prevCol = sType + nPrevId.toString();
                                    var vPrevValue = parseFloat(row[prevCol]);
                                    if (isNaN(vPrevValue) == false) {
                                        grid.SetValue(row, prevCol, vPrevValue + vAmount, 0);
                                    }
                                    else
                                        grid.SetValue(row, prevCol, vAmount, 0);
                                }
                            }
                        }
                    }
                }
                if (this.FTEMode == 1) this.ConvertRowFTEsToHours(grid, row);
            }
            row = grid.GetNext(row);
        }
        return true;
    };
    EditCosts.prototype.ConvertRowFTEsToHours = function (grid, row) {
        for (var c = 0; c < grid.ColNames[1].length; c++) {
            var col = grid.ColNames[1][c];
            var sType = col.substring(0, 1);
            var sId = col.substring(1);
            if (sType == "F") {
                var FTEconv = 1;
                var e = grid.GetAttribute(row, null, "E" + sId);
                if (isNaN(e) == false)
                    FTEconv = e / 100;
                var fte = row[col];
                grid.SetValue(row, "Q" + sId, fte * FTEconv, 0);
            }
        }
    };
    EditCosts.prototype.ApplyMoveEarlier = function (json) {
        var grid = this.GetSelectedTopGrid();
        var row = grid.GetFirst(null, 0);
        var amount = parseFloat(json.amount);
        var bUseAll = false;
        if (json.scope == "AllRows")
            bUseAll = true;
        var fromPeriod = parseInt(json.fromperiodid);
        var toPeriod = parseInt(json.toperiodid);
        while (row != null) {
            var bUse = (bUseAll || row.Selected);
            if (bUse) {
                for (var c = 0; c < grid.ColNames[1].length; c++) {
                    var col = grid.ColNames[1][c];
                    if (grid.GetAttribute(row, col, "CanEdit") == "1") {
                        var nId = parseInt(col.substring(1));
                        if (nId >= fromPeriod && nId <= toPeriod) {
                            var sType = col.substring(0, 1);
                            var vValue = parseFloat(row[col]);
                            if (isNaN(vValue) == false) {
                                var vAmount = ((vValue * amount) / 100);
                                grid.SetValue(row, col, vValue - vAmount, 0);
                                var nPrevId = (nId - 1);
                                if (nPrevId >= fromPeriod && nPrevId <= toPeriod) {
                                    var prevCol = sType + nPrevId.toString();
                                    var vPrevValue = parseFloat(row[prevCol]);
                                    if (isNaN(vPrevValue) == false) {
                                        grid.SetValue(row, prevCol, vPrevValue + vAmount, 0);
                                    }
                                    else
                                        grid.SetValue(row, prevCol, vAmount, 0);
                                }
                            }
                        }
                    }
                }
                if (this.FTEMode == 1) this.ConvertRowFTEsToHours(grid, row);
            }
            row = grid.GetNext(row);
        }
        return true;
    };
    EditCosts.prototype.ApplyAdjustment = function (json) {
        var grid = this.GetSelectedTopGrid();
        var row = grid.GetFirst(null, 0);
        var amount = parseInt(json.amount);
        var bUseAll = false;
        if (json.scope == "AllRows")
            bUseAll = true;
        var fromPeriod = parseInt(json.fromperiodid);
        var toPeriod = parseInt(json.toperiodid);
        while (row != null) {
            var bUse = (bUseAll || row.Selected);
            if (bUse) {
                for (var c = 0; c < grid.ColNames[1].length; c++) {
                    var col = grid.ColNames[1][c];
                    if (grid.GetAttribute(row, col, "CanEdit") == "1") {
                        var nId = parseInt(col.substring(1));
                        if (nId >= fromPeriod && nId <= toPeriod) {
                            var vValue = parseInt(row[col]);
                            if (isNaN(vValue) == false) {
                                if (json.action == "Grow")
                                    grid.SetValue(row, col, vValue + ((vValue * amount) / 100), 0);
                                else if (json.action == "Shrink")
                                    grid.SetValue(row, col, vValue - ((vValue * amount) / 100), 0);
                            }
                        }
                    }
                }
            }
            row = grid.GetNext(row);
        }
        return true;
    };
    EditCosts.prototype.OnGetCostTypesComplete = function (result) {
        this.CostTypes = result;
        try {

            var editorTabData = {
                parent: "idEditorTabDiv",
                style: "display:none;",
                showstate: "true",
                initialstate: "expanded",
                onstatechange: "ribbonEvent('Ribbon_Toggle');",
                imagePath: this.imagePath,
                sections: [
                    {
                        name: "Plan Actions",
                        tooltip: "Plan Actions",
                        columns: [
                            {
                                items: [
                                    { type: "bigbutton", id: "SaveBtn", name: "Save", img: "save32x32.png", tooltip: "Save", onclick: "ribbonEvent('SaveBtn');", disabled: true }
                                ]
                            },
                            {
                                items: [
                                    { type: "bigbutton", id: "CloseBtn", name: "Close", img: "close32.gif", tooltip: "Close", onclick: "ribbonEvent('CloseBtn');" }
                                ]
                            }
                        ]
                    },
                    {
                        name: "Tools",
                        tooltip: "Tools",
                        columns: [
                            {
                                items: [
                                    { type: "smallbutton", id: "CategoriesBtn", name: "Categories", img: "categories.png", tooltip: "Re-add removed category rows", onclick: "ribbonEvent('CategoriesBtn');", disabled: true },
                                    { type: "smallbutton", id: "DetailBtn", name: "Detail", img: "detail.png", tooltip: "Add a child detail row", onclick: "ribbonEvent('DetailBtn');", disabled: true },
                                    { type: "smallbutton", id: "RemoveBtn", name: "Delete", img: "delete.png", tooltip: "Remove selected category rows from display", onclick: "ribbonEvent('RemoveBtn');", disabled: true }
                                ]
                            },
                            {
                                items: [
                                    { type: "text", name: "Displayed Values:" },
                                    { type: "select", id: "DisplayedValues", onchange: "ribbonEvent('DisplayedValues');", options: "<option value='0'>UoMs</option><option value='1'>FTEs</option>", width: "55px" }
                                ]
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "ToolsBtn", name: "Tools", img: "spread.gif", tooltip: "Show Tools dialog for Move, Grow and Shrink operations", onclick: "ribbonEvent('ToolsBtn');", disabled: true },
                                    { type: "smallbutton", id: "ShowRefBtn", name: "Show Reference", img: "reference.png", tooltip: "Show/Hide Reference Area", onclick: "ribbonEvent('ShowRefBtn');", disabled: false },
                                    { type: "smallbutton", id: "CopyBtn", name: "Copy", img: "copyrow.gif", tooltip: "Copy values up from selected reference cost type", onclick: "ribbonEvent('CopyBtn');" }
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
                                    { type: "select", id: "idViewTab_FromPeriod", onchange: "ribbonEvent('ViewTab_FromPeriod_Changed');", width: "100px" }
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
                                    { type: "select", id: "idViewTab_ToPeriod", onchange: "ribbonEvent('ViewTab_ToPeriod_Changed');", width: "100px" }
                                ]
                            }
                        ]
                    }
                ]
            };

            this.editorTab = new Ribbon(editorTabData);
            this.editorTab.Render();

            this.layout = new dhtmlXLayoutObject(this.params.ClientID + "layoutDiv", "3E", "dhx_skyblue");
            this.layout._minHeight = 18;
            this.layout.cells(this.ribbonArea).setText("Ribbon Area");
            this.layout.cells(this.ribbonArea).hideHeader();
            this.layout.cells(this.ribbonArea).setHeight(92);
            this.layout.cells(this.ribbonArea).fixSize(false, true);

            this.layout.cells(this.ribbonArea).attachObject(document.getElementById(this.editorTab.getRibbonDiv()));
            this.layout.cells(this.mainArea).setText("Main Area");
            this.layout.cells(this.mainArea).hideHeader();
            this.layout.cells(this.referenceArea).setText("Reference Area");
            this.layout.cells(this.referenceArea).hideHeader();

            this.tabbar = this.layout.cells(this.mainArea).attachTabbar();
            this.tabbar.setImagePath("/_layouts/epmlive/dhtml/xtab/imgs/");
            this.tabbar.enableAutoReSize();
            this.tabbar.setStyle("winDflt");
            this.tabbar.setSkinColors("#EEEEEE", "#FFFFFF");

            this.tabbar_ref = this.layout.cells(this.referenceArea).attachTabbar();
            this.tabbar_ref.setImagePath("/_layouts/epmlive/dhtml/xtab/imgs/");
            this.tabbar_ref.enableAutoReSize();
            this.tabbar_ref.setStyle("winDflt");
            this.tabbar_ref.setSkinColors("#EEEEEE", "#FFFFFF");

            if (this.CostTypes == null) {
                alert("edit costs : CostTypes is null");
            }
            else if (this.CostTypes.length <= 0) {
                alert("edit costs : No CostTypes returned");
            }
            else {
                for (var n = 0; n < this.CostTypes.length; n++) {
                    var costtypeId = this.CostTypes[n].Id;
                    var costtypeName = this.CostTypes[n].Name;
                    this.tabbar.addTab("tab_" + costtypeId, costtypeName);
                    this.tabbar.setContentHTML("tab_" + costtypeId, "<div id='gridDiv_" + costtypeId + "'></div>");
                    this.tabbar_ref.addTab("reftab_" + costtypeId, costtypeName);
                    this.tabbar_ref.setContentHTML("reftab_" + costtypeId, "<div id='bottomgridDiv_" + costtypeId + "'></div>");
                }
            }

            this.tabbar.attachEvent("onSelect", function (id) { tabbarOnSelectDelegate(id, arguments); return true; });
            this.tabbar_ref.attachEvent("onSelect", function (id) { tabbarRefOnSelectDelegate(id, arguments); return true; });

            this.initialized = true;
            this.OnResize();

            var bAllowNamedRates = false;
            for (var n = 0; n < this.CostTypes.length; n++) {
                if (this.CostTypes[n].AllowNamedRates != false) {
                    bAllowNamedRates = true;
                    break;
                }
            }

            if (bAllowNamedRates)
                WorkEnginePPM.EditCosts.GetNamedRates(getNamedRatesCompleteDelegate);
            else
                WorkEnginePPM.EditCosts.GetPeriods(this.params.ViewUID, getPeriodsCompleteDelegate);

            this.layout.cells(this.referenceArea).collapse();
            this.referenceAreaCollapsed = true;
            this.editorTab.hideItem("CopyBtn");
        }
        catch (e) {
            alert(e.toString());
        }
    };
    EditCosts.prototype.OnGetNamedRatesComplete = function (result) {
        this.NamedRateValues = result;
        WorkEnginePPM.EditCosts.GetPeriods(this.params.ViewUID, getPeriodsCompleteDelegate);
    };
    EditCosts.prototype.OnGetPeriodsComplete = function (result) {
        this.Periods = result;
        if (this.CostTypes.length > 0) {
            this.tabbar.setTabActive("tab_" + this.CostTypes[0].Id);
        }
        
        var from = document.getElementById('idViewTab_FromPeriod');
        from.options.length = 0;
        from.options.selectedIndex = -1;
        var to = document.getElementById('idViewTab_ToPeriod');
        to.options.length = 0;
        to.options.selectedIndex = -1;
        for (var n = 0; n < this.Periods.length; n++) {
            var periodid = parseInt(this.Periods[n].Id);
            var sPeriod = this.Periods[n].Name;
            from.options[n] = new Option(sPeriod, periodid);
            to.options[n] = new Option(sPeriod, periodid);
        }
    };
    EditCosts.prototype.tabbarOnSelect = function (id, data) {
        var rootid = this.GetRootIdFromIdName(id);
        var grid = Grids["g_" + rootid];
        if (grid == null) {
            var sb = new StringBuilder();
            sb.append("<treegrid SuppressMessage='3' debug='0' sync='0' ");
            sb.append(" layout_url='" + this.params.Webservice + "' layout_method='Soap' layout_function='GetEditCostsLayout' layout_namespace='WorkEnginePPM' layout_param_Projectid='" + this.params.ProjectID + "' layout_param_Costtypeid='" + rootid + "' layout_param_Viewuid='" + this.params.ViewUID + "' layout_param_Ftemode='" + this.FTEMode + "' layout_param_Wepid='" + this.params.WEPID + "' layout_param_Trycheckout='1'");
            sb.append(" data_url='" + this.params.Webservice + "' data_method='Soap' data_function='GetEditCostsData' data_namespace='WorkEnginePPM' data_param_Projectid='" + this.params.ProjectID + "' data_param_Costtypeid='" + rootid + "' data_param_Viewuid='" + this.params.ViewUID + "' data_param_Ftemode='" + this.FTEMode + "' data_param_Wepid='" + this.params.WEPID + "' data_param_Trycheckout='1'");
            sb.append(" upload_url='" + this.params.Webservice + "' upload_type='Body' upload_method='Soap' upload_function='SaveEditCostsData' upload_namespace='WorkEnginePPM' upload_data='sData' upload_param_Projectid='" + this.params.ProjectID + "' upload_param_Costtypeid='" + rootid + "' upload_param_Viewuid='" + this.params.ViewUID + "' upload_param_Wepid='" + this.params.WEPID + "' >");
            sb.append("</treegrid>");

            TreeGrid(sb.toString(), "gridDiv_" + rootid, "g_" + rootid);
            this.ShowWorkingPopup("divLoading");
        }
        else {
            this.UpdateButtonsAsync();
        }
    };
    EditCosts.prototype.tabbarRefOnSelect = function (id, data) {
        var rootid = this.GetRootIdFromIdName(id);
        if (Grids["bottomg_" + rootid] == null) {
            var sb = new StringBuilder();
            sb.append("<treegrid SuppressMessage='3' debug='0' sync='0' ");
            sb.append(" layout_url='" + this.params.Webservice + "' layout_method='Soap' layout_function='GetEditCostsLayout' layout_namespace='WorkEnginePPM' layout_param_Projectid='" + this.params.ProjectID + "' layout_param_Costtypeid='" + rootid + "' layout_param_Viewuid='" + this.params.ViewUID + "' layout_param_Ftemode='" + this.FTEMode + "' layout_param_Wepid='" + this.params.WEPID + "' layout_param_Trycheckout='0'");
            sb.append(" data_url='" + this.params.Webservice + "' data_method='Soap' data_function='GetEditCostsData' data_namespace='WorkEnginePPM' data_param_Projectid='" + this.params.ProjectID + "' data_param_Costtypeid='" + rootid + "' data_param_Viewuid='" + this.params.ViewUID + "' data_param_Ftemode='" + this.FTEMode + "' data_param_Wepid='" + this.params.WEPID + "' data_param_Trycheckout='0' >");
            sb.append("</treegrid>");
            TreeGrid(sb.toString(), "bottomgridDiv_" + rootid, "bottomg_" + rootid);
            this.ShowWorkingPopup("divLoading");
        }
        else {
            this.UpdateButtonsAsync();
        }
    };
    EditCosts.prototype.GridsOnReady = function(grid, start) {
        if (this.startPeriod == null) {
            this.startPeriod = grid.StartPeriod;
            this.finishPeriod = grid.FinishPeriod;
            if (this.startPeriod == null || this.startPeriod <= 0)
                this.startPeriod = this.Periods[0].Id;
            if (this.finishPeriod == null || this.finishPeriod <= 0)
                this.finishPeriod = this.Periods[(this.Periods.length - 1)].Id;
            if (this.finishPeriod < this.startPeriod)
                this.finishPeriod = this.Periods[(this.Periods.length - 1)].Id;
            this.editorTab.selectByValue("idViewTab_FromPeriod", this.startPeriod);
            this.editorTab.selectByValue("idViewTab_ToPeriod", this.finishPeriod);
        }
        this.UpdateAllCalculatedCells(grid);
        this.CalculateGridTotals(grid, false);
    };
    EditCosts.prototype.GridsOnRenderFinish = function (grid) {
        this.SetGridColsVisibility(grid);
        if (grid.RowCount > 0) {
            var rootid = this.GetRootIdFromIdName(grid.id);
            var costtype = this.GetCostTypeFromId(rootid);
            if (costtype != null) {
                var level = costtype.InitialLevel;
                if (level <= 0) level = 99;
                var row = grid.GetFirst(null, 0);
                while (row != null) {
                    if (row.Level > level)
                        grid.Collapse(row);
                    else
                        grid.Expand(row);
                    row = grid.GetNext(row, 0);
                }
            }
        }
        this.SetCellsEditStatus(grid);
        for (var c = 0; c < grid.ColNames[1].length; c++) {
            var col = grid.ColNames[1][c];
            if (grid.GetAttribute(null, col, "IsStatusPeriod") == "1") {
                var lPos = grid.GetColLeft(col);
                grid.SetScrollLeft(lPos, 1);
            }
        }
        if (grid.CheckedoutDetails != null && grid.CheckedoutDetails != "") {
            alert(grid.CheckedoutDetails);
        }
        this.HideWorkingPopup("divLoading");
        this.UpdateButtonsAsync();
    };
    EditCosts.prototype.toolbarOnClick = function (id, data) {
        var grid = this.GetSelectedTopGrid();
        switch (id) {
            case "Ribbon_Toggle":
                if (this.editorTab.isCollapsed() == true) {
                    this.layout.cells(this.ribbonArea).fixSize(false, false);
                    this.layout.cells(this.ribbonArea).setHeight(92);
                    this.layout.cells(this.ribbonArea).fixSize(false, true);
                    this.editorTab.expand();
                } else {
                    this.layout.cells(this.ribbonArea).fixSize(false, false);
                    this.layout.cells(this.ribbonArea).setHeight(22);
                    this.layout.cells(this.ribbonArea).fixSize(false, true);
                    this.editorTab.collapse();
                }
                break;
            case "DisplayedValues":
                var modeSelection = document.getElementById("DisplayedValues");
                if (modeSelection != null && modeSelection.selectedIndex >= 0) {
                    if (modeSelection.selectedIndex == 0) this.FTEMode = 0; else this.FTEMode = 1;
                    for (var i = 0; i < Grids.length; i++) {
                        this.SetGridColsVisibility(Grids[i]);
                    }
                    this.UpdateButtonsAsync();
                }
                break;
            case "ShowRefBtn":
                {
                    var stateOn = this.editorTab.getButtonState("ShowRefBtn");
                    if (stateOn == false) {
                        this.editorTab.setButtonStateOn("ShowRefBtn");
                        this.editorTab.showItem("CopyBtn");
                        this.layout.cells(this.referenceArea).expand();
                        this.referenceAreaCollapsed = false;
                        if (this.CostTypes.length > 0) {
                            this.tabbar_ref.setTabActive("reftab_" + this.CostTypes[0].Id);
                        }
                    } else {
                        this.editorTab.setButtonStateOff("ShowRefBtn");
                        this.editorTab.hideItem("CopyBtn");
                        this.referenceAreaCollapsed = true;
                        this.layout.cells(this.referenceArea).collapse();
                        this.DisableButtons(false);
                        //                        for (var n = 0; n < this.CostTypes.length; n++) {
                        //                            var gtop = Grids["g_" + this.CostTypes[n].Id];
                        //                            if (gtop != null) {
                        //                                if (gtop.CostsAreEditable == 1) {
                        //                                    var g = Grids["bottomg_" + this.CostTypes[n].Id];
                        //                                    if (g != null) {
                        //                                        g.Dispose();
                        //                                    }
                        //                                }
                        //                            }
                        //                        }
                    }
                    this.UpdateButtonsAsync();
                    break;
                }
            case "CategoriesBtn":
                {
                    if (this.editorTab.isItemDisabled("CategoriesBtn") == true)
                        alert("Select an editable row");
                    else {
                        if (grid.FRow == null) {
                            alert("Please select a row");
                        } else {
                            var h = this.categoriesDlg_LoadData(grid, grid.FRow);
                            if (h == 0) {
                                alert("There are no categories which can be added under the selected row");
                            } else
                                this.DisplayDialog(20, 30, 350, 150 + h, "Select the categories to add", "winCategoriesDlg", "idCategoriesDlgObj", true, false);
                        }
                    }
                    break;
                }
            case "DetailBtn":
                {
                    if (this.CanAddDetailRow(grid, grid.FRow, true) == true) {
                        var row = grid.FRow;
                        var sId = grid.GetAttribute(row, null, "id");
                        //var sParentId = sId;
                        var npos = sId.indexOf("S");
                        if (npos > -1) {
                            // detail row - find the parent
                            var sParentId = sId.substring(0, npos);
                            row = grid.GetRowById(sParentId);
                        }

                        if (row != null) {
                            // count the children to get the sequence number
                            var childrow = row.firstChild;
                            var bchildren = false;
                            while (childrow != null) {
                                if (childrow.Visible == true) {
                                    bchildren = true;
                                    break;
                                }
                                childrow = childrow.nextSibling;
                            }

                            this.detailGrid = grid;
                            this.detailRow = row;

                            if (bchildren == false) {
                                this.DisplayDialog(20, 30, 350, 185, "Edit Cost Types", "winDetailDlg", "idDetailDlgObj", true, false);
                            }
                            else
                                this.AddDetailRow(grid, row, false);
                        }
                    }
                    break;
                }
            case "ToolsBtn":
                {
                    var toolsdlg = this.wins.window("winToolsDlg");
                    if (toolsdlg == null || toolsdlg.isHidden()) {
                        this.toolsDlg_LoadData();
                        this.DisplayDialog(20, 30, 350, 270, "Tools", "winToolsDlg", "idToolsDlgObj", false, false);
                    }
                    break;
                }
            case "RemoveBtn":
                {
                    if (this.editorTab.isItemDisabled("RemoveBtn") == true)
                        alert("Select one or more rows");
                    else {
                        if (grid != null) {
                            var b = window.confirm("Are you sure?\n\nAny row values will be deleted on save.");
                            if (b) {
                                var rows = grid.GetSelRows();
                                if (rows.length) {
                                    for (var i = 0; i < rows.length; i++)
                                        grid.DeleteRow(rows[i], 2); // 1=okmsg+del; 2=del; 3=undel
                                }
                                this.SetGridColsVisibility(grid);
                                this.UpdateAllCalculatedCells(grid);
                                this.CalculateGridTotals(grid, true);
                            }
                            this.UpdateButtonsAsync();
                        }
                    }
                    break;
                }
            case "SaveBtn":
                {
                    if (this.editorTab.isItemDisabled("SaveBtn") != true) {
                        document.body.style.cursor = 'wait';
                        this.ShowWorkingPopup("divSaving");
                        this.DisableButtons(false);
                        for (var n = 0; n < this.CostTypes.length; n++) {
                            var g = Grids["g_" + this.CostTypes[n].Id];
                            if (g != null) {
                                if (g.CostsAreEditable == 1) {
                                    if ((g.HasChanges() & (1 << 0)) != 0) {
                                        g.Save();
                                    }
                                }
                            }
                        }
                    }
                    break;
                }
            case "CloseBtn":
                {
                    var b = true;
                    this.ExitConfirmed = false;
                    if (this.Dirty)
                        b = window.confirm("You have unsaved changes.\n\nAre you sure you want to exit without saving?");
                    if (b) {
                        this.ExitConfirmed = true;
                        if (parent.SP.UI.DialogResult)
                            parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
                        else
                            parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.cancel, '');
                    }
                    break;
                }
            case "UoMBtn":
                {
                    this.FTEMode = 0;
                    for (var i = 0; i < Grids.length; i++) {
                        this.SetGridColsVisibility(Grids[i]);
                    }

                    this.UpdateButtonsAsync();
                    break;
                }
            case "FTEBtn":
                {
                    this.FTEMode = 1;
                    for (var i = 0; i < Grids.length; i++) {
                        this.SetGridColsVisibility(Grids[i]);
                    }

                    this.UpdateButtonsAsync();
                    break;
                }
            case "CopyBtn":
                {
                    if (grid != null) {
                        {
                            var refGrid = this.GetSelectedRefGrid();
                            if (refGrid != null) {
                                var rows = grid.GetSelRows();
                                var refRows = refGrid.GetSelRows();
                                if (rows.length != 1 || refRows.length != 1) {
                                    alert("A single row must be selected in each grid");
                                    return;
                                }
                                var row = rows[0];
                                var refRow = refRows[0];

                                for (var c = 0; c < grid.ColNames[1].length; c++) {
                                    var col = grid.ColNames[1][c];
                                    var refCol = refGrid.ColNames[1][c];
                                    if (grid.GetAttribute(row, col, "CanEdit") == "1") {
                                        var v1 = row[col];
                                        var v2 = refRow[refCol];
                                        if (v1 != v2) {
                                            grid.SetValue(row, col, v2, 0);
                                        }
                                    }
                                }
                                this.RecalculateRowAndTotals(grid, row);
                                this.CalculateGridTotals(grid, true);
                            }
                        }
                    }
                    this.UpdateButtonsAsync();
                    break;
                }
            case "ViewTab_FromPeriod_Changed":
            case "ViewTab_ToPeriod_Changed":
                var from = document.getElementById('idViewTab_FromPeriod');
                var sp = parseInt(from.options[from.selectedIndex].value);
                var to = document.getElementById('idViewTab_ToPeriod');
                var fp = parseInt(to.options[to.selectedIndex].value);

                if (sp > fp) {
                    alert("The 'From' period cannot be after the 'To' Period");
                    this.editorTab.selectByValue("idViewTab_FromPeriod", this.startPeriod);
                    this.editorTab.selectByValue("idViewTab_ToPeriod", this.finishPeriod);
                }
                else {
                    this.startPeriod = sp;
                    this.finishPeriod = fp;
                    for (var i = 0; i < Grids.length; i++) {
                        this.SetGridColsVisibility(Grids[i]);
                    }
                    this.UpdateButtonsAsync();
                }
                break;
        }
    };
    EditCosts.prototype.DisplayDialog = function (left, top, width, height, title, idWindow, idAttachObj, bModal, bResize) {
        var wins = this.wins;
        if (wins != null) {
            var dlg = wins.createWindow(idWindow, left, top, width, height);
            if (dlg != null) {
                dlg.clearIcon();
                if (bResize == false)
                    dlg.denyResize();
                else
                    dlg.allowResize();
                dlg.button("park").hide();
                dlg.button("close").hide();
                dlg.button("minmax1").hide();
                dlg.setModal(bModal);
                dlg.center();
                dlg.setText(title);
                dlg.attachEvent("onClose", function (win) { dlg_OnCloseDelegate(idWindow); return true; });
                if (idAttachObj != null)
                    dlg.attachObject(idAttachObj);
                dlg.allowMove();

            }
            return dlg;
        }
        return null;
    };
    EditCosts.prototype.dhxWins_CloseDialog = function (idWindow) {
        var dlg = this.wins.window(idWindow);
        if (dlg != null) {
            dlg.setModal(false);
            dlg.hide();
            dlg.detachObject();
        }
    };
    EditCosts.prototype.AddDetailRow = function (grid, parentrow, copy) {
        if (parentrow != null) {
            // count the children to get the sequence number
            var childrow = parentrow.firstChild;
            var ncount = 1;
            while (childrow != null) {
                if (childrow.Visible == true)
                    ncount++;
                childrow = childrow.nextSibling;
            }
            // build id of new row
            var sParentId = grid.GetAttribute(parentrow, null, "id");
            var sNewId = sParentId + "S" + ncount.toString();
            var newrow = grid.CopyRow(parentrow, parentrow, null, false, false);
            grid.SetAttribute(newrow, null, "id", sNewId, 0, 0);
            for (var c = 0; c < grid.ColNames[0].length; c++) {
                var col = grid.ColNames[0][c];
                var sType = col.substring(0, 1);
                if (sType == "W" || sType == "X" || sType == "Y" || sType == "Z") {
                    parentrow[col] = "";
                    if (copy == false) newrow[col] = "";
                }
            }
            for (var c = 0; c < grid.ColNames[1].length; c++) {
                var col = grid.ColNames[1][c];
                var sType = col.substring(0, 1);
                if (sType == "Q" || sType == "F" || sType == "C") {
                    parentrow[col] = "";
                    if (copy == false) newrow[col] = "";
                }
            }
            this.SetCellsEditStatus(grid);
            setTimeout(function () { grid.Focus(newrow, "uom"); }, 10);
        }
        this.UpdateButtonsAsync();
    };
    EditCosts.prototype.SetGridColsVisibility = function (grid) {
        var g = grid;
        if (g) {
            this.showArray = new Array();
            this.hideArray = new Array();
            for (var c = 0; c < g.ColNames[1].length; c++) {
                var col = g.ColNames[1][c];
                var sType = col.substring(0, 1);
                var periodId = parseInt(col.substring(1));
                var bHide = false;
                if (periodId < this.startPeriod || periodId > this.finishPeriod)
                    this.hideArray[this.hideArray.length] = col;
                else {
                    if ((sType == "Q" || col == "TQ") && this.FTEMode != 0)
                        bHide = true;
                    else if (sType == "F" && this.FTEMode == 0)
                        bHide = true;
                    else if (sType != "Q" && sType != "F" && sType != "C" && col != "uom" && col != "TC" && col != "TQ")
                        bHide = true;
                    else if (sType == "Q" || sType == "F" || col == "TQ")
                        bHide = this.HideQtyCol(grid, col);
                    if (sType != "P") {
                        if (bHide) {
                            this.hideArray[this.hideArray.length] = col;
                        } else {
                            this.showArray[this.showArray.length] = col;
                        }
                    }
                }
            }
            g.ChangeColsVisibility(this.showArray, this.hideArray, 0);
        }
    };
    EditCosts.prototype.HideQtyCol = function (grid, col) {
        var canHide = true;
        if (grid.RowCount > 0) {
            var row = grid.GetFirst(null, 0);
            while (row != null) {
                var uom = row["uom"];
                if (uom != null && uom != "") {
                    var deleted = row.Deleted;
                    if (deleted == null) deleted = 0;
                    if (deleted == 0) {
                        if (row.Visible != 0) {
                            canHide = false;
                            break;
                        }
                    }
                }
                row = grid.GetNext(row);
            }
        }
        return canHide;
    };
    EditCosts.prototype.toolsDlg_LoadData = function () {
        var jsonData = {};
        jsonData["event"] = "GetPeriods";
        var jsonPeriods = this.ChildEvent(jsonData);
        var from = document.getElementById('idSelPeriodFrom');
        from.options.length = 0;
        var to = document.getElementById('idSelPeriodTo');
        to.options.length = 0;
        for (var n = 0; n < jsonPeriods.periods.length; n++) {
            from.options[n] = new Option(jsonPeriods.periods[n].Name, jsonPeriods.periods[n].Id);
            to.options[n] = new Option(jsonPeriods.periods[n].Name, jsonPeriods.periods[n].Id);
        }
        from.options.selectedIndex = 0;
        to.options.selectedIndex = to.options.length - 1;
    };
    EditCosts.prototype.toolsDlg_OnClose = function () {
        this.dhxWins_CloseDialog("winToolsDlg");
    };
    EditCosts.prototype.toolsDlg_CloseOnClick = function () {
        this.dhxWins_CloseDialog("winToolsDlg");
    };
    EditCosts.prototype.toolsDlg_ApplyOnClick = function () {
        var jsonData = {};
        jsonData["event"] = "Apply";
        if (document.getElementById("idMoveLater").checked != 0)
            jsonData["action"] = "MoveLater";
        else if (document.getElementById("idMoveEarlier").checked != 0)
            jsonData["action"] = "MoveEarlier";
        else if (document.getElementById("idGrow").checked != 0)
            jsonData["action"] = "Grow";
        else if (document.getElementById("idShrink").checked != 0)
            jsonData["action"] = "Shrink";
        jsonData["amount"] = document.getElementById("idAmount").value;
        if (document.getElementById("idAllRows").checked != 0)
            jsonData["scope"] = "AllRows";
        else if (document.getElementById("idSelectedRows").checked != 0)
            jsonData["scope"] = "SelectedRows";

        var select = document.getElementById("idSelPeriodFrom");
        jsonData["fromperiodid"] = select.options[select.selectedIndex].value;
        select = document.getElementById("idSelPeriodTo");
        jsonData["toperiodid"] = select.options[select.selectedIndex].value;

        this.ChildEvent(jsonData);
    };
    EditCosts.prototype.categoriesDlg_LoadData = function (grid, row) {
        this.detailGrid = grid;
        this.detailRow = row;
        var h = 0;
        // are there any detail rows attached?
        var childrow = row.firstChild;
        var bChildren = false;
        var bDetail = false;
        while (childrow != null) {
            if (childrow.Visible == true) {
                bChildren = true;
                var sId = grid.GetAttribute(childrow, null, "id");
                var npos = sId.indexOf("S");
                if (npos > -1) {
                    bDetail = true;
                    break;
                }
            }
            childrow = childrow.nextSibling;
        }
        var sb = new StringBuilder();
        if (bDetail == true) {
            sb.append("Warning: <br />Adding sub-categories to this category will remove its detail data rows");
            document.getElementById("idDivCategoriesMessage").innerHTML = sb.toString();
            h += 40;
        }
        else if (bChildren == false) {
            sb.append("Warning: <br />Adding sub-categories to this category will remove any data for this category");
            document.getElementById("idDivCategoriesMessage").innerHTML = sb.toString();
            h += 40;
        }
        var bAdded = false;
        sb = new StringBuilder();
        sb.append("<table><tbody><tr><th style='text-align:left;'></th><th style='text-align:left;'>Category</th></tr>");
        row = grid.FRow.firstChild;
        while (row != null) {
            if (row.Visible == false) {
                sb.append("<tr><td class='controlcell' style='width:20px;'><input id='cid_" + row["Category"] + "' type='checkbox' /></td><td class='controlcell'>" + row["Category"] + "</td></tr>");
                h += 28;
                bAdded = true;
            }
            row = row.nextSibling;
        }
        sb.append("</tbody></table>");
        document.getElementById("idDivCategories").innerHTML = sb.toString();
        if (bAdded == false)
            return 0;
        return h;
    };
    EditCosts.prototype.categoriesDlg_OnClose = function () {
        this.dhxWins_CloseDialog("winCategoriesDlg");
    };
    EditCosts.prototype.categoriesDlg_DialogEvent = function (event) {
        switch (event) {
            case "Add":
                var grid = this.detailGrid;
                var row = this.detailRow;
                var bClearParent = false;
                // delete any detail rows attached
                var childrow = row.firstChild;
                while (childrow != null) {
                    if (childrow.Visible == true) {
                        var sId = grid.GetAttribute(childrow, null, "id");
                        var npos = sId.indexOf("S");
                        if (npos > -1) {
                            grid.DeleteRow(childrow, 2); // 1=okmsg+del; 2=del; 3=undel
                            childrow.Visible = 0;
                            bClearParent = true;
                        }
                    }
                    childrow = childrow.nextSibling;
                }
                // find the selected category rows to add
                childrow = row.firstChild;
                while (childrow != null) {
                    if (childrow.Visible == false) {
                        var cb = document.getElementById("cid_" + childrow["Category"]);
                        if (cb != null) {
                            if (cb.checked) {
                                grid.DeleteRow(childrow, 3); // 1=okmsg+del; 2=del; 3=undel
                                grid.ShowRow(childrow);
                                childrow.Visible = 1;
                                bClearParent = true;
                            }
                        }
                    }
                    childrow = childrow.nextSibling;
                }
                if (bClearParent) {
                    this.ClearRow(grid, row);
                    this.SetGridColsVisibility(grid);
                    this.SetCellsEditStatus(grid);
                    this.CalculateGridTotals(grid, true);
                    setTimeout(function () { grid.Focus(row, "uom"); }, 10);
                }
                break;
            case "Cancel":
                break;
        }
        this.dhxWins_CloseDialog("winCategoriesDlg");

        this.UpdateButtonsAsync();
    };
    EditCosts.prototype.ClearRow = function (grid, row) {
        for (var c = 0; c < grid.ColNames[0].length; c++) {
            var col = grid.ColNames[0][c];
            var sType = col.substring(0, 1);
            if (sType == "W" || sType == "X" || sType == "Y" || sType == "Z") {
                grid.SetValue(row, col, "", 0);
            }
        }

        for (var c = 0; c < grid.ColNames[1].length; c++) {
            var col = grid.ColNames[1][c];
            var sType = col.substring(0, 1);
            if (sType == "Q" || sType == "F" || sType == "C") {
                grid.SetValue(row, col, "", 0);
            }
        }
        grid.RefreshRow(row);
    };
    EditCosts.prototype.detailDlg_DialogEvent = function (event) {
        switch (event) {
            case "Copy":
                this.AddDetailRow(this.detailGrid, this.detailRow, true);
                break;
            case "Add":
                this.AddDetailRow(this.detailGrid, this.detailRow, false);
                break;
            case "Cancel":
                break;
        }
        this.dhxWins_CloseDialog("winDetailDlg");

        this.UpdateButtonsAsync();
    };
    EditCosts.prototype.GridOnAfterSave = function (grid, result, autoupdate) {
        this.HideWorkingPopup("divSaving");
        document.body.style.cursor = 'default';
        this.UpdateButtonsAsync();
    };
    EditCosts.prototype.GridsOnValueChanged = function (grid, row, col, val) {
        if (col.charAt(0) === "Z") {
            var s = val.toString();
            var i = s.indexOf("_");
            if (i > -1) {
                var sNewId = s.substr(0, i);
                var sNewVal = s.substr(i + 1);
                var sAttr = "Y" + col.substr(1);
                grid.SetAttribute(row, null, sAttr, sNewId, 0, 0);
                return sNewVal;
            }
        }
        else if (col.charAt(0) === "W") {
            var s = val.toString();
            var i = s.indexOf("_");
            if (i > -1) {
                var sNewId = s.substr(0, i);
                var sNewVal = s.substr(i + 1);
                grid.SetAttribute(row, null, "V", sNewId, 0, 0);
                return sNewVal;
            }
        }
        return val;
    };
    EditCosts.prototype.GridsOnAfterValueChanged = function (grid, row, col, val) {
        var sType = col.substring(0, 1);
        var sId = col.substring(1);
        if (sType == "F") {
            var FTEconv = 1;
            var e = grid.GetAttribute(row, null, "E" + sId);
            if (isNaN(e) == false)
                FTEconv = e / 100;
            var fte = row[col];
            grid.SetValue(row, "Q" + sId, fte * FTEconv, 1);
            this.UpdateCalculatedCells(grid, row, "Q" + sId);
        }
        else if (sType == "Q") {
            var FTEconv = 1;
            var e = grid.GetAttribute(row, null, "E" + sId);
            if (isNaN(e) == false)
                FTEconv = e / 100;
            var qty = row[col];
            row["F" + sId] = qty / FTEconv;
            this.UpdateCalculatedCells(grid, row, "Q" + sId);
        }
        else if (sType == "W") {
            this.RecalculateRowAndTotals(grid, row);
        }
        else
            this.UpdateCalculatedCells(grid, row, col);
        this.UpdateButtonsAsync();
    };
    EditCosts.prototype.UpdateCalculatedCells = function (grid, row, col) {
        var sType = col.substring(0, 1);
        var sId = col.substring(1);
        var r = this.GetRate(grid, row, col);
        if (sType == "Q" && r > 0) {
            var v = row[col] * r;
            if (v != row["C" + sId]) {
                row["C" + sId] = v;
                this.CalculateRowTotals(grid, row);
                this.CalculateColQtyTotals(grid, grid.GetFirst(null, 0), col, true, "");
                this.CalculateColQtyTotals(grid, grid.GetFirst(null, 0), "F" + sId, true, "");
                this.CalculateColCostTotals(grid, grid.GetFirst(null, 0), "C" + sId, true);

                this.CalculateColQtyTotals(grid, grid.GetFirst(null, 0), "TQ", true, "");
                this.CalculateColQtyTotals(grid, grid.GetFirst(null, 0), "TF", true, "");
                this.CalculateColCostTotals(grid, grid.GetFirst(null, 0), "TC", true);
                grid.RefreshRow(row);
            }
        }
        else if (sType == "C") {
            this.CalculateRowTotals(grid, row);
            this.CalculateColCostTotals(grid, grid.GetFirst(null, 0), col, true);
            this.CalculateColCostTotals(grid, grid.GetFirst(null, 0), "TC", true);
            grid.RefreshRow(row);
        }
    };
    EditCosts.prototype.RecalculateRowAndTotals = function (grid, row) {
        for (var c = 0; c < grid.ColNames[1].length; c++) {
            var col = grid.ColNames[1][c];
            var sType = col.substring(0, 1);
            var sId = col.substring(1);
            var r = this.GetRate(grid, row, col);
            if (sType == "Q" && r > 0) {
                if (isNaN(row[col]) == false) {
                    var v = row[col] * r;
                    if (v != row["C" + sId]) {
                        row["C" + sId] = v;
                        this.CalculateRowTotals(grid, row);
                        this.CalculateColQtyTotals(grid, grid.GetFirst(null, 0), col, true, "");
                        this.CalculateColQtyTotals(grid, grid.GetFirst(null, 0), "F" + sId, true, "");
                        this.CalculateColCostTotals(grid, grid.GetFirst(null, 0), "C" + sId, true);

                        this.CalculateColQtyTotals(grid, grid.GetFirst(null, 0), "TQ", true, "");
                        this.CalculateColQtyTotals(grid, grid.GetFirst(null, 0), "TF", true, "");
                        this.CalculateColCostTotals(grid, grid.GetFirst(null, 0), "TC", true);
                    }
                }
            }
        }
        grid.RefreshRow(row);
    };
    EditCosts.prototype.GetRate = function (grid, row, col) {
        var r = null;
        var sId = col.substring(1);
        if (this.NamedRateValues != null) {
            var rowNamedRateUid = grid.GetAttribute(row, null, "V");
            if (rowNamedRateUid != null && rowNamedRateUid != "") {
                var nId = parseInt(sId) - 1;
                if (nId < this.Periods.length) {
                    var start = this.Periods[nId].StartDate;

                    for (var n = 0; n < this.NamedRateValues.length; n++) {
                        if (rowNamedRateUid == this.NamedRateValues[n].Id) {
                            if (this.NamedRateValues[n].EffectiveDate <= start) {
                                return this.NamedRateValues[n].Rate;
                            }
                        }
                    }
                }
            }
        }
        if (r == null) {
            r = grid.GetAttribute(row, null, "R" + sId);
        }
        return r;
    };
    EditCosts.prototype.UpdateAllCalculatedCells = function (grid) {
        var calccosts = true;
        if (grid.CostsAreEditable != 1 || this.IsReferenceGrid(grid.id) == true)
            calccosts = false;
        var row = grid.GetFirst(null, 0);
        while (row != null) {
            if (row.Visible != 0) {
                var childRow = row.firstChild;
                var bVisibleChildren = false;
                while (childRow != null) {
                    if (childRow.Visible != 0) {
                        bVisibleChildren = true;
                        break;
                    }
                    childRow = childRow.nextSibling;
                }
                if (bVisibleChildren == false) {
                    for (var c = 0; c < grid.ColNames[1].length; c++) {
                        var col = grid.ColNames[1][c];
                        var sType = col.substring(0, 1);
                        var sId = col.substring(1);
                        if (sType == "Q") {
                            var r = this.GetRate(grid, row, col);
                            var FTEconv = 1;
                            var e = grid.GetAttribute(row, null, "E" + sId);
                            if (isNaN(e) == false)
                                FTEconv = e / 100;
                            var q = row[col];
                            if (isNaN(q) == false) {
                                if (calccosts == true) {
                                    if (r > 0) {
                                        var v = q * r;
                                        if ((row["C" + sId] - v) > 0.01)
                                            grid.SetValue(row, "C" + sId, v, 0);
                                        else
                                            row["C" + sId] = v;
                                    }
                                    else if (q != 0)
                                        row["C" + sId] = "";
                                }
                                if (FTEconv > 0)
                                    row["F" + sId] = q / FTEconv;
                            }
                            if (FTEconv <= 0)
                                row["F" + sId] = "";
                        }
                    }
                }
            }
            row = grid.GetNext(row);
        }
    };
    EditCosts.prototype.CalculateRowTotals = function (grid, row) {
        var tc = 0;
        var tq = 0;
        for (var c = 0; c < grid.ColNames[1].length; c++) {
            var col = grid.ColNames[1][c];
            var sType = col.substring(0, 1);
            if (sType == "Q") {
                var v = parseFloat(grid.GetValue(row, col));
                if (isNaN(v) == false)
                    tq += v;
            }
            else if (sType == "C") {
                var v = parseFloat(grid.GetValue(row, col));
                if (isNaN(v) == false)
                    tc += v;
            }
        }

        row["TC"] = tc;
        row["TQ"] = tq;
    };
    EditCosts.prototype.RefreshGrid = function (grid) {
        var row = grid.GetFirst(null, 0);
        while (row != null) {
            grid.RefreshRow(row);
            row = grid.GetNext(row);
        }
    };
    EditCosts.prototype.CalculateGridTotals = function (grid, bRefresh) {
        // sum the columns and then the rows
        for (var c = 0; c < grid.ColNames[1].length; c++) {
            var col = grid.ColNames[1][c];
            var sType = col.substring(0, 1);
            //var sId = col.substring(1);
            if (sType == "Q" || sType == "F")
                this.CalculateColQtyTotals(grid, grid.GetFirst(null, 0), col, bRefresh, "");
            else
                this.CalculateColCostTotals(grid, grid.GetFirst(null, 0), col, bRefresh);
        }

        var row = grid.GetFirst(null, 0);
        while (row != null) {
            this.CalculateRowTotals(grid, row);
            row = grid.GetNext(row);
        }
    };
    EditCosts.prototype.CalculateColQtyTotals = function (grid, row, col, bRefresh, uom) {
        var js = {};
        js["uom"] = uom;
        js["total"] = 0;
        if (row != null && row.Visible != 0) {
            var bVisibleChildren = false;
            var childRow = row.firstChild;
            while (childRow != null) {
                if (childRow.Visible != 0) {
                    bVisibleChildren = true;
                    var js1 = this.CalculateColQtyTotals(grid, childRow, col, bRefresh, row["uom"]);
                    if (js1["uom"] == null)
                        js1["uom"] = "";
                    if (js["uom"] == null)
                        js["uom"] = "";
                    if (js1["uom"] == js["uom"])
                        js["total"] += js1["total"];
                    else if (js["uom"] == "") {
                        js["uom"] = js1["uom"];
                        js["total"] += js1["total"];
                    }
                }
                childRow = childRow.nextSibling;
            }
            if (bVisibleChildren == false) {
                var v = parseFloat(grid.GetValue(row, col));
                if (isNaN(v) == false && (row["uom"] == uom || uom == "")) {
                    js["uom"] = row["uom"];
                    js["total"] = v;
                }
            }
            else {
                row[col] = js["total"].toString();
                if (bRefresh)
                    grid.RefreshCell(row, col);
                if (row["id"] == "I0")
                    row["uom"] = js["uom"];
            }
        }
        return js;
    };
    EditCosts.prototype.CalculateColCostTotals = function (grid, row, col, bRefresh) {
        var t = 0;
        if (row != null && row.Visible != 0) {
            var bVisibleChildren = false;
            var childRow = row.firstChild;
            while (childRow != null) {
                if (childRow.Visible != 0) {
                    t += this.CalculateColCostTotals(grid, childRow, col, bRefresh);
                    bVisibleChildren = true;
                }
                childRow = childRow.nextSibling;
            }
            if (bVisibleChildren == false) {
                var v = parseFloat(grid.GetValue(row, col));
                if (isNaN(v) == false)
                    t = v;
            }
            else {
                row[col] = t.toString();
                if (bRefresh)
                    grid.RefreshCell(row, col);
            }
        }
        return t;
    };
    EditCosts.prototype.SetCellsEditStatus = function (grid) {
        if (grid.RowCount > 0) {
            var row = grid.GetFirst(null, 0);
            while (row != null) {
                var bPossibleEdit = true;
                if (row.firstChild != null) {
                    var childrow = row.firstChild;
                    while (childrow != null) {
                        if (childrow.Visible != 0) {
                            bPossibleEdit = false;
                            break;
                        }
                        childrow = childrow.nextSibling;
                    }
                }
                if (bPossibleEdit == false) {
                    grid.SetAttribute(row, null, "HtmlPrefix", "<B>", 0, 0);
                    grid.SetAttribute(row, null, "HtmlPostfix", "</B>", 0, 0);
                }
                else {
                    grid.SetAttribute(row, null, "HtmlPrefix", "", 0, 0);
                    grid.SetAttribute(row, null, "HtmlPostfix", "", 0, 0);
                }
                if (grid.CostsAreEditable != 1 || this.IsReferenceGrid(grid.id) == true)
                    bPossibleEdit = false;
                if (bPossibleEdit == true) {
                    for (var c = 0; c < grid.ColNames[0].length; c++) {
                        var col = grid.ColNames[0][c];
                        var sType = col.substring(0, 1);
                        if (sType == "X") {
                            grid.SetAttribute(row, col, "CanEdit", "1", 0, 0);
                            grid.SetAttribute(row, col, "Button", "", 0, 0);
                        }
                        else if (sType == "Z" || sType == "W") {
                            grid.SetAttribute(row, col, "CanEdit", "2", 0, 0);
                            grid.SetAttribute(row, col, "Button", "Defaults", 1, 0);
                        }
                        else {
                            grid.SetAttribute(row, col, "CanEdit", "0", 0, 0);
                            grid.SetAttribute(row, col, "Button", "", 0, 0);
                        }
                    }

                    var sCanEditQ = "0";
                    var sCanEditC = "1";
                    if (row["uom"] != "") {
                        // has uom so quantities can be entered but not cost
                        sCanEditQ = "1";
                        sCanEditC = "0";
                    }

                    for (var c = 0; c < grid.ColNames[1].length; c++) {
                        var col = grid.ColNames[1][c];
                        var sType = col.substring(0, 1);
                        if (sType == "Q") {
                            grid.SetAttribute(row, col, "CanEdit", sCanEditQ, 0, 0);
                        }
                        else if (sType == "F") {
                            grid.SetAttribute(row, col, "CanEdit", sCanEditQ, 0, 0);
                        }
                        else if (sType == "C") {
                            grid.SetAttribute(row, col, "CanEdit", sCanEditC, 0, 0);
                        }
                        else
                            grid.SetAttribute(row, col, "CanEdit", "0", 0, 0);
                    }
                }
                else {
                    grid.SetAttribute(row, null, "CanEdit", "0", 0, 0);
                    for (var c = 0; c < grid.ColNames[0].length; c++) {
                        var col = grid.ColNames[0][c];
                        grid.SetAttribute(row, col, "CanEdit", "0", 0, 0);
                        grid.SetAttribute(row, col, "Button", "", 0, 0);
                    }
                    for (var c = 0; c < grid.ColNames[1].length; c++) {
                        var col = grid.ColNames[1][c];
                        grid.SetAttribute(row, col, "CanEdit", "0", 0, 0);
                    }
                }

                row = grid.GetNext(row);
            }
            this.RefreshGrid(grid);

        }
    };
    EditCosts.prototype.GridsOnGetDefaultColor = function (grid, row, col, r, g, b) {
        if (row.Kind != "Data" || grid.Cols[col] == null)
            return null;
        if (grid.FRow == row && grid.FCol == col)
            return null;
        var sdefault;
        if (grid.Cols[col].Sec == 0)
            sdefault = "rgb(255,255,255)";
        else
            sdefault = null;

        var bEditable = false;
        var sCanEdit = grid.GetAttribute(row, col, "CanEdit");
        if (sCanEdit == "1")
            bEditable = true;
        else {
            if (typeof (grid.GetAttribute(row, col, "Defaults")) != "undefined")
                bEditable = true;
        }
        if (bEditable == true) {
            var sChanged = grid.GetAttribute(row, null, col + "Changed");
            if (this.HasChanged(sChanged) == true)
                return null;
            if (grid.Cols[col].Sec != 0)
                sdefault = "rgb(255,255,255)";
        }
        return sdefault;
    };
    EditCosts.prototype.HasChanged = function (sChanged) {
        var bChanged = false;
        if (typeof(sChanged) != "undefined") {
            if (sChanged != null) {
                if (sChanged != "0")
                    bChanged = true;
            }
        }
        return bChanged;
    };
    EditCosts.prototype.GridsOnSelect = function (grid, Row, deselect) {
        this.UpdateButtonsAsync();
    };
    EditCosts.prototype.GridsOnFocus = function (grid, Row, Col, event) {
        this.UpdateButtonsAsync();
    };
    EditCosts.prototype.GridsOnClickCell = function (grid, row, col) {
        this.UpdateButtonsAsync();
    };
    EditCosts.prototype.GetSelectedTopGrid = function () {
        var tabid = this.tabbar.getActiveTab();
        if (tabid == null)
            return null;
        var rootid = this.GetRootIdFromIdName(tabid);
        return Grids["g_" + rootid];
    };
    EditCosts.prototype.GetSelectedRefGrid = function () {
        var tabid = this.tabbar_ref.getActiveTab();
        if (tabid == null)
            return null;
        var rootid = this.GetRootIdFromIdName(tabid);
        return Grids["bottomg_" + rootid];
    };
    EditCosts.prototype.DisableButtons = function (disableClose) {
        if (disableClose == true) {
            this.editorTab.disableItem("CloseBtn");
        }
        this.editorTab.disableItem("SaveBtn");
        this.editorTab.disableItem("CategoriesBtn");
        this.editorTab.disableItem("DetailBtn");
        this.editorTab.disableItem("RemoveBtn");
        this.editorTab.disableItem("ToolsBtn");
    };
    EditCosts.prototype.HandleButtons = function () {
        this.editorTab.enableItem("CloseBtn");
        var selectedgrid = this.GetSelectedTopGrid();
        // bit 0 = changed rows; bit 1 = selected rows - here I'm checking for changed rows 
        this.Dirty = false;
        for (var i = 0; i < Grids.length; i++) {
            var grid = Grids[i];
            if (grid != null) {
                if (grid.CostsAreEditable == 1) {
                    if ((grid.HasChanges() & (1 << 0)) != 0) {
                        this.editorTab.enableItem("SaveBtn");
                        this.Dirty = true;
                        break;
                    }
                }
            }
        }
        if (this.Dirty == false) {
            this.editorTab.disableItem("SaveBtn");
        }
        if (selectedgrid != null) {
            // check for selected rows (&2)
            if ((selectedgrid.HasChanges() & (1 << 1)) != 0) {
                this.editorTab.enableItem("RemoveBtn");
            } else {
                this.editorTab.disableItem("RemoveBtn");
            }
            if (selectedgrid.FRow == null || selectedgrid.CostsAreEditable != 1) {
                this.editorTab.disableItem("CategoriesBtn");
            } else {
                this.editorTab.enableItem("CategoriesBtn");
            }
            if (this.CanAddDetailRow(selectedgrid, selectedgrid.FRow, false)) {
                this.editorTab.enableItem("DetailBtn");
            } else {
                this.editorTab.disableItem("DetailBtn");
            }
        }
        this.editorTab.enableItem("ToolsBtn");
    };
    EditCosts.prototype.HasCustomFields = function (grid) {
        if (grid == null)
            return false;
        for (var c = 0; c < grid.ColNames[0].length; c++) {
            var col = grid.ColNames[0][c];
            var sType = col.substring(0, 1);
            if (sType == "X" || sType == "Z") {
                return true;
            }
        }
        return false;
    };
    EditCosts.prototype.CanAddDetailRow = function (grid, row, bAlert) {
        if (grid == null || row == null) {
            if (bAlert) alert("Cannot add detail row\n\nParent row must be selected");
            return false;
        }
        if (this.HasCustomFields(grid) == false) {
            if (bAlert) alert("Cannot add detail row\n\nAt least one custom field must be displayed");
            return false;
        }
        if (grid.CostsAreEditable != 1) {
            if (bAlert) alert("Cannot add detail row\n\nCosts are not editable");
            return false;
        }
        var sId = grid.GetAttribute(row, null, "id");
        if (sId.indexOf("S") > -1)
            return true;
        if (row.firstChild != null) {
            var childrow = row.firstChild;
            while (childrow != null) {
                if (childrow.Visible == true) {
                    sId = grid.GetAttribute(childrow, null, "id");
                    if (sId.indexOf("S") > -1)
                        return true;
                    else {
                        if (bAlert) alert("Cannot add detail row\n\nInvalid parent row selected");
                        return false;
                    }
                }
                childrow = childrow.nextSibling;
            }
        }
        return true;
    };
    EditCosts.prototype.OnAfterColResize = function (grid, col) {
        if (grid.Cols[col].Sec == 1) {
            if (this.bInColResize == false) {
                this.bInColResize = true;
                var lWidth = grid.GetAttribute(null, col, "Width");
                if (lWidth > 0) {
                    var sType = col.substring(0, 1);
                    if (this.FTEMode == 0 && (sType == "C" || sType == "Q") || this.FTEMode == 1 && (sType == "C" || sType == "F")) {
                        for (var c = 0; c < grid.ColNames[1].length; c++) {
                            var cCol = grid.ColNames[1][c];
                            var visible = grid.GetAttribute(null, cCol, "Visible");
                            if (visible != 0) {
                                var cWidth = grid.Cols[cCol].Width; // grid.GetAttribute(null, cCol, "Width");
                                if (cWidth > 0) {
                                    var cType = cCol.substring(0, 1);
                                    if (sType == cType) {
                                        var dx = lWidth - cWidth;
                                        if (dx != 0)
                                            grid.SetWidth(cCol, dx);
                                    }
                                }
                            }
                        }
                    }
                }
                this.bInColResize = false;
            }
        }
    };
    try {
        this.bInColResize = false;
        this.params = params;
        this.thisID = thisID;
        this.ribbonArea = "a";
        this.mainArea = "b";
        this.referenceArea = "c";
        this.referenceAreaCollapsed = true;
        this.firstResize = true;
        this.detailGrid = null;
        this.detailRow = null;
        this.Dirty = false;
        this.DoneCheckIn = false;
        this.editorTab = null;
        this.toolbar_ref = null;
        this.tabbar = null;
        this.tabbar_ref = null;
        this.layout = null;
        this.initialized = false;
        this.Width = 0;
        this.Height = 0;
        this.CostTypes = null;
        this.NamedRateValues = null;
        this.Periods = null;
        this.startPeriod = null;
        this.finishPeriod = null;
        this.selectPIAndViewDlg = null;
        this.imagePath = "/_layouts/ppm/images/";
        this.FTEMode = 0;
        this.lookupRow = null;
        this.lookupCol = "";
        this.lookupId = -1;
        this.ExitConfirmed = false;
        this.wins = new dhtmlXWindows();
        this.wins.setImagePath("/_layouts/ppm/images/");
        this.wins.setSkin("dhx_web");
        this.showArray = null;
        this.hideArray = null;
        this.hideAllArray = null;

        var loadDelegate = MakeDelegate(this, this.OnLoad);
        var CheckStatusCompleteDelegate = MakeDelegate(this, this.OnCheckStatusComplete);
        var unloadDelegate = MakeDelegate(this, this.OnUnload);
        var GetPIListCompleteDelegate = MakeDelegate(this, this.GetPIListComplete);
        var GetViewListCompleteDelegate = MakeDelegate(this, this.GetViewListComplete);
        var getCostTypesCompleteDelegate = MakeDelegate(this, this.OnGetCostTypesComplete);
        var getNamedRatesCompleteDelegate = MakeDelegate(this, this.OnGetNamedRatesComplete);
        var getPeriodsCompleteDelegate = MakeDelegate(this, this.OnGetPeriodsComplete);
        var tabbarOnSelectDelegate = MakeDelegate(this, this.tabbarOnSelect);
        var tabbarRefOnSelectDelegate = MakeDelegate(this, this.tabbarRefOnSelect);
        var GridsOnReadyDelegate = MakeDelegate(this, this.GridsOnReady);
        var GridsOnRenderFinishDelegate = MakeDelegate(this, this.GridsOnRenderFinish);
        var GridsOnAfterSaveDelegate = MakeDelegate(this, this.GridOnAfterSave);
        var GridsOnSelectDelegate = MakeDelegate(this, this.GridsOnSelect);
        var GridsOnAfterValueChangedDelegate = MakeDelegate(this, this.GridsOnAfterValueChanged);
        var GridsOnGetDefaultColorDelegate = MakeDelegate(this, this.GridsOnGetDefaultColor);
        var GridsOnClickCellDelegate = MakeDelegate(this, this.GridsOnClickCell);
        var GridsOnValueChangedDelegate = MakeDelegate(this, this.GridsOnValueChanged);
        var GridsOnFocusDelegate = MakeDelegate(this, this.GridsOnFocus);
        var GridsOnAfterColResizeDelegate = MakeDelegate(this, this.OnAfterColResize);

        if (document.addEventListener != null) { // e.g. Firefox
            window.addEventListener("load", loadDelegate, true);
            window.addEventListener("beforeunload", unloadDelegate, true);
            window.addEventListener("unload", unloadDelegate, true);
        }
        else { // e.g. IE
            window.attachEvent("onload", loadDelegate);
            window.attachEvent("onbeforeunload", unloadDelegate);
            window.attachEvent("onunload", unloadDelegate);
        }
    }
    catch (ex) {
        alert("Costs Initialization error\n\n" + ex.toString());
    }
}