import {CommonPageConstants} from '../../common/common-page.constants';

export class MyTimeOffPageConstants {
    static readonly pagePrefix = 'Time Off';
    static readonly pageName = `${MyTimeOffPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.newItem}`;
    static readonly editPageName = `${MyTimeOffPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.editItem}`;

    static get inputLabels() {
        return {
            title: 'Title *',
            timeOffType: 'Time Off Type *',
            requestor: 'Requestor *',
            start: 'Start *',
            finish: 'Finish *',
        };
    }

    static get inputValues() {
        return {
            requestorValue: 'admint01',
            startDate: '1/1/2019',
            finishDate: '2/1/2019'
        };
    }

    static get columnNames() {
        return {
            complete: 'Complete',
            daysOverdue: 'Days Overdue',
            description: 'Description',
            finish: 'Finish',
            hours: 'Hours',
            manager: 'Manager',
            requestDate: 'Request Date',
            requestor: 'Requestor',
            scheduleStatus: 'Schedule Status',
            start: 'Start',
            timeOffType: 'Time Off Type',
            title: 'Title',
            workDetail: 'Work Detail',
        };
    }

    static get timeOffTypes() {
        return {
            bereavement: 'Bereavement',
            doctorAppointment: 'Doctor Appointment',
            holiday: 'Holiday',
            juryDuty: 'Jury Duty',
            sickTime: 'Sick Time',
            vacation: 'Vacation'
        };
    }
}
