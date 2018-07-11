import {PageHelper} from '../../../../../../components/html/page-helper';
import {DropDownHelper} from '../../../../../../components/html/dropdown-helper';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {ElementHelper} from '../../../../../../components/html/element-helper';
import {ResourceCapacityHeatMapPage} from './resource-capacity-heatMap-page.po';

export class ResourceCapacityHeatMapPageHelper {
    static async selectParametersAndApply(stepLogger: StepLogger) {
        // this is work around without it not able to work on new tab
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.s);
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(ResourceCapacityHeatMapPage.periodStartOption);
        await  PageHelper.click(ResourceCapacityHeatMapPage.periodStartOption);
        stepLogger.step('Select Period start Date ');
        await DropDownHelper.selectOptionByVal(ResourceCapacityHeatMapPage.periodStartOption, '2' );
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceCapacityHeatMapPage.applyButton);
        stepLogger.step('Select Period End Date ');
        await  PageHelper.click(ResourceCapacityHeatMapPage.periodEndOption);
        await PageHelper.click(ResourceCapacityHeatMapPage.periodEndOptionValue);
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceCapacityHeatMapPage.applyButton);
        stepLogger.step('Select Department ');
        await PageHelper.click(ResourceCapacityHeatMapPage.department);
        const department = 'Test department 1';
        await DropDownHelper.selectOptionByVal(ResourceCapacityHeatMapPage.department, department );
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceCapacityHeatMapPage.applyButton);
        stepLogger.step('Click on Apply Button ');
        await ElementHelper.actionMouseMove(ResourceCapacityHeatMapPage.applyButton);
        await PageHelper.click(ResourceCapacityHeatMapPage.applyButton);
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceCapacityHeatMapPage.applyButton);

    }
}
