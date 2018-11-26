import {By, element} from 'protractor';

import {BasePage} from '../../../base-page';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {DepartmentsPageConstants} from './departments-page.constants';
import {CommonPageHelper} from '../../../common/common-page.helper';

export class DepartmentsPage extends BasePage {
    static get addNewItem() {
        return AnchorHelper.getAnchorById('idHomePageNewItem');
    }

    static get addNewItemOptions() {
        const addNewItemLabels = DepartmentsPageConstants.addNewItemOptions;
        const managerTable = 'table[id*="Managers"]';
        const executiveTable = 'table[id*="Executives"]';
        return {
            title: CommonPageHelper.getElementByTitle(addNewItemLabels.title),
            titlePlaceholder: element(By.css('div#WPQ2ClientFormPlaceholder>input:first-child')),
            parentDepartmentDropdown: CommonPageHelper.getElementByTitle(addNewItemLabels.parentDepartment),
            managerPossibleValueDropdown: CommonPageHelper.getElementByTitle(addNewItemLabels.managerPossibleValue),
            managerPossibleValueDropdownOption: element(By.css(`[title="${addNewItemLabels.managerPossibleValue}"] > option:first-child`)),
            managerSelectedValueOption: element(By.css(`[title="${addNewItemLabels.managerSelectedValue}"] > option:first-child`)),
            managerAdd: element(By.css(`${managerTable} input[value="${addNewItemLabels.add}"]`)),
            managerRemove: element(By.css(`${managerTable} input[value="${addNewItemLabels.remove}"]`)),
            executivesPossibleValueDropdown: CommonPageHelper.getElementByTitle(addNewItemLabels.managerSelectedValue),
            executivesPossibleValueDropdownOption: element(By.css(
                `[title="${addNewItemLabels.managerSelectedValue}"] > option:first-child`)),
            executiveSelectedValueOption: element(By.css(`[title="${addNewItemLabels.executivesSelectedValue}"] > option:first-child`)),
            executivesAdd: element(By.css(`${executiveTable} input[value="${addNewItemLabels.add}"]`)),
            executivesRemove: element(By.css(`${executiveTable} input[value="${addNewItemLabels.remove}"]`)),
            save: element(By.id(addNewItemLabels.save)),
            cancel: CommonPageHelper.getElementByTitle(addNewItemLabels.cancel),
        };
    }

    static getCreatedDepartment(departmentName: string) {
        return AnchorHelper.getAnchorByText(departmentName);
    }
}
