import {PageHelper} from '../../../../../../components/html/page-helper';
import {DropDownHelper} from '../../../../../../components/html/dropdown-helper';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {ResourceCapacityHeatMapPageConstants} from './resource-capacity-heatMap-page.constants';
import {CommonPageHelper} from '../../../../common/common-page.helper';
import {CommonPage} from '../../../../common/common.po';
export class ResourceCapacityHeatMapPageHelper {
    static async selectParametersAndApply(stepLogger: StepLogger) {
        const optionValue = 2;
        // this is work around without it not able to work on new tab
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.s);
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);

        await this.selectPeriodStartDate(stepLogger , optionValue );

        await this.selectLastValuePeriodEndDate(stepLogger);

        await this.selectDepartment(stepLogger);

        await CommonPageHelper.clickApplyButton(stepLogger);

}
    static async selectPeriodStartDate(stepLogger: StepLogger, optionValue: Number ) {
        await  PageHelper.click(CommonPage.periodStartOption(ResourceCapacityHeatMapPageConstants.periodStart));
        stepLogger.step('Select Period start Date ');

        await DropDownHelper.selectOptionByVal
        (CommonPage.periodStartOption(ResourceCapacityHeatMapPageConstants.periodStart), optionValue.toString() );

        await  CommonPageHelper.waitForApplyButtontoDisplayed;
    }

    static async selectLastValuePeriodEndDate(stepLogger: StepLogger) {
        stepLogger.step('Select Period End Date ');
        await  PageHelper.click(CommonPage.periodEndOption(ResourceCapacityHeatMapPageConstants.periodEnd));

        await PageHelper.click(CommonPage.periodEndOptionValue
        (ResourceCapacityHeatMapPageConstants.periodEnd));

        await  CommonPageHelper.waitForApplyButtontoDisplayed;
    }

    static async selectDepartment(stepLogger: StepLogger) {
        stepLogger.step('Select Department ');
        await PageHelper.click( CommonPage.department(ResourceCapacityHeatMapPageConstants.department));

        await DropDownHelper.selectOptionByVal(
            CommonPage.department
            (ResourceCapacityHeatMapPageConstants.department), ResourceCapacityHeatMapPageConstants.departmentValue);

        await  CommonPageHelper.waitForApplyButtontoDisplayed;
    }

  }
