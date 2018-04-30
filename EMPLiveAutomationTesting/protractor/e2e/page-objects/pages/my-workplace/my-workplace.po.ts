import {BasePage} from '../base-page';
import {MyWorkplaceConstants} from './my-workplace.constants';
import {CommonPageHelper} from '../common/common-page.helper';

export class CreateNewPage extends BasePage {
    static get navigation() {
        const labels = MyWorkplaceConstants.navigationLabels;
        return {
            myWork: CommonPageHelper.getSidebarLinkByTextUnderList(labels.myWork),
            myTimeSheet: CommonPageHelper.getSidebarLinkByTextUnderList(labels.myTimeSheet),
            myTimeOff: CommonPageHelper.getSidebarLinkByTextUnderList(labels.myTimeOff),
            toDo: CommonPageHelper.getSidebarLinkByTextUnderList(labels.toDo),
            discussions: CommonPageHelper.getSidebarLinkByTextUnderList(labels.discussions),
            events: CommonPageHelper.getSidebarLinkByTextUnderList(labels.events),
            wikis: CommonPageHelper.getSidebarLinkByTextUnderList(labels.wikis),
            sharedDocuments: CommonPageHelper.getSidebarLinkByTextUnderList(labels.sharedDocuments),
            pictures: CommonPageHelper.getSidebarLinkByTextUnderList(labels.pictures),
            links: CommonPageHelper.getSidebarLinkByTextUnderList(labels.links)
        };
    }
}
