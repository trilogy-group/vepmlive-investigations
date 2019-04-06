using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PortfolioEngineCore;

namespace OptmizerDataCache
{
    internal partial class OptTopGrid
    {
        private static string GetCurrencyFormat(int currencyPosition, int currencyDigits, string currencySymbol)
        {
            string currencyFormat;

            if (currencyDigits == 0)
            {
                currencyFormat = ",0";
            }
            else if (currencyDigits == 1)
            {
                currencyFormat = ",0.0";
            }
            else if (currencyDigits == 0 || currencyDigits == 2)
            {
                currencyFormat = ",0.00";
            }
            else
            {
                currencyFormat = ",0.000";
            }

            if (currencyPosition == 0)
            {
                currencyFormat = $"{currencySymbol}{currencyFormat}";
            }
            else if (currencyPosition == 2)
            {
                currencyFormat = $"{currencySymbol} {currencyFormat}";
            }
            else if (currencyPosition == 1)
            {
                currencyFormat = $"{currencyFormat}{currencySymbol}";
            }
            else
            {
                currencyFormat = $"{currencyFormat} {currencySymbol}";
            }
            return currencyFormat;
        }

        private CStruct xGrid;
        private CStruct m_xMiddleCols;
        private CStruct m_xHeader1;
        private CStruct m_xDef;
        private CStruct m_xDefTree;
        private CStruct m_xDefNode;

        private readonly CStruct[] m_xLevels = new CStruct[64];
        private int m_nLevel = 0;

        public bool InitializeGridLayout(List<clsOptFieldDelf> fielddef, int curr_pos, int curr_digits, string curr_sym)
        {
            var inOutAutojsonMenu = "{Items:["
                + "{Name:'1',Text:'In',Value:'In'},{Name:'2',Text:'Out',Value:'Out'},{Name:'3',Text:'Auto',Value:'Auto'}"
                + "]}";

            // set up the currency formatting
            var currencyFormat = GetCurrencyFormat(curr_pos, curr_digits, curr_sym);

            xGrid = new CStruct();
            xGrid.Initialize("Grid");

            AddTollbar();
            AddPanel();
            AddConfigurationAttributes();

            var leftColumns = xGrid.CreateSubStruct("LeftCols");
            var columns = xGrid.CreateSubStruct("Cols");

            m_xMiddleCols = columns;

            m_xDef = xGrid.CreateSubStruct("Def");
            AddDefinitionTree();
            AddDefinitionNode();

            xGrid.CreateSubStruct("Head");
            AddHeader();

            AddRowId(leftColumns);
            AddPId(leftColumns);

            AddPiSelected(columns);
            AddPiName(columns);
            AddCellMain(columns, inOutAutojsonMenu);
            AddPiStart(columns);
            AddPiFinish(columns);

            foreach (var column in fielddef)
            {
                SetColumnFormatting(column, columns, currencyFormat);
            }

            return true;
        }

        public void FinalizeGridLayout()
        {
        }

        public string GetString()
        {
            return xGrid.XML();
        }

        public bool InitializeGridData()
        {
            var body = xGrid.CreateSubStruct("Body");
            body.CreateSubStruct("B");
            var iStruct = body.CreateSubStruct("I");

            iStruct.CreateBooleanAttr("CanEdit", false);
            m_xLevels[0] = iStruct;

            var iSubStruct = iStruct.CreateSubStruct("I");
            iSubStruct.CreateStringAttr("PISelected", "Selected");
            iSubStruct.CreateStringAttr("rowid", "rselected");
            iSubStruct.CreateStringAttr("pid", "-1");

            m_xLevels[1] = iSubStruct;

            iSubStruct = iStruct.CreateSubStruct("I");
            iSubStruct.CreateStringAttr("PISelected", "Unselected");
            iSubStruct.CreateStringAttr("rowid", "runselected");
            iSubStruct.CreateStringAttr("pid", "-2");

            m_xLevels[2] = iSubStruct;

            return true;
        }

        public void AddDetailRow(clsOptPIData oDet, int rID, List<clsOptFieldDelf> fielddef)
        {
            var parent = m_xLevels[0];

            parent = oDet.PI_Selected == 0
                ? m_xLevels[2]
                : m_xLevels[1];

            var iStruct = parent.CreateSubStruct("I");
            iStruct.CreateStringAttr("id", rID.ToString());
            iStruct.CreateStringAttr("rowid", $"r{rID}");
            iStruct.CreateStringAttr("pid", oDet.PI_ID.ToString());
            iStruct.CreateStringAttr("Color", "white");
            iStruct.CreateStringAttr("Def", "Leaf");
            iStruct.CreateIntAttr("NoColorState", 1);
            iStruct.CreateBooleanAttr("CanEdit", false);

            iStruct.CreateStringAttr("PIName", oDet.PI_Name);

            if (oDet.PI_Mode == 1)
            {
                iStruct.CreateStringAttr("PIStatus", "In");
            }
            else if (oDet.PI_Mode == 2)
            {
                iStruct.CreateStringAttr("PIStatus", "Out");
            }
            else
            {
                iStruct.CreateStringAttr("PIStatus", "Auto");
            }

            iStruct.CreateStringAttr("PISelected", " ");
            iStruct.CreateStringAttr("PIStatusButton", "Defaults");

            iStruct.CreateStringAttr(
                "PIStart",
                oDet.StartDate == DateTime.MinValue
                    ? string.Empty
                    : oDet.StartDate.ToString("MM/dd/yyyy"));

            iStruct.CreateStringAttr(
                "PIFinish",
                oDet.FinishDate == DateTime.MinValue
                    ? string.Empty
                    : oDet.FinishDate.ToString("MM/dd/yyyy"));
            var columnId = 0;

            foreach (var column in fielddef)
            {
                try
                {
                    var name = column.fname.Replace("/n", string.Empty);
                    name = name.Replace(" ", string.Empty);
                    name = name.Replace("\r", string.Empty);
                    name = name.Replace("\n", string.Empty);
                    name = $"zX{name}";

                    var valueString = oDet.m_PI_Extra_data.ElementAt(columnId);

                    ++columnId;

                    iStruct.CreateStringAttr(name, valueString);
                }

                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }
            }

            iStruct.CreateIntAttr("NoColorState", 1);
        }
    }
}