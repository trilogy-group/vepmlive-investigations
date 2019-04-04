using System;
using System.Collections;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Serialization;
using EPMLiveCore;
using EPMLiveWebParts.Properties;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using WebPart = Microsoft.SharePoint.WebPartPages.WebPart;

namespace EPMLiveWebParts.RollupSummary
{
    [ToolboxData("<{0}:EPMLiveRollupSummary runat=server></{0}:EPMLiveRollupSummary>")]
    [Guid("7537b1cf-ae25-4ed0-abb6-67013a4a078e")]
    [XmlRoot(Namespace = "MyWebParts")]
    public partial class RollupSummary : WebPart
    {
        public RollupSummary()
        {
            ExportMode = WebPartExportMode.All;
        }

        public string title = "EPM Live Summary Rollup";
        private StringBuilder sb = new StringBuilder();
        private string strXML;
        private string strRollupSites;
        private SPWeb web;
        private Hashtable hshCounts = new Hashtable();
        private Hashtable hshNodes = new Hashtable();
        private SortedList arrSites;
        private SqlConnection cn;

        [Category("Custom Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyName("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [Browsable(false)]
        public string MyXml
        {
            get
            {
                if (strXML == null || strXML.Trim() == string.Empty)
                {
                    return Resources.defaultXml;
                }
                return strXML;
            }
            set { strXML = value; }
        }

        [Category("Custom Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyName("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [Browsable(false)]
        public string MyRollupSites
        {
            get
            {
                if (strRollupSites == null || strRollupSites.Trim() == string.Empty)
                {
                    return string.Empty;
                }
                return strRollupSites;
            }
            set { strRollupSites = value; }
        }

        public override string Title
        {
            get { return title; }
            set
            {
                title = value;
                base.Title = value;
            }
        }

        public void processItem(XmlNode ndItem)
        {
            var icon = string.Empty;
            int count;
            var id = string.Empty;
            try
            {
                icon = ndItem.Attributes["Icon"].Value;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception suppressed {0}", ex);
            }
            try
            {
                id = ndItem.Attributes["ID"].Value;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception suppressed {0}", ex);
            }

            count = (int)hshCounts[id];

            sb.Append("<tr>");
            sb.Append(
                icon != string.Empty
                    ? $"<td nowrap=\"nowrap\" width=\"27\"><img src=\"{icon}\" alt=\"\" style=\"border-width:0px;\" /></td>"
                    : "<td nowrap=\"nowrap\" width=\"27\"></td>");

            processDisplay(ndItem.SelectSingleNode("Displays"), count);

            sb.Append("</tr>");
        }

        public override ToolPart[] GetToolParts()
        {
            var toolParts = new ToolPart[3];
            toolParts[0] = new WebPartToolPart();
            toolParts[1] = new CustomPropertyToolPart();

            //Create a custom toolpart
            toolParts[2] = new SummaryRollupToolpart();

            return toolParts;
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            try
            {
                var act = new Act(SPContext.Current.Web);
                var activation = act.CheckFeatureLicense(ActFeature.WebParts);

                if (activation != 0)
                {
                    output.Write(act.translateStatus(activation));
                    return;
                }

                OpenConnectionWithPriviligedAccess();

                arrSites = new SortedList();

                var duplicateFound = false;

                web = SPContext.Current.Web;

                var doc = new XmlDocument();

                try
                {
                    doc.LoadXml(MyXml);
                    ProcesNodes(doc, ref duplicateFound);

                    ProcessWeb();

                    foreach (XmlNode xmlNode in doc.SelectSingleNode("Sections"))
                    {
                        processSection(xmlNode);
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                    if (ex.Message.IndexOf("Root element is missing") > -1
                        || ex.Message.IndexOf("Value cannot be null") > -1)
                    {
                        output.Write("This webpart XML is Missing.");
                    }
                    else
                    {
                        output.Write($"Failed to load XML: {ex.Message}");
                    }
                    return;
                }
                if (duplicateFound)
                {
                    output.Write("Warning: Duplicate Item ID's Found");
                }

                output.Write("<table cellpadding=\"1\" cellspacing=\"1\" style=\"margin:10px;\" class=\"ms-stdtxt\">");
                output.Write(sb.ToString());
                output.Write("</table>");
            }
            finally
            {
                cn?.Close();
            }
        }

        private void ProcessWeb()
        {
            if (strRollupSites == null || strRollupSites.Length <= 0)
            {
                processWeb(web);
            }
            else
            {
                foreach (var rollupSite in strRollupSites.Split('\n'))
                {
                    try
                    {
                        if (string.Equals(web.Url, rollupSite, StringComparison.OrdinalIgnoreCase))
                        {
                            processWeb(web);
                        }
                        else
                        {
                            using (var spSite = new SPSite(rollupSite))
                            using (var spWeb = spSite.OpenWeb())
                            {
                                processWeb(spWeb);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                    }
                }
            }
        }
    }
}