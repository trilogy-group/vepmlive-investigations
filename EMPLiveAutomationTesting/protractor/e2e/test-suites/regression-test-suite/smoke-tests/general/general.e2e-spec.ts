import {SuiteNames} from '../../../helpers/suite-names';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {ProjectItemPageHelper} from '../../../../page-objects/pages/items-page/project-item/project-item-page.helper';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {ElementHelper} from '../../../../components/html/element-helper';
import {ProjectItemPage} from '../../../../page-objects/pages/items-page/project-item/project-item.po';
import {ProjectItemPageConstants} from '../../../../page-objects/pages/items-page/project-item/project-item-page.constants';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';

describe(SuiteNames.regressionTestSuite, () => {
    let loginPage: LoginPage;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    fit('Check behavior of "Save and Close" button - [743175]', async () => {
        StepLogger.caseId = 743175;
        const uniqueId = PageHelper.getUniqueId();

        StepLogger.step('Create a new project and navigate to build team page');
        await ProjectItemPageHelper.createProjectAndNavigateToBuildTeamPage(uniqueId, );

        StepLogger.verification('Verify Save and Close button is disabled by default');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.saveAndClose);
        await expect(await ElementHelper.hasClass(ProjectItemPage.saveAndClose,
            ProjectItemPageConstants.buildTeamContentClass.saveAndCloseDisabled))
            .toBe(true,
                ProjectItemPageConstants.messageText.saveAndCloseDisabled);

        StepLogger.step('Add resource to Current team and verify');
        await ProjectItemPageHelper.addResourceAndVerifyUserMovedUnderCurrentTeam(uniqueId, );
    });

});
