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
    public class Setup : EPMLiveCore.API.BaseJob
    {
        public void execute(SPSite site, SPWeb web, string data)
        {
            XmlDocument doc = null;
            PortfolioEngineCore.Setup.SetupSite setup = null;
            ArrayList arrScripts = null;
            ArrayList arrUserInfo = null;
            SPList list = null;
            SPQuery query = null;
            PortfolioEngineCore.Setup.UserInformation ui = null;
            SPUser user = null;
            StringBuilder sbErrors = null;
            try
            {
                sbErrors = new StringBuilder();
                doc = new XmlDocument();
                doc.LoadXml(data);

                string basepath = doc.FirstChild.SelectSingleNode("BasePath").InnerText;
                string PID = doc.FirstChild.SelectSingleNode("PID").InnerText;
                string Company = doc.FirstChild.SelectSingleNode("Company").InnerText;
                string DBServer = doc.FirstChild.SelectSingleNode("DBServer").InnerText;
                string DB = doc.FirstChild.SelectSingleNode("DB").InnerText;
                string Username = doc.FirstChild.SelectSingleNode("Username").InnerText;
                string Password = doc.FirstChild.SelectSingleNode("Password").InnerText;

                setup = new PortfolioEngineCore.Setup.SetupSite();
                arrScripts = new ArrayList();
                arrUserInfo = new ArrayList();
                list = web.Lists.TryGetList("PFEScripts");
                query = new SPQuery();
                query.Query = "<OrderBy><FieldRef Name='Title'/></OrderBy>";

                foreach (SPListItem li in list.Items)
                {
                    try
                    {
                        PortfolioEngineCore.Setup.DataScript ds = new PortfolioEngineCore.Setup.DataScript();
                        ds.ScriptName = li.Title;
                        ds.Script = li["Script"].ToString();
                        arrScripts.Add(ds);
                    }
                    catch { }
                }

                if (arrScripts.Count == 0)
                {
                    bErrors = true;
                    sbErrors.Append("No valid DB scripts found in the PFE site");
                }
                else
                {
                    ui = new PortfolioEngineCore.Setup.UserInformation();

                    user = web.AllUsers.GetByID(base.userid);
                    ui.DisplayName = user.Name;

                    ui.Username = EPMLiveCore.CoreFunctions.GetCleanUserName(user.LoginName, web.Site);

                    arrUserInfo.Add(ui);

                    string adminaccount = site.WebApplication.ApplicationPool.Username;

                    setup.Setup(basepath, PID, Company, DBServer, DB, Username, Password, (PortfolioEngineCore.Setup.DataScript[])arrScripts.ToArray(typeof(PortfolioEngineCore.Setup.DataScript)), adminaccount, (PortfolioEngineCore.Setup.UserInformation[])arrUserInfo.ToArray(typeof(PortfolioEngineCore.Setup.UserInformation)), web.Url);

                    if (setup.SetupErrors)
                    {
                        bErrors = true;
                        sbErrors.Append("Error setting up site:<br>" + setup.SetupMessage);
                    }
                    else
                    {

                        string result = EPMLiveCore.WorkEngineAPI.AddRemoveFeatureEvents("<AddFeatures><Data><Feature Name='pfedatasync'/></Data></AddFeature>", web);

                        web.AllowUnsafeUpdates = true;
                        web.Site.RootWeb.AllowUnsafeUpdates = true;
                        EPMLiveCore.CoreFunctions.setConfigSetting(web.Site.RootWeb, "epkbasepath", basepath);
                    }
                }
            }
            catch (Exception ex)
            {
                bErrors = true;
                sbErrors.Append("Error: " + ex.Message);
            }
            finally
            {
                sErrors = sbErrors.ToString();
                sbErrors = null;
                doc = null;
                arrScripts = null;
                arrUserInfo = null;
                setup = null;
                list = null;
                query = null;
                ui = null;
                user = null;
                if (web != null)
                    web.Dispose();
                if (site != null)
                    site.Dispose();
                data = null;
            }
        }

    }
}
