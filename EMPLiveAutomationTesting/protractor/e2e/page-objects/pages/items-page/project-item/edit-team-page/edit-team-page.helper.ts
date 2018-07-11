import {StepLogger} from '../../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../../components/html/page-helper';
import {EditTeamPage} from './edit-team-page.po';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPage} from '../../../common/common.po';

export class EditTeamPageHelper {
    static async clickviewReport(stepLogger: StepLogger) {
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(EditTeamPage.viewReport);
        stepLogger.step('click on view report');
        await PageHelper.click(EditTeamPage.viewReport);
    }

    static async clickResourceCapacityHeatMap(stepLogger: StepLogger) {
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(EditTeamPage.viewReportMenus.resourceCapacityHeatMap);
        stepLogger.step('click on resource Capacity');
        await PageHelper.click(EditTeamPage.viewReportMenus.resourceCapacityHeatMap);
    }

    static async clickResourceCommitments(stepLogger: StepLogger) {
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(EditTeamPage.viewReportMenus.resourceCommitments);
        stepLogger.step('click on resource commitments');
        await PageHelper.click(EditTeamPage.viewReportMenus.resourceCommitments);
    }

    static async resourceAvailableVsPlannedByDept(stepLogger: StepLogger) {
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(EditTeamPage.viewReportMenus.resourceAvailableVsPlannedByDept);
        stepLogger.step('click on resource Capacity');
        await PageHelper.click(EditTeamPage.viewReportMenus.resourceAvailableVsPlannedByDept);
    }
    static async resourceWorkVsCapacity(stepLogger: StepLogger) {
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(EditTeamPage.viewReportMenus.resourceWorkVsCapacity);
        stepLogger.step('click on resource Capacity');
        await PageHelper.click(EditTeamPage.viewReportMenus.resourceAvailableVsPlannedByDept);
    }
    static async closeEditTeamPopUp(stepLogger: StepLogger) {
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.close);
        stepLogger.step('click on resource commitments');
        await PageHelper.click(CommonPage.ribbonItems.close);
    }

}
