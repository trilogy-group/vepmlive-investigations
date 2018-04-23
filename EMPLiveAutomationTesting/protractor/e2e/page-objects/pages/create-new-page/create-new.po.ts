import {BasePage} from '../base-page';
import {CommonPageHelper} from '../common/common-page.helper';
import {CreateNewPageConstants} from './create-new-page.constants';

export class CreateNewPage extends BasePage {
    static get navigation() {
        const listAppsLabels = CreateNewPageConstants.navigationLabels.listApps;
        const libraryAppsLabels = CreateNewPageConstants.navigationLabels.libraryApps;
        return {
            listApps: {
                change: CommonPageHelper.getSidebarLinkByTextUnderList(listAppsLabels.change),
                discussion: CommonPageHelper.getSidebarLinkByTextUnderList(listAppsLabels.discussion),
                event: CommonPageHelper.getSidebarLinkByTextUnderList(listAppsLabels.event),
                issue: CommonPageHelper.getSidebarLinkByTextUnderList(listAppsLabels.issue),
                link: CommonPageHelper.getSidebarLinkByTextUnderList(listAppsLabels.link),
                project: CommonPageHelper.getSidebarLinkByTextUnderList(listAppsLabels.project),
                portfolio: CommonPageHelper.getSidebarLinkByTextUnderList(listAppsLabels.portfolio),
                projectRequest: CommonPageHelper.getSidebarLinkByTextUnderList(listAppsLabels.projectRequest),
                risk: CommonPageHelper.getSidebarLinkByTextUnderList(listAppsLabels.risk),
                timeOff: CommonPageHelper.getSidebarLinkByTextUnderList(listAppsLabels.timeOff),
                toDo: CommonPageHelper.getSidebarLinkByTextUnderList(listAppsLabels.toDo)
            },
            libraryApps: {
                pictures: CommonPageHelper.getSidebarLinkByTextUnderList(libraryAppsLabels.pictures),
                projectDocument: CommonPageHelper.getSidebarLinkByTextUnderList(libraryAppsLabels.projectDocument),
                sharedDocument: CommonPageHelper.getSidebarLinkByTextUnderList(libraryAppsLabels.sharedDocument),
                sitePages: CommonPageHelper.getSidebarLinkByTextUnderList(libraryAppsLabels.sitePages)
            }
        };
    }
}
