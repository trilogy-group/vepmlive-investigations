import {BasePage} from '../../../base-page';
import {By, element} from 'protractor';
import {ModelerPageConstants} from './modeler-page.constants';

export class ModelerPage extends BasePage {

    static get selectModelAndVersionsPopup() {
        const modelAndVersionsLabel = ModelerPageConstants.selectModelAndVersionsPopup;
        return {
            title: element(By.css(`.${modelAndVersionsLabel.titleClass}`)),
            selectModelDropdown: element(By.id(modelAndVersionsLabel.selectModelDropdown)),
            versionsSelectionBox: element(By.id(modelAndVersionsLabel.versionsSelectionBox)),
            ok: this.getButtonOnPopup(modelAndVersionsLabel.ok),
            cancel: this.getButtonOnPopup(modelAndVersionsLabel.cancel),
            selectedOptionVersionsBox: element(By.css('select#idVersionList>option:checked')),
            selectVersionsOptions: element(By.css('select#idVersionList>option'))
        };
    }

    static get activeTab() {
        return element(By.css('.dhx_tab_element_active>span'));
    }

    static get getTabOptions() {
        const tabLabels = ModelerPageConstants.tabNames;
        const tabSection = '//div[contains(@class,"dhx_tabbar_row")]';
        return {
            optimizer: element(By.xpath(`${tabSection}//span[normalize-space(text())="${tabLabels.display}"]`)),
            view: element(By.xpath(`${tabSection}//span[normalize-space(text())="${tabLabels.view}"]`))
        };
    }

    static get displayTabOptions() {
        const displayTabLabels = ModelerPageConstants.displayTabOptions;
        return {
            close: element(By.css(`#idRibbonDiv_ul img[src*="${displayTabLabels.close}"]`)),
            totalDetails: element(By.id(displayTabLabels.totalDetails)),
            searchSettings: element(By.id(displayTabLabels.searchSettings)),
            findNext: element(By.id(displayTabLabels.findNext)),
            saveVersion: element(By.id(displayTabLabels.saveVersion)),
            copyVersion: element(By.id(displayTabLabels.copyVersion)),
            exportToExcel: element(By.id(displayTabLabels.exportToExcel)),
            print: element(By.id(displayTabLabels.print)),
            detailsTopGrid: element(By.id(displayTabLabels.detailsTopGrid)),
            applyTarget: element(By.id(displayTabLabels.applyTarget)),
            totalsDetails: element(By.id(displayTabLabels.totalsDetails)),
            createTarget: element(By.id(displayTabLabels.createTarget)),
            editTarget: element(By.id(displayTabLabels.editTarget)),
            deleteTarget: element(By.id(displayTabLabels.deleteTarget)),
            copyTarget: element(By.id(displayTabLabels.copyTarget)),
            exportToExcelBottom: element(By.id(displayTabLabels.exportToExcelBottom)),
            printBottom: element(By.id(displayTabLabels.printBottom)),
            totalsBottomGrid: element(By.id(displayTabLabels.totalsBottomGrid)),
        };
    }

    static get searchSettingsPopup() {
        const searchSettingsLabel = ModelerPageConstants.searchSettingsPopup;
        return {
            searchFor: element(By.id(searchSettingsLabel.searchFor)),
            where: element(By.id(searchSettingsLabel.where)),
            in: element(By.id(searchSettingsLabel.in)),
            details: element(By.id(searchSettingsLabel.details)),
            totals: element(By.id(searchSettingsLabel.totals)),
            ok: this.getButtonOnPopup(searchSettingsLabel.ok),
            cancel: this.getButtonOnPopup(searchSettingsLabel.cancel)
        };
    }

    static get copyVersionPopup() {
        const copyVersionLabel = ModelerPageConstants.copyVersionPopup;
        return {
            from: element(By.id(copyVersionLabel.from)),
            to: element(By.id(copyVersionLabel.to)),
            notInToVersion: element(By.id(copyVersionLabel.notInToVersion)),
            bothVersions: element(By.id(copyVersionLabel.bothVersions)),
            ok: this.getButtonOnPopup(copyVersionLabel.ok),
            cancel: this.getButtonOnPopup(copyVersionLabel.cancel)
        };
    }

    static get collapseAndExpandRibbons() {
        const ribbonItems = ModelerPageConstants.collapseAndExpandRibbons;
        return {
            collapseViewTopRibbon: element(By.id(ribbonItems.collapseViewTopRibbon)),
            expandViewTopRibbon: element(By.id(ribbonItems.expandViewTopRibbon)),
            minusSignTopRibbon: element(By.css(`#${ribbonItems.expandViewTopRibbon}>span>img`)),
            plusSignTopRibbon: element(By.css(`#${ribbonItems.collapseViewTopRibbon}>span>img`)),
            collapseViewBottomRibbon: element(By.id(ribbonItems.collapseViewBottomRibbon)),
            expandViewBottomRibbon: element(By.id(ribbonItems.expandViewBottomRibbon)),
            minusSignBottomRibbon: element(By.css(`#${ribbonItems.expandViewBottomRibbon}>span>img`)),
            plusSignBottomRibbon: element(By.css(`#${ribbonItems.collapseViewBottomRibbon}>span>img`))
        };
    }

    static get viewTabOptions() {
        const viewTabLabels = ModelerPageConstants.viewTabOptions;
        return {
            close: element(By.css(`#idViewTabDiv_ul img[src*="${viewTabLabels.close}"]`)),
            saveView: element(By.id(viewTabLabels.saveView)),
            renameView: element(By.id(viewTabLabels.renameView)),
            deleteView: element(By.id(viewTabLabels.deleteView)),
            sortAndGroup: element(By.id(viewTabLabels.sortAndGroup)),
            columnOrder: element(By.id(viewTabLabels.columnOrder)),
            periodsAndValues: element(By.id(viewTabLabels.periodsAndValues)),
            showGantt: element(By.id(viewTabLabels.showGantt)),
            ganttZoom: element(By.id(viewTabLabels.ganttZoom)),
            currentView: element(By.id(viewTabLabels.currentView))
        };
    }

    static getButtonOnPopup(buttonName: string) {
        const activeWindow = 'div.dhtmlx_window_active';
        return element(By.css(`${activeWindow} input[value="${buttonName}"]`));
    }

    static getSelectVersionOptionText(index: number) {
        return element(By.css(`select#idVersionList>option:nth-child(${index})`));
    }
}
