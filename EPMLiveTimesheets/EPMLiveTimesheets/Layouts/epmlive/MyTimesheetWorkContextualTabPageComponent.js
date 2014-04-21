function ULS_SP() {
    if (ULS_SP.caller) {
        ULS_SP.caller.ULSTeamName = "Windows SharePoint Services 4";
        ULS_SP.caller.ULSFileName = "/_layouts/epmlive/MyTimesheetWorkContextualTabPageComponent.js";
    }
}


Type.registerNamespace('MyTimesheetWorkPageComponent');

// RibbonApp Page Component
MyTimesheetWorkPageComponent.PageComponent = function () {
    ULS_SP();
    MyTimesheetWorkPageComponent.PageComponent.initializeBase(this);
}


MyTimesheetWorkPageComponent.PageComponent.initialize = function () {
    ULS_SP();
    ExecuteOrDelayUntilScriptLoaded(Function.createDelegate(null,
    MyTimesheetWorkPageComponent.PageComponent.initializePageComponent), 'SP.Ribbon.js');
}


MyTimesheetWorkPageComponent.PageComponent.initializePageComponent = function () {
    ULS_SP();
    var ribbonPageManager = SP.Ribbon.PageManager.get_instance();
    if (null !== ribbonPageManager) {
        ribbonPageManager.addPageComponent(MyTimesheetWorkPageComponent.PageComponent.instance);
        ribbonPageManager.get_focusManager().requestFocusForComponent(
    MyTimesheetWorkPageComponent.PageComponent.instance);
    }
}


MyTimesheetWorkPageComponent.PageComponent.refreshRibbonStatus = function () {
    SP.Ribbon.PageManager.get_instance().get_commandDispatcher().executeCommand(
  Commands.CommandIds.ApplicationStateChanged, null);
}


