using System;
using System.Linq;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace EPMLiveCore.Jobs
{
    public class Notifications: API.BaseJob
    {
        //private SPWeb currWeb;
        private SPList list;
        private StringWriter stringWriter;
        private HtmlTextWriter htmlWriter;
        protected GridView gvSection;
        private DataSet dsSectionTables;

        string sEvent = "";
        string[] arrSectionNames;
        private char[] chrCRSeparator = new char[] { '\r' };
        private string sFontName = "Lucida Grande,Arial Unicode MS,sans-serif";
        private int iFontSize = 10;
        private string sFromEmail = "";
        private string sSubject = "EPM Live: Task Status Report";
        private string sNote = "The following items are assigned to you in EPM Live."; // default
        private bool bShowGreeting = false;
        private bool bLockNotify = true;
        private string sMainURL = "";
        private bool bLogDetailedErrors = true;
        private ErrorLogDetailLevelEnum iErrorLogDetailLevel = ErrorLogDetailLevelEnum.SectionLevelErrors; // default at section level

        public enum ErrorLogDetailLevelEnum : int
        {
            JobLevelErrors = 0,
            UserLevelErrors = 1,
            SectionLevelErrors = 2,
            ListLevelErrors = 3,
            FieldLevelErrors = 4
        }

        public string FontName
        {
            get { return sFontName; }
            set { sFontName = value; }
        }

        public int FontSize
        {
            get { return iFontSize; }
            set { iFontSize = value; }
        }

        public string FromEmail
        {
            get { return sFromEmail; }
            set { sFromEmail = value; }
        }

        public string EmailSubject
        {
            get { return sSubject; }
            set { sSubject = value; }
        }

        public bool ShowGreeting
        {
            get { return bShowGreeting; }
            set { bShowGreeting = value; }
        }

        public bool LogDetailedErrors
        {
            get { return bLogDetailedErrors; }
            set { bLogDetailedErrors = value; }
        }

        public ErrorLogDetailLevelEnum ErrorLogDetailLevel
        {
            get { return iErrorLogDetailLevel; }
            set { iErrorLogDetailLevel = value; }
        }


        public void execute(SPSite site, SPWeb web, string data)
        {
            ShowGreeting = false;
            LogDetailedErrors = false;
            ErrorLogDetailLevel = ErrorLogDetailLevelEnum.SectionLevelErrors;

            //using (SPWeb web = site.RootWeb)
            {
                //==========================================
                sMainURL = web.Url;

                try
                {
                    if (web.Properties.ContainsKey("EPMLiveNotificationLists"))
                    {
                        if ((web.Properties["EPMLiveNotificationLists"] != null && web.Properties["EPMLiveNotificationLists"].Trim() != ""))
                        {
                            dsSectionTables = new DataSet();

                            string sNotificationLists = web.Properties["EPMLiveNotificationLists"];
                            createSectionTables(sNotificationLists); // create tables that will be re-used per user loop to minimize memory overhead


                            if (web.Properties.ContainsKey("EPMLiveNotificationEmail"))
                            {
                                sFromEmail = web.Properties["EPMLiveNotificationEmail"];
                            }

                            // override the default subject line
                            if (web.Properties.ContainsKey("EPMLiveNotificationEmailSubject"))
                            {
                                sSubject = web.Properties["EPMLiveNotificationEmailSubject"];
                            }

                            if (web.Properties.ContainsKey("EPMLiveNotificationNote"))
                            {
                                sNote = web.Properties["EPMLiveNotificationNote"];
                            }

                            if (web.Properties.ContainsKey("EPMLiveNotificationLock"))
                            {
                                if (web.Properties["EPMLiveNotificationLock"].ToUpper() == "TRUE")
                                    bLockNotify = true;
                                else
                                    bLockNotify = false;
                            }

                            if (web.Properties.ContainsKey("EPMLiveLogDetailedErrors"))
                            {
                                if (web.Properties["EPMLiveLogDetailedErrors"].ToUpper() == "TRUE")
                                    bLogDetailedErrors = true;
                                else
                                    bLogDetailedErrors = false;
                            }

                            if (sFromEmail != "")
                            {

                                bool allusers = false;
                                try
                                {
                                    allusers = bool.Parse(web.Properties["EPMLiveNotificationAllUsers"]);
                                }
                                catch { }

                                if (allusers)
                                {
                                    totalCount = web.SiteUsers.Count;
                                    float processedUsers = 0;
                                    foreach (SPUser u in web.SiteUsers)
                                    {
                                        processUser(u, web, u.ID, sNotificationLists);

                                        updateProgress(processedUsers++);
                                    }
                                }
                                else
                                {
                                    string sSignedUsers = web.Properties["EPMLiveNotificationUsers"];
                                    if (sSignedUsers != null && sSignedUsers.Trim() != "")
                                    {
                                        string[] arrSignedUsers = sSignedUsers.Split('|');

                                        totalCount = arrSignedUsers.Length;
                                        float processedUsers = 0;

                                        foreach (string sUser in arrSignedUsers)
                                        {
                                            if (sUser != null && sUser.Trim().Length > 0)
                                            {
                                                try
                                                {
                                                    // tables are created. fill with data
                                                    SPFieldLookupValue lv = new SPFieldLookupValue(sUser);
                                                    SPUser u = null;
                                                    try
                                                    {
                                                        u = web.AllUsers.GetByID(lv.LookupId);
                                                    }
                                                    catch { }
                                                    if (u != null)
                                                    {
                                                        processUser(u, web, lv.LookupId, sNotificationLists);
                                                    }
                                                    updateProgress(processedUsers++);
                                                }
                                                catch (Exception exc)
                                                {
                                                    logException("NotificationListsJob.ExecuteJob", exc.Message, "User: " + sUser);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            dsSectionTables.Dispose();
                        }
                    }
                    //if (web.Properties.ContainsKey("epmlivenotificationlastrun"))
                    //    web.Properties["epmlivenotificationlastrun"] = DateTime.Now.ToString();
                    //else
                    //    web.Properties.Add("epmlivenotificationlastrun", DateTime.Now.ToString());
                    //web.Properties.Update();


                }
                catch (Exception exc)
                {
                    logException("NotificationListsJob.ExecuteJob", exc.Message, "");
                }
                finally
                {
                    GC.Collect();
                }
                //==========================================
            }
        }

        private void processUser(SPUser u, SPWeb web, int iUserID, string sNotificationLists)
        {
            string sUserDisplayName = u.Name;
            string sToEmail = u.Email;

            try
            {
                
                if (sToEmail.Trim() != "") // only send if has email address
                {
                    // get the data
                    getData(web, sUserDisplayName, iUserID, sNotificationLists);

                    if (hasDataToEmail())
                    {
                        sendEmail(sToEmail, sFromEmail, sSubject, sUserDisplayName);
                    }
                }
            }
            catch (Exception exc)
            {
                logException("NotificationListsJob.ExecuteJob", exc.Message, "User: " + u.Name + " Email: " + sToEmail);
            }
        }


        private bool hasDataToEmail()
        {
            if (dsSectionTables.Tables.Count > 0)
            {
                foreach (DataTable dt in dsSectionTables.Tables)
                {
                    if (dt.Rows.Count > 0) return true;
                }
            }
            return false;
        }

        private void sendEmail(string sUserEmail, string sFromEmail, string sSubject, string sUserDisplayName)
        {
            string sMailSvr = "";
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SPAdministrationWebApplication spWebAdmin = Microsoft.SharePoint.Administration.SPAdministrationWebApplication.Local;
                    sMailSvr = spWebAdmin.OutboundMailServiceInstance.Server.Name;

                    System.Net.Mail.MailMessage mailMsg = new MailMessage();
                    mailMsg.From = new MailAddress(sFromEmail);
                    mailMsg.To.Add(new MailAddress(sUserEmail));
                    mailMsg.Subject = sSubject;
                    mailMsg.Body = createMsgBody(sUserDisplayName);
                    mailMsg.IsBodyHtml = true;
                    mailMsg.BodyEncoding = System.Text.Encoding.UTF8;
                    mailMsg.Priority = MailPriority.Normal;

                    // Configure the mail server
                    SmtpClient smtpClient = new SmtpClient();
                    
                    smtpClient.Host = sMailSvr;
                    //smtpClient.UseDefaultCredentials = true;
                    //smtpClient.Credentials = CredentialCache.DefaultNetworkCredentials;
                    smtpClient.Send(mailMsg);
                });
            }
            catch (Exception exc)
            {
                logException("NotificationListsJob.sendEmail", exc.Message, " Email address: " + sUserEmail + " Mail Server: " + sMailSvr);
            }
        }

        private string createMsgBody(string sUserDisplayName)
        {

            stringWriter = new StringWriter();
            htmlWriter = new HtmlTextWriter(stringWriter);

            // write the msg header
            if (bShowGreeting) htmlWriter.Write("><font face=\"Lucida Grande,Arial Unicode MS,sans-serif\" color=\"#666666\" size=\"2\">Hello " + sUserDisplayName + ",</font><br /><br />");

            htmlWriter.Write("<font face=\"Lucida Grande,Arial Unicode MS,sans-serif\" color=\"#666666\" size=\"2\">" + sNote + "</font>");
            htmlWriter.Write("<br /><br /><u><b><font face=\"Lucida Grande,Arial Unicode MS,sans-serif\" color=\"#666666\" size=\"4\">Work Assigned to You</font></b></u><br /><br>");

            // write the tables
            convertDataToHTML();

            if (!bLockNotify)
            {
                // write the msg footer
                htmlWriter.Write("<br />");
                htmlWriter.Write("To turn off these email notifications, please click <a href=\"" + sMainURL + "/_layouts/epmlive/notifications.aspx\" >here</a>.</font>");
            }

            return System.Web.HttpUtility.HtmlDecode(stringWriter.ToString());
        }

        private void createSectionTables(string sNotificationLists)
        {
            string[] arrSections = sNotificationLists.Split('\t'); // separate each notification list row
            arrSectionNames = new string[arrSections.Length];

            int i = 0;
            foreach (string sSection in arrSections)
            {
                string sSectionName = "";
                string sCols = "";

                try
                {
                    if (sSection.Trim() != "")
                    {

                        string[] sSectionItems = sSection.Split('`'); // separate each row column
                        if (sSectionItems.Length > 0)
                        {
                            sSectionName = sSectionItems[0];
                        }
                        if (sSectionItems.Length > 2)
                        {
                            sCols = sSectionItems[2];
                        }

                        // create a table for each section
                        dsSectionTables.Tables.Add(sSectionName);
                        arrSectionNames[i] = sSectionName;
                        i++;

                        // create table columns
                        string[] arColNames = sCols.Replace("\r\n", "\r").Split(chrCRSeparator, StringSplitOptions.RemoveEmptyEntries); // separate the multiple items in each column by newline/carriage return
                        foreach (string sColName in arColNames)
                        {
                            if (sColName.Trim() != "")
                            {
                                dsSectionTables.Tables[sSectionName].Columns.Add(getSplitVal(sColName, 1, "|"));
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    if ((bLogDetailedErrors) && ((ErrorLogDetailLevelEnum)iErrorLogDetailLevel == ErrorLogDetailLevelEnum.SectionLevelErrors || (ErrorLogDetailLevelEnum)iErrorLogDetailLevel == ErrorLogDetailLevelEnum.ListLevelErrors || (ErrorLogDetailLevelEnum)iErrorLogDetailLevel == ErrorLogDetailLevelEnum.FieldLevelErrors))
                    {
                        logException("NotificationListsJob.createSectionTables", exc.Message, "Error creating section table.  Section: " + sSectionName);
                    }
                }
            }

            //dsSectionTables.Tables.Add("Planner Updates");
            //dsSectionTables.Tables["Planner Updates"].Columns.Add("Project");
            //dsSectionTables.Tables["Planner Updates"].Columns.Add("Title");
            //dsSectionTables.Tables["Planner Updates"].Columns.Add("StartDate");
            //dsSectionTables.Tables["Planner Updates"].Columns.Add("DueDate");
            //dsSectionTables.Tables["Planner Updates"].Columns.Add("PercentComplete");
            //dsSectionTables.Tables["Planner Updates"].Columns.Add("Modified");
            //dsSectionTables.Tables["Planner Updates"].Columns["PercentComplete"].Caption = "% Complete";
        }

        private void getData(SPWeb web, string sUser, int iUserID, string sNotificationLists)
        {
            string[] arrSections = sNotificationLists.Split('\t');
            processSiteRecursive(web, sUser, iUserID, arrSections);
        }

        protected void gvSection_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    // format first column
                    e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                    e.Row.Cells[0].Width = 275;

                    // loop thru the other columns and align them to center
                    int cnt = 0;
                    foreach (TableCell cell in e.Row.Cells)
                    {
                        if (cnt > 0)
                        {
                            if(((DataRowView)e.Row.DataItem).DataView.Table.Columns[cnt].ColumnName == "Title")
                            {
                                e.Row.Cells[cnt].HorizontalAlign = HorizontalAlign.Left;
                            }
                            else
                            {
                                e.Row.Cells[cnt].HorizontalAlign = HorizontalAlign.Center;
                                if(e.Row.Cells[cnt].Text.Length > 10)
                                {
                                    e.Row.Cells[cnt].Width = e.Row.Cells[cnt].Text.Length * 8;
                                }
                                else
                                {
                                    e.Row.Cells[cnt].Width = 150;
                                }
                            }
                        }
                        cnt++;
                    }
                }
            }
            catch { }
        }

        private void convertDataToHTML()
        {
            try
            {
                gvSection = new GridView();
                gvSection.RowDataBound += new GridViewRowEventHandler(this.gvSection_RowDataBound);
                gvSection.BorderWidth = new Unit(1, UnitType.Pixel);

                gvSection.HeaderStyle.BackColor = System.Drawing.Color.WhiteSmoke;
                gvSection.HeaderStyle.Font.Bold = false;
                gvSection.HeaderStyle.Font.Size = FontUnit.Point(10);
                gvSection.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#666666");

                gvSection.Font.Size = FontUnit.Point(10);
                gvSection.Font.Bold = false;
                gvSection.ForeColor = System.Drawing.ColorTranslator.FromHtml("#666666");
                gvSection.Style.Add("font-family", sFontName);
                gvSection.CellPadding = 1;

                // convert the dataset data into html
                foreach (string sSectionName in arrSectionNames)
                {
                    if (sSectionName != null && sSectionName.Trim() != "")
                    {
                        if (dsSectionTables.Tables[sSectionName].Rows.Count > 0)
                        {
                            gvSection.DataSource = dsSectionTables.Tables[sSectionName];
                            gvSection.DataBind();
                            htmlWriter.Write("<b><font face=\"Lucida Grande,Arial Unicode MS,sans-serif\" color=\"#666666\" size=\"2\">" + sSectionName + "</font></b><br />");
                            gvSection.RenderControl(htmlWriter);
                            htmlWriter.Write("<br />"); // one line spacing between tables
                            dsSectionTables.Tables[sSectionName].Rows.Clear();
                        }
                    }
                }

                //if(dsSectionTables.Tables["Planner Updates"].Rows.Count > 0)
                //{
                //    DataView dv = dsSectionTables.Tables["Planner Updates"].DefaultView;
                //    dv.Sort = "Project";
                //    gvSection.DataSource = dv;
                //    gvSection.DataBind();
                //    htmlWriter.Write("<u><b><font face=\"Lucida Grande,Arial Unicode MS,sans-serif\" color=\"#666666\" size=\"4\">Pending Updates for Projects you Manage</font></b></u><br /><br>");
                //    htmlWriter.Write("<b><font face=\"Lucida Grande,Arial Unicode MS,sans-serif\" color=\"#666666\" size=\"2\">Planner Updates</font></b><br />");
                //    gvSection.RenderControl(htmlWriter);
                //    htmlWriter.Write("<br />");
                //    dsSectionTables.Tables["Planner Updates"].Rows.Clear();
                //}
            }
            catch (Exception exc)
            {
                logException("NotificationListsJob.convertDataToHTML", exc.Message, "");
            }
            finally
            {
                gvSection.DataSource = null;
                gvSection.Dispose();
            }
        }

        private void processSiteRecursive(SPWeb web, string sUser, int iUserID, string[] arrSections)
        {
            //currWeb = web;

            string sSectionData = "";
            string sSectionName = "";
            string sLists = "";
            string sCols = "";
            string sQuery = "";
            
            try
            {
                // loop thru the sections in this site
                foreach (string sSection in arrSections)
                {
                    if (sSection.Trim() != "")
                    {

                        string[] sSectionItems = sSection.Split('`'); // separate each row column
                        if (sSectionItems.Length > 0)
                        {
                            sSectionName = sSectionItems[0];
                        }
                        if (sSectionItems.Length > 1)
                        {
                            sLists = sSectionItems[1];
                        }
                        if (sSectionItems.Length > 2)
                        {
                            sCols = sSectionItems[2];
                        }
                        if (sSectionItems.Length > 3)
                        {
                            sQuery = sSectionItems[3];
                            // clean up
                            //sQuery = sQuery.Replace("\r", "").Replace("\n", "")
                            //sQuery = sQuery.Replace("<UserID/>", iUserID.ToString() + "#;" + sUser);
                            sQuery = sQuery.Replace("<UserID/>", sUser);
                            // build CAML and include user in the predicate criteria
                            sQuery = "<Where>" + sQuery + "</Where>";
                        }

                        processSection(web, sUser, sSectionName, sLists, sCols, sQuery);
                    }
                }
            }
            catch (Exception exc)
            {
                if ((bLogDetailedErrors) && ((ErrorLogDetailLevelEnum)iErrorLogDetailLevel == ErrorLogDetailLevelEnum.SectionLevelErrors || (ErrorLogDetailLevelEnum)iErrorLogDetailLevel == ErrorLogDetailLevelEnum.ListLevelErrors || (ErrorLogDetailLevelEnum)iErrorLogDetailLevel == ErrorLogDetailLevelEnum.FieldLevelErrors))
                {
                    logException("NotificationListsJob.processSiteRecursive", exc.Message, "Section data malformed - Section Data: " + sSectionData);
                }
            }
            
            //try
            //{

            //    Dictionary<string, EPMLiveCore.PlannerDefinition> plannerList = EPMLiveCore.CoreFunctions.GetPlannerList(web, null);

            //    foreach(KeyValuePair<string, EPMLiveCore.PlannerDefinition> de in plannerList)
            //    {
            //        SPList pList = web.Lists.TryGetList(de.Value.commandPrefix);
            //        SPList tList = web.Lists.TryGetList(de.Value.command);

            //        if(pList != null && tList != null)
            //        {
            //            try
            //            {
            //                SPQuery query = new SPQuery();
            //                query.Query = "<Where><Or><Eq><FieldRef Name=\"Author\" LookupId=\"True\"/><Value Type=\"User\">" + iUserID + "</Value></Eq><Eq><FieldRef Name=\"Planners\" LookupId=\"True\"/><Value Type=\"User\">" + iUserID + "</Value></Eq></Or></Where>";

            //                foreach(SPListItem liProject in pList.GetItems(query))
            //                {
            //                    SPQuery tquery = new SPQuery();
            //                    tquery.Query = "<Where><Neq><FieldRef Name=\"IsPublished\"/><Value Type=\"Boolean\">1</Value></Eq></Where>";

            //                    foreach(SPListItem liTask in tList.GetItems(tquery))
            //                    {
            //                        dsSectionTables.Tables["Planner Updates"].Rows.Add(
            //                            new string[] { 
            //                                "<a href=\"" + web.Url + "/" + pList.DefaultView.Url + "\" style=\"color:#3366CC\">" + liProject.Title +"</a>"
            //                                , "<a href=\"" + web.Url + "/" + tList.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url + "?ID=" + liTask.ID + "\"  style=\"color:#3366CC\">" + liTask.Title +"</a>"
            //                                , ProcessField(web, liTask, tList.Fields.GetFieldByInternalName("StartDate"))
            //                                , ProcessField(web, liTask, tList.Fields.GetFieldByInternalName("DueDate"))
            //                                , ProcessField(web, liTask, tList.Fields.GetFieldByInternalName("PercentComplete"))
            //                                , ProcessField(web, liTask, tList.Fields.GetFieldByInternalName("Modified"))
            //                                }
            //                            );
            //                    }
            //                }
            //            }
            //            catch { }
            //        }
            //    }

            //    //dsSectionTables.Tables["Planner Updates"].Rows.Add(sNewRow);
            //}
            //catch { }

            foreach (SPWeb w in web.Webs)
            {
               try
               {
                   processSiteRecursive(w, sUser, iUserID, arrSections);
               }
               catch { }
               w.Close();
               w.Dispose();
            }
        }

        private string ProcessField(SPWeb web, SPListItem li, SPField field)
        {
            string val = "";
            try
            {
                switch(field.Type)
                {
                    case SPFieldType.DateTime:
                        DateTime dt = DateTime.Parse(li[field.Id].ToString());
                        //int localeID = (int)web.RegionalSettings.LocaleId;
                        System.Globalization.CultureInfo cInfo = new System.Globalization.CultureInfo(web.Locale.LCID);
                        IFormatProvider culture = new System.Globalization.CultureInfo(cInfo.Name, true);

                        if(getFieldSchemaAttribValue(field.SchemaXml, "Format").ToUpper() == "DATEONLY")
                        {
                            val = dt.ToUniversalTime().GetDateTimeFormats(culture)[0]; //dt.ToShortDateString();
                        }
                        else
                        {
                            val = dt.ToUniversalTime().GetDateTimeFormats(culture)[72]; //dt.ToShortDateString() + " " + dt.ToShortTimeString();
                        }
                        break;
                    case SPFieldType.Number:
                        val = "0";
                        try
                        {
                            val = li[field.Id].ToString();
                            if(((SPFieldNumber)field).ShowAsPercentage)
                            {
                                val = (double.Parse(val) * 100).ToString() + "%";
                            }
                            else
                            {
                                val = field.GetFieldValueAsText(val);
                            }
                        }catch{}
                        break;
                    default:
                        val = field.GetFieldValueAsText(val);
                        break;
                }
            }
            catch { }
            return val;
        }

        private void processSection(SPWeb web, string sUser, string sSectionName, string sLists, string sCols, string sQuery)
        {
            string[] arColNames = sCols.Replace("\r\n", "\r").Split(chrCRSeparator, StringSplitOptions.RemoveEmptyEntries); // separate the multiple items in each column by newline/carriage return

            SPQuery spquery = new SPQuery();
            spquery.Query = sQuery;

            string[] arListNames = sLists.Replace("\r\n", "\r").Split(chrCRSeparator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string sListName in arListNames)
            {
                try
                {

                    if (sListName.Contains("|"))
                    {
                        string[] arListName = sListName.Split('|');
                        list = web.Lists[arListName[0].Trim()] as SPList;
                    }
                    else
                    {
                        list = web.Lists[sListName] as SPList;
                    }

                    if (list != null)
                    {
                        SPListItemCollection colListItems = list.GetItems(spquery);
                        try
                        {
                            int cntItems = colListItems.Count;
                            if (cntItems > 0)
                            {
                                // process column names to remove pipe char and get the internal name
                                string sParsedColName;
                                int i = 0;
                                foreach (string sColName in arColNames)
                                {
                                    if (sColName.Trim() != "")
                                    {
                                        sParsedColName = getSplitVal(sColName, 0, "|");
                                        arColNames[i] = sParsedColName;
                                        i++;
                                    }
                                }

                                string val = "";
                                foreach (SPListItem li in colListItems)
                                {
                                    int cntFields = arColNames.Length;
                                    string[] sNewRow = new string[cntFields];

                                    int cnt = 0;
                                    foreach (string sColName in arColNames)
                                    {
                                        if (sColName.Trim() != "")
                                        {
                                            try
                                            {
                                                SPField field = li.Fields.GetFieldByInternalName(sColName);
                                                if (li[field.Id] != null)
                                                {
                                                    val = li[field.Id].ToString();
                                                    if (!isDate(val))
                                                    {
                                                        val = field.GetFieldValueAsText(val);
                                                    }
                                                    else
                                                    {
                                                        try
                                                        {
                                                            DateTime dt = DateTime.Parse(val);
                                                            //int localeID = (int)web.RegionalSettings.LocaleId;
                                                            System.Globalization.CultureInfo cInfo = new System.Globalization.CultureInfo(web.Locale.LCID);
                                                            IFormatProvider culture = new System.Globalization.CultureInfo(cInfo.Name, true);

                                                            if (getFieldSchemaAttribValue(field.SchemaXml, "Format").ToUpper() == "DATEONLY")
                                                            {
                                                                val = dt.ToUniversalTime().GetDateTimeFormats(culture)[0]; //dt.ToShortDateString();
                                                            }
                                                            else
                                                            {
                                                                val = dt.ToUniversalTime().GetDateTimeFormats(culture)[72]; //dt.ToShortDateString() + " " + dt.ToShortTimeString();
                                                            }

                                                        }
                                                        catch { }
                                                    }
                                                    if (field.SchemaXml.IndexOf("Percentage") > 0 && getFieldSchemaAttribValue(field.SchemaXml, "Percentage").ToUpper() == "TRUE") // if check box 'Show as percentage is checked
                                                    {
                                                        val = val.Replace(" ", ""); // take out space between number and % symbol
                                                    }
                                                    if (field.InternalName == "Title")
                                                    {
                                                        val = "<a href=\"" + web.Url + "/" + list.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url + "?ID=" + li.ID + "\" style=\"color:#3366CC\">" + val + "</a>";
                                                    }
                                                    sNewRow[cnt] = val;
                                                }
                                            }
                                            catch (Exception exc)
                                            {
                                                if ((bLogDetailedErrors) && (ErrorLogDetailLevelEnum)iErrorLogDetailLevel == ErrorLogDetailLevelEnum.FieldLevelErrors)
                                                {
                                                    logException("NotificationListsJob.processSection", exc.Message, "Error retrieving field value.  Field: " + sColName + " Web: " + web.Name + " Section Name: " + sSectionName + " List Name: " + sListName);
                                                }
                                            }
                                            cnt++;
                                        }
                                    }
                                    dsSectionTables.Tables[sSectionName].Rows.Add(sNewRow);
                                }
                            }
                        }
                        catch (Exception exc)
                        {
                            if ((bLogDetailedErrors) && ((ErrorLogDetailLevelEnum)iErrorLogDetailLevel == ErrorLogDetailLevelEnum.ListLevelErrors || (ErrorLogDetailLevelEnum)iErrorLogDetailLevel == ErrorLogDetailLevelEnum.FieldLevelErrors))
                            {
                                logException("NotificationListsJob.processSection", exc.Message, "Error when querying list.  Web: " + web.Name + " Query: " + sQuery + " - Section Name: " + sSectionName + " List Name: " + sListName);
                            }
                        }
                    }
                }
                catch (Exception exc)
                {
                    if ((bLogDetailedErrors) && ((ErrorLogDetailLevelEnum)iErrorLogDetailLevel == ErrorLogDetailLevelEnum.SectionLevelErrors || (ErrorLogDetailLevelEnum)iErrorLogDetailLevel == ErrorLogDetailLevelEnum.ListLevelErrors || (ErrorLogDetailLevelEnum)iErrorLogDetailLevel == ErrorLogDetailLevelEnum.FieldLevelErrors))
                    {
                        logException("NotificationListsJob.processSection", exc.Message, "List does not exist  Web: " + web.Name + " Section Name: " + sSectionName + " List Name: " + sListName);
                    }
                }
            }
        }

        private string getFieldSchemaAttribValue(string sStringToSearch, string sAttribName)
        {
            string sAttribVal = "";
            try
            {
                int iFindPos = sStringToSearch.ToUpper().IndexOf(sAttribName.ToUpper() + "=");
                int iSubStrStart = iFindPos + sAttribName.Length + 2;
                int iSubStrEnd = sStringToSearch.IndexOf("\"", iSubStrStart);
                sAttribVal = sStringToSearch.Substring(iSubStrStart, iSubStrEnd - iSubStrStart);
            }
            catch { }
            return sAttribVal;
        }

        private string getSplitVal(string sStringToSearch, int iSplitValuePosition, string sSplitChar)
        {
            if (sStringToSearch.Contains(sSplitChar))
            {
                string[] arStr = sStringToSearch.Split(Convert.ToChar(sSplitChar));
                return arStr[iSplitValuePosition].Trim();
            }
            else
            {
                return sStringToSearch;
            }
        }

        private static bool isDate(string sDate)
        {
            DateTime dt;
            bool bIsDate = true;

            try
            {
                dt = DateTime.Parse(sDate);
            }
            catch
            {
                bIsDate = false;
            }

            return bIsDate;
        }

        private void logException(string sLoc, string sMsg, string sNotes)
        {
            try
            {
                bErrors = true;
                sEvent = "Error occurred in " + sLoc + " : Error message is: " + sMsg + " Additional notes: " + sNotes;

                sErrors += sEvent + "<br>";
            }
            catch { }
        }
    }
}
