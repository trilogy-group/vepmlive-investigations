import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {OptimizerPageHelper} from '../../../../../page-objects/pages/items-page/project-item/optimizer/optimizer-page.helper';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });
    it('Create New Strategy in Optimizer Functionality - [1124301]', async () => {
        const stepLogger = new StepLogger(1124301);
        const uniqueId = PageHelper.getUniqueId();

        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.projects,
            CommonPage.pageHeaders.projects.projectsCenter,
            CommonPageConstants.pageHeaders.projects.projectCenter,
            stepLogger);

        stepLogger.stepId(2);
        stepLogger.stepId(3);
        await CommonPageHelper.optimizerViaRibbon(stepLogger);

        await CommonPageHelper.verifyNavigation(stepLogger);

        stepLogger.stepId(4);
        await OptimizerPageHelper.clickConfigrationButton(stepLogger);

        await OptimizerPageHelper.verifyConfigrationPopUPDisplayed(stepLogger);

        stepLogger.stepId(5);
        await OptimizerPageHelper.addAvilabelFiled(stepLogger);

        await OptimizerPageHelper.verifyConfigrationPopUpClosed(stepLogger);

        stepLogger.stepId(6);
        await OptimizerPageHelper.clickSaveStrategy(stepLogger);

        await OptimizerPageHelper.verifySaveStrategyPopUpOpen(stepLogger);

        stepLogger.stepId(7);
        stepLogger.stepId(8);
        await OptimizerPageHelper.saveStrategyValidateIt(stepLogger , uniqueId);
    });
});
