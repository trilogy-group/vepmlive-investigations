import { browser } from 'protractor';
import { OptimizerPage } from './optimizer.po';
import { StepLogger } from '../../../../../../core/logger/step-logger';
import { PageHelper } from '../../../../../components/html/page-helper';
import { ValidationsHelper } from '../../../../../components/misc-utils/validation-helper';
import { OptimizerPageConstants } from './optimizer-page.constants';
import { ExpectationHelper } from '../../../../../components/misc-utils/expectation-helper';
import { CommonPageHelper } from '../../../common/common-page.helper';
import { TextboxHelper } from '../../../../../components/html/textbox-helper';
import { ElementHelper } from '../../../../../components/html/element-helper';

export class OptimizerPageHelper {

    static async selectColumns() {
        const label = OptimizerPage.getSelectColumnsPopup;
        StepLogger.step(`select columns by checking respective check box`);
        await PageHelper.click(label.hideAll);
        let i, j: number;
        for (i = 0; i < 7; i++) {
            await PageHelper.click(label.column.get(i));
        }
        // Getting the selected columns dynamically
        const allSelectedColumns: string[] = [];
        for (j = 0; j < 3; j++) {
            let eachColumnName: string;
            eachColumnName = await PageHelper.getText(label.selectedColumn.get(j));
            allSelectedColumns.push(eachColumnName);
        }
        return allSelectedColumns;
    }

    static async verifyColumnNamesInGrid(columnsSelected: string[]) {
        StepLogger.verification('Columns which were selected and saved for this particular view displayed');
        for (let i = 0; i < columnsSelected.length - 1; i++) {
            const currentColumnText = await PageHelper.getText(OptimizerPage.getDisplyedColumns(i + 1));
            await expect(columnsSelected).toContain(currentColumnText,
                ValidationsHelper.getNewViewCloumnShouldDisplayed(columnsSelected[i]));
        }
    }

    static async selectPreviouslySavedView(viewName: string) {
        await PageHelper.click(OptimizerPage.viewManagementOptions.currentViewDropdown);
        await PageHelper.click(OptimizerPage.getCurrentViewDropdownValue(viewName));
    }

    static async verifyFilterSectionLabels() {
        const label = OptimizerPage.getOptimizerConfiguration;
        StepLogger.verification('Verified the content of label name "Which fields will be used as filters?"');
        await ExpectationHelper.verifyDisplayedStatus(label.availableFields,
            OptimizerPageConstants.optimizerConfiguration.availableFields);
        await ExpectationHelper.verifyDisplayedStatus(label.selectedFilelds,
            OptimizerPageConstants.optimizerConfiguration.selectedFilelds);
        await ExpectationHelper.verifyDisplayedStatus(label.availableFieldsSelect,
            OptimizerPageConstants.availableFieldsSection);
        await ExpectationHelper.verifyDisplayedStatus(label.selectedFieldsSelect,
            OptimizerPageConstants.selectedFieldsSection);
        await ExpectationHelper.verifyDisplayedStatus(label.upArrow, OptimizerPageConstants.upArrow);
        await ExpectationHelper.verifyDisplayedStatus(label.downArrow, OptimizerPageConstants.downArrow);
        await ExpectationHelper.verifyDisplayedStatus(label.add, OptimizerPageConstants.add);
        await ExpectationHelper.verifyDisplayedStatus(label.remove, OptimizerPageConstants.remove);
    }

    static async verifyDeleteStrategyPopup() {
        const label = OptimizerPage.getDeleteStrategyPopup;
        const optimizerConstLabel = OptimizerPageConstants.deleteStrategyPopup;
        await ExpectationHelper.verifyText(label.message,
            optimizerConstLabel.message, optimizerConstLabel.message);
        await ExpectationHelper.verifyDisplayedStatus(label.ok, OptimizerPageConstants.ok);
        await ExpectationHelper.verifyDisplayedStatus(label.cancel, OptimizerPageConstants.cancel);
    }

