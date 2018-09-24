import {browser} from 'protractor';
import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {EventsPageHelper} from '../../../../../page-objects/pages/my-workplace/events/events-page.helper';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {EventsPage} from '../../../../../page-objects/pages/my-workplace/events/events.po';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {CheckboxHelper} from '../../../../../components/html/checkbox-helper';
import {ElementHelper} from '../../../../../components/html/element-helper';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;

    beforeEach(async () => {

        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    afterEach(async () => {
        await StepLogger.takeScreenShot();
    });

    it('Navigate to Event Page - [785879]', async () => {
        StepLogger.caseId = 785879;
        StepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            CommonPageConstants.pageHeaders.myWorkplace.events,
        );
    });

    it('Add an Event- [786942]', async () => {
        StepLogger.caseId = 786942;
        await EventsPageHelper.createNewEvent();
    });

    it('Create View- [855383]', async () => {
        StepLogger.caseId = 855383;
        const uniqueId = PageHelper.getUniqueId();
        StepLogger.preCondition('User is in Event page ');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            CommonPageConstants.pageHeaders.myWorkplace.events,
        );

        // Step #2 and #7 Inside this function
        await EventsPageHelper.createView(uniqueId, false);

    });

    it('Create Default View - [855387]', async () => {
        StepLogger.caseId = 855387;
        const uniqueId = PageHelper.getUniqueId();
        StepLogger.preCondition('User is in Event page ');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            CommonPageConstants.pageHeaders.myWorkplace.events,
        );

        // Step #1 and #6 Inside this function
        await EventsPageHelper.createView(uniqueId, true);
    });

    it('Create Column - [855530]', async () => {
        StepLogger.caseId = 855530;
        StepLogger.preCondition('User is in Event page ');
        const uniqueId = PageHelper.getUniqueId();
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            CommonPageConstants.pageHeaders.myWorkplace.events,
        );

        StepLogger.stepId(1);
        StepLogger.step('Click on CALENDAR tab');
        await PageHelper.click(EventsPage.calenderTab);

        StepLogger.verification('Details of the Calendar tab should be displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.calendearView))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.calendarContent));

        StepLogger.stepId(2);
        StepLogger.step('Click on Create Column from ribbon panel');
        await PageHelper.click(EventsPage.createColumn);

        StepLogger.verification('Create Column popup should be displayed');
        await PageHelper.switchToFrame(CommonPage.contentFrame);
        await expect(await PageHelper.isElementDisplayed(EventsPage.columnNameField))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.column));

        StepLogger.stepId(3);
        StepLogger.step('Select any of the column type');
        await CheckboxHelper.markCheckbox(EventsPage.choiceCheckbox, true);

        StepLogger.verification('the respective column type should get selected');
        await expect(await EventsPage.choiceCheckbox.isEnabled()).toBe(true,
            ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.columnType));

        StepLogger.stepId(4);
        StepLogger.step('Provide column name and other required details');
        await TextboxHelper.sendKeys(EventsPage.columnNameField, uniqueId);
        await TextboxHelper.sendKeys(EventsPage.descriptionField, CommonPageConstants.menuContainerIds.navigation);

        StepLogger.verification('the respective details should get populated');
        await CheckboxHelper.markCheckbox(EventsPage.choiceCheckbox, true);
        await expect(await TextboxHelper.hasValue(EventsPage.columnNameField, uniqueId))
            .toBe(true, ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.columnName));
        await expect(await TextboxHelper.hasValue(EventsPage.descriptionField, CommonPageConstants.menuContainerIds.navigation))
            .toBe(true, ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.columnDescription));

        StepLogger.stepId(5);
        StepLogger.step('Click on Ok button');
        await ElementHelper.scrollToElement(CommonPage.okButton);
        await PageHelper.click(CommonPage.okButton);

        StepLogger.verification('Newly added column should be displayed in events page while user select ' +
            'standard view from current view drop down ');
        await browser.sleep(PageHelper.timeout.m);
        await ElementHelper.clickUsingJs(EventsPage.createViews);
        await PageHelper.click(EventsPage.standardViewType);
        await ElementHelper.scrollToElement(ElementHelper.getElementByText(uniqueId));
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(uniqueId))).toBe(true,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.column));

    }) ;
});
