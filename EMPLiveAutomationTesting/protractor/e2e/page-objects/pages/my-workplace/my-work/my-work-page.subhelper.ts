import {MyWorkPageConstants} from './my-work-page.constants';
import {CommonPage} from '../../common/common.po';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {CommonPageHelper} from '../../common/common-page.helper';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {MyWorkPage} from './my-work.po';
import {LoginPageHelper} from '../../login/login-page.helper';
import {CommonPageConstants} from '../../common/common-page.constants';
import {ExpectationHelper} from '../../../../components/misc-utils/expectation-helper';
import {MyWorkplacePage} from '../my-workplace.po';
import {ElementHelper} from '../../../../components/html/element-helper';
import { MyWorkPageHelper } from './my-work-page.helper';

export class MyWorkPageSubHelper {

    static async createToDoItem() {
        StepLogger.subStep('navigate to my work section');
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
        );
        StepLogger.subStep('Click on new item icon');
        await PageHelper.click(MyWorkPage.newItem);
        StepLogger.subStep('Click on to do item');
        await PageHelper.click(MyWorkPage.newItemMenu.toDoItem);
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dialogTitle);
        await ExpectationHelper.verifyDisplayedStatus(MyWorkPage.widowTitleName.toDo, MyWorkPageConstants.title.toDo);
        await CommonPageHelper.switchToFirstContentFrame();
        const uniqueId = PageHelper.getUniqueId();
        const labels = MyWorkPageConstants.inputLabels;
        const titleValue = `${labels.title} ${uniqueId}`;
        StepLogger.subStep(`Send text ${titleValue} to title`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.title, titleValue);
        StepLogger.subStep(`Send text ${LoginPageHelper.adminEmailId} assigned To`);
        await TextboxHelper.sendKeys(MyWorkPage.inputs.assignedTo, LoginPageHelper.adminEmailId);
        StepLogger.subStep('Click on assinged to suggetions');
        await PageHelper.click(MyWorkPage.assignedToSuggestions);
        StepLogger.subStep('Click on save button');
        await PageHelper.click(CommonPage.formButtons.save);
        await WaitHelper.staticWait(PageHelper.timeout.s);
        StepLogger.subVerification('Verify Save button is not displayed anymore');
        await ExpectationHelper.verifyNotDisplayedStatus(CommonPage.formButtons.save, CommonPageConstants.formLabels.save);
        return titleValue;
    }

    static async clickOnItem(item: string) {
        StepLogger.subStep('Click on newly created item in the grid.');
        await this.verifyItemPresent(item);
        StepLogger.subStep(`Click on item ${item}`);
        await PageHelper.click(MyWorkPage.itemCreated(item));
    }

    static async verifyItemPresent(item: string) {
        StepLogger.subStep('Verify item created');
        await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.itemCreated(item));
        StepLogger.subVerification('Verify Created item is displayed');
        await ExpectationHelper.verifyDisplayedStatus(MyWorkPage.itemCreated(item), item);
    }

    static async clickOnEllipsesForItem(item: string) {
        StepLogger.subStep('Expand the ellipsis icon for a grid item.');
        await ElementHelper.actionHoverOver(MyWorkPage.itemCreated(item));
        await WaitHelper.waitForElementToBeDisplayed(MyWorkPage.ellipsisIconOfItem(item));
        await PageHelper.click(MyWorkPage.ellipsisIconOfItem(item));
        StepLogger.subVerification('Verify Dropdown is displayed');
        await MyWorkPageHelper.verifyEllipsesDropdownForItemDisplayed();
    }

    static async deleteToDoItem(item: string) {
        await CommonPageHelper.navigateToItemPageUnderMyWorkplace(
            MyWorkplacePage.navigation.myWork,
            CommonPage.pageHeaders.myWorkplace.myWork,
            CommonPageConstants.pageHeaders.myWorkplace.myWork,
        );
        await this.verifyItemPresent(item);
        StepLogger.subStep('Click on Ellipses For Item');
        await MyWorkPageSubHelper.clickOnEllipsesForItem(item);
        StepLogger.subStep('Click on delete item');
        await PageHelper.click(MyWorkPage.ellipsesDropdownForItem.deleteItem);
        await PageHelper.acceptAlert();
        StepLogger.subVerification('Verify Item deleted');
        await MyWorkPageHelper.verifyItemDeleted(item);
    }

    static async clickOnAnyEditItem() {
        StepLogger.subStep('Click on "Edit Item" button.');
        await PageHelper.click(MyWorkPage.manageTabRibbonItems.editItem);
    }
}
