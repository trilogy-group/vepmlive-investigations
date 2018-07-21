import {BasePage} from '../../../../base-page';
import {ElementHelper} from '../../../../../../components/html/element-helper';
import {ResourceCommitmentsConstansts} from './resource-commitments.constansts';

export class ResourceCommitments extends BasePage {

    static get specifyParameterValues() {
        return ElementHelper.getElementByText(ResourceCommitmentsConstansts.specifyParameterValues);
    }
    static get resourceCommitmentsMessage() {
        return ElementHelper.getElementByText(ResourceCommitmentsConstansts.resourceCommitmentsMessage);
    }
}
