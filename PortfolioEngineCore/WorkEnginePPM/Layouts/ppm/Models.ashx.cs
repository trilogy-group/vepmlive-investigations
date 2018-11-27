using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using PortfolioEngineCore;

namespace WorkEnginePPM
{

    public partial class Models : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            const string this_class = "WorkEnginePPM.Models";
            StreamReader sr = new StreamReader(context.Request.InputStream);
            string sRequest = sr.ReadToEnd();
            try
            {
                context.Server.ScriptTimeout = 86400;
                s = WebAdmin.CheckRequest(context, this_class, sRequest);
                if (s == "")
                {
                    CStruct xPageRequest = new CStruct();
                    if (xPageRequest.LoadXML(sRequest))
                    {
                        string sFunction = xPageRequest.GetStringAttr("function");
                        string sRequestContext = xPageRequest.GetStringAttr("context");
                        try
                        {
                            Assembly assemblyInstance = Assembly.GetExecutingAssembly();
                            Type thisClass = assemblyInstance.GetType(this_class, true, true);
                            MethodInfo m = thisClass.GetMethod(sFunction);
                            CStruct xData = xPageRequest.GetSubStruct("data");
                            object result = m.Invoke(null, new object[] { context, sRequestContext, xData });
                            s = WebAdmin.BuildReply(this_class, sFunction, sRequestContext, result.ToString());
                        }
                        catch (Exception ex)
                        {
                            s = WebAdmin.BuildReply(this_class, sFunction, sRequestContext, WebAdmin.FormatError("exception", this_class + ".ProcessRequest", ex.Message, "1"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                s = WebAdmin.BuildReply(this_class, this_class + ".ProcessRequest", sRequest, WebAdmin.FormatError("exception", this_class + ".ProcessRequest", ex.Message, "1"));
            }
            context.Response.ContentType = "text/xml; charset=utf-8";
            context.Response.Write(CStruct.ConvertXMLToJSON(s));
        }

        private static void InitializeSecurityColumns(_TGrid tg)
        {
            tg.AddColumn(title: "ID", width: 50, name: "GROUP_ID", isId: true, hidden: true);
            tg.AddColumn(title: "Permission Group", width: 170, name: "GROUP_NAME", maincol: true, editable: false);
            tg.AddColumn(title: "Read", width: 50, name: "DS_READ", align: _TGrid.Align.center, type: _TGrid.Type.checkbox, editable: true);
            tg.AddColumn(title: "Edit", width: 50, name: "DS_EDIT", align: _TGrid.Align.center, type: _TGrid.Type.checkbox, editable: true);
        }

        public static string ModelsRequest(HttpContext Context, string sRequestContext, CStruct xData)
        {
            var reply = string.Empty;
            try
            {
                switch (sRequestContext)
                {
                    case "ReadModelInfo":
                    {
                        reply = ReadModelInfo(Context, xData);
                        break;
                    }
                    case "UpdateModelInfo":
                    {
                        reply = UpdateModelInfo(Context, xData);
                        break;
                    }
                    case "DeleteModelInfo":
                    {
                        reply = DeleteModelInfo(Context, xData);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                reply = WebAdmin.FormatError("exception", "Models.ModelsRequest", ex.Message);
            }

            return reply;
        }

        private static string ReadModelInfo(HttpContext Context, CStruct xData)
        {
            string reply = string.Empty;
            var viewId = int.Parse(xData.InnerText);
            var baseInfo = WebAdmin.BuildBaseInfo(Context);
            using (var dataAccess = new DataAccess(baseInfo))
            {
                var dbAccess = dataAccess.dba;
                if (dbAccess.Open() == StatusEnum.rsSuccess)
                {
                    DataTable dataTable;
                    if (dbaModels.SelectModel(dbAccess, viewId, out dataTable) != StatusEnum.rsSuccess)
                    {
                        reply = WebAdmin.FormatError("exception", "Models.ReadModelInfo", dbAccess.StatusText);
                    }
                    else
                    {
                        CStruct models;
                        int selectedFlagField;

                        CreateModel(dataTable, out models, out selectedFlagField);
                        CreateCalendars(models, dbAccess);
                        CreateCostTypes(models, dbAccess, viewId);
                        CreateFlagCustomFields(models, dbAccess, selectedFlagField);
                        SelectAndUpdateSecurity(dbAccess, models);
                        dbaModels.SelectModelVersions(dbAccess, viewId, out dataTable);
                        var versions = BuildNewDataTableWithPermissions(dataTable);
                        var dGrid = UpdateGrid(versions);
                        PopulateModels(dGrid, models);

                        reply = models.XML();
                    }
                }
            }
            return reply;
        }

        private static void CreateModel(DataTable dataTable, out CStruct models, out int selectedFlagField)
        {
            models = new CStruct();
            models.Initialize("Model");

            var selectedCalendar = -1;
            selectedFlagField = 0;
            if (dataTable.Rows.Count == 1)
            {
                var row = dataTable.Rows[0];
                models.CreateIntAttr("MODEL_UID", SqlDb.ReadIntValue(row["MODEL_UID"]));
                models.CreateStringAttr("MODEL_NAME", SqlDb.ReadStringValue(row["MODEL_NAME"]));
                models.CreateStringAttr("MODEL_DESC", SqlDb.ReadStringValue(row["MODEL_DESC"]));
                selectedCalendar = SqlDb.ReadIntValue(row["MODEL_CB_ID"]);
                models.CreateIntAttr("MODEL_CB_ID", selectedCalendar);
                selectedFlagField = SqlDb.ReadIntValue(row["MODEL_SELECTED_FIELD_ID"]);
            }
            else
            {
                models.CreateIntAttr("MODEL_UID", 0);
                models.CreateStringAttr("MODEL_NAME", "New Model");
                models.CreateStringAttr("MODEL_DESC", "");
                models.CreateIntAttr("MODEL_CB_ID", selectedCalendar);
            }
        }

        private static void CreateCalendars(CStruct models, DBAccess dbAccess)
        {
            DataTable dataTable;
            var calendars = models.CreateSubStruct("calendars");
            var item = calendars.CreateSubStruct("item");
            item.CreateIntAttr("id", -1);
            item.CreateStringAttr("name", "[None]");
            dbaCalendars.SelectCalendars(dbAccess, out dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                item = calendars.CreateSubStruct("item");
                var nCalendar = SqlDb.ReadIntValue(row["CB_ID"]);
                item.CreateIntAttr("id", nCalendar);
                item.CreateStringAttr("name", SqlDb.ReadStringValue(row["CB_NAME"]));
            }
        }

        private static void CreateCostTypes(CStruct models, DBAccess dbAccess, int viewId)
        {
            DataTable dataTable;
            var costTypes = models.CreateSubStruct("costtypes");
            dbaModels.SelectCostTypesForModel(dbAccess, viewId, out dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                var item = costTypes.CreateSubStruct("item");
                var costType = SqlDb.ReadIntValue(row["CT_ID"]);
                item.CreateIntAttr("id", costType);
                item.CreateStringAttr("name", SqlDb.ReadStringValue(row["CT_NAME"]));
                item.CreateIntAttr("used", SqlDb.ReadIntValue(row["used"]));
            }
        }

        private static void CreateFlagCustomFields(CStruct models, DBAccess dbAccess, int selectedFlagField)
        {
            DataTable dataTable;
            var flagCustomFields = models.CreateSubStruct("flagcustomfields");
            dbaModels.SelectCustomFields_Flags(dbAccess, out dataTable);
            var item = flagCustomFields.CreateSubStruct("item");
            item.CreateIntAttr("id", -1);
            item.CreateStringAttr("name", "[None]");
            foreach (DataRow row in dataTable.Rows)
            {
                item = flagCustomFields.CreateSubStruct("item");
                var fieldId = SqlDb.ReadIntValue(row["FA_FIELD_ID"]);
                item.CreateIntAttr("id", fieldId);
                item.CreateStringAttr("name", SqlDb.ReadStringValue(row["FA_NAME"]));
                item.CreateIntAttr(
                    "selected",
                    selectedFlagField == fieldId
                        ? 1
                        : 0);
            }
        }

        private static void SelectAndUpdateSecurity(DBAccess dbAccess, CStruct models)
        {
            DataTable dataTable;
            dbaGroups.SelectEmptyCostTypeSecurityGroups(dbAccess, out dataTable);
            var tGrid = new _TGrid();
            InitializeSecurityColumns(tGrid);
            tGrid.SetDataTable(dataTable);
            string tGridSecurity;
            tGrid.Build(out tGridSecurity);
            models.CreateString("tgridSecurity", tGridSecurity);
        }

        private static void PopulateModels(_DGrid dGrid, CStruct models)
        {
            string columnData;
            string tableData;
            dGrid.Build(out columnData, out tableData);
            models.CreateString("dgridVersionsColumnData", columnData);
            models.CreateString("dgridVersionsTableData", tableData);
        }

        private static _DGrid UpdateGrid(DataTable versions)
        {
            var dGrid = new _DGrid();
            dGrid.AddColumn("ID", 50, name: "MODEL_VERSION_UID", isId: true, hidden: true);
            dGrid.AddColumn("Deleted", 50, name: "Deleted", type: _DGrid.Type.checkbox, editable: false, hidden: true);
            dGrid.AddColumn("Name", 150, name: "MODEL_VERSION_NAME", editable: false);
            dGrid.AddColumn("Description", 150, name: "MODEL_VERSION_DESC", editable: false);
            dGrid.AddColumn("Permissions", 250, name: "MODEL_VERSION_PERMISSIONS", editable: false);
            dGrid.AddColumn("PermissionsHidden", 180, name: "MODEL_VERSION_PERMISSIONS_HIDDEN", editable: false, hidden: true);
            dGrid.SetDataTable(versions);
            return dGrid;
        }

        private static DataTable BuildNewDataTableWithPermissions(DataTable dataTable)
        {
            var prevVersionId = 0;
            var versions = new DataTable();
            versions.Columns.Add("MODEL_VERSION_UID", Type.GetType("System.Int32"));
            versions.Columns.Add("MODEL_VERSION_NAME", Type.GetType("System.String"));
            versions.Columns.Add("MODEL_VERSION_DESC", Type.GetType("System.String"));
            versions.Columns.Add("MODEL_VERSION_PERMISSIONS", Type.GetType("System.String"));
            versions.Columns.Add("MODEL_VERSION_PERMISSIONS_HIDDEN", Type.GetType("System.String"));
            var rowCount = dataTable.Rows.Count;
            var rowIndex = 0;
            DataRow versionRow = null;
            var permissions = string.Empty;
            var hiddenPermissions = string.Empty;
            foreach (DataRow row in dataTable.Rows)
            {
                rowIndex++;
                var versionId = SqlDb.ReadIntValue(row["MODEL_VERSION_UID"]);
                if (versionId != prevVersionId || rowIndex == 1)
                {
                    if (versionRow != null)
                    {
                        versionRow["MODEL_VERSION_PERMISSIONS"] = permissions;
                        versionRow["MODEL_VERSION_PERMISSIONS_HIDDEN"] = hiddenPermissions;
                    }
                    permissions = string.Empty;
                    hiddenPermissions = string.Empty;
                    versionRow = versions.Rows.Add();
                    versionRow["MODEL_VERSION_UID"] = row["MODEL_VERSION_UID"];
                    versionRow["MODEL_VERSION_NAME"] = row["MODEL_VERSION_NAME"];
                    versionRow["MODEL_VERSION_DESC"] = row["MODEL_VERSION_DESC"];
                }
                var permissionGranded = "No Access";
                if (!row["GROUP_NAME"].Equals(DBNull.Value))
                {
                    if ((int)row["EDIT_PERMISSION"] == 1)
                    {
                        permissionGranded = "Read/Write";
                    }
                    else if ((int)row["VIEW_PERMISSION"] == 1)
                    {
                        permissionGranded = "Read Only";
                    }
                    if (!string.IsNullOrWhiteSpace(permissions))
                    {
                        permissions += ",";
                    }
                    permissions += string.Format("{0}({1})", row["GROUP_NAME"], permissionGranded);
                    if (!string.IsNullOrWhiteSpace(hiddenPermissions))
                    {
                        hiddenPermissions += ",";
                    }
                    hiddenPermissions += string.Format(
                        "{0}::{1}::{2}::{3}",
                        row["GROUP_ID"],
                        row["GROUP_NAME"],
                        row["VIEW_PERMISSION"],
                        row["EDIT_PERMISSION"]);
                }

                if (rowIndex == rowCount && versionRow != null)
                {
                    versionRow["MODEL_VERSION_PERMISSIONS"] = permissions;
                    versionRow["MODEL_VERSION_PERMISSIONS_HIDDEN"] = hiddenPermissions;
                    versionRow = null;
                }
                prevVersionId = versionId;
            }
            return versions;
        }

        //private static string ReadCalendarInfo(HttpContext Context, CStruct xData)
        //{
        //    string sReply = "";
        //    string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
        //    DataAccess da = new DataAccess(sBaseInfo);
        //    DBAccess dba = da.dba;
        //    if (dba.Open() == StatusEnum.rsSuccess)
        //    {
        //        try
        //        {
        //            int nCalendarId = -1;
        //            int i;
        //            if (Int32.TryParse(xData.InnerText, out i) == true)
        //                nCalendarId = i;
        //            CStruct xModel = new CStruct();
        //            xModel.Initialize("Model");
        //            xModel.CreateIntAttr("CB_ID", nCalendarId);
        //            DataTable dt;

        //            CStruct xPeriods = xModel.CreateSubStruct("periods");
        //            CStruct xItem = xPeriods.CreateSubStruct("item");
        //            xItem.CreateIntAttr("id", -1);
        //            xItem.CreateStringAttr("name", "[None]");
        //            if (nCalendarId >= 0)
        //            {
        //                {
        //                    dbaCalendars.SelectCalendarPeriods(dba, nCalendarId, out dt);
        //                    foreach (DataRow row in dt.Rows)
        //                    {
        //                        xItem = xPeriods.CreateSubStruct("item");
        //                        xItem.CreateIntAttr("id", DBAccess.ReadIntValue(row["PRD_ID"]));
        //                        xItem.CreateStringAttr("name", DBAccess.ReadStringValue(row["PRD_NAME"]));
        //                    }
        //                }
        //            }
        //            sReply = xModel.XML();
        //        }
        //        catch (Exception ex)
        //        {
        //            sReply = WebAdmin.FormatError("exception", "CostCategories.ReadCalendarFTEsInfo", ex.Message);
        //        }
        //        dba.Close();
        //    }
        //    return sReply;
        //}
        private static string UpdateModelInfo(HttpContext Context, CStruct xData)
        {
            int nMODEL_UID = xData.GetIntAttr("MODEL_UID");
            string sMODEL_NAME = xData.GetStringAttr("MODEL_NAME");
            string sMODEL_DESC = xData.GetStringAttr("MODEL_DESC");
            int nCOST_BREAKDOWN = xData.GetIntAttr("MODEL_COST_BREAKDOWN");
            int nCustom_Field = xData.GetIntAttr("MODEL_CUSTOM_FIELD");
            string sMODEL_CTS = xData.GetStringAttr("MODEL_CTS");

            string sXML = xData.InnerText;
            _DGrid dg = new _DGrid();
            dg.AddColumn(title: "ID", width: 50, name: "MODEL_VERSION_UID", isId: true, hidden: true);
            dg.AddColumn(title: "Deleted", width: 50, name: "Deleted", type: _DGrid.Type.checkbox, editable: false, hidden: true);
            dg.AddColumn(title: "Name", width: 150, name: "MODEL_VERSION_NAME", editable: false);
            dg.AddColumn(title: "Description", width: 150, name: "MODEL_VERSION_DESC", editable: false);
            dg.AddColumn(title: "Permissions", width: 250, name: "MODEL_VERSION_PERMISSIONS", editable: false);
            dg.AddColumn(title: "PermissionsHidden", width: 180, name: "MODEL_VERSION_PERMISSIONS_HIDDEN", editable: false, hidden: true);
            DataTable dt = dg.SetXmlData(sXML);


            string sReply = "";

            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                try
                {
                    if (dbaModels.UpdateModelInfo(dba, ref nMODEL_UID, sMODEL_NAME, sMODEL_DESC, nCOST_BREAKDOWN, nCustom_Field, sMODEL_CTS, dt, out sReply) != StatusEnum.rsSuccess)
                    {
                        if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "Models.UpdateModelsInfo2", dba.StatusText);
                    }
                    //  needed to update list after SAVE
                    CStruct xModels = new CStruct();
                    xModels.Initialize("Model");
                    xModels.CreateIntAttr("MODEL_UID", nMODEL_UID);
                    xModels.CreateStringAttr("MODEL_NAME", sMODEL_NAME);
                    xModels.CreateStringAttr("MODEL_DESC", sMODEL_DESC);
                    sReply = xModels.XML();
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "Models.UpdateModelsInfo3", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }

        private static string DeleteModelInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                int nMODEL_UID = xData.GetIntAttr("MODEL_UID");
                try
                {
                    dbaModels.DeleteModel(dba, nMODEL_UID, out sReply);
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "Models.DeleteModelInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }
        #endregion
    }
}
