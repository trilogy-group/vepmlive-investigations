import {BasePage} from '../../base-page';
import {IssueItemPageConstants} from './issue-item-page.constants';
import {CommonPageHelper} from '../../common/common-page.helper';

export class IssueItemPage extends BasePage {
    static get inputs() {
        const labels = IssueItemPageConstants.inputLabels;
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
}
