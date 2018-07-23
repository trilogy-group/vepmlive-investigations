import {ResourceCapacityHeatMapPageConstants} from "./resource-capacity-heatMap-page.constants";
import {CommonPage} from "../../../../common/common.po";

export class ResourceCapacityHeatMapPage {
    static get periodStart() {
        return CommonPage.getDropDownByParameterName(ResourceCapacityHeatMapPageConstants.periodStart);
    }

    static get periodEnd() {
        return CommonPage.getDropDownByParameterName(ResourceCapacityHeatMapPageConstants.periodEnd);
    }
}
