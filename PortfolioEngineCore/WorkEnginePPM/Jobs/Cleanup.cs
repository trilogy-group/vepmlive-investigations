using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Xml;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Collections;

namespace WorkEnginePPM.Jobs
{
    public class Cleanup : EPMLiveCore.API.BaseJob
    {
        private float counter = 0;
        StringBuilder sbErrors = null;
        public void execute(SPSite site, SPWeb web, string data)
        {
            sbErrors = new StringBuilder();
            SPWeb rootWeb = null;
            PortfolioEngineCore.WEIntegration.WEIntegration we = null;
            PortfolioEngineCore.PortfolioItems.PortfolioItems pe = null;
            try
            {
                rootWeb = site.RootWeb;

                string username = site.WebApplication.ApplicationPool.Username;

                string basePath = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
                string ppmId = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
                string ppmCompany = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
                string ppmDbConn = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");

                we = new PortfolioEngineCore.WEIntegration.WEIntegration(basePath, username, ppmId, ppmCompany, ppmDbConn,
                                                                       false);
                pe = new PortfolioEngineCore.PortfolioItems.PortfolioItems(basePath, username, ppmId, ppmCompany,
                                                                         ppmDbConn, false);

                //string resUrl = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, "EPMLiveResourceURL", false);
                //SPWeb resWeb = null;
                //SPSite resSite = null;
                //SPList resList = null;

                //if (resUrl.ToLower() != web.Url.ToLower())
                //{
                //    resSite = new SPSite(resUrl);
                //    resWeb = resSite.OpenWeb();
                //}
                //else
                //{
                //    resSite = web.Site;
                //    resWeb = web;
                //}


                //string PortfolioXml = epkInt.ExecuteProcess("GetPortfolioItems", "");
                //XmlDocument docPortfolioXml = new XmlDocument();
                //docPortfolioXml.LoadXml(PortfolioXml);

                //if(docPortfolioXml.SelectSingleNode("Reply/STATUS").InnerText != "0")
                //{
                //    bErrors = true;
                //    sErrors = "Error Getting Portfolio Items: " + docPortfolioXml.SelectSingleNode("Reply/Error").InnerText;
                //}
                //else
                //{
                //    DataSet ds = new DataSet();
                //    StringReader sr = new StringReader(PortfolioXml);
                //    ds.ReadXml(sr, XmlReadMode.Auto);

                //    DataView dv = null;
                //    if(ds.Tables.Count >= 4)
                //    {
                //        dv = ds.Tables[3].DefaultView;
                //        dv.Sort = "itemid";
                //    }

                //    totalCount = dv.Table.Rows.Count;

                //    if(resWeb != null)
                //    {

                //        try
                //        {
                //            resList = resWeb.Lists["Resources"];
                //        }
                //        catch { }

                //        if(resList != null)
                //        {
                //            totalCount += resList.ItemCount;
                //        }
                //    }


                sbErrors.Append("Processing Timesheets: <br>");
                try
                {
                    if (cn != null)
                        processTimesheets(site, web, cn, we);
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sbErrors.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"red\">General Error Processing Timesheets: " + ex.Message + "</font><br>");
                }

                //    sErrors += "<br>Processing Resources: <br>";
                //    try
                //    {
                //        string sPrefix = getPrefix(site);
                //        processResources(site, resWeb, sPrefix, resList);
                //    }
                //    catch(Exception ex)
                //    {
                //        bErrors = true;
                //        sErrors += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"red\">General Error Processing Resources: " + ex.Message + "</font><br>";
                //    }

                //    sErrors += "<br>Processing Items: <br>";
                //    try
                //    {
                //        if(dv != null)
                //            processItems(site, web, dv, ds, pe);
                //    }
                //    catch(Exception ex)
                //    {
                //        bErrors = true;
                //        sErrors += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"red\">General Error Processing Items: " + ex.Message + "</font><br>";
                //    }
                //}
            }
            catch (Exception ex)
            {
                bErrors = true;
                sbErrors.Append("<font color=\"red\">General Error: " + ex.Message + "</font><br>");
            }
            finally
            {
                sErrors = sbErrors.ToString();
                sbErrors = null;
                we = null;
                pe = null;
                if (rootWeb != null)
                    rootWeb.Dispose();
                if (web != null)
                    web.Dispose();
                if (site != null)
                    site.Dispose();
                data = null;
            }
        }

