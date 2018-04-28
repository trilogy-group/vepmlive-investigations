import {BasePage} from '../../base-page';
import {CommonPageHelper} from '../../common/common-page.helper';
import {CommonItemPageConstants} from './common-item-page.constants';
import {ButtonHelper} from '../../../../components/html/button-helper';
import {browser, By, element} from 'protractor';
import {CommonItemPageHelper} from './common-item-page.helper';

export class CommonItemPage extends BasePage {
    static readonly dialogTitleId = 'dialogTitleSpan';
    static readonly titleId = 'pageTitle';


    static get ribbonTitles() {
        const titles = CommonItemPageConstants.ribbonMenuTitles;
        return {
            hide: CommonItemPageHelper.getMenuItemFromRibbonContainer(titles.hide),
            items: CommonItemPageHelper.getMenuItemFromRibbonContainer(titles.items),
            list: CommonItemPageHelper.getMenuItemFromRibbonContainer(titles.list)
        };
    }

    static get ribbonItems() {
        const labels = CommonItemPageConstants.ribbonLabels;
        return {
            save: CommonPageHelper.getRibbonButtonByText(labels.save),
            editItem: CommonPageHelper.getRibbonButtonByText(labels.editItem),
            cancel: CommonPageHelper.getRibbonButtonByText(labels.cancel)
        };
    }

    static get formButtons() {
        const labels = CommonItemPageConstants.ribbonLabels;
        return {
            save: ButtonHelper.getInputButtonByExactTextXPath(labels.save),
            cancel: ButtonHelper.getInputButtonByExactTextXPath(labels.save)
        };
    }

    static get titles() {
        return element.all(By.id(this.titleId));
    }

    static get title() {
        return element(By.id(this.titleId));
    }

    static get dialogTitles() {
        return element.all(By.id(this.dialogTitleId));
    }

    static get dialogTitle() {
        return element(By.id(this.dialogTitleId));
    }

    static get contentFrame() {
        // element(By.css('.ms-dlgFrame')) never works in case of iframe
        return browser.driver.findElement(By.css('.ms-dlgFrame'));
    }
}
