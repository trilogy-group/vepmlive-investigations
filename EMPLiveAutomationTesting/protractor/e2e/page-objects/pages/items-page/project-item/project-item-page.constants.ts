import {CommonPageConstants} from '../../common/common-page.constants';

export class ProjectItemPageConstants {
    static readonly pagePrefix = 'Project Center';
    static readonly pageName = `${ProjectItemPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.newItem}`;
    static readonly editPageName = `${ProjectItemPageConstants.pagePrefix}${CommonPageConstants.pagePostFix.editItem}`;
    static readonly buildTeamPage = 'Build Team';
    static readonly teamMember = 'Team Member';
    static readonly languageAndRegion = 'Language and Region';
    static readonly associated = 'Associated';
    static readonly changeWindow = 'Changes - All Changes';
    static readonly issueWindow = 'Issues - All Issues by Status';
    static readonly nonAdminUser = 'Non Admin User';
    static readonly region  = 'Region';
    static readonly views  = 'Views';
    static readonly actualCost  = 'Actual Cost';
    static readonly saveView  = 'Save View';
    static readonly createColumn  = 'Create Column';
    static readonly actionsDropdown = 'Actions Dropdown';
    static readonly applyButton = 'Apply Button';
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
            ok: 'OK',
            projectUpdate: 'Project Update *',
        };
    }

    static get viewsItems() {
        return {
            showgantt: 'Show Gantt',
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
            currentTeam: 'Current Team',
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
            resourcePool: 'Resource Pool',
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

    static get buildTeamContentIDs() {
        return {
            resourcePool: 'tdRes',
            currentTeam: 'tdTeam'
        };
    }

    static get index() {
        return {
            one: 1,
            two: 2,
            three: 3
        };
    }

    static get buildTeamContentClass() {
        return {
            saveAndCloseDisabled: 'ms-cui-disabled'
        };
    }

    static get createColumnTabLabel() {
        return {
            createColumn: 'Create Column',
            nameAndType: 'Name and Type',
            additionalColumnSetting: 'Additional Column Settings',
            columnValidation: 'Column Validation',
        };
    }

    static get associatedItems() {
        return {
            lists: 'Lists',
            changes: 'Changes',
            issues: 'Issues',
            risks: 'Risks',
            documentLibraries: 'Document Libraries',
        };
    }

    static get messageText() {
        return {
            saveAndCloseDisabled: 'Save & Close Button is disabled',
            saveAndCloseEnabled: 'Save & Close Button is enabled'
        };
    }

    static get teamSectionlabels() {
        return {
            currentTeam: 'Current Team',
            resourcePool: 'Resource Pool'
        };
    }

    static get userInformation() {
        return {
            myLanguageAndRegion: 'My Language And Region',
            editItem: 'Edit Item',
            myAlerts: 'My Alerts'
        };
    }

    static get teamChangeButtons() {
        return {
            add: '< Add',
            remove: 'Remove >'
        };
    }

    static get reportParameter() {
        return {
            periodStart: 'Period Start',
            periodEnd: 'Period End',
            department: 'Department',
            resource: 'Resource',
            projectName: 'Project Name',
            resources: 'Resources',
            scope: 'Scope',
            from: 'From',
            to: 'To',
            units: 'Units'
        };
    }

    static get fragmentLabels() {
        return {
            fragment: 'Fragments ',
            insert: 'Insert Fragment',
            save: 'Save Fragment',
            manage: 'Manage Fragments',
        };
    }
    static get itemOptions() {
        return {
            resourceAnalyzer: 'Resource Analyzer',
            editCourse: 'Edit Course',
            publish: 'Publish Status'
        };
    }

    static get selectColumnLabel() {
        return {
            ok: 'OK',
            hideAll: 'Hide all',
            cancel: 'Cancel',
        };
    }

    static get addLinkPopup() {
        return {
            linkType: 'Link Type',
            addLink: 'Add Link',
            cancel: 'Cancel',
        };
    }

    static get planActionButtons() {
        return {
            save: 'Save Button',
            close: 'Close Button',
        };
    }

    static get toolButtons() {
        return {
            categories: 'Categories',
            detail: 'Detail',
            delete: 'Delete button',
            tools: 'Tools button',
            showReference: 'Show Reference'
        };
    }

    static get periodfields() {
        return {
            fromPeriod: 'From Period',
            toPeriod: 'To Period'
        };
    }

    static get reportHeaders() {
        return {
            refresh: 'Refresh',
            firstPage: 'First Page',
            previousPage: 'Previous Page',
            nextPage: 'Next Page',
            lastPage: 'Last Page',
            findTextInReport: 'Find Text in Report',
            findNext: 'Find Next'
        };
    }

    static get plannerLabels() {
        return {
            microsoftProject: 'Microsoft Project',
            projectPlanner: 'Project Planner'
        };
    }
    static get users() {
        return {
            adminUser: 'Admin User'
        };
    }

    static get newTaskFields() {
        return {
            assignedList: 'Assigned List',
            title: 'Title',
            finishDate: 'Finish Date',
            work: 'Work',
            duration: 'Duration',
            start: 'Start',
            date: 'DueDate',
            predecessors: 'Predecessors'
        };
    }

}
