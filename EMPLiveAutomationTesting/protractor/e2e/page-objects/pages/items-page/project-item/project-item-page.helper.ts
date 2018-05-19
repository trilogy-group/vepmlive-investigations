import {ProjectItemPage} from './project-item.po';
import {ProjectItemPageConstants} from './project-item-page.constants';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {ElementHelper} from '../../../../components/html/element-helper';
import {browser, element, By} from 'protractor';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../common/common-page.helper';
import {CommonPage} from '../../common/common.po';
import {AnchorHelper} from '../../../../components/html/anchor-helper';
import {CommonPageConstants} from '../../common/common-page.constants';
import {HomePage} from '../../homepage/home.po';
import {CheckboxHelper} from '../../../../components/html/checkbox-helper';
import { ComponentHelpers } from '../../../../components/devfactory/component-helpers/component-helpers';

export class ProjectItemPageHelper {
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

        // Add portfolio name
        stepLogger.step('Select any Portfolio from the drop down [Ex: Test Portfolio1]');
        await PageHelper.click(ProjectItemPage.portfolioShowAllButton);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(inputs.portfolio);
        const portfolioName = await inputs.portfolio.getText();
        stepLogger.verification('Required values selected in Portfolio Field');

        await PageHelper.click(inputs.portfolio);
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(portfolioName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.portfolio, portfolioName));

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
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
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
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(ProjectItemPageConstants.buildTeamPage,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.buildTeamPage));

        stepLogger.step('Switch to frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);
    }

    static async createProjectAndNavigateToBuildTeamPage(uniqueId: string, stepLogger: StepLogger) {
        stepLogger.step('Create a new project');
        const projectNameValue = await ProjectItemPageHelper.createNewProject(uniqueId, stepLogger);

        stepLogger.step('Navigate and open specific project page');
        await ProjectItemPageHelper.navigateAndOpenProjectPage(projectNameValue, stepLogger);

        stepLogger.step('Select "Edit Team" from the options displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
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
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ElementHelper.getElementByText(projectNameValue));
        await expect(await PageHelper.isElementPresent(ElementHelper.getElementByText(projectNameValue)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(projectNameValue));

        stepLogger.step('Navigate and open specific project page');
        await ProjectItemPageHelper.navigateAndOpenProjectPage(projectNameValue, stepLogger);

        stepLogger.step('Select "Edit Team" from the options displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        stepLogger.step('Wait for Build Team Page to open');
        await ProjectItemPageHelper.waitForBuildTeamPageToOpenAndSwitchToPage(stepLogger);

        stepLogger.verification('Verify User is moved under Current team');
        const userCheckBoxForCurrentTeam = await ProjectItemPage.getUserCheckBoxForTeamType(
            ProjectItemPageConstants.buildTeamContentIDs.currentTeam, ProjectItemPageConstants.nonAdminUser);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(userCheckBoxForCurrentTeam);
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
        let size = 0, resourceFound = false, text;
        const label = ProjectItemPage.teamRecordsName.currentTeam;
        await WaitHelper.getInstance().waitForElementToBeDisplayed(label.first());
        size = await label.count();
        for (let index = 0; index < size && !resourceFound; index++) {
            text = await label.get(index).getText();
            if (text === resourceName) {
                    resourceFound = true;
                }
        }
        return resourceFound;
    }

    static getReportParametersByTitle(title: string) {
        return element(By.xpath(`//table[contains(@id,"ParameterTable")]//td/span[contains(text(),'${title}')]`));
    }

    static getReportPagingHeaderByTitle(title: string) {
        return element(By.css(`input.sqlrv-Image[name*="RptControls"][title="${title}"]`));
    }

    static getReportTextFunctionHeaderByTitle(title: string) {
        return element(By.css(`.sqlrv[title="${title}"]`));
    }
}
