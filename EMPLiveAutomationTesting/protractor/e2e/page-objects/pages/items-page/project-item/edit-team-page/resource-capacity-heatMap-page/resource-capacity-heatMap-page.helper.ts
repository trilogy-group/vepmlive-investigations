
import {PageHelper} from '../../../../../../components/html/page-helper';
import {DropDownHelper} from '../../../../../../components/html/dropdown-helper';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {ElementHelper} from '../../../../../../components/html/element-helper';
import {ResourceCapacityHeatMapPage} from './resource-capacity-heatMap-page.po';
import {ResourceCapacityHeatMapPageConstants} from './resource-capacity-heatMap-page.constants';
export class ResourceCapacityHeatMapPageHelper {
    static async selectParametersAndApply(stepLogger: StepLogger) {

        // this is work around without it not able to work on new tab
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.s);
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);

        await this.selectPeriodStartDate(stepLogger);

        await this.selectValuePeriodEndDate(stepLogger);

        await this.selectDepartment(stepLogger);

        await this.clickApplyButton(stepLogger);

}
    static async selectPeriodStartDate(stepLogger: StepLogger) {
        await  PageHelper.click(ResourceCapacityHeatMapPage.periodStartOption);
        stepLogger.step('Select Period start Date ');
        await DropDownHelper.selectOptionByVal(ResourceCapacityHeatMapPage.periodStartOption, '2');
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceCapacityHeatMapPage.applyButton);
    }

    static async selectValuePeriodEndDate(stepLogger: StepLogger) {
        stepLogger.step('Select Period End Date ');
        await  PageHelper.click(ResourceCapacityHeatMapPage.periodEndOption);
        await PageHelper.click(ResourceCapacityHeatMapPage.periodEndOptionValue);
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceCapacityHeatMapPage.applyButton);
    }

    static async selectDepartment(stepLogger: StepLogger) {
        stepLogger.step('Select Department ');
        await PageHelper.click(ResourceCapacityHeatMapPage.department);
        await DropDownHelper.selectOptionByVal(
            ResourceCapacityHeatMapPage.department, ResourceCapacityHeatMapPageConstants.departmentValue);
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceCapacityHeatMapPage.applyButton);
    }

    static async clickApplyButton(stepLogger: StepLogger) {
        stepLogger.step('Click on Apply Button ');
        await ElementHelper.actionMouseMove(ResourceCapacityHeatMapPage.applyButton);
        await PageHelper.click(ResourceCapacityHeatMapPage.applyButton);
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceCapacityHeatMapPage.applyButton);
    }
}
