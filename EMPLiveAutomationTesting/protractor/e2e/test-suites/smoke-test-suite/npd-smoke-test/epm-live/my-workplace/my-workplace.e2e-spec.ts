import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {ToDoPage} from '../../../../../page-objects/pages/my-workplace/to-do/to-do.po';
import {ToDoPageConstants} from '../../../../../page-objects/pages/my-workplace/to-do/to-do-page.constants';
import {LinkPageConstants} from '../../../../../page-objects/pages/my-workplace/link/link-page.constants';
import {LinkPage} from '../../../../../page-objects/pages/my-workplace/link/link.po';
import {By, element} from 'protractor';
import {PicturePage} from '../../../../../page-objects/pages/my-workplace/picture/picture.po';
import {PicturePageConstants} from '../../../../../page-objects/pages/my-workplace/picture/picture-page.constants';
import {ToDoPageHelper} from '../../../../../page-objects/pages/my-workplace/to-do/to-do-page.helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import { DiscussionsPageHelper } from '../../../../../page-objects/pages/my-workplace/discussions/discussions-page.helper';
import { DiscussionsPage } from '../../../../../page-objects/pages/my-workplace/discussions/discussions.po';
import { DiscussionsPageConstants } from '../../../../../page-objects/pages/my-workplace/discussions/discussions-page.constants';
import {browser, By, element} from 'protractor';
import {PicturePageConstants} from '../../../../../page-objects/pages/my-workplace/picture/picture-page.constants';
import {ToDoPageHelper} from '../../../../../page-objects/pages/my-workplace/to-do/to-do-page.helper';
import {MyTimeOffPageConstants} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.constants';
import {MyTimeOffPageHelper} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.helper';
import {EventsPageConstants} from '../../../../../page-objects/pages/my-workplace/events/events-page.constants';
import {EventsPage} from '../../../../../page-objects/pages/my-workplace/events/events.po';
import {EventsPageHelper} from '../../../../../page-objects/pages/my-workplace/events/events-page.helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
// tslint:disable-next-line:max-line-length
import {SharedDocumentsPageConstants} from '../../../../../page-objects/pages/my-workplace/shared-documents/shared-documents-page.constants';

