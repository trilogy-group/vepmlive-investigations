import {CommonPageConstants} from '../../common/common-page.constants';

export class ResourcesPageConstants {

    static readonly inviteLink = 'Invite';
    static readonly pagePrefix = 'Resources';
    static readonly pageName = `${ResourcesPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.newItem}`;
    static readonly editPageName = `${ResourcesPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.editItem}`;

    static get inputLabels() {
        return {
            role: 'Role *',
            holidaySchedule: 'Holiday Schedule *',
            workHours: 'Work Hours *',
            availableFrom: 'Available From *',
            availableTo: 'Available To',
            department: 'Department',
            standardRate: 'Standard Rate',
            generic: 'Generic',
            displayName: 'Display Name',
        };
    }

    static get inputDropdownValues() {
        return {
            employee: 'Employee',
            usHolidays: 'US Holidays',
            usWorkHours: 'US Work Hours',
        };
    }

}