    static async verifyOptimizerWindowClosed() {
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyNotDisplayedStatus(OptimizerPage.getConfigure, 'optimizer tab');
    }

    static async verifyAlertMessageForSingleProjectSelection() {
        const alertText = await PageHelper.getAlertText();
        await ExpectationHelper.verifyStringEqualTo(alertText, OptimizerPageConstants.oneItemConfigureAlertMsg);
        await PageHelper.acceptAlert();
    }

    static async verifyCurrentStrategyName(strategyName: string) {
        StepLogger.step('Verify the Current Strategy drop down.');
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyText(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdown,
            OptimizerPageConstants.currentStrategy, strategyName);
    }

    static async verifyOptimizerPageOpened() {
        await ExpectationHelper.verifyDisplayedStatus(OptimizerPage.getConfigure, 'Optimizer page');
    }

    static async closeOptimizerWindowFromOptimizerTab() {
        StepLogger.step('Click on Close button of the optimizer tab.');
        await PageHelper.click(OptimizerPage.getCloseOptimizerWindow);
    }

    static async gotoConfigureSection() {
        await CommonPageHelper.goToOptimizer();
        await this.clickConfigure();
    }

    static async openSaveStrategyPopup() {
        StepLogger.step('Click on Save Strategy button.');
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.saveStrategy);
    }

    static async verifySaveStrtegyPopupDisplayed() {
        await ExpectationHelper.verifyDisplayedStatus(OptimizerPage.getOptimierSaveStrategyPopup.strategyName,
            'Save Strategy popup');
    }

    static async enterNewStrategyNameAndSubmit() {
        StepLogger.step('Enter Strategy name and submit');
        const label = OptimizerPage.getOptimierSaveStrategyPopup;
        const uniqueId = PageHelper.getUniqueId();
        const strategyName = `${OptimizerPageConstants.strategyName}${uniqueId}`;
        await TextboxHelper.sendKeys(label.strategyName, strategyName);
        await PageHelper.click(label.ok);
        return strategyName;
    }

    static async openDeleteStrategyPopup() {
        const label = OptimizerPage.getOptimizerStrategyActions;
        StepLogger.step('Select a strategy in current strategy and Click on Delete Strategy button.');
        await PageHelper.click(label.currentStrategyDropdown);
        // takes time to expand dropdown
        await browser.sleep(PageHelper.timeout.xs);
        const strategyName = await PageHelper.getText(label.currentStrategyDropdownValue);
        await PageHelper.click(label.currentStrategyDropdownValue);
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(label.deleteStrategy);
        return strategyName;
    }

    static async deleteStrategy() {
        const label = OptimizerPage.getOptimizerStrategyActions;
        StepLogger.step('Select a strategy in current strategy and Click on Delete Strategy button.');
        await PageHelper.click(label.currentStrategyDropdownSpan);
        // takes time to expand dropdown
        await browser.sleep(PageHelper.timeout.xs);
        const strategyName = await PageHelper.getText(label.currentStrategyDropdownValue);
        await PageHelper.click(label.currentStrategyDropdownValue);
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(label.deleteStrategy);
        return strategyName;
    }

    static async clickOKonDeleteStrategyPopup() {
        StepLogger.step('Click on Ok');
        await PageHelper.click(OptimizerPage.getDeleteStrategyPopup.ok);
    }

    static async clickOKonSaveStrategyPopup() {
        StepLogger.step('Click on Ok');
        await PageHelper.click(OptimizerPage.getOptimierSaveStrategyPopup.ok);
    }

    static async verifyDeletedStrategy(deletedStrategyName: string) {
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdownSpan);
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyNotDisplayedStatus(OptimizerPage.getCurrentStrategyByName(deletedStrategyName),
            deletedStrategyName);
    }

    static async verifyRibbonCollapsed() {
        await ExpectationHelper.verifyDisplayedStatus(OptimizerPage.getOptimizerRibbon.collapseView,
            OptimizerPageConstants.collapsed);
    }

    static async clickDeleteView() {
        StepLogger.step('Click on Delete View button.');
        const viewName = await PageHelper.getText(OptimizerPage.viewManagementOptions.currentViewDropdown);
        await PageHelper.click(OptimizerPage.viewManagementOptions.deleteView);
        await browser.sleep(PageHelper.timeout.s);
        return viewName;
    }

    static async clickSaveView() {
        StepLogger.step('Click on Save View button.');
        await PageHelper.click(OptimizerPage.viewManagementOptions.saveView);
        await browser.sleep(PageHelper.timeout.s);
    }

    static async verifyDeleteViewPopup() {
        const label = OptimizerPage.getDeleteViewPopup;
        const actualDelMessage = await PageHelper.getText(label.deleteViewMessage);
        const expectedDelMessage = OptimizerPageConstants.deleteViewPopup.deleteViewMessage;
        await ExpectationHelper.verifyStringEqualTo(actualDelMessage, expectedDelMessage);
        await ExpectationHelper.verifyDisplayedStatus(label.ok, OptimizerPageConstants.ok);
        await ExpectationHelper.verifyDisplayedStatus(label.cancel, OptimizerPageConstants.cancel);
    }

    static async verifyDeletedView(deletedViewName: string) {
        StepLogger.verification('Deleted the view in the current view dropdown');
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.clickIfDisplayed(OptimizerPage.viewManagementOptions.currentViewDropdown);
        await browser.sleep(PageHelper.timeout.s);
        await ExpectationHelper.verifyNotDisplayedStatus(OptimizerPage.getCurrentViewByName(deletedViewName),
            deletedViewName);
    }

    static async clickMinusSign() {
        StepLogger.step('Click on Minus Sign');
        await PageHelper.click(OptimizerPage.getOptimizerRibbon.minusSign);
    }

    static async clickViewTab() {
        StepLogger.step('Click on View Tab');
        await PageHelper.click(OptimizerPage.getTabOptions.view);
    }

    static async verifyViewPageOpened() {
        await ExpectationHelper.verifyDisplayedStatus(OptimizerPage.viewManagementOptions.saveView, 'View page');
    }

    static async closeOptimizerWindowFromViewTab() {
        StepLogger.step('Click on Close button of the optimizer tab.');
        await PageHelper.click(OptimizerPage.getCloseOptimizerViewTab);
    }

    static async clickOKonDeleteViewPopup() {
        StepLogger.step('Click on Ok');
        await PageHelper.click(OptimizerPage.getDeleteViewPopup.ok);
    }

    static async verifyMessageOnConfiguration() {
        const expectedMessage = OptimizerPageConstants.optimizerConfiguration.message;
        await ExpectationHelper.verifyContainsText(OptimizerPage.getOptimizerConfiguration.message,
            OptimizerPageConstants.configure, expectedMessage);
    }

    static async verfyCurrentStrategyDropdown() {
        await ExpectationHelper.verifyDisplayedStatus(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdown,
            OptimizerPageConstants.currentStrategy);
    }

    static async clickSelectColumns() {
        StepLogger.step('Click on Select Column button');
        await PageHelper.click(OptimizerPage.viewManagementOptions.selectColumns);
    }

    static async verifySelectColumnsPopup() {
        const label = OptimizerPage.getSelectColumnsPopup;
        const optConst = OptimizerPageConstants.selectColumnsPopup;
        await ExpectationHelper.verifyTextContains(label.heading,
            OptimizerPageConstants.selectColumns, optConst.header);
        await ExpectationHelper.verifyDisplayedStatus(label.eachColumn, 'Column names');
        await ExpectationHelper.verifyDisplayedStatus(label.eachSelectedColumn, 'Column checkbox');
        await ExpectationHelper.verifyDisplayedStatus(label.hideAll, optConst.hideAll);
        await ExpectationHelper.verifyDisplayedStatus(label.ok, OptimizerPageConstants.ok);
        await ExpectationHelper.verifyDisplayedStatus(label.cancel, OptimizerPageConstants.cancel);
    }

    static async clickHideAll() {
        StepLogger.step('Click on Hide all button.');
        await PageHelper.click(OptimizerPage.getSelectColumnsPopup.hideAll);
    }

    static async verifyNoColumnSelected() {
        const label = OptimizerPage.getSelectColumnsPopup;
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyNotDisplayedStatus(label.eachSelectedColumn, 'Checkbox selected');
    }

    static async clickShowAll() {
        StepLogger.step('Click on Show all button.');
        await PageHelper.click(OptimizerPage.getSelectColumnsPopup.showAll);
    }

    static async verifyAllColumnSelected() {
        const label = OptimizerPage.getSelectColumnsPopup;
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyNotDisplayedStatus(label.unchecked, 'Checkbox unselected');
    }

    static async clickOKonSelectColumnPopup() {
        StepLogger.step('Click on Ok');
        await PageHelper.click(OptimizerPage.getSelectColumnsPopup.ok);
    }

    static async verifyOptimizerTabOptions() {
        const tabLabel = OptimizerPage.getTabOptions;
        await ExpectationHelper.verifyDisplayedStatus(tabLabel.optimizer, 'Optimizer tab');
        await ExpectationHelper.verifyDisplayedStatus(tabLabel.view, 'View tab');
    }

    static async verifyOptimizerTabContents() {
        const actionsLabel = OptimizerPage.getOptimizerStrategyActions;
        await ExpectationHelper.verifyDisplayedStatus(OptimizerPage.getCloseOptimizerWindow, 'Close');
        await ExpectationHelper.verifyDisplayedStatus(OptimizerPage.getConfigure, 'Configure');
        await ExpectationHelper.verifyDisplayedStatus(actionsLabel.saveStrategy, 'Save Strategy');
        await ExpectationHelper.verifyDisplayedStatus(actionsLabel.renameStrategy, 'Rename Strategy');
        await ExpectationHelper.verifyDisplayedStatus(actionsLabel.deleteStrategy, 'Delete Strategy');
        await ExpectationHelper.verifyDisplayedStatus(actionsLabel.commitStrategy, 'Commit Strategy');
        await ExpectationHelper.verifyDisplayedStatus(actionsLabel.currentStrategyDropdown,
            OptimizerPageConstants.currentStrategy);
    }

    static async verifyConfigureScreen() {
        const configLabel = OptimizerPage.getOptimizerConfiguration;
        const configConst = OptimizerPageConstants.optimizerConfiguration;
        await ExpectationHelper.verifyContainsText(configLabel.enterValueLabel,
            OptimizerPageConstants.configure, configConst.enterValueLabel);
        await ExpectationHelper.verifyContainsText(configLabel.titleComparisonLabel,
            OptimizerPageConstants.configure, configConst.titleComparisonLabel);
        await ExpectationHelper.verifyContainsText(configLabel.thirdQuestion,
            OptimizerPageConstants.configure, configConst.thirdQuestion);
        await ExpectationHelper.verifyDisplayedStatus(configLabel.ok, OptimizerPageConstants.ok);
        await ExpectationHelper.verifyDisplayedStatus(configLabel.cancel, OptimizerPageConstants.cancel);
    }

    static async clickConfigure() {
        StepLogger.step('Click on Configure button.');
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(OptimizerPage.getConfigure);
    }

    static async verifyOptimizerConfigurationPopupOpened() {
        await ExpectationHelper.verifyDisplayedStatus(OptimizerPage.getOptimizerConfiguration.heading,
            OptimizerPageConstants.configure);
    }

    static async selectAvailableFieldAndAdd() {
        const configLabel = OptimizerPage.getOptimizerConfiguration;
        StepLogger.step('Select Value from the Available Fields selection box. Click on Add button.');
        await ElementHelper.actionHoverOverAndClick(configLabel.firstAvailableField, configLabel.firstAvailableField);
        const fieldName = await PageHelper.getText(configLabel.firstAvailableField);
        await ElementHelper.actionDoubleClick(configLabel.add);
        return fieldName;
    }

    static async verifyAddedFieldInSelectedFields(fieldName: string) {
        const configLabel = OptimizerPage.getOptimizerConfiguration;
        await ExpectationHelper.verifyText(configLabel.firstSelectedField,
            OptimizerPageConstants.selectedFieldsSection, fieldName);
    }

    static async selectSelectedFieldAndRemove() {
        const configLabel = OptimizerPage.getOptimizerConfiguration;
        if (!(await PageHelper.isElementPresent(configLabel.firstSelectedField, false))) {
            await this.selectAvailableFieldAndAdd();
        }
        StepLogger.step('Select Value from the Selected Fields selection box. Click on Remove button.');
        await PageHelper.click(configLabel.firstSelectedField);
        const fieldName = await PageHelper.getText(configLabel.firstSelectedField);
        await PageHelper.click(configLabel.remove);
        return fieldName;
    }

    static async verifyRemovedFieldInAvailableFields(fieldName: string) {
        await ExpectationHelper.verifyDisplayedStatus(OptimizerPage.getAvailableFieldByName(fieldName),
            `${fieldName} in ${OptimizerPageConstants.selectedFieldsSection}`);
    }

    static async verifySaveStrategyPopup() {
        const saveStategyLabel = OptimizerPage.getOptimierSaveStrategyPopup;
        await ExpectationHelper.verifyDisplayedStatus(saveStategyLabel.strategyName,
            `Strategy Name in ${OptimizerPageConstants.saveStrategy}`);
        await ExpectationHelper.verifyDisplayedStatus(saveStategyLabel.personalStrategyCheckBox,
            `Personal strategy checkbox`);
        await ExpectationHelper.verifyDisplayedStatus(saveStategyLabel.ok,
            OptimizerPageConstants.ok);
        await ExpectationHelper.verifyDisplayedStatus(saveStategyLabel.cancel,
            OptimizerPageConstants.cancel);
    }

    static async clickRenameStrategy() {
        StepLogger.step('Click on Rename Strategy button.');
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.renameStrategy);
    }

    static async verifyRenameStrategyPopup() {
        const renameStategyLabel = OptimizerPage.getRenameStrategyPopup;
        await ExpectationHelper.verifyDisplayedStatus(renameStategyLabel.strategyName,
            `Strategy Name in ${OptimizerPageConstants.renameStrategy}`);
        await ExpectationHelper.verifyDisplayedStatus(renameStategyLabel.ok,
            OptimizerPageConstants.ok);
        await ExpectationHelper.verifyDisplayedStatus(renameStategyLabel.cancel,
            OptimizerPageConstants.cancel);
    }

    static async selectStrategyFromCurrentStrategy() {
        StepLogger.step('Select strategy from current strategy');
        const label = OptimizerPage.getOptimizerStrategyActions;
        await PageHelper.click(OptimizerPage.getOptimizerStrategyActions.currentStrategyDropdown);
        // takes time to expand dropdown
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(label.currentStrategyDropdownValue);
        await browser.sleep(PageHelper.timeout.xs);
    }

    static async verifyViewTabContent() {
        const viewTabLabel = OptimizerPage.viewManagementOptions;
        await ExpectationHelper.verifyDisplayedStatus(viewTabLabel.saveView, 'Save view');
        await ExpectationHelper.verifyDisplayedStatus(viewTabLabel.renameView, 'Rename view');
        await ExpectationHelper.verifyDisplayedStatus(viewTabLabel.deleteView, 'Delete view');
        await ExpectationHelper.verifyDisplayedStatus(viewTabLabel.clearSorting, 'Clear sorting');
        await ExpectationHelper.verifyDisplayedStatus(viewTabLabel.selectColumns, 'Select columns');
        await ExpectationHelper.verifyDisplayedStatus(viewTabLabel.currentViewDropdown,
            OptimizerPageConstants.currentView);
    }

    static async verifyCurrentViewDropdown() {
        await ExpectationHelper.verifyDisplayedStatus(OptimizerPage.viewManagementOptions.currentViewDropdown,
            'Current View Dropdown');
    }
}
