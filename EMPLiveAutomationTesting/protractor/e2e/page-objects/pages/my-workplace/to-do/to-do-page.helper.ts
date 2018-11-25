import {browser} from 'protractor';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {ElementHelper} from '../../../../components/html/element-helper';
import {ToDoPage} from './to-do.po';
import {CommonPage} from '../../common/common.po';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {ToDoPageConstants} from './to-do-page.constants';
import {PageHelper} from '../../../../components/html/page-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';

export class ToDoPageHelper {

    static async fillFormAndSave(title: string, status: string, description: string) {
        const labels = ToDoPageConstants.inputLabels;

        StepLogger.step(`Title *: New To Do 1`);
        await TextboxHelper.sendKeys(ToDoPage.inputs.title, title);

        StepLogger.step(` Status: Select value 'Not Started'', if not selected already`);
        await PageHelper.sendKeysToInputField(ToDoPage.inputs.status, status);

        StepLogger.step(`Description: Enter some text [Ex: Description for New To Do 1]`);
        await TextboxHelper.sendKeys(ToDoPage.inputs.description, description);

        StepLogger.verification('Required values Entered/Selected in "Edit To Do" Page');
        StepLogger.verification('Verify - Title *: Random New To Do Item');
        await expect(await TextboxHelper.hasValue(ToDoPage.inputs.title, title))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, title));

        StepLogger.verification('Verify - Status: Select the value "In Progress"');
        await expect(await ElementHelper.hasSelectedOption(ToDoPage.inputs.status, status))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.status, status));

        StepLogger.verification('Verify - Description: Random value');
        await expect(await TextboxHelper.hasValue(ToDoPage.inputs.description, description))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.description, description));

        StepLogger.stepId(5);
        StepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);

        StepLogger.verification('"New To Do" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ToDoPageConstants.editPageName));
    }

    static async deleteGridGantt() {
        await browser.sleep(PageHelper.timeout.m);
        if (await ToDoPage.menueLink.first().isPresent() === true) {
            await PageHelper.click(ToDoPage.menueLink.first());
            await PageHelper.click(ToDoPage.delete);
            await PageHelper.acceptAlert();

            if (await ToDoPage.menueLink.first().isPresent() === true) {
                await this.deleteGridGantt();
            }
        }
    }
}
