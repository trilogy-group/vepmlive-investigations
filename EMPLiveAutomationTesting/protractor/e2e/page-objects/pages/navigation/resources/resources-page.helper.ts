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

    static async fillFormAndSave(displayName: string) {

        const labels = ResourcesPage.inputs;
        StepLogger.step(`Display Name *: New Resources 1`);
        await TextboxHelper.sendKeys(labels.displayName, displayName);

        StepLogger.step(`Select value for Role *: New Resources 1`);
        await PageHelper.click(labels.role);
        await PageHelper.click(labels.roleInput);

        StepLogger.step(`Select value for Holiday Schedule *: New Resources 1`);
        await PageHelper.click(labels.holidaySchedule);
        await PageHelper.click(labels.holidayScheduleInput);

        StepLogger.step(`Select value for Working Hours *: New Resources 1`);
        await PageHelper.click(labels.workingHours);
        await PageHelper.click(labels.workingHoursInput);

        StepLogger.stepId(4);
        StepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
        await PageHelper.switchToDefaultContent();

        StepLogger.verification('"New Resource" page is closed');
        await expect(await CommonPage.formButtons.save.isPresent())
            .toBe(false, ValidationsHelper.getWindowShouldNotBeDisplayedValidation(ResourcesPageConstants.editPageName));
    }

    static async clickNewInviteLink() {
        StepLogger.step('Click on "+ Invite" link displayed on top of "Resources" page');
        await WaitHelper.staticWait(PageHelper.timeout.s);
        await CommonPageHelper.buttonDisplayedValidation(ResourcesPage.newInviteLink, ResourcesPageConstants.inviteLink);

        await PageHelper.click(ResourcesPage.newInviteLink);

    }

    static async selectGenericBox() {
        StepLogger.step(`Check 'Generic' check box`);
        await PageHelper.click(ResourcesPage.inputs.generic);
    }

    static async clickSearchIcon() {
        StepLogger.step('Click on search');
        await PageHelper.click(ResourcesPage.searchIcon);
    }

    static async addResourceAndValidateIt() {
        const uniqueId = PageHelper.getUniqueId();
        const displayName = `${ResourcesPageConstants.inputLabels.displayName} ${uniqueId}`;

        StepLogger.step('Click on "+ Invite" link displayed on top of "Resources" page');
        await this.clickNewInviteLink();

        StepLogger.stepId(2);
        await this.selectGenericBox();

        StepLogger.stepId(3);
        StepLogger.step('Provide values in required fields');
        await this.fillFormAndSave(displayName);

        await WaitHelper.staticWait(PageHelper.timeout.s);
        StepLogger.stepId(4);
        await this.clickSearchIcon();

        await WaitHelper.staticWait(PageHelper.timeout.s);
        StepLogger.step('Enter newly created resource name');
        await TextboxHelper.sendKeys(ResourcesPage.searchTextbox, displayName, true);

        StepLogger.verification('Newly created Resource [Ex: Display Name 1] displayed in "Resources" page');
        await CommonPageHelper.labelDisplayedValidation(AnchorHelper.getElementByTextInsideGrid(displayName), displayName);

    }

    static async navigateToResourcesPage() {
        await CommonPageHelper.navigateToItemPageUnderNavigation(
            HomePage.navigation.projects.resources,
            CommonPage.pageHeaders.projects.resources,
            CommonPageConstants.pageHeaders.projects.resources,
        );
    }

    static async verifyResourcesPageDisplayed() {
        await ExpectationHelper.verifyDisplayedStatus(
            ResourcesPage.newInviteLink,
            ResourcesPageConstants.pagePrefix,
        );
    }

    static async verifyCreateUserPageDisplayed() {
        await ExpectationHelper.verifyDisplayedStatus(
            ResourcesPage.inputs.generic,
            ResourcesPageConstants.createUserPage,
        );
    }

    static async fillCreateUserForm() {
        const uniqueId = PageHelper.getUniqueId();
        const displayName = `${ResourcesPageConstants.inputLabels.displayName} ${uniqueId}`;
        const createUserlabels = ResourcesPage.inputs;
        await this.selectGenericBox();

        StepLogger.step(`enter display Name *: ${displayName}`);
        await TextboxHelper.sendKeys(createUserlabels.displayName, displayName);

        StepLogger.step(`Enter standard rate *: ${displayName}`);
        await TextboxHelper.sendKeys(createUserlabels.standardRate, ResourcesPageConstants.standardRate);

        StepLogger.step(`Select department *: ${displayName}`);
        await PageHelper.click(createUserlabels.department);
        await PageHelper.click(createUserlabels.departmentInput);

        StepLogger.step(`Select value for Role *: ${displayName}`);
        await PageHelper.click(createUserlabels.role);
        await PageHelper.click(createUserlabels.roleInput);

        StepLogger.step(`Select value for Holiday Schedule *: ${displayName}`);
        await PageHelper.click(createUserlabels.holidaySchedule);
        await PageHelper.click(createUserlabels.holidayScheduleInput);

        StepLogger.step(`Select value for Working Hours *: ${displayName}`);
        await PageHelper.click(createUserlabels.workingHours);
        await PageHelper.click(createUserlabels.workingHoursInput);
        return displayName;
    }

    static async clickSave() {
        StepLogger.step('Click on save');
        await PageHelper.click(CommonPage.formButtons.save);
    }

    static async verifyResourceSaved(displayName: string) {
        await browser.sleep(PageHelper.timeout.s);
        await this.clickSearchIcon();
        StepLogger.step('Enter newly created resource name');
        await TextboxHelper.sendKeys(ResourcesPage.searchTextbox, displayName, true);
        await ExpectationHelper.verifyDisplayedStatus(
            ResourcesPage.getUserByDisplayName(displayName),
            displayName,
        );
    }

    static async hoverOnResource() {
        StepLogger.step('Hover over Resource');
        const ellipses = ResourcesPage.gridDetails.ellipses;
        await browser.sleep(PageHelper.timeout.s);
        await ElementHelper.actionHoverOver(ellipses.get(0));
    }

    static async verifyEllipsisDisplayed() {
        await ExpectationHelper.verifyDisplayedStatus(
            ResourcesPage.gridDetails.ellipses.get(0),
            CommonPageConstants.ellipsisLabel,
        );
    }

    static async clickOnEllipsis() {
        StepLogger.step('Click on Ellipsis');
        await WaitHelper.waitForElementToBeDisplayed(ResourcesPage.gridDetails.ellipses.get(0));
        await ElementHelper.actionHoverOverAndClick(ResourcesPage.gridDetails.ellipses.get(0),
        ResourcesPage.gridDetails.ellipses.get(0));
    }

    static async verifyMenuItemDisplayed() {
        await ExpectationHelper.verifyDisplayedStatus(
            ResourcesPage.ellipsesDropdownForItem.editItem,
            ResourcesPageConstants.ellipsesDropdownLabel,
        );
    }

    static async clickOnEditItem() {
        StepLogger.step('Click on Edit Item');
        await PageHelper.click(ResourcesPage.ellipsesDropdownForItem.editItem);
    }

    static async editResourcePageDisplayed() {
        await ExpectationHelper.verifyDisplayedStatus(
            ResourcesPage.inputs.resources,
            ResourcesPageConstants.editPageName,
        );
    }

    static async selectDisabled() {
        StepLogger.step('Scroll down and check the checkbox for "Disabled"');
        const isDisabled = await PageHelper.isElementSelected(ResourcesPage.inputs.disabled);
        if (!isDisabled) {
            await PageHelper.click(ResourcesPage.inputs.disabled);
        }
    }

    static async verifyDisabledChecked() {
        await ExpectationHelper.verifyCheckboxIsChecked(
            ResourcesPage.inputs.disabled,
            ResourcesPageConstants.inputLabels.disabled,
        );
    }

    static async getDisplayNameInEditResourcePage() {
        StepLogger.step('Returns title of resource name');
        const displayName = await PageHelper.getAttributeValue(ResourcesPage.inputs.firstName, HtmlHelper.attributes.value);
        return displayName;
    }
}
