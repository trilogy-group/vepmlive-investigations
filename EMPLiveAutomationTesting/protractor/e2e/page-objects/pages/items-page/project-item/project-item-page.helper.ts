import {browser, By, element, ElementFinder, protractor} from 'protractor';
import {ProjectItemPage} from './project-item.po';
import {ProjectItemPageConstants} from './project-item-page.constants';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {ElementHelper} from '../../../../components/html/element-helper';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../common/common-page.helper';
import {CommonPage} from '../../common/common.po';
import {AnchorHelper} from '../../../../components/html/anchor-helper';
import {CommonPageConstants} from '../../common/common-page.constants';
import {HomePage} from '../../homepage/home.po';
import {CheckboxHelper} from '../../../../components/html/checkbox-helper';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';
import {MyTimeOffPage} from '../../my-workplace/my-time-off/my-time-off.po';

export class ProjectItemPageHelper {
    static get getlink() {
        return {
            myLanguageAndRegion: ElementHelper.getElementByText(ProjectItemPageConstants.userInformation.myLanguageAndRegion),
            adminUser: ElementHelper.getElementByText(ProjectItemPageConstants.users.adminUser),
            region: ElementHelper.getElementByText(ProjectItemPageConstants.region),
        };
    }

    static get button() {
        return {
            ok: ElementHelper.getElementByText(ProjectItemPageConstants.inputLabels.ok),
        };
    }

    static get newTasksFields() {
        const fields = ProjectItemPageConstants.newTaskFields;
        return {
            title: ProjectItemPageHelper.getField(fields.title),
            work: ProjectItemPageHelper.getField(fields.work),
            duration: ProjectItemPageHelper.getField(fields.duration),
            date: ProjectItemPageHelper.dateField(fields.date),
            predecessors: ProjectItemPageHelper.getField(fields.predecessors),
        };

    }

