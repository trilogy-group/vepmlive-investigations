using System;

namespace ModelDataCache
{
    [Serializable()]
    public class TargetRowData
    {
        public int CT_ID;
        public int BC_UID;
        public int BC_ROLE_UID;
        public int BC_SEQ;
        public string MC_Val;
        public int CAT_UID;
        public string CT_Name, Cat_Name, Role_Name, MC_Name, FullCatName, CC_Name, FullCCName, Grouping;
        public bool bGroupRow;

        public int m_rt;
        public string m_rt_name;


        public string sUoM;
        public double[] zCost, zValue, zFTE;
        public int[] OCVal;
        public string[] Text_OCVal;
        public string[] TXVal;
    }
}
