import {StepLogger} from '../../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../../components/html/page-helper';
import {EditCost} from './edit-cost.po';
import {CommonPageHelper} from '../../../common/common-page.helper';
import {CommonPage} from '../../../common/common.po';
import {EditCostConstants} from './edit-cost.constants';
import {HomePage} from '../../../homepage/home.po';
import {HomePageConstants} from '../../../homepage/home-page.constants';
import {ExpectationHelper} from '../../../../../components/misc-utils/expectation-helper';
import {CommonPageConstants} from '../../../common/common-page.constants';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';

export class EditCostHelper {

    static async enterValueInBenefitTab(cost: number) {
        StepLogger.step('Enter Value in Benefit Tab');
        await PageHelper.sendKeysToInputFieldAndEnter(EditCost.inputTextBoxForBenefitsCostTab, cost.toString());
    }

    static async verifyValueInBenefitCost(cost: number) {
        StepLogger.verification('Verify  Value in Benefit Cost');
        await CommonPageHelper.textPresentValidation(EditCost.inputTextBoxForBenefitsCostTab, cost.toString());
    }

    static async enterValueInActualCost(cost: number) {
        StepLogger.step('Enter Cost in Textbox ');
        await PageHelper.sendKeysToInputFieldAndEnter(EditCost.inputTextBoxForActualCostTab, cost.toString());

    }

    static async verifyValueInActualCost(cost: number) {
        StepLogger.verification('Verify  Value in Actual Cost');
        await CommonPageHelper.textPresentValidation(EditCost.inputTextBoxForActualCostTab, cost.toString());
    }

    static async enterValueInBudgetCost(cost: number) {
        StepLogger.step('Enter Value in Budget Tab');
        await PageHelper.sendKeysToInputFieldAndEnter(EditCost.inputTextBoxForBudgetTab, cost.toString());
    }

    static async verifyValueInBudgetCost(cost: number) {
        StepLogger.subVerification('Verify Value in budget tab');
        await CommonPageHelper.textPresentValidation(EditCost.inputTextBoxForBudgetTab, cost.toString());
    }

    static async clickActualCostsTab() {
        StepLogger.step('Click Actual Cost Tab');
        await PageHelper.click(EditCost.costTab.actualCostsTab);
        const isClicked = await WaitHelper.waitForElementToBeDisplayed(EditCost.veil, PageHelper.timeout.s);
        if (!isClicked) {
            await PageHelper.click(EditCost.costTab.actualCostsTab);
        }
    }

    static async clickBudgetTabCostsTab() {
        StepLogger.step('Click budgetTab Cost Tab');
        await PageHelper.clickAndEnter(EditCost.costTab.budgetTab);
    }

    static async clickBenefitsTab() {
        StepLogger.step('Click Benefits Tab');
        await PageHelper.click(EditCost.costTab.benefitsTab);
        const isClicked = await WaitHelper.waitForElementToBeDisplayed(EditCost.veil, PageHelper.timeout.s);
        if (!isClicked) {
            await PageHelper.click(EditCost.costTab.benefitsTab);
        }
    }

    static async clickResourcePlanTab() {
        StepLogger.step('Click resourcePlan Tab');
        await PageHelper.clickAndEnter(EditCost.costTab.resourcePlan);
    }

    static async clickTimeSheetActualsTab() {
        StepLogger.step('Click timeSheet Actuals Tab');
        await PageHelper.clickAndEnter(EditCost.costTab.timeSheetActuals);
    }

    static async clickSaveCostPlanner() {
        StepLogger.step('Click Save Button ');
        await PageHelper.click(CommonPage.ribbonItems.save);
    }

    static async clickCloseCostPlanner() {
        StepLogger.subStep('Click Close Button');
        await WaitHelper.waitForElementToBeHidden(EditCost.veil);
        await PageHelper.click(EditCost.close);
        await PageHelper.acceptAlertIfPresent();
    }

    static async validateEditCostIsDisabled() {
        StepLogger.verification('Validate Edit Cost Is Disabled ');
        await ExpectationHelper.verifyAttributeContains(CommonPage.ribbonItems.editCost, 'class', 'ms-cui-disabled');
    }

    static async validateEditCostIsEnable() {
        StepLogger.verification('Validate Edit Cost Is Enabled');
        // Static wait is needed as after selecting the project it takes a while for element to be enabled
        await PageHelper.sleepForXSec(10000);
        await ExpectationHelper.verifyAttributeValue(CommonPage.ribbonItems.editCost, 'class', 'ms-cui-ctl-large');
    }

    static async validateSaveButtonDisabled() {
        StepLogger.verification('Validate SaveButton Is Disabled ');
        const expectedValue = 'ms-cui-ctl-large ms-cui-disabled';

        await ExpectationHelper.verifyAttributeValue(CommonPage.ribbonItems.save, 'class', expectedValue);
    }

