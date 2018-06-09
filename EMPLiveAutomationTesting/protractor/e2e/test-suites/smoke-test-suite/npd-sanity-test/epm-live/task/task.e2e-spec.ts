import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {browser} from 'protractor';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import { ValidationsHelper } from '../../../../../components/misc-utils/validation-helper';
import { ProjectItemPage } from '../../../../../page-objects/pages/items-page/project-item/project-item.po';
import {PageHelper} from '../../../../../components/html/page-helper';
import { ProjectItemPageHelper } from '../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import { TextboxHelper } from '../../../../../components/html/textbox-helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../../../helpers/suite-names';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {MyTimeOffPage} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off.po';
import {MyTimeOffPageConstants} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.constants';
import {ElementHelper} from '../../../../../components/html/element-helper';

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

        stepLogger.stepId(3);
        stepLogger.step('Select any project from project center');
        await PageHelper.click(CommonPage.project);

        stepLogger.step('Click ITEMS tab select Edit Plan');
        await PageHelper.click(CommonPage.editPlan);

        stepLogger.step('click on Project Planner');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);

        stepLogger.verification('"Project Planner" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.pageHeaders.projects.projectPlanner);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        stepLogger.stepId(4);
        stepLogger.step('Click on "Task" button');
        await browser.sleep(PageHelper.timeout.m);
        await PageHelper.click(CommonPage.ribbonItems.addTask);

        stepLogger.step('Enter details for Task (Name, Finish Date, Hours)');
        await PageHelper.actionSendKeys( uniqueId);
        await PageHelper.click(MyTimeOffPage.dateFeild);
        await ElementHelper.actionDoubleClick(MyTimeOffPage.dateFeild);
        await TextboxHelper.sendKeys(MyTimeOffPage.dateEditBox, finishDate);
        await PageHelper.click(ProjectItemPage.workField);
        await PageHelper.actionSendKeys(CommonPageConstants.costData.firstData);
        await PageHelper.click(ProjectItemPage.pagetitle);

        stepLogger.stepId(5);
        stepLogger.step('Click on Save button from ribbon panel');
        await ElementHelper.clickUsingJs(ElementHelper.getElementByText(CommonPageConstants.formLabels.save));

        stepLogger.verification('Changes done in Project Planner page are saved');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ProjectItemPage.TaskName);
        await expect(await ProjectItemPage.TaskName.getText()).toBe(uniqueId,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.tasks));
        await expect(await ProjectItemPage.workField.getText()).toBe(CommonPageConstants.costData.firstData,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.workHours));

        stepLogger.stepId(6);
        stepLogger.step('Click on "Close" button from ribbon panel');
        await browser.sleep(PageHelper.timeout.s);
        await ElementHelper.clickUsingJs(ProjectItemPage.close);

        stepLogger.verification('Project Planner page is closed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(false,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        stepLogger.verification('Project Center page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.pageHeaders.projects.projectsCenter);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        stepLogger.stepId(7);
        stepLogger.step('Select the project in which task is added [Ex: SmokeTestProject1]\n' +
            'Click on the ITEMS tab above the grid\n' +
            'From the ITEMS ribbon menu, click on Edit Plan\n' +
            'Click on Project Planner in the list of planners displayed');
        await PageHelper.click(CommonPage.editPlan);

        stepLogger.step('click on Project Planner');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);

        stepLogger.verification('"Project Planner" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.pageHeaders.projects.projectPlanner);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        stepLogger.verification('Changes saved in step# 5 (Task added and details entered for task)' +
            ' are displayed in the Project Planner');
        await browser.sleep(PageHelper.timeout.m);
        await PageHelper.click(ProjectItemPage.selectTaskName);
        await expect(await ProjectItemPage.TaskName.getText()).toBe(uniqueId,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.tasks));
        await expect(await ProjectItemPage.workField.getText()).toBe(CommonPageConstants.costData.firstData,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.workHours));

        // Delete created task
        await PageHelper.click(ProjectItemPage.TaskName);
        await PageHelper.click(ProjectItemPage.deleteTask);
        await browser.switchTo().alert().accept();
        await ElementHelper.clickUsingJs(ElementHelper.getElementByText(CommonPageConstants.formLabels.save));
    });
});
