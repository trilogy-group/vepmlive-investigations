import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {browser} from 'protractor';
import {DocumentPage} from '../../../../../page-objects/pages/documents/document.po';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Add Documents Functionality-Project Document - [1124284]', async () => {
        const stepLogger = new StepLogger(1124284);
        const newFile = CommonPageHelper.uniqueDocumentFilePath;

        // Step #1 and #2 Inside this function
        await DocumentPage.navigateTOAddADocumentPage(stepLogger);

        // Step #3 and #4 Inside this function
        await DocumentPage.uploadDocument(newFile.fullFilePath, stepLogger, false);

        // Notification is not visible after save.

        // Step #5 and #6 Inside this function
        await DocumentPage.verifyCreatedDocument(stepLogger);

        stepLogger.verification('Newly uploaded Project document [Ex: testfile.txt] is displayed under the expanded ' +
            'Project node');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ElementHelper.getElementByText(newFile.file));
        await expect(await ElementHelper.getElementByText(newFile.file).isDisplayed())
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.file));
    });

    it('Add Project Documents Functionality-New version of existing document-[1175281]', async () => {
        const stepLogger = new StepLogger(1175281);
        const newFile = CommonPageHelper.uniqueDocumentFilePath;
        stepLogger.precondition('Execute test case C1124284 and add a Project Document [Ex: testfile.txt]');
        await PageHelper.click(HomePage.navigateMenu);
        await PageHelper.click(HomePage.navigateToHome);
        // Need to add sleep because of bug.
        await browser.sleep(PageHelper.timeout.m);
        await PageHelper.click(HomePage.toolBarMenuItems.more);
        await PageHelper.click(HomePage.toolBarMenuItems.projectDocument);
        await DocumentPage.uploadDocument(newFile.fullFilePath, stepLogger, true);

        // Step #1 and #2 Inside this function
        await DocumentPage.navigateTOAddADocumentPage(stepLogger);

        // Step #3 and #4 Inside this function
        await DocumentPage.uploadDocument(newFile.fullFilePath, stepLogger, true);

        // Notification is not visible after save.

        // Step #5 and #6 Inside this function
        await DocumentPage.verifyCreatedDocument(stepLogger);

        stepLogger.verification('Newly uploaded Project document [Ex: testfile.txt] is displayed under the expanded ' +
            'Project node');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ElementHelper.getElementByText(newFile.file));
        await expect(await ElementHelper.getElementByText(newFile.file).isDisplayed())
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.file));

        stepLogger.verification('Version column displays value "0.2" [A new version should be created successfully' +
            ' of the already existing document]');
        await expect(await CommonPageHelper.getVersionNumberByRowText(newFile.file, CommonPageConstants.versionComment.second).getText())
            .toBe(CommonPageConstants.versionComment.second, ValidationsHelper.getDisplayedValidation
            (CommonPageConstants.versionComment.second));

    });
});
