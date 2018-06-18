import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {browser} from 'protractor';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {ProjectItemPage} from '../../../../../page-objects/pages/items-page/project-item/project-item.po';
import {PageHelper} from '../../../../../components/html/page-helper';
import {ProjectItemPageHelper} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../../../helpers/suite-names';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {MyTimeOffPage} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off.po';
import {MyTimeOffPageConstants} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.constants';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Save the changes by Save button - [965680]', async () => {
        const stepLogger = new StepLogger(965680);
        const uniqueId = PageHelper.getUniqueId();
        const input = MyTimeOffPageConstants.inputValues;
        const finishDate = input.finishDate;

        stepLogger.stepId(1);
        stepLogger.step('Select "Navigation" icon  from left side menu');
        stepLogger.step('Select Projects -> Projects from the options displayed');

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.verification('Project Center page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.pageHeaders.projects.projectsCenter);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        stepLogger.stepId(2);
        stepLogger.step('Select any project from project center');
        await PageHelper.click(CommonPage.project);

        stepLogger.step('Click ITEMS tab select Edit Plan');
        await PageHelper.click(CommonPage.editPlan);

        stepLogger.verification('Select Planner pop-up displays with different planner options to select');
        await expect(await CommonPage.dialogTitle.isDisplayed()).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.selectPlanner));

        stepLogger.stepId(3);
        stepLogger.step('click on Project Planner');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);

        stepLogger.verification('The Project Planner page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.pageHeaders.projects.projectPlanner);
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
        stepLogger.step('Click on "Task" button');
        await PageHelper.click(CommonPage.ribbonItems.addTask);

        stepLogger.verification('A new task is created and required details entered [Ex: Task One]');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.selectTaskName))
            .toBe(true, ValidationsHelper.getDisplayedValidation(CommonPageConstants.pageHeaders.projects.tasks));

        stepLogger.step('Enter details for Task (Name, Finish Date, Hours)');
        await PageHelper.actionSendKeys(uniqueId);
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.date);
        await ElementHelper.actionDoubleClick(ProjectItemPageHelper.newTasksFields.date);
        await TextboxHelper.sendKeys(MyTimeOffPage.dateEditBox, finishDate);
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.work);
        await PageHelper.actionSendKeys(CommonPageConstants.costData.firstData);
        await PageHelper.click(CommonPage.pageTitle);

        stepLogger.stepId(5);
        stepLogger.step('Click on Save button from ribbon panel');
        await ElementHelper.clickUsingJs(ProjectItemPage.save);

        stepLogger.verification('Changes done in Project Planner page are saved');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ProjectItemPageHelper.newTasksFields.title);
        await expect(await ProjectItemPageHelper.newTasksFields.title.getText()).toBe(uniqueId,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.title, uniqueId));
        await expect(await ProjectItemPageHelper.newTasksFields.work.getText()).toBe(CommonPageConstants.costData.firstData,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.work,
                CommonPageConstants.pageHeaders.projects.workHours));

        stepLogger.stepId(6);
        stepLogger.step('Click on "Close" button from ribbon panel');
        // After save It need static wait(5 sec) and no element found which get change after save.
        await browser.sleep(PageHelper.timeout.s);
        await ElementHelper.clickUsingJs(ProjectItemPage.close);

        stepLogger.verification('Project Planner page is closed');
        await WaitHelper.getInstance().waitForElementToBeClickable(CommonPage.editPlan);
        await expect(await CommonPage.pageHeaders.projects.projectPlanner.isPresent()).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        stepLogger.verification('Project Center page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.pageHeaders.projects.projectsCenter);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        stepLogger.stepId(7);
        stepLogger.step('Select the project in which task is added [Ex: SmokeTestProject1]\n' +
            'Click on the ITEMS tab above the grid\n' +
            'From the ITEMS ribbon menu, click on Edit Plan\n' +
            'Click on Project Planner in the list of planners displayed');
        await browser.sleep(PageHelper.timeout.s);
        await ElementHelper.clickUsingJs(CommonPage.editPlan);

        stepLogger.step('click on Project Planner');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);

        stepLogger.verification('"Project Planner" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.pageHeaders.projects.projectPlanner);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        stepLogger.verification('Changes saved in step# 5 (Task added and details entered for task)' +
            ' are displayed in the Project Planner');
        // After select project Planner wait required, not element found which can use with waitHelper.
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.plannerbox);
        await PageHelper.click(ProjectItemPage.selectTaskName);
        await expect(await ProjectItemPageHelper.newTasksFields.title.getText()).toBe(uniqueId,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.title,
                CommonPageConstants.pageHeaders.projects.tasks));
        await expect(await ProjectItemPageHelper.newTasksFields.work.getText()).toBe(CommonPageConstants.costData.firstData,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.work,
                CommonPageConstants.pageHeaders.projects.workHours));
    });
});
