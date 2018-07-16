import {By, element} from 'protractor';
import {BasePage} from '../../../../base-page';

export class ResourceAvailablePage extends BasePage {
    static get periodStartOption()
    {
        return element.all(By.xpath('//*[@data-parametername=\'PeriodStart\']//select')).get(1);
    }
    static get periodEndOptionValue()
    {
        return element(By.xpath('(//*[@data-parametername=\'PeriodEnd\']//select)[2]//option[last()]'));
    }
    static get periodEndOption()
    {
        return element.all(By.xpath('//*[@data-parametername=\'PeriodEnd\']//select')).get(1);
    }
    static get department()
    {
        return element.all(By.xpath('(//*[@data-parametername=\'Department\']//select)')).get(1);
    }
    static get applyButton()
    {
        return element(By.xpath('//*[@value=\'Apply\']'));
    }
}
