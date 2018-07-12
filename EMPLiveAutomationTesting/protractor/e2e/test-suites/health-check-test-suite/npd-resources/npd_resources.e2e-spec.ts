import {ValidationsHelper} from "../../../components/misc-utils/validation-helper";
import {AnchorHelper} from "../../../components/html/anchor-helper";
import {PageHelper} from "../../../components/html/page-helper";
import {ResourcesPage} from "../../../page-objects/pages/navigation/resources/resources.po";
import {TextboxHelper} from "../../../components/html/textbox-helper";
import {ResourcesPageHelper} from "../../../page-objects/pages/navigation/resources/resources-page.helper";
import {ResourcesPageConstants} from "../../../page-objects/pages/navigation/resources/resources-page.constants";
import {CommonPage} from "../../../page-objects/pages/common/common.po";
import {WaitHelper} from "../../../components/html/wait-helper";
import {browser} from "protractor";
import {CommonPageConstants} from "../../../page-objects/pages/common/common-page.constants";
import {HomePage} from "../../../page-objects/pages/homepage/home.po";
import {CommonPageHelper} from "../../../page-objects/pages/common/common-page.helper";
import {StepLogger} from "../../../../core/logger/step-logger";
import {SuiteNames} from "../../helpers/suite-names";
import {LoginPage} from "../../../page-objects/pages/login/login.po";

describe(SuiteNames.healthCheckTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Add  resource - [829512]', async () => {
        const stepLogger = new StepLogger(829512);
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
