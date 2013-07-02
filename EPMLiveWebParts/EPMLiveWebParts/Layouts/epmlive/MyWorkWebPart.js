var iconUrl = '/_layouts/epmlive/images/mywork/';
var intRegex = /^\d+$/;
var leaveMessage = "You are currently in the edit mode. If you choose to proceed, all your changes will be lost.";

window.onbeforeunload = confirmPageLeave;

function confirmPageLeave(e) {
    if (Grids[MyWorkGrid.gridId].TotalRowsInEditMode > 0) {
        try {
            if (!e) e = window.event;
            e.returnValue = leaveMessage;

            if (e.stopPropagation) {
                e.stopPropagation();
                e.preventDefault();
            }
        } catch(e) {
        }
    }
}

function configureTitleCol(grid) {
    if (grid.Cols["Title"]["RelWidth"] === 100) {
        var width = grid.Cols['Title'].Width;

        grid.Cols["Title"]["RelWidth"] = 0;
        grid.SetWidth('Title', width - grid.Cols['Title'].Width);
    }
}

Grids.OnDblClick = function(grid, row, col, x, y, event) {
    if (grid.id === window.allWorkGridId) {
        if (!row['EditMode']) {
            editSaveRow(grid.id, row.id);
        }
    }
};

Grids.OnGetSortValue = function(grid, row, col, val) {
    if (grid.id === window.allWorkGridId) {
        if (col === 'DueDay') {
            return DateToString(row['DueDate'], 'yyyyMMdd');
        } else if (grid.GetAttribute(row, col, 'Type') === 'Date') {
            return DateToString(row[col], 'yyyyMMdd');
        } else if (val === undefined || val === '') {
            return 999999999999999;
        } else {
            return val;
        }
    }
};

Grids.OnReady = function (grid, start) {
    if (grid.id === window.allWorkGridId) {
        if (window.myWorkLoader) {
            window.myWorkLoader.close();
            window.setTimeout(function () {
                window.epmLive.utils.fireEvent(document.getElementById('MSOZoneCell_WebPart' + myWorkWebPartQualifier), 'mouseup');
                window.setTimeout(function () {
                    try {
                        window.SelectRibbonTab('Ribbon.MyWorkTab', true);
                        
                        window.setTimeout(function () {
                            try {
                                var setTabStyle = function () {
                                    var tabs = [$(document.getElementById('Ribbon.MyWorkTab-title')), $(document.getElementById('Ribbon.MyWorkViewsTab-title'))];

                                    for (var tab in tabs) {
                                        if (tabs.hasOwnProperty(tab)) {
                                            var t = tabs[tab];

                                            t.attr('style', 'border-top: 1px solid #E1E1E1 !important; height: 33px !important; margin-top: -4px !important');
                                            t.find('a').attr('style', 'padding-top: 4px !important;');

                                            if (t.attr('aria-selected') === 'false') {
                                                t.attr('style', 'height: 33px !important; margin-top: -3px !important');
                                            }

                                            t.click(function () {
                                                window.setTimeout(function () {
                                                    setTabStyle();
                                                }, 100);
                                            });
                                        }
                                    }
                                };

                                setTabStyle();
                            } catch (ex) {
                            }
                        }, 2000);
                    } catch (e) {
                    }
                }, 500);
            }, 500);
        } else {
            document.getElementById('MWG_Loader_' + myWorkWebPartId).style.display = 'none';
        }

        EPMLiveCore.WorkEngineAPI.set_path(siteUrl + '/_vti_bin/WorkEngine.asmx');

        if (MyWorkGrid.showingCompletedItems) {
            for (var rowId in grid.Rows) {
                var row = grid.Rows[rowId];

                if (row.Def.Name === 'Header' || row.Def.Name === 'Fixed' || row.Def.Name === 'Group' || row.Def.Name === 'Solid') continue;

                markRowCompleted(grid, row);
            }
        }

        MyWorkGrid.gridId = grid.id;

        MyWorkGrid.loadViews();
        MyWorkGrid.configureTag();
        MyWorkGrid.configureToolbar();

        MyWorkGrid.newItemIndicator = window.mwNewItemIndicator;
    }
};

Grids.OnRenderFinish = function(grid) {
    if (grid.id === window.allWorkGridId) {
        MyWorkGrid.resetNoDataRow();
    }
};

Grids.OnFocus = function(grid, row, col, orow, ocol, pagepos) {
    if (grid.id === window.allWorkGridId) {
        window.RefreshCommandUI();
    }
};

Grids.OnClick = function (grid, row, col, x, y, event) {
    if (grid.id === window.allWorkGridId) {
        MyWorkGrid.loadRibbon();

        MyWorkGrid.hidePivotMenu();
        $('#MWG_Search').blur();
        $('#Ribbon_MyWork_Actions_Search').blur();

        if (col === 'WorkingOn') {
            event.cancelBubble = true;
            return true;
        }

        if (grid.RowCount === 1) {
            if (grid.Cols[col].Type !== 'Date' && col !== 'Flag' && col !== 'Edit' && col !== 'CommentCount' && col !== 'Priority' && col !== 'Complete') {
                if (row.Kind === 'Data' && row.Def.Name === 'R') {
                    grid.SelectRow(row, !row.Selected);
                    window.RefreshCommandUI();
                }
            }
        }

        var rowBeingEdited = MyWorkGrid.rowBeingEdited;
        if (rowBeingEdited) {
            if (row.id !== rowBeingEdited.id) {
                grid.EndEdit(true);

                if (grid.HasChanges()) {
                    saveRow(grid.id, rowBeingEdited.id);
                } else {
                    cancelRowEdit(grid.id, rowBeingEdited.id);
                }

                MyWorkGrid.rowBeingEdited = null;
                grid.TotalRowsInEditMode = 0;
            }
        }

        if (!row['EditMode']) {
            var cell = row.id + col;

            if (MyWorkGrid.lastClickedCell === cell) {
                editSaveRow(grid.id, row.id);

                if (grid.Cols[col].Type === 'Lines') {
                    showRichTextBox(grid.id, row.id, col);
                }
            }

            MyWorkGrid.lastClickedCell = cell;
        }

        if (row.Def.Name === 'Group' && col === 'Title') {
            if (row.Expanded === 1) {
                grid.FRow = null;
                grid.Collapse(row);
            } else {
                grid.Expand(row);
            }

            window.setTimeout(function () {
                var g = Grids[MyWorkGrid.gridId];
                g.Update();
                g.Render();
            }, 100);

            return true;
        }
    }
};

Grids.OnGetHtmlValue = function (grid, row, col, val) {
    if (grid.id === window.allWorkGridId) {
        if (col === 'CommentCount' || col === 'Priority' || col === 'Flag' || col === 'Title' || col === 'WorkingOn') {
            if (row.Def.Name !== 'Header' && row.Def.Name !== 'Fixed' && row.Def.Name !== 'Group') {
                var value = val;

                switch (col) {
                    case 'CommentCount':
                        if (val == '') value = '<div class="MWG_CommentDisabled">&nbsp;</div>';
                        else {
                            var cssClass = '';
                            var commentRead = MyWorkGrid.isCommentRead(row);

                            if (!intRegex.test(val)) {
                                if (val.indexOf('Completed') != -1) {
                                    if (!commentRead) {
                                        cssClass = 'MWG_Comment_Completed';
                                    } else {
                                        cssClass = 'MWG_CommentRead_Completed';
                                    }
                                    val = val.split('Completed')[1];
                                }
                            } else {
                                if (!commentRead) {
                                    cssClass = 'MWG_Comment';
                                } else {
                                    cssClass = 'MWG_CommentRead';
                                }
                            }

                            value = '<div id="MWG_CommentCount_' + row.id + '" class="' + cssClass + '" onclick="showComments(\'' + grid.id + '\',\'' + row.id + '\');" style="cursor:pointer;"><span class="MWG_CommentCounter">' + val + '</span></div>';
                        }

                        break;
                    case 'Priority':
                        var img = '';

                        if (!intRegex.test(val)) {
                            if (val == 'HighCompleted') img = 'high-priority';
                            else if (val == 'LowCompleted') img = 'low-priority';
                            else if (val.indexOf('Normal') != -1) img = 'medium-priority';
                            else if (val.indexOf('High') != -1) img = 'high-priority';
                            else if (val.indexOf('Low') != -1) img = 'low-priority';
                        }

                        if (img != '') value = '<img src="' + iconUrl + img + '.png"/>';

                        break;
                    case 'Flag':
                        value = '<img src="' + iconUrl + getFlagImage(val) + '.png"/>';

                        break;
                    case 'Title':
                        if (grid.Cols['CommentCount'].Visible == 0) {
                            if (row['CommentCount'] != '' && intRegex.test(row['CommentCount'])) {
                                if (row['CommentCount'] != '0')
                                    value += '<div class="MWG_Comment_Small" onclick="showComments(\''
                                    + grid.id + '\',\'' + row.id + '\');" style="cursor:pointer;">&nbsp;</div>';
                            }
                        }

                        var postfix = '';

                        if (MyWorkGrid.newItemIndicator.enabled) {
                            var date = new Date();
                            var today = new Date(date.getFullYear(), date.getMonth(), date.getDate());

                            var d = new Date(today.getFullYear(), today.getMonth(), today.getDate() - (MyWorkGrid.newItemIndicator.days - 1)).getTime();

                            if (row.Created >= d) {
                                postfix = '<img class="MWG_NewItemIndicator" src="/_layouts/1033/images/new.gif"></img>';
                            }
                        }

                        row.TitleHtmlPostfix = postfix;

                        break;
                    case 'WorkingOn':
                        if (val === 0) {
                            value = '<div id="epmtgs_' + row.id + '" class="epmlive-toggle-switch epmlive-toggle-switch-off" data-state="0" onclick="MyWorkGrid.updateWorkingOn(\'' + row.id + '\');try { window.event.cancelBubble = true; } catch(e) { }" style="margin-left:20px;"><span>NO</span><div class="epmlive-toggle-switch-slider" style="left: -16px;"></div></div>';
                        } else {
                            value = '<div id="epmtgs_' + row.id + '" class="epmlive-toggle-switch epmlive-toggle-switch-on" data-state="1" onclick="MyWorkGrid.updateWorkingOn(\'' + row.id + '\');try { window.event.cancelBubble = true; } catch(e) { }" style="margin-left:20px;"><span>YES</span><div class="epmlive-toggle-switch-slider" style="left: 32px;"></div></div>';
                        }

                        break;
                }

                return value;
            }
        } else if (row.Def.Name === 'Group' && col !== 'Complete') {
            return '';
        } else if (grid.Cols[col] && grid.Cols[col].Type === 'Lines') {
            return val;
        }

        return null;
    }
};

Grids.OnLoaded = function (grid) {
    if (grid.id === window.allWorkGridId) {
        var maxHeight = window.mwWebPartHeight;

        if (maxHeight === 0) {
            var offset = $.browser.msie ? 20 : 5;
            maxHeight = $('#s4-workspace').height() - ($('#s4-titlerow').height() + $('#EPMLiveStatusbarTemplate').height() + $('#EPMLiveStatuTemplate').height() + $('#s4-statusbarcontainer').height() + offset);

            if ($('#MWG_Header').is(':visible')) {
                maxHeight -= (100 + ($.browser.msie ? 5 : 0));
            }
        }

        grid.MaxVScroll = maxHeight;

        var win = $(window);

        MyWorkGrid.winHeight = win.height();

        win.resize(function () {
            var height = $(this).height();
            var winHeight = MyWorkGrid.winHeight;

            var newHeight;

            if (height < winHeight) {
                newHeight = -(winHeight - height);
            } else {
                newHeight = height - winHeight;
            }

            if (newHeight !== 0) {
                grid.MaxVScroll += newHeight;
                MyWorkGrid.winHeight = height;

                grid.Update();
                grid.Render();
            }
        });

        grid.Update();
        grid.Render();

        $('html').click(function () {
            var g = window.Grids[MyWorkGrid.gridId];
            
            var row = MyWorkGrid.rowBeingEdited;
            if (row) {
                g.EndEdit(true);

                if (g.HasChanges()) {
                    saveRow(g.id, row.id);
                } else {
                    cancelRowEdit(g.id, row.id);
                }

                MyWorkGrid.rowBeingEdited = null;
                g.TotalRowsInEditMode = 0;
            }
        });

        MyWorkGrid.resetNoDataRow();
    }
};

