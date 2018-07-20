import {BasePage} from '../base-page';
import {ResourcePlannerConstants} from './resourceplanner-page.constants';
import {By, element} from 'protractor';
import {ElementHelper} from '../../../components/html/element-helper';

export class ResourceplannerPage extends BasePage {

    static get delete(){
        return element(By.id('DeleteBtn'));
    }

    static get selectUser(){
        // selecting User which have department Test department 1
        // tslint:disable-next-line:max-line-length
        return element(By.xpath(`//*[normalize-space(text())="${ResourcePlannerConstants.user}"]//following-sibling::td[text()="${ResourcePlannerConstants.department}"]`));
    }
    static getHoursHeader() {
        // selecting User which have department Test department 1
        return element.all(By.css('#g_RPE .GMHeadRight td.GMHeaderText'));
    }
    static get addedUser(){
        // selecting User which have department Test department 1
        return ElementHelper.getElementByText(ResourcePlannerConstants.user);
    }
    static get selectMonth(){
        return element(By.css('#g_RPE .GMBodyRight .GMDataRow td.GMClassEdit'));
    }
    static get inputHours(){
        return element(By.css('input.GMEditInput'));
    }
    static get yesButton(){
        return element(By.css('[value="Yes"]'));
    }

    static get greenCheckImg(){
        return element(By.css('[class*="rp-commitment"]'));
    }
    static get privateCheckImg(){
        return element(By.css('[class*="rp-pm-private"]'));
    }
    static getTopSectionButtonById(id: string) {
    return element(By.css(`#idEditorTabDiv_ul #${id}`));
    }

    static getbuttonSectionButtonById(id: string) {
        return element(By.css(`#idResourcesTabDiv_ul #${id}`));
    }
    static getTopGridItemsByText(title: string) {
        return element(By.xpath(`//*[@id="gridDiv_RPE"]//td[contains(text(),"${title}")]`));
    }
    static getButtomGridItemsByText(title: string) {
        return element(By.xpath(`//*[@id="g_Res"]//td[contains(text(),"${title}")]`));
    }

    static get topSection() {
        const labels = ResourcePlannerConstants.topSection;
        return {
            save: ResourceplannerPage.getTopSectionButtonById(labels.save),
            close: ResourceplannerPage.getTopSectionButtonById(labels.close),
            delete: ResourceplannerPage.getTopSectionButtonById(labels.delete),
            allocateValue: ResourceplannerPage.getTopSectionButtonById(labels.allocateValue),
            exportToExcel: ResourceplannerPage.getTopSectionButtonById(labels.exportToExcel),
            importCostPlan: ResourceplannerPage.getTopSectionButtonById(labels.importCostPlan),
            makePublic: ResourceplannerPage.getTopSectionButtonById(labels.makePublic),
            note: ResourceplannerPage.getTopSectionButtonById(labels.note),
            print: ResourceplannerPage.getTopSectionButtonById(labels.print),
            importWork: ResourceplannerPage.getTopSectionButtonById(labels.importWork),

        };
    }

    static get topGrid() {
        const labels = ResourcePlannerConstants.topGrid;
        return {
            comment: ResourceplannerPage.getTopGridItemsByText(labels.comment),
            department: ResourceplannerPage.getTopGridItemsByText(labels.department),
            itemName: ResourceplannerPage.getTopGridItemsByText(labels.itemName),
            role: ResourceplannerPage.getTopGridItemsByText(labels.role),
        };
    }
    static get buttomGrid() {
        const labels = ResourcePlannerConstants.topGrid;
        return {
            department: ResourceplannerPage.getButtomGridItemsByText(labels.department),
            itemName: ResourceplannerPage.getButtomGridItemsByText(labels.itemName),
            role: ResourceplannerPage.getButtomGridItemsByText(labels.role),
        };
    }
    static get buttonSection() {
        const labels = ResourcePlannerConstants.buttonSection;
        return {
            add: ResourceplannerPage.getbuttonSectionButtonById(labels.addButton),
            analyze: ResourceplannerPage.getbuttonSectionButtonById(labels.analyzeButton),
            clearSorting: ResourceplannerPage.getbuttonSectionButtonById(labels.clearSorting),
            heatMap: ResourceplannerPage.getbuttonSectionButtonById(labels.heatMap),
            match: ResourceplannerPage.getbuttonSectionButtonById(labels.matchButton),
            selectColumn: ResourceplannerPage.getbuttonSectionButtonById(labels.selectResColumnsBtn),
            filter: ResourceplannerPage.getbuttonSectionButtonById(labels.showFilter),
            showGrouping: ResourceplannerPage.getbuttonSectionButtonById(labels.showGrouping),
        };
    }
}
