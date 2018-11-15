import { By, element } from 'protractor';

import { CommonPageHelper } from '../../common/common-page.helper';
import { DiscussionsPageConstants } from './discussions-page.constants';
import { HtmlHelper } from '../../../../components/misc-utils/html-helper';
import { DiscussionsPageHelper } from './discussions-page.helper';
import { ButtonHelper } from '../../../../components/html/button-helper';
import { CommonPageConstants } from '../../common/common-page.constants';
import { AnchorHelper } from '../../../../components/html/anchor-helper';
import { SocialStreamPageConstants } from '../../settings/social-stream/social-stream-page.constants';

export class DiscussionsPage {

    static get newDiscussionLink() {
        return CommonPageHelper.getSpanByText(DiscussionsPageConstants.newDiscussion);
    }

    static get subjectTextField() {
        return CommonPageHelper.getElementByTitle(DiscussionsPageConstants.subjectInputTitle);
    }

    static get bodyTextBox() {
        return CommonPageHelper.getElementByRole(HtmlHelper.tags.textBox);
    }

    static get questionCheckbox() {
        return CommonPageHelper.getElementByTitle(DiscussionsPageConstants.question);
    }

    static get allDiscussionItems() {
        return DiscussionsPageHelper.discussionsItems(HtmlHelper.attributeValue.postMainContainer,
            DiscussionsPageConstants.inputLabels.subject);
    }

    static get openDiscussionLinkByText() {
        return (text: string) => element(By.cssContainingText(`div.ms-comm-postMainContainer.ms-comm-postSubjectColumn > a`, text));
    }

    static get discussionTitle() {
        return element(By.className('ms-accentText'));
    }

    static get replyButton() {
        return ButtonHelper.getButtonByText(DiscussionsPageConstants.reply);
    }

    static get replyBody() {
        return element(By.className('ms-comm-postReplyBody'));
    }

    static get replyMsg() {
        return element(By.id('forum0-Footer-RichTextArea'));
    }

    static get buttonSelector() {
        return {
            edit: AnchorHelper.getAnchorByText(CommonPageConstants.buttonName.edit)
        };
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

    static getDiscussionField(textValue: string) {
        return element(By.xpath(`//td[normalize-space(.)='${textValue}']//following-sibling::td[contains(@class, GMCell)]`));
    }

    static getRowByDot(textValue: string) {
        return element(By.xpath(`//td[normalize-space(.)='${textValue}']`));
    }

    static get discussionInList() {
        return {
            trTag: (subject: string) => element(By.xpath(`//*/tr[@class='GMDataRow ' and contains((.),'${subject}')]`))
        };
    }
}
