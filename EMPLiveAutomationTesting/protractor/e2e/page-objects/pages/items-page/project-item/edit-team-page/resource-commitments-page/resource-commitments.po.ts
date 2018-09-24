import {BasePage} from '../../../../base-page';
import {ElementHelper} from '../../../../../../components/html/element-helper';
import {ResourceCommitmentsConstansts} from './resource-commitments.constansts';
import {CommonPage} from '../../../../common/common.po';

export class ResourceCommitments extends BasePage {

    static get specifyParameterValues() {
        return ElementHelper.getElementByText(ResourceCommitmentsConstansts.specifyParameterValues);
    }

    static get resourceCommitmentsMessage() {
        return ElementHelper.getElementByText(ResourceCommitmentsConstansts.resourceCommitmentsMessage);
    }

    static get getDropDownByParameterName() {
        return CommonPage.getDropDownByParameterName(ResourceCommitmentsConstansts.resource);
    }
}
