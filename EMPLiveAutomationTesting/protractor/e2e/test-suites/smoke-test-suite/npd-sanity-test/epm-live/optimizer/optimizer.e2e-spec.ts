import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {EditCostHelper} from '../../../../../page-objects/pages/items-page/project-item/edit-cost-page/edit-cost.helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {ProjectItemPageHelper} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });
    it('Set Cost Plan for Project - [785226]', async () => {
        const stepLogger = new StepLogger(785226);
        const cost =  4;
        stepLogger.precondition('Creating a project');

        const uniqueId = PageHelper.getUniqueId();

        const  projectNameValue = await ProjectItemPageHelper.createNewProject(uniqueId, stepLogger);

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
        await EditCostHelper.enterValueInVariousCategories(stepLogger, cost);

        await EditCostHelper.verifyValueInVariousCategories(stepLogger, cost);

        stepLogger.stepId(4);
        await EditCostHelper.clickSaveCostPlanner(stepLogger);

        await EditCostHelper.verifyValueInVariousCategories(stepLogger, cost);
    });
});
