namespace CostDataValues
{
    public interface ITargetRowData
    {
        int CT_ID { get; set; }
        int BC_UID { get; set; }
        int BC_ROLE_UID { get; set; }
        int BC_SEQ { get; set; }
        string MC_Val { get; set; }
        int CAT_UID { get; set; }
        string CT_Name { get; set; }
        string Cat_Name { get; set; }
        string Role_Name { get; set; }
        string MC_Name { get; set; }
        string FullCatName { get; set; }
        string CC_Name { get; set; }
        string FullCCName { get; set; }
        string Grouping { get; set; }
        bool bGroupRow { get; set; }
        int m_rt { get; set; }
        string m_rt_name { get; set; }
        string sUoM { get; set; }
        double[] zCost { get; set; }
        double[] zValue { get; set; }
        double[] zFTE { get; set; }
        int[] OCVal { get; set; }
        string[] Text_OCVal { get; set; }
        string[] TXVal { get; set; }
    }
}
