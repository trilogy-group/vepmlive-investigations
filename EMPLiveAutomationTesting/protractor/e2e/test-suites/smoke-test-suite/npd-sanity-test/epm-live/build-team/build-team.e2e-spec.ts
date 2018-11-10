import {browser} from 'protractor';
import {PageHelper} from '../../../../../components/html/page-helper';
import {ProjectItemPageConstants} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {ProjectItemPage} from '../../../../../page-objects/pages/items-page/project-item/project-item.po';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../../../helpers/suite-names';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {ProjectItemPageHelper} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {ProjectItemPageValidations} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.validations';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {CheckboxHelper} from '../../../../../components/html/checkbox-helper';

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

    it('Add resources under "Current Team" - [778264]', async () => {
        StepLogger.caseId = 778264;
        StepLogger.stepId(1);
        StepLogger.step('Select "Navigation" icon  from left side menu');
        StepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.stepId(3);
        StepLogger.step('Select check-box for any Project');
        await PageHelper.click(CommonPage.record);

        StepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        StepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        StepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        await CommonPageHelper.switchToContentFrame();

        StepLogger.verification('"Current Team" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.currentTeam))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        StepLogger.verification('"Resource Pool" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.resourcePool))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.resourcePool));

        StepLogger.verification('"Current Team" section will list the resources attached to the project');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamRecords.currentTeam.first()))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        StepLogger.verification('"Resource Pool" section will list the resources other than "Current Team" section');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamRecords.resourcePool.first()))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.resourcePool));

        StepLogger.stepId(4);
        StepLogger.step('Select check-box for any of the resources displayed in "Resource Pool" (Right side)');
        await PageHelper.click(ProjectItemPage.teamRecords.resourcePool.first());
        const selectedResourcePoolResourceName = await ProjectItemPage.teamRecordsName.resourcePool.first().getText();

        StepLogger.step('Click on "< Add" button');
        await PageHelper.click(ProjectItemPage.teamChangeButtons.add);

        StepLogger.verification('Selected resource [Ex: Generic Resource 1] is added to "Current Team" (Left Side) grid');
        await expect(await ProjectItemPageHelper.checkResourceAddedInCurrentTeam(selectedResourcePoolResourceName))
            .toBe(true,
                ProjectItemPageValidations.getResourceAddedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        StepLogger.stepId(5);
        StepLogger.step('Click on "Save & Close" button in "Edit Team" window');
        await WaitHelper.waitForElementToBeClickable(CommonPage.ribbonItems.saveAndClose);
        await PageHelper.click(CommonPage.ribbonItems.saveAndClose);
        // After Saving Record, Security queue job takes 5-10 seconds to complete and update record.
        await WaitHelper.staticWait(5000);

        StepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        StepLogger.verification('"Edit Team" window is closed');
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        StepLogger.verification('"Project Center" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        StepLogger.stepId(6);
        StepLogger.step('Select check-box for any Project');
        await PageHelper.click(CommonPage.record);

        StepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        StepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        StepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await CommonPageHelper.switchToContentFrame();

        StepLogger.verification('Selected resource [Ex: Generic Resource 1] is added to "Current Team" (Left Side) grid');
        await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.teamRecordsName.currentTeam.last());
        await expect(await ProjectItemPageHelper.checkResourceAddedInCurrentTeam(selectedResourcePoolResourceName))
            .toBe(true,
                ProjectItemPageValidations.getResourceAddedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        StepLogger.stepId(7);
        StepLogger.step('Click "Close" button in "Edit Team" window');
        await PageHelper.click(CommonPage.ribbonItems.close);

        StepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        StepLogger.verification('"Edit Team" window is closed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        StepLogger.verification('"Project Center" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        StepLogger.verification('All previously created Projects are displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.record))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.inputLabels.projectName));
    });

    it('Check behavior of "Save and Close" button - [778301]', async () => {
        StepLogger.caseId = 778301;
        StepLogger.stepId(1);
        StepLogger.step('Select "Navigation" icon  from left side menu');
        StepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.stepId(3);
        StepLogger.step('Select check-box for any Project');
        await PageHelper.click(CommonPage.record);

        StepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        StepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        StepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        StepLogger.stepId(4);
        StepLogger.step('Check status of "Save & Close" button');

        await CommonPageHelper.switchToContentFrame();

        await expect(await PageHelper.isElementDisplayed(CommonPage.disabledribbonItems.saveAndClose))
            .toBe(true,
                ValidationsHelper.getButtonDisabledValidation(CommonPageConstants.ribbonLabels.saveAndClose));

        StepLogger.stepId(5);
        StepLogger.step('Select check-box for any of the resources displayed in "Resource Pool" (Right side)');
        await PageHelper.click(ProjectItemPage.teamRecords.resourcePool.first());
        const selectedResourcePoolResourceName = await ProjectItemPage.teamRecordsName.resourcePool.first().getText();

        StepLogger.step('Click on "< Add" button');
        await PageHelper.click(ProjectItemPage.teamChangeButtons.add);

        StepLogger.verification('Selected resource [Ex: Generic Resource 1] is added to "Current Team" (Left Side) grid');
        await expect(await ProjectItemPageHelper.checkResourceAddedInCurrentTeam(selectedResourcePoolResourceName))
            .toBe(true,
                ProjectItemPageValidations.getResourceAddedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        StepLogger.stepId(6);
        StepLogger.step('check status of "Save & Close" button');
        StepLogger.verification('"Save & Close" button displayed in Enabled mode after changes done in "Edit Team" window');
        await expect(await PageHelper.isElementDisplayed(CommonPage.disabledribbonItems.saveAndClose))
            .toBe(false,
                ValidationsHelper.getButtonEnabledValidation(CommonPageConstants.ribbonLabels.saveAndClose));

        StepLogger.stepId(7);
        StepLogger.step('Click on "Save & Close" button in "Edit Team" window');
        await WaitHelper.waitForElementToBeClickable(CommonPage.ribbonItems.saveAndClose);
        await PageHelper.click(CommonPage.ribbonItems.saveAndClose);
        // After Saving Record, Security queue job takes 5-10 seconds to complete and update record.
        await WaitHelper.staticWait(5000);

        StepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        StepLogger.verification('"Edit Team" window is closed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        StepLogger.verification('"Project Center" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        StepLogger.stepId(8);
        StepLogger.step('Select check-box for any Project');
        await PageHelper.click(CommonPage.record);

        StepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        StepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        StepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await CommonPageHelper.switchToContentFrame();

        StepLogger.verification('Selected resource [Ex: Generic Resource 1] is added to "Current Team" (Left Side) grid');
        await WaitHelper.waitForElementToBeDisplayed(ProjectItemPage.teamRecordsName.currentTeam.last());
        await expect(await ProjectItemPageHelper.checkResourceAddedInCurrentTeam(selectedResourcePoolResourceName))
            .toBe(true,
                ProjectItemPageValidations.getResourceAddedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        StepLogger.stepId(9);
        StepLogger.step('Click "Close" button in "Edit Team" window');
        await PageHelper.click(CommonPage.ribbonItems.close);

        StepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        StepLogger.verification('"Edit Team" window is closed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        StepLogger.verification('"Project Center" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        StepLogger.verification('All previously created Projects are displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.record))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.inputLabels.projectName));
        return selectedResourcePoolResourceName;
    });

    it('View the Build Team-Current team members in Project Planner. - [778315]', async () => {
        StepLogger.caseId = 778315;
        const uniqueId = PageHelper.getUniqueId();

        StepLogger.preCondition('Execute test case C778301 and add a resource to Project [Ex: Smoke Test Project 2 /' +
            ' Generic Resource 1]');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects, CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter, );
        await PageHelper.click(CommonPage.projectCheckbox);
        await PageHelper.click(CommonPage.ribbonTitles.items);
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await CommonPageHelper.switchToContentFrame();
        await PageHelper.click(ProjectItemPage.teamRecords.resourcePool.first());
        const selectedResourcePoolResourceName = await ProjectItemPage.teamRecordsName.resourcePool.first().getText();
        await PageHelper.click(ProjectItemPage.teamChangeButtons.add);
        await WaitHelper.waitForElementToBeClickable(CommonPage.ribbonItems.saveAndClose);
        await PageHelper.click(CommonPage.ribbonItems.saveAndClose);
        // 5 Sec wait required to let it save
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.switchToDefaultContent();

        StepLogger.stepId(1);
        StepLogger.step('Select "Navigation" icon  from left side menu');
        StepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.stepId(2);
        StepLogger.step('Select check-box for any Project');
        await ElementHelper.browserRefresh();
        await PageHelper.click(CommonPage.projectCheckbox);

        StepLogger.step('Click on "Items" tab');
        await browser.sleep(PageHelper.timeout.m);
        await PageHelper.click(CommonPage.ribbonTitles.items);

        StepLogger.step('Click ITEMS tab select Edit Plan');
        await CommonPageHelper.clickOnEditPlan();

        StepLogger.verification('Select Planner pop-up displays with different planner options to select');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle)).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.selectPlanner));

        StepLogger.stepId(3);
        StepLogger.step('Click on Project Planner in the list of planners displayed');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);

        StepLogger.verification('The Project Planner page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        StepLogger.verification('NO Tasks displayed in Project Planner');
        // After select project Planner wait required, not element found which can use with waitHelper.
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);
        await CommonPageHelper.deleteTask();
        await expect(await ProjectItemPage.selectTaskName.isPresent()).toBe(false,
            ValidationsHelper.getNotDisplayedValidation(CommonPageConstants.pageHeaders.projects.tasks));

        StepLogger.stepId(4);
        StepLogger.step('Click on + Task button');
        // After select project Planner wait required, not element found which can use with waitHelper.
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.waitForElementToBeHidden(CommonPage.plannerbox);
        await CommonPageHelper.deleteTask();
        await PageHelper.click(CommonPage.ribbonItems.addTask);

        StepLogger.step('Enter details for Task (Name, Hours)');
        await PageHelper.actionSendKeys(uniqueId);
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.work);
        await PageHelper.actionSendKeys(CommonPageConstants.costData.firstData);
        await ElementHelper.clickUsingJs(ProjectItemPage.save);
        // After save It need static wait(5 sec) and no element found which get change after save.
        await browser.sleep(PageHelper.timeout.m);

        StepLogger.verification('A new task is created and required details entered [Ex: New Task 1]');
        await expect(ProjectItemPageHelper.newTasksFields.title.getText()).toBe(uniqueId,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.tasks));
        await expect(ProjectItemPageHelper.newTasksFields.work.getText()).toBe(CommonPageConstants.costData.firstData,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.workHours));

        StepLogger.stepId(5);
        StepLogger.step('Click in the Assigned To column');
        await PageHelper.click(ProjectItemPage.assignToDropDown);

        StepLogger.step('Check the users displayed in the drop down');
        await expect(await PageHelper.isElementPresent(ProjectItemPageHelper.selectFirstAssign()))
            .toBe(true, ProjectItemPageValidations.getResourceAddedValidation
            (ProjectItemPageConstants.teamSectionlabels.currentTeam));

        StepLogger.verification('Newly added resource as per pre requisites [Ex: Generic Resource 1] is displayed in the' +
            ' drop down');

        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(selectedResourcePoolResourceName)))
            .toBe(true, ProjectItemPageValidations.getResourceAddedValidation
            (ProjectItemPageConstants.teamSectionlabels.currentTeam));
    });

    it('Verify functionality of "Always follow Web-Settings" check-box.. - [778281]', async () => {
        StepLogger.caseId = 778281;
        StepLogger.stepId(1);
        StepLogger.step('Select "Navigation" icon  from left side menu');
        StepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
        );

        StepLogger.stepId(3);
        StepLogger.step('Select check-box for any Project [Ex: Smoke Test Project 2]');
        await PageHelper.click(CommonPage.record);

        StepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        StepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        StepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(true, ValidationsHelper.getWindowShouldBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        await CommonPageHelper.switchToContentFrame();

        StepLogger.verification('"Build Team" tab is selected by default');
        // If we able to access Close button under Build Team tab that means Build tab is selected
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.close))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.close));

        StepLogger.verification('"Current Team" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.currentTeam))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        StepLogger.verification('"Resource Pool" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.resourcePool))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.resourcePool));

        StepLogger.stepId(4);
        StepLogger.step('Click on the "Title" link for the user name who is logged into application from the Current Team' +
            ' grid displayed on left side');
        await PageHelper.click(ProjectItemPageHelper.getlink.adminUser);
        await PageHelper.switchToDefaultContent();

        StepLogger.verification('User Information pop-up is displayed');
        await PageHelper.switchToFrame(CommonPage.userInfoFrame);

        StepLogger.stepId(5);
        StepLogger.step('Click on "My Language And Region" link displayed on top of "User Information" pop-up');
        await PageHelper.click(ProjectItemPageHelper.getlink.myLanguageAndRegion);
        await PageHelper.switchToNewTabIfAvailable(1);

        StepLogger.verification('New tab is opened and "Language and Region" page is displayed');
        await expect(await browser.getTitle()).toBe(ProjectItemPageConstants.languageAndRegion,
            ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.languageAndRegion));

        StepLogger.stepId(6);
        StepLogger.step('Scroll down till the section "Region" is visible');
        await ElementHelper.scrollToElement(ProjectItemPageHelper.getlink.region);

        StepLogger.step('Un check the check box Always follow web settings displayed in Follow Web Settings row');
        await CheckboxHelper.markCheckbox(CommonPage.regionCheckBox, false);

        StepLogger.verification('Always follow web settings check box is unchecked');
        await expect(await CheckboxHelper.isCheckboxChecked(CommonPage.regionCheckBox)).toBe(false,
            ValidationsHelper.getCheckBoxNotSelectedValidation());

        StepLogger.verification('Options in Time Zone and Region gets enabled');
        await expect(await CommonPage.timeZone.isPresent()).toBe(false,
            ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.timeZone));
    });

});
