import {BasePage} from '../../base-page';
import {CommonPageHelper} from '../../common/common-page.helper';
import {ResourcesPageConstants} from './resources-page.constants';

export class ResourcesPage extends BasePage {

    static get newInviteLink() {
        return CommonPageHelper.getSpanByText(ResourcesPageConstants.inviteLink);
    }

    static get inputs() {
        const dropdownLabel = ResourcesPageConstants.inputShowAllDropdown;
        const inputLabel = ResourcesPageConstants.inputLabels;
        const dropdownValueLabel = ResourcesPageConstants.inputDropdownValues;
        return {
            displayName: CommonPageHelper.getElementByTitle(inputLabel.displayName),
            generic: CommonPageHelper.getElementByTitle(inputLabel.generic),
            role: CommonPageHelper.getElementById(dropdownLabel.role),
            roleInput: CommonPageHelper.getDivByText(dropdownValueLabel.employee),
            holidaySchedule: CommonPageHelper.getElementById(dropdownLabel.holidaySchedule),
            holidayScheduleInput: CommonPageHelper.getDivByText(dropdownValueLabel.usHolidays),
            workingHours: CommonPageHelper.getElementById(dropdownLabel.workHours),
            workingHoursInput: CommonPageHelper.getDivByText(dropdownValueLabel.usWorkHours)
        };
    }
}
