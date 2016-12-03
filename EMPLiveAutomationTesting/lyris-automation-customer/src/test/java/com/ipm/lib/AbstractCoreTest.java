package com.ipm.lib;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.WebDriverWait;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Scope;



@Configuration
@ComponentScan("com.ipm")
public class AbstractCoreTest {

	public static WebDriverWait wait;
	public static String path;

	@Bean
	@Scope("prototype")
	public WebDriver driver() {
		//Chrome
				System.setProperty("webdriver.chrome.driver", System.getProperty("user.dir") + "\\src\\test\\resources\\uploads\\chromedriver.exe");
				return new ChromeDriver();
	}

	/*@Bean
	public Properties testProps() {
		return PropertiesLoader.getInstance().load("test.properties");
	}*/
	
	



}
