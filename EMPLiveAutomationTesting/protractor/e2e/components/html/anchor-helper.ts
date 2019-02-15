import {By, element} from 'protractor';
import {ComponentHelpers} from '../devfactory/component-helpers/component-helpers';
import {AnchorComponentSelectors} from '../component-types/anchor-component/anchor-component-selectors';
import {HtmlHelper} from '../misc-utils/html-helper';

export class AnchorHelper {

    static getElementsByTextXPathInsideGrid(text: string, isContains = false) {
        return `//td[contains(@class,'GMClassReadOnly') and ${ComponentHelpers.getXPathFunctionForDot(
            text,
            isContains
        )}]`;
    }

    static getElementByTextInsideGrid(text: string, isContains = false) {
        const xpath = this.getElementsByTextXPathInsideGrid(text, isContains);
        return element(By.xpath(`(${xpath})`));
    }

    static getElementsByTextInsideGrid(text: string, isContains = false) {
        const xpath = this.getElementsByTextXPathInsideGrid(text, isContains);
        return element.all(By.xpath(xpath));
    }

    static getAnchorInsideGridByClass(text: string) {
        return element(By.xpath(`//td[${ComponentHelpers.getXPathFunctionForClass(text, true)}]//a`));
    }

    static getAnchorByTextInsideGridByClass(classAttribute: string, text: string) {
        const xpath = `//td[${ComponentHelpers.getXPathFunctionForClass(classAttribute, true)}]/a[
            ${ComponentHelpers.getXPathFunctionForDot(text)}]`;
        return element(By.xpath(xpath));
    }

    static getAllAnchorsForText(
        text: string,
        isContains = false) {
        return element.all(By.xpath(AnchorComponentSelectors.getAnchorForTextXpath(
            text,
            isContains)));
    }

    static getAnchorByText(text: string) {
        return this.getAllAnchorsForText(text, false).first();
    }

    static getAnchorContainsText(text: string) {
        return this.getAllAnchorsForText(text, true).first();
    }

    static getItemById(idAttributeValue: string, isContains = false, tag = '*') {
        const xpath = `//${tag}[${ComponentHelpers.getXPathFunctionForStringComparison(
            idAttributeValue, `@${HtmlHelper.attributes.id}`, isContains)}]`;
        return element(By.xpath(xpath));
    }

    static getAnchorById(id: string, idIsContains = false) {
        return this.getItemById(id, idIsContains, HtmlHelper.tags.a);
    }
}
