import {By, element} from 'protractor';
import {CommonPageHelper} from '../../common/common-page.helper';
import {ToDoPageConstants} from './to-do-page.constants';
import {HtmlHelper} from '../../../../components/misc-utils/html-helper';
import {SocialStreamPageConstants} from '../../settings/social-stream/social-stream-page.constants';

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

    static get closeButton() {
        return CommonPageHelper.getAllElementsByType(HtmlHelper.tags.submit);
   }

    static get menueLink() {
        return element.all(By.xpath(`${this.gridTab}//*[contains(@class,'menuLink')]`));
    }

    static get gridTab() {
        return `//span[contains(@title,'Un') or contains(@title,'grid')]//parent::div`;
    }

    static get delete() {
        return CommonPageHelper.getElementByTitle(SocialStreamPageConstants.settingItems.delete);
    }

    static get gridGantt() {
        return element(By.id('GanttGrid0Main'));
    }

}
