import {StepLogger} from '../../../../../core/logger/step-logger';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {DiscussionsPage} from './discussions.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {CommonPage} from '../../common/common.po';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {DiscussionsPageConstants} from './discussions-page.constants';
import {element, By} from 'protractor';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';

export class DiscussionsPageHelper {

    static async fillNewDiscussionFormAndVerify(subject: string, body: string, stepLogger: StepLogger) {

        stepLogger.step(`Subject *: New Discussion 1`);
        await TextboxHelper.sendKeys(DiscussionsPage.subjectTextField, subject);

        stepLogger.step(`Body: Enter some text [Ex: Description for New Discussion 1]`);
        await TextboxHelper.sendKeys(DiscussionsPage.bodyTextBox, body);

        stepLogger.verification('Mark check "Question" checkbox');
        await PageHelper.click(DiscussionsPage.questionCheckbox);

        stepLogger.stepId(3);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);

        stepLogger.verification('"New Discussion" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(DiscussionsPageConstants.editPageName));
    }

    static getAllDiscussionsListing(text: string) {
        const xpath = element.all(By.xpath
            (`//div[contains(@class,'postMainContainer')]//span[${ComponentHelpers.getXPathFunctionForDot(text, true)}]`));
        return xpath;
    }
}
