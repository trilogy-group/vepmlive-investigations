import {SuiteNames} from '../../../../helpers/suite-names';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {SocialStreamPage} from '../../../../../page-objects/pages/settings/social-stream/social-stream.po';
import {SocialStreamPageConstants} from '../../../../../page-objects/pages/settings/social-stream/social-stream-page.constants';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {SocialStreamPageHelper} from '../../../../../page-objects/pages/settings/social-stream/social-stream-page.helper';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Add Social Stream Web Part - [856165]', async () => {
        const stepLogger = new StepLogger(856165);
        stepLogger.stepId(1);
        stepLogger.step('Go to left panel and click on Settings  (Main Gear) icon');
        await PageHelper.click(CommonPage.sidebarMenus.settings);

        stepLogger.verification('settings menu should be displayed in the left navigation');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPageHelper.settingMenu)).toBe(true,
            ValidationsHelper.getMenuDisplayedValidation(SocialStreamPageConstants.validations.settingMenu));

        stepLogger.stepId(2);
        stepLogger.step('Click on Edit Page');
        await PageHelper.click(SocialStreamPage.settingItems.editPage);

        stepLogger.verification('settings menu should be displayed in the left navigation');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPageHelper.webPartAdderUpdatePanel)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.validations.homePage));

        stepLogger.stepId(3);
        stepLogger.step('Click on "Add a Web Part"');
        await SocialStreamPage.deleteSocialStream();
        await PageHelper.click(SocialStreamPageHelper.addAWebpart);

        stepLogger.verification('respective page/section to add a web-part should be displayed');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPageHelper.webPartAdderUpdatePanel)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.validations.homePage));

        stepLogger.stepId(4);
        stepLogger.step('Select EPM Live category >> Select Social Stream web part');
        await PageHelper.click(SocialStreamPage.settingItems.epmLive);
        await PageHelper.click(SocialStreamPageHelper.nextButton);
        await PageHelper.click(SocialStreamPage.settingItems.socialStream);

        stepLogger.verification('the respective options should get selected');
        await expect(SocialStreamPageHelper.socialStreamColumn.getText()).toBe(SocialStreamPageConstants.settingItems.socialStream,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.settingItems.socialStream));

        stepLogger.stepId(5);
        stepLogger.step('Click on Add button');
        await PageHelper.click(SocialStreamPageHelper.addButton);

        stepLogger.verification('the Social Stream web-part should get added');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(SocialStreamPage.settingItems.socialStream);
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.settingItems.socialStream)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.settingItems.socialStream));

        stepLogger.stepId(6);
        stepLogger.step('Once web part is added, click on PAGE tab');
        await PageHelper.click(SocialStreamPage.settingItems.page);

        stepLogger.verification('contents of the PAGE tab should be displayed');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPageHelper.pageRibbon)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.settingItems.page));

        stepLogger.stepId(7);
        stepLogger.step('Click on Stop Editing');
        await PageHelper.click(SocialStreamPageHelper.stopEditing);

        stepLogger.verification('contents of the PAGE tab should be displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(SocialStreamPageHelper.socialStreamPage);
        await expect(await PageHelper.isElementDisplayed(SocialStreamPageHelper.socialStreamPage)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.settingItems.page));
    });

    it('Post Status - [907973]', async () => {
        const stepLogger = new StepLogger(907973);
        stepLogger.stepId(1);
        const uniqueId = PageHelper.getUniqueId();
        const status = SocialStreamPageConstants.message.testStatus + uniqueId;
        const comment = SocialStreamPageConstants.message.testComment + uniqueId;
        stepLogger.step('Check that there is a text box in Social Stream called What are you working on');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(SocialStreamPageHelper.updateBox.first());
        await expect(await PageHelper.isElementDisplayed(SocialStreamPageHelper.updateBox.first())).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.settingItems.socialStreamTextBox));

        stepLogger.verification('there should be a text box in Social Stream called What are you working on');
        await expect(await SocialStreamPageHelper.updateBox.first().getText()).toBe(SocialStreamPageConstants.message.socialStreamCreateBox,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.message.socialStreamCreateBox));

        stepLogger.stepId(2);
        stepLogger.step('Enter some text in it and click in Post button');
        await TextboxHelper.sendKeys(SocialStreamPageHelper.updateBox.first(), status);
        await PageHelper.click(SocialStreamPageHelper.postButton.first());

        stepLogger.verification('Posted comment should be displayed in Social Stream');
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getElementByText(status))).toBe(true,
            ValidationsHelper.getDisplayedValidation(status));

        stepLogger.stepId(3);
        stepLogger.step('Login with another user [Example: PM user] and check that the status posted by Admin get display here');
        await SocialStreamPageHelper.logout();
        await await loginPage.goToAndLoginAsTeamMember();

        stepLogger.verification('Status added by Admin should display here');
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getElementByText(status))).toBe(true,
            ValidationsHelper.getDisplayedValidation(status));

        stepLogger.stepId(4);
        stepLogger.step('Click in Add a comment text box and add comment');
        await TextboxHelper.sendKeys(SocialStreamPageHelper.commentTextBox.first(), comment);

        // Verification is not feasible with automation
        stepLogger.stepId(5);
        stepLogger.step('Click in Post button');
        await PageHelper.click(SocialStreamPageHelper.commentPost.first());

        stepLogger.verification('Comment should be added below the main status (Added by Admin User)');
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getElementByText(comment))).toBe(true,
            ValidationsHelper.getDisplayedValidation(comment));

        stepLogger.stepId(6);
        stepLogger.step('Go back to Home page of admin user and check that the comment added by another user get display here');
        await SocialStreamPageHelper.logout();
        await await loginPage.goToAndLogin();

        stepLogger.verification('Comment added by another user should be displayed to admin user');
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getElementByText(comment))).toBe(true,
            ValidationsHelper.getDisplayedValidation(comment));
    });
});
