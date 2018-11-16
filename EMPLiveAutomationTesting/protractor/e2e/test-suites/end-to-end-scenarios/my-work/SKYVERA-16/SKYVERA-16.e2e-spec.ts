import {SuiteNames} from '../../../helpers/suite-names';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {MyWorkPageHelper} from '../../../../page-objects/pages/my-workplace/my-work/my-work-page.helper';

describe(SuiteNames.endToEndSuite, () => {

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        await new LoginPage().goToAndLogin();
        StepLogger.preCondition('User should be on "My Work" page.');
        await MyWorkPageHelper.navigateToMyWork();
        await MyWorkPageHelper.verifyMyWorkPageDisplayed();
    });

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    it('Save View via Save View button. - [745105]', async () => {
        StepLogger.caseId = 745105;

        StepLogger.stepId(1);
        await MyWorkPageHelper.clickViewsTab();
        await MyWorkPageHelper.verifyViewRibbonDisplayed();

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickSelectColumns();
        await MyWorkPageHelper.verifyButtonsOnSelectColumns();

        StepLogger.stepId(3);
        const columnSelected = await MyWorkPageHelper.selectColumn();
        await MyWorkPageHelper.verifySelectedColumnDisplayed(columnSelected);

        StepLogger.stepId(4);
        await MyWorkPageHelper.clickSaveView();
        await MyWorkPageHelper.verifySaveViewPopupDisplayed();

        StepLogger.stepId(5);
        const viewName = await MyWorkPageHelper.fillNameAndSubmitSaveView();
        await MyWorkPageHelper.verifyViewName(viewName);
    });

    it('Check the validation when User tries to save view with blank name. - [745106]', async () => {
        StepLogger.caseId = 745106;

        StepLogger.stepId(1);
        await MyWorkPageHelper.clickViewsTab();
        await MyWorkPageHelper.verifyViewRibbonDisplayed();

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickSelectColumns();
        await MyWorkPageHelper.verifyButtonsOnSelectColumns();

        StepLogger.stepId(3);
        const columnSelected = await MyWorkPageHelper.selectColumn();
        await MyWorkPageHelper.verifySelectedColumnDisplayed(columnSelected);

        StepLogger.stepId(4);
        await MyWorkPageHelper.clickSaveView();
        await MyWorkPageHelper.verifySaveViewPopupDisplayed();

        StepLogger.stepId(5);
        await MyWorkPageHelper.deleteNameInSaveViewSubmit();
        await MyWorkPageHelper.verifyEmptyNameMessage();

        StepLogger.stepId(6);
        await MyWorkPageHelper.clickOKAlert();
        await MyWorkPageHelper.verifySaveViewPopupDisplayed();
    });

    it('Check Cancel button of Save and Rename View pop-up. - [745108]', async () => {
        StepLogger.caseId = 745108;

        StepLogger.stepId(1);
        await MyWorkPageHelper.clickViewsTab();
        await MyWorkPageHelper.verifyViewRibbonDisplayed();

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickSaveView();
        await MyWorkPageHelper.verifySaveViewPopupDisplayed();

        StepLogger.stepId(3);
        const currentView = await MyWorkPageHelper.enterTextOnSaveViewTitle();
        await MyWorkPageHelper.clickCancelButtonViewsPopup();
        await MyWorkPageHelper.verifyViewName(currentView);

        StepLogger.stepId(4);
        const currentViewName = await MyWorkPageHelper.selectViewFromCurrentView();
        await MyWorkPageHelper.clickRenameView(false);
        await MyWorkPageHelper.verifyRenameViewDisplayed();

        StepLogger.stepId(5);
        await MyWorkPageHelper.enterNewName();
        await MyWorkPageHelper.clickCancelButtonViewsPopup();
        await MyWorkPageHelper.verifyViewName(currentViewName, false);
    });

    it('Delete View. - [745109]', async () => {
        StepLogger.caseId = 745109;

        StepLogger.stepId(1);
        await MyWorkPageHelper.goToSaveView();
        await MyWorkPageHelper.verifySaveViewPopupDisplayed();

        StepLogger.stepId(2);
        const currentViewName = await MyWorkPageHelper.fillNameAndSubmitSaveView();
        await MyWorkPageHelper.verifyViewName(currentViewName);

        StepLogger.stepId(3);
        await MyWorkPageHelper.clickDeleteView();
        await MyWorkPageHelper.verifyDeleteViewPopup(currentViewName);

        StepLogger.stepId(4);
        await MyWorkPageHelper.clickOKonDeleteViewPopup();
        await MyWorkPageHelper.verifyViewDeleted(currentViewName);
    });

    it('Verify functionality of Cancel button of Delete View pop-up. - [745110]', async () => {
        StepLogger.caseId = 745110;

        StepLogger.stepId(1);
        await PageHelper.switchToDefaultContent();
        await MyWorkPageHelper.clickViewsTab();
        await MyWorkPageHelper.verifyViewRibbonDisplayed();

        StepLogger.stepId(2);
        const currentViewName = await MyWorkPageHelper.selectViewFromCurrentView();
        await MyWorkPageHelper.clickDeleteView();

        StepLogger.stepId(3);
        await MyWorkPageHelper.dismissDeletePopup();
        await MyWorkPageHelper.verifyViewName(currentViewName, false);
    });
});
