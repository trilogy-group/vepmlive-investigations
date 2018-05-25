import {browser, By, element, ElementFinder} from 'protractor';
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

const fs = require('fs');

export class CommonPageHelper {

    static get uniqueImageFilePath() {
        const imageFile = CommonPageConstants.imageFile;
        const newFileName = `${imageFile.jpegFileName}_${PageHelper.getUniqueId()}`.toLowerCase();
        const dir = CommonPageConstants.filesDirectoryName;
        const fullFilePath = `${__dirname}\\${dir}\\${newFileName}${imageFile.fileType}`;

        fs.createReadStream(imageFile.filePath())
            .pipe(fs.createWriteStream(fullFilePath));

        return {fullFilePath, newFileName};
    }

    static get uniqueDocumentFilePath() {
        const documentFile = CommonPageConstants.documentFile;
        const newFileName = `${documentFile.documentFileName}_${PageHelper.getUniqueId()}`.toLowerCase();
        const dir = CommonPageConstants.filesDirectoryName;
        const fullFilePath = `${__dirname}\\${dir}\\${newFileName}${documentFile.fileType}`;

        fs.createReadStream(documentFile.filePath())
            .pipe(fs.createWriteStream(fullFilePath));

        return {fullFilePath, newFileName};
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

    static getRibbonButtonByText(title: string) {
        return element(By.xpath(`//span[contains(@class,'ms-cui-ctl-largelabel') and (${ComponentHelpers.
        getXPathFunctionForDot(title)} or ${ComponentHelpers.getXPathFunctionForText(title)})]`));
    }

    static getDisabledRibbonButtonById(id: string) {
        return element(By.xpath(`//*[contains(@class,"ms-cui-disabled")][@aria-disabled="true"][contains(@id,'${id}')]`));
    }

    static getRibbonSmallButtonByTitle(title: string) {
        return element(By.xpath(`//a[contains(@class,'ms-cui-ctl') and normalize-space(@title)='${title}']`));
    }

    static getRibbonMediumButtonByTitle(title: string) {
        return element(By.xpath(`//span[contains(@class,'ms-cui-ctl-mediumlabel') and ${ComponentHelpers.getXPathFunctionForDot(title)}]`));
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
        return PageHelper.switchToFrame(CommonPage.contentFrame);
    }

    static getAutoCompleteItemByDescription(description: string) {
        return element(By.css(`[description="${description}"]`));
    }

    static getRowForTableData(columnText: string[]) {
        const columnXpaths: string[] = [];
        for (let index = 0; index < columnText.length; index++) {
            columnXpaths.push(`td[normalize-space(.)='${columnText[index]}']`);
        }
        const xpath = `//tr[contains(@class,'GMClassSelected')][${columnXpaths.join(CommonPageConstants.and)}]`;
        return element(By.xpath(xpath));
    }

    static getElementByTitle(title: string) {
        const xpath = `[title="${title}"]`;
        return element(By.css(xpath));
    }

    static getPageHeaderByTitle(title: string, isContains= false) {
        const xpath = `//*[@id='${CommonPage.titleId}']//*[${ComponentHelpers.getXPathFunctionForDot(title, isContains)}]`;
        return element(By.xpath(xpath));
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
                                                   stepLogger: StepLogger) {
        stepLogger.step('Select "Navigation" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.navigation);
        await CommonPageHelper.navigateToSubPage(pageName, linkOfThePage, pageHeader, stepLogger);
    }

    static async navigateToItemPageUnderMyWorkplace(linkOfThePage: ElementFinder,
                                                    pageHeader: ElementFinder,
                                                    pageName: string,
                                                    stepLogger: StepLogger) {
        stepLogger.step('Select "My Workplace" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.myWorkplace);
        stepLogger.stepId(2);
        await CommonPageHelper.navigateToSubPage(pageName, linkOfThePage, pageHeader, stepLogger);
    }

    static async navigateToSubPage(pageName: string, linkOfThePage: ElementFinder, pageHeader: ElementFinder, stepLogger: StepLogger) {
        stepLogger.step(`Select Project -> ${pageName} from the left side menu options displayed`);
        await PageHelper.click(linkOfThePage);

        stepLogger.verification(`${pageName} page is displayed`);
        await expect(await PageHelper.isElementDisplayed(pageHeader))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(pageName));
    }

    static getColumnHeaderByText(text: string) {
        return element(By.xpath(`//td[contains(@class,'GMHeaderText') and ${ComponentHelpers.getXPathFunctionForDot(text)}]`));
    }

    static async searchItemByTitle(titleValue: string, columnName: string, stepLogger: StepLogger) {

        // Give it sometime to create, Created Item is not reflecting immediately. requires time in processing
        // and search option also requires some time to settle down
        await browser.sleep(PageHelper.timeout.m);

        stepLogger.step('Click on search');
        await PageHelper.click(CommonPage.actionMenuIcons.search);

        stepLogger.step('Select column name as Title');
        await PageHelper.sendKeysToInputField(CommonPage.searchControls.column, columnName);

        stepLogger.step('Enter search term');
        await TextboxHelper.sendKeys(CommonPage.searchControls.text, titleValue, true);
    }

    static async showColumns(columnNames: string[]) {
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ganttGrid);
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
            await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.selectColumnPanel);
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
        return element(By.css(`#RibbonContainer li[title="${title}"]`));
    }

    static async editOptionViaRibbon(stepLogger: StepLogger) {
        await this.selectRecordFromGrid(stepLogger);

        stepLogger.step('Select "Edit Item" from the options displayed');
        await PageHelper.click(CommonPage.ribbonItems.editItem);
    }

    static async viewOptionViaRibbon(stepLogger: StepLogger) {
        await this.selectRecordFromGrid(stepLogger);

        stepLogger.step('Select "View Item" from the options displayed');
        await PageHelper.click(CommonPage.ribbonItems.viewItem);
    }

    static getCheckboxByExactText(text: string, isContains = false) {
        const xpath = `//${HtmlHelper.tags.label}[${ComponentHelpers.getXPathFunctionForDot(text, isContains)}]
        //input[@type='checkbox']`;
        return element.all(By.xpath(xpath)).first();
    }

    static async selectRecordFromGrid(stepLogger: StepLogger) {
        stepLogger.stepId(2);
        stepLogger.step('Select the check box for project created');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.record);
        await PageHelper.click(CommonPage.record);

        stepLogger.step('Click on ITEMS on ribbon');
        await PageHelper.click(CommonPage.ribbonTitles.items);
    }

    static getSpanByText(text: string) {
        return element(By.xpath(`//span[${ComponentHelpers.getXPathFunctionForText(text)}]`));
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

    public static get getTodayInMMDDYYYY(){
        const currentDate = this.getCurrentMonth + '/' + this.getPreviousDate + '/' + this.getCurrentYear;
        return currentDate;
    }

    public static get getYesterdayInMMDDYYYY(){
        const tomorrowDate = this.getCurrentMonth + '/' + this.getCurrentDate + '/' + this.getCurrentYear;
        return tomorrowDate;
    }

    static async actionTakenViaContextMenu(stepLogger: StepLogger, item: ElementFinder, actionItem: ElementFinder) {
        stepLogger.stepId(3);
        stepLogger.step('Mouse over the item created as per pre requisites that need to be viewed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(item);
        await ElementHelper.actionHoverOver(item);

        stepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonPage.ellipse);

        stepLogger.step('Select "View Item" from the options displayed');
        await PageHelper.click(actionItem);
    }
}
