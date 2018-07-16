import {PageHelper} from '../../../components/html/page-helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';
import {HomePage} from '../../../page-objects/pages/homepage/home.po';
import {CreateNewPageConstants} from '../../../page-objects/pages/items-page/create-new-page.constants';
import {ChangeItemPageHelper} from '../../../page-objects/pages/items-page/change-item/change-item-page.helper';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {CreateNewPage} from '../../../page-objects/pages/items-page/create-new.po';
import {AnchorHelper} from '../../../components/html/anchor-helper';
import {ChangeItemPageConstants} from '../../../page-objects/pages/items-page/change-item/change-item-page.constants';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';
import {WaitHelper} from '../../../components/html/wait-helper';
import {RiskItemPageHelper} from '../../../page-objects/pages/items-page/risk-item/risk-item-page.helper';
import {ChangeItemPage} from '../../../page-objects/pages/items-page/change-item/change-item.po';
import {TextboxHelper} from '../../../components/html/textbox-helper';
import {ProjectItemPage} from '../../../page-objects/pages/items-page/project-item/project-item.po';
import {ProjectItemPageConstants} from '../../../page-objects/pages/items-page/project-item/project-item-page.constants';

describe(SuiteNames.healthCheckTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Add, Edit and Delete Change - [829742]', async () => {
        const stepLogger = new StepLogger(829742);
        stepLogger.stepId(1);
        stepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);
        stepLogger.step('Various Create New options are displayed');
        await expect(await PageHelper.isElementDisplayed(CreateNewPage.navigation.listApps.change))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(CreateNewPageConstants.navigationLabels.listApps.change));
        stepLogger.stepId(2);
        stepLogger.step('Click on "Change" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.change);
        stepLogger.verification('"Changes - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(ChangeItemPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(ChangeItemPageConstants.pageName));
        stepLogger.stepId(3);
        stepLogger.step('Enter/Select required details in "Changes - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = ChangeItemPageConstants.inputLabels;
        let titleValue = `${labels.title} ${uniqueId}`;
        const priority = CommonPageConstants.priorities.high;
        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();
        await ChangeItemPageHelper.fillForm(titleValue, priority, stepLogger);
        stepLogger.verification('"Changes - New Item" window is closed');
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ChangeItemPageConstants.pageName));
        await PageHelper.switchToDefaultContent();
        stepLogger
            .verification('Notification about New Changes created [Ex: New Change Item 1]' +
                ' displayed on the Home Page');
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getNotificationByText(titleValue)))
            .toBe(true,
                ValidationsHelper.getNotificationDisplayedValidation(ChangeItemPageConstants.pageName));
        stepLogger.stepId(5);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.changes,
            CommonPage.pageHeaders.projects.changes,
            CommonPageConstants.pageHeaders.projects.changes,
            stepLogger);
        await CommonPageHelper.searchItemByTitle(titleValue,
            ChangeItemPageConstants.columnNames.linkTitleNoMenu,
            stepLogger);
        stepLogger.verification('Newly created Change [Ex: New Change Item 1] displayed in "Changes" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(titleValue));
        await CommonPageHelper.editOptionViaRibbon(stepLogger);
        titleValue = titleValue + 'Edited';
        await TextboxHelper.sendKeys(ChangeItemPage.inputs.title, titleValue);
        await PageHelper.click(CommonPage.formButtons.save);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.changes,
            CommonPage.pageHeaders.projects.changes,
            CommonPageConstants.pageHeaders.projects.changes,
            stepLogger);
        await CommonPageHelper.searchItemByTitle(titleValue,
            ChangeItemPageConstants.columnNames.linkTitleNoMenu,
            stepLogger);
        stepLogger.verification('Newly created Change [Ex: New Change Item 1] displayed in "Changes" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(titleValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(titleValue));
        await RiskItemPageHelper.deleteOptionViaRibbon(stepLogger);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.changes,
            CommonPage.pageHeaders.projects.changes,
            CommonPageConstants.pageHeaders.projects.changes,
            stepLogger);
        await CommonPageHelper.searchItemByTitle(titleValue,
            ChangeItemPageConstants.columnNames.linkTitleNoMenu,
            stepLogger);
        stepLogger.step('Validating deleted Risk  is not  Present');
        await expect(await PageHelper.isElementDisplayed(ProjectItemPage.noProjecrMsg))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(ProjectItemPageConstants.noDataFound));
    });
});
