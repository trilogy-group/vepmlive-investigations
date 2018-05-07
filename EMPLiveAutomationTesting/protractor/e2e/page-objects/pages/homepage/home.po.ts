import {BasePage} from '../base-page';
import {CommonPageHelper} from '../common/common-page.helper';
import {HomePageConstants} from './home-page.constants';
import {By, element} from 'protractor';

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
        const options = HomePageConstants.toolBarMenuOptions;
        return {
            change: CommonPageHelper.getToolBarItemsByText(options.change),
            discussion: CommonPageHelper.getToolBarItemsByText(options.discussion),
            event: CommonPageHelper.getToolBarItemsByText(options.event),
            issue: CommonPageHelper.getToolBarItemsByText(options.issue),
            link: CommonPageHelper.getToolBarItemsByText(options.link),
            project: CommonPageHelper.getToolBarItemsByText(options.project),
            more: CommonPageHelper.getToolBarItemsByText(options.more)
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
}
