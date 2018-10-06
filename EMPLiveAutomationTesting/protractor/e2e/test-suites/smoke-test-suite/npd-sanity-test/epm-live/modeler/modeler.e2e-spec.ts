import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {EditCostHelper} from '../../../../../page-objects/pages/items-page/project-item/edit-cost-page/edit-cost.helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {ProjectItemPageHelper} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {IssueItemPageHelper} from '../../../../../page-objects/pages/items-page/issue-item/issue-item-page.helper';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Validate Edit Cost Functionality in Cost Planner - [783206]', async () => {
        StepLogger.caseId = 783206;
        const cost = 4;

        const uniqueId = PageHelper.getUniqueId();

        const projectNameValue = await ProjectItemPageHelper.createNewProject(uniqueId);
        StepLogger.stepId(1);

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,

            projectNameValue,
            ProjectItemPageConstants.columnNames.title);

        await CommonPageHelper.clickItemTab();

        await IssueItemPageHelper.validateContentOfItemTabIsDisabled();

        StepLogger.stepId(2);
        await EditCostHelper.validateEditCostIsDisabled();

        StepLogger.stepId(3);

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,

            projectNameValue,
            ProjectItemPageConstants.columnNames.title);

        await EditCostHelper.validateEditCostIsEnable();

        StepLogger.stepId(4);

        await CommonPageHelper.editCostViaRibbon();

        await CommonPageHelper.switchToFirstContentFrame();

        await EditCostHelper.validateEditCostWebElements();

        StepLogger.stepId(5);
        await EditCostHelper.validateCostCategoriesInEachTab();

        StepLogger.stepId(6);
        await EditCostHelper.clickBudgetTabCostsTab();

        await EditCostHelper.enterValueInVariousCategories(cost);

        await EditCostHelper.verifyValueInVariousCategories(cost);
    });
});
