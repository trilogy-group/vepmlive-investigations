Type.registerNamespace('ContextualTabWebPart');

var _webPartPageComponentId;
var tsObject;

ContextualTabWebPart.CustomPageComponent = function ContextualTabWebPart_CustomPageComponent(webPartPcId, tsObject) {
    this._webPartPageComponentId = webPartPcId;

    this.tsObject = tsObject;

    ContextualTabWebPart.CustomPageComponent.initializeBase(this);
};

ContextualTabWebPart.CustomPageComponent.prototype = {

    $gridId: null,

    init: function ContextualTabWebPart_CustomPageComponent$init() {

    },

    getFocusedCommands: function ContextualTabWebPart_CustomPageComponent$getFocusedCommands() {
        return ['MyTimesheetContextualTab.EnableMyTimesheetTab',
        'MyTimesheetContextualTab.EnableContextualGroup',
        'Ribbon.MyTimesheet.ActionsGroup',
        'Ribbon.MyTimesheet.Save',
        'Ribbon.MyTimesheet.CurrentPeriodLabel',
        'Ribbon.MyTimesheet.ViewPeriodGroup',
        'Ribbon.MyTimesheet.PreviousPeriod',
        'Ribbon.MyTimesheet.CurrentPeriod',
        'Ribbon.MyTimesheet.NextPeriod',
        'Ribbon.MyTimesheet.CurrentViewLabel',
        'Ribbon.MyTimesheet.CurrentView',
        'Ribbon.MyTimesheet.ChangePeriod',
        'Ribbon.MyTimesheet.StatusLabel1',
        'Ribbon.MyTimesheet.Submit',
        'Ribbon.MyTimesheet.Unsubmit',
        'Ribbon.MyTimesheet.AddWork',
        'Ribbon.MyTimesheet.AddNonWork',
        'Ribbon.MyTimesheet.RemoveWork',
        'Ribbon.MyTimesheet.Comments',
        'Ribbon.MyTimesheet.Delegate',
        'Ribbon.MyTimesheet.DelegateMy',
        'Ribbon.MyTimesheet.ChangeDelegate',
        'Ribbon.MyTimesheet.DelegateOpen',
        'Ribbon.MyTimesheet.CurrentDelegate',

        'MyTimesheetContextualTab.EnableMyTimesheetViewsTab',
        'Ribbon.MyTimesheet.SaveView',
        'Ribbon.MyTimesheet.RenameView',
        'Ribbon.MyTimesheet.DeleteView',
        'Ribbon.MyTimesheet.CurrentViewDropDown.Select',
        'Ribbon.MyTimesheet.SelectColumns',
        'Ribbon.MyTimesheet.ShowHideFilters',
        'Ribbon.MyTimesheet.ShowHideGrouping',
        'Ribbon.MyTimesheet.ClearSort',
        'Ribbon.MyTimesheet.ChangeView',
        'Ribbon.MyTimesheet.AutoWork',

        'Ribbon.MyTimesheet.ApprovalsPM',
        'Ribbon.MyTimesheet.ApprovalsTM'];
    },

    getGlobalCommands: function ContextualTabWebPart_CustomPageComponent$getGlobalCommands() {
        return ['Ribbon.MyTimesheet.PopulatePeriodDropDown',
        'Ribbon.MyTimesheet.QueryCurrentPeriod',
        'Ribbon.MyTimesheet.PopulateDelegate',
        'Ribbon.MyTimesheet.CurrentViewDropDown.Populate',
        'Ribbon.MyTimesheet.ShowHideFilters.Query',
        'Ribbon.MyTimesheet.ShowHideGrouping.Query',
        'Ribbon.MyTimesheet.QueryStatus',
        'Ribbon.MyTimesheet.PopulateViewDropDown',
        'Ribbon.MyTimesheet.QueryCurrentView',
        'Ribbon.MyTimesheet.ShowHideFilters.Query',
        'Ribbon.MyTimesheet.ShowHideGrouping.Query',
        'Ribbon.MyTimesheet.Approvals'];
    },

    isFocusable: function ContextualTabWebPart_CustomPageComponent$isFocusable() {
        return true;
    },

    canHandleCommand: function ContextualTabWebPart_CustomPageComponent$canHandleCommand(commandId) {
        //Contextual Tab commands

        switch (commandId) {
            case 'MyTimesheetContextualTab.EnableMyTimesheetTab':
            case 'Ribbon.MyTimesheet.ActionsGroup':
            case 'MyTimesheetContextualTab.EnableContextualGroup':
            case 'Ribbon.MyTimesheet.CurrentPeriodLabel':
            case 'Ribbon.MyTimesheet.CurrentPeriod':
            case 'Ribbon.MyTimesheet.CurrentViewLabel':
            case 'Ribbon.MyTimesheet.CurrentView':
            case 'Ribbon.MyTimesheet.ViewPeriodGroup':
            case 'Ribbon.MyTimesheet.ChangePeriod':
            case 'Ribbon.MyTimesheet.PopulatePeriodDropDown':
            case 'Ribbon.MyTimesheet.QueryCurrentPeriod':
            case 'Ribbon.MyTimesheet.StatusLabel1':

            case 'Ribbon.MyTimesheet.DelegateMy':
            case 'Ribbon.MyTimesheet.Delegate':
            case 'Ribbon.MyTimesheet.ChangeDelegate':
            case 'Ribbon.MyTimesheet.DelegateOpen':
            case 'Ribbon.MyTimesheet.PopulateDelegate':
            case 'Ribbon.MyTimesheet.CurrentDelegate':
            case 'Ribbon.MyTimesheet.QueryStatus':
            case 'Ribbon.MyTimesheet.PopulateViewDropDown':
            case 'Ribbon.MyTimesheet.ChangeView':
            case 'Ribbon.MyTimesheet.QueryCurrentView':
            case 'Ribbon.MyTimesheet.ShowHideFilters.Query':
            case 'Ribbon.MyTimesheet.Approvals':
            case 'Ribbon.MyTimesheet.ApprovalsPM':
            case 'Ribbon.MyTimesheet.ApprovalsTM':
                return true;
            case 'Ribbon.MyTimesheet.Comments':
                if (curRow != null && curRow["ItemId"] != null)
                    return true;
                return false;
            case 'MyTimesheetContextualTab.EnableMyTimesheetViewsTab':
            case 'Ribbon.MyTimesheet.SaveView':
            case 'Ribbon.MyTimesheet.RenameView':
            case 'Ribbon.MyTimesheet.DeleteView':
                return this.tsObject.CanEditViews;
            case 'Ribbon.MyTimesheet.CurrentViewDropDown.Select':
            case 'Ribbon.MyTimesheet.SelectColumns':
            case 'Ribbon.MyTimesheet.ShowHideFilters':
            case 'Ribbon.MyTimesheet.ShowHideGrouping':
            case 'Ribbon.MyTimesheet.ClearSort':
                return true;
            case 'Ribbon.MyTimesheet.RemoveWork':
                if (this.tsObject.Locked || bTSApproving || (bTSSaving && bSaveAndSubmit))
                    return false;
                if (this.tsObject.Status != 'Unsubmitted')
                    return false;
                if (curRow != null && curRow["ItemID"] != null)
                    return true;
                return false;
            case 'Ribbon.MyTimesheet.AddWork':
            case 'Ribbon.MyTimesheet.AddNonWork':
            case 'Ribbon.MyTimesheet.AutoWork':
                if (this.tsObject.Locked || bTSApproving || (bTSSaving && bSaveAndSubmit))
                    return false;
                if (this.tsObject.Status != 'Unsubmitted')
                    return false;
                return true;
            case 'Ribbon.MyTimesheet.Save':
                if (bTSSaving || bTSApproving)
                    return false;
                if (this.tsObject.Locked)
                    return false;
                if (this.tsObject.Status != 'Unsubmitted')
                    return false;
                return true;
            case 'Ribbon.MyTimesheet.Submit':
                if (bTSSaving || bTSApproving)
                    return false;
                if (this.tsObject.Locked)
                    return false;
                if (this.tsObject.Status != 'Unsubmitted')
                    return false;
                return true;
            case 'Ribbon.MyTimesheet.Unsubmit':
                if (bTSSaving || bTSApproving)
                    return false;
                if (this.tsObject.Locked)
                    return false;
                if (this.tsObject.Status == 'Unsubmitted')
                    return false;
                return true;
            case 'Ribbon.MyTimesheet.PreviousPeriod':
                if (this.tsObject.PreviousPeriod != "0")
                    return true;
                return false;
            case 'Ribbon.MyTimesheet.NextPeriod':
                if (this.tsObject.NextPeriod != "0")
                    return true;
                return false;
            default:

                return false;
        }
    },

    handleCommand: function ContextualTabWebPart_CustomPageComponent$handleCommand(commandId, properties, sequence) {


        if (commandId === 'MyWork.Cmd.ViewItem') {

        }
        else if (commandId === 'Ribbon.MyTimesheet.Comments') {

            var grid = Grids["TS" + this.tsObject.id];
            var row = grid.FRow;

            var sUrl = siteUrl + '/_layouts/epmlive/gridaction.aspx?action=comments&webid=' + row['WebID'] + '&listid=' + row['ListID'] + '&ID=' + row['ItemID'];

            var options = { title: "Comments", allowMaximize: true, showClose: true, url: sUrl };

            SP.UI.ModalDialog.showModalDialog(options);

        }
        else if (commandId === 'Ribbon.MyTimesheet.PopulateViewDropDown') {
            properties.PopulationXML = this.getViews();
        }
        else if (commandId === 'Ribbon.MyTimesheet.PopulatePeriodDropDown') {
            properties.PopulationXML = this.getPeriods();
        }
        else if (commandId === 'Ribbon.MyTimesheet.QueryCurrentView') {
            properties['Value'] = this.tsObject.CurrentView;
        }
        else if (commandId === 'Ribbon.MyTimesheet.QueryCurrentPeriod') {
            properties['Value'] = this.tsObject.PeriodName;
        }
        else if (commandId === 'Ribbon.MyTimesheet.PopulateDelegate') {
            properties.PopulationXML = this.getDelegates();
        }
        else if (commandId === 'Ribbon.MyTimesheet.SelectColumns') {
            Grids["TS" + this.tsObject.id].ActionShowColumns();
        }
        else if (commandId === 'Ribbon.MyTimesheet.Save') {
            if (BeforeSave(Grids["TS" + this.tsObject.id])) {
                ShowMessage("TS" + this.tsObject.id, "Saving...", 100, 30);
                Grids["TS" + this.tsObject.id].Save();
            }
        }
        else if (commandId === 'Ribbon.MyTimesheet.AutoWork') {

            AutoAddWork(Grids["TS" + this.tsObject.id]);

        }
        else if (commandId === 'Ribbon.MyTimesheet.RemoveWork') {
            var grid = Grids["TS" + this.tsObject.id]

            if (grid.FRow.Def.Name == "R") {
                if (confirm("Are you sure you want to remove that item from your timesheet? This will also remove any related hours.")) {

                    grid.DeleteRow(grid.FRow, 2);
                    TimesheetHoursEdited = true;
                    //grid.HideRow(grid.FRow);
                }
            }
        }
        else if (commandId === 'Ribbon.MyTimesheet.Submit') {
            if (BeforeSubmit(Grids["TS" + this.tsObject.id])) {
                SubmitTimesheet("TS" + this.tsObject.id);
            }
        }
        else if (commandId === 'Ribbon.MyTimesheet.Unsubmit') {
            if (BeforeUnSubmit(Grids["TS" + this.tsObject.id])) {
                UnSubmitTimesheet("TS" + this.tsObject.id);
            }
        }
        else if (commandId === 'Ribbon.MyTimesheet.QueryStatus') {
            properties['Value'] = this.tsObject.Status
        }
        else if (commandId === 'Ribbon.MyTimesheet.ChangeDelegate') {
            try {
                var url = this.tsObject.TSURL;

                if (url.indexOf("?") > 0) {
                    url += "&Delegate=" + properties['CommandValueId'] + "&NewPeriod=" + this.tsObject.PeriodId;
                }
                else
                    url += "?Delegate=" + properties['CommandValueId'] + "&NewPeriod=" + this.tsObject.PeriodId;

                location.href = url;
            } catch (e) { }
        }
        else if (commandId === 'Ribbon.MyTimesheet.DelegateMy') {
            try {
                var url = this.tsObject.TSURL;

                if (url.indexOf("?") > 0) {
                    url += "&NewPeriod=" + this.tsObject.PeriodId;
                }
                else
                    url += "?NewPeriod=" + this.tsObject.PeriodId;

                location.href = url;
            } catch (e) { }
        }
        else if (commandId === 'Ribbon.MyTimesheet.ChangePeriod') {
            var url = this.tsObject.TSURL;

            if (url.indexOf("?") > 0) {
                url += "&NewPeriod=" + properties['CommandValueId'];
            }
            else
                url += "?NewPeriod=" + properties['CommandValueId'];

            if (this.tsObject.DelegateId != "") {
                url += "&Delegate=" + this.tsObject.DelegateId;
            }

            location.href = url;
        }
        else if (commandId === 'Ribbon.MyTimesheet.NextPeriod') {
            var url = this.tsObject.TSURL;

            if (url.indexOf("?") > 0) {
                url += "&NewPeriod=" + this.tsObject.NextPeriod;
            }
            else
                url += "?NewPeriod=" + this.tsObject.NextPeriod;

            if (this.tsObject.DelegateId != "") {
                url += "&Delegate=" + this.tsObject.DelegateId;
            }

            location.href = url;
        }
        else if (commandId === 'Ribbon.MyTimesheet.PreviousPeriod') {
            var url = this.tsObject.TSURL;

            if (url.indexOf("?") > 0) {
                url += "&NewPeriod=" + this.tsObject.PreviousPeriod;
            }
            else
                url += "?NewPeriod=" + this.tsObject.PreviousPeriod;

            if (this.tsObject.DelegateId != "") {
                url += "&Delegate=" + this.tsObject.DelegateId;
            }

            location.href = url;
        }
        else if (commandId === 'Ribbon.MyTimesheet.ShowHideFilters') {
            var grid = Grids["TS" + this.tsObject.id];
            if (grid.GetRowById("Filter").Visible)
                grid.HideRow(grid.GetRowById("Filter"));
            else
                grid.ShowRow(grid.GetRowById("Filter"));
        }
        else if (commandId === 'Ribbon.MyTimesheet.ShowHideFilters.Query') {
            var grid = Grids["TS" + this.tsObject.id];
            properties.On = grid.GetRowById("Filter").Visible;
        }
        else if (commandId === 'Ribbon.MyTimesheet.ShowHideGrouping') {
            var grid = Grids["TS" + this.tsObject.id];
            if (grid.GetRowById("Group").Visible)
                grid.HideRow(grid.GetRowById("Group"));
            else
                grid.ShowRow(grid.GetRowById("Group"));
        }
        else if (commandId === 'Ribbon.MyTimesheet.ShowHideGrouping.Query') {
            var grid = Grids["TS" + this.tsObject.id];
            properties.On = grid.GetRowById("Group").Visible;
        }
        else if (commandId === 'Ribbon.MyTimesheet.DeleteView') {
            var grid = Grids["TS" + this.tsObject.id];
            var newobj = eval("TSObject" + this.tsObject.id);

            if (Object.keys(newobj.Views).length == 1) {
                alert("You can not delete this view '" + this.tsObject.CurrentView + "'");
                return;
            }

            if (confirm("Are you sure you want to delete this view: " + this.tsObject.CurrentView + "?")) {
                DeleteView(grid, this.tsObject.CurrentView);
            }
        }
        else if (commandId === 'Ribbon.MyTimesheet.RenameView') {

            var grid = Grids["TS" + this.tsObject.id];

            viewNameDiv.style.display = "";

            viewNameDiv.firstChild.nextSibling.nextSibling.value = this.tsObject.CurrentView;

            viewNameDiv.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.style.display = "none";

            if (this.tsObject.Views[this.tsObject.CurrentViewId].Default.toLowerCase() == "true") {
                viewNameDiv.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.checked = true;
            }
            else
                viewNameDiv.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.checked = false;

            curGrid = grid;
            cView = this.tsObject.CurrentView;
            var options = { html: viewNameDiv, width: 250, height: 125, title: "Rename View", dialogReturnValueCallback: this.onRenameViewClose };
            SP.UI.ModalDialog.showModalDialog(options);
        }
        else if (commandId === 'Ribbon.MyTimesheet.SaveView') {

            var grid = Grids["TS" + this.tsObject.id];

            viewNameDiv.style.display = "";

            viewNameDiv.firstChild.nextSibling.nextSibling.value = this.tsObject.CurrentView;


            viewNameDiv.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.style.display = "";

            if (this.tsObject.Views[this.tsObject.CurrentViewId].Default.toLowerCase() == "true") {
                viewNameDiv.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.checked = true;
            }
            else
                viewNameDiv.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling.checked = false;

            curGrid = grid;

            var options = { html: viewNameDiv, width: 300, height: 150, title: "Save View", dialogReturnValueCallback: this.onSaveViewClose };
            SP.UI.ModalDialog.showModalDialog(options);
        }
        else if (commandId === 'Ribbon.MyTimesheet.ChangeView') {
            var grid = Grids["TS" + this.tsObject.id];
            ChangeView(grid, properties['CommandValueId'], "1");
        }
        else if (commandId === 'Ribbon.MyTimesheet.ClearSort') {
            var grid = Grids["TS" + this.tsObject.id];
            grid.ChangeSort("Title");
        }
        else if (commandId === 'Ribbon.MyTimesheet.AddWork') {

            var grid = Grids["TS" + this.tsObject.id];

            curGrid = grid;

            var surl = siteUrl + "/_layouts/epmlive/MyTimesheetAddWork.aspx?ID=" + grid.TimesheetUID;

            var options = { url: surl, showMaximized: true, title: "Add Work", dialogReturnValueCallback: this.onAddWorkClose, autoSize: false };

            SP.UI.ModalDialog.showModalDialog(options);
        }
        else if (commandId === 'Ribbon.MyTimesheet.AddNonWork') {

            var grid = Grids["TS" + this.tsObject.id];

            curGrid = grid;

            var surl = siteUrl + "/_layouts/epmlive/MyTimesheetAddWork.aspx?nonwork=true&ID=" + grid.TimesheetUID;

            var options = { url: surl, showMaximized: true, title: "Add Work", dialogReturnValueCallback: this.onAddWorkClose, autoSize: false };

            SP.UI.ModalDialog.showModalDialog(options);

        }
        else if (commandId === 'Ribbon.MyTimesheet.ApprovalsPM') {
            var grid = Grids["TS" + this.tsObject.id];

            curGrid = grid;

            var surl = siteColUrl + "/Lists/My%20Timesheet/Project%20Manager%20Approval.aspx";

            location.href = surl;

            //var options = { url: surl, showMaximized: true, title: "Approvals", autoSize: false };

            //SP.UI.ModalDialog.showModalDialog(options);
        }
        else if (commandId === 'Ribbon.MyTimesheet.ApprovalsTM') {
            var grid = Grids["TS" + this.tsObject.id];

            curGrid = grid;

            var surl = siteColUrl + "/_layouts/15/epmlive/mytimesheet.aspx?Approvals=true";

            location.href = surl;
        }

        return true;
    },

    onAddWorkClose: function (dialogResult, returnValue) {
        //        if (dialogResult == "1") {
        //            CheckForUpdate(curGrid);
        //        }
    },

    onSaveViewClose: function (dialogResult, returnValue) {
        if (dialogResult == "1") {
            var retval = returnValue.split('|');

            SaveView(curGrid, retval);
        }

    },

    onRenameViewClose: function (dialogResult, returnValue) {
        if (dialogResult == "1") {
            var retval = returnValue.split('|');

            RenameView(curGrid, cView, retval[0]);
        }

    },

    getViews: function () {
        var sb = new Sys.StringBuilder();
        sb.append('<Menu Id=\'COB.SharePoint.Ribbon.WithPageComponent.PCNotificationGroup.Dropdown.Menu\'>');
        sb.append('<MenuSection DisplayMode=\'Menu\' Id=\'COB.SharePoint.Ribbon.WithPageComponent.PCNotificationGroup.Dropdown.Menu.Manage\'>');
        sb.append('<Controls Id=\'COB.SharePoint.Ribbon.WithPageComponent.PCNotificationGroup.Dropdown.Menu.Manage.Controls\'>');

        var arrPeriods = this.tsObject.Periods.split(',');

        for (var v in this.tsObject.Views) {

            var oView = this.tsObject.Views[v];

            sb.append('<Button Id=\'Ribbon.MyTimesheet.ChangeView\' Command=\'Ribbon.MyTimesheet.ChangeView\' CommandValueId=\'' + v + '\' LabelText=\'' + oView.Name + '\' />');
        }

        sb.append('</Controls>');
        sb.append('</MenuSection>');
        sb.append('</Menu>');

        return sb.toString();
    },

    getPeriods: function () {
        var sb = new Sys.StringBuilder();
        sb.append('<Menu Id=\'COB.SharePoint.Ribbon.WithPageComponent.PCNotificationGroup.Dropdown.Menu\'>');
        sb.append('<MenuSection DisplayMode=\'Menu\' Id=\'COB.SharePoint.Ribbon.WithPageComponent.PCNotificationGroup.Dropdown.Menu.Manage\'>');
        sb.append('<Controls Id=\'COB.SharePoint.Ribbon.WithPageComponent.PCNotificationGroup.Dropdown.Menu.Manage.Controls\'>');

        var arrPeriods = this.tsObject.Periods.split(',');

        for (var i = 0; i < arrPeriods.length; i++) {
            var arrPeriod = arrPeriods[i].split('|');
            sb.append('<Button Id=\'Ribbon.MyTimesheet.Periods.ChangePeriod\' Command=\'Ribbon.MyTimesheet.ChangePeriod\' CommandValueId=\'' + arrPeriod[0] + '\' LabelText=\'' + arrPeriod[1] + '\' />');
        }

        sb.append('</Controls>');
        sb.append('</MenuSection>');
        sb.append('</Menu>');

        return sb.toString();
    },

    getDelegates: function () {
        var sb = new Sys.StringBuilder();
        sb.append('<Menu Id=\'COB.SharePoint.Ribbon.WithPageComponent.PCNotificationGroup.Dropdown.Menu\'>');
        sb.append('<MenuSection DisplayMode=\'Menu\' Id=\'COB.SharePoint.Ribbon.WithPageComponent.PCNotificationGroup.Dropdown.Menu.Manage\'>');
        sb.append('<Controls Id=\'COB.SharePoint.Ribbon.WithPageComponent.PCNotificationGroup.Dropdown.Menu.Manage.Controls\'>');

        var arrPeriods = this.tsObject.Delegates.split('^');

        for (var i = 0; i < arrPeriods.length; i++) {
            var arrPeriod = arrPeriods[i].split('|');
            sb.append('<Button Id=\'Ribbon.MyTimesheet.ChangeDelegate\' Command=\'Ribbon.MyTimesheet.ChangeDelegate\' CommandValueId=\'' + arrPeriod[0] + '\' LabelText=\'' + arrPeriod[1] + '\' />');
        }

        sb.append('</Controls>');
        sb.append('</MenuSection>');
        sb.append('</Menu>');

        return sb.toString();
    },


    receiveFocus: function () {
        return true;
    },

    yieldFocus: function () {
        return true;
    },

    getId: function ContextualTabWebPart_CustomPageComponent$getId() {
        return this._webPartPageComponentId;
    }
};

ContextualTabWebPart.CustomPageComponent.registerClass('ContextualTabWebPart.CustomPageComponent', CUI.Page.PageComponent);
SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs("MyTimesheetContextualTabPageComponent.js");