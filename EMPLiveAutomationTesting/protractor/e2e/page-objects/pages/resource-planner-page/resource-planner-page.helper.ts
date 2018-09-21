import {CommonPage} from '../common/common.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {PageHelper} from '../../../components/html/page-helper';
import {WaitHelper} from '../../../components/html/wait-helper';
import {ResourcePlannerConstants} from './resource-planner-page.constants';
import {CommonPageHelper} from '../common/common-page.helper';
import {ResourcePlannerPage} from './resource-planner-page.po';
import {ElementHelper} from '../../../components/html/element-helper';
import {ExpectationHelper} from '../../../components/misc-utils/expectation-helper';

export class ResourcePlannerPageHelper  {

    static async validatingAddingHoursFunctionality(stepLogger: StepLogger, hours: number) {
        // first deleting all the resources
        stepLogger.step('Add hours for the resource added in the top-grid');
        stepLogger.stepId(1);
        await  WaitHelper.waitForElementToBeDisplayed(ResourcePlannerPage.topSection.save);

        await PageHelper.switchToDefaultContent();
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        await  this.deletingAllReadyAddedUser(stepLogger);

        stepLogger.stepId(2);
        await  this.addUser(stepLogger);

        stepLogger.stepId(3);
        await this.inputHourAndSave(stepLogger, hours );

        stepLogger.stepId(4);
        await CommonPageHelper.fieldDisplayedValidation(ResourcePlannerPage.greenCheckImg , ResourcePlannerConstants.greenCheckImg );
        await WaitHelper.staticWait(PageHelper.timeout.s);
        await PageHelper.click(CommonPage.ribbonItems.close);
    }

    static async inputHourAndSave(stepLogger: StepLogger, hours: number) {
        stepLogger.step('input hour and save it');
        await PageHelper.click(ResourcePlannerPage.selectMonth);

        await PageHelper.sendKeysToInputField(ResourcePlannerPage.inputHours, hours.toString() );

        await PageHelper.click(CommonPage.ribbonItems.save);

        if (PageHelper.isElementDisplayed(ResourcePlannerPage.yesButton)) {
            await PageHelper.click(ResourcePlannerPage.yesButton);
        }

       }

