import {browser, By, element, ElementFinder, ElementArrayFinder} from 'protractor';
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
import {ResourceAnalyzerPageHelper} from '../../resource-analyzer-page/resource-analyzer-page.helper';
import {ResourceAnalyzerPage} from '../../resource-analyzer-page/resource-analyzer-page.po';

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

    static getRibbonButtonById(id: string) {
        return element(By.xpath(`//*[contains(@id,'${id}')]`));
    }

    public static get getTodayInMMDDYYYY() {
        const currentDate = this.getCurrentMonth + '/' + this.getPreviousDate + '/' + this.getCurrentYear;
        return currentDate;
    }
    static getElementByText(text: string, isContains = false) {
        return element(By.xpath(`//*[${ComponentHelpers.getXPathFunctionForText(text, isContains)}]`));
    }
    public static get getYesterdayInMMDDYYYY() {
        const tomorrowDate = this.getCurrentMonth + '/' + this.getCurrentDate + '/' + this.getCurrentYear;
        return tomorrowDate;
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

    static getRibbonButtonByText(title: string,  isContains = false ) {
        return element(By.xpath(`//span[contains(@class,'ms-cui-ctl-largelabel')
         and (${ComponentHelpers.getXPathFunctionForDot(title,  isContains )})]//parent::a`));
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

    static getPageHeaderByTitle(title: string, isContains = false) {
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
    static async searchByTitle(linkOfThePage: ElementFinder,
                               pageHeader: ElementFinder,
                               pageName: string,
                               stepLogger: StepLogger, titleValue: string , columnName: string ) {
        await this.navigateToItemPageUnderNavigation(
            linkOfThePage,
            pageHeader,
            pageName,
            stepLogger);
        await this.searchItemByTitle(titleValue, columnName, stepLogger);
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

    static async searchItemByTitle(titleValue: string, columnName: string, stepLogger: StepLogger, verifySearchControl = false) {

        // Give it sometime to create, Created Item is not reflecting immediately. requires time in processing
        // and search option also requires some time to settle down
        await browser.sleep(PageHelper.timeout.m);

        stepLogger.step('Click on search');
        await PageHelper.click(CommonPage.actionMenuIcons.search);

        if (verifySearchControl === true) {
            stepLogger.verification('Search Component dropdown is available');
            await expect(await PageHelper.isElementDisplayed(CommonPage.searchControls.column))
                .toBe(true, ValidationsHelper.getDisplayedValidation(CommonPageConstants.searchControl.searchComponentDropdown));
            stepLogger.verification('Search Operator dropdown is available');
            await expect(await PageHelper.isElementDisplayed(CommonPage.searchControls.type))
                .toBe(true, ValidationsHelper.getDisplayedValidation(CommonPageConstants.searchControl.searchOperatorDropdown));
            stepLogger.verification('Search field is available');
            await expect(await PageHelper.isElementDisplayed(CommonPage.searchControls.text))
                .toBe(true, ValidationsHelper.getDisplayedValidation(CommonPageConstants.searchControl.searchField));
        }
        stepLogger.step('Select column name as Title');
        await PageHelper.sendKeysToInputField(CommonPage.searchControls.column, columnName);

        stepLogger.step('Enter search title');
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

    static get save() {
        return element(By.css('[id*="SaveButton"]'));
    }

    static getMenuItemFromRibbonContainer(title: string) {
        return element(By.css(`#RibbonContainer li[title="${title}"]`));
    }

    static async editOptionViaRibbon(stepLogger: StepLogger, item = CommonPage.record) {
        await this.selectRecordFromGrid(stepLogger, item);

        stepLogger.step('Select "Edit Item" from the options displayed');
        await PageHelper.click(CommonPage.ribbonItems.editItem);
    }
    static async clickEditResourcePlanViaRibbon(stepLogger: StepLogger, item = CommonPage.record) {
        await this.selectRecordFromGrid(stepLogger, item);
        stepLogger.step('Select "Edit Resource Plan" from the options displayed');

        await PageHelper.click(CommonPage.ribbonItems.editResource);
        stepLogger.step('Select "Edit Resource Plan" from the options displayed');
    }
    static async resourceAnalyzerViaRibbon(stepLogger: StepLogger, item = CommonPage.record) {
        await this.selectRecordFromGrid(stepLogger, item);
        stepLogger.step('Select "Edit Resource Analyzer" from the options displayed');
        await PageHelper.click(CommonPage.ribbonItems.resourceAnalyzer);
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(ResourceAnalyzerPage.display);
        await PageHelper.switchToDefaultContent();
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.xs);
        await ResourceAnalyzerPageHelper.clickDisplayButton(stepLogger);
        await PageHelper.acceptAlert();
        stepLogger.step('Resource Analyzer Page is displayed');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.analyzerTab))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.resourceAnalyzer));
    }
    static async editTeam(stepLogger: StepLogger, item = CommonPage.record) {
        await this.selectRecordFromGrid(stepLogger, item);
        stepLogger.step('Select "Edit Resource Plan" from the options displayed');
        await PageHelper.click(CommonPage.ribbonItems.editTeam);
        stepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
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
            if (await  CommonPage.editPlan.isPresent() !== true) {
                await this.clickOnEditPlan();
            }
        }
        await PageHelper.click(CommonPage.editPlan);
    }

    static async deleteTask() {
        if (await ProjectItemPage.selectTaskName.isPresent() === true) {
            await PageHelper.click(ProjectItemPage.selectTaskName);
            await PageHelper.click(ProjectItemPage.deleteTask);
            await browser.switchTo().alert().accept();
            await ElementHelper.clickUsingJs(ProjectItemPage.save);
            // After save It need static wait(5 sec) and no element found which get change after save.
            await browser.sleep(PageHelper.timeout.s);

            if (await ProjectItemPage.selectTaskName.isPresent() === true) {
                await this.deleteTask();
            }
        }
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

    static async selectRecordFromGrid(stepLogger: StepLogger, item = CommonPage.record) {
        stepLogger.stepId(2);
        stepLogger.step('Select the check box for record');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(item);
        await PageHelper.click(item);

        stepLogger.step('Click on ITEMS on ribbon');
        await PageHelper.click(CommonPage.ribbonTitles.items);
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
        await PageHelper.click(CommonPage.ribbonItems.addTask);
        await PageHelper.actionSendKeys(title);
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.duration);
        await PageHelper.actionSendKeys(hours);
    }

    static async actionTakenViaContextMenu(item: ElementFinder, actionItem: ElementFinder, stepLogger: StepLogger) {
        stepLogger.stepId(3);
        stepLogger.step('Mouse over the item created as per pre requisites that need to be viewed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(item);
        await ElementHelper.actionHoverOver(item);

        stepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonPage.ellipse);

        stepLogger.step('Select "View Item" from the options displayed');
        await PageHelper.click(actionItem);
    }

    static async attachFile(attachmentFileButton: ElementFinder,
                            browseFileControl: ElementFinder,
                            stepLogger: StepLogger) {
        stepLogger.stepId(6);
        stepLogger.step('Click on button to attach files');
        await PageHelper.click(attachmentFileButton);

        stepLogger.verification('The popup appears with Choose Files option');
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.attachFilePopupTitle,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        stepLogger.stepId(7);
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        const newFile = CommonPageHelper.uniqueDocumentFilePath;
        stepLogger.step('Click on "Choose Files" and select the file that needs to be attached');
        await PageHelper.uploadFile(browseFileControl, newFile.fullFilePath);

        stepLogger.verification('The File name appears under "Choose Files"');
        await expect(await ElementHelper.getValue(browseFileControl))
            .toContain(newFile.newFileName,
                ValidationsHelper.getFieldShouldHaveValueValidation(CommonPageConstants.attachFilePopupTitle, newFile.newFileName));

        stepLogger.step('Click on OK');
        await PageHelper.click(CommonPage.formButtons.okWithSmallK);

        await PageHelper.switchToDefaultContent();

        return newFile;
    }

    static async uploadDocument(page: ElementFinder,
                                addWindowTitle: string,
                                pageName: string,
                                stepLogger: StepLogger,
                                newFile = CommonPageHelper.uniqueImageFilePath) {
        stepLogger.stepId(3);
        stepLogger.step(`Click on the "+ New" button link displayed on top of "${pageName}" page`);
        await PageHelper.click(CommonPage.uploadButton);

        stepLogger.step('Waiting for page to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(addWindowTitle,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(addWindowTitle));

        stepLogger.step('Switch to frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        stepLogger.stepId(4);
        stepLogger.step(`Click on "Choose Files" button in "${addWindowTitle}" pop up`);
        stepLogger.step(`Browse and select the file that need to be added as a ${pageName}`);
        await PageHelper.uploadFile(CommonPage.browseButton, newFile.fullFilePath);

        stepLogger.step('Click "OK" button');
        await PageHelper.click(CommonPage.formButtons.ok);

        await PageHelper.switchToDefaultContent();

        stepLogger.verification(`"${addWindowTitle}" window is closed`);
        await expect(await CommonPage.dialogTitle.isDisplayed())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(addWindowTitle));

        stepLogger.verification(`${pageName} page is displayed`);
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
        await WaitHelper.getInstance().waitForElementToBeDisplayed(label.first());
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

    static async switchToContentFrame(stepLogger: StepLogger) {
        stepLogger.step('Switch to content frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        // Avoiding - Element is not able to click at point (-9553, -9859)
        await browser.sleep(PageHelper.timeout.m);
    }

    static getPublicView(text: string) {
        return element(By.xpath(ComponentHelpers.getElementByTagXpath(HtmlHelper.tags.li, text, false)));
    }

    static getCreateNewPublicViewOfDropDown(publicViewTitle: string) {
        return element(By.xpath(ComponentHelpers.getElementByTagXpath(HtmlHelper.tags.li, publicViewTitle, false)));
    }
    static async clickLhsSideBarMenuIcon(icon: ElementFinder, stepLogger: StepLogger) {
        stepLogger.step('Click on icon from the left navigation panel');
        await PageHelper.click(icon);
    }

    static async verifyPanelHeaderDisplayed(item: ElementFinder, itemName: string, stepLogger: StepLogger) {
        stepLogger.verification(`verify "${itemName}" header is displayed`);
        const panelHeadingDisplayed = await PageHelper.isElementDisplayed(item);
        await expect(panelHeadingDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            itemName));
    }
    static searchedItemList(text: string) {
        return AnchorHelper.getAnchorByTextInsideGridByClass(HtmlHelper.attributeValue.gmClassReadOnly, text);
    }

    static getCellText(column: string) {
        // it is a part of a object "getCell", object created below
        return element(By.xpath(`.//*[contains(@onmousemove,"I24")]/td[contains(@class,"${column}")]`));
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
  static async fieldDisplayedValidation(targetElement: ElementFinder , name: string) {
        await expect(await PageHelper.isElementDisplayed(targetElement))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(name));
    }
    static async fieldNotDisplayedValidation(targetElement: ElementFinder , name: string) {
        await expect(await PageHelper.isElementDisplayed(targetElement))
            .toBe(false, ValidationsHelper.getNotDisplayedValidation(name));
    }
    static async notificationDisplayedValidation(targetElement: ElementFinder , name: string) {
        await expect(await PageHelper.isElementDisplayed(targetElement))
            .toBe(true, ValidationsHelper.getNotDisplayedValidation(name));
    }
    static async labelDisplayedValidation(targetElement: ElementFinder , name: string) {
        await expect(await PageHelper.isElementPresent(targetElement))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(name));
    }
    static async   labelContainValidation( title: string) {
        await expect(await CommonPage.latestNotification.getText())
            .toContain(title, ValidationsHelper.getLabelDisplayedValidation(title));
    }
    static async windowShouldNotBeDisplayedValidation( name: string) {
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(name));
    }
    static async buttonDisplayedValidation(targetElement: ElementFinder , name: string ) {
        await expect(await PageHelper.isElementDisplayed(targetElement, true))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(name));
    }
    static async pageDisplayedValidation( name: string) {
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect((await CommonPage.title.getText()).trim())
            .toBe(name,
                ValidationsHelper.getPageDisplayedValidation(name));
    }
    static async fieldShouldHaveValueValidation( projectName: string , labels: string ) {
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(projectName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels, projectName));
    }
    static async clickNewLink( stepLogger: StepLogger) {
        stepLogger.step('click on add new link ');
        await PageHelper.click(CommonPage.addNewLink);
    }
    static getApplyLink() {
        return element(By.css(`[value="${CommonPageConstants.ribbonLabels.apply}"]`));
    }
    static async clickApplyButton(stepLogger: StepLogger) {
        stepLogger.step('Click on Apply Button ');
        await ElementHelper.actionMouseMove(this.getApplyLink());
        await PageHelper.click(this.getApplyLink());
       }
    static async waitForApplyButtontoDisplayed() {
        await  WaitHelper.getInstance().waitForElementToBeClickable(this.getApplyLink());
    }
   }
