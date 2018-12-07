using System;
using System.Data;
using PortfolioEngineCore;

namespace WorkEnginePPM
{
    internal class ModelsControlCreation
    {
        private const string ModelUIdAttribute = "MODEL_UID";
        private const string ModelNameAttribute = "MODEL_NAME";
        private const string ModelDescAttribute = "MODEL_DESC";
        private const string ModelCbIdAttribute = "MODEL_CB_ID";

        internal static void CreateModel(DataTable dataTable, out CStruct models, out int selectedFlagField)
        {
            const string ModelSelectedFieldId = "MODEL_SELECTED_FIELD_ID";
            const string NewModelValue = "New Model";

            models = new CStruct();
            models.Initialize("Model");

            var selectedCalendar = -1;
            selectedFlagField = 0;
            if (dataTable.Rows.Count == 1)
            {
                var row = dataTable.Rows[0];
                models.CreateIntAttr(ModelUIdAttribute, SqlDb.ReadIntValue(row[ModelUIdAttribute]));
                models.CreateStringAttr(ModelNameAttribute, SqlDb.ReadStringValue(row[ModelNameAttribute]));
                models.CreateStringAttr(ModelDescAttribute, SqlDb.ReadStringValue(row[ModelDescAttribute]));
                selectedCalendar = SqlDb.ReadIntValue(row[ModelCbIdAttribute]);
                models.CreateIntAttr(ModelCbIdAttribute, selectedCalendar);
                selectedFlagField = SqlDb.ReadIntValue(row[ModelSelectedFieldId]);
            }
            else
            {
                models.CreateIntAttr(ModelUIdAttribute, 0);
                models.CreateStringAttr(ModelNameAttribute, NewModelValue);
                models.CreateStringAttr(ModelDescAttribute, string.Empty);
                models.CreateIntAttr(ModelCbIdAttribute, selectedCalendar);
            }
        }

        internal static void CreateCalendars(CStruct models, DBAccess dbAccess)
        {
            DataTable dataTable;
            var calendars = models.CreateSubStruct("calendars");
            var item = calendars.CreateSubStruct("item");
            item.CreateIntAttr("id", -1);
            item.CreateStringAttr("name", "[None]");
            dbaCalendars.SelectCalendars(dbAccess, out dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                item = calendars.CreateSubStruct("item");
                var nCalendar = SqlDb.ReadIntValue(row["CB_ID"]);
                item.CreateIntAttr("id", nCalendar);
                item.CreateStringAttr("name", SqlDb.ReadStringValue(row["CB_NAME"]));
            }
        }

        internal static void CreateCostTypes(CStruct models, DBAccess dbAccess, int viewId)
        {
            DataTable dataTable;
            var costTypes = models.CreateSubStruct("costtypes");
            dbaModels.SelectCostTypesForModel(dbAccess, viewId, out dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                var item = costTypes.CreateSubStruct("item");
                var costType = SqlDb.ReadIntValue(row["CT_ID"]);
                item.CreateIntAttr("id", costType);
                item.CreateStringAttr("name", SqlDb.ReadStringValue(row["CT_NAME"]));
                item.CreateIntAttr("used", SqlDb.ReadIntValue(row["used"]));
            }
        }

        internal static void CreateFlagCustomFields(CStruct models, DBAccess dbAccess, int selectedFlagField)
        {
            DataTable dataTable;
            var flagCustomFields = models.CreateSubStruct("flagcustomfields");
            dbaModels.SelectCustomFields_Flags(dbAccess, out dataTable);
            var item = flagCustomFields.CreateSubStruct("item");
            item.CreateIntAttr("id", -1);
            item.CreateStringAttr("name", "[None]");
            foreach (DataRow row in dataTable.Rows)
            {
                item = flagCustomFields.CreateSubStruct("item");
                var fieldId = SqlDb.ReadIntValue(row["FA_FIELD_ID"]);
                item.CreateIntAttr("id", fieldId);
                item.CreateStringAttr("name", SqlDb.ReadStringValue(row["FA_NAME"]));
                item.CreateIntAttr(
                    "selected",
                    selectedFlagField == fieldId
                        ? 1
                        : 0);
            }
        }

        internal static void SelectAndUpdateSecurity(DBAccess dbAccess, CStruct models)
        {
            DataTable dataTable;
            dbaGroups.SelectEmptyCostTypeSecurityGroups(dbAccess, out dataTable);
            var tGrid = new _TGrid();
            Models.InitializeSecurityColumns(tGrid);
            tGrid.SetDataTable(dataTable);
            string tGridSecurity;
            tGrid.Build(out tGridSecurity);
            models.CreateString("tgridSecurity", tGridSecurity);
        }

