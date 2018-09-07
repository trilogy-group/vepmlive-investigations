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

export class OptimizerPageHelper {
    static async clickConfigrationButton(stepLogger: StepLogger) {
        // this is work around without it not able to work on new tab
        await WaitHelper.waitForElementToBeDisplayed(OptimizerPage.saveStrategy);

        await CommonPageHelper.switchToFirstContentFrame();

        stepLogger.step('Click Configration Button');
        await PageHelper.click(OptimizerPage.configure);
    }
    static async selectAvailableFiled(stepLogger: StepLogger) {
        stepLogger.step('Click select Available Filed Button');
        await PageHelper.click(OptimizerPage.optionAvailable);
    }
    static async clickAddOption(stepLogger: StepLogger) {
        stepLogger.step('Click Add Button');
        await PageHelper.click(OptimizerPage.addOption);
    }
    static async clickOkOption(stepLogger: StepLogger) {
        stepLogger.step('Click Ok  Button');
        await PageHelper.click(OptimizerPage.okOption);
    }
    static async clickSaveStrategy(stepLogger: StepLogger) {
        stepLogger.step('Click save Strategy Button');
        await PageHelper.click(OptimizerPage.saveStrategy);
    }
    static async verifySaveStrategyPopUpOpen(stepLogger: StepLogger) {
        stepLogger.verification('verify Save Strategy PopUp Open');
        await CommonPageHelper.fieldDisplayedValidation(OptimizerPage.strategyName, OptimizerPageConstants.saveStrategy);
    }
    static async saveNewStratedyName(stepLogger: StepLogger) {
        stepLogger.step('Click save Strategy Button');
        await PageHelper.click(OptimizerPage.saveNewStratedyName);
    }
    static async clickShowAllStrategyArrowDown(stepLogger: StepLogger) {
        await WaitHelper.staticWait(PageHelper.timeout.s);

        stepLogger.step('Click Show All save Strategy Arrow Down Button');
        await PageHelper.click(OptimizerPage.arrowDown);
    }
    static async addAvilabelFiled(stepLogger: StepLogger) {

        await this.selectAvailableFiled(stepLogger);

        await this.clickAddOption(stepLogger);

        await this.clickOkOption(stepLogger);
    }
    static  async enterStrategyName(stepLogger: StepLogger,  strategyName: string) {
        stepLogger.step('Enter strategy Name' + strategyName);
        await PageHelper.sendKeysToInputField(OptimizerPage.strategyName, strategyName );
    }

    static  async saveStrategyValidateIt(stepLogger: StepLogger , strategyName: string) {

        await this.enterStrategyName(stepLogger, strategyName);

        await this.saveNewStratedyName(stepLogger);

        await this.clickShowAllStrategyArrowDown(stepLogger);

        await expect(await ElementHelper.getText(OptimizerPage.currectstrategy))
            .toContain(strategyName, ValidationsHelper.getLabelDisplayedValidation(strategyName));
    }
    static  async optimizerPageElementCheck(stepLogger: StepLogger ) {

        stepLogger.verification('Available option is displayed');
        await CommonPageHelper.buttonDisplayedValidation(OptimizerPage.optionAvailable, OptimizerPageConstants.avaliableOption);

        stepLogger.verification('Optimizer Text is displayed');

        await CommonPageHelper.fieldDisplayedValidation(OptimizerPage.optimizerText, OptimizerPageConstants.optimizerText);

        stepLogger.verification('Total Field Drop Down is displayed');
        await CommonPageHelper.buttonDisplayedValidation(OptimizerPage.totalFieldDropDown, OptimizerPageConstants.totalFieldDropDown);

        stepLogger.verification('Budget is selected bu default  is displayed');
        await CommonPageHelper.textPresentValidation(OptimizerPage.totalFieldDropDownOption, OptimizerPageConstants.budget);

        stepLogger.verification('Total Field Drop Down is displayed');
        await CommonPageHelper.buttonDisplayedValidation(OptimizerPage.addOption, OptimizerPageConstants.menuConfigure.add);

        stepLogger.verification('Total Field Drop Down is displayed');
        await CommonPageHelper.buttonDisplayedValidation(OptimizerPage.okOption, OptimizerPageConstants.menuConfigure.ok);

    }
    static async verifyConfigrationPopUpClosed(stepLogger: StepLogger) {
        stepLogger.verification('Optimizer Configuration Popup closed');
        await CommonPageHelper.labelDisplayedValidation
        (CommonPage.pageHeaders.projects.optimizerConfiguration, CommonPageConstants.pageHeaders.projects.projectDetails, false);
      }
    static async verifyConfigrationPopUPDisplayed(stepLogger: StepLogger) {
        stepLogger.verification('Optimizer Configuration Page is  opened ');
        await CommonPageHelper.fieldDisplayedValidation
        (CommonPage.pageHeaders.projects.optimizerConfiguration,
            ValidationsHelper.getPageDisplayedValidation(CommonPageConstants.pageHeaders.projects.projectDetails));
    }
}
