import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {ElementHelper} from '../../../../../components/html/element-helper';
import { WorkspacesConstants } from '../../../../../page-objects/pages/workspaces/workspaces.constants';
import { workspacesPage } from '../../../../../page-objects/pages/workspaces/workspaces.po';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('To Verify User is able to view notification after Creating Workspace Using a Project Template - [1175091]', async () => {
        const stepLogger = new StepLogger(1175091);

        stepLogger.stepId(1);
        stepLogger.step('Click on Workspaces icon from the left navigation panel');
        await PageHelper.click(CommonPage.sidebarMenus.workspaces);

        stepLogger.stepId(2);
        stepLogger.step(`Click on the 'New Workspace' button`);
        await ElementHelper.click(workspacesPage.newWSButton);

        stepLogger.step('Waiting for page to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        stepLogger.verification(`'Create Workspace' pop-up displayed with the following details`);
        await expect(await CommonPage.dialogTitle.getText())
            .toBe(WorkspacesConstants.windowTitle,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(WorkspacesConstants.windowTitle));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(3);
        stepLogger.step(`Select/Enter below details in 'Create Workspace' pop-up`);
        stepLogger.step(`Enter a Title for work space`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = WorkspacesConstants.inputLabels;
        const title = `${labels.title} ${uniqueId}`;
        await TextboxHelper.sendKeys(workspacesPage.titleInputField, title);

        stepLogger.step(`Enter a Description for work space`); 
        const description = `${labels.description} ${uniqueId}`; 
        await TextboxHelper.sendKeys(workspacesPage.descInputField, description); 
        
        stepLogger.step(`Select the radio button 'Open - Accessible and open to anyone who has permission to the parent site'`);       
        await ElementHelper.click(workspacesPage.openPermission);

        await WaitHelper.getInstance().waitForElementToBeDisplayed(workspacesPage.projectTemplate);
        stepLogger.step(`Select 'Project' as the 'Online' template`);
        await ElementHelper.click(workspacesPage.projectTemplate);

        stepLogger.stepId(4);
        stepLogger.step(`Click 'Create Workspace' button in 'Create Workspace' pop-up`);
        await ElementHelper.click(workspacesPage.createWSButton);
       
        stepLogger.verification(`'Create Workspace' pop-up is closed`);
        await expect(await CommonPage.dialogTitle.isPresent())
        .toBe(false, ValidationsHelper.getWindowShouldNotBeDisplayedValidation(WorkspacesConstants.windowTitle));
              
        await PageHelper.switchToDefaultContent();

        stepLogger.verification(`Blue notification displayed briefly on the right top corner stating 'Your workspace is being created - we will notify you once it is ready'`);
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getElementUsingText(WorkspacesConstants.notification, true)))
        .toBe(true, ValidationsHelper.getNotificationDisplayedValidation(WorkspacesConstants.notification));

    });

});
