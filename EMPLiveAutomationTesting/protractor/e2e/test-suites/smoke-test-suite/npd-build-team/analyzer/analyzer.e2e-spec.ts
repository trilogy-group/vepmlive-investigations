import {SuiteNames} from '../../../helpers/suite-names';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../../page-objects/pages/homepage/home.po';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {ResourceAnalyzerPageHelper} from '../../../../page-objects/pages/resource-analyzer-page/resource-analyzer-page.helper';
import {ResourceAnalyzerPage} from '../../../../page-objects/pages/resource-analyzer-page/resource-analyzer-page.po';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });
    fit('Resource Analyzer period popup window. - [744532]', async () => {
        const stepLogger = new StepLogger(744532);
        stepLogger.step('Select "Navigation" icon  from left side menu');
        stepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(1);
        stepLogger.step('Click Cancel button in Select Analyzer Periods popup window and validate it ');

        await ResourceAnalyzerPageHelper.verifyResourceAnalyzerCancelButtonFunctionality(stepLogger);
        stepLogger.stepId(2);

        stepLogger.step('Click on Display button in Select Analyzer Periods popup windowand validate it ');
        await CommonPageHelper.resourceAnalyzerViaRibbon(stepLogger);

    });
    fit('Verify Analyzer tab of resource analyzer page. - [744534]', async () => {
        const stepLogger = new StepLogger(744534);
        stepLogger.step('Select "Navigation" icon  from left side menu');
        stepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        await CommonPageHelper.resourceAnalyzerViaRibbon(stepLogger);
        stepLogger.stepId(1);

        stepLogger.step('Validate Top panel in analyser Tab');
        await ResourceAnalyzerPageHelper.validateTopPannelAnalyserTab(stepLogger);

        stepLogger.stepId(2);
        stepLogger.step('click on  view Tab');
        await PageHelper.click(ResourceAnalyzerPage.viewTab);

        stepLogger.step('Validate Top panel in view Tab');
        await ResourceAnalyzerPageHelper.validateTopPannelViewTab(stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Validate Bottom  panel');
        await ResourceAnalyzerPageHelper.validateBottomPannel(stepLogger);
    });

});
