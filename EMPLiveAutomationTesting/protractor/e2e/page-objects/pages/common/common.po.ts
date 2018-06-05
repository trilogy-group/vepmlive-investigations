import {BasePage} from '../base-page';
import {browser, By, element} from 'protractor';
import {ElementHelper} from '../../../components/html/element-helper';
import {CommonPageConstants} from './common-page.constants';
import {CommonPageHelper} from './common-page.helper';
import {ButtonHelper} from '../../../components/html/button-helper';
import {HtmlHelper} from '../../../components/misc-utils/html-helper';

export class CommonPage extends BasePage {

    static readonly dialogTitleId = 'dialogTitleSpan';
    static readonly plannerClass = 'GMEditCellInput';
    static readonly saveBtn = 'SaveBtn';
    static readonly closeBtn = 'CloseBtn';
    static readonly titleId = 'pageTitle';

    static get sidebarMenus() {
        const idPrefix = 'epm-nav-top-';
        return {
            navigation: element(By.id(`${idPrefix}ql`)),
            createNew: element(By.id(`${idPrefix}new`)),
            myWorkplace: element(By.id(`${idPrefix}workplace`)),
            favorites: element(By.id(`${idPrefix}favorites`)),
            mostRecent: element(By.id(`${idPrefix}recent`)),
            workspaces: element(By.id(`${idPrefix}workspaces`))
        };
    }

    static get addNewLink() {
        return element(By.css('[title="New Item"] a'));
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
            list: CommonPageHelper.getMenuItemFromRibbonContainer(titles.list)
        };
    }

    static get ribbonItems() {
        const labels = CommonPageConstants.ribbonLabels;
        return {
            viewItem: CommonPageHelper.getRibbonButtonByText(labels.viewItem),
            save: CommonPageHelper.getRibbonButtonByText(labels.save),
            editItem: CommonPageHelper.getRibbonButtonByText(labels.editItem),
            editCost: CommonPageHelper.getRibbonButtonById(labels.editCost),
            editPlan: CommonPageHelper.getRibbonButtonById(labels.editPlan),
            addTask: CommonPageHelper.getRibbonButtonById(labels.addTask),
            cancel: CommonPageHelper.getRibbonButtonByText(labels.cancel),
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
            save: ButtonHelper.getInputButtonByExactTextXPath(labels.save),
            ok: ButtonHelper.getInputButtonByExactTextXPath(labels.ok),
            cancel: ButtonHelper.getInputButtonByExactTextXPath(labels.cancel),
            add: ButtonHelper.getInputButtonByExactTextXPath(labels.add),
            remove: ButtonHelper.getInputButtonByExactTextXPath(labels.remove)
        };
    }

    static get ellipse() {
        return element(By.css('td .icon-ellipsis-horizontal'));
    }

    static get titles() {
        return element.all(By.id(this.titleId));
    }

    static get title() {
        return element(By.id(this.titleId));
    }

    static get eventDialogbox() {
        return element(By.xpath('.//*[@class="ms-dlgTitle"]'));
    }

    static get dialogTitles() {
        return element(By.xpath('//div[contains(@class,\'grouping-apply\')]//a[normalize-space(.)=\'Apply\']'));
    }

    static get cellTextBox1() {
        return element(By.xpath('.//*[contains(@onmousemove,"I24")]/*[contains(@class,"HideCol0C1")][1]'));
    }

    static get cellTextBox2() {
        return element(By.xpath('.//*[contains(@onmousemove,"I24")]/*[contains(@class,"HideCol0C2")][1]'));
    }

    static get cellTextBox3() {
        return element(By.xpath('.//*[contains(@onmousemove,"I24")]/*[contains(@class,"HideCol0C3")][1]'));
    }

    static get budgetTab() {
        return element(By.xpath('.//*[contains(@style,\'rgb(255, 255, 255)\')]/span[text()=\'Budget\']'));
    }

    static get actualCostTab() {
        return element(By.xpath('.//*[@tab_id=\'tab_9\' and @class]'));
    }

    static get benefitsCostTab() {
        return element(By.xpath('.//*[@tab_id=\'tab_10\' and @class]'));
    }

    static get clickONCostPlanner() {
        return element(By.id(this.plannerClass));
    }

    static get clickOnCloseButton() {
        return element(By.id(this.closeBtn));
    }

    static get clickOnSaveButton() {
        return element(By.id(this.saveBtn));
    }

    static get budgetEntervalue() {
        return element(By.xpath('.//*[contains(@onmousemove,\'I24\')]/*[contains(@class,\'HideCol0C1\')][1]'));
    }

    static get singleSearchTextBox() {
        return CommonPageHelper.getElementByTitle('Type something and hit enter to search this list');
    }

    static get dialogTitle() {
        return element(By.id(this.dialogTitleId));
    }

    static get fileVersion() {
        return element(By.xpath('.//a[text()="pdf-file_rjskzm-em"]//ancestor::div[1]//ancestor::tr[1]//td[7]'));
    }

    static get documentTitle() {
        return element(By.css('#WPQ2_ListTitleViewSelectorMenu_Container_surfaceopt0'));
    }

    static get projectCollapse() {
        return element(By.xpath('.//*[@class="ms-commentexpand-iconouter"]'));
    }

    static get versionCommentField() {
        return element(By.css('#ctl00_PlaceHolderMain_VersionCommentSection_ctl01_CheckInComment'));
    }

    static get homePageTitle() {
        return element(By.css('#MSOImageWebPart_WebPartWPQ3'));
    }

    static get contentUpdateFrame() {
        return element(By.xpath('.//*[contains(text(),"update the properties")]'));
    }

    static get contentFrame() {
        // element(By.css('.ms-dlgFrame')) never works in case of iframe
        return browser.driver.findElement(By.css('.ms-dlgFrame'));
    }

    static get newVersionCheckbox() {
            return element(By.css('#ctl00_PlaceHolderMain_ctl02_ctl04_OverwriteSingle'));
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
            column: element(By.css('#search0Main,#search2Main'))
        };
    }

    static get project() {
        return element(By.xpath(`(${this.selectorForProject})[1]`));
    }
    static get demoproject() {
        return element(By.xpath(`//*[@id="GanttGrid0Main"]/tbody/tr[2]/td[1]/div/div[2]/table/tbody/tr[3]/td/table/tbody/tr[2]/td[4]/a[1]`));
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
        return '//*[contains(@class,"GMDataRow")]//img[contains(@src,"green")]';
    }

    static get selectorForProject() {
        return '//*[contains(@class,"GMDataRow")]//a[contains(@href,"javascript")]';
    }

    static get selectorForRecordsWithoutGreenTick() {
        return '//*[contains(@class,"GMDataRow")]';
    }

    static get selectColumnPanel() {
        return element(By.xpath('//*[contains(@id,"msColumns") and contains(@id,"_ul_menu")'));
    }

    static get calendearView() {
        return element(By.xpath('.//*[@id="Ribbon.Calendar.Calendar"]'));
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

    static get tabPanel() {
        return CommonPageHelper.getElementByRole(HtmlHelper.tags.tabPanel);
   }
}
