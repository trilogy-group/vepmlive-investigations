import {PageHelper} from '../../../../../../components/html/page-helper';
import {DropDownHelper} from '../../../../../../components/html/dropdown-helper';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {ResourceCapacityHeatMapPageConstants} from './resource-capacity-heatMap-page.constants';
import {CommonPageHelper} from '../../../../common/common-page.helper';
import {ResourceCapacityHeatMapPage} from './resource-capacity-heatMap-page.po';

export class ResourceCapacityHeatMapPageHelper {
    static async selectParametersAndApply() {
        const optionValue = 2;
        // this is work around without it not able to work on new tab
        await WaitHelper.staticWait(PageHelper.timeout.s);
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);

        await this.selectPeriodStartDate(optionValue);

        await this.selectLastValuePeriodEndDate();

        await this.selectDepartment();

        await CommonPageHelper.clickApplyButton();

    }

    static async selectPeriodStartDate(optionValue: Number) {
        await  PageHelper.click(ResourceCapacityHeatMapPage.periodStart);
        StepLogger.step('Select Period start Date ');

        await DropDownHelper.selectOptionByVal(ResourceCapacityHeatMapPage.periodStart, optionValue.toString());

        await  CommonPageHelper.waitForApplyButtontoDisplayed();
    }

    static async selectLastValuePeriodEndDate() {
        StepLogger.step('Select Period End Date ');
        await  PageHelper.click(ResourceCapacityHeatMapPage.periodEnd);
        await PageHelper.click(ResourceCapacityHeatMapPage.periodEndOptionValue);
        await  CommonPageHelper.waitForApplyButtontoDisplayed();
    }

    static async selectDepartment() {
        StepLogger.step('Select Department ');
        await PageHelper.click(ResourceCapacityHeatMapPage.department);

        await DropDownHelper.selectOptionByVal(
            ResourceCapacityHeatMapPage.department, ResourceCapacityHeatMapPageConstants.departmentValue);

        await  CommonPageHelper.waitForApplyButtontoDisplayed();
    }

}
