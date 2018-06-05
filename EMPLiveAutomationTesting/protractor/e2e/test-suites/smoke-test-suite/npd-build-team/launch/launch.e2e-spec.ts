import {StepLogger} from '../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../components/html/page-helper';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../../page-objects/pages/homepage/home.po';
import {SuiteNames} from '../../../helpers/suite-names';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {ProjectItemPageConstants} from '../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {ProjectItemPage} from '../../../../page-objects/pages/items-page/project-item/project-item.po';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {ProjectItemPageHelper} from '../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {ElementHelper} from '../../../../components/html/element-helper';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Launch Build Team from Project Center - [743139]', async () => {
        const stepLogger = new StepLogger(743139);
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

        stepLogger.step('Switch to content frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        // If we able to access Close button under Build Team tab that means Build tab is selected
        stepLogger.verification('"Build Team" tab is selected by default');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.close))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.close));

        stepLogger.verification('"Current Team" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.currentTeam))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

        stepLogger.verification('"Resource Pool" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.resourcePool))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.resourcePool));

        stepLogger.stepId(4);
        stepLogger.step('Click "Close" button in "Edit Team" window');
        await PageHelper.click(CommonPage.ribbonItems.close);

        stepLogger.step('switch to default content');
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"Edit Team" window is closed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitle))
            .toBe(false, ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        stepLogger.verification('"Project Center" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.projects.projectsCenter))
            .toBe(true, ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectCenter));

        stepLogger.verification('All previously created Projects are displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.record))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.inputLabels.projectName));
    });

    it('Launch Build Team from Project Center - Ellipsis icon - [743140]', async () => {
        const stepLogger = new StepLogger(743139);
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
        stepLogger.step('Mouse over on any Project created as per pre requisites');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.record);
        await ElementHelper.actionHoverOver(CommonPage.record);

        stepLogger.step('Click on the Ellipses button (...)');
        await PageHelper.click(CommonPage.ellipse);
        stepLogger.step('select "Edit Team" from the options displayed');
        await PageHelper.click(CommonPage.contextMenuOptions.editTeam);

        stepLogger.verification('"Edit Team" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
        .toBe(CommonPageConstants.ribbonLabels.editTeam,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.ribbonLabels.editTeam));

        stepLogger.step('Switch to content frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        // If we able to access Close button under Build Team tab that means Build tab is selected
        stepLogger.verification('"Build Team" tab is selected by default');
        await expect(await PageHelper.isElementDisplayed(CommonPage.ribbonItems.close))
            .toBe(true,
                    ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.ribbonLabels.close));

        stepLogger.verification('"Current Team" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.currentTeam));

        stepLogger.verification('"Resource Pool" Section is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.resourcePool))
            .toBe(true,
                    ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.resourcePool));

        stepLogger.stepId(4);
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

    it('Navigate to Edit Costs page - [966345]', async () => {
        const stepLogger = new StepLogger(966345);
        const uniqueId = PageHelper.getUniqueId();
        const toolButtons = ProjectItemPage.toolButtons;
        const periodButtons = ProjectItemPage.periodButtons;

        stepLogger.step('Create a new project and navigate to Item page');
        await ProjectItemPageHelper.createProject(uniqueId, stepLogger);

        stepLogger.verification('Verify Resource Pool is displayed');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.itemOptions.editCourse))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.itemOptions.editCourse));

        stepLogger.stepId(1);
        stepLogger.step('Click on Edit Costs icon from the button menu');
        await PageHelper.click(ProjectItemPage.itemOptions.editCourse);

        stepLogger.stepId(2);
        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToContentFrame(stepLogger);

        stepLogger.verification('Check options displayed in Cost Planner window in Plan Actions - Close button');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.planActionButtons.close))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.planActionButtons.close));

        stepLogger.verification('Check options displayed in Cost Planner window in Plan Actions - Save button');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.planActionButtons.save))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(ProjectItemPageConstants.planActionButtons.save));

        stepLogger.verification('Check options displayed in Cost Planner window in Tools - categories button');
        await expect(await PageHelper.isElementDisplayed(toolButtons.categories))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.toolButtons.categories));

        stepLogger.verification('Check options displayed in Cost Planner window in Tools - delete button');
        await expect(await PageHelper.isElementDisplayed(toolButtons.delete))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.toolButtons.delete));

        stepLogger.verification('Check options displayed in Cost Planner window in Tools - details button');
        await expect(await PageHelper.isElementDisplayed(toolButtons.detail))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.toolButtons.detail));

        stepLogger.verification('Check options displayed in Cost Planner window in Tools - show reference button');
        await expect(await PageHelper.isElementDisplayed(toolButtons.showReference))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.toolButtons.showReference));

        stepLogger.verification('Check options displayed in Cost Planner window in Periods - from period button');
        await expect(await PageHelper.isElementDisplayed(periodButtons.fromPeriod))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.periodfields.fromPeriod));

        stepLogger.verification('Check options displayed in Cost Planner window in Periods - to period button');
        await expect(await PageHelper.isElementDisplayed(periodButtons.toPeriod))
            .toBe(true, ValidationsHelper.getDisplayedValidation(ProjectItemPageConstants.periodfields.toPeriod));
    });
});
