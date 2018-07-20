import {browser, By, element} from 'protractor';
import {ProjectItemPageConstants} from './project-item-page.constants';
import {BasePage} from '../../base-page';
import {CommonPageHelper} from '../../common/common-page.helper';
import {ProjectItemPageHelper} from './project-item-page.helper';
import {CommonPageConstants} from '../../common/common-page.constants';
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

    static get cancelPopupButton() {
        return {
            cancel: ElementHelper.getElementByText(CommonPageConstants.formLabels.cancel)
        };
    }

    static get selectTeamMember() {
        return element(By.xpath(`.//a[.="${ProjectItemPageConstants.teamMember}"]`));
    }

    static get selectTeamMemberCheckBox() {
        return element(By.xpath(`.//td[.="${ProjectItemPageConstants.teamMember}"]//parent::tr//*[contains(@class,'GMCellPanel')]`));
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

    static get assignmentPlannerFrame() {
        return browser.driver.findElement(By.xpath('//iframe[contains(@id,"DlgFrame")][contains(@src,"AssignmentPlanner")]'));
    }

    static get newTask() {
        return element(By.id('txtNewTask'));
    }

    static get changeWindow() {
        return ElementHelper.getElementByText(ProjectItemPageConstants.changeWindow);
    }

    static get issueWindow() {
        return ElementHelper.getElementByText(ProjectItemPageConstants.issueWindow);
    }

    static get selectPlanner() {
        const label = ProjectItemPageConstants.plannerLabels;
        return {
            microsoftProject: CommonPageHelper.getElementUsingText(label.microsoftProject, false),
            projectPlanner: CommonPageHelper.getElementUsingText(label.projectPlanner, false)

        };
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

    static get fragmentDropDownLabels() {
        const label = ProjectItemPageConstants.fragmentLabels;
        return {
            insert: element(By.xpath(`.//a[.="${label.insert}"]//*[contains(@class,"glass")]`)),
            save: element(By.xpath(`.//a[.="${label.save}"]//*[contains(@class,"glass")]`)),
            manage: element(By.xpath(`.//a[.="${label.manage}"]//*[contains(@class,"glass")]`)),
        };
    }

    static get reportHeaders() {
        const label = ProjectItemPageConstants.reportHeaders;
        return {
            refresh: ProjectItemPageHelper.getReportPagingHeaderByTitle(label.refresh),
            firstPage: ProjectItemPageHelper.getDisabledReportPagingHeaderByTitle(label.firstPage),
            previousPage: ProjectItemPageHelper.getDisabledReportPagingHeaderByTitle(label.previousPage),
            nextPage: ProjectItemPageHelper.getDisabledReportPagingHeaderByTitle(label.nextPage),
            lastPage: ProjectItemPageHelper.getDisabledReportPagingHeaderByTitle(label.lastPage),
            findTextInReport: CommonPageHelper.getElementByTitle(label.findTextInReport),
            findNext: CommonPageHelper.getElementByTitle(label.findNext)
        };
    }

    static get actionsdropdown() {
        return element(By.xpath(`(//a[contains(@id,"RSActionMenu") and @title="Open Menu"])[last()]`));
    }

    static get deleteTask() {
        return element(By.css('[id*="DeleteTask"]'));
    }

    static get applyParameterButton() {
        return element(By.css(`input[name*="ApplyParameters"][value="Apply"]`));
    }

    static get saveViewButton() {
        return element(By.css(`[id*="SaveView"]`));
    }

    static get associatedItemsDropDown() {
        return ElementHelper.getElementByText(ProjectItemPageConstants.associated);
    }

    static get OkButton() {
        return element(By.css(`[id="viewNameDiv"] [value="OK"]`));
    }

    static get fragmentIcon() {
        return element(By.xpath(`.//a[.="${ProjectItemPageConstants.fragmentLabels.fragment}"]`));
    }

    static get privateCheckBox() {
        return element(By.css(`[id*="chkPrivate"]`));
    }

    static get closeFragmentButton() {
        return element(By.css('[id*="btnClose"]'));
    }

    static get firstFragment() {
        return element(By.css('.modal-body tbody tr:nth-child(1)'));
    }

    static get ganttChart() {
        return './/*[contains(@class,"GSHeadRight")]';
    }

    static get ganttChartBars() {
        return element(By.xpath(`${this.ganttChart}//parent::td[contains(@style,"none")]`));
    }

    static get fragmentUploadMessage() {
        return ElementHelper.getElementByText(ProjectItemPageConstants.messageText.uploadSuccessfully, true);
    }

    static get insertFragmentButton() {
        return element(By.css('[id*="btnImport"]'));
    }

    static get saveViewNameField() {
        return element(By.id(`viewname`));
    }

    static get currentViewDropDown() {
        return element(By.css(`[id*="WorkViewsGroup"][class*="arrow-button"]`));
    }

    static get viewsButton() {
        return ElementHelper.getElementByText(ProjectItemPageConstants.views);
    }

    static get actuallCostColumn() {
        return ElementHelper.getElementByText(ProjectItemPageConstants.actualCost);
    }

    static get selectColumnName() {
        return element(By.xpath(`.//div[.="${ProjectItemPageConstants.actualCost}"]${this.unCheckedCheckbox}`));
    }

    static get linkDropDownId() {
        return 'slctAddLinkType';
    }

    static get linkTypeDropDownId() {
        return element(By.id(`slctAddLinkType`));
}

    static get lagTimeTextBox() {
        return element(By.id(`txtAddLinkLag`));
    }

    static get linkDropDownValue() {
        return element(By.xpath(`.//*[@id="${this.linkDropDownId}"]/option[1]`));
    }

    static get unCheckedCheckbox() {
        return '/div[contains(@class,"Unchecked")]';
    }

    static get checkedSelectColumn() {
        return element(By.xpath(`.//div[.="${ProjectItemPageConstants.actualCost}"]${this.checkedCheckbox}`));
    }

    static get checkedCheckbox() {
        return '/div[contains(@class,"Checked")]';
    }

    static get showGanttButton() {
        return ElementHelper.getElementByText(ProjectItemPageConstants.viewsItems.showgantt);
    }

    static get title() {
        return element(By.xpath('//*[@id="ResourceGrid"]//*[.="Title"]'));
    }

    static async getUserCheckBoxForTeamType(teamType: string, userName: string) {
        const xpathForUser = `//td[normalize-space(@id)="${teamType}"]//a[normalize-space(text())="${userName}"]
        //parent::td//parent::tr/td[contains(@class,"GMCellPanel")]`;
        return element(By.xpath(xpathForUser));
    }

    static get itemOptions() {
        return {
            resourceAnalyzer: element(By.css('[id*="Ribbon.ListItem.Manage.EPKResourceAnalyzer"]')),
            editCourse: element(By.css('[id*="Ribbon.ListItem.Manage.EPKCosts"]'))
        };
    }

    static get planActionButtons() {
        return {
            save: element(By.id('SaveBtn')),
            close: element(By.id('CloseBtn'))
        };
    }

    static get toolButtons() {
        return {
            categories: element(By.id('CategoriesBtn')),
            detail: element(By.id('DetailBtn')),
            delete: element(By.id('RemoveBtn')),
            tools: element(By.id('ToolsBtn')),
            showReference: element(By.id('ShowRefBtn'))
        };
    }

    static get createColumnTabLabel() {
        return {
            nameAndType: ElementHelper.getElementByText(ProjectItemPageConstants.createColumnTabLabel.nameAndType, true),
            additionalColumnSetting: ElementHelper.getElementByText(ProjectItemPageConstants.createColumnTabLabel.additionalColumnSetting),
            columnValidation: CommonPageHelper.getATagByText(ProjectItemPageConstants.createColumnTabLabel.columnValidation, true),
        };
    }

    static get associatedItems() {
        return {
            // Below xpath required, element will not be clickable by other xpath css is not possible.
            lists: ElementHelper.getElementByText(ProjectItemPageConstants.associatedItems.lists),
            changes: element(By.xpath(`${this.associatedGroup}//*[text()="${ProjectItemPageConstants.associatedItems.changes}"]
            /following-sibling::span`)),
            issues: element(By.xpath(`${this.associatedGroup}//*[text()="${ProjectItemPageConstants.associatedItems.issues}"]
            /following-sibling::span`)),
            risks: element(By.xpath(`${this.associatedGroup}//*[text()="${ProjectItemPageConstants.associatedItems.risks}"]
            /following-sibling::span`)),
            documentLibraries: ElementHelper.getElementByText(ProjectItemPageConstants.associatedItems.documentLibraries),
        };
    }

    static get periodButtons() {
        return {
            fromPeriod: element(By.css('[id*="FromPeriod_button"]')),
            toPeriod: element(By.css('[id*="ToPeriod_button"]'))
        };
    }

    static get selectColumnLabel() {
        return {
            ok: ElementHelper.getElementByText(ProjectItemPageConstants.selectColumnLabel.ok),
            hideAll: ElementHelper.getElementByText(ProjectItemPageConstants.selectColumnLabel.hideAll),
            cancel: ElementHelper.getElementByText(ProjectItemPageConstants.selectColumnLabel.cancel),
        };
    }

    static get selectTaskName() {
        // because xpath get change when tab selected, it used only once and "GSDataRow" I have managed for other locator.
        return element(By.xpath('.//*[@class="GSSection"]/tbody/tr[3]//*[contains(@class,"GSDataRow ")]//*[contains(@class,"Start")]'));
    }

    static get assignToDropDown() {
        return element(By.css('[class*= "AssignedTo"][class*="Edit"][style]'));
    }

    static get save() {
        return element(By.css('[id*="SaveButton"]'));
    }

    static get close() {
        return element(By.css('[id*="CloseButton"]'));
    }

    static get associatedGroup() {
        return `.//*[contains(@id,"CreateNewItem-Menu")]`;
    }

    static get publishstatus() {
        return element(By.css('[id*="publish"] a'));
    }

    static get publishButtton() {
        return element(By.css('[id*="PublishButton"]'));
    }

    static get profilePicOfUser() {
        return element(By.css('[id*="CounterProfile"]'));
    }

    static get linkType() {
        return ElementHelper.getElementByText(ProjectItemPageConstants.addLinkPopup.linkType, true);
    }

    static get cancelButton() {
        return element(By.css('#addlinkdiv [value="Cancel"]'));
    }
    static get noProjecrMsg() {
        return ElementHelper.getElementByText(ProjectItemPageConstants.noDataFound);
    }
}
