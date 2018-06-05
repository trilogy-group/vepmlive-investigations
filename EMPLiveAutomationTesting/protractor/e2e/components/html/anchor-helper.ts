import {By, element} from 'protractor';
import {ComponentHelpers} from '../devfactory/component-helpers/component-helpers';

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
}
