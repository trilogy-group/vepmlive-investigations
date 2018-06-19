import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {DiscussionsPageHelper} from '../../../../../page-objects/pages/my-workplace/discussions/discussions-page.helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {DiscussionsPageConstants} from '../../../../../page-objects/pages/my-workplace/discussions/discussions-page.constants';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {DiscussionsPage} from '../../../../../page-objects/pages/my-workplace/discussions/discussions.po';
import {SocialStreamPageConstants} from '../../../../../page-objects/pages/settings/social-stream/social-stream-page.constants';
import {ToDoPageHelper} from '../../../../../page-objects/pages/my-workplace/to-do/to-do-page.helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {SocialStreamPage} from '../../../../../page-objects/pages/settings/social-stream/social-stream.po';
import {browser} from 'protractor';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Navigate to Discussions page - [785609]', async () => {
        const stepLogger = new StepLogger(785609);
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.discussions,
            CommonPage.pageHeaders.myWorkplace.discussions,
            CommonPageConstants.pageHeaders.myWorkplace.discussions,
            stepLogger);
    });

    it('Add a New Discussion - [785611]', async () => {
        const stepLogger = new StepLogger(785611);
        await DiscussionsPageHelper.addDiscussion(stepLogger);
    });

    it('Edit Discussion from Workplace - [1175265]', async () => {
        const stepLogger = new StepLogger(1175265);

        stepLogger.step(`Precondition: Create new discussion`);
        const labels = DiscussionsPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const subject = `${labels.subject} ${uniqueId}`;
        const body = `${labels.body} ${uniqueId}`;
        let isQuestion = true;
        await DiscussionsPageHelper.createNewDiscussion(subject, body, isQuestion, stepLogger);

        stepLogger.stepId(1);
        stepLogger.stepId(2);
        // Step #1 and #2 Inside this function
        stepLogger.step('Navigate to Discussions page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.discussions,
            CommonPage.pageHeaders.myWorkplace.discussions,
            CommonPageConstants.pageHeaders.myWorkplace.discussions,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Mouse over the Discussion created as per pre requisites that need to be ' +
            'edited Click on the Ellipses button (...) and select Edit Item from the options displayed');
        await PageHelper.click(DiscussionsPageHelper.getDiscussionField(subject));
        await PageHelper.click(DiscussionsPage.buttonSelector.edit);

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select below details in Edit Discussion page Subject *: Updated New Discussion 1 Body: Update ' +
            'the text [Ex: Updated new Discussion used for Smoke Test Case creation] Question: Leave the check box unchecked/un selected');
        const newUniqueId = PageHelper.getUniqueId();
        const newSubject = `${labels.subject} ${newUniqueId}`;
        const newBody = `${labels.body} ${newUniqueId}`;
        isQuestion = false;
        await DiscussionsPageHelper.fillNewDiscussionForm(newSubject, newBody, isQuestion, stepLogger);

        stepLogger.stepId(5);
        stepLogger.step('Click save button');
        await DiscussionsPageHelper.saveDiscussionForm(stepLogger);

        stepLogger.verification('Updated Discussion item details subject displayed in the list');
        await expect(await PageHelper.isElementDisplayed(DiscussionsPage.getDiscussionFieldSelector(newSubject).subject))
            .toBe(true, ValidationsHelper.getDisplayedValidation(DiscussionsPageConstants.inputLabels.subject));

        stepLogger.verification('Updated Discussion item details body displayed in the list');
        await expect(await PageHelper.isElementDisplayed(DiscussionsPage.getDiscussionFieldSelector(newBody).body))
            .toBe(true, ValidationsHelper.getDisplayedValidation(DiscussionsPageConstants.inputLabels.body));
    });

    it('Add Grid/Gantt web part - [785832]', async () => {
        const stepLogger = new StepLogger(785832);
        // Delete previous created Grid/Gantt
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.discussions,
            CommonPage.pageHeaders.myWorkplace.discussions,
            CommonPageConstants.pageHeaders.myWorkplace.discussions,
            stepLogger);
        await PageHelper.click(CommonPage.sidebarMenus.settings);
        await PageHelper.click(SocialStreamPage.settingItems.editPage);
        await DiscussionsPageHelper.deleteGridGantt();

        stepLogger.stepId(1);
        stepLogger.step('User is on Discussions page [Left panel> My Workplace> Discussions]');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.discussions,
            CommonPage.pageHeaders.myWorkplace.discussions,
            CommonPageConstants.pageHeaders.myWorkplace.discussions,
            stepLogger);

        stepLogger.verification('user should be navigated to the "Discussions" page');
        await expect(await browser.getTitle()).toBe(DiscussionsPageConstants.discussionPage,
            ValidationsHelper.getDisplayedValidation(DiscussionsPageConstants.discussionPage));

        stepLogger.stepId(2);
        stepLogger.step(`Click on 'Main Gear Settings' display in left bottom corner`);
        await PageHelper.click(CommonPage.sidebarMenus.settings);

        stepLogger.verification('Settings should be displayed');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.settingMenu)).toBe(true,
            ValidationsHelper.getMenuDisplayedValidation(SocialStreamPageConstants.validations.settingMenu));

        stepLogger.stepId(3);
        stepLogger.step('Click on Edit Page');
        await PageHelper.click(SocialStreamPage.settingItems.editPage);

        stepLogger.verification('the Discussions page should be displayed in Edit Mode');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.webPartAdderUpdatePanel)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.validations.homePage));

        stepLogger.stepId(4);
        stepLogger.step(`Click on 'Add a Web Part'`);
        await PageHelper.click(SocialStreamPage.addAWebpart);

        stepLogger.verification('the respective details should be displayed');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.webPartAdderUpdatePanel)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.validations.homePage));

        stepLogger.stepId(5);
        stepLogger.step('Select Categories as EPM Live and Part as Grid/ Gantt and Click on Add button');
        await PageHelper.click(SocialStreamPage.settingItems.epmLive);
        await PageHelper.click(SocialStreamPage.settingItems.gridGantt);
        await PageHelper.click(SocialStreamPage.addButton);

        stepLogger.verification('Grid/ Gantt web part should be applied in Discussions page');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ToDoPageHelper.gridGantt);
        await expect(await PageHelper.isElementDisplayed(ToDoPageHelper.gridGantt)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.gridGantt));

        stepLogger.stepId(6);
        stepLogger.step(`Click on 'Stop Editing' (Page tab >> Stop Editing )`);
        await PageHelper.click(SocialStreamPage.settingItems.page);
        await PageHelper.click(SocialStreamPage.stopEditing);

        stepLogger.verification('User should be on Discussions list page and all discussions should be listed in grid');
        await browser.sleep(PageHelper.timeout.m);
        await expect(await PageHelper.isElementDisplayed(ToDoPageHelper.gridGantt)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.toDo));
    });
});
