import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {ReportsItemPage} from '../../../../../page-objects/pages/items-page/reports-item/reports-item.po';
import {ReportsItemPageConstants} from '../../../../../page-objects/pages/items-page/reports-item/reports-item-page.constants';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
    });

    it('View Reports Functionality - [1124270]', async () => {
        const stepLogger = new StepLogger(1124270);
        const projectReportListItem = ReportsItemPageConstants.reportListItems.projects;

        stepLogger.step('Navigate to Reports page');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.reports,
            ReportsItemPage.businessIntelligenceCenter,
            ReportsItemPageConstants.businessIntelligenceCenter,
            stepLogger);

        stepLogger.verification('Verify EPM Live Analytics option is displayed');
        await expect(await PageHelper.isElementDisplayed(ReportsItemPage.reportsLandingMenu.epmLiveAnalytics))
            .toBe(true,
                ValidationsHelper.getMenuDisplayedValidation(ReportsItemPageConstants.landingPageMenu.epmLiveAnalytics));

        stepLogger.verification('Verify Classic Reporting option is displayed');
        await expect(await PageHelper.isElementDisplayed(ReportsItemPage.reportsLandingMenu.classicReporting))
            .toBe(true,
                ValidationsHelper.getMenuDisplayedValidation(ReportsItemPageConstants.landingPageMenu.classicReporting));

        stepLogger.step('Click on Classic Reporting option');
        await PageHelper.click(ReportsItemPage.reportsLandingMenu.classicReporting);

        stepLogger.verification(`Classic Reporting page is displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.reports))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.reports));

        stepLogger.step('Click on Projects and expand the list');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(
            await ReportsItemPage.expandReportListItem(ReportsItemPageConstants.reportListItems.projects.projects));
        await PageHelper.click(
            await ReportsItemPage.expandReportListItem(ReportsItemPageConstants.reportListItems.projects.projects));

        stepLogger.verification(`Project health link is displayed`);
        await expect(await PageHelper.isElementDisplayed(ReportsItemPage.reportListItems.project.projectHealth))
            .toBe(true,
                ValidationsHelper.getButtonDisplayedValidation(projectReportListItem.projectHealth));

        stepLogger.step('Click on Projects health option');
        await PageHelper.click(ReportsItemPage.reportListItems.project.projectHealth);

        stepLogger.verification(`Project health view is displayed`);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(projectReportListItem.projectHealth,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(projectReportListItem.projectHealth));

        stepLogger.step('Click on close button');
        await WaitHelper.getInstance().waitForElementToBeClickable(CommonPage.closeButton);
        await PageHelper.click(CommonPage.closeButton);

        stepLogger.verification(`Classic Reporting page is displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.reports))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.reports));
    });
});
