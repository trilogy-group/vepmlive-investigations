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
import {EventsPageConstants} from '../../../../../page-objects/pages/my-workplace/events/events-page.constants';
import {WaitHelper} from '../../../../../components/html/wait-helper';
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

    it('Navigate to Event Page - [785879]', async () => {
        const stepLogger = new StepLogger(785879);
        stepLogger.stepId(1);
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            CommonPageConstants.pageHeaders.myWorkplace.events,
            stepLogger);
    });

    it('Add an Event- [786942]', async () => {
        const stepLogger = new StepLogger(786942);
        stepLogger.step('PRECONDITION: navigate to Events page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            CommonPageConstants.pageHeaders.myWorkplace.events,
            stepLogger);

        stepLogger.stepId(1);
        stepLogger.step('Click on "Events" tab displayed on top of "Events" page');
        await PageHelper.click(EventsPage.eventsTab);
        stepLogger.verification('Tab Panel of the Events should get displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.tabPanel, true))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.tabPanel));

        stepLogger.stepId(2);
        stepLogger.step('Click on "New Event" option from Events tab panel');
        await PageHelper.click(EventsPage.newEvent);
        stepLogger.verification('"Events - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitles.first());
        await expect(await CommonPage.dialogTitles.first().getText())
            .toBe(EventsPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(EventsPageConstants.pageName));
        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.stepId(3);
        stepLogger.step('Enter/Select required details in "Events - New Item" window');
        const labels = EventsPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const title = `${labels.title} ${uniqueId}`;
        await EventsPageHelper.fillNewEventsFormAndVerifyEventCreated(title, stepLogger);
    });

    it('Create View- [855383]', async () => {
        const stepLogger = new StepLogger(855383);
        stepLogger.precondition('User is in Event page ');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            CommonPageConstants.pageHeaders.myWorkplace.events,
            stepLogger);

        stepLogger.precondition('User has added events');
        await PageHelper.click(EventsPage.eventsTab);
        await PageHelper.clickWithWaitxs(EventsPage.newEvent);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.eventDialogbox);
        await CommonPageHelper.switchToFirstContentFrame();
        const labels = EventsPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const title = `${labels.title} ${uniqueId}`;
        await EventsPageHelper.fillNewEventsFormAndVerifyEventCreated(title, stepLogger);

        stepLogger.stepId(1);
        stepLogger.step('Click on CALENDAR tab');
        await PageHelper.clickWithWaitxs(EventsPage.calenderTab);

        stepLogger.verification('Contents of the CALENDAR tab should be displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.calendearView, true))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.calendarContent));

        stepLogger.stepId(2);
        stepLogger.step('Click on Create View');
        await WaitHelper.getInstance().waitForElementToBeClickable(EventsPage.createView);
        await PageHelper.click(EventsPage.createView);

        stepLogger.verification('View Type page should be displayed');
        await expect(await PageHelper.isElementDisplayed(EventsPage.standardViewType, true))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.viewType));

        stepLogger.stepId(3);
        stepLogger.step('Select any of the view [Example Standard View]');
        await WaitHelper.getInstance().waitForElementToBeClickable(EventsPage.standardViewType);
        await PageHelper.click(EventsPage.standardViewType);

        stepLogger.verification('Create View popup should be displayed');
        await expect(await PageHelper.isElementDisplayed(EventsPage.viewName, true))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.createView));

        stepLogger.stepId(4);
        stepLogger.step('Provide View name and select / deselect columns as per need');
        await WaitHelper.getInstance().waitForElementToBeClickable(EventsPage.viewName);
        await TextboxHelper.sendKeys(EventsPage.viewName, uniqueId);

        stepLogger.stepId(5);
        stepLogger.step('Click on Ok button');
        await WaitHelper.getInstance().waitForElementToBeClickable(EventsPage.okButton);
        await PageHelper.click(EventsPage.okButton);

        stepLogger.verification('User should be navigated to event page and created view should be displayed');
        await WaitHelper.getInstance().waitForElementToBeClickable(EventsPage.rollOver);
        await PageHelper.click(EventsPage.rollOver);
        await expect(await PageHelper.isElementDisplayed(EventsPage.getelement(uniqueId), true))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.createdView));

        stepLogger.stepId(6);
        stepLogger.step('Click on CLENDAR tab');
        await PageHelper.click(EventsPage.getelement(CommonPageConstants.calendar));
        await PageHelper.click(EventsPage.calenderTab);

        stepLogger.verification('contents of the CALENDAR tab should be displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.calendearView, true))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.calendarContent));

        stepLogger.stepId(7);
        stepLogger.step('Expand Current View drop down');
        await WaitHelper.getInstance().waitForElementToBeClickable(EventsPage.currentView);
        await PageHelper.click(EventsPage.currentView);

        stepLogger.verification('Created view should be displayed in the list');
        await expect(await PageHelper.isElementDisplayed(EventsPage.getelement(uniqueId), true))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.createdView));

    });

    it('Create Default View - [855387]', async () => {
        const stepLogger = new StepLogger(855387);
        stepLogger.precondition('User is in Event page ');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            CommonPageConstants.pageHeaders.myWorkplace.events,
            stepLogger);

        stepLogger.precondition('User has added events');
        await PageHelper.click(EventsPage.eventsTab);
        await PageHelper.clickWithWaitxs(EventsPage.newEvent);
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.eventDialogbox);
        await CommonPageHelper.switchToFirstContentFrame();
        const labels = EventsPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const title = `${labels.title} ${uniqueId}`;
        await EventsPageHelper.fillNewEventsFormAndVerifyEventCreated(title, stepLogger);

        stepLogger.stepId(1);
        stepLogger.step('Click on CALENDAR tab');
        await PageHelper.clickWithWaitxs(EventsPage.calenderTab);

        stepLogger.verification('Contents of the CALENDAR tab should be displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.calendearView, true))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.calendarContent));

        stepLogger.stepId(2);
        stepLogger.step('Click on Create View');
        await WaitHelper.getInstance().waitForElementToBeClickable(EventsPage.createView);
        await PageHelper.click(EventsPage.createView);

        stepLogger.verification('View Type page should be displayed');
        await expect(await PageHelper.isElementDisplayed(EventsPage.standardViewType, true))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.viewType));

        stepLogger.stepId(3);
        stepLogger.step('Select any of the view [Example Standard View]');
        await WaitHelper.getInstance().waitForElementToBeClickable(EventsPage.standardViewType);
        await PageHelper.click(EventsPage.standardViewType);

        stepLogger.verification('Create View popup should be displayed');
        await expect(await PageHelper.isElementDisplayed(EventsPage.viewName, true))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.createView));

        stepLogger.stepId(4);
        stepLogger.step('Provide value in required fields and check Make this the default view');
        await WaitHelper.getInstance().waitForElementToBeClickable(EventsPage.viewName);
        await CheckboxHelper.markCheckbox(EventsPage.defaultCheckbox, true);
        await TextboxHelper.sendKeys(EventsPage.viewName, uniqueId);

        stepLogger.stepId(5);
        stepLogger.step('Click on Ok button');
        await WaitHelper.getInstance().waitForElementToBeClickable(EventsPage.okButton);
        await PageHelper.click(EventsPage.okButton);

        stepLogger.verification('View should be created and user should be navigated to event page');
        await WaitHelper.getInstance().waitForElementToBeClickable(EventsPage.rollOver);
        await PageHelper.click(EventsPage.rollOver);
        await expect(await PageHelper.isElementDisplayed(EventsPage.getelement(uniqueId), true))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.createdView));

        stepLogger.stepId(6);
        stepLogger.step('Navigate to any other page and come back to Event page and from the CALENDAR tab, select' +
            ' any the Standard View which was created from the Current View drop-down');
        await PageHelper.click(EventsPage.getelement(CommonPageConstants.calendar));
        await PageHelper.clickWithWaitxs(EventsPage.calenderTab);
        stepLogger.step('Expand Current View drop down');
        await WaitHelper.getInstance().waitForElementToBeClickable(EventsPage.currentView);
        await PageHelper.clickWithWaitxs(EventsPage.currentView);
        await ElementHelper.clickUsingJs(EventsPage.getelement(uniqueId));

        stepLogger.verification('Newly added default view should be displayed in event page ');
        await WaitHelper.getInstance().waitForElementToBeClickable(EventsPage.getelement(uniqueId));
        await expect(await PageHelper.isElementDisplayed(EventsPage.getelement(uniqueId), true))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.createdView));
    });
});
