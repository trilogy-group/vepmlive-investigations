import {OptimizerPage} from './optimizer.po';
import {StepLogger} from "../../../../../../core/logger/step-logger";
import {PageHelper} from "../../../../../components/html/page-helper";
import {By, element} from "protractor";
import {WaitHelper} from "../../../../../components/html/wait-helper";

export class OptimizerPageHelper {

    static async selectColumns(stepLogger: StepLogger) {
        stepLogger.stepId(3);
        stepLogger.step(`select columns by checking respective check box`);
        await PageHelper.click(OptimizerPage.hideAllButton);
        const xpathAllColumns='//div[contains(@class,"GMColumnsMenuItemText")]';
        let list=element.all(By.xpath(xpathAllColumns));
        let i:number;
        // var colNameTemp:string;
        for( i=0;i<5;i++){
            const uniqueId=i;
            PageHelper.click(list.get(uniqueId));
        }
    }

    static async verifyColumnNamesInGrid(stepLogger: StepLogger){
        stepLogger.verification(`Verify the columns which were selected and saved for this particular view should be displayed in grid`);
        // let columnList=element.all(By.xpath(xpathAllDisplayedColumns));
        var columnNamesInTable:string[]=["Start","Finish","PI Percent Complete","Current Stage","Priority"];
        var i:number;
        const xpathAllDisplayedColumns=`//td[text()="Selection"]/following-sibling::td`;
        await expect(element.all(By.xpath(xpathAllDisplayedColumns)).count()).toBe(5);
        for( i=0;i<5;i++) {
            const xpathAllDisplayedColumn=`//td[text()="Selection"]/following-sibling::td[${i+1}]`;
            await expect(columnNamesInTable).toContain(await element(By.xpath(xpathAllDisplayedColumn)).getText());
        }
        stepLogger.verification("Columns which were selected and saved for this particular view has been displayed");
    }

    static async selectPreviouslySavedView(viewName:string){
        await PageHelper.click(OptimizerPage.viewManagementOptions.currentViewDropdown);
        const xpathDropdownValue=`//*[@id='idAnalyzerTab_SelView_viewinternal']//span[text()="${viewName}"]/following-sibling::span[1]`;
        await WaitHelper.getInstance().waitForElementToBeDisplayed(element(By.xpath(xpathDropdownValue)),PageHelper.timeout.s);
        await PageHelper.click(element(By.xpath(xpathDropdownValue)));
    }
}