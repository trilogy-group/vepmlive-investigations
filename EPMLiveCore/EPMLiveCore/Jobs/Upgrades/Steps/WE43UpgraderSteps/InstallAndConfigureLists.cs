using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using EPMLiveReportsAdmin;
using Microsoft.SharePoint;
using System.Net;
using System.Security.Cryptography;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [JobStep("WE43Upgrader", 10)]
    public class InstallAndConfigureLists : Step
    {
        private string storeurl = "";
        private SPDocumentLibrary solutions;

        public InstallAndConfigureLists(SPWeb spWeb, string data, int stepNumber, bool bispfe)
            : base(spWeb, data, stepNumber, bispfe)
        {
        }

        public override string Description
        {
            get { return "Install and Configure Lists"; }
        }

        public override bool Perform()
        {
            storeurl = CoreFunctions.getFarmSetting("workenginestore");

            solutions = (SPDocumentLibrary)base.SPWeb.Site.GetCatalog(SPListTemplateType.ListTemplateCatalog);

            LogMessage("Activating List Features");

            SPSite.Features.Add(new Guid("e08e676e-81fb-497e-9590-9d1c2673b85c"), true);


            //==============================================================
            LogMessage("Removing old settings list");

            try
            {
                SPList settings = SPWeb.Lists.TryGetList("EPM Live Settings");

                if(settings != null)
                    settings.Delete();
            }
            catch(Exception ex)
            {
                LogMessage("", ex.Message, 3);
            }

            //==============================================================

            LogMessage("Downloading and Installing List Templates");

            DownloadAndInstallList("Departments", "Departments", "Departments");
            DownloadAndInstallList("HolidaySchedules", "HolidaySchedules", "Holiday Schedules");
            DownloadAndInstallList("Holidays", "Holidays", "Holidays");

            if(base.bIsPfe)
                DownloadAndInstallList("EPM Live Settings", "pfe epm live settings", "EPM Live Settings");
            else
                DownloadAndInstallList("EPM Live Settings", "epm live settings", "EPM Live Settings");

            DownloadAndInstallList("Roles", "Roles", "Roles");
            DownloadAndInstallList("WorkHours", "WorkHours", "Work Hours");
            DownloadAndInstallList("Time Off", "TimeOff", "Time Off");
            //==============================================================


            LogMessage("Checking Holidays Lookup");

            SPList oHolidays = SPWeb.Lists.TryGetList("Holidays");
            SPList oHolidaySchedules = SPWeb.Lists.TryGetList("Holiday Schedules");
            SPList oResourcePool = SPWeb.Lists.TryGetList("Resources");

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
                SPField oField = null;
                try
                {
                    oField = oHolidays.Fields.GetFieldByInternalName("HolidaySchedule");
                }
                catch { }

                if(oField == null)
                {
                    LogMessage("\tCreating Holidays Lookup");

                    oField = oHolidays.Fields.GetFieldByInternalName(oHolidays.Fields.AddLookup("HolidaySchedule", oHolidaySchedules.ID, true));
                    oField.Title = "Holiday Schedule";
                    oField.Update();

                    var spFieldLookup = (SPFieldLookup)oField;
                    spFieldLookup.LookupField = "Title";
                    spFieldLookup.Update();
                }
                else
                {
                    LogMessage("\tUpdating Holidays Lookup");

                    SPFieldLookup oLookup = (SPFieldLookup)oField;
                    if(new Guid(oLookup.LookupList) != oHolidaySchedules.ID)
                    {
                        oField.Delete();
                        oHolidays.Update();
                        oField = oHolidays.Fields.GetFieldByInternalName(oHolidays.Fields.AddLookup("HolidaySchedule", oHolidaySchedules.ID, true));
                        oField.Title = "Holiday Schedule";
                        oField.Update();

                        var spFieldLookup = (SPFieldLookup) oField;
                        spFieldLookup.LookupField = "Title";
                        spFieldLookup.Update();
                    }

                }

                oHolidays.Update();
            }

            //Fixing Department Lookup

            SPList oDepartments = SPWeb.Lists.TryGetList("Departments");

            if(oDepartments == null)
            {
                LogMessage("", "Departments list missing", 3);
            }
            else
            {
                LogMessage("Departments list lookups");

                try
                {
                    SPFieldLookup lookup = (SPFieldLookup)oDepartments.Fields.GetFieldByInternalName("RBS");
                    if(new Guid(lookup.LookupList) != oDepartments.ID)
                    {
                        bool bSealed = lookup.Sealed;
                        if(bSealed)
                        {
                            lookup.Sealed = false;
                            lookup.Update();
                        }
                        lookup.AllowDeletion = true;
                        lookup.Update();
                        lookup.Delete();

                        oDepartments.Fields.AddLookup("RBS", oDepartments.ID, false);

                        lookup = (SPFieldLookup)oDepartments.Fields.GetFieldByInternalName("RBS");

                        

                        lookup.LookupField = "DisplayName";
                        lookup.Title = "Parent Department";
                        lookup.Update();

                        if(bSealed)
                        {
                            lookup.Sealed = true;
                            lookup.Update();
                        }

                        LogMessage("\tField RBS");
                    }
                }
                catch(Exception ex)
                {
                    LogMessage("", "Field RBS: " + ex.Message, 3);
                }

                try
                {
                    SPFieldLookup lookup = (SPFieldLookup)oDepartments.Fields.GetFieldByInternalName("Managers");
                    if(new Guid(lookup.LookupList) != oResourcePool.ID)
                    {
                        bool bSealed = lookup.Sealed;
                        if(bSealed)
                        {
                            lookup.Sealed = false;
                            lookup.Update();
                        }
                        lookup.AllowDeletion = true;
                        lookup.Update();
                        lookup.Delete();

                        oDepartments.Fields.AddLookup("Managers", oResourcePool.ID, true);

                        lookup = (SPFieldLookup)oDepartments.Fields.GetFieldByInternalName("Managers");
                        
                        

                        lookup.LookupField = "Title";
                        lookup.Update();

                        if(bSealed)
                        {
                            lookup.Sealed = true;
                            lookup.Update();
                        }

                        LogMessage("\tField Managers");
                    }
                }
                catch(Exception ex)
                {
                    LogMessage("", "Field Managers: " + ex.Message, 3);
                }

                try
                {
                    SPFieldLookup lookup = (SPFieldLookup)oDepartments.Fields.GetFieldByInternalName("Executives");
                    if(new Guid(lookup.LookupList) != oResourcePool.ID)
                    {
                        bool bSealed = lookup.Sealed;
                        if(bSealed)
                        {
                            lookup.Sealed = false;
                            lookup.Update();
                        }
                        lookup.AllowDeletion = true;
                        lookup.Update();
                        lookup.Delete();

                        oDepartments.Fields.AddLookup("Executives", oResourcePool.ID, false);

                        lookup = (SPFieldLookup)oDepartments.Fields.GetFieldByInternalName("Executives");

                        lookup.LookupField = "Title";
                        lookup.Update();

                        if(bSealed)
                        {
                            lookup.Sealed = true;
                            lookup.Update();
                        }

                        LogMessage("\tField Executives");
                    }
                }
                catch(Exception ex)
                {
                    LogMessage("", "Field Executives: " + ex.Message, 3);
                }
            }


            LogMessage("Processing Time Off Temp Data");

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

                if(!oTimeOff.Fields.ContainsFieldWithInternalName("TempType"))
                {

                    oTimeOff.Fields.Add("TempType", SPFieldType.Text, false);
                    oTimeOff.Update();

                    try
                    {
                        SPField oField = oTimeOff.Fields.GetFieldByInternalName("TempType");
                        oField.ShowInDisplayForm = false;
                        oField.ShowInEditForm = false;
                        oField.ShowInNewForm = false;
                        oField.Update();
                    }
                    catch { }
                }

                SPField oTimeOffType = null;
                try
                {
                    oTimeOffType = oTimeOff.Fields.GetFieldByInternalName("TimeOffType");
                }
                catch { }

                if(oTimeOffType != null && oTimeOffType.Type == SPFieldType.Choice)
                {
                    LogMessage("\tProcessing Temp Items");

                    foreach(SPListItem li in oTimeOff.Items)
                    {
                        try
                        {
                            li["TempType"] = li[oTimeOffType.Id].ToString();
                            li.Update();
                        }
                        catch(Exception ex)
                        {
                            LogMessage("\t", li.Title  + ": " + ex.Message, 3);
                        }
                    }

                    
                }

                SPField oWorkDetail = null;
                try
                {
                    oWorkDetail = oTimeOff.Fields.GetFieldByInternalName("WorkDetail");
                }
                catch { }

                if(oWorkDetail == null)
                {
                    
                    try
                    {
                        
                        oTimeOff.Fields.AddFieldAsXml(@"<Field Type=""DaysHoursBreakdownField"" DisplayName=""WorkDetail"" Required=""FALSE"" EnforceUniqueValues=""FALSE"" StaticName=""WorkDetail"" Name=""WorkDetail"" ><Customization><ArrayOfProperty><Property><Name>StartDateField</Name><Value xmlns:q1=""http://www.w3.org/2001/XMLSchema"" p4:type=""q1:string"" xmlns:p4=""http://www.w3.org/2001/XMLSchema-instance"">StartDate</Value></Property><Property><Name>FinishDateField</Name><Value xmlns:q2=""http://www.w3.org/2001/XMLSchema"" p4:type=""q2:string"" xmlns:p4=""http://www.w3.org/2001/XMLSchema-instance"">DueDate</Value></Property><Property><Name>HoursField</Name><Value xmlns:q3=""http://www.w3.org/2001/XMLSchema"" p4:type=""q3:string"" xmlns:p4=""http://www.w3.org/2001/XMLSchema-instance"">Work</Value></Property><Property><Name>HolidaySchedulesField</Name><Value xmlns:q4=""http://www.w3.org/2001/XMLSchema"" p4:type=""q4:string"" xmlns:p4=""http://www.w3.org/2001/XMLSchema-instance"">HolidaySchedule</Value></Property><Property><Name>ResourcePoolList</Name><Value xmlns:q5=""http://www.w3.org/2001/XMLSchema"" p4:type=""q5:string"" xmlns:p4=""http://www.w3.org/2001/XMLSchema-instance"">Resources</Value></Property><Property><Name>WorkHoursList</Name><Value xmlns:q6=""http://www.w3.org/2001/XMLSchema"" p4:type=""q6:string"" xmlns:p4=""http://www.w3.org/2001/XMLSchema-instance"">Work Hours</Value></Property><Property><Name>HolidaysList</Name><Value xmlns:q7=""http://www.w3.org/2001/XMLSchema"" p4:type=""q7:string"" xmlns:p4=""http://www.w3.org/2001/XMLSchema-instance"">Holidays</Value></Property></ArrayOfProperty></Customization></Field>");
                        SPField oField = oTimeOff.Fields.GetFieldByInternalName("WorkDetail");
                        oField.Title = "Work Detail";
                        oField.Update();

                        LogMessage("\tAdd Work Detail Field");
                    }
                    catch(Exception ex)
                    {
                        LogMessage("", "Add Work Detail: " + ex.Message, 3);
                    }
                }
            }

            try
            {
                if(!oResourcePool.Fields.ContainsFieldWithInternalName("EXTID"))
                {
                    oResourcePool.Fields.Add("EXTID", SPFieldType.Text, false);
                    SPField oField = oResourcePool.Fields.GetFieldByInternalName("EXTID");
                    oField.Hidden = true;
                    oField.Update();

                    LogMessage("Add EXTID Field to Resources");
                }
            }
            catch(Exception ex)
            {
                LogMessage("", "Add EXTID Field to Resources: " + ex.Message, 3);
            }

            //Process dept event

            LogMessage("Processing Department Events");

            try
            {
                bool badding = false;
                bool bupdating = false;
                bool bdeleted = false;

                string sClass = "EPMLiveCore.DepartmentEvent";
                string sAssembly = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";

                foreach(SPEventReceiverDefinition e in oDepartments.EventReceivers)
                {
                    if(e.Assembly == sAssembly && e.Class == sClass)
                    {
                        if(e.Type == SPEventReceiverType.ItemAdding)
                            badding = true;
                        else if(e.Type == SPEventReceiverType.ItemUpdating)
                            bupdating = true;
                        else if (e.Type == SPEventReceiverType.ItemDeleted)
                            bdeleted = true;
                    }
                }

                if(!badding)
                {
                    oDepartments.EventReceivers.Add(SPEventReceiverType.ItemAdding, sAssembly, sClass);
                    oDepartments.Update();
                }

                if(!bupdating)
                {
                    oDepartments.EventReceivers.Add(SPEventReceiverType.ItemUpdating, sAssembly, sClass);
                    oDepartments.Update();
                }
                if (!bdeleted)
                {
                    oDepartments.EventReceivers.Add(SPEventReceiverType.ItemDeleted, sAssembly, sClass);
                    oDepartments.Delete();
                }
            }
            catch(Exception ex)
            {
                LogMessage("", ex.Message, 3);
            }

            LogMessage("Mapping Reporting lists.");

            var reportData = new ReportData(SPSite.ID);
            DataTable dbMappings = reportData.GetDbMappings();

            if (!dbMappings.Select(string.Format("SiteId = '{0}'", SPSite.ID)).Any())
            {
                LogMessage("", "Reporting is not configured.", 2);
            }
            else
            {
                try
                {
                    var reportBiz = new ReportBiz(SPSite.ID, SPSite.WebApplication.Id);

                    reportBiz.GetDatabaseMappings();

                    foreach (var list in new[] { "Work Hours", "Holiday Schedules", "Holidays", "Time Off" })
                    {
                        try
                        {
                            LogMessage("Mapping " + list + " list to Reporting.");

                            SPList spList = SPWeb.Lists[list];

                            ListBiz listBiz = reportBiz.CreateListBiz(spList.ID);

                            if (string.IsNullOrEmpty(listBiz.ListName))
                            {
                                reportBiz.CreateListBiz(spList.ID);
                                LogMessage("", "Mapped successfully.", 1);
                            }
                            else
                            {
                                LogMessage("", "Already mapped.", 2);
                            }
                        }
                        catch (Exception ex)
                        {
                            LogMessage("", ex.Message, 3);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogMessage("", ex.Message, 3);
                }
            }

            return true;
        }

        private void DownloadAndInstallList(string listname, string template, string displayname)
        {
            LogMessage(listname);

            try
            {
                LogMessage("\tDownloading");
                using(WebClient webClient = new WebClient())
                {
                    ServicePointManager.ServerCertificateValidationCallback +=
                    delegate(
                        object sender,
                        X509Certificate certificate,
                        X509Chain chain,
                        SslPolicyErrors sslPolicyErrors)
                    {
                        return true;

                    };

                    webClient.Credentials = CoreFunctions.GetStoreCreds();
                    byte[] fileBytes = null;
                    fileBytes = webClient.DownloadData(storeurl + "/43Upgrade/" + template + ".stp");
                    SPFile f = solutions.RootFolder.Files.Add("43" + template + ".stp", fileBytes, true);
                    SPListItem li = f.GetListItem();
                    li["Title"] = "43" + template;
                    li.Update();
                }


                if(SPWeb.Lists.TryGetList(displayname) == null)
                {
                    LogMessage("\tCreating");

                    SPListTemplateCollection lc = SPSite.GetCustomListTemplates(SPWeb);
                    SPListTemplate temp = lc["43" + template ];

                    Guid list = SPWeb.Lists.Add(listname, "", temp);

                    SPList oList = SPWeb.Lists[list];
                    oList.Title = displayname;
                    oList.Hidden = true;
                    oList.Update();
                }
                else
                {
                    LogMessage("\tNot Creating ", listname + ": List exists", 2);
                }
               
            }
            catch(Exception ex)
            {
                LogMessage("", ex.Message, 3);
            }
        }
    }
}
