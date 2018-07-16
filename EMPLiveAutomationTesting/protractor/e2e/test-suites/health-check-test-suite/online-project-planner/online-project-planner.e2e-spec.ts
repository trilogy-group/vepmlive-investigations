import {PageHelper} from '../../../components/html/page-helper';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../helpers/suite-names';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {ResourcePlannerPageHelper} from '../../../page-objects/pages/resourceplanner-page/resourceplanner-page.helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {WaitHelper} from '../../../components/html/wait-helper';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {ProjectItemPageConstants} from '../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';
import {ProjectItemPageHelper} from '../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {AnchorHelper} from '../../../components/html/anchor-helper';
import {TextboxHelper} from '../../../components/html/textbox-helper';
import {ProjectItemPage} from '../../../page-objects/pages/items-page/project-item/project-item.po';

describe(SuiteNames.healthCheckTestSuite, () => {
    let homePage: HomePage;
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });
    it('Edit Resource plan - [829770]', async () => {
        const stepLogger = new StepLogger(829770);
        stepLogger.stepId(1);
        const hours = '10.00';
        // Step #1 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);
        await CommonPageHelper.resourcePlanViaRibbon(stepLogger);
        stepLogger.verification('"Edit Project" page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ProjectItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.resourcePlanner));
        stepLogger.stepId(1);
        // Add hours for the resource added in the top-grid
        stepLogger.step('Add hours for the resource added in the top-grid');
        await ResourcePlannerPageHelper.addingHours(stepLogger, hours);

    });
    it('Add, Edit and Delete Project - [829527]', async () => {
        const stepLogger = new StepLogger(829527);
        stepLogger.stepId(1);
        // Step #1 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        stepLogger.step('Click on "+ New item" link displayed on top of "Project Center" Page');
        await PageHelper.click(CommonPage.addNewLink);

        // Note - little mismatch, It doesn't open a popup window
        stepLogger.verification('"Project Center - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ProjectItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        stepLogger.stepId(3);
        stepLogger.step('Enter/Select required details in "Project Center - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = ProjectItemPageConstants.inputLabels;
        let projectNameValue = `${labels.projectName} ${uniqueId}`;
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

        stepLogger.stepId(4);
        stepLogger.verification('Navigate to page');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        await CommonPageHelper.searchItemByTitle(projectNameValue,
            ProjectItemPageConstants.columnNames.title,
            stepLogger);

        stepLogger.verification('Newly created Project [Ex: Project 1] displayed in "Project" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(projectNameValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(projectNameValue));
        await CommonPageHelper.editOptionViaRibbon(stepLogger);
        projectNameValue = projectNameValue + 'Edited';
        stepLogger.verification('"Edit Project" page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ProjectItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));
        await TextboxHelper.sendKeys(ProjectItemPage.inputs.projectName, projectNameValue);
        await PageHelper.click(CommonPage.formButtons.save);
        stepLogger.verification('"Project - New Item" window is closed');
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.pageName));
        await CommonPageHelper.searchItemByTitle(projectNameValue,
            ProjectItemPageConstants.columnNames.title,
            stepLogger);
        await CommonPageHelper.deleteOptionViaRibbon(stepLogger);
        stepLogger.verification('Navigate to page');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);
        await CommonPageHelper.searchItemByTitle(projectNameValue,
            ProjectItemPageConstants.columnNames.title,
            stepLogger);
        stepLogger.step('Validating deleted Project  is not  Present');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.noProjecrMsg))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.noDataFound));
         });
});
