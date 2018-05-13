import {CommonPageConstants} from '../../common/common-page.constants';

export class DiscussionsPageConstants {
    static readonly newDiscussion = 'new discussion';
    static readonly pagePrefix = 'Discussions';
    static readonly pageName = `${DiscussionsPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.newItem}`;
    static readonly editPageName = `${DiscussionsPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.editItem}`;
    static readonly subjectInputTitle= 'Subject Required Field';
    static readonly question= 'Question';

    static get inputLabels() {
        return {
            subject: 'Subject *',
            body: 'Description for New Discussion*',
        };
    }
}
