import {SuiteNames} from '../../../helpers/suite-names';
import {PageHelper} from '../../../../components/html/page-helper';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {WorkspacePageHelper} from '../../../../page-objects/pages/workspaces/workspace-page.helper';

describe(SuiteNames.regressionTestSuite, () => {
    let loginPage: LoginPage;
    let stepLogger: StepLogger;
    beforeEach(async () => {
        stepLogger = new StepLogger();
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Verify workspace button. - [744303]', async () => {
        stepLogger.caseId = 744303;
        stepLogger.stepId(1);
        await CommonPageHelper.clickLhsSideBarMenuIcon(CommonPage.sidebarMenus.workspaces, stepLogger);
        await CommonPageHelper.verifyPanelHeaderDisplayed(CommonPage.sidebarMenuPanelHeader.workspaces,
            CommonPageConstants.sidebarMenuPanelHeader.workspaces, stepLogger);

        stepLogger.stepId(2);
        await WorkspacePageHelper.verifyWorkpaceMenuPanelOptions(stepLogger);
    });
});
