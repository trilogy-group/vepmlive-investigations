import {StepLogger} from '../../../../../core/logger/step-logger';
import {HomePage} from '../../../../page-objects/pages/homepage/home.po';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {SuiteNames} from '../../../helpers/suite-names';
import {PageHelper} from '../../../../components/html/page-helper';
import {EditCostHelper} from '../../../../page-objects/pages/items-page/project-item/edit-cost-page/edit-cost.helper';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {IssueItemPageHelper} from '../../../../page-objects/pages/items-page/issue-item/issue-item-page.helper';

describe(SuiteNames.regressionTestSuite, () => {
    let loginPage: LoginPage;
    let stepLogger: StepLogger;
    beforeEach(async () => {
        stepLogger = new StepLogger();
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Verify the "Save" button when no changes made - [743219]', async () => {
        stepLogger.caseId = 743219;
        stepLogger.stepId(1);
        // verification for step 1 is inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);

        await CommonPageHelper.selectRecordAndClickItem(stepLogger);

        await IssueItemPageHelper.validateContentOfItemTab(stepLogger);

        stepLogger.stepId(3);
        await CommonPageHelper.clickEditCost(stepLogger);

        await CommonPageHelper.switchToFirstContentFrame();

        await EditCostHelper.validateSaveButtonDisabled(stepLogger);
    });
});
