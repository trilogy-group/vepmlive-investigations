import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {AnchorHelper} from '../../../components/html/anchor-helper';
import {PageHelper} from '../../../components/html/page-helper';
import {ResourcesPage} from '../../../page-objects/pages/navigation/resources/resources.po';
import {TextboxHelper} from '../../../components/html/textbox-helper';
import {ResourcesPageHelper} from '../../../page-objects/pages/navigation/resources/resources-page.helper';
import {ResourcesPageConstants} from '../../../page-objects/pages/navigation/resources/resources-page.constants';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {WaitHelper} from '../../../components/html/wait-helper';
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

    it('Add  resource - [829512]', async () => {
        const stepLogger = new StepLogger(829512);
        stepLogger.step('PRECONDITION: Navigate to Resources page');
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.resources,
            CommonPage.pageHeaders.projects.resources,
            CommonPageConstants.pageHeaders.projects.resources,
            stepLogger);
        stepLogger.stepId(2);
        await ResourcesPageHelper.addResourceAndValidateIt(stepLogger);
    });
});
