import {SuiteNames} from '../../../helpers/suite-names';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../../page-objects/pages/homepage/home.po';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {ModelerPageHelper} from '../../../../page-objects/pages/items-page/project-item/modeler-page/modeler-page.helper';
import { WaitHelper } from '../../../../components/html/wait-helper';
import { ModelerPage } from '../../../../page-objects/pages/items-page/project-item/modeler-page/modeler.po';

describe(SuiteNames.regressionTestSuite, () => {
    let loginPage: LoginPage;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Verify the select Version(s) Selection box. - [744210]', async () => {
        StepLogger.caseId = 744210;
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
        await CommonPageHelper.gotoModeler();
        await ModelerPageHelper.verifySelectVersionsSelectionBox();
    });

    it('Verify the Cancel button of Modeler popup window. - [744211]', async () => {
        StepLogger.caseId = 744211;
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
        await CommonPageHelper.gotoModeler();
        await ModelerPageHelper.verifyModelerPopupDisplayed();

        StepLogger.stepId(4);
        await ModelerPageHelper.clickCancelButton();
        await ModelerPageHelper.verifyModelerPopupClosed();
    });

    it('Verify the content of Display Tab - [744213]', async () => {
        StepLogger.caseId = 744213;
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
        await CommonPageHelper.gotoModeler();
        await ModelerPageHelper.clickOkButtonOnPopup();
        await ModelerPageHelper.verifyDisplayTabContent();
    });

    it('Verify the Close button of the Display Tab - [744214]', async () => {
        StepLogger.caseId = 744214;
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
        await CommonPageHelper.gotoModeler();
        await ModelerPageHelper.verifyModelerPopupDisplayed();

        StepLogger.stepId(4);
        await ModelerPageHelper.clickOkButtonOnPopup();
        await ModelerPageHelper.modelerPageDisplayed();

        StepLogger.stepId(5);
        await ModelerPageHelper.clickCloseButtonDisplayTab();
        await ModelerPageHelper.verifyModelerPageClosed();
    });

    it('Verify the Save Version button without version. - [744220]', async () => {
        StepLogger.caseId = 744220;
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
        await CommonPageHelper.gotoModeler();
        await WaitHelper.waitForElementToBeDisplayed(ModelerPage.selectModelAndVersionsPopup.title);
        await ModelerPageHelper.verifyModelerPopupDisplayed();

        StepLogger.stepId(4);
        await ModelerPageHelper.clickOkButtonOnPopup();
        await ModelerPageHelper.modelerPageDisplayed();

        StepLogger.stepId(5);
        await ModelerPageHelper.clickSaveVersion();
        await ModelerPageHelper.verifyNoVersionsAlert();
    });

    it('Verify the Copy Version button - [744222]', async () => {
        StepLogger.caseId = 744222;
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
        await CommonPageHelper.gotoModeler();
        await ModelerPageHelper.verifyModelerPopupDisplayed();

        StepLogger.stepId(4);
        await ModelerPageHelper.clickOkButtonOnPopup();
        await ModelerPageHelper.modelerPageDisplayed();

        StepLogger.stepId(5);
        await ModelerPageHelper.clickOkCopyVersion();
        await ModelerPageHelper.verifyCopyVersionPopup();
    });

    it('Verify the Minus sign. - [744227]', async () => {
        StepLogger.caseId = 744227;
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
        await CommonPageHelper.gotoModeler();
        await ModelerPageHelper.verifyModelerPopupDisplayed();

        StepLogger.stepId(4);
        await ModelerPageHelper.clickOkButtonOnPopup();
        await ModelerPageHelper.modelerPageDisplayed();

        StepLogger.stepId(5);
        await ModelerPageHelper.clickMinusSignOnBothRibbons();
        await ModelerPageHelper.verifyBothRibbonsCollapsed();
    });

    it('Verify the Apply Target button. - [744229]', async () => {
        StepLogger.caseId = 744229;
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
        await CommonPageHelper.gotoModeler();
        await ModelerPageHelper.verifyModelerPopupDisplayed();

        StepLogger.stepId(4);
        await ModelerPageHelper.clickOkButtonOnPopup();
        await ModelerPageHelper.modelerPageDisplayed();

        StepLogger.stepId(5);
        await ModelerPageHelper.clickApplyTarget();
        await ModelerPageHelper.verifyNoTargetsAlert();
    });

    it('Verify the content of View Tab - [744239]', async () => {
        StepLogger.caseId = 744239;
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
        await CommonPageHelper.gotoModeler();
        await ModelerPageHelper.verifyModelerPopupDisplayed();

        StepLogger.stepId(4);
        await ModelerPageHelper.clickOkButtonOnPopup();
        await ModelerPageHelper.modelerPageDisplayed();

        StepLogger.stepId(5);
        await ModelerPageHelper.clickViewTab();
        await ModelerPageHelper.verifyViewTabContent();
    });

    it('Verify the Close button of the View Tab - [744240]', async () => {
        StepLogger.caseId = 744240;
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
        await CommonPageHelper.gotoModeler();
        await ModelerPageHelper.verifyModelerPopupDisplayed();

        StepLogger.stepId(4);
        await ModelerPageHelper.clickOkButtonOnPopup();
        await ModelerPageHelper.modelerPageDisplayed();

        StepLogger.stepId(5);
        await ModelerPageHelper.clickViewTab();
        await ModelerPageHelper.verifyViewTabDisplayed();

        StepLogger.stepId(6);
        await ModelerPageHelper.clickCloseButtonViewTab();
        await ModelerPageHelper.verifyViewTabClosedAndRedirect();
    });
});
