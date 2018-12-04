import {StepLogger} from '../../../../core/logger/step-logger';
import {PageHelper} from '../../../components/html/page-helper';
import {ResourceAnalyzerPage} from './resource-analyzer-page.po';
import {ResourceAnalyzerPageConstants} from './resource-analyzer-page.constants';
import {CommonPage} from '../common/common.po';
import {CommonPageHelper} from '../common/common-page.helper';
import {CommonPageConstants} from '../common/common-page.constants';
import {WaitHelper} from '../../../components/html/wait-helper';

export class ResourceAnalyzerPageHelper {

    static async clickDisplayButton() {
        StepLogger.step('Click On display Button  ');
        return PageHelper.click(ResourceAnalyzerPage.display);
    }

    static async validateTopPannelAnalyserTab() {
        StepLogger.verification('Validating Print is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelAnalyserTab.print, ResourceAnalyzerPageConstants.topPannelAnalyzerTab.print);

        StepLogger.verification('Validating Publish is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelAnalyserTab.publish, ResourceAnalyzerPageConstants.topPannelAnalyzerTab.publish);

        StepLogger.verification('Validating Save Scenario is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelAnalyserTab.saveScenario, ResourceAnalyzerPageConstants.topPannelAnalyzerTab.saveScenario);

        StepLogger.verification('Validating Undo Button is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelAnalyserTab.undoButton, ResourceAnalyzerPageConstants.topPannelAnalyzerTab.undoButton);

        StepLogger.verification('Validating Change Calendar is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelAnalyserTab.changeCalendar, ResourceAnalyzerPageConstants.topPannelAnalyzerTab.changeCalendar);

        StepLogger.verification('Validating Show TimeSheet Actual is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelAnalyserTab.showTimeSheetActual, ResourceAnalyzerPageConstants.topPannelAnalyzerTab.showTimeSheetActual);

        StepLogger.verification('Validating Show Committed Work is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelAnalyserTab.showCommittedWork, ResourceAnalyzerPageConstants.topPannelAnalyzerTab.showCommittedWork);

        StepLogger.verification('Validating Export To Excel is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelAnalyserTab.exportToExcel, ResourceAnalyzerPageConstants.topPannelAnalyzerTab.exportToExcel);

    }

    static async validateTopPannelViewTab() {

        StepLogger.verification('Undo Button   is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.undo, ResourceAnalyzerPageConstants.topPannelViewTab.undoButton);

        StepLogger.verification('Save Scenario  is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.saveScenario, ResourceAnalyzerPageConstants.topPannelViewTab.saveScenario);

        StepLogger.verification('Show Grouping is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.showGrouping, ResourceAnalyzerPageConstants.topPannelViewTab.showGrouping);

        StepLogger.verification('Show Filter is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.showFilter, ResourceAnalyzerPageConstants.topPannelViewTab.showFilter);

        StepLogger.verification('To Period is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.toPeriod, ResourceAnalyzerPageConstants.topPannelViewTab.toPeriod);

        StepLogger.verification('From Period is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.fromPeriod, ResourceAnalyzerPageConstants.topPannelViewTab.fromPeriod);

        StepLogger.verification('Collapse All is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.collapseAll, ResourceAnalyzerPageConstants.topPannelViewTab.collapseAll);

        StepLogger.verification('Expand All is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.expandAll, ResourceAnalyzerPageConstants.topPannelViewTab.expandAll);

        StepLogger.verification('select Columns is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.selectColumns, ResourceAnalyzerPageConstants.topPannelViewTab.selectColumns);

        StepLogger.verification('Hide Details is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.hideDetails, ResourceAnalyzerPageConstants.topPannelViewTab.hideDetails);

        StepLogger.verification('show Bars is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.showBars, ResourceAnalyzerPageConstants.topPannelViewTab.showBars);

        StepLogger.verification('Clear Sorting is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.clearSorting, ResourceAnalyzerPageConstants.topPannelViewTab.clearSorting);

        StepLogger.verification('Delete View is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.deleteViewBtn, ResourceAnalyzerPageConstants.topPannelViewTab.deleteViewBtn);

        StepLogger.verification('Rename View is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.renameView, ResourceAnalyzerPageConstants.topPannelViewTab.renameViewBtn);

        StepLogger.verification('save View is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.saveView, ResourceAnalyzerPageConstants.topPannelViewTab.saveView);

        StepLogger.verification('Edit Resource is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.editResource, ResourceAnalyzerPageConstants.topPannelViewTab.editResource);
    }

    static async validateBottomPannel() {

        StepLogger.verification('Expend All is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.expandAll, ResourceAnalyzerPageConstants.bottomPannel.expandAll);

        StepLogger.verification('Collapse All is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.collapseAll, ResourceAnalyzerPageConstants.bottomPannel.collapseAll);

        StepLogger.verification('Show Filter is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.showFilter, ResourceAnalyzerPageConstants.bottomPannel.showFilter);

        StepLogger.verification('Show Grouping is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.showGrouping, ResourceAnalyzerPageConstants.bottomPannel.showGrouping);

        StepLogger.verification('Print is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.print, ResourceAnalyzerPageConstants.bottomPannel.print);

        StepLogger.verification('Select Column is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.selectColumn, ResourceAnalyzerPageConstants.bottomPannel.selectColumn);

        StepLogger.verification('Capacity Scenarios is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.capacityScenarios, ResourceAnalyzerPageConstants.bottomPannel.capacityScenarios);

        StepLogger.verification('legend is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.legend, ResourceAnalyzerPageConstants.bottomPannel.legend);

        StepLogger.verification('Remove Sorting is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.removeSorting, ResourceAnalyzerPageConstants.bottomPannel.removeSorting);

        StepLogger.verification('Export Excel is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.exportExcel, ResourceAnalyzerPageConstants.bottomPannel.exportExcel);

        StepLogger.verification('Expand All is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.expandAll, ResourceAnalyzerPageConstants.bottomPannel.expandAll);

        StepLogger.verification('Show Details is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.showDetails, ResourceAnalyzerPageConstants.bottomPannel.showDetails);

        StepLogger.verification('show Graph is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.showGraph, ResourceAnalyzerPageConstants.bottomPannel.showGraph);

        StepLogger.verification('Total Column is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.totalColumn, ResourceAnalyzerPageConstants.bottomPannel.totalColumn);

    }

    static async verifyResourceAnalyzerCancelButtonFunctionality() {
        await CommonPageHelper.resourceAnalyzerPopUp();

        StepLogger.verification('Display button is present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.display, ResourceAnalyzerPageConstants.display);

        StepLogger.verification('Cancel button is present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.cancel, ResourceAnalyzerPageConstants.cancel);

        StepLogger.verification('Fiscal Calendar Drop Down is present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.fiscalCalendarDropDown, ResourceAnalyzerPageConstants.fiscalCalendarDropDown);

        await this.cancelResourceAnalyzerPopUp();

        StepLogger.verification('Project Center Page is displayed');
        await CommonPageHelper.fieldDisplayedValidation
        (CommonPage.ribbonItems.resourceAnalyzer, CommonPageConstants.pageHeaders.projects.projectCenter);
    }

    static async cancelResourceAnalyzerPopUp() {
        StepLogger.step('cancel Resource Analyzer PopUp');
        await PageHelper.click(ResourceAnalyzerPage.cancel);

        StepLogger.subStep('Switch to default content');
        await WaitHelper.waitForElementToBeHidden(ResourceAnalyzerPage.cancel);
        await PageHelper.switchToDefaultContent();
    }
}
