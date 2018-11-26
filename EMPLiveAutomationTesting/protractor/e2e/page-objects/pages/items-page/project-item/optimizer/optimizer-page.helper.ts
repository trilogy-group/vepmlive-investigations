import {StepLogger} from '../../../../../../core/logger/step-logger';
import {PageHelper} from '../../../../../components/html/page-helper';
import {OptimizerPage} from './optimizer-page.po';
import {ElementHelper} from '../../../../../components/html/element-helper';
import {ValidationsHelper} from '../../../../../components/misc-utils/validation-helper';
import {WaitHelper} from '../../../../../components/html/wait-helper';
import {CommonPageHelper} from '../../../common/common-page.helper';
import {OptimizerPageConstants} from './optimizer-page.constants';
import {CommonPageConstants} from '../../../common/common-page.constants';
import {CommonPage} from '../../../common/common.po';
import { ExpectationHelper } from '../../../../../components/misc-utils/expectation-helper';

export class OptimizerPageHelper {
    static async clickConfigrationButton() {
        // this is work around without it not able to work on new tab
        await WaitHelper.waitForElementToBePresent(OptimizerPage.iFrame);
        await WaitHelper.staticWait(PageHelper.timeout.s);
        await PageHelper.switchToFrame(OptimizerPage.iFrame.getWebElement());
        await WaitHelper.staticWait(PageHelper.timeout.xs);
        StepLogger.step('Click Configration Button');
        await PageHelper.click(OptimizerPage.configure);
    }

    static async selectAvailableFiled() {
        StepLogger.step('Click select Available Filed Button');
        await WaitHelper.waitForElementToBePresent(OptimizerPage.optionAvailable);
        await ElementHelper.actionHoverOver(OptimizerPage.optionAvailable);
        await ElementHelper.actionClick(OptimizerPage.optionAvailable);
    }

    static async clickAddOption() {
        StepLogger.step('Click Add Button');
        await PageHelper.click(OptimizerPage.addOption);
    }

    static async clickOkOption() {
        StepLogger.step('Click Ok  Button');
        await PageHelper.click(OptimizerPage.okOption);
    }

    static async clickSaveStrategy() {
        StepLogger.step('Click save Strategy Button');
        await PageHelper.click(OptimizerPage.saveStrategy);
    }

    static async verifySaveStrategyPopUpOpen() {
        StepLogger.verification('verify Save Strategy PopUp Open');
        await CommonPageHelper.fieldDisplayedValidation(OptimizerPage.strategyName, OptimizerPageConstants.saveStrategy);
    }

    static async saveNewStratedyName() {
        StepLogger.step('Click save Strategy Button');
        await PageHelper.click(OptimizerPage.saveNewStratedyName);
    }

    static async clickShowAllStrategyArrowDown() {
        await WaitHelper.staticWait(PageHelper.timeout.s);

        StepLogger.step('Click Show All save Strategy Arrow Down Button');
        await PageHelper.click(OptimizerPage.arrowDown);
    }

    static async addAvilabelFiled() {

        await this.selectAvailableFiled();

        await this.clickAddOption();

        await this.clickOkOption();
    }

    static async enterStrategyName(strategyName: string) {
        StepLogger.step('Enter strategy Name' + strategyName);
        await PageHelper.sendKeysToInputField(OptimizerPage.strategyName, strategyName);
    }

    static async saveStrategyValidateIt(strategyName: string) {

        await this.enterStrategyName(strategyName);

        await this.saveNewStratedyName();

        await this.clickShowAllStrategyArrowDown();

        await expect(await ElementHelper.getText(OptimizerPage.currectstrategy))
            .toContain(strategyName, ValidationsHelper.getLabelDisplayedValidation(strategyName));
    }

    static async optimizerPageElementCheck() {

        StepLogger.verification('Available option is displayed');
        await CommonPageHelper.buttonDisplayedValidation(OptimizerPage.optionAvailable, OptimizerPageConstants.avaliableOption);

        StepLogger.verification('Optimizer Text is displayed');

        await CommonPageHelper.fieldDisplayedValidation(OptimizerPage.optimizerText, OptimizerPageConstants.optimizerText);

        StepLogger.verification('Total Field Drop Down is displayed');
        await CommonPageHelper.buttonDisplayedValidation(OptimizerPage.totalFieldDropDown, OptimizerPageConstants.totalFieldDropDown);

        StepLogger.verification('Budget is selected bu default  is displayed');
        await CommonPageHelper.textPresentValidation(OptimizerPage.totalFieldDropDownOption, OptimizerPageConstants.budget);

        StepLogger.verification('Total Field Drop Down is displayed');
        await CommonPageHelper.buttonDisplayedValidation(OptimizerPage.addOption, OptimizerPageConstants.menuConfigure.add);

        StepLogger.verification('Total Field Drop Down is displayed');
        await CommonPageHelper.buttonDisplayedValidation(OptimizerPage.okOption, OptimizerPageConstants.menuConfigure.ok);

    }

    static async verifyConfigrationPopUpClosed() {
        StepLogger.verification('Optimizer Configuration Popup closed');
        await ExpectationHelper.verifyHiddenStatus(
            CommonPage.pageHeaders.projects.optimizerConfiguration, CommonPageConstants.pageHeaders.projects.projectDetails);
    }

    static async verifyConfigrationPopUPDisplayed() {
        StepLogger.verification('Optimizer Configuration Page is  opened ');
        await CommonPageHelper.fieldDisplayedValidation
        (CommonPage.pageHeaders.projects.optimizerConfiguration,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectDetails));
    }
}
