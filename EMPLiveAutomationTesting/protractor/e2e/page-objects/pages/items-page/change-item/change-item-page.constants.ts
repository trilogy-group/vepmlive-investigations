import {CommonPageConstants} from '../../common/common-page.constants';

export class ChangeItemPageConstants {
    static readonly pagePrefix = 'Changes';
    static readonly pageName = `${ChangeItemPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.newItem}`;
    static readonly editPageName = `${ChangeItemPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.editItem}`;

    static get inputLabels() {
        return {
            title: 'Title *',
            project: 'Project *',
            assignedTo: 'Assigned To',
            status: 'Status *',
            priority: 'Priority',
            startDate: 'Start Date',
            dueDate: 'Due Date',
            effort: 'Effort (Hours)',
            category: 'Category',
            inScope: 'In Scope',
            benefitsOfTheChange: 'Benefits of the Change',
            impactOfNotMakingTheChange: 'Impact of Not Making the Change',
            costImpact: 'Cost Impact',
            scheduleImpact: 'Schedule Impact',
            resourceImpact: 'Resource Impact'
        };
    }

    static get columnNames() {
        return {
            assignedTo: 'Assigned To',
            benefitsOfTheChange: 'Benefits of the Change',
            category: 'Category',
            costImpact: 'Cost Impact',
            author: 'Created By',
            daysOverdue: 'Days Overdue',
            dueDate: 'Due Date',
            due: 'Due',
            work: 'Effort (Hours)',
            id: 'ID',
            impactOfNotMakingTheChange: 'Impact of Not Making the Change',
            inScope: 'In Scope',
            editor: 'Modified By',
            priority: 'Priority',
            project: 'Project',
            remainingHours: 'Remaining Hours',
            resourceImpact: 'Resource Impact',
            scheduleImpact: 'Schedule Impact',
            scheduleStatus: 'Schedule Status',
            startDate: 'Start Date',
            statusIcon: 'Status Icon',
            status: 'Status',
            linkTitleNoMenu: 'Title',
            gantt: 'Gantt Chart'
        };
    }

    static get statuses() {
        return {
            notStarted: 'Not Started',
            inProgress: 'In Progress',
            completed: 'Completed',
            deferred: 'Deferred',
            waitingOnSomeoneElse: 'Waiting on someone else'
        };
    }

    static get priorities() {
        return {
            high: '(1) High',
            normal: '(2) Normal',
            low: '(3) Low',
        };
    }
}
