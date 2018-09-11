import {MyWorkPageConstants} from './my-work-page.constants';
import {CommonPage} from '../../common/common.po';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {CommonPageHelper} from '../../common/common-page.helper';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {MyWorkPage} from './my-work.po';
import {LoginPageHelper} from '../../login/login-page.helper';
import {AnchorHelper} from '../../../../components/html/anchor-helper';
import {CommonPageConstants} from '../../common/common-page.constants';
import {ExpectationHelper} from '../../../../components/misc-utils/expectation-helper';
import {MyWorkplacePage} from '../my-workplace.po';
import {browser} from 'protractor';
import {ElementHelper} from '../../../../components/html/element-helper';

export class MyWorkPageHelper {

    static async fillFormAndSave(stepLogger: StepLogger) {
        const inputLabels = MyWorkPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const titleValue = `${inputLabels.title} ${uniqueId}`;

        stepLogger.step(`Title *: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, titleValue);

        stepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');
        await PageHelper.click(MyWorkPage.dropdownAll.project);
        await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.inputs.project);
        const projectName = await MyWorkPage.inputs.project.getText();
        await PageHelper.click(MyWorkPage.inputs.project);

        stepLogger.verification('Required values entered/selected in Project Field');
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(projectName).isPresent())
            .toBe(true, ValidationsHelper.getFieldShouldHaveValueValidation(inputLabels.project, projectName));

        stepLogger.step(`Assigned To: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.assignedTo, LoginPageHelper.adminEmailId);
        stepLogger.step(`select assignedTo value`);
        await PageHelper.click(MyWorkPage.selectValueFromSuggestions(LoginPageHelper.adminEmailId));

        stepLogger.stepId(5);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"New Item" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(MyWorkPageConstants.editPageName));
        // Wait for the page to close after clicking on save. This is to reduce window close synchronization issues
        await WaitHelper.staticWait(PageHelper.timeout.m);

        stepLogger.verification('Newly created Item [Ex: Title 1] displayed in "My Work" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(titleValue));
    }

