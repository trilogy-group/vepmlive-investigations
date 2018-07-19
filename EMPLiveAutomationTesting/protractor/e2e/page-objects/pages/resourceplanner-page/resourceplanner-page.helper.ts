import {ResourceplannerPage} from './resourceplanner-page.po';
import {CommonPage} from '../common/common.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {PageHelper} from '../../../components/html/page-helper';
import {WaitHelper} from '../../../components/html/wait-helper';
import {ResourcePlannerConstants} from './resourceplanner-page.constants';
import {CommonPageHelper} from '../common/common-page.helper';

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
        await CommonPageHelper.fieldDisplayedValidation(ResourceplannerPage.greenCheckImg , ResourcePlannerConstants.greenCheckImg );

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

       }

    static async addUser(stepLogger: StepLogger) {
        stepLogger.step('Adding  the resources');
        await PageHelper.click(ResourceplannerPage.selectUser);

        await PageHelper.click(CommonPage.ribbonItems.add);

        await CommonPageHelper.fieldDisplayedValidation(ResourceplannerPage.privateCheckImg , ResourcePlannerConstants.privateCheckImg );
    }
    static async deletingAllReadyAddedUser(stepLogger: StepLogger) {
        stepLogger.step('deleting all the resources');
        await PageHelper.click(ResourceplannerPage.delete);

        await PageHelper.acceptAlert();
    }
    static async  deletingUserAndSave(stepLogger: StepLogger) {
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
        await CommonPageHelper.fieldDisplayedValidation(ResourceplannerPage.topGrid.itemName , ResourcePlannerConstants.topGrid.itemName );

        stepLogger.step('Validating Top Grid department is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.topGrid.department , ResourcePlannerConstants.topGrid.department );

        stepLogger.step('Validating Top Grid role is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.topGrid.role , ResourcePlannerConstants.topGrid.role );

        stepLogger.step('Validating Top Grid comment is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.topGrid.comment , ResourcePlannerConstants.topGrid.comment );

    }
    static async validateButtomGrid(stepLogger: StepLogger) {
        stepLogger.step('Validating Top Grid Item Name is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.buttomGrid.itemName , ResourcePlannerConstants.topGrid.role );

        stepLogger.step('Validating Top Grid department is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.buttomGrid.department , ResourcePlannerConstants.topGrid.department );

        stepLogger.step('Validating Top Grid role is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.buttomGrid.role , ResourcePlannerConstants.topGrid.role );
       }

    static async validateTopSection(stepLogger: StepLogger) {
        stepLogger.step('Validating save is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.topSection.save, ResourcePlannerConstants.topSection.save);

        stepLogger.step('Validating Print is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.topSection.print, ResourcePlannerConstants.topSection.print);

        stepLogger.step('Validating Close is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.topSection.close, ResourcePlannerConstants.topSection.close);

        stepLogger.step('Validating Note is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.topSection.note, ResourcePlannerConstants.topSection.note);

        stepLogger.step('Validating Make Public is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.topSection.makePublic, ResourcePlannerConstants.topSection.makePublic);

        stepLogger.step('Validating import Cost Plan is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.topSection.importCostPlan, ResourcePlannerConstants.topSection.importCostPlan);

        stepLogger.step('Validating Export to Excel is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.topSection.exportToExcel, ResourcePlannerConstants.topSection.exportToExcel);

        stepLogger.step('Validating AllocateValue is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.topSection.allocateValue, ResourcePlannerConstants.topSection.allocateValue);

        stepLogger.step('Validating delete is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.topSection.delete, ResourcePlannerConstants.topSection.delete);

        stepLogger.step('Validating importWork is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.topSection.importWork, ResourcePlannerConstants.topSection.importWork);
    }
    static  async validateButtonSection(stepLogger: StepLogger ) {
         stepLogger.step('Validating Show Grouping  is Present');
         await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.buttonSection.showGrouping , ResourcePlannerConstants.buttonSection.showGrouping );

         stepLogger.step('Validating Heat Map  is Present');
         await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.buttonSection.heatMap , ResourcePlannerConstants.buttonSection.heatMap );

         stepLogger.step('Validating Show Grouping  is Present');
         await CommonPageHelper.fieldDisplayedValidation
         (ResourceplannerPage.buttonSection.filter , ResourcePlannerConstants.buttonSection.showFilter );

         stepLogger.step('Validating Select Column  is Present');
         await CommonPageHelper.fieldDisplayedValidation
         (ResourceplannerPage.buttonSection.selectColumn , ResourcePlannerConstants.buttonSection.selectResColumnsBtn );

         stepLogger.step('Validating Match   is Present');
         await CommonPageHelper.fieldDisplayedValidation
         (ResourceplannerPage.buttonSection.match , ResourcePlannerConstants.buttonSection.matchButton );

         stepLogger.step('Validating clear sorting  is Present');
         await CommonPageHelper.fieldDisplayedValidation
        (ResourceplannerPage.buttonSection.clearSorting , ResourcePlannerConstants.buttonSection.clearSorting );

         stepLogger.step('Validating Analyze is Present');
         await CommonPageHelper.fieldDisplayedValidation
         (ResourceplannerPage.buttonSection.analyze , ResourcePlannerConstants.buttonSection.analyzeButton );

         stepLogger.step('Validating Add is Present');
         await CommonPageHelper.fieldDisplayedValidation
         (ResourceplannerPage.buttonSection.add , ResourcePlannerConstants.buttonSection.addButton );     }

}
