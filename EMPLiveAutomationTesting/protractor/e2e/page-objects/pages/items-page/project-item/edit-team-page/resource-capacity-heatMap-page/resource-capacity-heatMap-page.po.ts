import {By, element} from 'protractor';
import {BasePage} from '../../../../base-page';
import {ResourceCapacityHeatMapPageConstants} from './resource-capacity-heatMap-page.constants';

export class ResourceCapacityHeatMapPage extends BasePage {
    static get periodStartOption() {
        return this.getDropDownByParameterName(ResourceCapacityHeatMapPageConstants.periodStart);
    }

    static get periodEndOption() {
        return this.getDropDownByParameterName(ResourceCapacityHeatMapPageConstants.periodEnd);
    }

    static get department() {
        return this.getDropDownByParameterName(ResourceCapacityHeatMapPageConstants.department);
    }

    static get applyButton()
    {
        return element(By.css('[value=\'Apply\']'));
    }
    static getDropDownByParameterName(name: string, index = 1) {
        return element.all(By.xpath(`//*[@data-parametername="${name}"]//select`)).get(index);
    }
    static get periodEndOptionValue() {
        return element(By.xpath('(//*[@data-parametername=\'FD_PRD_ID\']//select)[2]//option[last()]'));
    }
}
