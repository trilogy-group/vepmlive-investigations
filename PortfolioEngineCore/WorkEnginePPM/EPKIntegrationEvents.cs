using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Collections;
using System.Xml;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using PortfolioEngineCore;

namespace WorkEnginePPM
{
    public class EPKIntegrationEvents : SPItemEventReceiver 
    {

        public override void ItemAdded(SPItemEventProperties properties)
        {
            processItem(properties);
        }

        public override void ItemDeleting(SPItemEventProperties properties)
        {
            try
            {
                using (SPSite site = new SPSite(properties.SiteId))
                {
                    string xml = "<Items><Item ID=\"" + properties.Web.ID + "." + properties.ListId + "." + properties.ListItemId + "\"/></Items>";

                    string ret = CloseItemXml(xml, properties.Web);

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(ret);

                    XmlNode ndStatus = xmlDoc.SelectSingleNode("//STATUS");

                    if (ndStatus != null)
                    {
                        if (ndStatus.InnerText != "0")
                        {
                            properties.Cancel = true;
                            properties.ErrorMessage = "Error deleting Portfolio item: " + xmlDoc.SelectSingleNode("//Error").InnerText;
                        }
                    }
                    else
                    {
                        properties.Cancel = true;
                        properties.ErrorMessage = "Error processing Portfolio item: Unable to get status from Portfolio Integration.";
                    }
                }
            }
            catch (Exception ex)
            {
                properties.Cancel = true;
                properties.ErrorMessage = "Error deleting item: " + ex.Message;
            }
        }

        public override void ItemUpdating(SPItemEventProperties properties)
        {
            processItem(properties);
        }

