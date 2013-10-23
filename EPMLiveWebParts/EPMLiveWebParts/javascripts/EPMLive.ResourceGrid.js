/// <version>4.4.0.32813</version>
/// <reference path="references/knockout-1.2.1.debug.js" />
/// <reference path="references/jquery-1.7.1.js" />

function registerEpmLiveResourceGridScript() {
    (function ($$, $$$, $, k, undefined) {
        $$.id = k.observable(null);
        $$.autoFocus = true;
        $$.maxVScroll = null;
        $$.webpartQualifier = null;
        $$.pfeInstalled = false;
        $$.firstLoad = true;
        $$.epmrgv = null;
        $$.resourceDictionary = null;
        $$.resources = null;
        $$.myResources = null;
        $$.exportInProgress = false;
        $$.importInProgress = false;
        $$.webpartHeight = false;
        $$.userIsSiteAdmin = false;
        $$.allSelected = false;

        $$.reports = {
            wcReportId: null,
            opened: false,
            collection: {
                workvscapacity: {
                    name: 'Resource Work vs. Capacity',
                    hasResourcesParam: true,
                    url: '{0}/_layouts/ReportServer/RSViewerPage.aspx?rv:RelativeReportUrl={1}/Report Library/Resource Work vs. Capacity.rdl&rp:SiteId={2}&rp:URL={1}&rv:HeaderArea=none'.format($$$.currentWebFullUrl, $$$.currentWebUrl, $$$.currentSiteId)
                }
            },

            getXmlForRibbon: function () {
                var sb = new window.Sys.StringBuilder();
                var loaded = false;

                sb.append("<Menu Id='Ribbon.ResourceGrid.Views.Dropdown.Menu'>");

                sb.append("<MenuSection DisplayMode='Menu' Id='Ribbon.ResourceGrid.Reporting.ReportsDropDown.Menu' Title='Reports'>");
                sb.append("<Controls Id='Ribbon.ResourceGrid.Reporting.ReportsDropDown.Menu.Controls'>");

                var collection = $$.reports.collection;

                for (var reportId in collection) {
                    if (collection.hasOwnProperty(reportId)) {
                        if (reportId !== 'workvscapacity') {
                            loaded = true;
                            var report = collection[reportId];
                            sb.append("<Button Id='Ribbon.ResourceGrid.Reports.{0}' Command='ResourceGrid.Cmd.ReportsDropDown.Select' LabelText=\"{1}\" CommandValueId='{0}'/>".format(reportId, report.name));
                        }
                    }
                }

                if (!loaded) {
                    sb.append("<Button Id='Ribbon.ResourceGrid.Reports.{0}' Command='ResourceGrid.Cmd.ReportsDropDown.Select' LabelText='{1}' CommandValueId='{0}'/>".format('Loading', 'Loading...'));
                }

                sb.append('</Controls>');
                sb.append('</MenuSection>');

                sb.append('</Menu>');

                return sb.toString();
            },

            open: function (reportId) {
                if (!reportId || reportId === '0' || reportId === 0 || reportId === 'Loading') return;

                $$.reports.opened = true;

                var grid = $$.grid.grids[$$.id()];
                var selRows = grid.GetSelRows();

                var queryString = '';

                if ($$.reports.collection[reportId].hasResourcesParam) {
                    for (var j = 0; j < selRows.length; j++) {
                        var sr = selRows[j];

                        if (sr.Kind === 'Data' && sr.Def.Name === 'R') {
                            queryString += '&rp:Resources=' + sr.ResourceID;
                        }
                    }
                }

                $$.reports.opened = true;

                window.open($$.reports.collection[reportId].url + queryString);

                window.setTimeout(function () {
                    $$.reports.opened = false;
                }, 2000);
            },

            load: function () {
                function register(folders) {
                    if (!folders.length) {
                        folders = [folders];
                    }

                    for (var i = 0; i < folders.length; i++) {
                        var folder = folders[i];

                        if (folder['@Name'] === 'epmlivetl') {
                            if (!folder.Folder.length) {
                                folder.Folder = [folder.Folder];
                            }

                            for (var j = 0; j < folder.Folder.length; j++) {
                                var fldr = folder.Folder[j];

                                if (fldr['@Name'] === '(2) Resource' || fldr['@Name'] === 'Resources') {
                                    if (!fldr.Folder || !fldr.Folder.length) {
                                        fldr.Folder = [fldr];
                                    }

                                    for (var l = 0; l < fldr.Folder.length; l++) {
                                        var fld = fldr.Folder[l];

                                        for (var m = 0; m < fld.Report.length; m++) {
                                            var report = fld.Report[m];
                                            var name = report['@Name'];

                                            $$.reports.collection[$$$.md5(name)] = { name: name, url: report['@Url'], hasResourcesParam: report['@HasResourcesParam'] === 'True' };
                                        }
                                    }

                                    break;
                                }
                            }

                            break;
                        }
                    }
                };

                $.ajax({
                    type: 'POST',
                    url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'Reporting_GetAllReports', Dataxml: '<Reports/>' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',

                    success: function (response) {
                        if (response.d) {
                            var responseJson = $$$.parseJson(response.d);

                            var result = responseJson.Result;

                            if ($$$.responseIsSuccess(result)) {
                                if (result.GetAllReports.Data.Folder && result.GetAllReports.Data.Folder.Folder) {
                                    register(result.GetAllReports.Data.Folder.Folder);
                                }
                            } else {
                                $$$.logFailure(result);
                            }
                        } else {
                            $$$.log('response.d: ' + response.d);
                        }
                    },

                    error: function (error) {
                        $$$.log(error);
                    }
                });
            }
        };

        $$.grid = {
            grids: window.Grids,

            filteringOn: true,
            groupingOn: true,

            showColumnSelector: function () {
                this.g().ActionShowColumns('Selectable');
            },

            hideRow: function (rowId) {
                var grid = this.g();
                grid.HideRow(grid.GetRowById(rowId));
            },

            showRow: function (rowId) {
                var grid = this.g();
                grid.ShowRow(grid.GetRowById(rowId));
            },

            hideFilters: function () {
                this.hideRow('Filter');
                this.filteringOn = false;
            },

            showFilters: function () {
                this.showRow('Filter');
                this.filteringOn = true;
            },

            hideGrouping: function () {
                var grid = this.g();
                var rowId = null;

                var rows = grid.Rows;
                for (var r in rows) {
                    if (rows.hasOwnProperty(r)) {
                        var row = rows[r];

                        if (row.Kind === 'Group') {
                            rowId = row.id;
                            break;
                        }
                    }
                }

                if (rowId) {
                    this.hideRow(rowId);
                    this.groupingOn = false;
                }
            },

            showGrouping: function () {
                var grid = this.g();
                var rowId = null;

                var rows = grid.Rows;
                for (var r in rows) {
                    if (rows.hasOwnProperty(r)) {
                        var row = rows[r];

                        if (row.Kind === 'Group') {
                            rowId = row.id;
                            break;
                        }
                    }
                }

                if (rowId) {
                    this.showRow(rowId);
                    this.groupingOn = true;
                }
            },

            toggleFiltering: function () {
                if (this.filteringOn) {
                    this.hideFilters();
                } else {
                    this.showFilters();
                }

                window.setTimeout(function () {
                    var g = $$.grid.grids[$$.id()];
                    g.Update();
                    g.Render();
                }, 10);

                return this.filteringOn;
            },

            toggleGrouping: function () {
                if (this.groupingOn) {
                    this.hideGrouping();
                } else {
                    this.showGrouping();
                }

                window.setTimeout(function () {
                    var g = $$.grid.grids[$$.id()];
                    g.Update();
                    g.Render();
                }, 10);

                return this.groupingOn;
            },

            removeSorting: function () {
                this.g().ChangeSort('Title');

                window.setTimeout(function () {
                    var g = $$.grid.grids[$$.id()];
                    g.Update();
                    g.Render();
                }, 10);
            },

            resetNoDataRow: function () {
                var gridTable = $('#' + $$.id())[0];

                if (gridTable) {
                    var tableBodyElement = gridTable.firstChild;

                    if (!this.g().GetFirstVisible()) {
                        gridTable.removeChild(tableBodyElement);
                        var row = gridTable.insertRow(0);
                        var cell = row.insertCell(0);

                        cell.innerHTML = 'No resource found.';
                    }
                }
            },

            reload: function () {
                var url = window.location.href.replace(new RegExp('&epmrgv=' + $$.epmrgv, 'gi'), '').replace(new RegExp('epmrgv=' + $$.epmrgv, 'gi'), '');
                url = (url + (url.indexOf('?') !== -1 ? '&' : '?') + 'epmrgv=' + $$.views.currentView.id).replace(new RegExp('&&', 'g'), '&');
                window.location = url;
            },

            rowsSelected: function () {
                try {
                    return $$.grid.grids[$$.id()].GetSelRows().length;
                } catch (e) {
                    return 0;
                }
            },

            resourceUpdated: function (result, target, params) {
                if (result !== 1) return;

                var grid = $$.grid.grids[$$.id()];

                var row = params.row || { id: 0 };
                var changeType = params.changeType;

                if (changeType === 'Deleted') {
                    grid.AddDataFromServer("<Grid><Changes><I id='" + row.id + "' Deleted='1'/></Changes></Grid>");

                    $$.actions.reIndexResources();
                    return;
                }

                var rowIds = row.id;

                if (changeType === 'Added') {
                    rowIds = '';

                    for (var r in grid.Rows) {
                        if (grid.Rows.hasOwnProperty(r)) {
                            rowIds += grid.Rows[r].id + ',';
                        }
                    }

                    rowIds = rowIds.slice(0, -1);
                }

                $.ajax({
                    type: 'POST',
                    url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'GetResourcePoolDataGridChanges', Dataxml: '<ResourcePoolDataGridChanges><Params><ChangeType>" + changeType + "</ChangeType><Rows>" + rowIds + "</Rows></Params></ResourcePoolDataGridChanges>' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',

                    success: function (response) {
                        if (response.d) {
                            var responseJson = $$$.parseJson(response.d);

                            try {
                                grid.AddDataFromServer(responseJson.ResourcePoolDataGridChanges.Data['#cdata']);
                                grid.RenderBody();
                                grid.Render();
                                grid.Update();

                                if (changeType === 'Added') {
                                    $$.actions.reIndexResources();
                                }
                            } catch (e) {
                                $$$.log(error);
                            }
                        } else {
                            $$$.log('response.d: ' + response.d);
                        }
                    },

                    error: function (error) {
                        $$$.log(error);
                    }
                });
            }
        };

        $$.grid.g = k.dependentObservable(function () {
            return this.grids[$$.id()];
        }, $$.grid);

        $$.views = {
            collection: {},
            totalViews: 0,
            currentView: null,
            previousView: null,
            userHasGlobalViewModificationPermission: false,

            build: function (view) {
                var grid = $$.grid.g();

                view.cols = [];
                view.filters = [];

                var gridCols = grid.Cols;

                var visibleCols = grid.GetCols("Visible");

                var gridWidth = 0;

                for (var i = 0; i < visibleCols.length; i++) {
                    gridWidth += grid.Cols[visibleCols[i]].Width;
                }

                for (var j = 0; j < visibleCols.length; j++) {
                    var colName = visibleCols[j];
                    var col = grid.Cols[colName];

                    var width = col.Width;
                    var fixedWidth = (col.FixedWidth) ? ((col.FixedWidth === 1) ? true : false) : false;

                    if (!fixedWidth) {
                        width = Math.round(((width * 100) / gridWidth) * 1000) / 1000;
                    }

                    if (colName === 'Panel') {
                        width = 14;
                        fixedWidth = true;
                    }

                    view.cols.push({ name: colName, width: width, isfixedwidth: fixedWidth, section: col.Sec });
                }

                view.filteringon = $$.grid.filteringOn;

                var filterRow = grid.GetRowById('Filter');

                for (var gridCol in gridCols) {
                    if (gridCols.hasOwnProperty(gridCol)) {
                        var cell = filterRow[gridCol + 'Filter'];

                        if (cell) {
                            if (cell !== 0) {
                                view.filters.push({ column: gridCol, value: filterRow[gridCol], cell: cell });
                            }
                        }
                    }
                }

                view.groupingon = $$.grid.groupingOn;
                view.grouping = grid.Group;

                view.sorting = grid.Sort;

                return view;
            },

            getXml: function (view) {
                var viewXml = '<View Id="{0}" Name="{1}" IsDefault="{2}" IsPersonal="{3}"><Cols>'.format(view.id, escape(view.name), view.isdefault, view.ispersonal);

                for (var i = 0; i < view.cols.length; i++) {
                    var col = view.cols[i];
                    viewXml += '<Col Name="{0}" Width="{1}" IsFixedWidth="{2}" Section="{3}"/>'.format(col.name, col.width, col.isfixedwidth, col.section);
                }

                viewXml += '</Cols><Filters RowVisible="{0}">'.format(view.filteringon || false);

                if (view.filters) {
                    for (var m = 0; m < view.filters.length; m++) {
                        var filter = view.filters[m];
                        viewXml += '<Filter Column="{0}" Value="{1}" Cell="{2}"/>'.format(filter.column, filter.value, filter.cell);
                    }
                }

                viewXml += '</Filters><Grouping RowVisible="{0}">{1}</Grouping><Sorting>{2}</Sorting></View>'.format(view.groupingon || false, view.grouping || '', view.sorting || '');

                return viewXml;
            },

            save: function (view) {
                var grid = $$.grid.g();

                grid.StaticCursor = 1;

                view.id = (view.name !== 'Default View') ? $$$.md5(view.name) : 'dv';

                if (this.collection[view.id]) {
                    if (!confirm('Would you like to overwrite the "' + view.name + '" view?')) return;
                }

                view = this.build(view);

                $.ajax({
                    type: 'POST',
                    url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'SaveResourcePoolViews', Dataxml: '<ResourceGridViews>" + this.getXml(view) + "</ResourceGridViews>' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',

                    success: function (response) {
                        if (response.d) {
                            var responseJson = $$$.parseJson(response.d);

                            if ($$$.responseIsSuccess(responseJson.Result)) {
                                window.SP.UI.Notify.addNotification('The view "{0}" has been saved.'.format(view.name), false);

                                $$.views.collection[view.id] = view;
                                $$.views.apply(view.id);
                            } else {
                                $$$.logFailure(responseJson.Result);
                            }
                        } else {
                            $$$.log('response.d: ' + response.d);
                        }
                    },

                    error: function (error) {
                        $$$.log(error);
                    }
                });
            },

            showSaveDialog: function () {
                var grid = $$.grid.g();

                var element = document.createElement('div');
                element.innerHTML = $('#RWPSaveView-{0}'.format($$.id())).html();

                $($(element).find('#RWPSaveView-Name-{0}'.format($$.id()))).val(this.currentView.name);

                if (this.currentView.isdefault) {
                    $($(element).find('#RWPSaveView-Default-{0}'.format($$.id()))).attr('checked', 'checked');
                }

                var isPersonalCheckbox = $(element).find('#RWPSaveView-Personal-{0}'.format($$.id()));

                if (!$(isPersonalCheckbox).is(':disabled')) {
                    if (this.currentView.ispersonal) {
                        $(isPersonalCheckbox).attr('checked', 'checked');
                    }
                }

                var isMSIE = $.browser.msie;

                var height = isMSIE ? 140 : 135;
                var width = isMSIE ? 230 : 225;

                var options = window.SP.UI.$create_DialogOptions();

                options.title = 'Save View';
                options.html = element;
                options.height = height;
                options.width = width;
                options.allowMaximize = false;
                options.showClose = false;

                grid.StaticCursor = 0;
                grid.ActionBlur();

                window.SP.UI.ModalDialog.showModalDialog(options);
            },

            apply: function (viewId) {
                var view = null;

                var previousViewId = $$$.getUrlParamByName('epmrgv');

                if (previousViewId && $$.firstLoad) {
                    if (this.collection[previousViewId]) {
                        viewId = previousViewId;
                        $$.epmrgv = previousViewId;
                    }
                }

                if (viewId) {
                    view = this.collection[viewId];
                } else {
                    var globalDefaultView = 'dv';
                    var personalDefaultView = null;

                    for (var v in this.collection) {
                        var theView = this.collection[v];

                        if (theView.ispersonal && theView.isdefault) {
                            personalDefaultView = theView.id;
                        } else if (theView.isdefault) {
                            globalDefaultView = theView.id;
                        }

                        view = this.collection[personalDefaultView || globalDefaultView];
                    }
                }

                if (this.currentView && this.currentView.id === view.id) {
                    return;
                }

                var grid = $$.grid.g();

                var onlyMyResources = $$.actions.myResourcesOn;

                if (!grid.getColWidth) {
                    grid.getColWidth = function (c) {
                        if (c && this.Cols[c]) {
                            var w = this.Cols[c].Width;

                            if (!$$$.utils.isInt(w)) {
                                if (w.indexOf('-') !== -1) {
                                    w = w.split('-')[0];
                                }
                            }

                            return w - 0;
                        }

                        return 0;
                    };
                }

                var allCols = [];
                var mainCols = [];

                for (var i = 0; i < view.cols.length; i++) {
                    var col = view.cols[i];
                    var colName = col.name;
                    var gridCol = grid.Cols[colName];

                    var width = 0;
                    var currentColWidth = grid.getColWidth(colName);

                    if (col.isfixedwidth) {

                        if (colName === 'Panel') {
                            col.width = 14;
                        }

                        width = col.width - currentColWidth;
                    } else {
                        width = -currentColWidth;

                        if (gridCol) {
                            gridCol.RelWidth = col.width;
                        }
                    }

                    if (width !== 0) {
                        if (gridCol) {
                            gridCol.Width += width;
                        }

                        grid.Update();
                    }

                    grid.MoveCol(colName, col.section, 1, 0);

                    allCols.push(colName);
                }

                grid.Update();
                grid.Render();

                var groupCols = grid.Group.split(',');

                grid.DoGrouping(null);

                for (var j = 0; j < groupCols.length; j++) {
                    var groupCol = groupCols[j];
                    if (groupCol) {
                        grid.HideCol(groupCol);
                    }
                }

                var visibleCols = grid.GetCols('Visible');
                visibleCols = visibleCols.concat(groupCols);

                for (var l = 0; l < visibleCols.length; l++) {
                    var found = false;
                    var visibleCol = visibleCols[l];

                    for (var m = 0; m < allCols.length; m++) {
                        if (allCols[m] === visibleCol) {
                            found = true;
                            break;
                        }
                    }

                    if (!found && visibleCol) {
                        mainCols.push(visibleCol);
                    }
                }

                grid.ChangeColsVisibility(allCols, mainCols, 0);

                var filterValues = [];
                var filterOperatios = [];

                for (var o = 0; o < allCols; o++) {
                    filterValues.push(null);
                    filterOperatios.push(0);
                }

                grid.ChangeFilter(allCols, filterValues, filterOperatios, 0, 0, null);

                var filters = view.filters;

                if (filters) {
                    var cols = [];
                    var values = [];
                    var operators = [];

                    for (var n = 0; n < filters.length; n++) {
                        var filter = filters[n];

                        cols.push(filter.column);
                        values.push(filter.value);
                        operators.push(filter.cell);
                    }

                    grid.ChangeFilter(cols, values, operators, 0, 0, null);
                } else {
                    grid.ChangeFilter('', '', '', 0, 0, null);
                }

                if (view.filterrowvisible) {
                    $$.grid.showFilters();
                } else {
                    $$.grid.hideFilters();
                }

                grid.ChangeSort(view.sorting);

                $$.grid.hideGrouping();

                grid.DoGrouping(view.grouping || null);

                grid.Update();
                grid.Render();

                $$.actions.myResourcesOn = false;

                if (onlyMyResources) {
                    $$.actions.toggleMyResources();
                }

                this.currentView = view;

                window.RefreshCommandUI();

                if ($$.firstLoad) {
                    $$.actions.resetEasyScroll();
                    window.setTimeout(function () { $$.firstLoad = false; }, 2000);
                }

                window.setTimeout(function () {
                    var g = $$.grid.g();
                    g.Update();
                    g.Render();

                    $('.EPMLiveResourceGridGroup').click(function (event) {
                        try {
                            var row = $(this).parent();
                            if (row) {
                                row = row[0];

                                if (row) {
                                    var attributes = row.attributes;
                                    for (var a in attributes) {
                                        if (attributes.hasOwnProperty(a)) {
                                            var attr = attributes[a];
                                            if (attr.name === 'onmousemove') {
                                                row = g.Rows[attr.value.split('"')[1]];
                                                if (row.Expanded === 1) {
                                                    g.Collapse(row);
                                                } else {
                                                    g.Expand(row);
                                                }

                                                event.stopPropagation();
                                            }
                                        }
                                    }
                                }
                            }
                        } catch (e) {
                        }
                    });
                }, 10);
            },

            load: function () {

                function register(views) {

                    function getCleanValue(ov) {
                        if (ov) {
                            var lcov = ov.toLowerCase();

                            if (lcov === 'true') {
                                ov = true;
                            } else if (lcov === 'false') {
                                ov = false;
                            } else {
                                var number = parseInt(ov);
                                if (!isNaN(number)) {
                                    ov = number;
                                }
                            }
                        }

                        return ov;
                    }

                    if (!views.length) {
                        views = [views];
                    }

                    for (var i = 0; i < views.length; i++) {
                        var view = {};

                        var theView = views[i];
                        for (var v in theView) {
                            if (theView.hasOwnProperty(v)) {
                                var key = v.replace(/@/, '').toLowerCase();
                                var value = theView[v];
                                
                                if (key.toLowerCase() === 'name') {
                                    value = unescape(value);
                                }

                                if (key === 'cols') {
                                    value = value.Col;

                                    if (!value.length) {
                                        value = [value];
                                    }

                                    var cols = [];

                                    for (var l = 0; l < value.length; l++) {
                                        var theCol = value[l];

                                        var col = {};

                                        for (var c in theCol) {
                                            if (theCol.hasOwnProperty(c)) {
                                                col[c.replace(/@/, '').toLowerCase()] = getCleanValue(theCol[c]);
                                            }
                                        }

                                        cols.push(col);
                                    }

                                    view[key] = cols;
                                } else if (key === 'filters') {
                                    for (var f in value) {
                                        if (value.hasOwnProperty(f)) {
                                            var fk = f.replace(/@/, '').toLowerCase();

                                            if (fk === 'filter') {
                                                value = value.Filter;

                                                if (!value.length) {
                                                    value = [value];
                                                }

                                                var filters = [];

                                                for (var m = 0; m < value.length; m++) {
                                                    var theFilter = value[m];

                                                    var filter = {};

                                                    for (var fp in theFilter) {
                                                        if (theFilter.hasOwnProperty(fp)) {
                                                            filter[fp.replace(/@/, '').toLowerCase()] = getCleanValue(theFilter[fp]);
                                                        }
                                                    }

                                                    filters.push(filter);
                                                }

                                                view[key] = filters;
                                            } else {
                                                view['filter' + fk] = getCleanValue(value[f]);
                                            }
                                        }
                                    }
                                } else if (key === 'grouping') {
                                    for (var g in value) {
                                        if (value.hasOwnProperty(g)) {
                                            var gk = g.replace(/@/, '').toLowerCase();
                                            var theValue = getCleanValue(value[g]);

                                            if (gk === '#text') {
                                                view[key] = theValue;
                                            } else {
                                                view['grouping' + gk] = theValue;
                                            }
                                        }
                                    }
                                } else if (key !== 'id') {
                                    view[key] = getCleanValue(value);
                                } else {
                                    view[key] = value;
                                }
                            }
                        }

                        $$.views.collection[view.id] = view;
                        $$.views.totalViews++;
                    }
                }

                $.ajax({
                    type: 'POST',
                    url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'GetResourcePoolViews', Dataxml: '<Views/>' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',

                    success: function (response) {
                        if (response.d) {
                            var responseJson = $$$.parseJson(response.d);

                            var result = responseJson.Result;

                            if ($$$.responseIsSuccess(result)) {
                                $$.views.totalViews = 0;
                                register(result.ResourcePoolViews.Views.View);
                                $$.views.apply();
                            } else {
                                $$$.logFailure(result);
                            }
                        } else {
                            $$$.log('response.d: ' + response.d);
                        }
                    },

                    error: function (error) {
                        $$$.log(error);
                    }
                });
            },

            getXmlForRibbon: function () {
                var viewCollection = this.collection;
                var currentView = this.currentView;
                var totalViews = this.totalViews;
                var sb = new window.Sys.StringBuilder();

                function appendViews(viewType) {
                    sb.append("<MenuSection DisplayMode='Menu' Id='Ribbon.ResourceGrid.Views.Dropdown.Menu.{0}' Title='{0} Views'>".format(viewType));
                    sb.append("<Controls Id='Ribbon.ResourceGrid.Views.Dropdown.Menu.{0}.Controls'>".format(viewType));

                    var isPersonal = (viewType === 'Personal');

                    for (var v in viewCollection) {
                        if (viewCollection.hasOwnProperty(v)) {
                            var view = viewCollection[v];

                            if (view.name) {
                                if (view.ispersonal === isPersonal) {
                                    if (view.id === 'dv' && totalViews > 1) {
                                        continue;
                                    }

                                    sb.append("<Button Id='Ribbon.ResourceGrid.views.{0}' Command='ResourceGrid.Cmd.CurrentViewDropDown.Select' LabelText=\"{1}\" CommandValueId='{0}'/>".format(view.id, view.name));
                                }
                            }
                        }
                    }

                    sb.append('</Controls>');
                    sb.append('</MenuSection>');
                }

                ;

                sb.append("<Menu Id='Ribbon.ResourceGrid.Views.Dropdown.Menu'>");

                sb.append("<MenuSection DisplayMode='Menu' Id='Ribbon.ResourceGrid.Views.Dropdown.Menu.Default' Title='Current View'>");
                sb.append("<Controls Id='Ribbon.ResourceGrid.Views.Dropdown.Menu.Default.Controls'>");
                sb.append("<Button Id='Ribbon.ResourceGrid.views.{0}' Command='ResourceGrid.Cmd.CurrentViewDropDown.Select' LabelText=\"{1}\" CommandValueId='{0}'/>".format(currentView.id, currentView.name));
                sb.append('</Controls>');
                sb.append('</MenuSection>');

                appendViews('Global');
                appendViews('Personal');

                sb.append('</Menu>');

                return sb.toString();
            },

            remove: function () {
                var currentView = this.currentView;

                if (!this.userHasGlobalViewModificationPermission && !currentView.ispersonal) {
                    alert('You are not allowed to delete a global view');
                    return;
                }

                if (currentView.id === 'dv') {
                    alert('You cannot delete the Default View');
                    return;
                }

                if (!confirm('Are you sure you want to delete the "' + currentView.name + '" view?')) return;

                $.ajax({
                    type: 'POST',
                    url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'DeleteResourcePoolViews', Dataxml: '<ResourceGridViews>" + this.getXml(currentView) + "</ResourceGridViews>' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',

                    success: function (response) {
                        if (response.d) {
                            var responseJson = $$$.parseJson(response.d);

                            if ($$$.responseIsSuccess(responseJson.Result)) {
                                window.SP.UI.Notify.addNotification('The view "{0}" has been deleted.'.format(currentView.name), false);

                                delete $$.views.collection[currentView.id];
                                $$.views.totalViews--;
                                $$.views.apply();
                            } else {
                                $$$.logFailure(responseJson.Result);
                            }
                        } else {
                            $$$.log('response.d: ' + response.d);
                        }
                    },

                    error: function (error) {
                        $$$.log(error);
                    }
                });
            },

            rename: function (newName) {
                if (!newName) return;

                var currentView = this.currentView;

                var oldName = currentView.name;
                currentView.name = newName;

                if (!this.userHasGlobalViewModificationPermission && !currentView.ispersonal) {
                    alert('You are not allowed to rename a global view');
                    return;
                }

                if (currentView.id === 'dv') {
                    alert('You cannot rename the Default View');
                    return;
                }

                if (!confirm('Are you sure you want to rename the "' + oldName + '" view?')) return;

                $.ajax({
                    type: 'POST',
                    url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'UpdateResourcePoolViews', Dataxml: '<ResourceGridViews>" + this.getXml(currentView) + "</ResourceGridViews>' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',

                    success: function (response) {
                        if (response.d) {
                            var responseJson = $$$.parseJson(response.d);

                            if ($$$.responseIsSuccess(responseJson.Result)) {
                                window.SP.UI.Notify.addNotification('The view "{0}" has been renamed to "{1}".'.format(oldName, currentView.name), false);

                                $$.views.currentView.name = currentView.name;
                                $$.views.collection[currentView.id].name = currentView.name;

                                window.RefreshCommandUI();
                            } else {
                                $$$.logFailure(responseJson.Result);
                            }
                        } else {
                            $$$.log('response.d: ' + response.d);
                        }
                    },

                    error: function (error) {
                        $$$.log(error);
                    }
                });
            },

            showRenameDialog: function () {
                var grid = $$.grid.g();

                var element = document.createElement('div');
                element.innerHTML = $('#RWPRenameView-{0}'.format($$.id())).html();

                $($(element).find('#RWPRenameView-CurrentName-{0}'.format($$.id()))).html(this.currentView.name);

                var isMSIE = $.browser.msie;

                var height = isMSIE ? 135 : 140;
                var width = isMSIE ? 235 : 240;

                var options = window.SP.UI.$create_DialogOptions();

                options.title = 'Rename View';
                options.html = element;
                options.height = height;
                options.width = width;
                options.allowMaximize = false;
                options.showClose = false;

                grid.StaticCursor = 0;
                grid.ActionBlur();

                window.SP.UI.ModalDialog.showModalDialog(options);
            }
        };

        $$.actions = {
            easyScrollOn: false,
            myResourcesOn: false,

            loadRibbon: function () {
                SP.SOD.executeOrDelayUntilScriptLoaded(function () {
                    var selectTab = function (tabId) {
                        window._ribbonStartInit(tabId, true, null);

                        $('#s4-ribbonrow').height(35);

                        var intervalId = window.setInterval(function () {
                            if (!document.getElementById('Ribbon.ResourceGridTab')) {
                                window.SelectRibbonTab(tabId, true);
                            }
                        }, 1);

                        window.setTimeout(function () {
                            window.clearInterval(intervalId);
                            
                            try {
                                var setTabStyle = function() {
                                    var tabs = [$(document.getElementById('Ribbon.ResourceGridTab-title')), $(document.getElementById('Ribbon.ResourceGridViewTab-title'))];

                                    for (var tab in tabs) {
                                        if (tabs.hasOwnProperty(tab)) {
                                            var t = tabs[tab];

                                            t.attr('style', 'border-top: 1px solid #E1E1E1 !important; height: 33px !important; margin-top: -4px !important');
                                            t.find('a').attr('style', 'padding-top: 4px !important;');

                                            if (t.attr('aria-selected') === 'false') {
                                                t.attr('style', 'height: 33px !important; margin-top: -3px !important');
                                            }

                                            t.click(function() {
                                                window.setTimeout(function() {
                                                    setTabStyle();
                                                }, 100);
                                            });
                                        }
                                    }
                                };

                                setTabStyle();
                                
                                if (!epmLiveResourceGrid.loaderStopped) {
                                    $(document.getElementById("s4-ribbonrow")).height(126);
                                    window.EPM.UI.Loader.current().stopLoading('WebPart' + $$.webpartQualifier);
                                    epmLiveResourceGrid.loaderStopped = true;
                                }
                            } catch (ex) {
                            }
                        }, 750);
                    };

                    var pm = SP.Ribbon.PageManager.get_instance();

                    var ribbon = null;

                    try {
                        ribbon = pm.get_ribbon();
                    } catch (e) {
                    }

                    if (!ribbon) {
                        if (typeof (window._ribbonStartInit) === 'function') {
                            selectTab('Ribbon.ResourceGridTab');
                        }
                    }

                }, 'sp.ribbon.js');
            },

            dataTicketRequest: function () {
                var grid = $$.grid.g();

                var selectedRows = grid.GetSelRows();

                if ($$.allSelected) {
                    selectedRows = [];
                    var rows = grid.Rows;

                    for (var r in rows) {
                        if (rows.hasOwnProperty(r)) {
                            selectedRows.push(rows[r]);
                        }
                    }
                }

                var selectedRowIds = [];

                for (var i = 0; i < selectedRows.length; i++) {
                    var selectedRow = selectedRows[i];

                    if (selectedRow.Def.Name === 'R') {
                        selectedRowIds.push(selectedRow['EXTID']);
                    }
                }

                if (selectedRowIds.length > 0) {
                    return $.ajax({
                        type: 'POST',
                        url: $$$.currentWebUrl + '/_vti_bin/PortfolioEngine.asmx/Execute',
                        data: "{ Function: 'GenerateDataTicket', Dataxml: '<GenerateDataTicket><Ticket>" + selectedRowIds.join(',') + "</Ticket></GenerateDataTicket>' }",
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json'
                    });
                }

                return null;
            },

            retriveDataTicket: function (response) {
                if (response.d) {
                    var responseJson = $$$.parseJson(response.d);

                    var generateDataTicketResponse = responseJson.GenerateDataTicket;

                    if ($$$.responseIsSuccess(generateDataTicketResponse.Result)) {
                        return generateDataTicketResponse.Data.Ticket['@Id'];
                    } else {
                        $$$.logFailure(responseJson.Result);
                    }
                } else {
                    $$$.log('response.d: ' + response.d);
                }

                return null;
            },

            displayPopUp: function (url, title, allowMaximize, showClose, func, funcParams, width, height) {
                if (!allowMaximize) allowMaximize = true;
                if (!showClose) showClose = true;
                if (!func) {
                    func = function () {
                    };
                }

                var options;

                if (width && height) {
                    options = {
                        title: title,
                        allowMaximize: allowMaximize,
                        showMaximized: true,
                        showClose: showClose,
                        url: url,
                        dialogReturnValueCallback: Function.createCallback(Function.createDelegate(null, func), funcParams),
                        width: width,
                        height: height
                    };
                } else {
                    options = {
                        title: title,
                        allowMaximize: allowMaximize,
                        showClose: showClose,
                        url: url,
                        dialogReturnValueCallback: Function.createCallback(Function.createDelegate(null, func), funcParams)
                    };
                }

                if (title === 'Assignment Planner') {
                    var frame = document.createElement('iframe');
                    frame.setAttribute('src', url);
                    frame.setAttribute('width', '99%');
                    frame.setAttribute('height', '98%');

                    options.url = null;
                    options.html = frame;
                }

                window.SP.UI.ModalDialog.showModalDialog(options);
            },

            analyzeResources: function () {
                var dataTicketRequest = $$.actions.dataTicketRequest();

                if (dataTicketRequest) {
                    dataTicketRequest.success(function (response) {
                        var dataTicket = $$.actions.retriveDataTicket(response);

                        if (dataTicket) {
                            var url = '{0}/_layouts/ppm/rpanalyzer.aspx?dataid={1}'.format($$$.currentWebUrl, dataTicket);
                            $$.actions.displayPopUp(url, 'Resource Analyzer', true, true, null, null, 700, 700);
                        }
                    });
                }
            },

            redirect: function (operation) {
                var grid = $$.grid.grids[$$.id()];
                var selRows = grid.GetSelRows();
                var selRow = selRows[0];
                var id = null;

                if ($$.grid.rowsSelected() > 0) {
                    id = operation === 'viewprofile' ? selRow.ResourceID : selRow.ID;
                }

                if (operation === 'sendnotification') {
                    var emails = [];

                    for (var i = 0; i < selRows.length; i++) {
                        var row = selRows[i];

                        if (row.Kind === 'Data' && row.Def.Name === 'R') {
                            var email = row.Email;

                            if (email) {
                                emails.push(email);
                            }
                        }
                    }

                    window.location.href = 'mailto:{0}'.format(emails.join(';'));

                    return;
                }

                var url = '{0}/_layouts/epmlive/redirectionproxy.aspx?listname=Resources&webid={1}'.format($$$.currentWebUrl, $$$.currentWebId);

                switch (operation) {
                    case 'add':
                        $$.actions.displayPopUp('{0}&action=new'.format(url), null, true, true, $$.grid.resourceUpdated, { row: null, changeType: 'Added' });
                        break;
                    case 'edit':
                        $$.actions.displayPopUp('{0}&action=edit&id={1}'.format(url, id), null, true, true, $$.grid.resourceUpdated, { row: selRow, changeType: 'Changed' });
                        break;
                    case 'showcomments':
                        $$.actions.displayPopUp('{0}&action={1}&id={2}'.format(url, operation, id), null, true, true, null, null, 700, 700);
                        break;
                    default:
                        $$.actions.displayPopUp('{0}&action={1}&id={2}'.format(url, operation, id));
                        break;
                }
            },

            loadResourcePlanner: function () {
                var dataTicketRequest = $$.actions.dataTicketRequest();

                if (dataTicketRequest) {
                    dataTicketRequest.success(function (response) {
                        var dataTicket = $$.actions.retriveDataTicket(response);

                        if (dataTicket) {
                            var url = '{0}/_layouts/ppm/RPEditor.aspx?dataid={1}&isresource=1'.format($$$.currentWebUrl, dataTicket);
                            $$.actions.displayPopUp(url, 'Resource Planner', true, true, null, null, 700, 700);
                        }
                    });
                }
            },

            loadAssignmentPlanner: function () {
                var grid = $$.grid.g();

                var selectedRows = grid.GetSelRows();
                var selectedRowIds = [];

                for (var i = 0; i < selectedRows.length; i++) {
                    var selectedRow = selectedRows[i];

                    selectedRowIds.push(selectedRow['ID']);
                }

                if (selectedRowIds.length > 0) {
                    var url = '{0}/_layouts/epmlive/AssignmentPlanner.aspx?resources={1}&IsDlg=1'.format($$$.currentWebUrl, selectedRowIds.join(','));
                    $$.actions.displayPopUp(url, 'Assignment Planner', true, true, null, null, 1000, 700);
                }
            },

            deleteResource: function () {
                var grid = $$.grid.g();

                var row = grid.GetSelRows()[0];

                if (row.Kind === 'Data' && row.Def.Name === 'R') {
                    if (!confirm("Are you sure you want to delete this resource?")) {
                        return;
                    }

                    $.ajax({
                        type: 'POST',
                        url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                        data: "{ Function: 'DeleteResourcePoolResource', Dataxml: '<DeleteResourcePoolResource><Resource Id=\"" + row.ID + "\"/></DeleteResourcePoolResource>' }",
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',

                        success: function (response) {
                            if (response.d) {
                                var responseJson = $$$.parseJson(response.d);

                                if ($$$.responseIsSuccess(responseJson.Result)) {
                                    var resource = responseJson.Result.DeleteResourcePoolResource.Resource;
                                    var status = resource['@Status'];

                                    if (status === '0') {
                                        $$.grid.resourceUpdated(1, null, { row: row, changeType: 'Deleted' });
                                    } else {
                                        var message = resource['#cdata'];

                                        if (status === '1') {
                                            alert(message);
                                        } else if (status === '2') {
                                            if (!confirm(message)) return;
                                            $.ajax({
                                                type: 'POST',
                                                url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                                                data: "{ Function: 'DeleteResourcePoolResource', Dataxml: '<DeleteResourcePoolResource><Resource Id=\"" + row.ID + "\" ConfirmDelete=\"True\"/></DeleteResourcePoolResource>' }",
                                                contentType: 'application/json; charset=utf-8',
                                                dataType: 'json',

                                                success: function (resp) {
                                                    if (resp.d) {
                                                        var respJson = $$$.parseJson(resp.d);

                                                        if ($$$.responseIsSuccess(respJson.Result)) {
                                                            $$.grid.resourceUpdated(1, null, { row: row, changeType: 'Deleted' });
                                                        } else {
                                                            $$$.logFailure(respJson.Result);
                                                        }
                                                    } else {
                                                        $$$.log('resp.d: ' + resp.d);
                                                    }
                                                },

                                                error: function (err) {
                                                    $$$.log(err);
                                                }
                                            });
                                        }
                                    }
                                } else {
                                    $$$.logFailure(responseJson.Result);
                                }
                            } else {
                                $$$.log('response.d: ' + response.d);
                            }
                        },

                        error: function (error) {
                            $$$.log(error);
                        }
                    });
                }
            },

            resetEasyScroll: function () {
                var grid = $$.grid.g();

                $('#EPMLiveResourceGridSelector').watermark('Type here to search...');

                if ($$.resourceDictionary == null) {
                    $$.actions.reIndexResources();
                }

                $('#EPMLiveResourceGridSelector').autocomplete({
                    source: function (request, response) {
                        var results = $.ui.autocomplete.filter($$.actions.myResourcesOn ? $$.myResources : $$.resources, request.term);

                        response(results);
                    },

                    select: function (event, ui) {
                        var rowId = $$.resourceDictionary[ui.item.value];

                        if (rowId) {
                            var theRow = grid.Rows[rowId];

                            grid.ExpandParents(theRow);

                            grid.ActionClearSelection();
                            grid.SelectRow(theRow, true);

                            grid.SetScrollTop(grid.GetRowTop(theRow));
                        }

                        $$.actions.toggleEasyScroll();
                        window.setTimeout(function () { window.RefreshCommandUI(); }, 100);
                    }
                });

                $('#s4-ribbonrow').click(function (event) {
                    var hide = true;
                    var parents = $(event.target).parents();

                    for (var i = 0; i < 5; i++) {
                        try {
                            var parent = parents[i];

                            if (parent) {
                                if ($(parent)[0].id.indexOf('Ribbon.ResourceGrid.Actions.Find') !== -1) {
                                    hide = false;
                                    break;
                                }
                            }
                        } catch (e) { }
                    }

                    if (hide) {
                        $$.actions.hideEasyScroll(true);
                    }
                });
            },

            toggleEasyScroll: function () {
                var callout = $('.callout');
                if (callout.length) callout = callout[0];

                var resourceFinder = $(callout);

                if (resourceFinder.is(":visible")) {
                    $$.actions.hideEasyScroll(false);
                } else {
                    if ($$.resources.length === 0) return false;

                    var ribbonButton = document.getElementById('Ribbon.ResourceGrid.Actions.Find-Large');
                    if (!ribbonButton) {
                        ribbonButton = document.getElementById('Ribbon.ResourceGrid.Actions.Find-Small');
                    }

                    if (ribbonButton) {
                        var rButton = $(ribbonButton);
                        var offset = rButton.offset();

                        resourceFinder.css({ top: offset.top + rButton.height() });
                        resourceFinder.css({ left: offset.left + (rButton.width() / 2) - 31 });

                        $('#EPMLiveResourceGridSelector').val('');

                        resourceFinder.show();

                        $('#EPMLiveResourceGridSelector').focus();

                        $$.actions.easyScrollOn = true;
                    }
                }

                return $$.actions.easyScrollOn;
            },

            reIndexResources: function () {
                var grid = $$.grid.g();

                $$.resourceDictionary = {};
                $$.resources = [];
                $$.myResources = [];

                var rows = grid.Rows;
                for (var r in rows) {
                    if (rows.hasOwnProperty(r)) {
                        var row = rows[r];

                        if (row.Kind === 'Data' && row.Def.Name === 'R') {
                            var title = row['Title'];

                            $$.resources.push(title);
                            $$.resourceDictionary[title] = r;

                            if (row.IsMyResource === 1) {
                                $$.myResources.push(title);
                            }
                        }
                    }
                }
            },

            toggleMyResources: function () {
                var grid = $$.grid.g();

                if ($$.actions.myResourcesOn) {
                    grid.ChangeFilter('IsMyResource', '0', 6, 0, 1, null);
                    $$.actions.myResourcesOn = false;
                } else {
                    grid.ChangeFilter('IsMyResource', '1', 1, 0, 1, null);
                    $$.actions.myResourcesOn = true;
                }

                window.setTimeout(function () {
                    var g = $$.grid.grids[$$.id()];
                    g.Update();
                    g.Render();
                }, 500);
            },

            hideEasyScroll: function (refresh) {
                var callout = $('.callout');
                if (callout.length) callout = callout[0];

                var resourceFinder = $(callout);

                if (resourceFinder.is(":visible")) {
                    resourceFinder.hide();
                    $$.actions.easyScrollOn = false;

                    if (refresh) {
                        window.setTimeout(function () { window.RefreshCommandUI(); }, 100);
                    }
                }
            },

            exportResources: function () {
                $$.exportInProgress = true;
                window.RefreshCommandUI();

                var height = $('#EPMLiveStatusbar').height();

                var statuses = $$$.ui.statusbar.collection();

                for (var i = 0; i < statuses.length; i++) {
                    statuses[i].remove();
                }

                var statusbar = $$$.ui.statusbar.add('Status', 'Exporting resources to Excel spreadsheet...');
                statusbar.color('yellow');

                var status = statusbar.collection()[0];

                $.ajax({
                    type: 'POST',
                    url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'ExportResources', Dataxml: '<ExportResources/>' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',

                    success: function (resp) {
                        if (resp.d) {
                            var responseJson = $$$.parseJson(resp.d);
                            var result = responseJson.Result;

                            if ($$$.responseIsSuccess(result)) {
                                var resourceExporter = result.ResourceExporter;

                                if (resourceExporter['@Success'] === 'True') {
                                    status.message('Resources exported succesfully. Click <a href="' + $$$.currentWebUrl + '/_layouts/epmlive/filedownloader.aspx?fileid=' + resourceExporter['@File'] + '&filename=Resources.xlsm&ct=application/ms-excel">here</a> to download the spreadsheet.');
                                    statusbar.color('blue');
                                } else {
                                    var message = resourceExporter['@Message'];

                                    $$$.log(message);

                                    status.title('Error');
                                    status.message('Unable to export resources. The response was: ' + message);
                                    statusbar.color('red');
                                }
                            } else {
                                $$$.log(result);

                                status.title('Error');
                                status.message('Unable to export resources. The response was: ' + result);
                                statusbar.color('red');
                            }
                        } else {
                            $$$.log(resp.d);

                            status.title('Error');
                            status.message('Unable to export resources. There was no response from the server.');
                            statusbar.color('red');
                        }

                        $$.exportInProgress = false;
                        window.RefreshCommandUI();
                    },

                    error: function (err) {
                        $$$.log(err);

                        status.title('Error');
                        status.message('Unable to export resources. The response was: (' + err.status + ') ' + err.statusText);
                        statusbar.color('red');

                        $$.exportInProgress = false;
                        window.RefreshCommandUI();
                    }
                });
            },

            importResources: function () {
                var options = window.SP.UI.$create_DialogOptions();

                options.title = 'Import Resources';
                options.url = $$$.currentWebUrl + '/_layouts/epmlive/importresources.aspx';
                options.dialogReturnValueCallback = window.epmLiveResourceGrid.actions.onImportResourcesCompleted;

                window.SP.UI.ModalDialog.showModalDialog(options);
            },

            onImportResourcesCompleted: function (result, value) {
                if (result === 1) {
                    $$.grid.reload();
                }
            },

            canExport: function () {
                return !$$.exportInProgress && $$.userIsSiteAdmin;
            },

            canImport: function () {
                return !$$.importInProgress && $$.userIsSiteAdmin;
            }
        };

        window.Grids.OnClick = function (grid, row, col, x, y, evt) {
            window.SelectRibbonTab('Ribbon.ResourceGridTab', true);
            $$.actions.hideEasyScroll(true);

            if (row.Kind === 'Data' && row.Def.Name === 'R') {
                var status;

                if ((evt.shiftKey && evt.ctrlKey) || (!evt.shiftKey && !evt.ctrlKey)) {

                    var selectionStatus = row.Selected;

                    if (col !== 'Panel') {
                        grid.ActionClearSelection();
                    }
                    status = grid.SelectRow(row, !selectionStatus);
                } else if (evt.shiftKey) {
                    var selectedRows = grid.GetSelRows();
                    grid.ActionClearSelection();
                    status = selectedRows ? grid.SelectRange(selectedRows[0], null, row, null, 1, 1) : grid.SelectRow(row, !row.Selected);
                } else {
                    status = grid.SelectRow(row, !row.Selected);
                }

                if (status !== null) {
                    window.RefreshCommandUI();
                    return true;
                }
            } else if (row.Def.Name === 'Group') {
                if (col === 'Panel') {
                    grid.SelectRow(row, !row.Selected);

                    var child = row.firstChild;

                    while (child) {
                        grid.SelectRow(child, row.Selected);
                        child = child.nextSibling;
                    }

                    window.RefreshCommandUI();

                    return true;
                }
            } else if (row.Kind === 'Header' && col === 'Panel') {
                $$.allSelected = !$$.allSelected;

                window.setTimeout(function () {
                    window.RefreshCommandUI();
                }, 100);
            }
        };

        window.Grids.OnExpand = function (grid, row) {
            if ($.browser.msie) {
            window.setTimeout(function () {
                    grid.Render();
                    grid.Update();
                    grid.Render();

                    window.setTimeout(function () {
                        grid.Render();
                        grid.Update();
                        grid.Render();
                        grid.Render();

                        grid.SetScrollTop(grid.GetScrollTop() + 2);
                        grid.SetScrollTop(grid.GetScrollTop() - 2);
                    }, 200);

                }, 200);
            }
        };

        window.Grids.OnColumnsChanged = function (grid, cols, count) {
            var lastCol = grid.GetLastCol("1");

            for (var col in cols) {
                if (cols[col]) {
                    grid.MoveCol(col, lastCol, true, 0);
                }
            }

            var profilePicCol = cols['ProfilePic'];
            if (!profilePicCol) {
                if (!cols.length) {
                    try {
                        profilePicCol = cols.ProfilePic;
                    } catch (e) {
                    }
                }
            }

            if (profilePicCol !== undefined) {
                grid.SetAttribute(null, 'ProfilePic', 'Visible', '0', 0);
                grid.Rerender();
            }
        };

        window.Grids.OnReady = function (grid, start) {
            $$.id(grid.id);

            $$.views.load();
            $$.reports.load();
        };

        window.Grids.OnUpdated = function (grid) {
            $$.grid.resetNoDataRow();
        };

        window.Grids.OnLoaded = function (grid) {
            var offset = $.browser.msie ? 20 : 5;
            var webPartHeight = $$.webpartHeight;

            var maxHeight = webPartHeight;

            if (!webPartHeight) {
                maxHeight = $('#s4-workspace').height() - ($('#s4-titlerow').height() + $('#EPMLiveStatusbar').height() + $('#EPMLiveStatusbarTemplate').height() + $('#EPMLiveStatuTemplate').height() + $('#s4-statusbarcontainer').height() + offset) - 100;
            }

            grid.MaxVScroll = maxHeight;

            if (!webPartHeight) {
                $('#MSOZoneCell_WebPart' + $$.webpartQualifier).height(maxHeight);
                $('#WebPart' + $$.webpartQualifier).height(maxHeight);
            }

            var win = $(window);

            $$.winHeight = win.height();

            win.resize(function () {
                var height = $(this).height();
                var winHeight = $$.winHeight;

                var newHeight;

                if (height < winHeight) {
                    newHeight = -(winHeight - height);
                } else {
                    newHeight = height - winHeight;
                }

                newHeight += 100;

                if (newHeight !== 0) {
                    grid.MaxVScroll += newHeight;
                    $$.winHeight = height;

                    grid.Update();
                }
            });

            grid.Update();
            grid.Render();

            window.setTimeout(function () { $$.actions.loadRibbon(); }, 1500);

            $('#s4-workspace').click(function () {
                window.SelectRibbonTab('Ribbon.ResourceGridTab', true);
            });
        };

        window.Grids.OnGetHtmlValue = function (grid, row, col, val) {
            if (row.Def.Name === 'Group') {
                if (col !== 'Panel' && col !== 'Title') {
                    return '';
                }
            } else if (grid.Cols[col] && grid.Cols[col].Type === 'Lines') {
                return val;
            }
        };

        window.Grids.OnGetColor = function (grid, row, col, r, g, b, edit) {
            if (col === 'Title') {
                if ((r === 230 || r === 180 || r === 255) && (g === 242 || g === 217 || g === 255) && (b === 251 || b === 243 || b === 255)) {
                    if (row.r0) {
                        var panel = $(row.r0).find('.GSCellPanel');

                        if (panel) {
                            if (r === 230 && g === 242 && b === 251) {
                                $(panel).addClass('EPMLiveResourceGridPanelHovered');
                            } else if (r === 180 && g === 217 && b === 243) {
                                $(panel).addClass('EPMLiveResourceGridPanelHoveredSelected');
                            } else {
                                $(panel).removeClass('EPMLiveResourceGridPanelHovered EPMLiveResourceGridPanelHoveredSelected');
                            }
                        }
                    }
                }
            }

            return null;
        };

        window.SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs("EPMLive.ResourceGrid.js");
    }(window.epmLiveResourceGrid = window.epmLiveResourceGrid || {}, window.epmLive, window.jQuery, window.ko));
};

ExecuteOrDelayUntilScriptLoaded(registerEpmLiveResourceGridScript, 'EPMLive.js');

if (!window.console) console = {};

console.error = console.error || function () {
};

console.log = console.log || function () {
};