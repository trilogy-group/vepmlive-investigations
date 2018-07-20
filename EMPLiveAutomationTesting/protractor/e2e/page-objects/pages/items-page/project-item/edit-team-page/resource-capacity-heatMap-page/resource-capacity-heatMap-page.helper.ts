import {PageHelper} from '../../../../../../components/html/page-helper';
import {DropDownHelper} from '../../../../../../components/html/dropdown-helper';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {ResourceCapacityHeatMapPageConstants} from './resource-capacity-heatMap-page.constants';
import {CommonPageHelper} from '../../../../common/common-page.helper';
export class ResourceCapacityHeatMapPageHelper {
    static async selectParametersAndApply(stepLogger: StepLogger) {

        // this is work around without it not able to work on new tab
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.s);
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);

        await this.selectPeriodStartDate(stepLogger);

        await this.selectValuePeriodEndDate(stepLogger);

        await this.selectDepartment(stepLogger);

        await CommonPageHelper.clickApplyButton(stepLogger);

}
    static async selectPeriodStartDate(stepLogger: StepLogger) {
        await  PageHelper.click(CommonPageHelper.periodStartOption(ResourceCapacityHeatMapPageConstants.periodStart));
        stepLogger.step('Select Period start Date ');

        await DropDownHelper.selectOptionByVal(CommonPageHelper.periodStartOption(ResourceCapacityHeatMapPageConstants.periodStart), '2');

        await  CommonPageHelper.waitForApplyButtontoDisplayed;
    }

    static async selectValuePeriodEndDate(stepLogger: StepLogger) {
        stepLogger.step('Select Period End Date ');
        await  PageHelper.click(CommonPageHelper.periodEndOption(ResourceCapacityHeatMapPageConstants.periodEnd));

        await PageHelper.click(CommonPageHelper.periodEndOptionValue
        (ResourceCapacityHeatMapPageConstants.periodEnd));

        await  CommonPageHelper.waitForApplyButtontoDisplayed;
    }

    static async selectDepartment(stepLogger: StepLogger) {
        stepLogger.step('Select Department ');
        await PageHelper.click( CommonPageHelper.department(ResourceCapacityHeatMapPageConstants.department));

        await DropDownHelper.selectOptionByVal(
            CommonPageHelper.department
            (ResourceCapacityHeatMapPageConstants.department), ResourceCapacityHeatMapPageConstants.departmentValue);

        await  CommonPageHelper.waitForApplyButtontoDisplayed;
    }

  }
