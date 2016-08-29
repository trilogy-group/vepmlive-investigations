using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;


namespace EPMLiveCore
{
    public partial class adminversions : System.Web.UI.Page
    {
        protected SPGridView GvItems;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Version");
            dt.Columns.Add("dtModified");

            string []v = getVersion("EPM Live Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
            if (v[0] != "")
            {
                dt.Rows.Add("Core", v[0], v[1]);
            }

            v = getVersion("EPMLiveWebParts, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
            if (v[0] != "")
            {
                dt.Rows.Add("WebParts", v[0], v[1]);
            }

            v = getVersion("EPMLiveWorkplanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
            if (v[0] != "")
            {
                dt.Rows.Add("WorkPlanner", v[0], v[1]);
            }

            v = getVersion("EPMLiveSynch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=3ef432eb7a3c56f7");
            if (v[0] != "")
            {
                dt.Rows.Add("Administration Synch", v[0], v[1]);
            }

            v = getVersion("TimeSheets, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
            if (v[0] != "")
            {
                dt.Rows.Add("Timesheets", v[0], v[1]);
            }

            v = getVersion("Dashboard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
            if (v[0] != "")
            {
                dt.Rows.Add("Dashboards", v[0], v[1]);
            }

            v = getVersion("GettingStarted, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
            if (v[0] != "")
            {
                dt.Rows.Add("Getting Started", v[0], v[1]);
            }

            v = getVersion("EPMLiveEnterprise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
            if (v[0] != "")
            {
                dt.Rows.Add("Enterprise Core", v[0], v[1]);
            }

            v = getVersion("EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050");
            if (v[0] != "")
            {
                dt.Rows.Add("Reporting", v[0], v[1]);
            }

            v = getVersion("PortfolioEngineCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
            if(v[0] != "")
            {
                dt.Rows.Add("PortfolioEngine Core", v[0], v[1]);
            }

            v = getVersion("WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
            if(v[0] != "")
            {
                dt.Rows.Add("PortfolioEngine SharePoint", v[0], v[1]);
            }

            v = getVersion("EPMLiveAgilePlanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=5b9080c111c219f0");
            if (v[0] != "")
            {
                dt.Rows.Add("Agile Planner", v[0], v[1]);
            }

            GvItems.DataSource = dt;
            GvItems.DataBind();


        }
        private string []getVersion(string assName)
        {
            try
            {
                System.Reflection.Assembly ass = System.Reflection.Assembly.Load(new System.Reflection.AssemblyName(assName));
                System.Reflection.AssemblyName assn = ass.GetName();
                string[] data = new string[2];
                data[0] =  System.Diagnostics.FileVersionInfo.GetVersionInfo(assn.CodeBase.Replace("file:///", "").Replace("/", "\\")).FileVersion;
                DateTime dt = System.IO.File.GetLastWriteTime(assn.CodeBase.Replace("file:///", "").Replace("/", "\\"));
                data[1] = dt.ToShortDateString() + " " + dt.ToShortTimeString();
                return data;
            }
            catch { }
            return new string[2] { "" ,""};
        }
    }
}