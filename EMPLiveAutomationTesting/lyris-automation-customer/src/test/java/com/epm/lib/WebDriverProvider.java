package com.epm.lib;


import java.io.IOException;
import java.util.Map;
import java.util.concurrent.ConcurrentSkipListMap;

import javax.inject.Inject;
import javax.inject.Named;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.remote.RemoteWebDriver;

import com.epm.data.Browser;

@Named
public class WebDriverProvider {

	@Inject private RemoteWebDriver remotewebdriver;
	@Inject private LocalWebDriverProvider localWebDriverProvider; 
	private static Map<Browser, SharedWebDriver> webdrivermap=new ConcurrentSkipListMap<Browser, SharedWebDriver>();
public synchronized WebDriver getWebDriver(final Browser browser){
	if(webdrivermap.containsKey(browser)){
		return webdrivermap.get(browser);
	}
	else {
		try{
			WebDriver webdriver=createWebDriver(browser);
			if (webdriver instanceof SharedWebDriver){
				webdrivermap.put(browser, (SharedWebDriver)webdriver);
		}
			return webdriver;
		}
		catch (IOException e) {
			throw new RuntimeException("Unabe to Create Browser"+browser,e);
	}
	}
}

private WebDriver createWebDriver(final Browser browser) throws IOException
{
	WebDriver  webdriver;
	switch(browser.getWebDriverType()){
	case FireFoxDriver:
		webdriver= localWebDriverProvider.getFirefoxDriver(browser);
		break;
	case  ChromeDriver:
		webdriver= localWebDriverProvider.getChromeDriver();
		break;
	default :
		throw new UnsupportedOperationException("Unknown Browser Type"+browser);
	
	}		
		return new SharedWebDriver(webdriver);
	}
	


}
