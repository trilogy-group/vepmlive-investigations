package com.ipm.tests;

import com.ipm.lib.AbstractCoreTest;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;
import org.openqa.selenium.By;
import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.springframework.test.context.ContextConfiguration;

import static com.ipm.tests.LoginStepDefinition.driver;
import static org.junit.Assert.assertTrue;

@ContextConfiguration(classes = {AbstractCoreTest.class})
public class RessourceStepDefinition {


    private static String createdRessourceName;
    private WebDriverWait wait = new WebDriverWait(driver, 60);

    @When("^I click on Ressources on left panel$")
    public void iClickOnRessourcesOnLeftPanel() {
        driver.findElement(By.id("EPMLiveNavt9")).click();
        wait.until(ExpectedConditions.titleIs("Resource Pool"));
    }

    @Then("^The ressource page should be opned$")
    public void theRessourcePageShouldBeOpned() throws Throwable {
        assertTrue("", driver.getTitle().contains("Resource Pool"));
    }


    @When("^I click on 'Invite'$")
    public void iClickOnInvite() throws Throwable {
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='resourcePoolToolBar']/ul[1]/li[1]/a/span[2]")));
        Thread.sleep(5000);
        driver.findElement(By.xpath(".//*[@id='resourcePoolToolBar']/ul[1]/li[1]/a/span[2]")).click();
        wait.until(ExpectedConditions.titleIs("Resources - New Item"));

    }

    @Then("^The 'Add Ressource' page should be displayed$")
    public void theAddRessourcePageShouldBeDisplayed() throws Throwable {
        assertTrue("Verify page title", driver.getTitle().contains("Resources - New Item"));
    }

    @When("^I enter required fields and click on save button$")
    public void iEnterRequiredFieldsAndClickOnSaveButton() throws Throwable {
        createdRessourceName = "firstName" + System.currentTimeMillis() / 1000L;
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath("//input[@title='First Name']")));
        Thread.sleep(5000);
        driver.findElement(By.xpath("//input[@title='First Name']")).sendKeys(createdRessourceName);
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            wait.until(ExpectedConditions.elementToBeClickable(By.id("Role_ddlShowAll")));
            js.executeScript("window.document.getElementById('Role_ddlShowAll').click()");
            wait.until(ExpectedConditions.elementToBeClickable(By.id("autoText_0")));
            js.executeScript("window.document.getElementById('autoText_0').click()");
            wait.until(ExpectedConditions.elementToBeClickable(By.id("HolidaySchedule_ddlShowAll")));
            js.executeScript("window.document.getElementById('HolidaySchedule_ddlShowAll').click()");
            wait.until(ExpectedConditions.elementToBeClickable(By.id("autoText_0")));
            js.executeScript("window.document.getElementById('autoText_0').click()");
            wait.until(ExpectedConditions.elementToBeClickable(By.id("WorkHours_ddlShowAll")));
            js.executeScript("window.document.getElementById('WorkHours_ddlShowAll').click()");
            wait.until(ExpectedConditions.elementToBeClickable(By.id("autoText_0")));
            js.executeScript("window.document.getElementById('autoText_0').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        wait.until(ExpectedConditions.elementToBeClickable(By.id("ctl00_ctl36_g_aedfd158_1c7e_40b6_96e6_a8abc56e92ab_ctl00_toolBarTbl_RightRptControls_ctl00_ctl00_diidIOSaveItem")));
        driver.findElement(By.id("ctl00_ctl36_g_aedfd158_1c7e_40b6_96e6_a8abc56e92ab_ctl00_toolBarTbl_RightRptControls_ctl00_ctl00_diidIOSaveItem")).click();
        wait.until(ExpectedConditions.titleIs("Resource Pool"));
    }

    @Then("^Ressource should be added$")
    public void ressourceShouldBeAdded() throws Throwable {
        assertTrue("Verify title page", driver.getTitle().contains("Resource Pool"));
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath("//td[contains(text(), '" + createdRessourceName + "')]")));
        if (!driver.findElements(By.xpath("//td[contains(text(), '" + createdRessourceName + "')]")).isEmpty()) {
            assertTrue("", true);
        } else {
            assertTrue("", false);
        }
        System.out.println("Ressource founded :" + driver.findElement(By.xpath("//td[contains(text(), '" + createdRessourceName + "')]")).getText());

//        searchForCreatedRessource(createdRessourceName);
    }

    public void searchForCreatedRessource(String projectname) throws InterruptedException {
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath(".//*[@id='toolbar-search-icon']/span")));
        Thread.sleep(5000);
        driver.findElement(By.xpath(".//*[@id='toolbar-search-icon']/span")).click();
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath(".//*[@id='toolBarResGridSelector']")));
        Thread.sleep(5000);
        driver.findElement(By.xpath(".//*[@id='toolBarResGridSelector']")).sendKeys(createdRessourceName);
        Thread.sleep(5000);
        driver.findElement(By.xpath("//a[contains(text(), '" + createdRessourceName + "')]")).click();
        Thread.sleep(10000);
        System.out.println("Ressource wanted :" + createdRessourceName);
        System.out.println("Ressource founded :" + driver.findElement(By.xpath("//td[contains(text(), '" + createdRessourceName + "')]")).getText());
        assertTrue("", driver.findElement(By.xpath("//td[contains(text(), '" + createdRessourceName + "')]")).getText().contains(createdRessourceName));
    }
}
