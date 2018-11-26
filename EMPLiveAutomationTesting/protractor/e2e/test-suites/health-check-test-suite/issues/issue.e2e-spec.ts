import {PageHelper} from '../../../components/html/page-helper';
import {SuiteNames} from '../../helpers/suite-names';
import {LoginPage} from '../../../page-objects/pages/login/login.po';
import {StepLogger} from '../../../../core/logger/step-logger';

import {IssueItemPageHelper} from '../../../page-objects/pages/items-page/issue-item/issue-item-page.helper';

describe(SuiteNames.healthCheckTestSuite, () => {
    let loginPage: LoginPage;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    it('Add, Edit and Delete Issue - [829740]', async () => {
        StepLogger.caseId = 829740;
        StepLogger.stepId(1);
        let titleValue = await IssueItemPageHelper.createIssueAndValidateIt();

        StepLogger.stepId(2);
        titleValue = await IssueItemPageHelper.editItemAndValidateIt(titleValue);

        StepLogger.stepId(3);
        await IssueItemPageHelper.deleteItemAndValidateIt(titleValue);
    });

});
