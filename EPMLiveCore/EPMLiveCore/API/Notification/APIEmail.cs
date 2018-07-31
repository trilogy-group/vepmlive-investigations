using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.Mail;
using System.Xml;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore.API
{
    public class APIEmail
    {
        private const int _defaultUserId = 1073741823;

        public static void InstallAssignedToEvent(SPList list)
        {
            string assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
            string className = "EPMLiveCore.AssignedToEvent";

            bool del = false;
            bool add = false;
            bool upd = false;
            
            SPEventReceiverDefinitionCollection eventColl = list.EventReceivers; 

            foreach(SPEventReceiverDefinition eventDef in eventColl)
            {
                if(eventDef.Assembly.Equals(assemblyName) && eventDef.Class.Equals(className))
                {
                    if(eventDef.Type.Equals(SPEventReceiverType.ItemAdded))
                        add = true;

                    if(eventDef.Type.Equals(SPEventReceiverType.ItemUpdating))
                        upd = true;                    
                }
            }

            if(!add)
            {
                list.EventReceivers.Add(SPEventReceiverType.ItemAdded, assemblyName, className);
            }

            if(!upd)
            {
                list.EventReceivers.Add(SPEventReceiverType.ItemUpdating, assemblyName, className);
            }

            list.EnableAssignToEmail = false;

            if(!add || !upd || !del)
                list.Update();
        }

        public static void UnInstallAssignedToEvent(SPList list)
        {
            string assemblyName = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
            string className = "EPMLiveCore.AssignedToEvent";

            SPEventReceiverDefinitionCollection eventColl = list.EventReceivers;
            List<SPEventReceiverDefinition> listsToDelete = new List<SPEventReceiverDefinition>();

            foreach(SPEventReceiverDefinition eventDef in eventColl)
            {
                if(eventDef.Assembly.Equals(assemblyName) && eventDef.Class.Equals(className))
                {
                    listsToDelete.Add(eventDef);
                }
            }

            if(listsToDelete.Count > 0)
            {
                foreach(SPEventReceiverDefinition eventDel in listsToDelete)
                {
                    eventDel.Delete();
                }
            }

            list.Update();
        }

        private static void GetCoreInformation(SqlConnection cn, int templateid, out string body, out string subject, SPWeb web, SPUser curUser)
        {
            body = "";
            subject = "";
            //shortmessage = "";

            SqlCommand cmd = new SqlCommand("SELECT subject,body from EMAILTEMPLATES where emailid=@id", cn);
            cmd.Parameters.AddWithValue("@id", templateid);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                subject = dr.GetString(0);
                body = dr.GetString(1);
                //shortmessage = dr.GetString(2);
            }
            dr.Close();
                                
            body = body.Replace("{SiteName}", web.Title);
            body = body.Replace("{SiteUrl}", web.Url);

            body = body.Replace("{CurUser_Name}", curUser.Name);
            body = body.Replace("{CurUser_Email}", curUser.Email);
            body = body.Replace("{CurUser_Username}", CoreFunctions.GetJustUsername(curUser.LoginName));

            subject = subject.Replace("{SiteName}", web.Title);
            subject = subject.Replace("{SiteUrl}", web.Url);

            subject = subject.Replace("{CurUser_Name}", curUser.Name);
            subject = subject.Replace("{CurUser_Email}", curUser.Email);
            subject = subject.Replace("{CurUser_Username}", CoreFunctions.GetJustUsername(curUser.LoginName));

            //shortmessage = shortmessage.Replace("{SiteName}", web.Title);
            //shortmessage = shortmessage.Replace("{SiteUrl}", web.Url);

            //shortmessage = shortmessage.Replace("{CurUser_Name}", curUser.Name);
            //shortmessage = shortmessage.Replace("{CurUser_Email}", curUser.Email);
            //shortmessage = shortmessage.Replace("{CurUser_Username}", CoreFunctions.GetJustUsername(curUser.LoginName));
        }

        public static void QueueItemMessage(int templateid, bool hideFromUser, Hashtable additionalParams, string[] newusers, string[] delusers, bool doNotEmail, bool unmarkread, SPListItem li, SPUser curUser, bool forceNewEntry)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                iQueueItemMessage(templateid, hideFromUser, additionalParams, newusers, delusers, doNotEmail, unmarkread, li, curUser, forceNewEntry);
            });
        }

        public static void QueueItemMessage(int templateid, bool hideFromUser, Hashtable additionalParams, string[] newusers, string[] delusers, bool doNotEmail, bool unmarkread, SPWeb web, SPUser curUser, bool forceNewEntry)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                iQueueItemMessage(templateid, hideFromUser, additionalParams, newusers, delusers, doNotEmail, unmarkread, web, curUser, forceNewEntry);
            });
        }

        public static void ClearNotificationItem(SPListItem listItem)
        {
            if (listItem == null)
            {
                throw new ArgumentNullException(nameof(listItem));
            }

            if (listItem.ParentList == null)
            {
                throw new ArgumentNullException(nameof(listItem.ParentList));
            }

            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                try
                {
                    var connectionStr = CoreFunctions.getConnectionString(listItem.ParentList.ParentWeb.Site.WebApplication.Id);
                    using (var connection = new SqlConnection(connectionStr))
                    {
                        connection.Open();

                        using (var command = new SqlCommand("spNDeleteNotification", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@listid", listItem.ParentList.ID);
                            command.Parameters.AddWithValue("@itemid", listItem.ID);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception exception)
                {
                    Trace.TraceError(exception.ToString());
                    throw;
                }
            });
        }

        public static string QueueItemMessageXml(string data, SPWeb oWeb)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);
            int templateid = int.Parse(doc.FirstChild.Attributes["TemplateID"].Value);
            bool hideFromUser = false;
            bool doNotEmail = false;
            bool unMarkRead = true;
            bool forceNewEntry = false;
            string listName = "";
            string listId = "";
            string itemid = "";
            string webid = "";
            string sExternalColumn = "";
             
            try
            {
                listName = doc.FirstChild.Attributes["ListName"].Value;
            }catch{}
            try
            {
                listId = doc.FirstChild.Attributes["ListID"].Value;
            }catch{}
            try
            {
                itemid = doc.FirstChild.Attributes["ItemID"].Value;
            }catch{}
            try
            {
                webid = doc.FirstChild.Attributes["WebID"].Value;
            }catch{}

            try 
            {
                hideFromUser = bool.Parse(doc.FirstChild.Attributes["HideFromUser"].Value);
            }catch{}
            try
            {
                doNotEmail = bool.Parse(doc.FirstChild.Attributes["DoNotEmail"].Value);
            }catch{}
            try
            {
                unMarkRead = bool.Parse(doc.FirstChild.Attributes["UnMarkRead"].Value);
            }catch{}
            try
            {
                forceNewEntry = bool.Parse(doc.FirstChild.Attributes["ForceNewEntry"].Value);
            }catch{}

            Hashtable hshParams = new Hashtable();

            XmlNode nd = doc.FirstChild.SelectSingleNode("Params");
            foreach(XmlNode ndParam in nd.SelectNodes("Param"))
            {
                hshParams.Add(ndParam.Attributes["Name"].Value, ndParam.InnerText);
            }

            ArrayList ArrNew = new ArrayList();
            ArrayList ArrDel = new ArrayList();

            try
            {
                ArrNew = new ArrayList(doc.FirstChild.Attributes["NewUsers"].Value.Split(','));
            }
            catch { }
            try
            {
                ArrDel = new ArrayList(doc.FirstChild.Attributes["RemoveUsers"].Value.Split(','));
            }
            catch { }
            try
            {
                sExternalColumn = doc.FirstChild.Attributes["ExternalColumn"].Value;
            }
            catch { }

            if(sExternalColumn != "")
            {
                DataTable dtResources = API.APITeam.GetResourcePool("<Get><Columns>" + sExternalColumn + "</Columns></Get>", oWeb);

                ArrayList ArrNewTemp = new ArrayList();

                foreach(string s in ArrNew)
                {
                    DataRow[] dr = dtResources.Select(sExternalColumn + " ='" + s + "'");
                    if(dr.Length > 0)
                    {
                        ArrNewTemp.Add(dr[0]["SPID"].ToString());
                    }
                }

                ArrNew = ArrNewTemp;
            }

            string ret = Response.Failure(30010, "Error: No Item Id specificied");
            if(itemid != "" && (listId != "" || listName != ""))
            {
                SPSecurity.RunWithElevatedPrivileges(delegate(){

                    SPList oList = null;
                    try
                    {
                        using(SPSite site = new SPSite(oWeb.Site.ID))
                        {
                            if(webid != "")
                            {
                                using(SPWeb tWeb = site.OpenWeb(new Guid(webid)))
                                {
                                    if(listId != "")
                                    {
                                        oList = tWeb.Lists[new Guid(listId)];
                                    }
                                    else
                                    {
                                        oList = tWeb.Lists.TryGetList(listName);
                                    }

                                    if(oList != null)
                                    {
                                        SPListItem li = oList.GetItemById(int.Parse(itemid));

                                        API.APIEmail.QueueItemMessage(templateid, hideFromUser, hshParams, (string[])ArrNew.ToArray(typeof(string)), (string[])ArrDel.ToArray(typeof(string)), doNotEmail, unMarkRead, li, oWeb.CurrentUser, forceNewEntry);

                                        ret = Response.Success("Success");
                                    }
                                }
                            }
                            else
                            {
                                using(SPWeb web = site.OpenWeb(oWeb.ID))
                                {
                                    if(listId != "")
                                    {
                                        oList = web.Lists[new Guid(listId)];
                                    }
                                    else
                                    {
                                        oList = web.Lists.TryGetList(listName);
                                    }

                                    if(oList != null)
                                    {
                                        SPListItem li = oList.GetItemById(int.Parse(itemid));

                                        API.APIEmail.QueueItemMessage(templateid, hideFromUser, hshParams, (string[])ArrNew.ToArray(typeof(string)), (string[])ArrDel.ToArray(typeof(string)), doNotEmail, unMarkRead, li, oWeb.CurrentUser, forceNewEntry);

                                        ret = Response.Success("Success");
                                    }
                                }
                            }

                            
                        }
                    }catch{}

                    
                });

                return ret;
                
            }
            else
            {

                API.APIEmail.QueueItemMessage(templateid, hideFromUser, hshParams, (string[])ArrNew.ToArray(typeof(string)), (string[])ArrDel.ToArray(typeof(string)), doNotEmail, unMarkRead, oWeb, oWeb.CurrentUser, forceNewEntry);

                return Response.Success("Success");
            }

            return Response.Failure(30010, "Error: No Item Id specificied");
        }

        private static void iQueueItemMessage(
            int templateid,
            bool hidefrom,
            Hashtable additionalParams,
            string[] newusers,
            string[] delusers,
            bool doNotEmail,
            bool unmarkread,
            SPListItem li,
            SPUser curUser,
            bool forceNewEntry)
        {
            try
            {
                using (SPSite site = new SPSite(li.ParentList.ParentWeb.Site.ID))
                {
                    using (SPWeb web = site.OpenWeb(li.ParentList.ParentWeb.ID))
                    {
                        using (var connection = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id)))
                        {
                            connection.Open();

                            string body;
                            string subject;
                            GetSubjectAndBody(templateid, additionalParams, curUser, web, connection, out body, out subject);
                            SubstituteItems(li, web, ref body, ref subject);

                            var id = GetNotificationIdByListId(templateid, li, connection);

                            using (var upsertNotificationCommand = new SqlCommand())
                            {
                                upsertNotificationCommand.Connection = connection;
                                if (id == null || forceNewEntry)
                                {
                                    id = Guid.NewGuid().ToString();
                                }
                                upsertNotificationCommand.CommandText = GenerateUpsertSql(forceNewEntry, id);

                                upsertNotificationCommand.Parameters.AddWithValue("@id", id);
                                upsertNotificationCommand.Parameters.AddWithValue("@title", subject);
                                upsertNotificationCommand.Parameters.AddWithValue("@message", body);
                                upsertNotificationCommand.Parameters.AddWithValue("@type", templateid);
                                if (hidefrom)
                                {
                                    upsertNotificationCommand.Parameters.AddWithValue("@createdby", _defaultUserId);
                                }
                                else
                                {
                                    upsertNotificationCommand.Parameters.AddWithValue("@createdby", curUser.ID);
                                }
                                upsertNotificationCommand.Parameters.AddWithValue("@siteid", site.ID);
                                upsertNotificationCommand.Parameters.AddWithValue("@webid", web.ID);
                                upsertNotificationCommand.Parameters.AddWithValue("@listid", li.ParentList.ID);
                                upsertNotificationCommand.Parameters.AddWithValue("@itemid", li.ID);
                                upsertNotificationCommand.Parameters.AddWithValue("@emailed", doNotEmail);
                                upsertNotificationCommand.ExecuteNonQuery();
                            }

                            ProcessNewUsersWithListItem(newusers, unmarkread, li, connection, id);
                            DeleteUsers(delusers, connection, id);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Trace.TraceError("Exception details: {0}", exception);
                throw new InvalidOperationException(exception.Message);
            }
        }

        private static void SubstituteItems(
            SPListItem listItem, 
            SPWeb web, 
            ref string body, 
            ref string subject)
        {
            const string itemNamePlaceholder = "{ItemName}";
            const string itemUrlPlaceholder = "{ItemUrl}";

            var itemUrl = string.Format(
                "{0}/{1}?ID={2}", 
                web.Url,
                listItem.ParentList.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url,
                listItem.ID);

            body = body.Replace(itemNamePlaceholder, listItem.Title);
            body = body.Replace(itemUrlPlaceholder, itemUrl);
            subject = subject.Replace(itemNamePlaceholder, listItem.Title);
            subject = subject.Replace(itemUrlPlaceholder, itemUrl);
        }

        private static string GetNotificationIdByListId(
            int templateid, 
            SPListItem listItem, 
            SqlConnection connection)
        {
            string id = null;

            using (var command = new SqlCommand(
                "SELECT id from NOTIFICATIONS where listid=@listid and itemid=@itemid and type=@type", 
                connection))
            {
                command.Parameters.AddWithValue("@listid", listItem.ParentList.ID);
                command.Parameters.AddWithValue("@itemid", listItem.ID);
                command.Parameters.AddWithValue("@type", templateid);

                using (var row = command.ExecuteReader())
                {
                    if (row.Read())
                    {
                        id = row.GetGuid(0).ToString();
                    }
                    row.Close();
                }
            }
            return id;
        }

        private static void ProcessNewUsersWithListItem(
            string[] newusers, 
            bool unmarkread, 
            SPListItem li, 
            SqlConnection connection, 
            string id)
        {
            var dataSet = new DataSet();
            using (var personalizationCommand =
                new SqlCommand("select * from personalizations where FK=@id", connection))
            {
                personalizationCommand.Parameters.AddWithValue("@id", id);
                var dataAdapter = new SqlDataAdapter(personalizationCommand);
                dataAdapter.Fill(dataSet);
            }

            foreach (var user in newusers)
            {
                if (user != "")
                {
                    bool found = false;

                    if (dataSet.Tables.Count > 0)
                    {
                        var rowsFound = dataSet.Tables[0].Select(string.Format("userid='{0}'", user));

                        if (rowsFound.Length > 0)
                        {
                            found = true;
                            dataSet.Tables[0].Rows.Remove(rowsFound[0]);
                        }
                    }
                    if (!found)
                    {
                        using (var insertCommand = new SqlCommand(
                            "INSERT INTO personalizations " +
                            "(FK, [key], value, userid, siteid, webid, listid, itemid) " +
                            "VALUES " +
                            "(@id, 'Notifications', @value, @userid, @siteid, @webid, @listid, @itemid)",
                            connection))
                        {
                            insertCommand.Parameters.AddWithValue("@id", id);
                            insertCommand.Parameters.AddWithValue("@value", "00");
                            insertCommand.Parameters.AddWithValue("@userid", user);
                            insertCommand.Parameters.AddWithValue("@siteid", li.ParentList.ParentWeb.Site.ID);
                            insertCommand.Parameters.AddWithValue("@webid", li.ParentList.ParentWeb.ID);
                            insertCommand.Parameters.AddWithValue("@listid", li.ParentList.ID);
                            insertCommand.Parameters.AddWithValue("@itemid", li.ID);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                    if (unmarkread)
                    {
                        ExecuteNSetBit(connection, id, user);
                    }
                }
            }
        }

        private static void iQueueItemMessage(
            int templateid, 
            bool hidefrom, 
            Hashtable additionalParams, 
            string[] newusers, 
            string[] delusers, 
            bool doNotEmail, 
            bool unmarkread, 
            SPWeb oWeb, 
            SPUser curUser, 
            bool forceNewEntry)
        {
            try
            {
                using(var site = new SPSite(oWeb.Site.ID))
                {
                    using(var web = site.OpenWeb(oWeb.ID))
                    {
                        using (var connection = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id)))
                        {
                            connection.Open();

                            string body;
                            string subject;
                            GetSubjectAndBody(templateid, additionalParams, curUser, web, connection, out body, out subject);

                            var id = GetNotificationId(templateid, web, connection);

                            using (var upsertNotificationCommand = new SqlCommand())
                            {
                                upsertNotificationCommand.Connection = connection;
                                if (id == null || forceNewEntry)
                                {
                                    id = Guid.NewGuid().ToString();
                                }
                                upsertNotificationCommand.CommandText = GenerateUpsertSql(forceNewEntry, id);

                                upsertNotificationCommand.Parameters.AddWithValue("@id", id);
                                upsertNotificationCommand.Parameters.AddWithValue("@title", subject);
                                upsertNotificationCommand.Parameters.AddWithValue("@message", body);
                                upsertNotificationCommand.Parameters.AddWithValue("@type", templateid);
                                if (hidefrom)
                                {
                                    upsertNotificationCommand.Parameters.AddWithValue("@createdby", _defaultUserId);
                                }
                                else
                                {
                                    upsertNotificationCommand.Parameters.AddWithValue("@createdby", curUser.ID);
                                }
                                upsertNotificationCommand.Parameters.AddWithValue("@siteid", site.ID);
                                upsertNotificationCommand.Parameters.AddWithValue("@webid", web.ID);
                                upsertNotificationCommand.Parameters.AddWithValue("@listid", DBNull.Value);
                                upsertNotificationCommand.Parameters.AddWithValue("@itemid", DBNull.Value);
                                upsertNotificationCommand.Parameters.AddWithValue("@emailed", doNotEmail);
                                upsertNotificationCommand.ExecuteNonQuery();
                            }

                            ProcessNewUsers(newusers, unmarkread, web, connection, id);
                            DeleteUsers(delusers, connection, id);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Trace.TraceError("Exception details: {0}", exception);
                throw new InvalidOperationException(exception.Message);
            }
        }

        private static string GenerateUpsertSql(bool forceNewEntry, string id)
        {
            string commandText;
            if (id == null || forceNewEntry)
            {
                commandText =
                    "INSERT INTO NOTIFICATIONS (id, title, message, type, createdby, createdat, " +
                    "siteid, webid, listid, itemid, emailed) VALUES (@id, @title, @message, @type, " +
                    "@createdby, GETDATE(), @siteid, @webid, @listid, @itemid, @emailed)";
            }
            else
            {
                commandText =
                    "UPDATE NOTIFICATIONS set title=@title, message=@message, type=@type, " +
                    "createdby=@createdby, siteid=@siteid, webid=@webid, listid=@listid, " +
                    "emailed=@emailed, itemid=@itemid where id=@id";
            }
            return commandText;
        }

        private static void GetSubjectAndBody(
            int templateId, 
            Hashtable additionalParams, 
            SPUser curUser, 
            SPWeb web, 
            SqlConnection connection, 
            out string body, 
            out string subject)
        {
            body = string.Empty;
            subject = string.Empty;
            GetCoreInformation(connection, templateId, out body, out subject, web, curUser);

            foreach (var key in additionalParams.Keys)
            {
                var placeHolder = string.Format("{{{0}}}", key);
                var replaceWith = additionalParams[key].ToString();
                body = body.Replace(placeHolder, replaceWith);
                subject = subject.Replace(placeHolder, replaceWith);
            }
        }

        private static string GetNotificationId(int templateid, SPWeb web, SqlConnection connection)
        {
            string id = null;
            using (var command = 
                new SqlCommand(
                        "SELECT id from NOTIFICATIONS where webid=@webid and type=@type",
                        connection))
            {
                command.Parameters.AddWithValue("@webid", web.ID);
                command.Parameters.AddWithValue("@type", templateid);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id = reader.GetGuid(0).ToString();
                    }
                    reader.Close();
                }
            }

            return id;
        }

        private static void ProcessNewUsers(
            string[] newUsers, 
            bool unmarkread, 
            SPWeb web, 
            SqlConnection connection, 
            string id)
        {
            var dataSet = new DataSet();
            using (var personalizationCommand =
                new SqlCommand("select * from personalizations where FK=@id", connection))
            {
                personalizationCommand.Parameters.AddWithValue("@id", id);
                using (var dataAdapter = new SqlDataAdapter(personalizationCommand))
                {
                    dataAdapter.Fill(dataSet);
                }
            }

            foreach (var user in newUsers)
            {
                if (user != string.Empty)
                {
                    var found = false;
                    if (dataSet.Tables.Count > 0)
                    {
                        var rowsFound = dataSet.Tables[0].Select(string.Format("userid='{0}'", user));

                        if (rowsFound.Length > 0)
                        {
                            found = true;
                            dataSet.Tables[0].Rows.Remove(rowsFound[0]);
                        }
                    }
                    if (!found)
                    {
                        InsertPersonalization(web, connection, id, user);
                    }
                    if (unmarkread)
                    {
                        ExecuteNSetBit(connection, id, user);
                    }
                }
            }
        }

        private static void InsertPersonalization(SPWeb web, SqlConnection connection, string id, string user)
        {
            using (var command = 
                    new SqlCommand(
                        "INSERT INTO personalizations " +
                        "(FK, [key], value, userid, siteid, webid, listid, itemid) " +
                        "VALUES (@id, 'Notifications', @value, @userid, @siteid, @webid, @listid, @itemid)",
                        connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@value", "00");
                command.Parameters.AddWithValue("@userid", user);
                command.Parameters.AddWithValue("@siteid", web.Site.ID);
                command.Parameters.AddWithValue("@webid", web.ID);
                command.Parameters.AddWithValue("@listid", DBNull.Value);
                command.Parameters.AddWithValue("@itemid", DBNull.Value);
                command.ExecuteNonQuery();
            }
        }

        private static void ExecuteNSetBit(SqlConnection connection, string id, string user)
        {
            using (var spNSetBitCommand = new SqlCommand("spNSetBit", connection))
            {
                spNSetBitCommand.CommandType = CommandType.StoredProcedure;
                spNSetBitCommand.Parameters.AddWithValue("@FK", id);
                spNSetBitCommand.Parameters.AddWithValue("@userid", user);
                spNSetBitCommand.Parameters.AddWithValue("@index", 2);
                spNSetBitCommand.Parameters.AddWithValue("@val", 0);
                spNSetBitCommand.ExecuteNonQuery();
            }
        }

        private static void DeleteUsers(string[] delusers, SqlConnection connection, string id)
        {
            if (delusers != null)
            {
                foreach (string user in delusers)
                {
                    using (var command = 
                        new SqlCommand("delete from personalizations where FK=@id and userid=@userid", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@userid", user);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void sendEmail(int templateid, int userid, Hashtable additionalParams)
        {
            Guid siteid = SPContext.Current.Site.ID;
            Guid webid = SPContext.Current.Web.ID;
            SPUser curUser = SPContext.Current.Web.CurrentUser;
            SPUser eUser = SPContext.Current.Web.SiteUsers.GetByID(userid);
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                iSendEmail(templateid, false, siteid, webid, curUser, eUser, additionalParams);
            });
        }

        public static void sendEmailHideReply(int templateid, Guid site, Guid web, SPUser curUser, SPUser eUser, Hashtable additionalParams)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                iSendEmail(templateid, true, site, web, curUser, eUser, additionalParams);
            });
        }

        public static void sendEmail(int templateid, Guid site, Guid web, SPUser curUser, SPUser eUser, Hashtable additionalParams)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                iSendEmail(templateid, false, site, web, curUser, eUser, additionalParams);
            });
        }
        
        private static void iSendEmail(
            int templateid, 
            bool hidefrom, 
            Guid siteid, 
            Guid webid, 
            SPUser curUser, 
            SPUser eUser, 
            Hashtable additionalParams)
        {
            try
            {
                if(eUser.Email != "")
                {
                    try
                    {
                        using(SPSite site = new SPSite(siteid))
                        {
                            try
                            {
                                using(SPWeb web = site.OpenWeb(webid))
                                {
                                    try
                                    {
                                        string body = "";
                                        string subject = "";

                                        using (var connection = new SqlConnection(
                                            CoreFunctions.getConnectionString(site.WebApplication.Id)))
                                        {
                                            connection.Open();
                                            GetCoreInformation(connection, templateid, out body, out subject, web, curUser);
                                        }

                                        foreach(string s in additionalParams.Keys)
                                        {
                                            body = body.Replace("{" + s + "}", additionalParams[s].ToString());
                                            subject = subject.Replace("{" + s + "}", additionalParams[s].ToString());
                                        }

                                        SPAdministrationWebApplication spWebAdmin = Microsoft.SharePoint.Administration.SPAdministrationWebApplication.Local;
                                        string sMailSvr = spWebAdmin.OutboundMailServiceInstance.Server.Address;

                                        using (var mailMsg = new MailMessage())
                                        {
                                            if (hidefrom)
                                            {
                                                mailMsg.From = new MailAddress(spWebAdmin.OutboundMailSenderAddress);
                                            }
                                            else
                                            {
                                                if (curUser.Email == "")
                                                {
                                                    mailMsg.From = new MailAddress(spWebAdmin.OutboundMailSenderAddress, curUser.Name);
                                                }
                                                else
                                                {
                                                    mailMsg.From = new MailAddress(curUser.Email, curUser.Name);
                                                }
                                            }

                                            body = body.Replace("{ToUser_Name}", eUser.Name);
                                            body = body.Replace("{ToUser_Email}", eUser.Email);
                                            body = body.Replace("{ToUser_Username}", CoreFunctions.GetJustUsername(eUser.LoginName));

                                            subject = subject.Replace("{ToUser_Name}", eUser.Name);
                                            subject = subject.Replace("{ToUser_Email}", eUser.Email);
                                            subject = subject.Replace("{ToUser_Username}", CoreFunctions.GetJustUsername(eUser.LoginName));

                                            mailMsg.To.Add(new MailAddress(eUser.Email));
                                            mailMsg.Subject = subject;
                                            mailMsg.Body = body;
                                            mailMsg.IsBodyHtml = true;

                                            using (var smtpClient = new SmtpClient())
                                            {
                                                smtpClient.Host = sMailSvr;
                                                smtpClient.Send(mailMsg);
                                            }
                                        }
                                    }
                                    catch(Exception Exception) { throw new Exception(Exception.Message); }
                                }
                            }
                            catch (Exception Exception){throw new Exception(Exception.Message); }
                        }
                    }
                    catch (Exception Exception){throw new Exception(Exception.Message); }
                    
                }
            }
            catch (Exception Exception){throw new Exception(Exception.Message); }
        }

        public static void sendEmail(int templateID, Hashtable additionalParams, List<String> emailTo, string emailFrom, SPWeb oWeb, bool hideFrom)
        {
            string body = "";
            string subject = "";

            Guid siteid = SPContext.Current.Site.ID;
            Guid webid = SPContext.Current.Web.ID;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(oWeb.Site.WebApplication.Id)))
                {
                    cn.Open();

                    GetCoreInformation(cn, templateID, out body, out subject, oWeb, oWeb.CurrentUser);

                    foreach (string s in additionalParams.Keys)
                    {
                        body = body.Replace("{" + s + "}", additionalParams[s].ToString());
                        subject = subject.Replace("{" + s + "}", additionalParams[s].ToString());
                    }

                    SPAdministrationWebApplication spWebAdmin = Microsoft.SharePoint.Administration.SPAdministrationWebApplication.Local;
                    string sMailSvr = spWebAdmin.OutboundMailServiceInstance?.Server.Address;

                    if (string.IsNullOrEmpty(sMailSvr)) return;

                    using (MailMessage mailMsg = new MailMessage())
                    {


                        if (hideFrom)
                        {
                            mailMsg.From = new MailAddress(spWebAdmin.OutboundMailSenderAddress);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(emailFrom))
                                mailMsg.From = new MailAddress(spWebAdmin.OutboundMailSenderAddress, oWeb.CurrentUser.Name);
                            else
                                mailMsg.From = new MailAddress(oWeb.CurrentUser.Email, oWeb.CurrentUser.Name);
                        }

                        emailTo.ForEach(i => mailMsg.To.Add(i));
                        mailMsg.Subject = subject;
                        mailMsg.Body = body;
                        mailMsg.IsBodyHtml = true;

                        using (SmtpClient smtpClient = new SmtpClient())
                        {
                            smtpClient.Host = sMailSvr;
                            smtpClient.Send(mailMsg);
                        }
                    }
                }
            });            
        }
    }
}
