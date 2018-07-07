import {browser} from 'protractor';
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
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Navigate to Resources page - [910192]', async () => {
        const stepLogger = new StepLogger(910192);
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.resources,
            CommonPage.pageHeaders.projects.resources,
            CommonPageConstants.pageHeaders.projects.resources,
            stepLogger);
    });

    it('Add Generic resource - [910195]', async () => {
        const stepLogger = new StepLogger(910195);
        stepLogger.step('PRECONDITION: Navigate to Resources page');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.resources,
            CommonPage.pageHeaders.projects.resources,
            CommonPageConstants.pageHeaders.projects.resources,
            stepLogger);
        stepLogger.stepId(1);
        stepLogger.step('Click on "+ Invite" link displayed on top of "Resources" page');
        await browser.sleep(PageHelper.timeout.l);
        await expect(await PageHelper.isElementDisplayed(ResourcesPage.newInviteLink, true))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(ResourcesPageConstants.inviteLink));
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
        const uniqueId = PageHelper.getUniqueId();
        const displayName = `${ResourcesPageConstants.inputLabels.displayName} ${uniqueId}`;
        await ResourcesPageHelper.fillFormAndSave(displayName, stepLogger);

        stepLogger.stepId(4);
        stepLogger.step('Click on search');
        await PageHelper.click(ResourcesPage.searchIcon);
        stepLogger.step('Enter newly created resource name');
        await TextboxHelper.sendKeys(ResourcesPage.searchTextbox, displayName, true);
        stepLogger.verification('Newly created Resource [Ex: Display Name 1] displayed in "Resources" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(displayName)))
                .toBe(true, ValidationsHelper.getLabelDisplayedValidation(displayName));
    });
});
