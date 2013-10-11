using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
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
            string sReply = "";
            try
            {
                switch (sRequestContext)
                {
                    case "ReadModelInfo":
                    {
                        int nViewId = Int32.Parse(xData.InnerText);
                        string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                        DataAccess da = new DataAccess(sBaseInfo);
                        DBAccess dba = da.dba;
                        if (dba.Open() == StatusEnum.rsSuccess)
                        {
                            DataTable dt;
                            if (dbaModels.SelectModel(dba, nViewId, out dt) != StatusEnum.rsSuccess)
                            {
                                sReply = WebAdmin.FormatError("exception", "Models.ReadModelInfo", dba.StatusText);
                            }
                            else
                            {
                                CStruct xModels = new CStruct();
                                xModels.Initialize("Model");

                                int nSelectedCalendar = -1;
                                int nSelectedFlagField = 0;
                                if (dt.Rows.Count == 1)
                                {
                                    DataRow row = dt.Rows[0];
                                    xModels.CreateIntAttr("MODEL_UID", DBAccess.ReadIntValue(row["MODEL_UID"]));
                                    xModels.CreateStringAttr("MODEL_NAME", DBAccess.ReadStringValue(row["MODEL_NAME"]));
                                    xModels.CreateStringAttr("MODEL_DESC", DBAccess.ReadStringValue(row["MODEL_DESC"]));
                                    nSelectedCalendar = DBAccess.ReadIntValue(row["MODEL_CB_ID"]);
                                    xModels.CreateIntAttr("MODEL_CB_ID", nSelectedCalendar);
                                    nSelectedFlagField = DBAccess.ReadIntValue(row["MODEL_SELECTED_FIELD_ID"]);
                                }
                                else
                                {
                                    xModels.CreateIntAttr("MODEL_UID", 0);
                                    xModels.CreateStringAttr("MODEL_NAME", "New Model");
                                    xModels.CreateStringAttr("MODEL_DESC", "");
                                    xModels.CreateIntAttr("MODEL_CB_ID", nSelectedCalendar);
                                }

                                CStruct xCalendars = xModels.CreateSubStruct("calendars");
                                {
                                    CStruct xItem = xCalendars.CreateSubStruct("item");
                                    xItem.CreateIntAttr("id", -1);
                                    xItem.CreateStringAttr("name", "[None]");
                                    dbaCalendars.SelectCalendars(dba, out dt);
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        xItem = xCalendars.CreateSubStruct("item");
                                        int nCalendar = DBAccess.ReadIntValue(row["CB_ID"]);
                                        xItem.CreateIntAttr("id", nCalendar);
                                        xItem.CreateStringAttr("name", DBAccess.ReadStringValue(row["CB_NAME"]));
                                    }
                                }

                                CStruct xCosttypes = xModels.CreateSubStruct("costtypes");
                                {
                                    dbaModels.SelectCostTypesForModel(dba, nViewId, out dt);
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        CStruct xItem = xCosttypes.CreateSubStruct("item");
                                        int nCosttype = DBAccess.ReadIntValue(row["CT_ID"]);
                                        xItem.CreateIntAttr("id", nCosttype);
                                        xItem.CreateStringAttr("name", DBAccess.ReadStringValue(row["CT_NAME"]));
                                        xItem.CreateIntAttr("used", DBAccess.ReadIntValue(row["used"]));
                                    }
                                }
                                CStruct xFlagCustomFields = xModels.CreateSubStruct("flagcustomfields");
                                {
                                    dbaModels.SelectCustomFields_Flags(dba, out dt);
                                    CStruct xItem = xFlagCustomFields.CreateSubStruct("item");
                                    xItem.CreateIntAttr("id", -1);
                                    xItem.CreateStringAttr("name", "[None]");
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        xItem = xFlagCustomFields.CreateSubStruct("item");
                                        int nfieldid = DBAccess.ReadIntValue(row["FA_FIELD_ID"]);
                                        xItem.CreateIntAttr("id", nfieldid);
                                        xItem.CreateStringAttr("name", DBAccess.ReadStringValue(row["FA_NAME"]));
                                        if (nSelectedFlagField == nfieldid)
                                            xItem.CreateIntAttr("selected", 1);
                                        else
                                            xItem.CreateIntAttr("selected", 0);
                                    }
                                }
                                //CStruct xGroups = xModels.CreateSubStruct("groups");
                                //{
                                //    dbaGroups.SelectGroups(dba, out dt);
                                //    foreach (DataRow row in dt.Rows)
                                //    {
                                //        CStruct xItem = xGroups.CreateSubStruct("item");
                                //        int nfieldid = DBAccess.ReadIntValue(row["GROUP_ID"]);
                                //        xItem.CreateIntAttr("id", nfieldid);
                                //        xItem.CreateStringAttr("name", DBAccess.ReadStringValue(row["GROUP_NAME"]));
                                //    }
                                //}

                                {
                                    dbaGroups.SelectEmptyCostTypeSecurityGroups(dba, out dt);
                                    _TGrid tg = new _TGrid();
                                    InitializeSecurityColumns(tg);
                                    tg.SetDataTable(dt);
                                    string tgridSecurity = "";
                                    tg.Build(out tgridSecurity);
                                    xModels.CreateString("tgridSecurity", tgridSecurity);
                                }

                                {
                                    dbaModels.SelectModelVersions(dba, nViewId, out dt);

                                    // build up new data table with permissions info
                                    int prevversionid = 0;
                                    DataTable dtVersions = new DataTable();
                                    dtVersions.Columns.Add("MODEL_VERSION_UID", System.Type.GetType("System.Int32"));
                                    dtVersions.Columns.Add("MODEL_VERSION_NAME", System.Type.GetType("System.String"));
                                    dtVersions.Columns.Add("MODEL_VERSION_DESC", System.Type.GetType("System.String"));
                                    dtVersions.Columns.Add("MODEL_VERSION_PERMISSIONS", System.Type.GetType("System.String"));
                                    dtVersions.Columns.Add("MODEL_VERSION_PERMISSIONS_HIDDEN", System.Type.GetType("System.String"));
                                    int nRowCount = dt.Rows.Count;
                                    int nRow = 0;
                                    DataRow versionrow = null;
                                    string sPerms = "";
                                    string sPermsHidden = "";
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        nRow++;
                                        int versionid = DBAccess.ReadIntValue(row["MODEL_VERSION_UID"]);
                                        if (versionid != prevversionid || nRow == 1)
                                        {
                                            if (versionrow != null)
                                            {
                                                versionrow["MODEL_VERSION_PERMISSIONS"] = sPerms;
                                                versionrow["MODEL_VERSION_PERMISSIONS_HIDDEN"] = sPermsHidden;
                                            }
                                            sPerms = "";
                                            sPermsHidden = "";
                                            versionrow = dtVersions.Rows.Add();
                                            versionrow["MODEL_VERSION_UID"] = row["MODEL_VERSION_UID"];
                                            versionrow["MODEL_VERSION_NAME"] = row["MODEL_VERSION_NAME"];
                                            versionrow["MODEL_VERSION_DESC"] = row["MODEL_VERSION_DESC"];
                                        }
                                        //mv.MODEL_VERSION_UID, mv.MODEL_VERSION_NAME, mv.MODEL_VERSION_DESC, mgs.GROUP_ID, g.GROUP_NAME, mgs.VIEW_PERMISSION, mgs.EDIT_PERMISSION"
                                        var s = "No Access";
                                        if (!row["GROUP_NAME"].Equals(System.DBNull.Value))
                                        {
                                            if ((int)row["EDIT_PERMISSION"] == 1)
                                                s = "Read/Write";
                                            else if ((int)row["VIEW_PERMISSION"] == 1)
                                                s = "Read Only";
                                            if (sPerms != "")
                                                sPerms += ",";
                                            sPerms += row["GROUP_NAME"].ToString() + "(" + s + ")";
                                            if (sPermsHidden != "")
                                                sPermsHidden += ",";
                                            sPermsHidden += row["GROUP_ID"].ToString() + "::" + row["GROUP_NAME"].ToString() + "::" + row["VIEW_PERMISSION"].ToString() + "::" + row["EDIT_PERMISSION"].ToString();
                                        }

                                        if (nRow == nRowCount && versionrow != null)
                                        {
                                            versionrow["MODEL_VERSION_PERMISSIONS"] = sPerms;
                                            versionrow["MODEL_VERSION_PERMISSIONS_HIDDEN"] = sPermsHidden;
                                            versionrow = null;
                                        }
                                        prevversionid = versionid;
                                    }
                                    _DGrid dg = new _DGrid();
                                    //dg.AddColumn(title: "ID", width: 50, name: "MODEL_VERSION_UID", isId: true, hidden: true);
                                    //dg.AddColumn(title: "Deleted", width: 50, name: "Deleted", type:_DGrid.Type.checkbox, editable: true, hidden: false);
                                    //dg.AddColumn(title: "Name", width: 150, name: "MODEL_VERSION_NAME");
                                    //dg.AddColumn(title: "Description", width: 150, name: "MODEL_VERSION_DESC");
                                    //dg.AddColumn(title: "Permissions", width: 250, name: "MODEL_VERSION_PERMISSIONS");
                                    //dg.AddColumn(title: "PermissionsHidden", width: 180, name: "MODEL_VERSION_PERMISSIONS_HIDDEN");
                                    dg.AddColumn(title: "ID", width: 50, name: "MODEL_VERSION_UID", isId: true, hidden: true);
                                    dg.AddColumn(title: "Deleted", width: 50, name: "Deleted", type: _DGrid.Type.checkbox, editable: false, hidden: true);
                                    dg.AddColumn(title: "Name", width: 150, name: "MODEL_VERSION_NAME", editable: false);
                                    dg.AddColumn(title: "Description", width: 150, name: "MODEL_VERSION_DESC", editable: false);
                                    dg.AddColumn(title: "Permissions", width: 250, name: "MODEL_VERSION_PERMISSIONS", editable: false);
                                    dg.AddColumn(title: "PermissionsHidden", width: 180, name: "MODEL_VERSION_PERMISSIONS_HIDDEN", editable: false, hidden: true);
                                    dg.SetDataTable(dtVersions);
                                    string columnData;
                                    string tableData;
                                    dg.Build(out columnData, out tableData);
                                    xModels.CreateString("dgridVersionsColumnData", columnData);
                                    xModels.CreateString("dgridVersionsTableData", tableData);
                                }
                                dba.Close();
                                sReply = xModels.XML();
                            }
                        }
                        break;
                    }
                    //case "ReadCalendarInfo":
                    //    sReply = ReadCalendarInfo(Context, xData);
                    //    break;
                    case "UpdateModelInfo":
                    {
                        sReply = UpdateModelInfo(Context, xData);
                        break;
                    }
                    case "DeleteModelInfo":
                    {
                        sReply = DeleteModelInfo(Context, xData);
                        break;
                    }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                sReply = WebAdmin.FormatError("exception", "Models.ModelsRequest", ex.Message);
            }

            return sReply;
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
