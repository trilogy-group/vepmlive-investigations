import {SuiteNames} from '../../../helpers/suite-names';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../../page-objects/pages/homepage/home.po';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {OptimizerPageHelper} from '../../../../page-objects/pages/items-page/project-item/optimizer-page/optimizer-page.helper';
import {EditCostHelper} from '../../../../page-objects/pages/items-page/project-item/edit-cost-page/edit-cost.helper';
import {CommonSubPageHelper} from '../../../../page-objects/pages/common/common-page.subhelper';

describe(SuiteNames.regressionTestSuite, () => {
    let loginPage: LoginPage;
    let id = '';

    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Verify the Optimizer and View Option of the Optimizer page.  - [744404]', async () => {
        StepLogger.caseId = 744404;
        id = await EditCostHelper.createTwoProjectWithCost();
        await loginPage.goToAndLogin();
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();
        // Step 2 and 3 are inside the below function
        await CommonSubPageHelper.searchAndSelectUsingIdThenOpenOptimizer(id);
        await OptimizerPageHelper.verifyOptimizerTabOptions();
    });

    it('Verify the Content of Optimizer Option Tab.  - [744405]', async () => {
        StepLogger.caseId = 744405;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();

        // Step 2 and 3 are inside the below function
        await CommonSubPageHelper.searchAndSelectUsingIdThenOpenOptimizer(id);
        await OptimizerPageHelper.verifyOptimizerPageOpened();

        StepLogger.stepId(4);
        await OptimizerPageHelper.verifyOptimizerTabContents();
    });

    it('Verify the content of Optimizer configuration screen. - [744407][BUG:SKYVERA-1844]', async () => {
        StepLogger.caseId = 744407;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();

        // Step 2 and 3 are inside the below function
        await CommonSubPageHelper.searchAndSelectUsingIdThenOpenOptimizer(id);
        await OptimizerPageHelper.verifyOptimizerPageOpened();

        StepLogger.stepId(4);
        await OptimizerPageHelper.clickConfigure();
        await OptimizerPageHelper.verifyConfigureScreen();
    });

    it('Verify the Add button of the Optimizer configuration screen. - [744408][BUG:SKYVERA-1844]', async () => {
        StepLogger.caseId = 744408;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();

        // Step 2 and 3 are inside the below function
        await CommonSubPageHelper.searchAndSelectUsingIdThenOpenOptimizer(id);
        await OptimizerPageHelper.verifyOptimizerPageOpened();

        StepLogger.stepId(4);
        await OptimizerPageHelper.clickConfigure();
        await OptimizerPageHelper.verifyOptimizerConfigurationPopupOpened();

        StepLogger.stepId(5);
        const fieldName = await OptimizerPageHelper.selectAvailableFieldAndAdd();
        await OptimizerPageHelper.verifyAddedFieldInSelectedFields(fieldName);
    });

    it('Verify the Remove button of the Optimizer configuration screen. - [744409][BUG:SKYVERA-1844]', async () => {
        StepLogger.caseId = 744409;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();

        // Step 2 and 3 are inside the below function
        await CommonSubPageHelper.searchAndSelectUsingIdThenOpenOptimizer(id);
        await OptimizerPageHelper.verifyOptimizerPageOpened();

        StepLogger.stepId(4);
        await OptimizerPageHelper.clickConfigure();
        await OptimizerPageHelper.verifyOptimizerConfigurationPopupOpened();

        StepLogger.stepId(5);
        const fieldName = await OptimizerPageHelper.selectSelectedFieldAndRemove();
        await OptimizerPageHelper.verifyRemovedFieldInAvailableFields(fieldName);
    });

    it('Verify the content of Save Strategy button. - [744410]', async () => {
        StepLogger.caseId = 744410;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();

        // Step 2 and 3 are inside the below function
        await CommonSubPageHelper.searchAndSelectUsingIdThenOpenOptimizer(id);
        await OptimizerPageHelper.verifyOptimizerPageOpened();

        StepLogger.stepId(4);
        await OptimizerPageHelper.openSaveStrategyPopup();
        await OptimizerPageHelper.verifySaveStrategyPopup();
    });

    it('Verify the Rename Strategy button. - [744411]', async () => {
        StepLogger.caseId = 744411;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();

        // Step 2 and 3 are inside the below function
        await CommonSubPageHelper.searchAndSelectUsingIdThenOpenOptimizer(id);
        await OptimizerPageHelper.verifyOptimizerPageOpened();

        StepLogger.stepId(4);
        await OptimizerPageHelper.selectStrategyFromCurrentStrategy();
        await OptimizerPageHelper.clickRenameStrategy();
        await OptimizerPageHelper.verifyRenameStrategyPopup();
    });

    it('Verify the content of View Tab of optimizer. - [744413]', async () => {
        StepLogger.caseId = 744413;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();

        // Step 2 and 3 are inside the below function
        await CommonSubPageHelper.searchAndSelectUsingIdThenOpenOptimizer(id);
        await OptimizerPageHelper.verifyOptimizerPageOpened();

        StepLogger.stepId(4);
        await OptimizerPageHelper.clickViewTab();
        await OptimizerPageHelper.verifyViewTabContent();
    });

    it('Verify the on Delete View button. - [744414]', async () => {
        StepLogger.caseId = 744414;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();

        // Step 2 and 3 are inside the below function
        await CommonSubPageHelper.searchAndSelectUsingIdThenOpenOptimizer(id);
        await OptimizerPageHelper.verifyOptimizerPageOpened();

        StepLogger.stepId(4);
        await OptimizerPageHelper.clickViewTab();
        await OptimizerPageHelper.clickDeleteView();
        await OptimizerPageHelper.verifyDeleteViewPopup();
    });

    it('Verify the Current View drop down - [744415]', async () => {
        StepLogger.caseId = 744415;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();

        // Step 2 and 3 are inside the below function
        await CommonSubPageHelper.searchAndSelectUsingIdThenOpenOptimizer(id);
        await OptimizerPageHelper.verifyOptimizerPageOpened();

        StepLogger.stepId(4);
        await OptimizerPageHelper.clickViewTab();
        await OptimizerPageHelper.verifyCurrentViewDropdown();
    });
});