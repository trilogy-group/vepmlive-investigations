import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
import {PageHelper} from '../../../../../../components/html/page-helper';
import {ResourceAvailablePage} from './resource-available-vs-planned-by-dept-page.po';
import {DropDownHelper} from '../../../../../../components/html/dropdown-helper';
import {ElementHelper} from '../../../../../../components/html/element-helper';
import {ResourceAvailablePageConstants} from './resource-available-vs-planned-by-dept-page.constansts';

export class ResourceAvailablePageHelper {
         static async selectParametersAndApply(stepLogger: StepLogger) {
        // this is work around without it not able to work on new tab
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);

        await this.selectPeriodStartDate(stepLogger);

        await this.selectValuePeriodEndDate(stepLogger);

        await this.selectDepartment(stepLogger);

        await this.clickApplyButton(stepLogger);
         }

    static async selectPeriodStartDate(stepLogger: StepLogger) {
        await  PageHelper.click(ResourceAvailablePage.periodStartOption);
        stepLogger.step('Select Period start Date ');
        await DropDownHelper.selectOptionByVal(ResourceAvailablePage.periodStartOption, '2');
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceAvailablePage.applyButton);
    }

    static async selectValuePeriodEndDate(stepLogger: StepLogger) {
        stepLogger.step('Select Period End Date ');
        await  PageHelper.click(ResourceAvailablePage.periodEndOption);
        await PageHelper.click(ResourceAvailablePage.periodEndOptionValue);
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceAvailablePage.applyButton);
    }

    static async selectDepartment(stepLogger: StepLogger) {
        stepLogger.step('Select Department ');
        await PageHelper.click(ResourceAvailablePage.department);
        await DropDownHelper.selectOptionByVal(ResourceAvailablePage.department, ResourceAvailablePageConstants.departmentValue);
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceAvailablePage.applyButton);
    }

    static async clickApplyButton(stepLogger: StepLogger) {
        stepLogger.step('Click on Apply Button ');
        await ElementHelper.actionMouseMove(ResourceAvailablePage.applyButton);
        await PageHelper.click(ResourceAvailablePage.applyButton);
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceAvailablePage.applyButton);
    }
}
