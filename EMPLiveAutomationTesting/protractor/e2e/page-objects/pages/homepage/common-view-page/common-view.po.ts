import {CommonViewPageConstants} from './common-view-page.constants';
import {CommonViewPageHelper} from './common-view-page.helper';
import {By, element} from 'protractor';

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

    static get columnNames() {
        return {
            assignedTo: 'Assigned To',
            comments: 'Comments',
            daysOverdue: 'Days Overdue',
            description: 'Description',
            due: 'Due',
            dueDate: 'Due Date',
            effort: 'Effort',
            priority: 'Priority',
            project: 'Project',
            relatedIssues: 'Related Issues',
            resolution: 'Resolution',
            scheduleStatus: 'Schedule Status',
            startDate: 'Start Date',
            status: 'Status',
            title: 'Title'
        };
    }

    static get searchControls() {
        return {
            text: element(By.id('searchtext2Main')),
            type: element(By.id('searchtype2Main')),
            column: element(By.id('search2Main'))
        };
    }
}
