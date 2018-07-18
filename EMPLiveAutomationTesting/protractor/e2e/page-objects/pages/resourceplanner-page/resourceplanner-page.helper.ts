import {ResourceplannerPage} from './resourceplanner-page.po';
import {CommonPage} from '../common/common.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {PageHelper} from '../../../components/html/page-helper';
import {WaitHelper} from '../../../components/html/wait-helper';
import {browser} from 'protractor';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {ResourcePlannerConstants} from './resourceplanner-page.constants';

export class ResourcePlannerPageHelper  {

    static async validatingAddingHoursFunctionality(stepLogger: StepLogger, hours: number) {
        // first deleting all the resources

        stepLogger.stepId(1);
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(ResourceplannerPage.topSection.save);
        await PageHelper.switchToDefaultContent();
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        await  this.deletingAllReadyAddedUser(stepLogger);

        stepLogger.stepId(2);
        await  this.addUser(stepLogger);

        stepLogger.stepId(3);
        await this.inputHourAndSave(stepLogger, hours );

        stepLogger.stepId(4);
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.greenCheckImg))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.greenCheckImg));
        await PageHelper.click(CommonPage.ribbonItems.close);
    }

    static async inputHourAndSave(stepLogger: StepLogger, hours: number) {
        stepLogger.step('input hour and save it');
        await PageHelper.click(ResourceplannerPage.selectMonth);
        await PageHelper.sendKeysToInputField(ResourceplannerPage.inputHours, hours.toString() );
        await PageHelper.click(CommonPage.ribbonItems.save);
        if (PageHelper.isElementDisplayed(ResourceplannerPage.yesButton)) {
            await PageHelper.click(ResourceplannerPage.yesButton);
        }
        await WaitHelper.getInstance().waitForElementToBeClickable(CommonPage.ribbonItems.close);
        await browser.sleep(PageHelper.timeout.s);
       }

    static async addUser(stepLogger: StepLogger) {
        stepLogger.step('Adding  the resources');
        await PageHelper.click(ResourceplannerPage.selectUser);
        await PageHelper.click(CommonPage.ribbonItems.add);
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.privateCheckImg))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.privateCheckImg));

    }
    static async deletingAllReadyAddedUser(stepLogger: StepLogger) {
        stepLogger.step('deleting all the resources');
        await PageHelper.click(ResourceplannerPage.delete);
        await PageHelper.acceptAlert();
    }
    static async  deletingUser(stepLogger: StepLogger) {
        //  deleting all the resources
        stepLogger.stepId(1);
        await  WaitHelper.getInstance().waitForElementToBeDisplayed(ResourceplannerPage.topSection.save);

        await PageHelper.switchToDefaultContent();
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        await  this.deletingAllReadyAddedUser(stepLogger);

        stepLogger.stepId(2);
        stepLogger.step('Click  save');
        await PageHelper.click(CommonPage.ribbonItems.save);

        stepLogger.step('Click Close button');
        await PageHelper.click(CommonPage.ribbonItems.close);

    }
    static async validateTopGrid(stepLogger: StepLogger) {
        stepLogger.step('Validating Top Grid Item Name is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.topGrid.itemName))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topGrid.itemName));

        stepLogger.step('Validating Top Grid department is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.topGrid.department))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topGrid.department));

        stepLogger.step('Validating Top Grid role is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.topGrid.role))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topGrid.role));

        stepLogger.step('Validating Top Grid comment is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.topGrid.comment))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topGrid.comment));
    }
    static async validateButtomGrid(stepLogger: StepLogger) {
        stepLogger.step('Validating Top Grid Item Name is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.buttomGrid.itemName))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topGrid.itemName));

        stepLogger.step('Validating Top Grid department is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.buttomGrid.department))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topGrid.department));

        stepLogger.step('Validating Top Grid role is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.buttomGrid.role))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topGrid.role));
       }

    static async validateTopSection(stepLogger: StepLogger) {
        stepLogger.step('Validating save is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.topSection.save))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topSection.save));

        stepLogger.step('Validating Print is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.topSection.print))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topSection.print));

        stepLogger.step('Validating Close is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.topSection.close))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topSection.close));

        stepLogger.step('Validating Note is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.topSection.note))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topSection.note));

        stepLogger.step('Validating Make Public is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.topSection.makePublic))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topSection.makePublic));

        stepLogger.step('Validating import Cost Plan is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.topSection.importCostPlan))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topSection.importCostPlan));

        stepLogger.step('Validating Export to Excel is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.topSection.exportToExcel))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topSection.exportToExcel));

        stepLogger.step('Validating AllocateValue is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.topSection.allocateValue))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topSection.allocateValue));

        stepLogger.step('Validating delete is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.topSection.delete))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topSection.delete));

        stepLogger.step('Validating importWork is Present');
        await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.topSection.importWork))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.topSection.importWork));
        }
     static  async validateButtonSection(stepLogger: StepLogger) {
         stepLogger.step('Validating Show Grouping  is Present');
         await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.buttonSection.showGrouping))
             .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.buttonSection.showGrouping));

         stepLogger.step('Validating Heat Map  is Present');
         await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.buttonSection.heatMap))
             .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.buttonSection.heatMap));

         stepLogger.step('Validating Show Grouping  is Present');
         await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.buttonSection.filter))
             .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.buttonSection.showFilter));

         stepLogger.step('Validating Select Column  is Present');
         await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.buttonSection.selectColumn))
             .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.buttonSection.selectResColumnsBtn));

         stepLogger.step('Validating Match   is Present');
         await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.buttonSection.match))
             .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.buttonSection.matchButton));

         stepLogger.step('Validating clear sorting  is Present');
         await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.buttonSection.clearSorting))
             .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.buttonSection.clearSorting));

         stepLogger.step('Validating Analyze is Present');
         await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.buttonSection.analyze))
             .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.buttonSection.analyzeButton));

         stepLogger.step('Validating Add is Present');
         await expect(await PageHelper.isElementDisplayed(ResourceplannerPage.buttonSection.add))
             .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ResourcePlannerConstants.buttonSection.addButton));
     }

}
