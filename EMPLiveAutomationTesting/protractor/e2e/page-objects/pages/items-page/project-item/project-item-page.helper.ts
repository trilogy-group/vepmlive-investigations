import { browser, By, element, ElementFinder, protractor } from 'protractor';

import { ExpectationHelper } from '../../../../components/misc-utils/expectation-helper';
import { LoginPageHelper } from '../../login/login-page.helper';
import { ProjectItemPage } from './project-item.po';
import { ProjectItemPageConstants } from './project-item-page.constants';
import { StepLogger } from '../../../../../core/logger/step-logger';
import { TextboxHelper } from '../../../../components/html/textbox-helper';
import { ValidationsHelper } from '../../../../components/misc-utils/validation-helper';
import { PageHelper } from '../../../../components/html/page-helper';
import { ElementHelper } from '../../../../components/html/element-helper';
import { WaitHelper } from '../../../../components/html/wait-helper';
import { CommonPageHelper } from '../../common/common-page.helper';
import { CommonPage } from '../../common/common.po';
import { AnchorHelper } from '../../../../components/html/anchor-helper';
import { CommonPageConstants } from '../../common/common-page.constants';
import { HomePage } from '../../homepage/home.po';
import { CheckboxHelper } from '../../../../components/html/checkbox-helper';
import { ComponentHelpers } from '../../../../components/devfactory/component-helpers/component-helpers';
import { MyTimeOffPage } from '../../my-workplace/my-time-off/my-time-off.po';
import { ResourcePlannerConstants } from '../../resource-planner-page/resource-planner-page.constants';
import { EditCost } from './edit-cost-page/edit-cost.po';

export class ProjectItemPageHelper {
    static get getlink() {
        return {
            myLanguageAndRegion: ElementHelper.getElementByText(ProjectItemPageConstants.userInformation.myLanguageAndRegion),
            adminUser: element(By.css(`td.GMCell>a[href*=${LoginPageHelper.adminEmailId}]`)),
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
    ) {
        const labels = ProjectItemPageConstants.inputLabels;
        const inputs = ProjectItemPage.inputs;

        // Add project name
        StepLogger.step('Title *: Random New Issue Item');
        await TextboxHelper.sendKeys(inputs.projectName, projectNameValue);

        StepLogger.verification('Required values entered/selected in name Field');
        await expect(await TextboxHelper.hasValue(inputs.projectName, projectNameValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.projectName, projectNameValue));

        /* // Add portfolio name
         StepLogger.step('Select any Portfolio from the drop down [Ex: Test Portfolio1]');
         await PageHelper.click(ProjectItemPage.portfolioShowAllButton);
         await WaitHelper.waitForElementToBeDisplayed(inputs.portfolio);
         const portfolioName = await inputs.portfolio.getText();
         StepLogger.verification('Required values selected in Portfolio Field');

         await PageHelper.click(inputs.portfolio);
         await expect(await CommonPageHelper.getAutoCompleteItemByDescription(portfolioName).isPresent())
             .toBe(true,
                 ValidationsHelper.getFieldShouldHaveValueValidation(labels.portfolio, portfolioName));
 */
        // Add Project Description
        StepLogger.step('Enter some text [Ex: Description for Smoke Test Project 1]');
        await TextboxHelper.sendKeys(inputs.projectDescription, projectDescription);

        StepLogger.verification('Required values entered in Description Field');
        await expect(await TextboxHelper.hasValue(inputs.projectDescription, projectDescription))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.projectDescription, projectDescription));

        // Add Benefits
        StepLogger.step('Benefits: Test Smoke');
        await TextboxHelper.sendKeys(inputs.benefits, benefits);