Grids.OnColumnsChanged = function(grid, cols, count) {
    if (grid.id === window.allWorkGridId) {
        var lastCol = grid.GetLastCol("1");

        for (var col in cols) {
            if (cols[col]) {
                grid.MoveCol(col, lastCol, true, 0);
            }
        }
    }
};

window.Grids.OnGetColor = function(grid, row, col, r, g, b, edit) {
    if (grid.id === window.allWorkGridId) {
        if (col === 'CommentCount') {
            if ((r === 230 || r === 180 || r === 205 || r === 255) && (g === 242 || g === 217 || g === 230 || g === 255) && (b === 251 || b === 243 || b === 247 || b === 255)) {
                if (row.r0) {
                    var cell = $(row.r0).find('.MWG_CommentDisabled');

                    if (cell) {
                        if ((r === 230 && g === 242 && b === 251) || (r === 180 && g === 217 && b === 243)) {
                            $(cell).html('<div class="MWG_CommentHovered" onclick="showComments(\'' + grid.id + '\',\'' + row.id + '\');"></div>');
                        } else {
                            $(cell).html('');
                        }
                    }
                }
            }
        }

        return null;
    }
};

window.Grids.OnGroup = function (grid, group) {
    if (grid.id === window.allWorkGridId) {
        window.setTimeout(function () {
            var g = Grids[MyWorkGrid.gridId];
            g.Update();
            g.Render();
        }, 500);
    }
};

function ajaxRequest() {
    var activexmodes = ["Msxml2.XMLHTTP", "Microsoft.XMLHTTP"]; //activeX versions to check for in IE
    if (window.ActiveXObject) { //Test for support for ActiveXObject in IE first (as XMLHttpRequest in IE7 is broken)
        for (var i = 0; i < activexmodes.length; i++) {
            try {
                return new ActiveXObject(activexmodes[i]);
            } catch(e) {
                //suppress error
            }
        }
    } else if (window.XMLHttpRequest) // if Mozilla, Safari etc
        return new XMLHttpRequest();

    return false;
}

function calculateDueColor(col, row) {
    if (col === 'Complete' && (row.Def === undefined || row.Def.Name === 'Header' || row.Def.Name === 'Fixed' || row.Def.Name === 'Group' || row.Def.Name === 'Solid')) {
        return 'MWG_NoBgImg';
    }

    var dueDate = row['DueDate'];
    var dueDay = row['DueDay'];

    var cssClass = '';

    if (dueDay == 'Yesterday') cssClass = 'MWG_OverDue';
    else if (dueDate != '') {
        var today = new Date();
        var date = DateToString(dueDate, 'M/d/yyyy').split('/');

        var currentMonth = today.getMonth() + 1;
        var currentYear = today.getFullYear();

        if (date[2] < currentYear) {
            cssClass = 'MWG_OverDue';
        } else if (date[2] == currentYear) {
            if (date[0] < currentMonth) {
                cssClass = 'MWG_OverDue';
            } else if (date[0] == currentMonth && date[1] < today.getDate()) {
                cssClass = 'MWG_OverDue';
            }
        }
    }

    if (MyWorkGrid.loadingCompletedItems !== undefined || MyWorkGrid.loadingCompletedItems !== null) {
        if (MyWorkGrid.loadingCompletedItems) {
            if (cssClass === '') return 'MWG_CompletedRow';
            return 'MWG_OverDue_Completed';
        }
    }

    if (cssClass !== '' && col === 'Complete') cssClass = 'MWG_OverDue_Completed';
    if (cssClass === '' && col === 'Complete') cssClass = 'MWG_UnCompletedRow_Normal';

    return cssClass;
}

function cancelRowEdit(gridId, rowId) {
    var grid = Grids[gridId];
    var row = grid.Rows[rowId];

    var listWebSiteId = row['ListID'] + row['WebID'] + row['SiteID'];

    if (row['Complete'] == 1) return;

    row['EditMode'] = 0;
    grid.TotalRowsInEditMode--;

    grid.SetAttribute(row, 'Priority', 'CanEdit', 0, true, false);
    setCellValue(row.currentValues['Priority'], gridId, rowId, 'Priority');
    
    grid.SetAttribute(row, 'Title', 'CanEdit', 0, true, false);
    setCellValue(row.currentValues['Title'], gridId, rowId, 'Title');

    setCellValue(row.currentValues['DueDay'], gridId, rowId, 'DueDay');

    var cols = grid.ColNames[1];

    for (var col in cols) {
        var c = cols[col];

        if (grid.ColTypes[listWebSiteId][c] == 'Lines') {
            grid.SetAttribute(row, c, 'Button', '', true, false);
            grid.SetAttribute(row, c, 'OnClickSideButton', 'return;', true, false);
        }

        grid.SetAttribute(row, c, 'CanEdit', 0, true, false);

        setCellValue(row.currentValues[c], gridId, rowId, c);
    }

    MyWorkGrid.hideProcessing(rowId);

    row.isBeingEdited = false;
    MyWorkGrid.rowBeingEdited = null;
}

function markRowCompleted(grid, row) {
    row.CurrentCommentCount = row['CommentCount'];
    if (row['CommentCount'] > 0) setCellValue('Completed' + row['CommentCount'], grid.id, row.id, 'CommentCount');

    row.CurrentPriority = row['Priority'];

    var priority = row['Priority'];
    if (!intRegex.test(priority)) {
        if (priority.indexOf('High') != -1) setCellValue('HighCompleted', grid.id, row.id, 'Priority');
        else if (priority.indexOf('Low') != -1) setCellValue('LowCompleted', grid.id, row.id, 'Priority');
    }

    row.CurrentFlag = row['Flag'];
    if (row['Flag'] == 0) setCellValue('UnflaggedCompleted', grid.id, row.id, 'Flag');
    else setCellValue('FlaggedCompleted', grid.id, row.id, 'Flag');

    updateRowColor(grid, row, '#F9F9F9', 'MWG_CompletedRow', true);

    if (!MyWorkGrid.showingCompletedItems) {
        grid.RemoveRow(row);
    }
}

function markRowUnCompleted(grid, row) {
    MyWorkGrid.hideProcessing(row.id);

    setCellValue(row.CurrentCommentCount, grid.id, row.id, 'CommentCount');
    setCellValue(row.CurrentPriority, grid.id, row.id, 'Priority');
    setCellValue(row.CurrentFlag, grid.id, row.id, 'Flag');

    updateRowColor(grid, row, '#FFFFFF', '', false);

    if (MyWorkGrid.showingCompletedItems) {
        grid.RemoveRow(row);
    }
}

function updateRowColor(grid, row, color, cssCls, completed) {
    for (var c in grid.Cols) {
        if (c !== 'WorkingOn') {
            var cssClass = cssCls;

            if (c !== 'Complete' && c !== 'CommentCount' && color !== '#FFFFFF') {
                cssClass = 'MWG_CompletedLineThrough';
            }

            row[c + 'Class'] = cssClass;

            var dueColor;

            if (!completed) {
                if (c === 'DueDate' || c === 'DueDay') {
                    row[c + 'Class'] = calculateDueColor(c, row);
                } else if (c === 'Complete') {
                    dueColor = calculateDueColor(c, row);
                    if (dueColor !== 'MWG_OverDue_Completed') {
                        cssClass = 'MWG_UnCompletedRow_Normal';
                    }

                    row[c + 'Class'] = cssClass;
                }
            } else {
                if (c === 'Complete') {
                    dueColor = calculateDueColor(c, row);
                    if (dueColor === 'MWG_OverDue_Completed') {
                        cssClass = 'MWG_CompletedRow_OverDue';
                    } else {
                        cssClass = 'MWG_CompletedRow_Normal';
                    }

                    row[c + 'Class'] = cssClass;
                }
            }

            grid.RefreshCell(row, c);
        }
    }
}

function changeCompleteStatus(grid, row, col) {
    if (row.Def.Name === 'Header' || row.Def.Name === 'Fixed' || row.Def.Name === 'Group' || row.Def.Name === 'Solid') {
        return;
    }

    if (row.isBeingEdited) {
        SP.UI.Notify.addNotification("Cannot mark item as complete when in edit mode.", false);
        return;
    }

    MyWorkGrid.showProcessing(row.id);

    if (MyWorkGrid.showingCompletedItems) {
        MyWorkGrid.loadingCompletedItems = false;
    }

    var completed = grid.GetValue(row, col) == 0;

    if (completed) {
        updateRowColor(grid, row, '#F9F9F9', 'MWG_CompletedRow', true);
    } else {
        updateRowColor(grid, row, '#FFFFFF', '', false);
    }

    MyWorkGrid.showProcessing(row.id);

    var dataXml = '<MyWorkItem><Item ID="' + row['ItemID'] + '" /><List ID="' + row['ListID'] + '" /><Web ID="' + row['WebID'] + '" /><Site ID="' + row['SiteID']
        + '" URL="' + row['SiteURL'] + '" /><Fields><Field Name="Complete"><![CDATA[' + completed + ']]></Field></Fields></MyWorkItem>';

    EPMLiveCore.WorkEngineAPI.Execute("UpdateMyWorkItem", dataXml, function (response) {
        response = parseJson(response);

        if (responseIsSuccess(response)) {
            if (row['EditMode'] == 1) cancelRowEdit(grid.id, row.id);

            setCellValue(completed, grid.id, row.id, col);

            var cols = grid.ColNames[1];

            for (var c in cols) {
                var newVal = getFieldValue(cols[c], response);

                if (grid.GetAttribute(row, cols[c], 'Type') === 'Date') newVal = DateToString(newVal, grid.Cols[col].Format);
                if (newVal != undefined) {
                    setCellValue(newVal, grid.id, row.id, cols[c]);
                }
            }

            window.setTimeout(function () {
                MyWorkGrid.hideProcessing(row.id);

                if (completed && !MyWorkGrid.showingCompletedItems) {
                    if (!$.browser.msie) {
                        $(row.r0).fadeOut(800);
                        $(row.r1).fadeOut(800);
                    } else {
                        $(row.r0).find("td").fadeOut(800, function() { $(this).parent().remove(); });
                        $(row.r1).find("td").fadeOut(800, function() { $(this).parent().remove(); });
                    }
                } else if (!completed && MyWorkGrid.showingCompletedItems) {
                    if (!$.browser.msie) {
                        $(row.r0).fadeOut(800);
                        $(row.r1).fadeOut(800);
                    } else {
                        $(row.r0).find("td").fadeOut(800, function () { $(this).parent().remove(); });
                        $(row.r1).find("td").fadeOut(800, function () { $(this).parent().remove(); });
                    }
                }

                window.setTimeout(function () {
                    if (completed) {
                        markRowCompleted(grid, row);
                    } else {
                        markRowUnCompleted(grid, row);
                    }
                }, 850);
            }, 250);

            MyWorkGrid.isDirty = true;
        }
    });
}

function doActionOnItem(gridId, action) {
    var grid = Grids[gridId];
    var row = grid.FRow;

    if (row.tagName !== 'I') {
        var selRows = grid.GetSelRows();
        if (selRows.length > 0) {
            row = selRows[0];
        }
    }

    if (action == 'edit') {
        if (!MyWorkGrid.leaveConfirmation(grid)) {
            return;
        }

        var itemId = row['ItemID'];
        var listId = row['ListID'];
        var webId = row['WebID'];
        var siteUrl = row['SiteURL'];

        showSharePointPopup(siteUrl + '/_layouts/epmlive/gridaction.aspx?action=' + action + '&webid=' + webId + '&listid='
            + listId + '&ID=' + itemId, null, true, true, MyWorkGrid.reloadItemData, { grid: grid, itemId: itemId, listId: listId, webId: webId, siteUrl: siteUrl, siteId: row['SiteID'], row: row });

        return;
    } else if (action == 'comments') {
        var itemId = row['ItemID'];
        var listId = row['ListID'];
        var webId = row['WebID'];
        var siteUrl = row['SiteURL'];

        showSharePointPopup(siteUrl + '/_layouts/epmlive/myworkgridaction.aspx?action=' + action + '&webid=' + webId + '&listid='
            + listId + '&ID=' + itemId, null, true, true, MyWorkGrid.reloadCommentCount, { grid: grid, itemId: itemId, listId: listId, webId: webId, siteUrl: siteUrl, siteId: row['SiteID'], row: row }, 600, 500);

        return;
    } else if (action == 'delete') {
        if (confirm("Are you sure you want to delete this item?")) {
            var request = new ajaxRequest();

            request.onreadystatechange = function() {
                if (request.readyState == 4) {
                    if (request.status == 200) {
                        if (request.responseText.trim() == 'Success') {
                            grid.RemoveRow(row);
                            SP.UI.Notify.addNotification("Item was deleted successfully.", false);
                            MyWorkGrid.isDirty = true;
                        }
                    }
                }
            };

            request.open('GET', row['SiteURL'] + '/_layouts/epmlive/gridaction.aspx?action=delete&webid=' + row['WebID'] + '&listid=' + row['ListID'] + '&ID=' + row['ItemID'], true);
            request.send(null);
        }

        return;
    } else if (action == 'perms') {
        showSharePointPopup(row['SiteURL'] + '/_layouts/epmlive/gridaction.aspx?action=' + action + '&webid=' + row['WebID'] + '&listid=' + row['ListID'] + '&ID='
            + row['ItemID'] + '&gridid=' + gridId + '&rowid=' + row.id, null, true, true, null);

        return;
    }

    showSharePointPopup(row['SiteURL'] + '/_layouts/epmlive/gridaction.aspx?action=' + action + '&webid=' + row['WebID'] + '&listid=' + row['ListID'] + '&ID='
        + row['ItemID'], null, true, true, null);

    return;
}

