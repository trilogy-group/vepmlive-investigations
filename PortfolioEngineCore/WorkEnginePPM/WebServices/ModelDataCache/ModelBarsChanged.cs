using System;

namespace ModelDataCache
{
    [Serializable()]
    public class ModelBarsChanged
    {
        public int redrawCompleteGrid;
        public int barsAffected;
        public int[] RowID;
        public string[] Starts;
        public string[] Finishs;
    }
}
