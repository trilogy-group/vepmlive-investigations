import {By, element} from 'protractor';
import {BasePage} from '../../base-page';
import {RiskItemPageConstants} from './risk-item-page.constants';
import {CommonPageHelper} from '../../common/common-page.helper';
import {AnchorHelper} from '../../../../components/html/anchor-helper';
import {CommonPageConstants} from '../../common/common-page.constants';

export class RiskItemPage extends BasePage {

    static get inputs() {
        const labels = RiskItemPageConstants.inputLabels;
        return {
            title: CommonPageHelper.getTextBoxByLabel(labels.title),
            project: CommonPageHelper.getFirstAutoCompleteByLabel(labels.project),
            assignedTo: CommonPageHelper.getTextBoxByLabel(labels.assignedTo),
            status: CommonPageHelper.getSelectByLabel(labels.status),
            priority: CommonPageHelper.getSelectByLabel(labels.priority),
            description: CommonPageHelper.getTextAreaByLabel(labels.description),
            startDate: CommonPageHelper.getTextBoxByLabel(labels.startDate),
            dueDate: CommonPageHelper.getTextBoxByLabel(labels.dueDate),
            effort: CommonPageHelper.getTextBoxByLabel(labels.effort),
            comments: CommonPageHelper.getTextAreaByLabel(labels.comments),
            probability: CommonPageHelper.getTextAreaByLabel(labels.probability),
            impact: CommonPageHelper.getTextAreaByLabel(labels.impact),
            cost: CommonPageHelper.getTextAreaByLabel(labels.cost),
            mitigationPlan: CommonPageHelper.getTextAreaByLabel(labels.mitigationPlan),
            contingencyPlan: CommonPageHelper.getTextAreaByLabel(labels.contingencyPlan),
            trigger: CommonPageHelper.getTextAreaByLabel(labels.trigger),
            triggerDescription: CommonPageHelper.getTextAreaByLabel(labels.triggerDescription)
        };
    }

    static get riskItems() {
        return AnchorHelper
            .getElementsByTextInsideGrid(RiskItemPageConstants.inputLabels.title, true);
    }

    static get riskItem() {
        return AnchorHelper
            .getElementByTextInsideGrid(RiskItemPageConstants.inputLabels.title, true);
    }

    static get attachmentButton() {
        return element(By.css('.upload-attach'));
    }
    static get deleteRisk() {
        return element(By.xpath('//*[contains(text(),\'Delete Item\')]//parent::a'));
    }

    static get columnHeaderSelector() {
        return {
            status: CommonPageHelper.getColumnHeaderByText(CommonPageConstants.columnHeader.status)
        };
    }

    static get columnSortingItems() {
        const columnHeader = CommonPageConstants.columnHeader;
        return {
            status: {
                ascending: CommonPageHelper.getAscendingColumnSelector(columnHeader.status),
                descending: CommonPageHelper.getDescendingColumnSelector(columnHeader.status)
            },
        };
    }
}
