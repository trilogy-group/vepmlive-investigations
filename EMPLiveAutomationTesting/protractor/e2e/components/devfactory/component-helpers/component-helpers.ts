import {ComponentHelpersFactory} from '@aurea/protractor-automation-helper';
import {By, element} from 'protractor';

export class ComponentHelpers extends ComponentHelpersFactory {
    static getElementByTag(tag: string, text: string, isContains = false) {
        return element(By.xpath(this.getElementByTagXpath(tag, text, isContains)));
    }

    static getElementByTagXpath(tag: string, text: string, isContains = false) {
        return `//${tag}[${ComponentHelpers.getXPathFunctionForDot(text, isContains)}]`;
    }

    static getElementByTagXpathWithTag(tag: string, internalTag: string, text: string, isContains = false) {
        return `//${tag}[${ComponentHelpers.getXPathFunctionForStringComparison(text, internalTag, isContains)}]`;
    }
}
