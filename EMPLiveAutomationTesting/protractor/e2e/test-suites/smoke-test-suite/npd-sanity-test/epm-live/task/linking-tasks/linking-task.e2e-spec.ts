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
import {TaskPageHelper} from '../../../../../../page-objects/pages/my-workplace/task/task-page.helper';
import {TaskPageConstants} from '../../../../../../page-objects/pages/my-workplace/task/task-page.constants';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Decrease Task1\'s Duration (Respective Links=ON, Start ASAP =ON) - [1035340]', async () => {
        const stepLogger = new StepLogger(1035340);
        stepLogger.precondition('Execute steps# 1 to 4 in test case C743761 and add 2 tasks in the project ' +
            'created in pre requisite# 3 [Ex: Smoke Test Project 2:: New Task 1, New Task 2]');
        const uniqueId = PageHelper.getUniqueId();
        const hours = CommonPageConstants.hours.durationHours4;
        const testCase = TaskPageConstants.decrease;
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

        await TaskPageHelper.increaseAndDecreaseTaskDuration(stepLogger, uniqueId, hours, testCase);
    });

    it('Increase Task1\'s Duration (Respective Links=ON, \'Start ASAP\'=ON - [1035334])', async () => {
        const stepLogger = new StepLogger(1035334);
        stepLogger.precondition('Execute steps# 1 to 4 in test case C743761 and add 2 tasks in the project ' +
            'created in pre requisite# 3 [Ex: Smoke Test Project 2:: New Task 1, New Task 2]');
        const uniqueId = PageHelper.getUniqueId();
        const testCase = TaskPageConstants.increase;
        const hours = CommonPageConstants.hours.durationHours3;
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

        await TaskPageHelper.increaseAndDecreaseTaskDuration(stepLogger, uniqueId, hours, testCase);
    });
});
