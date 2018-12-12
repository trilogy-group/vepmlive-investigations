using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;

namespace EPMLiveWebParts
{
    [Guid("13de964a-8dc2-4113-b9ef-bf9ec9b4f63e")]
    [ToolboxData("<{0}:ListSummaryWebpart runat=server></{0}:ListSummaryWebpart>")]
    [XmlRoot(Namespace = "ListSummary")]
    public class ListSummary : Microsoft.SharePoint.WebPartPages.WebPart
    {
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
                        output.Write("<td><table width=\"100%\"><tr><td width=\"" + (percent).ToString() + "%\" height=\"15px\" style=\"background-color: rgb(0, 144, 202)\"></td><td width=\"100%\"></td></tr></table></td></tr>");

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

        private string GetReportFilters()
        {
            return ListSummaryProcessHelper.GetReportFilters(reportFilterIDs);
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
            return ListSummaryProcessHelper.ProcessReportFilter(list, web, _myProvider, ref reportFilterIDs, ref reportFilterField);
        }

        private void processWeb(SPWeb web)
        {
            ListSummaryProcessHelper.ProcessWeb(
                web,
                slStatus,
                PropRollupList,
                ref sErrors,
                ProcessReportFilter,
                processList,
                PropList,
                PropView,
                PropStatus,
                _lookupField,
                _lookupFieldList);
        }

        private void processList(DataTable dt)
        {
            ListSummaryProcessHelper.ProcessList(dt, reportFilterIDs, reportFilterField, slStatus, PropStatus, ref totalItems);
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
