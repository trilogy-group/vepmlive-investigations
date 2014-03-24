function ULS_SP() {
    if (ULS_SP.caller) {
        ULS_SP.caller.ULSTeamName = "Windows SharePoint Services 4";
        ULS_SP.caller.ULSFileName = "/_layouts/epmlive/WorkPlannerPageComponent.js";
    }
}


Type.registerNamespace('WorkPlannerPageComponent');

// RibbonApp Page Component
WorkPlannerPageComponent.PageComponent = function () {
    ULS_SP();
    WorkPlannerPageComponent.PageComponent.initializeBase(this);
}


WorkPlannerPageComponent.PageComponent.initialize = function () {
    ULS_SP();
    ExecuteOrDelayUntilScriptLoaded(Function.createDelegate(null,
    WorkPlannerPageComponent.PageComponent.initializePageComponent), 'SP.Ribbon.js');
}


WorkPlannerPageComponent.PageComponent.initializePageComponent = function () {
    ULS_SP();
    var ribbonPageManager = SP.Ribbon.PageManager.get_instance();
    if (null !== ribbonPageManager) {
        ribbonPageManager.addPageComponent(WorkPlannerPageComponent.PageComponent.instance);
        ribbonPageManager.get_focusManager().requestFocusForComponent(
    WorkPlannerPageComponent.PageComponent.instance);
    }
}


WorkPlannerPageComponent.PageComponent.refreshRibbonStatus = function () {
    SP.Ribbon.PageManager.get_instance().get_commandDispatcher().executeCommand(
  Commands.CommandIds.ApplicationStateChanged, null);
}


