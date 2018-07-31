using System;
using CostDataValues;

[Serializable()]
public class TargetRowData : ITargetRowData
{
    public int CT_ID { get; set; }
    public int BC_UID { get; set; }
    public int BC_ROLE_UID { get; set; }
    public int BC_SEQ { get; set; }
    public string MC_Val { get; set; }
    public int CAT_UID { get; set; }
    public string CT_Name { get; set; }
    public string Cat_Name { get; set; }
    public string Role_Name { get; set; }
    public string MC_Name { get; set; }
    public string FullCatName { get; set; }
    public string CC_Name { get; set; }
    public string FullCCName { get; set; }
    public string Grouping { get; set; }
    public bool bGroupRow { get; set; }
    public int m_rt { get; set; }
    public string m_rt_name { get; set; }
    public string sUoM { get; set; }
    public double[] zCost { get; set; }
    public double[] zValue { get; set; }
    public double[] zFTE { get; set; }
    public int[] OCVal { get; set; }
    public string[] Text_OCVal { get; set; }
    public string[] TXVal { get; set; }
}
