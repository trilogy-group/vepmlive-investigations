import {BasePage} from '../base-page';
import {CommonPageHelper} from '../common/common-page.helper';
import {HomePageConstants} from './home-page.constants';
import {By, element} from 'protractor';
import {CreateNewPageConstants} from '../items-page/create-new-page.constants';

export class HomePage extends BasePage {
    url = '/sites/devtestautomation';

    static get navigation() {
        const labels = HomePageConstants.navigationLabels.projects;
        return {
            projects: {
                requests: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.requests),
                portfolios: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.portfolios),
                projects: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.projects),
                tasks: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.tasks),
                risks: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.risks),
                issues: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.issues),
                changes: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.changes),
                documents: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.documents),
                resources: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.resources),
                reports: CommonPageHelper.getSidebarLinkByTextUnderNavigation(labels.reports)
            }
        };
    }

    static get toolBarMenuItems() {
        const options = CreateNewPageConstants.navigationLabels;
        return {
            change: CommonPageHelper.getToolBarItemsByText(options.listApps.change),
            discussion: CommonPageHelper.getToolBarItemsByText(options.listApps.discussion),
            event: CommonPageHelper.getToolBarItemsByText(options.listApps.event),
            issue: CommonPageHelper.getToolBarItemsByText(options.listApps.issue),
            link: CommonPageHelper.getToolBarItemsByText(options.listApps.link),
            project: CommonPageHelper.getToolBarItemsByText(options.listApps.project),
            portfolio: CommonPageHelper.getToolBarItemsByText(options.listApps.portfolio),
            projectRequest: CommonPageHelper.getToolBarItemsByText(options.listApps.projectRequest),
            more: this.moreButton,
            risk: CommonPageHelper.getToolBarItemsByText(options.listApps.risk),
            timeOff: CommonPageHelper.getToolBarItemsByText(options.listApps.timeOff),
            toDo: CommonPageHelper.getToolBarItemsByText(options.listApps.toDo),
            projectDocument: CommonPageHelper.getToolBarItemsByText(options.libraryApps.projectDocument),
            sharedDocument: CommonPageHelper.getToolBarItemsByText(options.libraryApps.sharedDocument)
        };
    }

    static get browseButton() {
        return element(By.css('.ms-fileinput'));
    }

    static get newButton() {
        return element(By.css('.js-listview-qcbNewButton'));
    }

    static get whatAreYouWorkingOnTextBox() {
        return element(By.css('#epm-se-status-update-box div.epm-se-comment-input'));
    }

    static get commentField() {
        return CommonPageHelper.getElementUsingText(HomePageConstants.comment, false);
    }

    static get moreButton() {
        return element(By.css('.epm-se-show-more'));
    }
}
