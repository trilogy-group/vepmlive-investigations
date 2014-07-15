function Model(thisID, params) {
	// NB Constructor code at end of function
	var MakeDelegate = function (target, method) {
		if (method == null) {
			throw ("Method not found");
		}

		return function () {
			return method.apply(target, arguments);
		}
	}



	function trim(stringToTrim) {
		  return stringToTrim.replace(/^\s+|\s+$/g,"");
	}

	Model.prototype.OnLoad = function (event) {
	    WorkEnginePPM.Model.set_path(this.Webservice);
	    Grids.OnAfterValueChanged = GridsOnAfterValueChangedDelegate;
	    //	    Grids.OnRenderStart = GridsOnRenderStartDelegate;
	    Grids.OnRenderFinish = GridsOnRenderFinishDelegate;
	    Grids.OnGanttChanged = GridsOnGanttChangedDelegate;
	    Grids.OnGetDefaultColor = GridsOnGetDefaultColorDelegate;
	    Grids.OnClickCell = GridsOnClickCellDelegate;
	    Grids.OnValueChanged = GridsOnValueChangedDelegate;
	    Grids.OnAfterColResize = GridsOnAfterColResizeDelegate;
	    Grids.OnReady = GridsOnReadyDelegate;

	    //		Grids.OnGetColor = GridsOnGetDefaultColorDelegate;

	    //	    this.ViewID = "11"; 

	    if (this.ViewID == "" && this.ViewName == "") {
	        this.IsModeller = true;

	    }
	    else {
	        this.IsModeller = false;
	    }

	    if (this.params.TicketVal == undefined || this.params.TicketVal == "")
	        WorkEnginePPM.Model.ExecuteJSON("","GetPortfolioItemList", "", GetPortfolioItemListCompleteDelegate);
	    else {
	        //	        WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("GetRAUserCalendarInfo", "", GetCalendarInfoCompleteDelegate);

	        if (this.ViewID == "" && this.ViewName == "") {
	            this.GetModelAndVersions();
	        }
	        else {
	            WorkEnginePPM.Model.GetCostViews(GetCostViewsCompleteDelegate);
	        }
	    }

	}

	Model.prototype.GetPortfolioItemListComplete = function (jsonString) {

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
	        alert("Model GetPortfolioItemListComplete Exception");

	        if (parent.SP.UI.DialogResult)
	            parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
	        else
	            parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');

	    }



	}


	Model.prototype.GrabSelectedPIs = function () {

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
	        WorkEnginePPM.Model.ExecuteJSON("","GetGeneratedPortfolioItemTicket", sExtPIs, GetGeneratedPortfolioItemTicketCompleteDelegate);
	    else
	        alert("No Portfolio Items were selected");



	    return retval;

	}

	Model.prototype.GetGeneratedPortfolioItemTicketComplete = function (jsonString) {
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
	                this.TicketVal = xticket;

	                if (this.IsModeller == true) 
	                        this.GetModelAndVersions();
	                else {


	                    WorkEnginePPM.Model.GetCostViews(GetCostViewsCompleteDelegate);
	                }

	                   



	            }




	        }

	    }

	    catch (e) {
	        alert("Model GetGeneratedPortfolioItemTicketComplete Exception");

	        if (parent.SP.UI.DialogResult)
	            parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
	        else
	            parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');

	    }

	}


	Model.prototype.GetModelAndVersions = function () {

	    WorkEnginePPM.Model.GetModels(GetModelsCompleteDelegate);
	


	}

   Model.prototype.GetCostViewsComplete = function (result) {
	   
       var bFound = false;
       var bnoview = false;

       if (this.ViewName == undefined)
           this.ViewName = "";

       if (this.ViewID == undefined)
           this.ViewID = "";

       if (this.ViewName == "" && this.ViewID == "")
           bnoview = true;

		for (var n = 0; n < result.length; n++) {
			var Id = result[n].Id;
			var Name = result[n].Name;

			if (bnoview) {
			    this.ViewName = "";
			    this.ViewID = Id;
			    bFound = true;
			    break;

			}

			if (Name == this.ViewName)
			{
				this.ViewName = "";
				this.ViewID = Id;
				bFound = true;
				break;
			}

			if (Id == this.ViewID)
			{

				bFound = true;
				break;
			}
 
		}

		if (bFound == false)
		{
		    alert("Cost View Specified did not exist");


		    if (parent.SP.UI.DialogResult)
		        parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
		    else
		        parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');

			return;


		}

		// for some bizzare reason - if these lines are not executed the grids end up in the wrong place - these are lines associated with choosing the model to use etc.
		// will investigate in the future - but better to get the inital code finished....

		this.selectModelAndVersion = new dhtmlXWindows();
		this.selectModelAndVersion.setSkin("dhx_web");
		this.selectModelAndVersion.enableAutoViewport(false);
		this.selectModelAndVersion.attachViewportTo(this.clientID + "mainDiv");
		this.selectModelAndVersion = null;


		WorkEnginePPM.Model.LoadModelData(this.TicketVal, this.ModelVal, this.VersionsVal, this.ViewID, InitialGetSortAndGroupDelegate);
 

   }

   Model.prototype.GetModelsComplete = function (result) {
	   var ModelList = document.getElementById('idModelList');
	   ModelList.options.length = 0;

	   if (result.length == 0) {
		   alert("No Models have been defined - please contact your administrator");

		   if (parent.SP.UI.DialogResult)
			   parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
		   else
			   parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');


		   return;
	    }

	    if (result.length == 1) {

	        var xName = result[0].Name;
	        
            if (xName == "***PermsisionsCheck***") {
 	            alert("You do not have the Global Permission set to access this functionality!");

	            if (parent.SP.UI.DialogResult)
	                parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
	            else
	                parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');
                return;               
            }

	     }

	     try {
	        if (this.selectModelAndVersion == null) {
	            this.selectModelAndVersion = new dhtmlXWindows();
	            this.selectModelAndVersion.setSkin("dhx_web");
	            this.selectModelAndVersion.enableAutoViewport(false);
	            this.selectModelAndVersion.attachViewportTo(this.clientID + "mainDiv");
	            this.selectModelAndVersion.setImagePath(this.imagePath);
	            this.selectModelAndVersion.createWindow("winModelAndVersionsDlg", 20, 30, 450, 185);
	            this.selectModelAndVersion.window("winModelAndVersionsDlg").setIcon("logo.ico", "logo.ico");
	            this.selectModelAndVersion.window("winModelAndVersionsDlg").allowMove();
	            this.selectModelAndVersion.window("winModelAndVersionsDlg").denyResize();
	            this.selectModelAndVersion.window("winModelAndVersionsDlg").setModal(true);
	            this.selectModelAndVersion.window("winModelAndVersionsDlg").center();
	            this.selectModelAndVersion.window("winModelAndVersionsDlg").setText("Select Model and Versions");
	            this.selectModelAndVersion.window("winModelAndVersionsDlg").attachObject("idMVDlgObj");
	            this.selectModelAndVersion.window("winModelAndVersionsDlg").button("close").disable();
	            this.selectModelAndVersion.window("winModelAndVersionsDlg").button("park").hide();
	            this.selectModelAndVersion.window("winModelAndVersionsDlg").button("minmax1").hide();






	        }
	        else
	            this.selectModelAndVersion.window("winModelAndVersionsDlg").show();
	    }

	    catch (e) {
	        alert("error 1");
	    }


	   for (var n = 0; n < result.length; n++) {
		   var Id = result[n].Id;
		   var Name = result[n].Name;
		   ModelList.options[n] = new Option(Name, Id, n == 0, n == 0);
	   }

	   this.SelectModel_Change();
   }

	Model.prototype.GetLoadSelectVersionComplete = function (result) {
		var VersionList = document.getElementById('idVersionList');
		VersionList.options.length = 0;
		this.VersionsList = result;
		for (var n = 0; n < result.length; n++) {
			var Id = result[n].Id;
			var Name = result[n].Name;
			VersionList.options[n] = new Option(Name, Id, n == 0, n == 0);
		}

	}


	Model.prototype.OnResize = function (event) {
	    if (this.initialized == true) {
	        var lHeight = this.Height;
	        var lWidth = this.Width;

	        //	        alert("Size h:" + lHeight + "   W:" + lWidth);
	        if (lHeight > 300) {

	            this.layout.cells(this.mainRibbonArea).fixSize(false, false);
	            if (this.ribbonBar.isCollapsed() == true)
	                this.layout.cells(this.mainRibbonArea).setHeight(50);
	            else
	                this.layout.cells(this.mainRibbonArea).setHeight(120);

	            this.layout.cells(this.mainRibbonArea).fixSize(false, true);

	            var lsplit = (lHeight - 90);
	            lsplit = Math.floor(lHeight / 2);
	            this.layout.cells(this.mainArea).setHeight(lsplit - 5);
	            this.layout.cells(this.totalsArea).setHeight(lsplit - 5);
	        }


	        this.layout.cont.obj._offsetTop = 0;
	        this.layout.cont.obj._offsetHeight = 0;
	        this.layout.cont.obj._offsetLeft = 0;
	        this.layout.cont.obj._offsetWidth = 0;


	        this.layout.setSizes();

//	        if (this.dlgEditTarget != null) 
//	            this.dlgEditTarget.window("winEditTargetDlg").setDimension(this.Width, this.Height);


	    }
	}


	Model.prototype.SetSize = function (nWidth, nHeight) {
	    this.Width = nWidth;
	    this.Height = nHeight;

	    var divLayout = document.getElementById(this.params.ClientID + "layoutDiv");
	    if (nHeight > 300) {
	        divLayout.style.height = nHeight + "px";
	    }

	    this.OnResize();
	}

	Model.prototype.OnLoadModelDataComplete = function () {

	    var bRet = false;

	    if (this.SnGData.LoadReturnCode != 0) {
	        bRet = true;
	        alert("An error occured while loading the cost data!  The error code returned was " + this.SnGData.LoadReturnCode + " : " + this.SnGData.errMsg);

	    }
	    else if (this.SnGData.NumPIs == 0) {
	        bRet = true;
	        alert("No matching Project items were found!");
	    }
	    else if (this.SnGData.HaveLowlevelData == 0) {
	        bRet = true;
	        alert("No Cost data matching the Project Items was loaded!");
	    }

	    if (bRet == true) {

	        if (parent.SP.UI.DialogResult)
	            parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
	        else
	            parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');


	        return;
	    }

	    if (this.SnGData.MissingPIs == 1)
	        alert("Not all list items had matching Portfolio items!");

	    this.layout = new dhtmlXLayoutObject(this.params.ClientID + "layoutDiv", "3E", "dhx_skyblue");


	    //this.layout = new dhtmlXLayoutObject(this.clientID + "mainDiv", "2E");

	    this.layout.cells(this.mainRibbonArea).setText("Ribbon");
	    this.layout.cells(this.mainRibbonArea).hideHeader();
	    this.layout.cells(this.mainArea).setText("Main Area");
	    this.layout.cells(this.mainArea).hideHeader();
	    this.layout.cells(this.mainArea).attachObject("gridDiv_1");

	    this.layout.cells(this.totalsArea).setText("Totals Area");
	    this.layout.cells(this.totalsArea).hideHeader();


	    this.layout_totals = this.layout.cells(this.totalsArea).attachLayout("2E", "dhx_skyblue");
	    this.layout_totals.cells(this.totalsRibbonArea).setText("Totals");
	    this.layout_totals.cells(this.totalsGridArea).setText("Total Grid Area");
	    this.layout_totals.cells(this.totalsRibbonArea).hideHeader();
	    this.layout_totals.cells(this.totalsGridArea).hideHeader();
	    this.layout_totals.cells(this.totalsRibbonArea).setHeight(68);
	    this.layout_totals.cells(this.totalsRibbonArea).fixSize(false, true);


	    this.layout_totals.cells(this.totalsGridArea).attachObject("bottomgridDiv_1");


	    var ModelRibbonData = {
	        parent: "idRibbonDiv",
	        style: "display:none;",
	        imagePath: this.imagePath,
	        showstate: "true",
	        initialstate: "expanded",
	        onstatechange: "dialogEvent('Ribbon_Toggle');",
	        sections: [
                    { name: "General",
                        columns: [
                            {
                                items: [
                                    { type: "bigbutton", name: "Close", img: "close32.gif", tooltip: "Close", onclick: "dialogEvent('CloseBtn');" }
                                ]
                            },
                            {
                                items: [
                                    { type: "bigbutton", id: "DetailsBtn", name: "Total<br/> Details", img: "ps32x32.png", style: "top: -96px; left: -224px;position:relative;", tooltip: "Undo", onclick: "dialogEvent('FilterBtn');" }
                                ]
                            }
                        ]
                    },
                    { name: "Display",
                        columns: [
                            {
                                items: [
                                    { type: "smallbutton", id: "tSearchBtn", name: "Search Settings", img: "formatmap16x16.png", style: "top: -48px; left: -78px;position:relative;", tooltip: "Search Settings", onclick: "dialogEvent('SearchBtn');" },
                                    { type: "smallbutton", id: "FindBtn", name: "Find Next", img: "formatmap16x16.png", style: "top: -208px; left: -128px;position:relative;", tooltip: "Find Next", onclick: "dialogEvent('FindNextBtn');", disabled: true }
                                ]
                            }
                        ]
                    },
	                { name: "Versions ",
	                    columns: [
                            {
                                items: [
                                    { type: "smallbutton", id: "SaveVers", name: "Save Version", img: "save.gif", tooltip: "Save Version", onclick: "dialogEvent('SaveBtn');" },
                                    { type: "smallbutton", id: "CopyVers", name: "Copy Version", img: "formatmap16x16.png", style: "top: -128px; left: -16px;position:relative;", tooltip: "Copy Version", onclick: "dialogEvent('CopyBtn');"}]
                            }
                        ]
	                },
                    {
                        name: "Share",
                        tooltip: "Share",
                        columns: [
                           {
                               items: [
                                    { type: "bigbutton", id: "idExportExcelTop", name: "Export to<br/> Excel", img: "formatmap32x32.png", style: "top: -352px; left: 0px;position:relative;", tooltip: "Export Details to Excel", onclick: "dialogEvent('ExportTopBtn');" }
                                ]
                           },
                           {
                               items: [
                                    { type: "bigbutton", id: "idPrintTop", name: "Print", img: "ps32x32.png", style: "top: -287px; left: -128px;position:relative;", tooltip: "Print", onclick: "dialogEvent('PrintTopBtn');" }
                                ]
                           }
                        ]
                    }
                ]
	    };

	    var CTARibbonData = {
	        parent: "idRibbonDiv",
	        style: "display:none;",
	        imagePath: this.imagePath,
	        showstate: "true",
	        initialstate: "expanded",
	        onstatechange: "dialogEvent('Ribbon_Toggle');",
	        sections: [
                    { name: "General",
                        columns: [
                            {
                                items: [
                                    { type: "bigbutton", name: "Close", img: "close32.gif", tooltip: "Close", onclick: "dialogEvent('CloseBtn');" }
                                ]
                            },
                            {
                                items: [
                                    { type: "bigbutton", id: "DetailsBtn", name: "Total<br/> Details", img: "ps32x32.png", style: "top: -96px; left: -224px;position:relative;", tooltip: "Undo", onclick: "dialogEvent('FilterBtn');" }
                                ]
                               }
                        ]
                    },
                    { name: "Display",
                        columns: [
                            {
                                items: [
                                    { type: "smallbutton", id: "tSearchBtn", name: "Search Settings", img: "formatmap16x16.png", style: "top: -48px; left: -78px;position:relative;", tooltip: "Search Settings", onclick: "dialogEvent('SearchBtn');" },
                                    { type: "smallbutton", id: "FindBtn", name: "Find Next", img: "formatmap16x16.png", style: "top: -208px; left: -128px;position:relative;", tooltip: "Find Next", onclick: "dialogEvent('FindNextBtn');", disabled: true }
                                ]
                            }
                        ]
                    },
                    {
                        name: "Share",
                        tooltip: "Share",
                        columns: [
                           {
                               items: [
                                    { type: "bigbutton", id: "idExportExcelTop", name: "Export to<br/> Excel", img: "formatmap32x32.png", style: "top: -352px; left: 0px;position:relative;", tooltip: "Export Details to Excel", onclick: "dialogEvent('ExportTopBtn');" }
                                ]
                           },
                           {
                               items: [
                                    { type: "bigbutton", id: "idPrintTop", name: "Print", img: "ps32x32.png", style: "top: -287px; left: -128px;position:relative;", tooltip: "Print", onclick: "dialogEvent('PrintTopBtn');" }
                                ]
                           }
                        ]
                    }
                ]
	    };

	    var viewTabData = {
	        parent: "idViewTabDiv",
	        style: "display:none;",
	        showstate: "true",
	        initialstate: "expanded",
	        onstatechange: "dialogEvent('View_Toggle');",
	        imagePath: this.imagePath,
	        sections: [
                {
                    name: "Actions",
                    columns: [
                        {
                            items: [
                                { type: "bigbutton", name: "Close", img: "close32.gif", tooltip: "Close", onclick: "dialogEvent('CloseBtn');" }
                            ]
                        }
                    ]
                },
                {
                    name: "Views",
                    columns: [
                        {
                            items: [
                                { type: "smallbutton", id: "SaveViewBtn", name: "Save View", img: "createview.gif", tooltip: "Save View", onclick: "dialogEvent('ViewTab_SaveView');" },
                                { type: "smallbutton", id: "RenameViewBtn", name: "Rename View", img: "editview.gif", tooltip: "Rename View", onclick: "dialogEvent('View_RenameView');" },
                                { type: "smallbutton", id: "DeleteViewBtn", name: "Delete View", img: "deleteview.gif", tooltip: "Delete View", onclick: "dialogEvent('View_DeleteView');" }
                            ]
                        },
                        {
                            items: [
                                    { type: "smallbutton", id: "SortBtn", name: "Sort and Group", img: "grouping.gif", tooltip: "Sort and Group", onclick: "dialogEvent('SnGBtn');" },
                                    { type: "smallbutton", id: "ColumnBtn", name: "Column Order", img: "formatmap16x16.png", style: "top: -224px; left: -128px;position:relative;", tooltip: "Column Order", onclick: "dialogEvent('ColsBtn');" }
                                ]
                        },
                        {
                            items: [
                                   { type: "smallbutton", id: "PerBtn", name: "Periods and Values", img: "formatmap16x16.png", style: "top: -96px; left: -96px;position:relative;", tooltip: "Periods and Values", onclick: "dialogEvent('CPerBtn');" },
                                    { type: "smallbutton", id: "GanttChk", name: "Show Gantt", img: "ps16x16.png", style: "top: -192px; left: -16px;position:relative;", tooltip: "Show Gantt", onclick: "dialogEvent('BarBtn');" }
                            ]
                        },
                        {
                            items: [
                                    { type: "text", name: "Gantt Zoom" },
                                    { type: "select", id: "idGanttZoom", onchange: "dialogEvent('GanttZoom_Changed');" },
                                    { type: "smallbutton", id: "EnableGrpChk", name: "PI Grouping", img: "ps16x16.png", style: "top: -142px; left: -48px;position:relative;", tooltip: "Enable PI Grouping", onclick: "dialogEvent('EnGrpBtn');" }
 
                                ]
                        },
                        {
                            items: [
                                { type: "text", name: " ", width: "10px" }
                            ]
                        },
                        {
                            items: [
                                { type: "text", name: "Current View:" },
                                { type: "select", id: "idUserViews", onchange: "dialogEvent('UserViewChanged');", width: "100px" }
                            ]
                        }
                    ]
                }
                ]
	    };
	    var CTAviewTabData = {
	        parent: "idViewTabDiv",
	        style: "display:none;",
	        showstate: "true",
	        initialstate: "expanded",
	        onstatechange: "dialogEvent('View_Toggle');",
	        imagePath: this.imagePath,
	        sections: [
                {
                    name: "Actions",
                    columns: [
                        {
                            items: [
                                { type: "bigbutton", name: "Close", img: "close32.gif", tooltip: "Close", onclick: "dialogEvent('CloseBtn');" }
                            ]
                        }
                    ]
                },
                {
                    name: "Views",
                    columns: [
                        {
                            items: [
                                { type: "smallbutton", id: "SaveViewBtn", name: "Save View", img: "createview.gif", tooltip: "Save View", onclick: "dialogEvent('ViewTab_SaveView');" },
                                { type: "smallbutton", id: "RenameViewBtn", name: "Rename View", img: "editview.gif", tooltip: "Rename View", onclick: "dialogEvent('View_RenameView');" },
                                { type: "smallbutton", id: "DeleteViewBtn", name: "Delete View", img: "deleteview.gif", tooltip: "Delete View", onclick: "dialogEvent('View_DeleteView');" }
                            ]
                        },
                        {
                            items: [
                                    { type: "smallbutton", id: "SortBtn", name: "Sort and Group", img: "grouping.gif", tooltip: "Sort and Group", onclick: "dialogEvent('SnGBtn');" },
                                    { type: "smallbutton", id: "ColumnBtn", name: "Column Order", img: "formatmap16x16.png", style: "top: -224px; left: -128px;position:relative;", tooltip: "Column Order", onclick: "dialogEvent('ColsBtn');" }
                                ]
                        },
                        {
                            items: [
                                   { type: "smallbutton", id: "PerBtn", name: "Periods and Values", img: "formatmap16x16.png", style: "top: -96px; left: -96px;position:relative;", tooltip: "Periods and Values", onclick: "dialogEvent('CPerBtn');" }
                                ]
                        },
                        {
                            items: [
                                { type: "text", name: "Current View:" },
                                { type: "select", id: "idUserViews", onchange: "dialogEvent('UserViewChanged');", width: "100px" }
                            ]
                        }
                    ]
                }
                ]
	    };

	    var bottomModelRibbonData = {
	        parent: "idBottomRibbonDiv",
	        style: "display:none;",
	        showstate: "true",
	        initialstate: "expanded",
	        onstatechange: "dialogEvent('BottomRibbon_Toggle');",
	        imagePath: this.imagePath,
	        showstate: "true",
	        sections: [
	                { name: "Targets",
	                    columns: [
	                        {
	                            items: [
                                    { type: "bigbutton", id: "LoadTargetBtn", name: "Apply<br/> Target", img: "ps32x32.png", style: "top: -0px; left: -0px;position:relative;", tooltip: "Apply Target", onclick: "dialogEvent('LoadTargetBtn');" }
	                            ]
	                        },
                            {
                                items: [
                                    { type: "bigbutton", id: "TotalsBtn", name: "Totals<br/>Details", img: "formatmap32x32.png", style: "top: -450px; left: -256px;position:relative;", tooltip: "Totals", onclick: "dialogEvent('TotalBtn');" }
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
                            },
                            {
                                items: [
                                    { type: "smallbutton", id: "ShowTotChk", name: "Show Remaining", img: "ps16x16.png", style: "top: -112px; left: -64px;position:relative;", tooltip: "Show Totals or Remaining", onclick: "dialogEvent('ShowTotBtn');" },
                                     { type: "smallbutton", id: "TargetLegend", name: "Legend", img: "ps16x16.png", style: "top: -128px; left: -176px;position:relative;", tooltip: "Legend", onclick: "dialogEvent('TarLegBtn');" }
                                ]
                            }
                        ]
	                },
                    {
                        name: "Share",
                        tooltip: "Share",
                        columns: [
                           {
                               items: [
                                    { type: "bigbutton", id: "ExportBotBtn", name: "Export to<br/> Excel", img: "formatmap32x32.png", style: "top: -352px; left: 0px;position:relative;", tooltip: "Export Totals to Excel", onclick: "dialogEvent('ExportBotBtn');" }
                                ]
                           },
                           {
                               items: [
                                    { type: "bigbutton", id: "PrintBotBtn", name: "Print", img: "ps32x32.png", style: "top: -287px; left: -128px;position:relative;", tooltip: "Print", onclick: "dialogEvent('PrintBotBtn');" }
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
                                   { type: "text", id: "idcmptextval", name: "       ", disabled: true, width: "200px" }
                               ]
                            }
                        ]
                    }
                ]
	    };

	    var bottomCTARibbonData = {
	        parent: "idBottomRibbonDiv",
	        style: "display:none;",
	        showstate: "true",
	        initialstate: "expanded",
	        onstatechange: "dialogEvent('BottomRibbon_Toggle');",
	        imagePath: this.imagePath,
	        showstate: "true",
	        sections: [
	                { name: "Comparison",
	                    columns: [
                           {
                               items: [
                                    { type: "bigbutton", id: "CTCmpBtn", name: "Compare<br/> Totals", img: "ps32x32.png", style: "top: -96px; left: -161px;position:relative;", tooltip: "Compare Totals against Cost Type", onclick: "dialogEvent('CTCmpBtn');" }
                               ]
                           },
                           {
                                items: [
                                    { type: "bigbutton", id: "TotalsBtn", name: "Totals<br/>Details", img: "formatmap32x32.png", style: "top: -450px; left: -256px;position:relative;", tooltip: "Totals", onclick: "dialogEvent('TotalBtn');" }
                               ]
                           },
	                       {
	                           items: [
                                    { type: "smallbutton", id: "ShowTotChk", name: "Show Remaining", img: "ps16x16.png", style: "top: -112px; left: -64px;position:relative;", tooltip: "Show Totals or Remaining", onclick: "dialogEvent('ShowTotBtn');" },
                                    { type: "smallbutton", id: "TargetLegend", name: "Legend", img: "ps16x16.png", style: "top: -128px; left: -176px;position:relative;", tooltip: "Legend", onclick: "dialogEvent('TarLegBtn');" }
                                ]
	                       }
                        ]
	                },
                    {
                        name: "Share",
                        tooltip: "Share",
                        columns: [
                           {
                               items: [
                                    { type: "bigbutton", id: "ExportBotBtn", name: "Export to<br/> Excel", img: "formatmap32x32.png", style: "top: -352px; left: 0px;position:relative;", tooltip: "Export Totals to Excel", onclick: "dialogEvent('ExportBotBtn');" }
                                ]
                           },
                           {
                               items: [
                                    { type: "bigbutton", id: "PrintBotBtn", name: "Print", img: "ps32x32.png", style: "top: -287px; left: -128px;position:relative;", tooltip: "Print", onclick: "dialogEvent('PrintBotBtn');" }
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
                                  { type: "text", id: "idcmptextval", name: "       ", disabled: true, width: "200px" }
                               ]
                            }
                        ]
                    }
               ]
	    };



	    if (this.IsModeller == true) {

	        this.ribbonBar = new Ribbon(ModelRibbonData);

	        this.viewBar = new Ribbon(viewTabData);
	    } else {
	        this.ribbonBar = new Ribbon(CTARibbonData);

	        this.viewBar = new Ribbon(CTAviewTabData);
	    }

	    this.ribbonBar.Render();

	    this.viewBar.Render();

	    this.Tabbar = this.layout.cells(this.mainRibbonArea).attachTabbar();
	    this.Tabbar.attachEvent("onSelect", function (id) { tabbarOnSelectDelegate(id, arguments); return true; });

	    //this.planTabbar.setSkin("dark_blue");
	    this.Tabbar.setImagePath("/_layouts/epmlive/dhtml/xtab/imgs/");
	    this.Tabbar.enableAutoReSize();
	    this.Tabbar.addTab("tab_Display", "Display", 70);
	    this.Tabbar.setContent("tab_Display", this.ribbonBar.getRibbonDiv());
	    this.Tabbar.addTab("tab_View", "View", 70);
	    this.Tabbar.setContent("tab_View", this.viewBar.getRibbonDiv());

	    if (this.IsModeller == true)
	        this.bottomRibbon = new Ribbon(bottomModelRibbonData);
	    else
	        this.bottomRibbon = new Ribbon(bottomCTARibbonData);


	    this.bottomRibbon.Render();

	    //	    this.layout.cells(this.mainRibbonArea).attachObject(this.ribbonBar.getRibbonDiv());	
	    this.layout.cells(this.mainRibbonArea).fixSize(false, false);
	    this.layout.cells(this.mainRibbonArea).setHeight(120);
	    this.layout.cells(this.mainRibbonArea).fixSize(false, true);

	    this.layout_totals.cells(this.totalsRibbonArea).attachObject(document.getElementById(this.bottomRibbon.getRibbonDiv()));

	    if (this.IsModeller == true) {

	        var select = document.getElementById("idGanttZoom");
	        select.options.length = 0;
	        select.options[0] = new Option("Years and half years", 1, true, true);
	        select.options[1] = new Option("Years and quarters", 2, false, false);
	        select.options[2] = new Option("Half years and months", 3, false, false);
	        select.options[3] = new Option("Quarters and months", 4, false, false);
	        select.options[4] = new Option("Months and weeks", 5, false, false);
	        select.options[5] = new Option("Months and days", 6, false, false);
	    }


	    this.DetGridDoRender = true;
	    this.TotGridDoRender = true;

	    this.bdoingCmp = false;
	    this.bShowingTotals = true;

	    this.Tabbar.setTabActive("tab_Display");

	    this.layout.attachEvent("onResizeFinish", layoutOnResizeFinishDelegate);




	    this.FlashTargetMenuStuff();

	    this.DoUserViewsMenu();


	    // commenting out this for we gantt issue
	    if (this.IsModeller == true) {
	        this.GanttShowing = true;


	        this.viewBar.setButtonStateOn("GanttChk");
	        //  this.ribbonBar.setButtonStateOn("EnableGrpChk");

	        this.viewBar.hideItem("EnableGrpChk");


	        WorkEnginePPM.Model.DoShowGantt(this.TicketVal, 1, DoShowGanttCompleteDelegate);
	    }


	    this.initialized = true;
	    this.layout._minHeight = 18;
	    this.layout_totals._minHeight = 18;



	    PingSessionData();


//	    var sHTML1 = "<treegrid SuppressMessage='3' debug='0' Export_Url='ModelExportExcel.aspx'  Export_Param_File = 'modelexport.xls' sync='0' layout_url='" + this.Webservice + "' layout_method='Soap' layout_function='GetTopGridLayout' layout_namespace='WorkEnginePPM' layout_param_Ticket='" + this.TicketVal + "' data_url='" + this.Webservice + "' data_method='Soap' data_function='GetTopGridData' data_namespace='WorkEnginePPM' data_param_Ticket='" + this.TicketVal + "' ></treegrid>";
//	   // this.DetGrid = TreeGrid(sHTML1, "gridDiv_1", "g_1");

	    this.ShowWorkingPopup("divLoading");



//	    var sHTML2 = "<treegrid SuppressMessage='3' debug='0' Export_Url='ModelExportExcel.aspx'  Export_Param_File = 'modelexport.xls' sync='0' layout_url='" + this.Webservice + "' layout_method='Soap' layout_function='GetBottomGridLayout' layout_namespace='WorkEnginePPM' layout_param_Ticket='" + this.TicketVal + "' data_url='" + this.Webservice + "' data_method='Soap' data_function='GetBottomGridData' data_namespace='WorkEnginePPM'  data_param_Ticket='" + this.TicketVal + "' ></treegrid>";
//	    //	    this.TotGrid = TreeGrid(sHTML2, "bottomgridDiv_1", "bottomg_1");



	}




  
	Model.prototype.DoUserViewsMenu = function () {
	   WorkEnginePPM.Model.LoadUserViewData(this.TicketVal, LoadUserViewDataCompleteDelegate);

	}


	Model.prototype.LoadUserViewDataComplete = function (result) {


	    this.RemoveUserViewData();

	    this.UserViews = result;

	    if (result == null)
	        return;

	    if (result.length == 0)
	        return;


	    if (this.dospecialcurrview == true) {
	        this.dospecialcurrview = false;


	        for (var i = 0; i < this.UserViews.length; i++) {
	            var uvs = this.UserViews[i];
	            if (i == 0)
	                this.CurrUserView = uvs.Name;

	            if (uvs.Deflt == 1) {
                    this.CurrUserView = uvs.Name;
                    break;
                }
	        }

	    }

	    var select = document.getElementById("idUserViews");
	    select.disabled = false;

	    select.options.length = 0;

	    select.options[0] = new Option("", -1, this.CurrUserView == "", this.CurrUserView == "");

	    for (var i = 0; i < this.UserViews.length; i++) {
	        var uv = this.UserViews[i];
	        select.options[i + 1] = new Option(uv.Name, i, this.CurrUserView == uv.Name, this.CurrUserView == uv.Name);
	    }

	    var selectText = document.getElementById("idUserViews" + "_textbox");

	    if (selectText != null) {
	        if (document.all) selectText.innerText = this.CurrUserView;
	        else selectText.textContent = this.CurrUserView;
	    }

        if (this.DetGrid == null)
            window.setTimeout(DeferedGridCreateDelegate, 200);


	}

	Model.prototype.DeferedGridCreate = function () {

        this.stashgridsettings = null;
	    var sbDataxml = new StringBuilder();
	    sbDataxml.append('<![CDATA[');
	    sbDataxml.append('<Execute Function="GetTopGrid">');
	    sbDataxml.append('</Execute>');
	    sbDataxml.append(']]>');

	    var sb = new StringBuilder();
	    sb.append("<treegrid  SuppressMessage='3' debug='0' sync='0' ");
	    sb.append(" Export_Url='ModelExportExcel.aspx'");
	    sb.append(" data_url='" + this.Webservice + "'");
	    sb.append(" data_method='Soap'");
	    sb.append(" data_function='Execute'")
	    sb.append(" data_namespace='WorkEnginePPM'");
	    sb.append(" data_param_Ticket='" + this.TicketVal + "'");
	    sb.append(" data_param_Function='GetTopGrid'");
	    sb.append(" data_param_Dataxml='" + sbDataxml.toString() + "'");
	    sb.append(" >");
	    sb.append("</treegrid>");

	    this.DetGrid = TreeGrid(sb.toString(), "gridDiv_1", "g_1");
    }

	Model.prototype.RemoveUserViewData = function () {
	    
        
	    var select = document.getElementById("idUserViews");
	    select.options.length = 0;
        select.disabled = true;
	}

	Model.prototype.FlashTargetMenuStuff = function () {

		if (this.bdoingCmp == false)
		{

		    this.bottomRibbon.disableItem("ShowTotChk");
			this.bottomRibbon.disableItem("TargetLegend");

			this.bottomRibbon.hideItem("ShowTotChk");
			this.bottomRibbon.hideItem("TargetLegend");
			return;
		}


        this.bottomRibbon.showItem("ShowTotChk");
        this.bottomRibbon.showItem("TargetLegend"); 
	    this.bottomRibbon.enableItem("ShowTotChk");
	    this.bottomRibbon.enableItem("TargetLegend");

	    if (this.bShowingTotals == true)
		{
	       this.bottomRibbon.setButtonStateOff("ShowTotChk");
			
		}
		else
		{
            this.bottomRibbon.setButtonStateOn("ShowTotChk");
		}
	}



    Model.prototype.SelectModel_OKOnClick = function (action) {

        if (action == 0) {

            if (parent.SP.UI.DialogResult)
                parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
            else
                parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');


            return;
        }


		var ModelList = document.getElementById('idModelList');
		var modelID = ModelList.options[ModelList.selectedIndex].value;

		var VersionList = document.getElementById('idVersionList');
		var sVers = "";

		for (var n = 0; n < VersionList.options.length; n++) {
			if (VersionList.options[n].selected == true) {
				if (sVers == "")
					sVers = VersionList.options[n].value.toString();
				else
					sVers = sVers + "," + VersionList.options[n].value.toString();
			}

		}


  
		this.ModelVal = modelID;
		this.VersionsVal = sVers;
		this.ViewID = "";
		this.selectModelAndVersion.window("winModelAndVersionsDlg").detachObject()
		this.selectModelAndVersion.window("winModelAndVersionsDlg").close();
		this.selectModelAndVersion = null;
   

		WorkEnginePPM.Model.LoadModelData(this.TicketVal, this.ModelVal, this.VersionsVal, this.ViewID, InitialGetSortAndGroupDelegate);


	}

	Model.prototype.GetFiltering = function () {
		try {
			if (this.selectFiltering == null) {


	            this.selectFiltering = new dhtmlXWindows();
	            this.selectFiltering.setSkin("dhx_web");
	    		this.selectFiltering.enableAutoViewport(false);
				this.selectFiltering.attachViewportTo(this.clientID + "mainDiv");
				this.selectFiltering.setImagePath(this.imagePath);
				this.selectFiltering.createWindow("winFilterDlg", 20, 30, 550, 450);
				this.selectFiltering.window("winFilterDlg").setIcon("logo.ico", "logo.ico");
				this.selectFiltering.window("winFilterDlg").allowMove();
				this.selectFiltering.window("winFilterDlg").denyResize();
				this.selectFiltering.window("winFilterDlg").setModal(true);
				this.selectFiltering.window("winFilterDlg").center();
				this.selectFiltering.window("winFilterDlg").setText("Select Detail Data Filtering");
				this.selectFiltering.window("winFilterDlg").attachObject("idFilterDlgObj");
				this.selectFiltering.window("winFilterDlg").button("close").disable();
				this.selectFiltering.window("winFilterDlg").button("park").hide();
				this.selectFiltering.window("winFilterDlg").button("minmax1").hide();

				var sHTML1 = "<treegrid debug='0' sync='0' layout_url='" + this.Webservice + "' layout_method='Soap' layout_function='GetFilterGridLayout' layout_namespace='WorkEnginePPM' layout_param_Ticket='" + this.TicketVal + "' data_url='" + this.Webservice + "' data_method='Soap' data_function='GetFilterGridData' data_namespace='WorkEnginePPM' data_param_Ticket='" + this.TicketVal + "' ></treegrid>";
				this.FilterGrid = TreeGrid(sHTML1, "FilterDiv", "f_1");
				
			}
			else
				this.selectFiltering.window("winFilterDlg").show();
		}

		catch (e) {
			alert("error 1");
		}
	}

	Model.prototype.SelectFilter_OKOnClick = function (iApply) {

		var s = "";
		var sel;
		var arows;

		if (iApply != 0) {
			arows = this.FilterGrid.Rows;

			for (var i = 1; i <= this.FilterGrid.RowCount; i++) {
				sel = this.FilterGrid.GetString(arows[i], "Select");

				if (sel == " ")
					sel = 0;

				s = s + ' ' + sel;


			}
		}


		this.selectFiltering.window("winFilterDlg").detachObject()
		this.selectFiltering.window("winFilterDlg").close();
		this.selectFiltering = null;


		if (s != "") {
			WorkEnginePPM.Model.SetFilterData(this.TicketVal, s);

			if (this.GanttShowing == true)
				this.ZoomTo = this.LastSelZoomTo;

			this.DetGridDoRender = true;

			this.ShowWorkingPopup("divLoading");

			if (this.DetGrid != null)
				this.DetGrid.Reload(null);
			if (this.TotGrid != null)
				this.TotGrid.Reload(null);
		}

		this.FilterGrid.Dispose();
		this.FilterGrid = null

	}


	
	Model.prototype.GetCostTypeCmp = function () {
		try {
			if (this.selectCostTypeCmp == null) {

	            this.selectCostTypeCmp = new dhtmlXWindows();
	            this.selectCostTypeCmp.setSkin("dhx_web");
				this.selectCostTypeCmp.enableAutoViewport(false);
				this.selectCostTypeCmp.attachViewportTo(this.clientID + "mainDiv");
				this.selectCostTypeCmp.setImagePath(this.imagePath);
				this.selectCostTypeCmp.createWindow("winCTCmpDlg", 20, 30, 550, 310);
				this.selectCostTypeCmp.window("winCTCmpDlg").setIcon("logo.ico", "logo.ico");
				this.selectCostTypeCmp.window("winCTCmpDlg").allowMove();
				this.selectCostTypeCmp.window("winCTCmpDlg").denyResize();
				this.selectCostTypeCmp.window("winCTCmpDlg").setModal(true);
				this.selectCostTypeCmp.window("winCTCmpDlg").center();
				this.selectCostTypeCmp.window("winCTCmpDlg").setText("Select Totals v Cost Types Comparison");
				this.selectCostTypeCmp.window("winCTCmpDlg").attachObject("idCTCmpDlgObj");
				this.selectCostTypeCmp.window("winCTCmpDlg").button("close").disable();
				this.selectCostTypeCmp.window("winCTCmpDlg").button("park").hide();
				this.selectCostTypeCmp.window("winCTCmpDlg").button("minmax1").hide();

				var sHTML1 = "<treegrid debug='0' sync='0' layout_url='" + this.Webservice + "' layout_method='Soap' layout_function='GetTotalGridLayout' layout_namespace='WorkEnginePPM' layout_param_Ticket='" + this.TicketVal + "' data_url='" + this.Webservice + "' data_method='Soap' data_function='GetCostTypeCompareGridData' data_namespace='WorkEnginePPM' data_param_Ticket='" + this.TicketVal + "' ></treegrid>";
				this.CTCmpGrid = TreeGrid(sHTML1, "CTCmpDiv", "ctc_1");
				
			}
			else
				this.selectCostTypeCmp.window("winCTCmpDlg").show();
		}

		catch (e) {
			alert("error 1");
		}
	}

	Model.prototype.SelectCostTypeCmp_OKOnClick = function (iApply) 
	{

	   var s = "";
	   var sel;
	   var arows;

	   if (iApply != 0)
	   {
		   arows = this.CTCmpGrid.Rows;

		   this.bdoingCmp = false;

			for (var i = 1; i <= this.CTCmpGrid.RowCount; i++)
			{
				sel = this.CTCmpGrid.GetString(arows[i], "Select");

				if (sel == " ")
					sel = 0;
				else
					this.bdoingCmp = true;

				s = s + ' ' + sel;


			}
	   }


		this.selectCostTypeCmp.window("winCTCmpDlg").detachObject()
		this.selectCostTypeCmp.window("winCTCmpDlg").close();
		this.selectCostTypeCmp = null;


		if (s != "")
		{
			WorkEnginePPM.Model.SetCostTypeCompareData(this.TicketVal, s);

			this.FlashTargetMenuStuff();
			if (this.TotGrid != null)
				this.TotGrid.Reload(null);    
		}   

		this.CTCmpGrid.Dispose();
		this.CTCmpGrid = null

	}


	Model.prototype.GetTotaling = function () {
		try {
			if (this.selectFiltering == null) {

	            this.selectTotals = new dhtmlXWindows();
	            this.selectTotals.setSkin("dhx_web");
				this.selectTotals.enableAutoViewport(false);
				this.selectTotals.attachViewportTo(this.clientID + "mainDiv");
				this.selectTotals.setImagePath(this.imagePath);
				this.selectTotals.createWindow("winTotalDlg", 20, 30, 550, 400);
				this.selectTotals.window("winTotalDlg").setIcon("logo.ico", "logo.ico");
				this.selectTotals.window("winTotalDlg").allowMove();
				this.selectTotals.window("winTotalDlg").denyResize();
				this.selectTotals.window("winTotalDlg").setModal(true);
				this.selectTotals.window("winTotalDlg").center();
				this.selectTotals.window("winTotalDlg").setText("Select Total Options");
				this.selectTotals.window("winTotalDlg").attachObject("idTotalsDlgObj");
				this.selectTotals.window("winTotalDlg").button("close").disable();
				this.selectTotals.window("winTotalDlg").button("park").hide();
				this.selectTotals.window("winTotalDlg").button("minmax1").hide();

				var sHTML1 = "<treegrid debug='0' sync='0' layout_url='" + this.Webservice + "' layout_method='Soap' layout_function='GetTotalGridLayout' layout_namespace='WorkEnginePPM' layout_param_Ticket='" + this.TicketVal + "' data_url='" + this.Webservice + "' data_method='Soap' data_function='GetTotalGridData' data_namespace='WorkEnginePPM' data_param_Ticket='" + this.TicketVal + "' ></treegrid>";
				this.TotalGrid = TreeGrid(sHTML1, "TotalDiv", "t_1");
				
			}
			else
				this.selectTotals.window("winTotalDlg").show();
		}

		catch (e) {
			alert("error 1");
		}
	}
	
	Model.prototype.SelectTotals_OKOnClick = function (iApply) 
	{

	   var s = "";
	   var sel;
	   var arows;

	   if (iApply != 0)
	   {
		   arows = this.TotalGrid.Rows;

			for (var i = 1; i <= this.TotalGrid.RowCount; i++)
			{
				sel = this.TotalGrid.GetString(arows[i], "Select");

				if (sel == " ")
					sel = 0;

				s = s + ' ' + sel;


			}
	   }


		this.selectTotals.window("winTotalDlg").detachObject()
		this.selectTotals.window("winTotalDlg").close();
		this.selectTotals = null;


		if (s != "")
		{
			WorkEnginePPM.Model.SetTotalData(this.TicketVal, s);
			if (this.TotGrid != null)
				this.TotGrid.Reload(null);    
		}   


		this.TotalGrid.Dispose();
		this.TotalGrid = null
   }



	
	 Model.prototype.SelectModel_Change = function () {
		 var ModelList = document.getElementById('idModelList');
		 var modelID = ModelList.options[ModelList.selectedIndex].value;

		 WorkEnginePPM.Model.LoadSelectVersions(modelID, GetLoadSelectVersionCompleteDelegate);
	 }
	 

	Model.prototype.GetSnG = function () {
		try {
			if (this.selectSnG == null) {


				this.selectSnG = new dhtmlXWindows();
				this.selectSnG.setSkin("dhx_web");
                this.selectSnG.enableAutoViewport(false);
				this.selectSnG.attachViewportTo(this.clientID + "mainDiv");
				this.selectSnG.setImagePath(this.imagePath);
				this.selectSnG.createWindow("winSnGDlg", 20, 30, 550, 240);
				this.selectSnG.window("winSnGDlg").setIcon("logo.ico", "logo.ico");
				this.selectSnG.window("winSnGDlg").allowMove();
				this.selectSnG.window("winSnGDlg").denyResize();
				this.selectSnG.window("winSnGDlg").setModal(true);
				this.selectSnG.window("winSnGDlg").center();
				this.selectSnG.window("winSnGDlg").setText("Select Sort and Group Options");
				this.selectSnG.window("winSnGDlg").attachObject("idSortnGroupDlgObj");
				this.selectSnG.window("winSnGDlg").button("close").disable();
				this.selectSnG.window("winSnGDlg").button("park").hide();
				this.selectSnG.window("winSnGDlg").button("minmax1").hide();
				WorkEnginePPM.Model.GetSortAndGroup(this.TicketVal, GetSortAndGroupCompleteDelegate);

				
			}
			else
				this.selectSnG.window("winSnGDlg").show();
		}

		catch (e) {
			alert("error 1");
		}
	}



	Model.prototype.SelectSnG_OKOnClick = function (iApply) {
	    if (iApply == 2) {
	        var sng1 = document.getElementById('sng1');
	        var SelShowToLevel = document.getElementById('idSelShowToLevel');

	        sng1.value = 0;
	        SelShowToLevel.value = 1;
	        this.FinishSnG();
	        
	        return;
	    }

	    this.selectSnG.window("winSnGDlg").detachObject()
	    this.selectSnG.window("winSnGDlg").close();
	    this.selectSnG = null;


	    if (iApply != 0) {
	        this.DetGridDoRender = true;
	        this.TotGridDoRender = true;

	        WorkEnginePPM.Model.SetSortAndGroup(this.TicketVal, this.SnGData);
	        if (this.GanttShowing == true)
	            this.ZoomTo = this.LastSelZoomTo;

	        this.DetGridDoRender = true;
	        this.ShowWorkingPopup("divLoading");
	        if (this.DetGrid != null)
	            this.DetGrid.Reload(null);
	        if (this.TotGrid != null)
	            this.TotGrid.Reload(null);
	    }


	}

	Model.prototype.InitialGetSortAndGroupComplete = function(result)
	{
	    this.SnGData = result;
	    
        try {


	        if (this.SnGData.ViewZoomTo != "") {
	            this.ZoomTo = this.SnGData.ViewZoomTo;
	            this.LastSelZoomTo = "";
	        }

	    }
	    catch (e) { }
	
		this.OnLoadModelDataComplete();
	}

	Model.prototype.InitialGetSortAndGroup = function (result) {

		try {
		    if (result == "***PermsisionsCheck***")
		        alert("You do not have the Global Permission set to access this functionality!");
			else if (result != "")
				alert(result);
			else {
				WorkEnginePPM.Model.GetSortAndGroup(this.TicketVal, InitialGetSortAndGroupCompleteDelegate);
				return;
			}

		}
		catch (e) {
			alert("Internal Webpage error - return from LoadModelData was not a string!");

		}

		if (parent.SP.UI.DialogResult)
			parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
		else
			parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');


	}

	Model.prototype.GetSortAndGroupComplete = function(result)
	{
		this.SnGData = result;
		this.flashSnGUI();
	}

	Model.prototype.ChangeSortandGroup = function () 
	{
		if (this.bSettingSnG == true)
			return;

		window.setTimeout(FinishSnGDelegate, 10);
	}



	Model.prototype.flashSnGUI = function () {

		var sdf;
		var i;

		this.bSettingSnG == true;

		var ix = document.getElementById("rbDet").checked;

		var sng1 = document.getElementById('sng1');
		var sng2 = document.getElementById('sng2');
		var sng3 = document.getElementById('sng3');

		var dir1 = document.getElementById('SnGDir1');
		var grp1 = document.getElementById('SnGGrp1');
		var dir2 = document.getElementById('SnGDir2');
		var grp2 = document.getElementById('SnGGrp2');
		var dir3 = document.getElementById('SnGDir3');
		var grp3 = document.getElementById('SnGGrp3');

		var stl = document.getElementById('idSelShowToLevel');


		sng1.options.length = 0;
		sng2.options.length = 0;
		sng3.options.length = 0;

		stl.options.length = 0;

		var stlval = 0;

		if (ix == true)
			stlval = this.SnGData.DetShowToLevel;
		else
			stlval = this.SnGData.TotShowToLevel;

		stl.options[0] = new Option("All Levels", 0, stlval == 0, stlval == 0);

		for (i = 1; i <= 10; i++)
			stl.options[i] = new Option(i.toString(), i, stlval == i, stlval == i);





		if (ix == true) {
			for (i = 0; i < this.SnGData.DetFields.length; i++) {
				sdf = this.SnGData.DetFields[i];

				sng1.options[i] = new Option(sdf.name, sdf.fid, sdf.fid == this.SnGData.DetRows[0].fid, sdf.fid == this.SnGData.DetRows[0].fid);
				sng2.options[i] = new Option(sdf.name, sdf.fid, sdf.fid == this.SnGData.DetRows[1].fid, sdf.fid == this.SnGData.DetRows[1].fid);
				sng3.options[i] = new Option(sdf.name, sdf.fid, sdf.fid == this.SnGData.DetRows[2].fid, sdf.fid == this.SnGData.DetRows[2].fid);
			}

			dir1.checked = (this.SnGData.DetRows[0].decf == 1);
			grp1.checked = (this.SnGData.DetRows[0].grpf == 1);

			dir2.checked = (this.SnGData.DetRows[1].decf == 1);
			grp2.checked = (this.SnGData.DetRows[1].grpf == 1);

			dir3.checked = (this.SnGData.DetRows[2].decf == 1);
			grp3.checked = (this.SnGData.DetRows[02].grpf == 1);


		}
		else {

			for (i = 0; i < this.SnGData.TotFields.length; i++) {
				sdf = this.SnGData.TotFields[i];

				sng1.options[i] = new Option(sdf.name, sdf.fid, sdf.fid == this.SnGData.TotRows[0].fid, sdf.fid == this.SnGData.TotRows[0].fid);
				sng2.options[i] = new Option(sdf.name, sdf.fid, sdf.fid == this.SnGData.TotRows[1].fid, sdf.fid == this.SnGData.TotRows[1].fid);
				sng3.options[i] = new Option(sdf.name, sdf.fid, sdf.fid == this.SnGData.TotRows[2].fid, sdf.fid == this.SnGData.TotRows[2].fid);
			}

			dir1.checked = (this.SnGData.TotRows[0].decf == 1);
			grp1.checked = (this.SnGData.TotRows[0].grpf == 1);

			dir2.checked = (this.SnGData.TotRows[1].decf == 1);
			grp2.checked = (this.SnGData.TotRows[1].grpf == 1);

			dir3.checked = (this.SnGData.TotRows[2].decf == 1);
			grp3.checked = (this.SnGData.TotRows[02].grpf == 1);


		}


		this.bSettingSnG == false;
		this.FinishSnG();

	}


	Model.prototype.HandleGanttButtons = function () {
	    var cbBar = this.viewBar.getButtonState("GanttChk"); 

	    var cbsel = document.getElementById("idGanttZoom");

	    if (cbBar != true) {


	//        this.ribbonBar.setButtonStateOff("EnableGrpChk");
	//        cbsel.disabled = true;
	        this.viewBar.disableItem("idGanttZoom");
	 //       this.ribbonBar.hideItem("idGanttZoom");

	    } else {

	//        this.ribbonBar.setButtonStateOn("EnableGrpChk");
	        this.viewBar.enableItem("idGanttZoom");
	//        this.ribbonBar.showItem("idGanttZoom");
	    }


	}

    Model.prototype.FinishSnG = function () 
    {
	    if (this.bSettingSnG == true)
	        return;

	    var ix = document.getElementById("rbDet").checked;

	    var sng1 = document.getElementById('sng1');
	    var sng2 = document.getElementById('sng2');
	    var sng3 = document.getElementById('sng3');

	    var dir1 = document.getElementById('SnGDir1');
	    var grp1 = document.getElementById('SnGGrp1');
	    var dir2 = document.getElementById('SnGDir2');
	    var grp2 = document.getElementById('SnGGrp2');
	    var dir3 = document.getElementById('SnGDir3');
	    var grp3 = document.getElementById('SnGGrp3');

	    var stl = document.getElementById('idSelShowToLevel');

	    if (sng1.value == 0) 
        {

	        sng2.value = 0;
	        sng2.disabled = true;
	        sng3.value = 0;
	        sng3.disabled = true;

	        dir1.checked = false;
	        dir1.disabled = true;


	        grp1.checked = false;
	        grp1.disabled = true;
	    }
	    else 
        {
	        dir1.disabled = false;
	        grp1.disabled = false;
	        sng2.disabled = false;

	    }

	    if (sng2.value == 0) 
        {

	        sng3.value = 0;
	        sng3.disabled = true;

	        dir2.checked = false;
	        dir2.disabled = true;

	        grp2.checked = false;
	        grp2.disabled = true;
	    }
	    else 
        {
	        dir2.disabled = false;

	        if (sng1.value >= 101 && sng1.value <= 1000)
	            grp2.disabled = false;
	        else
	            grp2.disabled = (grp1.checked != true);

	        sng3.disabled = false;

	    }

	    if (sng3.value == 0) 
        {

	        dir3.checked = false;
	        dir3.disabled = true;

	        grp3.checked = false;
	        grp3.disabled = true;
	    }
	    else 
        {
	        dir3.disabled = false;

	        if (grp1.disabled == false && sng1.value >= 101 && sng1.value <= 1000) 
            {
	            if (grp2.disabled == false && sng2.value >= 101 && sng2.value <= 1000)
	                grp3.disabled = false;
	            else
	                grp3.disabled = true;
	        }
	        else
	            grp3.disabled = (grp2.checked != true);
	    }


	    if (ix == true) 
        {

	        this.SnGData.DetRows[0].fid = sng1.value;
	        this.SnGData.DetRows[0].decf = (dir1.checked ? 1 : 0);
	        this.SnGData.DetRows[0].grpf = (grp1.checked ? 1 : 0);

	        this.SnGData.DetRows[1].fid = sng2.value;
	        this.SnGData.DetRows[1].decf = (dir2.checked ? 1 : 0);
	        this.SnGData.DetRows[1].grpf = (grp2.checked ? 1 : 0);

	        this.SnGData.DetRows[2].fid = sng3.value;
	        this.SnGData.DetRows[2].decf = (dir3.checked ? 1 : 0);
	        this.SnGData.DetRows[2].grpf = (grp3.checked ? 1 : 0);

	        this.SnGData.DetShowToLevel = stl.value;
	    }
	    else 
        {
	        this.SnGData.TotRows[0].fid = sng1.value;
	        this.SnGData.TotRows[0].decf = (dir1.checked ? 1 : 0);
	        this.SnGData.TotRows[0].grpf = (grp1.checked ? 1 : 0);

	        this.SnGData.TotRows[1].fid = sng2.value;
	        this.SnGData.TotRows[1].decf = (dir2.checked ? 1 : 0);
	        this.SnGData.TotRows[1].grpf = (grp2.checked ? 1 : 0);

	        this.SnGData.TotRows[2].fid = sng3.value;
	        this.SnGData.TotRows[2].decf = (dir3.checked ? 1 : 0);
	        this.SnGData.TotRows[2].grpf = (grp3.checked ? 1 : 0);

	        this.SnGData.TotShowToLevel = stl.value;
	    }
	}
 


	Model.prototype.GetCols= function () {
		try {
			if (this.selectCols == null) {


				this.selectCols = new dhtmlXWindows();
				this.selectCols.setSkin("dhx_web");
			    this.selectCols.enableAutoViewport(false);
				this.selectCols.attachViewportTo(this.clientID + "mainDiv");
				this.selectCols.setImagePath(this.imagePath);
				this.selectCols.createWindow("winColsDlg", 20, 30, 600, 410);
				this.selectCols.window("winColsDlg").setIcon("logo.ico", "logo.ico");
				this.selectCols.window("winColsDlg").allowMove();
				this.selectCols.window("winColsDlg").denyResize();
				this.selectCols.window("winColsDlg").setModal(true);
				this.selectCols.window("winColsDlg").center();
				this.selectCols.window("winColsDlg").setText("Select Column Options");
				this.selectCols.window("winColsDlg").attachObject("idColssDlgObj");
				this.selectCols.window("winColsDlg").button("close").disable();
				this.selectCols.window("winColsDlg").button("park").hide();
				this.selectCols.window("winColsDlg").button("minmax1").hide();

				this.ColsLoading = true;

				var sHTML1 = "<treegrid debug='0' sync='0' layout_url='" + this.Webservice + "' layout_method='Soap' layout_function='GetTotalGridLayout' layout_namespace='WorkEnginePPM' layout_param_Ticket='" + this.TicketVal + "' data_url='" + this.Webservice + "' data_method='Soap' data_function='GetColumnGridData' data_namespace='WorkEnginePPM' data_param_Ticket='" + this.TicketVal + "' ></treegrid>";
				this.ColsGrid = TreeGrid(sHTML1, "ColsDiv", "col_1");
				
			}
			else
				this.selectSnG.window("selectCols").show();
		}

		catch (e) {
			alert("error 1");
		}
	}
	
	Model.prototype.GetColsComplete = function(result)
	{
		this.ColData = result;
		window.setTimeout(LoadColumnOrderData, 100);
		

   }

   Model.prototype.DoLoadColumnOrderData = function () {

       try {

           var sdf;
           var i;

           var ix = true; // document.getElementById("rbCDet").checked;

           var xarr = this.ColsGrid.Rows;
           var FreezelList = document.getElementById('idSelectFreeze');

           FreezelList.options.length = 0;


           if (ix == true) {


               FreezelList.options[0] = new Option("None", 0, this.ColData.DetFreeze == 0, this.ColData.DetFreeze == 0);


               for (i = 0; i < this.ColData.DetFields.length; i++) {
                   sdf = this.ColData.DetFields[i];
                   this.ColsGrid.SetString(xarr[i + 1], "Select", sdf.selected, 1);
                   this.ColsGrid.SetString(xarr[i + 1], "Filtering", sdf.name, 1);
                   this.ColsGrid.ShowRow(xarr[i + 1]);


                   FreezelList.options[i + 1] = new Option(sdf.name, sdf.fid, this.ColData.DetFreeze == sdf.fid, this.ColData.DetFreeze == sdf.fid);


               }

               for (i = this.ColData.DetFields.length + 1; i <= 50; ++i) {
                   this.ColsGrid.SetString(xarr[i], "Select", 0, 1);
                   this.ColsGrid.SetString(xarr[i], "Filtering", "", 1);
                   this.ColsGrid.HideRow(xarr[i]);
               }


           }
           else {
               FreezelList.options[0] = new Option("None", 0, this.ColData.TotFreeze == 0, this.ColData.TotFreeze == 0);

               for (i = 0; i < this.ColData.TotFields.length; i++) {
                   sdf = this.ColData.TotFields[i];
                   this.ColsGrid.SetString(xarr[i + 1], "Select", sdf.selected, 1);
                   this.ColsGrid.SetString(xarr[i + 1], "Filtering", sdf.name, 1);
                   this.ColsGrid.ShowRow(xarr[i + 1]);

                   FreezelList.options[i + 1] = new Option(sdf.name, sdf.fid, this.ColData.TotFreeze == sdf.fid, this.ColData.TotFreeze == sdf.fid);
               }

               for (i = this.ColData.TotFields.length + 1; i <= 50; ++i) {
                   this.ColsGrid.SetString(xarr[i], "Select", 0, 1);
                   this.ColsGrid.SetString(xarr[i], "Filtering", "", 1);
                   this.ColsGrid.HideRow(xarr[i]);
               }
           }

       }

       catch (e) {
       }
   }


   Model.prototype.SelecFreeze_Change = function () {
       var ix = true; //  document.getElementById("rbCDet").checked;
       var FreezelList = document.getElementById('idSelectFreeze');
       var fid = FreezelList.options[FreezelList.selectedIndex].value;

       if (ix == true)
           this.ColData.DetFreeze = fid;
       else
           this.ColData.TotFreeze = fid;
   }



   Model.prototype.MoveRow_Click = function (iDir) {
       var ix = true; // document.getElementById("rbCDet").checked;

       var selrow = 0;
       var x = this.ColsGrid.FRow;
       var colarr = null;

       if (x == undefined)
           return;

       selrow = x.id;


       if (selrow == 0)
           return;


       if (ix == true)
           colarr = this.ColData.DetFields;
       else
           colarr = this.ColData.TotFields;

       if (iDir == 0 && selrow == 1)
           return;

       if (iDir == 1 && selrow == colarr.length)
           return;

       var sr = colarr[selrow - 1];

       if (iDir == 0) {
           colarr[selrow - 1] = colarr[selrow - 2];
           colarr[selrow - 2] = sr;
           this.reSelRow = selrow - 1;
       }
       else {
           colarr[selrow - 1] = colarr[selrow];
           colarr[selrow] = sr;
           this.reSelRow = selrow + 1;
       }


       this.DoLoadColumnOrderData();

       window.setTimeout(ColChangeSelectRowDelegate, 100);

   }

	Model.prototype.SelectCols_OKOnClick = function (iApply) 
	{


		this.selectCols.window("winColsDlg").detachObject()
		this.selectCols.window("winColsDlg").close();
		this.selectCols = null;


		this.ColsGrid.Dispose();
		this.ColsGrid = null;

		if (iApply != 0)
		{
			this.BotGridCapture();
			WorkEnginePPM.Model.SetColumnOrder(this.TicketVal, this.ColData);

			this.ZoomTo = this.LastSelZoomTo;
			this.ShowWorkingPopup("divLoading");
			if (this.DetGrid != null)
				this.DetGrid.Reload(null);
			if (this.TotGrid != null)
				this.TotGrid.Reload(null);    
		}   
		  
	}



	Model.prototype.ColChangeSelectRow = function () 
	{
		   
		var xarr = this.ColsGrid.Rows;

		if (this.reSelRow != 0)
		{
			this.ColsGrid.Focus(xarr[this.reSelRow],"Filtering");
		}


		this.reSelRow = 0;
	}


		Model.prototype.GetCopyVersion = function () {
		try {
			if (this.selectCopy == null) {


				this.selectCopy = new dhtmlXWindows();
				this.selectCopy.setSkin("dhx_web");
			    this.selectCopy.enableAutoViewport(false);
				this.selectCopy.attachViewportTo(this.clientID + "mainDiv");
				this.selectCopy.setImagePath(this.imagePath);
				this.selectCopy.createWindow("winCVDlg", 20, 30, 600, 210);
				this.selectCopy.window("winCVDlg").setIcon("logo.ico", "logo.ico");
				this.selectCopy.window("winCVDlg").allowMove();
				this.selectCopy.window("winCVDlg").denyResize();
				this.selectCopy.window("winCVDlg").setModal(true);
				this.selectCopy.window("winCVDlg").center();
				this.selectCopy.window("winCVDlg").setText("Copy Version - Select PIs");
				this.selectCopy.window("winCVDlg").attachObject("idCopyVersionsDlgObj");
				this.selectCopy.window("winCVDlg").button("close").disable();
				this.selectCopy.window("winCVDlg").button("park").hide();
				this.selectCopy.window("winCVDlg").button("minmax1").hide();

				var FromList = document.getElementById('SelFromVersion');
				var ToList = document.getElementById('SelToVersion');


				FromList.options.length = 0;
				ToList.options.length = 0;

				for (var n = 0; n <  this.VersionsList.length; n++) {
					var Id = this.VersionsList[n].Id;
					var Name = this.VersionsList[n].Name;
					FromList.options[n] = new Option(Name, Id, n == 0, n == 0);
					if (n != 0 && this.VersionsList[n].editable == 1) 
						ToList.options[n -1] = new Option(Name, Id, n == 1, n == 1);
				}

				this.SelectVersionChange_Change();
				
			}
			else
				this.selectCopy.window("winCVDlg").show();
		}

		catch (e) {
			alert("error 1");
		}
	}

	Model.prototype.SelectVersionChange_Change = function () 
	{
		var FromList = document.getElementById('SelFromVersion');
		var ToList = document.getElementById('SelToVersion');

		var fromlID = FromList.options[FromList.selectedIndex].value;
		var ToID = ToList.options[ToList.selectedIndex].value;

		 WorkEnginePPM.Model.LoadCopyVersionPILists(this.TicketVal, fromlID, ToID, GetLoadSelectCopyVersionListsCompleteDelegate);


	}


	Model.prototype.GetLoadSelectCopyVersionListsComplete = function (result) {

		var ToList = document.getElementById('idSelVersTo');
		var BothList = document.getElementById('idSelVersBoth');
		var sdf = null;
		var i;

		ToList.options.length = 0;
		BothList.options.length = 0;

		for (i = 0; i < result.DetFields.length; i++) {
			sdf = result.DetFields[i];

			ToList.options[i] = new Option(sdf.name, sdf.fid, true, true);


		}

		for (i = 0; i < result.TotFields.length; i++) {
			sdf = result.TotFields[i];

			BothList.options[i] = new Option(sdf.name, sdf.fid, true, true);

		}


	}



	Model.prototype.SelectCopyVersion_OKOnClick = function (iApply) {

		var s = "";
		var sel;
		var arows;
		var n;


		this.selectCopy.window("winCVDlg").detachObject()
		this.selectCopy.window("winCVDlg").close();
		this.selectCopy = null;




		if (iApply == 1) {
			var sPIs = "";
			var bOneNotSelected = false;

			var ToList = document.getElementById('idSelVersTo');
			var BothList = document.getElementById('idSelVersBoth');

			var FromVer = document.getElementById('SelFromVersion');
			var ToVer = document.getElementById('SelToVersion');

			var fromlID = FromVer.options[FromVer.selectedIndex].value;
			var ToID = ToVer.options[ToVer.selectedIndex].value;

			for (n = 0; n < ToList.options.length; n++) {
				if (ToList.options[n].selected == true) {
					if (sPIs == "")
						sPIs = ToList.options[n].value.toString();
					else
						sPIs = sPIs + "," + ToList.options[n].value.toString();
				}
				else
					bOneNotSelected = true;
			}

			for (n = 0; n < BothList.options.length; n++) {
				if (BothList.options[n].selected == true) {
					if (sPIs == "")
						sPIs = BothList.options[n].value.toString();
					else
						sPIs = sPIs + "," + BothList.options[n].value.toString();
				}
				else
					bOneNotSelected = true;
			}

			if (sPIs == "")
				return;

			if (bOneNotSelected == false)
				sPIs = "";

			WorkEnginePPM.Model.DoCopyVersion(this.TicketVal, fromlID, ToID, sPIs);

			if (this.GanttShowing == true)
				this.ZoomTo = this.LastSelZoomTo;
			this.DetGridDoRender = true;

			this.ShowWorkingPopup("divLoading");
			if (this.TotGrid != null)
				this.TotGrid.Reload(null);
			if (this.DetGrid != null)
				this.DetGrid.Reload(null);
		}



	}


	Model.prototype.DoDelete = function () {
	    try {
	        if (this.saveOrApply == null) {

	            var idCopyNameDiv = document.getElementById('idCopyNameDiv');

	            this.saveOrApply = new dhtmlXWindows();
	            this.saveOrApply.setSkin("dhx_web");
	            this.saveOrApply.enableAutoViewport(false);
	            this.saveOrApply.attachViewportTo(this.clientID + "mainDiv");
	            this.saveOrApply.setImagePath(this.imagePath);

	            if (this.DoingCopy == false) {
	                idCopyNameDiv.style.display = "none";
	                this.saveOrApply.createWindow("winSoADlg", 20, 30, 250, 135);
	            }
	            else {
	                idCopyNameDiv.style.display = "block";
	                this.saveOrApply.createWindow("winSoADlg", 20, 30, 550, 200);
	            }

	            this.saveOrApply.window("winSoADlg").setIcon("logo.ico", "logo.ico");
	            this.saveOrApply.window("winSoADlg").allowMove();
	            this.saveOrApply.window("winSoADlg").denyResize();
	            this.saveOrApply.window("winSoADlg").setModal(true);
	            this.saveOrApply.window("winSoADlg").center();



	            if (this.DoingDelete == true)
	                this.saveOrApply.window("winSoADlg").setText("Select which Target to Delete");
	            else if (this.DoingCopy == false)
	                this.saveOrApply.window("winSoADlg").setText("Select which Target to Edit");
	            else
	                this.saveOrApply.window("winSoADlg").setText("Select which Target to Copy");

	            this.saveOrApply.window("winSoADlg").attachObject("idSaveVersionOrApplyTargetDlgObj");
	            this.saveOrApply.window("winSoADlg").button("close").disable();
	            this.saveOrApply.window("winSoADlg").button("park").hide();
	            this.saveOrApply.window("winSoADlg").button("minmax1").hide();

	            var SVoT = document.getElementById('idSaveorApply');
	            SVoT.options.length = 0;


	            for (var n = 0; n < this.VersionsOrTargets.length; n++) {
	                var Id = this.VersionsOrTargets[n].Id;
	                var Name = this.VersionsOrTargets[n].Name;
	                SVoT.options[n] = new Option(Name, Id, n == 0, n == 0);
	            }



	        }
	        else
	            this.saveOrApply.window("winSoADlg").show();
	    }

	    catch (e) {
	        alert("error 1");
	    }
	}


	Model.prototype.DoSaveorApply = function () {
		try {
			var n;

			if (this.saveOrApply == null) {


				this.saveOrApply = new dhtmlXWindows();
				this.saveOrApply.setSkin("dhx_web");
			    this.saveOrApply.enableAutoViewport(false);
				this.saveOrApply.attachViewportTo(this.clientID + "mainDiv");
				this.saveOrApply.setImagePath(this.imagePath);
				this.saveOrApply.createWindow("winSoADlg", 20, 30, 230, 145);
				this.saveOrApply.window("winSoADlg").setIcon("logo.ico", "logo.ico");
				this.saveOrApply.window("winSoADlg").allowMove();
				this.saveOrApply.window("winSoADlg").denyResize();
				this.saveOrApply.window("winSoADlg").setModal(true);
				this.saveOrApply.window("winSoADlg").center();

				if (this.FromTarget == true)
					this.saveOrApply.window("winSoADlg").setText("Select Target to Apply");
				else
					this.saveOrApply.window("winSoADlg").setText("Select Version to Save");

				this.saveOrApply.window("winSoADlg").attachObject("idSaveVersionOrApplyTargetDlgObj");
				this.saveOrApply.window("winSoADlg").button("close").disable();
				this.saveOrApply.window("winSoADlg").button("park").hide();
				this.saveOrApply.window("winSoADlg").button("minmax1").hide();

				var SVoT = document.getElementById('idSaveorApply');
				SVoT.options.length = 0;

				if (this.FromTarget == true) {
					SVoT.options[0] = new Option("None", 0, true, true);
					for (n = 0; n < this.VersionsOrTargets.length; n++) {
						var Id1 = this.VersionsOrTargets[n].Id;
						var Name1 = this.VersionsOrTargets[n].Name;
						SVoT.options[n + 1] = new Option(Name1, Id1, false, false);
					}

				}
				else {

					for (n = 0; n < this.VersionsOrTargets.length; n++) {
						var Id2 = this.VersionsOrTargets[n].Id;
						var Name2 = this.VersionsOrTargets[n].Name;
						SVoT.options[n] = new Option(Name2, Id2, n == 0, n == 0);
					}
				}



			}
			else
				this.saveOrApply.window("winSoADlg").show();
		}

		catch (e) {
			alert("error 1");
		}
	}


	Model.prototype.SelectSaveOrApply_OKOnClick = function (iApply) {

	    var s = "";
	    var sel;
	    var arows;

	    var oName = document.getElementById('idcopynametext').value;
	    var oDesc = document.getElementById('idcopydesctext').value;

	    oName = trim(oName);

	    if (this.DoingCopy == false && this.DoingCopy == true && oName.length == 0) {
	        alert("You must supply a new target name");
	        return;
	    }


	    this.saveOrApply.window("winSoADlg").detachObject()
	    this.saveOrApply.window("winSoADlg").close();
	    this.saveOrApply = null;



	    if (iApply == 1) {
	        var SVoT = document.getElementById('idSaveorApply');
	        var ID = SVoT.options[SVoT.selectedIndex].value;
	        var sName = SVoT.options[SVoT.selectedIndex].text;

	        if (this.viaPopulateTarget == true) {
	            this.viaPopulateTarget = false;
//	            this.dlgEditTarget.window("winEditTargetDlg").show();
	            WorkEnginePPM.Model.ReturnVersionAsTarget(this.TicketVal, ID, GetVersionTargetCompleteDelegate);


	        }
	        else if (this.FromTarget == true) {
	            if (this.DoingDelete == true) {
	                this.DoingDelete == false;
	                WorkEnginePPM.Model.DoDeleteTarget(this.TicketVal, ID);
	            }
	            else if (this.DoingEdit == true) {
	                this.DoingEdit == false;

	                if (this.DoingCopy == false) {
	                    this.GoDoEditID = ID;
	                    this.GoDoEditName = sName;

	                    window.setTimeout(GoDoEditTimerDelegate, 100);
	                }
	                else {


	                    WorkEnginePPM.Model.CreateTarget(this.TicketVal, oName, oDesc, 0, ID, CreateTargetCompleteDelegate);

	                }

	                //  this.GoDoEdit(ID, sName);
	                return;
	            }
	            else {

	                this.bdoingCmp = (ID != 0);
	                WorkEnginePPM.Model.DoLoadTarget(this.TicketVal, ID);
	                this.FlashTargetMenuStuff();
	                if (this.TotGrid != null)
	                    this.TotGrid.Reload(null);

	            }
	        }
	        else
	            WorkEnginePPM.Model.DoSaveVersion(this.TicketVal, ID);
	    }


	    if (this.viaPopulateTarget == true) {
	        this.viaPopulateTarget = false;
	//        this.dlgEditTarget.window("winEditTargetDlg").show();
	    }


	}

	Model.prototype.GoDoEditTimer = function () {
		this.GoDoEdit(this.GoDoEditID, this.GoDoEditName);
	}

	Model.prototype.GetSaveOrTargetsComplete = function (result) 
	{

		this.VersionsOrTargets = result;

		if (result.length == 0)
		{
			
			if (this.FromTarget == false)
				alert("There are either no versions defined or versions that have been loaded or copied to save!");
			else
				alert("No Targets have been defined  or are available to apply");

			return;
		}

 
		this.DoSaveorApply();
 
   }
	Model.prototype.GetDeleteEditTargetsComplete = function (result) 
	{

		this.VersionsOrTargets = result;

		if (result.length == 0)
		{
			if (this.DoingDelete == true)
			   alert("No Targets have been defined  or are available to delete");
			else if (this.DoingCopy == false)
			    alert("No Targets have been defined or are available to edit");
		    else
		        alert("No Targets have been defined or are available to copy");

			return;
		}

 
		this.DoDelete();
 
   }

   


   Model.prototype.GetPeriodsandDisplayOpts = function (result) {
		try {
			
			 this.PeriodsandOptions = result;
			 if (this.selectPoD == null) {


				this.selectPoD = new dhtmlXWindows();
				this.selectPoD.setSkin("dhx_web");
			     this.selectPoD.enableAutoViewport(false);
				this.selectPoD.attachViewportTo(this.clientID + "mainDiv");
				this.selectPoD.setImagePath(this.imagePath);
				this.selectPoD.createWindow("winPoDDlg", 20, 30, 500, 230);
				this.selectPoD.window("winPoDDlg").setIcon("logo.ico", "logo.ico");
				this.selectPoD.window("winPoDDlg").allowMove();
				this.selectPoD.window("winPoDDlg").denyResize();
				this.selectPoD.window("winPoDDlg").setModal(true);
				this.selectPoD.window("winPoDDlg").center();

				this.selectPoD.window("winPoDDlg").setText("Select Periods and Display Options");
 
				this.selectPoD.window("winPoDDlg").attachObject("idPerDispOptsDlgObj");
				this.selectPoD.window("winPoDDlg").button("close").disable();
				this.selectPoD.window("winPoDDlg").button("park").hide();
				this.selectPoD.window("winPoDDlg").button("minmax1").hide();


			   var dispFrom = document.getElementById('idDispPerFrom');
			   var dispTo = document.getElementById('idDispPerTo');
			   var dragFrom = document.getElementById('idDragPerFrom');
			   var dragTo = document.getElementById('idDragPerTo');

			   var showQTY = document.getElementById('idShowQTY');
			   var idUseQTY = document.getElementById('idUseQTY');
			   var idUseFTE = document.getElementById('idUseFTE');
			   var showCosts = document.getElementById('idShowCosts');
			   var showRHSDecCosts = document.getElementById('idShowCostDecVals');


			   var dragOptsRow =  document.getElementById('idDragOpts');
			   
			   dispFrom.options.length = 0;
			   dispTo.options.length = 0;
			   dragFrom.options.length = 0;
			   dragTo.options.length = 0;

			   if (this.IsModeller  == false)
				   dragOptsRow.style.display = 'none';


				for (var n = 1; n <= this.PeriodsandOptions.Periods.length; n++) {
					var Id = this.PeriodsandOptions.Periods[n - 1].Id;
					var Name = this.PeriodsandOptions.Periods[n - 1].Name;
				   dispFrom.options[n - 1] = new Option(Name, Id, n == this.PeriodsandOptions.displayStart, n == this.PeriodsandOptions.displayStart);
				   dispTo.options[n - 1] = new Option(Name, Id, n == this.PeriodsandOptions.displayFinish, n == this.PeriodsandOptions.displayFinish);
				   dragFrom.options[n - 1] = new Option(Name, Id, n == this.PeriodsandOptions.dragStart, n == this.PeriodsandOptions.dragStart);
				   dragTo.options[n - 1] = new Option(Name, Id, n == this.PeriodsandOptions.dragFinish, n == this.PeriodsandOptions.dragFinish);
			   }


			showQTY.checked  = (this.PeriodsandOptions.showQTY == 1);
			showCosts.checked = (this.PeriodsandOptions.showCosts == 1);

			idUseQTY.disabled = (showQTY.checked == false);
			idUseFTE.disabled = (showQTY.checked == false);

			idUseFTE.checked =  (this.PeriodsandOptions.showWhichQTY == 1);
			idUseQTY.checked = (this.PeriodsandOptions.showWhichQTY == 0);

			showRHSDecCosts.checked = (this.PeriodsandOptions.showRHSDecCosts == 1);
			   
			}
			else
				this.selectPoD.window("winPoDDlg").show();
		}

		catch (e) {
			alert("error 1");
		}
	}


   Model.prototype.SelectPerDisp_OKOnClick = function (iApply) 
	{

		var showQTY = document.getElementById('idShowQTY');
		var showCosts = document.getElementById('idShowCosts');

		if ((showQTY.checked == false) && (showCosts.checked == false) && iApply == 1)
		{
			alert("Either Costs or QTY must be selected to be able to apply the changes!");
			return;
		}

		this.selectPoD.window("winPoDDlg").detachObject()
		this.selectPoD.window("winPoDDlg").close();
		this.selectPoD = null;

		if (iApply == 1)
		{
			this.BotGridCapture();
			WorkEnginePPM.Model.SetPeriodsandDisplay(this.TicketVal, this.PeriodsandOptions);
			try {
				if (this.GanttShowing == true)
					this.ZoomTo = this.LastSelZoomTo;

				this.DetGridDoRender = true;

				this.ShowWorkingPopup("divLoading");
				if (this.TotGrid != null)
					this.TotGrid.Reload(null);
				if (this.DetGrid != null)
					this.DetGrid.Reload(null);
		   }
		   catch (e) {

			}

		}

	}

	Model.prototype.SelectPOA_Change = function () 
	{

		var dispFrom = document.getElementById('idDispPerFrom');
		var dispTo = document.getElementById('idDispPerTo');
		var dragFrom = document.getElementById('idDragPerFrom');
		var dragTo = document.getElementById('idDragPerTo');

		var showQTY = document.getElementById('idShowQTY');
		var idUseQTY = document.getElementById('idUseQTY');
		var idUseFTE = document.getElementById('idUseFTE');
		var showCosts = document.getElementById('idShowCosts');
		var showRHSDecCosts = document.getElementById('idShowCostDecVals');

		idUseQTY.disabled = (showQTY.checked == false);
		idUseFTE.disabled = (showQTY.checked == false);

		this.PeriodsandOptions.displayStart = dispFrom.options[dispFrom.selectedIndex].value;
		this.PeriodsandOptions.displayFinish = dispTo.options[dispTo.selectedIndex].value;
		this.PeriodsandOptions.dragStart = dragFrom.options[dragFrom.selectedIndex].value;
		this.PeriodsandOptions.dragFinish = dragTo.options[dragTo.selectedIndex].value;


		this.PeriodsandOptions.showQTY = (showQTY.checked ? 1 : 0);
		this.PeriodsandOptions.showCosts = (showCosts.checked ? 1 : 0);

		this.PeriodsandOptions.showWhichQTY = (idUseFTE.checked ? 1 : 0);

		this.PeriodsandOptions.showRHSDecCosts =  (showRHSDecCosts.checked ? 1 : 0);
 
	
	}




	Model.prototype.ManageUserViews = function () {

		if (this.UserViewsObj == null) {


			this.UserViewsObj = new dhtmlXWindows();
			this.UserViewsObj.setSkin("dhx_web");
		    this.UserViewsObj.enableAutoViewport(false);
			this.UserViewsObj.attachViewportTo(this.clientID + "mainDiv");
			this.UserViewsObj.setImagePath(this.imagePath);
			this.UserViewsObj.createWindow("winUserVDlg", 20, 30, 300, 185);
			this.UserViewsObj.window("winUserVDlg").setIcon("logo.ico", "logo.ico");
			this.UserViewsObj.window("winUserVDlg").allowMove();
			this.UserViewsObj.window("winUserVDlg").denyResize();
			this.UserViewsObj.window("winUserVDlg").setModal(true);
			this.UserViewsObj.window("winUserVDlg").center();

			this.UserViewsObj.window("winUserVDlg").setText("Manage User Views");

			this.UserViewsObj.window("winUserVDlg").attachObject("idUserViewsDlgObj");
			this.UserViewsObj.window("winUserVDlg").button("close").disable();
			this.UserViewsObj.window("winUserVDlg").button("park").hide();
			this.UserViewsObj.window("winUserVDlg").button("minmax1").hide();

			var SelView = document.getElementById('idSelectUserView');
			var txtName = document.getElementById('idUserViewText');

			SelView.options.length = 0;

			var bSel = false
			var optSelView = null;

			for (var i = 0; i < this.UserViews.length; i++) {
				var uv = this.UserViews[i];

				if (this.CurrUserView == "")
					bSel = (i == 0);
				else {
					bSel = (this.CurrUserView == uv.Name);
				}

				SelView.options[i] = new Option(uv.Name, i + 1, bSel, bSel);

				if (bSel) {
					txtName.value = uv.Name;
					optSelView = uv;
				}

			}

			if (SelView != null && this.UserViews.length > 0) {

				var rbLocal = document.getElementById('idrbUserLocal');
				var rbGlobal = document.getElementById('idrbUserGlobal');

			   //alert(optSelView.Id + " " + optSelView.Name);

				if (optSelView.Id == 0)
					rbGlobal.checked = true;
				else
					rbLocal.checked = true;
			}



		}
		else
			this.UserViewsObj.window("winUserVDlg").show();
	}


	
	Model.prototype.SelectUserView_Change = function () {

		 var SelView = document.getElementById('idSelectUserView');
		 var ViewName = SelView.options[SelView.selectedIndex].text;

		 var txtName = document.getElementById('idUserViewText');

		 txtName.value = ViewName;
		 var rbLocal = document.getElementById('idrbUserLocal');
		 var rbGlobal = document.getElementById('idrbUserGlobal');

		 var indx = SelView.options[SelView.selectedIndex].value - 1;
		 
		 
		 if (this.UserViews[indx].Id == 0)
			  rbGlobal.checked = true;
		 else
			 rbLocal.checked = true;

	}

	Model.prototype.UserView_OnClick = function (iApply) {

		this.UserViewsObj.window("winUserVDlg").detachObject()
		this.UserViewsObj.window("winUserVDlg").close();
		this.UserViewsObj = null;



		var SelView = document.getElementById('idSelectUserView');
		var txtName = document.getElementById('idUserViewText').value;
		var rbLocal = document.getElementById('idrbUserLocal');
		var rbGlobal = document.getElementById('idrbUserGlobal');
		var locflag = (rbLocal.checked == true ? 1 : 0);
		var SelViewName = "";
		var indx = 0;


		if (iApply == 2 && this.UserViews.length > 0) {

			SelVewName = SelView.options[SelView.selectedIndex].text;
			indx = SelView.options[SelView.selectedIndex].value - 1;

			var lloc = (this.UserViews[indx].Id == 0 ? 0 : 1);

			var uv = this.UserViews[indx];

			if (this.CurrUserView == uv.Name)
			    this.CurrUserView = ""; 
 
			WorkEnginePPM.Model.DeleteUserViewData(this.TicketVal, SelViewName, lloc, LoadUserViewDataCompleteDelegate);

		}


		if (iApply == 1) {

		    WorkEnginePPM.Model.SaveUserViewData(this.TicketVal, txtName, locflag, this.ZoomString, LoadUserViewDataCompleteDelegate);
		}
	}


	Model.prototype.SelectUserViewDataComplete = function (data) {

	    if (data != null) {


	        this.SnGData = data;
	        try {


	            if (this.SnGData.ViewZoomTo != "") {
	                this.ZoomTo = this.SnGData.ViewZoomTo;
	                this.LastSelZoomTo = "";
	            }

	        }
	        catch (e) { }
	    }

	    this.bdoingCmp = (this.SnGData.TotalsCmp == 1);
	    this.FlashTargetMenuStuff();

	    this.ShowWorkingPopup("divLoading");

	    if (this.DetGrid != null)
	        this.DetGrid.Reload(null);
	    if (this.TotGrid != null)
	        this.TotGrid.Reload(null);

	    // sort out menus
	}
  
	Model.prototype.layoutOnResizeFinish = function (data) {
		//alert("layout_OnResizeFinish");
	}

	Model.prototype.toolbarOnClick = function (id, data) {

	    if (id == "Dont_Select_PI") {

	        this.selectPIList.window("winSELPIDlg").setModal(false);
	        this.selectPIList.window("winSELPIDlg").hide();
	        this.selectPIList.window("winSELPIDlg").detachObject()
	        this.selectPIList = null;

	        if (parent.SP.UI.DialogResult)
	            parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
	        else
	            parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');

	        return;
	    }

	    if (id == "Select_PI") {

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
	    }

	    if (id == "Ribbon_Toggle") {
	        if (this.ribbonBar.isCollapsed() == true) {
	            this.layout.cells(this.mainRibbonArea).fixSize(false, false);
	            this.layout.cells(this.mainRibbonArea).setHeight(120);
	            this.layout.cells(this.mainRibbonArea).fixSize(false, true);
	            this.ribbonBar.expand();
	            this.viewBar.expand();

	        } else {
	            this.layout.cells(this.mainRibbonArea).fixSize(false, false);
	            this.layout.cells(this.mainRibbonArea).setHeight(50);
	            this.layout.cells(this.mainRibbonArea).fixSize(false, true);
	            this.ribbonBar.collapse();
	            this.viewBar.collapse();
	        }

	        return;
	    }


	    if (id == "BottomRibbon_Toggle") {
	        if (this.bottomRibbon.isCollapsed() == true) {
	            this.layout_totals.cells(this.totalsRibbonArea).fixSize(false, false);
	            this.layout_totals.cells(this.totalsRibbonArea).setHeight(68);
	            this.layout_totals.cells(this.totalsRibbonArea).fixSize(false, true);
	            this.bottomRibbon.expand();


	        } else {
	            this.layout_totals.cells(this.totalsRibbonArea).fixSize(false, false);
	            this.layout_totals.cells(this.totalsRibbonArea).setHeight(22);
	            this.layout_totals.cells(this.totalsRibbonArea).fixSize(false, true);
	            this.bottomRibbon.collapse();

	        }

	        return;
	    }


	    if (id == "View_Toggle") {
	        if (this.viewBar.isCollapsed() == true) {
	            this.layout.cells(this.mainRibbonArea).fixSize(false, false);
	            this.layout.cells(this.mainRibbonArea).setHeight(120);
	            this.layout.cells(this.mainRibbonArea).fixSize(false, true);
	            this.ribbonBar.expand();
	            this.viewBar.expand();

	        } else {
	            this.layout.cells(this.mainRibbonArea).fixSize(false, false);
	            this.layout.cells(this.mainRibbonArea).setHeight(50);
	            this.layout.cells(this.mainRibbonArea).fixSize(false, true);
	            this.ribbonBar.collapse();
	            this.viewBar.collapse();
	        }

	        return;
	    }



	    if (id == "GanttZoom_Changed") {

	        var selectZoom = document.getElementById("idGanttZoom");

	        var selectedItem = selectZoom.options[selectZoom.selectedIndex];
	        if (selectedItem.value != null)
	            id = "Zoom" + selectedItem.value;

	    }

	    if (id == "UserViewChanged") {
	        var selectUV = document.getElementById("idUserViews");

	        var selectedview = selectUV.options[selectUV.selectedIndex];
	        if (selectedview.value != null) {

	            if (selectedview.value == -1) {
	                this.CurrUserView = "";
	            }
	            else {

	                var uvx = this.UserViews[selectedview.value];
	                this.CurrUserView = uvx.Name;

	                WorkEnginePPM.Model.SelectUserViewData(this.TicketVal, selectedview.value, SelectUserViewDataCompleteDelegate);
	                if (this.GanttShowing == true)
	                    this.ZoomTo = this.LastSelZoomTo;

	                this.DetGridDoRender = true;
	                this.TotGridDoRender = true;
	            }


	        }
	        return;

	    }


	    if (id.substring(0, 5) == "view_") {
	        var s = id.slice(5);

	        var uv = this.UserViews[s];
	        this.CurrUserView = uv.Name;

	        WorkEnginePPM.Model.SelectUserViewData(this.TicketVal, s, SelectUserViewDataCompleteDelegate);
	        if (this.GanttShowing == true)
	            this.ZoomTo = this.LastSelZoomTo;

	        this.DetGridDoRender = true;
	        this.TotGridDoRender = true;


	        return;
	    }


	    if (id == "CloseBtn") {
	        if (parent.SP.UI.DialogResult)
	            parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
	        else
	            parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');


	        return;
	    }

	    var Grid;

	    if (id == "View_RenameView") {
	        var bPersonal = false;

	        document.getElementById("id_RenameView_Name").value = "";

	        var selectView = document.getElementById("idUserViews");
	        if (selectView != null && selectView.selectedIndex >= 0) {


	            var selectedItem = selectView.options[selectView.selectedIndex];

	            if (selectedItem.value != null) {

	                if (selectedItem.value != -1) {
	                    var uv = this.UserViews[selectedItem.value];
	                } else {
	                    alert("Please select a view to rename first");
	                    return;
	                }
	            }

	            document.getElementById("id_SaveView_Name").value = selectedItem.text;
	        }

	        if (this.ModelViewDlg == null) {
	            this.ModelViewDlg = new dhtmlXWindows();
	            this.ModelViewDlg.setSkin("dhx_web");
	            this.ModelViewDlg.enableAutoViewport(false);
	            this.ModelViewDlg.attachViewportTo(this.params.ClientID + "mainDiv");
	            this.ModelViewDlg.setImagePath("/_layouts/ppm/images/");
	            this.ModelViewDlg.createWindow("winModelViewDlg", 20, 30, 280, 202);
	            this.ModelViewDlg.window("winModelViewDlg").setIcon("logo.ico", "logo.ico");
	            this.ModelViewDlg.window("winModelViewDlg").denyResize();
	            this.ModelViewDlg.window("winModelViewDlg").button("park").hide();
	            this.ModelViewDlg.window("winModelViewDlg").button("minmax1").hide();
	            this.ModelViewDlg.window("winModelViewDlg").setModal(true);
	            this.ModelViewDlg.window("winModelViewDlg").center();
	            this.ModelViewDlg.window("winModelViewDlg").setText("Save View");

	            this.ModelViewDlg.window("winModelViewDlg").attachObject("idRenameViewDlg");
	        }
	        else {
	            this.ModelViewDlg.window("winModelViewDlg").show();
	        }
	        return;
	    }

	    if (id == "ViewTab_SaveView") {
	        var bPersonal = false;

	        document.getElementById("id_SaveView_Name").value = "New View";

	        document.getElementById("id_SaveView_Personal").checked = true;
	        document.getElementById("id_SaveView_Default").checked = false;

	        var selectView = document.getElementById("idUserViews");
	        if (selectView != null && selectView.selectedIndex >= 0) {


	            var selectedItem = selectView.options[selectView.selectedIndex];

	            if (selectedItem.value != null) {

	                if (selectedItem.value != -1) {
	                    var uv = this.UserViews[selectedItem.value];
	                    bPersonal = (uv.Id != 0);
	                }
	            }

	            document.getElementById("id_SaveView_Name").value = selectedItem.text;

	            document.getElementById("id_SaveView_Personal").checked = bPersonal;
	        }

	        if (this.ModelViewDlg == null) {
	            this.ModelViewDlg = new dhtmlXWindows();
	            this.ModelViewDlg.setSkin("dhx_web");
	            this.ModelViewDlg.enableAutoViewport(false);
	            this.ModelViewDlg.attachViewportTo(this.params.ClientID + "mainDiv");
	            this.ModelViewDlg.setImagePath("/_layouts/ppm/images/");
	            this.ModelViewDlg.createWindow("winModelViewDlg", 20, 30, 280, 202);
	            this.ModelViewDlg.window("winModelViewDlg").setIcon("logo.ico", "logo.ico");
	            this.ModelViewDlg.window("winModelViewDlg").denyResize();
	            this.ModelViewDlg.window("winModelViewDlg").button("park").hide();
	            this.ModelViewDlg.window("winModelViewDlg").button("minmax1").hide();
	            this.ModelViewDlg.window("winModelViewDlg").setModal(true);
	            this.ModelViewDlg.window("winModelViewDlg").center();
	            this.ModelViewDlg.window("winModelViewDlg").setText("Save View");
	            //  this.ModelViewDlg.window("winModelViewDlg").attachEvent("onClose", function (win) { AnalyzerViewDlg_OnCloseDelegate(); return true; });
	            this.ModelViewDlg.window("winModelViewDlg").attachObject("idSaveViewDlg");
	        }
	        else {
	            this.ModelViewDlg.window("winModelViewDlg").show();
	        }
	        return;
	    }


	    if (id == "View_DeleteView") {
	        document.getElementById("id_DeleteView_Name").value = "";
	        var selectView = document.getElementById("idUserViews");
	        var bpers = false;
	        if (selectView != null && selectView.selectedIndex >= 0) {

	            var selectedItem = selectView.options[selectView.selectedIndex];

	            if (selectedItem.value != null) {

	                if (selectedItem.value != -1) {
	                    var uv = this.UserViews[selectedItem.value];
	                    bpers = (uv.Id != 0);
	                } else {
	                    alert("No View has been selected");
	                    return;

	                }
	            }

	            document.getElementById("id_DeleteView_Name").value = selectedItem.text;
	        }

	        if (this.ModelerDeleteViewDlg == null) {
	            this.ModelerDeleteViewDlg = new dhtmlXWindows();
	            this.ModelerDeleteViewDlg.setSkin("dhx_web");
	            this.ModelerDeleteViewDlg.enableAutoViewport(false);
	            this.ModelerDeleteViewDlg.attachViewportTo(this.params.ClientID + "mainDiv");
	            this.ModelerDeleteViewDlg.setImagePath("/_layouts/ppm/images/");
	            this.ModelerDeleteViewDlg.createWindow("winModelerDeleteViewDlg", 20, 30, 280, 167);
	            this.ModelerDeleteViewDlg.window("winModelerDeleteViewDlg").setIcon("logo.ico", "logo.ico");
	            this.ModelerDeleteViewDlg.window("winModelerDeleteViewDlg").denyResize();

	            this.ModelerDeleteViewDlg.window("winModelerDeleteViewDlg").button("park").hide();
	            this.ModelerDeleteViewDlg.window("winModelerDeleteViewDlg").button("minmax1").hide();
	            //this.ViewDlg.setSkin(this.params.DHTMLXSkin);                this.ModelerDeleteViewDlg.window("winModelerDeleteViewDlg").setModal(true);
	            this.ModelerDeleteViewDlg.window("winModelerDeleteViewDlg").center();
	            this.ModelerDeleteViewDlg.window("winModelerDeleteViewDlg").setText("Delete View");

	            this.ModelerDeleteViewDlg.window("winModelerDeleteViewDlg").attachObject("idDeleteViewDlg");
	        } else {
	            this.ViewDlg.window("winViewDlg").show();
	        }

	        return;

	    }
	    if (id == "DeleteView_OK") {
	        this.ModelerDeleteViewDlg.window("winModelerDeleteViewDlg").setModal(false);
	        this.ModelerDeleteViewDlg.window("winModelerDeleteViewDlg").hide();
	        this.ModelerDeleteViewDlg.window("winModelerDeleteViewDlg").detachObject();
	        this.ModelerDeleteViewDlg = null;

	        if (this.UserViews.length > 0) {

	            var SelView = document.getElementById("idUserViews");
	            var SelViewName = SelView.options[SelView.selectedIndex].text;
	            indx = SelView.selectedIndex - 1;

	            var lloc = (this.UserViews[indx].Id == 0 ? 0 : 1);

	            var uv = this.UserViews[indx];
	            this.CurrUserView = "";

	            WorkEnginePPM.Model.DeleteUserViewData(this.TicketVal, SelViewName, lloc, LoadUserViewDataCompleteDelegate);

	        }

	        return;


	    }


	    if (id == "DeleteView_Cancel") {
	        this.ModelerDeleteViewDlg.window("winModelerDeleteViewDlg").setModal(false);
	        this.ModelerDeleteViewDlg.window("winModelerDeleteViewDlg").hide();
	        this.ModelerDeleteViewDlg = null;
	        this.ModelerDeleteViewDlg.window("winModelerDeleteViewDlg").detachObject();
	        return;
	    }


	    if (id == "SaveView_Cancel" || id == "RenameView_Cancel") {
	        this.ModelViewDlg.window("winModelViewDlg").setModal(false);
	        this.ModelViewDlg.window("winModelViewDlg").hide();
	        this.ModelViewDlg.window("winModelViewDlg").detachObject();
	        this.ModelViewDlg = null;
	        return;
	    }

	    if (id == "SaveView_OK") {


	        var txtName = document.getElementById('id_SaveView_Name').value;

	        //if (txtName == "") {
	        //    alert("Please enter a view name");
	        //    return;
	        //}
	        //TO check entered value is blank or with only space.
	        var val = txtName.replace(/^\s+|\s+$/, '');
	        if (val.length == 0) {
	            alert("Please enter a valid view name");
	            return;
	        }

	        var rbLocal = document.getElementById("id_SaveView_Personal").checked;
	        var locflag = (rbLocal == true ? 1 : 0);
	        var rbDef = document.getElementById("id_SaveView_Default").checked;
	        if (rbDef == true)
	            locflag += 2;

	        this.CurrUserView = txtName;

	        WorkEnginePPM.Model.SaveUserViewData(this.TicketVal, txtName, locflag, this.ZoomString, LoadUserViewDataCompleteDelegate);


	        this.ModelViewDlg.window("winModelViewDlg").setModal(false);
	        this.ModelViewDlg.window("winModelViewDlg").hide();
	        this.ModelViewDlg.window("winModelViewDlg").detachObject();
	        this.ModelViewDlg = null;
	        return;
	    }

	    if (id == "RenameView_OK") {


	        var txtName = document.getElementById('id_RenameView_Name').value;

	        //if (txtName == "") {
	        //    alert("Please enter a view name");
	        //    return;
	        //}
	        //TO check entered value is blank or with only space.
	        var val = txtName.replace(/^\s+|\s+$/, '');
	        if (val.length == 0) {
	            alert("Please enter a valid view name");
	            return;
	        }

	        if (this.UserViews.length > 0) {

	            var SelView = document.getElementById("idUserViews");
	            var SelViewName = SelView.options[SelView.selectedIndex].text;
	            var indx = SelView.options[SelView.selectedIndex].value - 1;

	            var lloc = (this.UserViews[indx].Id == 0 ? 0 : 1);



	            WorkEnginePPM.Model.RenameUserViewData(this.TicketVal, txtName, this.CurrUserView, lloc, LoadUserViewDataCompleteDelegate);
	            this.CurrUserView = txtName;
	        }

	        this.ModelViewDlg.window("winModelViewDlg").setModal(false);
	        this.ModelViewDlg.window("winModelViewDlg").hide();
	        this.ModelViewDlg.window("winModelViewDlg").detachObject();
	        this.ModelViewDlg = null;
	        return;

	    }



	    if (id == "BarBtn") {

	        var cbBar = (this.viewBar.getButtonState("GanttChk") == false);


	        if (cbBar == true) {
	            this.viewBar.setButtonStateOn("GanttChk");
	            this.DetGridDoRender = true;


	            this.GanttShowing = true;
	            this.ZoomTo = this.LastSelZoomTo;
	            WorkEnginePPM.Model.DoShowGantt(this.TicketVal, 1, DoShowGanttCompleteDelegate);


	        } else {

	            this.viewBar.setButtonStateOff("GanttChk");
	            this.DetGridDoRender = true;
	            this.GanttShowing = false;
	            WorkEnginePPM.Model.DoShowGantt(this.TicketVal, 0, DoShowGanttCompleteDelegate);
	        }

	        try {

	            window.setTimeout(HandleGanttButtonsDelegate, 100);

	            if (this.DetGrid != null)
	                this.DetGrid.Reload(null);
	        }
	        catch (e) {

	        }
	    }

	    else if (id == "UserViewBtn") {
	        this.ManageUserViews();
	    }

	    else if (id.substr(0, 4) == "Zoom") {

	        this.DetGrid.ChangeZoom(id);
	        this.ZoomString = id;

	        var selectZoom = document.getElementById("idGanttZoom");

	        selectZoom.selectedIndex = id.substr(4, 1) - 1;
	        this.viewBar.refreshSelect("idGanttZoom");


	        if (this.firstdate != null)
	            this.DetGrid.ScrollToDate(this.firstdate);

	        this.LastSelZoomTo = id;

	    }

	    else if (id == "EnGrpBtn") {
	        //        var cbgrp = this.ribbonBar.getButtonState("EnableGrpChk");
	        //        if (cbgrp == true) {
	        //            WorkEnginePPM.Model.DoSetGroupingFlag(this.TicketVal, 1);
	        //        }
	        //        else {
	        //            WorkEnginePPM.Model.DoSetGroupingFlag(this.TicketVal, 0);
	        //        }


	    }


	    else if (id == "CopyBtn") {

	        this.GetCopyVersion()

	    }
	    else if (id == "SaveBtn") {

	        this.FromTarget = false
	        WorkEnginePPM.Model.GetSaveVersions(this.TicketVal, GetSaveOrTargetsCompleteDelegate);

	    }

	    else if (id == "CPerBtn") {
	        WorkEnginePPM.Model.GetPeriodsandDisplay(this.TicketVal, GetPeriodsandDisplayOptsDelegate);

	    }




	    else if (id == "LoadBtn") {
	        WorkEnginePPM.Model.DoLoadVersion(this.TicketVal);

	        this.ShowWorkingPopup("divLoading");
	        if (this.DetGrid != null)
	            this.DetGrid.Reload(null);
	        if (this.TotGrid != null)
	            this.TotGrid.Reload(null);


	    }
	    else if (id == "LoadTargetBtn") {

	        this.FromTarget = true;
	        this.DoingDelete = false;
	        this.DoingEdit = false;
	        this.DoingCopy = false;
	        WorkEnginePPM.Model.GetTargetList(this.TicketVal, GetSaveOrTargetsCompleteDelegate);

	    }
	    else if (id == "CreateTargetBtn") {

	        this.FromTarget = true;
	        this.DoingDelete = false;
	        this.DoingEdit = false;
	        this.DoingCopy = false;
	        this.CreateTarget();

	    }
	    else if (id == "CopyTargetBtn") {
	        this.FromTarget = true;
	        this.DoingEdit = true;
	        this.DoingDelete = false;
	        this.DoingCopy = true;
	        WorkEnginePPM.Model.GetTargetList(this.TicketVal, GetDeleteEditTargetsCompleteDelegate);
	    }
	    else if (id == "DeleteTargetBtn") {

	        this.FromTarget = true;
	        this.DoingDelete = true;
	        this.DoingEdit = false;
	        this.DoingCopy = false;
	        WorkEnginePPM.Model.GetTargetList(this.TicketVal, GetDeleteEditTargetsCompleteDelegate);
	    }
	    else if (id == "EditTargetBtn") {

	        this.FromTarget = true;
	        this.DoingEdit = true;
	        this.DoingDelete = false;
	        this.DoingCopy = false;
	        WorkEnginePPM.Model.GetTargetList(this.TicketVal, GetDeleteEditTargetsCompleteDelegate);

	    }
	    else if (id == "TestBtn") {

	        //            WorkEnginePPM.Model.DoBarMoved(this.TicketVal, "4", "03/02/2011", "07/26/2011");

	        //            RefreshBottomGrid();

	        //          var s = this.DetGrid.GetPrintable();
	        this.SearchGrid();
	    }

	    else if (id == "ShowTotBtn") {
	        if (this.bdoingCmp == false)
	            return;


	        var stateOn = this.bottomRibbon.getButtonState("ShowTotChk");


	        if (stateOn == true) {
	            this.bShowingTotals = true;
	            this.bottomRibbon.setButtonStateOff("ShowTotChk");
	            WorkEnginePPM.Model.DoShowRemTotal(this.TicketVal, 0);
	        } else {
	            this.bShowingTotals = false;
	            this.bottomRibbon.setButtonStateOn("ShowTotChk");
	            WorkEnginePPM.Model.DoShowRemTotal(this.TicketVal, 1);
	        }



	        this.FlashTargetMenuStuff();

	        if (this.TotGrid != null)
	            this.TotGrid.Reload(null);

	    }

	    else if (id == "TarLegBtn") {
	        this.ShowLegend();


	    }



	    else if (id == "FindNextBtn") {

	        if (this.ribbonBar.isItemDisabled("FindBtn"))
	            return;

	        this.SearchGrid(false);

	    }
	    else if (id == "FilterBtn") {
	        this.GetFiltering();

	    }
	    else if (id == "TotalBtn") {
	        this.GetTotaling();

	    }
	    else if (id == "SnGBtn") {
	        this.GetSnG();

	    }
	    else if (id == "ColsBtn") {
	        this.GetCols();

	    }
	    else if (id == "CTCmpBtn") {
	        this.GetCostTypeCmp();
	    }
	    else if (id == "SearchBtn") {
	        this.GetSearchData();

	    }


	    else if (id == "PrintTopBtn") {

	        Grid = Grids["g_1"];

	        Grid.ActionPrint();

	    }


	    else if (id == "PrintBotBtn") {

	        Grid = Grids["bottomg_1"];
	        Grid.ActionPrint();

	    }



	    else if (id == "ExportTopBtn") {

	        Grid = Grids["g_1"];

	        Grid.Source.Export.Type = "xls";
	        Grid.ActionExport();

	    }


	    else if (id == "ExportBotBtn") {

	        Grid = Grids["bottomg_1"];

	        Grid.Source.Export.Type = "xls";
	        Grid.ActionExport();

	    }
	}

	Model.prototype.HandleRefresh = function () {

		try {
			if (this.TotGrid != null)
				this.TotGrid.Reload(null);
		}
		catch (e) {

		}

	}

	Model.prototype.BotGridCapture = function () {


		var grid = Grids["bottomg_1"];

		var arows = grid.Rows;

		this.BottomGridState = new Array(grid.RowCount + 1);

		for (var i = 1; i <= grid.RowCount; i++)
		{
			var xr = arows[i];

			this.BottomGridState[i] = xr.Expanded;

		}

	}

  

	Model.prototype.GetSearchData= function () {
		try {
			if (this.SearchDlg == null) {



				this.SearchDlg = new dhtmlXWindows();
				this.SearchDlg.setSkin("dhx_web");
			    this.SearchDlg.enableAutoViewport(false);
				this.SearchDlg.attachViewportTo(this.clientID + "mainDiv");
				this.SearchDlg.setImagePath(this.imagePath);
				this.SearchDlg.createWindow("winSearchsDlg", 20, 30, 510, 220);
				this.SearchDlg.window("winSearchsDlg").setIcon("logo.ico", "logo.ico");
				this.SearchDlg.window("winSearchsDlg").allowMove();
				this.SearchDlg.window("winSearchsDlg").denyResize();
				this.SearchDlg.window("winSearchsDlg").setModal(true);
				this.SearchDlg.window("winSearchsDlg").center();
				this.SearchDlg.window("winSearchsDlg").setText("Select Search Options");
				this.SearchDlg.window("winSearchsDlg").attachObject("idSearchDlgObj");
				this.SearchDlg.window("winSearchsDlg").button("close").disable();
				this.SearchDlg.window("winSearchsDlg").button("park").hide();
				this.SearchDlg.window("winSearchsDlg").button("minmax1").hide();

				WorkEnginePPM.Model.GetColumnOrderData(this.TicketVal, GetSearchCompleteDelegate);
			   
			}
			else
				this.SearchDlg.window("winSearchsDlg").show();
		}

		catch (e) {
			alert("error 1");
		}
	}
	

	Model.prototype.GetSearchComplete = function(result)
	{
		this.ColData = result;

		var searchHow = document.getElementById('idSearchHow');
			   
		searchHow.options.length = 0;
		searchHow.options[0] = new Option("equals", 1, false,false);
		searchHow.options[1] = new Option("does not equal", 2, false,false);
		searchHow.options[2] = new Option("contains", 3, true,true);
		searchHow.options[3] = new Option("begins with", 4, false,false);

		this.DoLoadSearchData()

   }

   
	Model.prototype.SelectSearchWhere_Change = function()
	{

	       var ix = document.getElementById("rbSearchDet").checked;
		   var searchWhere = document.getElementById('idSearchWhere');

		   var usev = searchWhere.options[searchWhere.selectedIndex].text;

		   if (ix == true)
				this.DetSeachCol = usev;
			else
				this.TotSeachCol = usev;


	}
	Model.prototype.DoLoadSearchData = function () {

		try {

		    var ix = document.getElementById("rbSearchDet").checked;
			var searchWhere = document.getElementById('idSearchWhere');
			var cnt = 0;
			var foundcnt = 0;
			var sdf;
			var i;


			searchWhere.options.length = 0;


			if (ix == true) {


				if (this.DetSeachCol != "") {

					for (i = 0; i < this.ColData.DetFields.length; i++) {
						sdf = this.ColData.DetFields[i];

						if (sdf.selected == true) {
							if (this.DetSeachCol == sdf.name) {
								foundcnt = cnt;
								break;
							}
							++cnt;
						}
					}
				}


				cnt = 0;
				for (i = 0; i < this.ColData.DetFields.length; i++) {
					sdf = this.ColData.DetFields[i];

					if (sdf.selected == true) {
						searchWhere.options[cnt] = new Option(sdf.name, sdf.fid, cnt == foundcnt, cnt == foundcnt);
						++cnt;
					}
				}

			}
			else {

				if (this.TotSeachCol != "") {

					for (i = 0; i < this.ColData.TotFields.length; i++) {
						sdf = this.ColData.TotFields[i];

						if (sdf.selected == true) {
							if (this.TotSeachCol == sdf.name) {
								foundcnt = cnt;
								break;
							}
							++cnt;
						}
					}
				}

				cnt = 0;
				for (i = 0; i < this.ColData.TotFields.length; i++) {
					sdf = this.ColData.TotFields[i];

					if (sdf.selected == true) {
						searchWhere.options[cnt] = new Option(sdf.name, sdf.fid, cnt == 0, cnt == 0);
						++cnt;
					}
				}

			}

		}

		catch (e) {
		}

	}

	Model.prototype.SelectSearch_OKOnClick = function (iApply) {
	    if (iApply == 1) {
	        var searchtext = document.getElementById('idtxtsearch');

	        if (searchtext.value == '' || searchtext.value == null) {
	            alert("search for field can't be left blank !");
	        }
	        else {
		    this.SearchDet = document.getElementById("rbSearchDet").checked;

		   var searchWhere = document.getElementById('idSearchWhere');
		   var s = searchWhere.options[searchWhere.selectedIndex].text; 
	            this.SeachCol = "";

	            for (var xi = 0; xi < s.length; xi++) {
			if (s.charAt(xi) != ' ')
				this.SeachCol = this.SeachCol + s.charAt(xi);
		   }
		   
		   var searchHow = document.getElementById('idSearchHow');
		   this.SeachHow = searchHow.options[searchHow.selectedIndex].value; 

	            //var searchtext = document.getElementById('idtxtsearch');		   
		   this.SearchText = searchtext.value;
  
			this.SearchGrid(true);

	            this.SearchDlg.window("winSearchsDlg").detachObject()
	            this.SearchDlg.window("winSearchsDlg").close();
	            this.SearchDlg = null;
		 }
 
	    }
	    else {
	        this.SearchDlg.window("winSearchsDlg").detachObject()
	        this.SearchDlg.window("winSearchsDlg").close();
	        this.SearchDlg = null;
	    }

		  
	}

	Model.prototype.SearchGrid = function (bIsFirst) {

		if (bIsFirst)
			this.SearchStartRow = 0;


		var grid = null;

		if (this.SearchDet)
			grid = Grids["g_1"];
		else
			grid = Grids["bottomg_1"];

		var arows = grid.Rows;

		if (this.FindGrid != grid && this.FindCol != null && this.FindRow != null)
		{
			var lfr = this.FindRow;
			this.FindRow = null;

			grid.SelectRow(arows[lfr],1);       
			grid.Focus(arows[i], this.FindCol,null, true);   

		}
 
		this.FindGrid = grid;
		this.FindCol = null;
		this.FindRow = null;
 

		var sLookFor =  this.SearchText.toUpperCase();


		for (var i = this.SearchStartRow + 1; i <= grid.RowCount; i++)
		{
			var s = grid.GetString(arows[i], this.SeachCol).toUpperCase(); 

			var bTest = false;



			if (this.SeachHow == 1)
				bTest = (s == sLookFor);
			else if (this.SeachHow == 2)
				bTest = (s != sLookFor);
			else if (this.SeachHow == 3)
				bTest = (s.indexOf(sLookFor) != -1);
			else if (this.SeachHow == 4 && s.length >= sLookFor.length)
			    bTest = (sLookFor == s.slice(0, sLookFor.length));



			if (bTest == true)
			{
				 this.FindRow = arows[i].id;
				 this.FindCol = this.SeachCol;

				 this.SearchStartRow = i;

				 grid.SelectRow(arows[i],1);       
				 setTimeout(function () { grid.Focus(arows[i], this.SeachCol, null, true); }, 10);

				 this.ribbonBar.enableItem("FindBtn");
				 return;
			}
 
		}
		alert("Search did not find any matching rows");



	} 
	
	 Model.prototype.HandleBothRefresh = function () {

	     try {

	         this.ShowWorkingPopup("divLoading");
			if (this.TotGrid != null)
				this.TotGrid.Reload(null);

			if (this.DetGrid != null)
				this.DetGrid.Reload(null);
		}
		catch (e) {

		}

	}

	Model.prototype.HandlePingSession = function () {

		try {
			WorkEnginePPM.Model.DoPingSession(this.TicketVal);
			PingSessionData();
		}
		catch (e) {

		}

	}

	Model.prototype.GridsOnGanttChanged = function (Grid, Row, Col, sItem, New1, New2, Old1, Old2, Action) {

		var sStart, sFinish, bRefresh;


		sStart = Grid.GetString(Row, "Start");
		sFinish = Grid.GetString(Row, "Finish");

		//        this.BarGrid = Grid;

		try {


			this.MoveBarRow = Row.id;

			this.ShowBusy();


			WorkEnginePPM.Model.DoBarMoved(this.TicketVal, Row.id, sStart, sFinish, BarMovedCompleteDelegate);
  
		}
		catch (e) {
		}



	}


	Model.prototype.BarMovedComplete = function (result) {

		var bRedrawTop = false;

		if (result != null && result != undefined) {

			if (result.redrawCompleteGrid == 1)
				bRedrawTop = true;
			else {

				var Grid = Grids["g_1"];

				var refrshcnt = result.barsAffected - 1;

				var trows = Grid.Rows;
				for (var i = 0; i <= refrshcnt; ++i) {
					var urow = trows[result.RowID[i]];


					if (urow != undefined) {
						Grid.SetString(urow, "Start", result.Starts[i], 1);
						Grid.SetString(urow, "Finish", result.Finishs[i], 1);
					}

				}
			}
		}


		if (bRedrawTop == true) {
			this.ZoomTo = this.LastSelZoomTo;
			RefreshBothGrids();
		}
		else
			RefreshBottomGrid();

		this.HideBusy();
	}

	
	Model.prototype.HandleTargetEdit = function (Row, Col, value) {

		this.EditGrid = Grids["et_1"];

		if (Col == "Select") 
		return;
		
		if (Col.charAt(0) == "P")
		 {           
			var per, sCol, trow;

			sCol = Col.substr(1,Col.length - 2);
			per = parseInt(sCol);

		   trow = this.CSTargetCache.targetRows[parseInt(Row.id) - 1];
  
			if (Col.charAt(Col.length - 1) == "C")
			{
				trow.zCost[per] = parseFloat(value);
				return;
			}
			
 
			var cat = null;
			for (var j = 0; j < this.CSDataCache.Categories.length; j++)
			{

				if (this.CSDataCache.Categories[j].UID == trow.BC_UID)
				{
					cat = this.CSDataCache.Categories[j];
					break;
				}
			}

			if (this.etShowingFTEs == true)
			{
				trow.zFTE[per] = parseFloat(value);
				if (cat != null)
					 trow.zValue[per] = (parseFloat(value) * cat.FTEConv[per]) / 100;
			}
			else
				trow.zValue[per] = parseFloat(value);

			var rt = this.GrabRateTable(trow);

			if (rt == null)
				 trow.zCost[per] = 0;
			else
				 trow.zCost[per] = trow.zValue[per] * rt[per];

 
			if (cat != null && this.etShowingFTEs == false)
			{
				 
				  if (cat.FTEConv[per] == 0)
					trow.zFTE[per] = 0;
				 else
					trow.zFTE[per] = (trow.zValue[per] * 100) / cat.FTEConv[per];

			}
			   

			sCol = Col.substr(0,Col.length - 1) + "C";


			this.EditGrid.SetString(Row, sCol, trow.zCost[per], 1);

			if (this.TargetGroupingField != 0 )
			{
				this.RollUpTargetGrouping();
				this.FlashTargetData();
			}

			return;
		}

		RefreshTargetGrid();

	}

	Model.prototype.FlipFTEQtyTargetCostType = function (bFTE) 
	{

	   this.EditGrid = Grids["et_1"];
		var trow, grow, cat;
		var arows = this.EditGrid.Rows;
		var hRow = arows["Header"];
	   

		for (var i = 0; i < this.CSTargetCache.targetRows.length; i++)
		{
			trow = this.CSTargetCache.targetRows[i];
			grow = arows[i + 1];

			cat = null;
			for (var j = 0; j < this.CSDataCache.Categories.length; j++)
			{

				if (this.CSDataCache.Categories[j].UID == trow.BC_UID)
				{
					cat = this.CSDataCache.Categories[j];
					break;
				}
			}

			var rt = this.GrabRateTable(trow);
 
			if (rt != null)
			{
				for (var per = 1; per < rt.length; per++)
				{
					var x = "P" + per.toString() + "V";

					if (i == 0)
					{
						if (bFTE == true) 
							this.EditGrid.SetString(hRow, x, " FTE", 1);
						else
							this.EditGrid.SetString(hRow, x, " QTY", 1);
					}

					if (bFTE == true) 
					{
						if (cat.FTEConv[per] != 0)
							trow.zFTE[per] = (trow.zValue[per] * 100) / cat.FTEConv[per];
						else
							trow.zFTE[per] = 0;
						this.EditGrid.SetString(grow, x, trow.zFTE[per], 1);
					}
					else
						this.EditGrid.SetString(grow, x, trow.zValue[per], 1);
					
				}
			}
		}
	}

	Model.prototype.ChangeTargetCostType = function (Row, cat) 
	{

		this.EditGrid = Grids["et_1"];
		var trow;
		trow = this.CSTargetCache.targetRows[Row.id - 1];

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

		if (rt != null)
		{
			for (var per = 1; per < rt.length; per++)
			{
				trow.zCost[per] = trow.zValue[per] * rt[per];

				if (cat.FTEConv[per] == 0)
					trow.zFTE[per] = 0;
				else
					trow.zFTE[per] = (trow.zValue[per] * 100) / cat.FTEConv[per];


			}
 
		}

	}

	Model.prototype.TargetDeleteRows = function () {
		this.EditGrid = Grids["et_1"];
		var trow, grow, cat;
		var arows = this.EditGrid.Rows;

		var cnt = 0;
		var i;


		for (i = 1; i <= this.EditGrid.RowCount; i++) {
			grow = arows[i];

			if (this.EditGrid.GetString(grow, "Select") != "1")
				cnt++;

		}

		var narr = new Array(cnt);

		cnt = 0;


		for (i = 1; i <= this.EditGrid.RowCount; i++) {
			grow = arows[i];

			if (this.EditGrid.GetString(grow, "Select") != "1") {
				narr[cnt++] = this.CSTargetCache.targetRows[i - 1];
			}

		}

		this.CSTargetCache.targetRows = narr;

		for (i = this.EditGrid.RowCount; i > cnt; i--) {
			grow = arows[i];
			this.EditGrid.RemoveRow(grow);
		}

		this.FlashTargetData();


	}

	Model.prototype.TargetAddRow = function () {
		this.EditGrid = Grids["et_1"];
		var trow, grow;
		var arows = this.EditGrid.Rows;

		var nump = this.CSDataCache.numberPeriods;
		var i;

		var cnt = 0;


		for (i = 1; i <= this.EditGrid.RowCount; i++) {
			grow = arows[i];

			if (this.EditGrid.GetString(grow, "Select") != "1")
				cnt++;

		}

		var narr = new Array(this.EditGrid.RowCount + 1);

		cnt = 0;


		for (i = 1; i <= this.EditGrid.RowCount; i++) {
			narr[cnt++] = this.CSTargetCache.targetRows[i - 1];
		}

		narr[cnt++] = this.CreateNewTargetRow();




		this.CSTargetCache.targetRows = narr;


		grow = this.EditGrid.AddRow(null, null, true, cnt.toString(), "");

		grow.NoColorState = 1;


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
		//        setTimeout(function () { this.EditGrid.Focus(grow, "Select"); }, 10);
	}

	Model.prototype.PopulateTargetTexts = function (row, oDet) {
   
		this.EditGrid = Grids["et_1"];
		this.EditGrid.SetString(row,"GroupVal", oDet.Grouping, 1);
		this.EditGrid.SetString(row,"CostType", oDet.CT_Name, 1);
		this.EditGrid.SetString(row,"CostCategory", oDet.FullCatName, 1);
		this.EditGrid.SetString(row,"MajorCategory", oDet.MC_Name, 1);
		this.EditGrid.SetString(row,"Role", oDet.Role_Name, 1);
		this.EditGrid.SetString(row,"NamedRate", oDet.m_rt_name, 1);

	  

		for (var i = 0; i < this.CSDataCache.CustomFields.length; i++)
		{
			var stxt, oc;

			oc = this.CSDataCache.CustomFields[i];

			if (oc.FieldID < 11810)
				stxt = oDet.Text_OCVal[oc.FieldID - 11800];
			else
				stxt = oDet.TXVal[oc.FieldID - 11810];

			this.EditGrid.SetString(row,oc.Name, stxt, 1);

		 }

	  
	}


	Model.prototype.GrabRateTable = function (trow) {
			if (trow.m_rt != 0)
			{
				for (var i = 0; i < this.CSDataCache.NamedRates.length; i++)
				{
				   if (this.CSDataCache.NamedRates[i].UID == trow.BC_UID)
						return this.CSDataCache.NamedRates[i].Rates;

				}
			 
			}
			else
			{
				for (i = 0; i < this.CSDataCache.Categories.length; i++)
				{
					if (this.CSDataCache.Categories[i].UID == trow.BC_UID)
						return this.CSDataCache.Categories[i].Rates;
				}

			}


			return null;
   }


   Model.prototype.GridsOnValueChanged = function (grid, row, col, val) {

	   var trow;
	   var i;

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

			   trow = this.CSTargetCache.targetRows[row.id - 1];
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
				   trow = this.CSTargetCache.targetRows[row.id - 1];

				   if (oc.jsonMenu == "") {
					   trow.TXVal[oc.FieldID - 11810] = val;
					   return val;

				   }

				   for (var xi = 0; xi < oc.LookUp.length; xi++) {
					   lk = oc.LookUp[xi];

					   if (lk.UID == val) {




						   if (oc.FieldID < 11810) {
							   trow.Text_OCVal[oc.FieldID - 11800] = lk.Name;
							   trow.OCVal[oc.FieldID - 11800] = val;
						   }

						   else {
							   if (oc.UseFullName == 1) {
								   trow.TXVal[oc.FieldID - 11810] = lk.FullName;
								   return lk.FullName;
							   }
							   else
								   trow.TXVal[oc.FieldID - 11810] = lk.Name;
						   }

						   return lk.Name;
					   }
				   }
			   }

		   }


	   }

	   return val;
   }
   Model.prototype.GridsOnAfterValueChanged = function (Grid, Row, Col, value) {

       if (Grid.id == "et_1") {
           this.HandleTargetEdit(Row, Col, value)
           return value;
       }


       if (Grid.id == "g_1") {

           WorkEnginePPM.Model.DoTopGridCheck(this.TicketVal, Row.id);

           HandleClick(Grid, Row, Col, value);

           this.BotGridCapture();
           RefreshBottomGrid();
           return;
       }

       if (Grid.id == "f_1") {

           HandleClick(Grid, Row, Col, value);
           return;

       }

       if (Grid.id == "col_1") {

           var ix = true; //  document.getElementById("rbCDet").checked;
           var ri = Row.id;
           var sdf = null;

           if (ix == true)
               sdf = this.ColData.DetFields[ri - 1];
           else
               sdf = this.ColData.TotFields[ri - 1];


           sdf.selected = (sdf.selected == 1 ? 0 : 1);
           return;

       }

   }


	Model.prototype.ShowBusy = function () {


		try {



			document.body.style.cursor = 'wait';
			return;



		}

		catch (e) {
			alert("error 1");
		}
	}

	Model.prototype.HideBusy = function () 
	{


//        this.showBusy.window("winBusyDlg").detachObject()
//        this.showBusy.window("winBusyDlg").close();
//        this.showBusy = null;

		document.body.style.cursor = 'default';


	}



	Model.prototype.DoShowGanttComplete = function (result) {
//	    var cbgrp = this.ribbonBar.setButtonStateOn("EnableGrpChk");
//	    if (result == 1) {

//	        this.ribbonBar.showItem("EnableGrpChk");
//	        this.ribbonBar.setButtonStateOn("EnableGrpChk");
//	        this.ribbonBar.enableItem("EnableGrpChk");



//	    }
//	    else if (result == 2) {

//	        this.ribbonBar.showItem("EnableGrpChk");
//	        this.ribbonBar.setButtonStateOff("EnableGrpChk");
//	        this.ribbonBar.enableItem("EnableGrpChk");
//	    }
//	    else {
//	        this.ribbonBar.hideItem("EnableGrpChk");
//	    }
	}
	

	Model.prototype.CreateTarget = function () {


		try {



			if (this.dlgCreateTarget == null) {
				this.dlgCreateTarget = new dhtmlXWindows();
				this.dlgCreateTarget.setSkin("dhx_web");
			    this.dlgCreateTarget.enableAutoViewport(false);
				this.dlgCreateTarget.attachViewportTo(this.clientID + "mainDiv");
				this.dlgCreateTarget.setImagePath(this.imagePath);

				this.dlgCreateTarget.createWindow("winCreateTargetDlg", 20, 30, 550, 155);

				this.dlgCreateTarget.window("winCreateTargetDlg").setIcon("logo.ico", "logo.ico");
				this.dlgCreateTarget.window("winCreateTargetDlg").allowMove();
				this.dlgCreateTarget.window("winCreateTargetDlg").denyResize();
				this.dlgCreateTarget.window("winCreateTargetDlg").setModal(true);

				this.dlgCreateTarget.window("winCreateTargetDlg").showHeader();
				this.dlgCreateTarget.window("winCreateTargetDlg").progressOn();
				this.dlgCreateTarget.window("winCreateTargetDlg").center();

				this.dlgCreateTarget.window("winCreateTargetDlg").setText("Create Target");
				this.dlgCreateTarget.window("winCreateTargetDlg").attachObject("idCreateTragetDlgObj");
				this.dlgCreateTarget.window("winCreateTargetDlg").button("close").disable();
				this.dlgCreateTarget.window("winCreateTargetDlg").button("park").hide();
				this.dlgCreateTarget.window("winCreateTargetDlg").button("minmax1").hide();

				document.getElementById('idTxtNewTargetName').value = "";
				document.getElementById('idTxtNewTargetDesc').value = "";
			  }
			else
				this.dlgCreateTarget.window("winCreateTargetDlg").show();
		}

		catch (e) {
			alert("error 1");
		}
	}

	

	Model.prototype.CreateTarget_OKOnClick = function (iApply) 
	{

		var nametext = document.getElementById('idTxtNewTargetName').value;
		var desctext = document.getElementById('idTxtNewTargetDesc').value;
		var localtarget = (document.getElementById('idChkLocalTarget').checked ? 1 : 0);

		nametext = trim(nametext);

		if (iApply == 1 && nametext.length == 0)
		{
			   alert("You must enter a Target Name!");
			   return;

		}

		this.dlgCreateTarget.window("winCreateTargetDlg").detachObject()
		this.dlgCreateTarget.window("winCreateTargetDlg").close();
		this.dlgCreateTarget = null;


		if (iApply == 1)
		{
			WorkEnginePPM.Model.CreateTarget(this.TicketVal, nametext, desctext, localtarget, 0, CreateTargetCompleteDelegate);
		}
		   

		   
	}

	
	Model.prototype.CreateTargetComplete = function (result) {

	   if (result.Id <= 0)
	   {
			alert("A target of that name already exits!");
			return;
		}

		this.GoDoEdit(result.Id, result.Name);
		

	}

	Model.prototype.GoDoEdit = function (id, name) {

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


	            this.dlgEditTarget.window("winEditTargetDlg").setText("Edit Target : " + name);
	            this.dlgEditTarget.window("winEditTargetDlg").attachObject("idEditTargetDlg");
	            this.dlgEditTarget.window("winEditTargetDlg").button("close").disable();
	            this.dlgEditTarget.window("winEditTargetDlg").button("park").hide();
	            this.dlgEditTarget.window("winEditTargetDlg").button("minmax1").hide();
	            //               this.dlgEditTarget.window("winEditTargetDlg").attachEvent("onFocus", layoutOnResizeFinishDelegate);

	            this.EditTargetid = id;

	 

	  //          if (this.CSDataCache == null) {

	                WorkEnginePPM.Model.GetClientSideCalcData(this.TicketVal, GetClientSideCalcDataCompleteDelegate);
	  //          }
	  //          else {

	  //              WorkEnginePPM.Model.PrepareTargetData(this.TicketVal, this.EditTargetid, GetTargetDataCompleteDelegate);
	   //         }

	        }
	        else
	            this.dlgEditTarget.window("winEditTargetDlg").show();
	    }

	    catch (e) {
	        alert("error 1");
	    }

	}

	Model.prototype.CloseEditTarget = function () 
	{

	    this.dlgEditTarget.window("winEditTargetDlg").detachObject();
		this.dlgEditTarget.window("winEditTargetDlg").close();
		this.dlgEditTarget = null;

 

		this.EditGrid.Dispose();
		this.EditGrid = null;

		   
	}

	Model.prototype.SaveTarget = function () 
	{

		WorkEnginePPM.Model.SaveTargetData(this.TicketVal, this.EditTargetid, this.CSTargetCache, SaveTargetDataCompleteDelegate);
		   
	}

	Model.prototype.SaveTargetDataComplete = function () {

		alert("Target has been saved");

	}

	


	Model.prototype.GetClientSideCalcDataComplete = function (result) {
		this.CSDataCache = result;
		
		WorkEnginePPM.Model.ExecuteJSON(this.TicketVal,"GetFTEMode",  "", FireupEditTargetDelegate);
	}

	Model.prototype.FireupEditTarget = function (jsonString) {
		
      try {
            this.RetFTEMode = "0";

            if (jsonString != "") {
                var jsonObject = JSON_ConvertString(jsonString);
                if (JSON_ValidateServerResult(jsonObject)) {

                    this.RetFTEMode = jsonObject.Result.Mode.Value;

                }
            }
        }

        catch (e) {

        }

		WorkEnginePPM.Model.PrepareTargetData(this.TicketVal, this.EditTargetid, GetTargetDataCompleteDelegate);
	}

	Model.prototype.GetTargetDataComplete = function (result) {

	    this.TargetGroupingField = 0;
	    this.CSTargetCache = result;

	    this.etShowingFTEs = false;



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
                                    { type: "bigbutton", name: "Close", img: "close32.gif", tooltip: "Close", onclick: "etdialogEvent('etCloseBtn');" }
                                ]
                            },
                            {
                                items: [
                                    { type: "bigbutton", name: "Save", img: "save32x32.png", tooltip: "Save", onclick: "etdialogEvent('etSaveBtn');" }
                                ]
                            }
                        ]
                     },
                     { name: "Mode",
                         columns: [
                            {
                                items: [
                                    { type: "text", name: "Display Mode" },
                                    { type: "select", id: "idEdit_SelMode", onchange: "etdialogEvent('Edit_SelMode_Changed')", options: "<option " + (this.RetFTEMode == "0" ? "SELECTED" : "") + "  value='1'>Hours</option><option " + (this.RetFTEMode != "0" ? "SELECTED" : "") + " value='2'>FTEs</option>", width: "90px" }
                                ]
                            }
                        ]
                     },
                    { name: "Tools",
                        columns: [
                            {
                                items: [
                                     { type: "smallbutton", id: "LoadUpBtn", name: "Populate Model", img: "spread.gif", tooltip: "Populate Model", onclick: "etdialogEvent('etPopBtn');" },
                                     { type: "smallbutton", id: "TarAppendRow", name: "Append Row", img: "ps16x16.png", style: "top: -128px;left: -64px;position:relative;", tooltip: "Append Row", onclick: "etdialogEvent('etInsBtn');" },
                                     { type: "smallbutton", id: "TarDelRowsBtn", name: "Delete Selected Rows", img: "delete.gif", tooltip: "Delete Selected Rows", onclick: "etdialogEvent('etDelBtn');" }
                                ]
                            },
                            {
                                items: [
                                       { type: "smallbutton", id: "Grp", name: "Group Rows", img: "grouping.gif", tooltip: "Group Rows", onclick: "etdialogEvent('etGrpBtn');" }
                              ]
                            }
                        ]
                    }

                 ]
	    };



        this.EditTab = new Ribbon(TarRibonData);
        this.EditTab.Render();


 //	    this.ettoolbar = new dhtmlXToolbarObject(this.toolbarEditTargetData);
