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

    static getButtonOnPopup(buttonName: string) {
        const activeWindow = 'div.dhtmlx_window_active';
        return element(By.css(`${activeWindow} input[value="${buttonName}"]`));
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

    static getSelectVersionOptionText(index: number) {
        return element(By.css(`select#idVersionList>option:nth-child(${index})`));
    }
}
