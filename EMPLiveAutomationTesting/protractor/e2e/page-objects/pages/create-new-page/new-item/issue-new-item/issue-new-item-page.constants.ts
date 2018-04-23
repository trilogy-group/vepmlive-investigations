export class IssueNewItemPageConstants {
    static readonly pageName = 'Issues - New Item';

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
}
