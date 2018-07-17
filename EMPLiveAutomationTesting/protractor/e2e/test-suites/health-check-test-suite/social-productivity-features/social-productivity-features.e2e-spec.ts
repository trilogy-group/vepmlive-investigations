import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {ElementHelper} from '../../../components/html/element-helper';
import {WaitHelper} from '../../../components/html/wait-helper';
import {PageHelper} from '../../../components/html/page-helper';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';
import {ProjectItemPageHelper} from '../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {ProjectItemPageConstants} from '../../../page-objects/pages/items-page/project-item/project-item-page.constants';

describe(SuiteNames.healthCheckTestSuite, () => {
    let homePage: HomePage;
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });
    it('Add an item from Social Stream - [829790]', async () => {
        const stepLogger = new StepLogger(829790);
        // // Step #1 and #2 and #3 Inside this function
        await WaitHelper.getInstance().waitForElementToBeDisplayed(HomePage.whatAreYouWorkingOnTextBox);
        stepLogger.step('Click on "Project" Link on the top menu bar');
        await ElementHelper.click(HomePage.toolBarMenuItems.project);
        stepLogger.verification('Verify Project Center - New Item window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(ProjectItemPageConstants.pageName,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ProjectItemPageConstants.pageName));
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        stepLogger.step('Enter/Select required details in "Project Center - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = ProjectItemPageConstants.inputLabels;
        const projectNameValue = `${labels.projectName} ${uniqueId}`;
        const projectDescription = `${labels.projectDescription} ${uniqueId}`;
        const benefits = `${labels.benefits} ${uniqueId}`;
        const overallHealthOnTrack = CommonPageConstants.overallHealth.onTrack;
        const projectUpdateManual = CommonPageConstants.projectUpdate.manual;
        await ProjectItemPageHelper.fillForm(
            projectNameValue,
            projectDescription,
            benefits,
            overallHealthOnTrack,
            projectUpdateManual,
            stepLogger);
        await PageHelper.switchToDefaultContent();
        stepLogger.verification('Newly created Project displayed in "Project" page');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(projectNameValue)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(projectNameValue));
    });

});
