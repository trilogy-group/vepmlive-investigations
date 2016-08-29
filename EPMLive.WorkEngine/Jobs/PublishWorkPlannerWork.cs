using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Collections;
using System.Data;
using System.Xml;

namespace WorkEnginePPM.Jobs
{
    public class PublishWorkPlannerWork : EPMLiveCore.API.BaseJob
    {
        private PortfolioEngineCore.Admininfos GetAdminInfos(SPSite Site)
        {
            PortfolioEngineCore.Admininfos admin = null;
            SPWeb rootWeb = Site.RootWeb;

            SPUser user = rootWeb.SiteUsers.GetByID(userid);

            string username = ConfigFunctions.GetCleanUsername(rootWeb);

            string basePath = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
            string ppmId = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
            string ppmCompany = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
            string ppmDbConn = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");
            admin = new PortfolioEngineCore.Admininfos(basePath, username, ppmId, ppmCompany, ppmDbConn, PortfolioEngineCore.SecurityLevels.ViewPortfolioItems, false);


            return admin;
        }

        public void execute(SPSite site, SPWeb web, string data)
        {
            string[] keys = key.Split('.');
            SPList oTaskCenter;
            SPQuery query = null;
            SPListItemCollection lic = null;
            SPFieldUserValueCollection uvc = null;
            DataTable dtResources = null;
            ArrayList arrResourceExtId = null;
            try
            {
                string result = "";
                if (!String.IsNullOrEmpty(keys[2]) && keys[2].ToLower().Equals("msproject"))
                {
                    using (var portfolioEngineAPI = new PortfolioEngineAPI(web))
                    {
                        result = portfolioEngineAPI.Execute("UpdateScheduledWork", data);
                    }
                }
                else
                {
                    oTaskCenter = web.Lists[base.ListUid];

                    query = new SPQuery();

                    query.Query = "<Where><Eq><FieldRef Name='Project' LookupId='TRUE'/><Value Type='Lookup'>" + keys[0] + "</Value></Eq></Where>";

                    StringBuilder sendValue = new StringBuilder();
                    sendValue.Append("<UpdateListWork><Params />");

                    sendValue.Append(@"<Project ExtId=""" + data + @""" Source=""1"">");

                    lic = oTaskCenter.GetItems(query);

                    totalCount = lic.Count;

                    int counter = 0;

                    dtResources = EPMLiveCore.API.APITeam.GetResourcePool("<GetResources><Columns>EXTID</Columns></GetResources>", web);

                    foreach (SPListItem li in lic)
                    {
                        string assignedto = "";
                        try
                        {
                            assignedto = li["AssignedTo"].ToString();
                        }
                        catch { }
                        if (assignedto != "")
                        {
                            uvc = new SPFieldUserValueCollection(web, assignedto);
                            arrResourceExtId = null;
                            arrResourceExtId = new ArrayList();

                            foreach (SPFieldUserValue uv in uvc)
                            {

                                DataRow[] dr = dtResources.Select("SPID='" + uv.LookupId + "'");

                                if (dr.Length > 0)
                                {
                                    if (dr[0]["EXTID"].ToString() != "")
                                    {
                                        arrResourceExtId.Add(dr[0]["EXTID"].ToString());
                                    }
                                }
                            }

                            sendValue.Append(HelperFunctions.AddXml(li, arrResourceExtId));
                        }

                        updateProgress(counter++);
                    }

                    sendValue.Append(@"</Project>");

                    sendValue.Append("</UpdateListWork>");

                    PortfolioEngineCore.Admininfos admin = GetAdminInfos(site);

                    admin.UpdateListWork(sendValue.ToString(), out result);
                }

                result = result.Trim();

                if (!String.IsNullOrEmpty(keys[2]) && keys[2].ToLower().Equals("msproject"))
                {
                    SPUser currentuser = web.AllUsers.GetByID(userid);
                    var res = new Hashtable();
                    res.Add("Publish_Status", "Completed Successfully");
                    res.Add("Publish_DetailedStatus", "for project " + keys[1] + " Completed Successfully");
                    EPMLiveCore.API.APIEmail.QueueItemMessage(15, true, res, new[] { currentuser.ID.ToString() }, null, false, true, web, currentuser, true);
                }
            }
            catch (Exception ex)
            {

                bErrors = true;
                sErrors = "Error: " + ex.Message;
                if (key != null && key.Contains("MSProject"))
                {
                    SPUser currentuser = web.AllUsers.GetByID(userid);
                    var res = new Hashtable();
                    res.Add("Publish_Status", "Failed");
                    res.Add("Publish_DetailedStatus", "for project " + keys[1] + " failed due to the following reason: " + sErrors);
                    EPMLiveCore.API.APIEmail.QueueItemMessage(15, true, res, new[] { currentuser.ID.ToString() }, null, false, true, web, currentuser, true);
                }
            }
            finally
            {
                oTaskCenter = null;
                query = null;
                lic = null;
                uvc = null;
                if (dtResources != null)
                    dtResources.Dispose();
                arrResourceExtId = null;
                if (web != null)
                    web.Dispose();
                if (site != null)
                    site.Dispose();
                data = null;
            }
        }
    }
}
