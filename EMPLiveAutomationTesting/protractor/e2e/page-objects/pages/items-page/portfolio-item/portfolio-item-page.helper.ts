import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {PortfolioItemPage} from './portfolio-item.po';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {PortfolioItemPageConstants} from './portfolio-item-page.constants';
import {ElementHelper} from '../../../../components/html/element-helper';
import {CommonPage} from '../../common/common.po';

export class PortfolioItemPageHelper {
    static async fillForm(portfolioNameValue: string,
                          portfolioDescriptionValue: string,
                          portfolioTypeValue: string,
                          stateValue: string,
    ) {
        const labels = PortfolioItemPageConstants.inputLabels;

        StepLogger.step('Portfolio Name *: Enter a Name for Portfolio [Ex: Smoke_Test_Portfolio1]');
        await TextboxHelper.sendKeys(PortfolioItemPage.inputs.portfolioName, portfolioNameValue);

        StepLogger.verification('Required values entered/selected in portfolioName Field');
        await expect(await TextboxHelper.hasValue(PortfolioItemPage.inputs.portfolioName, portfolioNameValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.portfolioName, portfolioNameValue));

        StepLogger.step('Portfolio Description: Enter a Description for the portfolio [Ex: This is Test ');
        await TextboxHelper.sendKeys(PortfolioItemPage.inputs.portfolioDescription, portfolioDescriptionValue);

        StepLogger.verification('Required values entered/selected in portfolioDescription Field');
        await expect(await TextboxHelper.hasValue(PortfolioItemPage.inputs.portfolioDescription, portfolioDescriptionValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.portfolioDescription, portfolioDescriptionValue));

        StepLogger.step('Portfolio Type: Select a value from the drop down [Ex: Customer]');
        await PageHelper.sendKeysToInputField(PortfolioItemPage.inputs.portfolioType, portfolioTypeValue);
        await PageHelper.enterPressForBrowser();

        StepLogger.verification('Required values entered/selected in portfolioType Field');
        await expect(await ElementHelper.hasSelectedOption(PortfolioItemPage.inputs.portfolioType, portfolioTypeValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.portfolioType, portfolioTypeValue));

        StepLogger.step('Portfolio Type: Select a value from the drop down [Ex: Customer]');
        await PageHelper.sendKeysToInputField(PortfolioItemPage.inputs.state, stateValue);
        await PageHelper.enterPressForBrowser();

        StepLogger.verification('Required values entered/selected in portfolioType Field');
        await expect(await ElementHelper.hasSelectedOption(PortfolioItemPage.inputs.state, stateValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.state, stateValue));

        StepLogger.stepId(4);
        StepLogger.step('Click on "Save" button in "Portfolios - New Item" window');
        await PageHelper.click(CommonPage.formButtons.save);

        StepLogger.verification('"Portfolios - New Item" window is closed');
        await expect(await CommonPage.dialogTitle.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(PortfolioItemPageConstants.pageName));
    }
}
