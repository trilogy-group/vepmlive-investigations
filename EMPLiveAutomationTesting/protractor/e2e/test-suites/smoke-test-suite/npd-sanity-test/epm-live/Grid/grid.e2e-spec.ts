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
import {browser} from 'protractor';
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

    it('Add Duration. - [970519]', async () => {
        const stepLogger = new StepLogger(970519);
        const uniqueId = PageHelper.getUniqueId();
        const input = MyTimeOffPageConstants.inputValues;
        const finishDate = input.finishDate;

        stepLogger.precondition('Execute steps# 1 to 7 in test case C855881 and add a task to resource and publish the project');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        await PageHelper.click(CommonPage.projectCheckbox);
        await PageHelper.click(CommonPage.ribbonTitles.items);
        await PageHelper.click(CommonPage.editPlan);
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        await ProjectItemPageHelper.createTask(uniqueId, stepLogger, finishDate);

        stepLogger.stepId(1);
        stepLogger.step('Select a task from grid and click in the duration field');
        await PageHelper.click(ProjectItemPage.selectTaskName);

        stepLogger.step('Change the duration value [Ex: New Task 1 duration changed from 5 to 10]');
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.duration);
        await PageHelper.actionSendKeys(CommonPageConstants.hours.durationHours2);

        stepLogger.verification('Duration for selected task is updated');
        await PageHelper.click(ProjectItemPage.selectTaskName);
        await expect(await ProjectItemPageHelper.newTasksFields.duration.getText()).toBe(CommonPageConstants.hours.durationHours2,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.duration,
                CommonPageConstants.hours.durationHours2));

        stepLogger.verification('Finish date and Work (Effort Hours) are updated as per the Duration value selected');
        await expect(await ProjectItemPageHelper.newTasksFields.work.getText()).not.toBe(CommonPageConstants.hours.effortHours,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.work,
                CommonPageConstants.hours.effortHours));

        await expect(await ProjectItemPageHelper.newTasksFields.date.getText()).not.toBe(finishDate,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.finishDate, finishDate));

        stepLogger.stepId(2);
        stepLogger.step('Click on Assigned To column');
        await PageHelper.click(ProjectItemPage.assignToDropDown);

        stepLogger.step('Select another resource by checking respective check box');
        await PageHelper.click(ProjectItemPage.selectAssign(2));

        stepLogger.step('Click OK button');
        await PageHelper.click(ProjectItemPageHelper.button.ok);

        stepLogger.verification('Work column updated according to the number of assigned resources. (Billing hours ' +
            'of the resource multiplied with the duration and the result displayed in Work column) [In this case 2 X 8 X 10 = 160]');
        await expect(await ProjectItemPageHelper.newTasksFields.work.getText()).toBe(CommonPageConstants.hours.updatedEffortHours,
            ValidationsHelper.getFieldShouldHaveValueValidation( ProjectItemPageConstants.newTaskFields.work,
                CommonPageConstants.hours.updatedEffortHours));

        stepLogger.stepId(3);
        stepLogger.step('Click on Save button from button menu');
        await ElementHelper.clickUsingJs(ProjectItemPage.save);

        stepLogger.verification('Changes done in Project Planner page are saved');
        // After save It need static wait(5 sec) and no element found which get change after save.
        await browser.sleep(PageHelper.timeout.s);
        await expect(await ProjectItemPageHelper.newTasksFields.work.getText()).toBe(CommonPageConstants.hours.updatedEffortHours,
            ValidationsHelper.getFieldShouldHaveValueValidation( ProjectItemPageConstants.newTaskFields.work,
                CommonPageConstants.hours.updatedEffortHours));

        await PageHelper.click(ProjectItemPage.selectTaskName);
        await expect(await ProjectItemPageHelper.newTasksFields.duration.getText()).toBe(CommonPageConstants.hours.durationHours2,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.duration,
                CommonPageConstants.hours.durationHours2));

        stepLogger.stepId(4);
        stepLogger.step('Click on "Close" button from ribbon panel');
        await ElementHelper.clickUsingJs(ProjectItemPage.close);

        stepLogger.verification('Project Planner page is closed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.pageHeaders.projects.projectsCenter);
        await expect(await CommonPage.pageHeaders.projects.projectPlanner.isPresent()).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        stepLogger.verification('Project Center page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        stepLogger.stepId(5);
        stepLogger.step('Select the project in which task details updated in step# 2 [Ex: Smoke Test Project 2]' +
        'Click on the ITEMS tab above the grid From the ITEMS ribbon menu, click on Edit Plan' +
        'Click on Project Planner in the list of planners displayed');
        await ElementHelper.browserRefresh();
        await browser.sleep(PageHelper.timeout.m);
        await PageHelper.click(CommonPage.projectCheckbox);
        await PageHelper.click(CommonPage.ribbonTitles.items);
        // 5 second wait required Wait helper is not working.
        await PageHelper.click(CommonPage.editPlan);
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);

        stepLogger.verification('"Project Planner" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.pageHeaders.projects.projectPlanner);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        stepLogger.stepId(6 );
        stepLogger.step('Check the task details displayed');
        // After select project Planner wait required, not element found which can use with waitHelper.
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.plannerbox);
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.selectTaskName))
            .toBe(true, ValidationsHelper.getDisplayedValidation(CommonPageConstants.pageHeaders.projects.tasks));

        stepLogger.verification('Changes done to task in step# 3 are saved and displayed in Project Planner page');
        await PageHelper.click(ProjectItemPage.selectTaskName);
        await expect(await ProjectItemPageHelper.newTasksFields.work.getText()).toBe(CommonPageConstants.hours.updatedEffortHours,
            ValidationsHelper.getFieldShouldHaveValueValidation( ProjectItemPageConstants.newTaskFields.work,
                CommonPageConstants.hours.updatedEffortHours));

        await PageHelper.click(ProjectItemPage.selectTaskName);
        await expect(await ProjectItemPageHelper.newTasksFields.duration.getText()).toBe(CommonPageConstants.hours.durationHours2,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.duration,
                CommonPageConstants.hours.durationHours2));

        // Deleting created task
        await PageHelper.click(ProjectItemPage.deleteTask);
        await browser.switchTo().alert().accept();
        await ElementHelper.clickUsingJs(ProjectItemPage.save);
        // After save It need static wait(5 sec) and no element found which get change after save.
        await browser.sleep(PageHelper.timeout.s);

    });
});
