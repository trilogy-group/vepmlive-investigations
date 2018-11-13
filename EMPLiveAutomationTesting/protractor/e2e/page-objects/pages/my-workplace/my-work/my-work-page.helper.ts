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
import { browser } from 'protractor';
import {ElementHelper} from '../../../../components/html/element-helper';
import {HtmlHelper} from '../../../../components/misc-utils/html-helper';
import {ToDoPageConstants} from '../to-do/to-do-page.constants';
import {ToDoPageHelper} from '../to-do/to-do-page.helper';
import {TextComponentSelectors} from '../../../../components/component-types/text-component/text-component-selectors';
import {MyTimeOffPageHelper} from '../my-time-off/my-time-off-page.helper';
import {MyTimeOffPageConstants} from '../my-time-off/my-time-off-page.constants';

export class MyWorkPageHelper {

    static async fillFormAndSave() {
        const inputLabels = MyWorkPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const titleValue = `${inputLabels.title} ${uniqueId}`;

        StepLogger.step(`Title *: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, titleValue);

        StepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');
        await PageHelper.click(MyWorkPage.dropdownAll.project);
        await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.inputs.project);
        const projectName = await MyWorkPage.inputs.project.getText();
        await PageHelper.click(MyWorkPage.inputs.project);

        StepLogger.verification('Required values entered/selected in Project Field');
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(projectName).isPresent())
            .toBe(true, ValidationsHelper.getFieldShouldHaveValueValidation(inputLabels.project, projectName));

        StepLogger.step(`Assigned To: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.assignedTo, LoginPageHelper.adminEmailId);
        StepLogger.step(`select assignedTo value`);
        await PageHelper.click(MyWorkPage.selectValueFromSuggestions(LoginPageHelper.adminEmailId));

        StepLogger.stepId(5);
        StepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        StepLogger.verification('"New Item" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(MyWorkPageConstants.editPageName));
        // Wait for the page to close after clicking on save. This is to reduce window close synchronization issues
        await WaitHelper.staticWait(PageHelper.timeout.m);

        StepLogger.verification('Newly created Item [Ex: Title 1] displayed in "My Work" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(titleValue));
    }

    static async fillTimeOffFormAndSave(titleValue: string) {

        StepLogger.step(`Title *: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, titleValue);

        StepLogger.step('Time Off Type *: Select any type from the drop down [Ex: Holiday])');
        await PageHelper.click(MyWorkPage.dropdownAll.timeOffType);
        await PageHelper.click(MyWorkPage.dropdownAll.timeOffInput);

        StepLogger.step(`Requestor* : New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.requestor, LoginPageHelper.adminEmailId);
        StepLogger.step(`select Requester* value`);
        await PageHelper.click(MyWorkPage.assignedToSuggestions);

        StepLogger.step(`Enter Start Date: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.start, CommonPageHelper.getTodayInMMDDYYYY);

        StepLogger.step(`Enter Finish Date: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.finish, CommonPageHelper.getYesterdayInMMDDYYYY);

        StepLogger.stepId(5);
        StepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);

        StepLogger.verification('"New Item" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(MyWorkPageConstants.editPageName));
        // Wait for the page to close after clicking on save. This is to reduce window close synchronization issues
        await WaitHelper.staticWait(PageHelper.timeout.m);
    }

    static async clickOnPageTab() {
        StepLogger.step('Click on "Page" tab');
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(CommonPage.ribbonTitles.page);
    }

    static async verifyMyWorkPageDisplayed() {
        StepLogger.verification(`verify "My Work"  page is displayed`);
        const panelHeadingDisplayed = await PageHelper.isElementDisplayed(
            CommonPage.pageHeaders.myWorkplace.myWork);
        await expect(panelHeadingDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            CommonPageConstants.pageHeaders.myWorkplace.myWork));
    }

    static async expandEditPageDropdown() {
        StepLogger.step(`click on "Edit Page" dropdown`);
        await PageHelper.click(MyWorkPage.editPageDropdown);
    }

    static  async verifyStopEditingOptionDisabled() {
        StepLogger.verification(`verify "Stop Editing" option is shown as disabled`);
        const stopEditingDisplayed = await PageHelper.isElementDisplayed(
            MyWorkPage.disabledStopEditingOption);
        await expect(stopEditingDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            MyWorkPageConstants.editPageActions.stopEditing));
    }

    static async verifyEditPageDropdownOptions() {
        StepLogger.verification(`verify "Edit Page" option is shown`);
        const editPageDisplayed = await PageHelper.isElementDisplayed(
            MyWorkPage.editPageMenuOption);
        await expect(editPageDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            MyWorkPageConstants.editPageActions.editPage));

