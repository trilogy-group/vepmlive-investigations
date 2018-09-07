import {SuiteNames} from '../../../helpers/suite-names';
import {PageHelper} from '../../../../components/html/page-helper';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {MyWorkplacePage} from '../../../../page-objects/pages/my-workplace/my-workplace.po';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {MyWorkPageHelper} from '../../../../page-objects/pages/my-workplace/my-work/my-work-page.helper';

describe(SuiteNames.regressionTestSuite, () => {
    let loginPage: LoginPage;
    let stepLogger: StepLogger;
    beforeEach(async () => {
        stepLogger = new StepLogger();
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Edit page via Edit page option. - [745079]', async () => {
        stepLogger.caseId = 745079;
        const pageHeader = CommonPage.pageHeaders;
        const pageHeaderName = CommonPageConstants.pageHeaders.myWorkplace;

        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(MyWorkplacePage.navigation.myWork,
            pageHeader.myWorkplace.myWork, pageHeaderName.myWork, stepLogger);
        await MyWorkPageHelper.verifyMyWorkPageDisplayed(stepLogger);

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickOnPageTab(stepLogger);
        await MyWorkPageHelper.verifyPageTabIsSelected(stepLogger );

        stepLogger.stepId(3);
        await MyWorkPageHelper.expandEditPageDropdown(stepLogger);
        await MyWorkPageHelper.verifyEditPageDropdownOptions(stepLogger);

        stepLogger.stepId(4);
        await MyWorkPageHelper.clickOnEditPageMenuOption(stepLogger);
        await MyWorkPageHelper.verifyEditPageOpened(stepLogger);

    });
});
