import {PageHelper} from './../../../../../components/html/page-helper';
import {ProjectItemPageConstants} from './../../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {ProjectItemPage} from './../../../../../page-objects/pages/items-page/project-item/project-item.po';
import {ValidationsHelper} from './../../../../../components/misc-utils/validation-helper';
import {CommonPageConstants} from './../../../../../page-objects/pages/common/common-page.constants';
import {CommonPage} from './../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from './../../../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../../../helpers/suite-names';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {ProjectItemPageHelper} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {ProjectItemPageValidations} from '../../../../../page-objects/pages/items-page/project-item/project-item-page.validations';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';

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
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
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
    });
});
