import {CommonViewPageConstants} from './common-view-page.constants';
import {CommonViewPageHelper} from './common-view-page.helper';
import {By, element} from 'protractor';
import {LabelHelper} from '../../../../components/html/label-helper';

export class CommonViewPage {
    static get pageHeaders() {
        const labels = CommonViewPageConstants.pageHeaders.projects;
        return {
            projects: {
                requests: CommonViewPageHelper.getPageHeaderByTitle(labels.requests),
                portfolios: CommonViewPageHelper.getPageHeaderByTitle(labels.portfolios),
                projects: CommonViewPageHelper.getPageHeaderByTitle(labels.projects),
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

    static get selectColumnOptions() {
        const label = CommonViewPageConstants.columns;
        return {
            assignedTo: LabelHelper.getLabelByExactText(label.assignedTo),
            comments: LabelHelper.getLabelByExactText(label.comments),
            createdBy: LabelHelper.getLabelByExactText(label.createdBy),
            daysOverdue: LabelHelper.getLabelByExactText(label.daysOverdue),
            description: LabelHelper.getLabelByExactText(label.description),
            dueDate: LabelHelper.getLabelByExactText(label.dueDate),
            due: LabelHelper.getLabelByExactText(label.due),
            effort: LabelHelper.getLabelByExactText(label.effort),
            id: LabelHelper.getLabelByExactText(label.id),
            modifiedBy: LabelHelper.getLabelByExactText(label.modifiedBy),
            priority: LabelHelper.getLabelByExactText(label.priority),
            project: LabelHelper.getLabelByExactText(label.project),
            relatedIssues: LabelHelper.getLabelByExactText(label.relatedIssues),
            resolution: LabelHelper.getLabelByExactText(label.resolution),
            scheduleStatus: LabelHelper.getLabelByExactText(label.scheduleStatus),
            startDate: LabelHelper.getLabelByExactText(label.startDate),
            status: LabelHelper.getLabelByExactText(label.status),
            title: LabelHelper.getLabelByExactText(label.title),
            specialColumns: LabelHelper.getLabelByExactText(label.specialColumns),
            ganttChart: LabelHelper.getLabelByExactText(label.ganttChart)
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
        return element(By.xpath(`${this.selectorForRecords}[1]`));
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
            assignedTo: CommonViewPageHelper.getPageHeaderByTitle(label.assignedTo),
            comments: CommonViewPageHelper.getPageHeaderByTitle(label.comments),
            createdBy: CommonViewPageHelper.getPageHeaderByTitle(label.createdBy),
            daysOverdue: CommonViewPageHelper.getPageHeaderByTitle(label.daysOverdue),
            description: CommonViewPageHelper.getPageHeaderByTitle(label.description),
            dueDate: CommonViewPageHelper.getPageHeaderByTitle(label.dueDate),
            due: CommonViewPageHelper.getPageHeaderByTitle(label.due),
            effort: CommonViewPageHelper.getPageHeaderByTitle(label.effort),
            id: CommonViewPageHelper.getPageHeaderByTitle(label.id),
            modifiedBy: CommonViewPageHelper.getPageHeaderByTitle(label.modifiedBy),
            priority: CommonViewPageHelper.getPageHeaderByTitle(label.priority),
            project: CommonViewPageHelper.getPageHeaderByTitle(label.project),
            relatedIssues: CommonViewPageHelper.getPageHeaderByTitle(label.relatedIssues),
            resolution: CommonViewPageHelper.getPageHeaderByTitle(label.resolution),
            scheduleStatus: CommonViewPageHelper.getPageHeaderByTitle(label.scheduleStatus),
            startDate: CommonViewPageHelper.getPageHeaderByTitle(label.startDate),
            status: CommonViewPageHelper.getPageHeaderByTitle(label.status),
            title: CommonViewPageHelper.getPageHeaderByTitle(label.title),
            specialColumns: CommonViewPageHelper.getPageHeaderByTitle(label.specialColumns),
            ganttChart: CommonViewPageHelper.getPageHeaderByTitle(label.ganttChart)
        };
    }
}
