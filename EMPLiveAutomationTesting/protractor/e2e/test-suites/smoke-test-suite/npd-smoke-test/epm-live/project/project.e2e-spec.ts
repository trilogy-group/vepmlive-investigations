// tslint:disable-next-line:max-line-length
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/create-new-page/new-item/project-item/project-item-page.constants';
import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {CommonItemPage} from '../../../../../page-objects/pages/create-new-page/new-item/common-item/common-item.po';
import {CommonViewPage} from '../../../../../page-objects/pages/homepage/common-view-page/common-view.po';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {CommonViewPageHelper} from '../../../../../page-objects/pages/homepage/common-view-page/common-view-page.helper';
import {CommonViewPageConstants} from '../../../../../page-objects/pages/homepage/common-view-page/common-view-page.constants';
import {ProjectItemPage} from '../../../../../page-objects/pages/create-new-page/new-item/project-item/project-item.po';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {ProjectItemPageHelper} from '../../../../../page-objects/pages/create-new-page/new-item/project-item/project-item-page.helper';
// tslint:disable-next-line:max-line-length
import {ProjectItemPageValidations} from '../../../../../page-objects/pages/create-new-page/new-item/project-item/project-item-page.validations';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';

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
        await CommonViewPageHelper.navigateToItemPage(
            HomePage.navigation.projects.projects,
            CommonViewPage.pageHeaders.projects.projectsCenter,
            CommonViewPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        stepLogger.step('Click on "+ New item" link displayed on top of "Project Center" Page');
        await PageHelper.click(CommonPage.addNewLink);

        // Note - little mismatch, It doesn't open a popup window
        stepLogger.verification('"Project Center - New Item" window is displayed');
        await expect(await CommonItemPage.titles.first().getText())
            .toBe(ProjectItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.pageName));

        stepLogger.stepId(3);
        stepLogger.step('Enter/Select required details in "Project Center - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = ProjectItemPageConstants.inputLabels;
        const projectNameValue = `${labels.projectName} ${uniqueId}`;
        const projectDescription = `${labels.projectDescription} ${uniqueId}`;
        const benefits = `${labels.benefits} ${uniqueId}`;
        const overallHealthOnTrack = ProjectItemPageConstants.overallHealth.onTrack;
        const projectUpdateManual = ProjectItemPageConstants.projectUpdate.manual;

        await ProjectItemPageHelper.fillForm(
            projectNameValue,
            projectDescription,
            benefits,
            overallHealthOnTrack,
            projectUpdateManual,
            stepLogger);

        stepLogger.stepId(4);
        stepLogger.verification('Navigate to page');
        await CommonViewPageHelper.navigateToItemPage(
            HomePage.navigation.projects.projects,
            CommonViewPage.pageHeaders.projects.projectsCenter,
            CommonViewPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        await CommonViewPageHelper.searchItemByTitle(projectNameValue, ProjectItemPageConstants.columnNames.title, stepLogger);

        stepLogger.verification('Newly created Project [Ex: Project 1] displayed in "Project" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByExactTextXPath(projectNameValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(projectNameValue));
    });

    it('Edit Project Functionality - [1124173]', async () => {
        const stepLogger = new StepLogger(1124275);
        stepLogger.stepId(1);

        // Step #1 Inside this function
        await CommonViewPageHelper.navigateToItemPage(
            HomePage.navigation.projects.projects,
            CommonViewPage.pageHeaders.projects.projectsCenter,
            CommonViewPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        stepLogger.step('Select the check box for project created');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonViewPage.record);
        await PageHelper.click(CommonViewPage.record);

        stepLogger.step('Click on ITEMS on ribbon');
        await PageHelper.click(CommonItemPage.ribbonTitles.items);

        stepLogger.step('Select "Edit Item" from the options displayed');
        await PageHelper.click(CommonItemPage.ribbonItems.editItem);

        stepLogger.verification('"Edit Project" page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonItemPage.title);
        await expect(await CommonItemPage.title.getText())
            .toBe(ProjectItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));

        stepLogger.stepId(3);
        stepLogger.step('Enter/Select required details in "Project Center - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = ProjectItemPageConstants.inputLabels;
        const projectNameValue = `${labels.projectName} ${uniqueId}`;
        const projectDescription = `${labels.projectDescription} ${uniqueId}`;
        const benefits = `${labels.benefits} ${uniqueId}`;
        const overallHealthOnTrack = ProjectItemPageConstants.overallHealth.offTrack;
        const projectUpdateManual = ProjectItemPageConstants.projectUpdate.scheduleDriven;

        await expect(await ProjectItemPage.inputs.projectName.isPresent())
            .toBe(true,
                ProjectItemPageValidations.projectNameShouldBeEditable);

        await ProjectItemPageHelper.fillForm(
            projectNameValue,
            projectDescription,
            benefits,
            overallHealthOnTrack,
            projectUpdateManual,
            stepLogger);

        stepLogger.stepId(4);
        stepLogger.verification('Navigate to page');
        await CommonViewPageHelper.navigateToItemPage(
            HomePage.navigation.projects.projects,
            CommonViewPage.pageHeaders.projects.projectsCenter,
            CommonViewPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.verification('Search item by title');
        await CommonViewPageHelper.searchItemByTitle(projectNameValue, ProjectItemPageConstants.columnNames.title, stepLogger);

        stepLogger.verification('Show columns whatever is required');
        const columnNames = ProjectItemPageConstants.columnNames;
        await CommonViewPageHelper.showColumns([
            columnNames.title,
            columnNames.notes,
            columnNames.benefits,
            columnNames.overallHealth,
            columnNames.projectUpdate]);

        stepLogger.verification('Click on searched record');
        await PageHelper.click(CommonViewPage.record);

        stepLogger.verification('Verify record by title');
        const firstTableColumns = [projectNameValue];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(firstTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(firstTableColumns.join(CommonPageConstants.and)));

        stepLogger.verification('Verify by other properties');
        const secondTableColumns = [projectDescription, benefits, overallHealthOnTrack, projectUpdateManual];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(secondTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(secondTableColumns.join(CommonPageConstants.and)));

    });
});
