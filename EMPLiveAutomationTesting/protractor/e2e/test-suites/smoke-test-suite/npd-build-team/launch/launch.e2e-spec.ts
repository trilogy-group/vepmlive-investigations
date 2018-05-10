import { StepLogger } from '../../../../../core/logger/step-logger';
import { PageHelper } from '../../../../components/html/page-helper';
import { CommonPageHelper } from '../../../../page-objects/pages/common/common-page.helper';
import { HomePage } from '../../../../page-objects/pages/homepage/home.po';
import { SuiteNames } from '../../../helpers/suite-names';
import { CommonPage } from '../../../../page-objects/pages/common/common.po';
import { CommonPageConstants } from '../../../../page-objects/pages/common/common-page.constants';
import { WaitHelper } from '../../../../components/html/wait-helper';
import { ProjectItemPageConstants } from '../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import { ValidationsHelper } from '../../../../components/misc-utils/validation-helper';
import { ProjectItemPage } from '../../../../page-objects/pages/items-page/project-item/project-item.po';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
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
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitles.first());

        await expect(await CommonPage.dialogTitles.first().getText())
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
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.teamSection.currentTeam))
            .toBe(true,
                ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.teamSectionlabels.currentTeam));

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
        await expect(await PageHelper.isElementDisplayed(CommonPage.dialogTitles.first()))
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
