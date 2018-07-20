import {browser} from 'protractor';
import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {MyWorkPage} from '../../../../../page-objects/pages/my-workplace/my-work/my-work.po';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {MyWorkPageConstants} from '../../../../../page-objects/pages/my-workplace/my-work/my-work-page.constants';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {MyWorkPageHelper} from '../../../../../page-objects/pages/my-workplace/my-work/my-work-page.helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {LoginPageHelper} from '../../../../../page-objects/pages/login/login-page.helper';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {MyTimeOffPageConstants} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.constants';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {ProjectItemPage} from '../../../../../page-objects/pages/items-page/project-item/project-item.po';
import {ProjectItemPageHelper} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {SocialStreamPage} from '../../../../../page-objects/pages/settings/social-stream/social-stream.po';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Navigate to My Work page - [855540]', async () => {
        const stepLogger = new StepLogger(855540);
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);
    });

    it('Create New Changes - [855545]', async () => {
        const stepLogger = new StepLogger(855545);
        stepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "New Item" option from Manage tab');
        await PageHelper.click(MyWorkPage.newItem);

        stepLogger.step('Select "Change Item" option from menu');
        await PageHelper.click(MyWorkPage.newItemMenu.changesItem);

        stepLogger.verification('Wait for "Changes - New Item" window to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        stepLogger.verification('"Changes - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.changes))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.changes));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Changes - New Item" window');
        await MyWorkPageHelper.fillFormAndSave(stepLogger);
    });

    it('Create New Issue - [855547]', async () => {
        const stepLogger = new StepLogger(855547);
        stepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "New Item" option from Manage tab');
        await PageHelper.click(MyWorkPage.newItem);

        stepLogger.step('Select "Issues Item" option from menu');
        await PageHelper.click(MyWorkPage.newItemMenu.issuesItem);

        stepLogger.verification('Wait for "Issues - New Item" window to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        stepLogger.verification('"Issues - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.issues))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.issues));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Issues - New Item" window');
        await MyWorkPageHelper.fillFormAndSave(stepLogger);
    });

    it('Create New Risks - [855550]', async () => {
        const stepLogger = new StepLogger(855550);
        stepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "New Item" option from Manage tab');
        await PageHelper.click(MyWorkPage.newItem);

        stepLogger.step('Select "Risks Item" option from menu');
        await PageHelper.click(MyWorkPage.newItemMenu.risksItem);

        stepLogger.verification('Wait for "Risks - New Item" window to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        stepLogger.verification('"Risks - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.risks))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.risks));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Risks - New Item" window');
        await MyWorkPageHelper.fillFormAndSave(stepLogger);
    });

    it('Create New Time Off - [855551]', async () => {
        const stepLogger = new StepLogger(855551);
        stepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "New Item" option from Manage tab');
        await PageHelper.click(MyWorkPage.newItem);

        stepLogger.step('Select "Time Off Item" option from menu');
        await PageHelper.click(MyWorkPage.newItemMenu.timeOffItem);

        stepLogger.verification('Wait for "Time Off - New Item" window to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        stepLogger.verification('"Time Off - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.timeOff))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.timeOff));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Time Off - New Item" window');
        const uniqueId = PageHelper.getUniqueId();
        const inputLabels = MyWorkPageConstants.inputLabels;
        const titleValue = `${inputLabels.title} ${uniqueId}`;
        // step#5 is inside this function
        await MyWorkPageHelper.fillTimeOffFormAndSave(titleValue, stepLogger);

        stepLogger.stepId(6);
        stepLogger.verification('"Navigate to My Time Off page');
        await PageHelper.click( MyWorkplacePage.navigation.myTimeOff);

        stepLogger.verification('search for newly created projects');
        await CommonPageHelper.searchItemByTitle(titleValue, MyTimeOffPageConstants.columnNames.title, stepLogger, true);

        stepLogger.verification('searched projects should get displayed');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
                .toBe(true, ValidationsHelper.getLabelDisplayedValidation(titleValue));
    });

    it('Create New To Do item - [855560]', async () => {
        const stepLogger = new StepLogger(855560);
        stepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "New Item" option from Manage tab');
        await PageHelper.click(MyWorkPage.newItem);

        stepLogger.step('Select "To Do Item" option from menu');
        await PageHelper.click(MyWorkPage.newItemMenu.toDoItem);

        stepLogger.verification('Wait for "To Do - New Item" window to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        stepLogger.verification('"To Do - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.toDo))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.toDo));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "To Do - New Item" window');
        const uniqueId = PageHelper.getUniqueId();
        const labels = MyWorkPageConstants.inputLabels;
        stepLogger.step(`Title *: New Item`);
        const titleValue = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, titleValue);
        stepLogger.step(`Assigned To: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.assignedTo, LoginPageHelper.adminEmailId);
        stepLogger.step(`select assignedTo value`);
        await PageHelper.click(MyWorkPage.selectValueFromSuggestions(LoginPageHelper.adminEmailId));

        stepLogger.stepId(5);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"To Do New Item" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(MyWorkPageConstants.editPageName));
        // Wait for the page to close after clicking on save. This is to reduce window close synchronization issues
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.m);
    });

    it('Edit Item - Attach File - [855672]', async () => {
        const stepLogger = new StepLogger(855672);
        stepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);

        // Common functionality to edit any item
        const item = CommonPage.recordWithoutGreenTicket;
        await WaitHelper.getInstance().waitForElementToBeDisplayed(item);

        stepLogger.stepId(3);
        stepLogger.step('Click on the row of item created as per pre requisites');
        await PageHelper.click(item);
        const selectedTitle = await CommonPage.selectedTitle.getText();
        stepLogger.step('Click on "MANAGE" tab');
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
        await expect(await PageHelper.isElementDisplayed(CommonPage.fileUploadControl))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.fileUpload));

        stepLogger.stepId(5);
        stepLogger.step('Click on "Choose File" button in the pop up window Search and select the file to attach');
        const {fullFilePath, newFileName} = CommonPageHelper.uniqueDocumentFilePath;
        await PageHelper.uploadFile(CommonPage.fileUploadControl, fullFilePath);

        stepLogger.verification('Selected file name should be displayed in popup');
        await expect(await ElementHelper.getValue(CommonPage.fileUploadControl))
            .toContain(newFileName,
                ValidationsHelper.getFieldShouldHaveValueValidation(CommonPageConstants.fileUpload, newFileName));

        stepLogger.stepId(6);
        stepLogger.step('Click on "OK" button');
        await PageHelper.click(CommonPage.formButtons.ok);

        stepLogger.verification('Attached file is displayed at bottom of popup page');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFileName)))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(newFileName));

        stepLogger.stepId(7);
        stepLogger.step('Click on "Save" button in popup');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        // Nothing else is working to have it frame invisible
        await browser.sleep(PageHelper.timeout.m);

        stepLogger.verification('Popup window is closed');
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editItem));

        stepLogger.stepId(8);
        stepLogger.step('Click on the row of item to which attachment is added [Ex: New Issue 1]');
        await TextboxHelper.sendKeys(CommonPage.searchTextBox, selectedTitle, true);
        await PageHelper.click(item);

        stepLogger.step('Click on "Manage" tab');
        await PageHelper.click(CommonPage.ribbonTitles.manage);

        stepLogger.step('Click on "View Item" button');
        await PageHelper.click(CommonPage.ribbonItems.viewItem);

        stepLogger.verification('Popup window is shown');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(true,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.viewItem));

        await CommonPageHelper.switchToContentFrame(stepLogger);

        stepLogger.verification('Verify that image is attached');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFileName)))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(newFileName));

        stepLogger.stepId(9);
        stepLogger.step('Click on "Close" button');
        await PageHelper.click(CommonPage.formButtons.close);

        await PageHelper.switchToDefaultContent();

        stepLogger.verification('View item page should be displayed and user should be in "My Work" list page');
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.myWork));
    });

    it('Check that once task is assigned to user through Project Planner it shows up in his/her My Work page - [855881]',
        async () => {
        const stepLogger = new StepLogger(855881);
        const uniqueId = PageHelper.getUniqueId();
        const user = ProjectItemPageConstants.teamMember;
        stepLogger.stepId(1);
        stepLogger.step('Select "Navigation" icon  from left side menu');
        stepLogger.step('Select Projects -> Projects from the options displayed');

        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.verification('Project Center page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        stepLogger.stepId(2);
        stepLogger.step('Select on any of the project created as per pre requisites [Ex: Smoke Test Project 2]');
        stepLogger.step('Click on the ITEMS tab above the grid');
        stepLogger.step('From the ITEMS ribbon menu, click on Edit Plan');
        await PageHelper.click(CommonPage.projectCheckbox);
        await PageHelper.click(CommonPage.ribbonTitles.items);
        await PageHelper.click(CommonPage.editPlan);

        stepLogger.verification('Select Planner pop-up displays with different planner options to select');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.selectPlanner));

        stepLogger.stepId(3);
        stepLogger.step('click on Project Planner');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);

        stepLogger.verification('"Project Planner" window is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        stepLogger.verification('NO Tasks displayed in Project Planner');
        // After select project Planner wait required, not element found which can use with waitHelper.
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.plannerbox);
        await CommonPageHelper.deleteTask();
        await expect(await ProjectItemPage.selectTaskName.isPresent()).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(CommonPageConstants.pageHeaders.projects.tasks));

        stepLogger.stepId(4);
        stepLogger.step('Click on + Task button');
        stepLogger.step('Enter details for Task (Name, Finish Date, Hours)');
        await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours1, uniqueId);

        stepLogger.verification('A new task is created and required details entered [Ex: New Task 1]');
        await expect(await ProjectItemPageHelper.newTasksFields.title.getText()).toBe(uniqueId,
                ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.title, uniqueId));

        stepLogger.stepId(5);
        stepLogger.step('Click on "Assigned To" column');
        await PageHelper.click(ProjectItemPage.assignToDropDown);

        stepLogger.step('Select the check box for user to which the task need to be assigned [Ex: User1 User1]');
        await PageHelper.click(ProjectItemPageHelper.selectLastAssign());

        stepLogger.step('Click OK button');
        await PageHelper.click(ProjectItemPageHelper.button.ok);

        stepLogger.verification('List of users drop down is closed');
        await expect(await ProjectItemPageHelper.selectLastAssign().isPresent()).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(ProjectItemPageConstants.newTaskFields.assignedList));

        stepLogger.verification('Selected user name is displayed in "Assigned To" column [Ex: User1 User1] in' +
            ' "Project Planner" window');
        await expect(await ElementHelper.getElementByText(user).isPresent()).toBe(true,
            ValidationsHelper.getDisplayedValidation(user));

        stepLogger.stepId(6);
        stepLogger.step('Click on Save button from ribbon panel');
        await ElementHelper.clickUsingJs(ProjectItemPage.save);

        stepLogger.verification('Changes done in "Project Planner" window are saved');
        // After save It need static wait(5 sec) and no element found which get change after save.
        await browser.sleep(PageHelper.timeout.s);
        await expect(await ElementHelper.getText(ProjectItemPageHelper.newTasksFields.title)).toBe(uniqueId,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.title, uniqueId));
        await expect(await ElementHelper.getElementByText(user).isPresent()).toBe(true,
            ValidationsHelper.getDisplayedValidation(user));

        stepLogger.stepId(7);
        stepLogger.step('Click on Publish button in Project Planner window');
        await ElementHelper.clickUsingJs(ProjectItemPage.publishButtton);

        stepLogger.step('Wait till the Publishing is completed [Publish Status will show the status]');
        stepLogger.verification('Project Planner details are published successfully');
        // Wait required to let it publish
        await browser.sleep(PageHelper.timeout.s);
        await expect(await PageHelper.isElementPresent(ProjectItemPage.publishstatus)).toBe(true,
            ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.itemOptions.publish));

        stepLogger.stepId(8);
        stepLogger.step('Click "Close" button in "Project Planner" window');
        await ElementHelper.clickUsingJs(ProjectItemPage.close);

        stepLogger.verification('Project Planner window is closed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.pageHeaders.projects.projectsCenter);
        await expect(await CommonPage.pageHeaders.projects.projectPlanner.isPresent()).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        stepLogger.verification('Project Center page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        stepLogger.stepId(9);
        stepLogger.step('Login into application with the user credential to whom task is assigned in above steps [Ex: User1 User1]');
        await SocialStreamPage.logout();
        await loginPage.goToAndLoginAsTeamMember();
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);

        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(uniqueId))).toBe(true,
            ValidationsHelper.getDisplayedValidation(uniqueId));

        });

});
