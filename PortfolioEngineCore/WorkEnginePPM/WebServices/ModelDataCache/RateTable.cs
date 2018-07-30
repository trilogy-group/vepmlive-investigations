using System;

namespace ModelDataCache
{
    [Serializable()]
    class RateTable
    {
        public int UID, ID, Level;
        public string Name;
        public double[] zRate;
        private int mxdim;

        public RateTable(int arraysize)
        {
            mxdim = arraysize + 1;
            zRate = new double[arraysize + 1];
            for (int i = 0; i < mxdim; i++)
            {
                zRate[i] = 0;
            }
        }
    }
}
