import {By, element, ElementFinder} from 'protractor';
import {CommonPage} from '../../common/common.po';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {ComponentHelpers} from '../../../../components/devfactory/component-helpers/component-helpers';
import {CommonViewPage} from './common-view.po';
import {CheckboxHelper} from '../../../../components/html/checkbox-helper';
import {WaitHelper} from '../../../../components/html/wait-helper';

export class CommonViewPageHelper {
    static get importantColumnsToShow() {
        const map = new Map<ElementFinder, ElementFinder>();
        map.set(CommonViewPage.columns.title, CommonViewPage.selectColumnOptions.title);
        map.set(CommonViewPage.columns.status, CommonViewPage.selectColumnOptions.status);
        map.set(CommonViewPage.columns.priority, CommonViewPage.selectColumnOptions.priority);
        return map;
    };

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
    };

    static getColumnHeaderByText(text: string) {
        return element(By.xpath(`//td[contains(@class,'GMHeaderText') and '${ComponentHelpers.getXPathFunctionForDot(text)}']`));
    }

    static async showColumns(map: Map<ElementFinder, ElementFinder>) {

        await WaitHelper.getInstance().waitForElementToBeDisplayed(CommonViewPage.selectColumnPanel);
        const isApplyRequired = false;
        await map.forEach(async (key, value) => {
            const isTitleAvailable = await key.isDisplayed();
            if (!isTitleAvailable) {
                await PageHelper.click(CommonViewPage.actionMenuIcons.selectColumns);
                await CheckboxHelper.markCheckbox(value, true);
                isApplyRequired = true;
            }
        });
        if (isApplyRequired) {
            await PageHelper.click(CommonViewPage.applySelectColumnButton);
        }
    }
}
