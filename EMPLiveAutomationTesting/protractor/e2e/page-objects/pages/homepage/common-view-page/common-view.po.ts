import {CommonViewPageConstants} from './common-view-page.constants';
import {CommonViewPageHelper} from './common-view-page.helper';
import {By, element} from 'protractor';
import {ElementHelper} from '../../../../components/html/element-helper';

export class CommonViewPage {
    static get pageHeaders() {
        const labels = CommonViewPageConstants.pageHeaders.projects;
        return {
            projects: {
                requests: CommonViewPageHelper.getPageHeaderByTitle(labels.requests),
                portfolios: CommonViewPageHelper.getPageHeaderByTitle(labels.portfolios),
                projectsCenter: CommonViewPageHelper.getPageHeaderByTitle(labels.projectCenter),
                tasks: CommonViewPageHelper.getPageHeaderByTitle(labels.tasks),
                risks: CommonViewPageHelper.getPageHeaderByTitle(labels.risks),
                issues: CommonViewPageHelper.getPageHeaderByTitle(labels.issues),
                changes: CommonViewPageHelper.getPageHeaderByTitle(labels.changes),
                documents: CommonViewPageHelper.getPageHeaderByTitle(labels.documents),
                resources: CommonViewPageHelper.getPageHeaderByTitle(labels.resources),
                reports: CommonViewPageHelper.getPageHeaderByTitle(labels.reports)
            }
        };
    }

    static get actionMenuIcons() {
        const titles = CommonViewPageConstants.actionMenuIconTitles;
        return {
            search: CommonViewPageHelper.getActionMenuIcons(titles.search),
            toggleFilters: CommonViewPageHelper.getActionMenuIcons(titles.toggleFilters),
            defaultSort: CommonViewPageHelper.getActionMenuIcons(titles.defaultSort),
            groupBy: CommonViewPageHelper.getActionMenuIcons(titles.groupBy),
            selectColumns: CommonViewPageHelper.getActionMenuIcons(titles.selectColumns),
            view: CommonViewPageHelper.getActionMenuIcons(titles.view),
            settings: CommonViewPageHelper.getActionMenuIcons(titles.settings)
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
            text: ElementHelper.getElementByStartsWithId('searchtext'),
            type: ElementHelper.getElementByStartsWithId('searchtype'),
            column: ElementHelper.getElementByStartsWithId('search')
        };
    }

    static get record() {
        console.log(`(${this.selectorForRecords})[1]`);
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
        const options = CommonViewPageConstants.contextMenuOptions;
        return {
            viewItem: CommonViewPageHelper.getContextMenuItemByText(options.viewItem),
            editItem: CommonViewPageHelper.getContextMenuItemByText(options.editItem),
            workFlows: CommonViewPageHelper.getContextMenuItemByText(options.workFlows),
            permissions: CommonViewPageHelper.getContextMenuItemByText(options.permissions),
            deleteItem: CommonViewPageHelper.getContextMenuItemByText(options.deleteItem),
            comments: CommonViewPageHelper.getContextMenuItemByText(options.comments)
        };
    }

}
