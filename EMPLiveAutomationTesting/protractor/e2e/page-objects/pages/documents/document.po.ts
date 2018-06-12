import {PageHelper} from '../../../components/html/page-helper';
import {HomePage} from '../homepage/home.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {HomePageConstants} from '../homepage/home-page.constants';
import {CommonPage} from '../common/common.po';
import {ElementHelper} from '../../../components/html/element-helper';
import {browser} from 'protractor';
import {CommonPageConstants} from '../common/common-page.constants';
import {TextboxHelper} from '../../../components/html/textbox-helper';
import {CheckboxHelper} from '../../../components/html/checkbox-helper';

export class DocumentPage {

    static async uploadDocument(filePath: string, stepLogger: StepLogger, newVersionFile: boolean) {
        stepLogger.stepId(2);
        stepLogger.step('Click on + More button displayed in CREATE options in social stream');
        await ElementHelper.click(HomePage.toolBarMenuItems.more);

        stepLogger.step('Click on Project Document link from the options displayed');
        await ElementHelper.click(HomePage.toolBarMenuItems.projectDocument);

        stepLogger.verification('Add a document pop up displayed');
        await expect(CommonPage.dialogTitle.getText()).toBe(HomePageConstants.addADocumentWindow.addADocumentTitle,
            ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        stepLogger.stepId(3);
        stepLogger.step('Click on Choose File button in Add a document pop up > Browse and select the file ' +
            'that need to be added as a Project document [Ex: testfile.txt]');
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        await PageHelper.uploadFile(HomePage.chooseAfile, filePath);

        if (newVersionFile === true) {

            stepLogger.step('Select Check the check box Add as a new version to existing files');
            await CheckboxHelper.markCheckbox(CommonPage.newVersionCheckbox, true);

            stepLogger.step('Version Comments: Enter some comments [Ex: New Version of previously updated file]');
            await TextboxHelper.sendKeys(CommonPage.versionCommentField, CommonPageConstants.versionComment.first);

        }

        stepLogger.step('Click on OK');
        await PageHelper.click(CommonPage.formButtons.ok);

        stepLogger.verification('Add a document pop up is closed');
        await expect(HomePage.chooseAfile.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        stepLogger.verification('Add a document window to update the properties of the document is displayed');
        await expect(CommonPage.UpdatePropertyDocument.isDisplayed())
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentPropertyTitle));

        stepLogger.stepId(4);
        stepLogger.step('Click Save button in Add a document window');
        await PageHelper.click(CommonPage.formButtons.save);

        stepLogger.verification('Add a document window to update the properties of the document is closed');
        await expect(CommonPage.UpdatePropertyDocument.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentPropertyTitle));

        stepLogger.verification('Home Page is displayed');
        await expect(browser.getTitle())
            .toBe(HomePageConstants.homePage, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.pageName));

        // Notification is not visible after save.

        stepLogger.stepId(5);
        stepLogger.step('Select Navigation icon  from left side menu');
        await PageHelper.click(HomePage.navigateMenu);

        stepLogger.step('Select Projects -> Documents from the options displayed');
        await PageHelper.click(HomePage.navigation.projects.documents);

        stepLogger.verification('Project Documents page is displayed');
        await expect(browser.getTitle()).toBe(HomePageConstants.documentPage,
            ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.navigationLabels.projects.documents));

        stepLogger.verification('Project node is displayed in collapsed state');
        await expect(CommonPage.projectsList.isDisplayed()).toBe(true,
            ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.navigationLabels.projects.projectNodeCollapsed));

        stepLogger.stepId(6);
        stepLogger.step('Click on the Project node to expand it');
        await PageHelper.click(CommonPage.projectsList);

    }

}
