import {StepLogger} from '../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../components/html/page-helper';
import {ResourcesPage} from './resources.po';
import {CommonPage} from '../../common/common.po';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {ResourcesPageConstants} from './resources-page.constants';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {AnchorHelper} from '../../../../components/html/anchor-helper';
import {CommonPageHelper} from '../../common/common-page.helper';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {HomePage} from '../../homepage/home.po';
import {CommonPageConstants} from '../../common/common-page.constants';
import {ExpectationHelper} from '../../../../components/misc-utils/expectation-helper';
import {browser} from 'protractor';
import {ElementHelper} from '../../../../components/html/element-helper';
import {HtmlHelper} from '../../../../components/misc-utils/html-helper';

export class ResourcesPageHelper {

    static async fillFormAndSave(displayName: string, stepLogger: StepLogger) {

        const labels = ResourcesPage.inputs;
        stepLogger.step(`Display Name *: New Resources 1`);
        await TextboxHelper.sendKeys(labels.displayName, displayName);

        stepLogger.step(`Select value for Role *: New Resources 1`);
        await PageHelper.click(labels.role);
        await PageHelper.click(labels.roleInput);

        stepLogger.step(`Select value for Holiday Schedule *: New Resources 1`);
        await PageHelper.click(labels.holidaySchedule);
        await PageHelper.click(labels.holidayScheduleInput);

        stepLogger.step(`Select value for Working Hours *: New Resources 1`);
        await PageHelper.click(labels.workingHours);
        await PageHelper.click(labels.workingHoursInput);

        stepLogger.stepId(4);
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        stepLogger.verification('"New Resource" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false, ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ResourcesPageConstants.editPageName));
    }
    static async clickNewInviteLink(stepLogger: StepLogger) {
        stepLogger.step('Click on "+ Invite" link displayed on top of "Resources" page');
        await WaitHelper.staticWait(PageHelper.timeout.s);
        await CommonPageHelper.buttonDisplayedValidation(ResourcesPage.newInviteLink, ResourcesPageConstants.inviteLink );

        await PageHelper.click(ResourcesPage.newInviteLink);

    }
    static async selectGenericBox(stepLogger: StepLogger) {
        stepLogger.step(`Check 'Generic' check box`);
        await PageHelper.click(ResourcesPage.inputs.generic);
    }
    static async clickSearchIcon(stepLogger: StepLogger) {
        stepLogger.step('Click on search');
        await PageHelper.click(ResourcesPage.searchIcon);
    }
    static async addResourceAndValidateIt(stepLogger: StepLogger) {
        const uniqueId = PageHelper.getUniqueId();
        const displayName = `${ResourcesPageConstants.inputLabels.displayName} ${uniqueId}`;

        stepLogger.step('Click on "+ Invite" link displayed on top of "Resources" page');
        await this.clickNewInviteLink(stepLogger);

        stepLogger.stepId(2);
        await this.selectGenericBox(stepLogger);

        stepLogger.stepId(3);
        stepLogger.step('Provide values in required fields');
        await this.fillFormAndSave(displayName, stepLogger);

        await WaitHelper.staticWait(PageHelper.timeout.s);
        stepLogger.stepId(4);
        await this.clickSearchIcon(stepLogger);

        await WaitHelper.staticWait(PageHelper.timeout.s);
        stepLogger.step('Enter newly created resource name');
        await TextboxHelper.sendKeys(ResourcesPage.searchTextbox, displayName, true);

        stepLogger.verification('Newly created Resource [Ex: Display Name 1] displayed in "Resources" page');
        await CommonPageHelper.labelDisplayedValidation(AnchorHelper.getElementByTextInsideGrid(displayName), displayName );

    }

    static async navigateToResourcesPage(stepLogger: StepLogger) {
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.resources,
            CommonPage.pageHeaders.projects.resources,
            CommonPageConstants.pageHeaders.projects.resources,
            stepLogger);
    }

