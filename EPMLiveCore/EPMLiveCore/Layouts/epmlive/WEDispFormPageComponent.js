function ULS_SP() {
    if (ULS_SP.caller) {
        ULS_SP.caller.ULSTeamName = "Windows SharePoint Services 4";
        ULS_SP.caller.ULSFileName = "/_layouts/epmlive/WEDispFormPageComponent.js";
    }
}


Type.registerNamespace('WEDispFormPageComponent');

// RibbonApp Page Component
WEDispFormPageComponent.PageComponent = function () {
    ULS_SP();
    WEDispFormPageComponent.PageComponent.initializeBase(this);
}


WEDispFormPageComponent.PageComponent.initialize = function (editform) {
    ULS_SP();
    ExecuteOrDelayUntilScriptLoaded(Function.createDelegate(null,
    WEDispFormPageComponent.PageComponent.initializePageComponent), 'SP.Ribbon.js');
}


WEDispFormPageComponent.PageComponent.initializePageComponent = function () {
    ULS_SP();
    var ribbonPageManager = SP.Ribbon.PageManager.get_instance();
    if (null !== ribbonPageManager) {
        ribbonPageManager.addPageComponent(WEDispFormPageComponent.PageComponent.instance);
        ribbonPageManager.get_focusManager().requestFocusForComponent(
    WEDispFormPageComponent.PageComponent.instance);
    }
}


WEDispFormPageComponent.PageComponent.refreshRibbonStatus = function () {
    SP.Ribbon.PageManager.get_instance().get_commandDispatcher().executeCommand(
  Commands.CommandIds.ApplicationStateChanged, null);
}