//	    this.ettoolbar.attachEvent("onClick", ettoolbarOnClickDelegate);

//	    this.ettoolbar.hideItem("etQTYBtn");


//	    document.getElementById('idEditGridDiv').style.height = (this.Height - 120) + "px";
//	

	    var sHTML1 = "<treegrid debug='0' sync='0' layout_url='" + this.Webservice + "' layout_method='Soap' layout_function='GetTargetGridLayout' layout_namespace='WorkEnginePPM' layout_param_Ticket='" + this.TicketVal + "' data_url='" + this.Webservice + "' data_method='Soap' data_function='GetTargetGridData' data_namespace='WorkEnginePPM' data_param_Ticket='" + this.TicketVal + "' ></treegrid>";
	    this.EditGrid = TreeGrid(sHTML1, "idEditGridDiv", "et_1");


	}

	Model.prototype.ettoolbarOnClick = function (id, data) {


	    if (id == "Edit_SelMode_Changed") {
	        var select = document.getElementById('idEdit_SelMode');

	        if (select.options[select.selectedIndex].value == 1)
	            id = "etQTYBtn";
	        else
	            id = "etFTEBtn";
	    }
	    
	    if (id == "etCloseBtn") {
	        this.CloseEditTarget();
	    }
	    else if (id == "etSaveBtn") {
	        this.SaveTarget();
	    }
	    else if (id == "etPopBtn") {
	        this.PopulateTarget();
	    }
	    else if (id == "etTestBtn") {
	        this.ChangeTargetCostType(13, 3);
	    }
	    else if (id == "etFTEBtn") {
	        this.FlipFTEQtyTargetCostType(true);
	        this.etShowingFTEs = true;
	    }
	    else if (id == "etQTYBtn") {
	        this.FlipFTEQtyTargetCostType(false);
	        this.etShowingFTEs = false;
	    }
	    else if (id == "etInsBtn") {

	        this.TargetAddRow();
	    }
	    else if (id == "etDelBtn") {
	        this.TargetDeleteRows();
	    }

	    else if (id == "etGrpBtn") {
	        this.TargetGroupRows();
	    }
	}

	
   Model.prototype.ShowLegend = function () {
		if (this.dlgShowLegend == null)
		{
	  
            this.dlgShowLegend = new dhtmlXWindows();
            this.dlgShowLegend.setSkin("dhx_web");
			this.dlgShowLegend.enableAutoViewport(false);
			this.dlgShowLegend.attachViewportTo(this.clientID + "mainDiv");
			this.dlgShowLegend.setImagePath(this.imagePath);
			this.dlgShowLegend.createWindow("winShowLegDlg", 20, 30, 405, 325);
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


			var sHTML1 = "<treegrid debug='0' sync='0' layout_url='" + this.Webservice + "' layout_method='Soap' layout_function='GetLegendGridLayout' layout_namespace='WorkEnginePPM' layout_param_Ticket='" + this.TicketVal + "' data_url='" + this.Webservice + "' data_method='Soap' data_function='GetLegendGridData' data_namespace='WorkEnginePPM' data_param_Ticket='" + this.TicketVal + "' ></treegrid>";
			this.LegendGrid = TreeGrid(sHTML1, "idTarLegDiv", "leg_1");

			   
		}
		else
		   this.dlgShowLegend.window("winShowLegDlg").show();

   }

   

	Model.prototype.TargetLegend_OKOnClick = function () 
	{

		this.dlgShowLegend.window("winShowLegDlg").detachObject()
		this.dlgShowLegend.window("winShowLegDlg").close();
		this.dlgShowLegend = null;


		this.LegendGrid.Dispose();
		this.LegendGrid = null;
			
	}


   Model.prototype.TargetGroupRows = function () {
		if (this.dlgTargetGroup == null)
		{
	//		this.dlgEditTarget.window("winEditTargetDlg").hide();

			this.dlgTargetGroup = new dhtmlXWindows();
			this.dlgTargetGroup.setSkin("dhx_web");
		    this.dlgTargetGroup.enableAutoViewport(false);
			this.dlgTargetGroup.attachViewportTo(this.clientID + "mainDiv");
			this.dlgTargetGroup.setImagePath(this.imagePath);
			this.dlgTargetGroup.createWindow("winTarGrpDlg", 20, 30, 210, 135);
			this.dlgTargetGroup.window("winTarGrpDlg").setIcon("logo.ico", "logo.ico");
			this.dlgTargetGroup.window("winTarGrpDlg").allowMove();
			this.dlgTargetGroup.window("winTarGrpDlg").denyResize();
			this.dlgTargetGroup.window("winTarGrpDlg").setModal(true);
			this.dlgTargetGroup.window("winTarGrpDlg").center();

 
			this.dlgTargetGroup.window("winTarGrpDlg").setText("Select Grouping Field");
 
			this.dlgTargetGroup.window("winTarGrpDlg").attachObject("idGroupTargetBy");
			this.dlgTargetGroup.window("winTarGrpDlg").button("close").disable();
			this.dlgTargetGroup.window("winTarGrpDlg").button("park").hide();
			this.dlgTargetGroup.window("winTarGrpDlg").button("minmax1").hide();

			var SGT = document.getElementById('idSelectGroup');
			SGT.options.length = 0;

			SGT.options[0] = new Option("None", 0, true, true);
			SGT.options[1] = new Option("Cost Type", 1, false, false);
			SGT.options[2] = new Option("Cost Category", 2, false, false);
			SGT.options[3] = new Option("Role", 2, false, false);

			for (var i = 0; i < this.CSDataCache.CustomFields.length; i++)
			{
				var oc;

				oc = this.CSDataCache.CustomFields[i];

				var sName = oc.Name.substr(1,oc.Name.length - 1);

				SGT.options[i + 4] = new Option(sName, oc.FieldID, false, false);
			}
			   
		}
		else
		   this.dlgTargetGroup.window("winTarGrpDlg").show();

   }

   

	Model.prototype.SelectGroupTarget_OKOnClick = function (iApply) 
	{

	
		if (iApply == 1)
		{
			var SGT = document.getElementById('idSelectGroup');
			this.TargetGroupingField =  SGT.options[SGT.selectedIndex].value;

			this.DoTargetGrouping();
			this.RollUpTargetGrouping();
			this.FlashTargetData();
		}



		this.dlgTargetGroup.window("winTarGrpDlg").detachObject()
		this.dlgTargetGroup.window("winTarGrpDlg").close();
		this.dlgTargetGroup = null;

	//	this.dlgEditTarget.window("winEditTargetDlg").show();
			
	}


	Model.prototype.DoTargetGrouping = function () {

		this.EditGrid = Grids["et_1"];
		var narr = new Array();
		var narrindex = new Array();
		var startfrom = 1;

		var cnt = 0;
		var trow;
		var j;
		var i;

		for (i = 0; i < this.CSTargetCache.targetRows.length; i++) {
			if (this.CSTargetCache.targetRows[i].bGroupRow == false) {
				narr[cnt] = this.CSTargetCache.targetRows[i];
				narrindex[cnt++] = 0;
			}
		}

		if (this.TargetGroupingField == 0) {
			this.CSTargetCache.targetRows = narr;
		}
		else {

			var sarr = new Array();
			var stxt;

			sarr[0] = "";

			for (i = 0; i < narr.length; i++) {

				trow = narr[i];

				if (this.TargetGroupingField == 1)
					stxt = trow.CT_Name;
				else if (this.TargetGroupingField == 2)
					stxt = trow.FullCCName;
				else if (this.TargetGroupingField == 3)
					stxt = trow.Role_Name;
				else {

					if (this.TargetGroupingField < 11810)
						stxt = trow.Text_OCVal[this.TargetGroupingField - 11800];
					else
						stxt = trow.TXVal[this.TargetGroupingField - 11810];
				}

				var bfound = false;

				for (j = 0; j < sarr.length; j++) {
					if (stxt == sarr[j]) {
						narrindex[i] = j;
						bfound = true;

						if (j == 0)
							startfrom = 0;    // when we collate groups - we will include the blank text as well.
						break;
					}
				}

				if (bfound == false) {
					narrindex[i] = sarr.length;
					sarr[sarr.length] = stxt;
				}

			}

			cnt = 0;

			var garr = new Array();
			var newobj;

			for (j = startfrom; j < sarr.length; j++) {
				newobj = this.CreateNewTargetRow();
				garr[cnt++] = newobj;

				newobj.bGroupRow = true;
				newobj.Grouping = sarr[j];

				for (i = 0; i < narr.length; i++) {
					if (narrindex[i] == j)
						garr[cnt++] = narr[i];
				}

			}


			this.CSTargetCache.targetRows = garr;

		}

		var arows = this.EditGrid.Rows;
		var grow;

		if (this.EditGrid.RowCount < this.CSTargetCache.targetRows.length) {

			for (i = this.EditGrid.RowCount + 1; i <= this.CSTargetCache.targetRows.length; i++) {
				grow = this.EditGrid.AddRow(null, null, true, i.toString(), "");
				grow.NoColorState = 1;
			}

		}
		else if (this.EditGrid.RowCount > this.CSTargetCache.targetRows.length) {

			for (i = this.EditGrid.RowCount; i > this.CSTargetCache.targetRows.length; i--) {
				grow = arows[i];
				this.EditGrid.RemoveRow(grow);
			}
		}


	}

	Model.prototype.CreateNewTargetRow = function () {


		var newobj = new Object();
		var i;

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


		newobj.OCVal = new Array(6);
		newobj.Text_OCVal = new Array(6);
		newobj.TXVal = new Array(6);

		for (i = 0; i < 6; i++) {
			newobj.OCVal[i] = 0;
			newobj.Text_OCVal[i] = "";
			newobj.TXVal[i] = "";
		}

		var nump = this.CSDataCache.numberPeriods;

		newobj.zCost = new Array(nump);
		newobj.zValue = new Array(nump);
		newobj.zFTE = new Array(nump);

		for (i = 0; i <= nump; i++) {
			newobj.zCost[i] = 0.0;
			newobj.zValue[i] = 0.0;
			newobj.zFTE[i] = 0.0;
		}

		return newobj;
	}


  Model.prototype.RollUpTargetGrouping = function () {

	  if (this.TargetGroupingField == 0)
		  return;

	  var nump = this.CSDataCache.numberPeriods
	  var prow = null;
	  var pi;

	  for (var j = this.CSTargetCache.targetRows.length - 1; j >= 1; j--) {
		  var trow = this.CSTargetCache.targetRows[j];

		  if (trow.bGroupRow == true)
			  prow = null;
		  else {
			  if (prow == null) {
				  for (var i = j - 1; i >= 0; i--) {
					  prow = this.CSTargetCache.targetRows[i];

					  if (prow.bGroupRow == true) {
						  for (pi = 1; pi <= nump; pi++) {
							  prow.zCost[pi] = 0;
							  prow.zValue[pi] = 0;
							  prow.zFTE[pi] = 0;
						  }
						  break;
					  }
				  }
			  }
			  for (pi = 1; pi <= nump; pi++) {
				  if (trow.zCost[pi] != 0 && trow.zValue[pi] != 0)
					  var x = 4;

				  prow.zCost[pi] += trow.zCost[pi];
				  prow.zValue[pi] += trow.zValue[pi];
				  prow.zFTE[pi] += trow.zFTE[pi];
			  }

		  }
	  }

  }
  Model.prototype.FlashTargetData = function () {

	  this.EditGrid = Grids["et_1"];

	  var trow, grow, cat, xrow;
	  var arows = this.EditGrid.Rows;
	  var oc;
	  var xi;

	  if (this.TargetGroupingField == 0)
		  this.EditGrid.HideCol("GroupVal");
	  else
		  this.EditGrid.ShowCol("GroupVal");

	  for (var i = 0; i < this.CSTargetCache.targetRows.length; i++) {
		  trow = this.CSTargetCache.targetRows[i];
		  grow = arows[i + 1];

		  //          if (i > 0) {
		  //              xrow = arows[i];
		  //              xrow.nextSibling = grow;
		  //              grow.prevSibling = xrow;
		  //          }
		  //          else if (this.CSTargetCache.targetRows.length > 1)
		  //              grow.nextSibling = arows[2];
		  //             



		  if (trow.bGroupRow == true) {
			  this.EditGrid.SetAttribute(grow, "Select", "Type", "Text", 1);
			  this.EditGrid.SetAttribute(grow, "Select", "CanEdit", 0, 1);
			  this.EditGrid.SetString(grow, "Select", "", 1);
			  this.EditGrid.SetAttribute(grow, "CostType", "Button", "", 1);
			  this.EditGrid.SetAttribute(grow, "CostCategory", "Button", "", 1);

			  for (xi = 0; xi < this.CSDataCache.CustomFields.length; xi++) {
				  oc = this.CSDataCache.CustomFields[xi];
				  this.EditGrid.SetAttribute(grow, oc.Name, "CanEdit", 0, 1);
				  this.EditGrid.SetAttribute(grow, oc.Name, "Button", "", 1);
			  }
		  }
		  else {
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
			  if (cat.UoM == "" )
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
					  if (cat.FTEConv[per] != 0)
						  trow.zFTE[per] = (trow.zValue[per] * 100) / cat.FTEConv[per];
					  else
						  trow.zFTE[per] = 0;
					  this.EditGrid.SetString(grow, x, trow.zFTE[per], 1);
				  }
				  else
					  this.EditGrid.SetString(grow, x, trow.zValue[per], 1);
			  }
			  else if (trow.bGroupRow == true) {
				  if (this.etShowingFTEs == true)
					  this.EditGrid.SetString(grow, x, trow.zFTE[per], 1);
				  else
					  this.EditGrid.SetString(grow, x, trow.zValue[per], 1);
			  }
			  else
				  this.EditGrid.SetString(grow, x, 0, 1);

			  x = "P" + per.toString() + "C";
			  this.EditGrid.SetString(grow, x, trow.zCost[per], 1);
			  this.EditGrid.SetAttribute(grow, x, "CanEdit", ce, 1);

		  }
	  }
  }


   Model.prototype.PopulateTarget = function () {

		if (this.saveOrApply == null)
		{
//			this.dlgEditTarget.window("winEditTargetDlg").hide();
			this.saveOrApply = new dhtmlXWindows();
			this.saveOrApply.setSkin("dhx_web");
			this.saveOrApply.enableAutoViewport(false);
			this.saveOrApply.attachViewportTo(this.clientID + "mainDiv");
			this.saveOrApply.setImagePath(this.imagePath);
			this.saveOrApply.createWindow("winSoADlg", 20, 30, 210, 135);
			this.saveOrApply.window("winSoADlg").setIcon("logo.ico", "logo.ico");
			this.saveOrApply.window("winSoADlg").allowMove();
			this.saveOrApply.window("winSoADlg").denyResize();
			this.saveOrApply.window("winSoADlg").setModal(true);
			this.saveOrApply.window("winSoADlg").center();

			this.viaPopulateTarget = true;

			this.saveOrApply.window("winSoADlg").setText("Select Populate Version");
 
			this.saveOrApply.window("winSoADlg").attachObject("idSaveVersionOrApplyTargetDlgObj");
			this.saveOrApply.window("winSoADlg").button("close").disable();
			this.saveOrApply.window("winSoADlg").button("park").hide();
			this.saveOrApply.window("winSoADlg").button("minmax1").hide();

			var SVoT = document.getElementById('idSaveorApply');
			SVoT.options.length = 0;


			for (var n = 0; n < this.CSDataCache.Versions.length; n++) {
				var Id = this.CSDataCache.Versions[n].Id;
				var Name = this.CSDataCache.Versions[n].Name;
				SVoT.options[n] = new Option(Name, Id, n == 0, n == 0);
			}


			   
		}
		else
		   this.saveOrApply.window("winSoADlg").show();
	}

	Model.prototype.GetVersionTargetComplete = function (result) {

	    this.EditGrid = Grids["et_1"];
	    var narr = new Array(result.targetRows.length + this.CSTargetCache.targetRows.length);
	    var i;


	    for (i = 0; i < this.CSTargetCache.targetRows.length; i++) {
	        narr[i] = this.CSTargetCache.targetRows[i];
	    }

	    var adj = this.CSTargetCache.targetRows.length;
	    var grow;
	    var cnt = 0;
	    var cat;

	    for (i = 0; i < result.targetRows.length; i++) {
	        // add to 
	        cnt = i + adj + 1;

	        narr[i + adj] = result.targetRows[i];

	        grow = this.EditGrid.AddRow(null, null, true, cnt.toString(), "");

	        grow.NoColorState = 1;

	        trow = result.targetRows[i];

	        this.EditGrid.SetString(grow, "Select", "0", 1);

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
	                    if (cat.FTEConv[per] != 0)
	                        trow.zFTE[per] = (trow.zValue[per] * 100) / cat.FTEConv[per];
	                    else
	                        trow.zFTE[per] = 0;
	                    this.EditGrid.SetString(grow, x, trow.zFTE[per], 1);
	                }
	                else
	                    this.EditGrid.SetString(grow, x, trow.zValue[per], 1);
	            }
	            else
	                this.EditGrid.SetString(grow, x, 0, 1);

	            x = "P" + per.toString() + "C";
	            this.EditGrid.SetString(grow, x, trow.zCost[per], 1);
	            this.EditGrid.SetAttribute(grow, x, "CanEdit", ce, 1);

	        }


	    }

	    var arows = this.EditGrid.Rows;

	    this.CSTargetCache.targetRows = narr;
	    this.FlashTargetData();
	    this.EditGrid.RenderBody();
	}

	var RefreshTargetGrid = function () {

		try {


			window.setTimeout(HandleTargetRefreshDelegate, 100);
		}

		catch (e) {
		}
	}


	Model.prototype.HandleTargetRefresh = function () {

		try {
			this.RollUpTargetGrouping();
			this.FlashTargetData();
	   }
		catch (e) {

		}

	}

	Model.prototype.GridsOnGetDefaultColor = function (grid, row, col, r, g) {

		if (grid.id == "g_1") {

		    if (row.firstChild == null)
		        return null;

		    return 0xF8F8F8;
		}
		if (grid.id == "bottomg_1") {

			return null;

			//    if (Row.Kind == "Data")
			//        return "rgb(255,255,255)";



        }



        if (grid == this.FindGrid && col == this.FindCol && row.id == this.FindRow)

            return "rgb(" + r + "," + (g - 30) + "," + b + ")";


        if (grid == this.EditGrid) {

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

		return null;




	}


	var HandleClick = function (Grid, Row, Col, value) {
		var children;

		Row.Changed = 1;
		Grid.SetString(Row, Col, value, 1);
		children = Row.firstChild;

		while (children != null) {
			HandleClick(Grid, children, Col, value);
			children = children.nextSibling;
		}
	}

	var RefreshBottomGrid = function () {

		try {


			window.setTimeout(HandleRefreshDelegate, 100);
		}

		catch (e) {
		}
	}

	var RefreshBothGrids = function () {

		try {


			window.setTimeout(HandleRefreshBothDelegate, 300);
		}

		catch (e) {
		}
	}

	var PingSessionData = function () {

		try {


			window.setTimeout(HandlePingSessionData, 1000 * 60);
		}

		catch (e) {
		}
	}

   Model.prototype.GridsOnClickCell = function (grid, row, col) 
   {
//        if (grid.id == "et_1")
//        {

//        alert(col);
//        }
   }

//   Model.prototype.GridsOnRenderStart = function (grid) {
//       //	   grid.SetStyle(this.params.GridStyle, this.params.GridCSS, false);

//       var i = 1;
//   }


   Model.prototype.GridsOnRenderFinish = function (grid) {

       var i;

       if (grid.id == "bottomg_1") {
           if (this.burkka == true)
               this.HideWorkingPopup("divLoading");
       }

       if (grid.id == "f_1")
           this.FilterGrid = grid;

       if (grid.id == "t_1")
           this.TotalGrid = grid;

       if (grid.id == "et_1")
           this.EditGrid = grid;



       if (grid.id == "col_1") {
           this.ColsGrid = grid;

           if (this.ColsLoading == false)
               return;

           ColsLoading = false;

           WorkEnginePPM.Model.GetColumnOrderData(this.TicketVal, GetColsCompleteDelegate);
           return;

       }

       if (grid.id == "g_1") {
           this.DetGrid = grid;

           if (this.GanttShowing == true) {
               try {

                   if (this.firstdate == null) {

                       var xrows = grid.Rows;

                       for (var r in xrows) {
                           var row = xrows[r];


                           if (row != null) {
                               if (row.Kind == "Data") {

                                   var sdt = grid.GetString(row, "Start");
                                   var dateParts = sdt.split("/");

                                   var dt = new Date(dateParts[2], (dateParts[0] - 1), dateParts[1]);

                                   if (this.firstdate == null)
                                       this.firstdate = dt;
                                   else if (this.firstdate > dt)
                                       this.firstdate = dt;

                               }
                           }
                       }

                   }
               }
               catch (ex) { }


               if (this.ZoomTo != "") {
                   this.DetGrid.ChangeZoom(this.ZoomTo);

                   this.deferredZoom = this.ZoomTo;


                   window.setTimeout(this.DeferredZommDelegate, 100);


                   var selectZoom = document.getElementById("idGanttZoom");

                   selectZoom.selectedIndex = this.ZoomTo.substr(4, 1) - 1;
                   this.viewBar.refreshSelect("idGanttZoom");

                   this.ZoomString = this.ZoomTo;

                   //               if (this.firstdate != null)
                   //                   this.DetGrid.ScrollToDate(this.firstdate);
                   //               
                   this.ZoomTo = "";
               }
           }
       }




       if (grid.id == "g_1" && this.DetGridDoRender == true) {

           this.DetGridDoRender = false;


           var dstl = this.SnGData.DetShowToLevel;

           if (dstl == 0)
               return;

           --dstl;

           var arows = grid.Rows;


           for (i = 1; i <= grid.RowCount; i++) {
               var xr = arows[i];

               if (xr.Level >= dstl) {
                   grid.Collapse(xr);
               }
           }

           return;

       }

       if (grid.id == "bottomg_1") {

           this.TotGrid = grid;

           var trows = grid.Rows;

           if (this.TotGridDoRender == true) {

               this.TotGridDoRender = false;
               this.BottomGridState = null;

               var tstl = this.SnGData.TotShowToLevel;

               if (tstl == 0) {
                   WorkEnginePPM.Model.GetCompareStringValue(this.TicketVal, GetCompareStringValueCompleteDelegate);
                   return;
               }


               --tstl;


               for (i = 1; i <= grid.RowCount; i++) {
                   var yr = trows[i];

                   if (yr.Level >= tstl) {
                       grid.Collapse(yr);
                   }
               }
           }
           else if (this.BottomGridState != null) {
               var parr = new Array(256);

               for (i = 1; i <= grid.RowCount; i++) {
                   var zr = trows[i];

                   //                   parr[zr.Level] = zr;

                   if (this.BottomGridState[i] == 0) // && zr.Level > 0)
                   {
                       //                      var pr = parr[zr.Level - 1]
                       grid.Collapse(zr);
                   }
               }

               this.BottomGridState = null;



           }


           WorkEnginePPM.Model.GetCompareStringValue(this.TicketVal, GetCompareStringValueCompleteDelegate);
           return;

       }
   }


   Model.prototype.DeferredZomm = function () {


       try {
           if (this.deferredZoom == "")
               return;


           this.DetGrid.ChangeZoom(this.deferredZoom);

           this.deferredZoom = "";



           if (this.firstdate != null)
               this.DetGrid.ScrollToDate(this.firstdate);

       }

       catch (e) { };

   }


    Model.prototype.GetCompareStringValueComplete = function (result) {
        this.scompareStringtext = result;

        document.getElementById('idcmptextval').innerHTML = this.scompareStringtext;

    }


    Model.prototype.OnAfterColResize = function (grid, col) {
	   if (grid.id == "et_1")
		   this.EditGrid = grid;
	   else
		   return;

	   var arows = grid.Rows;

	   grid.SetWidth(col, 1);

	   


	   for (i = 1; i <= grid.RowCount; i++) {
		   var xr = arows[i];

		   var xz = xr.Def;



	   }
    }

    Model.prototype.GridsOnReady = function (grid, start) {
        if (grid.id == "g_1" && this.TotGrid == null) {

            var sbDataxml = new StringBuilder();
            sbDataxml.append('<![CDATA[');
            sbDataxml.append('<Execute Function="GetBottomGrid">');
            sbDataxml.append('</Execute>');
            sbDataxml.append(']]>');

            var sb = new StringBuilder();
            sb.append("<treegrid  SuppressMessage='3' debug='0' sync='0' ");
            sb.append(" Export_Url='ModelExportExcel.aspx'");
            sb.append(" data_url='" + this.Webservice + "'");
            sb.append(" data_method='Soap'");
            sb.append(" data_function='Execute'")
            sb.append(" data_namespace='WorkEnginePPM'");
            sb.append(" data_param_Ticket='" + this.TicketVal + "'");
            sb.append(" data_param_Function='GetBottomGrid'");
            sb.append(" data_param_Dataxml='" + sbDataxml.toString() + "'");
            sb.append(" >");
            sb.append("</treegrid>");

            this.TotGrid = TreeGrid(sb.toString(), "bottomgridDiv_1", "bottomg_1");

         }




        try {
            if (grid.id == "bottomg_1") {
                this.OnResize();

            }
        }
        catch (e) {
        }
    }


    Model.prototype.ShowWorkingPopup = function (divid) {
        //        var veil = document.getElementById("veil");
        //        veil.style.display = "block";
        var div = $('#' + divid);
        var win = $(window);
        div.css('top', (win.height() - div.height()) / 2);
        div.css('left', (win.width() - div.width()) / 2);
        div.show();
        var veil = $('#veil');
        this.burkka = true;
        veil.show();
    };
    Model.prototype.HideWorkingPopup = function (divid) {
        var div = $('#' + divid);
        div.hide();
        var veil = $('#veil');
        this.burkka = false;
        veil.hide();
    };


    Model.prototype.tabbarOnSelect = function (id, data) {
        if (this.ribbonBar.isCollapsed() == true) {
            this.layout.cells(this.mainRibbonArea).fixSize(false, false);
            this.layout.cells(this.mainRibbonArea).setHeight(120);
            this.layout.cells(this.mainRibbonArea).fixSize(false, true);
            this.ribbonBar.expand();
            this.viewBar.expand();
        }
    }
          try {
		// Initialised fields
		this.params = params;
		this.clientID = params.ClientID; // Text ID of the parent control
		this.ProjectID = 1;
		this.ViewUID = 1;
		this.Webservice = params.Webservice;
		this.TicketVal = params.TicketVal;
		this.ModelVal = params.ModelVal;
		this.VersionsVal = params.VersionsVal;
		this.ViewID = params.ViewIDVal;
		this.ViewName = params.ViewNameVal;

		this.ZoomTo = "Zoom1";
		this.LastSelZoomTo = this.ZoomTo;
		this.GanttShowing = false;

		this.Path = params.URL;

		//var toolArea = "a";
		this.mainRibbonArea = "a";
		this.mainArea = "b";
		this.totalsArea = "c";


		this.selectPIList = null;

		this.totalsRibbonArea = "a";
		this.totalsGridArea = "b";
              
        this.targetArea = "a";
		//var toolAreaCollapsed = true;
		this.totalsAreaCollapsed = true;

		this.layout = null;
		this.initialized = false;
		this.Height = 0;
		 this.selectModelAndVersion = null;
		this.selectFiltering = null;
		this.selectTotals = null;
		this.selectSnG = null;
		this.bSettingSnG = false;
		this.SnGData = null;
		this.selectCols = null;
		this.ColData = null;
		this.reSelRow = 0;
		this.selectCopy = null;
		this.saveOrApply = null;
		this.VersionsList = null;
		this.FromTarget = false;
		this.selectPoD = null;
		this.PeriodsandOptions = null;
		this.FindGrid = null;
		this.FindCol = null;
		this.FindRow = null;
		this.showBusy = null;
		this.dlgCreateTarget = null;
		this.viaPopulateTarget = false;
		this.CurrUserView = "";
		this.dospecialcurrview = true;

		this.deferredZoom = "";

		this.SearchDet = true;
		this.SeachCol = "";
		this.SeachHow = 0;
		this.SearchText = "";
		this.SearchStartRow = 0;
		this.MoveBarRow = 0;
		this.DoingDelete = false;
		this.DoingEdit = false;
		this.dlgEditTarget = null;
		this.dlgShowLegend = null;
		this.LegendGrid = null;

		this.EditTargetid = 0;
		this.EditGrid = null;

		this.UserViews = null;
 
		this.selectCostTypeCmp = null;

		this.CTCmpGrid = null;

		this.bdoingCmp = false;
		this.bShowingTotals = true;

        this.ModelViewDlg = null;

        this.burkka = false;

		var loadDelegate = MakeDelegate(this, this.OnLoad);
		var GetModelsCompleteDelegate = MakeDelegate(this, this.GetModelsComplete);
		var GetLoadSelectVersionCompleteDelegate = MakeDelegate(this, this.GetLoadSelectVersionComplete);
		var resizeDelegate = MakeDelegate(this, this.OnResize);
		var getLoadModelDataDelegate = MakeDelegate(this, this.OnLoadModelDataComplete);
		var layoutOnResizeFinishDelegate = MakeDelegate(this, this.layoutOnResizeFinish);
		var toolbarOnClickDelegate = MakeDelegate(this, this.toolbarOnClick);
		var ettoolbarOnClickDelegate = MakeDelegate(this, this.ettoolbarOnClick);
		var DeferedGridCreateDelegate = MakeDelegate(this, this.DeferedGridCreate);
		
		var GridsOnAfterValueChangedDelegate = MakeDelegate(this, this.GridsOnAfterValueChanged);
		var BarMovedCompleteDelegate = MakeDelegate(this, this.BarMovedComplete);

		var GridsOnGanttChangedDelegate = MakeDelegate(this, this.GridsOnGanttChanged);
		var FinishSnGDelegate =  MakeDelegate(this, this.FinishSnG);
		var GetSortAndGroupCompleteDelegate = MakeDelegate(this, this.GetSortAndGroupComplete);
		var InitialGetSortAndGroupCompleteDelegate = MakeDelegate(this, this.InitialGetSortAndGroupComplete);
		var InitialGetSortAndGroupDelegate = MakeDelegate(this, this.InitialGetSortAndGroup);
		var GetColsCompleteDelegate = MakeDelegate(this, this.GetColsComplete);
		var GridsOnValueChangedDelegate = MakeDelegate(this, this.GridsOnValueChanged);
		var GridsOnReadyDelegate = MakeDelegate(this, this.GridsOnReady);


		var GetPortfolioItemListCompleteDelegate = MakeDelegate(this, this.GetPortfolioItemListComplete);
		var GetGeneratedPortfolioItemTicketCompleteDelegate = MakeDelegate(this, this.GetGeneratedPortfolioItemTicketComplete);
        
		var GetSearchCompleteDelegate = MakeDelegate(this, this.GetSearchComplete);

		var LoadColumnOrderData = MakeDelegate(this, this.DoLoadColumnOrderData);
		var ColChangeSelectRowDelegate = MakeDelegate(this, this.ColChangeSelectRow);
		var GridsOnRenderFinishDelegate = MakeDelegate(this, this.GridsOnRenderFinish);
		var GetLoadSelectCopyVersionListsCompleteDelegate = MakeDelegate(this, this.GetLoadSelectCopyVersionListsComplete);
		var GetSaveOrTargetsCompleteDelegate = MakeDelegate(this, this.GetSaveOrTargetsComplete);
		var GetDeleteEditTargetsCompleteDelegate = MakeDelegate(this, this.GetDeleteEditTargetsComplete);
		var GetPeriodsandDisplayOptsDelegate = MakeDelegate(this, this.GetPeriodsandDisplayOpts);
		var GridsOnGetDefaultColorDelegate = MakeDelegate(this, this.GridsOnGetDefaultColor);
		var DoShowGanttCompleteDelegate = MakeDelegate(this, this.DoShowGanttComplete);
		var CreateTargetCompleteDelegate = MakeDelegate(this, this.CreateTargetComplete);
		var GetVersionTargetCompleteDelegate = MakeDelegate(this, this.GetVersionTargetComplete);
//		var GridsOnRenderStartDelegate = MakeDelegate(this, this.GridsOnRenderStart);

		var GetClientSideCalcDataCompleteDelegate = MakeDelegate(this, this.GetClientSideCalcDataComplete);
		var GetTargetDataCompleteDelegate =  MakeDelegate(this, this.GetTargetDataComplete);
		var FireupEditTargetDelegate = MakeDelegate(this, this.FireupEditTarget);
        
		this.CSDataCache = null;
		var GridsOnClickCellDelegate = MakeDelegate(this, this.GridsOnClickCell);

		var HandleGanttButtonsDelegate = MakeDelegate(this, this.HandleGanttButtons);
		var GetCompareStringValueCompleteDelegate = MakeDelegate(this, this.GetCompareStringValueComplete);

		
		this.TargetGroupingField = 0;
		var dlgTargetGroup = null;


		var SelectUserViewDataCompleteDelegate = MakeDelegate(this, this.SelectUserViewDataComplete);


		var HandleRefreshDelegate = MakeDelegate(this, this.HandleRefresh);
		var HandleTargetRefreshDelegate = MakeDelegate(this, this.HandleTargetRefresh);
		var HandleRefreshBothDelegate = MakeDelegate(this, this.HandleBothRefresh);
		var HandlePingSessionData = MakeDelegate(this, this.HandlePingSession);

		var GetCostViewsCompleteDelegate = MakeDelegate(this, this.GetCostViewsComplete);
		this.IsModeller = true;

		var LoadUserViewDataCompleteDelegate = MakeDelegate(this, this.LoadUserViewDataComplete);
		var SaveTargetDataCompleteDelegate = MakeDelegate(this, this.SaveTargetDataComplete);

		var tabbarOnSelectDelegate = MakeDelegate(this, this.tabbarOnSelect);

		var GoDoEditTimerDelegate = MakeDelegate(this, this.GoDoEditTimer);

		this.DeferredZommDelegate = MakeDelegate(this, this.DeferredZomm);

		
		this.GoDoEditID = 0;
		this.GoDoEditName = "";
		this.scompareStringtext = "";

		this.firstdate = null;


        this.ZoomString = "";
		this.TotGrid = null;
		this.DetGrid = null;
		this.ColsGrid = null;
		this.FilterGrid = null;
		this.ColsLoading = true;
		this.imagePath = "/_layouts/ppm/images/";
		this.VersionsOrTargets = null;
		this.BottomGridState = null;
		this.etlayout = null;
		this.CSTargetCache = null;

		this.DetSeachCol = "";
		this.TotSeachCol = "";
		this.etShowingFTEs = false;


		this.DetGridDoRender = false;
		this.TotGridDoRender = false;

		var GridsOnAfterColResizeDelegate = MakeDelegate(this, this.OnAfterColResize);

 
		if (document.addEventListener != null) { // e.g. Firefox
			window.addEventListener("load", loadDelegate, true);
		}
		else { // e.g. IE
			window.attachEvent("onload", loadDelegate);

		}
	}

	catch (e) {
		alert("Main error");
	}
}