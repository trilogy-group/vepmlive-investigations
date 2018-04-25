import {HomePageConstants} from '../home-page.constants';

export class CommonViewPageConstants {
    static get pageHeaders() {
        return HomePageConstants.navigationLabels;
    }

    static get actionMenuIconTitles() {
        return {
            search: 'search',
            toggleFilters: 'toggle filters',
            defaultSort: 'default sort',
            groupBy: 'Group by',
            selectColumns: 'select columns',
            view: 'View: ',
            settings: 'settings'
        };
    }

    static get contextMenuOptions() {
        return {
            viewItem: 'View Item',
            editItem: 'Edit Item',
            workFlows: 'Workflows',
            permissions: 'Permissions',
            deleteItem: 'Delete Item',
            comments: 'Comments'
        };
    }

    static get columns() {
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
