import {BasePage} from '../../../base-page';
import {CommonPageHelper} from '../../../common/common-page.helper';
import {CommonNewItemPageConstants} from './common-new-item-page.constants';
import {ButtonHelper} from '../../../../../components/html/button-helper';
import {browser, By, element} from 'protractor';

export class CommonNewItemPage extends BasePage {
    static readonly titleId = 'dialogTitleSpan';

    static get ribbonItems() {
        const labels = CommonNewItemPageConstants.ribbonLabels;
        return {
            save: CommonPageHelper.getRibbonButtonByText(labels.save),
            cancel: CommonPageHelper.getRibbonButtonByText(labels.cancel)
        };
    }

    static get formButtons() {
        const labels = CommonNewItemPageConstants.ribbonLabels;
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

    static get contentFrame() {
        // element(By.css('.ms-dlgFrame')) never works in case of iframe
        return browser.driver.findElement(By.css('.ms-dlgFrame'));
    }
}