        StepLogger.verification('Required values entered in "Benefits" Field');
        await expect(await TextboxHelper.hasValue(inputs.benefits, benefits))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.benefits, benefits));

        // Add Overall Health
        StepLogger.step(`Overall Health: Select the value ${overallHealth}`);
        await PageHelper.sendKeysToInputField(inputs.overallHealth, overallHealth);

        StepLogger.verification(`Verify - Overall Health: Select the value ${overallHealth}`);
        await expect(await ElementHelper.hasSelectedOption(inputs.overallHealth, overallHealth))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.overallHealth, overallHealth));
        await browser.sleep(10000);
        // Add Project Update
        StepLogger.step(`Project Update: Select the value "${projectUpdateManual}"`);
        await PageHelper.sendKeysToInputField(inputs.projectUpdate, projectUpdateManual);

        StepLogger.verification(`Verify - Project Update : Select the value "${projectUpdateManual}"`);
        await expect(await ElementHelper.hasSelectedOption(inputs.projectUpdate, projectUpdateManual))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.projectUpdate, projectUpdateManual));

        StepLogger.stepId(4);
        StepLogger.step('Click on "Save" button in "Project - New Item" window');
        await PageHelper.click(CommonPage.formButtons.save);

        StepLogger.verification('"Project - New Item" window is closed');
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.pageName));
    }

    static async navigateAndOpenProjectPage(projectNameValue: string, toOpen = true) {
        StepLogger.verification('Navigate to page');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.verification('Search item by title');
        await CommonPageHelper.searchItemByTitle(projectNameValue,
            ProjectItemPageConstants.columnNames.title,
        );

        StepLogger.verification('Newly created Project [Ex: Project 1] displayed in "Project" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(projectNameValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(projectNameValue));

        StepLogger.step('Click on searched record');
        await PageHelper.click(CommonPage.record);

        StepLogger.verification('Verify record by title');
        const firstTableColumns = [projectNameValue];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(firstTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(firstTableColumns.join(CommonPageConstants.and)));

        StepLogger.step('Click on Project record');
        await PageHelper.sleepForXSec(PageHelper.timeout.xs);
        await ElementHelper.actionHoverOver(CommonPageHelper.getRowForTableData(firstTableColumns));
        if (toOpen) {
            await PageHelper.click(CommonPageHelper.getRowForTableData(firstTableColumns));
        }
    }

    static async createNewProject(uniqueId: string) {

        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.step('Click on "+ New item" link displayed on top of "Project Center" Page');
        await PageHelper.click(CommonPage.addNewLink);
        await PageHelper.acceptAlertIfPresent();

        // Note - little mismatch, It doesn't open a popup window
        StepLogger.verification('"Project Center - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ProjectItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        StepLogger.step('Enter/Select required details in "Project Center - New Item" window as described below');
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
        );

        return projectNameValue;
    }

    static async waitForBuildTeamPageToOpenAndSwitchToPage() {
        StepLogger.step('Waiting for page to open');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(ProjectItemPageConstants.editTeamDialog,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.editTeamDialog));

        StepLogger.step('Switch to frame');
        await CommonPageHelper.switchToContentFrame();
    }

    static async createTask(uniqueId: string, finishDate: string) {

        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);
        await CommonPageHelper.deleteTask();
        StepLogger.step('Click on Add Task');
        await ElementHelper.actionHoverOver(CommonPage.ribbonItems.addTask);
        await PageHelper.click(CommonPage.ribbonItems.addTask);
        StepLogger.step('Enter Task name');
        await PageHelper.actionSendKeys(uniqueId);
        StepLogger.step('Enter finish date');
        await ElementHelper.actionHoverOver(ProjectItemPageHelper.newTasksFields.date);
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.date);
        await ElementHelper.actionDoubleClick(ProjectItemPageHelper.newTasksFields.date);
        await TextboxHelper.sendKeys(MyTimeOffPage.dateEditBox, finishDate);
        StepLogger.step('Enter duration');
        await ElementHelper.actionHoverOver(ProjectItemPageHelper.newTasksFields.duration);
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.duration);
        await ElementHelper.actionDoubleClick(ProjectItemPageHelper.newTasksFields.duration);
        await PageHelper.actionSendKeys(CommonPageConstants.hours.durationHours1);
        StepLogger.step('Enter effort hours');
        await ElementHelper.actionHoverOver(ProjectItemPageHelper.newTasksFields.work);
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.work);
        await ElementHelper.actionDoubleClick(ProjectItemPageHelper.newTasksFields.work);
        await PageHelper.actionSendKeys(CommonPageConstants.hours.effortHours);
        StepLogger.step('Select assignee');
        await ElementHelper.actionHoverOver(ProjectItemPage.assignToDropDown);
        await PageHelper.click(ProjectItemPage.assignToDropDown);
        await ElementHelper.actionDoubleClick(ProjectItemPage.assignToDropDown);
        await PageHelper.click(ProjectItemPageHelper.selectFirstAssign());
        StepLogger.step('Click OK');
        await PageHelper.click(ProjectItemPageHelper.button.ok);
    }

    static async createProjectAndNavigateToBuildTeamPage(uniqueId: string) {
        StepLogger.subStep('Create a new project');
        const projectNameValue = await ProjectItemPageHelper.createNewProject(uniqueId);

        StepLogger.subStep('Navigate and open specific project page');
        await ProjectItemPageHelper.navigateAndOpenProjectPage(projectNameValue, false);

        StepLogger.subStep('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        StepLogger.subStep('Select "Edit Team" from the options displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeamButton);
        await PageHelper.click(CommonPage.ribbonItems.editTeamButton);

        StepLogger.subStep('Wait for Build Team Page to open');
        await ProjectItemPageHelper.waitForBuildTeamPageToOpenAndSwitchToPage();
    }

    static async addResourceAndVerifyUserMovedUnderCurrentTeam(uniqueId: string) {
        const labels = ProjectItemPageConstants.inputLabels;
        const projectNameValue = `${labels.projectName} ${uniqueId}`;

        StepLogger.subStep('Select a user from resource pool and add');
        const userCheckBoxForResourcePool = ProjectItemPage.getResourcePoolFirstUserCheckBox;
        const userNameForResourcePool = await PageHelper.getText(ProjectItemPage.getResourcePoolFirstUserLabelLink);
        await CheckboxHelper.markCheckbox(userCheckBoxForResourcePool, true);

        StepLogger.subStep('Click on Add resource');
        await PageHelper.click(CommonPage.formButtons.add);

        StepLogger.verification('Verify Save and Close button is enabled after addition of resource');
        await expect(await ElementHelper.hasClass(ProjectItemPage.saveAndClose,
            ProjectItemPageConstants.buildTeamContentClass.saveAndCloseDisabled))
            .toBe(false, ProjectItemPageConstants.messageText.saveAndCloseEnabled);

        StepLogger.subStep('Click on Save & Close button');
        await PageHelper.click(CommonPage.ribbonItems.saveAndClose);

        StepLogger.subStep('Switch to default content');
        await WaitHelper.waitForElementToBeHidden(CommonPage.ribbonItems.saveAndClose);
        await PageHelper.switchToDefaultContent();

        StepLogger.subStep('Navigate and open specific project page');
        await ProjectItemPageHelper.navigateAndOpenProjectPage(projectNameValue, false);

        StepLogger.subStep('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        StepLogger.subStep('Select "Edit Team" from the options displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeamButton);
        await PageHelper.click(CommonPage.ribbonItems.editTeamButton);

        StepLogger.subStep('Wait for Build Team Page to open');
        await ProjectItemPageHelper.waitForBuildTeamPageToOpenAndSwitchToPage();

        StepLogger.subVerification('Verify User is moved under Current team');
        const userCheckBoxForCurrentTeam = await ProjectItemPage.getCurrentTeamUserLabelLinkByText(userNameForResourcePool);
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
        try {
            await CommonPageHelper.switchToContentFrame();
            await WaitHelper.staticWait(PageHelper.timeout.xs);
            await PageHelper.clickAndWaitForElementToHide(planner);
            await PageHelper.switchToDefaultContent();
        } catch {
            StepLogger.subStep('Pop up did not appear');
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
        await WaitHelper.waitForElementToBeHidden(ProjectItemPage.ganttChartBars);
        await ExpectationHelper.verifyNotDisplayedStatus(ProjectItemPage.ganttChartBars, ProjectItemPageConstants.ganttChart);
    }

    static async verifyAlertMessage() {
        await expect(await PageHelper.getAlertText()).toContain(ProjectItemPageConstants.baseLineMessage.clear,
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

    static async createProject(uniqueId: string) {
        StepLogger.step('Create a new project');
        await ProjectItemPageHelper.createNewProject(uniqueId);
    }

    static async removeAssignedUserIfPresent() {
        StepLogger.step('Removed assigned user from current team');
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

    static async editProjectAndValidateIt(projectNameValue: string) {
        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,

            projectNameValue,
            ProjectItemPageConstants.columnNames.title);
        await CommonPageHelper.editOptionViaRibbon();
        projectNameValue = projectNameValue + 'Edited';
        StepLogger.verification('"Edit Project" page is displayed');
        await CommonPageHelper.pageDisplayedValidation(ProjectItemPageConstants.pagePrefix);

        await TextboxHelper.sendKeys(ProjectItemPage.inputs.projectName, projectNameValue);

        await PageHelper.clickAndWaitForElementToHide(CommonPage.formButtons.save);

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,

            projectNameValue,
            ProjectItemPageConstants.columnNames.title);

        StepLogger.verification('Newly created Project [Ex: Project 1] displayed in "Project" page');
        await CommonPageHelper.labelDisplayedValidation(AnchorHelper.getElementByTextInsideGrid(projectNameValue), projectNameValue);
        return projectNameValue;

    }

    static async deleteOptionViaRibbon(item = CommonPage.record) {
        await CommonPageHelper.selectRecordFromGrid(item);

        StepLogger.step('Select "Delete" from the options displayed');
        await PageHelper.click(CommonPage.ribbonItems.delete);

        await PageHelper.acceptAlertIfPresent();
    }

    static async deleteProjectAndValidateIt(projectNameValue: string) {
        await this.deleteOptionViaRibbon();

        StepLogger.verification('Navigate to page');
        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,

            projectNameValue,
            ProjectItemPageConstants.columnNames.title);

        StepLogger.step('Validating deleted Project  is not  Present');
        await CommonPageHelper.fieldDisplayedValidation(ProjectItemPage.noProjecrMsg, ProjectItemPageConstants.noDataFound);
    }

    static async verifyProjectDetailsDisplayed() {
        StepLogger.verification('Project Details opened ');
        await CommonPageHelper.labelDisplayedValidation
        (CommonPage.contentTitleInViewMode, CommonPageConstants.pageHeaders.projects.projectDetails);
    }

    static async validateProjectOpenInNewTab() {
        StepLogger.verification('Switch To new Tab  ');
        await PageHelper.switchToNewTabIfAvailable(1);
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);

        StepLogger.step('Validating Top Grid Item Name is Present');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.editCostLink, ResourcePlannerConstants.topGrid.itemName);
    }

    static async validateProjectOpenViaRightClickInNewTab() {
        StepLogger.verification('Open project  In New Tab');
        await ElementHelper.openLinkInNewTab(ProjectItemPage.clickProjectLink);

        await this.validateProjectOpenInNewTab();
    }
}
