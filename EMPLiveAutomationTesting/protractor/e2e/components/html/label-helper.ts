import {By, element} from 'protractor';
import {TextComponentSelectors} from '../component-types/text-component/text-component-selectors';

export class LabelHelper {
    static getAllDivForText(
        text: string,
        textIsContains = false,
        insidePopup = false) {
        return element.all(By.xpath(TextComponentSelectors.getDivForTextXpath(text, textIsContains, insidePopup)));
    }

    static getDivByText(text: string) {
        return this.getAllDivForText(text, false).first();
    }

    static getDivContainsText(text: string) {
        return this.getAllDivForText(text, true).first();
    }

    static getAllListsForClass(
        classValue: string,
        textIsContains = false,
        insidePopup = false) {
        return element.all(By.xpath(TextComponentSelectors.getListForClassXpath(classValue, textIsContains, insidePopup)));
    }

    static getListByClass(classValue: string) {
        return this.getAllListsForClass(classValue, false).first();
    }

    static getListContainsClass(classValue: string) {
        return this.getAllListsForClass(classValue, true).first();
    }

    static getAllSpansForText(
        classValue: string,
        textIsContains = false,
        insidePopup = false) {
        return element.all(By.xpath(TextComponentSelectors.getSpanForTextXpath(classValue, textIsContains, insidePopup)));
    }

    static getSpanByText(classValue: string) {
        return this.getAllSpansForText(classValue, false).first();
    }

    static getSpanContainsText(classValue: string) {
        return this.getAllSpansForText(classValue, true).first();
    }

    static getSpanByTextInsideListByClassXpath(classValue: string, text: string) {
        return element.all(By.xpath(TextComponentSelectors.getSpanForTextInsideListForClassXpath(classValue, text, true))).first();
    }
}
