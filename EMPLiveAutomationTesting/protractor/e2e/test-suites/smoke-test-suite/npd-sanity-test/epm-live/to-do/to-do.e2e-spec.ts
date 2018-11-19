import {browser} from 'protractor';
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
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {SocialStreamPage} from '../../../../../page-objects/pages/settings/social-stream/social-stream.po';
import {SocialStreamPageConstants} from '../../../../../page-objects/pages/settings/social-stream/social-stream-page.constants';

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

    it('Navigate to To Do page - [785576]', async () => {
        StepLogger.caseId = 785576;
        StepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
        );
    });

    it('Add a To Do item - [785580]', async () => {
        StepLogger.caseId = 785580;
        StepLogger.step('preCondition: navigate to To Do page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
        );

        StepLogger.stepId(1);
        StepLogger.step('Click on "+ new link" link displayed on top of "Discussions" page');
        await PageHelper.click(CommonPage.addNewLink);
        StepLogger.verification('"To Do - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ToDoPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ToDoPageConstants.pageName));

        StepLogger.stepId(2);
        StepLogger.step(`Enter/Select below details in 'New To Do' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = ToDoPageConstants.inputLabels;
        const title = `${labels.title} ${uniqueId}`;
        const status = CommonPageConstants.statuses.notStarted;
        const description = `${labels.description} ${uniqueId}`;
        // step#3 is inside this function
        await ToDoPageHelper.fillFormAndSave(title, status, description);

        StepLogger.stepId(4);
        StepLogger.step(`click on Close button`);
        await PageHelper.click(ToDoPage.closeButton.first());
        StepLogger.verification(`To Do page is displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.myWorkplace.toDo))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.toDo));
        const label = AnchorHelper.getElementsByTextInsideGrid(labels.title);
        StepLogger.step(`Newly created ToDo [Ex: Title 1] displayed in "ToDo" page`);
        await CommonPageHelper.checkItemCreated(title, label);
    });

    it('Edit To Do from Workplace - [785584]', async () => {
        StepLogger.caseId = 785584;
        StepLogger.step('preCondition: Navigate to To Page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
        );

        StepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.actionTakenViaContextMenu(CommonPage.recordWithoutGreenTicket,
            CommonPage.contextMenuOptions.editItem);
        StepLogger.verification('"Edit Project" page is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ToDoPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ToDoPageConstants.editPageName));

        StepLogger.stepId(3);
        StepLogger.step(`Enter/Select below details in 'Edit To Do' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = ToDoPageConstants.inputLabels;
        const title = `${labels.title} ${uniqueId}`;
        const status = CommonPageConstants.statuses.inProgress;
        const description = `${labels.description} ${uniqueId}`;
        await ToDoPageHelper.fillFormAndSave(title, status, description);
        StepLogger.verification(`'Edit To Do' page is closed`);
        await expect(await ToDoPage.inputs.title.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ToDoPageConstants.editPageName));
        StepLogger.verification(`To Do page is displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.myWorkplace.toDo))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.toDo));
        const label = AnchorHelper.getElementsByTextInsideGrid(labels.title, true);
        StepLogger.step(`Modified Title of ToDo [Ex: Title 1] displayed in "ToDo" page`);
        await CommonPageHelper.checkItemCreated(title, label);
    });

    /* #UNSTABLE
    it('To Do - Attach File - [852049]', async () => {
        StepLogger.caseId = 852049;
        StepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
        );

        // Common functionality to edit any item
        const item = CommonPage.recordWithoutGreenTicket;
        await WaitHelper.waitForElementToBeDisplayed(item);

        StepLogger.stepId(1);
        StepLogger.step('Click on the row of item created as per pre requisites');
        await PageHelper.click(item);
        StepLogger.step('Click on "ITEMS" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        StepLogger.verification('contents of the ITEMS tan should be displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.attachFile))
            .toBe(true,
                ValidationsHelper.getItemsUnderTabShouldBeDisplayed(CommonPageConstants.ribbonMenuTitles.items));

        StepLogger.stepId(2);
        StepLogger.step('Click on "Attach File" button from button menu of popup');
        await PageHelper.click(CommonPage.ribbonItems.attachFile);

        await CommonPageHelper.switchToContentFrame();

        StepLogger.verification('A popup displayed to attach file');
        await expect(await PageHelper.isElementDisplayed(CommonPage.fileUploadControl))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.fileUpload));

        // 3 and 4 are same from automation perspective
        StepLogger.stepId(3);
        StepLogger.stepId(4);
        StepLogger.step('Click on "Choose File" button in the pop up window Search and select the file to attach');
        const {fullFilePath, newFileName} = CommonPageHelper.uniqueDocumentFilePath;
        await PageHelper.uploadFile(CommonPage.fileUploadControl, fullFilePath);

        StepLogger.verification('Selected file name should be displayed in popup');
        await expect(await ElementHelper.getValue(CommonPage.fileUploadControl))
            .toContain(newFileName,
                ValidationsHelper.getFieldShouldHaveValueValidation(CommonPageConstants.fileUpload, newFileName));

        StepLogger.stepId(5);
        StepLogger.step('Click on "OK" button');
        await PageHelper.click(CommonPage.formButtons.okWithSmallK);

        await PageHelper.switchToDefaultContent();

        // Nothing else is working to have it frame invisible
        await browser.sleep(PageHelper.timeout.m);

        StepLogger.verification('Popup window is closed');
        await WaitHelper.waitForElementToBeHidden(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editItem));

        StepLogger.stepId(6);
        StepLogger.step('Select that "To Do" item from grid and click on "View Item" from its contextual menu');
        await CommonPageHelper.actionTakenViaContextMenu(CommonPage.recordWithoutGreenTicket,
            CommonPage.contextMenuOptions.viewItem,
        );

        StepLogger.stepId(7);
        StepLogger.step('Check that the attached file get display under "Attachments" section');
        StepLogger.step('The attached file should be displayed under "Attachments" section');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFileName)))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(newFileName));

        StepLogger.stepId(8);
        StepLogger.step('Click on "Close" button');
        await PageHelper.click(CommonPage.formButtons.close);

        StepLogger.verification('View item page should be displayed and user should be in "To Do" list page');
        await expect(await PageHelper.isElementDisplayed(item))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.toDo));
    });
    */

    it('Add Grid/Gantt web part - [785834]', async () => {
        StepLogger.caseId = 785834;
        // Delete previous created Grid/Gantt
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
        );
        await PageHelper.click(CommonPage.sidebarMenus.settings);
        await PageHelper.click(SocialStreamPage.settingItems.editPage);
        await ToDoPageHelper.deleteGridGantt();

        StepLogger.step('preCondition: navigate to To Do page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
        );

        StepLogger.stepId(1);
        StepLogger.step('Verify that the Grid/ Gantt web part is not added in page and page looks as below:');
        StepLogger.verification('Grid/ Gantt web part should not have got added in the page');
        await expect(await ToDoPage.gridGantt.isPresent())
            .toBe(false,
                ValidationsHelper.getNotDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.gridGantt));

        StepLogger.stepId(2);
        StepLogger.step(`Click on 'Main Gear Settings' display in left bottom corner`);
        await PageHelper.click(CommonPage.sidebarMenus.settings);

        StepLogger.verification('the Settings menu should be displayed in the left navigation');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.settingMenu)).toBe(true,
            ValidationsHelper.getMenuDisplayedValidation(SocialStreamPageConstants.validations.settingMenu));

        StepLogger.stepId(3);
        StepLogger.step('Click on Edit Page');
        await PageHelper.click(SocialStreamPage.settingItems.editPage);

        StepLogger.verification('the page should be opened in Edit mode');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.webPartAdderUpdatePanel)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.validations.homePage));

        StepLogger.stepId(4);
        StepLogger.step(`Click on 'Add a Web Part' link`);
        await PageHelper.click(SocialStreamPage.addAWebpart);

        StepLogger.verification('the respective section to add a web part should be opened and displayed');
        await expect(await PageHelper.isElementDisplayed(SocialStreamPage.webPartAdderUpdatePanel)).toBe(true,
            ValidationsHelper.getDisplayedValidation(SocialStreamPageConstants.validations.homePage));

        StepLogger.stepId(5);
        StepLogger.step('Select Categories EPM Live and Part as Grid/ Gantt Click on Add');
        await PageHelper.click(SocialStreamPage.settingItems.epmLive);
        await PageHelper.click(SocialStreamPage.settingItems.gridGantt);
        await PageHelper.click(SocialStreamPage.addButton);

        StepLogger.verification('Grid/ Gantt web part should be applied in To Do page');
        await expect(await PageHelper.isElementDisplayed(ToDoPage.gridGantt)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.gridGantt));

        StepLogger.stepId(6);
        StepLogger.step(`Click on Page tab >> 'Stop Editing'`);
        await PageHelper.click(SocialStreamPage.settingItems.page);
        await PageHelper.click(SocialStreamPage.stopEditing);

        StepLogger.verification('User should be on To Do list page and all item should be displayed in grid.');
        await browser.sleep(PageHelper.timeout.m);
        await expect(await PageHelper.isElementDisplayed(ToDoPage.gridGantt)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.toDo));
    });
});
