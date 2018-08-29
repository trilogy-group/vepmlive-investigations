import {PageHelper} from '../../../components/html/page-helper';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {SuiteNames} from '../../helpers/suite-names';
import {StepLogger} from '../../../../core/logger/step-logger';
import {ProjectItemPageHelper} from '../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';
import {EditCostHelper} from '../../../page-objects/pages/items-page/project-item/edit-cost-page/edit-cost.helper';
import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';
import {ProjectItemPageConstants} from '../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';

describe(SuiteNames.healthCheckTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Add, Edit and Delete Project - [829527]', async () => {
        const stepLogger = new StepLogger(829527);
        stepLogger.stepId(1);
        // Step #1 Inside this function
        const uniqueId = PageHelper.getUniqueId();

        let projectNameValue = await ProjectItemPageHelper.createNewProject(uniqueId, stepLogger);

        projectNameValue = await ProjectItemPageHelper.editProjectAndValidateIt(stepLogger, projectNameValue);

        await ProjectItemPageHelper.deleteProjectAndValidateIt(stepLogger, projectNameValue);
    });

    it('Edit Project Cost - [829775]', async () => {
        const stepLogger = new StepLogger(829775);
        const cost =  4;
        const uniqueId = PageHelper.getUniqueId();

        stepLogger.precondition('Creating New Project');
        const  projectNameValue = await ProjectItemPageHelper.createNewProject(uniqueId, stepLogger);

        stepLogger.stepId(1);

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger,
            projectNameValue,
            ProjectItemPageConstants.columnNames.title);

        stepLogger.stepId(1);
        await CommonPageHelper.selectProjectAndClickEllipsisButton(stepLogger);

        await CommonPageHelper.verifyVariousOptionsOnContextMenu(stepLogger);

        stepLogger.stepId(2);
        await CommonPageHelper.clickEditCost(stepLogger);

        await CommonPageHelper.switchToFirstContentFrame();

        await EditCostHelper.validateEditCostWebElements(stepLogger);

        stepLogger.stepId(3);
        await EditCostHelper.enterValueInBudgetCost(stepLogger, cost);

        await EditCostHelper.verifyValueInBudgetCost(stepLogger, cost);

        stepLogger.stepId(4);
        await EditCostHelper.clickActualCostsTab(stepLogger);

        await EditCostHelper.enterValueInActualCost(stepLogger , cost);

        await EditCostHelper.verifyValueInActualCost(stepLogger, cost);

        stepLogger.stepId(5);
        await EditCostHelper.clickBenefitsTab(stepLogger);

        await EditCostHelper.enterValueInBenefitTab(stepLogger, cost);

        await EditCostHelper.verifyValueInBenefitCost(stepLogger, cost);

        stepLogger.stepId(6);
        stepLogger.stepId(7);
        await EditCostHelper.validateEditCostFunctionality(stepLogger, cost);
    });
});
