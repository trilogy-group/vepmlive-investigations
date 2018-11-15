import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {ToDoPage} from '../../../../../page-objects/pages/my-workplace/to-do/to-do.po';
import {ToDoPageConstants} from '../../../../../page-objects/pages/my-workplace/to-do/to-do-page.constants';
import {LinkPageConstants} from '../../../../../page-objects/pages/my-workplace/link/link-page.constants';
import {LinkPage} from '../../../../../page-objects/pages/my-workplace/link/link.po';
import {PicturePageConstants} from '../../../../../page-objects/pages/my-workplace/picture/picture-page.constants';
import {ToDoPageHelper} from '../../../../../page-objects/pages/my-workplace/to-do/to-do-page.helper';
import {MyTimeOffPageConstants} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.constants';
import {MyTimeOffPageHelper} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.helper';
import {EventsPageConstants} from '../../../../../page-objects/pages/my-workplace/events/events-page.constants';
import {EventsPage} from '../../../../../page-objects/pages/my-workplace/events/events.po';
import {EventsPageHelper} from '../../../../../page-objects/pages/my-workplace/events/events-page.helper';
import {LoginPage} from '../../../../../page-objects/pages/login/login.po';
import { ExpectationHelper } from '../../../../../components/misc-utils/expectation-helper';
import {ElementHelper} from '../../../../../components/html/element-helper';
// tslint:disable-next-line:max-line-length
import {SharedDocumentsPageConstants} from '../../../../../page-objects/pages/my-workplace/shared-documents/shared-documents-page.constants';
import {LinkPageHelper} from '../../../../../page-objects/pages/my-workplace/link/link-page.helper';
import {DiscussionsPageHelper} from '../../../../../page-objects/pages/my-workplace/discussions/discussions-page.helper';
import {DiscussionsPage} from '../../../../../page-objects/pages/my-workplace/discussions/discussions.po';
import {DiscussionsPageConstants} from '../../../../../page-objects/pages/my-workplace/discussions/discussions-page.constants';
import {TextboxHelper} from '../../../../../components/html/textbox-helper';

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

    it('Create A New To Do From Workplace - [1124261]', async () => {
        StepLogger.caseId = 1124261;
        StepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
        );

        StepLogger.stepId(3);
        StepLogger.step('Click on "+ New Item" link displayed on top of "To Do" page');
        await PageHelper.click(CommonPage.addNewLink);

        StepLogger.verification('"To Do - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ToDoPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ToDoPageConstants.pageName));

        StepLogger.step(`Enter/Select below details in 'New To Do' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = ToDoPageConstants.inputLabels;
        const title = `${labels.title} ${uniqueId}`;
        const status = CommonPageConstants.statuses.notStarted;
        const description = `${labels.description} ${uniqueId}`;
        await ToDoPageHelper.fillFormAndSave(title, status, description);

        StepLogger.verification('Newly created To Do item [Ex: New To Do 1] details displayed in read only mode');
        await expect(await CommonPage.contentTitleInViewMode.getText())
            .toBe(title,
                ValidationsHelper.getLabelDisplayedValidation(title));

        StepLogger.stepId(6);
        StepLogger.verification('Navigate to page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
        );

        await CommonPageHelper.searchItemByTitle(title,
            ToDoPageConstants.columnNames.title,
        );

        StepLogger.verification('Newly created To Do item [Ex: New To Do 1] details displayed in read only mode');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(title)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(title));
    });

    it('Edit To Do from Workplace - [1175263]', async () => {
        StepLogger.caseId = 1175263;
        StepLogger.stepId(1);

        // Step #1  and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.toDo,
            CommonPage.pageHeaders.myWorkplace.toDo,
            CommonPageConstants.pageHeaders.myWorkplace.toDo,
        );

        // Step #3 Inside this function
        await CommonPageHelper.actionTakenViaContextMenu(CommonPage.recordWithoutGreenTicket,
            CommonPage.contextMenuOptions.editItem);

        StepLogger.verification('"Edit Project" page is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ToDoPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ToDoPageConstants.editPageName));

        StepLogger.stepId(4);
        StepLogger.step(`Enter/Select below details in 'New To Do' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = ToDoPageConstants.inputLabels;
        const title = `${labels.title} ${uniqueId}`;
        const status = CommonPageConstants.statuses.inProgress;
        const description = `${labels.description} ${uniqueId}`;

        // Step #4 & #5 Inside this function
        await ToDoPageHelper.fillFormAndSave(title, status, description);

        // #5
        StepLogger.verification(`'Edit To Do' page is closed`);
        await expect(await ToDoPage.inputs.title.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ToDoPageConstants.editPageName));

        StepLogger.verification(`To Do page is displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.myWorkplace.toDo))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.toDo));

        StepLogger.step('Updated To Do item details (Title, Status) displayed in the list');
        StepLogger.step('Search item by title');
        await CommonPageHelper.searchItemByTitle(title, ToDoPageConstants.columnNames.title);

        StepLogger.step('Show columns whatever is required');
        const columnNames = ToDoPageConstants.columnNames;
        await CommonPageHelper.showColumns([
            columnNames.title,
            columnNames.status,
            columnNames.body]);

        StepLogger.step('Click on searched record');
        await PageHelper.click(CommonPage.recordWithoutGreenTicket);

        StepLogger.verification('Verify record by title');
        const firstTableColumns = [title];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(firstTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(firstTableColumns.join(CommonPageConstants.and)));

        StepLogger.verification('Verify by other properties');
        const secondTableColumns = [status, description];
        await expect(await PageHelper.isElementDisplayed(CommonPageHelper.getRowForTableData(secondTableColumns)))
            .toBe(true,
                ValidationsHelper.getRecordContainsMessage(secondTableColumns.join(CommonPageConstants.and)));
    });

    it('Create new Links from Workplace - [1175272]', async () => {
        StepLogger.caseId = 1175272;
        StepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.links,
            CommonPage.pageHeaders.myWorkplace.links,
            CommonPageConstants.pageHeaders.myWorkplace.links,
        );

        StepLogger.stepId(3);
        StepLogger.step('Click on "+ New Item" link displayed on top of "Links" page');
        await PageHelper.click(LinkPage.newLink);

        StepLogger.verification('"Link - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(LinkPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(LinkPageConstants.pageName));

        // Step #4 and #5 Inside this function
        const details = await LinkPageHelper.fillNewLinkFormAndVerification();

        await LinkPageHelper.verifyNewLinkAdded(details);
    });

    it('Create new Pictures from Workplace - [1175271]', async () => {
        StepLogger.caseId = 1175271;
        StepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.pictures,
            CommonPage.pageHeaders.myWorkplace.pictures,
            CommonPageConstants.pageHeaders.myWorkplace.pictures,
        );

        await CommonPageHelper.uploadDocument(CommonPage.pageHeaders.myWorkplace.pictures,
            PicturePageConstants.addAPicture,
            CommonPageConstants.pageHeaders.myWorkplace.pictures,
        );
    });

    it('Add Time Off From My Workplace - [1124447]', async () => {
        StepLogger.caseId = 1124447;

        StepLogger.step('Navigate to My Time Off page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myTimeOff,
            CommonPage.pageHeaders.myWorkplace.timeOff,
            MyTimeOffPageConstants.pagePrefix,
        );

        StepLogger.verification('"Time Off - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(MyTimeOffPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(MyTimeOffPageConstants.pagePrefix));

        StepLogger.step('Click on "+ New Item" link displayed on top of "Time Off" page');
        await PageHelper.click(CommonPage.addNewLink);

        StepLogger.step(`Enter/Select below details in 'My Time Off' page`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = MyTimeOffPageConstants.inputLabels;
        const input = MyTimeOffPageConstants.inputValues;
        const title = `${labels.title} ${uniqueId}`;
        const timeOffType = MyTimeOffPageConstants.timeOffTypes.holiday;
        const requestor = input.requestorValue;
        const startDate = input.startDate;
        const finishDate = input.finishDate;
        await MyTimeOffPageHelper.fillFormAndVerify(title, timeOffType, requestor, startDate, finishDate);

        StepLogger.verification('Newly created Time Off item details displayed in read only mode');
        await expect(await CommonPage.contentTitleInViewMode.getText())
            .toBe(title, ValidationsHelper.getLabelDisplayedValidation(title));

        StepLogger.verification('Navigate to page');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myTimeOff,
            CommonPage.pageHeaders.myWorkplace.timeOff,
            MyTimeOffPageConstants.pagePrefix,
        );

        await CommonPageHelper.searchItemByTitle(title, MyTimeOffPageConstants.columnNames.title);

        StepLogger.verification('Newly created Time off item details displayed in read only mode');
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextInsideGrid(title)))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(title));
    });

    it('Create a NewEvent from Workspace Functionality - [1124296]', async () => {
        StepLogger.caseId = 1124296;

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.events,
            CommonPage.pageHeaders.myWorkplace.events,
            EventsPageConstants.pagePrefix,
        );

        StepLogger.verification('"Events" Page is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(EventsPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(EventsPageConstants.pagePrefix));

        StepLogger.stepId(3);
        StepLogger.step('Mouse over on the date for which event to be created');
        await ElementHelper.actionMouseMove(EventsPage.calenderTomorrow);
        StepLogger.step('Click on "+ Add" link displayed on the date square box');
        await ElementHelper.clickUsingJs(EventsPage.addNewEvent(EventsPageConstants.addEvent));

        StepLogger.verification('"Events - New Item" window is displayed');
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitles.first());
        await expect(await CommonPage.dialogTitles.first().getText())
            .toBe(EventsPageConstants.pageName,
                ValidationsHelper.getPageDisplayedValidation(EventsPageConstants.pageName));

        StepLogger.step('Switch to frame');
        await CommonPageHelper.switchToFirstContentFrame();

        // Step #4 and #5 Inside this function
        const labels = EventsPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const title = `${labels.title} ${uniqueId}`;
        await EventsPageHelper.fillNewEventsFormAndVerifyEventCreated(title);
    });

    it('Create new Shared Document from Workplace - [1175269]', async () => {
        StepLogger.caseId = 1175269;
        StepLogger.stepId(1);

        // Step #1 and #2 Inside this function
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.sharedDocuments,
            CommonPage.pageHeaders.myWorkplace.sharedDocuments,
            CommonPageConstants.pageHeaders.myWorkplace.sharedDocuments,
        );

        await CommonPageHelper.uploadDocument(CommonPage.pageHeaders.myWorkplace.sharedDocuments,
            SharedDocumentsPageConstants.addADocument,
            CommonPageConstants.pageHeaders.myWorkplace.sharedDocuments,

            CommonPageHelper.uniqueDocumentFilePath);
    });

    it('Edit Event from Workplace - [1175266]', async () => {
        StepLogger.caseId = 1175266;

        StepLogger.step('preCondition: Create a New Event using steps in test case C1124296');
        const title = await EventsPageHelper.createNewEvent();

        StepLogger.stepId(3);
        StepLogger.step('Click on Event Name link displayed in Events Page for the event created as per pre requisites');
        const eventTitleElement = EventsPage.eventPageByTitle(title);
        await PageHelper.click(eventTitleElement);
        StepLogger.verification('Event Details Quick View Page is shown and all event details displayed in Read Only mode');
        const eventTitleDetails = CommonPageHelper.getElementUsingText(title, true);
        await expect(await PageHelper.isElementPresent(eventTitleDetails))
            .toBe(true, eventTitleDetails);

        StepLogger.stepId(4);
        StepLogger.step('Click on the "Edit Item" button menu displayed in "View" tab on top of the page');
        await PageHelper.click(EventsPage.editItem);
        StepLogger.verification('"Edit Event" page is displayed');
        await ExpectationHelper.verifyDisplayedStatus(CommonPage.saveNewEvent, CommonPageConstants.formLabels.save);

        // steps 5,6 are verified here
        const labels = EventsPageConstants.inputLabels;
        const uniqueId = PageHelper.getUniqueId();
        const newTitle = `${labels.title} ${uniqueId}`;
        await EventsPageHelper.fillNewEventForm(newTitle);

        StepLogger.stepId(7);
        StepLogger.step('Click "Close" button in Event Details Quick View Page');
        await PageHelper.click(EventsPage.closeEventButton);
        StepLogger.verification('"Events" Page is displayed');
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.myWorkplace.events))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.events));

        StepLogger.verification('Updated event is highlighted on the calendar for the date and time with blue background');
        const newEventTitle = CommonPageHelper.getElementUsingText(newTitle, true);
        await expect(await PageHelper.isElementPresent(newEventTitle))
            .toBe(true, ValidationsHelper.getLabelDisplayedValidation(newTitle));
    });

    it('Reply to a Discussion - [785614]', async () => {
        StepLogger.caseId = 785614;

        // steps 1,2,3 are inside this function
        StepLogger.step('preCondition: Create new Discussion');
        await DiscussionsPageHelper.addDiscussion();

        StepLogger.stepId(4);
        StepLogger.step(`Click on 'Discussion' added by Admin User`);
        const title = await ElementHelper.getText(DiscussionsPage.openDiscussionLink);
        await PageHelper.click(DiscussionsPage.openDiscussionLink);

        StepLogger.verification('the Discussion should get selected');
        await expect(await DiscussionsPage.discussionTitle.getText())
            .toBe(title, ValidationsHelper.getPageDisplayedValidation(title));

        StepLogger.stepId(5);
        StepLogger.step(`Click on 'Reply' Enter a response Click 'Reply' button`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = DiscussionsPageConstants.inputLabels;
        const message = `${labels.reply} ${uniqueId}`;
        await TextboxHelper.sendKeys(DiscussionsPage.replyMsg, message);
        await PageHelper.click(DiscussionsPage.replyButton);

        StepLogger.verification('Reply should be displayed below the discussion');
        await WaitHelper.waitForElementToBeDisplayed(DiscussionsPage.replyBody);
        await expect(await DiscussionsPage.replyBody.getText())
            .toBe(message, ValidationsHelper.getLabelDisplayedValidation(message));
    });
});
