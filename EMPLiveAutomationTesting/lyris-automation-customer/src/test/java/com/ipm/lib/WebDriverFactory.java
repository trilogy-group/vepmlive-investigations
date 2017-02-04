package com.ipm.lib;

import java.util.Map;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.firefox.FirefoxProfile;
import org.openqa.selenium.ie.InternetExplorerDriver;
import org.openqa.selenium.remote.DesiredCapabilities;


	
public class WebDriverFactory {
	
	private WebDriverFactory() {}

	public static WebDriver create(final WebDriverType.fireFox type) {
		WebDriver driver = null;
		
		if(WebDriverType.fireFox.FIREFOX.equals(type)) {
			
				driver = new FirefoxDriver();
			}
		
		else {
			throw new ScumberException(String.format("WebDriver [%s] is invalid", type));
		}
		
		return driver;
	}
	
	public static WebDriver create(final WebDriverType.ie type) {
		WebDriver driver = null;
		System.setProperty("webdriver.ie.driver",System.getProperty("user.dir") + "\\src\\test\\resources\\uploads\\IEDriverServer.exe");
		
		DesiredCapabilities capabilitiesIE = DesiredCapabilities.internetExplorer();
		capabilitiesIE.setCapability(
		    InternetExplorerDriver.INTRODUCE_FLAKINESS_BY_IGNORING_SECURITY_DOMAINS, true);
		 driver = new InternetExplorerDriver(capabilitiesIE);
		
		return driver;
	}
	
	public static WebDriver create(final WebDriverType.chrome type) {
		ChromeDriver driver = null;
				
				System.setProperty("webdriver.chrome.driver",System.getProperty("user.dir") + "\\src\\test\\resources\\uploads\\chromedriver.exe");
				
				 driver = new ChromeDriver();
		
		
		
		
		return driver;
	}
}
