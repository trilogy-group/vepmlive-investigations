import {OptimizerPage} from './optimizer.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../../components/html/page-helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';

export class OptimizerPageHelper {

    static async selectColumns(stepLogger: StepLogger) {
        const label = OptimizerPage.getSelectColumnsPopup;
        stepLogger.stepId(3);
        stepLogger.step(`select columns by checking respective check box`);
        await PageHelper.click(label.hideAll);
        let i, j: number;
        for ( i = 0; i < 3; i++) {
            await PageHelper.click(label.eachColumn.get(i));
        }
        // Getting the selected columns dynamically
        let eachColumnName, allSelectedColumns: string;
        allSelectedColumns = '';
        for ( j = 0; j < 3; j++ ) {
            eachColumnName = await PageHelper.getAttributeValue(label.selectedColumn.get(j), 'innerText');
            allSelectedColumns += eachColumnName + ',';
        }
        return allSelectedColumns;
    }

    static async verifyColumnNamesInGrid (selectedColumnsText: string, stepLogger: StepLogger) {
        const columnsSelected: string[] = selectedColumnsText.split(',');
        let i: number;
        stepLogger.verification('Columns which were selected and saved for this particular view displayed');
        for ( i = 0; i < columnsSelected.length - 1 ; i++) {
            await expect(columnsSelected).toContain( await OptimizerPage.getDisplyedColumns( i + 1).getText(),
                ValidationsHelper.getDisplayedValidation(columnsSelected[i]));
        }
    }

    static async selectPreviouslySavedView(viewName: string) {
        await PageHelper.click(OptimizerPage.viewManagementOptions.currentViewDropdown);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(OptimizerPage.getCurrentViewDropdownValue(viewName),
            PageHelper.timeout.s);
        await PageHelper.click(OptimizerPage.getCurrentViewDropdownValue(viewName));
    }
}
