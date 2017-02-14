package com.ipm.lib;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Scope;

import java.util.HashMap;
import java.util.Map;
import java.util.concurrent.TimeUnit;


@Configuration
@ComponentScan("com.ipm")
public class AbstractCoreTest {

    public static WebDriverWait wait;
    public static String path;
    private static WebDriver commonDriver;

    @Bean
    @Scope("prototype")
    public WebDriver driver() {
        //Chrome
        Map<String, Object> prefs = new HashMap<>();
        System.setProperty("webdriver.chrome.driver", System.getProperty("user.dir") + "\\src\\test\\resources\\uploads\\chromedriver.exe");
        prefs.put("download.default_directory", System.getProperty("user.dir"));
        DesiredCapabilities caps = DesiredCapabilities.chrome();
        ChromeOptions options = new ChromeOptions();
        options.addArguments("--no-sandbox");
        options.addArguments("--allow-running-insecure-content");
        options.setExperimentalOption("prefs", prefs);
        caps.setCapability(ChromeOptions.CAPABILITY, options);
        commonDriver = new ChromeDriver(caps);
        commonDriver.manage().timeouts().implicitlyWait(60, TimeUnit.SECONDS);
        return commonDriver;
    }

	/*@Bean
    public Properties testProps() {
		return PropertiesLoader.getInstance().load("test.properties");
	}*/


}