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
    public class _TGrid
    {
        private DataTable m_dt = null;
        private List<TCol> m_cols = new List<TCol>();

        private string m_sIDColName = "";
        public bool DragAndDrop = false;
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
            integer,
            checkbox,
            date,
            combo
        }

        public class TCol
        {
            public string title;
            public _TGrid.Type type;
            public _TGrid.Align align;
            public int width;
            public string name;
            public bool editable;
            public bool maincol;
            public bool mainlevelcol;
            public bool hidden;
            public System.Collections.Generic.Dictionary<int, string> dicCombo = null;
            public void AddKeyValuePair(int key, string value)
            {
                if (dicCombo == null)
                    dicCombo = new Dictionary<int, string>();
                dicCombo.Add(key, value);
            }
        }

        public _TGrid.TCol AddColumn(string title, int width, Type type = Type.text, _TGrid.Align align = _TGrid.Align.left, string name = "", bool editable = false, bool isId = false, bool maincol = false, bool mainlevelcol = false, bool hidden = false)
        {
            TCol col = new TCol();
            col.title = title;
            col.type = type;
            col.align = align;
            col.width = width;
            col.editable = editable;
            if (name != "") col.name = name; else col.name = title;
            m_cols.Add(col);
            if (isId == true)
                m_sIDColName = col.name;

            col.maincol = maincol;
            col.mainlevelcol = mainlevelcol;
            col.hidden = hidden;
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
        public DataTable SetXmlData(string sTreegridData)
        {
            CStruct xGrid = new CStruct();
            xGrid.LoadXML(sTreegridData);

            DataTable dt = new DataTable();
            foreach (TCol col in m_cols)
            {
                DataColumn dc = dt.Columns.Add();
                switch (col.type)
                {
                    case _TGrid.Type.text:
                        dc.DataType = typeof(String);
                        break;
                    case _TGrid.Type.integer:
                        dc.DataType = typeof(Int32);
                        break;
                    case _TGrid.Type.number:
                        dc.DataType = typeof(Decimal);
                        break;
                    case _TGrid.Type.date:
                        dc.DataType = typeof(DateTime);
                        break;
                    case _TGrid.Type.checkbox:
                        dc.DataType = typeof(Int32);
                        break;
                    default:
                        dc.DataType = typeof(String);
                        break;
                }
                dc.ColumnName = col.name;
            }

            CStruct xBody = xGrid.GetSubStruct("Body");
            CStruct xB = xBody.GetSubStruct("B");
            List<CStruct> listI = xB.GetList("I");
            HandleRows(dt, 1, listI);

            m_dt = dt;
            return dt;
        }
        public void HandleRows(DataTable dt, int level, List<CStruct> listI)
        {
            foreach (CStruct xI in listI)
            {
                if (xI.GetBooleanAttr("Deleted") != true)
                {
                    DataRow dr = dt.Rows.Add();
                    foreach (TCol col in m_cols)
                    {
                        if (col.mainlevelcol)
                        {
                            dr[col.name] = level;
                        }
                        else
                        {
                            switch (col.type)
                            {
                                case _TGrid.Type.text:
                                    dr[col.name] = xI.GetStringAttr(col.name);
                                    break;
                                case _TGrid.Type.integer:
                                    dr[col.name] = Int32.Parse(xI.GetStringAttr(col.name, "0"));
                                    break;
                                case _TGrid.Type.checkbox:
                                    dr[col.name] = Int32.Parse(xI.GetStringAttr(col.name, "0"));
                                    break;
                                case _TGrid.Type.number:
                                     dr[col.name] = Decimal.Parse(xI.GetStringAttr(col.name, "0"));
                                   break;
                                case _TGrid.Type.date:
                                    //DateTime date = DateTime.Parse(xI.GetStringAttr(col.name));
                                    DateTime date;
                                    try { date = DateTime.Parse(xI.GetStringAttr(col.name)); } catch { date = DateTime.Parse("1901-01-01"); }
                                    dr[col.name] = date;
                                    break;
                                default:
                                    dr[col.name] = xI.GetStringAttr(col.name);
                                    break;
                            }
                        }
                    }
                    List<CStruct> listIChildren = xI.GetList("I");
                    if (listIChildren != null && listIChildren.Count > 0)
                        HandleRows(dt, level + 1, listIChildren);
                }
            }
        }
        public void Build(out string sTableData)
        {
            sTableData = "";
            CStruct xGrid = new CStruct();
            xGrid.Initialize("Grid");

            CStruct xToolbar = xGrid.CreateSubStruct("Toolbar");
            xToolbar.CreateIntAttr("Visible", 0);

            CStruct xPanel = xGrid.CreateSubStruct("Panel");
            xPanel.CreateIntAttr("Visible", 0);
            xPanel.CreateIntAttr("Delete", 0);
            CStruct xCfg = xGrid.CreateSubStruct("Cfg");
            xCfg.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            xCfg.CreateIntAttr("SuppressCfg", 1);
            xCfg.CreateIntAttr("InEditMode", 2);
            //xCfg.CreateIntAttr("Selecting", 0);

            xCfg.CreateBooleanAttr("Dragging", DragAndDrop);
            xCfg.CreateBooleanAttr("Dropping", DragAndDrop);
            xCfg.CreateIntAttr("ColsMoving", 0);
            xCfg.CreateIntAttr("ColsPostLap", 1);
            xCfg.CreateIntAttr("ColsLap", 1);
            xCfg.CreateBooleanAttr("ShowDeleted", false);
            xCfg.CreateBooleanAttr("DateStrings", true);
            //xCfg.CreateIntAttr("ConstHeight", 1);
            xCfg.CreateIntAttr("ConstWidth", 2);
            //xCfg.CreateIntAttr("MaxHeight", 1);
            xCfg.CreateIntAttr("MaxWidth", 1);
            xCfg.CreateIntAttr("AppendId", 0);
            xCfg.CreateIntAttr("FullId", 0);
            xCfg.CreateStringAttr("IdChars", "0123456789");
            //xCfg.CreateIntAttr("NumberId", 1);
            //xCfg.CreateIntAttr("LastId", 1);
            //xCfg.CreateIntAttr("CaseSensitiveId", 0);
            xCfg.CreateIntAttr("SelectingCells", 1);
            xCfg.CreateStringAttr("Style", "GM");
            xCfg.CreateStringAttr("CSS", "RPEditor");
            xCfg.CreateIntAttr("Sorting", 0);
            xCfg.CreateIntAttr("FastColumns", 1);
            xCfg.CreateIntAttr("StaticCursor", 1);

            //xCfg.CreateStringAttr("MainCol", "Permission");

            //CStruct xLeftCols = xGrid.CreateSubStruct("LeftCols");
            CStruct xCols = xGrid.CreateSubStruct("Cols");
            //CStruct xHeader = xGrid.CreateSubStruct("Header");
            //xHeader.CreateIntAttr("Visible", 1);
            //xHeader.CreateIntAttr("SortIcons", 0);

            CStruct xC;
            // Add FieldID column
            //CStruct xC = xCols.CreateSubStruct("C");
            //xC.CreateStringAttr("Name", "FieldID");
            //xC.CreateStringAttr("Type", "Int");
            //xC.CreateBooleanAttr("CanEdit", false);
            //xC.CreateBooleanAttr("Visible", false);

            CStruct xHead = xGrid.CreateSubStruct("Head");
            CStruct xColHeader = xGrid.CreateSubStruct("Header");
            xColHeader.CreateIntAttr("ItemNameVisible", 1);
            xColHeader.CreateIntAttr("Spanned", -1);
            xColHeader.CreateIntAttr("SortIcons", 2);

            TCol levelcol = null;

            foreach (TCol col in m_cols)
            {
                if (col.maincol)
                {
                    xCfg.CreateStringAttr("MainCol", col.name);
                    xCfg.CreateIntAttr("NoTreeLines", 1);
                }
                if (col.mainlevelcol == true)
                    levelcol = col;

                // hidden columns are omitted from the view but row data is sent to client
                if (col.hidden == false)
                {
                    xC = xCols.CreateSubStruct("C");
                    if (col.type == Type.combo)
                    {
                        xC.CreateStringAttr("Name", col.name + "_value");
                        xColHeader.CreateStringAttr(col.name + "_value", col.title);
                        xC.CreateIntAttr("CanEdit", col.editable ? 2 : 0);
                    }
                    else
                    {
                        xC.CreateStringAttr("Name", col.name);
                        xColHeader.CreateStringAttr(col.name, col.title);
                        xC.CreateBooleanAttr("CanEdit", col.editable);
                    }
                    xC.CreateIntAttr("Width", col.width);
                    xC.CreateBooleanAttr("Visible", true);
                    //xC.CreateIntAttr("MinWidth", 50);
                    //xC.CreateIntAttr("CanMove", 0);
                    //xC.CreateStringAttr("Defaults", jsonLookup);
                    //xC.CreateStringAttr("Type", "Float");
                    //xC.CreateStringAttr("EditFormat", "0.###");
                    //xC.CreateStringAttr("Format", ",0.000;<span style='color:red;'>-,0.000</span>;");
                    //xC.CreateIntAttr("CanResize", 0);
                    //xC.CreateIntAttr("ShowHint", 0);

                    switch (col.type)
                    {
                        case _TGrid.Type.text:
                            xC.CreateStringAttr("Type", "Text");
                            break;
                        case _TGrid.Type.integer:
                            xC.CreateStringAttr("Type", "Int");
                            break;
                        case _TGrid.Type.checkbox:
                            xC.CreateStringAttr("Type", "Bool");
                            xC.CreateIntAttr("BoolIcon", 4);
                            xC.CreateIntAttr("MinWidth", 30);
                            break;
                        case _TGrid.Type.number:
                            xC.CreateStringAttr("Type", "Float");
                            break;
                        case _TGrid.Type.date:
                            xC.CreateStringAttr("Type", "Date");
                            xC.CreateStringAttr("Format", "M/d/yyyy");
                            break;
                        case _TGrid.Type.combo:
                            xC.CreateStringAttr("Type", "Text");
                            //xC.CreateIntAttr("CanEdit", 2);
                            if (col.dicCombo != null)
                            {
                                string sJSON = "";
                                foreach (KeyValuePair<int, string> item in col.dicCombo)
                                {
                                    if (sJSON != "")
                                        sJSON += ",";
                                    sJSON += "{Name:'" + item.Key + "',Text:'" + item.Value + "',Value:'" + item.Key + "'}";
                                }
                                xC.CreateStringAttr("Defaults", "{Items:[" + sJSON + "]}");
                                xC.CreateStringAttr("Button", "Defaults");
                                xC.CreateStringAttr("ValueField", col.name);
                                xC.CreateIntAttr("MinWidth", 30);
                            }
                            break;
                        default:
                            xC.CreateStringAttr("Type", "Text");
                            break;
                    }
                    switch (col.align)
                    {
                        case _TGrid.Align.left:
                            xC.CreateStringAttr("Align", "Left");
                            break;
                        case _TGrid.Align.right:
                            xC.CreateStringAttr("Align", "Right");
                            break;
                        case _TGrid.Align.justify:
                            xC.CreateStringAttr("Align", "Center");
                            break;
                        default:
                            xC.CreateStringAttr("Align", "Center");
                            break;
                    }
                }
            }


            CStruct xBody = xGrid.CreateSubStruct("Body");
            CStruct xB = xBody.CreateSubStruct("B");
            CStruct[] xParent = new CStruct[10];
            int level = 1;
            xParent[0] = xB;
            if (this.m_dt != null)
            {
                foreach (DataRow row in m_dt.Rows)
                {
                    if (levelcol != null)
                    {
                        level = DBAccess.ReadIntValue(row[levelcol.name]);
                        if (level < 1 || level > 9)
                            level = 1;
                    }
                    CStruct xI = xParent[level - 1].CreateSubStruct("I");
                    xParent[level] = xI;
                    //if (m_sIDColName != "")
                    //    xrow.CreateStringAttr("id", DBAccess.ReadStringValue(row[m_sIDColName]));
                    foreach (TCol col in m_cols)
                    {
                        string s = "";
                        try
                        {
                            switch (col.type)
                            {
                                case _TGrid.Type.checkbox:
                                    s = DBAccess.ReadStringValue(row[col.name]);
                                    //s = "0";
                                    break;
                                case _TGrid.Type.combo:
                                    if (col.dicCombo != null)
                                    {
                                        bool bIsNull;
                                        s = DBAccess.ReadStringValue(row[col.name]);
                                        int key = DBAccess.ReadIntValue(row[col.name], out bIsNull);
                                        if (bIsNull == false)
                                        {
                                            string sval = "Unknown";
                                            col.dicCombo.TryGetValue(key, out sval);
                                            xI.CreateStringAttr(col.name + "_value", sval);
                                        }
                                    }
                                    break;
                                default:
                                    s = DBAccess.ReadStringValue(row[col.name]);
                                    break;
                            }
                        }
                        catch
                        {
                        }
                        xI.CreateStringAttr(col.name, s);
                    }
                }
            }
            sTableData = xGrid.XML();
        }
    }
}

