import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../../page-objects/pages/common/common.po';
import {PageHelper} from '../../../../../../components/html/page-helper';
import {SuiteNames} from '../../../../../helpers/suite-names';
import {LoginPage} from '../../../../../../page-objects/pages/login/login.po';
import {CommonPageHelper} from '../../../../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../../../../page-objects/pages/homepage/home.po';
import {CommonPageConstants} from '../../../../../../page-objects/pages/common/common-page.constants';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
import {ProjectItemPageHelper} from '../../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {browser} from 'protractor';
import {ProjectItemPage} from '../../../../../../page-objects/pages/items-page/project-item/project-item.po';
import {ElementHelper} from '../../../../../../components/html/element-helper';
import {ProjectItemPageConstants} from '../../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {ValidationsHelper} from '../../../../../../components/misc-utils/validation-helper';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    fit('Decrease Task1\'s Duration (Respective Links=ON, Start ASAP =ON) - [1035340]', async () => {
        const stepLogger = new StepLogger(1035340);
        stepLogger.precondition('Execute steps# 1 to 4 in test case C743761 and add 2 tasks in the project ' +
            'created in pre requisite# 3 [Ex: Smoke Test Project 2:: New Task 1, New Task 2]');
        const uniqueId = PageHelper.getUniqueId();
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.pageHeaders.projects.projectsCenter);
        await PageHelper.click(CommonPage.project);
        await PageHelper.click(CommonPage.editPlan);
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.plannerbox);
        await CommonPageHelper.deleteTask();

        stepLogger.stepId(1);
        stepLogger.step('Click on "Task" button');
        stepLogger.step('Enter details for Task (Name, Hours)');
        await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours1, uniqueId);
        await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours2, uniqueId);
        await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours3, uniqueId);
        await ElementHelper.clickUsingJs(ProjectItemPage.save);

        stepLogger.verification('Third Task is created and required details entered [Ex: New Task 3]');
        stepLogger.verification('Changes done in "Project Planner" page are saved');
        // After save It need static wait(5 sec) and no element found which get change after save.
        await browser.sleep(PageHelper.timeout.s);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ProjectItemPageHelper.newTasksFields.title);
        await ProjectItemPageHelper.getselectTask(1, ProjectItemPageConstants.newTaskFields.start).click();
        await ProjectItemPageHelper.verifyTitleAndDuration(uniqueId, CommonPageConstants.hours.durationHours1);
        await ProjectItemPageHelper.getselectTask(2, ProjectItemPageConstants.newTaskFields.start).click();
        await ProjectItemPageHelper.verifyTitleAndDuration(uniqueId, CommonPageConstants.hours.durationHours2);
        await ProjectItemPageHelper.getselectTask(3, ProjectItemPageConstants.newTaskFields.start).click();
        await ProjectItemPageHelper.verifyTitleAndDuration(uniqueId, CommonPageConstants.hours.durationHours3);

        stepLogger.stepId(2);
        stepLogger.step('Select All three tasks using Shift or Ctrl buttons');
        await ProjectItemPageHelper.selectCreatedTask();
        await PageHelper.click(CommonPage.linkDownbutton);

        stepLogger.verification('Add Link pop up is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.addButton)).toBe(true,
            ValidationsHelper.getButtonDisplayedValidation(CommonPageConstants.buttonName.addButton));

        stepLogger.stepId(3);
        stepLogger.step('Leave the default value "0" in "Lag Time (Days)" text box\n' +
            'Click on "Add Link" button');
        await PageHelper.click(CommonPage.addButton);

        stepLogger.verification('Add Link pop up is closed');
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.addButton);
        await expect(await CommonPage.addButton.isPresent()).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(CommonPageConstants.buttonName.addButton));

        await browser.sleep(PageHelper.timeout.xs);

        stepLogger.verification('Selected tasks are linked');
        await ProjectItemPageHelper.getselectTask(2, ProjectItemPageConstants.newTaskFields.start).click();
        await expect(await ProjectItemPageHelper.newTasksFields.predecessors.getText()).toBe(CommonPageConstants.predecessorsData.
                predecessors1, ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.predecessors,
                CommonPageConstants.predecessorsData.predecessors1));
        await ProjectItemPageHelper.getselectTask(3, ProjectItemPageConstants.newTaskFields.start).click();
        await expect(await ProjectItemPageHelper.newTasksFields.predecessors.getText()).toBe(CommonPageConstants.predecessorsData.
                predecessors2, ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.predecessors,
                CommonPageConstants.predecessorsData.predecessors2));

        stepLogger.stepId(4);
        stepLogger.step('Click on Project tab');
        stepLogger.step('Ensure Respect Links option is enabled (If NOT enable click on it to Enable)');
        await PageHelper.click(CommonPage.projectTab);
        // Ensure Respect Links option is enabled (If NOT enable click on it to Enable and Respect Links' option is enabled
        // is not possible by automation.

        stepLogger.stepId(5);
        stepLogger.step('Decrease the Duration for task1 from, say, 5 to 3 days');
        await ProjectItemPageHelper.getselectTask(1, ProjectItemPageConstants.newTaskFields.start).click();
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.duration);
        await PageHelper.actionSendKeys(CommonPageConstants.hours.durationHours4);
        stepLogger.step('Click anywhere in the page/tab out of the Duration column');
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.duration);

        console.log(ProjectItemPageHelper.getselectTask(1, ProjectItemPageConstants.newTaskFields.start));

        // No changes done in Durations
        stepLogger.verification('Add Link pop up is displayed');
        await expect(await CommonPage.addButton.isPresent()).toBe(false,
            ValidationsHelper.getButtonDisplayedValidation(CommonPageConstants.buttonName.addButton));

    });
});
