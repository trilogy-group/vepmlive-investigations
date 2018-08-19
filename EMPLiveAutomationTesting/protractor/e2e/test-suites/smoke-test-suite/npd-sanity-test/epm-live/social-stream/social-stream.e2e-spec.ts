import {browser} from 'protractor';
import {SuiteNames} from '../../../../helpers/suite-names';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {SocialStreamPage} from '../../../../../page-objects/pages/settings/social-stream/social-stream.po';
import {SocialStreamPageConstants} from '../../../../../page-objects/pages/settings/social-stream/social-stream-page.constants';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CreateNewPageConstants} from '../../../../../page-objects/pages/items-page/create-new-page.constants';
import {HomePageConstants} from '../../../../../page-objects/pages/homepage/home-page.constants';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {DocumentPageHelper} from '../../../../../page-objects/pages/documents/document-page.helper';

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
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.settingMenu)).toBe(true,
            ValidationsHelper.getMenuDisplayedValidation(SocialStreamPageConstants.validations.settingMenu));

        stepLogger.stepId(2);
        stepLogger.step('Click on Edit Page');
        await PageHelper.click(SocialStreamPage.settingItems.editPage);

        stepLogger.verification('settings menu should be displayed in the left navigation');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.webPartAdderUpdatePanel)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.validations.homePage));

        stepLogger.stepId(3);
        stepLogger.step('Click on "Add a Web Part"');
        await SocialStreamPage.deleteSocialStream();
        await PageHelper.click(SocialStreamPage.addAWebpart);

        stepLogger.verification('respective page/section to add a web-part should be displayed');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.webPartAdderUpdatePanel)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.validations.homePage));

        stepLogger.stepId(4);
        stepLogger.step('Select EPM Live category >> Select Social Stream web part');
        await PageHelper.click(SocialStreamPage.settingItems.epmLive);
        await PageHelper.click(SocialStreamPage.nextButton);
        await PageHelper.click(SocialStreamPage.settingItems.socialStream);

        stepLogger.verification('the respective options should get selected');
        await expect(await SocialStreamPage.socialStreamColumn.getText()).toBe(SocialStreamPageConstants.settingItems.socialStream,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.settingItems.socialStream));

        stepLogger.stepId(5);
        stepLogger.step('Click on Add button');
        await PageHelper.click(SocialStreamPage.addButton);

        stepLogger.verification('the Social Stream web-part should get added');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.settingItems.socialStream)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.settingItems.socialStream));

        stepLogger.stepId(6);
        stepLogger.step('Once web part is added, click on PAGE tab');
        await PageHelper.click(SocialStreamPage.settingItems.page);

        stepLogger.verification('contents of the PAGE tab should be displayed');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.pageRibbon)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.settingItems.page));

        stepLogger.stepId(7);
        stepLogger.step('Click on Stop Editing');
        await PageHelper.click(SocialStreamPage.stopEditing);

        stepLogger.verification('contents of the PAGE tab should be displayed');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.socialStreamPage)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.settingItems.page));
    });

    it('Post Status - [907973]', async () => {
        const stepLogger = new StepLogger(907973);
        stepLogger.stepId(1);
        const uniqueId = PageHelper.getUniqueId();
        const status = SocialStreamPageConstants.message.testStatus + uniqueId;
        const comment = SocialStreamPageConstants.message.testComment + uniqueId;
        stepLogger.step('Check that there is a text box in Social Stream called What are you working on');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.updateBox.first())).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.settingItems.socialStreamTextBox));

        stepLogger.verification('there should be a text box in Social Stream called What are you working on');
        await expect(await SocialStreamPage.updateBox.first().getText()).toBe(SocialStreamPageConstants.message.socialStreamCreateBox,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.message.socialStreamCreateBox));

        stepLogger.stepId(2);
        stepLogger.step('Enter some text in it and click in Post button');
        await TextboxHelper.sendKeys(SocialStreamPage.updateBox.first(), status);
        await PageHelper.click(SocialStreamPage.postButton.first());

        stepLogger.verification('Posted comment should be displayed in Social Stream');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(status))).toBe(true,
            ValidationsHelper.getDisplayedValidation(status));

        stepLogger.stepId(3);
        stepLogger.step('Login with another user [Example: PM user] and check that the status posted by Admin get display here');
        await SocialStreamPage.logout();
        await await loginPage.goToAndLoginAsTeamMember();

        stepLogger.verification('Status added by Admin should display here');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(status))).toBe(true,
            ValidationsHelper.getDisplayedValidation(status));

        stepLogger.stepId(4);
        stepLogger.step('Click in Add a comment text box and add comment');
        await TextboxHelper.sendKeys(SocialStreamPage.commentTextBox.first(), comment);

        // Verification is not feasible with automation
        stepLogger.stepId(5);
        stepLogger.step('Click in Post button');
        await PageHelper.click(SocialStreamPage.commentPost.first());

        stepLogger.verification('Comment should be added below the main status (Added by Admin User)');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(comment))).toBe(true,
            ValidationsHelper.getDisplayedValidation(comment));

        stepLogger.stepId(6);
        stepLogger.step('Go back to Home page of admin user and check that the comment added by another user get display here');
        await SocialStreamPage.logout();
        await loginPage.goToAndLogin();

        stepLogger.verification('Comment added by another user should be displayed to admin user');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(comment))).toBe(true,
            ValidationsHelper.getDisplayedValidation(comment));
    });

    it('Add Shared Document - [907964]', async () => {
        const stepLogger = new StepLogger(907964);
        const newFile = CommonPageHelper.uniqueDocumentFilePath;

        stepLogger.stepId(1);
        stepLogger.step('Select Navigation icon  from left side menu');
        await PageHelper.click(HomePage.navigateMenu);

        stepLogger.verification('Different Navigation options displayed');
        await expect(await PageHelper.isElementPresent(HomePage.navigationMenu))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.navigation));

        stepLogger.stepId(2);
        stepLogger.step('Click on Home link displayed in Navigation options');
        await PageHelper.click(HomePage.navigateToHome);

        stepLogger.verification('Logged in users Home Page is displayed');
        await expect(await browser.getTitle())
            .toBe(HomePageConstants.homePage, ValidationsHelper.getPageDisplayedValidation(HomePageConstants.pageName));

        stepLogger.verification('Social Stream web part is shown on the Home Page');
        await expect(await PageHelper.isElementPresent(HomePage.toolBarMenuItems.socialStream))
            .toBe(true, ValidationsHelper.getDisplayedValidation(CreateNewPageConstants.navigationLabels.libraryApps.socialStream));

        stepLogger.stepId(3);
        stepLogger.step('Click on + More button displayed in CREATE options in social stream');
        // Sleep required because of bug of two "More" buttons
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(HomePage.toolBarMenuItems.more);

        stepLogger.step('Click on Shared Document link from the options displayed');
        await PageHelper.click(HomePage.toolBarMenuItems.sharedDocument);

        stepLogger.verification('Add a document pop up displayed');
        await DocumentPageHelper.verifyDocumentPopUp;

        stepLogger.stepId(4);
        // #4 and #5 step are inside the function
        stepLogger.step('Click in Choose file button displayed in Choose a file row in Add a document popup' +
            'Search and select the file to upload [Ex: Testwordfile.docx] and click Open button');
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        await PageHelper.uploadFile(CommonPage.browseButton, newFile.fullFilePath);

        // Selected file name is displayed on right side of Choose file button is not possible.

        stepLogger.stepId(6);
        stepLogger.step('Click OK button in Add a document popup');
        await PageHelper.click(CommonPage.formButtons.ok);

        stepLogger.verification('Add a document popup is to select file is closed');
        await browser.sleep(PageHelper.timeout.s);
        await expect(await CommonPage.browseButton.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        stepLogger.verification('Project Documents (Add a document) window displayed');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFile.newFileName)))
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.newFileName));

        stepLogger.stepId(7);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.sharedDocuments,
            CommonPage.pageHeaders.myWorkplace.sharedDocuments,
            CommonPageConstants.pageHeaders.myWorkplace.sharedDocuments,
            stepLogger);

        stepLogger.verification('Project Documents (Add a document) window displayed');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFile.file)))
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.newFileName));
    });
});
