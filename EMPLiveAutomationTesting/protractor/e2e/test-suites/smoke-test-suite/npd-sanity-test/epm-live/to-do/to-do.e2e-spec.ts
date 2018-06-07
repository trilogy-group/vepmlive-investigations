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
import {AnchorHelper} from '../../../../../components/html/anchor-helper';

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
        const label = AnchorHelper.getElementsByTextInsideGrid(labels.title);
        stepLogger.step(`Newly created ToDo [Ex: Title 1] displayed in "ToDo" page`);
        await CommonPageHelper.checkItemCreated(title, label);
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
        await CommonPageHelper.actionTakenViaContextMenu(CommonPage.recordWithoutGreenTicket,
            CommonPage.contextMenuOptions.editItem, stepLogger);
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
        const label = AnchorHelper.getElementsByTextInsideGrid(labels.title, true);
        stepLogger.step(`Modified Title of ToDo [Ex: Title 1] displayed in "ToDo" page`);
        await CommonPageHelper.checkItemCreated(title, label);
    });

    it('To Do - Attach File - [852049]', async () => {
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

        stepLogger.stepId(1);
        stepLogger.step('Click on the row of item created as per pre requisites');
        await PageHelper.click(item);
        stepLogger.step('Click on "ITEMS" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        stepLogger.verification('contents of the ITEMS tan should be displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.attachFile))
            .toBe(true,
                ValidationsHelper.getItemsUnderTabShouldBeDisplayed(CommonPageConstants.ribbonMenuTitles.items));

        stepLogger.stepId(2);
        stepLogger.step('Click on "Attach File" button from button menu of popup');
        await PageHelper.click(CommonPage.ribbonItems.attachFile);

        await CommonPageHelper.switchToContentFrame(stepLogger);

        stepLogger.verification('A popup displayed to attach file');
        await expect(await PageHelper.isElementDisplayed(CommonPage.fileUploadControl))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.fileUpload));

        // 3 and 4 are same from automation perspective
        stepLogger.stepId(3);
        stepLogger.stepId(4);
        stepLogger.step('Click on "Choose File" button in the pop up window Search and select the file to attach');
        const {fullFilePath, newFileName} = CommonPageHelper.uniqueDocumentFilePath;
        await PageHelper.uploadFile(CommonPage.fileUploadControl, fullFilePath);

        stepLogger.verification('Selected file name should be displayed in popup');
        await expect(await ElementHelper.getValue(CommonPage.fileUploadControl))
            .toContain(newFileName,
                ValidationsHelper.getFieldShouldHaveValueValidation(CommonPageConstants.fileUpload, newFileName));

        stepLogger.stepId(5);
        stepLogger.step('Click on "OK" button');
        await PageHelper.click(CommonPage.formButtons.okWithSmallK);

        await PageHelper.switchToDefaultContent();

        // Nothing else is working to have it frame invisible
        await browser.sleep(PageHelper.timeout.m);

        stepLogger.verification('Popup window is closed');
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editItem));

        stepLogger.stepId(6);
        stepLogger.step('Select that "To Do" item from grid and click on "View Item" from its contextual menu');
        await CommonPageHelper.actionTakenViaContextMenu(CommonPage.recordWithoutGreenTicket,
            CommonPage.contextMenuOptions.viewItem,
            stepLogger);

        stepLogger.stepId(7);
        stepLogger.step('Check that the attached file get display under "Attachments" section');
        stepLogger.step('The attached file should be displayed under "Attachments" section');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFileName)))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(newFileName));

        stepLogger.stepId(8);
        stepLogger.step('Click on "Close" button');
        await PageHelper.click(CommonPage.formButtons.close);

        stepLogger.verification('View item page should be displayed and user should be in "To Do" list page');
        await expect(await PageHelper.isElementDisplayed(item))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.toDo));
    });
});
