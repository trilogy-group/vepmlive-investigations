import { PageHelper } from '../../../components/html/page-helper';
import { WaitHelper } from '../../../components/html/wait-helper';
import { ElementHelper } from '../../../components/html/element-helper';
import { StepLogger } from '../../../../core/logger/step-logger';
import { CommonPage } from './common.po';
import { CommonSubPage } from './common.subpo';

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

    static async selectProject(project: string) {
        StepLogger.subStep(`Select the check box for project : ${project}`);
        await WaitHelper.waitForElementToBeDisplayed(CommonSubPage.projectItemCheckBox(project));
        await ElementHelper.clickUsingJs(CommonSubPage.projectItemCheckBox(project));
        await PageHelper.sleepForXSec(PageHelper.timeout.xs);
    }

    static async selectCheckBox() {
        await WaitHelper.waitForElementToBeDisplayed(CommonPage.dataRows.get(1));
        await ElementHelper.actionHoverOver(CommonPage.dataRows.get(1));
        StepLogger.subStep('Cliick on checkbox');
        await PageHelper.click(CommonPage.rowsFirstColumn.get(1));
    }

    static async selectOneRecordFromGrid() {
        StepLogger.subStep('Select the check box for record');
        await WaitHelper.waitForElementToBePresent(CommonPage.getNthRecord());
        await ElementHelper.actionHoverOver(CommonPage.getNthRecord());
        await PageHelper.click(CommonPage.getNthRecord());
    }
}
