import {By, element} from 'protractor';
import {BasePage} from '../../base-page';
import {CommonPageHelper} from '../../common/common-page.helper';
import {ResourcesPageConstants} from './resources-page.constants';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';
import {CommonPageConstants} from '../../common/common-page.constants';
import {AnchorHelper} from '../../../../components/html/anchor-helper';

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
            workingHoursInput: this.selectDropdownOption(dropdownValueLabel.usWorkHours),
            standardRate: CommonPageHelper.getElementByTitle(inputLabel.standardRate),
            department: this.getDropdownValue(dropdownLabel.department),
            departmentInput: element(By.css('.autoText:last-child')),
            disabled: CommonPageHelper.getElementByTitle(inputLabel.disabled),
            resources: element(By.linkText(inputLabel.resources)),
            firstName: CommonPageHelper.getElementByTitle(inputLabel.firstName),
        };
    }

    static get searchIcon() {
        return element(By.id('toolbar-search-icon'));
    }

    static get searchTextbox() {
        return element(By.id('toolBarResGridSelector'));
    }

    static get gridDetails() {
        return {
            ellipses: element.all(By.css('.GMCell.GMAlignRight.HideCol0Title')),
        };
    }

    static get resources() {
        return {
            resources: element.all(By.css('.GMDataRow .GMNoRight.GMNoLeft')),
        };
    }

    static get ellipsesDropdownForItem() {
        const ellipsesDropdownForItemLabels = CommonPageConstants.contextMenuOptions;
        return {
            viewItem: CommonPageHelper.getContextMenuItemByText(ellipsesDropdownForItemLabels.viewItem),
            deleteItem: CommonPageHelper.getContextMenuItemByText(ellipsesDropdownForItemLabels.deleteItem),
            editItem: CommonPageHelper.getContextMenuItemByText(ellipsesDropdownForItemLabels.editItem),
        };
    }

    static selectDropdownOption(option: string) {
        return element(By.xpath(`//div[${ComponentHelpers.getXPathFunctionForText(option)}]`));
    }

    static getDropdownValue(id: string) {
        return element(By.id(`${id}`));
    }

    static getUserByDisplayName(displayName: string) {
        return AnchorHelper.getElementByTextInsideGrid(displayName);
    }
}
