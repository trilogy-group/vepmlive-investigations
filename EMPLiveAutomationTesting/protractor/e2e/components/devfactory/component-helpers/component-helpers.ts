import {ComponentHelpersFactory} from '@aurea/protractor-automation-helper';
import {By, element} from 'protractor';
import {HtmlHelper} from '../../misc-utils/html-helper';

export class ComponentHelpers extends ComponentHelpersFactory {
    static getElementByTag(tag: string, text: string, isContains = false) {
        return element(By.xpath(this.getElementByTagXpath(tag, text, isContains)));
    }

    static getElementByTagXpath(tag: string, text: string, isContains = false) {
        return `//${tag}[${ComponentHelpers.getXPathFunctionForDot(text, isContains)}]`;
    }

    public static getXPathFunctionForClass(attributeValue: string, isContains = false) {
        return ComponentHelpers.getXPathFunctionForStringComparison(
            attributeValue,
            `@${HtmlHelper.attributes.class}`,
            isContains
        );
    }
}
