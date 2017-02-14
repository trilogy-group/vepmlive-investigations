package com.ipm.lib;

import org.openqa.selenium.StaleElementReferenceException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;


public abstract class AbstractPage implements ScreenDriver<WebDriver> {

	protected WebDriver driver;

	public AbstractPage(final WebDriver driver) throws InterruptedException {
		this.driver = driver;
		PageFactory.initElements(driver, this);
		initializeDriver();
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * com.aurea.test.scumber.selenium.pages.ScreenDriver#initializeDriver()
	 */
	@Override
	public abstract void initializeDriver();

	/*
	 * (non-Javadoc)
	 * 
	 * @see com.aurea.test.scumber.selenium.pages.ScreenDriver#checkSanity()
	 */
	@Override
	public abstract void checkSanity();

	/*
	 * (non-Javadoc)
	 * 
	 * @see com.aurea.test.scumber.selenium.pages.ScreenDriver#open()
	 */
	@Override
	public abstract void open();

	/*
	 * (non-Javadoc)
	 * 
	 * @see com.aurea.test.scumber.selenium.pages.ScreenDriver#close()
	 */
	@Override
	public abstract void close();

	public void wait(int time, WebElement element) {
		WebDriverWait wait = new WebDriverWait(driver, time);
		wait.ignoring(StaleElementReferenceException.class).until(ExpectedConditions.elementToBeClickable(element));
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see com.aurea.test.scumber.selenium.pages.ScreenDriver#wait(int)
	 */
	@Override
	public void wait(int time) {
		wait(time, getDefaultWaitElement());
	}

	protected abstract WebElement getDefaultWaitElement();

	/*
	 * (non-Javadoc)
	 * 
	 * @see com.aurea.test.scumber.selenium.pages.ScreenDriver#getDriver()
	 */
	@Override
	public WebDriver getDriver() {
		return driver;
	}

}
