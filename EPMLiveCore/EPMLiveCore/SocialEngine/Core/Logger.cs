using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Core
{
    internal class Logger
    {
        public void Log(ObjectKind objectKind, ActivityKind activityKind,
            Dictionary<string, object> data, SPWeb spWeb, Exception exception)
        {
            var details = new XElement("Details");

            foreach (var d in data)
            {
                details.Add(new XElement(d.Key, new XCData((d.Value ?? string.Empty).ToString())));
            }

            if (exception.InnerException != null)
            {
                details.Add(new XElement("InnerException", new XCData(exception.InnerException.Message)));
            }

            var kind = LogKind.Error;

            var socialEngineException = exception as SocialEngineException;
            if (socialEngineException != null) kind = socialEngineException.LogKind;

            const string SQL =
                @"INSERT INTO SS_Logs (Message, StackTrace, Details, Kind, WebId, UserId) VALUES (@Message, @StackTrace, @Details, @Kind, @WebId, @UserId)";

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                string cs = CoreFunctions.getReportingConnectionString(spWeb.Site.WebApplication.Id, spWeb.Site.ID);

                using (var sqlConnection = new SqlConnection(cs))
                {
                    using (var sqlCommand = new SqlCommand(SQL, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Message", exception.Message);
                        sqlCommand.Parameters.AddWithValue("@StackTrace", exception.StackTrace);
                        sqlCommand.Parameters.AddWithValue("@Details", details.ToString());
                        sqlCommand.Parameters.AddWithValue("@Kind", kind);
                        sqlCommand.Parameters.AddWithValue("@WebId", spWeb.ID);
                        sqlCommand.Parameters.AddWithValue("@UserId", spWeb.CurrentUser.ID);

                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            });
        }
    }
}