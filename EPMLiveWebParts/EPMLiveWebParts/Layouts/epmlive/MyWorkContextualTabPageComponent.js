Type.registerNamespace('ContextualTabWebPart');

var _webPartPageComponentId;

ContextualTabWebPart.CustomPageComponent = function ContextualTabWebPart_CustomPageComponent(webPartPcId, allWorkGridId, workingOnGridId) {
    this._webPartPageComponentId = webPartPcId;
    
    this.$allWorkGridId = allWorkGridId;
    this.$workingOnGridId = workingOnGridId;

    ContextualTabWebPart.CustomPageComponent.initializeBase(this);
};

ContextualTabWebPart.CustomPageComponent.prototype = {

    $allWorkGridId: null,
    $workingOnGridId: null,

    init: function ContextualTabWebPart_CustomPageComponent$init() { },

    getFocusedCommands: function ContextualTabWebPart_CustomPageComponent$getFocusedCommands() {
        return ['MyWorkContextualTab.EnableMyWorkTab',
        'MyWorkContextualTab.EnableMyWorkGroupNew',
        'MyWork.Cmd.NewItem',
        'MyWorkContextualTab.EnableMyWorkGroupManage',
        'MyWork.Cmd.ViewItem',
        'MyWork.Cmd.EditItem',
        'MyWork.Cmd.Comments',
        'MyWorkContextualTab.EnableMyWorkGroupViews',
        'MyWork.Cmd.SaveView',
        'MyWork.Cmd.RenameView',
        'MyWork.Cmd.DeleteView',
        'MyWork.Cmd.CurrentViewDropDown.Select',
        'MyWork.Cmd.SelectColoumns',
        'MyWork.Cmd.ShowHideFilters',
        'MyWork.Cmd.ShowHideGrouping',
        'MyWork.Cmd.ShowHideCompletedItems',
        'MyWork.Cmd.ClearSort',
        'MyWork.Cmd.Search',
        'MyWorkContextualTab.EnableMyWorkGroupShareTrack',
        'MyWorkContextualTab.EnableMyWorkGroupActions',
        'MyWorkContextualTab.EnableMyWorkGroupWorkFilter',
        'MyWork.Cmd.ShowMe',
        'MyWork.Cmd.ShowMe.Flyout',
        'MyWork.Cmd.ShowMe.WorkType',
        'MyWork.Cmd.ShowMe.CreatedBy',
        'MyWork.Cmd.ShowMe.Priority',
        'MyWork.Cmd.ShowMe.Status',
        'MyWork.Cmd.ShowMe.Flag',
        'MyWork.Cmd.ShowMe.Due',
        'MyWork.Cmd.ShowMe.Clear',
        'MyWork.Cmd.DueAgo',
        'MyWork.Cmd.DueAgoDays',
        'MyWork.Cmd.DueAfter',
        'MyWork.Cmd.DueAfterDays',
        'MyWork.Cmd.AlertMe'];
    },

    getGlobalCommands: function ContextualTabWebPart_CustomPageComponent$getGlobalCommands() {
        return ['MyWork.Cmd.CurrentViewDropDown.Select',
        'MyWork.Cmd.CurrentViewDropDown.Populate',
        'MyWork.Cmd.CurrentViewDropDown.Query',
        'MyWork.Cmd.ShowHideFilters.Query',
        'MyWork.Cmd.ShowHideGrouping.Query',
        'MyWork.Cmd.ShowHideCompletedItems.Query',
        'MyWork.Cmd.ShowMe.Populate',
        'MyWork.Cmd.Search.Query',
        'MyWork.Cmd.DueAgo.Query',
        'MyWork.Cmd.DueAgoDays.Query',
        'MyWork.Cmd.DueAfter.Query',
        'MyWork.Cmd.DueAfterDays.Query',
        'MyWork.Cmd.NewItem.Populate'];
    },

    isFocusable: function ContextualTabWebPart_CustomPageComponent$isFocusable() {
        return true;
    },

    canHandleCommand: function ContextualTabWebPart_CustomPageComponent$canHandleCommand(commandId) {
        //Contextual Tab commands

        MyWorkGrid.configureRibbon();

        //        if (!window.epmLiveWorkCenter || MyWorkGrid.gridId !== window.epmLiveWorkCenter.activeGrid()) {
        //            return false;
        //        }

        switch (commandId) {
            case 'MyWork.Cmd.NewItem':
            case 'MyWork.Cmd.NewItem.Populate':
                return MyWorkGrid.canHandleNewItemRibbonCommand();
            case 'MyWork.Cmd.ViewItem':
            case 'MyWork.Cmd.EditItem':
            case 'MyWork.Cmd.Comments':
            case 'MyWork.Cmd.AlertMe':
                return MyWorkGrid.canHandleRibbonCommand();
            case 'MyWork.Cmd.DueAgoDays':
            case 'MyWork.Cmd.DueAgoDays.Query':
                return MyWorkGrid.canHandleDueCommand('ago');
            case 'MyWork.Cmd.DueAfterDays':
            case 'MyWork.Cmd.DueAfterDays.Query':
                return MyWorkGrid.canHandleDueCommand('after');
            case 'MyWorkContextualTab.EnableMyWorkTab':
            case 'MyWorkContextualTab.EnableMyWorkGroupNew':
            case 'MyWorkContextualTab.EnableMyWorkGroupManage':
            case 'MyWorkContextualTab.EnableMyWorkGroupShareTrack':
            case 'MyWorkContextualTab.EnableMyWorkGroupViews':
            case 'MyWorkContextualTab.EnableMyWorkGroupActions':
            case 'MyWorkContextualTab.EnableMyWorkGroupWorkFilter':
            case 'MyWork.Cmd.SaveView':
            case 'MyWork.Cmd.RenameView':
            case 'MyWork.Cmd.DeleteView':
            case 'MyWork.Cmd.CurrentViewDropDown.Select':
            case 'MyWork.Cmd.CurrentViewDropDown.Populate':
            case 'MyWork.Cmd.CurrentViewDropDown.Query':
            case 'MyWork.Cmd.SelectColoumns':
            case 'MyWork.Cmd.ShowHideFilters':
            case 'MyWork.Cmd.ShowHideFilters.Query':
            case 'MyWork.Cmd.ShowHideGrouping':
            case 'MyWork.Cmd.ShowHideGrouping.Query':
            case 'MyWork.Cmd.ShowHideCompletedItems':
            case 'MyWork.Cmd.ShowHideCompletedItems.Query':
            case 'MyWork.Cmd.ClearSort':
            case 'MyWork.Cmd.Search':
            case 'MyWork.Cmd.Search.Query':
            case 'MyWork.Cmd.ShowMe':
            case 'MyWork.Cmd.ShowMe.Flyout':
            case 'MyWork.Cmd.ShowMe.WorkType':
            case 'MyWork.Cmd.ShowMe.CreatedBy':
            case 'MyWork.Cmd.ShowMe.Priority':
            case 'MyWork.Cmd.ShowMe.Status':
            case 'MyWork.Cmd.ShowMe.Flag':
            case 'MyWork.Cmd.ShowMe.Due':
            case 'MyWork.Cmd.ShowMe.Clear':
            case 'MyWork.Cmd.ShowMe.Populate':
            case 'MyWork.Cmd.DueAgo':
            case 'MyWork.Cmd.DueAgo.Query':
            case 'MyWork.Cmd.DueAfter':
            case 'MyWork.Cmd.DueAfter.Query':
                return true;
            default:
                return false;
        }
    },

    handleCommand: function ContextualTabWebPart_CustomPageComponent$handleCommand(commandId, properties, sequence) {
        MyWorkGrid.gridId = this.$allWorkGridId;

        if (commandId === 'MyWork.Cmd.ViewItem') { doActionOnItem(this.$allWorkGridId, 'view'); }

        else if (commandId === 'MyWork.Cmd.EditItem') { doActionOnItem(this.$allWorkGridId, 'edit'); }

        else if (commandId === 'MyWork.Cmd.Comments') { doActionOnItem(this.$allWorkGridId, 'comments'); }

        else if (commandId === 'MyWork.Cmd.AlertMe') { doActionOnItem(this.$allWorkGridId, 'subscribe'); }

        else if (commandId === 'MyWork.Cmd.ClearCompletedItems') { doActionOnItem(this.$allWorkGridId, 'clear-completed'); }

        else if (commandId === 'MyWork.Cmd.SelectColoumns') { MyWorkGrid.showSelectColoumnsDialog(); }

        else if (commandId === 'MyWork.Cmd.SaveView') { MyWorkGrid.saveView(); }

        else if (commandId === 'MyWork.Cmd.CurrentViewDropDown.Query') {
            if (MyWorkGrid.viewsLoaded) {
                properties['Value'] = MyWorkGrid.defaultView;
            } else { MyWorkGrid.loadViews(); }

            return true;
        }

        else if (commandId === 'MyWork.Cmd.CurrentViewDropDown.Populate') {
            properties.PopulationXML = MyWorkGrid.populateViews();

            return true;
        }

        else if (commandId === 'MyWork.Cmd.CurrentViewDropDown.Select') {
            MyWorkGrid.applyView(properties['CommandValueId']);
        }

        else if (commandId === 'MyWork.Cmd.RenameView') { MyWorkGrid.renameView(); }

        else if (commandId === 'MyWork.Cmd.DeleteView') { MyWorkGrid.deleteView(); }

        else if (commandId === 'MyWork.Cmd.ShowHideFilters') { properties.On = MyWorkGrid.toggleFilters(); }

        else if (commandId === 'MyWork.Cmd.ShowHideFilters.Query') {
            properties.On = MyWorkGrid.filtersOn;
        }

        else if (commandId === 'MyWork.Cmd.ShowHideGrouping') { properties.On = MyWorkGrid.toggleGrouping(); }

        else if (commandId === 'MyWork.Cmd.ShowHideGrouping.Query') {
            properties.On = MyWorkGrid.groupingOn;
        }

        else if (commandId === 'MyWork.Cmd.ClearSort') { MyWorkGrid.clearSort(); }

        else if (commandId === 'MyWork.Cmd.ShowHideCompletedItems') { properties.On = MyWorkGrid.toggleCompletedItems(); }

        else if (commandId === 'MyWork.Cmd.ShowHideCompletedItems.Query') {
            properties.On = MyWorkGrid.showingCompletedItems;
        }

        else if (commandId === 'MyWork.Cmd.NewItem.Populate') {
            properties.PopulationXML = MyWorkGrid.populateNewItemListButton();

            return true;
        }

        else if (commandId === 'MyWork.Cmd.NewItem') {
            MyWorkGrid.addNewItem(properties['CommandValueId']);
        }

        else if (commandId === 'MyWork.Cmd.Search.Query') {
            properties['Value'] = $('#Ribbon_MyWork_Actions_Search').val();
        }

        else if (commandId === 'MyWork.Cmd.ShowMe.Populate') {
            properties.PopulationXML = MyWorkGrid.populateShowMe();

            return true;
        }

        else if (commandId === 'MyWork.Cmd.ShowMe.WorkType') {
            MyWorkGrid.filter(properties['CommandValueId'], 'Work0000Type');
        }

        else if (commandId === 'MyWork.Cmd.ShowMe.CreatedBy') {
            MyWorkGrid.filter(properties['CommandValueId'], 'Author');
        }

        else if (commandId === 'MyWork.Cmd.ShowMe.Priority') {
            MyWorkGrid.filter(properties['CommandValueId'], 'Priority');
        }

        else if (commandId === 'MyWork.Cmd.ShowMe.Status') {
            MyWorkGrid.filter(properties['CommandValueId'], 'StatusFC');
        }

        else if (commandId === 'MyWork.Cmd.ShowMe.Flag') {
            MyWorkGrid.filter(properties['CommandValueId'] === 'Flagged' ? 1 : 0, 'Flag');
        }

        else if (commandId === 'MyWork.Cmd.ShowMe.Due') {
            MyWorkGrid.filter(properties['CommandValueId'], 'Due');
        }

        else if (commandId === 'MyWork.Cmd.ShowMe.Clear') {
            MyWorkGrid.clearFilter();
        }

        else if (commandId === 'MyWork.Cmd.DueAgo') {
            MyWorkGrid.updateWorkFilter('ago', properties.On);
        }

        else if (commandId === 'MyWork.Cmd.DueAgo.Query') {
            properties.On = MyWorkGrid.workFilters.daysAgoEnabled;
        }

        else if (commandId === 'MyWork.Cmd.DueAfter') {
            MyWorkGrid.updateWorkFilter('after', properties.On);
        }

        else if (commandId === 'MyWork.Cmd.DueAfter.Query') {
            properties.On = MyWorkGrid.workFilters.daysAfterEnabled;
        }

        else if (commandId === 'MyWork.Cmd.DueAgoDays') {
            MyWorkGrid.updateWorkFilter('agodays', properties['Value']);
        }

        else if (commandId === 'MyWork.Cmd.DueAgoDays.Query') {
            properties['Value'] = MyWorkGrid.workFilters.daysAgo;
        }
        
        else if (commandId === 'MyWork.Cmd.DueAfterDays') {
            MyWorkGrid.updateWorkFilter('afterdays', properties['Value']);
        }

        else if (commandId === 'MyWork.Cmd.DueAfterDays.Query') {
            properties['Value'] = MyWorkGrid.workFilters.daysAfter;
        }

        return true;
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
SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs("MyWorkContextualTabPageComponent.js");