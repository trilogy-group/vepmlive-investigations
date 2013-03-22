using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Xml;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    public partial class ImportCsv : LayoutsPageBase
    {
        private DataTable dtCols = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddlUID.Attributes.Add("OnChange", "CheckEXTID()");
            }
        }

        protected void gvColumns_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlCol = (DropDownList)e.Row.FindControl("ddlPlannerField");

                foreach(DataRow dr in dtCols.Rows)
                {
                    if(dr["InternalName"].ToString() == e.Row.Cells[0].Text || dr["DisplayName"].ToString() == e.Row.Cells[0].Text)
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

            XmlAttribute attr = doc.CreateAttribute("FileName");
            attr.Value = System.IO.Path.GetFileName(hdnFilename.Value);
            doc.FirstChild.Attributes.Append(attr);

            attr = doc.CreateAttribute("AllowDuplicateRows");
            attr.Value = (!chkNoDuplicates.Checked).ToString();
            doc.FirstChild.Attributes.Append(attr);

            attr = doc.CreateAttribute("Seperator");
            attr.Value = ddlSep.SelectedValue;
            doc.FirstChild.Attributes.Append(attr);

            XmlNode ndCols = doc.FirstChild.SelectSingleNode("//Columns");

            foreach(GridViewRow r in gvColumns.Rows)
            {

                DropDownList ddl = (DropDownList)r.FindControl("ddlPlannerField");

                if(ddl.SelectedValue != "")
                {
                    XmlNode ndNew = doc.CreateNode(XmlNodeType.Element, "Column", doc.NamespaceURI);

                    attr = doc.CreateAttribute("ImportField");
                    attr.Value = r.Cells[0].Text;
                    ndNew.Attributes.Append(attr);

                    attr = doc.CreateAttribute("PlannerField");
                    attr.Value = ddl.SelectedValue;
                    ndNew.Attributes.Append(attr);

                    ndCols.AppendChild(ndNew);
                }

            }

            //string newpath = Path.GetDirectoryName(hdnFilename.Value) + "\\IMPORT\\" + Path.GetFileName(hdnFilename.Value);

            SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(base.Site.WebApplication.Id));

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn.Open();
            });

            WorkPlannerAPI.PlannerProps props = WorkPlannerAPI.getSettings(base.Web, Request["PlannerId"]);

            SPList tList = base.Web.Lists.TryGetList(props.sListProjectCenter);

            Guid tJob = Guid.NewGuid();
                
            SqlCommand cmd = new SqlCommand("INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname,  scheduletype, webguid, listguid, itemid, jobdata, [key]) VALUES (@timerjobuid, @siteguid, 22, 'Import Csv', 0, @webguid, @listguid, @itemid, @jobdata, @key)", cn);
            cmd.Parameters.AddWithValue("@siteguid", base.Site.ID.ToString());
            cmd.Parameters.AddWithValue("@webguid", base.Web.ID);
            cmd.Parameters.AddWithValue("@listguid", tList.ID);
            cmd.Parameters.AddWithValue("@itemid", Request["ID"]);
            cmd.Parameters.AddWithValue("@jobdata", doc.FirstChild.OuterXml);
            cmd.Parameters.AddWithValue("@timerjobuid", tJob);
            cmd.Parameters.AddWithValue("@key", Request["PlannerID"]);
            cmd.ExecuteNonQuery();

            cn.Close();

            //SPSecurity.RunWithElevatedPrivileges(delegate()
            //{
            //    File.Move(hdnFilename.Value, newpath);
            //});
            EPMLiveCore.CoreFunctions.enqueue(tJob, 0);

            Response.Redirect("ImportExcelFinish.aspx?isdlg=1&jobuid=" + tJob);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string fName = FileUpload1.FileName ;
            string fNameExt = System.IO.Path.GetExtension(fName);
            if(fNameExt != ".txt" && fNameExt != ".csv" && fNameExt != ".tsv")
            {
                lblError.Visible = true;
                lblError.Text = "Invalid File. Must be txt, csv or tsv<br>";
            }
            else
            {
                lblError.Visible = false;
                pnlUpload.Visible = false;
                SPWeb  web = SPContext.Current.Web;

                //string sTempDir = EPMLiveCore.CoreFunctions.GetTempDirectory(web);
                //string filename = Guid.NewGuid().ToString("N") + fNameExt;
                //hdnFilename.Value = sTempDir + "\\" + filename;
                try
                {
                    //SPSecurity.RunWithElevatedPrivileges(delegate()
                    //{
                    //    FileUpload1.PostedFile.SaveAs(hdnFilename.Value);
                    //    FileUpload1.Dispose();
                    //});

                    byte[] buffer = EPMLiveCore.Infrastructure.EPMLiveFileStore.GetBytes(FileUpload1.PostedFile.InputStream);

                    using(var epmLiveFileStore = new EPMLiveCore.Infrastructure.EPMLiveFileStore(web))
                    {
                        hdnFilename.Value = epmLiveFileStore.Add(buffer, fNameExt);
                    }
                }
                catch(Exception ex)
                {
                    lblError.Visible = true;
                    pnlUpload.Visible = true;
                    lblError.Text = "Error Uploading: " + ex.Message;
                    return;
                }

                string firstLine = "";
                
                FileUpload1.PostedFile.InputStream.Position = 0;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    StreamReader sr = new StreamReader(FileUpload1.PostedFile.InputStream);
                    firstLine = sr.ReadLine();
                    sr.Close();
                });
                char seperator = ',';

                switch(ddlSep.SelectedValue)
                {
                    case "TSV":
                        seperator = '\t';
                        break;
                    case "CSV":
                        seperator = ',';
                        break;
                };

                string[] headers = firstLine.Split(seperator);

                DataTable dt = new DataTable();
                dt.Columns.Add("ImportField");

                foreach(string header in headers)
                {
                    dt.Rows.Add(new object[] { header });

                    if(header == "WBS")
                    {
                        ddlWBS.ClearSelection();
                        ListItem li = new ListItem(header);
                        li.Selected = true;
                        ddlWBS.Items.Add(li);
                    }
                    else
                        ddlWBS.Items.Add(header);

                    if(header == "EXTID")
                    {
                        ListItem li = new ListItem(header);
                        li.Selected = true;
                        ddlUID.Items.Add(li);
                    }
                    else
                        ddlUID.Items.Add(header);
                }

                dtCols.Columns.Add("InternalName");
                dtCols.Columns.Add("DisplayName");

                WorkPlannerAPI.PlannerProps props = WorkPlannerAPI.getSettings(base.Web, Request["PlannerID"]);

                SPList oTaskList = Web.Lists.TryGetList(props.sListTaskCenter);
                SortedList sl = new SortedList();
                foreach(SPField field in oTaskList.Fields)
                {
                    if(field.Reorderable)
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

                pnlColumns.Visible = true;
            }
        }
    }
}
