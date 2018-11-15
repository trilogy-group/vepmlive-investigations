import { browser } from 'protractor';

import { CommonPageHelper } from '../../../../../page-objects/pages/common/common-page.helper';
import { StepLogger } from '../../../../../../core/logger/step-logger';
import { CommonPage } from '../../../../../page-objects/pages/common/common.po';
import { ProjectItemPage } from '../../../../../page-objects/pages/items-page/project-item/project-item.po';
import { PageHelper } from '../../../../../components/html/page-helper';
import { ProjectItemPageHelper } from '../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import { WaitHelper } from '../../../../../components/html/wait-helper';
import { CommonPageConstants } from '../../../../../page-objects/pages/common/common-page.constants';
import { HomePage } from '../../../../../page-objects/pages/homepage/home.po';
import { SuiteNames } from '../../../../helpers/suite-names';
import { LoginPage } from '../../../../../page-objects/pages/login/login.po';
import { ElementHelper } from '../../../../../components/html/element-helper';

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

    it('Set and Clear Baseline - [970398]', async () => {
        StepLogger.caseId = 970398;
        StepLogger.preCondition('Select "Navigation" icon  from left side menu');
        StepLogger.preCondition('Select Projects -> Projects from the options displayed');
        const uniqueId = PageHelper.getUniqueId();
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        StepLogger.preCondition('Select any project from project center');
        await PageHelper.click(CommonPage.project);
        StepLogger.preCondition('Click ITEMS tab select Edit Plan');
        await PageHelper.click(CommonPage.editPlan);
        StepLogger.preCondition('click on Project Planner');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);
        await CommonPageHelper.deleteTask();
        await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours1, uniqueId);
        await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours2, uniqueId);
        await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours3, uniqueId);

        StepLogger.stepId(1);
        StepLogger.step('Click on Views tab');
        await PageHelper.click(ProjectItemPage.viewsButton);

        StepLogger.step('Click on Show Gantt button from the ribbon');
        await PageHelper.click(ProjectItemPage.showGanttButton);

        StepLogger.verification('Gantt Chart is displayed in Project Planner window');
        await ProjectItemPageHelper.verifyGanttChart();

        StepLogger.stepId(2);
        StepLogger.step('Click on Projects tab from ribbon panel');
        await ElementHelper.actionHoverOver(CommonPage.projectTab);
        await PageHelper.click(CommonPage.projectTab);

        StepLogger.step('Click on Set Baseline button from the ribbon');
        await WaitHelper.waitForElementToBePresent(CommonPage.setBaselineTab);
        await ElementHelper.actionHoverOver(CommonPage.setBaselineTab);
        await PageHelper.click(CommonPage.setBaselineTab);
        await PageHelper.acceptAlert();

        StepLogger.stepId(3);
        StepLogger.step('Change Duration of any task [Ex: Task One Duration changed from 5 to 10]' +
            'View the base line at the Gantt Chart');
        await browser.sleep(PageHelper.timeout.xs);
        await ElementHelper.actionHoverOver(ProjectItemPageHelper.newTasksFields.duration);
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.duration);
        await PageHelper.actionSendKeys(CommonPageConstants.hours.durationHours1);

        StepLogger.stepId(4);
        StepLogger.step('Click on Clear Baseline button from the ribbon');
        await PageHelper.click(CommonPage.clearBaselineTab);

        StepLogger.verification('A message displayed as Would you like to overwrite the baseline saved ' +
            'on: (Day Date time on which Baseline was set)');
        await ProjectItemPageHelper.verifyAlertMessage();

        StepLogger.stepId(5);
        StepLogger.step('Click in "OK" button in the message');
        await PageHelper.acceptAlert();
    });
});
