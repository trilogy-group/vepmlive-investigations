import {BasePage} from '../../../base-page';
import {By, element} from 'protractor';

export class EditTeamPage extends BasePage {
    static get viewReport() {
        return element(By.id('Ribbon.BuildTeam.ToolsGroup.Reports-Medium'));
    }
    static get resourceCapacityHeatMap()
    {
        return element(By.xpath('//span[text() ="Resource Capacity Heat Map"]//parent::a'));
    }
    static get periodStartOption()
    {
        return element.all(By.xpath('//*[@data-parametername=\'SD_PRD_ID\']//select')).get(1);
    }
    static get periodEndOptionValue()
    {
        return element(By.xpath('(//*[@data-parametername=\'FD_PRD_ID\']//select)[2]//option[last()]'));
    }
    static get periodEndOption()
    {
        return element.all(By.xpath('//*[@data-parametername=\'FD_PRD_ID\']//select')).get(1);
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
