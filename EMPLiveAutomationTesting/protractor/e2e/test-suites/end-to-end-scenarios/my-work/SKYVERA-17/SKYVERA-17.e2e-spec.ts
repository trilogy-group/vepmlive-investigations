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

    it('User should not be able to delete/rename default View. - [745111]', async () => {
        stepLogger.caseId = 745111;

        stepLogger.stepId(1);
        await MyWorkPageHelper.clickViewsTab(stepLogger);
        await MyWorkPageHelper.selectDefaultView(stepLogger);
        await MyWorkPageHelper.verifyDefaultViewName(stepLogger);

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickDeleteView(stepLogger);
        await MyWorkPageHelper.verifyDeleletViewMessageForDefaultView(stepLogger);

        stepLogger.stepId(3);
        await MyWorkPageHelper.clickOKAlert(stepLogger);
        await MyWorkPageHelper.verifyAlertClosed(stepLogger);

        stepLogger.stepId(4);
        await MyWorkPageHelper.clickRenameView(stepLogger);
        await MyWorkPageHelper.verifyRenameViewMessageForDefaultView(stepLogger);

        stepLogger.stepId(5);
        await MyWorkPageHelper.clickOKAlert(stepLogger);
        await MyWorkPageHelper.verifyAlertClosed(stepLogger);
    });

    it('Filter grid via Show Filters button. - [745116]', async () => {
        stepLogger.caseId = 745116;

        stepLogger.stepId(1);
        await MyWorkPageHelper.clickViewsTab(stepLogger);
        await MyWorkPageHelper.clickOnShowFilters(stepLogger);
        await MyWorkPageHelper.verifyExtraRowAdded(stepLogger);

        stepLogger.stepId(2);
        const filterText = await MyWorkPageHelper.getFirstWorkType(stepLogger);
        await MyWorkPageHelper.enterTextOnFilterFields(filterText, stepLogger);
        await MyWorkPageHelper.verifySearchResults(filterText, stepLogger);
    });

    it('Clear sorting via Clear Sorting button. - [745115]', async () => {
        stepLogger.caseId = 745115;

        stepLogger.stepId(1);
        await MyWorkPageHelper.clickViewsTab(stepLogger);
        await MyWorkPageHelper.clickOnAnyColumnHeader(stepLogger);
        await MyWorkPageHelper.verifyColumnSortedDisplayed(stepLogger);

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickOnRemoveSorting(stepLogger);
        await MyWorkPageHelper.verifySortedRemoved(stepLogger);
    });

    it('Change current view. - [745101]', async () => {
        stepLogger.caseId = 745101;

        stepLogger.stepId(1);
        await MyWorkPageHelper.clickOnManageTab(stepLogger);
        await MyWorkPageHelper.expandCurrentView(stepLogger);

        stepLogger.stepId(2);
        const viewName = await MyWorkPageHelper.verifySavedViewDisplayed(stepLogger);

        stepLogger.stepId(3);
        await MyWorkPageHelper.clickOnNewlyCreatedView(viewName, stepLogger);
        await MyWorkPageHelper.verifyViewName(viewName, stepLogger);
    });

    it('Verify the Select Columns Feature. - [745114]', async () => {
        stepLogger.caseId = 745114;

        stepLogger.stepId(1);
        await MyWorkPageHelper.clickViewsTab(stepLogger);
        await MyWorkPageHelper.clickSelectColumns(stepLogger);
        await MyWorkPageHelper.verifyButtonsOnSelectColumns(stepLogger);

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickCancelOnSelectColumnsPopup(stepLogger);
        await MyWorkPageHelper.verifySelectColumnPopupClosed(stepLogger);

        stepLogger.stepId(3);
        await MyWorkPageHelper.clickSelectColumns(stepLogger);
        await MyWorkPageHelper.clickOnHideAllButton(stepLogger);
        await MyWorkPageHelper.verifyHideAllFunctionality(stepLogger);

        stepLogger.stepId(4);
        await MyWorkPageHelper.clickOnShowAllButton(stepLogger);
        await MyWorkPageHelper.verifyShowAllFunctionality(stepLogger);

        stepLogger.stepId(5);
        const selectedColNames = await MyWorkPageHelper.selectAllColumnsAndSubmit(stepLogger);
        await MyWorkPageHelper.verifySelectedColumnsDisplayed(selectedColNames, stepLogger);
    });

});
