using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

using System.ComponentModel;

using System.Xml;

using System.Collections;
using System.Data;
using System.Text;

using System.Resources;

using System.Data.SqlClient;

namespace EPMLiveWebParts.RollupSummary
{
    [ToolboxData("<{0}:EPMLiveRollupSummary runat=server></{0}:EPMLiveRollupSummary>")]
    [Guid("7537b1cf-ae25-4ed0-abb6-67013a4a078e")]
    [XmlRoot(Namespace = "MyWebParts")]
    public class RollupSummary : Microsoft.SharePoint.WebPartPages.WebPart
    {
        public string title = "EPM Live Summary Rollup";
        private StringBuilder sb = new StringBuilder();
        private string strXML;
        private string strRollupSites;
        //private string[] rollupsites;
        SPWeb web;
        Hashtable hshCounts = new Hashtable();
        Hashtable hshNodes = new Hashtable();
        private SortedList arrSites;
        SqlConnection cn;

        [Category("Custom Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [Browsable(false)]
        // The accessor for this property.
        public string MyXml
        {
            get
            {
                if (strXML == null || strXML.Trim() == "")
                    return Properties.Resources.defaultXml;
                return strXML;
            }
            set
            {
                strXML = value;
            }
        }

        [Category("Custom Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [Browsable(false)]
        // The accessor for this property.
        public string MyRollupSites
        {
            get
            {
                if (strRollupSites == null || strRollupSites.Trim() == "")
                    return "";
                return strRollupSites;
            }
            set
            {
                strRollupSites = value;
            }
        }

        public override string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                base.Title = value;
            }
        }

        public RollupSummary()
        {
            this.ExportMode = WebPartExportMode.All;
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(SPContext.Current.Web);
            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.WebParts);

            if (activation != 0)
            {
                output.Write(act.translateStatus(activation));
                return;
            }

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite s = new SPSite(SPContext.Current.Site.ID))
                {
                    try
                    {
                        string dbCon = s.ContentDatabase.DatabaseConnectionString;
                        cn = new SqlConnection(dbCon);
                        cn.Open();
                        
                    }
                    catch { }
                }
            });

            arrSites = new SortedList();

            bool dupsFound = false;

            web = SPContext.Current.Web;

            

            XmlDocument doc = new XmlDocument();

            try
            {
                
                doc.LoadXml(MyXml);
                foreach (XmlNode nSections in doc.SelectSingleNode("Sections").SelectNodes("Section"))
                {
                    foreach (XmlNode nItem in nSections.SelectSingleNode("Items").SelectNodes("Item"))
                    {
                        string id = "";
                        try
                        {
                            id = nItem.Attributes["ID"].Value;
                        }
                        catch { }
                        if (id != "")
                        {
                            if (!hshNodes.Contains(id))
                            {
                                hshNodes.Add(id, nItem);
                                hshCounts.Add(id, 0);
                            }
                            else
                            {
                                dupsFound = true;  
                            }
                        }
                    }
                }

                if (strRollupSites == null || strRollupSites.Length <= 0)
                {
                    processWeb(web);
                }
                else
                {
                    foreach (string strRollupSite in strRollupSites.Split('\n'))
                    {
                        //SPSecurity.RunWithElevatedPrivileges(delegate()
                        //{
                            try
                            {
                                if (web.Url.ToLower() == strRollupSite.ToLower())
                                    processWeb(web);
                                else
                                {
                                    using (SPSite procSite = new SPSite(strRollupSite))
                                    {
                                        using (SPWeb ww = procSite.OpenWeb())
                                        {
                                            processWeb(ww);
                                        }
                                    }
                                }
                            }
                            catch { }
                        //});
                    }
                }
                //string curSite = "";
                //SPSite site = null;
                //SPWeb procWeb = null;
                //foreach(DictionaryEntry de in arrSites)
                //{
                //    if (curSite != de.Value.ToString())
                //    {
                //        if (site != null)
                //            site.Close();
                //        site = new SPSite(de.Key.ToString());
                //        curSite = de.Key.ToString();
                //    }

                //    string sWeb = de.Key.ToString().Replace(de.Value.ToString(), "");
                //    if (sWeb == "")
                //        procWeb = site.RootWeb;
                //    else
                //        procWeb = site.OpenWeb(sWeb.Substring(1));
                //    processWeb(procWeb);
                //    procWeb.Close();
                //    if (site != null)
                //        site.Close();
                //}

                foreach(XmlNode n in doc.SelectSingleNode("Sections"))
                {
                    processSection(n);
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Root element is missing") > -1 || ex.Message.IndexOf("Value cannot be null") > -1)
                {
                    output.Write("This webpart XML is Missing.");
                }
                else
                    output.Write("Failed to load XML: " + ex.Message);
                return;
            }
            if (dupsFound)
            {
                output.Write("Warning: Duplicate Item ID's Found");
            }

            output.Write("<table cellpadding=\"1\" cellspacing=\"1\" style=\"margin:10px;\" class=\"ms-stdtxt\">");
            output.Write(sb.ToString());
            output.Write("</table>");
            
        }


        //private void getWebs(SPWeb web)
        //{
        //    arrSites.Add(web.Url,web.Site.Url);
        //    foreach (SPWeb w in web.Webs)
        //    {
        //        getWebs(w);
        //        w.Close();
        //    }
        //}

