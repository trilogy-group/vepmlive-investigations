import { browser, By, element } from 'protractor';

import { BasePage } from '../base-page';
import { CommonPageConstants } from './common-page.constants';
import { CommonPageHelper } from './common-page.helper';
import { ButtonHelper } from '../../../components/html/button-helper';
import { HtmlHelper } from '../../../components/misc-utils/html-helper';
import { AnchorHelper } from '../../../components/html/anchor-helper';
import { RiskItemPageConstants } from '../items-page/risk-item/risk-item-page.constants';
import { TextComponentSelectors } from '../../../components/component-types/text-component/text-component-selectors';
import { ElementHelper } from '../../../components/html/element-helper';

export class CommonPage extends BasePage {

    static readonly dialogTitleId = 'dialogTitleSpan';
    static readonly plannerClass = 'GMEditCellInput';
    static readonly titleId = 'pageTitle';

    static get sidebarMenus() {
        const idPrefix = 'epm-nav-top-';
        return {
            navigation: element(By.id(`${idPrefix}ql`)),
            createNew: element(By.id(`${idPrefix}new`)),
            myWorkplace: element(By.id(`${idPrefix}workplace`)),
            favorites: element(By.id(`${idPrefix}favorites`)),
            mostRecent: element(By.id(`${idPrefix}recent`)),
            settings: element(By.id(`${idPrefix}settings`)),
            workspaces: element(By.id(`${idPrefix}workspaces`))
        };
    }

    static get sidebarMenuPanelHeader() {
        const label = CommonPageConstants.sidebarMenuPanelHeader;
        return {
            workspaces: TextComponentSelectors.getListByText(label.workspaces),
            createNew: TextComponentSelectors.getListByText(label.createNew),
            myWorkplace: TextComponentSelectors.getListByText(label.myWorkplace),
            favorites: TextComponentSelectors.getListByText(label.favorites),
            mostRecent: TextComponentSelectors.getListByText(label.mostRecent),
            settings: TextComponentSelectors.getListByText(label.settings),
            frequentApps: TextComponentSelectors.getListByText(label.frequentApps),
        };
    }

    static get addNewLink() {
        return element(By.css(`[title="${CommonPageConstants.newItem}"] a`));
    }

    static get contentTitleInViewMode() {
        return element(By.css('span.dispFormFancyTitle'));
    }

