import {ButtonHelperFactory} from '@aurea/protractor-automation-helper';
import {ComponentHelpers} from '../devfactory/component-helpers/component-helpers';
import {HtmlHelper} from '../misc-utils/html-helper';
import {By, element} from 'protractor';

export class ButtonHelper extends ButtonHelperFactory {
    static getInputButtonByTextUnderTable(text: string, isContains = false) {
        const xpath = `(//td${this.getInputButtonsByTextXPath(text, isContains)})[1]`;
        return element(By.xpath(xpath));
    }

    static getInputButtonsByText(text: string, isContains = false) {
        const xpath = this.getInputButtonsByTextXPath(text, isContains);
        return element.all(By.xpath(xpath));
    }

    static getInputButtonsByTextXPath(text: string, isContains = false) {
        return `//input[${ComponentHelpers.getXPathFunctionForStringComparison(
            text,
            `@${HtmlHelper.attributes.value}`,
            isContains
        )}]`;
    }

    static getButtonByText(text: string, isContains = false) {
        return element(By.xpath(ButtonHelper.getButtonByExactTextXPath(text,isContains)));
      }
}
