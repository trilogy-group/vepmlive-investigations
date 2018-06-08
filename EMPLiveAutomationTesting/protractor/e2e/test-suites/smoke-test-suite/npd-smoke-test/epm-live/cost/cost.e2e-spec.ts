import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {browser} from 'protractor';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Validate Edit Cost Functionality in Cost Planner - [743932]', async () => {
        const stepLogger = new StepLogger(743932);

        stepLogger.stepId(1);
        stepLogger.step('Select "Navigation" icon  from left side menu');
        stepLogger.step('Select Projects -> Projects from the options displayed');

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Select any project from project center');
        await PageHelper.click(CommonPage.project);

        stepLogger.step('Click ITEMS tab select Edit Costs');
        await PageHelper.click(CommonPage.ribbonItems.editCost);

        stepLogger.verification('Cost Planner window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await PageHelper.isElementPresent(CommonPage.dialogTitle)).toBe(true);

        stepLogger.stepId(4);
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        stepLogger.step('Ensure that Budget tab is selected');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.budgetTab);
        await expect(await PageHelper.isElementPresent(CommonPage.budgetTab)).toBe(true);

        stepLogger.step('Enter some costs');
        await PageHelper.sendKeysToInputField(CommonPage.cellTextBox1, CommonPageConstants.costData.budgetData);

        stepLogger.verification('Costs entered in Budget tab');
        await expect(await CommonPage.cellTextBox1.getText())
            .toBe(CommonPageConstants.costData.budgetData);

        stepLogger.stepId(5);
        stepLogger.step('Click on Actual Costs tab');
        await PageHelper.click(CommonPage.actualCostTab);
        stepLogger.step('Enter some costs');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.cellTextBox2);
        await PageHelper.sendKeysToInputField(CommonPage.cellTextBox2, CommonPageConstants.costData.actualCostData);

        stepLogger.verification('Costs entered in Actual Costs tab');
        await expect(await CommonPage.cellTextBox2.getText())
            .toBe(CommonPageConstants.costData.actualCostData);

        stepLogger.stepId(6);
        stepLogger.step('Click on Benefits tab');
        await PageHelper.click(CommonPage.benefitsCostTab);

        stepLogger.step('Enter some costs');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.cellTextBox3);
        await PageHelper.sendKeysToInputField(CommonPage.cellTextBox3, CommonPageConstants.costData.benefitsData);

        stepLogger.verification('Costs entered in Benefits tab');
        await expect(await CommonPage.cellTextBox3.getText())
            .toBe(CommonPageConstants.costData.benefitsData);

        stepLogger.stepId(7);
        stepLogger.step('Click on Save button');
        await ElementHelper.clickUsingJs(await CommonPage.ribbonItems.save);

        stepLogger.stepId(8);
        stepLogger.step('Click on Close button');
        await ElementHelper.clickUsingJs(await CommonPage.ribbonItems.close);

        stepLogger.stepId(9);
        stepLogger.step('Reopen the "Cost Planner" [Click on Edit Costs in ITEMS menu]');
        await PageHelper.click(CommonPage.ribbonItems.editCost);

        stepLogger.step('Check the details displayed in Budget, Actual Costs, Benefits tabs');
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.budgetTab);

        stepLogger.verification('Cost details displayed in Budget tab are same as values entered in Step# 4');
        await expect(await CommonPage.cellTextBox1.getText()).toBe(CommonPageConstants.costData.budgetData);

        stepLogger.verification('Cost details displayed in Actual Costs tab are same as values entered in Step# 5');
        await PageHelper.click(CommonPage.actualCostTab);
        await expect(await CommonPage.cellTextBox2.getText()).toBe(CommonPageConstants.costData.actualCostData);

        stepLogger.verification('Click on Benefits tabs');
        await PageHelper.click(CommonPage.benefitsCostTab);
        await expect(await CommonPage.cellTextBox3.getText()).toBe(CommonPageConstants.costData.benefitsData);

    });
});
