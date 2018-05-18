import { SuiteNames } from '../../helpers/suite-names';
import { HomePage } from '../../../page-objects/pages/homepage/home.po';
import { PageHelper } from '../../../components/html/page-helper';
import { StepLogger } from '../../../../core/logger/step-logger';
import { CommonPageHelper } from '../../../page-objects/pages/common/common-page.helper';
import { CommonPage } from '../../../page-objects/pages/common/common.po';
import { CommonPageConstants } from '../../../page-objects/pages/common/common-page.constants';
import { WaitHelper } from '../../../components/html/wait-helper';
import { ValidationsHelper } from '../../../components/misc-utils/validation-helper';
import { ElementHelper } from '../../../components/html/element-helper';
import {browser} from 'protractor';
import { ProjectItemPage } from '../../../page-objects/pages/items-page/project-item/project-item.po';
import { ProjectItemPageConstants } from '../../../page-objects/pages/items-page/project-item/project-item-page.constants';

describe(SuiteNames.regressionTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
    });

    it('View the options on "Resource Capacity Heat map" report page" - [743179]', async () => {
        const stepLogger = new StepLogger(743179);
        stepLogger.stepId(1);
        stepLogger.step('Go to Navigation > Projects > Projects');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        stepLogger.step('Mouse over on any Project created as per pre requisites');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.record);
        await ElementHelper.actionHoverOver(CommonPage.record);

        stepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonPage.ellipse);

        stepLogger.step('select "Edit Team" from the options displayed');
        await PageHelper.click(CommonPage.contextMenuOptions.editTeam);

        stepLogger.verification('"Edit Team" pop-up should load successfully');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
                .toBe(CommonPageConstants.ribbonLabels.editTeam,
                    ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        stepLogger.step('Switch to content frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        stepLogger.stepId(3);
        stepLogger.step('Click on "view Reports" drop down displayed on top of "Edit Team" window');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ProjectItemPage.teamRecords.currentTeam.get(0));
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.viewReports);
        await PageHelper.click(CommonPage.ribbonItems.viewReports);

        stepLogger.step('Click on "Resource Capacity Heat Map"');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.resourceCapacityHeatMap);
        await browser.executeScript('arguments[0].click();', CommonPage.ribbonItems.resourceCapacityHeatMap);
        await PageHelper.switchToDefaultContent();

        stepLogger.step('Verify Reporting Services page will be displayed with below fields');
        stepLogger.step('Verify "Period Start"');
        await PageHelper.switchToNewTabIfAvailable(2);
        await WaitHelper.getInstance().waitForElementToBePresent(ProjectItemPage.reportParameters.periodStart);
        await expect(await WaitHelper.getInstance().waitForElementToBeDisplayed(ProjectItemPage.reportParameters.periodStart))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.periodStart));

        stepLogger.step('Verify "Period End"');
        await expect(await WaitHelper.getInstance().waitForElementToBePresent(ProjectItemPage.reportParameters.periodEnd))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.periodEnd));

        stepLogger.step('Verify "Departments"');
        await expect(await WaitHelper.getInstance().waitForElementToBePresent(ProjectItemPage.reportParameters.department))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportParameter.department));

        stepLogger.step('Verify "Refresh"');
        await expect(await WaitHelper.getInstance().waitForElementToBePresent(ProjectItemPage.reportHeaders.refresh))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.refresh));

        stepLogger.step('Verify "First Page"');
        await WaitHelper.getInstance().waitForElementToBePresent(ProjectItemPage.reportHeaders.firstPage);
        await expect(await WaitHelper.getInstance().waitForElementToBePresent(ProjectItemPage.reportHeaders.firstPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.firstPage));

        stepLogger.step('Verify "Previous Page"');
        await expect(await WaitHelper.getInstance().waitForElementToBePresent(ProjectItemPage.reportHeaders.previousPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.previousPage));

        stepLogger.step('Verify "Next Page"');
        await expect(await WaitHelper.getInstance().waitForElementToBePresent(ProjectItemPage.reportHeaders.nextPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.nextPage));

        stepLogger.step('Verify "Last Page"');
        await expect(await WaitHelper.getInstance().waitForElementToBePresent(ProjectItemPage.reportHeaders.lastPage))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.lastPage));

        stepLogger.step('Verify "Find Text in Report"');
        await expect(await WaitHelper.getInstance().waitForElementToBePresent(ProjectItemPage.reportHeaders.findTextInReport))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.findTextInReport));

        stepLogger.step('Verify "Next Find"');
        await expect(await WaitHelper.getInstance().waitForElementToBePresent(ProjectItemPage.reportHeaders.findNext))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.reportHeaders.findNext));

        stepLogger.step('Verify "Actions dropdwon"');
        await expect(await WaitHelper.getInstance().waitForElementToBePresent(ProjectItemPage.actionsdropdown))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.actionsDropdown));
    });
});
