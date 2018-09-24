import {CommonPage} from '../common/common.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {PageHelper} from '../../../components/html/page-helper';
import {WaitHelper} from '../../../components/html/wait-helper';
import {ResourcePlannerConstants} from './resource-planner-page.constants';
import {CommonPageHelper} from '../common/common-page.helper';
import {ResourcePlannerPage} from './resource-planner-page.po';
import {ElementHelper} from '../../../components/html/element-helper';
import {ExpectationHelper} from '../../../components/misc-utils/expectation-helper';

export class ResourcePlannerPageHelper {

    static async validatingAddingHoursFunctionality(hours: number) {
        // first deleting all the resources
        StepLogger.step('Add hours for the resource added in the top-grid');
        StepLogger.stepId(1);
        await WaitHelper.waitForElementToBeDisplayed(ResourcePlannerPage.topSection.save);

        await PageHelper.switchToDefaultContent();
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        await this.deletingAllReadyAddedUser();

        StepLogger.stepId(2);
        await this.addUser();

        StepLogger.stepId(3);
        await this.inputHourAndSave(hours);

        StepLogger.stepId(4);
        await CommonPageHelper.fieldDisplayedValidation(ResourcePlannerPage.greenCheckImg, ResourcePlannerConstants.greenCheckImg);
        await WaitHelper.staticWait(PageHelper.timeout.s);
        await PageHelper.click(CommonPage.ribbonItems.close);
    }

    static async inputHourAndSave(hours: number) {
        StepLogger.step('input hour and save it');
        await PageHelper.click(ResourcePlannerPage.selectMonth);

        await PageHelper.sendKeysToInputField(ResourcePlannerPage.inputHours, hours.toString());

        await PageHelper.click(CommonPage.ribbonItems.save);

        if (PageHelper.isElementDisplayed(ResourcePlannerPage.yesButton)) {
            await PageHelper.click(ResourcePlannerPage.yesButton);
        }

    }

    static async addUser() {
        StepLogger.step('Adding  the resources');
        await PageHelper.click(ResourcePlannerPage.selectUser);

        await PageHelper.click(CommonPage.ribbonItems.add);

        await CommonPageHelper.fieldDisplayedValidation(ResourcePlannerPage.privateCheckImg, ResourcePlannerConstants.privateCheckImg);
    }

    static async deletingAllReadyAddedUser() {
        StepLogger.step('deleting all the resources');
        await PageHelper.click(ResourcePlannerPage.delete);

        await PageHelper.acceptAlert();
    }

    static async deletingUserAndSave() {
        //  deleting all the resources
        StepLogger.stepId(1);
        await WaitHelper.waitForElementToBeDisplayed(ResourcePlannerPage.topSection.save);

        await PageHelper.switchToDefaultContent();
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        await this.deletingAllReadyAddedUser();

        StepLogger.stepId(2);
        StepLogger.step('Click  save');
        await PageHelper.click(CommonPage.ribbonItems.save);

        StepLogger.step('Click Close button');
        await PageHelper.click(CommonPage.ribbonItems.close);

    }

    static async validateTopGrid() {
        StepLogger.step('Validating Top Grid Item Name is Present');
        await CommonPageHelper.fieldDisplayedValidation(ResourcePlannerPage.topGrid.itemName, ResourcePlannerConstants.topGrid.itemName);

        StepLogger.step('Validating Top Grid department is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topGrid.department, ResourcePlannerConstants.topGrid.department);

        StepLogger.step('Validating Top Grid role is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topGrid.role, ResourcePlannerConstants.topGrid.role);

        StepLogger.step('Validating Top Grid comment is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topGrid.comment, ResourcePlannerConstants.topGrid.comment);

    }

    static async validateButtomGrid() {
        StepLogger.step('Validating Top Grid Item Name is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttomGrid.itemName, ResourcePlannerConstants.topGrid.role);

        StepLogger.step('Validating Top Grid department is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttomGrid.department, ResourcePlannerConstants.topGrid.department);

        StepLogger.step('Validating Top Grid role is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttomGrid.role, ResourcePlannerConstants.topGrid.role);
    }

    static async validateTopSection() {
        StepLogger.step('Validating save is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.save, ResourcePlannerConstants.topSection.save);

        StepLogger.step('Validating Print is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.print, ResourcePlannerConstants.topSection.print);

        StepLogger.step('Validating Close is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.close, ResourcePlannerConstants.topSection.close);

        StepLogger.step('Validating Note is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.note, ResourcePlannerConstants.topSection.note);

        StepLogger.step('Validating Make Public is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.makePublic, ResourcePlannerConstants.topSection.makePublic);

        StepLogger.step('Validating import Cost Plan is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.importCostPlan, ResourcePlannerConstants.topSection.importCostPlan);

        StepLogger.step('Validating Export to Excel is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.exportToExcel, ResourcePlannerConstants.topSection.exportToExcel);

        StepLogger.step('Validating AllocateValue is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.allocateValue, ResourcePlannerConstants.topSection.allocateValue);

        StepLogger.step('Validating delete is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.delete, ResourcePlannerConstants.topSection.delete);

        StepLogger.step('Validating importWork is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.topSection.importWork, ResourcePlannerConstants.topSection.importWork);
    }

    static async validateButtonSection() {
        StepLogger.step('Validating Show Grouping  is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttonSection.showGrouping, ResourcePlannerConstants.buttonSection.showGrouping);

        StepLogger.step('Validating Heat Map  is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttonSection.heatMap, ResourcePlannerConstants.buttonSection.heatMap);

        StepLogger.step('Validating Show Grouping  is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttonSection.filter, ResourcePlannerConstants.buttonSection.showFilter);

        StepLogger.step('Validating Select Column  is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttonSection.selectColumn, ResourcePlannerConstants.buttonSection.selectResColumnsBtn);

        StepLogger.step('Validating Match   is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttonSection.match, ResourcePlannerConstants.buttonSection.matchButton);

        StepLogger.step('Validating clear sorting  is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttonSection.clearSorting, ResourcePlannerConstants.buttonSection.clearSorting);

        StepLogger.step('Validating Analyze is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttonSection.analyze, ResourcePlannerConstants.buttonSection.analyzeButton);

        StepLogger.step('Validating Add is Present');
        await CommonPageHelper.fieldDisplayedValidation
        (ResourcePlannerPage.buttonSection.add, ResourcePlannerConstants.buttonSection.addButton);
    }

    static async validateEditResourceOpenInNewTab() {
        StepLogger.verification('Switch To new Tab  ');
        await PageHelper.switchToNewTabIfAvailable(1);
        await PageHelper.switchToNewTabIfAvailable(0);
        await PageHelper.switchToNewTabIfAvailable(1);

        StepLogger.step('Validating Top Grid Item Name is Present');
        await CommonPageHelper.fieldDisplayedValidation(ResourcePlannerPage.topGrid.itemName, ResourcePlannerConstants.topGrid.itemName);
    }

    static async openEditResourceViaRibbonInNewTab() {
        StepLogger.step('Open edit resource In New Tab');
        await ElementHelper.openLinkInNewTab(ResourcePlannerPage.editResourceLink);
    }

    static async verifyResourcePlanDisplayed() {
        await ExpectationHelper.verifyText(
            CommonPage.dialogTitle,
            ResourcePlannerConstants.title,
            ResourcePlannerConstants.title,

        );
    }

    static async verifyDisabledResourceNotDisplayed(displayName: string) {
        await ExpectationHelper.verifyNotDisplayedStatus(
            ResourcePlannerPage.getButtomGridItemsByText(displayName),
            displayName,
        );
    }
}
