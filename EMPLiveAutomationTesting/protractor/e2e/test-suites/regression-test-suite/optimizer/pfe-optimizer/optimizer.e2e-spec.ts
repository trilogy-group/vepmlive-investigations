import {SuiteNames} from '../../../helpers/suite-names';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../../page-objects/pages/homepage/home.po';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
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
        await CommonPageHelper.gotoOptimizer(stepLogger);
        await OptimizerPageHelper.verifyOptimizerPageOpened(stepLogger);
        stepLogger.stepId(4);
        await OptimizerPageHelper.closeOptimizerWindowFromOptimizerTab(stepLogger);
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
        await OptimizerPageHelper.gotoConfigureSection(stepLogger);
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
        await CommonPageHelper.gotoOptimizer(stepLogger);
        await OptimizerPageHelper.openSaveStrategyPopup(stepLogger);
        await OptimizerPageHelper.verifySaveStrtegyPopupDisplayed(stepLogger);
        stepLogger.stepId(4);
        const strategyName = await OptimizerPageHelper.enterNewStrategyNameAndSubmit(stepLogger);
        stepLogger.stepId(5);
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
        await CommonPageHelper.gotoOptimizer(stepLogger);
        await OptimizerPageHelper.verifyOptimizerPageOpened(stepLogger);
        stepLogger.stepId(4);
        await OptimizerPageHelper.openDeleteStrategyPopup(stepLogger);
        await OptimizerPageHelper.verifyDeleteStrategyPopup(stepLogger);
    });

    it('Verify the content of label name "Which fields will be used as filters? of Optimizer configuration screen. - [744356]',
        async () => {
            const stepLogger = new StepLogger(744356);
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
            await OptimizerPageHelper.gotoConfigureSection(stepLogger);
            await OptimizerPageHelper.verifyFilterSectionLabels(stepLogger);
     });

    it('Verify that Strategy should be Deleted.  - [744370]', async () => {
        const stepLogger = new StepLogger(744370);
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
        await CommonPageHelper.gotoOptimizer(stepLogger);
        await OptimizerPageHelper.verifyOptimizerPageOpened(stepLogger);
        stepLogger.stepId(4);
        const strategyNameToDel = await OptimizerPageHelper.deleteStrategy(stepLogger);
        stepLogger.stepId(5);
        await OptimizerPageHelper.clickOKonDeleteStrategyPopup(stepLogger);
        await OptimizerPageHelper.verifyDeletedStrategy(stepLogger, strategyNameToDel);
    });

    it('Verify the Minus Sign  - [744373]', async () => {
        const stepLogger = new StepLogger(744373);
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
        await CommonPageHelper.gotoOptimizer(stepLogger);
        await OptimizerPageHelper.verifyOptimizerPageOpened(stepLogger);
        stepLogger.stepId(4);
        await OptimizerPageHelper.clickMinusSign(stepLogger);
        await OptimizerPageHelper.verifyRibbonCollapsed(stepLogger);
    });

    it('Verify the close button of the View Tab.  - [744376]', async () => {
        const stepLogger = new StepLogger(744376);
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
        await CommonPageHelper.gotoOptimizer(stepLogger);
        await OptimizerPageHelper.verifyOptimizerPageOpened(stepLogger);
        stepLogger.stepId(4);
        await OptimizerPageHelper.clickViewTab(stepLogger);
        await OptimizerPageHelper.verifyViewPageOpened(stepLogger);
        stepLogger.stepId(5);
        await OptimizerPageHelper.closeOptimizerWindowFromViewTab(stepLogger);
        await OptimizerPageHelper.verifyOptimizerWindowClosed(stepLogger);
    });

    it('Verify that View should be Deleted.  - [744382]', async () => {
        const stepLogger = new StepLogger(744382);
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
        await CommonPageHelper.gotoOptimizer(stepLogger);
        await OptimizerPageHelper.clickViewTab(stepLogger);
        await OptimizerPageHelper.verifyViewPageOpened(stepLogger);
        stepLogger.stepId(4);
        const viewNameToDel = await OptimizerPageHelper.clickDeleteView(stepLogger);
        await OptimizerPageHelper.verifyDeleteViewPopup(stepLogger);
        stepLogger.stepId(5);
        stepLogger.stepId(5);
        await OptimizerPageHelper.clickOKonDeleteViewPopup(stepLogger);
        await OptimizerPageHelper.verifyDeletedView(stepLogger, viewNameToDel);
    });
});
