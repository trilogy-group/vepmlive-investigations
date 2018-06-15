import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {browser} from 'protractor';
import {ProjectItemPage} from '../../../../../page-objects/pages/items-page/project-item/project-item.po';

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
        await expect(await PageHelper.isElementPresent(CommonPage.dialogTitle)).toBe(true,
            ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.contextMenuOptions.costPlan));

        stepLogger.stepId(4);
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        stepLogger.step('Ensure that Budget tab is selected');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.costButton.budget);
        await expect(await PageHelper.isElementPresent(CommonPage.costButton.budget)).toBe(true,
            ValidationsHelper.getMenuDisplayedValidation(ProjectItemPageConstants.inputLabels.budget));

        stepLogger.step('Enter some costs');
        await PageHelper.sendKeysToInputField(CommonPageHelper.getCell.cell1, CommonPageConstants.costData.budgetData);

        stepLogger.verification('Costs entered in Budget tab');
        await expect(await CommonPageHelper.getCell.cell1.getText()).toBe
        (CommonPageConstants.costData.budgetData, ValidationsHelper.getFieldShouldHaveValueValidation
        (ProjectItemPageConstants.inputLabels.budget, CommonPageConstants.costData.budgetData ));

        stepLogger.stepId(5);
        stepLogger.step('Click on Actual Costs tab');
        await CommonPageHelper.getEditCostTab(ProjectItemPageConstants.columnNames.actualCost);

        stepLogger.step('Enter some costs');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPageHelper.getCell.cell2);
        await PageHelper.sendKeysToInputField(CommonPageHelper.getCell.cell2, CommonPageConstants.costData.actualCostData);

        stepLogger.verification('Costs entered in Actual Costs tab');
        await expect(await CommonPageHelper.getCell.cell2.getText()).toBe
        (CommonPageConstants.costData.actualCostData, ValidationsHelper.getFieldShouldHaveValueValidation
        (ProjectItemPageConstants.columnNames.actualCost, CommonPageConstants.costData.actualCostData ));

        stepLogger.stepId(6);
        stepLogger.step('Click on Benefits tab');
        await CommonPageHelper.getEditCostTab(ProjectItemPageConstants.inputLabels.benefits);

        stepLogger.step('Enter some costs');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPageHelper.getCell.cell3);
        await PageHelper.sendKeysToInputField(CommonPageHelper.getCell.cell3, CommonPageConstants.costData.benefitsData);

        stepLogger.verification('Costs entered in Benefits tab');
        await expect(await CommonPageHelper.getCell.cell3.getText()).toBe
        (CommonPageConstants.costData.benefitsData, ValidationsHelper.getFieldShouldHaveValueValidation
        (ProjectItemPageConstants.columnNames.benefits, CommonPageConstants.costData.benefitsData));

        stepLogger.stepId(7);
        stepLogger.step('Click on Save button');
        await ElementHelper.clickUsingJs(CommonPage.ribbonItems.save);

        stepLogger.stepId(8);
        stepLogger.step('Click on Close button');
        // No helper works it required wait
        await browser.sleep(PageHelper.timeout.s);
        await ElementHelper.clickUsingJs(CommonPage.ribbonItems.close);

        stepLogger.stepId(9);
        stepLogger.step('Reopen the "Cost Planner" [Click on Edit Costs in ITEMS menu]');
        // No helper works it required wait
        await browser.sleep(PageHelper.timeout.m);
        await PageHelper.click(CommonPage.ribbonItems.editCost);

        stepLogger.step('Check the details displayed in Budget, Actual Costs, Benefits tabs');
        await browser.sleep(PageHelper.timeout.m);
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.costButton.budget);

        stepLogger.verification('Cost details displayed in Budget tab are same as values entered in Step# 4');

        await expect(await CommonPageHelper.getCell.cell1.getText()).toBe
        (CommonPageConstants.costData.budgetData, ValidationsHelper.getFieldShouldHaveValueValidation
        (ProjectItemPageConstants.inputLabels.budget, CommonPageConstants.costData.budgetData ));

        stepLogger.verification('Cost details displayed in Actual Costs tab are same as values entered in Step# 5');
        await PageHelper.click(CommonPageHelper.getEditCostTab(ProjectItemPageConstants.columnNames.actualCost));
        await expect(CommonPageHelper.getCell.cell2).toBe(CommonPageConstants.costData.actualCostData,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.columnNames.actualCost,
                CommonPageConstants.costData.actualCostData ));

        stepLogger.verification('Click on Benefits tabs');
        await PageHelper.click(CommonPageHelper.getEditCostTab(ProjectItemPageConstants.inputLabels.benefits));
        await expect(CommonPageHelper.getCell.cell3).toBe(CommonPageConstants.costData.benefitsData,
            ValidationsHelper.getFieldShouldHaveValueValidation(ProjectItemPageConstants.columnNames.benefits,
                CommonPageConstants.costData.benefitsData ));

        // Delete created task
        await PageHelper.click(ProjectItemPage.selectTaskName);
        await PageHelper.click(ProjectItemPage.deleteTask);
        await browser.switchTo().alert().accept();
        await ElementHelper.clickUsingJs(ProjectItemPage.save);
        // After save It need static wait(5 sec) and no element found which get change after save.
        await browser.sleep(PageHelper.timeout.s);
    });
});
