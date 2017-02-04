package com.ipm.tests;

import cucumber.api.CucumberOptions;
import cucumber.api.junit.Cucumber;
import org.junit.runner.RunWith;

@RunWith(Cucumber.class)
@CucumberOptions(monochrome = true, features = {"classpath:feature_files_ipm/ProjectPlanner.feature"}, glue = {
        "com.ipm.tests"}, tags = "@Ready", plugin = {"pretty", "json:target/cucumber"})
public class ProjectPlannerTest {

}
