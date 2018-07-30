using System;

namespace ModelDataCache
{
    [Serializable()]
    class CatItemData
    {
        public int UID, ID, Level, Role_UID, Mode, PID, MC_UID, Category;
        public string Name, UoM, FullName, MC_Val, Role_Name;
        public double[] Rates, FTEConv;

        public CatItemData(int arraysize)
        {

            Rates = new double[arraysize + 1];
            FTEConv = new double[arraysize + 1];
        }
    }
}
