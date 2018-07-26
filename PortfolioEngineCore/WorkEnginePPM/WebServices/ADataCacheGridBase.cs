using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioEngineCore;

internal abstract class ADataCacheGridBase<TPeriodData, TDetailRowData> : GridBase<TPeriodData, TDetailRowData>
{
    protected CStruct InitializeGridLayoutCategoryColumn(
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

    private void CreateIntAttributeFromBoolNullable(CStruct column, string attributeName, bool? value)
    {
        if (value != null)
        {
            column.CreateIntAttr(attributeName, value.Value ? 1 : 0);
        }
    }
}