        private string getPrefix(SPSite site)
        {
            try
            {
                return System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/", site.WebApplication.Name).AppSettings.Settings["prefix"].Value;
            }
            catch { }
            return "";
        }

        private void processTimesheets(SPSite site, SPWeb web, SqlConnection cn, PortfolioEngineCore.WEIntegration.WEIntegration we)
        {
            ArrayList arrLists = null;
            XmlDocument doc = null;
            XmlDocument docResXml = null;
            DataSet ds = new DataSet();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    if (cn.State == System.Data.ConnectionState.Closed)
                        cn.Open();
                });

                string lastApproved = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPKTSLastTSApprove");
                lastApproved = "";

                arrLists = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPKLists").Split(','));

                string newLastApproved = DateTime.Now.ToString();

                using (SqlCommand cmd = new SqlCommand("spTSGetApprovedTimesheets", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@siteguid", site.ID);
                    if (lastApproved == "")
                        cmd.Parameters.AddWithValue("@dtapproved", "1/1/1900");
                    else
                        cmd.Parameters.AddWithValue("@dtapproved", lastApproved);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    cn.Close();

                    doc = new XmlDocument();
                    doc.LoadXml("<Timesheets/>");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string sUsername = ConfigFunctions.GetCleanUsername(web, dr["username"].ToString());

                        XmlNode ndTimesheet = doc.FirstChild.SelectSingleNode("Timesheet[@Resource='" + sUsername + "' and @period_start='" + ((DateTime)dr["period_start"]).ToString("s") + "'  and @period_end='" + ((DateTime)dr["period_end"]).ToString("s") + "']");
                        if (ndTimesheet == null)
                        {
                            ndTimesheet = doc.CreateNode(XmlNodeType.Element, "Timesheet", doc.NamespaceURI);

                            XmlAttribute attrResource = doc.CreateAttribute("Resource");
                            attrResource.Value = sUsername;
                            ndTimesheet.Attributes.Append(attrResource);

                            XmlAttribute attrStart = doc.CreateAttribute("period_start");
                            attrStart.Value = ((DateTime)dr["period_start"]).ToString("s");
                            ndTimesheet.Attributes.Append(attrStart);

                            XmlAttribute attrEnd = doc.CreateAttribute("period_end");
                            attrEnd.Value = ((DateTime)dr["period_end"]).ToString("s");
                            ndTimesheet.Attributes.Append(attrEnd);

                            doc.FirstChild.AppendChild(ndTimesheet);
                        }

                        if (dr["project_list_uid"].ToString() != "")
                        {
                            XmlNode ndProject = doc.CreateNode(XmlNodeType.Element, "Hours", doc.NamespaceURI);

                            XmlAttribute attrProject = doc.CreateAttribute("Project");

                            string itemid = dr["web_uid"].ToString() + "." + dr["project_list_uid"].ToString() + "." + dr["project_id"].ToString();

                            try
                            {
                                using (SPWeb tweb = site.OpenWeb(new Guid(dr["web_uid"].ToString())))
                                {
                                    SPList tList = tweb.Lists[new Guid(dr["project_list_uid"].ToString())];

                                    SPListItem li = tList.GetItemById(int.Parse(dr["project_id"].ToString()));

                                    if (li["ParentItem"].ToString() != "")
                                    {
                                        itemid = li["ParentItem"].ToString();
                                    }
                                }
                            }
                            catch { }

                            attrProject.Value = itemid;
                            ndProject.Attributes.Append(attrProject);

                            XmlAttribute attrDate = doc.CreateAttribute("Date");
                            attrDate.Value = ((DateTime)dr["ts_item_date"]).ToString("s");
                            ndProject.Attributes.Append(attrDate);

                            XmlAttribute attrHours = doc.CreateAttribute("Hours");
                            attrHours.Value = dr["TotalHours"].ToString();
                            ndProject.Attributes.Append(attrHours);

                            XmlAttribute attrType = doc.CreateAttribute("Type");
                            attrType.Value = dr["TYPEID"].ToString();
                            ndProject.Attributes.Append(attrType);

                            XmlAttribute attrCategory = doc.CreateAttribute("Category");
                            attrCategory.Value = dr["TSTYPE_NAME"].ToString();
                            ndProject.Attributes.Append(attrCategory);

                            ndTimesheet.AppendChild(ndProject);
                        }
                        else if (arrLists.Contains(dr["LIST"].ToString()))
                        {
                            XmlNode ndProject = doc.CreateNode(XmlNodeType.Element, "Hours", doc.NamespaceURI);

                            XmlAttribute attrProject = doc.CreateAttribute("Project");

                            string itemid = dr["web_uid"].ToString() + "." + dr["list_uid"].ToString() + "." + dr["project_id"].ToString();

                            attrProject.Value = itemid;
                            ndProject.Attributes.Append(attrProject);

                            XmlAttribute attrDate = doc.CreateAttribute("Date");
                            attrDate.Value = ((DateTime)dr["ts_item_date"]).ToString("s");
                            ndProject.Attributes.Append(attrDate);

                            XmlAttribute attrHours = doc.CreateAttribute("Hours");
                            attrHours.Value = dr["TotalHours"].ToString();
                            ndProject.Attributes.Append(attrHours);

                            XmlAttribute attrType = doc.CreateAttribute("Type");
                            attrType.Value = dr["TYPEID"].ToString();
                            ndProject.Attributes.Append(attrType);

                            XmlAttribute attrCategory = doc.CreateAttribute("Category");
                            attrCategory.Value = dr["TSTYPE_NAME"].ToString();
                            ndProject.Attributes.Append(attrCategory);

                            ndTimesheet.AppendChild(ndProject);
                        }
                    }
                }
                try
                {
                    string ResXml = we.PostTimesheetData(doc.OuterXml);
                    docResXml = new XmlDocument();
                    docResXml.LoadXml(ResXml);

                    if (docResXml.FirstChild.Attributes["Status"].Value != "0")
                    {
                        bErrors = true;
                        sbErrors.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"red\">Error Posting Timesheet Data: " + System.Web.HttpUtility.HtmlEncode(docResXml.FirstChild.InnerXml) + "</font><br>");
                    }
                    else
                    {
                        sbErrors.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Success<br>");
                    }
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sbErrors.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"red\">Error Posting Timesheet Data: " + ex.Message + "</font><br>");
                }
                EPMLiveCore.CoreFunctions.setConfigSetting(web, "EPKTSLastTSApprove", newLastApproved);
            }
            finally
            {
                arrLists = null;
                doc = null;
                docResXml = null;
                if (ds != null)
                    ds.Dispose();
            }
        }

        private void processItems(SPSite site, SPWeb web, DataView dv, DataSet ds, PortfolioEngineCore.PortfolioItems.PortfolioItems pe)
        {

            Guid webGuid = Guid.Empty;
            SPWeb iWeb = null;
            Guid listGuid = Guid.Empty;
            SPList iList = null;

            string disableItems = "";

            foreach (DataRow dr in dv.Table.Rows)
            {
                string title = "Unknown";
                string[] itemid = dr["itemid"].ToString().Split('.');

                try
                {
                    bool e = false;

                    title = dr["portfolioitem_id"].ToString();
                    try
                    {
                        title = ds.Tables[4].Select("portfolioitem_id=" + dr["portfolioitem_id"].ToString() + " and ID=9900")[0]["Value"].ToString();
                    }
                    catch { }

                    Guid wGuid = new Guid(itemid[0]);
                    Guid lGuid = new Guid(itemid[1]);


                    if (webGuid != wGuid)
                    {
                        if (iWeb != null)
                        {
                            iWeb.Close();
                            iWeb = site.OpenWeb(wGuid);
                        }
                        else
                            iWeb = site.OpenWeb(wGuid);
                        webGuid = iWeb.ID;
                    }
                    if (listGuid != lGuid)
                    {
                        iList = iWeb.Lists[lGuid];
                        listGuid = iList.ID;
                    }

                    DataRow[] drFields = ds.Tables[4].Select("portfolioitem_id=" + dr["portfolioitem_id"].ToString());

                    string message = WorkEnginePPM.HelperFunctions.processPortfolioItem(iWeb, iList, itemid[2], drFields, "1", out e);
                    if (e)
                    {
                        if (message.Contains("Item does not exist"))
                        {
                            sbErrors.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + title + ": Item No Longer Exists (Disabling Portfolio Item)<br>");
                            disableItems += "<Item ID=\"" + dr["itemid"].ToString() + "\"/>";
                        }
                        else
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(message);

                            bErrors = true;
                            sbErrors.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + title + ": <font color=\"red\">Error: " + doc.InnerText + "</font><br>");
                        }
                    }
                    else
                    {
                        sbErrors.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + title + ": Success<br>");
                    }

                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("0x80070002"))
                    {
                        sbErrors.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + title + ": Web No Longer Exists (Disabling Portfolio Item)<br>");
                        disableItems += "<Item EXTID=\"" + dr["itemid"].ToString() + "\"/>";
                    }
                    else
                    {
                        bErrors = true;
                        sbErrors.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"red\">General Error (" + title + "): " + ex.Message + "</font><br>");
                    }
                }
                updateProgress(counter++);
            }

            if (disableItems != "")
            {
                string ret = pe.ClosePortfolioItems("<Items>" + disableItems + "</Items>");

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(ret);

                XmlNode ndStatus = xmlDoc.SelectSingleNode("Reply/STATUS");

                if (ndStatus != null)
                {
                    if (ndStatus.InnerText != "0")
                    {
                        bErrors = true;
                        sbErrors.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Disabling Portfolio Items: <font color=\"red\">Error: " + xmlDoc.SelectSingleNode("Reply/Error").InnerText + "</font><br>");
                    }
                    else
                    {
                        sbErrors.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Disabling Portfolio Items: Success<br>");
                    }
                }
                else
                {
                    bErrors = true;
                    sbErrors.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Disabling Portfolio Items: <font color=\"red\">Error: Could not get status</font><br>");
                }
            }
        }

        private void processResources(SPSite site, SPWeb resWeb, string sPrefix, SPList resList)
        {

            Hashtable hshFields = null;
            XmlDocument doc = null;
            try
            {
                hshFields = new Hashtable();
                string fields = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPKResourceFields");
                if (fields != "")
                {
                    foreach (string field in fields.Split('|'))
                    {
                        string[] spField = field.Split(',');
                        hshFields.Add(spField[0], spField[1]);
                    }
                }


                string ret = EPMLiveCore.WorkEngineAPI.GetResources("", resWeb);

                doc = new XmlDocument();
                doc.LoadXml(ret);
            }
            finally
            {
                hshFields = null;
                doc = null;
            }

            //foreach(XmlNode ndResource in ndResources)
            //{
            //    try
            //    {
            //        bool errors = false;
            //        string messages = WorkEnginePPM.HelperFunctions.processResource(ndResource, resList, hshFields, ref errors, sPrefix);

            //        if(errors)
            //        {
            //            bErrors = true;
            //            XmlDocument docMessage = new XmlDocument();
            //            docMessage.LoadXml(messages);
            //            sErrors += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + ndResource.SelectSingleNode("Field[@ID=3000]").Attributes["Value"].Value + "<font color=\"red\">Error: " + docMessage.InnerText + "</font><br>";
            //        }
            //        else
            //        {
            //            sErrors += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + ndResource.SelectSingleNode("Field[@ID=3000]").Attributes["Value"].Value + ": Success<br>";
            //        }
            //    }
            //    catch(Exception ex)
            //    {
            //        bErrors = true;
            //        sErrors += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"red\">Error (" + ndResource.SelectSingleNode("Field[@ID=3000]").Attributes["Value"].Value + "): " + ex.Message + "</font><br>";
            //    }
            //    updateProgress(counter++);
            //}
        }
    }
}
