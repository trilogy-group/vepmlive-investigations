import {BasePage} from '../../../base-page';
import {IssueNewItemPageConstants} from './issue-item-page.constants';
import {CommonPageHelper} from '../../../common/common-page.helper';
import {By, element} from 'protractor';

export class IssueNewItemPage extends BasePage {
    static get inputs() {
        const labels = IssueNewItemPageConstants.inputLabels;
        return {
            title: CommonPageHelper.getTextBoxByLabel(labels.title),
            project: CommonPageHelper.getFirstAutoCompleteByLabel(labels.project),
            assignedTo: CommonPageHelper.getTextBoxByLabel(labels.assignedTo),
            status: CommonPageHelper.getSelectByLabel(labels.status),
            priority: CommonPageHelper.getSelectByLabel(labels.priority),
            description: CommonPageHelper.getTextAreaByLabel(labels.description),
            relatedIssues: CommonPageHelper.getFirstAutoCompleteByLabel(labels.relatedIssues),
            startDate: CommonPageHelper.getTextBoxByLabel(labels.startDate),
            dueDate: CommonPageHelper.getTextBoxByLabel(labels.dueDate),
            effort: CommonPageHelper.getTextBoxByLabel(labels.effort),
            comments: CommonPageHelper.getTextAreaByLabel(labels.comments),
            resolution: CommonPageHelper.getTextAreaByLabel(labels.resolution)
        };
    }

    static get projectShowAllButton() {
        return element(By.id('Project_ddlShowAll'));
    }
}
