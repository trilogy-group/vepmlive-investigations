package com.ipm.tests;

import com.ipm.lib.AbstractCoreTest;
import cucumber.api.java.en.And;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;
import org.openqa.selenium.By;
import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.Keys;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.Select;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.springframework.test.context.ContextConfiguration;

import java.util.concurrent.TimeUnit;

import static com.ipm.tests.LoginStepDefinition.driver;
import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

@ContextConfiguration(classes = {AbstractCoreTest.class})
public class TaskIssiuRiskMgmtStepDefinition {

    private WebDriverWait wait = new WebDriverWait(driver, 120);
    private String createdTaskName;
    private String createdRiskName;
    private String createdIssueName;

    @When("^I click on Tasks on the left panel$")
    public void iClickOnTasksOnTheLeftPanel() {
        checkPageIsReady();
        wait.until(ExpectedConditions.elementToBeClickable(By.id("EPMLiveNavt4")));
        driver.findElement(By.id("EPMLiveNavt4")).click();
        wait.until(ExpectedConditions.titleIs("Task Center - My Tasks"));
    }

    @Then("^Task center page should be displayed$")
    public void taskCenterPageShouldBeDisplayed() throws Throwable {
        checkPageIsReady();
        assertTrue("Verify Task Centre Page Title", driver.getTitle().contains("Task Center - My Tasks"));
    }

