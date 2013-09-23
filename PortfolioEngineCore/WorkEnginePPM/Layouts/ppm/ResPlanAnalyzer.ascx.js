function ResPlanAnalyzer(thisID, params) {
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


	ResPlanAnalyzer.prototype.OnLoad = function (event) {
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
			Grids.OnMouseDown = GridsOnMouseDownDelegate;
			
      
			Grids.OnRenderStart = GridsOnRenderStartDelegate;
			Grids.OnRenderFinish = GridsOnRenderFinishDelegate;



			Grids.OnUpdated = GridsOnUpdatedDelegate;


			WorkEnginePPM.ResPlanAnalyzer.set_path(this.params.Webservice);


			WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("GetRAUserCalendarInfo", "", GetCalendarInfoCompleteDelegate);
		}
		catch (e) {
			alert("Resource Analyzer OnLoad Exception");
		}
	}

	ResPlanAnalyzer.prototype.OnUnload = function (event) {
		if (this.Dirty && this.ExitConfirmed == false)
			event.returnValue = "You have unsaved changes.\n\nAre you sure you want to exit without saving?";
		this.ExitConfirmed = false;
	}


	ResPlanAnalyzer.prototype.OnResize = function (event) {
	    if (this.initialized == true) {
	        //var toolbarDataObjectDiv = document.getElementById("toolbarDataObjectDiv");


	        if (this.Height == 0) {

	            this.Width = document.documentElement.clientWidth;
	            this.Height = document.documentElement.clientHeight;
	        }
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
	        if (this.dlgChart != null)
	            this.dlgChart.window("winChartDlg").setDimension(this.Width, this.Height);
	    }
	}



	ResPlanAnalyzer.prototype.HandlePingSession = function () {
		try {
			WorkEnginePPM.ResPlanAnalyzer.Execute("RASessionPing", "");
			this.PingSessionData();
		}
		catch (e) {

		}

	}

	ResPlanAnalyzer.prototype.PingSessionData = function () {

		try {


			window.setTimeout(HandlePingSessionData, 1000 * 60);
		}

		catch (e) {
		}
	}


	ResPlanAnalyzer.prototype.SetSize = function (nWidth, nHeight) {

		if (this.Width == nWidth && this.Height == nHeight)
			return;

		this.Width = nWidth;
		this.Height = nHeight;
		this.OnResize();
	}

	ResPlanAnalyzer.prototype.xmlStringToJson = function (xmlstring) {

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

	ResPlanAnalyzer.prototype.xmlToJson = function (xml) {

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

	ResPlanAnalyzer.prototype.BuildViewInf = function (viewGUID, viewName, isViewDefault, isViewPersonal, bConvToJSON) {
		if (isViewDefault == true) isViewDefault = 1; else if (isViewDefault == false) isViewDefault = 0;
		if (isViewPersonal == true) isViewPersonal = 1; else if (isViewPersonal == false) isViewPersonal = 0;

		var sTopGrid = this.BuildGridInf("g_1", this.AnalyzerFilterschecked, this.AnalyzeGroupingchecked, this.AnalyzerTabisCollapsed);

		var sBottomGrid = this.BuildGridInf("bottomg_1", this.TotalFilterschecked, this.TotalGroupingchecked, this.TotalTabisCollapsed);


		// need to get details xml, totals xml, mode settings 

		var ssbf = (this.AnalyzerShowBarschecked ? "1" : "0");
		var shdf = (this.AnalyzerHideDetailschecked ? "1" : "0");
		var shbd = (this.showingTotDet ? "1" : "0");	
        
        
        var FromList = document.getElementById("idAnalyzerTab_FromPeriod");
	    var ToList = document.getElementById("idAnalyzerTab_ToPeriod");

	    var StartID = parseInt(FromList.options[FromList.selectedIndex].value);
	    var FinishID = parseInt(ToList.options[ToList.selectedIndex].value);
        
        		

		var dataXml = '<View ViewGUID="' + XMLValue(viewGUID) + '" Name="' + XMLValue(viewName) + '" Default="'
				+ isViewDefault + '" Personal="' + isViewPersonal + '">'
				+ sTopGrid
				+ sBottomGrid
				+ '<OtherData>'
				+ this.TotalsColumnSettings
				+ this.DetailsSettings
				+ this.DisplayMode
				+ '</OtherData>'
				+ '<ViewSettings ShowBars="' + ssbf + '" HideDetails="' + shdf + '" ShowBotDet="' + shbd + '"';
                
                
        if (StartID == -1) 
            dataXml += ' PerInc = "1" FinishPeriod="' + FinishID + '" ';
        else
            dataXml += ' PerInc = "0" '
                
                
        dataXml += '/>' +'</View>';

		if (bConvToJSON != true)
			return dataXml;


		return this.xmlStringToJson(dataXml);

	}

	ResPlanAnalyzer.prototype.BuildGridInf = function (gridId, showFilter, showGrouping, ribbonExpanded) {
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

	ResPlanAnalyzer.prototype.DoesColExist = function (allcols, thiscol) {
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

	ResPlanAnalyzer.prototype.ApplyGridView = function (gridId, view, bRender) {
	    try {

	        var grid = Grids[gridId];
	        var gridView = view[gridId];
	        var allCols = new Array();

	        var gcols = grid.GetCols();

	        var p1c1ind = 0;


	        var FromList = document.getElementById("idAnalyzerTab_FromPeriod");
	        var ToList = document.getElementById("idAnalyzerTab_ToPeriod");

	        var StartID = parseInt(FromList.options[FromList.selectedIndex].value);


                              
            if (StartID == -1)
            {
                StartID = this.UsingPeriods.CurrentPeriod.Value;
            }

	        var FinishID = parseInt(ToList.options[ToList.selectedIndex].value);

	        for (var i = 0; i < gcols.length; i++) {
	            if (gcols[i] == "P1C1") {
	                p1c1ind = i;
	                break;
	            }
	        }


	        if (gridView.LeftCols !== null) {

	            if (gridId == "bottomg_1" && gridView.LeftCols == "")
	                gridView.LeftCols = "rtSelect:20";
                else {
	                if (gridView.LeftCols.indexOf("rtSelect") == -1)
	                {
	                    gridView.LeftCols += ",rtSelect:20";
	                }

	            }


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

	        try {
	            if (grid.Group != "")
	                grid.DoGrouping(null);
	        }
	        catch (e) { };

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
	                    this.showFilters(grid, false);
	                } else {
	                    this.hideFilters(grid, false);
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
	            try {
	                if (grid.Group != "")
	                    grid.DoGrouping(null);
	            } catch (e) { };
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

	ResPlanAnalyzer.prototype.flashGridView = function (gridId, bDoRender) {
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


            

            if (StartID == -1)
            {
                StartID = this.UsingPeriods.CurrentPeriod.Value;
            }



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

   
	ResPlanAnalyzer.prototype.SaveResourceAnalyzerViewComplete = function (jsonString) {
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
			this.HandleException("SaveResourceAnalyzerViewComplete", e);
		}
	}

	ResPlanAnalyzer.prototype.RenameResourceAnalyzerViewComplete = function (jsonString) {
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

	ResPlanAnalyzer.prototype.GetCalendarInfoComplete = function (jsonString) {

	    try {

	        if (jsonString != null) {

	            var jsonObject = JSON_ConvertString(jsonString);
	            if (JSON_ValidateServerResult(jsonObject)) {
	                this.ficalInfo = jsonObject.Result.ResourceAnalyzerCalendars;

	                if (this.ficalInfo.Security.Value != "1") {

	                    alert("You do not have the Global Permission set to access this functionality!");

	                    if (parent.SP.UI.DialogResult)
	                        parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
	                    else
	                        parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');


	                    return;
	                }
	            }
	        }

	        {

	            var CalList = document.getElementById('idCalList');
	            var FromList = document.getElementById('idPerFromList');
	            var ToList = document.getElementById('idPerToList');
	            var LastCal = null;

	            this.CmtCal = this.ficalInfo.Calendars.CmtCal.Value;
	            CalList.options.length = 0;
	            FromList.options.length = 0;
	            ToList.options.length = 0;

	            var cal_arr = JSON_GetArray(this.ficalInfo.Calendars, "Calendar");

	            if (cal_arr.length == 0) {
	                alert("No Fiscal Calendars have been defined - please contact your administrator");

	                if (parent.SP.UI.DialogResult)
	                    parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
	                else
	                    parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');


	                return;
	            }


	            if (this.selectCalendarAndPeriods == null) {
	                this.selectCalendarAndPeriods = new dhtmlXWindows();
	                this.selectCalendarAndPeriods.setSkin("dhx_web");
	                this.selectCalendarAndPeriods.enableAutoViewport(false);
	                this.selectCalendarAndPeriods.attachViewportTo(this.params.ClientID + "mainDiv");   // ("layoutDiv");
	                this.selectCalendarAndPeriods.setImagePath("/_layouts/ppm/images/");
	                //                   this.selectCalendarAndPeriods.createWindow("winFCandPerDlg", 20, 30, 410, 175);
	                this.selectCalendarAndPeriods.createWindow("winFCandPerDlg", 20, 30, 410, 120);
	                this.selectCalendarAndPeriods.window("winFCandPerDlg").setIcon("logo.ico", "logo.ico");
	                this.selectCalendarAndPeriods.window("winFCandPerDlg").allowMove();
	                this.selectCalendarAndPeriods.window("winFCandPerDlg").denyResize();
	                this.selectCalendarAndPeriods.window("winFCandPerDlg").setModal(true);
	                this.selectCalendarAndPeriods.window("winFCandPerDlg").center();
	                this.selectCalendarAndPeriods.window("winFCandPerDlg").setText("Select Analyzer Periods");
	                this.selectCalendarAndPeriods.window("winFCandPerDlg").attachObject("idFCandPerDlgObj");
	                this.selectCalendarAndPeriods.window("winFCandPerDlg").button("close").disable();
	                this.selectCalendarAndPeriods.window("winFCandPerDlg").button("park").hide();
	                //      this.selectCalendarAndPeriods.window("winFCandPerDlg").hideHeader();

	            }
	            else
	                this.selectCalendarAndPeriods.window("winFCandPerDlg").show();


	            for (var n = 0; n < cal_arr.length; n++) {
	                var cal = cal_arr[n];
	                var Id = cal.calID;
	                var Name = cal.calName;
	                CalList.options[n] = new Option(Name, Id, Id == this.ficalInfo.LastUserData.lastCalID, Id == this.ficalInfo.LastUserData.lastCalID);
	                if (Id == this.ficalInfo.LastUserData.lastCalID)
	                    LastCal = cal;
	            }

	            if (LastCal == null) {
	                LastCal = cal_arr[0];
	                this.ficalInfo.LastUserData.lastCalID = LastCal.calID;
	            }

	            if (LastCal == null)
	                return;

	            this.UsingPeriods = LastCal.Periods;

	            if (LastCal.Periods != null) {

	                for (var n1 = 0; n1 < LastCal.Periods.Period.length; n1++) {
	                    var per = LastCal.Periods.Period[n1];
	                    var perId = per.perID;
	                    var perName = per.perName;

	                    FromList.options[n1] = new Option(perName, perId, perId == this.ficalInfo.LastUserData.lastStartPerID, perId == this.ficalInfo.LastUserData.lastStartPerID);
	                    ToList.options[n1] = new Option(perName, perId, perId == this.ficalInfo.LastUserData.lastFinishPerID, perId == this.ficalInfo.LastUserData.lastFinishPerID);
	                }
	            }



	            window.setTimeout(SetInitialDisplayFocus, 100);


	        }
	    }

	    catch (e) {
	        alert("Resource Analyzer  GetCalendarInfoComplete error " + e.toString());

	        if (parent.SP.UI.DialogResult)
	            parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
	        else
	            parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');
	    }

	    return;
	}


	function SetInitialDisplayFocus() {
	    document.getElementById("idDisplayPress").focus();
	}


	ResPlanAnalyzer.prototype.SelectCalendar_Change = function () {
		var CalList = document.getElementById('idCalList');
		var FromList = document.getElementById('idPerFromList');
		var ToList = document.getElementById('idPerToList');
		var Cal = null;

		FromList.options.length = 0;
		ToList.options.length = 0;

		var CalID = CalList.options[CalList.selectedIndex].value;
		this.ficalInfo.LastUserData.lastCalID = CalID;
		this.ficalInfo.LastUserData.lastStartPerID = -1;
		this.ficalInfo.LastUserData.lastFinishPerID = -1;

		for (var n = 0; n < this.ficalInfo.Calendars.Calendar.length; n++) {
			Cal = this.ficalInfo.Calendars.Calendar[n];
			if (CalID == Cal.calID)
				break;
		}

		if (Cal.Periods == null)
			return;

		if (Cal.Periods.Period == null)
			return;


		this.UsingPeriods = Cal.Periods;

		for (var n1 = 0; n1 < Cal.Periods.Period.length; n1++) {
			var per = Cal.Periods.Period[n1];
			var perId = per.perID;
			var perName = per.perName;

			FromList.options[n1] = new Option(perName, perId, n1 == 0, n1 == 0);
			ToList.options[n1] = new Option(perName, perId, n1 == (Cal.Periods.Period.length - 1), n1 == (Cal.Periods.Period.length - 1));
		}

	}


	ResPlanAnalyzer.prototype.SelectFiscalDlg_OKOnClick = function (iCancel) {
	    this.selectCalendarAndPeriods.window("winFCandPerDlg").detachObject()
	    this.selectCalendarAndPeriods.window("winFCandPerDlg").close();
	    this.selectCalendarAndPeriods = null;




	    if (iCancel == 1) {


	        if (this.FromChangePeriods == false) {
	            if (parent.SP.UI.DialogResult)
	                parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
	            else
	                parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');
	        }

	        this.FromChangePeriods = false;

	        return;
	    }

	    if (this.FromChangePeriods == true) {


	            this.Detrid = Grids["g_1"];
	            this.Detrid.Dispose();
	            this.Detrid = null;

	            this.TotGrid = Grids["bottomg_1"];
	            this.TotGrid.Dispose();
	            this.TotGrid = null;

	            this.InitVars();
        }


	    var CalList = document.getElementById('idCalList');
	    var FromList = document.getElementById('idPerFromList');
	    var ToList = document.getElementById('idPerToList');


	    if (this.ficalInfo.LastUserData.lastCalID == -1) {
	        alert("No fiscal calendar has been selected!");
	        return;
	    }

	    if (FromList.length == 0) {

	        alert("The fiscal calendar selected does not have any periods defined!");
	        return;

	    }

	    //        var StartID = parseInt(FromList.options[FromList.selectedIndex].value);
	    //        var FinishID = parseInt(ToList.options[ToList.selectedIndex].value);
	    var per = this.UsingPeriods.Period[0];
	    StartID = per.perID;
	    var per = this.UsingPeriods.Period[this.UsingPeriods.Period.length - 1];
	    FinishID = per.perID;

	    //        if (StartID >= FinishID) {

	    //            alert("The From period must be before the To period");
	    //            return;
	    //        }


	    this.ficalInfo.LastUserData.lastStartPerID = StartID;
	    this.ficalInfo.LastUserData.lastFinishPerID = FinishID;



	    this.analyzerCalID = parseInt(this.ficalInfo.LastUserData.lastCalID);

	    var s = this.BuildLoadInf(this.params.TicketVal, this.ficalInfo.LastUserData.lastCalID, StartID, FinishID);


	    WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("RALoadData", s, LoadResPlanDataCompleteDelegate);

	}

	ResPlanAnalyzer.prototype.BuildLoadInf = function (sTicket, CalID, StartID, FinishID) {

		var dataXml = '<Load Ticket="' + sTicket + '" CalID="' + CalID + '" StartID="' + StartID + '" FinishID="' + FinishID + '">' + '</Load>';
		return dataXml;
	}


	// >>>>>> Totals area


	ResPlanAnalyzer.prototype.GetTotals = function () {
		WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("GetTotalsColumnsConfiguration", "", this.GetTotalsDataCompleteDelegate);
	}

	ResPlanAnalyzer.prototype.GetTotalsDataComplete = function (jsonString) {

		try {
			if (this.SetTotals == null) {



				this.SetTotals = new dhtmlXWindows();
				this.SetTotals.setSkin("dhx_web");

				this.SetTotals.enableAutoViewport(false);
				this.SetTotals.attachViewportTo(this.params.ClientID + "mainDiv");
				this.SetTotals.setImagePath(this.imagePath);
				this.SetTotals.createWindow("winTotDlg", 20, 30, 570, 510);
				this.SetTotals.window("winTotDlg").setIcon("logo.ico", "logo.ico");
				this.SetTotals.window("winTotDlg").allowMove();
				this.SetTotals.window("winTotDlg").denyResize();
				this.SetTotals.window("winTotDlg").setModal(true);
				this.SetTotals.window("winTotDlg").center();
				this.SetTotals.window("winTotDlg").setText("Totals Column Configuration");
				this.SetTotals.window("winTotDlg").attachObject("idTotalsColsDlg");
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

				var rbtotByRole = document.getElementById('idTotalsByRole');
				var rbtotByRes = document.getElementById('idTotalsByRes');
				var selRoleMode = document.getElementById('idSelRoleView');
				var selAvail = document.getElementById('idSelTotAvailCols');
				var selSelected = document.getElementById('idSelSelectedCols');
				var chkEnableHeatMap = document.getElementById('idEnableHeatMap');
				var selHeatMap = document.getElementById('idSelHeatmap');
				var selHeatMapColour = document.getElementById('idSelHeatmapColour');

				if (this.TotalsData.RoleMode.Value == 2)
					selRoleMode.selectedIndex = 1;
				else
					selRoleMode.selectedIndex = 0;

				if (this.TotalsData.TotalByRole.Value == 1) {
					rbtotByRole.checked = true;
					rbtotByRes.checked = false;
					selRoleMode.disabled = false;
					this.bottomgridbyrole = true;
				}
				else {
					rbtotByRes.checked = true;
					rbtotByRole.checked = false;
					selRoleMode.disabled = true;
					this.bottomgridbyrole = false;

				}

				chkEnableHeatMap.checked = (this.TotalsData.EnableHeatMap.Value == 1);


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

				window.setTimeout(this.FinishTotalsDelegate, 10);

			}
		}
		catch (e) {
			alert("Resource Analyzer  GetTotalsDataComplete error " + e.toString());

			if (this.SetTotals != null) {
				this.SetTotals.window("winTotDlg").detachObject()
				this.SetTotals.window("winTotDlg").close();
				this.SetTotals = null;
			}
		}
		this.TotalsLoading = false;

	}

 
	ResPlanAnalyzer.prototype.ChangeTotalsOptions = function () 
	{
		if (this.TotalsLoading == true)
			return;

		window.setTimeout(FinishTotalsDelegate, 10);
	}

	ResPlanAnalyzer.prototype.FinishTotals = function () {
	    if (this.TotalsLoading == true)
	        return;

	    var rbtotByRole = document.getElementById('idTotalsByRole');
	    var rbtotByRes = document.getElementById('idTotalsByRes');
	    var selRoleMode = document.getElementById('idSelRoleView');
	    var selAvail = document.getElementById('idSelTotAvailCols');
	    var selSelected = document.getElementById('idSelSelectedCols');
	    var chkEnableHeatMap = document.getElementById('idEnableHeatMap');
	    var selHeatMap = document.getElementById('idSelHeatmap');
	    var selHeatMapColour = document.getElementById('idSelHeatmapColour');

	    var iRoleMode = selRoleMode.value;

	    this.selectedHeatMapColour = selHeatMapColour;

	    var moveupbtn = document.getElementById('idSelectedColsMoveUp');
	    var movedownbtn = document.getElementById('idSelectedColsMoveDown');



	    selRoleMode.disabled = !rbtotByRole.checked;
	    selHeatMap.disabled = !chkEnableHeatMap.checked;

	    selHeatMapColour.disabled = !chkEnableHeatMap.checked;

	    selAvail.options.length = 0;
	    selSelected.options.length = 0;
	    selHeatMap.options.length = 0;

	    this.addbtndisabled = (this.TotAddSel == null);
	    this.setNewButtonDisable('idTotButtonAdd', this.addbtndisabled);

	    this.rembtndisabled = (this.TotRemSel == null);
	    this.setNewButtonDisable('idTotButtonRemove', this.rembtndisabled);

	    var i;
	    var item;
	    var j = 0;


	    var colopt = this.TotalsData.ColumnOptions;

	    if (iRoleMode == 1) {
	        colopt = this.TotalsData.ColumnNROptions;

	        for (i = 0; i < this.TotalsData.ColumnOptions.ColumnOption.length; i++) {
	            item = this.TotalsData.ColumnOptions.ColumnOption[i];
	            var bf = false;


	            for (xj = 0; xj < colopt.ColumnOption.length; xj++) {
	                var ij = colopt.ColumnOption[xj];

	                if (ij.ColumnID == item.ColumnID) {
	                    bf = true;
	                    break;
	                }

	            }

	            if (bf == false) {
	                item.Selected = 0;
	                var temparr = new Array();

	                for (xi = 0; xi < this.TotSelectedOrder.length; xi++) {
	                   if (this.TotSelectedOrder[xi] != item.ColumnID) {
        	                temparr[j++] = this.TotSelectedOrder[xi];
                    	}
	                }
	                this.TotSelectedOrder = temparr;


	            }

	        }


	    }

	    j = 0;

	    if (rbtotByRole.checked == false) {
	        var temparr = new Array();

	        for (i = 0; i < this.TotSelectedOrder.length; i++) {
	            if (this.TotSelectedOrder[i] <= 0)
	                temparr[j++] = this.TotSelectedOrder[i];
	        }
	        this.TotSelectedOrder = temparr;

	        if (this.TotalsData.EnableHeatField.Value > 0)
	            this.TotalsData.EnableHeatField.Value = -6;
	    }
	    else if (iRoleMode == 1) {
//	        var temparr = new Array();

//	        for (i = 0; i < this.TotSelectedOrder.length; i++) {
//	            if (this.TotSelectedOrder[i] <= 0)
//	                temparr[j++] = this.TotSelectedOrder[i];
//	            else {

//	                for (xi = 0; xi < this.TotalsData.ColumnOptions.ColumnOption.length; xi++) {
//	                    item = this.TotalsData.ColumnOptions.ColumnOption[xi];


//	                    if (this.TotSelectedOrder[i] == item.ColumnID) {
//	                        if (item.Selected == 1)
//	                            temparr[j++] = this.TotSelectedOrder[i];

//	                        break;
//	                    }
//	                }
//	            }
//	        }
//	        this.TotSelectedOrder = temparr;

	    }

	    var n1 = 0;
	    var usesel = this.TotalsData.EnableHeatField.Value;


	    for (i = 0; i < colopt.ColumnOption.length; i++) {
	        item = colopt.ColumnOption[i];
	        item.Selected = 0;

	        if (item.ColumnID != 0) {
	            if (item.ColumnID != -7 && item.ColumnID != -8) {

	                if (rbtotByRole.checked == true || (rbtotByRole.checked == false && item.ColumnID <= 0))
	                    selHeatMap.options[n1++] = new Option(item.Name, item.ColumnID, item.ColumnID == usesel, item.ColumnID == usesel);
	            }
	        }

	    }

	    n1 = 0;
	    var bSel = false;

	    var bfound = false;
	    var selval;

	    for (i = 0; i < this.TotSelectedOrder.length; i++) {
	        for (j = 0; j < colopt.ColumnOption.length; j++) {
	            item = colopt.ColumnOption[j];
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


	    selHeatMapColour.value = this.TotalsData.HeatFieldColour.Value;

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
	    for (j = 0; j < colopt.ColumnOption.length; j++) {
	        item = colopt.ColumnOption[j];
	        if (item.Selected == 0) {
	            bSel = false;




	            if (rbtotByRole.checked == true || (rbtotByRole.checked == false && item.ColumnID <= 0 && item.ColumnID != -8)) {
	                if (this.TotAddSel != null)
	                    bSel = (item.ColumnID == this.TotAddSel);

	                bfound |= bSel;

	                selAvail.options[n1++] = new Option(item.Name, item.ColumnID, bSel, bSel);
	            }
	        }
	    }

	    if (bfound == false)
	        this.TotAddSel = null;




	}


	ResPlanAnalyzer.prototype.TotalsCols_ButtonClick = function (iDir) {
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

                for (j = 0; j < this.TotalsData.ColumnNROptions.ColumnOption.length; j++) {
                    item = this.TotalsData.ColumnNROptions.ColumnOption[j];
                    if (item.ColumnID == iRemColID) {

                        item.Selected == 0;

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

                for (j = 0; j < this.TotalsData.ColumnNROptions.ColumnOption.length; j++) {
                    item = this.TotalsData.ColumnNROptions.ColumnOption[j];
                    if (item.ColumnID == iAddColID) {

                        item.Selected == 1;

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

	ResPlanAnalyzer.prototype.TotalsSelColsMove_ButtonClick = function (iallezup) {
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

	ResPlanAnalyzer.prototype.SelectTotals_OKOnClick = function (iApply) {
		if (iApply == 1) {


			var rbtotByRole = document.getElementById('idTotalsByRole');
			var selRoleMode = document.getElementById('idSelRoleView');
			var selAvail = document.getElementById('idSelTotAvailCols');
			var selSelected = document.getElementById('idSelSelectedCols');
			var chkEnableHeatMap = document.getElementById('idEnableHeatMap');
			var selHeatMap = document.getElementById('idSelHeatmap');
			var selHeatMapColour = document.getElementById('idSelHeatmapColour');


			var sb = new StringBuilder();
			sb.append("<TotalsConfiguration>");

			var sbDataxml = new StringBuilder();
			sbDataxml.append("<TotalByRole Value='");
			sbDataxml.append((rbtotByRole.checked ? "1" : "0"));
			sbDataxml.append("'/>");
			sb.append(sbDataxml.toString());

			var sbDataxml = new StringBuilder();
			sbDataxml.append("<RoleMode Value='");
			sbDataxml.append(selRoleMode.value);
			sbDataxml.append("'/>");
			sb.append(sbDataxml.toString());

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

			var sbDataxml = new StringBuilder();
			sbDataxml.append("<HeatFieldColour Value='");
			sbDataxml.append(selHeatMapColour.value);
			sbDataxml.append("'/>");
			sb.append(sbDataxml.toString());

			sbDataxml = new StringBuilder();
			sbDataxml.append("<SelectedOrderItems>");

			if (chkEnableHeatMap.checked) {
				var w = selHeatMap.selectedIndex;
				var selected_text = selHeatMap.options[w].text;
				this.heatmapText = selected_text;

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

				if (j == 0)
					sbDataxml.append("0");
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

			if (this.bottomgridbyrole != rbtotByRole.checked) {
				gview.Grouping = "";
				gview.Filters = "";
				gview.Sorting = "";

			}
			else {

				this.bottomgriddragstash = this.BuildViewInf("guid", "name", false, false, true);
				this.stashgridsettings = null;
			}

			WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("SetTotalsColumnsConfiguration", sb.toString(), this.SetTotalsDataCompleteDelegate);



		}

		this.SetTotals.window("winTotDlg").detachObject();
		this.SetTotals.window("winTotDlg").close();
		this.SetTotals = null;



	}


	ResPlanAnalyzer.prototype.SetTotalsDataComplete = function (jsonString) {

		try {
			var jsonObject = JSON_ConvertString(jsonString);
			if (JSON_ValidateServerResult(jsonObject)) {
				this.TotalsGridSettingsData = jsonObject.Result.TotalsGridSetting;

				this.TotalsGridSupressHeatmap = this.TotalsGridSettingsData.HeatMap.HeapMapSubCol;
				this.TotalsGridTotalsCol = this.TotalsGridSettingsData.HeatMap.HeapMapTotalsCol;
				
				this.heatmapText = "";

				try {
					this.heatmapText = this.TotalsGridSettingsData.HeatMap.HeatMapText;
				}
				catch (e) { }

				  RefreshBottomGrid();
			}
		}
		catch (e) {
			alert("Resource Analyzer  SetTotalsDataComplete error " + e.toString());

		}
	}

	ResPlanAnalyzer.prototype.SetChangeViewComplete = function (jsonString) {

		try {
			var jsonObject = JSON_ConvertString(jsonString);
			if (JSON_ValidateServerResult(jsonObject)) {
				this.TotalsGridSettingsData = jsonObject.Result.ViewData.TotalsGridSetting;

				this.TotalsGridSupressHeatmap = this.TotalsGridSettingsData.HeatMap.HeapMapSubCol;
				this.TotalsGridTotalsCol = this.TotalsGridSettingsData.HeatMap.HeapMapTotalsCol;

                var bdstate = jsonObject.Result.ViewData.BottomDetailsState.Value;

                this.showingTotDet = (bdstate == "1")
	            if (this.showingTotDet == true) {

	                    this.totTab.setButtonStateOn("idBTSDet");

                }
	            else {
                            
	                this.totTab.setButtonStateOff("idBTSDet");
 	            }

				
				var wmode = jsonObject.Result.ViewData.WorkDisplayMode.Mode;

				var wsel = document.getElementById("idAnalyzerTab_SelMode");
				wsel.selectedIndex = wmode - 1;


				this.DetailsData = jsonObject.Result.ViewData.WorkDetails;
  
				 var wselectedItem = wsel.options[wsel.selectedIndex];

				this.flashRibbonSelect("idAnalyzerTab_SelMode");
				this.flashTotalsButtons();

				this.stashgridsettings = null;

				RefreshBothGrids();
			}
		}
		catch (e) {
			alert("Resource Analyzer  SetChangeViewComplete error " + e.toString());

		}
	}




	ResPlanAnalyzer.prototype.SelectDetails_OKOnClick = function () {


		var chkAct = false;
		var chkReq = false;
		var chkMSP = false;
		var chkOpen = false;
		var chkNWI = false;
		var chkOReq = false;
		

   

		try {
				chkAct = this.analyzerTab.getButtonState("chkActual");
				chkReq = this.analyzerTab.getButtonState("chkCommit");
				chkMSP = this.analyzerTab.getButtonState("chkMSP");
				chkNWI = this.analyzerTab.getButtonState("chkNonWork");
				chkOReq = this.analyzerTab.getButtonState("chkOpenRequests");
				chkOpen = this.analyzerTab.getButtonState("chkRequests");
  
   
		}
		catch(e) {}


		var sb = new StringBuilder();
		sb.append("<WorkDetails>");

		var sbDataxml = new StringBuilder();
		sbDataxml.append("<ActualWork Value='");
		sbDataxml.append((chkAct == true ? "1" : "0"));
		sbDataxml.append("'/>");
		sb.append(sbDataxml.toString());

		sbDataxml = new StringBuilder();
		sbDataxml.append("<ProposedWork Value='");
		sbDataxml.append((chkOpen == true ? "1" : "0"));
		sbDataxml.append("'/>");
		sb.append(sbDataxml.toString());


		sbDataxml = new StringBuilder();
		sbDataxml.append("<ScheduledWork Value='");
		sbDataxml.append((chkMSP== true ? "1" : "0"));
		sbDataxml.append("'/>");
		sb.append(sbDataxml.toString());


		sbDataxml = new StringBuilder();
		sbDataxml.append("<CommittedWork Value='");
		sbDataxml.append((chkReq == true ? "1" : "0"));
		sbDataxml.append("'/>");
		sb.append(sbDataxml.toString());


		sbDataxml = new StringBuilder();
		sbDataxml.append("<PersonalWork Value='");
		sbDataxml.append((chkNWI == true ? "1" : "0"));
		sbDataxml.append("'/>");
		sb.append(sbDataxml.toString());

		sbDataxml = new StringBuilder();
		sbDataxml.append("<OpenRequestWork Value='");
		sbDataxml.append((chkOReq == true ? "1" : "0"));
		sbDataxml.append("'/>");
		sb.append(sbDataxml.toString());
		
		sb.append("</WorkDetails>");

		this.DetailsSettings = sb.toString();
		this.stashgridsettings = this.BuildViewInf("guid", "name", false, false, true);
		WorkEnginePPM.ResPlanAnalyzer.Execute("SetRAWorkDetails", sb.toString());

        this.stashgridsettings = this.BuildViewInf("guid", "name", false, false, true);
     	this.bottomgriddragstash = this.BuildViewInf("guid", "name", false, false, true);

		RefreshBothGrids();
	}


	ResPlanAnalyzer.prototype.SetSelectedMode = function (selindex) {
		try {
			var selectView = document.getElementById("idAnalyzerTab_SelMode");

			if (selindex != null) {

				if (selectView.selectedIndex == (selindex - 1)) {
					return false;
				}   
				
				selectView.selectedIndex = selindex - 1;
			}

			//           if (selectView.selectedIndex >= 0) {
			var selectedItem = selectView.options[selectView.selectedIndex];

			
			if (selectedItem.value != null) {


				var sb = new StringBuilder();
				sb.append("<WorkDisplayMode Mode='");
				sb.append(selectedItem.value);
				sb.append("' />");

				this.SelectedMode = selectedItem.value;

				this.DisplayMode = sb.toString();
				this.stashgridsettings = this.BuildViewInf("guid", "name", false, false, true);
				WorkEnginePPM.ResPlanAnalyzer.Execute("SetRAWorkDisplayMode", sb.toString());
				this.bottomgriddragstash = this.BuildViewInf("guid", "name", false, false, true);


				return true;
			}
			//           }
		}
		catch (e) {
			this.HandleException("GetSelectedMode", e);
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

	ResPlanAnalyzer.prototype.HandleBothRefresh = function () {

	    try {
	        if (this.DetGrid != null) {
	            //	            this.DetGrid.Reload(null);
	            this.DetGrid = Grids["g_1"];
	            this.DetGrid.Dispose();
	            this.DetGrid = null;


	            this.stashgridsettings = null;
	            var sbDataxml = new StringBuilder();
	            sbDataxml.append('<![CDATA[');
	            sbDataxml.append('<Execute Function="GetResourceAnalyzerData">');
	            sbDataxml.append('</Execute>');
	            sbDataxml.append(']]>');

	            var sb = new StringBuilder();
	            sb.append("<treegrid SuppressMessage='3' debug='0' sync='0' ");
	            sb.append(" Export_Url='rpaExportExcel.aspx'");
	            sb.append(" data_url='" + this.Webservice + "'");
	            sb.append(" data_method='Soap'");
	            sb.append(" data_function='Execute'")
	            sb.append(" data_namespace='WorkEnginePPM'");
	            sb.append(" data_param_Function='GetResourceAnalyzerData'");
	            sb.append(" data_param_Dataxml='" + sbDataxml.toString() + "'");
	            sb.append(" >");
	            sb.append("</treegrid>");

	            this.DetGrid = TreeGrid(sb.toString(), "gridDiv_1", "g_1");
	            this.doTopApply = true;

	        }

	        if (this.FilterDifferent == false)
	            RefreshBottomGrid();

	        this.FilterDifferent = false;
	    }
	    catch (e) {

	    }

	}


	ResPlanAnalyzer.prototype.InitializeLayout = function () {
	    try {



	        var negmode = this.DetailsData.NegMode.Value;
	        var showpersonal = this.DetailsData.ShowPersonal.Value;
	        var showopen = this.DetailsData.ShowOpenReq.Value;

            this.ChartATDisableList = new Array();
            this.ChartVTDisableList = new Array();
            this.ChartBTDisableList = new Array();
            this.ChartBlockCommand = new Array();





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
									{ type: "bigbutton", id: "SaveBtn", name: "Publish", img: "Publish.png", tooltip: "Publish", onclick: "dialogEvent('AnalyzerTab_SaveDrag');", disabled: true }
								]
							},
							{
							    items: [
									{ type: "bigbutton", name: "Close", img: "formatmap32x32.png", style: "top: -448px; left: -288px;position:relative;", tooltip: "Close", onclick: "dialogEvent('AnalyzerTab_Close');" }
								]
							},
							{
							    items: [
									{ type: "bigbutton", id: "idSaveScenario", name: "Save<br/>Scenario", img: "ps32x32.png", style: "top: -96px; left: -160px;position:relative;", tooltip: "Save Scenario", onclick: "dialogEvent('AnalyzerTab_SaveScen');" }
								]
							},
							{
							    items: [
									{ type: "bigbutton", id: "UndoBtn", name: "Undo", img: "formatmap32x32.png", style: "top: -416px; left: -96px;position:relative;", tooltip: "Undo", onclick: "dialogEvent('AnalyzerTab_UnDoDrag');", disabled: true }
								]
							},
                            {
                                items: [
		{ type: "bigbutton", id: "ChangePeriodBtn", name: "Change Analyzer<br/>Periods", img: "formatmap32x32.png", style: "top: -384px; left: 0px;position:relative;", tooltip: "Change Calendar", onclick: "dialogEvent('AnalyzerTab_ChangeCalendar');" }
								]
                            },
                            {
                                items: [
									{ type: "smallbutton", id: "chkAll", img: "Approve.gif", name: "Check All", tooltip: "Check all rows", onclick: "dialogEvent('AnalyzerTab_chkAll');" },
									{ type: "smallbutton", id: "chkNone", img: "Reject.gif", name: "Uncheck All", tooltip: "Uncheck all rows", onclick: "dialogEvent('AnalyzerTab_chkNone');" }
								]
                            }
						]
					},
					{
					    name: "Total Details",
					    tooltip: "Total Details",
					    columns: [
						   {
						       items: [
									{ type: "mediumtext", id: "chkCommit", name: "Show Committed Work", tooltip: "Show Committed Work", onclick: "dialogEvent('AnalyzerTab_chkCommit_Click');" },
									{ type: "mediumtext", id: "chkMSP", name: "Show Scheduled Work", tooltip: "Show Scheduled Work", onclick: "dialogEvent('AnalyzerTab_chkMSP_Click');" },
									{ type: "mediumtext", id: "chkActual", name: "Show Timesheet Actuals", tooltip: "Show Timesheet Actuals", onclick: "dialogEvent('AnalyzerTab_chkActual_Click');" }
								]

						   }]
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


	        var cbProp = { type: "mediumtext", id: "chkRequests", name: "Show Proposed Work", tooltip: "Show Proposed Work", onclick: "dialogEvent('AnalyzerTab_chkRequests_Click');" };
	        var cbReq = { type: "mediumtext", id: "chkOpenRequests", name: "Show Open Requirements", tooltip: "Show Open Requirements", onclick: "dialogEvent('AnalyzerTab_chkOpenRequests_Click');" };
	        var cbNW = { type: "mediumtext", id: "chkNonWork", name: "Show Personal Time Off", tooltip: "Show Personal Time Off", onclick: "dialogEvent('AnalyzerTab_chkNonWork_Click');" };



	        var sections = analyzerTabData.sections;
	        var columns = null;

	        for (var xi = 0; xi < sections.length - 1; xi++) {
	            if (sections[xi].name == "Total Details") {
	                columns = sections[xi].columns;
	                break;
	            }
	        }

	        if (columns != null) {
	            addedcol = 0;

	            if (negmode != "1") {
	                if (addedcol == 0) {
	                    columns[1] = new Object;
	                    columns[1].items = new Array;
	                }
	                columns[1].items[addedcol++] = cbProp;
	            }


	            if (showopen == "1") {
	                if (addedcol == 0) {
	                    columns[1] = new Object;
	                    columns[1].items = new Array;
	                }
	                columns[1].items[addedcol++] = cbReq;
	            }

	            if (showpersonal == "1") {
	                if (addedcol == 0) {
	                    columns[1] = new Object;
	                    columns[1].items = new Array;
	                }
	                columns[1].items[addedcol++] = cbNW;
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
					    columns: [
                             {
                                 items: [
									{ type: "bigbutton", name: "Close", img: "close32.gif", tooltip: "Close", onclick: "dialogEvent('AnalyzerTab_Close');" }
								]
                             },
							{
							    items: [
									{ type: "bigbutton", id: "idSaveScenario1", name: "Save<br/>Scenario", disabled: (this.fromresource == "1" ? false : true), img: "ps32x32.png", style: "top: -96px; left: -160px;position:relative;", tooltip: "Save Scenario", onclick: "dialogEvent('AnalyzerTab_SaveScen');" }
								]
							},
							{
							    items: [
									{ type: "bigbutton", id: "UndoBtn2", name: "Undo", img: "formatmap32x32.png", style: "top: -416px; left: -96px;position:relative;", tooltip: "Undo", onclick: "dialogEvent('AnalyzerTab_UnDoDrag');", disabled: true }
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
									{ type: "smallbutton", id: "idAnalyzerShowBars", name: "Show Bars", img: "ps16x16.png", style: "top: -192px; left: -16px;position:relative;", tooltip: "Show Bars", onclick: "dialogEvent('AnalyzerTab_ShowBars_Click');" },
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
									{ type: "text", name: "Displayed Values:"}]
							},
							{
							    items: [

									{ type: "select", id: "idAnalyzerTab_SelView", onchange: "dialogEvent('AnalyzerTab_SelView_Changed');", width: "100px" },
									{ type: "select", id: "idAnalyzerTab_SelMode", onchange: "dialogEvent('AnalyzerTab_SelMode_Changed');", width: "100px" }
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
									{ type: "text", name: "To Period:" }
								]
						   },
				           {
				               items: [
							        { type: "select", id: "idAnalyzerTab_FromPeriod", onchange: "dialogEvent('AnalyzerTab_FromPeriod_Changed');", width: "100px" },
									{ type: "select", id: "idAnalyzerTab_ToPeriod", onchange: "dialogEvent('AnalyzerTab_ToPeriod_Changed');", width: "100px" }
								]
				           }
						]
					   }
				]
	        };

	        var bbEditRes = { items: [{ type: "bigbutton", id: "idEditRes", name: "Edit Resource<br/>Plan", img: "formatmap32x32.png", style: "top: -352px; left: -288px;position:relative;", tooltip: "Plan", onclick: "dialogEvent('EditResPlan');"}] };
	        var bbEditRes1 = { items: [{ type: "bigbutton", id: "idEditRes1", name: "Edit Resource<br/>Plan", img: "formatmap32x32.png", style: "top: -352px; left: -288px;position:relative;", tooltip: "Plan", onclick: "dialogEvent('EditResPlan');"}] };

	        if (this.params.RPEMode != 1) {
	            sections = analyzerTabData.sections;

	            for (var xi = 0; xi < sections.length - 1; xi++) {
	                if (sections[xi].name == "Actions") {
	                    columns = sections[xi].columns;
	                    break;
	                }
	            }

	            columns[6] = columns[5];
	            columns[5] = columns[4];
	            columns[4] = columns[3];
	            columns[3] = columns[2];
	            columns[2] = bbEditRes;

	            sections = viewTabData.sections;

	            for (var xi = 0; xi < sections.length - 1; xi++) {
	                if (sections[xi].name == "Actions") {
	                    columns = sections[xi].columns;
	                    break;
	                }
	            }

	            columns[3] = columns[2];
	            columns[2] = columns[1];
	            columns[1] = bbEditRes1;

	        }

            
        this.ChartATDisableList.push("SaveBtn");
        this.ChartATDisableList.push("idSaveScenario");
        this.ChartATDisableList.push("UndoBtn");
        this.ChartATDisableList.push("ChangePeriodBtn");
        this.ChartATDisableList.push("chkAll");
        this.ChartATDisableList.push("chkNone");
        this.ChartATDisableList.push("idExportExcelTop");
        this.ChartATDisableList.push("idPrintTop");
        this.ChartATDisableList.push("idEditRes");

        this.ChartVTDisableList.push("idSaveScenario1");
        this.ChartVTDisableList.push("UndoBtn2");
        this.ChartVTDisableList.push("idEditRes1");
        this.ChartVTDisableList.push("SaveViewBtn");
        this.ChartVTDisableList.push("RenameViewBtn");
        this.ChartVTDisableList.push("DeleteViewBtn");
        this.ChartVTDisableList.push("idAnalyzerShowFilters");
        this.ChartVTDisableList.push("idAnalyzerShowGrouping");
        this.ChartVTDisableList.push("idViewTab_RemoveSorting");
        this.ChartVTDisableList.push("idAnalyzerShowBars");
        this.ChartVTDisableList.push("idAnalyzerHideDetails");
        this.ChartVTDisableList.push("SelectColumnsBtn");
        this.ChartVTDisableList.push("idAnalyzerExpandAll");
        this.ChartVTDisableList.push("idAnalyzerCollapsAll");
        this.ChartVTDisableList.push("idAnalyzerTab_SelView");
        this.ChartVTDisableList.push("idAnalyzerTab_SelMode");

        this.ChartBTDisableList.push("idTotCol");


       this.ChartBlockCommand.push("AnalyzerTab_SaveDrag");
       this.ChartBlockCommand.push("AnalyzerTab_SaveScen");
       this.ChartBlockCommand.push("AnalyzerTab_UnDoDrag");
       this.ChartBlockCommand.push("AnalyzerTab_ChangeCalendar");
       this.ChartBlockCommand.push("AnalyzerTab_chkAll");
       this.ChartBlockCommand.push("AnalyzerTab_chkNone");
       this.ChartBlockCommand.push("AnalyzerTab_ExporttoExcel");
       this.ChartBlockCommand.push("AnalyzerTab_Print");
       this.ChartBlockCommand.push("EditResPlan");


       this.ChartBlockCommand.push("AnalyzerTab_SaveView"); 
       this.ChartBlockCommand.push("AnalyzerTab_RenameView");
       this.ChartBlockCommand.push("AnalyzerTab_DeleteView");       
       this.ChartBlockCommand.push("AnalyzerTab_ShowFilters_Click");       
       this.ChartBlockCommand.push("AnalyzerTab_ShowGrouping_Click");       
       this.ChartBlockCommand.push("AnalyzerTab_RemoveSorting_Click");       
       this.ChartBlockCommand.push("AnalyzerTab_ShowBars_Click");       
       this.ChartBlockCommand.push("AnalyzerTab_HideDetails_Click");

       this.ChartBlockCommand.push("AnalyzerTab_SelectColumns");       
       this.ChartBlockCommand.push("AnalyzerTab_ExpandAll");
       this.ChartBlockCommand.push("AnalyzerTab_CollapseAll");

       this.ChartBlockCommand.push("AnalyzerTab_SelView_Changed");
       this.ChartBlockCommand.push("AnalyzerTab_SelMode_Changed");

       this.ChartBlockCommand.push("AnalyzerTab_CapScen");




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
									{ type: "mediumbutton", id: "idTotCol", name: "Capacity<br/> Scenarios", disabled: (this.fromresource == "1" ? false : true), img: "capscenariosl20x20.png", tooltip: "Capacity Scenarios", onclick: "dialogEvent('AnalyzerTab_CapScen');" }
								]
							},
							{
							    items: [
									{ type: "mediumbutton", id: "idGraph", name: "Show<br/>Graph", img: "ps16x16.png", style: "top: -128px; left: -80px;position:relative;", tooltip: "Show Graph", onclick: "dialogEvent('AnalyzerTab_ShowGraph');" }
								]
							},
							{
							    items: [
									{ type: "mediumbutton", id: "idBTSDet", name: "Show<br/>Details", img: "ps16x16.png", style: "top: -128px; left: -192px;position:relative;", tooltip: "Show Details", onclick: "dialogEvent('AnalyzerTab_ShowBottomDetails');" }
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

	        if (this.layout == null) {
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

	        }

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

	        if (this.UsingPeriods.CurrentPeriod == undefined) {
	            this.UsingPeriods.CurrentPeriod = new Object;
	            this.UsingPeriods.CurrentPeriod.Value = this.UsingPeriods.Period.length
	        }


	        for (var n1 = 0; n1 < this.UsingPeriods.Period.length; n1++) {
	            var per = this.UsingPeriods.Period[n1];
	            var perId = per.perID;
	            var perName = per.perName;

	            FromList.options[n1 + 1] = new Option(perName, perId, n1 == this.initDataStart, n1 == this.initDataStart);
	            ToList.options[n1] = new Option(perName, perId, n1 == this.initDataFinish, n1 == this.initDataFinish);

	            if (n1 == 0) {
                    if (this.initDataStart != -1)
	                    this.PerStart = perId;
                    else
                        this.PerStart = this.UsingPeriods.CurrentPeriod.Value;
                }

	            this.PerEnd = perId;

	        }

	        this.flashRibbonSelect('idAnalyzerTab_FromPeriod');
	        this.flashRibbonSelect('idAnalyzerTab_ToPeriod');

	        this.flashTotalsButtons();

	        this.Tabbar.setTabActive("tab_Display");


	        if (this.analyzerCalID != this.CmtCal || this.fromresource == "0") {

	            this.analyzerTab.disableItem("idSaveScenario");
	            this.viewTab.disableItem("idSaveScenario1");
	        }


	    }
	    catch (e) {
	        alert("ResPlanAnalyzer InitializeLayout Exception");
	    }
	}
    
    ResPlanAnalyzer.prototype.ShowWorkingPopup = function (divid) {
        //        var veil = document.getElementById("veil");
        //        veil.style.display = "block";
        var div = $('#' + divid);
        var win = $(window);
        div.css('top', (win.height() - div.height()) / 2);
        div.css('left', (win.width() - div.width()) / 2);
        div.show();
        var veil = $('#veil');
        veil.show();
    };
    
    ResPlanAnalyzer.prototype.HideWorkingPopup = function (divid) {
        var div = $('#' + divid);
        div.hide();
        var veil = $('#veil');
        veil.hide();
    };
    
	ResPlanAnalyzer.prototype.flashTotalsButtons = function () {
		
		try {
			if (this.DetailsData.ActualWork.Value == "1")
				this.analyzerTab.setButtonStateOn("chkActual");
			else {
				this.analyzerTab.setButtonStateOff("chkActual");
			}


			if (this.DetailsData.ProposedWork.Value == "1")
				this.analyzerTab.setButtonStateOn("chkRequests");
			else {
				this.analyzerTab.setButtonStateOff("chkRequests");
			}

			if (this.DetailsData.ScheduledWork.Value == "1")
				this.analyzerTab.setButtonStateOn("chkMSP");
			else {
				this.analyzerTab.setButtonStateOff("chkMSP");
			}

			if (this.DetailsData.CommittedWork.Value == "1")
				this.analyzerTab.setButtonStateOn("chkCommit");
			else {
				this.analyzerTab.setButtonStateOff("chkCommit");
			}

			if (this.DetailsData.PersonalWork.Value == "1")
				this.analyzerTab.setButtonStateOn("chkNonWork");
			else {
				this.analyzerTab.setButtonStateOff("chkNonWork");
			}

			if (this.DetailsData.OpenRequestWork.Value == "1")
				this.analyzerTab.setButtonStateOn("chkOpenRequest");
			else {
				this.analyzerTab.setButtonStateOff("chkOpenRequest");
			}
		}
		catch(e) {}
	}


	ResPlanAnalyzer.prototype.LoadResPlanDataComplete = function (result) {
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


				this.TargetData = jsonObject.Result.Targets;
				var views = jsonObject.Result.Views;
				this.Views = JSON_GetArray(views, "View");

				this.TotalsData = jsonObject.Result.TotalsConfiguration.TotalsConfiguration;

				this.fromresource = jsonObject.Result.FromResGrid.Value;
				this.allowcsmode = jsonObject.Result.AllowCSResMode.Value;

                

				this.TotalsColumnSettings = jsonObject.Result.TotalsConfiguration.Value;

				this.DetailsSettings = jsonObject.Result.DetailsConfiguration.Value;
				this.DetailsData = jsonObject.Result.DetailsConfiguration.WorkDetails;

				this.DisplayMode = jsonObject.Result.DisplayMode.Value;
				this.PMOAdmin = jsonObject.Result.gpPMOAdmin.Value;

				var LoadingDataReply = jsonObject.Result.LoadingDataReply;

				this.ticketvalue = jsonObject.Result.TicketValue.Value;
				this.ticketreturns = jsonObject.Result.TicketReturns.Value;

				this.loadedDataCount = jsonObject.Result.DetailsLoaded.Value;

				try {
					this.initDataStart = parseInt(jsonObject.Result.PeriodRange.Start);
					this.initDataFinish = parseInt(jsonObject.Result.PeriodRange.Finish);
				}
				catch (e) {

				}

				this.heatmapText = "";

				try {
				    this.heatmapText = jsonObject.Result.HeatMapText.Value;
				    this.NegMode = (jsonObject.Result.NegMode.Value == "1");
				}
	            catch (e) { }



				if (LoadingDataReply.Value !== "")
					alert(LoadingDataReply.Value);

				this.InitializeLayout();

				window.setTimeout(HandlePopulateUI, 200);



				this.PingSessionData();
			}
		}
		catch (e) {
			this.HandleException("LoadResPlanDataComplete", e);
			if (parent.SP.UI.DialogResult)
				parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
			else
				parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');

		}
	}


	ResPlanAnalyzer.prototype.GridsOnMouseDown = function (grid, row, col, x, y, event) {
		 return false;
	}


	ResPlanAnalyzer.prototype.GridsOnMouseOver = function (grid, row, col, orow, ocol, event) {
//        if (row == null)
//            return;

//        if (col == null)
//            return;

//        if (row.Kind != "Header")
//            return;


//        var bMove = grid.GetAttribute(row, col, "CanMove");

//        if (bMove != "0")
//            return;

//        event.explicitOriginalTarget.style.cursor = "default";





	}


	ResPlanAnalyzer.prototype.GridsOnRenderStart = function (grid) {
		if (grid.id == "bottomg_1")
			this.refreshIconsInTotGrid = null;

		return false;
	}
	ResPlanAnalyzer.prototype.GridsOnRenderFinish = function (grid) {
		if (grid.id == "bottomg_1") {
			this.TotGrid = grid;
			if (this.refreshIconsInTotGrid != null)
				window.setTimeout(HandleRerenderDelegate, 400);
		}
	}


	ResPlanAnalyzer.prototype.HandleRerender = function () {

		if (this.refreshIconsInTotGrid != null) {
			for (var i = 0; i < this.refreshIconsInTotGrid.length; i++) {
				this.TotGrid.RefreshCell(this.refreshIconsInTotGrid[i], "IconFlag");
			}
			this.refreshIconsInTotGrid = null;
		}

	}


	ResPlanAnalyzer.prototype.PopulateUI = function () {

		try {
			this.selectedView = null;
			var select = document.getElementById("idAnalyzerTab_SelMode");

			this.SelectedMode = 1;
			select.options.length = 0;
			select.options[0] = new Option("Hours", 1, true, true);
			select.options[1] = new Option("FTE", 2, false, false);
			select.options[2] = new Option("FTE Percent", 3, false, false);
			select.options[3] = new Option("FTE Conversion", 4, false, false);


			var selectedItem = select.options[select.selectedIndex];

			this.flashRibbonSelect("idAnalyzerTab_SelMode");

			this.TotalGroupingchecked = false;
			this.TotalFilterschecked = false;


			this.AnalyzerFilterschecked = false;
			this.AnalyzeGroupingchecked = false;


			var selectviews = document.getElementById("idAnalyzerTab_SelView");
			selectviews.options.length = 0;
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
			this.bapplyDefView = true;   // this stops the autoselection next time through this code if there was no default view previously defined

			this.SetViewChanged(null);


			if (this.selectedView != null)
				WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("ApplyResourceAnalyzerViewServerSideSettings", this.selectedView.ViewGUID, this.CreateTopGridDelegate);
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

	ResPlanAnalyzer.prototype.CreateTopGrid = function (jsonString) {

	    try {

	        if (jsonString == undefined || jsonString == "") {
	            this.TotalsGridSettingsData = null;

	            this.TotalsGridSupressHeatmap = 0;
	        }
	        else {

	            var jsonObject = JSON_ConvertString(jsonString);
	            if (JSON_ValidateServerResult(jsonObject)) {
	                this.TotalsGridSettingsData = jsonObject.Result.ViewData.TotalsGridSetting;

	                this.TotalsGridSupressHeatmap = this.TotalsGridSettingsData.HeatMap.HeapMapSubCol;
	                this.TotalsGridTotalsCol = this.TotalsGridSettingsData.HeatMap.HeapMapTotalsCol;

                    var bdstate = jsonObject.Result.ViewData.BottomDetailsState.Value;

                    this.showingTotDet = (bdstate == "1")
	                if (this.showingTotDet == true) {

	                        this.totTab.setButtonStateOn("idBTSDet");

                    }
	                else {
                            
	                    this.totTab.setButtonStateOff("idBTSDet");
 	                }

                        
	                this.heatmapText = "";

	                try {
	                    this.heatmapText = this.TotalsGridSettingsData.HeatMap.HeatMapText;
	                }
	                catch (e) { }

	                this.DetailsData = jsonObject.Result.ViewData.WorkDetails;   // the next two lines are needed to flash the proper state of the totals buttons on the top grid 
	                this.flashTotalsButtons()

	                document.getElementById("idTotCompVal").innerHTML = this.heatmapText;

	                var wmode = jsonObject.Result.ViewData.WorkDisplayMode.Mode;

	                var wsel = document.getElementById("idAnalyzerTab_SelMode");
	                wsel.selectedIndex = wmode - 1;

	                this.flashRibbonSelect("idAnalyzerTab_SelMode");



	            }
	        }

	        this.stashgridsettings = null;
	        var sbDataxml = new StringBuilder();
	        sbDataxml.append('<![CDATA[');
	        sbDataxml.append('<Execute Function="GetResourceAnalyzerData">');
	        sbDataxml.append('</Execute>');
	        sbDataxml.append(']]>');

	        var sb = new StringBuilder();
	        sb.append("<treegrid SuppressMessage='3' debug='0' sync='0' ");
	        sb.append(" Export_Url='rpaExportExcel.aspx'");
	        sb.append(" data_url='" + this.Webservice + "'");
	        sb.append(" data_method='Soap'");
	        sb.append(" data_function='Execute'")
	        sb.append(" data_namespace='WorkEnginePPM'");
	        sb.append(" data_param_Function='GetResourceAnalyzerData'");
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


	// >>>>>>>>>>>  Grid event handlers

	ResPlanAnalyzer.prototype.GridsOnValueChanged = function (grid, row, col, val) {
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

	ResPlanAnalyzer.prototype.GridsOnAfterValueChanged = function (Grid, Row, Col, value) {

		if (Grid.id == "g_1" && Col == "Select") {
			var sb = new StringBuilder();
			sb.append("<Rows ");
			sb.append(" value='" + value + "'>");

			HandleClick(Grid, Row, Col, value, sb);

			sb.append("</Rows>");

	 //       alert(sb.toString());

			WorkEnginePPM.ResPlanAnalyzer.Execute("SetRADetailsSelectedFlag", sb.toString());
			this.bottomgriddragstash = this.BuildViewInf("guid", "name", false, false, true);
			RefreshBottomGrid();
			return;
        }

        if (Grid.id == "bottomg_1" && Col == "rtSelect") {
            var sb = new StringBuilder();
            sb.append("<Rows ");
            sb.append(" value='" + value + "'>");

            this.HandleBottomClick(Grid, Row, Col, value, sb);

            sb.append("</Rows>");

            //       alert(sb.toString());

            WorkEnginePPM.ResPlanAnalyzer.Execute("SetRATotalSelectedFlag", sb.toString());

            if (this.showingGraph == true) {
                this.createChart();
            }

            return;
        }
	}

	ResPlanAnalyzer.prototype.GridsOnClickCell = function (grid, row, col) {

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
	        this.csrow = row;

            if (this.dlgSpreadDlg != null) {
	            var itemName = this.EditGrid.GetString(this.csrow, "CostCategory");
	            this.dlgSpreadDlg.window("winSpreadDlg").setText("Allocate " + (this.CSHourMode ? "Hours" : "FTEs") + " to " + itemName);
            }
	    }
	}

	ResPlanAnalyzer.prototype.GetGridRow = function (Grid, row) {
		try {
			return Grid.Rows[row];

		}
		catch (e) {
			return null;
		}

    }

    ResPlanAnalyzer.prototype.CheckIfRowFiltered = function (grid, row) {
        try {
            var i = this.FilteredTop.length;
            var rowid = grid.GetString(row, "rowid");

            for (var j = 0; j < i; j++) {
                if (this.FilteredTop[j] == rowid)
                    return false;
            }

            return true;

        }
        catch (e) {
            return true;
        }

    }


    ResPlanAnalyzer.prototype.GridsOnFilterFinish = function (Grid) {

	    if (Grid.id == "g_1") {

	        this.FilteredTop = new Array();
	        var fcnt = 0;

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

	                    if (rowid != "" && arow.Visible == false) {
	                        this.FilteredTop[fcnt] = rowid;
	                        ++fcnt;
	                        sb.append("<Row rowid='" + rowid + "'/>");
	                    }
	                }
	            }
	        }

	        sb.append("</FilteredRows>");

	        if (this.LastFilterString != sb.toString())
	            WorkEnginePPM.ResPlanAnalyzer.Execute("SetRADetailsFilteredFlag", sb.toString(), HandleRefreshDelegate);

	        this.LastFilterString = sb.toString();

	        return;
	    }
	}


	ResPlanAnalyzer.prototype.GetSelectedView = function () {
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



	ResPlanAnalyzer.prototype.AnalyzerViewDlg_OnClose = function () {
		this.AnalyzerViewDlg.window("winAnalyzerViewDlg").detachObject()
		this.AnalyzerViewDlg = null;
	}


	ResPlanAnalyzer.prototype.AnalyzerDeleteViewDlg_OnClose = function () {
		this.AnalyzerDeleteViewDlg.window("winAnalyzerDeleteViewDlg").detachObject()
		this.AnalyzerDeleteViewDlg = null;
	}

	ResPlanAnalyzer.prototype.DeleteResourceAnalyzerViewComplete = function (jsonString) {
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


	ResPlanAnalyzer.prototype.GridsOnReady = function (grid, start) {
	    try {

	        if (grid.id == "g_1")
	            this.topgridready = true;

	        if (grid.id == "bottomg_1") {
	            WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("GetTotalsGridChartData", "", GetTotalsGridChartDataCompleteDelegate);


	            if (this.bottomgridfirstready == false) {
	                this.HideWorkingPopup("divLoading");
	                bottomgridfirstready = true;
	            }

	            this.topgridready = true;
	            this.bottomgridready = true;
	        }

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



	        if (grid.id == "g_1") {
	            if (this.TotGrid == null) {

	                if (this.AnalyzerFilterschecked == true) {
	                    this.showFilters(grid, false);
	                } else {
	                    this.hideFilters(grid, false);
	                }

	                if (this.AnalyzeGroupingchecked == true) {
	                    this.showGrouping(grid);
	                } else {
	                    this.hideGrouping(grid);
	                }

	                var sbDataxml = new StringBuilder();

	                sbDataxml = new StringBuilder();
	                sbDataxml.append('<![CDATA[');
	                sbDataxml.append('<Execute Function="GetResourceAnalyzerTotals">');
	                sbDataxml.append('</Execute>');
	                sbDataxml.append(']]>');

	                sb = new StringBuilder();
	                sb.append("<treegrid SuppressMessage='3' debug='0' sync='0' ");
	                sb.append(" Export_Url='rpaExportExcel.aspx'");
	                sb.append(" data_url='" + this.Webservice + "'");
	                sb.append(" data_method='Soap'");
	                sb.append(" data_function='Execute'")
	                sb.append(" data_namespace='WorkEnginePPM'");
	                sb.append(" data_param_Function='GetResourceAnalyzerTotals'");
	                sb.append(" data_param_Dataxml='" + sbDataxml.toString() + "'");
	                sb.append(" >");
	                sb.append("</treegrid>");


	                this.TotGrid = TreeGrid(sb.toString(), "gridDiv_Totals", "bottomg_1");

	                this.initialized = true;
	                this.OnResize();


	            }

	            if (this.selectedView != null && this.doTopApply == true)
	                this.ApplyGridView(grid.id, this.selectedView, true);



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

	            this.doBottomApply = false;

	            if (this.TotalFilterschecked == true) {
	                this.showFilters(grid, false);
	            } else {
	                this.hideFilters(grid, false);
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

    var AllBottomLeavesChecked = function (Grid, Row) {
        var children;
        children = Row.firstChild;

        if (children == null) {
            var rowck = Grid.GetString(Row, "rtSelect");
            if (rowck == "0")
                return false;

        }

        while (children != null) {
            if (Grid.GetAttribute(children, "rtSelect", "CanEdit") == "0") {

                var rowck = Grid.GetString(Row, "rtSelect");
                if (rowck == "0")
                    return false;

                return true;
            }

            if (AllBottomLeavesChecked(Grid, children) == false)
                return false;

            children = children.nextSibling;
        }

        return true;
    }

	ResPlanAnalyzer.prototype.HandleRerenderChecks = function () {

	    if (this.refreshChecksInDetGrid != null) {
	        for (var i = 0; i < this.refreshChecksInDetGrid.length; i++) {
	            this.DetGrid.RefreshCell(this.refreshChecksInDetGrid[i], "Select");
	        }
	        this.refreshChecksInDetGrid = null;
	    }

	    if (this.refreshBottomChecksInDetGrid != null) {
	        for (var i = 0; i < this.refreshBottomChecksInDetGrid.length; i++) {
	            this.TotGrid.RefreshCell(this.refreshBottomChecksInDetGrid[i], "rtSelect");
	        }
	        this.refreshBottomChecksInDetGrid = null;
	    }

	}


	ResPlanAnalyzer.prototype.HandleRerenderRollups = function () {
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

	ResPlanAnalyzer.prototype.CheckLeafValuesareSame = function (grid, row, col) {

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

	ResPlanAnalyzer.prototype.GridsOnGetDefaultColor = function (grid, row, col, r, g, b) {
	    if (grid.id == "et_1") {

	        if (this.EditGrid.GetAttribute(row, col, "CanEdit") == "0")
	            return 0xDADCDD;

	        return null;

	    }

	    if (grid.id == "g_1") {

	        if (row.id == "Filter")
	            return null;

	        if (row.Kind == "Data") {

	            if (col == "Select") {
	                var xfp = grid.GetValue(row, "xinterenalPeriodMin");
	                var xlp = grid.GetValue(row, "xinterenalPeriodMax");
	                var xtp = this.UsingPeriods.Period.length;   //  grid.GetValue(row, "xinterenalPeriodTotal");
	                var xas = "";

	                var cv = grid.GetValue(row, "P1C1HtmlPrefix");

	                if (this.AnalyzerShowBarschecked == false) {
	                    if (cv != "") {

	                        for (var xi = 1; xi <= xtp; ++xi) {
	                            xas = "P" + xi.toString() + "C1";
	                            grid.SetString(row, xas + "HtmlPrefix", "", 1);
	                            grid.SetString(row, xas + "HtmlPostfix", "", 1);
	                            grid.SetString(row, xas + "ClassInner", "", 1);
	                        }
	                    }
	                }
	                else {
	                    if (cv == "") {
	                        if (xfp != 0) {

	                            for (var xi = 1; xi < xfp; ++xi) {
	                                xas = "P" + xi.toString() + "C1";
	                                grid.SetString(row, xas + "HtmlPrefix", "<font color='black'>", 1);
	                                grid.SetString(row, xas + "HtmlPostfix", "</font>", 1);
	                                //	                            grid.SetString(row, xas + "ClassInner", "", 1);
	                            }


	                            for (var xi = xfp; xi <= xlp; ++xi) {

	                                xas = "P" + xi.toString() + "C1";


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

	                            for (var xi = xlp + 1; xi <= xtp; ++xi) {
	                                xas = "P" + xi.toString() + "C1";
	                                grid.SetString(row, xas + "HtmlPrefix", "<font color='black'>", 1);
	                                grid.SetString(row, xas + "HtmlPostfix", "</font>", 1);
	                                //	                            grid.SetString(row, xas + "ClassInner", "", 1);
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

	                    //var cls = grid.GetAttribute(row, col, "ClassInner");
	                    //        grid.SetAttribute(row, col, "ClassInner", "GMngBodyRight", 1);



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


	    if (col == "rtSelect") {

	        var bAll = AllBottomLeavesChecked(grid, row);

	        var rowck = grid.GetString(row, "rtSelect");
	        var newck = (bAll == true ? "1" : "0");

	        if (rowck != newck) {
	            grid.SetAttribute(row, col, null, newck, 1);


	            if (this.refreshBottomChecksInDetGrid == null) {
	                this.refreshBottomChecksInDetGrid = new Array();
	                window.setTimeout(HandleRerenderChecksDelegate, 400);
	            }

	            this.refreshBottomChecksInDetGrid[this.refreshBottomChecksInDetGrid.length] = row;
	            //grid.RefreshCell(row, "Select");
	        }
	    }


	    if (row.firstChild == null || row.id == "Filter")
	        return null;

	    if (col == "RowSel")
	        return null;

	    if (col === "PortfolioItem") 
            return 0xFFFFFF;

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

	            grid.SetAttribute(row, col, "ExportStyle", 'background-color: ' + retval, false, false);
	            return retval;
	        }
	        else
	            return 0xFFFFFF;

	    }

	    return this.groupColour;

	}

	ResPlanAnalyzer.prototype.TargetBackground = function (Tdbl, Pdbl) {

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


	ResPlanAnalyzer.prototype.GridsOnStartDragCell = function (grid, row, col, shtml) {

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

	ResPlanAnalyzer.prototype.GridsOnMoveDragCell = function (grid, row, pcol, togrid, torow, tocol, x, y) {

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
	ResPlanAnalyzer.prototype.GridsOnEndDragCell = function (grid, row, col, togrid, torow, tocol, x, y) {

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


	    if (this.NegMode == true) {
	        if (this.NegWarn == false) {
	            this.NegWarn = true;
	            alert("Due to Negotiation Mode being enabled it will not be possible to publish any of the changes you make");
	        }

	    } else {
	        this.SaveBtn = true;


	        this.analyzerTab.enableItem("SaveBtn");
	        this.viewTab.enableItem("SaveBtn2");
	    }

	    this.UnDoBtn = true; RefreshBottomGrid
	    this.analyzerTab.enableItem("UndoBtn");
	    this.viewTab.enableItem("UndoBtn2");



	    this.dragStack.push(this.currDrag);

	    this.bottomgriddragstash = this.BuildViewInf("guid", "name", false, false, true);

	    this.TopGridDragged = true;
	    WorkEnginePPM.ResPlanAnalyzer.Execute("SetRADragRows", sb.toString(), HandleRefreshDelegate);

	}

	ResPlanAnalyzer.prototype.TabDoChecks = function (iMode) {
	    var Grid = this.DetGrid;

	    var arows = Grid.Rows;


	    for (var i in arows) {



	        var Row = arows[i];

            if (Row.Kind == "Data")
	            Grid.SetString(Row, "Select", iMode, 1);

        }


        this.bottomgriddragstash = this.BuildViewInf("guid", "name", false, false, true);

        WorkEnginePPM.ResPlanAnalyzer.Execute("SetAllCheckMarks", iMode.toString(), RefreshBottomGrid);

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

	ResPlanAnalyzer.prototype.HandleBottomClick = function (Grid, Row, Col, value, sb) {
	    var children;

	    Row.Changed = 1;
	    Grid.SetString(Row, Col, value, 1);
	    children = Row.firstChild;

        if (children != null) {
            if (Grid.GetAttribute(children, "rtSelect", "CanEdit") == "0") 
                children = null;
        }


	    if (children == null) {
	        var rowid = Grid.GetString(Row, "rowid");
	        sb.append("<Row rowid='" + rowid + "'/>");

	        if (this.ChartRawData != null) {
	            for (var i = 0; i < this.ChartRawData.length; i++) {
	                if (this.ChartRawData[i].ID == rowid) {
	                    this.ChartRawData[i].Sel = value;
	                    break;
	                }
	            }



	        }

	    }

	    while (children != null) {
	        this.HandleBottomClick(Grid, children, Col, value, sb);
	        children = children.nextSibling;
	    }
	}


	ResPlanAnalyzer.prototype.CaptureDragRow = function (Grid, Row) {
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

	ResPlanAnalyzer.prototype.ResetDragRow = function (Grid, rows) {

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
//				cval = rows[j].bcData[i];
//				Grid.SetString(trow, tCol, cval, 1);
			}
		}
	}


	ResPlanAnalyzer.prototype.HandleDragRow = function (Grid, Row, fromCol, toCol, sb) {
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

						var iRfp =   Grid.GetString(Row, "xinterenalPeriodMin");
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

	ResPlanAnalyzer.prototype.HandleRefresh = function () {

	    try {

	        if (this.TopGridDragged == true) {
	            this.TopGridDragged = false;

	            if (this.DetGrid != null)
	                this.DetGrid.Render();
	        }

	        if (this.TotGrid != null) {
	            this.TotGrid.Reload(null);
	        }

	    }
	    catch (e) {

	    }

	}


	var RefreshTopGrid = function () {

		try {


			window.setTimeout(HandleRefreshTopDelegate, 700);
		}

		catch (e) {
		}
	}

	ResPlanAnalyzer.prototype.HandleTopRefresh = function () {

		try {
			if (this.DetGrid != null) {

				this.DetGrid.Reload(null);
			}

		}
		catch (e) {

		}

    }


    ResPlanAnalyzer.prototype.GetTotalsGridChartDataComplete = function (jsonString) {
        try {

            if (jsonString != "") {
                var jsonObject = JSON_ConvertString(jsonString);
                if (JSON_ValidateServerResult(jsonObject)) {

                    this.ChartRawData = JSON_GetArray(jsonObject.Result.Rows, "Row");

                    for (var i = 0; i < this.ChartRawData.length; i++) {
                        var rw = this.ChartRawData[i];

                        var xavail = new Array();
                        var xtot = new Array();

                        for (var xi = 0; xi < rw.Tot.length; xi++) {
                            xavail[xi] = rw.Avail[xi].Value;
                            xtot[xi] = rw.Tot[xi].Value;

                        }

                        rw.Avail = xavail;
                        rw.Tot = xtot;

                    }

                    if (this.showingGraph == true) {
                        this.createChart();
                    }


                }
            }
        }

        catch (e) {

        }

    }

    ResPlanAnalyzer.prototype.PopulateCSDeptList = function (defdept)
    {
          var DeptList = document.getElementById("idNewCSDept");
          DeptList.options.length = 0;
          for (var n = 0; n < this.CSDepts.length; n++) 
          {
	                var dp = this.CSDepts[n];
	                var Id = dp.DEPTUID;
	                var Name = dp.DEPTNAME;
	                DeptList.options[n] = new Option(Name, Id, Id == defdept, Id == defdept);
	      }
      }

	  ResPlanAnalyzer.prototype.GetCapacityScenarioListComplete = function (jsonString) {

		try {

			if (jsonString != "") {
				var jsonObject = JSON_ConvertString(jsonString);
				if (JSON_ValidateServerResult(jsonObject)) {
				    this.CapacityScenarios = jsonObject.Result.CapacityScenarios;

				    this.CSDepts = JSON_GetArray(jsonObject.Result.CSDepts, "CSDept");
				}
			}



			if (this.CapScenDlg == null) {
				this.CapScenDlg = new dhtmlXWindows();
				this.CapScenDlg.setSkin("dhx_web");
				this.CapScenDlg.enableAutoViewport(false);
				this.CapScenDlg.attachViewportTo(this.params.ClientID + "mainDiv");
				this.CapScenDlg.setImagePath("/_layouts/ppm/images/");
				this.CapScenDlg.createWindow("winCapScenDlg", 20, 30, 330, 247);
				this.CapScenDlg.window("winCapScenDlg").setIcon("logo.ico", "logo.ico");
				this.CapScenDlg.window("winCapScenDlg").denyResize();
				this.CapScenDlg.window("winCapScenDlg").button("park").hide();
				this.CapScenDlg.window("winCapScenDlg").setModal(true);
				this.CapScenDlg.window("winCapScenDlg").center();
				this.CapScenDlg.window("winCapScenDlg").setText("Capacity Scenarios");
				this.CapScenDlg.window("winCapScenDlg").attachEvent("onClose", function (win) { CapScenDlg_OnCloseDelegate(); return true; });
				this.CapScenDlg.window("winCapScenDlg").attachObject("idCapScenDlg");



				var select = document.getElementById("idSelectCapScen");
				select.options.length = 0;


				if (this.CapacityScenarios == undefined || this.CapacityScenarios == null)
					return;

				this.csCalID = parseInt(this.CapacityScenarios.CB_ID);

				this.CapScens = JSON_GetArray(this.CapacityScenarios, "CapacityScenario");


				if (this.CapScens == undefined || this.CapScens == null)
					return;

				var bNotfound = true;


				for (var i = 0; i < this.CapScens.length; i++) {
					select.options[i] = new Option(this.CapScens[i].Name, this.CapScens[i].ID, this.SelectedCapScen == this.CapScens[i].ID, this.SelectedCapScen == this.CapScens[i].ID);

					if (this.SelectedCapScen == this.CapScens[i].ID)
						bNotfound = false;
				}


				this.idCapScenEdit_disabled = bNotfound;
				this.idCapScenCopy_disabled = bNotfound;
				this.idCapScenDel_disabled = bNotfound;

				this.setNewButtonDisable('idCapScenCopy', this.idCapScenCopy_disabled);
				this.setNewButtonDisable('idCapScenEdit', this.idCapScenEdit_disabled);
				this.setNewButtonDisable('idCapScenDel', this.idCapScenDel_disabled);


			}
			else {
				this.CapScenDlg.window("winCapScenDlg").show();
			}

		}
		catch (e) {
			this.HandleException("GetCapacityScenarioList", e);
		}
	}

	ResPlanAnalyzer.prototype.SaveCapacityScenarioListComplete = function (jsonString) {

	    try {

	        if (jsonString != "") {
	            var jsonObject = JSON_ConvertString(jsonString);
	            if (JSON_ValidateServerResult(jsonObject)) {
	                this.CapacityScenarios = jsonObject.Result.CapacityScenarios;
	            }
	        }



	        if (this.SaveScenDlg == null) {
	            this.SaveScenDlg = new dhtmlXWindows();
	            this.SaveScenDlg.setSkin("dhx_web");
	            this.SaveScenDlg.enableAutoViewport(false);
	            this.SaveScenDlg.attachViewportTo(this.params.ClientID + "mainDiv");
	            this.SaveScenDlg.setImagePath("/_layouts/ppm/images/");
	            this.SaveScenDlg.createWindow("winSaveScenDlg", 20, 30, 300, 300);
	            this.SaveScenDlg.window("winSaveScenDlg").setIcon("logo.ico", "logo.ico");
	            this.SaveScenDlg.window("winSaveScenDlg").denyResize();
	            this.SaveScenDlg.window("winSaveScenDlg").button("park").hide();
	            this.SaveScenDlg.window("winSaveScenDlg").setModal(true);
	            this.SaveScenDlg.window("winSaveScenDlg").center();
	            this.SaveScenDlg.window("winSaveScenDlg").setText("Save Scenario");
	            this.SaveScenDlg.window("winSaveScenDlg").attachEvent("onClose", function (win) { CapScenDlg_OnCloseDelegate(); return true; });
	            this.SaveScenDlg.window("winSaveScenDlg").attachObject("idSaveScenDlg");



	            var select = document.getElementById("idSaveScenSel");
	            select.options.length = 0;


	            document.getElementById("idSaveScenText").value = "";

	            if (this.CapacityScenarios == undefined || this.CapacityScenarios == null)
	                return;

	            this.csCalID = parseInt(this.CapacityScenarios.CB_ID);

	            this.CapScens = JSON_GetArray(this.CapacityScenarios, "CapacityScenario");


	            if (this.CapScens == undefined || this.CapScens == null)
	                return;

	            var bNotfound = true;


	            for (var i = 0; i < this.CapScens.length; i++) {
	                select.options[i] = new Option(this.CapScens[i].Name, this.CapScens[i].ID, this.SelectedCapScen == this.CapScens[i].ID, this.SelectedCapScen == this.CapScens[i].ID);

	                if (this.SelectedCapScen == this.CapScens[i].ID)
	                    bNotfound = false;
	            }


	        }
	        else {
	            this.SaveScenDlg.window("winSaveScenDlg").show();
	        }

	    }
	    catch (e) {
	        this.HandleException("SaveCapacityScenarioList", e);
	    }
	}

	ResPlanAnalyzer.prototype.CapScenDlg_OnClose = function () {

		if (this.SaveScenDlg != null) {
			this.SaveScenDlg.window("winSaveScenDlg").detachObject();
			this.SaveScenDlg = null;
		}


		if (this.CapScenDlg != null) {
			this.CapScenDlg.window("winCapScenDlg").detachObject();
			this.CapScenDlg = null;
		}
	}


	ResPlanAnalyzer.prototype.GoDoEdit = function () {

	    try {

	        var csname = this.SelectedCapScenText;
	        var csid = this.SelectedCapScen;

	        var rolemode = 0;

	        if (this.SelCapScen == null)
	            rolemode = document.getElementById("chkRoleBased").checked;
	        else
	            rolemode = (this.SelCapScen.RMODE == 1);


	        sbDataxml = new StringBuilder();
	        sbDataxml.append('<CSPARAM');
	        sbDataxml.append(' ID="' + csid + '"');
	        sbDataxml.append(' MODE="' + (rolemode ? '1' : '0') + '" />');

	        this.RoleMode = (rolemode ? 1 : 0);

	        var parms = sbDataxml.toString();

	        if (this.dlgEditTarget == null) {
	            this.dlgEditTarget = new dhtmlXWindows();
	            this.dlgEditTarget.setSkin("dhx_web");
	            this.dlgEditTarget.enableAutoViewport(false);
	            this.dlgEditTarget.attachViewportTo(this.clientID + "mainDiv");
	            this.dlgEditTarget.setImagePath(this.imagePath);

	            if (this.Width == 0) {
	                this.Width = this.layout.cells(this.mainRibbonArea).getWidth();
	                this.Height = this.layout.cells(this.mainRibbonArea).getHeight() + this.layout.cells(this.mainArea).getHeight() + this.layout.cells(this.totalsArea).getHeight();
	            }

	            this.dlgEditTarget.createWindow("winEditTargetDlg", 0, 0, this.Width, this.Height - 10);

	            //	this.dlgEditTarget.createWindow("winEditTargetDlg", 20, 30, 655, 555);

	            this.dlgEditTarget.window("winEditTargetDlg").setIcon("logo.ico", "logo.ico");
	            this.dlgEditTarget.window("winEditTargetDlg").allowMove();
	            this.dlgEditTarget.window("winEditTargetDlg").allowResize();
	            this.dlgEditTarget.window("winEditTargetDlg").setModal(true);

	            this.dlgEditTarget.window("winEditTargetDlg").showHeader();
	            this.dlgEditTarget.window("winEditTargetDlg").progressOn();
	            this.dlgEditTarget.window("winEditTargetDlg").center();


	            this.dlgEditTarget.window("winEditTargetDlg").setText("Edit Capacity Scenario : " + csname);
	            this.dlgEditTarget.window("winEditTargetDlg").attachObject("idEditCapScenDlg");
	            this.dlgEditTarget.window("winEditTargetDlg").button("close").disable();
	            this.dlgEditTarget.window("winEditTargetDlg").button("park").hide();

	            this.EditCSid = this.EditCapScen;
	            this.EditName = csname;

	            WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("GetCapacityScenarioData", parms, GetEditCSDataCompleteDelegate);

	        }
	        else
	            this.dlgEditTarget.window("winEditTargetDlg").show();
	    }

	    catch (e) {
	        alert("GoDoEdit");
	    }

	}

	ResPlanAnalyzer.prototype.GoDoChart = function () {

	    try {


	        if (this.dlgChart == null) {
	            this.dlgChart = new dhtmlXWindows();
	            this.dlgChart.setSkin("dhx_web");
	            this.dlgChart.enableAutoViewport(false);
	            this.dlgChart.attachViewportTo(this.clientID + "mainDiv");
	            this.dlgChart.setImagePath(this.imagePath);

	            if (this.Width == 0) {
	                this.Width = this.layout.cells(this.mainRibbonArea).getWidth();
	                this.Height = this.layout.cells(this.mainRibbonArea).getHeight() + this.layout.cells(this.mainArea).getHeight() + this.layout.cells(this.totalsArea).getHeight();
	            }

	            this.dlgChart.createWindow("winChartDlg", 0, 0, this.Width, this.Height - 10);


	            this.dlgChart.window("winChartDlg").setIcon("logo.ico", "logo.ico");
	            this.dlgChart.window("winChartDlg").allowMove();
	            this.dlgChart.window("winChartDlg").allowResize();
	            this.dlgChart.window("winChartDlg").setModal(true);

	            this.dlgChart.window("winChartDlg").showHeader();
	            this.dlgChart.window("winChartDlg").progressOn();
	            this.dlgChart.window("winChartDlg").center();


	            this.dlgChart.window("winChartDlg").setText("Availability Chart");
	            this.dlgChart.window("winChartDlg").attachObject("idChartDlg");
	            this.dlgChart.window("winChartDlg").button("close").disable();
	            this.dlgChart.window("winChartDlg").button("park").hide();

	            var ChRibonData = {
	                parent: "ribbonbarChartDiv",
	                style: "display:none;",
	                imagePath: this.imagePath,
	                showstate: "false",
	                sections: [
					 { name: "General",
					     columns: [
							{
							    items: [
									{ type: "bigbutton", name: "Close", img: "close32.gif", tooltip: "Close", onclick: "dialogEvent('Chart_Close');" }
								]
							}
						]
					 }

				   ]
	            };

	            if (this.layout_Chart == null) {
	                this.layout_Chart = new dhtmlXLayoutObject("idChart", "2E", "dhx_skyblue");

	                this.layout_Chart.cells(this.totalsRibbonArea).setText("Ribbon");
	                this.layout_Chart.cells(this.totalsGridArea).setText("Grid Area");
	                this.layout_Chart.cells(this.totalsRibbonArea).hideHeader();
	                this.layout_Chart.cells(this.totalsGridArea).hideHeader();
	                //this.layout_CS.cells(this.totalsGridArea).setHeight(this.Height - 110);
	                this.layout_Chart.cells(this.totalsRibbonArea).setHeight(92);
	                this.layout_Chart.cells(this.totalsRibbonArea).fixSize(false, true);



	                var parentObj = document.getElementById("idChart");
	                parentObj.style.height = (this.Height - 53) + "px";
	                this.layout_Chart.setSizes();


	                this.ChartTab = new Ribbon(ChRibonData);
	                this.ChartTab.Render();


	                //        var select = document.getElementById("idCSEdit_SelMode");
	                //        select.options.length = 0;
	                //        select.options[0] = new Option("Hours", 1, true, true);
	                //        select.options[1] = new Option("FTE", 2, false, false);


	                this.layout_Chart.cells(this.totalsRibbonArea).attachObject(document.getElementById(this.ChartTab.getRibbonDiv()));

	                this.layout_Chart.cells(this.totalsGridArea).attachObject("chart");



	            }
	            else {

	                var parentObj = document.getElementById("idChart");
	                parentObj.style.height = (this.Height - 53) + "px";
	                parentObj.style.width = (this.Width - 10) + "px";
	                this.layout_Chart.setSizes();
	            }


	        }
	        else
	            this.dlgChart.window("winChartDlg").show();
	    }

	    catch (e) {
	        alert("GoDoChart");
	    }

	}

	ResPlanAnalyzer.prototype.GetEditCSDataComplete = function (jsonString) {

	    //	    try {

	    this.CSRoleData = null;

	    var jsonObject = JSON_ConvertString(jsonString);
	    if (JSON_ValidateServerResult(jsonObject)) {

	        this.CostCats = jsonObject.Result.CS_Data.CostCategories;
	        this.CostCatFTEData = JSON_GetArray(this.CostCats, "CostCategory");
	        this.CapScen = jsonObject.Result.CS_Data.CapScenRows;
	        this.CapScenData = JSON_GetArray(this.CapScen, "CapScenRow");
	        this.CapScenPeriodCount = jsonObject.Result.CS_Data.PeriodCount;
	        this.CapScenPeriods = JSON_GetArray(jsonObject.Result.CS_Data.Periods, "Period");

	        if (jsonObject.Result.CS_Data.CapScenRoleDatas != undefined)
	            this.CSRoleData = JSON_GetArray(jsonObject.Result.CS_Data.CapScenRoleDatas, "CapScenRoleData");
	    }




	    var CSRibonData = {
	        parent: "ribbonbarEditCapScenDiv",
	        style: "display:none;",
	        imagePath: this.imagePath,
	        showstate: "false",
	        sections: [
					 { name: "General",
					     columns: [
							{
							    items: [
									{ type: "bigbutton", name: "Close", img: "close32.gif", tooltip: "Close", onclick: "dialogEvent('CSEdit_Close');" }
								]
							},
							{
							    items: [
									{ type: "bigbutton", name: "Save", img: "save32x32.png", tooltip: "Save", onclick: "dialogEvent('CSEdit_Save');" }
								]
							}
						]
					 },
					 { name: "Mode",
					     columns: [
							{
							    items: [
									{ type: "text", name: "Display Mode" },
									{ type: "select", id: "idCSEdit_SelMode", onchange: "dialogEvent('CSEdit_SelMode_Changed')", options: "<option value='1'>Hours</option><option value='2'>FTEs</option>", width: "90px" }
								]
							}
						]
					 },
					{ name: "Tools",
					    columns: [
							{
							    items: [
									{ type: "smallbutton", id: "SpreadBtn", name: "Allocate Values", img: "spread.gif", tooltip: "Allocate Values", onclick: "dialogEvent('CSEdit_Spread');" },
									{ type: "smallbutton", id: "LoadUpBtn", name: "Populate from Totals", img: "spread.gif", tooltip: "Populate from Totals", onclick: "dialogEvent('CSEdit_LoadUp');" }
								]
							}
						]
					}

				 ]
	    };

	    if (this.layout_CS == null) {
	        this.layout_CS = new dhtmlXLayoutObject("idEditCS", "2E", "dhx_skyblue");

	        this.layout_CS.cells(this.totalsRibbonArea).setText("Ribbon");
	        this.layout_CS.cells(this.totalsGridArea).setText("Grid Area");
	        this.layout_CS.cells(this.totalsRibbonArea).hideHeader();
	        this.layout_CS.cells(this.totalsGridArea).hideHeader();
	        //this.layout_CS.cells(this.totalsGridArea).setHeight(this.Height - 110);
	        this.layout_CS.cells(this.totalsRibbonArea).setHeight(92);
	        this.layout_CS.cells(this.totalsRibbonArea).fixSize(false, true);



	        var parentObj = document.getElementById("idEditCS");
	        parentObj.style.height = (this.Height - 53) + "px";
	        this.layout_CS.setSizes();


	        this.CSEditTab = new Ribbon(CSRibonData);
	        this.CSEditTab.Render();


	        //        var select = document.getElementById("idCSEdit_SelMode");
	        //        select.options.length = 0;
	        //        select.options[0] = new Option("Hours", 1, true, true);
	        //        select.options[1] = new Option("FTE", 2, false, false);


	        this.layout_CS.cells(this.totalsRibbonArea).attachObject(document.getElementById(this.CSEditTab.getRibbonDiv()));

	        this.layout_CS.cells(this.totalsGridArea).attachObject("idEditGridDiv");



	    }
	    else {

	        var parentObj = document.getElementById("idEditCS");
	        parentObj.style.height = (this.Height - 53) + "px";
	        parentObj.style.width = (this.Width - 10) + "px";
	        this.layout_CS.setSizes();
	    }
	    this.CSHourMode = true;

	    this.loadupenabled = false

	    if (this.analyzerCalID != this.csCalID)
	        this.CSEditTab.disableItem("LoadUpBtn");
	    else if (this.CSRoleData == null)
	        this.CSEditTab.disableItem("LoadUpBtn");
	    else if (this.CSRoleData.length == 0)
	        this.CSEditTab.disableItem("LoadUpBtn");
	    else
	        this.loadupenabled = true;


	    this.CSEditTab.selectByValue("idCSEdit_SelMode", 1)

	    var sbDataxml = new StringBuilder();

	    sbDataxml = new StringBuilder();
	    sbDataxml.append('<![CDATA[');
	    sbDataxml.append('<Execute Function="GetCapacityScenarioEdit">');
	    sbDataxml.append('</Execute>');
	    sbDataxml.append(']]>');

	    sb = new StringBuilder();
	    sb.append("<treegrid SuppressMessage='3' debug='0' sync='0' ");
	    sb.append(" data_url='" + this.Webservice + "'");
	    sb.append(" data_method='Soap'");
	    sb.append(" data_function='Execute'")
	    sb.append(" data_namespace='WorkEnginePPM'");
	    sb.append(" data_param_Function='GetCapacityScenarioEdit'");
	    sb.append(" data_param_Dataxml='" + sbDataxml.toString() + "'");
	    sb.append(" >");
	    sb.append("</treegrid>");

	    //	    this.layout_CS.setSizes();


	    this.EditGrid = TreeGrid(sb.toString(), "idEditGridDiv", "et_1");
	    this.csrow = null;


	}

	ResPlanAnalyzer.prototype.NewCapScenDlg_OnClose = function () {

			this.AnalyzerViewDlg.window("winAnalyzerViewDlg").detachObject()
			this.AnalyzerViewDlg = null;
			WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("GetCapacityScenarioList", "", GetCapacityScenarioListCompleteDelegate);

	}

	ResPlanAnalyzer.prototype.RedrawCSGrid = function () {

		this.EditGrid = Grids["et_1"];

		var trow, grow, frow;
		var arows = this.EditGrid.Rows;
		var oc;
		var xi;

		for (var i = 0; i < this.CapScenData.length; i++) {
			trow = this.CapScenData[i];
			frow = this.CostCatFTEData[i];
			grow = arows[i + 1];

			for (var per = 1; per <= this.CapScenPeriodCount; per++) {
				var x = "P" + per.toString() + "V";

				var gval, fval;

				if (this.CSHourMode == true) {
					this.EditGrid.SetAttribute(grow, x, "CanEdit", 1, 1);
					gval = trow.Hours[per - 1].Value;
				}
				else {
					fval = frow.FTEs[per - 1].Value
					this.EditGrid.SetAttribute(grow, x, "CanEdit", (fval == 0 ? 0 : 1), 1);
					gval = trow.FTEs[per - 1].Value;
					
				}

				this.EditGrid.SetString(grow, x, gval, 1);

			}
		}
	}

	ResPlanAnalyzer.prototype.GoDoSpread = function () {

		if (this.csrow == null) {
			alert("No Capacity Scenario row has been selected");
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

		}
		else
			this.dlgSpreadDlg.window("winSpreadDlg").show();

		var itemName = this.EditGrid.GetString(this.csrow, "CostCategory");
		

		this.dlgSpreadDlg.window("winSpreadDlg").setText("Allocate " + (this.CSHourMode ? "Hours" : "FTEs") + " to " + itemName);
//                dlg.setText("Allocate " + sUnits + " to " + itemName);
//  



		var sUnits = "";
		var sValue = "";
		

		if (this.CSHourMode) {
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
 
			for (var c = 0; c < this.CapScenPeriods.length; c++) {
				var per = this.CapScenPeriods[c];
				from.options[c] = new Option(per.Name, per.ID);
				to.options[c] = new Option(per.Name, per.ID);
			}
			from.options.selectedIndex = 0;
			to.options.selectedIndex = to.options.length - 1;
		}
	}

	ResPlanAnalyzer.prototype.spreadDlg_Apply = function () {
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

			var i = row.id - 1;
			var trow = this.CapScenData[i];
			var frow = this.CostCatFTEData[i];
			var gval;


			for (var per = 1; per <= this.CapScenPeriodCount; per++) {
				fval = frow.FTEs[per - 1].Value;
				

				var x = "P" + per.toString() + "V";

				if (per < startPeriod && clearPeriods != 0) {
					trow.FTEs[per - 1].Value = 0;
					trow.Hours[per - 1].Value = 0;
					this.EditGrid.SetString(row, x, 0, 1)
				}

				if (per > finishPeriod && clearPeriods != 0) {
					trow.FTEs[per - 1].Value = 0;
					trow.Hours[per - 1].Value = 0;
					this.EditGrid.SetString(row, x, 0, 1)
				}



				if (per >= startPeriod && per <= finishPeriod) {
					gval = val;

					if (this.CSHourMode == true) {
						if (fval != 0)
							trow.FTEs[per - 1].Value = val / fval;
						else
							trow.FTEs[per - 1].Value = 0;

						trow.Hours[per - 1].Value = val;
					}
					else {
						trow.Hours[per - 1].Value = val * fval;
						if (fval != 0)
							trow.FTEs[per - 1].Value = val;
						else {
							gval = 0;
							trow.FTEs[per - 1].Value = 0;
						}
					}
					this.EditGrid.SetString(row, x, gval, 1)
				}

				


			}
		}
	}



	ResPlanAnalyzer.prototype.GoDoLoadUp = function () {
	    if (this.loadupenabled == false)
	        return;


	    var grid = this.EditGrid;

	    var arows = grid.Rows;

	    for (var r in arows) {
	        var row = arows[r];


	        if (row != null) {
	            if (row.Kind == "Data") {

	                var i = row.id - 1;
	                var trow = this.CapScenData[i];
	                var frow = this.CostCatFTEData[i];
	                var gval;


	                for (var per = 1; per <= this.CapScenPeriodCount; per++) {
	                    var x = "P" + per.toString() + "V";
	                    trow.FTEs[per - 1].Value = 0;
	                    trow.Hours[per - 1].Value = 0;
	                    this.EditGrid.SetString(row, x, 0, 1)
	                }
	            }
	        }
	    }

	    for (var r in arows) {
	        var row = arows[r];


	        if (row != null) {
	            if (row.Kind == "Data") {

	                var i = row.id - 1;
	                var trow = this.CapScenData[i];

	                for (var xi = 0; xi < this.CSRoleData.length; xi++) {
	                    var ord = this.CSRoleData[xi];

	                    if (ord.RoleID == trow.ID) {
	                        try {
	                            for (var per = 1; per <= this.CapScenPeriodCount; per++) {
	                                trow.FTEs[per - 1].Value = ord.FTE[per - 1].Value / 100;
	                                trow.Hours[per - 1].Value = ord.Hours[per - 1].Value;
	                            }
	                        }
	                        catch (e) { }
	                        break;
	                    }

	                }

	            }
	        }
	    }

	    this.RedrawCSGrid();

	}

	ResPlanAnalyzer.prototype.SaveCapScenData = function () {


	    var trow, grow, frow;
	    var xi;

	    var sbDataxml = new StringBuilder();
	    var sb = new StringBuilder();

	    sbDataxml = new StringBuilder();
	    sbDataxml.append('<CapacityScenarioData');
	    sbDataxml.append(' Name="' + this.EditName + '"');
	    sbDataxml.append(' ID="' + this.EditCSid + '"');
	    sbDataxml.append(' DEPT="' + this.SelectedCapScenDept + '"');
	    sbDataxml.append(' RMODE="' + this.RoleMode + '"');
	    
	    sbDataxml.append(' WRES="' + (this.SelectedCapScenPrivate == true ? '1' : '0') + '" >');
	    sbDataxml.append('<CS_Values>');

	    this.SelectedCapScenPrivate = false;
        this.SelectedCapScenDept = 0;

	    for (var i = 0; i < this.CapScenData.length; i++) {
	        trow = this.CapScenData[i];

	        for (var per = 1; per <= this.CapScenPeriodCount; per++) {
	            var val, fval;
	            val = parseFloat(trow.Hours[per - 1].Value);
	            fval = parseFloat(trow.FTEs[per - 1].Value);

	            if (val !== 0 && fval !== 0) {

	                sb = new StringBuilder();
	                sb.append('<CS_Value');
	                sb.append(' Role_ID="' + trow.ID + '"');
	                sb.append(' Per_ID="' + per + '"');
	                sb.append(' Hours="' + val + '"');
	                sb.append(' FTEs="' + fval * 10000 + '" />');
	                sbDataxml.append(sb.toString());
	            }
	        }
	    }


	    sbDataxml.append('</CS_Values>');
	    sbDataxml.append('</CapacityScenarioData>');

	    var s = sbDataxml.toString();

	    WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("SaveCapacityScenarioData", s, this.SaveCapacityScenarioDataCompleteDelegate);


	}

	ResPlanAnalyzer.prototype.SaveCapacityScenarioDataComplete = function (jsonString) {

	    var jsonObject = JSON_ConvertString(jsonString);
	    if (JSON_ValidateServerResult(jsonObject)) {

	        var CSDet = jsonObject.Result.CSID;

	        this.EditCSid = CSDet.Value;
	        this.SelectedCapScen = CSDet.Value;
	        this.EditCapScen = CSDet.Value;

	    }


	    alert("The Capacity Scenario has been saved.");
	}


	ResPlanAnalyzer.prototype.SetViewChanged = function (selindex) {

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

			try {
				this.showingTotDet = (this.selectedView.ViewSettings.ShowBotDet == "1");
			} catch (e) {
                this.showingTotDet = false;
			}

            try {
				if (this.selectedView.ViewSettings.PerInc == "1")
                { 
                    var perf = this.selectedView.ViewSettings.FinishPeriod;
                    var pers = this.UsingPeriods.CurrentPeriod.Value;

                    if (perf < pers) 
                        perf = pers;
                    else if (perf > this.UsingPeriods.Period.length)
                            perf = this.UsingPeriods.Period.length

                    this.PerStart = pers;
                    this.PerEnd = perf;

                    document.getElementById("idAnalyzerTab_FromPeriod").selectedIndex = 0;
                    document.getElementById("idAnalyzerTab_ToPeriod").selectedIndex = perf -1;
                    this.flashRibbonSelect('idAnalyzerTab_FromPeriod');
                    this.flashRibbonSelect('idAnalyzerTab_ToPeriod');
                }
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

            
			if (this.AnalyzerHideDetailschecked == true) {
				this.totTab.setButtonStateOn("idBTSDet");
			} else {
				this.totTab.setButtonStateOff("idBTSDet");
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

			WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("ApplyResourceAnalyzerViewServerSideSettings", this.selectedView.ViewGUID, SetChangeViewCompleteDelegate);
		}
	}



	ResPlanAnalyzer.prototype.deferExternalEvent = function (event) {
		this.deferevent = event;

		window.setTimeout(this.deferedExternalEventDelegate, 200);
	}

	ResPlanAnalyzer.prototype.deferedExternalEvent = function () {
		this.externalEvent(this.deferevent);
		this.deferevent = "";
	}

	ResPlanAnalyzer.prototype.findAbsolutePosition = function (obj) {
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

	ResPlanAnalyzer.prototype.deferedsetFocus = function () {

		if (this.doSetFocus == "")
			return;
		try {
			document.getElementById(this.doSetFocus).focus();
		}
		catch (e) { }
		

		this.doSetFocus = "";

	}

	ResPlanAnalyzer.prototype.setNewButtonDisable = function (idButton, bstate) {

		var btn = document.getElementById(idButton);

		if (btn == null)
			return;
		
		if (bstate == true)
			btn.className = "button-new disabledSilver";
		else 
		   btn.className = "button-new silver";
			 
	}

	ResPlanAnalyzer.prototype.externalEvent = function (event) {

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

            if (this.showingGraph == true) {
                for  (var ibc = 0; ibc < this.ChartBlockCommand.length; ibc++)
                {
                    if (event == this.ChartBlockCommand[ibc])
                        return;
                }
            }


	        switch (event) {

	            case "SelectRole_Change":
	                if (this.TotalsLoading == true)
	                    return;

	                window.setTimeout(this.FinishTotalsDelegate, 10);
	                break;

	            case "AnalyzerTab_SaveScen":

	                //	                if (this.fromresource == "0")
	                //	                    break;

	                if (this.analyzerCalID != this.CmtCal || this.fromresource == "0")
	                    break;

	                WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("GetCapacityScenarioList", "", SaveCapacityScenarioListCompleteDelegate);
	                break;

	            case "AnalyzerTab_FromPeriod_Changed":
	                var fp = this.ribbonGetSelectValue("idAnalyzerTab_FromPeriod");
	                var tp = this.ribbonGetSelectValue("idAnalyzerTab_ToPeriod");

	                if (tp < fp) {
	                    alert("The From period cannot be after the To Period");
	                    this.ribbonSetSelectValue("idAnalyzerTab_FromPeriod", this.PerStart);
	                    return;
	                }

                    if (fp == -1)
                    {
                        fp = this.UsingPeriods.CurrentPeriod.Value;
                        if (tp < fp) {
                            tp = fp;

                            this.PerEnd = tp;

                            document.getElementById("idAnalyzerTab_ToPeriod").selectedIndex = tp -1;
                            this.flashRibbonSelect('idAnalyzerTab_ToPeriod');
                        }
                    }

	                this.PerStart = fp;

	                this.flashGridView("g_1", true);
	                this.flashGridView("bottomg_1", true);

                    if (this.showingGraph == true) 
                        this.createChart();

	                break;


	            case "AnalyzerTab_chkAll":

	                this.TabDoChecks(1);
	                break;

	            case "AnalyzerTab_chkNone":

	                this.TabDoChecks(0);
	                break;



	            case "AnalyzerTab_chkCommit_Click":

	                if (this.topgridready == false || this.bottomgridready == false)
	                    return;

	                this.topgridready = false;
	                this.bottomgridready = false;

	                var bchk = this.analyzerTab.getButtonState("chkCommit");

	                if (bchk == true)
	                    this.analyzerTab.setButtonStateOff("chkCommit");
	                else
	                    this.analyzerTab.setButtonStateOn("chkCommit");

	                this.SelectDetails_OKOnClick();

	                break;

	            case "AnalyzerTab_chkMSP_Click":

	                if (this.topgridready == false || this.bottomgridready == false)
	                    return;

	                this.topgridready = false;
	                this.bottomgridready = false;

	                var bchk = this.analyzerTab.getButtonState("chkMSP");

	                if (bchk == true)
	                    this.analyzerTab.setButtonStateOff("chkMSP");
	                else
	                    this.analyzerTab.setButtonStateOn("chkMSP");

	                this.SelectDetails_OKOnClick();

	                break;

	            case "AnalyzerTab_chkActual_Click":

	                if (this.topgridready == false || this.bottomgridready == false)
	                    return;

	                this.topgridready = false;
	                this.bottomgridready = false;

	                var bchk = this.analyzerTab.getButtonState("chkActual");

	                if (bchk == true)
	                    this.analyzerTab.setButtonStateOff("chkActual");
	                else
	                    this.analyzerTab.setButtonStateOn("chkActual");

	                this.SelectDetails_OKOnClick();

	                break;


	            case "AnalyzerTab_chkRequests_Click":

	                if (this.topgridready == false || this.bottomgridready == false)
	                    return;

	                this.topgridready = false;
	                this.bottomgridready = false;

	                var bchk = this.analyzerTab.getButtonState("chkRequests");

	                if (bchk == true)
	                    this.analyzerTab.setButtonStateOff("chkRequests");
	                else
	                    this.analyzerTab.setButtonStateOn("chkRequests");

	                this.SelectDetails_OKOnClick();

	                break;

	            case "AnalyzerTab_chkOpenRequests_Click":

	                if (this.topgridready == false || this.bottomgridready == false)
	                    return;

	                this.topgridready = false;
	                this.bottomgridready = false;

	                var bchk = this.analyzerTab.getButtonState("chkOpenRequests");

	                if (bchk == true)
	                    this.analyzerTab.setButtonStateOff("chkOpenRequests");
	                else
	                    this.analyzerTab.setButtonStateOn("chkOpenRequests");

	                this.SelectDetails_OKOnClick();

	                break;

	            case "AnalyzerTab_chkNonWork_Click":

	                if (this.topgridready == false || this.bottomgridready == false)
	                    return;

	                this.topgridready = false;
	                this.bottomgridready = false;

	                var bchk = this.analyzerTab.getButtonState("chkNonWork");

	                if (bchk == true)
	                    this.analyzerTab.setButtonStateOff("chkNonWork");
	                else
	                    this.analyzerTab.setButtonStateOn("chkNonWork");

	                this.SelectDetails_OKOnClick();

	                break;

	            case "AnalyzerTab_ToPeriod_Changed":


	                var fp = this.ribbonGetSelectValue("idAnalyzerTab_FromPeriod");
	                var tp = this.ribbonGetSelectValue("idAnalyzerTab_ToPeriod");

                    
                    if (fp == -1)
                    {
                        fp = this.UsingPeriods.CurrentPeriod.Value;
                    }

	                if (tp < fp) {
	                    alert("The To period cannot be before the From Period");
	                    this.ribbonSetSelectValue("idAnalyzerTab_ToPeriod", this.PerEnd);
	                    return;
	                }

	                this.PerEnd = tp;

	                this.flashGridView("g_1", true);
	                this.flashGridView("bottomg_1", true);

                    if (this.showingGraph == true) 
                        this.createChart();

	                break;



	            case "ViewChanged":
	                this.SetViewChanged(viewid);

	                break;

	            case "ModeChanged0":

	                if (this.SetSelectedMode(1) == true)
	                    RefreshBothGrids();
	                break;

	            case "ModeChanged1":

	                if (this.SetSelectedMode(2) == true)
	                    RefreshBothGrids();
	                break;

	            case "ModeChanged2":
	                if (this.SetSelectedMode(3) == true)
	                    RefreshBothGrids();
	                break;

	            case "ModeChanged3":
	                if (this.SetSelectedMode(4) == true)
	                    RefreshBothGrids();
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
	                try {
	                    this.AnalyzerFilterschecked = !this.AnalyzerFilterschecked;
	                    grid = Grids["g_1"];
	                    if (this.AnalyzerFilterschecked == true) {
	                        this.showFilters(grid, true);
	                    } else {
	                        this.hideFilters(grid, true);
	                    }
	                }
	                catch (e) {

	                }
	                break;


	            case "AnalyzerTab_SaveDrag":

	                if (this.SaveBtn == false || this.NewMode == true)
	                    return;



	                var result = confirm("You are about to Publish the your changes to the modified resource plans.  Are you sure you want to continue?");

	                if (result == false)
	                    return;

	                this.HaveDragChanges = false;
	                this.SaveBtn = false;

	                this.analyzerTab.disableItem("SaveBtn");
	                this.viewTab.disableItem("SaveBtn2");

	                WorkEnginePPM.ResPlanAnalyzer.Execute("RPASaveDraggedData", "");
	                break;

	            case "AnalyzerTab_UnDoDrag":

	                if (this.UnDoBtn == false)
	                    return;

	                if (this.dragStack.length == 0) {
	                    this.UnDoBtn = false;

	                    this.analyzerTab.disableItem("UndoBtn");
	                    this.viewTab.disableItem("UndoBtn2");

	                    break;
	                }

	                if (this.NegMode == false) {

	                    this.SaveBtn = true;
	                    this.analyzerTab.enableItem("SaveBtn");
	                    this.viewTab.enableItem("SaveBtn2");
	                }

	                grid = Grids["g_1"];

	                var dragarr = this.dragStack.pop();

	                if (this.dragStack.length == 0) {

	                    this.UnDoBtn = false;
	                    this.analyzerTab.disableItem("UndoBtn");
	                    this.viewTab.disableItem("UndoBtn2");

	                }

	                this.ResetDragRow(grid, dragarr);
	                WorkEnginePPM.ResPlanAnalyzer.Execute("UndoRADragRows", "", HandleRefreshDelegate);
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
	                sbd.append('<Execute Function="SaveResourcePlanAnalyzerView">');
	                sbd.append(s);
	                sbd.append('</Execute>');

	                WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("SaveResourceAnalyzerView", sbd.toString(), SaveResourceAnalyzerViewCompleteDelegate);
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

	                WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("RenameResourceAnalyzerView", sbd.toString(), RenameResourceAnalyzerViewCompleteDelegate);
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

	            case "AnalyzerTab_ChangeCalendar":
	                this.FromChangePeriods = true;
	                this.GetCalendarInfoComplete(null);

	                return;


	            case "AnalyzerTab_Close":
	                if (parent.SP.UI.DialogResult)
	                    parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
	                else
	                    parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');
	                return;

	            case "EditResPlan":

	                if (this.params.RPEMode == 1)
	                    break;

	                WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("EditResPlanTicket", this.params.TicketVal, this.EditResPlanDelegate);
	                break;

	            //   this.EditResPlan();     
	            //   break;     


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

	            case "AnalyzerTab_Details_Changed":
	                this.SelectDetails_OKOnClick();

	            case "AnalyzerTab_DetailsCanceled":
	                this.SetDetails.window("winDetDlg").detachObject()
	                this.SetDetails.window("winDetDlg").close();
	                this.SetDetails = null;
	                break;

	            case "AnalyzerTab_SelMode_Changed":
	                this.SetSelectedMode(null);
	                RefreshBothGrids();
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


	                grid.ChangeSort("rowid");
	                grid.SortRows();
	                grid.Render();

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


	            case "AnalyzerTab_CapScen":
	                if (this.fromresource == "0")
	                    break;

	                this.SelectedCapScen = 0;
	                this.CSChanged = false;

	                WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("GetCapacityScenarioList", "", GetCapacityScenarioListCompleteDelegate);

	                break;

	            case "TotalsTab_GridHelpBtn":
	                this.DisplayGridExplaination();
	                break;

	            case "AnalyzerTab_ShowBottomDetails":
 	                try {
   
   			            this.bottomgriddragstash = this.BuildViewInf("guid", "name", false, false, true);
	                    if (this.showingTotDet == false) {

	                         this.totTab.setButtonStateOn("idBTSDet");
	                         this.showingTotDet = true;
                             WorkEnginePPM.ResPlanAnalyzer.Execute("SetBottomDetailsDisplay", "1" , RefreshBottomGrid);

                        }
	                    else {
	                        this.showingTotDet = false;
                            
                             
	                        this.totTab.setButtonStateOff("idBTSDet");
                             WorkEnginePPM.ResPlanAnalyzer.Execute("SetBottomDetailsDisplay", "0" , RefreshBottomGrid);
	                    }

                        
	                }
	                catch (e) { }

	                break;
                       
     

	            case "AnalyzerTab_ShowGraph":
	                // this.GoDoChart();

	                try {


	                    if (this.showingGraph == false) {

	                         this.totTab.setButtonStateOn("idGraph");
	                         this.showingGraph = true;


                             for (var xi = 0; xi < this.ChartATDisableList.length; xi++)
                             {

                             	this.analyzerTab.temporyDisableItem(this.ChartATDisableList[xi]);
                             }


                            for (var xi = 0; xi < this.ChartVTDisableList.length; xi++)
                             {

                             	this.viewTab.temporyDisableItem(this.ChartVTDisableList[xi]);
                             }

                            for (var xi = 0; xi < this.ChartBTDisableList.length; xi++)
                             {

                             	this.totTab.temporyDisableItem(this.ChartBTDisableList[xi]);
                             }

                             
                          
	                       var gdiv = document.getElementById('gridDiv_1');
	                       var cdiv = document.getElementById('chart');

                           cdiv.style.height = gdiv.style.height;

	                        this.layout.cells(this.mainArea).detachObject();
	                        this.layout.cells(this.totalsGridArea).attachObject("chart");

	                        this.createChart();
	                    }
	                    else {
	                        this.showingGraph = false;
                            
                             for (var xi = 0; xi < this.ChartATDisableList.length; xi++)
                             {

                             	this.analyzerTab.resetTemporyDisableItem(this.ChartATDisableList[xi]);
                             }


                            for (var xi = 0; xi < this.ChartVTDisableList.length; xi++)
                             {

                             	this.viewTab.resetTemporyDisableItem(this.ChartVTDisableList[xi]);
                             }


                             
                            for (var xi = 0; xi < this.ChartBTDisableList.length; xi++)
                             {

                             	this.totTab.resetTemporyDisableItem(this.ChartBTDisableList[xi]);
                             }

                             
	                         this.totTab.setButtonStateOff("idGraph");
	                        this.layout.cells(this.mainArea).detachObject();
	                        this.layout.cells(this.totalsGridArea).attachObject("gridDiv_1");
	                    }
	                }
	                catch (e) { }

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

	            case "SelectCalendar_Change":
	                this.SelectCalendar_Change();
	                break;

	            case "Display_RPA":
	                this.ShowWorkingPopup();
	                this.SelectFiscalDlg_OKOnClick(0);
	                break;


	            case "Cancel_RPA":
	                this.SelectFiscalDlg_OKOnClick(1);
	                break;

	            case "TotalsTab_SelectTotalColumns":
	                this.TotGrid.SelectAllRows(0);

	                this.GetTotals();
	                break;

	            case "TotalColOK_Click":
	                this.TotGrid.SelectAllRows(0);
	                this.SelectTotals_OKOnClick(1);
	                break;


	            case "TotalColCancel_Click":
	                this.SelectTotals_OKOnClick(0);
	                break;

	            case "TotalByRes_Click":
	                if (this.TotalsLoading == true)
	                    return;

	                var rbtotByRole = document.getElementById('idTotalsByRole');
	                var rbtotByRes = document.getElementById('idTotalsByRes');

	                rbtotByRole.checked = false;
	                rbtotByRes.checked = true;

	                var answer = confirm("All Capacity Scenario Total Columns will be removed from the view because Capacity Scenarios require the grid to be grouped by Role");
	                if (!answer) {
	                    rbtotByRole.checked = true;
	                    rbtotByRes.checked = false;
	                    return;
	                }

	                window.setTimeout(this.FinishTotalsDelegate, 10);

	                break;

	            case "TotalByRole_Click":
	                if (this.TotalsLoading == true)
	                    return;

	                var rbtotByRole = document.getElementById('idTotalsByRole');
	                var rbtotByRes = document.getElementById('idTotalsByRes');
	                rbtotByRole.checked = true;
	                rbtotByRes.checked = false;

	                window.setTimeout(this.FinishTotalsDelegate, 10);

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

	            case "TotalsTab_SelectColumns":
	                grid = Grids["bottomg_1"];
	                grid.ActionShowColumns('Selectable');
	                break;
	                break;

	            case "TotalsTab_ShowFilters_Click":
	                try {


	                    this.TotalFilterschecked = !this.TotalFilterschecked;
	                    grid = Grids["bottomg_1"];
	                    if (this.TotalFilterschecked == true) {
	                        this.showFilters(grid, true);
	                    } else {
	                        this.hideFilters(grid, true);
	                    }
	                }
	                catch (e) {
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


	                grid.ChangeSort("rowid");
	                grid.SortRows();
	                grid.Render();

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

	                    WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("DeleteResourceAnalyzerView", sbd.toString(), DeleteResourceAnalyzerViewCompleteDelegate);
	                }
	                break;


	            case "SaveScenOK_Click":
	                var sscen = document.getElementById("idSaveScenText").value;


	                sscen = sscen.replace(/^\s+|\s+$/g, "");


	                if (sscen == "") {
	                    alert("You need to ender a Scenario name to save the data to");
	                    return;

	                }

	                WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("SaveCurrentToScenario", sscen, RefreshBottomGrid);


	            case "SaveScenCan_Click":

	                this.SaveScenDlg.window("winSaveScenDlg").detachObject();
	                this.SaveScenDlg.window("winSaveScenDlg").close();
	                this.SaveScenDlg = null;

	                //                    if (event == "SaveScenOK_Click")
	                //                        RefreshBottomGrid();

	                break;

	            case "CapScenDone_Click":

	                this.CapScenDlg.window("winCapScenDlg").detachObject();
	                this.CapScenDlg.window("winCapScenDlg").close();
	                this.CapScenDlg = null;

	                if (this.CSChanged == true)
	                    RefreshBottomGrid();

	                break;

	            case "CapScenSel":
	                this.idCapScenEdit_disabled = false;
	                this.idCapScenDel_disabled = false;
	                this.idCapScenCopy_disabled = false;

	                this.setNewButtonDisable('idCapScenCopy', this.idCapScenCopy_disabled);
	                this.setNewButtonDisable('idCapScenEdit', this.idCapScenEdit_disabled);
	                this.setNewButtonDisable('idCapScenDel', this.idCapScenDel_disabled);
	                break;



	            case "SaveScenSel":
	                var select = document.getElementById("idSaveScenSel");

	                var selectedItem = select.options[select.selectedIndex];

	                document.getElementById("idSaveScenText").value = selectedItem.text;

	                break;

	            case "CapScenNew_Click":
	                this.SelectedCapScen = -1;
	                this.EditCapScen = -1;
	                this.CapScenDlg.window("winCapScenDlg").detachObject();
	                this.CapScenDlg.window("winCapScenDlg").close();
	                this.CapScenDlg = null;
	                this.SelCapScen = null;

	                document.getElementById("idTxtCapScenName").value = "New Capacity Scenario";


	                this.PopulateCSDeptList(0);
	                window.setTimeout(this.CapScenCreateNewDelegate, 100);

	                break;


	            case "CapScenCopy_Click":

	                if (this.idCapScenCopy_disabled == true)
	                    return;

	                var select = document.getElementById("idSelectCapScen");
	                this.SelectedCapScen = select.value;
	                this.EditCapScen = -1;

	                var selectedItem = select.options[select.selectedIndex];
	                this.CapScenDlg.window("winCapScenDlg").detachObject();
	                this.CapScenDlg.window("winCapScenDlg").close();
	                this.CapScenDlg = null;




	                document.getElementById("idTxtCapScenName").value = "Copy of " + selectedItem.text;

	                var csc = this.CapScens[select.selectedIndex];

	                this.SelCapScen = csc;

	                document.getElementById("idNewCSPrivate").checked = (csc.WRES != 0);

	                this.PopulateCSDeptList(csc.DEPT);


	                window.setTimeout(this.CapScenCreateCopyDelegate, 100);
	                break;

	            case "CapScenEdit_Click":

	                if (this.idCapScenEdit_disabled == true)
	                    return;

	                var select = document.getElementById("idSelectCapScen");
	                this.SelectedCapScen = select.value;
	                this.EditCapScen = select.value;

	                var selectedItem = select.options[select.selectedIndex];

	                this.SelCapScen = this.CapScens[select.selectedIndex];

	                this.CapScenDlg.window("winCapScenDlg").detachObject();
	                this.CapScenDlg.window("winCapScenDlg").close();
	                this.CapScenDlg = null;


	                this.SelectedCapScenText = selectedItem.text;

	                window.setTimeout(this.GoDoEditDelegate, 100);

	                //this.GoDoEdit(this.SelectedCapScen, selectedItem.text);


	                break;

	            case "SaveCS_OK":
	                this.AnalyzerViewDlg.window("winAnalyzerViewDlg").setModal(false);
	                this.AnalyzerViewDlg.window("winAnalyzerViewDlg").hide();
	                this.AnalyzerViewDlg.window("winAnalyzerViewDlg").detachObject()
	                this.AnalyzerViewDlg = null;

	                this.SelectedCapScenText = document.getElementById("idTxtCapScenName").value;

	                this.SelectedCapScenPrivate = document.getElementById("idNewCSPrivate").checked;


	                var deptsel = document.getElementById("idNewCSDept");

	                this.SelectedCapScenDept = deptsel.options[deptsel.selectedIndex].value;


	                window.setTimeout(this.GoDoEditDelegate, 100);
	                //      this.GoDoEdit(this.SelectedCapScen, document.getElementById("idTxtCapScenName").value);
	                break;

	            //  call webservice to edit                                                                                    



	            case "CapScenRemove_Click":
	                if (this.idCapScenDel_disabled == true)
	                    return;

	                this.CSChanged = true;

	                var select = document.getElementById("idSelectCapScen");

	                for (i = 0; i <= select.options.length - 1; i++) {

	                    if (select.options[i].selected == true) {
	                        var iDelCapScen = select.options[i].value;

	                        if (select.options.length == 1) {
	                            this.idCapScenEdit_disabled = true;
	                            this.idCapScenDel_disabled = true;
	                            this.idCapScenCopy_disabled = true;

	                            this.setNewButtonDisable('idCapScenCopy', this.idCapScenCopy_disabled);
	                            this.setNewButtonDisable('idCapScenEdit', this.idCapScenEdit_disabled);
	                            this.setNewButtonDisable('idCapScenDel', this.idCapScenDel_disabled);

	                        }
	                        else if (i == select.options.length - 1)
	                            select.options[i - 1].selected = true;
	                        else
	                            select.options[i + 1].selected = true;


	                        WorkEnginePPM.ResPlanAnalyzer.Execute("DeleteCapacityScenario", iDelCapScen);
	                        // call webserveice to delete Cap Scen
	                        select.remove(i);
	                        break;
	                    }
	                }


	                break;

	            case "SaveCS_Cancel":
	                this.AnalyzerViewDlg.window("winAnalyzerViewDlg").setModal(false);
	                this.AnalyzerViewDlg.window("winAnalyzerViewDlg").hide();
	                this.AnalyzerViewDlg.window("winAnalyzerViewDlg").detachObject()
	                this.AnalyzerViewDlg = null;

	                WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("GetCapacityScenarioList", "", GetCapacityScenarioListCompleteDelegate);

	                break;

	            case "CSEdit_Save":
	                this.CSChanged = true;
	                this.SaveCapScenData();

	                break;

	            case "CSEdit_Close":


	                this.dlgEditTarget.window("winEditTargetDlg").setModal(false);
	                this.dlgEditTarget.window("winEditTargetDlg").hide();
	                this.dlgEditTarget.window("winEditTargetDlg").detachObject();
	                this.dlgEditTarget = null;


	                this.EditGrid.Dispose();
	                this.EditGrid = null;

	                WorkEnginePPM.ResPlanAnalyzer.ExecuteJSON("GetCapacityScenarioList", "", GetCapacityScenarioListCompleteDelegate);

	                break;


	            case "Chart_Close":

	                this.dlgChart.window("winChartDlg").setModal(false);
	                this.dlgChart.window("winChartDlg").hide();
	                this.dlgChart.window("winChartDlg").detachObject();
	                this.dlgChart = null;


	                break;


	            case "CSEdit_SelMode_Changed":

	                var vl = this.ribbonGetSelectValue("idCSEdit_SelMode");

	                if (this.dlgSpreadDlg != null) {
	                    this.dlgSpreadDlg.window("winSpreadDlg").setModal(false);
	                    this.dlgSpreadDlg.window("winSpreadDlg").hide();
	                    this.dlgSpreadDlg.window("winSpreadDlg").detachObject();
	                    this.dlgSpreadDlg = null;
	                }


	                if (vl == 1 && this.CSHourMode == true)
	                    break;

	                if (vl == 2 && this.CSHourMode == false)
	                    break;



	                this.CSHourMode = (this.CSHourMode == false);

	                this.RedrawCSGrid();



	                break;

	            case "CSEdit_Spread":
	                this.GoDoSpread();
	                break;

	            case "CSEdit_LoadUp":
	                this.GoDoLoadUp();
	                break;


	            case "spreadDlg_Close":


	                this.dlgSpreadDlg.window("winSpreadDlg").setModal(false);
	                this.dlgSpreadDlg.window("winSpreadDlg").hide();
	                this.dlgSpreadDlg.window("winSpreadDlg").detachObject();
	                this.dlgSpreadDlg = null;

	                break;

	            case "spreadDlg_Apply":
	                this.spreadDlg_Apply();
	                break;

	            case "GridExplain_OKOnClick":
	                this.dlgShowGridEx.window("winGridExDlg").setModal(false);
	                this.dlgShowGridEx.window("winGridExDlg").hide();
	                this.dlgShowGridEx.window("winGridExDlg").detachObject();
	                this.dlgShowGridEx = null;
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

	ResPlanAnalyzer.prototype.showFilters = function (grid, bfromtoolbar) {
	    try {
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

	    }
	    catch (e)
	    {
	        
	    }

	}


	ResPlanAnalyzer.prototype.FlashTopGridHideDetails = function () {
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

	        grid.DoFilter(null, null);
	        this.AnalyzerHideDetailschecked = false;
	        for (var r in arows) {
	            var yrow = arows[r];

	            if (yrow.Kind == "Data") {

	                if (this.CheckIfRowFiltered(grid, yrow))
	                    grid.ShowRow(yrow);
	            }
	        }
	        return;
	    }

	    if (row.firstChild == null) {

	        grid.DoFilter(null, null);
	        this.AnalyzerHideDetailschecked = false;
	        for (var r in arows) {
	            var zrow = arows[r];

	            if (zrow.Kind == "Data") {
	                if (this.CheckIfRowFiltered(grid, zrow))
	                    grid.ShowRow(zrow);
	            }


	        }
	        return;
	    }

	    this.AnalyzerHideDetailschecked = !this.AnalyzerHideDetailschecked;


	    var fc = null;

	    if (this.AnalyzerHideDetailschecked == true) {
	        for (var r in arows) {
	            row = arows[r];

	            if (row.Kind == "Data") {
	                fc = row.firstChild;

	                if (fc == null)
	                    grid.HideRow(row);  
	            }
	        }
	    } else {

	        grid.DoFilter(null, null);
	        for (var r in arows) {
	            row = arows[r];

	            if (row.Kind == "Data") {
	                fc = row.firstChild;

	                if (fc == null) {
	                    if (this.CheckIfRowFiltered(grid, row))
	                        grid.ShowRow(row);
	                }
	                   
	            }
	        }

	    }


	    grid.Render();
	    this.OnResize();
	}

	 ResPlanAnalyzer.prototype.hideFilters = function (grid, bfromtoolbar) {

	     try {
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

	         if (bfromtoolbar == true)
                 grid.Render();

	         //             var htt;
	         //             var htb;

	         //             htt = this.layout.cells(this.mainArea).getHeight();
	         //             htb = this.layout_totals.cells(this.totalsGridArea).getHeight();

	         //             this.layout_totals.cells(this.totalsGridArea).setHeight(100);
	         //             this.layout.cells(this.mainArea).setHeight(htt / 2);
	         //             this.layout_totals.cells(this.totalsGridArea).setHeight(htb);
	         //             this.layout.cells(this.mainArea).setHeight((htt * 3) / 2);

	         //             this.layout.cells(this.mainArea).setHeight(htt);


	     }
	     catch (e) { }
	 }

	 ResPlanAnalyzer.prototype.showGrouping = function (grid) {
	     var groupRow = this.getGroupRow(grid);
	     if (groupRow != null) {
	         if (groupRow.Visible == 1)
	             return;

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

	ResPlanAnalyzer.prototype.getGroupRow = function (grid) {
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

	ResPlanAnalyzer.prototype.hideGrouping = function (grid) {
		var groupRow = this.getGroupRow(grid);
		if (groupRow != null) {

		    if (groupRow.Visible == 0)
		        return;
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

	ResPlanAnalyzer.prototype.GridsOnUpdated = function (grid) {

//        var arow = grid.Rows["Filter"];

//        if (arow == undefined)
//            return;

//        if (arow == null)
//            return;

//        if (grid.id == "g_1")
//           grid.ChangeDef(arow, "FilterRow", 1, 0);


	}

	ResPlanAnalyzer.prototype.CapScenCreateNew = function () {
		if (this.AnalyzerViewDlg == null) {
			this.AnalyzerViewDlg = new dhtmlXWindows();
			this.AnalyzerViewDlg.setSkin("dhx_web");
			this.AnalyzerViewDlg.enableAutoViewport(false);
			this.AnalyzerViewDlg.attachViewportTo(this.params.ClientID + "mainDiv");
			this.AnalyzerViewDlg.setImagePath("/_layouts/ppm/images/");

            if (this.allowcsmode == "0")
                this.AnalyzerViewDlg.createWindow("winAnalyzerViewDlg", 20, 30, 265, 195);
            else
			    this.AnalyzerViewDlg.createWindow("winAnalyzerViewDlg", 20, 30, 265, 215);
			this.AnalyzerViewDlg.window("winAnalyzerViewDlg").setIcon("logo.ico", "logo.ico");
			this.AnalyzerViewDlg.window("winAnalyzerViewDlg").denyResize();
			//this.AnalyzerViewDlg.window("winAnalyzerViewDlg").button("close").disable();
			this.AnalyzerViewDlg.window("winAnalyzerViewDlg").button("park").hide();
			//this.AnalyzerViewDlg.setSkin(this.params.DHTMLXSkin);
			this.AnalyzerViewDlg.window("winAnalyzerViewDlg").setModal(true);
			this.AnalyzerViewDlg.window("winAnalyzerViewDlg").center();
			this.AnalyzerViewDlg.window("winAnalyzerViewDlg").setText("Create New Capacity Scenario");
			this.AnalyzerViewDlg.window("winAnalyzerViewDlg").attachEvent("onClose", function (win) { NewCapScenDlg_OnCloseDelegate(); return true; });
			this.AnalyzerViewDlg.window("winAnalyzerViewDlg").attachObject("idCreateNewCapScen");

			document.getElementById("idNewCSPrivate").checked = false;
			var rolediv = document.getElementById("idRolebased");

            if (this.allowcsmode == "0")
                rolediv.style.display = "none";
            else
			    rolediv.style.display = "block";

			
		}
		else {
			this.AnalyzerViewDlg.window("winAnalyzerViewDlg").show();
		}
	}

	ResPlanAnalyzer.prototype.CapScenCreateCopy = function () {
	    if (this.AnalyzerViewDlg == null) {
	        this.AnalyzerViewDlg = new dhtmlXWindows();
	        this.AnalyzerViewDlg.setSkin("dhx_web");
	        this.AnalyzerViewDlg.enableAutoViewport(false);
	        this.AnalyzerViewDlg.attachViewportTo(this.params.ClientID + "mainDiv");
	        this.AnalyzerViewDlg.setImagePath("/_layouts/ppm/images/");
	        this.AnalyzerViewDlg.createWindow("winAnalyzerViewDlg", 20, 30, 265, 195);
	        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").setIcon("logo.ico", "logo.ico");
	        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").denyResize();
	        //this.AnalyzerViewDlg.window("winAnalyzerViewDlg").button("close").disable();
	        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").button("park").hide();
	        //this.AnalyzerViewDlg.setSkin(this.params.DHTMLXSkin);
	        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").setModal(true);
	        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").center();
	        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").setText("Create Copy of Capacity Scenario");
	        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").attachEvent("onClose", function (win) { NewCapScenDlg_OnCloseDelegate(); return true; });
	        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").attachObject("idCreateNewCapScen");
	        var rolediv = document.getElementById("idRolebased");


	        rolediv.style.display = "none";



	    }
	    else {
	        this.AnalyzerViewDlg.window("winAnalyzerViewDlg").show();
	    }
	}
					
	ResPlanAnalyzer.prototype.GridsOnAfterColResize = function (grid, col) {
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


	ResPlanAnalyzer.prototype.HandleException = function (sWhere, e) {
		alert("Error " + sWhere + " : " + e.toString());
	}


	  ResPlanAnalyzer.prototype.ShowLegend = function () {
		if (this.dlgShowLegend == null)
		{

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
			sb.append("<treegrid SuppressMessage='3' debug='0' sync='0' ");
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

	ResPlanAnalyzer.prototype.tabbarOnSelect = function (id, data) {
		if (this.analyzerTab.isCollapsed() == true) {
			this.layout.cells(this.mainRibbonArea).fixSize(false, false);
			this.layout.cells(this.mainRibbonArea).setHeight(120);
			this.layout.cells(this.mainRibbonArea).fixSize(false, true);
			this.analyzerTab.expand();
			this.viewTab.expand();
		}
	}

	ResPlanAnalyzer.prototype.flashRibbonSelect = function (idsel) {
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


	ResPlanAnalyzer.prototype.ribbonGetSelectValue = function (idsel) {
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
	
	 ResPlanAnalyzer.prototype.ribbonSetSelectValue = function (idsel, indval) {
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


	function mycallback(dialogResult, returnValue) {
		WorkEnginePPM.ResPlanAnalyzer.Execute("ReloadPlanData", "", ReloadPlanDataCompleteDelegate);
		try {

		    this.analyzerTab.disableItem("UndoBtn");
		    this.viewTab.disableItem("UndoBtn2");
		    this.analyzerTab.disableItem("SaveBtn");
		    this.viewTab.disableItem("SaveBtn2");

		}

		catch (e) { }

		try {
		    this.dragStack = new Array();
		    this.dragLevel = 0;
        }

        catch (e) { }
}


	ResPlanAnalyzer.prototype.ReloadPlanDataComplete = function () {
		this.stashgridsettings = this.BuildViewInf("guid", "name", false, false, true); 
		RefreshBothGrids();
	}

	ResPlanAnalyzer.prototype.EditResPlan = function (jsonString) {


	    //	    alert(jsonString);


	    var sTicket = this.params.TicketVal;

	    var jsonObject = JSON_ConvertString(jsonString);
	    if (JSON_ValidateServerResult(jsonObject)) {

	        sTicket = jsonObject.Result.Ticket.Value;
	    }
        
        var weburl = document.URL;
	    weburl = weburl.replace("rpanalyzer", "rpeditor");

	    weburl = weburl.replace(this.params.TicketVal, sTicket);

	    if (this.fromresource == 1) {
	        if (weburl.indexOf("isresource=") == -1) {
	            weburl += "&isresource=1";
	        }

	    }

	    //    weburl = "/_layouts/ppm/rpeditor.aspx?dataid=" + this.params.TicketVal + "&IsResource=" + this.fromresource       

	    var options = { url: weburl, width: 800, height: 600, showClose: true, dialogReturnValueCallback: mycallback };

	    parent.SP.UI.ModalDialog.showModalDialog(options);

	}

	ResPlanAnalyzer.prototype.DisplayGridExplaination = function () {

		try {
			if (this.dlgShowGridEx == null) {

				this.dlgShowGridEx = new dhtmlXWindows();
				this.dlgShowGridEx.setSkin("dhx_web");
				this.dlgShowGridEx.enableAutoViewport(false);
				this.dlgShowGridEx.attachViewportTo(this.clientID + "mainDiv");
				this.dlgShowGridEx.setImagePath(this.imagePath);
				this.dlgShowGridEx.createWindow("winGridExDlg", 20, 30, 720, 500);
				this.dlgShowGridEx.window("winGridExDlg").setIcon("logo.ico", "logo.ico");
				this.dlgShowGridEx.window("winGridExDlg").allowMove();
				this.dlgShowGridEx.window("winGridExDlg").denyResize();
				this.dlgShowGridEx.window("winGridExDlg").setModal(true);
				this.dlgShowGridEx.window("winGridExDlg").center();


				this.dlgShowGridEx.window("winGridExDlg").setText("Grid Explanation");

				this.dlgShowGridEx.window("winGridExDlg").attachObject("idGridExplainDlgObj");
				this.dlgShowGridEx.window("winGridExDlg").button("close").disable();
				this.dlgShowGridEx.window("winGridExDlg").button("park").hide();

			} else
				this.dlgShowGridEx.window("winGridExDlg").show();

			var wrktxt = document.getElementById("iddivgewrk");


			var sb = new StringBuilder();
			sb.append("<ul style='list-style-type:disc'>");

			if (this.DetailsData.CommittedWork.Value == "1")
				sb.append("<li>Committed Work – Committed Work values come from committed items within Resource Plans</li>");

			if (this.DetailsData.ScheduledWork.Value == "1")
				sb.append("<li>Scheduled Work – Scheduled Work values come from items in SharePoint such as Tasks and Issues that have been configured as Scheduled Work items</li>");

			if (this.DetailsData.ActualWork.Value == "1")
				sb.append("<li>Timesheet Actuals - Timesheet Actuals values come from the actual values entered via the Timesheet</li>");


			var negmode = this.DetailsData.NegMode.Value;
			var showpersonal = this.DetailsData.ShowPersonal.Value;
			var showopen = this.DetailsData.ShowOpenReq.Value;

			if (this.DetailsData.ProposedWork.Value == "1" && negmode == "1")
				sb.append("<li>Proposed Work - Proposed Work values </li>");



			if (this.DetailsData.OpenRequestWork.Value == "1" && showopen == "1")
				sb.append("<li>Open Requirements - Open Requirements values </li>");


			if (this.DetailsData.PersonalWork.Value == "1" && showpersonal == "1")
				sb.append("<li>Personal Time Off - Personal Time Off </li>");

			sb.append("</ul");


			wrktxt.innerHTML = sb.toString();

			var colsSect = document.getElementById("iddivgeExtraColsSection");
			var colstxt = document.getElementById("iddivgecols");

			var sb = new StringBuilder();
			var colcnt = 0;

			sb.append("<ul style='list-style-type:disc'>");


			if (this.TotalsData != null) {

				var xiii = 0;

			}

			sb.append("</ul");


			colstxt.innerHTML = sb.toString();

			if (colcnt == 0)
				iddivgeExtraColsSection.style.display = "none";
			else
				iddivgeExtraColsSection.style.display = "block";


		}
		catch (e) {
		}

}

ResPlanAnalyzer.prototype.createChart = function () {

    try {

        var xdata = new Object();
        //       xdata.title = new Object();
        //       xdata.title.text = "";

        xdata.legend = new Object();
        xdata.legend.visible = true;

       // xdata.seriesDefaults = new Object();
       // xdata.seriesDefaults.type = "column";

        xdata.valueAxis = new Object();
      //  xdata.valueAxis.labels = new Object();
      //  xdata.valueAxis.labels.template = "#= kendo.format('{0:N0}', value) #";
        xdata.valueAxis.line = new Object();
        xdata.valueAxis.line.visible = false;

        xdata.tooltip = new Object();
        xdata.tooltip.visible = false;

        xdata.categoryAxis = new Object();
        xdata.categoryAxis.majorGridLines = new Object();
        xdata.categoryAxis.majorGridLines.visible = false;
        xdata.categoryAxis.labels = new Object();
        xdata.categoryAxis.labels.rotation = 45;


        var FromList = document.getElementById("idAnalyzerTab_FromPeriod");
        var ToList = document.getElementById("idAnalyzerTab_ToPeriod");

        var StartID = parseInt(FromList.options[FromList.selectedIndex].value);


        if (StartID == -1)
        {
            StartID = this.UsingPeriods.CurrentPeriod.Value;
        }

        StartID -= 1;
        var FinishID = parseInt(ToList.options[ToList.selectedIndex].value) - 1;

        var ycnt = FinishID - StartID;
        var ystp = 0;

        if (ycnt > 40) {
            ystp = Math.floor(ycnt/40) + 1;
            xdata.categoryAxis.labels.step = ystp;
        }


        xdata.categoryAxis.categories = new Array();




        var avail = new Array();

        for (var i = StartID; i <= FinishID; i++) {
            xdata.categoryAxis.categories.push(FromList.options[i].text);
            avail.push(Number(0));


        }

        xdata.series = new Object;
        var cnt = 0;

        for (var xi = 0; xi < this.ChartRawData.length; xi++) {
            var rd = this.ChartRawData[xi];

            if (rd.Sel != 0) {
                var ob = new Object;
                xdata.series[cnt++] = ob;
                ob.name = rd.Name;
                ob.type = "column"
                ob.stack = true;
                ob.data = new Array();

                for (var i = StartID; i <= FinishID; i++) {
                    ob.data.push(Number(rd.Tot[i]));
                    avail[i - StartID] += Number(rd.Avail[i]);
                }

            }


        }

        
                
        var oba = new Object;
        xdata.series[cnt++] = oba;
        oba.name = "Availability";
        oba.color = "#808080";

        // if ussing line type.... for avail
        oba.type = "line"
        oba.data = avail;


 // do something funcky for the avail....

//         oba.type = "candlestick"
//         oba.data = new Array();

//        for (var i = StartID; i <= FinishID; i++) {
//            var obc = new Object();
//            var adj = 0;

//            if ( avail[i - StartID] != 0)
//                adj = 2;
//            else
//                adj = 0;
//            obc.high = avail[i - StartID];
//            obc.low = avail[i - StartID] - adj;
//            obc.open = avail[i - StartID];
//            obc.close = avail[i - StartID] - adj;

//            oba.data.push(obc);
//        }


//         oba.type = "scatterLine"
//         oba.data = new Array();

//        for (var i = StartID; i <= FinishID; i++) {
//            var obc = new Array();
//            obc.push(i - StartID);
//            obc.push(avail[i - StartID]);
//            oba.data.push(obc);

//            obc = new Array();
//            obc.push(i - StartID + 1);
//            obc.push(avail[i - StartID]);
//            oba.data.push(obc);

//        }


        // done!

		var cdata = {
                legend: {
                    visible: true
                },
                series: [{
                    name: "Steve Masters",
                    stack: true,
					type: "column",
                    data: [0, 0, 0, 0, 0, 40, 40, 40, 0, 0]
                },     
                {
                    name: "Munjal Patel",
                    stack: true,
					type: "column",
                    data: [0, 0, 0, 0, 0, 0, 0, 0, 100, 0]
                },  
                {
                    name: "DBA",
                    stack: true,
					type: "column",
                    data: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
                }, 
				{
                    name: "Adam Barr",
                    stack: true,
					type: "column",
                    data: [0, 85, 0, 0, 0, 90, 100, 120, 120, 0]
                }, 
				{
                    name: "Availability",
					type: "line",
                    data: [352, 336, 552, 504, 528, 552, 480, 552, 528, 488]
                }],
                valueAxis: {
                    line: {
                        visible: false
                    }
                },
                categoryAxis: {
                    categories: ["Mar 2012"	,"Apr 2012"	, "May 2012","Jun 2012"	,"Jul 2012","Aug 2012"	,	"Sep 2012"	,	"Oct 2012"	,"Nov 2012"	,	"Dec 2012"],
                    majorGridLines: {
                        visible: false
                    }
                },
                tooltip: {
                    visible: true,
                }
            }

            if (this.kendochart != null) {
                var chart = $("#chart").data("kendoChart");
                chart.destroy();

                this.kendochart = null;
            }

            this.kendochart = $("#chart").kendoChart(xdata);

                            
	                       var gdiv = document.getElementById('gridDiv_1');
	                       var cdiv = document.getElementById('chart');

                           cdiv.style.height = gdiv.style.height;

    }
    catch (e) {
        alert("Create Graph error:" + e.toString());
    }
}


ResPlanAnalyzer.prototype.InitVars = function () {
    this.fromresource = "";
    // Initialised fields
    this.dlgShowGridEx = null;

    this.SelectedCapScenPrivate = false;
    this.kendochart = null;


    this.NegMode = false;
    this.NegWarn = false;

    this.TotMaxed = false;
    this.groupColour = 0xF8F8F8;

    this.bapplyDefView = false;

    this.analyzerCalID = 0;

    this.csCalID = 0;

    this.tg_rollup = null;
    this.tg_rollup_render = false;

    this.topgridready = false;
    this.bottomgridready = false;
    this.bottomgridfirstready = false;


    this.FilteredTop = new Array();

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

    this.SaveBtn = false;
    this.UnDoBtn = false;


    this.CapScenDlg = null;
    this.TopGridDragged = false;

    this.params = params;
    this.TotSelectedOrder = null;

    this.clientID = this.params.ClientID;
    this.Webservice = params.Webservice;

    this.mainRibbonArea = "a";
    this.mainArea = "b";
    this.totalsArea = "c";
    this.totalsRibbonArea = "a";
    this.totalsGridArea = "b";


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



    this.TotGrid = null;
    this.DetGrid = null;
    this.TotalsGridSettingsData = null;

    this.FilterDifferent = false;
    this.CSChanged = false;


    this.selectCalendarAndPeriods = null;
    this.imagePath = "/_layouts/ppm/images/";

    // dialog handles

    this.fiscalInfo = null;
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


    this.selectedHeatMapColour = "1";

    this.deferredhidedetails = false;
    this.SelCapScen = null;



    this.LastFilterString = "";

    this.CapacityScenarios = null;
    this.refreshIconsInTotGrid = null;
    this.refreshChecksInDetGrid = null;
    this.refreshBottomChecksInDetGrid = null;


    this.dragStack = new Array();
    this.dragLevel = 0;
    this.FromChangePeriods = false;

    this.CSDepts = null;
    this.SelectedCapScenDept = 0;
    this.loadupenabled = false;
    this.RoleMode = 0;

    this.dlgChart = null;
    this.showingGraph = false;
    this.ChartRawData = null;

    this.showingTotDet = false;
}

	try {


	    this.InitVars();

	    this.layout = null;
	    this.layout_totals = null;
	    this.analyzerTab = null;
	    this.viewTab = null;
	    this.totTab = null;
	    this.layout_CS = null; 
        this.layout_Chart = null;
	    this.CmtCal = 0;

	    var loadDelegate = MakeDelegate(this, this.OnLoad);
	    //        var unloadDelegate = MakeDelegate(this, this.OnUnload);
	    var HandlePingSessionData = MakeDelegate(this, this.HandlePingSession);
	    var HandlePopulateUI = MakeDelegate(this, this.PopulateUI);

	    this.deferevent = "";
	    this.deferedExternalEventDelegate = MakeDelegate(this, this.deferedExternalEvent);
	    this.deferedsetFocusDelegate = MakeDelegate(this, this.deferedsetFocus);


	    var GetCalendarInfoCompleteDelegate = MakeDelegate(this, this.GetCalendarInfoComplete);
	    var LoadResPlanDataCompleteDelegate = MakeDelegate(this, this.LoadResPlanDataComplete);

	    this.SaveCapacityScenarioDataCompleteDelegate = MakeDelegate(this, this.SaveCapacityScenarioDataComplete);

	    this.GetTotalsDataCompleteDelegate = MakeDelegate(this, this.GetTotalsDataComplete);
	    this.SetTotalsDataCompleteDelegate = MakeDelegate(this, this.SetTotalsDataComplete);
	    this.CreateTopGridDelegate = MakeDelegate(this, this.CreateTopGrid);

	    var GetCapacityScenarioListCompleteDelegate = MakeDelegate(this, this.GetCapacityScenarioListComplete);
	    var SaveCapacityScenarioListCompleteDelegate = MakeDelegate(this, this.SaveCapacityScenarioListComplete);


	    var GetEditCSDataCompleteDelegate = MakeDelegate(this, this.GetEditCSDataComplete);

	    var ReloadPlanDataCompleteDelegate = MakeDelegate(this, this.ReloadPlanDataComplete);
	    var SaveResourceAnalyzerViewCompleteDelegate = MakeDelegate(this, this.SaveResourceAnalyzerViewComplete);
	    var RenameResourceAnalyzerViewCompleteDelegate = MakeDelegate(this, this.RenameResourceAnalyzerViewComplete);


	    this.FinishTotalsDelegate = MakeDelegate(this, this.FinishTotals);
	    this.GoDoEditDelegate = MakeDelegate(this, this.GoDoEdit);
	    this.CapScenCreateCopyDelegate = MakeDelegate(this, this.CapScenCreateCopy);
	    this.CapScenCreateNewDelegate = MakeDelegate(this, this.CapScenCreateNew);
	    this.EditResPlanDelegate = MakeDelegate(this, this.EditResPlan);

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
	    var GridsOnMouseOverDelegate = MakeDelegate(this, this.GridsOnMouseOver);
	    var GridsOnMouseDownDelegate = MakeDelegate(this, this.GridsOnMouseDown);


	    var NewCapScenDlg_OnCloseDelegate = MakeDelegate(this, this.NewCapScenDlg_OnClose);


	    GridsOnFilterFinishDelegate = MakeDelegate(this, this.GridsOnFilterFinish);
	    var GridsOnReadyDelegate = MakeDelegate(this, this.GridsOnReady);



	    var GridsOnValueChangedDelegate = MakeDelegate(this, this.GridsOnValueChanged);
	    var AnalyzerViewDlg_OnCloseDelegate = MakeDelegate(this, this.AnalyzerViewDlg_OnClose);
	    var AnalyzerDeleteViewDlg_OnCloseDelegate = MakeDelegate(this, this.AnalyzerDeleteViewDlg_OnClose);

	    var CapScenDlg_OnCloseDelegate = MakeDelegate(this, this.CapScenDlg_OnClose);

	    var GridsOnRenderStartDelegate = MakeDelegate(this, this.GridsOnRenderStart);
	    var GridsOnRenderFinishDelegate = MakeDelegate(this, this.GridsOnRenderFinish);
	    var HandleRerenderDelegate = MakeDelegate(this, this.HandleRerender);
	    var HandleRerenderChecksDelegate = MakeDelegate(this, this.HandleRerenderChecks);
	    var HandleRerenderRollupsDelegate = MakeDelegate(this, this.HandleRerenderRollups);
	    var tabbarOnSelectDelegate = MakeDelegate(this, this.tabbarOnSelect);

        var GetTotalsGridChartDataCompleteDelegate =  MakeDelegate(this, this.GetTotalsGridChartDataComplete);

//<script src="/_layouts/ppm/Kendo/kendo.dataviz.min.js" type="text/javascript"></script>
//	    $.getScript("/_layouts/ppm/Kendo/kendo.dataviz.min.js", function (data, textStatus, jqxhr) {

	        //console.log(data); //data returned

	        //alert(textStatus); //success

	        //console.log(jqxhr.status); //200

	        //console.log('Load was performed.');

//	    });


 

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