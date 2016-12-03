package com.ipm.tests;

import java.awt.RenderingHints.Key;
import java.util.List;
import java.util.Properties;
import java.util.Random;
import java.util.concurrent.TimeUnit;

import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.Capabilities;
import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.interactions.Action;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.interactions.Keyboard;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.Select;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;

import com.ipm.lib.AbstractCoreTest;
import com.ipm.lib.AbstractPage;
import com.ipm.pageobjects.LoginPageObject;
import com.thoughtworks.selenium.webdriven.commands.KeyEvent;

import cucumber.api.java.Before;
import cucumber.api.java.en.And;
import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;
import lombok.extern.log4j.Log4j;

@ContextConfiguration(classes = { AbstractCoreTest.class })

public class ProjectPlannerDefinition {

	LoginPageObject objLogin;

	@Autowired
	protected WebDriver driver;

	@When("^execute before conditions")
	public void initilize() {
		LoginStepDefinition.login(driver);
		driver.manage().window().maximize();
	}

	@Given("^I Open project planer url")
	public void openProjectCenter() {
		System.out.println("Open Projectplanner");
		driver.navigate().to("http://qaepmlive6/sites/600/Lists/Project%20Center/Executive%20Summary.aspx");
		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

	}

	@Then("^I click on project panel")
	public void clickToLaftpanel() {
		driver.findElement(By.xpath("//*[@href='/sites/site1012/Lists/Project%20Center']")).click();
	}

	@Then("^I click on new item")
	public void clickOnNewItem() {
		driver.findElement(By.xpath("//li[@title='New Item']//a//span[@class='dropdown-label']")).click();
	}

	@Then("^I enter ProjectName \"([^\"]*)\"$")

	public void enterProjectName(String ProjectName) {

		driver.findElement(By.xpath("//*[@title='Project Name Required Field']"))
				.sendKeys(ProjectName + System.currentTimeMillis() / 1000L);

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
	public void clickingOndeletebutton() {
		driver.findElement(By.xpath(".//*[@id='Ribbon.ListForm.Display.Manage.DeleteItem-Medium']/span[2]")).click();
	}

	@Then("^I accept delete popup")
	public void acceptDelete() {
		driver.switchTo().alert().accept();
	}

	@Then("^ I verify new item element")
	public void verifyNewItemElement() {
		driver.findElement(By.xpath("//li[@title='New Item']//a//span[@class='dropdown-label']")).isDisplayed();
	}

	@Then("^I Click on Item menu")
	public void ClickOnItem() {
		driver.findElement(By.xpath(".//*[@id='Ribbon.ListItem-title']/a/span[1]")).click();
		driver.manage().timeouts().implicitlyWait(15, TimeUnit.SECONDS);
		System.out.println(driver);

	}

	@Then("^I am selecting any oneproject")
	public void selectOneProject() {

		Actions action = new Actions(driver).doubleClick(driver.findElement(By.xpath(
				".//*[@id='GanttGrid0Main']/tbody/tr[2]/td[1]/div/div[2]/table/tbody/tr[3]/td/table/tbody/tr[2]/td[1]")));
		action.build().perform();
	}

	@Then("^I Click on edit plan menu")
	public void editPlan() {
		JavascriptExecutor js = (JavascriptExecutor) driver;
		js.executeScript("window.document.getElementById('Ribbon.ListItem.EPMLive.Planner-Large').click()");

	}

	@Then("^I Click on project planner")
	public void clickOnProjectPlaner() {
		driver.switchTo().frame(1);
		driver.findElement(By.xpath("//a[2]")).click();
		driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);

	}

	@Then("^I Click on edit team")
	public void clicOnEditTeam() {
		JavascriptExecutor js = (JavascriptExecutor) driver;
		js.executeScript("window.document.getElementById('Ribbon.WorkPlanner.ResourcesGroup.EditTeam-Medium').click()");
	}

	@Then("^I am selecting fist user from list")
	public void selectFirstUser() {
		driver.switchTo().frame(1);
		WebElement element = driver.findElement(By.xpath(
				".//*[@id='WorkPlannerGrid']/tbody/tr[3]/td[1]/div/div[2]/table/tbody/tr[3]/td/table/tbody/tr[2]/td[3]"));
		Actions builder = new Actions(driver);
		Action actn = builder.moveToElement(element).click().doubleClick().sendKeys("test").build();
		actn.perform();
		driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);

	}

	@Then("^I Click on add user button")
	public void clickOnAddUser() {
		driver.findElement(By.xpath(".//*[@id='parentId']/tbody/tr/td[2]/input[1]")).click();
	}

	@Then("^I Click on Save build team")
	public void saveBuildTeam() throws InterruptedException {
		JavascriptExecutor js = (JavascriptExecutor) driver;
		js.executeScript(
				"window.document.getElementById('Ribbon.BuildTeam.StandardGroup.SaveCloseButton-Large').click()");
		Thread.sleep(50000);
	}

	@Then("^I Click on add tasks")
	public void clickOnAddTask() {
		driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);
		JavascriptExecutor js = (JavascriptExecutor) driver;
		js.executeScript("window.document.getElementById('Ribbon.WorkPlanner.InsertGroup.AddTask-Large').click()");
	}

	@Then("^I enter task name \"([^\"]*)\"$")
	public void enterTaskName(String task) {
		Actions action = new Actions(driver).doubleClick(driver.findElement(By.xpath(
				"//*[@id='WorkPlannerGrid']/tbody/tr[3]/td[1]/div/div[2]/table/tbody/tr[3]/td/table/tbody/tr[2]/td[3]")));
		action.build().perform();
		driver.findElement(By.xpath("//div[@class='GSEditCellInput']"))
				.sendKeys(task + System.currentTimeMillis() / 1000L);
		;

	}

	@Then("^I Click on user cell")
	public void clickOnUserCell() {
		driver.findElement(By
				.xpath("//div[@class='GridMain2']//td[@class='GSClassEdit GSClassFocusedCell GSEnum GSCell GSEnumRight GSEmpty GSCellBorderFF3 HideCol7AssignedTo'][8]"))
				.click();
	}

	@Then("^I select user for task")
	public void selectFirstUserForTask() {
		driver.findElement(By.xpath(".//*[@id='GM0_1']/div/div")).click();
		driver.findElement(By.xpath(".//*[@id='TreeGridControls']/div/div/div[8]/div/div[2]/button[2]")).click();

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
		driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
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
}
