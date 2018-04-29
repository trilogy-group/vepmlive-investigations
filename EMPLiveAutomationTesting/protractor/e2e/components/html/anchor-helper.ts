import {By, element} from 'protractor';
import {ComponentHelpers} from '../devfactory/component-helpers/component-helpers';

export class AnchorHelper {
    public static getElementByExactTextXPath(text: string, isContains = false) {
        const xpath = `//td[contains(@class,'GMClassReadOnly')]//a[${ComponentHelpers.getXPathFunctionForDot(
            text,
            isContains
        )}]`;
        return element.all(By.xpath(xpath)).first();
    }
}
