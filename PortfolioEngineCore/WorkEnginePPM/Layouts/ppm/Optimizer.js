function OptimizerRibbon(inOptData, params, sdlgDiv) {

    OptimizerRibbon.prototype.StashReturnData = function (result) {
        this.passbackresult = result;
    }
    OptimizerRibbon.prototype.SetInitialStratagies = function (strats) {
        this.Stratagies = strats;
        this.currStratagy = null;

        for (var i = 0; i < this.Stratagies.length; i++) {
            var st = this.Stratagies[i];

            if (st.Default == 1) {
                this.currStratagy = st;
                this.doApplyStratagy();
                return;
            }

        }

        if (this.Stratagies.length > 0) {
            this.currStratagy = this.Stratagies[0];
            this.doApplyStratagy();
        }

    }

    OptimizerRibbon.prototype.DataLoadComplete = function () {
        this.optTab.DeferredMultiSelect();
    }


    OptimizerRibbon.prototype.handleExternalEvent = function (event) {

        var oRetVal = null;

        var tbinx = -1;

        if (event.length > 13) {
            if (event.substr(0, 13) == "OptiClickFrom") {

                tbinx = parseInt(event.substr(13));
                event = "OptiClickFrom";
                this.rangefld = this.usingselectedFilters[tbinx];
            }
        }

        if (event.length > 11) {
            if (event.substr(0, 11) == "OptiClickTo") {

                tbinx = parseInt(event.substr(11));
                this.rangefld = this.usingselectedFilters[tbinx];
                event = "OptiClickTo";
            }
        }




        try {
            switch (event) {

                case "OptiClickFrom":
                case "OptiClickTo":

                    var frmtxt = document.getElementById('idFromRange');
                    var totxt = document.getElementById('idToRange');

                    frmtxt.value = "";
                    totxt.value = "";



                    var ldcontainer = document.getElementById(this.rangefld.ribbonName + 'inputl');
                    var rdcontainer = document.getElementById(this.rangefld.ribbonName + 'inputr');

                    frmtxt.value = ldcontainer.value;
                    totxt.value = rdcontainer.value;

                    //                    var r = getAbsolutePosition(ldcontainer);

                    //                    var xy = this.optTab.GetScreenPos(ldcontainer);


                    if (this.EditRangeDlg == null) {
                        this.EditRangeDlg = new dhtmlXWindows();
                        this.EditRangeDlg.setSkin("dhx_web");
                        this.EditRangeDlg.enableAutoViewport(false);
                        this.EditRangeDlg.attachViewportTo(this.params.ClientID + "mainDiv");
                        this.EditRangeDlg.setImagePath("/_layouts/ppm/images/");

                        this.EditRangeDlg.createWindow("winEditRangeDlgDlg", 20, 30, 300, 115);
  //                      this.EditRangeDlg.window("winEditRangeDlgDlg").setIcon("logo.ico", "logo.ico");
                        this.EditRangeDlg.window("winEditRangeDlgDlg").denyResize();
                        this.EditRangeDlg.window("winEditRangeDlgDlg").button("park").hide();
                        this.EditRangeDlg.window("winEditRangeDlgDlg").setModal(true);
                        this.EditRangeDlg.window("winEditRangeDlgDlg").center();
                        this.EditRangeDlg.window("winEditRangeDlgDlg").setText(fld.FName);
                        this.EditRangeDlg.window("winEditRangeDlgDlg").attachObject("idEditRangeDlg");
                    }
                    else {
                        this.EditRangeDlg.window("idEditRangeDlg").show();
                    }


                    if (event == "OptiClickFrom") {
                        frmtxt.focus();
                        frmtxt.select();
                    }
                    else {
                        totxt.focus();
                        totxt.select();
                    }

                    break;


                case "OptiPreInput":

                    this.PreRangeInput();
                    break;


                case "EditRange_Cancel":

                    this.EditRangeDlg.window("winEditRangeDlgDlg").detachObject();
                    this.EditRangeDlg.window("winEditRangeDlgDlg").close();
                    this.EditRangeDlg = null;
                    break;





                case "EditRange_OK":

                    this.EditRangeDlg.window("winEditRangeDlgDlg").detachObject();
                    this.EditRangeDlg.window("winEditRangeDlgDlg").close();
                    this.EditRangeDlg = null;

                    var frmtxt = document.getElementById('idFromRange');
                    var totxt = document.getElementById('idToRange');
                    var ldcontainer = document.getElementById(this.rangefld.ribbonName + 'inputl');
                    var rdcontainer = document.getElementById(this.rangefld.ribbonName + 'inputr');

                    ldcontainer.value = frmtxt.value;
                    rdcontainer.value = totxt.value;




                case "OptiInput":

                    this.RangeInput();

                case "OptiChange":

                    this.applyFilters();

                    var item;
                    var sInList = "";

                    for (var c = 0; c < this.piIn.length; c++) {
                        item = this.piIn[c];
                        sInList += " " + item.ID;
                    }


                    oRetVal = this.constructReturnRequest("OptiChange", "UpdateFilteredList", sInList);

                    this.updateProgressRibbon(false);

                    break;

                case "OptClose":
                    oRetVal = this.constructReturnRequest("Close", "", "");
                    break;

                case "OptClearFilters":
                    this.PreRangeInput();
                    this.clearFilters();

                    var sJSON = this.getOptimizerRibbonJSON();

                    this.optTab.updateRibbonData(sJSON);
                    this.optTab.ReRender();
                    this.flashCurrentStratagies();
                    window.setTimeout(this.flashTabRibbonDelegate, 100);


                case "OptApplyFilters":
                    this.PreRangeInput();
                    this.applyFilters();

                    var item;
                    var sInList = "";

                    for (var c = 0; c < this.piIn.length; c++) {
                        item = this.piIn[c];
                        sInList += " " + item.ID;
                    }


                    oRetVal = this.constructReturnRequest("OptiChange", "UpdateFilteredList", sInList);

                    this.updateProgressRibbon(false);
                    break;


                case "OptUpdateProgress":
                    this.updateProgressRibbon(true);

                    break;

                case "OptEditScen":
                    this.showOptDialog(this.dlgdiv);
                    break;

                case 'OptSelStrat_Changed':
                case "OptConfOK_Click":

                    if (event == "OptSelStrat_Changed") {
                        this.currStratagy = this.GetSelectedStratagy();
                        this.doApplyStratagy();
                    }
                    else {


                        // capture selected filter fields
                        this.CaptureFilters();
                        this.usingselectedFilters = new Array();

                        for (var c = 0; c < this.selectedFilters.length; c++) {
                            this.usingselectedFilters[c] = this.selectedFilters[c];
                        }

                        // capture ConfnameValue

                        var confVal = document.getElementById("idOptConfNameValue");

                        this.ConfNameValue = confVal.value;

                        // capture total field

                        var selConf = document.getElementById('idOptConfTotalField');
                        var iSelColID = 0;

                        for (io = 0; io < selConf.options.length; io++) {

                            if (selConf.options[io].selected == true) {
                                iSelColID = selConf.options[io].value;
                                break;
                            }
                        }

                        this.totalField = null;

                        for (var c = 0; c < this.CostnNumbers.length; c++) {
                            fld = this.CostnNumbers[c];

                            if (fld.FID == iSelColID) {
                                this.totalField = fld;
                                break;
                            }
                        }
                    }

                    var sJSON = this.getOptimizerRibbonJSON();

                    this.optTab.updateRibbonData(sJSON);
                    this.optTab.ReRender();
                    this.flashCurrentStratagies();

                    window.setTimeout(this.flashTabRibbonDelegate, 100);


                    this.applyFilters();
                    this.updateProgressRibbon();

                    var sInList = "";

                    for (var c = 0; c < this.piIn.length; c++) {
                        item = this.piIn[c];
                        sInList += " " + item.ID;
                    }


                    oRetVal = this.constructReturnRequest("OptiChange", "UpdateFilteredList", sInList);

                    if (event == "OptSelStrat_Changed")
                        break;

                case "OptConfCancel_Click":
                    this.OptDlg.window("winOptDlg").detachObject();
                    this.OptDlg.window("winOptDlg").close();
                    this.OptDlg = null;
                    break;
                case "OptConfAddCol_Click":
                    if (this.addbtndisabled != true)
                        this.OptConfCols_ButtonClick(0);

                    break;
                case "OptConfRemoveCol_Click":
                    if (this.rembtndisabled != true)
                        this.OptConfCols_ButtonClick(1);

                    break;
                case "OptConfEnableAdd":
                    var selAvail = document.getElementById('idOptConfAvailfields');


                    this.addbtndisabled = false;
                    this.setNewButtonDisable('idOptConfAdd', false);


                    for (i = 0; i <= selAvail.options.length - 1; i++) {

                        if (selAvail.options[i].selected == true) {
                            var fval = selAvail.options[i].value;

                            for (var ai = 0; ai < this.DisplayableFields.length; ai++) {
                                if (this.DisplayableFields[ai].FID == fval) {
                                    this.TotAddSel = this.DisplayableFields[ai];
                                    break;
                                }
                            }
                            break;
                        }
                    }

                    break;

                case "OptConfEnableRemove":
                    var selSelected = document.getElementById('idOptConfSelfields');
                    var selival = 0;

                    this.rembtndisabled = false;
                    this.setNewButtonDisable('idOptConfRemove', this.rembtndisabled);

                    for (i = 0; i <= selSelected.options.length; i++) {

                        if (selSelected.options[i].selected == true) {
                            var fval = selSelected.options[i].value;
                            selival = i;

                            for (var ai = 0; ai < this.DisplayableFields.length; ai++) {
                                if (this.DisplayableFields[ai].FID == fval) {
                                    this.TotRemSel = this.DisplayableFields[ai];
                                    break;
                                }
                            }

                            break;
                        }
                    }

                    var moveupbtn = document.getElementById('idOptConfSelectedColsMoveUp');
                    var movedownbtn = document.getElementById('idOptConfSelectedColsMoveDown');

                    if (selSelected.options.length <= 1) {
                        moveupbtn.disabled = true;
                        movedownbtn.disabled = true;
                    } else {
                        moveupbtn.disabled = false;
                        movedownbtn.disabled = false;
                    }

                    if (selival == 0)
                        moveupbtn.disabled = true;
                    else if (selival = (selSelected.options.length - 1))
                        movedownbtn.disabled = true;

                    break;
                case "OptConfSelectMoveUp":
                    this.OptConfSelColsMove_ButtonClick(1);
                    break;
                case "OptConfSelectMoveDown":
                    this.OptConfSelColsMove_ButtonClick(0);
                    break;


                case 'OptDelScen':

                    document.getElementById("idDelStrat").value = "";
                    var selectstratagy = document.getElementById("idOptTab_SelView");

                    if (selectstratagy.options.length == 1) {
                        alert("There are no stratagies to delete");
                        break;
                    }

                    if (selectstratagy.selectedIndex == 0)
                        break;

                    if (selectstratagy != null && selectstratagy.selectedIndex >= 0) {
                        var stratagy = this.GetSelectedStratagy();
                        this.selectedstratagy = stratagy;
                        var selectedItem = selectstratagy.options[selectstratagy.selectedIndex];
                        document.getElementById("idDelStrat").value = selectedItem.text;
                    }

                    if (this.DeleteStratDlg == null) {
                        this.DeleteStratDlg = new dhtmlXWindows();
                        this.DeleteStratDlg.setSkin("dhx_web");
                        this.DeleteStratDlg.enableAutoViewport(false);
                        this.DeleteStratDlg.attachViewportTo(this.params.ClientID + "mainDiv");
                        this.DeleteStratDlg.setImagePath("/_layouts/ppm/images/");
                        this.DeleteStratDlg.createWindow("winDeleteStratDlg", 20, 30, 280, 157);
  //                      this.DeleteStratDlg.window("winDeleteStratDlg").setIcon("logo.ico", "logo.ico");
                        this.DeleteStratDlg.window("winDeleteStratDlg").denyResize();
                        this.DeleteStratDlg.window("winDeleteStratDlg").button("park").hide();
                        this.DeleteStratDlg.window("winDeleteStratDlg").setModal(true);
                        this.DeleteStratDlg.window("winDeleteStratDlg").center();
                        this.DeleteStratDlg.window("winDeleteStratDlg").setText("Delete Stratagy");
                        this.DeleteStratDlg.window("winDeleteStratDlg").attachObject("idDeleteStratagy");
                    }
                    else {
                        this.DeleteStratDlg.window("winDeleteStratDlg").show();
                    }
                    break;



                case "DeleteStratagy_OK":


                    var selectstratagy = document.getElementById("idOptTab_SelView");
                    if (selectstratagy.selectedIndex >= 0) {
                        var selectedItem = selectstratagy.options[selectstratagy.selectedIndex];
                        var deletestratGuid = selectedItem.value;
                        var sbd = new StringBuilder();
                        sbd.append('<Execute Function="DeleteOptimizerStratagy">');
                        sbd.append('<Stratagy StratagyGUID="' + XMLValue(deletestratGuid) + '" />');
                        sbd.append('</Execute>');

                        oRetVal = this.constructReturnRequest("RaiseEventJSON", "DeleteOptimizerStratagy", sbd.toString());
                        oRetVal.Passback = true;
                        oRetVal.PassbackFunction = "DeleteOptimizerStratagyComplete";
                    }
                    break;

                case "DeleteOptimizerStratagyComplete":
                    this.DeleteOptimizerStratagyComplete(this.passbackresult);

                    this.doApplyStratagy();
                    var sJSON = this.getOptimizerRibbonJSON();

                    this.optTab.updateRibbonData(sJSON);
                    this.optTab.ReRender();
                    this.flashCurrentStratagies();

                    window.setTimeout(this.flashTabRibbonDelegate, 100);


                    this.applyFilters();
                    this.updateProgressRibbon();

                    var sInList = "";
                    for (var c = 0; c < this.piIn.length; c++) {
                        item = this.piIn[c];
                        sInList += " " + item.ID;
                    }


                    oRetVal = this.constructReturnRequest("OptiChange", "UpdateFilteredList", sInList);


                case "DeleteStratagy_Cancel":
                    this.DeleteStratDlg.window("winDeleteStratDlg").setModal(false);
                    this.DeleteStratDlg.window("winDeleteStratDlg").hide();
                    this.DeleteStratDlg.window("winDeleteStratDlg").detachObject()
                    this.DeleteStratDlg = null;
                    break;

                case "OptSaveScen":
                    document.getElementById("idSaveStratName").value = "New Strategy";
                    document.getElementById("idStratDefault").checked = false;
                    document.getElementById("idStratPer").checked = true;
                    var selectstratagy = document.getElementById("idOptTab_SelView");
                    if (selectstratagy != null && selectstratagy.selectedIndex >= 0) {
                        var strat = this.GetSelectedStratagy();
                        this.selectedStrat = strat;

                        var selectedItem = selectstratagy.options[selectstratagy.selectedIndex];
                        if (selectstratagy.selectedIndex != 0)
                            document.getElementById("idSaveStratName").value = selectedItem.text;
                        var bDefault = false;
                        document.getElementById("idStratDefault").checked = bDefault;
                        var bPersonal = false;
                        if (strat.Personal != 0)
                            bPersonal = true;
                        document.getElementById("idStratPer").checked = bPersonal;
                    }

                    if (this.SaveStratDlg == null) {
                        this.SaveStratDlg = new dhtmlXWindows();
                        this.SaveStratDlg.setSkin("dhx_web");
                        this.SaveStratDlg.enableAutoViewport(false);
                        this.SaveStratDlg.attachViewportTo(this.params.ClientID + "mainDiv");
                        this.SaveStratDlg.setImagePath("/_layouts/ppm/images/");
                        this.SaveStratDlg.createWindow("winSaveStratDlg", 20, 30, 280, 192);
 //                       this.SaveStratDlg.window("winSaveStratDlg").setIcon("logo.ico", "logo.ico");
                        this.SaveStratDlg.window("winSaveStratDlg").denyResize();
                        this.SaveStratDlg.window("winSaveStratDlg").button("park").hide();
                        this.SaveStratDlg.window("winSaveStratDlg").setModal(true);
                        this.SaveStratDlg.window("winSaveStratDlg").center();
                        this.SaveStratDlg.window("winSaveStratDlg").setText("Save Strategy");
                        this.SaveStratDlg.window("winSaveStratDlg").attachObject("idSaveStrat");
                    }
                    else {
                        this.SaveStratDlg.window("winSaveStratDlg").show();
                    }
                    break;

                case "SaveStratagy_OK":
                    var saveStratName = document.getElementById("idSaveStratName").value;
                    var selectStrat = document.getElementById("idOptTab_SelView");
                    var guid = new Guid();
                    if (selectStrat.selectedIndex >= 0) {
                        var selectedItem = selectStrat.options[selectStrat.selectedIndex];
                        guid.value = selectedItem.value;
                        if (selectedItem.text != saveStratName || guid.isGuid() != true) {
                            guid.newGuid();
                        }
                    }
                    else
                        guid.newGuid();

                    var bDefault = document.getElementById("idStratDefault").checked;
                    var bPersonal = document.getElementById("idStratPer").checked;

                    var s = this.BuildStratInf(guid.value, saveStratName, bDefault, bPersonal, false);
                    var sbd = new StringBuilder();
                    sbd.append('<Execute Function="SaveOptimzerStratagyView">');
                    sbd.append(s);
                    sbd.append('</Execute>');


                    oRetVal = this.constructReturnRequest("RaiseEventJSON", "SaveOptimizerStratagy", sbd.toString());
                    oRetVal.Passback = true;
                    oRetVal.PassbackFunction = "SaveOptimizerStratagyComplete";
                    break;

                case "SaveOptimizerStratagyComplete":
                    this.SaveOptimizerStratagyComplete(this.passbackresult);

                case "SaveStratagy_Cancel":

                    this.SaveStratDlg.window("winSaveStratDlg").setModal(false);
                    this.SaveStratDlg.window("winSaveStratDlg").hide();
                    this.SaveStratDlg.window("winSaveStratDlg").detachObject()
                    this.SaveStratDlg = null;
                    break;


                case "OptRenScen":
                    var selectStrat = document.getElementById("idOptTab_SelView");

                    if (selectStrat.options.length == 1) {
                        alert("There are no stratagies to rename");
                        break;
                    }

                    if (selectStrat.selectedIndex == 0)
                        break;

                    if (selectStrat != null && selectStrat.selectedIndex >= 0) {
                        var strat = this.GetSelectedStratagy();

                        var selectedItem = selectStrat.options[selectStrat.selectedIndex];
                        document.getElementById("idRenameStrat").value = selectedItem.text;
                    }
                    else {
                        alert("No Stratagies have been saved to be renamed!");
                        break;
                    }

                    if (this.RenameStratDlg == null) {
                        this.RenameStratDlg = new dhtmlXWindows();
                        this.RenameStratDlg.setSkin("dhx_web");
                        this.RenameStratDlg.enableAutoViewport(false);
                        this.RenameStratDlg.attachViewportTo(this.params.ClientID + "mainDiv");
                        this.RenameStratDlg.setImagePath("/_layouts/ppm/images/");
                        this.RenameStratDlg.createWindow("winRenameStratDlg", 20, 30, 280, 142);
 //                       this.RenameStratDlg.window("winRenameStratDlg").setIcon("logo.ico", "logo.ico");
                        this.RenameStratDlg.window("winRenameStratDlg").denyResize();
                        this.RenameStratDlg.window("winRenameStratDlg").button("park").hide();
                        this.RenameStratDlg.window("winRenameStratDlg").setModal(true);
                        this.RenameStratDlg.window("winRenameStratDlg").center();
                        this.RenameStratDlg.window("winRenameStratDlg").setText("Rename Strategy");
                        this.RenameStratDlg.window("winRenameStratDlg").attachObject("idRenameStratDlg");
                    }
                    else {
                        this.RenameStratDlg.window("winRenameStratDlg").show();
                    }
                    break;


                case "RenameStratagy_OK":
                    var renameStratName = document.getElementById("idRenameStrat").value;
                    var selectStrat = document.getElementById("idOptTab_SelView");

                    var guid;
                    if (selectStrat.selectedIndex >= 0) {
                        var selectedItem = selectStrat.options[selectStrat.selectedIndex];
                        guid = selectedItem.value;
                    }

                    var dataXml = '<Stratagy StratagyGUID="' + XMLValue(guid) + '" Name="' + XMLValue(renameStratName) + '" />';
                    var sbd = new StringBuilder();
                    sbd.append('<Execute Function="RenameOptimizerStratagy">');
                    sbd.append(dataXml);
                    sbd.append('</Execute>');

                    oRetVal = this.constructReturnRequest("RaiseEventJSON", "RenameOptimizerStratagy", sbd.toString());
                    oRetVal.Passback = true;
                    oRetVal.PassbackFunction = "RenameOptimizerStratagyComplete";
                    break;

                case "RenameOptimizerStratagyComplete":
                    this.RenameOptimizerStratagyComplete(this.passbackresult);

                case "RenameStratagy_Cancel":

                    this.RenameStratDlg.window("winRenameStratDlg").setModal(false);
                    this.RenameStratDlg.window("winRenameStratDlg").hide();
                    this.RenameStratDlg.window("winRenameStratDlg").detachObject()
                    this.RenameStratDlg = null;
                    break;



                case 'OptCmtScen':
                    if (this.notgotOptimzerFlag == true) {
                        alert("No flag named 'OptimizerFlag' has been defined in PortfolioEngine - hence Commit Strategy is disabled");

                        break;
                    }



                    var item;
                    var sInList = "";
                    var sOutList = "";

                    for (var c = 0; c < this.piIn.length; c++) {
                        item = this.piIn[c];
                        sInList += " " + item.ID;
                    }

                    for (var c = 0; c < this.piOut.length; c++) {
                        item = this.piOut[c];
                        sOutList += " " + item.ID;
                    }

                    var dataXml = '<SetOptimizerFlag In="' + sInList + '" Out="' + sOutList + '" />';


                    oRetVal = this.constructReturnRequest("RaiseEventJSON", "CommitOptimizerStratagy", dataXml);

                    oRetVal.Passback = true;
                    oRetVal.PassbackFunction = "CommitComplete";
                    break;

                case 'CommitComplete':
                    alert("Commit Strategy Completed");
                    break;


  
                default:
                    alert("unhandled Optimizer event - " + event);
                    break;
            }
        }
        catch (e) {
            this.HandleException("Optimizer", e);
            oRetVal = null;
        }

        return oRetVal;
    }


    OptimizerRibbon.prototype.DeleteOptimizerStratagyComplete = function (jsonString) {
        try {
            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {
                var StratagyGUID = jsonObject.Result.Stratagy.StratagyGUID;

                var bFound = false;
                var select = document.getElementById("idOptTab_SelView");
                for (var i = 0; i < select.options.length; i++) {
                    if (select.options[i].value == StratagyGUID) {
                        bFound = true;
                        select.options[i] = null;

                        if (i == (select.options.length)) {
                            if (select.options.length == 0)
                                this.currStratagy = null;
                            else
                                this.currStratagy = this.Stratagies[i - 1];
                        }
                        else if (i == 0)
                            this.currStratagy = this.Stratagies[1];
                        else
                            this.currStratagy = this.Stratagies[i + 1];

                        var sarr = new Array();

                        for (var i = 0; i < this.Stratagies.length; i++) {

                            var strat = this.Stratagies[i];

                            if (strat != undefined) {

                                if (strat.StratagyGUID != undefined) {

                                    if (strat.StratagyGUID != StratagyGUID) {
                                        sarr[sarr.length] = strat;

                                    }
                                }
                            }
                        }

                        this.Stratagies = sarr;
                        break;
                    }
                }

                if (select.options.length == 0)
                    select.disabled = true;
                else
                    select.disabled = false;

                this.currStratagy = this.GetSelectedStratagy();
            }
        }
        catch (e) {
            this.HandleException("DeleteOptimizerStratagyComplete", e);
        }
    }
    OptimizerRibbon.prototype.SaveOptimizerStratagyComplete = function (jsonString) {
        try {
            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {
                var Strat = jsonObject.Result.Stratagy;

                var bFound = false;
                var select = document.getElementById("idOptTab_SelView");
                for (var i = 0; i < select.options.length; i++) {
                    if (select.options[i].value == Strat.StratagyGUID) {
                        select.options[i].text = Strat.Name;
                        bFound = true;
                        this.Stratagies[i] = Strat;
                        this.currStratagy = Strat;
                        break;
                    }
                }
                if (bFound == false) {
                    select.options[select.options.length] = new Option(Strat.Name, Strat.StratagyGUID, true, true);

                    this.Stratagies.push(Strat);
                    this.currStratagy = Strat;
                }

                if (select.options.length == 0)
                    select.disabled = true;
                else
                    select.disabled = false;

                this.flashCurrentStratagies();

                //           this.SetViewChanged(null);

            }
        }
        catch (e) {
            this.HandleException("SaveRenameStratComplete", e);
        }
    }

    OptimizerRibbon.prototype.RenameOptimizerStratagyComplete = function (jsonString) {
        try {
            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {
                var strat = jsonObject.Result.Stratagy;

                var bFound = false;
                var select = document.getElementById("idOptTab_SelView");
                for (var i = 0; i < select.options.length; i++) {
                    if (select.options[i].value == strat.StratagyGUID) {
                        select.options[i].text = strat.Name;

                        this.Stratagies[i] = strat;
                        this.currStratagy = strat;
                        bFound = true;
                        break;
                    }
                }

                this.flashCurrentStratagies();
            }
        }
        catch (e) {
            this.HandleException("RenameOptimizerStratagyComplete", e);
        }
    }


    OptimizerRibbon.prototype.GetSelectedStratagy = function () {
        try {
            var selectStrat = document.getElementById("idOptTab_SelView");
            if (selectStrat.selectedIndex >= 0) {
                var selectedItem = selectStrat.options[selectStrat.selectedIndex];
                if (selectedItem.value != null) {
                    if (this.Stratagies != null) {
                        for (var i = 0; i < this.Stratagies.length; i++) {
                            var strat = this.Stratagies[i];
                            if (strat != null) {
                                if (strat.StratagyGUID == selectedItem.value) {
                                    this.flashRibbonSelect("idOptTab_SelView");
                                    return strat;
                                    break;
                                }
                            }
                        }
                    }
                }

                return this.Stratagies[0];
            }
        }
        catch (e) {
            this.HandleException("GetSelectedStratagy", e);
        }
        return null;
    }

    OptimizerRibbon.prototype.BuildStratInf = function (StratagyGUID, StratagyName, isStratagyDefault, isStratagyPersonal, bConvToJSON) {
        if (isStratagyDefault == true) isStratagyDefault = 1; else if (isStratagyDefault == false) isStratagyDefault = 0;
        if (isStratagyPersonal == true) isStratagyPersonal = 1; else if (isStratagyPersonal == false) isStratagyPersonal = 0;

        var sflds = new StringBuilder();
        var fld;
        var tfld = 0;

        if (this.totalField != null)
            tfld = this.totalField.FID;

        sflds.append("<Performance  Title='" + this.ConfNameValue + "' Value='" + this.targetValue + "' TFID='" + tfld + "' />");

        sflds.append("<Fields>")

        for (var n1 = 0; n1 < this.usingselectedFilters.length; n1++) {
            fld = this.usingselectedFilters[n1];

            sflds.append("<Field ")
            sflds.append(" FID='" + fld.FID + "'");


            if (fld.isNumeric) {
                sflds.append(" isNum='1'")


                sflds.append(" PosMin='" + fld.posMinValue + "'");
                sflds.append(" PosMax='" + fld.posMaxValue + "'");

                sflds.append(" RangeMin='" + fld.rangeMinValue + "'");
                sflds.append(" RangeMax='" + fld.rangeMaxValue + "' />");


            } else {

                var fcount = 0;

                for (var xi = 0; xi < fld.bSelVals.length; xi++) {
                    if (fld.bSelVals[xi] == true) {
                        ++fcount;
                    }
                }
                sflds.append(" isNum='0' FSELCNT='" + fcount + "' >")
                
                for (var xi = 0; xi < fld.bSelVals.length; xi++) {
                    if (fld.bSelVals[xi] == true) {
                        sflds.append("<Selected>" + fld.textVals[xi] + "</Selected>")
                    }
                }

                sflds.append("</Field>")
            }
        }

        sflds.append("</Fields>")




        var dataXml = '<Stratagy StratagyGUID="' + XMLValue(StratagyGUID) + '" Name="' + XMLValue(StratagyName) + '" ListID="' + this.params.ListIdVal + '" Default="'
				+ isStratagyDefault + '" Personal="' + isStratagyPersonal + '">'
				+ sflds.toString()
				+ '</Stratagy>';

        if (bConvToJSON != true)
            return dataXml;


        return this.xmlStringToJson(dataXml);

    }

    OptimizerRibbon.prototype.doApplyStratagy = function () {



        var strat = this.currStratagy;
        this.usingselectedFilters = new Array();

        if (strat == null)
            return;

        this.ConfNameValue = strat.Performance.Title;
        this.targetValue = strat.Performance.Value;

        var fld;

        if (strat.Performance.TFID == undefined) {
            this.totalField = this.CostnNumbers[0]
        }
        else if (strat.Performance.TFID == 0)
            this.totalField = null;
        else {
            for (var c = 0; c < this.CostnNumbers.length; c++) {
                fld = this.CostnNumbers[c];

                if (fld.FID == strat.Performance.TFID) {
                    this.totalField = fld;
                    break;
                }
            }
        }




        var xfie = JSON_GetArray(strat.Fields, "Field");

        for (i = 0; i < this.DisplayableFields.length; i++) {
            var item = this.DisplayableFields[i];
            item.selected = false;
        }


        for (var c = 0; c < xfie.length; c++) {
            for (var fi = 0; fi < this.Fields.length; fi++) {
                fld = this.Fields[fi];

                if (fld.FID == xfie[c].FID) {
                    this.usingselectedFilters[this.usingselectedFilters.length] = fld;
                    fld.selected = true;

                    if (fld.isNumeric == false) {
                        for (var xi = 0; xi < fld.bSelVals.length; xi++) {
                            fld.bSelVals[xi] = false;
                        }

                        var fsel;

                        if (xfie[c].FSELCNT == undefined)
                            fsel = JSON_GetArray(xfie[c], "Selected");
                        else if (xfie[c].FSELCNT > 1)
                            fsel = JSON_GetArray(xfie[c], "Selected");
                        else {
                            fsel = new Array();
                            if (xfie[c].FSELCNT == 1)
                                fsel[0] = xfie[c].Selected;
                        }

                        for (var yi = 0; yi < fsel.length; yi++) {

                            if (fsel[yi] == null)
                                fsel[yi] = "";

                            for (var xi = 0; xi < fld.bSelVals.length; xi++) {
                                if (fld.textVals[xi] == fsel[yi]) {
                                    fld.bSelVals[xi] = true;
                                    break;
                                }
                            }
                        }



                    }
                    else {
                        fld.posMaxValue = xfie[c].PosMax;
                        fld.posMinValue = xfie[c].PosMin;
                        try {
                            fld.rangeMinValue = xfie[c].RangeMin;
                            fld.rangeMaxValue = xfie[c].RangeMax;
                        }
                        catch (e) { }
                    }
                    break;
                }
            }
        }
    }


    OptimizerRibbon.prototype.flashRibbonSelect = function (idsel) {
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

    OptimizerRibbon.prototype.SetSliderVals = function (sID, minval, maxval, ftype) {

        var MinText = document.getElementById(sID + "displ");
        var MaxText = document.getElementById(sID + "dispr");

        var MinInp = document.getElementById(sID + "inputl");
        var MaxInp = document.getElementById(sID + "inputr");

        if (ftype == 8) {

            MinText.innerHTML = toPrettyString(minval, this.currprefix, this.currpostfix);
            MaxText.innerHTML = toPrettyString(maxval, this.currprefix, this.currpostfix);
        }
        else {
            MinText.innerHTML = toPrettyString(minval, "", "");
            MaxText.innerHTML = toPrettyString(maxval, "", "");
        }


        MinInp.value = minval;
        MaxInp.value = maxval;


    }

    OptimizerRibbon.prototype.GetMinVal = function (sID) {

       var container = $("#" + sID).parent();
       var val = container.find('.epm-slider-minval');
       return val.html();

    }
    OptimizerRibbon.prototype.GetMaxVal = function (sID) {
       var container = $("#" + sID).parent();
       var val = container.find('.epm-slider-maxval');
       return val.html();
   }

   OptimizerRibbon.prototype.GetPosMinVal = function (sID) {

       var container = $("#" + sID).parent();
       var val = container.find('.epm-slider-buttonmin');

       var xvl = val.css('left');

       if (xvl == -1)
           xvl = 0;

       return xvl;

   }
    OptimizerRibbon.prototype.GetPosMaxVal = function (sID) {
       var container = $("#" + sID).parent();
       var val = container.find('.epm-slider-buttonmax');
       return val.css('left');
   }
   OptimizerRibbon.prototype.CaptureFilters = function () {
       var fld;

       for (var n1 = 0; n1 < this.usingselectedFilters.length; n1++) {
           fld = this.usingselectedFilters[n1];

           if (fld.isNumeric) {

               popupInput(fld.ribbonName, 0);

               fld.rangeMinValue = this.GetMinVal(fld.ribbonName);
               fld.rangeMaxValue = this.GetMaxVal(fld.ribbonName);

               this.SetSliderVals(fld.ribbonName, fld.rangeMinValue, fld.rangeMaxValue, fld.FTYPE)

               fld.posMinValue = this.GetPosMinVal(fld.ribbonName);
               fld.posMaxValue = this.GetPosMaxVal(fld.ribbonName);

   

           } else {
               var selvals = this.optTab.GetCheckedSelection(fld.ribbonName);

               for (var xi = 0; xi < fld.bSelVals.length; xi++)
                   fld.bSelVals[xi] = false;

               for (var xi = 0; xi < selvals.length; xi++) {
                   var accind = selvals[xi].value;
                   fld.bSelVals[accind] = true;
               }


           }
       }
   }
   OptimizerRibbon.prototype.applyFilters = function () {
       var item;
       var fld;
       var shakeitallabout;
       var fValue;

       this.piIn = new Array();
       this.piOut = new Array();
       this.runningPITotal = 0;

       this.CaptureFilters();


       for (var i = 0; i < this.Items.length; i++) {
           item = this.Items[i];

           item.stashsel = item.isSel;
           shakeitallabout = true;





           for (var n1 = 0; n1 < this.usingselectedFilters.length; n1++) {
               fld = this.usingselectedFilters[n1];

               if (fld.isNumeric) 
               {
                   fValue = item.Fields[fld.accind].Value;

                   if (fValue < fld.rangeMinValue || fValue > fld.rangeMaxValue) {
                       shakeitallabout = false;
                       break;
                   }


               } else 
               {
                   fValue = item.Fields[fld.accind].Value;


                   for (var xi = 0; xi < fld.bSelVals.length; xi++) {
                       if (fValue == fld.textVals[xi]) {
                           if (fld.bSelVals[xi] == false) {
                               shakeitallabout = false;
                               break;
                           }
                       }

                   }

               }
           }


           item.isFilterSel = shakeitallabout;

           if (item.statusMode == 1)
               shakeitallabout = true;
           else if (item.statusMode == 2)
               shakeitallabout = false;


           if (shakeitallabout == true) {
               if (this.totalField != null) {
                   this.runningPITotal += item.Fields[this.totalField.accind].Value;
               }

               item.isSel = true;
               this.piIn[this.piIn.length] = item;
           } else {
               this.piOut[this.piOut.length] = item;
               item.isSel = false;
           }

       }

   };

   OptimizerRibbon.prototype.PreRangeInput = function () {
       for (var n1 = 0; n1 < this.usingselectedFilters.length; n1++) {
           fld = this.usingselectedFilters[n1];

           if (fld.isNumeric == true) {

               popupInput(fld.ribbonName, 0);
 
           }
       }


   }
   OptimizerRibbon.prototype.RangeInput = function () {
       for (var n1 = 0; n1 < this.usingselectedFilters.length; n1++) {
           fld = this.usingselectedFilters[n1];

           if (fld.isNumeric == true) {

               popupInput(fld.ribbonName, 0);

               var ldcontainer = document.getElementById(fld.ribbonName + 'inputl');
               var rdcontainer = document.getElementById(fld.ribbonName + 'inputr');

               var ldscontainer = document.getElementById(fld.ribbonName + 'displ');
               var rdscontainer = document.getElementById(fld.ribbonName + 'dispr');


               var lv = parseFloat(ldcontainer.value);
               var rv = parseFloat(rdcontainer.value);
               var lvc = true;
               var rvc = true;

               if (lv < fld.minValue)
                   lv = fld.minValue;
               else if (lv > fld.maxValue)
                   lv = fld.maxValue;
               else if (lv > rv)
                   lv = rv;
               else
                   lvc = false;

               if (rv < fld.minValue)
                   rv = fld.minValue;
               else if (rv > fld.maxValue)
                   rv = fld.maxValue;
               else if (lv > rv)
                   rv = lv;
               else
                   rvc = false;


               ldcontainer.value = lv;
               rdcontainer.value = rv;

               if (fld.FTYPE == 8) {
                   ldscontainer.innerHTML = toPrettyString(lv, this.currprefix, this.currpostfix);
                   rdscontainer.innerHTML = toPrettyString(rv, this.currprefix, this.currpostfix);
               }
               else {
                   ldscontainer.innerHTML = toPrettyString(lv, "", "");
                   rdscontainer.innerHTML = toPrettyString(rv, "", "");
               }

               var totrng = fld.maxValue - fld.minValue;
               var lp = parseInt(((lv - fld.minValue) * 100) / totrng);
               var hp = parseInt(((rv - fld.minValue) * 100) / totrng);

               fld.rangeMinValue = this.GetMinVal(fld.ribbonName);
               fld.rangeMaxValue = this.GetMaxVal(fld.ribbonName);


               var container = $("#" + fld.ribbonName).parent();
               var val = container.find('.epm-slider-minval');
               val.html(lv);

               val = container.find('.epm-slider-maxval');
               val.html(rv);


               val = container.find('.epm-slider-buttonmin');
               val.css('left', lp);

               val = container.find('.epm-slider-buttonmax');
               val.css('left', hp - lp);



               val = container.find('.epm-slider-scalemiddle')
               val.css('left', lp);
               val.width(hp - lp);



           }
       }


   }
   
   OptimizerRibbon.prototype.clearFilters = function () {




       // reset the non-numeric fields
       for (var n1 = 0; n1 < this.usingselectedFilters.length; n1++) {
           fld = this.usingselectedFilters[n1];

           if (fld.isNumeric == false) {
               for (var xi = 0; xi < fld.bSelVals.length; xi++) {
                   fld.bSelVals[xi] = true;
               }

           }
           else {
               fld.rangeMaxValue = fld.maxValue;
               fld.rangeMinValue = fld.minValue;
               fld.posMaxValue = 94;
               fld.posMinValue = 0;
           }
       }

   };
    OptimizerRibbon.prototype.updateRibbonDueToUserChange = function () {

        var item;
        var fld;
        var shakeitallabout;
        var fValue;

        this.piIn = new Array();
        this.piOut = new Array();
        this.runningPITotal = 0;

        for (var i = 0; i < this.Items.length; i++) {
            item = this.Items[i];
            shakeitallabout = true;


            if (item.isSel == true) {
                if (this.totalField != null) {
                    this.runningPITotal += item.Fields[this.totalField.accind].Value;
                }

                this.piIn[this.piIn.length] = item;
            } else {
                this.piOut[this.piOut.length] = item;
            }

            this.updateProgressRibbon(true);

        }
    }
    OptimizerRibbon.prototype.updateProgressRibbon = function (bApplyDelay) {

        var remVal = 0;
        var tarval = this.optTab.GetTargetInput("opttar");

        var tv;

        if (isNaN(tarval) || tarval == "")
            tv = 0;
        else
            tv = parseFloat(tarval);

        this.targetValue = tv;

        this.targetRemaining = tv - this.runningPITotal;
        
        if (bApplyDelay)
            window.setTimeout(this.flashRemainingValueDelegate, 10);
        else
            this.flashRemainingValue();


    }
    OptimizerRibbon.prototype.flashRemainingValue = function () {

        var iprog = 0;

        if (this.targetValue != 0) {
            iprog = Math.abs(this.runningPITotal / this.targetValue) * 100;

            if (iprog > 100)
                iprog = 100;
            else
                iprog = Math.round(iprog);
        }
        else if (this.runningPITotal > 0)
            iprog = 100;

        this.optTab.SetTargetRemaining("opttar", this.targetRemaining, this.runningPITotal, iprog, (this.targetRemaining < 0));
    }

    OptimizerRibbon.prototype.flashTabRibbon = function () {
        try {
 //           this.Tabbar.removeTab("tab_Opt", false);

            this.Tabbar.clearAll();
            this.Tabbar.setImagePath("/_layouts/epmlive/dhtml/xtab/imgs/");
            this.Tabbar.enableAutoReSize();


  //          this.Tabbar.addTab("tab_Opt", "Optimizer", 70, 0);

            var rdiv = this.optTab.getRibbonDiv();
            this.Tabbar.setContent("tab_Opt", rdiv);

 //           this.Tabbar.setTabActive("tab_Opt");
            this.Tabbar.enableScroll(false);
        }
        catch (e) {
            var x = e;
        }

    }  
    
    OptimizerRibbon.prototype.DeferInitialTabRibbon = function () {
        try {

            this.optTab.DeferredMultiSelect();
        }
        catch (e) { }

    }

    OptimizerRibbon.prototype.flashCurrentStratagies = function () {

        var select = document.getElementById("idOptTab_SelView");

        if (select == null)
            return;

        if (select.options.length != 0)
            select.options.length = 0;

        var csg;

        if (this.currStratagy == null)
            csg = "";
        else {
            csg = this.currStratagy.StratagyGUID
        }

        for (var i = 0; i < this.Stratagies.length; i++) {
            var Strat = this.Stratagies[i];
            select.options[select.options.length] = new Option(Strat.Name, Strat.StratagyGUID, Strat.StratagyGUID == csg, Strat.StratagyGUID == csg);
        }

        this.currStratagy = this.GetSelectedStratagy();
    }


    OptimizerRibbon.prototype.constructReturnRequest = function (mode, action, data) {
        var retval = new Object;

        retval.Mode = mode;
        retval.Action = action;
        retval.Data = data;
        retval.Passback = false;
        retval.PassbackFunction = "";

        return retval;
    }
    OptimizerRibbon.prototype.getOptimizerDlgInjectHtml = function () {
        return DlgHtmlInject();
    };
    OptimizerRibbon.prototype.getOptimizerRibbon = function (sRibbonDiv, sonstatechange, simagePath, tabbar,  viewTab) {

        this.sRibbonDiv = sRibbonDiv;
        this.sonstatechange = sonstatechange;
        this.simagePath = simagePath;
        this.Tabbar = tabbar;
 //       this.tabopt = tabopt;
        this.viewTab = viewTab

        var sJSON = this.getOptimizerRibbonJSON();

        this.optTab = new Ribbon(sJSON);

        this.updateRibbonDueToUserChange();

        this.optTab.Render();

        this.flashCurrentStratagies();


        this.Tabbar.setImagePath("/_layouts/epmlive/dhtml/xtab/imgs/");
        this.Tabbar.enableAutoReSize();
        this.Tabbar.addTab("tab_Opt", "Optimizer", 70);
        this.Tabbar.setContent("tab_Opt", this.optTab.getRibbonDiv());
        this.Tabbar.addTab("tab_View", "View", 70);
        this.Tabbar.setContent("tab_View", this.viewTab.getRibbonDiv());
 //       window.setTimeout(this.DeferInitialTabRibbonDelegate, 1000);


        return this.optTab;
    }
    OptimizerRibbon.prototype.getOptimizerRibbonJSON = function () {

        var tarpre = "";
        var tarpost = "";

        if (this.totalField != null) {
            if (this.totalField.FTYPE == 8) {
                tarpre = this.currprefix;
                tarpost = this.currpostfix;
            }

        }





        var OptimizerTabData = {
            parent: this.sRibbonDiv,
            style: "display:none;",
            showstate: "true",
            initialstate: "expanded",
            onstatechange: this.sonstatechange,
            imagePath: this.simagePath,
            sections: [
					{
					    name: "Actions",
					    columns: [
							{
							    items: [
									{ type: "bigbutton", name: "Close", img: "close32.gif", tooltip: "Close", onclick: "OptimizerEvent('OptClose');" }
								]
							},
							{
							    items: [
									{ type: "bigbutton", name: "Configure", img: "configure.png", tooltip: "Configure", onclick: "OptimizerEvent('OptEditScen');" }
								]
							},
							{
							    items: [
									{ type: "smallbutton", id: "idptSaveScen", img: "createview.gif", name: "Save Strategy", tooltip: "Save Strategy", onclick: "OptimizerEvent('OptSaveScen');" },
								    { type: "smallbutton", id: "idrenamestrat", name: "Rename Strategy", img: "editview.gif", tooltip: "Rename Strategy", onclick: "OptimizerEvent('OptRenScen');" },
									{ type: "smallbutton", id: "idptDelScen", img: "deleteview.gif", name: "Delete Strategy", tooltip: "Delete Strategy", onclick: "OptimizerEvent('OptDelScen');" }
								]
							},
					        {
					            items: [
									{ type: "smallbutton", id: "idptCmtScen", img: "createview.gif", name: "Commit Strategy", tooltip: "Commit Strategy", disabled: this.notgotOptimzerFlag, onclick: "OptimizerEvent('OptCmtScen');"}]
					        },
                            {
                                items: [
                                    { type: "text", name: "Current Strategy:" }
                                ]
                            },
							{
							    items: [

									{ type: "select", id: "idOptTab_SelView", onchange: "OptimizerEvent('OptSelStrat_Changed');", width: "100px" }
							   ]
							}
						]
					},
	                {
	                    name: "Comparison",
	                    columns: [
							{
							    items: [
							        { type: "optirp", id: "opttar", onchange: 'OptimizerEvent("OptUpdateProgress");', title: this.ConfNameValue, targetValue: this.targetValue, targetRemaining: this.targetRemaining, targetPrefix: tarpre, targetPostfix: tarpost }
								]
							}
	                    ]
	                }
				]
        };




        var sections = OptimizerTabData.sections;
        var columns = null;


        if (this.usingselectedFilters.length == 0) {
            var sObj = new Object;

            sObj.name = "Filters";
            columns = new Array();
            sObj.columns = columns;
            sections[sections.length] = sObj;

            var addme = new Object;


            addme.id = "idNoFilters";
            addme.name = "No Filters have been created";
            addme.tooltip = "No Filters have been created";
            addme.type = "text";


            columns[0] = new Object;
            columns[0].items = new Array;
            columns[0].items[0] = addme;

        }
        else {
            var sObj = new Object;

            sObj.name = "Filters";
            columns = new Array();
            sObj.columns = columns;
            sections[sections.length] = sObj;

            var xacc = 0;
            var cacc = -1;



            for (var n1 = 0; n1 < this.usingselectedFilters.length; n1++) {
                var fld = this.usingselectedFilters[n1];
                var cId = fld.FID;
                var cName = fld.FName;
                var cEvent = "OptiChange";
                var cbuttonID = "idFilter" + n1;

                fld.ribbonName = cbuttonID;

                if (xacc == 0) {
                    ++cacc;
                    columns[cacc] = new Object;
                    columns[cacc].items = new Array;
                }

                var addme = new Object;



                addme.id = cbuttonID;
                addme.name = cName;
                addme.tooltip = "Filter " + cName;
                addme.onclick = "OptimizerEvent('OptiChange');";

                if (fld.isNumeric) {
                    addme.type = "slider";
                    addme.onchange = 'OptimizerEvent("OptiChange");';
                    addme.oninput = 'OptimizerEvent("OptiInput");';
                    addme.onpreinput = 'OptimizerEvent("OptiPreInput");';
                    addme.onclickfrom = 'OptimizerEvent("OptiClickFrom' + n1 + '");';
                    addme.onclickto = 'OptimizerEvent("OptiClickTo' + n1 + '");';
                    addme.minValue = fld.minValue;
                    addme.maxValue = fld.maxValue;
                    addme.rangeminValue = fld.rangeMinValue;
                    addme.rangemaxValue = fld.rangeMaxValue;
                    addme.posminValue = fld.posMinValue;
                    addme.posmaxValue = fld.posMaxValue;

                    addme.sliderPrefix = "";
                    addme.sliderPostfix = "";

                    if (fld.FTYPE == 8) {

                        addme.sliderPrefix = tarpre;
                        addme.sliderPostfix = tarpost;
                    }



                    var idif = Math.abs(fld.maxValue - fld.minValue);

                    if (idif <= 10)
                        addme.step = 1;
                    else if (idif <= 100)
                        addme.step = 1;
                    else if (idif <= 1000)
                        addme.step = 10;
                    //                    else if (idif <= 10000)
                    //                        addme.step = 1000;
                    //                    else if (idif <= 100000)
                    //                        addme.step = 10000;
                    else
                        addme.step = idif / 100;

                    //addme.step = 100000;

                }
                else {
                    addme.type = "multicombo";

                    var sopt = "";

                    for (var xi = 0; xi < fld.textVals.length; xi++) {

                        if (fld.bSelVals[xi] == true)
                            sopt = sopt + "<option value = '" + xi + "' selected='selected' >" + fld.textDispVals[xi] + "</option>";
                        else
                            sopt = sopt + "<option value = '" + xi + "'>" + fld.textDispVals[xi] + "</option>";
                    }

                    addme.options = sopt;



                }

                columns[cacc].items[xacc++] = addme;

                if (xacc >= 1)
                    xacc = 0;
            }

            ++cacc;
            columns[cacc] = new Object;
            columns[cacc].items = new Array;

            //            var addme = new Object;
            //            addme.id = "idApplyOptFilters";
            //            addme.name = "Apply Filters";
            //            addme.tooltip = "Apply Filter ";
            //            addme.onclick = "OptimizerEvent('OptApplyFilters');";

            //            addme.type = "smallbutton";
            //            columns[cacc].items[0] = addme;

            var addme = new Object;
            addme.id = "idClearyOptFilters";
            addme.name = "Clear";
            addme.tooltip = "Clear Filter ";
            addme.onclick = "OptimizerEvent('OptClearFilters');";
            addme.img = "filter.png";
            addme.type = "smallbutton";
            columns[cacc].items[0] = addme;

        }





        return OptimizerTabData;

    };
    OptimizerRibbon.prototype.showOptDialog = function (idDiv) {

        if (this.Items.length == 1) {
            alert("You cannot Optimize only one Item!");
            return;
        }







        if (this.CostnNumbers.length == 0) {
            alert("No Cost or Number fields have been defined - so it is not possible to display the Optimizer Configuration Dialog");
            return;
        }


        try {



            if (this.OptDlg == null) {



                this.OptDlg = new dhtmlXWindows();
                this.OptDlg.setSkin("dhx_web");

                this.OptDlg.enableAutoViewport(false);
                this.OptDlg.attachViewportTo(this.params.ClientID + "mainDiv");
                this.OptDlg.setImagePath(this.imagePath);
                this.OptDlg.createWindow("winOptDlg", 20, 30, 594, 508);
                //               this.OptDlg.window("winOptDlg").setIcon("logo.ico", "logo.ico");
                this.OptDlg.window("winOptDlg").allowMove();
                this.OptDlg.window("winOptDlg").denyResize();
                this.OptDlg.window("winOptDlg").setModal(true);
                this.OptDlg.window("winOptDlg").center();
                this.OptDlg.window("winOptDlg").setText("Optimizer Configuration");
                this.OptDlg.window("winOptDlg").attachObject(idDiv);
                this.OptDlg.window("winOptDlg").button("close").disable();
                this.OptDlg.window("winOptDlg").button("park").hide();

                //       document.getElementById("dhxMainCont").style.border = "none";


            }
            else
                this.OptDlg.window("winOptDlg").show();

            this.OptConfLoading = true;

            var fld;

            if (this.totalField == null) {

                // make the first custom cost or number field the default one 

                for (var c = 0; c < this.CostnNumbers.length; c++) {
                    fld = this.CostnNumbers[c];
                    if (fld.FID > 10000) {
                        this.totalField = fld;
                        break;
                    }
                }
            }

            if (this.totalField == null)    // no custom fields so select the first one anyway
                this.totalField = this.CostnNumbers[0];

            var costSelect = document.getElementById("idOptConfTotalField");

            costSelect.options.length = 0;

            for (var c = 0; c < this.CostnNumbers.length; c++) {
                fld = this.CostnNumbers[c];
                costSelect.options[c] = new Option(fld.FName, fld.FID, fld.FID == this.totalField.FID, fld.FID == this.totalField.FID);
            }

            var confVal = document.getElementById("idOptConfNameValue");

            confVal.value = this.ConfNameValue;

            this.TotAddSel = null;
            this.TotRemSel = null;

            this.selectedFilters = new Array();

            for (var c = 0; c < this.usingselectedFilters.length; c++) {
                this.selectedFilters[c] = this.usingselectedFilters[c];
            }

            window.setTimeout(this.FinishOptConfDelegate, 10);
        }
        catch (e) {
            alert("Optimizer showOptDialog error " + e.toString());

            if (this.OptDlg != null) {
                this.OptDlg.window("winOptDlg").detachObject()
                this.OptDlg.window("winOptDlg").close();
                this.OptDlg = null;
            }
        }

        this.OptConfLoading = false;
    }
    OptimizerRibbon.prototype.setNewButtonDisable = function (idButton, bstate) {

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
    OptimizerRibbon.prototype.FinishOptConf = function () {
        if (this.OptConfLoading == true)
            return;

        var selAvail = document.getElementById('idOptConfAvailfields');
        var selSelected = document.getElementById('idOptConfSelfields');
        var moveupbtn = document.getElementById('idOptConfSelectedColsMoveUp');
        var movedownbtn = document.getElementById('idOptConfSelectedColsMoveDown');


        selAvail.options.length = 0;
        selSelected.options.length = 0;


        this.addbtndisabled = (this.TotAddSel == null);
        this.setNewButtonDisable('idOptConfAdd', this.addbtndisabled);

        this.rembtndisabled = (this.TotRemSel == null);
        this.setNewButtonDisable('idOptConfRemove', this.rembtndisabled);

        var i;
        var item;
        var bSel = false;
        var bfound = false;
        var selval;

        for (i = 0; i < this.selectedFilters.length; i++) {
            item = this.selectedFilters[i];
            item.selected = true;
            bSel = false;

            if (this.TotRemSel != null)
                bSel = (item.FID == this.TotRemSel.FID);

            bfound |= bSel;

            if (bSel)
                selval = i;

            selSelected.options[i] = new Option(item.FName, item.FID, bSel, bSel);
            selSelected.options[i].style.color = "#444444";
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

        var n1 = 0;

        for (i = 0; i < this.DisplayableFields.length; i++) {
            item = this.DisplayableFields[i];
            if (item.selected == false) {
                bSel = false;

                if (this.TotAddSel != null)
                    bSel = (item.FID == this.TotAddSel.FID);

                bfound |= bSel;

                selAvail.options[n1] = new Option(item.FName, item.FID, bSel, bSel);
                selAvail.options[n1++].style.color = "#444444";
            }
        }

        if (bfound == false)
            this.TotAddSel = null;

    }
    OptimizerRibbon.prototype.OptConfCols_ButtonClick = function (iDir) {
        var selAvail = document.getElementById('idOptConfAvailfields');
        var selSelected = document.getElementById('idOptConfSelfields');
        var i;
        var j;
        var item;

        if (iDir == 1) {
            var iRemColID;

            for (i = 0; i <= selSelected.options.length - 1; i++) {
                if (selSelected.options[i].selected == true) {

                    iRemColID = selSelected.options[i].value;

                    if (selSelected.options.length == 2) {
                        this.TotRemSel = null;
                    }
                    else if (i == selSelected.options.length - 1) {
                        if (i > 0)
                            selSelected.options[i - 1].selected = true;
                    }
                    else
                        selSelected.options[i + 1].selected = true;

                    selSelected.remove(i);
                    break;
                }
            }

            var newArr = new Array();

            for (i = 0; i < this.selectedFilters.length; i++) {
                item = this.selectedFilters[i];

                if (iRemColID == item.FID) {
                    item.selected = false;
                    this.TotAddSel = item;
                } else {
                    newArr[newArr.length] = item;
                }

            }
            this.selectedFilters = newArr;

            window.setTimeout(this.FinishOptConfDelegate, 10);
            return;

        }

        // iDir = 0 - so Add a column to the selected list...

        for (i = 0; i <= selAvail.options.length - 1; i++) {

            if (selAvail.options[i].selected == true) {
                var iAddColID = selAvail.options[i].value;

                if (selAvail.options.length == 1) {
                    this.TotAddSel = null;
                } else if (i == selAvail.options.length - 1)
                    selAvail.options[i - 1].selected = true;
                else
                    selAvail.options[i + 1].selected = true;

                selAvail.remove(i);
                break;


            }
        }

        for (i = 0; i < this.DisplayableFields.length; i++) {
            item = this.DisplayableFields[i];

            if (iAddColID == item.FID) {
                item.selected = true;
                this.TotRemSel = item;
                this.selectedFilters[this.selectedFilters.length] = item;
                break;
            }
        }

        for (i = 0; i <= selAvail.options.length - 1; i++) {

            if (selAvail.options[i].selected == true) {

                for (j = 0; j <= this.DisplayableFields.length; j++) {
                    item = this.DisplayableFields[j];
                    if (item.FID == selAvail.options[i].value) {
                        this.TotAddSel = item;
                        break;
                    }
                }
            }
        }


        window.setTimeout(this.FinishOptConfDelegate, 10);
        return;
    }
    OptimizerRibbon.prototype.OptConfSelColsMove_ButtonClick = function (iallezup) {
        var selSelected = document.getElementById('idOptConfSelfields');
        var moveupbtn = document.getElementById('idOptConfSelectedColsMoveUp');
        var movedownbtn = document.getElementById('idOptConfSelectedColsMoveDown');

        var i;
        var selival;
        var swapval;


        for (i = 0; i < selSelected.options.length; i++) {

            if (selSelected.options[i].selected == true) {
                selival = i;
                break;
            }
        }

        if (iallezup == 1) {
            if (selival == 0)
                return;

            swapval = this.selectedFilters[selival];
            this.selectedFilters[selival] = this.selectedFilters[selival - 1];
            this.selectedFilters[selival - 1] = swapval;
        }
        else {
            if (selival == selSelected.options.length - 1)
                return;

            swapval = this.selectedFilters[selival];
            this.selectedFilters[selival] = this.selectedFilters[selival + 1];
            this.selectedFilters[selival + 1] = swapval;
        }

        window.setTimeout(this.FinishOptConfDelegate, 10);

    }
    function ThisTypeNumeric(fldtype)
        {

            switch (fldtype)
            {


                case "20":
                case "23":  
                case "2":
                case "3":
                case "8":
                case "11":
                    return true;
            }
            return false;
        }
    function DlgHtmlInject  () {        
        var sInject = new StringBuilder();
            
        sInject.append('<div class="modalText" style="margin-top:10px;padding-right:10px;">');
        sInject.append('  <div style="display:relative;vertical-align:middle;padding-bottom:20x;padding-left:12px!important;">');
        sInject.append('	1) Which field will be totaled and used to compare to the manually entered value?<br>');
        sInject.append('<br>');
        sInject.append('  </div>');
        sInject.append('  <div style="padding-left:12px!important;">');
        sInject.append('    <select id="idOptConfTotalField" name="idOptTotalField" style="vertical-align:middle;padding:0px;margin:0px;" ></select>');
        sInject.append('  </div>'); 
        sInject.append('  <br />');
        sInject.append('  <div style="display:relative;vertical-align:middle;padding-bottom:20px;padding-left:12px!important;">');
        sInject.append('	2) Enter a title for the comparison field.');
        sInject.append('  </div>');
        sInject.append('  <div style="padding-left:12px!important;">');
        sInject.append('	<input id="idOptConfNameValue" type="text" value=" " style="width:210px;text-align:left;padding:0px;margin:0px;height:20px;" />');
        sInject.append('  </div>');
        sInject.append('  <br />');
        sInject.append('  <div style="padding-left:12px!important;">');
        sInject.append('    <div style="display:relative;vertical-align:middle;padding-bottom:20px;">');
        sInject.append('	  3) Which fields will be used as filters?');
        sInject.append('    </div>');        
        sInject.append('    <table cellspacing="0" cellpadding="0" style="width:100%; display: block;">');
        sInject.append('        <tr>');
        sInject.append('            <td style="padding-bottom:3px;">Available Fields</td>');
        sInject.append('            <td> </td>');
        sInject.append('            <td style="padding-left:10px;padding-bottom:3px;">Selected Fields</td>');
        sInject.append('        </tr>');
        sInject.append('        <tr>');
        sInject.append('            <td style="width:160px;padding-right:10px;">');
        sInject.append('                <select style="width:200px;height:140px;padding:0px;margin:0px;border:1px solid #CCCCCC;" size="10" id="idOptConfAvailfields" name="idOptAvailflds" onchange="OptimizerEvent(\'OptConfEnableAdd\');" ondblclick="OptimizerEvent(\'OptConfAddCol_Click\');"/> ');
        sInject.append('            </td>');
        sInject.append('             <td width=\'30px\' align=\'center\'>');
        sInject.append('                <table>');
        sInject.append('                    <tr>');
        sInject.append('                        <td>');
        sInject.append('                            <div class="button-containerVert">');
        sInject.append('				               <input id="idOptConfAdd" type="button" onclick="javascript: OptimizerEvent(\'OptConfAddCol_Click\');" class="epmliveButton" value="Add >"/>');
        sInject.append('			');
        sInject.append('		                    </div>');
        sInject.append('                        </td>');
        sInject.append('                    </tr>');
        sInject.append('                    ');
        sInject.append('                   <tr>');
        sInject.append('                        <td>');
        sInject.append('		                    <div class="button-containerVert">');
        sInject.append('				                <input id="idOptConfRemove" type="button" onclick="javascript: OptimizerEvent(\'OptConfRemoveCol_Click\');" class="epmliveButton" value="< Remove"/>');
        sInject.append('		                    </div>');
        sInject.append('                        </td>');
        sInject.append('                    </tr>');
        sInject.append('                </table>');
        sInject.append('            </td>');
        sInject.append('            <td style="width:160px;padding-left:10px;">');
        sInject.append('                <select style="width:200px;height:140px;padding:0px;margin:0px;border:1px solid #CCCCCC;" size="10" id="idOptConfSelfields" name="idOptConfSelfields" onchange="OptimizerEvent(\'OptConfEnableRemove\');"  ondblclick="OptimizerEvent(\'OptConfRemoveCol_Click\');"/> ');
        sInject.append('            </td>');
        sInject.append('            <td width="20px" align="center" style="padding-left:5px;">');
        sInject.append('                <table>');
        sInject.append('                    <tr>');
        sInject.append('                         <td id="idOptConfSelectedColsMoveUp" class="bb_buttonframe" onclick="OptimizerEvent(\'OptConfSelectMoveUp\');" style="padding-top: 3px; padding-left: 2px;">');
        sInject.append('                         <img style="cursor:pointer;" class="bb_buttonimage" src="/_layouts/ppm/images/Arrow Up Lg.gif" alt=""/>');
        sInject.append('                        </td>');
        sInject.append('                    </tr>');
        sInject.append('                    ');
        sInject.append('                   <tr>');
        sInject.append('                        <td id="idOptConfSelectedColsMoveDown" class="bb_buttonframe" onclick="OptimizerEvent(\'OptConfSelectMoveDown\');" style="padding-top: 3px; padding-left: 2px;">');
        sInject.append('                        <img style="cursor:pointer;" class="bb_buttonimage" src="/_layouts/ppm/images/Arrow Down Lg.gif" alt=""/>');
        sInject.append('                         </td>');
        sInject.append('                    </tr>');
        sInject.append('                </table>');
        sInject.append('            </td>');
        sInject.append('');
        sInject.append('       </tr>');
        sInject.append('    </table>');
        sInject.append('    <br />');
        sInject.append('Selecting more fields that can fit in to the space available in the filter section on the ribbon bar, will cause the filter section to not appear.  If this occurs, then reduce the number of fields selected until it does appear.');
        sInject.append('    <br />');
        sInject.append('    <div style="width:200px;float:right;margin-top:17px;">');
        sInject.append('	    <div class="button-container">');
        sInject.append('		    <input type="button" onclick="javascript: OptimizerEvent(\'OptConfOK_Click\');" class="epmliveButton" value="OK"/>');
        sInject.append('		    <input type="button" onclick="javascript: OptimizerEvent(\'OptConfCancel_Click\');" class="epmliveButton" value="Cancel"/>');
        sInject.append('	    </div>');
        sInject.append('    </div>');
        sInject.append('</div>');

        
        return sInject.toString();

    }
    OptimizerRibbon.prototype.getOptimizerPIItems = function () {

        return this.Items
    }
    var MakeDelegate = function (target, method) {
        if (method === null) {
            throw ("Method not found");
        }

        return function () {
            return method.apply(target, arguments);
        }
    }

    try {

        this.EditRangeDlg = null;
        this.rangefld = null;

        this.notgotOptimzerFlag = true;
        this.piIn = new Array();
        this.piOut = new Array();
        this.runningPITotal = 0;
        this.targetValue = 0;
        this.targetRemaining = 0;

        this.Stratagies = new Array();
        this.currStratagy = null;
        this.SaveStratDlg = null;
        this.RenameStratDlg = null;

        this.params = params;
        this.totalField = null;
        this.dlgdiv = sdlgDiv;

        this.passbackresult = "";

        this.FinishOptConfDelegate = MakeDelegate(this, this.FinishOptConf);
        this.flashRemainingValueDelegate = MakeDelegate(this, this.flashRemainingValue);
        this.flashTabRibbonDelegate = MakeDelegate(this, this.flashTabRibbon);
        this.DeferInitialTabRibbonDelegate = MakeDelegate(this, this.DeferInitialTabRibbon);
   
        this.TotAddSel = null;
        this.TotRemSel = null;

        this.OptDlg = null;
        this.ConfNameValue = "";

        this.OptData = inOptData;
        this.Fields = JSON_GetArray(this.OptData.Fields, "Field");
        this.Items = JSON_GetArray(this.OptData.Items, "Item");
        this.DisplayableFields = new Array();
        var item;
        var ifld;


        this.curr_pos = 0;
        this.curr_digits = 2;
        this.curr_sym = "$";
        this.currprefix = "$";
        this.currpostfix = "";
        
        try {
            this.curr_pos = this.OptData.Currency.Pos;
            this.curr_sym = this.OptData.Currency.Sym;
            this.curr_digits = this.OptData.Currency.Digits;

            if (this.curr_pos == 0)
                this.currprefix = this.curr_sym;
            else if (this.curr_pos == 2)
                this.currprefix = this.curr_sym + " ";
            else 
                this.currprefix = "";

            if (this.curr_pos == 1)
                this.currpostfix = this.curr_sym;
            else if (this.curr_pos == 3)
                this.currpostfix = " " +  this.curr_sym;
            else 
                this.currpostfix = "";    
      
        }
        catch(e) {

        }


        for (var i = 0; i < this.Items.length; i++) {
            item = this.Items[i];
            item.statusMode = 3;
            item.isSel = true;
            item.isFilterSel = true;
            item.Fields = JSON_GetArray(item.Fields, "Field");
            item.rowid = "";

        }

        this.CostnNumbers = new Array();
        this.selectedFilters = new Array();
        this.usingselectedFilters = new Array();

        for (var fi = 0; fi < this.Fields.length; fi++) {
            var fld = this.Fields[fi];

            if (fld.FOPTFLAG == 1)
                this.notgotOptimzerFlag = false;               

            fld.FID = parseInt(fld.FID);
            fld.accind = fi;
            fld.selected = false;

            fld.isNumeric = ThisTypeNumeric(fld.FTYPE);

            if (fld.isNumeric) {
                fld.minValue = 0;
                fld.maxValue = 0;

                fld.rangeMaxValue = 0;
                fld.rangeMinValue = 0;

                for (var i = 0; i < this.Items.length; i++) {
                    item = this.Items[i];
                    ifld = item.Fields[fi];

                    var iVal = parseFloat(ifld.Value);

                    ifld.Value = iVal;

                    if (i == 0) {
                        fld.minValue = iVal;
                        fld.maxValue = iVal;
                    } else {
                        fld.minValue = Math.min(iVal, fld.minValue);
                        fld.maxValue = Math.max(iVal, fld.maxValue);
                    }
                }
                


                fld.rangeMaxValue = fld.maxValue;
                fld.rangeMinValue = fld.minValue;

                fld.posMinValue = 0;
                fld.posMaxValue = 94;

                if (fld.minValue != fld.maxValue) {
                    this.DisplayableFields[this.DisplayableFields.length] = fld;
                    if (fld.FTYPE == "3" || fld.FTYPE == "8") {
                        this.CostnNumbers[this.CostnNumbers.length] = fld;
                        if (this.totalField == null)
                            this.totalField = fld;
                    }
                }
            } else {
                fld.textVals = new Array();
                fld.textDispVals = new Array();
                fld.bSelVals = new Array();

                for (var i = 0; i < this.Items.length; i++) {
                    item = this.Items[i];
                    ifld = item.Fields[fi];

                    var sVal = ifld.Value;

                    var bfnd = false;

                    for (var li = 0; li < fld.textVals.length; li++) {
                        if (fld.textVals[li] == sVal) {
                            bfnd = true;
                            break;
                        }
                    }

                    if (bfnd == false) {
                        fld.textVals[fld.textVals.length] = sVal;
                        fld.bSelVals[fld.bSelVals.length] = true;
                        fld.textDispVals[fld.textDispVals.length] = (sVal == "" ? "No Value" : sVal);

                    }
                }

                if (fld.FOPTFLAG != 1) {

                    if (fld.textVals.length > 1)
                        this.DisplayableFields[this.DisplayableFields.length] = fld;
                    else if (fld.textVals.length == 1 && fld.textVals[0] != "")
                        this.DisplayableFields[this.DisplayableFields.length] = fld;
                    else if (fld.FTYPE == 13)
                        this.DisplayableFields[this.DisplayableFields.length] = fld;

                }
            }

        }
        
        // by now we have the data ranges for the numeric stuff and the list of unique text values for all the items brought in!

        item = 0;


    }
    catch (e) { }
}

