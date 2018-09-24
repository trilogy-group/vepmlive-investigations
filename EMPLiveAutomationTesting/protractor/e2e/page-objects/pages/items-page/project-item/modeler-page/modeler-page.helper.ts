import {ExpectationHelper} from '../../../../../components/misc-utils/expectation-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ModelerPage} from './modeler.po';
import {ModelerPageConstants} from './modeler-page.constants';
import {PageHelper} from '../../../../../components/html/page-helper';
import {browser} from 'protractor';
import {HtmlHelper} from '../../../../../components/misc-utils/html-helper';
import {CommonPageHelper} from '../../../common/common-page.helper';

export class ModelerPageHelper {
    static async verifyModelerPopupDisplayed() {
        await ExpectationHelper.verifyText(
            ModelerPage.selectModelAndVersionsPopup.title,
            ModelerPageConstants.selectModel,
            ModelerPageConstants.selectModelAndVersionsPopup.title,
        );
    }

    static async verifyModelerPopupContent() {
        const modelAndVersionPopupItems = ModelerPage.selectModelAndVersionsPopup;
        await ExpectationHelper.verifyText(
            modelAndVersionPopupItems.title,
            ModelerPageConstants.selectModel,
            ModelerPageConstants.selectModelAndVersionsPopup.title,
        );
        await ExpectationHelper.verifyDisplayedStatus(modelAndVersionPopupItems.selectModelDropdown,
            ModelerPageConstants.selectModelDropdown);
        await ExpectationHelper.verifyDisplayedStatus(modelAndVersionPopupItems.versionsSelectionBox,
            ModelerPageConstants.selectVersions);
        await ExpectationHelper.verifyDisplayedStatus(modelAndVersionPopupItems.ok, ModelerPageConstants.ok);
        await ExpectationHelper.verifyDisplayedStatus(modelAndVersionPopupItems.cancel, ModelerPageConstants.cancel);
    }

    static async clickOkButtonOnPopup() {
        StepLogger.step('Click on "OK" button.');
        await PageHelper.click(ModelerPage.selectModelAndVersionsPopup.ok);
    }

    static async verifyDisplayTabSelectedDefault() {
        await ExpectationHelper.verifyText(ModelerPage.activeTab, ModelerPageConstants.activeTab,
            ModelerPageConstants.tabNames.display);
    }

    static async clickViewTab() {
        StepLogger.step('Click on View tab');
        await PageHelper.click(ModelerPage.getTabOptions.view);
    }

    static async verifyViewTabDisplayed() {
        await ExpectationHelper.verifyText(
            ModelerPage.activeTab,
            ModelerPageConstants.viewTab,
            ModelerPageConstants.tabNames.view,
        );
    }

    static async modelerPageDisplayed() {
        await ExpectationHelper.verifyDisplayedStatus(ModelerPage.displayTabOptions.searchSettings,
            ModelerPageConstants.modeler);
    }

    static async clicksSearchSettings() {
        StepLogger.step('Click on Search setting button.');
        await PageHelper.click(ModelerPage.displayTabOptions.searchSettings);
    }

    static async verifySearchSettingsPopup() {
        const selectSettingsPopupItems = ModelerPage.searchSettingsPopup;
        await ExpectationHelper.verifyDisplayedStatus(selectSettingsPopupItems.searchFor,
            ModelerPageConstants.settingsSearch);
        await ExpectationHelper.verifyDisplayedStatus(selectSettingsPopupItems.where,
            ModelerPageConstants.settingsWhere);
        await ExpectationHelper.verifyDisplayedStatus(selectSettingsPopupItems.in,
            ModelerPageConstants.settingsIn);
        await ExpectationHelper.verifyDisplayedStatus(selectSettingsPopupItems.details,
            ModelerPageConstants.settingsDetails);
        await ExpectationHelper.verifyDisplayedStatus(selectSettingsPopupItems.totals,
            ModelerPageConstants.settingsTotals);
        await ExpectationHelper.verifyDisplayedStatus(selectSettingsPopupItems.ok, ModelerPageConstants.ok);
        await ExpectationHelper.verifyDisplayedStatus(selectSettingsPopupItems.cancel, ModelerPageConstants.cancel);
    }

    static async verifyFindNext() {
        // Takes time to load elements
        await browser.sleep(PageHelper.timeout.s);
        await ExpectationHelper.verifyAttributeContains(
            ModelerPage.displayTabOptions.findNext,
            HtmlHelper.attributes.class,
            ModelerPageConstants.disabled,
        );
    }

    static async clickSaveVersion() {
        StepLogger.step('Click on Save Version button.');
        await PageHelper.click(ModelerPage.displayTabOptions.saveVersion);
    }

    static async verifySelectVersionsSelectionBox() {
        const modelAndVersionPopupItems = ModelerPage.selectModelAndVersionsPopup;
        await ExpectationHelper.verifyText(
            modelAndVersionPopupItems.selectedOptionVersionsBox,
            ModelerPageConstants.selectVersionDefault,
            ModelerPageConstants.defaultSelectedOption,
        );
        let i: number;
        for (i = 0; i < 4 ; i++) {
            await ExpectationHelper.verifyText(
                ModelerPage.getSelectVersionOptionText(i + 1),
                ModelerPageConstants.selectVersionsOptionsText,
                ModelerPageConstants.selectVersionsOptions[i]);
        }
    }

    static async clickCancelButton() {
        StepLogger.step('Click on Cancel button.');
        await PageHelper.click(ModelerPage.selectModelAndVersionsPopup.cancel);
    }

