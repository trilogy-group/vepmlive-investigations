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

    static async increaseAndDecreaseTaskDuration(uniqueId: string, updatedHours: string, operation: string) {

        StepLogger.stepId(1);
        StepLogger.step('Click on "Task" button');
        StepLogger.step('Enter details for Task (Name, Hours)');
        await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours1, uniqueId);
        await CommonPageHelper.enterTaskNameAndData(CommonPageConstants.hours.durationHours2, uniqueId);
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
        StepLogger.step('Select All three tasks using Shift or Ctrl buttons');
        await ProjectItemPageHelper.selectCreatedTask();
        await PageHelper.click(CommonPage.linkDownbutton);

        StepLogger.verification('Add Link pop up is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.addButton)).toBe(true,
            ValidationsHelper.getButtonDisplayedValidation(CommonPageConstants.buttonName.addButton));

        StepLogger.stepId(3);
        StepLogger.step('Leave the default value "0" in "Lag Time (Days)" text box\n' +
            'Click on "Add Link" button');
        await PageHelper.click(CommonPage.addButton);

        StepLogger.verification('Add Link pop up is closed');
        await WaitHelper.waitForElementToBeHidden(CommonPage.addButton);
        await expect(await CommonPage.addButton.isPresent()).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(CommonPageConstants.buttonName.addButton));

        StepLogger.verification('Selected tasks are linked');
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.two, ProjectItemPageConstants.newTaskFields.start).click();
        await expect(await ProjectItemPageHelper.newTasksFields.predecessors.getText())
            .toBe(CommonPageConstants.predecessorsData.predecessors1,
                ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.predecessors,
                    CommonPageConstants.predecessorsData.predecessors1));
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.three,
            ProjectItemPageConstants.newTaskFields.start).click();
        await expect(await ProjectItemPageHelper.newTasksFields.predecessors.getText())
            .toBe(CommonPageConstants.predecessorsData.predecessors2,
                ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.predecessors,
                    CommonPageConstants.predecessorsData.predecessors2));

        StepLogger.stepId(4);
        StepLogger.step('Click on Project tab');
        StepLogger.step('Ensure Respect Links option is enabled (If NOT enable click on it to Enable)');
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

        StepLogger.stepId(5);
        StepLogger.step(`${operation} the Duration for task1 from, say, 5 to 3 days`);
        await ProjectItemPageHelper.getselectTask(ProjectItemPageConstants.index.one, ProjectItemPageConstants.newTaskFields.start).click();
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.duration);
        await PageHelper.actionSendKeys(updatedHours);
        StepLogger.step('Click anywhere in the page/tab out of the Duration column');
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

        StepLogger.verification('Task1\'s Finish Date gets shifted forward');
        StepLogger.verification('Start and Finish dates for Task 2 and Task 3 get shifted forward');
        await expect(updatedFinishDate).not.toBe(finishDate, ValidationsHelper.getNotDisplayedValidation(finishDate));
        await expect(updatedStartDate1).not.toBe(startDate1, ValidationsHelper.getNotDisplayedValidation(startDate1));
        await expect(updatedStartDate2).not.toBe(startDate2, ValidationsHelper.getNotDisplayedValidation(startDate2));
        await expect(updatedFinishDate1).not.toBe(finishDate1, ValidationsHelper.getNotDisplayedValidation(finishDate1));
        await expect(updatedFinishDate2).not.toBe(finishDate2, ValidationsHelper.getNotDisplayedValidation(finishDate2));
    }

    static async navigateToPlannerAndDeleteTask() {
        await PageHelper.click(CommonPage.project);
        await PageHelper.click(CommonPage.editPlan);
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);
        await CommonPageHelper.deleteTask();
    }

}