function editRow(grid, row) {
    var listWebSiteId = row['ListID'] + row['WebID'] + row['SiteID'];

    if (grid.RowPermissions === undefined) {
        grid.RowPermissions = new Object();
    }

    if (grid.RowPermissions[listWebSiteId] === undefined) {
        var dataXml = '<MyWork><List ID="' + row['ListID'] + '" /><Web ID="' + row['WebID'] + '" /><Site ID="' + row['SiteID'] + '" URL="' + row['SiteURL'] + '" /></MyWork>';

        EPMLiveCore.WorkEngineAPI.Execute("CheckMyWorkListEditPermission", dataXml, function(response) {
            response = parseJson(response);

            if (responseIsSuccess(response)) {
                if (response.Result.MyWork.HasEditPermission === 'true') {
                    grid.RowPermissions[listWebSiteId] = true;
                } else {
                    grid.RowPermissions[listWebSiteId] = false;
                }

                editRowHelper(grid, row);
            }
        });
    } else {
        editRowHelper(grid, row);
    }
}

function editRowHelper(grid, row) {
    var cols = grid.ColNames[1];
    var listWebSiteId = row['ListID'] + row['WebID'] + row['SiteID'];

    if (grid.RowPermissions[listWebSiteId]) {
        if (row['EditMode'] === undefined) {
            row['EditMode'] = 1;
        }

        if (grid.TotalRowsInEditMode === undefined) {
            grid.TotalRowsInEditMode = 0;
        }

        grid.TotalRowsInEditMode++;
        row.isBeingEdited = true;

        if (grid.ColTypes == undefined) grid.ColTypes = new Object();

        if (grid.ColTypes[listWebSiteId] == undefined) {

            grid.ColTypes[listWebSiteId] = new Object();

            var dataXml = '<FieldInfo><Item ID="' + row['ItemID'] + '" /><List ID="' + row['ListID'] + '" /><Web ID="' + row['WebID'] + '" /><Site ID="' + row['SiteID'] + '" URL="'
                + row['SiteURL'] + '" /><Fields>Priority,Title,';

            for (var col in cols) {
                dataXml += cols[col] + ',';
            }

            dataXml = dataXml.substring(0, dataXml.length - 1);

            dataXml += '</Fields><GuessOriginalFieldName>True</GuessOriginalFieldName></FieldInfo>';

            EPMLiveCore.WorkEngineAPI.Execute("IsFieldEditable", dataXml, function(response) {
                response = parseJson(response);

                if (responseIsSuccess(response)) {
                    var fields = response.Result.FieldInfo.Fields.Field;

                    dataXml = '<MyWork><Item ID="' + row['ItemID'] + '" /><List ID="' + row['ListID'] + '" /><Web ID="' + row['WebID'] + '" /><Site ID="' + row['SiteID']
                        + '" URL="' + row['SiteURL'] + '" /><Fields>';

                    for (var f in fields) {
                        var fieldName = fields[f]["@Name"];

                        if (fields[f]["@Editable"] == "true") {
                            dataXml += fieldName + ',';
                        }
                    }

                    dataXml = dataXml.substring(0, dataXml.length - 1);

                    dataXml += '</Fields><GuessOriginalFieldName>True</GuessOriginalFieldName></MyWork>';

                    EPMLiveCore.WorkEngineAPI.Execute("GetMyWorkGridColType", dataXml, function(response) {
                        response = parseJson(response);

                        if (responseIsSuccess(response)) {
                            fields = response.Result.MyWork.Fields.Field;

                            for (var i = 0; i < fields.length; i++) {
                                var colName = fields[i]["@Name"];
                                var colType = fields[i]["@Type"];

                                grid.ColTypes[listWebSiteId][colName] = colType;

                                grid.SetAttribute(row, colName, 'Type', colType, true, false);
                                
                                if (colType !== 'Lines') {
                                    grid.SetAttribute(row, colName, 'CanEdit', 1, true, false);
                                }
                            }

                            editRowFinalizer(grid, row, cols, listWebSiteId);
                        }
                    });
                }
            });
        } else {
            for (var col in grid.ColTypes[listWebSiteId]) {
                var colType = grid.ColTypes[listWebSiteId][col];

                grid.SetAttribute(row, col, 'Type', colType, true, false);
                
                if (colType !== 'Lines') {
                    grid.SetAttribute(row, col, 'CanEdit', 1, true, false);
                }
            }
            editRowFinalizer(grid, row, cols, listWebSiteId);
        }
    } else {
        MyWorkGrid.hideProcessing(row.id);
        SP.UI.Notify.addNotification("You do not have permission to edit this item.", false);
    }
}

function editRowFinalizer(grid, row, cols, listWebSiteId) {
    var currentValues = new Object();

    currentValues['Priority'] = row['Priority'];
    currentValues['DueDay'] = row['DueDay'];
    currentValues['Title'] = row['Title'];

    for (var col in cols) {
        var c = cols[col];

        var value = row[c];

        if (value != undefined) currentValues[c] = value;
        else currentValues[c] = '';
    }

    row.currentValues = currentValues;

    var enumFields = '';
    for (var col in grid.ColTypes[listWebSiteId]) {
        var colType = grid.ColTypes[listWebSiteId][col];

        if (colType == 'Enum') enumFields += col + ',';
    }

    if (enumFields != '') {
        dataXml = '<MyWork><Item ID="' + row['ItemID'] + '" /><List ID="' + row['ListID'] + '" /><Web ID="' + row['WebID'] + '" /><Site ID="' + row['SiteID']
            + '" URL="' + row['SiteURL'] + '" /><Fields>' + enumFields;
        dataXml = dataXml.substring(0, dataXml.length - 1);
        dataXml += '</Fields><GuessOriginalFieldName>True</GuessOriginalFieldName></MyWork>';

        EPMLiveCore.WorkEngineAPI.Execute("GetMyWorkGridEnum", dataXml, function(response) {
            response = parseJson(response);

            if (responseIsSuccess(response)) {
                var fields = response.Result.MyWork.Fields.Field;

                for (var f in fields) {
                    var fieldName = fields[f]["@Name"];

                    grid.SetAttribute(row, fieldName, 'Enum', fields[f]["@Enum"], true, false);
                    grid.SetAttribute(row, fieldName, 'EnumKeys', fields[f]["@EnumKeys"], true, false);
                    grid.SetAttribute(row, fieldName, 'Range', fields[f]["@Range"], true, false);
                }

                MyWorkGrid.hideProcessing(row.id);
                MyWorkGrid.rowBeingEdited = row;
                MyWorkGrid.isDirty = true;
            }
        });
    } else {
        MyWorkGrid.hideProcessing(row.id);
        MyWorkGrid.rowBeingEdited = row;
    }
}

function editSaveRow(gridId, rowId) {
    var grid = Grids[gridId];
    var row = grid.Rows[rowId];

    if (row.Def.Name === 'Header' || row.Def.Name === 'Fixed' || row.Def.Name === 'Group') return;

    if (row['Complete'] == 1) return;

    MyWorkGrid.showProcessing(rowId);
    editRow(grid, row);
}

function updateEditColWidth(grid, row) {
    if (!$.browser.msie || parseInt($.browser.version) > 8) {
        if (grid.TotalRowsInEditMode === 0) {
            grid.SetWidth('Edit', -25);
        } else if (row.isBeingEdited && grid.TotalRowsInEditMode === 1) {
            grid.SetWidth('Edit', 25);
        }
    }
}

function emptyFunction() {
}

function getFieldValue(field, response) {
    var fields = response.Result.MyWorkItem.Fields.Field;

    for (var i = 0; i < fields.length; i++) {
        var theField = fields[i];
        if (theField['@Name'] == field) return theField['#cdata'];
    }

    return undefined;
}

function getFlagImage(val) {
    if (val == '0') return 'unflagged';
    else if (val == 'UnflaggedCompleted') return 'unflagged';
    else if (val == 'FlaggedCompleted') return 'flagged';
    else return 'flagged';
}

function newItemAdded(result, value, params) {
    params.grid.Reload();
}

function onshowRichTextBoxClosed(result, value, params) {
    if (result == 1) {
        setCellValue(unescape(value), params.gridId, params.rowId, params.col);
    }
}

function parseJson(response) {
    return eval('(' + xml2json(parseXml(response), "") + ')');
}

function parseXml(xml) {
    var dom = null;
    if (window.DOMParser) {
        try {
            dom = (new DOMParser()).parseFromString(xml, "text/xml");
        } catch(e) {
            dom = null;
        }
    } else if (window.ActiveXObject) {
        try {
            dom = new ActiveXObject('Microsoft.XMLDOM');
            dom.async = false;
            dom.loadXML(xml);
        } catch(e) {
            dom = null;
        }
    }

    return dom;
}

function responseIsSuccess(response) {
    return response.Result["@Status"] == 0;
}

function saveRow(gridId, rowId) {
    var grid = Grids[gridId];
    var row = grid.Rows[rowId];

    var listWebSiteId = row['ListID'] + row['WebID'] + row['SiteID'];

    grid.EndEdit(true);

    row['EditMode'] = 0;
    grid.TotalRowsInEditMode--;

    MyWorkGrid.showProcessing(rowId);

    if (row['Complete'] == 1) return;

    var priority = row['Priority'];
    var title = row['Title'];

    var dataXml = '<MyWorkItem><Item ID="' + row['ItemID'] + '" /><List ID="' + row['ListID'] + '" /><Web ID="' + row['WebID'] + '" /><Site ID="' + row['SiteID']
        + '" URL="' + row['SiteURL'] + '" /><Fields><Field Name="Priority"><![CDATA[' + priority + ']]></Field><Field Name="Title"><![CDATA[' + title + ']]></Field>';

    var cols = grid.ColNames[1];

    var edited = false;

    for (var col in cols) {
        var col = cols[col];
        var value = row[col];

        if (value != undefined) {
            if (value != row.currentValues[col]) {
                dataXml += '<Field Name="' + col + '"><![CDATA[' + value + ']]></Field>';
                edited = true;
            }
        }
    }

    dataXml += '</Fields></MyWorkItem>';

    if (!edited) {
        if (row.currentValues['Priority'] !== priority) {
            edited = true;
        }
        
        if (row.currentValues['Title'] !== title) {
            edited = true;
        }

        if (!edited) {
            cancelRowEdit(gridId, rowId);
            return;
        }
    }

    EPMLiveCore.WorkEngineAPI.Execute("UpdateMyWorkItem", dataXml, function(response) {
        response = parseJson(response);

        if (responseIsSuccess(response)) {
            grid.SetAttribute(row, 'Priority', 'CanEdit', 0, true, false);

            newVal = getFieldValue('Priority', response);
            if (newVal != undefined) setCellValue(newVal, grid.id, row.id, 'Priority');
            
            grid.SetAttribute(row, 'Title', 'CanEdit', 0, true, false);

            newVal = getFieldValue('Title', response);
            if (newVal != undefined) setCellValue(newVal, grid.id, row.id, 'Title');

            var cols = grid.ColNames[1];

            for (var col in cols) {
                var c = cols[col];

                newVal = getFieldValue(c, response);

                if (grid.ColTypes[listWebSiteId][c] == 'Lines') {
                    grid.SetAttribute(row, c, 'Button', '', true, false);
                    grid.SetAttribute(row, c, 'OnClickSideButton', 'return;', true, false);
                }

                if (newVal != undefined) setCellValue(newVal, grid.id, row.id, c);

                grid.SetAttribute(row, c, 'CanEdit', 0, true, false);
            }

            MyWorkGrid.hideProcessing(rowId);

            row.isBeingEdited = false;
            MyWorkGrid.rowBeingEdited = null;

            newVal = getFieldValue('DueDay', response);
            if (newVal != undefined) setCellValue(newVal, grid.id, row.id, 'DueDay');

            SP.UI.Notify.addNotification("Item was updated successfully.", false);

            MyWorkGrid.isDirty = true;
        }
    });
}

