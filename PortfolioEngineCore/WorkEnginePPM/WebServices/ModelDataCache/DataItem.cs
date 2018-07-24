using System;

namespace ModelDataCache
{
    [Serializable()]
    class DataItem
    {
        public string Name = "";
        public string Desc = "";
        public int ID = 0;
        public int UID = 0;
        public int level = 0, group = 0;
        public bool bLoaded = false;
        public bool bEditiable = false;
        public bool bSelected = false;
        public bool bAllSelected = false;
        public int filterpos = 0;
    };
}
