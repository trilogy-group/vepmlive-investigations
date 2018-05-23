import {CommonPageConstants} from '../../common/common-page.constants';

export class LinkPageConstants {
    static readonly pagePrefix = 'Links';
    static readonly pageName = `${LinkPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.newItem}`;
    static readonly editPageName = `${LinkPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.editItem}`;

    static get inputLabels() {
        return {
            url: 'URL *',
            notes: 'Notes'
        };
    }
    static get navigationLabels() {
        return {
            Next: 'Next',
        };
    }
}
