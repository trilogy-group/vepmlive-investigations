import {SuiteNames} from '../../../helpers/suite-names';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../components/html/page-helper';
import {LoginPage} from '../../../../page-objects/pages/login/login.po';
import {MyWorkPageHelper} from '../../../../page-objects/pages/my-workplace/my-work/my-work-page.helper';

describe(SuiteNames.endToEndSuite, () => {

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        await new LoginPage().goToAndLogin();
        StepLogger.preCondition('User should be on "My Work" page.');
        await MyWorkPageHelper.navigateToMyWork();
        await MyWorkPageHelper.verifyMyWorkPageDisplayed();
    });

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    it('Check the ellipsis icon (…) on the grid.- [745063]', async () => {
        StepLogger.caseId = 745063;

        StepLogger.stepId(1);
        await MyWorkPageHelper.clickEllipsesIcon();
        await MyWorkPageHelper.hoverOnAnyOption();
        await MyWorkPageHelper.verifySubmenuDisplayed();

        StepLogger.stepId(2);
        const workType = await MyWorkPageHelper.clickWorkTypeOption();
        await MyWorkPageHelper.verifySearchResults(workType);
    });

    it('Close the ellipsis (…) pop-up. - [745064]', async () => {
        StepLogger.caseId = 745064;

        StepLogger.stepId(1);
        await MyWorkPageHelper.clickEllipsesIcon();
        await MyWorkPageHelper.verifyEllipsesDropdownDisplayed();

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickCloseOnEllipsesDropdown();
        await MyWorkPageHelper.verifyEllipsesDropdownClosed();
    });

    it('Set the "Working on" via grid. - [745070]', async () => {
        StepLogger.caseId = 745070;

        StepLogger.stepId(1);
        const itemTitle = await MyWorkPageHelper.clickOnWorkingOnForAnyItem();
        await MyWorkPageHelper.verifyRadioButtonSelected();

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickViewsTab();
        await MyWorkPageHelper.selectWorkingOnView();
        await MyWorkPageHelper.verifyWorkingOnItemDisplayed(itemTitle);
    });

    it('Delete the item through ellipsis menu. - [745074]', async () => {
        StepLogger.caseId = 745074;

        StepLogger.stepId(1);
        const itemTitle = await MyWorkPageHelper.clickOnEllipsesForAnyItem();
        await MyWorkPageHelper.verifyEllipsesDropdownForItemDisplayed();

        StepLogger.stepId(2);
        await MyWorkPageHelper.clickOnDeleteItem();
        await MyWorkPageHelper.verifyDeleteItemPopup();

        StepLogger.stepId(3);
        await MyWorkPageHelper.clickOKAlert();
        await MyWorkPageHelper.verifyItemDeleted(itemTitle);
    });
});
