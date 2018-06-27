import {CommonPageConstants} from '../../common/common-page.constants';

export class DiscussionsPageConstants {
    static readonly newDiscussion = 'new discussion';
    static readonly pagePrefix = 'Discussions';
    static readonly pageName = `${DiscussionsPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.newItem}`;
    static readonly discussionPage = `${DiscussionsPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.subject}`;
    static readonly editPageName = `${DiscussionsPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.editItem}`;
    static readonly subjectInputTitle= 'Subject Required Field';
    static readonly question= 'Question';
    static readonly reply = 'Reply';

    static get inputLabels() {
        return {
            subject: 'Subject *',
            body: 'Description for New Discussion*',
            reply: 'reply *',
        };
    }

    static get classLabel() {
        return {
            postListItemClass: 'postListItem'
        };
    }
}
