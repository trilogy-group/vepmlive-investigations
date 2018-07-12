import {BasePage} from '../base-page';
import {ResourcePlannerConstants} from './resourceplanner-page.constants';
import {By, element} from 'protractor';
import {ElementHelper} from '../../../components/html/element-helper';

export class ResourceplannerPage extends BasePage {

    static get delete(){
        return element(By.id('DeleteBtn'));
    }

    static get selectUser(){
        // selecting User which have department Test department 1
        return element(By.xpath(`//*[normalize-space(text())=\'${ResourcePlannerConstants.user}\']//following-sibling::td[text()=\'${ResourcePlannerConstants.department}\']`));
    }
    static get showMe(){
        // selecting User which have department Test department 1
        return element(By.id('idResourcesTab_ShowMe_button'));
    }
    static getHoursHeader(){
        // selecting User which have department Test department 1
        return element.all(By.xpath('//*[@id=\'g_RPE\']//*[@class=\'GMHeadRight\']//td[contains(@class,\'GMHeaderText\')]'));
    }
    static get addedUser(){
        // selecting User which have department Test department 1
        return ElementHelper.getElementByText(ResourcePlannerConstants.user);
    }
    static get selectMonth(){
        return element(By.xpath('//*[@id=\'g_RPE\']//div[@class=\'GMBodyRight\']//*[@class=\'GMDataRow \']//td[contains(@class,\'GMClassEdit\')]'));
    }
    static get inputHours(){
        return element(By.xpath('//input[contains(@class,\'GMEditInput\')]'));
    }
    static get yesButton(){
        return element(By.xpath('//input[@value="Yes"]'));
    }

    static get greenCheckImg(){
        return element(By.css('[class*=\'rp-commitment\']'));
    }
    static get privateCheckImg(){
        return element(By.css('[class*=\'rp-pm-private\']'));
    }
}