    static async fillForm(projectNameValue: string,
                          projectDescription: string,
                          benefits: string,
                          overallHealth: string,
                          projectUpdateManual: string,
                          stepLogger: StepLogger) {
        const labels = ProjectItemPageConstants.inputLabels;
        const inputs = ProjectItemPage.inputs;

        // Add project name
        stepLogger.step('Title *: Random New Issue Item');
        await TextboxHelper.sendKeys(inputs.projectName, projectNameValue);

        stepLogger.verification('Required values entered/selected in name Field');
        await expect(await TextboxHelper.hasValue(inputs.projectName, projectNameValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.projectName, projectNameValue));

       /* // Add portfolio name
        stepLogger.step('Select any Portfolio from the drop down [Ex: Test Portfolio1]');
        await PageHelper.click(ProjectItemPage.portfolioShowAllButton);
        await WaitHelper.waitForElementToBeDisplayed(inputs.portfolio);
        const portfolioName = await inputs.portfolio.getText();
        stepLogger.verification('Required values selected in Portfolio Field');

        await PageHelper.click(inputs.portfolio);
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(portfolioName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.portfolio, portfolioName));
*/
        // Add Project Description
        stepLogger.step('Enter some text [Ex: Description for Smoke Test Project 1]');
        await TextboxHelper.sendKeys(inputs.projectDescription, projectDescription);

        stepLogger.verification('Required values entered in Description Field');
        await expect(await TextboxHelper.hasValue(inputs.projectDescription, projectDescription))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.projectDescription, projectDescription));

        // Add Benefits
        stepLogger.step('Benefits: Test Smoke');
        await TextboxHelper.sendKeys(inputs.benefits, benefits);

        stepLogger.verification('Required values entered in "Benefits" Field');
        await expect(await TextboxHelper.hasValue(inputs.benefits, benefits))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.benefits, benefits));

        // Add Overall Health
        stepLogger.step(`Overall Health: Select the value ${overallHealth}`);
        await PageHelper.sendKeysToInputField(inputs.overallHealth, overallHealth);

        stepLogger.verification(`Verify - Overall Health: Select the value ${overallHealth}`);
        await expect(await ElementHelper.hasSelectedOption(inputs.overallHealth, overallHealth))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.overallHealth, overallHealth));
        await browser.sleep(10000);
        // Add Project Update
        stepLogger.step(`Project Update: Select the value "${projectUpdateManual}"`);
        await PageHelper.sendKeysToInputField(inputs.projectUpdate, projectUpdateManual);

        stepLogger.verification(`Verify - Project Update : Select the value "${projectUpdateManual}"`);
        await expect(await ElementHelper.hasSelectedOption(inputs.projectUpdate, projectUpdateManual))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.projectUpdate, projectUpdateManual));

        stepLogger.stepId(4);
        stepLogger.step('Click on "Save" button in "Project - New Item" window');
        await PageHelper.click(CommonPage.formButtons.save);

        stepLogger.verification('"Project - New Item" window is closed');
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.pageName));
    }

    static async navigateAndOpenProjectPage(projectNameValue: string, stepLogger: StepLogger) {
        stepLogger.verification('Navigate to page');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.verification('Search item by title');
        await CommonPageHelper.searchItemByTitle(projectNameValue,
            ProjectItemPageConstants.columnNames.title,
            stepLogger);

        stepLogger.verification('Newly created Project [Ex: Project 1] displayed in "Project" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(projectNameValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(projectNameValue));

        stepLogger.step('Click on searched record');
        await PageHelper.click(CommonPage.record);

        stepLogger.verification('Verify record by title');
        const firstTableColumns = [projectNameValue];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(firstTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(firstTableColumns.join(CommonPageConstants.and)));

        stepLogger.step('Click on Project record');
        await PageHelper.click(CommonPageHelper.getRowForTableData(firstTableColumns));
    }

    static async createNewProject(uniqueId: string, stepLogger: StepLogger) {

        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.step('Click on "+ New item" link displayed on top of "Project Center" Page');
        await PageHelper.click(CommonPage.addNewLink);

        // Note - little mismatch, It doesn't open a popup window
        stepLogger.verification('"Project Center - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ProjectItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        stepLogger.step('Enter/Select required details in "Project Center - New Item" window as described below');
        const labels = ProjectItemPageConstants.inputLabels;
        const projectNameValue = `${labels.projectName} ${uniqueId}`;
        const projectDescription = `${labels.projectDescription} ${uniqueId}`;
        const benefits = `${labels.benefits} ${uniqueId}`;
        const overallHealthOnTrack = CommonPageConstants.overallHealth.onTrack;
        const projectUpdateManual = CommonPageConstants.projectUpdate.manual;

        await ProjectItemPageHelper.fillForm(
            projectNameValue,
            projectDescription,
            benefits,
            overallHealthOnTrack,
            projectUpdateManual,
            stepLogger);

        return projectNameValue;
    }

    static async waitForBuildTeamPageToOpenAndSwitchToPage(stepLogger: StepLogger) {
        stepLogger.step('Waiting for page to open');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(ProjectItemPageConstants.buildTeamPage,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.buildTeamPage));

        stepLogger.step('Switch to frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);
    }

    static async createTask(uniqueId: string, stepLogger: StepLogger, finishDate: string) {

        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);
        await CommonPageHelper.deleteTask();
        stepLogger.step('Click on Add Task');
        await PageHelper.click(CommonPage.ribbonItems.addTask);
        stepLogger.step('Enter Task name');
        await PageHelper.actionSendKeys(uniqueId);
        stepLogger.step('Enter finish date');
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.date);
        await ElementHelper.actionDoubleClick(ProjectItemPageHelper.newTasksFields.date);
        await TextboxHelper.sendKeys(MyTimeOffPage.dateEditBox, finishDate);
        stepLogger.step('Enter duration');
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.duration);
        await PageHelper.actionSendKeys(CommonPageConstants.hours.durationHours1);
        stepLogger.step('Enter effort hours');
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.work);
        await PageHelper.actionSendKeys(CommonPageConstants.hours.effortHours);
        stepLogger.step('Select assignee');
        await PageHelper.click(ProjectItemPage.assignToDropDown);
        await PageHelper.click(ProjectItemPageHelper.selectFirstAssign());
        stepLogger.step('Click OK');
        await PageHelper.click(ProjectItemPageHelper.button.ok);
    }

    static async createProjectAndNavigateToBuildTeamPage(uniqueId: string, stepLogger: StepLogger) {
        stepLogger.step('Create a new project');
        const projectNameValue = await ProjectItemPageHelper.createNewProject(uniqueId, stepLogger);

        stepLogger.step('Navigate and open specific project page');
        await ProjectItemPageHelper.navigateAndOpenProjectPage(projectNameValue, stepLogger);

        stepLogger.step('Select "Edit Team" from the options displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        stepLogger.step('Wait for Build Team Page to open');
        await ProjectItemPageHelper.waitForBuildTeamPageToOpenAndSwitchToPage(stepLogger);
    }

    static async addResourceAndVerifyUserMovedUnderCurrentTeam(uniqueId: string, stepLogger: StepLogger) {
        const labels = ProjectItemPageConstants.inputLabels;
        const projectNameValue = `${labels.projectName} ${uniqueId}`;

        stepLogger.step('Select a user from resource pool and add');
        const userCheckBoxForResourcePool = await ProjectItemPage.getUserCheckBoxForTeamType(
            ProjectItemPageConstants.buildTeamContentIDs.resourcePool, ProjectItemPageConstants.nonAdminUser);
        await CheckboxHelper.markCheckbox(userCheckBoxForResourcePool, true);

        stepLogger.step('Click on Add resource');
        await PageHelper.click(CommonPage.formButtons.add);

        stepLogger.verification('Verify Save and Close button is enabled after addition of resource');
        await expect(await ElementHelper.hasClass(ProjectItemPage.saveAndClose,
            ProjectItemPageConstants.buildTeamContentClass.saveAndCloseDisabled))
            .toBe(false, ProjectItemPageConstants.messageText.saveAndCloseEnabled);

        stepLogger.step('Click on Save & Close button');
        await PageHelper.click(CommonPage.ribbonItems.saveAndClose);

        await PageHelper.switchToDefaultContent();

        stepLogger.verification('Verify Project page is displayed');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(projectNameValue)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(projectNameValue));

        stepLogger.step('Navigate and open specific project page');
        await ProjectItemPageHelper.navigateAndOpenProjectPage(projectNameValue, stepLogger);

        stepLogger.step('Select "Edit Team" from the options displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        stepLogger.step('Wait for Build Team Page to open');
        await ProjectItemPageHelper.waitForBuildTeamPageToOpenAndSwitchToPage(stepLogger);

        stepLogger.verification('Verify User is moved under Current team');
        const userCheckBoxForCurrentTeam = await ProjectItemPage.getUserCheckBoxForTeamType(
            ProjectItemPageConstants.buildTeamContentIDs.currentTeam, ProjectItemPageConstants.nonAdminUser);
        await expect(await PageHelper.isElementDisplayed(userCheckBoxForCurrentTeam))
            .toBe(true, ValidationsHelper.getGridDisplayedValidation(ProjectItemPageConstants.nonAdminUser));
    }

    static getTeamSectionsByText(text: string) {
        return element(By.xpath(`//div[contains(@class,'gridHeader') and ${ComponentHelpers.getXPathFunctionForDot(text)}]`));
    }

    static getTeamChangeButtonByValue(value: string) {
        return element(By.css(`[value = "${value}"]`));
    }

    static async checkResourceAddedInCurrentTeam(resourceName: string) {
        let resourceFound = false, text;
        const label = ProjectItemPage.teamRecordsName.currentTeam;
        await WaitHelper.waitForElementToBeDisplayed(label.first());
        const size = await label.count();
        for (let index = 0; index < size && !resourceFound; index++) {
            await ElementHelper.scrollToElement(label.get(index));
            text = await label.get(index).getText();
            if (text === resourceName) {
                resourceFound = true;
            }
        }
        return resourceFound;
    }

    static async selectPlannerIfPopUpAppears(planner: ElementFinder) {
        if (await element.all(By.tagName('iframe')).count() >= 1) {
            await PageHelper.switchToFrame(CommonPage.contentFrame);
            await PageHelper.click(planner);
            await PageHelper.switchToDefaultContent();
        }
    }

    static getReportParametersByTitle(title: string) {
        return element(By.xpath(`//table[contains(@id,"ParameterTable")]//td/span[contains(text(),'${title}')]`));
    }

    static getReportPagingHeaderByTitle(title: string) {
        return element(By.css(`input.sqlrv-Image[name*="RptControls"][title="${title}"]`));
    }

    static dateField(tab: string) {
        // it is a part of a object "newTasksFields", object created below
        return element(By.xpath(`//*[contains(@class,"GSClassSelected ")]/*[contains(@class,"${tab}")][1]`));
    }

    static getField(tab: string) {
        // it is a part of a object "newTasksFields", object created below
        return element(By.xpath(`.//*[contains(@class,"GSClassSelected")]//*[contains(@class,"${tab}")]`));
    }

    static getDisabledReportPagingHeaderByTitle(title: string) {
        return element(By.xpath(`(//input[@title="${title}" and @disabled])[1]`));
    }

    static getselectTask(index: number, column: string) {
        // because xpath get change when tab selected, it used only once and "GSDataRow" I have managed for other locator.
        return element(By.xpath(`.//*[@class="GSSection"]/tbody/tr[3]//*[contains(@class,"GSDataRow")][${index}]//*[contains
        (@class,"${column}")]`));
    }

    static async closeResourcePage() {
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(CommonPage.resourceCloseButton);
    }

    static getFinishDate(index: number) {
        // because xpath get change when tab selected, it used only once and "GSDataRow" I have managed for other locator.
        return element(By.xpath(`.//*[@class="GSSection"]/tbody/tr[3]//*[contains(@class,"GSDataRow")][${index}]//*[contains(@class,
        "GSNoRight") and contains(@class,"Due")]`));
    }

    static async verifyTitleAndDuration(uniqueId: string, value: string) {
        await expect(await ProjectItemPageHelper.newTasksFields.title.getText()).toBe(uniqueId,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.title, uniqueId));
        await expect(await ProjectItemPageHelper.newTasksFields.duration.getText()).toBe(value,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.newTaskFields.duration, value));
    }

    static async verifyGanttChart() {
        const isBarChartPresent = await ProjectItemPage.ganttChartBars.isPresent();
        await expect(isBarChartPresent).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(ProjectItemPageConstants.ganttChart));
    }

    static async verifyAlertMessage() {
        await expect(await browser.switchTo().alert().getText()).toContain(ProjectItemPageConstants.baseLineMessage.clear,
            ValidationsHelper.getRecordContainsMessage(ProjectItemPageConstants.baseLineMessage.clear));
    }

    static async verifyFragmentDropDownLabel() {
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.fragmentDropDownLabels.insert)).toBe(true,
            ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.fragmentLabels.insert));
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.fragmentDropDownLabels.save)).toBe(true,
            ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.fragmentLabels.save));
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.fragmentDropDownLabels.manage)).toBe(true,
            ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.fragmentLabels.manage));
    }

    static async selectCreatedTask() {
        await ProjectItemPageHelper.getselectTask(1, ProjectItemPageConstants.newTaskFields.start).click();
        const elm2 = this.getselectTask(2, ProjectItemPageConstants.newTaskFields.start);
        const elm3 = this.getselectTask(3, ProjectItemPageConstants.newTaskFields.start);
        await browser.actions().keyDown(protractor.Key.CONTROL).perform();
        await elm2.click();
        await elm3.click();
        await browser.actions().keyUp(protractor.Key.CONTROL).perform();
    }

    static async selectCreatedTaskTwoAndThree() {
        await ProjectItemPageHelper.getselectTask(2, ProjectItemPageConstants.newTaskFields.start).click();
        const elm3 = this.getselectTask(3, ProjectItemPageConstants.newTaskFields.start);
        await browser.actions().keyDown(protractor.Key.CONTROL).perform();
        await elm3.click();
        await browser.actions().keyUp(protractor.Key.CONTROL).perform();
    }

    static async clickOnViewReports() {
        await PageHelper.click(CommonPage.ribbonItems.viewReports);
        await browser.sleep(PageHelper.timeout.xs);
    }

    static async createProject(uniqueId: string, stepLogger: StepLogger) {
        stepLogger.step('Create a new project');
        await ProjectItemPageHelper.createNewProject(uniqueId, stepLogger);
    }

    static async removeAssignedUserIfPresent(stepLogger: StepLogger) {
        stepLogger.step('Removed assigned user from current team');
        if (await ProjectItemPage.selectTeamMemberCheckBox.isPresent() === true) {
            await PageHelper.click(ProjectItemPage.selectTeamMemberCheckBox);
            await PageHelper.click(ProjectItemPage.teamChangeButtons.remove);
        }
    }

    static async unCheckedSelectColumnIfChecked() {
        if (await ProjectItemPage.selectColumnName.isPresent() === false) {
            await PageHelper.click(ElementHelper.getElementByText(ProjectItemPageConstants.actualCost));
            await PageHelper.click(ProjectItemPage.selectColumnLabel.ok);
        }
    }

    static selectFirstAssign() {
        return this.selectAssign(1);
    }

    static selectLastAssign() {
        return this.selectAssign(3);
    }

    static selectAssign(index: number) {
        return element(By.css(`[class*="MenuBody"] > div > div:nth-child(${index})`));
    }

    static async editProjectAndValidateIt(stepLogger: StepLogger, projectNameValue: string) {
        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger,
            projectNameValue,
            ProjectItemPageConstants.columnNames.title);
        await CommonPageHelper.editOptionViaRibbon(stepLogger);
        projectNameValue = projectNameValue + 'Edited';
        stepLogger.verification('"Edit Project" page is displayed');
        await CommonPageHelper.pageDisplayedValidation(ProjectItemPageConstants.pagePrefix);

        await TextboxHelper.sendKeys(ProjectItemPage.inputs.projectName, projectNameValue);

        await PageHelper.click(CommonPage.formButtons.save);

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger,
            projectNameValue,
            ProjectItemPageConstants.columnNames.title);

        stepLogger.verification('Newly created Project [Ex: Project 1] displayed in "Project" page');
        await CommonPageHelper.labelDisplayedValidation(AnchorHelper.getElementByTextInsideGrid(projectNameValue), projectNameValue);
        return projectNameValue;

    }

    static async deleteOptionViaRibbon(stepLogger: StepLogger, item = CommonPage.record) {
        await CommonPageHelper.selectRecordFromGrid(stepLogger, item);

        stepLogger.step('Select "Delete" from the options displayed');
        await PageHelper.click(CommonPage.ribbonItems.delete);

        await PageHelper.acceptAlert();
    }

    static async deleteProjectAndValidateIt(stepLogger: StepLogger, projectNameValue: string) {
        await this.deleteOptionViaRibbon(stepLogger);

        stepLogger.verification('Navigate to page');
        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger,
            projectNameValue,
            ProjectItemPageConstants.columnNames.title);

        stepLogger.step('Validating deleted Project  is not  Present');
        await CommonPageHelper.fieldDisplayedValidation(ProjectItemPage.noProjecrMsg, ProjectItemPageConstants.noDataFound);
    }

    static async verifyProjectDetailsDisplayed(stepLogger: StepLogger) {
        stepLogger.verification('Project Details opened ');
        await CommonPageHelper.labelDisplayedValidation
        (CommonPage.pageHeaders.projects.projectDetails, CommonPageConstants.pageHeaders.projects.projectDetails);
    }
}
