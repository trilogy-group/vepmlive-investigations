import {StepLogger} from '../../../../../core/logger/step-logger';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {SuiteNames} from '../../../helpers/suite-names';
import {PageHelper} from '../../../../components/html/page-helper';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {HomePage} from '../../../../page-objects/pages/homepage/home.po';
import {EditCostHelper} from '../../../../page-objects/pages/items-page/project-item/edit-cost-page/edit-cost.helper';
import {ResourcePlannerPageHelper} from '../../../../page-objects/pages/resource-planner-page/resource-planner-page.helper';
import {ProjectItemPageHelper} from '../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {ElementHelper} from '../../../../components/html/element-helper';
import {ResourcePlannerPage} from '../../../../page-objects/pages/resource-planner-page/resource-planner-page.po';
import {EditCost} from '../../../../page-objects/pages/items-page/project-item/edit-cost-page/edit-cost.po';

describe(SuiteNames.regressionTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Validate right click for Projects > Edit Cost tab - [14119619]', async () => {
        const stepLogger = new StepLogger(14119619);
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        await CommonPageHelper.selectRecordFromGrid(stepLogger);

        await EditCostHelper.verifiyEditCostIsPresent(stepLogger);

        stepLogger.stepId(3);
        await EditCostHelper.editCostOpenViaRibbonInNewTab(stepLogger);

        stepLogger.stepId(4);
        await EditCostHelper.validateEditCostOpenInNewTab(stepLogger);
    });

    it('Validate right click for Projects > Edit resource tab - [14119617]', async () => {
        const stepLogger = new StepLogger(14119617);
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        await CommonPageHelper.selectRecordFromGrid(stepLogger);

        await EditCostHelper.verifiyEditCostIsPresent(stepLogger);

        stepLogger.stepId(3);
        await ResourcePlannerPageHelper.openEditResourceViaRibbonInNewTab(stepLogger);

        stepLogger.stepId(4);
        await ResourcePlannerPageHelper.validateEditResourceOpenInNewTab(stepLogger);
    });
    it('Validate right click for Projects > Edit Cost tab through Ellipse link - [14119634]', async () => {
        const stepLogger = new StepLogger(14119634);
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        await CommonPageHelper.selectProjectAndClickEllipsisButton(stepLogger);

        await CommonPageHelper.verifyVariousOptionsOnContextMenu(stepLogger);

        stepLogger.stepId(3);
        stepLogger.stepId(4);
        await ElementHelper.openLinkInNewTab(EditCost.editCostLinkViaEllipse);

        await EditCostHelper.validateEditCostOpenInNewTab(stepLogger);
    });
    it('Validate right click for Projects > Edit resource tab through ellipse link - [14119625]', async () => {
        const stepLogger = new StepLogger(14119625);
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        await CommonPageHelper.selectProjectAndClickEllipsisButton(stepLogger);

        await CommonPageHelper.verifyVariousOptionsOnContextMenu(stepLogger);

        stepLogger.stepId(3);
        stepLogger.stepId(4);
        await ElementHelper.openLinkInNewTab(ResourcePlannerPage.editResourceLinkViaEllipse);

        await ResourcePlannerPageHelper.validateEditResourceOpenInNewTab(stepLogger);

    });
    it('Validate right click for Projects > Project name. - [14119624]', async () => {
        const stepLogger = new StepLogger(14119624);
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        stepLogger.stepId(3);
        await ProjectItemPageHelper.validateProjectOpenViaRightClickInNewTab(stepLogger);
    });
});
