import {SuiteNames} from '../../../helpers/suite-names';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../../page-objects/pages/homepage/home.po';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {ResourceAnalyzerPageHelper} from '../../../../page-objects/pages/resource-analyzer-page/resource-analyzer-page.helper';

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

    it('Resource Analyzer period popup window. - [744532]', async () => {
        StepLogger.caseId = 744532;
        StepLogger.step('Select "Navigation" icon  from left side menu');
        StepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.stepId(1);
        StepLogger.step('Click Cancel button in Select Analyzer Periods popup window and validate it ');

        await ResourceAnalyzerPageHelper.verifyResourceAnalyzerCancelButtonFunctionality();
        StepLogger.stepId(2);

        StepLogger.step('Click on Display button in Select Analyzer Periods popup windowand validate it ');
        await CommonPageHelper.resourceAnalyzerViaRibbon();

    });

    /* #UNSTABLE
    it('Verify Analyzer tab of resource analyzer page. - [744534]', async () => {
        StepLogger.caseId = 744534;
        StepLogger.step('Select "Navigation" icon  from left side menu');
        StepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        await CommonPageHelper.resourceAnalyzerViaRibbon();
        StepLogger.stepId(1);

        StepLogger.step('Validate Top panel in analyser Tab');
        await ResourceAnalyzerPageHelper.validateTopPannelAnalyserTab();

        StepLogger.stepId(2);
        StepLogger.step('click on  view Tab');
        await PageHelper.click(ResourceAnalyzerPage.viewTab);

        StepLogger.step('Validate Top panel in view Tab');
        await ResourceAnalyzerPageHelper.validateTopPannelViewTab();

        StepLogger.stepId(3);
        StepLogger.step('Validate Bottom  panel');
        await ResourceAnalyzerPageHelper.validateBottomPannel();
    });
    */

});
