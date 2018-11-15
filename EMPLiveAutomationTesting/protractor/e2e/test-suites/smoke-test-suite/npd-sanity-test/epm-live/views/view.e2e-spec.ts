import {browser} from 'protractor';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {ProjectItemPage} from '../../../../../page-objects/pages/items-page/project-item/project-item.po';
import {PageHelper} from '../../../../../components/html/page-helper';
import {ProjectItemPageHelper} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../../../helpers/suite-names';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {EventsPage} from '../../../../../page-objects/pages/my-workplace/events/events.po';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {CheckboxHelper} from '../../../../../components/html/checkbox-helper';
import {ElementHelper} from '../../../../../components/html/element-helper';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    it('Create Column - [970069]', async () => {
        StepLogger.caseId = 970069;
        const uniqueId = PageHelper.getUniqueId();
        StepLogger.preCondition('Select "Navigation" icon  from left side menu');
        StepLogger.preCondition('Select Projects -> Projects from the options displayed');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        StepLogger.preCondition('Select any project from project center');
        await PageHelper.click(CommonPage.project);
        StepLogger.preCondition('Click ITEMS tab select Edit Plan');
        await PageHelper.click(CommonPage.editPlan);
        StepLogger.preCondition('click on Project Planner');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        // Planner takes time to get open so sleep required
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);

        StepLogger.stepId(1);
        StepLogger.step('Click on "Views" tab');
        await PageHelper.click(ProjectItemPage.viewsButton);
        StepLogger.step('Click on Create Column icon from the button menu');
        await PageHelper.click(EventsPage.createColumn);

        StepLogger.verification('Create Column pop up is displayed with following options:' +
            'Name and Type' +
            'Additional Column Settings' +
            'Column Validations' +
            'OK button' +
            'Cancel button');
        await browser.sleep(PageHelper.timeout.s);
        await CommonPageHelper.switchToContentFrame();
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.createColumnTabLabel.nameAndType))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.createColumnTabLabel.nameAndType));
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.createColumnTabLabel.additionalColumnSetting)).toBe
        (true, ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.createColumnTabLabel.additionalColumnSetting));
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.createColumnTabLabel.columnValidation)).toBe
        (true, ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.createColumnTabLabel.columnValidation));
        await expect(await PageHelper.isElementDisplayed(CommonPage.okButton)).toBe
        (true, ValidationsHelper.getLabelDisplayedValidation(CommonPageConstants.formLabels.ok));
        await expect(await PageHelper.isElementDisplayed(CommonPage.cancelButton)).toBe
        (true, ValidationsHelper.getLabelDisplayedValidation(CommonPageConstants.formLabels.cancel));

        StepLogger.stepId(2);
        StepLogger.step('Enter/Select below values in "Create Column" pop up' +
            'Column name: Enter Name for Column [Ex: New Column 1]' +
            'The type of information in this column is: Select the radio button "Number (1, 1.0, 100)"' +
            'Leave all other values as is/default');
        await CheckboxHelper.markCheckbox(EventsPage.numberCheckbox, true);
        await TextboxHelper.sendKeys(EventsPage.columnNameField, uniqueId);
        await TextboxHelper.sendKeys(EventsPage.descriptionField, CommonPageConstants.title);

        StepLogger.verification('the respective details should get populated');
        await CheckboxHelper.markCheckbox(EventsPage.choiceCheckbox, true);
        await expect(await TextboxHelper.hasValue(EventsPage.columnNameField, uniqueId))
            .toBe(true, ValidationsHelper.getFieldShouldHaveValueValidation(CommonPageConstants.columnName, uniqueId));

        StepLogger.stepId(3);
        StepLogger.step('Click OK button in Create Column pop up');
        await ElementHelper.scrollToElement(CommonPage.okButton);
        await ElementHelper.clickUsingJs(CommonPage.okButton);

        StepLogger.verification('Create Column window is Closed');
        await WaitHelper.waitForElementToBeHidden(CommonPage.okButton);
        await expect(await CommonPage.okButton.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.createColumn));

        StepLogger.verification('Project Planner page is displayed');
        await expect(await CommonPage.pageHeaders.projects.projectPlanner.isPresent()).toBe(true,
            ValidationsHelper.getDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        StepLogger.stepId(4);
        StepLogger.step('Click Close button in Project Planner window');
        await ElementHelper.clickUsingJs(ProjectItemPage.close);
        await PageHelper.waitForAlertToBePresent();
        await PageHelper.acceptAlert();

        StepLogger.verification('Project Planner window is Closed');
        await expect(await CommonPage.pageHeaders.projects.projectPlanner.isPresent()).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        StepLogger.verification('Project Center page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        StepLogger.stepId(5);
        StepLogger.step('Select the project in which new column is added in step# 3 [Ex: Smoke Test Project 2]' +
            'Click on the ITEMS tab above the grid From the ITEMS ribbon menu, click on Edit Plan' +
            'Click on Project Planner in the list of planners displayed');
        StepLogger.step('Click ITEMS tab select Edit Plan');
        await PageHelper.click(CommonPage.editPlan);
        StepLogger.step('click on Project Planner');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);

        StepLogger.verification('"Project Planner" window is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.save))
            .toBe(true, ValidationsHelper.getWindowShouldBeDisplayedValidation
            (CommonPageConstants.pageHeaders.projects.projectPlanner));

        StepLogger.stepId(6);
        StepLogger.step('Click on "Views" tab');
        await PageHelper.click(ProjectItemPage.viewsButton);
        StepLogger.step('Click on Create Column icon from the button menu');
        await PageHelper.click(EventsPage.selectColumn);

        StepLogger.verification('"Select columns to display" pop up is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.createColumnDlgBox))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.createColumnTabLabel.createColumn));

        StepLogger.stepId(7);
        StepLogger.step('Check for display of newly created column [Ex: New Column 1] in "Select columns to display" pop up');
        StepLogger.verification('Newly created column [Ex: New Column 1] is displayed in Select columns to display pop up');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(uniqueId)))
            .toBe(true, ValidationsHelper.getFieldShouldHaveValueValidation(CommonPageConstants.columnName, uniqueId));

        StepLogger.stepId(8);
        StepLogger.step('Click Cancel button in Select columns to display pop up');
        await PageHelper.click(ProjectItemPage.cancelPopupButton.cancel);

        StepLogger.verification('"Project Planner" window is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(true, ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));
    });

    it('Create View - [970043]', async () => {
        StepLogger.caseId = 970043;
        const uniqueId = PageHelper.getUniqueId();
        StepLogger.preCondition('Select "Navigation" icon  from left side menu');
        StepLogger.preCondition('Select Projects -> Projects from the options displayed');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );
        StepLogger.preCondition('Select any project from project center');
        await PageHelper.click(CommonPage.project);
        StepLogger.preCondition('Click ITEMS tab select Edit Plan');
        await PageHelper.click(CommonPage.editPlan);
        StepLogger.preCondition('click on Project Planner');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);
        // Planner takes time to get open so sleep required
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);
        StepLogger.preCondition('Unchecked checkbox If checked already');
        await ProjectItemPageHelper.unCheckedSelectColumnIfChecked;

        StepLogger.stepId(1);
        StepLogger.step('Click on "Views" tab');
        await PageHelper.click(ProjectItemPage.viewsButton);
        StepLogger.step('Click on Create Column icon from the button menu');
        await PageHelper.click(EventsPage.selectColumn);

        StepLogger.verification('"Select columns to display" pop up is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.createColumnDlgBox))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.createColumnTabLabel.createColumn));

        StepLogger.verification('Three buttons OK, Hide all, Cancel are displayed at bottom of the pop up');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.selectColumnLabel.ok))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.selectColumnLabel.ok));
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.selectColumnLabel.hideAll))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.selectColumnLabel.hideAll));
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.selectColumnLabel.cancel))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.selectColumnLabel.cancel));

        StepLogger.stepId(2);
        StepLogger.step('Check the boxes on the right side of column to be added to the "View" and un-check columns you wish' +
            ' to exclude from the view');
        await PageHelper.click(ProjectItemPage.selectColumnName);
        StepLogger.verification('Required Columns are Checked/Unchecked');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.checkedSelectColumn))
            .toBe(true, ValidationsHelper.getCheckBoxSelectedValidation());

        StepLogger.stepId(3);
        StepLogger.step('Check the boxes on the right side of column to be added to the "View" and un-check columns you wish' +
            ' to exclude from the view');
        await PageHelper.click(ProjectItemPage.selectColumnLabel.ok);

        StepLogger.verification('"Select columns to display" pop up is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.actuallCostColumn))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.actualCost));

        StepLogger.stepId(4);
        StepLogger.step('Click on "Save View" from ribbon button menu');
        await PageHelper.click(ProjectItemPage.saveViewButton);

        StepLogger.verification('Save View pop up is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.saveViewNameField))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.saveView));

        StepLogger.stepId(5);
        StepLogger.step('Enter a Name of the view [Ex: Smoke Test View 1] Leave the Default View check box Un-checked');
        await TextboxHelper.sendKeys(ProjectItemPage.saveViewNameField, uniqueId);

        StepLogger.stepId(6);
        StepLogger.step('Click on "OK" button in "Save View" pop up');
        await PageHelper.click(ProjectItemPage.OkButton);

        StepLogger.verification('Save View pop up is closed');
        await WaitHelper.waitForElementToBeHidden(CommonPage.okButton);
        await expect(await CommonPage.okButton.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.saveView));

        StepLogger.verification('Project Planner page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner)).toBe(true,
            ValidationsHelper.getDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        StepLogger.verification('Project Planner page is displayed');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(uniqueId))).toBe(true,
            ValidationsHelper.getDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        StepLogger.stepId(7);
        StepLogger.step('Expand "Current View" drop down (From ribbon panel)');
        // waithelper doesn't work need to sleep to made changes
        await browser.sleep(PageHelper.timeout.xs);
        await PageHelper.click(ProjectItemPage.currentViewDropDown);

        StepLogger.verification('Project Planner page is displayed');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(uniqueId))).toBe(true,
            ValidationsHelper.getDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));
    });
});
