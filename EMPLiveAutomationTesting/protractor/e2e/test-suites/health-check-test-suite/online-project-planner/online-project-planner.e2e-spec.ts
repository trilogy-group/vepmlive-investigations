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

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    it('Add, Edit and Delete Project - [829527]', async () => {
        StepLogger.caseId = 829527;
        StepLogger.stepId(1);
        // Step #1 Inside this function
        const uniqueId = PageHelper.getUniqueId();

        let projectNameValue = await ProjectItemPageHelper.createNewProject(uniqueId, );

        projectNameValue = await ProjectItemPageHelper.editProjectAndValidateIt(projectNameValue);

        await ProjectItemPageHelper.deleteProjectAndValidateIt(projectNameValue);
    });

    it('Edit Project Cost - [829775]', async () => {
        StepLogger.caseId = 829775;
        const cost = 4;
        const uniqueId = PageHelper.getUniqueId();

        StepLogger.preCondition('Creating New Project');
        const projectNameValue = await ProjectItemPageHelper.createNewProject(uniqueId);

        StepLogger.stepId(1);

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,

            projectNameValue,
            ProjectItemPageConstants.columnNames.title);

        StepLogger.stepId(1);
        await CommonPageHelper.selectProjectAndClickEllipsisButton();

        await CommonPageHelper.verifyVariousOptionsOnContextMenu();

        StepLogger.stepId(2);
        await CommonPageHelper.clickEditCost();

        await CommonPageHelper.switchToFirstContentFrame();

        await EditCostHelper.validateEditCostWebElements();

        StepLogger.stepId(3);
        await EditCostHelper.enterValueInBudgetCost(cost);

        StepLogger.stepId(4);
        await EditCostHelper.clickActualCostsTab();

        await EditCostHelper.enterValueInActualCost(cost);

        StepLogger.stepId(5);
        await EditCostHelper.clickBenefitsTab();

        await EditCostHelper.enterValueInBenefitTab(cost);

        await EditCostHelper.verifyValueInBenefitCost(cost);

        StepLogger.stepId(6);
        StepLogger.stepId(7);
        await EditCostHelper.validateEditCostFunctionality(cost);
    });
});
