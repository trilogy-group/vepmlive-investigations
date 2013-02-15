using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Collections;
using System.Data;

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
            try
            {
                SPList oTaskCenter = web.Lists[base.ListUid];

                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Project' LookupId='TRUE'/><Value Type='Lookup'>" + key + "</Value></Eq></Where>";

                string sendValue = "<UpdateListWork><Params />";

                sendValue += @"<Project ExtId=""" + data + @""" Source=""1"">";

                SPListItemCollection lic = oTaskCenter.GetItems(query);

                totalCount = lic.Count;

                int counter = 0;

                foreach(SPListItem li in lic)
                {
                    string assignedto = "";
                    try
                    {
                        assignedto = li["AssignedTo"].ToString();
                    }
                    catch { }
                    if(assignedto != "")
                    {
                        SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(web, assignedto);

                        DataTable dtResources = EPMLiveCore.API.APITeam.GetResourcePool("<GetResources><Columns>EXTID</Columns></GetResources>", web);

                        ArrayList arrResourceExtId = new ArrayList();

                        foreach(SPFieldUserValue uv in uvc)
                        {

                            DataRow[] dr = dtResources.Select("SPID='" + uv.LookupId + "'");

                            if(dr.Length > 0)
                            {
                                if(dr[0]["EXTID"].ToString() != "")
                                {
                                    arrResourceExtId.Add(dr[0]["EXTID"].ToString());
                                }
                            }
                        }

                        sendValue += HelperFunctions.AddXml(li, arrResourceExtId);
                    }

                    updateProgress(counter++);
                }

                sendValue += @"</Project>";

                sendValue += "</UpdateListWork>";

                PortfolioEngineCore.Admininfos admin = GetAdminInfos(site);

                string result = "";
                admin.UpdateListWork(sendValue, out result);

                result = result.Trim();
            }
            catch(Exception ex)
            {
                bErrors = true;
                sErrors = "Error: " + ex.Message;
            }
        }
    }
}
