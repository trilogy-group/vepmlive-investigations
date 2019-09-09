import {By, element} from 'protractor';
import {BasePage} from '../base-page';
import {CommonPageHelper} from '../common/common-page.helper';
import {HomePageConstants} from './home-page.constants';
import {CreateNewPageConstants} from '../items-page/create-new-page.constants';
import {ElementHelper} from '../../../components/html/element-helper';

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
        const options = CreateNewPageConstants.navigationLabels.listApps;
        const optionsLibraryApps = CreateNewPageConstants.navigationLabels.libraryApps;
        return {
            change: CommonPageHelper.getToolBarItemsByText(options.change),
            discussion: CommonPageHelper.getToolBarItemsByText(options.discussion),
            event: CommonPageHelper.getToolBarItemsByText(options.event),
            issue: CommonPageHelper.getToolBarItemsByText(options.issue),
            link: CommonPageHelper.getToolBarItemsByText(options.link),
            project: CommonPageHelper.getToolBarItemsByText(options.project),
            portfolio: CommonPageHelper.getToolBarItemsByText(options.portfolio),
            projectRequest: CommonPageHelper.getToolBarItemsByText(options.projectRequest),
            socialStream: ElementHelper.getElementByText(optionsLibraryApps.socialStream),
            more: this.moreButton,
            risk: CommonPageHelper.getToolBarItemsByText(options.risk),
            timeOff: CommonPageHelper.getToolBarItemsByText(options.timeOff),
            toDo: CommonPageHelper.getToolBarItemsByText(options.toDo),
            projectDocument: CommonPageHelper.getToolBarItemsByText(optionsLibraryApps.projectDocument),
            sharedDocument: CommonPageHelper.getToolBarItemsByText(optionsLibraryApps.sharedDocument)
        };
    }

    static get navigateMenu() {
        // ql locator is alone on that page.
        return CommonPageHelper.getElementByTitle(HomePageConstants.navigation);
    }

    static get navigateToHome() {
        return element(By.css('.epm-nav-home a'));
    }

    static get chooseAfile() {
        return element(By.css('.ms-fileinput'));
    }

    static get navigationMenu() {
        return element(By.css('#epm-nav-sub'));
    }

    static get commentField() {
        return CommonPageHelper.getElementUsingText(HomePageConstants.comment, false);
    }

    static get moreButton() {
        return element.all(By.css('.epm-se-show-more')).first();
    }

    static get newButton() {
        return element(By.css('.js-listview-qcbNewButton'));
    }

    static get whatAreYouWorkingOnTextBox() {
        return element(By.css('#epm-se-status-update-box div.epm-se-comment-input'));
    }

    static get userMenu() {
        return {
            menu: element(By.css('a.ms-core-menu-root')),
            signOutLink: element(By.cssContainingText('a.ms-core-menu-link', 'Sign Out'))
        };
    }
}