import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {HomePageConstants} from '../../../../../page-objects/pages/homepage/home-page.constants';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
    });

    it('To Verify My Shared Documents Upload Functionality from Social Stream - [743927]', async () => {
        const stepLogger = new StepLogger(743927);

        stepLogger.step('Click on +new document link under My Shared Documents on the right side bottom of the page');
        await PageHelper.click(HomePage.mySharedDocumentsSection.addDocument.addNewDocumentButton);

        stepLogger.step('Waiting for page to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(HomePageConstants.addADocumentWindow.addADocumentTitle,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        stepLogger.step('Switch to frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        stepLogger.verification('Verify Choose File option is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(HomePage.mySharedDocumentsSection.addDocument.chooseFileButton);
        await expect(await PageHelper.isElementDisplayed(HomePage.mySharedDocumentsSection.addDocument.chooseFileButton))
            .toBe(true,
                ValidationsHelper.getButtonDisplayedValidation(HomePageConstants.addADocumentWindow.chooseFileButtonAriaLabel));

        stepLogger.verification('Verify OK button is displayed');
        await expect(await PageHelper.isElementDisplayed(HomePage.mySharedDocumentsSection.addDocument.okButton))
            .toBe(true,
                ValidationsHelper.getButtonDisplayedValidation(HomePageConstants.addADocumentWindow.okButton));

        stepLogger.verification('Verify Cancel button is displayed');
        await expect(await PageHelper.isElementDisplayed(HomePage.mySharedDocumentsSection.addDocument.cancelButton))
            .toBe(true,
                ValidationsHelper.getButtonDisplayedValidation(HomePageConstants.addADocumentWindow.cancelButton));

        stepLogger.step('Click on Cancel');
        await PageHelper.click(HomePage.mySharedDocumentsSection.addDocument.cancelButton);

        stepLogger.step('Switch back to home page');
        await PageHelper.switchToDefaultContent();

        stepLogger.step('Click on +new document link under My Shared Documents on the right side bottom of the page');
        await PageHelper.click(HomePage.mySharedDocumentsSection.addDocument.addNewDocumentButton);

        stepLogger.step('Waiting for page to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(HomePageConstants.addADocumentWindow.addADocumentTitle,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        stepLogger.step('Switch to frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        const newFile = CommonPageHelper.uniqueDocumentFilePath;

        stepLogger.step('Upload file');
        await PageHelper.uploadFile(HomePage.mySharedDocumentsSection.addDocument.chooseFileButton, newFile.fullFilePath);

        stepLogger.step('Click on OK');
        await PageHelper.click(HomePage.mySharedDocumentsSection.addDocument.okButton);

        stepLogger.step('Switch back to home page');
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('Verify newly uploaded file is displayed under My shared documents section');
        await expect(await PageHelper.isElementDisplayed(await HomePage.uploadedFile(newFile.newFileName)))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(newFile.newFileName));
    });
});
