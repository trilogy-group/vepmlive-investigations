import { CommonPageConstants } from '../../common/common-page.constants';
export class MyWorkPageConstants {

    static readonly pagePrefix = 'My Work';
    static readonly pagePostfix = `${CommonPageConstants.pagePostFix.newItem}`;
    static readonly editPageName = `${MyWorkPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.editItem}`;

    static get newItemMenu() {
        return {
            newItem: 'Ribbon.MyWork.New.NewItem-Large',
            changesItem: 'Ribbon.MyWork.NewItem.Changes-Menu32',
            issuesItem: 'Ribbon.MyWork.NewItem.Issues-Menu32',
            risksItem: 'Ribbon.MyWork.NewItem.Risks-Menu32',
            timeOffItem: 'Ribbon.MyWork.NewItem.Time Off-Menu32',
            toDoItem: 'Ribbon.MyWork.NewItem.To Do-Menu32',
        };
    }

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

    static get inputShowAllDropdown() {
        return {
            project: 'Project_ddlShowAll',
            timeOffType: 'TimeOffType_ddlShowAll',
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
}
