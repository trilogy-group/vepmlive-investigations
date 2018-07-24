import {StepLogger} from '../../../../core/logger/step-logger';
import {PageHelper} from '../../../components/html/page-helper';
import {ResourceAnalyzerPage} from './resource-analyzer-page.po';
import {ResourceAnalyzerPageConstants} from './resource-analyzer-page.constants';
import {CommonPage} from '../common/common.po';
import {CommonPageHelper} from '../common/common-page.helper';
import {CommonPageConstants} from '../common/common-page.constants';

export class ResourceAnalyzerPageHelper {

    static async clickDisplayButton(stepLogger: StepLogger) {
        stepLogger.step('Click On display Button  ');
        return PageHelper.click(ResourceAnalyzerPage.display);
    }

    static async validateTopPannelAnalyserTab(stepLogger: StepLogger) {
        stepLogger.verification('Validating Print is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelAnalyserTab.print , ResourceAnalyzerPageConstants.topPannelAnalyzerTab.print );

        stepLogger.verification('Validating Publish is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelAnalyserTab.publish , ResourceAnalyzerPageConstants.topPannelAnalyzerTab.publish );

        stepLogger.verification('Validating Save Scenario is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelAnalyserTab.saveScenario , ResourceAnalyzerPageConstants.topPannelAnalyzerTab.saveScenario );

        stepLogger.verification('Validating Undo Button is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelAnalyserTab.undoButton , ResourceAnalyzerPageConstants.topPannelAnalyzerTab.undoButton );

        stepLogger.verification('Validating Change Calendar is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelAnalyserTab.changeCalendar , ResourceAnalyzerPageConstants.topPannelAnalyzerTab.changeCalendar );

        stepLogger.verification('Validating Show TimeSheet Actual is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.
            topPannelAnalyserTab.showTimeSheetActual , ResourceAnalyzerPageConstants.topPannelAnalyzerTab.showTimeSheetActual );

        stepLogger.verification('Validating Show Committed Work is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.
            topPannelAnalyserTab.showCommittedWork , ResourceAnalyzerPageConstants.topPannelAnalyzerTab.showCommittedWork );

        stepLogger.verification('Validating Export To Excel is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.
            topPannelAnalyserTab.exportToExcel , ResourceAnalyzerPageConstants.topPannelAnalyzerTab.exportToExcel );

    }

    static async validateTopPannelViewTab(stepLogger: StepLogger) {

        stepLogger.verification('Undo Button   is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.undo , ResourceAnalyzerPageConstants.topPannelViewTab.undoButton );

        stepLogger.verification('Save Scenario  is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.saveScenario , ResourceAnalyzerPageConstants.topPannelViewTab.saveScenario );

        stepLogger.verification('Show Grouping is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.showGrouping , ResourceAnalyzerPageConstants.topPannelViewTab.showGrouping );

        stepLogger.verification('Show Filter is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.showFilter , ResourceAnalyzerPageConstants.topPannelViewTab.showFilter );

        stepLogger.verification('To Period is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.toPeriod , ResourceAnalyzerPageConstants.topPannelViewTab.toPeriod );

        stepLogger.verification('From Period is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.fromPeriod , ResourceAnalyzerPageConstants.topPannelViewTab.fromPeriod );

        stepLogger.verification('Collapse All is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.collapseAll , ResourceAnalyzerPageConstants.topPannelViewTab.collapseAll );

        stepLogger.verification('Expand All is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.expandAll , ResourceAnalyzerPageConstants.topPannelViewTab.expandAll );

        stepLogger.verification('select Columns is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.selectColumns , ResourceAnalyzerPageConstants.topPannelViewTab.selectColumns );

        stepLogger.verification('Hide Details is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.hideDetails , ResourceAnalyzerPageConstants.topPannelViewTab.hideDetails );

        stepLogger.verification('show Bars is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.showBars , ResourceAnalyzerPageConstants.topPannelViewTab.showBars );

        stepLogger.verification('Clear Sorting is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.clearSorting , ResourceAnalyzerPageConstants.topPannelViewTab.clearSorting );

        stepLogger.verification('Delete View is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.deleteViewBtn , ResourceAnalyzerPageConstants.topPannelViewTab.deleteViewBtn );

        stepLogger.verification('Rename View is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.renameView , ResourceAnalyzerPageConstants.topPannelViewTab.renameViewBtn );

        stepLogger.verification('save View is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.saveView , ResourceAnalyzerPageConstants.topPannelViewTab.saveView );

        stepLogger.verification('Edit Resource is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.topPannelViewTab.editResource , ResourceAnalyzerPageConstants.topPannelViewTab.editResource );
    }
    static async validateBottomPannel(stepLogger: StepLogger) {

        stepLogger.verification('Expend All is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.expandAll , ResourceAnalyzerPageConstants.bottomPannel.expandAll );

        stepLogger.verification('Collapse All is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.collapseAll , ResourceAnalyzerPageConstants.bottomPannel.collapseAll );

        stepLogger.verification('Show Filter is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.showFilter , ResourceAnalyzerPageConstants.bottomPannel.showFilter );

        stepLogger.verification('Show Grouping is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.showGrouping , ResourceAnalyzerPageConstants.bottomPannel.showGrouping );

        stepLogger.verification('Print is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.print , ResourceAnalyzerPageConstants.bottomPannel.print );

        stepLogger.verification('Select Column is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.selectColumn , ResourceAnalyzerPageConstants.bottomPannel.selectColumn );

        stepLogger.verification('Capacity Scenarios is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.capacityScenarios , ResourceAnalyzerPageConstants.bottomPannel.capacityScenarios );

        stepLogger.verification('legend is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.legend , ResourceAnalyzerPageConstants.bottomPannel.legend );

        stepLogger.verification('Remove Sorting is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.removeSorting , ResourceAnalyzerPageConstants.bottomPannel.removeSorting );

        stepLogger.verification('Export Excel is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.exportExcel , ResourceAnalyzerPageConstants.bottomPannel.exportExcel );

        stepLogger.verification('Expand All is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.expandAll , ResourceAnalyzerPageConstants.bottomPannel.expandAll );

        stepLogger.verification('Show Details is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.showDetails , ResourceAnalyzerPageConstants.bottomPannel.showDetails );

        stepLogger.verification('show Graph is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.showGraph , ResourceAnalyzerPageConstants.bottomPannel.showGraph );

        stepLogger.verification('Total Column is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.bottomPannel.totalColumn , ResourceAnalyzerPageConstants.bottomPannel.totalColumn );

    }

    static async verifyResourceAnalyzerCancelButtonFunctionality(stepLogger: StepLogger) {
        await CommonPageHelper.resourceAnalyzerPopUp(stepLogger);

        stepLogger.verification('Display button is present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.display , ResourceAnalyzerPageConstants.display);

        stepLogger.verification('Cancel button is present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.cancel , ResourceAnalyzerPageConstants.cancel);

        stepLogger.verification('Fiscal Calendar Drop Down is present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceAnalyzerPage.fiscalCalendarDropDown , ResourceAnalyzerPageConstants.fiscalCalendarDropDown);

        await this.cancelResourceAnalyzerPopUp(stepLogger);

        stepLogger.verification('Project Center Page is displayed');
        await CommonPageHelper.fieldDisplayedValidation
        (CommonPage.ribbonItems.resourceAnalyzer , CommonPageConstants.pageHeaders.projects.projectCenter);
   }
    static async cancelResourceAnalyzerPopUp(stepLogger: StepLogger) {
        stepLogger.step('cancel Resource Analyzer PopUp');
        await PageHelper.click(ResourceAnalyzerPage.cancel);
    }
}
