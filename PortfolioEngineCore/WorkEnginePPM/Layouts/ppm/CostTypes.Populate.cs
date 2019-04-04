using System.Data;
using System.Text;
using PortfolioEngineCore;

namespace WorkEnginePPM
{
    public partial class CostTypes
    {
        private static void PopulateTGridData(int editMode, DBAccess dbAccess, int ctId, CStruct costTypes)
        {
            DataTable dataTable;
            if (editMode == (int)CTEditMode.ctCalculated || editMode == (int)CTEditMode.ctCalculatedCumulative)
            {
                //  why is this here?  maybe it is needed to ensure TGrid initializes correctly even when not used? Maybe can switch to it w/o going back to server?
                dbaUsers.SelectAvailCCs(dbAccess, ctId, out dataTable);
                var tGrid = new _TGrid();
                InitializeCostCategoryColumns(tGrid);
                tGrid.SetDataTable(dataTable);
                string tgridData;
                tGrid.Build(out tgridData);
                costTypes.CreateString("tgridData", tgridData);

                var formula = new StringBuilder();
                dbaCostTypes.SelectCostTypeFormula(dbAccess, ctId, out dataTable);
                var first = true;
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    var component = SqlDb.ReadStringValue(dataRow["CT_NAME"], string.Empty);
                    var clOp = SqlDb.ReadIntValue(dataRow["CL_OP"]);

                    if (!first)
                    {
                        switch (clOp)
                        {
                            case 0:
                                formula.Append(" + ");
                                break;
                            case 1:
                                formula.Append(" - ");
                                break;
                        }
                    }
                    formula.Append(component);

                    first = false;
                }
                costTypes.CreateString("formula", formula.ToString());
            }
            else
            {
                dbaUsers.SelectAvailCCs(dbAccess, ctId, out dataTable);
                var tGrid = new _TGrid();
                InitializeCostCategoryColumns(tGrid);
                tGrid.SetDataTable(dataTable);
                string tgridData;
                tGrid.Build(out tgridData);
                costTypes.CreateString("tgridData", tgridData);
            }
        }

        private static void PopulateNamesAndIds(DBAccess dbAccess, int ctId, CStruct costTypes)
        {
            DataTable dataTable;
            dbaCostTypes.SelectCostTypesForCalc(dbAccess, ctId, out dataTable);
            var fields = costTypes.CreateSubStruct("fields");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var field = fields.CreateSubStruct("field");
                const string CtId = "CT_ID";
                field.CreateInt(CtId, SqlDb.ReadIntValue(dataRow[CtId]));
                field.CreateString("CT_NAME", SqlDb.ReadStringValue(dataRow["CT_NAME"], ""));
            }
        }

        private static void PopulateCFGrid(DBAccess dbAccess, int ctId, CStruct costTypes)
        {
            DataTable dataTable;
            dbaCostTypes.SelectInitializedCostTypeCustomFields(dbAccess, ctId, out dataTable);
            var tGrid = new _TGrid();
            InitializeCustomFieldColumns(tGrid);
            tGrid.SetDataTable(dataTable);
            string tgridData;
            tGrid.Build(out tgridData);
            costTypes.CreateString("tgridCFData", tgridData);
        }

        private static void PopulateCalendar(CStruct costTypes, DBAccess dbAccess)
        {
            var calendars = costTypes.CreateSubStruct("calendars");
            var item = calendars.CreateSubStruct("item");
            item.CreateIntAttr("id", -1);
            item.CreateStringAttr("name", "[None]");
            {
                DataTable dataTable;
                dbaCalendars.SelectCalendars(dbAccess, out dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    item = calendars.CreateSubStruct("item");
                    var nCalendar = SqlDb.ReadIntValue(row["CB_ID"]);
                    item.CreateIntAttr("id", nCalendar);
                    item.CreateStringAttr("name", SqlDb.ReadStringValue(row["CB_NAME"]));
                }
            }
        }

        private static int PopulateBasicCostTypeAttributes(CStruct costTypes, DataTable dataTable)
        {
            costTypes.Initialize("costtype");
            var nEditMode = (int)CTEditMode.ctBudget;
            if (dataTable.Rows.Count == 1)
            {
                var row = dataTable.Rows[0];
                costTypes.CreateIntAttr("CT_ID", SqlDb.ReadIntValue(row["CT_ID"]));
                costTypes.CreateStringAttr("CT_NAME", SqlDb.ReadStringValue(row["CT_NAME"]));
                nEditMode = SqlDb.ReadIntValue(row["CT_EDIT_MODE"]);
                costTypes.CreateIntAttr("CT_EDIT_MODE", nEditMode);
                var selectedCalendar = SqlDb.ReadIntValue(row["CT_CB_ID"]);
                costTypes.CreateIntAttr("CT_CB_ID", selectedCalendar);
                costTypes.CreateIntAttr("CT_INITIAL_LEVEL", SqlDb.ReadIntValue(row["INITIAL_LEVEL"]));
                costTypes.CreateIntAttr("CT_NAMEDRATES", SqlDb.ReadIntValue(row["CT_ALLOW_NAMED_RATES"]));
            }
            else
            {
                costTypes.CreateIntAttr("CT_ID", 0);
                costTypes.CreateStringAttr("CT_NAME", "New Cost Type");
                costTypes.CreateIntAttr("CT_EDIT_MODE", nEditMode);
                costTypes.CreateIntAttr("CT_CB_ID", -1);
                costTypes.CreateIntAttr("CT_INITIAL_LEVEL", 1);
                costTypes.CreateIntAttr("CT_NAMEDRATES", 0);
            }
            return nEditMode;
        }
    }
}