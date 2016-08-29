using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TimeSheets
{
    public abstract class TSBiz
    {
        private TSData _tsDataBacking;
        protected TSData TSData
        {
            get
            {
                if (_tsDataBacking == null)
                    _tsDataBacking = new TSData();
                return _tsDataBacking;
            }
        }
    }
}
