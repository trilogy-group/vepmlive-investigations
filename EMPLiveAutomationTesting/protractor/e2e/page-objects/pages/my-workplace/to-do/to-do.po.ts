import {CommonPageHelper} from '../../common/common-page.helper';
import {ToDoPageConstants} from './to-do-page.constants';

export class ToDoPage {
    static get inputs() {
        const labels = ToDoPageConstants.inputLabels;
        return {
            title: CommonPageHelper.getTextBoxByLabel(labels.title),
            status: CommonPageHelper.getSelectByLabel(labels.status),
            assignedTo: CommonPageHelper.getTextBoxByLabel(labels.assignedTo),
            priority: CommonPageHelper.getSelectByLabel(labels.priority),
            startDate: CommonPageHelper.getTextBoxByLabel(labels.startDate),
            dueDate: CommonPageHelper.getTextBoxByLabel(labels.dueDate),
            work: CommonPageHelper.getTextBoxByLabel(labels.work),
            description: CommonPageHelper.getTextAreaByLabel(labels.description)
        };
    }
}
