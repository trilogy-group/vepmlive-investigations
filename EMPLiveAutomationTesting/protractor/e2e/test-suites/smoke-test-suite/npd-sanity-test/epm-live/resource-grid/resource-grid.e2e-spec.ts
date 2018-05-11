import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {ResourcesPage} from '../../../../../page-objects/pages/navigation/resources/resources.po';
import {ResourcesPageConstants} from '../../../../../page-objects/pages/navigation/resources/resources-page.constants';
import {ResourcesPageHelper} from '../../../../../page-objects/pages/navigation/resources/resources-page.helper';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
    });

    it('Navigate to Resources page - [910192]', async () => {
        const stepLogger = new StepLogger(910192);
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderNavigation (
            HomePage.navigation.projects.resources,
            CommonPage.pageHeaders.projects.resources,
            CommonPageConstants.pageHeaders.projects.resources,
            stepLogger);
    });

    it('Add Generic resource - [910195]', async () => {
        const stepLogger = new StepLogger(910195);
        stepLogger.step('PRECONDITION: Navigate to Resources page');
        await CommonPageHelper.navigateToItemPageUnderNavigation (
            HomePage.navigation.projects.resources,
            CommonPage.pageHeaders.projects.resources,
            CommonPageConstants.pageHeaders.projects.resources,
            stepLogger);
        stepLogger.stepId(1);
        stepLogger.step('Click on "+ Invite" link displayed on top of "Resources" page');
        await PageHelper.click(ResourcesPage.newInviteLink);
        stepLogger.verification('"Resources - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ResourcesPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ResourcesPageConstants.pageName));

        stepLogger.stepId(2);
        stepLogger.step(`Check 'Generic' check box`);
        await PageHelper.click(ResourcesPage.inputs.generic);

        stepLogger.stepId(3);
        stepLogger.step('Provide values in required fields');
        // steps#4 is inside this function
        await ResourcesPageHelper.fillFormAndSave(stepLogger);
    });
});
