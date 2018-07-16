import {By, element} from 'protractor';
import {BasePage} from '../../../../base-page';

export class ResourceCapacityHeatMapPage extends BasePage {
    static get periodStartOption() {
        return element.all(By.xpath('//*[@data-parametername=\'SD_PRD_ID\']//select')).get(1);
    }

    static get periodEndOptionValue() {
        return element(By.xpath('(//*[@data-parametername=\'FD_PRD_ID\']//select)[2]//option[last()]'));
    }

    static get periodEndOption() {
        return element.all(By.xpath('//*[@data-parametername=\'FD_PRD_ID\']//select')).get(1);
    }

    static get department() {
        return element.all(By.xpath('(//*[@data-parametername=\'Department\']//select)')).get(1);
    }

    static get applyButton() {
        return element(By.xpath('//*[@value=\'Apply\']'));
    }
}
