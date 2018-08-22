import {StepLogger} from '../../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../../components/html/page-helper';
import {EditCost} from './edit-cost.po';
import {CommonPageHelper} from '../../../common/common-page.helper';
import {CommonPage} from '../../../common/common.po';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {EditCostConstants} from './edit-cost.constants';
import {HomePage} from '../../../homepage/home.po';
import {HomePageConstants} from '../../../homepage/home-page.constants';

export class EditCostHelper {

    static async enterValueInBenefitTab(stepLogger: StepLogger, cost: number) {
        stepLogger.step('Enter Value in Benefit Tab');
        await PageHelper.sendKeysToInputFieldAndEnter(EditCost.inputTextBoxForBenefitsCostTab, cost.toString());
    }

    static async verifyValueInBenefitCost(stepLogger: StepLogger, cost: number) {
        stepLogger.verification('Verify  Value in Benefit Cost');
        await CommonPageHelper.textPresentValidation(EditCost.inputTextBoxForBenefitsCostTab , cost.toString());
    }

    static async enterValueInActualCost(stepLogger: StepLogger , cost: number ) {
        stepLogger.step('Enter Cost in Textbox ');
        await PageHelper.sendKeysToInputFieldAndEnter(EditCost.inputTextBoxForActualCostTab , cost.toString());

    }

    static async verifyValueInActualCost(stepLogger: StepLogger, cost: number) {
        stepLogger.verification('Verify  Value in Actual Cost');
        await CommonPageHelper.textPresentValidation(EditCost.inputTextBoxForActualCostTab, cost.toString());
    }

    static async enterValueInBudgetCost(stepLogger: StepLogger, cost: number) {
        stepLogger.step('Enter Value in Budget Tab');
        await PageHelper.sendKeysToInputFieldAndEnter(EditCost.inputTextBoxForBudgetTab , cost.toString());
    }

    static async verifyValueInBudgetCost(stepLogger: StepLogger, cost: number) {
        stepLogger.verification('Enter Value in Benefit Tab');
        await CommonPageHelper.textPresentValidation(EditCost.inputTextBoxForBudgetTab  , cost.toString());
    }

    static async clickActualCostsTab(stepLogger: StepLogger) {
        stepLogger.step('Click Actual Cost Tab');
        await PageHelper.clickAndEnter(EditCost.costTab.actualCostsTab);
    }

    static async clickBudgetTabCostsTab(stepLogger: StepLogger) {
        stepLogger.step('Click budgetTab Cost Tab');
        await PageHelper.clickAndEnter(EditCost.costTab.budgetTab);
    }

    static async clickBenefitsTab(stepLogger: StepLogger) {
        stepLogger.step('Click Benefits Tab');
        await PageHelper.clickAndEnter(EditCost.costTab.benefitsTab);
    }

    static async clickResourcePlanTab(stepLogger: StepLogger) {
        stepLogger.step('Click resourcePlan Tab');
        await PageHelper.clickAndEnter(EditCost.costTab.resourcePlan);
    }

    static async clickTimeSheetActualsTab(stepLogger: StepLogger) {
        stepLogger.step('Click timeSheet Actuals Tab');
        await PageHelper.clickAndEnter(EditCost.costTab.timeSheetActuals);
    }

    static  async clickSaveCostPlanner(stepLogger: StepLogger) {
        stepLogger.step('Click Save Button ');
        await PageHelper.click(CommonPage.ribbonItems.save);
    }

    static  async clickCloseCostPlanner(stepLogger: StepLogger) {
        stepLogger.step('Click Close Button ');
        await WaitHelper.staticWait(PageHelper.timeout.s);

        await PageHelper.click(CommonPage.ribbonItems.close);
    }

    static  async validateEditCostIsDisabled(stepLogger: StepLogger) {
        stepLogger.verification('Validate Edit Cost Is Disabled ');
        await CommonPageHelper.verifyItemDisabled(CommonPage.ribbonItems.editCost);
    }

    static  async validateEditCostIsEnable(stepLogger: StepLogger) {
        stepLogger.verification('Validate Edit Cost Is Enabled');
        await CommonPageHelper.elementAttribueValueValidation(CommonPage.ribbonItems.editCost, '' , 'aria-disabled');
    }

    static  async validateSaveButtonDisabled(stepLogger: StepLogger) {
        stepLogger.verification('Validate SaveButton Is Disabled ');
        const expectedValue = 'ms-cui-ctl-large ms-cui-disabled';

        await CommonPageHelper.elementAttribueValueValidation(CommonPage.ribbonItems.save, expectedValue , 'class');
       }

