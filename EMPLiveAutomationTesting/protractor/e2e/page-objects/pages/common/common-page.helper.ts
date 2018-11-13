import {browser, By, element, ElementArrayFinder, ElementFinder} from 'protractor';
import {ComponentHelpers} from '../../../components/devfactory/component-helpers/component-helpers';
import {HtmlHelper} from '../../../components/misc-utils/html-helper';
import {PageHelper} from '../../../components/html/page-helper';
import {CommonPageConstants} from './common-page.constants';
import {WaitHelper} from '../../../components/html/wait-helper';
import {ElementHelper} from '../../../components/html/element-helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {CheckboxHelper} from '../../../components/html/checkbox-helper';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {TextboxHelper} from '../../../components/html/textbox-helper';
import {CommonPage} from './common.po';
import * as path from 'path';
import {HomePageConstants} from '../homepage/home-page.constants';
import {AnchorHelper} from '../../../components/html/anchor-helper';
import {ProjectItemPage} from '../items-page/project-item/project-item.po';
import {ProjectItemPageHelper} from '../items-page/project-item/project-item-page.helper';
import {ProjectItemPageConstants} from '../items-page/project-item/project-item-page.constants';
import {ResourceAnalyzerPageHelper} from '../resource-analyzer-page/resource-analyzer-page.helper';
import {ResourceAnalyzerPage} from '../resource-analyzer-page/resource-analyzer-page.po';
import {IssueItemPageHelper} from '../items-page/issue-item/issue-item-page.helper';
import {ExpectationHelper} from '../../../components/misc-utils/expectation-helper';
import {HomePage} from '../homepage/home.po';

const fs = require('fs');

export class CommonPageHelper {

    static get uniqueImageFilePath() {
        const imageFile = CommonPageConstants.imageFile;
        const newFileName = `${imageFile.jpegFileName}_${PageHelper.getUniqueId()}`.toLowerCase();
        const dir = CommonPageConstants.filesDirectoryName;
        const fullFilePath = path.join(__dirname, dir, newFileName + imageFile.fileType);

        fs.createReadStream(imageFile.filePath())
            .pipe(fs.createWriteStream(fullFilePath));

        return {fullFilePath, newFileName: newFileName + imageFile.fileType};
    }

    static get uniqueDocumentFilePath() {
        const documentFile = CommonPageConstants.documentFile;
        const newFileName = `${documentFile.documentFileName}_${PageHelper.getUniqueId()}`.toLowerCase();
        const dir = CommonPageConstants.filesDirectoryName;
        const fullFilePath = path.join(__dirname, dir, newFileName + documentFile.fileType);

        fs.createReadStream(documentFile.filePath())
            .pipe(fs.createWriteStream(fullFilePath));

        return {fullFilePath, newFileName: newFileName + documentFile.fileType, file: newFileName};
    }

    public static get getCurrentDate() {
        return new Date().getDate();
    }

    public static get getPreviousDate() {
        const date = this.getCurrentDate;
        const yesterday = date - 1;
        return yesterday;
    }

    public static get getCurrentMonth() {
        const month = new Date().getMonth();
        return month + 1; // January is 0!
    }

    public static get getCurrentYear() {
        return new Date().getFullYear();
    }

    public static get getTodayInMMDDYYYY() {
        const currentDate = this.getCurrentMonth + '/' + this.getPreviousDate + '/' + this.getCurrentYear;
        return currentDate;
    }

    public static get getYesterdayInMMDDYYYY() {
        const tomorrowDate = this.getCurrentMonth + '/' + this.getCurrentDate + '/' + this.getCurrentYear;
        return tomorrowDate;
    }

    static get save() {
        return element(By.css('[id*="SaveButton"]'));
    }

    static getRibbonButtonById(id: string) {
        return element(By.xpath(`//*[contains(@id,'${id}')]`));
    }

    static getElementByText(text: string, isContains = false) {
        return element(By.xpath(`//*[${ComponentHelpers.getXPathFunctionForText(text, isContains)}]`));
    }

    static getSidebarLinkByTextUnderCreateNew(title: string) {
        return this.getElementUnderSections(CommonPageConstants.menuContainerIds.createNew,
            HtmlHelper.tags.li,
            title);
    }

    static getSidebarLinkByTextUnderMyWorkPlace(title: string) {
        return this.getElementUnderSections(CommonPageConstants.menuContainerIds.myWorkplace,
            HtmlHelper.tags.li,
            title);
    }

    static getElementUnderSections(id: string, elementType: string, title: string) {
        const cls = 'contains(@class,"epm-nav-node")';
        const textSelector = ComponentHelpers.getXPathFunctionForDot(title);
        const xpath = `//*[@id="${id}"]//${elementType}[${cls}]//a[${textSelector}]`;
        return element(By.xpath(xpath));
    }

    static getSidebarLinkByTextUnderNavigation(title: string) {
        return this.getElementUnderSections(CommonPageConstants.menuContainerIds.navigation,
            HtmlHelper.tags.td,
            title);
    }

