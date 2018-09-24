/**
 * Page helper for general utility
 */
import {browser, ElementArrayFinder, ElementFinder, protractor, WebElement} from 'protractor';
import {WaitHelper} from './wait-helper';
import {JsHelper} from '../misc-utils/js-helper';
import {ElementHelper} from './element-helper';

const shortId = require('shortid');
const remote = require('selenium-webdriver/remote');

export class PageHelper {
    static MAX_RETRY_ATTEMPTS = 3;
    // noinspection JSValidateJSDoc
    /**
     * Timeout collection to meet various needs
     * @type {{xs: number; s: number; m: number; l: number; xl: number; xxl: number; xxxl: number}}
     */
    static timeout = {
        xxs: 1000,
        xs: 2000,
        s: 5000,
        m: 10000,
        l: 25000,
        xl: 50000,
        xxl: 75000,
        xxxl: 200000,
        xxxxl: 500000,
    };
    static DEFAULT_TIMEOUT = PageHelper.timeout.xxl;
    private static readonly EC = protractor.ExpectedConditions;

    static get isFullScreen() {
        const fullScreenScript = 'if (!window.screenTop && !window.screenY){return true;}'
            + 'else{return false;}';
        return browser.executeScript(fullScreenScript);
    }

    static actionKeyDown(key: string) {
        return browser.actions().keyDown(key).perform();
    }

    static actionSendKeys(key: string) {
        return browser.actions().sendKeys(key).perform();
    }

    static async sendKeysToInputField(elem: ElementFinder, key: string) {
        // send keys in not working in perticular fields, Its required actions classes.
        await WaitHelper.waitForElementToBeDisplayed(elem);
        await elem.click();
        await browser.actions().sendKeys(key).perform();
    }

    static actionKeyUp(key: string) {
        return browser.actions().keyUp(key).perform();
    }

    static keyPressForBrowser(key: string) {
        return browser.actions().sendKeys(key).perform();
    }

    static enterPressForBrowser() {
        return browser.actions().sendKeys(protractor.Key.ENTER).perform();
    }

    static actionMouseUp(location: WebElement) {
        return browser.actions().mouseUp(location).perform();
    }

    // Known issue for chrome, direct maximize window doesn't work
    /**
     * To maximize the browser window
     */
    static async maximizeWindow() {
        return this.resizeWindow();
    }

    static async resizeHorizontally(height: number) {
        return this.resizeWindow(-1, height);
    }

    static async resizeVertically(width: number) {
        return this.resizeWindow(width);
    }

    /**
     * To resize the browser window
     */
    static async resizeWindow(width = -1, height = -1) {
        class Size {
            width: number;
            height: number;
        }

        const windowSize = await this.executeScript(function () {
            return {
                width: window.screen.availWidth,
                height: window.screen.availHeight,
            };
        });

        const result = windowSize as Size;
        if (width !== -1) {
            result.width = width;
        }

        if (height !== -1) {
            result.height = height;
        }

        return this.setWindowSize(result.width, result.height);
    }

    /**
     * Sets window size
     * @param {number} width
     * @param {number} height
     */
    static async setWindowSize(width: number, height: number) {
        return browser.driver
            .manage()
            .window()
            .setSize(width, height);
    }

    /**
     * Wrapper for executing javascript code
     * @param {string | Function} script
     * @param varAargs
     * @returns {promise.Promise<any>}
     */
    static async executeScript(script: string | Function, ...varAargs: any[]) {
        return browser.driver.executeScript(script, varAargs);
    }

    /**
     * Wrapper to return an active element
     * @returns {WebElementPromise}

     static async getFocusedElement() {
    return browser.driver.switchTo().activeElement()
  } */

    /**
     * Switch to a new tab if browser has availability
     * @returns {PromiseLike<boolean> | Promise<boolean> | Q.Promise<any> | promise.Promise<any> | Q.IPromise<any>}
     */
    static async switchToNewTabIfAvailable(windowNumber = 1) {
        const handles = await browser.getAllWindowHandles();
        const newWindowHandle = handles[windowNumber]; // this is your new window
        if (newWindowHandle) {
            await browser.switchTo().window(newWindowHandle);
        }
        const url = await browser.getCurrentUrl();

        // Avoiding bootstraping issue, Known issue
        // Error: Error while waiting for Protractor to sync with the page:
        // "window.angular is undefined. This could be either because this is a non-angular page or
        // because your test involves client-side navigation, which can interfere with Protractor's bootstrapping.
        // See http://git.io/v4gXM for details
        return browser.driver.get(url);
    }

    public static async switchToFirstTab() {
        const handles = await browser.getAllWindowHandles();
        await browser.driver.close();
        await browser.switchTo().window(handles[0]);
    }

