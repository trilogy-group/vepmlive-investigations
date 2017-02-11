package com.ipm.tests;

import com.ipm.lib.AbstractCoreTest;
import com.ipm.pageobjects.LoginPageObject;
import cucumber.api.java.After;
import cucumber.api.java.en.And;
import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;
import junit.framework.TestCase;
import org.junit.Before;
import org.openqa.selenium.*;
import org.openqa.selenium.interactions.Action;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.Select;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;

import java.util.List;
import java.util.Set;
import java.util.concurrent.TimeUnit;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

@ContextConfiguration(classes = {AbstractCoreTest.class})

public class ProjectPlannerDefinition {

    private static String createdProjectName;
    private static String createdTask;
    private static WebElement addCellUserTask;
    private static String userTobeAdded;
    @Autowired
    protected WebDriver driver;
    LoginPageObject objLogin;

    @Before
    public void zoomOut() {
        WebElement html = driver.findElement(By.tagName("html"));
        html.sendKeys(Keys.chord(Keys.CONTROL, Keys.SUBTRACT));
    }

    @After
    public void closeAllBrowsersAfter() throws Exception {
        try {
            Set<String> windows = driver.getWindowHandles();
            String[] winNames = new String[windows.size()];
            int i = 0;
            for (String window : windows) {
                winNames[i] = window;
                i++;
            }
            if (winNames.length > 1) {
                for (i = winNames.length; i > 1; i--) {
                    driver.switchTo().window(winNames[i - 1]);
                    driver.close();
                }
            }
            driver.switchTo().window(winNames[0]);
            Thread.sleep(2000);
            driver.manage().timeouts().implicitlyWait(2, TimeUnit.SECONDS);

            driver.quit();
        } catch (Exception e) {
            System.out.println("remote browser may have already died");
        }
    }

    @Given("^execute before conditions")
    public void initilize() {
        LoginStepDefinition.login(driver);
        driver.manage().window().maximize();
    }

