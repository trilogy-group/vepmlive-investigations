import { browser } from 'protractor';

import { StepLogger } from '../../../../../core/logger/step-logger';
import { TextboxHelper } from '../../../../components/html/textbox-helper';
import { PageHelper } from '../../../../components/html/page-helper';
import { ExpectationHelper } from '../../../../components/misc-utils/expectation-helper';
import { CommonPage } from '../../common/common.po';
import { CommonPageConstants } from '../../common/common-page.constants';
import { EventsPageConstants } from './events-page.constants';
import { EventsPage } from './events.po';
import { ValidationsHelper } from '../../../../components/misc-utils/validation-helper';
import { CommonPageHelper } from '../../common/common-page.helper';
import { MyWorkplacePage } from '../my-workplace.po';
import { WaitHelper } from '../../../../components/html/wait-helper';
import { ElementHelper } from '../../../../components/html/element-helper';
import { CheckboxHelper } from '../../../../components/html/checkbox-helper';
import { MyWorkplaceConstants } from '../my-workplace.constants';

export class EventsPageHelper {

    static async fillNewEventForm(title: string) {

        StepLogger.step(`Title *: New Event 1`);
        await expect(await PageHelper.isElementDisplayed(EventsPage.titleTextField))
            .toBe(true,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(EventsPageConstants.inputLabels.title));
        await TextboxHelper.sendKeys(EventsPage.titleTextField, title);

        StepLogger.step(`Select Category *: New Event 1`);
        await expect(await PageHelper.isElementDisplayed(EventsPage.categoryField)).toBe(true,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(EventsPageConstants.inputLabels.category));
        await PageHelper.click(EventsPage.categoryField);

        await expect(await PageHelper.isElementDisplayed(EventsPage.categoryOption))
            .toBe(true,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(EventsPageConstants.categoryOption.meeting));

        await PageHelper.click(EventsPage.categoryOption);

        StepLogger.stepId(4);
        StepLogger.step('Click on save');
        await expect(await PageHelper.isElementDisplayed(CommonPage.saveNewEvent)).toBe(true,
            ValidationsHelper.getWindowShouldNotBeDisplayedValidation(CommonPageConstants.formLabels.save));

        await PageHelper.clickAndWaitForElementToHide(CommonPage.saveNewEvent);
    }

