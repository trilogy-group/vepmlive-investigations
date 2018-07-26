using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPMLiveCore;
using ModelDataCache;
using PortfolioEngineCore;

public abstract class GridBase<TPeriodData, TDetailRowData>
{
    protected CStruct Constructor;
    protected readonly CStruct[] Levels = new CStruct[64];
    protected int Level = 0;
    protected CStruct Header1;
    protected CStruct Header2;
    protected CStruct PeriodCols;

    protected IList<TPeriodData> Periods;
    protected IList<TDetailRowData> DetailRows;
    
    protected abstract bool CheckIfDetailRowShouldBeAdded(TDetailRowData detailRow);

    public void AddPeriodsData(IEnumerable<TPeriodData> periods)
    {
        Periods = periods.ToArray();
    }

    public List<TDetailRowData> AddDetailRowsData(IEnumerable<TDetailRowData> detailRowsData)
    {
        var result = new List<TDetailRowData>();
        foreach (var detailRow in detailRowsData)
        {
            if (CheckIfDetailRowShouldBeAdded(detailRow))
            {
                result.Add(detailRow);
            }
        }

        DetailRows = result;
        return result;
    }

    public string RenderToXml(GridRenderingTypes renderingType)
    {
        if (renderingType == GridRenderingTypes.None)
        {
            throw new ArgumentException("renderingType");
        }

        Constructor = new CStruct();
        Constructor.Initialize("Grid");

        if (renderingType.HasFlag(GridRenderingTypes.Layout))
        {
            InitializeGridLayout(renderingType);

            if (Periods != null)
            {
                AddPeriodColumns(Periods);
            }

            FinalizeGridLayout(renderingType);
        }

        if (renderingType.HasFlag(GridRenderingTypes.Data))
        {
            InitializeGridData(renderingType);

            if (DetailRows != null)
            {
                for(var i = 0; i < DetailRows.Count; i++)
                {
                    AddDetailRow(DetailRows[i], i);
                }
            }
        }

        return Constructor.XML();
    }

    protected abstract void InitializeGridLayout(GridRenderingTypes renderingType);
    protected abstract void InitializeGridData(GridRenderingTypes renderingType);
    protected virtual void FinalizeGridLayout(GridRenderingTypes renderingType)
    {

    }

    protected abstract void AddDetailRow(TDetailRowData detailRowData, int rowId);

    protected abstract string ResolvePeriodId(TPeriodData periodData, int index);
    
    protected string RemoveCharacters(string input, string characters)
    {
        if (input == null)
        {
            throw new ArgumentNullException("input");
        }

        var result = new StringBuilder(input.Length);

        for (int i = 0; i < input.Length; i++)
        {
            if (characters.IndexOf(input[i]) < 0)
            {
                result.Append(input[i]);
            }
        }

        return result.ToString();
    }

    protected abstract void AddPeriodColumns(IEnumerable<TPeriodData> periods);

    protected CStruct InitializeGridLayoutDefinition(string name = "R")
    {
        var m_xDef = Constructor.CreateSubStruct("Def");
        var m_xDefTree = m_xDef.CreateSubStruct("D");
        m_xDefTree.CreateStringAttr("Name", name);
        m_xDefTree.CreateStringAttr("HoverCell", "Color");
        m_xDefTree.CreateStringAttr("HoverRow", "Color");
        m_xDefTree.CreateStringAttr("FocusCell", "");
        m_xDefTree.CreateStringAttr("OnFocus", "ClearSelection+Grid.SelectRow(Row,!Row.Selected)");
        m_xDefTree.CreateIntAttr("NoColorState", 1);

        return m_xDefTree;
    }

    protected void InitializeGridLayoutHeader1(CStruct xHead, int spanned = -1, int sortIcons = 0)
    {
        Header1 = xHead.CreateSubStruct("Header");
        Header1.CreateIntAttr("Spanned", spanned);
        Header1.CreateIntAttr("SortIcons", sortIcons);
        Header1.CreateStringAttr("HoverCell", "Color");
        Header1.CreateStringAttr("HoverRow", string.Empty);
    }

    protected void InitializeGridLayoutHeader2(CStruct xHead)
    {
        Header2 = xHead.CreateSubStruct("Header");
        Header2.CreateStringAttr("id", "Header");
        Header2.CreateIntAttr("SortIcons", 0);
        Header2.CreateStringAttr("HoverCell", "Color");
        Header2.CreateStringAttr("HoverRow", string.Empty);
    }
}