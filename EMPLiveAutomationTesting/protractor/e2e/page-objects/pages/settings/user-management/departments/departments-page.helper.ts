import {browser} from 'protractor';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../../components/html/page-helper';
import {SettingsPage} from '../../settings.po';
import {CommonPage} from '../../../common/common.po';
import {ExpectationHelper} from '../../../../../components/misc-utils/expectation-helper';
import {DepartmentsPageConstants} from './departments-page.constants';
import {DepartmentsPage} from './departments.po';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {HtmlHelper} from '../../../../../components/misc-utils/html-helper';

export class DepartmentsPageHelper {

    static async navigateToDepartments(stepLogger: StepLogger) {
        stepLogger.step('Click on Settings > User Management > Departments');
        await PageHelper.click(CommonPage.sidebarMenus.settings);
        const userManagementItems = SettingsPage.menuItems.userManagement;
        await PageHelper.click(userManagementItems.rootMenu);
        await ElementHelper.actionHoverOver(userManagementItems.rootMenu);
        await ElementHelper.scrollToBottomOfPage();
        await PageHelper.click(userManagementItems.childMenus.departments);
    }

    static async verifyDepartmentsPageDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(
            DepartmentsPage.addNewItem,
            DepartmentsPageConstants.pageTitle,
            stepLogger
        );
    }

    static async clickAddNewItem(stepLogger: StepLogger) {
        stepLogger.step('Click on Add New Item');
        await PageHelper.click(DepartmentsPage.addNewItem);
    }

    static async verifyAddPageDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(
            DepartmentsPage.addNewItemOptions.title,
            DepartmentsPageConstants.addNewItemPageLabel,
            stepLogger
        );
    }

    static async enterNewTitle(stepLogger: StepLogger) {
        const uniqueId = PageHelper.getUniqueId();
        const departmentTitle = `${DepartmentsPageConstants.newTitleLabel}${uniqueId}`;
        stepLogger.step(`Provide title as "${departmentTitle}"`);
        await TextboxHelper.sendKeys(DepartmentsPage.addNewItemOptions.title, departmentTitle);
        return departmentTitle;
    }

    static async verifyTitleEntered(title: string, stepLogger: StepLogger) {
        await browser.sleep(PageHelper.timeout.s);
        await ExpectationHelper.verifyAttributeValue (
            DepartmentsPage.addNewItemOptions.titlePlaceholder,
            HtmlHelper.attributes.value,
            title,
            stepLogger
        );
    }

    static async selectManagersField(stepLogger: StepLogger) {
        stepLogger.step('Select admin user from Managers field and click on Add');
        const addNewItems = DepartmentsPage.addNewItemOptions;
        const user = await PageHelper.getText(addNewItems.managerPossibleValueDropdownOption);
        await PageHelper.click(addNewItems.managerAdd);
        return user;
    }

    static async verifySelectedManagersField(selectedUser: string, stepLogger: StepLogger) {
        await ExpectationHelper.verifyText(
            DepartmentsPage.addNewItemOptions.managerSelectedValueOption,
            DepartmentsPageConstants.managerSelectedLabel,
            selectedUser,
            stepLogger
        );
    }

    static async selectExecutivesField(stepLogger: StepLogger) {
        stepLogger.step('Select admin.user from Executives field and click on Add');
        const addNewItems = DepartmentsPage.addNewItemOptions;
        const user = await PageHelper.getText(addNewItems.executivesPossibleValueDropdownOption);
        await PageHelper.click(addNewItems.executivesAdd);
        return user;
    }

    static async verifySelectedExecutivesField(selectedUser: string, stepLogger: StepLogger) {
        await ExpectationHelper.verifyText(
            DepartmentsPage.addNewItemOptions.executiveSelectedValueOption,
            DepartmentsPageConstants.executivesSelectedLabel,
            selectedUser,
            stepLogger
        );
    }

    static async clickSave(stepLogger: StepLogger) {
        stepLogger.step('Click Save');
        await PageHelper.click(DepartmentsPage.addNewItemOptions.save);
    }

    static async verifyDepartmentCreated(departmentName: string, stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(
            DepartmentsPage.getCreatedDepartment(departmentName),
            departmentName,
            stepLogger
        );
    }
}
