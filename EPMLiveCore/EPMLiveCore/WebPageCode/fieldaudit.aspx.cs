using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;
using System.Drawing;
using System.IO;
using System.Text;

namespace EPMLiveCore
{
    public partial class fieldaudit : System.Web.UI.Page
    {
        protected DataGrid GvItems;
        DataTable dt = new DataTable();
        string lists = "";
        SPList mainList;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            dt.Columns.Add("Web");
            dt.Columns.Add("List Name");

            SPWeb web = SPContext.Current.Web;
            {
                web.Site.CatchAccessDeniedException = false;
                mainList = web.Lists[new Guid(Request["List"])];

                GridGanttSettings gSettings = new GridGanttSettings(mainList);

                lists = gSettings.RollupLists;
                

                if (lists != "")
                {
                    foreach (SPField field in mainList.Fields)
                    {
                        if(!field.Hidden && field.Type != SPFieldType.Computed)
                            dt.Columns.Add(field.InternalName);
                    }

                    processList(web, mainList.Title, "");
                    processWeb(web, "");

                    foreach (SPField field in mainList.Fields)
                    {
                        if(dt.Columns.Contains(field.InternalName))
                            dt.Columns[field.InternalName].ColumnName = "<div nowrap>" + field.Title + "</div>";
                    }
                }
            }
            DataView dvData = new DataView(dt);
            dvData.Sort = "List Name";

            GvItems.DataSource = dvData;
            GvItems.DataBind();

        }

        private void processList(SPWeb web, string listname, string spaces)
        {
            SPList sList = web.Lists[listname];
            string[] dataRow = new string[dt.Columns.Count];

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == "Web")
                {
                    dataRow[i] = spaces + "<a href=\"" + web.Url + "\" target=\"_blank\">" + web.Title + "</a>";
                }
                else if (dt.Columns[i].ColumnName == "List Name")
                {
                    dataRow[i] = listname;
                }
                else
                {
                    try
                    {
                        SPField f = sList.Fields.GetFieldByInternalName(dt.Columns[i].ColumnName);
                        SPField mf = mainList.Fields.GetFieldByInternalName(dt.Columns[i].ColumnName);

                        if (f.TypeAsString != mf.TypeAsString)
                            dataRow[i] = "<font color=\"red\"><b>" + f.TypeAsString + "</b></font>";
                        else
                            dataRow[i] = f.TypeAsString;
                    }
                    catch { }
                }
                if (sList.ID == mainList.ID)
                    dataRow[i] = "<font color=\"green\"><b>" + dataRow[i] + "</b></font>";
                dataRow[i] = "<div nowrap>" + dataRow[i] + "</div>";
            }
            dt.Rows.Add(dataRow);
        }

        private void processWeb(SPWeb web, string spaces)
        {
            foreach(string listinfo in lists.Split(','))
            {
                string list = listinfo.Split('|')[0];
                try
                {
                    if(list != mainList.Title || web.ID != mainList.ParentWeb.ID)
                        processList(web, list, spaces);
                }
                catch { }
            }
            foreach (SPWeb w in web.Webs)
            {
                try
                {
                    processWeb(w, spaces + "&nbsp;&nbsp;&nbsp;&nbsp;");
                }
                catch { }
                w.Close();
            }
        }
        
    }
}