    static  async validateEditCostFunctionality(stepLogger: StepLogger, value: number) {
        await this.clickActualCostsTab(stepLogger);

        stepLogger.verification('Validate Edit Cost Functionality ');
        await this.clickSaveCostPlanner(stepLogger);

        stepLogger.verification('Validate that Benefits Cost is save ');
        await this.verifyValueInActualCost(stepLogger, value);

        stepLogger.verification('Validate that Benefits Cost is save ');
        await this.verifyValueInActualCost(stepLogger, value);

        await this.validateSaveButtonDisabled(stepLogger);

        await this.clickCloseCostPlanner(stepLogger);

        stepLogger.verification('Validate that Project center page is displayed');
        await CommonPageHelper.fieldDisplayedValidation
        (HomePage.navigation.projects.projects, HomePageConstants.navigationLabels.projects.projects);

        await CommonPageHelper.clickEditCost(stepLogger);

        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.verification('Validate that Budget  Cost is save ');
        await this.verifyValueInBudgetCost(stepLogger, value);

        await this.clickActualCostsTab(stepLogger);

        stepLogger.verification('Validate that Actual  Cost is save ');
        await this.verifyValueInActualCost(stepLogger, value);

        await this.clickBenefitsTab(stepLogger);

        await this.verifyValueInBenefitCost(stepLogger, value);
   }

    static  async validateEditCostWebElements(stepLogger: StepLogger) {

       stepLogger.verification('Validate that Actual  Cost is Present ');
       await CommonPageHelper.fieldDisplayedValidation(EditCost.costTab.actualCostsTab, EditCostConstants.costTabs.actualCostsTab);

       stepLogger.verification('Validate that budget  Cost is Present ');
       await CommonPageHelper.fieldDisplayedValidation(EditCost.costTab.budgetTab, EditCostConstants.costTabs.budgetTab);

       stepLogger.verification('Validate that timeSheetActuals  Cost is Present ');
       await CommonPageHelper.fieldDisplayedValidation(EditCost.costTab.timeSheetActuals, EditCostConstants.costTabs.timeSheetActuals);

       stepLogger.verification('Validate that benefitsTab  Cost is Present ');
       await CommonPageHelper.fieldDisplayedValidation(EditCost.costTab.benefitsTab, EditCostConstants.costTabs.benefitsTab);

       stepLogger.verification('category is present for benefitsTab  Cost ');
       await CommonPageHelper.fieldDisplayedValidation(EditCost.category(), EditCostConstants.category);
    }

    static  async validateCostCategoriesInEachTab(stepLogger: StepLogger) {
        stepLogger.verification('Validate that  cost Categories is present in Budget Tab ');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.category(), EditCostConstants.category);

        await this.clickActualCostsTab(stepLogger);

        stepLogger.verification('Validate that  cost Categories is present in Actual Tab ');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.category(1), EditCostConstants.category);

        await this.clickBenefitsTab(stepLogger);

        stepLogger.verification('Validate that  cost Categories is present in Benefit Tab ');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.category(2), EditCostConstants.category);

        await this.clickResourcePlanTab(stepLogger);

        stepLogger.verification('Validate that  cost Categories is present in Resource plan Tab ');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.category(3), EditCostConstants.category);

        await this.clickTimeSheetActualsTab(stepLogger);

        stepLogger.verification('Validate that  cost Categories is present in time sheet tab  ');
        await CommonPageHelper.fieldDisplayedValidation(EditCost.category(4), EditCostConstants.category);
    }

    static  async enterValueInVariousCategories(stepLogger: StepLogger , cost: number ) {
        stepLogger.step('Enter Value in Cell1');
        await PageHelper.sendKeysToInputField(CommonPage.getCostCell.cell1 , cost.toString());

        stepLogger.step('Enter Value in Cell2');
        await PageHelper.sendKeysToInputField(CommonPage.getCostCell.cell2 , cost.toString());

        await this.enterValueInBudgetCost(stepLogger, cost);
    }

    static  async verifyValueInVariousCategories(stepLogger: StepLogger , cost: number ) {
        await this.verifyValueInBudgetCost(stepLogger, cost);

        stepLogger.verification('Verify  Value in Benefit Cell1');
        await CommonPageHelper.textPresentValidation(CommonPage.getCostCell.cell1 , cost.toString());

        stepLogger.verification('Verify  Value in Benefit Cell2');
        await CommonPageHelper.textPresentValidation(CommonPage.getCostCell.cell2 , cost.toString());
    }
}
