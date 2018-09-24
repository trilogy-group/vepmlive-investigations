import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {HomePageConstants} from '../../../../../page-objects/pages/homepage/home-page.constants';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {MyTimeOffPageHelper} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {ProjectItemPageHelper} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {LinkPageConstants} from '../../../../../page-objects/pages/my-workplace/link/link-page.constants';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {LinkPageHelper} from '../../../../../page-objects/pages/my-workplace/link/link-page.helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {MyTimeOffPageConstants} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.constants';

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

    it('To Verify My Shared Documents Upload Functionality from Social Stream - [743927]', async () => {
        StepLogger.caseId = 743927;

        StepLogger.step('Click on +new document link under My Shared Documents on the right side bottom of the page');
        await PageHelper.click(CommonPage.uploadButton);

        StepLogger.step('Waiting for page to open');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(HomePageConstants.addADocumentWindow.addADocumentTitle,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        await PageHelper.switchToFrame(CommonPage.contentFrame);

        StepLogger.verification('Verify Choose File option is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.browseButton))
            .toBe(true,
                ValidationsHelper.getButtonDisplayedValidation(HomePageConstants.addADocumentWindow.chooseFiles));

        StepLogger.verification('Verify OK button is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.formButtons.ok))
            .toBe(true,
                ValidationsHelper.getButtonDisplayedValidation(CommonPageConstants.formLabels.ok));

        StepLogger.verification('Verify Cancel button is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.formButtons.cancel))
            .toBe(true,
                ValidationsHelper.getButtonDisplayedValidation(CommonPageConstants.formLabels.cancel));

        StepLogger.step('Click on Cancel');
        await PageHelper.click(CommonPage.formButtons.cancel);

        await PageHelper.switchToDefaultContent();

        StepLogger.step('Click on +new document link under My Shared Documents on the right side bottom of the page');
        await PageHelper.click(CommonPage.uploadButton);

        StepLogger.step('Waiting for page to open');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(HomePageConstants.addADocumentWindow.addADocumentTitle,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        await PageHelper.switchToFrame(CommonPage.contentFrame);

        const newFile = CommonPageHelper.uniqueDocumentFilePath;

        StepLogger.step('Upload file');
        await PageHelper.uploadFile(CommonPage.browseButton, newFile.fullFilePath);

        StepLogger.step('Click on OK');
        await PageHelper.click(CommonPage.formButtons.ok);

        await PageHelper.switchToDefaultContent();

        StepLogger.verification('Verify newly uploaded file is displayed under My shared documents section');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFile.newFileName)))
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.newFileName));
    });

    it('Validate the Comments Section & the Ability to add a Project from the Social Stream - [743926]', async () => {
        StepLogger.caseId = 743926;

        StepLogger.step('Enter some comments for text area displaying text What are you working on?');
        await WaitHelper.waitForElementToBeDisplayed(HomePage.whatAreYouWorkingOnTextBox);
        await TextboxHelper.sendKeys(HomePage.whatAreYouWorkingOnTextBox, HomePageConstants.comment);

        StepLogger.verification('Verify Comment entered and posted is displayed in Activity Stream of user Home Page');
        await expect(await PageHelper.isElementDisplayed(HomePage.commentField))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(HomePageConstants.comment));

        StepLogger.step('Click on "Project" Link on the top menu bar');
        await ElementHelper.click(HomePage.toolBarMenuItems.project);

        StepLogger.verification('Verify Project Center - New Item window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(ProjectItemPageConstants.pageName,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.pageName));

        await PageHelper.switchToFrame(CommonPage.contentFrame);

        StepLogger.step('Enter/Select required details in "Project Center - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = ProjectItemPageConstants.inputLabels;
        const projectNameValue = `${labels.projectName} ${uniqueId}`;
        const projectDescription = `${labels.projectDescription} ${uniqueId}`;
        const benefits = `${labels.benefits} ${uniqueId}`;
        const overallHealthOnTrack = CommonPageConstants.overallHealth.onTrack;
        const projectUpdateManual = CommonPageConstants.projectUpdate.manual;

        await ProjectItemPageHelper.fillForm(
            projectNameValue,
            projectDescription,
            benefits,
            overallHealthOnTrack,
            projectUpdateManual,
        );

        await PageHelper.switchToDefaultContent();

        StepLogger.verification('Newly created Project displayed in "Project" page');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(projectNameValue)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(projectNameValue));

    });

    it('Add Time Off - [891123]', async () => {
        StepLogger.caseId = 891123;

        StepLogger.step('Click on "More" Link on the top menu bar');
        await ElementHelper.click(HomePage.toolBarMenuItems.more);

        StepLogger.step('Click on "Time Off" Link on the top menu bar');
        await ElementHelper.click(HomePage.toolBarMenuItems.timeOff);

        StepLogger.verification('"Time Off - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(MyTimeOffPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(MyTimeOffPageConstants.pageName));

        await PageHelper.switchToFrame(CommonPage.contentFrame);

        StepLogger.step(`Enter/Select below details in 'My Time Off' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = MyTimeOffPageConstants.inputLabels;
        const input = MyTimeOffPageConstants.inputValues;
        const title = `${labels.title} ${uniqueId}`;
        const timeOffType = MyTimeOffPageConstants.timeOffTypes.holiday;
        const requestor = input.requestorValue;
        const startDate = input.startDate;
        const finishDate = input.finishDate;
        await MyTimeOffPageHelper.fillFormAndVerify(title, timeOffType, requestor, startDate, finishDate,);

        await PageHelper.switchToDefaultContent();

        StepLogger.verification('Newly created Time off displayed in Home page');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(title)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(title));
    });
    it('Add an item from Social Stream - [1124294]', async () => {
        StepLogger.caseId = 1124294;

        // // Step #1 and #2 and #3 Inside this function
        StepLogger.stepId(3);
        StepLogger.step(`Click on the LINK icon  displayed in 'CREATE' options in social stream`);
        await ElementHelper.click(HomePage.toolBarMenuItems.link);

        StepLogger.verification(`Links - New Item' window is displayed`);
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitles.first());
        await expect(await CommonPage.dialogTitles.first().getText())
            .toBe(LinkPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(LinkPageConstants.pageName));

        StepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();
        const details = await LinkPageHelper.fillNewLinkFormAndVerification();

        StepLogger.stepId(6);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.links,
            CommonPage.pageHeaders.myWorkplace.links,
            CommonPageConstants.pageHeaders.myWorkplace.links,
        );

        StepLogger.verification(`'Links' page is displayed`);
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(LinkPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(LinkPageConstants.pagePrefix));

        await LinkPageHelper.verifyNewLinkAdded(details);

    });

});
