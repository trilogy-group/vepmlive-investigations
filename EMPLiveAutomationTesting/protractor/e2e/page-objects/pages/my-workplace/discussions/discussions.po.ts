import {CommonPageHelper} from '../../common/common-page.helper';
import {DiscussionsPageConstants} from './discussions-page.constants';
import {HtmlHelper} from '../../../../components/misc-utils/html-helper';
import { element} from 'protractor';
import { By } from 'selenium-webdriver';
import { ButtonHelperFactory } from '@aurea/protractor-automation-helper';

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

    static get openDiscussionLink() {
        return element(By.css(`div.ms-comm-postMainContainer.ms-comm-postSubjectColumn > a`));
    }

    static get discussionTitle() {
        return element(By.className('ms-accentText'));
    }

    static get replyButton() {
        console.log(ButtonHelperFactory.getButtonByExactTextXPath(DiscussionsPageConstants.reply));
        return element(By.xpath(ButtonHelperFactory.getButtonByExactTextXPath(DiscussionsPageConstants.reply)));
    } 

    static get replyBody() {
        return element(By.className('ms-comm-postReplyBody'));
    } 

    static get replyMsg() {
        return element(By.id('forum0-Footer-RichTextArea'))
    }      
}