MyTimesheetWorkPageComponent.PageComponent.prototype = {
    getFocusedCommands: function () {
        ULS_SP();
        return ['Ribbon.MyTimesheetWork.ActionsGroup',
        'Ribbon.MyTimesheetWork.AddWork',
        'Ribbon.MyTimesheetWork.Search',
        'Ribbon.MyTimesheetWork.AllWork',
        'Ribbon.MyTimesheetWork.CurrentViewLabel',
        'Ribbon.MyTimesheetWork.ChangeView',
        'Ribbon.MyTimesheetWork.MyTimesheetWorkViewsGroup',
        'Ribbon.MyTimesheetWork.SaveView',
        'Ribbon.MyTimesheetWork.DeleteView',
        'Ribbon.MyTimesheetWork.RenameView',
        'Ribbon.MyTimesheetWork.SelectColumns',
        'Ribbon.MyTimesheetWork.ShowHideFilters',
        'Ribbon.MyTimesheetWork.ShowHideGrouping',
        'Ribbon.MyTimesheetWork.ClearSort'
        ];
    },
    getGlobalCommands: function () {
        ULS_SP();
        var $arr = [];
        Array.add($arr, 'Ribbon.MyTimesheetWork.AllWork.Query');
        Array.add($arr, 'Ribbon.MyTimesheetWork.PopulateViewDropDown');
        Array.add($arr, 'Ribbon.MyTimesheetWork.QueryCurrentView');
        Array.add($arr, 'Ribbon.MyTimesheetWork.ShowHideFilters.Query');
        Array.add($arr, 'Ribbon.MyTimesheetWork.ShowHideGrouping.Query');
        
        return $arr;
    },
    isFocusable: function () {
        ULS_SP();
        return true;
    },
    receiveFocus: function () {
        ULS_SP();
        return true;
    },
    yieldFocus: function () {
        ULS_SP();
        return true;
    },
    canHandleCommand: function (commandId) {
        ULS_SP();
        switch (commandId) {
            case "Ribbon.MyTimesheetWork.ActionsGroup":
            case "Ribbon.MyTimesheetWork.AddWork":
            case "Ribbon.MyTimesheetWork.Search":
            case "Ribbon.MyTimesheetWork.AllWork.Query":
            case "Ribbon.MyTimesheetWork.AllWork":
            case "Ribbon.MyTimesheetWork.CurrentViewLabel":
            case "Ribbon.MyTimesheetWork.ChangeView":
            case "Ribbon.MyTimesheetWork.PopulateViewDropDown":
            case "Ribbon.MyTimesheetWork.QueryCurrentView":
            case "Ribbon.MyTimesheetWork.ChangeView":
            case "Ribbon.MyTimesheetWork.MyTimesheetWorkViewsGroup":
            case "Ribbon.MyTimesheetWork.SaveView":
            case "Ribbon.MyTimesheetWork.RenameView":
            case "Ribbon.MyTimesheetWork.DeleteView":
            case "Ribbon.MyTimesheetWork.SelectColumns":
            case "Ribbon.MyTimesheetWork.ShowHideFilters":
            case "Ribbon.MyTimesheetWork.ShowHideGrouping":
            case "Ribbon.MyTimesheetWork.ClearSort":
            case "Ribbon.MyTimesheetWork.ShowHideFilters.Query":
            case "Ribbon.MyTimesheetWork.ShowHideGrouping.Query":
                return true;
            default:
                return commandEnabled(commandId);
        };
    },
    handleCommand: function (commandId, properties, sequence) {
        ULS_SP();


        if (commandId === 'Ribbon.MyTimesheetWork.AddWork') {
            
            ShowMessage("Adding Work", 120, 30);

            var items = "";
            var grid = Grids["TSWork"];

            var pGrid = parent.curGrid;

            for(var sRow in grid.Rows)
            {
                var oRow = grid.Rows[sRow];
                if(oRow.Def.Name == "R")
                {
                    if(grid.GetValue(oRow, "Check") == "1")
                    {
                        var id = grid.GetValue(oRow, "ListId") + "." + grid.GetValue(oRow, "ItemId");

                        if(grid.GetValue(oRow, "Current") == "1")
                        {
                            if(NonWork)
                            {
                                alert("(" + grid.GetValue(oRow, "Title") + ") is already in your timesheet.");
                            }
                            else
                            {
                                if(confirm("(" + grid.GetValue(oRow, "Title") + ") is already in your timesheet, would you like to add another copy?"))
                                {
                                    //items += "," + id;
                                    var nRow = grid.MoveRowsToGrid(oRow, pGrid, null, 3, 2);
                                    pGrid.ChangeDef(nRow, "R", 1, 0);
                                    pGrid.SetValue(nRow, "TSTotals", 0, 0);
                                    pGrid.Recalculate(nRow, "TSTotals", 1);
                                    for (var p in parent.TSCols) {
                                        pGrid.SetValue(nRow, p, 0, 0);
                                    }
                                    pGrid.SetAttribute(nRow, null, "CanEdit", 1, 1);

                                    parent.GetOtherHours(pGrid, nRow);
                                }
                            }
                        }
                        else
                        {
                            if(NonWork)
                            {
                            
                                var found = false;

                                for(var R in pGrid.Rows)
                                {
                                    try
                                    {
                                        var pRow = pGrid.Rows[R];

                                        var plistid = pGrid.GetValue(pRow, "ListID");
                                        var pitemid = pGrid.GetValue(pRow, "ItemID");

                                        var listid = grid.GetValue(oRow, "ListID");
                                        var itemid = grid.GetValue(oRow, "ItemID");
    
                                        if(plistid == listid && pitemid == itemid)
                                        {
                                            found = true;
                                            break;
                                        }
                                    }catch(e){}
                                }

                                if(!found)
                                {
                                    var nRow = grid.MoveRowsToGrid(oRow, pGrid, null, 3, 2);
                                    pGrid.ChangeDef(nRow, "R", 1, 0);
                                    pGrid.SetValue(nRow, "TSTotals", 0, 0);
                                    pGrid.Recalculate(nRow, "TSTotals", 1);
                                    pGrid.SetAttribute(nRow, null, "CanEdit", 1, 1);
                                    for (var p in parent.TSCols) {
                                        pGrid.SetValue(nRow, p, 0, 0);
                                    }

                                    parent.GetOtherHours(pGrid, nRow);
                                }
                                else
                                {
                                    alert("(" + grid.GetValue(oRow, "Title") + ") is already in your timesheet.");
                                }
                            }
                            else
                            {
                                var nRow = grid.MoveRowsToGrid(oRow, pGrid, null, 3, 2);
                                pGrid.ChangeDef(nRow, "R", 1, 0);
                                pGrid.SetValue(nRow, "TSTotals", 0, 0);
                                pGrid.Recalculate(nRow, "TSTotals", 1);
                                pGrid.SetAttribute(nRow, null, "CanEdit", 1, 1);
                                for (var p in parent.TSCols) {
                                    pGrid.SetValue(nRow, p, 0, 0);
                                }

                                parent.GetOtherHours(pGrid, nRow);
                            }
                        }
                    }
                }
            }

            var newgridid = pGrid.id.substr(2);
            var newobj = eval("parent.TSObject" + newgridid);

            parent.ChangeView(pGrid, newobj.CurrentViewId);
            parent.TimesheetHoursEdited = true;
            window.frameElement.commitPopup();

//            if(items != "")
//            {
//                items = items.substr(1);
//                
//                AddItems(grid, items);    
//            }
        }
        else if (commandId === 'Ribbon.MyTimesheetWork.AllWork')
        {

            ShowMessage("Loading Work", 130, 50);

            if(OtherWork)
                var sUrl = "MyTimesheetAddWork.aspx?ID=" + TSUID;
            else
                var sUrl = "MyTimesheetAddWork.aspx?ID=" + TSUID + "&otherwork=true";

            location.href = sUrl + "&isdlg=1&showmaximized=true";
        }
        else if (commandId === 'Ribbon.MyTimesheetWork.Search') {
            ShowSearch();
        }
        else if (commandId === 'Ribbon.MyTimesheetWork.AllWork.Query')
        {
            properties.On = OtherWork;
        }
        else if (commandId === 'Ribbon.MyTimesheetWork.PopulateViewDropDown') {
            properties.PopulationXML = this.getViews();
        }
        else if (commandId === 'Ribbon.MyTimesheetWork.QueryCurrentView')
        {
            properties['Value'] = CurrentView;
        }
        else if (commandId === 'Ribbon.MyTimesheetWork.SelectColumns') {
            Grids["TSWork"].ActionShowColumns();
        }
        else if (commandId === 'Ribbon.MyTimesheetWork.ShowHideFilters') {
            var grid = Grids["TSWork"];
            if (grid.GetRowById("Filter").Visible)
                grid.HideRow(grid.GetRowById("Filter"));
            else
                grid.ShowRow(grid.GetRowById("Filter"));
        }
        else if (commandId === 'Ribbon.MyTimesheetWork.ShowHideFilters.Query') {
            var grid = Grids["TSWork"];
            properties.On = grid.GetRowById("Filter").Visible;
        }
        else if (commandId === 'Ribbon.MyTimesheetWork.ShowHideGrouping') {
            var grid = Grids["TSWork"];
            if (grid.GetRowById("Group").Visible)
                grid.HideRow(grid.GetRowById("Group"));
            else
                grid.ShowRow(grid.GetRowById("Group"));
        }
        else if (commandId === 'Ribbon.MyTimesheetWork.ShowHideGrouping.Query') {
            var grid = Grids["TSWork"];
            properties.On = grid.GetRowById("Group").Visible;
        }
        else if (commandId === 'Ribbon.MyTimesheetWork.SaveView') {

            var grid = Grids["TSWork"];

            viewNameDiv2.style.display = "";

            viewNameDiv2.firstChild.nextSibling.nextSibling.value = CurrentView;

            viewNameDiv2.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.style.display = "";

            if (Views[CurrentViewId].Default.toLowerCase() == "true") {
                viewNameDiv2.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.checked = true;
            }
            else
                viewNameDiv2.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.checked = false;

            curGrid = grid;

            var options = { html: viewNameDiv2, width: 280, height: 150, title: "Save View", dialogReturnValueCallback: this.onSaveViewClose };
            SP.UI.ModalDialog.showModalDialog(options);
        }
        else if (commandId === 'Ribbon.MyTimesheetWork.ChangeView') {
            var grid = Grids["TSWork"];
            ChangeView(grid, properties['CommandValueId']);
        }
        else if (commandId === 'Ribbon.MyTimesheetWork.ClearSort') {
            var grid = Grids["TSWork"];
            grid.ChangeSort("Title");
        }
    },

    onSaveViewClose: function (dialogResult, returnValue) {
        if (dialogResult == "1") {
            var retval = returnValue.split('|');

            SaveView(curGrid, retval);
        }

    },

    getViews: function () {
        var sb = new Sys.StringBuilder();
        sb.append('<Menu Id=\'COB.SharePoint.Ribbon.WithPageComponent.PCNotificationGroup.Dropdown.Menu\'>');
        sb.append('<MenuSection DisplayMode=\'Menu\' Id=\'COB.SharePoint.Ribbon.WithPageComponent.PCNotificationGroup.Dropdown.Menu.Manage\'>');
        sb.append('<Controls Id=\'COB.SharePoint.Ribbon.WithPageComponent.PCNotificationGroup.Dropdown.Menu.Manage.Controls\'>');

        for (var v in Views) {

            var oView = Views[v];

            sb.append('<Button Id=\'Ribbon.MyTimesheet.ChangeView\' Command=\'Ribbon.MyTimesheetWork.ChangeView\' CommandValueId=\'' + v + '\' LabelText=\'' + oView.Name + '\' />');
        }

        sb.append('</Controls>');
        sb.append('</MenuSection>');
        sb.append('</Menu>');

        return sb.toString();
    },

}


// Register classes
MyTimesheetWorkPageComponent.PageComponent.registerClass('MyTimesheetWorkPageComponent.PageComponent', CUI.Page.PageComponent);
MyTimesheetWorkPageComponent.PageComponent.instance = new MyTimesheetWorkPageComponent.PageComponent();


// Notify waiting jobs
NotifyScriptLoadedAndExecuteWaitingJobs("/_layouts/epmlive/MyTimesheetWorkContextualTabPageComponent.js");