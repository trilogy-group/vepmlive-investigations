using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioEngineCore;

internal abstract class ADataCacheGridBase<TPeriodData, TDetailRowData> : GridBase<TPeriodData, TDetailRowData>
{

    protected CStruct DefinitionRight;
    protected CStruct DefinitionLeaf;

    protected abstract int CalculateInternalPeriodMin(TDetailRowData resxData);

    protected abstract int CalculateInternalPeriodMax(TDetailRowData resxData);

    protected CStruct CreateColumn(
        CStruct columns,
        string name,
        string type = null,
        bool? visible = null,
        int? width = null,
        bool? canEdit = null,
        bool? canMove = null,
        bool? canExport = null,
        bool? canResize = false,
        bool? canFilter = false,
        bool? showHint = false,
        bool? canSort = false,
        bool? canHide = false,
        bool? canSelect = false)
    {
        var categoryColumn = columns.CreateSubStruct("C");
        categoryColumn.CreateStringAttr("Name", name);

        if (type != null)
        {
            categoryColumn.CreateStringAttr("Type", type);
        }

        if (width != null)
        {
            categoryColumn.CreateStringAttr("Width", width.ToString());
        }
        if (canEdit != null)
        {
            categoryColumn.CreateBooleanAttr("CanEdit", canEdit.Value);
        }

        CreateIntAttributeFromBoolNullable(categoryColumn, "Visible", visible);

        CreateIntAttributeFromBoolNullable(categoryColumn, "CanMove", canMove);
        CreateIntAttributeFromBoolNullable(categoryColumn, "CanExport", canExport);
        CreateIntAttributeFromBoolNullable(categoryColumn, "CanFilter", canFilter);
        CreateIntAttributeFromBoolNullable(categoryColumn, "CanResize", canResize);
        CreateIntAttributeFromBoolNullable(categoryColumn, "ShowHint", showHint);
        CreateIntAttributeFromBoolNullable(categoryColumn, "CanSort", canSort);
        CreateIntAttributeFromBoolNullable(categoryColumn, "CanHide", canHide);
        CreateIntAttributeFromBoolNullable(categoryColumn, "CanSelect", canSelect);

        return categoryColumn;
    }

    protected override int DetailRowIdBase => 1;

    protected void InitializePeriodHeatMapColumn(
        string periodId, 
        string periodName, 
        bool setFormulaForDefinitionRight, 
        string sumFunc)
    {
        var prefix = "P" + periodId + "H";

        Header1.CreateStringAttr(prefix, periodName + "\nHeatMap");

        var column = CreateColumn(PeriodCols, prefix, "Float",
            visible: false,
            canMove: false,
            canResize: null,
            canFilter: null);

        column.CreateStringAttr("Format", ",0.##");
        column.CreateStringAttr("Align", "Right");
        column.CreateIntAttr("MinWidth", 45);
        column.CreateIntAttr("Width", 65);

        if (setFormulaForDefinitionRight)
        {
            DefinitionRight.CreateStringAttr(prefix + "Formula", sumFunc);
            DefinitionRight.CreateStringAttr(prefix + "Format", ",#.##");
        }

        DefinitionLeaf.CreateStringAttr(prefix + "Formula", string.Empty);
    }

    private void CreateIntAttributeFromBoolNullable(CStruct column, string attributeName, bool? value)
    {
        if (value != null)
        {
            column.CreateIntAttr(attributeName, value.Value ? 1 : 0);
        }
    }
}