    @When("^I click on 'New Item'$")
    public void iClickOnNewItem() throws Throwable {
        checkPageIsReady();
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='actionmenu1Main']/div/ul[1]/li/a/span[1]")));
        driver.findElement(By.xpath(".//*[@id='actionmenu1Main']/div/ul[1]/li/a/span[1]")).click();
        wait.until(ExpectedConditions.titleIs("Task Center - New Item"));
    }

    @Then("^New Item page should be displayed$")
    public void newItemPageShouldBeDisplayed() throws Throwable {
        checkPageIsReady();
        assertTrue("Verify New Item Page", driver.getTitle().contains("Task Center - New Item"));
    }

    @When("^I provide required value and I click on save button$")
    public void iProvideRequiredValueAndIClickOnSaveButton() throws Throwable {
        checkPageIsReady();
        createdTaskName = "taskName" + System.currentTimeMillis() / 1000L;
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("Title_fa564e0f-0c70-4ab9-b863-0177e6ddd247_$TextField")));
        driver.findElement(By.id("Title_fa564e0f-0c70-4ab9-b863-0177e6ddd247_$TextField")).sendKeys(createdTaskName);
        wait.until(ExpectedConditions.elementToBeClickable(By.id("Project_ddlShowAll")));
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript("window.document.getElementById('Project_ddlShowAll').click()");
            js.executeScript("window.document.getElementById('autoText_0').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        Select select = new Select(driver.findElement(By.id("Status_c15b34c3-ce7d-490a-b133-3f4de8801b76_$DropDownChoice")));
        select.selectByValue("Not Started");
        driver.findElement(By.id("TestCol1_935a1af4-74ea-452e-9037-c6eb14d53091_$TextField")).sendKeys("test_1");
        driver.findElement(By.id("NewTestCol2_dffb091a-688c-4512-92d9-14c8a4300bec_$TextField")).sendKeys("test_2");
        wait.until(ExpectedConditions.elementToBeClickable(By.id("ctl00_ctl36_g_2e83c645_2091_434e_932c_0dab0cdff549_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem")));
        driver.findElement(By.id("ctl00_ctl36_g_2e83c645_2091_434e_932c_0dab0cdff549_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem")).click();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("ctl00_ctl36_g_2c9fb646_5498_41ba_8780_3319593b2b20_lblItemTitle")));
    }

    @Then("^Task should be created$")
    public void taskShouldBeCreated() throws Throwable {
        checkPageIsReady();
        assertTrue("Task is well created", driver.findElement(By.id("ctl00_ctl36_g_2c9fb646_5498_41ba_8780_3319593b2b20_lblItemTitle")).getText().contains(createdTaskName));
    }

    @When("^I click on 'Edit Item' button$")
    public void iClickOnEditItemButton() throws Throwable {
        checkPageIsReady();
        wait.until(ExpectedConditions.elementToBeClickable(By.id("Ribbon.ListForm.Display.Manage.EditItem2-Large")));
//        driver.findElement(By.id("Ribbon.ListForm.Display.Manage.EditItem2-Large")).click();
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;

            js.executeScript("window.document.getElementById('Ribbon.ListForm.Display.Manage.EditItem2-Large').click()");

        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        try {
            wait.until(ExpectedConditions.presenceOfElementLocated(By.id("Title_fa564e0f-0c70-4ab9-b863-0177e6ddd247_$TextField")));
        } catch (Exception e) {
            if (!driver.findElements(By.id("Ribbon.ListForm.Display.Manage.EditItem2-Large")).isEmpty()) {
                if (driver instanceof JavascriptExecutor) {
                    JavascriptExecutor js = (JavascriptExecutor) driver;

                    js.executeScript("window.document.getElementById('Ribbon.ListForm.Display.Manage.EditItem2-Large').click()");

                } else {
                    System.out.println("This driver does not support JavaScript!");
                }
                System.out.println("I click on 'Edit Item' button -- first click not working");
            }

        }

    }

    @Then("^Edit Task page should be displayed$")
    public void editTaskPageShouldBeDisplayed() throws Throwable {
        checkPageIsReady();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='Ribbon.ListForm.Edit-title']/a/span[1]")));
        System.out.println("Page Edit is open" + driver.findElement(By.xpath(".//*[@id='Ribbon.ListForm.Edit-title']/a/span[1]")).getText());
        assertTrue("Page Edit is open", driver.findElement(By.xpath(".//*[@id='Ribbon.ListForm.Edit-title']/a/span[1]")).getText().contains("EDIT"));
    }

    @When("^I make some changes and I click on save button$")
    public void iMakeSomeChangesAndIClickOnSaveButton() throws Throwable {
        checkPageIsReady();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("Status_c15b34c3-ce7d-490a-b133-3f4de8801b76_$DropDownChoice")));
        Thread.sleep(5000);
        Select select = new Select(driver.findElement(By.id("Status_c15b34c3-ce7d-490a-b133-3f4de8801b76_$DropDownChoice")));
        select.selectByValue("In Progress");
        Select select_0 = new Select(driver.findElement(By.id("Priority_a8eb573e-9e11-481a-a8c9-1104a54b2fbd_$DropDownChoice")));
        select_0.selectByValue("(3) Low");
        driver.findElement(By.id("ctl00_ctl36_g_2e83c645_2091_434e_932c_0dab0cdff549_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem")).click();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("ctl00_ctl36_g_2c9fb646_5498_41ba_8780_3319593b2b20_lblItemTitle")));
    }

    @Then("^Change should be saved$")
    public void chengeShouldBeSaved() throws Throwable {
        assertTrue("Change after edit task", driver.findElement(By.xpath(".//*[@id='ctl00_ctl36_g_2c9fb646_5498_41ba_8780_3319593b2b20_divQuickDetailsContent']/table/tbody/tr/td[1]/table/tbody/tr[4]/td[2]")).getText().contains("In Progress"));
        assertTrue("Change after edit task", driver.findElement(By.xpath(".//*[@id='ctl00_ctl36_g_2c9fb646_5498_41ba_8780_3319593b2b20_divQuickDetailsContent']/table/tbody/tr/td[1]/table/tbody/tr[5]/td[2]")).getText().contains("(3) Low"));
    }

    @When("^I click on 'Delete' button$")
    public void iClickOnDeleteButton() throws Throwable {
        checkPageIsReady();
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='Ribbon.ListForm.Display.Manage.DeleteItem-Medium']")));
//        WebElement element = driver.findElement(By.xpath(".//*[@id='Ribbon.ListForm.Display.Manage.DeleteItem-Medium']/span[2]"));
//        JavascriptExecutor executor = (JavascriptExecutor) driver;
//        executor.executeScript("arguments[0].click();", element);
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript("window.document.getElementById('Ribbon.ListForm.Display.Manage.DeleteItem-Medium').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
//        driver.findElement(By.xpath(".//*[@id='Ribbon.ListForm.Display.Manage.DeleteItem-Medium']/span[2]")).click();
        Thread.sleep(5000);
    }

    @Then("^Task should be deleted$")
    public void taskShouldBeDeleted() throws Throwable {
        checkPageIsReady();
        searchForCreatedTask(createdTaskName);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath(".//*[@id='GanttGrid0Main']/tbody/tr[3]/td/div/table/tbody/tr/td/div")));
        assertTrue("Task Not Deleted", driver.findElement(By.xpath(".//*[@id='GanttGrid0Main']/tbody/tr[3]/td/div/table/tbody/tr/td/div")).getText().contains("No data found"));
    }

    public void searchForCreatedTask(String projectname) {
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='actionmenu0Main']/div/ul[2]/li[1]/a/span")));
        driver.findElement(By.xpath(".//*[@id='actionmenu0Main']/div/ul[2]/li[1]/a/span")).click();
        wait.until(ExpectedConditions.elementToBeClickable(By.id("searchtext0Main")));
        driver.findElement(By.id("searchtext0Main")).click();
        driver.findElement(By.id("searchtext0Main")).sendKeys(projectname);
        driver.findElement(By.id("searchtext0Main")).sendKeys(Keys.RETURN);
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
    }

    public void searchForCreatedRisk(String projectname) {
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='actionmenu0Main']/div/ul[2]/li[1]/a/span")));
        driver.findElement(By.xpath(".//*[@id='actionmenu0Main']/div/ul[2]/li[1]/a/span")).click();
        wait.until(ExpectedConditions.elementToBeClickable(By.id("searchtext0Main")));
        driver.findElement(By.id("searchtext0Main")).click();
        driver.findElement(By.id("searchtext0Main")).sendKeys(projectname);
        driver.findElement(By.id("searchtext0Main")).sendKeys(Keys.RETURN);
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
    }

    public void searchForCreatedIssue(String projectname) {
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='actionmenu0Main']/div/ul[2]/li[1]/a/span")));
        driver.findElement(By.xpath(".//*[@id='actionmenu0Main']/div/ul[2]/li[1]/a/span")).click();
        wait.until(ExpectedConditions.elementToBeClickable(By.id("searchtext0Main")));
        driver.findElement(By.id("searchtext0Main")).click();
        driver.findElement(By.id("searchtext0Main")).sendKeys(projectname);
        driver.findElement(By.id("searchtext0Main")).sendKeys(Keys.RETURN);
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
    }

    @When("^I click on Risks on the left panel$")
    public void iClickOnRisksOnTheLeftPanel() throws Throwable {
        checkPageIsReady();
        wait.until(ExpectedConditions.elementToBeClickable(By.id("EPMLiveNavt5")));
        driver.findElement(By.id("EPMLiveNavt5")).click();
        wait.until(ExpectedConditions.titleIs("Risks - All My Risks"));
    }

    @Then("^Risk center page should be displayed$")
    public void riskCenterPageShouldBeDisplayed() throws Throwable {
        checkPageIsReady();
        assertTrue("Verify tasks page", driver.getTitle().contains("Risks - All My Risks"));
    }

    @Then("^Risk New Item page should be displayed$")
    public void riskNewItemPageShouldBeDisplayed() throws Throwable {
        checkPageIsReady();
        assertTrue("Verify tasks page", driver.getTitle().contains("Risks - New Item"));
    }

    @When("^I provide required value for new risk and I click on save button$")
    public void iProvideRequiredValueForNewRiskAndIClickOnSaveButton() throws Throwable {
        checkPageIsReady();
        createdRiskName = "taskName" + System.currentTimeMillis() / 1000L;
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("Title_fa564e0f-0c70-4ab9-b863-0177e6ddd247_$TextField"))).click();
        driver.findElement(By.id("Title_fa564e0f-0c70-4ab9-b863-0177e6ddd247_$TextField")).sendKeys(createdRiskName);
        wait.until(ExpectedConditions.elementToBeClickable(By.id("Project_ddlShowAll"))).click();
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript("window.document.getElementById('Project_ddlShowAll').click()");
            wait.until(ExpectedConditions.elementToBeClickable(By.id("autoText_0")));
            js.executeScript("window.document.getElementById('autoText_0').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        driver.findElement(By.id("ctl00_ctl36_g_c27dac1b_fd4a_4d21_a602_e27795e33a0e_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem")).click();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("ctl00_ctl36_g_1af02a9e_60f3_4982_b04d_303b53be05f8_lblItemTitle")));
    }

    @Then("^Risk should be created$")
    public void riskShouldBeCreated() throws Throwable {
        checkPageIsReady();
        assertTrue("Risk is well created", driver.findElement(By.id("ctl00_ctl36_g_1af02a9e_60f3_4982_b04d_303b53be05f8_lblItemTitle")).getText().contains(createdRiskName));

    }

    @Then("^Edit Risk page should be displayed$")
    public void editRiskPageShouldBeDisplayed() throws Throwable {
        checkPageIsReady();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='Ribbon.ListForm.Edit-title']/a/span[1]")));
        System.out.println("Page Edit is open" + driver.findElement(By.xpath(".//*[@id='Ribbon.ListForm.Edit-title']/a/span[1]")).getText());
        assertTrue("Page Edit is open", driver.findElement(By.xpath(".//*[@id='Ribbon.ListForm.Edit-title']/a/span[1]")).getText().contains("EDIT"));
    }

    @When("^I make some changes on risk item and I click on save button$")
    public void iMakeSomeChangesOnRiskItemAndIClickOnSaveButton() throws Throwable {
        checkPageIsReady();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("Status_5c820a57-98d6-44b5-95e6-4a717cfe5a06_$DropDownChoice")));
        Select select = new Select(driver.findElement(By.id("Status_5c820a57-98d6-44b5-95e6-4a717cfe5a06_$DropDownChoice")));
        select.selectByValue("In Progress");
        Select select_0 = new Select(driver.findElement(By.id("Priority_ec70454d-9ce5-4a8f-ac90-6d138a2f7d18_$DropDownChoice")));
        select_0.selectByValue("(3) Low");
        driver.findElement(By.id("ctl00_ctl36_g_4d763974_1be4_4911_8b6e_67af282eb09c_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem")).click();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("ctl00_ctl36_g_1af02a9e_60f3_4982_b04d_303b53be05f8_lblItemTitle")));
    }

    @Then("^Risk Changes should be saved$")
    public void riskChangesShouldBeSaved() throws Throwable {
        checkPageIsReady();
        assertTrue("Change after edit task", driver.findElement(By.xpath(".//*[@id='ctl00_ctl36_g_1af02a9e_60f3_4982_b04d_303b53be05f8_divQuickDetailsContent']/table/tbody/tr/td[1]/table/tbody/tr[7]/td[2]")).getText().contains("In Progress"));
        assertTrue("Change after edit task", driver.findElement(By.xpath(".//*[@id='ctl00_ctl36_g_1af02a9e_60f3_4982_b04d_303b53be05f8_divQuickDetailsContent']/table/tbody/tr/td[1]/table/tbody/tr[4]/td[2]")).getText().contains("(3) Low"));
    }

    @Then("^Risk should be deleted$")
    public void riskShouldBeDeleted() throws Throwable {
        checkPageIsReady();
        searchForCreatedRisk(createdRiskName);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath(".//*[@id='GanttGrid0Main']/tbody/tr[3]/td/div/table/tbody/tr/td/div")));
        assertEquals("Risk Not Deleted", "No data found", driver.findElement(By.xpath(".//*[@id='GanttGrid0Main']/tbody/tr[3]/td/div/table/tbody/tr/td/div")).getText());
    }

    @When("^I click on 'New Item' in Risk page$")
    public void iClickOnNewItemInRiskPage() throws Throwable {
        checkPageIsReady();
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='actionmenu0Main']/div/ul[1]/li/a/span[1]")));
        driver.findElement(By.xpath(".//*[@id='actionmenu0Main']/div/ul[1]/li/a/span[1]")).click();
        wait.until(ExpectedConditions.titleIs("Risks - New Item"));
    }

    @When("^I click on Issues on the left panel$")
    public void iClickOnIssuesOnTheLeftPanel() throws Throwable {
        checkPageIsReady();
        wait.until(ExpectedConditions.elementToBeClickable(By.id("EPMLiveNavt6")));
        driver.findElement(By.id("EPMLiveNavt6")).click();
        wait.until(ExpectedConditions.titleIs("Issues - My Active Issue Summary"));
    }

    @Then("^Issue center page should be displayed$")
    public void issueCenterPageShouldBeDisplayed() throws Throwable {
        checkPageIsReady();
        assertTrue("Verify issue page", driver.getTitle().contains("Issues - My Active Issue Summary"));
    }

    @When("^I click on 'New Item' in Issue page$")
    public void iClickOnNewItemInIssuePage() throws Throwable {
        checkPageIsReady();
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='actionmenu2Main']/div/ul[1]/li/a/span[1]")));
        driver.findElement(By.xpath(".//*[@id='actionmenu2Main']/div/ul[1]/li/a/span[1]")).click();
        wait.until(ExpectedConditions.titleIs("Issues - New Item"));
    }

    @Then("^Issue New Item page should be displayed$")
    public void issueNewItemPageShouldBeDisplayed() throws Throwable {
        checkPageIsReady();
        assertTrue("Verify New Item Issue page", driver.getTitle().contains("Issues - New Item"));
    }

    @When("^I provide required value for new Issue and I click on save button$")
    public void iProvideRequiredValueForNewIssueAndIClickOnSaveButton() throws Throwable {
        checkPageIsReady();
        createdIssueName = "issueName" + System.currentTimeMillis() / 1000L;
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("Title_fa564e0f-0c70-4ab9-b863-0177e6ddd247_$TextField"))).click();
        driver.findElement(By.id("Title_fa564e0f-0c70-4ab9-b863-0177e6ddd247_$TextField")).sendKeys(createdIssueName);
        wait.until(ExpectedConditions.elementToBeClickable(By.id("Project_ddlShowAll"))).click();
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript("window.document.getElementById('Project_ddlShowAll').click()");
            wait.until(ExpectedConditions.elementToBeClickable(By.id("autoText_0")));
            js.executeScript("window.document.getElementById('autoText_0').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        driver.findElement(By.id("ctl00_ctl36_g_6094c15c_3b78_4896_85a6_c81d762ad2de_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem")).click();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("ctl00_ctl36_g_9547a150_30b5_4141_a538_c5fea86852ac_lblItemTitle")));
    }

    @Then("^Issue should be created$")
    public void issueShouldBeCreated() throws Throwable {
        checkPageIsReady();
        assertTrue("Issue is well created", driver.findElement(By.id("ctl00_ctl36_g_9547a150_30b5_4141_a538_c5fea86852ac_lblItemTitle")).getText().contains(createdIssueName));
    }

    @Then("^Edit Issue page should be displayed$")
    public void editIssuePageShouldBeDisplayed() throws Throwable {
        checkPageIsReady();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='Ribbon.ListForm.Edit-title']/a/span[1]")));
        System.out.println("Page Edit issue is open" + driver.findElement(By.xpath(".//*[@id='Ribbon.ListForm.Edit-title']/a/span[1]")).getText());
        assertTrue("Page Edit issue is open", driver.findElement(By.xpath(".//*[@id='Ribbon.ListForm.Edit-title']/a/span[1]")).getText().contains("EDIT"));
    }

    @When("^I make some changes on Issue item and I click on save button$")
    public void iMakeSomeChangesOnIssueItemAndIClickOnSaveButton() throws Throwable {
        checkPageIsReady();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("Status_5c820a57-98d6-44b5-95e6-4a717cfe5a06_$DropDownChoice")));
        Select select = new Select(driver.findElement(By.id("Status_5c820a57-98d6-44b5-95e6-4a717cfe5a06_$DropDownChoice")));
        select.selectByValue("In Progress");
        Select select_0 = new Select(driver.findElement(By.id("Priority_ec70454d-9ce5-4a8f-ac90-6d138a2f7d18_$DropDownChoice")));
        select_0.selectByValue("(3) Low");
        driver.findElement(By.id("ctl00_ctl36_g_249bda0c_c162_462d_bd14_06d4a549827d_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem")).click();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("ctl00_ctl36_g_9547a150_30b5_4141_a538_c5fea86852ac_lblItemTitle")));
    }

    @Then("^Issue Changes should be saved$")
    public void issueChangesShouldBeSaved() throws Throwable {
        checkPageIsReady();
        assertTrue("Change after edit issue", driver.findElement(By.xpath(".//*[@id='ctl00_ctl36_g_9547a150_30b5_4141_a538_c5fea86852ac_divQuickDetailsContent']/table/tbody/tr/td[1]/table/tbody/tr[4]/td[2]")).getText().contains("In Progress"));
        assertTrue("Change after edit issue", driver.findElement(By.xpath(".//*[@id='ctl00_ctl36_g_9547a150_30b5_4141_a538_c5fea86852ac_divQuickDetailsContent']/table/tbody/tr/td[1]/table/tbody/tr[5]/td[2]")).getText().contains("(3) Low"));
    }

    @Then("^Issue should be deleted$")
    public void issueShouldBeDeleted() throws Throwable {
        checkPageIsReady();
        searchForCreatedIssue(createdIssueName);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath(".//*[@id='GanttGrid0Main']/tbody/tr[3]/td/div/table/tbody/tr/td/div")));
        assertEquals("Issue Not Deleted", "No data found", driver.findElement(By.xpath(".//*[@id='GanttGrid0Main']/tbody/tr[3]/td/div/table/tbody/tr/td/div")).getText());
    }

    @And("^accept delete popup for task issu risk$")
    public void iAcceptDeletePopupForTaskIssuRisk() throws Throwable {
        try {
            driver.switchTo().alert().accept();
            System.out.print("Alert accepted");
        } catch (Exception e) {
            System.out.println("Alert Not Present");
            if (driver instanceof JavascriptExecutor) {
                JavascriptExecutor js = (JavascriptExecutor) driver;
                js.executeScript("window.document.getElementById('Ribbon.ListForm.Display.Manage.DeleteItem-Medium').click()");
            } else {
                System.out.println("This driver does not support JavaScript!");
            }
            Thread.sleep(5000);
            try {
                driver.switchTo().alert().accept();
            } catch (Exception ex) {
                System.out.println("Alert Not Present for the second time");
            }
        }
        Thread.sleep(5000);
    }

    public void checkPageIsReady() {
        JavascriptExecutor js = (JavascriptExecutor) driver;
        //Initially bellow given if condition will check ready state of page.
        if (js.executeScript("return document.readyState").toString().equals("complete")) {
            System.out.println("Page Is loaded.");
            return;
        }
        //This loop will rotate for 60 times to check If page Is ready after every 1 second.
        //You can replace your value with 25 If you wants to Increase or decrease wait time.
        for (int i = 0; i < 60; i++) {
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
            }
            //To check page ready state.
            if (js.executeScript("return document.readyState").toString().equals("complete")) {
                System.out.println("Page Is loaded : " + i);
                break;
            }
        }
    }
}