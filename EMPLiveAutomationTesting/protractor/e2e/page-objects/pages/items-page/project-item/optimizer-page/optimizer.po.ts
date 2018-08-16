import {OptimizerPageConstants} from './optimizer-page.constants';
import {BasePage} from '../../../base-page';
import {By, element} from 'protractor';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {CommonPageHelper} from '../../../common/common-page.helper';

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
            ok: this.getButtonOnPopup(label.ok),
            cancel: this.getButtonOnPopup(label.cancel)
        };
    }

    static get getSelectColumnsPopup(){
        const label = OptimizerPageConstants.selectColumnsPopup;
        return{
            ok: ElementHelper.getElementByText(label.ok),
            cancel: ElementHelper.getElementByText(label.cancel),
            hideAll: ElementHelper.getElementByText(label.hideAll),
            column: element.all(By.css('.GMColumnsMenuItemText')),
            eachColumn: element(By.css('.GMColumnsMenuItemText')),
            selectedColumn: element.all(By.css('.GMColumnsMenuCheckedIconRight>div')),
            eachSelectedColumn: element(By.css('.GMColumnsMenuCheckedIconRight>div')),
            heading: element(By.css('.GMColumnsMenuHead')),
            unchecked: element(By.css('.GMColumnsMenuUncheckedIconRight')),
            showAll: ElementHelper.getElementByText(label.showAll),
        };
    }

    static get getTabOptions() {
        const label = OptimizerPageConstants.tabOptions;
        const tabSection = '//div[contains(@class,"dhx_tabbar_row")]';
        return {
            optimizer: element(By.xpath(`${tabSection}//span[normalize-space(text())="${label.optimizer}"]`)),
            view: element(By.xpath(`${tabSection}//span[normalize-space(text())="${label.view}"]`))
        };
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

    static getButtonOnPopup(buttonName: string) {
        const activeWindow = 'div.dhtmlx_window_active';
        return element(By.css(`${activeWindow} input[value="${buttonName}"]`));
    }

    static get getConfigure(){
        return element(By.css('ul#idOptimizerTabDiv_ul img[src*="configure"]'));
    }

    static get getOptimizerConfiguration(){
        const label = OptimizerPageConstants.optimizerConfiguration;
        return{
            heading: CommonPageHelper.getElementByText(label.heading),
            enterValueLabel: CommonPageHelper.getElementByText(label.enterValueLabel, true),
            titleComparisonLabel: CommonPageHelper.getElementByText(label.titleComparisonLabel, true),
            thirdQuestion: CommonPageHelper.getElementByText(label.thirdQuestion, true),
            availableFields: ElementHelper.getElementByText(label.availableFields),
            selectedFilelds: ElementHelper.getElementByText(label.selectedFilelds),
            add: AnchorHelper.getItemById(label.add),
            remove: AnchorHelper.getItemById(label.remove),
            availableFieldsSelect: AnchorHelper.getItemById(label.availableFieldsSelect),
            selectedFieldsSelect: AnchorHelper.getItemById(label.selectedFieldsSelect),
            upArrow: AnchorHelper.getItemById(label.upArrow),
            downArrow: AnchorHelper.getItemById(label.downArrow),
            ok: this.getButtonOnPopup(label.ok),
            cancel: this.getButtonOnPopup(label.cancel),
            message : element(By.css('#idOptDlg>div>div:last-child')),
            firstAvailableField: element(By.css('select#idOptConfAvailfields>option:first-child')),
            firstSelectedField: element(By.css('select#idOptConfSelfields>option:first-child'))
        };
    }

    static get getOptimizerStrategyActions(){
        const label = OptimizerPageConstants.optimizerStrategyActions;
        return{
            saveStrategy: AnchorHelper.getAnchorById(label.saveStrategy),
            renameStrategy: AnchorHelper.getAnchorById(label.renameStrategy),
            deleteStrategy: AnchorHelper.getAnchorById(label.deleteStrategy),
            commitStrategy: AnchorHelper.getAnchorById(label.commitStrategy),
            currentStrategyDropdown: AnchorHelper.getAnchorById(label.currentStrategyDropdown),
            currentStrategyDropdownValue: element(By.xpath('//li[@id="idOptTab_SelView_viewinternal"]/a[2]')),
            currentStrategyDropdownSpan: element(By.id(label.currentStrategyDropdownSpan))
        };
    }

    static get getOptimierSaveStrategyPopup(){
        const label = OptimizerPageConstants.optimierSaveStrategyPopup;
        return{
            strategyName: element(By.id(label.strategyName)),
            personalStrategyCheckBox: element(By.id(label.personalStrategyCheckBox)),
            ok: this.getButtonOnPopup(label.ok),
            cancel: this.getButtonOnPopup(label.cancel)
        };
    }

    static get getDeleteStrategyPopup(){
        const label = OptimizerPageConstants.optimierSaveStrategyPopup;
        return{
            message: element(By.xpath('//div[@id="idDeleteStratagy"]/div/div[1]')),
            ok: this.getButtonOnPopup(label.ok),
            cancel: this.getButtonOnPopup(label.cancel)
        };
    }

    static getCurrentStrategyByName(strategyName: string) {
        return element(By.xpath(`//li[@id="idOptTab_SelView_viewinternal"]//span[normalize-space(text())="${strategyName}"]`));
    }

    static get getOptimizerRibbon() {
        const label = OptimizerPageConstants.optimizerRibbon;
        return{
            collapseView: element(By.id(label.collapseView)),
            expandView: element(By.id(label.expandView)),
            minusSign: element(By.css(`#${label.expandView}>span>img`)),
            plusSign: element(By.css(`#${label.collapseView}>span>img`))
        };
    }

    static get getCloseOptimizerViewTab(){
        return element(By.xpath('//ul[@id="idViewTabDiv_ul"]//span[text()="Close"]'));
    }

    static get getDeleteViewPopup(){
        const label = OptimizerPageConstants.deleteViewPopup;
        return {
            deleteViewMessage: element(By.xpath(`//div[@id="${label.deleteViewPopup}"]/div/div[1]`)),
            viewName: element(By.id(label.viewName)),
            ok: this.getButtonOnPopup(label.ok),
            cancel: this.getButtonOnPopup(label.cancel)
        };
    }

    static getCurrentViewByName(viewName: string) {
        return element(By.xpath(`//li[@id="idAnalyzerTab_SelView_viewinternal"]//span[normalize-space(text())="${viewName}"]`));
    }
}
