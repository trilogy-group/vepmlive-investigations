import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {MyWorkPage} from '../../../../../page-objects/pages/my-workplace/my-work/my-work.po';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {MyWorkPageConstants} from '../../../../../page-objects/pages/my-workplace/my-work/my-work-page.constants';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {browser} from 'protractor';
import {MyWorkPageHelper} from '../../../../../page-objects/pages/my-workplace/my-work/my-work-page.helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goToAndLogin();
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
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(MyWorkPage.newItem);

        stepLogger.step('Select "Change Item" option from menu');
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(MyWorkPage.newItemMenu.changesItem);

        stepLogger.verification('Wait for "Changes - New Item" window to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitles.first());

        stepLogger.verification('"Changes - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.dialogWindowTitle(MyWorkPageConstants.pageName.changes), true))
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
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(MyWorkPage.newItem);

        stepLogger.step('Select "Issues Item" option from menu');
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(MyWorkPage.newItemMenu.issuesItem);

        stepLogger.verification('Wait for "Issues - New Item" window to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitles.first());

        stepLogger.verification('"Issues - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.dialogWindowTitle(MyWorkPageConstants.pageName.issues), true))
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
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(MyWorkPage.newItem);

        stepLogger.step('Select "Risks Item" option from menu');
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(MyWorkPage.newItemMenu.risksItem);

        stepLogger.verification('Wait for "Risks - New Item" window to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitles.first());

        stepLogger.verification('"Risks - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.dialogWindowTitle(MyWorkPageConstants.pageName.risks), true))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.risks));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Issues - New Item" window');
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
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(MyWorkPage.newItem);

        stepLogger.step('Select "Risks Item" option from menu');
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(MyWorkPage.newItemMenu.timeOffItem);

        stepLogger.verification('Wait for "Risks - New Item" window to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitles.first());

        stepLogger.verification('"Risks - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.dialogWindowTitle(MyWorkPageConstants.pageName.timeOff), true))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.timeOff));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Issues - New Item" window');
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
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(MyWorkPage.newItem);

        stepLogger.step('Select "To Do Item" option from menu');
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.click(MyWorkPage.newItemMenu.toDoItem);

        stepLogger.verification('Wait for "To Do - New Item" window to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitles.first());

        stepLogger.verification('"To Do - New Item" window is displayed');
        await expect(await PageHelper.isElementDisplayed(MyWorkPage.dialogWindowTitle(MyWorkPageConstants.pageName.toDo), true))
            .toBe(true, ValidationsHelper.getDisplayedValidation(MyWorkPageConstants.title.toDo));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select required details in "Issues - New Item" window');
        const uniqueId = PageHelper.getUniqueId();
        const labels = MyWorkPageConstants.inputLabels;
        stepLogger.step(`Title *: New Item`);
        const titleValue = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, titleValue);
        stepLogger.step(`Assigned To: New Item`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.assignedTo, CommonPageHelper.adminEmailId);
        await browser.sleep(PageHelper.timeout.s);
        stepLogger.step(`select assignedTo value`);
        await PageHelper.click(MyWorkPage.selectInputValue(CommonPageHelper.adminEmailId));

        stepLogger.stepId(5);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"To Do New Item" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(MyWorkPageConstants.editPageName));

        stepLogger.verification('Newly created ToDo Item [Ex: Title 1] displayed in "My Work" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementsByTextInsideGrid(titleValue).first()))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(titleValue));
    });
});
