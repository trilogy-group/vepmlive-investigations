import {SuiteNames} from '../../helpers/suite-names';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {PageHelper} from '../../../components/html/page-helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';
import {WaitHelper} from '../../../components/html/wait-helper';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {ElementHelper} from '../../../components/html/element-helper';
import {ProjectItemPage} from '../../../page-objects/pages/items-page/project-item/project-item.po';
import {ProjectItemPageConstants} from '../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {ProjectItemPageHelper} from '../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {LoginPage} from '../../../page-objects/pages/login/login.po';

describe(SuiteNames.endToEndSuite, () => {
    let loginPage: LoginPage;
    let stepLogger: StepLogger;
    beforeEach(async () => {
        stepLogger = new StepLogger();
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('View the options on "Resource Capacity Heat map" report page" - [743179]', async () => {
        stepLogger.caseId = 743179;
        stepLogger.stepId(1);
        stepLogger.step('Go to Navigation > Projects > Projects');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        stepLogger.step('Mouse over on any Project created as per pre requisites');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.record);
        await ElementHelper.actionHoverOver(CommonPage.record);

        stepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonPage.ellipse);

        stepLogger.step('select "Edit Team" from the options displayed');
        await PageHelper.click(CommonPage.contextMenuOptions.editTeam);

        stepLogger.verification('"Edit Team" pop-up should load successfully');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        await CommonPageHelper.switchToContentFrame(stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "view Reports" drop down displayed on top of "Edit Team" window');
        await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.teamRecords.currentTeam.get(0));
        await ProjectItemPageHelper.clickOnViewReports();

        stepLogger.step('Click on "Resource Capacity Heat Map"');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.resourceCapacityHeatMap);
        await ElementHelper.clickUsingJs(CommonPage.ribbonItems.resourceCapacityHeatMap);
        await PageHelper.switchToDefaultContent();

        stepLogger.step('Verify Reporting Services page will be displayed with below fields');
        stepLogger.step('Verify "Period Start"');
        await PageHelper.switchToNewTabIfAvailable(2);
        await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportParameters.periodStart);
        await expect(await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.reportParameters.periodStart))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.periodStart));

        stepLogger.step('Verify "Period End"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportParameters.periodEnd))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.periodEnd));

        stepLogger.step('Verify "Departments"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportParameters.department))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.department));

        stepLogger.step('Verify "Refresh"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.refresh))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.refresh));

        stepLogger.step('Verify "First Page"');
        await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.firstPage);
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.firstPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.firstPage));

        stepLogger.step('Verify "Previous Page"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.previousPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.previousPage));

        stepLogger.step('Verify "Next Page"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.nextPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.nextPage));

        stepLogger.step('Verify "Last Page"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.lastPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.lastPage));

        stepLogger.step('Verify "Find Text in Report"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.findTextInReport))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.findTextInReport));

        stepLogger.step('Verify "Next Find"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.findNext))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.findNext));

        stepLogger.step('Verify "Actions dropdwon"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.actionsdropdown))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.actionsDropdown));
    });

    it('View the options on "Resource Commitment" report page" - [743182]', async () => {
        stepLogger.caseId = 743182;
        stepLogger.stepId(1);
        stepLogger.step('Go to Navigation > Projects > Projects');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        stepLogger.step('Mouse over on any Project created as per pre requisites');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.record);
        await ElementHelper.actionHoverOver(CommonPage.record);

        stepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonPage.ellipse);

        stepLogger.step('select "Edit Team" from the options displayed');
        await PageHelper.click(CommonPage.contextMenuOptions.editTeam);

        stepLogger.verification('"Edit Team" pop-up should load successfully');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        await CommonPageHelper.switchToContentFrame(stepLogger);

        stepLogger.stepId(3);
        await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.teamRecords.currentTeam.get(0));
        await ProjectItemPageHelper.clickOnViewReports();

        stepLogger.step('Click on "Resource Commitment"');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.resourceCommitments);
        await ElementHelper.clickUsingJs(CommonPage.ribbonItems.resourceCommitments);
        await PageHelper.switchToDefaultContent();

        stepLogger.step('Verify Reporting Services page will be displayed with below fields');
        stepLogger.step('Verify "Resource"');
        await PageHelper.switchToNewTabIfAvailable(2);
        await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportParameters.resource);
        await expect(await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.reportParameters.resource))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.resource));

        stepLogger.step('Verify "Apply Button"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.applyParameterButton))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.applyButton));

        stepLogger.step('Verify "Refresh"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.refresh))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.refresh));

        stepLogger.step('Verify "First Page"');
        await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.firstPage);
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.firstPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.firstPage));

        stepLogger.step('Verify "Previous Page"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.previousPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.previousPage));

        stepLogger.step('Verify "Next Page"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.nextPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.nextPage));

        stepLogger.step('Verify "Last Page"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.lastPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.lastPage));

        stepLogger.step('Verify "Find Text in Report"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.findTextInReport))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.findTextInReport));

        stepLogger.step('Verify "Next Find"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.findNext))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.findNext));

        stepLogger.step('Verify "Actions dropdwon"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.actionsdropdown))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.actionsDropdown));
    });

    it('View the options on "Resource Available Vs. Planned by Dept" report page" - [743184]', async () => {
        stepLogger.caseId = 743184;
        stepLogger.stepId(1);
        stepLogger.step('Go to Navigation > Projects > Projects');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        stepLogger.step('Mouse over on any Project created as per pre requisites');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.record);
        await ElementHelper.actionHoverOver(CommonPage.record);

        stepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonPage.ellipse);

        stepLogger.step('select "Edit Team" from the options displayed');
        await PageHelper.click(CommonPage.contextMenuOptions.editTeam);

        stepLogger.verification('"Edit Team" pop-up should load successfully');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        await CommonPageHelper.switchToContentFrame(stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "view Reports" drop down displayed on top of "Edit Team" window');
        await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.teamRecords.currentTeam.get(0));
        await ProjectItemPageHelper.clickOnViewReports();

        stepLogger.step('Click on "Resource Available Vs. Planned by Dept"');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.resourceAvailableVsPlannedByDept);
        await ElementHelper.clickUsingJs(CommonPage.ribbonItems.resourceAvailableVsPlannedByDept);
        await PageHelper.switchToDefaultContent();

        stepLogger.step('Verify Reporting Services page will be displayed with below fields');
        stepLogger.step('Verify "Period Start"');
        await PageHelper.switchToNewTabIfAvailable(2);
        await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportParameters.periodStart);
        await expect(await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.reportParameters.periodStart))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.periodStart));

        stepLogger.step('Verify "Period End"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportParameters.periodEnd))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.periodEnd));

        stepLogger.step('Verify "Departments"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportParameters.department))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.department));

        stepLogger.step('Verify "Apply Button"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.applyParameterButton))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.applyButton));

        stepLogger.step('Verify "Refresh"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.refresh))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.refresh));

        stepLogger.step('Verify "First Page"');
        await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.firstPage);
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.firstPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.firstPage));

        stepLogger.step('Verify "Previous Page"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.previousPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.previousPage));

        stepLogger.step('Verify "Next Page"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.nextPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.nextPage));

        stepLogger.step('Verify "Last Page"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.lastPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.lastPage));

        stepLogger.step('Verify "Find Text in Report"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.findTextInReport))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.findTextInReport));

        stepLogger.step('Verify "Next Find"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.findNext))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.findNext));

        stepLogger.step('Verify "Actions dropdwon"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.actionsdropdown))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.actionsDropdown));
    });

    it('View the options on "Resource Requirement" - [743186]', async () => {
        stepLogger.caseId = 743186;
        stepLogger.stepId(1);
        stepLogger.step('Go to Navigation > Projects > Projects');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        stepLogger.step('Mouse over on any Project created as per pre requisites');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.record);
        await ElementHelper.actionHoverOver(CommonPage.record);

        stepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonPage.ellipse);

        stepLogger.step('select "Edit Team" from the options displayed');
        await PageHelper.click(CommonPage.contextMenuOptions.editTeam);

        stepLogger.verification('"Edit Team" pop-up should load successfully');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        await CommonPageHelper.switchToContentFrame(stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "view Reports" drop down displayed on top of "Edit Team" window');
        await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.teamRecords.currentTeam.get(0));
        await ProjectItemPageHelper.clickOnViewReports();

        stepLogger.step('Click on "Resource Requirements"');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.resourceRequirements);
        await ElementHelper.clickUsingJs(CommonPage.ribbonItems.resourceRequirements);
        await PageHelper.switchToDefaultContent();

        stepLogger.step('Verify Reporting Services page will be displayed with below fields');
        stepLogger.step('Verify "Project Name"');
        await PageHelper.switchToNewTabIfAvailable(2);
        await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportParameters.projectName);
        await expect(await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.reportParameters.projectName))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.projectName));

        stepLogger.step('Verify "Refresh"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.refresh))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.refresh));

        stepLogger.step('Verify "First Page"');
        await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.firstPage);
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.firstPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.firstPage));

        stepLogger.step('Verify "Previous Page"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.previousPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.previousPage));

        stepLogger.step('Verify "Next Page"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.nextPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.nextPage));

        stepLogger.step('Verify "Last Page"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.lastPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.lastPage));

        stepLogger.step('Verify "Find Text in Report"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.findTextInReport))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.findTextInReport));

        stepLogger.step('Verify "Next Find"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.findNext))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.findNext));

        stepLogger.step('Verify "Actions dropdwon"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.actionsdropdown))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.actionsDropdown));
    });

    it('View the options on "Resource Work vs. Capacity" report page" - [743188]', async () => {
        stepLogger.caseId = 743188;
        stepLogger.stepId(1);
        stepLogger.step('Go to Navigation > Projects > Projects');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        stepLogger.step('Mouse over on any Project created as per pre requisites');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.record);
        await ElementHelper.actionHoverOver(CommonPage.record);

        stepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonPage.ellipse);

        stepLogger.step('select "Edit Team" from the options displayed');
        await PageHelper.click(CommonPage.contextMenuOptions.editTeam);

        stepLogger.verification('"Edit Team" pop-up should load successfully');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        await CommonPageHelper.switchToContentFrame(stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "view Reports" drop down displayed on top of "Edit Team" window');
        await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.teamRecords.currentTeam.get(0));
        await ProjectItemPageHelper.clickOnViewReports();

        stepLogger.step('Click on "Resource Work vs. Capacity"');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.resourceWorkVsCapacity);
        await ElementHelper.clickUsingJs(CommonPage.ribbonItems.resourceWorkVsCapacity);
        await PageHelper.switchToDefaultContent();

        stepLogger.step('Verify Reporting Services page will be displayed with below fields');
        stepLogger.step('Verify "Resources"');
        await PageHelper.switchToNewTabIfAvailable(2);
        await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportParameters.resources);
        await expect(await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.reportParameters.resources))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.resources));

        stepLogger.step('Verify "Scope"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportParameters.scope))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.scope));

        stepLogger.step('Verify "From"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportParameters.from))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.from));

        stepLogger.step('Verify "To"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportParameters.to))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.to));

        stepLogger.step('Verify "Units"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportParameters.units))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.units));

        stepLogger.step('Verify "Apply Button"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.applyParameterButton))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.applyButton));

        stepLogger.step('Verify "Refresh"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.refresh))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.refresh));

        stepLogger.step('Verify "First Page"');
        await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.firstPage);
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.firstPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.firstPage));

        stepLogger.step('Verify "Previous Page"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.previousPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.previousPage));

        stepLogger.step('Verify "Next Page"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.nextPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.nextPage));

        stepLogger.step('Verify "Last Page"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.lastPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.lastPage));

        stepLogger.step('Verify "Find Text in Report"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.findTextInReport))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.findTextInReport));

        stepLogger.step('Verify "Next Find"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.reportHeaders.findNext))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.findNext));

        stepLogger.step('Verify "Actions dropdwon"');
        await expect(await WaitHelper.waitForElementToBePresent(ProjectItemPage.actionsdropdown))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.actionsDropdown));
    });
});
