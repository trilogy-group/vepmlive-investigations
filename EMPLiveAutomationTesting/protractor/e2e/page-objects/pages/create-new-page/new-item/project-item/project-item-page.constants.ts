import {CommonPageConstants} from '../../../common/common-page.constants';

export class ProjectItemPageConstants {
    static readonly pagePrefix = 'Project Center';
    static readonly pageName = `${ProjectItemPageConstants.pagePrefix} ${CommonPageConstants.pagePostFix.newItem}`;
    static readonly editPageName = `${ProjectItemPageConstants.pagePrefix} ${CommonPageConstants.pagePostFix.editItem}`;

    static get inputLabels() {
        return {
            projectName: 'Project Name *',
            portfolio: 'Portfolio',
            projectDescription: 'Project Description',
            benefits: 'Benefits',
            state: 'State *',
            lifecycleStage: 'Lifecycle Stage',
            projectType: 'Project Type',
            stageGateOwner: 'Stage Gate Owner',
            executiveSponsor: 'Executive Sponsor',
            projectStart: 'Project Start',
            projectFinish: 'Project Finish',
            overallHealth: 'Overall Health *',
            projectWork: 'Project Work',
            budget: 'Budget',
            plannedBenefit: 'Planned Benefit',
            businessInitiative: 'Business Initiative',
            strategicAlignment: 'Strategic Alignment',
            costReduction: 'Cost Reduction',
            employeeSatisfaction: 'Employee Satisfaction',
            risk: 'Risk',
            projectUpdate: 'Project Update *'
        };
    }

    static get columnNames() {
        return {
            percentOverdueTasks: '% of Overdue',
            percentOverBudget: '% Over Budget',
            activeIssues: 'Active Issues',
            activeTasks: 'Active Tasks',
            benefits: 'Benefits',
            budget: 'Budget',
            budgetStatus: 'Budget Status',
            businessInitiative: 'Business Initiative',
            costReduction: 'Cost Reduction',
            decision: 'Decision',
            improveEmployeeSatisfaction: 'Employee Satisfaction',
            executiveSponsor: 'Executive Sponsor',
            issueStatus: 'Issue Status',
            lifecycleStage: 'Lifecycle Stage',
            overallStatus: 'Overall Status',
            overdueIssues: 'Overdue Issues',
            overdueTasks: 'Overdue Tasks',
            plannedBenefit: 'Planned Benefit',
            portfolio: 'Portfolio',
            prioritizationScore: 'Prioritization Score',
            projectPercentComplete: 'Project % Complete',
            projectActualCost: 'Project Actual Cost',
            projectActualFinish: 'Project Actual Finish',
            projectActualStart: 'Project Actual Start',
            projectActualWork: 'Project Actual Work',
            notes: 'Project Description',
            projectFinish: 'Project Finish',
            projectManagers: 'Project Manager',
            title: 'Project Name',
            projectRemainingCost: 'Project Remaining Cost',
            projectRemainingWork: 'Project Remaining Work',
            projectStart: 'Project Start',
            projectType: 'Project Type',
            projectUpdate: 'Project Update',
            projectWork: 'Project Work',
            remainingHours: 'Remaining Hours',
            resourcePlanCost: 'Resource Plan Cost',
            resourcePlanHours: 'Resource Plan Hours',
            risk: 'Risk',
            roi: 'ROI',
            scheduleStatus: 'Schedule Status',
            stageGateOwner: 'Stage Gate Owner',
            state: 'State',
            strategicAlignment: 'Strategic Alignment',
            timeSheetActualCost: 'Timesheet Actual Cost',
            timeSheetHours: 'Timesheet Hours',
            workPercentSpent: 'Work % Spent',
            workStatus: 'Work Status',
            workspaceDriven: 'Workspace Driven',
        };
    }
    static get states() {
        return {
            proposed: '(1) Proposed',
            active: '(2) Active',
            closed: '(3) Closed',
        };
    }

    static get projectUpdate() {
        return {
            manual: 'Manual',
            scheduleDriven: 'Schedule Driven'
        };
    }

    static get overallHealth() {
        return {
            onTrack: '(1) On Track',
            atRisk: '(2) At Risk',
            offTrack: '(3) Off Track',
        };
    }
}
