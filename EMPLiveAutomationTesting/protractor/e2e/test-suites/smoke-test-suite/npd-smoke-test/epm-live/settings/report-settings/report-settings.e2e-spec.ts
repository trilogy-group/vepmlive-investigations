import {SuiteNames} from '../../../../../helpers/suite-names';
import {LoginPage} from '../../../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../../core/logger/step-logger';

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

    /* #UNSTABLE
    it('Run Refresh Schedule Functionality - [1124280]', async () => {
        StepLogger.caseId = 1124280;
        StepLogger.stepId(1);
        StepLogger.step('Click on "Main Gear Settings" icon  displayed in left bottom corner');
        await PageHelper.click(CommonPage.sidebarMenus.settings);

        const enterpriseReportingMenus = SettingsPage.menuItems.enterpriseReporting;

        StepLogger.verification('Various Settings Options displayed');
        await expect(await PageHelper.isElementDisplayed(enterpriseReportingMenus.rootMenu))
            .toBe(true,
                '');

        StepLogger.stepId(2);
        StepLogger.step('Expand "Enterprise Reporting" node');
        await PageHelper.click(enterpriseReportingMenus.rootMenu);

        StepLogger.verification('"Enterprise Reporting" node is expanded and sub options displayed below the node');
        await expect(await PageHelper.isElementDisplayed(enterpriseReportingMenus.childMenus.classicReports))
            .toBe(true,
                '');

        StepLogger.stepId(3);
        StepLogger.step('Click on "Reporting Settings" sub node displayed under "Enterprise Reporting" node');
        await PageHelper.click(SettingsPage.menuItems.enterpriseReporting.childMenus.reportingSettings);

        StepLogger.verification('"Mapped Lists" page is displayed');
        await ExpectationHelper.verifyText(CommonPage.title, ReportingSettingsPageConstants.pageName, ReportingSettingsPageConstants.pageName);

        StepLogger.stepId(4);
        StepLogger.step(`Click on 'Settings' link displayed on top of the page`);
        await PageHelper.click(ReportingSettingsPage.topMenus.settings.menu);
        StepLogger.step(`Select 'Refresh Schedule' from the options displayed`);
        await PageHelper.click(ReportingSettingsPage.topMenus.settings.childMenu.refreshSchedule);

        StepLogger.verification('"Report Manager" Page is displayed');
        await ExpectationHelper.verifyText(CommonPage.title, ReportManagerPageConstants.pageName, ReportManagerPageConstants.pageName);

        StepLogger.stepId(5);
        StepLogger.step('Click on "Run Now" button');
        await PageHelper.click(ReportManagerPage.formControls.runNow);

        StepLogger.step('Refresh the page using browser Refresh button');
        const lastRunLabel = ReportManagerPage.formControls.lastRun;
        const lastRunValue = await ElementHelper.getText(lastRunLabel);
        let maxAttempts = 0;
        while ((await ElementHelper.getText(lastRunLabel) === Constants.EMPTY_STRING && maxAttempts++ < 10)) {
            await WaitHelper.staticWait(PageHelper.timeout.l);
            await PageHelper.refreshPage();
        }

        StepLogger.verification('Last Result - commonly "No Errors" displayed (Note: Can display other results]');
        await ExpectationHelper.verifyText(ReportManagerPage.formControls.messages,
            ReportManagerPageValidation.lastResultValidation, ReportManagerPageConstants.noErrorMessage);

        StepLogger.verification(`Log - 'View Log' link displayed`);
        await expect(await PageHelper.isElementDisplayed(ReportManagerPage.formControls.viewLog))
            .toBe(true, ReportManagerPageValidation.logValidation);

        StepLogger.verification('Last Run - the date and time stamp display the date and the time the report is run');
        await expect((await lastRunLabel.getText()).trim())
            .not.toBe(lastRunValue, ReportManagerPageValidation.lastRunValidation);
    });
    */
});
