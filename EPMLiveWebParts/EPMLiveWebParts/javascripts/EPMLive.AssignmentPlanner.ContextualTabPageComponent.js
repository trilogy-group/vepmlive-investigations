/// <version>4.3.1</version>
/// <reference path="~/javascripts/EPMLive.AssignmentPlanner.js" />

window.Type.registerNamespace('ContextualTabWebPart');

ContextualTabWebPart.CustomPageComponent = function ContextualTabWebPart_CustomPageComponent() {
    ContextualTabWebPart.CustomPageComponent.initializeBase(this);
};

ContextualTabWebPart.CustomPageComponent.prototype = {
    init: function ContextualTabWebPart_CustomPageComponent$init() {
        try {
            window.epmLiveAssignmentPlanner.actions.setFromTo();
        } catch (e) { }
    },

    getFocusedCommands: function ContextualTabWebPart_CustomPageComponent$getFocusedCommands() {
        return ['AssignmentPlannerContextualTab.EnableAssignmentPlannerTab',
            'AssignmentPlannerContextualTab.EnableAssignmentPlannerGroupShare',
            'AssignmentPlannerContextualTab.EnableAssignmentPlannerGroupManage',
            'AssignmentPlannerContextualTab.EnableAssignmentPlannerGroupActions',
            'AssignmentPlannerContextualTab.EnableAssignmentPlannerGroupViews',
            'AssignmentPlannerContextualTab.EnableAssignmentPlannerGroupGantt',
            'AssignmentPlannerContextualTab.EnableAssignmentPlannerGroupModel',
            'AssignmentPlanner.Cmd.Close',
            'AssignmentPlanner.Cmd.SelectResources',
            'AssignmentPlanner.Cmd.Publish',
            'AssignmentPlanner.Cmd.ExportExcel',
            'AssignmentPlanner.Cmd.Print',
            'AssignmentPlanner.Cmd.Export',
            'AssignmentPlanner.Cmd.AlertMe',
            'AssignmentPlanner.Cmd.ViewItem',
            'AssignmentPlanner.Cmd.EditItem',
            'AssignmentPlanner.Cmd.Comments',
            'AssignmentPlanner.Cmd.Reassign',
            'AssignmentPlanner.Cmd.SaveView',
            'AssignmentPlanner.Cmd.RenameView',
            'AssignmentPlanner.Cmd.DeleteView',
            'AssignmentPlanner.Cmd.CurrentViewDropDown.Select',
            'AssignmentPlanner.Cmd.SelectColoumns',
            'AssignmentPlanner.Cmd.ShowHideFilters',
            'AssignmentPlanner.Cmd.ShowHideGrouping',
            'AssignmentPlanner.Cmd.ClearSort',
            'AssignmentPlanner.Cmd.From',
            'AssignmentPlanner.Cmd.To',
            'AssignmentPlanner.Cmd.ZoomIn',
            'AssignmentPlanner.Cmd.ZoomOut',
            'AssignmentPlanner.Cmd.ZoomToFit',
            'AssignmentPlanner.Cmd.ScrollTo',
            'AssignmentPlanner.Cmd.SaveModel',
            'AssignmentPlanner.Cmd.OpenModel',
            'AssignmentPlanner.Cmd.ClearModel'];
    },

    getGlobalCommands: function ContextualTabWebPart_CustomPageComponent$getGlobalCommands() {
        return ['AssignmentPlanner.Cmd.CurrentViewDropDown.Select',
                'AssignmentPlanner.Cmd.CurrentViewDropDown.Populate',
                'AssignmentPlanner.Cmd.CurrentViewDropDown.Query',
                'AssignmentPlanner.Cmd.ShowHideFilters.Query',
                'AssignmentPlanner.Cmd.ShowHideGrouping.Query'];
    },

    isFocusable: function ContextualTabWebPart_CustomPageComponent$isFocusable() {
        return true;
    },

    canHandleCommand: function ContextualTabWebPart_CustomPageComponent$canHandleCommand(commandId) {
        var $$ = window.epmLiveAssignmentPlanner;

        if (!$$.grid.g) return false;

        switch (commandId) {
            case 'AssignmentPlannerContextualTab.EnableAssignmentPlannerTab':
            case 'AssignmentPlannerContextualTab.EnableAssignmentPlannerGroupShare':
            case 'AssignmentPlannerContextualTab.EnableAssignmentPlannerGroupManage':
            case 'AssignmentPlannerContextualTab.EnableAssignmentPlannerGroupActions':
            case 'AssignmentPlannerContextualTab.EnableAssignmentPlannerGroupViews':
            case 'AssignmentPlannerContextualTab.EnableAssignmentPlannerGroupGantt':
            case 'AssignmentPlannerContextualTab.EnableAssignmentPlannerGroupModel':
            case 'AssignmentPlanner.Cmd.Close':
            case 'AssignmentPlanner.Cmd.SelectResources':
            case 'AssignmentPlanner.Cmd.ExportExcel':
            case 'AssignmentPlanner.Cmd.Print':
            case 'AssignmentPlanner.Cmd.Export':
            case 'AssignmentPlanner.Cmd.SaveView':
            case 'AssignmentPlanner.Cmd.RenameView':
            case 'AssignmentPlanner.Cmd.DeleteView':
            case 'AssignmentPlanner.Cmd.SelectColoumns':
            case 'AssignmentPlanner.Cmd.ShowHideFilters':
            case 'AssignmentPlanner.Cmd.ShowHideGrouping':
            case 'AssignmentPlanner.Cmd.ClearSort':
            case 'AssignmentPlanner.Cmd.From':
            case 'AssignmentPlanner.Cmd.To':
            case 'AssignmentPlanner.Cmd.ZoomToFit':
            case 'AssignmentPlanner.Cmd.ScrollTo':
            case 'AssignmentPlanner.Cmd.SaveModel':
            case 'AssignmentPlanner.Cmd.OpenModel':
            case 'AssignmentPlanner.Cmd.ClearModel':
            case 'AssignmentPlanner.Cmd.CurrentViewDropDown.Select':
            case 'AssignmentPlanner.Cmd.CurrentViewDropDown.Populate':
            case 'AssignmentPlanner.Cmd.CurrentViewDropDown.Query':
            case 'AssignmentPlanner.Cmd.ShowHideFilters.Query':
            case 'AssignmentPlanner.Cmd.ShowHideGrouping.Query':
                return true;
            case 'AssignmentPlanner.Cmd.Publish':
                return $$.grid.hasChanges();
            case 'AssignmentPlanner.Cmd.ZoomIn':
                return $$.grid.canZoomIn();
            case 'AssignmentPlanner.Cmd.ZoomOut':
                return $$.grid.canZoomOut();
            case 'AssignmentPlanner.Cmd.AlertMe':
            case 'AssignmentPlanner.Cmd.ViewItem':
            case 'AssignmentPlanner.Cmd.EditItem':
            case 'AssignmentPlanner.Cmd.Comments':
            case 'AssignmentPlanner.Cmd.Reassign':
                return $$.grid.totalRowsSelected() === 1;
            default:
                return false;
        }
    },

    handleCommand: function ContextualTabWebPart_CustomPageComponent$handleCommand(commandId, properties, sequence) {
        var $$ = window.epmLiveAssignmentPlanner;

        if (!$$.grid.g) return true;

        if (commandId === 'AssignmentPlanner.Cmd.SelectResources') { $$.actions.close(); }
        else if (commandId === 'AssignmentPlanner.Cmd.Close') { $$.actions.close(); }

        else if (commandId === 'AssignmentPlanner.Cmd.Publish') { $$.actions.publish(); }

        else if (commandId === 'AssignmentPlanner.Cmd.Print') { $$.actions.print(); }
        else if (commandId === 'AssignmentPlanner.Cmd.ExportExcel') { $$.actions.exportExcel(); }
        else if (commandId === 'AssignmentPlanner.Cmd.AlertMe') { $$.actions.redirect('alertme'); }

        else if (commandId === 'AssignmentPlanner.Cmd.ViewItem') { $$.actions.redirect('view'); }
        else if (commandId === 'AssignmentPlanner.Cmd.EditItem') { $$.actions.redirect('edit'); }
        else if (commandId === 'AssignmentPlanner.Cmd.Comments') { $$.actions.redirect('showcomments'); }

        else if (commandId === 'AssignmentPlanner.Cmd.SelectColoumns') { $$.grid.showColumnSelector(); }

        else if (commandId === 'AssignmentPlanner.Cmd.SaveView') { $$.views.showSaveDialog(); }
        else if (commandId === 'AssignmentPlanner.Cmd.DeleteView') { $$.views.remove(); }
        else if (commandId === 'AssignmentPlanner.Cmd.RenameView') { $$.views.showRenameDialog(); }
        else if (commandId === 'AssignmentPlanner.Cmd.CurrentViewDropDown.Query') {
            var currentView = $$.views.currentView;

            if (currentView) {
                properties['Value'] = currentView.name;
            }
        } else if (commandId === 'AssignmentPlanner.Cmd.CurrentViewDropDown.Populate') {
            properties.PopulationXML = $$.views.getXmlForRibbon();
        } else if (commandId === 'AssignmentPlanner.Cmd.CurrentViewDropDown.Select') {
            $$.views.apply(properties['CommandValueId']);
        }

        else if (commandId === 'AssignmentPlanner.Cmd.ShowHideFilters') { properties.On = $$.grid.toggleFiltering(); }
        else if (commandId === 'AssignmentPlanner.Cmd.ShowHideFilters.Query') { properties.On = $$.grid.filteringOn; }

        else if (commandId === 'AssignmentPlanner.Cmd.ShowHideGrouping') { properties.On = $$.grid.toggleGrouping(); }
        else if (commandId === 'AssignmentPlanner.Cmd.ShowHideGrouping.Query') { properties.On = $$.grid.groupingOn; }

        else if (commandId === 'AssignmentPlanner.Cmd.ClearSort') { properties.On = $$.grid.removeSorting(); }

        else if (commandId === 'AssignmentPlanner.Cmd.From') { $$.actions.updateDateRange('From'); }
        else if (commandId === 'AssignmentPlanner.Cmd.To') { $$.actions.updateDateRange('To'); }

        else if (commandId === 'AssignmentPlanner.Cmd.ZoomIn') { properties.On = $$.grid.zoomIn(); }
        else if (commandId === 'AssignmentPlanner.Cmd.ZoomOut') { properties.On = $$.grid.zoomOut(); }
        else if (commandId === 'AssignmentPlanner.Cmd.ZoomToFit') { properties.On = $$.grid.zoomToFit(); }
        else if (commandId === 'AssignmentPlanner.Cmd.ScrollTo') { properties.On = $$.grid.scrollTo(); }

        else if (commandId === 'AssignmentPlanner.Cmd.SaveModel') { properties.On = $$.models.save(); }
        else if (commandId === 'AssignmentPlanner.Cmd.OpenModel') { properties.On = $$.models.showOpenDialog(); }
        else if (commandId === 'AssignmentPlanner.Cmd.ClearModel') { properties.On = $$.models.clear(); }

        return true;
    },

    receiveFocus: function () {
        return true;
    },

    yieldFocus: function () {
        return true;
    }
};

ContextualTabWebPart.CustomPageComponent.registerClass('ContextualTabWebPart.CustomPageComponent', window.CUI.Page.PageComponent);
window.SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs("EPMLive.AssignmentPlanner.ContextualTabPageComponent.js");