import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {ProjectItemPageHelper} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {ProjectItemPage} from '../../../../../page-objects/pages/items-page/project-item/project-item.po';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {ItemSettingsPageHelper} from '../../../../../page-objects/pages/items-page/item-settings/item-settings-page.helper';
import {ItemSettingsPage} from '../../../../../page-objects/pages/items-page/item-settings/item-settings.po';
import {ItemSettingsPageConstants} from '../../../../../page-objects/pages/items-page/item-settings/item-settings-page.constants';
import {EditCostHelper} from '../../../../../page-objects/pages/items-page/project-item/edit-cost-page/edit-cost.helper';

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

    it('Add Project Functionality - [1124170]', async () => {
        StepLogger.caseId = 1124170;

        StepLogger.stepId(1);

        // Step #1 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.stepId(2);
        StepLogger.step('Click on "+ New item" link displayed on top of "Project Center" Page');
        await PageHelper.click(CommonPage.addNewLink);

        // Note - little mismatch, It doesn't open a popup window
        StepLogger.verification('"Project Center - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ProjectItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        StepLogger.stepId(3);
        StepLogger.step('Enter/Select required details in "Project Center - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
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

        StepLogger.stepId(4);
        StepLogger.verification('Navigate to page');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        await CommonPageHelper.searchItemByTitle(projectNameValue,
            ProjectItemPageConstants.columnNames.title,
        );

        StepLogger.verification('Newly created Project [Ex: Project 1] displayed in "Project" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(projectNameValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(projectNameValue));
    });

    it('Edit Project Functionality - [1124173]', async () => {
        StepLogger.caseId = 1124173;
        StepLogger.stepId(1);

        // Step #1 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        await CommonPageHelper.editOptionViaRibbon();

        StepLogger.verification('"Edit Project" page is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ProjectItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        StepLogger.stepId(3);
        StepLogger.step('Enter/Select required details in "Project Center - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = ProjectItemPageConstants.inputLabels;
        const projectNameValue = `${labels.projectName} ${uniqueId}`;
        const projectDescription = `${labels.projectDescription} ${uniqueId}`;
        const benefits = `${labels.benefits} ${uniqueId}`;
        const overallHealthOffTrack = CommonPageConstants.overallHealth.offTrack;
        const projectUpdateManual = CommonPageConstants.projectUpdate.scheduleDriven;

        const projectNameEditable = await ProjectItemPage.inputs.projectName.isPresent();
        if (!projectNameEditable) {
            StepLogger.step('Additional step - Click on cancel button to go back to setting page which is available via list page');
            await PageHelper.click(CommonPage.formButtons.cancel);
            StepLogger.step('Additional step - Click on setting button');
            await PageHelper.click(CommonPage.settingButton);
            StepLogger.step('Additional step - Click on manaage editable field');
            await PageHelper.click(ItemSettingsPage.generalSettings.manageEditableFields);
            StepLogger.step('Additional step - Make project name editable');
            await ItemSettingsPageHelper.configureEditableField(ItemSettingsPageConstants.editableMenuTitles.projectName,
                ItemSettingsPageConstants.editableMenuOptions.onEditItemEditable,
                ItemSettingsPageConstants.editableMenuConfigurationOptions.always);

            await CommonPageHelper.navigateToItemPageUnderNavigation(
                HomePage.navigation.projects.projects,
                CommonPage.pageHeaders.projects.projectsCenter,
                CommonPageConstants.pageHeaders.projects.projectCenter,
            );

            await CommonPageHelper.editOptionViaRibbon();
        }

        await ProjectItemPageHelper.fillForm(
            projectNameValue,
            projectDescription,
            benefits,
            overallHealthOffTrack,
            projectUpdateManual,
        );

        StepLogger.stepId(4);
        StepLogger.verification('Navigate to page');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.verification('Search item by title');
        await CommonPageHelper.searchItemByTitle(projectNameValue, ProjectItemPageConstants.columnNames.title);

        StepLogger.verification('Show columns whatever is required');
        const columnNames = ProjectItemPageConstants.columnNames;
        await CommonPageHelper.showColumns([
            columnNames.title,
            columnNames.notes,
            columnNames.benefits,
            columnNames.overallHealth,
            columnNames.projectUpdate]);

        StepLogger.verification('Click on searched record');
        await PageHelper.click(CommonPage.record);

        StepLogger.verification('Verify record by title');
        const firstTableColumns = [projectNameValue];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(firstTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(firstTableColumns.join(CommonPageConstants.and)));

        StepLogger.verification('Verify by other properties');
        const secondTableColumns = [projectDescription, benefits, overallHealthOffTrack, projectUpdateManual];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(secondTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(secondTableColumns.join(CommonPageConstants.and)));
    });

    it('Add resources under "Current Team" - [743144]', async () => {
        StepLogger.caseId = 743144;
        const uniqueId = PageHelper.getUniqueId();

        StepLogger.step('Create a new project and navigate to build team page');
        await ProjectItemPageHelper.createProjectAndNavigateToBuildTeamPage(uniqueId);

        StepLogger.verification('Verify Resource Pool is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.buildTeamContainers.resourcePool))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.columnNames.resourcePool));

        StepLogger.verification('Verify Current team is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.buildTeamContainers.currentTeam))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.columnNames.currentTeam));

        StepLogger.step('Add resource to Current team and verify');
        await ProjectItemPageHelper.addResourceAndVerifyUserMovedUnderCurrentTeam(uniqueId);
    });

    it('Validate Edit Cost Functionality in Cost Planner - [743932]', async () => {
        StepLogger.caseId = 743932;
        const cost =  4;
        const uniqueId = PageHelper.getUniqueId();

        StepLogger.preCondition('Creating New Project');
        const projectNameValue = await ProjectItemPageHelper.createNewProject(uniqueId);

        StepLogger.stepId(1);
        StepLogger.stepId(2);
        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,

            projectNameValue,
            ProjectItemPageConstants.columnNames.title);

        StepLogger.stepId(3);

        await CommonPageHelper.editCostViaRibbon();

        await CommonPageHelper.switchToFirstContentFrame();

        await EditCostHelper.validateEditCostWebElements();

        StepLogger.stepId(4);
        await EditCostHelper.enterValueInBudgetCost(cost);

        await EditCostHelper.verifyValueInBudgetCost(cost);

        StepLogger.stepId(5);
        await EditCostHelper.clickActualCostsTab();

        await EditCostHelper.enterValueInActualCost(cost);

        await EditCostHelper.verifyValueInActualCost(cost);

        StepLogger.stepId(6);
        await EditCostHelper.clickBenefitsTab();

        await EditCostHelper.enterValueInBenefitTab(cost);

        await EditCostHelper.verifyValueInBenefitCost(cost);

        StepLogger.stepId(7);
        StepLogger.stepId(8);
        StepLogger.stepId(9);
        await EditCostHelper.validateEditCostFunctionality(cost);
    });
});
