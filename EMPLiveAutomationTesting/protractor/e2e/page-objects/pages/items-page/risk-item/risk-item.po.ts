import {BasePage} from '../../base-page';
import {RiskItemPageConstants} from './risk-item-page.constants';
import {CommonPageHelper} from '../../common/common-page.helper';
import {By, element} from 'protractor';

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

    static get projectShowAllButton() {
        return element(By.id('Project_ddlShowAll'));
    }
}
