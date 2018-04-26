import {ElementFinder} from 'protractor';
import {WaitHelper} from './wait-helper';
import {ComponentHelpers} from '../devfactory/component-helpers/component-helpers';
import {HtmlHelper} from '../misc-utils/html-helper';

export class CheckboxHelper {
    /**
     * Returns
     * input[@type="checkbox" and contains(@name,@param)]
     * or
     * input[@type="checkbox" and normalize-space(@name)=attributeValue] based on the parameter
     * @example
     * // Returns input[@type="checkbox" and contains(@name,@param)]
     * this.getCheckboxXpathByName(text:attributeValue, isContains:true);
     * // Returns input[@type="checkbox" and normalize-space(@name)=attributeValue]
     * this.getCheckboxXpathByName(text:attributeValue, isContains:false);
     * @param {string} name
     * @param {boolean} isContains
     * @returns {string}
     */
    static getCheckboxXpathByName(name: string, isContains = false) {
        const attribute = ComponentHelpers
            .getXPathFunctionForStringComparison(
                name,
                `@${HtmlHelper.attributes.name}`,
                isContains);
        return `input[@type="checkbox" and ${attribute}]`;
    }

    static async markCheckbox(elementt: ElementFinder, markChecked: boolean) {
        await WaitHelper.getInstance().waitForElementToBeClickable(elementt);
        // Retry mark checkbox if previous try fails.  This is
        // useful on slow environments like on remote executions.
        const isSelected = await elementt.isSelected();
        if (isSelected !== markChecked) {
            await elementt.click();
        }
        return;
    }
}
