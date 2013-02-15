using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorkEnginePPM.ControlTemplates.WorkEnginePPM
{
    public partial class Table : System.Web.UI.UserControl
    {

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
        }
    }
}