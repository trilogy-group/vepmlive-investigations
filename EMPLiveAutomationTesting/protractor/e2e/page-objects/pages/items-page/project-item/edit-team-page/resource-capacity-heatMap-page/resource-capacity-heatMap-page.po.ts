import {CommonPage} from '../../../../common/common.po';
import {ResourceCapacityHeatMapPageConstants} from './resource-capacity-heatMap-page.constants';

export class ResourceCapacityHeatMapPage {
    static get periodStart() {
        return CommonPage.getDropDownByParameterName(ResourceCapacityHeatMapPageConstants.periodStart);
    }

    static get periodEnd() {
        return CommonPage.getDropDownByParameterName(ResourceCapacityHeatMapPageConstants.periodEnd);
    }

    static get periodEndOptionValue() {
        return CommonPage.periodEndOptionValue(ResourceCapacityHeatMapPageConstants.periodEnd);
    }

    static get department() {
        return CommonPage.getDropDownByParameterName(ResourceCapacityHeatMapPageConstants.department);
    }

}
