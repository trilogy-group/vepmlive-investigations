package com.ipm.tests;

import cucumber.api.java.en.And;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;
import org.openqa.selenium.By;
import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.Select;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.util.List;
import java.util.concurrent.TimeUnit;

import static com.ipm.tests.LoginStepDefinition.driver;
import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

public class SmokeVerificationStepDefinition {

    private String createdChangeTitle;
    private String workassigned;
    private WebDriverWait wait = new WebDriverWait(driver, 60);

    @When("^I click on Changes on the left panel$")
    public void iClickOnChangesOnTheLeftPanel() {
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("EPMLiveNavt7")));
        driver.findElement(By.id("EPMLiveNavt7")).click();
        wait.until(ExpectedConditions.titleIs("Changes - My Active Changes"));
    }

    @Then("^Change center page should be displayed$")
    public void changeCenterPageShouldBeDisplayed() throws Throwable {
        assertTrue("Verify changes page", driver.getTitle().contains("Changes - My Active Changes"));
    }

    @When("^I click on 'New Item' in Change page$")
    public void iClickOnNewItemInChangePage() throws Throwable {
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='actionmenu0Main']/div/ul[1]/li/a/span[1]")));
        driver.findElement(By.xpath(".//*[@id='actionmenu0Main']/div/ul[1]/li/a/span[1]")).click();
        wait.until(ExpectedConditions.titleIs("Changes - New Item"));
    }

    @Then("^Change New Item page should be displayed$")
    public void changeNewItemPageShouldBeDisplayed() throws Throwable {
        assertTrue("Verify New Item Changes page", driver.getTitle().contains("Changes - New Item"));
    }

    @When("^I provide required value for new Change and I click on save button$")
    public void iProvideRequiredValueForNewChangeAndIClickOnSaveButton() throws Throwable {
        createdChangeTitle = "changeName" + System.currentTimeMillis() / 1000L;
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("Title_fa564e0f-0c70-4ab9-b863-0177e6ddd247_$TextField")));
        driver.findElement(By.id("Title_fa564e0f-0c70-4ab9-b863-0177e6ddd247_$TextField")).sendKeys(createdChangeTitle);
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript("window.document.getElementById('Project_ddlShowAll').click()");
            js.executeScript("window.document.getElementById('autoText_0').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        Select select = new Select(driver.findElement(By.id("Status_5c820a57-98d6-44b5-95e6-4a717cfe5a06_$DropDownChoice")));
        select.selectByValue("Not Started");
        driver.findElement(By.id("ctl00_ctl36_g_744802db_0974_49fe_ad8d_4fb061f14c29_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem")).click();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("ctl00_ctl36_g_e261ec3d_df46_4403_aa3e_754ef3260bc5_lblItemTitle")));
    }

    @Then("^Change should be created$")
    public void changeShouldBeCreated() throws Throwable {
        assertTrue("Change item is well created", driver.findElement(By.id("ctl00_ctl36_g_e261ec3d_df46_4403_aa3e_754ef3260bc5_lblItemTitle")).getText().contains(createdChangeTitle));
    }

    @Then("^Edit Change page should be displayed$")
    public void editChangePageShouldBeDisplayed() throws Throwable {
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='Ribbon.ListForm.Edit-title']/a/span[1]")));
        System.out.println("Page Edit is open" + driver.findElement(By.xpath(".//*[@id='Ribbon.ListForm.Edit-title']/a/span[1]")).getText());
        assertTrue("Page Edit is open", driver.findElement(By.xpath(".//*[@id='Ribbon.ListForm.Edit-title']/a/span[1]")).getText().contains("EDIT"));
    }

    @When("^I make some changes on Change item and I click on save button$")
    public void iMakeSomeChangesOnChangeItemAndIClickOnSaveButton() throws Throwable {
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("Status_5c820a57-98d6-44b5-95e6-4a717cfe5a06_$DropDownChoice")));
        Select select = new Select(driver.findElement(By.id("Status_5c820a57-98d6-44b5-95e6-4a717cfe5a06_$DropDownChoice")));
        select.selectByValue("In Progress");
        Select select_0 = new Select(driver.findElement(By.id("Priority_ec70454d-9ce5-4a8f-ac90-6d138a2f7d18_$DropDownChoice")));
        select_0.selectByValue("(3) Low");
        driver.findElement(By.id("ctl00_ctl36_g_4e236b18_4bc6_469c_ac42_3a0bebbce14f_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem")).click();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("ctl00_ctl36_g_e261ec3d_df46_4403_aa3e_754ef3260bc5_lblItemTitle")));
    }

    @Then("^Changes in change item should be saved$")
    public void changesInChangeItemShouldBeSaved() throws Throwable {
        assertTrue("Changes after edit Change item not saved", driver.findElement(By.xpath(".//*[@id='ctl00_ctl36_g_e261ec3d_df46_4403_aa3e_754ef3260bc5_divQuickDetailsContent']/table/tbody/tr/td[1]/table/tbody/tr[3]/td[2]")).getText().contains("In Progress"));
        assertTrue("Changes after edit Change item not saved", driver.findElement(By.xpath(".//*[@id='ctl00_ctl36_g_e261ec3d_df46_4403_aa3e_754ef3260bc5_divQuickDetailsContent']/table/tbody/tr/td[1]/table/tbody/tr[4]/td[2]")).getText().contains("(3) Low"));
    }

    @Then("^Change should be deleted$")
    public void changeShouldBeDeleted() throws Throwable {
        searchForCreatedChange(createdChangeTitle);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath(".//*[@id='GanttGrid0Main']/tbody/tr[3]/td/div/table/tbody/tr/td/div")));
        assertEquals("Change item Not Deleted", "No data found", driver.findElement(By.xpath(".//*[@id='GanttGrid0Main']/tbody/tr[3]/td/div/table/tbody/tr/td/div")).getText());
    }

    public void searchForCreatedChange(String itemName) {
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath(".//*[@id='actionmenu0Main']/div/ul[2]/li[1]/a/span")));
        driver.findElement(By.xpath(".//*[@id='actionmenu0Main']/div/ul[2]/li[1]/a/span")).click();
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("searchtext0Main")));
        driver.findElement(By.id("searchtext0Main")).click();
        driver.findElement(By.id("searchtext0Main")).sendKeys(itemName);
        driver.findElement(By.id("searchtext0Main")).sendKeys(Keys.RETURN);
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
    }

    @When("^I click on 'Delete' button in change item$")
    public void iClickOnDeleteButtonInChangeItem() throws Throwable {
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath(".//*[@id='Ribbon.ListForm.Display.Manage.DeleteItem-Medium']/span[2]")));
        driver.findElement(By.xpath(".//*[@id='Ribbon.ListForm.Display.Manage.DeleteItem-Medium']/span[2]")).click();
        Thread.sleep(10000);
    }

    @When("^I click on Reports on the left panel$")
    public void iClickOnReportsOnTheLeftPanel() throws Throwable {
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("EPMLiveNavt10")));
        driver.findElement(By.id("EPMLiveNavt10")).click();
        wait.until(ExpectedConditions.titleIs("Reporting"));
    }

    @Then("^Reporting page should be displayed$")
    public void reportingPageShouldBeDisplayed() throws Throwable {
        assertTrue("Verify Reporting page title", driver.getTitle().contains("Reporting"));
    }

    @When("^I click on 'Classic Reporting'$")
    public void iClickOnClassicReporting() throws Throwable {
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='classic']/li")));
        driver.findElement(By.xpath(".//*[@id='classic']/li")).click();
        wait.until(ExpectedConditions.titleIs("Report"));
    }

    @Then("^Report page should be displayed$")
    public void reportPageShouldBeDisplayed() throws Throwable {
        assertTrue("Verify Report page title", driver.getTitle().contains("Report"));
        assertTrue("Verify Report List presence", driver.findElement(By.xpath(".//*[@id='WebPartTitleWPQ3']/h2/nobr/span[1]")).getText().contains("Report List"));
    }

    @When("^I click on project List from the 'Report List'$")
    public void iClickOnProjectListFromTheReportList() throws Throwable {
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='gridctl00$ctl36$g_ad12f598_1fd2_4896_9c89_84cd6fd83d86']/div[2]/table/tbody/tr[5]/td/div/div/img[1]")));
        driver.findElement(By.xpath(".//*[@id='gridctl00$ctl36$g_ad12f598_1fd2_4896_9c89_84cd6fd83d86']/div[2]/table/tbody/tr[5]/td/div/div/img[1]")).click();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='nodeval']/a")));
    }

    @And("^I Select 'Project Health' from the list$")
    public void iSelectProjectHealthFromTheList() throws Throwable {
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='gridctl00$ctl36$g_ad12f598_1fd2_4896_9c89_84cd6fd83d86']/div[2]/table/tbody/tr[14]/td/div/div")));
        driver.findElement(By.xpath(".//*[@id='gridctl00$ctl36$g_ad12f598_1fd2_4896_9c89_84cd6fd83d86']/div[2]/table/tbody/tr[14]/td/div/div")).click();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("dialogTitleSpan")));
    }

    @Then("^Project health view should get displayed$")
    public void projectHealthViewShouldGetDisplayed() throws Throwable {
        assertTrue("Verify title page", driver.findElement(By.id("dialogTitleSpan")).getText().contains("Project Health"));
    }

    @When("^I click on 'My Workplace' from left panel$")
    public void iClickOnMyWorkplaceFromLeftPanel() throws Throwable {
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("epm-nav-top-workplace")));
        driver.findElement(By.id("epm-nav-top-workplace")).click();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("epm-nav-link-C9C7CE205BE6399A66838808A33E3194")));
    }

    @And("^Click on 'My Timesheet'$")
    public void clickOnMyTimesheet() throws Throwable {
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='epm-nav-link-C9C7CE205BE6399A66838808A33E3194']/span")));
        driver.findElement(By.xpath(".//*[@id='epm-nav-link-C9C7CE205BE6399A66838808A33E3194']/span")).click();
        wait.until(ExpectedConditions.titleIs("My Timesheet"));
    }

    @And("^Click on 'Add Work'$")
    public void clickOnAddWork() throws Throwable {
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("Ribbon.MyTimesheet.WorkGroup.AddWork-Large")));
        if (driver.findElement(By.id("mytimesheetstatus")).getText().equalsIgnoreCase("Submitted")) {
            driver.findElement(By.xpath(".//*[@id='tsnav']/nav/div/div/ul/li[2]/span[2]")).click();
        }

        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("Ribbon.MyTimesheet.WorkGroup.AddWork-Large")));
        driver.findElement(By.id("Ribbon.MyTimesheet.WorkGroup.AddWork-Large")).click();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("dialogTitleSpan")));
    }

    @Then("^Tasks assigned to user will be displayed$")
    public void tasksAssignedToUserWillBeDisplayed() throws Throwable {
        assertTrue("Add Work Title", driver.findElement(By.id("dialogTitleSpan")).getText().contains("Add Work"));
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath("//tr[@class='GMDataRow ']")));
        assertTrue("Tasks assigned to user not displayed", !driver.findElements(By.xpath("//tr[@class='GMDataRow ']")).isEmpty());
    }

    @When("^I Select tasks and click on 'Add'$")
    public void iSelectTasksAndClickOnAdd() throws Throwable {
        Thread.sleep(10000);
        driver.switchTo().defaultContent();
        List<WebElement> iframes = driver.findElements(By.tagName("iframe"));
        for (WebElement iframe : iframes) {
            driver.switchTo().defaultContent();
            Thread.sleep(1000);
            driver.switchTo().frame(iframe);
            Thread.sleep(1000);
            System.out.println("add task timsheet size :" + driver.findElements(By.xpath(".//*[@id='TSWork']/tbody/tr[3]/td[1]/div/div[1]/table/tbody/tr[2]/td[3]")).size());
            System.out.println("add task timsheet size 2:" + driver.findElements(By.xpath("//td[@class=' GMClassReadOnly GMBool0RO GMWrap0 GMBool0RO GMCell GMEmpty GMCellBorderFF3 HideCol0Check']")).size());
//            if (!driver.findElements(By.xpath(".//*[@id='TSWork']/tbody/tr[3]/td[1]/div/div[1]/table/tbody/tr[2]/td[3]")).isEmpty()) {
//                workassigned = driver.findElement(By.xpath(".//*[@id='TSWork']/tbody/tr[3]/td[1]/div/div[1]/table/tbody/tr[2]/td[3]")).getText();
//                wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath("//td[@class='GMClassReadOnly GMBool0RO GMWrap0 GMBool1RO GMCell GMEmpty GMCellBorderFF3 HideCol0Check']")));
//                Actions action = new Actions(driver).click(driver.findElement(By.xpath("//td[@class='GMClassReadOnly GMBool0RO GMWrap0 GMBool1RO GMCell GMEmpty GMCellBorderFF3 HideCol0Check']")));
//                action.build().perform();
//                wait.until(ExpectedConditions.presenceOfElementLocated(By.id("Ribbon.MyTimesheetWork.ActionsGroup.AddWork-Large")));
//                driver.findElement(By.id("Ribbon.MyTimesheetWork.ActionsGroup.AddWork-Large")).click();
//                Thread.sleep(5000);
//            }
        }
        try {
            driver.switchTo().alert().accept();
        } catch (Exception e) {
            System.out.println("Alert 1 Not Present");
        }
        Thread.sleep(5000);
        try {
            driver.switchTo().alert().accept();
        } catch (Exception e) {
            System.out.println("Alert 2 Not Present");
        }
    }

    @When("^I click on 'Save' button$")
    public void iClickOnSaveButton() throws Throwable {
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("Ribbon.MyTimesheet.ActionsGroup.SaveButton-Large")));
        driver.findElement(By.id("Ribbon.MyTimesheet.ActionsGroup.SaveButton-Large")).click();
        wait.until(ExpectedConditions.textToBe(By.id("mytimesheetstatus"), "Unsubmitted"));

    }

    @And("^Click on 'Submit' button$")
    public void clickOnSubmitButton() throws Throwable {
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("Ribbon.MyTimesheet.ActionsGroup.SaveButton-Large")));
        driver.findElement(By.id("Ribbon.MyTimesheet.ActionsGroup.SaveButton-Large")).click();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("mytimesheetstatus")));
    }

    @Then("^Timesheet should be submitted$")
    public void timesheetShouldBeSubmitted() throws Throwable {
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("mytimesheetstatus")));
        assertTrue("TimeSheet is not submitted", driver.findElement(By.id("mytimesheetstatus")).getText().contains("Submitted"));
    }

    @Then("^The 'My Timesheet' page should be displayed$")
    public void theMyTimesheetPageShouldBeDisplayed() throws Throwable {
        assertTrue("Verify Timsheet page title", driver.getTitle().contains("My Timesheet"));
    }

    @Then("^Selected task should be displayed in Timesheet page$")
    public void selectedTaskShouldBeDisplayedInTimesheetPage() throws Throwable {
        assertTrue("task not displayed in timesheet", driver.findElement(By.xpath(".//*[@id='TS0Main']/tbody/tr[3]/td[1]/div/div[1]/table/tbody/tr[2]/td[2]")).getText().contains(workassigned));
    }
}