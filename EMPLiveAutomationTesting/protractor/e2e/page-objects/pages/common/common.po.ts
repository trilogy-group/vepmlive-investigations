import {BasePage} from '../base-page';
import {By, element} from 'protractor';
import {CommonPageConstants} from '../common-page/common-page.constants';
import {CommonPageHelper} from '../common-page/common-page.helper';
import {ElementHelper} from '../../../components/html/element-helper';

export class CommonPage extends BasePage {

    static get sidebarMenus() {
        const idPrefix = 'epm-nav-top-';
        return {
            navigation: element(By.id(`${idPrefix}ql`)),
            createNew: element(By.id(`${idPrefix}new`)),
            myWorkplace: element(By.id(`${idPrefix}workplace`)),
            favorites: element(By.id(`${idPrefix}favorites`)),
            mostRecent: element(By.id(`${idPrefix}recent`)),
            workspaces: element(By.id(`${idPrefix}workspaces`))
        };
    }

    static get addNewLink() {
        return element(By.css('[title="New Item"] a'));
    }

    static get contentTitleInViewMode() {
        return element(By.css('span.dispFormFancyTitle'));
    }

    static get pageHeaders() {
        const projectsLabels = CommonPageConstants.pageHeaders.projects;
        const myWorkplaceLabels = CommonPageConstants.pageHeaders.myWorkplace;
        return {
            projects: {
                requests: CommonPageHelper.getPageHeaderByTitle(projectsLabels.requests),
                portfolios: CommonPageHelper.getPageHeaderByTitle(projectsLabels.portfolios),
                projectPortfolios: CommonPageHelper.getPageHeaderByTitle(projectsLabels.projectPortfolios),
                projectsCenter: CommonPageHelper.getPageHeaderByTitle(projectsLabels.projectCenter),
                tasks: CommonPageHelper.getPageHeaderByTitle(projectsLabels.tasks),
                risks: CommonPageHelper.getPageHeaderByTitle(projectsLabels.risks),
                issues: CommonPageHelper.getPageHeaderByTitle(projectsLabels.issues),
                changes: CommonPageHelper.getPageHeaderByTitle(projectsLabels.changes),
                documents: CommonPageHelper.getPageHeaderByTitle(projectsLabels.documents),
                resources: CommonPageHelper.getPageHeaderByTitle(projectsLabels.resources),
                reports: CommonPageHelper.getPageHeaderByTitle(projectsLabels.reports)
            },
            myWorkplace: {
                myWork: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.myWork),
                myTimeSheet: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.myTimeSheet),
                myTimeOff: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.myTimeOff),
                toDo: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.toDo),
                discussions: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.discussions),
                events: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.events),
                wikis: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.wikis),
                sharedDocuments: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.sharedDocuments),
                pictures: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.pictures),
                links: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.links)
            }
        };
    }

    static get actionMenuIcons() {
        const titles = CommonPageConstants.actionMenuIconTitles;
        return {
            search: CommonPageHelper.getActionMenuIcons(titles.search),
            toggleFilters: CommonPageHelper.getActionMenuIcons(titles.toggleFilters),
            defaultSort: CommonPageHelper.getActionMenuIcons(titles.defaultSort),
            groupBy: CommonPageHelper.getActionMenuIcons(titles.groupBy),
            selectColumns: CommonPageHelper.getActionMenuIcons(titles.selectColumns),
            view: CommonPageHelper.getActionMenuIcons(titles.view),
            settings: CommonPageHelper.getActionMenuIcons(titles.settings)
        };
    }

    static get applySelectColumnButton() {
        return element(By.xpath(`//div[contains(@class,'grouping-apply')]//a[normalize-space(.)='Apply']`));
    }

    static get ganttGrid() {
        return ElementHelper.getElementByStartsWithId('GanttGrid');
    }

    static get searchControls() {
        return {
            text: element(By.css('#searchtext0Main,#searchtext2Main')),
            type: element(By.css('#searchtype0Main,#searchtype2Main')),
            column: element(By.css('#search0Main,#search2Main'))
        };
    }

    static get record() {
        return element(By.xpath(`(${this.selectorForRecords})[1]`));
    }

    static get records() {
        return element.all(By.xpath(this.selectorForRecords));
    }

    static get selectorForRecords() {
        return '//*[contains(@class,"GMDataRow")]//img[contains(@src,"green")]';
    }

    static get selectColumnPanel() {
        return element(By.xpath('//*[contains(@id,"msColumns") and contains(@id,"_ul_menu")'));
    }

    static get ellipse() {
        return element(By.css('td .icon-ellipsis-horizontal'));
    }

    static get contextMenuOptions() {
        const options = CommonPageConstants.contextMenuOptions;
        return {
            viewItem: CommonPageHelper.getContextMenuItemByText(options.viewItem),
            editItem: CommonPageHelper.getContextMenuItemByText(options.editItem),
            workFlows: CommonPageHelper.getContextMenuItemByText(options.workFlows),
            permissions: CommonPageHelper.getContextMenuItemByText(options.permissions),
            deleteItem: CommonPageHelper.getContextMenuItemByText(options.deleteItem),
            comments: CommonPageHelper.getContextMenuItemByText(options.comments)
        };
    }
}
