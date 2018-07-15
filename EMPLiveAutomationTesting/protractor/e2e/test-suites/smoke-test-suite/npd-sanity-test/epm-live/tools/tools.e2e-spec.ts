import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {PageHelper} from '../../../../../components/html/page-helper';
import {ResourcePlannerPageHelper} from '../../../../../page-objects/pages/resourceplanner-page/resourceplanner-page.helper';
import {ResourceplannerPage} from '../../../../../page-objects/pages/resourceplanner-page/resourceplanner-page.po';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {SuiteNames} from '../../../../helpers/suite-names';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });
    it('Navigate to Edit Resource Plan- [966351]', async () => {
        const stepLogger = new StepLogger(966351);

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
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(ResourceplannerPage.delete);
        await PageHelper.switchToDefaultContent();
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        stepLogger.stepId(2);
        stepLogger.verification('\t\n' +
            'Check options displayed in \'Resource Planner - Project Mode\' window top section');
        await ResourcePlannerPageHelper.validateTopSection(stepLogger);
        stepLogger.stepId(3);
        stepLogger.verification('Check the columns displayed in top grid');
        await ResourcePlannerPageHelper.validateTopGrid(stepLogger);
        stepLogger.stepId(4);
        stepLogger.verification('Check options displayed in \'Resource Planner - Project Mode\' window bottom section');
        await ResourcePlannerPageHelper.validatebuttonSection(stepLogger);
        stepLogger.stepId(5);
        stepLogger.verification('Check the columns displayed in bottom grid');
        await ResourcePlannerPageHelper.validatebuttonSection(stepLogger);
        await PageHelper.click(CommonPage.ribbonItems.close);
        stepLogger.verification(`${CommonPageConstants.pageHeaders.projects.projectCenter} page is displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));
    });

});
