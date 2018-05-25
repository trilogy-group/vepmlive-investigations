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

export class MyWorkPageHelper {

    static async fillFormAndSave(titleValue: string, stepLogger: StepLogger) {
        const inputLabels = MyWorkPageConstants.inputLabels;

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
}
