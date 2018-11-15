import {browser} from 'protractor';
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
import {SocialStreamPage} from '../../../../../page-objects/pages/settings/social-stream/social-stream.po';
import {ToDoPage} from '../../../../../page-objects/pages/my-workplace/to-do/to-do.po';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    it('Navigate to Discussions page - [785609]', async () => {
        StepLogger.caseId = 785609;
        StepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.discussions,
            CommonPage.pageHeaders.myWorkplace.discussions,
            CommonPageConstants.pageHeaders.myWorkplace.discussions,
        );
    });

    it('Add a New Discussion - [785611]', async () => {
        StepLogger.caseId = 785611;
        await DiscussionsPageHelper.addDiscussion();
    });

    it('Edit Discussion from Workplace - [1175265]', async () => {
        StepLogger.caseId = 1175265;

        StepLogger.step(`preCondition: Create new discussion`);
        const labels = DiscussionsPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const subject = `${labels.subject} ${uniqueId}`;
        const body = `${labels.body} ${uniqueId}`;
        let isQuestion = true;
        await DiscussionsPageHelper.createNewDiscussion(subject, body, isQuestion);

        StepLogger.stepId(1);
        StepLogger.stepId(2);
        // Step #1 and #2 Inside this function
        StepLogger.step('Navigate to Discussions page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.discussions,
            CommonPage.pageHeaders.myWorkplace.discussions,
            CommonPageConstants.pageHeaders.myWorkplace.discussions,
        );

        StepLogger.stepId(3);
        StepLogger.step('Mouse over the Discussion created as per pre requisites that need to be ' +
            'edited Click on the Ellipses button (...) and select Edit Item from the options displayed');
        await PageHelper.click(DiscussionsPageHelper.getDiscussionField(subject));
        await PageHelper.click(DiscussionsPage.buttonSelector.edit);

        StepLogger.stepId(4);
        StepLogger.step('Enter/Select below details in Edit Discussion page Subject *: Updated New Discussion 1 Body: Update ' +
            'the text [Ex: Updated new Discussion used for Smoke Test Case creation] Question: Leave the check box unchecked/un selected');
        const newUniqueId = PageHelper.getUniqueId();
        const newSubject = `${labels.subject} ${newUniqueId}`;
        const newBody = `${labels.body} ${newUniqueId}`;
        isQuestion = false;
        await DiscussionsPageHelper.fillNewDiscussionForm(newSubject, newBody, isQuestion);

        StepLogger.stepId(5);
        StepLogger.step('Click save button');
        await DiscussionsPageHelper.saveDiscussionForm();

        StepLogger.verification('Updated Discussion item details subject displayed in the list');
        await expect(await PageHelper.isElementDisplayed(DiscussionsPageHelper.getDiscussionFieldSelector(newSubject).subject))
            .toBe(true, ValidationsHelper.getDisplayedValidation(DiscussionsPageConstants.inputLabels.subject));

        StepLogger.verification('Updated Discussion item details body displayed in the list');
        await expect(await PageHelper.isElementDisplayed(DiscussionsPageHelper.getDiscussionFieldSelector(newBody).body))
            .toBe(true, ValidationsHelper.getDisplayedValidation(DiscussionsPageConstants.inputLabels.body));
    });

    it('Add Grid/Gantt web part - [785832]', async () => {
        StepLogger.caseId = 785832;
        // Delete previous created Grid/Gantt
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.discussions,
            CommonPage.pageHeaders.myWorkplace.discussions,
            CommonPageConstants.pageHeaders.myWorkplace.discussions,
        );
        await PageHelper.click(CommonPage.sidebarMenus.settings);
        await PageHelper.click(SocialStreamPage.settingItems.editPage);
        await DiscussionsPageHelper.deleteGridGantt();

        StepLogger.stepId(1);
        StepLogger.step('User is on Discussions page [Left panel> My Workplace> Discussions]');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.discussions,
            CommonPage.pageHeaders.myWorkplace.discussions,
            CommonPageConstants.pageHeaders.myWorkplace.discussions,
        );

        StepLogger.verification('user should be navigated to the "Discussions" page');
        await expect(await browser.getTitle()).toBe(DiscussionsPageConstants.discussionPage,
            ValidationsHelper.getDisplayedValidation(DiscussionsPageConstants.discussionPage));

        StepLogger.stepId(2);
        StepLogger.step(`Click on 'Main Gear Settings' display in left bottom corner`);
        await PageHelper.click(CommonPage.sidebarMenus.settings);

        StepLogger.verification('Settings should be displayed');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.settingMenu)).toBe(true,
            ValidationsHelper.getMenuDisplayedValidation(SocialStreamPageConstants.validations.settingMenu));

        StepLogger.stepId(3);
        StepLogger.step('Click on Edit Page');
        await PageHelper.click(SocialStreamPage.settingItems.editPage);

        StepLogger.verification('the Discussions page should be displayed in Edit Mode');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.webPartAdderUpdatePanel)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.validations.homePage));

        StepLogger.stepId(4);
        StepLogger.step(`Click on 'Add a Web Part'`);
        await PageHelper.click(SocialStreamPage.addAWebpart);

        StepLogger.verification('the respective details should be displayed');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.webPartAdderUpdatePanel)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.validations.homePage));

        StepLogger.stepId(5);
        StepLogger.step('Select Categories as EPM Live and Part as Grid/ Gantt and Click on Add button');
        await PageHelper.click(SocialStreamPage.settingItems.epmLive);
        await PageHelper.click(SocialStreamPage.settingItems.gridGantt);
        await PageHelper.click(SocialStreamPage.addButton);

        StepLogger.verification('Grid/ Gantt web part should be applied in Discussions page');
        await expect(await PageHelper.isElementDisplayed(ToDoPage.gridGantt)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.gridGantt));

        StepLogger.stepId(6);
        StepLogger.step(`Click on 'Stop Editing' (Page tab >> Stop Editing )`);
        await PageHelper.click(SocialStreamPage.settingItems.page);
        await PageHelper.click(SocialStreamPage.stopEditing);

        StepLogger.verification('User should be on Discussions list page and all discussions should be listed in grid');
        // wait helper doesn't work sleep required.
        await browser.sleep(PageHelper.timeout.m);
        await expect(await PageHelper.isElementDisplayed(ToDoPage.gridGantt)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.toDo));
    });
});
