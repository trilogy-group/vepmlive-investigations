import {By, element} from 'protractor';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {CommonPage} from '../../common/common.po';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {MyTimeOffPageConstants} from './my-time-off-page.constants';
import {PageHelper} from '../../../../components/html/page-helper';
import {MyTimeOffPage} from './my-time-off.po';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../common/common-page.helper';
import {StepLogger} from '../../../../../core/logger/step-logger';

export class MyTimeOffPageHelper {

    static async fillFormAndVerify(title: string, timeOffType: string, requestor: string, startDate: string,
                                   finishDate: string) {
        const labels = MyTimeOffPageConstants.inputLabels;
        const inputs = MyTimeOffPage.inputs;

        StepLogger.step(`Title *: New Time Off`);
        await TextboxHelper.sendKeys(MyTimeOffPage.inputs.title, title);

        StepLogger.step(` Time Off Type: Select value if not selected already`);
        await PageHelper.sendKeysToInputField(MyTimeOffPage.inputs.timeOffType, timeOffType);

        StepLogger.step('Select any Time OFf type from the drop down');
        await PageHelper.click(MyTimeOffPage.timeOffTypeShowAllButton);
        await WaitHelper.waitForElementToBeDisplayed(inputs.timeOffType);
        const timeOffName = await inputs.timeOffType.getText();

        StepLogger.verification('Required values selected in Time Off type Field');
        await PageHelper.click(inputs.timeOffType);
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(timeOffName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.timeOffType, timeOffName));

        StepLogger.step(`Requestor: Enter logged in user name`);
        await TextboxHelper.sendKeys(MyTimeOffPage.inputs.requestor, requestor);

        StepLogger.step(`Start: Select a Start date`);
        await TextboxHelper.sendKeys(MyTimeOffPage.inputs.start, startDate);

        StepLogger.step(`Finish: Select a Finish date`);
        await TextboxHelper.sendKeys(MyTimeOffPage.inputs.finish, finishDate);

        StepLogger.verification('Required values Entered/Selected in "Edit Time Off" Page');
        StepLogger.verification('Verify - Title *: Random New Time Off Item');
        await expect(await TextboxHelper.hasValue(MyTimeOffPage.inputs.title, title))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, title));

        StepLogger.verification('Verify - Requester: User name');
        await expect(await TextboxHelper.hasValue(MyTimeOffPage.inputs.requestor, requestor))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.requestor, requestor));

        StepLogger.verification('Verify - Start Date value');
        await expect(await TextboxHelper.hasValue(MyTimeOffPage.inputs.start, startDate))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.start, startDate));

        StepLogger.verification('Verify - Finish Date value');
        await expect(await TextboxHelper.hasValue(MyTimeOffPage.inputs.finish, finishDate))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.finish, finishDate));

        StepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);

        // Wait for the page to close after clicking on save. This is to reduce window close synchronization issues
        await WaitHelper.staticWait(PageHelper.timeout.m);

        StepLogger.verification('"New Time Off" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(MyTimeOffPageConstants.editPageName));

        StepLogger.step(`click on Close button`);
        await PageHelper.click(MyTimeOffPage.closeButton);
    }

    static getXpathForInputByLabel(type: string, title: string) {
        return `//table[contains(@class,"ms-formtable")]//td[normalize-space(.)='${title}']//parent::tr//${type}[not(@type='hidden')]`;
    }

    static getElementByType(type: string) {
        const xpath = `[type="${type}"]`;
        return element(By.css(xpath));
    }
}
