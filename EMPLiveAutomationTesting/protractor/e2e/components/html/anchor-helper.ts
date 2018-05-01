import {By, element} from 'protractor';
import {ComponentHelpers} from '../devfactory/component-helpers/component-helpers';

export class AnchorHelper {
    public static getElementByTextXPathInsideGrid(text: string, isContains = false) {
        return this.getElementsByTextXPathInsideGrid(text, isContains).first();
    }

    public static getElementsByTextXPathInsideGrid(text: string, isContains = false) {
        const xpath = `//td[contains(@class,'GMClassReadOnly') and ${ComponentHelpers.getXPathFunctionForDot(
            text,
            isContains
        )}]`;
        return element.all(By.xpath(xpath));
    }
}
