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

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    it('Add Social Stream Web Part - [856165]', async () => {
        StepLogger.caseId = 856165;
        StepLogger.stepId(1);
        StepLogger.step('Go to left panel and click on Settings  (Main Gear) icon');
        await PageHelper.click(CommonPage.sidebarMenus.settings);

        StepLogger.verification('settings menu should be displayed in the left navigation');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.settingMenu)).toBe(true,
            ValidationsHelper.getMenuDisplayedValidation(SocialStreamPageConstants.validations.settingMenu));

        StepLogger.stepId(2);
        StepLogger.step('Click on Edit Page');
        await PageHelper.click(SocialStreamPage.settingItems.editPage);

        StepLogger.verification('settings menu should be displayed in the left navigation');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.webPartAdderUpdatePanel)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.validations.homePage));

        StepLogger.stepId(3);
        StepLogger.step('Click on "Add a Web Part"');
        await SocialStreamPage.deleteSocialStream();
        await PageHelper.click(SocialStreamPage.addAWebpart);

        StepLogger.verification('respective page/section to add a web-part should be displayed');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.webPartAdderUpdatePanel)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.validations.homePage));

        StepLogger.stepId(4);
        StepLogger.step('Select EPM Live category >> Select Social Stream web part');
        await PageHelper.click(SocialStreamPage.settingItems.epmLive);
        await PageHelper.click(SocialStreamPage.nextButton);
        await PageHelper.click(SocialStreamPage.settingItems.socialStream);

        StepLogger.verification('the respective options should get selected');
        await expect(await SocialStreamPage.socialStreamColumn.getText()).toBe(SocialStreamPageConstants.settingItems.socialStream,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.settingItems.socialStream));

        StepLogger.stepId(5);
        StepLogger.step('Click on Add button');
        await PageHelper.click(SocialStreamPage.addButton);

        StepLogger.verification('the Social Stream web-part should get added');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.settingItems.socialStream)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.settingItems.socialStream));

        StepLogger.stepId(6);
        StepLogger.step('Once web part is added, click on PAGE tab');
        await PageHelper.click(SocialStreamPage.settingItems.page);

        StepLogger.verification('contents of the PAGE tab should be displayed');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.pageRibbon)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.settingItems.page));

        StepLogger.stepId(7);
        StepLogger.step('Click on Stop Editing');
        await PageHelper.click(SocialStreamPage.stopEditing);

        StepLogger.verification('contents of the PAGE tab should be displayed');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.socialStreamPage)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.settingItems.page));
    });

    xit('Post Status - [907973] [BUG:SKYVERA-1406]', async () => {
        StepLogger.caseId = 907973;
        StepLogger.stepId(1);
        const uniqueId = PageHelper.getUniqueId();
        const status = SocialStreamPageConstants.message.testStatus + uniqueId;
        const comment = SocialStreamPageConstants.message.testComment + uniqueId;
        StepLogger.step('Check that there is a text box in Social Stream called What are you working on');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.updateBox.first())).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.settingItems.socialStreamTextBox));

        StepLogger.verification('there should be a text box in Social Stream called What are you working on');
        await expect(await SocialStreamPage.updateBox.first().getText()).toBe(SocialStreamPageConstants.message.socialStreamCreateBox,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.message.socialStreamCreateBox));

        StepLogger.stepId(2);
        StepLogger.step('Enter some text in it and click in Post button');
        await TextboxHelper.sendKeys(SocialStreamPage.updateBox.first(), status);
        await PageHelper.click(SocialStreamPage.postButton.first());

        StepLogger.verification('Posted comment should be displayed in Social Stream');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(status))).toBe(true,
            ValidationsHelper.getDisplayedValidation(status));

        StepLogger.stepId(3);
        StepLogger.step('Login with another user [Example: PM user] and check that the status posted by Admin get display here');
        await SocialStreamPage.logout();
        await loginPage.goToAndLoginAsTeamMember();

        StepLogger.verification('Status added by Admin should display here');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(status))).toBe(true,
            ValidationsHelper.getDisplayedValidation(status));

        StepLogger.stepId(4);
        StepLogger.step('Click in Add a comment text box and add comment');
        await TextboxHelper.sendKeys(SocialStreamPage.commentTextBox.first(), comment);

        // Verification is not feasible with automation
        StepLogger.stepId(5);
        StepLogger.step('Click in Post button');
        await PageHelper.click(SocialStreamPage.commentPost.first());

        StepLogger.verification('Comment should be added below the main status (Added by Admin User)');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(comment))).toBe(true,
            ValidationsHelper.getDisplayedValidation(comment));

        StepLogger.stepId(6);
        StepLogger.step('Go back to Home page of admin user and check that the comment added by another user get display here');
        await SocialStreamPage.logout();
        await loginPage.goToAndLogin();

        StepLogger.verification('Comment added by another user should be displayed to admin user');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(comment))).toBe(true,
            ValidationsHelper.getDisplayedValidation(comment));
    });

    it('Add Shared Document - [907964]', async () => {
        StepLogger.caseId = 907964;
        const newFile = CommonPageHelper.uniqueDocumentFilePath;

        StepLogger.stepId(1);
        StepLogger.step('Select Navigation icon  from left side menu');
        await PageHelper.click(HomePage.navigateMenu);

        StepLogger.verification('Different Navigation options displayed');
        await expect(await PageHelper.isElementPresent(HomePage.navigationMenu))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.navigation));

        StepLogger.stepId(2);
        StepLogger.step('Click on Home link displayed in Navigation options');
        await PageHelper.click(HomePage.navigateToHome);

        StepLogger.verification('Logged in users Home Page is displayed');
        await expect(await browser.getTitle())
            .toBe(HomePageConstants.homePage, ValidationsHelper.getPageDisplayedValidation(HomePageConstants.pageName));

        StepLogger.verification('Social Stream web part is shown on the Home Page');
        await expect(await PageHelper.isElementPresent(HomePage.toolBarMenuItems.socialStream))
            .toBe(true, ValidationsHelper.getDisplayedValidation(CreateNewPageConstants.navigationLabels.libraryApps.socialStream));

        StepLogger.stepId(3);
        StepLogger.step('Click on + More button displayed in CREATE options in social stream');
        // Sleep required because of bug of two "More" buttons
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(HomePage.toolBarMenuItems.more);

        StepLogger.step('Click on Shared Document link from the options displayed');
        await PageHelper.click(HomePage.toolBarMenuItems.sharedDocument);

        StepLogger.verification('Add a document pop up displayed');
        await DocumentPageHelper.verifyDocumentPopUp;

        StepLogger.stepId(4);
        // #4 and #5 step are inside the function
        StepLogger.step('Click in Choose file button displayed in Choose a file row in Add a document popup' +
            'Search and select the file to upload [Ex: Testwordfile.docx] and click Open button');
        await CommonPageHelper.switchToContentFrame();
        await PageHelper.uploadFile(CommonPage.browseButton, newFile.fullFilePath);

        // Selected file name is displayed on right side of Choose file button is not possible.

        StepLogger.stepId(6);
        StepLogger.step('Click OK button in Add a document popup');
        await PageHelper.click(CommonPage.formButtons.ok);

        StepLogger.verification('Add a document popup is to select file is closed');
        await browser.sleep(PageHelper.timeout.s);
        await expect(await CommonPage.browseButton.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        StepLogger.verification('Project Documents (Add a document) window displayed');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFile.newFileName)))
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.newFileName));

        StepLogger.stepId(7);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.sharedDocuments,
            CommonPage.pageHeaders.myWorkplace.sharedDocuments,
            CommonPageConstants.pageHeaders.myWorkplace.sharedDocuments,
        );

        StepLogger.verification('Project Documents (Add a document) window displayed');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFile.file)))
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.newFileName));
    });
});
