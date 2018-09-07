import {PageHelper} from '../../../components/html/page-helper';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';
import {StepLogger} from '../../../../core/logger/step-logger';

describe(SuiteNames.healthCheckTestSuite, () => {
    let stepLogger: StepLogger;
    beforeEach(async () => {
        stepLogger = new StepLogger();
        await PageHelper.maximizeWindow();
        await new LoginPage().goToAndLogin();
    });
    it('Valid License for viewing EPM Live site- [743132]', async () => {
        stepLogger.caseId = 743132;
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);
    });
});
