import {BasePage} from '../base-page';
import {ResourcePlannerConstants} from './resource-planner-page.constants';
import {By, element} from 'protractor';
import {ElementHelper} from '../../../components/html/element-helper';
import {CommonPage} from '../common/common.po';

export class ResourcePlannerPage extends BasePage {

    static get delete() {
        return element(By.id('DeleteBtn'));
    }

    static get selectUser() {
        // selecting User which have department Test department 1
        // tslint:disable-next-line:max-line-length
        return element(By.xpath(`//*[normalize-space(text())="${ResourcePlannerConstants.user}"]//following-sibling::td[text()="${ResourcePlannerConstants.department}"]`));
    }

    static get editResourceLink() {
        return CommonPage.ribbonItems.editResource;
    }

    static get editResourceLinkViaEllipse() {
        return CommonPage.contextMenuOptions.editResource;
    }

    static get addedUser() {
        // selecting User which have department Test department 1
        return ElementHelper.getElementByText(ResourcePlannerConstants.user);
    }

    static get selectMonth() {
        return element(By.css('#g_RPE .GMBodyRight .GMDataRow td.GMClassEdit'));
    }

    static get inputHours() {
        return element(By.css('input.GMEditInput'));
    }

    static get yesButton() {
        return element(By.css('[value="Yes"]'));
    }

    static get greenCheckImg() {
        return element(By.css('[class*="rp-commitment"]'));
    }

    static get privateCheckImg() {
        return element(By.css('[class*="rp-pm-private"]'));
    }

    static get topSection() {
        const labels = ResourcePlannerConstants.topSection;
        return {
            save: ResourcePlannerPage.getTopSectionButtonById(labels.save),
            close: ResourcePlannerPage.getTopSectionButtonById(labels.close),
            delete: ResourcePlannerPage.getTopSectionButtonById(labels.delete),
            allocateValue: ResourcePlannerPage.getTopSectionButtonById(labels.allocateValue),
            exportToExcel: ResourcePlannerPage.getTopSectionButtonById(labels.exportToExcel),
            importCostPlan: ResourcePlannerPage.getTopSectionButtonById(labels.importCostPlan),
            makePublic: ResourcePlannerPage.getTopSectionButtonById(labels.makePublic),
            note: ResourcePlannerPage.getTopSectionButtonById(labels.note),
            print: ResourcePlannerPage.getTopSectionButtonById(labels.print),
            importWork: ResourcePlannerPage.getTopSectionButtonById(labels.importWork),

        };
    }

    static get topGrid() {
        const labels = ResourcePlannerConstants.topGrid;
        return {
            comment: ResourcePlannerPage.getTopGridItemsByText(labels.comment),
            department: ResourcePlannerPage.getTopGridItemsByText(labels.department),
            itemName: ResourcePlannerPage.getTopGridItemsByText(labels.itemName),
            role: ResourcePlannerPage.getTopGridItemsByText(labels.role),
        };
    }

    static get buttomGrid() {
        const labels = ResourcePlannerConstants.topGrid;
        return {
            department: ResourcePlannerPage.getButtomGridItemsByText(labels.department),
            itemName: ResourcePlannerPage.getButtomGridItemsByText(labels.itemName),
            role: ResourcePlannerPage.getButtomGridItemsByText(labels.role),
        };
    }

    static get buttonSection() {
        const labels = ResourcePlannerConstants.buttonSection;
        return {
            add: ResourcePlannerPage.getbuttonSectionButtonById(labels.addButton),
            analyze: ResourcePlannerPage.getbuttonSectionButtonById(labels.analyzeButton),
            clearSorting: ResourcePlannerPage.getbuttonSectionButtonById(labels.clearSorting),
            heatMap: ResourcePlannerPage.getbuttonSectionButtonById(labels.heatMap),
            match: ResourcePlannerPage.getbuttonSectionButtonById(labels.matchButton),
            selectColumn: ResourcePlannerPage.getbuttonSectionButtonById(labels.selectResColumnsBtn),
            filter: ResourcePlannerPage.getbuttonSectionButtonById(labels.showFilter),
            showGrouping: ResourcePlannerPage.getbuttonSectionButtonById(labels.showGrouping),
        };
    }

    static getHoursHeader() {
        // selecting User which have department Test department 1
        return element.all(By.css('#g_RPE .GMHeadRight td.GMHeaderText'));
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
}
