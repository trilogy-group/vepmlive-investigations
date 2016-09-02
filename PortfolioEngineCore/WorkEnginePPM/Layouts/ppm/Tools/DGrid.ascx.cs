using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PortfolioEngineCore;

namespace WorkEnginePPM
{
    public class _DGrid
    {
        private DataTable m_dt = null;
        private List<DCol> m_cols = new List<DCol>();

        private string m_sIDColName = "";

        public enum Align
        {
            left,
            right,
            center,
            justify
        }

        public enum Type
        {
            text,
            number,
            checkbox,
            calendar,
            combo
        }

        public class DCol
        {
            public string title;
            public Type type;
            public Align align;
            public int width;
            public string name;
            public bool editable;
            public bool hidden;
            public System.Collections.Generic.Dictionary<int,string> dicCombo = null;
            public void AddKeyValuePair(int key, string value)
            {
                if (dicCombo == null)
                    dicCombo = new Dictionary<int, string>();
                dicCombo.Add(key, value);
            }
        }

        public _DGrid.DCol AddColumn(string title, int width, Type type = Type.text, Align align = Align.left, string name = "", bool editable = false, bool isId = false, bool hidden = false)
        {
            DCol col = new DCol();
            col.title = title;
            col.type = type;
            col.align = align;
            col.width = width;
            if (name != "") col.name = name; else col.name = title;
            col.hidden = hidden;
            col.editable = editable;
            m_cols.Add(col);
            if (isId == true)
                m_sIDColName = col.name;
            return col;
        }
        public void SetDataTable(DataTable dt)
        {
            m_dt = dt;
        }
        public DataTable GetDataTable()
        {
            return m_dt;
        }
        public DataTable SetXmlData(string sgridData)
        {
            CStruct xRows = new CStruct();
            xRows.LoadXML(sgridData);

            DataTable dt = new DataTable();
            foreach (DCol col in m_cols)
            {
                DataColumn dc = dt.Columns.Add();
                switch (col.type)
                {
                    case _DGrid.Type.text:
                        dc.DataType = typeof(String);
                        break;
                    case _DGrid.Type.number:
                    //    dc.DataType = typeof(Decimal);
                    //    break;
                    //case _DGrid.Type.integer:
                        dc.DataType = typeof(Int32);
                        break;
                    //case _DGrid.Type.date:
                    //    dc.DataType = typeof(DateTime);
                    //    break;
                    case _DGrid.Type.checkbox:
                        dc.DataType = typeof(Int32);
                        break;
                    default:
                        dc.DataType = typeof(String);
                        break;
                }
                dc.ColumnName = col.name;
            }

            //CStruct xRows = xGrid.GetSubStruct("rows");
            List<CStruct> listRows = xRows.GetList("row");
            HandleRows(dt, listRows);

            m_dt = dt;
            return dt;
        }
        public void HandleRows(DataTable dt, List<CStruct> listRows)
        {
            foreach (CStruct xrow in listRows)
            {
                List<CStruct> listCells = xrow.GetList("cell");
                int index = 0;
                CStruct[] arrCells = listCells.ToArray();
                DataRow dr = dt.Rows.Add();
                foreach (DCol col in m_cols)
                {
                    CStruct xCell = arrCells[index++];
                    string sValue = xCell.InnerText;
                    switch (col.type)
                    {
                        case _DGrid.Type.text:
                            dr[col.name] = sValue;
                            break;
                        //case _DGrid.Type.integer:
                        case _DGrid.Type.number:
                            dr[col.name] = Int32.Parse(sValue);
                            break;
                        case _DGrid.Type.checkbox:
                            dr[col.name] = Int32.Parse(sValue);
                            break;
                        //case _DGrid.Type.number:
                        //    break;
                        //case _DGrid.Type.date:
                        //    DateTime date = DateTime.Parse(xI.GetStringAttr(col.name));
                        //    dr[col.name] = date;
                        //    break;
                        default:
                            dr[col.name] = sValue;
                            break;
                    }
                }
            }
        }
        public void Build(out string columnData, out string tableData)
        {
            columnData = "";
            tableData = "";
            if (this.m_dt != null)
            {
                if (m_cols.Count == 0)
                {
                    foreach (DataColumn col in m_dt.Columns)
                    {
                        AddColumn(title: col.ColumnName, width: 100, name: col.ColumnName, editable: true);
                    }
                }
                CStruct rows = new CStruct();
                rows.Initialize("rows");
                CStruct head = rows.CreateSubStruct("head");
                foreach (DCol col in m_cols)
                {
                    CStruct column = head.CreateSubStruct("column");
                    column.CreateStringAttr("name", col.name);
                    column.CreateIntAttr("width", col.width);
                    column.InnerText = col.title;
                    if (col.hidden)
                        column.CreateStringAttr("hidden", "true");
                    switch (col.type)
                    {
                        case Type.text:
                            if (col.editable) column.CreateStringAttr("type", "txt"); else column.CreateStringAttr("type", "rotxt");
                            column.CreateStringAttr("sort", "str");
                            break;
                        case Type.number:
                            if (col.editable) column.CreateStringAttr("type", "n"); else column.CreateStringAttr("type", "ron");
                            column.CreateStringAttr("sort", "int");
                            break;
                        case Type.calendar:
                            //column.CreateStringAttr("type", "dhxCalendar");
                            column.CreateStringAttr("type", "ed");
                            //column.CreateStringAttr("dateFormat", "%m/%d/%Y %H:%M:%S");
                            column.CreateStringAttr("dateFormat", "%m/%d/%Y");
                            column.CreateStringAttr("sort", "date");
                            break;
                        case Type.checkbox:
                            column.CreateStringAttr("type", "ch");
                            column.CreateStringAttr("sort", "int");
                            break;
                        case Type.combo:
                            if (col.editable) column.CreateStringAttr("type", "coro"); else column.CreateStringAttr("type", "coro");
                            if (col.dicCombo != null)
                            {
                                foreach (KeyValuePair<int, string> item in col.dicCombo)
                                {
                                    CStruct option = column.CreateSubStruct("option");
                                    option.CreateIntAttr("value", item.Key);
                                    option.InnerText = item.Value;
                                }
                            }
                            column.CreateStringAttr("sort", "str");
                            break;
                        default:
                            column.CreateStringAttr("type", "ro");
                            column.CreateStringAttr("sort", "str");
                            break;
                    }
                    switch (col.align)
                    {
                        case Align.left:
                            column.CreateStringAttr("align", "left");
                            break;
                        case Align.right:
                            column.CreateStringAttr("align", "right");
                            break;
                        case Align.justify:
                            column.CreateStringAttr("align", "justify");
                            break;
                        default:
                            column.CreateStringAttr("align", "center");
                            break;
                    }
                }

                columnData = head.ToJSONString();

                foreach (DataRow row in m_dt.Rows)
                {
                    CStruct xrow = rows.CreateSubStruct("row");
                    //foreach (DataColumn col in m_dt.Columns)
                    //{
                    //    xrow.CreateString("cell", DBAccess.ReadStringValue(row[col.ColumnName]));
                    //}
                    if (m_sIDColName != "")
                        xrow.CreateStringAttr("id", DBAccess.ReadStringValue(row[m_sIDColName]));
                    foreach (DCol col in m_cols)
                    {
                        string s = "";
                        try
                        {
                            if (col.dicCombo != null && col.type != Type.combo)
                            {
                                bool bIsNull;
                                int key = DBAccess.ReadIntValue(row[col.name], out bIsNull);
                                if (bIsNull == false)
                                {
                                    if (col.dicCombo.TryGetValue(key, out s) == false)
                                        s = "Unknown";
                                }
                            }
                            else
                                s = DBAccess.ReadStringValue(row[col.name]);
                        }
                        catch
                        {
                        }
                        xrow.CreateString("cell", s);
                    }
                }
                tableData = rows.XML();
            }
        }
    }
}

