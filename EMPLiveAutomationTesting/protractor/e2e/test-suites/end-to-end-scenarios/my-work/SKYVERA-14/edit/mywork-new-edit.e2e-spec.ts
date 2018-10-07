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

    it('Create New "To Do" Item. - [745088]', async () => {
        StepLogger.stepId(2);
        StepLogger.step(`Click on "Manage" tab and Expand the "New Item" drop-down.`);
        await MyWorkPageHelper.clickOnManageTab();
        await MyWorkPageHelper.expandNewItem();

        StepLogger.verification(`Dropdown with various menu should be displayed.`);
        await MyWorkPageHelper.newItemsDropdownDisplayed();

        StepLogger.stepId(3);
        StepLogger.step(`Click on "To Do Item".`);
        await MyWorkPageHelper.clickToDoItem();
        StepLogger.verification(`Verify that the new pop-up should open.`);
        await  MyWorkPageHelper.verifyToDoNewItemPopupDisplayed();

        StepLogger.stepId(4);
        StepLogger.step(`Populate the necessary fields, Enter resource name in "Assigned To" field(for e.g. Administrator.) Click on "Save" button. `);
        const todoTitle = await MyWorkPageHelper.fillNewItemFormForTodo();
        StepLogger.verification(`Verify that the new item should be created successfully
        and should get display in the grid [In case if created item is assigned to logged in user].`);
        await MyWorkPageHelper.verifyToDoCreateItem(todoTitle);

    });

    // Jira References - SKYVERA-14
    fit('Create New "Time-Offs" Item. - [745087]', async () => {
        StepLogger.stepId(2);
        StepLogger.step(`Click on "Manage" tab.`);
        await MyWorkPageHelper.clickOnManageTab();
        StepLogger.verification(`Manage tab should be displayed.`);
        await  MyWorkPageHelper.verifyManageTabDisplayed();

        StepLogger.stepId(3);
        StepLogger.step(`Expand the "New Item" drop-down, Click on "Time-Offs Item`);
        await MyWorkPageHelper.expandNewItem();
        await  MyWorkPageHelper.clickTimeOffItem();

        StepLogger.verification(`Verify that the new pop-up should open.`);
        await  MyWorkPageHelper.verifyTimeOffNewItemPopupDisplayed();

        StepLogger.stepId(4);
        StepLogger.step(`Populate the necessary fields, Enter resource name in "Assigned To" field(for e.g. Administrator.)Click on "Save" button.`);
        const title = await MyWorkPageHelper.fillNewItemFormForTimeoff();

        StepLogger.verification(`Verify that the new item should be created successfully.`);
        await MyWorkPageHelper.verifyToDoCreateItem(title);

    });

});
