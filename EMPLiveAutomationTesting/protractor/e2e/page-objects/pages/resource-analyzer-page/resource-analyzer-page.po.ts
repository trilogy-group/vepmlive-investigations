import {BasePage} from '../base-page';
import {By, element} from 'protractor';
import {ResourceAnalyzerPageConstants} from './resource-analyzer-page.constants';

export class ResourceAnalyzerPage extends BasePage {
    static get display() {
        return element(By.id('idDisplayPress'));
    }
    static get cancel() {
        return element(By.xpath('//*[@class="button-container"]//*[@value="Cancel"]'));
    }
    static get fiscalCalendarDropDown() {
        return element(By.id('idCalList'));
    }
    static get analyzerTab() {
        return element(By.xpath('//*[@tab_id= "tab_Display"]//*[text()="Analyzer"]'));
    }
    static get viewTab() {
        return element(By.css('[tab_id= "tab_View"]'));
    }
    static getTopAnalyserTabButtonById(id: string) {
        return element(By.css(`#idAnalyzerTabDiv_ul #${id}`));
    }

    static getTopViewTabButtonById(id: string) {
        return element(By.css(`#idViewTabDiv_ul #${id}`));
    }
    static getBottomTabButtonById(id: string) {
        return element(By.css(`#idBottomTabDiv_ribbon #${id}`));
    }
    static getBottomTabButtonByText(text: string) {
        return element(By.xpath(`//*[@id='idBottomTabDiv_ribbon']//*[contains(text(),'${text}')]//parent::a`));
    }

    static get topPannelAnalyserTab() {
        const labels = ResourceAnalyzerPageConstants.topPannelAnalyzerTab;
        return {
            publish: ResourceAnalyzerPage.getTopAnalyserTabButtonById(labels.publish),
            changeCalendar: ResourceAnalyzerPage.getTopAnalyserTabButtonById(labels.changeCalendar),
            editResource: ResourceAnalyzerPage.getTopAnalyserTabButtonById(labels.editResource),
            exportToExcel: ResourceAnalyzerPage.getTopAnalyserTabButtonById(labels.exportToExcel),
            print: ResourceAnalyzerPage.getTopAnalyserTabButtonById(labels.print),
            saveScenario: ResourceAnalyzerPage.getTopAnalyserTabButtonById(labels.saveScenario),
            showCommittedWork: ResourceAnalyzerPage.getTopAnalyserTabButtonById(labels.showCommittedWork),
            showTimeSheetActual: ResourceAnalyzerPage.getTopAnalyserTabButtonById(labels.showTimeSheetActual),
            undoButton: ResourceAnalyzerPage.getTopAnalyserTabButtonById(labels.undoButton),
        };
    }

    static get topPannelViewTab() {
        const labels = ResourceAnalyzerPageConstants.topPannelViewTab;
        return {
            editResource: ResourceAnalyzerPage.getTopViewTabButtonById(labels.editResource),
            undo: ResourceAnalyzerPage.getTopViewTabButtonById(labels.undoButton),
            saveScenario: ResourceAnalyzerPage.getTopViewTabButtonById(labels.saveScenario),
            saveView: ResourceAnalyzerPage.getTopViewTabButtonById(labels.saveView),
            renameView: ResourceAnalyzerPage.getTopViewTabButtonById(labels.renameViewBtn),
            deleteViewBtn: ResourceAnalyzerPage.getTopViewTabButtonById(labels.deleteViewBtn),
            showFilter: ResourceAnalyzerPage.getTopViewTabButtonById(labels.showFilter),
            showGrouping: ResourceAnalyzerPage.getTopViewTabButtonById(labels.showGrouping),
            clearSorting: ResourceAnalyzerPage.getTopViewTabButtonById(labels.clearSorting),
            showBars: ResourceAnalyzerPage.getTopViewTabButtonById(labels.showBars),
            hideDetails: ResourceAnalyzerPage.getTopViewTabButtonById(labels.hideDetails),
            selectColumns: ResourceAnalyzerPage.getTopViewTabButtonById(labels.selectColumns),
            expandAll: ResourceAnalyzerPage.getTopViewTabButtonById(labels.expandAll),
            collapseAll: ResourceAnalyzerPage.getTopViewTabButtonById(labels.collapseAll),
            fromPeriod: ResourceAnalyzerPage.getTopViewTabButtonById(labels.fromPeriod),
            toPeriod: ResourceAnalyzerPage.getTopViewTabButtonById(labels.toPeriod),

        };
    }
    static get bottomPannel() {
        const labels = ResourceAnalyzerPageConstants.bottomPannel;
        return {
            totalColumn: ResourceAnalyzerPage.getBottomTabButtonByText(labels.totalColumn),
            capacityScenarios: ResourceAnalyzerPage.getBottomTabButtonByText(labels.capacityScenarios),
            showGraph: ResourceAnalyzerPage.getBottomTabButtonById(labels.showGraph),
            showFilter: ResourceAnalyzerPage.getBottomTabButtonById(labels.showFilter),
            showDetails: ResourceAnalyzerPage.getBottomTabButtonById(labels.showDetails),
            showGrouping: ResourceAnalyzerPage.getBottomTabButtonById(labels.showGrouping),
            removeSorting: ResourceAnalyzerPage.getBottomTabButtonById(labels.removeSorting),
            selectColumn: ResourceAnalyzerPage.getBottomTabButtonById(labels.selectColumn),
            expandAll: ResourceAnalyzerPage.getBottomTabButtonById(labels.expandAll),
            collapseAll: ResourceAnalyzerPage.getBottomTabButtonById(labels.collapseAll),
            legend: ResourceAnalyzerPage.getBottomTabButtonById(labels.legend),
            exportExcel: ResourceAnalyzerPage.getBottomTabButtonById(labels.exportExcel),
            print: ResourceAnalyzerPage.getBottomTabButtonById(labels.print),
            comparisonData: ResourceAnalyzerPage.getBottomTabButtonByText(labels.comparisonData),
             };
    }
 }