namespace WorkEnginePPM.ControlTemplates.WorkEnginePPM
{
    public partial class DGrid : System.Web.UI.UserControl
    {

        private _DGrid _dgrid = new _DGrid();
       // private string m_sTableData = "";
        //public string TableData
        //{
        //    get { return m_sTableData; }
        //    set { m_sTableData = value; }
        //}
        //private string m_sColumnData = "";
        //public string ColumnData
        //{
        //    get { return m_sColumnData; }
        //    set { m_sColumnData = value; }
        //}

        public string UID
        {
            get { return "dgrid_" + this.UniqueID; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public _DGrid.DCol AddColumn(string title, int width, _DGrid.Type type = _DGrid.Type.text, _DGrid.Align align = _DGrid.Align.left, string name = "", bool editable = false, bool isId = false, bool hidden = false)
        {
            return _dgrid.AddColumn(title, width, type, align, name, editable, isId, hidden);
        }

        public void SetDataTable(DataTable dt)
        {
            _dgrid.SetDataTable(dt);
        }

        public void Render()
        {
            string sColumnData;
            string sTableData;
            _dgrid.Build(out sColumnData, out sTableData);

            hiddenColumnData.Value = sColumnData;
            hiddenTableData.Value = sTableData; //.Replace("'", "\\'");
        }
    }
}