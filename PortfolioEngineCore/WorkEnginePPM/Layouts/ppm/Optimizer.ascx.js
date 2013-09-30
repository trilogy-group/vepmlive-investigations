function Optimizer(thisID, params) {
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

    Optimizer.prototype.BuildLoadInf = function (sTicket, ListID, ViewID) {

        var dataXml = '<Load Ticket="' + sTicket + '" ListID="' + ListID + '" ViewID="' + ViewID + '">' + '</Load>';
        return dataXml;
    }




    Optimizer.prototype.OnLoad = function (event) {
        try {

            Grids.OnValueChanged = GridsOnValueChangedDelegate;
            Grids.OnGetDefaultColor = GridsOnGetDefaultColorDelegate;
            Grids.OnReady = GridsOnReadyDelegate;

            var s = this.BuildLoadInf(this.params.TicketVal, this.params.ListIdVal, this.params.ViewID);

            WorkEnginePPM.Optimizer.set_path(this.params.Webservice);


            WorkEnginePPM.Optimizer.ExecuteJSON("GetOptimizerData", s, LoadOptimizerDataCompleteDelegate);
        }
        catch (e) {
            alert("Optimizer OnLoad Exception");
        }
    }

	Optimizer.prototype.OnUnload = function (event) {
		if (this.Dirty && this.ExitConfirmed == false)
			event.returnValue = "You have unsaved changes.\n\nAre you sure you want to exit without saving?";
		this.ExitConfirmed = false;
	}
	Optimizer.prototype.OnResize = function (event) {
		if (this.initialized == true) {
			//var toolbarDataObjectDiv = document.getElementById("toolbarDataObjectDiv");
			var lHeight = this.Height;
			var divLayout = document.getElementById(this.params.ClientID + "layoutDiv");
			if (lHeight > 400) {
				divLayout.style.height = (lHeight /*- toolbarDataObjectDiv.offsetHeight*/ - 12) + "px";

	//			var lsplit = Math.floor((lHeight - 200) / 2);


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
	Optimizer.prototype.HandlePingSession = function () {
		try {
		    WorkEnginePPM.Optimizer.Execute("OptimizerSessionPing", "");
			this.PingSessionData();
		}
		catch (e) {

		}

	}
	Optimizer.prototype.PingSessionData = function () {

		try {


			window.setTimeout(HandlePingSessionData, 1000 * 60);
		}

		catch (e) {
		}
	}
	Optimizer.prototype.SetSize = function (nWidth, nHeight) {

		if (this.Width == nWidth && this.Height == nHeight)
			return;

		this.Width = nWidth;
		this.Height = nHeight;
		this.OnResize();
	}
	Optimizer.prototype.xmlStringToJson = function (xmlstring) {

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
	Optimizer.prototype.xmlToJson = function (xml) {

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
	Optimizer.prototype.BuildViewInf = function (viewGUID, viewName, isViewDefault, isViewPersonal, bConvToJSON) {
		if (isViewDefault == true) isViewDefault = 1; else if (isViewDefault == false) isViewDefault = 0;
		if (isViewPersonal == true) isViewPersonal = 1; else if (isViewPersonal == false) isViewPersonal = 0;

		var sTopGrid = this.BuildGridInf("g_1", false, false, this.AnalyzerTabisCollapsed);

		

		var dataXml = '<View ViewGUID="' + XMLValue(viewGUID) + '" Name="' + XMLValue(viewName) + '" Default="'
				+ isViewDefault + '" Personal="' + isViewPersonal + '">'
				+ sTopGrid
				+'</View>';

		if (bConvToJSON != true)
			return dataXml;


		return this.xmlStringToJson(dataXml);

	}
	Optimizer.prototype.BuildGridInf = function (gridId, showFilter, showGrouping, ribbonExpanded) {
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
	Optimizer.prototype.DoesColExist = function (allcols, thiscol) {
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
	Optimizer.prototype.ApplyGridView = function (gridId, view, bRender) {
	    try {

	        var grid = Grids[gridId];
	        var gridView = view[gridId];
	        var allCols = new Array();

	        var gcols = grid.GetCols();


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

	        //			try { grid.DoGrouping(null); } catch (e) { };
	        //			try {
	        //				for (var i = 0; i < groupCols.length; i++) {
	        //					grid.HideCol(groupCols[i]);
	        //				}
	        //			} catch (e) { };


	        try {
	            if (gridView.Cols !== null) {
	                var vCols = grid.GetCols('Visible');
	                vCols = vCols.concat(groupCols);

	                var mainCols = [];

	                //				var bhadFirstPer = false;

	                for (var i = 0; i < vCols.length; i++) {

	                    //						if (vCols[i] === "P1C1")
	                    //							bhadFirstPer = true;

	                    //						if (bhadFirstPer) {

	                    //							var per, sCol;

	                    //							sCol = vCols[i].substr(1, vCols[i].length - 2);
	                    //							per = parseInt(sCol);

	                    //							if (per >= StartID && per <= FinishID)
	                    //								allCols.push(vCols[i]);
	                    //							else {
	                    //								mainCols.push(vCols[i]);
	                    //							}

	                    //						} else {

	                    var found = false;
	                    for (var j = 0; j < allCols.length; j++) {
	                        if (allCols[j] === vCols[i]) {
	                            found = true;
	                        }
	                        //							}

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


	        //			try {
	        //				if (gridView['Filters'] === '') {
	        //					grid.ChangeFilter('', '', '', 0, 0, null);
	        //				} else {
	        //					var filters = gridView['Filters'].split('|');

	        //					if (filters[0] === '1') {
	        //						this.showFilters(grid);
	        //					} else {
	        //						this.hideFilters(grid);
	        //					}

	        //					filters[1] = filters[1].replace(",", ":");

	        //					var filter = filters[1].split(':');

	        //					var colvals = new Array();
	        //					var valvals = new Array();
	        //					var opvals = new Array();

	        //					if (filter.length > 2) {
	        //						var xi = 0;

	        //						for (var xj = 0; xj < filter.length; xj++) {
	        //							++xi;
	        //							if (xi == 1)
	        //								colvals[colvals.length] = filter[xj];

	        //							else if (xi == 2)
	        //								valvals[valvals.length] = filter[xj];

	        //							else {
	        //								opvals[opvals.length] = filter[xj];
	        //								xi = 0;
	        //							}
	        //						}

	        //						try { grid.ChangeFilter(colvals, valvals, opvals, 0, 0, null); } catch (e) { };

	        //					}



	        //				}
	        //			}
	        //			catch (e) { }


	        //			try {
	        //				grid.ChangeSort(gridView['Sorting']);
	        //			} catch (e) { }
	        //			



	        //			if (gridView['Grouping'] === '') {
	        //				try { grid.DoGrouping(null); } catch (e) { };
	        //			} else {
	        //				var grouping = gridView['Grouping'].split('|');

	        //				if (grouping[0] === '1') {
	        //					this.showGrouping(grid);
	        //				} else {
	        //					this.hideGrouping(grid);
	        //				}

	        ///				try {

	        //				    grid.DoGrouping("PISelected");
	        //				}
	        //				catch (e) { };


	        //				    this.hideGrouping(grid);
	        //				    this.hideFilters(grid);

	        //				    grid.ExpandAll(null, 0, 3);

	        //			}

	        try {
	            //				if (bRender)
	            //					grid.Render();
	        }
	        catch (e) { };


	    } catch (e) {
	        this.HandleException("ApplyGridView", e);
	    }
	}
	Optimizer.prototype.flashGridView = function (gridId, bDoRender) {
		try {

			var grid = Grids[gridId];
			var allCols = new Array();

			var gcols = grid.GetCols();
			var vCols = grid.GetCols('Visible');

			var mainCols = [];
			var bhadFirstPer = false;

			for (var i = 0; i < gcols.length; i++) {


				var found = false;
				for (var j = 0; j < allCols.length; j++) {
					if (allCols[j] === gcols[i]) {
						found = true;
					}
				}

				if (!found)
					mainCols.push(gcols[i]);
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
	Optimizer.prototype.SaveOptimizerViewComplete = function (jsonString) {
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
			this.HandleException("SaveOptimizerViewComplete", e);
		}
	}
	Optimizer.prototype.RenameOptimizerViewComplete = function (jsonString) {
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
			this.HandleException("RenameOptimizerViewComplete", e);
		}
	}


	// >>>>>> Totals area


	Optimizer.prototype.SetChangeViewComplete = function (jsonString) {

		try {
			var jsonObject = JSON_ConvertString(jsonString);
			if (JSON_ValidateServerResult(jsonObject)) {
				this.TotalsGridSettingsData = jsonObject.Result.ViewData.TotalsGridSetting;

				this.TotalsGridSupressHeatmap = this.TotalsGridSettingsData.HeatMap.HeapMapSubCol;
				this.TotalsGridTotalsCol = this.TotalsGridSettingsData.HeatMap.HeapMapTotalsCol;
				
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
	// >>>> Showing initalizing the grids and menus

	var RefreshBothGrids = function () {

		try {


			window.setTimeout(HandleRefreshBothDelegate, 400);
		}

		catch (e) {
		}
	}

	Optimizer.prototype.HandleBothRefresh = function () {

		try {
			if (this.DetGrid != null)
				this.DetGrid.Reload(null);


		}
		catch (e) {

		}

	}
	Optimizer.prototype.InitializeLayout = function () {
	    try {







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
									{ type: "smallbutton", id: "idViewTab_RemoveSorting", name: "Clear Sorting", img: "clearsort.gif", tooltip: "Remove Sorting", onclick: "dialogEvent('AnalyzerTab_RemoveSorting_Click');" },

									{ type: "smallbutton", id: "SelectColumnsBtn", name: "Select Columns", img: "selectcolumn.gif", tooltip: "Select Columns", onclick: "dialogEvent('AnalyzerTab_SelectColumns');" }

								]
							},
							{
							    items: [
									{ type: "text", name: "Current View:" }
							    ]
							},
							{
							    items: [

									{ type: "select", id: "idAnalyzerTab_SelView", onchange: "dialogEvent('AnalyzerTab_SelView_Changed');", width: "100px" }
							   ]
							}
						 ]
			         }
	            ]
	        };





	        this.layout = new dhtmlXLayoutObject(this.params.ClientID + "layoutDiv", "2E", "dhx_skyblue");
	        this.layout.cells(this.mainRibbonArea).setText("Analyzer");
	        this.layout.cells(this.mainArea).setText("Main Area");

	        this.layout.cells(this.mainRibbonArea).hideHeader();
	        this.layout.cells(this.mainArea).hideHeader();

	        this.layout.cells(this.mainArea).attachObject("gridDiv_1");


	        this.Tabbar = this.layout.cells(this.mainRibbonArea).attachTabbar();
	        this.Tabbar.attachEvent("onSelect", function (id) { tabbarOnSelectDelegate(id, arguments); return true; });



	        this.viewTab = new Ribbon(viewTabData);
	        this.viewTab.Render();


	        this.OptTab = this.optimalprime.getOptimizerRibbon("idOptimizerTabDiv", "dialogEvent('TopRibbon_Toggle');", this.imagePath, this.Tabbar, this.viewTab);


	        this.layout.cells(this.mainArea).setHeight(200);



	        this.layout.cells(this.mainRibbonArea).setHeight(120);


	        this.layout.cells(this.mainRibbonArea).setHeight(120);
	        this.layout.cells(this.mainRibbonArea).fixSize(false, true);

	        this.layout._minHeight = 18;


	        this.Tabbar.setTabActive("tab_Opt");



	    }
	    catch (e) {
	        alert("Optimizer InitializeLayout Exception");
	    }
	}
    
    Optimizer.prototype.ShowWorkingPopup = function (divid) {
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
    
    Optimizer.prototype.HideWorkingPopup = function (divid) {
        var div = $('#' + divid);
        div.hide();
        var veil = $('#veil');
        veil.hide();
    };

    Optimizer.prototype.LoadOptimizerDataComplete = function (result) {
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

                if (jsonObject.Result.OptData.Optimizer.Permissions.Allowed == 0) {

                    alert("You do not have the Global Permission set to access this functionality!");

                    if (parent.SP.UI.DialogResult)
                        parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
                    else
                        parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');
                    return;
                }


                this.optimalprime = new OptimizerRibbon(jsonObject.Result.OptData.Optimizer, this.params, "idOptDlg");

                this.piItems = this.optimalprime.getOptimizerPIItems();

                var sInject = this.optimalprime.getOptimizerDlgInjectHtml()
                document.getElementById("idOptDlg").innerHTML = sInject;


                var views = jsonObject.Result.Views;
                this.Views = JSON_GetArray(views, "View");

                var strats = jsonObject.Result.Stratagies;
                var stratarr = JSON_GetArray(strats, "Stratagy");

                this.optimalprime.SetInitialStratagies(stratarr);

                this.InitializeLayout();

                window.setTimeout(HandlePopulateUI, 200);

                this.PingSessionData();
            }
        }
        catch (e) {
            this.HandleException("LoadOptimizerDataComplete", e);
            if (parent.SP.UI.DialogResult)
                parent.SP.UI.ModalDialog.commonModalDialogClose(parent.SP.UI.DialogResult.OK, '');
            else
                parent.SP.UI.ModalDialog.commonModalDialogClose(0, '');

        }
    }

	Optimizer.prototype.HandleRerender = function () {

		if (this.refreshIconsInTotGrid != null) {
			for (var i = 0; i < this.refreshIconsInTotGrid.length; i++) {
				this.TotGrid.RefreshCell(this.refreshIconsInTotGrid[i], "IconFlag");
			}
			this.refreshIconsInTotGrid = null;
		}

	}


	Optimizer.prototype.PopulateUI = function () {

	    try {
	        var selectviews = document.getElementById("idAnalyzerTab_SelView");
	        selectviews.options.length = 0;

	        if (this.Views.length == 0) {
	            selectviews.options[0] = new Option("-- No View --",0, true, true);
	        }
	        else {
	            for (var i = 0; i < this.Views.length; i++) {
	                var view = this.Views[i];


	                if (this.bapplyDefView == true || view.Default == 0)
	                    selectviews.options[selectviews.options.length] = new Option(view.Name, view.ViewGUID, false, false);
	                else {

	                    this.bapplyDefView = (view.Default == 1)
	                    selectviews.options[selectviews.options.length] = new Option(view.Name, view.ViewGUID, this.bapplyDefView, this.bapplyDefView);
	                }
	            }
	        }


	        if (selectviews.options.length == 0)
	            selectviews.disabled = true;
	        else
	            selectviews.disabled = false;

	        this.selectedView = this.GetSelectedView();
	        this.bapplyDefView = true;   // this stops the autoselection next time through this code if there was no default view previously defined

	        this.SetViewChanged(null);


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

	Optimizer.prototype.CreateTopGrid = function (jsonString) {

	    try {

	        if (jsonString == undefined || jsonString == "") {
	            this.TotalsGridSettingsData = null;

	            this.TotalsGridSupressHeatmap = 0;
	        }


	        this.stashgridsettings = null;
	        var sbDataxml = new StringBuilder();
	        sbDataxml.append('<![CDATA[');
	        sbDataxml.append('<Execute Function="GetProjectGridData">');
	        sbDataxml.append('</Execute>');
	        sbDataxml.append(']]>');

	        var sb = new StringBuilder();
	        sb.append("<treegrid SuppressMessage='3' debug='0' sync='0' ");
	        sb.append(" Export_Url='rpaExportExcel.aspx'");
	        sb.append(" data_url='" + this.Webservice + "'");
	        sb.append(" data_method='Soap'");
	        sb.append(" data_function='Execute'")
	        sb.append(" data_namespace='WorkEnginePPM'");
	        sb.append(" data_param_Function='GetProjectGridData'");
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

	Optimizer.prototype.GridsOnValueChanged = function (grid, row, col, val) {
	    if (grid.id != "g_1")
	        return val;

	    if (col == "PIStatus") {


	        var imode = 0;
	        var selled = 0;

	        if (val == "In")
	            imode = 1;
	        else if (val == "Out")
	            imode = 2;
	        else
	            imode = 3;

	        var pid = grid.GetString(row, "pid");
	        var item = null;

	        for (var i = 0; i < this.piItems.length; i++) {
	            if (this.piItems[i].ID == pid) {
	                item = this.piItems[i];
	                break;
	            }

	        }

	        if (item != null) {

	            var bstash = item.isSel;

	            if (imode == 3)
	                item.isSel = item.isFilterSel;
	            else if (imode == 1)
	                item.isSel = true;
	            else {
	                item.isSel = false;
	            }

	            item.statusMode = imode;
	            //	            if (item.isSel == true) {
	            //	                grid.SetString(row, "PISelected", "Selected", 1);
	            //	            } else {
	            //	                grid.SetString(row, "PISelected", "Unselected", 1);
	            //	            }

	            selled = (item.isSel == true ? "1" : "0");
	            var selr = null;
	            var unselr = null;

	            if (bstash != item.isSel) {
	                selr = grid.Rows['AR1'];
	                unselr = grid.Rows['AR2'];

	                if (item.isSel == true) {
	                    grid.MoveRow(row, selr, null, true);
	                } else {
	                    grid.MoveRow(row, unselr, null, true);
	                }

	            }

	            this.optimalprime.updateRibbonDueToUserChange();




	            WorkEnginePPM.Optimizer.Execute("SetPIStatusModeChange", pid + " " + imode + " " + selled);

	        }
	    }



	    return val;


	}


    Optimizer.prototype.CheckIfRowFiltered = function (grid, row) {
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


	Optimizer.prototype.GetSelectedView = function () {
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

	Optimizer.prototype.AnalyzerViewDlg_OnClose = function () {
		this.AnalyzerViewDlg.window("winOptimizerViewDlg").detachObject()
		this.AnalyzerViewDlg = null;
	}


	Optimizer.prototype.AnalyzerDeleteViewDlg_OnClose = function () {
		this.AnalyzerDeleteViewDlg.window("winOptimizerDeleteViewDlg").detachObject()
		this.AnalyzerDeleteViewDlg = null;
	}

	Optimizer.prototype.DeleteOptimizerViewComplete = function (jsonString) {
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

    Optimizer.prototype.InitTopGrid = function () {

        //       var grid = Grids["g_1"];
        this.HideWorkingPopup("divLoading");
        this.bottomgridfirstready = true;
        this.OptimizerEvent("OptiChange");

        this.optimalprime.DataLoadComplete();

        //        grid.ExpandAll(null, 0, 3);       
    }



    Optimizer.prototype.GridsOnReady = function (grid, start) {
        try {

            if (grid.id == "g_1") {
                this.topgridready = true;

                this.initialized = true;
                this.OnResize();
            }
            
            if (this.bottomgridfirstready == false) {



                window.setTimeout(this.InitTopGridDelegate, 100);

            }



            //	        if (this.doTopApply == false && this.doBottomApply == false && this.stashgridsettings != null && (grid.id == "g_1" || grid.id == "bottomg_1")) {

            //	            this.ApplyGridView(grid.id, this.stashgridsettings.View, false);
            //	        }
            //	        else if (this.bottomgriddragstash != null && grid.id == "bottomg_1") {
            //	            this.ApplyGridView(grid.id, this.bottomgriddragstash.View, false);
            //	            this.bottomgriddragstash = null;
            //	            return;
            //	        }
            //	        else if (this.topgridstash != null && grid.id == "g_1") {
            //	            this.ApplyGridView(grid.id, this.topgridstash.View, false);
            //	            this.topgridstash = null;
            //	            return;
            //	        }


        }
        catch (e) { };



        try {



            if (grid.id == "g_1") {









                if (this.selectedView != null && this.doTopApply == true)
                    this.ApplyGridView(grid.id, this.selectedView, true);



                this.doTopApply = false;

            }



        }
        catch (e) {
            this.HandleException("GridsOnReady", e);
        }
    }


	Optimizer.prototype.HandleRerenderRollups = function () {
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

	Optimizer.prototype.CheckLeafValuesareSame = function (grid, row, col) {

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

   Optimizer.prototype.CalcTotals = function (grid, row) {




       try {

           var allcols = grid.GetCols();
           for (var c in allcols) {
               var cn = allcols[c];

               if (cn.substr(0, 2) == "zX") {
                   if (grid.GetString(row, cn) != "")
                       grid.SetString(row, cn, this.SumLeafValues(grid, row, cn), 0);





               }
           }
       } catch (e) {

       }
   }



    Optimizer.prototype.SumLeafValues = function (grid, row, col) {

        var children;
        children = row.firstChild;

        if (children == null) {
            var rowv = grid.GetString(row, col);
            return parseInt(rowv);
        }

        var val = 0;

        while (children != null) {
            val = val + grid.GetString(children, col);
            children = children.nextSibling;
        }

        return val;
    }

	Optimizer.prototype.GridsOnGetDefaultColor = function (grid, row, col, r, g, b) {


	    if (grid.id == "g_1") {

	        if (row.id == "Filter")
	            return null;

	        if (row.Kind == "Data") {

	            if (col == "PISelected") {
	                var pid = grid.GetValue(row, "pid");

	                for (var xi = 0; xi < this.piItems.length; xi++) {
	                    var item = this.piItems[xi];

	                    if (pid == item.ID) {
	                        item.rowid = row.id;
	                        break;
	                    }
	                }

	            }
	        }


	        if (row.firstChild == null || row.id == "Filter")
	            return null;



	        // this is where we need to check the children to see if they all have the same value and if so set this rows col to that value....

//	        if (grid.Cols[col].Sec == 1 && this.tg_rollup_render == false) {
//	            var rowv = grid.GetString(row, col);

//	            if (rowv == "") {
//	                this.GrpColVal = "";
//	                this.GrpColValSet = false;


//	                if (this.CheckLeafValuesareSame(grid, row, col) == true) {
//	                    if (this.tg_rollup == null) {
//	                        this.tg_rollup = new Array();
//	                        window.setTimeout(HandleRerenderRollupsDelegate, 400);
//	                    }

//	                    var o = new Object();

//	                    o.Row = row;
//	                    o.Col = col;

//	                    grid.SetAttribute(row, col, null, this.GrpColVal, 1);
//	                    //  o.val = this.GrpColVal;

//	                    //          if (this.tg_rollup_render == false)
//	                    this.tg_rollup.push(o);
//	                }

//	            }


//	        }


	        return this.groupColour;
	    }

	    if (row.firstChild == null)
	        return null;


	    if (row.firstChild == null || row.id == "Filter")
	        return null;




	    return this.groupColour;

	}

	var RefreshBottomGrid = function () {

		try {


			window.setTimeout(HandleRefreshDelegate, 700);
		}

		catch (e) {
		}
	}


	Optimizer.prototype.HandleRefresh = function () {

	    try {

	        if (this.TopGridDragged == true) {
	            this.TopGridDragged = false;

	            if (this.DetGrid != null)
	                this.DetGrid.Render();
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

	Optimizer.prototype.HandleTopRefresh = function () {

		try {
			if (this.DetGrid != null) {

				this.DetGrid.Reload(null);
			}

		}
		catch (e) {

		}

	}

	Optimizer.prototype.SetViewChanged = function (selindex) {

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

		if (oldguid == newguid && selindex == null)
			return;

	}



	Optimizer.prototype.deferExternalEvent = function (event) {
		this.deferevent = event;

		window.setTimeout(this.deferedExternalEventDelegate, 200);
	}

	Optimizer.prototype.deferedExternalEvent = function () {
		this.externalEvent(this.deferevent);
		this.deferevent = "";
	}

	Optimizer.prototype.setNewButtonDisable = function (idButton, bstate) {

		var btn = document.getElementById(idButton);

		if (btn == null)
		    return;
		btn.disabled = bstate;

		return;
		
		//if (bstate == true)
		//	btn.className = "button-new disabledSilver";
		//else 
		//   btn.className = "button-new silver";

    }

    Optimizer.prototype.OptimizerEventComplete = function (result) {
        if (this.lastReply.Passback == true) {

            this.optimalprime.StashReturnData(result);
            this.optimalprime.handleExternalEvent(this.lastReply.PassbackFunction);
        }
    }


    Optimizer.prototype.OptimizerEvent = function (event) {

        try {
            var oRep = this.optimalprime.handleExternalEvent(event);

            this.lastReply = oRep;

            if (oRep != null) {
                if (oRep.Mode == "RaiseEvent") {
                    WorkEnginePPM.Optimizer.Execute(oRep.Action, oRep.Data);
                }
                else if (oRep.Mode == "RaiseEventJSON") {
                    WorkEnginePPM.Optimizer.ExecuteJSON(oRep.Action, oRep.Data, OptimizerEventCompleteDelegate);
                }
                else if (oRep.Mode == "Close") {
                    this.externalEvent("AnalyzerTab_Close");
                }
                else if (oRep.Mode == "OptiChange") {
                    var grid = Grids["g_1"];
                    var selr = grid.Rows['AR1'];
                    var unselr = grid.Rows['AR2'];

                    for (var i = 0; i < this.piItems.length; i++) {
                        var item = this.piItems[i];
                        if (item.isSel != item.stashsel) {

                            if (item.rowid != "") {
                                var row = grid.Rows[item.rowid];

                                if (item.isSel == true) {
                                    //        grid.SetString(row, "PISelected", "Selected", 1);
                                    grid.MoveRow(row, selr, null, true);
                                } else {
                                    //          grid.SetString(row, "PISelected", "Unselected", 1);
                                    grid.MoveRow(row, unselr, null, true);
                                }
                            }
                        }
                    }

                    this.CalcTotals(grid, selr);
                    this.CalcTotals(grid, unselr);

                    grid.Render();
                    WorkEnginePPM.Optimizer.Execute(oRep.Action, oRep.Data);
                    window.setTimeout(this.ffDeferedRenderDelegate, 100);


                }
            }
        }

        catch (e) {
            this.HandleException("OptimizerEvent", e);
        }
    }

    Optimizer.prototype.ffDeferedRender = function (event) {
        var grid = Grids["g_1"];
        grid.Render();
    }
	Optimizer.prototype.externalEvent = function (event) {

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


	        switch (event) {



	            case "ViewChanged":
	                this.SetViewChanged(viewid);

	                break;

	            case "TopRibbon_Toggle":

	                if (this.viewTab.isCollapsed() == true) {
	                    this.layout.cells(this.mainRibbonArea).fixSize(false, false);
	                    this.layout.cells(this.mainRibbonArea).setHeight(120);
	                    this.layout.cells(this.mainRibbonArea).fixSize(false, true);
	                    this.viewTab.expand();
	                    this.OptTab.expand();

	                } else {
	                    this.layout.cells(this.mainRibbonArea).fixSize(false, false);
	                    this.layout.cells(this.mainRibbonArea).setHeight(50);
	                    this.layout.cells(this.mainRibbonArea).fixSize(false, true);
	                    this.viewTab.collapse();
	                    this.OptTab.collapse();

	                }
	                break;



	            case "AnalyzerTab_SelView_Changed":
	                this.SetViewChanged(null);
	                RefreshTopGrid();
	                break;


	            case "AnalyzerTab_RenameView":

	                if (this.Views.length == 0) {
	                    alert("No views have been saved to be renamed!");
	                    break;
	                }

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
	                    this.AnalyzerViewDlg.createWindow("winOptimizerViewDlg", 20, 30, 280, 142);
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").setIcon("logo.ico", "logo.ico");
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").denyResize();
	                    //this.AnalyzerViewDlg.window("winOptimizerViewDlg").button("close").disable();
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").button("park").hide();
	                    //this.AnalyzerViewDlg.setSkin(this.params.DHTMLXSkin);
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").setModal(true);
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").center();
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").setText("Rename View");
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").attachEvent("onClose", function (win) { AnalyzerViewDlg_OnCloseDelegate(); return true; });
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").attachObject("idRenameViewDlg");
	                }
	                else {
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").show();
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

	                    if (this.Views.length != 0)
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
	                    this.AnalyzerViewDlg.createWindow("winOptimizerViewDlg", 20, 30, 280, 192);
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").setIcon("logo.ico", "logo.ico");
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").denyResize();
	                    //this.AnalyzerViewDlg.window("winOptimizerViewDlg").button("close").disable();
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").button("park").hide();
	                    //this.AnalyzerViewDlg.setSkin(this.params.DHTMLXSkin);
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").setModal(true);
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").center();
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").setText("Save View");
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").attachEvent("onClose", function (win) { AnalyzerViewDlg_OnCloseDelegate(); return true; });
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").attachObject("idSaveViewDlg");
	                }
	                else {
	                    this.AnalyzerViewDlg.window("winOptimizerViewDlg").show();
	                }
	                break;

	            case "AnalyzerTab_DeleteView":
	                document.getElementById("id_DeleteView_Name").value = "";
	                var selectView = document.getElementById("idAnalyzerTab_SelView");

	                if (this.Views.length == 0) {
	                    alert("No views have been saved to be deleted!");
	                    break;
	                }

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
	                    this.AnalyzerDeleteViewDlg.createWindow("winOptimizerDeleteViewDlg", 20, 30, 280, 157);
	                    this.AnalyzerDeleteViewDlg.window("winOptimizerDeleteViewDlg").setIcon("logo.ico", "logo.ico");
	                    this.AnalyzerDeleteViewDlg.window("winOptimizerDeleteViewDlg").denyResize();
	                    //this.ViewDlg.window("winViewDlg").button("close").disable();
	                    this.AnalyzerDeleteViewDlg.window("winOptimizerDeleteViewDlg").button("park").hide();
	                    //this.ViewDlg.setSkin(this.params.DHTMLXSkin);
	                    this.AnalyzerDeleteViewDlg.window("winOptimizerDeleteViewDlg").setModal(true);
	                    this.AnalyzerDeleteViewDlg.window("winOptimizerDeleteViewDlg").center();
	                    this.AnalyzerDeleteViewDlg.window("winOptimizerDeleteViewDlg").setText("Delete View");
	                    this.AnalyzerDeleteViewDlg.window("winOptimizerDeleteViewDlg").attachEvent("onClose", function (win) { AnalyzerDeleteViewDlg_OnCloseDelegate(); return true; });
	                    this.AnalyzerDeleteViewDlg.window("winOptimizerDeleteViewDlg").attachObject("idDeleteViewDlg");
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

	                WorkEnginePPM.Optimizer.ExecuteJSON("SaveOptimizerView", sbd.toString(), SaveOptimizerViewCompleteDelegate);
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

	                WorkEnginePPM.Optimizer.ExecuteJSON("RenameOptimizerView", sbd.toString(), RenameOptimizerViewCompleteDelegate);
	                break;

	            case "SaveView_Cancel":
	            case "RenameView_Cancel":
	                this.AnalyzerViewDlg.window("winOptimizerViewDlg").setModal(false);
	                this.AnalyzerViewDlg.window("winOptimizerViewDlg").hide();
	                this.AnalyzerViewDlg.window("winOptimizerViewDlg").detachObject()
	                this.AnalyzerViewDlg = null;
	                break;

	            case "DeleteView_Cancel":
	                this.AnalyzerDeleteViewDlg.window("winOptimizerDeleteViewDlg").setModal(false);
	                this.AnalyzerDeleteViewDlg.window("winOptimizerDeleteViewDlg").hide();
	                this.AnalyzerDeleteViewDlg.window("winOptimizerDeleteViewDlg").detachObject()
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

	            case "AnalyzerTab_ExporttoExcel":
	                grid = Grids["g_1"];
	                grid.Source.Export.Type = "xls";
	                grid.ActionExport();
	                break;

	            case "AnalyzerTab_Print":
	                grid = Grids["g_1"];
	                grid.ActionPrint();
	                break;



	            case "AnalyzerTab_RemoveSorting_Click":
	                grid = Grids["g_1"];


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
	                    sbd.append('<Execute Function="DeleteOptimizerView">');
	                    sbd.append('<View ViewGUID="' + XMLValue(deleteViewGuid) + '" />');
	                    sbd.append('</Execute>');

	                    WorkEnginePPM.Optimizer.ExecuteJSON("DeleteOptimizerView", sbd.toString(), DeleteOptimizerViewCompleteDelegate);
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


	Optimizer.prototype.showFilters = function (grid) {
	    try {
	        grid.ShowRow(grid.GetRowById("Filter"));

	    }
	    catch (e) {}
	}

	Optimizer.prototype.hideFilters = function (grid) {

	    try {
	        grid.HideRow(grid.GetRowById("Filter"));
	        grid.Render();
	    }
	    catch (e) { }
	}


	Optimizer.prototype.getGroupRow = function (grid) {
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

	Optimizer.prototype.showGrouping = function (grid) {
	    var groupRow = this.getGroupRow(grid);
	    if (groupRow != null) {
	        groupRow.Visible = 1;
	    }
	}

	Optimizer.prototype.hideGrouping = function (grid) {
	    var groupRow = this.getGroupRow(grid);
	    if (groupRow != null) {
	        groupRow.Visible = 0;
	    }
	}

					
	Optimizer.prototype.HandleException = function (sWhere, e) {
		alert("Error " + sWhere + " : " + e.toString());
	}


	Optimizer.prototype.tabbarOnSelect = function (id, data) {
	    if (this.viewTab.isCollapsed() == true) {
			this.layout.cells(this.mainRibbonArea).fixSize(false, false);
			this.layout.cells(this.mainRibbonArea).setHeight(120);
			this.layout.cells(this.mainRibbonArea).fixSize(false, true);
			this.OptTab.expand();
			this.viewTab.expand();
		}
	}

	Optimizer.prototype.flashRibbonSelect = function (idsel) {
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


	Optimizer.prototype.ribbonGetSelectValue = function (idsel) {
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
	
	 Optimizer.prototype.ribbonSetSelectValue = function (idsel, indval) {
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

        this.optimalprime = null;
		this.fromresource = "";
		// Initialised fields
		this.dlgShowGridEx = null;

         this.piItems = null;

		
		this.groupColour = 0xF8F8F8;

		this.bapplyDefView = false;

		this.analyzerCalID = 0;
		this.CmtCal = 0;
		this.csCalID = 0;

		this.tg_rollup = null;
		this.tg_rollup_render = false;

		this.topgridready = false;
		this.bottomgridready = false;
	    this.bottomgridfirstready = false;


		this.FilteredTop = new Array();


		this.AnalyzerTabisCollapsed = false;
		this.TotalTabisCollapsed = false;

		this.bInColResize = false;


		this.params = params;
		this.clientID = this.params.ClientID;
		this.Webservice = params.Webservice;

		this.mainRibbonArea = "a";
		this.mainArea = "b";

		this.viewTab = null;
		

		
		this.Dirty = false;
		this.initialized = false;
		this.ExitConfirmed = false;
		this.Height = 0;
		this.Width = 0;
   
		this.layout = null;

		this.TotGrid = null;
		this.DetGrid = null;

		this.FilterDifferent = false;
		this.CSChanged = false;


		this.selectCalendarAndPeriods = null;
		this.imagePath = "/_layouts/ppm/images/";

		// dialog handles


		this.Views = null;
		this.selectedView = null;


		this.stashgridsettings = null;

		this.AnalyzerViewDlg = null;
		this.AnalyzerDeleteViewDlg = null;

		this.doTopApply = true;
		this.doBottomApply = true;


		this.bottomgriddragstash = null;
		this.topgridstash = null;





		var OptimizerEventCompleteDelegate = MakeDelegate(this, this.OptimizerEventComplete);
        this.lastReply = null;

	   

		var loadDelegate = MakeDelegate(this, this.OnLoad);
//        var unloadDelegate = MakeDelegate(this, this.OnUnload);
		var HandlePingSessionData = MakeDelegate(this, this.HandlePingSession);
		var HandlePopulateUI = MakeDelegate(this, this.PopulateUI);

		this.deferevent = "";
		this.deferedExternalEventDelegate = MakeDelegate(this, this.deferedExternalEvent);
		this.ffDeferedRenderDelegate = MakeDelegate(this, this.ffDeferedRender);

		
		
		var LoadOptimizerDataCompleteDelegate = MakeDelegate(this, this.LoadOptimizerDataComplete);

		this.CreateTopGridDelegate = MakeDelegate(this, this.CreateTopGrid);

		var SaveOptimizerViewCompleteDelegate = MakeDelegate(this, this.SaveOptimizerViewComplete);
		var RenameOptimizerViewCompleteDelegate = MakeDelegate(this, this.RenameOptimizerViewComplete);
		
		this.LastFilterString = "";

		var GridsOnGetDefaultColorDelegate = MakeDelegate(this, this.GridsOnGetDefaultColor);
		var HandleRefreshBothDelegate = MakeDelegate(this, this.HandleBothRefresh);
		var HandleRefreshTopDelegate = MakeDelegate(this, this.HandleTopRefresh);
		var HandleRefreshDelegate = MakeDelegate(this, this.HandleRefresh);
		var SetChangeViewCompleteDelegate = MakeDelegate(this, this.SetChangeViewComplete);
		var DeleteOptimizerViewCompleteDelegate = MakeDelegate(this, this.DeleteOptimizerViewComplete);
	



		var GridsOnReadyDelegate = MakeDelegate(this, this.GridsOnReady);
		


		var GridsOnValueChangedDelegate = MakeDelegate(this, this.GridsOnValueChanged);
		var AnalyzerViewDlg_OnCloseDelegate = MakeDelegate(this, this.AnalyzerViewDlg_OnClose);
		var AnalyzerDeleteViewDlg_OnCloseDelegate = MakeDelegate(this, this.AnalyzerDeleteViewDlg_OnClose);

	
		this.refreshIconsInTotGrid = null; 
		this.refreshChecksInDetGrid = null;
		var HandleRerenderDelegate = MakeDelegate(this, this.HandleRerender);
		var HandleRerenderRollupsDelegate = MakeDelegate(this, this.HandleRerenderRollups);

		this.InitTopGridDelegate = MakeDelegate(this, this.InitTopGrid);
		

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
		alert("Optimizer Initialization error");
	}
	

}