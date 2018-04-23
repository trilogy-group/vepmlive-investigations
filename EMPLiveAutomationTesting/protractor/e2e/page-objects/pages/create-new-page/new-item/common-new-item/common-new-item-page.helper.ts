import {By, element} from 'protractor';
import {ComponentHelpers} from '../../../../../components/devfactory/component-helpers/component-helpers';

export class CommonNewItemPageHelper {
    static getNotificationByText(text: string) {
        return element(By.xpath(`//h2[${ComponentHelpers.getXPathFunctionForDot(text)}]`));
    }
}
