import {BasePage} from '../../base-page';
import {CommonPageHelper} from '../../common/common-page.helper';
import {ResourcesPageConstants} from './resources-page.constants';
import {By, element} from 'protractor';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';
import {CommonPageConstants} from '../../common/common-page.constants';

export class ResourcesPage extends BasePage {

    static get newInviteLink() {
        return CommonPageHelper.getSpanByText(ResourcesPageConstants.inviteLink);
    }

    static get inputs() {
        const dropdownLabel = CommonPageConstants.dropdownShowAllButton;
        const inputLabel = ResourcesPageConstants.inputLabels;
        const dropdownValueLabel = ResourcesPageConstants.inputDropdownValues;
        return {
            displayName: CommonPageHelper.getElementByTitle(inputLabel.displayName),
            generic: CommonPageHelper.getElementByTitle(inputLabel.generic),
            role: this.getDropdownValue(dropdownLabel.role),
            roleInput: this.selectDropdownOption(dropdownValueLabel.employee),
            holidaySchedule: this.getDropdownValue(dropdownLabel.holidaySchedule),
            holidayScheduleInput: this.selectDropdownOption(dropdownValueLabel.usHolidays),
            workingHours: this.getDropdownValue(dropdownLabel.workHours),
            workingHoursInput: this.selectDropdownOption(dropdownValueLabel.usWorkHours)
        };
    }

    static selectDropdownOption(option: string) {
        return element(By.xpath(`//div[${ComponentHelpers.getXPathFunctionForText(option)}]`));
    }

    static getDropdownValue(id: string) {
        return element(By.id(`${id}`));
    }
}
