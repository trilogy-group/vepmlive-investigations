using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Xml;
using System.IO;

namespace EPMLiveAccountManagement
{
    class AccountManagementInstaller : SPFeatureReceiver
    {
        public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        {
        }

        public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        {
        }

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {

            SPWebApplication webApp = (SPWebApplication)properties.Feature.Parent;

            SPIisSettings iis = webApp.IisSettings[SPUrlZone.Default];
            if (File.Exists(iis.Path + "\\web.config"))
            {
                XmlDocument xWebConfig = new XmlDocument();
                xWebConfig.InnerXml = File.ReadAllText(iis.Path + "\\web.config");


                XmlNode nConfig = xWebConfig.SelectSingleNode("configuration");
                if (nConfig != null)
                {
                    // backup with timestamp
                    xWebConfig.Save(iis.Path + "\\web_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + ".bak");

                    XmlNode httpHandlers = xWebConfig.SelectSingleNode("//configuration/system.webServer/modules");

                    if (httpHandlers != null)
                    {
                        XmlNode ndVerb = httpHandlers.SelectSingleNode("add[@name='AccountManagement']");
                        if (ndVerb == null)
                        {
                            ndVerb = xWebConfig.CreateElement("add");
                            XmlAttribute attrName = xWebConfig.CreateAttribute("name");
                            attrName.Value = "AccountManagement";
                            XmlAttribute attrType = xWebConfig.CreateAttribute("type");
                            attrType.Value = "EPMLiveAccountManagement.AccountModule, EPMLiveAccountManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5";

                            ndVerb.Attributes.Append(attrName);
                            ndVerb.Attributes.Append(attrType);

                            httpHandlers.AppendChild(ndVerb);
                        }
                    }

                    xWebConfig.Save(iis.Path + "\\web.config");
                }

            }

            SPFarm.Local.Services.GetValue<SPWebService>().ApplyApplicationContentToLocalServer();

            foreach (SPSite site in webApp.Sites)
            {
                if (site.RootWeb.WebTemplateId == 6221)
                {
                    site.Features.Add(new Guid("2a4da1ba-8614-43e4-a34c-67c505aa5c71"), true);
                }
            }
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPWebApplication webApp = (SPWebApplication)properties.Feature.Parent;

            SPIisSettings iis = webApp.IisSettings[SPUrlZone.Default];
            if (File.Exists(iis.Path + "\\web.config"))
            {
                XmlDocument xWebConfig = new XmlDocument();
                xWebConfig.InnerXml = File.ReadAllText(iis.Path + "\\web.config");


                XmlNode nConfig = xWebConfig.SelectSingleNode("configuration");
                if (nConfig != null)
                {
                    // backup with timestamp
                    xWebConfig.Save(iis.Path + "\\web_" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString() + ".bak");

                    XmlNode httpHandlers = xWebConfig.SelectSingleNode("//configuration/system.webServer/modules");

                    if (httpHandlers != null)
                    {
                        XmlNode ndVerb = httpHandlers.SelectSingleNode("add[@name='AccountManagement']");
                        if (ndVerb != null)
                        {
                            httpHandlers.RemoveChild(ndVerb);
                        }
                    }

                    xWebConfig.Save(iis.Path + "\\web.config");
                }

            }

            foreach (SPSite site in webApp.Sites)
            {
                if (site.RootWeb.WebTemplateId == 6221)
                {
                    site.Features.Remove(new Guid("2a4da1ba-8614-43e4-a34c-67c505aa5c71"), true);
                }
            }
        }
    }
}
