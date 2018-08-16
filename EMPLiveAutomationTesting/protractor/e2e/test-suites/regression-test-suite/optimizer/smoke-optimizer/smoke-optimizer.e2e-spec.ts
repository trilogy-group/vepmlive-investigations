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

    it('Verify the Optimizer and View Option of the Optimizer page.  - [744404]', async () => {
        const stepLogger = new StepLogger(744404);
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
        await OptimizerPageHelper.verifyOptimizerTabOptions(stepLogger);
    });

    it('Verify the Content of Optimizer Option Tab.  - [744405]', async () => {
        const stepLogger = new StepLogger(744405);
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
        await OptimizerPageHelper.verifyOptimizerTabContents(stepLogger);
    });

    it('Verify the content of Optimizer configuration screen. - [744407]', async () => {
        const stepLogger = new StepLogger(744407);
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
        await OptimizerPageHelper.clickConfigure(stepLogger);
        await OptimizerPageHelper.verifyConfigureScreen(stepLogger);
    });

    it('Verify the Add button of the Optimizer configuration screen. - [744408]', async () => {
        const stepLogger = new StepLogger(744408);
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
        await OptimizerPageHelper.clickConfigure(stepLogger);
        await OptimizerPageHelper.verifyOptimizerConfigurationPopupOpened(stepLogger);
        stepLogger.stepId(5);
        const fieldName = await OptimizerPageHelper.selectAvailableFieldAndAdd(stepLogger);
        await OptimizerPageHelper.verifyAddedFieldInSelectedFields(fieldName, stepLogger);
    });

    it('Verify the Remove button of the Optimizer configuration screen. - [744409]', async () => {
        const stepLogger = new StepLogger(744409);
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
        await OptimizerPageHelper.clickConfigure(stepLogger);
        await OptimizerPageHelper.verifyOptimizerConfigurationPopupOpened(stepLogger);
        stepLogger.stepId(5);
        const fieldName = await OptimizerPageHelper.selectSelectedFiedldAndRemove(stepLogger);
        await OptimizerPageHelper.verifyRemovedFieldInAvailableFields(fieldName, stepLogger);
    });

    fit('Verify the content of Save Strategy button. - [744410]', async () => {
        const stepLogger = new StepLogger(744410);
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
        await OptimizerPageHelper.openSaveStrategyPopup(stepLogger);
        await OptimizerPageHelper.verifySaveStrategyPopup(stepLogger);
    });

    fit('Verify the Rename Strategy button. - [744411]', async () => {
        const stepLogger = new StepLogger(744411);
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
        await OptimizerPageHelper.selectStrategyFromCurrentStrategy(stepLogger);
        await OptimizerPageHelper.clickRenameStrategy(stepLogger);
        await OptimizerPageHelper.verifyRenameStrategyPopup(stepLogger);
    });
});
