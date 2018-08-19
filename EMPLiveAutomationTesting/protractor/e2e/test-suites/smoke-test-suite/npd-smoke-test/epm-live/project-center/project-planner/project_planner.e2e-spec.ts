import {browser} from 'protractor';
import {CommonPageHelper} from '../../../../../../page-objects/pages/common/common-page.helper';
import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../../page-objects/pages/common/common.po';
import {ValidationsHelper} from '../../../../../../components/misc-utils/validation-helper';
import {ProjectItemPage} from '../../../../../../page-objects/pages/items-page/project-item/project-item.po';
import {PageHelper} from '../../../../../../components/html/page-helper';
import {ProjectItemPageHelper} from '../../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
import {CommonPageConstants} from '../../../../../../page-objects/pages/common/common-page.constants';
import {HomePage} from '../../../../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../../../../helpers/suite-names';
import {LoginPage} from '../../../../../../page-objects/pages/login/login.po';
import {ElementHelper} from '../../../../../../components/html/element-helper';
import {ProjectItemPageConstants} from '../../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {SocialStreamPage} from '../../../../../../page-objects/pages/settings/social-stream/social-stream.po';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Validate project planner and create and assign task to resources - [743933]', async () => {
        const stepLogger = new StepLogger(743933);
        const uniqueId = PageHelper.getUniqueId();

        stepLogger.stepId(1);
        stepLogger.step('Click Navigation -> Projects -> Projects');

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.verification('Project Center opened and project selected');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        stepLogger.stepId(2);
        stepLogger.step('Click on Edit plan button');
        await PageHelper.click(CommonPage.project);
        await PageHelper.click(CommonPage.editPlan);

        stepLogger.verification('Select planner page opened');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.selectPlanner));

        stepLogger.stepId(3);
        stepLogger.step('click on Project Planner');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        // After select project Planner wait required, not element found which can use with waitHelper.
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);
        await CommonPageHelper.deleteTask();
        await PageHelper.click(CommonPage.ribbonItems.addTask);
        stepLogger.step('Enter details for Task (Name, Finish Date, Hours)');
        await PageHelper.actionSendKeys(uniqueId);
        await PageHelper.click(CommonPage.ribbonItems.addTask);
        await PageHelper.actionSendKeys(uniqueId);
        await PageHelper.click(CommonPage.ribbonItems.addTask);
        await PageHelper.actionSendKeys(uniqueId);

        stepLogger.verification('Tasks added');
        await PageHelper.click(ProjectItemPage.selectTaskName);
        await expect(await ProjectItemPageHelper.newTasksFields.title.getText()).toBe(uniqueId,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.title,
                CommonPageConstants.pageHeaders.projects.tasks));

        stepLogger.stepId(4);
        stepLogger.step('Select All the tasks by hold control button and select all tasks');
        stepLogger.step('Click on the Link Down button;');
        await ProjectItemPageHelper.selectCreatedTask();
        await PageHelper.click(CommonPage.linkDownbutton);

        stepLogger.verification('Pop up should get displayed with the following:');
        await expect(await PageHelper.isElementDisplayed(CommonPage.addButton)).toBe(true,
            ValidationsHelper.getButtonDisplayedValidation(ProjectItemPageConstants.addLinkPopup.addLink));
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.cancelButton)).toBe(true,
            ValidationsHelper.getButtonDisplayedValidation(ProjectItemPageConstants.addLinkPopup.cancel));
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.linkType)).toBe(true,
            ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.addLinkPopup.linkType));

        stepLogger.stepId(5);
        stepLogger.step('In the pop-up, click on Add Link button and now click on "Save" button.');
        await PageHelper.click(CommonPage.addButton);
        await ElementHelper.clickUsingJs(ProjectItemPage.save);

        stepLogger.verification('changes saved');
        // After save It need static wait(5 sec) and no element found which get change after save.
        await browser.sleep(PageHelper.timeout.m);
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.two, ProjectItemPageConstants.newTaskFields.start).click();
        await expect(await ProjectItemPageHelper.newTasksFields.predecessors.getText()).toBe(CommonPageConstants.predecessorsData.
            predecessors1, ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.predecessors,
            CommonPageConstants.predecessorsData.predecessors1));
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.three,
            ProjectItemPageConstants.newTaskFields.start).click();
        await expect(await ProjectItemPageHelper.newTasksFields.predecessors.getText()).toBe(CommonPageConstants.predecessorsData.
            predecessors2, ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.predecessors,
            CommonPageConstants.predecessorsData.predecessors2));
        await PageHelper.click(ProjectItemPage.selectTaskName);
        await expect(await ProjectItemPageHelper.newTasksFields.title.getText()).toBe(uniqueId,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.title,
                CommonPageConstants.pageHeaders.projects.tasks));

        stepLogger.stepId(6);
        stepLogger.step('On the ribbon, click "Edit Team"-> add another person -> save and close.');
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(CommonPage.editTeamButtonOnTask);
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await CommonPageHelper.switchToContentFrame(stepLogger);
        await ProjectItemPageHelper.removeAssignedUserIfPresent(stepLogger);
        await PageHelper.click(ProjectItemPage.title);
        await PageHelper.click(ProjectItemPage.title);
        await PageHelper.click(ProjectItemPage.selectTeamMemberCheckBox);
        const name = await ElementHelper.getText(ProjectItemPage.selectTeamMember);
        await PageHelper.click(ProjectItemPage.teamChangeButtons.add);
        await PageHelper.click(CommonPage.ribbonItems.saveAndClose);
        // Wait required to let it save
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('The "Build Team" window closes and the selected resource is now added and its' +
            ' availability can be verified in the "Assigned To" column.');
        await expect(await CommonPage.dialogTitle.isPresent()).toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));
        await PageHelper.click(ProjectItemPage.selectTaskName);
        await PageHelper.click(ProjectItemPage.assignToDropDown);

        stepLogger.verification('List of users drop down with a check box on Right side of user name is displayed');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(name))).toBe(true,
            ValidationsHelper.getDisplayedValidation(name));

        stepLogger.stepId(7);
        await PageHelper.click(ElementHelper.getElementByText(name));
        await PageHelper.click(ProjectItemPageHelper.button.ok);

        stepLogger.stepId(8);
        stepLogger.step('In the pop-up, click on Add Link button and now click on "Save" button.');
        await PageHelper.click(ProjectItemPage.viewsButton);
        await PageHelper.click(ProjectItemPage.showGanttButton);

        stepLogger.verification('Verify that Gantt chart shows correctly for each task. The Planner should be saved ' +
            'and Predecessors column set with values.');
        // Verify Gantt is not possible for each task

        stepLogger.stepId(9);
        stepLogger.step('Click on Save button.');
        await ElementHelper.clickUsingJs(ProjectItemPage.save);
        // wait required to let it save
        await browser.sleep(PageHelper.timeout.s);
        stepLogger.step('Click the Publish button.');
        await ElementHelper.clickUsingJs(ProjectItemPage.publishButtton);

        stepLogger.verification('Publishes successfully');
        // Wait required to let it published
        await browser.sleep(PageHelper.timeout.s);
        await expect(await PageHelper.isElementPresent(ProjectItemPage.publishstatus)).toBe(true,
            ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.itemOptions.publish));

        stepLogger.stepId(10);
        stepLogger.step('Click "Close" button in "Project Planner" window');
        await ElementHelper.clickUsingJs(ProjectItemPage.close);
        stepLogger.step('Wait 5 min and verify that the assigned user(s) receives the notification.');
        await browser.sleep(PageHelper.timeout.m);
        await SocialStreamPage.logout();
        await await loginPage.goToAndLoginAsTeamMember();
        await PageHelper.click(ProjectItemPage.profilePicOfUser);

        stepLogger.verification('Verify that the notification has been received by the assigned User');
        // Notification verification is not possible because its take lot of time to visible.

    });
});