        private void processSection(XmlNode ndSection)
        {
            string section = "";
            string url = "";
            try
            {
                section = ndSection.Attributes["Title"].Value;
            }
            catch{}
            try
            {
                string rUrl = web.ServerRelativeUrl;
                if (rUrl == "/") rUrl = "";
                url = ndSection.Attributes["URL"].Value;
                url = url.Replace("{WebUrl}", rUrl);
            }
            catch { }

            sb.Append("<tr>");
            if (url.Trim() != "")
                sb.Append("<td colspan=\"4\"><font class=\"ms-sectionheader\"><a class=\"ms-sectionheader\" href=\"" + url + "\">" + section + "</a></td>");
            else
                sb.Append("<td colspan=\"4\"><font class=\"ms-sectionheader\"><font class=\"ms-sectionheader a\">" + section + "</font></td>");
            sb.Append("</tr>");

            foreach (XmlNode n in ndSection.SelectSingleNode("Items"))
            {
                processItem(n);
            }
            sb.Append("<tr>");
            sb.Append("<td>&nbsp;</td>");
            sb.Append("</tr>");
        }

        public void processItem(XmlNode ndItem)
        {

            string icon = "";
            int count = 0;
            string id = "";
            try
            {
                icon = ndItem.Attributes["Icon"].Value;
            }
            catch { }
            try
            {
                id = ndItem.Attributes["ID"].Value;
            }
            catch { }

            count = (int)hshCounts[id];
            
            sb.Append("<tr>");
            if (icon != "")
                sb.Append("<td nowrap=\"nowrap\" width=\"27\"><img src=\"" + icon + "\" alt=\"\" style=\"border-width:0px;\" /></td>");
            else
                sb.Append("<td nowrap=\"nowrap\" width=\"27\"></td>");

            processDisplay(ndItem.SelectSingleNode("Displays"), count);

            sb.Append("</tr>");

        }

        private void processDisplay(XmlNode ndDisplays, int count)
        {
            string display = "";
            foreach (XmlNode ndDisplay in ndDisplays)
            {
                string compare = "";
                int val = 0;
                try
                {
                    compare = ndDisplay.Attributes["Comparator"].Value;
                }
                catch { }
                try
                {
                    val = Convert.ToInt32(ndDisplay.Attributes["Value"].Value);
                }
                catch { }
                if (compare == "GT")
                {
                    if (count > val)
                    {
                        display = ndDisplay.InnerText;
                        break;
                    }
                }
                else if (compare == "LT")
                {
                    if (count < val)
                    {
                        display = ndDisplay.InnerText;
                        break;
                    }
                }
                else
                {
                    display = ndDisplay.InnerText;
                    break;
                }
            }
            display = display.Replace("{#}", count.ToString());
            display = display.Replace("{WebUrl}", web.ServerRelativeUrl);
            sb.Append("<td nowrap=\"nowrap\" colspan=\"3\"><span class=\"ms-stdtxt\">" + display + "</span></td>");
        }

        private void processWeb(SPWeb curWeb)
        {
            try
            {
                foreach (DictionaryEntry e in hshNodes)
                {
                    XmlNode ndItem = (XmlNode)e.Value;
                    string id = "";
                    string list = "";
                    string query = "";

                    try
                    {
                        id = ndItem.Attributes["ID"].Value;
                    }
                    catch { }
                    try
                    {
                        list = ndItem.SelectSingleNode("Query").Attributes["List"].Value;
                    }
                    catch { }
                    try
                    {
                        query = ndItem.SelectSingleNode("Query").InnerText;
                    }
                    catch { }

                    hshCounts[id] = (int)hshCounts[id] + getCount(list, query, curWeb);

                }
            }
            catch (Exception ex)
            {
                sb.Append("ERROR: " + ex.Message + ex.StackTrace);
            }

        }

        private int getCount(string list, string query, SPWeb curWeb)
        {
            string siteurl = curWeb.ServerRelativeUrl.Substring(1);

            SPSiteDataQuery dq = new SPSiteDataQuery();
            int count = 0;
            try
            {
                string lists = "";


                string squery = "";
                if (siteurl == "")
                    squery = "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     webs.siteid='" + web.Site.ID + "' AND (dbo.AllLists.tp_Title like '" + list.Replace("'", "''") + "')";
                else
                    squery = "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     (dbo.Webs.FullUrl LIKE '" + siteurl + "/%' OR dbo.Webs.FullUrl = '" + siteurl + "') AND (dbo.AllLists.tp_Title like '" + list.Replace("'", "''") + "')";

                SqlCommand cmd = new SqlCommand(squery, cn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lists += "<List ID='" + dr.GetGuid(0).ToString() + "'/>";
                }
                dr.Close();

                            


                //dq.Lists = "<Lists ServerTemplate='10701'/>";
                dq.Lists = "<Lists>" + lists + "</Lists>";
                dq.Query = "<Where>" + query + "</Where>";
                dq.Webs = "<Webs Scope='Recursive'/>";
                dq.QueryThrottleMode = SPQueryThrottleOption.Override;
                DataTable dt = new DataTable();
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    dt = curWeb.GetSiteData(dq);
                });
                count = dt.Rows.Count;
            }
            catch (Exception ex)
            {
                sb.Append("ERROR: " + ex.Message + ex.StackTrace);
            }

            return count;

        }

        public override ToolPart[] GetToolParts()
        {
            ToolPart[] toolparts = new ToolPart[3];
            toolparts[0] = new WebPartToolPart();
            toolparts[1] = new CustomPropertyToolPart();

            //Create a custom toolpart
            toolparts[2] = new SummaryRollupToolpart();

            return toolparts;
        }
    }
}
