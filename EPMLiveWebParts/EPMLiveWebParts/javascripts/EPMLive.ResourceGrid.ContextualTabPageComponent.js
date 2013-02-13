/// <version>4.3.672012</version>
/// <reference path="EPMLive.ResourceGrid.js" />

window.Type.registerNamespace('ContextualTabWebPart');

var _webPartPageComponentId;

ContextualTabWebPart.CustomPageComponent = function ContextualTabWebPart_CustomPageComponent(webPartPcId, gridId) {
    this._webPartPageComponentId = webPartPcId;
    this.$gridId = gridId;

    ContextualTabWebPart.CustomPageComponent.initializeBase(this);
};

ContextualTabWebPart.CustomPageComponent.prototype = {
    $gridId: null,

    init: function ContextualTabWebPart_CustomPageComponent$init() { },

    getFocusedCommands: function ContextualTabWebPart_CustomPageComponent$getFocusedCommands() {
        return ['ResourceGridContextualTab.EnableResourceGridTab',
            'ResourceGridContextualTab.EnableResourceGridViewTab',
            'ResourceGridContextualTab.EnableResourceGridGroupNew',
            'ResourceGridContextualTab.EnableResourceGridGroupManage',
            'ResourceGridContextualTab.EnableResourceGridGroupActions',
            'ResourceGridContextualTab.EnableResourceGridGroupViews',
            'ResourceGridContextualTab.EnableResourceGridGroupPlan',
            'ResourceGridContextualTab.EnableResourceGridGroupAnalyze',
            'ResourceGridContextualTab.EnableResourceGridGroupReporting',
            'ResourceGrid.Cmd.NewItem',
            'ResourceGrid.Cmd.ViewItem',
            'ResourceGrid.Cmd.EditItem',
            'ResourceGrid.Cmd.VersionHistory',
            'ResourceGrid.Cmd.ItemPermissions',
            'ResourceGrid.Cmd.DeleteItem',
            'ResourceGrid.Cmd.Comments',
            'ResourceGrid.Cmd.SaveView',
            'ResourceGrid.Cmd.RenameView',
            'ResourceGrid.Cmd.DeleteView',
            'ResourceGrid.Cmd.CurrentViewDropDown.Select',
            'ResourceGrid.Cmd.SelectColoumns',
            'ResourceGrid.Cmd.ShowHideFilters',
            'ResourceGrid.Cmd.ShowHideGrouping',
            'ResourceGrid.Cmd.ClearSort',
            'ResourceGrid.Cmd.AnalyzeResources',
            'ResourceGrid.Cmd.PlanAssignments',
            'ResourceGrid.Cmd.AttachFile',
            'ResourceGrid.Cmd.ViewProfile',
            'ResourceGrid.Cmd.Find',
            'ResourceGrid.Cmd.Find.Query',
            'ResourceGrid.Cmd.SendNotification',
            'ResourceGrid.Cmd.ReportingWorkVsCapacity',
            'ResourceGrid.Cmd.ReportsDropDown.Select',
            'ResourceGrid.Cmd.ReportsDropDown.Populate',
            'ResourceGrid.Cmd.ReportsDropDown.Query',
            'ResourceGrid.Cmd.MyResources',
            'ResourceGrid.Cmd.MyResources.Query',
            'ResourceGrid.Cmd.EditResourcePlan'];
    },

    getGlobalCommands: function ContextualTabWebPart_CustomPageComponent$getGlobalCommands() {
        return ['ResourceGrid.Cmd.CurrentViewDropDown.Select',
                'ResourceGrid.Cmd.CurrentViewDropDown.Populate',
                'ResourceGrid.Cmd.CurrentViewDropDown.Query',
                'ResourceGrid.Cmd.ReportsDropDown.Select',
                'ResourceGrid.Cmd.ReportsDropDown.Populate',
                'ResourceGrid.Cmd.ReportsDropDown.Query',
                'ResourceGrid.Cmd.Find.Query',
                'ResourceGrid.Cmd.MyResources.Query',
                'ResourceGrid.Cmd.ShowHideFilters.Query',
                'ResourceGrid.Cmd.ShowHideGrouping.Query'];
    },

    isFocusable: function ContextualTabWebPart_CustomPageComponent$isFocusable() {
        return true;
    },

    canHandleCommand: function ContextualTabWebPart_CustomPageComponent$canHandleCommand(commandId) {
        var $$ = window.epmLiveResourceGrid;
        $$.id(this.$gridId);

        switch (commandId) {
            case 'ResourceGridContextualTab.EnableResourceGridTab':
            case 'ResourceGridContextualTab.EnableResourceGridViewTab':
            case 'ResourceGridContextualTab.EnableResourceGridGroupNew':
            case 'ResourceGridContextualTab.EnableResourceGridGroupManage':
            case 'ResourceGridContextualTab.EnableResourceGridGroupActions':
            case 'ResourceGridContextualTab.EnableResourceGridGroupViews':
            case 'ResourceGridContextualTab.EnableResourceGridGroupPlan':
            case 'ResourceGridContextualTab.EnableResourceGridGroupAnalyze':
            case 'ResourceGridContextualTab.EnableResourceGridGroupReporting':
            case 'ResourceGrid.Cmd.NewItem':
            case 'ResourceGrid.Cmd.SaveView':
            case 'ResourceGrid.Cmd.RenameView':
            case 'ResourceGrid.Cmd.DeleteView':
            case 'ResourceGrid.Cmd.CurrentViewDropDown.Select':
            case 'ResourceGrid.Cmd.CurrentViewDropDown.Populate':
            case 'ResourceGrid.Cmd.CurrentViewDropDown.Query':
            case 'ResourceGrid.Cmd.SelectColoumns':
            case 'ResourceGrid.Cmd.ShowHideFilters':
            case 'ResourceGrid.Cmd.ShowHideFilters.Query':
            case 'ResourceGrid.Cmd.ShowHideGrouping':
            case 'ResourceGrid.Cmd.ShowHideGrouping.Query':
            case 'ResourceGrid.Cmd.ClearSort':
            case 'ResourceGrid.Cmd.Find':
            case 'ResourceGrid.Cmd.Find.Query':
            case 'ResourceGrid.Cmd.MyResources':
            case 'ResourceGrid.Cmd.MyResources.Query':
                return true;
            case 'ResourceGrid.Cmd.ViewItem':
            case 'ResourceGrid.Cmd.EditItem':
            case 'ResourceGrid.Cmd.DeleteItem':
            case 'ResourceGrid.Cmd.VersionHistory':
            case 'ResourceGrid.Cmd.ItemPermissions':
            case 'ResourceGrid.Cmd.Comments':
            case 'ResourceGrid.Cmd.AttachFile':
            case 'ResourceGrid.Cmd.ViewProfile':
                return $$.grid.rowsSelected() === 1;
            case 'ResourceGrid.Cmd.AnalyzeResources':
            case 'ResourceGrid.Cmd.EditResourcePlan':
                return $$.grid.rowsSelected() >= 1 && $$.pfeInstalled;
            case 'ResourceGrid.Cmd.PlanAssignments':
            case 'ResourceGrid.Cmd.SendNotification':
            case 'ResourceGrid.Cmd.ReportingWorkVsCapacity':
            case 'ResourceGrid.Cmd.ReportsDropDown.Select':
            case 'ResourceGrid.Cmd.ReportsDropDown.Query':
            case 'ResourceGrid.Cmd.ReportsDropDown.Populate':
                return $$.grid.rowsSelected() >= 1;
            default:
                return false;
        }
    },

    handleCommand: function ContextualTabWebPart_CustomPageComponent$handleCommand(commandId, properties, sequence) {
        var $$ = window.epmLiveResourceGrid;
        $$.id(this.$gridId);

        if (commandId === 'ResourceGrid.Cmd.SelectColoumns') { $$.grid.showColumnSelector(); }

        else if (commandId === 'ResourceGrid.Cmd.SaveView') { $$.views.showSaveDialog(); }
        else if (commandId === 'ResourceGrid.Cmd.DeleteView') { $$.views.remove(); }
        else if (commandId === 'ResourceGrid.Cmd.RenameView') { $$.views.showRenameDialog(); }
        else if (commandId === 'ResourceGrid.Cmd.CurrentViewDropDown.Query') {
            var currentView = $$.views.currentView;

            if (currentView) {
                properties['Value'] = currentView.name;
            } else {
                $$.views.load();
            }
        } else if (commandId === 'ResourceGrid.Cmd.CurrentViewDropDown.Populate') {
            properties.PopulationXML = $$.views.getXmlForRibbon();
        } else if (commandId === 'ResourceGrid.Cmd.CurrentViewDropDown.Select') {
            $$.views.apply(properties['CommandValueId']);
        }

        else if (commandId === 'ResourceGrid.Cmd.ShowHideFilters') { properties.On = $$.grid.toggleFiltering(); }
        else if (commandId === 'ResourceGrid.Cmd.ShowHideFilters.Query') { properties.On = $$.grid.filteringOn; }

        else if (commandId === 'ResourceGrid.Cmd.ShowHideGrouping') { properties.On = $$.grid.toggleGrouping(); }
        else if (commandId === 'ResourceGrid.Cmd.ShowHideGrouping.Query') { properties.On = $$.grid.groupingOn; }

        else if (commandId === 'ResourceGrid.Cmd.MyResources') { properties.On = $$.actions.toggleMyResources(); }
        else if (commandId === 'ResourceGrid.Cmd.MyResources.Query') { properties.On = $$.actions.myResourcesOn; }

        else if (commandId === 'ResourceGrid.Cmd.Find') {
            properties.On = $$.actions.toggleEasyScroll();
        } else if (commandId === 'ResourceGrid.Cmd.Find.Query') {
            properties.On = $$.actions.easyScrollOn;
        }

        else if (commandId === 'ResourceGrid.Cmd.ClearSort') { properties.On = $$.grid.removeSorting(); }

        else if (commandId === 'ResourceGrid.Cmd.AnalyzeResources') { $$.actions.analyzeResources(); }
        else if (commandId === 'ResourceGrid.Cmd.EditResourcePlan') { $$.actions.loadResourcePlanner(); }
        else if (commandId === 'ResourceGrid.Cmd.PlanAssignments') { $$.actions.loadAssignmentPlanner(); }

        else if (commandId === 'ResourceGrid.Cmd.NewItem') { $$.actions.redirect('add'); }
        else if (commandId === 'ResourceGrid.Cmd.ViewItem') { $$.actions.redirect('view'); }
        else if (commandId === 'ResourceGrid.Cmd.EditItem') { $$.actions.redirect('edit'); }
        else if (commandId === 'ResourceGrid.Cmd.DeleteItem') { $$.actions.deleteResource(); }

        else if (commandId === 'ResourceGrid.Cmd.AttachFile') { $$.actions.redirect('attachfile'); }
        else if (commandId === 'ResourceGrid.Cmd.Comments') { $$.actions.redirect('showcomments'); }
        else if (commandId === 'ResourceGrid.Cmd.ViewProfile') { $$.actions.redirect('viewprofile'); }
        else if (commandId === 'ResourceGrid.Cmd.SendNotification') { $$.actions.redirect('sendnotification'); }

        else if (commandId === 'ResourceGrid.Cmd.VersionHistory') { $$.actions.redirect('version'); }
        else if (commandId === 'ResourceGrid.Cmd.ItemPermissions') { $$.actions.redirect('perms'); }

        else if (commandId === 'ResourceGrid.Cmd.ReportingWorkVsCapacity') { $$.reports.open('workvscapacity'); }

        else if (commandId === 'ResourceGrid.Cmd.ReportsDropDown.Populate') {
            properties.PopulationXML = $$.reports.getXmlForRibbon();
        } else if (commandId === 'ResourceGrid.Cmd.ReportsDropDown.Select') {
            if (!$$.reports.opened) {
                $$.reports.open(properties['CommandValueId']);
            }
        }
        else if (commandId === 'ResourceGrid.Cmd.ReportsDropDown.Query') { properties['Value'] = '(Select a report)'; }

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

ContextualTabWebPart.CustomPageComponent.registerClass('ContextualTabWebPart.CustomPageComponent', window.CUI.Page.PageComponent);
window.SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs("EPMLive.ResourceGrid.ContextualTabPageComponent.js");