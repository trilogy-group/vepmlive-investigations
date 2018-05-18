import {By, element, browser} from 'protractor';
import {ProjectItemPageConstants} from './project-item-page.constants';
import {BasePage} from '../../base-page';
import {CommonPageHelper} from '../../common/common-page.helper';
import {ElementHelper} from '../../../../components/html/element-helper';
import { ProjectItemPageHelper } from './project-item-page.helper';
import { CommonPageConstants } from '../../common/common-page.constants';

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

    static get saveAndClose() {
        return element(By.id('Ribbon.BuildTeam.StandardGroup.SaveCloseButton-Large'));
    }

    static async getUserCheckBoxForTeamType(teamType: string, userName: string) {
        const xpathForUser = `//td[normalize-space(@id)="${teamType}"]//a[normalize-space(text())="${userName}"]
        //parent::td//parent::tr/td[contains(@class,"GMCellPanel")]`;
        return element(By.xpath(xpathForUser));
    }

    static get buildTeamContainers() {
        const buildTeamSection = ProjectItemPageConstants.buildTeamContentIDs;
        return {
            currentTeam: ElementHelper.getElementByStartsWithId(buildTeamSection.currentTeam, buildTeamSection.currentTeam),
            resourcePool: ElementHelper.getElementByStartsWithId(buildTeamSection.resourcePool, buildTeamSection.resourcePool),
        };
    }

    static get teamRecords() {
        return {
            currentTeam: CommonPageHelper.getTeamRecordsByTeamId(CommonPageConstants.teamId.currentTeam),
            resourcePool: CommonPageHelper.getTeamRecordsByTeamId(CommonPageConstants.teamId.resourcePool)
        };
    }

    static get teamRecordsName() {
        return {
            currentTeam: CommonPageHelper.getTeamRecordsNameByTeamId(CommonPageConstants.teamId.currentTeam),
            resourcePool: CommonPageHelper.getTeamRecordsNameByTeamId(CommonPageConstants.teamId.resourcePool)
        };
    }

    static get teamChangeButtons() {
        const label = ProjectItemPageConstants.teamChangeButtons;
        return {
            add: ProjectItemPageHelper.getTeamChangeButtonByValue(label.add),
            remove: ProjectItemPageHelper.getTeamChangeButtonByValue(label.remove)
        };
    }

    static get assignmentPlannerFrame () {
        return browser.driver.findElement(By.xpath('//iframe[contains(@id,"DlgFrame")][contains(@src,"AssignmentPlanner")]'));
    }

    static get reportParameters() {
        const label = ProjectItemPageConstants.reportParameter;
        return {
            periodStart: ProjectItemPageHelper.getReportParametersByTitle(label.periodStart),
            periodEnd: ProjectItemPageHelper.getReportParametersByTitle(label.periodEnd),
            department: ProjectItemPageHelper.getReportParametersByTitle(label.department),
            resource: ProjectItemPageHelper.getReportParametersByTitle(label.resource),
            projectName: ProjectItemPageHelper.getReportParametersByTitle(label.projectName),
            resources: ProjectItemPageHelper.getReportParametersByTitle(label.resources),
            scope: ProjectItemPageHelper.getReportParametersByTitle(label.scope),
            from: ProjectItemPageHelper.getReportParametersByTitle(label.from),
            to: ProjectItemPageHelper.getReportParametersByTitle(label.to),
            units: ProjectItemPageHelper.getReportParametersByTitle(label.units)
        };
    }

    static get reportHeaders() {
        const label = ProjectItemPageConstants.reportHeaders;
        return {
            refresh: ProjectItemPageHelper.getReportPagingHeaderByTitle(label.refresh),
            firstPage: ProjectItemPageHelper.getReportPagingHeaderByTitle(label.firstPage),
            previousPage: ProjectItemPageHelper.getReportPagingHeaderByTitle(label.previousPage),
            nextPage: ProjectItemPageHelper.getReportPagingHeaderByTitle(label.nextPage),
            lastPage: ProjectItemPageHelper.getReportPagingHeaderByTitle(label.lastPage),
            findTextInReport: ProjectItemPageHelper.getReportTextFunctionHeaderByTitle(label.findTextInReport),
            findNext: ProjectItemPageHelper.getReportTextFunctionHeaderByTitle(label.findNext)
        };
    }

    static get actionsdropdown() {
        return element(By.xpath(`//a[contains(@id,"RSActionMenu_ctl01")][@title="Open Menu"]`));
    }

    static get applyParameterButton() {
        return element(By.xpath(`//input[contains(@name,"ApplyParameters")][@value="Apply"]`));
    }

}
