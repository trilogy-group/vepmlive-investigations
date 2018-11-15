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
        StepLogger.caseId = 744351;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();
        // Step 2 is inside the below function
        await CommonPageHelper.selectTwoRecordsFromGrid();
        StepLogger.stepId(3);
        await CommonPageHelper.goToOptimizer();
        await OptimizerPageHelper.verifyOptimizerPageOpened();
        StepLogger.stepId(4);
        await OptimizerPageHelper.closeOptimizerWindowFromOptimizerTab();
        await OptimizerPageHelper.verifyOptimizerWindowClosed();
    });

    it('Verify that when user select only single project  - [744353]', async () => {
        StepLogger.caseId = 744353;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();
        // Step 2 is inside the below function
        await CommonPageHelper.selectRecordFromGrid();
        StepLogger.stepId(3);
        await OptimizerPageHelper.gotoConfigureSection();
        await OptimizerPageHelper.verifyAlertMessageForSingleProjectSelection();
    });

    it('Verify that Saved Strategy name displayed in the Current Strategy drop down box  - [744366]', async () => {
        StepLogger.caseId = 744366;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();
        // Step 2 is inside the below function
        await CommonPageHelper.selectTwoRecordsFromGrid();
        StepLogger.stepId(3);
        await CommonPageHelper.goToOptimizer();
        await OptimizerPageHelper.openSaveStrategyPopup();
        await OptimizerPageHelper.verifySaveStrtegyPopupDisplayed();
        StepLogger.stepId(4);
        const strategyName = await OptimizerPageHelper.enterNewStrategyNameAndSubmit();
        StepLogger.stepId(5);
        await OptimizerPageHelper.verifyCurrentStrategyName(strategyName);
    });

    it('Verify the Delete Strategy button  - [744369]', async () => {
        StepLogger.caseId = 744369;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();
        // Step 2 is inside the below function
        await CommonPageHelper.selectTwoRecordsFromGrid();
        StepLogger.stepId(3);
        await CommonPageHelper.goToOptimizer();
        await OptimizerPageHelper.verifyOptimizerPageOpened();
        StepLogger.stepId(4);
        await OptimizerPageHelper.openDeleteStrategyPopup();
        await OptimizerPageHelper.verifyDeleteStrategyPopup();
    });

    // #REJECTED
    // it('Verify the content of label name "Which fields will be used as filters? of Optimizer configuration screen. - [744356]',
    //     async () => {
    //         StepLogger.caseId = 744356;
    //         // Step 1 is inside the below function
    //         await CommonPageHelper.navigateToItemPageUnderNavigation(
    //             HomePage.navigation.projects.projects,
    //             CommonPage.pageHeaders.projects.projectsCenter,
    //             CommonPageConstants.pageHeaders.projects.projectCenter,
    //         );
    //         await CommonPageHelper.verifyProjectCenterDisplayed();
    //         // Step 2 is inside the below function
    //         await CommonPageHelper.selectTwoRecordsFromGrid();
    //         StepLogger.stepId(3);
    //         await OptimizerPageHelper.gotoConfigureSection();
    //         await OptimizerPageHelper.verifyFilterSectionLabels();
    //     });

    it('Verify that Strategy should be Deleted.  - [744370]', async () => {
        StepLogger.caseId = 744370;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();
        // Step 2 is inside the below function
        await CommonPageHelper.selectTwoRecordsFromGrid();
        StepLogger.stepId(3);
        await CommonPageHelper.goToOptimizer();
        await OptimizerPageHelper.verifyOptimizerPageOpened();
        StepLogger.stepId(4);
        const strategyNameToDel = await OptimizerPageHelper.deleteStrategy();
        StepLogger.stepId(5);
        await OptimizerPageHelper.clickOKonDeleteStrategyPopup();
        await OptimizerPageHelper.verifyDeletedStrategy(strategyNameToDel);
        // postCondition
        await OptimizerPageHelper.openSaveStrategyPopup();
        await OptimizerPageHelper.clickOKonSaveStrategyPopup();

    });

    it('Verify the Minus Sign  - [744373]', async () => {
        StepLogger.caseId = 744373;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();
        // Step 2 is inside the below function
        await CommonPageHelper.selectTwoRecordsFromGrid();
        StepLogger.stepId(3);
        await CommonPageHelper.goToOptimizer();
        await OptimizerPageHelper.verifyOptimizerPageOpened();
        StepLogger.stepId(4);
        await OptimizerPageHelper.clickMinusSign();
        await OptimizerPageHelper.verifyRibbonCollapsed();
    });

    it('Verify the close button of the View Tab.  - [744376]', async () => {
        StepLogger.caseId = 744376;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();
        // Step 2 is inside the below function
        await CommonPageHelper.selectTwoRecordsFromGrid();
        StepLogger.stepId(3);
        await CommonPageHelper.goToOptimizer();
        await OptimizerPageHelper.verifyOptimizerPageOpened();
        StepLogger.stepId(4);
        await OptimizerPageHelper.clickViewTab();
        await OptimizerPageHelper.verifyViewPageOpened();
        StepLogger.stepId(5);
        await OptimizerPageHelper.closeOptimizerWindowFromViewTab();
        await OptimizerPageHelper.verifyOptimizerWindowClosed();
    });

    it('Verify that View should be Deleted.  - [744382]', async () => {
        StepLogger.caseId = 744382;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();
        // Step 2 is inside the below function
        await CommonPageHelper.selectTwoRecordsFromGrid();
        StepLogger.stepId(3);
        await CommonPageHelper.goToOptimizer();
        await OptimizerPageHelper.clickViewTab();
        await OptimizerPageHelper.verifyViewPageOpened();
        StepLogger.stepId(4);
        const viewNameToDel = await OptimizerPageHelper.clickDeleteView();
        await OptimizerPageHelper.verifyDeleteViewPopup();
        StepLogger.stepId(5);
        await OptimizerPageHelper.clickOKonDeleteViewPopup();
        await OptimizerPageHelper.verifyDeletedView(viewNameToDel);
        // post condition
        await OptimizerPageHelper.clickSaveView();
        await OptimizerPageHelper.clickOKonSaveViewPopup();
    });

    // #REJECTED
    // it('Verify the message display on the bottom of the Optimizer configuration page. - [744360]', async () => {
    //     StepLogger.caseId = 744360;
    //     // Step 1 is inside the below function
    //     await CommonPageHelper.navigateToItemPageUnderNavigation(
    //         HomePage.navigation.projects.projects,
    //         CommonPage.pageHeaders.projects.projectsCenter,
    //         CommonPageConstants.pageHeaders.projects.projectCenter,
    //     );
    //     await CommonPageHelper.verifyProjectCenterDisplayed();
    //     // Step 2 is inside the below function
    //     await CommonPageHelper.selectTwoRecordsFromGrid();
    //     // Step 3 and 4 are inside this function
    //     StepLogger.stepId(3);
    //     await OptimizerPageHelper.gotoConfigureSection();
    //     await OptimizerPageHelper.verifyMessageOnConfiguration();
    // });

    it('Verify that Current strategy drop down. - [744372]', async () => {
        StepLogger.caseId = 744372;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();
        // Step 2 is inside the below function
        await CommonPageHelper.selectTwoRecordsFromGrid();
        StepLogger.stepId(3);
        await CommonPageHelper.goToOptimizer();
        await OptimizerPageHelper.verifyOptimizerPageOpened();
        StepLogger.stepId(4);
        await OptimizerPageHelper.verfyCurrentStrategyDropdown();
    });

    it('Verify the Select column button. - [744384]', async () => {
        StepLogger.caseId = 744384;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();
        // Step 2 is inside the below function
        await CommonPageHelper.selectTwoRecordsFromGrid();
        StepLogger.stepId(3);
        await CommonPageHelper.goToOptimizer();
        await OptimizerPageHelper.clickViewTab();
        await OptimizerPageHelper.verifyViewPageOpened();
        StepLogger.stepId(4);
        await OptimizerPageHelper.clickSelectColumns();
        await OptimizerPageHelper.verifySelectColumnsPopup();
    });

    it('Verify the Hide all button of the Select column to display page should be displayed - [744385]', async () => {
        StepLogger.caseId = 744385;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();
        // Step 2 is inside the below function
        await CommonPageHelper.selectTwoRecordsFromGrid();
        StepLogger.stepId(3);
        await CommonPageHelper.goToOptimizer();
        await OptimizerPageHelper.clickViewTab();
        await OptimizerPageHelper.verifyViewPageOpened();
        StepLogger.stepId(4);
        await OptimizerPageHelper.clickSelectColumns();
        StepLogger.stepId(5);
        await OptimizerPageHelper.clickHideAll();
        await OptimizerPageHelper.verifyNoColumnSelected();
        StepLogger.stepId(6);
        await OptimizerPageHelper.clickShowAll();
        await OptimizerPageHelper.verifyAllColumnSelected();
    });

    it('Verify that selected column should be displayed on View Management grid. - [744386]', async () => {
        StepLogger.caseId = 744386;
        // Step 1 is inside the below function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();
        // Step 2 is inside the below function
        await CommonPageHelper.selectTwoRecordsFromGrid();
        StepLogger.stepId(3);
        await CommonPageHelper.goToOptimizer();
        await OptimizerPageHelper.clickViewTab();
        await OptimizerPageHelper.verifyViewPageOpened();
        StepLogger.stepId(4);
        await OptimizerPageHelper.clickSelectColumns();
        const selectedColNames = await OptimizerPageHelper.selectColumns();
        StepLogger.stepId(5);
        await OptimizerPageHelper.clickOKonSelectColumnPopup();
        await OptimizerPageHelper.verifyColumnNamesInGrid(selectedColNames);
    });
});
