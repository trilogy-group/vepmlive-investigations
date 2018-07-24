import {PageHelper} from '../../../components/html/page-helper';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';

describe(SuiteNames.healthCheckTestSuite, () => {
     fit('Valid License for viewing EPM Live site- [743132]', async () => {
        let loginPage: LoginPage;
        const stepLogger = new StepLogger(743132);
        await PageHelper.maximizeWindow();
        stepLogger.stepId(1);
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();

        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
             HomePage.navigation.projects.projects,
             CommonPage.pageHeaders.projects.projectsCenter,
             CommonPageConstants.pageHeaders.projects.projectCenter,
             stepLogger);
 });
});
