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
        string type,
        bool? visible = null,
        int? width = null,
        bool? canEdit = null,
        bool? canMove = null,
        bool? canExport = null,
        bool canResize = false,
        bool canFilter = false,
        bool showHint = false,
        bool canSort = false,
        bool canHide = false,
        bool canSelect = false)
    {
        var categoryColumn = columns.CreateSubStruct("C");
        categoryColumn.CreateStringAttr("Name", name);
        categoryColumn.CreateStringAttr("Type", type);

        if (visible != null)
        {
            categoryColumn.CreateIntAttr("Visible", visible.Value ? 1 : 0);
        }
        if (width != null)
        {
            categoryColumn.CreateStringAttr("Width", width.ToString());
        }
        if (canEdit != null)
        {
            categoryColumn.CreateBooleanAttr("CanEdit", canEdit.Value);
        }
        if (canMove != null)
        {
            categoryColumn.CreateIntAttr("CanMove", canMove.Value ? 1 : 0);
        }
        if (canExport != null)
        {
            categoryColumn.CreateIntAttr("CanExport", canExport.Value ? 1 : 0);
        }
        categoryColumn.CreateIntAttr("CanResize", canResize ? 1 : 0);
        categoryColumn.CreateIntAttr("CanFilter", canFilter ? 1 : 0);
        categoryColumn.CreateIntAttr("ShowHint", showHint ? 1 : 0);
        categoryColumn.CreateIntAttr("CanSort", canSort ? 1 : 0);
        categoryColumn.CreateIntAttr("CanHide", canHide ? 1 : 0);
        categoryColumn.CreateIntAttr("CanSelect", canSelect ? 1 : 0);

        return categoryColumn;
    }
}