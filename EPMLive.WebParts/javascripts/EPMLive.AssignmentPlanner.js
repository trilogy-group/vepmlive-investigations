function registerAssignmentPlannerScript() {
    (function ($$, $$$, $, undefined) {
        $$.id = null;
        $$.userId = null;
        $$.startDate = null;
        $$.dueDate = null;
        $$.newStartDate = null;
        $$.newDueDate = null;
        $$.iconUrl = $$$.currentWebUrl + '/_layouts/epmlive/images/mywork/';
        $$.maxVScroll = null;
        $$.forceHeight = false;
        $$.showingComments = false;
        $$.epmrgv = null;
        $$.curDateRangeType = null;
        $$.firstLoad = true;

        $$.grid = {
            g: null,
            checkedForChanges: false,
            filteringOn: true,
            groupingOn: true,
            dataFunction: null,
            dataXml: null,

            actions: {
                calculateUsage: function (grid, row) {
                    return row.StartDate && row.DueDate && row.Work && row.AssignedToText ? row.AssignedToText + '*' + (row.Work / grid.DiffGanttDate(row.DueDate, row.StartDate, 'd')) : '';
                },

                rowSelectionChanged: function (grid, row, deselect) {
                    grid.SetValue(row, 'R', deselect ? '' : $$.grid.actions.calculateUsage(grid, row), true);
                    return true;
                },

                updateFlag: function (grid, row) {
                    if (row.Def.Name === 'Header' || row.Def.Name === 'Fixed' || row.Def.Name === 'Group' || row.Def.Name === 'Solid') {
                        return;
                    }

                    grid.CloseDialog();

                    var flag = 1;

                    var value = grid.GetValue(row, 'FlagValue');
                    if (value === '1' || value === 1) flag = 0;

                    var dataXml = '<MyPersonalization><Item ID="{0}"/><List ID="{1}"/><Web ID="{2}"/><Site ID="{3}" URL="{4}"/><Personalizations><Personalization Key="AssignmentPlannerFlag" Value="{5}" /></Personalizations></MyPersonalization>'.format(row.ID, row.ListId, row.WebId, row.SiteId, $$$.currentSiteUrl, flag);

                    $.ajax({
                        type: 'POST',
                        url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                        data: "{ Function: 'SetMyPersonalization', Dataxml: '" + dataXml + "' }",
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',

                        success: function (response) {
                            if (response.d) {
                                var responseJson = $$$.parseJson(response.d);

                                if ($$$.responseIsSuccess(responseJson.Result)) {
                                    grid.SetValue(row, 'FlagValue', flag, 1);

                                    var flagUrl = '<img src="' + $$.iconUrl + 'unflagged.png" class="AP_Flag"/>';
                                    if (flag) flagUrl = '<img src="' + $$.iconUrl + 'flagged.png" class="AP_Flag"/>';

                                    grid.SetValue(row, 'Flag', flagUrl, 1);
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

                processComments: function (grid, row) {
                    var commentCount = grid.GetValue(row, 'CommentCount');

                    if (grid.GetValue(row, 'CommentProcessed')) return commentCount;

                    grid.SetValue(row, 'CommentProcessed', true, 0);

                    var isCommentRead = function (value) {
                        if ($$$.utils.isInt(value)) {
                            return value === $$.userId;
                        }

                        if (value.indexOf(',') !== -1) {
                            var commentViewers = value.split(',');

                            for (var i = 0; i < commentViewers.length; i++) {
                                if (parseInt(commentViewers[i] === $$.userId)) return true;
                            }
                        }

                        return false;
                    };

                    if (commentCount) {
                        var commentRead = isCommentRead(grid.GetValue(row, 'CommentersRead'));

                        return '<div id="AP_CommentCount_{0}" class="{1}" onclick="window.epmLive.assignmentPlanner.actions.showComments();" style="cursor:pointer;">{2}</div>'.format(row.id, !commentRead ? 'AP_Comment' : 'AP_CommentRead', commentCount);
                    }

                    return '<div class="AP_CommentDisabled">&nbsp;</div>';
                },

                cellValueChanged: function (grid, row, col, event) {
                    if (col === 'StartDate' || col === 'DueDate') {
                        var rows = grid.Rows;

                        if (rows) {
                            var value = grid.GetValue(row, col);

                            for (var r in rows) {
                                if (rows.hasOwnProperty(r)) {
                                    var theRow = rows[r];

                                    if (theRow.Kind === 'Data' && theRow.id !== row.id && theRow.ID === row.ID) {
                                        grid.SetValue(theRow, col, value, 1);
                                    }
                                }
                            }
                        }
                    }

                    return true;
                }
            },

            resetNoDataRow: function () {
                var gridTable = $('#' + $$.id)[0];

                if (gridTable) {
                    var tableBodyElement = gridTable.firstChild;

                    if (!$$.grid.g.GetFirstVisible()) {
                        gridTable.removeChild(tableBodyElement);
                        var row = gridTable.insertRow(0);
                        var cell = row.insertCell(0);

                        cell.innerHTML = 'No assignments found.';
                    }
                }
            },

            totalRowsSelected: function () {
                return this.g.GetSelRows().length;
            },

            hasChanges: function () {
                if (!this.checkedForChanges) {
                    this.checkedForChanges = true;
                    setTimeout('window.RefreshCommandUI()', 1000);
                } else {
                    this.checkedForChanges = false;
                }

                var changes = this.g.HasChanges().toString(2);
                return changes[changes.length - 1] === '1';
            },

            reload: function () {
                var removeUrlParameter = function (uri, parameter) {
                    var urlparts = uri.split('?');

                    if (urlparts.length >= 2) {
                        var urlBase = urlparts.shift();
                        var queryString = urlparts.join("?");

                        var prefix = encodeURIComponent(parameter) + '=';
                        var pars = queryString.split(/[&;]/g);
                        for (var i = pars.length; i-- > 0; ) {
                            if (pars[i].lastIndexOf(prefix, 0) !== -1) {
                                pars.splice(i, 1);
                            }
                        }

                        uri = urlBase + '?' + pars.join('&');
                    }

                    return uri;
                };

                var url = removeUrlParameter(window.location.href, 'epmrgv');
                url = removeUrlParameter(url, 'startdate');
                url = removeUrlParameter(url, 'duedate');

                url = (url + (url.indexOf('?') !== -1 ? '&' : '?') + 'epmrgv=' + $$.views.currentView.id + '&startdate=' + $$.newStartDate + '&duedate=' + $$.newDueDate);
                window.location = url;
            },

            showColumnSelector: function () {
                $$.grid.g.ActionShowColumns('Selectable');
            },

            hideRow: function (rowId) {
                var grid = $$.grid.g;
                grid.HideRow(grid.GetRowById(rowId));
            },

            showRow: function (rowId) {
                var grid = $$.grid.g;
                grid.ShowRow(grid.GetRowById(rowId));
            },

            hideFilters: function () {
                this.hideRow('AR1');
                this.filteringOn = false;

                if ($.browser.msie) {
                    window.setTimeout(function () {
                        var g = $$.grid.g;
                        g.Render();
                    }, 1);
                }
            },

            showFilters: function () {
                this.showRow('AR1');
                this.filteringOn = true;

                if ($.browser.msie) {
                    window.setTimeout(function () {
                        var g = $$.grid.g;
                        g.Render();
                    }, 1);
                }
            },

            hideGrouping: function () {
                var grid = $$.grid.g;
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

                if ($.browser.msie) {
                    window.setTimeout(function () {
                        var g = $$.grid.g;
                        g.Render();
                    }, 1);
                }
            },

            showGrouping: function () {
                var grid = $$.grid.g;
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

                if ($.browser.msie) {
                    window.setTimeout(function () {
                        var g = $$.grid.g;
                        g.Render();
                    }, 1);
                }
            },

            toggleFiltering: function () {
                if (this.filteringOn) {
                    this.hideFilters();
                } else {
                    this.showFilters();
                }

                return this.filteringOn;
            },

            toggleGrouping: function () {
                if (this.groupingOn) {
                    this.hideGrouping();
                } else {
                    this.showGrouping();
                }

                return this.groupingOn;
            },

            removeSorting: function () {
                $$.grid.g.ChangeSort('StartDate');
            },

            canZoomIn: function () {
                return $$.grid.g.CanZoomIn();
            },

            zoomIn: function () {
                if ($$.grid.canZoomIn()) {
                    var grid = $$.grid.g;

                    grid.ActionZoomIn();

                    if ($.browser.msie) {
                        window.setTimeout(function () {
                            var g = $$.grid.g;
                            g.Render();
                        }, 1);
                    }
                }
            },

            canZoomOut: function () {
                return $$.grid.g.CanZoomOut();
            },

            zoomOut: function () {
                if ($$.grid.canZoomOut()) {
                    var grid = $$.grid.g;

                    grid.ActionZoomOut();

                    if ($.browser.msie) {
                        window.setTimeout(function () {
                            var g = $$.grid.g;
                            g.Render();
                        }, 1);
                    }
                }
            },

            zoomToFit: function () {
                $$.grid.g.ActionZoomFit();
            },

            scrollTo: function () {
                var grid = $$.grid.g;
                var row = grid.FRow;

                if (row) {
                    var startDate = grid.GetValue(row, 'StartDate');

                    if (startDate) {
                        grid.ScrollToDate(new Date(startDate), 'left');
                    }
                }
            },

            reloadData: function (result, target) {
                if (result !== 1) return;

                $$.views.previousView = $$.views.currentView.id;

                var grid = $$.grid.g;
                grid.Reload(grid.Source, null, false);
            }
        };

        $$.views = {
            collection: {},
            currentView: null,
            previousView: null,
            userHasGlobalViewModificationPermission: false,

            build: function (view) {
                var grid = $$.grid.g;

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

                var filterRow = grid.GetRowById('AR1');

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
                var viewXml = '<View Id="{0}" Name="{1}" IsDefault="{2}" IsPersonal="{3}"><Cols>'.format(view.id, view.name, view.isdefault, view.ispersonal);

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
                var grid = $$.grid.g;

                grid.StaticCursor = 1;

                view.id = (view.name !== 'Default View') ? $$$.md5(view.name) : 'dv';

                if (this.collection[view.id]) {
                    if (!confirm('Would you like to overwrite the "' + view.name + '" view?')) return;
                }

                view = this.build(view);

                $.ajax({
                    type: 'POST',
                    url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'AssignmentPlanner_SaveViews', Dataxml: '<View>" + this.getXml(view) + "</View>' }",
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
                var grid = $$.grid.g;

                var element = document.createElement('div');
                element.innerHTML = $('#APSaveView-{0}'.format($$.id)).html();

                $($(element).find('#APSaveView-Name-{0}'.format($$.id))).val(this.currentView.name);

                if (this.currentView.isdefault) {
                    $($(element).find('#APSaveView-Default-{0}'.format($$.id))).attr('checked', 'checked');
                }

                var isPersonalCheckbox = $(element).find('#APSaveView-Personal-{0}'.format($$.id));

                if (!$(isPersonalCheckbox).is(':disabled')) {
                    if (this.currentView.ispersonal) {
                        $(isPersonalCheckbox).attr('checked', 'checked');
                    }
                }

                var isMSIE = $.browser.msie;

                var height = isMSIE ? 120 : 115;
                var width = isMSIE ? 220 : 215;

                var options = window.SP.UI.$create_DialogOptions();

                options.title = 'Save View';
                options.html = element;
                options.height = height;
                options.width = width;
                options.allowMaximize = false;
                options.showClose = false;
                options.dialogReturnValueCallback = Function.createDelegate(null, $$.views.showSaveDialogClosed);

                grid.StaticCursor = 0;
                grid.ActionBlur();

                window.SP.UI.ModalDialog.showModalDialog(options);
            },

            apply: function (viewId) {
                $$.actions.updateSplashStatus('Applying view');

                var view = null;

                var previousViewId = $$$.getUrlParamByName('epmrgv');

                if (previousViewId && $$.firstLoad) {
                    if (this.collection[previousViewId]) {
                        viewId = previousViewId;
                        $$.epmrgv = previousViewId;
                    }
                } else if (this.previousView) {
                    this.currentView = null;
                    viewId = this.previousView;
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

                var grid = $$.grid.g;

                var allCols = [];
                var mainCols = [];

                for (var i = 0; i < view.cols.length; i++) {
                    var col = view.cols[i];
                    var colName = col.name;

                    grid.MoveCol(colName, col.section, 1, 1);

                    allCols.push(colName);
                }

                grid.Render();
                grid.Update();

                var groupCols = grid.Group.split(',');

                grid.DoGrouping(null);

                for (var j = 0; j < groupCols.length; j++) {
                    grid.HideCol(groupCols[j]);
                }

                var visibleCols = grid.GetCols('Visible');
                visibleCols = visibleCols.concat(groupCols);

                for (var l = 0; l < visibleCols.length; l++) {
                    var found = false;
                    var visibleCol = visibleCols[l];

                    for (var m = 0; m < allCols.length; m++) {
                        found = allCols[m] === visibleCol;
                    }

                    if (!found) {
                        mainCols.push(visibleCol);
                    }
                }

                grid.ChangeColsVisibility(allCols, mainCols, 0);

                var filterValues = [];
                var filterOperatios = [];

                for (var k = 0; k < allCols; k++) {
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
                }

                if (view.filterrowvisible) {
                    $$.grid.showFilters();
                } else {
                    $$.grid.hideFilters();
                }

                grid.ChangeSort(view.sorting);

                if (view.groupingrowvisible) {
                    $$.grid.showGrouping();
                } else {
                    $$.grid.hideGrouping();
                }

                grid.DoGrouping(view.grouping || null);

                grid.Update();
                grid.Render();

                this.currentView = view;
                this.previousView = null;

                window.RefreshCommandUI();

                if ($$.firstLoad) {
                    window.setTimeout(function () {
                        $$.firstLoad = false;
                        grid.SuppressMessage = 0;
                    }, 2000);
                }

                if (grid.Resources) {
                    var counter = 0;

                    for (var resource in grid.Resources) {
                        counter++;

                        if (counter > 1) break;
                    }

                    if (counter === 1) {
                        grid.ExpandAll();
                    }
                }

                $$.grid.zoomToFit();

                $(".GSHeaderRow").each(function () {
                    var tr = $(this);
                    var text = tr.text().trim().replace(/ +?/g, '').replace(String.fromCharCode(65279), '');

                    if (text === 'Resource' || text === 'ResourceUsage') {
                        tr.find('td').each(function () {
                            $(this).css('font-weight', 'bold');
                        });
                    }
                });

                $('#EPMSplashContainer').hide();

                if ($.browser.msie) {
                    window.setTimeout(function () {
                        var g = $$.grid.g;
                        g.Update();
                        g.Render();
                    }, 10);
                }
            },

            load: function () {
                $$.actions.updateSplashStatus('Loading views');

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
                    };

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
                    }
                };

                $.ajax({
                    type: 'POST',
                    url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'AssignmentPlanner_LoadViews', Dataxml: '<Views/>' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',

                    success: function (response) {
                        if (response.d) {
                            var responseJson = $$$.parseJson(response.d);

                            var result = responseJson.Result;

                            if ($$$.responseIsSuccess(result)) {
                                register(result.AssignmentPlannerViews.Views.View);
                                $$.views.apply();
                            } else {
                                $$$.logFailure(result);
                                $('#EPMSplashContainer').hide();
                            }
                        } else {
                            $$$.log('response.d: ' + response.d);
                            $('#EPMSplashContainer').hide();
                        }
                    },

                    error: function (error) {
                        $$$.log(error);
                        $('#EPMSplashContainer').hide();
                    }
                });
            },

            getXmlForRibbon: function () {
                var viewCollection = this.collection;
                var currentView = this.currentView;
                var sb = new window.Sys.StringBuilder();

                function appendViews(viewType) {
                    sb.append("<MenuSection DisplayMode='Menu' Id='Ribbon.AssignmentPlanner.Views.Dropdown.Menu.{0}' Title='{0} Views'>".format(viewType));
                    sb.append("<Controls Id='Ribbon.AssignmentPlanner.Views.Dropdown.Menu.{0}.Controls'>".format(viewType));

                    var isPersonal = (viewType === 'Personal');

                    for (var v in viewCollection) {
                        if (viewCollection.hasOwnProperty(v)) {
                            var view = viewCollection[v];

                            if (view.name) {
                                if (view.ispersonal === isPersonal) {
                                    sb.append("<Button Id='Ribbon.AssignmentPlanner.views.{0}' Command='AssignmentPlanner.Cmd.CurrentViewDropDown.Select' LabelText='{1}' CommandValueId='{0}'/>".format(view.id, view.name));
                                }
                            }
                        }
                    }

                    sb.append('</Controls>');
                    sb.append('</MenuSection>');
                };

                sb.append("<Menu Id='Ribbon.AssignmentPlanner.Views.Dropdown.Menu'>");

                sb.append("<MenuSection DisplayMode='Menu' Id='Ribbon.AssignmentPlanner.Views.Dropdown.Menu.Default' Title='Current View'>");
                sb.append("<Controls Id='Ribbon.AssignmentPlanner.Views.Dropdown.Menu.Default.Controls'>");
                sb.append("<Button Id='Ribbon.AssignmentPlanner.views.{0}' Command='AssignmentPlanner.Cmd.CurrentViewDropDown.Select' LabelText='{1}' CommandValueId='{0}'/>".format(currentView.id, currentView.name));
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
                    data: "{ Function: 'AssignmentPlanner_DeleteViews', Dataxml: '<View>" + this.getXml(currentView) + "</View>' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',

                    success: function (response) {
                        if (response.d) {
                            var responseJson = $$$.parseJson(response.d);

                            if ($$$.responseIsSuccess(responseJson.Result)) {
                                window.SP.UI.Notify.addNotification('The view "{0}" has been deleted.'.format(currentView.name), false);

                                delete $$.views.collection[currentView.id];
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
                    data: "{ Function: 'AssignmentPlanner_UpdateViews', Dataxml: '<View>" + this.getXml(currentView) + "</View>' }",
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
                var grid = $$.grid.g;

                var element = document.createElement('div');
                element.innerHTML = $('#APRenameView-{0}'.format($$.id)).html();

                $($(element).find('#APRenameView-CurrentName-{0}'.format($$.id))).html(this.currentView.name);

                var isMSIE = $.browser.msie;

                var height = isMSIE ? 95 : 100;
                var width = isMSIE ? 235 : 240;

                var options = window.SP.UI.$create_DialogOptions();

                options.title = 'Rename View';
                options.html = element;
                options.height = height;
                options.width = width;
                options.allowMaximize = false;
                options.showClose = false;
                options.dialogReturnValueCallback = Function.createDelegate(null, $$.views.showRenameDialogClosed);

                grid.StaticCursor = 0;
                grid.ActionBlur();

                window.SP.UI.ModalDialog.showModalDialog(options);
            },

            showSaveDialogClosed: function (result, view) {
                if (result === window.SP.UI.DialogResult.OK) {
                    $$.views.save(view);
                }
            },

            showRenameDialogClosed: function (result, name) {
                if (result === window.SP.UI.DialogResult.OK) {
                    $$.views.rename(name);
                }
            }
        };

        $$.models = {
            collection: [],

            load: function () {
                var register = function (models) {
                    $$.models.collection = [];

                    if (!models.length) {
                        models = [models];
                    }

                    for (var i = 0; i < models.length; i++) {
                        $$.models.collection.push(models[i]["@Name"]);
                    }
                };

                $.ajax({
                    type: 'POST',
                    url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'AssignmentPlanner_LoadModels', Dataxml: '<Models/>' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',

                    success: function (response) {
                        if (response.d) {
                            var responseJson = $$$.parseJson(response.d);

                            var result = responseJson.Result;

                            if ($$$.responseIsSuccess(result)) {
                                register(result.AssignmentPlannerModels.Models.Model);
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

            save: function () {
                var modelExists = function (name) {
                    if ($$.models.collection[name]) {
                        return true;
                    }

                    return false;
                };

                var modelName = prompt('Please enter model name:', '');

                var proceed = true;

                if (modelExists(modelName)) {
                    proceed = confirm('The model with name {0} already exists. Do you want to overwrite this model?'.format(modelName));
                }

                if (!proceed) return;

                var grid = $$.grid.g;

                var data = grid.GetXmlData('Data,Resources');
                var encodedData = $$$.utils.base64.encode(data);

                $.ajax({
                    type: 'POST',
                    url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'AssignmentPlanner_SaveModels', Dataxml: '<Models><Model Name=\"" + modelName + "\"><![CDATA[" + encodedData + "]]></Model></Models>' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',

                    success: function (response) {
                        if (response.d) {
                            var responseJson = $$$.parseJson(response.d);

                            var result = responseJson.Result;

                            if ($$$.responseIsSuccess(result)) {
                                window.SP.UI.Notify.addNotification('Model has been saved successfully.', false);
                                $$.models.load();
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

            showOpenDialog: function () {
                var grid = $$.grid.g;

                var element = document.createElement('div');
                element.innerHTML = $('#APOpenModel-{0}'.format($$.id)).html();

                var modelList = $(element).find('#APOpenModel-ModelList-{0}'.format($$.id));

                for (var i = 0; i < $$.models.collection.length; i++) {
                    var model = $$.models.collection[i];
                    $(modelList).append('<option value="' + model + '">' + model + '</option>');
                }

                var isMSIE = $.browser.msie;

                var height = isMSIE ? 90 : 85;
                var width = isMSIE ? 215 : 210;

                var options = window.SP.UI.$create_DialogOptions();

                options.title = 'Open Model';
                options.html = element;
                options.height = height;
                options.width = width;
                options.allowMaximize = false;
                options.showClose = false;
                options.dialogReturnValueCallback = Function.createDelegate(null, $$.models.showOpenDialogClosed);

                grid.StaticCursor = 0;
                grid.ActionBlur();

                window.SP.UI.ModalDialog.showModalDialog(options);
            },

            open: function (name) {
                if (name) {
                    var grid = $$.grid.g;

                    var source = grid.Source;

                    if (!$$.grid.dataFunction) {
                        $$.grid.dataFunction = source.Data.Param.Function;
                    }

                    if (!$$.grid.dataXml) {
                        $$.grid.dataXml = source.Data.Param.Dataxml;
                    }

                    source.Data.Param.Function = 'AssignmentPlanner_GetModel';
                    source.Data.Param.Dataxml = $('<div/>').text('<AssignmentPlannerModel Name="' + name + '"></AssignmentPlannerModel>').html();

                    grid.Reload(source, null, false);

                    window.setTimeout(function () {
                        try {
                            $$.grid.hideFilters();
                        } catch (e) { }

                        try {
                            $$.grid.hideGrouping();
                        } catch (e) { }
                    }, 1000);
                }
            },

            clear: function () {
                var dataFunction = $$.grid.dataFunction;
                var dataXml = $$.grid.dataXml;

                if (dataFunction && dataXml) {
                    var grid = $$.grid.g;

                    var source = grid.Source;

                    source.Data.Param.Function = dataFunction;
                    source.Data.Param.Dataxml = dataXml;

                    grid.Reload(source, null, false);

                    window.setTimeout(function () {
                        try {
                            $$.grid.hideFilters();
                        } catch (e) { }

                        try {
                            $$.grid.hideGrouping();
                        } catch (e) { }
                    }, 1000);
                }
            },

            showOpenDialogClosed: function (result, name) {
                if (result === window.SP.UI.DialogResult.OK) {
                    $$.models.open(name);
                }
            }
        };

        $$.actions = {
            close: function () {
                window.SP.UI.ModalDialog.commonModalDialogClose(window.SP.UI.DialogResult.cancel);
            },

            publish: function () {
                var grid = $$.grid.g;

                var publishXml = '<Publish><Data><Items>';

                var changes = $$$.parseJson(grid.GetChanges());

                var changedRows = changes.Grid.Changes.I;

                if (!changedRows.length) changedRows = [changedRows];

                for (var i = 0; i < changedRows.length; i++) {
                    var changedRow = changedRows[i];

                    var id;
                    var changedProperties = [];

                    for (var r in changedRow) {
                        if (changedRow.hasOwnProperty(r)) {
                            if (r === '@id') {
                                id = changedRow[r];
                                continue;
                            }

                            if (r === '@StartDate' || r === '@DueDate') {
                                changedProperties.push({ property: r.replace('@', ''), value: changedRow[r] });
                            }
                        }
                    }

                    if (!id) continue;

                    var row = grid.GetRowById(id);

                    publishXml += '<Item SiteId="' + row.SiteId + '" WebId="' + row.WebId + '" ListId="' + row.ListId + '" ItemId="' + row.ID + '" ';

                    for (var j = 0; j < changedProperties.length; j++) {
                        var changedProperty = changedProperties[j];

                        publishXml += changedProperty.property + '="' + changedProperty.value + '" ';
                    }

                    publishXml += '/>';
                }

                publishXml += '</Items></Data></Publish>';

                $.ajax({
                    type: 'POST',
                    url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                    data: "{ Function: 'AssignmentPlanner_Publish', Dataxml: '" + publishXml + "' }",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',

                    success: function (response) {
                        if (response.d) {
                            var responseJson = $$$.parseJson(response.d);

                            if ($$$.responseIsSuccess(responseJson.Result)) {
                                window.SP.UI.Notify.addNotification('All updates have been published.', false);
                                grid.AcceptChanges();
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

            print: function () {
                $$.grid.g.ActionPrint();
            },

            exportExcel: function () {
                $$.grid.g.ActionExport();
            },

            showComments: function () {
                $$.actions.redirect('showcomments');
            },

            onCommentsPopupColsed: function () {
                $$.showingComments = false;
            },

            redirect: function (operation) {
                var grid = $$.grid.g;

                var selRows = grid.GetSelRows();

                if (selRows.length !== 1) return;

                var selRow = selRows[0];

                var id = selRow.ID;

                var url = '{0}/_layouts/epmlive/redirectionproxy.aspx?webid={1}&listname={2}'.format($$$.currentWebUrl, selRow.WebId, selRow.Work__Type);

                switch (operation) {
                    case 'edit':
                        $$.actions.displayPopUp('{0}&action=edit&id={1}'.format(url, id), null, true, true, $$.grid.reloadData);
                        break;
                    case 'showcomments':
                        if (!$$.showingComments) {
                            $$.actions.displayPopUp('{0}&action={1}&id={2}'.format(url, operation, id), null, true, true, $$.actions.onCommentsPopupColsed, null, 600, 500);
                            $$.showingComments = true;
                        }
                        break;
                    default:
                        $$.actions.displayPopUp('{0}&action={1}&id={2}'.format(url, operation, id));
                        break;
                }
            },

            displayPopUp: function (url, title, allowMaximize, showClose, func, funcParams, width, height) {
                if (allowMaximize === undefined || allowMaximize === null) allowMaximize = true;
                if (!showClose) showClose = true;
                if (!func) {
                    func = function () {
                    };
                }

                var options = {
                    title: title,
                    allowMaximize: allowMaximize,
                    showClose: showClose,
                    url: url,
                    dialogReturnValueCallback: Function.createCallback(Function.createDelegate(null, func), funcParams)
                };

                if (width) {
                    options.width = width;
                }

                if (height) {
                    options.height = height;
                }

                window.SP.UI.ModalDialog.showModalDialog(options);
            },

            setFromTo: function () {
                $('.ms-cui-ctl-medium').each(function () {
                    var ele = $(this);
                    if (this.id === 'Ribbon.AssignmentPlanner.Views.From-Medium') {
                        ele.find('.ms-cui-ctl-mediumlabel').first().text('From: ' + $$.startDate);
                    } else if (this.id === 'Ribbon.AssignmentPlanner.Views.To-Medium') {
                        ele.find('.ms-cui-ctl-mediumlabel').first().text('To: ' + $$.dueDate);
                    }
                });
            },

            updateDateRange: function (type, value) {
                var grid = $$.grid.g;

                if (!value) {
                    window.curTempDate = $$.dueDate;
                    $$.curDateRangeType = 'To';

                    if (type === 'From') {
                        window.curTempDate = $$.startDate;
                        $$.curDateRangeType = 'From';
                    }

                    var options = {
                        url: '{0}/_layouts/epmlive/SelectDate.aspx'.format($$$.currentWebUrl),
                        width: 280,
                        height: 280,
                        title: 'Select {0} Date:'.format(type),
                        dialogReturnValueCallback: Function.createDelegate(null, $$.actions.updateDateRangeClosed)
                    };

                    grid.StaticCursor = 0;
                    grid.ActionBlur();

                    window.SP.UI.ModalDialog.showModalDialog(options);
                } else {
                    var newDate = new Date(value);
                        if (type === 'From') {
                            if (currentDateFormat.slice(0, (currentDateFormat.length - (currentDateFormat.length - 1))) == "d") {
                                var duedateForFormat = $$.dueDate.split(/[/.]+/);
                                    var dueDateNewFormat = duedateForFormat[1] + "/" + duedateForFormat[0] + "/" + duedateForFormat[2];
                                }
                                else {
                                    var dueDateNewFormat = $$.dueDate;
                                }
                                if (newDate <= new Date(dueDateNewFormat)) {
                                    $$.newStartDate = '{0}/{1}/{2}'.format(newDate.getMonth() + 1, newDate.getDate(), newDate.getFullYear());
                                    $$.newDueDate = dueDateNewFormat;
                                    $$.grid.reload();
                                } else {
                                    alert('The start date must be less than or equal to the due date.');
                                }
                            } else {
                            if (currentDateFormat.slice(0, (currentDateFormat.length - (currentDateFormat.length - 1))) == "d") {
                                var startdateForFormat = $$.startDate.split(/[/.]+/);
                                    var startDateNewFormat = startdateForFormat[1] + "/" + startdateForFormat[0] + "/" + startdateForFormat[2];
                                }
                                else {
                                var startDateNewFormat = $$.startDate;
                                }
                                if (newDate >= new Date(startDateNewFormat)) {
                                    $$.newDueDate = '{0}/{1}/{2}'.format(newDate.getMonth() + 1, newDate.getDate(), newDate.getFullYear());
                                    $$.newStartDate = startDateNewFormat;
                                    $$.grid.reload();
                                } else {
                                    alert('The due date must be greater than or equal to the start date.');
                                }
                            }
                }
            },

            updateDateRangeClosed: function (result, value) {
                if (result === window.SP.UI.DialogResult.OK) {
                    $$.actions.updateDateRange($$.curDateRangeType, value);
                }
            },

            updateSplashStatus: function (status) {
                $('#EPMSplashStatus').text(status + ' . . .');
            }
        };

        window.Grids.OnReady = function (grid, start) {
            if (grid.id === $$.id) {
                $$.grid.g = window.Grids[$$.id];

                $$.views.load();
                //$$.models.load();

                window.setTimeout(function () {
                    var element = $('.SummaryTask.GSPx0xx');

                    element.hover(function () {
                        $(this).css('cursor', 'pointer');
                    });

                    element.removeClass('GSPx0xx').addClass('GSPx1xx EPM_AssignmentPlanner_Selector');

                    element.attr('data-selected', 'false');

                    $(window).resize(function () { $$.actions.setFromTo(); });
                }, 1000);
            }
        };

        window.Grids.OnLoaded = function (grid) {
            if (grid.id === $$.id) {
                if (!$$.forceHeight) {
                    var maxVScroll = $$.maxVScroll;

                    if (maxVScroll) {
                        grid.MaxVScroll = maxVScroll;
                    } else {
                        grid.NoVScroll = 1;
                    }
                }

                $$.actions.updateSplashStatus('Rendering data');
            }
        };

        window.Grids.OnRenderFinish = function(grid) {
            if (grid.id === $$.id) {
                if ($$.forceHeight) {
                    var height = $(parent.document.getElementsByTagName('iframe')[1]).parent().height() - $(document.getElementById('s4-ribbonrow')).height();

                    $('td.HideCol0Title').each(function () {
                        var $td = $(this);

                        if ($td.text() === 'Resource') {
                            height -= $td.parent().parent().parent().height();
                        }
                    });

                    $('#EpmLiveAssignmentPlannerGrid').height(height + 40);
                }
            }
        };

        window.Grids.OnUpdated = function (grid) {
            $$.grid.resetNoDataRow();
        };

        window.Grids.OnColumnsChanged = function (grid, cols, count) {
            if (grid.id === $$.id) {
                var lastCol = grid.GetLastCol("1");

                for (var col in cols) {
                    if (cols[col]) {
                        grid.MoveCol(col, lastCol, true, 0);
                    }
                }
            }
        };

        window.Grids.OnGanttMenu = function (grid, row, col, menu, ganttxy) {
            return true;
        };

        window.Grids.OnDblClick = function (grid, row, col, x, y, event) {
            if (grid.id === $$.id) {
                if (col === 'G') {
                    return true;
                }
            }
        };

        window.Grids.OnClick = function (grid, row, col, x, y, evt) {
            var changeChildRowSelection = function (parentRow, selectRow) {
                var child = parentRow.firstChild;

                while (child) {
                    grid.SelectRow(child, selectRow);
                    child = child.nextSibling;
                }

                window.RefreshCommandUI();
            };

            if (grid.id === $$.id) {
                if (grid.Cols[col].Type !== 'Date') {
                    if (row.Kind === 'Data' && row.Def.Name === 'R') {
                        if (col === 'Flag') {
                            $$.grid.actions.updateFlag(grid, row);
                            return true;
                        }

                        var status;

                        if ((evt.shiftKey && evt.ctrlKey) || (!evt.shiftKey && !evt.ctrlKey)) {
                            var selectionStatus = row.Selected;

                            if (col !== 'Panel') grid.ActionClearSelection();
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
                    } else if (row.Kind === 'Data' && row.Def.Name === 'GroupAssignedToText' && col === 'Panel') {
                        var element = $(row.r0).find('.EPM_AssignmentPlanner_Selector');

                        var selection = true;

                        if (element.attr('data-selected') === 'true') {
                            element.removeClass('GSPx2xx').addClass('GSPx1xx');
                            selection = false;
                        } else {
                            element.removeClass('GSPx1xx').addClass('GSPx2xx');
                        }

                        changeChildRowSelection(row, selection);
                        element.attr('data-selected', selection);
                    }
                }

                if ($.browser.msie) {
                    window.setTimeout(function () {
                        var g = $$.grid.g;
                        g.Update();
                        g.Render();
                    }, 10);
                }
            }
        };

        window.Grids.OnDataError = function (grid, source, result, message, data) {
            try {
                var response = $$$.parseJson(data);
                var error = $$$.parseJson(response['soap:Envelope']['soap:Body'].ExecuteResponse.ExecuteResult);
                alert(error.Result.Error['#text']);
                $$.actions.close();
            } catch (e) {
                $$$.log(e);
            }
        };

        window.Grids.OnFilterFinish = function(grid, type) {
            if ($.browser.msie) {
                window.setTimeout(function () {
                    grid.Update();
                    grid.Render();
                }, 100);
            }
        };

        window.SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs("EPMLive.AssignmentPlanner.js");
    } (window.epmLiveAssignmentPlanner = window.epmLiveAssignmentPlanner || {}, window.epmLive, window.jQuery));
}

ExecuteOrDelayUntilScriptLoaded(registerAssignmentPlannerScript, 'EPMLive.js');

try {
    document.getElementsByTagName("html")[0].className = 'ms-dialog';
} catch (e) { }

try {
    document.getElementById('s4-ribbonrow').style.height = '140px';
} catch (e) { }