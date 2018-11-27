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

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    it('Navigate to Resources page - [910192]', async () => {
        StepLogger.caseId = 910192;
        StepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.resources,
            CommonPage.pageHeaders.projects.resources,
            CommonPageConstants.pageHeaders.projects.resources,
        );
    });

    it('Add Generic resource - [910195]', async () => {
        StepLogger.caseId = 910195;
        StepLogger.step('preCondition: Navigate to Resources page');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.resources,
            CommonPage.pageHeaders.projects.resources,
            CommonPageConstants.pageHeaders.projects.resources,
        );
        StepLogger.stepId(1);
        StepLogger.step('Click on "+ Invite" link displayed on top of "Resources" page');
        await browser.sleep(PageHelper.timeout.l);
        await expect(await PageHelper.isElementDisplayed(ResourcesPage.newInviteLink, true))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(ResourcesPageConstants.inviteLink));
        await PageHelper.click(ResourcesPage.newInviteLink);
        StepLogger.verification('"Resources - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ResourcesPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ResourcesPageConstants.pageName));

        StepLogger.stepId(2);
        StepLogger.step(`Check 'Generic' check box`);
        await PageHelper.click(ResourcesPage.inputs.generic);

        StepLogger.stepId(3);
        StepLogger.step('Provide values in required fields');
        const uniqueId = PageHelper.getUniqueId();
        const displayName = `${ResourcesPageConstants.inputLabels.displayName} ${uniqueId}`;
        await ResourcesPageHelper.fillFormAndSave(displayName, );

        StepLogger.stepId(4);
        StepLogger.step('Click on search');
        await PageHelper.click(ResourcesPage.searchIcon);
        StepLogger.step('Enter newly created resource name');
        await TextboxHelper.sendKeys(ResourcesPage.searchTextbox, displayName, true);
        StepLogger.verification('Newly created Resource [Ex: Display Name 1] displayed in "Resources" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(displayName)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(displayName));
    });
});
