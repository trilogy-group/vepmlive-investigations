import {OptimizerPageConstants} from './optimizer-page.constants';
import {BasePage} from '../../../base-page';
import {By, element} from 'protractor';
import {ElementHelper} from '../../../../../components/html/element-helper';

export class OptimizerPage extends BasePage {

    static get viewManagementOptions() {
        const label = OptimizerPageConstants.viewManagementOptions;
        return {
            saveView: element(By.id(label.saveView)),
            renameView: element(By.id(label.renameView)),
            deleteView: element(By.id(label.deleteView)),
            clearSorting: element(By.id(label.clearSorting)),
            selectColumns: element(By.id(label.selectColumns)),
            currentViewDropdown: element(By.id(label.currentView))
        };
    }

    static get saveViewPopup(){
        const label = OptimizerPageConstants.saveViewPopup;
        return{
            viewName: element(By.id(label.viewName)),
            defaultView: element(By.id(label.defaultView)),
            personalView: element(By.id(label.personalView)),
            ok: element(By.css('div.dhtmlx_window_active input[value="OK"]')),
            cancel: element(By.css('div.dhtmlx_window_active input[value="Cancel"]'))
        };
    }

    static get getSelectColumnsPopup(){
        const label = OptimizerPageConstants.selectColumnsPopup;
        return{
            ok: ElementHelper.getElementByText(label.ok),
            hideAll: ElementHelper.getElementByText(label.hideAll),
            eachColumn: element.all(By.css('.GMColumnsMenuItemText')),
            selectedColumn: element.all(By.css('.GMColumnsMenuCheckedIconRight>div'))
        };
    }

    static getTabOptions(tabName: string) {
            return element(By.xpath(`//div[contains(@class,"dhx_tabbar_row")]//span[normalize-space(text())="${tabName}"]`));
    }

    static get getCloseOptimizerWindow(){
        return element(By.css('div#idOptimizerTabDiv_ribbon img[src*="close"]'));
    }

    static getDisplyedColumns(columnNumber: number) {
        return element(By.xpath(`//td[text()="Selection"]/following-sibling::td[${columnNumber}]`));
    }

    static getCurrentViewDropdownValue(viewName: string) {
        return element(By.xpath(`//*[@id='idAnalyzerTab_SelView_viewinternal']//span[text()="${viewName}"]/following-sibling::span[1]`));
    }
}
