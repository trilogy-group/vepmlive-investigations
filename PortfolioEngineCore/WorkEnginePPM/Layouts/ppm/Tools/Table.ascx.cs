using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PortfolioEngineCore;

namespace WorkEnginePPM.ControlTemplates.WorkEnginePPM
{
    public partial class Table : System.Web.UI.UserControl
    {
        private DataTable m_dt = null;
        private string m_sTableInnerHtml = string.Empty;
        private string m_sRowEventHandler = "table1_row_event";

        private struct TCol
        {
            //public int Index;
            public string Title;
            public string ClassRoot;
            public string Style;
        }

        TCol[] m_cols = new TCol[20];
        int m_nActualCols = 0;
        int m_nCurrentCol = 0;
        int m_nCurrentRow = 0;

        private string m_sTableData = "";
        public string TableData
        {
            get { return m_sTableData; }
            set { m_sTableData = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void RowEventHandler(string sEventHandler)
        {
            m_sRowEventHandler = sEventHandler;
        }

        public int AddColumn(string sTitle, string sClassRoot)
        {
            m_cols[m_nActualCols].Title = sTitle;
            m_cols[m_nActualCols].ClassRoot = sClassRoot;
            m_nActualCols++;

            if (m_sTableInnerHtml == string.Empty)
                AddRow("h_" + this.ID);
            m_sTableInnerHtml += "<th>" + sTitle + "</th>";
            return m_nActualCols - 1;
        }

        public int AddColumn(string sTitle, string sClassRoot, string sStyle)
        {
            m_cols[m_nActualCols].Title = sTitle;
            m_cols[m_nActualCols].ClassRoot = sClassRoot;
            m_cols[m_nActualCols].Style = sStyle;
            m_nActualCols++;

            if (m_sTableInnerHtml == string.Empty)
                AddRow("h_" + this.ID);
            m_sTableInnerHtml += "<th>" + sTitle + "</th>";
            return m_nActualCols - 1;
        }

        public void AddRow(string sRowUID)
        {
            if (m_sTableInnerHtml != string.Empty)
                m_sTableInnerHtml += "</tr>";
            string sRowId = "r_" + sRowUID;
            m_sTableInnerHtml += "<tr id='" + sRowId + "' ";
            m_sTableInnerHtml += "onclick='javascript:" + m_sRowEventHandler + "(\"" + this.ID + "\", \"onclick\",\"" + sRowUID + "\")' ";
            m_sTableInnerHtml += "onmouseover='javascript:" + m_sRowEventHandler + "(\"" + this.ID + "\", \"onmouseover\",\"" + sRowUID + "\")' ";
            m_sTableInnerHtml += "onmouseout='javascript:" + m_sRowEventHandler + "(\"" + this.ID + "\", \"onmouseout\",\"" + sRowUID + "\")' ";
            m_sTableInnerHtml += ">";

            m_nCurrentRow++;
            m_nCurrentCol = 0;
        }

        public void AddValue(string sValue)
        {
            //if (m_sTableInnerHtml == string.Empty)
            //    AddRow();
            string sAttr = "";
            if (m_cols[m_nCurrentCol].ClassRoot != string.Empty)
                sAttr += " class='" + m_cols[m_nCurrentCol].ClassRoot + "'";
            if (m_cols[m_nCurrentCol].Style != string.Empty)
                sAttr += " style='" + m_cols[m_nCurrentCol].Style + "'";
            m_sTableInnerHtml += "<td" + sAttr + ">" + sValue + "</td>";
            m_nCurrentCol++;
        }

        public void Render()
        {
            if (m_sTableInnerHtml != string.Empty)
                m_sTableInnerHtml += "</tr>";
            LiteralControl lit = new LiteralControl(m_sTableInnerHtml);
            this.idTableBody.Controls.Add(lit);

            if (m_dt != null)
            {
        //private string m_sTableData = "<rows><head><column width=\"50\" type=\"ed\" sort=\"str\">Col one</column><column width=\"100\" type=\"ed\" sort=\"str\">Col two</column></head><row id=\"1\"><cell>blah</cell><cell>blee</cell></row><row id=\"2\"><cell>blah2</cell><cell>bloo</cell></row></rows>";

                CStruct rows = new CStruct();
                rows.Initialize("rows");
                CStruct head = rows.CreateSubStruct("head");
                foreach (DataColumn col in m_dt.Columns)
                {
                    CStruct column = head.CreateSubStruct("column");
                    column.CreateStringAttr("type", "ed");
                    column.CreateStringAttr("sort", "str");
                    column.CreateStringAttr("width", "140");
                    column.InnerText = col.Caption;
                }

                foreach (DataRow row in m_dt.Rows)
                {
                    CStruct xrow = rows.CreateSubStruct("row");
                    foreach (DataColumn col in m_dt.Columns)
                    {
                        xrow.CreateString("cell", DBAccess.ReadStringValue(row[col.ColumnName]));
                    }
                    
                    //table1.AddRow(row["FA_FIELD_ID"].ToString());
                    //table1.AddValue("");
                    //int lEntity = DBAccess.ReadIntValue(row["Entity"]);
                    //string sEntity = "";
                    //if (lEntity == 1) sEntity = "Portfolio"; else sEntity = "Resource";
                    //table1.AddValue(sEntity);
                    //table1.AddValue(row["FA_NAME"].ToString());
                    //table1.AddValue(row["FA_DESC"].ToString());

                    //int lDataType = DBAccess.ReadIntValue(row["FA_FORMAT"]);
                    //table1.AddValue(EPKClass01.GetFieldFormat(lDataType));

                    //table1.AddValue("");  //lookup

                    //string sTable;
                    //string sField;
                    //int lTable = DBAccess.ReadIntValue(row["FA_TABLE_ID"]);
                    //int lField = DBAccess.ReadIntValue(row["FA_FIELD_IN_TABLE"]);
                    //if (EPKClass01.GetTableAndField(lTable, lField, out sTable, out sField))
                    //{
                    //    table1.AddValue(sTable);
                    //    table1.AddValue(sField);
                    //}
                    //else
                    //{
                    //    table1.AddValue("Unknown Table");
                    //    table1.AddValue("");
                    //}
                    //table1.AddValue("");
                }
                m_sTableData = rows.XML();
            }

        }
        public void SetDataTable(DataTable dt)
        {
            m_dt = dt;
        }
    }
}