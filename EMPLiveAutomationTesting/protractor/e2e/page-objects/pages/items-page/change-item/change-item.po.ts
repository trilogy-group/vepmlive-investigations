import {BasePage} from '../../base-page';
import {CommonPageHelper} from '../../common/common-page.helper';
import {By, element} from 'protractor';
import {ChangeItemPageConstants} from './change-item-page.constants';

export class ChangeItemPage extends BasePage {
    static get inputs() {
        const labels = ChangeItemPageConstants.inputLabels;
        return {
            title: CommonPageHelper.getTextBoxByLabel(labels.title),
            project: CommonPageHelper.getFirstAutoCompleteByLabel(labels.project),
            assignedTo: CommonPageHelper.getTextBoxByLabel(labels.assignedTo),
            status: CommonPageHelper.getSelectByLabel(labels.status),
            priority: CommonPageHelper.getSelectByLabel(labels.priority),
            startDate: CommonPageHelper.getTextBoxByLabel(labels.startDate),
            dueDate: CommonPageHelper.getTextBoxByLabel(labels.dueDate),
            effort: CommonPageHelper.getTextBoxByLabel(labels.effort),
            category: CommonPageHelper.getSelectByLabel(labels.category),
            inScope: CommonPageHelper.getSelectByLabel(labels.inScope),
            benefitsOfTheChange: CommonPageHelper.getTextAreaByLabel(labels.benefitsOfTheChange),
            impactOfNotMakingTheChange: CommonPageHelper.getTextAreaByLabel(labels.impactOfNotMakingTheChange),
            costImpact: CommonPageHelper.getTextBoxByLabel(labels.costImpact),
            scheduleImpact: CommonPageHelper.getTextAreaByLabel(labels.scheduleImpact),
            resourceImpact: CommonPageHelper.getTextAreaByLabel(labels.resourceImpact)
        };
    }

    static get projectShowAllButton() {
        return element(By.id('Project_ddlShowAll'));
    }
}
