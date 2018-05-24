import {ButtonHelperFactory} from '@aurea/protractor-automation-helper';
import {ComponentHelpers} from '../devfactory/component-helpers/component-helpers';
import {HtmlHelper} from '../misc-utils/html-helper';
import {By, element} from 'protractor';

export class ButtonHelper extends ButtonHelperFactory {
    static getInputButtonByExactTextUnderTable(text: string, isContains = false) {
        const xpath = `(//td//input[${ComponentHelpers.getXPathFunctionForStringComparison(
            text,
            `@${HtmlHelper.attributes.value}`,
            isContains
        )}])[1]`;
        return element(By.xpath(xpath));
    }

    static getInputButtonsByExactText(text: string, isContains = false) {
        const xpath = `//input[${ComponentHelpers.getXPathFunctionForStringComparison(
            text,
            `@${HtmlHelper.attributes.value}`,
            isContains
        )}]`;
        return element.all(By.xpath(xpath));
    }
}
