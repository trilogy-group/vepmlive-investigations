import {BasePage} from '../base-page';
import {CommonPageHelper} from '../common/common-page.helper';
import {CreateNewPageConstants} from './create-new-page.constants';

export class CreateNewPage extends BasePage {
    static get navigation() {
        const listAppsLabels = CreateNewPageConstants.navigationLabels.listApps;
        const libraryAppsLabels = CreateNewPageConstants.navigationLabels.libraryApps;
        return {
            listApps: {
                change: CommonPageHelper.getSidebarLinkByTextUnderCreateNew(listAppsLabels.change),
                discussion: CommonPageHelper.getSidebarLinkByTextUnderCreateNew(listAppsLabels.discussion),
                event: CommonPageHelper.getSidebarLinkByTextUnderCreateNew(listAppsLabels.event),
                issue: CommonPageHelper.getSidebarLinkByTextUnderCreateNew(listAppsLabels.issue),
                link: CommonPageHelper.getSidebarLinkByTextUnderCreateNew(listAppsLabels.link),
                project: CommonPageHelper.getSidebarLinkByTextUnderCreateNew(listAppsLabels.project),
                portfolio: CommonPageHelper.getSidebarLinkByTextUnderCreateNew(listAppsLabels.portfolio),
                projectRequest: CommonPageHelper.getSidebarLinkByTextUnderCreateNew(listAppsLabels.projectRequest),
                risk: CommonPageHelper.getSidebarLinkByTextUnderCreateNew(listAppsLabels.risk),
                timeOff: CommonPageHelper.getSidebarLinkByTextUnderCreateNew(listAppsLabels.timeOff),
                toDo: CommonPageHelper.getSidebarLinkByTextUnderCreateNew(listAppsLabels.toDo)
            },
            libraryApps: {
                pictures: CommonPageHelper.getSidebarLinkByTextUnderCreateNew(libraryAppsLabels.pictures),
                projectDocument: CommonPageHelper.getSidebarLinkByTextUnderCreateNew(libraryAppsLabels.projectDocument),
                sharedDocument: CommonPageHelper.getSidebarLinkByTextUnderCreateNew(libraryAppsLabels.sharedDocument),
                sitePages: CommonPageHelper.getSidebarLinkByTextUnderCreateNew(libraryAppsLabels.sitePages)
            }
        };
    }
}
