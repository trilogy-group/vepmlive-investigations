import {CommonPageConstants} from '../../common/common-page.constants';

export class ResourcesPageConstants {

    static readonly inviteLink = 'Invite';
    static readonly pagePrefix = 'Resources';
    static readonly pageName = `${ResourcesPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.newItem}`;
    static readonly editPageName = `${ResourcesPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.editItem}`;
    static readonly createUserPage = 'Create user page';
    static readonly standardRate = '10';
    static readonly ellipsesDropdownLabel = 'Ellipses Dropdown';

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
            disabled: 'Disabled',
            resources: 'Resources',
            firstName: 'First Name',
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
