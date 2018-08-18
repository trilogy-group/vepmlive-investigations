import {PageHelper} from '../../../../../../components/html/page-helper';
import {DropDownHelper} from '../../../../../../components/html/dropdown-helper';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {ResourceCapacityHeatMapPageConstants} from './resource-capacity-heatMap-page.constants';
import {CommonPageHelper} from '../../../../common/common-page.helper';
import {ResourceCapacityHeatMapPage} from './resource-capacity-heatMap-page.po';

export class ResourceCapacityHeatMapPageHelper {
    static async selectParametersAndApply(stepLogger: StepLogger) {
        const optionValue = 2;
        // this is work around without it not able to work on new tab
        await WaitHelper.staticWait(PageHelper.timeout.s);
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);

        await this.selectPeriodStartDate(stepLogger, optionValue);

        await this.selectLastValuePeriodEndDate(stepLogger);

        await this.selectDepartment(stepLogger);

        await CommonPageHelper.clickApplyButton(stepLogger);

    }

    static async selectPeriodStartDate(stepLogger: StepLogger, optionValue: Number) {
        await  PageHelper.click(ResourceCapacityHeatMapPage.periodStart);
        stepLogger.step('Select Period start Date ');

        await DropDownHelper.selectOptionByVal(ResourceCapacityHeatMapPage.periodStart, optionValue.toString());

        await  CommonPageHelper.waitForApplyButtontoDisplayed();
    }

    static async selectLastValuePeriodEndDate(stepLogger: StepLogger) {
        stepLogger.step('Select Period End Date ');
        await  PageHelper.click(ResourceCapacityHeatMapPage.periodEnd);
        await PageHelper.click(ResourceCapacityHeatMapPage.periodEndOptionValue);
        await  CommonPageHelper.waitForApplyButtontoDisplayed();
    }

    static async selectDepartment(stepLogger: StepLogger) {
        stepLogger.step('Select Department ');
        await PageHelper.click(ResourceCapacityHeatMapPage.department);

        await DropDownHelper.selectOptionByVal(
            ResourceCapacityHeatMapPage.department, ResourceCapacityHeatMapPageConstants.departmentValue);

        await  CommonPageHelper.waitForApplyButtontoDisplayed();
    }

}