    static async addUser(stepLogger: StepLogger) {
        stepLogger.step('Adding  the resources');
        await PageHelper.click(ResourcePlannerPage.selectUser);

        await PageHelper.click(CommonPage.ribbonItems.add);

        await CommonPageHelper.fieldDisplayedValidation(ResourcePlannerPage.privateCheckImg , ResourcePlannerConstants.privateCheckImg );
    }
    static async deletingAllReadyAddedUser(stepLogger: StepLogger) {
        stepLogger.step('deleting all the resources');
        await PageHelper.click(ResourcePlannerPage.delete);

        await PageHelper.acceptAlert();
    }
    static async  deletingUserAndSave(stepLogger: StepLogger) {
        //  deleting all the resources
        stepLogger.stepId(1);
        await  WaitHelper.waitForElementToBeDisplayed(ResourcePlannerPage.topSection.save);

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
        await CommonPageHelper.fieldDisplayedValidation(ResourcePlannerPage.topGrid.itemName , ResourcePlannerConstants.topGrid.itemName );

        stepLogger.step('Validating Top Grid department is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topGrid.department , ResourcePlannerConstants.topGrid.department );

        stepLogger.step('Validating Top Grid role is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topGrid.role , ResourcePlannerConstants.topGrid.role );

        stepLogger.step('Validating Top Grid comment is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topGrid.comment , ResourcePlannerConstants.topGrid.comment );

    }
    static async validateButtomGrid(stepLogger: StepLogger) {
        stepLogger.step('Validating Top Grid Item Name is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttomGrid.itemName , ResourcePlannerConstants.topGrid.role );

        stepLogger.step('Validating Top Grid department is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttomGrid.department , ResourcePlannerConstants.topGrid.department );

        stepLogger.step('Validating Top Grid role is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttomGrid.role , ResourcePlannerConstants.topGrid.role );
       }

    static async validateTopSection(stepLogger: StepLogger) {
        stepLogger.step('Validating save is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.save, ResourcePlannerConstants.topSection.save);

        stepLogger.step('Validating Print is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.print, ResourcePlannerConstants.topSection.print);

        stepLogger.step('Validating Close is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.close, ResourcePlannerConstants.topSection.close);

        stepLogger.step('Validating Note is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.note, ResourcePlannerConstants.topSection.note);

        stepLogger.step('Validating Make Public is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.makePublic, ResourcePlannerConstants.topSection.makePublic);

        stepLogger.step('Validating import Cost Plan is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.importCostPlan, ResourcePlannerConstants.topSection.importCostPlan);

        stepLogger.step('Validating Export to Excel is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.exportToExcel, ResourcePlannerConstants.topSection.exportToExcel);

        stepLogger.step('Validating AllocateValue is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.allocateValue, ResourcePlannerConstants.topSection.allocateValue);

        stepLogger.step('Validating delete is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.delete, ResourcePlannerConstants.topSection.delete);

        stepLogger.step('Validating importWork is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.importWork, ResourcePlannerConstants.topSection.importWork);
    }
    static  async validateButtonSection(stepLogger: StepLogger ) {
         stepLogger.step('Validating Show Grouping  is Present');
         await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttonSection.showGrouping , ResourcePlannerConstants.buttonSection.showGrouping );

         stepLogger.step('Validating Heat Map  is Present');
         await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttonSection.heatMap , ResourcePlannerConstants.buttonSection.heatMap );

         stepLogger.step('Validating Show Grouping  is Present');
         await CommonPageHelper.fieldDisplayedValidation
         (ResourcePlannerPage.buttonSection.filter , ResourcePlannerConstants.buttonSection.showFilter );

         stepLogger.step('Validating Select Column  is Present');
         await CommonPageHelper.fieldDisplayedValidation
         (ResourcePlannerPage.buttonSection.selectColumn , ResourcePlannerConstants.buttonSection.selectResColumnsBtn );

         stepLogger.step('Validating Match   is Present');
         await CommonPageHelper.fieldDisplayedValidation
         (ResourcePlannerPage.buttonSection.match , ResourcePlannerConstants.buttonSection.matchButton );

         stepLogger.step('Validating clear sorting  is Present');
         await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttonSection.clearSorting , ResourcePlannerConstants.buttonSection.clearSorting );

         stepLogger.step('Validating Analyze is Present');
         await CommonPageHelper.fieldDisplayedValidation
         (ResourcePlannerPage.buttonSection.analyze , ResourcePlannerConstants.buttonSection.analyzeButton );

         stepLogger.step('Validating Add is Present');
         await CommonPageHelper.fieldDisplayedValidation
         (ResourcePlannerPage.buttonSection.add , ResourcePlannerConstants.buttonSection.addButton );
    }
    static  async validateEditResourceOpenInNewTab(stepLogger: StepLogger) {
        stepLogger.verification('Switch To new Tab  ');
        await PageHelper.switchToNewTabIfAvailable(1);
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);

        stepLogger.step('Validating Top Grid Item Name is Present');
        await CommonPageHelper.fieldDisplayedValidation(ResourcePlannerPage.topGrid.itemName , ResourcePlannerConstants.topGrid.itemName );
    }
    static  async openEditResourceViaRibbonInNewTab (stepLogger: StepLogger) {
        stepLogger.step('Open edit resource In New Tab');
        await ElementHelper.openLinkInNewTab(ResourcePlannerPage.editResourceLink);
    }

    static async verifyResourcePlanDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyText(
            CommonPage.dialogTitle,
            ResourcePlannerConstants.title,
            ResourcePlannerConstants.title,
            stepLogger
        );
    }

    static async verifyDisabledResourceNotDisplayed(displayName: string, stepLogger: StepLogger) {
        await ExpectationHelper.verifyNotDisplayedStatus(
            ResourcePlannerPage.getButtomGridItemsByText(displayName),
            displayName,
            stepLogger
        );
    }
}
