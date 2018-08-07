import {browser} from 'protractor';
import {OptimizerPage} from './optimizer.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../../components/html/page-helper';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {OptimizerPageConstants} from './optimizer-page.constants';
// import {CommonPageConstants} from '../../../common/common-page.constants';
import {CommonPage} from '../../../common/common.po';

export class OptimizerPageHelper {

    static async selectColumns(stepLogger: StepLogger) {
        const label = OptimizerPage.getSelectColumnsPopup;
        stepLogger.stepId(3);
        stepLogger.step(`select columns by checking respective check box`);
        await PageHelper.click(label.hideAll);
        let i, j: number;
        for ( i = 0; i < 3; i++) {
            await PageHelper.click(label.column.get(i));
        }
        // Getting the selected columns dynamically
        const allSelectedColumns: string[] = [];
        for ( j = 0; j < 3; j++ ) {
            let eachColumnName: string;
            eachColumnName = await PageHelper.getText(label.selectedColumn.get(j));
            allSelectedColumns.push(eachColumnName);
        }
        return allSelectedColumns;
    }

    static async verifyColumnNamesInGrid (columnsSelected: string[], stepLogger: StepLogger) {
        let i: number;
        stepLogger.verification('Columns which were selected and saved for this particular view displayed');
        for ( i = 0; i < columnsSelected.length - 1 ; i++) {
            const currentColumnText = await PageHelper.getText(OptimizerPage.getDisplyedColumns( i + 1));
            await expect(columnsSelected).toContain( currentColumnText,
                ValidationsHelper.getNewViewCloumnShouldDisplayed(columnsSelected[i]));
        }
    }

    static async selectPreviouslySavedView(viewName: string) {
        await PageHelper.click(OptimizerPage.viewManagementOptions.currentViewDropdown);
        await PageHelper.click(OptimizerPage.getCurrentViewDropdownValue(viewName));
    }

    static async verifyFilterSectionLabels(stepLogger: StepLogger) {
        const label = OptimizerPage.getOptimizerConfiguration;
        stepLogger.verification('Verified the content of label name "Which fields will be used as filters?"');
        await expect(await PageHelper.isElementDisplayed(label.availableFields))
            .toBe(true, ValidationsHelper.getDisplayedValidation(OptimizerPageConstants.optimizerConfiguration.availableFields));
        await expect(await PageHelper.isElementDisplayed(label.selectedFilelds))
            .toBe(true, ValidationsHelper.getDisplayedValidation(OptimizerPageConstants.optimizerConfiguration.selectedFilelds));
        await expect(await PageHelper.isElementDisplayed(label.availableFieldsSelect))
            .toBe(true, ValidationsHelper.getDisplayedValidation(OptimizerPageConstants.availableFieldsSection));
        await expect(await PageHelper.isElementDisplayed(label.selectedFieldsSelect))
            .toBe(true, ValidationsHelper.getDisplayedValidation(OptimizerPageConstants.selectedFieldsSection));
        await expect(await PageHelper.isElementDisplayed(label.upArrow))
            .toBe(true, ValidationsHelper.getDisplayedValidation(OptimizerPageConstants.upArrow));
        await expect(await PageHelper.isElementDisplayed(label.downArrow))
            .toBe(true, ValidationsHelper.getDisplayedValidation(OptimizerPageConstants.downArrow));
        await expect(await PageHelper.isElementDisplayed(label.add))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(OptimizerPageConstants.add));
        await expect(await PageHelper.isElementDisplayed(label.remove))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(OptimizerPageConstants.remove));
    }

    static async verifyDeleteStrategyPopup(stepLogger: StepLogger) {
        stepLogger.verification('Delete strategy popup verified with message, OK and Cancel buttons');
        const label = OptimizerPage.getDeleteStrategyPopup;
        const optimizerConstLabel = OptimizerPageConstants.deleteStrategyPopup;
        await expect(await PageHelper.getText(label.message)).toBe(optimizerConstLabel.message,
                ValidationsHelper.getFieldShouldHaveValueValidation(OptimizerPageConstants.deleteStrategy, optimizerConstLabel.message));
        await expect(await PageHelper.isElementDisplayed(label.ok))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(OptimizerPageConstants.ok));
        await expect(await PageHelper.isElementDisplayed(label.cancel))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(OptimizerPageConstants.cancel));
    }

    static async verifyOptimizerWindowClosed(stepLogger: StepLogger) {
        stepLogger.verification('Optimizer window closed');
        await browser.sleep(PageHelper.timeout.s);
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.optimizer, false)).toBe(true,
            ValidationsHelper.getNotDisplayedValidation(OptimizerPageConstants.optimizer));
    }

    static async verifyAlertMessageForSingleProjectSelection(stepLogger: StepLogger) {
        const alertText = await  PageHelper.getAlertText();
        stepLogger.verification('Alert displayed and validated the content');
        expect(alertText).toBe(OptimizerPageConstants.oneItemConfigureAlertMsg, ValidationsHelper.getDisplayedValidation(
            OptimizerPageConstants.oneItemConfigureAlertMsg));
        await PageHelper.acceptAlert();
    }

    static async verifyCurrentStrategyName(strategyName: string, stepLogger: StepLogger) {
        stepLogger.verification('Saved Strategy name displayed in the Current Strategy drop down box');
        await expect(PageHelper.getText(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdown)).toBe(strategyName,
            ValidationsHelper.getFieldShouldHaveValueValidation(OptimizerPageConstants.currentStrategy, strategyName));
    }

    static async deleteStrategy() {
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdownSpan);
        // takes time to expand dropdown
        await browser.sleep(PageHelper.timeout.xs);
        const strategyName = await PageHelper.getText(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdownValue);
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdownValue);
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.deleteStrategy);
        return strategyName;
    }

    static async verifyDeletedStrategy(stepLogger: StepLogger, deletedStrategyName: string) {
        stepLogger.verification('Deleted the strategy in the current strategy dropdown');
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdownSpan);
        await expect(await PageHelper.isElementDisplayed(OptimizerPage.getCurrentStrategyByName(deletedStrategyName))).toBe(false,
            ValidationsHelper.getFieldShouldNotHaveValueValidation(OptimizerPageConstants.currentStrategy, deletedStrategyName));
    }

    static async verifyRibbonCollapsed(stepLogger: StepLogger) {
        stepLogger.verification('Ribbon collapsed');
        await expect(await PageHelper.isElementDisplayed(OptimizerPage.getOptimizerRibbon.collapseView)).toBe(true,
            ValidationsHelper.getDisplayedValidation(OptimizerPageConstants.collapsed));
    }
}
