import {browser, by, By, element, ElementFinder, protractor} from 'protractor';
import {WaitHelper} from './wait-helper';
import {PageHelper} from './page-helper';
import {ComponentHelpers} from '../devfactory/component-helpers/component-helpers';
import {HtmlHelper} from '../misc-utils/html-helper';

export class ElementHelper {
    private static readonly EC = protractor.ExpectedConditions;

    static async getBrowser() {
        const capabilities = await browser.getCapabilities();
        return capabilities.get('browserName');
    }

    static async actionMouseMove(item: ElementFinder) {
        await WaitHelper.getInstance().waitForElementToBeDisplayed(item);
        return browser.actions().mouseMove(item).perform();
    }

    static async actionMouseDown(item: ElementFinder) {
        await WaitHelper.getInstance().waitForElementToBeDisplayed(item);
        return browser.actions().mouseDown(item).perform();
    }

    static async actionDragAndDrop(source: ElementFinder, destination: ElementFinder) {
        return browser.actions().dragAndDrop(source, destination).perform();
    }

    static async actionDoubleClick(optElementOrButton ?: ElementFinder | string, optButton ?: string) {
        if (optElementOrButton) {
            return browser.actions().doubleClick(optElementOrButton).perform();
        }
        if (optButton) {
            return browser.actions().doubleClick(optButton).perform();
        }
    }

    static async actionClick(locator: ElementFinder) {
        return browser.actions().click(locator).perform();

    }

    static async actionHoverOver(locator: ElementFinder) {
        return browser.actions().mouseMove(locator).perform();
    }

    static async actionHoverOverAndClick(hoverOverLocator: ElementFinder, clickLocator: ElementFinder) {
        return browser.actions().mouseMove(hoverOverLocator).click(clickLocator).perform();
    }

    static async hasOption(select: ElementFinder, option: string) {
        return select
            .element(by.cssContainingText('option', option))
            .isPresent();
    }

    static async hasSelectedOption(select: ElementFinder, option: string) {
        return select.element(by.xpath(`./option[${ComponentHelpers.getXPathFunctionForDot(option)}]`)).isSelected();
    }

    static async rightClickAndSelectNewTab() {
        return browser.actions().click(protractor.Button.RIGHT).sendKeys(protractor.Key.ARROW_DOWN)
            .sendKeys(protractor.Key.ENTER).perform();
    }

    static async getFocusedElement() {
        return browser
            .driver
            .switchTo()
            .activeElement();
    }

    static async currentSelectedOptionByText(text: string) {
        const selector = `//option[@selected="selected" and normalize-space(.)="${text}"]`;
        return element(By.xpath(selector));
    }

    static async getSelectedOption(select: ElementFinder) {
        return select.element(By.css('option[selected]'));
    }

    static async isVisible(locator: ElementFinder) {
        return this.EC.visibilityOf(locator);
    }

    static async isNotVisible(locator: ElementFinder) {
        return this.EC.invisibilityOf(locator);
    }

    static async inDom(locator: ElementFinder) {
        return this.EC.presenceOf(locator);
    }

    static async notInDom(locator: ElementFinder) {
        return this.EC.stalenessOf(locator);
    }

    static async isClickable(locator: ElementFinder) {
        return this.EC.elementToBeClickable(locator);
    }

    static async hasText(locator: ElementFinder, text: string) {
        return this.EC.textToBePresentInElement(locator, text);
    }

    static async titleIs(title: string) {
        return this.EC.titleIs(title);
    }

    static async hasClass(locator: ElementFinder, klass: string) {
        const classes = await locator.getAttribute('class');
        return classes && classes.split(' ').indexOf(klass) !== -1;
    }

    static async getValue(locator: ElementFinder) {
        return PageHelper.getAttributeValue(locator, HtmlHelper.attributes.value);
    }

    static async hasClassRegex(locator: ElementFinder, klass: string) {
        const classAttribute = await locator.getAttribute('class');
        const pattern = new RegExp('(^|\\s)' + klass + '(\\s|$)');
        return pattern.test(classAttribute);
    }

    static async click(targetElement: ElementFinder) {
        await WaitHelper.getInstance().waitForElementToBeClickable(targetElement);
        return targetElement.click();
    }

    static async clickIfPresent(targetElement: ElementFinder) {
        const isPresent = await targetElement.isPresent();
        if (isPresent) {
            return this.click(targetElement);
        }
        return;
    }

    static async clickUsingJs(targetElement: ElementFinder) {
        await WaitHelper.getInstance().waitForElementToBeClickable(targetElement);
        return this.clickUsingJsNoWait(targetElement);
    }

    static async clickUsingJsNoWait(targetElement: ElementFinder) {
        return browser.executeScript('arguments[0].click();', targetElement);
    }

    static async waitForElementToHaveClass(targetElement: ElementFinder,
                                           kClass: string,
                                           timeout = PageHelper.DEFAULT_TIMEOUT,
                                           message = '') {
        return WaitHelper.getInstance().waitForElementToResolve(
            () => this.hasClass(targetElement, kClass),
            (result: any) => result, timeout, message);
    }

    static async selectDropDownByIndex(elementt: ElementFinder, optionNum: number) {
        if (optionNum) {
            const options = await elementt.findElements(by.tagName('option'));
            options[optionNum].click();
        }
    }

    static async scrollToElement(elementt: ElementFinder) {
        browser.executeScript('arguments[0].scrollIntoView();', elementt);
    }

    static async scrollToBottomOfPage() {
        browser.executeScript('window.scrollTo(0, document.body.scrollHeight)');
    }

    static async getAttributeValue(elem: ElementFinder, attribute: string) {
        await WaitHelper.getInstance().waitForElementToBeDisplayed(elem);
        try {
            const value = await elem.getAttribute(attribute);
            return value.trim();
        } catch (e) { return '' ; }
    }
    static async getText(elem: ElementFinder) {
        await WaitHelper.getInstance().waitForElementToBePresent(elem);
        const text = await elem.getText();
        return text.trim();
    }

    static getElementByStartsWithId(id: string, endsWith = 'Main') {
        return element(By.css(`[id^='${id}'][id$='${endsWith}']`));
    }

    static getElementByText(text: string, isContains = false) {
        return element(By.xpath(`//*[${ComponentHelpers.getXPathFunctionForText(text, isContains)}]`));
    }

    static browserRefresh() {
        browser.refresh();
    }
}