    static async fillTimeOffFormAndSave(titleValue: string, stepLogger: StepLogger) {

        stepLogger.step(`Title *: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, titleValue);

        stepLogger.step('Time Off Type *: Select any type from the drop down [Ex: Holiday])');
        await PageHelper.click(MyWorkPage.dropdownAll.timeOffType);
        await PageHelper.click(MyWorkPage.dropdownAll.timeOffInput);

        stepLogger.step(`Requestor* : New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.requestor, LoginPageHelper.adminEmailId);
        stepLogger.step(`select Requester* value`);
        await PageHelper.click(MyWorkPage.selectValueFromSuggestions(LoginPageHelper.adminEmailId));

        stepLogger.step(`Enter Start Date: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.start, CommonPageHelper.getTodayInMMDDYYYY);

        stepLogger.step(`Enter Finish Date: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.finish, CommonPageHelper.getYesterdayInMMDDYYYY);

        stepLogger.stepId(5);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"New Item" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(MyWorkPageConstants.editPageName));
        // Wait for the page to close after clicking on save. This is to reduce window close synchronization issues
        await WaitHelper.staticWait(PageHelper.timeout.m);
    }

    static async clickOnPageTab(stepLogger: StepLogger) {
        stepLogger.step('Click on "Page" tab');
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(CommonPage.ribbonTitles.page);
    }

    static async verifyMyWorkPageDisplayed(stepLogger: StepLogger) {
        stepLogger.verification(`verify "My Work"  page is displayed`);
        const panelHeadingDisplayed = await PageHelper.isElementDisplayed(
            CommonPage.pageHeaders.myWorkplace.myWork);
        await expect(panelHeadingDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            CommonPageConstants.pageHeaders.myWorkplace.myWork));
    }

    static async expandEditPageDropdown(stepLogger: StepLogger) {
        stepLogger.step(`click on "Edit Page" dropdown`);
        await PageHelper.click(MyWorkPage.editPageDropdown);
    }

    static async verifyEditPageDropdownOptions(stepLogger: StepLogger) {
        stepLogger.verification(`verify "Edit Page" option is shown`);
        const editPageDisplayed = await PageHelper.isElementDisplayed(
            MyWorkPage.editPageMenuOption);
        await expect(editPageDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            MyWorkPageConstants.editPageActions.editPage));

        stepLogger.verification(`verify "Stop Editing" option is shown as disabled`);
        const stopEditingDisplayed = await PageHelper.isElementDisplayed(
            MyWorkPage.disabledStopEditingOption);
        await expect(stopEditingDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            MyWorkPageConstants.editPageActions.stopEditing));
    }

    static async clickOnEditPageMenuOption(stepLogger: StepLogger) {
        stepLogger.step(`click on "Edit Page" option from dropdown`);
        await PageHelper.click(MyWorkPage.editPageMenuOption);
    }

    static async verifyEditPageOpened(stepLogger: StepLogger) {
        stepLogger.verification(`verify "Edit Page" opens`);
        const editPageDisplayed = await PageHelper.isElementDisplayed(
            MyWorkPage.editPage);
        await expect(editPageDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            MyWorkPageConstants.editPageActions.editPage));
    }

    static  async verifyPageTabIsSelected(stepLogger: StepLogger) {
        stepLogger.verification(`verify "PageTab" is shown as selected`);
        const tabDisplayed = await PageHelper.isElementDisplayed(MyWorkPage.selectedPageTab);
        await expect(tabDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            CommonPageConstants.ribbonMenuTitles.page));
    }

    static async fillAndSubmitSaveView() {
        const uniqueId = PageHelper.getUniqueId();
        const viewName = `${MyWorkPageConstants.viewName}${uniqueId}`;
        const viewsPopupItems = MyWorkPage.viewsPopup;
        await PageHelper.click(viewsPopupItems.name);
        await TextboxHelper.sendKeys(viewsPopupItems.name, viewName);
        if (!(await viewsPopupItems.defaultView.isSelected())) {
            await PageHelper.click(viewsPopupItems.defaultView);
        }
        if (!(await viewsPopupItems.personalView.isSelected())) {
            await PageHelper.click(viewsPopupItems.personalView);
        }
        await PageHelper.click(viewsPopupItems.ok);
        return viewName;
    }

    static async fillAndSubmitRenameView() {
        const uniqueId = PageHelper.getUniqueId();
        const viewNewName = `${MyWorkPageConstants.renameView}${uniqueId}`;
        await TextboxHelper.sendKeys(MyWorkPage.viewsPopup.newName, viewNewName);
        await PageHelper.click(MyWorkPage.viewsPopup.ok);
        return viewNewName;
    }
    static async verifyAndAcceptRenameConfirmationPopup(viewName: string, stepLogger: StepLogger) {
        const renamePopUpText = await PageHelper.getAlertText();
        const expectedPopUpText = `Would you like to rename the "${viewName}" view?`;
        await ExpectationHelper.verifyStringEqualTo(renamePopUpText, expectedPopUpText, stepLogger);
        await PageHelper.acceptAlert();
    }

    static async navigateToMyWork(stepLogger: StepLogger) {
        const pageHeader = CommonPage.pageHeaders;
        const pageHeaderName = CommonPageConstants.pageHeaders.myWorkplace;
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(MyWorkplacePage.navigation.myWork,
            pageHeader.myWorkplace.myWork, pageHeaderName.myWork, stepLogger);
    }

    static async clickStopEditing(stepLogger: StepLogger) {
        stepLogger.step('Click on Stop Editing button available');
        await this.clickOnPageTab(stepLogger);
        await PageHelper.click(MyWorkPage.stopEditing);
    }

    static async verifyManageTabDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.newItem,
            MyWorkPageConstants.manage,
            stepLogger
        );
    }

    static async clickOnManageTab(stepLogger: StepLogger) {
        stepLogger.step('Click on "Manage" tab.');
        await PageHelper.click(MyWorkPage.selectRibbonTabs.manage);
    }

    static async goToNewChangesItem(stepLogger: StepLogger) {
        await this.expandNewItem(stepLogger);
        stepLogger.step('click on "Changes Item" drop-down.');
        await PageHelper.click(MyWorkPage.newItemMenu.changesItem);
    }

    static async verifyChangesNewItemPopupDisplayed(stepLogger: StepLogger) {
        const changesItemLabel = `${MyWorkPageConstants.newItemTypeLabels.changes} ${MyWorkPageConstants.newItemPopupLabel}`;
        await ExpectationHelper.verifyText(
            MyWorkPage.inputs.heading,
            changesItemLabel,
            MyWorkPageConstants.pageName.changes,
            stepLogger
        );
    }

    static async fillNewItemFormForChanges(stepLogger: StepLogger) {
        return await MyWorkPageHelper.fillNewItemForm(MyWorkPageConstants.newItemTypeLabels.changes, stepLogger);
    }

    static async fillNewItemFormForRisks(stepLogger: StepLogger) {
        return await MyWorkPageHelper.fillNewItemForm(MyWorkPageConstants.newItemTypeLabels.risks, stepLogger);
    }

    static async fillNewItemFormForIssues(stepLogger: StepLogger) {
        return await MyWorkPageHelper.fillNewItemForm(MyWorkPageConstants.newItemTypeLabels.issues, stepLogger);
    }

    static async fillNewItemForm(itemType: string, stepLogger: StepLogger) {
        stepLogger.step('Populate the necessary fields. Enter resource name in "Assigned To"' +
            ' field(for e.g. Administrator.) Click on "Save" button.');
        const uniqueId = PageHelper.getUniqueId();
        const itemTitle = `${itemType} ${uniqueId}`;
        await CommonPageHelper.switchToFirstContentFrame();
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, itemTitle);
        await PageHelper.click(MyWorkPage.dropdownAll.project);
        await PageHelper.click(MyWorkPage.inputs.project);
        const assignedTo = `${MyWorkPageConstants.adMembersLabel}${LoginPageHelper.adminEmailId}`;
        await TextboxHelper.sendKeys(MyWorkPage.inputs.assignedTo, assignedTo);
        await PageHelper.click(MyWorkPage.assignedToSuggestions);
        await this.clickSaveButton(stepLogger);
        return itemTitle;
    }

    static async clickSaveButton(stepLogger: StepLogger, switchToFrame = false) {
        stepLogger.step('Click on save');
        if ( switchToFrame ) {
            await CommonPageHelper.switchToFirstContentFrame();
        }
        await PageHelper.click(MyWorkPage.buttonsOnPopup.save);
    }

    static async verifyCreateItem(itemTitle: string, stepLogger: StepLogger) {
        await browser.sleep(PageHelper.timeout.s);
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.getItemByName(itemTitle),
            itemTitle,
            stepLogger
        );
    }

    static async goToDoNewItem(stepLogger: StepLogger) {
        stepLogger.step('Expand the "New Item < ToDo Item" drop-down.');
        await PageHelper.click(MyWorkPage.newItem);
        await PageHelper.click(MyWorkPage.newItemMenu.toDoItem);
    }

    static async verifyToDoNewItemPopupDisplayed(stepLogger: StepLogger) {
        const toDoPopup = `${MyWorkPageConstants.newItemTypeLabels.toDo} ${MyWorkPageConstants.newItemPopupLabel}`;
        await ExpectationHelper.verifyText(
            MyWorkPage.inputs.heading,
            toDoPopup,
            MyWorkPageConstants.pageName.toDo,
            stepLogger
        );
    }

    static async verifyTitleValidationMessage(stepLogger: StepLogger) {
        await ExpectationHelper.verifyText(
            MyWorkPage.validationMessage,
            MyWorkPageConstants.validationMessageLabel,
            MyWorkPageConstants.blankValidationMessage,
            stepLogger
        );
}

    static async clickCancelButton(stepLogger: StepLogger) {
        stepLogger.step('Click on "Cancel" button');
        await PageHelper.click(MyWorkPage.buttonsOnPopup.cancel);
    }

    static async verifyPopupClosed(stepLogger: StepLogger) {
        const toDoPopup = `${MyWorkPageConstants.newItemTypeLabels.toDo} ${MyWorkPageConstants.newItemPopupLabel}`;
        await ExpectationHelper.verifyNotDisplayedStatus(
            MyWorkPage.inputs.title,
            toDoPopup,
            stepLogger
        );
    }

    static async expandNewItem(stepLogger: StepLogger) {
        stepLogger.step('Expand the "New Item" drop-down.');
        await PageHelper.click(MyWorkPage.newItem);
    }

    static async newItemsDropdownDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.newItemMenu.changesItem,
            MyWorkPageConstants.newItemListLabel,
            stepLogger
        );
    }

    static async clickIssuesItem(stepLogger: StepLogger) {
        stepLogger.step('Click on "Issues Item"');
        await PageHelper.click( MyWorkPage.newItemMenu.issuesItem);
    }

    static async verifyIssuesNewItemPopupDisplayed(stepLogger: StepLogger) {
        const issueItemLabel = `${MyWorkPageConstants.newItemTypeLabels.issues} ${MyWorkPageConstants.newItemPopupLabel}`;
        await ExpectationHelper.verifyText(
            MyWorkPage.inputs.heading,
            issueItemLabel,
            MyWorkPageConstants.pageName.issues,
            stepLogger
        );
    }

    static async verifyRisksNewItemPopupDisplayed(stepLogger: StepLogger) {
        const riskItemLabel = `${MyWorkPageConstants.newItemTypeLabels.risks} ${MyWorkPageConstants.newItemPopupLabel}`;
        await ExpectationHelper.verifyText(
            MyWorkPage.inputs.heading,
            riskItemLabel,
            MyWorkPageConstants.pageName.risks,
            stepLogger
        );
    }

    static async clickRisksItem(stepLogger: StepLogger) {
        stepLogger.step('Click on "Risks Item"');
        await PageHelper.click( MyWorkPage.newItemMenu.risksItem);
    }

    static async clickOnAnyCreatedItem(stepLogger: StepLogger) {
        stepLogger.step('Click on newly created item in the grid.');
        await PageHelper.click(CommonPage.recordWithoutGreenTicket);
    }

    static async verifyEditItemButtonEnabled(stepLogger: StepLogger) {
        await ExpectationHelper.verifyEnabledStatus(
            MyWorkPage.manageTabRibbonItems.editItem,
            MyWorkPageConstants.editItemLabel,
            stepLogger
        );
    }

    static async clickOnEditItem(stepLogger: StepLogger) {
        stepLogger.step('Click on "Edit Item" button.');
        await PageHelper.click(MyWorkPage.manageTabRibbonItems.editItem);
    }

    static async editTitle(stepLogger: StepLogger) {
        stepLogger.step('Edit field.');
        const uniqueId = PageHelper.getUniqueId();
        const itemEditedTitle = `${MyWorkPageConstants.editItemLabel} ${uniqueId}`;
        await CommonPageHelper.switchToFirstContentFrame();
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, itemEditedTitle);
        return itemEditedTitle;
    }

    static async verifyChangesNotReflected(editedItemTitleForCancel: string, stepLogger: StepLogger) {
        await ExpectationHelper.verifyNotDisplayedStatus(
            MyWorkPage.getItemByName(editedItemTitleForCancel),
            editedItemTitleForCancel,
            stepLogger
        );
    }

    static async clickCancelIcon(stepLogger: StepLogger) {
        stepLogger.step('Click on cancel icon');
        await PageHelper.click(MyWorkPage.closeIconOnPopup);
    }

    static async verifyCommentButtonEnabled(stepLogger: StepLogger) {
        await ExpectationHelper.verifyEnabledStatus(
            MyWorkPage.manageTabRibbonItems.comments,
            MyWorkPageConstants.commentsLabel,
            stepLogger
        );
    }

    static async clickOnComment(stepLogger: StepLogger) {
        await stepLogger.step('Click on "Comment" button from ribbon panel.');
        await PageHelper.click(MyWorkPage.manageTabRibbonItems.comments);
        await browser.sleep(PageHelper.timeout.s);
        await CommonPageHelper.switchToFirstContentFrame();
    }

    static async addComment(stepLogger: StepLogger) {
        stepLogger.step('Add a comment');
        const uniqueId = PageHelper.getUniqueId();
        const commentText = `${MyWorkPageConstants.commentsLabel} ${uniqueId}`;
        await TextboxHelper.sendKeys(MyWorkPage.commentsPopupDetails.commentTextArea, commentText);
        return commentText;
    }

    static async clickOnPost(stepLogger: StepLogger) {
        stepLogger.step('Click on "Post" button.');
        await PageHelper.click(MyWorkPage.commentsPopupDetails.post);
    }

    static async verifyCommentedPost(commentText: string, stepLogger: StepLogger) {
        // Dynamic wait didn't help
        await browser.sleep(PageHelper.timeout.s);
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.getCommentByName(commentText),
            commentText,
            stepLogger
        );
    }

    static async clickEditOnAnyComment(stepLogger: StepLogger) {
        stepLogger.step('Click on "Edit" button.');
        await PageHelper.click(MyWorkPage.commentsPopupDetails.edit);
    }

    static async editComment(stepLogger: StepLogger) {
        stepLogger.step('Edit the comment');
        const uniqueId = PageHelper.getUniqueId();
        const commentText = `${MyWorkPageConstants.editCommentsLabel} ${uniqueId}`;
        await TextboxHelper.sendKeys(MyWorkPage.commentsPopupDetails.editCommentTextArea, commentText);
        return commentText;
    }

    static async clickOnPostForEditComment(stepLogger: StepLogger) {
        stepLogger.step('Click post button on edit comment section');
        await PageHelper.click(MyWorkPage.commentsPopupDetails.editPost);
    }

    static async clickOnDelete(stepLogger: StepLogger) {
        stepLogger.step('Click on "Delete" button.');
        await ElementHelper.clickUsingJsNoWait(MyWorkPage.commentsPopupDetails.delete);
    }

    static async verifyCommentDeleted(commentText: string, stepLogger: StepLogger) {
        await ExpectationHelper.verifyNotDisplayedStatus(
            MyWorkPage.getCommentByName(commentText),
            commentText,
            stepLogger
        );
    }

    static async clickViewsTab(stepLogger: StepLogger) {
        stepLogger.step('Click on View tab.');
        // scripts are failing - dynamic waits couldn't help
        await browser.sleep(PageHelper.timeout.s);
        const isViewTabDisplayed = await PageHelper.isElementPresent(MyWorkPage.selectRibbonTabs.views);
        if (! isViewTabDisplayed) {
            await this.clickOnAnyCreatedItem(stepLogger);
        }
        await PageHelper.click(MyWorkPage.selectRibbonTabs.views);
    }

    static async verifyViewRibbonDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.getViewRibbonOptions.saveView,
            MyWorkPageConstants.viewsRibbonLabel,
            stepLogger
        );
    }

    static async clickSaveView(stepLogger: StepLogger) {
        stepLogger.step('Click on Save View');
        await this.clickOnAnyCreatedItem(stepLogger);
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.saveView);
    }

    static async verifySaveViewPopupDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.viewsPopup.name,
            MyWorkPageConstants.saveViewPopupLabel,
            stepLogger
        );
    }

    static async enterTextOnSaveViewTitle(stepLogger: StepLogger) {
        stepLogger.step('Enter text - save view name');
        const currentViewName = await PageHelper.getText(MyWorkPage.getCurrentView);
        const viewsPopupItems = MyWorkPage.viewsPopup;
        const uniqueId = PageHelper.getUniqueId();
        const viewName = `${MyWorkPageConstants.viewName}${uniqueId}`;
        await PageHelper.click(viewsPopupItems.name);
        await TextboxHelper.sendKeys(viewsPopupItems.name, viewName);
        return currentViewName;
    }

    static async clickCancelOnViewsPopup(stepLogger: StepLogger) {
        stepLogger.step('Click on Cancel button');
        await PageHelper.click(MyWorkPage.viewsPopup.cancel);
    }

    static async verifyViewName(currentView: string, stepLogger: StepLogger) {
        await browser.sleep(PageHelper.timeout.s);
        await ExpectationHelper.verifyText(
            MyWorkPage.getCurrentView,
            MyWorkPageConstants.currentView,
            currentView,
            stepLogger
        );
    }

    static async selectViewFromCurrentView(stepLogger: StepLogger) {
        stepLogger.step('Select some other view apart from Default view ');
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.currentViewDropdown);
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(MyWorkPage.selectViewNameOtherThanDefault);
        // sometimes - stale exception
        await browser.sleep(PageHelper.timeout.s);
        await this.clickViewsTab(stepLogger);
        const viewName = PageHelper.getText(MyWorkPage.getCurrentView);
        return viewName;
    }

    static async clickRenameView(stepLogger: StepLogger) {
        stepLogger.step('click on Rename view');
        await this.clickOnAnyCreatedItem(stepLogger);
        await ElementHelper.clickUsingJsNoWait(MyWorkPage.getViewRibbonOptions.renameView);
    }

    static async verifyRenameViewDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.viewsPopup.newName,
            MyWorkPageConstants.renameViewPopupLabel,
            stepLogger
        );
    }

    static async enterNewName(stepLogger: StepLogger) {
        stepLogger.step('Enter text - rename view new name');
        const uniqueId = PageHelper.getUniqueId();
        const viewName = `${MyWorkPageConstants.viewName}${uniqueId}`;
        await TextboxHelper.sendKeys(MyWorkPage.viewsPopup.newName, viewName);
    }

    static async clickCancelButtonViewsPopup(stepLogger: StepLogger) {
        stepLogger.step('Click on "Cancel" button');
        await PageHelper.click(MyWorkPage.viewsPopup.cancel);
    }

    static async clickDeleteView(stepLogger: StepLogger) {
        stepLogger.step('Click on Delete View button.');
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.deleteView);
    }

    static async dismissDeletePopup(stepLogger: StepLogger) {
        stepLogger.step('Click on Cancel button.');
        await PageHelper.dismissAlert();
    }

    static async goToSaveView(stepLogger: StepLogger) {
        await this.clickViewsTab(stepLogger);
        await this.clickSaveView(stepLogger);
    }

    static async fillNameAndSubmitSaveView(stepLogger: StepLogger) {
        stepLogger.step('Enter some valid text in it and do not check default view check box.Click on "Ok" button');
        const uniqueId = PageHelper.getUniqueId();
        const viewName = `${MyWorkPageConstants.viewName}${uniqueId}`;
        const viewsPopupItems = MyWorkPage.viewsPopup;
        await PageHelper.click(viewsPopupItems.name);
        await TextboxHelper.sendKeys(viewsPopupItems.name, viewName);
        if (await PageHelper.isElementSelected(viewsPopupItems.defaultView)) {
            await PageHelper.click(viewsPopupItems.defaultView);
        }
        if (await PageHelper.isElementSelected(viewsPopupItems.personalView)) {
            await PageHelper.click(viewsPopupItems.personalView);
        }
        await PageHelper.click(viewsPopupItems.ok);
        return viewName;
    }

    static async verifyDeleteViewPopup(viewName: string, stepLogger: StepLogger) {
        const deletePopUpText = await PageHelper.getAlertText();
        const expectedPopUpText = `Would you like to delete the "${viewName}" view?`;
        await ExpectationHelper.verifyStringEqualTo(deletePopUpText, expectedPopUpText, stepLogger);
    }

    static async clickOKonDeleteViewPopup(stepLogger: StepLogger) {
        stepLogger.step('Click on "Ok" button.');
        await PageHelper.acceptAlert();
    }

    static async verifyViewDeleted(currentViewName: string, stepLogger: StepLogger) {
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.currentViewDropdown);
        await ExpectationHelper.verifyNotDisplayedStatus(
            MyWorkPage.getCurrentViewByName(currentViewName),
            currentViewName,
            stepLogger
        );
    }

    static async clickSelectColumns(stepLogger: StepLogger) {
        await this.clickOnAnyCreatedItem(stepLogger);
        stepLogger.step('Click on "Select Columns".');
        await ElementHelper.clickUsingJsNoWait(MyWorkPage.getViewRibbonOptions.selectColumns);
    }

    static async verifyButtonsOnSelectColumns(stepLogger: StepLogger) {
        const selectPopupItems = MyWorkPage.selectColumnsPopup;
        const selectPopupLabels = MyWorkPageConstants.selectColumnsPopup;
        await ExpectationHelper.verifyDisplayedStatus(
            selectPopupItems.ok,
            selectPopupLabels.ok,
            stepLogger
        );
        await ExpectationHelper.verifyDisplayedStatus(
            selectPopupItems.cancel,
            selectPopupLabels.cancel,
            stepLogger
        );
        await ExpectationHelper.verifyDisplayedStatus(
            selectPopupItems.hideAll,
            selectPopupLabels.hideAll,
            stepLogger
        );
    }

    static async selectColumn(stepLogger: StepLogger) {
        stepLogger.step('Select the check-box for any column, Click on "Ok" button');
        const selectPopupItems = MyWorkPage.selectColumnsPopup;
        const columnName = await PageHelper.getText(selectPopupItems.column.get(0));
        const isColumnSelected = await PageHelper.isElementPresent(MyWorkPage.getColumnSelectedOnSelectColumnsPopup(columnName));
        if (! isColumnSelected) {
            await PageHelper.click(selectPopupItems.column.get(0));
        }
        await PageHelper.click(selectPopupItems.ok);
        return columnName;
    }

    static async verifySelectedColumnDisplayed(selectedColumn: string, stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus (
            MyWorkPage.columnDisplayed(selectedColumn),
            selectedColumn,
            stepLogger
        );
    }

    static async deleteNameInSaveViewSubmit(stepLogger: StepLogger) {
        stepLogger.step('Delete the text from the text-box. Click on "Ok" button.');
        const saveViewPopupItems = await MyWorkPage.viewsPopup;
        await PageHelper.click(saveViewPopupItems.name);
        await TextboxHelper.clearText(saveViewPopupItems.name);
        await PageHelper.click(saveViewPopupItems.ok);
    }

    static async verifyEmptyNameMessage(stepLogger: StepLogger) {
        const alertMessageExpected = await PageHelper.getAlertText();
        await ExpectationHelper.verifyStringEqualTo(
            alertMessageExpected,
            MyWorkPageConstants.noNameMessage,
            stepLogger
        );
    }

    static async clickOKAlert(stepLogger: StepLogger) {
        stepLogger.step('Click on "Ok" button.');
        await PageHelper.acceptAlert();
    }
}
