using System;
using System.Web;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using PortfolioEngineCore;

namespace WorkEnginePPM
{

    public partial class PostCostValuesHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        private const string ReadCalendarsForCostTypeRequestName = "ReadCalendarsForCostType";
        private const string PostCostValuesRequestName = "PostCostValues";
        private const string PostOnProjectRateChangeRequestName = "PostOnProjectResourceRateChange";
        private const string ProjectIdInAttribute = "ProjectId";
        private const string PublishInAttribute = "Publish";
        private const string PublishBaselineInAttribute = "PublishBaseline";

        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            const string this_class = "WorkEnginePPM.PostCostValuesHandler";
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

        /// <summary>
        /// Based on the request name calls the proper method. 
        /// </summary>
        /// <param name="context">The HTTP Context.</param>
        /// <param name="requestContext">The request name.
        /// Supported values:
        /// <see cref="ReadCalendarsForCostTypeRequestName"/>
        /// <see cref="PostCostValuesRequestName"/>
        /// <see cref="PostOnProjectRateChangeRequestName"/>
        /// </param>
        /// <param name="xmlData">Request data in XML format.</param>
        /// <returns>The response received from called function or empty if request is not supported.</returns>
        public static string PostCostValuesRequest(HttpContext context, string requestContext, CStruct xmlData)
        {
            var reply = string.Empty;
            var supportedRequests = new[] { ReadCalendarsForCostTypeRequestName, PostCostValuesRequestName, PostOnProjectRateChangeRequestName };

            // return if request is not supported
            if (string.IsNullOrWhiteSpace(requestContext) || !supportedRequests.Contains(requestContext))
            {
                return reply;
            }

            // process request
            try
            {
                var baseInfo = WebAdmin.BuildBaseInfo(context);
                var dataAccess = new DataAccess(baseInfo);
                var dbAccess = dataAccess.dba;

                if (dbAccess.Open() == StatusEnum.rsSuccess)
                {
                    try
                    {
                        switch (requestContext)
                        {
                            case ReadCalendarsForCostTypeRequestName:
                                var fieldId = int.Parse(xmlData.InnerText);
                                reply = ReadCalendarsForCostType(dbAccess, fieldId);
                                break;
                            case PostCostValuesRequestName:
                                reply = PostCostValues(dbAccess, xmlData, dataAccess.BasePath);
                                break;
                            case PostOnProjectRateChangeRequestName:
                                reply = PostOnProjectResourceRateChange(dbAccess, xmlData, dataAccess.BasePath);
                                break;
                        }
                    }
                    finally
                    {
                        dbAccess.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                reply = WebAdmin.FormatError("exception", "CostTypeCustomFields.CustomfieldRequest", ex.Message);
            }

            return reply;
        }

        private static string ReadCalendarsForCostType(DBAccess dba, int nCTId)
        {
            string sReply = "";
            DataTable dt;
            dbaEditCosts.SelectCostType(dba, nCTId, out dt);
            int editmode = 0;
            int ctCalendarId = -1;
            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];
                editmode = DBAccess.ReadIntValue(row["CT_EDIT_MODE"]);
                ctCalendarId = DBAccess.ReadIntValue(row["CT_CB_ID"]);
            }

            CStruct xCalendars = new CStruct();
            xCalendars.Initialize("calendars");
            dbaCalendars.SelectCalendars(dba, out dt);
            foreach (DataRow row in dt.Rows)
            {
                int calendarId = DBAccess.ReadIntValue(row["CB_ID"]);
                if (editmode != 1 || calendarId != ctCalendarId)
                {
                    CStruct xItem = xCalendars.CreateSubStruct("item");
                    xItem.CreateIntAttr("id", calendarId);
                    xItem.CreateStringAttr("name", DBAccess.ReadStringValue(row["CB_NAME"], ""));
                }
            }

            dba.Close();

            sReply = xCalendars.XML();
            return sReply;
        }

        /// <summary>
        /// Adds portfolio engine job for processing cost value updates after project resource rate change.
        /// </summary>
        /// <param name="dba">The database access object.</param>
        /// <param name="xmlData">Request data in XML format.
        /// Must have XML attributes:
        ///     ProjectId <see cref="ProjectIdInAttribute"/>
        ///     Publish <see cref="PublishInAttribute"/>
        ///     PublishBaseline <see cref="PublishBaselineInAttribute"/>
        /// </param>
        /// <param name="basePath">The base path for site.</param>
        /// <returns>The string value "1" if succeed, "0" if no job created.</returns>
        private static string PostOnProjectResourceRateChange(DBAccess dba, CStruct xmlData, string basePath)
        {
            // parse request data
            var projectId = xmlData.GetIntAttr(ProjectIdInAttribute).ToString("0");
            var publish = xmlData.GetBooleanAttr(PublishInAttribute);
            var publishBaseline = xmlData.GetBooleanAttr(PublishBaselineInAttribute);
            return dbaQueueManager.PostCostValuesOnProjectRatesChange(dba, basePath, projectId, publish, publishBaseline);
        }