    static get pageHeaders() {
        const projectsLabels = CommonPageConstants.pageHeaders.projects;
        const myWorkplaceLabels = CommonPageConstants.pageHeaders.myWorkplace;
        return {
            projects: {
                requests: CommonPageHelper.getPageHeaderByTitle(projectsLabels.requests),
                portfolios: CommonPageHelper.getPageHeaderByTitle(projectsLabels.portfolios),
                projectPortfolios: CommonPageHelper.getPageHeaderByTitle(projectsLabels.projectPortfolios),
                projectsCenter: CommonPageHelper.getPageHeaderByTitle(projectsLabels.projectCenter),
                tasks: CommonPageHelper.getPageHeaderByTitle(projectsLabels.tasks),
                taskCenter: CommonPageHelper.getPageHeaderByTitle(projectsLabels.taskCenter),
                risks: CommonPageHelper.getPageHeaderByTitle(projectsLabels.risks),
                issues: CommonPageHelper.getPageHeaderByTitle(projectsLabels.issues),
                changes: CommonPageHelper.getPageHeaderByTitle(projectsLabels.changes),
                documents: CommonPageHelper.getPageHeaderByTitle(projectsLabels.documents),
                resources: CommonPageHelper.getPageHeaderByTitle(projectsLabels.resources, true),
                reports: CommonPageHelper.getPageHeaderByTitle(projectsLabels.reports),
                reporting: CommonPageHelper.getPageHeaderByTitle(projectsLabels.reporting),
                projectPlanner: CommonPageHelper.getPageHeaderByTitle(projectsLabels.projectPlanner, true),
                optimizer: CommonPageHelper.getElementByText(projectsLabels.optimizer),
                projectDetails: CommonPageHelper.getElementByText(CommonPageConstants.pageHeaders.projects.projectDetails, true),
                optimizerConfiguration: CommonPageHelper.getElementByText(CommonPageConstants.pageHeaders.projects.optimizerConfiguration),

            },
            myWorkplace: {
                myWork: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.myWork, true),
                myTimeSheet: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.myTimeSheet),
                myTimeOff: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.myTimeOff),
                timeOff: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.timeOff),
                toDo: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.toDo),
                discussions: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.discussions),
                events: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.events),
                wikis: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.wikis),
                sharedDocuments: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.sharedDocuments),
                pictures: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.pictures),
                links: CommonPageHelper.getPageHeaderByTitle(myWorkplaceLabels.links)
            }
        };
    }

    static get ribbonTitles() {
        const titles = CommonPageConstants.ribbonMenuTitles;
        return {
            hide: CommonPageHelper.getMenuItemFromRibbonContainer(titles.hide),
            items: CommonPageHelper.getMenuItemFromRibbonContainer(titles.items),
            manage: CommonPageHelper.getMenuItemFromRibbonContainer(titles.manage),
            list: CommonPageHelper.getMenuItemFromRibbonContainer(titles.list),
            page: CommonPageHelper.getMenuItemFromRibbonContainer(titles.page)
        };
    }

    static get ribbonItems() {
        const labels = CommonPageConstants.ribbonLabels;
        const ids = CommonPageConstants.ribbonIds;
        return {
            viewItem: CommonPageHelper.getRibbonButtonByText(labels.viewItem),
            attachFile: CommonPageHelper.getRibbonButtonByText(labels.attachFile),
            save: CommonPageHelper.getRibbonButtonByText(labels.save),
            add: CommonPageHelper.getRibbonButtonByText(labels.add),
            editItem: CommonPageHelper.getRibbonButtonByText(labels.editItem),
            editCost: CommonPageHelper.getRibbonButtonById(labels.editCost),
            cancel: CommonPageHelper.getRibbonButtonByText(labels.cancel),
            addTask: CommonPageHelper.getRibbonButtonById(labels.addTask),
            editTeam: CommonPageHelper.getRibbonSmallButtonByTitle(labels.editTeam),
            editTeamButton: CommonPageHelper.getRibbonSmallButtonById(ids.editTeamIdSubstr),
            deleteItemButton: CommonPageHelper.getRibbonSmallButtonById(ids.deleteItemIdSubstr),
            close: CommonPageHelper.getRibbonButtonByText(labels.close),
            saveAndClose: CommonPageHelper.getRibbonButtonByText(labels.saveAndClose),
            assignmentPlanner: CommonPageHelper.getRibbonMediumButtonByTitle(labels.assignmentPlanner),
            viewReports: CommonPageHelper.getRibbonMediumButtonByTitle(labels.viewReports),
            resourceAvailableVsPlannedByDept: CommonPageHelper.getRibbonMediumButtonByTitle(labels.resourceAvailableVsPlannedByDept),
            resourceCapacityHeatMap: CommonPageHelper.getRibbonMediumButtonByTitle(labels.resourceCapacityHeatMap),
            resourceCommitments: CommonPageHelper.getRibbonMediumButtonByTitle(labels.resourceCommitments),
            resourceRequirements: CommonPageHelper.getRibbonMediumButtonByTitle(labels.resourceRequirements),
            resourceWorkVsCapacity: CommonPageHelper.getRibbonMediumButtonByTitle(labels.resourceWorkVsCapacity),
            editTeamProjectPlanner: CommonPageHelper.getRibbonMediumButtonByTitle(labels.editTeam),
            editResource: CommonPageHelper.getRibbonButtonByText(labels.editResource, true),
            resourceAnalyzer: CommonPageHelper.getRibbonButtonByText(labels.resourceAnalyzer),
            delete: CommonPageHelper.getRibbonButtonById(labels.delete),
            optimizer: CommonPageHelper.getRibbonButtonByText(labels.optimizer)
        };
    }

    static get disabledribbonItems() {
        const labels = CommonPageConstants.disabledribbonbuttonsId;
        return {
            saveAndClose: CommonPageHelper.getDisabledRibbonButtonById(labels.saveAndClose)
        };
    }

    static get formButtons() {
        const labels = CommonPageConstants.formLabels;
        return {
            save: ButtonHelper.getInputButtonByTextUnderTable(labels.save),
            ok: ButtonHelper.getInputButtonByTextUnderTable(labels.ok),
            close: ButtonHelper.getInputButtonsByText(labels.close).first(),
            okWithSmallK: ButtonHelper.getInputButtonByTextUnderTable(labels.okWithSmallK),
            okOutsideTable: ButtonHelper.getInputButtonsByText(labels.ok),
            cancel: ButtonHelper.getInputButtonByTextUnderTable(labels.cancel),
            add: ButtonHelper.getInputButtonByTextUnderTable(labels.add),
            remove: ButtonHelper.getInputButtonByTextUnderTable(labels.remove)
        };
    }

    static get saveNewEvent() {
        return element(By.css(`input[id$="${CommonPageConstants.specificIds.saveEventId}"]`));
    }

    static get title() {
        // Css doesn't allow to limit the no of elements and we need to keep it like that otherwise its getting >1 item
        return element(By.xpath(`(//*[@id='${this.titleId}'])[1]`));
    }

    static get dialogTitles() {
        return element.all(By.css(`h1#${this.dialogTitleId}`));
    }

    static get dialogTitle() {
        return element(By.xpath(`(//*[@id='${this.dialogTitleId}'])[1]`));
    }

    static get contentFrame() {
        return element(By.css('.ms-dlgFrame'));
    }

    static get analyzerFrame() {
        // element(By.css('.ms-dlgFrame')) never works in case of iframe
        return browser.driver.findElement(By.css('.dhx_modal_cover_ifr'));
    }

    static get userInfoFrame() {
        return element.all(By.css('.ms-dlgFrame')).last().getWebElement();
    }

    static get resourceGrid() {
        return `[id='tdRes']`;
    }

    static get savePopupBox() {
        return element(By.css(`[title="Save Fragment"]`));
    }

    static get resourceGroupingButton() {
        return element(By.css(`${this.resourceGrid} [data-original-title*='Grouping']`));
    }

    static get createColumnDlgBox() {
        return element(By.css(`[class*="ColumnsMenuHead"]`));
    }

    static get resourceGroupingColumn() {
        return element(By.css(`${this.resourceGrid} .GMHeaderGroupCustom`));
    }

    static get editTeamButtonOnTask() {
        return ElementHelper.getElementByText(CommonPageConstants.ribbonLabels.editTeam);
    }

    static get closeButton() {
        return element(By.css(`[id*=".CloseButton"]`));
    }

    static get actionMenuIcons() {
        const titles = CommonPageConstants.actionMenuIconTitles;
        return {
            searchIcon:  element(By.css('span[class*=icon-search]')),
            search: CommonPageHelper.getActionMenuIcons(titles.search),
            toggleFilters: CommonPageHelper.getActionMenuIcons(titles.toggleFilters),
            defaultSort: CommonPageHelper.getActionMenuIcons(titles.defaultSort),
            groupBy: CommonPageHelper.getActionMenuIcons(titles.groupBy),
            selectColumns: CommonPageHelper.getActionMenuIcons(titles.selectColumns),
            view: CommonPageHelper.getActionMenuIcons(titles.view),
            settings: CommonPageHelper.getActionMenuIcons(titles.settings)
        };
    }

    static get applySelectColumnButton() {
        return element(By.xpath(`//div[contains(@class,'grouping-apply')]//a[normalize-space(.)='Apply']`));
    }

    static get ganttGrid() {
        return ElementHelper.getElementByStartsWithId('GanttGrid');
    }

    static get searchControls() {
        return {
            text: element(By.css('#searchtext0Main,#searchtext2Main')),
            type: element(By.css('#searchtype0Main,#searchtype2Main')),
            column: element(By.css('#search0Main,#search2Main')),
            textChoice: element(By.css('#searchchoice0Main'))
        };
    }

    static get record() {
        return element(By.xpath(`(${this.selectorForRecordsWithGreenTick})[1]`));
    }

    static get secondRecord() {
        return element(By.css(`tr.GMClassSelected +tr > td.GMCellPanel`));
    }

    static get recordWithoutGreenTicket() {
        return element(By.xpath(`(${this.selectorForRecordsWithoutGreenTick})[1]`));
    }

    static get uploadSuccessFullyText() {
        return {
            message: ElementHelper.getElementByText(CommonPageConstants.documentUploadText),
        };
    }

    static get records() {
        return element.all(By.xpath(this.selectorForRecordsWithGreenTick));
    }

    static get timeZone() {
        return element(By.css('[name*="TimeZone"][disabled]'));
    }

    static get iconEllipsisHorizontal() {
        return element(By.xpath('//*[@class="GMSection"]//*[@class="icon-ellipsis-horizontal"]'));
    }

    static get selectorForRecordsWithGreenTick() {
        return `${this.selectorForRecordsWithoutGreenTick}//img[contains(@src,"green") or contains(@src,"checkmark")]`;
    }

    static get projectsList() {
        return element(By.css('.ms-commentexpand-iconouter'));
    }

    static get projectCheckbox() {
        return element(By.css(`(${this.projectFirstRow}) [class*='GMCellPanel GMEmpty']`));
    }

    static get projectFirstRow() {
        return `[onmousemove*='Rows["1"]']`;
    }

    static get selectorForRecordsWithoutGreenTick() {
        return '//*[contains(@class,"GMDataRow")]';
    }

    static get selectColumnPanel() {
        return element(By.xpath('//*[contains(@id,"msColumns") and contains(@id,"_ul_menu")'));
    }

    static get ellipse() {
        return element(By.css('td .icon-ellipsis-horizontal'));
    }

    static get addButton() {
        return element(By.css('#addlinkdiv [value="Add Link"]'));
    }

    static get addLinkCancelButton() {
        return element(By.css('#addlinkdiv [value="Cancel"]'));
    }

    static get projectTab() {
        return element(By.css('[id*="Project-title"] span'));
    }

    static get setBaselineTab() {
        return element(By.css('[id*="SetBaseline"] [class*="img"]'));
    }

    static get clearBaselineTab() {
        return element(By.css('[id*="ClearBaseline"] [class*="img"]'));
    }

    static get okButton() {
        return element(By.css('#onetidSaveItem'));
    }

    static get cancelButton() {
        return element(By.id('onetidCancelItem'));
    }

    static get UpdatePropertyDocument() {
        return element(By.xpath('.//*[contains(text(),"update the properties")]'));
    }

    static get pageTitle() {
        return element(By.id('pageTitle'));
    }

    static get linkDownbutton() {
        return element(By.css('[id*="LinkDown"]'));
    }

    static get editPlan() {
        return element(By.xpath(' .//*[contains(@id,"EPMLive.Planner") and not(contains(@class,"disabled"))]'));
    }

    static get versionCommentField() {
        return element(By.css('[id*="CheckInComment"]'));
    }

    static get newVersionCheckbox() {
        return element(By.css('[id*="OverwriteSingle"]'));
    }

    static get buildTeam() {
        return element(By.css('[id*="BuildTeam-title"]'));
    }

    static get project() {
        // This xpath is best we have. Onmouse click is required
        return element(By.css(`${CommonPage.projectFirstRow} [href*='Lists/Project']`));
    }

    static get costButton() {
        const fields = CommonPageConstants.costButtonLabel;
        return {
            budget: CommonPageHelper.getActiveButtonByText(fields.budget),
            actualCost: CommonPageHelper.getActiveButtonByText(fields.actualCost),
            benefits: CommonPageHelper.getActiveButtonByText(fields.benefits),
        };

    }

    static get editCostButton() {
        const fields = CommonPageConstants.costButtonLabel;
        return {
            budget: CommonPageHelper.getEditCostTab(fields.budget),
            actualCost: CommonPageHelper.getEditCostTab(fields.actualCost),
            benefits: CommonPageHelper.getEditCostTab(fields.benefits),
        };

    }

    static get costTab() {
        // its required it will not work without "ref", there is another tab as well only one thing different that is "ref"
        return `//div[not(contains(@tab_id,"ref"))]`;
    }

    static get plannerbox() {
        return element(By.css('[id*="mbox"][style*="block"]'));
    }

    static get calendearView() {
        return element(By.css('[id="Ribbon.Calendar.Calendar"]'));
    }

    static get singleSearchTextBox() {
        return CommonPageHelper.getElementByTitle('Type something and hit enter to search this list');
    }

    static get resourceCloseButton() {
        return element(By.css('.ms-dlgCloseBtn'));
    }

    static get contextMenuOptions() {
        const options = CommonPageConstants.contextMenuOptions;
        return {
            viewItem: CommonPageHelper.getContextMenuItemByText(options.viewItem),
            editItem: CommonPageHelper.getContextMenuItemByText(options.editItem),
            workFlows: CommonPageHelper.getContextMenuItemByText(options.workFlows),
            permissions: CommonPageHelper.getContextMenuItemByText(options.permissions),
            deleteItem: CommonPageHelper.getContextMenuItemByText(options.deleteItem),
            comments: CommonPageHelper.getContextMenuItemByText(options.comments),
            editTeam: CommonPageHelper.getContextMenuItemByText(options.editTeam),
            editPlan: CommonPageHelper.getContextMenuItemByText(options.editPlan),
            editCosts: CommonPageHelper.getContextMenuItemByText(options.editCosts),
            editResource: CommonPageHelper.getContextMenuItemByText(options.editResource)
        };
    }

    static get settingButton() {
        return element(By.css('[data-original-title="settings"]'));
    }

    static get projectShowAllButton() {
        return element(By.id('Project_ddlShowAll'));
    }

    static get getCostCell() {
        const cells = CommonPageConstants.cell;
        return {
            cell1: CommonPageHelper.getCellText(cells.cell1),
            cell2: CommonPageHelper.getCellText(cells.cell2),
            cell3: CommonPageHelper.getCellText(cells.cell3),
            cell4: CommonPageHelper.getCellText(cells.cell4),
            cell5: CommonPageHelper.getCellText(cells.cell5),
            cell6: CommonPageHelper.getCellText(cells.cell6),
            cell7: CommonPageHelper.getCellText(cells.cell7)
        };
    }

    static get getbuttons() {
        return {
            calender: ElementHelper.getElementByText(CommonPageConstants.calendar),
        };
    }

    static get tabPanel() {
        return CommonPageHelper.getElementByRole(HtmlHelper.tags.tabPanel);
    }

    static get searchChoiceOption() {
        return {
            proposed: element(By.css(`[value="${CommonPageConstants.states.proposed}"]`)),
            active: element(By.css(`[value="${CommonPageConstants.states.active}"]`)),
            closed: element(By.css(`[value="${CommonPageConstants.states.closed}"]`)),
        };
    }

    static get searchIcon() {
        return element(By.css(`[src*='find_icon']`));
    }

    static get linkDisable() {
        return ElementHelper.getElementByText(CommonPageConstants.linkDisable, true);
    }

    static get regionCheckBox() {
        return element(By.css(`[id*="WebRegional"]`));
    }

    static get noDataFound() {
        return CommonPageHelper.getMessageNoDataFound(HtmlHelper.attributeValue.gmNoDataRow, CommonPageConstants.messages.noDataFound);
    }

    static get viewAll() {
        return element(By.linkText(CommonPageConstants.viewAll));
    }

    static get paginationControlsByTitle() {
        return {
            next: element(By.css(`[title='${CommonPageConstants.paginationTitle.next}']`)),
            previous: element(By.css(`[title='${CommonPageConstants.paginationTitle.previous}']`))
        };
    }

    static get fileUploadControl() {
        return element(By.css('#onetidIOFile,[id*="fileUploadControl"]'));
    }

    static get lastButton() {
        return AnchorHelper.getAnchorByText(CommonPageConstants.last);
    }

    static get searchTextBox() {
        return element(By.id('MWG_Search'));
    }

    static get selectedTitle() {
        const selectedClass = '.GMClassSelected ';
        return element(By.css(`${selectedClass} .EPMLiveMyWorkTitle div,${selectedClass} .GMHtml.HideCol0Title`));
    }

    static get uploadButton() {
        return element(By.css('.js-listview-qcbUploadButton,.js-listview-qcbNewButton'));
    }

    static get browseButton() {
        return element(By.css('.ms-fileinput'));
    }

    static get paging() {
        return element(By.css('.ms-paging'));
    }

    static get viewPageActions() {
        const publicViewLabels = CommonPageConstants.viewDropDownLabels;
        const riskColumns = RiskItemPageConstants.columnNames;
        return {
            createNewPublicView: CommonPageHelper.getCreateNewPublicViewOfDropDown(publicViewLabels.createPublicView),
            defaultDropDownViewByText: CommonPageHelper.getDropDownViewByText(RiskItemPageConstants.defaultViewName),
            titleViewColumn: CommonPageHelper.getColumnElement(riskColumns.title),
            assignedToViewColumn: CommonPageHelper.getColumnElement(riskColumns.assignedTo),
            statusViewColumn: CommonPageHelper.getColumnElement(riskColumns.status),
            dueDateViewColumn: CommonPageHelper.getColumnElement(riskColumns.dueDate)
        };
    }

    static get viewNewPageActions() {
        const createLabels = CommonPageConstants.newPublicViewformLabels;
        return {
            fillCreatePublicViewPageTitle: element(By.name(createLabels.title)),
            publicViewRadioButton: element(By.id(CommonPageConstants.newPublicViewformLabels.publicView)),
            scheduledStatusCheckBox: element(By.name(CommonPageConstants.newPublicViewformLabels.scheduleStatus)),
            exposureCheckBox: element(By.name(CommonPageConstants.newPublicViewformLabels.exposure)),
            dueCheckBox: element(By.name(CommonPageConstants.newPublicViewformLabels.due)),
            submitCreatePublicViewPage: element(By.id(CommonPageConstants.formLabels.topSave))
        };
    }

    static get itemsListing() {
        return AnchorHelper.getAnchorInsideGridByClass(HtmlHelper.attributeValue.gmClassReadOnly);
    }

    static get personIcon() {
        return element(By.id('EPMLiveNotificationCounterProfilePic'));
    }

    static get latestNotification() {
        return element.all(By.className('EPMLiveNotificationTitle')).get(0);
    }

    static get modelerButton() {
        return CommonPageHelper.getRibbonButtonByText(CommonPageConstants.ribbonLabels.modeler);
    }

    static get gridDetails() {
        const gridLabels = CommonPageConstants.gridDetails;
        return {
            editField: element(By.css(`.${gridLabels.editTitle}`)),
            scroll: element(By.css(`.${gridLabels.scroll}`)),
        };
    }

    static getDropDownByParameterNameXpath(name: string) {
        return `//*[@data-parametername="${name}"]//select`;
    }

    static getDropDownByParameterName(name: string, index = 1) {
        return element.all(By.xpath(this.getDropDownByParameterNameXpath(name))).get(index);
    }

    static periodEndOptionValue(name: string) {
        return element(By.xpath(`(${this.getDropDownByParameterNameXpath
            (name)})[2]//option[last()]`));
    }

    static getNthProject(index = 1) {
        return element.all(By.xpath(`(${this.selectorForRecordsWithoutGreenTick}//a)`)).get(index);
    }

    static getNthRecord(index = 1) {
        return element.all(By.xpath(`(${this.selectorForRecordsWithoutGreenTick})//td[contains(@class,'GMCellPanel')]`)).get(index);
    }

    static getGridRowByTitle(titleName: string) {
        return element(By.xpath(`//td[contains(@class,"${CommonPageConstants.gridDetails.title}")]//a[text()="${titleName}"]`));
    }

    static getOptionsUnderUserManagement(option: string) {
        const selector = `//ul[@id='epm-nav-sub-settings-user-management-links']//span[text()='${option}']`;
        return element(By.xpath(selector));
    }

    static get dataRows() {
        return element.all(By.css('tr.GMDataRow'));
    }

    static get itemsMenu() {
        return element(By.css(`li[title='Items'] a span`));
    }

    static get rowsFirstColumn() {
        return element.all(By.css('tr.GMDataRow td.GMCellPanel'));
    }

    static get rowsDataFirstColumn() {
        return element.all(By.css('table.GMSection tr.GMDataRow  td.GMCellPanel'));
    }
}
