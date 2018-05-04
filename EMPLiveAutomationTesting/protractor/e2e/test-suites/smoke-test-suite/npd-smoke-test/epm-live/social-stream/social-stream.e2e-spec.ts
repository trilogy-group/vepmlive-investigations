import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {HomePageConstants} from '../../../../../page-objects/pages/homepage/home-page.constants';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {ElementHelper} from '../../../../../components/html/element-helper';

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
        await PageHelper.click(HomePage.newButton);

        stepLogger.step('Waiting for page to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(HomePageConstants.addADocumentWindow.addADocumentTitle,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        await PageHelper.switchToFrame(CommonPage.contentFrame);

        stepLogger.verification('Verify Choose File option is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(HomePage.browseButton);
        await expect(await PageHelper.isElementDisplayed(HomePage.browseButton))
            .toBe(true,
                ValidationsHelper.getButtonDisplayedValidation(HomePageConstants.addADocumentWindow.chooseFiles));

        stepLogger.verification('Verify OK button is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.formButtons.ok))
            .toBe(true,
                ValidationsHelper.getButtonDisplayedValidation(CommonPageConstants.formLabels.ok));

        stepLogger.verification('Verify Cancel button is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.formButtons.cancel))
            .toBe(true,
                ValidationsHelper.getButtonDisplayedValidation(CommonPageConstants.formLabels.cancel));

        stepLogger.step('Click on Cancel');
        await PageHelper.click(CommonPage.formButtons.cancel);

        await PageHelper.switchToDefaultContent();

        stepLogger.step('Click on +new document link under My Shared Documents on the right side bottom of the page');
        await PageHelper.click(HomePage.newButton);

        stepLogger.step('Waiting for page to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(HomePageConstants.addADocumentWindow.addADocumentTitle,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        await PageHelper.switchToFrame(CommonPage.contentFrame);

        const newFile = CommonPageHelper.uniqueDocumentFilePath;

        stepLogger.step('Upload file');
        await PageHelper.uploadFile(HomePage.browseButton, newFile.fullFilePath);

        stepLogger.step('Click on OK');
        await PageHelper.click(CommonPage.formButtons.ok);

        await PageHelper.switchToDefaultContent();

        stepLogger.verification('Verify newly uploaded file is displayed under My shared documents section');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ElementHelper.getElementByText(newFile.newFileName));
        await expect(ElementHelper.getElementByText(newFile.newFileName).isDisplayed())
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(newFile.newFileName));
    });
});
