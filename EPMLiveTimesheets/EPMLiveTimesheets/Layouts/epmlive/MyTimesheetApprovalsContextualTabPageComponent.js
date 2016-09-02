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
        return ['MyTimesheetApprovalsContextualTab.EnableMyTimesheetTab',
        'MyTimesheetApprovalsContextualTab.EnableContextualGroup',
        'Ribbon.MyTimesheet.ActionsGroup',
        'Ribbon.MyTimesheet.Approve',
        'Ribbon.MyTimesheet.Unlock',
        'Ribbon.MyTimesheet.Reject'
        ];
    },

    getGlobalCommands: function ContextualTabWebPart_CustomPageComponent$getGlobalCommands() {
        return [];
    },

    isFocusable: function ContextualTabWebPart_CustomPageComponent$isFocusable() {
        return true;
    },

    canHandleCommand: function ContextualTabWebPart_CustomPageComponent$canHandleCommand(commandId) {
        //Contextual Tab commands

        switch (commandId) {
            case 'MyTimesheetApprovalsContextualTab.EnableMyTimesheetTab':
            case 'MyTimesheetApprovalsContextualTab.EnableContextualGroup':
            case 'Ribbon.MyTimesheet.Approve':
            case 'Ribbon.MyTimesheet.Unlock':
            case 'Ribbon.MyTimesheet.Reject':

            default:
                return true;
        }
    },

    handleCommand: function ContextualTabWebPart_CustomPageComponent$handleCommand(commandId, properties, sequence) {


        if (commandId === 'MyWork.Cmd.ViewItem') {

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
SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs("MyTimesheetApprovalsContextualTabPageComponent.js");