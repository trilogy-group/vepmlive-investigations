import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../components/html/page-helper';
import {StepLogger} from '../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../page-objects/pages/common/common-page.constants';
import {WorkspacePageHelper} from '../../../page-objects/pages/workspaces/workspace-page.helper';

describe(SuiteNames.regressionTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Hide the panel via "Hide" button. - [743197]', async () => {
        const stepLogger = new StepLogger(743197);
        stepLogger.stepId(1);
        await CommonPageHelper.clickLhsSideBarMenuIcon(CommonPage.sidebarMenus.workspaces, stepLogger);
        await CommonPageHelper.verifyPanelHeaderDisplayed(CommonPage.sidebarMenuPanelHeader.workspaces,
            CommonPageConstants.sidebarMenuPanelHeader.workspaces, stepLogger);
        await WorkspacePageHelper.verifyWorkpaceListingInMenuPanel(stepLogger);

        stepLogger.stepId(2);
        await WorkspacePageHelper.expandEllipsisAndSelectEditTeamOption(stepLogger);
        await WorkspacePageHelper.verifyEditTeamWindowOpened(stepLogger);

        stepLogger.stepId(3);
        await WorkspacePageHelper.clickOnCloseButton(stepLogger);
        await WorkspacePageHelper.verifyEditTeamWindowClosed(stepLogger);
    });
});
