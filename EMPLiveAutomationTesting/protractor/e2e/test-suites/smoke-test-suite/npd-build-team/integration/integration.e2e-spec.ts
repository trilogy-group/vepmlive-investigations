import {SuiteNames} from '../../../helpers/suite-names';
import {HomePage} from '../../../../page-objects/pages/homepage/home.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {ProjectItemPage} from '../../../../page-objects/pages/items-page/project-item/project-item.po';
import {ProjectItemPageConstants} from '../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {ProjectItemPageHelper} from '../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {ElementHelper} from '../../../../components/html/element-helper';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {ProjectItemPageValidations} from '../../../../page-objects/pages/items-page/project-item/project-item-page.validations';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('View the Build Team-Current team members in Project Planner - [743198]', async () => {
        const stepLogger = new StepLogger(743198);
        const uniqueId = PageHelper.getUniqueId();
        stepLogger.stepId(1);
        stepLogger.step('Select "Navigation" icon  from left side menu');
        stepLogger.step('Select Projects -> Projects from the options displayed');
        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

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

        stepLogger.step('Select check-box for any of the resources displayed in "Resource Pool" (Right side)');
        await PageHelper.click(ProjectItemPage.teamRecords.resourcePool.first());
        const selectedResourcePoolResourceName = await ProjectItemPage.teamRecordsName.resourcePool.first().getText();

        stepLogger.step('Click on "< Add" button');
        await PageHelper.click(ProjectItemPage.teamChangeButtons.add);

        stepLogger.verification('Selected resource [Ex: Generic Resource 1] is added to "Current Team" (Left Side) grid');
        await expect(await ProjectItemPageHelper.checkResourceAddedInCurrentTeam(selectedResourcePoolResourceName))
            .toBe(true,
                ProjectItemPageValidations.getResourceAddedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        stepLogger.stepId(2);
        stepLogger.step('Click on "Save & Close" button in "Edit Team" window');
        await WaitHelper.getInstance().waitForElementToBeClickable(CommonPage.ribbonItems.saveAndClose);
        await PageHelper.click(CommonPage.ribbonItems.saveAndClose);

        stepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        stepLogger.stepId(3);
        stepLogger.step('Navigate to Project Center');
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(4);
        stepLogger.step('Mouse hover on any Project created as per pre requisites');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.record);
        await ElementHelper.actionHoverOver(CommonPage.record);

        stepLogger.step('Click on the Ellipses button (...)');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.ellipse);
        await PageHelper.click(CommonPage.ellipse);

        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.contextMenuOptions.editPlan);
        stepLogger.step('select "Edit Plan" from the options displayed');
        await PageHelper.click(CommonPage.contextMenuOptions.editPlan);

        stepLogger.stepId(5);
        stepLogger.step('click on Project Planner');

        // If user has default planner selected then then selectPlanner PopUp won't appear
        await ProjectItemPageHelper.selectPlannerIfPopUpAppears(ProjectItemPage.selectPlanner.projectPlanner);

        stepLogger.verification('Observe that the "Project Planner" is displayed');
        stepLogger.verification('"Project Planner" window is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectPlanner))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectPlanner));

        stepLogger.stepId(6);
        stepLogger.step('Enter New Task in the "Add a Task"');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ProjectItemPage.newTask);
        await TextboxHelper.sendKeys(ProjectItemPage.newTask, uniqueId, true);

        stepLogger.step('click on "Edit Team" button');
        await WaitHelper.getInstance().waitForElementToBeClickable(CommonPage.ribbonItems.editTeamProjectPlanner);
        await PageHelper.click(CommonPage.ribbonItems.editTeamProjectPlanner);

        stepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await CommonPageHelper.switchToContentFrame(stepLogger);

        stepLogger.verification('Observe that the newly added "Resource" is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ProjectItemPage.teamRecords.currentTeam.first());
        await expect(await ProjectItemPageHelper.checkResourceAddedInCurrentTeam(selectedResourcePoolResourceName))
            .toBe(true,
                ProjectItemPageValidations.getResourceAddedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));
    });
});
