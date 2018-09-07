import {browser} from 'protractor';
import {SuiteNames} from '../../../../../helpers/suite-names';
import {LoginPage} from '../../../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../../page-objects/pages/common/common.po';
import {SettingsPage} from '../../../../../../page-objects/pages/settings/settings.po';
import {Constants} from '../../../../../../components/misc-utils/constants';
import {ValidationsHelper} from '../../../../../../components/misc-utils/validation-helper';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
// tslint:disable-next-line:max-line-length
import {ReportingSettingsPage} from '../../../../../../page-objects/pages/settings/enterprise-reporting/reporting-settings/reporting-settings.po';
// tslint:disable-next-line:max-line-length
import {ReportManagerPage} from '../../../../../../page-objects/pages/settings/enterprise-reporting/reporting-settings/report-manager/report-manager.po';
// tslint:disable-next-line:max-line-length
import {ReportManagerPageConstants} from '../../../../../../page-objects/pages/settings/enterprise-reporting/reporting-settings/report-manager/report-manager-page.constants';
// tslint:disable-next-line:max-line-length
import {ReportManagerPageValidation} from '../../../../../../page-objects/pages/settings/enterprise-reporting/reporting-settings/report-manager/report-manager-page.validation';
// tslint:disable-next-line:max-line-length
import {ReportingSettingsPageConstants} from '../../../../../../page-objects/pages/settings/enterprise-reporting/reporting-settings/reporting-settings-page.constants';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    let stepLogger: StepLogger;
    beforeEach(async () => {
        stepLogger = new StepLogger();
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Run Refresh Schedule Functionality - [1124280]', async () => {
        stepLogger.caseId = 1124280;
        stepLogger.stepId(1);
        stepLogger.step('Click on "Main Gear Settings" icon  displayed in left bottom corner');
        await PageHelper.click(CommonPage.sidebarMenus.settings);

        const enterpriseReportingMenus = SettingsPage.menuItems.enterpriseReporting;

        stepLogger.verification('Various Settings Options displayed');
        await expect(await PageHelper.isElementDisplayed(enterpriseReportingMenus.rootMenu))
            .toBe(true,
                '');

        stepLogger.stepId(2);
        stepLogger.step('Expand "Enterprise Reporting" node');
        await PageHelper.click(enterpriseReportingMenus.rootMenu);

        stepLogger.verification('"Enterprise Reporting" node is expanded and sub options displayed below the node');
        await expect(await PageHelper.isElementDisplayed(enterpriseReportingMenus.childMenus.classicReports))
            .toBe(true,
                '');

        stepLogger.stepId(3);
        stepLogger.step('Click on "Reporting Settings" sub node displayed under "Enterprise Reporting" node');
        await PageHelper.click(SettingsPage.menuItems.enterpriseReporting.childMenus.reportingSettings);

        stepLogger.verification('"Mapped Lists" page is displayed');
        await expect((await CommonPage.title.getText()).trim())
            .toBe(ReportingSettingsPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(ReportingSettingsPageConstants.pageName));

        stepLogger.stepId(4);
        stepLogger.step(`Click on 'Settings' link displayed on top of the page`);
        await PageHelper.click(ReportingSettingsPage.topMenus.settings.menu);
        stepLogger.step(`Select 'Refresh Schedule' from the options displayed`);
        await PageHelper.click(ReportingSettingsPage.topMenus.settings.childMenu.refreshSchedule);

        stepLogger.verification('"Report Manager" Page is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect((await CommonPage.title.getText()).trim())
            .toBe(ReportManagerPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(ReportManagerPageConstants.pageName));

        stepLogger.stepId(5);
        stepLogger.step('Click on "Run Now" button');
        await PageHelper.click(ReportManagerPage.formControls.runNow);

        stepLogger.step('Refresh the page using browser Refresh button');
        const lastRunLabel = ReportManagerPage.formControls.lastRun;
        const lastRunValue = await lastRunLabel.getText();
        let maxAttempts = 0;
        while ((await lastRunLabel.getText()).trim() === Constants.EMPTY_STRING && maxAttempts < 10) {
            await browser.sleep(PageHelper.timeout.s);
            maxAttempts++;
            await browser.refresh();
        }

        stepLogger.verification('Last Result - commonly "No Errors" displayed (Note: Can display other results]');
        await expect((await ReportManagerPage.formControls.messages.getText()).trim())
            .toBe(ReportManagerPageConstants.noErrorMessage,
                ReportManagerPageValidation.lastResultValidation);

        stepLogger.verification(`Log - 'View Log' link displayed`);
        await expect(await PageHelper.isElementDisplayed(ReportManagerPage.formControls.viewLog))
            .toBe(true, ReportManagerPageValidation.logValidation);

        stepLogger.verification('Last Run - the date and time stamp display the date and the time the report is run');
        await expect((await lastRunLabel.getText()).trim())
            .not.toBe(lastRunValue, ReportManagerPageValidation.lastRunValidation);

    });
});