    static async verifyResourcesPageDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(
            ResourcesPage.newInviteLink,
            ResourcesPageConstants.pagePrefix,
            stepLogger
        );
    }

    static async verifyCreateUserPageDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(
            ResourcesPage.inputs.generic,
            ResourcesPageConstants.createUserPage,
            stepLogger
        );
    }

    static async fillCreateUserForm(stepLogger: StepLogger) {
        const uniqueId = PageHelper.getUniqueId();
        const displayName = `${ResourcesPageConstants.inputLabels.displayName} ${uniqueId}`;
        const createUserlabels = ResourcesPage.inputs;
        await this.selectGenericBox(stepLogger);

        stepLogger.step(`enter display Name *: ${displayName}`);
        await TextboxHelper.sendKeys(createUserlabels.displayName, displayName);

        stepLogger.step(`Enter standard rate *: ${displayName}`);
        await TextboxHelper.sendKeys(createUserlabels.standardRate, ResourcesPageConstants.standardRate);

        stepLogger.step(`Select department *: ${displayName}`);
        await PageHelper.click(createUserlabels.department);
        await PageHelper.click(createUserlabels.departmentInput);

        stepLogger.step(`Select value for Role *: ${displayName}`);
        await PageHelper.click(createUserlabels.role);
        await PageHelper.click(createUserlabels.roleInput);

        stepLogger.step(`Select value for Holiday Schedule *: ${displayName}`);
        await PageHelper.click(createUserlabels.holidaySchedule);
        await PageHelper.click(createUserlabels.holidayScheduleInput);

        stepLogger.step(`Select value for Working Hours *: ${displayName}`);
        await PageHelper.click(createUserlabels.workingHours);
        await PageHelper.click(createUserlabels.workingHoursInput);
        return displayName;
    }

    static async clickSave(stepLogger: StepLogger) {
        stepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
    }

    static async verifyResourceSaved(displayName: string, stepLogger: StepLogger) {
        await browser.sleep(PageHelper.timeout.s);
        await this.clickSearchIcon(stepLogger);
        stepLogger.step('Enter newly created resource name');
        await TextboxHelper.sendKeys(ResourcesPage.searchTextbox, displayName, true);
        await ExpectationHelper.verifyDisplayedStatus(
            ResourcesPage.getUserByDisplayName(displayName),
            displayName,
            stepLogger
        );
    }

    static async hoverOnResource(stepLogger: StepLogger) {
        stepLogger.step('Hover over Resource');
        const ellipses = ResourcesPage.gridDetails.ellipses.get(1);
        await browser.sleep(PageHelper.timeout.s);
        await ElementHelper.actionHoverOver(ellipses);
    }

    static async verifyEllipsisDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(
            ResourcesPage.gridDetails.ellipses.get(1),
            CommonPageConstants.ellipsisLabel,
            stepLogger
        );
    }

    static async clickOnEllipsis(stepLogger: StepLogger) {
        stepLogger.step('Click on Ellipsis');
        await PageHelper.click(ResourcesPage.gridDetails.ellipses.get(1));
    }

    static async verifyMenuItemDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(
            ResourcesPage.ellipsesDropdownForItem.editItem,
            ResourcesPageConstants.ellipsesDropdownLabel,
            stepLogger
        );
    }

    static async clickOnEditItem(stepLogger: StepLogger) {
        stepLogger.step('Click on Edit Item');
        await PageHelper.click(ResourcesPage.ellipsesDropdownForItem.editItem);
    }

    static async editResourcePageDisplayed(stepLogger: StepLogger) {
        await ExpectationHelper.verifyDisplayedStatus(
            ResourcesPage.inputs.displayName,
            ResourcesPageConstants.editPageName,
            stepLogger
        );
    }

    static async selectDisabled(stepLogger: StepLogger) {
        stepLogger.step('Scroll down and check the checkbox for "Disabled"');
        const isDisabled = await PageHelper.isElementSelected(ResourcesPage.inputs.disabled);
        if ( ! isDisabled) {
            await PageHelper.click(ResourcesPage.inputs.disabled);
        }
    }

    static async verifyDisabledChecked(stepLogger: StepLogger) {
        await ExpectationHelper.verifyCheckboxIsChecked(
            ResourcesPage.inputs.disabled,
            ResourcesPageConstants.inputLabels.disabled,
            stepLogger
        );
    }

    static async getDisplayNameInEditResourcePage(stepLogger: StepLogger) {
        stepLogger.step('Returns title of resource name');
        const displayName = await PageHelper.getAttributeValue(ResourcesPage.inputs.displayName, HtmlHelper.attributes.value);
        return displayName;
    }
}
