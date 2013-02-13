using System;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;
using EPMLiveWebParts.Utilities;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

using System.Collections;
using System.ComponentModel;

using System.Data;
using System.Data.SqlClient;

using System.Collections.Generic;

using System.Xml;

using System.Text;
using ReportFiltering;

namespace EPMLiveWebParts
{
    [Guid("13de964a-8dc2-4113-b9ef-bf9ec9b4f63e")]
    [ToolboxData("<{0}:ListSummaryWebpart runat=server></{0}:ListSummaryWebpart>")]
    [XmlRoot(Namespace = "ListSummary")]
    public class ListSummary : Microsoft.SharePoint.WebPartPages.WebPart
    {
        private const int MAX_LOOKUPFILTER = 300;

        private IReportID _myProvider;

        private EPMLiveCore.Act act;

        private string strList;
        private string strView;
        private string strRollupList;
        private string strRollupSites;
        private string strStatus;
        private string strUrl;

        private int activation;

        private string sErrors = "";

        int totalItems = 0;

        private SortedList<string, int> slStatus = new SortedList<string,int>();

        private string reportFilterField = "";
        ArrayList reportFilterIDs = new ArrayList();
        private string _lookupField;
        private string _lookupFieldList;

        [Category("Grid Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [Browsable(false)]
        public string PropStatus
        {
            get
            {
                if (strStatus == null)
                    return "";
                return strStatus;
            }
            set
            {
                strStatus = value;
            }
        }

        [Category("Grid Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [Browsable(false)]
        public string PropUrl
        {
            get
            {
                return strUrl;
            }
            set
            {
                strUrl = value;
            }
        }

        [Category("Grid Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [Browsable(false)]
        public string PropList
        {
            get
            {
                if (strList == null)
                    return "";
                return strList;
            }
            set
            {
                strList = value;
            }
        }

        [Category("Grid Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [Browsable(false)]
        public string PropView
        {
            get
            {
                if (strView == null)
                    return "";
                return strView;
            }
            set
            {
                strView = value;
            }
        }
        [Category("Grid Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [Browsable(false)]
        public string PropRollupList
        {
            get
            {
                if (strRollupList == null)
                    return "";
                return strRollupList;
            }
            set
            {
                strRollupList = value;
            }
        }
        [Category("Grid Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [Browsable(false)]
        public string PropRollupSites
        {
            get
            {
                if (strRollupSites == null)
                    return "";
                return strRollupSites;
            }
            set
            {
                strRollupSites = value;
            }
        }

        [ConnectionConsumer("Report ID Consumer", "ReportIDConsumer")]
        public void ReportIDConsumer(IReportID Provider)
        {
            _myProvider = Provider;
        }

        public ListSummary()
        {
            _lookupField = HttpContext.Current.Request.QueryString["lookupfield"];
            _lookupFieldList = HttpContext.Current.Request.QueryString["lookupfieldlist"];
        }

        protected override void CreateChildControls()
        {

            act = new EPMLiveCore.Act(SPContext.Current.Web);
            activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.WebParts);

            if (activation != 0)
                return;

            base.CreateChildControls();

            // TODO: add custom rendering code here.
            // Label label = new Label();
            // label.Text = "Hello World";
            // this.Controls.Add(label);
        }

        private string GetReportFilters()
        {
            StringBuilder sb = new StringBuilder();
            foreach(string s in reportFilterIDs)
            {
                sb.Append("<Value Type=\"Text\">");
                sb.Append(System.Web.HttpUtility.HtmlEncode(s));
                sb.Append("</Value>");
            }

            return sb.ToString();
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            if (activation != 0)
            {
                
                output.Write(act.translateStatus(activation));
                return;
            }

            if (PropList != "" && PropView != "" && PropStatus != "")
            {
                try
                {
                    getData();
                    SPWeb web = SPContext.Current.Web;
                    SPList list = web.GetListFromUrl(PropList);
                    SPField field = list.Fields.GetFieldByInternalName(PropStatus);

                    output.Write("<table border=\"0\" width=\"100%\" cellpadding=\"2\" cellspacing=\"0\">");

                    foreach (string status in slStatus.Keys)
                    {
                        int val = slStatus[status];
                        int percent = 0;
                        if (totalItems > 0)
                            percent = val * 100 / totalItems;
                        output.Write("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">");

                        string fstatus = "";
                        try
                        {
                            fstatus = field.GetFieldValueAsText(status);
                        }
                        catch { }

                        if (PropUrl != null && PropUrl != "")
                        {
                            if (SPContext.Current.Web.ServerRelativeUrl == "/")
                                output.Write("<a href=\"" + PropUrl.Replace("{SiteUrl}", "") + "?filterfield1=" + PropStatus + "&filtervalue1=" + fstatus + "\">");
                            else
                                output.Write("<a href=\"" + PropUrl.Replace("{SiteUrl}", SPContext.Current.Web.ServerRelativeUrl) + "?filterfield1=" + PropStatus + "&filtervalue1=" + fstatus + "\">");
                        }

                        output.Write(fstatus);

                        if (PropUrl != "")
                            output.Write("</a>");

                        output.Write(": " + val.ToString() + " ( " + (percent).ToString() + "% ) </td>");
                        output.Write("<td><table width=\"100%\"><tr><td width=\"" + (percent).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

                    }

                    output.Write("</tr></table>");
                }
                catch (Exception ex)
                {
                    output.Write("Error: " + ex.Message);
                }
            }

            output.Write(sErrors);
        }

        private void getData()
        {

            if (PropRollupSites != "")
            {
                foreach (string rsite in PropRollupSites.Replace("\r\n", "\n").Split('\n'))
                {
                    try
                    {
                        using (SPSite site = new SPSite(rsite))
                        {
                            using (SPWeb web = site.OpenWeb())
                            {
                                processWeb(web);
                            }
                        }
                    }
                    catch { }
                }
            }
            else
            {
                processWeb(SPContext.Current.Web);
            }
        }

        private string ProcessReportFilter(XmlDocument xmlQuery, SPList list, SPWeb web)
        {
            string ret = "";
            if(_myProvider != null)
            {
                Guid listid = Guid.Empty;


                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    try
                    {
                        SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                        cn.Open();

                        SqlCommand cmd = new SqlCommand("SELECT VALUE,listid FROM PERSONALIZATIONS where userid=@userid and [key]=@key and FK=@FK", cn);
                        cmd.Parameters.AddWithValue("@userid", web.CurrentUser.ID);
                        cmd.Parameters.AddWithValue("@key", "ReportFilterWebPartSelections");
                        cmd.Parameters.AddWithValue("@FK", _myProvider.ReportID.Replace("g_","").Replace("_","-"));
                        cmd.ExecuteNonQuery();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            reportFilterIDs = new ArrayList(dr.GetString(0).Split('|')[0].Split(','));
                            listid = dr.GetGuid(1);
                        }
                        dr.Close();
                        cn.Close();
                    }
                    catch { }
                });

                if(listid == list.ID)
                {
                    reportFilterField = "Title";

                    if(reportFilterIDs.Count < MAX_LOOKUPFILTER)
                    {

                        ret = "<In><FieldRef Name=\"Title\"/><Values>" + GetReportFilters() + "</Values></In>";

                    }
                }
                else if(listid != Guid.Empty)
                {



                    foreach(SPField oField in list.Fields)
                    {
                        if(oField.Type == SPFieldType.Lookup)
                        {
                            try
                            {
                                SPFieldLookup oLookup = (SPFieldLookup)oField;
                                if(new Guid(oLookup.LookupList) == listid)
                                {
                                    reportFilterField = oLookup.InternalName;
                                    break;
                                }
                            }
                            catch { }
                        }
                    }


                    if(reportFilterIDs.Count < MAX_LOOKUPFILTER && reportFilterField != "")
                    {
                        ret = "<In><FieldRef Name=\"" + reportFilterField + "\"/><Values>" + GetReportFilters() + "</Values></In>";
                    }
                }
            }

            return ret;
        }

        private void processWeb(SPWeb web)
        {
            try
            {
                string siteurl = web.ServerRelativeUrl.Substring(1);

                SPList list = web.GetListFromUrl(PropList);
                SPView view = list.Views[PropView];
                string spquery = view.Query;

                SPField f = list.Fields.GetFieldByInternalName(PropStatus);
                if (f.Type == SPFieldType.Choice || f.Type == SPFieldType.MultiChoice)
                {
                    XmlDocument docfield = new XmlDocument();
                    docfield.LoadXml(f.SchemaXml);
                    foreach (XmlNode ndChoice in docfield.FirstChild.SelectNodes("//CHOICE"))
                    {
                        slStatus.Add(ndChoice.InnerText, 0);
                    }
                }

                ArrayList arr = new ArrayList();
                string dqFields = "<FieldRef Name='" + PropStatus + "' Nullable='TRUE'/>";
                string dquery = "";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<Query>" + view.Query + "</Query>");

                string reportInternal = ProcessReportFilter(doc, list, web);
                LookupFilterHelper.AppendLookupQueryToExistingQuery(ref doc, _lookupField, _lookupFieldList);
                XmlNode ndWhere = doc.FirstChild.SelectSingleNode("//Where");

                if(reportInternal != "")
                {
                    if(ndWhere == null)
                    {
                        ndWhere = doc.CreateElement("Where");
                        doc.FirstChild.PrependChild(ndWhere);

                        ndWhere.InnerXml = reportInternal;
                    }
                    else
                    {
                        ndWhere.InnerXml = "<And>" + reportInternal + ndWhere.InnerXml + "</And>";
                    }
                }

                if (ndWhere != null)
                    dquery = ndWhere.OuterXml;

                dquery = dquery + "<OrderBy><FieldRef Name='" + PropStatus + "'/></OrderBy>";


                if (PropRollupList != "")
                {
                    string lists = "";
                    SqlConnection cn = null;
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        using (SPSite s1 = new SPSite(web.Site.ID))
                        {
                            string dbCon = s1.ContentDatabase.DatabaseConnectionString;
                            cn = new SqlConnection(dbCon);
                            cn.Open();
                        }
                    });

                    foreach (string rlist in PropRollupList.Replace("\r\n", "\n").Split('\n'))
                    {
                        try
                        {
                            lists = "";
                            string query = "";
                            if (siteurl == "")
                                query = "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     webs.siteid='" + web.Site.ID + "' AND (dbo.AllLists.tp_Title like '" + rlist.Replace("'", "''") + "')";
                            else
                                query = "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     (dbo.Webs.FullUrl LIKE '" + siteurl + "/%' OR dbo.Webs.FullUrl = '" + siteurl + "') AND (dbo.AllLists.tp_Title like '" + rlist.Replace("'", "''") + "')";

                            
                            SqlCommand cmd = new SqlCommand(query, cn);
                            //cmd.Parameters.AddWithValue("@rlist", rlist);
                            SqlDataReader dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                lists += "<List ID='" + dr.GetGuid(0).ToString() + "'/>";
                            }
                            dr.Close();

                            if(lists != "")
                            {
                                SPSiteDataQuery dq = new SPSiteDataQuery();
                                dq.Lists = "<Lists MaxListLimit='0'>" + lists + "</Lists>";
                                dq.Query = dquery;
                                dq.Webs = "<Webs Scope='Recursive'/>";
                                dq.ViewFields = dqFields;
                                dq.QueryThrottleMode = SPQueryThrottleOption.Override;

                                try
                                {
                                    DataTable dt = new DataTable();
                                    SPSecurity.RunWithElevatedPrivileges(delegate()
                                    {
                                        dt = web.GetSiteData(dq);
                                    });

                                    processList(dt);
                                }
                                catch(Exception ex)
                                {
                                    sErrors += "Get Rollup Site Data Error: " + ex.Message + "<br>";
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            sErrors += "Rollup List Error: " + ex.Message + "<br>";
                        }

                    }
                    cn.Close();
                }
                else
                {
                    SPSiteDataQuery dq = new SPSiteDataQuery();
                    dq.Lists = "<Lists MaxListLimit='0'><List ID='" + list.ID.ToString() + "'/></Lists>";
                    dq.Query = dquery;
                    dq.ViewFields = dqFields;
                    dq.QueryThrottleMode = SPQueryThrottleOption.Override;

                    try
                    {
                        DataTable dt = web.GetSiteData(dq);

                        processList(dt);
                    }
                    catch (Exception ex)
                    {
                        sErrors += "Get Site Data Error: " + ex.Message + "<br>";
                    }
                }
            }
            catch(Exception ex) {
                sErrors += "General Error: " + ex.Message + "<br>";
            }
        }

        private void processList(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {

                bool canCount = true;
                if(reportFilterIDs.Count >= MAX_LOOKUPFILTER)
                {
                    if(!reportFilterIDs.Contains(dr[reportFilterField]))
                        canCount = false;
                }

                if(canCount)
                {
                    if(slStatus.ContainsKey(dr[PropStatus].ToString()))
                    {
                        slStatus[dr[PropStatus].ToString()] = slStatus[dr[PropStatus].ToString()] + 1;
                    }
                    else
                    {
                        slStatus.Add(dr[PropStatus].ToString(), 1);
                    }

                    totalItems++;
                }
            }
        }

        public override ToolPart[] GetToolParts()
        {
            ToolPart[] toolparts = new ToolPart[3];
            toolparts[0] = new ListSummaryToolpart();
            toolparts[1] = new WebPartToolPart();
            toolparts[2] = new CustomPropertyToolPart();


            return toolparts;
        }
    }
}
