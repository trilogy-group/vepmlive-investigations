import {ExpectationHelper} from '../../../../../components/misc-utils/expectation-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ModelerPage} from './modeler.po';
import {ModelerPageConstants} from './modeler-page.constants';
import {PageHelper} from '../../../../../components/html/page-helper';
import {browser} from 'protractor';
import {HtmlHelper} from '../../../../../components/misc-utils/html-helper';

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
}
