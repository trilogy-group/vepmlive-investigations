import {StepLogger} from '../../../../../core/logger/step-logger';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {DiscussionsPage} from './discussions.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {CommonPage} from '../../common/common.po';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {DiscussionsPageConstants} from './discussions-page.constants';
import { CommonPageHelper } from '../../common/common-page.helper';
import { WaitHelper } from '../../../../components/html/wait-helper';
import { MyWorkplacePage } from '../my-workplace.po';
import { CommonPageConstants } from '../../common/common-page.constants';
import {CheckboxHelper} from '../../../../components/html/checkbox-helper';

export class DiscussionsPageHelper {

    static async fillNewDiscussionFormAndVerify(subject: string, body: string, isQuestion: boolean, stepLogger: StepLogger) {

        await this.enterSubjectAndBody(subject, body, isQuestion, stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);

        stepLogger.verification('"New Discussion" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(DiscussionsPageConstants.editPageName));
    }
  
    static async addDiscussion(stepLogger: StepLogger) {
        stepLogger.step('PRECONDITION: navigate to Discussions page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.discussions,
            CommonPage.pageHeaders.myWorkplace.discussions,
            CommonPageConstants.pageHeaders.myWorkplace.discussions,
            stepLogger
        );
        stepLogger.stepId(1);
        stepLogger.step('Click on "+ new discussion" link displayed on top of "Discussions" page');
        await PageHelper.click(DiscussionsPage.newDiscussionLink);
        stepLogger.verification('"Discussion - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(DiscussionsPageConstants.pagePrefix, ValidationsHelper.getPageDisplayedValidation(DiscussionsPageConstants.pageName));
        stepLogger.stepId(2);
        stepLogger.step(`Enter/Select below details in 'New Discussion' page`);
        const labels = DiscussionsPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const subject = `${labels.subject} ${uniqueId}`;
        const body = `${labels.body} ${uniqueId}`;
        await DiscussionsPageHelper.fillNewDiscussionFormAndVerify(subject, body, stepLogger);
    }    

    static async enterSubjectAndBody(subject: string, body: string, isQuestion: boolean, stepLogger: StepLogger) {
        stepLogger.step(`Subject *: New Discussion 1`);
        await TextboxHelper.sendKeys(DiscussionsPage.subjectTextField, subject);

        stepLogger.step(`Body: Enter some text [Ex: Description for New Discussion 1]`);
        await TextboxHelper.sendKeys(DiscussionsPage.bodyTextBox, body);

        stepLogger.verification('Mark check "Question" checkbox');
        await CheckboxHelper.markCheckbox(DiscussionsPage.questionCheckbox, isQuestion);
    }
}
