import {By, element, ElementFinder} from 'protractor';
import {CommonPage} from '../../common/common.po';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';
import {CommonViewPage} from './common-view.po';
import {CheckboxHelper} from '../../../../components/html/checkbox-helper';
import {WaitHelper} from '../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../common/common-page.helper';

export class CommonViewPageHelper {
    static getPageHeaderByTitle(title: string) {
        return element(By.css(`a[title="${title}"]`));
    }

    static getActionMenuIcons(title: string) {
        return element(By.css(`#actionmenu2Main li[title="${title}"]`));
    }

    static getContextMenuItemByText(text: string) {
        const xpath = `//ul[contains(@class,"epm-nav-contextual-menu")]//a[${ComponentHelpers.getXPathFunctionForDot(text)}]`;
        return element(By.xpath(xpath));
    }

    static async navigateToIssuePage(linkOfThePage: ElementFinder,
                                     pageHeader: ElementFinder,
                                     pageName: string,
                                     stepLogger: StepLogger) {
        stepLogger.step('Select "Navigation" icon  from left side menu');
        await PageHelper.click(CommonPage.sidebarMenus.navigation);

        stepLogger.step(`Select Project -> ${pageName} from the left side menu options displayed`);
        await PageHelper.click(linkOfThePage);

        stepLogger.verification(`${pageName} page is displayed`);
        await expect(await PageHelper.isElementDisplayed(pageHeader))
            .toBe(true,
                ValidationsHelper.getPageDisplayedValidation(pageName));
    }

    static getColumnHeaderByText(text: string) {
        return element(By.xpath(`//td[contains(@class,'GMHeaderText') and ${ComponentHelpers.getXPathFunctionForDot(text)}]`));
    }

    static async showColumns(columnNames: string[]) {
        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonViewPage.ganttGrid);
        let isApplyRequired = false;
        let promises = await Array.from(columnNames, async (key: string) => {
            const isOptionAvailable = await CommonViewPageHelper.getColumnHeaderByText(key).isPresent();
            if (!isOptionAvailable) {
                isApplyRequired = true;
            }
            return;
        });
        await Promise.all(promises);
        if (isApplyRequired) {
            await PageHelper.click(CommonViewPage.actionMenuIcons.selectColumns);
            await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonViewPage.selectColumnPanel);
            promises = await Array.from(columnNames, async (key: string) => {
                await CheckboxHelper.markCheckbox(CommonPageHelper.getCheckboxByExactText(key), true);
            });
            await Promise.all(promises);
            await PageHelper.click(CommonViewPage.applySelectColumnButton);
        }
    }
}
