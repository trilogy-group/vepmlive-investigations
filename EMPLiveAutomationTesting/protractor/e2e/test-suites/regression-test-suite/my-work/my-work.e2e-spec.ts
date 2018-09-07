import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../components/html/page-helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {MyWorkplacePage} from '../../../page-objects/pages/my-workplace/my-workplace.po';
import {MyWorkPage} from '../../../page-objects/pages/my-workplace/my-work/my-work.po';
import {browser} from 'protractor';
import {MyWorkPageConstants} from '../../../page-objects/pages/my-workplace/my-work/my-work-page.constants';
import {MyWorkPageHelper} from '../../../page-objects/pages/my-workplace/my-work/my-work-page.helper';
import {ExpectationHelper} from '../../../components/misc-utils/expectation-helper';

describe(SuiteNames.regressionTestSuite, () => {
    let loginPage: LoginPage;
    let stepLogger: StepLogger;
    beforeEach(async () => {
        stepLogger = new StepLogger();
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Verify that View should be saved - [744288]', async () => {
        stepLogger.caseId = 744288;
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
        await PageHelper.click(item);
        await PageHelper.click(MyWorkPage.selectRibbonTabs.views);
        stepLogger.stepId(4);
        stepLogger.step('Click on Save View button.');
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.saveView);
        await ExpectationHelper.verifyDisplayedStatus(MyWorkPage.viewsPopup.defaultView, 'Save View', stepLogger);
        stepLogger.stepId(5);
        stepLogger.step('Enter the Title of the new view name and select the check-box for Personal View' +
            'Click on "OK" button');
        const viewName = await MyWorkPageHelper.fillAndSubmitSaveView();
        // Takes time update current view
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyText(MyWorkPage.getCurrentView, MyWorkPageConstants.currentView, viewName, stepLogger );
    });

    it('Verify that View should be renamed - [744291]', async () => {
        stepLogger.caseId = 744291;
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
        await PageHelper.click(item);
        await PageHelper.click(MyWorkPage.selectRibbonTabs.views);
        stepLogger.stepId(3);
        stepLogger.step('Click on rename View button.');
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.renameView);
        stepLogger.stepId(4);
        stepLogger.step('Enter the Title of the new view name. > Click on "OK" button');
        const viewNewName = await MyWorkPageHelper.fillAndSubmitRenameView();
        stepLogger.stepId(5);
        stepLogger.step('Click on Ok in the pop-up.');
        await PageHelper.acceptAlert();
        // Takes time update current view
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyText(MyWorkPage.getCurrentView,
            MyWorkPageConstants.currentView, viewNewName, stepLogger );
    });

    it('Message while renaming the default view - [744293]', async () => {
        stepLogger.caseId = 744293;
        // preConditions are inside below function
        stepLogger.step('preCondition - click on My Workplace>> Click on My Work >> Views tab');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);
        const item = CommonPage.recordWithoutGreenTicket;
        await PageHelper.click(item);
        await PageHelper.click(MyWorkPage.selectRibbonTabs.views);
        stepLogger.stepId(1);
        stepLogger.step('Verify the default view name get display in "Current View" drop down');
        await ExpectationHelper.verifyDisplayedStatus(MyWorkPage.getCurrentView, MyWorkPageConstants.currentView, stepLogger);
        stepLogger.stepId(2);
        stepLogger.step('Click on rename View button.> provide new name >click on ok');
        const currentViewName = await PageHelper.getText(MyWorkPage.getCurrentView);
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.renameView);
        // Step 2 and 3 are inside the below function
        const viewNewName = await MyWorkPageHelper.fillAndSubmitRenameView();
        await MyWorkPageHelper.verifyAndAcceptRenameConfirmationPopup(currentViewName, stepLogger);
        // Takes time update current view
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyText(MyWorkPage.getCurrentView,
            MyWorkPageConstants.currentView, viewNewName, stepLogger );
    });
});
