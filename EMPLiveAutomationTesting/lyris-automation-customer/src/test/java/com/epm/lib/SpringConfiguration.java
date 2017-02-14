package com.epm.lib;

import org.openqa.selenium.WebDriver;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.EnableAspectJAutoProxy;
import org.springframework.context.annotation.Import;
import org.apache.commons.collections4.collection.*;

@Configuration
@Import({BrowserConfiguration.class})
@EnableAspectJAutoProxy
public class SpringConfiguration {

	/*@Bean
	public TestProperty<WebDriver> webdriver()
	{
		//return new TestProperty<WebDriver>("Webdriver",null)
	}*/
}
