package com.ipm.tests;


import org.openqa.selenium.WebDriver;
import cucumber.api.java.en.When;



public class LoginStepDefinition  {
//@Inject private TestProperty<WebDriver> driver;	
	

	protected WebDriver driver;
	
	


   public LoginStepDefinition(WebDriver driver) {
		this.driver=driver;
	}


	


	public static void login(WebDriver driver)
	{
		
		driver.get("http://farmadmin:Pass%40word1@qaepmlive6/sites/600");
	}
	
}
