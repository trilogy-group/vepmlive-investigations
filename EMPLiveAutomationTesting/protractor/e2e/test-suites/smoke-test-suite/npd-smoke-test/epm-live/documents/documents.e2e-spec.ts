import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {HomePageConstants} from '../../../../../page-objects/pages/homepage/home-page.constants';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {CheckboxHelper} from '../../../../../components/html/checkbox-helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    const newFile = CommonPageHelper.uniqueDocumentFilePath;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Add Documents Functionality-Project Document - [1124284]', async () => {
        const stepLogger = new StepLogger(1124284);
        stepLogger.stepId(1);
        stepLogger.step('Select Navigation icon  from left side menu');
        await PageHelper.click(HomePage.navigateMenu);

        stepLogger.step('Click on Home link');
        await PageHelper.click(HomePage.navigateToHome);

        stepLogger.verification('Logged in users Home Page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.homePageTitle);
        await expect(await CommonPage.homePageTitle.isPresent())
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.pageName));

        stepLogger.stepId(2);
        stepLogger.step('Click on + More button displayed in CREATE options in social stream');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(HomePage.toolBarMenuItems.more);
        await ElementHelper.click(HomePage.toolBarMenuItems.more);

        stepLogger.step('Click on Project Document link from the options displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(HomePage.toolBarMenuItems.projectDocument);
        await ElementHelper.click(HomePage.toolBarMenuItems.projectDocument);

        stepLogger.verification('Add a document pop up displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(HomePageConstants.addADocumentWindow.addADocumentTitle,
                ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        stepLogger.stepId(3);
        stepLogger.step('Click on Choose File button in Add a document pop up > Browse and select the file ' +
            'that need to be added as a Project document [Ex: testfile.txt]');
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        await PageHelper.uploadFile(HomePage.browseButton, newFile.fullFilePath);

        stepLogger.step('Click on OK');
        await PageHelper.click(CommonPage.formButtons.ok);

        stepLogger.verification('Add a document pop up is closed');
        await WaitHelper.getInstance().waitForElementToBeHidden(HomePage.browseButton);
        await expect(await HomePage.browseButton.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        stepLogger.verification('Add a document window to update the properties of the document is displayed');
        await expect(await CommonPage.contentUpdateFrame.isDisplayed())
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentPropertyTitle));

        stepLogger.stepId(4);
        stepLogger.step('Click Save button in Add a document window');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.formButtons.save);
        await PageHelper.click(CommonPage.formButtons.save);

        stepLogger.verification('Add a document window to update the properties of the document is closed');
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.contentUpdateFrame);
        await expect(await CommonPage.contentUpdateFrame.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentPropertyTitle));

        stepLogger.verification('Home Page is displayed');
        await expect(await CommonPage.homePageTitle.isPresent())
            .toBe(true,
                ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.pageName));

        // Notification is not visible after save.

        stepLogger.stepId(5);
        stepLogger.step('Select Navigation icon  from left side menu');
        await PageHelper.click(HomePage.navigateMenu);

        stepLogger.step('Select Projects -> Documents from the options displayed');
        await PageHelper.click(HomePage.navigation.projects.documents);

        stepLogger.verification('Project Documents page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.documentTitle);
        await expect(CommonPage.documentTitle.isDisplayed()).toBe(true,
                ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.navigationLabels.projects.documents));

        stepLogger.verification('Project node is displayed in collapsed state');
        await expect(CommonPage.projectCollapse.isDisplayed()).toBe(true,
                ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.navigationLabels.projects.projectNodeCollapsed));

        stepLogger.step('Click on the Project node to expand it');
        await PageHelper.click(CommonPage.projectCollapse);

        stepLogger.verification('Newly uploaded Project document [Ex: testfile.txt] is displayed under the expanded ' +
            'Project node');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ElementHelper.getElementByTextWithTextParameter(newFile.file));
        await expect(ElementHelper.getElementByTextWithTextParameter(newFile.file).isDisplayed())
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.file));
    });

    it('Add Project Documents Functionality-New version of existing document-[1175281]', async () => {
        const stepLogger = new StepLogger(1175281);
        stepLogger.stepId(1);
        stepLogger.step('Select Navigation icon  from left side menu');
        await PageHelper.click(HomePage.navigateMenu);

        stepLogger.step('Click on Home link');
        await PageHelper.click(HomePage.navigateToHome);

        stepLogger.verification('Logged in users Home Page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.homePageTitle);
        await expect(await CommonPage.homePageTitle.isPresent())
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.pageName));

        stepLogger.stepId(2);
        stepLogger.step('Click on + More button displayed in CREATE options in social stream');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(HomePage.toolBarMenuItems.more);
        await ElementHelper.click(HomePage.toolBarMenuItems.more);

        stepLogger.step('Click on Project Document link from the options displayed');
        await ElementHelper.click(HomePage.toolBarMenuItems.projectDocument);

        stepLogger.verification('Add a document pop up displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(HomePageConstants.addADocumentWindow.addADocumentTitle,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        stepLogger.stepId(3);
        stepLogger.step('Click on Choose File button in Add a document pop up Browse and select the same ' +
            'file already added as a Project document [Ex: testfile.txt] as per pre requisites');
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        await PageHelper.uploadFile(HomePage.browseButton, newFile.fullFilePath);

        stepLogger.step('Select Check the check box Add as a new version to existing files');
        await CheckboxHelper.markCheckbox(CommonPage.newVersionCheckbox, true);

        stepLogger.step('Version Comments: Enter some comments [Ex: New Version of previously updated file]');
        await TextboxHelper.sendKeys(CommonPage.versionCommentField, CommonPageConstants.versionComment.first);

        stepLogger.step('Click on OK');
        await PageHelper.click(CommonPage.formButtons.ok);

        stepLogger.verification('Add a document pop up is closed');
        await WaitHelper.getInstance().waitForElementToBeHidden(HomePage.browseButton);
        await expect(await HomePage.browseButton.isPresent()).toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentTitle));

        stepLogger.verification('Add a document window to update the properties of the document is displayed');
        await expect(await CommonPage.contentUpdateFrame.isDisplayed())
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentPropertyTitle));

        stepLogger.stepId(4);
        stepLogger.step('Click Save button in Add a document window');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.formButtons.save);
        await PageHelper.click(CommonPage.formButtons.save);

        stepLogger.verification('Add a document window to update the properties of the document is closed');
        await WaitHelper.getInstance().waitForElementToBeHidden(CommonPage.contentUpdateFrame);
        await expect(await CommonPage.contentUpdateFrame.isPresent()).toBe(false,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(HomePageConstants.addADocumentWindow.addADocumentPropertyTitle));

        stepLogger.verification('Home Page is displayed');
        await expect(await CommonPage.homePageTitle.isPresent())
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.pageName));

        // Notification is not visible after save.

        stepLogger.stepId(5);
        stepLogger.step('Select Navigation icon  from left side menu');
        await PageHelper.click(HomePage.navigateMenu);

        stepLogger.step('Select Projects -> Documents from the options displayed');
        await PageHelper.click(HomePage.navigation.projects.documents);

        stepLogger.verification('Project Documents page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.documentTitle);
        await expect(CommonPage.documentTitle.isDisplayed())
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.navigationLabels.projects.documents));

        stepLogger.verification('Project node is displayed in collapsed state');
        await expect(CommonPage.projectCollapse.isDisplayed()).toBe(true,
            ValidationsHelper.getMenuDisplayedValidation(HomePageConstants.navigationLabels.projects.projectNodeCollapsed));

        stepLogger.step('Click on the Project node to expand it');
        await PageHelper.click(CommonPage.projectCollapse);

        stepLogger.verification('Newly uploaded Project document [Ex: testfile.txt] is displayed under the expanded ' +
            'Project node');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(ElementHelper.getElementByTextWithTextParameter(newFile.file));
        await expect(ElementHelper.getElementByTextWithTextParameter(newFile.file).isDisplayed())
            .toBe(true, ValidationsHelper.getDisplayedValidation(newFile.file));

        await WaitHelper.getInstance().waitForElementToBeDisplayed(ElementHelper.getElementByTextWithTextParameter(newFile.file));
        await expect(CommonPage.fileVersion(newFile.file).getText())
            .toBe(CommonPageConstants.versionComment.second, ValidationsHelper.getDisplayedValidation
            (CommonPageConstants.versionComment.second));

    });
});