        private static string PostCostValues(DBAccess dba, CStruct xData, string basePath)
        {
            string sReply = "";
            int nCTId = xData.GetIntAttr("CT_ID");
            int nCBId = xData.GetIntAttr("CB_ID");

            int lMethod = 0;
            if (lMethod == 0)
            {
                // add job to Queue for immediate execution
                CStruct xRequest = new CStruct();
                xRequest.Initialize("Request");
                CStruct xSet = xRequest.CreateSubStruct("EPKSet");
                xSet.CreateString("EPKAuth", "");
                CStruct xProcess = xSet.CreateSubStruct("EPKProcess");
                xProcess.CreateInt("RequestNo", 2);
                CStruct xCBCTs = xProcess.CreateSubStruct("CBCTs");
                CStruct xCBCT = xCBCTs.CreateSubStruct("CBCT");
                xCBCT.CreateIntAttr("CTID", nCTId);
                xCBCT.CreateIntAttr("CBID", nCBId);
                int lRowsAffected;
                dbaQueueManager.PostCostValues(dba, "Post Cost Values for CTID=" + nCTId.ToString("0") + " and CBID=" + nCBId.ToString("0"), xRequest.XML(), basePath, out lRowsAffected);
            }
            else if (lMethod == 1)
            {
                // execute synchronously - NAX Version
                CStruct xRequest = new CStruct();
                xRequest.Initialize("Data");
                CStruct xCB = xRequest.CreateSubStruct("CB");
                xCB.CreateIntAttr("Id", nCBId);
                CStruct xCT = xRequest.CreateSubStruct("CT");
                xCT.CreateIntAttr("Id", nCTId);

                string sResult = "";
                string sPostInstruction = "";
                bool bUpdateOK = true;

                bUpdateOK = dbaCostValues.PostCostValues(dba, xRequest.XML(), out sResult, out sPostInstruction);

                //Admininfos adminCore = GetAdminCore(SecurityLevels.Base);
                //bUpdateOK = adminCore.PostCostValues(xDataInputElement.XML(), out sResult, out sPostInstruction);

                //if (!AdminFunctions.CalcCategoryRates(dba, out sReply))
                //{
                //    sReply = DBAccess.FormatAdminError("error", "Post Cost Values.Post", sReply);
                //    dba.Status = StatusEnum.rsRequestCannotBeCompleted;
                //}
                //else
                //{
                //    //CStruct xCalendar = new CStruct();
                //    //xCalendar.Initialize("calendar");
                //    //xCalendar.CreateIntAttr("calendarid", nCalendarId);
                //    //xCalendar.CreateStringAttr("name", sCalendarName);
                //    //sReply = xCalendar.XML();
                //}
            }
            else if (lMethod == 2)
            {
                // add job to Queue for immediate execution - NAX version
                CStruct xQueue = new CStruct();
                xQueue.Initialize("Queue");
                xQueue.CreateInt("JobContext", (int)QueuedJobContext.qjcPostCostValues);
                xQueue.CreateString("Context", "Post Cost Values");
                xQueue.CreateString("Comment", "from Admin Page");

                CStruct xRequest = new CStruct();
                xRequest.Initialize("Data");
                CStruct xCB = xRequest.CreateSubStruct("CB");
                xCB.CreateIntAttr("Id", nCBId);
                CStruct xCT = xRequest.CreateSubStruct("CT");
                xCT.CreateIntAttr("Id", nCTId);

                xQueue.CreateString("Data", xRequest.XML());
                AdminFunctions.SubmitJobRequest(dba, dba.UserWResID, xQueue.XML(), basePath);

            }

            return sReply;
        }

        //private Admininfos GetAdminCore(SecurityLevels secLevel, bool debugging = false)
        //{
        //    Admininfos adminClass = null;

        //    SPSecurity.RunWithElevatedPrivileges(
        //        () => { adminClass = InitilizeAdminCore(secLevel, debugging, Username); });

        //    return adminClass;
        //}

        #endregion
    }
}
