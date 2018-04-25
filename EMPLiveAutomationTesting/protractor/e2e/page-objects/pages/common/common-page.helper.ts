import {By, element} from 'protractor';
import {ComponentHelpers} from '../../../components/devfactory/component-helpers/component-helpers';
import {HtmlHelper} from '../../../components/misc-utils/html-helper';
import {CommonItemPage} from '../create-new-page/new-item/common-item/common-item.po';
import {PageHelper} from '../../../components/html/page-helper';

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
        return this.getInputByLabel('*[contains(@class,"autocomplete")][1]', title);
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
        return element(By.css(`[description='${description}']`));
    }

    static getRowForTableData(columnText: string[]) {
        const columnXpaths: string[] = [];
        for (let index = 0; index < columnText.length; index++) {
            columnXpaths.push(`td[normalize-space(.)='${columnText[index]}']`);
        }
        return element(By.xpath(`//tr[${columnXpaths.join('and')}]`));
    }
}