    static getRibbonButtonByText(title: string, isContains = false) {
        return element(By.xpath(`//span[contains(@class,'ms-cui-ctl-largelabel')
         and (${ComponentHelpers.getXPathFunctionForDot(title, isContains)})]//parent::a`));
    }

    static getDisabledRibbonButtonById(id: string) {
        return element(By.xpath(`//*[contains(@class,"ms-cui-disabled")][@aria-disabled="true"][contains(@id,'${id}')]`));
    }

    static getRibbonSmallButtonByTitle(title: string) {
        return element(By.xpath(`//a[contains(@class,'ms-cui-ctl') and normalize-space(@title)='${title}']`));
    }

    static getRibbonSmallButtonById(id: string) {
        return element(By.css(`a[id^='${id}']`));
    }

    static getRibbonSmallButtonByText(text: string) {
        return element(By.xpath(`//a[contains(@class,'ms-cui-ctl') and contains((.),'${text}')]`));
    }

    static getRibbonMediumButtonByTitle(title: string, isContains = false) {
        return element(By.xpath
        (`//span[contains(@class,'ms-cui-ctl-mediumlabel') and ${ComponentHelpers.getXPathFunctionForDot(title, isContains)}]`));
    }

    static getToolBarItemsByText(title: string) {
        return element(By.xpath(`//ul[contains(@id,'epm-se-toolbar-items')]//a[text()='${title}']`));
    }

    static getTextBoxByLabel(title: string) {
        return this.getInputByLabel(HtmlHelper.tags.input, title);
    }

    static getTextBoxesByLabel(title: string) {
        return this.getInputsByLabel(HtmlHelper.tags.input, title);
    }

    static getTextAreaByLabel(title: string) {
        return this.getInputByLabel(HtmlHelper.tags.textArea, title);
    }

    static getFirstAutoCompleteByLabel(title: string) {
        return this.getInputByLabel('*[contains(@class,"autocomplete")]//*[contains(@class,"autoText")][1]', title);
    }

    static getSelectByLabel(title: string) {
        return this.getInputByLabel(HtmlHelper.tags.select, title);
    }

    static getInputByLabel(type: string, title: string) {
        return element(By.xpath(this.getXpathForInputByLabel(type, title)));
    }

    static getInputsByLabel(type: string, title: string) {
        return element.all(By.xpath(this.getXpathForInputByLabel(type, title)));
    }

    static getXpathForInputByLabel(type: string, title: string) {
        return `//table[contains(@class,"ms-formtable")]//td[normalize-space(.)='${title}']//parent::tr//${type}`;
    }

    static async switchToFirstContentFrame() {
        await WaitHelper.waitForElementToBePresent(CommonPage.contentFrame, PageHelper.timeout.m);
        try {
            return PageHelper.switchToFrame(CommonPage.contentFrame.getWebElement());
        } catch (e) {
            console.log('Iframe not present');
        }
    }

    static getAutoCompleteItemByDescription(description: string) {
        return element(By.css(`[description="${description}"]`));
    }

    static getRowForTableData(columnText: string[]) {
        const columnXpaths: string[] = [];
        for (let index = 0; index < columnText.length; index++) {
            columnXpaths.push(`td[normalize-space(.)='${columnText[index]}']`);
        }
        const xpath = `//tr[${columnXpaths.join(CommonPageConstants.and)}]`;
        return element(By.xpath(xpath));
    }

    static getElementByTitle(title: string) {
        const xpath = `[title="${title}"]`;
        return element(By.css(xpath));
    }

    static getPageHeaderByTitle(title: string, isContains = false) {
        const xpath = `//*[@id='${CommonPage.titleId}']//*[${ComponentHelpers.getXPathFunctionForDot(title, isContains)}]`;
        return element.all(By.xpath(xpath)).first();
    }

    static getActionMenuIcons(title: string) {
        const xpath = `//*[${ComponentHelpers.getXPathFunctionForStringComparison('actionmenu', '@id', true)}]//li[@title="${title}"]`;
        return element(By.xpath(xpath));
    }

    static getContextMenuItemByText(text: string) {
        const xpath = `//ul[contains(@class,"epm-nav-contextual-menu")]//a[${ComponentHelpers.getXPathFunctionForDot(text)}]`;
        return element(By.xpath(xpath));
    }

    static getElementUsingText(text: string, isContains: boolean) {
        const xpath = `//*[${ComponentHelpers.getXPathFunctionForDot(text, isContains)}]`;
        return element.all(By.xpath(xpath)).first();
    }

    static getElementUsingTextContent(text: string, isContains: boolean) {
        const xpath = `//*[${ComponentHelpers.getXPathFunctionForText(text, isContains)}]`;
        return element(By.xpath(xpath));
    }

