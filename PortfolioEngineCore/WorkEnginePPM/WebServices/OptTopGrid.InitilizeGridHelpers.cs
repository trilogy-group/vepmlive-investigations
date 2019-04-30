using System;
using System.Diagnostics;
using PortfolioEngineCore;

namespace OptmizerDataCache
{
    internal partial class OptTopGrid
    {
        private void SetColumnFormatting(clsOptFieldDelf column, CStruct columns, string currencyFormat)
        {
            try
            {
                var name = column.fname.Replace("/n", "");
                name = name.Replace(" ", "");
                name = name.Replace("\r", "");
                name = name.Replace("\n", "");
                var valueString = column.fname.Replace("/n", "\n");

                name = $"zX{name}";

                var cStruct = columns.CreateSubStruct("C");

                cStruct.CreateStringAttr("Name", name);
                cStruct.CreateStringAttr("Class", "GMCellMain");
                cStruct.CreateIntAttr("CanDrag", 0);

                if (column.fname != "Budget")
                {
                    cStruct.CreateIntAttr("Visible", 0);
                }

                cStruct.CreateIntAttr("ShowHint", 0);
                cStruct.CreateIntAttr("CaseSensitive", 0);
                cStruct.CreateStringAttr("OnDragCell", "Focus,DragCell");
                m_xDefTree.CreateIntAttr($"{name}CanDrag", 0);
                m_xDefTree.CreateStringAttr($"{name}HtmlPrefix", "<B>");
                m_xDefTree.CreateStringAttr($"{name}HtmlPostfix", "</B>");
                m_xDefNode.CreateIntAttr($"{name}CanDrag", 0);
                m_xDefNode.CreateStringAttr($"{name}HtmlPrefix", string.Empty);
                m_xDefNode.CreateStringAttr($"{name}HtmlPostfix", string.Empty);

                var func = "(Row.id == 'Filter' ? '' : sum())";

                if (column.ftype == 2)
                {
                    cStruct.CreateStringAttr("Type", "Text");
                }
                else if (column.ftype == 3)
                {
                    cStruct.CreateStringAttr("Type", "Float");
                    cStruct.CreateStringAttr("Format", ",0.##");
                    m_xDefTree.CreateStringAttr($"{name}Formula", func);
                    m_xDefTree.CreateStringAttr($"{name}Format", ",0.##");
                    m_xDefNode.CreateStringAttr($"{name}Formula", string.Empty);
                }
                else if (column.ftype == 8)
                {
                    cStruct.CreateStringAttr("Type", "Float");
                    cStruct.CreateStringAttr("Format", currencyFormat);
                    m_xDefTree.CreateStringAttr($"{name}Formula", func);
                    m_xDefTree.CreateStringAttr($"{name}Format", currencyFormat);
                    m_xDefNode.CreateStringAttr($"{name}Formula", string.Empty);
                }
                else
                {
                    cStruct.CreateStringAttr("Type", "Text");
                }

                cStruct.CreateIntAttr("CanEdit", 0);
                cStruct.CreateIntAttr("CanMove", 1);

                m_xHeader1.CreateStringAttr(name, valueString);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
        }

        private void AddPiFinish(CStruct columns)
        {
            CStruct cStruct;
            string name;
            cStruct = columns.CreateSubStruct("C");

            name = "PIFinish";
            cStruct.CreateStringAttr("Name", "PIFinish");
            cStruct.CreateStringAttr("Class", "GMCellMain");
            cStruct.CreateIntAttr("ShowHint", 0);
            cStruct.CreateIntAttr("CaseSensitive", 0);
            cStruct.CreateStringAttr("OnDragCell", "Focus,DragCell");
            m_xDefTree.CreateStringAttr($"{name}HtmlPrefix", "<B>");
            m_xDefTree.CreateStringAttr($"{name}HtmlPostfix", "</B>");
            m_xDefNode.CreateStringAttr($"{name}HtmlPrefix", string.Empty);
            m_xDefNode.CreateStringAttr($"{name}HtmlPostfix", string.Empty);
            cStruct.CreateStringAttr("Type", "Text");
            m_xHeader1.CreateStringAttr(name, "Finish");
        }

        private void AddPiStart(CStruct columns)
        {
            CStruct cStruct;
            string name;
            cStruct = columns.CreateSubStruct("C");
            name = "PIStart";
            cStruct.CreateStringAttr("Name", "PIStart");
            cStruct.CreateStringAttr("Class", "GMCellMain");
            cStruct.CreateIntAttr("ShowHint", 0);
            cStruct.CreateIntAttr("CaseSensitive", 0);
            cStruct.CreateStringAttr("OnDragCell", "Focus,DragCell");
            m_xDefTree.CreateStringAttr($"{name}HtmlPrefix", "<B>");
            m_xDefTree.CreateStringAttr($"{name}HtmlPostfix", "</B>");
            m_xDefNode.CreateStringAttr($"{name}HtmlPrefix", string.Empty);
            m_xDefNode.CreateStringAttr($"{name}HtmlPostfix", string.Empty);
            cStruct.CreateStringAttr("Type", "Text");
            m_xHeader1.CreateStringAttr(name, "Start");
        }

        private void AddCellMain(CStruct columns, string inOutAutojsonMenu)
        {
            CStruct cStruct;
            string name;
            cStruct = columns.CreateSubStruct("C");
            name = "PIStatus";
            cStruct.CreateStringAttr("Name", name);
            cStruct.CreateStringAttr("Class", "GMCellMain");
            cStruct.CreateIntAttr("ShowHint", 0);
            cStruct.CreateIntAttr("CaseSensitive", 0);
            cStruct.CreateStringAttr("Defaults", inOutAutojsonMenu);
            cStruct.CreateStringAttr("OnDragCell", "Focus,DragCell");
            m_xDefTree.CreateStringAttr($"{name}HtmlPrefix", "<B>");
            m_xDefTree.CreateStringAttr($"{name}HtmlPostfix", "</B>");
            m_xDefNode.CreateStringAttr($"{name}HtmlPrefix", string.Empty);
            m_xDefNode.CreateStringAttr($"{name}HtmlPostfix", string.Empty);
            cStruct.CreateStringAttr("Type", "Text");
            m_xHeader1.CreateStringAttr(name, "Selection");
            cStruct.CreateIntAttr("CanHide", 0);
        }

        private void AddPiName(CStruct columns)
        {
            string name;
            CStruct cStruct;
            name = "PIName";
            cStruct = columns.CreateSubStruct("C");
            cStruct.CreateStringAttr("Name", name);
            cStruct.CreateStringAttr("Class", "GMCellMain");
            cStruct.CreateIntAttr("ShowHint", 0);
            cStruct.CreateIntAttr("CaseSensitive", 0);
            cStruct.CreateStringAttr("OnDragCell", "Focus,DragCell");
            m_xDefTree.CreateStringAttr($"{name}HtmlPrefix", "<B>");
            m_xDefTree.CreateStringAttr($"{name}HtmlPostfix", "</B>");
            m_xDefNode.CreateStringAttr($"{name}HtmlPrefix", string.Empty);
            m_xDefNode.CreateStringAttr($"{name}HtmlPostfix", string.Empty);
            cStruct.CreateStringAttr("Type", "Text");
            m_xHeader1.CreateStringAttr(name, "Item Name");
            cStruct.CreateIntAttr("CanHide", 0);
        }

        private void AddPiSelected(CStruct columns)
        {
            CStruct cStruct;
            string name;
            cStruct = columns.CreateSubStruct("C");
            name = "PISelected";
            cStruct.CreateStringAttr("Name", name);
            cStruct.CreateStringAttr("Class", "GMCellMain");
            cStruct.CreateIntAttr("ShowHint", 0);
            cStruct.CreateIntAttr("Width", 120);
            cStruct.CreateIntAttr("CaseSensitive", 0);
            cStruct.CreateStringAttr("OnDragCell", "Focus,DragCell");
            m_xDefTree.CreateStringAttr($"{name}HtmlPrefix", "<B>");
            m_xDefTree.CreateStringAttr($"{name}HtmlPostfix", "</B>");
            m_xDefNode.CreateStringAttr($"{name}HtmlPrefix", string.Empty);
            m_xDefNode.CreateStringAttr($"{name}HtmlPostfix", string.Empty);
            cStruct.CreateStringAttr("Type", "Text");
            m_xHeader1.CreateStringAttr(name, "Selected");
            cStruct.CreateIntAttr("CanHide", 0);
        }

        private void AddPId(CStruct leftColumns)
        {
            CStruct cStruct;
            cStruct = leftColumns.CreateSubStruct("C");
            cStruct.CreateStringAttr("Name", "pid");
            cStruct.CreateStringAttr("Type", "Text");
            cStruct.CreateIntAttr("CanExport", 0);
            cStruct.CreateIntAttr("ShowHint", 0);
            cStruct.CreateIntAttr("CanSort", 0);
            cStruct.CreateIntAttr("CanFilter", 0);
            cStruct.CreateIntAttr("CanResize", 0);
            cStruct.CreateIntAttr("Visible", 0);
            cStruct.CreateIntAttr("CanHide", 0);
            cStruct.CreateIntAttr("CanSelect", 0);
            m_xDefTree.CreateStringAttr("pid", string.Empty);
        }

        private void AddRowId(CStruct leftColumns)
        {
            CStruct cStruct;
            cStruct = leftColumns.CreateSubStruct("C");
            cStruct.CreateStringAttr("Name", "rowid");
            cStruct.CreateStringAttr("Type", "Text");
            cStruct.CreateIntAttr("CanExport", 0);
            cStruct.CreateIntAttr("ShowHint", 0);
            cStruct.CreateIntAttr("CanSort", 0);
            cStruct.CreateIntAttr("CanFilter", 0);
            cStruct.CreateIntAttr("CanResize", 0);
            cStruct.CreateIntAttr("Visible", 0);
            cStruct.CreateIntAttr("CanHide", 0);
            cStruct.CreateIntAttr("CanSelect", 0);
            m_xDefTree.CreateStringAttr("rowid", string.Empty);
        }

        private void AddHeader()
        {
            m_xHeader1 = xGrid.CreateSubStruct("Header");
            m_xHeader1.CreateIntAttr("Spanned", 1);
            m_xHeader1.CreateIntAttr("SortIcons", 2);
            m_xHeader1.CreateStringAttr("HoverCell", "Color");
            m_xHeader1.CreateStringAttr("HoverRow", "");
        }

        private void AddDefinitionNode()
        {
            m_xDefNode = m_xDef.CreateSubStruct("D");
            m_xDefNode.CreateStringAttr("Name", "Leaf");
            m_xDefNode.CreateStringAttr("Calculated", "0");
            m_xDefNode.CreateStringAttr("HoverCell", "Color");
            m_xDefNode.CreateStringAttr("HoverRow", "Color");
            m_xDefNode.CreateStringAttr("FocusCell", "");
            m_xDefNode.CreateStringAttr("HoverCell", "Color");
            m_xDefNode.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            m_xDefNode.CreateIntAttr("NoColorState", 1);
            m_xDefNode.CreateIntAttr("ReCalc", 256);
        }

        private void AddDefinitionTree()
        {
            m_xDefTree = m_xDef.CreateSubStruct("D");
            m_xDefTree.CreateStringAttr("Name", "R");
            m_xDefTree.CreateStringAttr("Calculated", "1");
            m_xDefTree.CreateStringAttr("Calculated", "1");
            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateStringAttr("HoverRow", "Color");
            m_xDefTree.CreateStringAttr("FocusCell", "");
            m_xDefTree.CreateStringAttr("HoverCell", "Color");
            m_xDefTree.CreateIntAttr("NoColorState", 1);
            m_xDefTree.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
            m_xDefTree.CreateIntAttr("ReCalc", 256);
        }

        private void AddTollbar()
        {
            var toolbar = xGrid.CreateSubStruct("Toolbar");
            toolbar.CreateIntAttr("Visible", 0);
        }

        private void AddPanel()
        {
            var panel = xGrid.CreateSubStruct("Panel");
            panel.CreateIntAttr("Visible", 0);
            panel.CreateIntAttr("Select", 0);
            panel.CreateIntAttr("Delete", 0);
            panel.CreateIntAttr("CanHide", 0);
            panel.CreateIntAttr("CanSelect", 0);
        }

        private void AddConfigurationAttributes()
        {
            var config = xGrid.CreateSubStruct("Cfg");
            config.CreateStringAttr("MainCol", "PISelected");
            config.CreateStringAttr("Code", "GTACCNPSQEBSLC");
            config.CreateIntAttr("SuppressCfg", 3);
            config.CreateIntAttr("SuppressMessage", 3);
            config.CreateIntAttr("Dragging", 0);
            config.CreateIntAttr("Sorting", 1);
            config.CreateIntAttr("ColsMoving", 1);
            config.CreateIntAttr("ColsPosLap", 1);
            config.CreateIntAttr("ColsLap", 1);
            config.CreateIntAttr("VisibleLap", 1);
            config.CreateIntAttr("SectionWidthLap", 1);
            config.CreateIntAttr("WideHScroll", 0);
            config.CreateIntAttr("LeftWidth", 150);
            config.CreateIntAttr("Width", 400);
            config.CreateIntAttr("RightWidth", 800);
            config.CreateIntAttr("MinMidWidth", 50);
            config.CreateIntAttr("MinRightWidth", 400);
            config.CreateIntAttr("LeftCanResize", 0);
            config.CreateIntAttr("RightCanResize", 1);
            config.CreateIntAttr("FocusWholeRow", 1);
            config.CreateIntAttr("MaxHeight", 0);
            config.CreateIntAttr("ShowDeleted", 0);
            config.CreateBooleanAttr("DateStrings", true);
            config.CreateIntAttr("MaxWidth", 1);
            config.CreateIntAttr("MaxSort", 2);
            config.CreateIntAttr("AppendId", 0);
            config.CreateIntAttr("FullId", 0);
            config.CreateStringAttr("IdChars", "0123456789");
            config.CreateIntAttr("NumberId", 1);
            config.CreateIntAttr("LastId", 1);
            config.CreateIntAttr("CaseSensitiveId", 0);
            config.CreateStringAttr("Style", "GM");
            config.CreateStringAttr("CSS", "ResPlanAnalyzer");
            config.CreateIntAttr("FastColumns", 1);
            config.CreateIntAttr("ExpandAllLevels", 3);
            config.CreateIntAttr("NoTreeLines", 1);
            config.CreateIntAttr("ShowVScroll", 1);
        }
    }
}