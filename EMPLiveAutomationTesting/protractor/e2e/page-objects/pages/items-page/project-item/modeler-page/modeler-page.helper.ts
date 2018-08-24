import {ExpectationHelper} from '../../../../../components/misc-utils/expectation-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ModelerPage} from './modeler.po';
import {ModelerPageConstants} from './modeler-page.constants';
import {PageHelper} from '../../../../../components/html/page-helper';
import {browser} from 'protractor';
import {HtmlHelper} from '../../../../../components/misc-utils/html-helper';
import {CommonPageHelper} from '../../../common/common-page.helper';

export class ModelerPageHelper {
    static async verifyModelerPopupDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyText(
            ModelerPage.selectModelAndVersionsPopup.title,
            ModelerPageConstants.selectModel,
            ModelerPageConstants.selectModelAndVersionsPopup.title,
            stepLogger);
    }

    static async verifyModelerPopupContent(stepLogger: StepLogger) {
        const modelAndVersionPopupItems = ModelerPage.selectModelAndVersionsPopup;
        await ExpectationHelper.verifyText(
            modelAndVersionPopupItems.title,
            ModelerPageConstants.selectModel,
            ModelerPageConstants.selectModelAndVersionsPopup.title,
            stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(modelAndVersionPopupItems.selectModelDropdown,
            ModelerPageConstants.selectModelDropdown, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(modelAndVersionPopupItems.versionsSelectionBox,
            ModelerPageConstants.selectVersions, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(modelAndVersionPopupItems.ok,  ModelerPageConstants.ok, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(modelAndVersionPopupItems.cancel,  ModelerPageConstants.cancel, stepLogger);
    }

    static async clickOkButtonOnPopup(stepLogger: StepLogger) {
        stepLogger.step('Click on "OK" button.');
        await PageHelper.click(ModelerPage.selectModelAndVersionsPopup.ok);
    }

    static async verifyDisplayTabSelectedDefault(stepLogger: StepLogger) {
        await ExpectationHelper.verifyText(ModelerPage.activeTab, ModelerPageConstants.activeTab,
            ModelerPageConstants.tabNames.display, stepLogger);
    }

    static async clickViewTab(stepLogger: StepLogger) {
        stepLogger.step('Click on View tab');
        await PageHelper.click(ModelerPage.getTabOptions.view);
    }

    static async verifyViewTabDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyText(
            ModelerPage.activeTab,
            ModelerPageConstants.viewTab,
            ModelerPageConstants.tabNames.view,
            stepLogger);
    }

    static async modelerPageDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(ModelerPage.displayTabOptions.searchSettings,
            ModelerPageConstants.modeler, stepLogger);
    }

    static async clicksSearchSettings(stepLogger: StepLogger) {
        stepLogger.step('Click on Search setting button.');
        await PageHelper.click(ModelerPage.displayTabOptions.searchSettings);
    }

    static async verifySearchSettingsPopup(stepLogger: StepLogger) {
        const selectSettingsPopupItems = ModelerPage.searchSettingsPopup;
        await ExpectationHelper.verifyDisplayedStatus(selectSettingsPopupItems.searchFor,
            ModelerPageConstants.settingsSearch, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(selectSettingsPopupItems.where,
            ModelerPageConstants.settingsWhere, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(selectSettingsPopupItems.in,
            ModelerPageConstants.settingsIn, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(selectSettingsPopupItems.details,
            ModelerPageConstants.settingsDetails, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(selectSettingsPopupItems.totals,
            ModelerPageConstants.settingsTotals, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(selectSettingsPopupItems.ok,  ModelerPageConstants.ok, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(selectSettingsPopupItems.cancel,  ModelerPageConstants.cancel, stepLogger);
    }

    static async verifyFindNext(stepLogger: StepLogger) {
        // Takes time to load elements
        await browser.sleep(PageHelper.timeout.s);
        await ExpectationHelper.verifyAttributeContains(
            ModelerPage.displayTabOptions.findNext,
            HtmlHelper.attributes.class,
            ModelerPageConstants.disabled,
            stepLogger);
    }

    static async clickSaveVersion(stepLogger: StepLogger) {
        stepLogger.step('Click on Save Version button.');
        await PageHelper.click(ModelerPage.displayTabOptions.saveVersion);
    }

    static async verifySelectVersionsSelectionBox(stepLogger: StepLogger) {
        const modelAndVersionPopupItems = ModelerPage.selectModelAndVersionsPopup;
        await ExpectationHelper.verifyText(
            modelAndVersionPopupItems.selectedOptionVersionsBox,
            ModelerPageConstants.selectVersionDefault,
            ModelerPageConstants.defaultSelectedOption,
            stepLogger);
        let i: number;
        for (i = 0; i < 4 ; i++) {
            await ExpectationHelper.verifyText(
                ModelerPage.getSelectVersionOptionText(i + 1),
                ModelerPageConstants.selectVersionsOptionsText,
                ModelerPageConstants.selectVersionsOptions[i], stepLogger);
        }
    }

    static async clickCancelButton(stepLogger: StepLogger) {
        stepLogger.step('Click on Cancel button.');
        await PageHelper.click(ModelerPage.selectModelAndVersionsPopup.cancel);
    }

    static async verifyModelerPopupClosed(stepLogger: StepLogger) {
        // takes time to close the popup
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyNotDisplayedStatus(
            ModelerPage.selectModelAndVersionsPopup.selectModelDropdown,
            ModelerPageConstants.selectModel,
            stepLogger);
    }

    static async verifyDisplayTabContent(stepLogger: StepLogger) {
        const displayTabItems = ModelerPage.displayTabOptions;
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.close, ModelerPageConstants.close, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.totalDetails, ModelerPageConstants.totalDetails, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.searchSettings, ModelerPageConstants.searchSettings, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.totalDetails, ModelerPageConstants.totalDetails, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.findNext, ModelerPageConstants.findNext, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.saveVersion, ModelerPageConstants.saveVersion, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.copyVersion, ModelerPageConstants.copyVersion, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.exportToExcel, ModelerPageConstants.exportToExcel, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.print, ModelerPageConstants.print, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.detailsTopGrid, ModelerPageConstants.detailsTopGrid, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.applyTarget, ModelerPageConstants.applyTarget, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.totalsDetails, ModelerPageConstants.totalsDetails, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.createTarget, ModelerPageConstants.createTarget, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.editTarget, ModelerPageConstants.editTarget, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.deleteTarget, ModelerPageConstants.deleteTarget, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.copyTarget, ModelerPageConstants.copyTarget, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.exportToExcelBottom,
            ModelerPageConstants.exportToExcelBottom, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.print, ModelerPageConstants.printBottom, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.totalsBottomGrid, ModelerPageConstants.totalsBottomGrid, stepLogger);
    }

    static async clickCloseButtonDisplayTab(stepLogger: StepLogger) {
        stepLogger.step('Click on close button.');
        await PageHelper.click(ModelerPage.displayTabOptions.close);
    }

    static async verifyModelerPageClosed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyNotDisplayedStatus(
            ModelerPage.displayTabOptions.searchSettings,
            ModelerPageConstants.modeler,
            stepLogger);
    }

    static async verifyNoVersionsAlert(stepLogger: StepLogger) {
        // Takes time to open alert
        await browser.sleep(PageHelper.timeout.s);
        const actualAlertText = await PageHelper.getAlertText();
        await ExpectationHelper.verifyStringEqualTo(
            actualAlertText,
            ModelerPageConstants.noVersionsPopupText,
            stepLogger);
    }

    static async verifyCopyVersionPopup(stepLogger: StepLogger) {
        const copyVersionItems = ModelerPage.copyVersionPopup;
        await ExpectationHelper.verifyDisplayedStatus(copyVersionItems.from,
            ModelerPageConstants.from, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(copyVersionItems.to,
            ModelerPageConstants.to, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(copyVersionItems.notInToVersion,
            ModelerPageConstants.notInToVersion, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(copyVersionItems.bothVersions,
            ModelerPageConstants.bothVersions, stepLogger);
    }

    static async clickOkCopyVersion(stepLogger: StepLogger) {
        stepLogger.step('Click on Copy Version button.');
        await PageHelper.click(ModelerPage.displayTabOptions.copyVersion);
    }

    static async clickMinusSignOnBothRibbons(stepLogger: StepLogger) {
        const ribbonItems = ModelerPage.collapseAndExpandRibbons;
        stepLogger.step('Click on Minus Sign to the right in the top and bottom ribbons to collapse the ribbon.');
        await PageHelper.click(ribbonItems.minusSignTopRibbon);
        await PageHelper.click(ribbonItems.minusSignBottomRibbon);
    }

    static async verifyBothRibbonsCollapsed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(ModelerPage.collapseAndExpandRibbons.collapseViewTopRibbon,
            ModelerPageConstants.collapsedTopRibbon, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(ModelerPage.collapseAndExpandRibbons.collapseViewBottomRibbon,
            ModelerPageConstants.collapsedBottomRibbon, stepLogger);
    }

    static async clickApplyTarget(stepLogger: StepLogger) {
        stepLogger.step('Click on Apply Target button.');
        await PageHelper.click(ModelerPage.displayTabOptions.applyTarget);
    }

    static async verifyNoTargetsAlert(stepLogger: StepLogger) {
        // Takes time to open alert
        await browser.sleep(PageHelper.timeout.xs);
        const actualAlertText = await PageHelper.getAlertText();
        await ExpectationHelper.verifyStringEqualTo(
            actualAlertText,
            ModelerPageConstants.noTargetsAlertText,
            stepLogger);
    }

    static async verifyViewTabContent(stepLogger: StepLogger) {
        const viewTabOptions = ModelerPage.viewTabOptions;
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.close, ModelerPageConstants.close, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.saveView, ModelerPageConstants.saveView, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.renameView, ModelerPageConstants.renameView, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.deleteView, ModelerPageConstants.deleteView, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.sortAndGroup, ModelerPageConstants.sortAndGroup, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.columnOrder, ModelerPageConstants.columnOrder, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.periodsAndValues, ModelerPageConstants.periodsAndValues, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.showGantt, ModelerPageConstants.showGantt, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.ganttZoom, ModelerPageConstants.ganttZoom, stepLogger);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.currentView, ModelerPageConstants.currentView, stepLogger);
    }

    static async verifyViewTabClosedAndRedirect(stepLogger: StepLogger) {
        await ExpectationHelper.verifyNotDisplayedStatus(
            ModelerPage.viewTabOptions.saveView,
            ModelerPageConstants.viewTab,
            stepLogger);
        await CommonPageHelper.verifyProjectCenterDisplayed(stepLogger);
    }

    static async clickCloseButtonViewTab(stepLogger: StepLogger) {
        stepLogger.step('Click on close button.');
        await PageHelper.click(ModelerPage.viewTabOptions.close);
    }
}
