import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {DiscussionsPage} from '../../../../../page-objects/pages/my-workplace/discussions/discussions.po';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {DiscussionsPageConstants} from '../../../../../page-objects/pages/my-workplace/discussions/discussions-page.constants';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {DiscussionsPageHelper} from '../../../../../page-objects/pages/my-workplace/discussions/discussions-page.helper';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
    });

    it('Navigate to Discussions page - [785609]', async () => {
        const stepLogger = new StepLogger(785609);
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.discussions,
            CommonPage.pageHeaders.myWorkplace.discussions,
            CommonPageConstants.pageHeaders.myWorkplace.discussions,
            stepLogger);
    });

    it('Add a New Discussion - [785611]', async () => {
        const stepLogger = new StepLogger(785611);
        stepLogger.step('PRECONDITION: navigate to Discussions page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.discussions,
            CommonPage.pageHeaders.myWorkplace.discussions,
            CommonPageConstants.pageHeaders.myWorkplace.discussions,
            stepLogger);

        stepLogger.stepId(1);
        stepLogger.step('Click on "+ new discussion" link displayed on top of "Discussions" page');
        await PageHelper.click(DiscussionsPage.newDiscussionLink);
        stepLogger.verification('"Discussion - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(DiscussionsPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(DiscussionsPageConstants.pageName));

        stepLogger.stepId(2);
        stepLogger.step(`Enter/Select below details in 'New Discussion' page`);
        const labels = DiscussionsPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const subject = `${labels.subject} ${uniqueId}`;
        const body = `${labels.body} ${uniqueId}`;
        await DiscussionsPageHelper.fillNewDiscussionFormAndVerify(subject, body, stepLogger);
    });
});
