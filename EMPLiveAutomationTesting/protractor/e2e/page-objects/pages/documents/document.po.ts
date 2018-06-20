import {PageHelper} from '../../../components/html/page-helper';
import {HomePage} from '../homepage/home.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {HomePageConstants} from '../homepage/home-page.constants';
import {CommonPage} from '../common/common.po';
import {browser} from 'protractor';
import {CommonPageConstants} from '../common/common-page.constants';
import {TextboxHelper} from '../../../components/html/textbox-helper';
import {CheckboxHelper} from '../../../components/html/checkbox-helper';
import {CreateNewPageConstants} from '../items-page/create-new-page.constants';
import {HomePageHelper} from '../homepage/home-page.helper';
import {CommonPageHelper} from '../common/common-page.helper';

export class DocumentPage {

    static async navigateTOAddADocumentPage(stepLogger: StepLogger) {

        stepLogger.stepId(1);
        stepLogger.step('Select Navigation icon  from left side menu');
        await PageHelper.click(HomePageHelper.navigateMenu);

        stepLogger.step('Click on Home link');
        await PageHelper.click(HomePageHelper.navigateToHome);

        stepLogger.verification('Logged in users Home Page is displayed');
        await expect(await browser.getTitle())
            .toBe(HomePageConstants.homePage, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.pageName));

        stepLogger.stepId(2);
        stepLogger.step('Click on + More button displayed in CREATE options in social stream');
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(HomePage.toolBarMenuItems.more);

        stepLogger.step('Click on Project Document link from the options displayed');
        await PageHelper.click(HomePage.toolBarMenuItems.projectDocument);

        stepLogger.verification('Add a document pop up displayed');
        await expect(await CommonPage.dialogTitle.getText()).toBe(HomePageConstants.addADocumentWindow.addADocumentTitle,
            ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

    }

    static async uploadDocument(filePath: string, stepLogger: StepLogger, newVersionFile: boolean) {

        stepLogger.stepId(3);
        stepLogger.step('Click on Choose File button in Add a document pop up > Browse and select the file ' +
            'that need to be added as a Project document [Ex: testfile.txt]');
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        await PageHelper.uploadFile(HomePageHelper.chooseAfile, filePath);

        if (newVersionFile === true) {

            stepLogger.step('Select Check the check box Add as a new version to existing files');
            await CheckboxHelper.markCheckbox(CommonPage.newVersionCheckbox, true);

            stepLogger.step('Version Comments: Enter some comments [Ex: New Version of previously updated file]');
            await TextboxHelper.sendKeys(CommonPage.versionCommentField, CommonPageConstants.versionComment.first);

        }

        stepLogger.step('Click on OK');
        await PageHelper.click(CommonPage.formButtons.ok);

        stepLogger.verification('Add a document pop up is closed');
        await expect(await HomePageHelper.chooseAfile.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        stepLogger.verification('Add a document window to update the properties of the document is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.UpdatePropertyDocument))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentPropertyTitle));

        stepLogger.step('Click Save button in Add a document window');
        await PageHelper.click(CommonPage.formButtons.save);

        stepLogger.verification('Add a document window to update the properties of the document is closed');
        // Sleep required to let it save
        await browser.sleep(PageHelper.timeout.s);
        await expect(await CommonPageHelper.UpdatePropertyDocument.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentPropertyTitle));

        stepLogger.verification('Home Page is displayed');
        await expect(await browser.getTitle())
            .toBe(HomePageConstants.homePage, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.pageName));

    }

    static async verifyCreatedDocument(stepLogger: StepLogger) {

        stepLogger.stepId(5);
        stepLogger.step('Select Navigation icon  from left side menu');
        await PageHelper.click(HomePageHelper.navigateMenu);

        stepLogger.step('Select Projects -> Documents from the options displayed');
        await PageHelper.click(HomePage.navigation.projects.documents);

        stepLogger.verification('Project Documents page is displayed');
        await expect(await browser.getTitle()).toBe(HomePageConstants.documentPage,
            ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.navigationLabels.projects.documents));

        stepLogger.verification('Project node is displayed in collapsed state');
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.projectsList)).toBe(true,
            ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.navigationLabels.projects.projectNodeCollapsed));

        stepLogger.stepId(6);
        stepLogger.step('Click on the Project node to expand it');
        await PageHelper.click(CommonPageHelper.projectsList);

    }

    static async addDocument(filePath: string, stepLogger: StepLogger, document: string) {

        stepLogger.stepId(1);
        stepLogger.step('Select Navigation icon  from left side menu');
        await PageHelper.click(HomePageHelper.navigateMenu);

        stepLogger.verification('Different Navigation options displayed');
        await expect(await PageHelper.isElementPresent(HomePageHelper.navigationMenu))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.navigation));

        stepLogger.stepId(2);
        stepLogger.step('Click on Home link displayed in Navigation options');
        await PageHelper.click(HomePageHelper.navigateToHome);

        stepLogger.verification('Logged in users Home Page is displayed');
        await expect(await browser.getTitle())
            .toBe(HomePageConstants.homePage, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.pageName));

        stepLogger.verification('Social Stream web part is shown on the Home Page');
        await expect(await PageHelper.isElementPresent(HomePage.toolBarMenuItems.socialStream))
            .toBe(true, ValidationsHelper.getDisplayedValidation(CreateNewPageConstants.navigationLabels.libraryApps.socialStream));

        stepLogger.stepId(3);
        stepLogger.step('Click on + More button displayed in CREATE options in social stream');
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(HomePage.toolBarMenuItems.more);
        if (document === CreateNewPageConstants.navigationLabels.libraryApps.projectDocument) {
            stepLogger.step('Click on Project Document link from the options displayed');
            await PageHelper.click(HomePage.toolBarMenuItems.projectDocument);
        } else {
            stepLogger.step('Click on Shared Document link from the options displayed');
            await PageHelper.click(HomePage.toolBarMenuItems.sharedDocument);
        }
        stepLogger.verification('Add a document pop up displayed');
        await expect(await CommonPage.dialogTitle.getText()).toBe(HomePageConstants.addADocumentWindow.addADocumentTitle,
            ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        stepLogger.stepId(4);
        stepLogger.step('Click in Choose file button displayed in Choose a file row in Add a document popup' +
        'Search and select the file to upload [Ex: Testwordfile.docx] and click Open button');
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        await PageHelper.uploadFile(HomePageHelper.chooseAfile, filePath);

        // Selected file name is displayed on right side of Choose file button is not possible.

        stepLogger.stepId(5);
        stepLogger.step('Click OK button in Add a document popup');
        await PageHelper.click(CommonPage.formButtons.ok);

        stepLogger.verification('Add a document popup is to select file is closed');
        await expect(await HomePageHelper.chooseAfile.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        stepLogger.verification('Project Documents (Add a document) window displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.UpdatePropertyDocument))
          .toBe(true, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentPropertyTitle));

        stepLogger.verification('Text The document was uploaded successfully. Use this form to update the' +
            ' properties of the document. on top of the window');
        await expect(await PageHelper.isElementPresent(CommonPage.uploadSuccessFullyText))
          .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.documentUploadText));

        stepLogger.stepId(6);
        stepLogger.step('Click Save button in Add a document window');
        await PageHelper.click(CommonPage.formButtons.save);

        stepLogger.verification('Project Documents (Add a document) window is closed');
        await expect(await CommonPageHelper.UpdatePropertyDocument.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentPropertyTitle));
    }
}
