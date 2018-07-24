using System;

namespace WorkEnginePPM.WebServices.ModelDataCache
{
    [Serializable()]
    class RateFTECache
    {
        public double[] zRate, zFTE;
        private int mxdim;

        public RateFTECache(int arraysize)
        {
            mxdim = arraysize + 1;
            zRate = new double[arraysize + 1];
            zFTE = new double[arraysize + 1];
            for (int i = 0; i < mxdim; i++)
            {
                zRate[i] = 0;
                zFTE[i] = 0;
            }
        }
    }
}
