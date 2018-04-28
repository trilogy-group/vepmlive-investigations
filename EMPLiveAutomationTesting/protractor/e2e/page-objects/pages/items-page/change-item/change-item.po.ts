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
            category: CommonPageHelper.getSelectByLabel(labels.effort),
            inScope: CommonPageHelper.getSelectByLabel(labels.effort),
            benefitsOfTheChange: CommonPageHelper.getTextAreaByLabel(labels.effort),
            impactOfNotMakingTheChange: CommonPageHelper.getTextAreaByLabel(labels.effort),
            costImpact: CommonPageHelper.getTextBoxByLabel(labels.effort),
            scheduleImpact: CommonPageHelper.getTextAreaByLabel(labels.effort),
            resourceImpact: CommonPageHelper.getTextAreaByLabel(labels.effort)
        };
    }

    static get projectShowAllButton() {
        return element(By.id('Project_ddlShowAll'));
    }
}
