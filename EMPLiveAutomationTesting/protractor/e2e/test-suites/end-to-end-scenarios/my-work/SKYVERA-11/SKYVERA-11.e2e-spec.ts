import {SuiteNames} from '../../../helpers/suite-names';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../components/html/page-helper';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {MyWorkPageHelper} from '../../../../page-objects/pages/my-workplace/my-work/my-work-page.helper';

describe(SuiteNames.endToEndSuite, () => {
    let stepLogger: StepLogger;
    beforeEach(async () => {
        stepLogger = new StepLogger();
        await PageHelper.maximizeWindow();
        await new LoginPage().goToAndLogin();
        stepLogger.preCondition('User should be on "My Work" page.');
        await MyWorkPageHelper.navigateToMyWork(stepLogger);
        await MyWorkPageHelper.verifyMyWorkPageDisplayed(stepLogger);
    });

    it('Check the ellipsis icon (…) on the grid.- [745063]', async () => {
        stepLogger.caseId = 745063;

        stepLogger.stepId(1);
        await MyWorkPageHelper.clickEllipsesIcon(stepLogger);
        await MyWorkPageHelper.hoverOnAnyOption(stepLogger);
        await MyWorkPageHelper.verifySubmenuDisplayed(stepLogger);

        stepLogger.stepId(2);
        const workType = await MyWorkPageHelper.clickWorkTypeOption(stepLogger);
        await MyWorkPageHelper.verifySearchResults(workType, stepLogger);
    });

    it('Close the ellipsis (…) pop-up. - [745064]', async () => {
        stepLogger.caseId = 745064;

        stepLogger.stepId(1);
        await MyWorkPageHelper.clickEllipsesIcon(stepLogger);
        await MyWorkPageHelper.verifyEllipsesDropdownDisplayed(stepLogger);

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickCloseOnEllipsesDropdown(stepLogger);
        await MyWorkPageHelper.verifyEllipsesDropdownClosed(stepLogger);
    });

    it('Set the "Working on" via grid. - [745070]', async () => {
        stepLogger.caseId = 745070;

        stepLogger.stepId(1);
        const itemTitle = await MyWorkPageHelper.clickOnWorkingOnForAnyItem(stepLogger);
        await MyWorkPageHelper.verifyRadioButtonSelected(stepLogger);

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickViewsTab(stepLogger);
        await MyWorkPageHelper.selectWorkingOnView(stepLogger);
        await MyWorkPageHelper.verifyWorkingOnItemDisplayed(itemTitle, stepLogger);
    });

    it('Delete the item through ellipsis menu. - [745074]', async () => {
        stepLogger.caseId = 745074;

        stepLogger.stepId(1);
        const itemTitle = await MyWorkPageHelper.clickOnEllipsesForAnyItem(stepLogger);
        await MyWorkPageHelper.verifyEllipsesDropdownForItemDisplayed(stepLogger);

        stepLogger.stepId(2);
        await MyWorkPageHelper.clickOnDeleteItem(stepLogger);
        await MyWorkPageHelper.verifyDeleteItemPopup(stepLogger);

        stepLogger.stepId(3);
        await MyWorkPageHelper.clickOKAlert(stepLogger);
        await MyWorkPageHelper.verifyItemDeleted(itemTitle, stepLogger);
    });
});
