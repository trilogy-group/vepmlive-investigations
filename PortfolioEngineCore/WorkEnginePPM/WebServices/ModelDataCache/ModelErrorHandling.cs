using System;
using System.Data.SqlClient;
using WorkEnginePPM;
using PortfolioEngineCore;

namespace ModelDataCache
{
    static class ModelErrorHandling
    {
        public static void HandleStatusError(SqlConnection oDataAccess, PortfolioEngineCore.SeverityEnum eSeverity, string sFunction, PortfolioEngineCore.StatusEnum eStatus, string sText, int UserWResID, string sSessionInfo)
        {
            DBTrace(oDataAccess, eStatus, PortfolioEngineCore.TraceChannelEnum.Exception, "HandleStatusError", sFunction, sText, "Severity : " + eSeverity.ToString(), UserWResID, sSessionInfo);
            return;
        }

        private static void DBTrace(SqlConnection oDataAccess, PortfolioEngineCore.StatusEnum eStatus, PortfolioEngineCore.TraceChannelEnum eChannel, string sKeyword, string sFunction, string sText, string sDetails, int UserWResID, string sSessionInfo)
        {
            var xTraceMessages = new CStruct();
            xTraceMessages.Initialize("TraceMessages");

            CStruct xTrace;
            xTrace = xTraceMessages.CreateSubStruct("Trace");
            xTrace.CreateIntAttr("Status", (int)eStatus);
            xTrace.CreateIntAttr("Channel", (int)eChannel);
            xTrace.CreateDateAttr("Timestamp", DateTime.Now);
            xTrace.CreateStringAttr("Keyword", sKeyword);
            xTrace.CreateStringAttr("Function", sFunction);
            xTrace.CreateStringAttr("Text", sText);
            xTrace.CreateStringAttr("Details", sDetails);

            WriteTrace(oDataAccess, xTraceMessages, UserWResID, sSessionInfo);
        }

        private static void WriteTrace(SqlConnection oDataAccess, CStruct xTrace, int UserWResID, string sSessionInfo)
        {
            if (xTrace == null)
                return;
            
            var sCommand =
                "INSERT INTO EPG_LOG (LOG_WRES_ID,LOG_SESSION,LOG_STATUS,LOG_CHANNEL,LOG_TIMESTAMP,LOG_KEYWORD,LOG_FUNCTION,LOG_TEXT,LOG_DETAILS) "
              + " VALUES(@LOG_WRES_ID,@LOG_SESSION,@LOG_STATUS,@LOG_CHANNEL,@LOG_TIMESTAMP,@LOG_KEYWORD,@LOG_FUNCTION,@LOG_TEXT,@LOG_DETAILS)";

            try
            {
                var oCommand = new SqlCommand(sCommand, oDataAccess);

                oCommand.Parameters.AddWithValue("@LOG_WRES_ID", UserWResID);
                oCommand.Parameters.AddWithValue("@LOG_SESSION", sSessionInfo);

                oCommand.Parameters.AddWithValue("LOG_STATUS", xTrace.GetIntAttr("Status"));
                oCommand.Parameters.AddWithValue("LOG_CHANNEL", xTrace.GetIntAttr("Channel"));
                oCommand.Parameters.AddWithValue("LOG_TIMESTAMP",  xTrace.GetDateAttr("Timestamp"));
                oCommand.Parameters.AddWithValue("LOG_KEYWORD", vb.Left(xTrace.GetStringAttr("Keyword"), 48));
                oCommand.Parameters.AddWithValue("LOG_FUNCTION", vb.Left(xTrace.GetStringAttr("Function"), 48));
                oCommand.Parameters.AddWithValue("LOG_TEXT", vb.Left(xTrace.GetStringAttr("Text"), 253));
                oCommand.Parameters.AddWithValue("LOG_DETAILS", vb.Left(xTrace.GetStringAttr("Details"), 2048));

                int lRowsAffected = oCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string StatusText = "";
                StatusText = "WriteTrace Exception : " + ex.Message.ToString();
            }
            return;
        }
    }
}
