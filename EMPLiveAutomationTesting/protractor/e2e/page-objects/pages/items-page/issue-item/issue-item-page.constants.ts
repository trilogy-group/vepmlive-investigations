import {CommonPageConstants} from '../../common/common-page.constants';

export class IssueItemPageConstants {
    static readonly pagePrefix = 'Issues';
    static readonly pageName = `${IssueItemPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.newItem}`;
    static readonly editPageName = `${IssueItemPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.editItem}`;

    static get inputLabels() {
        return {
            title: 'Title *',
            project: 'Project *',
            assignedTo: 'Assigned To',
            status: 'Status',
            priority: 'Priority',
            description: 'Description',
            relatedIssues: 'Related Issues',
            startDate: 'Start Date',
            dueDate: 'Due Date',
            effort: 'Effort',
            comments: 'Comments',
            resolution: 'Resolution'
        };
    }

    static get columnNames() {
        return {
            assignedTo: 'Assigned To',
            comments: 'Comments',
            createdBy: 'Created By',
            daysOverdue: 'Days Overdue',
            description: 'Description',
            dueDate: 'Due Date',
            due: 'Due',
            effort: 'Effort',
            id: 'ID',
            modifiedBy: 'Modified By',
            priority: 'Priority',
            project: 'Project',
            relatedIssues: 'Related Issues',
            resolution: 'Resolution',
            scheduleStatus: 'Schedule Status',
            startDate: 'Start Date',
            status: 'Status',
            title: 'Title',
            specialColumns: 'Special Columns',
            ganttChart: 'Gantt Chart'
        };
    }

}
