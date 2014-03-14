using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Core
{
    internal class Logger
    {
        #region Methods (5) 

        // Public Methods (3) 

        public Guid Log(SPWeb contextWeb, Exception exception)
        {
            XElement details = GetDetails(new Dictionary<string, object>());
            return AddLog(contextWeb, exception.Message, exception.StackTrace, details, LogKind.Error, null, null);
        }

        public Guid Log(ObjectKind objectKind, ActivityKind activityKind,
            Dictionary<string, object> data, SPWeb spWeb, Exception exception)
        {
            XElement details = GetDetails(data);

            if (exception.InnerException != null)
            {
                details.Add(new XElement("InnerException", new XCData(exception.InnerException.Message)));
            }

            var kind = LogKind.Error;

            var socialEngineException = exception as SocialEngineException;
            if (socialEngineException != null) kind = socialEngineException.LogKind;

            return AddLog(spWeb, exception.Message, exception.StackTrace, details, kind, objectKind, activityKind);
        }

        public Guid Log(ObjectKind objectKind, ActivityKind activityKind, Dictionary<string, object> data, SPWeb spWeb,
            string message)
        {
            return AddLog(spWeb, message, null, GetDetails(data), LogKind.Info, objectKind, activityKind);
        }

        // Private Methods (2) 

        private static Guid AddLog(SPWeb spWeb, string message, string stackTrace, XElement details, LogKind kind,
            ObjectKind? objectKind, ActivityKind? activityKind)
        {
            Guid id = Guid.NewGuid();

            if (objectKind.HasValue)
            {
                details.Add(new XElement("ObjectKind", objectKind.Value.ToString()));
            }

            if (activityKind.HasValue)
            {
                details.Add(new XElement("ActivityKind", activityKind.Value.ToString()));
            }

            const string SQL =
                @"INSERT INTO SS_Logs (Id, Message, StackTrace, Details, Kind, WebId, UserId) VALUES (@Id, @Message, @StackTrace, @Details, @Kind, @WebId, @UserId)";

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                string cs = CoreFunctions.getReportingConnectionString(spWeb.Site.WebApplication.Id, spWeb.Site.ID);

                using (var sqlConnection = new SqlConnection(cs))
                {
                    using (var sqlCommand = new SqlCommand(SQL, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Id", id);
                        sqlCommand.Parameters.AddWithValue("@Message", message);
                        sqlCommand.Parameters.AddWithValue("@StackTrace", stackTrace);
                        sqlCommand.Parameters.AddWithValue("@Details", details.ToString());
                        sqlCommand.Parameters.AddWithValue("@Kind", kind);
                        sqlCommand.Parameters.AddWithValue("@WebId", spWeb.ID);
                        sqlCommand.Parameters.AddWithValue("@UserId", spWeb.CurrentUser.ID);

                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            });

            return id;
        }

        private static XElement GetDetails(Dictionary<string, object> data)
        {
            var details = new XElement("Details");

            foreach (var d in data)
            {
                try
                {
                    details.Add(new XElement(d.Key, new XCData((d.Value ?? string.Empty).ToString())));
                }
                catch { }
            }

            return details;
        }

        #endregion Methods 
    }
}