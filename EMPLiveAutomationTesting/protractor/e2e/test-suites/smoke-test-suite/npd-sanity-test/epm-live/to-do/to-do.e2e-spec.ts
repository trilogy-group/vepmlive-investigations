import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {ToDoPageHelper} from '../../../../../page-objects/pages/my-workplace/to-do/to-do-page.helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {ToDoPageConstants} from '../../../../../page-objects/pages/my-workplace/to-do/to-do-page.constants';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {ToDoPage} from '../../../../../page-objects/pages/my-workplace/to-do/to-do.po';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {browser} from 'protractor';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {MyWorkPageConstants} from '../../../../../page-objects/pages/my-workplace/my-work/my-work-page.constants';
import {MyWorkPage} from '../../../../../page-objects/pages/my-workplace/my-work/my-work.po';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Navigate to To Do page - [785576]', async () => {
        const stepLogger = new StepLogger(785576);
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
            stepLogger);
    });

    it('Add a To Do item - [785580]', async () => {
        const stepLogger = new StepLogger(785580);
        stepLogger.step('PRECONDITION: navigate to To Do page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
            stepLogger);

        stepLogger.stepId(1);
        stepLogger.step('Click on "+ new link" link displayed on top of "Discussions" page');
        await PageHelper.click(CommonPage.addNewLink);
        stepLogger.verification('"To Do - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ToDoPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ToDoPageConstants.pageName));

        stepLogger.stepId(2);
        stepLogger.step(`Enter/Select below details in 'New To Do' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = ToDoPageConstants.inputLabels;
        const title = `${labels.title} ${uniqueId}`;
        const status = CommonPageConstants.statuses.notStarted;
        const description = `${labels.description} ${uniqueId}`;
        // step#3 is inside this function
        await ToDoPageHelper.fillFormAndSave(title, status, description, stepLogger);

        stepLogger.stepId(4);
        stepLogger.step(`click on Close button`);
        await PageHelper.click(ToDoPage.closeButton.first());
        stepLogger.verification(`To Do page is displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.myWorkplace.toDo))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.toDo));
    });

    it('Edit To Do from Workplace - [785584]', async () => {
        const stepLogger = new StepLogger(785584);
        stepLogger.step('PRECONDITION: Navigate to To Page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
            stepLogger);

        stepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.actionTakenViaContextMenu(stepLogger, CommonPage.recordWithoutGreenTicket,
            CommonPage.contextMenuOptions.editItem);
        stepLogger.verification('"Edit Project" page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ToDoPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ToDoPageConstants.editPageName));

        stepLogger.stepId(3);
        stepLogger.step(`Enter/Select below details in 'Edit To Do' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = ToDoPageConstants.inputLabels;
        const title = `${labels.title} ${uniqueId}`;
        const status = CommonPageConstants.statuses.inProgress;
        const description = `${labels.description} ${uniqueId}`;
        await ToDoPageHelper.fillFormAndSave(title, status, description, stepLogger);
        stepLogger.verification(`'Edit To Do' page is closed`);
        await expect(await ToDoPage.inputs.title.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ToDoPageConstants.editPageName));
        stepLogger.verification(`To Do page is displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.myWorkplace.toDo))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.toDo));
    });

    it('Attach File - [852049]', async () => {
        const stepLogger = new StepLogger(1176340);
        stepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
            stepLogger);

        // Common functionality to edit any item
        const item = CommonPage.recordWithoutGreenTicket;
        await WaitHelper.getInstance().waitForElementToBeDisplayed(item);

        stepLogger.step('Click on the row of item created as per pre requisites');
        await PageHelper.click(item);
        const selectedTitle = await CommonPage.selectedTitle.getText();
        stepLogger.step('Click on "Manage" tab');
        await PageHelper.click(CommonPage.ribbonTitles.manage);
        stepLogger.step('Click on "Edit Item" button');
        await PageHelper.click(CommonPage.ribbonItems.editItem);

        stepLogger.verification('Edit work item pop-up should load successfully');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(true,
                ValidationsHelper.getWindowShouldBeDisplayedValidation(CommonPageConstants.ribbonLabels.editItem));

        stepLogger.verification('Selected item details displayed in editable mode in the pop up window');

        stepLogger.step('Switch to content frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        // Avoiding - Element is not clickable at point (-9553, -9859)
        await browser.sleep(PageHelper.timeout.s);

        stepLogger.stepId(4);
        stepLogger.step('Click on "Attach File" button from button menu of popup');
        await PageHelper.click(CommonPage.ribbonItems.attachFile);

        stepLogger.verification('A popup displayed to attach file');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.fileUploadControl))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(MyWorkPageConstants.fileUpload));

        stepLogger.stepId(5);
        stepLogger.step('Click on "Choose File" button in the pop up window Search and select the file to attach');
        const {fullFilePath, newFileName} = CommonPageHelper.uniqueDocumentFilePath;
        console.log(fullFilePath);
        await PageHelper.uploadFile(MyWorkPage.fileUploadControl, fullFilePath);

        stepLogger.verification('Selected file name should be displayed in popup');
        await expect(await ElementHelper.getValue(MyWorkPage.fileUploadControl))
            .toContain(newFileName,
                ValidationsHelper.getFieldShouldHaveValueValidation(MyWorkPageConstants.fileUpload, newFileName));

        stepLogger.stepId(6);
        stepLogger.step('Click on "OK" button');
        await PageHelper.click(CommonPage.formButtons.ok);

        stepLogger.verification('Attached file is displayed at bottom of popup page');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFileName, true)))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(newFileName));

        stepLogger.stepId(7);
        stepLogger.step('Click on "Save" button in popup');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        // Nothing else is working to have it invisible
        await browser.sleep(PageHelper.timeout.m);

        stepLogger.verification('Popup window is closed');
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editItem));

        stepLogger.stepId(8);
        stepLogger.step('Click on the row of item to which attachment is added [Ex: New Issue 1]');
        await TextboxHelper.sendKeys(MyWorkPage.searchTextBox, selectedTitle, true);
        await PageHelper.click(item);

        stepLogger.step('Click on "Manage" tab');
        await PageHelper.click(CommonPage.ribbonTitles.manage);

        stepLogger.step('Click on "View Item" button');
        await PageHelper.click(CommonPage.ribbonItems.viewItem);

        stepLogger.verification('Popup window is shown');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(true,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.viewItem));

        stepLogger.step('Switch to content frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFileName)))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(newFileName));
    });
});
