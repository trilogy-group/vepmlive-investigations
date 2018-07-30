import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../components/html/page-helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {MyWorkplacePage} from '../../../page-objects/pages/my-workplace/my-workplace.po';
import {WaitHelper} from '../../../components/html/wait-helper';
import {MyWorkPage} from '../../../page-objects/pages/my-workplace/my-work/my-work.po';
import {browser} from 'protractor';
import {MyWorkPageConstants} from '../../../page-objects/pages/my-workplace/my-work/my-work-page.constants';
import {MyWorkPageHelper} from '../../../page-objects/pages/my-workplace/my-work/my-work-page.helper';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {TextboxHelper} from '../../../components/html/textbox-helper';

describe(SuiteNames.regressionTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Verify that View should be saved - [744288]', async () => {
        const stepLogger = new StepLogger(855540);
        // Step 1 and Step 2 are inside below function
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);
        stepLogger.stepId(3);
        stepLogger.step('Click on any of the item, the ribbon panel get enable and Click on View Tab');
        const item = CommonPage.recordWithoutGreenTicket;
        await WaitHelper.getInstance().waitForElementToBeDisplayed(item);
        await PageHelper.click(item);
        browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(MyWorkPage.selectRibbonTabs.views);
        stepLogger.stepId(4);
        stepLogger.step('Click on Save View button.');
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.saveView);
        await stepLogger.verification('Wait for save view popup appears');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(MyWorkPage.viewsPopup.defaultView, PageHelper.timeout.s);
        await stepLogger.verification('Save view popup displayed');
        const uniqueId = PageHelper.getUniqueId();
        const viewName = `${MyWorkPageConstants.viewName}${uniqueId}`;
        stepLogger.stepId(5);
        stepLogger.step('Enter the Title of the new view name and select the check-box for Personal View' +
            'Click on "OK" button');
        await MyWorkPageHelper.fillAndSubmitSaveView(viewName);
        await browser.sleep(PageHelper.timeout.xs);
        await expect(MyWorkPage.getCurrentView().getText())
            .toBe(viewName, ValidationsHelper.getFieldShouldHaveValueValidation(MyWorkPageConstants.currentView, viewName));
        stepLogger.verification('Saved View name displayed in the Current View drop down box.');
    });

    it('Verify that View should be saved - [744288]', async () => {
        const stepLogger = new StepLogger(855540);
        // Step 1 are inside below function
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);
        stepLogger.stepId(2);
        stepLogger.step('Click on My work page > Click on View Tab');
        const item = CommonPage.recordWithoutGreenTicket;
        await WaitHelper.getInstance().waitForElementToBeDisplayed(item);
        await PageHelper.click(item);
        browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(MyWorkPage.selectRibbonTabs.views);
        stepLogger.stepId(3);
        stepLogger.step('Click on rename View button.');
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.renameView);
        stepLogger.stepId(4);
        stepLogger.step('Enter the Title of the new view name. > Click on "OK" button');
        const uniqueId = PageHelper.getUniqueId();
        const viewNewName = `${MyWorkPageConstants.renameView}${uniqueId}`;
        await TextboxHelper.sendKeys(MyWorkPage.viewsPopup.newName, viewNewName);
        await PageHelper.click(MyWorkPage.viewsPopup.ok);
        stepLogger.stepId(5);
        stepLogger.step('Click on Ok in the pop-up.');
        await PageHelper.acceptAlert();
        await browser.sleep(PageHelper.timeout.xs);
        await expect(MyWorkPage.getCurrentView().getText())
            .toBe(viewNewName, ValidationsHelper.getFieldShouldHaveValueValidation(MyWorkPageConstants.currentView, viewNewName));
        stepLogger.verification('Saved View name displayed in the Current View drop down box.');
    });
});
