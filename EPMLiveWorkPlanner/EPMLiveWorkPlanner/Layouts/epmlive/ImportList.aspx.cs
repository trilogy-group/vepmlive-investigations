using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;
using System.Xml;
using System.Data.SqlClient;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    public partial class ImportList : LayoutsPageBase
    {
        private DataTable dtCols = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                foreach(SPList list in Web.Lists)
                {
                    if(!list.Hidden)
                    {
                        ddlList.Items.Add(new ListItem(list.Title, list.ID.ToString()));
                    }
                }
            }
        }

        protected void gvColumns_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlCol = (DropDownList)e.Row.FindControl("ddlPlannerField");

                foreach(DataRow dr in dtCols.Rows)
                {
                    if(dr["InternalName"].ToString() == e.Row.Cells[0].Text)
                    {
                        ListItem li = new ListItem(dr["DisplayName"].ToString(), dr["InternalName"].ToString());
                        li.Selected = true;
                        ddlCol.Items.Add(li);
                    }
                    else
                        ddlCol.Items.Add(new ListItem(dr["DisplayName"].ToString(), dr["InternalName"].ToString()));
                }
            }
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Import><Columns></Columns></Import>");

            XmlAttribute attr = doc.CreateAttribute("AttachedItemsOnly");
            attr.Value = chkLinkedItems.Checked.ToString();
            doc.FirstChild.Attributes.Append(attr);

            attr = doc.CreateAttribute("List");
            attr.Value = ddlList.SelectedItem.Text;
            doc.FirstChild.Attributes.Append(attr);

            attr = doc.CreateAttribute("ResourceField");
            attr.Value = "ID";
            doc.FirstChild.Attributes.Append(attr);
            
            XmlNode ndCols = doc.FirstChild.SelectSingleNode("//Columns");

            foreach(GridViewRow r in gvColumns.Rows)
            {

                DropDownList ddl = (DropDownList)r.FindControl("ddlPlannerField");

                if(ddl.SelectedValue != "")
                {
                    XmlNode ndNew = doc.CreateNode(XmlNodeType.Element, "Column", doc.NamespaceURI);

                    attr = doc.CreateAttribute("ListField");
                    attr.Value = r.Cells[0].Text;
                    ndNew.Attributes.Append(attr);

                    attr = doc.CreateAttribute("PlannerField");
                    attr.Value = ddl.SelectedValue;
                    ndNew.Attributes.Append(attr);

                    ndCols.AppendChild(ndNew);
                }

            }

            SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(base.Site.WebApplication.Id));

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn.Open();
            });

            WorkPlannerAPI.PlannerProps props = WorkPlannerAPI.getSettings(base.Web, Request["PlannerId"]);

            SPList tList = base.Web.Lists.TryGetList(props.sListProjectCenter);

            Guid tJob = Guid.NewGuid();

            SqlCommand cmd = new SqlCommand("INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname,  scheduletype, webguid, listguid, itemid, jobdata, [key]) VALUES (@timerjobuid, @siteguid, 21, 'Import List', 0, @webguid, @listguid, @itemid, @jobdata, @key)", cn);
            cmd.Parameters.AddWithValue("@siteguid", base.Site.ID.ToString());
            cmd.Parameters.AddWithValue("@webguid", base.Web.ID);
            cmd.Parameters.AddWithValue("@listguid", tList.ID);
            cmd.Parameters.AddWithValue("@itemid", Request["ID"]);
            cmd.Parameters.AddWithValue("@jobdata", doc.FirstChild.OuterXml);
            cmd.Parameters.AddWithValue("@timerjobuid", tJob);
            cmd.Parameters.AddWithValue("@key", Request["PlannerID"]);
            cmd.ExecuteNonQuery();

            cn.Close();

            EPMLiveCore.CoreFunctions.enqueue(tJob, 0);

            Response.Redirect("ImportExcelFinish.aspx?isdlg=1&jobuid=" + tJob);

        }

        protected void btnList_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("ListField");
            dt.Columns.Add("ListFieldTitle");

            SPList list = base.Web.Lists[new Guid(ddlList.SelectedValue)];

            foreach(SPField field in list.Fields)
            {
                if(field.Reorderable)
                {
                    if(field.InternalName == "WBS")
                    {
                        ddlWBS.ClearSelection();
                        ListItem li = new ListItem(field.Title, field.InternalName);
                        li.Selected = true;
                        ddlWBS.Items.Add(li);
                    }
                    else
                        ddlWBS.Items.Add(new ListItem(field.Title, field.InternalName));

                    dt.Rows.Add(new object[] { field.InternalName, field.Title });
                }
            }

            dtCols.Columns.Add("InternalName");
            dtCols.Columns.Add("DisplayName");

            WorkPlannerAPI.PlannerProps props = WorkPlannerAPI.getSettings(base.Web, Request["PlannerID"]);

            SPList oTaskList = Web.Lists.TryGetList(props.sListTaskCenter);
            SortedList sl = new SortedList();
            foreach(SPField field in oTaskList.Fields)
            {
                if(field.Reorderable && !field.ReadOnlyField)
                {
                    sl.Add(field.Title, field.InternalName);
                }
            }

            foreach(DictionaryEntry de in sl)
            {
                dtCols.Rows.Add(new object[] { de.Value, de.Key });
            }

            gvColumns.DataSource = dt;
            gvColumns.DataBind();

            gvColumns.Columns[0].Visible = false;

            pnlCols.Visible = true;
            pnlList.Visible = false;

        }
    }
}
