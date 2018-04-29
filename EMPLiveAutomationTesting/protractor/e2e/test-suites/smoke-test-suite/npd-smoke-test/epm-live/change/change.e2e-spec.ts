import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonViewPage} from '../../../../../page-objects/pages/homepage/common-view-page/common-view.po';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {CommonViewPageHelper} from '../../../../../page-objects/pages/homepage/common-view-page/common-view-page.helper';
import {CommonViewPageConstants} from '../../../../../page-objects/pages/homepage/common-view-page/common-view-page.constants';
import {CreateNewPage} from '../../../../../page-objects/pages/items-page/create-new.po';
import {CreateNewPageConstants} from '../../../../../page-objects/pages/items-page/create-new-page.constants';
import {CommonItemPage} from '../../../../../page-objects/pages/items-page/common-item/common-item.po';
import {ChangeItemPageConstants} from '../../../../../page-objects/pages/items-page/change-item/change-item-page.constants';
import {ChangeItemPage} from '../../../../../page-objects/pages/items-page/change-item/change-item.po';
import {CommonItemPageHelper} from '../../../../../page-objects/pages/items-page/common-item/common-item-page.helper';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
    });

    xit('Add Changes Functionality - [1124277]', async () => {
        const stepLogger = new StepLogger(1124277);

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
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonItemPage.dialogTitles.first());

        await expect(await CommonItemPage.dialogTitles.first().getText())
            .toBe(ChangeItemPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(ChangeItemPageConstants.pageName));

        stepLogger.stepId(3);
        stepLogger.step('Enter/Select required details in "Changes - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = ChangeItemPageConstants.inputLabels;

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();
        stepLogger.step('Title *: Random New Change Item');
        const titleValue = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(ChangeItemPage.inputs.title, titleValue);

        stepLogger.verification('Required values entered/selected in title Field');
        await expect(await TextboxHelper.hasValue(ChangeItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, titleValue));

        stepLogger.step('Click on projectShowAllButton');
        await PageHelper.click(ChangeItemPage.projectShowAllButton);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ChangeItemPage.inputs.project);
        stepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');
        const projectName = await ChangeItemPage.inputs.project.getText();
        await PageHelper.click(ChangeItemPage.inputs.project);

        stepLogger.verification('Required values entered/selected in Project Field');
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(projectName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.project, projectName));

        stepLogger.stepId(4);
        stepLogger.step('Click on "Save" button in "Changes - New Item" window');
        await PageHelper.click(CommonItemPage.formButtons.save);

        stepLogger.verification('"Changes - New Item" window is closed');
        await expect(await CommonItemPage.dialogTitles.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ChangeItemPageConstants.pageName));

        await PageHelper.switchToDefaultContent();
        stepLogger
            .verification('Notification about New Changes created [Ex: New Change Item 1]' +
                ' displayed on the Home Page');

        await expect(await PageHelper.isElementDisplayed(CommonItemPageHelper.getNotificationByText(titleValue)))
            .toBe(true,
                ValidationsHelper.getNotificationDisplayedValidation(ChangeItemPageConstants.pageName));

        stepLogger.stepId(5);
        await CommonViewPageHelper.navigateToItemPage(
            HomePage.navigation.projects.changes,
            CommonViewPage.pageHeaders.projects.changes,
            CommonViewPageConstants.pageHeaders.projects.changes,
            stepLogger);

        await CommonViewPageHelper.searchItemByTitle(titleValue, ChangeItemPageConstants.columnNames.linkTitleNoMenu, stepLogger);

        stepLogger.verification('Newly created Change [Ex: New Change Item 1] displayed in "Changes" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByExactTextXPath(titleValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(titleValue));
    });

});
