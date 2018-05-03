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

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
    });

    it('View Reports Functionality - [1124270]', async () => {
        const stepLogger = new StepLogger(1124270);

        stepLogger.step('Navigate to Reports page');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.reports,
            ReportsItemPage.reportsLandingPage.businessIntelligenceCenter,
            ReportsItemPageConstants.reportsLandingPage.businessIntelligenceCenter,
            stepLogger);

        stepLogger.verification('Verify EPM Live Analytics option is displayed');
        await expect(await PageHelper.isElementDisplayed(ReportsItemPage.reportsLandingPage.epmLiveAnalytics))
            .toBe(true,
                ValidationsHelper.getMenuDisplayedValidation(ReportsItemPageConstants.reportsLandingPage.epmLiveAnalytics));

        stepLogger.verification('Verify Classic Reporting option is displayed');
        await expect(await PageHelper.isElementDisplayed(ReportsItemPage.reportsLandingPage.classicReporting))
            .toBe(true,
                ValidationsHelper.getMenuDisplayedValidation(ReportsItemPageConstants.reportsLandingPage.classicReporting));

        stepLogger.step('Click on Classic Reporting option');
        await PageHelper.click(ReportsItemPage.reportsLandingPage.classicReporting);
        stepLogger.verification(`Classic Reporting page is displayed`);
        await expect(await PageHelper.isElementDisplayed(ReportsItemPage.reportsLandingPage.reportsHeader))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(ReportsItemPageConstants.reportsHeader));

        stepLogger.step('Click on Projects and expand the list');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ReportsItemPage.classicReporting.expandProjectsList);
        await PageHelper.click(ReportsItemPage.classicReporting.expandProjectsList);

        stepLogger.verification(`Project health link is displayed`);
        await expect(await PageHelper.isElementDisplayed(ReportsItemPage.classicReporting.projectHealthOption))
            .toBe(true,
                ValidationsHelper.getButtonDisplayedValidation(ReportsItemPageConstants.classicReportingPage.projectHealth));

        stepLogger.step('Click on Projects health option');
        await PageHelper.click(ReportsItemPage.classicReporting.projectHealthOption);

        stepLogger.verification(`Project health view is displayed`);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ReportsItemPage.classicReporting.projectHealthHeader);
        await expect(await PageHelper.isElementDisplayed(ReportsItemPage.classicReporting.projectHealthHeader))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(ReportsItemPageConstants.classicReportingPage.projectHealth));

        stepLogger.step('Waiting for page to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(ReportsItemPageConstants.classicReportingPage.projectHealth,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ReportsItemPageConstants.classicReportingPage.projectHealth));

        stepLogger.step('Click on close button');
        await WaitHelper.getInstance().waitForElementToBeClickable(ReportsItemPage.classicReporting.closeButton);
        await PageHelper.click(ReportsItemPage.classicReporting.closeButton);

        stepLogger.verification(`Classic Reporting page is displayed`);
        await expect(await PageHelper.isElementDisplayed(ReportsItemPage.reportsLandingPage.reportsHeader))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(ReportsItemPageConstants.reportsHeader));
    });
});
