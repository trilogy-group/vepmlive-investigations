import {CommonPageHelper} from '../../common/common-page.helper';
import {DiscussionsPageConstants} from './discussions-page.constants';
import {HtmlHelper} from '../../../../components/misc-utils/html-helper';
import {DiscussionsPageHelper} from './discussions-page.helper';

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
        return DiscussionsPageHelper.getAllDiscussionsItem(HtmlHelper.attributeValue.postMainContainer,
            DiscussionsPageConstants.inputLabels.subject);
        }
}