    static async verifyNewEventCreated(titleNewEvent: string) {

        await PageHelper.switchToDefaultContent();
        StepLogger.verification('"Verificaion: New Event" page is closed');
        await ExpectationHelper.verifyNotDisplayedStatus(CommonPage.saveNewEvent, EventsPageConstants.editPageName);

        await this.expandAllItems();
        StepLogger.verification(`verify "New Event" got created which is: ${titleNewEvent}`);
        await expect(await PageHelper.isElementDisplayed(EventsPage.getNewEventAdded(titleNewEvent)))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(titleNewEvent));
    }

    static async fillNewEventsFormAndVerifyEventCreated(title: string) {
        StepLogger.step(`Title *: New Event 1`);
        await TextboxHelper.sendKeys(EventsPage.titleTextField, title);

        StepLogger.step(`Select Category *: New Event 1`);
        await PageHelper.click(EventsPage.categoryField);
        await PageHelper.click(EventsPage.categoryOption);

        StepLogger.stepId(4);
        StepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        StepLogger.verification('"New Event" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(EventsPageConstants.editPageName));

        StepLogger.verification('verify "New Event" get created');
        await expect(await PageHelper.isElementDisplayed(EventsPage.calenderBlock))
            .toBe(true, ValidationsHelper.getFieldDisplayedValidation(CommonPageConstants.title));
    }

    static async createNewEvent() {

        StepLogger.step('preCondition: navigate to Events page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            CommonPageConstants.pageHeaders.myWorkplace.events,
        );

        StepLogger.stepId(1);
        StepLogger.step('Click on "Events" tab displayed on top of "Events" page');
        await expect(await PageHelper.isElementDisplayed(EventsPage.eventsTab))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(MyWorkplaceConstants.navigationLabels.events));
        await PageHelper.click(EventsPage.eventsTab);

        StepLogger.verification('Tab Panel of the Events should get displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.tabPanel))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.tabPanel));

        StepLogger.stepId(2);
        StepLogger.step('Click on "New Event" option from Events tab panel');
        await expect(await PageHelper.isElementDisplayed(EventsPage.newEvent))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(EventsPageConstants.newEvent));
        await PageHelper.click(EventsPage.newEvent);

        StepLogger.verification('"Events - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitles.first());
        await ExpectationHelper.verifyText(CommonPage.dialogTitles.first(), EventsPageConstants.pageName, EventsPageConstants.pageName);

        StepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();
        StepLogger.stepId(3);
        StepLogger.step('Enter/Select required details in "Events - New Item" window');
        const labels = EventsPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const title = `${labels.title} ${uniqueId}`;
        await EventsPageHelper.fillNewEventForm(title);
        await EventsPageHelper.verifyNewEventCreated(title);
        return title;
    }

    static async createView(uniqueId: string, defaultView: boolean) {

        StepLogger.stepId(1);
        StepLogger.step('Click on CALENDAR tab');
        await PageHelper.click(EventsPage.calenderTab);

        StepLogger.verification('Contents of the CALENDAR tab should be displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.calendearView))
            .toBe(true, ValidationsHelper.getMenuDisplayedValidation(CommonPageConstants.calendarContent));

        StepLogger.stepId(2);
        StepLogger.step('Click on Create View');
        await ElementHelper.clickUsingJs(EventsPage.createViews);

        StepLogger.verification('View Type page should be displayed');
        await expect(await browser.getTitle()).toEqual(CommonPageConstants.viewDropDownLabels.createPublicView,
            ValidationsHelper.getDisplayedValidation(CommonPageConstants.viewType));

        StepLogger.stepId(3);
        StepLogger.step('Select any of the view [Example Standard View]');
        await PageHelper.click(EventsPage.standardViewType);

        StepLogger.verification('Create View popup should be displayed');
        await expect(await browser.getTitle())
            .toEqual(CommonPageConstants.viewDropDownLabels.createPublicView,
                ValidationsHelper.getDisplayedValidation(CommonPageConstants.createView));

        StepLogger.stepId(4);
        StepLogger.step('Provide value in required fields and check Make this the default view');

        if (defaultView === true) {
            await CheckboxHelper.markCheckbox(EventsPage.defaultCheckbox, true);
        }
        await TextboxHelper.sendKeys(EventsPage.viewName, uniqueId);

        StepLogger.stepId(5);
        StepLogger.step('Click on Ok button');
        await PageHelper.click(CommonPage.okButton);

        StepLogger.verification('View should be created and user should be navigated to event page');
        await PageHelper.click(EventsPage.rollOverEventList);

        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(uniqueId)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(CommonPageConstants.createdView));

        StepLogger.stepId(6);
        StepLogger.step('Navigate to any other page and come back to Event page and from the CALENDAR tab, select' +
            ' any the Standard View which was created from the Current View drop-down');
        await PageHelper.click(CommonPage.getbuttons.calender);
        await PageHelper.click(EventsPage.calenderTab);

        StepLogger.step('Expand Current View drop down');
        await PageHelper.click(EventsPage.currentView);
        await ElementHelper.clickUsingJs(ElementHelper.getElementByText(uniqueId));

        StepLogger.verification('Created view should be displayed in the list');
        await expect(await PageHelper.isElementDisplayed(ElementHelper.getElementByText(uniqueId)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(CommonPageConstants.createdView));
    }

    static async expandAllItems() {
        const count = await EventsPage.seeMoreLinks.count();
        let i = 0;
        while (i < count) {
            await PageHelper.click(EventsPage.seeMoreLinks.get(i));
            i++;
        }
    }
}