    static async verifyModelerPopupClosed() {
        // takes time to close the popup
        await browser.sleep(PageHelper.timeout.xs);
        await ExpectationHelper.verifyNotDisplayedStatus(
            ModelerPage.selectModelAndVersionsPopup.selectModelDropdown,
            ModelerPageConstants.selectModel,
        );
    }

    static async verifyDisplayTabContent() {
        const displayTabItems = ModelerPage.displayTabOptions;
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.close, ModelerPageConstants.close);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.totalDetails, ModelerPageConstants.totalDetails);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.searchSettings, ModelerPageConstants.searchSettings);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.totalDetails, ModelerPageConstants.totalDetails);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.findNext, ModelerPageConstants.findNext);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.saveVersion, ModelerPageConstants.saveVersion);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.copyVersion, ModelerPageConstants.copyVersion);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.exportToExcel, ModelerPageConstants.exportToExcel);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.print, ModelerPageConstants.print);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.detailsTopGrid, ModelerPageConstants.detailsTopGrid);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.applyTarget, ModelerPageConstants.applyTarget);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.totalsDetails, ModelerPageConstants.totalsDetails);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.createTarget, ModelerPageConstants.createTarget);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.editTarget, ModelerPageConstants.editTarget);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.deleteTarget, ModelerPageConstants.deleteTarget);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.copyTarget, ModelerPageConstants.copyTarget);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.exportToExcelBottom,
            ModelerPageConstants.exportToExcelBottom);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.print, ModelerPageConstants.printBottom);
        await ExpectationHelper.verifyDisplayedStatus(displayTabItems.totalsBottomGrid, ModelerPageConstants.totalsBottomGrid);
    }

    static async clickCloseButtonDisplayTab() {
        StepLogger.step('Click on close button.');
        await PageHelper.click(ModelerPage.displayTabOptions.close);
    }

    static async verifyModelerPageClosed() {
        await ExpectationHelper.verifyNotDisplayedStatus(
            ModelerPage.displayTabOptions.searchSettings,
            ModelerPageConstants.modeler,
        );
    }

    static async verifyNoVersionsAlert() {
        // Takes time to open alert
        await browser.sleep(PageHelper.timeout.s);
        const actualAlertText = await PageHelper.getAlertText();
        await ExpectationHelper.verifyStringEqualTo(
            actualAlertText,
            ModelerPageConstants.noVersionsPopupText,
        );
    }

    static async verifyCopyVersionPopup() {
        const copyVersionItems = ModelerPage.copyVersionPopup;
        await ExpectationHelper.verifyDisplayedStatus(copyVersionItems.from,
            ModelerPageConstants.from);
        await ExpectationHelper.verifyDisplayedStatus(copyVersionItems.to,
            ModelerPageConstants.to);
        await ExpectationHelper.verifyDisplayedStatus(copyVersionItems.notInToVersion,
            ModelerPageConstants.notInToVersion);
        await ExpectationHelper.verifyDisplayedStatus(copyVersionItems.bothVersions,
            ModelerPageConstants.bothVersions);
    }

    static async clickOkCopyVersion() {
        StepLogger.step('Click on Copy Version button.');
        await PageHelper.click(ModelerPage.displayTabOptions.copyVersion);
    }

    static async clickMinusSignOnBothRibbons() {
        const ribbonItems = ModelerPage.collapseAndExpandRibbons;
        StepLogger.step('Click on Minus Sign to the right in the top and bottom ribbons to collapse the ribbon.');
        await PageHelper.click(ribbonItems.minusSignTopRibbon);
        await PageHelper.click(ribbonItems.minusSignBottomRibbon);
    }

    static async verifyBothRibbonsCollapsed() {
        await ExpectationHelper.verifyDisplayedStatus(ModelerPage.collapseAndExpandRibbons.collapseViewTopRibbon,
            ModelerPageConstants.collapsedTopRibbon);
        await ExpectationHelper.verifyDisplayedStatus(ModelerPage.collapseAndExpandRibbons.collapseViewBottomRibbon,
            ModelerPageConstants.collapsedBottomRibbon);
    }

    static async clickApplyTarget() {
        StepLogger.step('Click on Apply Target button.');
        await PageHelper.click(ModelerPage.displayTabOptions.applyTarget);
    }

    static async verifyNoTargetsAlert() {
        // Takes time to open alert
        await browser.sleep(PageHelper.timeout.xs);
        const actualAlertText = await PageHelper.getAlertText();
        await ExpectationHelper.verifyStringEqualTo(
            actualAlertText,
            ModelerPageConstants.noTargetsAlertText,
        );
    }

    static async verifyViewTabContent() {
        const viewTabOptions = ModelerPage.viewTabOptions;
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.close, ModelerPageConstants.close);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.saveView, ModelerPageConstants.saveView);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.renameView, ModelerPageConstants.renameView);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.deleteView, ModelerPageConstants.deleteView);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.sortAndGroup, ModelerPageConstants.sortAndGroup);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.columnOrder, ModelerPageConstants.columnOrder);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.periodsAndValues, ModelerPageConstants.periodsAndValues);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.showGantt, ModelerPageConstants.showGantt);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.ganttZoom, ModelerPageConstants.ganttZoom);
        await ExpectationHelper.verifyDisplayedStatus(viewTabOptions.currentView, ModelerPageConstants.currentView);
    }

    static async verifyViewTabClosedAndRedirect() {
        await ExpectationHelper.verifyNotDisplayedStatus(
            ModelerPage.viewTabOptions.saveView,
            ModelerPageConstants.viewTab,
        );
        await CommonPageHelper.verifyProjectCenterDisplayed();
    }

    static async clickCloseButtonViewTab() {
        StepLogger.step('Click on close button.');
        await PageHelper.click(ModelerPage.viewTabOptions.close);
    }
}
