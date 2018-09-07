import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {MyWorkPageHelper} from '../../../../../page-objects/pages/my-workplace/my-work/my-work-page.helper';

describe(SuiteNames.endToEndSuite, () => {
    let stepLogger: StepLogger;
    beforeEach(async () => {
        stepLogger = new StepLogger();
        await PageHelper.maximizeWindow();
        await new LoginPage().goToAndLogin();

        stepLogger.stepId(1);
        await MyWorkPageHelper.navigateToMyWork(stepLogger);
        await MyWorkPageHelper.verifyMyWorkPageDisplayed(stepLogger);

    });

    fit('Stop Editing via Stop-Editing option. - [745080]', async () => {
        stepLogger.caseId = 745080;

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickOnPageTab(stepLogger);
        await MyWorkPageHelper.verifyPageTabIsSelected(stepLogger);

        stepLogger.stepId(3);
        await MyWorkPageHelper.expandEditPageDropdown(stepLogger);
        await MyWorkPageHelper.verifyEditPageDropdownOptions(stepLogger);

        stepLogger.stepId(4);
        await MyWorkPageHelper.clickOnEditPageMenuOption(stepLogger);
        await MyWorkPageHelper.verifyEditPageOpened(stepLogger);

        stepLogger.stepId(5);
        await MyWorkPageHelper.clickStopEditing(stepLogger);
        await MyWorkPageHelper.verifyManageTabDisplayed(stepLogger);
    });

    fit('Create New "Changes" Item. - [745084]', async () => {
        stepLogger.caseId = 745084;

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickOnManageTab(stepLogger);
        await MyWorkPageHelper.verifyManageTabDisplayed(stepLogger);

        stepLogger.stepId(3);
        await MyWorkPageHelper.goToNewChangesItem(stepLogger);
        await MyWorkPageHelper.verifyChangesNewItemPopupDisplayed(stepLogger);

        stepLogger.stepId(4);
        const changesTitle = await MyWorkPageHelper.fillNewItemFormForChanges(stepLogger);
        await MyWorkPageHelper.verifyCreateItem(changesTitle, stepLogger);
    });

    fit('Create New "Issues" Item. - [745085]', async () => {
        stepLogger.caseId = 745085;

        stepLogger.stepId(2);
        await MyWorkPageHelper.expandNewItem(stepLogger);
        await MyWorkPageHelper.newItemsDropdownDisplayed(stepLogger);

        stepLogger.stepId(3);
        await MyWorkPageHelper.clickIssuesItem(stepLogger);
        await MyWorkPageHelper.verifyIssuesNewItemPopupDisplayed(stepLogger);

        stepLogger.stepId(4);
        const issuesTitle = await MyWorkPageHelper.fillNewItemFormForIssues(stepLogger);
        await MyWorkPageHelper.verifyCreateItem(issuesTitle, stepLogger);
    });

    fit('Create New "Risks" Item. - [745086]', async () => {
        stepLogger.caseId = 745086;

        stepLogger.stepId(2);
        await MyWorkPageHelper.expandNewItem(stepLogger);
        await MyWorkPageHelper.newItemsDropdownDisplayed(stepLogger);

        stepLogger.stepId(3);
        await MyWorkPageHelper.clickRisksItem(stepLogger);
        await MyWorkPageHelper.verifyRisksNewItemPopupDisplayed(stepLogger);

        stepLogger.stepId(4);
        const risksTitle = await MyWorkPageHelper.fillNewItemFormForRisks(stepLogger);
        await MyWorkPageHelper.verifyCreateItem(risksTitle, stepLogger);
    });

    fit('Check validation while creating new item. - [745089]', async () => {
        stepLogger.caseId = 745089;

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickOnManageTab(stepLogger);
        await MyWorkPageHelper.verifyManageTabDisplayed(stepLogger);

        stepLogger.stepId(3);
        await MyWorkPageHelper.goToDoNewItem(stepLogger);
        await MyWorkPageHelper.verifyToDoNewItemPopupDisplayed(stepLogger);

        stepLogger.stepId(4);
        await MyWorkPageHelper.clickSaveButton(stepLogger, true);
        await MyWorkPageHelper.verifyTitleValidationMessage(stepLogger);

        stepLogger.stepId(5);
        await MyWorkPageHelper.clickCancelButton(stepLogger);
        await MyWorkPageHelper.verifyPopupClosed(stepLogger);
    });
});
