using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.SharePoint;
using System.Xml;

namespace WorkEnginePPM.Jobs
{
    public class InstallWorkEvents : EPMLiveCore.API.BaseJob
    {
        public void execute(SPSite site, SPWeb web, string data)
        {
            SPList oParentList = web.Lists[base.ListUid];

            ArrayList worklists = new ArrayList(EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "epk" + oParentList.Title.Replace(" ", "") + "_worklists").Split('|'));
            SPWebCollection webColl = site.AllWebs;
            
            totalCount = webColl.Count;
            
            int newCount = 0;

            for (int i = 0; i < totalCount; i++)
            {
                using (var oWeb = webColl[i])
                {
                    string sData = "<EventReceiverManager><Data>";
                    sData += "<EventReceiver DataId='0' SiteId='" + site.ID + "' WebId='" + oWeb.ID + "' ListId='" + oParentList.ID + "' Type='ItemAdded' Operation='ADD' Assembly='WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5' ClassName='WorkEnginePPM.EPKIntegrationEvents' ></EventReceiver>";
                    sData += "<EventReceiver DataId='1' SiteId='" + site.ID + "' WebId='" + oWeb.ID + "' ListId='" + oParentList.ID + "' Type='ItemUpdating' Operation='ADD' Assembly='WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5' ClassName='WorkEnginePPM.EPKIntegrationEvents' ></EventReceiver>";
                    sData += "<EventReceiver DataId='2' SiteId='" + site.ID + "' WebId='" + oWeb.ID + "' ListId='" + oParentList.ID + "' Type='ItemDeleting' Operation='ADD' Assembly='WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5' ClassName='WorkEnginePPM.EPKIntegrationEvents' ></EventReceiver>";
                    sData += "</Data></EventReceiverManager>";

                    XmlDocument DocRet = new XmlDocument();
                    DocRet.LoadXml(EPMLiveCore.WorkEngineAPI.EventReceiverManager(sData, oWeb));


                    foreach (SPList oList in oWeb.Lists)
                    {
                        string action = "REMOVE";
                        if (worklists.Contains(oList.Title))
                            action = "ADD";

                        sData = "<EventReceiverManager><Data>";
                        sData += "<EventReceiver DataId='0' SiteId='" + site.ID + "' WebId='" + oWeb.ID + "' ListId='" + oList.ID + "' Type='ItemAdded' Operation='" + action + "' Assembly='WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5' ClassName='WorkEnginePPM.PfEWorkEvent' ></EventReceiver>";
                        sData += "<EventReceiver DataId='1' SiteId='" + site.ID + "' WebId='" + oWeb.ID + "' ListId='" + oList.ID + "' Type='ItemUpdated' Operation='" + action + "' Assembly='WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5' ClassName='WorkEnginePPM.PfEWorkEvent' ></EventReceiver>";
                        sData += "<EventReceiver DataId='2' SiteId='" + site.ID + "' WebId='" + oWeb.ID + "' ListId='" + oList.ID + "' Type='ItemDeleting' Operation='" + action + "' Assembly='WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5' ClassName='WorkEnginePPM.PfEWorkEvent' ></EventReceiver>";
                        sData += "</Data></EventReceiverManager>";

                        DocRet = new XmlDocument();
                        DocRet.LoadXml(EPMLiveCore.WorkEngineAPI.EventReceiverManager(sData, oWeb));

                    }
                    updateProgress(newCount++);
                }
            }
        }
    }
}
