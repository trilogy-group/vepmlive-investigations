import {SuiteNames} from '../../../../../helpers/suite-names';
import {LoginPage} from '../../../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../../page-objects/pages/common/common.po';
import {SettingsPage} from '../../../../../../page-objects/pages/settings/settings.po';
import {AdvancedReportsPage} from '../../../../../../page-objects/pages/settings/enterprise-reporting/advanced-reports/advanced-reports.po';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Run Refresh Schedule Functionality - [1124280]', async () => {
        const stepLogger = new StepLogger(1124280);
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
        await expect(await PageHelper.isElementDisplayed(enterpriseReportingMenus.childMenus.classicReports))
            .toBe(true,
                '');


        stepLogger.stepId(4);
        stepLogger.step(`Click on 'Settings' link displayed on top of the page`);
        await PageHelper.click(AdvancedReportsPage.topMenus.settings.menu);
        stepLogger.step(`Select 'Refresh Schedule' from the options displayed`);
        await PageHelper.click(AdvancedReportsPage.topMenus.settings.childMenu.refreshSchedule);

        stepLogger.verification('\'Report Manager\' Page is displayed');

    });
});