function setCellValue(value, gridId, rowId, col) {
    var grid = Grids[gridId];
    var row = grid.Rows[rowId];

    grid.SetValue(row, col, value, 1);
}

function showRichTextBox(gridId, rowId, col) {
    var grid = Grids[gridId];
    var row = grid.Rows[rowId];

    showSharePointPopup(siteUrl + '/_layouts/epmlive/myworkrichtexteditor.aspx?RichTextValue=' + escape(row[col]), col + ' Editor', false, false, onshowRichTextBoxClosed, {
        gridId: gridId,
        rowId: rowId,
        col: col
    }, 600, 400);

    return;
}

function showSharePointPopup(url, title, allowMaximize, showClose, func, funcParams, width, height) {
    if (allowMaximize == null) allowMaximize = true;
    if (showClose == null) showClose = true;
    if (func == null) func = emptyFunction;

    var options;

    if (width !== undefined && height !== undefined) {
        options = {
            title: title,
            allowMaximize: allowMaximize,
            showClose: showClose,
            url: url,
            dialogReturnValueCallback: Function.createCallback(Function.createDelegate(null, func), funcParams),
            width: width,
            height: height
        };
    } else {
        options = { title: title, allowMaximize: allowMaximize, showClose: showClose, url: url, dialogReturnValueCallback: Function.createCallback(Function.createDelegate(null, func), funcParams) };
    }

    SP.UI.ModalDialog.showModalDialog(options);
}

function updateFlag(grid, row, col) {
    if (row.Def.Name === 'Header') {
        var sort = grid.Sort;
        var sortType = 1;

        if (sort.indexOf("Flag") !== -1) {
            sortType = 1;

            if (sort.indexOf("-Flag") !== -1) {
                sortType = 0;
            }
        }

        grid.SortClick('Flag', sortType);
        return;
    }

    if (row.Def.Name === 'Fixed' || row.Def.Name === 'Group' || row.Def.Name === 'Solid') {
        return;
    }

    if (row['Complete'] == 1) return;

    grid.CloseDialog();

    var flag = '';

    switch (grid.GetValue(row, col)) {
    case 1:
        flag = 0;
        break;
    case 0:
    default:
        flag = 1;
        break;
    }

    var dataXml = '<MyPersonalization><Item ID="' + row['ItemID'] + '" /><List ID="' + row['ListID'] + '" /><Web ID="' + row['WebID'] + '" /><Site ID="' + row['SiteID']
        + '" URL="' + row['SiteURL'] + '" /><Personalizations><Personalization Key="Flag" Value="' + flag + '" /></Personalizations></MyPersonalization>';

    EPMLiveCore.WorkEngineAPI.Execute("SetMyPersonalization", dataXml, function(response) {
        response = parseJson(response);

        if (responseIsSuccess(response)) setCellValue(flag, grid.id, row.id, col);
    });
}

function showComments(gridId, rowId) {
    var grid = Grids[gridId];
    var row = grid.Rows[rowId];

    grid.Focus(row, 'CommentCount', null, false);

    doActionOnItem(gridId, 'comments');
}

