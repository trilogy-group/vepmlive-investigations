import {CommonPageConstants} from '../../common/common-page.constants';

export class PortfolioItemPageConstants {
    static readonly pagePrefix = 'Project Portfolios';
    static readonly pageName = `${PortfolioItemPageConstants.pagePrefix} ${CommonPageConstants.pagePostFix.newItem}`;
    static readonly editPageName = `${PortfolioItemPageConstants.pagePrefix} ${CommonPageConstants.pagePostFix.editItem}`;

    static get inputLabels() {
        return {
            portfolioName: 'Portfolio Name *',
            portfolioDescription: 'Portfolio Description',
            portfolioType: 'Portfolio Type',
            portfolioGoals: 'Portfolio Goals',
            state: 'State *',
            budget: 'Budget',
            plannedBenefit: 'Planned Benefit'
        };
    }

    static get columnNames() {
        return {
            numberOfActiveProjects: '# Of Active Projects',
            actualWork: 'Actual Work',
            averagePrioritization: 'Average Prioritization',
            budget: 'Budget',
            budgetStatus: 'Budget Status',
            overallHealth: 'Overall Health',
            overdueIssues: 'Overdue Issues',
            plannedBenefit: 'Planned Benefit',
            notes: 'Portfolio Description',
            portfolioGoals: 'Portfolio Goals',
            title: 'Portfolio Name',
            portfolioType: 'Portfolio Type',
            projectActualCost: 'Project Actual Cost',
            projectBenefits: 'Project Benefits',
            projectBudget: 'Project Budget',
            projectRemainingCost: 'Project Remaining Cost',
            projectROI: 'Project ROI',
            remainingBudget: 'Remaining Budget',
            rOI: 'ROI',
            scheduleStatus: 'Schedule Status',
            stateIcon: 'State Indicator',
            work: 'Work',
            workStatus: 'Work Status',
            workspaceUrl: 'WorkspaceUrl',
        };
    }

    static get portfolioTypes() {
        return {
            other: 'Other',
            customer: 'Customer',
            development: 'Development',
            enhancement: 'Enhancement',
            support: 'Support',
            program: 'Program',
            marketing: 'Marketing'
        };
    }

    static get portfolioGoals() {
        return {
            customerSatisfaction: 'Customer Satisfaction',
            growBusiness: 'Grow Business',
            runBusiness: 'Run Business',
            transformation: 'Transformation'
        };
    }

    static get states() {
        return {
            proposed: '(1) Proposed',
            active: '(2) Active',
            closed: '(3) Closed',
        };
    }
}
