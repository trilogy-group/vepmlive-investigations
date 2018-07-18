import {PageHelper} from '../../../components/html/page-helper';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../helpers/suite-names';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {ResourcePlannerPageHelper} from '../../../page-objects/pages/resourceplanner-page/resourceplanner-page.helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {WaitHelper} from '../../../components/html/wait-helper';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {ProjectItemPageConstants} from '../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';

describe(SuiteNames.healthCheckTestSuite, () => {
    let homePage: HomePage;
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });
    it('Validate the Functionality of Edit Resource plan- [2488591]', async () => {
        const stepLogger = new StepLogger(2488591);
        stepLogger.stepId(1);
        const hours = 10.00;
        // Step #1 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);
        await CommonPageHelper.resourcePlanViaRibbon(stepLogger);
        stepLogger.verification('"Edit Project" page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ProjectItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.resourcePlanner));
        stepLogger.stepId(1);
        // Add hours for the resource added in the top-grid
        stepLogger.step('Add hours for the resource added in the top-grid');
        await ResourcePlannerPageHelper.validatingAddingHoursFunctionality(stepLogger, hours);

    });

});
