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

    it('Verify the Modeler page. - [744256]', async () => {
        const stepLogger = new StepLogger(744256);
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
    });

    it('Verify the content of Modeler popup window. - [744257]', async () => {
        const stepLogger = new StepLogger(744257);
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
        await ModelerPageHelper.verifyModelerPopupContent(stepLogger);
    });

    it('Verify the content of View Modeler page. - [744260]', async () => {
        const stepLogger = new StepLogger(744260);
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
        await ModelerPageHelper.verifyDisplayTabSelectedDefault(stepLogger);

        stepLogger.stepId(6);
        await ModelerPageHelper.clickViewTab(stepLogger);
        await ModelerPageHelper.verifyViewTabDisplayed(stepLogger);
    });

    it('Verify the search setting button. - [744262]', async () => {
        const stepLogger = new StepLogger(744262);
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
        await ModelerPageHelper.clicksSearchSettings(stepLogger);
        await ModelerPageHelper.verifySearchSettingsPopup(stepLogger);
    });

    it('Verify the Find next button - [744263]', async () => {
        const stepLogger = new StepLogger(744263);
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
        await ModelerPageHelper.verifyFindNext(stepLogger);
    });
});
