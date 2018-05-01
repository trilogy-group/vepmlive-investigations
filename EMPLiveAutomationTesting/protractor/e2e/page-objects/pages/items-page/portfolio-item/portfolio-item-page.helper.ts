import {TextboxHelper} from '../../../../components/html/textbox-helper';
import {PageHelper} from '../../../../components/html/page-helper';
import {PortfolioItemPage} from './portfolio-item.po';
import {StepLogger} from '../../../../../core/logger/step-logger';
import {ValidationsHelper} from '../../../../components/misc-utils/validation-helper';
import {CommonItemPage} from '../common-item/common-item.po';
import {PortfolioItemPageConstants} from './portfolio-item-page.constants';
import {ElementHelper} from '../../../../components/html/element-helper';

export class PortfolioItemPageHelper {
    static async fillForm(portfolioNameValue: string,
                          portfolioDescriptionValue: string,
                          portfolioTypeValue: string,
                          stateValue: string,
                          stepLogger: StepLogger) {
        const labels = PortfolioItemPageConstants.inputLabels;

        stepLogger.step('Portfolio Name *: Enter a Name for Portfolio [Ex: Smoke_Test_Portfolio1]');
        await TextboxHelper.sendKeys(PortfolioItemPage.inputs.portfolioName, portfolioNameValue);

        stepLogger.verification('Required values entered/selected in portfolioName Field');
        await expect(await TextboxHelper.hasValue(PortfolioItemPage.inputs.portfolioName, portfolioNameValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.portfolioName, portfolioNameValue));

        stepLogger.step('Portfolio Description: Enter a Description for the portfolio [Ex: This is Test ');
        await TextboxHelper.sendKeys(PortfolioItemPage.inputs.portfolioDescription, portfolioDescriptionValue);

        stepLogger.verification('Required values entered/selected in portfolioDescription Field');
        await expect(await TextboxHelper.hasValue(PortfolioItemPage.inputs.portfolioDescription, portfolioDescriptionValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.portfolioDescription, portfolioDescriptionValue));

        stepLogger.step('Portfolio Type: Select a value from the drop down [Ex: Customer]');
        await PageHelper.sendKeysToInputField(PortfolioItemPage.inputs.portfolioType, portfolioTypeValue);

        stepLogger.verification('Required values entered/selected in portfolioType Field');
        await expect(await ElementHelper.hasSelectedOption(PortfolioItemPage.inputs.portfolioType, portfolioTypeValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.portfolioType, portfolioTypeValue));

        stepLogger.step('Portfolio Type: Select a value from the drop down [Ex: Customer]');
        await PageHelper.sendKeysToInputField(PortfolioItemPage.inputs.state, stateValue);

        stepLogger.verification('Required values entered/selected in portfolioType Field');
        await expect(await ElementHelper.hasSelectedOption(PortfolioItemPage.inputs.state, stateValue))
            .toBe(true,
                ValidationsHelper.getFieldShouldHaveValueValidation(labels.state, stateValue));

        stepLogger.stepId(4);
        stepLogger.step('Click on "Save" button in "Portfolios - New Item" window');
        await PageHelper.click(CommonItemPage.formButtons.save);

        stepLogger.verification('"Portfolios - New Item" window is closed');
        await expect(await CommonItemPage.dialogTitles.isPresent())
            .toBe(false,
                ValidationsHelper.getWindowShouldNotBeDisplayedValidation(PortfolioItemPageConstants.pageName));
    }
}
