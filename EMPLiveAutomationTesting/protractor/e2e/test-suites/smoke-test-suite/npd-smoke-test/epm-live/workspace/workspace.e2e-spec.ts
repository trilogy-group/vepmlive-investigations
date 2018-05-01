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
import {TextboxHelper} from '../../../../../components/html/textbox-helper';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {AnchorHelper} from '../../../../../components/html/anchor-helper';
import {ToDoPage} from '../../../../../page-objects/pages/my-workplace/to-do/to-do.po';
import {ToDoPageConstants} from '../../../../../page-objects/pages/my-workplace/to-do/to-do-page.constants';
import {IssueItemPageConstants} from '../../../../../page-objects/pages/items-page/issue-item/issue-item-page.constants';

describe(SuiteNames.smokeTestSuite, () => {
    let homePage: HomePage;
    beforeEach(async () => {
        await PageHelper.maximizeWindow();
        homePage = new HomePage();
        await homePage.goTo();
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

        stepLogger.stepId(2);
        stepLogger.step('Click on "+ New Item" link displayed on top of "To Do" page');
        await PageHelper.click(CommonPage.addNewLink);

        stepLogger.verification('"To Do - New Item" window is displayed');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonPage.title);
        await expect(await CommonPage.title.getText())
            .toBe(ToDoPageConstants.pagePrefix,
                ValidationsHelper.getPageDisplayedValidation(ToDoPageConstants.pageName));

        stepLogger.step(`Enter/Select below details in 'New To Do' page`);
        stepLogger.step(`Title *: New To Do 1`);
        const uniqueId = PageHelper.getUniqueId();
        const labels = ToDoPageConstants.inputLabels;
        const title = `${ToDoPageConstants.inputLabels.title} ${uniqueId}`;
        const status = CommonPageConstants.statuses.notStarted;
        const description = `${ToDoPageConstants.inputLabels.description} ${uniqueId}`;
        await TextboxHelper.sendKeys(ToDoPage.inputs.title, title);

        stepLogger.step(` Status: Select value 'Not Started'', if not selected already`);
        await PageHelper.sendKeysToInputField(ToDoPage.inputs.status, status);

        stepLogger.step(`Description: Enter some text [Ex: Description for New To Do 1]`);
        await TextboxHelper.sendKeys(ToDoPage.inputs.description, description);

        stepLogger.verification('Required values Entered/Selected in "Edit Issue" Page');
        stepLogger.verification('Verify - Title *: Random New Issue Item');
        await expect(await TextboxHelper.hasValue(ToDoPage.inputs.title, title))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.title, title));

        stepLogger.verification('Verify - Status: Select the value "In Progress"');
        await expect(await ElementHelper.hasSelectedOption(ToDoPage.inputs.status, status))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.status, status));

        stepLogger.verification('Verify - Description: Random value');
        await expect(await TextboxHelper.hasValue(ToDoPage.inputs.description, description))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.description, description));

        stepLogger.stepId(5);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);

        stepLogger.verification('"New To Do" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(IssueItemPageConstants.editPageName));

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
        await expect(await PageHelper.isElementPresent(AnchorHelper.getElementByTextXPathInsideGrid(title)))
            .toBe(true,
                ValidationsHelper.getLabelDisplayedValidation(title));
    });
});
