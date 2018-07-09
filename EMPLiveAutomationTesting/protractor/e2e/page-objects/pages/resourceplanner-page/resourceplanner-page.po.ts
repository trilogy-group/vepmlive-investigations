import {BasePage} from '../base-page';
import {ElementHelper} from '../../../components/html/element-helper';
import {ResourcePlannerConstants} from './resourceplanner-page.constants';
import {By, element} from 'protractor';

export class ResourceplannerPage extends BasePage {

    static get delete(){
        return element(By.id('DeleteBtn'));
    }

    static get selectUser(){
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

}
