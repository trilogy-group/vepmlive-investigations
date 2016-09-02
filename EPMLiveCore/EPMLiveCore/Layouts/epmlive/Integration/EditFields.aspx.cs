using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive.Integration
{
    public partial class EditFields : LayoutsPageBase
    {
        Guid ListId;

        protected void Page_Load(object sender, EventArgs e)
        {
            ListId = new Guid(Request["List"]);

            var dt = new DataTable();
            dt.Columns.Add("DisplayName");
            dt.Columns.Add("FieldType");
            dt.Columns.Add("InternalName");

            foreach (SPField fld in Web.Lists[ListId].Fields)
            {
                if (!fld.Sealed && (!fld.ReadOnlyField || fld.Type == SPFieldType.Calculated)
                    && fld.Type != SPFieldType.Attachments && fld.InternalName != "Order" &&
                    fld.Type != SPFieldType.File && fld.InternalName != "MetaInfo")
                {
                    dt.Rows.Add(new[] { fld.Title, fld.TypeShortDescription, fld.InternalName });
                }
            }

            dt.DefaultView.Sort = "DisplayName ASC";

            GvFields.DataSource = dt;
            GvFields.DataBind();
        }

        protected void GvFields_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            string sFieldDisplayName = DataBinder.Eval(e.Row.DataItem, "DisplayName").ToString();
            string sFieldInternalName = DataBinder.Eval(e.Row.DataItem, "InternalName").ToString();
            string sFieldType = DataBinder.Eval(e.Row.DataItem, "FieldType").ToString();
            string sLink = "<a href=\"#\" onclick=\"pageRedir('" + SPContext.Current.Web.Url +
                           "/_layouts/FldEdit.aspx?source="
                           + HttpUtility.UrlEncode(HttpContext.Current.Request.RawUrl) + "&List=" +
                           ListId + "&Field="
                           + HttpUtility.HtmlDecode(sFieldInternalName) + "')\" >" + sFieldDisplayName + "</a>";
            e.Row.Cells[0].Text = HttpUtility.HtmlDecode(sLink);
            e.Row.Cells[1].Text = HttpUtility.HtmlDecode(sFieldType);
        }
    }
}
