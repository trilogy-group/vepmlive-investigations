import {browser} from 'protractor';
import {SuiteNames} from '../../../../helpers/suite-names';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {SettingsPage} from '../../../../../page-objects/pages/settings/settings.po';
import {PlannerSettingsPageHelper} from '../../../../../page-objects/pages/settings/planner-setting/planner-settings-page.helper';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {PlannerSettingsPageConstants} from '../../../../../page-objects/pages/settings/planner-setting/planner-settings-page.constants';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {CheckboxHelper} from '../../../../../components/html/checkbox-helper';
import {PlannerSettingPage} from '../../../../../page-objects/pages/settings/planner-setting/planner-setting.po';

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

    it('Add new planner - [1032747]', async () => {
        StepLogger.caseId = 1032747;
        StepLogger.stepId(1);
        const uniqueId = PageHelper.getUniqueId();
        const plannerName = `${PlannerSettingsPageConstants.newPlannerDetails.name}${uniqueId}`;
        StepLogger.step('Click on "Main Gear Settings" icon  displayed in left bottom corner');
        await PageHelper.click(CommonPage.sidebarMenus.settings);

        const plannerReportingMenus = SettingsPage.menuItems.plannerSettings;

        StepLogger.verification('Various Settings Options displayed');
        await expect(await PageHelper.isElementDisplayed(plannerReportingMenus.rootMenu))
            .toBe(true, ValidationsHelper.getDisplayedValidation(PlannerSettingsPageConstants.validation.settings));

        StepLogger.stepId(2);
        StepLogger.step('Expand "Planner Settings" node');
        await PlannerSettingsPageHelper.expandPlannerSettingsNode();

        StepLogger.step('Click on "Planners" sub node');
        await PageHelper.click(PlannerSettingsPageHelper.menu.buttonLabel.planner);

        StepLogger.verification('Various Settings Options displayed');
        await expect(await PageHelper.isElementDisplayed(PlannerSettingsPageHelper.menu.menuTitles.planName))
            .toBe(true, ValidationsHelper.getDisplayedValidation(PlannerSettingsPageConstants.validation.planName));
        await expect(await PageHelper.isElementDisplayed(PlannerSettingsPageHelper.menu.menuTitles.souceList))
            .toBe(true, ValidationsHelper.getDisplayedValidation(PlannerSettingsPageConstants.validation.sourceList));
        await expect(await PageHelper.isElementDisplayed(PlannerSettingsPageHelper.menu.menuTitles.taskList))
            .toBe(true, ValidationsHelper.getDisplayedValidation(PlannerSettingsPageConstants.validation.taskList));
        await expect(await PageHelper.isElementDisplayed(PlannerSettingsPageHelper.menu.menuTitles.backToSetting))
            .toBe(true, ValidationsHelper.getDisplayedValidation(PlannerSettingsPageConstants.validation.backToSetting));
        await expect(await PageHelper.isElementDisplayed(PlannerSettingsPageHelper.menu.menuTitles.newPlanner))
            .toBe(true, ValidationsHelper.getDisplayedValidation(PlannerSettingsPageConstants.validation.addANewPlanner));

        StepLogger.stepId(3);
        StepLogger.step('Click on + Add New Planner button link');
        await PageHelper.click(PlannerSettingsPageHelper.menu.menuTitles.newPlanner);

        StepLogger.verification('Planner Settings page is displayed');
        await expect(await browser.getTitle()).toBe(PlannerSettingsPageConstants.plannerPage,
            ValidationsHelper.getPageDisplayedValidation(PlannerSettingsPageConstants.plannerPage));

        StepLogger.stepId(4);
        StepLogger.step('Enter/Select below value in Planner Settings page "General Settings"');
        StepLogger.step('Planner Name: Enter a Name for Planner [Ex: Smoke Test Planner 1]');
        await TextboxHelper.sendKeys(PlannerSettingPage.planNameField, plannerName);

        StepLogger.step('Planner Description: Enter Description for Planner [Ex: New Planner created as part of smoke test]');
        await TextboxHelper.sendKeys(PlannerSettingPage.planDiscriptionField,
            PlannerSettingsPageConstants.newPlannerDetails.description);

        StepLogger.step('Scroll down till the section Additional Settings is displayed');
        await ElementHelper.scrollToElement(PlannerSettingPage.startSoonCheckBox);

        StepLogger.step('Enforce Start as Soon as Possible: Check/Select the check box Enable Start as Soon as Possible');
        await CheckboxHelper.markCheckbox(PlannerSettingPage.startSoonCheckBox, true);

        // To Verify "Required values Entered/Selected in 'Planner Settings' page" is not posible
        await PlannerSettingsPageHelper.saveAndVerifyCreatePlanner(plannerName, true);
    });

    it('Edit Planner name - [1032780]', async () => {
        StepLogger.caseId = 1032780;
        const uniqueId = PageHelper.getUniqueId();
        StepLogger.preCondition('Add new planner');
        const plannerName = `${PlannerSettingsPageConstants.newPlannerDetails.name}${uniqueId}`;
        const plannerUpdatedName = PlannerSettingsPageConstants.newPlannerDetails.updatedName + uniqueId;
        await PlannerSettingsPageHelper.createPlanner(plannerName);

        StepLogger.stepId(1);
        StepLogger.step('Click on "Main Gear Settings" icon  displayed in left bottom corner');
        await PageHelper.click(CommonPage.sidebarMenus.settings);

        StepLogger.step('Expand "Planner Settings" node');
        await PlannerSettingsPageHelper.expandPlannerSettingsNode();

        StepLogger.step('Click on "Planners" sub node');
        await PageHelper.click(PlannerSettingsPageHelper.menu.buttonLabel.planner);

        StepLogger.verification('Planner Administration page is displayed');
        await expect(await browser.getTitle()).toBe(PlannerSettingsPageConstants.administration,
            ValidationsHelper.getPageDisplayedValidation(PlannerSettingsPageConstants.administration));

        StepLogger.verification('All existing Planners are displayed in the list along with the new planner created' +
            ' as per pre requisites [Ex: Smoke Test Planner 1]');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(plannerName)))
            .toBe(true, ValidationsHelper.getRecordCreatedValidation([plannerName]));

        StepLogger.stepId(2);
        StepLogger.step('Mouse over the name of the newly created planner [Ex: Smoke Test Planner 1]\n' +
            'Click on drop down seen on the right side of the planner name');
        await PageHelper.click(ElementHelper.getElementByText(plannerName));

        StepLogger.step('Select Edit Planner from the options displayed');
        await PageHelper.click(PlannerSettingsPageHelper.menu.menuTitles.editPlanner);

        // Values selected for the Planner while creating are pre populated in respective fields verify is not posible
        StepLogger.verification('Planner Settings page is displayed');
        await expect(await browser.getTitle()).toBe(PlannerSettingsPageConstants.plannerPage,
            ValidationsHelper.getPageDisplayedValidation(PlannerSettingsPageConstants.plannerPage));

        StepLogger.stepId(3);
        StepLogger.step('Planner Name: Enter a Name for Planner [Ex: Smoke Test Planner 1]');
        await TextboxHelper.sendKeys(PlannerSettingPage.planNameField, plannerUpdatedName);

        StepLogger.step('Planner Description: Enter Description for Planner [Ex: New Planner created as part of smoke test]');
        await TextboxHelper.sendKeys(PlannerSettingPage.planDiscriptionField,
            PlannerSettingsPageConstants.newPlannerDetails.updatedDescription);

        // Required changes done in 'Planner Settings' page verify is not posible
        // Step from 4 Inside the function
        await PlannerSettingsPageHelper.saveAndVerifyCreatePlanner(plannerUpdatedName, true);

    });

});