WEDispFormPageComponent.PageComponent.prototype = {
    $Z1: "",
    $Z2: "",
    getFocusedCommands: function () {
        ULS_SP();
        return [];
    },
    getGlobalCommands: function () {
        ULS_SP();
        var $arr = [];


        Array.add($arr, 'Ribbon.ListForm.Display.Manage.EditItem2');
        Array.add($arr, 'Ribbon.ListForm.Display.Associated.LinkedItems');
        Array.add($arr, 'Ribbon.ListForm.Display.Associated.LinkedItemsButton');
        Array.add($arr, 'Ribbon.ListForm.Display.Manage.EPMLivePlanner');
        Array.add($arr, 'Ribbon.ListForm.Display.Manage.TaskPlanner');
        Array.add($arr, 'Ribbon.ListForm.Display.Manage.CreateWorkspace');
        Array.add($arr, 'Ribbon.ListForm.Display.Manage.GoToWorkspace');
        Array.add($arr, 'Ribbon.ListForm.Display.Manage.BuildTeam');
        Array.add($arr, 'Ribbon.ListForm.Display.Manage.EPKCost');
        Array.add($arr, 'Ribbon.ListForm.Display.Manage.EPKRP');
        Array.add($arr, 'Ribbon.ListForm.Display.Manage.EPKRPM');
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
            case "Ribbon.ListForm.Display.Manage.EditItem2":
            case "Ribbon.ListForm.Display.Associated.LinkedItems":
            case "Ribbon.ListForm.Display.Associated.LinkedItemsButton":
            case "Ribbon.ListForm.Display.Manage.EPMLivePlanner":
            case "Ribbon.ListForm.Display.Manage.TaskPlanner":
            case "Ribbon.ListForm.Display.Manage.CreateWorkspace":
            case "Ribbon.ListForm.Display.Manage.GoToWorkspace":
            case "Ribbon.ListForm.Display.Manage.BuildTeam":
            case "Ribbon.ListForm.Display.Manage.EPKCost":
            case "Ribbon.ListForm.Display.Manage.EPKRP":
            case "Ribbon.ListForm.Display.Manage.EPKRPM":
                return true;
            default:
                return commandEnabled(commandId);
        };
    },
    handleCommand: function (commandId, properties, sequence) {
        ULS_SP();
        if (commandId === 'Ribbon.ListForm.Display.Manage.EditItem2') {
            var weburl = "";
            if (WEExtraParams != "")
                weburl = WEEditForm + "?ID=" + WEItemId + "&" + WEExtraParams + "&Source=" + WESource;
            else
                weburl = WEEditForm + "?ID=" + WEItemId + "&Source=" + WESource;

            if (WEDLG == "1") {
                var options = { url: weburl, width: 700, dialogReturnValueCallback: this.NewItemCallback };
                SP.UI.ModalDialog.showModalDialog(options);
            }
            else {
                location.href = weburl;
            }
        }
        else if (commandId === 'Ribbon.ListForm.Display.Associated.LinkedItemsButton') {

            //sm("dlgPosting", 150, 50);

            //var listInfo = properties['CommandValueId'].split('.');

            var listInfo = properties.SourceControlId.split('.');

            dhtmlxAjax.post(WEWebUrl + "/_layouts/epmlive/gridaction.aspx?action=linkeditemspost", "listid=" + WEListId + "&lookups=" + escape(WETitle) + "&field=" + listInfo[5] + "&LookupFieldList=" + listInfo[4], this.LinkedItemsButtonPost);

        }
        else if (commandId === 'Ribbon.ListForm.Display.Manage.TaskPlanner') {
            try {

                var weburl = WEWebUrl + "/_layouts/epmlive/gridaction.aspx?action=GoToTaskPlanner&webid=" + WEWebId + "&listid=" + WEListId + "&id=" + WEItemId + "&Source=" + WESource;

                location.href = weburl;
            } catch (e) { }
        }
        else if (commandId === 'Ribbon.ListForm.Display.Manage.EPMLivePlanner') {

            try {

                var weburl = WEWebUrl + "/_layouts/epmlive/workplanner.aspx?listid=" + WEListId + "&id=" + WEItemId + "&Source=" + WESource;

                location.href = weburl;

            } catch (e) { }
        }
        else if (commandId === 'Ribbon.ListForm.Display.Manage.CreateWorkspace') {

            var layoutsUrl = SP.Utilities.Utility.getLayoutsPageUrl('EPMLive/CreateNewWorkspace.aspx?list=' + WEListId + '&type=site&CopyFrom=' + WEItemId);
            var urlBuilder = new SP.Utilities.UrlBuilder(layoutsUrl);
            var tUrl = urlBuilder.get_url();

            var options = { url: tUrl, title: 'Create', allowMaximize: false, width: 800, height: 600, dialogReturnValueCallback: Function.createDelegate(null, HandleCreateNewWorkspaceCreate) };

            SP.UI.ModalDialog.showModalDialog(options);

            function HandleCreateNewWorkspaceCreate(result, value) {
                if (result == '1') {
                    window.location.href = value;
                }
            }
        }
        else if (commandId === 'Ribbon.ListForm.Display.Manage.GoToWorkspace') {
            if (parent) {
                parent.location.href = "gridaction.aspx?action=workspace&webid" + WEWebId;
            }
            else {
                location.href = "gridaction.aspx?action=workspace&webid" + WEWebId;
            }
        }
        else if (commandId === 'Ribbon.ListForm.Display.Manage.BuildTeam') {
            var options = { url: WEWebUrl + "/_layouts/epmlive/buildteam.aspx?listid=" + WEListId + "&id=" + WEItemId, title: "Build Team", showMaximized: true, dialogReturnValueCallback: this.NewItemCallback };

            SP.UI.ModalDialog.showModalDialog(options);
        }
        else if (commandId === 'Ribbon.ListForm.Display.Manage.EPKCost') {
            var FullId = WEWebId + "." + WEListId + "." + WEItemId;

            weburl = WEWebUrl + "/_layouts/ppm/costs.aspx?itemid=" + FullId + "&listid=" + WEListId + "&view=";

            var options = { url: weburl, showMaximized: true, showClose: false, dialogReturnValueCallback: this.NewItemCallback };

            SP.UI.ModalDialog.showModalDialog(options);
        }
        else if (commandId === 'Ribbon.ListForm.Display.Manage.EPKRP') {
            var FullId = WEWebId + "." + WEListId + "." + WEItemId;

            weburl = WEWebUrl + "/_layouts/ppm/rpeditor.aspx?itemid=" + FullId;

            var options = { url: weburl, showMaximized: true, showClose: false, dialogReturnValueCallback: this.NewItemCallback };

            SP.UI.ModalDialog.showModalDialog(options);
        }
        else if (commandId === 'Ribbon.ListForm.Display.Manage.EPKRPM') {
            this.epkmulti('rpeditor');
        }
        else {
            return handleCommand(commandId, properties, sequence);
        }
    },
    NewItemCallback: function (dialogResult, returnValue) {
        if (dialogResult) {
            window.location.href = window.location.href;
        }
    },
    LinkedItemsButtonPost: function (ret) {
        //hm("dlgPosting");

        var ticket = ret.xmlDoc.ResponseText;

        if (ticket == undefined)
            ticket = ret.xmlDoc.responseText;

        if (ticket.indexOf("General Error") != 0) {
            var listInfo = ticket.split('|');

            var weburl = listInfo[0] + "/_layouts/epmlive/gridaction.aspx?action=linkeditems&list=" + listInfo[3] + "&field=" + listInfo[1] + "&LookupFieldList=" + listInfo[2] + "&Source=" + document.location.href;
            var options = { url: weburl, showMaximized: true };

            SP.UI.ModalDialog.showModalDialog(options);
        }
        else {
            alert(ticket);
        }
    },
    epkmulti: function (epkcontrol) {

        if (weburl == "/")
            weburl = "";

        this.$Z1 = epkcontrol

        dhtmlxAjax.post(WEWebUrl + "/_layouts/ppm/gridaction.aspx?action=postepkmultipage", "IDs=" + WEWebId + "." + WEListId + "." + WEItemId, this.epkmultiresponse);

    },
    epkmultiresponse: function (ret) {
        var ticket = ret.xmlDoc.ResponseText;

        if (ticket == undefined)
            ticket = ret.xmlDoc.responseText;

        var weburl = WEWebUrl + "/_layouts/ppm/gridaction.aspx?action=epkmultipage&ticket=" + ticket + "&epkcontrol=" + this.$Z1 + "&view=&listid=" + WEListId;

        function myCallback(dialogResult, returnValue) { }

        var options = { url: weburl, showMaximized: true, showClose: false, dialogReturnValueCallback: myCallback };

        SP.UI.ModalDialog.showModalDialog(options);
    }
}


// Register classes
WEDispFormPageComponent.PageComponent.registerClass('WEDispFormPageComponent.PageComponent',
    CUI.Page.PageComponent);
WEDispFormPageComponent.PageComponent.instance = new WEDispFormPageComponent.PageComponent();


// Notify waiting jobs
NotifyScriptLoadedAndExecuteWaitingJobs("/_layouts/epmlive/WEDispFormPageComponent.js");