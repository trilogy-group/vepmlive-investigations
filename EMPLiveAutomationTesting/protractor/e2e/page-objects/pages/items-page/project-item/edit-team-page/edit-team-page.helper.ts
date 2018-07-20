import {StepLogger} from '../../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../../components/html/page-helper';
import {EditTeamPage} from './edit-team-page.po';
import {CommonPage} from '../../../common/common.po';

export class EditTeamPageHelper {
    static async clickviewReport(stepLogger: StepLogger) {
        stepLogger.step('click on view report');
        await PageHelper.click(EditTeamPage.viewReport);
    }

    static async clickResourceCapacityHeatMap(stepLogger: StepLogger) {
        stepLogger.step('click on resource Capacity');
        await PageHelper.click(EditTeamPage.viewReportMenus.resourceCapacityHeatMap);
    }

    static async clickResourceCommitments(stepLogger: StepLogger) {
        stepLogger.step('click on resource commitments');
        await PageHelper.click(EditTeamPage.viewReportMenus.resourceCommitments);
    }

    static async resourceAvailableVsPlannedByDept(stepLogger: StepLogger) {
        stepLogger.step('click on resource Capacity');
        await PageHelper.click(EditTeamPage.viewReportMenus.resourceAvailableVsPlannedByDept);
    }
    static async resourceWorkVsCapacity(stepLogger: StepLogger) {
        stepLogger.step('click on resource Capacity');
        await PageHelper.click(EditTeamPage.viewReportMenus.resourceAvailableVsPlannedByDept);
    }
    static async closeEditTeamPopUp(stepLogger: StepLogger) {
        stepLogger.step('click on resource commitments');
        await PageHelper.click(CommonPage.ribbonItems.close);
    }

}
