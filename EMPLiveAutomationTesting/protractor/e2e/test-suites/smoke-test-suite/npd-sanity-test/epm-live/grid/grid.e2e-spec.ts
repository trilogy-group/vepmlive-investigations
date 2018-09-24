import {browser} from 'protractor';
import {PageHelper} from '../../../../../components/html/page-helper';
import {ProjectItemPage} from '../../../../../page-objects/pages/items-page/project-item/project-item.po';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../../../helpers/suite-names';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ProjectItemPageHelper} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {MyTimeOffPageConstants} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.constants';
import {WaitHelper} from '../../../../../components/html/wait-helper';

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

    it('Add Duration. - [970519]', async () => {
        StepLogger.caseId = 970519;
        const uniqueId = PageHelper.getUniqueId();
        const input = MyTimeOffPageConstants.inputValues;
        const finishDate = input.finishDate;

        StepLogger.preCondition('Execute steps# 1 to 7 in test case C855881 and add a task to resource and publish the project');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        await PageHelper.click(CommonPage.projectCheckbox);
        await PageHelper.click(CommonPage.ribbonTitles.items);
        await PageHelper.click(CommonPage.editPlan);
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        await ProjectItemPageHelper.createTask(uniqueId, finishDate);

        StepLogger.stepId(1);
        StepLogger.step('Select a task from grid and click in the duration field');
        await PageHelper.click(ProjectItemPage.selectTaskName);

        StepLogger.step('Change the duration value [Ex: New Task 1 duration changed from 5 to 10]');
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.duration);
        await PageHelper.actionSendKeys(CommonPageConstants.hours.durationHours2);

        StepLogger.verification('Duration for selected task is updated');
        await PageHelper.click(ProjectItemPage.selectTaskName);
        await expect(await ProjectItemPageHelper.newTasksFields.duration.getText()).toBe(CommonPageConstants.hours.durationHours2,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.duration,
                CommonPageConstants.hours.durationHours2));

        StepLogger.verification('Finish date and Work (Effort Hours) are updated as per the Duration value selected');
        await expect(await ProjectItemPageHelper.newTasksFields.work.getText()).not.toBe(CommonPageConstants.hours.effortHours,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.work,
                CommonPageConstants.hours.effortHours));

        await expect(await ProjectItemPageHelper.newTasksFields.date.getText()).not.toBe(finishDate,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.finishDate, finishDate));

        StepLogger.stepId(2);
        StepLogger.step('Click on Assigned To column');
        await PageHelper.click(ProjectItemPage.assignToDropDown);

        StepLogger.step('Select another resource by checking respective check box');
        await PageHelper.click(ProjectItemPageHelper.selectAssign(2));

        StepLogger.step('Click OK button');
        await PageHelper.click(ProjectItemPageHelper.button.ok);

        StepLogger.verification('Work column updated according to the number of assigned resources. (Billing hours ' +
            'of the resource multiplied with the duration and the result displayed in Work column) [In this case 2 X 8 X 10 = 160]');
        await expect(await ProjectItemPageHelper.newTasksFields.work.getText()).toBe(CommonPageConstants.hours.updatedEffortHours,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.work,
                CommonPageConstants.hours.updatedEffortHours));

        StepLogger.stepId(3);
        StepLogger.step('Click on Save button from button menu');
        await ElementHelper.clickUsingJs(ProjectItemPage.save);

        StepLogger.verification('Changes done in Project Planner page are saved');
        // After save It need static wait(5 sec) and no element found which get change after save.
        await browser.sleep(PageHelper.timeout.s);
        await expect(await ProjectItemPageHelper.newTasksFields.work.getText()).toBe(CommonPageConstants.hours.updatedEffortHours,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.work,
                CommonPageConstants.hours.updatedEffortHours));

        await PageHelper.click(ProjectItemPage.selectTaskName);
        await expect(await ProjectItemPageHelper.newTasksFields.duration.getText()).toBe(CommonPageConstants.hours.durationHours2,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.duration,
                CommonPageConstants.hours.durationHours2));

        StepLogger.stepId(4);
        StepLogger.step('Click on "Close" button from ribbon panel');
        await ElementHelper.clickUsingJs(ProjectItemPage.close);

        StepLogger.verification('Project Planner page is closed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.pageHeaders.projects.projectsCenter);
        await expect(await CommonPage.pageHeaders.projects.projectPlanner.isPresent()).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        StepLogger.verification('Project Center page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        StepLogger.stepId(5);
        StepLogger.step('Select the project in which task details updated in step# 2 [Ex: Smoke Test Project 2]' +
            'Click on the ITEMS tab above the grid From the ITEMS ribbon menu, click on Edit Plan' +
            'Click on Project Planner in the list of planners displayed');
        await PageHelper.click(CommonPage.projectCheckbox);
        await PageHelper.click(CommonPage.ribbonTitles.items);
        // 5 second wait required Wait helper is not working.
        await CommonPageHelper.clickOnEditPlan();
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);

        StepLogger.verification('"Project Planner" window is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        StepLogger.stepId(6);
        StepLogger.step('Check the task details displayed');
        // After select project Planner wait required, not element found which can use   with waitHelper.
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.selectTaskName))
            .toBe(true, ValidationsHelper.getDisplayedValidation(CommonPageConstants.pageHeaders.projects.tasks));

        StepLogger.verification('Changes done to task in step# 3 are saved and displayed in Project Planner page');
        await PageHelper.click(ProjectItemPage.selectTaskName);
        await expect(await ProjectItemPageHelper.newTasksFields.work.getText()).toBe(CommonPageConstants.hours.updatedEffortHours,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.work,
                CommonPageConstants.hours.updatedEffortHours));

        await PageHelper.click(ProjectItemPage.selectTaskName);
        await expect(await ProjectItemPageHelper.newTasksFields.duration.getText()).toBe(CommonPageConstants.hours.durationHours2,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.duration,
                CommonPageConstants.hours.durationHours2));

    });
});
