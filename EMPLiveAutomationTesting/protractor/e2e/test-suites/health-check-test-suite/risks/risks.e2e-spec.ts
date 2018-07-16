import {PageHelper} from '../../../components/html/page-helper';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../core/logger/step-logger';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {RiskItemPageConstants} from '../../../page-objects/pages/items-page/risk-item/risk-item-page.constants';
import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';
import {CreateNewPageConstants} from '../../../page-objects/pages/items-page/create-new-page.constants';
import {RiskItemPage} from '../../../page-objects/pages/items-page/risk-item/risk-item.po';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';
import {WaitHelper} from '../../../components/html/wait-helper';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {CreateNewPage} from '../../../page-objects/pages/items-page/create-new.po';
import {AnchorHelper} from '../../../components/html/anchor-helper';
import {TextboxHelper} from '../../../components/html/textbox-helper';
import {RiskItemPageHelper} from '../../../page-objects/pages/items-page/risk-item/risk-item-page.helper';
import {ProjectItemPageConstants} from '../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {ProjectItemPage} from '../../../page-objects/pages/items-page/project-item/project-item.po';

describe(SuiteNames.healthCheckTestSuite, () => {
    let homePage: HomePage;
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });
    it('Add, Edit and Delete Risk- [829719]', async () => {
        const stepLogger = new StepLogger(829719);
        stepLogger.stepId(1);
        stepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);
        stepLogger.step('Various Create New options are displayed');
        await expect(await PageHelper.isElementDisplayed(CreateNewPage.navigation.listApps.risk))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(CreateNewPageConstants.navigationLabels.listApps.risk));
        stepLogger.stepId(2);
        stepLogger.step('Click on "Risk" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.risk);
        stepLogger.verification('"Risks - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(RiskItemPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(RiskItemPageConstants.pageName));

        stepLogger.stepId(3);
        stepLogger.step('Enter/Select required details in "Risks - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = RiskItemPageConstants.inputLabels;
        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();
        stepLogger.step('Title *: Random New Risk Item');
        let titleValue = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(RiskItemPage.inputs.title, titleValue);
        stepLogger.verification('Required values entered/selected in title Field');
        await expect(await TextboxHelper.hasValue(RiskItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, titleValue));
        stepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');
        await PageHelper.click(CommonPage.projectShowAllButton);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(RiskItemPage.inputs.project);
        const projectName = await RiskItemPage.inputs.project.getText();
        await PageHelper.click(RiskItemPage.inputs.project);
        stepLogger.verification('Required values entered/selected in Project Field');
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(projectName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.project, projectName));
        stepLogger.stepId(4);
        stepLogger.step('Click on "Save" button in "Risks - New Item" window');
        await PageHelper.click(CommonPage.formButtons.save);
        stepLogger.verification('"Risks - New Item" window is closed');
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(RiskItemPageConstants.pageName));
        await PageHelper.switchToDefaultContent();
        stepLogger
            .verification('Notification about New Risks created [Ex: New Risk Item 1] displayed on the Home Page');
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getNotificationByText(titleValue)))
            .toBe(true,
                ValidationsHelper.getNotificationDisplayedValidation(RiskItemPageConstants.pageName));
        stepLogger.stepId(5);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
            stepLogger);
        stepLogger.step('Project *:Search Project ');
        await CommonPageHelper.searchItemByTitle(titleValue,
            RiskItemPageConstants.columnNames.title,
            stepLogger);
        stepLogger.verification('Newly created Risk [Ex: New Risk Item 1] displayed in "Risks" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(titleValue));
        stepLogger.verification('Make some changes and click on \'Save\' button');
        await CommonPageHelper.editOptionViaRibbon(stepLogger);
        titleValue = titleValue + 'Edited';
        await TextboxHelper.sendKeys(RiskItemPage.inputs.title, titleValue);
        stepLogger.step('Click on "Save" button in "Risks - New Item" window');
        await PageHelper.click(CommonPage.formButtons.save);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
            stepLogger);
        await CommonPageHelper.searchItemByTitle(titleValue,
            RiskItemPageConstants.columnNames.title,
            stepLogger);
        stepLogger.step('Select a Risk and Click on "ITEMS" >> Delete Item');
        await RiskItemPageHelper.deleteOptionViaRibbon(stepLogger);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.risks,
            CommonPage.pageHeaders.projects.risks,
            CommonPageConstants.pageHeaders.projects.risks,
            stepLogger);
        await CommonPageHelper.searchItemByTitle(titleValue,
            RiskItemPageConstants.columnNames.title,
            stepLogger);
        stepLogger.step('Validating deleted Risk  is not  Present');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.noProjecrMsg))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.noDataFound));
    });
});
