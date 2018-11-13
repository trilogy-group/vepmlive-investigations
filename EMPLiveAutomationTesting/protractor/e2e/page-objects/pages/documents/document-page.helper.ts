import {browser} from 'protractor';
import {PageHelper} from '../../../components/html/page-helper';
import {HomePage} from '../homepage/home.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {HomePageConstants} from '../homepage/home-page.constants';
import {CommonPage} from '../common/common.po';
import {CommonPageConstants} from '../common/common-page.constants';
import {TextboxHelper} from '../../../components/html/textbox-helper';
import {CheckboxHelper} from '../../../components/html/checkbox-helper';
import {CreateNewPageConstants} from '../items-page/create-new-page.constants';
import {WaitHelper} from '../../../components/html/wait-helper';
import {DocumentPage} from './document-page.po';
import {CommonPageHelper} from '../common/common-page.helper';

export class DocumentPageHelper {

    static async navigateTOAddADocumentPage() {

        StepLogger.stepId(1);
        StepLogger.step('Select Navigation icon  from left side menu');
        await PageHelper.click(HomePage.navigateMenu);

        StepLogger.step('Click on Home link');
        await PageHelper.click(HomePage.navigateToHome);

        StepLogger.verification('Logged in users Home Page is displayed');
        await expect(await browser.getTitle())
            .toBe(HomePageConstants.homePage, ValidationsHelper.getPageDisplayedValidation(HomePageConstants.pageName));

        StepLogger.stepId(2);
        StepLogger.step('Click on + More button displayed in CREATE options in social stream');
        // Sleep required because of bug of two "More" buttons
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(HomePage.toolBarMenuItems.more);

        StepLogger.step('Click on Project Document link from the options displayed');
        await PageHelper.click(HomePage.toolBarMenuItems.projectDocument);

        StepLogger.verification('Add a document pop up displayed');
        await this.verifyDocumentPopUp();

    }

    static async uploadDocument(filePath: string, newVersionFile: boolean) {

        StepLogger.stepId(3);
        StepLogger.step('Click on Choose File button in Add a document pop up > Browse and select the file ' +
            'that need to be added as a Project document [Ex: testfile.txt]');
        await CommonPageHelper.switchToContentFrame();
        await PageHelper.uploadFile(CommonPage.browseButton, filePath);

        if (newVersionFile === true) {

            StepLogger.step('Select Check the check box Add as a new version to existing files');
            await CheckboxHelper.markCheckbox(CommonPage.newVersionCheckbox, true);

            StepLogger.step('Version Comments: Enter some comments [Ex: New Version of previously updated file]');
            await TextboxHelper.sendKeys(CommonPage.versionCommentField, CommonPageConstants.versionComment.first);

        }

        StepLogger.step('Click on OK');
        await PageHelper.click(CommonPage.formButtons.ok);

        StepLogger.verification('Add a document pop up is closed');
        await expect(await CommonPage.browseButton.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        StepLogger.verification('Add a document window to update the properties of the document is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.UpdatePropertyDocument))
            .toBe(true, ValidationsHelper.getDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentPropertyTitle));

        StepLogger.step('Click Save button in Add a document window');
        await PageHelper.click(CommonPage.formButtons.save);

        StepLogger.verification('Add a document window to update the properties of the document is closed');
        // Sleep required to let it save
        await browser.sleep(PageHelper.timeout.s);
        await expect(await CommonPage.UpdatePropertyDocument.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentPropertyTitle));

        StepLogger.verification('Home Page is displayed');
        await expect(await browser.getTitle())
            .toBe(HomePageConstants.homePage, ValidationsHelper.getPageDisplayedValidation(HomePageConstants.homePage));
    }

    static async verifyCreatedDocument() {

        StepLogger.stepId(5);
        StepLogger.step('Select Navigation icon  from left side menu');
        await PageHelper.click(HomePage.navigateMenu);

        StepLogger.step('Select Projects -> Documents from the options displayed');
        await PageHelper.click(HomePage.navigation.projects.documents);
        // wait is needed for next page to load
        await PageHelper.sleepForXSec(5000);

        StepLogger.verification('Project Documents page is displayed');
        await expect(await browser.getTitle()).toBe(HomePageConstants.documentPage,
            ValidationsHelper.getPageDisplayedValidation(HomePageConstants.navigationLabels.projects.documents));

        StepLogger.verification('Project node is displayed in collapsed state');
        await expect(await PageHelper.isElementDisplayed(CommonPage.projectsList)).toBe(true,
            ValidationsHelper.getDisplayedValidation(HomePageConstants.navigationLabels.projects.projectNodeCollapsed));

        StepLogger.stepId(6);
        StepLogger.step('Click on the Project node to expand it');
        await PageHelper.click(CommonPage.projectsList);

    }

    static async addDocument(filePath: string, document: string) {

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
        if (document === CreateNewPageConstants.navigationLabels.libraryApps.projectDocument) {
            StepLogger.step('Click on Project Document link from the options displayed');
            await PageHelper.click(HomePage.toolBarMenuItems.projectDocument);
        } else {
            StepLogger.step('Click on Shared Document link from the options displayed');
            await PageHelper.click(HomePage.toolBarMenuItems.sharedDocument);
        }
        StepLogger.verification('Add a document pop up displayed');
        await this.verifyDocumentPopUp();

        StepLogger.stepId(4);
        StepLogger.step('Click in Choose file button displayed in Choose a file row in Add a document popup' +
            'Search and select the file to upload [Ex: Testwordfile.docx] and click Open button');
        await CommonPageHelper.switchToContentFrame();
        await PageHelper.uploadFile(CommonPage.browseButton, filePath);

        // Selected file name is displayed on right side of Choose file button is not possible.

        StepLogger.stepId(5);
        StepLogger.step('Click OK button in Add a document popup');
        await PageHelper.click(CommonPage.formButtons.ok);

        StepLogger.verification('Add a document popup is to select file is closed');
        await browser.sleep(PageHelper.timeout.s);
        await expect(await CommonPage.browseButton.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        StepLogger.verification('Project Documents (Add a document) window displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.UpdatePropertyDocument))
            .toBe(true, ValidationsHelper.getDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentPropertyTitle));

        StepLogger.verification('Text The document was uploaded successfully. Use this form to update the' +
            ' properties of the document. on top of the window');
        await expect(await PageHelper.isElementPresent(CommonPage.uploadSuccessFullyText.message))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.documentUploadText));

        StepLogger.stepId(6);
        StepLogger.step('Click Save button in Add a document window');
        await PageHelper.click(CommonPage.formButtons.save);

        StepLogger.verification('Project Documents (Add a document) window is closed');
        await this.verifyUpdateDocumentPopUp();
    }

    static async verifyDocumentPopUp() {
        await WaitHelper.waitForElementOptionallyPresent(DocumentPage.documentTitle);
        await expect(await CommonPage.dialogTitle.getText()).toBe(HomePageConstants.addADocumentWindow.addADocumentTitle,
            ValidationsHelper.getDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

    }

    static async verifyUpdateDocumentPopUp() {
        await browser.sleep(PageHelper.timeout.s);
        await expect(await CommonPage.UpdatePropertyDocument.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentPropertyTitle));

    }
}
