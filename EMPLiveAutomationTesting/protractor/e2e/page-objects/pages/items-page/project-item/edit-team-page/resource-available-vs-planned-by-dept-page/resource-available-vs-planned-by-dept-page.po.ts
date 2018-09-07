import {BasePage} from '../../../../base-page';
import {ResourceAvailablePageConstants} from './resource-available-vs-planned-by-dept-page.constansts';
import {CommonPage} from '../../../../common/common.po';

export class ResourceAvailablePage extends BasePage {

    static get periodStartOption() {
       return CommonPage.getDropDownByParameterName(ResourceAvailablePageConstants.periodStart);
    }
    static get periodEndOption() {
        return CommonPage.getDropDownByParameterName(ResourceAvailablePageConstants.periodEnd);
    }
    static get periodEndOptionValue() {
        return CommonPage.periodEndOptionValue(ResourceAvailablePageConstants.periodEnd);
    }
    static get department() {
        return CommonPage.getDropDownByParameterName(ResourceAvailablePageConstants.department);
    }

}
