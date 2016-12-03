package com.epm.lib;

import java.util.List;
import java.util.Set;

import org.openqa.selenium.By;
import org.openqa.selenium.OutputType;
import org.openqa.selenium.TakesScreenshot;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebDriverException;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.remote.UnreachableBrowserException;

public class SharedWebDriver implements WebDriver, TakesScreenshot {

	private WebDriver backingWebDriver;

	private final Thread closeThread = new Thread() {

		@Override
		public void run() {
			try {
				backingWebDriver.quit();
			} catch (UnreachableBrowserException e) {
				System.out.println("unable to close webdriver" + e);
			}
		}
	};

	public SharedWebDriver(final WebDriver webdriver) {
		backingWebDriver = webdriver;
		Runtime.getRuntime().addShutdownHook(closeThread);
	}

	@Override
	public <X> X getScreenshotAs(OutputType<X> arg0) throws WebDriverException {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void close() {
      this.close();
	}

	@Override
	public WebElement findElement(By arg0) {
		
		return backingWebDriver.findElement(arg0);
	}

	@Override
	public List<WebElement> findElements(By arg0) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void get(String arg0) {
backingWebDriver.get(arg0);
	}

	@Override
	public String getCurrentUrl() {
		
		return backingWebDriver.getCurrentUrl();
	}

	@Override
	public String getPageSource() {
		return backingWebDriver.getPageSource();
	}

	@Override
	public String getTitle() {
		return backingWebDriver.getTitle();
	}

	@Override
	public String getWindowHandle() {
		
		return backingWebDriver.getWindowHandle();
	}

	@Override
	public Set<String> getWindowHandles() {
		return backingWebDriver.getWindowHandles();
	}

	@Override
	public Options manage() {
		return backingWebDriver.manage();
	}

	@Override
	public Navigation navigate() {
		return backingWebDriver.navigate();
	}

	@Override
	public void quit() {
backingWebDriver.quit();
	}

	@Override
	public TargetLocator switchTo() {
		return backingWebDriver.switchTo();
	}

}
