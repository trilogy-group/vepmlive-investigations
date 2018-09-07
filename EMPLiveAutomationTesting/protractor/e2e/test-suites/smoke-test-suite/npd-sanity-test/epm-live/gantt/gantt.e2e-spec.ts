import {browser} from 'protractor';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {ProjectItemPage} from '../../../../../page-objects/pages/items-page/project-item/project-item.po';
import {PageHelper} from '../../../../../components/html/page-helper';
import {ProjectItemPageHelper} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../../../helpers/suite-names';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    let stepLogger: StepLogger;
    beforeEach(async () => {
        stepLogger = new StepLogger();
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Set and Clear Baseline - [970398]', async () => {
        stepLogger.caseId = 970398;
        stepLogger.preCondition('Select "Navigation" icon  from left side menu');
        stepLogger.preCondition('Select Projects -> Projects from the options displayed');
        const uniqueId = PageHelper.getUniqueId();
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);
        stepLogger.preCondition('Select any project from project center');
        await PageHelper.click(CommonPage.project);
        stepLogger.preCondition('Click ITEMS tab select Edit Plan');
        await PageHelper.click(CommonPage.editPlan);
        stepLogger.preCondition('click on Project Planner');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);
        await CommonPageHelper.deleteTask();
        await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours1, uniqueId);
        await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours2, uniqueId);
        await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours3, uniqueId);

        stepLogger.stepId(1);
        stepLogger.step('Click on Views tab');
        await PageHelper.click(ProjectItemPage.viewsButton);

        stepLogger.step('Click on Show Gantt button from the ribbon');
        await PageHelper.click(ProjectItemPage.showGanttButton);

        stepLogger.verification('Gantt Chart is displayed in Project Planner window');
        await ProjectItemPageHelper.verifyGanttChart();

        stepLogger.stepId(2);
        stepLogger.step('Click on Projects tab from ribbon panel');
        await PageHelper.click(CommonPage.projectTab);

        stepLogger.step('Click on Set Baseline button from the ribbon');
        await PageHelper.click(CommonPage.setBaselineTab);
        // accept alert required to set new base line
        await browser.switchTo().alert().accept();

        stepLogger.stepId(3);
        stepLogger.step('Change Duration of any task [Ex: Task One Duration changed from 5 to 10]' +
            'View the base line at the Gantt Chart');
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.duration);
        await PageHelper.actionSendKeys(CommonPageConstants.hours.durationHours1);

        stepLogger.stepId(4);
        stepLogger.step('Click on Clear Baseline button from the ribbon');
        await PageHelper.click(CommonPage.clearBaselineTab);

        stepLogger.verification('A message displayed as Would you like to overwrite the baseline saved ' +
            'on: (Day Date time on which Baseline was set)');
        await ProjectItemPageHelper.verifyAlertMessage();

        stepLogger.stepId(5);
        stepLogger.step('Click in "OK" button in the message');
        await browser.switchTo().alert().accept();
        // unable to verify baseline, its a chart, nothing is changing in dom.
    });
});
