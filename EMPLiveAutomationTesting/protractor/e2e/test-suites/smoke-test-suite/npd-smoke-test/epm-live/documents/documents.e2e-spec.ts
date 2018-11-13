import {browser} from 'protractor';
import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {HomePageConstants} from '../../../../../page-objects/pages/homepage/home-page.constants';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CreateNewPageConstants} from '../../../../../page-objects/pages/items-page/create-new-page.constants';
import {DocumentPageHelper} from '../../../../../page-objects/pages/documents/document-page.helper';
import {ElementHelper} from '../../../../../components/html/element-helper';

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

    fit('Add Documents Functionality-Project Document - [1124284]', async () => {
        StepLogger.caseId = 1124284;
        const newFile = CommonPageHelper.uniqueDocumentFilePath;

        // Step #1 and #2 Inside this function
        await DocumentPageHelper.navigateTOAddADocumentPage();

        // Step #3 and #4 Inside this function
        await DocumentPageHelper.uploadDocument(newFile.fullFilePath, false);

        // Notification is not visible after save.

        // Step #5 and #6 Inside this function
        await DocumentPageHelper.verifyCreatedDocument();

        StepLogger.verification('Newly uploaded Project document [Ex: testfile.txt] is displayed under the expanded ' +
            'Project node');

        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFile.file)))
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.file));
    });

    it('Add Project Documents Functionality-New version of existing document-[1175281]', async () => {
        StepLogger.caseId = 1175281;
        const newFile = CommonPageHelper.uniqueDocumentFilePath;
        StepLogger.preCondition('Execute test case C1124284 and add a Project Document [Ex: testfile.txt]');
        await PageHelper.click(HomePage.navigateMenu);
        await PageHelper.click(HomePage.navigateToHome);
        await expect(await browser.getTitle())
            .toBe(HomePageConstants.homePage, ValidationsHelper.getPageDisplayedValidation(HomePageConstants.pageName));
        // Need to add sleep because of bug.
        await browser.sleep(PageHelper.timeout.m);
        await PageHelper.click(HomePage.toolBarMenuItems.more);
        await PageHelper.click(HomePage.toolBarMenuItems.projectDocument);
        await expect(await CommonPage.dialogTitle.getText()).toBe(HomePageConstants.addADocumentWindow.addADocumentTitle,
            ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));
        await DocumentPageHelper.uploadDocument(newFile.fullFilePath, true);

        // Step #1 and #2 Inside this function
        await DocumentPageHelper.navigateTOAddADocumentPage();

        // Step #3 and #4 Inside this function
        await DocumentPageHelper.uploadDocument(newFile.fullFilePath, true);

        // Notification is not visible after save.

        // Step #5 and #6 Inside this function
        await DocumentPageHelper.verifyCreatedDocument();

        StepLogger.verification('Newly uploaded Project document [Ex: testfile.txt] is displayed under the expanded ' +
            'Project node');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFile.file)))
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.file));

        StepLogger.verification('Version column displays value "0.2" [A new version should be created ' +
            'successfully of the already existing document]');
        await expect(await CommonPageHelper.getVersionNumberByRowText(newFile.file, CommonPageConstants.versionComment.second).getText())
            .toBe(CommonPageConstants.versionComment.second, ValidationsHelper.getDisplayedValidation
            (CommonPageConstants.versionComment.second));

    });

    it('Add Project Document - [907962]', async () => {
        StepLogger.caseId = 907962;
        const newFile = CommonPageHelper.uniqueDocumentFilePath;
        const project = CreateNewPageConstants.navigationLabels.libraryApps.projectDocument;

        // Step #1 and #6 Inside this function
        await DocumentPageHelper.addDocument(newFile.fullFilePath, project);

        StepLogger.verification('Project Document uploaded [Ex: Testwordfile.docx] is displayed in "Social Stream"');
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getElementAllByText(newFile.file, true)))
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.file));

        StepLogger.stepId(7);
        StepLogger.step('Select Navigation icon  from left side menu');
        await PageHelper.click(HomePage.navigateMenu);
        await PageHelper.click(HomePage.navigation.projects.documents);
        StepLogger.step('Click on the Project node to expand it');
        await PageHelper.click(CommonPage.projectsList);

        StepLogger.verification('Project Documents page is displayed');
        await expect(await browser.getTitle()).toBe(HomePageConstants.documentPage,
            ValidationsHelper.getPageDisplayedValidation(HomePageConstants.navigationLabels.projects.documents));

        StepLogger.verification('Project Document uploaded [Ex: Testwordfile.docx] is displayed under the Project Node');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFile.file)))
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.file));
    });
});
