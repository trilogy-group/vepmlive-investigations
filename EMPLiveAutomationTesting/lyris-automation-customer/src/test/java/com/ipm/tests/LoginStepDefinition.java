package com.ipm.tests;

import org.openqa.selenium.WebDriver;

import java.io.InputStream;
import java.util.Enumeration;
import java.util.Properties;

public class LoginStepDefinition {
//@Inject private TestProperty<WebDriver> driver;	

    private static IpmStepDefination ipm;
    protected WebDriver driver;


    public LoginStepDefinition(WebDriver driver) {
        this.driver = driver;
    }

    public static void login(WebDriver driver) {
        //  driver.get("http://farmadmin:Pass%40word1@qaepmlive6/SitePages/Home.aspx");
        LoginStepDefinition lg = new LoginStepDefinition(driver);
        driver.get(lg.getUrl());
    }

    public String getUrl() {
        return getPropValue("url");
    }

    public String getPropValue(String key) {
        String filename = "local.properties";
        Properties properties = new Properties();
        try (InputStream inputStream = getClass().getClassLoader().getResourceAsStream(filename)) {
            if (inputStream == null) {
                return "";
            }
            properties.load(inputStream);

            Enumeration<?> e = properties.propertyNames();
            while (e.hasMoreElements()) {
                String propKey = (String) e.nextElement();
                if (propKey.toLowerCase().equals(key.toLowerCase())) {
                    return properties.getProperty(propKey.toLowerCase());
                }
            }
        } catch (Exception e) {
            System.out.println("Error while handling properties file : " + e);
            return "";
        }
        return "";
    }
}