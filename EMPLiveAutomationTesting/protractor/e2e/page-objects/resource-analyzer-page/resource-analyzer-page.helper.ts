import {StepLogger} from '../../../core/logger/step-logger';
import {PageHelper} from '../../components/html/page-helper';
import {ResourceAnalyzerPage} from './resource-analyzer-page.po';
import {ValidationsHelper} from '../../components/misc-utils/validation-helper';
import {ResourceAnalyzerPageConstants} from './resource-analyzer-page.constants';
import {CommonPage} from '../pages/common/common.po';
import {WaitHelper} from '../../components/html/wait-helper';
import {CommonPageHelper} from '../pages/common/common-page.helper';
import {CommonPageConstants} from '../pages/common/common-page.constants';

export class ResourceAnalyzerPageHelper {

    static async clickDisplayButton(stepLogger: StepLogger) {
        stepLogger.step('Click On display Button  ');
        return PageHelper.click(ResourceAnalyzerPage.display);
    }

    static async validateTopPannelAnalyserTab(stepLogger: StepLogger) {
        stepLogger.step('Validating Print is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelAnalyserTab.print))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelAnalyzerTab.print));

        stepLogger.step('Validating Publish is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelAnalyserTab.publish))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelAnalyzerTab.publish));

        stepLogger.step('Validating Save Scenario is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelAnalyserTab.saveScenario))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelAnalyzerTab.saveScenario));

        stepLogger.step('Validating Undo Button is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelAnalyserTab.undoButton))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelAnalyzerTab.undoButton));

        stepLogger.step('Validating Change Calendar is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelAnalyserTab.changeCalendar))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelAnalyzerTab.changeCalendar));

        stepLogger.step('Validating Show TimeSheet Actual is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelAnalyserTab.showTimeSheetActual))
        .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelAnalyzerTab.showTimeSheetActual));

        stepLogger.step('Validating Show Committed Work is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelAnalyserTab.showCommittedWork))
        .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelAnalyzerTab.showCommittedWork));

        stepLogger.step('Validating Export To Excel is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelAnalyserTab.exportToExcel))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelAnalyzerTab.exportToExcel));

    }

    static async validateTopPannelViewTab(stepLogger: StepLogger) {

        stepLogger.step('Undo Button   is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.undo))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.undoButton));

        stepLogger.step('Save Scenario  is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.saveScenario))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.saveScenario));

        stepLogger.step('Show Grouping is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.showGrouping))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.showGrouping));

        stepLogger.step('Show Filter is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.showFilter))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.showFilter));

        stepLogger.step('To Period is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.toPeriod))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.toPeriod));

        stepLogger.step('From Period is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.fromPeriod))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.fromPeriod));

        stepLogger.step('Collapse All is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.collapseAll))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.collapseAll));

        stepLogger.step('Expand All is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.expandAll))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.expandAll));

        stepLogger.step('select Columns is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.selectColumns))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.selectColumns));

        stepLogger.step('Hide Details is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.hideDetails))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.hideDetails));

        stepLogger.step('show Bars is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.showBars))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.showBars));

        stepLogger.step('Clear Sorting is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.clearSorting))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.clearSorting));

        stepLogger.step('Delete View is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.deleteViewBtn))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.deleteViewBtn));

        stepLogger.step('Rename View is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.renameView))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.renameViewBtn));

        stepLogger.step('save View is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.saveView))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.saveView));

        stepLogger.step('Edit Resource is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.topPannelViewTab.editResource))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.topPannelViewTab.editResource));
    }
    static async validatebottomPannel(stepLogger: StepLogger) {

        stepLogger.step('Expend All is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.bottomPannel.expandAll))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.bottomPannel.expandAll));

        stepLogger.step('Collapse All is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.bottomPannel.collapseAll))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.bottomPannel.collapseAll));

        stepLogger.step('Show Filter is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.bottomPannel.showFilter))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.bottomPannel.showFilter));

        stepLogger.step('Show Grouping is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.bottomPannel.showGrouping))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.bottomPannel.showGrouping));

        stepLogger.step('Print is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.bottomPannel.print))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.bottomPannel.print));

        stepLogger.step('Select Column is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.bottomPannel.selectColumn))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.bottomPannel.selectColumn));

        stepLogger.step('Capacity Scenarios is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.bottomPannel.capacityScenarios))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.bottomPannel.capacityScenarios));

        stepLogger.step('legend is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.bottomPannel.legend))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.bottomPannel.legend));

        stepLogger.step('Remove Sorting is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.bottomPannel.removeSorting))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.bottomPannel.removeSorting));

        stepLogger.step('Export Excel is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.bottomPannel.exportExcel))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.bottomPannel.exportExcel));

        stepLogger.step('Expand All is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.bottomPannel.expandAll))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.bottomPannel.expandAll));

        stepLogger.step('Show Details is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.bottomPannel.showDetails))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.bottomPannel.showDetails));

        stepLogger.step('show Graph is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.bottomPannel.showGraph))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.bottomPannel.showGraph));

        stepLogger.step('Total Column is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.bottomPannel.totalColumn))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourceAnalyzerPageConstants.bottomPannel.totalColumn));
    }
    static async verifyResourceAnalyzerCancelButtonFunctionality(stepLogger: StepLogger, item = CommonPage.record) {
        await CommonPageHelper.selectRecordFromGrid(stepLogger, item);
        stepLogger.step('Select "Edit Resource Analyzer" from the options displayed');
        await PageHelper.click(CommonPage.ribbonItems.resourceAnalyzer);
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(ResourceAnalyzerPage.cancel);
        await PageHelper.switchToDefaultContent();
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        stepLogger.step('Display button is present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.display))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(ResourceAnalyzerPageConstants.display));
        stepLogger.step('Cancel button is present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.cancel))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(ResourceAnalyzerPageConstants.cancel));
        stepLogger.step('Fiscal Calendar Drop Down is present');
        await expect(await PageHelper.isElementDisplayed(ResourceAnalyzerPage.fiscalCalendarDropDown))
            .toBe(true, ValidationsHelper.getButtonDisplayedValidation(ResourceAnalyzerPageConstants.fiscalCalendarDropDown));
        await PageHelper.click(ResourceAnalyzerPage.cancel);
        stepLogger.step('Project Center Page is displayed');
        await WaitHelper.getInstance().waitForElementToBeClickable(CommonPage.ribbonItems.resourceAnalyzer);
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.resourceAnalyzer))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));
    }
}
