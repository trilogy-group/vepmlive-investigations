// tslint:disable-next-line:max-line-length
import {IssueNewItemPageConstants} from '../../../../../page-objects/pages/create-new-page/new-item/issue-new-item/issue-new-item-page.constants';
// tslint:disable-next-line:max-line-length
import {CommonNewItemPageHelper} from '../../../../../page-objects/pages/create-new-page/new-item/common-new-item/common-new-item-page.helper';
import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CreateNewPage} from '../../../../../page-objects/pages/create-new-page/create-new.po';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {CreateNewPageConstants} from '../../../../../page-objects/pages/create-new-page/create-new-page.constants';
import {CommonNewItemPage} from '../../../../../page-objects/pages/create-new-page/new-item/common-new-item/common-new-item.po';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {IssueNewItemPage} from '../../../../../page-objects/pages/create-new-page/new-item/issue-new-item/issue-new-item.po';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonViewPage} from '../../../../../page-objects/pages/homepage/common-view-page/common-view.po';
import {CommonViewPageConstants} from '../../../../../page-objects/pages/homepage/common-view-page/common-view-page.constants';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {browser} from 'protractor';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
    });

    it('Add Issues Functionality - [1124274]', async () => {
        const stepLogger = new StepLogger(1124274);

        stepLogger.stepId(1);

        stepLogger.step('Select "Create New" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.createNew);

        stepLogger.step('Various Create New options are displayed');
        await expect(await PageHelper.isElementDisplayed(CreateNewPage.navigation.listApps.issue))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(CreateNewPageConstants.navigationLabels.listApps.issue));

        stepLogger.stepId(2);
        stepLogger.step('Click on "Issue" link from the options displayed');
        await PageHelper.click(CreateNewPage.navigation.listApps.issue);

        stepLogger.verification('"Issues - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonNewItemPage.titles.first());
        await expect(await CommonNewItemPage.titles.first().getText())
            .toBe(IssueNewItemPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(IssueNewItemPageConstants.pageName));

        stepLogger.stepId(3);
        stepLogger.step('Enter/Select required details in "Issues - New Item" window as described below');
        const uniqueId = PageHelper.getUniqueId();
        const labels = IssueNewItemPageConstants.inputLabels;

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();
        stepLogger.step('Title *: Random New Issue Item');
        const titleValue = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(IssueNewItemPage.inputs.title, titleValue);

        stepLogger.verification('Required values entered/selected in title Field');
        await expect(await TextboxHelper.hasValue(IssueNewItemPage.inputs.title, titleValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldValueValidation(labels.title, titleValue));

        stepLogger.step('Project *: Select any project from the drop down [Ex: PM User Project 1])');

        await PageHelper.click(IssueNewItemPage.projectShowAllButton);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(IssueNewItemPage.inputs.project);
        const projectName = await IssueNewItemPage.inputs.project.getText();
        await PageHelper.click(IssueNewItemPage.inputs.project);

        stepLogger.verification('Required values entered/selected in Project Field');
        await expect(await CommonPageHelper.getAutoCompleteItemByDescription(projectName).isPresent())
            .toBe(true,
                ValidationsHelper.getFieldShouldValueValidation(labels.project, projectName));

        stepLogger.stepId(4);
        stepLogger.step('Click on "Save" button in "Issues - New Item" window');
        await PageHelper.click(CommonNewItemPage.formButtons.save);

        stepLogger.verification('"Issues - New Item" window is closed');
        await expect(await CommonNewItemPage.title.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(IssueNewItemPageConstants.pageName));

        await PageHelper.switchToDefaultContent();
        stepLogger
            .verification('Notification about New Issues created [Ex: New Issue Item 1] displayed on the Home Page');

        await expect(await PageHelper.isElementDisplayed(CommonNewItemPageHelper.getNotificationByText(titleValue)))
            .toBe(true,
                ValidationsHelper.getNotificationDisplayedValidation(IssueNewItemPageConstants.pageName));

        stepLogger.stepId(5);
        stepLogger.step('Select "Navigation" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.navigation);

        stepLogger.step('Select Project -> Issues from the left side menu options displayed');
        await PageHelper.click(HomePage.navigation.projects.issues);

        stepLogger.verification('"Issues" page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonViewPage.pageHeaders.projects.issues))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonViewPageConstants.pageHeaders.projects.issues));

        // Give it sometime to create, Created Issue is not reflecting immediately
        await browser.sleep(PageHelper.timeout.s);

        stepLogger.step('Click on search');
        await PageHelper.click(CommonViewPage.actionMenuIcons.search);

        stepLogger.step('Select column name as Title');
        await PageHelper.sendKeysToInputField(CommonViewPage.searchControls.column, CommonViewPage.columnNames.title);

        stepLogger.step('Enter search term');
        await TextboxHelper.sendKeys(CommonViewPage.searchControls.text, titleValue, true);

        stepLogger.verification('Newly created Issue [Ex: New Issue Item 1] displayed in "Issues" page');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByExactTextXPath(titleValue)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(titleValue));
    });
});
