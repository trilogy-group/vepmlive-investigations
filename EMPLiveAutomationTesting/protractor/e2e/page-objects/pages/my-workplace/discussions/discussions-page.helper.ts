import {browser, By, element} from 'protractor';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {DiscussionsPage} from './discussions.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {CommonPage} from '../../common/common.po';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {DiscussionsPageConstants} from './discussions-page.constants';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';
import {CommonPageHelper} from '../../common/common-page.helper';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {MyWorkplacePage} from '../my-workplace.po';
import {CommonPageConstants} from '../../common/common-page.constants';
import {CheckboxHelper} from '../../../../components/html/checkbox-helper';
// import {LinkPage} from "../link/link.po";
import {ExpectationHelper} from '../../../../components/misc-utils/expectation-helper';
import {ElementHelper} from '../../../../components/html/element-helper';

export class DiscussionsPageHelper {

    static async fillNewDiscussionFormAndVerify(subject: string, body: string, isQuestion: boolean) {
        StepLogger.step('Enter the subject and body');
        await this.enterSubjectAndBody(subject, body, isQuestion);

        StepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);

        StepLogger.subStep('Click on Close button');
        await PageHelper.click(CommonPage.formButtons.close);

        StepLogger.verification('"New Discussion" page is closed');
        await WaitHelper.waitForElementToBeHidden(CommonPage.formButtons.close);
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(DiscussionsPageConstants.editPageName));

        // const label = DiscussionsPage.allDiscussionItems;
        StepLogger.step(`Newly created Discussion [Ex: Discussion 1] displayed in "Discussions" page`);
        await this.verifyNewDiscussionAdded(subject);
        // await CommonPageHelper.checkItemCreated(subject, label);
    }

    static async addDiscussion() {
        StepLogger.step('preCondition: navigate to Discussions page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.discussions,
            CommonPage.pageHeaders.myWorkplace.discussions,
            CommonPageConstants.pageHeaders.myWorkplace.discussions,
        );
        StepLogger.stepId(1);
        StepLogger.step('Click on "+ new discussion" link displayed on top of "Discussions" page');
        await PageHelper.click(DiscussionsPage.newDiscussionLink);
        StepLogger.verification('"Discussion - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(DiscussionsPageConstants.pagePrefix, ValidationsHelper.getPageDisplayedValidation(DiscussionsPageConstants.pageName));
        StepLogger.stepId(2);
        StepLogger.step(`Enter/Select below details in 'New Discussion' page`);
        const labels = DiscussionsPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const subject = `${labels.subject} ${uniqueId}`;
        const body = `${labels.body} ${uniqueId}`;
        await DiscussionsPageHelper.fillNewDiscussionFormAndVerify(subject, body, false);

        return subject;
    }

    static discussionsItems(classAttribute: string, text: string) {
        const xpath = element.all(By.xpath
        (`//div[${ComponentHelpers.getXPathFunctionForClass(classAttribute, true)}]//span[
                ${ComponentHelpers.getXPathFunctionForDot(text, true)}]`));
        return xpath;
    }

    static async enterSubjectAndBody(subject: string, body: string, isQuestion: boolean) {
        StepLogger.step(`Subject *: New Discussion 1`);
        await TextboxHelper.sendKeys(DiscussionsPage.subjectTextField, subject);

        StepLogger.step(`Body: Enter some text [Ex: Description for New Discussion 1]`);
        await TextboxHelper.sendKeys(DiscussionsPage.bodyTextBox, body);

        StepLogger.verification('Mark check "Question" checkbox');
        await CheckboxHelper.markCheckbox(DiscussionsPage.questionCheckbox, isQuestion);
    }

    static async createNewDiscussion(subject: string, body: string, isQuestion: boolean) {
        StepLogger.step('Navigate to Discussions page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.discussions,
            CommonPage.pageHeaders.myWorkplace.discussions,
            CommonPageConstants.pageHeaders.myWorkplace.discussions,
        );

        StepLogger.step('Click on "New discussion" link displayed on top of "Discussions" page');
        await PageHelper.click(DiscussionsPage.newDiscussionLink);

        StepLogger.verification('"Discussion - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(DiscussionsPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(DiscussionsPageConstants.pageName));

        StepLogger.step(`Enter/Select below details in 'New Discussion' page`);
        await this.fillNewDiscussionFormAndVerify(subject, body, isQuestion);
    }

    static async fillNewDiscussionForm(subject: string, body: string, isQuestion: boolean) {
        StepLogger.step('Enter subject and body');
        await this.enterSubjectAndBody(subject, body, isQuestion);
    }

    static async saveDiscussionForm() {
        StepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);

        StepLogger.verification('"New Discussion" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(DiscussionsPageConstants.editPageName));
    }

    static async deleteGridGantt() {
        await browser.sleep(PageHelper.timeout.m);
        if (await DiscussionsPage.menueLink.first().isPresent() === true) {
            await PageHelper.click(DiscussionsPage.menueLink.first());
            await PageHelper.click(DiscussionsPage.delete);
            await browser.switchTo().alert().accept();
            // After save It need static wait(5 sec) and no element found which get change after save.
            await browser.sleep(PageHelper.timeout.m);

            if (await DiscussionsPage.menueLink.first().isPresent() === true) {
                await this.deleteGridGantt();
            }
        }
    }

    static getDiscussionFieldSelector(text: string) {
        return {
            subject: CommonPageHelper.getDivByText(text),
            body: CommonPageHelper.getDivByText(text)
        };
    }

    static async search(titleToSearch: string) {
        await CommonPageHelper.searchItemByTitle(titleToSearch, 'Subject');
        await WaitHelper.waitForElementToBePresent(DiscussionsPage.getDiscussionField(titleToSearch));
    }

    static async verifyNewDiscussionAdded(subject: string) {
        StepLogger.subVerification('Newly added Discussion is displayed in the list');
        const item = DiscussionsPage.discussionInList.trTag(subject);
        await PageHelper.click(CommonPage.lastButton);
        await WaitHelper.waitForElementToBeDisplayed(item);
        await ElementHelper.scrollToElement(item);
        await ExpectationHelper.verifyDisplayedStatus(item, subject);
    }

}
