import {CommonPageHelper} from '../../common/common-page.helper';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {ElementHelper} from '../../../../components/html/element-helper';
import {ChangeItemPage} from './change-item.po';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {ChangeItemPageConstants} from './change-item-page.constants';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {CommonPage} from '../../common/common.po';

export class ChangeItemPageHelper {
    static async fillForm(titleValue: string, priority: string, stepLogger: StepLogger) {
        const labels = ChangeItemPageConstants.inputLabels;
        stepLogger.step('Title *: Random New Change Item');
        await TextboxHelper.sendKeys(ChangeItemPage.inputs.title, titleValue);

        stepLogger.verification('Required values entered/selected in title Field');
        await expect(await TextboxHelper.hasValue(ChangeItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, titleValue));

        stepLogger.step('Click on projectShowAllButton');
        await PageHelper.click(ChangeItemPage.projectShowAllButton);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ChangeItemPage.inputs.project);
        stepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');
        const projectName = await ChangeItemPage.inputs.project.getText();
        await PageHelper.click(ChangeItemPage.inputs.project);

        stepLogger.verification('Required values entered/selected in Project Field');
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(projectName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.project, projectName));

        stepLogger.step(`Priority: Select the value "${priority}"`);
        await PageHelper.sendKeysToInputField(ChangeItemPage.inputs.priority, priority);

        stepLogger.verification(`Verify - Priority: Select the value  "${priority}"`);
        await expect(await ElementHelper.hasSelectedOption(ChangeItemPage.inputs.priority, priority))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.priority, priority));

        stepLogger.stepId(5);
        stepLogger.step('Click on "Save" button in "Changes - New Item" window');
        await PageHelper.click(CommonPage.formButtons.save);

        return projectName;
    }
}
