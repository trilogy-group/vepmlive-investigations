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
import {ProjectItemPageValidations} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.validations';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
    });

    it('Add Project Functionality - [1124170]', async () => {
        const stepLogger = new StepLogger(1124170);

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
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextXPathInsideGrid(projectNameValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(projectNameValue));
    });

    it('Edit Project Functionality - [1124173]', async () => {
        const stepLogger = new StepLogger(1124173);
        stepLogger.stepId(1);

        // Step #1 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        await CommonPageHelper.editOptionViaRibbon(stepLogger);

        stepLogger.verification('"Edit Project" page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ProjectItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        stepLogger.stepId(3);
        stepLogger.step('Enter/Select required details in "Project Center - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = ProjectItemPageConstants.inputLabels;
        const projectNameValue = `${labels.projectName} ${uniqueId}`;
        const projectDescription = `${labels.projectDescription} ${uniqueId}`;
        const benefits = `${labels.benefits} ${uniqueId}`;
        const overallHealthOffTrack = CommonPageConstants.overallHealth.offTrack;
        const projectUpdateManual = CommonPageConstants.projectUpdate.scheduleDriven;

        await expect(await ProjectItemPage.inputs.projectName.isPresent())
            .toBe(true,
                ProjectItemPageValidations.projectNameShouldBeEditable);

        await ProjectItemPageHelper.fillForm(
            projectNameValue,
            projectDescription,
            benefits,
            overallHealthOffTrack,
            projectUpdateManual,
            stepLogger);

        stepLogger.stepId(4);
        stepLogger.verification('Navigate to page');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.verification('Search item by title');
        await CommonPageHelper.searchItemByTitle(projectNameValue, ProjectItemPageConstants.columnNames.title, stepLogger);

        stepLogger.verification('Show columns whatever is required');
        const columnNames = ProjectItemPageConstants.columnNames;
        await CommonPageHelper.showColumns([
            columnNames.title,
            columnNames.notes,
            columnNames.benefits,
            columnNames.overallHealth,
            columnNames.projectUpdate]);

        stepLogger.verification('Click on searched record');
        await PageHelper.click(CommonPage.record);

        stepLogger.verification('Verify record by title');
        const firstTableColumns = [projectNameValue];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(firstTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(firstTableColumns.join(CommonPageConstants.and)));

        stepLogger.verification('Verify by other properties');
        const secondTableColumns = [projectDescription, benefits, overallHealthOffTrack, projectUpdateManual];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(secondTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(secondTableColumns.join(CommonPageConstants.and)));
    });
});