    /**
     * Gets html attribute value
     * @param {WebElementPromise} elem
     * @param {string} attribute
     * @returns {string} attribute value
     */
    static async getAttributeValue(elem: ElementFinder, attribute: string) {
        await WaitHelper.waitForElementToBeDisplayed(elem);
        const attributeValue = await elem.getAttribute(attribute);
        return attributeValue.trim();
    }

    /**
     * Click on element
     * @param {ElementFinder} targetElement
     * @returns {any}
     */
    static async click(targetElement: ElementFinder) {
        await WaitHelper.waitForElementToBePresent(targetElement);
        await ElementHelper.clickUsingJs(targetElement);
    }

    static async clickIfPresent(targetElement: ElementFinder) {
        const isPresent = await targetElement.isPresent();
        if (isPresent) {
            return this.click(targetElement);
        }
        return;
    }

    /**
     * Click on the element and wait for it to get hidden
     * @param {ElementFinder} targetElement
     * @returns {PromiseLike<boolean> | Promise<boolean> | Q.Promise<any> | promise.Promise<any> | Q.IPromise<any>}
     */
    static async clickAndWaitForElementToHide(targetElement: ElementFinder) {
        await WaitHelper.waitForElementToBeClickable(targetElement);
        await targetElement.click();
        return WaitHelper.waitForElementToBeHidden(targetElement);
    }

    /**
     * Click on element if displayed
     * @param {ElementFinder} targetElement
     * @param withoutJs
     * @returns {any}
     */
    public static async clickIfDisplayed(targetElement: ElementFinder, withoutJs = true) {
        const isPresent = await targetElement.isPresent();
        if (isPresent === true) {
            const isDisplayed = await targetElement.isDisplayed();
            if (isDisplayed === true) {
                if (withoutJs) {
                    await PageHelper.click(targetElement);
                } else {
                    await ElementHelper.clickUsingJs(targetElement);
                }
            }
        }
    }

    /**
     * Gets promise for current url
     * @returns {any}
     */
    static async currentUrl() {
        return browser.getCurrentUrl();
    }

    static async getPageTitle() {
        return await browser.getTitle();
    }

    /**
     * Refresh a page
     *
     */
    public static async refreshPage() {
        await browser.refresh();
    }

    static async switchToFrame(frameEle: WebElement) {
        return browser.driver.switchTo().frame(frameEle);
    }

    /**
     * Verify whether element is hidden on page or not
     * @param {ElementFinder} targetElement
     * @param toWait
     * @param {boolean} toWait
     * @returns {Promise<any>}
     */
    static async isElementHidden(targetElement: ElementFinder, toWait = true) {
        if (toWait) {
            return browser.wait(async () =>
                !(await targetElement.isPresent()) || !(await targetElement.isDisplayed()),
            ).then(() => true).catch(() => false);
        }
        return !(await targetElement.isPresent()) || !(await targetElement.isDisplayed());
    }

    /**
     * Verify whether element is displayed on page or not
     * @param {ElementFinder} targetElement
     * @param toWait
     * @param {boolean} toWait
     * @returns {Promise<any>}
     */
    static async isElementDisplayed(targetElement: ElementFinder, toWait = true) {
        if (toWait) {
            await WaitHelper.waitForElementToBeDisplayed(targetElement);
        }
        return await targetElement.isDisplayed();
    }

    static async isEnable(targetElement: ElementFinder) {
        await WaitHelper.waitForElementToBeDisplayed(targetElement);
        return targetElement.isEnabled();
    }

    static async isElementPresent(targetElement: ElementFinder, toWait = true) {
        if (toWait) {
            await WaitHelper.waitForElementToBePresent(targetElement);
        }
        return await targetElement.isPresent();
    }

    public static async isElementEnabled(targetElement: ElementFinder, toWait = true) {
        if (toWait) {
            await WaitHelper.waitForElementToBeDisplayed(targetElement);
        }
        return await targetElement.isEnabled();
    }

    public static async isElementSelected(targetElement: ElementFinder, toWait = true) {
        if (toWait) {
            await WaitHelper.waitForElementToBeDisplayed(targetElement);
        }
        return await targetElement.isSelected();
    }

    static isListSorted(sourceList: any[], isAscending: boolean) {
        let isSorted = true;
        const sortList = Object.assign([], sourceList);
        sortList.sort((a, b) => (((a < b) === isAscending) ? -1 : 1));
        for (let i = 0; i < sourceList.length; i++) {
            if (sourceList[i] !== sortList[i]) {
                isSorted = false;
                break;
            }
        }
        return isSorted;
    }

    /**
     * Gets innertext for all the elements
     * @param {WebElementPromise} elements
     * @returns {string} inner text
     */
    public static async getAllTexts(elements: ElementArrayFinder): Promise<string[]> {
        const allTexts = [];
        const allItems = await elements.asElementFinders_();
        for (const elem of allItems) {
            const elementText = await this.getText(elem);
            allTexts.push(elementText);
        }
        return allTexts;
    }

