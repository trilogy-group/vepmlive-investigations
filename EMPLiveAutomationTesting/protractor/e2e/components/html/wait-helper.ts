import {PageHelper} from './page-helper';
import {browser, ElementFinder, protractor} from 'protractor';

export class WaitHelper {
    private static instance: WaitHelper;
    private readonly EC = protractor.ExpectedConditions;

    private constructor() {
    }

    static getInstance() {
        if (!WaitHelper.instance) {
            WaitHelper.instance = new WaitHelper();
        }
        return WaitHelper.instance;
    }

    /**
     * Default timeout for promises
     * @type {number}
     */
    /**
     * Wait for an element to exist
     * @param {ElementFinder} targetElement
     * @param {number} timeout
     * @param {string} message
     */
    async waitForElement(targetElement: ElementFinder,
                         timeout = PageHelper.DEFAULT_TIMEOUT,
                         message = 'Element should exist') {
        return browser.wait(this.EC.presenceOf(targetElement),
            timeout,
            targetElement.locator().toString() + message);
    }

    /**
     * Wait for an element to display
     * @param {ElementFinder} targetElement
     * @param {number} timeout
     * @param {string} message
     */
    async waitForElementToBeDisplayed(targetElement: ElementFinder,
                                      timeout = PageHelper.DEFAULT_TIMEOUT,
                                      message = 'Element should be visible') {
        return browser.wait(this.EC.visibilityOf(targetElement),
            timeout,
            targetElement.locator().toString() + message)
            .then(() => true, () => false);
    }

    /**
     * Wait for an element to present
     * @param {ElementFinder} targetElement
     * @param {number} timeout
     * @param {string} message
     */
    async waitForElementToBePresent(targetElement: ElementFinder,
                                    timeout = PageHelper.DEFAULT_TIMEOUT,
                                    message = 'Element should be visible') {
        return browser.wait(this.EC.presenceOf(targetElement),
            timeout,
            targetElement.locator().toString() + message)
            .then(() => true, () => false);
    }

    /**
     * Wait for an element to hide
     * @param {ElementFinder} targetElement
     * @param {number} timeout
     * @param {string} message
     * @returns {any}
     */
    async waitForElementToBeHidden(targetElement: ElementFinder,
                                   timeout = PageHelper.DEFAULT_TIMEOUT,
                                   message = 'Element should not be visible') {
        return browser.wait(this.EC.invisibilityOf(targetElement),
            timeout,
            targetElement.locator().toString() + message);
    }

    /**
     * Wait for an element to become clickable
     * @param {ElementFinder} targetElement
     * @param {number} timeout
     * @param {string} message
     */
    async waitForElementToBeClickable(targetElement: ElementFinder,
                                      timeout = PageHelper.DEFAULT_TIMEOUT,
                                      message = 'Element not clickable') {
        return browser.wait(this.EC.elementToBeClickable(targetElement),
            timeout,
            targetElement.locator().toString() + message);
    }

    async waitForElementToResolve(promiseCall: Function,
                                  resolver: Function,
                                  timeout = PageHelper.DEFAULT_TIMEOUT,
                                  message = '') {
        let result = false;
        return browser.wait(() => {
            promiseCall().then((value: any) => (result = resolver(value)));
            return result;
        }, timeout, message);
    }

    async waitForElementToHaveText(targetElement: ElementFinder, timeout = PageHelper.DEFAULT_TIMEOUT, message = '') {
        return this.waitForElementToResolve(() => targetElement.getText(), (text: string) => text.length > 0, timeout, message);
    }

    async waitForElementOptionallyPresent(targetElement: ElementFinder, timeout = PageHelper.DEFAULT_TIMEOUT) {
        const isDisplayed = this.EC.presenceOf(targetElement);
        return browser.wait(isDisplayed, timeout).then(function () {
            return true;
        }, function () {
            return false;
        });
    }
}
