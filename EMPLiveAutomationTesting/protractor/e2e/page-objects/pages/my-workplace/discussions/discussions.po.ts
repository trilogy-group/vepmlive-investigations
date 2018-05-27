import {CommonPageHelper} from '../../common/common-page.helper';
import {DiscussionsPageConstants} from './discussions-page.constants';
import {HtmlHelper} from '../../../../components/misc-utils/html-helper';
import { element, by } from 'protractor';
import { ComponentHelpers } from '../../../../components/devfactory/component-helpers/component-helpers';

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
        return element(by.css(`div[class='ms-comm-postMainContainer ms-comm-postSubjectColumn']>a`));
    }

    static get Discussiontitle() {
        return element(by.className('ms-accentText'));
    }

    static get replyButton() {
        const xpath = `//button[${ComponentHelpers.getXPathFunctionForText(DiscussionsPageConstants.reply,false)}]`;
        return element(by.xpath(xpath));
    }  

    static get replyBody() {
        return element(by.className('ms-comm-postReplyBody'));
    } 

    static get replyMsg() {
        return element(by.id('forum0-Footer-RichTextArea'));
    }      
}
