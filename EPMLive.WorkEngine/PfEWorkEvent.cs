using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Collections;
using System.Data;

namespace WorkEnginePPM
{
    public class PfEWorkEvent : SPItemEventReceiver
    {
        public override void ItemAdded(SPItemEventProperties properties)
        {
            updateItem(properties);
        }

        public override void ItemUpdated(SPItemEventProperties properties)
        {
            updateItem(properties);
        }

        public override void ItemDeleted(SPItemEventProperties properties)
        {
            base.ItemDeleted(properties);
        }

        public override void ItemDeleting(SPItemEventProperties properties)
        {
            Hashtable ParentLists = GetAllParentLists(properties, true);
            if(ParentLists.Count > 0)
            {
                PortfolioEngineCore.Admininfos admin = GetAdminInfos(properties);
                if(admin != null)
                {

                    string sendValue = "<UpdateListWork><Params />";

                    foreach(DictionaryEntry gList in ParentLists)
                    {
                        try
                        {
                            SPList pList = properties.Web.Lists[(Guid)gList.Key];

                            sendValue += @"<Project ExtId=""" + pList.ParentWeb.ID + "." + pList.ID + "." + gList.Value + @""" Source=""1"">";

                            sendValue += "<Item Id=\"" + properties.ListItem.ParentList.ID + "." + properties.ListItem.ID + "\"/>";

                            sendValue += @"</Project>";
                        }
                        catch { }
                    }

                    sendValue += "</UpdateListWork>";

                    string result = "";
                    admin.DeleteListWork(sendValue, out result);

                    result = result.Trim();
                }
            }
        }
        

        private void ProcessItem(string sendValue, PortfolioEngineCore.Admininfos admin)
        {

            string result = "";
            admin.UpdateListWork(sendValue, out result);

            result = result.Trim();
        }

        private PortfolioEngineCore.Admininfos GetAdminInfos(SPItemEventProperties properties)
        {
            PortfolioEngineCore.Admininfos admin = null;

            string username = ConfigFunctions.GetCleanUsername(properties.Web);

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(properties.SiteId))
                {
                    SPWeb rootWeb = site.RootWeb;
                    string basePath = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
                    string ppmId = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
                    string ppmCompany = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
                    string ppmDbConn = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");
                    admin = new PortfolioEngineCore.Admininfos(basePath, username, ppmId, ppmCompany, ppmDbConn, PortfolioEngineCore.SecurityLevels.ViewPortfolioItems, false);
                }
            });

            return admin;
        }

        private void updateItem(SPItemEventProperties properties)
        {
            string assignedto = "";
            try
            {
                assignedto = properties.ListItem["AssignedTo"].ToString();
            }
            catch { }
            if(assignedto != "")
            {
                Hashtable ParentLists = GetAllParentLists(properties, false);
                if(ParentLists.Count > 0)
                {
                    PortfolioEngineCore.Admininfos admin = GetAdminInfos(properties);
                    if(admin != null)
                    {
                        SPFieldUserValueCollection uvc = new SPFieldUserValueCollection(properties.Web, assignedto);

                        DataTable dtResources = EPMLiveCore.API.APITeam.GetResourcePool("<GetResources><Columns>EXTID</Columns></GetResources>", properties.Web);

                        string sendValue = "<UpdateListWork><Params />";

                        foreach(DictionaryEntry gList in ParentLists)
                        {
                            try
                            {
                                SPList pList = properties.Web.Lists[(Guid)gList.Key];

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

                                sendValue += @"<Project ExtId=""" + pList.ParentWeb.ID + "." + pList.ID + "." + gList.Value + @""" Source=""1"">";

                                sendValue += HelperFunctions.AddXml(properties.ListItem, arrResourceExtId);

                                sendValue += @"</Project>";
                            }
                            catch { }
                        }

                        sendValue += "</UpdateListWork>";

                        ProcessItem(sendValue, admin);
                    }
                }
            }
        }

        private ArrayList GetParentLists(string listname, SPWeb web)
        {
            ArrayList Parents = new ArrayList();

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(web.Site.ID))
                {
                    ArrayList epklists = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "epklists").Split(','));

                    foreach(string list in epklists)
                    {
                        if(list != "")
                        {
                            ArrayList worklists = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "epk" + list.Replace(" ", "") + "_worklists").Split('|'));

                            if(worklists.Contains(listname))
                            {
                                Parents.Add(list);
                            }
                        }
                    }                   
                }
            });

            return Parents;
        }

        private Hashtable GetAllParentLists(SPItemEventProperties properties, bool bDeleting)
        {
            Hashtable allParents = new Hashtable();

            if(!bDeleting)
            {
                Dictionary<string, EPMLiveCore.PlannerDefinition> planners = EPMLiveCore.CoreFunctions.GetPlannerList(properties.Web, null);

                foreach(EPMLiveCore.PlannerDefinition def in planners.Values)
                {
                    if(def.command == properties.ListTitle)
                        return allParents;
                }
            }

            ArrayList parents = GetParentLists(properties.ListTitle, properties.Web);

            foreach(SPField field in properties.List.Fields)
            {
                if(field.Type == SPFieldType.Lookup)
                {
                    SPFieldLookup lookup = (SPFieldLookup)field;
                    try
                    {
                        if(lookup.LookupList != "")
                        {
                            SPList pList = properties.Web.Lists[new Guid(lookup.LookupList)];
                            if(parents.Contains(pList.Title))
                            {
                                try
                                {
                                    SPFieldLookupValueCollection lvc = new SPFieldLookupValueCollection(properties.ListItem[field.Id].ToString());
                                    foreach(SPFieldLookupValue lv in lvc)
                                    {
                                        allParents.Add(pList.ID, lv.LookupId);
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                    catch { }
                }
            }
            return allParents;
        }
    }
}
