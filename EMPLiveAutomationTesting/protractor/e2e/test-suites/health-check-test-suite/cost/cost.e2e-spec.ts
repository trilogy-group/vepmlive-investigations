import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';
import {SuiteNames} from '../../helpers/suite-names';
import {PageHelper} from '../../../components/html/page-helper';
import {EditCostHelper} from '../../../page-objects/pages/items-page/project-item/edit-cost-page/edit-cost.helper';
import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';
import {ProjectItemPageHelper} from '../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {ProjectItemPageConstants} from '../../../page-objects/pages/items-page/project-item/project-item-page.constants';

describe(SuiteNames.healthCheckTestSuite, () => {
    let loginPage: LoginPage;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    it('Edit Project Cost - [2488601]', async () => {
        StepLogger.caseId = 2488601;
        const cost = 4;
        const uniqueId = PageHelper.getUniqueId();

        StepLogger.preCondition('Creating New project');
        const projectNameValue = await ProjectItemPageHelper.createNewProject(uniqueId);

        StepLogger.stepId(1);

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,

            projectNameValue,
            ProjectItemPageConstants.columnNames.title);

        StepLogger.stepId(2);
        await CommonPageHelper.editCostViaRibbon();

        await CommonPageHelper.switchToFirstContentFrame();

        await EditCostHelper.validateEditCostWebElements;

        StepLogger.stepId(3);
        await EditCostHelper.enterValueInBudgetCost(cost);

        await EditCostHelper.clickActualCostsTab();

        await EditCostHelper.enterValueInActualCost(cost);

        await EditCostHelper.clickBenefitsTab();

        await EditCostHelper.enterValueInBenefitTab(cost);

        await EditCostHelper.verifyValueInBenefitCost(cost);

        StepLogger.stepId(4);
        StepLogger.stepId(5);
        StepLogger.stepId(6);
        await EditCostHelper.validateEditCostFunctionality(cost);
    });
});
