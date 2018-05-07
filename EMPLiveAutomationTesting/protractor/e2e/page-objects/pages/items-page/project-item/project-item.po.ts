import {By, element} from 'protractor';
import {ProjectItemPageConstants} from './project-item-page.constants';
import {BasePage} from '../../base-page';
import {CommonPageHelper} from '../../common/common-page.helper';
import {ElementHelper} from '../../../../components/html/element-helper';

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

    static get portfolioShowAllButton() {
        return element(By.id('Portfolio_ddlShowAll'));
    }

    static get saveAndCloseButton() {
        return element(By.id('Ribbon.BuildTeam.StandardGroup.SaveCloseButton-Large'));
    }

    static async getUserCheckBoxForTeamType(teamType: string, userName: string) {
        const xpathForUser = `//td[@id="${teamType}"]//a[text()="${userName}"]//parent::td//parent::tr/td[contains(@class,"GMCellPanel")]`;
        return element(By.xpath(xpathForUser));
    }

    static get buildTeamContainers() {
        const buildTeamSection = ProjectItemPageConstants.buildTeamContentIDs;
        return {
            currentTeam: ElementHelper.getElementByStartsWithId(buildTeamSection.currentTeam, buildTeamSection.currentTeam),
            resourcePool: ElementHelper.getElementByStartsWithId(buildTeamSection.resourcePool, buildTeamSection.resourcePool),
        };
    }
}
