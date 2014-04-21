using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Text;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class totalfields : LayoutsPageBase
    {
        protected Panel pnlFields;
        private SortedList<string, SPField> displayableFields = new SortedList<string, SPField>();

        public override string PageToRedirectOnCancel
        {
            get
            {
                return ((Web.ServerRelativeUrl == "/") ? "" : Web.ServerRelativeUrl) + "/_layouts/15/listedit.aspx?List=" + Request["List"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            {
                pnlFields.Controls.Add(new LiteralControl("<TABLE border=0 cellPadding=2 cellSpacing=0 width=300><TR><TD class=\"ms-authoringcontrols\" vAlign=top><P><B>Column Name</B></P></td><td>&nbsp;&nbsp;&nbsp;&nbsp;</td><TD class=\"ms-authoringcontrols\" noWrap vAlign=top width=\"138px\"><P><B>Total&nbsp;</B></P></TD></TR>"));

                SPList list = web.Lists[new Guid(Request.QueryString["List"])];

                foreach (SPField field in list.Fields)
                    if (!field.Hidden && (!field.ReadOnlyField || field.Type == SPFieldType.Calculated) && field.Type != SPFieldType.Attachments && field.InternalName != "ContentType")
                        displayableFields.Add(field.Title, field);

                foreach (SPField field in displayableFields.Values)
                {

                    pnlFields.Controls.Add(new LiteralControl("<tr><TD class=ms-authoringcontrols borderColor=#c0c0c0 width=\"100%\" nowrap>" + field.Title + "</td><td>&nbsp;&nbsp;&nbsp;&nbsp;</td><TD class=\"ms-authoringcontrols\" noWrap>"));

                    DropDownList ddlList = new DropDownList();
                    ddlList.ID = "ddl" + field.InternalName;
                    ddlList.Width = 120;

                    if (field.TypeAsString == "TotalRollup")
                    {
                        ddlList.Items.Add(new ListItem("None", ""));
                        ddlList.Items.Add(new ListItem("Count", "COUNT"));
                        ddlList.Items.Add(new ListItem("Sum", "SUM"));
                        ddlList.Items.Add(new ListItem("Average", "AVG"));
                        ddlList.Items.Add(new ListItem("Minimum", "MIN"));
                        ddlList.Items.Add(new ListItem("Maximum", "MAX"));
                    }
                    else
                    {
                        switch (field.Type)
                        {
                            case SPFieldType.Lookup:
                            case SPFieldType.Boolean:
                            case SPFieldType.Choice:
                            case SPFieldType.MultiChoice:
                            case SPFieldType.URL:
                            case SPFieldType.User:
                            case SPFieldType.Text:
                            case SPFieldType.Note:
                                ddlList.Items.Add(new ListItem("None", ""));
                                ddlList.Items.Add(new ListItem("Count", "COUNT"));
                                break;
                            case SPFieldType.Number:
                            case SPFieldType.Currency:
                                ddlList.Items.Add(new ListItem("None", ""));
                                ddlList.Items.Add(new ListItem("Count", "COUNT"));
                                ddlList.Items.Add(new ListItem("Sum", "SUM"));
                                ddlList.Items.Add(new ListItem("Average", "AVG"));
                                ddlList.Items.Add(new ListItem("Minimum", "MIN"));
                                ddlList.Items.Add(new ListItem("Maximum", "MAX"));
                                break;
                            case SPFieldType.DateTime:
                                ddlList.Items.Add(new ListItem("None", ""));
                                ddlList.Items.Add(new ListItem("Count", "COUNT"));
                                ddlList.Items.Add(new ListItem("Minimum", "MIN"));
                                ddlList.Items.Add(new ListItem("Maximum", "MAX"));
                                break;
                            case SPFieldType.Calculated:
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(field.SchemaXml);

                                string resulttype = "";
                                try
                                {
                                    resulttype = doc.FirstChild.Attributes["ResultType"].Value;
                                }
                                catch { }
                                switch (resulttype)
                                {
                                    case "Currency":
                                    case "Number":
                                        ddlList.Items.Add(new ListItem("None", ""));
                                        ddlList.Items.Add(new ListItem("Count", "COUNT"));
                                        ddlList.Items.Add(new ListItem("Sum", "SUM"));
                                        ddlList.Items.Add(new ListItem("Average", "AVG"));
                                        ddlList.Items.Add(new ListItem("Minimum", "MIN"));
                                        ddlList.Items.Add(new ListItem("Maximum", "MAX"));
                                        break;
                                    case "DateTime":
                                        ddlList.Items.Add(new ListItem("None", ""));
                                        ddlList.Items.Add(new ListItem("Count", "COUNT"));
                                        ddlList.Items.Add(new ListItem("Minimum", "MIN"));
                                        ddlList.Items.Add(new ListItem("Maximum", "MAX"));
                                        break;

                                    default:
                                        ddlList.Items.Add(new ListItem("None", ""));
                                        ddlList.Items.Add(new ListItem("Count", "COUNT"));
                                        break;
                                };

                                break;
                            default:
                                pnlFields.Controls.Add(new LiteralControl(field.TypeAsString));
                                break;
                        }
                    }

                    pnlFields.Controls.Add(ddlList);
                    pnlFields.Controls.Add(new LiteralControl("</td></tr>"));

                }
                pnlFields.Controls.Add(new LiteralControl("</table>"));

                if (!IsPostBack)
                {
                    Hashtable hshFields = new Hashtable();

                    GridGanttSettings gSettings = new GridGanttSettings(list);

                    //if (strTotals == "")
                    //    strTotals = CoreFunctions.getConfigSetting(web, "epmlivelisttotals-" + System.IO.Path.GetDirectoryName(list.DefaultView.Url));

                    if (gSettings.TotalSettings != "")
                    {
                        //string fieldTotals = web.Properties["epmlivelisttotals-" + System.IO.Path.GetDirectoryName(list.DefaultView.Url)];
                        string[] fieldList = gSettings.TotalSettings.Split('\n');
                        foreach (string field in fieldList)
                        {
                            if (field != "")
                            {
                                string[] fieldData = field.Split('|');
                                DropDownList ddl = (DropDownList)pnlFields.FindControl("ddl" + fieldData[0]);
                                if (ddl != null)
                                {
                                    ddl.SelectedValue = fieldData[1];
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            {
                StringBuilder sb = new StringBuilder();
                SPList list = web.Lists[new Guid(Request.QueryString["List"])];

                foreach (Control ctl in pnlFields.Controls)
                {
                    if (ctl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                    {
                        System.Web.UI.WebControls.DropDownList ddl = (System.Web.UI.WebControls.DropDownList)ctl;
                        if (ddl.SelectedValue != "")
                        {
                            sb.Append(ddl.ID.Substring(3) + "|" + ddl.SelectedValue + "\n");
                        }
                    }
                }

                //if (web.Properties.ContainsKey("epmlivelisttotals-" + System.IO.Path.GetDirectoryName(list.DefaultView.Url)))
                //    web.Properties["epmlivelisttotals-" + System.IO.Path.GetDirectoryName(list.DefaultView.Url)] = sb.ToString();
                //else
                //    web.Properties.Add("epmlivelisttotals-" + System.IO.Path.GetDirectoryName(list.DefaultView.Url), sb.ToString());

                //web.Properties.Update();
                //web.Update();

                GridGanttSettings gSettings = new GridGanttSettings(list);
                gSettings.TotalSettings = sb.ToString();
                gSettings.SaveSettings(list);

                //CoreFunctions.setListSetting(list, "TotalSettings", sb.ToString());

                Microsoft.SharePoint.Utilities.SPUtility.Redirect("listedit.aspx?List=" + list.ID.ToString(), Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
        }

    }
}
