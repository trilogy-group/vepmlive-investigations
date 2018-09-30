import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {MyWorkPageHelper} from '../../../../../page-objects/pages/my-workplace/my-work/my-work-page.helper';

describe(SuiteNames.endToEndSuite, () => {

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        await new LoginPage().goToAndLogin();

        StepLogger.stepId(1);
        await MyWorkPageHelper.navigateToMyWork();
        await MyWorkPageHelper.verifyMyWorkPageDisplayed();

    });

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    it('Stop Editing via Stop-Editing option. - [745080]', async () => {
        StepLogger.caseId = 745080;

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickOnPageTab();
        await MyWorkPageHelper.verifyPageTabIsSelected();

        StepLogger.stepId(3);
        await MyWorkPageHelper.expandEditPageDropdown();
        await MyWorkPageHelper.verifyEditPageDropdownOptions();

        StepLogger.stepId(4);
        await MyWorkPageHelper.clickOnEditPageMenuOption();
        await MyWorkPageHelper.verifyEditPageOpened();

        StepLogger.stepId(5);
        await MyWorkPageHelper.clickStopEditing();
        await MyWorkPageHelper.verifyManageTabDisplayed();
    });

    it('Create New "Changes" Item. - [745084]', async () => {
        StepLogger.caseId = 745084;

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickOnManageTab();
        await MyWorkPageHelper.verifyManageTabDisplayed();

        StepLogger.stepId(3);
        await MyWorkPageHelper.goToNewChangesItem();
        await MyWorkPageHelper.verifyChangesNewItemPopupDisplayed();

        StepLogger.stepId(4);
        const changesTitle = await MyWorkPageHelper.fillNewItemFormForChanges();
        await MyWorkPageHelper.verifyCreateItem(changesTitle);
    });

    it('Create New "Issues" Item. - [745085]', async () => {
        StepLogger.caseId = 745085;

        StepLogger.stepId(2);
        await MyWorkPageHelper.expandNewItem();
        await MyWorkPageHelper.newItemsDropdownDisplayed();

        StepLogger.stepId(3);
        await MyWorkPageHelper.clickIssuesItem();
        await MyWorkPageHelper.verifyIssuesNewItemPopupDisplayed();

        StepLogger.stepId(4);
        const issuesTitle = await MyWorkPageHelper.fillNewItemFormForIssues();
        await MyWorkPageHelper.verifyCreateItem(issuesTitle);
    });

    it('Create New "Risks" Item. - [745086]', async () => {
        StepLogger.caseId = 745086;

        StepLogger.stepId(2);
        await MyWorkPageHelper.expandNewItem();
        await MyWorkPageHelper.newItemsDropdownDisplayed();

        StepLogger.stepId(3);
        await MyWorkPageHelper.clickRisksItem();
        await MyWorkPageHelper.verifyRisksNewItemPopupDisplayed();

        StepLogger.stepId(4);
        const risksTitle = await MyWorkPageHelper.fillNewItemFormForRisks();
        await MyWorkPageHelper.verifyCreateItem(risksTitle);
    });

    it('Check validation while creating new item. - [745089]', async () => {
        StepLogger.caseId = 745089;

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickOnManageTab();
        await MyWorkPageHelper.verifyManageTabDisplayed();

        StepLogger.stepId(3);
        await MyWorkPageHelper.goToDoNewItem();
        await MyWorkPageHelper.verifyToDoNewItemPopupDisplayed();

        StepLogger.stepId(4);
        await MyWorkPageHelper.clickSaveButton(true);
        await MyWorkPageHelper.verifyTitleValidationMessage();

        StepLogger.stepId(5);
        await MyWorkPageHelper.clickCancelButton();
        await MyWorkPageHelper.verifyPopupClosed();
    });
});
