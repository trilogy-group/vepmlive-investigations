import {BasePage} from '../base-page';
import {browser, By, element} from 'protractor';
import {ElementHelper} from '../../../components/html/element-helper';
import {CommonPageConstants} from './common-page.constants';
import {CommonPageHelper} from './common-page.helper';
import {ButtonHelper} from '../../../components/html/button-helper';
import {HtmlHelper} from '../../../components/misc-utils/html-helper';
import {AnchorHelper} from '../../../components/html/anchor-helper';
import {RiskItemPageConstants} from '../items-page/risk-item/risk-item-page.constants';
import {ComponentHelpers} from '../../../components/devfactory/component-helpers/component-helpers';

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
                risks: CommonPageHelper.getPageHeaderByTitle(projectsLabels.risks),
                issues: CommonPageHelper.getPageHeaderByTitle(projectsLabels.issues),
                changes: CommonPageHelper.getPageHeaderByTitle(projectsLabels.changes),
                documents: CommonPageHelper.getPageHeaderByTitle(projectsLabels.documents),
                resources: CommonPageHelper.getPageHeaderByTitle(projectsLabels.resources, true),
                reports: CommonPageHelper.getPageHeaderByTitle(projectsLabels.reports),
                reporting: CommonPageHelper.getPageHeaderByTitle(projectsLabels.reporting),
                projectPlanner: CommonPageHelper.getPageHeaderByTitle(projectsLabels.projectPlanner, true)
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
            list: CommonPageHelper.getMenuItemFromRibbonContainer(titles.list)
        };
    }

    static get ribbonItems() {
        const labels = CommonPageConstants.ribbonLabels;
        return {
            viewItem: CommonPageHelper.getRibbonButtonByText(labels.viewItem),
            attachFile: CommonPageHelper.getRibbonButtonByText(labels.attachFile),
            save: CommonPageHelper.getRibbonButtonByText(labels.save),
            editItem: CommonPageHelper.getRibbonButtonByText(labels.editItem),
            editCost: CommonPageHelper.getRibbonButtonById(labels.editCost),
            cancel: CommonPageHelper.getRibbonButtonByText(labels.cancel),
            addTask: CommonPageHelper.getRibbonButtonById(labels.addTask),
            editTeam: CommonPageHelper.getRibbonSmallButtonByTitle(labels.editTeam),
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
        // element(By.css('.ms-dlgFrame')) never works in case of iframe
        return browser.driver.findElement(By.css('.ms-dlgFrame'));
    }

    static get actionMenuIcons() {
        const titles = CommonPageConstants.actionMenuIconTitles;
        return {
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

    static get recordWithoutGreenTicket() {
        return element(By.xpath(`(${this.selectorForRecordsWithoutGreenTick})[1]`));
    }

    static get records() {
        return element.all(By.xpath(this.selectorForRecordsWithGreenTick));
    }

    static get selectorForRecordsWithGreenTick() {
        return `${this.selectorForRecordsWithoutGreenTick}//img[contains(@src,"green") or contains(@src,"checkmark")]`;
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

    static get editPlan() {
        return element(By.xpath('.//*[contains(@id,"EPMLive.Planner")]'));
    }

    static get project() {
        return element(By.xpath(`.//*[contains(@onmousemove,'Rows["1"]')]//*[contains(@href,'Lists/Project')]`));
    }

    static get actualCostTab() {
        return element(By.xpath('//div[not(contains(@tab_id,"ref"))]/*[text()="Actual Costs"]'));
    }

    static getVersionNumberByRowText(searchCellText: string, targetCellText: string, isContainsSearchCell = false) {
        const item = element(By.xpath(`//tr[td[${ComponentHelpers.getXPathFunctionForDot
        (searchCellText, isContainsSearchCell)}]]//td[normalize-space(.)= '${targetCellText}']`));
        return item;
    }

    static get versionCommentField() {
        return element(By.xpath('.//*[contains(@id,"CheckInComment")]'));
    }

    static get newVersionCheckbox() {
        return element(By.xpath('.//*[contains(@id,"OverwriteSingle")]'));
    }

    static get documentTitle() {
        return element(By.xpath('.//*[contains(@id,"surfaceopt")]'));
    }

    static get projectsList() {
        return element(By.css('.ms-commentexpand-iconouter'));
    }

    static get UpdatePropertyDocument() {
        return element(By.xpath('.//*[contains(text(),"update the properties")]'));
    }

    static get cellTextBox1() {
        return element(By.xpath('.//*[contains(@onmousemove,"I24")]/td[contains(@class,"HideCol0C10")]'));
    }

    static get cellTextBox2() {
        return element(By.xpath('.//*[contains(@onmousemove,"I24")]/td[contains(@class,"HideCol0C12")]'));
    }

    static get cellTextBox3() {
        return element(By.xpath('.//*[contains(@onmousemove,"I24")]/td[contains(@class,"HideCol0C13")]'));
    }

    static get budgetTab() {
        return element(By.xpath('.//*[contains(@class,"element_active")]/*[text()=\'Budget\']'));
    }

    static get okButton () {
        return element(By.css('[id="onetidSaveItem"]'));
    }

    static get benefitsCostTab() {
        return element(By.xpath('//div[not(contains(@tab_id,"ref"))]/*[text()="Benefits"]'));
    }

    static get calendearView() {
            return element(By.xpath('.//*[@id="Ribbon.Calendar.Calendar"]'));
    }

    static get singleSearchTextBox() {
        return CommonPageHelper.getElementByTitle('Type something and hit enter to search this list');
    }

    static get closeButton() {
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
            editPlan: CommonPageHelper.getContextMenuItemByText(options.editPlan)
        };
    }

    static get settingButton() {
        return element(By.css('[data-original-title="settings"]'));
    }

    static get projectShowAllButton() {
        return element(By.id('Project_ddlShowAll'));
    }

    static get tabPanel() {
        return CommonPageHelper.getElementByRole(HtmlHelper.tags.tabPanel);
   }

    static get searchChoiceOption(){
        return {
           proposed: element(By.css(`[value="${CommonPageConstants.states.proposed}"]`)),
           active: element(By.css(`[value="${CommonPageConstants.states.active}"]`)),
           closed: element(By.css(`[value="${CommonPageConstants.states.closed}"]`)),
        };
    }

    static get searchIcon(){
        return element(By.css(`[src*='find_icon']`));
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

    static get personIcon(){
        return element(By.id('EPMLiveNotificationCounterProfilePic'));
    }

    static get latestNotification(){
        return element(By.className('EPMLiveNotificationTitle'));
    }
}
