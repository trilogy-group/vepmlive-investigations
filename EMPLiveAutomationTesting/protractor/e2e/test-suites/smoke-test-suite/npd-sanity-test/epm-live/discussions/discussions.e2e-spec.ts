import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {DiscussionsPageHelper} from '../../../../../page-objects/pages/my-workplace/discussions/discussions-page.helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
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
        await DiscussionsPageHelper.addDiscussion(stepLogger);
    });

    it('Edit Discussion from Workplace - [1175265]', async () => {
        const stepLogger = new StepLogger(1175265);

        stepLogger.step(`Precondition: Create new discussion`);
        const labels = DiscussionsPageConstants.inputLabels;
        let uniqueId = PageHelper.getUniqueId();
        let subject = `${labels.subject} ${uniqueId}`;
        let body = `${labels.body} ${uniqueId}`;
        let isQuestion = true;
        await DiscussionsPageHelper.createNewDiscussion(subject, body, isQuestion, stepLogger);

        stepLogger.stepId(1);
        stepLogger.stepId(2);
        // Step #1 and #2 Inside this function
        stepLogger.step('Navigate to Discussions page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.discussions,
            CommonPage.pageHeaders.myWorkplace.discussions,
            CommonPageConstants.pageHeaders.myWorkplace.discussions,
            stepLogger);
        stepLogger.step('Select "Navigation" icon  from left side menu and click on Risks');

        stepLogger.stepId(3);
        stepLogger.step('Mouse over the Discussion created as per pre requisites that need to be ' +
            'edited Click on the Ellipses button (...) and select Edit Item from the options displayed');
        await PageHelper.click(DiscussionsPage.getDiscussionField(subject));
        await PageHelper.click(DiscussionsPage.buttonSelector.edit);

        stepLogger.stepId(4);
        stepLogger.step('Enter/Select below details in Edit Discussion page Subject *: Updated New Discussion 1 Body: Update ' +
            'the text [Ex: Updated new Discussion used for Smoke Test Case creation] Question: Leave the check box unchecked/un selected');
        uniqueId = PageHelper.getUniqueId();
        subject = `${labels.subject} ${uniqueId}`;
        body = `${labels.body} ${uniqueId}`;
        isQuestion = false;
        await DiscussionsPageHelper.fillNewDiscussionForm(subject, body, isQuestion, stepLogger);

        stepLogger.stepId(5);
        stepLogger.step('Click save button');
        await DiscussionsPageHelper.saveDiscussionForm(stepLogger);

        stepLogger.verification('Updated Discussion item details subject displayed in the list');
        await expect(await PageHelper.isElementDisplayed(DiscussionsPage.getDiscussionFieldSelector(subject).subject))
            .toBeTruthy(ValidationsHelper.getWindowShouldNotBeDisplayedValidation(DiscussionsPageConstants.inputLabels.subject));

        stepLogger.verification('Updated Discussion item details body displayed in the list');
        await expect(await PageHelper.isElementDisplayed(DiscussionsPage.getDiscussionFieldSelector(body).body))
            .toBeTruthy(ValidationsHelper.getWindowShouldNotBeDisplayedValidation(DiscussionsPageConstants.inputLabels.body));
    });
});
