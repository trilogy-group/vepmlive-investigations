import {CommonPageConstants} from '../../common/common-page.constants';

export class ToDoPageConstants {
    static readonly pagePrefix = 'To Do';
    static readonly pageName = `${ToDoPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.newItem}`;
    static readonly editPageName = `${ToDoPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.editItem}`;

    static get inputLabels() {
        return {
            title: 'Title *',
            status: 'Status',
            assignedTo: 'Assigned To',
            startDate: 'Start Date',
            dueDate: 'Due Date',
            priority: 'Priority',
            work: 'Work',
            description: 'Description'
        };
    }

    static get columnNames() {
        return {
            percentComplete: '% Complete',
            assignedTo: 'Assigned To',
            author: 'Created By',
            daysOverdue: 'Days Overdue',
            body: 'Description',
            dueDate: 'Due Date',
            due: 'Due',
            iD: 'ID',
            editor: 'Modified By',
            priority: 'Priority',
            scheduleStatus: 'Schedule Status',
            startDate: 'Start Date',
            status: 'Status',
            title: 'Title',
            work: 'Work',
            gantt: 'Gantt Chart'
        };
    }
}
