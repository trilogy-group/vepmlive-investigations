import {By, element} from 'protractor';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {CommonItemPage} from './common-item.po';
import {PageHelper} from '../../../../components/html/page-helper';
import {CommonViewPage} from '../../homepage/common-view-page/common-view.po';
import {StepLogger} from '../../../../../core/logger/step-logger';

export class CommonItemPageHelper {
    static getNotificationByText(text: string) {
        return element(By.xpath(`//h2[${ComponentHelpers.getXPathFunctionForDot(text)}]`));
    }

    static getPageNumberByTitle(title: string) {
        return element(By.xpath(`//a[contains(@class,'pageNumber') and contains(@title,"${title}")]`));
    }

    static getMenuItemFromRibbonContainer(title: string) {
        return element(By.css(`#RibbonContainer li[title="${title}"]`));
    }

    static async editOptionViaRibbon(stepLogger: StepLogger) {
        await this.selectRecordFromGrid(stepLogger);

        stepLogger.step('Select "Edit Item" from the options displayed');
        await PageHelper.click(CommonItemPage.ribbonItems.editItem);
    }

    static async viewOptionViaRibbon(stepLogger: StepLogger) {
        await this.selectRecordFromGrid(stepLogger);

        stepLogger.step('Select "View Item" from the options displayed');
        await PageHelper.click(CommonItemPage.ribbonItems.viewItem);
    }

    private static async selectRecordFromGrid(stepLogger: StepLogger) {
        stepLogger.stepId(2);
        stepLogger.step('Select the check box for project created');
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonViewPage.record);
        await PageHelper.click(CommonViewPage.record);

        stepLogger.step('Click on ITEMS on ribbon');
        await PageHelper.click(CommonItemPage.ribbonTitles.items);
    }
}
