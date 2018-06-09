import { ElementHelper } from '../../../components/html/element-helper';
import {WorkSpacesPage} from './workspaces.po';
import { WaitHelper } from '../../../components/html/wait-helper';
import { WorkspacesConstants } from './workspaces.constants';
import { CommonPageHelper } from '../common/common-page.helper';
import { StepLogger } from '../../../../core/logger/step-logger';
import { PageHelper } from '../../../components/html/page-helper';
import { CommonPage } from '../common/common.po';
import { ValidationsHelper } from '../../../components/misc-utils/validation-helper';
import { TextboxHelper } from '../../../components/html/textbox-helper';

export class WorkspacePageHelper {

static async createWorkspace(stepLogger: StepLogger) {
    stepLogger.stepId(1);
    stepLogger.step('Click on Workspaces icon from the left navigation panel');
    await PageHelper.click(CommonPage.sidebarMenus.workspaces);
    stepLogger.stepId(2);
    stepLogger.step(`Click on the 'New Workspace' button`);
    await ElementHelper.click(WorkSpacesPage.newWorkSpaceButton);
    stepLogger.step('Waiting for page to open');
    await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);
    stepLogger.verification(`'Create Workspace' pop-up displayed with the following details`);
    await expect(await CommonPage.dialogTitle.getText())
        .toBe(WorkspacesConstants.windowTitle, ValidationsHelper.getWindowShouldNotBeDisplayedValidation(WorkspacesConstants.windowTitle));
    stepLogger.step('Switch to frame');
    await CommonPageHelper.switchToFirstContentFrame();
    stepLogger.stepId(3);
    stepLogger.step(`Select/Enter below details in 'Create Workspace' pop-up`);
    stepLogger.step(`Enter a Title for work space`);
    const uniqueId = PageHelper.getUniqueId();
    const labels = WorkspacesConstants.inputLabels;
    const title = `${labels.title} ${uniqueId}`;
    await TextboxHelper.sendKeys(WorkSpacesPage.titleInputField, title);
    stepLogger.step(`Enter a Description for work space`);
    const description = `${labels.description} ${uniqueId}`;
    await TextboxHelper.sendKeys(WorkSpacesPage.descInputField, description);
    stepLogger.step(`Select the radio button 'Open - Accessible and open to anyone who has permission to the parent site'`);
    await ElementHelper.click(WorkSpacesPage.openPermission);
    await WaitHelper.getInstance().waitForElementToBeDisplayed(WorkSpacesPage.projectTemplate);
    stepLogger.step(`Select 'Project' as the 'Online' template`);
    await ElementHelper.click(WorkSpacesPage.projectTemplate);
    stepLogger.stepId(4);
    stepLogger.step(`Click 'Create Workspace' button in 'Create Workspace' pop-up`);
    await ElementHelper.click(WorkSpacesPage.createWorkSpaceButton);
    stepLogger.verification(`'Create Workspace' pop-up is closed`);
    await expect(await CommonPage.dialogTitle.isPresent())
        .toBe(false, ValidationsHelper.getWindowShouldNotBeDisplayedValidation(WorkspacesConstants.windowTitle));
    await PageHelper.switchToDefaultContent();
    stepLogger.verification(`Blue notification displayed briefly on the right top corner stating
     'Your workspace is being created - we will notify you once it is ready'`);
    await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getElementUsingText(WorkspacesConstants.notification, true)))
        .toBe(true, ValidationsHelper.getNotificationDisplayedValidation(WorkspacesConstants.notification));
    return title;
    }
}
