import {StepLogger} from '../../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../../components/html/page-helper';
import {EditTeamPage} from './edit-team-page.po';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {DropDownHelper} from '../../../../../components/html/dropdown-helper';
import {ElementHelper} from '../../../../../components/html/element-helper';

export class EditTeamPageHelper {
    static async clickviewReport(stepLogger: StepLogger) {
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(EditTeamPage.viewReport);
        stepLogger.step('click on view report');
        await PageHelper.click(EditTeamPage.viewReport);
    }

    static async clickResourceCapacityHeatMap(stepLogger: StepLogger) {
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(EditTeamPage.resourceCapacityHeatMap);
        stepLogger.step('click on view report');
        await PageHelper.click(EditTeamPage.resourceCapacityHeatMap);
    }
    static async selectParametersAndApply(stepLogger: StepLogger) {
        // this is work around without it not able to work on new tab
        await WaitHelper.getInstance().staticWait(PageHelper.timeout.s);
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(EditTeamPage.applyButton);
        await  PageHelper.click(EditTeamPage.periodStartOption);
        stepLogger.step('Select Period start Date ');
        await DropDownHelper.selectOptionByVal(EditTeamPage.periodStartOption, '2' );
        await  WaitHelper.getInstance().waitForElementToBeClickable(EditTeamPage.applyButton);
        stepLogger.step('Select Period End Date ');
        await  PageHelper.click(EditTeamPage.periodEndOption);
        await PageHelper.click(EditTeamPage.periodEndOptionValue);
        await  WaitHelper.getInstance().waitForElementToBeClickable(EditTeamPage.applyButton);
        stepLogger.step('Select Department ');
        await PageHelper.click(EditTeamPage.department);
        const department = 'Test department 1';
        await DropDownHelper.selectOptionByVal(EditTeamPage.department, department );
        await  WaitHelper.getInstance().waitForElementToBeClickable(EditTeamPage.applyButton);
        stepLogger.step('Click on Apply Button ');
        await ElementHelper.actionMouseMove(EditTeamPage.applyButton);
        await PageHelper.click(EditTeamPage.applyButton);
        await  WaitHelper.getInstance().waitForElementToBeClickable(EditTeamPage.applyButton);

    }
}
