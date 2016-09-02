using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Net.Mail;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace EPMLiveCore.API
{
    public class APIEmail
    {
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

        public static void ClearNotificationItem(SPListItem li)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {

                    SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(li.ParentList.ParentWeb.Site.WebApplication.Id));
                    cn.Open();

                    SqlCommand cmd = new SqlCommand("spNDeleteNotification", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@listid", li.ParentList.ID);
                    cmd.Parameters.AddWithValue("@itemid", li.ID);
                    cmd.ExecuteNonQuery();

                    cn.Close();
                }
                catch(Exception Exception) { throw new Exception(Exception.Message); }
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

        private static void iQueueItemMessage(int templateid, bool hidefrom, Hashtable additionalParams, string[] newusers, string[] delusers, bool doNotEmail, bool unmarkread, SPListItem li, SPUser curUser, bool forceNewEntry)
        {
            try
            {
                using(SPSite site = new SPSite(li.ParentList.ParentWeb.Site.ID))
                {
                    try
                    {
                        using(SPWeb web = site.OpenWeb(li.ParentList.ParentWeb.ID))
                        {
                            try
                            {
                                string body = "";
                                string subject = "";
                                //string shortmessage = "";

                                SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id));
                                cn.Open();

                                GetCoreInformation(cn, templateid, out body, out subject, web, curUser);

                                foreach(string s in additionalParams.Keys)
                                {
                                    body = body.Replace("{" + s + "}", additionalParams[s].ToString());
                                    subject = subject.Replace("{" + s + "}", additionalParams[s].ToString());
                                    //shortmessage = shortmessage.Replace("{" + s + "}", additionalParams[s].ToString());
                                }

                                string itemurl = web.Url + "/" + li.ParentList.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url + "?ID=" + li.ID;

                                body = body.Replace("{ItemName}", li.Title);
                                body = body.Replace("{ItemUrl}", itemurl);
                                subject = subject.Replace("{ItemName}", li.Title);
                                subject = subject.Replace("{ItemUrl}", itemurl);

                                SqlCommand cmd = new SqlCommand("SELECT id from NOTIFICATIONS where listid=@listid and itemid=@itemid and type=@type", cn);
                                cmd.Parameters.AddWithValue("@listid", li.ParentList.ID);
                                cmd.Parameters.AddWithValue("@itemid", li.ID);
                                cmd.Parameters.AddWithValue("@type", templateid);

                                SqlDataReader dr = cmd.ExecuteReader();

                                string id = null;

                                if(dr.Read())
                                {
                                    id = dr.GetGuid(0).ToString();
                                }
                                dr.Close();

                                if(id == null || forceNewEntry)
                                {
                                    id = Guid.NewGuid().ToString();

                                    cmd = new SqlCommand("INSERT INTO NOTIFICATIONS (id, title, message, type, createdby, createdat, siteid, webid, listid, itemid, emailed) VALUES (@id, @title, @message, @type, @createdby, GETDATE(), @siteid, @webid, @listid, @itemid, @emailed)", cn);
                                }
                                else
                                {
                                    cmd = new SqlCommand("UPDATE NOTIFICATIONS set title=@title, message=@message, type=@type, createdby=@createdby, siteid=@siteid, webid=@webid, listid=@listid, emailed=@emailed, itemid=@itemid where id=@id", cn);
                                }

                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.Parameters.AddWithValue("@title", subject);
                                cmd.Parameters.AddWithValue("@message", body);
                                cmd.Parameters.AddWithValue("@type", templateid);
                                if(hidefrom)
                                    cmd.Parameters.AddWithValue("@createdby", 1073741823);
                                else
                                    cmd.Parameters.AddWithValue("@createdby", curUser.ID);
                                cmd.Parameters.AddWithValue("@siteid", site.ID);
                                cmd.Parameters.AddWithValue("@webid", web.ID);
                                cmd.Parameters.AddWithValue("@listid", li.ParentList.ID);
                                cmd.Parameters.AddWithValue("@itemid", li.ID);
                                cmd.Parameters.AddWithValue("@emailed", doNotEmail);
                                cmd.ExecuteNonQuery();

                                cmd = new SqlCommand("select * from personalizations where FK=@id", cn);
                                cmd.Parameters.AddWithValue("@id", id);
                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataSet ds = new DataSet();
                                da.Fill(ds);

                                foreach(string user in newusers)
                                {
                                    if(user != "")
                                    {
                                        bool found = false;

                                        if(ds.Tables.Count > 0)
                                        {
                                            DataRow[] drFound = ds.Tables[0].Select("userid='" + user + "'");

                                            if(drFound.Length > 0)
                                            {
                                                found = true;
                                                ds.Tables[0].Rows.Remove(drFound[0]);
                                            }
                                        }
                                        if(!found)
                                        {
                                            cmd = new SqlCommand("INSERT INTO personalizations (FK, [key], value, userid, siteid, webid, listid, itemid) VALUES (@id, 'Notifications', @value, @userid, @siteid, @webid, @listid, @itemid)", cn);
                                            cmd.Parameters.AddWithValue("@id", id);
                                            cmd.Parameters.AddWithValue("@value", "00");
                                            cmd.Parameters.AddWithValue("@userid", user);
                                            cmd.Parameters.AddWithValue("@siteid", li.ParentList.ParentWeb.Site.ID);
                                            cmd.Parameters.AddWithValue("@webid", li.ParentList.ParentWeb.ID);
                                            cmd.Parameters.AddWithValue("@listid", li.ParentList.ID);
                                            cmd.Parameters.AddWithValue("@itemid", li.ID);
                                            cmd.ExecuteNonQuery();
                                        }
                                        if(unmarkread)
                                        {
                                            cmd = new SqlCommand("spNSetBit", cn);
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            cmd.Parameters.AddWithValue("@FK", id);
                                            cmd.Parameters.AddWithValue("@userid", user);
                                            cmd.Parameters.AddWithValue("@index", 2);
                                            cmd.Parameters.AddWithValue("@val", 0);
                                            cmd.ExecuteNonQuery();
                                        }


                                    }
                                }

                                if(delusers != null)
                                {
                                    foreach(string user in delusers)
                                    {
                                        cmd = new SqlCommand("delete from personalizations where FK=@id and userid=@userid", cn);
                                        cmd.Parameters.AddWithValue("@id", id);
                                        cmd.Parameters.AddWithValue("@userid", user);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                cn.Close();

                            }
                            catch(Exception Exception) { throw new Exception(Exception.Message); }
                        }
                    }
                    catch(Exception Exception) { throw new Exception(Exception.Message); }
                }
            }
            catch(Exception Exception) { throw new Exception(Exception.Message); }
        }

        private static void iQueueItemMessage(int templateid, bool hidefrom, Hashtable additionalParams, string[] newusers, string[] delusers, bool doNotEmail, bool unmarkread, SPWeb oWeb, SPUser curUser, bool forceNewEntry)
        {
            try
            {
                using(SPSite site = new SPSite(oWeb.Site.ID))
                {
                    try
                    {
                        using(SPWeb web = site.OpenWeb(oWeb.ID))
                        {
                            try
                            {
                                string body = "";
                                string subject = "";
                                //string shortmessage = "";

                                SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id));
                                cn.Open();

                                GetCoreInformation(cn, templateid, out body, out subject, web, curUser);

                                foreach(string s in additionalParams.Keys)
                                {
                                    body = body.Replace("{" + s + "}", additionalParams[s].ToString());
                                    subject = subject.Replace("{" + s + "}", additionalParams[s].ToString());
                                    //shortmessage = shortmessage.Replace("{" + s + "}", additionalParams[s].ToString());
                                }

                                SqlCommand cmd = new SqlCommand("SELECT id from NOTIFICATIONS where webid=@webid and type=@type", cn);
                                cmd.Parameters.AddWithValue("@webid", web.ID);
                                cmd.Parameters.AddWithValue("@type", templateid);

                                SqlDataReader dr = cmd.ExecuteReader();

                                string id = null;

                                if(dr.Read())
                                {
                                    id = dr.GetGuid(0).ToString();
                                }
                                dr.Close();

                                if(id == null || forceNewEntry)
                                {
                                    id = Guid.NewGuid().ToString();

                                    cmd = new SqlCommand("INSERT INTO NOTIFICATIONS (id, title, message, type, createdby, createdat, siteid, webid, listid, itemid, emailed) VALUES (@id, @title, @message, @type, @createdby, GETDATE(), @siteid, @webid, @listid, @itemid, @emailed)", cn);
                                }
                                else
                                {
                                    cmd = new SqlCommand("UPDATE NOTIFICATIONS set title=@title, message=@message, type=@type, createdby=@createdby, siteid=@siteid, webid=@webid, listid=@listid, emailed=@emailed, itemid=@itemid where id=@id", cn);
                                }

                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.Parameters.AddWithValue("@title", subject);
                                cmd.Parameters.AddWithValue("@message", body);
                                cmd.Parameters.AddWithValue("@type", templateid);
                                if(hidefrom)
                                    cmd.Parameters.AddWithValue("@createdby", 1073741823);
                                else
                                    cmd.Parameters.AddWithValue("@createdby", curUser.ID);
                                cmd.Parameters.AddWithValue("@siteid", site.ID);
                                cmd.Parameters.AddWithValue("@webid", web.ID);
                                cmd.Parameters.AddWithValue("@listid", DBNull.Value);
                                cmd.Parameters.AddWithValue("@itemid", DBNull.Value);
                                cmd.Parameters.AddWithValue("@emailed", doNotEmail);
                                cmd.ExecuteNonQuery();

                                cmd = new SqlCommand("select * from personalizations where FK=@id", cn);
                                cmd.Parameters.AddWithValue("@id", id);
                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataSet ds = new DataSet();
                                da.Fill(ds);

                                foreach(string user in newusers)
                                {
                                    if(user != "")
                                    {
                                        bool found = false;

                                        if(ds.Tables.Count > 0)
                                        {
                                            DataRow[] drFound = ds.Tables[0].Select("userid='" + user + "'");

                                            if(drFound.Length > 0)
                                            {
                                                found = true;
                                                ds.Tables[0].Rows.Remove(drFound[0]);
                                            }
                                        }
                                        if(!found)
                                        {
                                            cmd = new SqlCommand("INSERT INTO personalizations (FK, [key], value, userid, siteid, webid, listid, itemid) VALUES (@id, 'Notifications', @value, @userid, @siteid, @webid, @listid, @itemid)", cn);
                                            cmd.Parameters.AddWithValue("@id", id);
                                            cmd.Parameters.AddWithValue("@value", "00");
                                            cmd.Parameters.AddWithValue("@userid", user);
                                            cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                                            cmd.Parameters.AddWithValue("@webid", web.ID);
                                            cmd.Parameters.AddWithValue("@listid", DBNull.Value);
                                            cmd.Parameters.AddWithValue("@itemid", DBNull.Value);
                                            cmd.ExecuteNonQuery();
                                        }
                                        if(unmarkread)
                                        {
                                            cmd = new SqlCommand("spNSetBit", cn);
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            cmd.Parameters.AddWithValue("@FK", id);
                                            cmd.Parameters.AddWithValue("@userid", user);
                                            cmd.Parameters.AddWithValue("@index", 2);
                                            cmd.Parameters.AddWithValue("@val", 0);
                                            cmd.ExecuteNonQuery();
                                        }


                                    }
                                }

                                if(delusers != null)
                                {
                                    foreach(string user in delusers)
                                    {
                                        cmd = new SqlCommand("delete from personalizations where FK=@id and userid=@userid", cn);
                                        cmd.Parameters.AddWithValue("@id", id);
                                        cmd.Parameters.AddWithValue("@userid", user);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                cn.Close();

                            }
                            catch(Exception Exception) { throw new Exception(Exception.Message); }
                        }
                    }
                    catch(Exception Exception) { throw new Exception(Exception.Message); }
                }
            }
            catch(Exception Exception) { throw new Exception(Exception.Message); }
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

        
        private static void iSendEmail(int templateid, bool hidefrom, Guid siteid, Guid webid, SPUser curUser, SPUser eUser, Hashtable additionalParams)
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

                                        SqlConnection cn = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id));
                                        cn.Open();

                                        GetCoreInformation(cn, templateid, out body, out subject, web, curUser);

                                        
                                        cn.Close();

                                        foreach(string s in additionalParams.Keys)
                                        {
                                            body = body.Replace("{" + s + "}", additionalParams[s].ToString());
                                            subject = subject.Replace("{" + s + "}", additionalParams[s].ToString());
                                        }

                                        SPAdministrationWebApplication spWebAdmin = Microsoft.SharePoint.Administration.SPAdministrationWebApplication.Local;
                                        string sMailSvr = spWebAdmin.OutboundMailServiceInstance.Server.Address;

                                        System.Net.Mail.MailMessage mailMsg = new MailMessage();
                                        if(hidefrom)
                                        {
                                            mailMsg.From = new MailAddress(spWebAdmin.OutboundMailSenderAddress);
                                        }
                                        else
                                        {
                                            if(curUser.Email == "")
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

                                        SmtpClient smtpClient = new SmtpClient();

                                        smtpClient.Host = sMailSvr;

                                        smtpClient.Send(mailMsg);
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
    }
}
