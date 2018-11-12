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
import {MyTimeOffPageConstants} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.constants';
import { ExpectationHelper } from '../../../../../components/misc-utils/expectation-helper';

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

    it('Navigate to My Work page - [855540]', async () => {
        StepLogger.caseId = 855540;
        StepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
        );
    });

    it('Create New Changes - [855545]', async () => {
        StepLogger.caseId = 855545;
        StepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
        );

        StepLogger.stepId(3);
        StepLogger.step('Click on "New Item" option from Manage tab');
        await PageHelper.click(MyWorkPage.newItem);

        StepLogger.step('Select "Change Item" option from menu');
        await PageHelper.click(MyWorkPage.newItemMenu.changesItem);

        StepLogger.verification('Wait for "Changes - New Item" window to open');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        StepLogger.verification('"Changes - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.changes))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.changes));

        StepLogger.stepId(4);
        StepLogger.step('Enter/Select required details in "Changes - New Item" window');
        await MyWorkPageHelper.fillNewItemFormForChanges();
    });

    it('Create New Issue - [855547]', async () => {
        StepLogger.caseId = 855547;
        StepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
        );

        StepLogger.stepId(3);
        StepLogger.step('Click on "New Item" option from Manage tab');
        await PageHelper.click(MyWorkPage.newItem);

        StepLogger.step('Select "Issues Item" option from menu');
        await PageHelper.click(MyWorkPage.newItemMenu.issuesItem);

        StepLogger.verification('Wait for "Issues - New Item" window to open');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        StepLogger.verification('"Issues - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.issues))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.issues));

        StepLogger.stepId(4);
        StepLogger.step('Enter/Select required details in "Issues - New Item" window');
        await MyWorkPageHelper.fillNewItemFormForIssues();
    });

    it('Create New Risks - [855550]', async () => {
        StepLogger.caseId = 855550;
        StepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
        );

        StepLogger.stepId(3);
        StepLogger.step('Click on "New Item" option from Manage tab');
        await PageHelper.click(MyWorkPage.newItem);

        StepLogger.step('Select "Risks Item" option from menu');
        await PageHelper.click(MyWorkPage.newItemMenu.risksItem);

        StepLogger.verification('Wait for "Risks - New Item" window to open');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        StepLogger.verification('"Risks - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.risks))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.risks));

        StepLogger.stepId(4);
        StepLogger.step('Enter/Select required details in "Risks - New Item" window');
        await MyWorkPageHelper.fillNewItemFormForRisks();
    });

    it('Create New Time Off - [855551]', async () => {
        StepLogger.caseId = 855551;
        StepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
        );

        StepLogger.stepId(3);
        StepLogger.step('Click on "New Item" option from Manage tab');
        await PageHelper.click(MyWorkPage.newItem);

        StepLogger.step('Select "Time Off Item" option from menu');
        await PageHelper.click(MyWorkPage.newItemMenu.timeOffItem);

        StepLogger.verification('Wait for "Time Off - New Item" window to open');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        StepLogger.verification('"Time Off - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.timeOff))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.timeOff));

        StepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        StepLogger.stepId(4);
        StepLogger.step('Enter/Select required details in "Time Off - New Item" window');
        const uniqueId = PageHelper.getUniqueId();
        const inputLabels = MyWorkPageConstants.inputLabels;
        const titleValue = `${inputLabels.title} ${uniqueId}`;
        // step#5 is inside this function
        await MyWorkPageHelper.fillTimeOffFormAndSave(titleValue, );

        StepLogger.stepId(6);
        StepLogger.verification('"Navigate to My Time Off page');
        await PageHelper.click(MyWorkplacePage.navigation.myTimeOff);

        StepLogger.verification('search for newly created projects');
        await CommonPageHelper.searchItemByTitle(titleValue, MyTimeOffPageConstants.columnNames.title, true);

        StepLogger.verification('searched projects should get displayed');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(titleValue));
    });

    it('Create New To Do item - [855560]', async () => {
        StepLogger.caseId = 855560;
        StepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
        );

        StepLogger.stepId(3);
        StepLogger.step('Click on "New Item" option from Manage tab');
        await PageHelper.click(MyWorkPage.newItem);

        StepLogger.step('Select "To Do Item" option from menu');
        await PageHelper.click(MyWorkPage.newItemMenu.toDoItem);

        StepLogger.verification('Wait for "To Do - New Item" window to open');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        StepLogger.verification('"To Do - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.toDo))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.toDo));

        StepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        StepLogger.stepId(4);
        StepLogger.step('Enter/Select required details in "To Do - New Item" window');
        const uniqueId = PageHelper.getUniqueId();
        const labels = MyWorkPageConstants.inputLabels;
        StepLogger.step(`Title *: New Item`);
        const titleValue = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, titleValue);
        StepLogger.step(`Assigned To: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.assignedTo, LoginPageHelper.adminEmailId);
        StepLogger.step(`select assignedTo value`);
        await PageHelper.click(MyWorkPage.assignedToSuggestions);

        StepLogger.stepId(5);
        StepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
        await WaitHelper.staticWait(PageHelper.timeout.s);

        StepLogger.verification('"To Do New Item" page is closed');
        await ExpectationHelper.verifyNotDisplayedStatus(CommonPage.formButtons.save, CommonPageConstants.formLabels.save);
    });

    /* #UNSTABLE
    it('Edit Item - Attach File - [855672]', async () => {
        StepLogger.caseId = 855672;
        StepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
        );

        // Common functionality to edit any item
        const item = CommonPage.recordWithoutGreenTicket;
        await WaitHelper.waitForElementToBeDisplayed(item);

        StepLogger.stepId(3);
        StepLogger.step('Click on the row of item created as per pre requisites');
        await PageHelper.click(item);
        const selectedTitle = await CommonPage.selectedTitle.getText();
        StepLogger.step('Click on "MANAGE" tab');
        await PageHelper.click(CommonPage.ribbonTitles.manage);

        StepLogger.step('Click on "Edit Item" button');
        await PageHelper.click(CommonPage.ribbonItems.editItem);

        StepLogger.verification('Edit work item pop-up should load successfully');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(true,
                ValidationsHelper.getWindowShouldBeDisplayedValidation(CommonPageConstants.ribbonLabels.editItem));

        StepLogger.verification('Selected item details displayed in editable mode in the pop up window');

        StepLogger.step('Switch to content frame');
        await CommonPageHelper.switchToContentFrame();

        // Avoiding - Element is not clickable at point (-9553, -9859)
        await browser.sleep(PageHelper.timeout.s);

        StepLogger.stepId(4);
        StepLogger.step('Click on "Attach File" button from button menu of popup');
        await PageHelper.click(CommonPage.ribbonItems.attachFile);

        StepLogger.verification('A popup displayed to attach file');
        await expect(await PageHelper.isElementDisplayed(CommonPage.fileUploadControl))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.fileUpload));

        StepLogger.stepId(5);
        StepLogger.step('Click on "Choose File" button in the pop up window Search and select the file to attach');
        const {fullFilePath, newFileName} = CommonPageHelper.uniqueDocumentFilePath;
        await PageHelper.uploadFile(CommonPage.fileUploadControl, fullFilePath);

        StepLogger.verification('Selected file name should be displayed in popup');
        await expect(await ElementHelper.getValue(CommonPage.fileUploadControl))
            .toContain(newFileName,
                ValidationsHelper.getFieldShouldHaveValueValidation(CommonPageConstants.fileUpload, newFileName));

        StepLogger.stepId(6);
        StepLogger.step('Click on "OK" button');
        await PageHelper.click(CommonPage.formButtons.ok);

        StepLogger.verification('Attached file is displayed at bottom of popup page');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFileName)))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(newFileName));

        StepLogger.stepId(7);
        StepLogger.step('Click on "Save" button in popup');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        // Nothing else is working to have it frame invisible
        await browser.sleep(PageHelper.timeout.m);

        StepLogger.verification('Popup window is closed');
        await WaitHelper.waitForElementToBeHidden(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editItem));

        StepLogger.stepId(8);
        StepLogger.step('Click on the row of item to which attachment is added [Ex: New Issue 1]');
        await TextboxHelper.sendKeys(CommonPage.searchTextBox, selectedTitle, true);
        await PageHelper.click(item);

        StepLogger.step('Click on "Manage" tab');
        await PageHelper.click(CommonPage.ribbonTitles.manage);

        StepLogger.step('Click on "View Item" button');
        await PageHelper.click(CommonPage.ribbonItems.viewItem);

        StepLogger.verification('Popup window is shown');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(true,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.viewItem));

        await CommonPageHelper.switchToContentFrame();

        StepLogger.verification('Verify that image is attached');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFileName)))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(newFileName));

        StepLogger.stepId(9);
        StepLogger.step('Click on "Close" button');
        await PageHelper.click(CommonPage.formButtons.close);

        await PageHelper.switchToDefaultContent();

        StepLogger.verification('View item page should be displayed and user should be in "My Work" list page');
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.myWork));
    });
    */

    /* #UNSTABLE
    it('Check that once task is assigned to user through Project Planner it shows up in his/her My Work page - [855881]',
        async () => {
            StepLogger.caseId = 855881;
            const uniqueId = PageHelper.getUniqueId();
            const user = ProjectItemPageConstants.teamMember;
            StepLogger.stepId(1);
            StepLogger.step('Select "Navigation" icon  from left side menu');
            StepLogger.step('Select Projects -> Projects from the options displayed');

            await CommonPageHelper.navigateToItemPageUnderNavigation(
                HomePage.navigation.projects.projects,
                CommonPage.pageHeaders.projects.projectsCenter,
                CommonPageConstants.pageHeaders.projects.projectCenter,
            );

            StepLogger.verification('Project Center page is displayed');
            await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
                .toBe(true,
                    ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

            StepLogger.stepId(2);
            StepLogger.step('Select on any of the project created as per pre requisites [Ex: Smoke Test Project 2]');
            StepLogger.step('Click on the ITEMS tab above the grid');
            StepLogger.step('From the ITEMS ribbon menu, click on Edit Plan');
            await CommonPageSubHelper.selectOneRecordFromGrid();
            await PageHelper.click(CommonPage.ribbonTitles.items);
            await PageHelper.click(CommonPage.editPlan);

            StepLogger.verification('Select Planner pop-up displays with different planner options to select');
            await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle)).toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.selectPlanner));

            StepLogger.stepId(3);
            StepLogger.step('click on Project Planner');
            await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);

            StepLogger.verification('"Project Planner" window is displayed');
            await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
                .toBe(true,
                    ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

            StepLogger.verification('NO Tasks displayed in Project Planner');
            // After select project Planner wait required, not element found which can use with waitHelper.
            await browser.sleep(PageHelper.timeout.m);
            await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);
            await CommonPageHelper.deleteTask();
            await expect(await ProjectItemPage.selectTaskName.isPresent()).toBe(false,
                ValidationsHelper.getNotDisplayedValidation(CommonPageConstants.pageHeaders.projects.tasks));

            StepLogger.stepId(4);
            StepLogger.step('Click on + Task button');
            StepLogger.step('Enter details for Task (Name, Finish Date, Hours)');
            await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours1, uniqueId);

            StepLogger.verification('A new task is created and required details entered [Ex: New Task 1]');
            await expect(await ProjectItemPageHelper.newTasksFields.title.getText()).toBe(uniqueId,
                ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.title, uniqueId));

            StepLogger.stepId(5);
            StepLogger.step('Click on "Assigned To" column');
            await ElementHelper.actionHoverOver(ProjectItemPage.assignToDropDown);
            await PageHelper.click(ProjectItemPage.assignToDropDown);

            StepLogger.step('Select the check box for user to which the task need to be assigned [Ex: User1 User1]');
            await PageHelper.click(ProjectItemPage.assignToDropDown);
            await ElementHelper.actionHoverOver(ProjectItemPageHelper.selectFirstAssign());

            StepLogger.step('Click OK button');
            await PageHelper.click(ProjectItemPageHelper.button.ok);

            StepLogger.verification('List of users drop down is closed');
            await expect(await ProjectItemPageHelper.selectLastAssign().isPresent()).toBe(false,
                ValidationsHelper.getNotDisplayedValidation(ProjectItemPageConstants.newTaskFields.assignedList));

            StepLogger.verification('Selected user name is displayed in "Assigned To" column [Ex: User1 User1] in' +
                ' "Project Planner" window');
            await expect(await ElementHelper.getElementByText(user).isPresent()).toBe(true,
                ValidationsHelper.getDisplayedValidation(user));

            StepLogger.stepId(6);
            StepLogger.step('Click on Save button from ribbon panel');
            await ElementHelper.clickUsingJs(ProjectItemPage.save);

            StepLogger.verification('Changes done in "Project Planner" window are saved');
            // After save It need static wait(5 sec) and no element found which get change after save.
            await browser.sleep(PageHelper.timeout.s);
            await expect(await ElementHelper.getText(ProjectItemPageHelper.newTasksFields.title)).toBe(uniqueId,
                ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.title, uniqueId));
            await expect(await ElementHelper.getElementByText(user).isPresent()).toBe(true,
                ValidationsHelper.getDisplayedValidation(user));

            StepLogger.stepId(7);
            StepLogger.step('Click on Publish button in Project Planner window');
            await ElementHelper.clickUsingJs(ProjectItemPage.publishButtton);

            StepLogger.step('Wait till the Publishing is completed [Publish Status will show the status]');
            StepLogger.verification('Project Planner details are published successfully');
            // Wait required to let it publish
            await browser.sleep(PageHelper.timeout.s);
            await expect(await PageHelper.isElementPresent(ProjectItemPage.publishstatus)).toBe(true,
                ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.itemOptions.publish));

            StepLogger.stepId(8);
            StepLogger.step('Click "Close" button in "Project Planner" window');
            await ElementHelper.clickUsingJs(ProjectItemPage.close);

            StepLogger.verification('Project Planner window is closed');
            await WaitHelper.waitForElementToBeDisplayed(CommonPage.pageHeaders.projects.projectsCenter);
            await expect(await CommonPage.pageHeaders.projects.projectPlanner.isPresent()).toBe(false,
                ValidationsHelper.getNotDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

            StepLogger.verification('Project Center page is displayed');
            await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter)).toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

            StepLogger.stepId(9);
            StepLogger.step('Login into application with the user credential to whom task is assigned in above steps [Ex: User1 User1]');
            await SocialStreamPage.logout();
            await loginPage.goToAndLoginAsTeamMember();
            await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
                MyWorkplacePage.navigation.myWork,
                CommonPage.pageHeaders.myWorkplace.myWork,
                CommonPageConstants.pageHeaders.myWorkplace.myWork,
            );

            await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(uniqueId))).toBe(true,
                ValidationsHelper.getDisplayedValidation(uniqueId));

        });
        */

});
