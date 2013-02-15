using System;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class grouppermissions_NAX : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //buttonbar1.EventHandler("buttonbar1_event");
            //buttonbar1.AddButton("btnAdd", "<u>A</u>dd", "", "", "alt text", "3em", "a", false);
            //buttonbar1.AddButton("btnUpdate", "<u>M</u>odify", "", "", "alt text", "4em", "u", true);
            //buttonbar1.AddButton("btnDelete", "<u>D</u>elete", "", "images/delete.gif", "alt text", "5em", "d", true);
            //buttonbar1.Render();

            table1.RowEventHandler("table1_row_event");
            table1.AddColumn("", "cellSpacer");
            table1.AddColumn("Name", "", "width:12em;");
            table1.AddColumn("Desc", "", "width:20em;");
            table1.AddColumn("", "");

            string sDBConnect = WebAdmin.GetConnectionString(this.Context);
            DBAccess dba = new DBAccess(sDBConnect);
            if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;

            DataTable dt;
            string cmdText = "SELECT * FROM EPG_GROUPS Where GROUP_ENTITY=1 ORDER BY GROUP_NAME";
            dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand(cmdText, dba.Connection, dba.Transaction);
                SqlDataReader reader = cmd.ExecuteReader();

                dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch (Exception ex)
            {
                //eStatus = HandleStatusError(SeverityEnum.Exception, "SelectData", (StatusEnum)eStatusOnException, ex.Message.ToString());
            }
            //            if (dbaUsers.SelectCustomFields(dba, out dt) != StatusEnum.rsSuccess) goto Status_Error;

            foreach (DataRow row in dt.Rows)
            {
                table1.AddRow(row["GROUP_ID"].ToString());
                table1.AddValue("");
                table1.AddValue(row["GROUP_NAME"].ToString());
                table1.AddValue(row["GROUP_NOTES"].ToString());

                table1.AddValue("");
            }
            dba.Close();
            table1.Render();
            return;
        Status_Error:
            //dba.Close();
            //table1.Render();
            //lblGeneralError.Text = dba.FormatErrorText();
            //lblGeneralError.Visible = true;
            return;
        }
    }
}
