import {SuiteNames} from '../../../helpers/suite-names';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {MyWorkPageHelper} from '../../../../page-objects/pages/my-workplace/my-work/my-work-page.helper';

describe(SuiteNames.endToEndSuite, () => {
    let stepLogger: StepLogger;
    beforeEach(async () => {
        stepLogger = new StepLogger();
        await PageHelper.maximizeWindow();
        await new LoginPage().goToAndLogin();
        stepLogger.preCondition('User should be on "My Work" page.');
        await MyWorkPageHelper.navigateToMyWork(stepLogger);
        await MyWorkPageHelper.verifyMyWorkPageDisplayed(stepLogger);
    });

    it('Save View via Save View button. - [745105]', async () => {
        stepLogger.caseId = 745105;

        stepLogger.stepId(1);
        await MyWorkPageHelper.clickViewsTab(stepLogger);
        await MyWorkPageHelper.verifyViewRibbonDisplayed(stepLogger);

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickSelectColumns(stepLogger);
        await MyWorkPageHelper.verifyButtonsOnSelectColumns(stepLogger);

        stepLogger.stepId(3);
        const columnSelected = await MyWorkPageHelper.selectColumn(stepLogger);
        await MyWorkPageHelper.verifySelectedColumnDisplayed(columnSelected, stepLogger);

        stepLogger.stepId(4);
        await MyWorkPageHelper.clickSaveView(stepLogger);
        await MyWorkPageHelper.verifySaveViewPopupDisplayed(stepLogger);

        stepLogger.stepId(5);
        const viewName = await MyWorkPageHelper.fillNameAndSubmitSaveView(stepLogger);
        await MyWorkPageHelper.verifyViewName(viewName, stepLogger);
    });

    it('Check the validation when User tries to save view with blank name. - [745106]', async () => {
        stepLogger.caseId = 745106;

        stepLogger.stepId(1);
        await MyWorkPageHelper.clickViewsTab(stepLogger);
        await MyWorkPageHelper.verifyViewRibbonDisplayed(stepLogger);

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickSelectColumns(stepLogger);
        await MyWorkPageHelper.verifyButtonsOnSelectColumns(stepLogger);

        stepLogger.stepId(3);
        const columnSelected = await MyWorkPageHelper.selectColumn(stepLogger);
        await MyWorkPageHelper.verifySelectedColumnDisplayed(columnSelected, stepLogger);

        stepLogger.stepId(4);
        await MyWorkPageHelper.clickSaveView(stepLogger);
        await MyWorkPageHelper.verifySaveViewPopupDisplayed(stepLogger);

        stepLogger.stepId(5);
        await MyWorkPageHelper.deleteNameInSaveViewSubmit(stepLogger);
        await MyWorkPageHelper.verifyEmptyNameMessage(stepLogger);

        stepLogger.stepId(6);
        await MyWorkPageHelper.clickOKAlert(stepLogger);
        await MyWorkPageHelper.verifySaveViewPopupDisplayed(stepLogger);
    });

    it('Check Cancel button of Save and Rename View pop-up. - [745108]', async () => {
        stepLogger.caseId = 745108;

        stepLogger.stepId(1);
        await MyWorkPageHelper.clickViewsTab(stepLogger);
        await MyWorkPageHelper.verifyViewRibbonDisplayed(stepLogger);

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickSaveView(stepLogger);
        await MyWorkPageHelper.verifySaveViewPopupDisplayed(stepLogger);

        stepLogger.stepId(3);
        const currentView = await MyWorkPageHelper.enterTextOnSaveViewTitle(stepLogger);
        await MyWorkPageHelper.clickCancelButtonViewsPopup(stepLogger);
        await MyWorkPageHelper.verifyViewName(currentView, stepLogger);

        stepLogger.stepId(4);
        const currentViewName = await MyWorkPageHelper.selectViewFromCurrentView(stepLogger);
        await MyWorkPageHelper.clickRenameView(stepLogger);
        await MyWorkPageHelper.verifyRenameViewDisplayed(stepLogger);

        stepLogger.stepId(5);
        await MyWorkPageHelper.enterNewName(stepLogger);
        await MyWorkPageHelper.clickCancelButtonViewsPopup(stepLogger);
        await MyWorkPageHelper.verifyViewName(currentViewName, stepLogger);
    });

    it('Delete View. - [745109]', async () => {
        stepLogger.caseId = 745109;

        stepLogger.stepId(1);
        await MyWorkPageHelper.goToSaveView(stepLogger);
        await MyWorkPageHelper.verifySaveViewPopupDisplayed(stepLogger);

        stepLogger.stepId(2);
        const currentViewName = await MyWorkPageHelper.fillNameAndSubmitSaveView(stepLogger);
        await MyWorkPageHelper.verifyViewName(currentViewName, stepLogger);

        stepLogger.stepId(3);
        await MyWorkPageHelper.clickDeleteView(stepLogger);
        await MyWorkPageHelper.verifyDeleteViewPopup(currentViewName, stepLogger);

        stepLogger.stepId(4);
        await MyWorkPageHelper.clickOKonDeleteViewPopup(stepLogger);
        await MyWorkPageHelper.verifyViewDeleted(currentViewName, stepLogger);
    });

    it('Verify functionality of Cancel button of Delete View pop-up. - [745110]', async () => {
        stepLogger.caseId = 745110;

        stepLogger.stepId(1);
        await MyWorkPageHelper.clickViewsTab(stepLogger);
        await MyWorkPageHelper.verifyViewRibbonDisplayed(stepLogger);

        stepLogger.stepId(2);
        const currentViewName = await MyWorkPageHelper.selectViewFromCurrentView(stepLogger);
        await MyWorkPageHelper.clickDeleteView(stepLogger);

        stepLogger.stepId(3);
        await MyWorkPageHelper.dismissDeletePopup(stepLogger);
        await MyWorkPageHelper.verifyViewName(currentViewName, stepLogger);
    });
});
