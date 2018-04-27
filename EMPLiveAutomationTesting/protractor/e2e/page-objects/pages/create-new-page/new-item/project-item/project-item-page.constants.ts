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
