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

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Verify the "Save" button when no changes made - [743219]', async () => {
        StepLogger.caseId = 743219;
        StepLogger.stepId(1);
        // verification for step 1 is inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.stepId(2);

        await CommonPageHelper.selectRecordAndClickItem();

        await IssueItemPageHelper.validateContentOfItemTab();

        StepLogger.stepId(3);
        await CommonPageHelper.clickEditCost();

        await CommonPageHelper.switchToFirstContentFrame();

        await EditCostHelper.validateSaveButtonDisabled();
    });
});
