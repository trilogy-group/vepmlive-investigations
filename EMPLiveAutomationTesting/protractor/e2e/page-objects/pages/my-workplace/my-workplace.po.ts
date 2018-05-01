import {BasePage} from '../base-page';
import {MyWorkplaceConstants} from './my-workplace.constants';
import {CommonPageHelper} from '../common/common-page.helper';

export class MyWorkplacePage extends BasePage {
    static get navigation() {
        const labels = MyWorkplaceConstants.navigationLabels;
        return {
            myWork: CommonPageHelper.getSidebarLinkByTextUnderMyWorkPlace(labels.myWork),
            myTimeSheet: CommonPageHelper.getSidebarLinkByTextUnderMyWorkPlace(labels.myTimeSheet),
            myTimeOff: CommonPageHelper.getSidebarLinkByTextUnderMyWorkPlace(labels.myTimeOff),
            toDo: CommonPageHelper.getSidebarLinkByTextUnderMyWorkPlace(labels.toDo),
            discussions: CommonPageHelper.getSidebarLinkByTextUnderMyWorkPlace(labels.discussions),
            events: CommonPageHelper.getSidebarLinkByTextUnderMyWorkPlace(labels.events),
            wikis: CommonPageHelper.getSidebarLinkByTextUnderMyWorkPlace(labels.wikis),
            sharedDocuments: CommonPageHelper.getSidebarLinkByTextUnderMyWorkPlace(labels.sharedDocuments),
            pictures: CommonPageHelper.getSidebarLinkByTextUnderMyWorkPlace(labels.pictures),
            links: CommonPageHelper.getSidebarLinkByTextUnderMyWorkPlace(labels.links)
        };
    }
}
