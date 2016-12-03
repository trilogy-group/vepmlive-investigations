package com.ipm.tests;

import org.junit.runner.RunWith;

import cucumber.api.CucumberOptions;
import cucumber.api.junit.Cucumber;

@RunWith(Cucumber.class)
@CucumberOptions(monochrome = true, features = { "classpath:feature_files_ipm/Resource.feature" }, glue = {
		"com.ipm.tests" }, tags = "@Ready", plugin = { "pretty", "json:target/cucumber" })

public class ResourceTest {

}
