import {MyWorkPageConstants} from './my-work-page.constants';
import {CommonPage} from '../../common/common.po';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {CommonPageHelper} from '../../common/common-page.helper';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {MyWorkPage} from './my-work.po';
import {AnchorHelper} from '../../../../components/html/anchor-helper';
import {MyWorkplacePage} from '../my-workplace.po';
import {LoginPageHelper} from '../../login/login-page.helper';

export class MyWorkPageHelper {

    static async fillFormAndSave(stepLogger: StepLogger) {
        const uniqueId = PageHelper.getUniqueId();
        const inputLabels = MyWorkPageConstants.inputLabels;

        stepLogger.step(`Title *: New Item`);
        const titleValue = `${inputLabels.title} ${uniqueId}`;
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

        stepLogger.verification('Newly created Item [Ex: Title 1] displayed in "My Work" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(titleValue));
    }

    static async fillTimeOffFormAndSave(stepLogger: StepLogger) {

        const uniqueId = PageHelper.getUniqueId();

        stepLogger.step(`Title *: New Item`);
        const titleValue = `${MyWorkPageConstants.inputLabels.title} ${uniqueId}`;
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

        stepLogger.stepId(6);
        stepLogger.verification('"Navigate to My Time Off page');
        await PageHelper.click( MyWorkplacePage.navigation.myTimeOff);
        stepLogger.verification('"Click on last button');
        await PageHelper.click(MyWorkPage.lastButton);
        stepLogger.verification('Newly created TimeOff [Ex: Title 1] displayed in "My Time Off" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
                    .toBe(true, ValidationsHelper.getLabelDisplayedValidation(titleValue));
    }
}
