package com.epm.lib;

import javax.inject.Named;

import org.apache.commons.lang3.StringUtils;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.firefox.FirefoxBinary;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.firefox.FirefoxProfile;

import com.epm.data.Browser;
import com.thoughtworks.selenium.webdriven.WebDriverBackedSelenium;

@Named
public class LocalWebDriverProvider {

	public WebDriver getFirefoxDriver(final Browser browser)
	{
		FirefoxProfile profile= new FirefoxProfile();
		if(StringUtils.isNotBlank(browser.getCustomUserAgent())){
			profile.setPreference("general user agent override", browser.getCustomUserAgent());
		}
		FirefoxBinary bin= new FirefoxBinary();
		
		return new FirefoxDriver(bin,profile,browser.getDesiredCapabilities());
	}
	public WebDriver getChromeDriver()
	{
		return new ChromeDriver();
		
	}
}
