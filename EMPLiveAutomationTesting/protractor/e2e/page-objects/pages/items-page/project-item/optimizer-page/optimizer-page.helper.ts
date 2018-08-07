import {OptimizerPage} from './optimizer.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../../components/html/page-helper';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {OptimizerPageConstants} from './optimizer-page.constants';
// import {CommonPage} from '../../../common/common.po';
import {browser} from 'protractor';
import {ExpectationHelper} from '../../../../../components/misc-utils/expectation-helper';
import {CommonPageHelper} from '../../../common/common-page.helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';

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
        await ExpectationHelper.verifyText(label.message,
             optimizerConstLabel.message , optimizerConstLabel.message, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(label.ok,  OptimizerPageConstants.ok, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(label.cancel,  OptimizerPageConstants.cancel, stepLogger);
    }

    static async verifyOptimizerWindowClosed(stepLogger: StepLogger) {
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyNotDisplayedStatus(OptimizerPage.getConfigure, 'optimizer tab', stepLogger);
    }

    static async verifyAlertMessageForSingleProjectSelection(stepLogger: StepLogger) {
        const alertText = await PageHelper.getAlertText();
        stepLogger.verification('Alert displayed and validated the content');
        await ExpectationHelper.verifyStringEqualTo(alertText, OptimizerPageConstants.oneItemConfigureAlertMsg, stepLogger);
        await PageHelper.acceptAlert();
    }

    static async verifyCurrentStrategyName(strategyName: string, stepLogger: StepLogger) {
        stepLogger.step('Verify the Current Strategy drop down.');
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyText(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdown,
            OptimizerPageConstants.currentStrategy, strategyName, stepLogger);
    }

    static async verifyOptimizerPageOpened(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(OptimizerPage.getConfigure,  'Optimizer page', stepLogger);
    }

    static async closeOptimizerWindowFromOptimizerTab(stepLogger: StepLogger) {
        stepLogger.step('Click on Close button of the optimizer tab.');
        await PageHelper.click(OptimizerPage.getCloseOptimizerWindow);
    }

    static async gotoConfigureSection(stepLogger: StepLogger) {
        await CommonPageHelper.gotoOptimizer(stepLogger);
        stepLogger.step('Click on Configure button.');
        await PageHelper.click(OptimizerPage.getConfigure);
    }

    static async openSaveStrategyPopup(stepLogger: StepLogger) {
        stepLogger.step('Click on Save Strategy button.');
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.saveStrategy);
    }

    static async verifySaveStrtegyPopupDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(OptimizerPage.getOptimierSaveStrategyPopup.strategyName,
            'Save Strategy popup', stepLogger);
    }

    static async enterNewStrategyNameAndSubmit(stepLogger: StepLogger) {
        stepLogger.step('Enter Strategy name and submit');
        const uniqueId = PageHelper.getUniqueId();
        const strategyName = `${OptimizerPageConstants.strategyName}${uniqueId}`;
        await TextboxHelper.sendKeys(OptimizerPage.getOptimierSaveStrategyPopup.strategyName, strategyName);
        await PageHelper.click(OptimizerPage.getOptimierSaveStrategyPopup.ok);
        return strategyName;
    }

    static async openDeleteStrategyPopup(stepLogger: StepLogger) {
        stepLogger.step('Select a strategy in current strategy and Click on Delete Strategy button.');
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdown);
        // takes time to expand dropdown
        await browser.sleep(PageHelper.timeout.xs);
        const strategyName = await PageHelper.getText(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdownValue);
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdownValue);
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.deleteStrategy);
        return strategyName;
    }

}
