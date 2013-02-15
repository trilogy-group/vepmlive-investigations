function EditCalendar(thisID, params) {
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


    EditCalendar.prototype.OnLoad = function (event) {
	    try {

	        Grids.OnValueChanged = GridsOnValueChangedDelegate;
            Grids.OnClickCell = GridsOnClickCellDelegate;
            Grids.OnAfterColResize = GridsOnAfterColResizeDelegate;
            Grids.OnReady = GridsOnReadyDelegate;
            Grids.OnGetDefaultColor = GridsOnGetDefaultColorDelegate;


	        WorkEnginePPM.EditCalendar.set_path(this.params.Webservice);


	        WorkEnginePPM.EditCalendar.ExecuteJSON("GetCalendarInfo", "", GetCalendarInfoCompleteDelegate);
	    }
	    catch (e) {
	        alert("Edit Calendar OnLoad Exception");
	    }
	}

	EditCalendar.prototype.OnUnload = function (event) {
		if (this.Dirty && this.ExitConfirmed == false)
			event.returnValue = "You have unsaved changes.\n\nAre you sure you want to exit without saving?";
		this.ExitConfirmed = false;
	}


    EditCalendar.prototype.OnResize = function (event) {
	    if (this.initialized == true) {
	        //var toolbarDataObjectDiv = document.getElementById("toolbarDataObjectDiv");
	        var lHeight = this.Height;
	        var divLayout = document.getElementById(this.params.ClientID + "layoutDiv");
	        if (lHeight > 300) {
	            divLayout.style.height = (lHeight /*- toolbarDataObjectDiv.offsetHeight*/ - 12) + "px";
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
	}


	EditCalendar.prototype.SetSize = function (nWidth, nHeight) {

	    if (this.Width == nWidth && this.Height == nHeight)
	        return;

	    this.Width = nWidth;
	    this.Height = nHeight;
	    this.OnResize();
	}

	EditCalendar.prototype.GridsOnAfterColResize = function (grid, col) {
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

	EditCalendar.prototype.GridsOnClickCell = function (grid, row, col) {
	    this.curr_grid_row = row;
	}


	EditCalendar.prototype.GetCalendarInfoComplete = function (jsonString) {

	    try {
	        var jsonObject = JSON_ConvertString(jsonString);
	        if (JSON_ValidateServerResult(jsonObject)) {
	            this.CalInfo = JSON_GetArray(jsonObject.Result.Calendars, "Calendar");

	            this.InitializeLayout();
	        }
	    }

	    catch (e) {
	        alert("Edit Calendar  GetCalendarInfoComplete error " + e.toString());

	        if (SP.UI.DialogResult)
	            SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');
	        else
	            SP.UI.ModalDialog.commonModalDialogClose(0, '');
	    }

	    return;
	}

	EditCalendar.prototype.SaveCalData = function () {

	    var sbd = new StringBuilder();
	    sbd.append('<Calendar ID="' + this.EditCal + '">');
	    sbd.append('<Periods>');

	    for (var j = 1; j <= this.CalDat.pers.length; j++) {
	        var per = this.CalDat.pers[j - 1];
	        sbd.append('<Period ');
	        sbd.append(' ID="' + j + '"');
	        sbd.append(' Name="' + per.Name + '"');
	        sbd.append(' StartDate="' + per.StartDate + '"');
	        sbd.append(' FinishDate="' + per.FinishDate + '"');
	        sbd.append('/>');
	    }

	    sbd.append('</Periods>');


	    sbd.append('</Calendar>');

	    this.CalDat.bChanged = false

	    WorkEnginePPM.EditCalendar.Execute("SetCalendarData", sbd.toString());

	}

	EditCalendar.prototype.GetRootIdFromIdName = function (idname) {
        // ids in form of g_1
        var s = idname.split("_");
        return s[1];
    }

    EditCalendar.prototype.tabbarOnSelect = function (id, data) {

        if (this.CalDat != null) {

            if (this.CalDat.bChanged == true) {
                alert("You must save your changes to this calendar or close to cancel edits before switching to another calendar!");
                return false;
            }

        }


        this.currtab = id;
        var rootid = this.GetRootIdFromIdName(id);
        var grid = Grids["g_" + rootid];

        this.CalDat = null;
        this.curr_grid_row = null;

        for (var n = 0; n < this.CalInfo.length; n++) {
            var cal = this.CalInfo[n];
            var Id = cal.ID;

            if (Id == rootid) {
                this.CalDat = cal;
                break;
            }
        }

        this.EditCal = rootid;

        if (grid == null) {

            var sbDataxml = new StringBuilder();

            sbDataxml = new StringBuilder();
            sbDataxml.append('<![CDATA[');
            sbDataxml.append('<Execute Function="GetCalendarPeriodsGrid">');
            sbDataxml.append('</Execute>');
            sbDataxml.append(']]>');

            sb = new StringBuilder();
            sb.append("<treegrid debug='1' sync='0' ");
            sb.append(" data_url='" + this.Webservice + "'");
            sb.append(" data_method='Soap'");
            sb.append(" data_function='Execute'")
            sb.append(" data_namespace='WorkEnginePPM'");
            sb.append(" data_param_Function='GetCalendarPeriodsGrid'");
            sb.append(" data_param_Dataxml='" + sbDataxml.toString() + "'");
            sb.append(" >");
            sb.append("</treegrid>");



            TreeGrid(sb.toString(), "gridDiv_" + rootid, "g_" + rootid);

        }
        else {
            grid.SelectAllRows(0);
        }

        this.CalendarGrid = Grids["g_" + rootid];

        return true;
   }


	EditCalendar.prototype.InitializeLayout = function () {
	    try {
	        var PeriodTabData = {
	            parent: "idPeriodTabDiv",
	            style: "display:none;",
	            imagePath: this.imagePath,
	            sections: [
                    { name: "General",
                        columns: [
                            {
                                items: [
                                    { type: "bigbutton", name: "Close", img: "close32.gif", tooltip: "Close", onclick: "dialogEvent('PeriodTab_Close');" }
                                ]
                            },
                            {
                                items: [
                                    { type: "bigbutton", id: "SaveBtn", name: "Save", img: "save32x32.png", tooltip: "Save", onclick: "dialogEvent('PeriodTab_Save');", disabled: true }
                                ]
                            },
                            {
                                items: [
                                    { type: "bigbutton", id: "NewBtn", name: "New", img: "save32x32.png", tooltip: "New", onclick: "dialogEvent('PeriodTab_New');" }
                                ]
                            },                            
                            {
                                items: [
                                    { type: "bigbutton", id: "DelBtn", name: "Delete", img: "Delete.gif", tooltip: "Delete", onclick: "dialogEvent('PeriodTab_Delete');" }
                                ]
                            }
                        ]
                    },
                    {
                        columns: [
                            {
                                items: [
                                    { type: "smallbutton", id: "AppenedPerBtn", name: "Append", img: "refresh.gif", tooltip: "Append a new period ", onclick: "dialogEvent('PeriodTab_AppendPeriod');" },
                                    { type: "smallbutton", id: "InsertPerBtn", name: "Insert", img: "refresh.gif", tooltip: "Insert a new period before currently selected row", onclick: "dialogEvent('PeriodTab_InsertPeriod');" },
                                    { type: "smallbutton", id: "DeletePerBtn", name: "Delete", img: "delete.gif", tooltip: "Delete currently selected row", onclick: "dialogEvent('PeriodTab_DeletePeriod');" }
                                ]
                            }
                        ]
                    }
                ]
	        };

	        this.layout = new dhtmlXLayoutObject(this.params.ClientID + "layoutDiv", "2E", "dhx_skyblue");
	        this.layout.cells(this.mainRibbonArea).setText("Periods");
	        this.layout.cells(this.mainArea).setText("Main Area");

	        this.layout.cells(this.mainRibbonArea).hideHeader();
	        this.layout.cells(this.mainArea).hideHeader();


	        this.PeriodTab = new Ribbon(PeriodTabData);
	        this.PeriodTab.Render();

	        this.layout.cells(this.mainRibbonArea).setHeight(95);
	        this.layout.cells(this.mainRibbonArea).attachObject("idPeriodTabDiv");

	        //this.layout.cells(this.mainArea).attachObject("gridDiv_Periods");
	        this.tabbar = this.layout.cells(this.mainArea).attachTabbar();


	        this.tabbar.setImagePath("/_layouts/epmlive/dhtml/xtab/imgs/");
	        this.tabbar.enableAutoReSize();

	        this.tabbar.attachEvent("onSelect", function (id) { return tabbarOnSelectDelegate(id, arguments); });
            

	        for (var n = 0; n < this.CalInfo.length; n++) {
	            var cal = this.CalInfo[n];
	            cal.pers = JSON_GetArray(cal.Periods, "Period");
	            var Id = cal.ID;
	            var Name = cal.Name;
	            this.tabbar.addTab("tab_" + Id, Name);
	            this.tabbar.setContentHTML("tab_" + Id, "<div id='gridDiv_" + Id + "'></div>");
	        }


	        if (this.CalInfo.length > 0)
	            this.tabbar.setTabActive("tab_" + this.CalInfo[0].ID);


	    }
	    catch (e) {
	        alert("EditCalendar InitializeLayout Exception");
	    }
	}


	EditCalendar.prototype.GridsOnValueChanged = function (grid, row, col, val) {


	    //	    if (grid.id == "g_1") {
	    this.PeriodTab.enableItem("SaveBtn");
	    this.CalDat.bChanged = true;

	    for (var i = 1; i <= this.CalDat.pers.length; i++) {
	        if (row == this.CalDat.PerArray[i - 1]) {

	            if (col == "PeriodName") {
	                this.CalDat.pers[i - 1].Name = val;
	            }

	            if (col == "PeriodStart") {
	                this.CalDat.pers[i - 1].StartDate = this.ISODateFormat(val);
	            }
	            if (col == "PeriodFinish") {
	                this.CalDat.pers[i - 1].FinishDate = this.ISODateFormat(val);
	            }

	            return val;
	        }
	    }

	    return val;

	}

	EditCalendar.prototype.ISODateFormat = function (dval) {

	    var ndt = new Date(dval);
	    var smon = "" + (ndt.getUTCMonth() + 1);
	    if (smon.length == 1)
	        smon = "0" + smon;

	    var sday = "" + ndt.getUTCDate();
	    if (sday.length == 1)
	        sday = "0" + sday;

	    var xdt = ndt.getUTCFullYear() + "-" + smon + "-" + sday + "T00:00:00";

	    return xdt;
	}


	EditCalendar.prototype.ISOtoDate = function (sval) {

	    var yrs = parseInt(sval.substr(0, 4));
	    var mth =  parseInt(sval.substr(5, 2)) - 1;
	    var dys =  parseInt(sval.substr(8, 2));
        var d = new Date(yrs, mth, dys, 0, 0, 0, 0);

	    return d;
	}

    

    EditCalendar.prototype.days_between = function(date1, date2) {

        // The number of milliseconds in one day
        var ONE_DAY = 1000 * 60 * 60 * 24

        // Convert both dates to milliseconds
        var date1_ms = date1.getTime()
        var date2_ms = date2.getTime()

        // Calculate the difference in milliseconds
        var difference_ms = Math.abs(date1_ms - date2_ms)
    
        // Convert back to days and return
        return Math.round(difference_ms/ONE_DAY)

    }


    EditCalendar.prototype.AddDays = function (date1, days) {

        // The number of milliseconds in one day
        var ONE_DAY = 1000 * 60 * 60 * 24

        // Convert both dates to milliseconds
        var date1_ms = date1.getTime();
        date1_ms += (days * ONE_DAY);

        var xdt = new Date(date1_ms);

        return xdt;

    }



    EditCalendar.prototype.NewCalDlg_OnClose = function () {
        this.NewCalDlg.window("winNewCalDlg").detachObject()
        this.NewCalDlg = null;
    }


    EditCalendar.prototype.externalEvent = function (event) {

        try {
            switch (event) {



                case "PeriodTab_Close":
                    if (SP.UI.DialogResult)
                        SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, '');
                    else
                        SP.UI.ModalDialog.commonModalDialogClose(0, '');

                    break;

                case "PeriodTab_Save":
                    this.PeriodTab.disableItem("SaveBtn");
                    this.SaveCalData();

                    break;

                case "PeriodTab_New":
                    if (this.NewCalDlg == null) {
                        this.NewCalDlg = new dhtmlXWindows();
                        this.NewCalDlg.enableAutoViewport(false);
                        this.NewCalDlg.attachViewportTo(this.params.ClientID + "mainDiv");
                        this.NewCalDlg.setImagePath("/_layouts/ppm/images/");
                        this.NewCalDlg.createWindow("winNewCalDlg", 20, 30, 575, 175);
                        this.NewCalDlg.window("winNewCalDlg").setIcon("logo.ico", "logo.ico");
                        this.NewCalDlg.window("winNewCalDlg").denyResize();
                        this.NewCalDlg.window("winNewCalDlg").button("park").hide();
                        this.NewCalDlg.window("winNewCalDlg").setModal(true);
                        this.NewCalDlg.window("winNewCalDlg").center();
                        this.NewCalDlg.window("winNewCalDlg").setText("New Calendar");
                        this.NewCalDlg.window("winNewCalDlg").attachEvent("onClose", function (win) { NewCalDlg_OnCloseDelegate(); return true; });
                        this.NewCalDlg.window("winNewCalDlg").attachObject("idCreateNewCal");
                    }
                    else {
                        this.NewCalDlg.window("winNewCalDlg").show();
                    }
                    break;

                case "PeriodTab_Delete":


                    var result = confirm("You are about to delete a calendar.  Are you sure you want to continue?");

                    if (result == false)
                        return;

                    var ntab;

                    for (var i = 0; i < this.CalInfo.length; i++) {
                        var cal = this.CalInfo[i]

                        if (this.EditCal == cal.ID) {
                            WorkEnginePPM.EditCalendar.Execute("DeleteCalendar", this.EditCal);
                            ntab = i;
                            break;
                        }
                    }
                    this.CalInfo.splice(ntab, 1);
                    this.tabbar.removeTab(this.currtab, true);


                    break;


                case "NewCal_OK":

                    var calname = document.getElementById("idTxtCalName").value;
                    var caldesc = document.getElementById("idTxtCalDesc").value;

                    if (calname == "") {
                        alert("Please enter a valid calendar name");
                        break;
                    }


                    this.NewCalDlg.window("winNewCalDlg").setModal(false);
                    this.NewCalDlg.window("winNewCalDlg").hide();
                    this.NewCalDlg.window("winNewCalDlg").detachObject()
                    this.NewCalDlg = null;

                    sb = new StringBuilder();
                    sb.append('<CreateNewCalendar');
                    sb.append(' CalName="' + calname + '" ');
                    sb.append(' CalDesc="' + caldesc + '" />');

                    WorkEnginePPM.EditCalendar.ExecuteJSON("CreateNewCalendar", sb.toString(), CreateNewCalendar_CompleteDelegate);

                    break;

                case "NewCal_Cancel":
                    this.NewCalDlg.window("winNewCalDlg").setModal(false);
                    this.NewCalDlg.window("winNewCalDlg").hide();
                    this.NewCalDlg.window("winNewCalDlg").detachObject()
                    this.NewCalDlg = null;
                    break;

                    break;

                case "PeriodTab_AppendPeriod":

                    this.CalDat.bChanged = true;
                    this.PeriodTab.enableItem("SaveBtn");
                    var perlen = this.CalDat.pers.length;

                    if (perlen == 0)
                        this.CalDat.MaxPerID = 1;
                    else
                        this.CalDat.MaxPerID += 1;

                    this.CalDat.pers[perlen] = new Object;
                    this.CalDat.pers[perlen].ID = this.CalDat.MaxPerID;
                    this.CalDat.pers[perlen].Name = "Period" + this.CalDat.MaxPerID.toString();

                    if (perlen != 0) {

                        var s = this.CalDat.pers[perlen - 1].StartDate;
                        var sdt = this.ISOtoDate(s);
                        s = this.CalDat.pers[perlen - 1].FinishDate;
                        var fdt = this.ISOtoDate(s);

                        var xdt = this.AddDays(fdt, 1);

                        this.CalDat.pers[perlen].StartDate = this.ISODateFormat(xdt);

                        var ddif = this.days_between(fdt, sdt) + 1;
                        xdt = this.AddDays(fdt, ddif);
                        this.CalDat.pers[perlen].FinishDate = this.ISODateFormat(xdt);
                    }
                    else {


                        var sdt = new Date();
                        var xdt = this.AddDays(sdt, 1);

                        this.CalDat.pers[perlen].StartDate = this.ISODateFormat(sdt);
                        this.CalDat.pers[perlen].FinishDate = this.ISODateFormat(xdt);
                    }

                    var arow = this.CalendarGrid.AddRow(null, null, true, null, null);

                    arow.Added = 0;
                    arow.Color = "white";

                    this.CalendarGrid.SetString(arow, "Period", this.CalDat.pers[perlen].ID, 1);
                    this.CalendarGrid.SetString(arow, "PeriodName", this.CalDat.pers[perlen].Name, 1);
                    this.CalendarGrid.SetString(arow, "PeriodStart", this.CalDat.pers[perlen].StartDate, 1);
                    this.CalendarGrid.SetString(arow, "PeriodFinish", this.CalDat.pers[perlen].FinishDate, 1);

                    arow.Changed = 0;
                    this.CalDat.PerArray[perlen] = arow;
                    this.CalendarGrid.Render();

                    break;

                case "PeriodTab_InsertPeriod":
                    if (this.curr_grid_row == null) {
                        alert("No row has been selected to delete");
                        return;
                    }


                    this.CalDat.bChanged = true;
                    this.PeriodTab.enableItem("SaveBtn");


                    for (var i = 0; i < this.CalDat.PerArray.length; i++) {
                        if (this.CalDat.PerArray[i] == this.curr_grid_row) {

                            this.CalDat.MaxPerID += 1;

                            for (var j = this.CalDat.PerArray.length - 1; j > i; j--) {
                                this.CalDat.pers[j] = this.CalDat.pers[j - 1];
                                this.CalDat.pers[j].ID = j + 1;
                                this.CalDat.PerArray[j] = this.CalDat.PerArray[j - 1];
                            }



                            this.CalDat.pers[i] = new Object;
                            this.CalDat.pers[i].ID = i + 1;
                            this.CalDat.pers[i].Name = "Period" + this.CalDat.pers[i].ID.toString();
                            this.CalDat.pers[i].StartDate = this.CalDat.pers[i + 1].StartDate;
                            this.CalDat.pers[i].FinishDate = this.CalDat.pers[i + 1].FinishDate;
                            var arow = this.CalendarGrid.AddRow(null, this.curr_grid_row, true, null, null);
                            this.CalDat.PerArray[i] = arow;
                            this.curr_grid_row = arow;
                            arow.Added = 0;
                            arow.Color = "white";

                            this.CalendarGrid.SetString(arow, "Period", this.CalDat.pers[i].ID, 1);
                            this.CalendarGrid.SetString(arow, "PeriodName", this.CalDat.pers[i].Name, 1);
                            this.CalendarGrid.SetString(arow, "PeriodStart", this.CalDat.pers[i].StartDate, 1);
                            this.CalendarGrid.SetString(arow, "PeriodFinish", this.CalDat.pers[i].FinishDate, 1);

                            this.curr_grid_row = null;
                            break;
                        }
                    }


                    for (var i = 0; i < this.CalDat.PerArray.length; i++) {
                        this.CalDat.pers[i].ID = i + 1;
                        this.CalendarGrid.SetString(this.CalDat.PerArray[i], "Period", i + 1, 1);
                        this.CalDat.PerArray[i].Changed = 0;

                    }

                    this.CalDat.MaxPerID = this.CalDat.pers.length;
                    this.CalendarGrid.Render();

                    break;

                case "PeriodTab_DeletePeriod":

                    if (this.curr_grid_row == null) {
                        alert("No row has been selected to delete");
                        return;
                    }

                    this.CalDat.bChanged = true;
                    this.PeriodTab.enableItem("SaveBtn");

                    for (var i = 0; i < this.CalDat.PerArray.length; i++) {
                        if (this.CalDat.PerArray[i] == this.curr_grid_row) {

                            this.CalDat.PerArray.splice(i, 1);
                            this.CalDat.pers.splice(i, 1);
                            this.CalendarGrid.RemoveRow(this.curr_grid_row);
                            this.curr_grid_row = null;
                            break;
                        }
                    }

                    for (var i = 0; i < this.CalDat.PerArray.length; i++) {
                        this.CalDat.pers[i].ID = i + 1;
                        this.CalendarGrid.SetString(this.CalDat.PerArray[i], "Period", i + 1, 1);
                        this.CalDat.PerArray[i].Changed = 0;

                    }
                    this.CalDat.MaxPerID = this.CalDat.pers.length;
                    this.CalendarGrid.Render();

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


    EditCalendar.prototype.CreateNewCalendar_Complete = function (jsonString) {
        try {
            var jsonObject = JSON_ConvertString(jsonString);
            if (JSON_ValidateServerResult(jsonObject)) {
                var newCal = jsonObject.Result.NewCalendarID;

                if (newCal == undefined) {
                    alert("Create New Calendar failed")
                    return;
                }


                if (newCal == 0) {
                    alert("Create New Calendar failed")
                    return;
                }

                this.CalInfo[this.CalInfo.length] = new Object;
                var cal = this.CalInfo[this.CalInfo.length - 1];
                cal.pers = new Array();
                cal.Periods = new Array;
                cal.ID = newCal;

                var Name = document.getElementById("idTxtCalName").value;
                cal.Name = Name;
                this.tabbar.addTab("tab_" + newCal, Name);
                this.tabbar.setContentHTML("tab_" + newCal, "<div id='gridDiv_" + newCal + "'></div>");

                this.tabbar.setTabActive("tab_" + newCal);

            }
        }

        catch (e) {
            this.HandleException("CreateNewCalendar_Complete", e);
        }
    }


    EditCalendar.prototype.GridsOnReady = function (grid, start) {
        try {

            //       if (grid.id == "g_1") {
            this.CalDat.PerArray = new Array();
            this.CalDat.bChanged = false;

            for (var i = 0; i < this.CalDat.pers.length; i++) {
                var arow = grid.AddRow(null, null, true, "r" + i, null);

                arow.Added = 0;
                arow.Color = "white";

                grid.SetString(arow, "Period", this.CalDat.pers[i].ID, 1);
                grid.SetString(arow, "PeriodName", this.CalDat.pers[i].Name, 1);
                grid.SetString(arow, "PeriodStart", this.CalDat.pers[i].StartDate, 1);
                grid.SetString(arow, "PeriodFinish", this.CalDat.pers[i].FinishDate, 1);

                arow.Changed = 0;
                this.CalDat.PerArray[i] = arow;
                this.CalDat.MaxPerID = this.CalDat.pers.length;

            }

            return;

            //       }

        }
        catch (e) {
            this.HandleException("GridsOnReady", e);
        }
    }

	EditCalendar.prototype.GridsOnGetDefaultColor = function (grid, row, col, r, g, b) {
	    if (row.Kind != "Data")
            return null;


	    return 0xFFFFFF;

	}
	EditCalendar.prototype.HandleException = function (sWhere, e) {
	    alert("Error " + sWhere + " : " + e.toString());
	}


	try {
	    // Initialised fields

	    this.CalData = null;
	    this.params = params;
	    this.imagePath = "/_layouts/ppm/images/";
	    this.Webservice = params.Webservice;




	    this.mainRibbonArea = "a";
	    this.mainArea = "b";
	
	    this.CalendarGrid = null;

     	this.Dirty = false;
		this.initialized = false;
		this.ExitConfirmed = false;
		this.Height = 0;
		this.Width = 0;

		this.CalInfo = null;
		this.selectCalendar = null;

		var loadDelegate = MakeDelegate(this, this.OnLoad);

		var GridsOnReadyDelegate = MakeDelegate(this, this.GridsOnReady);
		var GridsOnAfterColResizeDelegate = MakeDelegate(this, this.GridsOnAfterColResize);
		var GridsOnClickCellDelegate = MakeDelegate(this, this.GridsOnClickCell);
		var GridsOnValueChangedDelegate = MakeDelegate(this, this.GridsOnValueChanged);
		var GridsOnGetDefaultColorDelegate = MakeDelegate(this, this.GridsOnGetDefaultColor);
		var GetCalendarInfoCompleteDelegate = MakeDelegate(this, this.GetCalendarInfoComplete);
		var GetCalendarDataInfoCompleteDelegate = MakeDelegate(this, this.GetCalendarDataInfoComplete);
		var tabbarOnSelectDelegate = MakeDelegate(this, this.tabbarOnSelect);
		var NewCalDlg_OnCloseDelegate = MakeDelegate(this, this.NewCalDlg_OnClose);
		var CreateNewCalendar_CompleteDelegate = MakeDelegate(this, this.CreateNewCalendar_Complete);
		

		

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