    static async validateEditCostFunctionality(value: number) {
        StepLogger.subStep('Click on "Save" button in "Cost Planner" window');
        await this.clickSaveCostPlanner();
        await this.validateSaveButtonDisabled();
        StepLogger.subStep('Click on "Close" button in "Cost Planner" window');
        await this.clickCloseCostPlanner();

        StepLogger.verification('Validate that Project center page is displayed');
        await CommonPageHelper.fieldDisplayedValidation
        (HomePage.navigation.projects.projects, HomePageConstants.navigationLabels.projects.projects);

        await CommonPageHelper.clickEditCost();

        await CommonPageHelper.switchToFirstContentFrame();

        StepLogger.verification('Validate that Budget  Cost is save ');

        await this.verifyValueInBudgetCost(value);

        await this.clickActualCostsTab();

        StepLogger.verification('Validate that Actual  Cost is save ');
        await this.verifyValueInActualCost(value);

        await this.clickBenefitsTab();

        await this.verifyValueInBenefitCost(value);
    }

    static async validateEditCostWebElements() {

        StepLogger.verification('Validate that Actual  Cost is Present ');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.costTab.actualCostsTab, EditCostConstants.costTabs.actualCostsTab);

        StepLogger.verification('Validate that budget  Cost is Present ');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.costTab.budgetTab, EditCostConstants.costTabs.budgetTab);

        StepLogger.verification('Validate that timeSheetActuals  Cost is Present ');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.costTab.timeSheetActuals, EditCostConstants.costTabs.timeSheetActuals);

        StepLogger.verification('Validate that benefitsTab  Cost is Present ');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.costTab.benefitsTab, EditCostConstants.costTabs.benefitsTab);

        StepLogger.verification('category is present for benefitsTab  Cost ');

        await CommonPageHelper.fieldDisplayedValidation(EditCost.category(), EditCostConstants.category);
    }

    static async validateCostCategoriesInEachTab() {
        StepLogger.verification('Validate that  cost Categories is present in Budget Tab ');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.category(), EditCostConstants.category);

        await this.clickActualCostsTab();

        StepLogger.verification('Validate that  cost Categories is present in Actual Tab ');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.category(1), EditCostConstants.category);

        await this.clickBenefitsTab();

        StepLogger.verification('Validate that  cost Categories is present in Benefit Tab ');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.category(2), EditCostConstants.category);

        await this.clickResourcePlanTab();

        StepLogger.verification('Validate that  cost Categories is present in Resource plan Tab ');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.category(3), EditCostConstants.category);

        await this.clickTimeSheetActualsTab();

        StepLogger.verification('Validate that  cost Categories is present in time sheet tab  ');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.category(4), EditCostConstants.category);
    }

    static async enterValueInVariousCategories(cost: number) {
        StepLogger.step('Enter Value in Cell1');
        await PageHelper.sendKeysToInputField(CommonPage.getCostCell.cell1, cost.toString());

        StepLogger.step('Enter Value in Cell2');
        await PageHelper.sendKeysToInputField(CommonPage.getCostCell.cell2, cost.toString());

        await this.enterValueInBudgetCost(cost);
    }

    static async verifyValueInVariousCategories(cost: number) {
        await this.verifyValueInBudgetCost(cost);

        StepLogger.verification('Verify  Value in Benefit Cell1');
        await CommonPageHelper.textPresentValidation(CommonPage.getCostCell.cell1, cost.toString());

        StepLogger.verification('Verify  Value in Benefit Cell2');
        await CommonPageHelper.textPresentValidation(CommonPage.getCostCell.cell2, cost.toString());
    }

    static async clickEditCostFromContextMenu() {
        StepLogger.step('Select "Edit Cost" from Context Menu options displayed');
        await PageHelper.click(CommonPage.contextMenuOptions.editCosts);
    }

    static async verifiyEditCostIsPresent() {
        StepLogger.verification('Verifiy Edit cost is present');
        await CommonPageHelper.fieldDisplayedValidation(CommonPage.ribbonItems.editCost, CommonPageConstants.ribbonLabels.editCost);
    }

    static async editCostOpenViaRibbonInNewTab() {
        StepLogger.step('Open Cost In New Tab');
        await ElementHelper.openLinkInNewTab(EditCost.editCostLink);
    }

    static async validateEditCostOpenInNewTab() {
        StepLogger.verification('Switch To new Tab  ');
        await PageHelper.switchToNewTabIfAvailable(1);
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);

        StepLogger.verification('Validate that Actual  Cost is Present ');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.costTab.actualCostsTab, EditCostConstants.costTabs.actualCostsTab);
    }
}
