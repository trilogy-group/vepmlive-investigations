import {BasePage} from '../base-page';
import {CommonPageHelper} from '../common/common-page.helper';
import {HomePageConstants} from './home-page.constants';

export class HomePage extends BasePage {
    url = '/sites/devtestautomation';

    static get navigation() {
        const labels = HomePageConstants.navigationLabels.projects;
        return {
            projects: {
                requests: CommonPageHelper.getSidebarLinkByTextUnderTableData(labels.requests),
                portfolios: CommonPageHelper.getSidebarLinkByTextUnderTableData(labels.portfolios),
                projects: CommonPageHelper.getSidebarLinkByTextUnderTableData(labels.projects),
                tasks: CommonPageHelper.getSidebarLinkByTextUnderTableData(labels.tasks),
                risks: CommonPageHelper.getSidebarLinkByTextUnderTableData(labels.risks),
                issues: CommonPageHelper.getSidebarLinkByTextUnderTableData(labels.issues),
                changes: CommonPageHelper.getSidebarLinkByTextUnderTableData(labels.changes),
                documents: CommonPageHelper.getSidebarLinkByTextUnderTableData(labels.documents),
                resources: CommonPageHelper.getSidebarLinkByTextUnderTableData(labels.resources),
                reports: CommonPageHelper.getSidebarLinkByTextUnderTableData(labels.reports)
            }
        };
    }
}
