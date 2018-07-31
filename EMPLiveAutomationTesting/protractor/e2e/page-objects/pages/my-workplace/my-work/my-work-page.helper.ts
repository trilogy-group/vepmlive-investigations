import {MyWorkPageConstants} from './my-work-page.constants';
import {CommonPage} from '../../common/common.po';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {CommonPageHelper} from '../../common/common-page.helper';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {MyWorkPage} from './my-work.po';
import {LoginPageHelper} from '../../login/login-page.helper';
import {AnchorHelper} from '../../../../components/html/anchor-helper';
import {CommonPageConstants} from '../../common/common-page.constants';
import {browser} from 'protractor';

export class MyWorkPageHelper {

    static async fillFormAndSave(stepLogger: StepLogger) {
        const inputLabels = MyWorkPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const titleValue = `${inputLabels.title} ${uniqueId}`;

        stepLogger.step(`Title *: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, titleValue);

        stepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');
        await PageHelper.click(MyWorkPage.dropdownAll.project);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(MyWorkPage.inputs.project);
        const projectName = await MyWorkPage.inputs.project.getText();
        await PageHelper.click(MyWorkPage.inputs.project);

        stepLogger.verification('Required values entered/selected in Project Field');
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(projectName).isPresent())
            .toBe(true, ValidationsHelper.getFieldShouldHaveValueValidation(inputLabels.project, projectName));

        stepLogger.step(`Assigned To: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.assignedTo, LoginPageHelper.adminEmailId);
        stepLogger.step(`select assignedTo value`);
        await PageHelper.click(MyWorkPage.selectValueFromSuggestions(LoginPageHelper.adminEmailId));

        stepLogger.stepId(5);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"New Item" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(MyWorkPageConstants.editPageName));
        // Wait for the page to close after clicking on save. This is to reduce window close synchronization issues
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.m);

        stepLogger.verification('Newly created Item [Ex: Title 1] displayed in "My Work" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(titleValue));
    }

    static async fillTimeOffFormAndSave(titleValue: string, stepLogger: StepLogger) {

        stepLogger.step(`Title *: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, titleValue);

        stepLogger.step('Time Off Type *: Select any type from the drop down [Ex: Holiday])');
        await PageHelper.click(MyWorkPage.dropdownAll.timeOffType);
        await PageHelper.click(MyWorkPage.dropdownAll.timeOffInput);

        stepLogger.step(`Requestor* : New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.requestor, LoginPageHelper.adminEmailId);
        stepLogger.step(`select Requester* value`);
        await PageHelper.click(MyWorkPage.selectValueFromSuggestions(LoginPageHelper.adminEmailId));

        stepLogger.step(`Enter Start Date: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.start, CommonPageHelper.getTodayInMMDDYYYY);

        stepLogger.step(`Enter Finish Date: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.finish, CommonPageHelper.getYesterdayInMMDDYYYY);

        stepLogger.stepId(5);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"New Item" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(MyWorkPageConstants.editPageName));
        // Wait for the page to close after clicking on save. This is to reduce window close synchronization issues
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.m);
    }

    static async clickOnPageTab(stepLogger: StepLogger) {
        stepLogger.step('Click on "Page" tab');
        await PageHelper.click(CommonPage.ribbonTitles.page);
    }

    static async verifyMyWorkPageDisplayed(stepLogger: StepLogger) {
        stepLogger.verification(`verify "My Work"  page is displayed`);
        const panelHeadingDisplayed = await PageHelper.isElementDisplayed(
            CommonPage.pageHeaders.myWorkplace.myWork);
        await expect(panelHeadingDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            CommonPageConstants.pageHeaders.myWorkplace.myWork));
    }

    static async expandEditPageDropdown(stepLogger: StepLogger) {
        stepLogger.step(`click on "Edit Page" dropdown`);
        await PageHelper.click(MyWorkPage.editPageDropdown);
    }

    static async verifyEditPageDropdownOptions(stepLogger: StepLogger) {
        stepLogger.verification(`verify "Edit Page" option is shown`);
        const editPageDisplayed = await PageHelper.isElementDisplayed(
            MyWorkPage.editPageMenuOption);
        await expect(editPageDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            MyWorkPageConstants.editPageActions.editPage));

        stepLogger.verification(`verify "Stop Editing" option is shown as disabled`);
        const stopEditingDisplayed = await PageHelper.isElementDisplayed(
            MyWorkPage.disabledStopEditingOption);
        await expect(stopEditingDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            MyWorkPageConstants.editPageActions.stopEditing));
    }

    static async clickOnEditPageMenuOption(stepLogger: StepLogger) {
        stepLogger.step(`click on "Edit Page" option from dropdown`);
        await PageHelper.click(MyWorkPage.editPageMenuOption);
    }

    static async verifyEditPageOpened(stepLogger: StepLogger) {
        stepLogger.verification(`verify "Edit Page" opens`);
        const editPageDisplayed = await PageHelper.isElementDisplayed(
            MyWorkPage.editPage);
        await expect(editPageDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            MyWorkPageConstants.editPageActions.editPage));
    }

    static  async verifyPageTabIsSelected(stepLogger: StepLogger) {
        stepLogger.verification(`verify "PageTab" is shown as selected`);
        const tabDisplayed = await PageHelper.isElementDisplayed(MyWorkPage.selectedPageTab);
        await expect(tabDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            CommonPageConstants.ribbonMenuTitles.page));
    }

    static async fillAndSubmitSaveView(viewName: string) {
        const label = MyWorkPage.viewsPopup;
        await PageHelper.click(label.name);
        // await label.name.clear();
        await TextboxHelper.sendKeys(label.name, viewName);
        // await PageHelper.sendKeysToInputField(label.name, viewName);
        if (!(label.defaultView.isSelected())) {
            label.defaultView.click();
        }
        if (!(label.personalView.isSelected())) {
            label.defaultView.click();
        }
        await PageHelper.click(label.ok);
    }

    static async fillAndSubmitRenameView() {
        const uniqueId = PageHelper.getUniqueId();
        const viewNewName = `${MyWorkPageConstants.renameView}${uniqueId}`;
        await TextboxHelper.sendKeys(MyWorkPage.viewsPopup.newName, viewNewName);
        await PageHelper.click(MyWorkPage.viewsPopup.ok);
        return viewNewName;
    }
    static async verifyAndAcceptRenameConfirmationPopup(viewName: string) {
       await  browser.switchTo().alert().getText().then(function (popUpText) {
           expect(popUpText).toBe(`Would you like to rename the "${viewName}" view?`);
       });
       await PageHelper.acceptAlert();
    }
}
