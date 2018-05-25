import {SuiteNames} from '../../../../helpers/suite-names';
import {PageHelper} from '../../../../../components/html/page-helper';
import {HomePage} from '../../../../../page-objects/pages/homepage/home.po';
import {StepLogger} from '../../../../../../core/logger/step-logger';
import {MyWorkplacePage} from '../../../../../page-objects/pages/my-workplace/my-workplace.po';
import {CommonPage} from '../../../../../page-objects/pages/common/common.po';
import {CommonPageHelper} from '../../../../../page-objects/pages/common/common-page.helper';
import {CommonPageConstants} from '../../../../../page-objects/pages/common/common-page.constants';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {ToDoPage} from '../../../../../page-objects/pages/my-workplace/to-do/to-do.po';
import {ToDoPageConstants} from '../../../../../page-objects/pages/my-workplace/to-do/to-do-page.constants';
import {LinkPageConstants} from '../../../../../page-objects/pages/my-workplace/link/link-page.constants';
import {LinkPage} from '../../../../../page-objects/pages/my-workplace/link/link.po';
import {PicturePage} from '../../../../../page-objects/pages/my-workplace/picture/picture.po';
import {PicturePageConstants} from '../../../../../page-objects/pages/my-workplace/picture/picture-page.constants';
import {ToDoPageHelper} from '../../../../../page-objects/pages/my-workplace/to-do/to-do-page.helper';
import {MyTimeOffPageConstants} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.constants';
import {MyTimeOffPageHelper} from '../../../../../page-objects/pages/my-workplace/my-time-off/my-time-off-page.helper';
import { LinkPageHelper } from '../../../../../page-objects/pages/my-workplace/link/link-page.helper';
import { element, By, browser } from 'protractor';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goToAndLogin();
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
        await CommonPageHelper.editItemViaContextMenu(stepLogger, CommonPage.recordWithoutGreenTicket);

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
        
        // Step #4 and #5 Inside this function
        const details = await LinkPageHelper.fillNewLinkFormAndVerification(stepLogger);

        stepLogger.verification('Newly added Link details are displayed in the list');
        const item = element(By.linkText(details.description));
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
                 ValidationsHelper.getDisplayedValidation(details.url));

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

        stepLogger.stepId(3);
        stepLogger.step('Click on the "+ New" button link displayed on top of "Pictures" page');
        await PageHelper.click(PicturePage.uploadButton);

        stepLogger.step('Waiting for page to open');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.dialogTitle);

        await expect(await CommonPage.dialogTitle.getText())
            .toBe(PicturePageConstants.addAPicture,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(PicturePageConstants.addAPicture));

        stepLogger.step('Switch to frame');
        await PageHelper.switchToFrame(CommonPage.contentFrame);

        const newFile = CommonPageHelper.uniqueImageFilePath;
        stepLogger.stepId(4);
        stepLogger.step('Click on "Choose Files" button in "Add a picture" pop up');
        stepLogger.step('Browse and select the file that need to be added as a picture');
        await PageHelper.uploadFile(PicturePage.browseButton, newFile.fullFilePath);

        stepLogger.step('Click "OK" button');
        await PageHelper.click(CommonPage.formButtons.ok);

        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"Add a picture" window is closed');
        await expect(await CommonPage.dialogTitle.isDisplayed())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(PicturePageConstants.addAPicture));

        stepLogger.verification(`Pictures page is displayed`);
        await expect(await PageHelper.isElementDisplayed(CommonPage.pageHeaders.myWorkplace.pictures))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.myWorkplace.pictures));

        await expect(ElementHelper.getElementByText(newFile.newFileName).isDisplayed())
            .toBe(true,
                ValidationsHelper.getImageDisplayedValidation(newFile.newFileName));
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
 
});
