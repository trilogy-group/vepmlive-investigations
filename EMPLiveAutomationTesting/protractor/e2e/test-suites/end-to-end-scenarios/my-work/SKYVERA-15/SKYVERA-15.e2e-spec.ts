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

    fit('"Edit Item" via "Edit Item" button. - [745091]', async () => {
        stepLogger.caseId = 745091;

        stepLogger.stepId(1);
        await MyWorkPageHelper.clickOnAnyCreatedItem(stepLogger);
        await MyWorkPageHelper.verifyEditItemButtonEnabled(stepLogger);

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickOnEditItem(stepLogger);
        await MyWorkPageHelper.verifyEditPageOpened(stepLogger);

        stepLogger.stepId(3);
        const editedItemTitle = await MyWorkPageHelper.editTitle(stepLogger);
        await MyWorkPageHelper.clickSaveButton(stepLogger);
        await MyWorkPageHelper.verifyCreateItem(editedItemTitle, stepLogger);

        stepLogger.stepId(4);
        await MyWorkPageHelper.clickOnAnyCreatedItem(stepLogger);
        await MyWorkPageHelper.clickOnEditItem(stepLogger);
        const editedItemTitleForCancel = await MyWorkPageHelper.editTitle(stepLogger);

        stepLogger.stepId(5);
        await MyWorkPageHelper.clickCancelButton(stepLogger);
        await MyWorkPageHelper.verifyChangesNotReflected(editedItemTitleForCancel, stepLogger);
    });

    fit('"Close the Edit item pop-up via Close button/icon. - [745095]', async () => {
        stepLogger.caseId = 745095;

        stepLogger.stepId(1);
        await MyWorkPageHelper.clickOnAnyCreatedItem(stepLogger);
        await MyWorkPageHelper.verifyEditItemButtonEnabled(stepLogger);

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickOnEditItem(stepLogger);
        await MyWorkPageHelper.verifyEditPageOpened(stepLogger);

        stepLogger.stepId(3);
        const editedItemTitleForCancel = await MyWorkPageHelper.editTitle(stepLogger);
        await MyWorkPageHelper.clickCancelIcon(stepLogger);
        await MyWorkPageHelper.verifyChangesNotReflected(editedItemTitleForCancel, stepLogger);
    });

    fit('Edit the comments. - [745098]', async () => {
        stepLogger.caseId = 745098;

        stepLogger.stepId(1);
        await MyWorkPageHelper.clickOnAnyCreatedItem(stepLogger);
        await MyWorkPageHelper.verifyCommentButtonEnabled(stepLogger);

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickOnComment(stepLogger);
        const commentText = await MyWorkPageHelper.addComment(stepLogger);

        stepLogger.stepId(3);
        await MyWorkPageHelper.clickOnPost(stepLogger);
        await MyWorkPageHelper.verifyCommentedPost(commentText, stepLogger);

        stepLogger.stepId(4);
        await MyWorkPageHelper.clickEditOnAnyComment(stepLogger);
        const editedText = await MyWorkPageHelper.editComment(stepLogger);

        stepLogger.stepId(5);
        await MyWorkPageHelper.clickOnPostForEditComment(stepLogger);
        await MyWorkPageHelper.verifyCommentedPost(editedText, stepLogger);
    });
});
