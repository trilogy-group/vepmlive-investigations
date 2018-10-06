import {PageHelper} from '../../../components/html/page-helper';
import {ResourcesPageHelper} from '../../../page-objects/pages/navigation/resources/resources-page.helper';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';

describe(SuiteNames.healthCheckTestSuite, () => {
    let loginPage: LoginPage;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    it('Add  resource - [829512]', async () => {
        StepLogger.caseId = 829512;
        StepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.resources,
            CommonPage.pageHeaders.projects.resources,
            CommonPageConstants.pageHeaders.projects.resources,
        );
        StepLogger.stepId(2);
        await ResourcesPageHelper.addResourceAndValidateIt();
    });
});
