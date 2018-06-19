import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {ElementHelper} from '../../../../components/html/element-helper';
import {ToDoPage} from './to-do.po';
import {CommonPage} from '../../common/common.po';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {ToDoPageConstants} from './to-do-page.constants';
import {PageHelper} from '../../../../components/html/page-helper';
import {browser, By, element} from 'protractor';

export class ToDoPageHelper {

    static async fillFormAndSave(title: string, status: string, description: string, stepLogger: StepLogger) {
        const labels = ToDoPageConstants.inputLabels;

        stepLogger.step(`Title *: New To Do 1`);
        await TextboxHelper.sendKeys(ToDoPage.inputs.title, title);

        stepLogger.step(` Status: Select value 'Not Started'', if not selected already`);
        await PageHelper.sendKeysToInputField(ToDoPage.inputs.status, status);

        stepLogger.step(`Description: Enter some text [Ex: Description for New To Do 1]`);
        await TextboxHelper.sendKeys(ToDoPage.inputs.description, description);

        stepLogger.verification('Required values Entered/Selected in "Edit To Do" Page');
        stepLogger.verification('Verify - Title *: Random New To Do Item');
        await expect(await TextboxHelper.hasValue(ToDoPage.inputs.title, title))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, title));

        stepLogger.verification('Verify - Status: Select the value "In Progress"');
        await expect(await ElementHelper.hasSelectedOption(ToDoPage.inputs.status, status))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.status, status));

        stepLogger.verification('Verify - Description: Random value');
        await expect(await TextboxHelper.hasValue(ToDoPage.inputs.description, description))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.description, description));

        stepLogger.stepId(5);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);

        stepLogger.verification('"New To Do" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ToDoPageConstants.editPageName));
    }

    static get menueLink() {
        return element.all(By.xpath(`${this.gridTab}//*[contains(@class,'menuLink')]`));
    }

    static get gridTab() {
        return `//span[contains(@title,'Un') or contains(@title,'grid')]//parent::div`;
    }

    static get delete() {
        return element(By.css('[title= "Delete"]'));
    }

    static get gridGantt() {
        return element(By.id('GanttGrid0Main'));
    }

    static async deleteGridGantt() {
        await browser.sleep(PageHelper.timeout.m);
        if (await this.menueLink.first().isPresent() === true) {
            await PageHelper.click(this.menueLink.first());
            await PageHelper.click(this.delete);
            await browser.switchTo().alert().accept();
            // After save It need static wait(5 sec) and no element found which get change after save.
            await browser.sleep(PageHelper.timeout.m);

            if (await this.menueLink.first().isPresent() === true) {
                await this.deleteGridGantt();
            }
        }
    }
}