var MyWorkGrid = {
    gridId: null,
    defaultView: null,
    defaultViewId: null,
    isDefaultViewPersonal: false,
    views: new Object(),
    viewsLoaded: false,
    filtersOn: false,
    groupingOn: false,
    showingCompletedItems: false,
    loadingCompletedItems: false,
    rowBeingEdited: null,
    lastClickedCell: null,
    tagId: null,
    showMeFilters: null,
    isDirty: true,
    showMeFilterApplied: false,
    lastFilter: null,
    headerToolbarConfigured: false,
    searchWatermark: 'Find an item',
    workFiltersConfigured: false,
    workFilters: { daysAgoEnabled: null, daysAgo: null, daysAfterEnabled: null, daysAfter: null },
    newItemIndicator: { enabled: true, days: 2 },

    showSelectColoumnsDialog: function showSelectColoumnsDialog() {
        Grids[MyWorkGrid.gridId].ActionShowColumns('Selectable');
    },

    loadViews: function () {
        EPMLiveCore.WorkEngineAPI.Execute("GetMyWorkGridViews", '', function (response) {
            response = parseJson(response);

            if (responseIsSuccess(response)) {

                if (response.Result.MyWork.Views !== null) {
                    var views = response.Result.MyWork.Views.View;

                    if (views.length > 0 || views["@ID"] !== undefined) {

                        if (views["@ID"] !== undefined) {
                            var v = views;
                            views = new Array();
                            Array.add(views, v);
                        }

                        for (var v in views) {
                            var view = views[v];

                            MyWorkGrid.views[view["@ID"]] = new Object();

                            var viewName = view["@Name"];
                            var viewId = view["@ID"];
                            var isPersonal = false;
                            var isDefault = false;

                            if (view["@Type"] === 'Personal') {
                                isPersonal = true;
                            }
                            if (view["@Default"] === "true") {
                                isDefault = true;
                            }

                            MyWorkGrid.views[viewId] = {
                                id: viewId,
                                name: viewName,
                                isDefault: isDefault,
                                isPersonal: isPersonal,
                                leftCols: view["@LeftCols"],
                                cols: view["@Cols"],
                                rightCols: view["@RightCols"],
                                filters: view["@Filters"],
                                grouping: view["@Grouping"],
                                sorting: view["@Sorting"]
                            };
                        }

                        if (requestedView !== '') {
                            requestedView = Base64.decode(requestedView).toLowerCase();

                            if (requestedViewType === '') {
                                requestedViewType = 'global';
                            } else {
                                requestedViewType = Base64.decode(requestedViewType).toLowerCase();
                                if (requestedViewType !== 'personal') {
                                    requestedViewType = 'global';
                                }
                            }

                            for (var vw in MyWorkGrid.views) {
                                var theView = MyWorkGrid.views[vw];

                                if (theView.name.toLowerCase() === requestedView) {
                                    if (theView.isPersonal === (requestedViewType === 'personal')) {
                                        masterView = theView.id;
                                    }
                                }
                            }
                        }

                        if (masterView === '') {
                            var defaultPersonalView = '';
                            var defaultGlobalView = 'dv';

                            for (var v in MyWorkGrid.views) {
                                var view = MyWorkGrid.views[v];

                                if (view.isDefault && MyWorkGrid.defaultViewId !== view.id) {
                                    if (view.isPersonal) {
                                        defaultPersonalView = view.id;
                                    } else {
                                        defaultGlobalView = view.id;
                                    }
                                }
                            }

                            if (defaultPersonalView !== '') {
                                MyWorkGrid.applyView(defaultPersonalView);
                            } else {
                                MyWorkGrid.applyView(defaultGlobalView);
                            }

                        } else {
                            MyWorkGrid.applyView(masterView);
                        }

                    }
                }

                MyWorkGrid.viewsLoaded = true;

                RefreshCommandUI();
            }
        });
    },

    applyView: function (viewId) {
        try {
            if (MyWorkGrid.defaultViewId === viewId) {
                return;
            }

            var grid = Grids[MyWorkGrid.gridId];

            var allCols = new Array();

            var view = MyWorkGrid.views[viewId];

            if (view.leftCols !== null) {
                var leftCols = view.leftCols.split(',');

                for (var lc = 0; lc < leftCols.length; lc++) {
                    var lcv = leftCols[lc].split(':');
                    var lcol = lcv[0];

                    Array.add(allCols, lcol);

                    try {
                        var lwidth = lcv[1] - MyWorkGrid.getColWidth(lcol);

                        if (lcol === 'Edit') {
                            if ($.browser.msie && parseInt($.browser.version) <= 8) {
                                lwidth = 23;
                            }
                        }

                        if (lwidth !== 0) {
                            grid.SetWidth(lcol, lwidth);
                        }
                    } catch (e) {
                    }

                    grid.MoveCol(lcol, 0, 1, 1);
                }
            }

            if (view.cols !== null) {
                var cols = view.cols.split(',');

                for (var cc = 0; cc < cols.length; cc++) {
                    var ccv = cols[cc].split(':');
                    var ccol = ccv[0];

                    Array.add(allCols, ccol);

                    try {
                        var cwidth = ccv[1] - MyWorkGrid.getColWidth(ccol);
                        if (cwidth !== 0) {
                            grid.SetWidth(ccol, cwidth);
                        }
                    } catch (e) {
                    }

                    grid.MoveCol(ccol, 1, 1, 1);
                }
            }

            if (view.rightCols !== null) {
                var rightCols = view.rightCols.split(',');

                for (var rc = 0; rc < rightCols.length; rc++) {
                    var rcv = rightCols[rc].split(':');
                    var rcol = rcv[0];

                    Array.add(allCols, rcol);

                    try {
                        var rwidth = rcv[1] - MyWorkGrid.getColWidth(rcol);
                        if (rwidth !== 0) {
                            grid.SetWidth(rcol, rwidth);
                        }
                    } catch (e) {
                    }

                    grid.MoveCol(rcol, 2, 1, 1);
                }
            }

            grid.Update();
            grid.Render();

            var groupCols = grid.Group.split(',');

            grid.DoGrouping(null);

            for (var i = 0; i < groupCols.length; i++) {
                grid.HideCol(groupCols[i]);
            }

            var vCols = grid.GetCols('Visible');
            vCols = vCols.concat(groupCols);

            var mainCols = [];

            for (var i = 0; i < vCols.length; i++) {
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

            grid.ChangeColsVisibility(allCols, mainCols, 0);

            if (view['filters'] === '') {
                grid.ChangeFilter('', '', '', 0, 0, null);
            } else {
                var filters = view['filters'].split('|');

                if (filters[0] === '1') {
                    MyWorkGrid.showFilters();
                } else {
                    MyWorkGrid.hideFilters();
                }

                var filter = filters[1].split(':');

                grid.ChangeFilter(filter[0], filter[1], filter[2], 0, 0, null);
            }

            grid.ChangeSort(view['sorting']);

            if (view['grouping'] === '') {
                grid.DoGrouping(null);
            } else {
                var grouping = view['grouping'].split('|');

                if (grouping[0] === '1') {
                    MyWorkGrid.showGrouping();
                } else {
                    MyWorkGrid.hideGrouping();
                }

                grid.DoGrouping(grouping[1]);
            }

            grid.Cols["Title"]["RelWidth"] = 100;

            if (grid.TotalRowsInEditMode === undefined) {
                grid.TotalRowsInEditMode = 0;
            } else if (grid.TotalRowsInEditMode > 0 && MyWorkGrid.getColWidth('Edit') === 25) {
                grid.SetWidth('Edit', 25);
            }

            grid.Update();
            grid.Render();

            grid.Cols['Title'].RelWidth = 1;

            MyWorkGrid.defaultViewId = viewId;
            MyWorkGrid.defaultView = view.name;
            MyWorkGrid.isDefaultViewPersonal = view.isPersonal;

            for (var rowId in grid.Rows) {
                var row = grid.Rows[rowId];

                if (row.Def.Name === 'Header' || row.Def.Name === 'Fixed' || row.Def.Name === 'Group' || row.Def.Name === 'Solid') continue;

                if (grid.GetValue(row, 'Complete') === 1) {
                    markRowCompleted(grid, row);
                }
            }

            configureTitleCol(grid);

            RefreshCommandUI();

            window.setTimeout(function () {
                var g = Grids[MyWorkGrid.gridId];
                g.Update();
                g.Render();

                $('#EPMMyWorkGrid').css('overflow', 'visible');
                $('.s4-wpTopTable').css('border', 'none');
            }, 10);
        } catch (e) {
        }
    },

    getColWidth: function (col) {
        var value = Grids[MyWorkGrid.gridId].Cols[col].Width;

        if (!intRegex.test(value)) {
            if (value.indexOf('-') != -1) {
                value = value.split('-')[0];
            }
        }

        return value - 0;
    },

    populateViews: function () {
        var sb = new Sys.StringBuilder();
        sb.append("<Menu Id='Ribbon.MyWork.Views.Dropdown.Menu'>");

        sb.append("<MenuSection DisplayMode='Menu' Id='Ribbon.MyWork.Views.Dropdown.Menu.Default' Title='Current View'>");
        sb.append("<Controls Id='Ribbon.MyWork.Views.Dropdown.Menu.Default.Controls'>");
        sb.append("<Button Id='Ribbon.MyWork.views." + MyWorkGrid.defaultViewId + "' Command='MyWork.Cmd.CurrentViewDropDown.Select' LabelText=\""
            + MyWorkGrid.defaultView + "\" CommandValueId='" + MyWorkGrid.defaultViewId + "'/>");
        sb.append('</Controls>');
        sb.append('</MenuSection>');

        if (MyWorkGrid.views !== undefined) {
            var views = MyWorkGrid.views;

            sb.append("<MenuSection DisplayMode='Menu' Id='Ribbon.MyWork.Views.Dropdown.Menu.Global' Title='Global Views'>");
            sb.append("<Controls Id='Ribbon.MyWork.Views.Dropdown.Menu.Global.Controls'>");

            for (var v in views) {
                var view = views[v];

                if (view.name !== undefined) {
                    if (!view.isPersonal) {
                        sb.append("<Button Id='Ribbon.MyWork.views." + view.id + "' Command='MyWork.Cmd.CurrentViewDropDown.Select' LabelText=\""
                            + view.name + "\" CommandValueId='" + view.id + "'/>");
                    }
                }
            }

            sb.append('</Controls>');
            sb.append('</MenuSection>');

            sb.append("<MenuSection DisplayMode='Menu' Id='Ribbon.MyWork.Views.Dropdown.Menu.Personal' Title='Personal Views'>");
            sb.append("<Controls Id='Ribbon.MyWork.Views.Dropdown.Menu.Personal.Controls'>");

            for (var v in views) {
                var view = views[v];

                if (view.name !== undefined) {
                    if (view.isPersonal) {
                        sb.append("<Button Id='Ribbon.MyWork.views." + view.id + "' Command='MyWork.Cmd.CurrentViewDropDown.Select' LabelText=\""
                            + view.name + "\" CommandValueId='" + view.id + "'/>");
                    }
                }
            }

            sb.append('</Controls>');
            sb.append('</MenuSection>');
        }

        sb.append('</Menu>');

        return sb.toString();
    },

    saveView: function () {
        var grid = Grids[MyWorkGrid.gridId];

        grid.StaticCursor = 0;
        grid.ActionBlur();

        var viewDiv = document.createElement('div');

        viewDiv.innerHTML = document.getElementById('MWG_SaveView').innerHTML;
        viewDiv.children[0].children[0].value = MyWorkGrid.defaultView;

        if (MyWorkGrid.views[MyWorkGrid.defaultViewId].isDefault) {
            viewDiv.children[0].children[2].checked = true;
        }

        if (MyWorkGrid.isDefaultViewPersonal) {
            var personalCheckBox = viewDiv.children[0].children[4];
            if (!personalCheckBox.disabled) {
                personalCheckBox.checked = true;
            }
        }

        var options = { html: viewDiv, width: 250, height: 125, title: "Save View", dialogReturnValueCallback: MyWorkGrid.onSaveViewClose };
        SP.UI.ModalDialog.showModalDialog(options);
    },

    onSaveViewClose: function (dialogResult, returnValue) {
        if (dialogResult !== SP.UI.DialogResult.OK) return;

        var vals = returnValue.split("|");

        var viewName = vals[0];
        var viewId = 'dv';
        if (viewName !== 'Default View') {
            viewId = MD5(viewName.toLowerCase());
        }
        var isViewDefault = vals[1];
        var isViewPersonal = vals[2];

        var grid = Grids[MyWorkGrid.gridId];
        grid.StaticCursor = 1;

        if (MyWorkGrid.validateViewName(viewId, viewName, 'overwrite')) {
            var leftCols = '';
            var cols = '';
            var rightCols = '';

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

            if (MyWorkGrid.views[viewId] === undefined) {
                MyWorkGrid.views[viewId] = new Object();
            }

            var filterRow = grid.GetRowById('Filter');
            var filters = '';

            for (var col in grid.Cols) {
                var cell = filterRow[col + 'Filter'];

                if (cell !== undefined) {
                    if (cell !== 0) {
                        filters += ',' + col + ':' + filterRow[col] + ':' + cell;
                    }
                }
            }

            if (filters.length > 0) {
                filters = filters.substr(1);
            }

            var showFilter = 0;
            if (MyWorkGrid.filtersOn) {
                showFilter = 1;
            }

            filters = showFilter + '|' + filters;

            var showGrouping = 0;
            if (MyWorkGrid.groupingOn) {
                showGrouping = 1;
            }

            var grouping = showGrouping + '|' + grid.Group;

            var sorting = grid.Sort;

            var dataXml = '<MyWork><View ID="' + viewId + '" Name="' + viewName + '" Default="'
                + isViewDefault + '" Personal="' + isViewPersonal + '" LeftCols="' + leftCols + '" Cols="' + cols + '" RightCols="'
                + rightCols + '" Filters="' + filters + '" Grouping="' + grouping + '" Sorting="' + sorting + '"/></MyWork>';

            EPMLiveCore.WorkEngineAPI.Execute("SaveMyWorkGridView", dataXml, function (response) {
                response = parseJson(response);

                if (responseIsSuccess(response)) {
                    MyWorkGrid.defaultViewId = viewId;
                    MyWorkGrid.defaultView = viewName;
                    MyWorkGrid.isDefaultViewPersonal = isViewPersonal;

                    MyWorkGrid.views[viewId] = {
                        id: viewId,
                        name: viewName,
                        isDefault: isViewDefault === 'true' ? true : false,
                        isPersonal: isViewPersonal === 'true' ? true : false,
                        leftCols: leftCols,
                        cols: cols,
                        rightCols: rightCols,
                        filters: filters,
                        grouping: grouping,
                        sorting: sorting
                    };

                    RefreshCommandUI();
                }
            });
        }
    },

    validateViewName: function (viewId, viewName, action) {
        if (MyWorkGrid.views[viewId] !== undefined) {
            return confirm("Would you like to " + action + " the \"" + viewName + "\" view?");
        }

        return true;
    },

    getSavingViewInfo: function (element) {
        return element.parentNode.children[0].value + '|' + element.parentNode.children[2].checked + '|' + element.parentNode.children[4].checked;
    },

    renameView: function () {
        if (MyWorkGrid.defaultViewId === "dv") {
            alert('You cannot rename the Default View');
            return;
        }

        var grid = Grids[MyWorkGrid.gridId];

        grid.StaticCursor = 0;
        grid.ActionBlur();

        var viewDiv = document.createElement('div');

        viewDiv.innerHTML = document.getElementById('MWG_RenameView').innerHTML;
        viewDiv.children[0].children[0].innerHTML = '<strong>' + MyWorkGrid.defaultView + '</strong>';

        var options = { html: viewDiv, width: 280, height: 115, title: "Rename View", dialogReturnValueCallback: MyWorkGrid.onRenameViewClose };
        SP.UI.ModalDialog.showModalDialog(options);
    },

    onRenameViewClose: function (dialogResult, returnValue) {
        if (dialogResult !== SP.UI.DialogResult.OK) return;

        for (var v in MyWorkGrid.views) {
            var view = MyWorkGrid.views[v];

            if (view.isPersonal === MyWorkGrid.isDefaultViewPersonal && view.name === returnValue) {
                var group = 'Personal';
                if (!view.isPersonal) group = 'Global';

                alert('The "' + returnValue + '" view already exists in the ' + group + ' group.');
                return;
            }
        }

        var grid = Grids[MyWorkGrid.gridId];
        grid.StaticCursor = 1;


        if (MyWorkGrid.validateViewName(MyWorkGrid.defaultViewId, MyWorkGrid.defaultView, 'rename')) {
            var dataXml = '<MyWork><View ID="' + MyWorkGrid.defaultViewId + '" Name="' + returnValue + '" Personal="'
                + MyWorkGrid.isDefaultViewPersonal + '"/></MyWork>';

            EPMLiveCore.WorkEngineAPI.Execute("RenameMyWorkGridView", dataXml, function (response) {
                response = parseJson(response);

                if (responseIsSuccess(response)) {
                    MyWorkGrid.defaultView = returnValue;

                    MyWorkGrid.views[MyWorkGrid.defaultViewId].name = returnValue;

                    RefreshCommandUI();
                }
            });
        }
    },

    deleteView: function () {
        if (MyWorkGrid.defaultViewId === "dv") {
            alert('You cannot delete the Default View');
            return;
        }

        if (MyWorkGrid.validateViewName(MyWorkGrid.defaultViewId, MyWorkGrid.defaultView, 'delete')) {
            var dataXml = '<MyWork><View ID="' + MyWorkGrid.defaultViewId + '" Personal="' + MyWorkGrid.isDefaultViewPersonal + '"/></MyWork>';

            EPMLiveCore.WorkEngineAPI.Execute("DeleteMyWorkGridView", dataXml, function (response) {
                response = parseJson(response);

                if (responseIsSuccess(response)) {
                    delete MyWorkGrid.views[MyWorkGrid.defaultViewId];

                    MyWorkGrid.applyView('dv');
                }
            });
        }
    },

    toggleFilters: function () {
        if (!MyWorkGrid.filtersOn) {
            MyWorkGrid.showFilters();
        } else {
            MyWorkGrid.hideFilters();
        }

        window.setTimeout(function () {
            var g = Grids[MyWorkGrid.gridId];
            g.Update();
            g.Render();
        }, 10);

        return MyWorkGrid.filtersOn;
    },

    showFilters: function () {
        var grid = Grids[MyWorkGrid.gridId];

        MyWorkGrid.filtersOn = true;
        grid.ShowRow(grid.GetRowById("Filter"));
    },

    hideFilters: function () {
        var grid = Grids[MyWorkGrid.gridId];

        MyWorkGrid.filtersOn = false;
        grid.HideRow(grid.GetRowById("Filter"));
    },

    toggleGrouping: function () {
        if (!MyWorkGrid.groupingOn) {
            MyWorkGrid.showGrouping();
        } else {
            MyWorkGrid.hideGrouping();
        }

        window.setTimeout(function () {
            var g = Grids[MyWorkGrid.gridId];
            g.Update();
            g.Render();
        }, 10);

        return MyWorkGrid.groupingOn;
    },

    showGrouping: function () {
        var grid = Grids[MyWorkGrid.gridId];

        MyWorkGrid.groupingOn = true;
        var row = grid.GetRowById('AR2') || grid.GetRowById('AR1');
        grid.ShowRow(row);
    },

    hideGrouping: function () {
        var grid = Grids[MyWorkGrid.gridId];

        MyWorkGrid.groupingOn = false;
        var row = grid.GetRowById('AR2') || grid.GetRowById('AR1');
        grid.HideRow(row);
    },

    canHandleRibbonCommand: function () {
        try {
            var grid = Grids[MyWorkGrid.gridId];
            var row = grid.FRow;

            if (!row || !row.Def) {
                var selRows = grid.GetSelRows();
                if (selRows && selRows.length > 0) row = selRows[0];
            }

            if (row === undefined || row === null || row.Def.Name === 'Header' || row.Def.Name === 'Fixed' || row.Def.Name === 'Group') {
                return false;
            }

            return true;
        } catch (e) {
        }

        return false;
    },

    clearSort: function () {
        Grids[MyWorkGrid.gridId].ChangeSort('DueDate');
    },

    toggleCompletedItems: function () {
        if (!MyWorkGrid.showingCompletedItems) {
            MyWorkGrid.showCompletedItems();
        } else {
            MyWorkGrid.hideCompletedItems();
        }

        return MyWorkGrid.showingCompletedItems;
    },

    showCompletedItems: function () {
        MyWorkGrid.showingCompletedItems = true;
        MyWorkGrid.loadingCompletedItems = true;
        MyWorkGrid.defaultViewId = null;

        var grid = Grids[MyWorkGrid.gridId];

        var source = grid.Source;
        source.Data.Param.Dataxml = completeQuery;
        source.Layout.Param.Dataxml = completeQuery;

        grid.Reload(source, null, false);
        MyWorkGrid.isDirty = true;

        MyWorkGrid.changeToolbarSelection('Completed');

        try {
            $('.GSNoDataRow').find('div').html('You do not have any completed work items.');
        } catch (e) {
        }
    },

    hideCompletedItems: function () {
        MyWorkGrid.showingCompletedItems = false;
        MyWorkGrid.loadingCompletedItems = false;
        MyWorkGrid.defaultViewId = null;

        var grid = Grids[MyWorkGrid.gridId];

        var source = grid.Source;
        source.Data.Param.Dataxml = nonCompleteQuery;
        source.Layout.Param.Dataxml = nonCompleteQuery;

        grid.Reload(source, null, false);
        MyWorkGrid.isDirty = true;

        MyWorkGrid.changeToolbarSelection('Active');

        try {
            $('.GSNoDataRow').find('div').html('There are no active work items assigned to you.');
        } catch (e) {
        }
    },

    reloadCommentCount: function (result, value, params) {
        var dataXml = '<ListItem><Item ID="' + params.itemId + '" /><List ID="' + params.listId + '" /><Web ID="' + params.webId + '" /><Site ID="' + params.siteId
            + '" URL="' + params.siteUrl + '" /></ListItem>';

        EPMLiveCore.WorkEngineAPI.Execute("GetListItem", dataXml, function (response) {
            response = parseJson(response);

            if (responseIsSuccess(response)) {
                var fields = response.Result.ListItem.Fields.Field;

                var commentCount = params.row['CommentCount'];
                var commenters = params.row['Commenters'];
                var commentersRead = params.row['CommentersRead'];

                for (var f in fields) {
                    var field = fields[f];
                    if (field["@Name"] === 'CommentCount') {
                        commentCount = field["#cdata"];
                    }

                    if (field["@Name"] === 'Commenters') {
                        commenters = field["#cdata"];
                    }

                    if (field["@Name"] === 'CommentersRead') {
                        commentersRead = field["#cdata"];
                    }
                }

                setCellValue(commentCount, params.grid.id, params.row.id, 'CommentCount');
                setCellValue(commenters, params.grid.id, params.row.id, 'Commenters');
                setCellValue(commentersRead, params.grid.id, params.row.id, 'CommentersRead');

                var cssClass = 'MWG_CommentRead';
                if (params.row['Complete'] === 1) {
                    markRowCompleted(params.grid, params.row);
                    cssClass = 'MWG_CommentRead_Completed';
                }

                try {
                    document.getElementById('MWG_CommentCount_' + params.row.id).className = cssClass;
                } catch (e) {
                }
            }
        });
    },

    reloadItemData: function (result, value, params) {
        var dataXml = '<MyWork><Item ID="' + params.itemId + '" /><List ID="' + params.listId + '" /><Web ID="' + params.webId + '" /><Site ID="' + params.siteId
            + '" URL="' + params.siteUrl + '" /></MyWork>';

        EPMLiveCore.WorkEngineAPI.Execute("GetMyWorkListItem", dataXml, function (response) {
            response = parseJson(response);

            if (responseIsSuccess(response)) {
                var fields = response.Result.MyWork.Fields.Field;

                var completed = false;
                var cssClass = 'MWG_CommentDisabled';

                for (var f in fields) {
                    var field = fields[f];
                    var fieldName = field["@Name"];

                    if (params.row[fieldName] !== undefined) {
                        var value = field["#cdata"];

                        if (fieldName === 'Complete') {
                            if (value === 'True') {
                                setCellValue(1, params.grid.id, params.row.id, 'Complete');
                                completed = true;
                            } else {
                                setCellValue(0, params.grid.id, params.row.id, 'Complete');
                            }
                        } else {
                            setCellValue(value, params.grid.id, params.row.id, fieldName);
                        }
                    }
                }

                var commentCount = params.row['CommentCount'];
                var commentsRead = MyWorkGrid.isCommentRead(params.row);

                if (commentCount !== undefined || commentCount !== '') {
                    if (completed) {
                        if (commentsRead) {
                            cssClass = 'MWG_CommentRead_Completed';
                        } else {
                            cssClass = 'MWG_Comment_Completed';
                        }
                    } else {
                        if (commentsRead) {
                            cssClass = 'MWG_CommentRead';
                        } else {
                            cssClass = 'MWG_Comment';
                        }
                    }
                }

                try {
                    document.getElementById('MWG_CommentCount_' + params.row.id).className = cssClass;
                } catch (e) {
                }

                if (completed) {
                    markRowCompleted(params.grid, params.row);
                }

                SP.UI.Notify.addNotification("Item was updated successfully.", false);
            }
        });
    },

    populateNewItemListButton: function () {
        var sb = new Sys.StringBuilder();
        sb.append("<Menu Id='Ribbon.MyWork.NewItem.Menu'>");

        sb.append("<MenuSection DisplayMode='Menu32' Id='Ribbon.MyWork.NewItem.Menu.Lists' Title=' '>");
        sb.append("<Controls Id='Ribbon.MyWork.NewItem.Menu.Lists.Controls'>");

        for (var l in newItemLists) {
            var list = newItemLists[l]["Name"];

            sb.append("<Button Id='Ribbon.MyWork.NewItem." + list + "' Command='MyWork.Cmd.NewItem' CommandValueId='"
                + list + "' LabelText='" + list + " Item' Description='Create a new "
                + list + " item.' Image32by32='/_layouts/1033/images/formatmap32x32.png' CommandType='OptionSelection' Image32by32Top='-160' Image32by32Left='-384'/>");
        }

        sb.append('</Controls>');
        sb.append('</MenuSection>');
        sb.append('</Menu>');

        return sb.toString();
    },

    canHandleNewItemRibbonCommand: function () {
        return newItemLists.length > 0;
    },

    addNewItem: function (list) {
        if (list !== undefined) {
            var grid = Grids[MyWorkGrid.gridId];

            if (!MyWorkGrid.leaveConfirmation(grid)) {
                return;
            }

            for (var l in newItemLists) {
                var theList = newItemLists[l];

                if (list === theList["Name"]) {
                    if (theList["Rollup"]) {
                        document.location.href = siteUrl + '/_layouts/epmlive/newitem.aspx?List=' + list + '&Source=' + document.location.href;
                    } else {
                        showSharePointPopup(siteUrl + '/_layouts/epmlive/myworkgridaction.aspx?action=new&webid=' + currentWebId + '&listname=' + list, null, true, true, MyWorkGrid.fullReload);
                    }
                }
            }
        }
    },

    goToWorkspace: function () {
        var grid = Grids[MyWorkGrid.gridId];
        var row = grid.FRow;

        if (!MyWorkGrid.leaveConfirmation(grid)) {
            return;
        }

        document.location.href = siteUrl + '/_layouts/epmlive/gridaction.aspx?action=workspace&webid=' + row['WebID'] + '&Source=' + document.location.href;
    },

    canHandleApproveRejectCommand: function () {
        try {
            var grid = Grids[MyWorkGrid.gridId];
            var row = grid.FRow;

            if (!row || !row.Def) {
                var selRows = grid.GetSelRows();
                if (selRows && selRows.length > 0) row = selRows[0];
            }

            if (row === undefined || row === null || row.Def.Name === 'Header' || row.Def.Name === 'Fixed' || row.Def.Name === 'Group') {
                return false;
            }

            var dataXml = '<ListItems><ListItem><Item ID="' + row['ItemID'] + '" /><List ID="' + row['ListID'] + '" /><Web ID="' + row['WebID'] + '" /><Site ID="' + row['SiteID']
                + '" URL="' + row['SiteURL'] + '" /></ListItem></ListItems>';

            EPMLiveCore.WorkEngineAPI.Execute("IsModerationEnabled", dataXml, function (response) {
                response = parseJson(response);

                if (responseIsSuccess(response)) {
                    return response.Result.ListItems.ListItem.ModerationEnabled === "true";
                }

                return false;
            });
        } catch (e) {
        }

        return false;
    },

    leaveConfirmation: function (grid) {
        if (grid.TotalRowsInEditMode > 0) {

            if (confirm(leaveMessage + " Are you sure you want to proceed?")) {

                for (var rowId in grid.Rows) {
                    var row = grid.Rows[rowId];

                    if (row.Def.Name === 'Header' || row.Def.Name === 'Fixed' || row.Def.Name === 'Group' || row.Def.Name === 'Solid') continue;

                    if (row.isBeingEdited) {
                        cancelRowEdit(grid.id, row.id);
                    }
                }

                return true;
            }

            return false;
        }

        return true;
    },

    isCommentRead: function (row) {
        var commentersRead = row['CommentersRead'];

        if (intRegex.test(commentersRead)) {
            if (commentersRead === userId) {
                return true;
            }
        } else if (commentersRead.indexOf(',') !== -1) {
            var commentViewrs = commentersRead.split(',');
            for (var u in commentViewrs) {
                if (parseInt(commentViewrs[u]) === userId) {
                    return true;
                }
            }
        }

        return false;
    },

    fullReload: function () {
        if (MyWorkGrid.showingCompletedItems) {
            MyWorkGrid.showCompletedItems();
        } else {
            MyWorkGrid.hideCompletedItems();
        }
    },

    resetNoDataRow: function () {
        var gridTable = document.getElementById(MyWorkGrid.gridId);

        if (gridTable !== null) {
            var tableBodyElement = gridTable.firstChild;

            if (!Grids[MyWorkGrid.gridId].GetFirstVisible()) {
                gridTable.removeChild(tableBodyElement);
                var row = gridTable.insertRow(0);
                var cell = row.insertCell(0);

                var message = 'There are no active work items assigned to you.';

                if (MyWorkGrid.showingCompletedItems) {
                    message = 'You do not have any completed work items.';
                }

                cell.innerHTML = message;

                MyWorkGrid.noDataResetCompleted = true;
            }
        }
    },

    showProcessing: function (rowId) {
        $('#MWG_Processing_' + rowId).show();
    },

    hideProcessing: function (rowId) {
        $('#MWG_Processing_' + rowId).hide();
    },

    updateWorkingOn: function (rowId) {
        var row = Grids[MyWorkGrid.gridId].GetRowById(rowId);
        var ele = $('#epmtgs_' + rowId);

        var slider = $(ele.find('.epmlive-toggle-switch-slider')[0]);
        var label = $(ele.find('span')[0]);

        var width = ele.width() + slider.width() + 7;

        if (ele.data('state')) {
            ele.data('state', 0);
            ele.removeClass('epmlive-toggle-switch-on');
            ele.addClass('epmlive-toggle-switch-off');
            slider.animate({ left: '-=' + width }, 300);
            label.text('NO');
            row['WorkingOn'] = 0;
        } else {
            ele.data('state', 1);
            ele.removeClass('epmlive-toggle-switch-off');
            ele.addClass('epmlive-toggle-switch-on');
            slider.animate({ left: '+=' + width }, 300);
            label.text('YES');
            row['WorkingOn'] = 1;
        }

        var dataXml = "{ Function: 'TagManager_AddTagOrder', Dataxml: '<TagOrder ListId=\"" + row['ListID'] + "\" ItemId=\"" + row['ItemID'] + "\" TagId=\"" + MyWorkGrid.tagId + "\"/>' }";

        if (row['WorkingOn'] === 0) {
            dataXml = "{ Function: 'TagManager_RemoveTagOrder', Dataxml: '<TagOrder ListId=\"" + row['ListID'] + "\" ItemId=\"" + row['ItemID'] + "\" TagId=\"" + MyWorkGrid.tagId + "\"/>' }";
        }

        var $$$ = window.epmLive;

        $.ajax({
            type: 'POST',
            url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
            data: dataXml,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',

            success: function (response) {
                if (response.d) {
                    var responseJson = $$$.parseJson(response.d);

                    var result = responseJson.Result;

                    if (!$$$.responseIsSuccess(result)) {
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

    configureTag: function () {
        var $$$ = window.epmLive;

        var getTag = function () {
            $.ajax({
                type: 'POST',
                url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'TagManager_GetTag', Dataxml: '<Tag Type=\"1\"/>' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',

                success: function (response) {
                    if (response.d) {
                        var responseJson = $$$.parseJson(response.d);

                        var result = responseJson.Result;

                        if ($$$.responseIsSuccess(result)) {
                            if (result.Tag) {
                                MyWorkGrid.tagId = result.Tag['@Id'];
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
        };

        var registerTag = function () {
            $.ajax({
                type: 'POST',
                url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
                data: "{ Function: 'TagManager_RegisterTag', Dataxml: '<Tag Name=\"WorkingOn\" Type=\"1\"/>' }",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',

                success: function (response) {
                    if (response.d) {
                        var responseJson = $$$.parseJson(response.d);

                        var result = responseJson.Result;

                        if ($$$.responseIsSuccess(result)) {
                            if (result.Tag) {
                                MyWorkGrid.tagId = result.Tag['@Id'];
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
        };

        getTag();

        if (!MyWorkGrid.tagId) {
            registerTag();
        }
    },

    performSearch: function (query) {
        var grid = Grids[MyWorkGrid.gridId];
        var searchBoxes = [$('#Ribbon_MyWork_Actions_Search'), $('#MWG_Search')];
        var searchBox;
        var i;

        if (query) {
            grid.ChangeFilter('TitleLower', query.toLowerCase(), 11, 0, 1, null);

            for (i = 0; i < searchBoxes.length; i++) {
                searchBox = searchBoxes[i];

                searchBox.removeClass('MWG_SearchProcessing');
                searchBox.addClass('MWG_SearchClose');
            }
        } else {
            grid.ChangeFilter('TitleLower', '', 0, 0, 1, null);

            for (i = 0; i < searchBoxes.length; i++) {
                searchBox = searchBoxes[i];

                searchBox.removeClass('MWG_SearchProcessing');
                searchBox.removeClass('MWG_SearchClose');

                searchBox.val('');
            }
        }

        window.setTimeout(function () {
            var g = Grids[MyWorkGrid.gridId];
            g.Update();
            g.Render();
        }, 1000);
    },

    configureRibbon: function () {
        var configureSearch = function () {
            if (!MyWorkGrid.searchConfigured) {
                var element = $('#Ribbon_MyWork_Actions_Search');
                if (element.length) {
                    MyWorkGrid.configureSearch(element);

                    MyWorkGrid.searchConfigured = true;
                }
            }
        };

        var configureWorkFilters = function () {
            if (!MyWorkGrid.workFiltersConfigured) {
                if (document.getElementById('Ribbon_MyWork_WorkFilter_DueAgoDays')) {
                    if (window.workFilters.daysAgo <= 0) {
                        window.workFilters.daysAgo = '';
                    }

                    if (window.workFilters.daysAfter <= 0) {
                        window.workFilters.daysAfter = '';
                    }

                    MyWorkGrid.workFilters = window.workFilters;

                    for (var i = 0; i < 2; i++) {
                        var ele = $(document.getElementById('Ribbon.MyWorkTab.MyWorkGroupWorkFilter-MyWorkLayout-' + i));
                        ele.css('display', 'block');
                        ele.css('margin-top', '5px');
                        ele.css('margin-bottom', '5px');
                        ele.css('background-position', 'center right');

                        for (var j = 0; j < 3; j++) {
                            $(document.getElementById('Ribbon.MyWorkTab.MyWorkGroupWorkFilter-MyWorkLayout-' + i + '-' + j)).css('display', 'inline');
                        }
                    }

                    var agoElement = $('#Ribbon_MyWork_WorkFilter_DueAgo-Medium-checkbox');
                    agoElement.change(function () {
                        MyWorkGrid.workFilters.daysAgoEnabled = agoElement.is(':checked');
                        window.RefreshCommandUI();
                    });

                    var afterElement = $('#Ribbon_MyWork_WorkFilter_DueAfter-Medium-checkbox');
                    afterElement.change(function () {
                        MyWorkGrid.workFilters.daysAfterEnabled = afterElement.is(':checked');
                        window.RefreshCommandUI();
                    });

                    $(document.getElementById('Ribbon_MyWork_WorkFilter_DueAgoDays')).val(MyWorkGrid.workFilters.daysAgo);
                    $(document.getElementById('Ribbon_MyWork_WorkFilter_DueAfterDays')).val(MyWorkGrid.workFilters.daysAfter);

                    MyWorkGrid.workFiltersConfigured = true;
                }
            }
        };

        configureSearch();
        configureWorkFilters();
    },

    configureToolbar: function () {
        var configureMenu = function () {
            $('#MWG_Pivot').find('.mwg-menuitem').each(function () {
                $(this).click(function () {
                    var ele = $(this);

                    if (!ele.hasClass('selected')) {
                        var filter = ele.data('filter');

                        if (filter === 'active') {
                            MyWorkGrid.hidePivotMenu();
                            MyWorkGrid.hideCompletedItems();
                            window.RefreshCommandUI();
                        } else if (filter === 'completed') {
                            MyWorkGrid.hidePivotMenu();
                            MyWorkGrid.showCompletedItems();
                            window.RefreshCommandUI();
                        } else if (filter === '7days') {
                            MyWorkGrid.filter('7', 'Due');
                            MyWorkGrid.changeToolbarSelection('Seven');
                        }
                    }
                });
            });

            $('#MWG_Pivot_Selector').click(function () {
                var menu = $('#MWG_PivotMenu_wrap');

                var showMenu = function () {
                    MyWorkGrid.buildShowMeFilters();

                    var dictionary = [
                        { element: 'MWG_WorkType_Menu', action: 'Work0000Type', values: MyWorkGrid.showMeFilters.workType },
                        { element: 'MWG_CreatedBy_Menu', action: 'Author', values: MyWorkGrid.showMeFilters.createdBy },
                        { element: 'MWG_Priority_Menu', action: 'Priority', values: MyWorkGrid.showMeFilters.priority },
                        { element: 'MWG_Status_Menu', action: 'StatusFC', values: MyWorkGrid.showMeFilters.status },
                        { element: 'MWG_Flag_Menu', action: 'Flag', values: ['Flagged', 'Not Flagged'] },
                        { element: 'MWG_Due_Menu', action: 'Due', values: ['Next 7 days', 'Next 14 days', 'Next 30 days'] }
                    ];

                    for (var i = 0; i < dictionary.length; i++) {
                        var item = dictionary[i];

                        for (var j = 0; j < item.values.length; j++) {
                            var value = item.values[j];
                            var dataValue = value;

                            if (item.action === 'Flag') {
                                dataValue = value === 'Flagged' ? 1 : 0;
                            }

                            $('#' + item.element).append('<li data-col="' + item.action + '" data-value="' + dataValue + '">' + value + '</li>');
                        }
                    }

                    $($('#MWG_PivotMenu').find('.mwg-submenu')).each(function () {
                        $($(this).find('li')).each(function () {
                            $(this).click(function () {
                                var ele = $(this);
                                MyWorkGrid.filter(ele.data('value'), ele.data('col'));
                            });
                        });

                        $(this).parent().hide();
                    });

                    if (MyWorkGrid.showMeFilterApplied) {
                        $('.mwg-mi-clear').show();
                    } else {
                        $('.mwg-mi-clear').hide();
                    }

                    menu.show();
                };

                if (!menu.is(':visible')) {
                    MyWorkGrid.hidePivotMenu();
                    showMenu();
                }
            });

            $('#MWG_PivotClose').click(function () {
                MyWorkGrid.hidePivotMenu();
            });

            $('.mwg-smi').hover(
                function () {
                    $($(this).find('.mwg-submenu-wrap')).show();
                },
                function () {
                    $($(this).find('.mwg-submenu-wrap')).hide();
                }
            );

            $('.mwg-mi-clear').click(function () {
                MyWorkGrid.clearFilter();
            });
        };

        var configureSearch = function () {
            MyWorkGrid.configureSearch($('#MWG_Search'));
        };

        configureMenu();
        configureSearch();
    },

    buildShowMeFilters: function () {
        if (MyWorkGrid.isDirty || !MyWorkGrid.showMeFilters) {
            var grid = Grids[MyWorkGrid.gridId];

            var workTypes = [];
            var createdBy = [];
            var priorities = [];
            var statuses = [];

            for (var r in grid.Rows) {
                if (grid.Rows.hasOwnProperty(r)) {
                    var row = grid.Rows[r];

                    if (row.Def.Kind === 'Data' && row.Def.Name === 'R') {
                        var workType = row['Work0000Type'];
                        var author = row['Author'];
                        var priority = row['Priority'];
                        var status = row['StatusFC'];

                        if ($.inArray(workType, workTypes) === -1) {
                            workTypes.push(workType);
                        }

                        if ($.inArray(author, createdBy) === -1) {
                            createdBy.push(author);
                        }

                        if ($.inArray(priority, priorities) === -1) {
                            priorities.push(priority);
                        }

                        if ($.inArray(status, statuses) === -1) {
                            statuses.push(status);
                        }
                    }
                }
            }

            MyWorkGrid.showMeFilters = { workType: workTypes.sort(), createdBy: createdBy.sort(), priority: priorities.sort(), status: statuses.sort() };

            MyWorkGrid.isDirty = false;
        }
    },

    populateShowMe: function () {
        var generateId = function (num) {
            var id = '';
            var base = ('A').charCodeAt(0);

            do {
                num--;
                id = String.fromCharCode(base + (num % 26)) + id;
                num = (num / 26) >> 0;
            } while (num > 0);

            return id;
        };

        var preMenuXml = function (label, id) {
            id = id.toUpperCase();

            var s = new Sys.StringBuilder();

            s.append('<FlyoutAnchor Id="Ribbon.MyWork.Actions.ShowMe.M.MS.C.F' + id + '" LabelText="' + label + '" Command="MyWork.Cmd.ShowMe.Flyout">');
            s.append('<Menu Id="Ribbon.MyWork.Actions.ShowMe.M.MS.C.F' + id + '.M">');
            s.append('<MenuSection Id="Ribbon.MyWork.Actions.ShowMe.M.MS.C.F' + id + '.M.MS">');
            s.append('<Controls Id="Ribbon.MyWork.Actions.ShowMe.M.MS.C.F' + id + '.M.MS.C">');

            return s.toString();
        };

        var postMenuXml = function () {
            var s = new Sys.StringBuilder();

            s.append('</Controls>');
            s.append('</MenuSection>');
            s.append('</Menu>');
            s.append('</FlyoutAnchor>');

            return s.toString();
        };

        var buildMenuXml = function (label, id, command, items) {
            var s = new Sys.StringBuilder();
            s.append(preMenuXml(label, id));

            for (var i = 0; i < items.length; i++) {
                var item = items[i];
                s.append('<Button Id="Ribbon.MyWork.Actions.ShowMe.M.MS.C.FWT.M.MS.C.' + generateId(i + 1) + '" LabelText="' + item + '" Command="MyWork.Cmd.ShowMe.' + command + '" CommandValueId="' + item + '"/>');
            }

            s.append(postMenuXml());
            return s.toString();
        };

        var clearFiltersMenu = function () {
            var s = new Sys.StringBuilder();

            s.append('<MenuSection Id="Ribbon.MyWork.Actions.ShowMe.M.CMS">');
            s.append('<Controls Id="Ribbon.MyWork.Actions.ShowMe.M.CMS.C">');
            s.append('<Button Id="Ribbon.MyWork.Actions.ShowMe.M.CMS.C.CF" LabelText="Clear Filters" Command="MyWork.Cmd.ShowMe.Clear" Image16by16="/_layouts/epmlive/images/mywork/filteroff.gif" Image32by32="/_layouts/epmlive/images/mywork/filteroff.gif"/>');
            s.append('</Controls>');
            s.append('</MenuSection>');

            return s.toString();
        };

        MyWorkGrid.buildShowMeFilters();

        var sb = new Sys.StringBuilder();

        sb.append('<Menu Id="Ribbon.MyWork.Actions.ShowMe.M">');

        if (MyWorkGrid.showMeFilterApplied) {
            sb.append(clearFiltersMenu());
            sb.append('<MenuSection Id="Ribbon.MyWork.Actions.ShowMe.M.MS" Title="Filters">');
        } else {
            sb.append('<MenuSection Id="Ribbon.MyWork.Actions.ShowMe.M.MS">');
        }

        sb.append('<Controls Id="Ribbon.MyWork.Actions.ShowMe.M.MS.C">');

        sb.append(buildMenuXml('Work Types', 'WT', 'WorkType', MyWorkGrid.showMeFilters.workType));
        sb.append(buildMenuXml('Created By', 'CB', 'CreatedBy', MyWorkGrid.showMeFilters.createdBy));
        sb.append(buildMenuXml('Priority', 'PR', 'Priority', MyWorkGrid.showMeFilters.priority));
        sb.append(buildMenuXml('Status', 'STS', 'Status', MyWorkGrid.showMeFilters.status));
        sb.append(buildMenuXml('Flag', 'FLG', 'Flag', ['Flagged', 'Not Flagged']));
        sb.append(buildMenuXml('Due', 'DUE', 'Due', ['Next 7 days', 'Next 14 days', 'Next 30 days']));

        sb.append('</Controls>');
        sb.append('</MenuSection>');
        sb.append('</Menu>');

        return sb.toString();
    },

    filter: function (value, col) {
        var grid = window.Grids[MyWorkGrid.gridId];

        if (col === 'Flag') {
            if (value === 1) {
                grid.ChangeFilter(col, 1, 1, 0, 0, null);
            } else {
                grid.ChangeFilter(col, 1, 2, 0, 0, null);
            }

            MyWorkGrid.lastFilter = 'Flag';
        } else if (col === 'Due') {
            var date = new Date();
            var today = new Date(date.getFullYear(), date.getMonth(), date.getDate());

            var days;

            if (value.indexOf('7') !== -1) {
                days = 7;
            } else if (value.indexOf('14') !== -1) {
                days = 14;
            } else if (value.indexOf('30') !== -1) {
                days = 30;
            }

            if (days) {
                var d = new Date(today.getFullYear(), today.getMonth(), today.getDate() + days);

                grid.ChangeFilter('DueDateFC', window.DateToString(today, 'yyyyMMdd'), 6, 1, 0, null);
                grid.ChangeFilter('DueDateFC2', window.DateToString(d, 'yyyyMMdd'), 4, 0, 1, null);
            }

            MyWorkGrid.lastFilter = 'DueDateFC';
        } else {
            grid.ChangeFilter(col, value, 11, 0, 0, null);
            MyWorkGrid.lastFilter = col;
        }

        MyWorkGrid.showMeFilterApplied = true;

        MyWorkGrid.hidePivotMenu();

        window.setTimeout(function () {
            var g = Grids[MyWorkGrid.gridId];
            g.Update();
            g.Render();
        }, 10);
    },

    clearFilter: function () {
        window.Grids[MyWorkGrid.gridId].ChangeFilter(MyWorkGrid.lastFilter, '', 0, 0, 0, null);

        if (MyWorkGrid.lastFilter === 'DueDateFC') {
            window.Grids[MyWorkGrid.gridId].ChangeFilter('DueDateFC2', '', 0, 0, 0, null);
        }

        MyWorkGrid.lastFilter = null;
        MyWorkGrid.showMeFilterApplied = false;

        MyWorkGrid.hidePivotMenu();

        window.setTimeout(function () {
            var g = Grids[MyWorkGrid.gridId];
            g.Update();
            g.Render();
        }, 10);
    },

    changeToolbarSelection: function (selection) {
        $('.mwg-menuitem').each(function () {
            $(this).removeClass('selected');
        });

        $('#MWG_Pivot_' + selection).addClass('selected');
    },

    hidePivotMenu: function () {
        $('#MWG_PivotMenu_wrap').hide();

        $('.mwg-submenu').each(function () {
            $($(this).find('li')).each(function () {
                $(this).remove();
            });
        });

        $('#Ribbon_MyWork_Actions_Search').blur();
        $('#MWG_Search').blur();
    },

    configureSearch: function (element) {
        element.mousemove(function (e) {
            var ele = $(this);

            var x = (ele.width() + 25) - (e.pageX - ele.offset().left);

            if (x <= 25) {
                if (!ele.hasClass('MWG_Hover')) {
                    ele.addClass('MWG_Hover');
                }
            } else {
                if (ele.hasClass('MWG_Hover')) {
                    ele.removeClass('MWG_Hover');
                }
            }
        });

        element.click(function (e) {
            var ele = $(this);

            var x = (ele.width() + 25) - (e.pageX - ele.offset().left);

            if (x <= 25) {
                ele.addClass('MWG_SearchProcessing');

                if (ele.hasClass('MWG_SearchClose')) {
                    ele.val('');
                }

                MyWorkGrid.performSearch(ele.val());

                ele.blur();
            }
        });

        element.keypress(function (e) {
            if (e.which === 13) {
                var ele = $(this);

                ele.addClass('MWG_SearchProcessing');
                MyWorkGrid.performSearch(ele.val());

                ele.blur();
            }
        });

        element.change(function () {
            var ele = $(this);
            var val = ele.val();

            if (val !== MyWorkGrid.searchWatermark) {
                if (ele.attr('id') === 'MWG_Search') {
                    $('#Ribbon_MyWork_Actions_Search').val(val);
                } else {
                    $('#MWG_Search').val(val);
                }
            }
        });

        element.val(MyWorkGrid.searchWatermark).addClass('mwg-watermark');

        element.blur(function () {
            var ele = $(this);

            if (!ele.val()) {
                ele.val(MyWorkGrid.searchWatermark).addClass('mwg-watermark');
            }
        });

        element.focus(function () {
            var ele = $(this);

            if (ele.val() === MyWorkGrid.searchWatermark) {
                ele.val('').removeClass('mwg-watermark');
            }
        });
    },

    canHandleDueCommand: function (action) {
        var isActionAgo = action === 'ago';
        var shouldEnable = MyWorkGrid.workFiltersConfigured && (isActionAgo ? $('#Ribbon_MyWork_WorkFilter_DueAgo-Medium-checkbox').is(':checked') : $('#Ribbon_MyWork_WorkFilter_DueAfter-Medium-checkbox').is(':checked'));

        if (isActionAgo) {
            var agoElement = $('#Ribbon_MyWork_WorkFilter_DueAgoDays');

            if (shouldEnable) {
                agoElement.removeAttr('disabled');
            } else {
                agoElement.attr('disabled', 'disabled');
            }
        } else {
            var afterElement = $('#Ribbon_MyWork_WorkFilter_DueAfterDays');

            if (shouldEnable) {
                afterElement.removeAttr('disabled');
            } else {
                afterElement.attr('disabled', 'disabled');
            }
        }

        return shouldEnable;
    },

    updateWorkFilter: function (action, value) {
        var ele = action.indexOf('ago') !== -1 ?
            $(document.getElementById('Ribbon.MyWorkTab.MyWorkGroupWorkFilter-MyWorkLayout-0')) :
            $(document.getElementById('Ribbon.MyWorkTab.MyWorkGroupWorkFilter-MyWorkLayout-1'));

        ele.addClass('MWG_SearchProcessing');

        if (value !== true && value !== false) {
            try {
                if (value <= 0) {
                    value = '';
                }
            } catch (e) {
            }
        }

        var wf = MyWorkGrid.workFilters;

        if (action === 'ago') {
            wf.daysAgoEnabled = value;
        } else if (action === 'after') {
            wf.daysAfterEnabled = value;
        } else if (action === 'agodays') {
            wf.daysAgo = value;
        } else if (action === 'afterdays') {
            wf.daysAfter = value;
        }

        var $$$ = window.epmLive;

        var dataXml = '<Personalization Key="MyWork_DueFilter"><Filters><Filter Key="SiteId">' + $$$.currentSiteId + '</Filter></Filters><Value>' + wf.daysAgoEnabled + "|" + wf.daysAgo + "|" + wf.daysAfterEnabled + "|" + wf.daysAfter + '</Value></Personalization>';

        $.ajax({
            type: 'POST',
            url: $$$.currentWebUrl + '/_vti_bin/WorkEngine.asmx/Execute',
            data: "{ Function: 'Personalization_Set', Dataxml: '" + dataXml + "' }",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',

            success: function (response) {
                if (response.d) {
                    var responseJson = $$$.parseJson(response.d);

                    var result = responseJson.Result;

                    if (!$$$.responseIsSuccess(result)) {
                        $$$.logFailure(result);
                    }
                } else {
                    $$$.log('response.d: ' + response.d);
                }

                ele.removeClass('MWG_SearchProcessing');
            },

            error: function (error) {
                $$$.log(error);
                ele.removeClass('MWG_SearchProcessing');
            }
        });
    },
    
    loadRibbon: function () {
        SP.SOD.executeOrDelayUntilScriptLoaded(function () {
            var selectTab = function (tabId) {
                window._ribbonStartInit(tabId, false, null);
                window.SelectRibbonTab(tabId, true);
                window.RefreshCommandUI();
            };

            var pm = SP.Ribbon.PageManager.get_instance();

            var ribbon = null;

            try {
                ribbon = pm.get_ribbon();
            } catch (e) {
            }

            if (!ribbon) {
                if (typeof(window._ribbonStartInit) === 'function') {
                    selectTab('Ribbon.MyWorkTab');
                }
            } else {
                var selectedTab = $('#RibbonContainer_activeTabId').val();
                if (selectedTab !== 'Ribbon.MyWorkTab' && selectedTab !== 'Ribbon.MyWorkViewsTab') {
                    window.SelectRibbonTab('Ribbon.MyWorkTab', true);
                    window.RefreshCommandUI();
                }
            }

        }, 'sp.ribbon.js');
    }
};

var Base64 = {
    // private property
    _keyStr: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=",

    // public method for encoding
    encode: function(input) {
        var output = "";
        var chr1, chr2, chr3, enc1, enc2, enc3, enc4;
        var i = 0;

        input = Base64._utf8_encode(input);

        while (i < input.length) {

            chr1 = input.charCodeAt(i++);
            chr2 = input.charCodeAt(i++);
            chr3 = input.charCodeAt(i++);

            enc1 = chr1 >> 2;
            enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
            enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
            enc4 = chr3 & 63;

            if (isNaN(chr2)) {
                enc3 = enc4 = 64;
            } else if (isNaN(chr3)) {
                enc4 = 64;
            }

            output = output +
                this._keyStr.charAt(enc1) + this._keyStr.charAt(enc2) +
                this._keyStr.charAt(enc3) + this._keyStr.charAt(enc4);

        }

        return output;
    },

    // public method for decoding
    decode: function(input) {
        var output = "";
        var chr1, chr2, chr3;
        var enc1, enc2, enc3, enc4;
        var i = 0;

        input = input.replace(/[^A-Za-z0-9\+\/\=]/g, "");

        while (i < input.length) {

            enc1 = this._keyStr.indexOf(input.charAt(i++));
            enc2 = this._keyStr.indexOf(input.charAt(i++));
            enc3 = this._keyStr.indexOf(input.charAt(i++));
            enc4 = this._keyStr.indexOf(input.charAt(i++));

            chr1 = (enc1 << 2) | (enc2 >> 4);
            chr2 = ((enc2 & 15) << 4) | (enc3 >> 2);
            chr3 = ((enc3 & 3) << 6) | enc4;

            output = output + String.fromCharCode(chr1);

            if (enc3 != 64) {
                output = output + String.fromCharCode(chr2);
            }
            if (enc4 != 64) {
                output = output + String.fromCharCode(chr3);
            }

        }

        output = Base64._utf8_decode(output);

        return output;

    },

    // private method for UTF-8 encoding
    _utf8_encode: function(string) {
        string = string.replace(/\r\n/g, "\n");
        var utftext = "";

        for (var n = 0; n < string.length; n++) {

            var c = string.charCodeAt(n);

            if (c < 128) {
                utftext += String.fromCharCode(c);
            } else if ((c > 127) && (c < 2048)) {
                utftext += String.fromCharCode((c >> 6) | 192);
                utftext += String.fromCharCode((c & 63) | 128);
            } else {
                utftext += String.fromCharCode((c >> 12) | 224);
                utftext += String.fromCharCode(((c >> 6) & 63) | 128);
                utftext += String.fromCharCode((c & 63) | 128);
            }

        }

        return utftext;
    },

    // private method for UTF-8 decoding
    _utf8_decode: function(utftext) {
        var string = "";
        var i = 0;
        var c = c1 = c2 = 0;

        while (i < utftext.length) {

            c = utftext.charCodeAt(i);

            if (c < 128) {
                string += String.fromCharCode(c);
                i++;
            } else if ((c > 191) && (c < 224)) {
                c2 = utftext.charCodeAt(i + 1);
                string += String.fromCharCode(((c & 31) << 6) | (c2 & 63));
                i += 2;
            } else {
                c2 = utftext.charCodeAt(i + 1);
                c3 = utftext.charCodeAt(i + 2);
                string += String.fromCharCode(((c & 15) << 12) | ((c2 & 63) << 6) | (c3 & 63));
                i += 3;
            }

        }

        return string;
    }
};