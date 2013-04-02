function ULS_SP() {
    if (ULS_SP.caller) {
        ULS_SP.caller.ULSTeamName = "Windows SharePoint Services 4";
        ULS_SP.caller.ULSFileName = "/_layouts/epmlive/BuildTeamPageComponent.js";
    }
}

Type.registerNamespace('BuildTeamPageComponent');

// RibbonApp Page Component
BuildTeamPageComponent.PageComponent = function () {
    ULS_SP();
    BuildTeamPageComponent.PageComponent.initializeBase(this);
}


BuildTeamPageComponent.PageComponent.initialize = function () {
    ULS_SP();
    ExecuteOrDelayUntilScriptLoaded(Function.createDelegate(null,
    BuildTeamPageComponent.PageComponent.initializePageComponent), 'SP.Ribbon.js');
}


BuildTeamPageComponent.PageComponent.initializePageComponent = function () {
    ULS_SP();
    var ribbonPageManager = SP.Ribbon.PageManager.get_instance();
    if (null !== ribbonPageManager) {
        ribbonPageManager.addPageComponent(BuildTeamPageComponent.PageComponent.instance);
        ribbonPageManager.get_focusManager().requestFocusForComponent(
    BuildTeamPageComponent.PageComponent.instance);
    }
}


BuildTeamPageComponent.PageComponent.refreshRibbonStatus = function () {
    SP.Ribbon.PageManager.get_instance().get_commandDispatcher().executeCommand(
  Commands.CommandIds.ApplicationStateChanged, null);
}


BuildTeamPageComponent.PageComponent.prototype = {
    getFocusedCommands: function () {
        ULS_SP();
        return [];
    },
    getGlobalCommands: function () {
        ULS_SP();
        var $arr = ['Ribbon.BuildTeam.SaveButton', 'Ribbon.BuildTeam.SaveCloseButton', 'Ribbon.BuildTeam.CloseButton', 'Ribbon.BuildTeam.ShowPool', 'Ribbon.BuildTeam.AddResource', 'Ribbon.BuildTeam.AddResColumns', 'Ribbon.BuildTeam.AddTeamColumns', 'Ribbon.BuildTeam.Assignments', 'Ribbon.BuildTeam.DisplayReports', 'Ribbon.BuildTeam.AddToTeam', 'Ribbon.BuildTeam.RemoveFromTeam'];

        Array.add($arr, "Ribbon.BuildTeam.DisplayReports");
        Array.add($arr, "Ribbon.BuildTeam.PopulateReports");
        Array.add($arr, "Ribbon.BuildTeam.ShowReport");
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
            case "Ribbon.BuildTeam.PopulateReports":
            case "Ribbon.BuildTeam.DisplayReports":
            case "Ribbon.BuildTeam.ShowReport":
                return true;
            default:
                return commandEnabled(commandId);
        };
    },

    handleCommand: function (commandId, properties, sequence) {
        ULS_SP();
        if (commandId === 'Ribbon.BuildTeam.PopulateReports') {
            properties.PopulationXML = this.PopulateReports();
            return true;
        }
        else if (commandId === 'Ribbon.BuildTeam.ShowReport') {

            var sResources = "";

            var tGrid = Grids.TeamGrid;
            var rGrid = Grids.ResourceGrid;

            var sRows = rGrid.GetSelRows();

            for (var r in sRows) {
                var oSRow = sRows[r];
                sResources += "%26rp%3aResources%3d" + oSRow.SPID;
            }

            sRows = tGrid.GetSelRows();

            for (var r in sRows) {
                var oSRow = sRows[r];
                sResources += "%26rp%3aResources%3d" + oSRow.SPID;
            }

            //if (sResources != "") 
            //    sResources = sResources.substr(1);

            window.open("BuildTeamHelper.aspx?Command=GoToReport&surl=" + properties['CommandValueId'] + sResources);

        }
        else {
            return handleCommand(commandId, properties, sequence);
        }
    },

    PopulateReports: function () {


        var retDoc = dhtmlxAjax.postSync("BuildTeamHelper.aspx", "Command=GetReports");

        var ret = retDoc.xmlDoc.responseText;

        if (ret != "Error") {
            var sb = new Sys.StringBuilder();
            sb.append('<Menu Id=\'Ribbon.WorkPlanner.DisplayView.Dropdown.Menu\'>');
            sb.append('<MenuSection DisplayMode=\'Menu\' Id=\'Ribbon.WorkPlanner.DisplayView.Dropdown.Menu.Default\'>');
            sb.append('<Controls Id=\'Ribbon.WorkPlanner.DisplayView.Dropdown.Menu.Default.Controls\'>');

            sb.append(ret.trim());

            sb.append('</Controls>');
            sb.append('</MenuSection>');

            sb.append('</Menu>');
            return sb.toString();
        }
        else {

        }
    }
}


// Register classes
BuildTeamPageComponent.PageComponent.registerClass('BuildTeamPageComponent.PageComponent',
    CUI.Page.PageComponent);
BuildTeamPageComponent.PageComponent.instance = new BuildTeamPageComponent.PageComponent();


// Notify waiting jobs
NotifyScriptLoadedAndExecuteWaitingJobs("/_layouts/epmlive/BuildTeamPageComponent.js");