package com.ipm.tests;

import java.io.IOException;
import java.util.Properties;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.WebDriver;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;

import com.ipm.lib.AbstractCoreTest;
import com.ipm.pageobjects.LoginPageObject;

import cucumber.api.Scenario;
import cucumber.api.java.After;
import cucumber.api.java.en.And;
import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;

@ContextConfiguration(classes = { AbstractCoreTest.class })
public class IpmStepDefination {

	LoginPageObject objLogin;
	String siteurl;
	String siteusername;
	String sitepassword;
	AbstractCoreTest objCore;
	

	public String list_name;

	@Autowired
	protected WebDriver driver;
	
	@Autowired
	protected Properties testProps;


	@Given("^user navigates to URL : \"([^\"]*)\" application$")
	public void I_open_lhq(String ipmURL) throws IOException, InterruptedException {
		
		objLogin = new LoginPageObject(driver);

		// Set implicit wait of 10 seconds and maximize window
		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
		driver.manage().window().maximize();
		siteurl = ipmURL;
		System.out.println(ipmURL);
		driver.get(ipmURL);
	}
	
	@When("^I enter \"([^\"]*)\" and \"([^\"]*)\" in login panel$")
	public void enterLoginCredentials(String username, String password) throws IOException, InterruptedException {
		
		objLogin.enterTheLoginCredentials(username,password);
	} 
	
	@And("^I click login button$")
	public void clickLoginButton() throws IOException, InterruptedException {
		
		objLogin.clickOnLoginButton();
	}
	
	@Then("^I should land on home page$")
	public void checkHomePage() throws IOException, InterruptedException {
		
		objLogin.validateHomePage();
	}
	

	@After
	public void closeBrowser(Scenario scenario) throws  InterruptedException, IOException {

		try {
			if (scenario.isFailed()) {

				

			}
		} finally {

			driver.quit();
		}

	}
}
