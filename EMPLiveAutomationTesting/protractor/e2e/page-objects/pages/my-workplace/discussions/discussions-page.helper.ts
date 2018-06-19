import {StepLogger} from '../../../../../core/logger/step-logger';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {DiscussionsPage} from './discussions.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {CommonPage} from '../../common/common.po';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {DiscussionsPageConstants} from './discussions-page.constants';
import {element, By, browser} from 'protractor';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';
import { CommonPageHelper } from '../../common/common-page.helper';
import { WaitHelper } from '../../../../components/html/wait-helper';
import { MyWorkplacePage } from '../my-workplace.po';
import { CommonPageConstants } from '../../common/common-page.constants';
import {CheckboxHelper} from '../../../../components/html/checkbox-helper';
import {LabelHelper} from '../../../../components/html/label-helper';

export class DiscussionsPageHelper {

    static async fillNewDiscussionFormAndVerify(subject: string, body: string, isQuestion: boolean, stepLogger: StepLogger) {
        stepLogger.step('Enter the subject and body');
        await this.enterSubjectAndBody(subject, body, isQuestion, stepLogger);

        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);

        stepLogger.verification('"New Discussion" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(DiscussionsPageConstants.editPageName));

        const label = DiscussionsPage.allDiscussionItems;
        stepLogger.step(`Newly created Discussion [Ex: Discussion 1] displayed in "Discussions" page`);
        await CommonPageHelper.checkItemCreated(subject, label);
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
        await DiscussionsPageHelper.fillNewDiscussionFormAndVerify(subject, body, false, stepLogger);
    }

    static discussionsItems(classAttribute: string, text: string) {
        const xpath = element.all(By.xpath
            (`//div[${ComponentHelpers.getXPathFunctionForClass(classAttribute, true)}]//span[
                ${ComponentHelpers.getXPathFunctionForDot(text, true)}]`));
        return xpath;
    }

    static async enterSubjectAndBody(subject: string, body: string, isQuestion: boolean, stepLogger: StepLogger) {
        stepLogger.step(`Subject *: New Discussion 1`);
        await TextboxHelper.sendKeys(DiscussionsPage.subjectTextField, subject);

        stepLogger.step(`Body: Enter some text [Ex: Description for New Discussion 1]`);
        await TextboxHelper.sendKeys(DiscussionsPage.bodyTextBox, body);

        stepLogger.verification('Mark check "Question" checkbox');
        await CheckboxHelper.markCheckbox(DiscussionsPage.questionCheckbox, isQuestion);
    }

    static async createNewDiscussion(subject: string, body: string, isQuestion: boolean, stepLogger: StepLogger) {
        stepLogger.step('Navigate to Discussions page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.discussions,
            CommonPage.pageHeaders.myWorkplace.discussions,
            CommonPageConstants.pageHeaders.myWorkplace.discussions,
            stepLogger);

        stepLogger.step('Click on "New discussion" link displayed on top of "Discussions" page');
        await PageHelper.click(DiscussionsPage.newDiscussionLink);

        stepLogger.verification('"Discussion - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(DiscussionsPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(DiscussionsPageConstants.pageName));

        stepLogger.step(`Enter/Select below details in 'New Discussion' page`);
        await this.fillNewDiscussionFormAndVerify(subject, body, isQuestion, stepLogger);
    }

    static async fillNewDiscussionForm(subject: string, body: string, isQuestion: boolean, stepLogger: StepLogger) {
        stepLogger.step('Enter subject and body');
        await this.enterSubjectAndBody(subject, body, isQuestion, stepLogger);
    }

    static async saveDiscussionForm(stepLogger: StepLogger) {
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);

        stepLogger.verification('"New Discussion" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(DiscussionsPageConstants.editPageName));
    }

    static getDiscussionField(textValue: string) {
        return LabelHelper.getSpanByTextInsideListByClassXpath(
            DiscussionsPageConstants.classLabel.postListItemClass,
            textValue);
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
