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
import {browser} from 'protractor';
import {CheckboxHelper} from '../../../../../components/html/checkbox-helper';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Add resources under "Current Team" - [778264]', async () => {
        const stepLogger = new StepLogger(778264);
        stepLogger.stepId(1);
        stepLogger.step('Select "Navigation" icon  from left side menu');
        stepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Select check-box for any Project');
        await PageHelper.click(CommonPage.record);

        stepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        stepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        stepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        await CommonPageHelper.switchToContentFrame(stepLogger);

        stepLogger.verification('"Current Team" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.currentTeam))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        stepLogger.verification('"Resource Pool" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.resourcePool))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.resourcePool));

        stepLogger.verification('"Current Team" section will list the resources attached to the project');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ProjectItemPage.teamRecords.currentTeam.first());
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamRecords.currentTeam.first()))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        stepLogger.verification('"Resource Pool" section will list the resources other than "Current Team" section');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamRecords.resourcePool.first()))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.resourcePool));

        stepLogger.stepId(4);
        stepLogger.step('Select check-box for any of the resources displayed in "Resource Pool" (Right side)');
        await PageHelper.click(ProjectItemPage.teamRecords.resourcePool.first());
        const selectedResourcePoolResourceName = await ProjectItemPage.teamRecordsName.resourcePool.first().getText();

        stepLogger.step('Click on "< Add" button');
        await PageHelper.click(ProjectItemPage.teamChangeButtons.add);

        stepLogger.verification('Selected resource [Ex: Generic Resource 1] is added to "Current Team" (Left Side) grid');
        await expect(await ProjectItemPageHelper.checkResourceAddedInCurrentTeam(selectedResourcePoolResourceName))
            .toBe(true,
                ProjectItemPageValidations.getResourceAddedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        stepLogger.stepId(5);
        stepLogger.step('Click on "Save & Close" button in "Edit Team" window');
        await WaitHelper.getInstance().waitForElementToBeClickable(CommonPage.ribbonItems.saveAndClose);
        await PageHelper.click(CommonPage.ribbonItems.saveAndClose);
        // After Saving Record, Security queue job takes 5-10 seconds to complete and update record.
        await WaitHelper.getInstance().staticWait(5000);

        stepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"Edit Team" window is closed');
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        stepLogger.verification('"Project Center" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        stepLogger.stepId(6);
        stepLogger.step('Select check-box for any Project');
        await PageHelper.click(CommonPage.record);

        stepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        stepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        stepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await CommonPageHelper.switchToContentFrame(stepLogger);

        stepLogger.verification('Selected resource [Ex: Generic Resource 1] is added to "Current Team" (Left Side) grid');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ProjectItemPage.teamRecordsName.currentTeam.last());
        await expect(await ProjectItemPageHelper.checkResourceAddedInCurrentTeam(selectedResourcePoolResourceName))
            .toBe(true,
                ProjectItemPageValidations.getResourceAddedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        stepLogger.stepId(7);
        stepLogger.step('Click "Close" button in "Edit Team" window');
        await PageHelper.click(CommonPage.ribbonItems.close);

        stepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"Edit Team" window is closed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        stepLogger.verification('"Project Center" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        stepLogger.verification('All previously created Projects are displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.record))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.inputLabels.projectName));
    });

    it('Check behavior of "Save and Close" button - [778301]', async () => {
        const stepLogger = new StepLogger(778301);
        stepLogger.stepId(1);
        stepLogger.step('Select "Navigation" icon  from left side menu');
        stepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Select check-box for any Project');
        await PageHelper.click(CommonPage.record);

        stepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        stepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        stepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        stepLogger.stepId(4);
        stepLogger.step('Check status of "Save & Close" button');

        await CommonPageHelper.switchToContentFrame(stepLogger);

        await expect(await PageHelper.isElementDisplayed(CommonPage.disabledribbonItems.saveAndClose))
            .toBe(true,
                ValidationsHelper.getButtonDisabledValidation(CommonPageConstants.ribbonLabels.saveAndClose));

        stepLogger.stepId(5);
        stepLogger.step('Select check-box for any of the resources displayed in "Resource Pool" (Right side)');
        await PageHelper.click(ProjectItemPage.teamRecords.resourcePool.first());
        const selectedResourcePoolResourceName = await ProjectItemPage.teamRecordsName.resourcePool.first().getText();

        stepLogger.step('Click on "< Add" button');
        await PageHelper.click(ProjectItemPage.teamChangeButtons.add);

        stepLogger.verification('Selected resource [Ex: Generic Resource 1] is added to "Current Team" (Left Side) grid');
        await expect(await ProjectItemPageHelper.checkResourceAddedInCurrentTeam(selectedResourcePoolResourceName))
            .toBe(true,
                ProjectItemPageValidations.getResourceAddedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        stepLogger.stepId(6);
        stepLogger.step('check status of "Save & Close" button');
        stepLogger.verification('"Save & Close" button displayed in Enabled mode after changes done in "Edit Team" window');
        await expect(await PageHelper.isElementDisplayed(CommonPage.disabledribbonItems.saveAndClose))
            .toBe(false,
                ValidationsHelper.getButtonEnabledValidation(CommonPageConstants.ribbonLabels.saveAndClose));

        stepLogger.stepId(7);
        stepLogger.step('Click on "Save & Close" button in "Edit Team" window');
        await WaitHelper.getInstance().waitForElementToBeClickable(CommonPage.ribbonItems.saveAndClose);
        await PageHelper.click(CommonPage.ribbonItems.saveAndClose);
        // After Saving Record, Security queue job takes 5-10 seconds to complete and update record.
        await WaitHelper.getInstance().staticWait(5000);

        stepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"Edit Team" window is closed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        stepLogger.verification('"Project Center" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        stepLogger.stepId(8);
        stepLogger.step('Select check-box for any Project');
        await PageHelper.click(CommonPage.record);

        stepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        stepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        stepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await CommonPageHelper.switchToContentFrame(stepLogger);

        stepLogger.verification('Selected resource [Ex: Generic Resource 1] is added to "Current Team" (Left Side) grid');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ProjectItemPage.teamRecordsName.currentTeam.last());
        await expect(await ProjectItemPageHelper.checkResourceAddedInCurrentTeam(selectedResourcePoolResourceName))
            .toBe(true,
                ProjectItemPageValidations.getResourceAddedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        stepLogger.stepId(9);
        stepLogger.step('Click "Close" button in "Edit Team" window');
        await PageHelper.click(CommonPage.ribbonItems.close);

        stepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"Edit Team" window is closed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        stepLogger.verification('"Project Center" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        stepLogger.verification('All previously created Projects are displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.record))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.inputLabels.projectName));
        return selectedResourcePoolResourceName;
    });

    it('View the Build Team-Current team members in Project Planner. - [778315]', async () => {
        const stepLogger = new StepLogger(778315);
        const uniqueId = PageHelper.getUniqueId();

        stepLogger.precondition('Execute test case C778301 and add a resource to Project [Ex: Smoke Test Project 2 /' +
            ' Generic Resource 1]');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects, CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter, stepLogger);
        await PageHelper.click(CommonPage.projectCheckbox);
        await PageHelper.click(CommonPage.ribbonTitles.items);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ribbonItems.editTeam);
        await PageHelper.click(CommonPage.ribbonItems.editTeam);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await CommonPageHelper.switchToContentFrame(stepLogger);
        await PageHelper.click(ProjectItemPage.teamRecords.resourcePool.first());
        const selectedResourcePoolResourceName = await ProjectItemPage.teamRecordsName.resourcePool.first().getText();
        await PageHelper.click(ProjectItemPage.teamChangeButtons.add);
        await WaitHelper.getInstance().waitForElementToBeClickable(CommonPage.ribbonItems.saveAndClose);
        await PageHelper.click(CommonPage.ribbonItems.saveAndClose);
        // 5 Sec wait required to let it save
        await browser.sleep(PageHelper.timeout.s);
        await PageHelper.switchToDefaultContent();

        stepLogger.stepId(1);
        stepLogger.step('Select "Navigation" icon  from left side menu');
        stepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Select check-box for any Project');
        await ElementHelper.browserRefresh();
        await browser.sleep(PageHelper.timeout.m);
        await PageHelper.click(CommonPage.projectCheckbox);

        stepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        stepLogger.step('Click ITEMS tab select Edit Plan');
        await PageHelper.click(CommonPage.editPlan);

        stepLogger.step('click on Project Planner');
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);

        stepLogger.verification('"Project Planner" window is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        stepLogger.stepId(4);
        stepLogger.step('Click on "Task" button');
        // After select project Planner wait required, not element found which can use with waitHelper.
        await browser.sleep(PageHelper.timeout.m);
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.plannerbox);
        await PageHelper.click(CommonPage.ribbonItems.addTask);

        stepLogger.step('Enter details for Task (Name, Finish Date, Hours)');
        await PageHelper.actionSendKeys( uniqueId);
        await PageHelper.click(ProjectItemPageHelper.newTasksFields.work);
        await PageHelper.actionSendKeys(CommonPageConstants.costData.firstData);
        await ElementHelper.clickUsingJs(ProjectItemPage.save);
        // After save It need static wait(5 sec) and no element found which get change after save.
        await browser.sleep(PageHelper.timeout.m);

        stepLogger.verification('A new task is created and required details entered [Ex: New Task 1]');
        await expect(ProjectItemPageHelper.newTasksFields.title.getText()).toBe(uniqueId,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.tasks));
        await expect(ProjectItemPageHelper.newTasksFields.work.getText()).toBe(CommonPageConstants.costData.firstData,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.workHours));
        await console.log(selectedResourcePoolResourceName);
        stepLogger.stepId(5);
        stepLogger.step('Click in the Assigned To column');
        await PageHelper.click(ProjectItemPage.assignToDropDown);

        stepLogger.step('Check the users displayed in the drop down');
        await expect(await PageHelper.isElementPresent(ProjectItemPage.selectAssign(1)))
            .toBe(true, ProjectItemPageValidations.getResourceAddedValidation
            (ProjectItemPageConstants.teamSectionlabels.currentTeam));

        stepLogger.verification('Newly added resource as per pre requisites [Ex: Generic Resource 1] is displayed in the' +
            ' drop down');
        await expect(await PageHelper.isElementPresent(ElementHelper.getElementByText(selectedResourcePoolResourceName)))
            .toBe(true, ProjectItemPageValidations.getResourceAddedValidation
            (ProjectItemPageConstants.teamSectionlabels.currentTeam));

        // Delete created task
        await PageHelper.click(ProjectItemPage.selectTaskName);
        await PageHelper.click(ProjectItemPage.deleteTask);
        await browser.switchTo().alert().accept();
        await ElementHelper.clickUsingJs(ProjectItemPage.save);
        // After save It need static wait(5 sec) and no element found which get change after save.
        await browser.sleep(PageHelper.timeout.s);
    });

    it('Verify functionality of "Always follow Web-Settings" check-box.. - [778281]', async () => {
        const stepLogger = new StepLogger(778281);
        stepLogger.stepId(1);
        stepLogger.step('Select "Navigation" icon  from left side menu');
        stepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Select check-box for any Project [Ex: Smoke Test Project 2]');
        await PageHelper.click(CommonPage.record);

        stepLogger.step('Click on "Items" tab');
        await PageHelper.click(CommonPage.ribbonTitles.items);

        stepLogger.step('Click on "Edit Team" icon from ribbon panel');
        await PageHelper.click(CommonPage.ribbonItems.editTeam);

        stepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(true, ValidationsHelper.getWindowShouldBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        await PageHelper.switchToFrame(CommonPage.contentFrame);

        stepLogger.verification('"Build Team" tab is selected by default');
        // If we able to access Close button under Build Team tab that means Build tab is selected
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.close))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.close));

        stepLogger.verification('"Current Team" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.currentTeam))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        stepLogger.verification('"Resource Pool" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.resourcePool))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.resourcePool));

        stepLogger.stepId(4);
        stepLogger.step('Click on the "Title" link for the user name who is logged into application from the Current Team' +
            ' grid displayed on left side');
        await PageHelper.click(ProjectItemPageHelper.getlink.adminUser);
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('User Information pop-up is displayed');
        await PageHelper.switchToFrame(CommonPage.userInfoFrame);

        stepLogger.stepId(5);
        stepLogger.step('Click on "My Language And Region" link displayed on top of "User Information" pop-up');
        await PageHelper.click(ProjectItemPageHelper.getlink.myLanguageAndRegion);
        await PageHelper.switchToNewTabIfAvailable(1);

        stepLogger.verification('New tab is opened and "Language and Region" page is displayed');
        await expect(browser.getTitle()).toBe(ProjectItemPageConstants.languageAndRegion,
            ValidationsHelper.getPageDisplayedValidation(ProjectItemPageConstants.languageAndRegion));

        stepLogger.stepId(6);
        stepLogger.step('Scroll down till the section "Region" is visible');
        await ElementHelper.scrollToElement(ProjectItemPageHelper.getlink.region);

        stepLogger.step('Un check the check box Always follow web settings displayed in Follow Web Settings row');
        await CheckboxHelper.markCheckbox(CommonPage.regionCheckBox, false);

        stepLogger.verification('Always follow web settings check box is unchecked');
        await expect(CheckboxHelper.checkboxstatus(CommonPage.regionCheckBox)).toBe(false,
            ValidationsHelper.getCheckBoxNotSelectedValidation());

        stepLogger.verification('Options in Time Zone and Region gets enabled');
        await expect(await CommonPage.timeZone.isPresent()).toBe(false,
                ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.timeZone));
    });
});
