using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.SharePoint;
using System.IO;
using System.Data;
using System.Collections;
using System.Xml;
using System.Threading;
using System.ComponentModel;

namespace EPMLiveCore
{
    [WebService(Namespace = "http://epmlive.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class EPMLiveTimePhased : System.Web.Services.WebService
    {
        public class Period
        {
            public string name;
            public DateTime start;
            public DateTime end;
        }

        public class TSData
        {
            public string Url;
            public string Project;
            public string Data;
            public string webUrl;
            public Guid siteUid;
        }

        public EPMLiveTimePhased()
        {

        }

        public void doTSData(object data)
        {
            TSData tsData = (TSData)data;
            ArrayList arr = new ArrayList();

            SPQuery query = new SPQuery();
            query.Query = "<Where><And><Eq><FieldRef Name='TimePhasedType'/><Value Type='Number'>1</Value></Eq><Eq><FieldRef Name='Title'/><Value Type=\"Text\"><![CDATA[" + tsData.Project + "]]></Value></Eq></And></Where>";

            SPSite site = new SPSite(tsData.siteUid);
            SPWeb web = site.OpenWeb(tsData.webUrl);
            try
            {
                SPList list = web.Lists["EPMLiveTimePhased"];

                foreach (SPListItem li in list.GetItems(query))
                {
                    arr.Add(li);
                }
                foreach (SPListItem li in arr)
                {
                    li.Delete();
                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(tsData.Data);

                foreach (XmlNode ndTask in doc.ChildNodes[0].ChildNodes)
                {
                    foreach (XmlNode ndResource in ndTask.ChildNodes)
                    {
                        foreach (XmlNode ndValueType in ndResource.ChildNodes)
                        {
                            try
                            {
                                SPListItem li = list.Items.Add();
                                li["Title"] = tsData.Project;
                                li["Task"] = ndTask.Attributes["Name"].Value.ToString();
                                li["WBS"] = ndTask.Attributes["WBS"].Value.ToString();
                                li["Resource"] = ndResource.Attributes["Name"].Value.ToString();
                                li["ValueType"] = ndValueType.Attributes["Name"].Value.ToString();
                                li["TimePhasedType"] = 1;
                                foreach (XmlNode ndPeriod in ndValueType.ChildNodes)
                                {
                                    string pName = ndPeriod.Attributes["Name"].Value.Trim();
                                    string pValue = ndPeriod.Attributes["Value"].Value.Trim();
                                    li[list.Fields.GetFieldByInternalName(pName.Replace(" ", "_x0020_")).Id] = pValue;
                                }
                                li.Update();
                            }
                            catch { }
                        }
                    }
                }
            }
            catch { }
            web.Close();
            site.Close();
        }
        [WebMethod]
        public string getConfigSetting(string setting)
        {
            string val ="";
            SPWeb web = SPContext.Current.Web;
            {
                if(setting.ToLower().Contains("url"))
                    val = EPMLiveCore.CoreFunctions.getLockConfigSetting(web, setting, false);
                else
                    val = EPMLiveCore.CoreFunctions.getConfigSetting(web, setting);
            }
            return val;
        }

        [WebMethod]
        public bool saveTimePhasedData(string sUrl, string sProject, string sData)
        {
            
            SPWeb tsWeb = SPContext.Current.Web;
            bool success = true;
            try
            {

                SPList tsList = tsWeb.Lists["EPMLiveTimePhased"];

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sData);


                TSData tsData = new TSData();
                tsData.Data = sData;
                tsData.siteUid = tsWeb.Site.ID;
                tsData.webUrl = tsWeb.ServerRelativeUrl;
                tsData.Project = sProject;
                tsData.Url = sUrl;

                Thread thrDownload = new Thread(new ParameterizedThreadStart(doTSData));
                thrDownload.IsBackground = true;
                thrDownload.Start(tsData);
                
            }
            catch
            {
                success = false;
            }

            return success;
        }

        [WebMethod]
        public string[] getAllValueTypes(string sUrl)
        {
            string[] sValues = new string[0];
            try
            {
                using (SPSite site = new SPSite(sUrl))
                {
                    sUrl = sUrl.Replace(site.Url, "");
                    using(SPWeb web = site.OpenWeb(site.RootWeb.ID))
                    {
                        if(sUrl != "")
                        {
                            using(SPWeb rweb = site.OpenWeb(sUrl))
                            {
                                sValues = iGetAllValueTypes(rweb);
                            }
                        }
                        else
                            sValues = iGetAllValueTypes(web);
                    }
                }

            }
            catch { }
            return sValues;
        }

        private string []iGetAllValueTypes(SPWeb web)
        {
            string []sValues;
            SPList lstValues = null;
            ArrayList arrValues = new ArrayList();
            try
            {
                lstValues = web.Lists["EPMLiveValueTypes"];
            }
            catch { }

            if(lstValues != null)
            {
                foreach(SPListItem li in lstValues.Items)
                {
                    arrValues.Add(li.Title);
                }
            }

            sValues = new string[arrValues.Count];
            int counter = 0;

            foreach(string sVal in arrValues)
            {
                sValues[counter++] = sVal;
            }
            return sValues;
        }

        [WebMethod]
        public Period[] getAllTimePeriods(string sUrl)
        {
            Period[] periods = new Period[0];
            try
            {

                using (SPSite site = new SPSite(sUrl))
                {
                    sUrl = sUrl.Replace(site.Url, "");
                    using(SPWeb web = site.OpenWeb(site.RootWeb.ID))
                    {
                        if(sUrl != "")
                        {
                            using(SPWeb rweb = site.OpenWeb(sUrl))
                            {
                                periods = iGetAllTimePeriods(rweb);
                            }
                        }
                        else
                            periods = iGetAllTimePeriods(web);
                    }
                }
            }
            catch { }

            return periods;
        }

        private Period[] iGetAllTimePeriods(SPWeb web)
        {
            Period[] periods = new Period[0];
            SPWeb tsWeb = SPContext.Current.Web;
            SPList lstPeriods = null;
            SPList lstData = null;
            ArrayList arrPeriods = new ArrayList();
            try
            {
                lstPeriods = web.Lists["EPMLivePeriods"];
                lstData = tsWeb.Lists["EPMLiveTimePhased"];
            }
            catch { }
            if(lstPeriods != null && lstData != null)
            {
                foreach(SPListItem li in lstPeriods.Items)
                {
                    try
                    {
                        string field = li.Title.Replace(" ", "_x0020_");

                        if(lstData.Fields.GetFieldByInternalName(field) != null)
                        {

                            Period p = new Period();
                            p.name = li.Title;
                            p.start = DateTime.Parse(li["StartDate"].ToString());
                            p.end = DateTime.Parse(li["EndDate"].ToString());

                            arrPeriods.Add(p);
                        }
                    }
                    catch
                    {

                    }
                }
            }

            periods = new Period[arrPeriods.Count];
            int counter = 0;
            foreach(Period p in arrPeriods)
            {
                periods[counter++] = p;
            }
            return periods;
        }

        [WebMethod]
        public string[] getPublisherSettings()
        {
            ArrayList arrSettings = new ArrayList();
            string url = SPContext.Current.Web.Url;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(url))
                {
                    using (SPWeb web = site.OpenWeb())
                    {

                        web.Site.CatchAccessDeniedException = false;
                        web.AllowUnsafeUpdates = true;

                        Guid lWeb = CoreFunctions.getLockedWeb(web);

                        if(lWeb != Guid.Empty)
                        {
                            using (SPWeb web2 = site.OpenWeb(lWeb))
                            {
                                //if (web2.Url.ToLower() == url2.ToLower())
                                {
                                    foreach (string prop in web2.Properties.Keys)
                                        if (prop.Contains("epmlivepub-"))
                                            if (web2.Properties[prop] != "")
                                                arrSettings.Add(prop + "|" + web2.Properties[prop]);
                                }
                            }
                            //    }
                            //}
                        }
                        else
                        {
                            foreach (string prop in web.Properties.Keys)
                                if (prop.Contains("epmlivepub-"))
                                    if (web.Properties[prop] != "")
                                        arrSettings.Add(prop + "|" + web.Properties[prop]);
                        }

                        arrSettings.Add("epmlivetsflag|" + web.Site.RootWeb.Properties["EPMLiveTSFlag"]);
                        arrSettings.Add("epmlivetstimesheethours|" + web.Site.RootWeb.Properties["EPMLiveTSTimesheetHours"]);

                    }
                }
            });

            return (string[])arrSettings.ToArray(typeof(string));
        }

        [WebMethod]
        public bool canPublishToSite()
        {
            try
            {
                string pub = CoreFunctions.getConfigSetting(SPContext.Current.Web, "EPMLiveDisablePublishing").Trim();
                if (pub == "True")
                    return false;
                else
                    return true;
            }
            catch
            {
                return true;
            }
        }
    }

}