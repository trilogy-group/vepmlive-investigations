using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using Microsoft.SharePoint;
using Microsoft.Win32;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    [JobStep("WE43Upgrader", 40)]
    public class UpdateResourcePool : Step
    {
        #region Constructors (1) 

        public UpdateResourcePool(SPWeb spWeb, string data, int stepNumber, bool bispfe)
            : base(spWeb, data, stepNumber, bispfe)
        {
        }

        #endregion Constructors 

        #region Properties (1) 

        public override string Description
        {
            get { return "Updating Resource Pool"; }
        }

        #endregion Properties 

        #region Methods (5) 

        // Public Methods (1) 

        public override bool Perform()
        {
            LogMessage("Loading Resource Pool List");

            SPList oResourcePool = SPWeb.Lists.TryGetList("Resources");
            SPList oRoles = SPWeb.Lists.TryGetList("Roles");
            SPList oDepartments = SPWeb.Lists.TryGetList("Departments");
            SPList oHolidaySchedule = SPWeb.Lists.TryGetList("Holiday Schedules");
            SPList oWorkHours = SPWeb.Lists.TryGetList("Work Hours");

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
            else if (oHolidaySchedule == null)
            {
                LogMessage("", "HolidaySchedules list missing", 3);
            }
            else if (oWorkHours == null)
            {
                LogMessage("", "WorkHours list missing", 3);
            }
            else
            {
                try
                {
                    DataTable dtRoles = oRoles.Items.GetDataTable();
                    DataTable dtDepartments = oDepartments.Items.GetDataTable();

                    #region Add Temp fields

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
                    catch (Exception ex)
                    {
                        LogMessage("\t", "Adding TempRole field: " + ex.Message, 3);
                    }

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
                    catch (Exception ex)
                    {
                        LogMessage("\t", "Adding TempDept field: " + ex.Message, 3);
                    }

                    oResourcePool.Update();

                    #endregion

                    #region Process Role and Departments

                    bool bProcessRole = false;
                    bool bProcessDept = false;

                    try
                    {
                        if (oResourcePool.Fields.GetFieldByInternalName("Role").Type == SPFieldType.Choice)
                            bProcessRole = true;
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (oResourcePool.Fields.GetFieldByInternalName("Department").Type == SPFieldType.Choice)
                            bProcessDept = true;
                    }
                    catch
                    {
                    }

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
                        SPField newField = oResourcePool.Fields.CreateNewField(SPFieldType.Choice.ToString(),
                            "Department");
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

                    #endregion

                    ProcessFields(ref oResourcePool);

                    oFieldRole = oResourcePool.Fields.GetFieldByInternalName("Role");
                    oFieldDept = oResourcePool.Fields.GetFieldByInternalName("Department");

                    LogMessage("\tUpdating Role, Department, Holiday Schedule and Work Hours");

                    EnumerableRowCollection<DataRow> resourceHSWS = null;
                    EnumerableRowCollection<DataRow> holidaySchedules = null;
                    EnumerableRowCollection<DataRow> workHours = null;

                    try
                    {
                        var dtResourceHSWS = new DataTable();

                        string connectionString = GetConnectionString();

                        if (string.IsNullOrEmpty(connectionString))
                        {
                            throw new Exception("PFE DB connection string is empty.");
                        }

                        using (var sqlConnection = new SqlConnection(connectionString))
                        {
                            using (var sqlCommand = new SqlCommand(SQL, sqlConnection))
                            {
                                sqlConnection.Open();
                                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                                {
                                    dtResourceHSWS.Load(sqlDataReader);
                                }
                            }
                        }

                        resourceHSWS = dtResourceHSWS.AsEnumerable();

                        if (resourceHSWS.Any())
                        {
                            holidaySchedules = oHolidaySchedule.Items.GetDataTable().AsEnumerable();
                            workHours = oWorkHours.Items.GetDataTable().AsEnumerable();
                        }
                    }
                    catch (Exception ex)
                    {
                        LogMessage("\t", "(Get PFE DB ConnectionString): " + ex.Message, 3);
                    }

                    foreach (SPListItem li in oResourcePool.Items)
                    {
                        try
                        {
                            #region Copy Department and Roles

                            if (li["TempDept"] != null && !li["TempDept"].ToString().Contains(";#") &&
                                oFieldDept.Type == SPFieldType.Lookup)
                            {
                                DataRow[] dr = dtDepartments.Select("DisplayName='" + li["TempDept"] + "'");
                                if (dr.Length > 0)
                                {
                                    var lv = new SPFieldLookupValue(int.Parse(dr[0]["ID"].ToString()),
                                        li["TempDept"].ToString());
                                    li[oFieldDept.Id] = lv;
                                }
                            }

                            if (li["TempRole"] != null && !li["TempRole"].ToString().Contains(";#") &&
                                oFieldRole.Type == SPFieldType.Lookup)
                            {
                                DataRow[] dr = dtRoles.Select("Title='" + li["TempRole"] + "'");
                                if (dr.Length > 0)
                                {
                                    var lv = new SPFieldLookupValue(int.Parse(dr[0]["ID"].ToString()),
                                        li["TempRole"].ToString());
                                    li[oFieldRole.Id] = lv;
                                }
                            }

                            #endregion

                            string spAccount = string.Empty;
                            var resAcct = li["SharePointAccount"] as string;
                            if (!string.IsNullOrEmpty(resAcct))
                            {
                                var uv = new SPFieldUserValue(SPWeb, resAcct);
                                if (uv.User != null)
                                {
                                    spAccount = uv.User.LoginName.ToLower();
                                }
                            }

                            string extId = (li["EXTID"] ?? string.Empty).ToString();

                            if (resourceHSWS != null && resourceHSWS.Any() && !string.IsNullOrEmpty(spAccount))
                            {
                                try
                                {
                                    if (string.IsNullOrEmpty(extId))
                                    {
                                        foreach (DataRow row in resourceHSWS)
                                        {
                                            object acct = row["Account"];
                                            if (acct != null && acct != DBNull.Value)
                                            {
                                                if (acct.ToString().ToLower().Equals(spAccount))
                                                {
                                                    li["EXTID"] = (row["ResourceId"] ?? string.Empty).ToString();
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    LogMessage("\t", "(" + li.Title + "): Not setting EXTID. " + ex.Message, 3);
                                }

                                try
                                {
                                    foreach (object schedule in from hs in resourceHSWS
                                        let account = hs["Account"]
                                        where account != null && account != DBNull.Value
                                        where account.ToString().ToLower().Equals(spAccount)
                                        select hs["HolidaySchedule"]
                                        into schedule
                                        where schedule != null && schedule != DBNull.Value
                                        select schedule)
                                    {
                                        foreach (DataRow s in holidaySchedules)
                                        {
                                            object sch = s["Title"];
                                            if (sch == null || sch == DBNull.Value) continue;

                                            string hsch = sch.ToString();
                                            if (!hsch.ToLower().Equals(schedule.ToString().ToLower())) continue;

                                            li["HolidaySchedule"] =
                                                new SPFieldLookupValue(Convert.ToInt32(s["ID"].ToString()), hsch);
                                            break;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    LogMessage("\t", "(" + li.Title + "): Not setting Holiday Schedule. " + ex.Message,
                                        3);
                                }

                                try
                                {
                                    foreach (object hours in from wh in resourceHSWS
                                        let account = wh["Account"]
                                        where account != null && account != DBNull.Value
                                        where account.ToString().ToLower().Equals(spAccount)
                                        select wh["WorkHours"]
                                        into hours
                                        where hours != null && hours != DBNull.Value
                                        select hours)
                                    {
                                        foreach (DataRow h in workHours)
                                        {
                                            object hr = h["Title"];
                                            if (hr == null || hr == DBNull.Value) continue;

                                            string whr = hr.ToString();
                                            if (!whr.ToLower().Equals(hours.ToString().ToLower())) continue;

                                            li["WorkHours"] = new SPFieldLookupValue(
                                                Convert.ToInt32(h["ID"].ToString()), whr);
                                            break;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    LogMessage("\t", "(" + li.Title + "): Not setting Work Hours. " + ex.Message, 3);
                                }
                            }
                            else
                            {
                                LogMessage("\t",
                                    "(" + li.Title +
                                    "): Not setting Holiday Schedule and Work Hours. Cannot load from PFE.", 3);
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

                            WorkEngineAPI.AddRemoveFeatureEvents(
                                @"<AddRemoveFeatureEvents><Data><Feature Name=""pferesourcemanagement"" Operation=""ADD""/></Data></AddRemoveFeatureEvents>",
                                SPWeb);
                        }
                    }

                    LogMessage("Enabling New Button");

                    using (var spSite = new SPSite(oResourcePool.ParentWeb.Site.ID))
                    {
                        using (SPWeb spWeb = spSite.OpenWeb(oResourcePool.ParentWeb.ID))
                        {
                            SPList resourcePool = spWeb.Lists.GetList(oResourcePool.ID, false);

                            var gSettings = new GridGanttSettings(resourcePool) {HideNewButton = false};
                            gSettings.SaveSettings(resourcePool);
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

        // Private Methods (4) 

        private string GetConnectionString()
        {
            string basePath = CoreFunctions.getConfigSetting(SPWeb, "epkbasepath");

            if (string.IsNullOrEmpty(basePath))
            {
                throw new Exception("EPK Base Path is empty.");
            }

            string database = CoreFunctions.getConfigSetting(SPWeb, "ppmdbconn");

            if (string.IsNullOrEmpty(database))
            {
                database = GetDatabaseFromRegistry(basePath);
            }

            if (string.IsNullOrEmpty(database))
            {
                throw new Exception("Cannot read PFE DB information from the registry.");
            }

            string[] list = database.Split(';').Where(s => !s.ToLower().Contains("provider")).ToArray();

            return string.Join(";", list);
        }

        private static string GetDatabaseFromRegistry(string basePath)
        {
            string database = string.Empty;

            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software", false);

            try
            {
                RegistryKey key = registryKey.OpenSubKey("EPMLive", false)
                    .OpenSubKey("PortfolioEngine", false)
                    .OpenSubKey(basePath);

                database = key.GetValue("ConnectionString").ToString();
            }
            catch
            {
                try
                {
                    RegistryKey key = registryKey.OpenSubKey("Wow6432Node", false)
                        .OpenSubKey("EPMLive", false)
                        .OpenSubKey("PortfolioEngine", false)
                        .OpenSubKey(basePath);

                    database = key.GetValue("ConnectionString").ToString();
                }
                catch
                {
                }
            }

            return database;
        }

        private void ProcessFields(ref SPList oResourcePool)
        {
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
            catch (Exception ex)
            {
                LogMessage("\t", "Removing CanLogin field: " + ex.Message, 3);
            }

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
            catch (Exception ex)
            {
                LogMessage("\t", "Removing DepartmentManager field: " + ex.Message, 3);
            }

            try
            {
                if (!oResourcePool.Fields.ContainsFieldWithInternalName("ResourceLevel"))
                {
                    LogMessage("\tAdding License Type field");

                    string sField =
                        oResourcePool.Fields.AddFieldAsXml(
                            @"<Field Type=""ResourceLevels"" DisplayName=""ResourceLevel"" Required=""FALSE"" EnforceUniqueValues=""FALSE"" StaticName=""ResourceLevel"" Name=""ResourceLevel"" AllowDeletion=""FALSE"" Description=""Choose the license type that this resource will require within EPM Live.  The licence type selected will determine the features available to this resource.""/>");
                    SPField oField = oResourcePool.Fields.GetFieldByInternalName("ResourceLevel");
                    oField.Title = "License Type";
                    oField.Sealed = true;
                    oField.Update();
                }
            }
            catch (Exception ex)
            {
                LogMessage("\t", "Adding License Type field: " + ex.Message, 3);
            }

            try
            {
                if (!oResourcePool.Fields.ContainsFieldWithInternalName("HolidaySchedule"))
                {
                    LogMessage("\tAdding Holiday Schedule field");

                    SPList oHolidaySchedules = SPWeb.Lists.TryGetList("Holiday Schedules");
                    if (oHolidaySchedules != null)
                    {
                        oResourcePool.Fields.AddLookup("HolidaySchedule", oHolidaySchedules.ID, true);
                        var oField = (SPFieldLookup) oResourcePool.Fields.GetFieldByInternalName("HolidaySchedule");
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
            catch (Exception ex)
            {
                LogMessage("\t", "Adding Holiday Schedule field: " + ex.Message, 3);
            }

            try
            {
                if (!oResourcePool.Fields.ContainsFieldWithInternalName("WorkHours"))
                {
                    LogMessage("\tAdding Work Hours field");

                    SPList oWorkHours = SPWeb.Lists.TryGetList("Work Hours");
                    if (oWorkHours != null)
                    {
                        oResourcePool.Fields.AddLookup("WorkHours", oWorkHours.ID, true);
                        var oField = (SPFieldLookup) oResourcePool.Fields.GetFieldByInternalName("WorkHours");
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
            catch (Exception ex)
            {
                LogMessage("\t", "Adding Work Hours field: " + ex.Message, 3);
            }

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
                            var oField = (SPFieldLookup) oResourcePool.Fields.GetFieldByInternalName("Role");
                            oField.LookupField = "CCRName";
                            oField.Update();
                        }
                        else
                        {
                            var oField = (SPFieldLookup) oResourcePool.Fields.GetFieldByInternalName("Role");
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
                                var oField = (SPFieldLookup) oResourcePool.Fields.GetFieldByInternalName(sField);
                                oField.LookupField = "CCRName";
                                oField.Update();
                            }
                            else
                            {
                                var oField = (SPFieldLookup) oResourcePool.Fields.GetFieldByInternalName(sField);
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
            catch (Exception ex)
            {
                LogMessage("\t", "Adding Role field: " + ex.Message, 3);
            }

            try
            {
                if (!oResourcePool.Fields.ContainsFieldWithInternalName("Department"))
                {
                    LogMessage("\tAdding Department field");

                    SPList oDepts = oResourcePool.ParentWeb.Lists.TryGetList("Departments");
                    if (oDepts != null)
                    {
                        oResourcePool.Fields.AddLookup("Department", oDepts.ID, true);

                        var oField = (SPFieldLookup) oResourcePool.Fields.GetFieldByInternalName("Department");
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

                            var oField = (SPFieldLookup) oResourcePool.Fields.GetFieldByInternalName("Department");
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
            catch (Exception ex)
            {
                LogMessage("\t", "Adding Department field: " + ex.Message, 3);
            }

            oResourcePool.Update();
        }

        private void UpdateField(string sFieldName, bool bCanShowInNewForm, bool bCanShowInEditForm,
            bool bCanShowInDisplayForm, ref SPList ResourcePool)
        {
            using (var spSite = new SPSite(ResourcePool.ParentWeb.Site.ID))
            {
                using (SPWeb spWeb = spSite.OpenWeb(ResourcePool.ParentWeb.ID))
                {
                    SPList oResourcePool = spWeb.Lists[ResourcePool.ID];

                    if (!oResourcePool.Fields.ContainsFieldWithInternalName(sFieldName)) return;

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

        #endregion Methods 

        private const string SQL = @"
            SELECT    dbo.EPG_VW_RPT_Resources.ResourceID AS ResourceId, dbo.EPG_VW_RPT_Resources.[User Name] AS Account, dbo.EPG_GROUPS.GROUP_NAME AS HolidaySchedule, EPG_GROUPS_1.GROUP_NAME AS WorkHours
            FROM      dbo.EPG_GROUP_MEMBERS AS EPG_GROUP_MEMBERS_1 INNER JOIN
                      dbo.EPG_GROUPS AS EPG_GROUPS_1 ON EPG_GROUP_MEMBERS_1.GROUP_ID = EPG_GROUPS_1.GROUP_ID RIGHT OUTER JOIN
                      dbo.EPG_VW_RPT_Resources ON EPG_GROUP_MEMBERS_1.MEMBER_UID = dbo.EPG_VW_RPT_Resources.ResourceID LEFT OUTER JOIN
                      dbo.EPG_GROUP_MEMBERS INNER JOIN
                      dbo.EPG_GROUPS ON dbo.EPG_GROUP_MEMBERS.GROUP_ID = dbo.EPG_GROUPS.GROUP_ID ON
                      dbo.EPG_VW_RPT_Resources.ResourceID = dbo.EPG_GROUP_MEMBERS.MEMBER_UID
            WHERE     (dbo.EPG_GROUPS.GROUP_ENTITY = 11) AND (EPG_GROUPS_1.GROUP_ENTITY = 10)";
    }
}