        await this.verifyStopEditingOptionDisabled();
    }

    static async clickOnEditPageMenuOption() {
        StepLogger.step(`click on "Edit Page" option from dropdown`);
        await PageHelper.click(MyWorkPage.editPageMenuOption);
    }

    static async verifyEditPageOpened() {
        StepLogger.verification(`verify "Edit Page" opens`);
        const editPageDisplayed = await PageHelper.isElementDisplayed(
            MyWorkPage.editPage);
        await expect(editPageDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            MyWorkPageConstants.editPageActions.editPage));
    }
    static async verifyPageTabIsSelected() {
        StepLogger.verification(`verify "PageTab" is shown as selected`);
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

    static async verifyAndAcceptRenameConfirmationPopup(viewName: string) {
        const isPresent = await PageHelper.waitForAlertToBePresent();
        if (isPresent) {
            const renamePopUpText = await PageHelper.getAlertText();
            const expectedPopUpText = `Would you like to rename the "${viewName}" view?`;
            await ExpectationHelper.verifyStringEqualTo(renamePopUpText, expectedPopUpText);
            await PageHelper.acceptAlert();
        }
    }
    static async navigateToMyWork() {
        const pageHeader = CommonPage.pageHeaders;
        const pageHeaderName = CommonPageConstants.pageHeaders.myWorkplace;
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(MyWorkplacePage.navigation.myWork,
            pageHeader.myWorkplace.myWork, pageHeaderName.myWork);
    }

    static async clickStopEditing() {
        StepLogger.step('Click on Stop Editing button available');
        await this.clickOnPageTab();
        await PageHelper.clickAndWaitForElementToHide(MyWorkPage.stopEditing);
    }

    static async verifyManageTabDisplayed() {
        await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.newItem);
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.newItem,
            MyWorkPageConstants.manage,
        );
    }

    static async clickOnManageTab() {
        StepLogger.step('Click on "Manage" tab.');
        const isDisplayed = await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.selectRibbonTabs.manage);
        if (!isDisplayed) {
            await PageHelper.refreshPage();
            await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.selectRibbonTabs.manage);
        }
        await PageHelper.click(MyWorkPage.selectRibbonTabs.manage);
    }

    static async goToNewChangesItem() {
        await this.expandNewItem();
        StepLogger.step('click on "Changes Item" drop-down.');
        await PageHelper.click(MyWorkPage.newItemMenu.changesItem);
    }

    static async verifyChangesNewItemPopupDisplayed() {
        const changesItemLabel = `${MyWorkPageConstants.newItemTypeLabels.changes} ${MyWorkPageConstants.newItemPopupLabel}`;
        await ExpectationHelper.verifyText(
            MyWorkPage.inputs.heading,
            changesItemLabel,
            MyWorkPageConstants.pageName.changes,
        );
    }

    static async fillNewItemFormForChanges() {
        return await MyWorkPageHelper.fillNewItemForm(MyWorkPageConstants.newItemTypeLabels.changes);
    }

    static async fillNewItemFormForRisks() {
        return await MyWorkPageHelper.fillNewItemForm(MyWorkPageConstants.newItemTypeLabels.risks);
    }

    static async fillNewItemFormForIssues() {
        return await MyWorkPageHelper.fillNewItemForm(MyWorkPageConstants.newItemTypeLabels.issues);
    }

    static async fillNewItemFormForTimeoff() {
        await CommonPageHelper.switchToFirstContentFrame();
        const uniqueId = PageHelper.getUniqueId();
        const labels = MyTimeOffPageConstants.inputLabels;
        const input = MyTimeOffPageConstants.inputValues;
        const title = `${labels.title} ${uniqueId}`;
        const timeOffType = MyTimeOffPageConstants.timeOffTypes.holiday;
        const requestor = input.requestorValue;
        const startDate = input.startDate;
        const finishDate = input.finishDate;
        await MyTimeOffPageHelper.fillFormAndVerify(title, timeOffType, requestor, startDate, finishDate);
        return title;
    }

    static async fillNewItemFormForTodo() {
        const uniqueId = PageHelper.getUniqueId();
        const itemTitle = `ToDo ${uniqueId}`;
        await CommonPageHelper.switchToFirstContentFrame();
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, itemTitle);
        await this.clickSaveButton();
        return itemTitle;
    }

    static async fillNewItemForm(itemType: string) {
        StepLogger.step('Populate the necessary fields. Enter resource name in "Assigned To"' +
            ' field(for e.g. Administrator.) Click on "Save" button.');
        const uniqueId = PageHelper.getUniqueId();
        const itemTitle = `${itemType} ${uniqueId}`;
        await CommonPageHelper.switchToFirstContentFrame();
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, itemTitle);
        await PageHelper.click(MyWorkPage.dropdownAll.project);
        await PageHelper.click(MyWorkPage.inputs.project);
        const assignedTo = `${MyWorkPageConstants.administrator}`;
        await TextboxHelper.sendKeys(MyWorkPage.inputs.assignedTo, assignedTo);
        await PageHelper.click(MyWorkPage.assignedToSuggestions);
        await this.clickSaveButton();
        await WaitHelper.waitForElementToBeHidden(MyWorkPage.buttonsOnPopup.save);
        return itemTitle;
    }

    static async clickSaveButton(switchToFrame = false) {
        StepLogger.step('Click on save');
        if (switchToFrame) {
            await CommonPageHelper.switchToFirstContentFrame();
        }
        await PageHelper.click(MyWorkPage.buttonsOnPopup.save);
    }

    static async verifyCreateItem(itemTitle: Array<string>) {
        await TextboxHelper.sendKeys(MyWorkPage.searchItem, itemTitle[0], true);
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.getItemByName(itemTitle[1]),
            itemTitle[1],
        );
    }

    static async verifyToDoCreateItem(itemTitle: string) {
        await browser.sleep(PageHelper.timeout.s);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
        );
        await ExpectationHelper.verifyElementPresentStatus(
            TextComponentSelectors.getItemByText(itemTitle), itemTitle
        );
    }

    static async goToDoNewItem() {
        StepLogger.step('Expand the "New Item < ToDo Item" drop-down.');
        await PageHelper.click(MyWorkPage.newItem);
        await PageHelper.click(MyWorkPage.newItemMenu.toDoItem);
    }

    static async verifyToDoNewItemPopupDisplayed() {
        const toDoPopup = `${MyWorkPageConstants.newItemTypeLabels.toDo} ${MyWorkPageConstants.newItemPopupLabel}`;
        await ExpectationHelper.verifyText(
            MyWorkPage.inputs.heading,
            toDoPopup,
            MyWorkPageConstants.pageName.toDo,
        );
    }

    static async verifyTimeOffNewItemPopupDisplayed() {
        const toDoPopup = `${MyWorkPageConstants.newItemTypeLabels.timeOff} ${MyWorkPageConstants.newItemPopupLabel}`;
        await ExpectationHelper.verifyText(
            MyWorkPage.inputs.heading,
            toDoPopup,
            MyWorkPageConstants.pageName.timeOff,
        );
    }

    static async fillToDoDeatilsAndSave() {
        const uniqueId = PageHelper.getUniqueId();
        const labels = ToDoPageConstants.inputLabels;
        const title = `${labels.title} ${uniqueId}`;
        const status = CommonPageConstants.statuses.notStarted;
        const description = `${labels.description} ${uniqueId}`;
        // step#3 is inside this function
        await ToDoPageHelper.fillFormAndSave(title, status, description);
    }

    static async verifyTitleValidationMessage() {
        await ExpectationHelper.verifyText(
            MyWorkPage.validationMessage,
            MyWorkPageConstants.validationMessageLabel,
            MyWorkPageConstants.blankValidationMessage,
        );
    }

    static async clickCancelButton() {
        StepLogger.step('Click on "Cancel" button');
        await PageHelper.click(MyWorkPage.buttonsOnPopup.cancel);
    }

    static async verifyPopupClosed() {
        const toDoPopup = `${MyWorkPageConstants.newItemTypeLabels.toDo} ${MyWorkPageConstants.newItemPopupLabel}`;
        await ExpectationHelper.verifyNotDisplayedStatus(
            MyWorkPage.inputs.title,
            toDoPopup,
        );
    }

    static async expandNewItem() {
        StepLogger.step('Expand the "New Item" drop-down.');
        await PageHelper.click(MyWorkPage.newItem);
    }

    static async newItemsDropdownDisplayed() {
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.newItemMenu.changesItem,
            MyWorkPageConstants.newItemListLabel,
        );
    }

    static async clickIssuesItem() {
        StepLogger.step('Click on "Issues Item"');
        await PageHelper.click(MyWorkPage.newItemMenu.issuesItem);
    }

    static async verifyIssuesNewItemPopupDisplayed() {
        const issueItemLabel = `${MyWorkPageConstants.newItemTypeLabels.issues} ${MyWorkPageConstants.newItemPopupLabel}`;
        await ExpectationHelper.verifyText(
            MyWorkPage.inputs.heading,
            issueItemLabel,
            MyWorkPageConstants.pageName.issues,
        );
    }

    static async verifyRisksNewItemPopupDisplayed() {
        const riskItemLabel = `${MyWorkPageConstants.newItemTypeLabels.risks} ${MyWorkPageConstants.newItemPopupLabel}`;
        await ExpectationHelper.verifyText(
            MyWorkPage.inputs.heading,
            riskItemLabel,
            MyWorkPageConstants.pageName.risks,
        );
    }

    static async clickRisksItem() {
        StepLogger.step('Click on "Risks Item"');
        await PageHelper.click(MyWorkPage.newItemMenu.risksItem);
    }

    static async clickToDoItem() {
        StepLogger.step('Click on "To-Do Item"');
        await PageHelper.click(MyWorkPage.newItemMenu.toDoItem);
    }

    static async clickTimeOffItem() {
        StepLogger.step('Click on "To-Do Item"');
        await PageHelper.click(MyWorkPage.newItemMenu.timeOffItem);
    }

    static async clickOnAnyCreatedItem() {
        StepLogger.step('Click on newly created item in the grid.');
        await PageHelper.click(CommonPage.recordWithoutGreenTicket);
    }

    static async verifyEditItemButtonEnabled() {
        await ExpectationHelper.verifyEnabledStatus(
            MyWorkPage.manageTabRibbonItems.editItem,
            MyWorkPageConstants.editItemLabel,
        );
    }

    static async clickOnEditItem() {
        StepLogger.step('Click on "Edit Item" button.');
        await PageHelper.click(MyWorkPage.manageTabRibbonItems.editItem);
    }

    static async editTitle() {
        StepLogger.step('Edit field.');
        const uniqueId = PageHelper.getUniqueId();
        const itemEditedTitle = `${MyWorkPageConstants.editItemLabel} ${uniqueId}`;
        await CommonPageHelper.switchToFirstContentFrame();
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, itemEditedTitle);
        return [uniqueId, itemEditedTitle];
    }

    static async verifyChangesNotReflected(editedItemTitleForCancel: string) {
        await ExpectationHelper.verifyNotDisplayedStatus(
            MyWorkPage.getItemByName(editedItemTitleForCancel),
            editedItemTitleForCancel,
        );
    }

    static async clickCancelIcon() {
        StepLogger.step('Click on cancel icon');
        await PageHelper.click(MyWorkPage.closeIconOnPopup);
    }

    static async verifyCommentButtonEnabled() {
        await ExpectationHelper.verifyEnabledStatus(
            MyWorkPage.manageTabRibbonItems.comments,
            MyWorkPageConstants.commentsLabel,
        );
    }

    static async clickOnComment() {
        await StepLogger.step('Click on "Comment" button from ribbon panel.');
        await PageHelper.click(MyWorkPage.manageTabRibbonItems.comments);
        await browser.sleep(PageHelper.timeout.s);
        await CommonPageHelper.switchToFirstContentFrame();
    }

    static async addComment() {
        StepLogger.step('Add a comment');
        const uniqueId = PageHelper.getUniqueId();
        const commentText = `${MyWorkPageConstants.commentsLabel} ${uniqueId}`;
        await TextboxHelper.sendKeys(MyWorkPage.commentsPopupDetails.commentTextArea, commentText);
        return commentText;
    }

    static async clickOnPost() {
        StepLogger.step('Click on "Post" button.');
        await PageHelper.click(MyWorkPage.commentsPopupDetails.post);
    }

    static async verifyCommentedPost(commentText: string) {
        // Dynamic wait didn't help
        await browser.sleep(PageHelper.timeout.s);
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.getCommentByName(commentText),
            commentText,
        );
    }

    static async clickEditOnAnyComment() {
        StepLogger.step('Click on "Edit" button.');
        await PageHelper.click(MyWorkPage.commentsPopupDetails.edit);
    }

    static async editComment() {
        StepLogger.step('Edit the comment');
        const uniqueId = PageHelper.getUniqueId();
        const commentText = `${MyWorkPageConstants.editCommentsLabel} ${uniqueId}`;
        await TextboxHelper.sendKeys(MyWorkPage.commentsPopupDetails.editCommentTextArea, commentText);
        return commentText;
    }

    static async clickOnPostForEditComment() {
        StepLogger.step('Click post button on edit comment section');
        await PageHelper.click(MyWorkPage.commentsPopupDetails.editPost);
    }

    static async clickOnDelete() {
        StepLogger.step('Click on "Delete" button.');
        await ElementHelper.clickUsingJsNoWait(MyWorkPage.commentsPopupDetails.delete);
    }

    static async verifyCommentDeleted(commentText: string) {
        await ExpectationHelper.verifyNotDisplayedStatus(
            MyWorkPage.getCommentByName(commentText),
            commentText,
        );
    }

    static async clickViewsTab(checkRow = true) {
        StepLogger.step('Click on View tab.');
        await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.topBar);
        let isViewTabDisplayed = await PageHelper.isElementPresent(MyWorkPage.selectRibbonTabs.views);
        if (checkRow) {
            if (!isViewTabDisplayed) {
                await this.clickOnAnyCreatedItem();
            }
        }
        await PageHelper.click(MyWorkPage.selectRibbonTabs.views);
        isViewTabDisplayed = await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.getViewRibbonOptions.selectColumns, PageHelper.timeout.m);
        if (!isViewTabDisplayed) {
            await PageHelper.click(MyWorkPage.selectRibbonTabs.views);
        }
        await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.getViewRibbonOptions.selectColumns);
    }

    static async verifyViewRibbonDisplayed() {
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.getViewRibbonOptions.saveView,
            MyWorkPageConstants.viewsRibbonLabel,
        );
    }

    static async clickSaveView() {
        StepLogger.step('Click on Save View');
        await this.clickOnAnyCreatedItem();
        await this.clickViewsTab(false);
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.saveView);
    }

    static async verifySaveViewPopupDisplayed() {
        const isDisplayed = await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.viewsPopup.name, PageHelper.timeout.s);
        if (!isDisplayed) {
            await this.goToSaveView();
        }
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.viewsPopup.name,
            MyWorkPageConstants.saveViewPopupLabel,
        );
    }

    static async enterTextOnSaveViewTitle() {
        StepLogger.step('Enter text - save view name');
        const currentViewName = await PageHelper.getText(MyWorkPage.getCurrentView);
        const viewsPopupItems = MyWorkPage.viewsPopup;
        const uniqueId = PageHelper.getUniqueId();
        const viewName = `${MyWorkPageConstants.viewName}${uniqueId}`;
        await PageHelper.click(viewsPopupItems.name);
        await TextboxHelper.sendKeys(viewsPopupItems.name, viewName);
        return currentViewName;
    }

    static async clickCancelOnViewsPopup() {
        StepLogger.step('Click on Cancel button');
        await PageHelper.click(MyWorkPage.viewsPopup.cancel);
    }

    static async verifyViewName(currentView: string) {
        await browser.sleep(PageHelper.timeout.s);
        await this.clickOnAnyCreatedItem();
        await ExpectationHelper.verifyText(
            MyWorkPage.getCurrentView,
            MyWorkPageConstants.currentView,
            currentView,
        );
    }

    static async selectViewFromCurrentView() {
        StepLogger.step('Select some other view apart from Default view ');
        await this.clickViewsTab(false);
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.currentViewDropdown);
        const isOpened = await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.selectViewNameOtherThanDefault, PageHelper.timeout.s);
        if (!isOpened) {
            await PageHelper.click(MyWorkPage.getViewRibbonOptions.currentViewDropdown);
            await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.selectViewNameOtherThanDefault);
        }
        await PageHelper.click(MyWorkPage.selectViewNameOtherThanDefault);
        // sometimes - stale exception
        await browser.sleep(PageHelper.timeout.s);
        await this.clickViewsTab();
        const viewName = PageHelper.getText(MyWorkPage.getCurrentView);
        return viewName;
    }

    static async clickRenameView() {
        await this.clickOnAnyCreatedItem();
        StepLogger.step('click on Rename view');
        await ElementHelper.clickUsingJsNoWait(MyWorkPage.getViewRibbonOptions.renameView);
    }

    static async verifyRenameViewDisplayed() {
        await browser.sleep(PageHelper.timeout.s);
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.viewsPopup.newName,
            MyWorkPageConstants.renameViewPopupLabel,
        );
    }

    static async enterNewName() {
        StepLogger.step('Enter text - rename view new name');
        const uniqueId = PageHelper.getUniqueId();
        const viewName = `${MyWorkPageConstants.viewName}${uniqueId}`;
        await TextboxHelper.sendKeys(MyWorkPage.viewsPopup.newName, viewName);
    }

    static async clickCancelButtonViewsPopup() {
        StepLogger.step('Click on "Cancel" button');
        await PageHelper.click(MyWorkPage.viewsPopup.cancel);
    }

    static async clickDeleteView() {
        StepLogger.step('Click on Delete View button.');
        const isPresent = await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.getViewRibbonOptions.deleteView, PageHelper.timeout.s);
        if (!isPresent) {
            await this.clickViewsTab();
        }
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.deleteView);
        const alertOpened  = await PageHelper.waitForAlertToBePresent(PageHelper.timeout.xl);
        if (!alertOpened) {
            try {
                await PageHelper.click(MyWorkPage.getViewRibbonOptions.deleteView);
            } catch (e) {
                console.log(e);
            }
        }
    }

    static async dismissDeletePopup() {
        StepLogger.step('Click on Cancel button.');
        await PageHelper.dismissAlert();
    }

    static async goToSaveView() {
        await this.clickViewsTab();
        await this.clickSaveView();
    }

    static async fillNameAndSubmitSaveView() {
        StepLogger.step('Enter some valid text in it and do not check default view check box.Click on "Ok" button');
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

    static async verifyDeleteViewPopup(viewName: string) {
        const deletePopUpText = await PageHelper.getAlertText();
        const expectedPopUpText = `Would you like to delete the "${viewName}" view?`;
        await ExpectationHelper.verifyStringEqualTo(deletePopUpText, expectedPopUpText);
    }

    static async clickOKonDeleteViewPopup() {
        StepLogger.step('Click on "Ok" button.');
        await PageHelper.acceptAlert();
    }

    static async verifyViewDeleted(currentViewName: string) {
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.currentViewDropdown);
        await ExpectationHelper.verifyNotDisplayedStatus(
            MyWorkPage.getCurrentViewByName(currentViewName),
            currentViewName,
        );
    }

    static async clickSelectColumns() {
        await this.clickOnAnyCreatedItem();
        StepLogger.step('Click on "Select Columns".');
        const isDisplayed = await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.getViewRibbonOptions.selectColumns, PageHelper.timeout.s);
        if (!isDisplayed) {
            await this.clickViewsTab(false);
        }
        await ElementHelper.click(MyWorkPage.getViewRibbonOptions.selectColumns);
    }

    static async verifyButtonsOnSelectColumns() {
        const selectPopupItems = MyWorkPage.selectColumnsPopup;
        const selectPopupLabels = CommonPageConstants.selectColumnsPopup;
        await ExpectationHelper.verifyDisplayedStatus(
            selectPopupItems.ok,
            selectPopupLabels.ok,
        );
        await ExpectationHelper.verifyDisplayedStatus(
            selectPopupItems.cancel,
            selectPopupLabels.cancel,
        );
        await ExpectationHelper.verifyDisplayedStatus(
            selectPopupItems.hideAll,
            selectPopupLabels.hideAll,
        );
    }

    static async selectColumn() {
        StepLogger.step('Select the check-box for any column, Click on "Ok" button');
        const selectPopupItems = MyWorkPage.selectColumnsPopup;
        const columnName = await PageHelper.getText(selectPopupItems.column.get(0));
        const isColumnSelected = await PageHelper.isElementPresent(MyWorkPage.getColumnSelectedOnSelectColumnsPopup(columnName));
        if (!isColumnSelected) {
            await PageHelper.click(selectPopupItems.column.get(0));
        }
        await PageHelper.click(selectPopupItems.ok);
        return columnName;
    }

    static async verifySelectedColumnDisplayed(selectedColumn: string) {
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.columnDisplayed(selectedColumn),
            selectedColumn,
        );
    }

    static async deleteNameInSaveViewSubmit() {
        StepLogger.step('Delete the text from the text-box. Click on "Ok" button.');
        const saveViewPopupItems = await MyWorkPage.viewsPopup;
        await PageHelper.click(saveViewPopupItems.name);
        await TextboxHelper.clearText(saveViewPopupItems.name);
        await PageHelper.click(saveViewPopupItems.ok);
        const alertOpened  = await PageHelper.waitForAlertToBePresent(PageHelper.timeout.xl);
        if (!alertOpened) {
            try {
                await PageHelper.click(MyWorkPage.getViewRibbonOptions.deleteView);
            } catch (e) {
                console.log(e);
            }
        }
    }

    static async verifyEmptyNameMessage() {
        const alertMessageExpected = await PageHelper.getAlertText();
        await ExpectationHelper.verifyStringEqualTo(
            alertMessageExpected,
            MyWorkPageConstants.noNameMessage,
        );
    }

    static async clickOKAlert() {
        StepLogger.step('Click on "Ok" button.');
        await PageHelper.acceptAlert();
    }

    static async clickEllipsesIcon() {
        StepLogger.step('Click on ellipses icon.');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.pageHeaders.myWorkplace.myWork);
        await browser.sleep(PageHelper.timeout.s);
        await ElementHelper.clickUsingJsNoWait(MyWorkPage.headerOptions.ellipses);
    }

    static async verifyEllipsesDropdownDisplayed() {
        await browser.sleep(PageHelper.timeout.s);
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.ellipsesDropdown.workTypes,
            MyWorkPageConstants.ellipsesDropdownLabel,
        );
    }

    static async clickCloseOnEllipsesDropdown() {
        StepLogger.step('Click on "Close" button.');
        await PageHelper.click(MyWorkPage.ellipsesDropdown.close);
    }

    static async verifyEllipsesDropdownClosed() {
        await ExpectationHelper.verifyHiddenStatus(
            MyWorkPage.ellipsesDropdown.workTypes,
            MyWorkPageConstants.ellipsesDropdownLabel,
        );
    }

    static async clickOnWorkingOnForAnyItem() {
        StepLogger.step('Click on the "Working on" column for any of the items');
        const gridItems = MyWorkPage.gridDetails;
        const radioButtonClassAttribute = await PageHelper.getAttributeValue(
            gridItems.workingOn.get(0), HtmlHelper.attributes.class);
        const isChecked = radioButtonClassAttribute.includes(MyWorkPageConstants.radioCheckedLabel);
        if (!isChecked) {
            await PageHelper.click(gridItems.workingOn.get(0));
        }
        await this.clickOnAnyCreatedItem();
        const selectedItemTitle = await PageHelper.getText(gridItems.title.get(0));
        return selectedItemTitle;
    }

    static async selectWorkingOnView() {
        StepLogger.step('Expand the "Current View" drop-down and click on Click on "Working on it"');
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.currentViewDropdown);
        const isOpened = await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.getCurrentViewByName(MyWorkPageConstants.workingOnItLabel),
            PageHelper.timeout.s);
        if (!isOpened) {
            await PageHelper.click(MyWorkPage.getViewRibbonOptions.currentViewDropdown);
            await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.getCurrentViewByName(MyWorkPageConstants.workingOnItLabel));
        }
        await ElementHelper.clickUsingJs(MyWorkPage.getCurrentViewByName(MyWorkPageConstants.workingOnItLabel));
        await browser.sleep(PageHelper.timeout.s);
        await this.clickViewsTab();
    }

    static async verifyWorkingOnItemDisplayed(itemTitle: any) {
        await ExpectationHelper.verifyDisplayedStatus(
            CommonPage.getGridRowByTitle(itemTitle),
            `${MyWorkPageConstants.workingOnItLabel} item`,
        );
    }

    static async verifyRadioButtonSelected() {
        const gridItems = MyWorkPage.gridDetails;
        await ExpectationHelper.verifyAttributeContains(
            gridItems.workingOn.get(0),
            HtmlHelper.attributes.class,
            MyWorkPageConstants.radioCheckedLabel,
        );
    }

    static async hoverOnAnyOption() {
        StepLogger.step('Hover the mouse for any of the options.');
        await ElementHelper.actionHoverOver(MyWorkPage.ellipsesDropdown.workTypes);
    }

    static async verifySubmenuDisplayed() {
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.ellipsesDropdown.workTypeSubmenuItem,
            MyWorkPageConstants.workTypeSubMenuLabel,
        );
    }

    static async clickWorkTypeOption() {
        StepLogger.step('Click on any option');
        const ellipseMyWorkPageItems = MyWorkPage.ellipsesDropdown;
        await ElementHelper.actionHoverOver(ellipseMyWorkPageItems.workTypes);
        const workType = await PageHelper.getText(ellipseMyWorkPageItems.workTypeSubmenuItem);
        await ElementHelper.actionHoverOver(ellipseMyWorkPageItems.workTypes);
        await PageHelper.click(ellipseMyWorkPageItems.workTypeSubmenuItem);
        return workType;
    }

    static async verifySearchResults(workType: string) {
        await WaitHelper.staticWait(PageHelper.timeout.xs);
        const rowCount = await MyWorkPage.gridDetails.workType.count();
        for (let i = 0; i < rowCount; i++) {
            await ExpectationHelper.verifyText(
                MyWorkPage.gridDetails.workType.get(i),
                MyWorkPageConstants.searchResultsLabel,
                workType,
            );
        }
    }

    static async doubleClickOnTitle() {
        StepLogger.step('Wait for elements to be greater than 0');
        await browser.wait(async () => await MyWorkPage.gridDetails.title.count() > 0);
        StepLogger.step('Double Click on the right side of item name.');
        await browser.actions().click(MyWorkPage.gridDetails.title.get(0)).perform();
    }

    static async verifyTitleInEditableMode() {
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.gridDetails.editTitle,
            MyWorkPageConstants.editTitleLabel,
        );
    }

    static async editTitleInGrid() {
        StepLogger.step('Make the necessary changes. - edit title');
        const uniqueId = PageHelper.getUniqueId();
        const title = `${MyWorkPageConstants.editItemLabel}${uniqueId}`;
        await TextboxHelper.sendKeys(MyWorkPage.gridDetails.editTitle, title);
        return title;
    }

    static async clickAnyWhereElseOnPage() {
        StepLogger.step('Click on anywhere else on the page.');
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.currentView);
    }

    static async verifyTitleEdited(editedTitle: string) {
        await ExpectationHelper.verifyDisplayedStatus(
            CommonPage.getGridRowByTitle(editedTitle),
            editedTitle,
        );
    }

    static async clickOnEllipsesForAnyItem() {
        StepLogger.step('Expand the ellipsis icon for a grid item.');
        const gridItems = MyWorkPage.gridDetails;
        const title = await PageHelper.getText(gridItems.title.get(0));
        await PageHelper.click(gridItems.toEdit.get(0));
        return title;
    }

    static async verifyEllipsesDropdownForItemDisplayed() {
        await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.ellipsesDropdownForItem.deleteItem);
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.ellipsesDropdownForItem.deleteItem,
            MyWorkPageConstants.ellipsesDropdownLabel,
        );
    }

    static async clickOnDeleteItem() {
        StepLogger.step('Click on "Delete Item" option.');
        await PageHelper.click(MyWorkPage.ellipsesDropdownForItem.deleteItem);
        if (!(await PageHelper.waitForAlertToBePresent(PageHelper.timeout.xl))) {
            try {
                await PageHelper.click(MyWorkPage.ellipsesDropdownForItem.deleteItem);
            } catch (e) {
                console.log(e);
            }
        }
    }

    static async verifyDeleteItemPopup() {
        const actualMessage = await PageHelper.getAlertText();
        await ExpectationHelper.verifyStringEqualTo(
            actualMessage,
            MyWorkPageConstants.deleteItemMessage,
        );
    }

    static async verifyItemDeleted(itemTitle: any) {
        await PageHelper.refreshPage();
        await browser.sleep(PageHelper.timeout.s);
        await ExpectationHelper.verifyNotDisplayedStatus(
            CommonPage.getGridRowByTitle(itemTitle),
            itemTitle,
        );
    }

    static async selectDefaultView() {
        StepLogger.step('Select Default View');
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.currentViewDropdown);
        await browser.sleep(PageHelper.timeout.xs);
        await ElementHelper.clickUsingJsNoWait(MyWorkPage.getCurrentViewByName(MyWorkPageConstants.defaultViewLabel));
    }

    static async verifyDeleletViewMessageForDefaultView() {
        const actualMessage = await PageHelper.getAlertText();
        await ExpectationHelper.verifyStringEqualTo(
            actualMessage,
            MyWorkPageConstants.deleteDefaultViewMessage,
        );
    }

    static async verifyAlertClosed() {
        await browser.sleep(PageHelper.timeout.s);
        await ExpectationHelper.verifyAlertNotDisplayed(
            MyWorkPageConstants.alertLabel,
        );
    }

    static async verifyRenameViewMessageForDefaultView() {
        await browser.sleep(PageHelper.timeout.s);
        const actualMessage = await PageHelper.getAlertText();
        await ExpectationHelper.verifyStringEqualTo(
            actualMessage,
            MyWorkPageConstants.renameDefaultViewMessage,
        );
    }

    static async verifyDefaultViewName() {
        await this.verifyViewName(MyWorkPageConstants.defaultViewLabel);
    }

    static async clickOnShowFilters() {
        StepLogger.step('Click on Show Filters button.');
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.showFilters);
    }

    static async verifyExtraRowAdded() {
        await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.gridDetails.filter);
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.gridDetails.filter,
            MyWorkPageConstants.filterRowLabel,
        );
    }

    static async getFirstWorkType() {
        StepLogger.step('Get first work type');
        return await PageHelper.getText(MyWorkPage.gridDetails.workTypeValues.get(0));
    }

    static async enterTextOnFilterFields(filterText: string) {
        StepLogger.step('Enter some valid text under any of the column names and hit enter.');
        await browser.sleep(PageHelper.timeout.s);
        const workTypeFilter = MyWorkPage.gridDetails.workTypeFilter;
        await CommonPageHelper.filterColumnByText(workTypeFilter, filterText);
        return filterText;
    }

    static async clickOnAnyColumnHeader() {
        StepLogger.step('Click on any of the column header.');
        await PageHelper.click(MyWorkPage.gridDetails.workTypeHeader);
    }

    static async verifyColumnSortedDisplayed() {
        await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.gridDetails.sorted);
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.gridDetails.sorted,
            MyWorkPageConstants.sortedColumnsLabel,
        );
    }

    static async clickOnRemoveSorting() {
        StepLogger.step('Click on remove sorting button');
        const isDisplayed = await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.getViewRibbonOptions.removeSorting, PageHelper.timeout.s);
        if (!isDisplayed) {
            await this.clickViewsTab(false);
        }
        await PageHelper.click(MyWorkPage.getViewRibbonOptions.removeSorting);
    }

    static async verifySortedRemoved() {
        await ExpectationHelper.verifyNotDisplayedStatus(
            MyWorkPage.gridDetails.sorted,
            MyWorkPageConstants.sortedColumnsLabel,
        );
    }

    static async expandCurrentView() {
        StepLogger.step('Expand the Current View drop down by clicking on it.');
        await ElementHelper.clickUsingJsNoWait(MyWorkPage.getViewRibbonOptions.manageCurrentViewDropdown);
    }

    static async verifySavedViewDisplayed() {
        await ExpectationHelper.verifyDisplayedStatus(
            MyWorkPage.newlyCreatedView,
            MyWorkPageConstants.newlyCreatedViewLabel,
        );
        return await PageHelper.getText(MyWorkPage.newlyCreatedView);
    }

    static async clickOnNewlyCreatedView(viewName: string) {
        StepLogger.step('Click on any of the options.');
        await ElementHelper.clickUsingJsNoWait(MyWorkPage.getCurrentViewByName(viewName));
    }

    static async clickCancelOnSelectColumnsPopup() {
        StepLogger.step('Click on any of the options.');
        await PageHelper.clickAndWaitForElementToHide(MyWorkPage.selectColumnsPopup.cancel);
    }

    static async verifySelectColumnPopupClosed() {
        await ExpectationHelper.verifyNotDisplayedStatus(
            MyWorkPage.selectColumnsPopup.hideAll,
            MyWorkPageConstants.selectColumnsPopupLabel,
        );
    }

    static async clickOnHideAllButton() {
        StepLogger.step('Click on "Hide All" button');
        await PageHelper.click(MyWorkPage.selectColumnsPopup.hideAll);
    }

    static async verifyHideAllFunctionality() {
        const selectColumnsPopupItems = MyWorkPage.selectColumnsPopup;
        await ExpectationHelper.verifyDisplayedStatus(
            selectColumnsPopupItems.showAll,
            CommonPageConstants.selectColumnsPopup.showAll,
        );
        await WaitHelper.waitForElementToBeHidden(selectColumnsPopupItems.eachSelectedColumn);
        await ExpectationHelper.verifyNotDisplayedStatus(
            selectColumnsPopupItems.eachSelectedColumn,
            MyWorkPageConstants.selectedCheckboxLabel,
        );
    }

    static async clickOnShowAllButton() {
        StepLogger.step('Click on "Show All" button');
        await PageHelper.click(MyWorkPage.selectColumnsPopup.showAll);
    }

    static async verifyShowAllFunctionality() {
        await WaitHelper.waitForElementToBeHidden(MyWorkPage.selectColumnsPopup.columnUnchecked);
        await ExpectationHelper.verifyNotDisplayedStatus(
            MyWorkPage.selectColumnsPopup.columnUnchecked,
            MyWorkPageConstants.unSelectedCheckboxLabel,
        );
    }

    static async selectAllColumnsAndSubmit() {
        const selectColumnPopupItems = MyWorkPage.selectColumnsPopup;
        // unselecting the columns which has images
        let i, j: number;
        for (i = 0; i < (await selectColumnPopupItems.columnNameWithImages.count()); i++) {
            await PageHelper.click(selectColumnPopupItems.columnNameWithImages.get(i));
        }
        await PageHelper.click(MyWorkPage.getColumnByNameOnSelectColumnsPopup('CommentCount'));
        // Getting the selected columns dynamically
        const allSelectedColumns: string[] = [];
        const count = await selectColumnPopupItems.allSelectedColumn.count() - 1;
        for (j = 0; j < count; j++) {
            const eachColumnName = await PageHelper.getText(selectColumnPopupItems.allSelectedColumn.get(j));
            allSelectedColumns.push(eachColumnName);
        }
        StepLogger.step('Click on "Ok" button');
        await PageHelper.click(selectColumnPopupItems.ok);
        return allSelectedColumns;
    }

    static async verifySelectedColumnsDisplayed(selectedColNames: string[]) {
        await browser.sleep(PageHelper.timeout.s);
        for (let i = 0; i < selectedColNames.length - 1; i++) {
            await ElementHelper.scrollToElement(MyWorkPage.columnDisplayed(selectedColNames[i]));
            await ExpectationHelper.verifyDisplayedStatus(
                MyWorkPage.columnDisplayed(selectedColNames[i]),
                selectedColNames[i],
            );
        }
    }
}
