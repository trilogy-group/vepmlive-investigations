import {By, element} from 'protractor';
import {ProjectItemPageConstants} from './project-item-page.constants';
import {BasePage} from '../../base-page';
import {CommonPageHelper} from '../../common/common-page.helper';
import { ProjectItemPageHelper } from './project-item-page.helper';

export class ProjectItemPage extends BasePage {
    static get inputs() {
        const labels = ProjectItemPageConstants.inputLabels;
        return {
            projectName: CommonPageHelper.getTextBoxByLabel(labels.projectName),
            portfolio: CommonPageHelper.getFirstAutoCompleteByLabel(labels.portfolio),
            projectDescription: CommonPageHelper.getTextAreaByLabel(labels.projectDescription),
            benefits: CommonPageHelper.getTextAreaByLabel(labels.benefits),
            state: CommonPageHelper.getSelectByLabel(labels.state),
            lifecycleStage: CommonPageHelper.getSelectByLabel(labels.lifecycleStage),
            projectType: CommonPageHelper.getSelectByLabel(labels.projectType),
            stageGateOwner: CommonPageHelper.getTextBoxByLabel(labels.stageGateOwner),
            executiveSponsor: CommonPageHelper.getTextBoxByLabel(labels.executiveSponsor),
            projectStart: CommonPageHelper.getTextBoxByLabel(labels.projectStart),
            projectFinish: CommonPageHelper.getTextBoxByLabel(labels.projectFinish),
            overallHealth: CommonPageHelper.getSelectByLabel(labels.overallHealth),
            projectWork: CommonPageHelper.getTextBoxByLabel(labels.projectWork),
            budget: CommonPageHelper.getTextBoxByLabel(labels.budget),
            plannedBenefit: CommonPageHelper.getTextBoxByLabel(labels.plannedBenefit),
            businessInitiative: CommonPageHelper.getSelectByLabel(labels.businessInitiative),
            strategicAlignment: CommonPageHelper.getSelectByLabel(labels.strategicAlignment),
            costReduction: CommonPageHelper.getSelectByLabel(labels.costReduction),
            employeeSatisfaction: CommonPageHelper.getSelectByLabel(labels.employeeSatisfaction),
            risk: CommonPageHelper.getSelectByLabel(labels.risk),
            projectUpdate: CommonPageHelper.getSelectByLabel(labels.projectUpdate)
        };
    }

    static get teamSection() {
        const labels = ProjectItemPageConstants.teamSectionlabels;
        return {
            currentTeam: ProjectItemPageHelper.getTeamSectionsByText(labels.currentTeam),
            resourcePool: ProjectItemPageHelper.getTeamSectionsByText(labels.resourcePool)
        };
    }

    static get portfolioShowAllButton() {
        return element(By.id('Portfolio_ddlShowAll'));
    }

    static get teamRecords() {
        return {
            currentTeam: ProjectItemPageHelper.getTeamRecordsByTeamId('TeamGrid'),
            resourcePool: ProjectItemPageHelper.getTeamRecordsByTeamId('ResourceGrid')
        };
    }

    static get teamRecordsName() {
        return {
            currentTeam: ProjectItemPageHelper.getTeamRecordsNameByTeamId('TeamGrid'),
            resourcePool: ProjectItemPageHelper.getTeamRecordsNameByTeamId('ResourceGrid')
        };
    }

    static get teamChangeButtons() {
        const label = ProjectItemPageConstants.teamChangeButtons;
        return {
            add: ProjectItemPageHelper.getTeamChangeButtonByValue(label.add),
            remove: ProjectItemPageHelper.getTeamChangeButtonByValue(label.remove)
        };
    }

}
