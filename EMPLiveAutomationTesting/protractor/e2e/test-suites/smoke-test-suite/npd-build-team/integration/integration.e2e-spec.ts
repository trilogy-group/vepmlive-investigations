import {SuiteNames} from '../../../helpers/suite-names';
import {HomePage} from '../../../../page-objects/pages/homepage/home.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {ProjectItemPage} from '../../../../page-objects/pages/items-page/project-item/project-item.po';
import {ProjectItemPageConstants} from '../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {ProjectItemPageHelper} from '../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {ElementHelper} from '../../../../components/html/element-helper';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {ProjectItemPageValidations} from '../../../../page-objects/pages/items-page/project-item/project-item-page.validations';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';

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

    it('View the Build Team-Current team members in Project Planner - [743198]', async () => {
        StepLogger.caseId = 743198;
        const uniqueId = PageHelper.getUniqueId();
        StepLogger.stepId(1);
        StepLogger.step('Select "Navigation" icon  from left side menu');
        StepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.step('Select check-box for any Project');
        await PageHelper.click(CommonPage.record);

        StepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        StepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        StepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        await CommonPageHelper.switchToContentFrame();

        StepLogger.step('Select check-box for any of the resources displayed in "Resource Pool" (Right side)');
        await PageHelper.click(ProjectItemPage.teamRecords.resourcePool.first());
        const selectedResourcePoolResourceName = await ProjectItemPage.teamRecordsName.resourcePool.first().getText();

        StepLogger.step('Click on "< Add" button');
        await PageHelper.click(ProjectItemPage.teamChangeButtons.add);

        StepLogger.verification('Selected resource [Ex: Generic Resource 1] is added to "Current Team" (Left Side) grid');
        await expect(await ProjectItemPageHelper.checkResourceAddedInCurrentTeam(selectedResourcePoolResourceName))
            .toBe(true,
                ProjectItemPageValidations.getResourceAddedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        StepLogger.stepId(2);
        StepLogger.step('Click on "Save & Close" button in "Edit Team" window');
        await WaitHelper.waitForElementToBeClickable(CommonPage.ribbonItems.saveAndClose);
        await PageHelper.click(CommonPage.ribbonItems.saveAndClose);

        StepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        StepLogger.stepId(3);
        StepLogger.step('Navigate to Project Center');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.stepId(4);
        StepLogger.step('Mouse hover on any Project created as per pre requisites');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.record);
        await ElementHelper.actionHoverOver(CommonPage.record);

        StepLogger.step('Click on the Ellipses button (...)');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ellipse);
        await PageHelper.click(CommonPage.ellipse);

        await WaitHelper.waitForElementToBeDisplayed(CommonPage.contextMenuOptions.editPlan);
        StepLogger.step('select "Edit Plan" from the options displayed');
        await PageHelper.click(CommonPage.contextMenuOptions.editPlan);

        StepLogger.stepId(5);
        StepLogger.step('click on Project Planner');

        // If user has default planner selected then then selectPlanner PopUp won't appear
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);

        StepLogger.verification('Observe that the "Project Planner" is displayed');
        StepLogger.verification('"Project Planner" window is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        StepLogger.stepId(6);
        StepLogger.step('Enter New Task in the "Add a Task"');
        await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.newTask);
        await TextboxHelper.sendKeys(ProjectItemPage.newTask, uniqueId, true);

        StepLogger.step('click on "Edit Team" button');
        await WaitHelper.waitForElementToBeClickable(CommonPage.ribbonItems.editTeamProjectPlanner);
        await PageHelper.click(CommonPage.ribbonItems.editTeamProjectPlanner);

        StepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await CommonPageHelper.switchToContentFrame();

        StepLogger.verification('Observe that the newly added "Resource" is displayed');
        await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.teamRecords.currentTeam.first());
        await expect(await ProjectItemPageHelper.checkResourceAddedInCurrentTeam(selectedResourcePoolResourceName))
            .toBe(true,
                ProjectItemPageValidations.getResourceAddedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));
    });

    xit('View the options on "Resource Capacity Heat map" report page" - 743179 - Disabled Duplication', async () => {
        StepLogger.caseId = 743179;
        StepLogger.stepId(1);
        StepLogger.step('Go to Navigation > Projects > Projects');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.stepId(2);
        StepLogger.step('Mouse over on any Project created as per pre requisites');
        await PageHelper.isElementDisplayed(CommonPage.record);
        await ElementHelper.actionHoverOver(CommonPage.record);

        StepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonPage.ellipse);

        StepLogger.step('select "Edit Team" from the options displayed');
        await PageHelper.click(CommonPage.contextMenuOptions.editTeam);

        StepLogger.verification('"Edit Team" pop-up should load successfully');
        await PageHelper.isElementDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));
        await CommonPageHelper.switchToContentFrame();

        StepLogger.stepId(3);
        StepLogger.step('Click on "view Reports" drop down displayed on top of "Edit Team" window');
        await PageHelper.isElementDisplayed(ProjectItemPage.teamRecords.currentTeam.get(0));
        await ProjectItemPageHelper.clickOnViewReports();

        StepLogger.step('Click on "Resource Capacity Heat Map"');
        await PageHelper.isElementDisplayed(CommonPage.ribbonItems.resourceCapacityHeatMap);
        await ElementHelper.clickUsingJs(CommonPage.ribbonItems.resourceCapacityHeatMap);
        await PageHelper.switchToDefaultContent();

        StepLogger.step('Verify Reporting Services page will be displayed with below fields');
        StepLogger.step('Verify "Actions Dropdown"');
        await PageHelper.switchToNewTabIfAvailable(1);
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.actionsdropdown))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.actionsDropdown));

        StepLogger.step('Verify "Refresh"');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.reportHeaders.refresh))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.refresh));

        StepLogger.step('Verify "First Page"');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.reportHeaders.firstPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.firstPage));

        StepLogger.step('Verify "Previous Page"');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.reportHeaders.previousPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.previousPage));

        StepLogger.step('Verify "Next Page"');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.reportHeaders.nextPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.nextPage));

        StepLogger.step('Verify "Last Page"');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.reportHeaders.lastPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.lastPage));

        StepLogger.step('Verify "Period Start"');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.reportParameters.periodStart))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.periodStart));

        StepLogger.step('Verify "Period End"');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.reportParameters.periodEnd))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.periodEnd));

        StepLogger.step('Verify "Departments"');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.reportParameters.department))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.department));
    });
});
