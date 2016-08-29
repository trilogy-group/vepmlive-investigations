using System;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Serialization;
using System.Web.Services.Protocols;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using System.Net;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EPMLiveWebParts.SSRS2006;
using EPMLiveWebParts.SSRS2005;
using System.Web.UI.HtmlControls;
using System.Reflection;
using Microsoft.SharePoint.Administration;
using System.Collections.Generic;

namespace EPMLiveWebParts
{
    [Guid("9237c225-fcc1-4571-9233-5a1e8c2e7019"), XmlRoot(Namespace = "ReportViewerWebPart")]
    public class ReportViewerSingle : Microsoft.SharePoint.WebPartPages.WebPart
    {
        Microsoft.Reporting.WebForms.ReportViewer rv;

        //protected override void Render(HtmlTextWriter writer)
        //{


        //    rv.RenderControl(writer);
        //}


        //protected DropDownList ddl;
        //string url = "";
        string ReportingServicesURL = "";

        bool Integrated;

        bool? bUseDefaults;
        //bool bIsTopList;
        bool bIsIntegratedMode;
        string strSRSUrl;
        string strReportsPath = "";
        //string currFolder = "";
        //int iDeepestFolderLevel = 1;

        string error = "";

        public ReportViewerSingle()
        {
            this.ExportMode = WebPartExportMode.All;
        }

        [Category("Reporting Properties")]
        [DefaultValue("")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Report Path")]
        [Description("")]
        [Browsable(true)]
        [XmlElement(ElementName = "PropReportPath")]
        // The accessor for this property.
        public string PropReportPath
        {
            get
            {
                if (strReportsPath == null)
                    return "";
                return strReportsPath;
            }
            set
            {
                strReportsPath = value;
            }
        }

        [Category("Reporting Properties")]
        [DefaultValue(false)]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Use Application Defaults")]
        [Description("")]
        [Browsable(true)]
        [XmlElement(ElementName = "UseDefaults")]
        // The accessor for this property.
        public bool UseDefaults
        {
            get
            {
                if (bUseDefaults == null)
                {
                    return true;
                }
                else
                    return bUseDefaults.Value;
            }
            set
            {
                bUseDefaults = value;
            }
        }

        [Category("Reporting Properties")]
        [DefaultValue("")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("SQL Reporting Services URL")]
        [Description("")]
        [Browsable(true)]
        [XmlElement(ElementName = "PropSRSUrl")]
        // The accessor for this property.
        public string PropSRSUrl
        {
            get
            {
                if (strSRSUrl == null)
                    return "";
                return strSRSUrl;
            }
            set
            {
                strSRSUrl = value;
            }
        }

        [Category("Reporting Properties")]
        [DefaultValue(false)]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Integrated Mode")]
        [Description("")]
        [Browsable(true)]
        [XmlElement(ElementName = "IsIntegratedMode")]
        // The accessor for this property.
        public bool IsIntegratedMode
        {
            get
            {
                return bIsIntegratedMode;
            }
            set
            {
                bIsIntegratedMode = value;
            }
        }

        protected override void CreateChildControls()
        {
            
            rv = new Microsoft.Reporting.WebForms.ReportViewer();
            SPWeb rootWeb = SPContext.Current.Site.RootWeb;
            if (UseDefaults)
            {
                ReportingServicesURL = EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportingServicesURL");

                try
                {
                    Integrated = bool.Parse(EPMLiveCore.CoreFunctions.getWebAppSetting(SPContext.Current.Site.WebApplication.Id, "ReportsUseIntegrated"));
                }
                catch { }
            }
            else
            {
                ReportingServicesURL = PropSRSUrl;
                Integrated = IsIntegratedMode;
            }             
            if (string.IsNullOrEmpty(PropReportPath))
            {
                error = "Report Path has not been set. Please configure the Report Path.";
            }
            else if (ReportingServicesURL == null || ReportingServicesURL == "")
            {
                error = "ReportingServicesURL has not been set.";
            }
            else if (Integrated && !(rootWeb.GetFile(rootWeb.Url + "/Report Library" + PropReportPath + ".rdl").Exists))
            {
                error = "Please configure the correct Report Path.";
            }
            else
            {
               try
                {
                    rv.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                    rv.ServerReport.ReportServerUrl = new Uri(ReportingServicesURL);
                    if(Integrated)
                        rv.ServerReport.ReportPath = rootWeb.Url + "/Report Library" + PropReportPath + ".rdl";
                    else
                        rv.ServerReport.ReportPath = PropReportPath;
                    rv.ShowToolBar = true;
                    rv.SizeToReportContent = true;
                    rv.EnableTheming = true;
                    rv.CssClass = "ms-toolbar";
                    rv.EnableTheming = true;
                    rv.Width = new Unit(59, UnitType.Percentage);
                    rv.ControlStyle.Width = new Unit(79, UnitType.Percentage);

                    Microsoft.Reporting.WebForms.ReportParameterInfoCollection rpic = rv.ServerReport.GetParameters();

                    List<Microsoft.Reporting.WebForms.ReportParameter> arrParams = new List<Microsoft.Reporting.WebForms.ReportParameter>();

                    foreach (Microsoft.Reporting.WebForms.ReportParameterInfo rpi in rpic)
                    {
                        if (rpi.Prompt == "")
                        {
                            switch (rpi.Name)
                            {
                                case "URL":
                                    Microsoft.Reporting.WebForms.ReportParameter rp = new Microsoft.Reporting.WebForms.ReportParameter(rpi.Name, HttpUtility.UrlEncode(SPContext.Current.Web.ServerRelativeUrl));
                                    arrParams.Add(rp);
                                    break;
                                case "SiteId":
                                    Microsoft.Reporting.WebForms.ReportParameter rp1 = new Microsoft.Reporting.WebForms.ReportParameter(rpi.Name, SPContext.Current.Site.ID.ToString());
                                    arrParams.Add(rp1);
                                    break;
                                case "WebId":
                                    Microsoft.Reporting.WebForms.ReportParameter rp2 = new Microsoft.Reporting.WebForms.ReportParameter(rpi.Name, SPContext.Current.Web.ID.ToString());
                                    arrParams.Add(rp2);
                                    break;
                                case "UserId":
                                    Microsoft.Reporting.WebForms.ReportParameter rp3 = new Microsoft.Reporting.WebForms.ReportParameter(rpi.Name, SPContext.Current.Web.CurrentUser.ID.ToString());
                                    arrParams.Add(rp3);
                                    break;
                                case "Username":
                                    Microsoft.Reporting.WebForms.ReportParameter rp4 = new Microsoft.Reporting.WebForms.ReportParameter(rpi.Name, HttpContext.Current.User.Identity.Name);
                                    arrParams.Add(rp4);
                                    break;

                            }
                        }
                    }
                    if (arrParams.Count > 0)
                        rv.ServerReport.SetParameters(arrParams);
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }

            }

            Controls.Add(rv);
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(SPContext.Current.Web);
            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.MyWork);

            if (activation != 0)
            {
                output.Write(act.translateStatus(activation));
                return;
            }

            if (error != "")
                output.Write(error);
            else
            {
                rv.RenderControl(output);
                output.WriteLine("<script language=\"javascript\">document.getElementById('" + rv.ClientID + "_fixedTable').style.width='100%';</script>");
            }


        }
    }
}
