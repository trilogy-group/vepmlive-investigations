import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {CommonPage} from '../../common/common.po';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {MyTimeOffPageConstants} from './my-time-off-page.constants';
import {PageHelper} from '../../../../components/html/page-helper';
import {MyTimeOffPage} from './my-time-off.po';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../common/common-page.helper';

export class MyTimeOffPageHelper {

    static async fillFormAndVerify(title: string, timeOffType: string, requestor: string, startDate: string,
                                   finishDate: string, stepLogger: StepLogger) {
        const labels = MyTimeOffPageConstants.inputLabels;
        const inputs = MyTimeOffPage.inputs;

        stepLogger.step(`Title *: New Time Off`);
        await TextboxHelper.sendKeys(MyTimeOffPage.inputs.title, title);

        stepLogger.step(` Time Off Type: Select value 'Holiday'', if not selected already`);
        await PageHelper.sendKeysToInputField(MyTimeOffPage.inputs.timeOffType, timeOffType);

        stepLogger.step('Select any Time OFf type from the drop down');
        await PageHelper.click(MyTimeOffPage.timeOffTypeShowAllButton);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(inputs.timeOffType);
        const timeOffName = await inputs.timeOffType.getText();

        stepLogger.verification('Required values selected in Time Off type Field');
        await PageHelper.click(inputs.timeOffType);
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(timeOffName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.timeOffType, timeOffName));

        stepLogger.step(`Requestor: Enter logged in user name`);
        await TextboxHelper.sendKeys(MyTimeOffPage.inputs.requestor, requestor);

        stepLogger.step(`Start: Select a Start date`);
        await TextboxHelper.sendKeys(MyTimeOffPage.inputs.start, startDate);

        stepLogger.step(`Finish: Select a Finish date`);
        await TextboxHelper.sendKeys(MyTimeOffPage.inputs.finish, finishDate);

        stepLogger.verification('Required values Entered/Selected in "Edit Time Off" Page');
        stepLogger.verification('Verify - Title *: Random New Time Off Item');
        await expect(await TextboxHelper.hasValue(MyTimeOffPage.inputs.title, title))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, title));

        stepLogger.verification('Verify - Requester: User name');
        await expect(await TextboxHelper.hasValue(MyTimeOffPage.inputs.requestor, requestor))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.requestor, requestor));

        stepLogger.verification('Verify - Start Date value');
        await expect(await TextboxHelper.hasValue(MyTimeOffPage.inputs.start, startDate))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.start, startDate));

        stepLogger.verification('Verify - Finish Date value');
        await expect(await TextboxHelper.hasValue(MyTimeOffPage.inputs.finish, finishDate))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.finish, finishDate));

        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);

        stepLogger.verification('"New Time Off" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(MyTimeOffPageConstants.editPageName));
    }

    static getXpathForInputByLabel(type: string, title: string) {
        return `//table[contains(@class,"ms-formtable")]//td[normalize-space(.)='${title}']//parent::tr//${type}[not(@type='hidden')]`;
    }

}