describe(SuiteNames.smokeTestSuite, () => {
    let loginPage: LoginPage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        loginPage = new LoginPage();
        await loginPage.goToAndLogin();
    });

    it('Create A New To Do From Workplace - [1124261]', async () => {
        const stepLogger = new StepLogger(1124261);
        stepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "+ New Item" link displayed on top of "To Do" page');
        await PageHelper.click(CommonPage.addNewLink);

        stepLogger.verification('"To Do - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ToDoPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ToDoPageConstants.pageName));

        stepLogger.step(`Enter/Select below details in 'New To Do' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = ToDoPageConstants.inputLabels;
        const title = `${labels.title} ${uniqueId}`;
        const status = CommonPageConstants.statuses.notStarted;
        const description = `${labels.description} ${uniqueId}`;
        await ToDoPageHelper.fillFormAndSave(title, status, description, stepLogger);

        stepLogger.verification('Newly created To Do item [Ex: New To Do 1] details displayed in read only mode');
        await expect(await CommonPage.contentTitleInViewMode.getText())
            .toBe(title,
                ValidationsHelper.getLabelDisplayedValidation(title));

        stepLogger.stepId(6);
        stepLogger.verification('Navigate to page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
            stepLogger);

        await CommonPageHelper.searchItemByTitle(title,
            ToDoPageConstants.columnNames.title,
            stepLogger);

        stepLogger.verification('Newly created To Do item [Ex: New To Do 1] details displayed in read only mode');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(title)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(title));
    });

    it('Edit To Do from Workplace - [1175263]', async () => {
        const stepLogger = new StepLogger(1175263);
        stepLogger.stepId(1);

        // Step #1  and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
            stepLogger);

        // Step #3 Inside this function
        await CommonPageHelper.actionTakenViaContextMenu(CommonPage.recordWithoutGreenTicket,
            CommonPage.contextMenuOptions.editItem, stepLogger);

        stepLogger.verification('"Edit Project" page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ToDoPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ToDoPageConstants.editPageName));

        stepLogger.stepId(4);
        stepLogger.step(`Enter/Select below details in 'New To Do' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = ToDoPageConstants.inputLabels;
        const title = `${labels.title} ${uniqueId}`;
        const status = CommonPageConstants.statuses.inProgress;
        const description = `${labels.description} ${uniqueId}`;

        // Step #4 & #5 Inside this function
        await ToDoPageHelper.fillFormAndSave(title, status, description, stepLogger);

        // #5
        stepLogger.verification(`'Edit To Do' page is closed`);
        await expect(await ToDoPage.inputs.title.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ToDoPageConstants.editPageName));

        stepLogger.verification(`To Do page is displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.myWorkplace.toDo))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.toDo));

        stepLogger.step('Updated To Do item details (Title, Status) displayed in the list');
        stepLogger.step('Search item by title');
        await CommonPageHelper.searchItemByTitle(title, ToDoPageConstants.columnNames.title, stepLogger);

        stepLogger.step('Show columns whatever is required');
        const columnNames = ToDoPageConstants.columnNames;
        await CommonPageHelper.showColumns([
            columnNames.title,
            columnNames.status,
            columnNames.body]);

        stepLogger.step('Click on searched record');
        await PageHelper.click(CommonPage.recordWithoutGreenTicket);

        stepLogger.verification('Verify record by title');
        const firstTableColumns = [title];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(firstTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(firstTableColumns.join(CommonPageConstants.and)));

        stepLogger.verification('Verify by other properties');
        const secondTableColumns = [status, description];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(secondTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(secondTableColumns.join(CommonPageConstants.and)));
    });

    it('Create new Links from Workplace - [1175272]', async () => {
        const stepLogger = new StepLogger(1175272);
        stepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.links,
            CommonPage.pageHeaders.myWorkplace.links,
            CommonPageConstants.pageHeaders.myWorkplace.links,
            stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Click on "+ New Item" link displayed on top of "Links" page');
        await PageHelper.click(LinkPage.newLink);

        stepLogger.verification('"Link - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(LinkPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(LinkPageConstants.pageName));

        stepLogger.stepId(4);
        stepLogger.step(`Enter/Select below details in 'New Link' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = LinkPageConstants.inputLabels;
        const url = `https://url_${uniqueId}.com`;
        const description = `${LinkPageConstants.inputLabels.url} ${uniqueId}`;
        const notes = `${LinkPageConstants.inputLabels.notes} ${uniqueId}`;

        stepLogger.step(`Url *: http://url_randomstring.com`);
        await TextboxHelper.sendKeys(LinkPage.inputs.title.get(0), url);

        stepLogger.step(`Description *: Random description`);
        await TextboxHelper.sendKeys(LinkPage.inputs.title.get(1), description);

        stepLogger.step(`Notes: Random notes`);
        await TextboxHelper.sendKeys(LinkPage.inputs.notes, notes);

        stepLogger.verification('Required values Entered/Selected in "Edit To Do" Page');
        stepLogger.verification('Verify - URL');
        await expect(await TextboxHelper.hasValue(LinkPage.inputs.title.get(0), url))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.url, url));

        stepLogger.verification('Verify - Description');
        await expect(await TextboxHelper.hasValue(LinkPage.inputs.title.get(1), description))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.url, description));

        stepLogger.verification('Verify - Description: Random value');
        await expect(await TextboxHelper.hasValue(LinkPage.inputs.notes, notes))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.notes, notes));

        stepLogger.stepId(5);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);

        stepLogger.verification('"New Link" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ToDoPageConstants.editPageName));

        stepLogger.verification('Newly created Link item [Ex: New Link 1] details displayed in read only mode');

        const item = element(By.linkText(description));
        let pagingText = await CommonPage.paging.getText();
        while (!(await item.isPresent()) && await CommonPage.paginationControlsByTitle.next.isPresent()) {
            await PageHelper.click(CommonPage.paginationControlsByTitle.next);

            // Wait if page is not the next one, Ajax operation
            await browser.wait(async () => pagingText !== await CommonPage.paging.getText());
            pagingText = await CommonPage.paging.getText();
        }

        // Always Description appears whereas we want url to assert
        await expect(await PageHelper.isElementDisplayed(item))
            .toBe(true,
                ValidationsHelper.getDisplayedValidation(url));
    });

    it('Create new Pictures from Workplace - [1175271]', async () => {
        const stepLogger = new StepLogger(1175271);
        stepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.pictures,
            CommonPage.pageHeaders.myWorkplace.pictures,
            CommonPageConstants.pageHeaders.myWorkplace.pictures,
            stepLogger);
        await CommonPageHelper.uploadDocument(CommonPage.pageHeaders.myWorkplace.pictures,
            PicturePageConstants.addAPicture,
            CommonPageConstants.pageHeaders.myWorkplace.pictures,
            stepLogger);
    });

    it('Add Time Off From My Workplace - [1124447]', async () => {
        const stepLogger = new StepLogger(1124447);

        stepLogger.step('Navigate to My Time Off page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myTimeOff,
            CommonPage.pageHeaders.myWorkplace.timeOff,
            MyTimeOffPageConstants.pagePrefix,
            stepLogger);

        stepLogger.verification('"Time Off - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(MyTimeOffPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(MyTimeOffPageConstants.pagePrefix));

        stepLogger.step('Click on "+ New Item" link displayed on top of "Time Off" page');
        await PageHelper.click(CommonPage.addNewLink);

        stepLogger.step(`Enter/Select below details in 'My Time Off' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = MyTimeOffPageConstants.inputLabels;
        const input = MyTimeOffPageConstants.inputValues;
        const title = `${labels.title} ${uniqueId}`;
        const timeOffType = MyTimeOffPageConstants.timeOffTypes.holiday;
        const requestor = input.requestorValue;
        const startDate = input.startDate;
        const finishDate = input.finishDate;
        await MyTimeOffPageHelper.fillFormAndVerify(title, timeOffType, requestor, startDate, finishDate, stepLogger);

        stepLogger.verification('Newly created Time Off item details displayed in read only mode');
        await expect(await CommonPage.contentTitleInViewMode.getText())
            .toBe(title, ValidationsHelper.getLabelDisplayedValidation(title));

        stepLogger.verification('Navigate to page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myTimeOff,
            CommonPage.pageHeaders.myWorkplace.timeOff,
            MyTimeOffPageConstants.pagePrefix,
            stepLogger);

        await CommonPageHelper.searchItemByTitle(title, MyTimeOffPageConstants.columnNames.title, stepLogger);

        stepLogger.verification('Newly created Time off item details displayed in read only mode');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(title)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(title));
    });

    it('Create a NewEvent from Workspace Functionality - [1124296]', async () => {
        const stepLogger = new StepLogger(1124296);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            EventsPageConstants.pagePrefix,
            stepLogger);

        stepLogger.verification('"Events" Page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(EventsPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(EventsPageConstants.pagePrefix));

        stepLogger.stepId(3);
        stepLogger.step('Mouse over on the date for which event to be created');
        await ElementHelper.actionMouseMove(EventsPage.calenderTomorrow);
        stepLogger.step('Click on "+ Add" link displayed on the date square box');
        await ElementHelper.clickUsingJs(EventsPage.addNewEvent(EventsPageConstants.addEvent));

        stepLogger.verification('"Events - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitles.first());
        await expect(await CommonPage.dialogTitles.first().getText())
            .toBe(EventsPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(EventsPageConstants.pageName));

        stepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        // Step #4 and #5 Inside this function
        const labels = EventsPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const title = `${labels.title} ${uniqueId}`;
        await EventsPageHelper.fillNewEventsFormAndVerifyEventCreated(title, stepLogger);
    });

    it('Create new Shared Document from Workplace - [1175269]', async () => {
        const stepLogger = new StepLogger(1175269);
        stepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.sharedDocuments,
            CommonPage.pageHeaders.myWorkplace.sharedDocuments,
            CommonPageConstants.pageHeaders.myWorkplace.sharedDocuments,
            stepLogger);

        await CommonPageHelper.uploadDocument(CommonPage.pageHeaders.myWorkplace.sharedDocuments,
            SharedDocumentsPageConstants.addADocument,
            CommonPageConstants.pageHeaders.myWorkplace.sharedDocuments,
            stepLogger,
            CommonPageHelper.uniqueDocumentFilePath);
    });

    it('Edit Event from Workplace - [1175266]', async () => {
        const stepLogger = new StepLogger(1175266);

        stepLogger.step('PRECONDITION: Create a New Event using steps in test case C1124296');
        const title = await EventsPageHelper.createNewEvent();

        stepLogger.stepId(3);
        stepLogger.step('Click on Event Name link displayed in Events Page for the event created as per pre requisites');
        const eventTitleElement = EventsPage.eventPageByTitle(title);
        await PageHelper.click(eventTitleElement);
        stepLogger.verification('Event Details Quick View Page is shown and all event details displayed in Read Only mode');
        const eventTitleDetails = CommonPageHelper.getElementUsingText(title, true);
        await expect(await PageHelper.isElementPresent(eventTitleDetails))
            .toBe(true, eventTitleDetails);

        stepLogger.stepId(4);
        stepLogger.step('Click on the "Edit Item" button menu displayed in "View" tab on top of the page');
        await PageHelper.click(CommonPage.contextMenuOptions.editTeam);
        stepLogger.verification('"Edit Event" page is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPageHelper.getElementUsingText('Save', false));
        await expect(await CommonPage.title.getText())
            .toBe(EventsPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(EventsPageConstants.editPageName));

        // steps 5,6 are verified here
        const labels = EventsPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const newTitle = `${labels.title} ${uniqueId}`;
        await EventsPageHelper.fillNewEventForm(newTitle, stepLogger);

        stepLogger.stepId(7);
        stepLogger.step('Click "Close" button in Event Details Quick View Page');
        await PageHelper.click(EventsPage.closeEventButton);
        stepLogger.verification('"Events" Page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.myWorkplace.events))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.events));

        stepLogger.verification('Updated event is highlighted on the calendar for the date and time with blue background');
        const newEventTitle = CommonPageHelper.getElementUsingText(newTitle, true);
        await expect(await PageHelper.isElementPresent(newEventTitle))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(newTitle));
    });
  
      it('Reply to a Discussion - [785614]', async () => {
        const stepLogger = new StepLogger(785614);
        
        // steps 1,2,3 are inside this function
        stepLogger.step('PRECONDITION: Create new Discussion');        
        await DiscussionsPageHelper.addDiscussion(stepLogger);

        stepLogger.stepId(4);
        stepLogger.step(`Click on 'Discussion' added by Admin User`);
        const title = await ElementHelper.getText(DiscussionsPage.openDiscussionLink)
        await PageHelper.click(DiscussionsPage.openDiscussionLink);
        
        stepLogger.verification('the Discussion should get selected');
        await expect(await DiscussionsPage.discussionTitle.getText())
            .toBe(title, ValidationsHelper.getPageDisplayedValidation(title));
            
        stepLogger.stepId(4);
        stepLogger.step(`Click on 'Reply' Enter a response Click 'Reply' button`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = DiscussionsPageConstants.inputLabels;
        const replyMsg = `${labels.reply} ${uniqueId}`;
        await TextboxHelper.sendKeys(DiscussionsPage.replyMsg, replyMsg);
        await PageHelper.click(DiscussionsPage.replyButton);

        stepLogger.verification('Reply should be displayed below the discussion');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(DiscussionsPage.replyBody);
        await expect(await DiscussionsPage.replyBody.getText())
            .toBe(replyMsg, ValidationsHelper.getLabelDisplayedValidation(replyMsg));
    });
});
