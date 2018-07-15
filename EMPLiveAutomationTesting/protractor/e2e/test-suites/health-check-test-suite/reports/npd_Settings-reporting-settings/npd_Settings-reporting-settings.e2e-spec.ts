import {SuiteNames} from '../../../helpers/suite-names';
import {HomePage} from '../../../../page-objects/pages/homepage/home.po';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {ReportingSettingsPageHelper} from '../../../../page-objects/pages/settings/enterprise-reporting/reporting-settings/reporting-settings-page.helper';

describe(SuiteNames.healthCheckTestSuite, () => {
    let homePage: HomePage;
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });
    it('Run Refresh Schedule - [82979]', async () => {
        const stepLogger = new StepLogger(82979);
        stepLogger.stepId(1);
         await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);
        await ReportingSettingsPageHelper.navigateTo(stepLogger);
        stepLogger.stepId(2);
        // Run Schedule
        await ReportingSettingsPageHelper.runSchedule(stepLogger);
    });

});