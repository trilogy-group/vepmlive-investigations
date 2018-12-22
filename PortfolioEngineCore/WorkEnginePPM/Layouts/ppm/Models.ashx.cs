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

        internal static void InitializeSecurityColumns(_TGrid tg)
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

        private static string ReadModelInfo(HttpContext context, CStruct xData)
        {
            var reply = string.Empty;
            var viewId = int.Parse(xData.InnerText);
            var baseInfo = WebAdmin.BuildBaseInfo(context);
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

                        ModelsControlCreation.CreateModel(dataTable, out models, out selectedFlagField);
                        ModelsControlCreation.CreateCalendars(models, dbAccess);
                        ModelsControlCreation.CreateCostTypes(models, dbAccess, viewId);
                        ModelsControlCreation.CreateFlagCustomFields(models, dbAccess, selectedFlagField);
                        ModelsControlCreation.SelectAndUpdateSecurity(dbAccess, models);
                        dbaModels.SelectModelVersions(dbAccess, viewId, out dataTable);
                        var versions = ModelsControlCreation.BuildNewDataTableWithPermissions(dataTable);
                        var dGrid = ModelsControlCreation.UpdateGrid(versions);
                        ModelsControlCreation.PopulateModels(dGrid, models);

                        reply = models.XML();
                    }
                }
            }
            return reply;
        }

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
    }
}