        private void processItem(SPItemEventProperties properties)
        {
            //WorkEnginePPM.WebAdmin.SimpleDBTrace(properties.SiteId, 99900, "WorkEnginePPM", "processItem", "Entry", "");
            if(properties.ListItem != null)
            {
                Hashtable hshFields = new Hashtable();
                Hashtable hshFields2 = new Hashtable();
                try
                {
                    if(properties.AfterProperties["ExternalID"].ToString() != "")
                        return;
                }
                catch { }
                try
                {
                    using(SPSite site = new SPSite(properties.SiteId))
                    {

                        string fields = ConfigFunctions.getConfigSetting(site.RootWeb, "EPK" + properties.List.Title.Replace(" ","") + "_fields");
                        
                        if(fields == "")
                            fields = ConfigFunctions.getConfigSetting(site.RootWeb, "epkportfoliofields");

                        if(fields != "")
                        {
                            foreach(string field in fields.Split('|'))
                            {
                                string[] spField = field.Split(',');
                                if (spField[2] == "2" || spField[2] == "3")
                                    hshFields.Add(spField[0], spField[1]);
                                if (spField[2] == "1" || spField[2] == "3")
                                    hshFields2.Add(spField[0], spField[1]);
                            }
                        }

                        string xml = "<Items>";

                        xml += ConfigFunctions.getItemXml(properties.ListItem, hshFields, properties.AfterProperties, properties.Web);

                        xml += "</Items>";

                        string ret = UpdateItemXml(xml, properties.Web);
                        //WorkEnginePPM.WebAdmin.SimpleDBTrace(properties.SiteId, 99901, "WorkEnginePPM", "processItem", xml, ret);

                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(ret);

                        //XmlNode ndStatus = xmlDoc.SelectSingleNode("Reply/STATUS");

                        //if(ndStatus != null)
                        //{
                        if(xmlDoc.FirstChild.SelectSingleNode("//Item[@ItemId='" + properties.Web.ID + "." + properties.ListId + "." + properties.ListItemId + "']").Attributes["Error"].Value != "0")
                        {
                            properties.Cancel = true;
                            properties.ErrorMessage = "Error processing item: " + xmlDoc.FirstChild.SelectSingleNode("//Item[@ItemId='" + properties.Web.ID + "." + properties.ListId + "." + properties.ListItemId + "']").InnerText;
                            return;
                        }

                            CStruct xReply = new CStruct();
                            xReply.LoadXML("<Return>" + ret + "</Return>");
                            
                            // the reply xml contains the "UpdateItems" xml sent back from PE

                            CStruct xUpdatePortfolioItems = xReply.GetSubStruct("UpdatePortfolioItems");
                            if (xUpdatePortfolioItems != null)
                            {
                                SPList list = properties.ListItem.ParentList;
                                string sItemID = list.ParentWeb.ID + "." + list.ID + "." + properties.ListItem.ID;
                                // <Item ItemId="cda5677f-08b8-44ab-8c63-f287d6200cd9.ec269b62-7fe5-47c9-8614-bb9752d4b8e8.3" ID="2" Error="2" ErrorText="Field Name 20017 not found"/>
                                // look for any item errors
                                List<CStruct> lstItems = xUpdatePortfolioItems.GetList("Item");
                                foreach (CStruct xItem in lstItems)
                                {
                                    if (xItem.GetStringAttr("ItemId") == sItemID)
                                    {
                                        int nError = xItem.GetIntAttr("Error");
                                        if (nError != 0)
                                        {
                                            properties.Cancel = true;
                                            properties.ErrorMessage = "Error processing item: " + nError.ToString() + " - " + xItem.GetStringAttr("ErrorText");
                                            //WorkEnginePPM.WebAdmin.SimpleDBTrace(properties.SiteId, 99902, "WorkEnginePPM", "processItem", "error1", properties.ErrorMessage);
                                            return;
                                        }
                                    }
                                }


                                CStruct xPortfolioItems = xUpdatePortfolioItems.GetSubStruct("PortfolioItems");
                                List<CStruct> lstPortfolioItems = xPortfolioItems.GetList("PortfolioItem");


                                SPItemEventDataCollection afterProperties = properties.AfterProperties;
                                foreach (CStruct xPortfolioItem in lstPortfolioItems)
                                {
                                    if (xPortfolioItem.GetStringAttr("ItemID") == sItemID)
                                    {

                                        List<CStruct> lstFields = xPortfolioItem.GetList("Field");
                                        //foreach (CStruct xField in lstFields)
                                        //{
                                        //    string sField = xField.GetStringAttr("ID");
                                        //    string sValue = xField.GetStringAttr("Value");
                                        //    if (hshFields.ContainsKey(sField))
                                        //    //if (list.Fields.ContainsField(sField))
                                        //    {
                                        //        string s = hshFields.Values.[sField];
                                        //        afterProperties[sField] = sValue;
                                        //    }
                                        //}

                                        foreach (DictionaryEntry field in hshFields2)
                                        {
                                            string spfield = field.Value.ToString();
                                            string epkfield = field.Key.ToString();

                                            CStruct xCurrentEPKField = null;
                                            foreach (CStruct xField in lstFields)
                                            {
                                                if (xField.GetStringAttr("ID") == epkfield)
                                                {
                                                    xCurrentEPKField = xField;
                                                    break;
                                                }
                                            }

                                            if (xCurrentEPKField != null)
                                            {
                                                string sValue = xCurrentEPKField.GetStringAttr("Value");
                                                SPField oField = null;
                                                try
                                                {
                                                    oField = list.Fields.GetFieldByInternalName(spfield);
                                                }
                                                catch { }

                                                if (oField != null)
                                                {
                                                    try
                                                    {
                                                        if (oField.Type == SPFieldType.DateTime)
                                                        {
                                                            try
                                                            {
                                                                afterProperties[spfield] = sValue;
                                                            }
                                                            catch { }
                                                        }
                                                        else if (oField.Type == SPFieldType.User)
                                                        {
                                                            try
                                                            {
                                                                //SPUser user = web.AllUsers.GetByID(int.Parse(afterProperties[spfield].ToString().Split(';')[0]));
                                                                //val = EPMLiveCore.CoreFunctions.GetRealUserName(user.LoginName);
                                                            }
                                                            catch { }
                                                        }
                                                        else if (oField.Type == SPFieldType.Number || oField.Type == SPFieldType.Currency)
                                                        {
                                                            try
                                                            {
                                                                afterProperties[spfield] = sValue;
                                                            }
                                                            catch { }
                                                        }
                                                        else if (oField.Type == SPFieldType.Boolean)
                                                        {
                                                            try
                                                            {
                                                                afterProperties[spfield] = sValue;
                                                            }
                                                            catch { }

                                                        }
                                                        else if (oField.Type == SPFieldType.Calculated)
                                                        {
                                                            afterProperties[spfield] = sValue;
                                                        }
                                                        else
                                                        {
                                                            try
                                                            {
                                                                afterProperties[spfield] = sValue;
                                                            }
                                                            catch { }
                                                        }
                                                    }
                                                    catch { }
                                                }
                                            }
                                        }
                                    }
                                }
                            }


                        //}
                        //else
                        //{
                        //    properties.Cancel = true;
                        //    properties.ErrorMessage = "Error processing item: Unable to get status from Portfolio Integration.";
                        //    //WorkEnginePPM.WebAdmin.SimpleDBTrace(properties.SiteId, 99904, "WorkEnginePPM", "processItem", "error2", properties.ErrorMessage);
                        //}
                    }
                }
                catch(Exception ex)
                {
                    properties.Cancel = true;
                    properties.ErrorMessage = "General error processing item: " + ex.Message;
                    //WorkEnginePPM.WebAdmin.SimpleDBTrace(properties.SiteId, 99904, "WorkEnginePPM", "processItem", "Exception", properties.ErrorMessage);
                }
            }
        }

        private string UpdateItemXml(string xml, SPWeb web)
        {
            string username = ConfigFunctions.GetCleanUsername(web);
            

            SPWeb rootWeb = web.Site.RootWeb;

            string basePath = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
            string ppmId = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
            string ppmCompany = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
            string ppmDbConn = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");

            PortfolioEngineCore.PortfolioItems.PortfolioItems we = new PortfolioEngineCore.PortfolioItems.PortfolioItems(basePath, username, ppmId, ppmCompany, ppmDbConn, false);
            string ret = "";
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                ret = we.UpdatePortfolioItems(xml);
            });
            return ret;
        }

        private string CloseItemXml(string xml, SPWeb web)
        {
            string username = ConfigFunctions.GetCleanUsername(web);

            SPWeb rootWeb = web.Site.RootWeb;

            string basePath = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
            string ppmId = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
            string ppmCompany = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
            string ppmDbConn = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");

            PortfolioEngineCore.PortfolioItems.PortfolioItems we = new PortfolioEngineCore.PortfolioItems.PortfolioItems(basePath, username, ppmId, ppmCompany, ppmDbConn, false);

            string ret = "";
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                ret = we.ClosePortfolioItems(xml);
            });
            return ret;
        }
    }
}
