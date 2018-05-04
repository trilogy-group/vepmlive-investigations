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
            requestorValue: 'NonAdmin User',
            startDate: '1/1/2019',
            finishDate: '2/1/2019'
        };
    }

    static get columnNames() {
        return {
            title: 'Title'
        };
    }
}
