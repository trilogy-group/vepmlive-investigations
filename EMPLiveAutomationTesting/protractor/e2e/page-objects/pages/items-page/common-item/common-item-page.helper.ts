import {By, element} from 'protractor';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';

export class CommonItemPageHelper {
    static getNotificationByText(text: string) {
        return element(By.xpath(`//h2[${ComponentHelpers.getXPathFunctionForDot(text)}]`));
    }

    static getPageNumberByTitle(title: string) {
        return element(By.xpath(`//a[contains(@class,'pageNumber') and contains(@title,"${title}")]`));
    }

    static getMenuItemFromRibbonContainer(title: string) {
        return element(By.css(`#RibbonContainer li[title="${title}"]`));
    }

}
