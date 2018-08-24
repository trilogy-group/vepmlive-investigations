import {SuiteNames} from '../../../helpers/suite-names';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../../page-objects/pages/homepage/home.po';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {ModelerPageHelper} from '../../../../page-objects/pages/items-page/project-item/modeler-page/modeler-page.helper';

describe(SuiteNames.regressionTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Verify the select Version(s) Selection box. - [744210]', async () => {
        const stepLogger = new StepLogger(744210);
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
        await CommonPageHelper.gotoModeler(stepLogger);
        await ModelerPageHelper.verifySelectVersionsSelectionBox(stepLogger);
    });

    it('Verify the Cancel button of Modeler popup window. - [744211]', async () => {
        const stepLogger = new StepLogger(744211);
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
        await CommonPageHelper.gotoModeler(stepLogger);
        await ModelerPageHelper.verifyModelerPopupDisplayed(stepLogger);

        stepLogger.stepId(4);
        await ModelerPageHelper.clickCancelButton(stepLogger);
        await ModelerPageHelper.verifyModelerPopupClosed(stepLogger);
    });

    it('Verify the content of Display Tab - [744213]', async () => {
        const stepLogger = new StepLogger(744213);
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
        await CommonPageHelper.gotoModeler(stepLogger);
        await ModelerPageHelper.clickOkButtonOnPopup(stepLogger);
        await ModelerPageHelper.verifyDisplayTabContent(stepLogger);
    });

    it('Verify the Close button of the Display Tab - [744214]', async () => {
        const stepLogger = new StepLogger(744214);
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
        await CommonPageHelper.gotoModeler(stepLogger);
        await ModelerPageHelper.verifyModelerPopupDisplayed(stepLogger);

        stepLogger.stepId(4);
        await ModelerPageHelper.clickOkButtonOnPopup(stepLogger);
        await ModelerPageHelper.modelerPageDisplayed(stepLogger);

        stepLogger.stepId(5);
        await ModelerPageHelper.clickCloseButtonDisplayTab(stepLogger);
        await ModelerPageHelper.verifyModelerPageClosed(stepLogger);
    });

    it('Verify the Save Version button without version. - [744220]', async () => {
        const stepLogger = new StepLogger(744220);
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
        await CommonPageHelper.gotoModeler(stepLogger);
        await ModelerPageHelper.verifyModelerPopupDisplayed(stepLogger);

        stepLogger.stepId(4);
        await ModelerPageHelper.clickOkButtonOnPopup(stepLogger);
        await ModelerPageHelper.modelerPageDisplayed(stepLogger);

        stepLogger.stepId(5);
        await ModelerPageHelper.clickSaveVersion(stepLogger);
        await ModelerPageHelper.verifyNoVersionsAlert(stepLogger);
    });

    it('Verify the Copy Version button - [744222]', async () => {
        const stepLogger = new StepLogger(744222);
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
        await CommonPageHelper.gotoModeler(stepLogger);
        await ModelerPageHelper.verifyModelerPopupDisplayed(stepLogger);

        stepLogger.stepId(4);
        await ModelerPageHelper.clickOkButtonOnPopup(stepLogger);
        await ModelerPageHelper.modelerPageDisplayed(stepLogger);

        stepLogger.stepId(5);
        await ModelerPageHelper.clickOkCopyVersion(stepLogger);
        await ModelerPageHelper.verifyCopyVersionPopup(stepLogger);
    });

    it('Verify the Minus sign. - [744227]', async () => {
        const stepLogger = new StepLogger(744227);
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
        await CommonPageHelper.gotoModeler(stepLogger);
        await ModelerPageHelper.verifyModelerPopupDisplayed(stepLogger);

        stepLogger.stepId(4);
        await ModelerPageHelper.clickOkButtonOnPopup(stepLogger);
        await ModelerPageHelper.modelerPageDisplayed(stepLogger);

        stepLogger.stepId(5);
        await ModelerPageHelper.clickMinusSignOnBothRibbons(stepLogger);
        await ModelerPageHelper.verifyBothRibbonsCollapsed(stepLogger);
    });

    it('Verify the Apply Target button. - [744229]', async () => {
        const stepLogger = new StepLogger(744229);
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
        await CommonPageHelper.gotoModeler(stepLogger);
        await ModelerPageHelper.verifyModelerPopupDisplayed(stepLogger);

        stepLogger.stepId(4);
        await ModelerPageHelper.clickOkButtonOnPopup(stepLogger);
        await ModelerPageHelper.modelerPageDisplayed(stepLogger);

        stepLogger.stepId(5);
        await ModelerPageHelper.clickApplyTarget(stepLogger);
        await ModelerPageHelper.verifyNoTargetsAlert(stepLogger);
    });

    it('Verify the content of View Tab - [744239]', async () => {
        const stepLogger = new StepLogger(744239);
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
        await CommonPageHelper.gotoModeler(stepLogger);
        await ModelerPageHelper.verifyModelerPopupDisplayed(stepLogger);

        stepLogger.stepId(4);
        await ModelerPageHelper.clickOkButtonOnPopup(stepLogger);
        await ModelerPageHelper.modelerPageDisplayed(stepLogger);

        stepLogger.stepId(5);
        await ModelerPageHelper.clickViewTab(stepLogger);
        await ModelerPageHelper.verifyViewTabContent(stepLogger);
    });

    it('Verify the Close button of the View Tab - [744240]', async () => {
        const stepLogger = new StepLogger(744240);
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
        await CommonPageHelper.gotoModeler(stepLogger);
        await ModelerPageHelper.verifyModelerPopupDisplayed(stepLogger);

        stepLogger.stepId(4);
        await ModelerPageHelper.clickOkButtonOnPopup(stepLogger);
        await ModelerPageHelper.modelerPageDisplayed(stepLogger);

        stepLogger.stepId(5);
        await ModelerPageHelper.clickViewTab(stepLogger);
        await ModelerPageHelper.verifyViewTabDisplayed(stepLogger);

        stepLogger.stepId(6);
        await ModelerPageHelper.clickCloseButtonViewTab(stepLogger);
        await ModelerPageHelper.verifyViewTabClosedAndRedirect(stepLogger);
    });
});
