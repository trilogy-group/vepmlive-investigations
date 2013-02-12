using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Data;
using System.Threading;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [JobStep("WE43Upgrader", 30)]

    public class AddListData : Step
    {
        public AddListData(SPWeb spWeb, string data, int stepNumber, bool bispfe)
            : base(spWeb, data, stepNumber, bispfe)
        {
        }

        public override string Description
        {
            get { return "Updating List Data"; }
        }

        public override bool Perform()
        {
            LogMessage("Loading Resource Pool List");

            SPList oResourcePool = SPWeb.Lists.TryGetList("Resources");

            if(oResourcePool == null)
            {
                LogMessage("", "Resources list missing", 3);
            }
            else
            {
                ProcessResources(oResourcePool);
                ProcessRoles(oResourcePool);
                ProcessWorkHours(oResourcePool);
                ProcessHolidays(oResourcePool);
                ProcessDepartments(oResourcePool);
                ProcessNonWork(oResourcePool);
            }


            return true;
        }

        private void ProcessResources(SPList oResourcePool)
        {
            SPField MAPID = null;

            try
            {
                MAPID = oResourcePool.Fields.GetFieldByInternalName("MAPID");
            }
            catch { }

            
            if(MAPID != null)
            {
                LogMessage("Processing Resource Pool MAPID");

                foreach(SPListItem spListItem in oResourcePool.Items)
                {
                    SPListItem li = oResourcePool.GetItemById(spListItem.ID);

                    try
                    {
                        if(li["MAPID"] != null && li["MAPID"].ToString() != "")
                        {
                            li["EXTID"] = li["MAPID"];
                        }
                        li.Update();

                    }
                    catch(Exception ex)
                    {
                        LogMessage("\t", "(" + li.Title + "): " + ex.Message, 3);
                    }
                }
            }
        }

        private void ProcessNonWork(SPList oResourcePool)
        {

            LogMessage("Processing Non Work");

            SPList oNonWork = SPWeb.Lists.TryGetList("Non Work");
            SPList oTimeOff = SPWeb.Lists.TryGetList("Time Off");

            if(oNonWork == null)
            {
                LogMessage("", "Non Work list missing", 3);
            }
            else if(oTimeOff == null)
            {
                LogMessage("", "Time Off list missing", 3);
            }
            else
            {

                DataTable dt = oNonWork.Items.GetDataTable();

                SPField oField = oTimeOff.Fields.GetFieldByInternalName("TimeOffType");

                if(oField.Type == SPFieldType.Choice)
                {

                    SPFieldChoice oChoice = (SPFieldChoice)oField;

                    foreach(string choice in oChoice.Choices)
                    {
                        try
                        {
                            DataRow[] dr = dt.Select("Title='" + choice + "'");
                            if(dr.Length == 0)
                            {

                                SPListItem li = oNonWork.Items.Add();
                                li["Title"] = choice;
                                li.Update();

                                LogMessage("\t" + choice);
                            }
                        }
                        catch(Exception ex)
                        {
                            LogMessage("", choice + ": " + ex.Message, 3);
                        }
                    }
                }
            }
        }

        private void ProcessRoles(SPList oResourcePool)
        {
            LogMessage("Processing Roles");

            SPList oRoles = SPWeb.Lists.TryGetList("Roles");

            if(oRoles != null)
            {
                if(bIsPfe)
                {
                    LogMessage("\tReading Roles from PfE");

                    try
                    {
                        SPListItem li = oRoles.Items.Add();
                        li["Title"] = "TEMPROLEDELETEME";
                        li.Update();

                        var bErrored = false;
                        var iCounter = 0;

                        while (!bErrored && iCounter < 5)
                        {
                            try
                            {
                                li.Delete();
                                Thread.Sleep(1000);
                            }
                            catch
                            {
                                bErrored = true;
                            }
                            finally
                            {
                                iCounter++;
                            }
                        }

                        int itemToDeleteId = 0;

                        SPListItemCollection spListItemCollection = oRoles.Items;
                        foreach (SPListItem spListItem in spListItemCollection)
                        {
                            if (spListItem["Title"].Equals("TEMPROLEDELETEME"))
                            {
                                itemToDeleteId = spListItem.ID;
                            }
                        }

                        if (itemToDeleteId != 0)
                        {
                            SPListItem spListItem = oRoles.GetItemById(itemToDeleteId);
                            spListItem.Delete();
                        }
                    }
                    catch(Exception ex)
                    {
                        LogMessage("", "Error: " + ex.Message, 3);
                    }
                }
                else
                {
                    LogMessage("\tReading Roles from Resource Pool");

                    SPField oField = null;
                    try
                    {
                        oField = oResourcePool.Fields.GetFieldByInternalName("Role");
                    }
                    catch { }
                    if(oField != null)
                    {
                        if(oField.Type == SPFieldType.Lookup)
                        {
                            LogMessage("", "Roles Field already upgraded", 2);
                        }
                        else if(oField.Type == SPFieldType.Choice)
                        {
                            try
                            {
                                DataTable dt = oRoles.Items.GetDataTable(); 
                                
                                SPFieldChoice oC = (SPFieldChoice)oField;
                                foreach(string s in oC.Choices)
                                {
                                    DataRow[] dr = (dt == null ? new DataRow[0] : dt.Select("Title='" + s + "'"));

                                    if(dr.Length <= 0)
                                    {
                                        LogMessage("\tAdd: " + s);
                                        SPListItem li = oRoles.Items.Add();
                                        li["Title"] = s;
                                        li.Update();
                                    }
                                    else
                                    {
                                        LogMessage("\t", "Add: " + s, 2);
                                    }
                                }
                            }
                            catch(Exception ex)
                            {
                                LogMessage("", "Error: " + ex.Message, 3);
                            }
                        }
                        else
                        {
                            LogMessage("", "Roles Field not a choice field", 2);
                        }
                    }
                    else
                    {
                        LogMessage("", "Roles Field missing from resource pool", 3);
                    }                  
                }
            }
            else
            {
                LogMessage("", "Roles list missing", 3);
            }
        }

        private void ProcessDepartments(SPList oResourcePool)
        {
            LogMessage("Processing Departments");

            SPList oDepartments = SPWeb.Lists.TryGetList("Departments");

            if(oDepartments != null)
            {
                if(bIsPfe)
                {
                    LogMessage("\tReading Departments from PfE");

                    try
                    {
                        SPListItem liRes = oResourcePool.Items[0];

                        SPFieldLookupValue lv = new SPFieldLookupValue(liRes.ID, liRes.Title);

                        SPListItem li = oDepartments.Items.Add();
                        li["Title"] = "TEMPDEPTDELETEME";
                        li["Managers"] = lv;
                        li.Update();

                        var bErrored = false;
                        var iCounter = 0;

                        while (!bErrored && iCounter < 5)
                        {
                            try
                            {
                                li.Delete();
                                Thread.Sleep(1000);
                            }
                            catch
                            {
                                bErrored = true;
                            }
                            finally
                            {
                                iCounter++;
                            }
                        }

                        int itemToDeleteId = 0;

                        SPListItemCollection spListItemCollection = oDepartments.Items;
                        foreach (SPListItem spListItem in spListItemCollection)
                        {
                            if (spListItem["Title"].Equals("TEMPDEPTDELETEME"))
                            {
                                itemToDeleteId = spListItem.ID;
                            }
                        }

                        if (itemToDeleteId != 0)
                        {
                            SPListItem spListItem = oDepartments.GetItemById(itemToDeleteId);
                            spListItem.Delete();
                        }
                    }
                    catch(Exception ex)
                    {
                        LogMessage("", "Error: " + ex.Message, 3);
                    }
                }
                else
                {
                    LogMessage("\tReading Departments from Resource Pool");

                    SPField oField = null;
                    try
                    {
                        oField = oResourcePool.Fields.GetFieldByInternalName("Department");
                    }
                    catch { }
                    if(oField != null)
                    {
                        if(oField.Type == SPFieldType.Lookup)
                        {
                            LogMessage("", "Departments Field already upgraded", 2);
                        }
                        else if(oField.Type == SPFieldType.Choice)
                        {
                            try
                            {
                                DataTable dt = oDepartments.Items.GetDataTable();

                                SPFieldChoice oC = (SPFieldChoice)oField;
                                foreach(string s in oC.Choices)
                                {
                                    DataRow[] dr = (dt == null ? new DataRow[0] : dt.Select("Title='" + s + "'"));

                                    if(dr.Length <= 0)
                                    {
                                        LogMessage("\tAdd: " + s);
                                        SPListItem li = oDepartments.Items.Add();
                                        li["Title"] = s;
                                        li.Update();
                                    }
                                    else
                                    {
                                        LogMessage("\t", "Add: " + s, 2);
                                    }
                                }
                            }
                            catch(Exception ex)
                            {
                                LogMessage("", "Error: " + ex.Message, 3);
                            }
                        }
                        else
                        {
                            LogMessage("", "Departments Field not a choice field", 2);
                        }
                    }
                    else
                    {
                        LogMessage("", "Department Field missing from resource pool", 3);
                    }
                }
            }
            else
            {
                LogMessage("", "Departments list missing", 3);
            }
        }

        private void ProcessWorkHours(SPList oResourcePool)
        {
            LogMessage("Processing Work Hours");

            SPList oWorkHours = SPWeb.Lists.TryGetList("Work Hours");

            if(oWorkHours != null)
            {
                if(bIsPfe)
                {
                    LogMessage("\tReading Work Hours from PfE");

                    try
                    {
                        SPListItem li = oWorkHours.Items.Add();
                        li["Title"] = "TEMPWORKDELETEME";
                        li["Monday"] = 8;
                        li["Tuesday"] = 8;
                        li["Wednesday"] = 8;
                        li["Thursday"] = 8;
                        li["Friday"] = 8;
                        li["Saturday"] = 0;
                        li["Sunday"] = 0;
                        li.Update();
                        li.Delete();
                    }
                    catch(Exception ex)
                    {
                        LogMessage("", "Error: " + ex.Message, 3);
                    }
                }
                else
                {
                    if(oWorkHours.Items.Count == 0)
                    {

                        LogMessage("\tAdding default work hours");

                        try
                        {
                            SPListItem li = oWorkHours.Items.Add();
                            li["Title"] = "US Work Hours";
                            li["Monday"] = 8;
                            li["Tuesday"] = 8;
                            li["Wednesday"] = 8;
                            li["Thursday"] = 8;
                            li["Friday"] = 8;
                            li.Update();
                        }
                        catch(Exception ex)
                        {
                            LogMessage("", "Error: " + ex.Message, 3);
                        }
                    }
                }
            }
            else
            {
                LogMessage("", "WorkHours list missing", 3);
            }
        }

        private void ProcessHolidays(SPList oResourcePool)
        {
            LogMessage("Processing Holidays");

            SPList oHolidays = SPWeb.Lists.TryGetList("Holidays");
            SPList oHolidaySchedules = SPWeb.Lists.TryGetList("Holiday Schedules");

            if(oHolidays == null)
            {
                LogMessage("", "Holidays list missing", 3);
            }
            else if(oHolidaySchedules == null)
            {
                LogMessage("", "Holiday Schedules list missing", 3);
            }
            else
            {
                if(bIsPfe)
                {
                    LogMessage("\tReading Holidays from PfE");

                    try
                    {
                        SPListItem li = oHolidaySchedules.Items.Add();
                        li["Title"] = "TEMPScheduleDELETEME";
                        li.Update();

                        var bErrored = false;
                        var iCounter = 0;

                        while (!bErrored && iCounter < 5)
                        {
                            try
                            {
                                li.Delete();
                                Thread.Sleep(1000);
                            }
                            catch
                            {
                                bErrored = true;
                            }
                            finally
                            {
                                iCounter++;
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        LogMessage("", ex.Message, 3);
                    }
                }
                else
                {
                    LogMessage("\tAdding Holiday Schedule");

                    SPFieldLookupValue lv = null;

                    try
                    {
                        if(oHolidaySchedules.Items.Count == 0)
                        {
                            SPListItem li = oHolidaySchedules.Items.Add();
                            li["Title"] = "US Holidays";
                            li.Update();

                            lv = new SPFieldLookupValue(li.ID, li.Title);
                        }
                        else
                        {
                            SPListItem li = oHolidaySchedules.Items[0];
                            lv = new SPFieldLookupValue(li.ID, li.Title);
                        }
                    }
                    catch(Exception ex)
                    {
                        LogMessage("", "Error: " + ex.Message, 3);
                    }

                    SPField oHSField = null;
                    try
                    {
                        oHSField = oHolidays.Fields.GetFieldByInternalName("HolidaySchedule");
                    }catch{}

                    if(lv != null && oHSField != null)
                    {
                        LogMessage("\tAdding Holidays To Schedule");

                        foreach(SPListItem li in oHolidays.Items)
                        {
                            if(li[oHSField.Id] == null)
                            {
                                LogMessage("\t\t" + li.Title);
                                li[oHSField.Id] = lv;
                                li.Update();
                            }
                            else
                            {
                                LogMessage("\t", li.Title, 2);
                            }
                        }
                    }
                }
            }
        }
    }
}
