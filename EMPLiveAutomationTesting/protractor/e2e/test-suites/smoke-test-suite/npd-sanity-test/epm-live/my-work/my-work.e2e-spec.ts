import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {MyWorkPage} from '../../../../../page-objects/pages/my-workplace/my-work/my-work.po';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {MyWorkPageConstants} from '../../../../../page-objects/pages/my-workplace/my-work/my-work-page.constants';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {MyWorkPageHelper} from '../../../../../page-objects/pages/my-workplace/my-work/my-work-page.helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {LoginPageHelper} from '../../../../../page-objects/pages/login/login-page.helper';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {browser} from 'protractor';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Navigate to My Work page - [855540]', async () => {
        const stepLogger = new StepLogger(855540);
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);
    });

    it('Create New Changes - [855545]', async () => {
        const stepLogger = new StepLogger(855545);
        stepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "New Item" option from Manage tab');
        await PageHelper.click(MyWorkPage.newItem);

        stepLogger.step('Select "Change Item" option from menu');
        await PageHelper.click(MyWorkPage.newItemMenu.changesItem);

        stepLogger.verification('Wait for "Changes - New Item" window to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        stepLogger.verification('"Changes - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.changes, true))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.changes));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Changes - New Item" window');
        // step#5 is inside this function
        await MyWorkPageHelper.fillFormAndSave(stepLogger);

    });

    it('Create New Issue - [855547]', async () => {
        const stepLogger = new StepLogger(855547);
        stepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "New Item" option from Manage tab');
        await PageHelper.click(MyWorkPage.newItem);

        stepLogger.step('Select "Issues Item" option from menu');
        await PageHelper.click(MyWorkPage.newItemMenu.issuesItem);

        stepLogger.verification('Wait for "Issues - New Item" window to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        stepLogger.verification('"Issues - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.issues, true))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.issues));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Issues - New Item" window');
        // step#5 is inside this function
        await MyWorkPageHelper.fillFormAndSave(stepLogger);
    });

    it('Create New Risks - [855550]', async () => {
        const stepLogger = new StepLogger(855550);
        stepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "New Item" option from Manage tab');
        await PageHelper.click(MyWorkPage.newItem);

        stepLogger.step('Select "Risks Item" option from menu');
        await PageHelper.click(MyWorkPage.newItemMenu.risksItem);

        stepLogger.verification('Wait for "Risks - New Item" window to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        stepLogger.verification('"Risks - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.risks, true))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.risks));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Risks - New Item" window');
        // step#5 is inside this function
        await MyWorkPageHelper.fillFormAndSave(stepLogger);
    });

    it('Create New Time Off - [855551]', async () => {
        const stepLogger = new StepLogger(855551);
        stepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "New Item" option from Manage tab');
        await PageHelper.click(MyWorkPage.newItem);

        stepLogger.step('Select "Time Off Item" option from menu');
        await PageHelper.click(MyWorkPage.newItemMenu.timeOffItem);

        stepLogger.verification('Wait for "Time Off - New Item" window to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        stepLogger.verification('"Time Off - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.timeOff, true))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.timeOff));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Time Off - New Item" window');
        // step#5 and step#6 are inside this function
        await MyWorkPageHelper.fillTimeOffFormAndSave(stepLogger);
    });

    it('Create New To Do item - [855560]', async () => {
        const stepLogger = new StepLogger(855560);
        stepLogger.stepId(1);
        // step#2 is inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "New Item" option from Manage tab');
        await PageHelper.click(MyWorkPage.newItem);

        stepLogger.step('Select "To Do Item" option from menu');
        await PageHelper.click(MyWorkPage.newItemMenu.toDoItem);

        stepLogger.verification('Wait for "To Do - New Item" window to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        stepLogger.verification('"To Do - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.toDo, true))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.toDo));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "To Do - New Item" window');
        const uniqueId = PageHelper.getUniqueId();
        const labels = MyWorkPageConstants.inputLabels;
        stepLogger.step(`Title *: New Item`);
        const titleValue = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, titleValue);
        stepLogger.step(`Assigned To: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.assignedTo, LoginPageHelper.adminEmailId);
        stepLogger.step(`select assignedTo value`);
        await PageHelper.click(MyWorkPage.selectValueFromSuggestions(LoginPageHelper.adminEmailId));

        stepLogger.stepId(5);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"To Do New Item" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(MyWorkPageConstants.editPageName));

        stepLogger.verification('Newly created ToDo Item [Ex: Title 1] displayed in "My Work" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(titleValue));
    });

    it('Edit Item - Attach File - [855672]', async () => {
        const stepLogger = new StepLogger(1176340);
        stepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
            stepLogger);

        // Common functionality to edit any item
        const item = CommonPage.recordWithoutGreenTicket;
        await WaitHelper.getInstance().waitForElementToBeDisplayed(item);

        stepLogger.stepId(1);
        stepLogger.step('Click on the row of item created as per pre requisites');
        await PageHelper.click(item);
        const selectedTitle = await CommonPage.selectedTitle.getText();
        stepLogger.step('Click on "MANAGE" tab');
        await PageHelper.click(CommonPage.ribbonTitles.manage);

        stepLogger.verification('contents of the ITEMS tan should be displayed');
        await expect(await CommonPage.ribbonItems.attachFile.isDisplayed())
            .toBe(true,
                ValidationsHelper.getItemsUnderTabShouldBeDisplayed(CommonPageConstants.ribbonMenuTitles.items));

        stepLogger.stepId(2);
        stepLogger.step('Click on "Attach File" button from button menu of popup');
        await PageHelper.click(CommonPage.ribbonItems.attachFile);

        await CommonPageHelper.switchToContentFrame(stepLogger);

        stepLogger.stepId(4);
        stepLogger.verification('A popup displayed to attach file');
        await expect(await PageHelper.isElementDisplayed(CommonPage.fileUploadControl))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.fileUpload));

        stepLogger.stepId(5);
        stepLogger.step('Click on "Choose File" button in the pop up window Search and select the file to attach');
        const {fullFilePath, newFileName} = CommonPageHelper.uniqueDocumentFilePath;
        await PageHelper.uploadFile(CommonPage.fileUploadControl, fullFilePath);

        stepLogger.verification('Selected file name should be displayed in popup');
        await expect(await ElementHelper.getValue(CommonPage.fileUploadControl))
            .toContain(newFileName,
                ValidationsHelper.getFieldShouldHaveValueValidation(CommonPageConstants.fileUpload, newFileName));

        stepLogger.stepId(6);
        stepLogger.step('Click on "OK" button');
        await PageHelper.click(CommonPage.formButtons.ok);

        stepLogger.verification('Attached file is displayed at bottom of popup page');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFileName, true)))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(newFileName));

        stepLogger.stepId(7);
        stepLogger.step('Click on "Save" button in popup');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        // Nothing else is working to have it frame invisible
        await browser.sleep(PageHelper.timeout.m);

        stepLogger.verification('Popup window is closed');
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editItem));

        stepLogger.stepId(8);
        stepLogger.step('Click on the row of item to which attachment is added [Ex: New Issue 1]');
        await TextboxHelper.sendKeys(CommonPage.searchTextBox, selectedTitle, true);
        await PageHelper.click(item);

        stepLogger.step('Click on "Manage" tab');
        await PageHelper.click(CommonPage.ribbonTitles.manage);

        stepLogger.step('Click on "View Item" button');
        await PageHelper.click(CommonPage.ribbonItems.viewItem);

        stepLogger.verification('Popup window is shown');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(true,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.viewItem));

        await CommonPageHelper.switchToContentFrame(stepLogger);

        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(newFileName)))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(newFileName));
    });
});
