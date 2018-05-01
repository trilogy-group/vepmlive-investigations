import {By, element, ElementFinder} from 'protractor';
import {ComponentHelpers} from '../../../components/devfactory/component-helpers/component-helpers';
import {HtmlHelper} from '../../../components/misc-utils/html-helper';
import {PageHelper} from '../../../components/html/page-helper';
import {CommonPageConstants} from './common-page.constants';
import {CommonItemPage} from '../items-page/common-item/common-item.po';
import {WaitHelper} from '../../../components/html/wait-helper';
import {ElementHelper} from '../../../components/html/element-helper';
import {CommonPage} from '../common-page/common.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {CommonPageHelper} from '../common-page/common-page.helper';
import {CheckboxHelper} from '../../../components/html/checkbox-helper';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {TextboxHelper} from '../../../components/html/textbox-helper';
import {CommonPage} from './common.po';

export class CommonPageHelper {
    static getSidebarLinkByTextUnderList(title: string) {
        return this.getElementUnderSections(HtmlHelper.tags.li, title);
    }

    static getElementUnderSections(elementType: string, title: string) {
        const cls = 'contains(@class,"epm-nav-node")';
        const textSelector = ComponentHelpers.getXPathFunctionForDot(title);
        const xpath = `//${elementType}[${cls}]//a[${textSelector}]`;
        return element(By.xpath(xpath));
    }

    static getSidebarLinkByTextUnderTableData(title: string) {
        return this.getElementUnderSections(HtmlHelper.tags.td, title);
    }

    static getRibbonButtonByText(title: string) {
        return element(By.xpath(`//span[contains(@class,'ms-cui-ctl-largelabel') and ${ComponentHelpers.getXPathFunctionForDot(title)}]`));
    }

    static getTextBoxByLabel(title: string) {
        return this.getInputByLabel(HtmlHelper.tags.input, title);
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
        const xpath = `//table[contains(@class,"ms-formtable")]//td[normalize-space(.)='${title}']//parent::tr//${type}`;
        return element(By.xpath(xpath));
    }

    static async switchToFirstContentFrame() {
        return PageHelper.switchToFrame(CommonItemPage.contentFrame);
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

    static async editItemViaContextMenu(stepLogger: StepLogger) {
        stepLogger.stepId(3);
        stepLogger.step('Mouse over the Portfolio created as per pre requisites that need to be edited');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.record);
        await ElementHelper.actionHoverOver(CommonPage.record);

        stepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonPage.ellipse);

        stepLogger.step('Select "Edit Item" from the options displayed');
        await PageHelper.click(CommonPage.contextMenuOptions.editItem);
    }

    static getPageHeaderByTitle(title: string) {
        const xpath = `//*[@id='${CommonItemPage.titleId}']//a[${ComponentHelpers.getXPathFunctionForDot(title)}]`;
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

    public static getCheckboxByExactText(text: string, isContains = false) {
        const xpath = `//${HtmlHelper.tags.label}[${ComponentHelpers.getXPathFunctionForDot(text, isContains)}]
        //input[@type='checkbox']`;
        return element.all(By.xpath(xpath)).first();
    }
}
