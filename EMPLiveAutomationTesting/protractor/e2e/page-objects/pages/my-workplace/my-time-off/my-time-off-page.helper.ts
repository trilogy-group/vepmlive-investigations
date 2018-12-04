import { By, element } from 'protractor';

import { ValidationsHelper } from '../../../../components/misc-utils/validation-helper';
import { CommonPage } from '../../common/common.po';
import { TextboxHelper } from '../../../../components/html/textbox-helper';
import { MyTimeOffPageConstants } from './my-time-off-page.constants';
import { PageHelper } from '../../../../components/html/page-helper';
import { MyTimeOffPage } from './my-time-off.po';
import { StepLogger } from '../../../../../core/logger/step-logger';
import { ExpectationHelper } from '../../../../components/misc-utils/expectation-helper';

export class MyTimeOffPageHelper {

    static async fillFormAndVerify(title: string, timeOffType: string, requestor: string, startDate: string,
                                   finishDate: string, toVerify = true) {
        const labels = MyTimeOffPageConstants.inputLabels;
        const inputs = MyTimeOffPage.inputs;

        StepLogger.step(`Title *: New Time Off`);
        await TextboxHelper.sendKeys(MyTimeOffPage.inputs.title, title);

        StepLogger.step(` Time Off Type: Select value if not selected already`);
        await PageHelper.click(MyTimeOffPage.timeOffTypeShowAllButton);
        await PageHelper.click(MyTimeOffPage.timeOffTypeValues(timeOffType));

        StepLogger.step(`Requestor: Enter logged in user name`);
        await TextboxHelper.sendKeys(inputs.requestor, requestor);

        StepLogger.step(`Start: Select a Start date`);
        await TextboxHelper.sendKeys(inputs.start, startDate);

        StepLogger.step(`Finish: Select a Finish date`);
        await TextboxHelper.sendKeys(inputs.finish, finishDate);

        StepLogger.verification('Required values Entered/Selected in "Edit Time Off" Page');
        StepLogger.verification('Verify - Title *: Random New Time Off Item');
        await expect(await TextboxHelper.hasValue(inputs.title, title))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, title));

        StepLogger.verification('Verify - Requester: User name');
        await expect(await TextboxHelper.hasValue(inputs.requestor, requestor))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.requestor, requestor));

        StepLogger.verification('Verify - Start Date value');
        await expect(await TextboxHelper.hasValue(inputs.start, startDate))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.start, startDate));

        StepLogger.verification('Verify - Finish Date value');
        await expect(await TextboxHelper.hasValue(inputs.finish, finishDate))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.finish, finishDate));

        StepLogger.step('Click on save');
        await PageHelper.clickAndWaitForElementToHide(CommonPage.formButtons.save);

        StepLogger.verification('"New Time Off" page is closed');
        await ExpectationHelper.verifyNotDisplayedStatus(CommonPage.formButtons.save, MyTimeOffPageConstants.editPageName);

        if (toVerify) {
            StepLogger.subVerification('Newly created Time Off item details displayed in read only mode');
            await ExpectationHelper.verifyText(CommonPage.contentTitleInViewMode,
                ValidationsHelper.getLabelDisplayedValidation(title), title);

            StepLogger.step(`click on Close button`);
            await PageHelper.clickIfDisplayed(MyTimeOffPage.closeButton);
        }
    }

    static getXpathForInputByLabel(type: string, title: string) {
        return `//table[contains(@class,"ms-formtable")]//td[normalize-space(.)='${title}']//parent::tr//${type}[not(@type='hidden')]`;
    }

    static getElementByType(type: string) {
        const xpath = `[type="${type}"]`;
        return element(By.css(xpath));
    }
}
