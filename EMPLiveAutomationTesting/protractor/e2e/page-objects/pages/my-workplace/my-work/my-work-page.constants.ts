import {CommonPageConstants} from '../../common/common-page.constants';

export class MyWorkPageConstants {

    static readonly pagePrefix = 'My Work';
    static readonly editPageName = `${MyWorkPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.editItem}`;
    static readonly edit = 'Edit.Edit';
    static readonly viewName= 'View';
    static readonly renameView= 'rView';
    static readonly currentView= 'Current View';

    static get pageName() {
        return {
            changes: `Changes${CommonPageConstants.pagePostFix.newItem}`,
            issues: `Issues${CommonPageConstants.pagePostFix.newItem}`,
            risks: `Risks${CommonPageConstants.pagePostFix.newItem}`,
            timeOff: `Time Off${CommonPageConstants.pagePostFix.newItem}`,
            toDo: `To Do${CommonPageConstants.pagePostFix.newItem}`,
        };
    }

    static get title() {
        return {
            newItem: 'NewItem',
            changesItem: 'NewItem.Changes',
            changes: 'Changes',
            issues: 'Issues',
            risks: 'Risks',
            timeOff: 'Time Off',
            toDo: 'To Do',
        };
    }

    static get inputLabels() {
        return {
            title: 'Title *',
            project: 'Project *',
            assignedTo: 'Assigned To',
            start: 'Start Required Field',
            finish: 'Finish Required Field',
            timeOffType: 'Time Off Type *',
            requestor: 'Requestor',
        };
    }

    static get inputDropdownValues() {
        return {
            Holiday: 'Holiday',
            juryDuty: 'Jury Duty',
            sick: 'Sick',
            vacation: 'Vacation',
            doctorAppointment: 'Doctor Appointment',
        };
    }

    static get editPageActions() {
        return {
            stopEditing: 'Actions.Stop',
            editPage: 'Actions.Edit-Menu',
        };
    }

    static get ribbonTabs(){
        return{
            page: 'Page',
            hide: 'Hide',
            manage: 'Manage Work',
            views: 'Manage Views'
        };
    }

    static get viewRibbonOptions(){
        return{
          saveView: 'Ribbon.MyWork.Views.SaveView-Medium',
          renameView: 'Ribbon.MyWork.Views.RenameView-Medium',
          deleteView: 'Ribbon.MyWork.Views.DeleteView-Medium'
        };
    }

    static get viewsPopUp(){
        return{
            title: 'dialogTitleSpan',
            name: 'MWG_ViewName',
            defaultView: 'MWG_DefaultView',
            personalView: 'MWG_PersonalView',
            ok: 'OK',
            cancel: 'Cancel',
            newName: 'MWG_ViewNewName'
        };
    }
}
