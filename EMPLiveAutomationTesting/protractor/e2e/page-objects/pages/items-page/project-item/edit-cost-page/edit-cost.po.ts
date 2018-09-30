import {By, element} from 'protractor';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {EditCostConstants} from './edit-cost.constants';
import {CommonPage} from '../../../common/common.po';

export class EditCost {

    static get inputTextBoxForBenefitsCostTab() {
        return this.getEditInput(3);
    }

    static get inputTextBoxForBudgetTab() {
        return CommonPage.getCostCell.cell5;
    }

    static get inputTextBoxForActualCostTab() {
        return CommonPage.getCostCell.cell6;
    }

    static get costTab() {
        const label = EditCostConstants.costTabs;
        return {
            budgetTab: ElementHelper.getElementByText(label.budgetTab),
            actualCostsTab: ElementHelper.getElementByText(label.actualCostsTab),
            benefitsTab: ElementHelper.getElementByText(label.benefitsTab),
            resourcePlan: ElementHelper.getElementByText(label.resourcePlan),
            timeSheetActuals: ElementHelper.getElementByText(label.timeSheetActuals)
        };
    }

    static get editCostLink() {
        return CommonPage.ribbonItems.editCost;
    }

    static get editCostLinkViaEllipse() {
        return CommonPage.contextMenuOptions.editCosts;
    }

    static getEditInput(index = 1) {
        return element(By.xpath(`(//table[@class = "GMMainTable"])[${index}]//*[contains(@class,"GMClassEdit")]`));
    }

    static category(index = 0) {
        return ElementHelper.getAllElementByText(EditCostConstants.category).get(index);
    }
}
