import {SuiteNames} from '../../../helpers/suite-names';
import {PageHelper} from '../../../../components/html/page-helper';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../../../page-objects/pages/common/common-page.helper';
import {MyWorkplacePage} from '../../../../page-objects/pages/my-workplace/my-workplace.po';
import {CommonPage} from '../../../../page-objects/pages/common/common.po';
import {CommonPageConstants} from '../../../../page-objects/pages/common/common-page.constants';
import {MyWorkPageHelper} from '../../../../page-objects/pages/my-workplace/my-work/my-work-page.helper';

describe(SuiteNames.endToEndSuite, () => {
    let loginPage: LoginPage;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Edit page via Edit page option. - [745079]', async () => {
        StepLogger.caseId = 745079;
        const pageHeader = CommonPage.pageHeaders;
        const pageHeaderName = CommonPageConstants.pageHeaders.myWorkplace;

        StepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(MyWorkplacePage.navigation.myWork,
            pageHeader.myWorkplace.myWork, pageHeaderName.myWork);
        await MyWorkPageHelper.verifyMyWorkPageDisplayed();

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickOnPageTab();
        await MyWorkPageHelper.verifyPageTabIsSelected();

        StepLogger.stepId(3);
        await MyWorkPageHelper.expandEditPageDropdown();
        await MyWorkPageHelper.verifyEditPageDropdownOptions();

        StepLogger.stepId(4);
        await MyWorkPageHelper.clickOnEditPageMenuOption();
        await MyWorkPageHelper.verifyEditPageOpened();

    });
});
