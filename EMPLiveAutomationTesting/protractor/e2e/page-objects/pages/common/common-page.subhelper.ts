import { PageHelper } from '../../../components/html/page-helper';
import { WaitHelper } from '../../../components/html/wait-helper';
import { ElementHelper } from '../../../components/html/element-helper';
import { StepLogger } from '../../../../core/logger/step-logger';
import { CommonPage } from './common.po';

export class CommonSubPageHelper {

    static async clickOnItemsTab() {
        StepLogger.subStep('click on items tab');
        await WaitHelper.waitForElementToBePresent(CommonPage.itemsMenu);
        await PageHelper.click(CommonPage.ribbonTitles.items);
        const isClicked = await WaitHelper.waitForElementToBeDisplayed(CommonPage.ribbonItems.editItem, PageHelper.timeout.s);
        if (!isClicked) {
            await ElementHelper.clickUsingJs(CommonPage.ribbonTitles.items);
            // it takes a while to load the items, also this is triggered only if menu is not displayed in first attempt
            await PageHelper.sleepForXSec(PageHelper.timeout.m);
        }
    }
}