WorkPlannerPageComponent.PageComponent.prototype = {
    getFocusedCommands: function () {
        ULS_SP();
        return ['Ribbon.WorkPlanner.CurrentView', 'Ribbon.WorkPlanner.PopulateDisplayView', 'Ribbon.WorkPlanner.QueryDisplayView', 'Ribbon.WorkPlanner.DisplayView.DoDisplayView'];
    },
    getGlobalCommands: function () {
        ULS_SP();
        var $arr = ['Ribbon.WorkPlanner.SaveButton', 'Ribbon.WorkPlanner.PublishButton', 'Ribbon.WorkPlanner.PrintButton', 'Ribbon.WorkPlanner.CloseButton', 'Ribbon.WorkPlanner.ExcelButton', 'Ribbon.WorkPlanner.PDFButton', 'Ribbon.WorkPlanner.NewTask', 'Ribbon.WorkPlanner.NewSummary', 'Ribbon.WorkPlanner.NewIteration', 'Ribbon.WorkPlanner.NewMilestone', 'Ribbon.WorkPlanner.DeleteTasks', 'Ribbon.WorkPlanner.ShowBacklog', 'Ribbon.WorkPlanner.Details', 'Ribbon.WorkPlanner.Notes', 'Ribbon.WorkPlanner.Links', 'Ribbon.WorkPlanner.Comments', 'Ribbon.WorkPlanner.Alerts', 'Ribbon.WorkPlanner.History', 'Ribbon.WorkPlanner.Permissions', 'Ribbon.WorkPlanner.Attachments', 'Ribbon.WorkPlanner.Workflows', 'Ribbon.WorkPlanner.Copy', 'Ribbon.WorkPlanner.Paste', 'Ribbon.WorkPlanner.Undo', 'Ribbon.WorkPlanner.Redo', 'Ribbon.WorkPlanner.AssignResources', 'Ribbon.WorkPlanner.EditTeam', 'Ribbon.WorkPlanner.ResourceInformation', 'Ribbon.WorkPlanner.CheckResource', 'Ribbon.WorkPlanner.SelectResColumns', 'Ribbon.WorkPlanner.ShowResGrid', 'Ribbon.WorkPlanner.Indent', 'Ribbon.WorkPlanner.Outdent', 'Ribbon.WorkPlanner.LinkDown', 'Ribbon.WorkPlanner.LinkUp', 'Ribbon.WorkPlanner.Unlink', 'Ribbon.WorkPlanner.Percent0', 'Ribbon.WorkPlanner.Percent50', 'Ribbon.WorkPlanner.Percent100', 'Ribbon.WorkPlanner.ZoomIn', 'Ribbon.WorkPlanner.ZoomOut', 'Ribbon.WorkPlanner.ZoomFit', 'Ribbon.WorkPlanner.ScrollTo', 'Ribbon.WorkPlanner.ShowHideGantt', 'Ribbon.WorkPlanner.ShowBaseline', 'Ribbon.WorkPlanner.SaveView', 'Ribbon.WorkPlanner.EditView', 'Ribbon.WorkPlanner.DeleteView', 'Ribbon.WorkPlanner.CurrentView', 'Ribbon.WorkPlanner.DisplayView', 'Ribbon.WorkPlanner.SelectColumns', 'Ribbon.WorkPlanner.CreateColumn', 'Ribbon.WorkPlanner.ShowFilters', 'Ribbon.WorkPlanner.ShowGrouping', 'Ribbon.WorkPlanner.ClearSort', 'Ribbon.WorkPlanner.ShowAssignments', 'Ribbon.WorkPlanner.ShowSummary', 'Ribbon.WorkPlanner.UpdateProject', 'Ribbon.WorkPlanner.UpdateStatus', 'Ribbon.WorkPlanner.ProjectInfo', 'Ribbon.WorkPlanner.DisableCalc', 'Ribbon.WorkPlanner.SetBaseline', 'Ribbon.WorkPlanner.ClearBaseline', 'Ribbon.WorkPlanner.MoveProject', 'Ribbon.WorkPlanner.RespectLinks', 'Ribbon.WorkPlanner.SummaryRollup', 'Ribbon.WorkPlanner.CreateNew', 'Ribbon.WorkPlanner.ImportFrom', 'Ribbon.WorkPlanner.ImportList', 'Ribbon.WorkPlanner.ImportExcel', 'Ribbon.WorkPlanner.ImportCsv', 'Ribbon.WorkPlanner.SaveTemplate', 'Ribbon.WorkPlanner.EditCosts', 'Ribbon.WorkPlanner.EditResourcePlan', 'Ribbon.WorkPlanner.Fragment', 'Ribbon.WorkPlanner.AddFragmentButton', 'Ribbon.WorkPlanner.SaveFragmentButton', 'Ribbon.WorkPlanner.ManageFragmentButton'];

        Array.add($arr, 'Ribbon.WorkPlanner.LinkExternalTask');
        Array.add($arr, 'Ribbon.WorkPlanner.PopulateDisplayView');
        Array.add($arr, 'Ribbon.WorkPlanner.QueryDisplayView');
        Array.add($arr, 'Ribbon.WorkPlanner.QueryAutoCalc');
        Array.add($arr, 'Ribbon.WorkPlanner.QueryShowResGrid');
        Array.add($arr, 'Ribbon.WorkPlanner.QueryRespectLinks');
        Array.add($arr, 'Ribbon.WorkPlanner.CreateNewQuery');
        Array.add($arr, 'Ribbon.WorkPlanner.QuerySummaryRollup');
        Array.add($arr, 'Ribbon.WorkPlanner.DoCreateNew');
        Array.add($arr, 'Ribbon.WorkPlanner.DoCreateNewNoProject');
        Array.add($arr, 'Ribbon.WorkPlanner.Expand');
        Array.add($arr, 'Ribbon.WorkPlanner.QueryShowBaseline');
        Array.add($arr, 'Ribbon.WorkPlanner.QueryShowSummary');
        Array.add($arr, 'Ribbon.WorkPlanner.QueryShowAssignments');
        Array.add($arr, 'Ribbon.WorkPlanner.QueryShowGrouping');
        Array.add($arr, 'Ribbon.WorkPlanner.QueryShowFilters');
        Array.add($arr, 'Ribbon.WorkPlanner.QueryShowGantt');
        Array.add($arr, 'Ribbon.WorkPlanner.QueryShowBacklog');
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
            case "Ribbon.WorkPlanner.PopulateDisplayView":
            case "Ribbon.WorkPlanner.QueryDisplayView":
            case "Ribbon.WorkPlanner.DisplayView.DoDisplayView":
            case "Ribbon.WorkPlanner.QueryAutoCalc":
            case "Ribbon.WorkPlanner.QueryRespectLinks":
            case "Ribbon.WorkPlanner.CreateNewQuery":
            case "Ribbon.WorkPlanner.QuerySummaryRollup":
            case "Ribbon.WorkPlanner.DoCreateNew":
            case "Ribbon.WorkPlanner.DoCreateNewNoProject":
            case "Ribbon.WorkPlanner.Expand":
            case "Ribbon.WorkPlanner.QueryShowBaseline":
            case "Ribbon.WorkPlanner.QueryShowSummary":
            case "Ribbon.WorkPlanner.QueryShowAssignments":
            case "Ribbon.WorkPlanner.QueryShowGrouping":
            case "Ribbon.WorkPlanner.QueryShowFilters":
            case "Ribbon.WorkPlanner.QueryShowGantt":
            case "Ribbon.WorkPlanner.QueryShowResGrid":
            case "Ribbon.WorkPlanner.QueryShowBacklog":
                return true;
            default:
                return commandEnabled(commandId);
        };
    },
    handleCommand: function (commandId, properties, sequence) {
        ULS_SP();
        if (commandId === 'Ribbon.WorkPlanner.PopulateDisplayView') {
            properties.PopulationXML = PopulateDisplayView();
            return true;
        }
        else if (commandId === 'Ribbon.WorkPlanner.QueryDisplayView') {
            properties['Value'] = curView;
        }
        else if (commandId === 'Ribbon.WorkPlanner.QueryAutoCalc') {
            properties['On'] = IsCalcEnabled();
        }
        else if (commandId === 'Ribbon.WorkPlanner.QueryShowGantt') {
            properties['On'] = IsShowGantt();
        }
        else if (commandId === 'Ribbon.WorkPlanner.QueryRespectLinks') {
            properties['On'] = IsRespectLinks();
        }
        else if (commandId === 'Ribbon.WorkPlanner.DisplayView.DoDisplayView') {
            ChangeView(properties['CommandValueId']);
        }
        else if (commandId === 'Ribbon.WorkPlanner.CreateNewQuery') {
            properties.PopulationXML = PopulateCreateNew();
            return true;
        }
        else if (commandId === 'Ribbon.WorkPlanner.QuerySummaryRollup') {
            properties['On'] = bSummaryRollup;
        }
        else if (commandId === 'Ribbon.WorkPlanner.DoCreateNew') {
            DoCreateNew(properties["CommandValueId"], true);
        }
        else if (commandId === 'Ribbon.WorkPlanner.DoCreateNewNoProject') {
            DoCreateNew(properties["CommandValueId"], false);
        }
        else if (commandId === 'Ribbon.WorkPlanner.Expand') {
            if (properties != null)
                Expand(properties['CommandValueId']);
        }
        else if (commandId === 'Ribbon.WorkPlanner.QueryShowBaseline') {
            try {
                properties['On'] = isShowBaseline();
            } catch (e) { }
        }
        else if (commandId === 'Ribbon.WorkPlanner.QueryShowSummary') {
            try {
                properties['On'] = CanShowSummary();
            } catch (e) { }
        }
        else if (commandId === 'Ribbon.WorkPlanner.QueryShowAssignments') {
            try {
                properties['On'] = oShowAssignments;
            } catch (e) { }
        }
        else if (commandId === 'Ribbon.WorkPlanner.QueryShowGrouping') {
            try {
                properties['On'] = isShowGrouping();
            } catch (e) { }
        }
        else if (commandId === 'Ribbon.WorkPlanner.QueryShowFilters') {
            try {
                properties['On'] = isShowFilters();
            } catch (e) { }
        }
        else if (commandId === 'Ribbon.WorkPlanner.QueryShowResGrid') {
            try {
                properties['On'] = isQueryShowResGrid();
            } catch (e) { }
        }
        else if (commandId === 'Ribbon.WorkPlanner.QueryShowBacklog') {
            try {
                properties['On'] = isQueryShowBacklog();
            } catch (e) { }
        }
        else {
            return handleCommand(commandId, properties, sequence);
        }
    }
}


// Register classes
WorkPlannerPageComponent.PageComponent.registerClass('WorkPlannerPageComponent.PageComponent',
    CUI.Page.PageComponent);
WorkPlannerPageComponent.PageComponent.instance = new WorkPlannerPageComponent.PageComponent();


// Notify waiting jobs
NotifyScriptLoadedAndExecuteWaitingJobs("/_layouts/epmlive/WorkPlannerPageComponent.js");