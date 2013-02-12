using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.SharePoint;
using System.Data;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [JobStep("WE43Upgrader", 40)]

    public class UpdateResourcePool : Step
    {
        public UpdateResourcePool(SPWeb spWeb, string data, int stepNumber, bool bispfe)
            : base(spWeb, data, stepNumber, bispfe)
        {
        }

        public override string Description
        {
            get { return "Updating Resource Pool"; }
        }

        public override bool Perform()
        {
            LogMessage("Loading Resource Pool List");

            SPList oResourcePool = SPWeb.Lists.TryGetList("Resources");
            SPList oRoles = SPWeb.Lists.TryGetList("Roles");
            SPList oDepartments = SPWeb.Lists.TryGetList("Departments");

            if (oResourcePool == null)
            {
                LogMessage("", "Resources list missing", 3);
            }
            else if (oRoles == null)
            {
                LogMessage("", "Roles list missing", 3);
            }
            else if (oDepartments == null)
            {
                LogMessage("", "Departments list missing", 3);
            }
            else
            {
                try
                {
                    DataTable dtRoles = oRoles.Items.GetDataTable();
                    DataTable dtDepartments = oDepartments.Items.GetDataTable();

                    try
                    {
                        if (!oResourcePool.Fields.ContainsFieldWithInternalName("TempRole"))
                        {
                            LogMessage("\tAdding TempRole field");

                            oResourcePool.Fields.Add("TempRole", SPFieldType.Text, false);

                            SPField oField = oResourcePool.Fields.GetFieldByInternalName("TempRole");
                            oField.ShowInDisplayForm = false;
                            oField.ShowInEditForm = false;
                            oField.ShowInNewForm = false;
                            oField.Update();
                        }
                    }
                    catch (Exception ex) { LogMessage("\t", "Adding TempRole field: " + ex.Message, 3); }

                    try
                    {
                        if (!oResourcePool.Fields.ContainsFieldWithInternalName("TempDept"))
                        {
                            LogMessage("\tAdding TempDept field");

                            oResourcePool.Fields.Add("TempDept", SPFieldType.Text, false);

                            SPField oField = oResourcePool.Fields.GetFieldByInternalName("TempDept");
                            oField.ShowInDisplayForm = false;
                            oField.ShowInEditForm = false;
                            oField.ShowInNewForm = false;
                            oField.Update();
                        }
                    }
                    catch (Exception ex) { LogMessage("\t", "Adding TempDept field: " + ex.Message, 3); }

                    oResourcePool.Update();

                    bool bProcessRole = false;
                    bool bProcessDept = false;

                    try
                    {
                        if (oResourcePool.Fields.GetFieldByInternalName("Role").Type == SPFieldType.Choice)
                            bProcessRole = true;
                    }
                    catch { }
                    try
                    {
                        if (oResourcePool.Fields.GetFieldByInternalName("Department").Type == SPFieldType.Choice)
                            bProcessDept = true;
                    }
                    catch { }

                    SPField oFieldRole;
                    SPField oFieldDept;

                    try
                    {
                        oFieldRole = oResourcePool.Fields.GetFieldByInternalName("Role");
                    }
                    catch
                    {
                        SPField newField = oResourcePool.Fields.CreateNewField(SPFieldType.Choice.ToString(), "Role");
                        oResourcePool.Fields.Add(newField);
                        oResourcePool.Update();

                        oFieldRole = oResourcePool.Fields.GetFieldByInternalName("Role");
                    }

                    try
                    {
                        oFieldDept = oResourcePool.Fields.GetFieldByInternalName("Department");
                    }
                    catch
                    {
                        SPField newField = oResourcePool.Fields.CreateNewField(SPFieldType.Choice.ToString(), "Department");
                        oResourcePool.Fields.Add(newField);
                        oResourcePool.Update();

                        oFieldDept = oResourcePool.Fields.GetFieldByInternalName("Department");
                    }

                    if (bProcessRole || bProcessDept)
                    {

                        LogMessage("\tCopying Temporary Data");

                        foreach (SPListItem li in oResourcePool.Items)
                        {
                            try
                            {
                                if (bProcessDept && li[oFieldDept.Id] != null && oFieldDept.Type == SPFieldType.Choice)
                                {
                                    li["TempDept"] = li[oFieldDept.Id].ToString();
                                }

                                if (bProcessDept && li[oFieldRole.Id] != null && oFieldRole.Type == SPFieldType.Choice)
                                {
                                    li["TempRole"] = li[oFieldRole.Id].ToString();
                                }

                                li.Update();
                            }
                            catch (Exception ex)
                            {
                                LogMessage("\t", "Error (" + li.Title + "): " + ex.Message, 3);
                            }
                        }

                    }

                    Thread.Sleep(5000);

                    ProcessFields(ref oResourcePool);

                    oFieldRole = oResourcePool.Fields.GetFieldByInternalName("Role");
                    oFieldDept = oResourcePool.Fields.GetFieldByInternalName("Department");

                    LogMessage("\tUpdating Role and Department");

                    foreach (SPListItem li in oResourcePool.Items)
                    {
                        try
                        {
                            if (li["TempDept"] != null && !li["TempDept"].ToString().Contains(";#") && oFieldDept.Type == SPFieldType.Lookup)
                            {
                                DataRow[] dr = dtDepartments.Select("Title='" + li["TempDept"].ToString() + "'");
                                if (dr.Length > 0)
                                {

                                    SPFieldLookupValue lv = new SPFieldLookupValue(int.Parse(dr[0]["ID"].ToString()), li["TempDept"].ToString());
                                    li[oFieldDept.Id] = lv;
                                }
                            }

                            if (li["TempRole"] != null && !li["TempRole"].ToString().Contains(";#") && oFieldRole.Type == SPFieldType.Lookup)
                            {
                                DataRow[] dr = dtRoles.Select("Title='" + li["TempRole"].ToString() + "'");
                                if (dr.Length > 0)
                                {

                                    SPFieldLookupValue lv = new SPFieldLookupValue(int.Parse(dr[0]["ID"].ToString()), li["TempRole"].ToString());
                                    li[oFieldRole.Id] = lv;
                                }
                            }

                            li.Update();

                            LogMessage("\t\t" + li.Title);
                        }
                        catch (Exception ex)
                        {
                            LogMessage("\t", "(" + li.Title + "): " + ex.Message, 3);
                        }
                    }

                    if (bIsPfe)
                    {
                        using (var workEngineAPI = new WorkEngineAPI())
                        {
                            LogMessage("Installing PfE Resource Events");

                            WorkEngineAPI.AddRemoveFeatureEvents(@"<AddRemoveFeatureEvents><Data><Feature Name=""pferesourcemanagement"" Operation=""ADD""/></Data></AddRemoveFeatureEvents>", SPWeb);
                        }
                    }

                    LogMessage("Enabling New Button");

                    using (var spSite = new SPSite(oResourcePool.ParentWeb.Site.ID))
                    {
                        using (SPWeb spWeb = spSite.OpenWeb(oResourcePool.ParentWeb.ID))
                        {
                            SPList resourcePool = spWeb.Lists.GetList(oResourcePool.ID, false);

                            var gSettings = new GridGanttSettings(resourcePool) { HideNewButton = false };
                            gSettings.SaveSettings();
                        }
                    }


                    LogMessage("Processing Editable Fields");
                    UpdateField("Generic", true, false, true, ref oResourcePool);
                    UpdateField("FirstName", true, true, true, ref oResourcePool);
                    UpdateField("LastName", true, true, true, ref oResourcePool);
                    UpdateField("Email", true, false, true, ref oResourcePool);
                    UpdateField("ResourceLevel", true, true, true, ref oResourcePool);
                    UpdateField("Permissions", true, true, true, ref oResourcePool);
                    UpdateField("StandardRate", true, true, true, ref oResourcePool);
                    UpdateField("Department", true, true, true, ref oResourcePool);
                    UpdateField("Role", true, true, true, ref oResourcePool);
                    UpdateField("HolidaySchedule", true, true, true, ref oResourcePool);
                    UpdateField("WorkHours", true, true, true, ref oResourcePool);
                    UpdateField("AvailableFrom", true, true, true, ref oResourcePool);
                    UpdateField("AvailableTo", true, true, true, ref oResourcePool);
                    UpdateField("Disabled", false, true, true, ref oResourcePool);

                }
                catch (Exception ex)
                {
                    LogMessage("", "General: " + ex.Message, 3);
                }

            }


            return true;
        }

        private void UpdateField(string sFieldName, bool bCanShowInNewForm, bool bCanShowInEditForm, bool bCanShowInDisplayForm, ref SPList ResourcePool)
        {
            using (var spSite = new SPSite(ResourcePool.ParentWeb.Site.ID))
            {
                using (SPWeb spWeb = spSite.OpenWeb(ResourcePool.ParentWeb.ID))
                {
                    SPList oResourcePool = spWeb.Lists[ResourcePool.ID];

                    if (oResourcePool.Fields.ContainsFieldWithInternalName(sFieldName))
                    {
                        try
                        {
                            SPField oField = oResourcePool.Fields.GetFieldByInternalName(sFieldName);

                            bool bSealed = oField.Sealed;
                            if (bSealed)
                            {
                                oField.Sealed = false;
                                oField.Update();
                            }

                            oField.ShowInDisplayForm = bCanShowInDisplayForm;
                            oField.ShowInEditForm = bCanShowInEditForm;
                            oField.ShowInNewForm = bCanShowInNewForm;
                            oField.Update();

                            if (bSealed)
                            {
                                oField.Sealed = true;
                                oField.Update();
                            }
                            LogMessage("\t" + sFieldName);
                        }
                        catch (Exception ex)
                        {
                            LogMessage("", "(" + sFieldName + "): " + ex.Message, 3);
                        }
                    }
                }
            }
        }

        private void ProcessFields(ref SPList oResourcePool)
        {
            //using (var spSite = new SPSite(resourcePool.ParentWeb.Site.ID))
            //{
            //    using (SPWeb spWeb = spSite.OpenWeb(resourcePool.ParentWeb.ID))
            //    {
            //        SPList oResourcePool = spWeb.Lists[resourcePool.ID];

            try
            {
                if (oResourcePool.Fields.ContainsFieldWithInternalName("CanLogin"))
                {
                    LogMessage("\tRemoving CanLogin field");
                    SPField oField = oResourcePool.Fields.GetFieldByInternalName("CanLogin");
                    if (oField.Sealed)
                    {
                        oField.Sealed = false;
                        oField.Update();
                    }
                    oField.AllowDeletion = true;
                    oField.Update();
                    oField.Delete();

                }
            }
            catch (Exception ex) { LogMessage("\t", "Removing CanLogin field: " + ex.Message, 3); }

            //oResourcePool.Update();
            //    }
            //}

            //using (var spSite = new SPSite(resourcePool.ParentWeb.Site.ID))
            //{
            //    using (SPWeb spWeb = spSite.OpenWeb(resourcePool.ParentWeb.ID))
            //    {
            //        SPList oResourcePool = spWeb.Lists[resourcePool.ID];

            try
            {
                if (oResourcePool.Fields.ContainsFieldWithInternalName("DepartmentManager"))
                {
                    LogMessage("\tRemoving Department Manager field");

                    SPField oField = oResourcePool.Fields.GetFieldByInternalName("DepartmentManager");
                    if (oField.Sealed)
                    {
                        oField.Sealed = false;
                        oField.Update();
                    }
                    oField.AllowDeletion = true;
                    oField.Update();
                    oField.Delete();
                }
            }
            catch (Exception ex) { LogMessage("\t", "Removing DepartmentManager field: " + ex.Message, 3); }

            //        oResourcePool.Update();
            //    }
            //}

            //using (var spSite = new SPSite(resourcePool.ParentWeb.Site.ID))
            //{
            //    using (SPWeb spWeb = spSite.OpenWeb(resourcePool.ParentWeb.ID))
            //    {
            //        SPList oResourcePool = spWeb.Lists[resourcePool.ID];

            try
            {
                if (!oResourcePool.Fields.ContainsFieldWithInternalName("ResourceLevel"))
                {
                    LogMessage("\tAdding License Type field");

                    string sField = oResourcePool.Fields.AddFieldAsXml(@"<Field Type=""ResourceLevels"" DisplayName=""ResourceLevel"" Required=""FALSE"" EnforceUniqueValues=""FALSE"" StaticName=""ResourceLevel"" Name=""ResourceLevel"" AllowDeletion=""FALSE"" Description=""Choose the license type that this resource will require within EPM Live.  The licence type selected will determine the features available to this resource.""/>");
                    SPField oField = oResourcePool.Fields.GetFieldByInternalName("ResourceLevel");
                    oField.Title = "License Type";
                    oField.Sealed = true;
                    oField.Update();
                }
            }
            catch (Exception ex) { LogMessage("\t", "Adding License Type field: " + ex.Message, 3); }

            //oResourcePool.Update();
            //    }
            //}

            //using (var spSite = new SPSite(resourcePool.ParentWeb.Site.ID))
            //{
            //    using (SPWeb spWeb = spSite.OpenWeb(resourcePool.ParentWeb.ID))
            //    {
            //        SPList oResourcePool = spWeb.Lists[resourcePool.ID];

            try
            {
                if (!oResourcePool.Fields.ContainsFieldWithInternalName("HolidaySchedule"))
                {
                    LogMessage("\tAdding Holiday Schedule field");

                    SPList oHolidaySchedules = SPWeb.Lists.TryGetList("Holiday Schedules");
                    if (oHolidaySchedules != null)
                    {
                        oResourcePool.Fields.AddLookup("HolidaySchedule", oHolidaySchedules.ID, true);
                        SPFieldLookup oField = (SPFieldLookup)oResourcePool.Fields.GetFieldByInternalName("HolidaySchedule");
                        oField.LookupField = "Title";
                        oField.Title = "Holiday Schedule";
                        oField.Update();
                    }
                    else
                    {
                        LogMessage("\t", "Holiday schedule list missing", 3);
                    }
                }
            }
            catch (Exception ex) { LogMessage("\t", "Adding Holiday Schedule field: " + ex.Message, 3); }

            //oResourcePool.Update();
            //    }
            //}

            //using (var spSite = new SPSite(resourcePool.ParentWeb.Site.ID))
            //{
            //    using (SPWeb spWeb = spSite.OpenWeb(resourcePool.ParentWeb.ID))
            //    {
            //        SPList oResourcePool = spWeb.Lists[resourcePool.ID];

            try
            {
                if (!oResourcePool.Fields.ContainsFieldWithInternalName("WorkHours"))
                {
                    LogMessage("\tAdding Work Hours field");

                    SPList oWorkHours = SPWeb.Lists.TryGetList("Work Hours");
                    if (oWorkHours != null)
                    {
                        oResourcePool.Fields.AddLookup("WorkHours", oWorkHours.ID, true);
                        SPFieldLookup oField = (SPFieldLookup)oResourcePool.Fields.GetFieldByInternalName("WorkHours");
                        oField.LookupField = "Title";
                        oField.Title = "Work Hours";
                        oField.Update();
                    }
                    else
                    {
                        LogMessage("\t", "WorkHours list missing", 3);
                    }
                }
            }
            catch (Exception ex) { LogMessage("\t", "Adding Work Hours field: " + ex.Message, 3); }

            //        oResourcePool.Update();
            //    }
            //}

            //using (var spSite = new SPSite(resourcePool.ParentWeb.Site.ID))
            //{
            //    using (SPWeb spWeb = spSite.OpenWeb(resourcePool.ParentWeb.ID))
            //    {
            //        SPList oResourcePool = spWeb.Lists[resourcePool.ID];

            try
            {
                if (!oResourcePool.Fields.ContainsFieldWithInternalName("Role"))
                {
                    LogMessage("\tAdding Role field");

                    SPList oRoles = SPWeb.Lists.TryGetList("Roles");
                    if (oRoles != null)
                    {
                        oResourcePool.Fields.AddLookup("Role", oRoles.ID, true);

                        if (bIsPfe)
                        {
                            SPFieldLookup oField = (SPFieldLookup)oResourcePool.Fields.GetFieldByInternalName("Role");
                            oField.LookupField = "CCRName";
                            oField.Update();
                        }
                        else
                        {
                            SPFieldLookup oField = (SPFieldLookup)oResourcePool.Fields.GetFieldByInternalName("Role");
                            oField.LookupField = "Title";
                            oField.Update();
                        }
                    }
                    else
                    {
                        LogMessage("\t", "Roles list missing", 3);
                    }
                }
                else
                {
                    SPField oRoleField = oResourcePool.Fields.GetFieldByInternalName("Role");
                    if (oRoleField.Type != SPFieldType.Lookup)
                    {
                        LogMessage("\tReplacing Role field");

                        SPList oRoles = SPWeb.Lists.TryGetList("Roles");
                        if (oRoles != null)
                        {
                            if (oRoleField.Sealed)
                            {
                                oRoleField.Sealed = false;
                                oRoleField.Update();
                            }
                            oRoleField.AllowDeletion = true;
                            oRoleField.Update();
                            oRoleField.Delete();

                            string sField = oResourcePool.Fields.AddLookup("Role", oRoles.ID, true);

                            if (bIsPfe)
                            {
                                SPFieldLookup oField = (SPFieldLookup)oResourcePool.Fields.GetFieldByInternalName(sField);
                                oField.LookupField = "CCRName";
                                oField.Update();
                            }
                            else
                            {
                                SPFieldLookup oField = (SPFieldLookup)oResourcePool.Fields.GetFieldByInternalName(sField);
                                oField.LookupField = "Title";
                                oField.Update();
                            }
                        }
                        else
                        {
                            LogMessage("\t", "Roles list missing", 3);
                        }
                    }
                }
            }
            catch (Exception ex) { LogMessage("\t", "Adding Role field: " + ex.Message, 3); }

            //        oResourcePool.Update();
            //    }
            //}

            //using (var spSite = new SPSite(resourcePool.ParentWeb.Site.ID))
            //{
            //    using (SPWeb spWeb = spSite.OpenWeb(resourcePool.ParentWeb.ID))
            //    {
            //        SPList oResourcePool = spWeb.Lists[resourcePool.ID];

            try
            {
                if (!oResourcePool.Fields.ContainsFieldWithInternalName("Department"))
                {
                    LogMessage("\tAdding Department field");

                    SPList oDepts = oResourcePool.ParentWeb.Lists.TryGetList("Departments");
                    if (oDepts != null)
                    {
                        oResourcePool.Fields.AddLookup("Department", oDepts.ID, true);

                        SPFieldLookup oField = (SPFieldLookup)oResourcePool.Fields.GetFieldByInternalName("Department");
                        oField.LookupField = "DisplayName";
                        oField.Update();
                    }
                    else
                    {
                        LogMessage("\t", "Departments list missing", 3);
                    }
                }
                else
                {
                    SPField oDeptField = oResourcePool.Fields.GetFieldByInternalName("Department");
                    if (oDeptField.Type != SPFieldType.Lookup)
                    {
                        LogMessage("\tReplacing Department field");

                        SPList oDepts = oResourcePool.ParentWeb.Lists.TryGetList("Departments");
                        if (oDepts != null)
                        {
                            if (oDeptField.Sealed)
                            {
                                LogMessage("\t\tUnsealing the field");

                                oDeptField.Sealed = false;

                                try
                                {
                                    oDeptField.Update();
                                }
                                catch
                                {
                                    Thread.Sleep(1000);
                                    oDeptField.Update();
                                }
                            }

                            LogMessage("\t\tAllowing deletion of the field");

                            oDeptField.AllowDeletion = true;

                            try
                            {
                                oDeptField.Update();
                            }
                            catch
                            {
                                Thread.Sleep(1000);
                                oDeptField.Update();
                            }

                            LogMessage("\t\tDeleting the field");

                            try
                            {
                                oDeptField.Delete();
                            }
                            catch
                            {
                                Thread.Sleep(1000);
                                oDeptField.Delete();
                            }

                            LogMessage("\t\tAdding the Department lookup");

                            oResourcePool.Fields.AddLookup("Department", oDepts.ID, true);
                            Thread.Sleep(1000);

                            LogMessage("\t\tConfiguring the Department lookup");

                            SPFieldLookup oField = (SPFieldLookup)oResourcePool.Fields.GetFieldByInternalName("Department");
                            oField.LookupField = "DisplayName";

                            try
                            {
                                oField.Update();
                            }
                            catch
                            {
                                Thread.Sleep(1000);
                                oField.Update();
                            }

                            LogMessage("", "The Department field is replaced", 1);
                        }
                        else
                        {
                            LogMessage("\t", "Departments list missing", 3);
                        }
                    }
                }
            }
            catch (Exception ex) { LogMessage("\t", "Adding Department field: " + ex.Message, 3); }

            oResourcePool.Update();
            //    }
            //}
        }
    }
}
