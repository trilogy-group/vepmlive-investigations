import {BasePage} from '../../../../base-page';
import {By, element} from 'protractor';
import {ResourceCommitmentsConstansts} from '../resource-commitments-page/resource-commitments.constansts';
import {ElementHelper} from '../../../../../../components/html/element-helper';

export class RespurceWorkVSCapacityPage extends BasePage {
    static get resource()
    {
        return element.all(By.xpath('(//*[@data-parametername=\'Resource\']//select)')).get(1);
    }
    static get resourceOption()
    {
        return element.all(By.xpath('(//*[@data-parametername=\'Resource\']//select//option)'));
    }
    static get applyButton()
    {
        return element(By.xpath('//*[@value=\'Apply\']'));
    }
    static get specifyParameterValues() {
        return ElementHelper.getElementByText(ResourceCommitmentsConstansts.specifyParameterValues);
    }
}
