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

    it('Add, Edit and Delete Issue - [829740]', async () => {
        const stepLogger = new StepLogger(829740);
        stepLogger.stepId(1);
        let titleValue = await IssueItemPageHelper.createIssueAndValidateIt(stepLogger);

        stepLogger.stepId(2);
        titleValue = await IssueItemPageHelper.editItemAndValidateIt(stepLogger, titleValue);

        stepLogger.stepId(3);
        await IssueItemPageHelper.deleteItemAndValidateIt(stepLogger, titleValue);
    });

});
