import {ComponentHelpers} from '../devfactory/component-helpers/component-helpers';
import {HtmlHelper} from '../misc-utils/html-helper';
import {By, element} from 'protractor';

export class LabelHelper {
    public static getLabelByExactText(text: string, isContains = false) {
        const xpath = `//${HtmlHelper.tags.label}[${ComponentHelpers.getXPathFunctionForDot(text, isContains)}]`;
        return element.all(By.xpath(xpath)).first();
    }
}
