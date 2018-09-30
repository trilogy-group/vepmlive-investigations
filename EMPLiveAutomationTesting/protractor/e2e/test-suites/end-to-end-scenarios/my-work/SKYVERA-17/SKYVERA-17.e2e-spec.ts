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

    it('User should not be able to delete/rename default View. - [745111]', async () => {
        StepLogger.caseId = 745111;

        StepLogger.stepId(1);
        await MyWorkPageHelper.clickViewsTab();
        await MyWorkPageHelper.selectDefaultView();
        await MyWorkPageHelper.verifyDefaultViewName();

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickDeleteView();
        await MyWorkPageHelper.verifyDeleletViewMessageForDefaultView();

        StepLogger.stepId(3);
        await MyWorkPageHelper.clickOKAlert();
        await MyWorkPageHelper.verifyAlertClosed();

        StepLogger.stepId(4);
        await MyWorkPageHelper.clickRenameView();
        await MyWorkPageHelper.verifyRenameViewMessageForDefaultView();

        StepLogger.stepId(5);
        await MyWorkPageHelper.clickOKAlert();
        await MyWorkPageHelper.verifyAlertClosed();
    });

    it('Filter grid via Show Filters button. - [745116]', async () => {
        StepLogger.caseId = 745116;

        StepLogger.stepId(1);
        await MyWorkPageHelper.clickViewsTab();
        await MyWorkPageHelper.clickOnShowFilters();
        await MyWorkPageHelper.verifyExtraRowAdded();

        StepLogger.stepId(2);
        const filterText = await MyWorkPageHelper.getFirstWorkType();
        await MyWorkPageHelper.enterTextOnFilterFields(filterText);
        await MyWorkPageHelper.verifySearchResults(filterText);
    });

    it('Clear sorting via Clear Sorting button. - [745115]', async () => {
        StepLogger.caseId = 745115;

        StepLogger.stepId(1);
        await MyWorkPageHelper.clickViewsTab();
        await MyWorkPageHelper.clickOnAnyColumnHeader();
        await MyWorkPageHelper.verifyColumnSortedDisplayed();

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickOnRemoveSorting();
        await MyWorkPageHelper.verifySortedRemoved();
    });

    it('Change current view. - [745101]', async () => {
        StepLogger.caseId = 745101;

        StepLogger.stepId(1);
        await MyWorkPageHelper.clickOnManageTab();
        await MyWorkPageHelper.expandCurrentView();

        StepLogger.stepId(2);
        const viewName = await MyWorkPageHelper.verifySavedViewDisplayed();

        StepLogger.stepId(3);
        await MyWorkPageHelper.clickOnNewlyCreatedView(viewName);
        await MyWorkPageHelper.verifyViewName(viewName);
    });

    it('Verify the Select Columns Feature. - [745114]', async () => {
        StepLogger.caseId = 745114;

        StepLogger.stepId(1);
        await MyWorkPageHelper.clickViewsTab();
        await MyWorkPageHelper.clickSelectColumns();
        await MyWorkPageHelper.verifyButtonsOnSelectColumns();

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickCancelOnSelectColumnsPopup();
        await MyWorkPageHelper.verifySelectColumnPopupClosed();

        StepLogger.stepId(3);
        await MyWorkPageHelper.clickSelectColumns();
        await MyWorkPageHelper.clickOnHideAllButton();
        await MyWorkPageHelper.verifyHideAllFunctionality();

        StepLogger.stepId(4);
        await MyWorkPageHelper.clickOnShowAllButton();
        await MyWorkPageHelper.verifyShowAllFunctionality();

        StepLogger.stepId(5);
        const selectedColNames = await MyWorkPageHelper.selectAllColumnsAndSubmit();
        await MyWorkPageHelper.verifySelectedColumnsDisplayed(selectedColNames);
    });

});
