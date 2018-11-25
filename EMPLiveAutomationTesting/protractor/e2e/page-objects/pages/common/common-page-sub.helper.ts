import { StepLogger } from '../../../../core/logger/step-logger';
import { WaitHelper } from '../../../components/html/wait-helper';
import { CommonPage } from './common.po';
import { PageHelper } from '../../../components/html/page-helper';
import { ElementHelper } from '../../../components/html/element-helper';

export class CommonPageSubHelper {

    static async selectCheckBox() {
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dataRows.get(1));
        await ElementHelper.actionHoverOver(CommonPage.dataRows.get(1));
        await PageHelper.click(CommonPage.rowsFirstColumn.get(1));
    }

    static async selectOneRecordFromGrid() {
        StepLogger.subStep('Select the check box for record');
        await WaitHelper.waitForElementToBePresent(CommonPage.getNthRecord());
        await ElementHelper.actionHoverOver(CommonPage.getNthRecord());
        await PageHelper.click(CommonPage.getNthRecord());
    }
}