    static async getText(elem: ElementFinder) {
        await WaitHelper.waitForElementToBePresent(elem);
        await browser.wait(async () => (await elem.getText()).trim() !== '').catch(() => false);
        const text = await elem.getText();
        return text.trim();
    }

    public static async getAllTextsInArray(elements: ElementArrayFinder) {
        const allTexts: any = await PageHelper.getAllTexts(elements);
        return JsHelper.cleanArray(allTexts);
    }

    static async switchToiFrame(frameOrIframeElement: ElementFinder, sleepTime = PageHelper.timeout.xs) {
        await browser.waitForAngularEnabled(false);
        await WaitHelper.waitForElementToBeDisplayed(frameOrIframeElement);
        // Wait is needed to load the iframe properly
        await browser.sleep(sleepTime);
        return await browser.switchTo().frame(frameOrIframeElement.getWebElement());
    }

    static async switchToDefaultContent() {
        await browser.switchTo().defaultContent();
        await browser.waitForAngularEnabled(true);
    }

    static async acceptAlert() {
        return await browser.switchTo().alert().accept();
    }

    static async dismissAlert() {
        return await browser.switchTo().alert().dismiss();
    }

    static async closeAlertIfPresent() {
        try {
            await browser.sleep(PageHelper.timeout.xs);
            await browser.switchTo().alert().accept().then(null, function () {
                browser.sleep(PageHelper.timeout.xs);
            });
        } catch (e) {
        }
    }

    static getUniqueId(): string {
        // noinspection reason: Giving error for unknown character function
        // noinspection Annotator
        shortId.characters('0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-_');
        return shortId.generate().replace(/-/g, '').replace(/_/g, '');
    }

    static getUniqueIdForCategory(length: number) {
        return Math.random().toString(36).substr(2, length);
    }

    static getUniqueIdWithAlphabetsOnly() {
        return this.getUniqueId().replace(/[0-9]/g, '');
    }

    static getUniqueIntId(size = 6): string {
        // noinspection reason: Giving error for unknown character function
        // noinspection Annotator
        return Math.floor(Math.pow(10, size - 1) + Math.random() * 9 * Math.pow(10, size - 1)).toString();
    }

    static async uploadFile(item: ElementFinder, filePath: string) {
        browser.setFileDetector(new remote.FileDetector());
        await WaitHelper.waitForElementToBePresent(item);
        await item.sendKeys(filePath);
    }

    public static async getAlertText() {
        return await browser.switchTo().alert().getText();
    }

    /**
     * Wait for an alert to appear
     * @param {number} timeout in milliseconds
     * @param {string} message
     */
    public static async waitForAlertToBePresent(timeout: number = PageHelper.DEFAULT_TIMEOUT, message: string = 'Alert is not present') {
        return await browser.wait(this.EC.alertIsPresent(), timeout, message);
    }

    public static async sleepForXSec(milliseconds: number) {
        await browser.sleep(milliseconds);
    }

    static async randomString(size: number) {
        let text = '';
        const possible = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';

        for (let i = 0; i < size; i++) {
            text += possible.charAt(Math.floor(Math.random() * possible.length));
        }
        return text;
    }

    public static numberFromString(text: string) {
        return Number(text.replace(/\D+/g, ''));
    }

    /**
     * Gets innertext for all the elements
     * @param {WebElementPromise} elements
     * @returns {string} inner text
     */
    public static async getAllTextsInLowerCase(elements: ElementArrayFinder): Promise<string[]> {
        const allTexts = [];
        const allItems = await elements.asElementFinders_();
        for (const elem of allItems) {
            const elementText = await this.getText(elem);
            allTexts.push(elementText.toLowerCase());
        }
        return allTexts;
    }

    static async replaceSpaceWithMinus(text: string) {
        return text.replace(/\s+/g, '-');
    }

    /**
     * Gets CSS attribute value
     * @param {WebElementPromise} elem
     * @param {string} attribute
     * @returns {string} attribute value
     */
    static async getCssValue(elem: ElementFinder, attribute: string) {
        await WaitHelper.waitForElementToBeDisplayed(elem);
        const attributeValue = await elem.getCssValue(attribute);
        return attributeValue.trim();
    }

    static async sendKeysToInputFieldAndEnter(elem: ElementFinder, key: string) {
        await this.sendKeysToInputField(elem, key);
        await this.enterPressForBrowser();
    }

    static async clickAndEnter(elem: ElementFinder) {
        await this.click(elem);
        await this.enterPressForBrowser();
    }

    static async isAlertPresent() {
        return await browser.wait(this.EC.alertIsPresent(), 1000).then(() => true).catch(() => false);
    }
}
