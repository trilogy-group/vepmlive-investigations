import {CommonPageHelper} from '../../../common/common-page.helper';
import {OptimizerPageConstants} from './optimizer-page.constants';
import {BasePage} from '../../../base-page';
import {By, element} from 'protractor';
import {ElementHelper} from '../../../../../components/html/element-helper';

export class OptimizerPage extends BasePage {
    static get configure() {
        return  CommonPageHelper.getRibbonButtonByText(OptimizerPageConstants.configureButton);
    }
    static get saveStrategy() {
        return  CommonPageHelper.getRibbonMediumButtonByTitle(OptimizerPageConstants.saveStrategy, true);
    }
    static get strategyName() {
        return  element(By.id('idSaveStratName'));
    }
    static get optionAvailable() {
        return  element(By.css('[name="idOptAvailflds"] option'));
    }
    static  configureMenu(value: string ) {
        return element(By.xpath(`//*[@id='idOptDlg']//*[@value='${value}']`));
    }
    static get addOption() {
        return this.configureMenu(OptimizerPageConstants.menuConfigure.add);
    }
    static get okOption() {
        return this.configureMenu(OptimizerPageConstants.menuConfigure.ok);
    }
    static get arrowDown() {
        return element(By.className('ms-cui-dd-arrow-button'));
    }
    static  get saveNewStratedyName() {
        return element(By.xpath('//*[@class="button-container"]//*[@value="OK"]'));
    }
    static get currectstrategy() {
        return element(By.id('idOptTab_SelView_viewinternal'));
    }
    static get optimizerText() {
        return ElementHelper.getElementByText(OptimizerPageConstants.optimizerText , true);
    }
    static get totalFieldDropDown() {
        return element(By.id(OptimizerPageConstants.fieldDropDownId));
    }
    static get totalFieldDropDownOption() {
        return element.all(By.css(`#${OptimizerPageConstants.fieldDropDownId} option`)).get(0);
    }
}
