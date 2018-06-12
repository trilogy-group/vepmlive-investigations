import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {HomePageConstants} from '../../../../../page-objects/pages/homepage/home-page.constants';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {browser} from 'protractor';
import {DocumentPage} from '../../../../../page-objects/pages/documents/document.po';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    const newFile = CommonPageHelper.uniqueDocumentFilePath;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Add Documents Functionality-Project Document - [1124284]', async () => {
        const stepLogger = new StepLogger(1124284);
        stepLogger.stepId(1);
        stepLogger.step('Select Navigation icon  from left side menu');
        await PageHelper.click(HomePage.navigateMenu);

        stepLogger.step('Click on Home link');
        await PageHelper.click(HomePage.navigateToHome);

        stepLogger.verification('Logged in users Home Page is displayed');
        await expect(browser.getTitle())
            .toBe(HomePageConstants.homePage, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.pageName));

        // Step #2 and #6 Inside this function
        await DocumentPage.uploadDocument(newFile.fullFilePath, stepLogger, false);

        stepLogger.verification('Newly uploaded Project document [Ex: testfile.txt] is displayed under the expanded ' +
            'Project node');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ElementHelper.getElementByText(newFile.file));
        await expect(ElementHelper.getElementByText(newFile.file).isDisplayed())
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.file));
    });

    it('Add Project Documents Functionality-New version of existing document-[1175281]', async () => {
        const stepLogger = new StepLogger(1175281);
        stepLogger.stepId(1);
        stepLogger.step('Select Navigation icon  from left side menu');
        await PageHelper.click(HomePage.navigateMenu);

        stepLogger.step('Click on Home link');
        await PageHelper.click(HomePage.navigateToHome);

        stepLogger.verification('Logged in users Home Page is displayed');
        await expect(browser.getTitle())
            .toBe(HomePageConstants.homePage, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.pageName));

        // Step #2 and #6 Inside this function
        await DocumentPage.uploadDocument(newFile.fullFilePath, stepLogger, true);

        stepLogger.verification('Newly uploaded Project document [Ex: testfile.txt] is displayed under the expanded ' +
            'Project node');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ElementHelper.getElementByText(newFile.file));
        await expect(ElementHelper.getElementByText(newFile.file).isDisplayed())
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.file));

        stepLogger.verification('Version column displays value "0.2" [A new version should be created ' +
            'successfully of the already existing document]');
        await expect(CommonPageHelper.getVersionNumberByRowText(newFile.file, CommonPageConstants.versionComment.second ).getText())
            .toBe(CommonPageConstants.versionComment.second, ValidationsHelper.getDisplayedValidation
            (CommonPageConstants.versionComment.second));

    });
});
