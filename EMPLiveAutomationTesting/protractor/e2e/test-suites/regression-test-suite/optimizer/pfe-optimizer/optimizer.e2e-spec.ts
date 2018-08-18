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

    fit('Verify the Close button of the Optimizer page  - [744351]', async () => {
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

    fit('Verify that when user select only single project  - [744353]', async () => {
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

    fit('Verify that Saved Strategy name displayed in the Current Strategy drop down box  - [744366]', async () => {
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

    fit('Verify the Delete Strategy button  - [744369]', async () => {
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

    fit('Verify the content of label name "Which fields will be used as filters? of Optimizer configuration screen. - [744356]',
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

    fit('Verify that Strategy should be Deleted.  - [744370]', async () => {
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

    fit('Verify the Minus Sign  - [744373]', async () => {
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

    fit('Verify the close button of the View Tab.  - [744376]', async () => {
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

    fit('Verify that View should be Deleted.  - [744382]', async () => {
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
        await OptimizerPageHelper.clickOKonDeleteViewPopup(stepLogger);
        await OptimizerPageHelper.verifyDeletedView(stepLogger, viewNameToDel);
    });

    fit('Verify the message display on the bottom of the Optimizer configuration page. - [744360]', async () => {
        const stepLogger = new StepLogger(744360);
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);
        await CommonPageHelper.verifyProjectCenterDisplayed(stepLogger);
        // Step 2 is inside the below function
        await CommonPageHelper.selectTwoRecordsFromGrid(stepLogger);
        // Step 3 and 4 are inside this function
        stepLogger.stepId(3);
        await OptimizerPageHelper.gotoConfigureSection(stepLogger);
        await OptimizerPageHelper.verifyMessageOnConfiguration(stepLogger);
    });

    fit('Verify that Current strategy drop down. - [744372]', async () => {
        const stepLogger = new StepLogger(744372);
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
        await OptimizerPageHelper.verfyCurrentStrategyDropdown(stepLogger);
    });

    fit('Verify the Select column button. - [744384]', async () => {
        const stepLogger = new StepLogger(744384);
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
        await OptimizerPageHelper.clickSelectColumns(stepLogger);
        await OptimizerPageHelper.verifySelectColumnsPopup(stepLogger);
    });

    fit('Verify the Hide all button of the Select column to display page should be displayed - [744385]', async () => {
        const stepLogger = new StepLogger(744385);
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
        await OptimizerPageHelper.clickSelectColumns(stepLogger);
        stepLogger.stepId(5);
        await OptimizerPageHelper.clickHideAll(stepLogger);
        await OptimizerPageHelper.verifyNoColumnSelected(stepLogger);
        stepLogger.stepId(6);
        await OptimizerPageHelper.clickShowAll(stepLogger);
        await OptimizerPageHelper.verifyAllColumnSelected(stepLogger);
    });

    fit('Verify that selected column should be displayed on View Management grid. - [744386]', async () => {
        const stepLogger = new StepLogger(744386);
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
        await OptimizerPageHelper.clickSelectColumns(stepLogger);
        const selectedColNames = await OptimizerPageHelper.selectColumns(stepLogger);
        stepLogger.stepId(5);
        await OptimizerPageHelper.clickOKonSelectColumnPopup(stepLogger);
        await OptimizerPageHelper.verifyColumnNamesInGrid(selectedColNames, stepLogger);
    });
});
