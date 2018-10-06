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

    it('"Edit Item" via "Edit Item" button. - [745091]', async () => {
        StepLogger.caseId = 745091;

        StepLogger.stepId(1);
        await MyWorkPageHelper.clickOnAnyCreatedItem();
        await MyWorkPageHelper.verifyEditItemButtonEnabled();

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickOnEditItem();
        await MyWorkPageHelper.verifyEditPageOpened();

        StepLogger.stepId(3);
        const editedItemTitle = await MyWorkPageHelper.editTitle();
        await MyWorkPageHelper.clickSaveButton();
        await MyWorkPageHelper.verifyCreateItem(editedItemTitle);

        StepLogger.stepId(4);
        await MyWorkPageHelper.clickOnAnyCreatedItem();
        await MyWorkPageHelper.clickOnEditItem();
        const editedItemTitleForCancel = await MyWorkPageHelper.editTitle();

        StepLogger.stepId(5);
        await MyWorkPageHelper.clickCancelButton();
        await MyWorkPageHelper.verifyChangesNotReflected(editedItemTitleForCancel);
    });

    it('"Close the Edit item pop-up via Close button/icon. - [745095]', async () => {
        StepLogger.caseId = 745095;

        StepLogger.stepId(1);
        await MyWorkPageHelper.clickOnAnyCreatedItem();
        await MyWorkPageHelper.verifyEditItemButtonEnabled();

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickOnEditItem();
        await MyWorkPageHelper.verifyEditPageOpened();

        StepLogger.stepId(3);
        const editedItemTitleForCancel = await MyWorkPageHelper.editTitle();
        await MyWorkPageHelper.clickCancelIcon();
        await MyWorkPageHelper.verifyChangesNotReflected(editedItemTitleForCancel);
    });

    it('Edit the comments. - [745098]', async () => {
        StepLogger.caseId = 745098;

        StepLogger.stepId(1);
        await MyWorkPageHelper.clickOnAnyCreatedItem();
        await MyWorkPageHelper.verifyCommentButtonEnabled();

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickOnComment();
        const commentText = await MyWorkPageHelper.addComment();

        StepLogger.stepId(3);
        await MyWorkPageHelper.clickOnPost();
        await MyWorkPageHelper.verifyCommentedPost(commentText);

        StepLogger.stepId(4);
        await MyWorkPageHelper.clickEditOnAnyComment();
        const editedText = await MyWorkPageHelper.editComment();

        StepLogger.stepId(5);
        await MyWorkPageHelper.clickOnPostForEditComment();
        await MyWorkPageHelper.verifyCommentedPost(editedText);
    });
});
