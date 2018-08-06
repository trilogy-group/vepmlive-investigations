import {browser} from 'protractor';
import {SuiteNames} from '../../../helpers/suite-names';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../../page-objects/pages/homepage/home.po';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {OptimizerPage} from '../../../../page-objects/pages/items-page/project-item/optimizer-page/optimizer.po';
import {OptimizerPageConstants} from '../../../../page-objects/pages/items-page/project-item/optimizer-page/optimizer-page.constants';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {OptimizerPageHelper} from '../../../../page-objects/pages/items-page/project-item/optimizer-page/optimizer-page.helper';

describe(SuiteNames.regressionTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Verify the Close button of the Optimizer page  - [744351]', async () => {
        const stepLogger = new StepLogger(744351);
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);
        await CommonPageHelper.verifyProjectCenterDisplayed(stepLogger);
        // Step 2 is inside the below function
        await CommonPageHelper.selectTwoRecordsFromGrid(stepLogger);
        stepLogger.stepId(3);
        stepLogger.step('Click on Optimizer button from the items tab.');
        await PageHelper.click(CommonPageHelper.getRibbonButtonByText(CommonPageConstants.ribbonLabels.optimizer));
        // Takes time to load the iframe
        await browser.sleep(PageHelper.timeout.m);
        await CommonPageHelper.switchToFirstContentFrame();
        stepLogger.stepId(4);
        stepLogger.step('Click on Close button of the optimizer tab.');
        await PageHelper.click(OptimizerPage.getCloseOptimizerWindow);
        await OptimizerPageHelper.verifyOptimizerWindowClosed(stepLogger);
    });

    it('Verify that when user select only single project  - [744353]', async () => {
        const stepLogger = new StepLogger(744353);
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);
        await CommonPageHelper.verifyProjectCenterDisplayed(stepLogger);
        // Step 2 is inside the below function
        await CommonPageHelper.selectRecordFromGrid(stepLogger);
        stepLogger.stepId(3);
        stepLogger.step('Click on Optimizer button from the items tab < Click on Configure button.');
        await PageHelper.click(CommonPageHelper.getRibbonButtonByText(CommonPageConstants.ribbonLabels.optimizer));
        // Takes time to load the iframe
        await browser.sleep(PageHelper.timeout.m);
        await CommonPageHelper.switchToFirstContentFrame();
        await PageHelper.click(OptimizerPage.getConfigure);
        await OptimizerPageHelper.verifyAlertMessageForSingleProjectSelection(stepLogger);
    });

    it('Verify that Saved Strategy name displayed in the Current Strategy drop down box  - [744366]', async () => {
        const stepLogger = new StepLogger(744366);
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);
        await CommonPageHelper.verifyProjectCenterDisplayed(stepLogger);
        // Step 2 is inside the below function
        await CommonPageHelper.selectTwoRecordsFromGrid(stepLogger);
        stepLogger.stepId(3);
        stepLogger.step('Click on Optimizer button from the items tab, Click on Save Strategy button.');
        await PageHelper.click(CommonPageHelper.getRibbonButtonByText(CommonPageConstants.ribbonLabels.optimizer));
        // Takes time to load the iframe
        await browser.sleep(PageHelper.timeout.m);
        await CommonPageHelper.switchToFirstContentFrame();
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.saveStrategy);
        stepLogger.stepId(4);
        stepLogger.step('Enter Strategy name.');
        const uniqueId = PageHelper.getUniqueId();
        const strategyName = `${OptimizerPageConstants.strategyName}${uniqueId}`;
        await TextboxHelper.sendKeys(OptimizerPage.getOptimierSaveStrategyPopup.strategyName, strategyName);
        await PageHelper.click(OptimizerPage.getOptimierSaveStrategyPopup.ok);
        stepLogger.stepId(5);
        stepLogger.step('Verify the Current Strategy drop down.');
        await browser.sleep(PageHelper.timeout.xs);
        await OptimizerPageHelper.verifyCurrentStrategyName(strategyName, stepLogger);
    });

    it('Verify the Delete Strategy button  - [744369]', async () => {
        const stepLogger = new StepLogger(744369);
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);
        await CommonPageHelper.verifyProjectCenterDisplayed(stepLogger);
        // Step 2 is inside the below function
        await CommonPageHelper.selectTwoRecordsFromGrid(stepLogger);
        stepLogger.stepId(3);
        stepLogger.step('Click on Optimizer button from the items tab.');
        await PageHelper.click(CommonPageHelper.getRibbonButtonByText(CommonPageConstants.ribbonLabels.optimizer));
        // Takes time to load the iframe
        await browser.sleep(PageHelper.timeout.m);
        await CommonPageHelper.switchToFirstContentFrame();
        stepLogger.stepId(4);
        stepLogger.step('Select a strategy in current strategy and Click on Delete Strategy button.');
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdown);
        // takes time to expand dropdown
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdownValue);
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.deleteStrategy);
        await OptimizerPageHelper.verifyDeleteStrategyPopup(stepLogger);
    });
});
