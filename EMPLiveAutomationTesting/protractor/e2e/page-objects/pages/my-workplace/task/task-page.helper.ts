import {browser} from 'protractor';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {ProjectItemPage} from '../../items-page/project-item/project-item.po';
import {CommonPage} from '../../common/common.po';
import {ProjectItemPageHelper} from '../../items-page/project-item/project-item-page.helper';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../common/common-page.helper';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {ElementHelper} from '../../../../components/html/element-helper';
import {CommonPageConstants} from '../../common/common-page.constants';
import {PageHelper} from '../../../../components/html/page-helper';
import {ProjectItemPageConstants} from '../../items-page/project-item/project-item-page.constants';

export class TaskPageHelper {

    static async increaseAndDecreaseTaskDuration(stepLogger: StepLogger, uniqueId: string, updatedHours: string, operation: string) {

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
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.one, ProjectItemPageConstants.newTaskFields.start).click();
        await ProjectItemPageHelper.verifyTitleAndDuration(uniqueId, CommonPageConstants.hours.durationHours1);
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.two, ProjectItemPageConstants.newTaskFields.start).click();
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

        stepLogger.verification('Selected tasks are linked');
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.two, ProjectItemPageConstants.newTaskFields.start).click();
        await expect(await ProjectItemPageHelper.newTasksFields.predecessors.getText()).toBe(CommonPageConstants.predecessorsData.
            predecessors1, ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.predecessors,
            CommonPageConstants.predecessorsData.predecessors1));
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.three,
            ProjectItemPageConstants.newTaskFields.start).click();
        await expect(await ProjectItemPageHelper.newTasksFields.predecessors.getText()).toBe(CommonPageConstants.predecessorsData.
            predecessors2, ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.predecessors,
            CommonPageConstants.predecessorsData.predecessors2));

        stepLogger.stepId(4);
        stepLogger.step('Click on Project tab');
        stepLogger.step('Ensure Respect Links option is enabled (If NOT enable click on it to Enable)');
        await PageHelper.click(CommonPage.projectTab);
        // Ensure Respect Links option is enabled (If NOT enable click on it to Enable and Respect Links' option is enabled
        // is not possible by automation.
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.one, ProjectItemPageConstants.newTaskFields.start).click();
        const finishDate = await ProjectItemPageHelper.getFinishDate(ProjectItemPageConstants.index.one).getText();
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.two, ProjectItemPageConstants.newTaskFields.start).click();
        const startDate1 = await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.two,
            ProjectItemPageConstants.newTaskFields.start).getText();
        const finishDate1 = await ProjectItemPageHelper.getFinishDate(ProjectItemPageConstants.index.two).getText();
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.three,
            ProjectItemPageConstants.newTaskFields.start).click();
        const finishDate2 = await ProjectItemPageHelper.getFinishDate(ProjectItemPageConstants.index.three).getText();
        const startDate2 = await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.three,
            ProjectItemPageConstants.newTaskFields.start).getText();

        stepLogger.stepId(5);
        stepLogger.step(`${operation} the Duration for task1 from, say, 5 to 3 days`);
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.one, ProjectItemPageConstants.newTaskFields.start).click();
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.duration);
        await PageHelper.actionSendKeys(updatedHours);
        stepLogger.step('Click anywhere in the page/tab out of the Duration column');
        await PageHelper.click(ProjectItemPage.selectTaskName);

        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.one, ProjectItemPageConstants.newTaskFields.start).click();
        const updatedFinishDate = ProjectItemPageHelper.getFinishDate(ProjectItemPageConstants.index.one).getText();
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.two, ProjectItemPageConstants.newTaskFields.start).click();
        const updatedStartDate1 = ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.two,
            ProjectItemPageConstants.newTaskFields.start).getText();
        const updatedFinishDate1 = ProjectItemPageHelper.getFinishDate(ProjectItemPageConstants.index.two).getText();
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.three,
            ProjectItemPageConstants.newTaskFields.start).click();
        const updatedFinishDate2 = ProjectItemPageHelper.getFinishDate(ProjectItemPageConstants.index.three).getText();
        const updatedStartDate2 = ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.three,
            ProjectItemPageConstants.newTaskFields.start).getText();

        stepLogger.verification('Task1\'s Finish Date gets shifted forward');
        stepLogger.verification('Start and Finish dates for Task 2 and Task 3 get shifted forward');
        await expect(await updatedFinishDate).not.toBe(finishDate, ValidationsHelper.getNotDisplayedValidation(finishDate));
        await expect(await updatedStartDate1).not.toBe(startDate1, ValidationsHelper.getNotDisplayedValidation(startDate1));
        await expect(await updatedStartDate2).not.toBe(startDate2, ValidationsHelper.getNotDisplayedValidation(startDate2));
        await expect(await updatedFinishDate1).not.toBe(finishDate1, ValidationsHelper.getNotDisplayedValidation(finishDate1));
        await expect(await updatedFinishDate2).not.toBe(finishDate2, ValidationsHelper.getNotDisplayedValidation(finishDate2));
    }

    static async navigateToPlannerAndDeleteTask() {
        await PageHelper.click(CommonPage.project);
        await PageHelper.click(CommonPage.editPlan);
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.plannerbox);
        await CommonPageHelper.deleteTask();
    }

}
