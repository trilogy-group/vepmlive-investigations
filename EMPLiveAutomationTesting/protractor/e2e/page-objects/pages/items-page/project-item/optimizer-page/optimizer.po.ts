import {OptimizerPageConstants} from './optimizer-page.constants';
import {BasePage} from '../../../base-page';
import {browser, By, element} from "protractor";
import {ElementHelper} from "../../../../../components/html/element-helper";

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
            viewName:element(By.id(label.viewName)),
            defaultView:element(By.id(label.defaultView)),
            personalView:element(By.id(label.personalView)),
            ok: element(By.xpath('//div[contains(@class,"dhtmlx_window_active")]//input[@value="OK"]')),
            cancel:ElementHelper.getElementByText(label.cancel)
        }
    }

    static async getButtonOnSaveView(buttonName: string) {
        const xpathButton = `//div[@id="idSaveViewDlg"]//input[normalize-space(@value)="${buttonName}")]`;
        return element(By.xpath(xpathButton));
    }

    static async getAllColumnNames(){
        const xpathAllColumns='//div[contains(@class,"GMColumnsMenuItemText")]';
        let list=element.all(By.xpath(xpathAllColumns));
        return list;
    }

    static get hideAllButton(){
        return element(By.xpath('//button[normalize-space(text())="Hide all"]'))
    }

    static get okButton(){
        return element(By.xpath('//button[normalize-space(text())="OK"]'))
    }

    static get getTabOptions(){
        return {
            viewTab:element(By.xpath('//div[contains(@class,"dhx_tabbar_row")]//span[normalize-space(text())="View"]')),
            optimizerTab:element(By.xpath('//div[contains(@class,"dhx_tabbar_row")]//span[normalize-space(text())="Optimizer"]'))
        }
    }

    static get getCloseOptimizerWindow(){
        return element(By.xpath('//div[@id="idOptimizerTabDiv_ribbon"]//img[contains(@src,"close")]'))
    }

    static get allSelectedColumns(){
        return element.all(By.xpath('//td[text()="Selection"]/following-sibling::td'))
    }

    static get optimizerFrame() {
        return browser.driver.findElement(By.xpath('//div[@class="ms-dlgFrameContainer"]/iframe'));
    }
}