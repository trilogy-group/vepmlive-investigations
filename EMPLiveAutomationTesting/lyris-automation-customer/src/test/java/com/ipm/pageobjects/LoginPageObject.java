package com.ipm.pageobjects;

import org.junit.Assert;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.springframework.beans.factory.annotation.Autowired;

import com.ipm.lib.AbstractPage;

public class LoginPageObject extends AbstractPage {

	@Autowired
	public LoginPageObject(WebDriver driver) throws InterruptedException {
		super(driver);
		PageFactory.initElements(driver, this);
	}

	@FindBy(xpath = ".//input[@id='txtBizPassUserID']")
	WebElement usernameTextbox;   
	
	@FindBy(xpath = ".//input[@id='txtBizPassUserPassword']")
	WebElement passwordTextbox; 
	
	@FindBy(xpath = ".//input[@id='login']")
	WebElement loginButton;
	
	
	@FindBy(xpath = ".//span[@id='tab-1040-btnInnerEl']")
	WebElement homePageTab;
	
	public void enterTheLoginCredentials(String username, String password) {
		
		usernameTextbox.sendKeys(username);
		passwordTextbox.sendKeys(password);
	}  
	
    public void clickOnLoginButton() {
		
		loginButton.click();
		
	}
    
    public void validateHomePage() throws InterruptedException {

		Assert.assertTrue("IPM home page is not visible", homePageTab.getText().contains("Home"));
	}

	
	@Override
	public void checkSanity() {
		// TODO Auto-generated method stub

	}

	@Override
	public void close() {
		// TODO Auto-generated method stub

	}

	@Override
	protected WebElement getDefaultWaitElement() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public void initializeDriver() {
		// TODO Auto-generated method stub

	}

	@Override
	public void open() {
		// TODO Auto-generated method stub

	}
}
