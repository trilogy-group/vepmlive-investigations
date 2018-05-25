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
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitles.first());

        stepLogger.verification('"Changes - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.changes, true))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.changes));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Changes - New Item" window');
        const uniqueId = PageHelper.getUniqueId();
        const inputLabels = MyWorkPageConstants.inputLabels;
        const titleValue = `${inputLabels.title} ${uniqueId}`;
        await MyWorkPageHelper.fillFormAndSave(titleValue, stepLogger);

        stepLogger.stepId(5);
        stepLogger.step(`Newly created Change [Ex: Title 1] displayed in "My Work" page`);
        const label = AnchorHelper.getElementsByTextInsideGrid(inputLabels.title, true);
        await CommonPageHelper.checkItemCreated(titleValue, label);
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
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitles.first());

        stepLogger.verification('"Issues - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.issues, true))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.issues));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Issues - New Item" window');
        const uniqueId = PageHelper.getUniqueId();
        const inputLabels = MyWorkPageConstants.inputLabels;
        const titleValue = `${inputLabels.title} ${uniqueId}`;
        await MyWorkPageHelper.fillFormAndSave(titleValue, stepLogger);

        stepLogger.stepId(5);
        stepLogger.step(`Newly created Issues [Ex: Title 1] displayed in "My Work" page`);
        const label = AnchorHelper.getElementsByTextInsideGrid(MyWorkPageConstants.inputLabels.title, true);
        await CommonPageHelper.checkItemCreated(titleValue, label);
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
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitles.first());

        stepLogger.verification('"Risks - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.risks, true))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.risks));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Risks - New Item" window');
        const uniqueId = PageHelper.getUniqueId();
        const inputLabels = MyWorkPageConstants.inputLabels;
        const titleValue = `${inputLabels.title} ${uniqueId}`;
        await MyWorkPageHelper.fillFormAndSave(titleValue, stepLogger);

        stepLogger.stepId(5);
        stepLogger.step(`Newly created Risks [Ex: Title 1] displayed in "My Work" page`);
        const label = AnchorHelper.getElementsByTextInsideGrid(inputLabels.title, true);
        await CommonPageHelper.checkItemCreated(titleValue, label);
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
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitles.first());

        stepLogger.verification('"Time Off - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.widowTitleName.timeOff, true))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.timeOff));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Time Off - New Item" window');
        const uniqueId = PageHelper.getUniqueId();
        const inputLabels = MyWorkPageConstants.inputLabels;
        const titleValue = `${inputLabels.title} ${uniqueId}`;
        // step#5 is inside this function
        await MyWorkPageHelper.fillTimeOffFormAndSave(titleValue, stepLogger);

        stepLogger.stepId(6);
        stepLogger.verification('"Navigate to My Time Off page');
        await PageHelper.click( MyWorkplacePage.navigation.myTimeOff);
        stepLogger.verification('"Click on last button');
        await PageHelper.click(MyWorkPage.lastButton);
        const label = AnchorHelper.getElementsByTextInsideGrid(inputLabels.title, true);
        stepLogger.step(`Newly created Time Off [Ex: Title 1] displayed in "My Time Off" page`);
        await CommonPageHelper.checkItemCreated(titleValue, label);
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
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitles.first());

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
        // Wait for the page to close after clicking on save. This is to reduce window close synchronization issues
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.m);

        stepLogger.verification('Newly created ToDo Item [Ex: Title 1] displayed in "My Work" page');
        const label = AnchorHelper.getElementsByTextInsideGrid(MyWorkPageConstants.inputLabels.title, true);
        stepLogger.step(`Newly created ToDo [Ex: Title 1] displayed in "My Work" page`);
        await CommonPageHelper.checkItemCreated(titleValue, label);
    });
});
