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
        StepLogger.caseId = 744256;
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
    });

    it('Verify the content of Modeler popup window. - [744257]', async () => {
        StepLogger.caseId = 744257;
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
        await ModelerPageHelper.verifyModelerPopupContent();
    });

    it('Verify the content of View Modeler page. - [744260]', async () => {
        StepLogger.caseId = 744260;
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
        await ModelerPageHelper.verifyDisplayTabSelectedDefault();

        StepLogger.stepId(6);
        await ModelerPageHelper.clickViewTab();
        await ModelerPageHelper.verifyViewTabDisplayed();
    });

    it('Verify the search setting button. - [744262]', async () => {
        StepLogger.caseId = 744262;
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
        await ModelerPageHelper.clicksSearchSettings();
        await ModelerPageHelper.verifySearchSettingsPopup();
    });

    it('Verify the Find next button - [744263]', async () => {
        StepLogger.caseId = 744263;
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
        await ModelerPageHelper.verifyFindNext();
    });
});
