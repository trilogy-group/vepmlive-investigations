import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../../../components/html/page-helper';
import {DropDownHelper} from '../../../../../../components/html/dropdown-helper';
import {ResourceAvailablePageConstants} from './resource-available-vs-planned-by-dept-page.constansts';
import {CommonPageHelper} from '../../../../common/common-page.helper';
import {ResourceAvailablePage} from './resource-available-vs-planned-by-dept-page.po';

export class ResourceAvailablePageHelper {
         static async selectParametersAndApply(stepLogger: StepLogger) {
        // this is work around without it not able to work on new tab
        const optionValue = 2;
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);

        await this.selectPeriodStartDate(stepLogger , optionValue );

        await this.selectLastValuePeriodEndDate(stepLogger);

        await this.selectDepartment(stepLogger);

        await CommonPageHelper.clickApplyButton(stepLogger);
         }

    static async selectPeriodStartDate(stepLogger: StepLogger, optionValue: Number )  {
        await  PageHelper.click(ResourceAvailablePage.periodStartOption);
        stepLogger.step('Select Period start Date ');

        await DropDownHelper.selectOptionByVal(
            ResourceAvailablePage.periodStartOption , optionValue.toString());

        await  CommonPageHelper.waitForApplyButtontoDisplayed();
    }

    static async selectLastValuePeriodEndDate(stepLogger: StepLogger) {
        stepLogger.step('Select Period End Date ');
        await  PageHelper.click(ResourceAvailablePage.periodEndOption);

        await PageHelper.click(ResourceAvailablePage.periodEndOptionValue);

        await  CommonPageHelper.waitForApplyButtontoDisplayed();
    }

    static async selectDepartment(stepLogger: StepLogger) {
        stepLogger.step('Select Department ');
        await PageHelper.click(ResourceAvailablePage.department);

        await DropDownHelper.selectOptionByVal
        (ResourceAvailablePage.department, ResourceAvailablePageConstants.departmentValue);

        await  CommonPageHelper.waitForApplyButtontoDisplayed();
    }

}
