import {StepLogger} from '../../../../core/logger/step-logger';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {SuiteNames} from '../../helpers/suite-names';
import {PageHelper} from '../../../components/html/page-helper';
import {EditCostHelper} from '../../../page-objects/pages/items-page/project-item/edit-cost-page/edit-cost.helper';
import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';
import {ProjectItemPageHelper} from '../../../page-objects/pages/items-page/project-item/project-item-page.helper';

describe(SuiteNames.regressionTestSuite, () => {
    let loginPage: LoginPage;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Launch Cost Planner from Project center.(Ellipsis icon) - [743216]', async () => {
        StepLogger.caseId = 743216;

        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.stepId(1);
        await CommonPageHelper.selectProjectAndClickEllipsisButton();

        await CommonPageHelper.verifyVariousOptionsOnContextMenu();

        StepLogger.stepId(2);
        await EditCostHelper.clickEditCostFromContextMenu();

        await CommonPageHelper.switchToFirstContentFrame();

        await EditCostHelper.validateEditCostWebElements();
    });
    it('Launch Cost Planner from "View Item" page for Project. - [743217]', async () => {
        StepLogger.caseId = 743217;
        StepLogger.stepId(1);

        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.stepId(2);
        await CommonPageHelper.viewOptionViaRibbon();

        await ProjectItemPageHelper.verifyProjectDetailsDisplayed();

        StepLogger.stepId(3);
        await CommonPageHelper.clickEditCost();

        await CommonPageHelper.switchToFirstContentFrame();

        await EditCostHelper.validateEditCostWebElements();
    });
   });
