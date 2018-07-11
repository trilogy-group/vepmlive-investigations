import {StepLogger} from '../../../../../../../core/logger/step-logger';
import {WaitHelper} from '../../../../../../components/html/wait-helper';
import {PageHelper} from '../../../../../../components/html/page-helper';
import {ResourceAvailablePage} from './resource-available-vs-planned-by-dept-page.po';
import {DropDownHelper} from '../../../../../../components/html/dropdown-helper';
import {ElementHelper} from '../../../../../../components/html/element-helper';

export class ResourceAvailablePageHelpergeHelper {
         static async selectParametersAndApply(stepLogger: StepLogger) {
        // this is work around without it not able to work on new tab

        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(ResourceAvailablePage.periodStartOption);
        await  PageHelper.click(ResourceAvailablePage.periodStartOption);
        stepLogger.step('Select Period start Date ');
        await DropDownHelper.selectOptionByVal(ResourceAvailablePage.periodStartOption, '2');
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceAvailablePage.applyButton);
        stepLogger.step('Select Period End Date ');
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.s);
        await  PageHelper.click(ResourceAvailablePage.periodEndOption);
        await PageHelper.click(ResourceAvailablePage.periodEndOptionValue);
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceAvailablePage.applyButton);
        stepLogger.step('Select Department ');
        await PageHelper.click(ResourceAvailablePage.department);
        const department = 'Test department 1';
        await DropDownHelper.selectOptionByVal(ResourceAvailablePage.department, department);
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceAvailablePage.applyButton);
        stepLogger.step('Click on Apply Button ');
        await ElementHelper.actionMouseMove(ResourceAvailablePage.applyButton);
        await PageHelper.click(ResourceAvailablePage.applyButton);
        await  WaitHelper.getInstance().waitForElementToBeClickable(ResourceAvailablePage.applyButton);

    }
}
