import {By, element} from 'protractor';
import {ComponentHelpers} from '../devfactory/component-helpers/component-helpers';

export class AnchorHelper {

    public static getElementsByTextXPathInsideGrid(text: string, isContains = false) {
        const xpath = `//td[contains(@class,'GMClassReadOnly') and ${ComponentHelpers.getXPathFunctionForDot(
            text,
            isContains
        )}]`;
        return xpath;
    }

    public static getElementByTextXPathInsideGrid(text: string, isContains = false) {
        const xpath = this.getElementsByTextXPathInsideGridXpath(text, isContains);
        return element(By.xpath(`(${xpath})[1]`));
    }

    public static getElementsByTextXPathInsideGrid(text: string, isContains = false) {
        const xpath = this.getElementsByTextXPathInsideGridXpath(text, isContains);
        return element.all(By.xpath(xpath));
    }
}
