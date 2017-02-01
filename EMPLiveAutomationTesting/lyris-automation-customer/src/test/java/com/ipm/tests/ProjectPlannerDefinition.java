package com.ipm.tests;

import com.ipm.lib.AbstractCoreTest;
import com.ipm.pageobjects.LoginPageObject;
import cucumber.api.java.en.And;
import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;
import org.openqa.selenium.*;
import org.openqa.selenium.interactions.Action;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.ui.ExpectedConditions;
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
    private static WebElement addCellUserTask;
    @Autowired
    protected WebDriver driver;
    LoginPageObject objLogin;

    @When("^execute before conditions")
    public void initilize() {
        LoginStepDefinition.login(driver);
        driver.manage().window().maximize();
    }

    @Given("^I Open project planer url")
    public void openProjectCenter() {
        System.out.println("Open Projectplanner");
        driver.navigate().to("http://qaepmlive6/sites/600/Lists/Project%20Center/Executive%20Summary.aspx");
        driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);
    }

    @Then("^I click on project panel")
    public void clickToLaftpanel() {
        driver.findElement(By.xpath("//*[@href='/sites/site1012/Lists/Project%20Center']")).click();
    }

    @When("^I click on new item")
    public void clickOnNewItem() {
        driver.findElement(By.xpath("//li[@title='New Item']//a//span[@class='dropdown-label']")).click();
        WebDriverWait wait = new WebDriverWait(driver, 30);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath("//*[@title='Project Name Required Field']")));
    }

    @Then("^I enter a Project Name as \"([^\"]*)\"$")
    public void enterProjectName(String ProjectName) {
        createdProjectName = ProjectName + System.currentTimeMillis() / 1000L;
        driver.findElement(By.xpath("//*[@title='Project Name Required Field']"))
                .sendKeys(createdProjectName);
    }

    @Then("^I select project status \"([^\"]*)\"$")
    public void selectProjectStatus(String projectstatus) {
        JavascriptExecutor js = (JavascriptExecutor) driver;
        js.executeScript(
                "$('#State_9602a7d9-37b9-4c13-b279-a52cf3ce9325_$DropDownChoice').val('" + projectstatus + "');");
        js.executeScript("$('#State_9602a7d9-37b9-4c13-b279-a52cf3ce9325_$DropDownChoice').change();");
    }

    @Then("^I select overAll status \"([^\"]*)\"$")
    public void selectOverallHealth(String overallstatus) {
        JavascriptExecutor js = (JavascriptExecutor) driver;
        js.executeScript("$('#OverallHealth_e4b98e4e-a3be-45be-9650-76865191d8c5_$DropDownChoice').val('"
                + overallstatus + "');");
        js.executeScript("$('#OverallHealth_e4b98e4e-a3be-45be-9650-76865191d8c5_$DropDownChoice').change();");
    }

    @Then("^I select Project Update \"([^\"]*)\"$")
    public void selectProjectUpdate(String projectupdate) {
        JavascriptExecutor js = (JavascriptExecutor) driver;
        js.executeScript("$('#ProjectUpdate_1c9b74a6-d9c5-4d4e-9f95-b57fe36f975b_$DropDownChoice').val('"
                + projectupdate + "');");
        js.executeScript("$('#ProjectUpdate_1c9b74a6-d9c5-4d4e-9f95-b57fe36f975b_$DropDownChoice').change();");
    }

    @Then("^I click on save button")
    public void clickingOnSavebutton() {
        driver.findElement(By
                .xpath(".//*[@id='ctl00_ctl36_g_a038f5c9_5a7c_4db2_a4d6_96bbca5d21ea_ctl00_toolBarTbl_RightRptControls_ctl00_ctl00_diidIOSaveItem']"))
                .click();
        WebDriverWait wait = new WebDriverWait(driver, 30);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath("//*[@id='divQuickDetailsHeader']")));
    }

    @Then("^I Click On save button on project edit page")
    public void clickOnSaveButtonOnEditProjectpage() {
        driver.findElement(By
                .xpath("//*[@id='ctl00_ctl36_g_f55c623a_bb6a_4823_ba38_6f0901e5712e_ctl00_toolBarTbl_RightRptControls_ctl00_ctl00_diidIOSaveItem']"))
                .click();
    }

    @Then("^I click on edit button")
    public void clickingOnEditbutton() {
        driver.findElement(By.xpath("//a[@id='Ribbon.ListForm.Display.Manage.EditItem2-Large']")).click();
    }

    @When("^I click on delete button")
    public void clickingOndeletebutton() throws InterruptedException {
        driver.findElement(By.xpath(".//*[@id='Ribbon.ListForm.Display.Manage.DeleteItem-Medium']/span[2]")).click();
        Thread.sleep(5000);
    }

    @Then("^I accept delete popup")
    public void acceptDelete() throws InterruptedException {
        driver.switchTo().alert().accept();
        Thread.sleep(5000);
    }

    @Then("^ I verify new item element")
    public void verifyNewItemElement() {
        driver.findElement(By.xpath("//li[@title='New Item']//a//span[@class='dropdown-label']")).isDisplayed();
    }

    @And("^I Click on Item menu")
    public void ClickOnItem() {
        driver.findElement(By.xpath(".//*[@id='Ribbon.ListItem-title']/a/span[1]")).click();
        WebDriverWait wait = new WebDriverWait(driver, 30);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("Ribbon.ListItem.New")));
    }

    @And("^I am selecting any oneproject")
    public void selectOneProject() {
        Actions action = new Actions(driver).doubleClick(driver.findElement(By.xpath(
                ".//*[@id='GanttGrid0Main']/tbody/tr[2]/td[1]/div/div[2]/table/tbody/tr[3]/td/table/tbody/tr[2]/td[1]")));
        action.build().perform();
    }

    @And("^I Click on edit plan menu")
    public void editPlan() {
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript("window.document.getElementById('Ribbon.ListItem.EPMLive.Planner-Large').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        WebDriverWait wait = new WebDriverWait(driver, 30);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("dialogTitleSpan")));
    }

    @And("^I Click on project planner")
    public void clickOnProjectPlaner() {
        driver.switchTo().frame(1);
        driver.findElement(By.xpath("//a[2]")).click();
        WebDriverWait wait = new WebDriverWait(driver, 30);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("Ribbon.WorkPlanner.ResourcesGroup.EditTeam-Medium")));
    }

    @When("^I Click on edit team")
    public void clicOnEditTeam() {
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript("window.document.getElementById('Ribbon.WorkPlanner.ResourcesGroup.EditTeam-Medium').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        driver.switchTo().frame(1);
        WebDriverWait wait = new WebDriverWait(driver, 30);
        wait.until(ExpectedConditions.presenceOfElementLocated(By.xpath(".//*[@id='Ribbon.BuildTeam-title']/a/span[1]")));
    }

    @When("^I am selecting the first user from the list")
    public void selectFirstUser() {
        driver.switchTo().defaultContent();
        driver.switchTo().frame(1);
        WebElement element = driver.findElement(By.xpath(
                ".//*[@id='ResourceGrid']/tbody/tr[3]/td[1]/div/div[1]/table/tbody/tr[2]/td[3]"));
        Actions builder = new Actions(driver);
        Action actn = builder.moveToElement(element).click().doubleClick().sendKeys("test").build();
        actn.perform();
        driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);
    }

    @And("^I Click on add user button")
    public void clickOnAddUser() {
        driver.findElement(By.xpath(".//*[@id='parentId']/tbody/tr/td[2]/input[1]")).click();
        driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);
    }

    @And("^I Click on Save build team")
    public void saveBuildTeam() throws InterruptedException {
        if (driver instanceof JavascriptExecutor) {
            JavascriptExecutor js = (JavascriptExecutor) driver;
            js.executeScript(
                    "window.document.getElementById('Ribbon.BuildTeam.StandardGroup.SaveCloseButton-Large').click()");
        } else {
            System.out.println("This driver does not support JavaScript!");
        }
        WebDriverWait wait = new WebDriverWait(driver, 30);
        wait.until(ExpectedConditions.presenceOfElementLocated(By.id("DeltaPlaceHolderPageTitleInTitleArea")));
    }

    @When("^I Click on add tasks")
    public void clickOnAddTask() throws InterruptedException {
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
        List<WebElement> webElements = driver.findElements(By.xpath(".//*[@id='WorkPlannerGrid']/tbody/tr[3]/td[1]/div/div[2]/table/tbody/tr[3]/td/table/tbody/tr"));
        webElements.get(webElements.size() - 1).findElement(By.xpath("./td[4]")).click();
        Thread.sleep(5000);
        driver.findElement(By.xpath(".//*[@id='Grid6FocusCursors']/div[1]/div/input")).sendKeys(task + System.currentTimeMillis() / 1000L);
        //     driver.findElement(By.xpath(".//*[@id='Grid6FocusCursors']/div[1]/div/input")).sendKeys(Keys.RETURN);
        Thread.sleep(5000);
    }

    @Then("^I Click on user cell")
    public void clickOnUserCell() throws InterruptedException {
        List<WebElement> webElements = driver.findElements(By.xpath(".//*[@id='WorkPlannerGrid']/tbody/tr[3]/td[2]/div/div[2]/table/tbody/tr[3]/td/table/tbody/tr"));
        webElements.get(webElements.size() - 1).findElement(By.xpath("./td[11]")).click();
        Thread.sleep(5000);
        webElements.get(webElements.size() - 1).findElement(By.xpath("./td[11]")).click();
    }

    @Then("^I select user for task")
    public void selectFirstUserForTask() throws InterruptedException {
        driver.findElement(By.xpath("//div[@class='GSMenuItemText GSEnumMenuItemText']")).click();
        Thread.sleep(3000);
        driver.findElement(By.xpath("//*[contains(text(), 'OK')]")).click();
    }

    @Then("^I save a task")
    public void saveTasks() {
        driver.findElement(By.xpath("//*[@id='Ribbon.WorkPlanner.StandardGroup.SaveButton-Large']")).click();
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
    }

    @Then("^I close Task Window")
    public void closeTaskWindow() {
        driver.findElement(By.xpath("//*[@id='Ribbon.WorkPlanner.StandardGroup.CloseButton-Large']")).click();
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
    }

    @Then("^I Click on Edit Resource Planner")
    public void clickOnEditResourcePlanner() {
        Actions action = new Actions(driver)
                .doubleClick(driver.findElement(By.id("Ribbon.ListItem.Manage.EPKResourcePlanner-Large")));
        action.build().perform();
    }

    public void searchForCreatedProject(String projectname) {
        driver.findElement(By.xpath(".//*[@id='actionmenu0Main']/div/ul[2]/li[1]/a/span")).click();
        WebDriverWait wait = new WebDriverWait(driver, 30);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath("//*[@id='searchtext0Main']")));
        driver.findElement(By.xpath("//*[@id='searchtext0Main']")).click();
        driver.findElement(By.xpath("//*[@id='searchtext0Main']")).sendKeys(projectname);
        driver.findElement(By.xpath("//*[@id='searchtext0Main']")).sendKeys(Keys.RETURN);
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
    }

    public void selectFirstProject() {
        Actions action = new Actions(driver).doubleClick(driver.findElement(
                By.xpath("//*[@id='GanttGrid0Main']/tbody/tr[2]/td[1]/div/div[2]/table/tbody/tr[2]/td[1]")));
        action.build().perform();
    }

    @Then("^I select user \"([^\"]*)\"$")
    public void selectFirstUserInResourcePlanner(String username) throws InterruptedException {
        Thread.sleep(10000);
        driver.switchTo().frame(1);
        // mouseClickById("idResourcesTab_ShowFilters");
        mouseClickByxpath("//*[@id='g_Res']/tbody/tr[3]/td[3]/div/div[1]/table/tbody/tr[2]/td[2]");
        WebElement element = driver
                .findElement(By.xpath("//[@id='g_Res']/tbody/tr[3]/td[3]/div/div[1]/table/tbody/tr[2]/td[2]"));

        JavascriptExecutor executor = (JavascriptExecutor) driver;
        executor.executeScript("arguments[0].click();", element);
        // js.executeScript("$('#ctl00_ctl36_g_f55c623a_bb6a_4823_ba38_6f0901e5712e_ctl00_toolBarTbltop_RightRptControls_ctl01_ctl00_diidIOSaveItem').click()");
        driver.findElement(By.xpath("//*[@id='g_Res']/tbody/tr[1]/td[3]/div/table/tbody/tr[3]/td[3]")).click();
        driver.findElement(By.xpath("//*[@id='g_Res']/tbody/tr[1]/td[3]/div/table/tbody/tr[3]/td[3]"))
                .sendKeys(username);
        driver.findElement(By.xpath("//*[@id='g_Res']/tbody/tr[3]/td[3]/div/div[1]/table/tbody/tr[2]/td[2]")).click();
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
    }

    @Then("^I click on add user in project planner")
    public void clickOnAddUserInResourcePlanner() {
        driver.findElement(By.xpath(".//*[@id='g_Res']/tbody/tr[3]/td[3]/div/div[1]/table/tbody/tr[2]/td[2]")).click();
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
    }

    @Then("^I enter hours in grid \"([^\"]*)\"$")
    public void enterHoursInGrid(String Hours) {
        for (int i = 1; i <= 15; i++) {
            driver.findElement(By
                    .xpath(".//*[@id='g_RPE']/tbody/tr[3]/td[5]/div/div[1]/table/tbody/tr[3]/td/table/tbody/tr[2]//td["
                            + i + "]"))
                    .click();
            driver.findElement(By.xpath("//*[@id='Grid0FocusCursors']/div[1]/div/input")).sendKeys(Hours);

        }
    }

    @Then("^I click onResourse plannerSave button")
    public void clickOnSaveButtonInResourcePlaner() {
        driver.findElement(By.xpath("//*[@id='SavePlanBtn']")).click();
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
        driver.switchTo().alert().accept();
    }

    @Then("^I click on set public ok button")
    public void clickOnPublicOKButton() {
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
        Thread.sleep(20000);
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
        assertEquals("Project Not Saved", createdProjectName, driver.findElement(By.xpath("//div[@class='dispFormFancyTitle']/span")).getText());
    }

    @Then("^The project created must be deleted$")
    public void theProjectCreatedMustBeDeleted() {
        searchForCreatedProject(createdProjectName);
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
        WebDriverWait wait = new WebDriverWait(driver, 30);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.xpath(".//*[@id='Ribbon.BuildTeam-title']/a/span[1]")));
        assertEquals("Title of Build Team page not appeared", "BUILD TEAM", driver.findElement(By.xpath(".//*[@id='Ribbon.BuildTeam-title']/a/span[1]")).getText());
    }

    @Then("^The tasks page should be displayed$")
    public void theTasksPageShouldBeDisplayed() {
        WebDriverWait wait = new WebDriverWait(driver, 30);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("DeltaPlaceHolderPageTitleInTitleArea")));
        if (!driver.findElements(By.id("DeltaPlaceHolderPageTitleInTitleArea")).isEmpty()) {
            assertTrue("Tasks page displayed", true);
        } else {
            assertTrue("Tasks page not displayed", false);
        }
    }

    @Then("^The Select Planner Page should be displayed$")
    public void theSelectPlannerPageShouldBeDisplayed() {
        WebDriverWait wait = new WebDriverWait(driver, 30);
        wait.until(ExpectedConditions.visibilityOfElementLocated(By.id("dialogTitleSpan")));
        assertEquals("Title of Select Planner Pop-up", "Select Planner", driver.findElement(By.id("dialogTitleSpan")).getText());
    }
}