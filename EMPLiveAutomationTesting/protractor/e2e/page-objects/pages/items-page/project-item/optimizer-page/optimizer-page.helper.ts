import {browser} from 'protractor';
import {OptimizerPage} from './optimizer.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../../components/html/page-helper';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {OptimizerPageConstants} from './optimizer-page.constants';
import {ExpectationHelper} from '../../../../../components/misc-utils/expectation-helper';
import {CommonPageHelper} from '../../../common/common-page.helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';

export class OptimizerPageHelper {

    static async selectColumns(stepLogger: StepLogger) {
        const label = OptimizerPage.getSelectColumnsPopup;
        stepLogger.step(`select columns by checking respective check box`);
        await PageHelper.click(label.hideAll);
        let i, j: number;
        for ( i = 0; i < 7; i++) {
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
        await ExpectationHelper.verifyDisplayedStatus(label.availableFields,
            OptimizerPageConstants.optimizerConfiguration.availableFields, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(label.selectedFilelds,
            OptimizerPageConstants.optimizerConfiguration.selectedFilelds, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(label.availableFieldsSelect,
            OptimizerPageConstants.availableFieldsSection, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(label.selectedFieldsSelect,
            OptimizerPageConstants.selectedFieldsSection, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(label.upArrow, OptimizerPageConstants.upArrow, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(label.downArrow, OptimizerPageConstants.downArrow, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(label.add, OptimizerPageConstants.add, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(label.remove, OptimizerPageConstants.remove, stepLogger);
    }

    static async verifyDeleteStrategyPopup(stepLogger: StepLogger) {
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
        await browser.sleep(PageHelper.timeout.xs);
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
        const label = OptimizerPage.getOptimierSaveStrategyPopup;
        const uniqueId = PageHelper.getUniqueId();
        const strategyName = `${OptimizerPageConstants.strategyName}${uniqueId}`;
        await TextboxHelper.sendKeys(label.strategyName, strategyName);
        await PageHelper.click(label.ok);
        return strategyName;
    }

    static async openDeleteStrategyPopup(stepLogger: StepLogger) {
        const label = OptimizerPage.getOptimizerStrategyActions ;
        stepLogger.step('Select a strategy in current strategy and Click on Delete Strategy button.');
        await PageHelper.click(label.currentStrategyDropdown);
        // takes time to expand dropdown
        await browser.sleep(PageHelper.timeout.xs);
        const strategyName = await PageHelper.getText(label.currentStrategyDropdownValue);
        await PageHelper.click(label.currentStrategyDropdownValue);
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(label.deleteStrategy);
        return strategyName;
    }

    static async deleteStrategy(stepLogger: StepLogger) {
        const label = OptimizerPage.getOptimizerStrategyActions ;
        stepLogger.step('Select a strategy in current strategy and Click on Delete Strategy button.');
        await PageHelper.click(label.currentStrategyDropdownSpan);
        // takes time to expand dropdown
        await browser.sleep(PageHelper.timeout.xs);
        const strategyName = await PageHelper.getText(label.currentStrategyDropdownValue);
        await PageHelper.click(label.currentStrategyDropdownValue);
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(label.deleteStrategy);
        return strategyName;
    }

    static async clickOKonDeleteStrategyPopup(stepLogger: StepLogger) {
        stepLogger.step('Click on Ok');
        await PageHelper.click(OptimizerPage.getDeleteStrategyPopup.ok);
    }

    static async verifyDeletedStrategy(stepLogger: StepLogger, deletedStrategyName: string) {
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdownSpan);
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyNotDisplayedStatus(OptimizerPage.getCurrentStrategyByName(deletedStrategyName),
            deletedStrategyName, stepLogger);
    }

    static async verifyRibbonCollapsed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(OptimizerPage.getOptimizerRibbon.collapseView,
            OptimizerPageConstants.collapsed, stepLogger);
    }

    static async clickDeleteView(stepLogger: StepLogger) {
        stepLogger.step('Click on Delete View button.');
        const viewName = await PageHelper.getText(OptimizerPage.viewManagementOptions.currentViewDropdown);
        await PageHelper.click(OptimizerPage.viewManagementOptions.deleteView);
        await browser.sleep(PageHelper.timeout.s);
        return viewName;
    }

    static async verifyDeleteViewPopup(stepLogger: StepLogger) {
        const actualDelMessage = await PageHelper.getText(OptimizerPage.getDeleteViewPopup.deleteViewMessage);
        const expectedDelMessage = OptimizerPageConstants.deleteViewPopup.deleteViewMessage;
        await ExpectationHelper.verifyStringEqualTo(actualDelMessage, expectedDelMessage, stepLogger);
    }

    static async verifyDeletedView(stepLogger: StepLogger, deletedViewName: string) {
        stepLogger.verification('Deleted the view in the current view dropdown');
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(OptimizerPage.viewManagementOptions.currentViewDropdown);
        await browser.sleep(PageHelper.timeout.s);
        await ExpectationHelper.verifyNotDisplayedStatus(OptimizerPage.getCurrentViewByName(deletedViewName),
            deletedViewName, stepLogger);
    }

    static async clickMinusSign(stepLogger: StepLogger) {
        stepLogger.step('Click on Minus Sign');
        await PageHelper.click(OptimizerPage.getOptimizerRibbon.minusSign);
    }

    static async clickViewTab(stepLogger: StepLogger) {
        stepLogger.step('Click on View Tab');
        await PageHelper.click(OptimizerPage.getTabOptions.view);
    }

    static async verifyViewPageOpened(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(OptimizerPage.viewManagementOptions.saveView,  'View page', stepLogger);
    }

    static async closeOptimizerWindowFromViewTab(stepLogger: StepLogger) {
        stepLogger.step('Click on Close button of the optimizer tab.');
        await PageHelper.click(OptimizerPage.getCloseOptimizerViewTab);
    }

    static async clickOKonDeleteViewPopup(stepLogger: StepLogger) {
        stepLogger.step('Click on Ok');
        await PageHelper.click(OptimizerPage.getDeleteViewPopup.ok);
    }

    static async verifyMessageOnConfiguration(stepLogger: StepLogger) {
        const expectedMessage = OptimizerPageConstants.optimizerConfiguration.message;
        await ExpectationHelper.verifyContainsText(OptimizerPage.getOptimizerConfiguration.message,
            OptimizerPageConstants.configure, expectedMessage, stepLogger);
    }

    static async verfyCurrentStrategyDropdown(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdown,
            OptimizerPageConstants.currentStrategy, stepLogger);
    }

    static async clickSelectColumns(stepLogger: StepLogger) {
        stepLogger.step('Click on Select Column button');
        await PageHelper.click(OptimizerPage.viewManagementOptions.selectColumns);
    }

    static async verifySelectColumnsPopup(stepLogger: StepLogger) {
        const label = OptimizerPage.getSelectColumnsPopup;
        const optConst = OptimizerPageConstants.selectColumnsPopup;
        await ExpectationHelper.verifyText(label.heading,
            OptimizerPageConstants.selectColumns, optConst.header, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(label.eachColumn, 'Column names' , stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(label.eachSelectedColumn, 'Column checkbox' , stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(label.hideAll, optConst.hideAll , stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(label.ok, OptimizerPageConstants.ok , stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(label.cancel, OptimizerPageConstants.cancel , stepLogger);
    }

    static async clickHideAll(stepLogger: StepLogger) {
        stepLogger.step('Click on Hide all button.');
        await PageHelper.click(OptimizerPage.getSelectColumnsPopup.hideAll);
    }

    static async verifyNoColumnSelected(stepLogger: StepLogger) {
        const label = OptimizerPage.getSelectColumnsPopup;
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyNotDisplayedStatus(label.eachSelectedColumn, 'Checkbox selected' , stepLogger);
    }

    static async clickShowAll(stepLogger: StepLogger) {
        stepLogger.step('Click on Show all button.');
        await PageHelper.click(OptimizerPage.getSelectColumnsPopup.showAll);
    }

    static async verifyAllColumnSelected(stepLogger: StepLogger) {
        const label = OptimizerPage.getSelectColumnsPopup;
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyNotDisplayedStatus(label.unchecked, 'Checkbox unselected' , stepLogger);
    }

    static async clickOKonSelectColumnPopup(stepLogger: StepLogger) {
        stepLogger.step('Click on Ok');
        await PageHelper.click(OptimizerPage.getSelectColumnsPopup.ok);
    }

    static async verifyOptimizerTabOptions(stepLogger: StepLogger) {
        const tabLabel = OptimizerPage.getTabOptions;
        await ExpectationHelper.verifyDisplayedStatus(tabLabel.optimizer, 'Optimizer tab' , stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(tabLabel.view, 'View tab' , stepLogger);
    }
}
