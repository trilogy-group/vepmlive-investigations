import {CommonPageConstants} from '../../common/common-page.constants';

export class ProjectItemPageConstants {
    static readonly pagePrefix = 'Project Center';
    static readonly pageName = `${ProjectItemPageConstants.pagePrefix} ${CommonPageConstants.pagePostFix.newItem}`;
    static readonly editPageName = `${ProjectItemPageConstants.pagePrefix} ${CommonPageConstants.pagePostFix.editItem}`;
    static readonly editTeamPageName = 'Edit Team';
    static readonly editTeamCloseBtn = 'Close Button';

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
            percentComplete: '% Complete',
            percentOverdueTasks: '% of Overdue',
            percentOverBudget: '% Over Budget',
            activeIssues: 'Active Issues',
            activeTasks: 'Active Tasks',
            actualCost: 'Actual Cost',
            actualFinish: 'Actual Finish',
            actualStart: 'Actual Start',
            actualWork: 'Actual Work',
            assignedTo: 'Assigned To',
            baselineCost: 'Baseline Cost',
            baselineFinish: 'Baseline Finish',
            baselineStart: 'Baseline Start',
            baselineWork: 'Baseline Work',
            benefits: 'Benefits',
            budget: 'Budget',
            budgetStatus: 'Budget Status',
            businessInitiative: 'Business Initiative',
            cost: 'Cost',
            costReduction: 'Cost Reduction',
            costReductionWeight: 'Cost Reduction Rating',
            decision: 'Decision',
            defaultPlanner: 'Default Planner',
            duration: 'Duration',
            impEmployeeSatisfactionWeight: 'Employee Rating',
            improveEmployeeSatisfaction: 'Employee Satisfaction',
            executiveSponsor: 'Executive Sponsor',
            finish: 'Finish',
            parentItem: 'Hidden',
            issueStatus: 'Issue Status',
            lifecycleStage: 'Lifecycle Stage',
            overallHealth: 'Overall Health',
            overallStatus: 'Overall Status',
            overdueIssues: 'Overdue Issues',
            overdueTasks: 'Overdue Tasks',
            owner: 'Owner',
            plannedBenefit: 'Planned Benefit',
            planners: 'Planners',
            portfolio: 'Portfolio',
            prioritizationScore: 'Prioritization Score',
            priority: 'Priority',
            projectPercentComplete: 'Project % Complete',
            projectActualCost: 'Project Actual Cost',
            projectActualFinish: 'Project Actual Finish',
            projectActualStart: 'Project Actual Start',
            projectActualWork: 'Project Actual Work',
            notes: 'Project Description',
            projectFinish: 'Project Finish',
            projectManagers: 'Project Manager',
            title: 'Project Name',
            projectPlannerBD: 'Project Planner Baseline Date',
            projectRemainingCost: 'Project Remaining Cost',
            projectRemainingWork: 'Project Remaining Work',
            projectStart: 'Project Start',
            projectType: 'Project Type',
            projectUpdate: 'Project Update',
            projectWork: 'Project Work',
            remainingCost: 'Remaining Cost',
            remainingHours: 'Remaining Hours',
            remainingWork: 'Remaining Work',
            resourcePlanCost: 'Resource Plan Cost',
            resourcePlanHours: 'Resource Plan Hours',
            risk: 'Risk',
            riskWeight: 'Risk Rating',
            roi: 'ROI',
            scheduleStatus: 'Schedule Status',
            site: 'Site',
            stageGateOwner: 'Stage Gate Owner',
            start: 'Start',
            state: 'State',
            stateIcon: 'State Indicator',
            status: 'Status',
            strategicAlignment: 'Strategic Alignment',
            strategicAlignmentWeight: 'Strategic Alignment Rating',
            timesheetActualCost: 'Timesheet Actual Cost',
            timesheetHours: 'Timesheet Hours',
            work: 'Work',
            workPercentSpent: 'Work % Spent',
            workHealth: 'Work Health',
            workStatus: 'Work Status',
            workspaceDriven: 'Workspace Driven'
        };
    }

    static get teamSectionlabels() {
        return {
            currentTeam: 'Current Team',
            resourcePool: 'Resource Pool'
        };
    }

}
