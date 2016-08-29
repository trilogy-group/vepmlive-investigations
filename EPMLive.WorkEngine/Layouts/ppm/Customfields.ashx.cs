using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using PortfolioEngineCore;

namespace WorkEnginePPM
{

    public partial class Customfields : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            const string this_class = "WorkEnginePPM.Customfields";
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

        public static string CustomfieldRequest(HttpContext Context, string sRequestContext, CStruct xData)
        {
            string sReply = "";
            try
            {
                switch (sRequestContext)
                {
                    case "ReadCustomfieldInfo":
                        {
                            int nFieldId = Int32.Parse(xData.InnerText);
                            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                            DataAccess da = new DataAccess(sBaseInfo);
                            DBAccess dba = da.dba;
                            if (dba.Open() == StatusEnum.rsSuccess)
                            {
                                sReply = ReadCustomFieldInfo(dba, nFieldId);
                            }
                            dba.Close();
                            break;
                        }
                    case "UpdateCustomfieldInfo":
                        sReply = UpdateCustomFieldInfo(Context, xData);
                        break;
                    case "DeleteCustomfieldInfo":
                        sReply = DeleteCustomFieldInfo(Context, xData);
                        break;
                    case "ValidateFormula":
                        {
                            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
                            DataAccess da = new DataAccess(sBaseInfo);
                            DBAccess dba = da.dba;
                            if (dba.Open() == StatusEnum.rsSuccess)
                            {
                                int nFieldId2 = xData.GetIntAttr("FA_FIELD_ID");
                                string sFormula = xData.GetStringAttr("formula");
                                sReply = dbaCustomFields.ValidateAndSaveCustomFieldFormula(dba, nFieldId2, ref sFormula, false);
                            }
                            dba.Close();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                sReply = WebAdmin.FormatError("exception", "Customfields.CustomfieldRequest", ex.Message);
            }

            return sReply;
        }

        private static string ReadCustomFieldInfo(DBAccess dba, int nFieldId)
        {
            string sReply = "";
            CStruct xCustomfield = new CStruct();
            xCustomfield.Initialize("customfield");
            DataTable dt;
            dbaCustomFields.SelectCustomField(dba, nFieldId, out dt);
            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                xCustomfield.CreateInt("FA_FIELD_ID", DBAccess.ReadIntValue(row["FA_FIELD_ID"]));
                xCustomfield.CreateString("FA_NAME", DBAccess.ReadStringValue(row["FA_NAME"], ""));
                xCustomfield.CreateString("FA_DESC", DBAccess.ReadStringValue(row["FA_DESC"], ""));
                xCustomfield.CreateInt("FA_TABLE_ID", DBAccess.ReadIntValue(row["FA_TABLE_ID"]));
                int iDataType = DBAccess.ReadIntValue(row["FA_FORMAT"]);
                xCustomfield.CreateInt("FA_FORMAT", iDataType);

                string sEntity = "";
                int lEntity = DBAccess.ReadIntValue(row["Entity"]);
                xCustomfield.CreateInt("ENTITY_ID", lEntity);
                if (lEntity == 2) sEntity = "Portfolio"; else sEntity = "Resource";
                xCustomfield.CreateString("ENTITY_NAME", sEntity);
                bool bIsDeprecated;
                xCustomfield.CreateString("FA_FORMAT_NAME", EPKClass01.GetFieldFormat(iDataType, out bIsDeprecated));

                string sTable;
                string sField;
                int lTable = DBAccess.ReadIntValue(row["FA_TABLE_ID"]);
                int lField = DBAccess.ReadIntValue(row["FA_FIELD_IN_TABLE"]);
                if (EPKClass01.GetTableAndField(lTable, lField, out sTable, out sField))
                {
                    xCustomfield.CreateString("TABLE_NAME", sTable);
                    xCustomfield.CreateString("FIELD_NAME", sField);
                }
                else
                {
                    xCustomfield.CreateString("TABLE_NAME", "Unknown Table");
                    xCustomfield.CreateString("FIELD_NAME", "");
                }
                if (lEntity == 2)
                {
                    // get the lookup fields for the calculation if entity is portfolio
                    dbaCustomFields.SelectPortfolioFormulaCustomFields(dba, out dt);
                    CStruct xFields = xCustomfield.CreateSubStruct("fields");
                    foreach (DataRow row2 in dt.Rows)
                    {
                        CStruct xField = xFields.CreateSubStruct("field");
                        xField.CreateInt("FA_FIELD_ID", DBAccess.ReadIntValue(row2["FA_FIELD_ID"]));
                        xField.CreateString("FA_NAME", DBAccess.ReadStringValue(row2["FA_NAME"], ""));
                    }
                    string sFormula = "";
                    dbaCustomFields.SelectCustomFieldFormula(dba, nFieldId, out dt);
                    bool bFirst = true;
                    foreach (DataRow row2 in dt.Rows)
                    {
                        decimal decRatio = DBAccess.ReadDecimalValue(row2["CL_RATIO"]);
                        string sComponent = DBAccess.ReadStringValue(row2["ComponentName"], "");
                        int nOp = DBAccess.ReadIntValue(row2["CL_OP"]);

                        if (bFirst == false)
                        {
                            switch (nOp)
                            {
                                case 0:
                                    sFormula += " + ";
                                    break;
                                case 1:
                                    sFormula += " - ";
                                    break;
                                case 2:
                                    sFormula += " * ";
                                    break;
                                case 3:
                                    sFormula += " / ";
                                    break;
                            }
                        }
                        if (Decimal.Compare(decRatio, (decimal)1) != 0)
                        {
                            sFormula += decRatio.ToString("0.###") + " * ";
                        }
                        sFormula += sComponent;

                        bFirst = false;

                    }
                    xCustomfield.CreateString("formula", sFormula);
                }
            }

            sReply = xCustomfield.XML();
            return sReply;
        }
        private static string UpdateCustomFieldInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                int nFieldId = xData.GetIntAttr("FA_FIELD_ID");
                string sFieldName = xData.GetStringAttr("FA_NAME");
                string sFieldDesc = xData.GetStringAttr("FA_DESC");
                int nEntity = xData.GetIntAttr("ENTITY_ID");
                int nFieldType = xData.GetIntAttr("FA_FORMAT");
                string sFormula = xData.GetStringAttr("formula");
                try
                {                    
                    if (dbaCustomFields.UpdateCustomFieldInfo(dba, nEntity, nFieldType, ref nFieldId, sFieldName, sFieldDesc, out sReply) != StatusEnum.rsSuccess)
                    {
                        if (sReply.Length == 0) sReply = WebAdmin.FormatError("exception", "Customfields.UpdateCustomFieldInfo", dba.StatusText);
                    }
                    else
                    {
                        //if (sFormula != "")  // wasn't replaccing with new empty formula
                        sReply = dbaCustomFields.ValidateAndSaveCustomFieldFormula(dba, nFieldId, ref sFormula, true);
                        if (sReply == "")
                        {
                            sReply = ReadCustomFieldInfo(dba, nFieldId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "Customfields.UpdateCustomFieldInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }

        private static string DeleteCustomFieldInfo(HttpContext Context, CStruct xData)
        {
            string sReply = "";
            string sBaseInfo = WebAdmin.BuildBaseInfo(Context);
            DataAccess da = new DataAccess(sBaseInfo);
            DBAccess dba = da.dba;
            if (dba.Open() == StatusEnum.rsSuccess)
            {
                int nFieldId = xData.GetIntAttr("FA_FIELD_ID");
                try
                {
                    dbaCustomFields.DeleteCustomField(dba, nFieldId, out sReply);
                }
                catch (Exception ex)
                {
                    sReply = WebAdmin.FormatError("exception", "Customfields.DeleteCustomFieldInfo", ex.Message);
                }
                dba.Close();
            }
            return sReply;
        }

        #endregion
    }
}
