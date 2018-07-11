import {By, element} from 'protractor';
import {BasePage} from '../../../../base-page';
import {ElementHelper} from '../../../../../../components/html/element-helper';
import {ResourceCommitmentsConstansts} from './resource-commitments.constansts';

export class ResourceCommitments extends BasePage {
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

    static get resourceCommitmentsMessage() {
        return ElementHelper.getElementByText(ResourceCommitmentsConstansts.resourceCommitmentsMessage);
    }
}
