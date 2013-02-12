using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal class Notification
    {
        #region Fields (1) 

        private static readonly Dictionary<string, string[]> ValidInputs = new Dictionary<string, string[]>
                                                                               {
                                                                                   {"Type", new[] {"EMAILED", "READ"}},
                                                                                   {"Value", new[] {"false", "true"}}
                                                                               };

        #endregion Fields 

        #region Methods (12) 

        // Private Methods (10) 

        /// <summary>
        /// Builds the notification element.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="epmNotification">The epm notification.</param>
        private static void BuildNotificationElement(XDocument result, EPMNotification epmNotification)
        {
            var xElement = new XElement("Notification");
            xElement.Add(new XAttribute("ID", epmNotification.Id));
            xElement.Add(new XAttribute("Type", epmNotification.Type));
            xElement.Add(new XAttribute("CreatedBy", epmNotification.CreatedBy));
            xElement.Add(new XAttribute("CreatedAt", epmNotification.CreatedAt));
            xElement.Add(new XAttribute("CreatedAtDateString", epmNotification.CreatedAtDateString));
            xElement.Add(new XAttribute("CreatorName", epmNotification.CreatorName));
            xElement.Add(new XAttribute("CreatorThumbnail", epmNotification.CreatorThumbnail));
            xElement.Add(new XAttribute("SiteId", epmNotification.SiteId));
            xElement.Add(new XAttribute("WebId", epmNotification.WebId));
            xElement.Add(new XAttribute("ListId", epmNotification.ListId));
            xElement.Add(new XAttribute("ItemId", epmNotification.ItemId));
            xElement.Add(new XAttribute("NotificationRead", epmNotification.NotificationRead));
            xElement.Add(new XAttribute("UserEmailed", epmNotification.UserEmailed));
            xElement.Add(new XAttribute("Emailed", epmNotification.Emailed));
            xElement.Add(new XAttribute("PersonalizationId", epmNotification.PersonalizationId));
            xElement.Add(new XAttribute("PersonalizationSiteId", epmNotification.PersonalizationSiteId));

            if (!string.IsNullOrEmpty(epmNotification.SiteCreationDate))
            {
                xElement.Add(new XAttribute("SiteCreationDate", epmNotification.SiteCreationDate));
            }

            xElement.Add(new XElement("Title", new XCData(epmNotification.Title)));
            xElement.Add(new XElement("Message", new XCData(epmNotification.Message)));

            if (result.Root != null) result.Root.Add(xElement);
        }

        /// <summary>
        /// Builds the notifications.
        /// </summary>
        /// <param name="epmNotifications">The epm notifications.</param>
        /// <param name="sqlCommand">The SQL command.</param>
        /// <param name="sqlConnection">The SQL connection.</param>
        /// <param name="spWeb">The sp web.</param>
        private static void BuildNotifications(List<EPMNotification> epmNotifications, SqlCommand sqlCommand,
                                               SqlConnection sqlConnection, SPWeb spWeb)
        {
            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                var epmNotification = new EPMNotification
                                          {
                                              Id = sqlDataReader.GetGuid(sqlDataReader.GetOrdinal("ID")),
                                              Type = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Type")),
                                              Title = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Title"))
                                          };


                if (sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Message")) != DBNull.Value)
                    epmNotification.Message = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Message"));

                if (sqlDataReader.GetValue(sqlDataReader.GetOrdinal("CreatedBy")) != DBNull.Value)
                    epmNotification.CreatedBy = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("CreatedBy"));

                if (sqlDataReader.GetValue(sqlDataReader.GetOrdinal("SiteId")) != DBNull.Value)
                    epmNotification.SiteId = sqlDataReader.GetGuid(sqlDataReader.GetOrdinal("SiteId"));

                if (sqlDataReader.GetValue(sqlDataReader.GetOrdinal("WebId")) != DBNull.Value)
                    epmNotification.WebId = sqlDataReader.GetGuid(sqlDataReader.GetOrdinal("WebId"));

                if (sqlDataReader.GetValue(sqlDataReader.GetOrdinal("ListId")) != DBNull.Value)
                    epmNotification.ListId = sqlDataReader.GetGuid(sqlDataReader.GetOrdinal("ListId"));

                if (sqlDataReader.GetValue(sqlDataReader.GetOrdinal("ItemId")) != DBNull.Value)
                    epmNotification.ItemId = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ItemId"));

                if (sqlDataReader.GetValue(sqlDataReader.GetOrdinal("UserEmailed")) != DBNull.Value)
                    epmNotification.UserEmailed = sqlDataReader.GetBoolean(sqlDataReader.GetOrdinal("UserEmailed"));

                if (sqlDataReader.GetValue(sqlDataReader.GetOrdinal("NotificationRead")) != DBNull.Value)
                    epmNotification.NotificationRead =
                        sqlDataReader.GetBoolean(sqlDataReader.GetOrdinal("NotificationRead"));

                if (sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Emailed")) != DBNull.Value)
                    epmNotification.Emailed = sqlDataReader.GetBoolean(sqlDataReader.GetOrdinal("Emailed"));

                if (sqlDataReader.GetValue(sqlDataReader.GetOrdinal("PersonalizationId")) != DBNull.Value)
                    epmNotification.PersonalizationId =
                        sqlDataReader.GetGuid(sqlDataReader.GetOrdinal("PersonalizationId"));

                if (sqlDataReader.GetValue(sqlDataReader.GetOrdinal("PersonalizationSiteId")) != DBNull.Value)
                    epmNotification.PersonalizationSiteId =
                        sqlDataReader.GetGuid(sqlDataReader.GetOrdinal("PersonalizationSiteId"));

                if (sqlDataReader.GetValue(sqlDataReader.GetOrdinal("CreatedAt")) != DBNull.Value)
                    epmNotification.CreatedAt =
                        GetRegionalDateTime(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("CreatedAt")), spWeb);

                if (sqlDataReader.GetValue(sqlDataReader.GetOrdinal("SiteCreationDate")) != DBNull.Value)
                    epmNotification.SiteCreationDate =
                        GetRegionalDateTime(sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("SiteCreationDate")),
                                            spWeb);

                SPRegionalSettings spRegionalSettings = spWeb.CurrentUser.RegionalSettings ?? spWeb.RegionalSettings;
                var cultureInfo = new CultureInfo((int) spRegionalSettings.LocaleId);

                string[] dateParts = epmNotification.CreatedAt.Split(' ')[0].Split('/');
                var dateTime = new DateTime(Convert.ToInt32(dateParts[2]), Convert.ToInt32(dateParts[0]), Convert.ToInt32(dateParts[1]));

                epmNotification.CreatedAtDateString = dateTime.ToString(cultureInfo.DateTimeFormat.ShortDatePattern);

                epmNotification.CreatorThumbnail = string.Format("{0}/_layouts/images/person.gif",
                                                                 spWeb.SafeServerRelativeUrl());

                epmNotification.CreatorName = "System";

                if (epmNotification.CreatedBy != 0)
                {
                    if (epmNotification.SiteId != Guid.Empty)
                    {
                        using (var site = new SPSite(epmNotification.SiteId))
                        {
                            using (SPWeb web = site.OpenWeb())
                            {
                                SPUser user = web.SiteUsers.GetByID(epmNotification.CreatedBy);

                                if (user != null)
                                {
                                    epmNotification.CreatorName = Regex.Replace(user.Name ?? user.LoginName, @"\\",
                                                                                @"\\");

                                    SPList spList = spWeb.Site.RootWeb.SiteUserInfoList;

                                    SPListItem spListItem = spList.GetItemById(user.ID);

                                    var creatorThumbnail = spListItem["Picture"] as string;

                                    if (!string.IsNullOrEmpty(creatorThumbnail))
                                    {
                                        epmNotification.CreatorThumbnail =
                                            creatorThumbnail.Remove(creatorThumbnail.IndexOf(','));
                                    }
                                }
                            }
                        }
                    }
                }

                epmNotifications.Add(epmNotification);
            }
        }

        /// <summary>
        /// Gets the notifications.
        /// </summary>
        /// <param name="notificationStatus">The type.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="firstPage">The first page.</param>
        /// <param name="lastPage">The last page.</param>
        /// <returns></returns>
        private static IEnumerable<EPMNotification> GetNotifications(string notificationStatus, int limit, int firstPage,
                                                                     int lastPage)
        {
            try
            {
                SPWeb currentWeb = SPContext.Current.Web;

                var epmNotifications = new List<EPMNotification>();

                using (var spSite = new SPSite(currentWeb.Site.ID))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(currentWeb.ID))
                    {
                        SPUser spUser = spWeb.CurrentUser;

                        using (
                            var sqlConnection =
                                new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                        {
                            var sqlCommand = new SqlCommand("spNGetNotifications", sqlConnection)
                                                 {CommandType = CommandType.StoredProcedure};

                            SqlParameter userName = sqlCommand.Parameters.Add("@UserName", SqlDbType.NVarChar);
                            SqlParameter userId = sqlCommand.Parameters.Add("@UserId", SqlDbType.NVarChar);
                            SqlParameter siteId = sqlCommand.Parameters.Add("@SiteId", SqlDbType.UniqueIdentifier);

                            SqlParameter siteCreationDateTime =
                                sqlCommand.Parameters.Add("@SiteCreationDateTime", SqlDbType.DateTime);

                            SqlParameter isUserSiteCollectionAdmin =
                                sqlCommand.Parameters.Add("@IsUserSiteCollectionAdmin", SqlDbType.Bit);

                            userName.Value = spUser.LoginName;
                            userId.Value = spUser.ID;
                            siteId.Value = spSite.ID;
                            siteCreationDateTime.Value = spSite.RootWeb.Created;
                            isUserSiteCollectionAdmin.Value = spUser.IsSiteAdmin;

                            SqlParameter theNotificationStatus = sqlCommand.Parameters.Add("@NotificationStatus",
                                                                                           SqlDbType.VarChar);
                            theNotificationStatus.Value = notificationStatus;

                            if (limit != 0)
                            {
                                SqlParameter theLimit = sqlCommand.Parameters.Add("@Limit", SqlDbType.Int);
                                theLimit.Value = limit;
                            }

                            if (firstPage != 0)
                            {
                                SqlParameter theFirstPage = sqlCommand.Parameters.Add("@FirstPage", SqlDbType.Int);
                                theFirstPage.Value = firstPage;
                            }

                            if (lastPage != 0)
                            {
                                SqlParameter theLastPage = sqlCommand.Parameters.Add("@LastPage", SqlDbType.Int);
                                theLastPage.Value = lastPage;
                            }

                            try
                            {
                                SPSecurity.RunWithElevatedPrivileges(
                                    () => { BuildNotifications(epmNotifications, sqlCommand, sqlConnection, spWeb); });
                            }
                            catch (SqlException sqlException)
                            {
                                throw new APIException(10001, sqlException.Message);
                            }
                            finally
                            {
                                sqlConnection.Close();
                            }
                        }
                    }
                }

                return epmNotifications;
            }
            catch (SqlException sqlException)
            {
                throw new APIException(10002, sqlException.Message);
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(10003, e.Message);
            }
        }

        /// <summary>
        /// Gets the notifications for the first load.
        /// </summary>
        /// <param name="notificationStatus">The notification status.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="firstPage">The first page.</param>
        /// <param name="lastPage">The last page.</param>
        /// <returns></returns>
        private static string GetNotificationsForTheFirstLoad(string notificationStatus, int limit, int firstPage,
                                                              int lastPage)
        {
            if (!notificationStatus.Equals("ALL")) return string.Empty;

            IEnumerable<EPMNotification> epmNotifications =
                GetNotifications(notificationStatus, limit, firstPage, lastPage).ToList();

            IEnumerable<EPMNotification> newNotifications = epmNotifications.Where(n => !n.NotificationRead).ToList();

            var result = new XDocument();
            result.Add(new XElement("Notifications", new XAttribute("TotalNew", newNotifications.Count())));

            int count = epmNotifications.Count();
            if (count > 15)
            {
                foreach (EPMNotification epmNotification in epmNotifications.Skip(count - 15))
                {
                    BuildNotificationElement(result, epmNotification);
                }
            }
            else
            {
                foreach (EPMNotification epmNotification in epmNotifications)
                {
                    BuildNotificationElement(result, epmNotification);
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Gets the paging constraints.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="notificationStatus">The notification status.</param>
        /// <param name="firstPage">The first page.</param>
        /// <param name="lastPage">The last page.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="firstLoad">if set to <c>true</c> [first load].</param>
        private static void GetPagingConstraints(string data, out string notificationStatus, out int firstPage,
                                                 out int lastPage, out int limit, out bool firstLoad)
        {
            notificationStatus = "ALL";
            limit = 0;
            firstPage = 0;
            lastPage = 0;
            firstLoad = false;

            XDocument xDocument = XDocument.Parse(data);

            if (xDocument.Root == null || !xDocument.Root.Name.LocalName.Equals("Notifications"))
            {
                throw new APIException(10501, @"Root element ""Notifications"" not found");
            }

            XAttribute notificationStatusAttribute = xDocument.Root.Attribute("Status");
            if (notificationStatusAttribute != null)
            {
                string value = notificationStatusAttribute.Value;
                if (!value.Equals("ALL") && !value.Equals("NEW") && !value.Equals("OLD"))
                {
                    throw new Exception(
                        string.Format(
                            @"{0} is not a valid value for the Notification Status. Expected value is one of these: ALL, NEW, OLD.",
                            value));
                }

                notificationStatus = value;
            }

            XAttribute limitAttribute = xDocument.Root.Attribute("Limit");
            if (limitAttribute != null)
            {
                limit = Convert.ToInt32(limitAttribute.Value);
            }

            XAttribute firstPageAttribute = xDocument.Root.Attribute("FirstPage");
            if (firstPageAttribute != null)
            {
                firstPage = Convert.ToInt32(firstPageAttribute.Value);
            }

            XAttribute lastPageAttribute = xDocument.Root.Attribute("LastPage");
            if (lastPageAttribute != null)
            {
                lastPage = Convert.ToInt32(lastPageAttribute.Value);
            }

            XAttribute firstLoadAttribute = xDocument.Root.Attribute("FirstLoad");
            if (firstLoadAttribute != null)
            {
                bool.TryParse(firstLoadAttribute.Value, out firstLoad);
            }
        }

        /// <summary>
        /// Gets the regional date time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        private static string GetRegionalDateTime(DateTime dateTime, SPWeb spWeb)
        {
            string result = string.Empty;

            using (var spSite = new SPSite(spWeb.Site.ID))
            {
                using (SPWeb web = spSite.OpenWeb(spWeb.ID))
                {
                    SPUser user = web.CurrentUser;

                    SPRegionalSettings spRegionalSettings = user.RegionalSettings ?? web.RegionalSettings;

                    if (dateTime != DateTime.MinValue)
                    {
                        DateTime utcToLocalTime = spRegionalSettings.TimeZone.UTCToLocalTime(dateTime.ToUniversalTime());
                        result = utcToLocalTime.ToString("M/d/yyyy HH:mm:ss").Replace('-', '/').Replace('.', '/');
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Sets the notification flag.
        /// </summary>
        /// <param name="epmNotification">The epm notification.</param>
        /// <param name="sqlConnection">The SQL connection.</param>
        /// <param name="user">The user.</param>
        private static void SetNotificationFlag(EPMNotification epmNotification, SqlConnection sqlConnection,
                                                SPUser user)
        {
            var sqlCommand = new SqlCommand("spNSetBit", sqlConnection) {CommandType = CommandType.StoredProcedure};

            SqlParameter notificationId = sqlCommand.Parameters.Add("@FK", SqlDbType.UniqueIdentifier);
            SqlParameter userId = sqlCommand.Parameters.Add("@userid", SqlDbType.VarChar);
            SqlParameter index = sqlCommand.Parameters.Add("@index", SqlDbType.Int);
            SqlParameter bit = sqlCommand.Parameters.Add("@val", SqlDbType.Bit);

            notificationId.Value = epmNotification.Id;
            userId.Value = epmNotification.Type > 1 ? user.ID.ToString() : user.LoginName;
            index.Value = epmNotification.FlagToSet;
            bit.Value = true;

            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                                                         {
                                                             sqlConnection.Open();
                                                             sqlCommand.ExecuteNonQuery();
                                                         });
            }
            catch (SqlException sqlException)
            {
                throw new APIException(10509, sqlException.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// Sets the notification flags.
        /// </summary>
        /// <param name="epmNotifications">The epm notifications.</param>
        private static void SetNotificationFlags(IEnumerable<EPMNotification> epmNotifications)
        {
            try
            {
                SPWeb spWeb = SPContext.Current.Web;
                using (var spSite = new SPSite(spWeb.Site.ID))
                {
                    using (SPWeb web = spSite.OpenWeb(spWeb.ID))
                    {
                        using (
                            var sqlConnection =
                                new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                        {
                            foreach (EPMNotification epmNotification in epmNotifications)
                            {
                                SPUser currentUser = web.CurrentUser;
                                TranslateNotificationToPersonalization(epmNotification, sqlConnection, currentUser);

                                SetNotificationFlag(epmNotification, sqlConnection, currentUser);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlException)
            {
                throw new APIException(10506, sqlException.Message);
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(10507, e.Message);
            }
        }

        /// <summary>
        /// Translates the notification to personalization.
        /// </summary>
        /// <param name="epmNotification">The epm notification.</param>
        /// <param name="sqlConnection">The SQL connection.</param>
        /// <param name="user">The user.</param>
        private static void TranslateNotificationToPersonalization(EPMNotification epmNotification,
                                                                   SqlConnection sqlConnection, SPUser user)
        {
            var sqlCommand = new SqlCommand("spNTranslateNotificationToPersonalization", sqlConnection)
                                 {CommandType = CommandType.StoredProcedure};

            SqlParameter notificationId = sqlCommand.Parameters.Add("@NotificationId", SqlDbType.UniqueIdentifier);
            SqlParameter userName = sqlCommand.Parameters.Add("@UserName", SqlDbType.NVarChar);
            SqlParameter userId = sqlCommand.Parameters.Add("@UserId", SqlDbType.NVarChar);

            notificationId.Value = epmNotification.Id;
            userName.Value = user.LoginName;
            userId.Value = user.ID;

            try
            {
                SPSecurity.RunWithElevatedPrivileges(() =>
                                                         {
                                                             sqlConnection.Open();
                                                             sqlCommand.ExecuteNonQuery();
                                                         });
            }
            catch (SqlException sqlException)
            {
                throw new APIException(10508, sqlException.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// Validates the set notification flags input data.
        /// </summary>
        /// <param name="xDocument">The x document.</param>
        private static void ValidateSetNotificationFlagsInputData(XDocument xDocument)
        {
            if (xDocument.Root == null || !xDocument.Root.Name.LocalName.Equals("Notifications"))
            {
                throw new APIException(10501, @"Root element ""Notifications"" not found");
            }

            IEnumerable<XElement> notificationElements = xDocument.Root.Elements("Notification");
            bool noNotificationElements = true;

            int notificationIndex = 0;
            foreach (XElement notificationElement in notificationElements)
            {
                noNotificationElements = false;

                if (!notificationElement.Attributes().ToList().Exists(a => a.Name.LocalName.Equals("ID")))
                {
                    throw new APIException(10502,
                                           string.Format(
                                               @"Attribute ""ID"" not found for the Notification at index {0}",
                                               notificationIndex));
                }

                if (!notificationElement.Attributes().ToList().Exists(a => a.Name.LocalName.Equals("Type")))
                {
                    throw new APIException(10507,
                                           string.Format(
                                               @"Attribute ""Type"" not found for the Notification at index {0}",
                                               notificationIndex));
                }

                int type;
                if (!int.TryParse(notificationElement.Attribute("Type").Value, out type))
                {
                    throw new APIException(10508,
                                           string.Format(
                                               @"The value for attribute ""Type"" must be an integer at index {0}",
                                               notificationIndex));
                }

                IEnumerable<XElement> flagElements = notificationElement.Elements("Flag");
                bool noFlagElements = true;

                int flagIndex = 0;
                foreach (XElement flagElement in flagElements)
                {
                    noFlagElements = false;

                    List<XAttribute> flagAttributes = flagElement.Attributes().ToList();

                    foreach (var validInput in ValidInputs)
                    {
                        string attribute = validInput.Key;

                        if (!flagAttributes.Exists(a => a.Name.LocalName.Equals(attribute)))
                        {
                            throw new APIException(10503,
                                                   string.Format(
                                                       @"Attribute ""{0}"" not found for the Notification at index {1}, Flag at index {2}",
                                                       attribute, notificationIndex, flagIndex));
                        }

                        string value =
                            (flagAttributes.Where(a => a.Name.LocalName.Equals(attribute)).Select(a => a.Value)).
                                FirstOrDefault();

                        if (!validInput.Value.Contains(value))
                        {
                            throw new APIException(10504,
                                                   string.Format(
                                                       @"""{0}"" is not a valid value for the attribute ""{1}."" The expected value is any one of these: ""{2}""",
                                                       value, attribute, string.Join(", ", validInput.Value)));
                        }
                    }

                    flagIndex++;
                }

                if (noFlagElements)
                {
                    throw new APIException(10505,
                                           string.Format(
                                               @"No ""Flag"" element found for the Notification at index {0}.",
                                               notificationIndex));
                }

                notificationIndex++;
            }

            if (noNotificationElements)
            {
                throw new APIException(10506, @"No ""Notification"" element found.");
            }
        }

        // Internal Methods (2) 

        /// <summary>
        /// Gets the notifications.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetNotifications(string data)
        {
            try
            {
                string notificationStatus;
                int limit;
                int firstPage;
                int lastPage;
                bool firstLoad;

                GetPagingConstraints(data, out notificationStatus, out firstPage, out lastPage, out limit, out firstLoad);

                if (firstLoad)
                {
                    return GetNotificationsForTheFirstLoad(notificationStatus, limit, firstPage, lastPage);
                }

                var result = new XDocument();
                result.Add(new XElement("Notifications"));

                foreach (
                    EPMNotification epmNotification in GetNotifications(notificationStatus, limit, firstPage, lastPage))
                {
                    BuildNotificationElement(result, epmNotification);
                }

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(10000, e.Message);
            }
        }

        /// <summary>
        /// Sets the notification flags.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string SetNotificationFlags(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("Notifications"));

                XDocument xDocument = XDocument.Parse(data);

                ValidateSetNotificationFlagsInputData(xDocument);

                XAttribute markAllReadAttr = xDocument.Root.Attribute("MarkAllRead");
                if (markAllReadAttr != null && markAllReadAttr.Value.Equals("true"))
                {
                    var notifications = new List<EPMNotification>();

                    foreach (EPMNotification epmNotification in GetNotifications("NEW", 0, 0, 0))
                    {
                        EPMNotification notification = epmNotification;

                        notification.FlagToSet = 2;
                        notifications.Add(notification);
                    }

                    SetNotificationFlags(notifications);

                    return result.ToString();
                }

                var epmNotifications = new List<EPMNotification>();

                foreach (XElement notificationElement in xDocument.Root.Elements("Notification"))
                {
                    var epmNotification = new EPMNotification
                                              {
                                                  Id = new Guid(notificationElement.Attribute("ID").Value),
                                                  Type = Convert.ToInt32(notificationElement.Attribute("Type").Value)
                                              };

                    foreach (XElement flagElement in notificationElement.Elements("Flag"))
                    {
                        string value = flagElement.Attribute("Value").Value;

                        int flagToSet = 0;
                        switch (flagElement.Attribute("Type").Value)
                        {
                            case "EMAILED":
                                epmNotification.UserEmailed = Boolean.Parse(value);
                                flagToSet = 1;
                                break;
                            case "READ":
                                epmNotification.NotificationRead = Boolean.Parse(value);
                                flagToSet = 2;
                                break;
                        }


                        epmNotification.FlagToSet = flagToSet;
                    }

                    epmNotifications.Add(epmNotification);
                }

                SetNotificationFlags(epmNotifications);

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(10500, e.Message);
            }
        }

        #endregion Methods 

        #region Nested type: EPMNotification

        private struct EPMNotification
        {
            #region Data Members (20) 

            public string CreatedAt;
            public string CreatedAtDateString;
            public int CreatedBy;
            public string CreatorName;
            public string CreatorThumbnail;
            public bool Emailed;
            public int FlagToSet;
            public Guid Id;
            public int ItemId;
            public Guid ListId;
            public string Message;
            public bool NotificationRead;
            public Guid PersonalizationId;
            public Guid PersonalizationSiteId;
            public string SiteCreationDate;
            public Guid SiteId;
            public string Title;
            public int Type;
            public bool UserEmailed;
            public Guid WebId;

            #endregion Data Members 
        }

        #endregion
    }
}