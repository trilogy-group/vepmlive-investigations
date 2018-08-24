import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {SuiteNames} from '../../helpers/suite-names';
import {PageHelper} from '../../../components/html/page-helper';
import {EditCostHelper} from '../../../page-objects/pages/items-page/project-item/edit-cost-page/edit-cost.helper';
import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';
import {ProjectItemPageHelper} from '../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {ProjectItemPageConstants} from '../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';

describe(SuiteNames.healthCheckTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Edit Project Cost - [2488601]', async () => {
        const stepLogger = new StepLogger(2488601);
        const cost =  4;
        const uniqueId = PageHelper.getUniqueId();

        stepLogger.precondition('Creating New project');
        const  projectNameValue = await ProjectItemPageHelper.createNewProject(uniqueId, stepLogger);

        stepLogger.stepId(1);
        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger,
            projectNameValue,
            ProjectItemPageConstants.columnNames.title);

        stepLogger.stepId(2);
        await CommonPageHelper.editCostViaRibbon(stepLogger);

        await CommonPageHelper.switchToFirstContentFrame();

        await EditCostHelper.validateEditCostWebElements;

        stepLogger.stepId(3);
        await EditCostHelper.enterValueInBudgetCost(stepLogger, cost);

        await EditCostHelper.verifyValueInBudgetCost(stepLogger, cost);

        await EditCostHelper.clickActualCostsTab(stepLogger);

        await EditCostHelper.enterValueInActualCost(stepLogger , cost);

        await EditCostHelper.verifyValueInActualCost(stepLogger, cost);

        await EditCostHelper.clickBenefitsTab(stepLogger);

        await EditCostHelper.enterValueInBenefitTab(stepLogger, cost);

        await EditCostHelper.verifyValueInBenefitCost(stepLogger, cost);

        stepLogger.stepId(4);
        stepLogger.stepId(5);
        stepLogger.stepId(6);
        await EditCostHelper.validateEditCostFunctionality(stepLogger, cost);
    });
});
