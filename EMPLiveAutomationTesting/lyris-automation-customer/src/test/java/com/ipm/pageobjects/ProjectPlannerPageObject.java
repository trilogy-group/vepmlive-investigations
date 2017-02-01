package com.ipm.pageobjects;

import com.ipm.lib.AbstractPage;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.Select;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.concurrent.TimeUnit;

public class ProjectPlannerPageObject extends AbstractPage {

    @FindBy(xpath = "//li[@title='New Item']//a//span[@class='dropdown-label']")
    WebElement newitem;
    @FindBy(xpath = "//*[@title='Project Name Required Field']")
    WebElement projectnmae;
    @FindBy(xpath = "//*[@title='State Required Field']")
    WebElement projectstatus;
    @FindBy(xpath = "//*[@title='Overall Health Required Field']")
    WebElement overallstatus;
    @FindBy(xpath = "//*[@title='Project Update Required Field']")
    WebElement projectupdate;
    @FindBy(xpath = "//*[@title='Project Update Required Field']")
    WebElement projectsavebutton;
    @FindBy(xpath = "//a[@id='Ribbon.ListForm.Display.Manage.EditItem2-Large']")
    WebElement projecteditbutton;
    @FindBy(xpath = ".//*[@id='Ribbon.ListForm.Display.Manage.DeleteItem-Medium']/span[2]")
    WebElement projectdeletebutton;
    @FindBy(xpath = ".//*[@id='Ribbon.ListItem-title']/a/span[1]")
    WebElement itemmenu;
    @FindBy(xpath = ".//*[@id='ctl00_ctl36_g_a038f5c9_5a7c_4db2_a4d6_96bbca5d21ea_ctl00_toolBarTbl_RightRptControls_ctl00_ctl00_diidIOSaveItem']")
    WebElement savebutton;
    @FindBy(xpath = ".//*[@id='Ribbon.ListItem.EPMLive.Planner-Large']")
    WebElement editplanbutton;
    @FindBy(xpath = "//*[@src='/sites/site1012/_layouts/epmlive/images/planner_online.png']")
    WebElement projectplanner;
    @FindBy(xpath = "//*[@id='Ribbon.WorkPlanner.ResourcesGroup.EditTeam-Medium']/span[2]")
    WebElement edititem;
    @FindBy(xpath = ".//*[@id='parentId']/tbody/tr/td[2]/input[1]")
    WebElement adduserbutton;
    @FindBy(xpath = ".//*[@id='Ribbon.BuildTeam.StandardGroup.SaveCloseButton-Large']")
    WebElement savebuildteambutton;
    @FindBy(xpath = "//*[@id='Ribbon.WorkPlanner.InsertGroup.AddTask-Large']")
    WebElement addtaskbutton;
    @FindBy(xpath = "//div[@class='GSEditCellInput']")
    WebElement taskname;
    @FindBy(xpath = "//div[@class='GridMain2']//td[@class='GSClassEdit GSClassFocusedCell GSEnum GSCell GSEnumRight GSEmpty GSCellBorderFF3 HideCol7AssignedTo'][8]")
    WebElement usercell;
    @FindBy(xpath = "//*[@id='Ribbon.WorkPlanner.StandardGroup.SaveButton-Large']")
    WebElement savetask;
    @FindBy(xpath = "//*[@id='Ribbon.WorkPlanner.StandardGroup.CloseButton-Large']")
    WebElement closetask;
    @FindBy(xpath = "//*[@id='Ribbon.ListItem.Manage.EPKResourcePlanner-Large']")
    WebElement editresourceplanner;
    @FindBy(xpath = "//*[@id='GanttGrid0Main']/tbody/tr[2]/td[1]/div/div[2]/table/tbody/tr[2]/td[1]")
    WebElement firstproject;
    @FindBy(xpath = ".//*[@id='g_Res']/tbody/tr[3]/td[3]/div/div[1]/table/tbody/tr[2]/td[2]")
    WebElement adduserinResourceplanner;
    @FindBy(xpath = "//*[@id='SavePlanBtn")
    WebElement saveplanbutton;
    @FindBy(xpath = ".//*[@id='idPrivateRowsDlg']/div[2]/input[1]")
    WebElement publicokbtn;
    @FindBy(xpath = ".//*[@id='ProjectActualCost_851f0f4c-b798-4feb-8798-1853625d82fa_$CurrencyField']")
    WebElement projectcost;
    @FindBy(xpath = "//*[@id='ResourceGrid']/tbody/tr[3]/td[1]/div/div[1]/table/tbody/tr[2]/td[1]")
    WebElement firstuserinteam;

    @Autowired
    public ProjectPlannerPageObject(WebDriver driver) throws InterruptedException {
        super(driver);
        PageFactory.initElements(driver, this);
    }

    public void clickOnNewItem() {
        newitem.click();
    }

    public void enterProjectName(String projectname) {
        projectnmae.sendKeys(projectname + System.currentTimeMillis() / 1000L);
    }

    public void selectProjectStatus(String projectstatusvalue) {
        Select select = new Select(projectstatus);
        select.selectByValue(projectstatusvalue);
    }

    public void selectOverAllstatus(String overallstatusvalue) {
        Select select = new Select(overallstatus);
        select.selectByValue(overallstatusvalue);
    }

    public void selectProjectUpdateTyep(String projectUpdatetyepvalue) {
        Select select = new Select(projectupdate);
        select.selectByValue(projectUpdatetyepvalue);
    }

    public void clickOnSaveItem() {
        savebutton.click();
    }

    public void clickonProjectEditbutton() {
        projecteditbutton.click();
    }

    public void clickonProjectDeletebutton() {
        projectdeletebutton.click();
    }

    public void clickonItemMenu() {
        itemmenu.click();

    }

    public void clickoneditplanbutton() {
        editplanbutton.click();

    }

    public void clickonProjectPlannerButton() {
        projectplanner.click();
    }

    public void editTeamButton() {
        edititem.click();
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

    }

    public void clickOnFirstUser() {
        firstuserinteam.click();
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

    }

    public void clickOnAddUserbutton() {
        adduserbutton.click();
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);

    }

    public void saveBuildTeamButton() {
        savebuildteambutton.click();
        driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);


    }


    @Override
    public void initializeDriver() {
        // TODO Auto-generated method stub

    }

    @Override
    public void checkSanity() {
        // TODO Auto-generated method stub

    }

    @Override
    public void open() {
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

}
