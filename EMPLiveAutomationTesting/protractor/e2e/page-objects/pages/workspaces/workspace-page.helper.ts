import {ElementHelper} from '../../../components/html/element-helper';
import {WorkSpacesPage} from './workspaces.po';
import {WaitHelper} from '../../../components/html/wait-helper';
import {WorkspacesConstants} from './workspaces.constants';
import {CommonPageHelper} from '../common/common-page.helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {PageHelper} from '../../../components/html/page-helper';
import {CommonPage} from '../common/common.po';
import {ValidationsHelper} from '../../../components/misc-utils/validation-helper';
import {TextboxHelper} from '../../../components/html/textbox-helper';
import {CommonPageConstants} from '../common/common-page.constants';
import {browser} from 'protractor';

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

    static async verifyWorkpaceMenuPanelOptions(stepLogger: StepLogger) {
        const option = WorkSpacesPage.workspacesMenuOptions;
        const optionName = WorkspacesConstants.workspacesMenuOptions;
        stepLogger.verification(`verify "New workspace" option is displayed`);
        const newWorkspaceDisplayed = await PageHelper.isElementDisplayed(option.newWorkspace);
        await expect(newWorkspaceDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            optionName.newWorkspace));

        stepLogger.verification(`verify "Favourite Workspaces" option is displayed`);
        const favouriteWorkspacesDisplayed = await PageHelper.isElementDisplayed(option.favoriteWorkspaces);
        await expect(favouriteWorkspacesDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            optionName.favoriteWorkspaces));

        stepLogger.verification(`verify "All Workspaces" option is displayed`);
        const AllWorkspacesDisplayed = await PageHelper.isElementDisplayed(option.allWorkspaces);
        await expect(AllWorkspacesDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            optionName.allWorkspaces));
    }

    static async verifyWorkpaceListingInMenuPanel(stepLogger: StepLogger) {
        stepLogger.verification(`verify all available Workspaces are listed`);
        const workspaceDisplayed = await PageHelper.isElementDisplayed(
            WorkSpacesPage.allWorkspaceListing);
        await expect(workspaceDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            WorkspacesConstants.workspaceListing));
    }

    static async expandEllipsisAndSelectEditTeamOption(stepLogger: StepLogger) {
        stepLogger.step('Mouse over on first listed workspace');
        await ElementHelper.actionHoverOver(WorkSpacesPage.allWorkspaceListing);
        stepLogger.step(`expand ellipsis against any workspace listed `);
        await PageHelper.click(WorkSpacesPage.workspaceEllipsis);
        stepLogger.step(`select "Edit Team" option`);
        await PageHelper.click(WorkSpacesPage.contextMenu.editTeam);
    }

    static async verifyEditTeamWindowOpened(stepLogger: StepLogger) {
        stepLogger.step('Switch to default frame');
        await PageHelper.switchToDefaultContent();
        stepLogger.verification(`verify "Edit Team" pop-up opened.`);
        const editTeamDisplayed = await PageHelper.isElementDisplayed(
            WorkSpacesPage.editTeamPopupHeading);
        await expect(editTeamDisplayed).toBe(true, ValidationsHelper.getDisplayedValidation(
            WorkspacesConstants.editTeam));
    }

    static async clickOnCloseButton(stepLogger: StepLogger) {
        stepLogger.step('Switch to content frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        stepLogger.step(`click on Close button`);
        await PageHelper.click(CommonPage.ribbonItems.close);
    }

    static async verifyEditTeamWindowClosed(stepLogger: StepLogger) {
        stepLogger.verification('"Edit Team" window is closed');
        await expect(await PageHelper.isElementPresent(CommonPage.ribbonItems.close, false))
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(
                    CommonPageConstants.ribbonLabels.close));
    }

    static async validateLatestNotification(stepLogger: StepLogger , title: string ) {
        let maxAttempts = 0;
        let maxClickAttempts = 0;
        stepLogger.step('Title is ' + title.replace('* ', '').replace(/-/g, '' ) );
        // tslint:disable-next-line:max-line-length
        while (!((await CommonPage.latestNotification.getText()).includes(title.replace('* ', '').replace(/-/g, '' ))) && maxAttempts++ < 20) {

            browser.refresh();

            await PageHelper.click(CommonPage.personIcon);

            await browser.sleep(PageHelper.timeout.s);

            while (!(await PageHelper.isElementPresent(CommonPage.latestNotification, false ) && maxClickAttempts++ < 10)) {
                browser.refresh();

                await PageHelper.click(CommonPage.personIcon);

                await browser.sleep(PageHelper.timeout.s);
            }

        }

        stepLogger.verification(`Notification 'Your Workspace <Name of Workspace entered in step# 3> is now ready!'
        displayed in the pop down`);
        await CommonPageHelper.labelContainValidation(title.replace('* ', '').replace(/-/g, '' ));
}
}