namespace WorkEnginePPM
{
    public partial class TGrid : System.Web.UI.UserControl
    {
        private _TGrid _tgrid = new _TGrid();
        //private string m_sTableData = "";
        //public string TableData
        //{
        //    get { return m_sTableData; }
        //    set { m_sTableData = value; }
        //}
        public bool DragAndDrop
        {
            get { return _tgrid.DragAndDrop; }
            set { _tgrid.DragAndDrop = value; }
        }
        public string UID
        {
            get { return "tgrid_" + this.UniqueID; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //<link rel="stylesheet" type="text/css" href="/_layouts/ppm/RPEditor.ascx.css" />

            //<script src="/_layouts/epmlive/TreeGrid/GridE.js" type="text/javascript"></script>
            //<script src="/_layouts/ppm/tools/tgrid.ascx.js" type="text/javascript"></script>
            //if (!IsPostBack)
            {
                //Type cstype = this.GetType();
                //if (!Page.ClientScript.IsClientScriptBlockRegistered(cstype, "RPEditor.ascx.css"))
                //    Page.ClientScript.RegisterClientScriptBlock(cstype, "RPEditor.ascx.css",
                //        Page.ResolveUrl("/_layouts/ppm/RPEditor.ascx.css"));

                if (!Page.ClientScript.IsClientScriptIncludeRegistered("GridE"))
                    Page.ClientScript.RegisterClientScriptInclude("GridE",
                        Page.ResolveUrl("/_layouts/epmlive/TreeGrid/GridE.js"));

                if (!Page.ClientScript.IsClientScriptIncludeRegistered("tgrid"))
                    Page.ClientScript.RegisterClientScriptInclude("tgrid",
                        Page.ResolveUrl("/_layouts/ppm/tools/tgrid.ascx.js"));
            }
        }

        public _TGrid.TCol AddColumn(string title, int width, _TGrid.Type type = _TGrid.Type.text, _TGrid.Align align = _TGrid.Align.left, string name = "", bool editable = false, bool isId = false, bool maincol = false, bool mainlevelcol = false, bool hidden = false)
        {
            return _tgrid.AddColumn(title, width, type, align, name, editable, isId, maincol, mainlevelcol, hidden);
        }

        public void SetDataTable(DataTable dt)
        {
            _tgrid.SetDataTable(dt);
        }

        public void Render()
        {
            string sTableData;
            _tgrid.Build(out sTableData);
            hiddenTableData.Value = sTableData;
        }
    }
}