using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;

namespace EPMLiveCore
{
    public class WorkEngineListEventsFeatureReceiver : SPFeatureReceiver
    {
        List<string> _listNames = new List<string>();

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            try
            {
                SPWeb web = (SPWeb)properties.Feature.Parent;
                base.FeatureActivated(properties);
                AddEventHandlers(web);
                InitializeWebpartProperties(web);
                PullResourceFromTopSite(web);
            }
            catch { }
        }

        private void PullResourceFromTopSite(SPWeb web)
        {
            SPList rList = null;
            SPList tList = null;

            web.Site.AllowUnsafeUpdates = true;
            web.Site.RootWeb.AllowUnsafeUpdates = true;
            web.AllowUnsafeUpdates = true;

            tList = web.Lists.TryGetList("Team");

            string resWebUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, true);

            if (!string.IsNullOrEmpty(resWebUrl))
            {
                using (SPWeb rWeb = web.Site.AllWebs[resWebUrl])
                {
                    rList = rWeb.Lists.TryGetList("Resources");

                    if ((rList != null) &&
                        (rList.Items.Count > 0) &&
                        (tList != null))
                    {
                        foreach (SPListItem item in rList.Items)
                        {
                            SPField userValueFld = null;
                            string spAccounts = null;

                            try
                            {
                                userValueFld = item.Fields[item.Fields.GetFieldByInternalName("SharePointAccount").Id];
                            }
                            catch { }

                            if ((userValueFld != null) && (item[rList.Fields.GetFieldByInternalName("SharePointAccount").Id] != null))
                            {
                                spAccounts = item[rList.Fields.GetFieldByInternalName("SharePointAccount").Id].ToString();
                                string[] valPair = spAccounts.Split(new string[] { ";#" }, StringSplitOptions.None);

                                if (int.Parse(valPair[0]) != SPContext.Current.Web.CurrentUser.ID)
                                {
                                    continue;
                                }

                                SPQuery q = new SPQuery();
                                q.Query = "<Where><Eq><FieldRef Name=\"ResID\" /><Value Type=\"Number\">" + SPContext.Current.Web.CurrentUser.ID.ToString() + "</Value></Eq></Where>";
                                SPListItemCollection tListItems = tList.GetItems(q);

                                if (tListItems.Count.Equals(0))
                                {
                                    SPListItem newTeamItem = tList.Items.Add();
                                    newTeamItem[tList.Fields.GetFieldByInternalName("Title").Id] = item["Title"];
                                    newTeamItem[tList.Fields.GetFieldByInternalName("ResID").Id] = item.ID;
                                    newTeamItem.Update();
                                    tList.Update();
                                    web.Update();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AddEventHandlers(SPWeb web)
        {
            ProcessEventHandlers(web);
            //RegisterAssignToEvent(web);
            AddEventHandlersToLocalResourcesList(web);
        }

        private void AddEventHandlersToLocalResourcesList(SPWeb web)
        {
            // get a local list called "Resouces"
            SPList rList = web.Lists.TryGetList("Resources");

            // if "Resouces" exists locally, add 
            // ItemAdding, ItemUpdating, and ItemDeleted events
            if (rList != null)
            {
                web.AllowUnsafeUpdates = true;
                string assemblyName = "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050";
                string className = "EPMLiveReportsAdmin.ListEvents";


                List<SPEventReceiverDefinition> evts = GetListEvents(rList,
                                                                              assemblyName,
                                                                              className,
                                                                              new List<SPEventReceiverType> { SPEventReceiverType.ItemAdded,
                                                                                                              SPEventReceiverType.ItemUpdated,
                                                                                                              SPEventReceiverType.ItemDeleting });

                foreach (SPEventReceiverDefinition e in evts)
                {
                    e.Delete();
                }

                rList.EventReceivers.Add(SPEventReceiverType.ItemAdded, assemblyName, className);
                rList.EventReceivers.Add(SPEventReceiverType.ItemUpdated, assemblyName, className);
                rList.EventReceivers.Add(SPEventReceiverType.ItemDeleting, assemblyName, className);

                rList.Update();
            }
        }

        private List<SPEventReceiverDefinition> GetListEvents(SPList list, string assemblyName, string className, List<SPEventReceiverType> types)
        {
            List<SPEventReceiverDefinition> evts = new List<SPEventReceiverDefinition>();

            try
            {
                evts = (from e in list.EventReceivers.OfType<SPEventReceiverDefinition>()
                        where e.Assembly.Equals(assemblyName, StringComparison.CurrentCultureIgnoreCase) &&
                              e.Class.Equals(className, StringComparison.CurrentCultureIgnoreCase) &&
                              types.Contains(e.Type)
                        select e).ToList<SPEventReceiverDefinition>();
            }
            catch
            {

            }

            return evts;
        }

        private void ProcessEventHandlers(SPWeb web)
        {
            string sClass = string.Empty;
            string sAssembly = string.Empty;
            List<EventInfos> receiversInfo = new List<EventInfos>();
            List<SPEventReceiverDefinition> receiverDefs = new List<SPEventReceiverDefinition>();

            foreach (SPList l in web.Lists)
            {
                if (l.EventReceivers.Count > 0)
                {
                    foreach (SPEventReceiverDefinition def in l.EventReceivers)
                    {
                        receiverDefs.Add(def);
                        receiversInfo.Add(new EventInfos(l.ID, def.Class, def.Assembly, def.Type));
                    }
                }
            }

            if (receiverDefs.Count > 0)
            {
                foreach (SPEventReceiverDefinition d in receiverDefs)
                {
                    d.Delete();
                }
            }

            if (receiversInfo.Count > 0)
            {
                foreach (EventInfos e in receiversInfo)
                {
                    SPList li = web.Lists[e.ListID];
                    li.EventReceivers.Add(e.Type, e.SAssembly, e.SClass);
                    li.Update();
                }
            }

            List<string> reportingLists = GetReportingLists(web);

            if (reportingLists != null)
            {
                foreach (string listName in reportingLists)
                {
                    SPList l = null;

                    try
                    {
                        l = web.Lists[listName];
                    }
                    catch { }

                    string repAssembly = "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050";
                    string repClass = "EPMLiveReportsAdmin.ListEvents";

                    if (l != null)
                    {
                        List<SPEventReceiverDefinition> evts = GetListEvents(l,
                                                                                 repAssembly,
                                                                                 repClass,
                                                                                 new List<SPEventReceiverType> { SPEventReceiverType.ItemAdded,
                                                                                                             SPEventReceiverType.ItemUpdated,
                                                                                                             SPEventReceiverType.ItemDeleting });

                        foreach (SPEventReceiverDefinition e in evts)
                        {
                            e.Delete();
                        }

                        l.EventReceivers.Add(SPEventReceiverType.ItemAdded, repAssembly, repClass);
                        l.EventReceivers.Add(SPEventReceiverType.ItemUpdated, repAssembly, repClass);
                        l.EventReceivers.Add(SPEventReceiverType.ItemDeleting, repAssembly, repClass);
                    }
                }
            }

        }

        private void RegisterAssignToEvent(SPWeb web)
        {
            string strProps;
            for (int i = 0; i < web.Lists.Count; i++)
            {
                string sAssembly = "EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";
                string sClass = "EPMLiveCore.NotificationEvent";

                List<SPEventReceiverDefinition> evts = GetListEvents(web.Lists[i],
                                                                     sAssembly,
                                                                     sClass,
                                                                     new List<SPEventReceiverType> { SPEventReceiverType.ItemDeleting });

                foreach (SPEventReceiverDefinition e in evts)
                {
                    e.Delete();
                }

                web.Lists[i].EventReceivers.Add(SPEventReceiverType.ItemDeleting, sAssembly, sClass);

                SPList list = web.Lists[i];

                GridGanttSettings gSettings = new GridGanttSettings(list);

                if(gSettings.SendEmails)
                {
                    API.APIEmail.InstallAssignedToEvent(list);
                }
            }
        }

        private List<string> GetReportingLists(SPWeb web)
        {
            var siteId = web.Site.ID;
            //var rd = new ReportData(siteId);
            DataTable result = null;
            List<string> listNames = new List<string>();

            try
            {
                //result = rd.GetListMappings();
            }
            catch { }

            if (result != null)
            {
                foreach (DataRow row in result.Rows)
                {
                    if (!string.IsNullOrEmpty(row.ItemArray[1].ToString()) &&
                        !listNames.Contains(row.ItemArray[1].ToString()))
                    {
                        listNames.Add(row.ItemArray[1].ToString());
                    }
                }
            }

            return listNames;
        }

        private bool ListExists(SPWeb web, string listName)
        {
            try
            {
                SPList list = web.Lists[listName];
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void InitializeWebpartProperties(SPWeb web)
        {
            string wnWpConfig = string.Empty;

            try
            {
                wnWpConfig = web.AllProperties["WhatsNewLists"].ToString();
            }
            catch (NullReferenceException x)
            {
                wnWpConfig = string.Empty;
            }

            if (string.IsNullOrEmpty(wnWpConfig))
            {
                return;
            }

            string processedWNWpConfig = string.Empty;
            processedWNWpConfig = wnWpConfig;

            Dictionary<string, string> listAndGuids = new Dictionary<string, string>();
            SPList listHolder = null;

            if (!string.IsNullOrEmpty(processedWNWpConfig))
            {
                string[] listConfigs = processedWNWpConfig.Split('|');

                foreach (string listConfig in listConfigs)
                {
                    if (!string.IsNullOrEmpty(listConfig))
                    {
                        string tempLstName = listConfig.Replace("\'", "");
                        string listName = tempLstName.Split(',')[0];
                        listHolder = web.Lists.TryGetList(listName);
                        if (listHolder != null && !listAndGuids.ContainsKey(listName))
                        {
                            listAndGuids.Add(listName, listHolder.ID.ToString("D"));
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, string> lstAndGuid in listAndGuids)
            {
                if (processedWNWpConfig.Contains(lstAndGuid.Key))
                {
                    processedWNWpConfig = processedWNWpConfig.Replace(lstAndGuid.Key, lstAndGuid.Value);
                }
            }

            processedWNWpConfig = processedWNWpConfig.Replace("|", "\n");
            processedWNWpConfig = System.Text.RegularExpressions.Regex.Replace(processedWNWpConfig, "\n$", "");

            SPLimitedWebPartManager myMgr = web.GetLimitedWebPartManager("default.aspx", System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

            if (myMgr != null)
            {
                foreach (System.Web.UI.WebControls.WebParts.WebPart myPart in myMgr.WebParts)
                {
                    if (myPart.GetType().Equals(typeof(Microsoft.SharePoint.Applications.GroupBoard.WebPartPages.WhatsNewWebPart)))
                    {
                        Microsoft.SharePoint.Applications.GroupBoard.WebPartPages.WhatsNewWebPart myWNPart = (Microsoft.SharePoint.Applications.GroupBoard.WebPartPages.WhatsNewWebPart)myPart;

                        myWNPart.NumItemsPerson = 10;
                        myWNPart.NumItemsShared = 10;
                        myWNPart.ShowDetails = true;
                        myWNPart.TargetConfig = processedWNWpConfig;
                        myMgr.SaveChanges(myWNPart);

                    }
                }
                myMgr.Dispose();
            }
        }

    }

    internal class EventInfos
    {
        public Guid ListID;
        public string SClass = string.Empty;
        public string SAssembly = string.Empty;
        public SPEventReceiverType Type;

        public EventInfos(Guid listID, string recClass, string recAssembly, SPEventReceiverType recType)
        {
            ListID = listID;
            SClass = recClass;
            SAssembly = recAssembly;
            Type = recType;
        }
    }
}
