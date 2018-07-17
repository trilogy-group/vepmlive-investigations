import {By, element} from 'protractor';
import {BasePage} from '../../../../base-page';
import {ResourceAvailablePageConstants} from './resource-available-vs-planned-by-dept-page.constansts';
export class ResourceAvailablePage extends BasePage {
    static get periodStartOption()
    {
        return this.getDropDownByParameterName(ResourceAvailablePageConstants.periodStart);
    }
    static get periodEndOption()
    {
        return this.getDropDownByParameterName(ResourceAvailablePageConstants.periodEnd);
    }
    static get department()
    {
        return this.getDropDownByParameterName(ResourceAvailablePageConstants.department);
    }
    static get applyButton()
    {
        return element(By.css('[value=\'Apply\']'));
    }
    static getDropDownByParameterName(name: string, index = 1) {
        return element.all(By.xpath(`//*[@data-parametername="${name}"]//select`)).get(index);
    }
    static get periodEndOptionValue()
    {
        return element(By.xpath('(//*[@data-parametername=\'PeriodEnd\']//select)[2]//option[last()]'));
    }
}
