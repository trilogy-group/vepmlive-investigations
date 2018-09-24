import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../../page-objects/pages/common/common.po';
import {PageHelper} from '../../../../../../components/html/page-helper';
import {SuiteNames} from '../../../../../helpers/suite-names';
import {LoginPage} from '../../../../../../page-objects/pages/login/login.po';
import {CommonPageHelper} from '../../../../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../../../../page-objects/pages/homepage/home.po';
import {CommonPageConstants} from '../../../../../../page-objects/pages/common/common-page.constants';
import {TaskPageHelper} from '../../../../../../page-objects/pages/my-workplace/task/task-page.helper';
import {TaskPageConstants} from '../../../../../../page-objects/pages/my-workplace/task/task-page.constants';
import {ProjectItemPage} from '../../../../../../page-objects/pages/items-page/project-item/project-item.po';
import {ElementHelper} from '../../../../../../components/html/element-helper';
import {browser} from 'protractor';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
import {ProjectItemPageConstants} from '../../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {ProjectItemPageHelper} from '../../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {ValidationsHelper} from '../../../../../../components/misc-utils/validation-helper';
import {TextboxHelper} from '../../../../../../components/html/textbox-helper';

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

    it('Decrease Task1\'s Duration (Respective Links=ON, Start ASAP =ON) - [1035340]', async () => {
        StepLogger.caseId = 1035340;
        StepLogger.preCondition('Execute steps# 1 to 4 in test case C743761 and add 2 tasks in the project ' +
            'created in pre requisite# 3 [Ex: Smoke Test Project 2:: New Task 1, New Task 2]');
        const uniqueId = PageHelper.getUniqueId();
        const hours = CommonPageConstants.hours.durationHours4;
        const operation = TaskPageConstants.decrease;
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await TaskPageHelper.navigateToPlannerAndDeleteTask();
        await TaskPageHelper.increaseAndDecreaseTaskDuration(uniqueId, hours, operation);
    });

    it('Increase Task1\'s Duration (Respective Links=ON, \'Start ASAP\'=ON - [1035334])', async () => {
        StepLogger.caseId = 1035334;
        StepLogger.preCondition('Execute steps# 1 to 4 in test case C743761 and add 2 tasks in the project ' +
            'created in pre requisite# 3 [Ex: Smoke Test Project 2:: New Task 1, New Task 2]');
        const uniqueId = PageHelper.getUniqueId();
        const operation = TaskPageConstants.increase;
        const hours = CommonPageConstants.hours.durationHours3;
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await TaskPageHelper.navigateToPlannerAndDeleteTask();
        await TaskPageHelper.increaseAndDecreaseTaskDuration(uniqueId, hours, operation);
    });

    it('Check the functionality of Cancel button for "Add Link" pop-up - [1035432])', async () => {
        StepLogger.caseId = 1035432;
        StepLogger.preCondition('Execute steps# 1 to 4 in test case C743761 and add 2 tasks in the project created in' +
            ' pre requisite# 2 [Ex: Smoke Test Project 2:: New Task 1, New Task 2]');
        const uniqueId = PageHelper.getUniqueId();
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await TaskPageHelper.navigateToPlannerAndDeleteTask();
        await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours1, uniqueId);
        await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours2, uniqueId);

        StepLogger.stepId(1);
        StepLogger.step('Click on + Task button');
        StepLogger.step('Enter details for Task (Name, Hours)');
        StepLogger.step('Click on Save button from ribbon panel in the Project Planner page');
        await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours3, uniqueId);
        await ElementHelper.clickUsingJs(ProjectItemPage.save);

        StepLogger.verification('Third Task is created and required details entered [Ex: New Task 3]');
        StepLogger.verification('Changes done in "Project Planner" page are saved');
        // After save It need static wait(5 sec) and no element found which get change after save.
        await browser.sleep(PageHelper.timeout.s);
        await WaitHelper.waitForElementToBeDisplayed(ProjectItemPageHelper.newTasksFields.title);
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.one, ProjectItemPageConstants.newTaskFields.start).click();
        await ProjectItemPageHelper.verifyTitleAndDuration(uniqueId, CommonPageConstants.hours.durationHours1);
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.two, ProjectItemPageConstants.newTaskFields.start).click();
        await ProjectItemPageHelper.verifyTitleAndDuration(uniqueId, CommonPageConstants.hours.durationHours2);
        await ProjectItemPageHelper.getselectTask(3, ProjectItemPageConstants.newTaskFields.start).click();
        await ProjectItemPageHelper.verifyTitleAndDuration(uniqueId, CommonPageConstants.hours.durationHours3);

        StepLogger.stepId(2);
        StepLogger.step('Select Task 2 and 3 using Shift or Ctrl buttons');
        StepLogger.step('Click on Link Down button from the button menu');
        await ProjectItemPageHelper.selectCreatedTaskTwoAndThree();
        await PageHelper.click(CommonPage.linkDownbutton);

        StepLogger.verification('Add Link pop up is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.addButton)).toBe(true,
            ValidationsHelper.getButtonDisplayedValidation(CommonPageConstants.buttonName.addButton));

        StepLogger.stepId(3);
        StepLogger.step('Select a value in Link Type: [Ex: FS (Finish-to-start)]');
        await PageHelper.click(ProjectItemPage.linkTypeDropDownId);
        await ElementHelper.clickUsingJs(ProjectItemPage.linkDropDownValue);

        StepLogger.step('Enter a value in Lag Time (Days) text box [Ex: 5]');
        await TextboxHelper.sendKeys(ProjectItemPage.lagTimeTextBox, CommonPageConstants.hours.durationHours4);

        StepLogger.verification('Required values Entered/Selected in Add Link pop up');
        await expect(await ElementHelper.getText(ProjectItemPage.linkDropDownValue)).toBe
        (ProjectItemPageConstants.linkDropDownValues.finishToStart, ValidationsHelper.getFieldShouldHaveValueValidation
        (ProjectItemPageConstants.addLinkPopup.linkType, CommonPageConstants.buttonName.addButton));

        StepLogger.stepId(4);
        StepLogger.step('Click on Cancel button in Add Link pop up');
        await PageHelper.click(CommonPage.addLinkCancelButton);

        StepLogger.verification('Add Link pop up is closed');
        await expect(await CommonPage.addButton.isPresent()).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(CommonPageConstants.buttonName.addButton));

        StepLogger.verification('Selected Tasks are NOT linked [NO change in column values Work and Predecessors]');
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.two, ProjectItemPageConstants.newTaskFields.start).click();
        await expect(await ProjectItemPageHelper.newTasksFields.predecessors.getText()).toBe(CommonPageConstants.predecessorsData.predecessorsNull, ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.predecessors,
            CommonPageConstants.predecessorsData.predecessorsNull));
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.three,
            ProjectItemPageConstants.newTaskFields.start).click();
        await expect(await ProjectItemPageHelper.newTasksFields.predecessors.getText()).toBe(CommonPageConstants.predecessorsData.predecessorsNull, ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.predecessors,
            CommonPageConstants.predecessorsData.predecessorsNull));
    });
});
