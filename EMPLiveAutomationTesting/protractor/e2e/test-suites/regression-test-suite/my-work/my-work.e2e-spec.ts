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

    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        await new LoginPage().goToAndLogin();
    });

    it('Verify that View should be saved - [744288]', async () => {
        StepLogger.caseId = 744288;
        // Step 1 and Step 2 are inside below function
        StepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
        );
        StepLogger.stepId(3);
        StepLogger.step('Click on any of the item, the ribbon panel get enable and Click on View Tab');
        const item = CommonPage.recordWithoutGreenTicket;
        await PageHelper.click(item);
        await PageHelper.click(MyWorkPage.selectRibbonTabs.views);
        StepLogger.stepId(4);
        StepLogger.step('Click on Save View button.');
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.saveView);
        await ExpectationHelper.verifyDisplayedStatus(MyWorkPage.viewsPopup.defaultView, 'Save View');
        StepLogger.stepId(5);
        StepLogger.step('Enter the Title of the new view name and select the check-box for Personal View' +
            'Click on "OK" button');
        const viewName = await MyWorkPageHelper.fillAndSubmitSaveView();
        // Takes time update current view
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyText(MyWorkPage.getCurrentView, MyWorkPageConstants.currentView, viewName);
    });

    it('Verify that View should be renamed - [744291]', async () => {
        StepLogger.caseId = 744291;
        // Step 1 are inside below function
        StepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
        );
        StepLogger.stepId(2);
        StepLogger.step('Click on My work page > Click on View Tab');
        const item = CommonPage.recordWithoutGreenTicket;
        await PageHelper.click(item);
        await PageHelper.click(MyWorkPage.selectRibbonTabs.views);
        StepLogger.stepId(3);
        StepLogger.step('Click on rename View button.');
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.renameView);
        StepLogger.stepId(4);
        StepLogger.step('Enter the Title of the new view name. > Click on "OK" button');
        const viewNewName = await MyWorkPageHelper.fillAndSubmitRenameView();
        StepLogger.stepId(5);
        StepLogger.step('Click on Ok in the pop-up.');
        await PageHelper.acceptAlert();
        // Takes time update current view
        await browser.sleep(PageHelper.timeout.xs);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
        );
        await ExpectationHelper.verifyText(MyWorkPage.getCurrentView,
            MyWorkPageConstants.currentView, viewNewName);
    });

    it('Message while renaming the default view - [744293]', async () => {
        StepLogger.caseId = 744293;
        // preConditions are inside below function
        StepLogger.step('preCondition - click on My Workplace>> Click on My Work >> Views tab');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
        );
        const item = CommonPage.recordWithoutGreenTicket;
        await PageHelper.click(item);
        await PageHelper.click(MyWorkPage.selectRibbonTabs.views);
        StepLogger.stepId(1);
        StepLogger.step('Verify the default view name get display in "Current View" drop down');
        await ExpectationHelper.verifyDisplayedStatus(MyWorkPage.getCurrentView, MyWorkPageConstants.currentView);
        StepLogger.stepId(2);
        StepLogger.step('Click on rename View button.> provide new name >click on ok');
        const currentViewName = await PageHelper.getText(MyWorkPage.getCurrentView);
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.renameView);
        // Step 2 and 3 are inside the below function
        const viewNewName = await MyWorkPageHelper.fillAndSubmitRenameView();
        await MyWorkPageHelper.verifyAndAcceptRenameConfirmationPopup(currentViewName);
        // Takes time update current view
        await browser.sleep(PageHelper.timeout.xs);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
        );
        await ExpectationHelper.verifyText(MyWorkPage.getCurrentView,
            MyWorkPageConstants.currentView, viewNewName);
    });
});
