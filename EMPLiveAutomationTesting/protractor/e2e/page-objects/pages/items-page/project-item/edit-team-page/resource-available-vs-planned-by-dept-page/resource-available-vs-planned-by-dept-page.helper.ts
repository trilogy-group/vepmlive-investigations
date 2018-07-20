import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../../../components/html/page-helper';
import {DropDownHelper} from '../../../../../../components/html/dropdown-helper';
import {ResourceAvailablePageConstants} from './resource-available-vs-planned-by-dept-page.constansts';
import {CommonPageHelper} from '../../../../common/common-page.helper';

export class ResourceAvailablePageHelper {
         static async selectParametersAndApply(stepLogger: StepLogger) {
        // this is work around without it not able to work on new tab
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);

        await this.selectPeriodStartDate(stepLogger);

        await this.selectValuePeriodEndDate(stepLogger);

        await this.selectDepartment(stepLogger);

        await CommonPageHelper.clickApplyButton(stepLogger);
         }

     static async selectPeriodStartDate(stepLogger: StepLogger) {
        await  PageHelper.click(CommonPageHelper.periodStartOption(ResourceAvailablePageConstants.periodStart));
        stepLogger.step('Select Period start Date ');

        await DropDownHelper.selectOptionByVal(CommonPageHelper.periodStartOption(ResourceAvailablePageConstants.periodStart) , '2');

        await  CommonPageHelper.waitForApplyButtontoDisplayed;
    }

    static async selectValuePeriodEndDate(stepLogger: StepLogger) {
        stepLogger.step('Select Period End Date ');
        await  PageHelper.click(CommonPageHelper.periodEndOption(ResourceAvailablePageConstants.periodEnd));

        await PageHelper.click(CommonPageHelper.periodEndOptionValue(ResourceAvailablePageConstants.periodEnd));

        await  CommonPageHelper.waitForApplyButtontoDisplayed;
    }

    static async selectDepartment(stepLogger: StepLogger) {
        stepLogger.step('Select Department ');
        await PageHelper.click(CommonPageHelper.department(ResourceAvailablePageConstants.department));

        await DropDownHelper.selectOptionByVal
        (CommonPageHelper.department(ResourceAvailablePageConstants.department), ResourceAvailablePageConstants.departmentValue);

        await  CommonPageHelper.waitForApplyButtontoDisplayed;
    }

}
