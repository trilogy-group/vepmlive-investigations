using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using static System.Diagnostics.Trace;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class totalfields : LayoutsPageBase
    {
        protected Panel pnlFields;
        private SortedList<string, SPField> displayableFields = new SortedList<string, SPField>();

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                pnlFields?.Dispose();
                InputFormSection1?.Dispose();
                ButtonSection1?.Dispose();
                FormDigest1?.Dispose();
            }
        }

        /// <inheritdoc />
        public sealed override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public override string PageToRedirectOnCancel
        {
            get
            {
                return ((Web.ServerRelativeUrl == "/") ? "" : Web.ServerRelativeUrl) + "/_layouts/15/listedit.aspx?List=" + Request["List"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var web = SPContext.Current.Web;
            {
                pnlFields.Controls.Add(
                    new LiteralControl(
                        "<TABLE border=0 cellPadding=2 cellSpacing=0 width=300><TR><TD class=\"ms-authoringcontrols\" vAlign=top><P><B>Column Name</B></P></td><td>&nbsp;&nbsp;&nbsp;&nbsp;</td><TD class=\"ms-authoringcontrols\" noWrap vAlign=top width=\"138px\"><P><B>Total&nbsp;</B></P></TD></TR>"));

                var list = web.Lists[new Guid(Request.QueryString["List"])];

                GetFieldsToPopulate(list);
                PopulatePanelFields();
                HandleNoPostBack(list);
            }
        }

        private void GetFieldsToPopulate(SPList list)
        {
            foreach (SPField field in list.Fields)
            {
                if (!field.Hidden
                    && (!field.ReadOnlyField || field.Type == SPFieldType.Calculated)
                    && field.Type != SPFieldType.Attachments
                    && field.InternalName != "ContentType")
                {
                    displayableFields.Add(field.Title, field);
                }
            }
        }

        private void PopulatePanelFields()
        {
            foreach (var field in displayableFields.Values)
            {
                pnlFields.Controls.Add(
                    new LiteralControl(
                        $"<tr><TD class=ms-authoringcontrols borderColor=#c0c0c0 width=\"100%\" nowrap>{field.Title}</td><td>&nbsp;&nbsp;&nbsp;&nbsp;</td><TD class=\"ms-authoringcontrols\" noWrap>"));

                var dropDownList = new DropDownList
                {
                    ID = "ddl" + field.InternalName,
                    Width = 120
                };

                ProcessFieldType(field, dropDownList);

                pnlFields.Controls.Add(dropDownList);
                pnlFields.Controls.Add(new LiteralControl("</td></tr>"));
            }
            pnlFields.Controls.Add(new LiteralControl("</table>"));
        }

        private void ProcessFieldType(SPField field, DropDownList dropDownList)
        {
            if (field.TypeAsString == "TotalRollup")
            {
                ProcessTotalRollupFieldType(dropDownList);
            }
            else
            {
                ProcessOthersFieldTypes(field, dropDownList);
            }
        }

        private static void ProcessTotalRollupFieldType(DropDownList dropDownList)
        {
            dropDownList.Items.Add(new ListItem("None", string.Empty));
            dropDownList.Items.Add(new ListItem("Count", "COUNT"));
            dropDownList.Items.Add(new ListItem("Sum", "SUM"));
            dropDownList.Items.Add(new ListItem("Average", "AVG"));
            dropDownList.Items.Add(new ListItem("Minimum", "MIN"));
            dropDownList.Items.Add(new ListItem("Maximum", "MAX"));
        }

        private void ProcessOthersFieldTypes(SPField field, DropDownList dropDownList)
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
                    dropDownList.Items.Add(new ListItem("None", string.Empty));
                    dropDownList.Items.Add(new ListItem("Count", "COUNT"));
                    break;
                case SPFieldType.Number:
                case SPFieldType.Currency:
                    dropDownList.Items.Add(new ListItem("None", string.Empty));
                    dropDownList.Items.Add(new ListItem("Count", "COUNT"));
                    dropDownList.Items.Add(new ListItem("Sum", "SUM"));
                    dropDownList.Items.Add(new ListItem("Average", "AVG"));
                    dropDownList.Items.Add(new ListItem("Minimum", "MIN"));
                    dropDownList.Items.Add(new ListItem("Maximum", "MAX"));
                    break;
                case SPFieldType.DateTime:
                    dropDownList.Items.Add(new ListItem("None", string.Empty));
                    dropDownList.Items.Add(new ListItem("Count", "COUNT"));
                    dropDownList.Items.Add(new ListItem("Minimum", "MIN"));
                    dropDownList.Items.Add(new ListItem("Maximum", "MAX"));
                    break;
                case SPFieldType.Calculated:
                    var xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(field.SchemaXml);
                    ProcessResultType(xmlDocument, dropDownList);
                    break;
                default:
                    pnlFields.Controls.Add(new LiteralControl(field.TypeAsString));
                    break;
            }
        }

        private static void ProcessResultType(XmlDocument xmlDocument, DropDownList dropDownList)
        {
            var resultType = string.Empty;
            try
            {
                resultType = xmlDocument.FirstChild.Attributes["ResultType"].Value;
            }
            catch (Exception ex)
            {
                TraceError("Exception Suppressed {0}", ex);
            }
            switch (resultType)
            {
                case "Currency":
                case "Number":
                    dropDownList.Items.Add(new ListItem("None", string.Empty));
                    dropDownList.Items.Add(new ListItem("Count", "COUNT"));
                    dropDownList.Items.Add(new ListItem("Sum", "SUM"));
                    dropDownList.Items.Add(new ListItem("Average", "AVG"));
                    dropDownList.Items.Add(new ListItem("Minimum", "MIN"));
                    dropDownList.Items.Add(new ListItem("Maximum", "MAX"));
                    break;
                case "DateTime":
                    dropDownList.Items.Add(new ListItem("None", string.Empty));
                    dropDownList.Items.Add(new ListItem("Count", "COUNT"));
                    dropDownList.Items.Add(new ListItem("Minimum", "MIN"));
                    dropDownList.Items.Add(new ListItem("Maximum", "MAX"));
                    break;
                default:
                    dropDownList.Items.Add(new ListItem("None", string.Empty));
                    dropDownList.Items.Add(new ListItem("Count", "COUNT"));
                    break;
            }
        }

        private void HandleNoPostBack(SPList list)
        {
            if (!IsPostBack)
            {
                var gSettings = new GridGanttSettings(list);

                if (gSettings.TotalSettings != string.Empty)
                {
                    var fieldList = gSettings.TotalSettings.Split('\n');
                    foreach (var field in fieldList)
                    {
                        if (field != string.Empty)
                        {
                            var fieldData = field.Split('|');
                            var dropDownList = (DropDownList)pnlFields.FindControl($"ddl{fieldData[0]}");
                            if (dropDownList != null)
                            {
                                dropDownList.SelectedValue = fieldData[1];
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
