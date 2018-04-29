export class IssueItemPageConstants {
    static readonly pageName = 'Issues - New Item';
    static readonly editPageName = 'Issues Page Edit Mode';

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
