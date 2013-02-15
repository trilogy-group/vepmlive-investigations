using System;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class Customfields_NAX : LayoutsPageBase
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
            table1.AddColumn("Entity", "", "width:6em;");
            table1.AddColumn("Name", "", "width:12em;");
            table1.AddColumn("Desc", "", "width:20em;");
            table1.AddColumn("Data Type", "", "width:6em;");
            table1.AddColumn("Lookup", "", "width:10em;");
            table1.AddColumn("Table", "", "width:10em;");
            table1.AddColumn("Field", "");
            table1.AddColumn("", "");

            string sDBConnect = WebAdmin.GetConnectionString(this.Context);
            DBAccess dba = new DBAccess(sDBConnect);
            if (dba.Open() != StatusEnum.rsSuccess) goto Status_Error;

            DataTable dt;
            string cmdText = "SELECT FA_FIELD_ID,FA_NAME,FA_FORMAT,FA_TABLE_ID,FA_FIELD_IN_TABLE,FA_DESC,"
                            + " case When (FA_TABLE_ID >100 And FA_TABLE_ID<200) Then 2 When (FA_TABLE_ID >200 And FA_TABLE_ID<300) Then 1 Else 0 End as Entity"
                            + " FROM EPGC_FIELD_ATTRIBS"
                            + " Where FA_TABLE_ID > 100 and FA_TABLE_ID < 300"
                            + " ORDER BY Entity,FA_NAME";
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
                table1.AddRow(row["FA_FIELD_ID"].ToString());
                table1.AddValue("");
                int lEntity = DBAccess.ReadIntValue(row["Entity"]);
                string sEntity = "";
                if (lEntity == 1) sEntity = "Portfolio"; else sEntity = "Resource";
                table1.AddValue(sEntity);
                table1.AddValue(row["FA_NAME"].ToString());
                table1.AddValue(row["FA_DESC"].ToString());

                int lDataType = DBAccess.ReadIntValue(row["FA_FORMAT"]);
                table1.AddValue(EPKClass01.GetFieldFormat(lDataType));

                table1.AddValue("");  //lookup

                string sTable;
                string sField;
                int lTable = DBAccess.ReadIntValue(row["FA_TABLE_ID"]);
                int lField = DBAccess.ReadIntValue(row["FA_FIELD_IN_TABLE"]);
                if (EPKClass01.GetTableAndField(lTable, lField, out sTable, out sField))
                {
                    table1.AddValue(sTable);
                    table1.AddValue(sField);
                }
                else
                {
                    table1.AddValue("Unknown Table");
                    table1.AddValue("");
                }
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