    @Given("^I Open project planer url")
    public void openProjectCenter() {
        System.out.println("Open Projectplanner");

        driver.navigate().to("http://qaepmlive6/Lists/Project%20Center/Executive%20Summary.aspx");
        driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);
    }

    @Then("^I click on project panel")
    public void clickToLaftpanel() throws InterruptedException {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.id("EPMLiveNavt3")));
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript("window.document.getElementById('EPMLiveNavt3').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        wait.until(ExpectedConditions.titleIs("Project Center - Executive Summary"));
//        Thread.sleep(10000);
    }

    @When("^I click on new item")
    public void clickOnNewItem() {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath("//li[@title='New Item']//a//span[@class='dropdown-label']")));
        driver.findElement(By.xpath("//li[@title='New Item']//a//span[@class='dropdown-label']")).click();
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath("//*[@title='Project Name Required Field']")));
    }

    @Then("^I enter a Project Name as \"([^\"]*)\"$")
    public void enterProjectName(String ProjectName) {
        checkPageIsReady();
        createdProjectName = ProjectName + System.currentTimeMillis() / 1000L;
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath("//*[@title='Project Name Required Field']")));
        driver.findElement(By.xpath("//*[@title='Project Name Required Field']"))
                .sendKeys(createdProjectName);
    }

    @Then("^I select project status \"([^\"]*)\"$")
    public void selectProjectStatus(String projectstatus) {
        checkPageIsReady();
        JavascriptExecutor js = (JavascriptExecutor) driver;
        js.executeScript(
                "$('#State_9602a7d9-37b9-4c13-b279-a52cf3ce9325_$DropDownChoice').val('" + projectstatus + "');");
        js.executeScript("$('#State_9602a7d9-37b9-4c13-b279-a52cf3ce9325_$DropDownChoice').change();");
    }

    @Then("^I select Overall Health \"([^\"]*)\"$")
    public void selectOverallHealth(String overallstatus) {
        checkPageIsReady();
        JavascriptExecutor js = (JavascriptExecutor) driver;
        js.executeScript("$('#OverallHealth_e4b98e4e-a3be-45be-9650-76865191d8c5_$DropDownChoice').val('"
                + overallstatus + "');");
        js.executeScript("$('#OverallHealth_e4b98e4e-a3be-45be-9650-76865191d8c5_$DropDownChoice').change();");
    }

    @Then("^I select Project Update \"([^\"]*)\"$")
    public void selectProjectUpdate(String projectupdate) {
        checkPageIsReady();
        JavascriptExecutor js = (JavascriptExecutor) driver;
        js.executeScript("$('#ProjectUpdate_1c9b74a6-d9c5-4d4e-9f95-b57fe36f975b_$DropDownChoice').val('"
                + projectupdate + "');");
        js.executeScript("$('#ProjectUpdate_1c9b74a6-d9c5-4d4e-9f95-b57fe36f975b_$DropDownChoice').change();");
    }

    @Then("^I click on save button")
    public void clickingOnSavebutton() {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='ctl00_ctl36_g_a038f5c9_5a7c_4db2_a4d6_96bbca5d21ea_ctl00_toolBarTbl_RightRptControls_ctl00_ctl00_diidIOSaveItem']")));

        driver.findElement(By
                .xpath(".//*[@id='ctl00_ctl36_g_a038f5c9_5a7c_4db2_a4d6_96bbca5d21ea_ctl00_toolBarTbl_RightRptControls_ctl00_ctl00_diidIOSaveItem']"))
                .click();

        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath("//*[@id='divQuickDetailsHeader']")));
    }

    @Then("^I Click On save button on project edit page")
    public void clickOnSaveButtonOnEditProjectpage() {
        driver.findElement(By
                .xpath("//*[@id='ctl00_ctl36_g_f55c623a_bb6a_4823_ba38_6f0901e5712e_ctl00_toolBarTbl_RightRptControls_ctl00_ctl00_diidIOSaveItem']"))
                .click();
    }

    @Then("^I click on edit button")
    public void clickingOnEditbutton() throws InterruptedException {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath("//a[@id='Ribbon.ListForm.Display.Manage.EditItem2-Large']")));
        driver.findElement(By.xpath("//a[@id='Ribbon.ListForm.Display.Manage.EditItem2-Large']")).click();
        try {
            wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath("//*[@id='ctl00_ctl36_g_f55c623a_bb6a_4823_ba38_6f0901e5712e_ctl00_ctl04_ctl01_ctl00_ctl00_ctl07_upLevelDiv']")));
            System.out.println("I click on edit button : " + driver.getTitle());
        } catch (Exception e) {
            if (driver.findElements(By.xpath("//a[@id='Ribbon.ListForm.Display.Manage.EditItem2-Large']")).isEmpty()) {
                wait.until(ExpectedConditions.elementToBeClickable(By.xpath("//a[@id='Ribbon.ListForm.Display.Manage.EditItem2-Large']")));
                driver.findElement(By.xpath("//a[@id='Ribbon.ListForm.Display.Manage.EditItem2-Large']")).click();
                System.out.println("edit button Not working for the first time : " + driver.getTitle());
            }
            System.out.println("I click on edit button : " + "Exit without clicking on edit button");
        }
        Thread.sleep(5000);
    }

    @When("^I click on delete button")
    public void clickingOndeletebutton() throws InterruptedException {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='Ribbon.ListForm.Display.Manage.DeleteItem-Medium']/span[2]")));
        driver.findElement(By.xpath(".//*[@id='Ribbon.ListForm.Display.Manage.DeleteItem-Medium']/span[2]")).click();
        Thread.sleep(5000);
    }

    @Then("^I accept delete popup")
    public void acceptDelete() throws InterruptedException {
        try {
            driver.switchTo().alert().accept();
        } catch (Exception e) {
            System.out.println("Alert Not Present");
        }
        Thread.sleep(5000);
    }

    @Then("^ I verify new item element")
    public void verifyNewItemElement() {
        driver.findElement(By.xpath("//li[@title='New Item']//a//span[@class='dropdown-label']")).isDisplayed();
    }

    @And("^I Click on Item menu")
    public void ClickOnItem() {
        System.out.println("I click on Item Menu");
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='Ribbon.ListItem-title']/a/span[1]")));
        driver.findElement(By.xpath(".//*[@id='Ribbon.ListItem-title']/a/span[1]")).click();
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("Ribbon.ListItem.New")));
    }

    @And("^I am selecting any oneproject")
    public void selectOneProject() throws InterruptedException {
        System.out.println("I am selecting any oneproject");
        searchForCreatedProject(createdProjectName);
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='GanttGrid0Main']/tbody/tr[2]/td[1]/div/div[2]/table/tbody/tr[3]/td/table/tbody/tr[3]/td/table/tbody/tr[2]/td[1]")));
        Thread.sleep(5000);

        Actions action = new Actions(driver).doubleClick(driver.findElement(By.xpath(
                ".//*[@id='GanttGrid0Main']/tbody/tr[2]/td[1]/div/div[2]/table/tbody/tr[3]/td/table/tbody/tr[3]/td/table/tbody/tr[2]/td[1]")));
        action.build().perform();
    }

    @And("^I Click on edit plan menu")
    public void editPlan() throws InterruptedException {
        checkPageIsReady();
        System.out.println("I Click on edit plan menu");
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.id("Ribbon.ListItem.EPMLive.Planner-Large")));
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;

            js.executeScript("window.document.getElementById('Ribbon.ListItem.EPMLive.Planner-Large').click()");

        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        try {
            wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("dialogTitleSpan")));
        } catch (Exception e) {
            if (!driver.findElements(By.id("Ribbon.ListItem.EPMLive.Planner-Large")).isEmpty()) {
                if (driver instanceof JavascriptExecutor) {
                    JavascriptExecutor js = (JavascriptExecutor) driver;
                    js.executeScript("window.document.getElementById('Ribbon.ListItem.EPMLive.Planner-Large').click()");

                } else {
                    System.out.println("This driver does not support JavaScript!");
                }
                wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("dialogTitleSpan")));
            }
            System.out.print("I Click on edit plan menu : Exception on clicking on");
        }
    }

    @And("^I Click on project planner")
    public void clickOnProjectPlaner() {
        checkPageIsReady();
        System.out.println("I Click on project planner");
        driver.switchTo().frame(1);
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath("//a[2]")));
        driver.findElement(By.xpath("//a[2]")).click();
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath(".//*[@id='ctl00_PlaceHolderMain_pnlTemplate']/div[1]/a[1]/table/tbody/tr/td")));
    }

    @When("^I Click on edit team")
    public void clicOnEditTeam() throws InterruptedException {
        checkPageIsReady();
        System.out.println("I Click on edit team");
        Thread.sleep(5000);
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.id("Ribbon.WorkPlanner.ResourcesGroup.EditTeam-Medium")));
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript("window.document.getElementById('Ribbon.WorkPlanner.ResourcesGroup.EditTeam-Medium').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        driver.switchTo().frame(1);
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='Ribbon.BuildTeam-title']/a/span[1]")));
    }

    @When("^I am selecting the first user from the list")
    public void selectFirstUser() {
        checkPageIsReady();
        driver.switchTo().defaultContent();
        driver.switchTo().frame(1);
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='ResourceGrid']/tbody/tr[3]/td[1]/div/div[1]/table/tbody/tr[2]/td[1]")));
        WebElement element = driver.findElement(By.xpath(".//*[@id='ResourceGrid']/tbody/tr[3]/td[1]/div/div[1]/table/tbody/tr[2]/td[1]"));
        Actions builder = new Actions(driver);
        Action actn = builder.moveToElement(element).click().sendKeys("test").build();
        actn.perform();
        driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);
    }

    @And("^I Click on add user button")
    public void clickOnAddUser() {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='parentId']/tbody/tr/td[2]/input[1]")));
        driver.findElement(By.xpath(".//*[@id='parentId']/tbody/tr/td[2]/input[1]")).click();
        driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);
    }

    @And("^I Click on Save build team")
    public void saveBuildTeam() throws InterruptedException {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.id("Ribbon.BuildTeam.StandardGroup.SaveCloseButton-Large")));
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript(
                    "window.document.getElementById('Ribbon.BuildTeam.StandardGroup.SaveCloseButton-Large').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("DeltaPlaceHolderPageTitleInTitleArea")));
    }

    @When("^I Click on add tasks")
    public void clickOnAddTask() throws InterruptedException {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.id("Ribbon.WorkPlanner.InsertGroup.AddTask-Large")));
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript("window.document.getElementById('Ribbon.WorkPlanner.InsertGroup.AddTask-Large').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        Thread.sleep(5000);
    }

    @Then("^I enter task name \"([^\"]*)\"$")
    public void enterTaskName(String task) throws InterruptedException {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='WorkPlannerGrid']/tbody/tr[3]/td[1]/div/div[2]/table/tbody/tr[3]/td/table/tbody/tr")));
        List<WebElement> webElements = driver.findElements(By.xpath(".//*[@id='WorkPlannerGrid']/tbody/tr[3]/td[1]/div/div[2]/table/tbody/tr[3]/td/table/tbody/tr"));
        webElements.get(webElements.size() - 1).findElement(By.xpath("./td[4]")).click();
        Thread.sleep(5000);
        createdTask = task + System.currentTimeMillis() / 1000L;
        System.out.println("Created task : " + createdTask);
        driver.findElement(By.xpath(".//*[@id='Grid6FocusCursors']/div[1]/div/input")).sendKeys(createdTask);
        Thread.sleep(5000);
    }

    @Then("^I Click on user cell")
    public void clickOnUserCell() throws InterruptedException {
        checkPageIsReady();
        List<WebElement> webElements = driver.findElements(By.xpath(".//*[@id='WorkPlannerGrid']/tbody/tr[3]/td[2]/div/div[2]/table/tbody/tr[3]/td/table/tbody/tr"));
        Thread.sleep(5000);
        webElements.get(webElements.size() - 1).findElement(By.xpath("./td[8]")).click();
        Thread.sleep(5000);
    }

    @Then("^I select user for task")
    public void selectFirstUserForTask() throws InterruptedException {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath("//div[@class='GSMenuItemText GSEnumMenuItemText']")));
        driver.findElement(By.xpath("//div[@class='GSMenuItemText GSEnumMenuItemText']")).click();
        Thread.sleep(5000);
        driver.findElement(By.xpath("//*[contains(text(), 'OK')]")).click();
    }

    @Then("^I save a task")
    public void saveTasks() throws InterruptedException {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath("//*[@id='Ribbon.WorkPlanner.StandardGroup.SaveButton-Large']")));
        driver.findElement(By.xpath("//*[@id='Ribbon.WorkPlanner.StandardGroup.SaveButton-Large']")).click();
        Thread.sleep(10000);
    }

    @Then("^I close Task Window")
    public void closeTaskWindow() {
        driver.findElement(By.xpath("//*[@id='Ribbon.WorkPlanner.StandardGroup.CloseButton-Large']")).click();
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
    }

    @Then("^I Click on Edit Resource Planner")
    public void clickOnEditResourcePlanner() throws InterruptedException {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.id("Ribbon.ListItem.Manage.EPKResourcePlanner-Large")));
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript("window.document.getElementById('Ribbon.ListItem.Manage.EPKResourcePlanner-Large').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        try {
            wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("dialogTitleSpan")));
        } catch (Exception e) {
            if (driver instanceof JavascriptExecutor) {
                JavascriptExecutor js = (JavascriptExecutor) driver;
                js.executeScript("window.document.getElementById('Ribbon.ListItem.Manage.EPKResourcePlanner-Large').click()");
            } else {
                System.out.println("This driver does not support JavaScript!");
            }
            wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("dialogTitleSpan")));
        }
    }

    public void searchForCreatedProject(String projectname) {
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath(".//*[@id='actionmenu0Main']/div/ul[2]/li[1]/a/span")));
        driver.findElement(By.xpath(".//*[@id='actionmenu0Main']/div/ul[2]/li[1]/a/span")).click();
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath("//*[@id='searchtext0Main']")));
        driver.findElement(By.xpath("//*[@id='searchtext0Main']")).click();
        driver.findElement(By.xpath("//*[@id='searchtext0Main']")).sendKeys(projectname);
        driver.findElement(By.xpath("//*[@id='searchtext0Main']")).sendKeys(Keys.RETURN);
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
    }

    public void searchForCreatedTask(String projectname) throws InterruptedException {
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='actionmenu1Main']/div/ul[2]/li[1]/a/span")));
        driver.findElement(By.xpath(".//*[@id='actionmenu1Main']/div/ul[2]/li[1]/a/span")).click();
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath("//*[@id='searchtext1Main']")));
//        driver.findElement(By.xpath("//*[@id='searchtext1Main']")).click();
        driver.findElement(By.xpath("//*[@id='searchtext1Main']")).clear();
        driver.findElement(By.xpath("//*[@id='searchtext1Main']")).sendKeys(projectname);
        driver.findElement(By.xpath("//*[@id='searchtext1Main']")).sendKeys(Keys.RETURN);
        Thread.sleep(5000);
    }

    public void selectFirstProject() {
        Actions action = new Actions(driver).doubleClick(driver.findElement(
                By.xpath("//*[@id='GanttGrid0Main']/tbody/tr[2]/td[1]/div/div[2]/table/tbody/tr[2]/td[1]")));
        action.build().perform();
    }

    @Then("^I select one user$")
    public void selectFirstUserInResourcePlanner() throws InterruptedException {
        checkPageIsReady();
        Thread.sleep(5000);
//        List<WebElement> iframes = driver.findElements(By.tagName("iframe"));
//        for (WebElement iframe : iframes) {
//            driver.switchTo().defaultContent();
//            driver.switchTo().frame(iframe);
//            System.out.println("webdriver size  :" + driver.findElements(By.xpath(".//*[@id='g_Res']/tbody/tr[3]/td[3]/div/div[1]/table/tbody/tr[3]/td[2]")).size());
//        }
        driver.switchTo().defaultContent();
        driver.switchTo().frame(1);
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='g_Res']/tbody/tr[3]/td[3]/div/div[1]/table/tbody/tr[3]/td[3]")));
        driver.findElement(By.xpath(".//*[@id='g_Res']/tbody/tr[3]/td[3]/div/div[1]/table/tbody/tr[3]/td[3]")).click();
        userTobeAdded = driver.findElement(By.xpath(".//*[@id='g_Res']/tbody/tr[3]/td[3]/div/div[1]/table/tbody/tr[3]/td[3]")).getText();
    }

    @Then("^I click on add user in project planner")
    public void clickOnAddUserInResourcePlanner() throws InterruptedException {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("ResAddBtn")));
        driver.findElement(By.id("ResAddBtn")).click();
        Thread.sleep(5000);
    }

    @Then("^I enter hours in grid \"([^\"]*)\"$")
    public void enterHoursInGrid(String Hours) throws InterruptedException {
        checkPageIsReady();
        driver.switchTo().defaultContent();
        List<WebElement> iframes = driver.findElements(By.tagName("iframe"));
        for (WebElement iframe : iframes) {
            driver.switchTo().defaultContent();
            Thread.sleep(1000);
            driver.switchTo().frame(iframe);
            Thread.sleep(1000);
            if (!driver.findElements(By.xpath(".//*[@id='g_RPE']/tbody/tr[3]/td[3]/div/div[1]/table/tbody/tr[3]/td/table/tbody/tr[2]/td[3]")).isEmpty()) {
                driver.findElement(By.xpath(".//*[@id='g_RPE']/tbody/tr[3]/td[3]/div/div[1]/table/tbody/tr[3]/td/table/tbody/tr[2]/td[3]")).click();
            }
        }
        WebDriverWait wait = new WebDriverWait(driver, 60);
        JavascriptExecutor executor = (JavascriptExecutor) driver;
        Thread.sleep(2000);
        executor.executeScript("window.document.getElementById('SpreadBtn').click()");
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("idSpreadAmount")));
        Select select = new Select(driver.findElement(By.id("idSpreadFinishPeriod")));
        select.selectByValue("Q47");
        Thread.sleep(2000);
        driver.findElement(By.xpath(".//*[@id='idSpreadDlgObj']/div/div[2]/div/input[1]")).click();
        driver.findElement(By.xpath(".//*[@id='idSpreadDlgObj']/div/div[2]/div/input[2]")).click();
    }

    @Then("^I click onResourse plannerSave button")
    public void clickOnSaveButtonInResourcePlaner() {
        checkPageIsReady();
        driver.findElement(By.id("SavePlanBtn")).click();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='idPrivateRowsDlg']/div[2]/input[1]")));
    }

    @Then("^I click on set public ok button")
    public void clickOnPublicOKButton() {
        checkPageIsReady();
        driver.findElement(By.xpath(".//*[@id='idPrivateRowsDlg']/div[2]/input[1]")).click();
    }

    @Then("^I click on Resource planner Close button")
    public void closeResourcePlanner() {
        driver.findElement(By.xpath(".//*[@id='CloseBtn']")).click();
    }

    @Then("^I enter project cost \"([^\"]*)\"$")
    public void enterProjectCost(String projectcost) {
        driver.findElement(
                By.xpath(".//*[@id='ProjectActualCost_851f0f4c-b798-4feb-8798-1853625d82fa_$CurrencyField']"))
                .clear();
        driver.findElement(
                By.xpath(".//*[@id='ProjectActualCost_851f0f4c-b798-4feb-8798-1853625d82fa_$CurrencyField']"))
                .sendKeys(projectcost);
    }

    @Then("^Icreate project with default values")
    public String createProjectWithDefaultValues(String projectname) {
        projectname = projectname + (System.currentTimeMillis() / 1000l);
        openProjectCenter();
        clickOnNewItem();
        enterProjectName(projectname);
        clickingOnSavebutton();
        openProjectCenter();
        return projectname;

    }

    @Then("^I create project with defaultvalues and selectproject in projectsfolder \"([^\"]*)\"$")
    public void createAndSelectProject(String projectname) throws InterruptedException {
        searchForCreatedProject(createProjectWithDefaultValues(projectname));
        Thread.sleep(10000);
        ClickOnItem();
        selectFirstProject();
    }

    @Then("^Save edited project")
    public void saveEditedProject() {
        JavascriptExecutor js = (JavascriptExecutor) driver;
        js.executeScript(
                "$('#ctl00_ctl36_g_f55c623a_bb6a_4823_ba38_6f0901e5712e_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem').click()");
    }

    public void mouseClickById(String id) {
        Actions action = new Actions(driver).doubleClick(driver.findElement(By.id(id)));
        action.build().perform();
    }

    public void mouseClickByxpath(String xpath) {
        Actions action = new Actions(driver).doubleClick(driver.findElement(By.xpath(xpath)));
        action.build().perform();
    }

    @Then("^The project created must be saved$")
    public void theProjectCreatedMustBeSaved() {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        System.out.print("The project created must be saved   : " + driver.getTitle());
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("ctl00_ctl36_g_caaf5b24_e68c_405e_8d73_605b42be2a51_lblItemTitle")));
        assertEquals("Project Not Saved", createdProjectName, driver.findElement(By.id("ctl00_ctl36_g_caaf5b24_e68c_405e_8d73_605b42be2a51_lblItemTitle")).getText());
    }

    @Then("^The project created must be deleted$")
    public void theProjectCreatedMustBeDeleted() {
        checkPageIsReady();
        searchForCreatedProject(createdProjectName);
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath(".//*[@id='GanttGrid0Main']/tbody/tr[3]/td/div/table/tbody/tr/td/div")));
        assertEquals("Project Not Deleted", "No data found", driver.findElement(By.xpath(".//*[@id='GanttGrid0Main']/tbody/tr[3]/td/div/table/tbody/tr/td/div")).getText());
    }

    @Then("^Close all browsers$")
    public void closeAllBrowsers() throws Exception {
        Set<String> windows = driver.getWindowHandles();
        String[] winNames = new String[windows.size()];
        int i = 0;
        for (String window : windows) {
            winNames[i] = window;
            i++;
        }
        if (winNames.length > 1) {
            for (i = winNames.length; i > 1; i--) {
                driver.switchTo().window(winNames[i - 1]);
                driver.close();
            }
        }
        driver.switchTo().window(winNames[0]);
        Thread.sleep(2000);
        driver.manage().timeouts().implicitlyWait(2, TimeUnit.SECONDS);
        try {
            driver.quit();
        } catch (Exception e) {
            System.out.println("remote browser may have already died");
        }
    }

    @Then("^The Page Build Team should be displayed$")
    public void thePageBuildTeamShouldBeOpened() {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath(".//*[@id='Ribbon.BuildTeam-title']/a/span[1]")));
        assertEquals("Title of Build Team page not appeared", "BUILD TEAM", driver.findElement(By.xpath(".//*[@id='Ribbon.BuildTeam-title']/a/span[1]")).getText());
    }

    @Then("^The tasks page should be displayed$")
    public void theTasksPageShouldBeDisplayed() throws InterruptedException {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("DeltaPlaceHolderPageTitleInTitleArea")));
        if (!driver.findElements(By.id("DeltaPlaceHolderPageTitleInTitleArea")).isEmpty()) {
            assertTrue("Tasks page displayed", true);
        } else {
            assertTrue("Tasks page not displayed", false);
        }
        Thread.sleep(5000);
    }

    @Then("^The Select Planner Page should be displayed$")
    public void theSelectPlannerPageShouldBeDisplayed() {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("dialogTitleSpan")));
        assertEquals("Title of Select Planner Pop-up", "Select Planner", driver.findElement(By.id("dialogTitleSpan")).getText());
    }

    @And("^I save after editing$")
    public void iClickOnSaveButtonAfterEdit() throws Throwable {
        checkPageIsReady();
        Thread.sleep(5000);
        System.out.print("Enter in I save after editing   : " + driver.getTitle());
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='ctl00_ctl36_g_f55c623a_bb6a_4823_ba38_6f0901e5712e_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem']")));
        driver.findElement(By.xpath(".//*[@id='ctl00_ctl36_g_f55c623a_bb6a_4823_ba38_6f0901e5712e_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem']")).click();
        try {
            wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("ctl00_ctl36_g_caaf5b24_e68c_405e_8d73_605b42be2a51_lblItemTitle")));
            System.out.println("Clic to save after editing ok");
        } catch (Exception e) {
            if (!driver.findElements(By.xpath(".//*[@id='ctl00_ctl36_g_f55c623a_bb6a_4823_ba38_6f0901e5712e_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem']")).isEmpty()) {
                wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='ctl00_ctl36_g_f55c623a_bb6a_4823_ba38_6f0901e5712e_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem']")));
                driver.findElement(By.xpath(".//*[@id='ctl00_ctl36_g_f55c623a_bb6a_4823_ba38_6f0901e5712e_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem']")).click();
                System.out.print("Exception clic on save not working first time");
            }
            System.out.print("Exception click to save after editing");
        }
    }

    @And("^I enter Project Work as \"([^\"]*)\"$")
    public void iEnterProjectWorkAs(String arg0) throws Throwable {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("ProjectWork_39a13b25-4a5c-45f1-8bd8-cae4a338c076_$NumberField")));
        driver.findElement(By.id("ProjectWork_39a13b25-4a5c-45f1-8bd8-cae4a338c076_$NumberField")).clear();
        driver.findElement(By.id("ProjectWork_39a13b25-4a5c-45f1-8bd8-cae4a338c076_$NumberField")).sendKeys(arg0);
    }

    @And("^Project Actual Work as \"([^\"]*)\"$")
    public void projectActualWorkAs(String arg0) throws Throwable {
        checkPageIsReady();
        driver.findElement(By.id("ProjectActualWork_e73d0c0b-5964-4bcf-95bc-ead0218796b4_$NumberField")).clear();
        driver.findElement(By.id("ProjectActualWork_e73d0c0b-5964-4bcf-95bc-ead0218796b4_$NumberField")).sendKeys(arg0);
    }

    @And("^I enter a test as \"([^\"]*)\"$")
    public void iEnterATestAs(String arg0) throws Throwable {
        checkPageIsReady();
        driver.findElement(By.id("test_0507c843-dc05-40cf-bfc6-fac2494ae364_$TextField")).sendKeys(arg0);
    }

    @And("^The values edited should be changed as \"([^\"]*)\" for Project Work  and \"([^\"]*)\" for Actual Work$")
    public void theValuesEditedShouldBeChangedAsForProjectWorkAndForBudget(String arg0, String arg1) throws Throwable {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath(".//*[@id='ctl00_ctl36_g_caaf5b24_e68c_405e_8d73_605b42be2a51_divQuickDetailsContent']/table/tbody/tr/td[2]/table/tbody/tr[5]/td[2]")));
        assertTrue("Changed value of project worker", driver.findElement(By.xpath(".//*[@id='ctl00_ctl36_g_caaf5b24_e68c_405e_8d73_605b42be2a51_divQuickDetailsContent']/table/tbody/tr/td[2]/table/tbody/tr[5]/td[2]")).getText().contains(arg0));
        assertTrue("Changed value of project Budget", driver.findElement(By.xpath(".//*[@id='ctl00_ctl36_g_caaf5b24_e68c_405e_8d73_605b42be2a51_divQuickDetailsContent']/table/tbody/tr/td[2]/table/tbody/tr[6]/td[2]")).getText().contains(arg1));
    }

    @And("^I click on Blank Plan$")
    public void iClickOnBlankPlan() throws Throwable {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='ctl00_PlaceHolderMain_pnlTemplate']/div[1]/a[1]/table/tbody/tr/td")));
        driver.findElement(By.xpath(".//*[@id='ctl00_PlaceHolderMain_pnlTemplate']/div[1]/a[1]/table/tbody/tr/td")).click();
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("Ribbon.WorkPlanner.ResourcesGroup.EditTeam-Medium")));
    }

    @When("^I click on publish$")
    public void iClickOnPublish() throws Throwable {
        checkPageIsReady();
        System.out.println("I click on publish");
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.id("Ribbon.WorkPlanner.StandardGroup.PublishButton-Large")));
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript("window.document.getElementById('Ribbon.WorkPlanner.StandardGroup.PublishButton-Large').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        System.out.println("Publish is enabled :" + driver.findElement(By.id("Ribbon.WorkPlanner.StandardGroup.PublishButton-Large")).isEnabled());
        Thread.sleep(5000);
    }

    @And("^I click on Close Tasks$")
    public void iClickOnCloseTasks() throws Throwable {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='Ribbon.WorkPlanner.StandardGroup.CloseButton-Large']/span[1]/span/img")));
        while (!driver.findElements(By.xpath(".//*[@id='Ribbon.WorkPlanner.StandardGroup.CloseButton-Large']/span[1]/span/img")).isEmpty()) {
            wait.until(ExpectedConditions.elementToBeClickable(By.xpath(".//*[@id='Ribbon.WorkPlanner.StandardGroup.CloseButton-Large']/span[1]/span/img")));
            driver.findElement(By.xpath(".//*[@id='Ribbon.WorkPlanner.StandardGroup.CloseButton-Large']/span[1]/span/img")).click();
        }
    }

    @Then("^The project summary page should be displayed$")
    public void theProjectSummaryPageShouldBeDisplayed() throws Throwable {
        checkPageIsReady();
        assertTrue("Verify Project Page Title", driver.getTitle().contains("Project Center"));
    }

    @When("^I click on Tasks$")
    public void iClickOnTasks() throws Throwable {
        checkPageIsReady();
        System.out.println("I click on Tasks");
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.elementToBeClickable(By.id("EPMLiveNavt4")));
        driver.findElement(By.id("EPMLiveNavt4")).click();
        wait.until(ExpectedConditions.titleIs("Task Center - My Tasks"));
    }

    @Then("^The Tasks Summary page should displayed$")
    public void theTasksSummaryPageShouldDisplayed() throws Throwable {
        checkPageIsReady();
        assertTrue("Verify Tasks Page Title", driver.getTitle().contains("Task Center - My Tasks"));
    }

    @And("^Task created should be saved$")
    public void taskCreatedShouldBeSaved() throws Throwable {
        searchForCreatedTask(createdTask);
//        assertTrue("Task Created Not Saved", !driver.findElements(By.xpath(".//*[@id='GanttGrid1Main']/tbody/tr[2]/td[1]/div/div[2]/table/tbody/tr[3]/td/table/tbody/tr")).isEmpty());
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath("//a[contains(text(), '" + createdTask + "')]")));
        if (!driver.findElements(By.xpath("//a[contains(text(), '" + createdTask + "')]")).isEmpty()) {
            assertTrue("", true);
        } else {
            assertTrue("", false);
        }
    }

    @When("^I click on 'Edit Cost'$")
    public void iClickOnEditCost() throws Throwable {
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript("window.document.getElementById('Ribbon.ListItem.Manage.EPKCosts-Large').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("dialogTitleSpan")));
    }

    @Then("^The cost Planner page should be displayed$")
    public void theCostPlannerPageShouldBeDisplayed() throws Throwable {
        assertTrue("Verify Cost Edit Page", driver.findElement(By.id("dialogTitleSpan")).getText().contains("Cost Planner"));
    }

    @When("^I enter some costs and I click on save button$")
    public void iEnterSomeCostsAndIClickOnSaveButton() throws Throwable {

        Thread.sleep(10000);
        WebDriverWait wait = new WebDriverWait(driver, 60);


        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript("window.document.getElementsByClassName('dhx_tab_element dhx_tab_element_inactive dhx_tab_hover').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }


        List<WebElement> iframes = driver.findElements(By.tagName("iframe"));
        for (WebElement iframe : iframes) {
            driver.switchTo().defaultContent();
            driver.switchTo().frame(iframe);
            System.out.println("---------------:::::::::::::" + driver.findElements(By.xpath(".//*[@id='dhxTabbarObj_beut9z1dQeRo']/div/div[1]/div/div[2]/div[3]")).size());
        }


        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='dhxTabbarObj_W4mtCes4IiNM']/div/div[1]/div/div[2]/span")));
        driver.findElement(By.xpath(".//*[@id='dhxTabbarObj_W4mtCes4IiNM']/div/div[1]/div")).click();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='g_9']/tbody/tr[2]/td[3]/div/div[1]/table/tbody/tr[3]/td/table/tbody/tr[3]/td/table/tbody/tr[2]/td[3]")));
        driver.findElement(By.xpath(".//*[@id='g_9']/tbody/tr[2]/td[3]/div/div[1]/table/tbody/tr[3]/td/table/tbody/tr[3]/td/table/tbody/tr[2]/td[3]")).click();
        driver.findElement(By.xpath(".//*[@id='g_9']/tbody/tr[2]/td[3]/div/div[1]/table/tbody/tr[3]/td/table/tbody/tr[3]/td/table/tbody/tr[2]/td[3]")).sendKeys("10");

        driver.findElement(By.xpath(".//*[@id='dhxTabbarObj_y4wtBLtLY43C']/div/div[1]/div/div[3]/span")).click();
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='g_10']/tbody/tr[2]/td[3]/div/div[1]/table/tbody/tr[3]/td/table/tbody/tr[2]/td[3]")));
        driver.findElement(By.xpath(".//*[@id='g_10']/tbody/tr[2]/td[3]/div/div[1]/table/tbody/tr[3]/td/table/tbody/tr[2]/td[3]")).click();
        driver.findElement(By.xpath(".//*[@id='g_10']/tbody/tr[2]/td[3]/div/div[1]/table/tbody/tr[3]/td/table/tbody/tr[2]/td[3]")).sendKeys("10");

        driver.findElement(By.xpath(".//*[@id='SaveBtn']/span[1]/span/img")).click();
    }

    @And("^I click on Close button in Cost Planner Page$")
    public void iClickOnCloseButtonInCostPlannerPage() throws Throwable {

    }

    @Then("^Cost plan should be displayed$")
    public void costPlanShouldBeDisplayed() throws Throwable {

    }

    @And("^get url$")
    public void getUrl() throws Throwable {
        driver.get("http://qaepmlive6/Lists/Project%20Center/DispForm.aspx?ID=126&Source=http%3a%2f%2fqaepmlive6%2fLists%2fProject%20Center%2fExecutive%20Summary.aspx");
    }

    @Then("^Resource Planner page should be displayed$")
    public void resourcePlannerPageShouldBeDisplayed() throws Throwable {
        checkPageIsReady();
        WebDriverWait wait = new WebDriverWait(driver, 60);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("dialogTitleSpan")));
        assertEquals("Title of Select Planner Pop-up", "Resource Planner - Project Mode", driver.findElement(By.id("dialogTitleSpan")).getText());
    }

    @Then("^Resource should be added to top section$")
    public void resourceShouldBeAddedToTopSection() throws Throwable {
        checkPageIsReady();
        List<WebElement> webElements = driver.findElements(By.xpath(".//*[@id='g_Res']/tbody/tr[3]/td[3]/div/div[1]/table/tbody/tr"));
        if (!webElements.isEmpty()) {
            for (int i = 2; i < webElements.size(); i++) {
                if (webElements.get(i).findElement(By.xpath("./td[3]")).getText().contains(userTobeAdded)) {
                    TestCase.assertTrue("User added in ressource planner", true);
                    break;
                } else {
                    TestCase.assertTrue("User has not added in ressource planner", false);
                }
            }
        } else {
            TestCase.assertTrue("User has not added in ressource planner", false);
        }

    }

    @Then("^Pop up should displayed asking the User if they want to \"([^\"]*)\"$")
    public void popUpShouldDisplayedAskingTheUserIfTheyWantTo(String arg0) throws Throwable {
        checkPageIsReady();
        assertTrue("Title Add ressource pop up", driver.findElement(By.xpath(".//*[@id='ctl00_PlaceHolderMain_ctl00layoutDiv']/div[6]/div/div[3]")).getText().contains(arg0));
    }

    @Then("^The \"([^\"]*)\" mark should turn to a green check mark next to the selected resources on the top grid$")
    public void theMarkShouldTurnToAGreenCheckMarkNextToTheSelectedResourcesOnTheTopGrid(String arg0) throws Throwable {

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