        internal static void PopulateModels(_DGrid dGrid, CStruct models)
        {
            string columnData;
            string tableData;
            dGrid.Build(out columnData, out tableData);
            models.CreateString("dgridVersionsColumnData", columnData);
            models.CreateString("dgridVersionsTableData", tableData);
        }

        internal static _DGrid UpdateGrid(DataTable versions)
        {
            var dGrid = new _DGrid();
            dGrid.AddColumn("ID", 50, name: "MODEL_VERSION_UID", isId: true, hidden: true);
            dGrid.AddColumn("Deleted", 50, name: "Deleted", type: _DGrid.Type.checkbox, editable: false, hidden: true);
            dGrid.AddColumn("Name", 150, name: "MODEL_VERSION_NAME", editable: false);
            dGrid.AddColumn("Description", 150, name: "MODEL_VERSION_DESC", editable: false);
            dGrid.AddColumn("Permissions", 250, name: "MODEL_VERSION_PERMISSIONS", editable: false);
            dGrid.AddColumn(
                "PermissionsHidden",
                180,
                name: "MODEL_VERSION_PERMISSIONS_HIDDEN",
                editable: false,
                hidden: true);
            dGrid.SetDataTable(versions);
            return dGrid;
        }

        internal static DataTable BuildNewDataTableWithPermissions(DataTable dataTable)
        {
            var prevVersionId = 0;
            var versions = new DataTable();
            versions.Columns.Add("MODEL_VERSION_UID", Type.GetType("System.Int32"));
            versions.Columns.Add("MODEL_VERSION_NAME", Type.GetType("System.String"));
            versions.Columns.Add("MODEL_VERSION_DESC", Type.GetType("System.String"));
            versions.Columns.Add("MODEL_VERSION_PERMISSIONS", Type.GetType("System.String"));
            versions.Columns.Add("MODEL_VERSION_PERMISSIONS_HIDDEN", Type.GetType("System.String"));
            var rowCount = dataTable.Rows.Count;
            var rowIndex = 0;
            DataRow versionRow = null;
            var permissions = string.Empty;
            var hiddenPermissions = string.Empty;
            foreach (DataRow row in dataTable.Rows)
            {
                rowIndex++;
                var versionId = SqlDb.ReadIntValue(row["MODEL_VERSION_UID"]);
                if (versionId != prevVersionId || rowIndex == 1)
                {
                    if (versionRow != null)
                    {
                        versionRow["MODEL_VERSION_PERMISSIONS"] = permissions;
                        versionRow["MODEL_VERSION_PERMISSIONS_HIDDEN"] = hiddenPermissions;
                    }
                    permissions = string.Empty;
                    hiddenPermissions = string.Empty;
                    versionRow = versions.Rows.Add();
                    versionRow["MODEL_VERSION_UID"] = row["MODEL_VERSION_UID"];
                    versionRow["MODEL_VERSION_NAME"] = row["MODEL_VERSION_NAME"];
                    versionRow["MODEL_VERSION_DESC"] = row["MODEL_VERSION_DESC"];
                }
                var permissionGranded = "No Access";
                if (!row["GROUP_NAME"].Equals(DBNull.Value))
                {
                    if ((int)row["EDIT_PERMISSION"] == 1)
                    {
                        permissionGranded = "Read/Write";
                    }
                    else if ((int)row["VIEW_PERMISSION"] == 1)
                    {
                        permissionGranded = "Read Only";
                    }
                    if (!string.IsNullOrWhiteSpace(permissions))
                    {
                        permissions += ",";
                    }
                    permissions += string.Format("{0}({1})", row["GROUP_NAME"], permissionGranded);
                    if (!string.IsNullOrWhiteSpace(hiddenPermissions))
                    {
                        hiddenPermissions += ",";
                    }
                    hiddenPermissions += string.Format(
                        "{0}::{1}::{2}::{3}",
                        row["GROUP_ID"],
                        row["GROUP_NAME"],
                        row["VIEW_PERMISSION"],
                        row["EDIT_PERMISSION"]);
                }

                if (rowIndex == rowCount && versionRow != null)
                {
                    versionRow["MODEL_VERSION_PERMISSIONS"] = permissions;
                    versionRow["MODEL_VERSION_PERMISSIONS_HIDDEN"] = hiddenPermissions;
                    versionRow = null;
                }
                prevVersionId = versionId;
            }
            return versions;
        }
    }
}