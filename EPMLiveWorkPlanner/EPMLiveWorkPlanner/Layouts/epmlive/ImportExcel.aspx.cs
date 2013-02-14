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
using Microsoft.SharePoint.Utilities;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    public partial class ImportExcel : LayoutsPageBase
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

        protected void btnSheet_Click(object sender, EventArgs e)
        {
            pnlSheet.Visible = false;
            
            var epmLiveFileStore = new EPMLiveCore.Infrastructure.EPMLiveFileStore(Web);

            using(SpreadsheetDocument myDoc = SpreadsheetDocument.Open(epmLiveFileStore.GetStream(hdnFilename.Value), false))
            {
                WorkbookPart workbookPart = myDoc.WorkbookPart;

                IEnumerable<Sheet> sheets = myDoc.WorkbookPart.Workbook.Descendants<Sheet>().Where(s => s.Name == ddlSheet.SelectedValue);
                if(sheets.Count() == 0)
                    return;

                WorksheetPart worksheetPart = (WorksheetPart)myDoc.WorkbookPart.GetPartById(sheets.First().Id);
                Worksheet worksheet = worksheetPart.Worksheet;
                SheetData oSheetData = worksheet.GetFirstChild<SheetData>();
                WorkbookStylesPart workbookStylesPart = myDoc.WorkbookPart.GetPartsOfType<WorkbookStylesPart>().First();
                CellFormats cellFormats = (CellFormats)workbookStylesPart.Stylesheet.CellFormats;

                IEnumerable<Row> rows = oSheetData.Descendants<Row>();

                DataTable dt = new DataTable();
                dt.Columns.Add("ExcelField");
                try
                {
                    foreach(Cell cell in rows.ElementAt(0))
                    {
                        string cellname = GetCellValue(myDoc, cell, cellFormats);

                        if(cellname == "WBS")
                        {
                            ddlWBS.ClearSelection();
                            ListItem li = new ListItem(cellname);
                            li.Selected = true;
                            ddlWBS.Items.Add(li);
                        }
                        else
                            ddlWBS.Items.Add(cellname);

                        if(cellname == "EXTID")
                        {
                            ListItem li = new ListItem(cellname);
                            li.Selected = true;
                            ddlUID.Items.Add(li);
                        }
                        else
                            ddlUID.Items.Add(cellname);

                        dt.Rows.Add(new object[] { cellname });
                    }
                }
                catch { }
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

        private string GetCellValue(SpreadsheetDocument document, Cell cell, CellFormats cellFormats)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;

            string value = cell.CellValue.InnerXml;

            try
            {
                if(cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                {
                    return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
                }
                else
                {
                    if(cell.DataType == null)
                    {
                        CellFormat cf = cellFormats.Descendants<CellFormat>().ElementAt<CellFormat>(Convert.ToInt32(cell.StyleIndex.Value));
                        if(cf.NumberFormatId >= 0 && cf.NumberFormatId <= 13)
                            return Convert.ToDecimal(value).ToString();
                        else if(cf.NumberFormatId >= 14 && cf.NumberFormatId <= 22)
                            return DateTime.FromOADate(Convert.ToDouble(value)).ToString("s");
                        else
                            return value;
                    }
                    else
                        return value;
                }
            }
            catch { return value; }

        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Import><Columns></Columns></Import>");

            XmlAttribute attr = doc.CreateAttribute("FileName");
            attr.Value = System.IO.Path.GetFileName(hdnFilename.Value);
            doc.FirstChild.Attributes.Append(attr);

            attr = doc.CreateAttribute("SheetId");
            attr.Value = ddlSheet.SelectedValue;
            doc.FirstChild.Attributes.Append(attr);

            attr = doc.CreateAttribute("Structure");
            attr.Value = ddlWBS.SelectedValue;
            doc.FirstChild.Attributes.Append(attr);

            attr = doc.CreateAttribute("AllowDuplicateRows");
            attr.Value = (!chkNoDuplicates.Checked).ToString();
            doc.FirstChild.Attributes.Append(attr);

            XmlNode ndCols = doc.FirstChild.SelectSingleNode("//Columns");

            foreach(GridViewRow r in gvColumns.Rows)
            {

                DropDownList ddl = (DropDownList)r.FindControl("ddlPlannerField");

                if(ddl.SelectedValue != "")
                {
                    XmlNode ndNew = doc.CreateNode(XmlNodeType.Element, "Column", doc.NamespaceURI);

                    attr = doc.CreateAttribute("ExcelField");
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
                
            SqlCommand cmd = new SqlCommand("INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname,  scheduletype, webguid, listguid, itemid, jobdata, [key]) VALUES (@timerjobuid, @siteguid, 20, 'Import XLS', 0, @webguid, @listguid, @itemid, @jobdata, @key)", cn);
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

            Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/ImportExcelFinish.aspx?isdlg=1&jobuid=" + tJob, SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);
        }

        

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string fName = FileUpload1.FileName ;
            string fNameExt = System.IO.Path.GetExtension(fName);
            if(fNameExt != ".xls" && fNameExt != ".xlsx")
            {
                lblError.Visible = true;
                lblError.Text = "Invalid File. Must be xls or xlsx<br>";
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
                    byte[] buffer = EPMLiveCore.Infrastructure.EPMLiveFileStore.GetBytes(FileUpload1.PostedFile.InputStream);

                    //FileUpload1.PostedFile.InputStream.Read(buffer, 0, (int)FileUpload1.PostedFile.InputStream.Length);

                    using(var epmLiveFileStore = new EPMLiveCore.Infrastructure.EPMLiveFileStore(web))
                    {
                        hdnFilename.Value = epmLiveFileStore.Add(buffer, fNameExt);
                    }
                    //SPSecurity.RunWithElevatedPrivileges(delegate()
                    //{
                    //    FileUpload1.PostedFile.SaveAs(hdnFilename.Value);
                    //});
                }
                catch(Exception ex)
                {
                    lblError.Visible = true;
                    pnlUpload.Visible = true;
                    lblError.Text = "Error Uploading: " + ex.Message;
                    return;
                }

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using(SpreadsheetDocument myDoc = SpreadsheetDocument.Open(FileUpload1.PostedFile.InputStream, false))
                    {
                        WorkbookPart workbookPart = myDoc.WorkbookPart;

                        ddlSheet.Items.Clear();

                        IEnumerable<Sheet> sheets = myDoc.WorkbookPart.Workbook.Descendants<Sheet>();
                        foreach(Sheet sheet in sheets)
                        {
                            ddlSheet.Items.Add(sheet.Name);
                        }
                    }
                });

                pnlSheet.Visible = true;
            }
        }
    }
}
