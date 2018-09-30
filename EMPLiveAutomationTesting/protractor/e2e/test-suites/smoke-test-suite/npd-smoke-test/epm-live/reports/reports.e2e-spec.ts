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
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';

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

    it('View Reports Functionality - [1124270]', async () => {
        StepLogger.caseId = 1124270;
        const projectReportListConstant = ReportsItemPageConstants.reportListItems.projects;
        const projectReportListElement = ReportsItemPage.reportListItems.project;
        const projectCommonPageConstant = CommonPage.pageHeaders.projects;
        const projectCommonPageElement = CommonPageConstants.pageHeaders.projects;

        StepLogger.step('Navigate to Reports page');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.reports,
            ReportsItemPage.businessIntelligenceCenter,
            ReportsItemPageConstants.businessIntelligenceCenter,
        );

        StepLogger.verification('Verify EPM Live Analytics option is displayed');
        await expect(await PageHelper.isElementDisplayed(ReportsItemPage.reportsLandingMenu.epmLiveAnalytics))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(ReportsItemPageConstants.landingPageMenu.epmLiveAnalytics));

        StepLogger.verification('Verify Classic Reporting option is displayed');
        await expect(await PageHelper.isElementDisplayed(ReportsItemPage.reportsLandingMenu.classicReporting))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(ReportsItemPageConstants.landingPageMenu.classicReporting));

        StepLogger.step('Click on Classic Reporting option');
        await PageHelper.click(ReportsItemPage.reportsLandingMenu.classicReporting);

        StepLogger.verification(`Classic Reporting page is displayed`);
        await expect(await PageHelper.isElementDisplayed(projectCommonPageConstant.reports))
            .toBe(true, ValidationsHelper.getPageDisplayedValidation(projectCommonPageElement.reports));

        StepLogger.step('Click on Projects and expand the list');
        await WaitHelper.waitForElementToBeDisplayed(
            await ReportsItemPage.expandReportListItem(projectReportListConstant.projects));
        await PageHelper.click(await ReportsItemPage.expandReportListItem(projectReportListConstant.projects));

        StepLogger.verification(`Project health link is displayed`);
        await expect(await PageHelper.isElementDisplayed(projectReportListElement.projectHealth))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(projectReportListConstant.projectHealth));

        StepLogger.step('Click on Projects health option');
        await PageHelper.click(projectReportListElement.projectHealth);

        StepLogger.verification(`Project health view is displayed`);
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(projectReportListConstant.projectHealth,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(projectReportListConstant.projectHealth));

        StepLogger.step('Click on close button');
        await WaitHelper.waitForElementToBeClickable(CommonPage.closeButton);
        await PageHelper.click(CommonPage.closeButton);

        StepLogger.verification(`Classic Reporting page is displayed`);
        await expect(await PageHelper.isElementDisplayed(projectCommonPageConstant.reports))
            .toBe(true, ValidationsHelper.getPageDisplayedValidation(projectCommonPageElement.reports));
    });
});
