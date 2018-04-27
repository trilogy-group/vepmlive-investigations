import {CommonViewPageConstants} from './common-view-page.constants';
import {CommonViewPageHelper} from './common-view-page.helper';
import {By, element} from 'protractor';
import {CommonPageHelper} from '../../common/common-page.helper';

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
        return element(By.id('GanttGrid2Main'));
    }

    static get selectColumnOptions() {
        const label = CommonViewPageConstants.columns;
        return {
            assignedTo: CommonPageHelper.getCheckboxByExactText(label.assignedTo),
            comments: CommonPageHelper.getCheckboxByExactText(label.comments),
            createdBy: CommonPageHelper.getCheckboxByExactText(label.createdBy),
            daysOverdue: CommonPageHelper.getCheckboxByExactText(label.daysOverdue),
            description: CommonPageHelper.getCheckboxByExactText(label.description),
            dueDate: CommonPageHelper.getCheckboxByExactText(label.dueDate),
            due: CommonPageHelper.getCheckboxByExactText(label.due),
            effort: CommonPageHelper.getCheckboxByExactText(label.effort),
            id: CommonPageHelper.getCheckboxByExactText(label.id),
            modifiedBy: CommonPageHelper.getCheckboxByExactText(label.modifiedBy),
            priority: CommonPageHelper.getCheckboxByExactText(label.priority),
            project: CommonPageHelper.getCheckboxByExactText(label.project),
            relatedIssues: CommonPageHelper.getCheckboxByExactText(label.relatedIssues),
            resolution: CommonPageHelper.getCheckboxByExactText(label.resolution),
            scheduleStatus: CommonPageHelper.getCheckboxByExactText(label.scheduleStatus),
            startDate: CommonPageHelper.getCheckboxByExactText(label.startDate),
            status: CommonPageHelper.getCheckboxByExactText(label.status),
            title: CommonPageHelper.getCheckboxByExactText(label.title),
            specialColumns: CommonPageHelper.getCheckboxByExactText(label.specialColumns),
            ganttChart: CommonPageHelper.getCheckboxByExactText(label.ganttChart)
        };
    }

    static get searchControls() {
        return {
            text: element(By.id('searchtext2Main')),
            type: element(By.id('searchtype2Main')),
            column: element(By.id('search2Main'))
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
        return element(By.id('msColumns2Main_ul_menu'));
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

    static get columns() {
        const label = CommonViewPageConstants.columns;
        return {
            assignedTo: CommonViewPageHelper.getColumnHeaderByText(label.assignedTo),
            comments: CommonViewPageHelper.getColumnHeaderByText(label.comments),
            createdBy: CommonViewPageHelper.getColumnHeaderByText(label.createdBy),
            daysOverdue: CommonViewPageHelper.getColumnHeaderByText(label.daysOverdue),
            description: CommonViewPageHelper.getColumnHeaderByText(label.description),
            dueDate: CommonViewPageHelper.getColumnHeaderByText(label.dueDate),
            due: CommonViewPageHelper.getColumnHeaderByText(label.due),
            effort: CommonViewPageHelper.getColumnHeaderByText(label.effort),
            id: CommonViewPageHelper.getColumnHeaderByText(label.id),
            modifiedBy: CommonViewPageHelper.getColumnHeaderByText(label.modifiedBy),
            priority: CommonViewPageHelper.getColumnHeaderByText(label.priority),
            project: CommonViewPageHelper.getColumnHeaderByText(label.project),
            relatedIssues: CommonViewPageHelper.getColumnHeaderByText(label.relatedIssues),
            resolution: CommonViewPageHelper.getColumnHeaderByText(label.resolution),
            scheduleStatus: CommonViewPageHelper.getColumnHeaderByText(label.scheduleStatus),
            startDate: CommonViewPageHelper.getColumnHeaderByText(label.startDate),
            status: CommonViewPageHelper.getColumnHeaderByText(label.status),
            title: CommonViewPageHelper.getColumnHeaderByText(label.title),
            specialColumns: CommonViewPageHelper.getColumnHeaderByText(label.specialColumns),
            ganttChart: CommonViewPageHelper.getColumnHeaderByText(label.ganttChart)
        };
    }
}
