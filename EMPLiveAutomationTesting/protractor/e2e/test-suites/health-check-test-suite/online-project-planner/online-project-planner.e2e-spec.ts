import {PageHelper} from '../../../components/html/page-helper';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../helpers/suite-names';
import {ResourcePlannerPageHelper} from '../../../page-objects/pages/resource-planner-page/resource-planner-page.helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {ProjectItemPageConstants} from '../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';
import {ProjectItemPageHelper} from '../../../page-objects/pages/items-page/project-item/project-item-page.helper';

describe(SuiteNames.healthCheckTestSuite, () => {
    let homePage: HomePage;
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });
    it('Edit Resource plan - [829770]', async () => {
        const stepLogger = new StepLogger(829770);
        stepLogger.stepId(1);
        const hours = 10.00 ;
        // Step #1 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        await CommonPageHelper.clickEditResourcePlanViaRibbon(stepLogger);
        stepLogger.verification('"Edit Project" page is displayed');
        await CommonPageHelper.pageDisplayedValidation(ProjectItemPageConstants.pagePrefix);

        stepLogger.stepId(2);
        // Add hours for the resource added in the top-grid
        stepLogger.step('Add hours for the resource added in the top-grid');
        await ResourcePlannerPageHelper.validatingAddingHoursFunctionality(stepLogger, hours);

    });
    it('Add, Edit and Delete Project - [829527]', async () => {
        const stepLogger = new StepLogger(829527);
        stepLogger.stepId(1);
        // Step #1 Inside this function
        const uniqueId = PageHelper.getUniqueId();

        let projectNameValue = await ProjectItemPageHelper.createNewProject(uniqueId, stepLogger );

        projectNameValue = await ProjectItemPageHelper.editProjectAndValidateIt(stepLogger , projectNameValue );

        await ProjectItemPageHelper.deleteProjectAndValidateIt(stepLogger , projectNameValue );
        });
});
