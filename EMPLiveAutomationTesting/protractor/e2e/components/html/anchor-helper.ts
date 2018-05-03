import {By, element} from 'protractor';
import {ComponentHelpers} from '../devfactory/component-helpers/component-helpers';

export class AnchorHelper {

    static getElementsByTextXPathInsideGrid(text: string, isContains = false) {
        const xpath = `//td[contains(@class,'GMClassReadOnly') and ${ComponentHelpers.getXPathFunctionForDot(
            text,
            isContains
        )}]`;
        return xpath;
    }

    static getElementByTextInsideGrid(text: string, isContains = false) {
        const xpath = this.getElementsByTextXPathInsideGrid(text, isContains);
        return element(By.xpath(`(${xpath})[1]`));
    }

    static getElementsByTextInsideGrid(text: string, isContains = false) {
        const xpath = this.getElementsByTextXPathInsideGrid(text, isContains);
        return element.all(By.xpath(xpath));
    }
}