    static async navigateToItemPageUnderNavigation(linkOfThePage: ElementFinder,
                                                   pageHeader: ElementFinder,
                                                   pageName: string,
    ) {
        StepLogger.step('Select "Navigation" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.navigation);
        await CommonPageHelper.navigateToSubPage(pageName, linkOfThePage, pageHeader);
    }

    static async searchByTitle(linkOfThePage: ElementFinder,
                               pageHeader: ElementFinder,
                               pageName: string,
                               titleValue: string, columnName: string) {
        await this.navigateToItemPageUnderNavigation(
            linkOfThePage,
            pageHeader,
            pageName,
        );
        await this.searchItemByTitle(titleValue, columnName, );
    }

    static async navigateToItemPageUnderMyWorkplace(linkOfThePage: ElementFinder,
                                                    pageHeader: ElementFinder,
                                                    pageName: string
    ) {
        StepLogger.step('Select "My Workplace" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.myWorkplace);
        StepLogger.stepId(2);
        await CommonPageHelper.navigateToSubPage(pageName, linkOfThePage, pageHeader);
    }

    static async navigateToSubPage(pageName: string, linkOfThePage: ElementFinder, pageHeader: ElementFinder) {
        StepLogger.step(`Select Project -> ${pageName} from the left side menu options displayed`);
        await PageHelper.click(linkOfThePage);

        StepLogger.verification(`${pageName} page is displayed`);
        await expect(await PageHelper.isElementDisplayed(pageHeader, true))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(pageName));
    }

    static getColumnHeaderByText(text: string) {
        return element(By.xpath(`//td[contains(@class,'GMHeaderText') and ${ComponentHelpers.getXPathFunctionForDot(text)}]`));
    }

    static async searchItemByTitle(titleValue: string, columnName: string, verifySearchControl = false) {

        StepLogger.step('Click on search');
        await PageHelper.click(CommonPage.actionMenuIcons.searchIcon);

        if (verifySearchControl === true) {
            StepLogger.verification('Search Component dropdown is available');
            await expect(await PageHelper.isElementDisplayed(CommonPage.searchControls.column))
                .toBe(true, ValidationsHelper.getDisplayedValidation(CommonPageConstants.searchControl.searchComponentDropdown));
            StepLogger.verification('Search Operator dropdown is available');
            await expect(await PageHelper.isElementDisplayed(CommonPage.searchControls.type))
                .toBe(true, ValidationsHelper.getDisplayedValidation(CommonPageConstants.searchControl.searchOperatorDropdown));
            StepLogger.verification('Search field is available');
            await expect(await PageHelper.isElementDisplayed(CommonPage.searchControls.text))
                .toBe(true, ValidationsHelper.getDisplayedValidation(CommonPageConstants.searchControl.searchField));
        }
        StepLogger.step('Select column name as Title');
        await PageHelper.sendKeysToInputField(CommonPage.searchControls.column, columnName);

        StepLogger.step('Enter search title');
        await TextboxHelper.sendKeys(CommonPage.searchControls.text, titleValue, true);
    }

    static async showColumns(columnNames: string[]) {
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ganttGrid);
        let isApplyRequired = false;
        let promises = await Array.from(columnNames, async (key: string) => {
            const isOptionAvailable = await CommonPageHelper.getColumnHeaderByText(key).isPresent();
            if (!isOptionAvailable) {
                isApplyRequired = true;
            }
            return;
        });
        await Promise.all(promises);
        if (isApplyRequired) {
            await PageHelper.click(CommonPage.actionMenuIcons.selectColumns);
            await WaitHelper.waitForElementToBeDisplayed(CommonPage.selectColumnPanel);
            promises = await Array.from(columnNames, async (key: string) => {
                await CheckboxHelper.markCheckbox(CommonPageHelper.getCheckboxByExactText(key), true);
            });
            await Promise.all(promises);
            await PageHelper.click(CommonPage.applySelectColumnButton);
        }
    }

    static getNotificationByText(text: string) {
        return element(By.xpath(`//h2[${ComponentHelpers.getXPathFunctionForDot(text)}]`));
    }

    static getPageNumberByTitle(title: string) {
        return element(By.xpath(`//a[contains(@class,'pageNumber') and contains(@title,"${title}")]`));
    }

    static getMenuItemFromRibbonContainer(title: string) {
        return element.all(By.css(`#RibbonContainer li[title="${title}"] span`)).first();
    }

    static async refreshPageIfRibbonElementIsDisable(targetElement: ElementFinder, item = CommonPage.record) {
        let maxAttempts = 0;
        await browser.sleep(PageHelper.timeout.s);

        while ((await CommonPageHelper.getRibbonIsDisable(targetElement, 'aria-disabled') === 'true') && maxAttempts++ < 5) {
            await browser.refresh();
            await this.selectRecordFromGrid(item);
        }
    }

    static async editOptionViaRibbon(item = CommonPage.record) {
        await this.selectRecordFromGrid(item);

        await this.refreshPageIfRibbonElementIsDisable(CommonPage.ribbonItems.editItem);

        StepLogger.step('Select "Edit Item" from the options displayed');
        await ElementHelper.clickUsingJsNoWait(CommonPage.ribbonItems.editItem);

    }

    static async editViaItems() {
        StepLogger.stepId(3);
        StepLogger.step('Select the check box for record');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dataRows.get(1));
        await ElementHelper.actionHoverOver(CommonPage.dataRows.get(1));
        await PageHelper.click(CommonPage.rowsFirstColumn.get(1));

