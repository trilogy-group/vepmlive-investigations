using System;

namespace EPMLiveCore.API
{
    [Serializable]
    public class MyWorkGridView
    {
        #region Properties (10) 

        public string Cols { get; set; }

        public bool Default { get; set; }

        public string Filters { get; set; }

        public string Grouping { get; set; }

        public string Id { get; set; }

        public string LeftCols { get; set; }

        public string Name { get; set; }

        public bool Personal { get; set; }

        public string RightCols { get; set; }

        public string Sorting { get; set; }

        #endregion Properties 
    }
}