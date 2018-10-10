import {ProjectItemPageConstants} from '../project-item/project-item-page.constants';
import {RiskItemPageConstants} from './risk-item-page.constants';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {CommonPageHelper} from '../../common/common-page.helper';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {ElementHelper} from '../../../../components/html/element-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {RiskItemPage} from './risk-item.po';
import {CommonPage} from '../../common/common.po';
import {CommonPageConstants} from '../../common/common-page.constants';
import {CheckboxHelper} from '../../../../components/html/checkbox-helper';
import {CreateNewPage} from '../create-new.po';
import {HomePage} from '../../homepage/home.po';
import {AnchorHelper} from '../../../../components/html/anchor-helper';
import {ProjectItemPage} from '../project-item/project-item.po';

export class RiskItemPageHelper {

    static async editRisk() {
        await this.verifyPage();

        StepLogger.stepId(4);
        StepLogger.step('Enter/Select required details in "Edit Risk" page as described below');

        const labels = RiskItemPageConstants.inputLabels;
        StepLogger.step('Title *: Random New Risk Item');
        const uniqueId = PageHelper.getUniqueId();
        const titleValue = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(RiskItemPage.inputs.title, titleValue);

        StepLogger.step('Status: Select the value "In Progress"');
        const status = CommonPageConstants.statuses.notStarted;
        await PageHelper.sendKeysToInputField(RiskItemPage.inputs.status, status);

        const priority = CommonPageConstants.priorities.low;
        StepLogger.step('Priority: Select the value "(1) High"');
        await PageHelper.sendKeysToInputField(RiskItemPage.inputs.priority, priority);

        StepLogger.verification('Required values Entered/Selected in "Edit Risk" Page');
        StepLogger.verification('Verify - Title *: Random New Risk Item');
        await expect(await TextboxHelper.hasValue(RiskItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, titleValue));

        StepLogger.verification('Verify - Status: Select the value "In Progress"');
        await expect(await ElementHelper.hasSelectedOption(RiskItemPage.inputs.status, status))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.status, status));

        StepLogger.verification('Verify - Priority: Select the value "(1) High"');
        await expect(await ElementHelper.hasSelectedOption(RiskItemPage.inputs.priority, priority))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.priority, priority));

        StepLogger.stepId(5);
        StepLogger.step('Click "Save" button in "Edit Risk" page');
        await PageHelper.click(CommonPage.formButtons.save);

        StepLogger.verification('"Risks" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.risks))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.risks));

        StepLogger.verification('"Edit Risk" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(RiskItemPageConstants.editPageName));

        StepLogger.verification('Updated Risk details (Title, Status, Priority) displayed in "Risks" page');

        StepLogger.verification('Search item by title');
        await CommonPageHelper.searchItemByTitle(titleValue, RiskItemPageConstants.columnNames.title);

        StepLogger.verification('Show columns whatever is required');
        await CommonPageHelper.showColumns([
            RiskItemPageConstants.columnNames.title,
            RiskItemPageConstants.columnNames.status,
            RiskItemPageConstants.columnNames.priority]);

        StepLogger.verification('Verify record by title');
        const firstTableColumns = [titleValue];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(firstTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(firstTableColumns.join(CommonPageConstants.and)));

        StepLogger.verification('Verify by other properties');
        const secondTableColumns = [status, priority];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(secondTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(secondTableColumns.join(CommonPageConstants.and)));
    }

    static async unCheckColumns() {
        StepLogger.step('Deselect non required and default selected column "Schedule Status"');
        await expect(await PageHelper.isElementDisplayed(CommonPage.viewNewPageActions.scheduledStatusCheckBox))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(CommonPageConstants.newPublicViewformLabels.scheduleStatus));
        await CheckboxHelper.markCheckbox(CommonPage.viewNewPageActions.scheduledStatusCheckBox, false);

        StepLogger.step('Deselect non required and default selected column "Exposure"');
        await expect(await PageHelper.isElementDisplayed(CommonPage.viewNewPageActions.exposureCheckBox))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(CommonPageConstants.newPublicViewformLabels.exposure));
        await CheckboxHelper.markCheckbox(CommonPage.viewNewPageActions.exposureCheckBox, false);

        StepLogger.step('Deselect non required and default selected column Schedule "Due"');
        await expect(await PageHelper.isElementDisplayed(CommonPage.viewNewPageActions.dueCheckBox))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(CommonPageConstants.newPublicViewformLabels.due));
        await CheckboxHelper.markCheckbox(CommonPage.viewNewPageActions.dueCheckBox, false);
    }

    static async verifyPage() {
        StepLogger.verification('"Edit Risk" page is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(RiskItemPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.editPageName));
    }

    static async verifyRiskViewAdd(titleNewView: string) {
        StepLogger.verification('Newly created Public risk view is selected in "View" drop down');
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getDropDownViewByText(titleNewView)))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(titleNewView));

        StepLogger.verification(`${RiskItemPageConstants.columnNames.title} columns selected to display in the view should be displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.viewPageActions.titleViewColumn))
            .toBe(true,
                ValidationsHelper.getNewViewCloumnShouldDisplayed(RiskItemPageConstants.columnNames.title));

        StepLogger.verification(`${RiskItemPageConstants.columnNames.assignedTo} columns
        selected to display in the view should be displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.viewPageActions.assignedToViewColumn))
            .toBe(true,
                ValidationsHelper.getNewViewCloumnShouldDisplayed(RiskItemPageConstants.columnNames.assignedTo));

        StepLogger.verification(`${RiskItemPageConstants.columnNames.status} columns selected to display in the view should be displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.viewPageActions.statusViewColumn))
            .toBe(true,
                ValidationsHelper.getNewViewCloumnShouldDisplayed(RiskItemPageConstants.columnNames.status));

        StepLogger.verification(`${RiskItemPageConstants.columnNames.dueDate} columns selected to display in the view should be displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.viewPageActions.dueDateViewColumn))
            .toBe(true,
                ValidationsHelper.getNewViewCloumnShouldDisplayed(RiskItemPageConstants.columnNames.dueDate));
    }

    static async deleteOptionViaRibbon(item = CommonPage.record) {
        await CommonPageHelper.selectRecordFromGrid(item);

        await CommonPageHelper.refreshPageIfRibbonElementIsDisable(RiskItemPage.deleteRisk);

        StepLogger.step('Select "Delete" from the options displayed');
        await PageHelper.click(RiskItemPage.deleteRisk);

        await PageHelper.acceptAlert();
    }

    static async clickCreateNew() {
        StepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);

    }

    static async clickNewRiskIcon() {
        StepLogger.step('Click on "Risk" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.risk);

    }

    static async enterRiskTitle() {
        const uniqueId = PageHelper.getUniqueId();
        const labels = RiskItemPageConstants.inputLabels;
        const titleValue = `${labels.title} ${uniqueId}`;

        StepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        StepLogger.step('Title *: Random New Risk Item');
        await TextboxHelper.sendKeys(RiskItemPage.inputs.title, titleValue);

        return titleValue;
    }

    static async selectProjectFromDropDown() {

        StepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');
        await PageHelper.click(CommonPage.projectShowAllButton);

        await WaitHelper.waitForElementToBeDisplayed(RiskItemPage.inputs.project);

        await PageHelper.click(RiskItemPage.inputs.project);
    }

    static async saveRisk() {
        StepLogger.step('Click on "Save" button in "Risks - New Item" window');
        await PageHelper.click(CommonPage.formButtons.save);
    }

    static async createRiskAndValidateIt() {
        StepLogger.step('Enter/Select required details in "Risks - New Item" window as described below');

        await this.clickCreateNew();

        await this.clickNewRiskIcon();

        const titleValue = await this.enterRiskTitle();

        await this.selectProjectFromDropDown();

        await this.saveRisk();

        await PageHelper.switchToDefaultContent();
        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,

            titleValue,
            RiskItemPageConstants.columnNames.title);

        StepLogger.verification('Newly created Risk [Ex: New Risk Item 1] displayed in "Risks" page');
        await CommonPageHelper.labelDisplayedValidation(AnchorHelper.getElementByTextInsideGrid(titleValue), titleValue);
        return titleValue;
    }

    static async editRiskAndValidateIt(titleValue: string) {
        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,

            titleValue,
            RiskItemPageConstants.columnNames.title);

        StepLogger.step('Make some changes and click on "Save" button');
        await CommonPageHelper.editOptionViaRibbon();

        titleValue = titleValue + 'Edited';
        await TextboxHelper.sendKeys(RiskItemPage.inputs.title, titleValue);

        await this.saveRisk();

        await PageHelper.switchToDefaultContent();

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,

            titleValue,
            RiskItemPageConstants.columnNames.title);

        StepLogger.verification('Newly created Risk [Ex: New Risk Item 1] displayed in "Risks" page');
        await CommonPageHelper.labelDisplayedValidation(AnchorHelper.getElementByTextInsideGrid(titleValue), titleValue);

        return titleValue;

    }

    static async deleteRiskAndValidateIt(titleValue: string) {
        StepLogger.step('Select a Risk and Click on "ITEMS" >> Delete Item');
        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,

            titleValue,
            RiskItemPageConstants.columnNames.title);

        await RiskItemPageHelper.deleteOptionViaRibbon();

        await CommonPageHelper.searchByTitle(HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,

            titleValue,
            RiskItemPageConstants.columnNames.title);

        StepLogger.step('Validating deleted Risk  is not  Present');
        await CommonPageHelper.fieldDisplayedValidation(ProjectItemPage.noProjecrMsg, ProjectItemPageConstants.noDataFound);
    }
}