        StepLogger.step('Click on ITEMS on ribbon');
        await WaitHelper.waitForElementToBePresent(CommonPage.itemsMenu);
        await PageHelper.click(CommonPage.itemsMenu);

        StepLogger.step('Select "Edit Item" from the options displayed');
        await WaitHelper.waitForElementToBePresent(CommonPage.ribbonItems.editItem);
        await PageHelper.click(CommonPage.ribbonItems.editItem);
    }

    static async viewViaItems() {
        StepLogger.stepId(2);
        StepLogger.step('Select the check box for record');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dataRows.get(1));
        await ElementHelper.actionHoverOver(CommonPage.dataRows.get(1));
        await PageHelper.click(CommonPage.rowsFirstColumn.get(1));

        StepLogger.step('Click on ITEMS on ribbon');
        await PageHelper.click(CommonPage.itemsMenu);

        StepLogger.step('Select "Edit Item" from the options displayed');
        await PageHelper.click(CommonPage.ribbonItems.viewItem);
    }

    static async editCostViaRibbon(item = CommonPage.record) {
        await this.selectRecordFromGrid(item);

        await this.refreshPageIfRibbonElementIsDisable(CommonPage.ribbonItems.editCost);

        await IssueItemPageHelper.validateContentOfItemTab();

        StepLogger.step('Select "Edit Cost" from the options displayed');
        await PageHelper.click(CommonPage.ribbonItems.editCost);

    }

    static async selectRecordAndClickItem(item = CommonPage.record) {
        await this.selectRecordFromGrid(item);

        await this.refreshPageIfRibbonElementIsDisable(CommonPage.ribbonItems.editCost);

    }

    static async clickEditCost() {
        StepLogger.step('Select "Edit Cost" from the options displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editCost);
        await PageHelper.click(CommonPage.ribbonItems.editCost);
    }

    static async clickEditResourcePlanViaRibbon(item = CommonPage.record) {
        await this.selectRecordFromGrid(item);
        StepLogger.step('Select "Edit Resource Plan" from the options displayed');

        await this.refreshPageIfRibbonElementIsDisable(CommonPage.ribbonItems.editResource);

        await PageHelper.click(CommonPage.ribbonItems.editResource);
        StepLogger.step('Select "Edit Resource Plan" from the options displayed');
    }

    static async resourceAnalyzerViaRibbon(item = CommonPage.record) {
        await this.selectRecordFromGrid(item);
        StepLogger.step('Select "Edit Resource Analyzer" from the options displayed');
        await PageHelper.click(CommonPage.ribbonItems.resourceAnalyzer);
        await WaitHelper.waitForElementToBeDisplayed(ResourceAnalyzerPage.display);
        await PageHelper.switchToDefaultContent();
        await CommonPageHelper.switchToContentFrame();
        await WaitHelper.staticWait(PageHelper.timeout.xs);
        await ResourceAnalyzerPageHelper.clickDisplayButton();
        const isPresent = await PageHelper.waitForAlertToBePresent();
        if (isPresent) {
            await PageHelper.acceptAlert();
        }
        StepLogger.step('Resource Analyzer Page is displayed');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.analyzerTab))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.resourceAnalyzer));
    }

    static async editTeam(item = CommonPage.record) {
        await this.selectRecordFromGrid(item);
        StepLogger.step('Select "Edit Resource Plan" from the options displayed');

        await this.refreshPageIfRibbonElementIsDisable(CommonPage.ribbonItems.editTeam);

        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        StepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));
    }

    static async clickOnEditPlan() {
        await browser.sleep(PageHelper.timeout.s);
        if (await CommonPage.editPlan.isPresent() !== true) {
            await ElementHelper.browserRefresh();
            await PageHelper.click(CommonPage.projectCheckbox);
            await browser.sleep(PageHelper.timeout.m);
            await PageHelper.click(CommonPage.ribbonTitles.items);
            await browser.sleep(PageHelper.timeout.s);
            if (await CommonPage.editPlan.isPresent() !== true) {
                await this.clickOnEditPlan();
            }
        }
        await PageHelper.click(CommonPage.editPlan);
    }

    static async deleteTask() {
        if (await ProjectItemPage.selectTaskName.isPresent() === true) {
            await WaitHelper.waitForElementToBePresent(ProjectItemPage.deleteTask);
            await ElementHelper.actionHoverOver(ProjectItemPage.selectTaskName);
            await PageHelper.click(ProjectItemPage.selectTaskName);
            await WaitHelper.waitForElementToBeClickable(ProjectItemPage.deleteTask);
            await ElementHelper.actionHoverOver(ProjectItemPage.deleteTask);
            await PageHelper.click(ProjectItemPage.deleteTask);
            // wait for alert to open
            await PageHelper.sleepForXSec(3000);
            await browser.switchTo().alert().accept();
            await ElementHelper.clickUsingJs(ProjectItemPage.save);
            // After save It need static wait(5 sec) and no element found which get change after save.
            await browser.sleep(PageHelper.timeout.s);

            if (await ProjectItemPage.selectTaskName.isPresent() === true) {
                await this.deleteTask();
            }
        }
    }

    static async viewOptionViaRibbon() {
        await this.selectRecordFromGrid();

        StepLogger.step('Select "View Item" from the options displayed');
        await PageHelper.click(CommonPage.ribbonItems.viewItem);
    }

    static getCheckboxByExactText(text: string, isContains = false) {
        const xpath = `//${HtmlHelper.tags.label}[${ComponentHelpers.getXPathFunctionForDot(text, isContains)}]
        //input[@type='checkbox']`;
        return element.all(By.xpath(xpath)).first();
    }

    static async selectRecordFromGrid(item = CommonPage.record) {
        StepLogger.stepId(2);
        StepLogger.step('Select the check box for record');
        await WaitHelper.waitForElementToBeDisplayed(item);
        await ElementHelper.actionHoverOver(item);
        await PageHelper.click(item);

        StepLogger.step('Click on ITEMS on ribbon');
        await PageHelper.click(CommonPage.ribbonTitles.items);
        const isClicked = await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editItem, PageHelper.timeout.s);
        if (!isClicked) {
            await PageHelper.click(CommonPage.ribbonTitles.items);
        }
    }

    static async selectTwoRecordFromGrid() {
        StepLogger.stepId(2);
        StepLogger.step('Select the check box for record');
        await WaitHelper.waitForElementToBePresent(CommonPage.getNthRecord());
        await ElementHelper.actionHoverOver(CommonPage.getNthRecord());
        await PageHelper.click(CommonPage.getNthRecord());

        await ElementHelper.actionHoverOver(CommonPage.getNthRecord(2));
        await PageHelper.click(CommonPage.getNthRecord(2));

        StepLogger.step('Click on ITEMS on ribbon');
        await PageHelper.click(CommonPage.ribbonTitles.items);
    }

    static async clickItemTab() {

        StepLogger.step('Click on ITEMS on ribbon');
        await PageHelper.click(CommonPage.ribbonTitles.items);
    }

    static async selectTwoRecordsFromGrid() {
        StepLogger.stepId(2);
        StepLogger.step('Select the check box for two records');
        StepLogger.subStep('Select the first record');
        await ElementHelper.actionHoverOver(CommonPage.getNthRecord());
        await PageHelper.click(CommonPage.getNthRecord());

        await browser.sleep(PageHelper.timeout.xs);
        StepLogger.subStep('Select the Second record');
        await ElementHelper.actionHoverOver(CommonPage.getNthRecord(3));
        await PageHelper.click(CommonPage.getNthRecord(2));
        await this.clickItemTab();
    }

    static async verifyProjectCenterDisplayed() {
        StepLogger.verification('Project Center opened ');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.pageHeaders.projects.projectsCenter);
        }

    static getSpanByText(text: string) {
        return element(By.xpath(`//span[${ComponentHelpers.getXPathFunctionForText(text)}]`));
    }

    static getElementByValue(text: string) {
        const xpath = `//*[@value="${text}"]`;
        return element(By.xpath(xpath));
    }

    static getATagByText(text: string, isContains: boolean) {
        const xpath = `//a[${ComponentHelpers.getXPathFunctionForDot(text, isContains)}]`;
        return element(By.xpath(xpath));
    }

    static getElementByRole(role: string) {
        const xpath = `[role="${role}"]`;
        return element(By.css(xpath));
    }

    static getSpanByTextInsideUnorderedListByRole(role: string, text: string) {
        return element(By.xpath(`//ul[normalize-space(@role)='${role}']//span[${ComponentHelpers.getXPathFunctionForText(text)}]`));
    }

    static getElementContainsId(id: string) {
        const xpath = `[id*="${id}"]`;
        return element(By.css(xpath));
    }

    static getVersionNumberByRowText(searchCellText: string, targetCellText: string, isContainsSearchCell = false) {
        const item = element(By.xpath(`//tr[td[${ComponentHelpers.getXPathFunctionForDot
        (searchCellText, isContainsSearchCell)}]]//td[normalize-space(.)= '${targetCellText}']`));
        return item;
    }

    static getElementContainsTitle(title: string) {
        return element(By.css(`[title*="${title}"]`));
    }

    static getAllElementsByType(type: string) {
        const xpath = `[type="${type}"]`;
        return element.all(By.css(xpath));
    }

    static getTeamRecordsByTeamId(id: string) {
        return element.all(By.xpath(`//*[@id="${id}"]//*[contains(@class,'GMCellPanel')]`));
    }

    static getTeamRecordsNameByTeamId(id: string) {
        return element.all(By.xpath(`//*[@id="${id}"]//a`));
    }

    static async enterTaskNameAndData(hours: string, title: string) {
        await WaitHelper.waitForElementToBePresent(CommonPage.ribbonItems.addTask);
        await ElementHelper.actionHoverOver(CommonPage.ribbonItems.addTask);
        await PageHelper.click(CommonPage.ribbonItems.addTask);
        await PageHelper.actionSendKeys(title);
        await WaitHelper.staticWait(PageHelper.timeout.xs);
        await ElementHelper.actionHoverOver(ProjectItemPageHelper.newTasksFields.duration);
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.duration);
        await PageHelper.actionSendKeys(hours);
        await WaitHelper.staticWait(PageHelper.timeout.xs);
    }

    static async actionTakenViaContextMenu(item: ElementFinder, actionItem: ElementFinder) {
        StepLogger.stepId(3);
        StepLogger.step('Mouse over the item created as per pre requisites that need to be viewed');
        await WaitHelper.waitForElementToBeDisplayed(item);
        await ElementHelper.actionHoverOver(item);

        StepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonPage.ellipse);

        StepLogger.step('Select "View Item" from the options displayed');
        await PageHelper.click(actionItem);
    }

    static async attachFile(attachmentFileButton: ElementFinder,
                            browseFileControl: ElementFinder,
    ) {
        StepLogger.stepId(6);
        StepLogger.step('Click on button to attach files');
        await PageHelper.click(attachmentFileButton);

        StepLogger.verification('The popup appears with Choose Files option');
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.attachFilePopupTitle,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        StepLogger.stepId(7);
        await CommonPageHelper.switchToContentFrame();
        const newFile = CommonPageHelper.uniqueDocumentFilePath;
        StepLogger.step('Click on "Choose Files" and select the file that needs to be attached');
        await PageHelper.uploadFile(browseFileControl, newFile.fullFilePath);

        StepLogger.verification('The File name appears under "Choose Files"');
        await expect(await ElementHelper.getValue(browseFileControl))
            .toContain(newFile.newFileName,
                ValidationsHelper.getFieldShouldHaveValueValidation(CommonPageConstants.attachFilePopupTitle, newFile.newFileName));

        StepLogger.step('Click on OK');
        await PageHelper.click(CommonPage.formButtons.okWithSmallK);
        return newFile;
    }

    static async uploadDocument(page: ElementFinder,
                                addWindowTitle: string,
                                pageName: string,
                                newFile = CommonPageHelper.uniqueImageFilePath) {
        StepLogger.stepId(3);
        StepLogger.step(`Click on the "+ New" button link displayed on top of "${pageName}" page`);
        await PageHelper.click(CommonPage.uploadButton);

        StepLogger.step('Waiting for page to open');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(addWindowTitle,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(addWindowTitle));

        StepLogger.step('Switch to frame');
        await CommonPageHelper.switchToContentFrame();

        StepLogger.stepId(4);
        StepLogger.step(`Click on "Choose Files" button in "${addWindowTitle}" pop up`);
        StepLogger.step(`Browse and select the file that need to be added as a ${pageName}`);
        await PageHelper.uploadFile(CommonPage.browseButton, newFile.fullFilePath);

        StepLogger.step('Click "OK" button');
        await PageHelper.click(CommonPage.formButtons.ok);

        await PageHelper.switchToDefaultContent();

        StepLogger.verification(`"${addWindowTitle}" window is closed`);
        await expect(await CommonPage.dialogTitle.isDisplayed())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(addWindowTitle));

        StepLogger.verification(`${pageName} page is displayed`);
        await expect(await PageHelper.isElementDisplayed(page))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(pageName));

        const fileNameWithoutExtension = newFile.newFileName.split('.')[0];
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(fileNameWithoutExtension, true)))
            .toBe(true,
                ValidationsHelper.getImageDisplayedValidation(newFile.newFileName));
    }

    static getMessageNoDataFound(classAttribute: string, text: string) {
        const xpath = element(By.xpath(`//div[${ComponentHelpers.getXPathFunctionForClass(classAttribute, true)} and
            ${ComponentHelpers.getXPathFunctionForDot(text)}]`));
        return xpath;
    }

    static async checkItemCreated(titleValue: string, label: ElementArrayFinder) {
        let itemFound = false, text;
        await WaitHelper.waitForElementToBeDisplayed(label.first());
        const size = await label.count();
        for (let index = 0; index < size && !itemFound; index++) {
            await ElementHelper.scrollToElement(label.get(index));
            text = await label.get(index).getText();
            if (text === titleValue) {
                itemFound = true;
            }
        }
        return itemFound;
    }

    static async switchToContentFrame() {
        StepLogger.step('Switch to content frame');
        await PageHelper.switchToiFrame(CommonPage.contentFrame);
        await browser.sleep(PageHelper.timeout.xs);
    }

    static getPublicView(text: string) {
        return element(By.xpath(ComponentHelpers.getElementByTagXpath(HtmlHelper.tags.li, text, false)));
    }

    static getCreateNewPublicViewOfDropDown(publicViewTitle: string) {
        return element(By.xpath(ComponentHelpers.getElementByTagXpath(HtmlHelper.tags.span, publicViewTitle, false)));
    }

    static async clickLhsSideBarMenuIcon(icon: ElementFinder) {
        StepLogger.step('Click on icon from the left navigation panel');
        await PageHelper.click(icon);
    }

    static async verifyPanelHeaderDisplayed(item: ElementFinder, itemName: string) {
        StepLogger.verification(`verify "${itemName}" header is displayed`);
        const panelHeadingDisplayed = await PageHelper.isElementDisplayed(item);
        await expect(panelHeadingDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            itemName));
    }

    static searchedItemList(text: string) {
        return AnchorHelper.getAnchorByTextInsideGridByClass(HtmlHelper.attributeValue.gmClassReadOnly, text);
    }

    static getCellText(column: string) {
        // it is a part of a object "getCell", object created below
        return element.all(By.xpath(`//td[contains(@class,'GMClassEdit GMFloat GMCell')][contains(@class,"${column}")]`)).first();
    }

    static getColumnElement(columnName: string) {
        return element(By.xpath(`${ComponentHelpers.getElementByTagXpath(HtmlHelper.tags.td, columnName, false)}`));
    }

    static getDropDownViewByText(titleView: string) {
        return element(By.xpath(`${ComponentHelpers.getElementByTagXpathWithTag(HtmlHelper.tags.a, `@${HtmlHelper.attributes.class}`,
            CommonPageConstants.dropDown, true)}${ComponentHelpers.getElementByTagXpath(HtmlHelper.tags.span, titleView, false)}`));
    }

    static getDivByText(text: string) {
        return element(By.xpath(`//div[${ComponentHelpers.getXPathFunctionForText(text)}]`));
    }

    static getElementAllByText(text: string, isContains = false) {
        return element.all(By.xpath(`//*[${ComponentHelpers.getXPathFunctionForText(text, isContains)}]`)).first();
    }

    static getDescendingColumnSelector(columnName: string) {
        return this.getColumnSelector(columnName, CommonPageConstants.classNames.descendingClass);
    }

    static getEditCostTab(value: string) {
        // its required it will not work without "ref", there is another tab as well only one thing different that is "ref"
        return element(By.xpath(`${CommonPage.costTab}/*[text()="${value}"]`));
    }

    static getActiveButtonByText(tab: string) {
        // it is a part of a object "costButton", object created below
        return element(By.xpath(`.//*[contains(@class,"element_active")]/*[text()="${tab}"]`));
    }

    static getAscendingColumnSelector(columnName: string) {
        return this.getColumnSelector(columnName, CommonPageConstants.classNames.ascendingClass);
    }

    static getColumnSelector(columnName: string, sortingClass: string) {
        return element(By.xpath(`//td[contains(@class, '${CommonPageConstants.classNames.headerTextClass}')` +
            ` and normalize-space(.)='${columnName}']` +
            `//following-sibling::td[contains(@class,'${CommonPageConstants.classNames.headerButtonClass}')][1]` +
            `//u[contains(@class,'${sortingClass}')]`));
    }

    static async fieldDisplayedValidation(targetElement: ElementFinder, name: string) {
        await expect(await PageHelper.isElementDisplayed(targetElement))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(name));
    }

    static async fieldNotDisplayedValidation(targetElement: ElementFinder, name: string) {
        await expect(await PageHelper.isElementDisplayed(targetElement))
            .toBe(false, ValidationsHelper.getNotDisplayedValidation(name));
    }

    static async notificationDisplayedValidation(targetElement: ElementFinder, name: string) {
        await expect(await PageHelper.isElementDisplayed(targetElement))
            .toBe(true, ValidationsHelper.getNotDisplayedValidation(name));
    }

    static async labelDisplayedValidation(targetElement: ElementFinder, name: string, expectedResult = true) {
        await WaitHelper.waitForElementToBeDisplayed(targetElement);
        await expect(await PageHelper.isElementDisplayed(targetElement)).toBe(expectedResult,
                ValidationsHelper.getLabelDisplayedValidation(name));
    }

    static async labelContainValidation(title: string) {
        await expect(await CommonPage.latestNotification.getText())
            .toContain(title, ValidationsHelper.getLabelDisplayedValidation(title));
    }

    static async windowShouldNotBeDisplayedValidation(name: string) {
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(name));
    }

    static async buttonDisplayedValidation(targetElement: ElementFinder, name: string) {
        await expect(await PageHelper.isElementDisplayed(targetElement, true))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(name));
    }

    static async pageDisplayedValidation(name: string) {
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect((await CommonPage.title.getText()).trim())
            .toBe(name,
                ValidationsHelper.getPageDisplayedValidation(name));
    }

    static async fieldShouldHaveValueValidation(projectName: string, labels: string) {
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(projectName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels, projectName));
    }

    static async textPresentValidation(targetElement: ElementFinder, text: string) {
        await WaitHelper.waitForElementToBeDisplayed(targetElement);
        await expect(await ElementHelper.getText(targetElement)).toBe(text,
                ValidationsHelper.getImageDisplayedValidation(text));
    }

    static async clickNewLink() {
        StepLogger.step('click on add new link ');
        await PageHelper.click(CommonPage.addNewLink);
    }

    static getApplyLink() {
        return element(By.css(`[value="${CommonPageConstants.ribbonLabels.apply}"]`));
    }

    static async clickApplyButton() {
        StepLogger.step('Click on Apply Button ');
        await ElementHelper.actionMouseMove(this.getApplyLink());
        await PageHelper.click(this.getApplyLink());
    }

    static async waitForApplyButtontoDisplayed() {
        await WaitHelper.waitForElementToBeClickable(this.getApplyLink());
    }

    static async resourceAnalyzerPopUp(item = CommonPage.record) {
        await this.selectRecordFromGrid(item);
        StepLogger.step('Select "Edit Resource Analyzer" from the options displayed');
        await PageHelper.click(CommonPage.ribbonItems.resourceAnalyzer);
        await WaitHelper.waitForElementToBeDisplayed(ResourceAnalyzerPage.display);
        await PageHelper.switchToDefaultContent();
        await CommonPageHelper.switchToContentFrame();
        await WaitHelper.staticWait(PageHelper.timeout.xs);
    }

    static async getRibbonIsDisable(targetElement: ElementFinder, attributeName: string) {
        return await ElementHelper.getAttributeValue(targetElement, attributeName);
    }

    static getOptimizerButton() {
        return CommonPageHelper.getRibbonButtonByText(CommonPageConstants.ribbonLabels.optimizer);
    }

    static async goToOptimizer() {
        StepLogger.step('Click on Optimizer button from the items tab.');
        await PageHelper.click(this.getOptimizerButton());
        // Takes time to load the iframe
        await browser.sleep(PageHelper.timeout.m);
        StepLogger.step('switch To First Content Frame');
        await CommonPageHelper.switchToFirstContentFrame();
    }

    static async gotoModeler() {
        StepLogger.step('Click on Modeler button from the items tab.');
        await PageHelper.click(CommonPage.modelerButton);
        // Takes time to load the iframe
        await browser.sleep(PageHelper.timeout.s);
        await CommonPageHelper.switchToFirstContentFrame();
    }

    static async selectProjectAndClickEllipsisButton(item = CommonPage.record) {
        await CommonPageHelper.selectRecordFromGrid(item);

        await ElementHelper.actionMouseMove(item);

        await CommonPageHelper.clickIconEllipsisHorizontal();
    }

    static async verifyItemDisabled(targetElement: ElementFinder) {
        await ExpectationHelper.verifyAttributeValue(targetElement, 'aria-disabled', 'true', );
    }

    static async clickIconEllipsisHorizontal() {
        StepLogger.step('Click on Ellipsis Horizontal');
        await PageHelper.click(CommonPage.iconEllipsisHorizontal);
    }

    static async optimizerViaRibbon() {
        await this.selectTwoRecordFromGrid();

        StepLogger.step('Select "Optimizer" from the options displayed');
        await PageHelper.click(CommonPage.ribbonItems.optimizer);
    }

    static async verifyNavigation() {
        StepLogger.verification('Optimizer page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.optimizer)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.optimizer));

    }

    static async verifyVariousOptionsOnContextMenu() {
        StepLogger.verification('On Context Menu Edit Cost is present');
        await CommonPageHelper.fieldDisplayedValidation
        (CommonPage.contextMenuOptions.editCosts, CommonPageConstants.contextMenuOptions.editCosts);

        StepLogger.verification('On Context Menu comments is present');
        await CommonPageHelper.fieldDisplayedValidation
        (CommonPage.contextMenuOptions.comments, CommonPageConstants.contextMenuOptions.comments);

        StepLogger.verification('On Context Menu deleteItem is present');
        await CommonPageHelper.fieldDisplayedValidation
        (CommonPage.contextMenuOptions.deleteItem, CommonPageConstants.contextMenuOptions.deleteItem);

        StepLogger.verification('On Context Menu editPlan is present');
        await CommonPageHelper.fieldDisplayedValidation
        (CommonPage.contextMenuOptions.editPlan, CommonPageConstants.contextMenuOptions.editPlan);
    }

    static async filterColumnByText(elem: ElementFinder, textToSearch: string) {
        StepLogger.step('Enter text to filter in column');
        await browser.actions().mouseMove(elem, {x: -5, y: -5}).perform();
        await browser.actions().click(elem).perform();
        await browser.actions().doubleClick(elem).perform();
        // Takes time to enable input field
        await browser.sleep(PageHelper.timeout.xs);
        await TextboxHelper.sendKeys(CommonPage.gridDetails.editField, textToSearch, true);
    }

    static async navigateToProjectCenter() {
        await this.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
    }

    static async verifyContextMenuDisplayed() {
        await ExpectationHelper.verifyDisplayedStatus(
            CommonPage.contextMenuOptions.editPlan,
            CommonPageConstants.contextMenuLabel,
        );
    }

    static async clickEditResourcePlan() {
        StepLogger.step('Click on Edit Resource Plan');
        await CommonPageHelper.getContextMenuItemByText(CommonPageConstants.contextMenuOptions.editResource);
    }
}
