import {CommonPageHelper} from '../../common/common-page.helper';
import {DiscussionsPageConstants} from './discussions-page.constants';
import {HtmlHelper} from '../../../../components/misc-utils/html-helper';
import { element, by } from 'protractor';
import { ComponentHelpers } from '../../../../components/devfactory/component-helpers/component-helpers';
import { By } from 'selenium-webdriver';
import { ElementHelper } from '../../../../components/html/element-helper';

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
        const xpath = `//button[${ComponentHelpers.getXPathFunctionForText(DiscussionsPageConstants.reply)}]`;
        return element(By.xpath(xpath));
    }  

    static get replyBody() {
        return element(By.className('ms-comm-postReplyBody'));
    } 

    static get replyMsg() {
        return ElementHelper.getElementByText(DiscussionsPageConstants.placeHolder);
    }      
}
